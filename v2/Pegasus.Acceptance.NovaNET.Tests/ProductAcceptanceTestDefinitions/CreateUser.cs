using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
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
        private static Logger Logger = 
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
                base.isTakeScreenShotDuringEntryExit);
            //Create New User 
            new NewUserPage().CreateNewUserInWorkSpace(userTypeEnum);
            Logger.LogMethodExit("CreateUser", "CreateNewUser",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Get User Name from Memory
            User user = User.Get(userTypeEnum);
            // Search User in the Manage Users frame
            new AdminToolPage().UserSearch(user.Name);
            Logger.LogMethodExit("CreateUser", "SearchWsUser",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checks if Correct User is displayed.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type Enum.</param>
        [Then(@"I should see the ""(.*)"" in Manage Users frame")]
        public void ShowUserInManageUsersFrame(User.UserTypeEnum 
            userTypeEnum)
        {
            //Checks the display of correct User
            Logger.LogMethodEntry("CreateUser", "ShowUserInManageUsersFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Get User From Memory
            User user = User.Get(userTypeEnum);
            //Verify Username
            Logger.LogAssertion("VerifyUserName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.Name, new ManageUsersPage().GetSearchedUserName()));
            Logger.LogMethodExit("CreateUser", "ShowUserInManageUsersFrame",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Navigates to the sub tab
            new ManageUserPage().NavigateToSubTab((ManageUserPage.CreateUserTab)Enum.
                Parse(typeof(ManageUserPage.CreateUserTab), tabName));
            Logger.LogMethodExit("CreateUser", "NavigateToSubTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects the User Option.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="tabName">This is Tab Name.</param>
        [When(@"I select the ""(.*)"" option from ""(.*)"" subtab")]
        public void SelectUserOption(
            User.UserTypeEnum userTypeEnum, String tabName)
        {
            //Select the User Option
            Logger.LogMethodEntry("CreateUser", "SelectUserOption",
                base.isTakeScreenShotDuringEntryExit);
            //Click on the Add/Create Users link
            new ManageUserPage().ClickOnAddCreateUsersLink((ManageUserPage.CreateUserTab)Enum.
                Parse(typeof(ManageUserPage.CreateUserTab), tabName));
            //Select the userType
            new ManageUserPage().SelectUserType(userTypeEnum);
            Logger.LogMethodExit("CreateUser", "SelectUserOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create User In CourseSpace.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type.</param>
        [When(@"I create a new ""(.*)"" user in Coursespace")]
        public void CreateNewUserInCourseSpace(
            User.UserTypeEnum userTypeEnum)
        {
            //Create User in Coursespace
            Logger.LogMethodEntry("CreateUser", "CreateNewUserInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            //Create Cs User
            new AddUserPage().CreateNewUser(userTypeEnum);
            Logger.LogMethodExit("CreateUser", "CreateNewUserInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create New User In Course Space Global Home Page.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type.</param>
        [When(@"I create a new ""(.*)"" user in Coursespace Global Home")]
        public void CreateNewUserInCourseSpaceGlobalHomePage(
            User.UserTypeEnum userTypeEnum)
        {
            //Create New User In Course Space Global Home Page
            Logger.LogMethodEntry("CreateUser",
                "CreateNewUserInCourseSpaceGlobalHomePage",
                base.isTakeScreenShotDuringEntryExit);
            //Create Cs User
            new AddUserPage().CreateNewUserInGlobalHome(userTypeEnum);
            Logger.LogMethodExit("CreateUser", 
                "CreateNewUserInCourseSpaceGlobalHomePage",
                base.isTakeScreenShotDuringEntryExit);
        }       

        /// <summary>
        /// Search the User in Coursespace.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="tabName">This is Tab Name.</param>
        [When(@"I search the created ""(.*)"" in ""(.*)"" subtab")]
        public void SearchUserInCourseSpace(
            User.UserTypeEnum userTypeEnum, 
            String tabName)
        {
            //Search the User
            Logger.LogMethodEntry("CreateUser", "SearchUserInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            //Search User
            new ManageUserPage().SearchUserInCourseSpace(userTypeEnum,
                (ManageUserPage.CreateUserTab)Enum.
                Parse(typeof(ManageUserPage.CreateUserTab), tabName));
            Logger.LogMethodExit("CreateUser", "SearchUserInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Searched User.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="tabName">This is Tab Name.</param>
        [Then(@"I should see the ""(.*)"" in ""(.*)"" subtab")]
        public void DisplayOfUserInCourseSpace(
            User.UserTypeEnum 
            userTypeEnum, String tabName)
        {
            //Verify the Searched User
            Logger.LogMethodEntry("CreateUser", "DisplayOfUserInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            //Get the User From Memory
            User user = User.Get(userTypeEnum);
            //Verify the Searched User
            Logger.LogAssertion("VerifyUserName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.Name, new ManageUserPage().
                    GetSearchedUserInCourseSpace
                    ((ManageUserPage.CreateUserTab)Enum.
                    Parse(typeof(ManageUserPage.CreateUserTab), tabName))));
            Logger.LogMethodExit("CreateUser", "DisplayOfUserInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects the Bulk User Option and Uploads the Bulk User File.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>
        [When(@"I select the Bulk user upload option and Import a bulk users file in ""(.*)"" subtab")]
        public void BulkUserUploadInCourseSpace(
            String tabName)
        {
            //Bulk User Upload in Users Tab
            Logger.LogMethodEntry("CreateUser", "BulkUserUploadInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            //Delete the Older Uploaded Files
            new BulkUploadQueuePage().DeleteOlderUploadedFiles();
            //Click on the Add Users link
            new ManageUserPage().ClickOnAddCreateUsersLink((ManageUserPage.CreateUserTab)Enum.
                Parse(typeof(ManageUserPage.CreateUserTab), tabName));
            //Upload the Users 
            new ManageUserPage().BulkUserUpload();
            Logger.LogMethodExit("CreateUser", "BulkUserUploadInCourseSpace",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Successfull Message For Upload Users.
        /// </summary>
        /// <param name="successMessage">This is the Successful Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in Users subtab")]
        public void SuccessfullMessageForUploadUsers(
            String successMessage)
        {
            //Verify Successfull Message For Upload Users
            Logger.LogMethodEntry("CreateUser", "SuccessfullMessageForUploadUsers",
               base.isTakeScreenShotDuringEntryExit);
            //Verify the Successfull Message
            Logger.LogAssertion("VerifySuccessfullMessageAfterBulkRegistration",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(successMessage,
                    new ManageUserPage().GetSuccessfullMessageAfterBulkRegistration()));
            Logger.LogMethodExit("CreateUser", "SuccessfullMessageForUploadUsers",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create NewUser In CourseSpace Admin.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I create new ""(.*)"" user in CourseSpace admin")]
        public void CreateNewUserInCourseSpaceAdmin(User.UserTypeEnum userTypeEnum)
        {
            // Create NewUser In CourseSpace Admin
            Logger.LogMethodEntry("CreateUser",
                "CreateNewUserInCourseSpaceAdmin",
                base.isTakeScreenShotDuringEntryExit);
            //Create Cs User
            new AddUserPage().CreateNewUserInCourseSpaceAdmin(userTypeEnum);
            Logger.LogMethodExit("CreateUser",
                "CreateNewUserInCourseSpaceAdmin",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The User Cmenu Option In Manage User Frame.
        /// </summary>
        [When(@"I click the user cmenu option in manage user frame")]
        public void ClickTheUserCmenuOptionInManageUserFrame()
        {
            //Click The User Cmenu Option In Manage User Frame
            Logger.LogMethodEntry("CreateUser", "ClickTheUserCmenuOptionInManageUserFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Delete The Created User In Manage User Frame
            new ManageUsersPage().DeleteTheCreatedUserInManageUserFrame();
            Logger.LogMethodExit("CreateUser", "ClickTheUserCmenuOptionInManageUserFrame",
                base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
            //Select Cmenu Option
            new ManageUsersPage().SelectCmenuOption(cmenuOption);
            Logger.LogMethodExit("CreateUser", "SelectTheCmenuOptionofUser",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'OK' Option.
        /// </summary>
        [When(@"I select 'OK' option")]
        public void ClickOnOkOption()
        {
            //Select Ok Option
            Logger.LogMethodEntry("CreateUser", "ClickOnOkOption",
              base.isTakeScreenShotDuringEntryExit);
            //Click on Ok Button
            new ShowMessagePage().ClickOnPegasusAlertOkButton();
            Logger.LogMethodExit("CreateUser", "ClickOnOkOption",
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
