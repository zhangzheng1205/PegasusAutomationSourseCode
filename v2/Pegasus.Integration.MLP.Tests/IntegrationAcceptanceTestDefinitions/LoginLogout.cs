using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Integration.Hed.MLP.Tests.IntegrationAcceptanceTestDefinitions;

namespace Pegasus.Integration.MLP.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of LoginLogout page 
    /// and handles Pegasus LoginLogout Page Actions.
    /// </summary>
    [Binding]
    public class LoginLogout : PegasusBaseTestFixture
    {
        /// <summary>
        /// The instance for Login Page
        /// </summary>
        BrowsePegasusUserURL loginPage;

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(LoginLogout));

        /// <summary>
        /// Opens the Login Url of the User of given Type
        ///  Asserts on the said Url is opened.
        /// </summary>
        /// <param name="userType">Type of the user.</param>
        /// <seealso cref="User.UserTypeEnum"/>
        [Given("I browsed the login url for \"(.*)\"")]
        [Given("I browsed the login url for \"(.*)\"")]
        public void BrowsePegasusLoginUrl(String userType)
        {
            //Browse Login Url
            Logger.LogMethodEntry("LoginLogout", "BrowsePegasusLoginUrl",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Login with the User of Given Type.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type. </param>
        /// <param name="loginMode">This is User Login Type.</param>
        /// <seealso cref="User.UserTypeEnum"/>
        [When("I logged into the Pegasus as \"(.*)\" in \"(.*)\"")]
        public void LoginIntoThePegasus(User.UserTypeEnum userTypeEnum,
            BrowsePegasusUserURL.PegasusLoginSpace loginMode)
        {
            //Login in Pegasus
            Logger.LogMethodEntry("LoginLogout", "LoginIntoThePegasus",
                base.isTakeScreenShotDuringEntryExit);
            Boolean isUserAlreadyLoggedIn = base.IsElementPresent
                (By.PartialLinkText(LoginLogoutResource.
                LoginLogout_Signout_Link_Title_Locator),
                Convert.ToInt32(LoginLogoutResource.
                LoginLogout_Custom_TimeToWait_Element));
            if (!isUserAlreadyLoggedIn)
            {
                //Get the user of the given type from Memory Data Store
                User user = User.Get(userTypeEnum);
                //Login as according to the Pegasus Login Mode
                try
                {
                    switch (loginMode)
                    {
                        case BrowsePegasusUserURL.PegasusLoginSpace.WorkSpace:
                            //Login as the given user with password in workspace
                            loginPage.Authenticate(user.Name, user.Password,
                                 BrowsePegasusUserURL.PegasusLoginSpace.WorkSpace, userTypeEnum);
                            LoginSpace = BrowsePegasusUserURL.PegasusLoginSpace.WorkSpace.ToString();
                            break;
                        case BrowsePegasusUserURL.PegasusLoginSpace.CourseSpace:
                            //Login as the given user with password in course space
                            loginPage.Authenticate(user.Name, user.Password,
                                BrowsePegasusUserURL.PegasusLoginSpace.CourseSpace, userTypeEnum);
                            LoginSpace = BrowsePegasusUserURL.PegasusLoginSpace.CourseSpace.ToString();
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

            Logger.LogMethodExit("LoginLogout", "LoginIntoThePegasus",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// User Loggedin Successfully.
        /// </summary>
        [Then(@"I should logged in successfully")]
        public void LoggedInSuccessfully()
        {
            //Login Success
            Logger.LogMethodEntry("LoginLogout", "LoggedInSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
            //Assert we have logged in successfully
            Logger.LogAssertion("VerifyLoginSuccess",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreNotEqual(LoginLogoutResource.
                    LoginLogout_Window_Name_Title, new BrowsePegasusUserURL(
                        User.UserTypeEnum.HedWsAdmin).GetPageTitle()));
            Logger.LogMethodExit("LoginLogout", "LoggedInSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the logout link.
        /// </summary>
        /// <param name="linkSignOut">This is SignOut Link</param>
        [Then("I \"(.*)\" from the Pegasus")]
        [When("I \"(.*)\" from the Pegasus")]
        public void SignOutFromThePegasus(String linkSignOut)
        {
            //Method to Clicks on SignOut link
            Logger.LogMethodEntry("LoginLogout", "SignOutFromThePegasus",
                base.isTakeScreenShotDuringEntryExit);
            // Click Sign out link 
            new BrowsePegasusUserURL(User.UserTypeEnum.
                HedWsAdmin).ClickSignOutButton(linkSignOut);
            Logger.LogMethodExit("LoginLogout", "SignOutFromThePegasus",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the logout link .
        /// </summary>
        /// <param name="linkSignOut">This is SignOut Link Name.</param>
        /// <param name="userTypeEnum">This is user by type enum.</param>
        [Then("I \"(.*)\" from the \"(.*)\"")]
        [When("I \"(.*)\" from the \"(.*)\"")]
        public void SignOutByTheUser(String linkSignOut,
            User.UserTypeEnum userTypeEnum)
        {
            //Method to Clicks on SignOut link
            Logger.LogMethodEntry("LoginLogout",
                "SignOutByTheUser",
                base.isTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.HedWsAdmin:
                case User.UserTypeEnum.HedCsAdmin:
                case User.UserTypeEnum.CsSmsInstructor:
                case User.UserTypeEnum.CsSmsStudent:
                case User.UserTypeEnum.HedTeacherAssistant:
                case User.UserTypeEnum.HedProgramAdmin:
                case User.UserTypeEnum.HedWsInstructor:
                    //Click On Sign Out Link 
                    new AdminToolPage().SignOutByHigherEdUsers(linkSignOut);
                    break;
                case User.UserTypeEnum.ECollegeAdmin:
                case User.UserTypeEnum.ECollegeTeacher:
                case User.UserTypeEnum.ECollegeStudent:
                    //Click On Sign Out Link
                    new HomePSHPage().SignOutByECollegeUsers(linkSignOut);
                    break;
            }
            Logger.LogMethodExit("LoginLogout", "SignOutByTheUser",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Opens the ECollege Login Url of the User of given Type
        ///  Asserts on the said Url is opened.
        /// </summary>
        /// <param name="userType">Type of the user</param>
        /// <seealso cref="User.UserTypeEnum"/>
        [Given(@"I browsed the ECollege URL as ""(.*)""")]
        public void BrowsedECollegeLoginURL(String userType)
        {
            //Browse Login Url
            Logger.LogMethodEntry("LoginLogout", "BrowsedECollegeLoginURL",
                base.isTakeScreenShotDuringEntryExit);
            //Login  the type of the user
            Boolean isUserAlreadyLoggedIn = base.IsElementPresent(By.PartialLinkText
                (LoginLogoutResource.LoginLogout_ECollege_Signoff_PartialTxt_Locator),
               Convert.ToInt32(LoginLogoutResource.
               LoginLogout_Custom_TimeToWait_Element));
            //Check User Already Logged In
            if (!isUserAlreadyLoggedIn)
            {
                // Pick Url based on user type enum
                loginPage = new BrowsePegasusUserURL((User.UserTypeEnum)
                    Enum.Parse(typeof(User.UserTypeEnum), userType));
                //Open Url in Browser
                loginPage.GoToLoginUrl();
            }
            Logger.LogMethodExit("LoginLogout", "BrowsedECollegeLoginURL",
                base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Login with the ECollege User of Given Type.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I login to Pearson TPI Cert as ""(.*)""")]
        public void LoginToPearsonTpiCert(User.UserTypeEnum
            userTypeEnum)
        {
            //Login to ECollege
            Logger.LogMethodEntry("LoginLogout", "LoginToPearsonTPICert",
                base.isTakeScreenShotDuringEntryExit);
            new ECollegeLoginPage().ECollegeUserLogin(userTypeEnum);
            Logger.LogMethodExit("LoginLogout", "LoginToPearsonTPICert",
                base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// ECollege User Loggedin Successfully.
        /// </summary>
        [Then(@"I should logged in successfully on ECollege")]
        public void ECollegeUseLoggedInSuccessfully()
        {
            //Login Success
            Logger.LogMethodEntry("LoginLogout", "LoggedInSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
            //Assert we have logged in successfully
            Logger.LogAssertion("VerifyLoginSuccess",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreNotEqual(LoginLogoutResource.
                    LoginLogout_ECollege_Window_Title, loginPage.GetPageTitle()));
            Logger.LogMethodExit("LoginLogout", "LoggedInSuccessfully",
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
