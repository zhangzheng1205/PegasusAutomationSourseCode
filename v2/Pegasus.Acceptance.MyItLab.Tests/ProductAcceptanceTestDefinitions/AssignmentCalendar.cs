using Pearson.Pegasus.TestAutomation.Frameworks;
using System;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public class AssignmentCalendar : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(AssignmentCalendar));


        /// <summary>
        /// Click On View Advanced Calendar
        /// </summary>
        [When(@"I select 'View Advanced calendar' option in calendar")]
        public void ClickViewAdvancedCalendar()
        {
            //Click On View Advanced Calendar
            Logger.LogMethodEntry("AssignmentCalendar", "ClickViewAdvancedCalendar",
               base.isTakeScreenShotDuringEntryExit);
            //Click on View Advanced Calendar
            new CalendarHEDDefaultUXPage().ClickOnViewAdvancedCalendar();
            Logger.LogMethodExit("AssignmentCalendar", "ClickViewAdvancedCalendar",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Current date
        /// </summary>
        [When(@"I select the current date")]
        public void SelectCurrentDate()
        {
            //Select Current Date
            Logger.LogMethodEntry("AssignmentCalendar", "SelectCurrentDate",
               base.isTakeScreenShotDuringEntryExit);
            //Select Current Date
            new CalendarHEDDefaultUXPage().SelectCurrentDateFromCalendar();
            Logger.LogMethodExit("AssignmentCalendar", "SelectCurrentDate",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify AssignCourseMaterials And DayWeekMonth option
        /// </summary>
        /// <param name="assignCourseMaterialsOption">This is AssignCoursematerialsOption</param>
        /// <param name="dayWeekMonthOption">This is dayWeekMonth Option</param>
        /// <param name="addNoteoption">This is AddNote Option</param>
        [Then(@"I should see the ""(.*)"" option with ""(.*)"" and ""(.*)"" button")]
        public void VerifyAddCourseMaterialsAndDayWeekMonth(string assignCourseMaterialsOption,
            string dayWeekMonthOption, string addNoteoption)
        {
            //Verify AssignCourseMaterials And DayWeekMonth option
            Logger.LogMethodEntry("AssignmentCalendar", "VerifyAddCourseMaterialsAndDayWeekMonth",
               base.isTakeScreenShotDuringEntryExit);
            //Verify Assign Course Materials
            Logger.LogAssertion("VerifyAssignCourseMaterials",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(assignCourseMaterialsOption,
                new CalendarHEDDefaultUXPage().GetAssignCourseMaterialsText()));
            //Verify DayWeekMonth
            Logger.LogAssertion("VerifyDayWeekMonth",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(dayWeekMonthOption,
                new CalendarHEDDefaultUXPage().getDayWeekMonthText()));
            //Verify AddNote Text
            Logger.LogAssertion("VerifyAddNote", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(addNoteoption, new CalendarHEDDefaultUXPage().GetAddNoteText()));
            Logger.LogMethodExit("AssignmentCalendar", "VerifyAddCourseMaterialsAndDayWeekMonth",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Assign Message
        /// </summary>
        /// <param name="assignCountMessage">This is assign count message</param>
        /// <param name="assignTextMessage">This is assign Text Message</param>
        [Then(@"I should see the message of calendar ""(.*)"" and ""(.*)""")]
        public void VerifyAssignMessage(string assignCountMessage, string assignTextMessage)
        {
            //Verify Assign Message
            Logger.LogMethodEntry("AssignmentCalendar", "VerifyAssignMessage",
             base.isTakeScreenShotDuringEntryExit);
            //Verify Assign Count Message
            Logger.LogAssertion("VerifyAssignCountMessage",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
               Assert.AreEqual(assignCountMessage,
               new CalendarHEDDefaultUXPage().getAssignedCountwithText()));
            //Verify Assign Text Message
            Logger.LogAssertion("VerifyAssignTextMessage",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
               Assert.AreEqual(assignTextMessage,
               new CalendarHEDDefaultUXPage().getAssignedTextInCalendarFrame()));
            Logger.LogMethodExit("AssignmentCalendar", "VerifyAssignMessage",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="activityBehavioralModeEnum">This is Activity Behavioral Type Enum.</param>
        [When(@"I search the ""(.*)"" activity of behavioral mode ""(.*)""")]
        public void SearchActivity(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum activityBehavioralModeEnum)
        {
            //Search the Activity
            Logger.LogMethodEntry("AssignmentCalendar", "SearchActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, activityBehavioralModeEnum);
            //Search the Activity            
            new CalendarHEDDefaultUXPage().SearchTheActivity(activity.Name);
            Logger.LogMethodExit("AssignmentCalendar", "SearchActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Searched Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="activityBehavioralModeEnum">This is Activity Behavioral Type Enum.</param>
        [Then(@"I should see the searched ""(.*)"" activity of behavioral mode ""(.*)""")]
        public void DisplayOfSearchedActivity(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum activityBehavioralModeEnum)
        {
            //Display Of Searched Activity
            Logger.LogMethodEntry("AssignmentCalendar",
                "DisplayOfSearchedActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity =
                Activity.Get(activityTypeEnum, activityBehavioralModeEnum);
            //Assert the Searched Activity            
            Logger.LogAssertion("VerifySearchedActivity",
                ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.AreEqual(activity.Name,
                    new CalendarHEDDefaultUXPage().
                GetSearchedActivityName()));
            Logger.LogMethodExit("AssignmentCalendar",
                "DisplayOfSearchedActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 'Drag And Drop' The Activity On Current Day.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="activityBehavioralModeEnum">This is Activity Behavioral Type Enum.</param>
        [When(@"I 'Drag and Drop' the ""(.*)"" activity of behavioral mode ""(.*)"" on current day")]
        public void DragAndDropTheActivityOnCurrentDay(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum activityBehavioralModeEnum)
        {
            //'Drag And Drop' The Activity On Current Day
            Logger.LogMethodEntry("AssignmentCalendar",
                "DragAndDropTheActivityOnCurrentDay",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity =
                Activity.Get(activityTypeEnum, activityBehavioralModeEnum);
            //Drag and Drop the Activity
            new CalendarHEDDefaultUXPage().DragAndDropActivity(activity.Name);
            Logger.LogMethodExit("AssignmentCalendar",
                "DragAndDropTheActivityOnCurrentDay",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Assigned Activity On Current Day.
        /// </summary> 
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="activityBehavioralModeEnum">This is Activity Behavioral Type Enum.</param>
        [Then(@"I should see the ""(.*)"" activity of behavioral mode ""(.*)"" assigned by 'Drag and Drop' in day view")]
        public void DisplayOfAssignedActivityInDayView(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum activityBehavioralModeEnum)
        {
            //Display Of Assigned Activity On Current Day
            Logger.LogMethodEntry("AssignmentCalendar",
                "DisplayOfAssignedActivityInDayView",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, activityBehavioralModeEnum);
            //Assert the Assigned Activity            
            Logger.LogAssertion("VerifyActivityAssigned",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(new CalendarHEDDefaultUXPage().
                    GetAssignedActivityNameOnCurrentDay(activity.Name), activity.Name));
            Logger.LogMethodExit("AssignmentCalendar",
                "DisplayOfAssignedActivityInDayView",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Assigned Content Count.
        /// </summary>
        /// <param name="assignedContentCountMessage">This is Count Message Of Assigned Content.</param>
        [Then(@"I should see the message ""(.*)"" in day view")]
        public void VerifyAssignedContentCount(string assignedContentCountMessage)
        {
            //Verify Assigned Content Count
            Logger.LogMethodEntry("AssignmentCalendar", "VerifyAssignedContentCount",
                base.isTakeScreenShotDuringEntryExit);
            //Enter Inside Day View
            new CalendarHEDDefaultUXPage().EnterTheDayViewForAssignedActivity();
            //Verify Assign Count Message
            Logger.LogAssertion("VerifyAssignCountMessage",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
               Assert.AreEqual(assignedContentCountMessage,
               new CalendarHEDDefaultUXPage().getAssignedCountwithText()));
            Logger.LogMethodExit("AssignmentCalendar", "VerifyAssignedContentCount",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Status Of Assigned Content In Status Column.
        /// </summary>
        [Then(@"I should see the Status of the assigned content in status column")]
        public void VerifyTheStatusOfAssignedContentInStatusColumn()
        {
            //Verify The Status Of Assigned Content In Status Column
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyTheStatusOfAssignedContentInStatusColumn",
               base.isTakeScreenShotDuringEntryExit);
            //Assert the Display Of status of assigned content
            Logger.LogAssertion("VerifyTheStatusOfAssignedContent",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new CalendarHEDDefaultUXPage().IsActivityDueDateStatusPresent()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyTheStatusOfAssignedContentInStatusColumn",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Calendar Icon
        /// </summary>
        [When(@"I click on the calendar icon")]
        public void ClickOnCalendarIcon()
        {
            //Click On Calendar Icon
            Logger.LogMethodEntry("AssignmentCalendar",
                "ClickOnCalendarIcon",
               base.isTakeScreenShotDuringEntryExit);
            //Click On Calendar Icon
            new CalendarHEDDefaultUXPage().ClickOnCalendarIcon();
            Logger.LogMethodExit("AssignmentCalendar",
                "ClickOnCalendarIcon",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Option 'Set Scheduling Options' Of Content.
        /// </summary>
        [When(@"I select the cmenu option 'Set Scheduling Options' of the content")]
        public void SelectSetSchedulingOptionsCmenuOfContent()
        {
            //Select Cmenu Option 'Set Scheduling Options' Of Content
            Logger.LogMethodEntry("AssignmentCalendar",
                "SelectSetSchedulingOptionsCmenuOfContent",
               base.isTakeScreenShotDuringEntryExit);
            //Select Cmenu Option 'Set Scheduling Options' Of Content
            new CalendarHEDDefaultUXPage().SelectSetSchedulingOptionsCmenu();
            Logger.LogMethodExit("AssignmentCalendar",
                "SelectSetSchedulingOptionsCmenuOfContent",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Due Date Of Assigned Content.
        /// </summary>
        [Then(@"I should see the due date to which content is assigned in 'Assign' frame")]
        public void VerifyTheDueDateOfAssignedContent()
        {
            //Verify The Due Date Of Assigned Content
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyTheDueDateOfAssignedContent",
               base.isTakeScreenShotDuringEntryExit);
            //Current Date
            string currentDate = DateTime.Now.ToString(AssignmentCalendarResource.
                AssignmentCalendar_Resource_Date_Format);
            //Assert the Display Of Due Date to Which Content is Assigned
            Logger.LogAssertion("VerifyTheDisplayOfDueDate",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(currentDate,
                    new AssignContentPage().GetDueDateOfAssignedContent()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyTheDueDateOfAssignedContent",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Option In View By Dropdown.
        /// </summary>
        /// <param name="dropdownOption">This is Dropdown option.</param>
        [When(@"I select ""(.*)"" option in 'View By' dropdown")]
        public void SelectOptionInViewByDropdown(string dropdownOption)
        {
            //Select Option In View By Dropdown
            Logger.LogMethodEntry("AssignmentCalendar", "SelectOptionInViewByDropdown",
               base.isTakeScreenShotDuringEntryExit);
            //Select Option In 'View By' Dropdown
            new CalendarDefaultUXPage().SelectViewByDropdownOption(dropdownOption);
            Logger.LogMethodExit("AssignmentCalendar", "SelectOptionInViewByDropdown",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Contents Order In The Content Frame.
        /// </summary>
        [Then(@"I should see contents in the content frame which are created in course")]
        public void VerifyContentsOrderInTheContentFrame()
        {
            //Verify Contents Order In The Content Frame
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyContentsOrderInTheContentFrame",
               base.isTakeScreenShotDuringEntryExit);
            //Verify Contents Order In The Content Frame
            Logger.LogAssertion("VerifyContentsInContentFrame",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(new CalendarDefaultUXPage().GetContentsOrderInContentFrame(),
                    new CourseContentUXPage().GetContentOrderInMyCourse()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyContentsOrderInTheContentFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The ContentType From ShowDropdown.
        /// </summary>
        /// <param name="showContentType">This is Show Items from dropdown.</param>
        [When(@"I select the ""(.*)"" from show dropdown")]
        public void SelectTheContentTypeFromShowDropdown(string showContentType)
        {
            //Select The ContentType From ShowDropdown
            Logger.LogMethodEntry("AssignmentCalendar",
                "SelectTheContentTypeFromShowDropdown",
               base.isTakeScreenShotDuringEntryExit);
            //Select The ContentType From ShowDropdown
            new CalendarHEDDefaultUXPage().SelectTheContentTypeFromShowDropdown((
                CalendarHEDDefaultUXPage.ShowDropdownTypeEnum)Enum.Parse
                (typeof(CalendarHEDDefaultUXPage.ShowDropdownTypeEnum),
                showContentType));
            Logger.LogMethodExit("AssignmentCalendar",
                "SelectTheContentTypeFromShowDropdown",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Contents In The Calendar Frame.
        /// </summary>
        [Then(@"I should see the asset contents in caledar frame")]
        public void VerifyTheContentsInCaledarFrame()
        {
            //Verify Contents In The Calendar Frame
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyTheContentsInCaledarFrame",
               base.isTakeScreenShotDuringEntryExit);
            //Verify Contents Order In The Content Frame
            Logger.LogAssertion("VerifyContentsInContentFrame",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(new CalendarDefaultUXPage().
                                  GetContentsOrderInContentFrame(),
                    new CourseContentUXPage().GetContentOrderInMyCourse()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyTheContentsInCaledarFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Assigned Contents In The Calendar Frame.
        /// </summary>
        [Then(@"I should see the  assigned asset contents in caledar frame")]
        public void VerifyTheAssignedContentsInCaledarFrame()
        {
            //Verify The Assigned Contents In The Calendar Frame
            Logger.LogMethodEntry("AssignmentCalendar",
                  "VerifyTheAssignedContentsInCaledarFrame",
                           base.isTakeScreenShotDuringEntryExit);
            //Fetch the dat from memory
            Activity activity = Activity.Get(
                Activity.ActivityTypeEnum.SIMStudyPlan2010,
                Activity.ActivityBehavioralModesEnum.SkillBased);
            //Verify Contents Order In The Content Frame
            Logger.LogAssertion("VerifyContentsInContentFrame",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(activity.Name, new CalendarDefaultUXPage().
                                  GetAssetNameInCalendar(activity.Name)));
            Logger.LogMethodExit("AssignmentCalendar",
                  "VerifyTheAssignedContentsInCaledarFrame",
                           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Instructor Graded Contents In CaledarFrame.
        /// </summary>
        [Then(@"I should see the Instructor Graded contents in caledar frame")]
        public void VerifyTheInstructorGradedContentsInCaledarFrame()
        {
            // Verify The Instructor Graded Contents In CaledarFrame
            Logger.LogMethodEntry("AssignmentCalendar",
                  "VerifyTheInstructorGradedContentsInCaledarFrame",
                           base.isTakeScreenShotDuringEntryExit);
            //Fetch the dat from memory
            Activity activity = Activity.Get(
                Activity.ActivityTypeEnum.HomeWork);
            //Verify Contents Order In The Content Frame
            Logger.LogAssertion("VerifyContentsInContentFrame",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(activity.Name, new CalendarDefaultUXPage().
                                  GetAssetNameInCalendar(activity.Name)));
            Logger.LogMethodExit("AssignmentCalendar",
                  "VerifyTheInstructorGradedContentsInCaledarFrame",
                           base.isTakeScreenShotDuringEntryExit);
        }
    }
}
