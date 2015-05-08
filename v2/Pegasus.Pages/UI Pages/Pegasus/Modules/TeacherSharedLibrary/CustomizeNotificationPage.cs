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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeacherSharedLibrary;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles CustomizeNotification Page Actions
    /// </summary>
    public class CustomizeNotificationPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(CustomizeNotificationPage));

        /// <summary>
        /// Close the Customized Item Saved Window
        /// </summary>
        public void CloseCustomizedItemSavedWindow()
        {
            //Close the Customized Item Saved Window
            logger.LogMethodEntry("CustomizeNotificationPage", 
                "CloseCustomizedItemSavedWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(Convert.ToInt32(CustomizeNotificationPageResource.
                    CustomizeNotification_Page_Sleep));
                base.WaitUntilPopUpLoads(CustomizeNotificationPageResource.
                            CustomizeNotification_Page_Window_TitleName);
                if (IsPopupPresent(CustomizeNotificationPageResource.
                        CustomizeNotification_Page_Window_TitleName, 10))
                {                    
                    base.WaitUntilWindowLoads(CustomizeNotificationPageResource.
                            CustomizeNotification_Page_Window_TitleName);
                    //Select Window
                    base.SwitchToLastOpenedWindow();
                    //Click On Button
                    base.WaitForElement(By.PartialLinkText(CustomizeNotificationPageResource.
                        CustomizeNotification_Page_DoneButton_PartialLinkText_Locator));
                    IWebElement getDoneButton = base.GetWebElementPropertiesByPartialLinkText
                        (CustomizeNotificationPageResource.
                        CustomizeNotification_Page_DoneButton_PartialLinkText_Locator);
                    base.ClickByJavaScriptExecutor(getDoneButton);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("CustomizeNotificationPage", 
                "CloseCustomizedItemSavedWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
