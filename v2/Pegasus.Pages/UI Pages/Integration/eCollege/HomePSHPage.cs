using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the Home PSH Window Actions.
    /// </summary>
    public class HomePSHPage : BasePage
    {
        /// <summary>
        /// The Static instance of the Logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(HomePSHPage));

        /// <summary>
        /// Select the Administration Page link ECollege portal.
        /// </summary>
        public void SelectHomePSHPagesLink(String pshHomeLinkName)
        {
            //Select Administrative Pages Link
            Logger.LogMethodEntry("HomePSHPage", "SelectHomePSHPagesLink",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectHomePSHWindow();
                //Select SelectAdministration Pages
                base.WaitForElement(By.PartialLinkText(pshHomeLinkName));
                //Get Element Property
                IWebElement getAdministrationLinkProperty = base.
                    GetWebElementPropertiesByPartialLinkText(pshHomeLinkName);
                base.ClickByJavaScriptExecutor(getAdministrationLinkProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HomePSHPage", "SelectHomePSHPagesLink",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Home PSH Window.
        /// </summary>
        private void SelectHomePSHWindow()
        {
            //Select Admin Home Window
            Logger.LogMethodExit("HomePSHPage",
               "SelectHomePSHWindow", base.IsTakeScreenShotDuringEntryExit);
            //Select Window Gets Load
            base.WaitUntilWindowLoads(HomePSHPageResource.
                HomePSH_Page_PSHHOME_Window_Title);
            //Select Window
            base.SelectWindow(HomePSHPageResource.
                HomePSH_Page_PSHHOME_Window_Title);
            Logger.LogMethodExit("HomePSHPage",
                "SelectHomePSHWindow", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Sign Out form ECollge Portal.
        /// </summary>
        /// <param name="linkSignOut">This is sign out link.</param>
        public void SignOutByECollegeUsers(String linkName)
        {
            Logger.LogMethodEntry("HomePSHPage",
               "SignOutByECollegeUsers", base.IsTakeScreenShotDuringEntryExit);
            //Click on link available on PSH page
            this.ClickOnLinkOnPSHHomePage(linkName);
            Logger.LogMethodExit("HomePSHPage",
               "SignOutByECollegeUsers", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click on link available on PSH page.
        /// </summary>
        /// <param name="linkName">This is name of Link.</param>
        private void ClickOnLinkOnPSHHomePage(String linkName)
        {
            Logger.LogMethodEntry("HomePSHPage",
               "ClickOnLinkOnPSHHomePage", base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            //this.SelectHomePSHWindow();
            this.SwitchToDefaultWindow();
            // Wait for Signoff Link
            base.WaitForElement(By.PartialLinkText(linkName));
            IWebElement signOffElement = base.GetWebElementPropertiesByPartialLinkText(linkName);
            // Click on Signoff Link
            base.ClickByJavaScriptExecutor(signOffElement);
            Logger.LogMethodExit("HomePSHPage",
               "ClickOnLinkOnPSHHomePage", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on tab name link.
        /// </summary>
        /// <param name="linkName">This is tab name.</param>
        public void ClickOnTabLink(String linkName)
        {
            Logger.LogMethodEntry("HomePSHPage",
              "ClickOnTabLink", base.IsTakeScreenShotDuringEntryExit);
            //Click on link available on PSH page
            this.ClickOnLinkOnPSHHomePage(linkName);
            Logger.LogMethodExit("HomePSHPage",
               "ClickOnTabLink", base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
