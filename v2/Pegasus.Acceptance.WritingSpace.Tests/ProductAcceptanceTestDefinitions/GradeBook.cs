using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.WritingSpace.
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
        /// Verify The WritingSpace Activity In Gradebook.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        [Then(@"I should see the ""(.*)"" activity in Gradebook")]
        public void VerifyWritingSpaceActivityInGradebook(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify The WritingSpace Activity In Gradebook
            Logger.LogMethodEntry("GradeBook", "VerifyWritingSpaceActivityInGradebook",
                 isTakeScreenShotDuringEntryExit);
            //Get the activity from memory
             Activity activity = Activity.Get(activityTypeEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new GBDefaultUXPage().
                              GetWritingSpaceActivityNameInGradebook(activity.Name)));
            Logger.LogMethodExit("GradeBook", "VerifyWritingSpaceActivityInGradebook",
                isTakeScreenShotDuringEntryExit);
        }       
       
        /// <summary>
        /// Verify Activity Score in Gradebook for Enrollled Students.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type enum.</param>
        /// <param name="userTypeEnum">This is User type.</param>
        [Then(@"I should see the ""(.*)"" activity with grade for the enrollled ""(.*)""")]
        public void VerifyActivityScoreInGradebookForEnrollledStudents(
            Activity.ActivityTypeEnum activityTypeEnum, User.UserTypeEnum userTypeEnum)
        {
            //Verify Activity Display in Gradebook for Enrollled Students
            Logger.LogMethodEntry("GradeBook",
                "VerifyActivityScoreInGradebookForEnrollledStudents",
                 isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            //Assert Activity Name for Enrolled User in Gradebook
            Logger.LogAssertion("VerifyActivityDisplayInGradebook",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(GradeBookResource.
                 GradebookPage_Writingspace_Activity_Grade,
                 new GBDefaultUXPage().GetWritingSpaceActivityScore
                 (activity.Name, user.LastName,user.FirstName)));
            Logger.LogMethodExit("GradeBook",
                "VerifyActivityScoreInGradebookForEnrollledStudents",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click writing Space Activity Cmenu Option.
        /// </summary>
        /// <param name="activityName">This is Activity Type Enum.</param>
        [When(@"I click the ""(.*)"" activity cmenu option")]
        public void ClickwritingSpaceActivityCmenuOption(
            Activity.ActivityTypeEnum activityName)
        {
            //Click writing Space Activity Cmenu Option
            Logger.LogMethodEntry("GradeBook", 
                "ClickwritingSpaceActivityCmenuOption", 
                isTakeScreenShotDuringEntryExit);
            //Get the activity from memory
            Activity activity = Activity.Get(activityName);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Click on Activity Cmenu
            new GBInstructorUXPage().
                     ClickTheWritingSpaceActivityCmenuOption(activity.Name);
            Logger.LogMethodExit("GradeBook",
                "ClickwritingSpaceActivityCmenuOption",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display Of CMenu Options For Activity.
        /// </summary>
        /// <param name="table">This is Table Reference.</param>
        [Then(@"I should able to see the Display of c-menu options for activity")]
        public void VerifyTheDisplayOfCMenuOptionsForActivity(Table table)
        {
            //Verify The Display Of CMenu Options For Activity.
            Logger.LogMethodEntry("GradeBook",
                 "VerifyTheDisplayOfCMenuOptionsForActivity",
                 base.isTakeScreenShotDuringEntryExit);
            foreach (var tableRow in table.Rows)
            {
                //Assert Display of Activity Cmenu Options
                TableRow row = tableRow;
                Logger.LogAssertion("VerifyCmenuOptions", ScenarioContext.
                    Current.ScenarioInfo.Title,
                () => Assert.AreEqual(row[GradeBookResource.
                    GradebookPage_Activity_Expected_Cmenu_Options_Displayed],
                    new GBInstructorUXPage().GetDisplayOfWritingSpaceActivityCmenuOptions(row[
                    GradeBookResource.
                    GradebookPage_Activity_Actual_Cmenu_Options_Displayed])));
            }
            Logger.LogMethodExit("GradeBook",
                "VerifyTheDisplayOfCMenuOptionsForActivity",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display of Writing Space Activity With Score.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="activityScore">This is activity score.</param>
        [Then(@"I should see the ""(.*)"" activity with score ""(.*)""")]
        public void VerifyWritingSpaceActivityWithScore(
            Activity.ActivityTypeEnum activityTypeEnum, string activityScore)
        {
            //Verify Display of Writing Space Activity With Score
            Logger.LogMethodEntry("Gradebook", "VerifyWritingSpaceActivityWithScore",
                base.isTakeScreenShotDuringEntryExit);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Window and Frame
            new CourseContentUXPage().SelectGradebookWindowInCourseHome();
            //Verify The Searched Asset Name
            Logger.LogAssertion("VerifyAssetScore",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityScore,
                     gbStudentPage.GetActivityScoreInGradebook
                     (activity.Name)));
            Logger.LogMethodExit("Gradebook", "VerifyWritingSpaceActivityWithScore",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display of Activity In Gradebook.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should not see the ""(.*)"" activity in gradebook")]
        public void VerifyDisplayofActivityInGradebook(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify The Display of Activity In Gradebook
            Logger.LogMethodEntry("Gradebook",
                "VerifyDisplayofActivityInGradebook",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Select Window and Frame
            new CourseContentUXPage().SelectGradebookWindowInCourseHome();
            //Verify Display of Activity in Gradebook
            Logger.LogAssertion("IsAssetTypeDisplayed",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreNotEqual(activity.Name,gbStudentPage.
                   GetAssetNameInGradebook(activity.Name)));
            Logger.LogMethodExit("Gradebook",
                "VerifyDisplayofActivityInGradebook",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Asset In Gradebook.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I click on cmenu ""(.*)"" of ""(.*)"" Activity")]
        public void ClickOnCmenuOfAssetInGradebook(
            string assetCmenu, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu Of Asset In Gradebook
            Logger.LogMethodEntry("GradeBook", "ClickOnCmenuOfAssetInGradebook",
                  isTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Get Activity
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Window and Frame
            new CourseContentUXPage().SelectGradebookWindowInCourseHome();
            //Select The Cmenu Option Of Asset
            gbInstructorPage.SelectTheCmenuOptionOfAsset(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), activity.Name, activityTypeEnum);            
            Logger.LogMethodExit("GradeBook", "ClickOnCmenuOfAssetInGradebook",
                 isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display of Cmenu Option in Asset Cmenu Options.
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should see cmenu ""(.*)"" of asset ""(.*)""")]
        public void VerifyDisplayofCmenuOptionInAssetCmenuOptions(string cmenuOption,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Display of Cmenu Option in Asset Cmenu Options
            Logger.LogMethodEntry("GradeBook",
                "VerifyDisplayofCmenuOptionInAssetCmenuOptions",
           base.isTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Get Activity
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Frame
            gbInstructorPage.SelectGradebookFrame();
            //Assert Display Of Context Menu Option
            Logger.LogAssertion("VerifyDisplayOfContextMenuOption",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(cmenuOption, gbInstructorPage.
                    GetCmenuOptionofAsset(cmenuOption, activity.Name)));
            Logger.LogMethodExit("GradeBook",
                "VerifyDisplayofCmenuOptionInAssetCmenuOptions",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Custom View sub tab in a gradeBook.
        /// </summary>
        [When(@"I navigate to CustomView sub tab in a Page")]
        public void NavigateToCustomViewSubTab()
        {
            //Navigate to Custom View sub tab in a gradeBook
            Logger.LogMethodEntry("GBemailAddressPreference",
                "NavigateToCustomViewSubTab",
            base.isTakeScreenShotDuringEntryExit);
            // Navigate to Custom View Page in a GradeBook
            new GBInstructorUXPage().NavigateToCustomView();
            Logger.LogMethodExit("GBemailAddressPreference",
                "NavigateToCustomViewSubTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Asset in CustomView.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I click on cmenu ""(.*)"" of asset ""(.*)"" in Custom View")]
        public void ClickOnCmenuOfAssetInCustomView(string assetCmenu,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu Of Asset in CustomView
            Logger.LogMethodEntry("GradeBook", "ClickOnCmenuOfAssetInCustomView",
                  isTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Get Activity
            Activity activity = Activity.Get(activityTypeEnum);   
            //Select Window and Frame
            new CourseContentUXPage().SelectGradebookWindowInCourseHome();
            //Select The Cmenu Option Of Asset
            gbInstructorPage.SelectTheCmenuOptionOfAsset(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), activity.Name, activityTypeEnum);
            Logger.LogMethodExit("GradeBook", "ClickOnCmenuOfAssetInCustomView",
                 isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity Cmenu Option For Student.
        /// </summary>
        /// <param name="activityName">This is Activity Type Enum.</param>
        [When(@"I click on ""(.*)"" activity cmenu option")]
        public void ClickOnActivityCmenuOptionForStudent(
            Activity.ActivityTypeEnum activityName)
        {
            //Click On Activity Cmenu Option For Student
            Logger.LogMethodEntry("GradeBook",
                "ClickOnActivityCmenuOptionForStudent",
                isTakeScreenShotDuringEntryExit);
            //Get the activity from memory
            Activity activity = Activity.Get(activityName);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();            
            //Click on Activity Cmenu
            gbStudentPage.
                ClickOnWritingspaceActivityCmenuForStudent(activity.Name);                     
            Logger.LogMethodExit("GradeBook",
                "ClickOnActivityCmenuOptionForStudent",
                isTakeScreenShotDuringEntryExit);
        }       

        /// <summary>
        /// Verify Display of Activity Cmenu in Student Gradebook.
        /// </summary>
        /// <param name="activityCmenu">This is Activity Cmenu.</param>
        [Then(@"I should be able to see ""(.*)"" cmenu")]
        public void VerifyDisplayofActivityCmenuInStudentGradebook(string activityCmenu)
        {
            //Verify Display of Activity Cmenu in Student Gradebook
            Logger.LogMethodEntry("GradeBook",
                "VerifyDisplayofActivityCmenuInStudentGradebook",
                 base.isTakeScreenShotDuringEntryExit);
            //Assert Display Of Context Menu Option in Student Gradebook
            Logger.LogAssertion("VerifyDisplayOfContextMenuOption",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityCmenu,
                    new GBStudentUXPage().
                    GetActivityCmenuOptionInStudentGradebook(activityCmenu)));
            Logger.LogMethodExit("GradeBook",
                "VerifyDisplayofActivityCmenuInStudentGradebook",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Successfull Message In Gradebook.
        /// </summary>
        /// <param name="successMessage">This is Success Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in gradebook")]
        public void VerifyTheSuccessfullMessageInGradebook(string successMessage)
        {
            //Verify Display of Success Message in Gradebook
            Logger.LogMethodEntry("GradeBook",
                "VerifyTheSuccessfullMessageInGradebook",
                 base.isTakeScreenShotDuringEntryExit);
            //Assert Success Message in Gradebook
            Logger.LogAssertion("VerifyDisplayOfContextMenuOption",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(successMessage,
                    new GBInstructorUXPage().GetHideForStudentSuccessMessage()));
            Logger.LogMethodExit("GradeBook",
                "VerifyTheSuccessfullMessageInGradebook",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity Grade Cmenu.
        /// </summary>
        /// <param name="activityName">This is Activity Type Enum.</param>
        [When(@"I click on ""(.*)"" Activity grade cmenu")]
        public void ClickOnActivityGradeCmenu(
            Activity.ActivityTypeEnum activityName)
        {
            //Click On Activity Grade Cmenu
            Logger.LogMethodEntry("GradeBook", "ClickOnActivityGradeCmenu",
                isTakeScreenShotDuringEntryExit);
            //Get the activity from memory
            Activity activity = Activity.Get(activityName);
            //Fetch User from memory
            User user = User.Get(User.UserTypeEnum.MMNDStudent);
            //Select Window and Frame
            new CourseContentUXPage().SelectGradebookWindowInCourseHome();
            //Click on Activity Grade Cell Cmenu
            new GBInstructorUXPage().ClickOnActivityGradeCellCmenu(
                activity.Name, user.FirstName, user.LastName);
            Logger.LogMethodExit("GradeBook", "ClickOnActivityGradeCmenu",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display of Grade Cell Cmenu.
        /// </summary>
        /// <param name="gradeCellCmenuOption">This is Grade Cell Cmenu Option.</param>
        [Then(@"I should be able to see ""(.*)"" grade cmenu")]
        public void VerifyGradeCellCmenu(string gradeCellCmenuOption)
        {
            //Verify The Display of Grade Cell Cmenu
            Logger.LogMethodEntry("GradeBook","VerifyGradeCellCmenu",
                isTakeScreenShotDuringEntryExit);
            //Assert Display of Grade Cell Cmenu in Gradebook
            Logger.LogAssertion("VerifyDisplayOfGradeCellCmenuOption",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(gradeCellCmenuOption,
                    new GBInstructorUXPage().GetGradeCellCmenuOption(gradeCellCmenuOption)));
            Logger.LogMethodExit("GradeBook","VerifyGradeCellCmenu",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Apply Grade Schema For the Submitted Activity.
        /// </summary>
        [When(@"I 'Apply' the grade schema for the submitted activity")]
        public void ApplyGradeSchemaForSubmittedActivity()
        {
            //Apply Grade Schema For the Submitted Activity
            Logger.LogMethodEntry("GradeBook","ApplyGradeSchemaForSubmittedActivity",
                base.isTakeScreenShotDuringEntryExit);       
            //Click On Apply Button
            new GBSchemaPage().ClickonApplyButton();
            Logger.LogMethodExit("GradeBook","ApplyGradeSchemaForSubmittedActivity",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
