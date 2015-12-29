#define RANDOMDEBUG
//#define MOUSEPOSITIONDEBUG
//#define KEYDEBUG
//#define EXITDEBUG
#define BARRELDEBUG
#define ENEMYDEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using GameFramework;
using Game;

namespace Components {
    class GameManagerComponent : Component{
        //helpers
        //enemies
        //coins
        //skeleton objects
        public GameObject Key = null;
        public GameObject[][] ActiveTiles = null;
        public GameObject[][] HiddenTiles = null;
        public GameObject LockedExit = null;
        public GameObject UnlockedExit = null;
        public GameObject BarrelPool = null;
        public GameObject CoinPool = null;
        public GameObject MonsterPool = null;
        public GameObject Helper1Pool = null;

       protected int BarrelSpawnChance = 14;
       protected int CoinSpawnChance = 20;//out of 100
       protected int EnemySpawnChance = 25;
       public bool HasKey = false;

        int floor = 0;
        int randomKeyX = 0;
        int randomKeyY = 0;
        int randomExitX =  0;
        int randomExitY = 0;

        public GameManagerComponent(GameObject game) : base("GameManagerComponent", game) {
            ActiveTiles = new GameObject[5][];
            for (int i = 0; i < ActiveTiles.Length; i++) {
                ActiveTiles[i] = new GameObject[5];
            }
            HiddenTiles = new GameObject[5][];
            for (int i = 0; i < HiddenTiles.Length; i++) {
                HiddenTiles[i] = new GameObject[5];
            }
        }
        public void InitializeLevel() {
            floor++;
            UnlockedExit.Enabled = false;
            LockedExit.Enabled = true;
            Random random = new Random();
            randomKeyX = random.Next(ActiveTiles.Length);
            randomKeyY = random.Next(ActiveTiles[0].Length);
            randomExitX = random.Next(ActiveTiles.Length);
            randomExitY = random.Next(ActiveTiles[0].Length);
            while(randomExitX == randomKeyX && randomExitY == randomKeyY) {
                randomExitX = random.Next(ActiveTiles.Length);
                randomExitY = random.Next(ActiveTiles[0].Length);
            }
#if RANDOMDEBUG
                Console.WriteLine("Key X: " + randomKeyX + " Y: " + randomKeyY);
#endif
            HasKey = false;
            //randomly place key on tile
            Key.LocalPosition = new Point((randomKeyX * 65)+15, (randomKeyY * 65)+15);//65 == tile sprite width, 15 offset to center
            for (int x = 0; x < ActiveTiles.Length; x++) {
                for (int y = 0; y < ActiveTiles[x].Length; y++) {
                    HiddenTiles[x][y].Enabled = true;

                    if (x == randomKeyX && y ==randomKeyY) {
                        continue;
                    }
                    int rando = random.Next(100);
                    if (x == randomExitX && y == randomExitY) {
                        HiddenTiles[x][y].Enabled = false;
                        continue;
                    }
                    if (MonsterPool.FindChild("Monster") != null) {
                        if (rando<EnemySpawnChance) {
#if ENEMYDEBUG
                            Console.WriteLine("Enemy spawned at X: " + x + " Y: " + y);
#endif
                            MonsterPool.FindChild("Monster").LocalPosition = new Point(-40,-50);
                            ActiveTiles[x][y].AddChild(MonsterPool.FindChild("Monster"));
                            ActiveTiles[x][y].FindChild("Monster").Enabled = false;
                        }
                    }
                    if (BarrelPool.FindChild("Barrel") != null && ActiveTiles[x][y].FindChild("Monster") == null) {
                        if (ActiveTiles[x][y].FindChild("Monster") != null) {
                            rando = random.Next(100);
                            continue;
                        }
                        if (rando <= BarrelSpawnChance) {
#if BARRELDEBUG
                            Console.WriteLine("Barrel Spawned at X: " + x + " Y: " + y);
#endif
                            BarrelPool.FindChild("Barrel").LocalPosition = new Point(10,0);
                            
                            ActiveTiles[x][y].AddChild(BarrelPool.FindChild("Barrel"));
                            ActiveTiles[x][y].FindChild("Barrel").Enabled = false;
                            rando = random.Next(100);
                        }
                    }
                    if (CoinPool.FindChild("Coins") != null) {
                        if (rando <= CoinSpawnChance) {
#if BARRELDEBUG
                            Console.WriteLine("Coin spawned at x: " + x + " y: " + y);
#endif
                            GameObject barrel = ActiveTiles[x][y].FindChild("Barrel");
                            GameObject coins = CoinPool.FindChild("Coins");
                            GameObject monster = ActiveTiles[x][y].FindChild("Monster");
                            coins.LocalPosition = new Point(5, 20);
                            if (barrel != null) {
                                barrel.AddChild(coins);
                                coins.Enabled = false;
                                rando = random.Next(100);
                                continue;
                            }
                            if (monster != null) {
                                monster.AddChild(coins);
                                coins.Enabled = false;
                                rando = random.Next(100);
                                continue;
                            }
                            ActiveTiles[x][y].AddChild(coins);
                            coins.Enabled = false;
                            rando = random.Next(100);
                        }
                    }
                    
                    
                }
            }
            LockedExit.LocalPosition = new Point(64 * randomExitX, 64 * randomExitY);
            UnlockedExit.LocalPosition = new Point(64 * randomExitX, 64 * randomExitY);

        }//end initializelevel
        public void BarrelClicked(Point MousePosition, GameObject barrel) {
            if (barrel.Children != null && barrel.Children.Count > 0) {
                for (int i = barrel.Children.Count-1;i>= 0; i--) {
                    barrel.FindChild(barrel.Children[i].Name).Enabled = true;
                    ActiveTiles[(MousePosition.X / 65)][(MousePosition.Y / 65)].AddChild(barrel.Children[i]);
                }
            }
            BarrelPool.AddChild(barrel);
        }
        public void CoinsClicked(Point MousePosition,GameObject coins) {
            CoinPool.AddChild(coins);
        }
        public void EnemyClicked(GameObject monsterPool, GameObject enemy,Point MousePosition) {
            ButtonComponent enemyClick = (ButtonComponent)enemy.FindComponent("ButtonComponent");
            EnemyComponent enemystats = (EnemyComponent)enemy.FindComponent("EnemyComponent");
            AnimatedSpriteRendererComponent enemyAnims = (AnimatedSpriteRendererComponent)enemy.FindComponent("AnimatedSpriteRendererComponent");
            if (enemystats.Health <= 0) {
                enemyAnims.PlayAnimation("Death");
                if (enemy.Children != null && enemy.Children.Count > 0) {
                    for (int i = enemy.Children.Count - 1; i >= 0; i--) {
                        enemy.FindChild(enemy.Children[i].Name).Enabled = true;
                        ActiveTiles[(MousePosition.X / 65)][(MousePosition.Y / 65)].AddChild(enemy.Children[i]);
                    }
                }
            }
        }
        public void TileClicked(Point MousePosition,GameObject tile) {
#if MOUSEPOSITIONDEBUG
            Console.WriteLine("MousePosition X: " + (MousePosition.X / 65) + " Y: " + (MousePosition.Y / 65));
#endif
            if ((MousePosition.X/65) == randomKeyX && (MousePosition.Y/65) == randomKeyY) {
#if KEYDEBUG
                Console.WriteLine("Key Enabled");
#endif
                //if no monster
                Key.Enabled = true;
            }
            if (ActiveTiles[(MousePosition.X / 65)][(MousePosition.Y / 65)].Children != null) {
                if (ActiveTiles[(MousePosition.X / 65)][(MousePosition.Y / 65)].FindChild("Barrel") != null) {
                    ActiveTiles[(MousePosition.X / 65)][(MousePosition.Y / 65)].FindChild("Barrel").Enabled = true;
                }
                if (ActiveTiles[(MousePosition.X / 65)][(MousePosition.Y / 65)].FindChild("Coins", false) != null) {
                    ActiveTiles[(MousePosition.X / 65)][(MousePosition.Y / 65)].FindChild("Coins").Enabled = true;
                }
                if (ActiveTiles[(MousePosition.X / 65)][(MousePosition.Y / 65)].FindChild("Monster", false) != null) {
                    ActiveTiles[(MousePosition.X / 65)][(MousePosition.Y / 65)].FindChild("Monster").Enabled = true;
                }
            }
        }//end tileCliked
    }//end component
}
