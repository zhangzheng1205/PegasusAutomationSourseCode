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

        [Then(@"Asset should should display at ""(.*)"" place")]
        public void VerifyAssetCopiedPosition(string position)
        {
            Logger.LogMethodEntry("ContentLibrary",
                "VerifyAssetCopiedPosition",
                base.isTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibrary = new ContentLibraryUXPage();
            Assert.AreEqual(contentLibrary.GetCountOfAssetTitleByColorAndFontStyle(
                "Red", "Italic"),contentLibrary.GetPastedItemCount());
            Logger.LogMethodExit("ContentLibrary",
               "VerifyAssetCopiedPosition",
               base.isTakeScreenShotDuringEntryExit);
        }

        [Then(@"A ""(.*)"" confirmation pop up should display with ""(.*)"" button and ""(.*)"" button")]
        public void VerifyDisplayOfPopUpWithButtons(
            string popUp, 
            string firstButton, 
            string secondButton)
        {
            Logger.LogMethodEntry("ContentLibrary",
               "VerifyAssetCopiedPosition",
               base.isTakeScreenShotDuringEntryExit);
            ShowMessagePage showMessagePage = new ShowMessagePage();
            Assert.AreEqual(firstButton, 
                showMessagePage.GetOkButtonText());
            Assert.AreEqual(secondButton, 
                showMessagePage.GetCancelButtonText());
            Logger.LogMethodExit("ContentLibrary",
               "VerifyAssetCopiedPosition",
               base.isTakeScreenShotDuringEntryExit);
        }


        [When(@"I click on OK button on Delete confirmation pop up")]
        public void ClickOKButtonOnDeleteConfirmationPopUp()
        {
            Logger.LogMethodEntry("ContentLibrary",
               "ClickOKButtonOnDeleteConfirmationPopUp",
               base.isTakeScreenShotDuringEntryExit);
            new ShowMessagePage().ClickOkButton();
            Logger.LogMethodExit("ContentLibrary",
               "ClickOKButtonOnDeleteConfirmationPopUp",
               base.isTakeScreenShotDuringEntryExit);
        }
       
    }
}
