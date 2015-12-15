#define STATICSPRITEDEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using System.Drawing;

namespace AnimationTest {
    class StaticSpriteRendererComponent : Component{
        public Dictionary<string, int> SpriteBank = null;
        protected Dictionary<string,Rectangle> sourceRects = null;
        protected string currentSprite = null;
        public string CurrentSprite {
            get {
                return currentSprite;
            }
            private set {
                currentSprite = value;
            }
        }
        public StaticSpriteRendererComponent(GameObject game) : base("StaticSpriteRendererComponent", game) {
            SpriteBank = new Dictionary<string, int>();
            sourceRects = new Dictionary<string, Rectangle>();
        }
        public override void OnRender() {
            if (gameObject == null) {
#if STATICSPRITEDEBUG
                Console.WriteLine("StaticSpriteRenderer gameObject is null");
#endif
            }
            if (CurrentSprite == null) {
#if STATICSPRITEDEBUG
                Console.WriteLine("StaticSpriteRenderer CurrentSprite is null");
#endif
            }
            TextureManager.Instance.Draw(SpriteBank[CurrentSprite],gameObject.GlobalPosition,1.0f, sourceRects[CurrentSprite]);
        }
        public void AddSprite(string name, string spriteSheet, Rectangle source) {
            if (SpriteBank.ContainsKey(name) || sourceRects.ContainsKey(name)) {
#if STATICSPRITEDEBUG
                Console.WriteLine("Static SpriteBank already contains: " + name);
#endif
                return;
            }
            if (CurrentSprite == null) {
                CurrentSprite = name;
            }
            int sprite = TextureManager.Instance.LoadTexture(spriteSheet);
            SpriteBank.Add(name, sprite);
            sourceRects.Add(name, source);
        }

        public void SetSprite(string name) {
            if (!SpriteBank.ContainsKey(name)){
#if STATICSPRITEDEBUG
                Console.WriteLine("Static Sprite: " + name + " does not exist");
#endif
                return;
            }
            if (CurrentSprite == name) {
#if STATICSPRITEDEBUG
                Console.WriteLine("Static CurrentSprite is already: " + name);
#endif
                return;
            }
            CurrentSprite = name;
        }

        public void RemoveSprite(string name) {
            if (!SpriteBank.ContainsKey(name)) {
#if STATICSPRITEDEBUG
                Console.WriteLine("Static SpriteBank does not contain: " + name);
#endif
                return;
            }
            if (CurrentSprite == name) {
#if STATICSPRITEDEBUG
                Console.WriteLine("Trying to remove CurrentSprite in use: " + name);
#endif
                return;
            }
            TextureManager.Instance.UnloadTexture(SpriteBank[name]);
            SpriteBank.Remove(name);
        }
        public override void OnDestroy() {
            foreach(KeyValuePair<string,int> kvp in SpriteBank) {
                TextureManager.Instance.UnloadTexture(kvp.Value);
            }
        }
    }
}
