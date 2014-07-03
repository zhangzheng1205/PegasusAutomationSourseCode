using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.DRT;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium;
using System.Windows.Forms;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.DRT
{
    /// <summary>
    /// This class handles Presentation Page Actions
    /// </summary>
    public class PlayerTestPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(PlayerTestPage));

        /// <summary>
        /// This function checks whether activity has been launched successfully
        /// </summary>
        /// <returns>Activity previewed or not</returns>
        public Boolean IsActivityPreviewed()
        {
            logger.LogMethodEntry("PlayerTestPage", "IsActivityPreviewed",
               base.isTakeScreenShotDuringEntryExit);
            bool isOverviewButtonShown = false;
            try
            {
                //Wait For Page To Load
                Thread.Sleep(Convert.ToInt32(PlayerTestPageResource.
                    PlayerTestPage_ThreadSleepForActivtiyLaunch_Value));
                // Select the presentation window
                base.WaitUntilWindow(PlayerTestPageResource
                    .PlayerTestPage_WindowName_Title);
                base.SelectWindow(PlayerTestPageResource
                    .PlayerTestPage_WindowName_Title);
                //checks the presence of overview button
                isOverviewButtonShown = base.IsElementPresent
                    (By.XPath(PlayerTestPageResource.PlayerTestPage_OverviewButton_Xpath_Locator));
                base.WebDriver.Close();
                Thread.Sleep(Convert.ToInt32(PlayerTestPageResource.
                    PlayerTestPage_ThreadSleep_Value));
                SendKeys.SendWait("{ENTER}");
                Thread.Sleep(Convert.ToInt32(PlayerTestPageResource
                    .PlayerTestPage_ThreadSleep_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PlayerTestPage", "IsActivityPreviewed",
              base.isTakeScreenShotDuringEntryExit);
            return isOverviewButtonShown;
        }

    }
}
