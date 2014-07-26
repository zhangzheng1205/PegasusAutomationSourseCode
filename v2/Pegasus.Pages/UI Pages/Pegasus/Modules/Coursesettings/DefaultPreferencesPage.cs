using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Default Preferences Page Actions.
    /// </summary>
    public class DefaultPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(DefaultPreferencesPage));


        /// <summary>
        /// Get Number Of Attempts Text
        /// </summary>
        /// <returns>'Number Of Attempts' Text</returns>
        public String GetNumberOfAttemptsText()
        {
            //Get Number Of Attempts Text
            logger.LogMethodEntry("DefaultPreferencesPage", "GetNumberOfAttemptsText",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getNumberOfAttemptsText = string.Empty;
            try
            {
                base.WaitForElement(By.Id(DefaultPreferencesPageResource.
                    DefaultPreferences_Page_GetNumberOfAttemptsText_Id_Locator));
                //Get Number Of Attempts Text
                getNumberOfAttemptsText = base.GetElementTextById(DefaultPreferencesPageResource.
                    DefaultPreferences_Page_GetNumberOfAttemptsText_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("DefaultPreferencesPage", "GetNumberOfAttemptsText",
                base.isTakeScreenShotDuringEntryExit);
            return getNumberOfAttemptsText.Trim();
        }

    }
}
