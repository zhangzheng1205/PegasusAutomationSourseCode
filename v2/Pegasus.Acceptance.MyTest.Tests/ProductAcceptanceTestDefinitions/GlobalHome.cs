using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyTest.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handle the all the action happend on Global Home page.
    /// </summary>
    [Binding]
    class GlobalHome : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(InstructorSearchCatalog));

        /// <summary>
        /// Click on UpgradeAvialbe Link of TestBank to 
        /// varify the displayed of upgrade button on Upgrdae popup.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type Enum.</param>
        [When(@"I click on Up arrow image followed by Upgrade Available link of the ""(.*)"" course")]
        public void ClickOnUpgradeAvailableLinkOfTheCourse(Course.
            CourseTypeEnum courseTypeEnum)
        {
            //Logger Enrty
            Logger.LogMethodEntry("GlobalHome", "ClickOnUpgradeAvailableLinkOfTheCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Instance of HEDGlobalHomePage
            //Click on Upgrade Available Link of TestBank
            new HEDGlobalHomePage().ClickOnUpgradeAvailableOfTestBank(courseTypeEnum);
            //Logger Exit 
            Logger.LogMethodExit("GlobalHome", "ClickOnUpgradeAvailableLinkOfTheCourse",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the Keep Me Test Course checkbox status on Upgrade Popup.
        /// </summary>
        /// <param name="textMessage">This is name of checkbox</param>
        [Then(@"I should see the Keep My Test course check box which is enabled by default on Upgrade Popup")]
        public void VerifyTheCheckBoxStateOnUpgradePopup()
        {
            //Logger Enrty
            Logger.LogMethodEntry("GlobalHome", "VerifyTheCheckBoxStateOnUpgradePopup",
                base.isTakeScreenShotDuringEntryExit);
            //Instance of HEDGlobalHomePage
            HEDGlobalHomePage hedGlobalHomePage = new HEDGlobalHomePage();
            //Assert the checkbox is enable on Upgrade Popup
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(hedGlobalHomePage.
                    IsStatusOfKeepMeTestCourseCheckBoxEnabled()));
            //Close the popup window
            hedGlobalHomePage.CloseUpgradePopupWindow();
            //Logger Exit 
            Logger.LogMethodExit("GlobalHome", "VerifyTheCheckBoxStateOnUpgradePopup",
               base.isTakeScreenShotDuringEntryExit);

        }

    }
}
