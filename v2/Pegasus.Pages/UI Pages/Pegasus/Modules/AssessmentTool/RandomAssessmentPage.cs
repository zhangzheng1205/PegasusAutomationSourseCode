using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles RandomAssessment Page Actions.
    /// </summary>
    public class RandomAssessmentPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(RandomAssessmentPage));

        /// <summary>
        /// Validate Visibilty Questions Tab for Basic Random Activity. 
        /// </summary>
        public bool isQuestionsTabVisible()
        {
            bool isQuestionTabsDisplayed = false;
            try
            {
                // Validate Visibilty Questions Tab for Basic Random Activity
                logger.LogMethodEntry("RandomAssessmentPage",
                    "isQuestionsTabVisible",
                           base.isTakeScreenShotDuringEntryExit);
                //Wait for the Window
                this.SelectEditRandomActivtyWindow();
                //Validate Visibilty Questions Tab
                isQuestionTabsDisplayed = base.IsElementPresent(
                    By.Id(RandomAssessmentResource.
                    RandomAssessment_Page_QuestionsTab_ID), 
                    Convert.ToInt16(RandomAssessmentResource.
                    RandomAssessment_Page_Custom_Wait_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomAssessmentPage",
                "isQuestionsTabVisible",
                base.isTakeScreenShotDuringEntryExit);
            return isQuestionTabsDisplayed;
        }

        /// <summary>
        /// Is Present The Preference Settings In Activity.
        /// </summary>
        /// <returns>Try Again ckeckbox selected.</returns>
        public bool IsPresentThePreferenceSettingsInActivity()
        {
            //Is Present The Preference Settings In Activity
            logger.LogMethodEntry("RandomAssessmentPage",
                "IsPresentThePreferenceSettingsInActivity",
                       base.isTakeScreenShotDuringEntryExit);
            bool isAllowstudentstoTryAgainDisplayed = false;
            try
            {
                //Select Edit Random Activty Window.
                this.SelectEditRandomActivtyWindow();
                //Wait for the element
                base.WaitForElement(By.Id(RandomAssessmentResource.
                    RandomAssessment_Page_Activity_AllowstudentstoTryAgain_PreferenceSet));
                //Check the preference settings
                isAllowstudentstoTryAgainDisplayed = base.IsElementPresent(By.Id
                    (RandomAssessmentResource.
                    RandomAssessment_Page_Activity_AllowstudentstoTryAgain_PreferenceSet));
                //Verify if it is Selected
                if (!(base.GetWebElementPropertiesById(RandomAssessmentResource.
                    RandomAssessment_Page_Activity_AllowstudentstoTryAgain_PreferenceSet).Selected))
                {
                    //Check the 'Display courses as folders on the Content page' Checkbox
                    base.ClickButtonById(RandomAssessmentResource.
                    RandomAssessment_Page_Activity_AllowstudentstoTryAgain_PreferenceSet);
                }
                //Click On Save Return Button
                this.ClickOnSaveReturnButton();                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomAssessmentPage",
                "IsPresentThePreferenceSettingsInActivity",
                base.isTakeScreenShotDuringEntryExit);
            return isAllowstudentstoTryAgainDisplayed;
        }

        /// <summary>
        /// Click On Save Return Button.
        /// </summary>
        private void ClickOnSaveReturnButton()
        {
            //Click On Save Return Button
            logger.LogMethodEntry("RandomAssessmentPage", "ClickOnSaveReturnButton",
                       base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RandomAssessmentResource.
                RandomAssessment_Page_ActivityPreference_Savebutton_Id_Locator));
            base.FocusOnElementById(RandomAssessmentResource.
                RandomAssessment_Page_ActivityPreference_Savebutton_Id_Locator);
            IWebElement getSavePreference = base.GetWebElementPropertiesById
                (RandomAssessmentResource.
                RandomAssessment_Page_ActivityPreference_Savebutton_Id_Locator);
            base.ClickByJavaScriptExecutor(getSavePreference);
            Thread.Sleep(Convert.ToInt32(RandomAssessmentResource.
                RandomAssessment_Page_Activity_Prepare_Time));
            logger.LogMethodExit("RandomAssessmentPage", "ClickOnSaveReturnButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit Random Activty Window.
        /// </summary>
        private void SelectEditRandomActivtyWindow()
        {
            //Is Present The Preference Settings In Activity
            logger.LogMethodEntry("RandomAssessmentPage", "SelectEditRandomActivtyWindow",
                       base.isTakeScreenShotDuringEntryExit);
            //Select the window
            base.WaitUntilWindowLoads(RandomAssessmentResource.
                     RandomAssessment_Page_WindowName);
            base.SelectWindow(RandomAssessmentResource.
                    RandomAssessment_Page_WindowName);
            logger.LogMethodExit("RandomAssessmentPage", "SelectEditRandomActivtyWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Never Preference Option For Correct Answer
        /// </summary>
        public void EnableNeverPreferenceForCorrectAnswer()
        {
            //Eanble Never Preference Option For Correct Answer
            logger.LogMethodEntry("RandomAssessmentPage", "EnableNeverPreferenceForCorrectAnswer",
                      base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(RandomAssessmentResource.
                RandomAssessment_Page_NeverCorrectAnswer_RadioButton_Id_Locator));
            //Get Radio Button Property
            IWebElement getRadioButtonProperty = base.
                GetWebElementPropertiesById(RandomAssessmentResource.
                RandomAssessment_Page_NeverCorrectAnswer_RadioButton_Id_Locator);
            //Click On Radio Button
            base.ClickByJavaScriptExecutor(getRadioButtonProperty);
            logger.LogMethodExit("RandomAssessmentPage", "EnableNeverPreferenceForCorrectAnswer",
                      base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable At Attempt Option for Correct Answer
        /// </summary>
        public void EnableAtAttemptOptionForCorrectAnswer()
        {
            //Enable At Attempt Option for Correct Answer
            logger.LogMethodEntry("RandomAssessmentPage", "EnableAtAttemptOptionForCorrectAnswer",
                     base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(RandomAssessmentResource.
                        RandomAssessment_Page_AtAttempt_Id_Locator));
                //Get Radio Button Property
                IWebElement getRadioButtonProperty = base.GetWebElementPropertiesById(
                    RandomAssessmentResource.RandomAssessment_Page_AtAttempt_Id_Locator);
                //Click On Radio Button
                base.ClickByJavaScriptExecutor(getRadioButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("RandomAssessmentPage", "EnableAtAttemptOptionForCorrectAnswer",
                      base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Increase the Activity Attempt
        /// </summary>
        /// <param name="activityAttempt">This is Activity Attempt</param>
        public void IncreaseActivityAttempt(string activityAttempt)
        {
            //Increase the Activity Attempt
            logger.LogMethodEntry("RandomAssessmentPage", "IncreaseActivityAttempt",
             base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click On Prefernces Tab
                this.ClickThePreferenceTab();
                //Select Edit Random Activity Window
                this.SelectEditRandomActivityWindow();
                base.WaitForElement(By.Id(RandomAssessmentResource.
                    RandomAssessment_Page_InputAttemptValue_Id_Locator));
                //Clear Text Box
                base.ClearTextById(RandomAssessmentResource.
                    RandomAssessment_Page_InputAttemptValue_Id_Locator);
                IWebElement getAttemptTextBoxProperty = base.GetWebElementPropertiesById(
                    RandomAssessmentResource.RandomAssessment_Page_InputAttemptValue_Id_Locator);
                //Fill Attempt Value
                base.FillTextBoxById(RandomAssessmentResource.
                    RandomAssessment_Page_InputAttemptValue_Id_Locator, activityAttempt);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomAssessmentPage", "IncreaseActivityAttempt",
                     base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Preference Tab.
        /// </summary>
        private void ClickThePreferenceTab()
        {
            //Click The Preference Tab
            logger.LogMethodEntry("RandomAssessmentPage", "ClickThePreferenceTab",
                   base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RandomAssessmentResource.
                RandomAssessment_Page_Select_PreferenceTab_Id_Locator));
            base.FocusOnElementById(RandomAssessmentResource.
                RandomAssessment_Page_Select_PreferenceTab_Id_Locator);
            IWebElement getPreferenceTab = base.GetWebElementPropertiesById
                (RandomAssessmentResource.
                RandomAssessment_Page_Select_PreferenceTab_Id_Locator);
            //Click on Preference tab
            base.ClickByJavaScriptExecutor(getPreferenceTab);
            logger.LogMethodExit("RandomAssessmentPage", "ClickThePreferenceTab",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Edit Random Activity' Window.
        /// </summary>
        private void SelectEditRandomActivityWindow()
        {
            //Select 'Edit Random Activity' Window
            logger.LogMethodEntry("RandomAssessmentPage",
                "SelectEditRandomActivityWindow",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(RandomAssessmentResource.
                RandomAssessment_Page_EditRandomActivity_WindowName);
            //Select Window
            base.SelectWindow(RandomAssessmentResource.
                RandomAssessment_Page_EditRandomActivity_WindowName);
            logger.LogMethodExit("RandomAssessmentPage",
               "SelectEditRandomActivityWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Correct Answer Attempt Value
        /// </summary>
        /// <param name="attemptValue">This is Attempt Value</param>
        public void EnterCorrectAnswerAttemptValue(String attemptValue)
        {
            //Enter Correct Answer Attempt Value
            logger.LogMethodEntry("RandomAssessmentPage",
                "EnterCorrectAnswerAttemptValue",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(RandomAssessmentResource.
                       RandomAssessment_Page_InputAtAttempt_Id_Locator));
                //Clear Text Box
                base.ClearTextById(RandomAssessmentResource.
                    RandomAssessment_Page_InputAtAttempt_Id_Locator);
                //Enter Attempt Value
                base.FillTextBoxById(RandomAssessmentResource.
                    RandomAssessment_Page_InputAtAttempt_Id_Locator, attemptValue);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomAssessmentPage",
              "EnterCorrectAnswerAttemptValue",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Save and Return Button In Message Tab.
        /// </summary>
        public void ClickSaveandReturnActivityPreferenceButtonInMessageTab()
        {
            //Click Save and Return Button In Message Tab
            logger.LogMethodEntry("RandomAssessmentPage",
                  "ClickSaveandReturnActivityPreferenceButtonInMessageTab",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(RandomAssessmentResource.
                       RandomAssessment_Page_SaveandReturn_Message_Tab_Id_Locator));
                //Click on Save and Return Button
                IWebElement getSaveandReturnButton =
                    base.GetWebElementPropertiesById(RandomAssessmentResource.
                    RandomAssessment_Page_SaveandReturn_Message_Tab_Id_Locator);
                base.ClickByJavaScriptExecutor(getSaveandReturnButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomAssessmentPage",
                  "ClickSaveandReturnActivityPreferenceButtonInMessageTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity Level Tab.
        /// </summary>
        /// <param name="activityWindowName">This is activity window name.</param>
        /// <param name="selectActivityLevelTab">This is activity Tab name.</param>
        public void SelectActivityLevelTab(string activityWindowName, string selectActivityLevelTab)
        {
            // select activity level Tabs
            logger.LogMethodEntry("RandomAssessmentPage",
                  "SelectActivityLevelTab",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                // select activity window
                base.WaitUntilWindowLoads(activityWindowName);
                base.SelectWindow(activityWindowName);
                // select activity level Tab 
                base.WaitForElement(By.PartialLinkText(selectActivityLevelTab));
                base.ClickByJavaScriptExecutor
                    (base.GetWebElementPropertiesByPartialLinkText(selectActivityLevelTab));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomAssessmentPage",
                  "SelectActivityLevelTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Activity Level Preferences.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void SetActivityLevelPreferences(string activityName)
        {
            // select activity level preference
            logger.LogMethodEntry("RandomAssessmentPage",
                  "SetActivityLevelPreferences",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch(activityName)
                {
                    case "Access Chapter 1: End-of-Chapter Quiz":
                        base.WaitForElement(By.Id(RandomAssessmentResource.
                            RandomAssessment_Page_Select_SaveForLater_Preference_Id_Locator));
                        // is preference selected
                        bool isSaveForLaterReferenceSet = base.IsElementSelectedById(RandomAssessmentResource.
                            RandomAssessment_Page_Select_SaveForLater_Preference_Id_Locator);
                        if(!isSaveForLaterReferenceSet)
                        {
                            // select preference
                            base.SelectCheckBoxById(RandomAssessmentResource.
                            RandomAssessment_Page_Select_SaveForLater_Preference_Id_Locator);
                        }                         
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomAssessmentPage",
                  "SetActivityLevelPreferences",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Save and Return Preference Button.
        /// </summary>
        public void ClickSaveandReturnActivityPreferenceButton()
        {
            // click save and return preference button
            logger.LogMethodEntry("RandomAssessmentPage",
                  "ClickSaveandReturnActivityPreferenceButton",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.PartialLinkText(RandomAssessmentResource.
                       RandomAssessment_Page_SaveandReturn_Button_PartialLinkText_Locator), 5);
                // click on save and return button
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByPartialLinkText
                    (RandomAssessmentResource.RandomAssessment_Page_SaveandReturn_Button_PartialLinkText_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomAssessmentPage",
                  "ClickSaveandReturnActivityPreferenceButton",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}