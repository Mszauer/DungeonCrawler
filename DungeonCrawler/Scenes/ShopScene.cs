﻿using System;
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

            //skill 1 level up button
            GameObject skill1UpButtonObj = new GameObject("Skill1", Root);
            Root.AddChild(skill1UpButtonObj);
            skill1UpButtonObj.LocalPosition =new Point(3, 186);
            StaticSpriteRendererComponent skill1BgButton = new StaticSpriteRendererComponent(skill1UpButtonObj);
            skill1UpButtonObj.AddComponent(skill1BgButton);
            skill1BgButton.AddSprite("Skill1BG", "Assets/ObjectSpriteSheet.png", new Rectangle(326,105,188,63));

            GameObject skill1IcoObj = new GameObject("Skill1IcoObj", skill1UpButtonObj);
            skill1UpButtonObj.AddChild(skill1IcoObj);
            StaticSpriteRendererComponent skill1Ico = new StaticSpriteRendererComponent(skill1IcoObj);
            skill1IcoObj.AddComponent(skill1Ico);
            skill1Ico.AddSprite("Skill1Ico","Assets/ObjectSpriteSheet.png",new Rectangle(45, 757, 41, 39));

            GameObject skill1UpBuyObj = new GameObject("Skill1UpObj", skill1UpButtonObj);
            skill1UpButtonObj.AddChild(skill1UpBuyObj);
            StaticSpriteRendererComponent skill1UpBuy = new StaticSpriteRendererComponent(skill1UpBuyObj);
            skill1UpBuyObj.AddComponent(skill1UpBuy);
            skill1UpBuy.AddSprite("Skill1UpBuy", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 365, 45, 45));

            //skill 2 level up button
            GameObject skill2UpButtonObj = new GameObject("Skill2", Root);
            Root.AddChild(skill2UpButtonObj);
            skill2UpButtonObj.LocalPosition = new Point(3, 249);
            StaticSpriteRendererComponent skill2BgButton = new StaticSpriteRendererComponent(skill2UpButtonObj);
            skill2UpButtonObj.AddComponent(skill2BgButton);
            skill2BgButton.AddSprite("Skill2BG", "Assets/ObjectSpriteSheet.png", new Rectangle(326, 105, 188, 63));

            GameObject skill2IcoObj = new GameObject("Skill2IcoObj", skill2UpButtonObj);
            skill2UpButtonObj.AddChild(skill2IcoObj);
            StaticSpriteRendererComponent skill2Ico = new StaticSpriteRendererComponent(skill2IcoObj);
            skill2IcoObj.AddComponent(skill2Ico);
            skill2Ico.AddSprite("Skill2Ico", "Assets/ObjectSpriteSheet.png", new Rectangle(45, 757, 41, 39));

            GameObject skill2UpBuyObj = new GameObject("Skill2UpObj", skill2UpButtonObj);
            skill2UpButtonObj.AddChild(skill2UpBuyObj);
            StaticSpriteRendererComponent skill2UpBuy = new StaticSpriteRendererComponent(skill2UpBuyObj);
            skill2UpBuyObj.AddComponent(skill2UpBuy);
            skill2UpBuy.AddSprite("Skill2UpBuy", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 365, 45, 45));

            //skill 3 level up button
            GameObject skill3UpButtonObj = new GameObject("Skill3", Root);
            Root.AddChild(skill3UpButtonObj);
            skill3UpButtonObj.LocalPosition = new Point(3, 312);
            StaticSpriteRendererComponent skill3BgButton = new StaticSpriteRendererComponent(skill3UpButtonObj);
            skill3UpButtonObj.AddComponent(skill3BgButton);
            skill3BgButton.AddSprite("Skill3BG", "Assets/ObjectSpriteSheet.png", new Rectangle(326, 105, 188, 63));

            GameObject skill3IcoObj = new GameObject("Skill3IcoObj", skill3UpButtonObj);
            skill3UpButtonObj.AddChild(skill3IcoObj);
            StaticSpriteRendererComponent skill3Ico = new StaticSpriteRendererComponent(skill3IcoObj);
            skill3IcoObj.AddComponent(skill3Ico);
            skill3Ico.AddSprite("Skill3Ico", "Assets/ObjectSpriteSheet.png", new Rectangle(45, 757, 41, 39));

            GameObject skill3UpBuyObj = new GameObject("Skill3UpObj", skill3UpButtonObj);
            skill3UpButtonObj.AddChild(skill3UpBuyObj);
            StaticSpriteRendererComponent skill3UpBuy = new StaticSpriteRendererComponent(skill3UpBuyObj);
            skill3UpBuyObj.AddComponent(skill3UpBuy);
            skill3UpBuy.AddSprite("Skill3UpBuy", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 365, 45, 45));
        }
    }
}
