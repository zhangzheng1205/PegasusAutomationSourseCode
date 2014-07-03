﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
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
            Logger.LogMethodEntry("GradeBook", "VerifyActivityInGradebook", isTakeScreenShotDuringEntryExit);
            //Get the activity from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new GBDefaultUXPage().GetActivityNameInGradebook(activity.Name)));
            Logger.LogMethodExit("GradeBook", "VerifyActivityInGradebook", isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Activity Cmenu Option.
        /// </summary>
        /// <param name="activityName">This is Activity Type Enum.</param>
        [When(@"I click the ""(.*)"" activity cmenu option")]
        public void ClickActivityCmenuOption(Activity.ActivityTypeEnum activityName)
        {
            //Click Activity Cmenu Option
            Logger.LogMethodEntry("GradeBook", "ClickwritingSpaceActivityCmenuOption", isTakeScreenShotDuringEntryExit);
            //Get the activity from memory
            Activity activity = Activity.Get(activityName);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Click on Activity Cmenu
            new GBInstructorUXPage().ClickTheActivityCmenuOption(activity.Name);
            Logger.LogMethodExit("GradeBook", "ClickwritingSpaceActivityCmenuOption", isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display Of CMenu Options For Activity.
        /// </summary>
        /// <param name="table">This is Table Reference.</param>
        [Then(@"I should able to see the Display of c-menu options for activity")]
        public void VerifyTheDisplayOfCMenuOptionsForActivity(Table table)
        {
            //Verify The Display Of CMenu Options For Activity.
            Logger.LogMethodEntry("GradeBook", "VerifyTheDisplayOfCMenuOptionsForActivity", base.isTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("GradeBook", "VerifyTheDisplayOfCMenuOptionsForActivity", base.isTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("GradeBook", "ClickOnCmenuOfActivityInGradebook", isTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Get Activity
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Window and Frame
            new CourseContentUXPage().SelectGradebookWindowInCourseHome();
            //Select The Cmenu Option Of Asset
            gbInstructorPage.SelectTheCmenuOptionOfActivity(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), activity.Name);
            Logger.LogMethodExit("GradeBook", "ClickOnCmenuOfActivityInGradebook", isTakeScreenShotDuringEntryExit);
        }                

        /// <summary>
        /// Verify The Successfull Message In Gradebook.
        /// </summary>
        /// <param name="successMessage">This is Success Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in gradebook")]
        public void VerifyTheSuccessfullMessageInGradebook(string successMessage)
        {
            //Verify Display of Success Message in Gradebook
            Logger.LogMethodEntry("GradeBook", "VerifyTheSuccessfullMessageInGradebook", base.isTakeScreenShotDuringEntryExit);
            //Assert Success Message in Gradebook
            Logger.LogAssertion("VerifyDisplayOfContextMenuOption",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(successMessage,
                    new GBInstructorUXPage().GetHideForStudentSuccessMessage()));
            Logger.LogMethodExit("GradeBook", "VerifyTheSuccessfullMessageInGradebook", base.isTakeScreenShotDuringEntryExit);
        }
    }
}
