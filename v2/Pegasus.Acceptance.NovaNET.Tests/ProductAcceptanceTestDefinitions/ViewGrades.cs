using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.NovaNET.Tests.Definitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles the View Grades Actions.
    /// </summary>
    [Binding]
    public class ViewGrades : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(ViewGrades));

        /// <summary>
        /// Verify Grade of the Submitted Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see the grade under activity column of the submitted ""(.*)"" activity for ""(.*)""")]
        public void VerifyGradeOfTheSubmittedActivity(
            String activityName,
            User.UserTypeEnum userTypeEnum)       
        {
            //Verify Grade of the Submitted Activity
            Logger.LogMethodEntry("ViewGrades", 
                "VerifyGradeOfTheSubmittedActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Click on View Grades Button of Submitted Activity
            new GBInstructorUXPage().ClickOnActivityViewGradesButton();
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                    (ViewGradesResource.
                    ViewGradesResource_SubmittedActivity_Grade_Value,
                    new GBInstructorUXPage().
                    GetGradeDisplayedInTheGradeCellofSubmittedActivity(
                    activityName, userTypeEnum)));
            Logger.LogMethodExit("ViewGrades", 
                "VerifyGradeOfTheSubmittedActivity",
                base.isTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Click The Activity Cmneu In GradeBook.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="cmenuOption">This is Cmenu Options.</param>
        [When(@"I click the ""(.*)"" activity of cmneu ""(.*)""")]
        public void ClickTheActivityCmneuInGradeBook(
            Activity.ActivityTypeEnum activityTypeEnum,string cmenuOption)
        {
            //Click The Activity Cmneu In GradeBook
            Logger.LogMethodEntry("ViewGrades", 
                "ClickTheActivityCmneuInGradeBook",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the activity from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Click On Activity Cmenu In GradeBook
            new GBStudentUXPage().
                ClickOnActivityCmenuInGradeBook(activity.Name, cmenuOption);
            Logger.LogMethodExit("ViewGrades", 
                "ClickTheActivityCmneuInGradeBook",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Grade In View SubmissionPage.
        /// </summary>
        /// <param name="submittedGrade">This is Grade Displayed.</param>
        [Then(@"I should see the grade ""(.*)"" in view submission page")]
        public void VerifyTheGradeInViewSubmissionPage(String submittedGrade)
        {
            //Verify The Grade In View SubmissionPage
            Logger.LogMethodEntry("ViewGrades", 
                "VerifyTheGradeInViewSubmissionPage",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Edited Grade in ViewSubmission Page
            Logger.LogAssertion("VerifyGradeinViewSubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(submittedGrade,
                    new ViewSubmissionPage().
                    GetSubmittedGradeInViewSubmissionPage()));
            Logger.LogMethodExit("ViewGrades", 
                "VerifyTheGradeInViewSubmissionPage",
                base.isTakeScreenShotDuringEntryExit);
        }       

        /// <summary>
        /// Click On Cmenu Of Asset In Gradebook.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu type enum.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I click on cmenu ""(.*)"" of asset ""(.*)""")]
        public void ClickOnCmenuOfAssetInGradebook(string assetCmenu, 
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu Of Asset In Gradebook
            Logger.LogMethodEntry("ViewGrades", "ClickOnCmenuOfAssetInGradebook",
                  isTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Fetch the activity from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Frame
            gbInstructorPage.SelectGradebookFrame();            
            //Select The Cmenu Option Of Asset
            gbInstructorPage.SelectTheCmenuOptionOfAssetInGradebook(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), activity.Name, activityTypeEnum);
            Logger.LogMethodExit("ViewGrades", "ClickOnCmenuOfAssetInGradebook",
                 isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit The Score In Edit Grade Window.
        /// </summary>
        [When(@"I edit the score in Edit Grade Window")]
        public void EditTheScoreInEditGradeWindow()
        {
            //Edit The Score In Edit Grade Window
            Logger.LogMethodEntry("ViewGrades",
                "EditTheScoreInEditGradeWindow",
                  isTakeScreenShotDuringEntryExit);
            //Grade the Activity
            new GBGradeBatchUpdationPage().GradetheActivityInNovaNet();
            Logger.LogMethodExit("ViewGrades",
                "EditTheScoreInEditGradeWindow",
                 isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Apply Grade Schema For the Submitted Activity.
        /// </summary>
        [When(@"I 'Apply' the grade schema for the submitted activity")]
        public void ApplyGradeSchemaForSubmittedActivity()
        {
            //Apply Grade Schema For the Submitted Activity
            Logger.LogMethodEntry("ViewGrades",
               "ApplyGradeSchemaForSubmittedActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Apply Button
            new GBSchemaPage().ClickOnApplyButton();
            Logger.LogMethodExit("ViewGrades",
               "ApplyGradeSchemaForSubmittedActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Searched Grade Of Submitted Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Name.</param>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see searched grade under activity column of submitted ""(.*)"" activity for ""(.*)""")]
        public void VerifySearchedGradeOfSubmittedActivity(
            Activity.ActivityTypeEnum activityTypeEnum,
            User.UserTypeEnum userTypeEnum)
        {
            //Verify Searched Grade Of Submitted Activity
            Logger.LogMethodEntry("ViewGrades",
               "VerifySearchedGradeOfSubmittedActivity",
               base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                    (ViewGradesResource.
                    ViewGradesResource_SubmittedActivity_Grade_Value,
                 new GBInstructorUXPage().
             GetSearchedActivityGradeDisplayedInTheGradeCell(
                 activity.Name, userTypeEnum)));            
            Logger.LogMethodExit("ViewGrades",
                "VerifySearchedGradeOfSubmittedActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Updated Apply Grade Schema For Activity.
        /// </summary>
        /// <param name="schemaValue">This is Schema Value.</param>
        /// <param name="activityName">This is Activity Name.</param>
        [Then(@"I should see the updated apply grade schema value ""(.*)"" for Activity ""(.*)""")]
        public void VerifyTheUpdatedApplyGradeSchemaForActivity(
            string schemaValue, Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Verify The Updated Apply Grade Schema For Activity
            Logger.LogMethodEntry("ViewGrades",
              "VerifyTheUpdatedApplyGradeSchemaForActivity",
               base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Verify Schema Value
            Logger.LogAssertion("VerifyApplyGradeSchemaValue",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(schemaValue,
                   new GBInstructorUXPage().
                         GetGradeValuePresentInGradeCell(activity.Name)));
            Logger.LogMethodExit("ViewGrades",
               "VerifyTheUpdatedApplyGradeSchemaForActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit The Grade In View Submission Window.
        /// </summary>
        [When(@"I edit the grade in view submission window")]
        public void EditTheGradeInViewSubmissionWindow()
        {
            // Edit The Grade In View Submission Window
            Logger.LogMethodEntry("ViewGrades", "EditTheGradeInViewSubmissionWindow",
                 base.isTakeScreenShotDuringEntryExit);
            //Edit Grades In View Submission page
            new ViewSubmissionPage().EditGradesInViewSubmissionPage();
            Logger.LogMethodExit("ViewGrades", "EditTheGradeInViewSubmissionWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Edited Grade in ViewSubmission Page.
        /// </summary>
        /// <param name="editedGrade">This is Edited Grade.</param>
        [Then(@"I should see the edited grade ""(.*)"" in view submission page")]
        public void VerifyTheEditedGradeInViewSubmissionPage(String editedGrade)
        {
            //Verify the Edited Grade in ViewSubmission Page
            Logger.LogMethodEntry("ViewGrades",
                "VerifyTheEditedGradeInViewSubmissionPage",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Edited Grade in ViewSubmission Page
            Logger.LogAssertion("VerifyGradeinViewSubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(editedGrade,
                    new ViewSubmissionPage().GetGradefromViewSubmissionPage()));
            Logger.LogMethodExit("ViewGrades",
                "VerifyTheEditedGradeInViewSubmissionPage",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Click The View Filters Link In Gradebook.
        /// </summary>
        [When(@"I click the 'View Filters' link in gradebook")]
        public void ClickTheViewFiltersLinkInGradebook()
        {
            // Click The View Filters Link In Gradebook
            Logger.LogMethodEntry("ViewGrades",
                "ClickTheViewFiltersLinkInGradebook",
                base.isTakeScreenShotDuringEntryExit);
            new GBGroupsDefaultUXPage().ClickOnViewFiltersLinkInGradebook();
            Logger.LogMethodExit("ViewGrades",
                "ClickTheViewFiltersLinkInGradebook",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Student In Gradebook.
        /// </summary>
        /// <param name="userTypeEnum">This is User Name.</param>
        [When(@"I search the ""(.*)"" in gradebook")]
        public void SearchTheStudentInGradebook(User.UserTypeEnum userTypeEnum)
        {
            //Search The Student In Gradebook
            Logger.LogMethodEntry("ViewGrades", "SearchTheStudentInGradebook",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From  Memory 
            User user = User.Get(userTypeEnum);
            //Search The Student In Gradebook
            new GBGroupsDefaultUXPage().SearchStudentInGradebook(user.Name);
            Logger.LogMethodExit("ViewGrades", "SearchTheStudentInGradebook",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click On Show Status for All Item Filter Option.
        /// </summary>
        [When(@"I select 'Show Status for All Items' filter option")]
        public void ClickOnShowStatusforAllItemFilterOption()
        {
            //Click On Show Status for All Item Filter Option
            Logger.LogMethodEntry("ViewGrades",
                "ClickOnShowStatusforAllItemFilterOption",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Show Status for All Item Filter Option
            new GBGroupsDefaultUXPage().ClickOnShowStatusforAllItemFilterOption();
            Logger.LogMethodExit("ViewGrades",
                "ClickOnShowStatusforAllItemFilterOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Show Status Of Activity Display In Gradebook.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="userTypeEnum">This is User type.</param>
        [Then(@"I should see the ""(.*)"" activity in Gradebook for all the enrollled ""(.*)""")]
        public void VerifyShowStatusOfActivityDisplayInGradebook(
            Activity.ActivityTypeEnum activityTypeEnum, User.UserTypeEnum userTypeEnum)
        {
            //Verify Show Status Of Activity Display In Gradebook
            Logger.LogMethodEntry("ViewGrades",
                "VerifyShowStatusOfActivityDisplayInGradebook",
                 isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            Activity activity = Activity.Get(activityTypeEnum);
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            //Assert Activity Name for Enrolled User in Gradebook
            Logger.LogAssertion("VerifyActivityDisplayInGradebook",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(ViewGradesResource.
                 ViewGradesResource_SubmittedActivity_Status_Value,
                 new GBInstructorUXPage().GetActivityStatus
                 (activity.Name, user.LastName, user.FirstName)));
            Logger.LogMethodExit("ViewGrades",
                "VerifyShowStatusOfActivityDisplayInGradebook",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Assignment Types Link In Gradebook.
        /// </summary>
        [When(@"I click on 'Assignment Types' link in gradebook")]
        public void ClickOnAssignmentTypesLinkInGradebook()
        {
            //Click On Assignment Types Link In Gradebook
            Logger.LogMethodEntry("ViewGrades",
                "ClickOnAssignmentTypesLinkInGradebook",
                 isTakeScreenShotDuringEntryExit);
            // Click On Assignment Types Link In Gradebook
            new GBGroupsDefaultUXPage().ClickOnAssignmentTypesLinkInGradebook();
            Logger.LogMethodExit("ViewGrades",
               "ClickOnAssignmentTypesLinkInGradebook",
               isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Assignment Type.
        /// </summary>
        /// <param name="assignmentType">This is Activity Type.</param>
        [When(@"I select ""(.*)"" Assignment Type")]
        public void SelectAssignmentType(string assignmentType)
        {
            //Select Assignment Type
            Logger.LogMethodEntry("ViewGrades",
                "SelectAssignmentType",
                 isTakeScreenShotDuringEntryExit);
            // Click On Assignment Types Link In Gradebook
            new GBGroupsDefaultUXPage().
                SelectAssignmentTypeInGradebook(assignmentType);
            Logger.LogMethodExit("ViewGrades",
               "SelectAssignmentType",
               isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display Of Assignment Type Activity In Gradebook.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should see the ""(.*)"" activity in Gradebook")]
        public void VerifyDisplayOfAssignmentTypeActivityInGradebook(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Display Of Assignment Type Activity In Gradebook
            Logger.LogMethodEntry("ViewGrades",
                "VerifyDisplayOfAssignmentTypeActivityInGradebook",
                 isTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            // Get Assignment Types Activity In Gradebook
            Logger.LogAssertion("VerifyAssetTypeActivityDisplayInGradebook",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(activity.Name, new GBInstructorUXPage().
                GetAssignmentTypeActivityInGradebook(activity.Name)));
            Logger.LogMethodExit("ViewGrades",
               "VerifyDisplayOfAssignmentTypeActivityInGradebook",
               isTakeScreenShotDuringEntryExit);
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
