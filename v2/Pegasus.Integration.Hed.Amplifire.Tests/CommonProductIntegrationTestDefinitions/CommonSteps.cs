using Pegasus.Automation.DataTransferObjects;
using TechTalk.SpecFlow;
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.CommonPageObjects;
using Pegasus.Acceptance.MyTest.Tests.CommonProductAcceptanceTestDefinitions;

namespace Pegasus.Integration.Hed.Amplifire.Tests.ProductIntegrationTestDefinitions
{
    /// <summary>
    /// This class contains the common feature steps
    /// that can be reused while verifying the scenarios.
    /// </summary>
    [Binding]
    public class CommonSteps : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(CommonSteps));

        /// <summary>
        /// This is Frame Type Enum
        /// </summary>
        public enum FrameTypeEnum
        {
            /// <summary>
            /// This is Left frame
            /// </summary>
            left = 1,
            /// <summary>
            /// This is Right frame
            /// </summary>
            right = 2,
        }


        /// <summary>
        /// Check If The Expected Page Is Opened.
        /// </summary>
        /// <param name="expectedPageTitle">This is Expected Page Title.</param>
        [Then("I should be on the \"(.*)\" page")]
        [Given(@"I am on the ""(.*)"" page")]
        public void ShowThePageInPegasus(
            String expectedPageTitle)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("CommonSteps", "ShowThePageInPegasus",
                IsTakeScreenShotDuringEntryExit);
            //Wait Till Thinking Indicator Loads
            bool isThinkingIndicatorLoading = IsThinkingIndicatorLoading();
            //If Thinking Indicator In Process After Specified Time Interval then Fail This Step
            if (isThinkingIndicatorLoading)
            {
                Logger.LogAssertion("VerifyOpenedPageTitle", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.Fail(CommonStepsResource.CommonSteps_PageNotOpened_Message));
            }
            //Wait For Page Get Switched
            WaitUntilPageGetSwitchedSuccessfully(expectedPageTitle);
            //Get current opened page title
            string getActualPageTitle = GetPageTitle;
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedPageTitle, getActualPageTitle));
            Logger.LogMethodExit("CommonSteps", "ShowThePageInPegass",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Course Space User Tabs.
        /// </summary>
        /// <param name="parentTabName">This is Parent Tab Name.</param>
        /// <param name="childTabName">This is Child Tab Name.</param>      
        [When(@"I navigate to ""(.*)"" tab and selected ""(.*)"" subtab")]
        public void NavigateToCourseSpaceUserTabs(
            string parentTabName, string childTabName)
        {
            //Navigate to Tab
            Logger.LogMethodEntry("CommonSteps", "NavigateToCourseSpaceUserTabs",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Tab
            new TodaysViewUxPage().SelectTab(parentTabName, childTabName);
            Logger.LogMethodExit("CommonSteps", "NavigateToCourseSpaceUserTabs",
               base.IsTakeScreenShotDuringEntryExit);
        }




        /// <summary>
        /// Navigating to the folder where given asset exists
        /// </summary>
        /// <param name="Assetname">Asset Name</param>
        /// <param name="tabName">Tab</param>
        /// <param name="userTypeEnum">User type</param>
        [When(@"I navigate to ""(.*)"" asset in ""(.*)"" tab as ""(.*)""")]
        public void NavigateToFolder(string Assetname, string tabName, User.UserTypeEnum userTypeEnum)
        {
            //Select Cmenu Option Of Activity
            Logger.LogMethodEntry("CourseContent", "NavigateToFolder",
                base.IsTakeScreenShotDuringEntryExit);
            new CommonPage().ManageTheActivityFolderLevelNavigation(Assetname, tabName, userTypeEnum);
            Logger.LogMethodExit("CourseContent", "NavigateToFolder",
             base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select Cmenu Option Of Activity.
        /// </summary>
        /// <param name="cmenuOptionName">This is Cmenu Option Name.</param>
        /// <param name="activityName">This is activity name.</param>
        [When(@"I select cmenu ""(.*)"" option of activity ""(.*)""")]
        public void SelectCmenuOptionOfActivity(string cmenuOptionName,
            string activityName)
        {
            // select cmenu option
            Logger.LogMethodEntry("LaunchActivity", "SelectCmenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            // select activity cmenu option
            new TeachingPlanUxPage().SelectActivityCmenuOptionInMyCourseFrame((TeachingPlanUxPage.ActivityCmenuEnum)
                Enum.Parse(typeof(TeachingPlanUxPage.ActivityCmenuEnum), cmenuOptionName), activityName);
            Logger.LogMethodExit("LaunchActivity", "SelectCmenuOptionOfActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }



         /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {
            //Reset Webdriver Instance
            new CommonSteps().ResetWebdriver();
        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test.
        /// and stops the webdriver.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {
            // clean processess
            new CommonSteps().WebDriverCleanUp();
        }
    }
}
