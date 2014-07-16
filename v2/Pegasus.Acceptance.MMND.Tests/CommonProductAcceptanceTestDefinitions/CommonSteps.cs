using System;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Acceptance.MMND.Tests.CommonProductAcceptanceTestDefinitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MMND.Tests.
    CommonProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the common feature steps that can be reuse while verifying
    /// the scenarios.
    /// </summary>
    [Binding]
    public class CommonSteps : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(CommonSteps));

        /// <summary>
        /// Check If The Expected Page Is Opened.
        /// </summary>
        /// <param name="expectedPageTitle">This is Expected Page Title.</param>
        [Then("I should be on the \"(.*)\" page")]
        [Given(@"I am on the ""(.*)"" page")]
        public void ShowThePageInMMND(String expectedPageTitle)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("CommonSteps", "ShowThePageInMMND",
                base.isTakeScreenShotDuringEntryExit);
            //Wait Till Thinking Indicator Loads
            bool isThinkingIndicatorLoading = base.IsThinkingIndicatorLoading();
            //If Thinking Indicator In Process After Specified Time Interval then Fail This Step
            if (isThinkingIndicatorLoading)
            {
                Logger.LogAssertion("VerifyOpenedPageTitle",
                    ScenarioContext.Current.ScenarioInfo.Title,
                    () => Assert.Fail(CommonStepsResource.CommonSteps_PageNotOpened_Message));
            }
            //Wait For Page Get Switched
            base.WaitUntilPageGetSwitchedSuccessfully(expectedPageTitle);
            //Get current opened page title
            string getActualPageTitle = base.GetPageTitle;
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedPageTitle, getActualPageTitle));
            Logger.LogMethodExit("CommonSteps", "ShowThePageInMMND",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside MMNDCourse.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I navigate inside ""(.*)"" course in ""(.*)""")]
        public void NavigateInsideMMNDCourse(
            Course.CourseTypeEnum courseTypeEnum, User.UserTypeEnum userTypeEnum)
        {
            //Navigate Inside MMNDCourse
            Logger.LogMethodEntry("CommonSteps", "NavigateInsideMMNDCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Enter into the Course
            new UserLayoutRootNodeTargetPage().EnterIntoMMNDCourse
                (courseTypeEnum, userTypeEnum);
            Logger.LogMethodExit("CommonSteps", "NavigateInsideMMNDCourse",
                base.isTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Click On Subtab.
        /// </summary>
        /// <param name="linkName">This is Subtab.</param>
        [When(@"I click on ""(.*)"" subtab")]
        public void ClickOnSubtab(string subtabName)
        {
            //Click On Subtab
            Logger.LogMethodEntry("CommonSteps", "ClickOnSubtab",
                isTakeScreenShotDuringEntryExit);
            //Navigate to Sub Tab           
            new ViewPage().NavigateInsideSubTabLink(subtabName);
            Logger.LogMethodExit("CommonSteps", "ClickOnSubtab",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type.</param>
        /// <param name="userTypeEnum">This is user time enum.</param>
        [When(@"I enter in the ""(.*)"" from the Global Home page as ""(.*)""")]
        public void EnterInCourse(Course.CourseTypeEnum courseTypeEnum,
            User.UserTypeEnum userTypeEnum)
        {
            //Enter in Course from Global Home Page 
            Logger.LogMethodEntry("CommonSteps", "EnterInCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Enter Into The Course
            new HEDGlobalHomePage().EnterInsideCourse(
                courseTypeEnum, userTypeEnum);
            Logger.LogMethodExit("CommonSteps", " EnterInCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Navigate to Tab Window
        ///Verifies that Correct Window Opened.
        /// </summary>
        /// <param name="tabName">This is Name of the Tab.</param>
        [When(@"I navigate to the ""(.*)"" tab")]
        [Then("I navigate to the \"(.*)\" tab")]
        [Then(@"I select the ""(.*)"" tab")]
        [Given(@"I select the ""(.*)"" tab")]
        [When(@"I select the ""(.*)"" tab")]
        [Given("I navigate to the \"(.*)\" tab")]
        public void NavigateToTheTab(String tabName)
        {
            //Method to Navigate to the Tab Window 
            Logger.LogMethodEntry("CommonSteps", "NavigateToTheTab",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.PartialLinkText(tabName));
            //Get Tab Element Property
            IWebElement getTabNameProperty = base.
                GetWebElementPropertiesByPartialLinkText(tabName);
            //Click on Tab 
            base.ClickByJavaScriptExecutor(getTabNameProperty);
            //Wait Till Thinking Indicator Loads
            bool isThinkingIndicatorLoading = base.IsThinkingIndicatorLoading();
            //If Thinking Indicator In Process After Specified Time Interval then Fail This Step
            if (isThinkingIndicatorLoading)
            {
                Logger.LogAssertion("VerifyOpenedPageTitle", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.Fail(CommonStepsResource.CommonSteps_PageNotOpened_Message));
            }
            Logger.LogMethodExit("CommonSteps", "NavigateToTheTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should be on the ""(.*)"" window")]
        public void VerifyCustomColumnWindow(string expectedPageTitle)
        {
            //Method to Navigate to the Tab Window 
            Logger.LogMethodEntry("CommonSteps", "OpenCustomColumnWindow",
                base.isTakeScreenShotDuringEntryExit);
            new GBInstructorUXPage().SelectTheWindowName(expectedPageTitle);
            string getActualPageTitle = base.GetPageTitle;
            Logger.LogAssertion("VerifyOpenedPageTitle", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedPageTitle, getActualPageTitle));
            Logger.LogMethodExit("CommonSteps", "OpenCustomColumnWindow",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts
        /// </summary>
        [BeforeScenario]
        public static void Setup()
        {
            new CommonSteps().ResetWebdriver();
        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test
        /// and stops the webdriver.
        /// </summary>
        [AfterScenario]
        public static void TearDown()
        {
            // clean processess
            new CommonSteps().WebDriverCleanUp();
        }
    }
}
