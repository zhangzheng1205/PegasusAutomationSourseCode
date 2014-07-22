#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles User Enrollment actions
    /// </summary>
    [Binding]
    public class UserEnrollment : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(UserEnrollment));

        /// <summary>
        ///Select Course To Enroll Users
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type enum.</param>
        [When(@"I select the created ""(.*)"" course")]
        public void SelectCourseToEnrollUsers(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("UserEnrollment", "SelectCourseToEnrollUsers",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch course name from memory
            Course course = Course.Get(courseTypeEnum);
            //Selection of course in right frame
            new ManageCoursesPage().SelectCourse(course.Name);
            Logger.LogMethodExit("UserEnrollment", "SelectCourseToEnrollUsers",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select WS user from the left frame.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type enum.</param>
        [When(@"I select the ""(.*)"" user")]
        public void SelectWsUserInLeftFrame(
            User.UserTypeEnum userTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("UserEnrollment", "SelectWSUserInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch user name from memory
            User user = User.Get(userTypeEnum);   
            // User search in left frame
            new AdminToolPage().UserSearch(user.Name);
            //Select User
            new ManageUsersPage().SelectUser(user.Name);
            Logger.LogMethodExit("UserEnrollment", "SelectWSUserInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enroll user to the master course.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type enum.</param>
        [When(@"I enroll the ""(.*)"" in the selected course")]
        public void EnrollTheUserInTheCourse(
            User.UserTypeEnum userTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("UserEnrollment", "EnrollTheUserInTheCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Enroll user to the course
            new AdminToolPage().EnrollUserInCourse(userTypeEnum);
            Logger.LogMethodExit("UserEnrollment", "EnrollTheUserInTheCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// See The Enrolled User In The Manage Courses Frame.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type enum.</param>
        [Then(@"I should see the enrolled ""(.*)"" in the Manage Courses frame")]
        public void CheckEnrolledUserInsideCourse(
            User.UserTypeEnum userTypeEnum)
        {
            //To See The Enrolled User Inside The Course
            Logger.LogMethodEntry("UserEnrollment", "EnrollTheUserInTheCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch User's Last Name From Memory
            User user = User.Get(userTypeEnum);
            //Asert The Last Name Of The User
            Logger.LogAssertion("UserEnrollment",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.LastName,
            new UserEnrollmentPage().GetEnrolledUserLastName(user.LastName)));
            Logger.LogMethodExit("UserEnrollment", "EnrollTheUserInTheCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This function verifies the availability of the master library in right frame.
        /// </summary>
        /// <param name="classTypeEnum">This is class by type enum.</param>
        [When(@"I select the ""(.*)"" class")]
        public void SelectMasterLibraryClass(
            Class.ClassTypeEnum classTypeEnum)
        {
            //Select master library class in right frame
            Logger.LogMethodEntry("UserEnrollment", "SelectMasterLibraryClass",
             base.isTakeScreenShotDuringEntryExit);
            //Select Master library class on the right frame
            new OrgAdminEnrollClassesPage().SelectMasterLibraryClass(classTypeEnum);
            Logger.LogMethodExit("UserEnrollment", "SelectMasterLibraryClass",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select users under the user frame in Enrollment.
        /// </summary>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [When(@"I select the ""(.*)"" under User Frame")]
        public void SelectUserInLeftFrame(
            User.UserTypeEnum userTypeEnum)
        {
            //Select users in left frame
            Logger.LogMethodEntry("UserEnrollment", "SelectUserInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
            // Get the user
            User user = User.Get(userTypeEnum);
            // Select the user in left frame
            new OrgAdminUserEnrollmentPage().SelectUserInLeftFrame(user.Name);
            Logger.LogMethodExit("UserEnrollment", "SelectUserInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select Enroll button in middle frame.
        /// </summary>
        [When(@"I select the Enroll button")]
        public void SelectEnrollButton()
        {
            //Select enroll button
            Logger.LogMethodEntry("UserEnrollment", "SelectEnrollButton",
                base.isTakeScreenShotDuringEntryExit);
            // Click on enroll button in middle frame
            new OrgEnrollmentPage().SelectEnrollButton();
            Logger.LogMethodExit("UserEnrollment", "SelectEnrollButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check user enrolled successfully message.
        /// </summary>
        [Then(@"I should see the successfull message 'Users enrolled successfully'")]
        public void CheckEnrollmentSuccessfullMessage()
        {
            //Select enroll button
            Logger.LogMethodEntry("UserEnrollment", "CheckEnrollmentSuccessfullMessage",
                base.isTakeScreenShotDuringEntryExit);
            //Assert we have correct message displayed
            Logger.LogAssertion("VerifySuccessMessageDisplay",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true, new OrgAdminUserEnrollmentPage()
                    .GetSuccessfulMessageText().Contains(UserEnrollmentResource.
                    UserEnrollment_Enrollment_SuccessMessage_Text)));
            Logger.LogMethodExit("UserEnrollment", "CheckEnrollmentSuccessfullMessage",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select the User in the Right Frame.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I select the ""(.*)"" in the enrolled course")]
        public void SelectTheUserInTheEnrolledCourse(
            User.UserTypeEnum userTypeEnum)
        {
            //Select the User in the Right Frame
            Logger.LogMethodEntry("UserEnrollment", "SelectTheUserInTheEnrolledCourse",
               base.isTakeScreenShotDuringEntryExit);
            // Get the user
            User user = User.Get(userTypeEnum);
            //Select the User in the Right Frame
            new UserEnrollmentPage().SelectUserInRightFrame(user.LastName);
            Logger.LogMethodExit("UserEnrollment", "SelectTheUserInTheEnrolledCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Un Enroll the Selected User from the Course.
        /// </summary>
        [When(@"I Unenroll the 'user' from the course")]
        public void UnenrollTheUserInTheSelectedCourse()
        {
            //Un Enroll the Selected User from the Course
            Logger.LogMethodEntry("UserEnrollment", "UnenrollTheInTheSelectedCourse",
               base.isTakeScreenShotDuringEntryExit);
            //Click on Un Enroll Selected Users Option
            new UserEnrollmentPage().ClickOnUnEnrollSelectedUsersOption();
            Logger.LogMethodExit("UserEnrollment", "UnenrollTheInTheSelectedCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Add Buttom In Administrator Tab.
        /// </summary>
        [When(@"I click the Add button")]
        public void ClickTheAddButtomInAdministratorTab()
        {
            //Click The Add Buttom In Administrator Tab
            Logger.LogMethodEntry("UserEnrollment", "ClickTheAddButtomInAdministratorTab",
               base.isTakeScreenShotDuringEntryExit);
            //Click On The Add Buttom In Administrator Tab
            new EnrollmentPage().ClickEnrollButton();
            Logger.LogMethodExit("UserEnrollment", "ClickTheAddButtomInAdministratorTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Promoted Workspace Admin.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see the ""(.*)"" as Promoted Workspace Admin")]
        public void VerifyThePromotedWorkspaceAdmin(
            User.UserTypeEnum userTypeEnum)
        {
            //Verify The Promoted Workspace Admin
            Logger.LogMethodEntry("UserEnrollment", "VerifyThePromotedWorkspaceAdmin",
               base.isTakeScreenShotDuringEntryExit);
            //Get the user name from memory
              User user = User.Get(userTypeEnum);                    
            // Assert for Promoted workspace admin
            Logger.LogAssertion("VerifyPromotedWorkspaceAdmin",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(user.LastName,
                    new EnrollmentPage().GetPromotedWorkspaceAdminName(user.LastName)));           
            Logger.LogMethodExit("UserEnrollment", "VerifyThePromotedWorkspaceAdmin",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Administrator Tool Page.
        /// </summary>
        [When(@"I am on the 'Administration Tool' page")]
        [Given(@"I am on the 'Administration Tool' page")]
        public void NavigateToAdministratorToolPage()
        {
            //Navigate To Administrator Tool Page
            Logger.LogMethodEntry("UserEnrollment", "NavigateToAdministratorToolPage",
               base.isTakeScreenShotDuringEntryExit);
            //Navigate Administrator Tool Page
            new AdminToolPage().NavigateAdministratorToolPage();
            Logger.LogMethodExit("UserEnrollment", "NavigateToAdministratorToolPage",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Promoted Admin.
        /// </summary>
        /// <param name="userTypeEnum">This is User type by enum.</param>
        [When(@"I search the ""(.*)"" in Administrator tab")]
        public void SearchThePromotedAdmin(
            User.UserTypeEnum userTypeEnum)
        {
            //Search The Promoted Admin
            Logger.LogMethodEntry("UserEnrollment", "SearchThePromotedAdmin",
               base.isTakeScreenShotDuringEntryExit);
            //Get the user name from memory
             User user = User.Get(userTypeEnum); 
            //Declaration Page Class Object
            EnrollmentPage enrollmentPage = new EnrollmentPage();
            //Search The Promoted Admin
            enrollmentPage.SearchThePromotedAdmin(user.LastName, userTypeEnum);           
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.DPCourseSpacePramotedAdmin:
                    //Click The ManageAccess Cmenu In Administrator Tab
                    enrollmentPage.ClickTheManageAccessCmenuInAdministratorTab();
                    //Save The Manage Access Save Button
                    enrollmentPage.SaveTheManageAccessSaveButton();
                    break;
            }
            Logger.LogMethodExit("UserEnrollment", "SearchThePromotedAdmin",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Unenroll Selected User Button.
        /// </summary>
        [When(@"I click on the 'Unenroll Selected Users' button")]
        public void ClickOnTheUnenrollSelectedUserButton()
        {
            //Click On The Unenroll Selected User Button
            Logger.LogMethodEntry("UserEnrollment", "ClickOnTheUnenrollSelectedUserButton",
               base.isTakeScreenShotDuringEntryExit);
            //Click UnEnroll Cmenu Option In Ws Admin
            new EnrollmentPage().ClickUnEnrollSelectedUsersInWsAdmin();
            Logger.LogMethodExit("UserEnrollment", "ClickOnTheUnenrollSelectedUserButton",
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
