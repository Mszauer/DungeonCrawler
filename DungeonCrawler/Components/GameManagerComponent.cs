#define RANDOMDEBUG
#define MOUSEPOSITIONDEBUG
//#define KEYDEBUG
#define EXITDEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using GameFramework;
using Game;

namespace Components {
    class GameManagerComponent : Component{
        public GameObject Key = null;
        public GameObject[][] ActiveTiles = null;
        public GameObject[][] HiddenTiles = null;
        public GameObject LockedExit = null;
        public GameObject UnlockedExit = null;

        public bool HasKey = false;
        int randomKeyX = 0;
        int randomKeyY = 0;
        int randomExitX =  0;
        int randomExitY = 0;
        public GameManagerComponent(GameObject game) : base("GameManagerComponent", game) {
            ActiveTiles = new GameObject[5][];
            for (int i = 0; i < ActiveTiles.Length; i++) {
                ActiveTiles[i] = new GameObject[5];
            }
            HiddenTiles = new GameObject[5][];
            for (int i = 0; i < HiddenTiles.Length; i++) {
                HiddenTiles[i] = new GameObject[5];
            }
        }
        public void InitializeLevel() {
            UnlockedExit.Enabled = false;
            LockedExit.Enabled = true;
            Random random = new Random();
            randomKeyX = random.Next(ActiveTiles.Length);
            randomKeyY = random.Next(ActiveTiles[0].Length);
            randomExitX = random.Next(ActiveTiles.Length);
            randomExitY = random.Next(ActiveTiles[0].Length);
            while(randomExitX == randomKeyX && randomExitY == randomKeyY) {
                randomExitX = random.Next(ActiveTiles.Length);
                randomExitY = random.Next(ActiveTiles[0].Length);
            }
#if RANDOMDEBUG
                Console.WriteLine("Key X: " + randomKeyX + " Y: " + randomKeyY);
#endif
            HasKey = false;
            //randomly place key on tile
            Key.LocalPosition = new Point((randomKeyX * 65)+15, (randomKeyY * 65)+15);//65 == tile sprite width
            for (int x = 0; x < ActiveTiles.Length; x++) {
                for (int y = 0; y < ActiveTiles[x].Length; y++) {
                    if (x == randomExitX && y == randomExitY) {
                        HiddenTiles[x][y].Enabled = false;
                        continue;
                    }
                    HiddenTiles[x][y].Enabled = true;
                }
            }
            LockedExit.LocalPosition = new Point(64 * randomExitX, 64 * randomExitY);
            UnlockedExit.LocalPosition = new Point(64 * randomExitX, 64 * randomExitY);

        }//end initializelevel

        public void TileClicked(Point MousePosition) {
#if MOUSEPOSITIONDEBUG
            Console.WriteLine("MousePosition X: " + (MousePosition.X / 65) + " Y: " + (MousePosition.Y / 65));
#endif
            if ((MousePosition.X/65) == randomKeyX && (MousePosition.Y/65) == randomKeyY) {
#if KEYDEBUG
                Console.WriteLine("Key Enabled");
#endif
                //if no monster
                Key.Enabled = true;
            }
        }//end tileCliked
    }//end component
}
