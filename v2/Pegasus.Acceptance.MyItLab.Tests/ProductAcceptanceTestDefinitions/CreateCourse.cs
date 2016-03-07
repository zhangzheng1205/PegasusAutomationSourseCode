using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
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
                base.IsTakeScreenShotDuringEntryExit);
            //Creates a new course of defined format
            new NewCoursePage().CreateNewCourse(courseTypeEnum, courseFormatOption);
            Logger.LogMethodExit("CreateCourse", "CreateNewCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Search the course in right frame
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
            Logger.LogMethodExit("CreateCourse", "SearchTheCourseByCourseName",
                base.IsTakeScreenShotDuringEntryExit);
        }

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
            Logger.LogMethodEntry("CourseCopy",
                "VerifyTheCourseMessage",
                base.IsTakeScreenShotDuringEntryExit);
            // Assert Course Search
            Logger.LogAssertion("VerifySearchCourse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(message,
                    new ManageCoursesPage().GetMessageInManageCourseFrame(message)));
            Logger.LogMethodExit("CourseCopy",
                "VerifyTheCourseMessage",
                base.IsTakeScreenShotDuringEntryExit);
        }

      
     

        /// <summary>
        /// Create Testing Course Copy In Workspace.
        /// </summary>
        /// <param name=""></param>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I perform ""(.*)"" for ""(.*)"" course")]
        public void CreateTestingCourseCopyInWorkspace
            (String cmenuAction, Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Testing Course Copy In Workspace            
            Logger.LogMethodEntry("CreateCourse",
                "CreateTestingCourseCopyInWorkspace",
                base.IsTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
             (cmenuAction);
            //Copy Course As Testing Course
            new NewCoursePage().CopyCourseActions(cmenuAction, courseTypeEnum);
            Logger.LogMethodExit("CreateCourse",
                "CreateTestingCourseCopyInWorkspace",
                base.IsTakeScreenShotDuringEntryExit);
        }

          [When(@"I perform ""(.*)"" for ""(.*)"" course to another workspace ""(.*)""")]
        public void CopyCourseToAnotherWorkspace(String cmenuAction,
              Course.CourseTypeEnum courseTypeEnum,User.UserTypeEnum userTypeEnum)
        {
               //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
             (cmenuAction);
            new NewCoursePage().CopyMasterCourseInDifferentWorkspace(courseTypeEnum, userTypeEnum);
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
            Logger.LogMethodEntry("CreateCourse", "VerifiedTheCourseForAssignedToCopyState",
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
            Logger.LogMethodExit("CreateCourse", "CreateAuthoredCourseCopyInWorkSpace",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Ensure course is out of AssignedToCopy state or not.
        /// </summary>
        /// /// <param name="courseTypeEnum">This is course type enum.</param>
        [Then(@"I should see the Copied ""(.*)"" Course Out Of Assigned to Copy State")]
        public void CourseOutOfAssignedToCopyState(Course.CourseTypeEnum courseTypeEnum)
        {
            //Check Course Get Our Of Assigned To Copy State
            Logger.LogMethodEntry("CreateCourse", "CourseOutOfAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            ManageCoursesPage manageCoursesPage = new ManageCoursesPage();
            //Assert [CourseForAssignedToCopy] Text Present
            Logger.LogAssertion("VerifyAssignedToCopyTextPresent",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual("False"
                    , manageCoursesPage.
                    GetAssignedToCopyTextPresentAfterSpecifiedTime()));
            //Fetch And Store Course Workspace Id
            manageCoursesPage.FetchAndStoreCourseWorkspaceId(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "CourseOutOfAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Publish the Freshly Copied Course or Existing Course.
        /// </summary>
        /// <param name="freshCourseTypeEnum">Freshly created Course name.</param>
        /// <param name="existingCourseTypeEnum">Existing Course name.</param>
        [When(@"I Publish ""(.*)"" or ""(.*)""")]
        public void PublishFreshOrExisting(Course.CourseTypeEnum freshCourseTypeEnum,
           Course.CourseTypeEnum existingCourseTypeEnum)
        {

            // Publish the Freshly Copied Course or Existing Course
            Logger.LogMethodEntry("CreateCourse", "PublishFreshOrExisting",
              base.IsTakeScreenShotDuringEntryExit);
            ManageCoursesPage manageCoursesPage = new ManageCoursesPage();
            manageCoursesPage.PublishFreshOrExistingCourse(freshCourseTypeEnum,
                existingCourseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "PublishFreshOrExisting",
               base.IsTakeScreenShotDuringEntryExit);
        }

         
       

    }
}
