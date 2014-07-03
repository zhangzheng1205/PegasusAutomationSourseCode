#region

using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of Preferences page 
    /// and handles Pegasus Course Prefences Page Actions.
    /// </summary>
    [Binding]
    public class Preferences : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
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
                base.isTakeScreenShotDuringEntryExit);
            // Set The LTI Tools Preference
            new LTIToolsPreferencesPage().EnableMGMMathXlInLtiTools();
            Logger.LogMethodExit("Preferences", "SetTheLtiToolsPreferences",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// click on Home sub tab in preference.
        /// </summary>
        /// <param name="subTabName">This is Subtab name.</param>
        [When(@"I click on the ""(.*)"" tab")]
        public void ClickOnTheHomeTab(string subTabName)
        {
            //Navigating to 'Home' sub tab
            Logger.LogMethodEntry("Preferences", "ClickOnTheHomeTab",
                 base.isTakeScreenShotDuringEntryExit);
            //Navigating to 'Home' sub tab options from preference page
            new GeneralPreferencesPage().ClickonSubTabofPreference(subTabName);
            Logger.LogMethodExit("Preferences", "ClickOnTheHomeTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set The Standards and Skills Preferences For The Course.
        /// </summary>
        [When(@"I set the Standards and Skills preference in the Mastercourse for MGM")]
        public void SetTheStandardsAndSkillsPreference()
        {
            //To Set The Standards and Skills Preferences For The Course
            Logger.LogMethodEntry("Preferences","SetTheStandardsAndSkillsPreference",
                base.isTakeScreenShotDuringEntryExit);
            // Set The Standards and Skills Preference
            GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
            //Select Main Frame
            generalPreferencePage.SelectThePreferenceWindowWithFrame();
            //Set The Course Standard Skill Preferences
            new StandardSkillPreferencesPage().SetTheCourseStandardSkillPreferences
                (PreferencesResource.PreferencesPage_SkillFramework_Name,
                PreferencesResource.PreferencesPage_StandardFramework_Name);
            generalPreferencePage.SavePreferences();
            Logger.LogMethodExit("Preferences", "SetTheStandardsAndSkillsPreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set the LTI Option For MGM Test Activities.
        /// </summary>
        [When(@"I set the 'Allow activity to be used as a pre-test or a post-test' option for MGM Test activities")]
        public void SetTheLTIOptionForMGMTestActivities()
        {
            //To Set the LTI Option For MGM Test Activities
            Logger.LogMethodEntry("Preferences", "SetTheLTIOptionForMGMTestActivities",
                base.isTakeScreenShotDuringEntryExit);
            //Set The LTI Option for MGM Test Activities
            new ActivitiesPreferencesPage().
                SelectAllowActivityToBeUsedAsPretestOrPosttestOption();
            Logger.LogMethodExit("Preferences", "SetTheLTIOptionForMGMTestActivities",
                base.isTakeScreenShotDuringEntryExit);
        }

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
        /// Set The Preferences For Custom Content.
        /// </summary>
        [When(@"I set the preferences for Custom Content")]
        public void SetThePreferencesForCustomContent()
        {
            //Set Preference settings For Custom Content
            Logger.LogMethodEntry("Preferences",
                "SetThePreferencesForCustomContent",
                base.isTakeScreenShotDuringEntryExit);
            //Set The Preferences For Custom Content
            new CustomContentPreferencesPage().
                SetCustomContentPreferences();
            Logger.LogMethodExit("Preferences",
                "SetThePreferencesForCustomContent",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set The Preferences For My Course
        /// </summary>
        [When(@"I set the preferences for My Course")]
        public void SetThePreferencesForMyCourse()
        {
            //Set The Preferences For My Course
            Logger.LogMethodEntry("Preferences",
                "SetThePreferencesForMyCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Set The Preferences For My Course
            new MyCoursesPreferencesPage().SetMyCoursesPreferences();
            Logger.LogMethodExit("Preferences",
                "SetThePreferencesForMyCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set The Preferences For Content
        /// </summary>
        [When(@"I set the preferences for Content")]
        public void SetThePreferencesForContent()
        {
            //Set The Preferences For Content
            Logger.LogMethodEntry("Preferences",
                "SetThePreferencesForContent",
                 base.isTakeScreenShotDuringEntryExit);
            //Set The Preferences For Content
            new CourseContentPreferencesPage().
                SetTheContentPreferences();
            Logger.LogMethodExit("Preferences",
                "SetThePreferencesForContent",
                 base.isTakeScreenShotDuringEntryExit);
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
