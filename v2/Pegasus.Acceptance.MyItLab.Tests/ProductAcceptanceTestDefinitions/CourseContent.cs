using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Automation.DataTransferObjects;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Course Content related actions.
    /// </summary>
    [Binding]
    public class CourseContent : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CourseContent));

        [When(@"I select checkbox of (.*) assets in My Course View")]
        public void SelectCheckboxOfAssets(int assetCount)
        {
            Logger.LogMethodEntry("CourseContent",
                 "SelectCheckboxOfAssets",
                 base.IsTakeScreenShotDuringEntryExit);
            CourseContentUXPage courseContentPage = new CourseContentUXPage();
            courseContentPage.SelectAndSwitchToMyCourseHome();
            courseContentPage.SelectCheckboxOfAssets(assetCount);
            Logger.LogMethodExit("CourseContent",
              "SelectCheckboxOfAssets",
              base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see ""(.*)"" button on My Course View header ""(.*)""")]
        public void VerifyButtonStatusOnMyCourseViewHeader(
            CourseContentUXPage.MyCourseButtonType buttonType, 
            string buttonStatus)
        {
            Logger.LogMethodEntry("CourseContent",
                 "VerifyButtonStatusOnMyCourseViewHeader",
                 base.IsTakeScreenShotDuringEntryExit);
            bool isEnabled = new CourseContentUXPage()
                .IsButtonEnabled(buttonType);
            if (buttonStatus.Equals("Enabled")){
                Assert.IsTrue(isEnabled);
            }else{
                Assert.IsFalse(isEnabled);
            }           
            Logger.LogMethodExit("CourseContent",
              "VerifyButtonStatusOnMyCourseViewHeader",
              base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I select ""(.*)"" button on My Course View header")]
        public void SelectButtonOnMyCourseViewHeader(
            CourseContentUXPage.MyCourseButtonType buttonType)
        {
            Logger.LogMethodEntry("CourseContent",
                  "SelectButtonOnMyCourseViewHeader",
                  base.IsTakeScreenShotDuringEntryExit);
            new CourseContentUXPage().ClickButtonOnHeader(buttonType);
            Logger.LogMethodExit("CourseContent",
              "SelectButtonOnMyCourseViewHeader",
              base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see the assets which are shown should be hidden and assets which are hidden should be shown")]
        public void VerifyAssetsShowHideStatus()
        {
            Logger.LogMethodEntry("CourseContent",
                 "VerifyAssetsShowHideStatus",
                 base.IsTakeScreenShotDuringEntryExit);
            if (base.IsPopupPresent(CourseContentResource
                .CourseContent_ShowHide_ConfirmationPopup_Name))
            {
                this.ClickOkButtonOnPegasusConfirmationPopUp();
            }
            Activity shownActivity = Activity.Get(Activity.ShowHideStatusEnum.Shown);
            base.SelectDefaultWindow();
            CourseContentUXPage courseContentPage = new CourseContentUXPage();
            courseContentPage.SelectAndSwitchToMyCourseHome();
            if (shownActivity != null)
            {
                Assert.AreEqual(Activity.ShowHideStatusEnum.Hidden,
                courseContentPage
                .GetAssetsShowHideStatus(shownActivity.ActivityID));
                return;
            }
            Activity hiddenActivity = Activity.Get(Activity.ShowHideStatusEnum.Hidden);
            if (hiddenActivity != null)
            {
                Assert.AreEqual(Activity.ShowHideStatusEnum.Shown,
               courseContentPage
                .GetAssetsShowHideStatus(hiddenActivity.ActivityID));
            }
            Logger.LogMethodExit("CourseContent",
              "VerifyAssetsShowHideStatus",
              base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see None or All should be displayed for the assets under Shown-To column when they are Hidden or shown respectively")]
        public void VerifyDisplayOfTextInShownToColumn()
        {
            Logger.LogMethodEntry("CourseContent",
                 "VerifyDisplayOfTextInShownToColumn",
                 base.IsTakeScreenShotDuringEntryExit);
            string shownToText;            
            CourseContentUXPage courseContentUXPage = new CourseContentUXPage();
            Activity shownActivity = Activity.Get(Activity.ShowHideStatusEnum.Shown);
            if (shownActivity != null)
            {
                shownToText = courseContentUXPage.GetTextInShownToColumn(
                    shownActivity.ActivityID);
                Assert.AreEqual(CourseContentResource.CourseContent_None_Value,
                    shownToText);
                return;
            }
            Activity hiddenActivity = Activity.Get(Activity.ShowHideStatusEnum.Hidden);
            if (hiddenActivity != null)
            {
                shownToText = courseContentUXPage.GetTextInShownToColumn(
                    hiddenActivity.ActivityID);
                if (shownToText.Equals(CourseContentResource.CourseContent_All_Value)
                    || shownToText.Equals(CourseContentResource
                    .CourseContent_Selected_Value))
                    Assert.IsTrue(true);
            }
            Logger.LogMethodExit("CourseContent",
              "VerifyDisplayOfTextInShownToColumn",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks Ok button on Pegasus confirmation pop-up.
        /// </summary>
        public void ClickOkButtonOnPegasusConfirmationPopUp()
        {
            Logger.LogMethodEntry("CourseContent",
               "ClickOKButtonOnPegasusConfirmationPopUp",
               base.IsTakeScreenShotDuringEntryExit);
            //If assets are already attempted by student a show hide pop-up will appear.
            try
            {
                new ShowMessagePage().ClickOkButton();
            }
            catch{}
            Logger.LogMethodExit("CourseContent",
               "ClickOKButtonOnPegasusConfirmationPopUp",
               base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
