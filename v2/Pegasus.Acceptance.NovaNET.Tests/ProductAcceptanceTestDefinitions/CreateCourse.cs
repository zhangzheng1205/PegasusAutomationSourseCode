using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles course creation actions.
    /// </summary>
    [Binding]
    public class CreateCourse : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(CreateCourse));

        /// <summary>
        /// Creates a New Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        /// <param name="courseFormatOption">This is course format option name.</param>
        [When(@"I create a new ""(.*)"" course by selecting ""(.*)"" format")]
        public void CreateNewCourse(
            Course.CourseTypeEnum courseTypeEnum, 
            String courseFormatOption)
        {
            //Creates a New Course
            Logger.LogMethodEntry("CreateCourse", "CreateNewCourse", 
                base.IsTakeScreenShotDuringEntryExit);
            //Creates a new course using defined format
            new NewCoursePage().CreateNewCourse(courseTypeEnum, 
                courseFormatOption);
            Logger.LogMethodExit("CreateCourse", "CreateNewCourse", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the course in right frame.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type Enum.</param>
        /// <param name="searchRadioButton">This is Search Radio Button.</param>
        /// <param name="dropdownOption">This is Dropdown Option.</param>
       [When(@"I search ""(.*)"" course in workspace by ""(.*)"" and ""(.*)"" dropdown option")]
        public void SearchTheCourse(
            Course.CourseTypeEnum courseTypeEnum,
            string searchRadioButton, string dropdownOption)
        {
            //Search Course in right frame
            Logger.LogMethodEntry("CreateCourse", "SearchTheCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the Course from Memory
            Course course = Course.Get(courseTypeEnum);
            //Search course
            new SearchCoursesPage().SearchCourse(
                (SearchCoursesPage.SearchRadioButtonEnum)Enum.Parse(typeof(
                SearchCoursesPage.SearchRadioButtonEnum),
                searchRadioButton), course.Name, dropdownOption);
            //Select CourseEnrollement Window
            new ManageCoursesPage().SelectCourseEnrollementWindow();
            Logger.LogMethodExit("CreateCourse", "SearchTheCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Verify Course Search.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type Enum.</param>
        [Then(@"I should see the searched ""(.*)"" course in Manage Courses frame")]
        public void CheckSearchedCourse(
            Course.CourseTypeEnum 
            courseTypeEnum)
        {
            //To Verify The Course Search
            Logger.LogMethodEntry("CreateCourse", "CheckSearchedCourse",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Course Name From InMemory
            Course course = Course.Get(courseTypeEnum);
            // Assert Course Search
            Logger.LogAssertion("VerifySearchCourse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(course.Name,
                    new ManageCoursesPage().GetSearchedCourse(courseTypeEnum)));
            Logger.LogMethodExit("CreateCourse", "CheckSearchedCourse",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Delete The Created Course In Manage Course Frame.
        /// </summary>
        [When(@"I select the course to delete in manage course frame")]
        public void DeleteTheCreatedCourseInManageCourseFrame()
        {
            //Delete The Created Course In Manage Course Frame
            Logger.LogMethodEntry("CreateCourse",
                "DeleteTheCreatedCourseInManageCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Delete The Created Course In Manage Course Frame
            new ManageCoursesPage().DeleteTheCreatedCourseInManageCourseFrame();
            Logger.LogMethodExit("CreateCourse",
                "DeleteTheCreatedCourseInManageCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Course Message.
        /// </summary>
        /// <param name="message">This is course message.</param>
        [Then(@"I should see the ""(.*)"" message in Manage Course")]
        public void VerifyTheCourseMessage(string message)
        {
            //Verify The Course Message
            Logger.LogMethodEntry("CreateCourse",
                "VerifyTheCourseMessage",
                base.IsTakeScreenShotDuringEntryExit);
            // Assert Course Search
            Logger.LogAssertion("VerifySearchCourse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(message,
                    new ManageCoursesPage().GetMessageInManageCourseFrame(message)));
            Logger.LogMethodExit("CreateCourse",
                "VerifyTheCourseMessage",
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
