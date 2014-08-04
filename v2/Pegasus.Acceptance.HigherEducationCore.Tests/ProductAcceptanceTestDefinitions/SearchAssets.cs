using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.HigherEducation.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests
    .ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles the Search Assets Actions
    /// </summary>
    [Binding]
    public class SearchAssets : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(SearchAssets));

        /// <summary>
        /// Click On Searchview Option.
        /// </summary>
        /// <param name="courseMaterialsType">This is Course Materials Type.</param>
        [When(@"I click on searchview option in ""(.*)""")]
        public void ClickOnSearchviewOption(string courseMaterialsType)
        {
            //Click On Searchview Option
            Logger.LogMethodEntry("SearchAssets",
                "ClickOnSearchviewOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Search The Activity In Course Materials
            new ContentLibraryUXPage().ClickOnSearchViewOption(
                (ContentLibraryUXPage.CourseMaterialsTypeEnum)Enum.Parse
                (typeof(ContentLibraryUXPage.CourseMaterialsTypeEnum),
                courseMaterialsType));
            Logger.LogMethodExit("SearchAssets",
                "ClickOnSearchviewOption",
                 base.IsTakeScreenShotDuringEntryExit);
        }  

        /// <summary>
        ///Search Asset In Course Materials Tab .
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="courseMaterialsType">This is Course Materials Type.</param>
        [When(@"I search ""(.*)"" asset in ""(.*)""")]
        public void SearchAssetInCourseMaterialsTabByAdvancedSearch(
            Activity.ActivityTypeEnum activityTypeEnum,
            string courseMaterialsType)
        {
            //Search Asset In Course Materials Tab
            Logger.LogMethodEntry("SearchAssets",
                "SearchAssetInCourseMaterialsTabByAdvancedSearch",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Search The Activity In Course Materials
            new ContentLibraryUXPage().SearchAssetNameByAdvancedSearchOption(
                (ContentLibraryUXPage.CourseMaterialsTypeEnum)Enum.Parse
                (typeof(ContentLibraryUXPage.CourseMaterialsTypeEnum),
                courseMaterialsType),activity.Name);
            Logger.LogMethodExit("SearchAssets",
                "SearchAssetInCourseMaterialsTabByAdvancedSearch",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Searched Asset Name.
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        [Then(@"I should see the ""(.*)"" in 'Course Materials Library'")]
        public void VerifySearchedAssetInCourseMaterialsLibrary(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify The Searched Asset Name
            Logger.LogMethodEntry("SearchAssets", "VerifySearchedAssetInCourseMaterialsLibrary",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            //Verify The Searched Asset Name
            Logger.LogAssertion("VerifyAssetName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new ContentLibraryUXPage().
                    GetAssetNameFromCourseMaterialsTab(activity.Name)));
            Logger.LogMethodExit("SearchAssets", "VerifySearchedAssetInCourseMaterialsLibrary",
              base.IsTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Click On Advanced Search Option In 'My Course' Frame.
        /// </summary>
        [When(@"I click on AdvancedSearch option in 'My Course'")]
        public void ClickOnAdvancedSearchOptionInMyCourse()
        {
            //Click On Advanced Search Option In 'My Course' Frame.
            Logger.LogMethodEntry("SearchAssets", "ClickOnAdvancedSearchOptionInMyCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Advanced Search Option
            new CourseContentUXPage().ClickAdvanceSearchOption();
            Logger.LogMethodExit("SearchAssets", "ClickOnAdvancedSearchOptionInMyCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Search Asset By Advanced search Option.
        /// </summary>
        /// <param name="activityName"></param>
        [When(@"I search ""(.*)"" asset by advancedsearch option")]
        public void SearchAssetByAdvancedsearchOption(string activityName)
        {
            //Search Asset In 'My Course' Frame
            Logger.LogMethodEntry("SearchAssets",
                "SearchAssetByAdvancedsearchOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Course Materials Window
            new ContentLibraryUXPage().SelectTheWindowName(SearchAssetsResource.
                SearchAssets_Page_CourseMaterials_Window_Name);
            //Fill the Asset Name in Text Box And Click On Search Button
            new AdvancedSearchPage().
                FillAssetNameInTextBoxAndClickSearchButton(activityName);
            Logger.LogMethodExit("SearchAssets",
                "SearchAssetByAdvancedsearchOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Asset Name In 'My Course' Frame.
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        [Then(@"I should see the ""(.*)"" in 'My Course'")]
        public void VerifyAssetNameInMyCourse(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify The Asset Name In 'My Course' Frame
            Logger.LogMethodEntry("SearchAssets", "VerifyAssetNameInMyCourse",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            //Verify The Searched Asset Name
            Logger.LogAssertion("VerifyAssetName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetAssetNameFromMyCourseTab(activity.Name)));
            Logger.LogMethodExit("SearchAssets", "VerifyAssetNameInMyCourse",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Message In MyCourse.
        /// </summary>
        /// <param name="message">This is Message.</param>
        [Then(@"I should see the ""(.*)"" in 'My Course' frame")]
        public void VerifyTheMessageInMyCourse(string message)
        {
            //Verify The Message In MyCourse
            Logger.LogMethodEntry("SearchAssets", "VerifyTheMessageInMyCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify The Searched Asset Name
            Logger.LogAssertion("VerifyAssetName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(message,
                    new CourseContentUXPage().GetAssetNameFromMyCourseTab(message)));
            Logger.LogMethodExit("SearchAssets", "VerifyTheMessageInMyCourse",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Message In ContentLibrary Frame.
        /// </summary>
        /// <param name="message">This is Message.</param>
        [Then(@"I should see the ""(.*)"" in 'Course Materials Library' frame")]
        public void VerifyTheMessageInContentLibraryFrame(string message)
        {
            //Verify The Message In ContentLibrary Frame
            Logger.LogMethodEntry("SearchAssets",
                "VerifyTheMessageInContentLibraryFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify The Searched Asset Name
            Logger.LogAssertion("VerifyAssetName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(message,
                    new ContentLibraryUXPage().
                    GetAssetNameFromCourseMaterialsTab(message)));
            Logger.LogMethodExit("SearchAssets",
                "VerifyTheMessageInContentLibraryFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
