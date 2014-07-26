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
    /// This Class Handles Message Grid Page Actions
    /// </summary>
    public class MessageGridPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(MessageGridPage));

        /// <summary>
        /// Create Mail Mesage in CourseSpace by Teacher.
        /// </summary>
        public void CreateMailMessage(User.UserTypeEnum userTypeEnum)
        {
            //Create Mail in CourseSpace
            logger.LogMethodEntry("MessageGridPage", "CreateMailMessage",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Generate Guid for Mail Details
                Guid mailDetails = Guid.NewGuid();
                //Click on Messages Link
                new HomePage().ClickOnMessagesLink(userTypeEnum);
                //Wait for Mail Light Box
                base.WaitForElement(By.Id(MessageGridPageResource.
                    MessageGrid_Page_MailLightBox_Id_Locator));
                //Switch to Mail Light Box Frame
                base.SwitchToIFrame(MessageGridPageResource.
                    MessageGrid_Page_MailLightBox_Id_Locator);
                base.WaitForElement(By.Id(MessageGridPageResource.
                    MessageGrid_Page_ComposeNewFrame_Id_Locator));
                //Switch to Compose Frame
                base.SwitchToIFrame(MessageGridPageResource.
                    MessageGrid_Page_ComposeNewFrame_Id_Locator);
                //Click on Compose Button
                base.WaitForElement(By.Id(MessageGridPageResource.
                    MessageGrid_Page_ComposeNewButton_Id_Locator));
                base.ClickButtonById(MessageGridPageResource.
                    MessageGrid_Page_ComposeNewButton_Id_Locator);
                //Enter Details to Create Mail
                this.EnterDetailsToCreateMail(mailDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MessageGridPage", "CreateMailMessage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Details to Create Mail.
        /// </summary>
        /// <param name="mailDetails">This is Mail Details Guid.</param>
        private void EnterDetailsToCreateMail(Guid mailDetails)
        {
            // Enter Details to Create Message
            logger.LogMethodEntry("MessageGridPage", "EnterDetailsToCreateMail",
                base.isTakeScreenShotDuringEntryExit);
            //Click on To Button
            base.WaitForElement(By.PartialLinkText(MessageGridPageResource.
                MessageGrid_Page_ToButton_PartialLinkText_Locator));
            base.ClickButtonByPartialLinkText(MessageGridPageResource.
                MessageGrid_Page_ToButton_PartialLinkText_Locator);
            //Switch to Mail Light Box Frame
            base.WaitForElement(By.Id(MessageGridPageResource.
                MessageGrid_Page_MailLightBox_Id_Locator));
            base.SwitchToIFrame(MessageGridPageResource.
                MessageGrid_Page_MailLightBox_Id_Locator);
            //Select Recepient by Checking the CheckBox
            base.WaitForElement(By.Id(MessageGridPageResource.
                MessageGrid_Page_SelectRecepients_CheckBox_Id_Locator));
            base.SelectCheckBoxById(MessageGridPageResource.
                MessageGrid_Page_SelectRecepients_CheckBox_Id_Locator);
            //Click on Add Recepients Button
            base.WaitForElement(By.PartialLinkText(MessageGridPageResource.
                MessageGrid_Page_SelectRecepients_AddRecepientsButton_PartialLinkText_Locator));
            base.ClickButtonByPartialLinkText(MessageGridPageResource.
                MessageGrid_Page_SelectRecepients_AddRecepientsButton_PartialLinkText_Locator);
            base.SelectWindow(MessageGridPageResource.MessageGrid_Page_Window_Title);
            //Switch to Mail Light Box Frame
            base.SwitchToIFrame(MessageGridPageResource.
                MessageGrid_Page_MailLightBox_Id_Locator);
            //Switch to Compose Frame
            base.SwitchToIFrame(MessageGridPageResource.
                MessageGrid_Page_ComposeNewFrame_Id_Locator);
            //Enter Subject and Message
            this.EnterSubjectAndMessage(mailDetails);
            logger.LogMethodExit("MessageGridPage", "EnterDetailsToCreateMail",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Subject and Message.
        /// </summary>
        /// <param name="mailDetails">This is mail details Guid.</param>
        private void EnterSubjectAndMessage(Guid mailDetails)
        {
            //Enter Subject and Message
            logger.LogMethodEntry("MessageGridPage", "EnterSubjectAndMessage",
                base.isTakeScreenShotDuringEntryExit);
            //Enter the Subject
            base.WaitForElement(By.Id(MessageGridPageResource.
                MessageGrid_Page_ComposeNewFrame_SubjectTextBox_Id_Locator));
            base.FillTextBoxById(MessageGridPageResource.
                MessageGrid_Page_ComposeNewFrame_SubjectTextBox_Id_Locator,
                mailDetails.ToString());
            //Click on View Source
            base.WaitForElement(By.Id(MessageGridPageResource.
                MessageGrid_Page_HTMLEditor_ViewSource_Id_Locator));
            base.ClickLinkById(MessageGridPageResource.
                MessageGrid_Page_HTMLEditor_ViewSource_Id_Locator);
            //Enter Message in Text Area
            base.WaitForElement(By.Id(MessageGridPageResource.
                MessageGrid_Page_HTMLEditor_TextArea_Id_Locator));
            base.FillTextBoxById(MessageGridPageResource.
                MessageGrid_Page_HTMLEditor_TextArea_Id_Locator, mailDetails.ToString());
            //Store Mail Message In Memory
            this.StoreMailDetailsInMemory(mailDetails);
            logger.LogMethodExit("MessageGridPage", "EnterSubjectAndMessage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Gets the Success Message
        /// </summary>
        /// <returns>This is SuccessMessage</returns>
        public String GetSuccessMessage()
        {
            //Gets the Success Message
            logger.LogMethodEntry("MessageGridPage", "GetSuccessMessage",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            String successMessage = string.Empty;
            try
            {
                //Selects the Window
                base.SelectWindow(MessageGridPageResource.MessageGrid_Page_Window_Title);
                //Switch to Mail Light Box Frame
                base.SwitchToIFrame(MessageGridPageResource.
                    MessageGrid_Page_MailLightBox_Id_Locator);
                base.WaitForElement(By.Id(MessageGridPageResource.
                    MessageGrid_Page_SuccessMessage_Id_Locator));
                //Get Message from Application
                successMessage = base.GetElementTextById(MessageGridPageResource.
                    MessageGrid_Page_SuccessMessage_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MessageGridPage", "GetSuccessMessage",
               base.isTakeScreenShotDuringEntryExit);
            return successMessage;
        }

        /// <summary>
        /// Close the Mail Popup
        /// </summary>
        public void CloseMailPopup()
        {
            //Close the Mail Popup
            logger.LogMethodEntry("MessageGridPage", "CloseMailPopup",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on Close Button
                base.WaitForElement(By.PartialLinkText(MessageGridPageResource.
                    MessageGrid_Page_CloseButton_PartialLinkText_Locator));
                base.ClickButtonByPartialLinkText(MessageGridPageResource.
                    MessageGrid_Page_CloseButton_PartialLinkText_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MessageGridPage", "CloseMailPopup",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Send Mail To CourseSpace Users 
        /// </summary>
        public void SendMailToCourseSpaceUsers()
        {
            //Send Mail To CourseSpace Users
            logger.LogMethodEntry("MessageGridPage", "SendMailToCourseSpaceUsers",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on Send Button
                base.WaitForElement(By.PartialLinkText(MessageGridPageResource.
                    MessageGrid_Page_SendButton_PartialLinkText_Locator));
                base.FocusOnElementByPartialLinkText(MessageGridPageResource.
                    MessageGrid_Page_SendButton_PartialLinkText_Locator);
                //Get Send Button Property
                IWebElement getSendButton = base.GetWebElementPropertiesByPartialLinkText
                    (MessageGridPageResource.MessageGrid_Page_SendButton_PartialLinkText_Locator);
                base.ClickByJavaScriptExecutor(getSendButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MessageGridPage", "SendMailToCourseSpaceUsers",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Mail Details In Memory.
        /// </summary>
        /// <param name="mailDetails">This is mail details Guid.</param>
        private void StoreMailDetailsInMemory(Guid mailDetails)
        {
            logger.LogMethodEntry("MessageGridPage", "StoreMailDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
            Mail newMail = new Mail
            {
                //Store Mail Details
                Subject = mailDetails.ToString(),
                Message = mailDetails.ToString(),
                MailType = Mail.MailTypeEnum.DPCsTeacher,
                IsCreated = true
            };
            newMail.StoreMailMessageInMemory();
            logger.LogMethodExit("MessageGridPage", "StoreMailDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Mail Message Details.
        /// </summary>
        /// <returns>Mail Message Subject Details.</returns>
        public String GetMailMessageSubject()
        {
            //Get Mail Message
            logger.LogMethodExit("MessageGridPage", "GetMailMessageSubject",
             base.isTakeScreenShotDuringEntryExit);
            string getMailMessageSubject = string.Empty;
            try
            {
                //Select Window
                base.SelectWindow(MessageGridPageResource.
                    MessageGrid_Page_OverViewWindow_Title);
                //Wait for Element
                base.WaitForElement(By.Id(MessageGridPageResource.
                    MessageGrid_Page_MailLightBox_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(MessageGridPageResource.
                    MessageGrid_Page_MailLightBox_Id_Locator);
                //Wait for Element
                base.WaitForElement(By.Id(MessageGridPageResource.
                    MessageGrid_Page_ComposeNewFrame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(MessageGridPageResource.
                    MessageGrid_Page_ComposeNewFrame_Id_Locator);
                //Wait For Element
                base.WaitForElement(By.XPath(MessageGridPageResource.
                    MessageGrid_Page_MailSubject_Grid_XPath_Locator));
                //Get Mail Message 
                getMailMessageSubject = base.GetTitleAttributeValueByXPath
                    (MessageGridPageResource.MessageGrid_Page_MailSubject_Grid_XPath_Locator);
                //Close Mail Inbox
                this.CloseMailMessageInboxFrame();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MessageGridPage", "GetMailMessageSubject",
             base.isTakeScreenShotDuringEntryExit);
            return getMailMessageSubject;
        }

        /// <summary>
        /// Close Mail Message Inbox Frame.
        /// </summary>
        private void CloseMailMessageInboxFrame()
        {
            //Click on Mail Close Button
            logger.LogMethodExit("MessageGridPage", "CloseMailMessageInboxFrame",
             base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(MessageGridPageResource.
                MessageGrid_Page_OverViewWindow_Title);
            //Wait for Element
            base.WaitForElement(By.Id(MessageGridPageResource.
                MessageGrid_Page_MailLightBox_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(MessageGridPageResource.
                MessageGrid_Page_MailLightBox_Id_Locator);
            //Wait For Element
            base.WaitForElement(By.Id(MessageGridPageResource.
                MessageGrid_Page_Close_Button_Id_Locator));
            //Get Close Button Property
            IWebElement getCloseButtonProperty = base.GetWebElementPropertiesById
                (MessageGridPageResource.MessageGrid_Page_Close_Button_Id_Locator);
            //Click on Close Button
            base.ClickByJavaScriptExecutor(getCloseButtonProperty);
            logger.LogMethodExit("MessageGridPage", "CloseMailMessageInboxFrame",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Compose New Option
        /// </summary>
        public void SelectComposeNewOption()
        {
            //Click On Compose New Option
            logger.LogMethodExit("MessageGridPage", "SelectComposeNewOption",
             base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Course Mail Window
                this.SelectCourseMailWindow();
                //Select IFrame
                this.SelectIFrame();
                //Click On Compose New Button
                this.ClickOnComposeNewButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MessageGridPage", "SelectComposeNewOption",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Seelct Course Mail Window
        /// </summary>
        private void SelectCourseMailWindow()
        {
            //Select Course Mail Window
            logger.LogMethodExit("MessageGridPage", "SelectCourseMailWindow",
             base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(MessageGridPageResource.
                MessageGrid_Page_CourseMail_Window_Name);
            //Select Course Mail Window
            base.SelectWindow(MessageGridPageResource.
                MessageGrid_Page_CourseMail_Window_Name);
            logger.LogMethodExit("MessageGridPage", "SelectCourseMailWindow",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select IFrame
        /// </summary>
        private void SelectIFrame()
        {
            //Select IFrame
            logger.LogMethodExit("MessageGridPage", "SelectIFrame",
             base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MessageGridPageResource.
                MessageGrid_Page_ComposeNewFrame_Id_Locator));
            //Switch To IFrame 
            base.SwitchToIFrameById(MessageGridPageResource.
                MessageGrid_Page_ComposeNewFrame_Id_Locator);
            logger.LogMethodExit("MessageGridPage", "SelectIFrame",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Compose New Bitton
        /// </summary>
        private void ClickOnComposeNewButton()
        {
            //Click On Compose New Button
            logger.LogMethodExit("MessageGridPage", "ClickOnComposeNewButton",
             base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MessageGridPageResource.
                MessageGrid_Page_ComposeNewButton_Id_Locator));
            //Get Compose New Button Property 
            IWebElement getComposeNewButtonProperty = base.GetWebElementPropertiesById(
                MessageGridPageResource.MessageGrid_Page_ComposeNewButton_Id_Locator);
            //Click On Compose New Button
            base.ClickByJavaScriptExecutor(getComposeNewButtonProperty);
            logger.LogMethodExit("MessageGridPage", "ClickOnComposeNewButton",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Mail Subject From Instructor
        /// </summary>
        /// <returns>Mail Subject Title</returns>
        public String GetMailSubjectFromInstructor(string mailSubject)
        {
            logger.LogMethodExit("MessageGridPage", "GetMailSubjectFromInstructor",
             base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSubjectTitle = string.Empty;
            //Select Course Mail Window
            this.SelectCourseMailWindow();
            //Select IFrame
            this.SelectIFrame();
            //Get Subject Title
            getSubjectTitle = this.GetSubjectTitle(mailSubject);           
            logger.LogMethodExit("MessageGridPage", "GetMailSubjectFromInstructor",
            base.isTakeScreenShotDuringEntryExit);
            return getSubjectTitle;
        }

        /// <summary>
        /// Get Subject Title
        /// </summary>
        /// <param name="mailSubject">This is Mail Subject</param>
        /// <returns>Subject Title</returns>
        private String GetSubjectTitle(string mailSubject)
        {
            //Get Subject Title
            logger.LogMethodExit("MessageGridPage", "GetSubjectTitle",
             base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSubjectTitle = string.Empty;
            base.WaitForElement(By.XPath(MessageGridPageResource.
                MessageGrid_Page_GetSubjectCount_Xpath_Locator));
            //Get Subject Count
            int getMailCount = base.GetElementCountByXPath(MessageGridPageResource.
                MessageGrid_Page_GetSubjectCount_Xpath_Locator);
            for (int initialValue = Convert.ToInt32(MessageGridPageResource.
                MessageGrid_Page_GetSubjectTitle_InitialValue);
                initialValue <= getMailCount; initialValue++)
            {
                base.WaitForElement(By.XPath(string.Format(MessageGridPageResource.
                    MessageGrid_Page_GetSubjectTitle_Xpath_Locator,initialValue)));
                //Get Subject Title
                getSubjectTitle = base.GetTitleAttributeValueByXPath(
                    string.Format(MessageGridPageResource.
                    MessageGrid_Page_GetSubjectTitle_Xpath_Locator,initialValue));
                if (getSubjectTitle == mailSubject)
                {
                    break;
                }
            }
            logger.LogMethodExit("MessageGridPage", "GetSubjectTitle",
            base.isTakeScreenShotDuringEntryExit);
            return getSubjectTitle;
        }
    }
}
