#define FONTDEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using System.Drawing;
using System.IO;

namespace Components {
    class FontRendererComponent : Component{
        public enum Allignment { Center, Left, Right}
        public Allignment CurrentAllignment = Allignment.Left;
        Dictionary<char, Rectangle> GlyphBank = null;
        Dictionary<char, Point> GlyphOffset = null;
        Dictionary<char, int> GlyphKerning = null;
        protected int sprite = 0;
        public int Width(int index) {
            List<int> width = new List<int>();
            width.Add(0);
            foreach (char c in currentWord) {
                if (c == '\n') {
                    width.Add(0);
                    continue;
                }
                if (c == '\t') {
                    width[width.Count-1] += GlyphBank['A'].Width * 4;
                    continue;
                }
                width[width.Count-1] += GlyphKerning[c];
            }
            int max = 0;
            for (int i = 0; i < width.Count; i++) {
                max = Math.Max(max, width[i]);
            }
            return width[index];
        }
        protected string currentWord = null;
        
        public FontRendererComponent(GameObject game,string spritePath, string fntPath) : base("FontRendererComponent", game) {
            sprite = TextureManager.Instance.LoadTexture(spritePath);
            GlyphBank = new Dictionary<char, Rectangle>();
            GlyphOffset = new Dictionary<char, Point>();
            GlyphKerning = new Dictionary<char, int>();
            currentWord = "";
            if (System.IO.File.Exists(fntPath)) {
                using (TextReader reader = File.OpenText(fntPath)) {
#if FONTDEBUG
                    int lineNum = 1;
#endif
                    string contents = reader.ReadLine();
                    while (!string.IsNullOrEmpty(contents)) {
                        string[] content = contents.Split(' ');
                        if (contents[0] != ' ') {
                            if (GlyphBank.ContainsKey(content[0][0])) {
#if FONTDEBUG
                                Console.WriteLine("FontRenderer already contains Char: " + content[0][0]);
#endif
                                continue;
                            }
                            Point sourceLoc = new Point(System.Convert.ToInt32(content[1]), System.Convert.ToInt32(content[2]));
                            Size sourceSizee = new Size(System.Convert.ToInt32(content[3]), System.Convert.ToInt32(content[4]));
                            Rectangle sourceRect = new Rectangle(sourceLoc, sourceSizee);
                            GlyphBank.Add(content[0][0], sourceRect);
                            Point sourceOffset = new Point(System.Convert.ToInt32(content[5]), System.Convert.ToInt32(content[6]));
                            GlyphOffset.Add(content[0][0], sourceOffset);
                            GlyphKerning.Add(content[0][0], System.Convert.ToInt32(content[7]));
#if FONTDEBUG
                            lineNum++;
#endif
                        }
                        else {
                            Point sourceLoc = new Point(System.Convert.ToInt32(content[2]), System.Convert.ToInt32(content[3]));
                            Size sourceSizee = new Size(System.Convert.ToInt32(content[4]), System.Convert.ToInt32(content[5]));
                            Rectangle sourceRect = new Rectangle(sourceLoc, sourceSizee);
                            GlyphBank.Add(' ', sourceRect);
                            Point sourceOffset = new Point(System.Convert.ToInt32(content[6]), System.Convert.ToInt32(content[7]));
                            GlyphOffset.Add(' ', sourceOffset);
                            GlyphKerning.Add(' ', System.Convert.ToInt32(content[8]));
#if FONTDEBUG
                            lineNum++;
#endif
                        }
                        contents = reader.ReadLine();
                    }
                }
            }
            else {
#if FONTDEBUG
                Console.WriteLine("FontRenderer trying to load nonexistant .fnt: " + fntPath);
#endif
                return;
            }
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
            int lineCounter = 0;
            Point karrat = gameObject.GlobalPosition;
            if (CurrentAllignment == Allignment.Right) {
                karrat.X -= Width(lineCounter);
            }
            else if (CurrentAllignment == Allignment.Center) {
                karrat.X -= Width(lineCounter)/2;
            }
            for (int i = 0; i < currentWord.Length; i++) {
                if (currentWord[i] == '\n') {
                    lineCounter++;
                    karrat.Y += GlyphBank['A'].Height;
                    if (CurrentAllignment == Allignment.Left) {
                        karrat.X = gameObject.GlobalPosition.X;
                    }
                    else if (CurrentAllignment == Allignment.Right) {
                        karrat.X = gameObject.GlobalPosition.X - Width(lineCounter);
                    }
                    else if (CurrentAllignment == Allignment.Center) {
                        karrat.X = gameObject.GlobalPosition.X - (Width(lineCounter) /2);
                    }
                    continue;
                }
                else if(currentWord[i] == '\t') {
                    karrat.X += GlyphBank['A'].Width * 4;
                    continue;
                }
                Rectangle source = GlyphBank[currentWord[i]];
                TextureManager.Instance.Draw(sprite, new Point(karrat.X + GlyphOffset[currentWord[i]].X, karrat.Y + GlyphOffset[currentWord[i]].Y), 1.0f, source);
                karrat.X += GlyphKerning[currentWord[i]];
            }
            
        }
        public override void OnDestroy() {
            TextureManager.Instance.UnloadTexture(sprite);
        }
    }
}
