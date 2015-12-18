using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components;
using GameFramework;
using System.Drawing;

namespace Game {
    class ShopScene : Scene{
        public override void Initialize() {
            //background picture
            GameObject background = new GameObject("Background", Root);
            Root.AddChild(background);
            StaticSpriteRendererComponent backgroundPicture = new StaticSpriteRendererComponent(background);
            background.AddComponent(backgroundPicture);
            backgroundPicture.AddSprite("Background", "Assets/ObjectSpriteSheet.png", new Rectangle(0, 0, 320, 480));

            //currency display
            GameObject currency = new GameObject("Currency", Root);
            Root.AddChild(currency);
            currency.LocalPosition = new Point(7, 5);
            StaticSpriteRendererComponent currencyBG = new StaticSpriteRendererComponent(currency);
            currency.AddComponent(currencyBG);
            currencyBG.AddSprite("Currency", "Assets/ObjectSpriteSheet.png", new Rectangle(327, 50, 113, 42));

            //health buy button
            GameObject healthBuyButton = new GameObject("Health", Root);
            Root.AddChild(healthBuyButton);
            healthBuyButton.LocalPosition = new Point(3, 60);
            StaticSpriteRendererComponent heartBG = new StaticSpriteRendererComponent(healthBuyButton);
            healthBuyButton.AddComponent(heartBG);
            heartBG.AddSprite("HeartBG", "Assets/ObjectSpriteSheet.png", new Rectangle(326, 105, 188, 63));

            GameObject heartIcoObj = new GameObject("HeartIco", healthBuyButton);
            healthBuyButton.AddChild(heartIcoObj);
            heartIcoObj.LocalPosition = new Point(15,15);
            StaticSpriteRendererComponent heartIco = new StaticSpriteRendererComponent(healthBuyButton);
            heartIcoObj.AddComponent(heartIco);
            heartIco.AddSprite("HeartIco","Assets/ObjectSpriteSheet.png",new Rectangle(142, 761, 36, 31));

            GameObject heartBuyObj = new GameObject("HeartBuyObj", healthBuyButton);
            healthBuyButton.AddChild(heartBuyObj);
            heartBuyObj.LocalPosition = new Point(133,10);
            StaticSpriteRendererComponent heartBuy = new StaticSpriteRendererComponent(healthBuyButton);
            heartBuyObj.AddComponent(heartBuy);
            heartBuy.AddSprite("HeartBuy", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 365, 45, 45));
            
        }
    }
}
