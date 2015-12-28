using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components;
using GameFramework;
using System.Drawing;
using System.IO;

namespace Game {
    class InGameScene : Scene{
        protected int CurrentHero = 0;
        protected int Monies = 0;
        protected int currentHealth = 10;
        protected int currentAttack = 1;
        protected int Floor = 1;

        public override void Initialize() {
            int monsterPoolAmt = 5; //amount of monsters in each unique pool
            int barrelPoolAmt = 3; //possible amount of barrels on screen
            int tilesWidth = 5;
            int tilesHeight = 5;
            int UIWidth = 5;
            int UIHeight = 2;
            Enter();

            GameManagerComponent GameManager = new GameManagerComponent(Root);

            //Currency Display
            GameObject currency = new GameObject("Currency");
            currency.LocalPosition = new Point(-140, -50);
            StaticSpriteRendererComponent currencyBG = new StaticSpriteRendererComponent(currency);
            currencyBG.AddSprite("Currency", "Assets/ObjectSpriteSheet.png", new Rectangle(327, 50, 113, 42));

            GameObject currencyAmtObj = new GameObject("CurrencyAmtObj");
            currency.AddChild(currencyAmtObj);
            currencyAmtObj.LocalPosition = new Point(105, 12);//90,9
            FontRendererComponent currencyAmt = new FontRendererComponent(currencyAmtObj, "Assets/Font/14Fontsheet.png", "Assets/Font/14Fontsheet.fnt");
            currencyAmt.CurrentAllignment = FontRendererComponent.Allignment.Right;
            currencyAmt.DrawString(Monies.ToString());//insert currency variable here

            GameObject levelObj = new GameObject("Level");
            levelObj.LocalPosition = new Point(10,-47);
            StaticSpriteRendererComponent levelBgObj = new StaticSpriteRendererComponent(levelObj);
            levelBgObj.AddSprite("Level", "Assets/ObjectSpritesheet.png", new Rectangle(325, 238, 180, 40));

            GameObject levelFntObj = new GameObject("LevelFntObj");
            levelObj.AddChild(levelFntObj);
            levelFntObj.LocalPosition = new Point(5, 5);
            FontRendererComponent floor = new FontRendererComponent(levelFntObj, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            floor.DrawString("Floor: ");
            GameObject levelAmtObj = new GameObject("LevelAmtObj");
            levelObj.AddChild(levelAmtObj);
            levelAmtObj.LocalPosition = new Point(170, 5);
            FontRendererComponent flooramt = new FontRendererComponent(levelAmtObj, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            flooramt.CurrentAllignment = FontRendererComponent.Allignment.Right;
            flooramt.DrawString(Floor.ToString());

            GameObject UI = new GameObject("UI");
            Root.AddChild(UI);

            GameObject UITiles = new GameObject("UITiles");
            UITiles.LocalPosition = new Point(0, 350);
            UI.AddChild(UITiles);
            for (int h = 0; h < UIHeight; h++) {
                for (int w = 0; w < UIWidth; w++) {
                    GameObject Tile = new GameObject("UITile" + h + "_" + w);
                    UITiles.AddChild(Tile);
                    Tile.LocalPosition = new Point(w * 64, h * 64);//1px overlap
                    StaticSpriteRendererComponent tileSprite = new StaticSpriteRendererComponent(Tile);
                    if (h == 0 && w == 0) {
                        tileSprite.AddSprite("TopLeftTile", "Assets/ObjectSpritesheet.png", new Rectangle(39, 857, 65, 65));
                    }
                    else if (h == 0 && w == UIWidth - 1) {
                        tileSprite.AddSprite("TopRightTile", "Assets/ObjectSpritesheet.png", new Rectangle(106, 857, 65, 65));
                    }
                    else if (h == UIHeight - 1 && w == 0) {
                        tileSprite.AddSprite("BottomRightTile", "Assets/ObjectSpritesheet.png", new Rectangle(39, 924, 65, 65));
                    }
                    else if (h == UIHeight - 1 && w == UIWidth - 1) {
                        tileSprite.AddSprite("BottomLeftTile", "Assets/ObjectSpritesheet.png", new Rectangle(106, 924, 65, 65));
                    }
                    else if (h == 0) {
                        tileSprite.AddSprite("UpperTile", "Assets/ObjectSpriteSheet.png", new Rectangle(173, 923, 65, 65));
                    }
                    else if (h == UIHeight - 1) {
                        tileSprite.AddSprite("LowerTile", "Assets/ObjectSpritesheet.png", new Rectangle(173, 857, 65, 65));
                    }
                }
            }
            GameObject petRockObj = new GameObject("PetRockObj");
            UITiles.AddChild(petRockObj);
            GameObject heroObj = new GameObject("HeroObj");
            UI.AddChild(heroObj);
            heroObj.LocalPosition = new Point(15, 340);
            HeroComponent heroStats = new HeroComponent(heroObj);
            AnimatedSpriteRendererComponent heroSprite = new AnimatedSpriteRendererComponent(heroObj);
            if (CurrentHero == 0) {
                heroSprite.AddAnimation("Idle", "Assets/Characters/Archer/Archer_Idle.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Attack", "Assets/Characters/Archer/Archer_Attack.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Hit", "Assets/Characters/Archer/Archer_Hit.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Death", "Assets/Characters/Archer/Archer_Death.png", heroSprite.AddAnimation(4, 4, 128, 128));
            }
            else if (CurrentHero == 1) {
                heroSprite.AddAnimation("Idle", "Assets/Characters/Knight/Knight_Idle.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Attack", "Assets/Characters/Knight/Knight_Attack.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Hit", "Assets/Characters/Knight/Knight_Hit.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Death", "Assets/Characters/Knight/Knight_Death.png", heroSprite.AddAnimation(4, 4, 128, 128));
            }
            else if (CurrentHero == 2) {
                heroSprite.AddAnimation("Idle", "Assets/Characters/Barbarian/Barbarian_Idle.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Attack", "Assets/Characters/Barbarian/Barbarian_Attack.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Hit", "Assets/Characters/Barbarian/Barbarian_Hit.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Death", "Assets/Characters/Barbarian/Barbarian_Death.png", heroSprite.AddAnimation(4, 4, 128, 128));
            }
            heroSprite.PlayAnimation("Idle");

            using (StreamReader reader = new StreamReader("Assets/Data/hero_" + CurrentHero + ".txt")) {
                heroStats.Health = System.Convert.ToInt32(reader.ReadLine());
                heroStats.Attack = System.Convert.ToInt32(reader.ReadLine());
                for (int i = 0; i < 3; i++) {
                    heroStats.AddSkill(reader.ReadLine(), 4, "");
                }
                heroStats.Skills[heroStats.SkillIndexer[1]] = System.Convert.ToInt32(reader.ReadLine());
                heroStats.Skills[heroStats.SkillIndexer[2]] = System.Convert.ToInt32(reader.ReadLine());
                heroStats.Skills[heroStats.SkillIndexer[3]] = System.Convert.ToInt32(reader.ReadLine());

            }
            if (CurrentHero == 2) {
                petRockObj.LocalPosition = new Point(-8, 35);
                StaticSpriteRendererComponent petRock = new StaticSpriteRendererComponent(petRockObj);
                petRock.Anchor = StaticSpriteRendererComponent.AnchorPosition.BottomMiddle;
                if (heroStats.Skills[heroStats.SkillIndexer[2]] == 1) {
                    petRock.AddSprite("Pet Rock1", "Assets/ObjectSpriteSheet.png", new Rectangle(448, 945, 80, 80));
                }
                else if (heroStats.Skills[heroStats.SkillIndexer[2]] == 2) {
                    petRock.AddSprite("Pet Rock2", "Assets/ObjectSpriteSheet.png", new Rectangle(448, 859, 80, 80));
                }
                else if (heroStats.Skills[heroStats.SkillIndexer[2]] == 3) {
                    petRock.AddSprite("Pet Rock3", "Assets/ObjectSpriteSheet.png", new Rectangle(365, 859, 80, 80));
                }
                else if (heroStats.Skills[heroStats.SkillIndexer[2]] >= 4) {
                    petRock.AddSprite("Pet Rock4", "Assets/ObjectSpriteSheet.png", new Rectangle(365, 945, 80, 80));
                }
                else {
                    Console.WriteLine("Skill indexer: " + heroStats.Skills[heroStats.SkillIndexer[2]].ToString());
                }
            }

            GameObject HeroStats = new GameObject("HeroStats");
            UITiles.AddChild(HeroStats);
            HeroStats.LocalPosition = new Point(135, 13);
            //health bar
            GameObject healthBarBGObj = new GameObject("HealthBarBGObj");
            HeroStats.AddChild(healthBarBGObj);
            StaticSpriteRendererComponent healthBarBGSprite = new StaticSpriteRendererComponent(healthBarBGObj);
            healthBarBGSprite.AddSprite("HealthBarBGSprite", "Assets/ObjectSpritesheet.png", new Rectangle(0, 542, 170, 36));
            GameObject healthBarObj = new GameObject("healthBarObj");
            healthBarObj.LocalPosition = new Point(37, 5);
            healthBarBGObj.AddChild(healthBarObj);
            StaticSpriteRendererComponent healthBarSprite = new StaticSpriteRendererComponent(healthBarObj);
            healthBarSprite.AddSprite("HealthBarSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(0, 579, 128, 24));
            //armor bar
            GameObject armorBarBgObj = new GameObject("ArmorBarBgObj");
            HeroStats.AddChild(armorBarBgObj);
            armorBarBgObj.LocalPosition = new Point(5, 35);
            StaticSpriteRendererComponent armorBarBgSprite = new StaticSpriteRendererComponent(armorBarBgObj);
            armorBarBgSprite.AddSprite("ArmorBarBgSprite", "Assets/ObjectSpritesheet.png", new Rectangle(165, 505, 165, 40));
            GameObject armorBarObj = new GameObject("ArmorBarObj");
            armorBarBgObj.AddChild(armorBarObj);
            armorBarObj.LocalPosition = new Point(32, 8);
            StaticSpriteRendererComponent armorBarSprite = new StaticSpriteRendererComponent(armorBarObj);
            armorBarSprite.AddSprite("ArmorBarSprite", "Assets/ObjectSpritesheet.png", new Rectangle(195, 485, 130, 20));
            //temporary stat displayer
            GameObject currentHeroStats = new GameObject("CurrentHeroStats");
            UITiles.AddChild(currentHeroStats);
            currentHeroStats.LocalPosition = new Point(130, 85);
            FontRendererComponent currentStatsAmt = new FontRendererComponent(currentHeroStats, "Assets/Font/14Fontsheet.png", "Assets/Font/14Fontsheet.fnt");
            currentStatsAmt.DrawString("Health: " + currentHealth.ToString() + "   Attack: " + currentAttack.ToString());

            GameObject Helper1Pool = new GameObject("Helper1Pool");
            Root.AddChild(Helper1Pool);
            Helper1Pool.Enabled = false;
            GameManager.Helper1Pool = Helper1Pool;
            for (int i = 0; i < 1; i++) {
                GameObject Helper1 = new GameObject("Helper");
                Helper1Pool.AddChild(Helper1);
                HelperComponent helper = new HelperComponent(Helper1);
                helper.Heal = 7;
                AnimatedSpriteRendererComponent HelperAnimation = new AnimatedSpriteRendererComponent(Helper1);
                HelperAnimation.AddAnimation("Idle", "Assets/Characters/Mage2/Mage2_Idle.png", HelperAnimation.AddAnimation(4, 4, 128, 128));
                HelperAnimation.AddAnimation("Attack", "Assets/Characters/Mage2/Mage2_Attack.png", HelperAnimation.AddAnimation(4, 4, 128, 128));
                HelperAnimation.PlayAnimation("Idle");
                ButtonComponent helperAction = new ButtonComponent(Helper1);
                helperAction.DoClick += delegate {
                    HelperAnimation.PlayAnimation("Attack");
                    currentHealth += helper.Heal;
                    currentStatsAmt.DrawString("Health: " + currentHealth.ToString() + "   Attack: " + currentAttack.ToString());
                    GameManager.HelperClicked(Helper1Pool,Helper1);
                };
            }

            GameObject Helper2Pool = new GameObject("Helper2Pool");
            Root.AddChild(Helper2Pool);
            Helper2Pool.Enabled = false;
            GameManager.Helper2Pool = Helper2Pool;
            for (int i = 0; i < 1; i++) {
                GameObject Helper2 = new GameObject("Helper");
                Helper2Pool.AddChild(Helper2);
                HelperComponent helper = new HelperComponent(Helper2);
                helper.Attack = 4;
                AnimatedSpriteRendererComponent HelperAnimation = new AnimatedSpriteRendererComponent(Helper2);
                HelperAnimation.AddAnimation("Idle", "Assets/Characters/Mage2/Mage2_Idle.png", HelperAnimation.AddAnimation(4, 4, 128, 128));
                HelperAnimation.AddAnimation("Attack", "Assets/Characters/Mage2/Mage2_Attack.png", HelperAnimation.AddAnimation(4, 4, 128, 128));
                HelperAnimation.PlayAnimation("Idle");
                ButtonComponent helperAction = new ButtonComponent(Helper2);
                helperAction.DoClick += delegate {
                    HelperAnimation.PlayAnimation("Attack");
                    //game manager do attack all active
                    GameManager.HelperClicked(Helper2Pool,Helper2);

                };
            }

            GameObject BarrelPool = new GameObject("BarrelPool");
            Root.AddChild(BarrelPool);
            BarrelPool.Enabled = false;
            GameManager.BarrelPool = BarrelPool;
            for (int i = 0; i < barrelPoolAmt; i++) {
                GameObject barrel = new GameObject("Barrel");
                BarrelPool.AddChild(barrel);
                StaticSpriteRendererComponent BarrelSprite = new StaticSpriteRendererComponent(barrel);
                BarrelSprite.AddSprite("BarrelSprite", "Assets/ObjectSpritesheet.png", new Rectangle(105,679,45,65));
                ButtonComponent barrelClicked = new ButtonComponent(barrel);
                barrelClicked.DoClick += delegate {
                    GameManager.BarrelClicked(InputManager.Instance.MousePosition, barrel);
                };
            }

            
            GameObject CoinPool = new GameObject("CoinPool");
            Root.AddChild(CoinPool);
            CoinPool.Enabled = false;
            GameManager.CoinPool = CoinPool;
            for (int i = 0; i < 3; i++) {
                GameObject coins = new GameObject("Coins");
                CoinPool.AddChild(coins);
                StaticSpriteRendererComponent CoinsSprite = new StaticSpriteRendererComponent(coins);
                CoinsSprite.AddSprite("CoinsSprite", "assets/ObjectSpritesheet.png", new Rectangle(245, 865, 60, 35));
                ButtonComponent coinsClicked = new ButtonComponent(coins);
                coinsClicked.DoClick += delegate {
                    GameManager.CoinsClicked(InputManager.Instance.MousePosition,coins);
                    Monies += 10;
                    currencyAmt.DrawString(Monies.ToString());
                };
            }

            GameObject ChestPool = new GameObject("ChestPool");
            Root.AddChild(ChestPool);
            ChestPool.Enabled = false;
            for (int i = 0; i < 2; i++) {
                GameObject chest = new GameObject("Chest1_" + (i + 1));
                ChestPool.AddChild(chest);
                AnimatedSpriteRendererComponent ChestAnimation = new AnimatedSpriteRendererComponent(chest);
                Rectangle[] frames = new Rectangle[3];
                frames[0] = new Rectangle(221, 799, 55, 57);
                frames[1] = new Rectangle(276, 799, 55, 57);
                frames[2] = new Rectangle(330, 799, 55, 57);
                ChestAnimation.AddAnimation("ChestOpen", "Assets/ObjectSpritesheet.png", frames);
                ChestAnimation.AddAnimation("ChestIdle", "Assets/ObjectSpritesheet.png", frames[0]);
                ChestAnimation.PlayAnimation("ChestIdle");
            }

            GameObject PlayArea = new GameObject("PlayArea");
            Root.AddChild(PlayArea);

            GameObject ActiveTile = new GameObject("Active Tiles");
            PlayArea.AddChild(ActiveTile);
            for (int h = 0; h < tilesHeight; h++) {
                for (int w = 0; w < tilesWidth; w++) {
                    GameObject tile = new GameObject("Tile" + h + "_" + w);
                    tile.LocalPosition = new Point((w * 64), (h * 64));//65 = sprite size, 1px overlap
                    ActiveTile.AddChild(tile);
                    GameManager.ActiveTiles[w][h] = tile;
                    StaticSpriteRendererComponent tileSprite = new StaticSpriteRendererComponent(tile);
                    tileSprite.AddSprite("Tile_Active", "Assets/ObjectSpritesheet.png", new Rectangle(0, 605, 65, 65));
                    
                }
            }
            GameObject UnlockedExit = new GameObject("UnlockedExit");
            PlayArea.AddChild(UnlockedExit);
            GameManager.UnlockedExit = UnlockedExit;
            UnlockedExit.Enabled = true;
            StaticSpriteRendererComponent UnlockedexitSprite = new StaticSpriteRendererComponent(UnlockedExit);
            UnlockedexitSprite.AddSprite("Exit_Active", "Assets/ObjectSpritesheet.png", new Rectangle(137, 605, 65, 65));
            ButtonComponent UnlockedExitButton = new ButtonComponent(UnlockedExit);
            UnlockedExitButton.DoClick += delegate {
                Floor++;
                flooramt.DrawString(Floor.ToString());
                GameManager.InitializeLevel();
            };

            GameObject LockedExit = new GameObject("LockedExit");
            PlayArea.AddChild(LockedExit);
            GameManager.LockedExit = LockedExit;
            LockedExit.Enabled = true;
            StaticSpriteRendererComponent exitSprite = new StaticSpriteRendererComponent(LockedExit);
            exitSprite.AddSprite("Exit_Locked", "Assets/ObjectSpritesheet.png", new Rectangle(71, 607, 65, 65));
            //add button component
            //when clicked display helping tooltip to find the key
            
            GameObject Key = new GameObject("Key");
            GameManager.Key = Key;
            PlayArea.AddChild(Key);
            Key.Enabled = false;
            StaticSpriteRendererComponent keySprite = new StaticSpriteRendererComponent(Key);
            keySprite.AddSprite("KeySprite", "Assets/ObjectSpritesheet.png", new Rectangle(310, 862, 35, 40));
            ButtonComponent keyButton = new ButtonComponent(Key);
            keyButton.DoClick += delegate {
                Key.Enabled = false;
                GameManager.HasKey = true;
                GameManager.LockedExit.Enabled = false;
                GameManager.UnlockedExit.Enabled = true;
            };

            GameObject HiddenTile = new GameObject("Hidden Tiles");
            PlayArea.AddChild(HiddenTile);
            for (int h = 0; h < tilesHeight; h++) {
                for (int w = 0; w < tilesWidth; w++) {
                    GameObject tile = new GameObject("Tile" + h + "_" + w);
                    tile.LocalPosition = new Point((w * 64), (h * 64));//65 = sprite size, 1px overlap
                    HiddenTile.AddChild(tile);
                    GameManager.HiddenTiles[w][h] = tile;
                    StaticSpriteRendererComponent tileSprite = new StaticSpriteRendererComponent(tile);
                    tileSprite.AddSprite("Tile_Hidden", "Assets/ObjectSpritesheet.png", new Rectangle(400, 790, 65, 65));
                    ButtonComponent tileButton = new ButtonComponent(tile);
                    tileButton.DoClick += delegate {
                        if (tile.Enabled) {
                            tile.Enabled = false;
                            GameManager.TileClicked(InputManager.Instance.MousePosition,tile);
                        }
                    };
                }
            }
            GameObject MonsterPool = new GameObject("MonsterPool");
            Root.AddChild(MonsterPool);
            MonsterPool.Enabled = false;
            GameManager.MonsterPool = MonsterPool;
            for (int i = 0; i < monsterPoolAmt; i++) {
                GameObject Monster = new GameObject("Monster");
                MonsterPool.AddChild(Monster);
                EnemyComponent monster = new EnemyComponent(Monster);
                monster.Health = 12;
                monster.Attack = 4;
                AnimatedSpriteRendererComponent MonsterAnimation = new AnimatedSpriteRendererComponent(Monster);
                MonsterAnimation.AddAnimation("Idle", "Assets/Characters/Skeleton1/Skeleton1_Idle.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Hit", "Assets/Characters/Skeleton1/Skeleton1_Hit.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Death", "Assets/Characters/Skeleton1/Skeleton1_Death.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Attack", "Assets/Characters/Skeleton1/Skeleton1_Attack.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.PlayAnimation("Idle");
                ButtonComponent enemy = new ButtonComponent(Monster);
                enemy.DoClick += delegate {
                    MonsterAnimation.PlayAnimation("Attack");
                    currentHealth -= monster.Attack;
                    currentStatsAmt.DrawString("Health: " + currentHealth.ToString() + "   Attack: " + currentAttack.ToString());
                    //enemy takes a hit
                    heroSprite.PlayAnimation("Attack");
                    monster.Health -= currentAttack;
                    GameManager.EnemyClicked(MonsterPool, Monster);
                };
            }

            //money parent
            HeroStats.AddChild(currency);
            HeroStats.AddChild(levelObj);
            GameManager.InitializeLevel();

        }
        public override void Enter() {
            using (StreamReader reader = new StreamReader("Assets/Data/CurrentHero.txt")) {
                CurrentHero = System.Convert.ToInt32(reader.ReadLine());
                Monies = System.Convert.ToInt32(reader.ReadLine());
            }
            using (StreamReader reader = new StreamReader("Assets/Data/hero_" + CurrentHero + ".txt")) {
                currentHealth = System.Convert.ToInt32(reader.ReadLine());
                currentAttack = System.Convert.ToInt32(reader.ReadLine());

            }
        }
        public override void Exit() {
            using (StreamWriter writer = new StreamWriter("Assets/Data/CurrentHero.txt")) {
                writer.WriteLine(CurrentHero.ToString());
                writer.WriteLine(Monies.ToString());
            }
        }
    }
}
