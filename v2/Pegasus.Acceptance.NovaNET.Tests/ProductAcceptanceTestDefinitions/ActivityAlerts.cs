using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.NovaNET.Tests.Definitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles the Activity Alerts Actions.
    /// </summary>
    [Binding]
    public class ActivityAlerts : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(ActivityAlerts));

        /// <summary>
        /// Verify the Alert for New Grades.
        /// </summary>
        [Then(@"I should see the alert for New Grades")]
        public void VerifyAlertForNewGrades()
        {
            //Verify the Alert for New Grades
            Logger.LogMethodEntry("ActivityAlerts", "VerifyAlertForNewGrades",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert New Grades Alert
            Logger.LogAssertion("VerifyAlertForNewGrades", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreNotEqual(ActivityAlertsResource.
                    TeacherDashBoard_NewGradesAlert_Value,
                    new TodaysViewUxPage().GetNewGradesAlert()));
            Logger.LogMethodExit("ActivityAlerts", "VerifyAlertForNewGrades",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select New Grades Option.
        /// </summary>
        [When(@"I select New Grades option")]
        public void SelectNewGradesOption()
        {
            //Select New Grades Option
            Logger.LogMethodEntry("ActivityAlerts", "SelectNewGradesOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on New Grades Option
            new TodaysViewUxPage().ClickNewGradesOptionInOverViewTab();
            Logger.LogMethodExit("ActivityAlerts", "SelectNewGradesOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Display of Submitted Activity Name on Clicking the 'New Grades'.
        /// </summary>
        /// <param name="activityName">This is name of activity.</param>
        [Then(@"I should see name of submitted activity as ""(.*)""")]
        public void VerifyNameOfSubmittedActivity(String activityName)
        {
            //Verify the Display of Submitted Activity Name
            Logger.LogMethodEntry("ActivityAlerts", "VerifyNameOfSubmittedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Display of Submitted Activity Name
            Logger.LogAssertion("VerifyNameofSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityName,
                   new TodaysViewUxPage().GetSubmittedActivityName(activityName)));
            Logger.LogMethodExit("ActivityAlerts", "VerifyNameOfSubmittedActivity",
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
