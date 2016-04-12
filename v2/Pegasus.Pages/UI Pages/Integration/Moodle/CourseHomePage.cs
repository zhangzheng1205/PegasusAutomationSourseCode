using Pearson.Pegasus.TestAutomation.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;


namespace Pegasus.Pages.UI_Pages.Integration.Moodle
{
    public class CourseHomePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(CourseHomePage));

        /// <summary>
        /// Click on the link
        /// </summary>
        /// <param name="linkName">This is the link name.</param>
        /// <param name="pageName">This is the page name.</param>
        public void ClickLinkInMMNDPage(string linkName, string pageName)
        {
            // Click on the link
            logger.LogMethodEntry("CourseHomePage", "ClickLinkMMND", base.IsTakeScreenShotDuringEntryExit);
            // Wait untill window load
            base.WaitUntilWindowLoads(pageName);
            base.SelectWindow(pageName);
            // Wait for the link and click on the link
            base.WaitForElement(By.PartialLinkText(linkName));
            base.ClickLinkByPartialLinkText(linkName);
            logger.LogMethodExit("CourseHomePage", "ClickLinkMMND", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the link n pearson link page
        /// </summary>
        /// <param name="linkName">This is the link name.</param>
        /// <param name="pageName">This is the page name.</param>
        public void ClickLinkInPearsonLinkPage(string linkName, string pageName)
        {
            logger.LogMethodEntry("CourseHomePage", "ClickLinkInPearsonLinkPage", base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(pageName);
            base.SelectWindow(pageName);
            // Switch to Iframe by ID value
            base.WaitForElement(By.Id("centerIframe"));
            base.SwitchToIFrameById("centerIframe");
            // Click link by partial link text
            base.WaitForElement(By.PartialLinkText(linkName));
            base.ClickLinkByPartialLinkText(linkName);
            base.AcceptAlert();
            // Wait untill the new popup is loaded
            Thread.Sleep(30000);

            logger.LogMethodExit("CourseHomePage", "ClickLinkInPearsonLinkPage", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}