using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Integration.Hed.ETextS11.Tests.IntegrationAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.ETextS11.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of Program Admin Actions
    /// Resposible to handle template, section, user and user
    /// enrollment in sections.
    /// </summary>
    [Binding]
    public class ProgramAdmin : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ProgramAdmin));

        /// <summary>
        /// Create Template as a Program Admin.
        /// </summary>
        [Then(@"I create Template as a Program Admin")]
        [When(@"I create Template as a Program Admin")]
        public void CreateNewTemplateAsProgramAdmin()
        {
            //Create New Template
            Logger.LogMethodEntry("ProgramAdmin",
                "CreateNewTemplateAsTheProgramAdmin",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(
                Course.CourseTypeEnum.MySpanishLabMaster);
            //Assert Create New Template 
            new ManageTemplatePage().CreatTemplate(course.Name);
            Logger.LogMethodExit("ProgramAdmin",
                "CreateNewTemplateAsTheProgramAdmin",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Add Sections Link.
        /// </summary>
        [When(@"I click on Add Sections link from the Program Administration page")]
        public void ClickOnAddSectionsLink()
        {
            //Click on 'Add Sections' Link
            Logger.LogMethodEntry("ProgramAdmin",
                "ClickOnAddSectionsLink",
                base.isTakeScreenShotDuringEntryExit);
            //Click on Add New Sections Link
            new ManageTemplatePage().ClickOnAddNewSectionsLink();
            Logger.LogMethodExit("ProgramAdmin",
                "ClickOnAddSectionsLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create New Section.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I create Section from ""(.*)"" Template as a Program Admin")]
        public void CreateSectionAsProgramAdmin(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Create New Section
            Logger.LogMethodEntry("ProgramAdmin",
                "CreateSectionAsProgramAdmin",
                base.isTakeScreenShotDuringEntryExit);
            //Create New Section 
            new AddNewSectionPage().CreateNewSection(courseTypeEnum);
            Logger.LogMethodExit("ProgramAdmin",
                "CreateSectionAsProgramAdmin",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Section in Active State.
        /// </summary>
        [When(@"I verified the Section for AssignedToCopy state")]
        public void SectionInAssignedToCopyState()
        {
            //Verify Section in Active State
            Logger.LogMethodEntry("ProgramAdmin", "SectionInAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);          
            //Approve Section in Active State
            new ManageTemplatePage().
                ApproveInActiveStateOfEntityInProgramAdministration(course.SectionName);
            Logger.LogMethodExit("ProgramAdmin", "SectionInAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Section in Active State or not.
        /// </summary>
        [Then(@"I should see the Section to be successfully out of AssignedToCopy state")]
        public void ApproveAssignedToCopyStateForSection()
        {
            //Verify Section in Active State
            Logger.LogMethodEntry("ProgramAdmin", "ApproveAssignedToCopyStateForSection",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);            
            //Assert Verify Template in Active State or not
            Logger.LogAssertion("VerifyTemplateActiveState",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(false, new ManageTemplatePage().GetAssignToCopyStateText
                (course.SectionName).Contains(ProgramAdminResource.
                ProgramAdmin_Page_AssignToCopyState_Text_Value)));
            Logger.LogMethodExit("ProgramAdmin", "ApproveAssignedToCopyStateForSection",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Template in Active State.
        /// </summary>
        [Then(@"I verify the Template for AssignedToCopy state")]
        [When(@"I verify the Template for AssignedToCopy state")]
        public void TemplateInAssignedToCopyState()
        {
            Logger.LogMethodEntry("ProgramAdmin", "TemplateInAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.MySpanishLabMaster);
            //Verify Template in Active State
            new ManageTemplatePage().ApproveInActiveStateOfEntityInProgramAdministration(course.Name);
            Logger.LogMethodExit("ProgramAdmin", "TemplateInAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Template in Active State or not.
        /// </summary>
        [Then(@"I should see the Template to be successfully out of AssignedToCopy state")]
        public void ApproveAssignedToCopyStateForTemplate()
        {
            Logger.LogMethodEntry("ProgramAdmin", "ApproveAssignedToCopyStateForTemplate",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.MySpanishLabMaster);
            //Assert Verify Template in Active State or not
            Logger.LogAssertion("VerifyTemplateActiveState",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(false, new ManageTemplatePage().
                GetAssignToCopyStateText(course.Name).Contains(ProgramAdminResource.
                ProgramAdmin_Page_AssignToCopyState_Text_Value)));
            Logger.LogMethodExit("ProgramAdmin", "ApproveAssignedToCopyStateForTemplate",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// verify user on Program Administration Page
        /// </summary>
        [Given(@"I am on the Program Administration Page")]
        public void DisplayOfProgramAdministrationPage()
        {
            //To verify user is on Program Administration Page
            Logger.LogMethodEntry("ProgramAdmin",
                "DisplayOfProgramAdministrationPage",
                base.isTakeScreenShotDuringEntryExit);
            //Assert to verify is user on Program Administration page 
            Logger.LogAssertion("ProgramAdmin",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(base.IsWindowsExists(ProgramAdminResource.
                    ProgramAdmin_Page_Window_Title_Name)));
            Logger.LogMethodExit("ProgramAdmin",
                "DisplayOfProgramAdministrationPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search user in Enrollment Tab.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I search the ""(.*)"" in the Users frame")]
        public void SearchTheUserInTheUsersFrame(
            User.UserTypeEnum userTypeEnum)
        {
            // Search the user in Enrollment Tab
            Logger.LogMethodEntry("ProgramAdmin", "SearchTheUserInTheUsersFrame",
                 base.isTakeScreenShotDuringEntryExit);
            //Get user From Memory
            User user = User.Get(userTypeEnum);
            //Search user 
            new ProgramAdminManageUsersPage().SearchUser(user.Name);
            Logger.LogMethodExit("ProgramAdmin", "SearchTheUserInTheUsersFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify the display of searched user.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see the searched ""(.*)"" in the Users frame")]
        public void SeeTheSearchedUserInTheUsersFrame(
            User.UserTypeEnum userTypeEnum)
        {
            //Verification of display of searched user
            Logger.LogMethodEntry("ProgramAdmin", "SeeTheSearchedUserInTheUsersFrame",
                 base.isTakeScreenShotDuringEntryExit);
            //Get user From Memory
            User user = User.Get(User.UserTypeEnum.CsSmsStudent);
            string userNameTrimmed = user.Name.Substring(0, 8);
            //Assert display of user
            Logger.LogAssertion("ProgramAdmin",
                ScenarioContext.Current.ScenarioInfo.Title,
             () => Assert.AreEqual(true, new ProgramAdminManageUsersPage().
                 GetSearchedUser().Contains(userNameTrimmed)));
            Logger.LogMethodExit("ProgramAdmin", "SeeTheSearchedUserInTheUsersFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Searched User in the Users frame.
        /// </summary>
        [When(@"I Select the Searched User in the Users frame")]
        public void SelectTheSearchedUserInTheUsersFrame()
        {
            // Selecting the searcged user under enrollment tab
            Logger.LogMethodEntry("ProgramAdmin",
                "SelectTheSearchedUserInTheUsersFrame",
                 base.isTakeScreenShotDuringEntryExit);
            // Select searched User
            new ProgramAdminManageUsersPage().SelectAllUser();
            Logger.LogMethodExit("ProgramAdmin",
                "SelectTheSearchedUserInTheUsersFrame",
               base.isTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Enter the searched section in enrollments tab.
        /// </summary>
        [When(@"I entered into the searched section")]
        public void EnterIntoTheSearchedSection()
        {
            //Enter In Searched Section
            Logger.LogMethodEntry("ProgramAdmin", "EnterIntoTheSearchedSection",
                  base.isTakeScreenShotDuringEntryExit);
            //Click on the searched section
            new ProgramAdminManageCourseTemplatesPage().EnterIntoSection();
            Logger.LogMethodExit("ProgramAdmin", "EnterIntoTheSearchedSection",
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
