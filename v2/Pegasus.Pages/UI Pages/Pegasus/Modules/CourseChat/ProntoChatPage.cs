using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.CourseChat;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Pronoto Chat Page actions
    /// </summary>
    public class ProntoChatPage : BasePage
    {

        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(ProntoChatPage));


        /// <summary>
        /// Click On Mail Option
        /// </summary>
        public void ClickOnMailOption()
        {
            //Click On Mail Option
            logger.LogMethodEntry("ProntoChatPage",
                "ClickOnMailOption",
                base.isTakeScreenShotDuringEntryExit);
            //Select Communicate Window
            this.SelectCommunicateWindow();
            //Click On Mail Button
            this.ClickOnMailButton();
            logger.LogMethodExit("ProntoChatPage",
                "ClickOnMailOption",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Communicate Window
        /// </summary>
        private void SelectCommunicateWindow()
        {
            //Select Communicate Window
            logger.LogMethodEntry("ProntoChatPage",
                "SelectCommunicateWindow",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ProntoChatPageResource.
                ProntoChat_Page_Communicate_Window_Name);
            //Select Communicate Window
            base.SelectWindow(ProntoChatPageResource.
                ProntoChat_Page_Communicate_Window_Name);
            logger.LogMethodExit("ProntoChatPage",
                "SelectCommunicateWindow",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On mail Button
        /// </summary>
        private void ClickOnMailButton()
        {
            //Click On Mail Button
            logger.LogMethodEntry("ProntoChatPage",
                "ClickOnMailButton",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Name(ProntoChatPageResource.
                PronotoChat_Page_MailButton_Name_Locator));
            //Get Mail Button Property
            IWebElement getMailButtonProperty = base.GetWebElementPropertiesByName
                (ProntoChatPageResource.PronotoChat_Page_MailButton_Name_Locator);
            base.ClickByJavaScriptExecutor(getMailButtonProperty);
            logger.LogMethodExit("ProntoChatPage",
                "ClickOnMailButton",
                 base.isTakeScreenShotDuringEntryExit);
        }
    }
}
