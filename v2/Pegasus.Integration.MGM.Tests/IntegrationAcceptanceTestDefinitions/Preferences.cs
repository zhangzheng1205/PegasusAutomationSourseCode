using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Integration.DigitalPath.Rumba.Tests.IntegrationAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MGM.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of Preferences page 
    /// and handles Pegasus Course Prefences Page Actions.
    /// </summary>
    [Binding]
    public class Preferences : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(Preferences));

        /// <summary>
        /// Set The LTI Tools Preferences For The Course.
        /// </summary>
        [When(@"I set the LTI Tools preferences in the Master Course for MGM")]
        public void SetTheLtiToolsPreferences()
        {
            //To Set The LTI Tools Preferences For The Course
            Logger.LogMethodEntry("Preferences", "SetTheLtiToolsPreferences",
                base.IsTakeScreenShotDuringEntryExit);
            // Set The LTI Tools Preference
            new LTIToolsPreferencesPage().EnableMGMMathXlInLtiTools();
            Logger.LogMethodExit("Preferences", "SetTheLtiToolsPreferences",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set The Standards and Skills Preferences For The Course.
        /// </summary>
        [When(@"I set the Standards and Skills preference in the Mastercourse for MGM")]
        public void SetTheStandardsAndSkillsPreference()
        {
            //To Set The Standards and Skills Preferences For The Course
            Logger.LogMethodEntry("Preferences", "SetTheStandardsAndSkillsPreference",
                base.IsTakeScreenShotDuringEntryExit);
            GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
            //Select Main Frame
            generalPreferencePage.SelectThePreferenceWindowWithFrame();
            //Set The Course Standard Skill Preferences
            new StandardSkillPreferencesPage().SetTheCourseStandardSkillPreferences
                (PreferencesResource.PreferencesPage_SkillFramework_Name,
                PreferencesResource.PreferencesPage_StandardFramework_Name);
            generalPreferencePage.SavePreferences();
            Logger.LogMethodExit("Preferences", "SetTheStandardsAndSkillsPreference",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
