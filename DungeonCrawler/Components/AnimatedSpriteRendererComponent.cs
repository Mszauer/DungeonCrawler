using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using System.Drawing;

namespace AnimationTest.Components {
    class AnimatedSpriteRendererComponent : Component{
        Dictionary<string, Rectangle[]> AnimationBank = null;
        public int CurrentFrame = 0;
        public string CurrentSprite = null;

        public AnimatedSpriteRendererComponent(string name, GameObject game) : base(name, game) {
            Name = name;
        }
        public override void OnRender() {
            
        }
        public void AddSprite(string name, params Rectangle[] sourceRect) {
            if (AnimationBank == null) {
                AnimationBank = new Dictionary<string, Rectangle[]>();
            }
            if (CurrentSprite == null) {
                CurrentSprite = name;
            }
            AnimationBank.Add(name, sourceRect);
        }
        public void Animate() {
            CurrentFrame++;
            if (CurrentFrame > AnimationBank[CurrentSprite].Length - 1) {
                CurrentFrame = 0;
            }
        }
        public void SetSprite(string name) {
            if (Name == name) {
                return;
            }
            CurrentSprite = name;
            CurrentFrame = 0;
        }
    }
}
