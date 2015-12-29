#define ANIMATEDSPRITEDEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using System.Drawing;

namespace Components {
    class AnimatedSpriteRendererComponent : Component{
        public delegate void OnAnimationFinished();
        public OnAnimationFinished AnimationFinished = null;
        public Dictionary<string, Rectangle[]> AnimationBank = null;
        public Dictionary<string, int> SpriteBank = null;
        public int CurrentFrame = 0;
        protected float animTimer = 0.0f;
        protected float frameTimer = 1.0f / 15.0f;
        public string CurrentAnimation = null;
        public bool loop = false;

        public AnimatedSpriteRendererComponent(GameObject game) : base("AnimatedSpriteRendererComponent", game) {
            AnimationBank = new Dictionary<string, Rectangle[]>();
            SpriteBank = new Dictionary<string, int>();
        }
        public override void OnRender() {
            if (CurrentAnimation == null) {
                return;
            }
            if (gameObject == null) {
#if ANIMATEDSPRITEDEBUG
                Console.WriteLine("AnimatedSprite gameObject is null on "+Name);
#endif
                return;
            }
            TextureManager.Instance.Draw(SpriteBank[CurrentAnimation], gameObject.GlobalPosition, 1.0f, AnimationBank[CurrentAnimation][CurrentFrame]);
        }
        public override void OnUpdate(float dTime) {
            if (CurrentAnimation == null) {
                return;
            }
            do {
                Animate(dTime);
            } while (loop);
        }
        public void AddAnimation(string name, string spriteSheet, params Rectangle[] sourceRect) {
            if (AnimationBank.ContainsKey(name)) {
#if ANIMATEDSPRITEDEBUG
                Console.WriteLine("Animated AnimationBank already contains animation: " + name);
#endif
                return;
            }
            if (SpriteBank.ContainsKey(name)) {
#if ANIMATEDSPRITEDEBUG
                Console.WriteLine("Animated SpriteBank already contains sprite: "+ name);
#endif
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
                    if (AnimationFinished != null) {
                        AnimationFinished();
                    }
                }
            }
        }

        public void PlayAnimation(string name) {
            if (!SpriteBank.ContainsKey(name)) {
#if ANIMATEDSPRITEDEBUG
                Console.WriteLine("Animated SpriteBank doesn't contain: " + name);
#endif
                return;
            }
            if (!AnimationBank.ContainsKey(name)) {
#if ANIMATEDSPRITEDEBUG
                Console.WriteLine("AnimatedSprite AnimationBank doesn't contain: " + name);
#endif
                return;            }
            CurrentAnimation = name;
            CurrentFrame = 0;
        }
        public override void OnDestroy() {
            foreach (KeyValuePair<string,int> kvp in SpriteBank) {
                TextureManager.Instance.UnloadTexture(kvp.Value);
            }
        }
        public Rectangle[] AddAnimation(int rows,int cols, int spriteWidth,int spriteHeight) {
            Rectangle[] frames = new Rectangle[rows*cols];
            int frameNum = 0;
            for (int row = rows-1;row >= 0; row--) {
                Rectangle frame = new Rectangle(0, 0, spriteWidth,spriteHeight);
                frame.Y = row * spriteHeight;
                int sourceCol = 0;
                for (int col = cols-1; col >= 0; col--) {
                    frame.X = spriteWidth * sourceCol;
                    frames[frameNum] = frame;
                    frameNum++;
                    sourceCol++;
                }
            }
            return frames;
        }

    }
}
