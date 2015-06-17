#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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
    /// This class contains the details of LoginLogout page 
    /// and handles Pegasus LoginLogout Page Actions.
    /// </summary>
    [Binding]
    public class LoginLogout : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(LoginLogout));

        /// <summary>
        /// The instance for Login Page.
        /// </summary>
        BrowsePegasusUserURL loginPage;

        /// <summary>
        /// Opens the Login Url of the User of given Type
        /// Asserts on the said Url is opened.
        /// </summary>
        /// <param name="userType">This is User Type.</param>
        [Given(@"I browsed the login url for ""(.*)""")]
		[When(@"I browse the login url for ""(.*)""")]
        public void BrowsePegasusLoginUrl(string userType)
        {
            //Browse Login Url
            Logger.LogMethodEntry("LoginLogout", "BrowsePegasusLoginUrl",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Default Window
            base.SelectDefaultWindow();
            // Pick Url based on user type enum
            loginPage = new BrowsePegasusUserURL((User.UserTypeEnum)
                Enum.Parse(typeof(User.UserTypeEnum), userType));
            //Login  the type of the user
            Boolean isBasePegasusUrlBrowsedSuccessful =
                loginPage.IsUrlBrowsedSuccessful();
            //Check Is Url Browsed Successfully
            if (isBasePegasusUrlBrowsedSuccessful)
            {
                //Open Url in Browser
                loginPage.GoToLoginUrl();
            }
            Logger.LogMethodExit("LoginLogout", "BrowsePegasusLoginUrl",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Login with the User of Given Type.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type.</param>
        /// <param name="loginMode">This is User Login Mode.</param>
        [When(@"I login to Pegasus as ""(.*)"" in ""(.*)""")]
        public void LoginToThePegasus(User.UserTypeEnum userTypeEnum,
            BrowsePegasusUserURL.PegasusLoginSpace loginMode)
        {
            //Login in Pegasus
            Logger.LogMethodEntry("LoginLogout", "LoginToThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
            Boolean isUserAlreadyLoggedIn = base.IsElementPresent
                (By.PartialLinkText(LoginLogoutResource.
                LoginLogout_Signout_Link_Title_Locator),
                Convert.ToInt32(LoginLogoutResource.
                LoginLogout_Custom_TimeToWait_Element)) || base.IsElementPresent
               (By.ClassName(LoginLogoutResource.LoginLogout_DPUser_LN_FN_Class_Locator),
               Convert.ToInt32(LoginLogoutResource.LoginLogout_Custom_TimeToWait_Element));
            if (!isUserAlreadyLoggedIn)
            {
                try
                {
                    //Get the user of the given type from Memory Data Store
                    User user = User.Get(userTypeEnum);
                    //Login According To The Pegasus Login Mode
                    switch (loginMode)
                    {
                        case BrowsePegasusUserURL.PegasusLoginSpace.WorkSpace:
                            //Login as the given user with password in workspace
                            loginPage.Authenticate(user.Name, user.Password,
                                BrowsePegasusUserURL.PegasusLoginSpace.WorkSpace, userTypeEnum);
                            break;
                        case BrowsePegasusUserURL.PegasusLoginSpace.CourseSpace:
                            //Login as the given user with password in course space
                            loginPage.Authenticate(user.Name, user.Password,
                                BrowsePegasusUserURL.PegasusLoginSpace.CourseSpace, userTypeEnum);
                            break;
                    }
                    UserName = user.Name;
                    Password = user.Password;
                    UserType = userTypeEnum.ToString();
                }
                catch (Exception)
                {
                    LoginSpace = "";
                    UserName = "";
                    UserType = "";
                    Password = "";
                    throw;
                }
            }
            Logger.LogMethodExit("LoginLogout", "LoginToThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Check If User Is Logged In Successfully.
        /// </summary>
        [Given(@"I am Logged in to Pegasus")]
        [Then(@"I should be logged in successfully")]
        public void LoggedInSuccessfully()
        {
            //To Check Login Success
            Logger.LogMethodEntry("LoginLogout", "LoggedInSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert User Has Logged In Successfully
            Logger.LogAssertion("VerifyLoginSuccess",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreNotEqual(LoginLogoutResource.
                    LoginLogout_Window_Name_Title, loginPage.GetPageTitle()));
            Logger.LogMethodExit("LoginLogout", "LoggedInSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the logout link .
        /// </summary>
        /// <param name="linkSignOut">This is SignOut Link Name.</param>
        /// <param name="userTypeEnum">This is user by type. </param>
        [When(@"I ""(.*)"" from the ""(.*)""")]
        public void SignOutFromThePegasus(
            String linkSignOut, User.UserTypeEnum userTypeEnum)
        {
            //Method to Clicks on SignOut link
            Logger.LogMethodEntry("LoginLogout", "SignOutFromThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
            //Created Class Object
            HomePage homePage = new HomePage();
            switch (userTypeEnum)
            {
                //Select Pegasus User by Type
                case User.UserTypeEnum.WsAdmin:
                case User.UserTypeEnum.WsTeacher:
                case User.UserTypeEnum.WsStudent:
                case User.UserTypeEnum.CsAdmin:
                case User.UserTypeEnum.DPCTGPPublisherAdmin:
                case User.UserTypeEnum.DPCsOrganizationAdmin:
                case User.UserTypeEnum.DPCourseSpacePramotedAdmin:
                    // Click Sign out link 
                    new AdminToolPage().SignOutByPegasusUser(linkSignOut);
                    break;
                case User.UserTypeEnum.DPCsTeacher:
                case User.UserTypeEnum.DPCsNewTeacher:
                case User.UserTypeEnum.DPDemoUser:
                    //Click on Sign Out Link
                    homePage.SignoutByDigitalPathCSTeacher(linkSignOut);
                    break;
                case User.UserTypeEnum.DPCsStudent:
                case User.UserTypeEnum.DPCsNewStudent:
                    // Click on sign out link
                    homePage.SignOutByDigitalPathCSStudent(linkSignOut);
                    break;
            }
            Logger.LogMethodExit("LoginLogout", "SignOutFromThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the SignOut link.
        /// </summary>
        [When(@"I 'Sign out' from the Pegasus as Dp User")]
        public void SignoutFromThePegasusAsDpUser()
        {
            //Method to Clicks on SignOut link
            Logger.LogMethodEntry("LoginLogout", "SignoutFromThePegasusAsDpUser",
                base.IsTakeScreenShotDuringEntryExit);
            // Click Sign out link 
            new HomePage().DigitalPathCsUserLogout();
            Logger.LogMethodExit("LoginLogout", "SignoutFromThePegasusAsDpUser",
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
