using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.WritingSpace.Tests.
    ProductAcceptanceTestDefinitions
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
        /// Click The Add Course Materials Button.
        /// </summary>
        /// <param name="courseMaterialsType">This is CourseMaterials Type.</param>
        [When(@"I click on the 'Add Course Materials' button in ""(.*)""")]
        public void ClickTheAddCourseMaterialsButton(string courseMaterialsType)
        {
            //Click The Add Course Materials Button
            Logger.LogMethodEntry("SearchAssets", "ClickTheAddCourseMaterialsButton",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Add Course Materials Button
            new ContentLibraryUXPage().ClickOnTheAddCourseMaterialsButton
                ((ContentLibraryUXPage.CourseMaterialsTypeEnum)Enum.Parse
                (typeof(ContentLibraryUXPage.CourseMaterialsTypeEnum),
                courseMaterialsType));
            Logger.LogMethodExit("SearchAssets","ClickTheAddCourseMaterialsButton",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Activity In Course Materials.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="courseMaterialsType">This is Course Materials type.</param>
        [When(@"I search the ""(.*)"" Activity in ""(.*)""")]
        public void SearchTheActivityInCourseMaterials(
            Activity.ActivityTypeEnum activityTypeEnum,string courseMaterialsType)
        {
            //Search The Activity In Course Materials
            Logger.LogMethodEntry("SearchAssets",
                "SearchTheActivityInCourseMaterials",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Search The Activity In Course Materials
            new ContentLibraryUXPage().SearchTheActivityNameInCourseMaterials(
                (ContentLibraryUXPage.CourseMaterialsTypeEnum)Enum.Parse
                (typeof(ContentLibraryUXPage.CourseMaterialsTypeEnum),
                courseMaterialsType),activity.Name);
            Logger.LogMethodExit("SearchAssets",
                "SearchTheActivityInCourseMaterials",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Verify The Activity In Course Materials.
        /// </summary>
        /// <param name="assetName">This is Activity Name.</param>
        /// <param name="courseMaterialsType">This is Course Materials Type.</param>
        [Then(@"I should see the ""(.*)"" message in ""(.*)""")]
        public void VerifyTheActivityInCourseMaterials(string assetName,
            string courseMaterialsType)
        {
            //Verify The Activity In Course Materials
            Logger.LogMethodEntry("SearchAssets",
                "VerifyTheActivityInCourseMaterials",
                base.isTakeScreenShotDuringEntryExit);
            //Verify The Searched Asset Name
            Logger.LogAssertion("VerifyAssetName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(assetName,
                    new ContentLibraryUXPage().
                    GetActivityNameInCourseMaterialsTab(
                    (ContentLibraryUXPage.CourseMaterialsTypeEnum)Enum.Parse
                     (typeof(ContentLibraryUXPage.CourseMaterialsTypeEnum),
                          courseMaterialsType),assetName)));
            Logger.LogMethodExit("SearchAssets",
                "VerifyTheActivityInCourseMaterials",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click The Advanced Search Link In Course Materials.
        /// </summary>
        /// <param name="courseMaterialsType">This is CourseMaterials Type.</param>
        [When(@"I click the 'Advanced Search' link in ""(.*)""")]
        public void ClickOnTheAdvancedSearchLinkInCourseMaterials(string courseMaterialsType)
        {
            //Click on Advanced Search Link In Course Materials
            Logger.LogMethodEntry("SearchAssets",
                "ClickOnTheAdvancedSearchLinkInCourseMaterials",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Advanced Search link Option
            new ContentLibraryUXPage().ClickTheAdvancedSearchLinkInCourseMaterials
                ((ContentLibraryUXPage.CourseMaterialsTypeEnum)Enum.Parse
                (typeof(ContentLibraryUXPage.CourseMaterialsTypeEnum),
                courseMaterialsType));
            Logger.LogMethodExit("SearchAssets",
                "ClickOnTheAdvancedSearchLinkInCourseMaterials",
                 base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Verify The Display OF Asset In Add Course Materials.
        /// </summary>
        /// <param name="assetName">This is Asset Type Name.</param>
        [Then(@"I should not see the ""(.*)""")]
        public void VerifyTheDisplayOfAssetInAddCourseMaterials(string assetName)
        {
            //Verify The Display OF Asset In Add Course Materials
            Logger.LogMethodEntry("SearchAssets",
                "VerifyTheDisplayOfAssetInAddCourseMaterials",
                base.isTakeScreenShotDuringEntryExit);
            //Verify the Display Of Asset In Add Course Materials
            Logger.LogAssertion("VerifyTheAssetDisplayed",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreNotEqual(assetName,new ContentLibraryUXPage().
                   GetTheDisplayOfActivityNameInAddCourseMaterials(assetName)));
            Logger.LogMethodExit("SearchAssets",
                "VerifyTheDisplayOfAssetInAddCourseMaterials",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display Of Asset In Advanced Search Popup.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        [Then(@"I should not see the ""(.*)"" in Advanced search popup")]
        public void VerifyTheDisplayOfAssetInAdvancedSearchPopup(string assetName)
        {
            //Verify The Display Of Asset In Advanced Search Popup
            Logger.LogMethodEntry("SearchAssets",
                "VerifyTheDisplayOfAssetInAdvancedSearchPopup",
                base.isTakeScreenShotDuringEntryExit);
            //Verify the Display of asset In Advanced Search Popup
            Logger.LogAssertion("VerifyTheDisplayOfAsset",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreNotEqual(assetName,new ContentLibraryUXPage().
                   GetTheDisplayOfAssetTypeInAdvancedSearchPopup(assetName)));
            Logger.LogMethodExit("SearchAssets",
                "VerifyTheDisplayOfAssetInAdvancedSearchPopup",
                 base.isTakeScreenShotDuringEntryExit);
        }
    }
}
