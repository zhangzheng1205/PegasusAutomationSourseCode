#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.Definitions
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
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(CourseCopy));

        /// <summary>
        /// Creates The Authored Course Copy.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I create course copy as ""(.*)"" in workspace")]
        public void CreateAuthoredCourseCopyInWorkspace
            (Course.CourseTypeEnum courseTypeEnum)
        {
            //Copies Course
            logger.LogMethodEntry("CourseCopy", "CreateAuthoredCourseCopyInWorkspace",
                base.isTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
                    (CourseCopyResource.CourseCopy_CopyasmasterCourse_CMenu_Option_Name);
            //Create A Copy Of Master Course
            new NewCoursePage().CopyCourseAsMasterCourse(courseTypeEnum);
            logger.LogMethodExit("CourseCopy", "CreateAuthoredCourseCopyInWorkSpace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Approve  From The [CourseForAssignedToCopy] State.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I verify the course ""(.*)"" for AssignedToCopy state")]
        public void VerifyTheCourseForAssignedToCopyState
            (Course.CourseTypeEnum courseTypeEnum)
        {
            //Check Course for Assigned To Copy State
            logger.LogMethodEntry("CourseCopy", "VerifyTheCourseForAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
            //Get The Copied Master Course Name Stored In Memory
            Course course = Course.Get(courseTypeEnum);
            //Search course
            new SearchCoursesPage().SearchCourse(course.Name);
            //Approve From [CourseForAssignedToCopy] State 
            new ManageCoursesPage().ApproveAssignedToCopyState(course.Name);
            logger.LogMethodExit("CourseCopy", "VerifyTheCourseForAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Ensure Course Is Out Of AssignedToCopy State Or Not.
        /// </summary>
        [Then(@"I should see the copied course out of Assigned to Copy State")]
        public void CourseOutOfAssignedToCopyState()
        {
            //Check Course Get Our Of Assigned To Copy State
            logger.LogMethodEntry("CourseCopy", "OutOfAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
            //Assert [CourseForAssignedToCopy] Text Present
            logger.LogAssertion("VerifyAssignedToCopyTextPresent",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(CourseCopyResource
                    .CourseCopy_CopyAsMasterCourse_ReturnValue_Match
                    , new ManageCoursesPage().GetAssignedToCopyTextPresentAfterSpecifiedTime()));
            logger.LogMethodExit("CourseCopy", "OutOfAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the course in right frame.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type.</param>
        [When(@"I search ""(.*)"" in workspace")]
        public void SearchTheCourse(Course.CourseTypeEnum courseTypeEnum)
        {
            //Search Course in right frame
            logger.LogMethodEntry("CourseCopy", "SearchTheCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Get the Course from Memory
            Course course = Course.Get(courseTypeEnum);
            //Search course
            new SearchCoursesPage().SearchCourse(course.Name);
            //Select CourseEnrollement Window
            new ManageCoursesPage().SelectCourseEnrollementWindow();
            logger.LogMethodExit("CourseCopy", "SearchTheCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Course Search.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [Then(@"I should see the searched ""(.*)"" course in Manage Courses frame")]
        public void CheckSearchedCourse(Course.CourseTypeEnum courseTypeEnum)
        {
            //To Verify The Course Search
            logger.LogMethodEntry("CourseCopy", "CheckSearchedCourse",
               base.isTakeScreenShotDuringEntryExit);
            //Get Course Name From InMemory
            Course course = Course.Get(courseTypeEnum);
            // Assert Course Search
            logger.LogAssertion("VerifySearchCourse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(course.Name,
                    new ManageCoursesPage().GetSearchedCourse(courseTypeEnum)));
            logger.LogMethodExit("CourseCopy", "CheckSearchedCourse",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Copy of Authored Course in different workspace.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I create course copy to other workspace as ""(.*)""")]
        public void CreateCourseCopyInDifferentWorkspace
            (Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Workspace Course Copy In Authored Course
            logger.LogMethodEntry("CourseCopy",
                "CreateWorkspaceCourseCopyInAuthoredCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
            (CourseCopyResource.CourseCopy_CopyasmasterCourse_CMenu_Option_Name);
            //Copy Workspace Course As MasterCourse
            new NewCoursePage().CopyMasterCourseInDifferentWorkspace(courseTypeEnum);
            logger.LogMethodExit("CourseCopy",
                "CreateWorkspaceCourseCopyInAuthoredCourse",
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
