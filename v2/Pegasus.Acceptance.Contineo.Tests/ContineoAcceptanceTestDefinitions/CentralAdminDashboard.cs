#region

using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages.Integration.Contineo;

#endregion

namespace Pegasus.Acceptance.Contineo.
    Tests.ContineoAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the common feature steps
    /// that can be reuse while verifying
    /// the scenarios.
    /// </summary>
    [Binding]
    public class CentralAdminDashboard : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CentralAdminDashboard));
        /// <summary>
        /// Verify if Central Admin Page is open
        /// </summary>
        /// <param name="tabName">This is to get the Tab Name</param>
        [Then(@"I should be on the ""(.*)"" Page")]
        public void VerifyCentralAdminPage(string tabName)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("CentralAdminDashboard", "VerifyCentralAdminPage",
                IsTakeScreenShotDuringEntryExit);
            bool isCentralAdminPage = false;
            //Get expected page title from the feature file
            string expectedPageTitle = tabName;
            if (isCentralAdminPage)
            {
                //Verify if the Page is open
                Logger.LogAssertion("CentralAdminDashboard", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.Fail(CentralAdminDashboardPageResource.CentralAdminDashboard_PageNotOpened_Message));
            }
            else
            {
                //Check if window is open and get the Window name
                string getWindowName = new CentralAdminDashboardPage().IsCentralAdminPageOpen();
                //Assert we have correct page opened
                Logger.LogAssertion("CentralAdminDashboard",
                    ScenarioContext.Current.ScenarioInfo.Title,
                    () => Assert.AreEqual(expectedPageTitle, getWindowName));
            }
            Logger.LogMethodExit("CentralAdminDashboard", "VerifyCentralAdminPage",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the PSNPlus link in CAT
        /// </summary>
        [When(@"I click on '(.*)' link under Learning systems")]
        public void clickPSNPlusLink(string LMSName)
        {
            //Click PSNPlus link in CAT page
            Logger.LogMethodEntry("CentralAdminDashboard", "clickPSNPlusLink",
                IsTakeScreenShotDuringEntryExit);
            //Verify PSNPlus link is present and click on it
            new CentralAdminDashboardPage().SSOtoPSNPlus(LMSName);
            Logger.LogMethodExit("CentralAdminDashboard", "clickPSNPlusLink",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// SignOut of CAT as Contineo User
        /// </summary>
        /// <param name="userTypeEnum">This is user type based on user role.</param>
        [When(@"I 'Sign Out' from Central Admin as ""(.*)""")]
        public void ContineoUserSignOutfromCAT(User.UserTypeEnum userTypeEnum)
        {
            //Click PSNPlus link in CAT page
            Logger.LogMethodEntry("CentralAdminDashboard", "ContineoUserSignOutfromCAT",
                IsTakeScreenShotDuringEntryExit);
            //Contineo User Sign Out from CAT
            new CentralAdminDashboardPage().SignOutfromCAT(userTypeEnum);
            Logger.LogMethodExit("CentralAdminDashboard", "ContineoUserSignOutfromCAT",
                IsTakeScreenShotDuringEntryExit);
        }

    }
}
