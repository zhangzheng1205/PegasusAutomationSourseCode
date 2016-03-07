using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using System;
using Pegasus.Integration.Hed.ETextS11.Tests.IntegrationAcceptanceTestDefinitions;

namespace Pegasus.Integration.ETextS11.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles copy course actions.
    /// </summary>
    [Binding]
    public class CourseCopy : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(CourseCopy));

        /// <summary>
        /// Creates The Authored Course Copy.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I create course copy as ""(.*)"" course")]
        public void CreateCourseCopyInWorkspace(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Copies Course
            Logger.LogMethodEntry("CourseCopy", "CreateCourseCopyInWorkspace",
                base.IsTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
                    (CourseCopyResource.CourseCopy_CopyasMasterCourse_CMenu_Option_Name);
            //Create A Copy Of Master Course
            new NewCoursePage().CopyCourseAsMasterCourse(courseTypeEnum);
            Logger.LogMethodExit("CourseCopy", "CreateCourseCopyInWorkspace",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Approve  from the [CourseForAssignedToCopy] State.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <param name="searchRadioButton">This is Search Radio Button.</param>
        /// <param name="dropdownOption">This is Dropdown Option.</param>
        [When(@"I verified the course ""(.*)"" for AssignedToCopy state by ""(.*)"" and ""(.*)"" dropdown option")]
        public void VerifiedTheCourseForAssignedToCopyState(
            Course.CourseTypeEnum courseTypeEnum,
            string searchRadioButton, string dropdownOption)
        {
            //Check Course for Assigned To Copy State
            Logger.LogMethodEntry("CourseCopy", "VerifiedTheCourseForAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            // Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Search course
            new SearchCoursesPage().SearchCourse(
                (SearchCoursesPage.SearchRadioButtonEnum)Enum.Parse(typeof(
                SearchCoursesPage.SearchRadioButtonEnum),
                searchRadioButton), course.Name, dropdownOption);
            //Approve Course From [AssignedToCopy] State 
            new ManageCoursesPage().ApproveAssignedToCopyState(
                (SearchCoursesPage.SearchRadioButtonEnum)Enum.Parse(
                typeof(SearchCoursesPage.SearchRadioButtonEnum), searchRadioButton),
                course.Name, dropdownOption);
            Logger.LogMethodExit("CourseCopy", "CreateAuthoredCourseCopyInWorkSpace",
                base.IsTakeScreenShotDuringEntryExit);
        }       

        /// <summary>
        /// Ensure course is out of AssignedToCopy state or not.
        /// </summary>
        [Then("I should see the Copied Course Out Of Assigned to Copy State")]
        public void CourseOutOfAssignedToCopyState()
        {
            //Check Course Get Our Of Assigned To Copy State
            Logger.LogMethodEntry("CourseCopy", "OutOfAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert [CourseForAssignedToCopy] Text Present
            Logger.LogAssertion("VerifyAssignedToCopyTextPresent",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(
                    CourseCopyResource
                    .CourseCopy_CopyAsMasterCourse_ReturnValue_Match
                    , new ManageCoursesPage().GetAssignedToCopyTextPresentAfterSpecifiedTime()));
            Logger.LogMethodExit("CourseCopy", "OutOfAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Workspace Course Copy In Authored Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I create course copy to other workspace as ""(.*)"" course")]
        public void CreateCourseCopyInDifferentWorkSpace
            (Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Workspace Course Copy In Authored Course
            Logger.LogMethodEntry("CourseCopy", "CreateCourseCopyInDifferentWorkSpace",
                base.IsTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
            (CourseCopyResource.CourseCopy_CopyasMasterCourse_CMenu_Option_Name);
            //Copy Workspace Course As MasterCourse 
            //Pass workspace name via usertype enum to select the Workspace.The method has been generalized .
             //new NewCoursePage().CopyMasterCourseInDifferentWorkspace(courseTypeEnum);
            Logger.LogMethodExit("CourseCopy", "CreateCourseCopyInDifferentWorkSpace",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Testing Course Copy In Workspace.
        /// </summary>
        /// <param name=""></param>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I create testing type course copy as ""(.*)"" course")]
        public void CreateTestingCourseCopyInWorkspace
            (Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Testing Course Copy In Workspace            
            Logger.LogMethodEntry("CourseCopy", "CreateTestingCourseCopyInWorkspace",
                base.IsTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
             (CourseCopyResource.CourseCopy_CopyasMasterCourse_CMenu_CTC_Option_Name);
            //Copy Course As Testing Course
            new NewCoursePage().CopyCourseAsTestingCourse(courseTypeEnum);
            Logger.LogMethodExit("CourseCopy", "CreateTestingCourseCopyInWorkspace",
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
