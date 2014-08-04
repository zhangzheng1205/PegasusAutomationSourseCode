using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MMND.
    Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of GradeBook page 
    /// and handles Pegasus GradeBook Page Actions.
    /// </summary>
    [Binding]
    public class GradeBook : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(GradeBook));       

        /// <summary>
        /// Verify The Activity In Gradebook.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        [Then(@"I should see the ""(.*)"" activity in Gradebook")]
        public void VerifyActivityInGradebook(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify The Activity In Gradebook
            Logger.LogMethodEntry("GradeBook", "VerifyActivityInGradebook", IsTakeScreenShotDuringEntryExit);
            //Get the activity from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new GBDefaultUXPage().GetActivityNameInGradebook(activity.Name)));
            Logger.LogMethodExit("GradeBook", "VerifyActivityInGradebook", IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Activity Cmenu Option.
        /// </summary>
        /// <param name="activityName">This is Activity Type Enum.</param>
        [When(@"I click the ""(.*)"" activity cmenu option")]
        public void ClickActivityCmenuOption(Activity.ActivityTypeEnum activityName)
        {
            //Click Activity Cmenu Option
            Logger.LogMethodEntry("GradeBook", "ClickwritingSpaceActivityCmenuOption", IsTakeScreenShotDuringEntryExit);
            //Get the activity from memory
            Activity activity = Activity.Get(activityName);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Click on Activity Cmenu
            new GBInstructorUXPage().ClickTheActivityCmenuOption(activity.Name);
            Logger.LogMethodExit("GradeBook", "ClickwritingSpaceActivityCmenuOption", IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display Of CMenu Options For Activity.
        /// </summary>
        /// <param name="table">This is Table Reference.</param>
        [Then(@"I should able to see the Display of c-menu options for activity")]
        public void VerifyTheDisplayOfCMenuOptionsForActivity(Table table)
        {
            //Verify The Display Of CMenu Options For Activity.
            Logger.LogMethodEntry("GradeBook", "VerifyTheDisplayOfCMenuOptionsForActivity", base.IsTakeScreenShotDuringEntryExit);
            foreach (var tableRow in table.Rows)
            {
                //Assert Display of Activity Cmenu Options
                TableRow row = tableRow;
                Logger.LogAssertion("VerifyCmenuOptions", ScenarioContext.
                    Current.ScenarioInfo.Title,
                () => Assert.AreEqual(row[GradeBookResource.GradebookPage_Activity_Expected_Cmenu_Options_Displayed],
                    new GBInstructorUXPage().GetDisplayOfWritingSpaceActivityCmenuOptions
                    (row[GradeBookResource.GradebookPage_Activity_Actual_Cmenu_Options_Displayed])));
            }
            Logger.LogMethodExit("GradeBook", "VerifyTheDisplayOfCMenuOptionsForActivity", base.IsTakeScreenShotDuringEntryExit);
        } 

        /// <summary>
        /// Click On Cmenu Of Asset In Gradebook.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I click on cmenu ""(.*)"" of ""(.*)"" Activity")]
        public void ClickOnCmenuOfActivityInGradebook(
            string assetCmenu, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu Of Asset In Gradebook
            Logger.LogMethodEntry("GradeBook", "ClickOnCmenuOfActivityInGradebook", IsTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Get Activity
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Window and Frame
            new CourseContentUXPage().SelectGradebookWindowInCourseHome();
            //Select The Cmenu Option Of Asset
            gbInstructorPage.SelectTheCmenuOptionOfActivity(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), activity.Name, activityTypeEnum);
            Logger.LogMethodExit("GradeBook", "ClickOnCmenuOfActivityInGradebook", IsTakeScreenShotDuringEntryExit);
        }                

        /// <summary>
        /// Verify The Successfull Message In Gradebook.
        /// </summary>
        /// <param name="successMessage">This is Success Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in gradebook")]
        public void VerifyTheSuccessfullMessageInGradebook(string successMessage)
        {
            //Verify Display of Success Message in Gradebook
            Logger.LogMethodEntry("GradeBook", "VerifyTheSuccessfullMessageInGradebook", base.IsTakeScreenShotDuringEntryExit);
            //Assert Success Message in Gradebook
            Logger.LogAssertion("VerifyDisplayOfContextMenuOption",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(successMessage,
                    new GBInstructorUXPage().GetHideForStudentSuccessMessage()));
            Logger.LogMethodExit("GradeBook", "VerifyTheSuccessfullMessageInGradebook", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// click on create column drop down.
        /// </summary>
        [When(@"I click on the Create Column drop down and select ""(.*)"" Column")]
        public void ClickOnCustomColumn(string customColumnCmenu)
        {
            // Open Create Total column pop up window
            Logger.LogMethodEntry("GradeBook", "ClickOnCustomColumn",
                base.IsTakeScreenShotDuringEntryExit);
            new GBInstructorUXPage().ClickOnCustomColumn(
                (GBInstructorUXPage.CustomColumnTypeEnum)Enum.Parse(typeof(
                GBInstructorUXPage.CustomColumnTypeEnum), customColumnCmenu)
                );
            Logger.LogMethodExit("GradeBook", "ClickOnCustomColumn",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Calculated Column Name
        /// </summary>
        [When(@"I enter Calculated Column name")]
        public void EnterCalculatedColumnName()
        {
            // Open Create Total column pop up window
            Logger.LogMethodEntry("GradeBook", "EnterCalculatedColumnName",
                base.IsTakeScreenShotDuringEntryExit);
            new GBInstructorUXPage().EnterCalculatedColumnName();            
            Logger.LogMethodExit("GradeBook", "EnterCalculatedColumnName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the activities for Calculated Column (Min 2 activities are required)
        /// </summary>
        /// <param name="activityTypeEnum1">Activity Type 1</param>
        /// <param name="activityTypeEnum2">Activity Type 2</param>
        [When(@"I select checkbox of activities ""(.*)"" and ""(.*)""")]
        public void SelectCheckboxOfActivities(Activity.ActivityTypeEnum activityTypeEnum1, Activity.ActivityTypeEnum activityTypeEnum2)
        {
            // Select activities for adding
            Logger.LogMethodEntry("GradeBook", "SelectCheckboxOfActivities",
                base.IsTakeScreenShotDuringEntryExit);
            //Sending first activity to for loop
            Activity activity1 = Activity.Get(activityTypeEnum1);
            new GBInstructorUXPage().SelectActivityFromLeftFrameForCustomColumn(activity1.Name);
            //Sending second activity to for loop
            Activity activity2 = Activity.Get(activityTypeEnum2);
            new GBInstructorUXPage().SelectActivityFromLeftFrameForCustomColumn(activity2.Name);
            Logger.LogMethodExit("GradeBook", "SelectCheckboxOfActivities",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add button image 
        /// </summary>
        [When(@"I click the on Add button")]
        public void ClickOnAddButton()
        {
            // Select activities for adding
            Logger.LogMethodEntry("GradeBook", "ClickOnAddButton",
                base.IsTakeScreenShotDuringEntryExit);
            // Add activities to right frame
            new GBInstructorUXPage().AddActivitiesinRightFrame();
            Logger.LogMethodExit("GradeBook", "ClickOnAddButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save button
        /// </summary>
        [When(@"I click on Save Button")]
        public void ClickOnSaveButton()
        {
            // Select activities for adding
            Logger.LogMethodEntry("GradeBook", "ClickOnAddButton",
                base.IsTakeScreenShotDuringEntryExit);
            // Add activities to right frame
            new GBInstructorUXPage().ClickOnsaveButton();
            Logger.LogMethodExit("GradeBook", "ClickOnAddButton",
               base.IsTakeScreenShotDuringEntryExit);
        }




    }
}
