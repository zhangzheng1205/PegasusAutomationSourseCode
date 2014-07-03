using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    // <summary>
    /// This Class Handles GBRoasterDefaultUX Page Actions
    /// </summary>
    public class GBRoasterDefaultUXPage : BasePage
    {
        // <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(GBRoasterDefaultUXPage));

        /// <summary>
        /// Selects the Roster Window
        /// </summary>
        public void SelectRosterWindow()
        {
            //Selects the Manage Organization Window
            logger.LogMethodEntry("GBRoasterDefaultUXPage",
                "SelectRosterWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Roster Window
                base.SelectWindow(GBRoasterDefaultUXPageResource.
                    GBRoasterDefaultUX_Page_Window_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRoasterDefaultUXPage",
                "SelectRosterWindow",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
