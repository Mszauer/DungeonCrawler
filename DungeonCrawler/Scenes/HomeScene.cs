﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using Components;
using System.Drawing;

namespace Game {
    class HomeScene : Scene{
        public override void Initialize() {

            GameObject background = new GameObject("Background", Root);
            Root.AddChild(background);
            StaticSpriteRendererComponent backgroundPicture = new StaticSpriteRendererComponent(background);
            background.AddComponent(backgroundPicture);
            backgroundPicture.AddSprite("Background","Assets/ObjectSpriteSheet.png",new Rectangle(0,0,320,480));

            //turn audio on/off when clicked
            GameObject audioButton = new GameObject("AudioButton", Root);
            audioButton.LocalPosition = new Point(10, 425);
            Root.AddChild(audioButton);
            StaticSpriteRendererComponent aButton = new StaticSpriteRendererComponent(audioButton);
            audioButton.AddComponent(aButton);
            aButton.AddSprite("AudioButtonDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 0, 46, 46));
            aButton.AddSprite("AudioButtonHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 46, 46, 46));
            aButton.AddSprite("AudioButtonHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 92, 46, 46));
            aButton.AddSprite("AudioButtonClick", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 134, 46, 46));

            /*
            //exit application when clicker
            GameObject quitButton = new GameObject("QuitButton", Root);
            Root.AddChild(quitButton);
            StaticSpriteRendererComponent xButton = new StaticSpriteRendererComponent(quitButton);
            quitButton.AddComponent(xButton);
            //xButton.AddSprite();
            */
            //Welcome message
            GameObject welcomeBox = new GameObject("WelcomeBox", Root);
            Root.AddChild(welcomeBox);
            welcomeBox.LocalPosition = new Point(60, 115);
            StaticSpriteRendererComponent welcomeBG = new StaticSpriteRendererComponent(welcomeBox);
            welcomeBox.AddComponent(welcomeBG);
            welcomeBG.AddSprite("WelcomeBox","Assets/ObjectSpriteSheet.png",new Rectangle(467,0,228,99));

            /*
            FontRendererComponent welcomeText = new FontRendererComponent(welcomeBox, "Assets/Font/bane.png", "Assets/Font/bane.txt");
            welcomeBox.AddComponent(welcomeText);
            welcomeText.DrawString("Welcome Back,\n Explorer");
            */

            //switch to scene 4:HeroSelectionScene if clicked
            GameObject startButton = new GameObject("StartButton", welcomeBox);
            Root.AddChild(startButton);
            startButton.LocalPosition = new Point(156, 18);
            StaticSpriteRendererComponent sButton = new StaticSpriteRendererComponent(startButton);
            startButton.AddComponent(sButton);
            sButton.AddSprite("PlayButtonDefault","Assets/ObjectSpriteSheet.png",new Rectangle(926,126,57,57));
            sButton.AddSprite("PlayButtonDefaultHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(926, 126, 57, 57));
            sButton.AddSprite("PlayButtonDefaultHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(926, 240, 57, 57));
            sButton.AddSprite("PlayButtonDefaultClick", "Assets/ObjectSpriteSheet.png", new Rectangle(926, 297, 57, 57));

            /*
            //switch to Scene2:CreditsScene if clicked
            GameObject creditsButton = new GameObject("CreditsButton", Root);
            Root.AddChild(creditsButton);
            StaticSpriteRendererComponent cButton = new StaticSpriteRendererComponent(creditsButton);
            creditsButton.AddComponent(cButton);
            //cButton.AddSprite();

            //switch to scene3:LogScene if clicked
            GameObject logButton = new GameObject("LogButton", Root);
            Root.AddChild(logButton);
            StaticSpriteRendererComponent lButton = new StaticSpriteRendererComponent(logButton);
            logButton.AddComponent(lButton);
            //lButton.AddSprite();

            //Displays version number
            GameObject versionNumber = new GameObject("VersionNumber", Root);
            Root.AddChild(versionNumber);
            StaticSpriteRendererComponent versionBG = new StaticSpriteRendererComponent(versionNumber); //semi-transparent background
            versionNumber.AddComponent(versionBG);
            FontRendererComponent versionText = new FontRendererComponent(versionNumber, "Assets/Font/bane.png", "Assets/Font/bane.txt");
            versionText.DrawString("Version : 1.0");
            */
        }
    }
}
