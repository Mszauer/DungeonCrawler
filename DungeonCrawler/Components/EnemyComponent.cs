using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;
using GameFramework;
using System.Drawing;

namespace Components {
    class EnemyComponent : Component{
        public int Health = 3;
        public int Attack = 1;

        public EnemyComponent (GameObject game) : base("EnemyComponent", game) {

        }
    }
}
