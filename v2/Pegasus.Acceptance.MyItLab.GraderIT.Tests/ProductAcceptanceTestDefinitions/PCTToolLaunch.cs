using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Location;

namespace Pegasus.Acceptance.MyItLab.GraderIT.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class contains the definitions for PCT Click Scenario.
    /// </summary>
    [Binding]
    public class PCTToolLaunch : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PCTToolLaunch));

        /// <summary>
        /// Open PCT Tools DropDown.
        /// </summary>
        [When(@"I click on PCT in Tools DropDown")]
        public void OpenPCTToolsDropDown()
        {
            // Method to launch the PCT URL
            Logger.LogMethodEntry("PCTToolLaunch", "WhenIOpenPCTToolsDropDown",
                isTakeScreenShotDuringEntryExit);

            // Open the PCT Tools drop down from resource tool bar
            new TodaysViewUXPage().OpenPCTToolsDropDown();

            Logger.LogMethodExit("PCTToolLaunch", "WhenIOpenPCTToolsDropDown",
                isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// When I Click On PCT Tool In Tools DropDown.
        /// </summary>
        [When("I click on the \"(.*)\" link")]
        public void ClickOnPCTToolInDropDown(string PCTToolName)
        {
            // Method to launch the PCT URL
            Logger.LogMethodEntry("PCTToolLaunch", "WhenIClickOnPCTToolInDropDown",
                isTakeScreenShotDuringEntryExit);
            new TodaysViewUXPage().LaunchPCTFromDropDown(PCTToolName);
            Logger.LogMethodExit("PCTToolLaunch", "WhenIClickOnPCTToolInDropDown",
                isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify the PCT Window Width and Height.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        [Then(@"I should see the window size is ""(.*)"" by ""(.*)""")]
        public void VerifyPCTWindowHeightandWidth(int width, int height)
        {
            //Verify The PCT window size
            Logger.LogMethodEntry("PCTToolLaunch", "VerifyTheQuestionEditPage"
              , base.isTakeScreenShotDuringEntryExit);

            //Asserts To Verify The PCT window width
            Logger.LogAssertion("VerifyThePCTWindowWidth",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new TodaysViewUXPage().GetPCTWindowWidth() >= width));
            //Asserts To Verify The PCT window height
            Logger.LogAssertion("VerifyThePCTWindowHeight",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new TodaysViewUXPage().GetPCTWindowHeight() >= height));

            Logger.LogMethodExit("PCTToolLaunch", "VerifyTheQuestionEditPage"
                , base.isTakeScreenShotDuringEntryExit);
        }

    }
}
