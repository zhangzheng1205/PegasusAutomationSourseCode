using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.CommonPageObjects;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This step definition class contains the details of
    /// display of assign contents .
    /// </summary>
    [Binding]
    public class CoursePreview : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
        Logger.GetInstance(typeof(CoursePreview));

        /// <summary>
        /// Verify Calendar Asset Icon
        /// </summary>
        [Then(@"I should see the calendar icon for assigned asset")]
        public void CalendarIconForAssignedAsset()
        {
            //Verify Calendar Asset Icon
            Logger.LogMethodEntry("CoursePreview", "CalendarIconForAssignedAsset",
            base.IsTakeScreenShotDuringEntryExit);
            CalendarFramePage calendarFramePage = new CalendarFramePage();
            //Select Course materials Window and Frame
            calendarFramePage.CoursematerialsWindowandFrame();
            //Verify Calendar Asset Icon
            Logger.LogAssertion("VerifyCalendarIcon", ScenarioContext.
            Current.ScenarioInfo.Title, () => Assert.IsTrue
            (calendarFramePage.IsCalendarIconPresent()));
            Logger.LogMethodExit("CoursePreview", "CalendarIconForAssignedAsset",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Calendar Icon
        /// </summary>
        [When(@"I click on the calendar icon of assigned asset")]
        public void ClickOnCalendarIconofAsset()
        {
            //Click on Calendar Icon
            Logger.LogMethodEntry("CoursePreview", "ClickOnCalendarIconofAsset",
            base.IsTakeScreenShotDuringEntryExit);
            CalendarFramePage calendarFramePage = new CalendarFramePage();
            //Select Course materials Window and Frame
            calendarFramePage.CoursematerialsWindowandFrame();
            //Click on Calendar Icon
            calendarFramePage.ClickOnCalendarIcon();
            Logger.LogMethodExit("CoursePreview", "ClickOnCalendarIconofAsset",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigating to the folder where given asset exists.
        /// </summary>
        /// <param name="Assetname">Asset Name</param>
        /// <param name="tabName">Tab</param>
        /// <param name="userTypeEnum">User type</param>
        [When(@"I navigate to ""(.*)"" asset in ""(.*)"" tab as ""(.*)""")]
        public void NavigateToFolder(string Assetname, string tabName, User.UserTypeEnum userTypeEnum)
        {
            //Navigating to the folder where given asset exists
            Logger.LogMethodEntry("CourseContent", "NavigateToFolder",
                base.IsTakeScreenShotDuringEntryExit);
            new CommonPage().ManageTheActivityFolderLevelNavigation(Assetname, tabName, userTypeEnum);
            Logger.LogMethodExit("CourseContent", "NavigateToFolder",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Opening c menu and clicking on the given c menu option.
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
            new TeachingPlanUxPage().SelectActivityCmenuForInstructor((TeachingPlanUxPage.ActivityCmenuEnum)
                Enum.Parse(typeof(TeachingPlanUxPage.ActivityCmenuEnum), activityCmenuOption), assetName);
            Logger.LogMethodExit("CourseContent", "CMenuOperationsForAnAsset",
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
        /// Checking assigned status.
        /// </summary>
        /// <param name="assetName">Asset Name</param>
        [Then(@"I should see assigned icon for ""(.*)""")]
        public void ConfirmAssetAssignedStatus(string assetName)
        {
            Logger.LogMethodEntry("CourseContent", "ConfirmAssetAssignedStatus",
              base.IsTakeScreenShotDuringEntryExit);

            //Checking the activity status whether it is assigned or not
            Logger.LogAssertion("CheckAssignedStatus",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new CoursePreviewMainUXPage().
                   IsAssetAssigned(assetName)));
            Logger.LogMethodExit("CourseContent", "ConfirmAssetAssignedStatus",
            base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
