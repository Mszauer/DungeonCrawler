#define HERODEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameFramework;

namespace Components {
    class HeroComponent : Component{
        public Dictionary<int, string> SkillIndexer = null;
        public Dictionary<string, int> Skills = null;
        public Dictionary<string, string> ToolTips = null;
        public int Health = 10;
        public int Attack = 1;
        protected int maxLevel = 4;
        public HeroComponent(GameObject game) : base("HeroComponent",game) {
            SkillIndexer = new Dictionary<int, string>();
            Skills = new Dictionary<string, int>();
            ToolTips = new Dictionary<string, string>();
        }
        public void AddSkill(string name, int levels,string tooltip) {
            Skills.Add(name, 1);
            ToolTips.Add(name, tooltip);
            SkillIndexer.Add(Skills.Count, name);
        }
        public bool MaxLevel(string skill) {
            if (!Skills.ContainsKey(skill)) {
#if HERODEBUG
                Console.WriteLine(Name + " does not contain " + skill + " skill");
#endif
                return false;
            }
            foreach (KeyValuePair<string,int> kvp in Skills) {
                if (kvp.Key == skill) {
                    if (kvp.Value == maxLevel) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
