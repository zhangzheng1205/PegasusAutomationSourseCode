using Pearson.Pegasus.TestAutomation.Frameworks;
using System;
using System.Collections.Generic;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;
using System.Configuration;

namespace Pegasus.Acceptance.HigherEducation.HSS.Tests.CommonProductAcceptanceTestDefinitions
{
    [Binding]
    public class AssignmentCalendar : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(AssignmentCalendar));
        private const string ENV_PEG_AUTOMATION_BROWSER = "PEG_AUTOMATION_BROWSER";
        private const string APP_SETTINGS_BROWSER = "Browser";
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
        /// Clicks Ok button on Pegasus confirmation pop-up.
        /// </summary>
        public void ClickOkButtonOnPegasusConfirmationPopUp()
        {
            // Clicks Ok button on Pegasus confirmation pop-up
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
        [Then(@"I assign the asset for current date in the properties popup")]
        public void AssignTheAsset()
        {
            // Assign the asset to the current date,set start and end date,mark notification and save
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
            // Verify the schedule checkmark and due date icon beside the activity name
            Logger.LogMethodEntry("AssignmentCalendar",
                "VerifyDueDateIconAndCheckMarkForAsset",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyDueDateIconAndCheckMarkForAsset",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Opening c menu and clicking on the given c menu option.
        /// </summary>
        /// <param name="activityCmenuOption">c menu option  name.</param>
        /// <param name="assetName">Activity name.</param>
        [When(@"I click on ""(.*)"" option in c menu of ""(.*)"" asset")]
        public void CMenuOperationsForAnAsset(string activityCmenuOption, string assetName)
        {
            //Select Cmenu Option Of Activity
            Logger.LogMethodEntry("CourseContent", "CMenuOperationsForAnAsset",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Activity Cmenu Option
            new TeachingPlanUxPage().SelectActivityCmenuForInstructor
                ((TeachingPlanUxPage.ActivityCmenuEnum)
                Enum.Parse(typeof(TeachingPlanUxPage.ActivityCmenuEnum),
                activityCmenuOption), assetName);
            Logger.LogMethodExit("CourseContent", "CMenuOperationsForAnAsset",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assigning the activity with due date.
        /// </summary>
        [When(@"I assign asset with due date and save")]
        public void AssignAssetWithDueDateAndSave()
        {
            // Assigning the activity with due date
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
            // Checking assigned status
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
        /// Assign the asset to the current date,set start and end date,mark notification and save.
        /// </summary>
        [When(@"I assign the asset for current date in the properties popup")]
        public void AssignTheAssetforStartDateIcon()
        {
            Logger.LogMethodEntry("AssignmentCalendar",
               "AssignTheAsset",
               base.IsTakeScreenShotDuringEntryExit);
            ////base.SelectWindow("Assign");
            string browserName = Environment.GetEnvironmentVariable(ENV_PEG_AUTOMATION_BROWSER);
            if (string.IsNullOrEmpty(browserName))
            {
                browserName = ConfigurationManager.AppSettings[APP_SETTINGS_BROWSER];
                if (browserName == "Internet Explorer")
                {
                    Thread.Sleep(10000);
                    base.SwitchToLastOpenedWindow();
                    string pageTitle = base.GetPageTitle;
                    // Verifies the Correct Page Opened
                    base.SelectWindow(pageTitle);
                }
                else
                {
                    base.SelectWindow("Assign");
                }
            }
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

    }
}

