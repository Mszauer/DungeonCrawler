#define SCENEDEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework {
    class SceneManager {
        List<Scene> SceneStack = null;
        private static SceneManager instance = null;
        public static SceneManager Instance {
            get {
                if (instance == null) {
                    instance = new SceneManager();
                }
                return instance;
            }
        }
        private SceneManager() {

        }
        public void Update(float dTime) {
            if (SceneStack != null && SceneStack.Count != 0) {
                SceneStack[SceneStack.Count - 1].Update(dTime);
            }
        }
        public void Render() {
            if (SceneStack != null) {
                for (int i = 0; i < SceneStack.Count; i++) {
                    SceneStack[i].Render();
                }
            }
        }
        public void PopScene(Scene scene) {
            if (SceneStack != null && SceneStack.Count >= 0) {
                SceneStack.RemoveAt(SceneStack.Count - 1);
#if SCENEDEBUG
                Console.WriteLine("Removed Scene: " + scene);
#endif
            }
        }
        public void PushScene(Scene scene) {
            if (SceneStack == null) {
                SceneStack = new List<Scene>();
            }
            SceneStack.Add(scene);
#if SCENEDEBUG
            Console.WriteLine("Added Scene: "+scene);
#endif
        }
        public Scene PeekScene() {
            if (SceneStack != null && SceneStack.Count >= 0) {
                return SceneStack[SceneStack.Count - 1];
            }
#if SCENEDEBUG
            Console.WriteLine("SceneStack is null or empty");
#endif
            return null;
        }
    }
}
