using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.LTISettings.Main.AdminMode.LTICourseToolSettings;
using Pegasus.Pages.UI_Pages.MMND.SecureEcollegeLabs.CCNG;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles IndexPage actions
    /// </summary>
    public class IndexPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(IndexPage));


        /// <summary>
        /// Get Successfull Message after course Integration
        /// </summary>
        /// <returns>Successfull Message after course Integration</returns>
        public String GetSuccessfullMessageAfterCourseIntegration()
        {
            //Get Message
            logger.LogMethodEntry("IndexPage", "GetSuccessfullMessageAfterCourseIntegration",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            string getMessage = string.Empty;
            try
            {
                //Select Window
                base.SelectWindow(IndexPageResource.Index_Page_Window_Name);
                base.WaitForElement(By.XPath(IndexPageResource.
                    Index_Page_SuccessMessage_Xpath_Locator));
                //Get Message
                getMessage = base.GetElementTextByXPath(IndexPageResource.
                    Index_Page_SuccessMessage_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                 
            }
            logger.LogMethodExit("IndexPage", "GetSuccessfullMessageAfterCourseIntegration",
            base.IsTakeScreenShotDuringEntryExit);
            return getMessage;
        }

    }
}
