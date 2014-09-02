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
    /// This class handles Create Question actions.
    /// </summary>
     public class CreateQuestionPage : BasePage
    {
        private static readonly Logger logger =
        Logger.GetInstance(typeof(CreateQuestionPage));


        /// <summary>
        /// Create New Questions from Activity.
        /// </summary>
        public void ClickOnQuestionLink(string questionName)
        {
            logger.LogMethodEntry("CreateQuestionPage",
            "ClickOnTrueFalseQuestionLink",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                //base.SelectWindow(CreateQuestionPageResource.CreateQuestionPage_Window_Title_Locator);     
                this.SelectCreateQuestionPageWindow();
                //Wait for Iframe
                base.WaitForElement(By.Id(CreateQuestionPageResource.
                CreateQuestionPage_Iframe_Id_Locator));
                //Switch to IFrame
                base.SwitchToIFrameById(CreateQuestionPageResource.
                CreateQuestionPage_Iframe_Id_Locator);
                //Get property for 'True/False' question link
                IWebElement getQuestionName = base.GetWebElementPropertiesByPartialLinkText
                (questionName);
                //Click on 'True/False' question link
                base.ClickByJavaScriptExecutor(getQuestionName);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateQuestionPage",
            "ClickOnTrueFalseQuestionLink",
            base.IsTakeScreenShotDuringEntryExit);

        }


        /// <summary>
        /// Select the Create Question Page window.
        /// </summary>
         private void SelectCreateQuestionPageWindow()
        {
            logger.LogMethodEntry("CreateQuestionPage",
          "SelectWindow",
          base.IsTakeScreenShotDuringEntryExit);
           
                //Select Window
                base.SelectWindow(CreateQuestionPageResource.
                    CreateQuestionPage_Window_Title_Locator);

          
              logger.LogMethodExit("CreateQuestionPage",
              "SelectWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify, if all native questions are present.
        /// </summary>
        public Boolean IsAllNativeQuestionsPresent()
        {
            logger.LogMethodEntry("CreateQuestionPage",
           "IsAllNativeQuestionsPresent",
           base.IsTakeScreenShotDuringEntryExit);
            bool isNativeQuestionsDisplayed = false;
            try
            {
                //Select window
                this.SelectCreateQuestionPageWindow();
                //Switch to Iframe
                base.SwitchToIFrameById(CreateQuestionPageResource.
                    CreateQuestionPage_Iframe_Id_Locator);
                //Wait for element
                base.WaitForElement(By.PartialLinkText(CreateQuestionPageResource.
                    CreateQuestionPage_FillintheBlank_PartialText_Locator));
                //Is 'Fill in the Blank' question link Displayed
                bool isFillInTheBlankDisplayed = base.IsElementPresent(By.PartialLinkText(CreateQuestionPageResource.
                    CreateQuestionPage_FillintheBlank_PartialText_Locator));
                //Is 'Matching' question link Displayed
                bool isMatchingDisplayed = base.IsElementPresent(By.PartialLinkText(CreateQuestionPageResource.
                    CreateQuestionPage_Matching_PartialText_Locator));
                //Is 'Multiple Choice' question link Displayed
                bool isMultipleChoiceDisplayed = base.IsElementPresent(By.PartialLinkText(CreateQuestionPageResource.
                    CreateQuestionPage_MultipleChoice_PartialText_Locator));
                //Is 'Multiple Response' question link Displayed
                bool isMultipleResponseDisplayed = base.IsElementPresent(By.PartialLinkText(CreateQuestionPageResource.
                    CreateQuestionPage_MultipleResponse_PartialText_Locator));                            
                //Is 'True/false' question link Displayed
                bool isTrueFalseDisplayed = base.IsElementPresent(By.PartialLinkText(CreateQuestionPageResource.
                    CreateQuestionPage_TrueFalse_PartialText_Locator));
                //Are All Native Questions Present 
                isNativeQuestionsDisplayed = isFillInTheBlankDisplayed && isMatchingDisplayed && isMultipleChoiceDisplayed &&
                   isMultipleResponseDisplayed && isTrueFalseDisplayed;
                  }                             
                    
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateQuestionPage",
            "IsAllNativeQuestionsPresent",
            base.IsTakeScreenShotDuringEntryExit);
            return isNativeQuestionsDisplayed;
        }


        /// <summary>
        /// Click on Canel button
        /// </summary>       
        public void ClickOnCancelButton()
        {

            logger.LogMethodEntry("CreateQuestionPage",
            "ClickOnCancelButton",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectCreateQuestionPageWindow();
                //Switch to Iframe
                base.SwitchToIFrameById(CreateQuestionPageResource.
                    CreateQuestionPage_Iframe_Id_Locator);
                // Wait for element
                base.WaitForElement(By.Id(CreateQuestionPageResource.
                    CreateQuestionPage_Cancel_Button_Id_Locator));
                // Get Cancel button
                IWebElement getCancelButton = base.GetWebElementPropertiesById(CreateQuestionPageResource.
                    CreateQuestionPage_Cancel_Button_Id_Locator);
                // Click on cancel button
                base.ClickByJavaScriptExecutor(getCancelButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateQuestionPage",
            "ClickOnCancelButton",
            base.IsTakeScreenShotDuringEntryExit);

        }
    }
}
