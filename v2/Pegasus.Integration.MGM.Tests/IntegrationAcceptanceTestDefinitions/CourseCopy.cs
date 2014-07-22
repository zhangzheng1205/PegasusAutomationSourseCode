using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Integration.MGM.Tests.CommonIntegrationAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using System;
using Pegasus.Integration.DigitalPath.Rumba.Tests.IntegrationAcceptanceTestDefinitions;
using Pegasus.Integration.DigitalPath.Rumba.Tests.CommonIntegrationAcceptanceTestDefinitions;

namespace Pegasus.Integration.MGM.Tests.
    IntegrationAcceptanceTestDefinitions
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
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CourseCopy));

        /// <summary>
        /// Creates The Authored Course Copy.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I create course copy as ""(.*)"" in workspace")]
        public void CreateAuthoredCourseCopyInWorkspace(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Copies Course
            Logger.LogMethodEntry("CourseCopy",
                "CreateAuthoredCourseCopyInWorkspace",
                base.isTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
                    (CourseCopyResource.
                    CourseCopy_CopyasmasterCourse_CMenu_Option_Name);
            //Create A Copy Of Master Course
            new NewCoursePage().CopyCourseAsMasterCourse(courseTypeEnum);
            Logger.LogMethodExit("CourseCopy",
                "CreateAuthoredCourseCopyInWorkSpace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Approve  From The [CourseForAssignedToCopy] State.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        /// <param name="searchRadioButton">This is Search Radio Button.</param>
        /// <param name="dropdownOption">This is Dropdown Option.</param>
        [When(@"I verify the course ""(.*)"" for AssignedToCopy state")]
        public void VerifyTheCourseForAssignedToCopyState(
            Course.CourseTypeEnum courseTypeEnum,
            string searchRadioButton, string dropdownOption)
        {
            //Check Course for Assigned To Copy State
            Logger.LogMethodEntry("CourseCopy",
                "VerifyTheCourseForAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Ensure Course Is Out Of AssignedToCopy State Or Not.
        /// </summary>
        [Then(@"I should see the copied course out of Assigned to Copy State")]
        public void CourseOutOfAssignedToCopyState()
        {
            //Check Course Get Our Of Assigned To Copy State
            Logger.LogMethodEntry("CourseCopy", "OutOfAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
            //Assert [CourseForAssignedToCopy] Text Present
            Logger.LogAssertion("VerifyAssignedToCopyTextPresent",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(CourseCopyResource
                    .CourseCopy_CopyAsMasterCourse_ReturnValue_Match
                    , new ManageCoursesPage().
                    GetAssignedToCopyTextPresentAfterSpecifiedTime()));
            Logger.LogMethodExit("CourseCopy", "OutOfAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the course in right frame.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        /// <param name="searchRadioButton">This is Search Radio Button.</param>
        /// <param name="dropdownOption">This is Dropdown Option.</param>
        [When(@"I search ""(.*)"" in workspace")]
        public void SearchTheCourse(
            Course.CourseTypeEnum courseTypeEnum,
            string searchRadioButton, string dropdownOption)
        {
            //Search Course in right frame
            Logger.LogMethodEntry("CourseCopy", "SearchTheCourse",
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
            Logger.LogMethodExit("CourseCopy", "SearchTheCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Course Search.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [Then(@"I should see the searched ""(.*)"" course in Manage Courses frame")]
        public void CheckSearchedCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //To Verify The Course Search
            Logger.LogMethodEntry("CourseCopy", "CheckSearchedCourse",
               base.isTakeScreenShotDuringEntryExit);
            //Get Course Name From InMemory
            Course course = Course.Get(courseTypeEnum);
            // Assert Course Search
            Logger.LogAssertion("VerifySearchCourse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(course.Name,
                    new ManageCoursesPage().GetSearchedCourse(courseTypeEnum)));
            Logger.LogMethodExit("CourseCopy", "CheckSearchedCourse",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Copy of Authored Course in different workspace.
        /// </summary>
        /// <param name="courseTypeEnum">This is course by type Enum.</param>
        [When(@"I create course copy to other workspace as ""(.*)""")]
        public void CreateCourseCopyInDifferentWorkspace
            (Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Workspace Course Copy In Authored Course
            Logger.LogMethodEntry("CourseCopy",
                "CreateWorkspaceCourseCopyInAuthoredCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
            (CourseCopyResource.CourseCopy_CopyasmasterCourse_CMenu_Option_Name);
            //Copy Workspace Course As MasterCourse
            new NewCoursePage().CopyMasterCourseInDifferentWorkspace(courseTypeEnum);
            Logger.LogMethodExit("CourseCopy",
                "CreateWorkspaceCourseCopyInAuthoredCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Move Content from Class Content Library to Class Content
        /// </summary>
        [When(@"I click on masterlibrary in class content library")]
        public void MoveContentfromClassContentLibrarytoClassContent()
        {
           //Move Content from Class Content Library to Class Content
            Logger.LogMethodEntry("CourseCopy",
               "MoveContentfromClassContentLibrarytoClassContent",
               base.isTakeScreenShotDuringEntryExit);
            // Click on MasterLibrary
            new CourseContentUXPage().ClickonMasterLibrary();
            Logger.LogMethodExit("CourseCopy",
                "vMoveContentfromClassContentLibrarytoClassContent",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Activity in Class Content Library
        /// </summary>
        /// <param name="activityTypeEnum">This is the activity type enum.</param>
        [When(@"I select the ""(.*)"" activity in class content library")]
        public void SelecttheActivityinClassContentLibrary(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select the Activity in Class Content Library
            Logger.LogMethodEntry("CourseCopy",
               "SelecttheActivityinClassContentLibrary",
               base.isTakeScreenShotDuringEntryExit);
            //Get Activity based on Activity ID
            switch (activityTypeEnum)
            {
                case Activity.ActivityTypeEnum.Test:
                    //Gets the Activity name from Memory by using activity ID
                    Activity activity = Activity.Get(CommonStepsResource.
                        CommonSteps_DigitalPath_Activity_Test_UC1);
                    //Select Activity
                    new CourseContentUXPage().SelectActivity(activity.Name);
                    break;
                case Activity.ActivityTypeEnum.SkillStudyPlan:
                    //Gets the Activity name from Memory by using activity ID
                    activity = Activity.Get(CommonStepsResource.
                        CommonSteps_DigitalPath_Activity_SkillStudyPlan_UC1);
                    //Select Activity
                    new CourseContentUXPage().SelectActivity(activity.Name);
                    break;
            }
           
            Logger.LogMethodExit("CourseCopy",
                "SelecttheActivityinClassContentLibrary",
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
