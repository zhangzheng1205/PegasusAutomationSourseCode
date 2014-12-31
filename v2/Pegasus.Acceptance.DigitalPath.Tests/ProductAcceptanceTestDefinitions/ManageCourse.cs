#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

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
        [Then(@"I should see assigned LCC ""(.*)""")]
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
        /// Verify the status of LCC in manage course materials tab.
        /// </summary>
        /// <param name="status">Expected status.</param>
        /// <param name="activityName">LCC name.</param>
        [Then(@"I should see status as ""(.*)"" for LCC ""(.*)""")]
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
        [Then(@"I should see the due date for LCC ""(.*)""")]
        public void ValidateDueDateOfLCC(string lccName)
        {
            //Validate the due date of LCC
            Logger.LogMethodEntry("ManageCourse", "ValidateDueDateOfLCC",
               base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(User.UserTypeEnum.DPCsTeacher);
            DateTime instance = user.CurrentProfileDateTime;
            string currentDateTime = instance.ToString();
            string currentDate = currentDateTime.Split(' ')[0];
            Logger.LogAssertion("ManageCourse", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(currentDate, new CoursePreviewMainUXPage().GetDueDateOfAssignedContent(lccName)));
            Logger.LogMethodExit("ManageCourse", "ValidateDueDateOfLCC",
             base.IsTakeScreenShotDuringEntryExit);
        }

      

        [Then(@"I should see ""(.*)"" text in Shown to column for LCC ""(.*)""")]
        public void ValidateShownColumnText(string shownColumnText, string activityName)
        {
            //Validate the text in shown to column in Manage course materials
            Logger.LogMethodEntry("ManageCourse", "ValidateShownColumnText",
               base.IsTakeScreenShotDuringEntryExit);
            //Validate the text in shown to column in Manage course materials
            Logger.LogAssertion("ManageCourse", ScenarioContext.Current.ScenarioInfo.Title,
            () => Assert.AreEqual(shownColumnText, new CoursePreviewMainUXPage().GetShownToColumnTextOfAssignedContent(activityName)));
            Logger.LogMethodExit("ManageCourse", "ValidateStatusOftheActivity",
             base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see Assigned icon for LCC ""(.*)""")]
        public void ValidateDisplayOfAssignIcon(string activityName)
        {
            //Validate the display of assign icon for LCC in Manage course materials
            Logger.LogMethodEntry("ManageCourse", "ValidateDisplayOfAssignIcon",
               base.IsTakeScreenShotDuringEntryExit);
            //Validate the display of assign icon for LCC in Manage course materials
            Logger.LogAssertion("ManageCourse", ScenarioContext.Current.ScenarioInfo.Title,
            () => Assert.IsTrue(new CoursePreviewMainUXPage().IsAssignIconExists(activityName)));
            Logger.LogMethodExit("ManageCourse", "ValidateDisplayOfAssignIcon",
             base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
