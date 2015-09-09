using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Automation;
using Pegasus.Pages.UI_Pages.SSRSReports;

namespace Pegasus.Integration.SSRSReports.Tests.
    CommonProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of LoginLogout page 
    /// and handles SSRS LoginLogout Page Actions.
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
        [Given(@"I browse the login URL for ""(.*)""")]
        public void BrowseSSRSLoginUrl(string userType)
        {
            //Browse Login Url
            Logger.LogMethodEntry("LoginLogout", "BrowseSSRSLoginUrl",
                base.IsTakeScreenShotDuringEntryExit);
            // Pick Url based on user type enum
            loginPage = new BrowsePegasusUserURL((User.UserTypeEnum)
                Enum.Parse(typeof(User.UserTypeEnum), userType));
            loginPage.GoToSSRSLoginUrl();
            Logger.LogMethodExit("LoginLogout", "BrowseSSRSLoginUrl",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userTypeEnum"></param>
        [When(@"I log into the SSRS as ""(.*)""")]
        public void LoginIntoTheSSRS(User.UserTypeEnum userTypeEnum)
        {
            //Login in Pegasus
            Logger.LogMethodEntry("LoginLogout", "LoginIntoTheSSRS",
                base.IsTakeScreenShotDuringEntryExit);
                try
                {
                    //Get the user of the given type from Memory Data Store
                    User user = User.Get(userTypeEnum);
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
            Logger.LogMethodExit("LoginLogout", "BrowseSSRSLoginUrl",
                base.IsTakeScreenShotDuringEntryExit);
            }

        /// <summary>
        /// Verify if the desired Report page is loaded
        /// </summary>
        /// <param name="pageName"></param>
        [When(@"I am on the '(.*)' Page")]
        [Then(@"I should be on the '(.*)' Page")]
        public void LoggedInSuccessfully(string pageName)
        {
            //Login Success
            Logger.LogMethodEntry("LoginLogout", "LoggedInSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
            string actualWindowName = pageName + LoginResource.Login_Window_Name_Append_Title;
            //Assert we have logged in successfully
            Logger.LogAssertion("VerifyLoginSuccess",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(actualWindowName, new FolderPage().getWindowName()));
            Logger.LogMethodExit("LoginLogout", "LoggedInSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
