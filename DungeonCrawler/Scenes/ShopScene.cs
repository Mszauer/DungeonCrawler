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
            GameObject background = new GameObject("Background");
            Root.AddChild(background);
            StaticSpriteRendererComponent backgroundPicture = new StaticSpriteRendererComponent(background);
            backgroundPicture.AddSprite("Background", "Assets/ObjectSpriteSheet.png", new Rectangle(0, 0, 320, 480));

            //currency display
            GameObject currency = new GameObject("Currency");
            Root.AddChild(currency);
            currency.LocalPosition = new Point(7, 5);
            StaticSpriteRendererComponent currencyBG = new StaticSpriteRendererComponent(currency);
            currencyBG.AddSprite("Currency", "Assets/ObjectSpriteSheet.png", new Rectangle(327, 50, 113, 42));

            //health buy button
            GameObject healthBuyButton = new GameObject("Health");
            Root.AddChild(healthBuyButton);
            healthBuyButton.LocalPosition = new Point(3, 60);
            StaticSpriteRendererComponent heartBG = new StaticSpriteRendererComponent(healthBuyButton);
            heartBG.AddSprite("HeartBG", "Assets/ObjectSpriteSheet.png", new Rectangle(326, 105, 188, 63));

            GameObject heartIcoObj = new GameObject("HeartIco");
            healthBuyButton.AddChild(heartIcoObj);
            heartIcoObj.LocalPosition = new Point(15,15);
            StaticSpriteRendererComponent heartIco = new StaticSpriteRendererComponent(heartIcoObj);
            heartIco.AddSprite("HeartIco","Assets/ObjectSpriteSheet.png",new Rectangle(142, 761, 36, 31));

            GameObject heartBuyObj = new GameObject("HeartBuyObj");
            healthBuyButton.AddChild(heartBuyObj);
            heartBuyObj.LocalPosition = new Point(133,10);
            StaticSpriteRendererComponent heartBuy = new StaticSpriteRendererComponent(heartBuyObj);
            heartBuy.AddSprite("HeartBuy", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 365, 45, 45));

            //attack buy button
            GameObject attackBuyButton = new GameObject("Attack");
            Root.AddChild(attackBuyButton);
            attackBuyButton.LocalPosition = new Point(3, 123);
            StaticSpriteRendererComponent attackBG = new StaticSpriteRendererComponent(attackBuyButton);
            attackBG.AddSprite("AttackBG", "Assets/ObjectSpriteSheet.png", new Rectangle(326, 105, 188, 63));

            GameObject attackIcoObj = new GameObject("AttackIco");
            attackBuyButton.AddChild(attackIcoObj);
            attackIcoObj.LocalPosition = new Point(13, 12);
            StaticSpriteRendererComponent attackIco = new StaticSpriteRendererComponent(attackIcoObj);
            attackIco.AddSprite("AttackIco", "Assets/ObjectSpriteSheet.png", new Rectangle(93, 759, 38, 38));
            
            GameObject attackBuyObj = new GameObject("AttackBuyObj");
            attackBuyButton.AddChild(attackBuyObj);
            attackBuyObj.LocalPosition = new Point(133, 10);
            StaticSpriteRendererComponent attackBuy = new StaticSpriteRendererComponent(attackBuyObj);
            attackBuy.AddSprite("AttackBuy", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 365, 45, 45));
            
            //skill 1 level up button
            GameObject skill1UpButtonObj = new GameObject("Skill1");
            Root.AddChild(skill1UpButtonObj);
            skill1UpButtonObj.LocalPosition =new Point(3, 186);
            StaticSpriteRendererComponent skill1BgButton = new StaticSpriteRendererComponent(skill1UpButtonObj);
            skill1BgButton.AddSprite("Skill1BG", "Assets/ObjectSpriteSheet.png", new Rectangle(326,105,188,63));

            GameObject skill1IcoObj = new GameObject("Skill1IcoObj");
            skill1UpButtonObj.AddChild(skill1IcoObj);
            skill1IcoObj.LocalPosition = new Point(11,10);
            StaticSpriteRendererComponent skill1Ico = new StaticSpriteRendererComponent(skill1IcoObj);
            skill1Ico.AddSprite("Skill1Ico","Assets/ObjectSpriteSheet.png",new Rectangle(45, 757, 41, 41));

            GameObject skill1UpBuyObj = new GameObject("Skill1UpObj");
            skill1UpButtonObj.AddChild(skill1UpBuyObj);
            skill1UpBuyObj.LocalPosition = new Point(136,8);
            StaticSpriteRendererComponent skill1UpBuy = new StaticSpriteRendererComponent(skill1UpBuyObj);
            skill1UpBuy.AddSprite("Skill1UpBuy", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 365, 45, 45));

            //skill 2 level up button
            GameObject skill2UpButtonObj = new GameObject("Skill2");
            Root.AddChild(skill2UpButtonObj);
            skill2UpButtonObj.LocalPosition = new Point(3, 249);
            StaticSpriteRendererComponent skill2BgButton = new StaticSpriteRendererComponent(skill2UpButtonObj);
            skill2BgButton.AddSprite("Skill2BG", "Assets/ObjectSpriteSheet.png", new Rectangle(326, 105, 188, 63));

            GameObject skill2IcoObj = new GameObject("Skill2IcoObj");
            skill2UpButtonObj.AddChild(skill2IcoObj);
            StaticSpriteRendererComponent skill2Ico = new StaticSpriteRendererComponent(skill2IcoObj);
            skill2IcoObj.LocalPosition = new Point(11, 10);
            skill2Ico.AddSprite("Skill2Ico", "Assets/ObjectSpriteSheet.png", new Rectangle(45, 757, 41, 41));

            GameObject skill2UpBuyObj = new GameObject("Skill2UpObj");
            skill2UpButtonObj.AddChild(skill2UpBuyObj);
            skill2UpBuyObj.LocalPosition = new Point(136, 8);
            StaticSpriteRendererComponent skill2UpBuy = new StaticSpriteRendererComponent(skill2UpBuyObj);
            skill2UpBuy.AddSprite("Skill2UpBuy", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 365, 45, 45));

            //skill 3 level up button
            GameObject skill3UpButtonObj = new GameObject("Skill3");
            Root.AddChild(skill3UpButtonObj);
            skill3UpButtonObj.LocalPosition = new Point(3, 312);
            StaticSpriteRendererComponent skill3BgButton = new StaticSpriteRendererComponent(skill3UpButtonObj);
            skill3BgButton.AddSprite("Skill3BG", "Assets/ObjectSpriteSheet.png", new Rectangle(326, 105, 188, 63));

            GameObject skill3IcoObj = new GameObject("Skill3IcoObj");
            skill3UpButtonObj.AddChild(skill3IcoObj);
            StaticSpriteRendererComponent skill3Ico = new StaticSpriteRendererComponent(skill3IcoObj);
            skill3IcoObj.LocalPosition = new Point(11, 10);
            skill3Ico.AddSprite("Skill3Ico", "Assets/ObjectSpriteSheet.png", new Rectangle(45, 757, 41, 41));

            GameObject skill3UpBuyObj = new GameObject("Skill3UpObj");
            skill3UpButtonObj.AddChild(skill3UpBuyObj);
            StaticSpriteRendererComponent skill3UpBuy = new StaticSpriteRendererComponent(skill3UpBuyObj);
            skill3UpBuyObj.LocalPosition = new Point(136, 8);
            skill3UpBuy.AddSprite("Skill3UpBuy", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 365, 45, 45));

            //Back button
            GameObject backButton = new GameObject("BackButton");
            Root.AddChild(backButton);
            backButton.LocalPosition = new Point(10,423);
            StaticSpriteRendererComponent back = new StaticSpriteRendererComponent(backButton);
            back.AddSprite("BackDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 181, 46, 46));
            back.AddSprite("BackHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 227, 46, 46));
            back.AddSprite("BackHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 273, 46, 46));
            back.AddSprite("BackClick", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 319, 46, 46));

            //health identifier
            GameObject healthObj = new GameObject("HealthObj");
            Root.AddChild(healthObj);
            healthObj.LocalPosition = new Point(112,412);
            StaticSpriteRendererComponent healthBg = new StaticSpriteRendererComponent(healthObj);
            healthBg.AddSprite("healthBg","Assets/ObjectSpriteSheet.png",new Rectangle(42, 675, 55, 70));

            GameObject heartHealthObj = new GameObject("HeartHealthObj");
            healthObj.AddChild(heartHealthObj);
            heartHealthObj.LocalPosition = new Point(10, 9);
            StaticSpriteRendererComponent heartHealthIco = new StaticSpriteRendererComponent(heartHealthObj);
            heartHealthIco.AddSprite("HeartHealthIco", "Assets/ObjectSpriteSheet.png", new Rectangle(142, 761, 36, 31));

            //attack identifier
            GameObject attackObj = new GameObject("AttackObj");
            Root.AddChild(attackObj);
            attackObj.LocalPosition = new Point(230, 412);
            StaticSpriteRendererComponent attack = new StaticSpriteRendererComponent(attackObj);
            attack.AddSprite("AttackBg", "Assets/ObjectSpriteSheet.png", new Rectangle(42, 675, 55, 70));

            GameObject swordIcoObj = new GameObject("SwordIcoObj");
            attackObj.AddChild(swordIcoObj);
            swordIcoObj.LocalPosition = new Point(11,7);
            StaticSpriteRendererComponent swordIco = new StaticSpriteRendererComponent(swordIcoObj);
            swordIco.AddSprite("SwordIco", "Assets/ObjectSpriteSheet.png", new Rectangle(93, 759, 38, 38));

        }
    }
}
