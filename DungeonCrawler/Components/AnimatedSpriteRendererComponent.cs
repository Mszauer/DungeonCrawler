using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using System.Drawing;

namespace Components {
    class AnimatedSpriteRendererComponent : Component{
        Dictionary<string, Rectangle[]> AnimationBank = null;
        Dictionary<string, int> SpriteBank = null;
        public int CurrentFrame = 0;
        protected float animTimer = 0.0f;
        protected float frameTimer = 1.0f / 30.0f;
        public string CurrentAnimation = null;

        public AnimatedSpriteRendererComponent(GameObject game) : base("AnimatedSpriteRendererComponent", game) {
            AnimationBank = new Dictionary<string, Rectangle[]>();
            SpriteBank = new Dictionary<string, int>();
        }
        public override void OnRender() {
            if (CurrentAnimation == null) {
                return;
            }
            if (gameObject == null) {
                Console.WriteLine("gameObject is null on "+Name);
                return;
            }
            TextureManager.Instance.Draw(SpriteBank[CurrentAnimation], gameObject.GlobalPosition, 1.0f, AnimationBank[CurrentAnimation][CurrentFrame]);
        }
        public override void OnUpdate(float dTime) {
            if (CurrentAnimation == null) {
                return;
            }
            Animate(dTime);
        }
        public void AddAnimation(string name, string spriteSheet, params Rectangle[] sourceRect) {
            if (AnimationBank.ContainsKey(name)) {
                Console.WriteLine("AnimationBank already contains animation: " + name);
                return;
            }
            if (SpriteBank.ContainsKey(name)) {
                Console.WriteLine("SpriteBank already contains sprite: "+ name);
            }
            int sprite = TextureManager.Instance.LoadTexture(spriteSheet);
            AnimationBank.Add(name, sourceRect);
            SpriteBank.Add(name, sprite);
        }
        public void Animate(float dTime) {
            animTimer += dTime;
            if (animTimer >= frameTimer) {
                animTimer -= frameTimer;
                CurrentFrame++;
                if (CurrentFrame > AnimationBank[CurrentAnimation].Length - 1) {
                    CurrentFrame = 0;
                }
            }
        }
        public void PlayAnimation(string name) {
            if (!SpriteBank.ContainsKey(name)) {
                Console.WriteLine("SpriteBank doesn't contain: " + name);
                return;
            }
            if (!AnimationBank.ContainsKey(name)) {
                Console.WriteLine("AnimationBank doesn't contain: " + name);
                return;            }
            CurrentAnimation = name;
            CurrentFrame = 0;
        }
        public override void OnDestroy() {
            foreach (KeyValuePair<string,int> kvp in SpriteBank) {
                TextureManager.Instance.UnloadTexture(kvp.Value);
            }
        }
    }
}
