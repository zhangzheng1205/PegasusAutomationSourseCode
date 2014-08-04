using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.HigherEducation.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
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
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I create Template using ""(.*)"" course as a program admin")]
        public void CreateNewTemplateAsProgramAdmin(
             Course.CourseTypeEnum courseTypeEnum)
        {
            //Create New Template
            Logger.LogMethodEntry("ProgramAdmin", "CreateNewTemplateAsTheProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Create New Template 
            new ManageTemplatePage().CreatTemplate(course.Name);
            Logger.LogMethodExit("ProgramAdmin", "CreateNewTemplateAsTheProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Add Sections Link.
        /// </summary>
        [When(@"I click on Add Sections link from the Program Administration page")]
        public void ClickOnAddSectionsLink()
        {
            //Click on 'Add Sections' Link
            Logger.LogMethodEntry("ProgramAdmin", "ClickOnAddSectionsLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Add New Sections Link
            new ManageTemplatePage().ClickOnAddNewSectionsLink();
            Logger.LogMethodExit("ProgramAdmin", "ClickOnAddSectionsLink",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("ProgramAdmin", "CreateSectionAsProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
            //Create New Section 
            new AddNewSectionPage().CreateNewSection(courseTypeEnum);
            Logger.LogMethodExit("ProgramAdmin", "CreateSectionAsProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Section in Active State.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I verify the Section created from ""(.*)"" course Template for AssignedToCopy state")]
        public void SectionInAssignedToCopyState(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Section in Active State
            Logger.LogMethodEntry("ProgramAdmin", "SectionInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Approve Section in Active State
            new ManageTemplatePage().ApproveInActiveStateOfEntityInProgramAdministration(
                course.SectionName);
            Logger.LogMethodExit("ProgramAdmin", "SectionInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Section in Active State or not.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [Then(@"I should see the Section created from ""(.*)"" course Template to be successfully out of AssignedToCopy state")]
        public void ApproveAssignedToCopyStateForSection(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Section in Active State
            Logger.LogMethodEntry("ProgramAdmin", "ApproveAssignedToCopyStateForSection",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Verify Template in Active State or not
            Logger.LogAssertion("VerifyTemplateActiveState",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(false, new ManageTemplatePage().
                GetAssignToCopyStateText
                (course.SectionName).Contains(ProgramAdminResource.
                ProgramAdmin_Page_AssignToCopyState_Text_Value)));
            Logger.LogMethodExit("ProgramAdmin", "ApproveAssignedToCopyStateForSection",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Template in Active State.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I verify the ""(.*)"" course Template for AssignedToCopy state")]
        public void TemplateInAssignedToCopyState(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Template in Active State
            Logger.LogMethodEntry("ProgramAdmin", "TemplateInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Verify Template in Active State
            new ManageTemplatePage().
                ApproveInActiveStateOfEntityInProgramAdministration(course.Name);
            Logger.LogMethodExit("ProgramAdmin", "TemplateInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Template in Active State or not.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [Then(@"I should see the ""(.*)"" course Template to be successfully out of AssignedToCopy state")]
        public void ApproveAssignedToCopyStateForTemplate(
            Course.CourseTypeEnum courseTypeEnum)
        {
            Logger.LogMethodEntry("ProgramAdmin", "ApproveAssignedToCopyStateForTemplate",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Verify Template in Active State or not
            Logger.LogAssertion("VerifyTemplateActiveState",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(false, new ManageTemplatePage().
                GetAssignToCopyStateText(course.Name).Contains(ProgramAdminResource.
                ProgramAdmin_Page_AssignToCopyState_Text_Value)));
            Logger.LogMethodExit("ProgramAdmin", "ApproveAssignedToCopyStateForTemplate",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// verify user on Program Administration Page.
        /// </summary>
        [Given(@"I am on the Program Administration Page")]
        public void DisplayOfProgramAdministrationPage()
        {
            //To verify user is on Program Administration Page
            Logger.LogMethodEntry("ProgramAdmin", "DisplayOfProgramAdministrationPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert to verify is user on Program Administration page 
            Logger.LogAssertion("ProgramAdmin",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(base.IsWindowsExists(ProgramAdminResource.
                    ProgramAdmin_Page_Window_Title_Name)));
            Logger.LogMethodExit("ProgramAdmin", "DisplayOfProgramAdministrationPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify the display of user under Users Tab.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type Enum.</param>
        [Then(@"I should see enrolled ""(.*)""")]
        public void DisplayEnrolledUser(
            User.UserTypeEnum userTypeEnum)
        {
            // Verification of user display in Users Tab
            Logger.LogMethodEntry("ProgramAdmin", "DisplayEnrolledUser",
                base.IsTakeScreenShotDuringEntryExit);
            //Get user From Memory
            User user = User.Get(userTypeEnum);
            string studentUserName = new ProgramAdminUsersPage().
                GetUserName(user.Name);
            // Get first 15 characters of user name
            string userNameMemory = user.Name.Substring(0, 15);
            // Assert for Enrolled User Present
            Logger.LogAssertion("ProgramAdmin", ScenarioContext.
                Current.ScenarioInfo.Title,
              () => Assert.AreEqual(true,
                  studentUserName.Contains(userNameMemory)));
            Logger.LogMethodExit("ProgramAdmin", "DisplayEnrolledUser",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("ProgramAdmin",
                "SearchTheUserInTheUsersFrame",
                 base.IsTakeScreenShotDuringEntryExit);
            //Get user From Memory
            User user = User.Get(userTypeEnum);
            //Search user 
            new ProgramAdminManageUsersPage().SearchUser(user.Name);
            Logger.LogMethodExit("ProgramAdmin",
                "SearchTheUserInTheUsersFrame",
               base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("ProgramAdmin",
                "SeeTheSearchedUserInTheUsersFrame",
                 base.IsTakeScreenShotDuringEntryExit);
            //Get user From Memory
            User user = User.Get(User.UserTypeEnum.CsSmsStudent);            
            //Assert display of user
            Logger.LogAssertion("VerifyTheSearchedUserInTheUsersFrame",
                ScenarioContext.Current.ScenarioInfo.Title,
             () => Assert.AreEqual(true, new ProgramAdminManageUsersPage().
                 GetSearchedUser().Contains(user.Name)));
            Logger.LogMethodExit("ProgramAdmin",
                "SeeTheSearchedUserInTheUsersFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Searched User in the Users frame.
        /// </summary>
        [When(@"I Select the searched User in the Users frame")]
        public void SelectTheSearchedUserInTheUsersFrame()
        {
            // Selecting the searcged user under enrollment tab
            Logger.LogMethodEntry("ProgramAdmin",
                "SelectTheSearchedUserInTheUsersFrame",
                 base.IsTakeScreenShotDuringEntryExit);
            // Select searched User
            new ProgramAdminManageUsersPage().SelectAllUser();
            Logger.LogMethodExit("ProgramAdmin",
                "SelectTheSearchedUserInTheUsersFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the Section.
        /// </summary>
        [When(@"I search the Section2 in the Sections frame")]
        public void SearchTheSection2InTheSectionsFrame()
        {
            // Searching the section2
            Logger.LogMethodEntry("ProgramAdmin",
                "SearchTheSection2InTheSectionsFrame",
                 base.IsTakeScreenShotDuringEntryExit);
            //Get course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);
            //Search section2
            new ProgramAdminManageCourseTemplatesPage().SearchSection
                (course.SectionName + ProgramAdminResource.
                ProgramAdmin_Page_SecondSection_Value);
            Logger.LogMethodExit("ProgramAdmin",
                "SearchTheSection2InTheSectionsFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the searched section in section frame.
        /// </summary>
        [Then(@"I should see the searched section in section frame")]
        public void VerifyTheSearchedSectionInSectionFrame()
        {
            //Display of Seached Section Name
            Logger.LogMethodEntry("ProgramAdmin", "SeeTheSearchedSectionInSectionFrame",
                  base.IsTakeScreenShotDuringEntryExit);
            //Get course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);            
            // Assert for display of searched section 
            Logger.LogAssertion("VerifyTheSearchedSectionInSectionFrame",
                ScenarioContext.Current.ScenarioInfo.Title,
             () => Assert.AreEqual(true,
                new ProgramAdminManageCourseTemplatesPage().
                GetSearchedSection().Contains
                (course.SectionName)));
            Logger.LogMethodExit("ProgramAdmin",
                "SeeTheSearchedSectionInSectionFrame",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the searched section in enrollments tab.
        /// </summary>
        [When(@"I entered into the searched section")]
        public void EnterIntoTheSearchedSection()
        {
            //Enter In Searched Section
            Logger.LogMethodEntry("ProgramAdmin",
                "EnterIntoTheSearchedSection",
                  base.IsTakeScreenShotDuringEntryExit);
            //Click on the searched section
            new ProgramAdminManageCourseTemplatesPage().
                EnterIntoSection();
            Logger.LogMethodExit("ProgramAdmin",
                "EnterIntoTheSearchedSection",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enroll User to Section
        /// </summary>
        /// <param name="addUserOption">This is Add User Option</param>
        [When(@"I Enroll user to section using ""(.*)"" option")]
        public void EnrollUsertoSection(String addUserOption)
        {
            //Enrol User in Different Section
            Logger.LogMethodEntry("ProgramAdmin",
                "EnrollUsertoSection",
                 base.IsTakeScreenShotDuringEntryExit);
            //Creating object of page class
            EnrollmentMainPage enrollmentMainPage =
                new EnrollmentMainPage();
            //Click Enroll button
            enrollmentMainPage.ClickEnrollButton();
            // Select Add User Option link
            enrollmentMainPage.ClickonAddUserOption(addUserOption);
            Logger.LogMethodExit("ProgramAdmin",
                "EnrollUsertoSection",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Cmenu of Section or Template.
        /// </summary>
        /// <param name="cMenuOption">This is Cmenu option.</param>
        [When(@"I click the ""(.*)"" option")]
        public void ClickOnCmenuOfSectionOrTemplate(String cMenuOption)
        {
            //Click on Cmenu of Section or Template
            Logger.LogMethodEntry("ProgramAdmin", "ClickOnCmenuOfSectionOrTemplate"
                , base.IsTakeScreenShotDuringEntryExit);
            //Click on Cmenu of Section or Template
            new ManageTemplatePage().
                ClickOnCmenuOfSectionOrTemplate(cMenuOption);
            Logger.LogMethodExit("ProgramAdmin", "ClickOnCmenuOfSectionOrTemplate"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Section Name and ID After Enter Inside the Section.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [Then(@"I should see the section name and ID of ""(.*)""")]
        public void VerifySectionNameandIDAfterEnterInsideSection(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify the Section Name and ID After Enter Inside the Section
            Logger.LogMethodEntry("ProgramAdmin",
                "VerifySectionNameandIDAfterEnterInsideSection"
                 , base.IsTakeScreenShotDuringEntryExit);
            //Get course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);
            //Get Section Name
            string sectionName = course.SectionName +
                (ProgramAdminResource.ProgramAdmin_Page_First_Section_Value);
            // Assert for display of section name after enter inside the section 
            Logger.LogAssertion("VerifySectionNameAfterEnterInsideSection",
                ScenarioContext.Current.ScenarioInfo.Title,
             () => Assert.AreEqual(sectionName,new TodaysViewUXPage().GetCourseName()));
            // Assert for display of section ID after enter inside the section
            Logger.LogAssertion("VerifySectionIDAfterEnterInsideSection",
               ScenarioContext.Current.ScenarioInfo.Title,
            () => Assert.AreEqual(course.SectionId,
               new TodaysViewUXPage().GetSectionIDAfterEnterInsideSection()));
            Logger.LogMethodExit("ProgramAdmin",
                "VerifySectionNameandIDAfterEnterInsideSection"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Course Name
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [Then(@"I should see the ""(.*)"" course")]
        public void DisplayOfCourseName(Course.CourseTypeEnum courseTypeEnum)
        {
            // Verify the Display Of Course Name 
            Logger.LogMethodEntry("ProgramAdmin", "DisplayOfCourseName",
                base.IsTakeScreenShotDuringEntryExit);
            // Get the Course Name
            Course course = Course.Get(courseTypeEnum);
            // Assert Course Name 
            Logger.LogAssertion("VerifyCourseName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(course.Name,new TodaysViewUXPage().GetCourseName()));
            Logger.LogMethodExit("ProgramAdmin", "DisplayOfCourseName",
                base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Search the Section.
        /// </summary>
        [When(@"I search the Section1 in the Sections frame")]
        public void SearchTheSection1InSectionsFrame()
        {
            // Search the section
            Logger.LogMethodEntry("ProgramAdmin",
                "SearchTheSection1InSectionsFrame",
                 base.IsTakeScreenShotDuringEntryExit);
            //Get course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);
            //Search section1
            new ProgramAdminManageCourseTemplatesPage().SearchSection
                (course.SectionName + (ProgramAdminResource.
                ProgramAdmin_Page_First_Section_Value));
            Logger.LogMethodExit("ProgramAdmin",
                "SearchTheSection1InSectionsFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Student Promoted as Teaching Assistant in Section
        /// </summary>
        [Then(@"I should see the student promoted as Teaching Assistant in section")]
        public void VerifyTheStudentPromotedasTeachingAssistantInSection()
        {
            //Verify the Student Promoted as Teaching Assistant in Section
            Logger.LogMethodEntry("ProgramAdmin",
                 "VerifyTheStudentPromotedasTeachingAssistantInSection",
                  base.IsTakeScreenShotDuringEntryExit);
            // Assert the Student Promoted as Teaching Assistant in Section
            Logger.LogAssertion("ProgramAdmin",
              ScenarioContext.Current.ScenarioInfo.Title,
           () => Assert.AreEqual(true,
               new ProgramAdminManageCourseTemplatesPage().
               IsTeachingAssistantPresentinSection()));
            Logger.LogMethodExit("ProgramAdmin",
               "VerifyTheStudentPromotedasTeachingAssistantInSection",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Derive Section From Parent Section.
        /// </summary>
        [When(@"I derive section from parent section")]
        public void DeriveSectionFromParentSection()
        {
            //Derive Section From Parent Section
            Logger.LogMethodEntry("ProgramAdmin",
                 "DeriveSectionFromParentSection",
                  base.IsTakeScreenShotDuringEntryExit);
            //Derive Section From Parent Section
            new ManageTemplatePage().DeriveSectionFromParentSection();
            Logger.LogMethodExit("ProgramAdmin",
               "DeriveSectionFromParentSection",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Section.
        /// </summary>
        [When(@"I search section")]
        public void SearchTheSection()
        {
            Logger.LogMethodEntry("ProgramAdmin", "SearchTheSection",
                 base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.MySpanishLabMaster);
            //Search Section
            new ManageTemplatePage().SearchSection(course.SectionName);
            Logger.LogMethodExit("ProgramAdmin", "SearchTheSection",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Save Button click to create course Manage Template section
        /// </summary>
        /// <param name=""></param>
        [When(@"I click ""(.*)"" button to ""(.*)""")]
        public void ClickToCreateUpdate(string Button, String Operation)
        {
            Logger.LogMethodEntry("ProgramAdmin", "ClickSaveToCreateSharedLibrary",
                base.IsTakeScreenShotDuringEntryExit);
            //SaveUpdate method to create or update the course.
            new EditCopyTemplatesSectionsPage().CreateSharedLibrary();

            Logger.LogMethodExit("ProgramAdmin", "ClickSaveToCreateSharedLibrary",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// click on the copy button, during the copy of the template/section as template inside the program 
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        [When(@"I click ""(.*)"" button ""(.*)""")]
        public void ClickOnCopyButton(string Button, string Oparation)
        {
            Logger.LogMethodEntry("ProgramAdmin", "ClickOnCopyButton",
                base.IsTakeScreenShotDuringEntryExit);
            //SaveUpdate method to create or update the course.
            new EditCopyTemplatesSectionsPage().ClickToCreateUpdate();
            Logger.LogMethodExit("ProgramAdmin", "ClickOnCopyButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Copying the section from section inside the program
        /// </summary>
        /// <param name="Button"></param>
        /// <param name="Oparation"></param>
        [When(@"I click ""(.*)"" button to copy ""(.*)""")]
        public void ClickonCopySectionButton(string Button, string Oparation)
        {
            Logger.LogMethodEntry("ProgramAdmin", "ClickonCopySectionButton",
          base.IsTakeScreenShotDuringEntryExit);
            //SaveUpdate method to create or update the course.
            new EditCopyTemplatesSectionsPage().CopySection();
            Logger.LogMethodExit("ProgramAdmin", "ClickonCopySectionButton",
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
