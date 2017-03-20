using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles Gradebook Actions.
    /// </summary>

    [Binding]
    public class Gradebook : PegasusBaseTestFixture
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Gradebook));

        /// <summary>
        /// Display Of Submitted Sim Activity Score.
        /// </summary>
        /// <param name="activityScore">This is Activity Score.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode Enum.</param>
        [Then(@"I should see the score ""(.*)"" of ""(.*)"" activity of behavioral mode ""(.*)"" type")]
        public void DisplayOfSubmiitedSimActivityScore(string activityScore,
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Display Of Submitted Sim Activity Score
            Logger.LogMethodEntry("Gradebook",
                "DisplayOfSubmiitedSimActivityScore",
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralModeEnum);
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            // Assert Activity Score
            Logger.LogAssertion("VerifyActivityScore", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityScore,
                    new GBInstructorUXPage().GetActivityStatus(activity.Name,
                    GradebookResource.Gradebook_Resource_User_Last_Name_Value,
                    GradebookResource.Gradebook_Resource_User_First_Name_Value)));
            Logger.LogMethodExit("Gradebook",
                "DisplayOfSubmiitedSimActivityScore",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Associate the Activity to MyCourse Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="activityModeTypeEnum">This is activity mode enum.</param>
        [When(@"I associate the ""(.*)"" activity of behavioral mode ""(.*)"" to MyCourse frame")]
        public void AssociateTheActivityToMyCourseFrame(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum activityModeTypeEnum)
        {
            //Associate the Activity to MyCourse Frame
            Logger.LogMethodEntry("Gradebook", "AssociateTheActivityToMyCourseFrame",
                IsTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibraryUxPage = new ContentLibraryUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum, activityModeTypeEnum);
            //Select Window
            contentLibraryUxPage.SelectTheWindowName(GradebookResource.
                GradeBook_CourseMaterials_Window_Title);
            //Select the frame
            contentLibraryUxPage.SelectAndSwitchtoFrame(GradebookResource.
                GradeBook_CourseMaterials_LeftFrame_Id_Locator);
            // Select the activity
            contentLibraryUxPage.SelectActivity(activity.Name);
            // Click on Activity Add Button
            contentLibraryUxPage.ClickOnActivityAddButton();
            Logger.LogMethodExit("GradeBook", "AssociateTheActivityToMyCourseFrame",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On View Grades Of Asset
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        [When(@"I click on the ""(.*)"" 'View Grades' option")]
        public void ClickViewGradesOptionOfAsset(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On The Grades Tab Cmenu Option  
            Logger.LogMethodEntry("Gradebook",
                "ClickViewGradesOptionOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Gradebook Window
            gbStudentPage.SelectGradebookWindow();
            //Click The Grades Tab Cmenu Option          
            gbStudentPage.NavigateInsideViewGrade(activity.Name);
            Logger.LogMethodExit("Gradebook",
                "ClickViewGradesOptionOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Pre Test Score.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        /// <param name="activityScore">This is activity score</param>
        [Then(@"I should see the pre test ""(.*)"" score ""(.*)""")]
        public void VerifyThePreTestScore(Activity.ActivityTypeEnum activityTypeEnum, string activityScore)
        {
            //Verify Pre Test Score
            Logger.LogMethodEntry("Gradebook", "VerifyThePreTestScore",
                base.IsTakeScreenShotDuringEntryExit);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Gradebook Window
            gbStudentPage.SelectGradebookWindow();
            //Verify The Searched Asset Name
            Logger.LogAssertion("VerifyAssetScore",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityScore,
                     gbStudentPage.GetActivityScoreInGradebook
                     (activity.Name + GradebookResource.Gradebook_Resource_PreTest_Name)));
            Logger.LogMethodExit("Gradebook", "VerifyThePreTestScore",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu of Asset.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I click on cmenu ""(.*)"" of asset ""(.*)""")]
        public void ClickOnCmenuOfAsset(string assetCmenu, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu of Asset
            Logger.LogMethodEntry("Gradebook", "ClickOnCmenuOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Gradebook window
            gbStudentPage.SelectGradebookWindow();
            //Click On Activity Cmenu
            gbStudentPage.ClickOnActivityCmenuOptionInGradeBookOfStudent(
                activity.Name + GradebookResource.Gradebook_Resource_PreTest_Name, assetCmenu);
            Logger.LogMethodExit("Gradebook", "ClickOnCmenuOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Cmenu Of Asset In GradeBook.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I click the cmenu ""(.*)"" of asset ""(.*)""")]
        public void SelectTheCmenuOfAssetInGradeBook(string assetCmenu,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Select The Cmenu Of Asset In GradeBook
            Logger.LogMethodEntry("Gradebook", "SelectTheCmenuOfAssetInGradeBook",
                base.IsTakeScreenShotDuringEntryExit);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Select Gradebook window
            gbStudentPage.SelectGradebookWindow();
            //Select The Cmenu Option Of Asset
            gbInstructorPage.SelectTheCmenuOptionOfAsset(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), activity.Name, activityTypeEnum);
            Logger.LogMethodExit("Gradebook", "SelectTheCmenuOfAssetInGradeBook",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Status Of SIM5 activity
        /// </summary>
        /// <param name="questionStatus">This is Question Status</param>
        [Then(@"I should the status of submitted SIM5 activity question as ""(.*)""")]
        public void VerifyStatusOfSubmittedSIM5Activity(string questionStatus)
        {
            //Verify Status of Submitted Activity
            Logger.LogMethodEntry("Gradebook", "VerifyStatusOfSubmittedSIM5Activity",
                base.IsTakeScreenShotDuringEntryExit);
            ViewSubmissionPage viewSubmissionPage = new ViewSubmissionPage();
            //Select Submission Frame
            viewSubmissionPage.SelectTheSubmissionFrame();
            //Verify Question Status
            Logger.LogAssertion("VerifyAssetStatus",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(questionStatus, viewSubmissionPage.GetQuestionStatus()));
            Logger.LogMethodExit("Gradebook", "VerifyStatusOfSubmittedSIM5Activity",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the total time taken by SIM Study plan pre test.
        /// </summary>
        /// <param name="timeInMinute">This is  taken time.</param>
        [Then(@"I should see the total time ""(.*)"" for SIM Study Plan Pre Test on View Submission page")]
        public void VerifyTotalTimeForSIMStudyPlanPreTest(String timeInMinute)
        {
            //Verify Status of Submitted Activity
            Logger.LogMethodEntry("Gradebook", "VerifyTotalTimeForSIMStudyPlanPreTest",
                base.IsTakeScreenShotDuringEntryExit);
            ViewSubmissionPage viewSubmissionPage = new ViewSubmissionPage();
            //Select Submission Frame
            viewSubmissionPage.SelectTheSubmissionFrame();
            //Verify Total Time taken by activity
            Logger.LogAssertion("VerifyAssetStatus",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(timeInMinute, viewSubmissionPage.GetTotalTimeTaken()));
            Logger.LogMethodExit("Gradebook", "VerifyStatusOfSubmittedSIM5Activity",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Pre Test Score
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        /// <param name="activityScore">This is activity score</param>
        [Then(@"I should see the pre test training ""(.*)"" score ""(.*)""")]
        public void VerifyThePreTestTrainingScore(Activity.ActivityTypeEnum activityTypeEnum, string activityScore)
        {
            //Verify Pre Test Score
            Logger.LogMethodEntry("Gradebook", "VerifyThePreTestTrainingScore",
                base.IsTakeScreenShotDuringEntryExit);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Gradebook Window
            gbStudentPage.SelectGradebookWindow();
            //Verify The Searched Asset Name
            Logger.LogAssertion("VerifyAssetScore",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityScore,
                     gbStudentPage.GetActivityScoreInGradebook
                     (activity.Name + GradebookResource.Gradebook_Resource_PreTestTraining_Name)));
            Logger.LogMethodExit("Gradebook", "VerifyThePreTestTrainingScore",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu of Asset
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        [When(@"I click on cmenu ""(.*)"" of asset training ""(.*)""")]
        public void ClickOnCmenuOfTrainingAsset(string assetCmenu, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu of Asset
            Logger.LogMethodEntry("Gradebook", "ClickOnCmenuOfTrainingAsset",
                base.IsTakeScreenShotDuringEntryExit);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Gradebook window
            gbStudentPage.SelectGradebookWindow();
            //Click On Activity Cmenu
            gbStudentPage.ClickOnActivityCmenuOptionInGradeBookOfStudent(
                activity.Name + GradebookResource.Gradebook_Resource_PreTestTraining_Name, assetCmenu);
            Logger.LogMethodExit("Gradebook", "ClickOnCmenuOfTrainingAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On ViewGrade Button In Gradebook.
        /// </summary>
        /// <param name="activityTypeEnum">Thia is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Activity Behavioral Mode Type.</param>
        [When(@"I click on view grade ""(.*)"" of behavioral mode type ""(.*)"" in Gradebook")]
        public void ClickOnViewGradeButtonInGradebook(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Click On ViewGrade Button In Gradebook
            Logger.LogMethodEntry("GradeBook", "ClickOnViewGradeButtonInGradebook",
                IsTakeScreenShotDuringEntryExit);
            //Fetch the activity from memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralModeEnum);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Click on View Grades Button of Submitted Activity
            gbInstructorPage.ClickOnAssetViewGradesButton(activity.Name);
            Logger.LogMethodExit("GradeBook", "ClickOnViewGradeButtonInGradebook",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Studyplan Training Material.
        /// </summary>
        /// <param name="assetCmenu">This is Cmenu Options Type.</param>
        /// <param name="activityTypeEnum">Thia is Activity Type Enum.</param>
        [When(@"I click on cmenu ""(.*)"" of studyplan Training Material ""(.*)""")]
        public void ClickOnCmenuOfStudyplanTrainingMaterial(string assetCmenu,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu Of Studyplan Training Material
            Logger.LogMethodEntry("GradeBook",
                "ClickOnCmenuOfStudyplanTrainingMaterial",
                IsTakeScreenShotDuringEntryExit);
            //Fetch the activity from memory
            Activity activity = Activity.Get(activityTypeEnum);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Select Frame
            gbInstructorPage.SelectGradebookFrame();
            //Select The Cmenu Option Of Asset
            gbInstructorPage.SelectTheCmenuOptionOfAsset(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu),
                activity.Name + GradebookResource.
                Gradebook_Resource_TariningMaterial_Name, activityTypeEnum);
            Logger.LogMethodExit("GradeBook",
                "ClickOnCmenuOfStudyplanTrainingMaterial",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Apply Grade Schema For the Submitted Activity.
        /// </summary>
        [When(@"I 'Apply' the grade schema for the submitted activity")]
        public void ApplyGradeSchemaForSubmittedActivity()
        {
            //Apply Grade Schema For the Submitted Activity
            Logger.LogMethodEntry("GradeBook",
               "ApplyGradeSchemaForSubmittedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Apply Button
            new GBSchemaPage().ClickOnApplyButton();
            Logger.LogMethodExit("GradeBook",
               "ApplyGradeSchemaForSubmittedActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Activity Display in Gradebook for Enrollled Students.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type enum.</param>
        /// <param name="userTypeEnum">This is User type.</param>
        [Then(@"I should see the ""(.*)"" activity status ""(.*)"" in Gradebook for all the enrollled ""(.*)""")]
        public void VerifyActivityStatusInGradebookForEnrollledStudents(
            Activity.ActivityTypeEnum activityTypeEnum,
           string activityStatus, User.UserTypeEnum userTypeEnum)
        {
            //Verify Activity Display in Gradebook for Enrollled Students
            Logger.LogMethodEntry("GradeBook",
                "VerifyActivityStatusInGradebookForEnrollledStudents",
                 IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            //Assert Activity Status for Enrolled User in Gradebook
            Logger.LogAssertion("VerifyActivityDisplayInGradebook",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(activityStatus,
                 new GBInstructorUXPage().GetActivityStatus
                 (activity.Name + GradebookResource.
                 Gradebook_Resource_TariningMaterial_Name,
                 user.LastName, user.FirstName)));
            Logger.LogMethodExit("GradeBook",
                "VerifyActivityStatusInGradebookForEnrollledStudents",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Update The Schema Value For the Submitted Activity
        /// </summary>
        [When(@"I update the schema of the submitted activity")]
        public void UpdateTheSchemaOfTheSubmittedActivity()
        {
            //Update The Schema Value For the Submitted Activity
            Logger.LogMethodEntry("GradeBook",
               "UpdateTheSchemaOfTheSubmittedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Update Schema
            new GBSchemaPage().ClickOnUpdateSchema();
            //Edit and Update Schema
            new GBSchemaCreatEditPage().EditAndUpdateTheApplyGradeSchema();
            Logger.LogMethodExit("GradeBook",
              "UpdateTheSchemaOfTheSubmittedActivity",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Cmenu Option Of Asset.
        /// </summary>        
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I click on the 'View Submissions' cmenu option of ""(.*)"" which has been submitted")]
        public void ClickOnTheCmenuOptionOfAsset(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On The Cmenu Option Of Asset
            Logger.LogMethodEntry("GradeBook", "ClickOnTheCmenuOptionOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Activity
            new CoursePreviewMainUXPage().OpenActivity(activityTypeEnum);
            //Click On Cmenu Of Asset
            new SIMStudyPlanStudentUXPage().ClickOnCmenuOfAsset();
            Logger.LogMethodExit("GradeBook", "ClickOnTheCmenuOptionOfAsset",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Total Submission.
        /// </summary>
        /// <param name="submissionCount">This is Submission Count.</param>
        [Then(@"I should see the total submission ""(.*)""")]
        public void VerifyTheTotalSubmission(string submissionCount)
        {
            //Verify The Total Submission
            Logger.LogMethodEntry("GradeBook", "VerifyTheTotalSubmission",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert to Verify the Submission in View Submission Page
            Logger.LogAssertion("VerifySubmissionInViewSubmission",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(submissionCount,
                 new ViewSubmissionPage().GetSubmissionCountInViewSubmission()));
            Logger.LogMethodExit("GradeBook", "VerifyTheTotalSubmission",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Score in ViewSubmission Page.
        /// </summary>
        /// <param name="newGrade">This is score.</param>
        [Then(@"I should see the score ""(.*)"" in view submission page")]
        public void VerifyTheScoreInViewSubmissionPage(String newGrade)
        {
            //Verify the Score in ViewSubmission Page
            Logger.LogMethodEntry("GradeBook", "VerifyTheScoreInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Score in ViewSubmission Page
            Logger.LogAssertion("VerifyScoreinViewSubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(newGrade,
                    new ViewSubmissionPage().GetGradefromStudentViewSubmissionPage()));
            Logger.LogMethodExit("GradeBook", "VerifyTheScoreInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select View Grade Option Of Study Plan Pre Test
        /// </summary>
        [When(@"I select 'View Grades' option of study plan pre test")]
        public void SelectViewGradeOptionOfStudyPlanPreTest()
        {
            //Select View Grade Option Of Study Plan Pre Test
            Logger.LogMethodEntry("GradeBook", "SelectViewGradeOptionOfStudyPlanPreTest",
                base.IsTakeScreenShotDuringEntryExit);
            //Select View Grades Cmenu Option
            new SIMStudyPlanStudentUXPage().SelectViewGradesCmenuOption();
            Logger.LogMethodExit("GradeBook", "SelectViewGradeOptionOfStudyPlanPreTest",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Grade In View Submission Page  
        /// </summary>
        /// <param name="score">This is Score</param>      
        [Then(@"I should see the score ""(.*)"" in View Submission page")]
        public void VerifyTheGradeInViewSubmissionPage(string score)
        {
            //Verify The Grade In View Submission Page  
            Logger.LogMethodEntry("GradeBook",
                "VerifyTheGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert for score
            Logger.LogAssertion("VerifyTheScore", ScenarioContext.
                Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(GradebookResource.Gradebook_Resource_Gradebook_Grade_Text + score,
                 new ViewSubmissionPage().GetScoreResultInViewSubmissionPage()));
            Logger.LogMethodExit("GradeBook",
                "VerifyTheGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Submitted Activity In View Submission Page
        /// </summary>
        [When(@"I select the submitted activity in View Submission Page")]
        public void SelectTheSubmittedActivityInViewSubmissionPage()
        {
            //Select The Submitted Activity In View Submission Page
            Logger.LogMethodEntry("GradeBook",
                "SelectTheSubmittedActivityInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Select The Submitted Activity In View Submission Page
            new ViewSubmissionPage().SelectSubmissionInViewSubmissionWindow();
            Logger.LogMethodExit("GradeBook",
               "SelectTheSubmittedActivityInViewSubmissionPage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Send Message Option In View Submission Page
        /// </summary>
        [When(@"I select 'Send Message' option in View Submission Page")]
        public void SelectSendMessageOptionInViewSubmissionPage()
        {
            //Select Send Message Option In View Submission Page
            Logger.LogMethodEntry("GradeBook",
                "SelectSendMessageOptionInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Send Message Option In View Submission Page
            new ViewSubmissionPage().SelectSendMessageOption();
            Logger.LogMethodExit("GradeBook",
               "SelectSendMessageOptionInViewSubmissionPage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Send Message Buttons
        /// </summary>
        /// <param name="sendMessageButtons">Send Message Buttons</param>
        [Then(@"I should see the ""(.*)"" buttons")]
        public void VerifySendMessageButton(string sendMessageButtons)
        {
            //Verify Send Message Button
            Logger.LogMethodEntry("GradeBook",
              "VerifySendMessageButton",
              base.IsTakeScreenShotDuringEntryExit);
            //Verify Send Message Buttons
            Logger.LogAssertion("VerifySendMessageButton", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(sendMessageButtons, new ComposeNewMailUXPage().
                    GetSendSaveasdraftCancelButtonText()));
            Logger.LogMethodExit("GradeBook",
              "VerifySendMessageButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Associate The Asset From ContentLibrary To MyCourse Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I associate the ""(.*)"" activity to MyCourse frame")]
        public void AssociateTheAssetFromContentLibraryToMyCourseFrame(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Associate The Asset From ContentLibrary To MyCourse Frame
            Logger.LogMethodEntry("Gradebook",
                "AssociateTheAssetFromContentLibraryToMyCourseFrame",
                IsTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Window
            contentLibraryUXPage.SelectTheWindowName(GradebookResource.
                GradeBook_CourseMaterials_Window_Title);
            //Select the frame
            contentLibraryUXPage.SelectAndSwitchtoFrame(GradebookResource.
                GradeBook_CourseMaterials_LeftFrame_Id_Locator);
            // Select the activity
            contentLibraryUXPage.SelectActivity(activity.Name);
            // Click on Activity Add Button
            contentLibraryUXPage.ClickOnActivityAddButton();
            Logger.LogMethodExit("GradeBook",
                "AssociateTheAssetFromContentLibraryToMyCourseFrame",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Asset In Grades Tab.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I click on cmenu ""(.*)"" of asset ""(.*)"" in grades tab")]
        public void ClickOnCmenuOfAssetInGradesTab(string assetCmenu,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu Of Asset In Grades Tab
            Logger.LogMethodEntry("Gradebook", "ClickOnCmenuOfAssetInGradesTab",
                base.IsTakeScreenShotDuringEntryExit);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Gradebook window
            gbStudentPage.SelectGradebookWindow();
            //Click On Activity Cmenu
            gbStudentPage.ClickOnActivityCmenuOptionInGradeBookOfStudent(
                activity.Name, assetCmenu);
            Logger.LogMethodExit("Gradebook", "ClickOnCmenuOfAssetInGradesTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The SaveForLater Display Message.
        /// </summary>
        /// <param name="messageText">Display Message.</param>
        [Then(@"I should see the message ""(.*)""")]
        public void VerifyTheSaveForLaterDisplayMessage(string messageText)
        {
            // Verify The SaveForLater Display Message
            Logger.LogMethodEntry("Gradebook", "VerifyTheSaveForLaterDisplayMessage",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify Send Message 
            Logger.LogAssertion("VerifySendMessageButton",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(messageText, new ViewSubmissionPage().
                    GetSaveForLaterDisplayMessage()));
            Logger.LogMethodExit("Gradebook", "VerifyTheSaveForLaterDisplayMessage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit The Manual Grade In ViewSubmission Page.
        /// </summary>
        [When(@"I edit the grade in view submission page")]
        public void EditTheManualGradeInViewSubmissionPage()
        {
            //Edit The Manual Grade In ViewSubmission Page
            Logger.LogMethodEntry("Gradebook",
                "EditTheManualGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Edit The Manual Grade In ViewSubmission page
            new ViewSubmissionPage().EditTheManualGradeInViewSubmissionPage();
            Logger.LogMethodExit("Gradebook",
                "EditTheManualGradeInViewSubmissionPage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The View Button In Report.
        /// </summary>
        [When(@"I click the 'View' button in report")]
        public void ClickTheViewButtonInReport()
        {
            //Click The View Button In Report
            Logger.LogMethodEntry("Gradebook", "ClickTheViewButtonInReport",
                base.IsTakeScreenShotDuringEntryExit);
            //Click The View Button In Report
            new RptStuStudyPlanPage().ClickTheViewButtonInReport();
            Logger.LogMethodExit("Gradebook", "ClickTheViewButtonInReport",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Attempt By The Student In Submission Page.
        /// </summary>
        /// <param name="submissionCount">Submission Count.</param>
        [Then(@"I should see the attempt by the student submission ""(.*)""")]
        public void VerifyTheAttemptByTheStudentInSubmissionPage(
                     string submissionCount)
        {
            //Verify The Attempt By The Student In Submission Page
            Logger.LogMethodEntry("GradeBook",
                "VerifyTheAttemptByTheStudentInSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert to Verify the Submission in View Submission Page
            Logger.LogAssertion("VerifySubmissionInViewSubmission",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(submissionCount,
                 new ViewSubmissionPage().GetAttemptByTheStudentInSubmissionPage()));
            Logger.LogMethodExit("GradeBook",
                "VerifyTheAttemptByTheStudentInSubmissionPage",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Close Button In Report Page.
        /// </summary>
        [When(@"I click the close button in report page")]
        public void ClickTheCloseButtonInReportPage()
        {
            //Click The Close Button In Report Page
            Logger.LogMethodEntry("GradeBook", "ClickTheCloseButtonInReportPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Close Button In Report Page
            new RptStuStudyPlanPage().ClickOnCloseButtonInReportPage();
            Logger.LogMethodExit("GradeBook", "ClickTheCloseButtonInReportPage",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Apply 'Assignment Types' Filter In Gradebook.
        /// </summary>
        [When(@"I apply 'Assignment Types' filter in gradebook")]
        public void ApplyAssignmentTypesFilterInGradebook()
        {
            //Apply 'Assignment Types' Filter In Gradebook
            Logger.LogMethodEntry("GradeBook", "ApplyAssignmentTypesFilterInGradebook",
                base.IsTakeScreenShotDuringEntryExit);
            //Apply Gradebook 'Assignment Types' Filter
            new GBInstructorUXPage().ApplyGradebookAssignmentTypesFilter();
            Logger.LogMethodExit("GradeBook", "ApplyAssignmentTypesFilterInGradebook",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Filter Selection In Gradebook.
        /// </summary>
        [Then(@"I should see the filter selection changes made earlier")]
        public void VerifyTheFilterSelectionInGradebook()
        {
            //Verify The Filter Selection In Gradebook
            Logger.LogMethodEntry("GradeBook", "VerifyTheFilterSelectionInGradebook",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert to Verify The Filter Selection In Gradebook
            Logger.LogAssertion("VerifyFilterSelectionInGradebook",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.IsTrue(new GBInstructorUXPage().
                 IsAssignmentTypesFilterApplyInGradebook()));
            Logger.LogMethodExit("GradeBook", "VerifyTheFilterSelectionInGradebook",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit The Score In ViewSubmission Page.
        /// </summary>
        [When(@"I edit the score in view submission page")]
        public void EditTheScoreInViewSubmissionPage()
        {
            //Edit The Score In ViewSubmission Page
            Logger.LogMethodEntry("Gradebook",
                "EditTheScoreInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Edit The Manual Grade In ViewSubmission page
            new ViewSubmissionPage().EditTheScoreInViewSubmissionPage();
            Logger.LogMethodExit("Gradebook",
                "EditTheScoreInViewSubmissionPage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Grade Of The Submitted Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userTypeEnum">This is User Name.</param>
        [Then(@"I should see the grade under activity column of the submitted ""(.*)"" activity for ""(.*)""")]
        public void VerifyGradeOfTheSubmittedActivity(
            Activity.ActivityTypeEnum activityName,
            User.UserTypeEnum userTypeEnum)
        {
            //Verify Grade of the Submitted Activity
            Logger.LogMethodEntry("Gradebook",
                "VerifyGradeOfTheSubmittedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityName);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (GradebookResource.GradeBook_ActivityGrade_Score_Value,
                    new GBInstructorUXPage().GetActivityStatus(
                    activity.Name, user.LastName, user.FirstName)));
            Logger.LogMethodExit("Gradebook",
                "VerifyGradeOfTheSubmittedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Verify The Activity Score In Gradebook .
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="activityScore">This is Activitry Score.</param>
        [Then(@"I should see the activity ""(.*)"" score ""(.*)""")]
        public void VerifyTheActivityScoreInGradebook(string activityName,
            string activityScore)
        {
            //Verify The Activity Score In Gradebook
            Logger.LogMethodEntry("Gradebook", "VerifyTheActivityScoreInGradebook",
                base.IsTakeScreenShotDuringEntryExit);
            var gbStudentPage = new GBStudentUXPage();
            //Select Gradebook Window
            gbStudentPage.SelectGradebookWindow();
            //Verify The Searched Asset Name
            Logger.LogAssertion("VerifyAssetScore",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityScore,
                     gbStudentPage.GetActivityScoreInGradebook
                     (activityName)));
            Logger.LogMethodExit("Gradebook", "VerifyTheActivityScoreInGradebook",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Cmenu Of Asset In Gradebook.
        /// </summary>
        /// <param name="assetCmenu">This is Cmenu Option.</param>
        /// <param name="activityName">This is Activity Name.</param>
        [When(@"I click on cmenu ""(.*)"" of asset ""(.*)"" in gradebook")]
        public void SelectTheCmenuOfAssetInGradebook(string assetCmenu, string activityName)
        {
            //Select The Cmenu Of Asset In Gradebook
            Logger.LogMethodEntry("Gradebook", "SelectTheCmenuOfAssetInGradebook",
                base.IsTakeScreenShotDuringEntryExit);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            //Select Gradebook window
            gbStudentPage.SelectGradebookWindow();
            //Click On Activity Cmenu
            gbStudentPage.ClickOnActivityCmenuOptionInGradeBookOfStudent(
                activityName, assetCmenu);
            Logger.LogMethodExit("Gradebook", "SelectTheCmenuOfAssetInGradebook",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Score Of Activity.
        /// </summary>
        /// <param name="activityScore">This is Activity Score.</param>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userTypeEnum">This is User Type Enum.</param>        
        [Then(@"I should see the score ""(.*)"" of ""(.*)"" activity for ""(.*)""")]
        public void VerifyTheScoreOfActivity(
            string activityScore, string activityName, User.UserTypeEnum userTypeEnum)
        {
            //Verify The Score Of Activity
            Logger.LogMethodEntry("Gradebook",
                "VerifyTheScoreOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (activityScore, new GBInstructorUXPage().GetActivityStatus(
                    activityName, user.LastName, user.FirstName)));
            Logger.LogMethodExit("Gradebook",
                "VerifyTheScoreOfActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Score Of Activity.
        /// </summary>
        /// <param name="activityScore">This is Activity Score.</param>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="scenerioName">This is scenerio name of the student.</param>
        [Then(@"I should see score ""(.*)"" of ""(.*)"" activity for ""(.*)""  with ""(.*)""")]
        public void VerifyTheScoreOfActivityBasedOnScenerio(string activityScore,
            string activityName,
            string scenerioName, User.UserTypeEnum userTypeEnum)
        {
            //Verify The Score Of Activity
            Logger.LogMethodEntry("Gradebook",
                "VerifyTheScoreOfActivityBasedOnScenerio",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = new GBInstructorUXPage().FetchTheUserDetails(scenerioName, userTypeEnum);
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (activityScore, new GBInstructorUXPage().GetActivityStatus(
                    activityName, user.LastName, user.FirstName)));
            Logger.LogMethodExit("Gradebook",
                "VerifyTheScoreOfActivityBasedOnScenerio",
               base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see the ""(.*)"" score in view submission page for a ""(.*)"" with ""(.*)""")]
        public void VerifyTheScoreInViewSubmissionPageBasedOnScenerio(string submissionScore,
            string scenerioName, User.UserTypeEnum userTypeEnum)
        {
            //Verify The Score Of Activity
            Logger.LogMethodEntry("Gradebook",
                "VerifyTheScoreOfActivityBasedOnScenerio",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = new GBInstructorUXPage().FetchTheUserDetails(scenerioName, userTypeEnum);
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (submissionScore, new ViewSubmissionPage().GetSubmissionScoreByStudent
                 (user.LastName, user.FirstName)));
            Logger.LogMethodExit("Gradebook",
                "VerifyTheScoreOfActivityBasedOnScenerio",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select The Cmenu Of Asset In Instructor GradeBook.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu.</param>
        /// <param name="activityTypeEnum">This is Asset Name.</param>
        [When(@"I select the cmenu ""(.*)"" of asset ""(.*)""")]
        public void SelectCmenuOfAssetInInstructorGradeBook(string assetCmenu,
            string assetName)
        {
            // Select The Cmenu Of Asset In GradeBook
            Logger.LogMethodEntry("Gradebook", "SelectCmenuOfAssetInInstructorGradeBook",
                base.IsTakeScreenShotDuringEntryExit);
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Select Gradebook window
            gbStudentPage.SelectGradebookWindow();
            gbInstructorPage.SelectCmenuOptionOfAssetInGradebook(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), assetName);
            Logger.LogMethodExit("Gradebook", "SelectCmenuOfAssetInInstructorGradeBook",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Student Submission Score In ViewSubmission Page.
        /// </summary>
        /// <param name="submissionScore">This is Submission Score.</param>
        [Then(@"I should see ""(.*)"" score in view submission page")]
        public void VerifyStudentSubmissionScoreInViewSubmissionPage(string submissionScore)
        {
            // Verify Student Submission Score In ViewSubmission Page
            Logger.LogMethodEntry("Gradebook", "VerifyStudentSubmissionScoreInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (submissionScore, new ViewSubmissionPage().GetSubmissionScoreInViewSubmissionPage()));
            Logger.LogMethodExit("Gradebook", "VerifyStudentSubmissionScoreInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Activity Grade Schema In Gradebook.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Name.</param>
        /// <param name="activityStatus">This is Activity Status.</param>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see the ""(.*)"" activity status ""(.*)"" in Gradebook for enrollled ""(.*)""")]
        public void VerifyActivityGradeSchemaInGradebook(
            string activityName, string activityStatus,
            User.UserTypeEnum userTypeEnum)
        {
            //Verify Activity Grade Schema In Gradebook
            Logger.LogMethodEntry("GradeBook",
                "VerifyActivityGradeSchemaInGradebook",
                 IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            //Assert Activity Status for Enrolled User in Gradebook
            Logger.LogAssertion("VerifyActivityDisplayInGradebook",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(activityStatus,
                 new GBInstructorUXPage().GetActivityStatus
                 (activityName, user.LastName, user.FirstName)));
            Logger.LogMethodExit("GradeBook",
                "VerifyActivityGradeSchemaInGradebook",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On View Grades In Gradebook.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        [When(@"I click on view grades of ""(.*)"" in gradebook")]
        public void ClickOnViewGradesInGradebook(string activityName)
        {
            // Click On View Grades In Gradebook
            Logger.LogMethodEntry("Gradebook", "ClickOnViewGradesInGradebook",
                base.IsTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Select Gradebook Window
            gbInstructorPage.SelectGradebookFrame();
            //Click on View Grades Button
            gbInstructorPage.GetActivityName(activityName);
            Logger.LogMethodExit("Gradebook", "ClickOnViewGradesInGradebook",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Options In ViewSubmission Page.
        /// </summary>
        /// <param name="declineOption">This is Decline Option.</param>
        /// <param name="acceptOption">This is Accept Option.</param>
        [Then(@"I should see ""(.*)"" and ""(.*)"" options in view submission page")]
        public void VerifyOptionsInViewSubmissionPage(string declineOption, string acceptOption)
        {
            //Verify Options In ViewSubmission Page
            Logger.LogMethodEntry("Gradebook", "VerifyOptionsInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify 'Decline' and 'Accept' Option Displayed in View Submission Page
            new ViewSubmissionPage().IsDeclineAcceptOptionDisplayed(declineOption, acceptOption);
            Logger.LogMethodExit("Gradebook", "VerifyOptionsInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On MyCourse Link In Gradebook.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I click on 'My Course' link in gradebook by ""(.*)""")]
        public void ClickOnMyCourseLinkInGradebook(User.UserTypeEnum userTypeEnum)
        {
            //Click On MyCourse Link In Gradebook
            Logger.LogMethodEntry("Gradebook", "VerifyOptionsInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On MyCourse Link
            new GBInstructorUXPage().ClickonMyCourseInGradebook(userTypeEnum);
            Logger.LogMethodExit("Gradebook", "VerifyOptionsInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// BlackBoard teacher edit the grades in Pegasus
        /// </summary>
        /// <param name="gradeTypeEnum">This is Grade by Type Enum.</param>
        [When(@"I edit the grade ""(.*)"" in view submission page")]
        public void WhenIEditTheGradeInViewSubmissionPage(Grade.GradeTypeEnum score)
        {
            //Edit The Manual Grade In ViewSubmission Page
            Logger.LogMethodEntry("Gradebook",
                "EditTheManualGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Edit The Manual Grade In ViewSubmission page
            new ViewSubmissionPage().EditTheGradeInViewSubmissionPageByBBIns(score);
            Logger.LogMethodExit("Gradebook",
                "EditTheManualGradeInViewSubmissionPage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit Grade of activity in Gradebook
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        [When(@"I click on Edit Grade ""(.*)"" of ""(.*)"" activity for ""(.*)"" in Pegasus")]
        public void EditGradeOfActivityInPegasusByBBIns(Grade.GradeTypeEnum gradeType, Activity.ActivityTypeEnum activityType, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("Gradebook", "EditGradeOfActivityInPegasusByBBIns", base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userType);
            string userFirstName = user.FirstName.ToString();
            string userLastName = user.LastName.ToString();
            new GBInstructorUXPage().EditActivityScoreInPegasusAtViewSubmission(gradeType, activityType, userLastName, userFirstName);
            Logger.LogMethodExit("Gradebook", "EditGradeOfActivityInPegasusByBBIns", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit Grade as Moodle instructor
        /// </summary>
        /// <param name="gradeType">This is the grade type.</param>
        /// <param name="activityType">This is the activity name.</param>
        /// <param name="userType">This is the user type.</param>
        [When(@"I click Edit Grade ""(.*)"" of ""(.*)"" activity for ""(.*)"" in Pegasus")]
        public void EditGradeOfActivityInPegasusByMoodleIns(Grade.GradeTypeEnum gradeType, Activity.ActivityTypeEnum activityType, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("Gradebook", "EditGradeOfActivityInPegasusByBBIns", base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userType);
            string userFirstName = user.FirstName.ToString();
            string userLastName = user.LastName.ToString();
            new GBInstructorUXPage().EditActivityScoreInPegasusByMoodleIns(gradeType, activityType, userLastName, userFirstName);
            Logger.LogMethodExit("Gradebook", "EditGradeOfActivityInPegasusByBBIns", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify The Score Of Activity.
        /// </summary>
        /// <param name="activityScore">This is Activity Score.</param>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see the score ""(.*)"" of ""(.*)"" activity for ""(.*)"" in Pegasus")]
        public void VerifyTheScoreOfActivityInPegasus(
            Grade.GradeTypeEnum score, string activityName, User.UserTypeEnum userTypeEnum)
        {
            //Verify The Score Of Activity
            Logger.LogMethodEntry("Gradebook",
                "VerifyTheScoreOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            // Fetch Grades from in memory
            Grade grade = Grade.Get(score);
            string activityScore = grade.GradeScore.ToString();
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (activityScore, new GBInstructorUXPage().GetActivityStatus(
                    activityName, user.LastName, user.FirstName)));
            Logger.LogMethodExit("Gradebook",
                "VerifyTheScoreOfActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Button In View Submission Page.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        [When(@"I select the option ""(.*)"" in view submission page")]
        public void SelectButtonInViewSubmissionPage(string buttonName)
        {
            //Select Button In View Submission Page
            Logger.LogMethodEntry("Gradebook", "SelectButtonInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Button In View Submission Page
            new ViewSubmissionPage().ClickOnButtonInViewSubmissionPage(buttonName);
            Logger.LogMethodExit("Gradebook", "SelectButtonInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of GradeSync Icon
        /// </summary>
        /// <param name="activityName">This is the activity name</param>
        [Then(@"I should see GBSync icon for ""(.*)"" activity")]
        public void VaidateGBSyncIconForActivity(string activityName)
        {
            Logger.LogMethodEntry("Gradebook",
                "VaidateGBSyncIconForActivity",
               base.IsTakeScreenShotDuringEntryExit);
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (true, new GBInstructorUXPage().GetGBSyncIconStatus(activityName)));
            Logger.LogMethodExit("Gradebook",
                "VaidateGBSyncIconForActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

         /// <summary>
        /// Verify Badge Icon is present in Gradebook
        /// </summary>
        /// <param name="activityName">This is the activity name</param>
        /// <param name="userTypeEnum">This is the user type</param>
        [Then(@"I should see the badge icon for ""(.*)"" as ""(.*)""")]
        public void isBadgeIconPresentInGradebook(string activityName,
            User.UserTypeEnum userTypeEnum)
        {
            // Verify Badge Icon is present in Student Gradebook
            Logger.LogMethodEntry("Gradebook",
                "isBadgeIconPresentInGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            string userLastName = User.Get(userTypeEnum).LastName.ToString();
            string userFirstName = User.Get(userTypeEnum).FirstName.ToString();
            //Assert Badge is displayed for submitted badged activity
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.CsSmsInstructor:
                    Logger.LogAssertion("isBadgeIconPresentInInstructorGB", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.AreEqual
                            (true, new GBInstructorUXPage()
                            .VerifyBadge(activityName, userLastName, userFirstName)));
                    break;
                case User.UserTypeEnum.CsSmsStudent:
                    Logger.LogAssertion("isBadgeIconPresentInStudentGB", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.AreEqual
                            (true, new GBStudentUXPage().isBadgePresent(activityName)));
                    break;
            }
            Logger.LogMethodExit("Gradebook",
                "isBadgeIconPresentInGradebook", base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I perform Delete All Submission ""(.*)"" for the activity")]
        public void PerformDeleteAllSubmissionForTheActivity(User.UserTypeEnum userTypeEnum)
        {
            string userLastName = User.Get(userTypeEnum).LastName.ToString();
            string userFirstName = User.Get(userTypeEnum).FirstName.ToString();
            new ViewSubmissionPage().DeleteAllSubmission(userLastName, userFirstName);
            new GBInstructorUXPage().SelectGradebookFrame();
        }

        /// <summary>
        /// Verify the submenu details
        /// </summary>
        /// <param name="subMenuTitle">This is the sub menu title.</param>
        /// <param name="activityColumn">This is the column name.</param>
        /// <param name="gradeColumn">This is the column name.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [Then(@"I should be able to see ""(.*)"" submenu text with ""(.*)"" and ""(.*)"" columns as ""(.*)"" user")]        
        public void ValidateCustomViewTab(string subMenuTitle,
           string activityColumn, string gradeColumn, User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("Gradebook",
                "ValidateCustonViewTab",
               base.IsTakeScreenShotDuringEntryExit);            
           //Verify sub menu title displayed
            Logger.LogAssertion("ValidateCustomViewTab", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.AreEqual
                            (subMenuTitle, new GBCustomViewUX().
                            GetCustomViewTabDisplayItems(subMenuTitle, userTypeEnum)));
            //Verify Activity column dispalyed
            Logger.LogAssertion("ValidateCustomViewTab", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.AreEqual
                            (activityColumn, new GBCustomViewUX().
                            GetCustomViewTabDisplayItems(activityColumn, userTypeEnum)));
            //Verify Grade column dispalyed
            Logger.LogAssertion("ValidateCustomViewTab", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.AreEqual
                            (gradeColumn, new GBCustomViewUX().
                            GetCustomViewTabDisplayItems(gradeColumn, userTypeEnum)));
            Logger.LogMethodExit("Gradebook",
                "ValidateCustonViewTab",
               base.IsTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Verify the activity saved in Customview tab
        /// </summary>
        /// <param name="activityTypeEnum">This is the activity type enum.</param>
        /// <param name="activityIcon">This is the activity icon.</param>
        /// <param name="activityScore">This is the activity score.</param>
        /// <param name="userScenario">This is scenerio name of the student.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [Then(@"I should see ""(.*)"" with ""(.*)"" having ""(.*)"" grade for ""(.*)"" as ""(.*)"" user")]
        public void VerifySavedActivityDisplayInCustomViewBasedOnScenerio(
            Activity.ActivityTypeEnum activityTypeEnum,string activityIcon, 
             int activityScore, string userScenario, User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("Gradebook",
                   "VerifySavedActivityDisplayInCustomView",
                  base.IsTakeScreenShotDuringEntryExit);
          
            //Get Activity name from XML
            Activity activity = Activity.Get(activityTypeEnum);
            String expectedActivity = activity.Name;
            //Verify Activity dispalyed
            Logger.LogAssertion("VerifySavedActivityDisplayInCustomView", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.AreEqual
                            (expectedActivity, new GBCustomViewUX().
                            GetActivitySavedInCustomView(expectedActivity, userTypeEnum)));
            ////Verify Activity icon dispalyed
            Logger.LogAssertion("VerifySavedActivityDisplayInCustomView", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.IsTrue
                            (new GBCustomViewUX().
                            GetActivityIconInCustomView(expectedActivity, userTypeEnum)));
            ////Verify Grade column dispalyed
            Logger.LogAssertion("VerifySavedActivityDisplayInCustomView", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.AreEqual
                            (activityScore, new GBCustomViewUX().
                            GetActivityScoreInCustomView(expectedActivity, userTypeEnum)));
            Logger.LogMethodExit("Gradebook",
                "VerifySavedActivityDisplayInCustomView",
               base.IsTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Verify the activity saved in Customview tab
        /// </summary>
        /// <param name="activityTypeEnum">This is the activity type enum.</param>
        /// <param name="activityIcon">This is the activity icon.</param>
        /// <param name="activityScore">This is the activity score.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [Then(@"I should see ""(.*)"" with the ""(.*)"" having ""(.*)"" grade for ""(.*)"" user")]
        public void VerifySavedActivityDisplayInCustomView(Activity.ActivityTypeEnum activityTypeEnum,
            string activityIcon, int activityScore, User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("Gradebook",
                   "VerifySavedActivityDisplayInCustomView",
                  base.IsTakeScreenShotDuringEntryExit);

            //Get Activity name from XML
            Activity activity = Activity.Get(activityTypeEnum);
            String expectedActivity = activity.Name;
            //Verify Activity dispalyed
            Logger.LogAssertion("VerifySavedActivityDisplayInCustomView", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.AreEqual
                            (expectedActivity, new GBCustomViewUX().
                            GetActivitySavedInCustomView(expectedActivity, userTypeEnum)));
            ////Verify Activity icon dispalyed
            Logger.LogAssertion("VerifySavedActivityDisplayInCustomView", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.IsTrue
                            (new GBCustomViewUX().
                            GetActivityIconInCustomView(expectedActivity, userTypeEnum)));
            ////Verify Grade column dispalyed
            Logger.LogAssertion("VerifySavedActivityDisplayInCustomView", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.AreEqual
                            (activityScore, new GBCustomViewUX().
                            GetActivityScoreInCustomView(expectedActivity, userTypeEnum)));

            Logger.LogMethodExit("Gradebook",
                "VerifySavedActivityDisplayInCustomView",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the activity position in custom view tab
        /// </summary>
        /// <param name="p0">This is the activity type enum.</param>
        /// <param name="p1">This is the expected activity position.</param>
        [Then(@"I should see ""(.*)"",""(.*)"" activity in ""(.*)"" order")]       
        public void VerifyActivityPositioInCustomViewFrame(
            Activity.ActivityTypeEnum activityTypeEnum1,Activity.ActivityTypeEnum activityTypeEnum2, string sortOrder)
        {
            Logger.LogMethodEntry("Gradebook",
                           "VerifyActivityPositioInCustomViewFrame",
                          base.IsTakeScreenShotDuringEntryExit);
            //Get the 1st Activity from InMemory
            Activity firstActivity1 = Activity.Get(activityTypeEnum1);
            String activity1 = firstActivity1.Name;
            //Get the 2nd Activity from InMemory
            Activity secondActivity = Activity.Get(activityTypeEnum2);
            String activity2 = secondActivity.Name;
            Logger.LogAssertion("VerifySavedActivityDisplayInCustomView", ScenarioContext.
                       Current.ScenarioInfo.Title, () => Assert.IsTrue(
                           new GBCustomViewUX().IsTheActivtiyColumnSorted(activity1,activity2,sortOrder)));
            Logger.LogMethodExit("Gradebook",
                "VerifySavedActivityDisplayInCustomView",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Sort the Activity and Grades column in Custom view tab
        /// </summary>
        /// <param name="sortColumn">This is the column name.</param>
        [When(@"I sort the ""(.*)"" in 'Ascending' order")]        
        [When(@"I sort the ""(.*)"" in 'Descending' order")]
        public void SortActivityInCustomView(string sortColumn)
        {
            Logger.LogMethodEntry("Gradebook",
                           "SortActivityInCUstomView",
                          base.IsTakeScreenShotDuringEntryExit);                     
           new GBCustomViewUX().SortCustomViewActivity(sortColumn);
            Logger.LogMethodExit("Gradebook",
                "VerifySavedActivityDisplayInCustomView",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the display of sorted columns in custom view tab
        /// </summary>
        /// <param name="sortType">Tis is the type of sorting to be done</param>
        [Then(@"I should see ""(.*)"" icon for the sorted column")]        
        public void VerifyCustomColumnSort(string sortType)
        {
            Logger.LogMethodEntry("Gradebook",
                            "VerifyActivityPositioInCustomViewFrame",
                           base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifySavedActivityDisplayInCustomView", ScenarioContext.
                       Current.ScenarioInfo.Title, () => Assert.IsTrue(
                           new GBCustomViewUX().IsCustomViewColumnSorted(sortType)));
            Logger.LogMethodExit("Gradebook",
                "VerifySavedActivityDisplayInCustomView",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the SIM5 activity based on the tab required
        /// </summary>
        /// <param name="activityName">This is the activity type enum.</param>
        /// <param name="tabName">This is the tab name.</param>
        /// <param name="userTypeEnum">This is the User tyoe enum.</param>
        [When(@"I navigate to ""(.*)"" activity in ""(.*)"" by ""(.*)""")]
        public void SelectSIM5Activity(Activity.ActivityTypeEnum activityTypeEnum, string tabName, User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("Gradebook",
                            "SelectSIM5Activity",
                           base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            String activityName = activity.Name;
            new GBDefaultUXPage().FolderLevelNavigation(activityName, tabName, userTypeEnum);
            Logger.LogMethodExit("Gradebook",
               "SelectSIM5Activity",
              base.IsTakeScreenShotDuringEntryExit);
        }

       /// <summary>
        /// Verify the Activity and its grade in Grades tab
        /// </summary>
       /// </summary>
       /// <param name="activityName">This is the Activity type enum.</param>
       /// <param name="activityGrade">This is the activity grade.</param>
        [Then(@"I should see ""(.*)"" activity in Grades tab with ""(.*)"" grade")]
        public void VerifyActivityDisplayInTab(Activity.ActivityTypeEnum activityTypeEnum,
            Grade.GradeTypeEnum gradeTypeEnum)
        {
            Logger.LogMethodEntry("Gradebook",
                           "VerifyActivityDisplayInTab",
                          base.IsTakeScreenShotDuringEntryExit);
            //Fetch the Activity name from XML
            Activity activity = Activity.Get(activityTypeEnum);
            String activityName = activity.Name;
            //Fetch the Grade from XML
            Grade grade = Grade.Get(gradeTypeEnum);
            String activityExpectedGrade = grade.GradeScore;

            Logger.LogAssertion("VerifyActivityDisplayInTab", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.AreEqual
                            (activityName, new GBDefaultUXPage().IsActivityDisplayedInGradesTab(activityName)));
            Logger.LogAssertion("VerifyActivityDisplayInTab", ScenarioContext.
                        Current.ScenarioInfo.Title, () => Assert.AreEqual
                            (activityExpectedGrade, new GBDefaultUXPage().
                            IsActivityGradeDisplayedInGradesTab(activityName, activityExpectedGrade)));
            Logger.LogMethodExit("Gradebook",
               "VerifyActivityDisplayInTab",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the option from the activity cmenu in Grades tab
        /// </summary>
        /// <param name="cmenuOption">This is the cmenu option.</param>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [When(@"I click on ""(.*)"" cmenu option of ""(.*)"" as ""(.*)"" user")]
        public void ClickOnCmenuOptionOfActivity(string cmenuOption, Activity.ActivityTypeEnum activityTypeEnum
            , User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("Gradebook",
                           "VerifyActivityPositioInCustomViewFrame",
                          base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            String activityName = activity.Name;
            new GBDefaultUXPage().
            ClickOnActivitycMenuOption(cmenuOption, activityName, userTypeEnum);
            Logger.LogMethodExit("Gradebook",
               "VerifySavedActivityDisplayInCustomView",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the activity name i Viw submission page of student
        /// </summary>
        /// <param name="activityTypeEnum">This is the activity type enum.</param>
        [Then(@"I should see ""(.*)"" activity name")]
        public void VerifyActivityNameInViewSubmissionPage(Activity.ActivityTypeEnum activityTypeEnum)
        {
            Logger.LogMethodEntry("Gradebook",
                           "VerifyActivityNameInViewSubmissionPage",
                          base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            String activityName = activity.Name;
            Logger.LogAssertion("VerifyActivityDisplayInTab", ScenarioContext.
                       Current.ScenarioInfo.Title, () => Assert.AreEqual
                           (activityName, new ViewSubmissionPage().
                           IsActivityPresentInViewSubmissionPage(activityName)));
            Logger.LogMethodExit("Gradebook",
                           "VerifyActivityNameInViewSubmissionPage",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Attempts grid and its column dispaly in student view submission page
        /// </summary>
        /// <param name="dateColumnName">This is the Date column name.</param>
        /// <param name="gradeColumnName">This is the Grade column name.</param>
        /// <param name="totalAttemptRows">This is the total number of attempt rows.</param>
        /// /// <param name="userTypeEnum">This is the user type enum.</param>
        [Then(@"I should see 'Attempts' grid with ""(.*)"" ""(.*)"" columns having ""(.*)"" entries as ""(.*)"" user")]
        [Then(@"I should see 'StudentsList' grid with ""(.*)"" ""(.*)"" columns having ""(.*)"" entries as ""(.*)"" user")]
        public void VerifyAtemptsGridInViewSubmission(string columnTitle, 
            string gradeColumnName, int totalRows, User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("Gradebook",
                            "VerifyAtemptsGridInViewSubmission",
                           base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyActivityDisplayInTab", ScenarioContext.
                       Current.ScenarioInfo.Title, () => Assert.IsTrue
                           (new ViewSubmissionPage().IsLeftFrameGridPresentInViewSubmissionPage(columnTitle,
            gradeColumnName,  totalRows, userTypeEnum)));            
            Logger.LogMethodExit("Gradebook",
                           "VerifyAtemptsGridInViewSubmission",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// CLick on the required attemp row to view the submission details
        /// </summary>
        /// <param name="activityScore">This is the activity score.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [When(@"I click on attempt having ""(.*)"" grade as ""(.*)""")]
        public void ViewActivitySubmission(String activityScore, User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("Gradebook",
                            "VerifyAtemptsGridInViewSubmission",
                           base.IsTakeScreenShotDuringEntryExit);
            new ViewSubmissionPage().ClickOnActivityAttemptToViewSubmission(activityScore);
            Logger.LogMethodExit("Gradebook",
                           "VerifyAtemptsGridInViewSubmission",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Activity Score In ViewSubmission page of student
        /// </summary>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        /// <param name="activityScore">This is the activity score.</param>
        [Then(@"I should see ""(.*)"" with ""(.*)"" score")]
        public void VerifyActivityScoreInViewSubmission(User.UserTypeEnum userTypeEnum, String activityScore)
        {
            Logger.LogMethodEntry("Gradebook",
                            "VerifyActivityScoreInViewSubmission",
                           base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            string expectedUserName = user.LastName + ", " + user.FirstName;
            Logger.LogAssertion("VerifyActivityDisplayInTab", ScenarioContext.
                       Current.ScenarioInfo.Title, () => Assert.AreEqual
                           (activityScore, new ViewSubmissionPage().GetActivityScoreInViewSubmission()));
            Logger.LogAssertion("VerifyActivityDisplayInTab", ScenarioContext.
                      Current.ScenarioInfo.Title, () => Assert.AreEqual
                          (expectedUserName, new ViewSubmissionPage().GetStudentNameInViewSUbmissionPage()));             
            Logger.LogMethodExit("Gradebook",
                           "VerifyActivityScoreInViewSubmission",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Student in Instructor View Submission left frame
        /// </summary>
        /// <param name="userTypeEnum">This is the UserType enum.</param>
        [When(@"I click on ""(.*)"" in the StudentList")]
        public void ClickStudentList(User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("Gradebook",
                           "ClickStudentList",
                          base.IsTakeScreenShotDuringEntryExit);
            //Fetch the User from the memory
            User user = User.Get(userTypeEnum);
            string lastName = user.LastName;
            string firstName = user.FirstName;
            //Click on Student in View Submission Frame
            new ViewSubmissionPage().SelectStudentInInstructorViewSubmissionPage(lastName, firstName);
            Logger.LogMethodExit("Gradebook",
                           "ClickStudentList",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Student name in Instructor View Submission left frame
        /// </summary>
        /// <param name="userTypeEnum">This is the UserType enum.</param>
        /// <param name="pastDueIcon">This is the pastdue icon.</param>
        [Then(@"I should see ""(.*)"" with ""(.*)"" icon")]
        public void VerifyStudentNameInInstructorViewSubmission(User.UserTypeEnum userTypeEnum, string pastDueIcon)
        {
            Logger.LogMethodEntry("Gradebook",
                           "VerifyStudentNameInInstructorViewSubmission",
                          base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            string expectedUserName = user.LastName + ", " + user.FirstName;
            Logger.LogAssertion("VerifyActivityDisplayInTab", ScenarioContext.
                       Current.ScenarioInfo.Title, () => Assert.AreEqual
                           (expectedUserName, new ViewSubmissionPage().
                           GetStudentNameInInstructorViewSubmissionPage()));
            Logger.LogAssertion("VerifyActivityDisplayInTab", ScenarioContext.
                      Current.ScenarioInfo.Title, () => Assert.IsTrue
                          (new ViewSubmissionPage().
                          IsPastdueIconDisplayedInInstructorViewSubmissionPage()));
            Logger.LogMethodExit("Gradebook",
                           "VerifyActivityScoreInViewSubmission",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see ""(.*)"" with ""(.*)"" grade")]
        public void ValidateStudentandGradeInInstructorViewSubmission(User.UserTypeEnum userTypeEnum, string studentGrade)
        {
            Logger.LogMethodEntry("Gradebook",
                           "ValidateStudentandGradeInInstructorViewSubmission",
                          base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            string lastName = user.LastName;
            string firstName = user.FirstName;
            string expectedUserName = lastName + ", " + firstName;
            Logger.LogAssertion("VerifyActivityDisplayInTab", ScenarioContext.
                       Current.ScenarioInfo.Title, () => Assert.AreEqual
                           (expectedUserName, new ViewSubmissionPage().
                           GetStudentNameInInstructorViewSubmissionList(lastName, firstName)));
            Logger.LogAssertion("VerifyActivityDisplayInTab", ScenarioContext.
                      Current.ScenarioInfo.Title, () => Assert.AreEqual
                          (studentGrade, new ViewSubmissionPage().
                          GetStudentScoreInInstructorViewSubmissionList(expectedUserName)));
            Logger.LogMethodExit("Gradebook", 
                           "ValidateStudentandGradeInInstructorViewSubmission",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        [When(@"I click on 'Submit Students Answer' button")]
        public void SubmitStudentAnswerInInstructorViewSubmission()
        {
            Logger.LogMethodEntry("Gradebook",
                          "SubmitStudentAnswerInInstructorViewSubmission",
                         base.IsTakeScreenShotDuringEntryExit);
            new ViewSubmissionPage().SubmitStudentAnswerForcefully();
            Logger.LogMethodExit("Gradebook",
                         "SubmitStudentAnswerInInstructorViewSubmission",
                        base.IsTakeScreenShotDuringEntryExit);   
        }

        [Then(@"I should see ""(.*)"" with ""(.*)"" submission grade")]
        public void ValidateSubmissionGrade(User.UserTypeEnum userTypeEnum, string studentGrade)
        {
            Logger.LogMethodEntry("Gradebook",
                          "ValidateSubmissionGrade",
                         base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyActivityDisplayInTab", ScenarioContext.
                       Current.ScenarioInfo.Title, () => Assert.AreEqual
                           (studentGrade, new ViewSubmissionPage().
                           GetSubmissionGradeInInstructorViewSubmission()));
            //Fetch User from the memory
            User user = User.Get(userTypeEnum);
            string lastName = user.LastName;
            string firstName = user.FirstName;
            string expectedUserName = lastName + ", " + firstName;
            Logger.LogAssertion("VerifyActivityDisplayInTab", ScenarioContext.
                       Current.ScenarioInfo.Title, () => Assert.AreEqual
                           (expectedUserName, new ViewSubmissionPage().
                           GetStudentNameInInstructorViewSubmissionPage()));
            Logger.LogMethodExit("Gradebook",
                          "ValidateSubmissionGrade",
                         base.IsTakeScreenShotDuringEntryExit);            
        }

        [Then(@"I should see the score ""(.*)"" for ""(.*)"" activity for ""(.*)""")]
        public void ThenIShouldSeeTheScoreForActivityFor(string activityScore, Activity.ActivityTypeEnum activityTypeEnum, User.UserTypeEnum userTypeEnum)
        {
            //Verify The Score Of Activity
            Logger.LogMethodEntry("Gradebook",
                "VerifyTheScoreOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory

            Activity activity = Activity.Get(activityTypeEnum);
            string activityName = activity.Name.ToString();
            User user = User.Get(userTypeEnum);
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (activityScore, new GBInstructorUXPage().GetActivityStatus(
                    activityName, user.LastName, user.FirstName)));
            Logger.LogMethodExit("Gradebook",
                "VerifyTheScoreOfActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see score ""(.*)"" for ""(.*)"" activity submitted by ""(.*)""")]
        public void ValidateSubmissionScoreInGradeBook(int score, Activity.ActivityTypeEnum activityTypeEnum, User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("Gradebook",
                "VerifyTheScoreOfActivityBasedOnScenerio",
               base.IsTakeScreenShotDuringEntryExit);

            // Get the activity name
            Activity activityType = Activity.Get(activityTypeEnum);
            string activityName = activityType.Name.ToString();

            // Get User details
            User userType = User.Get(userTypeEnum);
            string firstName = userType.FirstName.ToString();
            string lastName = userType.LastName.ToString();
            string userName = userType.Name.ToString();

            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (score, new GBDefaultUXPage().GetActivityScore(
                    activityName, lastName, firstName)));

            Logger.LogMethodExit("Gradebook",
                "VerifyTheScoreOfActivityBasedOnScenerio",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the activity in the Gradebook
        /// </summary>
        /// <param name="activityTypeEnum"></param>
        /// <param name="tabName"></param>
        /// <param name="userType"></param>
        [When(@"I select ""(.*)"" in ""(.*)"" as ""(.*)""")]
        public void SelectActivityNameInGB(Activity.ActivityTypeEnum activityTypeEnum,
            string tabName, User.UserTypeEnum userType)
        {
            //Manage The Activity Folder Level Navigation
            Logger.LogMethodEntry("Gradebook", "SelectActivityNameInGB", base.IsTakeScreenShotDuringEntryExit);
            new GBDefaultUXPage().SelectFolderInGradeBook(activityTypeEnum, tabName, userType);
            Logger.LogMethodExit("Gradebook", "SelectActivityNameInGB", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate the display of Grades in view submission
        /// </summary>
        /// <param name="gradeTypeEnum">This is Grade type enum.</param>
        /// <param name="scenerioName">This is scenario name.</param>
        /// <param name="activityType">This is activity type.</param>
        /// <param name="userTypeEnum">This is user type enum.</param>
        [Then(@"I should be displayed with ""(.*)"" for ""(.*)""  for ""(.*)"" user ""(.*)"" scenario")]
        public void ValidateDisplayOfGradesInViewSubmission(Grade.GradeTypeEnum gradeTypeEnum, Activity.ActivityTypeEnum activityType, 
            User.UserTypeEnum userTypeEnum, string scenerioName)
        {
            Logger.LogMethodEntry("Gradebook", "ValidateDisplayOfGradesInViewSubmission", base.IsTakeScreenShotDuringEntryExit);
            //Assert Grades of Submitted Activity in view submission

            // Get the grade
            Grade grade = Grade.Get(gradeTypeEnum);
            string gradeScore = grade.GradeScore.ToString();
            int score = Convert.ToInt32(gradeScore);

            //Get the user of the given type from Memory Data Store
            User user = new LoginContentPage().
                SelectUserDetailsBaesdOnScenerio(scenerioName, userTypeEnum);

            //Get User name
            string userName = user.Name.ToString();
            string firstName = user.FirstName.ToString();
            string lastName = user.LastName.ToString();

            //Get activity name
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();


            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue
                 (new ViewSubmissionPage().GetViewSubmissionScoreStatus(score,
                    activityName, lastName, firstName)));
            Logger.LogMethodExit("Gradebook", "ValidateDisplayOfGradesInViewSubmission", base.IsTakeScreenShotDuringEntryExit);
        }

        //Then I should be displayed with "SimActivity0Score" for "RegWordSIMActivity"  for "CsSmsStudent" user "scoring 0" scenario
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        [When(@"I delete all submission for ""(.*)"" of ""(.*)"" user ""(.*)"" scenario")]
        public void WhenIDeleteAllSubmissionForOfUserScenario(Activity.ActivityTypeEnum activityType, User.UserTypeEnum userTypeEnum, 
            string scenerioName)
        {
            Logger.LogMethodEntry("Gradebook", "ValidateDisplayOfGradesInViewSubmission", base.IsTakeScreenShotDuringEntryExit);

            //Get the user of the given type from Memory Data Store
            User user = new LoginContentPage().
                SelectUserDetailsBaesdOnScenerio(scenerioName, userTypeEnum);

            //Get User name
            string userName = user.Name.ToString();
            string firstName = user.FirstName.ToString();
            string lastName = user.LastName.ToString();

            //Get activity name
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();

            new ViewSubmissionPage().DeleteGradeInGradeBook(
                    activityName, lastName, firstName);
        }

    }
}
  