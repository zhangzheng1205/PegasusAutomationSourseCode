using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages.Integration.Blackboard;
using System.Globalization;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Integration.Moodle;

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
                    SelectUserDetailsBaesdOnScenerio(scenerioName, userTypeEnum);
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
                case User.UserTypeEnum.BBInstructor:
                    new BlackboardCourseAction().SignOutByHigherEdUsers(linkSignOut);
                    break;
            }
            Logger.LogMethodExit("LoginLogout", "SignOutFromThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Opens the Login Url of the User of given Type.
        /// </summary>
        /// <param name="userType">This is User Type.</param>
        [When(@"I browsed the URL of ""(.*)""")]
        [Given(@"I browsed the URL of ""(.*)""")]
        public void BrowseBlackBoardCertLoginUrl(string userType)
        {
            //Browse Login Url
            Logger.LogMethodEntry("LoginLogout", "BrowseMMNDCertLoginUrl",
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
            Logger.LogMethodExit("LoginLogout", "BrowseMMNDCertLoginUrl",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Login to the Blackboard Instructor Portal.
        /// </summary>
        [When(@"I login to Blackboard Cert as ""(.*)""")]
        public void LoginToBBCert(User.UserTypeEnum userTypeEnum)
        {
            //Login to Blackboard
            Logger.LogMethodEntry("LoginLogout", "LoginToBBCert",
                base.IsTakeScreenShotDuringEntryExit);
            //Get User details from memory
            User user = User.Get(userTypeEnum);
            switch (userTypeEnum)
            {
                //Login as BBInstructor
                case User.UserTypeEnum.BBInstructor:
                case User.UserTypeEnum.BBStudent:
                    //Login as BB Instructor/Student
                    new BlackboardLoginPage().LoginToBB(user.Name, user.Password);
                    break;
            }
            Logger.LogMethodExit("LoginLogout", "LoginToBBCert",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Blackboard user logout
        /// </summary>
        /// <param name="p0"></param>
        [When(@"I ""(.*)"" of Blackboard as ""(.*)""")]
        public void LogoutOfBlackboardPortal(string linkName, User.UserTypeEnum userType)
        {
            //Login to Blackboard
            Logger.LogMethodEntry("LoginLogout", "LogoutOfBlackboardPortal",
                base.IsTakeScreenShotDuringEntryExit);
            //Get User details from memory
            User user = User.Get(userType);
            switch (userType)
            {
                //Login as BBInstructor
                case User.UserTypeEnum.BBInstructor:
                case User.UserTypeEnum.BBStudent:
                    //Login as BB Instructor/Student
                    new BlackboardCourseAction().SignOutByHigherEdUsers(linkName);
                    break;
            }
            Logger.LogMethodExit("LoginLogout", "LogoutOfBlackboardPortal",
                base.IsTakeScreenShotDuringEntryExit);
        }

        
        public void WhenIOfBlackboardAs(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"I should be logged in successfully as ""(.*)""")]
        public void LoggedInSuccessfully(User.UserTypeEnum userTypeEnum)
        {
            //To Check Login Success
            Logger.LogMethodEntry("LoginLogout", "LoggedInSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
            //Initializing the Variable
            Boolean isUserLoggedIn = false;
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.BBInstructor:
                case User.UserTypeEnum.BBStudent:
                    {
                        //Verify If MMNDInstructor Is Logged In Successfully
                        isUserLoggedIn = new BlackboardLoginPage().IsUserLoggedInSuccessFully();
                    }
                    break;
                case User.UserTypeEnum.MoodleKioskStudent:
                case User.UserTypeEnum.MoodleKioskTeacher:
                    {
                        //Verify If MMNDInstructor Is Logged In Successfully
                        isUserLoggedIn = new MoodleLoginPage().IsUserLoggedInSuccessFullyMoodle();
                    }
                    break;
            }
            //Assert User Has Logged In Successfully.
            Logger.LogAssertion("VerifyLoginSuccess",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(isUserLoggedIn));
            Logger.LogMethodExit("LoginLogout", "LoggedInSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate Blackboard user login.
        /// </summary>
        /// <param name="expectedPageTitle">This is expected page title.</param>
        [Then(@"I should be on ""(.*)"" page")]
        public void ShowThePageInBlackBoard(String expectedPageTitle)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("CommonSteps", "ShowThePageInPegasus",
                IsTakeScreenShotDuringEntryExit);
            //Wait For Page Get Switched
            base.WaitUntilWindowLoads(expectedPageTitle);
            //Get current opened page title
            string actualPageTitle =
                WebDriver.Title.ToString(CultureInfo.InvariantCulture);
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedPageTitle, actualPageTitle));
            Logger.LogMethodExit("CommonSteps", "ShowThePageInPegass",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Moodle user login to Moodle portal
        /// </summary>
        /// <param name="userType">This is the user type enum.</param>
        [When(@"I login to Moodle as ""(.*)""")]
        public void UserLoginToMoodleKioskCertAs(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("LoginLogout", "UserLoginToMoodleKioskCertAs", base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userType);
            switch (userType)
            {
                case User.UserTypeEnum.MoodleKioskStudent:
                case User.UserTypeEnum.MoodleKioskTeacher:
                case User.UserTypeEnum.MoodleDirectTeacher:
                case User.UserTypeEnum.MoodleDirectStudent:
                    new MoodleLoginPage().LoginToCanvas(user.Name, user.Password);
                    break;
            }
            Logger.LogMethodExit("LoginLogout", "UserLoginToMoodleKioskCertAs", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Blackboard user logout of Pegasus
        /// </summary>
        [When(@"I logout of Pegasus")]
        public void LogoutOfPegasus()
        {
            Logger.LogMethodEntry("LoginLogout", "ClickOnBackButton",
                IsTakeScreenShotDuringEntryExit);
            new BlackboardLoginPage().logoutOfPegasus();
            Logger.LogMethodExit("LoginLogout", "ShowThePageInPegass",
                IsTakeScreenShotDuringEntryExit);
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