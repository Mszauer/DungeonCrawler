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
        public List<GameObject> Heroes = null;
        public int CurrentHero = 0;
        public override void Initialize() {
            Heroes = new List<GameObject>();
            //background
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
            currencyAmt.DrawString("0");//insert currency variable here

            //Back button
            GameObject backButton = new GameObject("BackButton");
            Root.AddChild(backButton);
            backButton.LocalPosition = new Point(10, 423);
            StaticSpriteRendererComponent backSprite = new StaticSpriteRendererComponent(backButton);
            backSprite.AddSprite("BackDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 181, 46, 46));
            backSprite.AddSprite("BackHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 227, 46, 46));
            backSprite.AddSprite("BackHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 273, 46, 46));
            backSprite.AddSprite("BackClick", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 319, 46, 46));
            ButtonComponent back = new ButtonComponent(backButton);
            back.DoHover += delegate {
                if (backSprite.CurrentSprite != "BackHover2") {
                    backSprite.SetSprite("BackHover2");
                }
            };
            back.DoClick += delegate {
                SceneManager.Instance.PopScene();
            };
            back.NoHover += delegate {
                if (backSprite.CurrentSprite != "BackDefault") {
                    backSprite.SetSprite("BackDefault");
                }
            };

            //tree stump
            GameObject treeStumpObj = new GameObject("TreeStumpObj");
            Root.AddChild(treeStumpObj);
            treeStumpObj.LocalPosition = new Point(0, 335);
            StaticSpriteRendererComponent treeStumpSprite = new StaticSpriteRendererComponent(treeStumpObj);
            treeStumpSprite.AddSprite("TreeStumpSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(244, 904, 112, 85));

            //HEROES
            //That Gai hero
            GameObject thatGaiObj = new GameObject("ThatGai");
            Root.AddChild(thatGaiObj);
            thatGaiObj.LocalPosition = new Point(15, 235);
            thatGaiObj.Enabled = true;
            Heroes.Add(thatGaiObj);
            AnimatedSpriteRendererComponent thatGai = new AnimatedSpriteRendererComponent(thatGaiObj);
            thatGai.AddAnimation("Idle", "Assets/Characters/Archer/Archer_Idle.png", thatGai.AddAnimation(4, 4, 128, 128));
            thatGai.PlayAnimation("Idle");

            //BoveMaster Hero
            GameObject boveMasterObj = new GameObject("BoveMaster");
            Root.AddChild(boveMasterObj);
            boveMasterObj.LocalPosition = new Point(5, 235);
            boveMasterObj.Enabled = false;
            Heroes.Add(boveMasterObj);
            AnimatedSpriteRendererComponent boveMaster = new AnimatedSpriteRendererComponent(boveMasterObj);
            boveMaster.AddAnimation("Idle", "Assets/Characters/Knight/Knight_Idle.png", boveMaster.AddAnimation(4, 4, 128, 128));
            boveMaster.PlayAnimation("Idle");

            //sassy calves hero
            GameObject sassyCalvesObj = new GameObject("Sassy Calves");
            Root.AddChild(sassyCalvesObj);
            sassyCalvesObj.LocalPosition = new Point(15, 235);
            sassyCalvesObj.Enabled = false;
            Heroes.Add(sassyCalvesObj);
            AnimatedSpriteRendererComponent sassyCalves = new AnimatedSpriteRendererComponent(sassyCalvesObj);
            sassyCalves.AddAnimation("Idle", "Assets/Characters/Barbarian/Barbarian_Idle.png", sassyCalves.AddAnimation(4, 4, 128, 128));
            sassyCalves.PlayAnimation("Idle");
            GameObject petRockObj = new GameObject("PetRockObj");
            sassyCalvesObj.AddChild(petRockObj);
            petRockObj.LocalPosition = new Point(0, 100);
            StaticSpriteRendererComponent petRock = new StaticSpriteRendererComponent(petRockObj);
            petRock.Anchor = StaticSpriteRendererComponent.AnchorPosition.BottomMiddle;
            petRock.AddSprite("Pet Rock1", "Assets/ObjectSpriteSheet.png", new Rectangle(448, 945, 80, 80));
            petRock.AddSprite("Pet Rock2", "Assets/ObjectSpriteSheet.png", new Rectangle(448, 859, 80, 80));
            petRock.AddSprite("Pet Rock3", "Assets/ObjectSpriteSheet.png", new Rectangle(365, 859, 80, 80));
            petRock.AddSprite("Pet Rock4", "Assets/ObjectSpriteSheet.png", new Rectangle(365, 945, 80, 80));
            petRock.SetSprite("Pet Rock1");

            //health identifier
            GameObject healthObj = new GameObject("HealthObj");
            Root.AddChild(healthObj);
            healthObj.LocalPosition = new Point(112, 412);
            StaticSpriteRendererComponent healthBg = new StaticSpriteRendererComponent(healthObj);
            healthBg.AddSprite("healthBg", "Assets/ObjectSpriteSheet.png", new Rectangle(42, 675, 55, 70));

            GameObject heartHealthObj = new GameObject("HeartHealthObj");
            healthObj.AddChild(heartHealthObj);
            heartHealthObj.LocalPosition = new Point(10, 9);
            StaticSpriteRendererComponent heartHealthIco = new StaticSpriteRendererComponent(heartHealthObj);
            heartHealthIco.AddSprite("HeartHealthIco", "Assets/ObjectSpriteSheet.png", new Rectangle(142, 761, 36, 31));

            GameObject healthLevelObj = new GameObject("HealthLevelObj");
            healthObj.AddChild(healthLevelObj);
            healthLevelObj.LocalPosition = new Point(54, 0);
            StaticSpriteRendererComponent healthLevelSprite = new StaticSpriteRendererComponent(healthLevelObj);
            healthLevelSprite.AddSprite("HealthLevelSpriteDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(948, 350, 35, 35));
            healthLevelSprite.AddSprite("HealthLevelSpriteHover", "Assets/ObjectSpriteSheet.png", new Rectangle(948, 418, 35, 35));
            healthLevelSprite.AddSprite("HealthLevelSpriteClick", "Assets/ObjectSpriteSheet.png", new Rectangle(948, 453, 35, 35));
            ButtonComponent health = new ButtonComponent(healthLevelObj);
            health.DoClick += delegate {
                if (healthLevelSprite.CurrentSprite != "HealthLevelSpriteClick") {
                    healthLevelSprite.SetSprite("HealthLevelSpriteClick");
                }
                SceneManager.Instance.PushScene(new ShopScene());
            };
            health.DoHover += delegate {
                if (healthLevelSprite.CurrentSprite != "HealthLevelSpriteHover") {
                    healthLevelSprite.SetSprite("HealthLevelSpriteHover");
                }
            };
            health.NoHover += delegate {
                if (healthLevelSprite.CurrentSprite != "HealthLevelSpriteDefault") {
                    healthLevelSprite.SetSprite("HealthLevelSpriteDefault");
                }
            };

            GameObject healthAmtObj = new GameObject("HealthIdentifierAmtObj");
            healthObj.AddChild(healthAmtObj);
            healthAmtObj.LocalPosition = new Point(27, 45);
            FontRendererComponent healthAmtFnt = new FontRendererComponent(healthAmtObj, "Assets/font/14Fontsheet.png", "Assets/Font/14Fontsheet.fnt");
            healthAmtFnt.CurrentAllignment = FontRendererComponent.Allignment.Center;
            healthAmtFnt.DrawString("0"); //insert variable here

            //attack identifier
            GameObject attackObj = new GameObject("AttackObj");
            Root.AddChild(attackObj);
            attackObj.LocalPosition = new Point(230, 412);
            StaticSpriteRendererComponent attack = new StaticSpriteRendererComponent(attackObj);
            attack.AddSprite("AttackBg", "Assets/ObjectSpriteSheet.png", new Rectangle(42, 675, 55, 70));

            GameObject swordIcoObj = new GameObject("SwordIcoObj");
            attackObj.AddChild(swordIcoObj);
            swordIcoObj.LocalPosition = new Point(11, 7);
            StaticSpriteRendererComponent swordIco = new StaticSpriteRendererComponent(swordIcoObj);
            swordIco.AddSprite("SwordIco", "Assets/ObjectSpriteSheet.png", new Rectangle(93, 759, 38, 38));

            GameObject attackLevelObj = new GameObject("AttackLevelObj");
            attackObj.AddChild(attackLevelObj);
            attackLevelObj.LocalPosition = new Point(54,0);//284,415 global
            StaticSpriteRendererComponent attackLevelSprite = new StaticSpriteRendererComponent(attackLevelObj);
            attackLevelSprite.AddSprite("AttackLevelSpriteDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(948, 350, 35, 35));
            attackLevelSprite.AddSprite("AttackLevelSpriteHover", "Assets/ObjectSpriteSheet.png", new Rectangle(948, 418, 35, 35));
            attackLevelSprite.AddSprite("AttackLevelSpriteClick", "Assets/ObjectSpriteSheet.png", new Rectangle(948, 453, 35, 35));
            ButtonComponent attackShop = new ButtonComponent(attackLevelObj);
            attackShop.DoClick += delegate {
                if (attackLevelSprite.CurrentSprite != "AttackLevelSpriteClick") {
                    attackLevelSprite.SetSprite("AttackLevelSpriteClick");
                }
                 SceneManager.Instance.PushScene(new ShopScene());
             };
            attackShop.DoHover += delegate {
                if (attackLevelSprite.CurrentSprite != "AttackLevelSpriteHover") {
                    attackLevelSprite.SetSprite("AttackLevelSpriteHover");
                }
            };
            attackShop.NoHover += delegate {
                if (attackLevelSprite.CurrentSprite != "AttackLevelSpriteDefault") {
                    attackLevelSprite.SetSprite("AttackLevelSpriteDefault");
                }
            };

            GameObject attackAmtObj = new GameObject("HealthIdentifierAmtObj");
            attackObj.AddChild(attackAmtObj);
            attackAmtObj.LocalPosition = new Point(27, 45);
            FontRendererComponent attackAmtFnt = new FontRendererComponent(attackAmtObj, "Assets/font/14Fontsheet.png", "Assets/Font/14Fontsheet.fnt");
            attackAmtFnt.CurrentAllignment = FontRendererComponent.Allignment.Center;
            attackAmtFnt.DrawString("0"); //insert variable here

            //name plate
            GameObject namePlateObj = new GameObject("NamePlateObj");
            Root.AddChild(namePlateObj);
            namePlateObj.LocalPosition = new Point(18,60);
            StaticSpriteRendererComponent namePlateSprite = new StaticSpriteRendererComponent(namePlateObj);
            namePlateSprite.AddSprite("NamePlateSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(320, 180, 286, 54));

            //hero name
            GameObject heroNameObj = new GameObject("heroNameObj");
            namePlateObj.AddChild(heroNameObj);
            heroNameObj.LocalPosition = new Point(143, 5);
            FontRendererComponent heroNameFont = new FontRendererComponent(heroNameObj, "Assets/Font/42Fontsheet.png", "Assets/Font/42Fontsheet.fnt");
            heroNameFont.CurrentAllignment = FontRendererComponent.Allignment.Center;
            heroNameFont.DrawString(Heroes[CurrentHero].Name); // CurrentHero.Name

            //name plate prev button
            GameObject namePlatePrevObj = new GameObject("NamePlatePrevObj");
            namePlateObj.AddChild(namePlatePrevObj);
            namePlatePrevObj.LocalPosition = new Point(2, 5);
            StaticSpriteRendererComponent namePlatePrevSprite = new StaticSpriteRendererComponent(namePlatePrevObj);
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 723, 46, 46));
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 769, 46, 46));
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 811, 46, 46));
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteClick", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 858, 46, 46));
            ButtonComponent namePlatePrev = new ButtonComponent(namePlatePrevObj);
            namePlatePrev.DoClick += delegate {
                if (namePlatePrevSprite.CurrentSprite != "NamePlatePrevSpriteClick") {
                    namePlatePrevSprite.SetSprite("NamePlatePrevSpriteClick");
                }
                Heroes[CurrentHero].Enabled = false;
                CurrentHero--;
                if (CurrentHero < 0) {
                    CurrentHero = Heroes.Count - 1;
                }
                Heroes[CurrentHero].Enabled = true;
                heroNameFont.DrawString(Heroes[CurrentHero].Name); // CurrentHero.Name
            };
            namePlatePrev.DoHover += delegate {
                if (namePlatePrevSprite.CurrentSprite != "NamePlatePrevSpriteHover2") {
                    namePlatePrevSprite.SetSprite("NamePlatePrevSpriteHover2");
                }
            };
            namePlatePrev.NoHover += delegate {
                if (namePlatePrevSprite.CurrentSprite != "NamePlatePrevSpriteDefault") {
                    namePlatePrevSprite.SetSprite("NamePlatePrevSpriteDefault");
                }
            };

            //name plate next button
            GameObject namePlateNextObj = new GameObject("NamePlateNextObj");
            namePlateObj.AddChild(namePlateNextObj);
            namePlateNextObj.LocalPosition = new Point(237, 5);
            StaticSpriteRendererComponent namePlateNextSprite = new StaticSpriteRendererComponent(namePlateNextObj);
            namePlateNextSprite.AddSprite("NamePlateNextSpriteDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 543, 46, 46));
            namePlateNextSprite.AddSprite("NamePlatenextSpriteHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 587, 46, 46));
            namePlateNextSprite.AddSprite("NamePlatenextSpriteHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 632, 46, 46));
            namePlateNextSprite.AddSprite("NamePlatenextSpriteClick", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 678, 46, 46));
            ButtonComponent namePlateNext = new ButtonComponent(namePlateNextObj);
            namePlateNext.DoClick += delegate {
                if (namePlateNextSprite.CurrentSprite != "NamePlatenextSpriteClick") {
                    namePlateNextSprite.SetSprite("NamePlatenextSpriteClick");
                }
                //do logic to swap her component and skills
                Heroes[CurrentHero].Enabled = false;
                CurrentHero++;
                if (CurrentHero > Heroes.Count-1) {
                    CurrentHero = 0;
                }
                Heroes[CurrentHero].Enabled = true;
                heroNameFont.DrawString(Heroes[CurrentHero].Name); // CurrentHero.Name
            };
            namePlateNext.DoHover += delegate {
                if (namePlateNextSprite.CurrentSprite != "NamePlatenextSpriteHover2") {
                    namePlateNextSprite.SetSprite("NamePlatenextSpriteHover2");
                }
            };
            namePlateNext.NoHover += delegate {
                if (namePlateNextSprite.CurrentSprite != "NamePlateNextSpriteDefault") {
                    namePlateNextSprite.SetSprite("NamePlateNextSpriteDefault");
                }
            };

            //skill 1
            GameObject skill1BgObj = new GameObject("Skill1BgObj");
            Root.AddChild(skill1BgObj);
            skill1BgObj.LocalPosition = new Point(100, 130);
            StaticSpriteRendererComponent skill1BgSprite = new StaticSpriteRendererComponent(skill1BgObj);
            skill1BgSprite.AddSprite("Skill1BgSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(528, 105, 189, 61));

            GameObject skill1NameObj = new GameObject("Skill1NameObj");
            skill1BgObj.AddChild(skill1NameObj);
            skill1NameObj.LocalPosition = new Point(95, 5);
            FontRendererComponent skill1NameFnt = new FontRendererComponent(skill1NameObj, "Assets/Font/42Fontsheet.png", "Assets/Font/42Fontsheet.fnt");
            skill1NameFnt.CurrentAllignment = FontRendererComponent.Allignment.Center;
            skill1NameFnt.DrawString("Skill 1"); //insert hero skill 1

            GameObject skill1TooltipObj = new GameObject("Skill1TooltipObj");
            skill1BgObj.AddChild(skill1TooltipObj);
            skill1TooltipObj.Enabled = false;
            skill1TooltipObj.LocalPosition = new Point(-20, -50); //75,80 global
            StaticSpriteRendererComponent skill1TooltipSprite = new StaticSpriteRendererComponent(skill1TooltipObj);
            skill1TooltipSprite.AddSprite("Skill1TooltipSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(730, 3, 240, 117));

            GameObject skill1LevelObj = new GameObject("Skill1LevelObj");
            skill1BgObj.AddChild(skill1LevelObj);
            skill1LevelObj.LocalPosition = new Point(158, 45);
            StaticSpriteRendererComponent skill1LeveSprite = new StaticSpriteRendererComponent(skill1LevelObj);
            skill1LeveSprite.AddSprite("Skill1LevelSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(99, 804, 46, 46));
            ButtonComponent skill1 = new ButtonComponent(skill1LevelObj);
            skill1.DoHover += delegate {
                skill1TooltipObj.Enabled = true;
            };
            skill1.NoHover += delegate {
                skill1TooltipObj.Enabled = false;
            };
            //skill 2
            GameObject skill2BgObj = new GameObject("Skill2BgObj");
            Root.AddChild(skill2BgObj);
            skill2BgObj.LocalPosition = new Point(100, 225);
            StaticSpriteRendererComponent skill2BgSprite = new StaticSpriteRendererComponent(skill2BgObj);
            skill2BgSprite.AddSprite("Skill2BgSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(528, 105, 189, 61));

            GameObject skill2NameObj = new GameObject("Skill2NameObj");
            skill2BgObj.AddChild(skill2NameObj);
            skill2NameObj.LocalPosition = new Point(95, 5);
            FontRendererComponent skill2NameFnt = new FontRendererComponent(skill2NameObj, "Assets/Font/42Fontsheet.png", "Assets/Font/42Fontsheet.fnt");
            skill2NameFnt.CurrentAllignment = FontRendererComponent.Allignment.Center;
            skill2NameFnt.DrawString("Skill 2"); //insert hero skill 1

            GameObject skill2TooltipObj = new GameObject("Skill2TooltipObj");
            skill2BgObj.AddChild(skill2TooltipObj);
            skill2TooltipObj.Enabled = false;
            skill2TooltipObj.LocalPosition = new Point(-20, -50); //80,172 global
            StaticSpriteRendererComponent skill2TooltipSprite = new StaticSpriteRendererComponent(skill2TooltipObj);
            skill2TooltipSprite.AddSprite("Skill2TooltipSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(730, 3, 240, 117));

            GameObject skill2LevelObj = new GameObject("Skill2LevelObj");
            skill2BgObj.AddChild(skill2LevelObj);
            skill2LevelObj.LocalPosition = new Point(158, 45);
            StaticSpriteRendererComponent skill2LeveSprite = new StaticSpriteRendererComponent(skill2LevelObj);
            skill2LeveSprite.AddSprite("Skill2LevelSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(99, 804, 46, 46));
            ButtonComponent skill2 = new ButtonComponent(skill2LevelObj);
            skill2.DoHover += delegate {
                skill2TooltipObj.Enabled = true;
            };
            skill2.NoHover += delegate {
                skill2TooltipObj.Enabled = false;
            };

            //skill 3
            GameObject skill3BgObj = new GameObject("Skill3BgObj");
            Root.AddChild(skill3BgObj);
            skill3BgObj.LocalPosition = new Point(100, 320);
            StaticSpriteRendererComponent skill3BgSprite = new StaticSpriteRendererComponent(skill3BgObj);
            skill3BgSprite.AddSprite("Skill3BgSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(528, 105, 189, 61));

            GameObject skill3NameObj = new GameObject("Skill3NameObj");
            skill3BgObj.AddChild(skill3NameObj);
            skill3NameObj.LocalPosition = new Point(95, 5);
            FontRendererComponent skill3NameFnt = new FontRendererComponent(skill3NameObj, "Assets/Font/42Fontsheet.png", "Assets/Font/42Fontsheet.fnt");
            skill3NameFnt.CurrentAllignment = FontRendererComponent.Allignment.Center;
            skill3NameFnt.DrawString("Skill 3"); //insert hero skill 3

            GameObject skill3TooltipObj = new GameObject("Skill3TooltipObj");
            skill3BgObj.AddChild(skill3TooltipObj);
            skill3TooltipObj.Enabled = false;
            skill3TooltipObj.LocalPosition = new Point(-20, -55); //75,265 global
            StaticSpriteRendererComponent skill3TooltipSprite = new StaticSpriteRendererComponent(skill3TooltipObj);
            skill3TooltipSprite.AddSprite("Skill3TooltipSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(730, 3, 240, 117));

            GameObject skill3LevelObj = new GameObject("Skill3LevelObj");
            skill3BgObj.AddChild(skill3LevelObj);
            skill3LevelObj.LocalPosition = new Point(158, 45);
            StaticSpriteRendererComponent skill3LeveSprite = new StaticSpriteRendererComponent(skill3LevelObj);
            skill3LeveSprite.AddSprite("Skill3LevelSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(99, 804, 46, 46));
            ButtonComponent skill3 = new ButtonComponent(skill3LevelObj);
            skill3.DoHover += delegate {
                skill3TooltipObj.Enabled = true;
            };
            skill3.NoHover += delegate {
                skill3TooltipObj.Enabled = false;
            };

        }//end update
    }
}
