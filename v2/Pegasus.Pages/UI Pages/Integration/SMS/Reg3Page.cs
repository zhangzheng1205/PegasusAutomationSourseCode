using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Integration.SMS;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Reg3Page actions
    /// </summary>
    public class Reg3Page : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(Reg3Page));

        
        /// <summary>
        /// Click On Log In Now Button
        /// </summary>
        public void ClickOnLogInNowButton()
        {
            //Click On Log In Now Button
            logger.LogMethodEntry("Reg3Page", "ClickOnLogInNowButton",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Confirmation and Summary Window
                base.SelectWindow(Reg3PageResource.
                        Reg3_Page_ConfirmationAndSummary_Window_Name);
                base.WaitForElement(By.ClassName(Reg3PageResource.
                    Reg3_Page_LogInNow_ClassName_Locator));
                //Get Log In Now Button Property
                IWebElement getLogInNowButton = GetWebElementPropertiesByClassName(Reg3PageResource.
                    Reg3_Page_LogInNow_ClassName_Locator);
                //Click On Log In Now Button
                base.ClickByJavaScriptExecutor(getLogInNowButton);
                //Wait for MyLabMasteringPearson Window
                base.WaitUntilWindowLoads(Reg3PageResource.
                    Reg3_Page_MyLabMasteringPearson_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("Reg3Page", "ClickOnLogInNowButton",
               base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
