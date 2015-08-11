#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains details of LTIServices.
    /// </summary>
    [Binding]
    public class LTITools : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(LTITools));

        /// <summary>
        /// Navigate to Services subtab under LTI Tools.
        /// </summary>
        /// <param name="TabName">This param is for tab name</param>
        /// <param name="subtabName">This param is for subtab name</param>
        [When(@"I go to '(.*)' and click '(.*)' subtab")]
        public void NavigateToLTIToolsSubtab(string TabName, string subtabName)
        {
            //Manage to navigate  Products Page
            Logger.LogMethodEntry("LTITools", "NavigateToLTIToolsSubtab",
                base.IsTakeScreenShotDuringEntryExit);
            //Navigate to Manage Products Page
            new AdminToolPage().NavigateToServicesPage();
            Logger.LogMethodExit("LTITools", "NavigateToLTIToolsSubtab",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Clicking on RLCN link under Services sub-tab.
        /// </summary>
        /// <param name="linkname">This param is for link name</param>
        [When(@"I click on '(.*)' link")]
        public void OpenRLCNUtility(string linkname)
        {
            //Open RLCN Utility
            Logger.LogMethodEntry("LTIServices", "OpenRLCNUtility",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Create new Product Link
           new AdminToolPage().ClickOnRLCNUtilityLink();
        }


        /// <summary>
        /// To verify the RLCN Failed Requests pop up is open
        /// </summary>

        [Then(@"I should be on the RLCN Utility Page")]
        public void verifyRLCNFailedRequests()
        {
            //Verify that the RLCN Failed Requests pop up is open
            Logger.LogMethodEntry("RLCNUtilityPage", "verifyRLCNFailedRequests",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify that the RLCN Failed Requests pop up is open
            new RLCNUtilityPage().TriggerFailedRLCNRequests();
            Logger.LogMethodExit("RLCNUtilityPage", "verifyRLCNFailedRequests",
                base.IsTakeScreenShotDuringEntryExit);
        }


    }
}