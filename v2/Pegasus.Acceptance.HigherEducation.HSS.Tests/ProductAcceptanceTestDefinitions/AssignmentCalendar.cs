using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducation.HSS.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Calendar related actions.
    /// </summary>
    [Binding]
    public class AssignmentCalendar : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(AssignmentCalendar));

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

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
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
