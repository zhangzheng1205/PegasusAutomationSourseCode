#region

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Integration.Rumba;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages.Integration.Contineo;

#endregion

namespace Pegasus.Acceptance.Contineo.Tests.
    ContineoAcceptanceTestDefinitions
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
            else
            {

            }
            Logger.LogMethodExit("LoginLogout", "BrowsePegasusLoginUrl",
                base.IsTakeScreenShotDuringEntryExit);
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
            Course newCourse = new Course
            {
                Name = "e49c0491-3017-424d-90e6-55b1292f00dd",
                CourseType = Course.CourseTypeEnum.MasterLibrary,
                IsCreated = true
            };
            newCourse.StoreCourseInMemory();

            Program newprog = new Program
            {
                Name = "353b7263-8f1b-4bdc-9074-fdc2f3bde668",
                ProgramType = Program.ProgramTypeEnum.DigitalPath,
                IsCreated = true
            };
            newprog.StoreProgramInMemory();

            Product newprod = new Product
            {
                Name = "a2f092f3-a886-4864-842b-b0c2a994b3b9",
                ProductType = Product.ProductTypeEnum.DigitalPath,
                IsCreated = true
            };
            newprod.StoreProductInMemory();

            //Organization neworga = new Organization
            //{
            // Name = "7373ae36-17b7-4745-b2a5-7c2153f8df3e",
            // OrganizationLevel = Organization.OrganizationLevelEnum.PowerSchool,
            // OrganizationType=Organization.OrganizationTypeEnum.DigitalPath,
            // IsCreated = true
            //};
            //neworga.StoreOrganizationInMemory();


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
            Logger.LogMethodExit("LoginLogout", "LoginToThePegasus",
                base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I login to PowerSchool as ""(.*)""")]
        public void LoginToPowerSchool(User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("LoginLogout", "LoginToPowerSchool",
                base.IsTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.ContineoTeacher:
                    new PowerTeacherSignInPage().SignInAsPowerSchoolUser(userTypeEnum);
                    break;
                case User.UserTypeEnum.ContineoStudent:
                    new StudentAndParentSignInPage().SignInAsPowerSchoolUser(userTypeEnum);
                    break;
            }
                
            Logger.LogMethodExit("LoginLogout", "LoginToPowerSchool",
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
        /// <param name="userTypeEnum">This is user by type .</param>
        [When(@"I ""(.*)"" from the ""(.*)""")]
        public void SignOutFromThePegasus
            (String linkSignOut, User.UserTypeEnum userTypeEnum)
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
                case User.UserTypeEnum.RumbaTeacher:
                case User.UserTypeEnum.ContineoTeacher:
                    //Click on Sign Out Link
                    homePage.SignoutByDigitalPathCSTeacher(linkSignOut);
                    break;
                case User.UserTypeEnum.DPCsStudent:
                case User.UserTypeEnum.RumbaStudent:
                case User.UserTypeEnum.ContineoStudent:
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

        [When(@"I 'Sign Out' from PSNPlus as '(.*)'")]
        //[When(@"I 'Sign Out' from PSNPlus as ""(.*)""")]
        public void SignoutFromThePegasusAsContineUser(User.UserTypeEnum userTypeEnum)
        {
            //Method to Clicks on SignOut link
            Logger.LogMethodEntry("LoginLogout", "SignoutFromThePegasusAsContineUser",
                base.IsTakeScreenShotDuringEntryExit);
            // Click Sign out link 
            new HomePage().ContineoUserLogout(userTypeEnum);
            Logger.LogMethodExit("LoginLogout", "SignoutFromThePegasusAsContineUser",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Method to verify Required Contineo parameters in RUL page URL.
        /// </summary>
        /// <param name="profileKey">parameter that need to verify.</param>
        /// <param name="k12IntKey">parameter that need to verify.</param>
        [Then(@"I should see Contineo parameters ""(.*)"" and ""(.*)"" in the Rumba Universal Login URL")]
        public void VerifyRequiredParametersInRULUrl(
            String profileKey,String k12IntKey)
        {
            //Log method entry
            Logger.LogMethodEntry("LoginLogout", "VerifyRequiredParametersInRULUrl",
                base.IsTakeScreenShotDuringEntryExit);
            //Intialized expected object in order to assert
            Dictionary<String, String> expectedObj=new Dictionary<string,string>();
            expectedObj.Add(LoginLogoutResource.Contineo_ProfileKey,
                LoginLogoutResource.Contineo_ProfileValue);
            expectedObj.Add(LoginLogoutResource.Contineo_k12IntKey,
                LoginLogoutResource.Contineo_k12IntValue);
            // Log assert result 
            Logger.LogAssertion("VerifyRequiredParametersInRULUrl",
                 ScenarioContext.Current.ScenarioInfo.Title,
                 () => CollectionAssert.AreEqual(expectedObj,
                     new SignInPage().GetRequiredParametersForRUL(profileKey, k12IntKey)));
            // Log method exit
            Logger.LogMethodExit("LoginLogout", "VerifyRequiredParametersInRULUrl",
                IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("LoginLogout", "ClickOnSignInOnRumbaPage",
                base.IsTakeScreenShotDuringEntryExit);
            // Redirect to login page
            new SignInPage().RedirectToRULPage(buttonClass);
           // Log method exit
            Logger.LogMethodExit("LoginLogout", "VerifyRequiredParametersInRULUrl",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify user has logged out from PSNPlus
        /// </summary>
        /// <param name="SignedOut">This is the window name after sign out</param>
        [Then(@"I should see the ""(.*)"" page")]
        public void ValidateContineoUserLogout(string SignedOut)
        {
            //Validate Logout From Rumba
            Logger.LogMethodEntry("LoginLogout", "ValidateContineoUserLogout",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert Logout
            Logger.LogAssertion("ValidateLogout",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(SignedOut, new HomePage().GetContineoSignOutConfirmation(SignedOut)));
            Logger.LogMethodExit("LoginLogout", "ValidateContineoUserLogout",
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
