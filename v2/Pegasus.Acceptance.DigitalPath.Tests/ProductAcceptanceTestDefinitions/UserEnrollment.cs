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
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch course name from memory
            Course course = Course.Get(courseTypeEnum);
            //Selection of course in right frame
            new ManageCoursesPage().SelectCourse(course.Name);
            Logger.LogMethodExit("UserEnrollment", "SelectCourseToEnrollUsers",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch user name from memory
            User user = User.Get(userTypeEnum);   
            // User search in left frame
            new AdminToolPage().UserSearch(user.Name);
            //Select User
            new ManageUsersPage().SelectUser(user.Name);
            Logger.LogMethodExit("UserEnrollment", "SelectWSUserInLeftFrame",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Enroll user to the course
            new AdminToolPage().EnrollUserInCourse(userTypeEnum);
            Logger.LogMethodExit("UserEnrollment", "EnrollTheUserInTheCourse",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch User's Last Name From Memory
            User user = User.Get(userTypeEnum);
            //Asert The Last Name Of The User
            Logger.LogAssertion("UserEnrollment",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.LastName,
            new UserEnrollmentPage().GetEnrolledUserLastName(user.LastName)));
            Logger.LogMethodExit("UserEnrollment", "EnrollTheUserInTheCourse",
                base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
            //Select Master library class on the right frame
            new OrgAdminEnrollClassesPage().SelectMasterLibraryClass(classTypeEnum);
            Logger.LogMethodExit("UserEnrollment", "SelectMasterLibraryClass",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            // Get the user
            User user = User.Get(userTypeEnum);
            // Select the user in left frame
            new OrgAdminUserEnrollmentPage().SelectUserInLeftFrame(user.Name);
            Logger.LogMethodExit("UserEnrollment", "SelectUserInLeftFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select Enroll button in middle frame.
        /// </summary>
        [When(@"I select the Enroll button")]
        public void SelectEnrollButton()
        {
            //Select enroll button
            Logger.LogMethodEntry("UserEnrollment", "SelectEnrollButton",
                base.IsTakeScreenShotDuringEntryExit);
            // Click on enroll button in middle frame
            new OrgEnrollmentPage().SelectEnrollButton();
            Logger.LogMethodExit("UserEnrollment", "SelectEnrollButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check user enrolled successfully message.
        /// </summary>
        [Then(@"I should see the successfull message 'Users enrolled successfully'")]
        public void CheckEnrollmentSuccessfullMessage()
        {
            //Select enroll button
            Logger.LogMethodEntry("UserEnrollment", "CheckEnrollmentSuccessfullMessage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert we have correct message displayed
            Logger.LogAssertion("VerifySuccessMessageDisplay",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true, new OrgAdminUserEnrollmentPage()
                    .GetSuccessfulMessageText().Contains(UserEnrollmentResource.
                    UserEnrollment_Enrollment_SuccessMessage_Text)));
            Logger.LogMethodExit("UserEnrollment", "CheckEnrollmentSuccessfullMessage",
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            // Get the user
            User user = User.Get(userTypeEnum);
            //Select the User in the Right Frame
            new UserEnrollmentPage().SelectUserInRightFrame(user.LastName);
            Logger.LogMethodExit("UserEnrollment", "SelectTheUserInTheEnrolledCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Un Enroll the Selected User from the Course.
        /// </summary>
        [When(@"I Unenroll the 'user' from the course")]
        public void UnenrollTheUserInTheSelectedCourse()
        {
            //Un Enroll the Selected User from the Course
            Logger.LogMethodEntry("UserEnrollment", "UnenrollTheInTheSelectedCourse",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on Un Enroll Selected Users Option
            new UserEnrollmentPage().ClickOnUnEnrollSelectedUsersOption();
            Logger.LogMethodExit("UserEnrollment", "UnenrollTheInTheSelectedCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Add Buttom In Administrator Tab.
        /// </summary>
        [When(@"I click the Add button")]
        public void ClickTheAddButtomInAdministratorTab()
        {
            //Click The Add Buttom In Administrator Tab
            Logger.LogMethodEntry("UserEnrollment", "ClickTheAddButtomInAdministratorTab",
               base.IsTakeScreenShotDuringEntryExit);
            //Click On The Add Buttom In Administrator Tab
            new EnrollmentPage().ClickEnrollButton();
            Logger.LogMethodExit("UserEnrollment", "ClickTheAddButtomInAdministratorTab",
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Get the user name from memory
              User user = User.Get(userTypeEnum);                    
            // Assert for Promoted workspace admin
            Logger.LogAssertion("VerifyPromotedWorkspaceAdmin",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(user.LastName,
                    new EnrollmentPage().GetPromotedWorkspaceAdminName(user.LastName)));           
            Logger.LogMethodExit("UserEnrollment", "VerifyThePromotedWorkspaceAdmin",
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Administrator Tool Page
            new AdminToolPage().NavigateAdministratorToolPage();
            Logger.LogMethodExit("UserEnrollment", "NavigateToAdministratorToolPage",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Unenroll Selected User Button.
        /// </summary>
        [When(@"I click on the 'Unenroll Selected Users' button")]
        public void ClickOnTheUnenrollSelectedUserButton()
        {
            //Click On The Unenroll Selected User Button
            Logger.LogMethodEntry("UserEnrollment", "ClickOnTheUnenrollSelectedUserButton",
               base.IsTakeScreenShotDuringEntryExit);
            //Click UnEnroll Cmenu Option In Ws Admin
            new EnrollmentPage().ClickUnEnrollSelectedUsersInWsAdmin();
            Logger.LogMethodExit("UserEnrollment", "ClickOnTheUnenrollSelectedUserButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Create new button in Manage students pop up.
        /// </summary>
        [When(@"I Click on Create New button")]
        public void ClickOnCreateNewButton()
        {
            //Click on create new button
            Logger.LogMethodEntry("UserEnrollment", "ClickOnCreateNewButton",
               base.IsTakeScreenShotDuringEntryExit);
            new GBRosterGridUXPage().ClickOnCreateNewButton();
            Logger.LogMethodExit("UserEnrollment", "ClickOnCreateNewButton",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select option from Create new drop down.
        /// </summary>
        /// <param name="dropDownOption">Drop option to be selected.</param>
        [When(@"I select ""(.*)"" drop down option")]
        public void SelectDropDownOption(string dropDownOption)
        {
            //Click on create new button
            Logger.LogMethodEntry("UserEnrollment", "SelectDropDownOption",
               base.IsTakeScreenShotDuringEntryExit);
            new GBRosterGridUXPage().SelectOptionsUnderCreateNewDropDown(dropDownOption);
            Logger.LogMethodExit("UserEnrollment", "SelectDropDownOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on search button in Enroll from School pop up.
        /// </summary>
        [When(@"I click on Search button")]
        public void ClickOnSearchButton()
        {
            //Click on search button
            Logger.LogMethodEntry("UserEnrollment", "ClickOnSearchButton",
               base.IsTakeScreenShotDuringEntryExit);
            new GBRoasterEnrollFrmSchoolPage().ClickOnSearchButton();
            Logger.LogMethodExit("UserEnrollment", "ClickOnSearchButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search users in Enroll from school pop up.
        /// </summary>
        /// <param name="userName">Name of the user to search.</param>
        [When(@"I enter student username ""(.*)"" to search")]
        public void SearchUsers(User.UserTypeEnum userTypeEnum)
        {
            //Search users
            Logger.LogMethodEntry("UserEnrollment", "SearchUsers",
               base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            string studentname = user.Name.ToString();
            new GBRoasterEnrollFrmSchoolPage().SearchForUsers(studentname);
            Logger.LogMethodExit("UserEnrollment", "SearchUsers",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the searched user name.
        /// </summary>
        /// <param name="userName">Username to validate.</param>
        [Then(@"I should see searched username ""(.*)"" in search list")]
        public void ValidateSearchedUserName(User.UserTypeEnum userTypeEnum)
        {
            //Validate searched user name
            Logger.LogMethodEntry("UserEnrollment", "ValidateSearchedUserName",
               base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            string studentname = user.Name.ToString();
            Logger.LogAssertion("UserEnrollment", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(studentname, new GBRoasterEnrollFrmSchoolPage().GetUserNameFromSearchResult()));
            Logger.LogMethodExit("UserEnrollment", "ValidateSearchedUserName",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enroll student to class
        /// </summary>
        [When(@"I select the student and click on Add button")]
        public void EnrollStudent()
        {
            //Enroll student to class
            Logger.LogMethodEntry("UserEnrollment", "EnrollStudent",
               base.IsTakeScreenShotDuringEntryExit);
            new GBRoasterEnrollFrmSchoolPage().EnrollUser();
            Logger.LogMethodExit("UserEnrollment", "EnrollStudent",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the success message in enroll from school pop up.
        /// </summary>
        /// <param name="sucessMessage">Success message to validate.</param>
        [Then(@"I should see the success message ""(.*)""")]
        public void ValidateSuccessMessage(string sucessMessage)
        {
            //Validate success message
            Logger.LogMethodEntry("UserEnrollment", "ValidateSuccessMessage",
               base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("UserEnrollment", ScenarioContext.Current.ScenarioInfo.Title,
                 () => Assert.AreEqual(sucessMessage, new GBRoasterEnrollFrmSchoolPage().GetSuccessMessage()));
            Logger.LogMethodExit("UserEnrollment", "ValidateSuccessMessage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close the enroll from school popup.
        /// </summary>
        [When(@"I close Enroll from school pop up")]
        public void CloseEnrollFromSchoolPopup()
        {
            //Close the enroll from school popup
            Logger.LogMethodEntry("UserEnrollment", "CloseEnrollFromSchoolPopup",
               base.IsTakeScreenShotDuringEntryExit);
            new GBRoasterEnrollFrmSchoolPage().ClickOnCloseButton();
            Logger.LogMethodExit("UserEnrollment", "CloseEnrollFromSchoolPopup",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close manage student pop up.
        /// </summary>
        [When(@"I close Manage student pop up")]
        public void ClickOnCloseButtonInManageStudentsPopUp()
        {
            //Click on close button
            Logger.LogMethodEntry("UserEnrollment", "ClickOnCloseButtonInManageStudentsPopUp",
               base.IsTakeScreenShotDuringEntryExit);
            new GBRosterGridUXPage().ClickOnCloseButton();
            base.SelectDefaultWindow();
            Logger.LogMethodExit("UserEnrollment", "ClickOnCloseButtonInManageStudentsPopUp",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate the presence of Enroll from school pop up.
        /// </summary>
        /// <param name="popUpName">Pop up name to validate.</param>
        [Then(@"I should see ""(.*)"" pop up closed")]
        public void ValidateClosureOfPopUp(string popUpName)
        {
            //Validate the presence of Enroll from school pop up.
            Logger.LogMethodEntry("UserEnrollment", "ValidateClosureOfPopUp",
               base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("UserEnrollment", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsFalse(new GBRoasterEnrollFrmSchoolPage().IsEnrollFromSchoolPopupClosed(popUpName)));
            Logger.LogMethodExit("UserEnrollment", "ValidateClosureOfPopUp",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the enrolled student display in Manage students
        /// pop up.
        /// </summary>
        /// <param name="studentName">Name of the student to validate.</param>
        [Then(@"I should see the student ""(.*)"" displayed in manage student pop up")]
        public void ValidateEnrolledStudentDisplay(User.UserTypeEnum userTypeEnum)
        {
            //Validate display of enrolled user
            Logger.LogMethodEntry("UserEnrollment", "ValidateEnrolledStudentDisplay",
               base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            string studentName = user.Name.ToString();
            Logger.LogAssertion("UserEnrollment", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new GBRosterGridUXPage().
                   IsEnrolledStudentDisplayedUnderRoster(studentName)));
            Logger.LogMethodExit("UserEnrollment", "ValidateEnrolledStudentDisplay",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Update user profile details in class roaster
        /// </summary>
        /// <param name="cmenuOption">This is the cmenu option name.</param>
        /// <param name="userData">This is the user name.</param>
        [When(@"I click on ""(.*)"" cmenu option of the student ""(.*)""")]
        public void ClickCmenuOfUserInManageRoaster(string cmenuOption, User.UserTypeEnum userData)
        {
            Logger.LogMethodEntry("ManageStudentsDefaultPage", "ClickCmenuOfUserInManageRoaster",
                base.IsTakeScreenShotDuringEntryExit);
            new ManageStudentsDefaultPage().ClickUserCmenuInManageRoaster(cmenuOption, userData);
            Logger.LogMethodExit("ManageStudentsDefaultPage", "ClickCmenuOfUserInManageRoaster",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student from the Class Roster frame
        /// </summary>
        /// <param name="userName">This is the usertype enum.</param>
        [When(@"I unenroll student ""(.*)"" from Class Roster frame")]
        public void SelectStudentFromClassRosterFrame(User.UserTypeEnum userName)
        {
            Logger.LogMethodEntry("UserEnrollment", "SelectStudentFromClassRosterFrame",
                  base.IsTakeScreenShotDuringEntryExit);
            User userNameText = User.Get(userName);
            string userNameTitle = userNameText.Name.ToString();
            new GBRoasterEnrollFrmSchoolPage().UnenrollUserEnrollFromSchoolPopup(userNameTitle);
            Logger.LogMethodExit("UserEnrollment", "SelectStudentFromClassRosterFrame",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Validate the non availablity of Unenrolled student in Manage students
        /// pop up.
        /// </summary>
        /// <param name="studentName">Name of the student to validate.</param>
        [Then(@"I should see the student ""(.*)"" not displayed in manage student pop up")]
        public void ValidateNonAvailablityOfUnEnrolledStudent(User.UserTypeEnum userTypeEnum)
        {
            //Validate display of enrolled user
            Logger.LogMethodEntry("UserEnrollment", "ValidateNonAvailablityOfUnEnrolledStudent",
               base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            string studentName = user.Name.ToString();
            Logger.LogAssertion("UserEnrollment", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsFalse(new GBRosterGridUXPage().
                   IsEnrolledStudentDisplayedUnderRoster(studentName)));
            Logger.LogMethodExit("UserEnrollment", "ValidateNonAvailablityOfUnEnrolledStudent",
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
