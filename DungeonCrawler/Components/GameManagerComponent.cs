#define RANDOMDEBUG
//#define MOUSEPOSITIONDEBUG
//#define KEYDEBUG
//#define EXITDEBUG
#define BARRELDEBUG
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

        public int BarrelSpawnChance = 14;
        public int CoinSpawnChance = 20;//out of 100
        public int EnemyDropChance = 30; //out of 100 for coins to drop
        public bool HasKey = false;

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
                    if (BarrelPool.FindChild("Barrel") != null) {
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

                            coins.LocalPosition = new Point(5, 20);
                            if (barrel != null) {
                                barrel.AddChild(coins);
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
        public void TileClicked(Point MousePosition) {
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
            }
        }//end tileCliked
    }//end component
}
