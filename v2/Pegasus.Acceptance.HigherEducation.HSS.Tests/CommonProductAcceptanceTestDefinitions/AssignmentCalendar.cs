using Pearson.Pegasus.TestAutomation.Frameworks;
using System;
using System.Collections.Generic;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Acceptance.HigherEducation.HSS.Tests.CommonProductAcceptanceTestDefinitions
{
    [Binding]
    public class AssignmentCalendar : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(AssignmentCalendar));
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
            Logger.LogMethodExit("AssignmentCalendar",
                  "ClickOnAssignUnassignLink",
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
            CalendarHedDefaultUxPage calendarHEDDefaultUXPage =
                new CalendarHedDefaultUxPage();
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
        /// Drag and Drop selected 'Excel Chapter 1: Simulation Activities' assets to current date.
        /// </summary>
        [When(@"I should drag and drop multiple assets along with ""(.*)"" to the current date")]       
        public void DragAndDropMultipleAssetsToCurrentDate(string activityName)
        {
            // Drag and drop multiple assets to current date
            Logger.LogMethodEntry("AssignmentCalendar",
               "DragAndDropMultipleAssetsToCurrentDate",
               base.IsTakeScreenShotDuringEntryExit);
            new CalendarHedDefaultUxPage().DragAndDropMultipleActivities(activityName);
            // Drag and drop multiple assets to current date
            Logger.LogMethodExit("AssignmentCalendar",
             "DragAndDropMultipleAssetsToCurrentDate",
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
        /// Assign the asset to the current date,set start and end date,mark notification and save.
        /// </summary>       
        [Then(@"I assign the asset for current date in the properties popup")]        
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


    }
}
