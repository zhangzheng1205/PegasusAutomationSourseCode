#region

using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
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

        /// <summary>
        /// To Verify Class on SSO
        /// </summary>
        /// <param name="classTypeEnum"></param>
        /// <param name="courseTypeEnum"></param>
        [Then(@"I should see ""(.*)"" class for ""(.*)"" displayed in classes channel")]
        public void VerifyClassForMultipleMLDisplayedInClassesChannel(Class.ClassTypeEnum classTypeEnum,
            Product.ProductTypeEnum productTypeEnum)
        {
            //Validate class name
            Logger.LogMethodEntry("CreateClass", "VerifyClassForMultipleMLDisplayedInClassesChannel",
             base.IsTakeScreenShotDuringEntryExit);
            //Get class and course name from memory
            Class Class = Class.Get(classTypeEnum);
            Product Product = Product.Get(productTypeEnum);
            string className = Class.Name + ": " + Product.Name;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed.TotalMinutes < 15)
            {
                string actualClass = new HomePage().GetDisplayClassName(className);
                if (actualClass == className) break;
                {
                    new HomePage().GetDisplayClassName(className);
                }
            }

            Logger.LogAssertion("ValidateClassDisplayInClassesChannel", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(className, new HomePage().GetDisplayClassName(className)));
            Logger.LogMethodExit("CreateClass", "VerifyClassForMultipleMLDisplayedInClassesChannel",
            base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should not see ""(.*)"" class for ""(.*)"" displayed in classes channel")]
        public void VerifyForClassNotDisplayedInClassesChannel(Class.ClassTypeEnum classTypeEnum,
            Product.ProductTypeEnum productTypeEnum)
        {
            //Validate class name
            Logger.LogMethodEntry("CreateClass", "VerifyClassForMultipleMLDisplayedInClassesChannel",
             base.IsTakeScreenShotDuringEntryExit);
            //Get class and course name from memory
            Class Class = Class.Get(classTypeEnum);
            Product Product = Product.Get(productTypeEnum);
            string className = Class.Name + ": " + Product.Name;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed.TotalMinutes < 15)
            {
                string actualClass = new HomePage().GetDisplayClassName(className);
                if (!(actualClass == className)) break;
                {
                    new HomePage().GetDisplayClassName(className);
                }
            }

            Logger.LogAssertion("ValidateClassDisplayInClassesChannel", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreNotEqual(className, new HomePage().GetDisplayClassName(className)));
            Logger.LogMethodExit("CreateClass", "VerifyClassForMultipleMLDisplayedInClassesChannel",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Add Product to class in Contineo
        /// </summary>
        /// <param name="Product Name">This the Product Name</param>
        [When(@"I ""(.*)"" Product ""(.*)"" to the class")]
        public void WhenIAddProductToTheClass(string action,Product.ProductTypeEnum productTypeEnum)
        {
            //get the product 
            Product product = Product.Get(productTypeEnum);
            string productName = product.Name;
            new CentralAdminDashboardPage().contineoTrial(action,productName);
        }

    }
}
