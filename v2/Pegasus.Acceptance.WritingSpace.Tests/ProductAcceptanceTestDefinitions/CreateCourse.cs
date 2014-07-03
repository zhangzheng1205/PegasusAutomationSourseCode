using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.WritingSpace.Tests.
    ProductAcceptanceTestDefinitions
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
               base.isTakeScreenShotDuringEntryExit);
            //Get Course Name From InMemory
            Course course = Course.Get(courseTypeEnum);
            // Assert Course Search
            Logger.LogAssertion("VerifySearchCourse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(course.Name,
                    new ManageCoursesPage().GetSearchedCourse(courseTypeEnum)));
            Logger.LogMethodExit("CreateCourse", "CheckSearchedCourse",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Creates a New Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <param name="courseFormatOption">This is course format option value.</param>
        [When(@"I create a new ""(.*)"" course by selecting ""(.*)"" format")]
        public void CreateNewCourse(Course.CourseTypeEnum
            courseTypeEnum, String courseFormatOption)
        {
            //Creates a New Course
            Logger.LogMethodEntry("CreateCourse", "CreateNewCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Creates a new course of defined format
            new NewCoursePage().CreateNewCourse(courseTypeEnum, courseFormatOption);
            Logger.LogMethodExit("CreateCourse", "CreateNewCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the course in right frame.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type Enum.</param>
        /// <param name="searchRadioButton">This is Search Radio Button.</param>
        /// <param name="dropdownOption">This is Dropdown Option.</param>
        [When(@"I search ""(.*)"" course in workspace by ""(.*)"" and ""(.*)"" dropdown option")]
        public void SearchTheCourseByCourseName(Course.CourseTypeEnum courseTypeEnum,
            string searchRadioButton, string dropdownOption)
        {
            //Search Course in right frame
            Logger.LogMethodEntry("CreateCourse", "SearchTheCourseByCourseName",
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
            Logger.LogMethodExit("CreateCourse", "SearchTheCourseByCourseName",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Create/Copy Course' Option
        /// </summary>
        [When(@"I select 'Create/Copy course' option")]
        public void SelectCreateCopyCourseOption()
        {
            //Select 'Create/Copy Course' Option
            Logger.LogMethodEntry("CreateCourse", "SelectCreateCopyCourseOption",
                base.isTakeScreenShotDuringEntryExit);
            //Click on the 'Create/Copy Course' button
            new UserLayoutRootNodePage().ClickOntheCreateCopyCourseButton();
            Logger.LogMethodExit("CreateCourse", "SelectCreateCopyCourseOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Access Code Id
        /// </summary>
        [When(@"I enter the access code id")]
        public void EnterTheAccessCodeId()
        {
            //Enter The Access Code Id
            Logger.LogMethodEntry("CreateCourse", "EnterTheAccessCodeId",
                base.isTakeScreenShotDuringEntryExit);
            //Enter The Access Code
            new UserLayoutRootNodeTargetPage().EnterAccessCodeId();
            Logger.LogMethodExit("CreateCourse", "EnterTheAccessCodeId",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course From The List
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I select ""(.*)"" course from the list")]
        public void SelectCourseFromTheList(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Select Course From The List
            Logger.LogMethodEntry("CreateCourse", "SelectCourseFromTheList",
                base.isTakeScreenShotDuringEntryExit);
            //Search the Course From List
            new UserLayoutRootNodeTargetPage().SearchCourseFromList(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "SelectCourseFromTheList",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Course Details
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I create ""(.*)"" course")]
        public void CreateMMNDCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Enter The Course Details
            Logger.LogMethodEntry("CreateCourse", "CreateMMNDCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Enter The Course Details
            new UserLayoutRootNodeTargetPage().EnterCourseDetails(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "CreateMMNDCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Course Created Successfully
        /// </summary>
        [Then(@"The course should be successfully created")]
        public void CourseCreatedSuccessfully()
        {
            //Course Created Successfully
            Logger.LogMethodEntry("CreateCourse", "CourseCreatedSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
            //Assert the Course Creation
            Logger.LogAssertion("VerifyCourseCreation",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(
                    CreateCourseResource.CreateCourse_CourseCopy_Confirmation_Message,
                    new UserLayoutRootNodeTargetPage().GetSuccessfullMessage()));
            Logger.LogMethodExit("CreateCourse", "CourseCreatedSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get CourseId Of Course
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I fetch the course id of ""(.*)"" course")]
        public void FetchCourseIdOfCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Fetch the Course Id
            Logger.LogMethodEntry("CreateCourse", "FetchCourseIdOfCourse",
               base.isTakeScreenShotDuringEntryExit);
            //Fetch the Course Id
            new UserLayoutRootNodeTargetPage().GetCourseId(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "FetchCourseIdOfCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Logout Succesfully From MMND
        /// </summary>
        [Then(@"I should see the application logout successfully")]
        public void LogoutSuccesfullyFromMMND()
        {
            //Verify The Course
            Logger.LogMethodEntry("CreateCourse", "LogoutSuccesfullyFromMMND",
               base.isTakeScreenShotDuringEntryExit);
            //Verify The Succesfully Logout From MMND
            Logger.LogAssertion("VerifySuccessfulLogout",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(
                    CreateCourseResource.CreateCourse_Logout_Confirmation_Message,
                    new MyPearsonLoginPage().GetSuccessfullyLoggedOutOfMMNDMessage()));
            Logger.LogMethodExit("CreateCourse", "LogoutSuccesfullyFromMMND",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I verify the ""(.*)"" course from processing state")]
        public void VerifyTheCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify The Course
            Logger.LogMethodEntry("CreateCourse", "VerifyTheCourse",
               base.isTakeScreenShotDuringEntryExit);
            //Verify The Course in Active state
            new UserLayoutRootNodeTargetPage().VerifyCourseInActiveState(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "VerifyTheCourse",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display Of Course In Active State.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [Then(@"I should see the ""(.*)"" course in active state")]
        public void DisplayOfCourseInActiveState(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Display Of Course In Active State
            Logger.LogMethodEntry("CreateCourse", "DisplayOfCourseInActiveState",
               base.isTakeScreenShotDuringEntryExit);
            //Verify The Course In Active State
            Logger.LogAssertion("VerifyCourseInActiveState",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsFalse(
                new UserLayoutRootNodeTargetPage().IsTheCourseInActiveState(courseTypeEnum)));
            Logger.LogMethodExit("CreateCourse", "DisplayOfCourseInActiveState",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
