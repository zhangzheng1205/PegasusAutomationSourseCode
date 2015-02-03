using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.Mathxl;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the OverviewTest Page Ui Actions.
    /// </summary>
    public class OverviewTestPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(OverviewTestPage));

        /// <summary>
        /// Get The Page Name.
        /// </summary>
        /// <param name="expectedPageName">This is Expected Page Name.</param>
        /// <returns>Page Title.</returns>
        public string GetPageName(string expectedPageName)
        {
            // page name
            Logger.LogMethodEntry("OverviewTestPage", "GetPageName",
                      base.IsTakeScreenShotDuringEntryExit);
            string pageTitle = string.Empty;
            try
            {
                // select window
                this.SelectExpectedWindow(expectedPageName);
                pageTitle = base.GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("OverviewTestPage", "GetPageName",
                      base.IsTakeScreenShotDuringEntryExit);
            return pageTitle;
        }

        /// <summary>
        /// Get Button Name.
        /// </summary>
        /// <returns>Button Name.</returns>
        public string GetButtonName()
        {
            // button name
            Logger.LogMethodEntry("OverviewTestPage", "GetButtonName",
                      base.IsTakeScreenShotDuringEntryExit);
            IWebElement webElementButtonName = null;
            try
            {
                webElementButtonName = base.GetWebElementPropertiesById(OverviewTestPageResource
                    .OverviewTest_Page_ButtonClose_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("OverviewTestPage", "GetButtonName",
                      base.IsTakeScreenShotDuringEntryExit);
            return webElementButtonName.Text;
        }

        /// <summary>
        /// Select Expected Opened Window.
        /// </summary>
        /// <param name="expectedPageName">This is expected page name.</param>
        private void SelectExpectedWindow(string expectedPageName)
        {
            // select expected window
            Logger.LogMethodEntry("OverviewTestPage", "SelectExpectedWindow",
                     base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(expectedPageName);
            base.SelectWindow(expectedPageName);
            base.MaximizeWindow();
            Logger.LogMethodExit("OverviewTestPage", "SelectExpectedWindow",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Click On Button In Page.
        /// </summary>
        /// <param name="clickToButtonName">This is button name.</param>
        /// <param name="pageName">This is page name.</param>
        public void ClickOnButtonInPage(string clickToButtonName, string pageName)
        {
            // click on button in page
            Logger.LogMethodEntry("OverviewTestPage", "ClickOnButtonInPage",
                    base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // page name
                switch (pageName)
                {
                    case "Test Summary":
                        // button name
                        switch (clickToButtonName)
                        {
                            case "Close":
                                IWebElement webElementButtonName = base.GetWebElementPropertiesById(OverviewTestPageResource
                                    .OverviewTest_Page_ButtonClose_Id_Locator);
                                base.ClickByJavaScriptExecutor(webElementButtonName);
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("OverviewTestPage", "ClickOnButtonInPage",
                    base.IsTakeScreenShotDuringEntryExit);

        }
    }
}
