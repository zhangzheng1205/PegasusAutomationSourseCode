using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.WritingSpace.
    Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Calendar related actions.
    /// </summary>
    [Binding]
    public class AssignmentCalendar:PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(AssignmentCalendar));

        /// <summary>
        /// Search Content In Assignment Calendar.
        /// </summary>
        /// <param name="contentName">This is Content Name.</param>
        [When(@"I search ""(.*)"" activity in calendar")]
        public void SearchContentInAssignmentCalendar(
                Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Search Content In Assignment Calendar
            Logger.LogMethodEntry("AssignmentCalendar", 
                "SearchContentInAssignmentCalendar",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the activity from memory
            Activity activity = Activity.Get(activityTypeEnum);
            new CourseHomeListItemViewPage().SelectCourseHomeWindow();
            //Search Content
            new CalendarHEDDefaultUXPage().SearchContent(activity.Name);
            Logger.LogMethodExit("AssignmentCalendar", 
                "SearchContentInAssignmentCalendar",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Searched Asset In Assignment Calendar Message.
        /// </summary>
        /// <param name="assetName">This is Message.</param>
        [Then(@"I should see the ""(.*)"" in 'Assignment Calendar'")]
        public void VerifySearchedAssetMessageInAssignmentCalendar(string message)
        {
            //Verify Searched Asset In Assignment Calendar Message
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifySearchedAssetMessageInAssignmentCalendar",
                base.isTakeScreenShotDuringEntryExit);
            //Verify The message
            Logger.LogAssertion("VerifyThefailureMessage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(message,
                    new CalendarHEDDefaultUXPage().
                    GetMessageFromAssignmentCalendarTab(message)));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifySearchedAssetMessageInAssignmentCalendar",
              base.isTakeScreenShotDuringEntryExit);
        }        
    }
}
