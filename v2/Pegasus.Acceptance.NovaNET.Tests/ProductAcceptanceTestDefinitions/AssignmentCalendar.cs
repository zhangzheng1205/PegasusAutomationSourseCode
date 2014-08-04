using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles configuration of calendar and assigning activity.
    /// </summary>
    [Binding]
    public class AssignmentCalendar : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(AssignmentCalendar));

        /// <summary>
        /// Sets Up The Calendar.
        /// </summary>
        [When(@"I Setup the Calendar")]
        public void SetupTheCalendar()
        {
            //Sets Up The Calendar
            Logger.LogMethodEntry("AssignmentCalendar", "SetupTheCalendar",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the 'Calendar Setup' button            
            new EmptyCalendarPage().CheckTheStatusOfCalendarSetupButton();            
            Logger.LogMethodExit("AssignmentCalendar", "SetupTheCalendar",
                base.IsTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Drags And Drops The Asset To The Calendar.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        [When(@"I drag and drop the ""(.*)"" to the calendar")]
        public void DragAndDropTheAssetToTheCalendar(
            String assetName)
        {
            //Drag And Drop the Asset
            Logger.LogMethodEntry("AssignmentCalendar", 
                "DragAndDropTheAssetToTheCalendar",
                base.IsTakeScreenShotDuringEntryExit);
            //Drag and Drop the Asset
            new CalendarDefaultUXPage().DragAndDropAsset(assetName);
            Logger.LogMethodExit("AssignmentCalendar", 
                "DragAndDropTheAssetToTheCalendar",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Calendar Creation Content Message.
        /// </summary>
        /// <param name="contentMessage">This is content messag.e</param>
        [Then(@"I should see the content message ""(.*)""")]
        public void CalendarCreationContentMessage(
            String contentMessage)
        {
            //Calendar Creation Content Message
            Logger.LogMethodEntry("AssignmentCalendar", "CalendarCreationContentMessage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert The Display Of Content message
            Logger.LogAssertion("VerifyAssignedContentMessage",
                ScenarioContext.Current.ScenarioInfo.Title, () => 
                    Assert.AreEqual(contentMessage,
                    new CalendarDefaultUXPage().
                    GetAssignedAssetContentMessage(contentMessage)));
            Logger.LogMethodExit("AssignmentCalendar", "CalendarCreationContentMessage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Assigned Asset
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        [Then(@"""(.*)"" should be successfully assigned to the calendar")]
        public void DisplayOfAssignedAsset(String assetName)
        {
            //Display of Assigned Asset
            Logger.LogMethodEntry("AssignmentCalendar", "DisplayOfAssignedAsset",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert The Display Of Assigned Asset
            Logger.LogAssertion("VerifyAssignedAsset",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(assetName,
                    new CalendarDefaultUXPage().GetAssignedAssetName(assetName)));
            Logger.LogMethodExit("AssignmentCalendar", "DisplayOfAssignedAsset",
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
