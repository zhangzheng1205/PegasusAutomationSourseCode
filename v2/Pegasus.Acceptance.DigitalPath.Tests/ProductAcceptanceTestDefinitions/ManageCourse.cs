#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Create Course Copy Page Actions.
    /// </summary>
    [Binding]
    public class ManageCourse : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ManageCourse));

        /// <summary>
        /// Verify button availability on the screen.
        /// </summary>
        /// <param name="getButtonName">This is the Button name.</param>
        [Then(@"I should see ""(.*)"" button")]
        public void VerifyButtonAvailability(String getButtonName)
        {
            // Check availability of button
            Logger.LogMethodEntry("ManageCourse", "VerifyButtonAvailability",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert the Display Of button in manage course frame
            Logger.LogAssertion("VerifyDisplayOfButtons",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.
                    IsTrue(new SearchCoursesPage().
                    IsButtonDisplayed((SearchCoursesPage.ManageCourseFrameButtons)Enum.Parse
                (typeof(SearchCoursesPage.ManageCourseFrameButtons), getButtonName), getButtonName)));
            Logger.LogMethodExit("ManageCourse", "VerifyButtonAvailability",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify radio button availability on the screen.
        /// </summary>
        /// <param name="radioButtonName">This is the button name.</param>
        [Then(@"I should see ""(.*)"" radio button")]
        public void VerifyRadioButtonAvailability(
            String radioButtonName)
        {
            //Check availability of RadioButton
            Logger.LogMethodEntry("ManageCourse", "VerifyRadioButtonAvailability",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert the Display Of radio button in manage course frame
            Logger.LogAssertion("VerifyDisplayOfRadioButtons",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.
                    IsTrue(new SearchCoursesPage().
                    IsRadioButtonDisplayed(radioButtonName)));
            Logger.LogMethodExit("ManageCourse", "VerifyRadioButtonAvailability",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify text field next to the filters in manage course frame.
        /// </summary>
        [Then(@"I should see Text field next to the Filters")]
        public void VerifyTextFieldInManageCourseFrame()
        {
            //Check availability of text field
            Logger.LogMethodEntry("ManageCourse", "VerifyTextFieldInManageCourseFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert the availability of text field in manage course frame
            Logger.LogAssertion("VerifyDisplayOfTextField",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.
                    IsTrue(new SearchCoursesPage().
                    IsTextFieldPresentInCourseFrame()));
            Logger.LogMethodExit("ManageCourse", "VerifyTextFieldInManageCourseFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Equals, Contains, Begins With and Ends With Filters in manage course frame.
        /// </summary>
        [Then(@"I should see Equals, Contains, Begins With and Ends With Filters")]
        public void VerifyFiltersInManageCourseFrame()
        {
            //Check availability of filters
            Logger.LogMethodEntry("ManageCourse", "VerifyFiltersInManageCourseFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert the availability of fitlers in manage course frame
            Logger.LogAssertion("VerifyDisplayOfFilters",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.
                    AreEqual(ManageCourseResource.ManageCourse_FiltersName, new SearchCoursesPage().
                    GetFiltersName()));
            Logger.LogMethodExit("ManageCourse", "VerifyFiltersInManageCourseFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify display of assigned LCC name.
        /// </summary>
        /// <param name="lccName">LCC activity name</param>
        [Then(@"I should see assigned MathXL activity ""(.*)""")]
        [Then(@"I should see assigned study plan ""(.*)""")]
        [Then(@"I should see assigned LCC ""(.*)""")]
        [Then(@"I should see assigned Media Server Link ""(.*)""")]
        [Then(@"I should see assigned Writing Coach activity ""(.*)""")]
        public void ValidateLCCNameDisplayInManageCourseMaterial(string lccName)
        {
            //Validate the display of LCC name
            Logger.LogMethodEntry("ManageCourse", "ValidateLCCNameDisplayInManageCourseMaterial",
               base.IsTakeScreenShotDuringEntryExit);
            //Validate the display of LCC name in Manage course materials
            Logger.LogAssertion("ManageCourse", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(lccName, new CoursePreviewMainUXPage().GetActivityNameInTeachingPlanTab(lccName)));
            Logger.LogMethodExit("ManageCourse", "ValidateLCCNameDisplayInManageCourseMaterial",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select c/menu of the asset
        /// </summary>
        /// <param name="cmenu">This is the menu name</param>
        /// <param name="assetName">This is the asset link name</param>
        [When(@"I select ""(.*)"" from cmenu of ""(.*)""")]
        public void SelectCMenu(CoursePreviewMainUXPage.
            ActivityCmenuEnum cmenu, string assetName)
        {
            //Validate the display of LCC name
            Logger.LogMethodEntry("ManageCourse", "ValidateLCCNameDisplayInManageCourseMaterial",
               base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewMainUXPage().SelectActivityCmenuOptioninDP(cmenu, assetName);
            Logger.LogMethodExit("ManageCourse", "ValidateLCCNameDisplayInManageCourseMaterial",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the status of LCC in manage course materials tab.
        /// </summary>
        /// <param name="status">Expected status.</param>
        /// <param name="activityName">LCC name.</param>
        [Then(@"I should see status as ""(.*)"" for MathXL activity ""(.*)""")]
        [Then(@"I should see status as ""(.*)"" for study plan ""(.*)""")]
        [Then(@"I should see status as ""(.*)"" for LCC ""(.*)""")]
        [Then(@"I should see status as ""(.*)"" for Writing Coach activity ""(.*)""")]
        public void ValidateStatusOftheActivity(string status, string activityName)
        {
            //Validate the Status of assigned LCC
            Logger.LogMethodEntry("ManageCourse", "ValidateStatusOftheActivity",
               base.IsTakeScreenShotDuringEntryExit);
            //Validate the Status of assigned LCC
            Logger.LogAssertion("ManageCourse", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(status, new CoursePreviewMainUXPage().GetStatusOfActivityInManageCourseMaterails(activityName)));
            Logger.LogMethodExit("ManageCourse", "ValidateStatusOftheActivity",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate the due date of assigned LCC in
        /// manage course materials tab.
        /// </summary>
        /// <param name="lccName">LCC name</param>
        [Then(@"I should see the due date for MathXL activity ""(.*)""")]
        [Then(@"I should see the due date for study plan ""(.*)""")]
        [Then(@"I should see the due date for LCC ""(.*)""")]
        public void ValidateDueDateOfLCC(string lccName)
        {
            //Validate the due date of LCC
            Logger.LogMethodEntry("ManageCourse", "ValidateDueDateOfLCC",
               base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(User.UserTypeEnum.DPCsTeacher);
            DateTime instance = user.CurrentProfileDateTime;
            String CurrentMonth = DateTime.Now.Month.ToString();
            String CurrentDay = DateTime.Now.Day.ToString();
            String CurrentYear = DateTime.Now.Year.ToString();
            String currentDate = CurrentMonth + "/" + CurrentDay + "/" + CurrentYear;

            Logger.LogAssertion("ManageCourse", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(currentDate, new CoursePreviewMainUXPage().GetDueDateOfAssignedContent(lccName)));
            Logger.LogMethodExit("ManageCourse", "ValidateDueDateOfLCC",
             base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate the shown column text in manage course materials.
        /// </summary>
        /// <param name="shownColumnText">Text to validate.</param>
        /// <param name="activityName">Name of the activity.</param>
        [Then(@"I should see ""(.*)"" text in Shown to column for MathXL activity ""(.*)""")]
        [Then(@"I should see ""(.*)"" text in Shown to column for study plan ""(.*)""")]
        [Then(@"I should see ""(.*)"" text in Shown to column for LCC ""(.*)""")]
        [Then(@"I should see ""(.*)"" text in Shown to column for Writing Coach activity ""(.*)""")]
        public void ValidateShownColumnTextInMangeCourseMaterials(string shownColumnText, string activityName)
        {
            //Validate the text in shown to column in Manage course materials
            Logger.LogMethodEntry("ManageCourse", "ValidateShownColumnTextInMangeCourseMaterials",
               base.IsTakeScreenShotDuringEntryExit);
            //Validate the text in shown to column in Manage course materials
            Logger.LogAssertion("ManageCourse", ScenarioContext.Current.ScenarioInfo.Title,
            () => Assert.AreEqual(shownColumnText, new CoursePreviewMainUXPage().GetShownToColumnTextOfAssignedContent(activityName)));

            Logger.LogMethodExit("ManageCourse", "ValidateShownColumnTextInMangeCourseMaterials",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate assign icon.
        /// </summary>
        /// <param name="activityName">Name of the activity.</param>
        [Then(@"I should see Assigned icon for MathXL activity ""(.*)""")]
        [Then(@"I should see Assigned icon for study plan ""(.*)""")]
        [Then(@"I should see Assigned icon for LCC ""(.*)""")]
        [Then(@"I should see Assigned icon for Writing Coach activity ""(.*)""")]
        public void ValidateDisplayOfAssignIcon(string activityName)
        {
            //Validate the display of assign icon for LCC in Manage course materials
            Logger.LogMethodEntry("ManageCourse", "ValidateDisplayOfAssignIcon",
               base.IsTakeScreenShotDuringEntryExit);
            //Validate the display of assign icon for LCC in Manage course materials
            Logger.LogAssertion("ManageCourse", ScenarioContext.Current.ScenarioInfo.Title,
            () => Assert.IsTrue(new CoursePreviewMainUXPage().IsAssignIconExists(activityName)));
            base.SwitchToDefaultPageContent();
            base.SwitchToDefaultWindow();
            Logger.LogMethodExit("ManageCourse", "ValidateDisplayOfAssignIcon",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medialink"></param>
        [When(@"I click on '(.*)' in the Manage Coursework")]
        public void ClickMediaServerLink(Activity.ActivityTypeEnum medialink)
        {
            //Select Cmenu Of Asset In Table Of Contents
            Logger.LogMethodEntry("ManageCourse", "ClickMediaServerLink",
                  base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewMainUXPage().ClickonMediaServerLink(medialink);
            Logger.LogMethodExit("ManageCourse", "ClickMediaServerLink",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Media Server Link is launched successfully.
        /// </summary>
        /// <param name="activity">This is media server link</param>
        [Then(@"I should see the '(.*)' launched successfully")]
        public void MediaSeverSuccessfullyLaunched(Activity.ActivityTypeEnum activity)
        {
            //Select Cmenu Of Asset In Table Of Contents
            Logger.LogMethodEntry("ManageCourse", "MediaSeverSuccessfullyLaunched",
                  base.IsTakeScreenShotDuringEntryExit);
            Activity activityName = Activity.Get(Activity.ActivityTypeEnum.MediaServerLink);
            string mediaServerLink = activityName.Name.ToString();
            Logger.LogAssertion("MediaSeverSuccessfullyLaunched",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new CoursePreviewMainUXPage().
                    OpenMediaServerLink(mediaServerLink)));
            base.CloseBrowserWindow();
            base.SelectDefaultWindow();
            Logger.LogMethodExit("ManageCourse", "MediaSeverSuccessfullyLaunched",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click OK button in Delete Assignments Pop Up
        /// </summary>
        [When(@"I click on Ok button in Delete Assignment pop up")]
        public void ClickOKinDeleteAssignment()
        {
            //Click on Ok button in Alert pop up
            Logger.LogMethodEntry("CommonSteps", "ClickOKinDeleteAssignment",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Ok button in Alert pop up
            new CoursePreviewMainUXPage().ClickOKinDeleteAssignmentPopUp();
            Logger.LogMethodExit("CommonSteps", "ClickOKinDeleteAssignment",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
