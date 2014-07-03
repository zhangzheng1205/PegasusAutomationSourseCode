using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.eText;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the EbookIntegrationErrorPage actions
    /// </summary>
    public class EbookIntegrationErrorPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger.
        /// </summary>
        private static readonly Logger Logger = Logger.
            GetInstance(typeof(EbookIntegrationErrorPage));

        /// <summary>
        /// Created EText Message Property.
        /// </summary>
        private string getETextMessage { get; set; }

        /// <summary>
        /// Get eText Message.
        /// </summary>
        /// <returns>This is eText Message.</returns>
        public String GetETextMessage()
        {
            //Get eText Message
            Logger.LogMethodEntry("EbookIntegrationErrorPage",
                "GeteTextMessage",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize variable
            string getElementTextByXPath = string.Empty;
            try
            {
                //Select Window
                this.SelectPearsonETextSignInPageWindow();
                base.WaitForElement(By.XPath(EbookIntegrationErrorPageResource.
                    EbookIntegrationError_Page_IAcceptButton_Xpath_Locator));
                //Get eText Message
                getElementTextByXPath = base.GetElementTextByXPath(
                    EbookIntegrationErrorPageResource.
                    EbookIntegrationError_Page_IAcceptButton_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("EbookIntegrationErrorPage", "GeteTextMessage",
               base.isTakeScreenShotDuringEntryExit);
            return getElementTextByXPath;
        }

        /// <summary>
        /// Select EText Window.
        /// </summary>
        private void SelectPearsonETextSignInPageWindow()
        {
            //Select Window
            Logger.LogMethodExit("EbookIntegrationErrorPage",
                "SelectPearsonETextSignInPageWindow",
              base.isTakeScreenShotDuringEntryExit);
            //Wait Fow Window Loads
            base.WaitUntilWindowLoads(EbookIntegrationErrorPageResource.
                                     EbookIntegrationError_Page_Window_Name);
            //Select Window
            base.SelectWindow(EbookIntegrationErrorPageResource.
                                  EbookIntegrationError_Page_Window_Name);
            Logger.LogMethodExit("EbookIntegrationErrorPage",
                "SelectPearsonETextSignInPageWindow",
              base.isTakeScreenShotDuringEntryExit);
        }
    }
}
