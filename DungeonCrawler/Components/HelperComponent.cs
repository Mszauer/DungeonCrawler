using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using Game;

namespace Components {
    class HelperComponent : Component{
        public int Heal = 0;
        public int Attack = 0;
        public HelperComponent(GameObject game) : base("HelperComponent", game) {

        }
    }
}
