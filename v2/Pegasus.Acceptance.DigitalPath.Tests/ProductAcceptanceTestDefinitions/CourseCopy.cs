﻿#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using System;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
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
                base.IsTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
                    (CourseCopyResource.
                    CourseCopy_CopyasmasterCourse_CMenu_Option_Name);
            //Create A Copy Of Master Course
            new NewCoursePage().CopyCourseAsMasterCourse(courseTypeEnum);
            Logger.LogMethodExit("CourseCopy", 
                "CreateAuthoredCourseCopyInWorkSpace",
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
            Logger.LogMethodEntry("CourseCopy", "OutOfAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert [CourseForAssignedToCopy] Text Present
            Logger.LogAssertion("VerifyAssignedToCopyTextPresent",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(CourseCopyResource
                    .CourseCopy_CopyAsMasterCourse_ReturnValue_Match
                    , new ManageCoursesPage().
                    GetAssignedToCopyTextPresentAfterSpecifiedTime()));
            Logger.LogMethodExit("CourseCopy", "OutOfAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the course in right frame.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        /// <param name="searchRadioButton">This is Search Radio Button.</param>
        /// <param name="dropdownOption">This is Dropdown Option.</param>
        [When(@"I search ""(.*)"" in workspace by ""(.*)"" and ""(.*)"" dropdown option")]
        public void SearchTheCourse(Course.CourseTypeEnum courseTypeEnum,
            string searchRadioButton, string dropdownOption)
        {
            //Search Course in right frame
            Logger.LogMethodEntry("CourseCopy", "SearchTheCourse",
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
            Logger.LogMethodExit("CourseCopy", "SearchTheCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Verify Course Search.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [Then(@"I should see the searched ""(.*)"" course in Manage Courses frame")]
        public void CheckSearchedCourse(Course.CourseTypeEnum courseTypeEnum)
        {
            //To Verify The Course Search
            Logger.LogMethodEntry("CourseCopy", "CheckSearchedCourse",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Course Name From InMemory
            Course course = Course.Get(courseTypeEnum);
            // Assert Course Search
            Logger.LogAssertion("VerifySearchCourse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(course.Name,
                    new ManageCoursesPage().GetSearchedCourse(courseTypeEnum)));
            Logger.LogMethodExit("CourseCopy", "CheckSearchedCourse",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Create Copy of Authored Course. /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="courseTypeEnum"></param>
        [When(@"I ""(.*)"" as ""(.*)""")]
        public void CreateCopyOfAuthoredCourse(string cmenuAction, Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Testing Course Copy In Workspace            
            Logger.LogMethodEntry("CreateCourse",
                "CreateCopyOfAuthoredCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
             (cmenuAction);
            //Copy Course 
            new NewCoursePage().CopyCourseActions(cmenuAction, courseTypeEnum);
            Logger.LogMethodExit("CreateCourse",
                "CreateCopyOfAuthoredCourse",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("CourseCopy", "CreateNewCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Creates a new course of defined format
            new NewCoursePage().CreateNewCourse(courseTypeEnum, courseFormatOption);
            Logger.LogMethodExit("CourseCopy", "CreateNewCourse",
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
            Logger.LogMethodEntry("CourseCopy", "SearchTheCourseByCourseName",
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
            Logger.LogMethodExit("CourseCopy", "SearchTheCourseByCourseName",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
            (CourseCopyResource.CourseCopy_CopyasmasterCourse_CMenu_Option_Name);
            //Copy Workspace Course As MasterCourse
            // Pass workspace name via usertype enum to select the Workspace.The method has been generalized .
           // new NewCoursePage().CopyMasterCourseInDifferentWorkspace(courseTypeEnum);
            Logger.LogMethodExit("CourseCopy",
                "CreateWorkspaceCourseCopyInAuthoredCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Delete The Created Course In Manage Course Frame.
        /// </summary>
        [When(@"I select the course to delete in manage course frame")]
        public void DeleteTheCreatedCourseInManageCourseFrame()
        {
           //Delete The Created Course In Manage Course Frame
            Logger.LogMethodEntry("CourseCopy",
                "DeleteTheCreatedCourseInManageCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Delete The Created Course In Manage Course Frame
            new ManageCoursesPage().DeleteTheCreatedCourseInManageCourseFrame();
            Logger.LogMethodExit("CourseCopy",
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
