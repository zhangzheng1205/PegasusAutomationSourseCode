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
    /// This Class Handles Lesson Plan Preferences Page Actions.
    /// </summary>
    public class LessonPlanPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(LessonPlanPreferencesPage));

        /// <summary>
        /// Click On 'Enable Instructor Only Assets' Preference Checkbox.
        /// </summary>
        public void ClickOnInstructorOnlyAssetsPreferenceCheckbox()
        {
            //Click On 'Enable Instructor Only Assets' Preference Checkbox
            logger.LogMethodEntry("LessonPlanPreferencesPage",
            "ClickOnInstructorOnlyAssetsPreferenceCheckbox",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                GeneralPreferencesPage generalPreferencesPage = new GeneralPreferencesPage();
                //Selct window and frame
                generalPreferencesPage.SelectThePreferenceWindowWithFrame();
                base.WaitForElement(By.Id(LessonPlanPreferencesPageResource.
                    LessonPlanPreferences_Page_InstructorOnlyAssets_Preference_Id_Locator));
                //Click On 'Enable Instructor Only Assets' Preference Checkbox
                base.SelectCheckBoxById(LessonPlanPreferencesPageResource.
                    LessonPlanPreferences_Page_InstructorOnlyAssets_Preference_Id_Locator);
                //Save Preferences
                generalPreferencesPage.SavePreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("LessonPlanPreferencesPage",
            "ClickOnInstructorOnlyAssetsPreferenceCheckbox",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Instructor Only Assets Preference Enabled.
        /// </summary>
        /// <returns>Instructor Only Assets Preference Status.</returns>
        public bool IsInstructorOnlyAssetsPreferenceEnabled()
        {
            //Verify Instructor Only Assets Preference Enabled
            logger.LogMethodEntry("LessonPlanPreferencesPage",
             "IsInstructorOnlyAssetsPreferenceEnabled",
             base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isInstructorOnlyAssetsPreferenceDisabled = false;
            try
            {
                //Selct window and frame
                new GeneralPreferencesPage().SelectThePreferenceWindowWithFrame();
                base.WaitForElement(By.Id(LessonPlanPreferencesPageResource.
                    LessonPlanPreferences_Page_InstructorOnlyAssets_Preference_Id_Locator));
                //Status Of 'Enable Instructor Only Assets' Preference
                isInstructorOnlyAssetsPreferenceDisabled =
                    base.IsElementEnabledById(LessonPlanPreferencesPageResource.
                    LessonPlanPreferences_Page_InstructorOnlyAssets_Preference_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("LessonPlanPreferencesPage",
            "IsInstructorOnlyAssetsPreferenceEnabled",
            base.IsTakeScreenShotDuringEntryExit);
            return isInstructorOnlyAssetsPreferenceDisabled;
        }
    }
}
