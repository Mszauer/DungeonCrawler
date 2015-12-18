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

            //attack buy button
            GameObject attackBuyButton = new GameObject("Attack", Root);
            Root.AddChild(attackBuyButton);
            attackBuyButton.LocalPosition = new Point(3, 123);
            StaticSpriteRendererComponent attackBG = new StaticSpriteRendererComponent(attackBuyButton);
            attackBuyButton.AddComponent(attackBG);
            attackBG.AddSprite("AttackBG", "Assets/ObjectSpriteSheet.png", new Rectangle(326, 105, 188, 63));

            GameObject attackIcoObj = new GameObject("AttackIco", attackBuyButton);
            attackBuyButton.AddChild(attackIcoObj);
            //16,135 for location
            attackIcoObj.LocalPosition = new Point(13, 12);
            StaticSpriteRendererComponent attackIco = new StaticSpriteRendererComponent(attackBuyButton);
            attackIcoObj.AddComponent(attackIco);
            attackIco.AddSprite("AttackIco", "Assets/ObjectSpriteSheet.png", new Rectangle(93, 759, 38, 38));

            GameObject attackBuyObj = new GameObject("AttackBuyObj", attackBuyButton);
            attackBuyButton.AddChild(attackBuyObj);
            attackBuyObj.LocalPosition = new Point(133, 10);
            StaticSpriteRendererComponent attackBuy = new StaticSpriteRendererComponent(attackBuyButton);
            attackBuyObj.AddComponent(attackBuy);
            attackBuy.AddSprite("AttackBuy", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 365, 45, 45));

        }
    }
}
