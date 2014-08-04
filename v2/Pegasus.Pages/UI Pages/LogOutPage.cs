using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Logout Actions.
    /// </summary>
    public class LogOutPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(LogOutPage));

        /// <summary>
        /// Click Sign out link on the page.
        /// </summary>
        /// <param name="linkSignOut">This is SingOut Link.</param>
        public void SignOutByNovaNetUser(String linkSignOut)
        {
            //Complete SingOut Process
            Logger.LogMethodEntry("LoginPage", "SignOutByNovaNetUser",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Base Page
                base.SelectDefaultWindow();
                //Wait for Element
                base.WaitForElement(By.PartialLinkText(linkSignOut));
                //Focus on Element
                base.FocusOnElementByPartialLinkText(linkSignOut);
                //Get Element Property
                IWebElement getSignOutLink = base.GetWebElementPropertiesByPartialLinkText(linkSignOut);
                //Click SignOut Link
                base.ClickByJavaScriptExecutor(getSignOutLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LoginPage", "SignOutByNovaNetUser",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
