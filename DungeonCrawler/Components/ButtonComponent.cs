using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameFramework;

namespace Components {
    class ButtonComponent : Component{
        public delegate void ClickCallback();
        public delegate void HoverCallback();
        public delegate void NonHoverCallback();
        public ClickCallback DoClick = null;
        public HoverCallback DoHover = null;
        public NonHoverCallback NoHover = null;
        protected bool wasPushed = false;
        //gameobject location
        //image size of button, get component of the button
        public StaticSpriteRendererComponent buttonRenderer;

        public ButtonComponent(GameObject game):base("ButtonComponent", game) {
        }

        public override void OnActivate() {
            buttonRenderer = (StaticSpriteRendererComponent)gameObject.FindComponent("StaticSpriteRendererComponent");

        }
        public override void OnUpdate(float dTime) {
            //if mouse is in position?
            InputManager i = InputManager.Instance;
            //is x inside?
            if (gameObject.GlobalPosition.X < i.MousePosition.X && i.MousePosition.X < (gameObject.GlobalPosition.X+buttonRenderer.SourceRects[buttonRenderer.CurrentSprite].Width) && gameObject.GlobalPosition.Y < i.MousePosition.Y && i.MousePosition.Y < (gameObject.GlobalPosition.Y + buttonRenderer.SourceRects[buttonRenderer.CurrentSprite].Height)) {
                if (DoHover != null) {
                        DoHover();
                }//end y
                if (DoClick != null) {
                    if (i.MousePressed(OpenTK.Input.MouseButton.Left)) {
                        wasPushed = true;
                    }
                    else {
                        wasPushed = false;
                    }
                    if (i.MouseReleased(OpenTK.Input.MouseButton.Left)) {
                        DoClick();
                    }
                }
            }//end x
            else {
                if (NoHover != null) {
                    NoHover();
                }
            }
        }//end update
    }
}
