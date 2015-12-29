using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;
using Components;
using GameFramework;
using System.Drawing;
using System.IO;

namespace Game{
    class DeathScene : Scene{

        public override void Initialize() {
            int Monies = 0;
            bool audioEnabled = true;
            bool BackgroundMusic = true;
            int currentHero = 0;

            //load last hero selected
            if (File.Exists("Assets/Data/CurrentHero.txt")) {
                using (TextReader reader = File.OpenText("Assets/Data/CurrentHero.txt")) {
                    currentHero = System.Convert.ToInt32(reader.ReadLine());
                    Monies = System.Convert.ToInt32(reader.ReadLine());
                    //BackgroundMusic = SoundManager.Instance.LoadMp3(reader.ReadLine());
                }
            }//end if
            GameObject background = new GameObject("Background");
            Root.AddChild(background);
            StaticSpriteRendererComponent backgroundPicture = new StaticSpriteRendererComponent(background);
            backgroundPicture.AddSprite("Background", "Assets/ObjectSpriteSheet.png", new Rectangle(0, 0, 320, 480));

            //currency counter
            GameObject currency = new GameObject("Currency");
            Root.AddChild(currency);
            currency.LocalPosition = new Point(7, 5);
            StaticSpriteRendererComponent currencyBG = new StaticSpriteRendererComponent(currency);
            currencyBG.AddSprite("Currency", "Assets/ObjectSpriteSheet.png", new Rectangle(327, 50, 113, 42));
            ButtonComponent currencyShop = new ButtonComponent(currency);
            currencyShop.DoClick += delegate {
                SceneManager.Instance.PushScene(new ShopScene());
            };

            GameObject currencyAmtObj = new GameObject("CurrencyAmtObj");
            currency.AddChild(currencyAmtObj);
            currencyAmtObj.LocalPosition = new Point(105, 12);//90,9
            FontRendererComponent currencyAmt = new FontRendererComponent(currencyAmtObj, "Assets/Font/14Fontsheet.png", "Assets/Font/14Fontsheet.fnt");
            currencyAmt.CurrentAllignment = FontRendererComponent.Allignment.Right;
            currencyAmt.DrawString(Monies.ToString());//insert currency variable here

            //turn audio on/off when clicked
            GameObject audioButton = new GameObject("AudioButton");
            audioButton.LocalPosition = new Point(10, 425);
            Root.AddChild(audioButton);
            StaticSpriteRendererComponent aButton = new StaticSpriteRendererComponent(audioButton);
            aButton.AddSprite("AudioButtonDisabled", "Assets/ObjectSpriteSheet.png", new Rectangle(977, 0, 45, 45));
            aButton.AddSprite("AudioButtonHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(977, 46, 45, 45));
            aButton.AddSprite("AudioButtonHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(977, 91, 45, 45));
            aButton.AddSprite("AudioButtonEnabled", "Assets/ObjectSpriteSheet.png", new Rectangle(977, 135, 45, 45));
            ButtonComponent audio = new ButtonComponent(audioButton);
            audio.DoClick += delegate {
                audioEnabled = (audioEnabled) ? false : true;
            };
            audio.DoHover += delegate {
                if (aButton.CurrentSprite != "AudioButtonHover2") {
                    aButton.SetSprite("AudioButtonHover2");
                }
            };
            audio.NoHover += delegate {
                if (audioEnabled) {
                    if (aButton.CurrentSprite != "AudioButtonEnabled") {
                        aButton.SetSprite("AudioButtonEnabled");
                    }
                }
                else {
                    if (aButton.CurrentSprite != "AudioButtonDisabled") {
                        aButton.SetSprite("AudioButtonDisabled");
                    }
                }
            };

            //Welcome message
            GameObject welcomeBox = new GameObject("WelcomeBox");
            Root.AddChild(welcomeBox);
            welcomeBox.LocalPosition = new Point(60, 115);
            StaticSpriteRendererComponent welcomeBG = new StaticSpriteRendererComponent(welcomeBox);
            welcomeBG.AddSprite("WelcomeBox", "Assets/ObjectSpriteSheet.png", new Rectangle(467, 0, 228, 99));

            //switch to scene 4:HeroSelectionScene if clicked
            GameObject startButton = new GameObject("StartButton");
            welcomeBox.AddChild(startButton);
            startButton.LocalPosition = new Point(156, 18);
            StaticSpriteRendererComponent sButton = new StaticSpriteRendererComponent(startButton);
            sButton.AddSprite("PlayButtonDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(918, 126, 57, 57));
            sButton.AddSprite("PlayButtonDefaultHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(918, 126, 57, 55));
            sButton.AddSprite("PlayButtonDefaultHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(918, 240, 57, 55));
            sButton.AddSprite("PlayButtonDefaultClick", "Assets/ObjectSpriteSheet.png", new Rectangle(918, 297, 57, 55));
            ButtonComponent play = new ButtonComponent(startButton);
            play.DoHover += delegate () {
                if (sButton.CurrentSprite != "PlayButtonDefaultHover2") {
                    sButton.SetSprite("PlayButtonDefaultHover2");
                }
            };
            play.DoClick += delegate () {
                SceneManager.Instance.PushScene(new HeroSelectionScene());
            };
            play.NoHover += delegate () {
                if (sButton.CurrentSprite != "PlayButtonDefault") {
                    sButton.SetSprite("PlayButtonDefault");
                }
            };
            GameObject startObj = new GameObject("StartObj");
            welcomeBox.AddChild(startObj);
            startObj.LocalPosition = new Point(95, 25);
            FontRendererComponent startFont = new FontRendererComponent(startObj, "Assets/Font/42Fontsheet.png", "Assets/Font/42Fontsheet.fnt");
            startFont.CurrentAllignment = FontRendererComponent.Allignment.Center;
            startFont.DrawString("Play Again");

            //tree stump
            GameObject treeStumpObj = new GameObject("TreeStumpObj");
            Root.AddChild(treeStumpObj);
            treeStumpObj.LocalPosition = new Point(115, 335);
            StaticSpriteRendererComponent treeStumpSprite = new StaticSpriteRendererComponent(treeStumpObj);
            treeStumpSprite.AddSprite("TreeStumpSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(244, 904, 112, 85));

            GameObject hero = new GameObject("Hero");
            hero.LocalPosition = new Point(115, 240);
            Root.AddChild(hero);
            StaticSpriteRendererComponent heroDead = new StaticSpriteRendererComponent(hero);
            if (currentHero == 0) {
                //load archer dead
                heroDead.AddSprite("Dead", "Assets/Characters/Archer/Archer_Death.png", new Rectangle(0, 0, 128, 128));
            }
            else if (currentHero == 1) {
                //load knight dead
                heroDead.AddSprite("Dead", "Assets/Characters/Knight/Knight_Death.png", new Rectangle(0, 0, 128, 128));
            }
            else if (currentHero == 2) {
                //load barbarian dead
                heroDead.AddSprite("Dead", "Assets/Characters/Barbarian/Barbarian_Death.png", new Rectangle(0, 0, 128, 128));
            }
            
        }

    }
}
