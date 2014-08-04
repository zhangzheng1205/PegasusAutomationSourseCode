using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles the Course Creation Actions.
    /// </summary>
    [Binding]
    public class CourseCreation : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(CourseCreation));

        /// <summary>
        /// Select Create Course Option.
        /// </summary>
        [When(@"I select the 'Create Course' option in 'Classes' Page")]
        public void SelectCreateCourseOption()
        {
            //Select Create Course Option
            Logger.LogMethodEntry("CourseCreation", 
                "SelectCreateCourseOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Create Course Option
            new MyClassDefaultUXPage().ClickOnCreateCourseOption();
            Logger.LogMethodExit("CourseCreation", 
                "SelectCreateCourseOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Course Using Master Libraries.
        /// </summary>
        [When(@"I create the course using master libraries")]
        public void CreateCourseUsingMasterLibraries()
        {
            //Create Course Using Master Libraries
            Logger.LogMethodEntry("CourseCreation", 
                "CreateCourseUsingMasterLibraries",
                base.IsTakeScreenShotDuringEntryExit);
            //Create the Course Using Master Libraries
            new CreateClassCoursePage().CreatetheCourseUsingMasterLibrary();
            Logger.LogMethodExit("CourseCreation", 
                "CreateCourseUsingMasterLibraries",
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
