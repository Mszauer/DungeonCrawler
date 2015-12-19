using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components;
using GameFramework;
using System.Drawing;

namespace Game {
    class HeroSelectionScene : Scene{
        public override void Initialize() {
            //background
            GameObject background = new GameObject("Background", Root);
            Root.AddChild(background);
            StaticSpriteRendererComponent backgroundPicture = new StaticSpriteRendererComponent(background);
            background.AddComponent(backgroundPicture);
            backgroundPicture.AddSprite("Background", "Assets/ObjectSpriteSheet.png", new Rectangle(0, 0, 320, 480));

            //currency counter
            GameObject currency = new GameObject("Currency", Root);
            Root.AddChild(currency);
            currency.LocalPosition = new Point(7, 5);
            StaticSpriteRendererComponent currencyBG = new StaticSpriteRendererComponent(currency);
            currency.AddComponent(currencyBG);
            currencyBG.AddSprite("Currency", "Assets/ObjectSpriteSheet.png", new Rectangle(327, 50, 113, 42));

            //Back button
            GameObject backButton = new GameObject("BackButton", Root);
            Root.AddChild(backButton);
            backButton.LocalPosition = new Point(10, 423);
            StaticSpriteRendererComponent back = new StaticSpriteRendererComponent(backButton);
            backButton.AddComponent(back);
            back.AddSprite("BackDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 181, 46, 46));
            back.AddSprite("BackHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 227, 46, 46));
            back.AddSprite("BackHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 273, 46, 46));
            back.AddSprite("BackClick", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 319, 46, 46));

            //name plate
            GameObject namePlateObj = new GameObject("NamePlateObj", Root);
            Root.AddChild(namePlateObj);
            namePlateObj.LocalPosition = new Point(18,60);
            StaticSpriteRendererComponent namePlateSprite = new StaticSpriteRendererComponent(namePlateObj);
            namePlateObj.AddComponent(namePlateSprite);
            namePlateSprite.AddSprite("NamePlateSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(320, 180, 286, 54));

            //name plate prev button
            GameObject namePlatePrevObj = new GameObject("NamePlatePrevObj", namePlateObj);
            namePlateObj.AddChild(namePlatePrevObj);
            namePlatePrevObj.LocalPosition = new Point(2, 5);
            StaticSpriteRendererComponent namePlatePrevSprite = new StaticSpriteRendererComponent(namePlatePrevObj);
            namePlatePrevObj.AddComponent(namePlatePrevSprite);
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 723, 46, 46));
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 769, 46, 46));
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 811, 46, 46));
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteClick", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 858, 46, 46));

            //name plate next button
            GameObject namePlateNextObj = new GameObject("NamePlateNextObj", namePlateObj);
            namePlateObj.AddChild(namePlateNextObj);
            namePlateNextObj.LocalPosition = new Point(237, 5);
            StaticSpriteRendererComponent namePlateNextSprite = new StaticSpriteRendererComponent(namePlateNextObj);
            namePlateNextObj.AddComponent(namePlateNextSprite);
            namePlateNextSprite.AddSprite("NamePlatenextSpriteDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 543, 46, 46));
        }
    }
}
