using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.NovaNET.Tests.Definitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using System;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles copy course actions.
    /// </summary>
    [Binding]
    public class CourseCopy : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(CourseCopy));

        /// <summary>
        /// Creates The Authored Course Copy.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I create course copy as ""(.*)"" course in workspace")]
        public void CreateAuthoredCourseCopyInWorkspace(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Copies Course
            Logger.LogMethodEntry("CourseCopy", "CreateAuthoredCourseCopyInWorkspace",
                base.IsTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
                    (CourseCopyResource.
                    CourseCopy_CopyasmasterCourse_CMenu_Option_Name);
            //Create A Copy Of Master Course
            new NewCoursePage().CopyCourseAsMasterCourse(courseTypeEnum);
            Logger.LogMethodExit("CourseCopy", "CreateAuthoredCourseCopyInWorkSpace",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Approve  From The [CourseForAssignedToCopy] State.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        /// <param name="searchRadioButton">This is Search Radio Button.</param>
        /// <param name="dropdownOption">This is Dropdown Option.</param>
        [When(@"I verify the course ""(.*)"" for AssignedToCopy state by ""(.*)"" and ""(.*)"" dropdown option")]
        public void VerifyTheCourseForAssignedToCopyState(
            Course.CourseTypeEnum courseTypeEnum,
            string searchRadioButton, string dropdownOption)
        {
            //Check Course for Assigned To Copy State
            Logger.LogMethodEntry("CourseCopy", 
                "VerifyTheCourseForAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            //Get The Copied Master Course Name Stored In Memory
            Course course = Course.Get(courseTypeEnum);
            //Search course
            new SearchCoursesPage().SearchCourse(
                (SearchCoursesPage.SearchRadioButtonEnum)Enum.Parse(typeof(
                SearchCoursesPage.SearchRadioButtonEnum),
                searchRadioButton), course.Name, dropdownOption);
            //Approve From [CourseForAssignedToCopy] State 
            new ManageCoursesPage().ApproveAssignedToCopyState(
                (SearchCoursesPage.SearchRadioButtonEnum)Enum.Parse(
                typeof(SearchCoursesPage.SearchRadioButtonEnum), searchRadioButton),
                course.Name, dropdownOption);
            Logger.LogMethodExit("CourseCopy", 
                "VerifyTheCourseForAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Ensure Course Is Out Of AssignedToCopy State Or Not.
        /// </summary>
        [Then(@"I should see the copied course out of Assigned to Copy State")]
        public void CourseOutOfAssignedToCopyState()
        {
            //Check Course Get Our Of Assigned To Copy State
            Logger.LogMethodEntry("CourseCopy", 
                "CourseOutOfAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert [CourseForAssignedToCopy] Text Present
            Logger.LogAssertion("VerifyAssignedToCopyTextPresent",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(CourseCopyResource
                    .CourseCopy_CopyAsMasterCourse_ReturnValue_Match
                    , new ManageCoursesPage().
                    GetAssignedToCopyTextPresentAfterSpecifiedTime()));
            Logger.LogMethodExit("CourseCopy", 
                "CourseOutOfAssignedToCopyState",
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
