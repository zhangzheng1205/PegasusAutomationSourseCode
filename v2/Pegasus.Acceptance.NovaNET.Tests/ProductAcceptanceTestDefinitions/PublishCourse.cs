using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.NovaNET.Tests.Definitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    [Binding]
    public class PublishCourse : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger
        /// </summary> 
        private static Logger Logger = 
            Logger.GetInstance(typeof(PublishCourse));

        /// <summary>
        /// Publish the Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <param name="cmenuOptionName">This is cmenu option name.</param>
        [When(@"I publish the ""(.*)"" course in workspace as ""(.*)""")]
        public void PublishTheCourse(
            Course.CourseTypeEnum courseTypeEnum,
            string cmenuOptionName)
        {
            //To publish course
            Logger.LogMethodEntry("PublishCourse", "PublishTheCourse",
         base.isTakeScreenShotDuringEntryExit);
            //Click on Course Cmenu Option
            new ManageCoursesPage().ClickCourseCMenuOption(PublishCourseResource.
                PublishCourse_CmenuOption_Publish_Keyword + cmenuOptionName);
            //Course published successfully
            new PublishingNotesPage().PublishCourseInWorkSpace(courseTypeEnum);
            Logger.LogMethodExit("PublishCourse", "PublishTheCourse",
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
