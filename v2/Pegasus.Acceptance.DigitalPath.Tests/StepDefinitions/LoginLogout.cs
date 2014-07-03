#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Integration.Rumba;
using TechTalk.SpecFlow;
using System.Collections.Generic;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.Definitions
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
        private static readonly Logger logger =
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
        public void BrowsePegasusLoginUrl(string userType)
        {
            //Browse Login Url
            logger.LogMethodEntry("LoginLogout", "BrowsePegasusLoginUrl",
                base.isTakeScreenShotDuringEntryExit);
            //Select Default Window
            base.SelectDefaultWindow();
            //Login  the type of the user
            Boolean isUserAlreadyLoggedIn = base.IsElementPresent(By.PartialLinkText
                (LoginLogoutResource.LoginLogout_Signout_Link_Title_Locator),
               Convert.ToInt32(LoginLogoutResource.
               LoginLogout_Custom_TimeToWait_Element)) || base.IsElementPresent
               (By.ClassName(LoginLogoutResource.LoginLogout_DPUser_LN_FN_Class_Locator),
                Convert.ToInt32(LoginLogoutResource.LoginLogout_Custom_TimeToWait_Element));
            //Check User Already Logged In
            if (!isUserAlreadyLoggedIn)
            {
                loginPage = new BrowsePegasusUserURL((User.UserTypeEnum)
                    Enum.Parse(typeof(User.UserTypeEnum), userType));
                //Open Url in Browser
                loginPage.GoToLoginUrl();
            }
            logger.LogMethodExit("LoginLogout", "BrowsePegasusLoginUrl",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Login with the User of Given Type.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type.</param>
        /// <param name="loginMode">This is User Login Mode.</param>
        [Then(@"I login to Pegasus as ""(.*)"" in ""(.*)""")]
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
               (By.ClassName(LoginLogoutResource.LoginLogout_DPUser_LN_FN_Class_Locator),
               Convert.ToInt32(LoginLogoutResource.LoginLogout_Custom_TimeToWait_Element));
            if (!isUserAlreadyLoggedIn)
            {
                //Get the user of the given type from Memory Data Store
                User user = User.Get(userTypeEnum);
                try
                {
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
        [Given(@"I am Logged in to Pegasus")]
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
                    LoginLogout_Window_Name_Title, loginPage.GetPageTitle()));
            logger.LogMethodExit("LoginLogout", "LoggedInSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the logout link .
        /// </summary>
        /// <param name="linkSignOut">This is SignOut Link Name.</param>
        /// <param name="userTypeEnum">This is user by type .</param>
        [When(@"I ""(.*)"" from the ""(.*)""")]
        public void SignOutFromThePegasus
            (String linkSignOut, User.UserTypeEnum userTypeEnum)
        {
            //Method to Clicks on SignOut link
            logger.LogMethodEntry("LoginLogout", "SignOutFromThePegasus",
                base.isTakeScreenShotDuringEntryExit);
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
                case User.UserTypeEnum.RumbaTeacher:
                    //Click on Sign Out Link
                    homePage.SignoutByDigitalPathCSTeacher(linkSignOut);
                    break;
                case User.UserTypeEnum.DPCsStudent:
                case User.UserTypeEnum.RumbaStudent:
                    // Click on sign out link
                    homePage.SignOutByDigitalPathCSStudent(linkSignOut);
                    break;
            }
            logger.LogMethodExit("LoginLogout", "SignOutFromThePegasus",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the SignOut link.
        /// </summary>
        [When(@"I 'Sign out' from the Pegasus as Dp User")]
        public void SignoutFromThePegasusAsDpUser()
        {
            //Method to Clicks on SignOut link
            logger.LogMethodEntry("LoginLogout", "SignoutFromThePegasusAsDpUser",
                base.isTakeScreenShotDuringEntryExit);
            // Click Sign out link 
            new HomePage().DigitalPathCsUserLogout();
            logger.LogMethodExit("LoginLogout", "SignoutFromThePegasusAsDpUser",
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Method to verify Required Contineo parameters in RUL page URL.
        /// </summary>
        /// <param name="profileKey">parameter that need to verify.</param>
        /// <param name="k12IntKey">parameter that need to verify.</param>
        [Then(@"I should see Contineo parameters ""(.*)"" and ""(.*)"" in the Rumba Universal Login URL")]
        public void VerifyRequiredParametersInRULUrl(String profileKey,String k12IntKey)
        {
            //Log method entry
            logger.LogMethodEntry("LoginLogout", "VerifyRequiredParametersInRULUrl",
                base.isTakeScreenShotDuringEntryExit);
            //Intialized expected object in order to assert
            Dictionary<String, String> expectedObj=new Dictionary<string,string>();
            expectedObj.Add(LoginLogoutResource.Contineo_ProfileKey,
                LoginLogoutResource.Contineo_ProfileValue);
            expectedObj.Add(LoginLogoutResource.Contineo_k12IntKey,
                LoginLogoutResource.Contineo_k12IntValue);
            // Log assert result 
            logger.LogAssertion("VerifyRequiredParametersInRULUrl",
                 ScenarioContext.Current.ScenarioInfo.Title,
                 () => CollectionAssert.AreEqual(expectedObj,
                     new SignInPage().GetRequiredParametersForRUL(profileKey, k12IntKey)));
            // Log method exit
            logger.LogMethodExit("LoginLogout", "VerifyRequiredParametersInRULUrl",
                isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Method to click on Sign In Button on RUL sign out page.
        /// this is a mediator page that shows the log out message
        /// </summary>
        /// <param name="buttonClass">class name to find out element</param>        
        [When(@"I click on the Sign In ""(.*)"" in Rumba Page")]
        public void ClickOnSignInOnRumbaPage(String buttonClass)
        {
            // Log Method entry
            logger.LogMethodEntry("LoginLogout", "ClickOnSignInOnRumbaPage",
                base.isTakeScreenShotDuringEntryExit);
            // Redirect to login page
            new SignInPage().RedirectToRULPage(buttonClass);
           // Log method exit
            logger.LogMethodExit("LoginLogout", "VerifyRequiredParametersInRULUrl",
                isTakeScreenShotDuringEntryExit);
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
