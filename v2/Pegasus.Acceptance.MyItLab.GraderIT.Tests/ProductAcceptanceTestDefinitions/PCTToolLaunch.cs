using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyITLab.GraderIT.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class contains the definitions for PCT Click Scenario.
    /// </summary>
    [Binding]
    public class PctToolLaunch : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PctToolLaunch));

        /// <summary>
        /// Open PCT Tools DropDown.
        /// </summary>
        [When(@"I click on PCT in Tools DropDown")]
        public void OpenPctToolsDropDown()
        {
            // Method to launch the PCT URL
            Logger.LogMethodEntry("PCTToolLaunch", "OpenPctToolsDropDown",
                IsTakeScreenShotDuringEntryExit);

            // Open the PCT Tools drop down from resource tool bar
            new TodaysViewUXPage().OpenPCTToolsDropDown();

            Logger.LogMethodExit("PCTToolLaunch", "OpenPctToolsDropDown",
                IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// When I Click On PCT Tool In Tools DropDown.
        /// </summary>
        [When("I click on the \"(.*)\" link")]
        public void ClickOnPctToolInDropDown(string pctToolName)
        {
            // Method to launch the PCT URL
            Logger.LogMethodEntry("PCTToolLaunch", "ClickOnPctToolInDropDown",
                IsTakeScreenShotDuringEntryExit);
            new TodaysViewUXPage().LaunchPCTFromDropDown(pctToolName);
            Logger.LogMethodExit("PCTToolLaunch", "ClickOnPctToolInDropDown",
                IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify the PCT Window Width and Height.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        [Then(@"I should see the window size is ""(.*)"" by ""(.*)""")]
        public void VerifyPctWindowHeightandWidth(int width, int height)
        {
            //Verify The PCT window size
            Logger.LogMethodEntry("PCTToolLaunch", "VerifyTheQuestionEditPage"
              , base.IsTakeScreenShotDuringEntryExit);

            //Asserts To Verify The PCT window width
            Logger.LogAssertion("VerifyThePCTWindowWidth",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new TodaysViewUXPage().GetPCTWindowWidth() >= width));
            //Asserts To Verify The PCT window height
            Logger.LogAssertion("VerifyThePCTWindowHeight",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new TodaysViewUXPage().GetPCTWindowHeight() >= height));

            Logger.LogMethodExit("PCTToolLaunch", "VerifyTheQuestionEditPage"
                , base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
