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
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles SkillBasedAssessmentPage Page Actions.
    /// </summary>

    public class SkillBasedAssessmentPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(SkillBasedAssessmentPage));

        /// <summary>
        /// Validate Visibilty Questions Tab for Skill Based Activity.  
        /// </summary>
        public bool isQuestionsTabVisibile()
        {
            bool isQuestionTabsDisplayed = false;
            try
            {
                // Validate Visibilty Questions Tab for Skill Based Activity
                logger.LogMethodEntry("SkillBasedAssessmentPage",
                    "isQuestionsTabVisibile",
                    base.isTakeScreenShotDuringEntryExit);
                //Wait for the Window
                base.WaitUntilWindowLoads(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_WindowName);
                //Validate Visibilty Questions Tab
                isQuestionTabsDisplayed = base.IsElementPresent(By.Id(
                 SkillBasedAssessmentResource.SkillBasedAssessment_Page_QuestionsTab_ID),
                Convert.ToInt16(SkillBasedAssessmentResource.
                SkillBasedAssessment_Page_Custom_Wait_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "isQuestionsTabVisibile",
                base.isTakeScreenShotDuringEntryExit);
            return isQuestionTabsDisplayed;
        }

        /// <summary>
        /// Validate Visibilty Questions Tab for Skill Based Sim Study plan. 
        /// </summary>
        /// <param name="testType">This is Test type in Sim Study plan .</param>
        public bool isQuestionsTabVisibileInSimStudyPlan(string testType)
        {
            bool isQuestionTabsDisplayed = false;
            try
            {
                // Validate Visibilty Questions Tab for  Skill Based Sim Study plan
                logger.LogMethodEntry("SkillBasedAssessmentPage",
                    "isQuestionsTabVisibileInSimStudyPlan",
                   base.isTakeScreenShotDuringEntryExit);
                string getWindowName;
                if (testType == SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_PreTest)
                {
                    //Window name For Pre test
                    getWindowName = SkillBasedAssessmentResource.
                     SkillBasedAssessment_Page_Pre_Test_WindowName;
                }
                else
                {
                    //Window name For Post test
                    getWindowName = SkillBasedAssessmentResource.
                       SkillBasedAssessment_Page_Post_Test_WindowName;
                }
                //Wait for the Window
                base.WaitUntilWindowLoads(getWindowName);
                //Validate Visibilty Questions Tab
                isQuestionTabsDisplayed = base.IsElementPresent(
                    By.Id(getWindowName),
                    Convert.ToInt16(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_Custom_Wait_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "isQuestionsTabVisibileInSimStudyPlan",
                  base.isTakeScreenShotDuringEntryExit);
            return isQuestionTabsDisplayed;
        }

        /// <summary>
        /// Click on tab of Edit SIM StudyPlan PreTest/Post Test.
        /// </summary>
        /// <param name="tabName">This is tab name.</param>
        public void ClickOnTabOfEditSIMStudyPlanPreTest(String tabName)
        {
            //Entry Logger 
            logger.LogMethodEntry("SkillBasedAssessmentPage",
               "ClickOnTabOfEditSIMStudyPlanPreTest",
                base.isTakeScreenShotDuringEntryExit);
            try
            {

                //Select Create Pre TestWidnow
                base.SelectWindow(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_Pre_Test_WindowName);
                //Wait for Tab Element 
                base.WaitForElement(By.PartialLinkText(tabName));
                //Get The html property
                IWebElement getHtmlPropertyofTab = base.
                    GetWebElementPropertiesByLinkText(tabName);
                base.ClickByJavaScriptExecutor(getHtmlPropertyofTab);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Exit Logger
            logger.LogMethodExit("SkillBasedAssessmentPage",
               "ClickOnTabOfEditSIMStudyPlanPreTest",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Time in Set Time limit for activity.
        /// </summary>
        /// <param name="timeInMinute">This is Time in minute.</param>
        public void EnterTimeInActivityPreference(int timeInMinute)
        {
            //Entry Logger 
            logger.LogMethodEntry("SkillBasedAssessmentPage",
               "EnterTimeInActivityPreference",base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for set time limit Check box
                base.WaitForElement(By.Id(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Time_Limit_Checkbox_ID));
                //Validate the checkbox status
                if (!base.IsElementSelectedById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Time_Limit_Checkbox_ID))
                {
                    base.SelectCheckBoxByName(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Time_Limit_Checkbox_ID);
                }
                //Wait for Timer text box
                base.WaitForElement(By.Id(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Time_Limit_TextBox_Id));
                //Clear Minute Textbox
                base.ClearTextByID(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Time_Limit_TextBox_Id);
                //Fill Text by expected time
                base.FillTextBoxByID(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Time_Limit_TextBox_Id, 
                    timeInMinute.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Exit Logger
            logger.LogMethodExit("SkillBasedAssessmentPage",
              "EnterTimeInActivityPreference", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save And Return on SIM Study Plan PreTest Preference page.
        /// </summary>
        public void ClickOnSaveAndReturnOfSIMStudyPlanPreTest()
        {
            //Logger Entry
            logger.LogMethodEntry("SkillBasedAssessmentPage",
            "ClickOnSaveAndReturnOfSIMStudyPlanPreTest",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Pretest Window
                this.SelectSIMStudyPlanPretestWindow();
                //Save The Preference Settings
                this.SaveThePreferenceSettings();               
                // Select Edit myitlab Study Plan window.
                this.SelectSIMStudyplanWindow();
                //Wait for Save and resturn button
                base.WaitForElement(By.Id(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_SIMStudyPreTest_SaveAndResturn_Button_ID));
                //Click On Save And Return
                base.ClickButtonByID(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_SIMStudyPreTest_SaveAndResturn_Button_ID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            logger.LogMethodExit("SkillBasedAssessmentPage",
               "ClickOnSaveAndReturnOfSIMStudyPlanPreTest",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save The Preference Settings.
        /// </summary>
        private void SaveThePreferenceSettings()
        {
            //Save The Preference Settings
            logger.LogMethodEntry("SkillBasedAssessmentPage",
            "SaveThePreferenceSettings",
            base.isTakeScreenShotDuringEntryExit);
            //Wait for Button
            base.WaitForElement(By.Id(SkillBasedAssessmentResource.
                SkillBasedAssessment_Page_SIMPreTest_Pref_SaveAndResturn_Button_ID));
            base.FocusOnElementByID(SkillBasedAssessmentResource.
                SkillBasedAssessment_Page_SIMPreTest_Pref_SaveAndResturn_Button_ID);
            //Click On Save and Return
            base.ClickButtonByID(SkillBasedAssessmentResource.
                SkillBasedAssessment_Page_SIMPreTest_Pref_SaveAndResturn_Button_ID);
            logger.LogMethodExit("SkillBasedAssessmentPage",
               "SaveThePreferenceSettings",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit myitlab Study Plan window.
        /// </summary>
        private void SelectSIMStudyplanWindow()
        {
            //Logger Entry
            logger.LogMethodEntry("SkillBasedAssessmentPage",
            "SelectSIMStudyplanWindow",
            base.isTakeScreenShotDuringEntryExit);
           //Wait for window
            base.WaitUntilWindowLoads(SkillBasedAssessmentResource.
                SkillBasedAssessment_AddmyitlabStudyPlan_Window_Name);
            //Select Window
            base.SelectWindow(SkillBasedAssessmentResource.
                SkillBasedAssessment_AddmyitlabStudyPlan_Window_Name);
            //Logger Exit
            logger.LogMethodExit("SkillBasedAssessmentPage",
            "SelectSIMStudyplanWindow",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select SIM Study Plan Pre test Window.
        /// </summary>
        private void SelectSIMStudyPlanPretestWindow()
        {
            //Select Pretest Window
            logger.LogMethodEntry("SkillBasedAssessmentPage", 
                "SelectSIMStudyPlanPretestWindow",
             base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitUntilWindowLoads(SkillBasedAssessmentResource.
                SkillBasedAssessment_Page_Pre_Test_WindowName);
            //Select Window
            base.SelectWindow(SkillBasedAssessmentResource.
                SkillBasedAssessment_Page_Pre_Test_WindowName);
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "SelectSIMStudyPlanPretestWindow",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify 'Play Training Mode' Preference.
        /// </summary>  
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        public void VerifyPlayTrainingModePreference(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Play Training Mode Preference
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "VerifyPlayTrainingModePreference",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click The Preference Tab
                this.ClickThePreferenceTab(); 
                //Select 'Create Activity' Window
                this.SelectCreateActivityWindow();
                base.WaitForElement(By.Id(SkillBasedAssessmentResource.
                  SkillBasedAssessment_Page_PlayMode_Checkbox_Id_Locator));
                switch (activityTypeEnum)
                {
                    case Activity.ActivityTypeEnum.SIMExamActivity:
                        //Uncheck 'Play Training Mode' Preference
                        this.UncheckPlayTrainingModePreference();
                        break;
                    case Activity.ActivityTypeEnum.SIMTrainingActivity:
                        //Check 'Play Training Mode' Preference
                        this.CheckPlayTrainingModePreference();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }            
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "VerifyPlayTrainingModePreference",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Preference Tab.
        /// </summary>
        public void ClickThePreferenceTab()
        {
            //Click The Preference Tab
            logger.LogMethodEntry("SkillBasedAssessmentPage", "ClickThePreferenceTab",
                   base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAssement_Page_Select_PreferenceTab_Id_Locator));
                base.FocusOnElementByID(AddAssessmentPageResources.
                    AddAssement_Page_Select_PreferenceTab_Id_Locator);
                IWebElement getPreferenceTab = base.GetWebElementPropertiesById
                    (AddAssessmentPageResources.
                    AddAssement_Page_Select_PreferenceTab_Id_Locator);
                //Click on Preference tab
                base.ClickByJavaScriptExecutor(getPreferenceTab);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage", "ClickThePreferenceTab",
                  base.isTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Check 'Play Training Mode' Preference.
        /// </summary>
        private void CheckPlayTrainingModePreference()
        {
            //Check 'Play Training Mode' Preference
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "CheckPlayTrainingModePreference",
                base.isTakeScreenShotDuringEntryExit);
            if (!base.IsElementSelectedById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_PlayMode_Checkbox_Id_Locator))
            {
                //Check 'Play Training Mode' Preference
                base.ClickCheckBoxById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_PlayMode_Checkbox_Id_Locator);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "CheckPlayTrainingModePreference",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Uncheck 'Play Training Mode' Preference.
        /// </summary>
        private void UncheckPlayTrainingModePreference()
        {
            //Uncheck 'Play Training Mode' Preference
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "UncheckPlayTrainingModePreference",
                base.isTakeScreenShotDuringEntryExit);
            if (base.IsElementSelectedById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_PlayMode_Checkbox_Id_Locator))
            {
                //Uncheck 'Play Training Mode' Preference
                base.ClickCheckBoxById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_PlayMode_Checkbox_Id_Locator);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "UncheckPlayTrainingModePreference",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Create Activity' Widnow.
        /// </summary>
        private void SelectCreateActivityWindow()
        {
            //Select 'Create Activity' Widnow
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "SelectCreateActivityWindow",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_WindowName);
            //Select Window
            base.SelectWindow(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_WindowName);
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "SelectCreateActivityWindow",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Question Type.
        /// </summary>
        /// <param name="questionType">This is Question type.</param>
        public void SelectTheQuestionType(string questionType)
        {
            //Select Create Question Type
            logger.LogMethodEntry("SkillBasedAssessmentPage", "SelectTheQuestionType",
                   base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.PartialLinkText(questionType));
                IWebElement getSelectQuestions =
                  base.GetWebElementPropertiesByPartialLinkText(questionType);
                //Click the Question type
                base.ClickByJavaScriptExecutor(getSelectQuestions);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage", "SelectTheQuestionType",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable The Manual Grading Preference.
        /// </summary>
        public void EnableTheManualGradingPreference()
        {
            //Enable The Manual Grading Preference
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "EnableTheManualGradingPreference",
                   base.isTakeScreenShotDuringEntryExit);
            try
            {  
                //Wait for the element
                base.WaitForElement(By.Id(SkillBasedAssessmentResource.
                    SkillBasedAssessment_ManualGrading_Preference_Id_Locator));
                if (!base.IsElementSelectedById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_ManualGrading_Preference_Id_Locator))
                {
                    //Check 'Required Manual Grading' Preference
                    base.ClickCheckBoxById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_ManualGrading_Preference_Id_Locator);
                }
                //Save The Preference Settings
                this.SaveThePreferenceSettings();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage", 
                "EnableTheManualGradingPreference",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Save for Later Preference.
        /// </summary>
        public void SetSaveforLaterPreference()
        {
            //Set Save for Later Preference
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "SetSaveforLaterPreference",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
               //Wait for the element
                base.WaitForElement(By.Id(SkillBasedAssessmentResource.
                    SkillBasedAssessment_SaveForLater_Checkbox_ID));
                if (!base.IsElementSelectedById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_SaveForLater_Checkbox_ID))
                {
                    //Get web element
                    IWebElement getSaveLaterCheckbox = base.GetWebElementPropertiesById
                        (SkillBasedAssessmentResource.
                    SkillBasedAssessment_SaveForLater_Checkbox_ID);
                    //Click on 'Save On Later' checkbox
                    base.ClickByJavaScriptExecutor(getSaveLaterCheckbox);
                }
                //Enable Never Prefernce Option For Correct Answer
                new RandomAssessmentPage().EnableNeverPreferenceForCorrectAnswer();
                //Click the Save and Return tab
                new RandomTopicListPage().ClickOnSaveAndReturnButtonInPreference();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "SetSaveforLaterPreference",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Feedback Never Preference.
        /// </summary>
        public void EnableFeedbackNeverPreference()
        {
            //Enable Feedback Never Preference
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "EnableFeedbackNeverPreference",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click the preference
                this.ClickThePreferenceTab();
                //Select 'Edit Random Activity' Window
                this.SelectEditRandomActivityWindow();
                base.WaitForElement(By.Id(SkillBasedAssessmentResource.
                        SkillBasedAssessment_FeedbackNever_Radiobutton_Id));
                if (!base.IsElementSelected(By.Id(SkillBasedAssessmentResource.
                    SkillBasedAssessment_FeedbackNever_Radiobutton_Id)))
                {
                    //Select Feedback 'Never' Radio Button
                    base.SelectRadioButtonById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_FeedbackNever_Radiobutton_Id);
                }
                //Click the Save and Return tab
                new RandomTopicListPage().ClickOnSaveAndReturnButtonInPreference();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "EnableFeedbackNeverPreference",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Edit Random Activity' Window.
        /// </summary>
        private void SelectEditRandomActivityWindow()
        {
            //Select 'Edit Random Activity' Window
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "SelectEditRandomActivityWindow",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(SkillBasedAssessmentResource.
                SkillBasedAssessment_EditRandomActivity_WindowName);
            //Select Window
            base.SelectWindow(SkillBasedAssessmentResource.
                SkillBasedAssessment_EditRandomActivity_WindowName);
            logger.LogMethodExit("SkillBasedAssessmentPage",
               "SelectEditRandomActivityWindow",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
