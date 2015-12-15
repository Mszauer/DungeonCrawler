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
            testAnim.AddComponent(new AnimatedSpriteRendererComponent("animations", Root));
        }
    }
}
