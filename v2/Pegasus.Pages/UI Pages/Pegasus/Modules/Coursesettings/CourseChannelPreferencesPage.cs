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

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Course Channel Preferences Page Actions.
    /// </summary>
    public class CourseChannelPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(CourseChannelPreferencesPage));

        /// <summary>
        /// Enable Course Channel Option.
        /// </summary>
        public void EnableCourseChannelOption()
        {
            //Enable Course Channel Option
            logger.LogMethodEntry("CourseChannelPreferencesPage", "EnableCourseChannelOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Preferences Window
                this.SelectPreferencesWindow();
                base.WaitForElement(By.Id(CourseChannelPreferencesPageResource.
                    CourseChannelPreferences_Page_CourseChannel_Preferences_Frame));
                //Switch to Frame
                base.SwitchToIFrame(CourseChannelPreferencesPageResource.
                    CourseChannelPreferences_Page_CourseChannel_Preferences_Frame);
                base.WaitForElement(By.Id(CourseChannelPreferencesPageResource.
                    CourseChannelPreferences_Page_InstructorCustomizeHomePage_Preference_Id_Locator));
                if (!base.IsElementSelectedById(CourseChannelPreferencesPageResource.
                    CourseChannelPreferences_Page_InstructorCustomizeHomePage_Preference_Id_Locator))
                {
                    //Enable 'Instructors can customize their Home Page' Option in Course Channel Preference
                    base.SelectCheckBoxById(CourseChannelPreferencesPageResource.
                    CourseChannelPreferences_Page_InstructorCustomizeHomePage_Preference_Id_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseChannelPreferencesPage", "EnableCourseChannelOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Preferences Window
        /// </summary>
        private void SelectPreferencesWindow()
        {
            logger.LogMethodEntry("CourseChannelPreferencesPage", "SelectPreferencesWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Select Preferences Window
            base.WaitUntilWindowLoads(CourseChannelPreferencesPageResource.
                CourseChannelPreferences_Page_Window_Name);
            // Select Window
            base.SelectWindow(CourseChannelPreferencesPageResource.
                CourseChannelPreferences_Page_Window_Name);
            logger.LogMethodExit("CourseChannelPreferencesPage", "SelectPreferencesWindow",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
