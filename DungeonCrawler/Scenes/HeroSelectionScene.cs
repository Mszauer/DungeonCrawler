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

            GameObject currencyAmtObj = new GameObject("CurrencyAmtObj");
            currency.AddChild(currencyAmtObj);
            currencyAmtObj.LocalPosition = new Point(90, 9);
            FontRendererComponent currencyAmt = new FontRendererComponent(currencyAmtObj, "Assets/Font/14Fontsheet.png", "Assets/Font/14Fontsheet.fnt");
            currencyAmt.DrawString("0");//insert currency variable here

            //Back button
            GameObject backButton = new GameObject("BackButton");
            Root.AddChild(backButton);
            backButton.LocalPosition = new Point(10, 423);
            StaticSpriteRendererComponent back = new StaticSpriteRendererComponent(backButton);
            back.AddSprite("BackDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 181, 46, 46));
            back.AddSprite("BackHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 227, 46, 46));
            back.AddSprite("BackHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 273, 46, 46));
            back.AddSprite("BackClick", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 319, 46, 46));

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
            healthLevelSprite.AddSprite("HeslthLevelSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(948, 351, 36, 36));

            GameObject healthAmtObj = new GameObject("HealthIdentifierAmtObj");
            healthObj.AddChild(healthAmtObj);
            healthAmtObj.LocalPosition = new Point(23, 41);
            FontRendererComponent healthAmtFnt = new FontRendererComponent(healthAmtObj, "Assets/font/14Fontsheet.png", "Assets/Font/14Fontsheet.fnt");
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
            attackLevelSprite.AddSprite("AttackLevelSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(948,351,36,36));

            GameObject attackAmtObj = new GameObject("HealthIdentifierAmtObj");
            attackObj.AddChild(attackAmtObj);
            attackAmtObj.LocalPosition = new Point(23, 41);
            FontRendererComponent attackAmtFnt = new FontRendererComponent(attackAmtObj, "Assets/font/14Fontsheet.png", "Assets/Font/14Fontsheet.fnt");
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
            heroNameObj.LocalPosition = new Point(70, 5);
            FontRendererComponent heroNameFont = new FontRendererComponent(heroNameObj, "Assets/Font/42Fontsheet.png", "Assets/Font/42Fontsheet.fnt");
            heroNameFont.DrawString("That Gai"); // insert CurrentHero.Name here

            //name plate prev button
            GameObject namePlatePrevObj = new GameObject("NamePlatePrevObj");
            namePlateObj.AddChild(namePlatePrevObj);
            namePlatePrevObj.LocalPosition = new Point(2, 5);
            StaticSpriteRendererComponent namePlatePrevSprite = new StaticSpriteRendererComponent(namePlatePrevObj);
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 723, 46, 46));
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 769, 46, 46));
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 811, 46, 46));
            namePlatePrevSprite.AddSprite("NamePlatePrevSpriteClick", "Assets/ObjectSpriteSheet.png", new Rectangle(982, 858, 46, 46));

            //name plate next button
            GameObject namePlateNextObj = new GameObject("NamePlateNextObj");
            namePlateObj.AddChild(namePlateNextObj);
            namePlateNextObj.LocalPosition = new Point(237, 5);
            StaticSpriteRendererComponent namePlateNextSprite = new StaticSpriteRendererComponent(namePlateNextObj);
            namePlateNextSprite.AddSprite("NamePlatenextSpriteDefault", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 543, 46, 46));
            namePlateNextSprite.AddSprite("NamePlatenextSpriteHover1", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 587, 46, 46));
            namePlateNextSprite.AddSprite("NamePlatenextSpriteHover2", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 632, 46, 46));
            namePlateNextSprite.AddSprite("NamePlatenextSpriteClick", "Assets/ObjectSpriteSheet.png", new Rectangle(983, 678, 46, 46));

            //tree stump
            GameObject treeStumpObj = new GameObject("TreeStumpObj");
            Root.AddChild(treeStumpObj);
            treeStumpObj.LocalPosition = new Point(0,335);
            StaticSpriteRendererComponent treeStumpSprite = new StaticSpriteRendererComponent(treeStumpObj);
            treeStumpSprite.AddSprite("TreeStumpSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(244, 904, 112, 85));

            //skill 1
            GameObject skill1BgObj = new GameObject("Skill1BgObj");
            Root.AddChild(skill1BgObj);
            skill1BgObj.LocalPosition = new Point(100, 130);
            StaticSpriteRendererComponent skill1BgSprite = new StaticSpriteRendererComponent(skill1BgObj);
            skill1BgSprite.AddSprite("Skill1BgSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(528, 105, 189, 61));

            GameObject skill1LevelObj = new GameObject("Skill1LevelObj");
            skill1BgObj.AddChild(skill1LevelObj);
            skill1LevelObj.LocalPosition = new Point(158, 45);
            StaticSpriteRendererComponent skill1LeveSprite = new StaticSpriteRendererComponent(skill1LevelObj);
            skill1LeveSprite.AddSprite("Skill1LevelSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(99, 804, 46, 46));

            GameObject skill1TooltipObj = new GameObject("Skill1TooltipObj");
            skill1BgObj.AddChild(skill1TooltipObj);
            skill1TooltipObj.Enabled = false;
            skill1TooltipObj.LocalPosition = new Point(-20, -50); //75,80 global
            StaticSpriteRendererComponent skill1TooltipSprite = new StaticSpriteRendererComponent(skill1TooltipObj);
            skill1TooltipSprite.AddSprite("Skill1TooltipSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(730, 3, 240, 117));

            //skill 2
            GameObject skill2BgObj = new GameObject("Skill2BgObj");
            Root.AddChild(skill2BgObj);
            skill2BgObj.LocalPosition = new Point(100, 225);
            StaticSpriteRendererComponent skill2BgSprite = new StaticSpriteRendererComponent(skill2BgObj);
            skill2BgSprite.AddSprite("Skill2BgSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(528, 105, 189, 61));

            GameObject skill2LevelObj = new GameObject("Skill2LevelObj");
            skill2BgObj.AddChild(skill2LevelObj);
            skill2LevelObj.LocalPosition = new Point(158, 45);
            StaticSpriteRendererComponent skill2LeveSprite = new StaticSpriteRendererComponent(skill2LevelObj);
            skill2LeveSprite.AddSprite("Skill2LevelSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(99, 804, 46, 46));

            GameObject skill2TooltipObj = new GameObject("Skill2TooltipObj");
            skill2BgObj.AddChild(skill2TooltipObj);
            skill2TooltipObj.Enabled = false;
            skill2TooltipObj.LocalPosition = new Point(-20, -50); //80,172 global
            StaticSpriteRendererComponent skill2TooltipSprite = new StaticSpriteRendererComponent(skill2TooltipObj);
            skill2TooltipSprite.AddSprite("Skill2TooltipSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(730, 3, 240, 117));

            //skill 3
            GameObject skill3BgObj = new GameObject("Skill3BgObj");
            Root.AddChild(skill3BgObj);
            skill3BgObj.LocalPosition = new Point(100, 320);
            StaticSpriteRendererComponent skill3BgSprite = new StaticSpriteRendererComponent(skill3BgObj);
            skill3BgSprite.AddSprite("Skill3BgSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(528, 105, 189, 61));

            GameObject skill3LevelObj = new GameObject("Skill3LevelObj");
            skill3BgObj.AddChild(skill3LevelObj);
            skill3LevelObj.LocalPosition = new Point(158, 45);
            StaticSpriteRendererComponent skill3LeveSprite = new StaticSpriteRendererComponent(skill3LevelObj);
            skill3LeveSprite.AddSprite("Skill3LevelSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(99, 804, 46, 46));

            GameObject skill3TooltipObj = new GameObject("Skill3TooltipObj");
            skill3BgObj.AddChild(skill3TooltipObj);
            skill3TooltipObj.Enabled = false;
            skill3TooltipObj.LocalPosition = new Point(-20, -55); //75,265 global
            StaticSpriteRendererComponent skill3TooltipSprite = new StaticSpriteRendererComponent(skill3TooltipObj);
            skill3TooltipSprite.AddSprite("Skill3TooltipSprite", "Assets/ObjectSpriteSheet.png", new Rectangle(730, 3, 240, 117));

            /*
            //hero
            GameObject heroAnimObj = new GameObject("heroAnimObj");
            Root.AddChild(heroAnimObj);
            heroAnimObj.LocalPosition = new Point(0,150);
            AnimatedSpriteRendererComponent heroAnimation = new AnimatedSpriteRendererComponent(heroAnimObj);
            heroAnimation.AddAnimation("Idle", "Assets/DarkKnight2/DarkKnight2_Idle.png", new Rectangle(0, 768, 256, 256), new Rectangle(256, 768, 256, 256), new Rectangle(512, 768, 256, 256), new Rectangle(768, 768, 256, 256), new Rectangle(0, 512, 256, 256), new Rectangle(256, 512, 256, 256), new Rectangle(512, 512, 256, 256), new Rectangle(768, 512, 256, 256), new Rectangle(0, 256, 256, 256), new Rectangle(256, 256, 256, 256));
            heroAnimation.PlayAnimation("Idle");
            */
        }
    }
}
