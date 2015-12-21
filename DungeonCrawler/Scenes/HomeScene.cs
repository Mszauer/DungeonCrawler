using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using Components;
using System.Drawing;

namespace Game {
    class HomeScene : Scene{
        protected bool audioEnabled = true;
        public override void Initialize() {
            GameObject background = new GameObject("Background");
            Root.AddChild(background);
            StaticSpriteRendererComponent backgroundPicture = new StaticSpriteRendererComponent(background);
            backgroundPicture.AddSprite("Background","Assets/ObjectSpriteSheet.png",new Rectangle(0,0,320,480));

            //currency counter
            GameObject currency = new GameObject("Currency");
            Root.AddChild(currency);
            currency.LocalPosition = new Point(7,5);
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
            currencyAmt.DrawString("0");//insert currency variable here

            //turn audio on/off when clicked
            GameObject audioButton = new GameObject("AudioButton");
            audioButton.LocalPosition = new Point(10, 425);
            Root.AddChild(audioButton);
            StaticSpriteRendererComponent aButton = new StaticSpriteRendererComponent(audioButton);
            aButton.AddSprite("AudioButtonDisabled", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 0, 45, 45));
            aButton.AddSprite("AudioButtonHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 46, 45, 45));
            aButton.AddSprite("AudioButtonHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 91, 45, 45));
            aButton.AddSprite("AudioButtonEnabled", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 134, 45, 45));
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
            welcomeBG.AddSprite("WelcomeBox","Assets/ObjectSpriteSheet.png",new Rectangle(467,0,228,99));

            //switch to scene 4:HeroSelectionScene if clicked
            GameObject startButton = new GameObject("StartButton");
            welcomeBox.AddChild(startButton);
            startButton.LocalPosition = new Point(156, 18);
            StaticSpriteRendererComponent sButton = new StaticSpriteRendererComponent(startButton);
            sButton.AddSprite("PlayButtonDefault","Assets/ObjectSpriteSheet.png",new Rectangle(926,126,57,57));
            sButton.AddSprite("PlayButtonDefaultHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(925, 126, 57, 57));
            sButton.AddSprite("PlayButtonDefaultHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(925, 240, 57, 57));
            sButton.AddSprite("PlayButtonDefaultClick", "Assets/ObjectSpriteSheet.png", new Rectangle(926, 297, 57, 57));
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
            startObj.LocalPosition = new Point(105,25);
            FontRendererComponent startFont = new FontRendererComponent(startObj, "Assets/Font/42Fontsheet.png", "Assets/Font/42Fontsheet.fnt");
            startFont.CurrentAllignment = FontRendererComponent.Allignment.Center;
            startFont.DrawString("Start");

            //Displays Creator
            GameObject creator = new GameObject("Creator");
            Root.AddChild(creator);
            creator.LocalPosition = new Point(170,425);
            StaticSpriteRendererComponent creatorBox = new StaticSpriteRendererComponent(creator);
            creatorBox.AddSprite("CreatorBox", "Assets/ObjectSpriteSheet.png", new Rectangle(322, 1, 144, 47));

            GameObject createrObj = new GameObject("CreatorObj");
            creator.AddChild(createrObj);
            createrObj.LocalPosition = new Point(72, 13);
            FontRendererComponent creatorFont = new FontRendererComponent(createrObj, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            creatorFont.CurrentAllignment = FontRendererComponent.Allignment.Center;
            creatorFont.DrawString("By : MSzauer");

            if (audioEnabled) {
                //play music here
            }
        }

    }
}
