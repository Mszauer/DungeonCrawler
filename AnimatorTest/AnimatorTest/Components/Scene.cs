using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework {
    class Scene {
        //root game object,update,render
        public GameObject Root = null;
        public Scene() {
            Root = new GameObject("SceneRoot");
        }
        
        public virtual void Initialize() {

        }

        public virtual void Enter() {

        }

        public virtual void Update(float dTime) {
            if (Root != null) {
                Root.Update(dTime);
            }
        }

        public virtual void Render() {
            if (Root != null) {
                 Root.Render();
            }
        }

        public virtual void Exit() {

        }

        public virtual void Shutdown() {

        }
        
    }
}
