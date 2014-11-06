using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.CommonPageObjects;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
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
                .GetAssetsShowHideStatus(shownActivity.ActivityId));
                return;
            }
            Activity hiddenActivity = Activity.Get(Activity.ShowHideStatusEnum.Hidden);
            if (hiddenActivity != null)
            {
                Assert.AreEqual(Activity.ShowHideStatusEnum.Shown,
               courseContentPage
                .GetAssetsShowHideStatus(hiddenActivity.ActivityId));
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
            CourseContentUXPage courseContentUxPage = new CourseContentUXPage();
            Activity shownActivity = Activity.Get(Activity.ShowHideStatusEnum.Shown);
            if (shownActivity != null)
            {
                shownToText = courseContentUxPage.GetTextInShownToColumn(
                    shownActivity.ActivityId);
                Assert.AreEqual(CourseContentResource.CourseContent_None_Value,
                    shownToText);
                return;
            }
            Activity hiddenActivity = Activity.Get(Activity.ShowHideStatusEnum.Hidden);
            if (hiddenActivity != null)
            {
                shownToText = courseContentUxPage.GetTextInShownToColumn(
                    hiddenActivity.ActivityId);
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

        /// <summary>
        /// Opening c menu and clicking on the given c menu option
        /// </summary>
        /// <param name="activityCmenuOption">c menu option  name</param>
        /// <param name="assetName">Activity name</param>
        [When(@"I click on ""(.*)"" option in c menu of ""(.*)"" asset")]
        public void CMenuOperationsForAnAsset(string activityCmenuOption, string assetName)
        {
            //Select Cmenu Option Of Activity
            Logger.LogMethodEntry("CourseContent", "CMenuOperationsForAnAsset",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Activity Cmenu Option
            new CoursePreviewMainUXPage().SelectActivityCmenuForInstructor(
                (CoursePreviewMainUXPage.ActivityCmenuEnum)
                Enum.Parse(typeof(CoursePreviewMainUXPage.ActivityCmenuEnum),
                activityCmenuOption), assetName);
            Logger.LogMethodExit("CourseContent", "CMenuOperationsForAnAsset",
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
        /// Assigning the activity with due date.
        /// </summary>
        [When(@"I assign asset with due date and save")]
        public void AssignAssetWithDueDateAndSave()
        {
            Logger.LogMethodEntry("CourseContent", "AssignAssetWithDueDateAndSave",
               base.IsTakeScreenShotDuringEntryExit);
            AssignContentPage assignContent = new AssignContentPage();
            //Selecting assign radio button
            assignContent.SelectAssignedRadiobutton();
            //Set duedate
            assignContent.GetAndFillDueDate();
            //Setting due date and save
            assignContent.SaveProperties();
            Logger.LogMethodExit("CourseContent", "AssignAssetWithDueDateAndSave",
              base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Assigning the asset with duedate and scheduling with start and end date
        /// </summary>
        [When(@"I assign and schedule the asset and save")]
        public void AssignAndScheduleTheAssetAndSave()
        {
            Logger.LogMethodEntry("CourseContent", "AssignAndScheduleTheAssetAndSave",
               base.IsTakeScreenShotDuringEntryExit);
            AssignContentPage assignContent = new AssignContentPage();
            //Selecting assign radio button
            assignContent.SelectAssignedRadiobutton();
            //Setting due date
            assignContent.GetAndFillDueDate();
            //Setting the start date and end date
            assignContent.SetStartAndEndDate();
            Logger.LogMethodExit("CourseContent", "AssignAndScheduleTheAssetAndSave",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checking assigned status
        /// </summary>
        /// <param name="assetName">Asset Name</param>
        [Then(@"I should see assigned icon for ""(.*)""")]
        public void ConfirmAssetAssignedStatus(string assetName)
        {
            Logger.LogMethodEntry("CourseContent", "IsAssetAssigned",
              base.IsTakeScreenShotDuringEntryExit);

            //Checking the activity status whether it is assigned or not
            Logger.LogAssertion("CheckAssignedStatus",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new CoursePreviewMainUXPage().
                   IsAssetAssigned(assetName)));
            Logger.LogMethodExit("CourseContent", "IsAssetAssigned",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Checking for assigned and scheduled status
        /// </summary>
        /// <param name="assetName">Asset name</param>
        [Then(@"I should see scheduled icon for ""(.*)""")]
        public void ConfirmAssetAssignedAndScheduledStatus(string assetName)
        {
            Logger.LogMethodEntry("CourseContent", "IsAssetAssignedAndScheduled",
              base.IsTakeScreenShotDuringEntryExit);

            //Checking the activity status whether it is assigned or not
            Logger.LogAssertion("CheckAssignedStatus",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new CoursePreviewMainUXPage().
                    IsAssetScheduled(assetName)));
            Logger.LogMethodExit("CourseContent", "IsAssetAssignedAndScheduled",
             base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I assign the asset to with a due date near to past due date")]
        public void AssignWithDueDateNearToPastDueDate()
        {
            Logger.LogMethodEntry("CourseContent", "AssignAndScheduleTheAssetAndSave",
                base.IsTakeScreenShotDuringEntryExit);
            AssignContentPage assignContent = new AssignContentPage();
            //Selecting assign radio button
            assignContent.SelectAssignedRadiobutton();
            //Setting due date
            assignContent.FillDueDateNearPastDueDate();
        }

    }
}
