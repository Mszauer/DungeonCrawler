using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameFramework;
using System.Drawing;
using OpenTK;

namespace AnimatorTest {
    static class Program {
        public static OpenTK.GameWindow Window = null;
        public static void Initialize(object sender, EventArgs e) {
            GraphicsManager.Instance.Initialize(Window);
            TextureManager.Instance.Initialize(Window);
            InputManager.Instance.Initialize(Window);
            SoundManager.Instance.Initialize(Window);
            //Game.Initialize(Window);
        }
        public static void Update(object sender, FrameEventArgs e) {
            float dTime = (float)e.Time;
            if (dTime > 1.0f / 60.0f) {
                dTime = 1.0f / 60.0f;
            }
            InputManager.Instance.Update();
            //Game.Instance.Update(dTime);
        }
        public static void Render(object sender, FrameEventArgs e) {
            GraphicsManager.Instance.ClearScreen(Color.CadetBlue);
            //Game.Instance.Render();
        }
        public static void Shutdown(object sender, EventArgs e) {
            //Game.Instance.Shutdown();
            SoundManager.Instance.Shutdown();
            InputManager.Instance.Shutdown();
            TextureManager.Instance.Shutdown();
            GraphicsManager.Instance.Shutdown();
        }
        [STAThread]
        static void Main(string[] args) {
            Window = new OpenTK.GameWindow();
            Window.Title = "Animation testing";
            Window.ClientSize = new System.Drawing.Size(512 / 2, 448 / 2);
            Window.Load += new EventHandler<EventArgs>(Initialize);
            Window.UpdateFrame += new EventHandler<FrameEventArgs>(Update);
            Window.RenderFrame += new EventHandler<FrameEventArgs>(Render);
            Window.Unload += new EventHandler<EventArgs>(Shutdown);
            Window.Run(60.0f);
            Window.Dispose();
#if DEBUG
            Console.WriteLine("\nFinished executing, press any key to exit...");
            Console.ReadKey();
#endif
        }
    }
}
