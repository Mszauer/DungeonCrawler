#define STATICSPRITEDEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using System.Drawing;

namespace Components {
    class StaticSpriteRendererComponent : Component{
        public enum AnchorPosition { TopLeft, Center, BottomMiddle }
        public AnchorPosition Anchor = AnchorPosition.TopLeft;
        public Dictionary<string, int> SpriteBank = null;
        public Dictionary<string,Rectangle> SourceRects = null;
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
            SourceRects = new Dictionary<string, Rectangle>();
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
            Point renderPos = new Point(gameObject.GlobalPosition.X, gameObject.GlobalPosition.Y);
            if (Anchor == AnchorPosition.Center) {
                renderPos.X /= 2;
                renderPos.Y /= 2;
            }
            else if (Anchor == AnchorPosition.BottomMiddle) {
                renderPos.X /= 2;
            }
            TextureManager.Instance.Draw(SpriteBank[CurrentSprite],renderPos,1.0f, SourceRects[CurrentSprite]);
        }
        public void AddSprite(string name, string spriteSheet, Rectangle source) {
            if (SpriteBank.ContainsKey(name) || SourceRects.ContainsKey(name)) {
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
            SourceRects.Add(name, source);
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
