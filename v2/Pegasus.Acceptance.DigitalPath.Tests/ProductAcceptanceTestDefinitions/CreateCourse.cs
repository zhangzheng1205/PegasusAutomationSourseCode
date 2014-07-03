#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Create Course Copy Page Actions.
    /// </summary>
    [Binding]
    public class CreateCourse : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CreateCourse));

        /// <summary>
        /// Click The Display All Link Button.
        /// </summary>
        ///  <param name="displayLinkType">This is display link type by enum..</param>   
        [When(@"I click the ""(.*)"" button")]
        public void ClickTheDisplayAllLinkButton(String displayLinkType)
        {
            // Click The Display All Courses Button
            Logger.LogMethodEntry("CreateCourse", "ClickTheDisplayAllLinkButton",
               base.isTakeScreenShotDuringEntryExit);
            //Click On The Display All Courses Button
            new SearchCoursesPage().ClickOnTheDisplayAllLinkButton
                ((SearchCoursesPage.DisplayAllLinkTypeEnum)Enum.Parse
                (typeof(SearchCoursesPage.DisplayAllLinkTypeEnum), displayLinkType));
            Logger.LogMethodExit("CreateCourse", "ClickTheDisplayAllLinkButton",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Search The Copy As Test Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        /// <param name="searchRadioButton">This is Search Radio Button.</param>
        /// <param name="dropdownOption">This is Dropdown Option.</param>
        [When(@"I search the ""(.*)"" course in workspace by ""(.*)"" and ""(.*)"" dropdown option")]
        public void SearchTheCopyAsTestCourse(
            Course.CourseTypeEnum courseTypeEnum,
            string searchRadioButton, string dropdownOption)
        {
            //Search The Copy As Test Course 
            Logger.LogMethodEntry("CreateCourse", "SearchTheCopyAsTestCourse",
             base.isTakeScreenShotDuringEntryExit);
            //Get the Course from Memory
            Course course = Course.Get(courseTypeEnum);
            //Search course
            new SearchCoursesPage().SearchCourse(
                (SearchCoursesPage.SearchRadioButtonEnum)Enum.Parse(typeof(
                SearchCoursesPage.SearchRadioButtonEnum),
                searchRadioButton), course.Name, dropdownOption);
            Logger.LogMethodExit("CreateCourse", "SearchTheCopyAsTestCourse",
               base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        ///Click The Cmenu Option Of CTC Course .
        /// </summary>
        [When(@"I click the cmenu option of CTC course")]
        public void ClickTheCmenuOptionOfCTCCourse()
        {
            //Click The Cmenu Option Of CTC Course 
            Logger.LogMethodEntry("CreateCourse", "ClickTheCmenuOptionOfCTCCourse",
             base.isTakeScreenShotDuringEntryExit);
            //Click On The Cmenu Option Of CTC Course 
            new ManageCoursesPage().ClickOnTheCmenuOptionOfCTCCourse();
            Logger.LogMethodExit("CreateCourse", "ClickTheCmenuOptionOfCTCCourse",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display The Default Cmenu Options Of CTC.
        /// </summary>
        [Then(@"I should see the default cmenu options of CTC")]
        public void DisplayTheDefaultCmenuOptionsOfCTC()
        {
            //Display The Default Cmenu Options Of CTC
            Logger.LogMethodEntry("CreateCourse",
                "DisplayTheDefaultCmenuOptionsOfCTC",
             base.isTakeScreenShotDuringEntryExit);
            //Assert the Display Of Default Cmenu Options
            Logger.LogAssertion("VerifyDisplayOfCmenuOptions",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.
                    IsTrue(new ManageCoursesPage().
                    IsDefaultCmenuOptionsDisplayedInCTC()));
            Logger.LogMethodExit("CreateCourse",
                "DisplayTheDefaultCmenuOptionsOfCTC",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Copy As Testing Course In Workspace.
        /// </summary>      
        /// <param name="courseTypeEnum">>This is course type enum.</param>
        [When(@"I create testing type course copy as ""(.*)""")]
        public void CreateCopyAsTestingCourseInWorkspace(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Copy As Testing Course In Workspace 
            Logger.LogMethodEntry("CreateCourse",
               "CreateCopyAsTestingCourseInWorkspace",
            base.isTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
             (CreateCourseResource.
             CreateCourseCopy_CopyasTestingrCourse_CMenu_CTC_Option_Name);
            //Create Copy Course As Testing Course
            new NewCoursePage().CopyCourseAsTestingCourse(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse",
                "CreateCopyAsTestingCourseInWorkspace",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Cmenu Option.
        /// </summary>
        [When(@"I click on the cmenu option")]
        public void ClickOnTheCmenuOption()
        {
            //Click On Cmenu Option
            Logger.LogMethodEntry("CreateCourse",
                "ClickOnTheCmenuOption",
             base.isTakeScreenShotDuringEntryExit);
            //Click of CMenu Option
            new ManageCoursesPage().ClickOnTheCmenuOptionOfCTCCourse();
            Logger.LogMethodExit("CreateCourse",
                 "ClickOnTheCmenuOption",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Verify the Cmenu Options.
        /// </summary>
        [Then(@"I should see cmenu options of course")]
        public void VerifyCmenuOptionsOfCourse()
        {
            //Verify Cmenu Option of Course
            Logger.LogMethodEntry("CreateCourse",
                "VerifyCmenuOptionsOfCourse",
             base.isTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyCmenuOptions",
                 ScenarioContext.Current.ScenarioInfo.Title, () =>
                     Assert.AreEqual(CreateCourseResource.
                     CreateCourseCopy_Coursecmenu_Option_Name,
                     new ManageCoursesPage().GetCmenuOptionOfCourse()));
            Logger.LogMethodExit("CreateCourse",
                "VerifyCmenuOptionsOfCourse",
               base.isTakeScreenShotDuringEntryExit);
        }

                /// <summary>
        /// Verify Course Created,Type and Status.
        /// </summary>
        [Then(@"I should see the 'Created','Type' and 'Status' of course")]
        public void VerifyCreatedTypeAndStatus()
        {
            //Verify Course Created,Type and Status
            Logger.LogMethodEntry("CreateCourse",
                 "VerifyCreatedTypeAndStatus",
              base.isTakeScreenShotDuringEntryExit);
            //Verify Course Type
            Logger.LogAssertion("VerifyCourseType", ScenarioContext.Current.ScenarioInfo.Title, ()
                => Assert.AreEqual(CreateCourseResource.CreateCourseCopy_CourseType_Name
                , new ManageCoursesPage().GetCourseType()));
            //Verify Course Status
            Logger.LogAssertion("VerifyCourseStatus", ScenarioContext.Current.ScenarioInfo.Title, ()
                => Assert.AreEqual(CreateCourseResource.CreateCourseCopy_CourseStatus_Name,
                new ManageCoursesPage().GetCourseStatus()));
            //Get Course Creation Date
            Course course = Course.Get(Course.CourseTypeEnum.MasterLibrary);
            DateTime dateMonthYear = course.creationDate;
            string getCurrentDateMonthYear = dateMonthYear.ToString();
            string[] getCurrentDate = getCurrentDateMonthYear.Split(Convert.ToChar(
                CreateCourseResource.CreateCourseCopy_SpecialCharacter_DateMonthYear_value));
            getCurrentDateMonthYear = getCurrentDate[0];
            //Verify Course Created Date
            Logger.LogAssertion("VerifyDayMonthYear", ScenarioContext.Current.ScenarioInfo.Title, ()
                => Assert.AreEqual(getCurrentDateMonthYear,
                new ManageCoursesPage().GetDateMonthYearFromManageFrame()));
            Logger.LogMethodExit("CreateCourse",
               "VerifyCreatedTypeAndStatus",
              base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Verify New Search and Delete Selected Course Button.
        /// </summary>
        [Then(@"I should see the 'New search' and 'Delete Selected Courses' button")]
        public void VerifyNewSearchAndDeleteSelectedCourseButton()
        {
            //Verify New Search and Delete Selected Course Button
            Logger.LogMethodEntry("CreateCourse",
                 "VerifyNewSearchAndDeleteSelectedCourseButton",
              base.isTakeScreenShotDuringEntryExit);
            //Verify New Search Button
            Logger.LogAssertion("VerifyNewSearchButton", ScenarioContext.Current.ScenarioInfo.Title, ()
                => Assert.AreEqual(CreateCourseResource.CreateCourseCopy_NewSearch_Name,
                 new ManageCoursesPage().GetNewSearchButtonName()));
            //Verify Delete Course Button
            Logger.LogAssertion("VerifyDeletCoursesButton", ScenarioContext.Current.ScenarioInfo.Title, ()
                => Assert.AreEqual(CreateCourseResource.CreateCourseCopy_DeleteSelectedCourses_Name,
                 new ManageCoursesPage().GetDeleteSelectedCoursesButtonName()));
            Logger.LogMethodExit("CreateCourse",
               "VerifyNewSearchAndDeleteSelectedCourseButton",
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
