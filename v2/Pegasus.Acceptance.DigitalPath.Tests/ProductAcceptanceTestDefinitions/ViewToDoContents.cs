#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles View Assigned Contents in To Do Tab.
    /// </summary>
    [Binding]
    public class ViewToDoContents : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(ViewToDoContents));

        /// <summary>
        /// Display The Assigned Asset In To Do Tab.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>       
        [Then(@"I should see the display of assigned asset ""(.*)"" in ToDo tab")]
        public void DisplayTheAssignedAssetInToDoTab(String activityName)
        {
            //Display The Assigned Asset In To Do Tab
            Logger.LogMethodEntry("ViewToDoContents", "DisplayTheAssignedAssetInToDoTab",
               base.IsTakeScreenShotDuringEntryExit);            
            //Verify The Assigned Content In To Do Tab         
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityName,
                    new StudTodoDonePage().GetAssignedContentInToDoTab(activityName)));
            Logger.LogMethodExit("ViewToDoContents", "DisplayTheAssignedAssetInToDoTab",
               base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
