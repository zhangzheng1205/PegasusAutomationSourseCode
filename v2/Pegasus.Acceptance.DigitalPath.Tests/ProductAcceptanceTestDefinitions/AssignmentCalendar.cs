#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
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
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(AssignmentCalendar));

        /// <summary>
        /// Select calendar set up button.
        /// </summary>
        [When("I click on the Calendar set up button")]
        public void ClickCalendarSetUpButton()
        {
            //Select calendar set up button
            Logger.LogMethodEntry("AssignmentCalendar", "ClickCalendarSetUpButton",
                base.isTakeScreenShotDuringEntryExit);
            // New instance of Emptycalendarpage to select calendar set up button
            new EmptyCalendarPage().SelectCalendarSetUp();
            Logger.LogMethodExit("AssignmentCalendar", "ClickCalendarSetUpButton",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Assign the activity from left frame to calendar.
        /// </summary>
        [When(@"I set the due date for the ""(.*)"" activity")]
        public void SetDueDateForActivity(String activityName)
        {
            //Assign the activity in calendar
            Logger.LogMethodEntry("AssignmentCalendar", "AssignActivityInCalendar",
                base.isTakeScreenShotDuringEntryExit);            
            // fetch class name 
            Class orgClass = Class.Get(Class.ClassTypeEnum.DigitalPathMasterLibrary);
            // Assign activity from left frame
            new CalendarDefaultGlobalUXPage().
                SetDueDateOfActivity(activityName, orgClass.Name);
            Logger.LogMethodExit("AssignmentCalendar", "AssignActivityInCalendar",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign the activity to the calendar on current date.
        /// </summary>
        /// <param name="activityTypeEnum">This is Actvity Type Enum.</param>
        [When(@"I assign the ""(.*)"" activity on current date")]
        public void AssignTheActivity(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Assign the activity in calendar
            Logger.LogMethodEntry("AssignmentCalendar", "AssignTheActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            // Assign activity from left frame
            new CalendarDefaultGlobalUXPage().AssignActivityToCalendar(activity.Name);
            Logger.LogMethodExit("AssignmentCalendar", "AssignTheActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Due Date For The Activity In Calendar.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        [When(@"I set the due date for the ""(.*)"" activity in calendar")]
        public void SetDueDateForTheActivityInCalendar(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Assign the activity in calendar
            Logger.LogMethodEntry("AssignmentCalendar", "SetDueDateForTheActivityInCalendar",
                base.isTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            // fetch class name 
            Class orgClass = Class.Get(Class.ClassTypeEnum.DigitalPathMasterLibrary);
            // Assign activity from left frame
            new CalendarDefaultGlobalUXPage().
                SetDueDateOfActivity(activity.Name, orgClass.Name);
            Logger.LogMethodExit("AssignmentCalendar", "SetDueDateForTheActivityInCalendar",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the assigned activity on the calendar.
        /// </summary>
        [Then("I should see the activity assigned successfully")]
        public void VerifyAssignedActivity()
        {
            //Assign the activity in calendar
            Logger.LogMethodEntry("AssignmentCalendar", "VerifyAssignedActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Assert assigned activity on the calendar frame
            Logger.LogAssertion("VerifyPrsentationLaunch", 
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new CalendarDefaultGlobalUXPage().
                    IsAssignedTextPresent()));
            Logger.LogMethodExit("AssignmentCalendar", "VerifyAssignedActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the calendar being set up on the right frame.
        /// </summary>
        [Then("I should see the calendar configured successfully")]
        public void VerifyTheCalendarSetUp()
        {
            //Verify the calendar title
            Logger.LogMethodEntry("AssignmentCalendar", "VerifyTheCalendarSetUp",
                base.isTakeScreenShotDuringEntryExit);
            //Assert calendar title on the calendar frame
            Logger.LogAssertion("VerifyPrsentationLaunch", 
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new CalendarDefaultGlobalUXPage().
                    GetCalendarTitle().Contains
                    (AssignmentCalendarResource.
                    AssignmentCalendar_CalendarTitle_Value)));
            Logger.LogMethodExit("AssignmentCalendar", "VerifyTheCalendarSetUp",
                base.isTakeScreenShotDuringEntryExit);
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
