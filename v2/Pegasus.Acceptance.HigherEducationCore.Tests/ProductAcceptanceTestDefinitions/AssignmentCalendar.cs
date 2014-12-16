using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace Pegasus.Acceptance.HigherEducation.WL.Tests.
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
        /// Search the Activity.
        /// </summary>
      ///<param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I search the ""(.*)""")]
        public void SearchTheActivity(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Search the Activity
            Logger.LogMethodEntry("AssignmentCalendar", "SearchTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Search the Activity            
            new CalendarHedDefaultUxPage().SearchTheActivity(activity.Name);
            Logger.LogMethodExit("AssignmentCalendar", "SearchTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Searched Activity.
        /// </summary>
        ///<param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should see the searched ""(.*)""")]
        public void DisplayOfSearchedActivity(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Display Of Searched Activity
            Logger.LogMethodEntry("AssignmentCalendar",
                "DisplayOfSearchedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert the Searched Activity            
            Logger.LogAssertion("VerifySearchedActivity",
                ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.AreEqual(activity.Name,
                    new CalendarHedDefaultUxPage().
                GetSearchedActivityName()));
            Logger.LogMethodExit("AssignmentCalendar",
                "DisplayOfSearchedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 'Drag And Drop' The Activity On Current Day.
        /// </summary>
        ///<param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I 'Drag and Drop' the ""(.*)"" on current day")]
        public void DragAndDropTheActivityOnCurrentDay(
           Activity.ActivityTypeEnum activityTypeEnum)
        {
            //'Drag And Drop' The Activity On Current Day
            Logger.LogMethodEntry("AssignmentCalendar",
                "DragAndDropTheActivityOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Drag and Drop the Activity
            new CalendarHedDefaultUxPage().DragAndDropActivity(activity.Name);
            Logger.LogMethodExit("AssignmentCalendar",
                "DragAndDropTheActivityOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Assigned Activity On Current Day.
        /// </summary>
        ///<param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should see the ""(.*)"" assigned by 'Drag and Drop'")]
        public void DisplayOfAssignedActivity(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Display Of Assigned Activity On Current Day
            Logger.LogMethodEntry("AssignmentCalendar", "DisplayOfAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert the Assigned Activity            
            Logger.LogAssertion("VerifyActivityAssigned", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(new CalendarHedDefaultUxPage().
                    GetAssignedActivityNameOnCurrentDay(activity.Name), activity.Name));
            Logger.LogMethodExit("AssignmentCalendar", "DisplayOfAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the Activity.
        /// </summary>
        [When(@"I search another Activity")]
        public void SearchAnotherActivity()
        {
            //Search the Activity
            Logger.LogMethodEntry("AssignmentCalendar",
                "SearchAnotherActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Search the Activity
            new CalendarHedDefaultUxPage().SearchTheActivity(
                AssignmentCalendarResource.
                AssignmentCalendar_Activity2_Name);
            Logger.LogMethodExit("AssignmentCalendar",
                "SearchAnotherActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign Activity From 'Assignment Properties' Cmenu Options.
        /// </summary>                
        [When(@"I Assign the Activity by the Activity Cmenu options")]
        public void AssignActivityFromCmenuOptions()
        {
            //Assign Activity From 'Assignment Properties' Cmenu Options
            Logger.LogMethodEntry("AssignmentCalendar",
                "AssignActivityFromCmenuOptions",
                base.IsTakeScreenShotDuringEntryExit);
            //Assign The Activity
            new CalendarHedDefaultUxPage().AssignActivityThroughCmenuOption();
            Logger.LogMethodExit("AssignmentCalendar",
                "AssignActivityFromCmenuOptions",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Activity Assigned By Cmenu Option
        /// </summary>
        ///<param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should see the ""(.*)"" assigned by Cmenu options")]
        public void DisplayOfActivityAssignedByCmenuOption(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Display Of Assigned Activity
            Logger.LogMethodEntry("AssignmentCalendar",
                "DisplayOfActivityAssignedByCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert the Assigned Activity
            Logger.LogAssertion("VerifyAssignedActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new CalendarHedDefaultUxPage().
                    GetAssignedActivityNameOnCurrentDay(activity.Name)));
            Logger.LogMethodExit("AssignmentCalendar",
                "DisplayOfActivityAssignedByCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Multiple Assets.
        /// </summary>
        [When(@"I drag and drop 'Multiple Assets'")]
        public void SelectTheAssets()
        {
            //Select Multiple Assets
            Logger.LogMethodEntry("AssignmentCalendar",
                "SelectTheAssets",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Multiple Assets
            new CalendarHedDefaultUxPage().
                SelectMultipleAssetsToDragAndDrop();
            Logger.LogMethodExit("AssignmentCalendar",
                "SelectTheAssets",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Status Of Activity.
        /// </summary>
        [Then(@"I should see the status of the activity")]
        public void VerifyCalendarStatusOfTheActivity()
        {
            //Verify the Status Of Activity
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyCalendarStatusOfTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify Calendar Status Of Activity
            Logger.LogAssertion("VerifyCalendarStatusOfActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new CalendarHedDefaultUxPage().
                    IsActivityDueDateStatusPresent()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyCalendarStatusOfTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Option Assignment properties of Activity.
        /// </summary>
        [When(@"I select the cmenu option 'Assignment Properties' of activity")]
        public void SelectCmenuOptionAssignmentPropertiesOfActivity()
        {
            //Select Cmenu Option Assignment properties of Activity
            Logger.LogMethodEntry("AssignmentCalendar",
                "SelectCmenuOptionAssignmentPropertiesOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Cmenu Option Assignment Properties
            new CalendarHedDefaultUxPage().ClickOnAssignmentProperties();
            Logger.LogMethodExit("AssignmentCalendar",
                "SelectCmenuOptionAssignmentPropertiesOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Due Date Of Activity.
        /// </summary>
        [Then(@"I should see the due date of activity")]
        public void VerifyTheDueDateOfActivity()
        {
            //Verify the Due Date Of Activity
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyTheDueDateOfActivity",
               base.IsTakeScreenShotDuringEntryExit);
            //Verify Due Date Of Activity
            Logger.LogAssertion("VerifyDueDateOfActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(new CalendarHedDefaultUxPage().
                    GetMyProfileProfileDate(),
                    new AssignContentPage().getDueDateOfActivity()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyTheDueDateOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Calendar Icon.
        /// </summary>
        [When(@"I click on calendar icon")]
        public void ClickOnCalendarIcon()
        {
            //Click On Calendar Icon
            Logger.LogMethodEntry("AssignmentCalendar",
                "ClickOnCalendarIcon",
               base.IsTakeScreenShotDuringEntryExit);
            //Click On Calendar Icon
            new CourseCalendarPage().ClickOnCalendarIcon();
            Logger.LogMethodExit("AssignmentCalendar",
                "ClickOnCalendarIcon",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Assigned Activity .
        /// </summary>
        /// <param name="activityName">This is Activity Type Enum.</param>
        [Then(@"I should see the assigned asset ""(.*)""")]
        public void VerifyTheAssignedActivity(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify The Assigned Activity
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyTheAssignedActivity",
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Verify the Assigned Activity 
            Logger.LogAssertion("VerifyTheAssignedActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new CourseCalendarPage().GetActivityName(
                    AssignmentCalendarResource.
                AssignmentCalendar_CourseMaterials_Window_Name, activity.Name)));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyTheAssignedActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Option In Dropdown.
        /// </summary>
        /// <param name="viewByDropdownOption">This is View By Dropdown Option.</param>
        /// <param name="showDropdownOption">This is Show Dropdown Option.</param>
        [When(@"I select ""(.*)"" option in 'VIEW BY' dropdown and ""(.*)"" option in 'SHOW' dropdown")]
        public void SelectOptionInDropdown(
            string viewByDropdownOption, string showDropdownOption)
        {
            //Select Option In Dropdown
            Logger.LogMethodEntry("AssignmentCalendar",
                "SelectOptionInDropdown",
               base.IsTakeScreenShotDuringEntryExit);
            CalendarHedDefaultUxPage calendarHEDDefaultUXPage =
                new CalendarHedDefaultUxPage();
            //Select Option In 'View By' Dropdown
            calendarHEDDefaultUXPage.
                SelectOptionInViewByDropdown(viewByDropdownOption);
            //Select Option In 'Show' Dropdown
            calendarHEDDefaultUXPage.
                SelectOptionInShowDropDown(showDropdownOption);
            Logger.LogMethodExit("AssignmentCalendar",
                "SelectOptionInDropdown",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Content Type.
        /// </summary>
        /// <param name="contentType">This is Content Type.</param>
        [When(@"I select ""(.*)"" content type")]
        public void SelectContentType(string contentType)
        {
            //Select Content Type
            Logger.LogMethodEntry("AssignmentCalendar", "SelectContentType",
               base.IsTakeScreenShotDuringEntryExit);
            //Select The Content Type
            new CalendarHedDefaultUxPage().SelectTheContentType(contentType);
            Logger.LogMethodExit("AssignmentCalendar", "SelectContentType",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Content.
        /// </summary>
        /// <param name="contentName">This is Activity Type Enum.</param>
        [When(@"I search ""(.*)"" content")]
        public void SearchContent(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Search Content
            Logger.LogMethodEntry("AssignmentCalendar", "SearchContent",
                base.IsTakeScreenShotDuringEntryExit);
            CalendarHedDefaultUxPage calendarHEDDefaultUXPage = new CalendarHedDefaultUxPage();
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select the Calendar Window
            calendarHEDDefaultUXPage.SelectCalendarWindow();
            //Search Content
            calendarHEDDefaultUXPage.SearchContent(activity.Name);
            Logger.LogMethodExit("AssignmentCalendar", "SearchContent",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Day View For Assigned Content In Calendar.
        /// </summary>
        [When(@"I enter day view for assigned content in calendar")]
        public void EnterDayViewForAssignedContentInCalendar()
        {
            //Enter Day View For Assigned Content In Calendar
            Logger.LogMethodEntry("AssignmentCalendar",
                "EnterDayViewForAssignedContentInCalendar",
                base.IsTakeScreenShotDuringEntryExit);
            //Enter Day View For Assigned Content In Calendar
            new CalendarHedDefaultUxPage().EnterTheDayViewForAssignedActivity();
            Logger.LogMethodExit("AssignmentCalendar",
                "EnterDayViewForAssignedContentInCalendar",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Order Of Assigned Contents In Calendar.
        /// </summary>
        [Then(@"I should see the order of assigned contents in calendar same as in course content")]
        public void VerifyTheOrderOfAssignedContentsInCalendar()
        {
            //Verify The Order Of Assigned Contents In Calendar
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyTheOrderOfAssignedContentsInCalendar",
                base.IsTakeScreenShotDuringEntryExit);
            CalendarHedDefaultUxPage calendarHEDDefaultUXPage =
                new CalendarHedDefaultUxPage();
            //Get Contents Order In Course Content
            string getContentsOrder = calendarHEDDefaultUXPage.
                GetContentsOrderInCourseContent();
            //Verify The Order Of Assigned Contents In Calendar
            Logger.LogAssertion("VerifyTheOrderOfAssignedContentsInCalendar",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(getContentsOrder,
                    calendarHEDDefaultUXPage.GetAssignedContentsOrderInCalendar()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyTheOrderOfAssignedContentsInCalendar",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Set Availability Date Range Option.
        /// </summary>
        [When(@"I select the 'Set availability date range' option")]
        public void SelectSetAvailabilityDateRangeOption()
        {
            //Select Set Availability Date Range Option
            Logger.LogMethodEntry("AssignmentCalendar",
                "SelectSetAvailabilityDateRangeOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Set Avalability Date Range Radiobutton
            new AssignContentPage().SelectSetAvalabilityDateRangeRadiobutton();
            Logger.LogMethodExit("AssignmentCalendar",
                "SelectSetAvailabilityDateRangeOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display Of Fields In Restrict Availability Frame.
        /// </summary>
        [Then(@"I should see all the fields in 'Restrict Availability' frame")]
        public void VerifyDisplayOfFieldsInRestrictAvailabilityFrame()
        {
            //Verify The Display Of Fields In Restrict Availability Frame
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyDisplayOfFieldsInRestrictAvailabilityFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify The Display Of Start Date And End Date
            Logger.LogAssertion("VerifyTheDisplayOfStartDateAndEndDate",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new AssignContentPage().IsStartEndDateFieldPresent()));
            //Verify The Display Of Time Zone Tooltip
            Logger.LogAssertion("VerifyTheDisplayOfTimezoneTooltip",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(AssignmentCalendarResource.
                    AssignmentCalendar_TimeZone_Value,
                    new AssignContentPage().GetTimezone()));
            //Verify The Display Of Start End Date Text
            Logger.LogAssertion("VerifyTheDisplayOfStartEndDateText",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(AssignmentCalendarResource.
                    AssignmentCalendar_StartEnd_Date_Text,
                    new AssignContentPage().GetStartEndDateText()));
            //Verify The Display Of Checkboxes
            Logger.LogAssertion("VerifyTheDisplayOfCheckboxes",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new AssignContentPage().
                    IsCheckboxesPresentInRestrictAvailabilityFrame()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyDisplayOfFieldsInRestrictAvailabilityFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Not Assigned' Option.
        /// </summary>
        [When(@"I select the 'Not Assigned' option")]
        public void SelectNotAssignedOption()
        {
            //Select 'Not Assigned' Option
            Logger.LogMethodEntry("AssignmentCalendar",
                "SelectNotAssignedOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Select 'Not Assigned' Radio button
            new AssignContentPage().SelectNotAssignedRadiobutton();
            Logger.LogMethodExit("AssignmentCalendar",
                "SelectNotAssignedOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Disabled Status Of 'Set End Date As Due Date' Option.
        /// </summary>
        [Then(@"I should see the 'Set End Date as Due Date' option in disabled state")]
        public void VerifyDisabledStatusOfSetEndDateAsDueDateOption()
        {
            //Verify Disabled Status Of 'Set End Date As Due Date' Option
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyDisabledStatusOfSetEndDateAsDueDateOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify Disabled Status Of 'Set End Date As Due Date' Option
            Logger.LogAssertion("VerifyDisabled StatusOfSetEndDateAsDueDateOption",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsFalse(new AssignContentPage().
                    IsStatusOfSetEndDateAsDueDateOptionDisabled()));
            Logger.LogMethodExit("AssignmentCalendar",
               "VerifyDisabledStatusOfSetEndDateAsDueDateOption",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button In Assign Window.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        [When(@"I click on ""(.*)"" button in assign window")]
        public void ClickOnTheButtonInAssignWindow(string buttonName)
        {
            //Click On Button In Assign Window
            Logger.LogMethodEntry("AssignmentCalendar",
                "ClickOnTheButtonInAssignWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Button In Assign Window
            new AssignContentPage().ClickOnButtonInAssignWindow(buttonName);
            Logger.LogMethodExit("AssignmentCalendar",
               "ClickOnTheButtonInAssignWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Content In Calendar.
        /// </summary>
        /// <param name="contentName">This is Content Name.</param>
        /// <param name="status">This is Content Status.</param>
        [When(@"I select ""(.*)"" content which is ""(.*)""")]
        public void SelectTheContentInCalendar(string contentName,string status)
        {
            //Select The Content In Calendar
            Logger.LogMethodEntry("AssignmentCalendar",
                "SelectTheContentInCalendar",
                base.IsTakeScreenShotDuringEntryExit);
            //Select The Content In Calendar
            new CalendarHedDefaultUxPage().SelectContentInCalendar(contentName, status);
            Logger.LogMethodExit("AssignmentCalendar",
               "SelectTheContentInCalendar",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button In Assignment Calendar.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        [When(@"I click on ""(.*)"" button in Calendar")]
        public void ClickOnButtonInAssignmentCalendar(string buttonName)
        {
            //Click On Button In Assignment Calendar
            Logger.LogMethodEntry("AssignmentCalendar",
                "ClickOnButtonInAssignmentCalendar",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Button In Calendar
            new CalendarHedDefaultUxPage().ClickOnButtonInCalendar(buttonName);
            Logger.LogMethodExit("AssignmentCalendar",
              "ClickOnButtonInAssignmentCalendar",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Content Is In Assigned State.
        /// </summary>
        /// <param name="contentName">This is Content Name.</param>
        /// <param name="status">This is Content Status.</param>
        [Then(@"I should see ""(.*)"" content is in ""(.*)"" state")]
        public void VerifyContentIsInAssignedState(string contentName,string status)
        {
            //Verify Content Is In Assigned State
            Logger.LogMethodEntry("AssignmentCalendar",
               "VerifyContentIsInAssignedState",
               base.IsTakeScreenShotDuringEntryExit);
            //Asset To Verify Content Is In Assigned State
            Logger.LogAssertion("VerifyContentIsInAssignedState",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(status,new CalendarHedDefaultUxPage().
                    GetContentStatus(contentName, status)));
            Logger.LogMethodExit("AssignmentCalendar",
              "VerifyContentIsInAssignedState",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Button Is In Disabled State.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        [Then(@"I should see the '(.*)' button is in disabled state")]
        public void VerifyTheButtonIsInDisabledState(string buttonName)
        {
            //Verify The Button Is In Disabled State
            Logger.LogMethodEntry("AssignmentCalendar",
               "VerifyTheButtonIsInDisabledState",
               base.IsTakeScreenShotDuringEntryExit);
            //Asset To Verify Assign/Unassign Button Is In Disabled State
            Logger.LogAssertion("VerifyAssignUnassignButtonIsInDisabledState",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new CalendarHedDefaultUxPage().
                    IsAssignUnassignButtonDisabled()));            
            Logger.LogMethodExit("AssignmentCalendar",
              "VerifyTheButtonIsInDisabledState",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify 'All Students' And 'Selected Student' Options
        /// </summary>
        [Then(@"I should see 'All Students' and 'Selected Students' options in 'Make item available to' frame")]
        public void VerifyAllStudentsAndSelectedStudentOptions()
        {
            //Verify 'All Students' And 'Selected Student' Options
            Logger.LogMethodEntry("AssignmentCalendar",
               "VerifyAllStudentsAndSelectedStudentOptions",
               base.IsTakeScreenShotDuringEntryExit);
            //Asset To Verify Display Of 'All Students' And 'Selected Student' Options
            Logger.LogAssertion("VerifyAllStudentsAndSelectedStudentOptions",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new AssignContentPage().
                    IsAllStudentsSelectedStudentsOptionsPresent()));            
            Logger.LogMethodExit("AssignmentCalendar",
              "VerifyAllStudentsAndSelectedStudentOptions",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Selected Students' Option.
        /// </summary>
        [When(@"I select 'Selected Students' option")]
        public void SelectTheSelectedStudentsOption()
        {
            //Select 'Selected Students' Option
            Logger.LogMethodEntry("AssignmentCalendar",
               "SelectTheSelectedStudentsOption",
               base.IsTakeScreenShotDuringEntryExit);
            //Select 'Selected Students' Option
            new AssignContentPage().SelectSelectedStudentsOption();
            Logger.LogMethodExit("AssignmentCalendar",
              "SelectTheSelectedStudentsOption",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Expected Text In Assign Window.
        /// </summary>
        /// <param name="textToVerify">This Is Expected Text.</param>
        [Then(@"I should see the text ""(.*)"" in 'Make item available to' frame")]
        public void VerifyTheTextInFrame(string expectedText)
        {
            //Verify Expected Text In Assign Window
            Logger.LogMethodEntry("AssignmentCalendar",
               "VerifyTheTextInFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Asset To Verify Expected Text In Assign Window
            Logger.LogAssertion("VerifyAllStudentsAndSelectedStudentOptions",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedText, new AssignContentPage().
                    GetTextInAssignWindow()));
            Logger.LogMethodExit("AssignmentCalendar",
              "VerifyTheTextInFrame",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Frames In 'Make Item Available' Frame.
        /// </summary>
        [Then(@"I should see the 'View by' and 'Selected Students' frames")]
        public void VerifyFramesInMakeItemAvailableFrame()
        {
            //Verify Frames In 'Make Item Available' Frame
            Logger.LogMethodEntry("AssignmentCalendar",
               "VerifyFramesInMakeItemAvailableFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Student From Memory
            User user = User.Get(User.UserTypeEnum.CsSmsStudent);
            //Asset To Verify 'View by' Frame
            Logger.LogAssertion("VerifyViewbyFrame",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.Name,
                    new AssignContentPage().GetStudentInViewbyFrame()));
            //Asset To Verify 'Select Students' Frame
            Logger.LogAssertion("VerifySelectStudentsFrame",
                 ScenarioContext.Current.ScenarioInfo.Title,
                 () => Assert.AreEqual(string.Empty, new AssignContentPage().
                     GetContentInSelectStudentsFrame()));
            //Asset To Verify Groups In 'View by' Frame
            Logger.LogAssertion("VerifyGroupsInViewbyFrame",
                 ScenarioContext.Current.ScenarioInfo.Title,
                 () => Assert.AreEqual(AssignmentCalendarResource.
                     AssignmentCalendar_GroupName_Value,
                     new AssignContentPage().GetGroupName()));
            Logger.LogMethodExit("AssignmentCalendar",
              "VerifyFramesInMakeItemAvailableFrame",
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

        [Then(@"I should see the current date highlighted in the calendar frame")]
        public void VerifyCurrentDateInCalendar()
        {
            //Verify if the current date highlighted in the calendar frame
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyTheCurrentDateHighlightedInTheCalendar",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyCurrentDateHighlighted",
                    ScenarioContext.Current.ScenarioInfo.
                       Title, () => Assert.IsTrue(
                     new CalendarHedDefaultUxPage().IsCurrentDateHighlighted()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyTheCurrentDateHighlightedInTheCalendar",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify due date icon is diplayed in assigned date.
        /// </summary>       
        [Then(@"I should see due date icon displayed in current date")]
        public void VerifyDueDateIconDisplayed()
        {
            // Verify due date icon is diplayed in assigned date
            Logger.LogMethodEntry("AssignmentCalendar",
              "VerifyDueDateIconDisplayed",
              base.IsTakeScreenShotDuringEntryExit);
            // Verify due date icon is diplayed in assigned date
            Logger.LogAssertion("VerifyDueDateIconDisplayed",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new CalendarHedDefaultUxPage()
                   .IsActivityDueDateIconPresent()));
            Logger.LogMethodEntry("AssignmentCalendar",
             "VerifyDueDateIconDisplayed",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects the check box of activity.
        /// </summary>
        /// <param name="activityCount">Number of activity for which checkbox to be checked.</param>
        /// <param name="folderName">This is Activity folder name.</param>
        [When(@"I select the check box of any (.*) activities in ""(.*)""")]
        public void SelectCheckBoxOfActivity(
            int activityCount, String folderName)
        {
            Logger.LogMethodEntry("AssignmentCalendar",
                 "SelectCheckBoxOfActivity",
                          base.IsTakeScreenShotDuringEntryExit);
            var calendarHedDefaultUxPage =
                new CalendarHedDefaultUxPage();
            String activityId = calendarHedDefaultUxPage.GetAssetId(folderName);
            calendarHedDefaultUxPage.SelectCheckBoxOfActivity(activityCount,
                activityId);
            Logger.LogMethodExit("AssignmentCalendar",
                  "SelectCheckBoxOfActivity",
                           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Assign/UnAssign link button state.
        /// </summary>
        [Then(@"I should see Assign/Unassign link in active state on the content frame header")]
        public void VerifyAssignUnassignLinkState()
        {
            // Verify Assign/UnAssign link button state
            Logger.LogMethodEntry("AssignmentCalendar",
                 "VerifyAssignUnassignLinkState",
                          base.IsTakeScreenShotDuringEntryExit);
            // Verify Assign/UnAssign link button state
            Assert.IsTrue(new CalendarHedDefaultUxPage()
                .IsAssignedUnAssignedButtonEnabled());
            Logger.LogMethodExit("AssignmentCalendar",
                  "VerifyAssignUnassignLinkState",
                           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on Assign/Unassign link button.
        /// </summary>
        [When(@"I click on assign/Unassign link displayed in content frame header")]
        public void ClickOnAssignUnassignLink()
        {
            // Clicks on Assign/Unassign link button
            Logger.LogMethodEntry("AssignmentCalendar",
                 "ClickOnAssignUnassignLink",
                          base.IsTakeScreenShotDuringEntryExit);
            // Clicks on Assign/Unassign link button
            new CalendarHedDefaultUxPage()
                .ClickOnAssignUnassignButton();
            Logger.LogMethodExit("AssignmentCalendar",
                  "ClickOnAssignUnassignLink",
                           base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify Check mark in assigned status column.
        /// </summary>
        [Then(@"I should see the check mark in assigned status column next to the assets")]
        public void VerifyCheckMarkInAssignedStatusColumn()
        {
            // Verify Check mark in assigned status column
            Logger.LogMethodEntry("AssignmentCalendar",
                 "VerifyCheckMarkInAssignedStatusColumn",
                          base.IsTakeScreenShotDuringEntryExit);
            List<Activity> assignedActivityList =
                Activity.Get(a => a.IsAssigned == true);
            List<Activity> unAssignedActivityList =
                Activity.Get(a => a.IsAssigned == false);
            CalendarHedDefaultUxPage calendarHEDDefaultUXPage =
                new CalendarHedDefaultUxPage();
            // Verify Check mark in assigned status column
            foreach (Activity unAssignedActivity in unAssignedActivityList)
            {
                Assert.IsTrue(calendarHEDDefaultUXPage
                    .IsAssetAssigned(unAssignedActivity.ActivityId));
                unAssignedActivity.IsAssigned = true;
                unAssignedActivity.UpdateActivityInMemory(unAssignedActivity);
            }
            Logger.LogMethodExit("AssignmentCalendar",
                  "VerifyCheckMarkInAssignedStatusColumn",
                           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Drag and Drop selected  assets to current date.
        /// </summary>
        [When(@"I should drag and drop multiple assets along with ""(.*)"" to the current date")]
        public void DragAndDropMultipleAssetsToCurrentDate(string activityName)
        {
            // Drag and drop multiple assets to current date
            Logger.LogMethodEntry("AssignmentCalendar",
               "DragAndDropMultipleAssetsToCurrentDate",
               base.IsTakeScreenShotDuringEntryExit);
            // Drag and drop multiple assets to current date
            new CalendarHedDefaultUxPage().DragAndDropMultipleActivities(activityName);
            Logger.LogMethodExit("AssignmentCalendar",
             "DragAndDropMultipleAssetsToCurrentDate",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Current date.
        /// </summary>
        [When(@"I select the current date")]
        public void SelectCurrentDate()
        {
            //Select Current Date
            Logger.LogMethodEntry("AssignmentCalendar", "SelectCurrentDate",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Current Date
            new CalendarHedDefaultUxPage().SelectCurrentDateFromCalendar();
            Logger.LogMethodExit("AssignmentCalendar", "SelectCurrentDate",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the assigned content in the day view.
        /// </summary>     
        [Then(@"I should see the assigned content ""(.*)"" in the day view")]
        public void VerifyAssignedContent(string assetName)
        {
            //Verify the assigned content in the day view
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyAssignedContent",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyAssignedContentText",
                ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.AreEqual(assetName,
                    new CalendarHedDefaultUxPage().GetAssignAssetText(assetName)));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyAssignedContent",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assigning the asset with duedate and scheduling with start and end date
        /// </summary>
        [When(@"I assign and schedule the asset and save")]
        public void AssignAndScheduleTheAssetAndSave()
        {
            Logger.LogMethodEntry("CourseContent", "AssignAndScheduleTheAssetAndSave",
               base.IsTakeScreenShotDuringEntryExit);
            AssignContentPage assignContent = new AssignContentPage();
            //Selecting assign radio button
            assignContent.SelectAssignedRadiobutton();
            //Setting due date
            assignContent.GetAndFillDueDate();
            //Setting the start date and end date
            assignContent.SetStartAndEndDate();
            Logger.LogMethodExit("CourseContent", "AssignAndScheduleTheAssetAndSave",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the cmenu option of the asset.
        /// </summary>
        /// <param name="cmenuOption">This is the cmenu option.</param>
        /// <param name="assetName">This is a asset name.</param>
        [When(@"I select cmenu ""(.*)"" of activity ""(.*)""")]
        public void SelectCmenuOfActivity(string cmenuOption, string assetName)
        {
            // Click on the cmenu option of the asset
            Logger.LogMethodEntry("AssignmentCalendar",
              "SelectCmenuOfActivity",
              base.IsTakeScreenShotDuringEntryExit);
            //click on cmenu option
            new CalendarHedDefaultUxPage().SelectActivityCmenu
                (cmenuOption, assetName);           
            Logger.LogMethodExit("AssignmentCalendar",
                "SelectCmenuOfActivity",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign the asset to the current date,set start and end date,mark notification and save.
        /// </summary>
        [When(@"I assign the asset for current date in the properties popup")]
        public void AssignTheAssetforStartDateIcon()
        {
            Logger.LogMethodEntry("AssignmentCalendar",
               "AssignTheAsset",
               base.IsTakeScreenShotDuringEntryExit);
            base.SelectWindow("Assign");
            AssignContentPage assignContentPage = new AssignContentPage();
            //Select 'Assigned' radiobutton
            assignContentPage.SelectAssignRadiobuttonInAssignWindow();
            //Select current date
            assignContentPage.SelectCurrentDateInAssignWindow();
            //Set start and end date
            assignContentPage.SetStartAndEndDateAssignWindow();
            //Check availability notification
            assignContentPage.CheckAvailabilityNotification();
            //Save the properties
            assignContentPage.SaveProperties();
            Logger.LogMethodExit("AssignmentCalendar",
                "AssignTheAsset",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifying Start Date Flag is Present.
        /// </summary>
        [Then(@"I should see the startdate Icon in calendar frame")]
        public void VerifyTheStartdateIconInCalendarFrame()
        {
            // Verifying Start Date Flag is Present
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyTheStartdateIconInCalendarFrame",
                                base.IsTakeScreenShotDuringEntryExit);
            //Verify Start Date Flag Presence by Assert.
            Logger.LogAssertion("VerifyingStartDateFlag",
                ScenarioContext.Current.ScenarioInfo.Title,
                        () => Assert.IsTrue(new CalendarHedDefaultUxPage().
                            IsStartDateFlagDisplayed()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyTheStartdateIconInCalendarFrame",
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
