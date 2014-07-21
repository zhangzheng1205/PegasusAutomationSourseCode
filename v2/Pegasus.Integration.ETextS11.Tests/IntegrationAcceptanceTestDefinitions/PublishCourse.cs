using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Integration.Hed.ETextS11.Tests.IntegrationAcceptanceTestDefinitions;

namespace Pegasus.Integration.ETextS11.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class contains the details  for Publish Course.
    /// in workspace
    /// </summary>
    [Binding]
    public class PublishCourse : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(PublishCourse));

        /// <summary>
        /// Publish Master Course In WorkSpace. 
        /// </summary>
        /// <param name="courseTypeEnum">This course type enum.</param>
        /// <param name="cmenuOptionName">This is course cmenu option name.</param>
        [When(@"I publish the Authored ""(.*)"" in workspace as ""(.*)""")]
        public void PublishAuthoredMasterCourseInWorkSpace
            (Course.CourseTypeEnum courseTypeEnum, String cmenuOptionName)
        {
            //Method To Publish Course
            Logger.LogMethodEntry("PublishCourse", "PublishAuthoredMasterCourseInWorkSpace",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Course Cmenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
                    (PublishCourseResource.
                    PublishCourse_PublishAsMasterCourse_Keyword + cmenuOptionName);
            //Course Published Successfully
            new PublishingNotesPage().PublishCourseInWorkSpace(courseTypeEnum);
            Logger.LogMethodExit("PublishCourse", "PublishAuthoredMasterCourseInWorkSpace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the course in right frame.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <param name="searchRadioButton">This is Search Radio Button.</param>
        /// <param name="dropdownOption">This is Dropdown Option.</param>
        [When("I search \"(.*)\" coursen in worspace")]
        public void SearchCourseInRightFrame(Course.CourseTypeEnum courseTypeEnum,
            string searchRadioButton, string dropdownOption)
        {
            //Method To Search Course
            Logger.LogMethodEntry("PublishCourse", "SearchCourseInRightFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Get the Course from Memory
            Course course = Course.Get(courseTypeEnum);
            //Search course
            new SearchCoursesPage().SearchCourse(
                (SearchCoursesPage.SearchRadioButtonEnum)Enum.Parse(typeof(
                SearchCoursesPage.SearchRadioButtonEnum),
                searchRadioButton), course.Name, dropdownOption);
            //Select CourseEnrollement Window
            new ManageCoursesPage().SelectCourseEnrollementWindow();
            Logger.LogMethodExit("PublishCourse", "SearchCourseInRightFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

    }
}
