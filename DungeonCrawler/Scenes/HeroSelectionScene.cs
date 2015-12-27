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
    class HeroSelectionScene : Scene{
        protected int CurrentHero = 0;
        protected int Monies = 0;

        public override void Initialize() {
            List<GameObject> Heroes = new List<GameObject>();

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
            currencyAmt.DrawString(Monies.ToString());//insert currency variable here

            //Back button
            GameObject backButton = new GameObject("BackButton");
            Root.AddChild(backButton);
            backButton.LocalPosition = new Point(10, 423);
            StaticSpriteRendererComponent backSprite = new StaticSpriteRendererComponent(backButton);
            backSprite.AddSprite("BackDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 181, 46, 46));
            backSprite.AddSprite("BackHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 227, 46, 46));
            backSprite.AddSprite("BackHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 273, 46, 46));
            backSprite.AddSprite("BackClick", "Assets/ObjectSpriteSheet.png", new Rectangle(976, 319, 46, 46));
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

            //switch to next scene
            GameObject startButton = new GameObject("StartButton");
            Root.AddChild(startButton);
            startButton.LocalPosition = new Point(265, 1);
            StaticSpriteRendererComponent sButton = new StaticSpriteRendererComponent(startButton);
            sButton.AddSprite("PlayButtonDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(918, 126, 57, 57));
            sButton.AddSprite("PlayButtonDefaultHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(918, 126, 58, 58));
            sButton.AddSprite("PlayButtonDefaultHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(918, 238, 58, 58));
            sButton.AddSprite("PlayButtonDefaultClick", "Assets/ObjectSpriteSheet.png", new Rectangle(918, 297, 58, 58));
            ButtonComponent play = new ButtonComponent(startButton);
            play.DoHover += delegate () {
                if (sButton.CurrentSprite != "PlayButtonDefaultHover2") {
                    sButton.SetSprite("PlayButtonDefaultHover2");
                }
            };
            play.DoClick += delegate () {
                SceneManager.Instance.PopScene();
                SceneManager.Instance.PopScene();
                SceneManager.Instance.PushScene(new InGameScene());
            };
            play.NoHover += delegate () {
                if (sButton.CurrentSprite != "PlayButtonDefault") {
                    sButton.SetSprite("PlayButtonDefault");
                }
            };
            //tree stump
            GameObject treeStumpObj = new GameObject("TreeStumpObj");
            Root.AddChild(treeStumpObj);
            treeStumpObj.LocalPosition = new Point(0, 335);
            StaticSpriteRendererComponent treeStumpSprite = new StaticSpriteRendererComponent(treeStumpObj);
            treeStumpSprite.AddSprite("TreeStumpSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(244, 904, 112, 85));

            if (File.Exists("Assets/Data/CurrentHero.txt")) {
                using (TextReader reader = File.OpenText("Assets/Data/CurrentHero.txt")) {
                    CurrentHero = System.Convert.ToInt32(reader.ReadLine());
                    Monies = System.Convert.ToInt32(reader.ReadLine());
                }
            }//end if

            //HEROES
            //That Gai hero
            GameObject thatGaiObj = new GameObject("That Gai");
            Root.AddChild(thatGaiObj);
            thatGaiObj.LocalPosition = new Point(15, 235);
            thatGaiObj.Enabled = CurrentHero == 0;
            Heroes.Add(thatGaiObj);
            HeroComponent gai = new HeroComponent(thatGaiObj);
            gai.HeroIndex = 0;
            gai.AddSkill("Pull Sumo", 4, "\"Pull Sumo Eat Butt!\"\nIncreases health by 2/level");
            gai.AddSkill("Glutes of Steel", 4, "Rumour has it his glutes\n are actually made of steel!\nIncreases attack by 1/level");
            gai.AddSkill("Almond Lover", 4,"Almond Milk is life\n increases health by 1/level");
            AnimatedSpriteRendererComponent thatGai = new AnimatedSpriteRendererComponent(thatGaiObj);
            thatGai.AddAnimation("Idle", "Assets/Characters/Archer/Archer_Idle.png", thatGai.AddAnimation(4, 4, 128, 128));
            thatGai.PlayAnimation("Idle");

            //BoveMaster Hero
            GameObject boveMasterObj = new GameObject("BoveMaster");
            Root.AddChild(boveMasterObj);
            boveMasterObj.LocalPosition = new Point(5, 235);
            boveMasterObj.Enabled = CurrentHero == 1;
            Heroes.Add(boveMasterObj);
            HeroComponent bove = new HeroComponent(boveMasterObj);
            bove.HeroIndex = 1;
            bove.AddSkill("Beard of Gods", 4, "A beard Odin is jealous of\nIncreases 2 health/level");
            bove.AddSkill("Whittler", 4, "Such dexterity, wow\nMuch whittling\n Increases attack 1/level");
            bove.AddSkill("Coach", 4, "Perfect execution of hits\nIncreases attack 1/level");
            AnimatedSpriteRendererComponent boveMaster = new AnimatedSpriteRendererComponent(boveMasterObj);
            boveMaster.AddAnimation("Idle", "Assets/Characters/Knight/Knight_Idle.png", boveMaster.AddAnimation(4, 4, 128, 128));
            boveMaster.PlayAnimation("Idle");

            //sassy calves hero
            GameObject sassyCalvesObj = new GameObject("Sassy Calves");
            Root.AddChild(sassyCalvesObj);
            sassyCalvesObj.LocalPosition = new Point(15, 235);
            sassyCalvesObj.Enabled = CurrentHero == 2;
            Heroes.Add(sassyCalvesObj);
            HeroComponent sassy = new HeroComponent(sassyCalvesObj);
            sassy.HeroIndex = 2;
            sassy.AddSkill("Lion's Mane", 4, "An Impenetrable mane\nIncreases health 1/level");
            sassy.AddSkill("Pet Rock", 4, "A ferocious beast\nChance to deal 5 extra damage\nChance Increases/level");
            sassy.AddSkill("Team Calves", 4, "Calves like this are\nbestowed upon few\nIncreases damage 1/level");
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
            if (sassy.Skills[sassy.SkillIndexer[3]] == 1) {
                petRock.SetSprite("Pet Rock1");
            }
            else if (sassy.Skills[sassy.SkillIndexer[3]] == 2) {
                petRock.SetSprite("Pet Rock2");
            }
            else if (sassy.Skills[sassy.SkillIndexer[3]] == 3) {
                petRock.SetSprite("Pet Rock3");
            }
            else if (sassy.Skills[sassy.SkillIndexer[3]] >= 4) {
                petRock.SetSprite("Pet Rock4");
            }

            //load hero stats
                for (int i = 0; i < Heroes.Count; i++) {
                    if (File.Exists("Assets/Data/hero_" + i + ".txt")) {
                    using (StreamReader reader = new StreamReader("Assets/Data/hero_" + i + ".txt")) {
                        HeroComponent currentHeroComponent = (HeroComponent)Heroes[i].FindComponent("HeroComponent");//get hero object, get hero skills component
                        currentHeroComponent.Health = System.Convert.ToInt32(reader.ReadLine());
                        currentHeroComponent.Attack = System.Convert.ToInt32(reader.ReadLine());
                        reader.ReadLine();
                        reader.ReadLine();
                        reader.ReadLine();
                        List<string> skills = new List<string>(currentHeroComponent.Skills.Keys);
                        foreach (string skill in skills) {
                            currentHeroComponent.Skills[skill] = System.Convert.ToInt32(reader.ReadLine());
                        }
                    }
                }
            }

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
            healthLevelSprite.AddSprite("HealthLevelSpriteDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(942, 350, 35, 35));
            healthLevelSprite.AddSprite("HealthLevelSpriteHover", "Assets/ObjectSpriteSheet.png", new Rectangle(942, 418, 35, 35));
            healthLevelSprite.AddSprite("HealthLevelSpriteClick", "Assets/ObjectSpriteSheet.png", new Rectangle(942, 453, 35, 35));
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
            HeroComponent healthAmt = (HeroComponent)Heroes[CurrentHero].FindComponent("HeroComponent");
            healthAmtFnt.DrawString(healthAmt.Health.ToString());

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
            attackLevelSprite.AddSprite("AttackLevelSpriteDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(942, 350, 35, 35));
            attackLevelSprite.AddSprite("AttackLevelSpriteHover", "Assets/ObjectSpriteSheet.png", new Rectangle(942, 418, 35, 35));
            attackLevelSprite.AddSprite("AttackLevelSpriteClick", "Assets/ObjectSpriteSheet.png", new Rectangle(942, 453, 35, 35));
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

            GameObject attackAmtObj = new GameObject("AttackIdentifierAmtObj");
            attackObj.AddChild(attackAmtObj);
            attackAmtObj.LocalPosition = new Point(27, 45);
            FontRendererComponent attackAmtFnt = new FontRendererComponent(attackAmtObj, "Assets/font/14Fontsheet.png", "Assets/Font/14Fontsheet.fnt");
            attackAmtFnt.CurrentAllignment = FontRendererComponent.Allignment.Center;
            HeroComponent attackAmt = (HeroComponent)Heroes[CurrentHero].FindComponent("HeroComponent");
            attackAmtFnt.DrawString(attackAmt.Attack.ToString());

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
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(978, 723, 46, 46));
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(978, 769, 46, 46));
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(978, 811, 46, 46));
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteClick", "Assets/ObjectSpriteSheet.png", new Rectangle(978, 858, 46, 46));

            //name plate next button
            GameObject namePlateNextObj = new GameObject("NamePlateNextObj");
            namePlateObj.AddChild(namePlateNextObj);
            namePlateNextObj.LocalPosition = new Point(237, 5);
            StaticSpriteRendererComponent namePlateNextSprite = new StaticSpriteRendererComponent(namePlateNextObj);
            namePlateNextSprite.AddSprite("NamePlateNextSpriteDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(977, 543, 46, 46));
            namePlateNextSprite.AddSprite("NamePlatenextSpriteHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(977, 587, 46, 46));
            namePlateNextSprite.AddSprite("NamePlatenextSpriteHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(977, 632, 46, 46));
            namePlateNextSprite.AddSprite("NamePlatenextSpriteClick", "Assets/ObjectSpriteSheet.png", new Rectangle(977, 678, 46, 46));

            HeroComponent skillTooltips = (HeroComponent)Heroes[CurrentHero].FindComponent("HeroComponent");

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
            HeroComponent heroSkills = (HeroComponent)Heroes[CurrentHero].FindComponent("HeroComponent");
            skill1NameFnt.DrawString(heroSkills.SkillIndexer[1]); //insert hero skill 1

            GameObject skill1TooltipObj = new GameObject("Skill1TooltipObj");
            skill1BgObj.AddChild(skill1TooltipObj);
            skill1TooltipObj.Enabled = false;
            skill1TooltipObj.LocalPosition = new Point(-20, -50); //75,80 global
            StaticSpriteRendererComponent skill1TooltipSprite = new StaticSpriteRendererComponent(skill1TooltipObj);
            skill1TooltipSprite.AddSprite("Skill1TooltipSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(730, 3, 240, 117));

            GameObject skill1TooltipText = new GameObject("Skill1TooltipText");
            skill1TooltipObj.AddChild(skill1TooltipText);
            skill1TooltipText.LocalPosition = new Point(120, 13);
            FontRendererComponent tooltip1 = new FontRendererComponent(skill1TooltipText, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            tooltip1.CurrentAllignment = FontRendererComponent.Allignment.Center;
            tooltip1.DrawString(skillTooltips.ToolTips[skillTooltips.SkillIndexer[1]]);

            GameObject skill1LevelObj = new GameObject("Skill1LevelObj");
            skill1BgObj.AddChild(skill1LevelObj);
            skill1LevelObj.LocalPosition = new Point(158, 45);
            StaticSpriteRendererComponent skill1LeveSprite = new StaticSpriteRendererComponent(skill1LevelObj);
            skill1LeveSprite.AddSprite("Skill1LevelSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(99, 804, 46, 46));

            GameObject skill1LevelText = new GameObject("Skill1LevelText");
            skill1LevelObj.AddChild(skill1LevelText);
            skill1LevelText.LocalPosition = new Point(23, 10);
            FontRendererComponent skill1LvlTxt = new FontRendererComponent(skill1LevelText, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            skill1LvlTxt.DrawString(heroSkills.Skills[heroSkills.SkillIndexer[1]].ToString());
            skill1LvlTxt.CurrentAllignment = FontRendererComponent.Allignment.Center;

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
            skill2NameFnt.DrawString(heroSkills.SkillIndexer[2]); //insert hero skill 2

            GameObject skill2TooltipObj = new GameObject("Skill2TooltipObj");
            skill2BgObj.AddChild(skill2TooltipObj);
            skill2TooltipObj.Enabled = false;
            skill2TooltipObj.LocalPosition = new Point(-20, -50); //80,172 global
            StaticSpriteRendererComponent skill2TooltipSprite = new StaticSpriteRendererComponent(skill2TooltipObj);
            skill2TooltipSprite.AddSprite("Skill2TooltipSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(730, 3, 240, 117));

            GameObject skill2TooltipText = new GameObject("Skill2TooltipText");
            skill2TooltipObj.AddChild(skill2TooltipText);
            skill2TooltipText.LocalPosition = new Point(120, 5);
            FontRendererComponent tooltip2 = new FontRendererComponent(skill2TooltipText, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            tooltip2.CurrentAllignment = FontRendererComponent.Allignment.Center;
            tooltip2.DrawString(skillTooltips.ToolTips[skillTooltips.SkillIndexer[2]]);

            GameObject skill2LevelObj = new GameObject("Skill2LevelObj");
            skill2BgObj.AddChild(skill2LevelObj);
            skill2LevelObj.LocalPosition = new Point(158, 45);
            StaticSpriteRendererComponent skill2LeveSprite = new StaticSpriteRendererComponent(skill2LevelObj);
            skill2LeveSprite.AddSprite("Skill2LevelSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(99, 804, 46, 46));

            GameObject skill2LevelText = new GameObject("Skill2LevelText");
            skill2LevelObj.AddChild(skill2LevelText);
            skill2LevelText.LocalPosition = new Point(23, 10);
            FontRendererComponent skill2LvlTxt = new FontRendererComponent(skill2LevelText, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            skill2LvlTxt.DrawString(heroSkills.Skills[heroSkills.SkillIndexer[2]].ToString());
            skill2LvlTxt.CurrentAllignment = FontRendererComponent.Allignment.Center;

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
            skill3NameFnt.DrawString(heroSkills.SkillIndexer[3]); //insert hero skill 3

            GameObject skill3TooltipObj = new GameObject("Skill3TooltipObj");
            skill3BgObj.AddChild(skill3TooltipObj);
            skill3TooltipObj.Enabled = false;
            skill3TooltipObj.LocalPosition = new Point(-20, -55); //75,265 global
            StaticSpriteRendererComponent skill3TooltipSprite = new StaticSpriteRendererComponent(skill3TooltipObj);
            skill3TooltipSprite.AddSprite("Skill3TooltipSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(730, 3, 240, 117));

            GameObject skill3TooltipText = new GameObject("Skill3TooltipText");
            skill3TooltipObj.AddChild(skill3TooltipText);
            skill3TooltipText.LocalPosition = new Point(120, 8);
            FontRendererComponent tooltip3 = new FontRendererComponent(skill3TooltipText, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            tooltip3.CurrentAllignment = FontRendererComponent.Allignment.Center;
            tooltip3.DrawString(skillTooltips.ToolTips[skillTooltips.SkillIndexer[3]]);

            GameObject skill3LevelObj = new GameObject("Skill3LevelObj");
            skill3BgObj.AddChild(skill3LevelObj);
            skill3LevelObj.LocalPosition = new Point(158, 45);
            StaticSpriteRendererComponent skill3LeveSprite = new StaticSpriteRendererComponent(skill3LevelObj);
            skill3LeveSprite.AddSprite("Skill3LevelSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(99, 804, 46, 46));

            GameObject skill3LevelText = new GameObject("Skill3LevelText");
            skill3LevelObj.AddChild(skill3LevelText);
            skill3LevelText.LocalPosition = new Point(23, 10);
            FontRendererComponent skill3LvlTxt = new FontRendererComponent(skill3LevelText, "Assets/Font/22Fontsheet.png", "Assets/Font/22Fontsheet.fnt");
            skill3LvlTxt.DrawString(heroSkills.Skills[heroSkills.SkillIndexer[3]].ToString());
            skill3LvlTxt.CurrentAllignment = FontRendererComponent.Allignment.Center;

            ButtonComponent skill3 = new ButtonComponent(skill3LevelObj);
            skill3.DoHover += delegate {
                skill3TooltipObj.Enabled = true;
            };
            skill3.NoHover += delegate {
                skill3TooltipObj.Enabled = false;
            };

            ButtonComponent namePlateNext = new ButtonComponent(namePlateNextObj);
            namePlateNext.DoClick += delegate {
                if (namePlateNextSprite.CurrentSprite != "NamePlatenextSpriteClick") {
                    namePlateNextSprite.SetSprite("NamePlatenextSpriteClick");
                }
                //do logic to swap hero component and skills
                Heroes[CurrentHero].Enabled = false;
                CurrentHero++;
                if (CurrentHero > Heroes.Count - 1) {
                    CurrentHero = 0;
                }
                Heroes[CurrentHero].Enabled = true;
                heroNameFont.DrawString(Heroes[CurrentHero].Name); // CurrentHero.Name
                heroSkills = (HeroComponent)Heroes[CurrentHero].FindComponent("HeroComponent");
                skill1NameFnt.DrawString(heroSkills.SkillIndexer[1]);
                skill2NameFnt.DrawString(heroSkills.SkillIndexer[2]);
                skill3NameFnt.DrawString(heroSkills.SkillIndexer[3]);
                healthAmt = (HeroComponent)Heroes[CurrentHero].FindComponent("HeroComponent");
                healthAmtFnt.DrawString(healthAmt.Health.ToString());
                attackAmt = (HeroComponent)Heroes[CurrentHero].FindComponent("HeroComponent");
                attackAmtFnt.DrawString(attackAmt.Attack.ToString());
                skillTooltips = (HeroComponent)Heroes[CurrentHero].FindComponent("HeroComponent");
                tooltip1.DrawString(skillTooltips.ToolTips[skillTooltips.SkillIndexer[1]]);
                tooltip2.DrawString(skillTooltips.ToolTips[skillTooltips.SkillIndexer[2]]);
                tooltip3.DrawString(skillTooltips.ToolTips[skillTooltips.SkillIndexer[3]]);
                skill1LvlTxt.DrawString(heroSkills.Skills[heroSkills.SkillIndexer[1]].ToString());
                skill2LvlTxt.DrawString(heroSkills.Skills[heroSkills.SkillIndexer[2]].ToString());
                skill3LvlTxt.DrawString(heroSkills.Skills[heroSkills.SkillIndexer[3]].ToString());
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
                heroSkills = (HeroComponent)Heroes[CurrentHero].FindComponent("HeroComponent");
                skill1NameFnt.DrawString(heroSkills.SkillIndexer[1]);
                skill2NameFnt.DrawString(heroSkills.SkillIndexer[2]);
                skill3NameFnt.DrawString(heroSkills.SkillIndexer[3]);
                healthAmt = (HeroComponent)Heroes[CurrentHero].FindComponent("HeroComponent");
                healthAmtFnt.DrawString(healthAmt.Health.ToString());
                attackAmt = (HeroComponent)Heroes[CurrentHero].FindComponent("HeroComponent");
                attackAmtFnt.DrawString(attackAmt.Attack.ToString());
                skillTooltips = (HeroComponent)Heroes[CurrentHero].FindComponent("HeroComponent");
                tooltip1.DrawString(skillTooltips.ToolTips[skillTooltips.SkillIndexer[1]]);
                tooltip2.DrawString(skillTooltips.ToolTips[skillTooltips.SkillIndexer[2]]);
                tooltip3.DrawString(skillTooltips.ToolTips[skillTooltips.SkillIndexer[3]]);
                skill1LvlTxt.DrawString(heroSkills.Skills[heroSkills.SkillIndexer[1]].ToString());
                skill2LvlTxt.DrawString(heroSkills.Skills[heroSkills.SkillIndexer[2]].ToString());
                skill3LvlTxt.DrawString(heroSkills.Skills[heroSkills.SkillIndexer[3]].ToString());

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
        }//end update

        public override void Enter() {
            HeroComponent currentHeroComponent = null;
            GameObject currentHero = null;
            GameObject heroAttack = null;
            FontRendererComponent heroAttackFnt = null;
            GameObject heroHealth = null;
            FontRendererComponent heroHealthFnt = null;
            GameObject heroSkill1 = null;
            FontRendererComponent heroSkill1Fnt = null;
            GameObject heroSkill2 = null;
            FontRendererComponent heroSkill2Fnt = null;
            GameObject heroSkill3 = null;
            FontRendererComponent heroSkill3Fnt = null;
            GameObject currencyAmtObj = null;
            FontRendererComponent currencyAmt = null;
            //load last hero selected
            if (File.Exists("Assets/Data/CurrentHero.txt")) {
                using (TextReader reader = File.OpenText("Assets/Data/CurrentHero.txt")) {
                    CurrentHero = System.Convert.ToInt32(reader.ReadLine());
                    Monies = System.Convert.ToInt32(reader.ReadLine());
                }
            }//end if
            if (CurrentHero == 0) {
                currentHero = Root.FindChild("That Gai");
                currentHeroComponent = (HeroComponent)currentHero.FindComponent("HeroComponent");
            }
            else if (CurrentHero == 1) {
                currentHero = Root.FindChild("BoveMaster");
                currentHeroComponent = (HeroComponent)currentHero.FindComponent("HeroComponent");
            }
            else if (CurrentHero == 2) {
                currentHero = Root.FindChild("Sassy Calves");
                currentHeroComponent = (HeroComponent)currentHero.FindComponent("HeroComponent");
                GameObject petRockObj = currentHero.FindChild("PetRockObj");
                if (petRockObj != null) {
                    StaticSpriteRendererComponent petRock = (StaticSpriteRendererComponent)petRockObj.FindComponent("StaticSpriteRendererComponent");
                    if (currentHeroComponent.Skills[currentHeroComponent.SkillIndexer[2]] == 1) {
                        petRock.SetSprite("Pet Rock1");
                    }
                    else if (currentHeroComponent.Skills[currentHeroComponent.SkillIndexer[2]] == 2) {
                        petRock.SetSprite("Pet Rock2");
                    }
                    else if (currentHeroComponent.Skills[currentHeroComponent.SkillIndexer[2]] == 3) {
                        petRock.SetSprite("Pet Rock3");
                    }
                    else if (currentHeroComponent.Skills[currentHeroComponent.SkillIndexer[2]] >= 4) {
                        petRock.SetSprite("Pet Rock4");
                    }
                }
            }
            heroHealth = Root.FindChild("HealthIdentifierAmtObj");
            heroHealthFnt = (FontRendererComponent)heroHealth.FindComponent("FontRendererComponent");
            heroAttack = Root.FindChild("AttackIdentifierAmtObj");
            heroAttackFnt = (FontRendererComponent)heroAttack.FindComponent("FontRendererComponent");
            heroSkill1 = Root.FindChild("Skill1LevelText");
            heroSkill1Fnt = (FontRendererComponent)heroSkill1.FindComponent("FontRendererComponent");
            heroSkill2 = Root.FindChild("Skill2LevelText");
            heroSkill2Fnt = (FontRendererComponent)heroSkill2.FindComponent("FontRendererComponent");
            heroSkill3 = Root.FindChild("Skill3LevelText");
            heroSkill3Fnt = (FontRendererComponent)heroSkill3.FindComponent("FontRendererComponent");
            currencyAmtObj = Root.FindChild("CurrencyAmtObj");
            currencyAmt = (FontRendererComponent)currencyAmtObj.FindComponent("FontRendererComponent");
            if (File.Exists("Assets/Data/hero_" + CurrentHero + ".txt")) {
                using (TextReader reader = File.OpenText("Assets/Data/hero_" + CurrentHero + ".txt")) {
                    currentHeroComponent.Health = System.Convert.ToInt32(reader.ReadLine());
                    currentHeroComponent.Attack = System.Convert.ToInt32(reader.ReadLine());
                    reader.ReadLine();
                    reader.ReadLine();
                    reader.ReadLine();
                    currentHeroComponent.Skills[currentHeroComponent.SkillIndexer[1]] = System.Convert.ToInt32(reader.ReadLine());
                    currentHeroComponent.Skills[currentHeroComponent.SkillIndexer[2]] = System.Convert.ToInt32(reader.ReadLine());
                    currentHeroComponent.Skills[currentHeroComponent.SkillIndexer[3]] = System.Convert.ToInt32(reader.ReadLine());
                }
            }
            heroHealthFnt.DrawString(currentHeroComponent.Health.ToString());
            heroAttackFnt.DrawString(currentHeroComponent.Attack.ToString());
            heroSkill1Fnt.DrawString(currentHeroComponent.Skills[currentHeroComponent.SkillIndexer[1]].ToString());
            heroSkill2Fnt.DrawString(currentHeroComponent.Skills[currentHeroComponent.SkillIndexer[2]].ToString());
            heroSkill3Fnt.DrawString(currentHeroComponent.Skills[currentHeroComponent.SkillIndexer[3]].ToString());
            currencyAmt.DrawString(Monies.ToString());//insert currency variable here
        }

        public override void Exit() {
            GameObject currentHero = null;
            if(CurrentHero == 0) {
                currentHero = Root.FindChild("That Gai");
            }
            else if (CurrentHero == 1) {
                currentHero = Root.FindChild("BoveMaster");
            }
            else if (CurrentHero == 2) {
                currentHero = Root.FindChild("Sassy Calves");
            }
            HeroComponent currentHeroComp = (HeroComponent)currentHero.FindComponent("HeroComponent");
            using (StreamWriter writer = new StreamWriter("Assets/Data/CurrentHero.txt")) {
                writer.WriteLine(CurrentHero.ToString());
                writer.WriteLine(Monies.ToString());
            }
            using (StreamWriter writer = new StreamWriter("Assets/Data/hero_" + CurrentHero + ".txt")) {
                writer.WriteLine(currentHeroComp.Health);
                writer.WriteLine(currentHeroComp.Attack);
                writer.WriteLine(currentHeroComp.SkillIndexer[1]);
                writer.WriteLine(currentHeroComp.SkillIndexer[2]);
                writer.WriteLine(currentHeroComp.SkillIndexer[3]);
                writer.WriteLine(currentHeroComp.Skills[currentHeroComp.SkillIndexer[1]]);
                writer.WriteLine(currentHeroComp.Skills[currentHeroComp.SkillIndexer[2]]);
                writer.WriteLine(currentHeroComp.Skills[currentHeroComp.SkillIndexer[3]]);

            }
        }
    }
}
