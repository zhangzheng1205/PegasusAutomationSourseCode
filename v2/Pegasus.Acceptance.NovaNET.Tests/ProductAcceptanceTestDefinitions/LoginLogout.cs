using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.NovaNET.Tests.Definitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
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
        /// The instance for Login Page.
        /// </summary>
        BrowsePegasusUserURL loginPage;

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = 
            Logger.GetInstance(typeof(LoginLogout));

        /// <summary>
        /// Opens the Login Url of the User of given Type
        /// Asserts on the said Url is opened.
        /// </summary>
        /// <param name="userType">This is User Type.</param>
        [Given(@"I browsed the login url for ""(.*)""")]
        public void BrowsePegasusLoginUrl(String userType)
        {
            //Browse Login Url
            logger.LogMethodEntry("LoginLogout", "BrowsePegasusLoginUrl",
                base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("LoginLogout", "BrowsePegasusLoginUrl",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Login with the User of Given Type.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="loginMode">This is User Login Mode.</param>
        [When(@"I login to Pegasus as ""(.*)"" in ""(.*)""")]
        public void LoginToThePegasus(User.UserTypeEnum userTypeEnum,
            BrowsePegasusUserURL.PegasusLoginSpace loginMode)
        {
            //Login in Pegasus
            logger.LogMethodEntry("LoginLogout", "LoginToThePegasus",
                base.isTakeScreenShotDuringEntryExit);
            Boolean isUserAlreadyLoggedIn = base.IsElementPresent
                (By.PartialLinkText(LoginLogoutResource.
                LoginLogout_Signout_Link_Title_Locator),
                Convert.ToInt32(LoginLogoutResource.
                LoginLogout_Custom_TimeToWait_Element)) || base.IsElementPresent
               (By.ClassName(LoginLogoutResource.LoginLogout_NNUser_LN_FN_Class_Locator),
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
            logger.LogMethodExit("LoginLogout", "LoginToThePegasus",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Check If User Is Logged In Successfully.
        /// </summary>
        [Then(@"I should be logged in successfully")]
        public void LoggedInSuccessfully()
        {
            //To Check Login Success
            logger.LogMethodEntry("LoginLogout", "LoggedInSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
            //Assert User Has Logged In Successfully
            logger.LogAssertion("VerifyLoginSuccess",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreNotEqual(LoginLogoutResource.
                    LoginLogout_Window_Name_Title, new BrowsePegasusUserURL
                        (User.UserTypeEnum.HedWsAdmin).GetPageTitle()));
            logger.LogMethodExit("LoginLogout", "LoggedInSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the logout link.
        /// </summary>
        /// <param name="linkSignOut">This is SignOut Link Name.</param>
        /// <param name="userTypeEnum">This is user by type enum. </param>
        [When(@"I ""(.*)"" from the ""(.*)""")]
        public void SignOutFromThePegasus(String linkSignOut, 
            User.UserTypeEnum userTypeEnum)
        {
            //Method to Clicks on SignOut link
            logger.LogMethodEntry("LoginLogout", "SignOutFromThePegasus",
                base.isTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                //Select Pegasus User by Type                
                case User.UserTypeEnum.WsTeacher:
                case User.UserTypeEnum.WsStudent:
                case User.UserTypeEnum.CsAdmin:
                case User.UserTypeEnum.NovaNETWsAdmin:
                    // Click Sign out link 
                    new AdminToolPage().SignOutByPegasusUser(linkSignOut);
                    break;
                case User.UserTypeEnum.NovaNETCsTeacher:
                case User.UserTypeEnum.NovaNETCsStudent:
                    // Click Sign out link 
                    new LogOutPage().SignOutByNovaNetUser(linkSignOut);
                    break;
            }
            logger.LogMethodExit("LoginLogout", "SignOutFromThePegasus",
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
