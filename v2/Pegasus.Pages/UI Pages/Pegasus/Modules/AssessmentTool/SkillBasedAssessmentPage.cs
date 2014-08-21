﻿using System;
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
                    base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Time in Set Time limit for activity.
        /// </summary>
        /// <param name="timeInMinute">This is Time in minute.</param>
        public void EnterTimeInActivityPreference(int timeInMinute)
        {
            //Entry Logger 
            logger.LogMethodEntry("SkillBasedAssessmentPage",
               "EnterTimeInActivityPreference", base.IsTakeScreenShotDuringEntryExit);
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
                base.ClearTextById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Time_Limit_TextBox_Id);
                //Fill Text by expected time
                base.FillTextBoxById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Time_Limit_TextBox_Id,
                    timeInMinute.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Exit Logger
            logger.LogMethodExit("SkillBasedAssessmentPage",
              "EnterTimeInActivityPreference", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save And Return on SIM Study Plan PreTest Preference page.
        /// </summary>
        public void ClickOnSaveAndReturnOfSIMStudyPlanPreTest()
        {
            //Logger Entry
            logger.LogMethodEntry("SkillBasedAssessmentPage",
            "ClickOnSaveAndReturnOfSIMStudyPlanPreTest",
            base.IsTakeScreenShotDuringEntryExit);
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
                base.ClickButtonById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_SIMStudyPreTest_SaveAndResturn_Button_ID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            logger.LogMethodExit("SkillBasedAssessmentPage",
               "ClickOnSaveAndReturnOfSIMStudyPlanPreTest",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save The Preference Settings.
        /// </summary>
        private void SaveThePreferenceSettings()
        {
            //Save The Preference Settings
            logger.LogMethodEntry("SkillBasedAssessmentPage",
            "SaveThePreferenceSettings",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for Button
            base.WaitForElement(By.Id(SkillBasedAssessmentResource.
                SkillBasedAssessment_Page_SIMPreTest_Pref_SaveAndResturn_Button_ID));
            base.FocusOnElementById(SkillBasedAssessmentResource.
                SkillBasedAssessment_Page_SIMPreTest_Pref_SaveAndResturn_Button_ID);
            //Click On Save and Return
            base.ClickButtonById(SkillBasedAssessmentResource.
                SkillBasedAssessment_Page_SIMPreTest_Pref_SaveAndResturn_Button_ID);
            logger.LogMethodExit("SkillBasedAssessmentPage",
               "SaveThePreferenceSettings",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit myitlab Study Plan window.
        /// </summary>
        private void SelectSIMStudyplanWindow()
        {
            //Logger Entry
            logger.LogMethodEntry("SkillBasedAssessmentPage",
            "SelectSIMStudyplanWindow",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for window
            base.WaitUntilWindowLoads(SkillBasedAssessmentResource.
                SkillBasedAssessment_AddmyitlabStudyPlan_Window_Name);
            //Select Window
            base.SelectWindow(SkillBasedAssessmentResource.
                SkillBasedAssessment_AddmyitlabStudyPlan_Window_Name);
            //Logger Exit
            logger.LogMethodExit("SkillBasedAssessmentPage",
            "SelectSIMStudyplanWindow",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select SIM Study Plan Pre test Window.
        /// </summary>
        private void SelectSIMStudyPlanPretestWindow()
        {
            //Select Pretest Window
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "SelectSIMStudyPlanPretestWindow",
             base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitUntilWindowLoads(SkillBasedAssessmentResource.
                SkillBasedAssessment_Page_Pre_Test_WindowName);
            //Select Window
            base.SelectWindow(SkillBasedAssessmentResource.
                SkillBasedAssessment_Page_Pre_Test_WindowName);
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "SelectSIMStudyPlanPretestWindow",
               base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Preference Tab.
        /// </summary>
        public void ClickThePreferenceTab()
        {
            //Click The Preference Tab
            logger.LogMethodEntry("SkillBasedAssessmentPage", "ClickThePreferenceTab",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAssement_Page_Select_PreferenceTab_Id_Locator));
                base.FocusOnElementById(AddAssessmentPageResources.
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
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check 'Play Training Mode' Preference.
        /// </summary>
        private void CheckPlayTrainingModePreference()
        {
            //Check 'Play Training Mode' Preference
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "CheckPlayTrainingModePreference",
                base.IsTakeScreenShotDuringEntryExit);
            if (!base.IsElementSelectedById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_PlayMode_Checkbox_Id_Locator))
            {
                //Check 'Play Training Mode' Preference
                base.SelectCheckBoxById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_PlayMode_Checkbox_Id_Locator);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "CheckPlayTrainingModePreference",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Uncheck 'Play Training Mode' Preference.
        /// </summary>
        private void UncheckPlayTrainingModePreference()
        {
            //Uncheck 'Play Training Mode' Preference
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "UncheckPlayTrainingModePreference",
                base.IsTakeScreenShotDuringEntryExit);
            if (base.IsElementSelectedById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_PlayMode_Checkbox_Id_Locator))
            {
                //Uncheck 'Play Training Mode' Preference
                base.SelectCheckBoxById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_PlayMode_Checkbox_Id_Locator);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "UncheckPlayTrainingModePreference",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Create Activity' Widnow.
        /// </summary>
        private void SelectCreateActivityWindow()
        {
            //Select 'Create Activity' Widnow
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "SelectCreateActivityWindow",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_WindowName);
            //Select Window
            base.SelectWindow(SkillBasedAssessmentResource.
                    SkillBasedAssessment_Page_WindowName);
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "SelectCreateActivityWindow",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Question Type.
        /// </summary>
        /// <param name="questionType">This is Question type.</param>
        public void SelectTheQuestionType(string questionType)
        {
            //Select Create Question Type
            logger.LogMethodEntry("SkillBasedAssessmentPage", "SelectTheQuestionType",
                   base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable The Manual Grading Preference.
        /// </summary>
        public void EnableTheManualGradingPreference()
        {
            //Enable The Manual Grading Preference
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "EnableTheManualGradingPreference",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(SkillBasedAssessmentResource.
                    SkillBasedAssessment_ManualGrading_Preference_Id_Locator));
                if (!base.IsElementSelectedById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_ManualGrading_Preference_Id_Locator))
                {
                    //Check 'Required Manual Grading' Preference
                    base.SelectCheckBoxById(SkillBasedAssessmentResource.
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
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Save for Later Preference.
        /// </summary>
        public void SetSaveforLaterPreference()
        {
            //Set Save for Later Preference
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "SetSaveforLaterPreference",
                base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Feedback Never Preference.
        /// </summary>
        public void EnableFeedbackNeverPreference()
        {
            //Enable Feedback Never Preference
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "EnableFeedbackNeverPreference",
                base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Select SIM5 AND QTI Supported Questions from Question Bank for SIM5 Activity.
        /// </summary>
        public void SelectQuestionFromQuestionBank()
        {
            logger.LogMethodEntry("SkillBasedAssessmentPage", "SelectQuestionFromQuestionBank",
                 base.IsTakeScreenShotDuringEntryExit);
            //Select SIM5 Questions From Bank
            try
            {
                //Click on Select Question From Bank
                this.ClickOnSelectQuestionFromBank();
                // Switch to last open Window
                base.SwitchToLastOpenedWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage", "SelectQuestionFromQuestionBank",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Select Question From Bank
        /// </summary>
        private void ClickOnSelectQuestionFromBank()
        {
            logger.LogMethodEntry("SkillBasedAssessmentPage", "ClickOnSelectQuestionFromBank",
                 base.IsTakeScreenShotDuringEntryExit);
            //Get IWebElement properties for 'Select Question From Bank'
            IWebElement GetSelectQuestionFromBank = base.
                GetWebElementPropertiesByPartialLinkText(SkillBasedAssessmentResource.
                SkillBasedAssessment_Questions_SelectQuestionsFromBank_Anchor);
            //Click on 'Select Questions from Bank' option
            base.ClickByJavaScriptExecutor(GetSelectQuestionFromBank);
            logger.LogMethodExit("SkillBasedAssessmentPage", "ClickOnSelectQuestionFromBank",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Create new questions.
        /// </summary>
        public void CreateNewQuestion()
        {
            //Select Question From Bank for Basic Random
            logger.LogMethodEntry("RandomTopicListPage", "SelectQuestionFromBankForBasicRandom",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {

                base.WaitForElement(By.XPath(RandomTopicListPageResource.
                       RandomTopicList_Page_SelectQuestionFromBank_Xpath_Locator));

                IWebElement getSelectQuestion = base.GetWebElementPropertiesByXPath(RandomTopicListPageResource.
                        RandomTopicList_Page_SelectQuestionFromBank_Xpath_Locator);
                //Click On Select Question From Bank
                base.ClickByJavaScriptExecutor(getSelectQuestion);
                //Wait for Select Questions Window
                base.WaitUntilWindowLoads(RandomTopicListPageResource.
                    RandomTopicList_Page_SelectQuestions_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "SelectQuestionFromBankForBasicRandom",
              base.IsTakeScreenShotDuringEntryExit);
        }




        /// <summary>
        /// Create new Pegasus native questions.
        /// </summary>
        public void CreatePegasusNativeQuestion()
        {
            //Create Pegasus native question

            logger.LogMethodEntry("SkillBasedAssessmentPage", "CreatePegasusNativeQuestion",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to last open window
                base.SwitchToLastOpenedWindow();
                //Click on 'Add Questions' link
                new RandomTopicListPage().ClickOnAddQuestionLink();
                //Click on 'Create new Question'
                this.ClickOnCreateNewQuestion();
                //Click on 'True/False' question link
                //new CreateQuestionPage().ClickOnTrueFalseQuestionLink();
                //Create a new True/False question
                new TrueFalsePage().CreateNewTrueFalseQuestion();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage", "CreatePegasusNativeQuestion",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Save and Return.
        /// </summary>
        public void SaveandReturn()
        {
            logger.LogMethodEntry("SkillBasedAssessmentPage", "SaveandReturn",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to last open window
                base.SwitchToLastOpenedWindow();
                //Wait for 'Save and Return' button
                base.WaitForElement(By.Id(SkillBasedAssessmentResource.SkillBasedAssessment_SaveAndReturn_Button_Id_Locator));
                //Get Property for 'Save and Return' button
                IWebElement GetSaveAndReturn = base.GetWebElementPropertiesById(SkillBasedAssessmentResource.
                    SkillBasedAssessment_SaveAndReturn_Button_Id_Locator);
                //Click on 'Save and Return'
                base.ClickByJavaScriptExecutor(GetSaveAndReturn);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage", "SaveandReturn",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Create New Question
        /// </summary>
        private void ClickOnCreateNewQuestion()
        {

            logger.LogMethodEntry("SkillBasedAssessmentPage", "ClickOnCreateNewQuestion",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.PartialLinkText(SkillBasedAssessmentResource.
                    SkillBasedAssessment_CreateNewQuestion_PartialText_Id_Locator));
                //Get property for 'Create New Question'
                IWebElement GetCreateNewQuestion = base.GetWebElementPropertiesByPartialLinkText(SkillBasedAssessmentResource.
                    SkillBasedAssessment_CreateNewQuestion_PartialText_Id_Locator);
                //Click on Create New Question link
                base.ClickByJavaScriptExecutor(GetCreateNewQuestion);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage", "ClickOnCreateNewQuestion",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select 'Edit Random Activity' Window.
        /// </summary>
        private void SelectEditRandomActivityWindow()
        {
            //Select 'Edit Random Activity' Window
            logger.LogMethodEntry("SkillBasedAssessmentPage",
                "SelectEditRandomActivityWindow",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(SkillBasedAssessmentResource.
                SkillBasedAssessment_EditRandomActivity_WindowName);
            //Select Window
            base.SelectWindow(SkillBasedAssessmentResource.
                SkillBasedAssessment_EditRandomActivity_WindowName);
            logger.LogMethodExit("SkillBasedAssessmentPage",
               "SelectEditRandomActivityWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
