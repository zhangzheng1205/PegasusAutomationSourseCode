using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Common;
using System.Threading;


namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation.AutoGrader
{
    public class PresentationPage : BasePage
    {

        By download1CssSelector = By.CssSelector(".btn.btn-default.btn-sm.bottom-align-text.gd_well1_buttonText");
        By download2CssSelector = By.CssSelector(".btn.btn-primary.btn-sm.gt_download_all.paddClose");
        By chooseFileCssSelector=By.CssSelector("#btnChooseFile");
        By uploadFileCssSelector = By.CssSelector("#btnUpload");
        By closeDownloadCssSelector = By.CssSelector(".btn.btn-default.btn-sm.paddClose.gd_downloadPopUp_closeText");
        By submitCssSelector = By.CssSelector("#btn_gd_submission");
        By closeAssignmentCssSelector = By.CssSelector("#btnCloseAssignment");
        By progressBarColorCssSelector = By.CssSelector("div[id='downloadall_progress_bar'][style*='green']");
        By uploadSuccessMessageCssSelector = By.CssSelector(".Messagealert.alert-success.hyphenate");
        By submissionSuccessMessageCssSelector = By.CssSelector(".alert.alert-success.gd_submission_success_msg");

        // <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(PresentationPage));

        /// <summary>
        /// Gets text on Get Download Files button.
        /// </summary>
        /// <returns>Get Download Files button Text</returns>
        public string GetDownloadFilesButtonText()
        {
            // Validate the button existance and return the 
            //text of Get Download Files button
            string getDownloadFilesButtonText = string.Empty;
            logger.LogMethodEntry("PresentationPage",
               "GetDownloadFilesButtonText",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for Window Load
            base.WaitUntilWindowLoads(PresentationPageResource.
                      PresentationPage_Page_Title_Value);
            //Select Presentation Page window
            base.SelectWindow(PresentationPageResource.
                      PresentationPage_Page_Title_Value);
            //Wait for Download button to load
            base.WaitForElement(By.PartialLinkText(PresentationPageResource
                .PresentationPage_Page_DownloadButton_Title_Value));
            // Gets text on Get Download Files button
            getDownloadFilesButtonText = base.GetElementTextByPartialLinkText
                (PresentationPageResource
                .PresentationPage_Page_DownloadButton_Title_Value);
            logger.LogMethodExit("PresentationPage",
               "GetDownloadFilesButtonText",
               base.IsTakeScreenShotDuringEntryExit);
            return getDownloadFilesButtonText;
        }

        /// <summary>
        /// Click Submit button.
        /// </summary>
        public void ClickSubmitButton()
        {
            // Wait for Submit button to load and click on the Submit button
            logger.LogMethodEntry("PresentationPage",
               "ClickSubmitButton",
               base.IsTakeScreenShotDuringEntryExit);
            base.SelectWindow(PresentationPageResource.
                      PresentationPage_Page_Title_Value);
            base.WaitForElement(By.Id(PresentationPageResource.
                PresentationPage_Page_Submit_Button_Id));
            IWebElement getSubmitButtonID = base.GetWebElementPropertiesById
                (PresentationPageResource.PresentationPage_Page_Submit_Button_Id);
            base.ClickByJavaScriptExecutor(getSubmitButtonID);
            Thread.Sleep(Convert.ToInt32(PresentationPageResource.
                PresentationPage_Page_Element_WaitTime_Value));
            logger.LogMethodExit("PresentationPage",
               "ClickSubmitButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Gets text on Upload Completed File button.
        /// </summary>
        /// <returns>Return text of Get Upload Completed File Button</returns>
        public string GetUploadCompletedFileButtonText()
        {
            //Wait for Upload Completed File Button to load and return the text value
            string uploadCompletedFileButtonText = string.Empty;
            logger.LogMethodEntry("PresentationPage",
               "GetUploadCompletedFileButtonText",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Presentation Page window
            base.SelectWindow(PresentationPageResource.
                                  PresentationPage_Page_Title_Value);
            base.WaitForElement(By.PartialLinkText(PresentationPageResource.
                PresentationPage_Page_UploadCompleteButton_Title_Value));
            uploadCompletedFileButtonText = base.GetElementTextByPartialLinkText
                (PresentationPageResource.PresentationPage_Page_UploadCompleteButton_Title_Value);
            logger.LogMethodExit("PresentationPage",
               "GetUploadCompletedFileButtonText",
               base.IsTakeScreenShotDuringEntryExit);
            return uploadCompletedFileButtonText;
        }

        /// <summary>
        ///  Validate The Message On the Copy as Section Popup Page
        /// </summary>
        public Boolean ValidateTheMessageOnPopupPage(string message)
        {
            //To Validate The Message On the Copy as Section Popup Page
            logger.LogMethodEntry("PresentationPage", "ValidateTheMessageOnPopupPage",
            base.IsTakeScreenShotDuringEntryExit);

            //Initialize Variable
            bool IsTrue = false; ;
            try
            {
                //TO select the pop window so as to set focus to its elements.
                base.SelectWindow(PresentationPageResource.
                    PresentationPage_Page_Title_Value);
                //Check the message excpected and obtained are same
                IsTrue = base.IsElementContainsTextById(PresentationPageResource.
                    PresentationPage_Page_Table_Id_Locator, message);
            }
            //Exception Handling
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PresentationPage", "ValidateTheMessageOnPopupPage",
            base.IsTakeScreenShotDuringEntryExit);

            return IsTrue;
        }

        /// <summary>
        /// Clicks Download Files button.
        /// </summary>
        public void ClickDownloadFilesButton()
        {
            // Clicks Download Files button.
            logger.LogMethodEntry("PresentationPage",
              "ClickDownloadFilesButton",
              base.IsTakeScreenShotDuringEntryExit);
            base.SelectWindow(PresentationPageResource.
                      PresentationPage_Page_Title_Value);
            base.WaitForElement(By.Id(PresentationPageResource
                .PresentationPage_Page_Download_Button_Id));
            //Clicks Download Files button base on the ID
            IWebElement alertDownloadFilesButton = base.GetWebElementPropertiesById
                (PresentationPageResource
                .PresentationPage_Page_Download_Button_Id);
            base.ClickByJavaScriptExecutor(alertDownloadFilesButton);
            logger.LogMethodExit("PresentationPage",
              "ClickDownloadFilesButton",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Clicks Upload Completed File button.
        /// </summary>
        public void ClickUploadCompletedFileButton()
        {
            // Clicks Upload Completed File button
            logger.LogMethodEntry("PresentationPage",
              "ClickUploadCompletedFile",
              base.IsTakeScreenShotDuringEntryExit);
            base.SelectWindow(PresentationPageResource.
                      PresentationPage_Page_Title_Value);
            base.WaitForElement(By.Id(PresentationPageResource
                .PresentationPage_Page_UploadComplete_Button_Id));
            //Clicks Upload Completed File button based on the button ID
            IWebElement alertUploadCompletedFileButton = base.GetWebElementPropertiesById
                (PresentationPageResource
                .PresentationPage_Page_UploadComplete_Button_Id);
            base.ClickByJavaScriptExecutor(alertUploadCompletedFileButton);
            logger.LogMethodExit("PresentationPage",
              "ClickUploadCompletedFile",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Validation message displayed on the Presentation popup
        /// </summary>
        /// <param name="message">Validation message displayed on the Popup</param>
        /// <param name="pageName">Presentation page name</param>
        /// <returns>validation message existance</returns>
        public bool ValidateTheMessageOnPopupPage(string message, string pageName)
        {
            //To Validate The Message On the Copy as Section Popup Page
            logger.LogMethodEntry("PresentationPage", "ValidateTheMessageOnPopupPage",
            base.IsTakeScreenShotDuringEntryExit);

            //Initialize Variable
            bool IsTrue = false; ;
            try
            {
                //TO select the pop window so as to set focus to its elements.
                base.WaitUntilWindowLoads(pageName);
                base.SelectWindow(pageName);
                switch (pageName)
                {
                    case "Test Presentation":
                        //Check the message excpected and obtained are same
                        IsTrue = base.IsElementContainsTextById(PresentationPageResource.
                                 PresentationPage_Page_Table_Id_Locator, message);
                        break;
                    case "Test Feedback":
                        //Check the message excpected and obtained are same
                        IsTrue = base.IsElementContainsTextById(GraderFeedbackResource.
                            GraderFeedbackResource_Page_Table_Id_Locator, message);
                        break;
                }
            }
            //Exception Handling
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PresentationPage", "ValidateTheMessageOnPopupPage",
            base.IsTakeScreenShotDuringEntryExit);
            return IsTrue;
        }

        /// <summary>
        /// Click on Button on basis of button text.
        /// </summary>
        /// <param name="buttonText"></param>
        public void ClickButton(string buttonText)
        {
            logger.LogMethodEntry("PresentationPage", "ClickButton",
           base.IsTakeScreenShotDuringEntryExit);
            // Click on Button on basis of button text
            try
            {
                IWebElement buttonElement = null;
                switch (buttonText)
                {

                    case "Download Materials":
                        base.WaitForElement(download1CssSelector);
                        buttonElement = base.GetWebElementProperties(download1CssSelector);
                        break;
                    case "Choose File":
                        base.WaitForElement(chooseFileCssSelector);
                        buttonElement = base.GetWebElementProperties(chooseFileCssSelector);
                        break;
                    case "Download All Files":
                        base.WaitForElement(download2CssSelector);
                        buttonElement = base.GetWebElementProperties(download2CssSelector);
                        break;
                    case "Close":
                        base.WaitForElement(closeDownloadCssSelector);
                        buttonElement = base.GetWebElementProperties(closeDownloadCssSelector);
                        break;
                    case "Submit for Grading":
                        base.WaitForElement(submitCssSelector);
                        buttonElement = base.GetWebElementProperties(submitCssSelector);
                        break;
                    case "Close Assignment":
                        base.WaitForElement(closeAssignmentCssSelector);
                        buttonElement = base.GetWebElementProperties(closeAssignmentCssSelector);
                        break;
                    case "Upload":
                        base.WaitForElement(uploadFileCssSelector);
                        buttonElement = base.GetWebElementProperties(uploadFileCssSelector);
                        break;
                }
                //Click Button
                buttonElement.Click();
            }
            catch (Exception e)
            {
                
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PresentationPage", "ClickButton",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Return button validation bool value .
        /// </summary>
        /// <param name="expectedDownloadButton"> this is expected Download Button.</param>
        /// <param name="expectedUploadButton">This is expected Uopload Button.</param>
        /// <returns></returns>
        public bool VerifyTestPresentationPageButtons(string expectedDownloadButton,string expectedUploadButton)
        {
            logger.LogMethodEntry("PresentationPage", "VerifyTestPresentationPageButtons",
            base.IsTakeScreenShotDuringEntryExit);
            //Return button validation bool value
            bool buttonsPresent = false;
            try
            {
                Thread.Sleep(15000);
                base.SwitchToLastOpenedWindow();
                bool downloadPresent = false;
                bool uploadPresent = false;
                //Verify download and upload buttons
                downloadPresent = base.IsElementPresent(download1CssSelector, 10);
                uploadPresent = base.IsElementPresent(chooseFileCssSelector, 10);
                if (downloadPresent & uploadPresent)
                {
                    buttonsPresent = true;
                }
            }
            catch (Exception e)
            {
                
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PresentationPage", "VerifyTestPresentationPageButtons",
           base.IsTakeScreenShotDuringEntryExit);
            //Return button validation bool value
            return buttonsPresent;
        }

        /// <summary>
        /// Returns Bool value of Download Progressbar Color .
        /// </summary>
        /// <returns>This is bool value.</returns>
        public bool VerifyDownloadProgressBarColor()
        {
            logger.LogMethodEntry("PresentationPage", "VerifyDownloadProgressBarColor",
            base.IsTakeScreenShotDuringEntryExit);
            bool isGreen = false;
            try
            {
                //Returns Bool value of Download Progressbar Color
                isGreen = base.IsElementPresent(progressBarColorCssSelector, 15);
            }
            catch (Exception e)
            {
                
                 ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PresentationPage", "VerifyDownloadProgressBarColor",
            base.IsTakeScreenShotDuringEntryExit);
            //Returns Bool value of Download Progressbar Color
            return isGreen;

        }

        /// <summary>
        /// Returns Bool value of Upload Success Message.
        /// </summary>
        /// <returns>This is bool value.</returns>
        public bool VerifySuccessfulUpload()
        {
            logger.LogMethodEntry("PresentationPage", "VerifySuccessfulUpload",
           base.IsTakeScreenShotDuringEntryExit);
            bool uploadCompleted = false;
            try
            {
                //Returns Bool value of Upload Success Message
                uploadCompleted = base.IsElementPresent(uploadSuccessMessageCssSelector, 20);
            }
            catch (Exception e)
            {
                
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PresentationPage", "VerifySuccessfulUpload",
          base.IsTakeScreenShotDuringEntryExit);
            //Returns Bool value of Upload Success Message
            return uploadCompleted;
        }

        /// <summary>
        /// Returns Bool value of Submission Success Message.
        /// </summary>
        /// <returns>This is bool value.</returns>
        public bool VerifySuccessfulSubmission()
        {
            logger.LogMethodEntry("PresentationPage", "VerifySuccessfulSubmission",
          base.IsTakeScreenShotDuringEntryExit);
            bool submissionCompleted = false;
            try
            {
                //Returns Bool value of Submission Success Message
                submissionCompleted = base.IsElementPresent(submissionSuccessMessageCssSelector, 20);
            }
            catch (Exception e)
            {
                
                 ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PresentationPage", "VerifySuccessfulSubmission",
          base.IsTakeScreenShotDuringEntryExit);
            //Returns Bool value of Submission Success Message
            return submissionCompleted;
        }
    }
}
