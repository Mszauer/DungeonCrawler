using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components;
using GameFramework;
using System.Drawing;
using System.IO;

namespace Game {
    class ShopScene : Scene{
        protected int Monies = 0;
        protected int CurrentHero = 0;
        protected int heroHealth = 0;
        protected int heroAttack = 0;
        protected int heroSkill1 = 1;
        protected int heroSkill2 = 1;
        protected int heroSkill3 = 1;
        protected int statMultiplier = 5;
        protected int skillMultiplier = 4;
        protected string skill1Name;
        protected string skill2Name;
        protected string skill3Name;

        public override void Initialize() {

            //load data
            if (File.Exists("Assets/Data/CurrentHero.txt")) {
                using (StreamReader reader = new StreamReader("Assets/Data/CurrentHero.txt")) {
                    CurrentHero = System.Convert.ToInt32(reader.ReadLine());
                    Monies = System.Convert.ToInt32(reader.ReadLine());
                }
            }
            if (File.Exists("Assets/Data/hero_" + CurrentHero + ".txt")) {
                using (StreamReader reader = new StreamReader("Assets/Data/hero_" + CurrentHero + ".txt")) {
                    heroHealth = System.Convert.ToInt32(reader.ReadLine());
                    heroAttack = System.Convert.ToInt32(reader.ReadLine());
                    skill1Name = reader.ReadLine();
                    skill2Name = reader.ReadLine();
                    skill3Name = reader.ReadLine();
                    heroSkill1 = System.Convert.ToInt32(reader.ReadLine());
                    heroSkill2 = System.Convert.ToInt32(reader.ReadLine());
                    heroSkill3 = System.Convert.ToInt32(reader.ReadLine());
                }
            }
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

            GameObject currencyAmtObj = new GameObject("CurrencyAmtObj");
            currency.AddChild(currencyAmtObj);
            currencyAmtObj.LocalPosition = new Point(105, 12);//90,9
            FontRendererComponent currencyAmt = new FontRendererComponent(currencyAmtObj, "Assets/Font/14Fontsheet.png", "Assets/Font/14Fontsheet.fnt");
            currencyAmt.CurrentAllignment = FontRendererComponent.Allignment.Right;
            currencyAmt.DrawString(Monies.ToString());//insert currency variable here

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
            heartBuy.AddSprite("HeartBuyDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 367, 45, 45));
            heartBuy.AddSprite("HeartBuyHover", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 455, 45, 45));
            heartBuy.AddSprite("HeartBuyClick", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 500, 45, 45));
            ButtonComponent heartPurchase = new ButtonComponent(heartBuyObj);

            GameObject healthBuyAmtObj = new GameObject("HealthBuyAmtObj");
            healthBuyButton.AddChild(healthBuyAmtObj);
            healthBuyAmtObj.LocalPosition = new Point(120, 17);
            FontRendererComponent healthBuyAmt = new FontRendererComponent(healthBuyAmtObj, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            healthBuyAmt.CurrentAllignment = FontRendererComponent.Allignment.Right;
            healthBuyAmt.DrawString(((heroHealth/10) * statMultiplier).ToString()); //insert variable for cost here

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
            attackBuy.AddSprite("AttackBuyDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 367, 45, 45));
            attackBuy.AddSprite("AttackBuyHover", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 455, 45, 45));
            attackBuy.AddSprite("AttackBuyClick", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 500, 45, 45));
            ButtonComponent attackPurchase = new ButtonComponent(attackBuyObj);

            GameObject attackBuyAmtObj = new GameObject("AttackBuyAmtObj");
            attackBuyButton.AddChild(attackBuyAmtObj);
            attackBuyAmtObj.LocalPosition = new Point(120, 17);
            FontRendererComponent attackBuyAmt = new FontRendererComponent(attackBuyAmtObj, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            attackBuyAmt.CurrentAllignment = FontRendererComponent.Allignment.Right;
            attackBuyAmt.DrawString((heroAttack * statMultiplier).ToString()); //insert variable for cost here

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
            skill1UpBuy.AddSprite("Skill1UpBuyDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 367, 45, 45));
            skill1UpBuy.AddSprite("Skill1UpBuyHover", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 455, 45, 45));
            skill1UpBuy.AddSprite("Skill1UpBuyClick", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 500, 45, 45));
            ButtonComponent skill1Up = new ButtonComponent(skill1UpBuyObj);

            GameObject skill1BuyAmtObj = new GameObject("Skill1BuyAmtObj");
            skill1UpButtonObj.AddChild(skill1BuyAmtObj);
            skill1BuyAmtObj.LocalPosition = new Point(120, 17);
            FontRendererComponent skill1BuyAmt = new FontRendererComponent(skill1BuyAmtObj, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            skill1BuyAmt.CurrentAllignment = FontRendererComponent.Allignment.Right;
            skill1BuyAmt.DrawString((heroSkill1 * skillMultiplier).ToString()); //insert variable for cost here

            GameObject Skill1IdentifierObj = new GameObject("Skill1IdentifierObj");
            skill1UpButtonObj.AddChild(Skill1IdentifierObj);
            Skill1IdentifierObj.LocalPosition = new Point(190, 10);
            FontRendererComponent Skill1Identifier = new FontRendererComponent(Skill1IdentifierObj, "Assets/Font/42Fontsheet.png", "Assets/Font/42Fontsheet.fnt");
            Skill1Identifier.DrawString("Skill 1"); //variable for skill 3

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
            skill2UpBuy.AddSprite("Skill2UpBuyDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 367, 45, 45));
            skill2UpBuy.AddSprite("Skill2UpBuyHover", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 455, 45, 45));
            skill2UpBuy.AddSprite("Skill2UpBuyClick", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 500, 45, 45));
            ButtonComponent skill2Up = new ButtonComponent(skill2UpBuyObj);

            GameObject skill2BuyAmtObj = new GameObject("Skill2BuyAmtObj");
            skill2UpButtonObj.AddChild(skill2BuyAmtObj);
            skill2BuyAmtObj.LocalPosition = new Point(120, 17);
            FontRendererComponent skill2BuyAmt = new FontRendererComponent(skill2BuyAmtObj, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            skill2BuyAmt.CurrentAllignment = FontRendererComponent.Allignment.Right;
            skill2BuyAmt.DrawString((heroSkill2 * skillMultiplier).ToString()); //insert variable for cost here

            GameObject Skill2IdentifierObj = new GameObject("Skill2IdentifierObj");
            skill2UpButtonObj.AddChild(Skill2IdentifierObj);
            Skill2IdentifierObj.LocalPosition = new Point(190, 10);
            FontRendererComponent Skill2Identifier = new FontRendererComponent(Skill2IdentifierObj, "Assets/Font/42Fontsheet.png", "Assets/Font/42Fontsheet.fnt");
            Skill2Identifier.DrawString("Skill 2"); //variable for skill 3

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
            skill3UpBuy.AddSprite("Skill3UpBuyDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 367, 45, 45));
            skill3UpBuy.AddSprite("Skill3UpBuyHover", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 455, 45, 45));
            skill3UpBuy.AddSprite("Skill3UpBuyClick", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 500, 45, 45));

            ButtonComponent skill3Up = new ButtonComponent(skill3UpBuyObj);

            GameObject skill3BuyAmtObj = new GameObject("Skill3BuyAmtObj");
            skill3UpButtonObj.AddChild(skill3BuyAmtObj);
            skill3BuyAmtObj.LocalPosition = new Point(120, 17);
            FontRendererComponent skill3BuyAmt = new FontRendererComponent(skill3BuyAmtObj, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            skill3BuyAmt.CurrentAllignment = FontRendererComponent.Allignment.Right;
            skill3BuyAmt.DrawString((heroSkill3 * skillMultiplier).ToString()); //insert variable for cost here

            GameObject Skill3IdentifierObj = new GameObject("Skill3IdentifierObj");
            skill3UpButtonObj.AddChild(Skill3IdentifierObj);
            Skill3IdentifierObj.LocalPosition = new Point(190, 10);
            FontRendererComponent Skill3Identifier = new FontRendererComponent(Skill3IdentifierObj, "Assets/Font/42Fontsheet.png", "Assets/Font/42Fontsheet.fnt");
            Skill3Identifier.DrawString("Skill 3"); //variable for skill 3

            //Back button
            GameObject backButton = new GameObject("BackButton");
            Root.AddChild(backButton);
            backButton.LocalPosition = new Point(10,423);
            StaticSpriteRendererComponent backSprite = new StaticSpriteRendererComponent(backButton);
            backSprite.AddSprite("BackDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 181, 46, 46));
            backSprite.AddSprite("BackHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 227, 46, 46));
            backSprite.AddSprite("BackHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 273, 46, 46));
            backSprite.AddSprite("BackClick", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 319, 46, 46));
            ButtonComponent back = new ButtonComponent(backButton);
            back.DoClick += delegate {
                SceneManager.Instance.PopScene();
            };
            back.DoHover += delegate {
                if (backSprite.CurrentSprite != "BackHover2") {
                    backSprite.SetSprite("BackHover2");
                }
            };
            back.NoHover += delegate {
                if (backSprite.CurrentSprite != "BackDefault") {
                    backSprite.SetSprite("BackDefault");
                }
            };
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

            GameObject healthAmtObj = new GameObject("HealthIdentifierAmtObj");
            healthObj.AddChild(healthAmtObj);
            healthAmtObj.LocalPosition = new Point(27, 45);
            FontRendererComponent healthAmtFnt = new FontRendererComponent(healthAmtObj, "Assets/font/14Fontsheet.png", "Assets/Font/14Fontsheet.fnt");
            healthAmtFnt.CurrentAllignment = FontRendererComponent.Allignment.Center;
            healthAmtFnt.DrawString(heroHealth.ToString()); //insert variable here

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

            GameObject attackAmtObj = new GameObject("HealthIdentifierAmtObj");
            attackObj.AddChild(attackAmtObj);
            attackAmtObj.LocalPosition = new Point(27, 45);
            FontRendererComponent attackAmtFnt = new FontRendererComponent(attackAmtObj, "Assets/font/14Fontsheet.png", "Assets/Font/14Fontsheet.fnt");
            attackAmtFnt.CurrentAllignment = FontRendererComponent.Allignment.Center;
            attackAmtFnt.DrawString(heroAttack.ToString()); //insert variable here

            heartPurchase.DoHover += delegate {
                if (heartBuy.CurrentSprite != "HeartBuyHover") {
                    heartBuy.SetSprite("HeartBuyHover");
                }
            };
            heartPurchase.NoHover += delegate {
                if (heartBuy.CurrentSprite != "HeartBuyDefault") {
                    heartBuy.SetSprite("HeartBuyDefault");
                }
            };
            heartPurchase.DoClick += delegate {
                //increase level of skill
                //increase cost
                if (Monies >= (heroHealth * statMultiplier) / 10){
                    if (heartBuy.CurrentSprite != "HeartBuyClick") {
                        heartBuy.SetSprite("HeartBuyClick");
                    }
                    Monies -= (heroHealth * statMultiplier) / 10;
                    heroHealth++;
                    currencyAmt.DrawString(Monies.ToString());//insert currency variable here
                    healthBuyAmt.DrawString(((heroHealth * statMultiplier) / 10).ToString()); //insert variable for cost here
                    healthAmtFnt.DrawString(heroHealth.ToString()); //insert variable here
                }
            };


            attackPurchase.DoHover += delegate {
                if (attackBuy.CurrentSprite != "AttackBuyHover") {
                    attackBuy.SetSprite("AttackBuyHover");
                }
            };
            attackPurchase.NoHover += delegate {
                if (attackBuy.CurrentSprite != "AttackBuyDefault") {
                    attackBuy.SetSprite("AttackBuyDefault");
                }
            };
            attackPurchase.DoClick += delegate {
                //increase level of skill
                //increase cost
                if (Monies >= (heroAttack * statMultiplier)) {
                    if (attackBuy.CurrentSprite != "AttackBuyClick") {
                        attackBuy.SetSprite("AttackBuyClick");
                    }
                    Monies -= (heroAttack * statMultiplier);
                    heroAttack++;
                    currencyAmt.DrawString(Monies.ToString());//insert currency variable here
                    attackBuyAmt.DrawString((heroAttack * statMultiplier).ToString()); //insert variable for cost here
                    attackAmtFnt.DrawString(heroAttack.ToString()); //insert variable here
                }
            };

            skill1Up.DoHover += delegate {
                if (skill1UpBuy.CurrentSprite != "Skill1UpBuyHover") {
                    skill1UpBuy.SetSprite("Skill1UpBuyHover");
                }
            };
            skill1Up.NoHover += delegate {
                if (skill1UpBuy.CurrentSprite != "Skill1UpBuyDefault") {
                    skill1UpBuy.SetSprite("Skill1UpBuyDefault");
                }
            };
            skill1Up.DoClick += delegate {
                //increase level of skill
                //increase cost
                if (Monies >= heroSkill1 * skillMultiplier) {
                    if (skill1UpBuy.CurrentSprite != "Skill1UpBuyClick") {
                        skill1UpBuy.SetSprite("Skill1UpBuyClick");
                    }
                    Monies -= heroSkill1 * skillMultiplier;
                    heroSkill1++;
                    currencyAmt.DrawString(Monies.ToString());//insert currency variable here
                    skill1BuyAmt.DrawString((heroSkill1 * skillMultiplier).ToString()); //insert variable for cost here
                }
            };

            skill2Up.DoHover += delegate {
                if (skill2UpBuy.CurrentSprite != "Skill2UpBuyHover") {
                    skill2UpBuy.SetSprite("Skill2UpBuyHover");
                }
            };
            skill2Up.NoHover += delegate {
                if (skill2UpBuy.CurrentSprite != "Skill2UpBuyDefault") {
                    skill2UpBuy.SetSprite("Skill2UpBuyDefault");
                }
            };
            skill2Up.DoClick += delegate {
                //increase level of skill
                //increase cost
                if (Monies >= heroSkill2 * skillMultiplier) {
                    if (skill2UpBuy.CurrentSprite != "Skill2UpBuyClick") {
                        skill2UpBuy.SetSprite("Skill2UpBuyClick");
                    }
                    Monies -= heroSkill2 * skillMultiplier;
                    heroSkill2++;
                    currencyAmt.DrawString(Monies.ToString());//insert currency variable here
                    skill2BuyAmt.DrawString((heroSkill2 * skillMultiplier).ToString()); //insert variable for cost here
                }
            };

            skill3Up.DoHover += delegate {
                if (skill3UpBuy.CurrentSprite != "Skill3UpBuyHover") {
                    skill3UpBuy.SetSprite("Skill3UpBuyHover");
                }
            };
            skill3Up.NoHover += delegate {
                if (skill3UpBuy.CurrentSprite != "Skill3UpBuyDefault") {
                    skill3UpBuy.SetSprite("Skill3UpBuyDefault");
                }
            };
            skill3Up.DoClick += delegate {
                //increase level of skill
                //increase cost
                if (Monies >= heroSkill3 * skillMultiplier) {
                    if (skill3UpBuy.CurrentSprite != "Skill3UpBuyClick") {
                        skill3UpBuy.SetSprite("Skill3UpBuyClick");
                    }
                    Monies -= heroSkill3 * skillMultiplier;
                    heroSkill3++;
                    currencyAmt.DrawString(Monies.ToString());//insert currency variable here
                    skill3BuyAmt.DrawString((heroSkill3 * skillMultiplier).ToString()); //insert variable for cost here
                }
            };
        }//end initialize
        public override void Exit() {
            using (StreamWriter writer = new StreamWriter("Assets/Data/CurrentHero.txt")) {
                writer.WriteLine(CurrentHero.ToString());
                writer.WriteLine(Monies.ToString());
            }
            using (StreamWriter writer = new StreamWriter("Assets/Data/hero_" + CurrentHero + ".txt")) {
                writer.WriteLine(heroHealth);
                writer.WriteLine(heroAttack);
                writer.WriteLine(skill1Name);
                writer.WriteLine(skill2Name);
                writer.WriteLine(skill3Name);
                writer.WriteLine(heroSkill1);
                writer.WriteLine(heroSkill2);
                writer.WriteLine(heroSkill3);

            }
        }
    }
}
