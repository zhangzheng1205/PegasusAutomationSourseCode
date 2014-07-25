using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Content library related actions.
    /// </summary>
    [Binding]
    public class ContentLibrary : PegasusBaseTestFixture
    {

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ContentLibrary));

        [When(@"I select Advanced Options link")]
        public void ExpandAdvancedOptionsLink()
        {
            Logger.LogMethodEntry("ContentLibrary",
               "ExpandAdvancedOptionsLink",
               base.isTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibrary =
                new ContentLibraryUXPage();
            contentLibrary.SelectAndSwitchToContentLibrary();
            contentLibrary.ExpandAdvancedOptions();
            Logger.LogMethodExit("ContentLibrary",
               "ExpandAdvancedOptionsLink",
               base.isTakeScreenShotDuringEntryExit);
        }

        [When(@"I select checkbox of (.*) assets")]
        public void SelectCheckboxOfAssets(int assetCount)
        {
            Logger.LogMethodEntry("ContentLibrary",
                "SelectCheckboxOfAssets",
                base.isTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibrary =
                new ContentLibraryUXPage();
            contentLibrary.SelectAndSwitchToContentLibrary();
            contentLibrary.SelectCheckboxOfAssets(assetCount);
            Logger.LogMethodExit("ContentLibrary",
               "SelectCheckboxOfAssets",
               base.isTakeScreenShotDuringEntryExit);
        }

        [Then(@"""(.*)"" button on Content Library header should get ""(.*)""")]
        public void VerifyStatusOfButtonOnContentLibraryHeader(
            ContentLibraryUXPage.AdvancedOptionsButtonType buttonType,
            string buttonStatus)
        {
            Logger.LogMethodEntry("ContentLibrary",
                "SelectCheckboxOfAssets",
                base.isTakeScreenShotDuringEntryExit);

            bool isEnabled = new ContentLibraryUXPage()
                .IsButtonEnabledOnHeader(buttonType);
            if (buttonStatus.Equals("Enabled"))
            {
                Assert.IsTrue(isEnabled);
            }
            else
            {
                Assert.IsFalse(isEnabled);
            }
            Logger.LogMethodExit("ContentLibrary",
               "SelectCheckboxOfAssets",
               base.isTakeScreenShotDuringEntryExit);
        }

        [When(@"I select ""(.*)"" button on Content Library header")]
        public void SelectButtonOnContentLibraryHeader(
           ContentLibraryUXPage.AdvancedOptionsButtonType buttonType)
        {
            Logger.LogMethodEntry("ContentLibrary",
                "SelectCheckboxOfAssets",
                base.isTakeScreenShotDuringEntryExit);
            new ContentLibraryUXPage().ClickButtonOnHeader(buttonType);
            Logger.LogMethodExit("ContentLibrary",
               "SelectCheckboxOfAssets",
               base.isTakeScreenShotDuringEntryExit);
        }

        [Then(@"Count (.*) should be displayed in Clipboard Items")]
        public void VerifyClipboardItemsCount(int assetCount)
        {
            Logger.LogMethodEntry("ContentLibrary",
                "SelectCheckboxOfAssets",
                base.isTakeScreenShotDuringEntryExit);
            Assert.AreEqual(assetCount, new ContentLibraryUXPage()
                .GetClipboardItemsCount());
            Logger.LogMethodExit("ContentLibrary",
               "SelectCheckboxOfAssets",
               base.isTakeScreenShotDuringEntryExit);
        }

        [Then(@"Asset title should display in ""(.*)"" color and ""(.*)"" style\.")]
        public void VerifyAssetTitleColorAndFontStyle(
            string titleColor, string fontStyle)
        {
            Logger.LogMethodEntry("ContentLibrary",
                "SelectCheckboxOfAssets",
                base.isTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibrary = new ContentLibraryUXPage();
            Assert.AreEqual(contentLibrary.GetClipboardItemsCount(),
                contentLibrary.GetCountOfAssetTitleByColorAndFontStyle(
                titleColor, fontStyle));
            Logger.LogMethodExit("ContentLibrary",
               "SelectCheckboxOfAssets",
               base.isTakeScreenShotDuringEntryExit);
        }

        [When(@"I Select ""(.*)"" on Paste Advanced Options on Content Library")]
        public void SelectPasteAdvancedOptions(
            ContentLibraryUXPage.PasteOptions pasteOption)
        {
            Logger.LogMethodEntry("ContentLibrary",
                 "SelectPasteAdvancedOptions",
                 base.isTakeScreenShotDuringEntryExit);
            new ContentLibraryUXPage().SelectPasteOption(pasteOption);
            Logger.LogMethodExit("ContentLibrary",
               "SelectPasteAdvancedOptions",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selected Activity By Name And Assigned In My CourseFrame.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        [When(@"I selected activity ""(.*)"" and assigned in My Course frame")]
        public void SelectedActivityAndAssignedInMyCourseFrame(string activityName)
        {
            // select activity and assign 
            Logger.LogMethodEntry("ContentLibrary",
                 "SelectedActivityAndAssignedInMyCourseFrame",
                 base.isTakeScreenShotDuringEntryExit);
            // select and add activity in my course frame
            new Pages.UI_Pages.TeachingPlanUxPage().
                SelectActivityInCourseMaterialsLibraryFrame(activityName);
            Logger.LogMethodExit("ContentLibrary",
            "SelectedActivityAndAssignedInMyCourseFrame",
            base.isTakeScreenShotDuringEntryExit);
        }
    }
}
