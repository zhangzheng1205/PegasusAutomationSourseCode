using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This step definition class contains the details of
    /// View the contents in To Do
    /// </summary>
    [Binding]
    public class ViewToDoContents : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ViewToDoContents));

        /// <summary>
        /// Display The Assigned Asset In To Do Tab.
        /// </summary>
        /// <param name="activityName">This is Activity Type Enum.</param>       
        [Then(@"I should see the display of assigned asset ""(.*)"" in ToDo tab")]
        public void DisplayTheAssignedAssetInToDoTab(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Open the Activity Presentation Window
            Logger.LogMethodEntry("ViewToDoContents", "DisplayTheAssignedAssetInToDoTab"
                , base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Verify The Assigned Content In To Do Tab         
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new StudTodoDonePage().GetAssignedContentInToDoTab(activity.Name)));
            Logger.LogMethodExit("ViewToDoContents", "DisplayTheAssignedAssetInToDoTab"
                 , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Assigned Completed Asset In Completed Tab.
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        [Then(@"I should see the assigned completed asset ""(.*)"" in completed tab")]
        public void VerifyAssignedCompletedAssetInCompletedTab(string assetName)
        {
            //Verify Assigned Completed Asset In Completed Tab
            Logger.LogMethodEntry("ViewToDoContents",
                "VerifyAssignedCompletedAssetInCompletedTab"
                   , base.IsTakeScreenShotDuringEntryExit);
            //Verify The Assigned Completed Content In Completed Tab         
            Logger.LogAssertion("VerifyAssignedCompletedAssetName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(assetName,
                    new StudTodoDonePage().GetAssignedCompletedContentInCompletedTab(assetName)));
            Logger.LogMethodExit("ViewToDoContents",
                "VerifyAssignedCompletedAssetInCompletedTab"
                 , base.IsTakeScreenShotDuringEntryExit);
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
