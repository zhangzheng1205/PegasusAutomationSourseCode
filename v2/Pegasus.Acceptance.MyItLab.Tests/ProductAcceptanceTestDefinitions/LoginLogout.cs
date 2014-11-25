using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of LoginLogout page 
    /// and handles Pegasus LoginLogout Page Actions
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
        private static Logger Logger = Logger.GetInstance(typeof(LoginLogout));

        /// <summary>
        /// Opens the Login Url of the User of given Type.
        ///  Asserts on the said Url is opened.
        /// </summary>
        /// <param name="userType">Type of the user.</param>
        /// <seealso cref="User.UserTypeEnum"/>

        [Given("I browsed the login url for \"(.*)\"")]
        public void BrowsePegasusLoginUrl(string userType)
        {
            //Browse Login Url
            Logger.LogMethodEntry("LoginLogout", "BrowsePegasusLoginUrl",
                base.IsTakeScreenShotDuringEntryExit);
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
        /// <param name="userTypeEnum">This is User Type. </param>
        /// <param name="loginMode">This is User Login Type.</param>
        /// <seealso cref="User.UserTypeEnum"/>
        [When("I logged into the Pegasus as \"(.*)\" in \"(.*)\"")]       
        public void LoginIntoThePegasus(User.UserTypeEnum userTypeEnum,
            BrowsePegasusUserURL.PegasusLoginSpace loginMode)
        {
            //Login in Pegasus
            Logger.LogMethodEntry("LoginLogout", "LoginIntoThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
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
                this.CommonLoginIntoThePegasus(userTypeEnum, loginMode, user);
            }
            Logger.LogMethodExit("LoginLogout", "LoginIntoThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Login Into The Pegasus Based On Scenerios.
        /// </summary>
        /// <param name="scenerioName">This is based on scenerio.</param>
        /// <param name="userTypeEnum">This is user type emun.</param>
        /// <param name="loginMode">This is pegasus login mode.</param>
        [When(@"I login as ""(.*)"" into the pegasus as ""(.*)"" in ""(.*)""")]
        public void LoginIntoThePegasusBasedOnScenerios(string scenerioName,
           User.UserTypeEnum userTypeEnum,
            BrowsePegasusUserURL.PegasusLoginSpace loginMode)
        {
            //Login Into The Pegasus Based On Scenerios
            Logger.LogMethodEntry("LoginLogout", "LoginIntoThePegasusBasedOnScenerios",
                base.IsTakeScreenShotDuringEntryExit);
            Boolean isUserAlreadyLoggedIn = base.IsElementPresent
                (By.PartialLinkText(LoginLogoutResource.
                LoginLogout_Signout_Link_Title_Locator),
                Convert.ToInt32(LoginLogoutResource.
                LoginLogout_Custom_TimeToWait_Element));
            if (!isUserAlreadyLoggedIn)
            {
                //Get the user of the given type from Memory Data Store
                User user = new LoginContentPage().
                    SelectUserDetailsBaesdOnScenerio(scenerioName,userTypeEnum);                
                //Login as according to the Pegasus Login Mode
                this.CommonLoginIntoThePegasus(userTypeEnum, loginMode, user);
            }
            Logger.LogMethodExit("LoginLogout", "LoginIntoThePegasusBasedOnScenerios",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Common LoginInto The Pegasus.
        /// </summary>
        /// <param name="userTypeEnum">This is user type emun.</param>
        /// <param name="loginMode">This is pegasus login mode.</param>
        /// <param name="user">This is user.</param>
        public void CommonLoginIntoThePegasus(User.UserTypeEnum userTypeEnum,
            BrowsePegasusUserURL.PegasusLoginSpace loginMode, User user)
        {
            //Common LoginInto The Pegasus
            Logger.LogMethodEntry("LoginLogout", "CommonLoginIntoThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("LoginLogout", "CommonLoginIntoThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
        }  

        /// <summary>
        /// User Loggedin Successfully.
        /// </summary>
        [Then(@"I should logged in successfully")]
        public void LoggedInSuccessfully()
        {
            //Login Success
            Logger.LogMethodEntry("LoginLogout", "LoggedInSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert we have logged in successfully
            Logger.LogAssertion("VerifyLoginSuccess",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreNotEqual(LoginLogoutResource.
                    LoginLogout_Window_Name_Title, new BrowsePegasusUserURL(
                        User.UserTypeEnum.HedWsAdmin).GetPageTitle()));
            Logger.LogMethodExit("LoginLogout", "LoggedInSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on the logout link 
        /// </summary>
        /// <param name="linkSignOut">This is SignOut Link</param>
        [Then("I \"(.*)\" from the Pegasus")]
        [When("I \"(.*)\" from the Pegasus")]
        public void SignOutFromThePegasus(string linkSignOut)
        {
            //Method to Clicks on SignOut link
            Logger.LogMethodEntry("LoginLogout", "SignOutFromThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
            // Click Sign out link 
            new BrowsePegasusUserURL(User.UserTypeEnum.HedWsAdmin).
                ClickSignOutButton(linkSignOut);
            Logger.LogMethodExit("LoginLogout", "SignOutFromThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the logout link 
        /// </summary>
        /// <param name="linkSignOut">This is SignOut Link Name.</param>
        /// <param name="userTypeEnum">This is user by type enum. </param>
        [Then("I \"(.*)\" from the \"(.*)\"")]
        [When("I \"(.*)\" from the \"(.*)\"")]
        public void SignOutFromThePegasus(string linkSignOut, 
            User.UserTypeEnum userTypeEnum)
        {
            //Method to Clicks on SignOut link
            Logger.LogMethodEntry("LoginLogout", "SignOutFromThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.HedWsAdmin:
                case User.UserTypeEnum.HedMiLWsAdmin: 
                case User.UserTypeEnum.HedCsAdmin:
                case User.UserTypeEnum.CsSmsInstructor:
                case User.UserTypeEnum.CsSmsStudent:
                case User.UserTypeEnum.HedTeacherAssistant:
                case User.UserTypeEnum.HedProgramAdmin:
                case User.UserTypeEnum.HedWsInstructor:
                case User.UserTypeEnum.HedMilAcceptanceInstructor:
                case User.UserTypeEnum.HEDWSCTGPublisherAdmin:
                case User.UserTypeEnum.HedMilPPEStudent:
                    // Click Sign out link 
                    new AdminToolPage().SignOutByHigherEdUsers(linkSignOut);
                    break;
            }
            Logger.LogMethodExit("LoginLogout", "SignOutFromThePegasus",
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

