using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Location;

namespace Pegasus.Acceptance.MyItLab.GraderIT.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class contains the definitions for Preferences scenarios.
    /// </summary>
    [Binding]
    public class Preferences : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = Logger.GetInstance(typeof(Preferences));

        /// <summary>
        /// Set The Preferences For Copy Content.
        /// </summary>
        [When(@"I set the preferences for Copy Content")]
        public void SetThePreferencesForCopyContent()
        {
            //Preference settings For Copy Content
            Logger.LogMethodEntry("Preferences",
                "SetThePreferencesForCopyContent",
                base.isTakeScreenShotDuringEntryExit);
            //Set The Preferences For Copy Content
            new CourseCopyPreferencesPage().
                SetCopyContentPreference();
            Logger.LogMethodExit("Preferences",
                "SetThePreferencesForCopyContent",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Home sub tab in preference
        /// </summary>
        /// <param name="subTabName">Preference Subtab name</param>
        [When(@"I click on the ""(.*)"" tab")]
        public void ClickOnPreferenceSubTab(string subTabName)
        {
            // Select the preference sub tab
            Logger.LogMethodEntry("Preferences", "ClickOnPreferenceSubTab",
                 base.isTakeScreenShotDuringEntryExit);
            // Navigating to given prefernce tab options from preference page
            new GeneralPreferencesPage().ClickonSubTabofPreference(subTabName);
            // Select the preference sub tab
            Logger.LogMethodExit("Preferences", "ClickOnPreferenceSubTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Necessary General Preference Settings.
        /// </summary>
        [When(@"I enable necessary general preference settings")]
        public void EnableNecessaryGeneralPreferenceSettings()
        {
            //Enable Necessary General Preference Settings
            Logger.LogMethodEntry("Preference",
                "EnableNecessaryGeneralPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
            //Enable General Preference Settings
            new GeneralPreferencesPage().EnableGeneralPreferenceSettings();
            Logger.LogMethodExit("Preference",
                "EnableNecessaryGeneralPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Necessary Catalog Preference Settings.
        /// </summary>
        [When(@"I enable necessary catalog preference settings")]
        public void EnableNecessaryCatalogPreferenceSettings()
        {
            //Enable Necessary Catalog Preference Settings
            Logger.LogMethodEntry("Preference",
                "EnableNecessaryCatalogPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
            //Enable Catalog Preference Settings
            new CatalogPreferencesPage().EnableCatalogPreferenceSettings();
            Logger.LogMethodExit("Preference",
                "EnableNecessaryCatalogPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Disable 'Hide MyCourse Materials on Creation' Preference.
        /// </summary>
        [When(@"I disable 'Hide My Course materials on creation' preference")]
        public void DisableHideMyCourseMaterialsonCreationPreference()
        {
            //Disable 'Hide MyCourse Materials on Creation' Preference
            Logger.LogMethodEntry("Preference",
                "DisableHideMyCourseMaterialsonCreationPreference",
                base.isTakeScreenShotDuringEntryExit);
            //Disable 'Hide MyCourse Materials on Creation' Preference
            new CourseMaterialPreferencePage().
                DisableHideMyCourseMaterialsPreference();
            Logger.LogMethodExit("Preference",
                "DisableHideMyCourseMaterialsonCreationPreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Necessary Grading Preference Settings.
        /// </summary>
        [When(@"I enable necessary grades preference settings")]
        public void EnableNecessaryGradingPreferenceSettings()
        {
            //Enable Necessary Grades Preference Settings
            Logger.LogMethodEntry("Preference",
                "EnableNecessaryGradingPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
            //Declare object
            GradingPreferencesPage gradePreferencesPage =
                new GradingPreferencesPage();
            //Select Grade Sub Tab Frame
            gradePreferencesPage.SelectGradeSubTabFrame();
            //Enable 'Apply Grade Schema' Option
            gradePreferencesPage.EnableApplyGradeSchemaOption();
            //Enable Folder level Calculation checkbox
            gradePreferencesPage.EnableFolderLevelCalculationCheckbox();
            //Save The Preference
            new GeneralPreferencesPage().SavePreferences();
            Logger.LogMethodExit("Preference",
                "EnableNecessaryGradingPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable 'Enable SIM5 Questions' Preference.
        /// </summary>
        [When(@"I enable 'Enable SIM5 questions' preference")]
        public void EnableSIM5QuestionsPreference()
        {
            //Enable 'Enable SIM5 Questions' Preference
            Logger.LogMethodEntry("Preference", "EnableSIM5QuestionsPreference",
                base.isTakeScreenShotDuringEntryExit);
            //Enable 'Enable SIM5 Questions' Preference
            new QuestionsPreferencesPage().EnableSIM5QuestionsPreference();
            Logger.LogMethodExit("Preference", "EnableSIM5QuestionsPreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable 'Grader Project' Question Type Preference.
        /// </summary>
        [When(@"I enable 'Grader Project' question type preference")]
        public void EnableGraderProjectQuestionTypePreference()
        {
            //Enable 'Grader Project' Question Type Preference
            Logger.LogMethodEntry("Preference",
                "EnableGraderProjectQuestionTypePreference",
                base.isTakeScreenShotDuringEntryExit);
            //Enable 'Grader Project' Question Type Preference
            new QuestionsPreferencesPage().EnableGraderProjectQuestionTypePreference();
            Logger.LogMethodExit("Preference",
                "EnableGraderProjectQuestionTypePreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable 'Display Integrity detection to students
        /// automatically for Grader projects' Preference.
        /// </summary>
        [When(@"I enable 'Display Integrity detection to students automatically for Grader projects' preference")]
        public void EnableDisplayIntegrityDetectionPreference()
        {
            //Enable 'Display Integrity detection to students
            //automatically for Grader projects' Preference
            Logger.LogMethodEntry("Preference",
                "EnableDisplayIntegrityDetectionPreference",
                base.isTakeScreenShotDuringEntryExit);
            //Enable 'Display Integrity detection to students
            //automatically for Grader projects' Preference
            new GradingPreferencesPage().EnableDisplayIntegrityDetectionPreference();
            Logger.LogMethodExit("Preference",
                "EnableDisplayIntegrityDetectionPreference",
                base.isTakeScreenShotDuringEntryExit);
        }        
    }
}
