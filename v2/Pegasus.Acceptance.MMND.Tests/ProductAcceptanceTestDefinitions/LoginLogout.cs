using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MMND.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of LoginLogout page 
    /// and handles MMND LoginLogout Page Actions.
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
        private static Logger Logger = 
            Logger.GetInstance(typeof(LoginLogout));

        /// <summary>
        /// Opens the Login Url of the User of given Type.
        /// </summary>
        /// <param name="userType">This is User Type.</param>
        [Given(@"I browsed the URL of ""(.*)""")]
        public void BrowseMMNDCertLoginUrl(string userType)
        {
            //Browse Login Url
            Logger.LogMethodEntry("LoginLogout", "BrowseMMNDCertLoginUrl",
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
            Logger.LogMethodExit("LoginLogout", "BrowseMMNDCertLoginUrl",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Login to the MMND Portal.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I login to MMND Cert as ""(.*)""")]
        public void LoginToMMND(User.UserTypeEnum userTypeEnum)
        {
            //Login to MMND
            Logger.LogMethodEntry("LoginLogout", "LoginToMMND",
                base.isTakeScreenShotDuringEntryExit);
            //Get User details from memory
            User user = User.Get(userTypeEnum);
            switch (userTypeEnum)
            {
                //Login as MMNDInstructor
                case User.UserTypeEnum.MMNDInstructor:
                case User.UserTypeEnum.MMNDStudent:
                    //Login as MMND Instructor/Student
                    new MyPearsonLoginPage().LoginToMMND(user.Name, user.Password);
                    break;
                //Login as MMNDAdmin
                case User.UserTypeEnum.MMNDAdmin:
                    //Login as MMND admin
                    new LoginContentPage().Login(user.Name, user.Password);
                    break;
            }
            Logger.LogMethodExit("LoginLogout", "LoginToMMND",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Check If User Is Logged In Successfully.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should be logged in successfully as ""(.*)""")]
        public void LoggedInSuccessfully(User.UserTypeEnum userTypeEnum)
        {
            //To Check Login Success
            Logger.LogMethodEntry("LoginLogout", "LoggedInSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
            //Initializing the Variable
            Boolean isUserLoggedIn = false;
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.MMNDInstructor:
                case User.UserTypeEnum.MMNDStudent:
                    {
                        //Verify If MMNDInstructor Is Logged In Successfully
                        isUserLoggedIn = new MyPearsonLoginPage().IsUserLoggedInSuccessFully();
                    }
                    break;
                case User.UserTypeEnum.MMNDAdmin:
                    {
                        //Verify If MMNDAdmin Is Logged In Successfully
                        isUserLoggedIn = new EPContentPage().IsExitButtonDisplayed();
                    }
                    break;
            }
            //Assert User Has Logged In Successfully.
            Logger.LogAssertion("VerifyLoginSuccess",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(isUserLoggedIn));
            Logger.LogMethodExit("LoginLogout", "LoggedInSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Log out from MMND Portal.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I log out from the application as ""(.*)""")]
        [Then(@"I log out from the application as ""(.*)""")]
        public void LogOutFromMMND(User.UserTypeEnum userTypeEnum)
        {
            //Log out of MMND
            Logger.LogMethodEntry("LoginLogout", "LogOutFromMMND",
                base.isTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.MMNDInstructor:
                    //Sign Out From Application
                    new UserLayoutRootNodeTargetPage().LogoutOfMMND();
                    break;
                case User.UserTypeEnum.MMNDStudent:
                    //Sign Out From Application 
                    new UserLayoutRootNodeTargetPage().LogoutAsMMNDStudent();
                    break;
                case User.UserTypeEnum.MMNDAdmin:
                    //Sign Out From Application
                    new EPContentPage().SignOutFromApplication();
                    break;
            }
            Logger.LogMethodExit("LoginLogout", "LogOutFromMMND",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Successfull Message.
        /// </summary>
        /// <param name="message">Successfull Message.</param>
        [Then(@"I should see the message ""(.*)""")]
        public void VerifyTheMessage(string message)
        {
            //Verify SUccessfull Message
            Logger.LogMethodEntry("LoginLogout", "VerifyTheMessage",
               base.isTakeScreenShotDuringEntryExit);
            //Assert Message
            Logger.LogAssertion("VerifyMessage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(message,
                    new IndexPage().GetSuccessfullMessageAfterCourseIntegration()));
            Logger.LogMethodExit("LoginLogout", "VerifyTheMessage",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Opens the Login Url of the User of given Type.
        ///  Asserts on the said Url is opened.
        /// </summary>
        /// <param name="userType">Type of the user.</param>
        /// <seealso cref="User.UserTypeEnum"/>
        [When("I browsed the login url for \"(.*)\"")]
        [Given("I browsed the login url for \"(.*)\"")]
        public void BrowsePegasusLoginUrl(string userType)
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
                    LoginLogout_Window_Name_Title, new BrowsePegasusUserURL(User.UserTypeEnum.HedWsAdmin).GetPageTitle()));
            Logger.LogMethodExit("LoginLogout", "LoggedInSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the logout link.
        /// </summary>
        /// <param name="linkSignOut">This is SignOut Link Name.</param>
        /// <param name="userTypeEnum">This is user by type.</param>
        [Then("I \"(.*)\" from the \"(.*)\"")]
        [When("I \"(.*)\" from the \"(.*)\"")]
        public void SignOutFromThePegasus(String linkSignOut,
            User.UserTypeEnum userTypeEnum)
        {
            //Method to Clicks on SignOut link
            Logger.LogMethodEntry("LoginLogout", "SignOutFromThePegasus",
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
                    // Click Sign out link 
                    new AdminToolPage().SignOutByHigherEdUsers(linkSignOut);
                    break;
            }
            Logger.LogMethodExit("LoginLogout", "SignOutFromThePegasus",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
