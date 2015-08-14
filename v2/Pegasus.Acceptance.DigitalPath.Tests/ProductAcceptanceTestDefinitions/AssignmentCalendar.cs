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
                base.IsTakeScreenShotDuringEntryExit);
            // New instance of Emptycalendarpage to select calendar set up button
            new EmptyCalendarPage().SelectCalendarSetUp();
            Logger.LogMethodExit("AssignmentCalendar", "ClickCalendarSetUpButton",
                base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Assign the activity from left frame to calendar.
        /// </summary>
        [When(@"I set the due date for the ""(.*)"" activity")]
        public void SetDueDateForActivity(String activityName)
        {
            //Assign the activity in calendar
            Logger.LogMethodEntry("AssignmentCalendar", "AssignActivityInCalendar",
                base.IsTakeScreenShotDuringEntryExit);            
            // fetch class name 
            Class orgClass = Class.Get(Class.ClassTypeEnum.DigitalPathMasterLibrary);
            // Assign activity from left frame
            new CalendarDefaultGlobalUXPage().
                SetDueDateOfActivity(activityName, orgClass.Name);
            Logger.LogMethodExit("AssignmentCalendar", "AssignActivityInCalendar",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            // Assign activity from left frame
            new CalendarDefaultGlobalUXPage().AssignActivityToCalendar(activity.Name);
            Logger.LogMethodExit("AssignmentCalendar", "AssignTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            // fetch class name 
            Class orgClass = Class.Get(Class.ClassTypeEnum.DigitalPathMasterLibrary);
            // Assign activity from left frame
            new CalendarDefaultGlobalUXPage().
                SetDueDateOfActivity(activity.Name, orgClass.Name);
            Logger.LogMethodExit("AssignmentCalendar", "SetDueDateForTheActivityInCalendar",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the assigned activity on the calendar.
        /// </summary>
        [Then("I should see the activity assigned successfully")]
        public void VerifyAssignedActivity()
        {
            //Assign the activity in calendar
            Logger.LogMethodEntry("AssignmentCalendar", "VerifyAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert assigned activity on the calendar frame
            Logger.LogAssertion("VerifyPrsentationLaunch", 
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new CalendarDefaultGlobalUXPage().
                    IsAssignedTextPresent()));
            Logger.LogMethodExit("AssignmentCalendar", "VerifyAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

               
        /// <summary>
        /// Verify the calendar being set up on the right frame.
        /// </summary>
        /// <param name="expectedPeriod">This is the period name.</param>
        [Then(@"I should see the ""(.*)"" period configured in calendar successfully")]
        public void VerifyTheCalendarSetUp(string expectedPeriod)
        {
            //Verify the calendar title
            Logger.LogMethodEntry("AssignmentCalendar", "VerifyTheCalendarSetUp",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the period to be referred
            Product product = Product.Get(Product.ProductTypeEnum.DigitalPath);
            expectedPeriod = product.PeriodName;
            //Assert calendar title on the calendar frame
            Logger.LogAssertion("VerifyPrsentationLaunch",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new CalendarDefaultGlobalUXPage().
                  IsPeriodPresent(expectedPeriod)));
           
            Logger.LogMethodExit("AssignmentCalendar", "VerifyTheCalendarSetUp",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Expand the folder in TOC view of Planner tab.
        /// </summary>
        /// <param name="folderName">Name of the folder to expand.</param>
        [When(@"I expand the folder ""(.*)"" in Planner tab")]
        public void ExpandFolderInPlannerTab(string folderName)
        {
            //Expand the folder in Planner tab
            Logger.LogMethodEntry("AssignmentCalendar", "ExpandFolderInPlannerTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Expand the folder
            new CalendarDefaultGlobalUXPage().ExpandFolderInPlannerTab(folderName);
            Logger.LogMethodExit("AssignmentCalendar", "ExpandFolderInPlannerTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Expand the sub folder in planner tab.
        /// </summary>
        /// <param name="subFolderName">Name of the sub folder to expand.</param>
        [When(@"I expand the sub folder ""(.*)"" in Planner tab")]
        public void ExpandSubFolderInPlannerTab(string subFolderName)
        {
            //Expand the Sub folder in Planner tab
            Logger.LogMethodEntry("AssignmentCalendar", "ExpandSubFolderInPlannerTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Expan sub folder
            new CalendarDefaultGlobalUXPage().ExpandSubFolderInPlannerTab(subFolderName);
            Logger.LogMethodExit("AssignmentCalendar", "ExpandSubFolderInPlannerTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Expand the leaf folder in planner tab.
        /// </summary>
        /// <param name="leafFolderName">Name of the lead folder to expand.</param>
        [When(@"I expand the leaf folder ""(.*)"" in Planner tab")]
        public void ExpandLeafFolderInPlannerTab(string leafFolderName)
        {
            //Expand the leaf folder in Planner tab
            Logger.LogMethodEntry("AssignmentCalendar", "ExpandLeafFolderInPlannerTab",
                base.IsTakeScreenShotDuringEntryExit);
            new CalendarDefaultGlobalUXPage().LeafFolderExpansionInPlannerTab(leafFolderName);
            Logger.LogMethodExit("AssignmentCalendar", "ExpandLeafFolderInPlannerTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Cmenu icon of the activity in Planner tab.
        /// </summary>
        /// <param name="cmenuOption">Cmenu name</param>
        /// <param name="activityName">Activity name</param>
        [When(@"I select cmenu option ""(.*)"" of ""(.*)"" activity in Planner tab")]
        public void SelectCmenuOptionOfLCCInPlannerTab(string cmenuOption, string activityName)
        {
            //Find activity and click on the cmenu option
            Logger.LogMethodEntry("AssignmentCalendar", "SelectCmenuOptionOfLCCInPlannerTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Find activity in planner tab and click on the cmenu option
            new CalendarDefaultGlobalUXPage().FindActivityAndClickOnCmenu(cmenuOption, activityName);
            Logger.LogMethodExit("AssignmentCalendar", "SelectCmenuOptionOfLCCInPlannerTab",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Drag and drop the activity. 
        /// </summary>
        /// <param name="activityName">Name of the content to drag and drop.</param>
        [When(@"I Drag and drop the study plan ""(.*)""")]
        public void DragAndDropContent(string activityName)
        {
            //Drag and drop the activity in planner
            Logger.LogMethodEntry("AssignmentCalendar", "DragAndDropContent",
                base.IsTakeScreenShotDuringEntryExit);
             new CalendarDefaultGlobalUXPage().DragAndDropActivityInPlannerTab(activityName);
            Logger.LogMethodExit("AssignmentCalendar", "DragAndDropContent",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Refresh the planner tab.
        /// </summary>
        [When(@"I refresh the frame till content is copied")]
        public void RefreshCalendarFrame()
        {
            //Validate assigned content in calendar
            Logger.LogMethodEntry("AssignmentCalendar", "RefreshCalendarFrame",
                base.IsTakeScreenShotDuringEntryExit);
            new CalendarDefaultGlobalUXPage().VerifyAssignedTextOnCalendar();
            Logger.LogMethodExit("AssignmentCalendar", "RefreshCalendarFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify assigned content display in Calendar frame
        /// </summary>
        /// <param name="activityName">Content name to validate.</param>
        [Then(@"I should see the assigned Study plan ""(.*)"" in calendar frame")]
        public void ValidateAssignedContentDisplayInCalendar(string activityName)
        {
            //Validate assigned content in calendar
            Logger.LogMethodEntry("AssignmentCalendar", "ValidateAssignedContentDisplayInCalendar",
                base.IsTakeScreenShotDuringEntryExit);
            //Validate assigned content in calendar
            Logger.LogAssertion("ValidateAssignedContentDisplayInCalendar", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityName, new CalendarDefaultGlobalUXPage().GetAssignedContentTitle(activityName)));
            Logger.LogMethodExit("AssignmentCalendar", "ValidateAssignedContentDisplayInCalendar",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select product from the Curriculum dropdown.
        /// </summary>
        /// <param name="p0"></param>
        [When(@"I select ""(.*)"" Product from the Curriculum dropdown")]
        public void SelectProductFromCurriculumDropdown(Product.ProductTypeEnum productName)
        {
            Logger.LogMethodEntry("AssignmentCalendar", "SelectProductFromCurriculumDropdown",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the Product Name from Test Data
            Product Product = Product.Get(productName);
            string digitalPathProductName = Product.Name.ToString();
            CalendarDefaultGlobalUXPage calendarDefaultGlobalUXPage = new CalendarDefaultGlobalUXPage();
            calendarDefaultGlobalUXPage.SelectProductInCurriculumDropdown(digitalPathProductName);
            Logger.LogMethodExit("AssignmentCalendar", "SelectProductFromCurriculumDropdown",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify the Assigned Content Under a period in calendar frame in Day View.
        /// </summary>
        /// <param name="assetName">This is the Asset name.</param>
        /// <param name="periodName">This is the period name.</param>
        [Then(@"I should see the assigned asset ""(.*)"" under the period ""(.*)"" in calendar frame")]
        public void VerifyAssignedAssetUnderPeriodInCalendarDayView(string assetName, 
            Product.ProductTypeEnum productTypeEnum)
        {
            // To verify the Assigned Content Under a period in calendar frame in Day View
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyAssignedAssetUnderPeriodInCalendarDayView",
               base.IsTakeScreenShotDuringEntryExit);
            Product product = Product.Get(productTypeEnum);
            string periodName = product.PeriodName.ToString();
            //Assert assigned asset Under a period in calendar frame in Day View
            Logger.LogAssertion("VerifyAssignedAssetUnderPeriodInCalendarDayView",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new CalendarDefaultGlobalUXPage().
                      IsAssetPresentUnderPeriodInCalendarDayView(assetName, periodName)));
            base.SelectDefaultWindow();
            Logger.LogMethodExit("AssignmentCalendar",
            "VerifyAssignedAssetUnderPeriodInCalendarDayView",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the expected activity Dragged and Drooped to the calendar.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        [When(@"I refresh the frame till ""(.*)"" is displayed in calendar frame")]
        public void VerifyDisplayOfDragAndDropActivity(string activityName)
        {
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyDisplayOfDragAndDropActivity",
               base.IsTakeScreenShotDuringEntryExit);
            
            Logger.LogAssertion("VerifyAssignedAssetUnderPeriodInCalendarDayView",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new CalendarDefaultGlobalUXPage().IsDragDropActivityPresentInCalendar(activityName)));
            base.SelectDefaultWindow();
            Logger.LogMethodExit("AssignmentCalendar",
            "VerifyDisplayOfDragAndDropActivity",
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
