using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
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
        private static Logger Logger = 
            Logger.GetInstance(typeof(Preferences));
        
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
        /// Set The Preferences For Shared Library.
        /// </summary>
        [When(@"I set the preferences for Shared Library")]
        public void SetThePreferencesForSharedLibrary()
        {
            //Set The Preferences For Shared Library
            Logger.LogMethodEntry("Preferences", 
                "SetThePreferencesForSharedLibrary",
                base.isTakeScreenShotDuringEntryExit);
            new SharedLibraryPreferencesPage().
                SetSharedLibrariesPreferences();
            Logger.LogMethodExit("Preferences", 
                "SetThePreferencesForSharedLibrary",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set The Preferences For Content In ContainerCourse.
        /// </summary>
        [When(@"I set the preferences for Content in Container course")]
        public void SetThePreferencesForContentInContainerCourse()
        {
            //Set The Preferences For Content In ContainerCourse
            Logger.LogMethodEntry("Preferences", 
                "SetThePreferencesForContentInContainerCourse",
                base.isTakeScreenShotDuringEntryExit);            
            //Set The Content Preferences For ContainerCourse
            new CourseContentPreferencesPage().
                SetTheContentPreferencesForContainerCourse();
            Logger.LogMethodExit("Preferences", 
                "SetThePreferencesForContentInContainerCourse",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Saves The Preferences.
        /// </summary>
        [When(@"I save the Preferences")]
        public void SaveThePreferences()
        {
            //Click on the Save Preferences Button
            Logger.LogMethodEntry("Preferences", 
                "SaveThePreferences", 
                base.isTakeScreenShotDuringEntryExit);
            //Save the Preferences
            new ActivitiesPreferencesPage().SaveActivityPreferences();
            Logger.LogMethodExit("Preferences", 
                "SaveThePreferences",
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
        /// Enable Necessary Grading Preference Settings.
        /// </summary>
        [When(@"I enable necessary grades preference settings")]
        public void EnableNecessaryGradingTabPreferenceSettings()
        {
            //Enable Necessary Grades Preference Settings
            Logger.LogMethodEntry("Preference",
                "EnableNecessaryGradingTabPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
            GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
            //Select Main Frame
            generalPreferencePage.SelectThePreferenceWindowWithFrame();
            //Declare object
            GradingPreferencesPage gradePreferencesPage =
                new GradingPreferencesPage();
            //Enable 'Apply Grade Schema' Option
            gradePreferencesPage.EnableApplyGradeSchemaOption();            
            //Save The Preference
            generalPreferencePage.SavePreferences();
            Logger.LogMethodExit("Preference",
                "EnableNecessaryGradingTabPreferenceSettings",
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
