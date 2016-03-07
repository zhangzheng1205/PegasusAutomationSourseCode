#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of the User's in Pegasus
    /// also handles the creation of different type of user's
    /// in Pegasus for each instances.
    /// </summary>
    [Binding]
    public class CreateUser : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CreateUser));

        /// <summary>
        /// Create New User In Pegasus.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type Enum.</param>
        [When("I create a new \"(.*)\" user")]
        public void CreateNewUser(User.UserTypeEnum userTypeEnum)
        {
            //Create Users by Type in Pegasus
            Logger.LogMethodEntry("CreateUser", "CreateNewUser",
                base.IsTakeScreenShotDuringEntryExit);
            //Create New User 
            new NewUserPage().CreateNewUserInWorkSpace(userTypeEnum);
            Logger.LogMethodExit("CreateUser", "CreateNewUser",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search WS user from the Manage Users frame.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type Enum.</param>
        [When(@"I search the created ""(.*)"" in  Manage Users frame")]
        public void SearchWsUser(User.UserTypeEnum userTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("CreateUser", "SearchWsUser",
                base.IsTakeScreenShotDuringEntryExit);
            //Get User Name from Memory
            User user = User.Get(userTypeEnum);
            // Search User in the Manage Users frame
            new AdminToolPage().UserSearch(user.Name);
            Logger.LogMethodExit("CreateUser", "SearchWsUser",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checks if Correct User is displayed.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type Enum.</param>
        [Then(@"I should see the ""(.*)"" in Manage Users frame")]
        public void ShowUserInManageUsersFrame(User.UserTypeEnum userTypeEnum)
        {
            //Checks the display of correct User
            Logger.LogMethodEntry("CreateUser", "ShowUserInManageUsersFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Get User From Memory
            User user = User.Get(userTypeEnum);
            //Verify Username
            Logger.LogAssertion("VerifyUserName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.Name,
                    new ManageUsersPage().GetSearchedUserName()));
            Logger.LogMethodExit("CreateUser", "ShowUserInManageUsersFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To the Sub Tab.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>       
        [When(@"I click on the ""(.*)"" tab in Manage Organization page")]
        public void NavigateToSubTab(String tabName)
        {
            //Clicks on the sub Tab
            Logger.LogMethodEntry("CreateUser", "NavigateToSubTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Navigates to the sub tab
            new ManageUserPage().NavigateToSubTab((ManageUserPage.CreateUserTab)Enum.
                Parse(typeof(ManageUserPage.CreateUserTab), tabName));
            Logger.LogMethodExit("CreateUser", "NavigateToSubTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Refresh Student link
        /// </summary>
        [When(@"I click on Refresh Students link")]
        public void ClickRefreshStudentsLink()
        {
            Logger.LogMethodEntry("CreateUser",
                "ClickRefreshStudentsLink",
                base.IsTakeScreenShotDuringEntryExit);
            new ManageStudentsDefaultPage().ClickRefreshStudentsLink();
            Logger.LogMethodExit("CreateUser",
                "ClickRefreshStudentsLink",
                base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Verify the success message on ManageOrganization popup.
        /// </summary>
        /// <param name="successMessage">This is the Success Message.</param>
        [Then(@"I should see successfull message ""(.*)""")]
        public void VerifyTheSuccessfullMessage(string successMessage)
        {
            // Method To Verify the Success Message 
            Logger.LogMethodEntry("CommonSteps", "DisplayTheSuccessfullMessageInWindow",
                IsTakeScreenShotDuringEntryExit);
            //Assert for Successfull Message Displayed
            Logger.LogAssertion("VerifyTheSuccessfullMessage", ScenarioContext.
                   Current.ScenarioInfo.Title, () => Assert.AreEqual(successMessage,
                   new ManageOrganisationToolBarPage().GetSuccessfullMessageFromManageOrganizationPopup()));
            Logger.LogMethodExit("CommonSteps", "DisplayTheSuccessfullMessageInWindow",
                IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Selects the User Option.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="tabName">This is Tab Name.</param>
        [When(@"I select the ""(.*)"" option from ""(.*)"" subtab")]
        public void SelectUserOption(User.UserTypeEnum userTypeEnum,
            String tabName)
        {
            //Select the User Option
            Logger.LogMethodEntry("CreateUser", "SelectUserOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Add/Create Users link
            new ManageUserPage().ClickOnAddCreateUsersLink((
                ManageUserPage.CreateUserTab)Enum.
                Parse(typeof(ManageUserPage.CreateUserTab), tabName));
            //Select the userType
            new ManageUserPage().SelectUserType(userTypeEnum);
            Logger.LogMethodExit("CreateUser", "SelectUserOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create User In CourseSpace.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type Enum.</param>
        [When(@"I create a new ""(.*)"" user in Coursespace")]
        public void CreateNewUserInCourseSpace(User.UserTypeEnum userTypeEnum)
        {
            //Create User in Coursespace
            Logger.LogMethodEntry("CreateUser", "CreateNewUserInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
            //Create Cs User
            new AddUserPage().CreateNewUser(userTypeEnum);
            Logger.LogMethodExit("CreateUser", "CreateNewUserInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the User in Coursespace.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="tabName">This is Tab Name.</param>
        [When(@"I search the created ""(.*)"" in ""(.*)"" subtab")]
        public void SearchUserInCourseSpace(
            User.UserTypeEnum userTypeEnum, String tabName)
        {
            //Search the User
            Logger.LogMethodEntry("CreateUser", "SearchUserInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
            //Search User
            new ManageUserPage().SearchUserInCourseSpace(userTypeEnum,
                (ManageUserPage.CreateUserTab)Enum.
                Parse(typeof(ManageUserPage.CreateUserTab), tabName));
            Logger.LogMethodExit("CreateUser", "SearchUserInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Searched User.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="tabName">This is Tab Name.</param>
        [Then(@"I should see the ""(.*)"" in ""(.*)"" subtab")]
        public void DisplayOfUserInCourseSpace(
            User.UserTypeEnum userTypeEnum, String tabName)
        {
            //Verify the Searched User
            Logger.LogMethodEntry("CreateUser", "DisplayOfUserInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the User From Memory
            User user = User.Get(userTypeEnum);
            //Verify the Searched User
            Logger.LogAssertion("VerifyUserName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.Name, new ManageUserPage().
                    GetSearchedUserInCourseSpace
                    ((ManageUserPage.CreateUserTab)Enum.
                    Parse(typeof(ManageUserPage.CreateUserTab), tabName))));
            Logger.LogMethodExit("CreateUser", "DisplayOfUserInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects the Bulk User Option and Uploads the Bulk User File.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>
        [When(@"I select the Bulk user upload option and Import a bulk users file in ""(.*)"" subtab")]
        public void BulkUserUploadInCourseSpace(String tabName)
        {
            //Bulk User Upload in Users Tab
            Logger.LogMethodEntry("CreateUser", "BulkUserUploadInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
            //Delete the Older Uploaded Files
            new BulkUploadQueuePage().DeleteOlderUploadedFiles();
            //Click on the Add Users link
            new ManageUserPage().ClickOnAddCreateUsersLink((
                ManageUserPage.CreateUserTab)Enum.
                Parse(typeof(ManageUserPage.CreateUserTab), tabName));
            //Upload the Users 
            new ManageUserPage().BulkUserUpload();
            Logger.LogMethodExit("CreateUser", "BulkUserUploadInCourseSpace",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Successfull Message For Upload Users.
        /// </summary>
        /// <param name="successMessage">This is the Successful Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in Users subtab")]
        public void SuccessfullMessageForUploadUsers(String successMessage)
        {
            //Verify Successfull Message For Upload Users
            Logger.LogMethodEntry("CreateUser", "SuccessfullMessageForUploadUsers",
               base.IsTakeScreenShotDuringEntryExit);
            //Verify the Successfull Message
            Logger.LogAssertion("VerifySuccessfullMessageAfterBulkRegistration",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(successMessage,
                    new ManageUserPage().GetSuccessfullMessageAfterBulkRegistration()));
            Logger.LogMethodExit("CreateUser", "SuccessfullMessageForUploadUsers",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks On The User Cmenu Link.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I click on the cmenu link for ""(.*)""")]
        public void ClickOnTheUserCmenuLink(User.UserTypeEnum userTypeEnum)
        {
            //Clicks On The User Cmenu Link
            Logger.LogMethodEntry("CreateUser", "ClickOnTheUserCmenuLink",
               base.IsTakeScreenShotDuringEntryExit);
            //Clicks On The User Cmenu Link
            new ManageUsersPage().ClickOnUserCmenuLinkIcon();
            Logger.LogMethodExit("CreateUser", "ClickOnTheUserCmenuLink",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Display of the User CMenu Options.
        /// </summary>
        [Then(@"I should see 'User Information', 'Edit', 'Delete' and 'Deny Access' in CMenu Options")]
        public void DisplayOfUserCMenuOptions()
        {
            //Verify the Display of User CMenu Options
            Logger.LogMethodEntry("CreateUser", "DisplayOfUserCMenuOptions",
               base.IsTakeScreenShotDuringEntryExit);
            //Verify the Display of User CMenu Options
            Logger.LogAssertion("VerifyDisplayOfUserCMenuOptions",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(
                   CreateUserResource.CreateUserPage_ContextMenuOptions_Value,
                    new ManageUsersPage().GetCMenuOptionsOfUser()));
            Logger.LogMethodExit("CreateUser", "DisplayOfUserCMenuOptions",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Option of User.
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option</param>
        [When(@"I select the Cmenu option ""(.*)""")]
        public void SelectTheCmenuOptionofUser(
            ManageUsersPage.UserCmenuOption cmenuOption)
        {
            //Selec the Cmenu Option of User
            Logger.LogMethodEntry("CreateUser", "SelectTheCmenuOptionofUser",
              base.IsTakeScreenShotDuringEntryExit);
            //Select Cmenu Option
            new ManageUsersPage().SelectCmenuOption(cmenuOption);
            Logger.LogMethodExit("CreateUser", "SelectTheCmenuOptionofUser",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Information of User.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        [Then(@"I should be able to view the information of the ""(.*)""")]
        public void VerifyTheInformationOfUser(
            User.UserTypeEnum userTypeEnum)
        {
            //Verify the Information of the User
            Logger.LogMethodEntry("CreateUser", "VerifyTheInformationOfUser",
              base.IsTakeScreenShotDuringEntryExit);
            //Get the User From Memory
            User user = User.Get(userTypeEnum);
            //Verify the Display of User Information            
            Logger.LogAssertion("VerifyDisplayOfUserInformation",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(
                CreateUserResource.CreateUserPage_UserInformation_Options_Value,
                new UserInformationPage().GetUserInformationDetails()));
            //Verify the UserName
            Logger.LogAssertion("VerifyUserName",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(
                    user.Name,
                    new UserInformationPage().GetUserName()));
            Logger.LogMethodExit("CreateUser", "VerifyTheInformationOfUser",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the User Created In Administrators Tab.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I search the created ""(.*)"" in  administrators tab")]
        public void SearchTheCreatedUserInAdministratorsTab(
            User.UserTypeEnum userTypeEnum)
        {
            //Search the User Created In Administrators Tab
            Logger.LogMethodEntry("CreateUser", "SearchTheCreatedUserInAdministratorsTab",
            base.IsTakeScreenShotDuringEntryExit);
            //Get the User From Memory
            User user = User.Get(userTypeEnum);
            //Search the User Created In Administrators Tab
            new AdminToolPage().SearchUserInAdministratorsPage(user.Name);
            Logger.LogMethodExit("CreateUser", "SearchTheCreatedUserInAdministratorsTab",
           base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify the User In Administrators Tab.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see the ""(.*)"" in administrators tab")]
        public void VerifyTheUserInAdministratorsTab(
            User.UserTypeEnum userTypeEnum)
        {
            //Checks the display of correct User
            Logger.LogMethodEntry("CreateUser", "VerifyTheUserInAdministratorsTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the User From Memory
            User user = User.Get(userTypeEnum);
            //Verify Username
            Logger.LogAssertion("VerifyUserName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.Name
                    , new ManageUsersPage().GetSearchedUserName()));
            Logger.LogMethodExit("CreateUser", "VerifyTheUserInAdministratorsTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Cmenu option of Workspace promoted admin.
        /// </summary>
        /// <param name="userTypeEnum">This is the User type enum for promoted admin.</param>
        [When(@"I click on the cmenu option of ""(.*)""")]
        public void ClickCmenuOfPromotedAdmin(
            User.UserTypeEnum userTypeEnum)
        {
            //Checks the display unroll option in Cmenu
            Logger.LogMethodEntry("CreateUser", "ClickCmenuOfPromotedAdmin",
                base.IsTakeScreenShotDuringEntryExit);
            //Get User Name from Memory
            User user = User.Get(userTypeEnum);
            // Calling instance of Admin Enrollment Class
            AdminEnrollment adminEnrollment = new AdminEnrollment();
            adminEnrollment.FindPromotedAdminInFrame();
            // Click Cmenu image
            adminEnrollment.ClickCmenuImage(user.LastName);
            Logger.LogMethodExit("CreateUser", "ClickCmenuOfPromotedAdmin",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Cmenu option "Unenroll" is displayed.
        /// </summary>
        /// <param name="getOptionName">This is the option name.</param>
        [Then(@"I should successfully see the cmenu option ""(.*)""")]
        public void VerifyCMenuOptionForPromotedAdmin(
            String getOptionName)
        {
            //Verify Cmenu option "Unenroll" for admin
            Logger.LogMethodEntry("CreateUser", "VerifyCmenuOptionForPromotedAdmin",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify Unenroll Cmenu option
            Logger.LogAssertion("VerifyCmenuOption", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(getOptionName, new AdminEnrollment()
                    .GetCmenuOptionForWorkspaceAdmin()
                    ));
            Logger.LogMethodExit("CreateUser", "VerifyCmenuOptionForPromotedAdmin",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Class Cmenu Option.
        /// </summary>
        /// <param name="cMenuOptionName">This is Class CMenu Option Name.</param>
        /// <param name="classTypeEnum">This is Class Type Enum.</param>
        [When(@"I select the ""(.*)"" from ""(.*)"" cmenu options")]
        public void SelectTheClassCmenuOption(
            String cMenuOptionName,
            Class.ClassTypeEnum classTypeEnum)
        {
            //Select The Class Cmenu Option
            Logger.LogMethodEntry("CreateUser", "SelectTheClassCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the Class Name from Memory
            Class className = Class.Get(classTypeEnum);
            ManageClassManagementPage manageClassManagement =
                new ManageClassManagementPage();
            //Search the Class            
            manageClassManagement.ClassSearchInCoursespace(className.Name);
            //Click on the cmenu option            
            manageClassManagement.SelectTheCMenuOption(cMenuOptionName);
            Logger.LogMethodExit("CreateUser", "SelectTheClassCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display Of 'Manage Students' Page.
        /// </summary>
        [Then(@"I should be on the 'Manage Students' page")]
        public void VerifyDisplayOfManageStudentsPage()
        {
            //Verify Display Of 'Manage Students' Page
            Logger.LogMethodEntry("CreateUser", "DisplayOfManageStudentsPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify Display Of 'Manage Students' Page
            Logger.LogAssertion("VerifyDisplayOfManageStudentsPage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(CreateUserResource.
                    CreateUserPage_ManageStudents_Window_Title,
                    new ManageStudentsDefaultPage().GetManageStudentsPage()));
            Logger.LogMethodExit("CreateUser", "DisplayOfManageStudentsPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Delete Older Uploaded Files In 'Manage Students' Page.
        /// </summary>
        [When(@"I delete the Older uploaded files")]
        public void DeleteOlderUploadedFilesInManageStudentsPage()
        {
            //Delete Older Uploaded Files In 'Manage Students' Page
            Logger.LogMethodEntry("CreateUser",
                "DeleteOlderUploadedFilesInManageStudentsPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Delete the Older Files
            new ManageStudentsDefaultPage().DeleteTheOlderUploadedFiles();
            Logger.LogMethodExit("CreateUser",
                "DeleteOlderUploadedFilesInManageStudentsPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Option From The 'Create New' Drop Down Options.
        /// </summary>
        /// <param name="dropDownOption">This is Create New Drop Down Option to be selected.</param>
        [When(@"I select the ""(.*)"" option from the 'Create New' drop down option")]
        public void SelectOptionFromTheCreateNewDropDownOptions(
            String dropDownOption)
        {
            //Select the Option From The 'Create New' Drop Down Options
            Logger.LogMethodEntry("CreateUser",
                "SelectOptionFromTheCreateNewDropDownOptions",
                base.IsTakeScreenShotDuringEntryExit);
            //Select the Option From The 'Create New' Drop Down Options
            new ManageStudentsDefaultPage().
                SelectTheOptionFromCreateNewDropDown(dropDownOption);
            Logger.LogMethodExit("CreateUser",
                "SelectOptionFromTheCreateNewDropDownOptions",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Import A Bulk Users File.
        /// </summary>
        [When(@"I Import a bulk users file")]
        public void ImportABulkUsersFile()
        {
            //Import A Bulk Users File
            Logger.LogMethodEntry("CreateUser", "ImportABulkUsersFile",
                base.IsTakeScreenShotDuringEntryExit);
            //Import the Users File
            new ManageStudentsDefaultPage().ImportUsers();
            Logger.LogMethodExit("CreateUser", "ImportABulkUsersFile",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display of Successfull Message For Bulk Registration In 'Manage Students' Window.
        /// </summary>
        /// <param name="successfullMessage">This is Successfull Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in 'Manage Students' window")]
        public void DisplaySuccessfullMessageForBulkRegistrationInManageStudentsWindow(
            String successfullMessage)
        {
            //Display of Successfull Message For Bulk Registration In 'Manage Students' Window
            Logger.LogMethodEntry("CreateUser",
                "DisplaySuccessfullMessageForBulkRegistrationInManageStudentsWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify of Successfull Message For Bulk Registration In 'Manage Students' Window            
            Logger.LogAssertion("VerifySuccessfullMessageAfterBulkRegistration",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(successfullMessage,
                    new ManageStudentsDefaultPage().GetSuccessfullMessageAfterBulkRegistration()));
            Logger.LogMethodExit("CreateUser",
                "DisplaySuccessfullMessageForBulkRegistrationInManageStudentsWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter In To Organization Level In Admin HomePage.
        /// </summary>
        [When(@"I enter in to the 'Organization level' in Admin Home page")]
        public void EnterInToOrganizationLevelInAdminHomePage()
        {
            //Enter In To Organization Level In Admin HomePage
            Logger.LogMethodEntry("CreateUser", "EnterInToOrganizationLevelInAdminHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            //Enter In To Organization Level In Admin HomePage
            new AdminHomePage().EnterInToOrganizationLevelInAdminHomePage();
            Logger.LogMethodExit("CreateUser", "EnterInToOrganizationLevelInAdminHomePage",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select The Option In Manage Student Page.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <param name="tabName">This is tab name.</param>
        [When(@"I select the ""(.*)"" option from ""(.*)"" subtab in Manage Student Page")]
        public void SelectTheOptionInManageStudentPage(
            User.UserTypeEnum userTypeEnum, String tabName)
        {
            //Select the User Option
            Logger.LogMethodEntry("CreateUser", "SelectTheOptionInManageStudentPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Add/Create Users link
            new ManageUserPage().ClickOnAddCreateUsersLink((ManageUserPage.CreateUserTab)Enum.
                Parse(typeof(ManageUserPage.CreateUserTab), tabName));
            //Select the userType in Manage Student page
            new ManageUserPage().SelectUserTypeInManageStudentPage(userTypeEnum);
            Logger.LogMethodExit("CreateUser", "SelectTheOptionInManageStudentPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Successfull Message In Manage Students Page.
        /// </summary>
        /// <param name="successMessage">This is Success Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in Manage Students page")]
        public void VerifyTheSuccessfullMessageInManageStudentsPage(
            String successMessage)
        {
            //Verify The Successfull Message In Manage Students Page
            Logger.LogMethodEntry("CreateUser", "VerifyTheSuccessfullMessageInManageStudentsPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Display of Success Message            
            Logger.LogAssertion("VerifySuccessfullMessage",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(successMessage, new GBRosterGridUXPage().GetSuccessMessage()));
            Logger.LogMethodExit("CreateUser", "VerifyTheSuccessfullMessageInManageStudentsPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The User Cmenu Option In Manage User Frame.
        /// </summary>
        [When(@"I click the user cmenu option in manage user frame")]
        public void ClickTheUserCmenuOptionInManageUserFrame()
        {
            //Click The User Cmenu Option In Manage User Frame
            Logger.LogMethodEntry("CreateUser", "ClickTheUserCmenuOptionInManageUserFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Delete The Created User In Manage User Frame
            new ManageUsersPage().DeleteTheCreatedUserInManageUserFrame();
            Logger.LogMethodExit("CreateUser", "ClickTheUserCmenuOptionInManageUserFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Update user details
        /// </summary>
        /// <param name="p0"></param>
        [When(@"I update details of ""(.*)"" user")]
        public void UpdateDetailsOfUser(User.UserTypeEnum userTypeEnum)
        {
            //Create User in Coursespace
            Logger.LogMethodEntry("CreateUser", "UpdateDetailsOfUser",
                base.IsTakeScreenShotDuringEntryExit);
            //Create Cs User
            new UpdateUserPage().UpdateUser(userTypeEnum);
            Logger.LogMethodExit("CreateUser", "UpdateDetailsOfUser",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Teacher upload the student bulk upload file
        /// </summary>
        /// <param name="fileName">This is the file name.</param>
        [When(@"I upload the file BulkUser_Template")]
        public void UploadBulkStudentFile()
        {
            // Bulk Upload document
            Logger.LogMethodEntry("CreateUser",
                "UploadBulkStudentFile",
                base.IsTakeScreenShotDuringEntryExit);
            new ManageStudentsDefaultPage().ImportUsers();
            Logger.LogMethodExit("CreateUser", "UploadBulkStudentFile",
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
