
#define FONTDEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using System.Drawing;

namespace Components {
    class FontRendererComponent : Component{
        Dictionary<char, Rectangle> GlyphBank = null;
        protected int sprite = 0;
        protected string currentWord = null;
        public FontRendererComponent(GameObject game,string spritePath) : base("FontRendererComponent", game) {
            sprite = TextureManager.Instance.LoadTexture(spritePath);
            GlyphBank = new Dictionary<char, Rectangle>();
            currentWord = "";
            AddGlyph(' ', new Rectangle(0, 0, 50, 50));
            AddGlyph('!', new Rectangle(50,0,50,50));
            AddGlyph('@', new Rectangle(150,0,50,50));
            AddGlyph('%', new Rectangle(250,0,50,50));
            AddGlyph(',', new Rectangle(600,0,50,50));
            AddGlyph('0', new Rectangle(0,50,50,50));
            AddGlyph('1', new Rectangle(50, 50, 50, 50));
            AddGlyph('2', new Rectangle(100, 50, 50, 50));
            AddGlyph('3', new Rectangle(150, 50, 50, 50));
            AddGlyph('4', new Rectangle(200, 50, 50, 50));
            AddGlyph('5', new Rectangle(250, 50, 50, 50));
            AddGlyph('6', new Rectangle(300, 50, 50, 50));
            AddGlyph('7', new Rectangle(350, 50, 50, 50));
            AddGlyph('8', new Rectangle(400, 50, 50, 50));
            AddGlyph('9', new Rectangle(450, 50, 50, 50));
            AddGlyph(':', new Rectangle(500, 50, 50, 50));
            AddGlyph(';', new Rectangle(550, 50, 50, 50));
            AddGlyph('?', new Rectangle(750, 50, 50, 50));
            AddGlyph('A', new Rectangle(50, 100, 50, 50));
            AddGlyph('B', new Rectangle(100, 100, 50, 50));
            AddGlyph('C', new Rectangle(150, 100, 50, 50));
            AddGlyph('D', new Rectangle(200, 100, 50, 50));
            AddGlyph('E', new Rectangle(250, 100, 50, 50));
            AddGlyph('F', new Rectangle(300, 100, 50, 50));
            AddGlyph('G', new Rectangle(350, 100, 50, 50));
            AddGlyph('H', new Rectangle(400, 100, 50, 50));
            AddGlyph('I', new Rectangle(450, 100, 50, 50));
            AddGlyph('J', new Rectangle(500, 100, 50, 50));
            AddGlyph('K', new Rectangle(550, 100, 50, 50));
            AddGlyph('L', new Rectangle(600, 100, 50, 50));
            AddGlyph('M', new Rectangle(650, 100, 50, 50));
            AddGlyph('N', new Rectangle(700, 100, 50, 50));
            AddGlyph('O', new Rectangle(750, 100, 50, 50));
            AddGlyph('P', new Rectangle(0, 150, 50, 50));
            AddGlyph('Q', new Rectangle(50, 150, 50, 50));
            AddGlyph('R', new Rectangle(100, 150, 50, 50));
            AddGlyph('S', new Rectangle(150, 150, 50, 50));
            AddGlyph('T', new Rectangle(200, 150, 50, 50));
            AddGlyph('U', new Rectangle(250, 150, 50, 50));
            AddGlyph('V', new Rectangle(300, 150, 50, 50));
            AddGlyph('W', new Rectangle(350, 150, 50, 50));
            AddGlyph('X', new Rectangle(400, 150, 50, 50));
            AddGlyph('Y', new Rectangle(450, 150, 50, 50));
            AddGlyph('Z', new Rectangle(500, 150, 50, 50));
            AddGlyph('a', new Rectangle(50, 150, 50, 50));
            AddGlyph('b', new Rectangle(100, 150, 50, 50));
            AddGlyph('c', new Rectangle(150, 150, 50, 50));
            AddGlyph('d', new Rectangle(200, 100, 50, 50));
            AddGlyph('e', new Rectangle(250, 100, 50, 50));
            AddGlyph('f', new Rectangle(300, 150, 50, 50));
            AddGlyph('g', new Rectangle(350, 150, 50, 50));
            AddGlyph('h', new Rectangle(400, 150, 50, 50));
            AddGlyph('i', new Rectangle(450, 150, 50, 50));
            AddGlyph('j', new Rectangle(500, 100, 50, 50));
            AddGlyph('k', new Rectangle(550, 150, 50, 50));
            AddGlyph('l', new Rectangle(600, 100, 50, 50));
            AddGlyph('m', new Rectangle(650, 150, 50, 50));
            AddGlyph('n', new Rectangle(700, 150, 50, 50));
            AddGlyph('o', new Rectangle(750, 100, 50, 50));
            AddGlyph('p', new Rectangle(0, 200, 50, 50));
            AddGlyph('q', new Rectangle(50, 200, 50, 50));
            AddGlyph('r', new Rectangle(100, 250, 50, 50));
            AddGlyph('s', new Rectangle(150, 200, 50, 50));
            AddGlyph('t', new Rectangle(200, 250, 50, 50));
            AddGlyph('u', new Rectangle(250, 200, 50, 50));
            AddGlyph('v', new Rectangle(300, 200, 50, 50));
            AddGlyph('w', new Rectangle(350, 200, 50, 50));
            AddGlyph('x', new Rectangle(400, 200, 50, 50));
            AddGlyph('y', new Rectangle(450, 200, 50, 50));
            AddGlyph('z', new Rectangle(500, 200, 50, 50));
        }
        protected void AddGlyph(char c,Rectangle sourceRect) {
            if (GlyphBank.ContainsKey(c)) {
#if FONTDEBUG
                Console.WriteLine("FontRenderer GlyphBank already contains char: " + c);
#endif
                return;
            }
            GlyphBank.Add(c, sourceRect);
        }
        public void RemoveGlyph(char c) {
            if (!GlyphBank.ContainsKey(c)) {
#if FONTDEBUG
                Console.WriteLine("FontRenderer trying to remove nonexistant glyph: " + c);
#endif
                return;
            }
            GlyphBank.Remove(c);
        }

        public void DrawString(string word) {
            currentWord = word;
        }

        public override void OnRender() {
        Point karrat = gameObject.GlobalPosition;
            for (int i = 0; i < currentWord.Length; i++) {
                if (currentWord[i] == '\n') {
                    karrat.Y += GlyphBank['A'].Height;
                    karrat.X = gameObject.GlobalPosition.X;
                    continue;
                }
                else if(currentWord[i] == '\t') {
                    karrat.X += GlyphBank['A'].Width * 4;
                    continue;
                }
                Rectangle source = GlyphBank[currentWord[i]];
                TextureManager.Instance.Draw(sprite, karrat, 1.0f, source);
                karrat.X += GlyphBank[currentWord[i]].Width;
            }
        }
        public override void OnDestroy() {
            TextureManager.Instance.UnloadTexture(sprite);
        }
    }
}
