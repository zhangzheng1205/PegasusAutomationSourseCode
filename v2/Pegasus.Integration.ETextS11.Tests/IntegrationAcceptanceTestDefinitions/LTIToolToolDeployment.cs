using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Integration.Hed.ETextS11.Tests.IntegrationAcceptanceTestDefinitions;

namespace Pegasus.Integration.ETextS11.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contain details of deployment of 
    /// LTI Tool in LTI tab by CSWsAdmin.
    /// </summary>
    [Binding]
    public class LTIToolToolDeployment : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(LTIToolToolDeployment));

        /// <summary>
        /// To Check status of deployed tools in LTI tab.
        /// </summary>
        /// <param name="lTiToolType">This is LTI tooltype</param>
        [Then(@"I should see the ""(.*)"" Tool in enabled state")]
        public void LTIToolInEnabledState(String lTiToolType)
        {
            //Verify The LTI Tool Status
            Logger.LogMethodEntry("LTIToolToolDeployment", "LTIToolInEnabledState",
                    base.IsTakeScreenShotDuringEntryExit);
            // Get LTI Tool is deployed in LTI tab with Enabled Status
            LTIToolsPreferencesPage lTiToolsPreferencesPage =
                new LTIToolsPreferencesPage();
            //Assert eText Tool Status
            Logger.LogAssertion("VerifyeLTIToolEnableState",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(LTIToolDeployment_Resource.
                    LTIToolDeployment_Resource_LTI_Tool_Status
                    , lTiToolsPreferencesPage.
                GetEnabledLTITools(lTiToolType)));
            Logger.LogMethodExit("LTIToolToolDeployment", "LTIToolInEnabledState",
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