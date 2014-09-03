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
    }
}
