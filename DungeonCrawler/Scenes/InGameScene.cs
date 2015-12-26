using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components;
using GameFramework;
using System.Drawing;
using System.IO;

namespace Scenes {
    class InGameScene : Scene{
        protected int CurrentHero = 0;
        protected int Monies = 0;

        public override void Initialize() {
            int monsterPoolAmt = 5; //amount of monsters in each unique pool
            int barrelPoolAmt = 3; //possible amount of barrels on screen
            int tilesWidth = 5;
            int tilesHeight = 5;
            Enter();

            GameObject Monster1Pool = new GameObject("Monster1Pool");
            Root.AddChild(Monster1Pool);
            Monster1Pool.Enabled = false;
            for (int i = 0; i < monsterPoolAmt; i++) {
                GameObject Monster1 = new GameObject("Monster1_" + (i+1));
                Monster1Pool.AddChild(Monster1);
                AnimatedSpriteRendererComponent MonsterAnimation = new AnimatedSpriteRendererComponent(Monster1);
                MonsterAnimation.AddAnimation("Idle", "Assets/Characters/DarkKnight/DarkKnight_Idle.png", MonsterAnimation.AddAnimation(4,4,128,128));
                MonsterAnimation.AddAnimation("Hit", "Assets/Characters/DarkKnight/DarkKnight_Hit.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Death", "Assets/Characters/DarkKnight/DarkKnight_Death.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Attack", "Assets/Characters/DarkKnight/DarkKnight_Attack.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.PlayAnimation("Idle");
            }

            GameObject Monster2Pool = new GameObject("Monster2Pool");
            Root.AddChild(Monster2Pool);
            Monster2Pool.Enabled = false;
            for (int i = 0; i < monsterPoolAmt; i++) {
                GameObject Monster2 = new GameObject("Monster2_" + (i + 1));
                Monster2Pool.AddChild(Monster2);
                AnimatedSpriteRendererComponent MonsterAnimation = new AnimatedSpriteRendererComponent(Monster2);
                MonsterAnimation.AddAnimation("Idle", "Assets/Characters/DarkKnight2/DarkKnight2_Idle.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Hit", "Assets/Characters/DarkKnight2/DarkKnight2_Hit.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Death", "Assets/Characters/DarkKnight2/DarkKnight2_Death.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Attack", "Assets/Characters/DarkKnight2/DarkKnight2_Attack.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.PlayAnimation("Idle");
            }

            GameObject Monster3Pool = new GameObject("Monster3Pool");
            Root.AddChild(Monster3Pool);
            Monster3Pool.Enabled = false;
            for (int i = 0; i < monsterPoolAmt; i++) {
                GameObject Monster3 = new GameObject("Monster3_" + (i + 1));
                Monster3Pool.AddChild(Monster3);
                AnimatedSpriteRendererComponent MonsterAnimation = new AnimatedSpriteRendererComponent(Monster3);
                MonsterAnimation.AddAnimation("Idle", "Assets/Characters/Skeleton/Skeleton_Idle.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Hit", "Assets/Characters/Skeleton/Skeleton_Hit.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Death", "Assets/Characters/Skeleton/Skeleton_Death.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Attack", "Assets/Characters/Skeleton/Skeleton_Attack.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.PlayAnimation("Idle");
            }

            GameObject Monster4Pool = new GameObject("Monster4Pool");
            Root.AddChild(Monster4Pool);
            Monster4Pool.Enabled = false;
            for (int i = 0; i < monsterPoolAmt; i++) {
                GameObject Monster4 = new GameObject("Monster4_" + (i + 1));
                Monster4Pool.AddChild(Monster4);
                AnimatedSpriteRendererComponent MonsterAnimation = new AnimatedSpriteRendererComponent(Monster4);
                MonsterAnimation.AddAnimation("Idle", "Assets/Characters/Skeleton2/Skeleton2_Idle.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Hit", "Assets/Characters/Skeleton2/Skeleton2_Hit.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Death", "Assets/Characters/Skeleton2/Skeleton2_Death.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Attack", "Assets/Characters/Skeleton2/Skeleton2_Attack.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.PlayAnimation("Idle");
            }

            GameObject Monster5Pool = new GameObject("Monster5Pool");
            Root.AddChild(Monster5Pool);
            Monster5Pool.Enabled = false;
            for (int i = 0; i < monsterPoolAmt; i++) {
                GameObject Monster5 = new GameObject("Monster5_" + (i + 1));
                Monster5Pool.AddChild(Monster5);
                AnimatedSpriteRendererComponent MonsterAnimation = new AnimatedSpriteRendererComponent(Monster5);
                MonsterAnimation.AddAnimation("Idle", "Assets/Characters/Ogre/Ogre_Idle.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Hit", "Assets/Characters/Ogre/Ogre_Hit.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Death", "Assets/Characters/Ogre/Ogre_Death.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Attack", "Assets/Characters/Ogre/Ogre_Attack.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.PlayAnimation("Idle");
            }

            GameObject Monster6Pool = new GameObject("Monster6Pool");
            Root.AddChild(Monster6Pool);
            Monster6Pool.Enabled = false;
            for (int i = 0; i < monsterPoolAmt; i++) {
                GameObject Monster6 = new GameObject("Monster6_" + (i + 1));
                Monster6Pool.AddChild(Monster6);
                AnimatedSpriteRendererComponent MonsterAnimation = new AnimatedSpriteRendererComponent(Monster6);
                MonsterAnimation.AddAnimation("Idle", "Assets/Characters/Ogre2/Ogre2_Idle.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Hit", "Assets/Characters/Ogre2/Ogre2_Hit.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Death", "Assets/Characters/Ogre2/Ogre2_Death.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Attack", "Assets/Characters/Ogre2/Ogre2_Attack.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.PlayAnimation("Idle");
            }

            GameObject Monster7Pool = new GameObject("Monster7Pool");
            Root.AddChild(Monster7Pool);
            Monster7Pool.Enabled = false;
            for (int i = 0; i < monsterPoolAmt; i++) {
                GameObject Monster7 = new GameObject("Monster7_" + (i + 1));
                Monster7Pool.AddChild(Monster7);
                AnimatedSpriteRendererComponent MonsterAnimation = new AnimatedSpriteRendererComponent(Monster7);
                MonsterAnimation.AddAnimation("Idle", "Assets/Characters/Ninja/Ninja_Idle.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Hit", "Assets/Characters/Ninja/Ninja_Hit.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Death", "Assets/Characters/Ninja/Ninja_Death.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.AddAnimation("Attack", "Assets/Characters/Ninja/Ninja_Attack.png", MonsterAnimation.AddAnimation(4, 4, 128, 128));
                MonsterAnimation.PlayAnimation("Idle");
            }

            GameObject Helper1Pool = new GameObject("Helper1Pool");
            Root.AddChild(Helper1Pool);
            Monster1Pool.Enabled = false;
            for (int i = 0; i < 1; i++) {
                GameObject Helper1 = new GameObject("Helper1_" + (i + 1));
                Helper1Pool.AddChild(Helper1);
                AnimatedSpriteRendererComponent HelperAnimation = new AnimatedSpriteRendererComponent(Helper1);
                HelperAnimation.AddAnimation("Idle", "Assets/Characters/Mage2/Mage2_Idle.png", HelperAnimation.AddAnimation(4, 4, 128, 128));
                HelperAnimation.AddAnimation("Hit", "Assets/Characters/Mage2/Mage2_Hit.png", HelperAnimation.AddAnimation(4, 4, 128, 128));
                HelperAnimation.AddAnimation("Death", "Assets/Characters/Mage2/Mage2_Death.png", HelperAnimation.AddAnimation(4, 4, 128, 128));
                HelperAnimation.AddAnimation("Attack", "Assets/Characters/Mage2/Mage2_Attack.png", HelperAnimation.AddAnimation(4, 4, 128, 128));
                HelperAnimation.PlayAnimation("Idle");
            }

            GameObject Helper2Pool = new GameObject("Helper2Pool");
            Root.AddChild(Helper2Pool);
            Helper2Pool.Enabled = false;
            for (int i = 0; i < 1; i++) {
                GameObject Helper2 = new GameObject("Helper2_" + (i + 1));
                Helper2Pool.AddChild(Helper2);
                AnimatedSpriteRendererComponent HelperAnimation = new AnimatedSpriteRendererComponent(Helper2);
                HelperAnimation.AddAnimation("Idle", "Assets/Characters/Mage2/Mage2_Idle.png", HelperAnimation.AddAnimation(4, 4, 128, 128));
                HelperAnimation.AddAnimation("Hit", "Assets/Characters/Mage2/Mage2_Hit.png", HelperAnimation.AddAnimation(4, 4, 128, 128));
                HelperAnimation.AddAnimation("Death", "Assets/Characters/Mage2/Mage2_Death.png", HelperAnimation.AddAnimation(4, 4, 128, 128));
                HelperAnimation.AddAnimation("Attack", "Assets/Characters/Mage2/Mage2_Attack.png", HelperAnimation.AddAnimation(4, 4, 128, 128));
                HelperAnimation.PlayAnimation("Idle");
            }

            GameObject BarrelPool = new GameObject("BarrelPool");
            Root.AddChild(BarrelPool);
            BarrelPool.Enabled = false;
            for (int i = 0; i < barrelPoolAmt; i++) {
                GameObject barrel = new GameObject("Barrel1_" + (i + 1));
                BarrelPool.AddChild(barrel);
                StaticSpriteRendererComponent BarrelSprite = new StaticSpriteRendererComponent(barrel);
                BarrelSprite.AddSprite("BarrelSprite", "Assets/ObjectSpritesheet.png", new Rectangle(105,679,45,65));
            }

            GameObject CoinPool = new GameObject("CoinPool");
            Root.AddChild(CoinPool);
            CoinPool.Enabled = false;
            for (int i = 0; i < 3; i++) {
                GameObject coins = new GameObject("Coins1_" + (i + 1));
                CoinPool.AddChild(coins);
                StaticSpriteRendererComponent CoinsSprite = new StaticSpriteRendererComponent(coins);
                CoinsSprite.AddSprite("CoinsSprite", "assets/ObjectSpritesheet.png", new Rectangle(245, 865, 60, 35));
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

            GameObject Tiles = new GameObject("Tiles");
            PlayArea.AddChild(Tiles);
            for (int h = 0; h < tilesHeight; h++) {
                for (int w = 0; w < tilesWidth; w++) {
                    GameObject tile = new GameObject("Tile" + h + "_" + w);
                    Tiles.AddChild(tile);
                    StaticSpriteRendererComponent tileSprite = new StaticSpriteRendererComponent(tile);
                    tileSprite.AddSprite("Tile_Active", "Assets/ObjectSpritesheet.png", new Rectangle(0, 605, 65, 65));
                    tileSprite.AddSprite("Tile_Hidden", "Assets/ObjectSpritesheet.png", new Rectangle(400, 790, 65, 65));
                }
            }

            GameObject Exit = new GameObject("Exit");
            PlayArea.AddChild(Exit);
            StaticSpriteRendererComponent exitSprite = new StaticSpriteRendererComponent(Exit);
            exitSprite.AddSprite("Exit_Active", "Assets/ObjectSpritesheet.png", new Rectangle(137, 605, 65, 65));
            exitSprite.AddSprite("Exit_Unlocked", "Assets/ObjectSpritesheet.png", new Rectangle(264,690,65,65));
            exitSprite.AddSprite("Exit_Locked", "Assets/ObjectSpritesheet.png", new Rectangle(71, 607, 65, 65));

            GameObject Key = new GameObject("Key");
            PlayArea.AddChild(Key);
            StaticSpriteRendererComponent keySprite = new StaticSpriteRendererComponent(Key);
            keySprite.AddSprite("KeySprite", "Assets/ObjectSpritesheet.png", new Rectangle(310, 862, 35, 40));

            GameObject heroObj = new GameObject("HeroObj");
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
            }
        }
        public override void Enter() {
            using (StreamReader reader = new StreamReader("Assets/Data/CurrentHero.txt")) {
                CurrentHero = System.Convert.ToInt32(reader.ReadLine());
                Monies = System.Convert.ToInt32(reader.ReadLine());
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
