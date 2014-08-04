using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
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
        /// <param name="behavoiralModeTypeEnum">This is Behavioral Mode Type Enum.</param>
        [When(@"I associate the ""(.*)"" activity of behavioral mode ""(.*)"" to MyCourse frame")]
        public void AssociateTheActivityToMyCourseFrame(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum ActivityModeTypeEnum)
        {
            //Associate the Activity to MyCourse Frame
            Logger.LogMethodEntry("Gradebook", "AssociateTheActivityToMyCourseFrame",
                IsTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum, ActivityModeTypeEnum);
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
                () =>Assert.AreEqual(sendMessageButtons,new ComposeNewMailUXPage().
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
            Logger.LogMethodEntry("Gradebook","ClickTheViewButtonInReport",
                base.IsTakeScreenShotDuringEntryExit);
            //Click The View Button In Report
            new RptStuStudyPlanPage().ClickTheViewButtonInReport();
            Logger.LogMethodExit("Gradebook","ClickTheViewButtonInReport",
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
            Logger.LogMethodExit("GradeBook","ClickTheCloseButtonInReportPage",
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
            GBStudentUXPage gbStudentPage = new GBStudentUXPage();
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
            Logger.LogMethodEntry("Gradebook","SelectTheCmenuOfAssetInGradebook",
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
        /// Manage The Gradebook FolderLevel Navigation.
        /// </summary>
        /// <param name="navigateMILFolderLevelName">This is MIL Folder Level Type.</param>
        [When(@"I navigate inside the folder level type ""(.*)"" in gradebook")]
        public void ManageTheGradebookFolderLevelNavigation(string navigateMILFolderLevelType)
        {
            //Manage The Gradebook FolderLevel Navigation
            Logger.LogMethodEntry("Gradebook",
                "ManageTheGradebookFolderLevelNavigation",
                base.IsTakeScreenShotDuringEntryExit);
            //Manage The Gradebook Folder Navigation
            new GBLeftNavigationUXPage().ManageTheGradebookFolderNavigation(
                (GBLeftNavigationUXPage.MilAuthoredCourseFolderLelevlTypeEnum)Enum.Parse(typeof
                (GBLeftNavigationUXPage.MilAuthoredCourseFolderLelevlTypeEnum),
                navigateMILFolderLevelType));
            Logger.LogMethodExit("Gradebook", 
                "ManageTheGradebookFolderLevelNavigation",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
