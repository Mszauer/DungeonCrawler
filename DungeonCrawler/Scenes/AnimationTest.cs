using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using Components;
using System.Drawing;

namespace Game {
    class AnimationTest : Scene{
        public override void Initialize() {
            GameObject testAnimRenderer = new GameObject("AnimationTester");
            Root.AddChild(testAnimRenderer);
            AnimatedSpriteRendererComponent animator = new AnimatedSpriteRendererComponent(testAnimRenderer);
            animator.AddAnimation("Idle", "Assets/Characters/DarkKnight2/DarkKnight2_Idle.png", new Rectangle(0, 768, 256, 256), new Rectangle(256, 768, 256, 256), new Rectangle(512, 768, 256, 256), new Rectangle(768, 768, 256, 256), new Rectangle(0, 512, 256, 256), new Rectangle(256, 512, 256, 256), new Rectangle(512, 512, 256, 256), new Rectangle(768, 512, 256, 256), new Rectangle(0, 256, 256, 256), new Rectangle(256, 256, 256, 256));
            animator.PlayAnimation("Idle");
            
            GameObject testStaticRender = new GameObject("StaticTester");
            testStaticRender.LocalPosition = new Point(0, 256);
            Root.AddChild(testStaticRender);
            StaticSpriteRendererComponent staticSprite = new StaticSpriteRendererComponent(testStaticRender);
            staticSprite.AddSprite("Background", "Assets/Characters/DarkKnight2/DarkKnight2_Idle.png", new Rectangle(0,768,256,256));

            GameObject StaticFontRenderer = new GameObject("FontTester");
            StaticFontRenderer.LocalPosition = new Point(256, 0);
            Root.AddChild(StaticFontRenderer);
            FontRendererComponent fontRenderer = new FontRendererComponent(StaticFontRenderer, "Assets/Font/bane.png","Assets/Font/bane.fnt");
            fontRenderer.DrawString("The Quick Brown Fox Jumped Over The Lazy Brown Dog");

            /*GameObject AudioPlayer = new GameObject("AudioPlayer", Root);
            Root.AddChild(AudioPlayer);
            AudioSourceComponent audio = new AudioSourceComponent(AudioPlayer);
            AudioPlayer.AddComponent(audio);
            audio.AddSound("BackgroundMusic", "Assets/CourseClear.wav");
            audio.PlaySound("BackgroundMusic");
            */
        }
    }
}
