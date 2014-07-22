#region

using System;
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
    /// This Class Handles Basic Search and Advanced Search Actions.
    /// </summary>
    [Binding]
    public class SearchAssets : PegasusBaseTestFixture
    {
        /// <summary>
        /// Static instance of the logger.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(SearchAssets));

        /// <summary>
        /// Search the Asset.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        /// <param name="searchCriteriaLinkName">This is Search Criteria Link Name</param>
        [When(@"I search the asset type ""(.*)"" by ""(.*)"" criteria")]
        public void SearchAssetByCriteria(
            Activity.ActivityTypeEnum activityTypeEnum, 
            String searchCriteriaLinkName)
        {
            //Search the Asset
            Logger.LogMethodEntry("SearchAssets", "SearchAssetByCriteria",
                base.isTakeScreenShotDuringEntryExit);
            //Get the Activity Name From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Check Activity Assign To Copy State
            new ContentLibraryPage().CheckActivityAssignToCopyStateInCurriculumTab(activity.Name);
            //Search the Asset based on criteria
            new ContentLibraryPage().SearchAsset(activity.Name,
                (ContentLibraryPage.SearchCriteriaEnum)Enum.Parse
                (typeof(ContentLibraryPage.SearchCriteriaEnum), searchCriteriaLinkName));
            Logger.LogMethodExit("SearchAssets", "SearchAssetByCriteria",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Asset Searched Successfully.
        /// </summary>
        /// <param name="activityTypeEnum"> This is Activity by Type enum.</param>
        [Then(@"I should see the searched asset ""(.*)""")]
        public void VerifyAssetSearchedSuccessfully(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Asset Searched Successfully
            Logger.LogMethodEntry("SearchAssets", "VerifyAssetSearchedSuccessfully",
               base.isTakeScreenShotDuringEntryExit);
            //Get the Activity Name From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert Asset Searched Successfully
            Logger.LogAssertion("VerifyAssetSearchedSuccessfully",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name, new ContentLibraryPage().
                    GetAssetName()));
            Logger.LogMethodExit("SearchAssets", "VerifyAssetSearchedSuccessfully",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clear Searched Result.
        /// </summary>
        [When(@"I clear the searched result")]
        public void ClearSearchedResult()
        {
            //Clear Searched Result
            Logger.LogMethodEntry("SearchAssets", "ClearSearchedResult",
              base.isTakeScreenShotDuringEntryExit);
            //Clear Searched Result
            new ContentLibraryPage().ClearSearchedResult();
            Logger.LogMethodExit("SearchAssets", "ClearSearchedResult",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Verify Searched Result Present.
        /// </summary>
        [Then(@"I should not see the searched result")]
        public void VerifySearchedResultPresent()
        {
            //Verify Searched Result Present
            Logger.LogMethodEntry("SearchAssets", "VerifySearchedResultPresent",
              base.isTakeScreenShotDuringEntryExit);
            //Assert for Searched Result Present or Not
            Logger.LogAssertion("VerifyAssetSearchedSuccessfully",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(false, new ContentLibraryPage().
                   CheckClearResultLinkPresent()));
            Logger.LogMethodExit("SearchAssets", "VerifySearchedResultPresent",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Asset Using Advanced Search.
        /// </summary>
        /// <param name="activityTypeEnum"> This is Activity by Type enum.</param>
        ///  <param name="tabName"> This is search tab name.</param>
        [When(@"I search the asset type ""(.*)"" in ""(.*)"" tab using Advanced Search")]
        public void SearchAssetUsingAdvancedSearch(
            Activity.ActivityTypeEnum activityTypeEnum,
            String tabName)
        {
            //Search Asset Using Advanced Search
            Logger.LogMethodEntry("SearchAssets", "SearchAssetUsingAdvancedSearch",
              base.isTakeScreenShotDuringEntryExit);
            //Get the Activity Name From Memory
            Activity activity = Activity.Get(activityTypeEnum);            
            //Search Asset Using Advanced Search
            new AdvancedSearchPage().SearchAssetUsingAdvancedSearch(activity.Name, 
                (AdvancedSearchPage.SearchTab)Enum.Parse
                (typeof(AdvancedSearchPage.SearchTab),tabName));
            Logger.LogMethodExit("SearchAssets", "SearchAssetUsingAdvancedSearch",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Asset in Planner Tab.
        /// </summary>
        /// <param name="activityTypeEnum"> This is Activity by Type enum.</param>
        [When(@"I search the asset ""(.*)""")]
        public void SearchAssetInPlannerTab(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Search Asset in Planner Tab
            Logger.LogMethodEntry("SearchAssets", "SearchAssetInPlannerTab",
                base.isTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            //Search Asset in Planner Tab
            new CalendarDefaultGlobalUXPage().SearchAssetInPlannerTab(activity.Name);
            Logger.LogMethodExit("SearchAssets", "SearchAssetInPlannerTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Asset Searched Successfully in Planner Tab.
        /// </summary>
        /// <param name="activityTypeEnum"> This is Activity by Type enum.</param>
        [Then(@"I should see the searched asset ""(.*)"" successfully")]
        public void VerifySearchedAssetSuccessfullyInPlannerTab(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Verify Asset Searched Successfully in Planner Tab
            Logger.LogMethodEntry("SearchAssets", "VerifySearchedAssetSuccessfullyInPlannerTab",
                base.isTakeScreenShotDuringEntryExit);
            //Get the Activity Name From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert Asset Searched Successfully
            Logger.LogAssertion("VerifyAssetSearchedSuccessfully",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name, new CalendarDefaultGlobalUXPage().
                    GetAssetName()));
            Logger.LogMethodExit("SearchAssets", "VerifySearchedAssetSuccessfullyInPlannerTab",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clear Searched result in Planner Tab.
        /// </summary>
        [When(@"I clear the searched result in planner tab")]
        public void ClearSearchedResultInPlannerTab()
        {
            //Clear Searched result in Planner Tab
            Logger.LogMethodEntry("SearchAssets", "ClearSearchedResultInPlannerTab",
                base.isTakeScreenShotDuringEntryExit);
            //Clear Searched result in Planner Tab
            new CalendarDefaultGlobalUXPage().ClearSearchedResult();
            Logger.LogMethodExit("SearchAssets", "ClearSearchedResultInPlannerTab",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Searched Result Present In Planner Tab.
        /// </summary>
        [Then(@"I should not see the searched result in planner tab")]
        public void VerifySearchedResultPresentInPlannerTab()
        {
            //Verify Searched Result Present In Planner Tab
            Logger.LogMethodEntry("SearchAssets", "VerifySearchedResultPresentInPlannerTab",
                 base.isTakeScreenShotDuringEntryExit);
            //Assert for Searched Result Present or Not
            Logger.LogAssertion("VerifyAssetSearchedSuccessfully",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(false, new CalendarDefaultGlobalUXPage().
                   CheckClearResultLinkPresent()));
            Logger.LogMethodExit("SearchAssets", "VerifySearchedResultPresentInPlannerTab",
                 base.isTakeScreenShotDuringEntryExit);
        }       

        /// <summary>
        /// Verify Searched Asset In Planner Tab.
        /// </summary>
        /// <param name="activityTypeEnum"> This is activity by Type enum.</param>
        [Then(@"I should see the searched asset ""(.*)"" in planner tab")]
        public void VerifySearchedAssetInPlannerTab(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Searched Asset In Planner Tab
            Logger.LogMethodEntry("SearchAssets", "VerifySearchedAssetInPlannerTab",
                 base.isTakeScreenShotDuringEntryExit);
            //Get the Activity Name From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert Asset Searched Successfully
            Logger.LogAssertion("VerifyAssetSearchedSuccessfully",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name, new CalendarDefaultGlobalUXPage().
                    GetAssetName()));
            Logger.LogMethodExit("SearchAssets", "VerifySearchedAssetInPlannerTab",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution start.
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
