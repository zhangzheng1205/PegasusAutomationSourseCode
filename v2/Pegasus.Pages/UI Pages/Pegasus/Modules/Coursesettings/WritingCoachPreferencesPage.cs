using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using System.Threading;
using System.IO;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles General Preferences Page Actions.
    /// </summary>
    public class WritingCoachPreferencesPage:BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(WritingCoachPreferencesPage));

        /// <summary>
        /// Enable Writing Assistant Preference Settings.
        /// </summary>
        public void EnableWritingAssistantPreferenceSettings()
        {
            //Enable Writing Assistant Preference Settings
            logger.LogMethodEntry("WritingCoachPreferencesPage",
            "EnableWritingAssistantPreferenceSettings", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Declare the obeject for page
                GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
                //Select the window
                generalPreferencePage.SelectThePreferenceWindowWithFrame();
                //  Enable Writing Assistant Preference Settings,send lock and checkbox id
                generalPreferencePage.EnableGeneralPreferenceSettings(
                    WritingCoachPreferencesPageResource.
                    WritingCoachPreferencesPage_WritingSpace_Lock_Id_Loctor,
                    WritingCoachPreferencesPageResource.
                    WritingCoachPreferencesPage_WritingSpace_Checkbox_Id_Loctor);
                //Save the preferences
                generalPreferencePage.SavePreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("WritingCoachPreferencesPage",
             "EnableWritingAssistantPreferenceSettings", base.isTakeScreenShotDuringEntryExit);
        }
    }
}
