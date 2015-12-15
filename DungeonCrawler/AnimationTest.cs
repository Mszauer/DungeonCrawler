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
            GameObject testAnim = new GameObject("AnimationTester", Root);
            AnimatedSpriteRendererComponent animator = new AnimatedSpriteRendererComponent(testAnim);
            testAnim.AddComponent(animator);
            animator.AddAnimation("Idle", "Assets/DarkKnight2_Idle.png", new Rectangle(0, 768, 256, 256), new Rectangle(256, 768, 256, 256), new Rectangle(512, 768, 256, 256), new Rectangle(768, 768, 256, 256), new Rectangle(0, 512, 256, 256), new Rectangle(256, 512, 256, 256), new Rectangle(512, 512, 256, 256), new Rectangle(768, 512, 256, 256), new Rectangle(0, 256, 256, 256), new Rectangle(256, 256, 256, 256));
            animator.PlayAnimation("Idle");
            Root.AddChild(testAnim);
        }
    }
}
