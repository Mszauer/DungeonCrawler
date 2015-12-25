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
            Enter();

            GameObject heroObj = new GameObject("HeroObj");
            HeroComponent heroStats = new HeroComponent(heroObj);
            AnimatedSpriteRendererComponent heroSprite = new AnimatedSpriteRendererComponent(heroObj);
            if (CurrentHero == 0) {
                heroSprite.AddAnimation("Idle", "Assets/Characters/Archer/Archer_Idle.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Attack", "Assets/Characters/Archer/Archer_Attack.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Hit", "Assets/Characters/Archer/Archer_Hit.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Death", "Assets/Characters/Archer/Archer_Death.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Walk", "Assets/Characters/Archer/Archer_Walk.png", heroSprite.AddAnimation(4, 4, 128, 128));
            }
            else if (CurrentHero == 1) {
                heroSprite.AddAnimation("Idle", "Assets/Characters/Knight/Knight_Idle.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Attack", "Assets/Characters/Knight/Knight_Attack.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Hit", "Assets/Characters/Knight/Knight_Hit.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Death", "Assets/Characters/Knight/Knight_Death.png", heroSprite.AddAnimation(4, 4, 128, 128));
                heroSprite.AddAnimation("Walk", "Assets/Characters/Knight/Knight_Walk.png", heroSprite.AddAnimation(4, 4, 128, 128));
            }
            else if (CurrentHero == 2) {
                heroSprite.AddAnimation("Idle", "Assets/Characters/Barbarian/Barbarian_Idle.png", heroSprite.AddAnimation(4, 4, 128, 128));

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
