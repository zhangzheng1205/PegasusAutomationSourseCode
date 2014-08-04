using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SIMStudyPlan;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles SIMStudyPlanDefaultUX Page Actions.
    /// </summary>
    public class SIMStudyPlanDefaultUXPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(TeachingPlanUxPage));

        /// <summary>
        /// Edit Sim Study plan.
        /// </summary>
        ///  <param name="testType">Sim Study plan Test type.</param>
        public void EditSimStudyPlan(string testType)
        {
            //Edit Study plan
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage", "EditSimStudyPlan",
                                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Window
                base.WaitUntilWindowLoads(SIMStudyPlanDefaultUXPageResource.
                    SIMStudyPlanDefaultUX_Page_WindowName);
                //Navigate 'Build Study Plan' sub tab
                NavigateToSubTabs(SIMStudyPlanDefaultUXPageResource.
                    SIMStudyPlanDefaultUX_Page_Build_Study_Plan_Tab_Id);
                //Click on PreTest Contextual Menu 
                this.ClickContextualMenu(testType);
                //Click on Contextual Menu Edit option
                ClickContextualMenuOption(SIMStudyPlanDefaultUXPageResource.
                    SIMStudyPlanDefaultUX_Page_ContextualMenu_EditOption_Id);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("SIMStudyPlanDefaultUXPage", "EditSimStudyPlan",
                                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Subtabs in Sim Study Plan.
        /// </summary>
        /// <param name="subtabId">This is Subtab Name.</param>
        private void NavigateToSubTabs(string subtabId)
        {
            //Navigate to Subtabs
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
               "NavigateToSubTabs", base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(subtabId));
            //Focus on Element
            base.FocusOnElementById(subtabId);
            //Click on Subtab
            IWebElement getSubTabName = base.GetWebElementPropertiesById(subtabId);
            base.ClickByJavaScriptExecutor(getSubTabName);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "NavigateToSubTabs", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Contextual Menu. 
        /// </summary>
        /// <param name="testType">Sim Study plan Test type.</param>
        private void ClickContextualMenu(string testType)
        {
            //Click on PreTest Contextual Menu. 
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
              "ClickContextualMenu", base.IsTakeScreenShotDuringEntryExit);
            string getXpathContextualMenu;
            if (testType == SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_PreTest)
            {
                //Xpath for Pre test Contextual Menu.
                getXpathContextualMenu = SIMStudyPlanDefaultUXPageResource.
                   SIMStudyPlanDefaultUX_Page_PreTest_ContextualMenu_Icon_XPath_Locator;
            }
            else
            {
                //Xpath for Post test Contextual Menu.
                getXpathContextualMenu = SIMStudyPlanDefaultUXPageResource.
                 SIMStudyPlanDefaultUX_Page_PostTest_ContextualMenu_Icon_XPath_Locator;
            }
            //Wait For Element
            WaitForElement(By.XPath(getXpathContextualMenu));
            base.FocusOnElementByXPath(getXpathContextualMenu);
            //Click on Contextual Menu
            IWebElement getContextualMenue =
                base.GetWebElementPropertiesByXPath(getXpathContextualMenu);
            base.ClickByJavaScriptExecutor(getContextualMenue);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
              "ClickContextualMenu", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on PreTest Contextual Menu Option. 
        /// </summary>
        ///<param name="cmenuOptionId">Contextual Menu option</param>
        private void ClickContextualMenuOption(string cmenuOptionId)
        {

            //Click on PreTest Contextual Menu Option. 
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
             "ClickContextualMenuOption", base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            WaitForElement(By.Id(cmenuOptionId));
            //Focus on Element
            base.FocusOnElementById(cmenuOptionId);
            //Click on Contextual Menu
            IWebElement getContextualMenueOption =
                base.GetWebElementPropertiesById(cmenuOptionId);
            base.ClickByJavaScriptExecutor(getContextualMenueOption);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "ClickContextualMenuOption", base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Create SIM StudyPlan.
        /// </summary>
        /// <param name="activityTypeEnum">This is ActivityType Enum.</param>
        /// <param name="behavioralModeEnum">This is BehavioralMode Enum.</param>
        public void CreateSIMStudyPlan(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create SIM StudyPlan
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
             "CreateSIMStudyPlan", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                ContentBrowserUXPage contentBrowserUXPage = new ContentBrowserUXPage();
                //Create SIMStudyPlan Using SIMQuestions
                this.CreateSIM5StudyPlanUsingSIMQuestions(
                    activityTypeEnum,behavioralModeEnum);                             
                //Click On Add Question Link
                new RandomTopicListPage().ClickOnAddQuestionLink();
                //Search the question
                contentBrowserUXPage.SearchTheQuestionInSelectQuestionWindow
                     (SIMStudyPlanDefaultUXPageResource.
                     SIMStudyPlanDefaultUX_Page_XL_Question_Name);
                //Select Pretest Window
                this.SelectCreatePretestWindow();  
                //Click On Save And Return
                this.ClickOnSaveAndReturn(behavioralModeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "CreateSIMStudyPlan", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create SIM5StudyPlan Using SIMQuestions.
        /// </summary>
        /// <param name="activityTypeEnum">This is ActivityType Enum.</param>
        /// <param name="behavioralModeEnum">This is BehavioralMode Enum.</param>
        private void CreateSIM5StudyPlanUsingSIMQuestions(
            Activity.ActivityTypeEnum activityTypeEnum,
                  Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create SIM5StudyPlan Using SIMQuestions
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
            "CreateSIM5StudyPlanUsingSIMQuestions", base.IsTakeScreenShotDuringEntryExit);
            //Generate GUID For Studyplan Name
            Guid studyplanName = Guid.NewGuid();
            ContentBrowserUXPage contentBrowserUXPage = new ContentBrowserUXPage();
            //Select Studyplan Window
            this.SelectStudyplanWindow();
            //Enter Studyplan Name And Click On Create Test
            this.EnterStudyplanNameAndClickOnCreateTest(studyplanName);
            //Store SIM Studyplan
            new AddAssessmentPage().StoreActivityDetails(activityTypeEnum,
                behavioralModeEnum, studyplanName.ToString());
            //Generate GUID For Pretest Name
            Guid pretestName = Guid.NewGuid();
            //Select Pretest Window
            this.SelectCreatePretestWindow();
            //Enter Pretest Name And Select Skill based Radiobutton
            this.EnterPretestNameAndSelectBehavioralModeTypeRadiobutton(
                pretestName,behavioralModeEnum);
            //Store Pretest Details
            this.StorePretestDetails(pretestName);  
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
              "CreateSIM5StudyPlanUsingSIMQuestions", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The SIM Questions.
        /// </summary>
        private void SearchTheSIMQuestions(
                       Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Search The SIM Questions
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
              "SearchTheSIMQuestions", base.IsTakeScreenShotDuringEntryExit);
            //Click On Add Question Link
            new RandomTopicListPage().ClickOnAddQuestionLink();
            //Select the Question Type
            new SkillBasedAssessmentPage().SelectTheQuestionType(
                SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_Select_QuestionType);
            switch (behavioralModeEnum)
            {
                case Activity.ActivityBehavioralModesEnum.SkillBased:
                    //Search the Question
                    new ContentBrowserUXPage().SearchTheQuestionInSelectQuestionWindow(
                        SIMStudyPlanDefaultUXPageResource.
                        SIMStudyPlanDefaultUX_Page_Search_QuestionName);
                    //Select Create Pretest Window
                    this.SelectCreatePretestWindow();
                    break;
                case Activity.ActivityBehavioralModesEnum.DocBased:
                    Question question = Question.Get(
                        Question.QuestionTypeEnum.SIM2010WordQuestionSet);
                    //Search the question
                    new ContentBrowserUXPage().SelectQuestion(question.Name);
                    //Select Pretest Window
                    this.SelectPreTestWindow();
                    break;
            }
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "SearchTheSIMQuestions", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create PreTest StudyPlan.
        /// </summary>
        /// <param name="behavioralModeEnum">This is Behavioral Mode Type.</param>
        private void CreatePreTestStudyPlan(
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create PreTest StudyPlan
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
              "CreatePreTestStudyPlan", base.IsTakeScreenShotDuringEntryExit);
            //Generate GUID For Pretest Name
            Guid pretestName = Guid.NewGuid();
            //Select Pretest Window
            this.SelectCreatePretestWindow();
            //Enter Pretest Name And Select Skill based Radiobutton
            this.EnterPretestNameAndSelectBehavioralModeTypeRadiobutton(
                pretestName,behavioralModeEnum);
            //Store Pretest Details
            this.StorePretestDetails(pretestName);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "CreatePreTestStudyPlan", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Pretest Details In Memory.
        /// </summary>
        /// <param name="pretestName">This is Pretest Name.</param>
        private void StorePretestDetails(Guid pretestName)
        {
            //Store Pretest Details In Memory
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
            "StorePretestDetails", base.IsTakeScreenShotDuringEntryExit);
            //Store the Pretest in memory
            Activity newPreTest = new Activity
            {
                Name = pretestName.ToString(),
                ActivityType = Activity.ActivityTypeEnum.Sim5PreTest,
                IsCreated = true,
            };
            newPreTest.StoreActivityInMemory();
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "StorePretestDetails", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save And Return.
        /// </summary>
        public void ClickOnSaveAndReturn(
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Click On Save And Return
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
            "ClickOnSaveAndReturn", base.IsTakeScreenShotDuringEntryExit); 
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveReturn_Id_Locator));
            //Get web element
            IWebElement getSaveReturnButton = base.GetWebElementPropertiesById
                (SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveReturn_Id_Locator);
            //Click On Save and Return
            base.ClickByJavaScriptExecutor(getSaveReturnButton);
            //Select Studyplan Window
            this.SelectStudyplanWindow();    
            //Wait for the element
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveAndReturn_Id_Locator));
            IWebElement getSaveButton = base.GetWebElementPropertiesById
                (SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveAndReturn_Id_Locator);
            //Click On Save And Return
            base.ClickByJavaScriptExecutor(getSaveButton);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "ClickOnSaveAndReturn", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Pretest Name And Select Skillbased Radiobutton.
        /// </summary>
        /// <param name="pretestName">This is Pretest Name.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode Type.</param>
        private void EnterPretestNameAndSelectBehavioralModeTypeRadiobutton(Guid pretestName, 
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Enter Pretest Name And Select Skillbased Radiobutton 
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
             "EnterPretestNameAndSelectSkillbasedRadiobutton",
             base.IsTakeScreenShotDuringEntryExit);            
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_AvtivityName_Text_Id_Locator));
            //Enter Pretest Name
            base.FillTextBoxById(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_AvtivityName_Text_Id_Locator,
                pretestName.ToString());
            switch (behavioralModeEnum)
            {
                case Activity.ActivityBehavioralModesEnum.SkillBased:
                    //Selct SkillBased Reedio button
                    this.SelectSkillBasedBehavioralMode();
                    break;
                case Activity.ActivityBehavioralModesEnum.DocBased:
                    //Selct DocBased Reedio button
                    this.SelectDocumnetBasedBehavioralMode();
                    break;
            }
            //Click on Save And Continue Button
            this.ClickOnSaveAndContinueButton();            
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "EnterPretestNameAndSelectSkillbasedRadiobutton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save And Continue Button.
        /// </summary>
        private void ClickOnSaveAndContinueButton()
        {
            //Click on Save And Continue Button
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
                "ClickOnSaveAndContinueButton",
                      base.IsTakeScreenShotDuringEntryExit); 
            //Wait for the element
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveAndContinue_Id_Locator));
            IWebElement getSaveContinueButton = base.GetWebElementPropertiesById
                (SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveAndContinue_Id_Locator);
            //Click On Save And Continue
            base.ClickByJavaScriptExecutor(getSaveContinueButton);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "ClickOnSaveAndContinueButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select DocumentBased Behavioral Mode.
        /// </summary>
        private void SelectDocumnetBasedBehavioralMode()
        {
            //Select DocumentBased Behavioral Mode
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage", 
                "SelectDocumnetBasedBehavioralMode",
                      base.IsTakeScreenShotDuringEntryExit);    
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                   SIMStudyPlanDefaultUX_Page_Docbased_Radiobutton_Id_Locator));
            //Select Skill Based Radiobutton
            base.SelectRadioButtonById(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_Docbased_Radiobutton_Id_Locator);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "SelectDocumnetBasedBehavioralMode",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select SkillBased Behavioral Mode.
        /// </summary>
        private void SelectSkillBasedBehavioralMode()
        {
            //Select SkillBased Behavioral Mode
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage", 
                "SelectSkillBasedBehavioralMode",
                    base.IsTakeScreenShotDuringEntryExit);    
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                  SIMStudyPlanDefaultUX_Page_Skillbased_Radiobutton_Id_Locator));
            //Select Skill Based Radiobutton
            base.SelectRadioButtonById(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_Skillbased_Radiobutton_Id_Locator);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "SelectSkillBasedBehavioralMode",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Pretest Window.
        /// </summary>
        private void SelectCreatePretestWindow()
        {
            //Select Pretest Window
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
                "SelectCreatePretestWindow",
             base.IsTakeScreenShotDuringEntryExit);            
            base.WaitUntilWindowLoads(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_Create_Pretest_Window_Name);
            //Select Window
            base.SelectWindow(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_Create_Pretest_Window_Name);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage", 
                "SelectCreatePretestWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Studyplan Name And Click On Create Test.
        /// </summary>
        /// <param name="studyplanName">This is Studyplan Name.</param>
        private void EnterStudyplanNameAndClickOnCreateTest(Guid studyplanName)
        {
            //Enter Studyplan Name And Click On Create Test
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
                "EnterStudyplanNameAndClickOnCreateTest",
             base.IsTakeScreenShotDuringEntryExit);            
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_Studyplan_Name_Textbox_Name_Id_Locator));
            //Enter Studyplan Name
            base.FillTextBoxById(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_Studyplan_Name_Textbox_Name_Id_Locator,
                studyplanName.ToString());            
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveContinue_Button_Id_Locator));
            //Click On Save And Continue
            base.ClickButtonById(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveContinue_Button_Id_Locator);            
            base.WaitForElement(By.XPath(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_CreateTest_Link_Xpath_Locator));
            //Click On Create Test Link
            base.ClickLinkByXPath(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_CreateTest_Link_Xpath_Locator);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
                "EnterStudyplanNameAndClickOnCreateTest",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Studyplan Window.
        /// </summary>
        private void SelectStudyplanWindow()
        {
            //Select Studyplan Window
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage", "SelectStudyplanWindow",
             base.IsTakeScreenShotDuringEntryExit);            
            base.WaitUntilWindowLoads(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_WindowName);
            //Select Window
            base.SelectWindow(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_WindowName);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage", "SelectStudyplanWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create SIMStudyPlan Using SIMQuestions.
        /// </summary>
        /// <param name="activityTypeEnum">This is ActivityType Enum.</param>
        /// <param name="behavioralModeEnum">This is BehavioralMode Enum.</param>
        public void CreateSIMStudyPlanUsingSIMQuestions(
            Activity.ActivityTypeEnum activityTypeEnum,
                  Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create SIMStudyPlan Using SIMQuestions
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
            "CreateSIMStudyPlanUsingSIMQuestions", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generate GUID For Studyplan Name
                Guid studyplanName = Guid.NewGuid();
                ContentBrowserUXPage contentBrowserUXPage = new ContentBrowserUXPage();
                //Select Studyplan Window
                this.SelectStudyplanWindow();
                //Enter Studyplan Name And Click On Create Test
                this.EnterStudyplanNameAndClickOnCreateTest(studyplanName);
                //Store SIM Studyplan
                new AddAssessmentPage().StoreActivityDetails(activityTypeEnum,
                    behavioralModeEnum, studyplanName.ToString());
                //Click On Add And Close Button
                new ContentBrowserUXPage().ClickOnAddAndCloseButton();
                //Create Pretest
                this.CreatePreTestStudyPlan(behavioralModeEnum);
                //Search The SIM Questions
                this.SearchTheSIMQuestions(behavioralModeEnum);
                //Click On Save And Return
                new SIMStudyPlanDefaultUXPage().ClickOnSaveAndReturn(behavioralModeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "CreateSIMStudyPlanUsingSIMQuestions", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Pretest Window.
        /// </summary>
        private void SelectPreTestWindow()
        {
            //Select Pretest Window
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage", "SelectPretestWindow",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_Pretest_Window_Name);
            //Select Pre Test Window
            base.SelectWindow(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_Pretest_Window_Name);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage", "SelectPretestWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select And Select SIM 2007 Questions
        /// </summary>
        private void SearchAndSelectTheSIM2007Questions()
        {
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
             "SearchAndSelectTheSIM2007Questions", base.IsTakeScreenShotDuringEntryExit);
            //Click On Add Question Link
            new RandomTopicListPage().ClickOnAddQuestionLink();
            //Select the Question Type
            new SkillBasedAssessmentPage().SelectTheQuestionType(
                SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_Select_QuestionType);
            //Search the Question
            new ContentBrowserUXPage().SearchTheQuestionInSelectQuestionWindow(
                SIMStudyPlanDefaultUXPageResource.SIMStudyPlanDefaultUX_Page_SIM2007_Question_Name);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage", "SearchAndSelectTheSIM2007Questions",
               base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select Save And Return In Create Pre Test Window
        /// </summary>
        private void ClickOnSaveAndReturnInCreatePreTestWindow()
        {
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
             "ClickOnSaveAndReturnInCreatePreTestWindow", base.IsTakeScreenShotDuringEntryExit);
            //Select Create PreTest Window
            this.SelectCreatePretestWindow();
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveReturn_Id_Locator));
            //Get web element
            IWebElement getSaveReturnButton = base.GetWebElementPropertiesById
                (SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveReturn_Id_Locator);
            //Click On Save and Return
            base.ClickByJavaScriptExecutor(getSaveReturnButton);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage", "ClickOnSaveAndReturnInCreatePreTestWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Click On Post Test Creation Test Button
        /// </summary>
        private void ClickOnPostTestCreateTestButton()
        {
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
            "ClickOnPostTestCreateTestButton", base.IsTakeScreenShotDuringEntryExit);
            //Click On Post Test Creation Test Button
            base.WaitForElement(By.ClassName(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_CreatePostTest_ClassName_Locator));
            //Get Create Post Test Button
            IWebElement getCreateTestProperty = base.GetWebElementPropertiesByClassName(
                SIMStudyPlanDefaultUXPageResource.SIMStudyPlanDefaultUX_Page_CreatePostTest_ClassName_Locator);
            //Click On Create Post Test Button
            base.ClickByJavaScriptExecutor(getCreateTestProperty);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage", "ClickOnPostTestCreateTestButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Post Test Window
        /// </summary>
        private void SelectPostTestWindow()
        {
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage","SelectPostTestWindow", 
                base.IsTakeScreenShotDuringEntryExit);
            //Select Post Test Window
            base.WaitUntilWindowLoads(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_CreatePostTest_Window_Name);
            base.SelectWindow(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_CreatePostTest_Window_Name);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage", "SelectPostTestWindow",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Posttest Name And Select Skillbased Radiobutton.
        /// </summary>
        /// <param name="posttestName">This is Postest Name.</param>
        private void EnterPosttestNameAndSelectSkillbasedRadiobutton(Guid posttestName)
        {
            //Enter Posttest Name And Select Skillbased Radiobutton 
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
             "EnterPosttestNameAndSelectSkillbasedRadiobutton",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_AvtivityName_Text_Id_Locator));
            //Enter Posttest Name
            base.FillTextBoxById(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_AvtivityName_Text_Id_Locator,
                posttestName.ToString());
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_Skillbased_Radiobutton_Id_Locator));
            //Select Skill Based Radiobutton
            base.SelectRadioButtonById(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_Skillbased_Radiobutton_Id_Locator);
            //Wait for the element
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveAndContinue_Id_Locator));
            //Get Save And Continue Button Property
            IWebElement getSaveContinueButton = base.GetWebElementPropertiesById
                (SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveAndContinue_Id_Locator);
            //Click On Save And Continue
            base.ClickByJavaScriptExecutor(getSaveContinueButton);
            this.StorePosttestDetails(posttestName);
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "EnterPosttestNameAndSelectSkillbasedRadiobutton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save And Return In Create Post Test Window
        /// </summary>
        private void ClickOnSaveAndReturnInCreatePostTestWindow()
        {
            //Click On Save And Return In Create Post Test Window
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
             "ClickOnSaveAndReturnInCreatePostTestWindow",
             base.IsTakeScreenShotDuringEntryExit);
            //Select Post Test Window
            this.SelectPostTestWindow();
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveReturn_Id_Locator));
            //Get Save And Return Button Property
            IWebElement getSaveReturnButton = base.GetWebElementPropertiesById
                (SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveReturn_Id_Locator);
            //Click On Save and Return
            base.ClickByJavaScriptExecutor(getSaveReturnButton);
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
             "ClickOnSaveAndReturnInCreatePostTestWindow",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save And Return In Add MyitLab Study Plan Window
        /// </summary>
        private void ClickOnSaveAndReturnInAddmyitLabStudyPlanWindow()
        {
            //Click On Save And Return In Add MyitLab Study Plan Window
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
             "ClickOnSaveAndReturnInAddmyitLabStudyPlanWindow",
             base.IsTakeScreenShotDuringEntryExit);
            //Select Studyplan Window
            this.SelectStudyplanWindow();
            //Wait for the element
            base.WaitForElement(By.Id(SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveAndReturn_Id_Locator));
            IWebElement getSaveButton = base.GetWebElementPropertiesById
                (SIMStudyPlanDefaultUXPageResource.
                SIMStudyPlanDefaultUX_Page_SaveAndReturn_Id_Locator);
            //Click On Save And Return
            base.ClickByJavaScriptExecutor(getSaveButton);
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
            "ClickOnSaveAndReturnInAddmyitLabStudyPlanWindow",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create SIM Study Plan Using 2007 SIM Questions
        /// </summary>
        /// <param name="activityTypeEnum">This is activity Type Enum</param>
        /// <param name="behavioralModeEnum">This is behavioral Mode Enum</param>
        public void CreateSIMStudyPlanUsing2007SIMQuestions(Activity.ActivityTypeEnum activityTypeEnum,
                  Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create SIM Study Plan Using 2007 SIM Questions
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
            "CreateSIMStudyPlanUsing2007SIMQuestions",
            base.IsTakeScreenShotDuringEntryExit);
            Guid studyplanName = Guid.NewGuid();
            //Generate GUID For Pretest Name
            Guid posttestName = Guid.NewGuid();
            ContentBrowserUXPage contentBrowserUXPage = new ContentBrowserUXPage();
            try
            {
                //Select Study Plan Window
                this.SelectStudyplanWindow();
                //Enter Studyplan Name And Click On Create Test
                this.EnterStudyplanNameAndClickOnCreateTest(studyplanName);
                //Store SIM Studyplan
                new AddAssessmentPage().StoreActivityDetails(activityTypeEnum,
                    behavioralModeEnum, studyplanName.ToString());
                //Click On Add And Close Button
                new ContentBrowserUXPage().ClickOnAddAndCloseButton();
                //Create Pretest
                this.CreatePreTestStudyPlan(behavioralModeEnum);
                //Search SIM 2007 Questions
                this.SearchAndSelectTheSIM2007Questions();
                //Click On Save And Return
                this.ClickOnSaveAndReturnInCreatePreTestWindow();
                //Select Study Plan Window
                this.SelectStudyplanWindow();
                //Click On Post Test Create Test Button
                this.ClickOnPostTestCreateTestButton();
                //Select Post Test Window
                this.SelectPostTestWindow();
                //Enter Post Test Name and Select Skill Based
                this.EnterPosttestNameAndSelectSkillbasedRadiobutton(posttestName);
                //Search the SIM 2007 Questions
                this.SearchAndSelectTheSIM2007Questions();
                //Click On Save and Return Button In Create Post Test Window
                this.ClickOnSaveAndReturnInCreatePostTestWindow();
                //Click On Save And Return Button In Add MyitLab Study Plan Window
                this.ClickOnSaveAndReturnInAddmyitLabStudyPlanWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
            "CreateSIMStudyPlanUsing2007SIMQuestions",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Store Posttest Details In Memory.
        /// </summary>
        /// <param name="PosttestName">This is Posttest Name.</param>
        private void StorePosttestDetails(Guid posttestName)
        {
            //Store Posttest Details In Memory
            logger.LogMethodEntry("SIMStudyPlanDefaultUXPage",
            "StorePretestDetails", base.IsTakeScreenShotDuringEntryExit);
            //Store the Posttest in memory
            Activity newPostTest = new Activity
            {
                Name = posttestName.ToString(),
                ActivityType = Activity.ActivityTypeEnum.Sim5PostTest,
                IsCreated = true,
            };
            newPostTest.StoreActivityInMemory();
            logger.LogMethodExit("SIMStudyPlanDefaultUXPage",
               "StorePretestDetails", base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
