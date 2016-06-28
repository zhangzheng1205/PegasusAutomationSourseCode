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
using OpenQA.Selenium.Interactions;
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
                           base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                       base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            return isAllowstudentstoTryAgainDisplayed;
        }

        /// <summary>
        /// Click On Save Return Button.
        /// </summary>
        private void ClickOnSaveReturnButton()
        {
            //Click On Save Return Button
            logger.LogMethodEntry("RandomAssessmentPage", "ClickOnSaveReturnButton",
                       base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit Random Activty Window.
        /// </summary>
        private void SelectEditRandomActivtyWindow()
        {
            //Is Present The Preference Settings In Activity
            logger.LogMethodEntry("RandomAssessmentPage", "SelectEditRandomActivtyWindow",
                       base.IsTakeScreenShotDuringEntryExit);
            //Select the window
            base.WaitUntilWindowLoads(RandomAssessmentResource.
                     RandomAssessment_Page_WindowName);
            base.SelectWindow(RandomAssessmentResource.
                    RandomAssessment_Page_WindowName);
            logger.LogMethodExit("RandomAssessmentPage", "SelectEditRandomActivtyWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Never Preference Option For Correct Answer
        /// </summary>
        public void EnableNeverPreferenceForCorrectAnswer()
        {
            //Eanble Never Preference Option For Correct Answer
            logger.LogMethodEntry("RandomAssessmentPage", "EnableNeverPreferenceForCorrectAnswer",
                      base.IsTakeScreenShotDuringEntryExit);
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
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable At Attempt Option for Correct Answer
        /// </summary>
        public void EnableAtAttemptOptionForCorrectAnswer()
        {
            //Enable At Attempt Option for Correct Answer
            logger.LogMethodEntry("RandomAssessmentPage", "EnableAtAttemptOptionForCorrectAnswer",
                     base.IsTakeScreenShotDuringEntryExit);
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
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Increase the Activity Attempt
        /// </summary>
        /// <param name="activityAttempt">This is Activity Attempt</param>
        public void IncreaseActivityAttempt(string activityAttempt)
        {
            //Increase the Activity Attempt
            logger.LogMethodEntry("RandomAssessmentPage", "IncreaseActivityAttempt",
             base.IsTakeScreenShotDuringEntryExit);
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
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Preference Tab.
        /// </summary>
        private void ClickThePreferenceTab()
        {
            //Click The Preference Tab
            logger.LogMethodEntry("RandomAssessmentPage", "ClickThePreferenceTab",
                   base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Edit Random Activity' Window.
        /// </summary>
        private void SelectEditRandomActivityWindow()
        {
            //Select 'Edit Random Activity' Window
            logger.LogMethodEntry("RandomAssessmentPage",
                "SelectEditRandomActivityWindow",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(RandomAssessmentResource.
                RandomAssessment_Page_EditRandomActivity_WindowName);
            //Select Window
            base.SelectWindow(RandomAssessmentResource.
                RandomAssessment_Page_EditRandomActivity_WindowName);
            logger.LogMethodExit("RandomAssessmentPage",
               "SelectEditRandomActivityWindow",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Save and Return Button In Message Tab.
        /// </summary>
        public void ClickSaveandReturnActivityPreferenceButtonInMessageTab()
        {
            //Click Save and Return Button In Message Tab
            logger.LogMethodEntry("RandomAssessmentPage",
                  "ClickSaveandReturnActivityPreferenceButtonInMessageTab",
                 base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Save and Return Preference Button.
        /// </summary>
        public void ClickSaveandReturnActivityPreferenceButton()
        {
            // click save and return preference button
            logger.LogMethodEntry("RandomAssessmentPage",
                  "ClickSaveandReturnActivityPreferenceButton",
                 base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        public void SetQuestionsPerPagePreference(string count)
        {
            base.SwitchToDefaultWindow();
            // Enable "Display this number of questions per page" radio button
            base.WaitForElement(By.Id("radQuestionperpage"));
            base.SelectRadioButtonById("radQuestionperpage");

            // Fill textbox "Display this number of questions per page" by ID
            base.ClearTextById("txtNoOfQuestions");
            base.FillTextBoxById("txtNoOfQuestions",
               count);
        }

        public void SetStyleSheet(string styleType)
        {
            base.SwitchToDefaultWindow();
            base.WaitForElement(By.Id("cboStyleSheet"));
            base.SelectDropDownValueThroughTextById("cboStyleSheet", styleType);
          
        }

        public void ClickSkipQuestion()
        {
            base.SwitchToDefaultWindow();
            base.WaitForElement(By.Id("chkSkip"));
            base.GetWebElementPropertiesById("chkSkip").Click();
        }

        /// <summary>
        /// Click Save and Return Button In Message Tab.
        /// </summary>
        public void SaveandReturnPreferenceAtCreateRandomActivity()
        {
            //Click Save and Return Button In Message Tab
            logger.LogMethodEntry("RandomAssessmentPage",
                  "SaveandReturnPreferenceAtCreateRandomActivity",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id("cmdTabPreferenceFinish"));
                //Click on Save and Return Button
                IWebElement getSaveandReturnButton =
                    base.GetWebElementPropertiesById("cmdTabPreferenceFinish");
                Thread.Sleep(3000);
                base.ClickByJavaScriptExecutor(getSaveandReturnButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomAssessmentPage",
                  "SaveandReturnPreferenceAtCreateRandomActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        public void EnterMessagesValues(string messageType)
        {
            logger.LogMethodEntry("RandomAssessmentPage",
                 "EnterMessagesValues",
                base.IsTakeScreenShotDuringEntryExit);
            string idValue = string.Empty;
            string message = message = "This is " + messageType + " message"; 
            switch(messageType)
            {
                case "Beginning of activity": idValue = "txtBeginFeedback";
                                              
                    break;
                case "Direction lines (instructions)": idValue = "txtdirectionlines";
                                                       
                    break;
                case "End of activity": idValue = "txtEndFeedback";
                    break;
            }
            WaitForElement(By.Id(idValue));
            base.ClearTextById(idValue);
            base.FillTextBoxById(idValue,message);
            logger.LogMethodExit("RandomAssessmentPage",
                 "EnterMessagesValues",
               base.IsTakeScreenShotDuringEntryExit);
        }


        public void EnterDirectionLineToSection(string actionType, string sectionNo)
        {
            //Select the current window
            base.SwitchToDefaultWindow();
            //Switch to frame
            base.SwitchToIFrameById("frmTopic");
            string idValue = string.Empty;
            string direction = string.Empty;
            switch(actionType)
            {
                case "Add": idValue = "ancAddDirectionLine_" + sectionNo;
                    direction = "This is direction for Section " + sectionNo;
                    OpenEditorAndAddDirections(idValue, direction);
                    break;
                case "Edit": idValue = "ancAddDirectionLine_" + sectionNo;
                    direction = " edited" ;
                    OpenEditorAndAddDirections(idValue, direction);
                    break;
                case "Delete": idValue = "ancDeleteDirectionLine_" + sectionNo;
                     base.WaitForElement(By.Id(idValue));
                     IWebElement deleteLink =base.GetWebElementPropertiesById(idValue);
                     base.ClickByJavaScriptExecutor(deleteLink);
                     base.WaitUntilWindowLoads("Pegasus");
                     base.GetWebElementPropertiesById("imgOk").Click();
                     break;

            }

            base.SwitchToDefaultPageContent();

           
            
        }

        private void OpenEditorAndAddDirections(string idValue, string direction)
        {
            base.WaitForElement(By.Id(idValue));
            //Click on Save and Return Button
            IWebElement addLink =
            base.GetWebElementPropertiesById(idValue);
            base.ClickByJavaScriptExecutor(addLink);
            base.WaitUntilWindowLoads("Editor");
            base.SwitchToIFrameById("ucEditor");
            base.WaitForElement(By.CssSelector(".WebEditor"));


            IWebElement textArea = base.GetWebElementPropertiesByCssSelector(".WebEditor");
            base.PerformMoveToElementClickAction(textArea);
            Actions builder = new Actions(WebDriver);
            Thread.Sleep(3000);
            builder.SendKeys(direction).Perform();
            base.SwitchToDefaultPageContent();
            base.GetWebElementPropertiesById("cmdOK").Click();
        }

        public bool VerifyTheDirectionLines(string actionType,string sectionNumber)
        {
            string expectedDirection = string.Empty;
            base.SwitchToDefaultWindow();
            //Switch to frame
            base.SwitchToIFrameById("frmTopic");
            bool directionPresent = false;
            switch (actionType)
            {
                case "added":
                    expectedDirection = "This is direction for Section " + sectionNumber;
                    break;
                case "edited":
                    expectedDirection = "This is direction for Section " + sectionNumber+" edited" ;
                    break;
            }
            string idValue="lbldirectionalline_"+sectionNumber;
            string actualDirection = base.GetElementInnerTextById(idValue).Trim();
            if (expectedDirection == actualDirection)
                directionPresent = true;
            base.SwitchToDefaultPageContent();
            return directionPresent;
          

        }

      public bool VerifyDirectionDeletion(string sectionNumber)
        {
            bool DirectionPres = true;
            base.SwitchToDefaultWindow();
            string idValue="lbldirectionalline_"+sectionNumber;
            DirectionPres = base.IsElementPresent(By.Id(idValue), 10);
            return DirectionPres;
            
        }

    }
}