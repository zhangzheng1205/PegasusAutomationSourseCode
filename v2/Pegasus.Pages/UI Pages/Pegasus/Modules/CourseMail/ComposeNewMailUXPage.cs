using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.CourseMail;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Compose New MailUX Page actions
    /// </summary>
    public class ComposeNewMailUXPage : BasePage
    {

        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(ComposeNewMailUXPage));

        /// <summary>
        /// Click On To Button
        /// </summary>
        public void ClickOnToButton()
        {
            //Click On To Button
            logger.LogMethodEntry("ComposeNewMailUXPage", "ClickOnToButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(ComposeNewMailUXPageResource.
                        ComposeNewMailUX_Page_ToButton_Id_Locator));
                //Get To Button Property 
                IWebElement getToButtonProperty = base.
                    GetWebElementPropertiesById(ComposeNewMailUXPageResource.
                    ComposeNewMailUX_Page_ToButton_Id_Locator);
                //Click On To Button
                base.ClickByJavaScriptExecutor(getToButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ComposeNewMailUXPage", "ClickOnToButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// ENter Subject Title and HTML Text
        /// </summary>
        /// <param name="mailTypeEnum">This is Mail Type Enum </param>
        public void EnterSubjectTitleAndHtmlText(Mail.MailTypeEnum mailTypeEnum)
        {
            //Enter Subject Title and HTML Text
            logger.LogMethodEntry("ComposeNewMailUXPage", "EnterSubjectTitleAndHtmlText",
                base.IsTakeScreenShotDuringEntryExit);
            //Generate Guid for Mail Details
            Guid mailDetails = Guid.NewGuid();
            try
            {
                //Select Course Mail Window
                this.SelectCourseMailWindow();
                //Select IFrame
                this.SelectIFrame();
                //Fill the Title
                this.FillTitle(mailDetails.ToString());
                //Click On View Source Button
                this.ClickOnViewSourceButton();
                //Enter HTML Text
                this.FillHtmlText(mailDetails.ToString());
                //Store Mail Details In Memory
                this.StoreMailDetailsInMemory(mailDetails, mailTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ComposeNewMailUXPage", "EnterSubjectTitleAndHtmlText",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill HTML Text
        /// </summary>
        /// <param name="mailDetails">This is Mail Details</param>
        public void FillHtmlText(string mailDetails)
        {
            //Fill HTML Text
            logger.LogMethodEntry("ComposeNewMailUXPage", "FillHtmlText",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(ComposeNewMailUXPageResource.
                        ComposeNewMailUX_Page_HTMLTextarea_Id_Locator));
                //Clear Text Box
                base.ClearTextById(ComposeNewMailUXPageResource.
                    ComposeNewMailUX_Page_HTMLTextarea_Id_Locator);
                //Fill Text Box
                base.FillTextBoxById(ComposeNewMailUXPageResource.
                    ComposeNewMailUX_Page_HTMLTextarea_Id_Locator, mailDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ComposeNewMailUXPage", "FillHtmlText",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Send Button
        /// </summary>
        public void ClickOnSendButton()
        {
            //Click On Send Button
            logger.LogMethodEntry("ComposeNewMailUXPage", "ClickOnSendButton",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(ComposeNewMailUXPageResource.
                       ComposeNewMailUX_Page_SendButton_Id_Locator));
                //Get Send Button Property 
                IWebElement getSendButtonProperty = base.GetWebElementPropertiesById
                    (ComposeNewMailUXPageResource.ComposeNewMailUX_Page_SendButton_Id_Locator);
                //Click On Send Button
                base.ClickByJavaScriptExecutor(getSendButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ComposeNewMailUXPage", "ClickOnSendButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Iframe
        /// </summary>
        private void SelectIFrame()
        {
            //Select IFrame
            logger.LogMethodEntry("ComposeNewMailUXPage", "SelectIFrame",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ComposeNewMailUXPageResource.
                ComposeNewMailUX_Page_Frame_Id_Locator));
            //Switch To IFrame
            base.SwitchToIFrameById(ComposeNewMailUXPageResource.
                ComposeNewMailUX_Page_Frame_Id_Locator);
            logger.LogMethodExit("ComposeNewMailUXPage", "SelectIFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Mail Window
        /// </summary>
        private void SelectCourseMailWindow()
        {
            //Select Course Mail Window
            logger.LogMethodEntry("ComposeNewMailUXPage", "SelectCourseMailWindow",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ComposeNewMailUXPageResource.
                ComposeNewMailUX_Page_CourseMail_Window_Name);
            //Select Course Mail Window
            base.SelectWindow(ComposeNewMailUXPageResource.
                ComposeNewMailUX_Page_CourseMail_Window_Name);
            logger.LogMethodExit("ComposeNewMailUXPage", "SelectCourseMailWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Title
        /// </summary>
        /// <param name="mailDetails">This is Mail Details</param>
        private void FillTitle(string mailDetails)
        {
            //Fill Title
            logger.LogMethodEntry("ComposeNewMailUXPage", "FillTitle",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ComposeNewMailUXPageResource.
                ComposeNewMailUX_Page_Input_SubjectTextBox_Id_Locator));
            //Clear Text Box 
            base.ClearTextById(ComposeNewMailUXPageResource.
                ComposeNewMailUX_Page_Input_SubjectTextBox_Id_Locator);
            //Fill Text Box
            base.FillTextBoxById(ComposeNewMailUXPageResource.
                ComposeNewMailUX_Page_Input_SubjectTextBox_Id_Locator, mailDetails);
            logger.LogMethodExit("ComposeNewMailUXPage", "FillTitle",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On View Source Button
        /// </summary>
        private void ClickOnViewSourceButton()
        {
            //Click On View Source Button
            logger.LogMethodEntry("ComposeNewMailUXPage", "ClickOnViewSourceButton",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ComposeNewMailUXPageResource.
                ComposeNewMailUX_Page_ViewSourceButton_Id_Locator));
            //Get View Source Button
            IWebElement getViewSourceButtonProperty = base.GetWebElementPropertiesById(
                ComposeNewMailUXPageResource.ComposeNewMailUX_Page_ViewSourceButton_Id_Locator);
            //Click On View Source Button
            base.ClickByJavaScriptExecutor(getViewSourceButtonProperty);
            logger.LogMethodExit("ComposeNewMailUXPage", "ClickOnViewSourceButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Mail Details In Memory
        /// </summary>
        /// <param name="mailDetails">This is Mail Details Guid</param>
        /// <param name="mailTypeEnum">This is Mail Type Enum</param>
        private void StoreMailDetailsInMemory(Guid mailDetails,
            Mail.MailTypeEnum mailTypeEnum)
        {
            logger.LogMethodEntry("ComposeNewMailUXPage", "StoreMailDetailsInMemory",
               base.IsTakeScreenShotDuringEntryExit);
            Mail newMail = new Mail
            {
                //Store Mail Details
                Subject = mailDetails.ToString(),
                Message = mailDetails.ToString(),
                MailType = mailTypeEnum,
                IsCreated = true
            };
            newMail.StoreMailMessageInMemory();
            logger.LogMethodExit("ComposeNewMailUXPage", "StoreMailDetailsInMemory",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Send Message Window
        /// </summary>
        private void SelectSendMessageWindow()
        {
            //Select Send Message Window
            logger.LogMethodEntry("ComposeNewMailUXPage", "SelectSendMessageWindow",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ComposeNewMailUXPageResource.
                ComposeNewMailUX_Page_SendMessage_Window_Name);
            base.SelectWindow(ComposeNewMailUXPageResource.
                ComposeNewMailUX_Page_SendMessage_Window_Name);
            logger.LogMethodExit("ComposeNewMailUXPage", "SelectSendMessageWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get 'Send' 'Save as draft' 'Cancel' button text
        /// </summary>
        /// <returns>SendSaveasdraftCa</returns>
        public String GetSendSaveasdraftCancelButtonText()
        {
            //Get 'Send' 'Saveasdraft' 'Cancel' button text
            logger.LogMethodEntry("ComposeNewMailUXPage", "GetSendSaveasdraftCancelButtonText",
              base.IsTakeScreenShotDuringEntryExit); 
            //Initialize variable
            string getSendSaveasdraftCanceltext = string.Empty;
            //Initialize variable
            string getSendtext = string.Empty;
            //Initialize variable
            string getSaveasdrafttext = string.Empty;
            //Initialize variable
            string getCanceltext = string.Empty;
            try
            {
                //Select Send Message Window
                this.SelectSendMessageWindow();
                base.WaitForElement(By.Id(ComposeNewMailUXPageResource.
                    ComposeNewMailUX_Page_Send_Id_Locator));
                //Get Send Text
                getSendtext = base.GetElementTextById(ComposeNewMailUXPageResource.
                    ComposeNewMailUX_Page_Send_Id_Locator);
                base.WaitForElement(By.Id(ComposeNewMailUXPageResource.
                    ComposeNewMailUX_Page_Saveasdraft_Id_Locator));
                //Get Save as draft text
                getSaveasdrafttext = base.GetElementTextById(ComposeNewMailUXPageResource.
                    ComposeNewMailUX_Page_Saveasdraft_Id_Locator);
                base.WaitForElement(By.Id(ComposeNewMailUXPageResource.
                    ComposeNewMailUX_Page_Cancel_Id_Locator));
                //Get Cancel text
                getCanceltext = base.GetElementTextById(ComposeNewMailUXPageResource.
                    ComposeNewMailUX_Page_Cancel_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ComposeNewMailUXPage", "GetSendSaveasdraftCancelButtonText",
              base.IsTakeScreenShotDuringEntryExit);
            return getSendSaveasdraftCanceltext = getSendtext + getSaveasdrafttext + getCanceltext;
        }
    }
}
