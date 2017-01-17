using Pearson.Pegasus.TestAutomation.Frameworks;
using System;
using System.Collections.Generic;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public class AssignmentCalendar : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(AssignmentCalendar));


        /// <summary>
        /// Click On View Advanced Calendar
        /// </summary>
        [When(@"I select 'View Advanced calendar' option in calendar")]
        public void ClickViewAdvancedCalendar()
        {
            //Click On View Advanced Calendar
            Logger.LogMethodEntry("AssignmentCalendar", "ClickViewAdvancedCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on View Advanced Calendar
            new CalendarHedDefaultUxPage().ClickOnViewAdvancedCalendar();
            Logger.LogMethodExit("AssignmentCalendar", "ClickViewAdvancedCalendar",
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
               base.IsTakeScreenShotDuringEntryExit);
            //Verify Assign Course Materials
            Logger.LogAssertion("VerifyAssignCourseMaterials",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(assignCourseMaterialsOption,
                new CalendarHedDefaultUxPage().GetAssignCourseMaterialsText()));
            //Verify DayWeekMonth
            Logger.LogAssertion("VerifyDayWeekMonth",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(dayWeekMonthOption,
                new CalendarHedDefaultUxPage().GetDayWeekMonthText()));
            //Verify AddNote Text
            Logger.LogAssertion("VerifyAddNote", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(addNoteoption, new CalendarHedDefaultUxPage().GetAddNoteText()));
            Logger.LogMethodExit("AssignmentCalendar", "VerifyAddCourseMaterialsAndDayWeekMonth",
               base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
            //Verify Assign Count Message
            Logger.LogAssertion("VerifyAssignCountMessage",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
               Assert.AreEqual(assignCountMessage,
               new CalendarHedDefaultUxPage().GetAssignedCountWithText()));
            //Verify Assign Text Message
            Logger.LogAssertion("VerifyAssignTextMessage",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
               Assert.AreEqual(assignTextMessage,
               new CalendarHedDefaultUxPage().getAssignedTextInCalendarFrame()));
            Logger.LogMethodExit("AssignmentCalendar", "VerifyAssignMessage",
               base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, activityBehavioralModeEnum);
            //Search the Activity            
            new CalendarHedDefaultUxPage().SearchTheActivity(activity.Name);
            Logger.LogMethodExit("AssignmentCalendar", "SearchActivity",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity =
                Activity.Get(activityTypeEnum, activityBehavioralModeEnum);
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
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="activityBehavioralModeEnum">This is Activity Behavioral Type Enum.</param>
        [When(@"I 'Drag and Drop' the ""(.*)"" activity of behavioral mode ""(.*)"" on ""(.*)""")]
        public void WhenITheActivityOfBehavioralModeOn(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum activityBehavioralModeEnum, string dateType)
        {
            //'Drag And Drop' The Activity On Current Day
            Logger.LogMethodEntry("AssignmentCalendar",
                "DragAndDropTheActivityOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity =
                Activity.Get(activityTypeEnum, activityBehavioralModeEnum);
            //Drag and Drop the Activity
            switch(dateType)
            {
                case "Current date":
                    new CalendarHedDefaultUxPage().DragAndDropActivityCurrentDate(activity.Name);
                    break;

                case "Future date":
                    new CalendarHedDefaultUxPage().DragAndDropActivityFutureDate(activity.Name);
                    break;
            }
    
            Logger.LogMethodExit("AssignmentCalendar",
                "DragAndDropTheActivityOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, activityBehavioralModeEnum);
            //Assert the Assigned Activity            
            Logger.LogAssertion("VerifyActivityAssigned",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(new CalendarHedDefaultUxPage().
                    GetAssignedActivityNameOnCurrentDay(activity.Name), activity.Name));
            Logger.LogMethodExit("AssignmentCalendar",
                "DisplayOfAssignedActivityInDayView",
                base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see the ""(.*)"" activity of behavioral mode ""(.*)"" assigned by 'Drag and Drop' in day view of ""(.*)""")]
        public void ValidateDisplayOfAssignedActivityInDayView(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum activityBehavioralModeEnum, string dateType)
        {
            Logger.LogMethodEntry("AssignmentCalendar",
                "DisplayOfAssignedActivityInDayView",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, activityBehavioralModeEnum);

            //Assert the Assigned Activity            
            Logger.LogAssertion("VerifyActivityAssigned",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(new CalendarHedDefaultUxPage().
                    GetAssignedActivityNameBasedOnDay(activity.Name, dateType), activity.Name));
            Logger.LogMethodExit("AssignmentCalendar",
                "DisplayOfAssignedActivityInDayView",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click day view in assignment calender.
        /// </summary>
        /// <param name="dateType">This is date type.</param>
        [When(@"I click on ""(.*)"" in normal calender view")]
        public void ClickOnDayView(string dateType)
        {
            Logger.LogMethodEntry("AssignmentCalendar",
                "ClickOnDayView",
                base.IsTakeScreenShotDuringEntryExit);
            switch(dateType)
            { 
                case "Future date":
                new CalendarHedDefaultUxPage().EnterTheDayViewForAssignedActivityForFutureDate();
                break;
        }
            Logger.LogMethodExit("AssignmentCalendar",
                "ClickOnDayView",
                base.IsTakeScreenShotDuringEntryExit);
        }

        
        public void WhenIClickOnIconInDate(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        /// <summary>
        /// Click Add notes option in calendar view.
        /// </summary>
        /// <param name="optionName">This is option name.</param>
        /// <param name="dateType">This is date type.</param>
        [When(@"I click on ""(.*)"" icon in ""(.*)"" date")]
        public void ClickAddNoteOption(string optionName, string dateType)
        {
            Logger.LogMethodEntry("AssignmentCalendar", "ClickAddNoteOption",base.IsTakeScreenShotDuringEntryExit);
            switch(dateType)
            {
                case "Future date":
                    new CalendarHedDefaultUxPage().ClickOptionInDayView(optionName);
                break;
             }
            Logger.LogMethodExit("AssignmentCalendar", "ClickAddNoteOption", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click OK button in the delete note confirmation popup
        /// </summary>
        [When(@"I click Ok button in confirmation lightbox")]
        public void ClickOkButtonInConfirmationLightbox()
        {
            Logger.LogMethodEntry("AssignmentCalendar", "ClickOkButtonInConfirmationLightbox", base.IsTakeScreenShotDuringEntryExit);
            new CalendarHedDefaultUxPage().ClickOkButton();
            Logger.LogMethodExit("AssignmentCalendar", "ClickOkButtonInConfirmationLightbox", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate the display of wizard 
        /// </summary>
        /// <param name="wizardName"></param>
        [Then(@"I should be displayed with ""(.*)"" wizard")]
        public void ValidateDisplayOfWizard(string wizardName)
        {
            Logger.LogMethodEntry("AssignmentCalendar", "ValidateDisplayOfWizard", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyActivityAssigned",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(new CalendarHedDefaultUxPage().
                    getNotesWizardTitle(), wizardName));
            Logger.LogMethodExit("AssignmentCalendar", "ValidateDisplayOfWizard", base.IsTakeScreenShotDuringEntryExit);
        }

        
        public void WhenINotesAndClickOnButton(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

       
        /// <summary>
        /// Enter notes and click on save and close button
        /// </summary>
     [When(@"I ""(.*)"" notes and click on 'Save and Close' button")]
        public void EnterNotesAndClickOnButton(string noteType)
        {
            Logger.LogMethodEntry("AssignmentCalendar", "EnterNotesAndClickOnButton", base.IsTakeScreenShotDuringEntryExit);
           switch(noteType)
           {
               case "Create":
                new CalendarHedDefaultUxPage().EnterNotes();
                break;

               case "Edit":
                new CalendarHedDefaultUxPage().EditNotes();
                break;
            }
            Logger.LogMethodExit("AssignmentCalendar", "EnterNotesAndClickOnButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of notes created in the day view
        /// </summary>
        [Then(@"I should be displayed with the notes in the day view")]
        public void ValidateDisplayOfNotesInTheDayView()
        {
            Logger.LogMethodEntry("AssignmentCalendar", "ValidateDisplayOfNotesInTheDayView", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyStudentPresent",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new CalendarHedDefaultUxPage().ValidateNotes()));
            Logger.LogMethodExit("TodaysView", "ValidateActivityNameInPastDueSubmittedChannel",
               base.IsTakeScreenShotDuringEntryExit);
            Logger.LogMethodExit("AssignmentCalendar", "ValidateDisplayOfNotesInTheDayView", base.IsTakeScreenShotDuringEntryExit);
        }

        //Then I should be displayed with 'Due date' icon and 'Notes' icon in "Future date"
        [Then(@"I should be displayed with 'Due date' icon and 'Notes' icon in ""(.*)""")]
        public void ValidateDisplayOfIcon(string dateType)
        {
            switch(dateType)
            {
                case "Future date":
                       Logger.LogAssertion("VerifyStudentPresent",
                        ScenarioContext.Current.ScenarioInfo.Title, () =>
                        Assert.IsTrue(new CalendarHedDefaultUxPage().ValidateOptionInAssignmentCalendar()));
                        Logger.LogMethodExit("TodaysView", "ValidateActivityNameInPastDueSubmittedChannel",
                           base.IsTakeScreenShotDuringEntryExit);
                    break;
            }
        }


        /// <summary>
        /// Click view type in the Advance calender
        /// </summary>
        /// <param name="viewType"></param>
        [When(@"I click on ""(.*)"" view in Advance calender")]
        public void SelectViewInAdvanceCalender(string viewType)
        {
            Logger.LogMethodEntry("AssignmentCalendar",
                "SelectViewInAdvanceCalender",
                base.IsTakeScreenShotDuringEntryExit);
            // Select view type from the drop down
            new CalendarHedDefaultUxPage().SelectViewType(viewType);
            Logger.LogMethodEntry("AssignmentCalendar",
                "SelectViewInAdvanceCalender",
                base.IsTakeScreenShotDuringEntryExit);
        }



        [Then(@"I should see the ""(.*)"" activity assigned in ""(.*)"" view of ""(.*)"" in Advance calender")]
        public void ThenIShouldSeeTheActivityAssignedInViewOfInAdvanceCalender(Activity.ActivityTypeEnum activityType, string viewType, string dateType)
        {
            Activity activity = Activity.Get(activityType);
            switch(viewType)
            {
                case "Day":
                    //Assert the Assigned Activity            
                    Logger.LogAssertion("VerifyActivityAssigned",
                        ScenarioContext.Current.ScenarioInfo.Title,
                        () => Assert.AreEqual(new CalendarHedDefaultUxPage().
                            GetAssignedActNameOnCurrentDayInAdvaceCalender(activity.Name, dateType), activity.Name));

                    break;

                case "Week":
                    new CalendarHedDefaultUxPage().SelectViewType(viewType);
                    break;

                case "Month":
                    new CalendarHedDefaultUxPage().SelectViewType(viewType);
                    break;

            }
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
                base.IsTakeScreenShotDuringEntryExit);
            //Enter Inside Day View
            new CalendarHedDefaultUxPage().EnterTheDayViewForAssignedActivity();
            //Verify Assign Count Message
            Logger.LogAssertion("VerifyAssignCountMessage",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
               Assert.AreEqual(assignedContentCountMessage,
               new CalendarHedDefaultUxPage().GetAssignedCountWithText()));
            Logger.LogMethodExit("AssignmentCalendar", "VerifyAssignedContentCount",
                base.IsTakeScreenShotDuringEntryExit);
        }


        [Then(@"I should see the message ""(.*)"" in day view of ""(.*)"" frame")]
        public void VerifyAssignedContentCountBasedOnDate(string assignedContentCountMessage, string dateType)
        {
            switch (dateType)
            {
                case "Current date":
                    //Enter the Day View for current date
                    new CalendarHedDefaultUxPage().EnterTheDayViewForAssignedActivity();
                    break;

                case "Future date":
                    //Enter the Day View for future date
                    new CalendarHedDefaultUxPage().EnterTheDayViewForAssignedActivityForFutureDate();
                    break;
            }
            //Verify Assign Count Message
            Logger.LogAssertion("VerifyAssignCountMessage",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
               Assert.AreEqual(assignedContentCountMessage,
               new CalendarHedDefaultUxPage().GetAssignedCountWithText()));

        }
       
        /// <summary>
        /// Click option in Calender frame
        /// </summary>
        /// <param name="optionName">This is option name.</param>
        /// <param name="pageTitle">This is page name.</param>
         [When(@"I click on ""(.*)"" option in calender frame of ""(.*)"" page")]
        public void ClickOnOptionInCalenderFrame(string optionName, string pageTitle)
        {
            // Click option in calender frame
            Logger.LogMethodEntry("AssignmentCalendar", "ClickOnOptionInCalenderFrame",base.IsTakeScreenShotDuringEntryExit);
            new CalendarHedDefaultUxPage().ClickOptionInCalendar(optionName, pageTitle);
            Logger.LogMethodExit("AssignmentCalendar", "ClickOnOptionInCalenderFrame", base.IsTakeScreenShotDuringEntryExit);
        }

         /// <summary>
         /// Validate display of options in calender
         /// </summary>
         /// <param name="optionName"></param>
         /// <param name="calenderType"></param>
         /// <param name="pageTitle"></param>
         [Then(@"I should be displayed with ""(.*)"" option in ""(.*)"" of ""(.*)"" page")]
         public void ValidateDisplayOfOptionCalenderBased(string optionName, string calenderType, string pageTitle)
         {
             Logger.LogMethodEntry("AssignmentCalendar", "ValidateDisplayOfOptionCalenderBased", base.IsTakeScreenShotDuringEntryExit);
             // Validate the display of options available in the calender
                 Logger.LogAssertion("VerifyTheStatusOfAssignedContent",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(
                new CalendarHedDefaultUxPage().GetOptionExistanceStatus(optionName, calenderType, pageTitle)));
             Logger.LogMethodExit("AssignmentCalendar", "ValidateDisplayOfOptionCalenderBased", base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Assert the Display Of status of assigned content
            Logger.LogAssertion("VerifyTheStatusOfAssignedContent",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new CalendarHedDefaultUxPage().IsActivityDueDateStatusPresent()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyTheStatusOfAssignedContentInStatusColumn",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Click On Calendar Icon
            new CalendarHedDefaultUxPage().ClickOnCalendarIcon();
            Logger.LogMethodExit("AssignmentCalendar",
                "ClickOnCalendarIcon",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Select Cmenu Option 'Set Scheduling Options' Of Content
            new CalendarHedDefaultUxPage().SelectSetSchedulingOptionsCmenu();
            Logger.LogMethodExit("AssignmentCalendar",
                "SelectSetSchedulingOptionsCmenuOfContent",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Current Date
            string currentDate = DateTime.Now.ToString(AssignmentCalendarResource.
                AssignmentCalendar_Resource_Date_Format);
            //Assert the Display Of Due Date to Which Content is Assigned
            Logger.LogAssertion("VerifyTheDisplayOfDueDate",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(currentDate,
                    new AssignContentPage().GetDueDateOfAssignedContent()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyTheDueDateOfAssignedContent",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Select Option In 'View By' Dropdown
            new CalendarDefaultUXPage().SelectViewByDropdownOption(dropdownOption);
            Logger.LogMethodExit("AssignmentCalendar", "SelectOptionInViewByDropdown",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Verify Contents Order In The Content Frame
            Logger.LogAssertion("VerifyContentsInContentFrame",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(new CalendarDefaultUXPage().GetContentsOrderInContentFrame(),
                    new CourseContentUXPage().GetContentOrderInMyCourse()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyContentsOrderInTheContentFrame",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Select The ContentType From ShowDropdown
            new CalendarHedDefaultUxPage().SelectTheContentTypeFromShowDropdown((
                CalendarHedDefaultUxPage.ShowDropdownTypeEnum)Enum.Parse
                (typeof(CalendarHedDefaultUxPage.ShowDropdownTypeEnum),
                showContentType));
            Logger.LogMethodExit("AssignmentCalendar",
                "SelectTheContentTypeFromShowDropdown",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Verify Contents Order In The Content Frame
            Logger.LogAssertion("VerifyContentsInContentFrame",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(new CalendarDefaultUXPage().
                                  GetContentsOrderInContentFrame(),
                    new CourseContentUXPage().GetContentOrderInMyCourse()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyTheContentsInCaledarFrame",
               base.IsTakeScreenShotDuringEntryExit);
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
                           base.IsTakeScreenShotDuringEntryExit);
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
                           base.IsTakeScreenShotDuringEntryExit);
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
                           base.IsTakeScreenShotDuringEntryExit);
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
                           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Expands the container asset node.
        /// </summary>
        [When(@"I expands the Asset Path on Calendar page")]
        public void ExpandsTheAssetPath()
        {
            Logger.LogMethodEntry("AssignmentCalendar",
                 "ExpandsTheAssetPath",
                          base.IsTakeScreenShotDuringEntryExit);
            CalendarHedDefaultUxPage calendarHEDDefaultUXPage = 
                new CalendarHedDefaultUxPage();
            Activity activity = Activity.Get(Activity.ActivityTypeEnum.Folder);
            activity.ActivityId = calendarHEDDefaultUXPage.GetAssetId(
                    activity.Name);
            activity.UpdateActivityInMemory(activity);
            calendarHEDDefaultUXPage.ExpandNode(activity.ActivityId);
            Logger.LogMethodExit("AssignmentCalendar",
                  "ExpandsTheAssetPath",
                           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify expand of folder and activities content.
        /// </summary>
        [Then(@"I should see expanded Folder with activities")]
        public void VerifyExpanedFolderWithActivities()
        {
            Logger.LogMethodEntry("AssignmentCalendar",
                 "VerifyExpanedFolderWithActivities",
                          base.IsTakeScreenShotDuringEntryExit);
            Assert.IsTrue(new CalendarHedDefaultUxPage().IsNodeExpanded(
                Activity.Get(Activity.ActivityTypeEnum.Folder).ActivityId));
            Logger.LogMethodExit("AssignmentCalendar",
              "VerifyExpanedFolderWithActivities",
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
            Logger.LogMethodEntry("AssignmentCalendar",
                 "VerifyAssignUnassignLinkState",
                          base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("AssignmentCalendar",
                 "ClickOnAssignUnassignLink",
                          base.IsTakeScreenShotDuringEntryExit);
            new CalendarHedDefaultUxPage()
                .ClickOnAssignUnassignButton();
            List<Activity> assignedActivityList =
                Activity.Get(a => a.IsAssigned == true);
            if (base.IsPopupPresent(CourseContentResource
               .CourseContent_ShowHide_ConfirmationPopup_Name,10))
            {
                this.ClickOkButtonOnPegasusConfirmationPopUp();
                base.SelectDefaultWindow();
            }
            
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
            Logger.LogMethodEntry("AssignmentCalendar",
                 "VerifyCheckMarkInAssignedStatusColumn",
                          base.IsTakeScreenShotDuringEntryExit);
            List<Activity> assignedActivityList =
                Activity.Get(a => a.IsAssigned == true);
            List<Activity> unAssignedActivityList =
                Activity.Get(a => a.IsAssigned == false);
            CalendarHedDefaultUxPage calendarHedDefaultUxPage =
                new CalendarHedDefaultUxPage();
            foreach (Activity unAssignedActivity in unAssignedActivityList)
            {
                Assert.IsTrue(calendarHedDefaultUxPage
                    .IsAssetAssigned(unAssignedActivity.ActivityId));
                unAssignedActivity.IsAssigned = true;                
                unAssignedActivity.UpdateActivityInMemory(unAssignedActivity);
            }
            Logger.LogMethodExit("AssignmentCalendar",
                  "VerifyCheckMarkInAssignedStatusColumn",
                           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks Ok button on Pegasus confirmation pop-up.
        /// </summary>
        public void ClickOkButtonOnPegasusConfirmationPopUp()
        {
            Logger.LogMethodEntry("AssignmentCalendar",
               "ClickOKButtonOnPegasusConfirmationPopUp",
               base.IsTakeScreenShotDuringEntryExit);
            //If assets are already attempted by student a show hide pop-up will appear
                base.SelectWindow(CourseContentResource
               .CourseContent_ShowHide_ConfirmationPopup_Name);
                new ShowMessagePage().ClickOkButton();
            Logger.LogMethodExit("AssignmentCalendar",
               "ClickOKButtonOnPegasusConfirmationPopUp",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify if the current date highlighted in the calendar frame.
        /// </summary>
        [Then(@"I should see the current date highlighted in the calendar frame")]
        public void VerifyTheCurrentDateHighlightedInTheCalendar()
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
        /// Verify folder asset is present.
        /// </summary>
        /// <param name="expectedFolderAssetName">This is a activity folder name.</param>
       [Then(@"I should see ""(.*)"" asset")]
        public void VerifyFolderAssetPresent(string expectedFolderAssetName)
        {
            //Verify expected folder name is same as actual folder name
            Logger.LogMethodEntry("AssignmentCalendar",
              "VerifyFolderAssetPresent",
              base.IsTakeScreenShotDuringEntryExit);
            //Assert expected and actual folder values
            Logger.LogAssertion("VerifyFolderAssetPresent",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedFolderAssetName,
                    new CalendarHedDefaultUxPage().GetActualFolderName(expectedFolderAssetName)));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyFolderAssetPresent",
              base.IsTakeScreenShotDuringEntryExit);
        }      

        /// <summary>
        ///  /// Drag and drop 'Word Chapter 1: Simulation Activities' folder to current date.
        /// </summary>
        [When(@"I drag and drop the ""(.*)"" folder to the current date")]
       public void DragAndDropFolderToCurrentDate(string activityName)
        {
            // Drag and drop a folder asset to current date.
            Logger.LogMethodEntry("AssignmentCalendar",
               "DragAndDropFolderToCurrentDate",
               base.IsTakeScreenShotDuringEntryExit);
            // Drag and drop a folder asset to current date.
            new CalendarHedDefaultUxPage().DragAndDropFolderAsset(activityName);
            //the commented code stopped working due to compatability issues with recent webdriver/browser.
            //new CalendarHedDefaultUxPage().DragAndDropWordFolderAsset();
            Logger.LogMethodExit("AssignmentCalendar",
              "DragAndDropFolderToCurrentDate",
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
                   .IsActivityDueDateStatusPresent()));
            Logger.LogMethodEntry("AssignmentCalendar",
             "VerifyDueDateIconDisplayed",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifying Start Date Flag is Present.
        /// </summary>
        [Then(@"I should see the startdate Icon in calendar frame")]
        public void VerifyTheStartdateIconInCalendarFrame()
        {
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
        /// Drag and Drop selected 'Excel Chapter 1: Simulation Activities' assets to current date.
        /// </summary>
        [When(@"I should drag and drop multiple assets to the current date")]
        public void DragAndDropMultipleAssetsToCurrentDate()
        {
            // Drag and drop multiple assets to current date
            Logger.LogMethodEntry("AssignmentCalendar",
               "DragAndDropMultipleAssetsToCurrentDate",
               base.IsTakeScreenShotDuringEntryExit);
            new CalendarHedDefaultUxPage().DragAndDropMultipleExcelActivities();
            // Drag and drop multiple assets to current date
            Logger.LogMethodExit("AssignmentCalendar",
             "DragAndDropMultipleAssetsToCurrentDate",
             base.IsTakeScreenShotDuringEntryExit);
        }

       
        /// <summary>
        /// Assign the asset to the current date,set start and end date,mark notification and save.
        /// </summary>
        [When(@"I assign the asset for current date in the properties popup")]
        public void AssignTheAsset()
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
        /// Verify the due date icon display next to the activity in calendar page.
        /// </summary>
        [Then(@"I should see the duedate icon along with the checkmark in the calendar")]
        public void VerifyTheAssignIconInCalendar()
        {
            Logger.LogMethodEntry("AssignmentCalendar",
             "VerifyDueDateIconInCalendar",
             base.IsTakeScreenShotDuringEntryExit);
            //verify duedate icon
            Logger.LogAssertion("VerifyDueDateIconInCalendar",
                ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.IsTrue(new CalendarHedDefaultUxPage().
                    IsDueDateIconPresentInCalendar()));
            //Verify CheckMark icon
            Logger.LogAssertion("VerifyCheckMarkIconInCalendar",
                ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.IsTrue(new CalendarHedDefaultUxPage().
                    IsCheckMarkDisplayedInCalendar()));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyDueDateIconInCalendar",
              base.IsTakeScreenShotDuringEntryExit);
        }

       

        // <summary>
        /// Click on the cmenu option of the asset.
        /// </summary>
        /// <param name="cmenuOption">This is the cmenu option.</param>
        /// <param name="assetName">This is a asset name.</param>
        [When(@"I select cmenu ""(.*)"" of activity ""(.*)""")]
        public void SelectCmenuOfActivity(string cmenuOption, string assetName)
        {
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
        /// Click on the cmenu option of the asset.
        /// </summary>
        /// <param name="cmenuOptionName">This is cmenu option name.</param>
        /// <param name="activityType">This is activity type.</param>
        [When(@"I click cmenu ""(.*)"" of activity ""(.*)""")]
        public void ClickCmenuOfActivity(string cmenuOptionName, Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("AssignmentCalendar",
              "SelectCmenuOfActivity",
              base.IsTakeScreenShotDuringEntryExit);

            // Get the activity name from inmemeory 
            Activity activity = Activity.Get(activityType);
            string assetName = activity.Name.ToString();

            //click on cmenu option
            new CalendarHedDefaultUxPage().SelectActivityCmenuOption
                (cmenuOptionName, assetName);
            Logger.LogMethodExit("AssignmentCalendar",
                "SelectCmenuOfActivity",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify the schedule checkmark and due date icon beside the activity name.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="folderName">This is the activity folder name.</param>
        [Then(@"I should see the duedate icon along with the checkmark in the calendar beside activity ""(.*)"" under ""(.*)""")]
        public void VerifyDueDateIconAndCheckMarkForAsset(string activityName, string folderName)
        {
            new CalendarHedDefaultUxPage().SelectCalendarWindow();
            String activityId = new CalendarHedDefaultUxPage().GetAssetId(folderName);
            String containerId = "ContainerID_" + activityId;
            //verify duedate icon
            Logger.LogAssertion("VerifyDueDateIconInCalendar",
                ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.IsTrue(new CalendarHedDefaultUxPage().
                    IsScheduleCheckMarkDisplayedBesideAsset(activityName, containerId)));
            //Verify CheckMark icon
            Logger.LogAssertion("VerifyCheckMarkIconInCalendar",
                ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.IsTrue(new CalendarHedDefaultUxPage().
                    IsDuedateIconDisplayedBesideAsset(activityName, containerId)));

        }

        /// <summary>
        /// Validate the date displayed in Advance view of calender
        /// </summary>
        /// <param name="dateType"></param>
        [Then(@"I should be on the ""(.*)"" in Advance calender")]
        public void ValidateDateInAdvanceCalender(string dateType)
        {
            Logger.LogMethodEntry("AssignmentCalendar", "ValidateDateInAdvanceCalender",base.IsTakeScreenShotDuringEntryExit);
            
            Logger.LogMethodExit("AssignmentCalendar", "ValidateDateInAdvanceCalender", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click option in assignment calender
        /// </summary>
        /// <param name="optionName">This is option Name.</param>
        [When(@"I click on ""(.*)"" option of notes")]
        public void ClickIconInCalendar(string optionName)
        {
            Logger.LogMethodEntry("AssignmentCalendar", "ClickIconInCalendar", base.IsTakeScreenShotDuringEntryExit);

            Logger.LogMethodExit("AssignmentCalendar", "ClickIconInCalendar", base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
