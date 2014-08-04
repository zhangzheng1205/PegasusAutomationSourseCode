using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.ETextS11.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Create Course Page Actions.
    /// </summary>
    [Binding]
    public class CreateCourse : PegasusBaseTestFixture
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(CreateCourse));

        /// <summary>
        /// Verify Course Search.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [Then("I should be able to see the searched \"(.*)\" course")]
        [Then(@"I should see the searched ""(.*)"" course in Manage Courses frame")]
        public void CheckSearchedCourse(
            Course.CourseTypeEnum courseTypeEnum)
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
        /// Creates a New Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <param name="courseFormatOption">This is course format option value.</param>
        [When(@"I create a new ""(.*)"" course by selecting ""(.*)"" format")]
        public void CreateNewCourse(Course.CourseTypeEnum courseTypeEnum, 
            String courseFormatOption)
        {
            //Creates a New Course
            Logger.LogMethodEntry("CreateCourse", "CreateNewCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Creates a new course of defined format
            new NewCoursePage().CreateNewCourse(courseTypeEnum, courseFormatOption);
            Logger.LogMethodExit("CreateCourse", "CreateNewCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the course in right frame.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type.</param>
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
        /// This method is called before execution of test.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// This function is called after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
