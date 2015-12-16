using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using Components;
using System.Drawing;

namespace AnimationTest {
    class AnimationTest : Scene{
        public override void Initialize() {
            GameObject testAnimRenderer = new GameObject("AnimationTester", Root);
            Root.AddChild(testAnimRenderer);
            AnimatedSpriteRendererComponent animator = new AnimatedSpriteRendererComponent(testAnimRenderer);
            testAnimRenderer.AddComponent(animator);
            animator.AddAnimation("Idle", "Assets/DarkKnight2/DarkKnight2_Idle.png", new Rectangle(0, 768, 256, 256), new Rectangle(256, 768, 256, 256), new Rectangle(512, 768, 256, 256), new Rectangle(768, 768, 256, 256), new Rectangle(0, 512, 256, 256), new Rectangle(256, 512, 256, 256), new Rectangle(512, 512, 256, 256), new Rectangle(768, 512, 256, 256), new Rectangle(0, 256, 256, 256), new Rectangle(256, 256, 256, 256));
            animator.PlayAnimation("Idle");
            
            GameObject testStaticRender = new GameObject("StaticTester", Root);
            testStaticRender.LocalPosition = new Point(0, 256);
            Root.AddChild(testStaticRender);
            StaticSpriteRendererComponent staticSprite = new StaticSpriteRendererComponent(testStaticRender);
            testStaticRender.AddComponent(staticSprite);
            staticSprite.AddSprite("Background", "Assets/DarkKnight2/DarkKnight2_Idle.png", new Rectangle(0,768,256,256));

            GameObject StaticFontRenderer = new GameObject("FontTester", Root);
            StaticFontRenderer.LocalPosition = new Point(256, 0);
            Root.AddChild(StaticFontRenderer);
            FontRendererComponent fontRenderer = new FontRendererComponent(StaticFontRenderer, "Assets/FontSheet.png");
            StaticFontRenderer.AddComponent(fontRenderer);
            fontRenderer.DrawString("Hello \n World");

            GameObject AudioPlayer = new GameObject("AudioPlayer", Root);
            Root.AddChild(AudioPlayer);
            AudioSourceComponent audio = new AudioSourceComponent(AudioPlayer);
            AudioPlayer.AddComponent(audio);
            audio.AddSound("BackgroundMusic", "Assets/CourseClear.wav");
            audio.PlaySound("BackgroundMusic");
        }
    }
}
