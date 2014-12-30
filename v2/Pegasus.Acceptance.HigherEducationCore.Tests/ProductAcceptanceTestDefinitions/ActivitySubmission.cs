using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducation.WL.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This step definition class contains the details of
    /// activity submission.
    /// </summary>
    [Binding]
    public class ActivitySubmission : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ActivitySubmission));

        /// <summary>
        /// Open Activity Presentation Page.
        /// </summary>
        [When(@"I open the Activity")]
        public void OpenTheActivity()
        {
            //Open the Activity Presentation Window
            Logger.LogMethodEntry("ActivitySubmission", "OpenTheActivity"
                , base.IsTakeScreenShotDuringEntryExit);
            // Open Activity Window 
            new CoursePreviewMainUXPage().OpenActivity();
            Logger.LogMethodExit("ActivitySubmission", "OpenTheActivity"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch Activity Presentation Window.
        /// </summary>
        [Then(@"I should see the activity successfully launched")]
        public void ActivitySuccessfullyLaunched()
        {
            //Launching of Activity Presentation Window
            Logger.LogMethodEntry("ActivitySubmission",
                "ActivitySuccessfullyLaunched"
                , base.IsTakeScreenShotDuringEntryExit);
            //Assert Launch Activity Window
            Logger.LogAssertion("VerifyActivityLaunched",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new StudentPresentationPage().
                    IsActivityPresentationPageOpened()));
            Logger.LogMethodExit("ActivitySubmission",
                "ActivitySuccessfullyLaunched"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the Activity.
        /// </summary>
        [When(@"I submit the activity")]
        public void AttemptTheActivity()
        {
            //Launching of Activity Presentation Window
            Logger.LogMethodEntry("ActivitySubmission",
                "AttemptTheActivity"
                , base.IsTakeScreenShotDuringEntryExit);
            // Attempt Activity 
            new StudentPresentationPage().AttemptActivity();
            Logger.LogMethodExit("ActivitySubmission",
                "AttemptTheActivity"
                , base.IsTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Verify Submission of Activity.
        /// </summary>
        [Then(@"I should see the activity submitted successfully for grading")]
        public void VerifyActivitySubmission()
        {
            //Submit the Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifyActivitySubmission"
                , base.IsTakeScreenShotDuringEntryExit);
            //Assert Activity is submitted successfully
            Logger.LogAssertion("VerifyActivityIsSubmitted",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new StudentPresentationPage().
                    IsPostTestActivitySubmittedSuccessfully()));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifyActivitySubmission"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Extra Practice Page Availability.
        /// </summary>
        [Given(@"I am on the 'Extra Practice' page")]
        public void ActivityExtraPracticePage()
        {
            //Verify Correct Page Opened
            Logger.LogMethodEntry("ActivitySubmission",
                "ActivityExtraPracticePage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyExtraPracticePageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new StudentPresentationPage().
                    IsActivityPresentationPageOpened()));
            Logger.LogMethodExit("ActivitySubmission",
                "ActivityExtraPracticePage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate inside the activity in gradbook page.
        /// </summary>
        [When(@"I navigate inside the activity")]
        public void NavigateInsideActivityInGradesPage()
        {
            //Navigate inside activity folder on gradebook page
            Logger.LogMethodEntry("ActivitySubmission",
                "NavigateInsideActivityInGrades",
                base.IsTakeScreenShotDuringEntryExit);
            // Navigated inside the activity
            new GBLeftNavigationUXPage().NavigateToActivityFolder();
            Logger.LogMethodExit("ActivitySubmission",
                "NavigateInsideActivityInGrades",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Grades under grade tab of submitted activity.
        /// </summary>
        [Then(@"I should see the grade under grade column of the submitted activity")]
        public void VerifyGradesOfSubmittedActivity()
        {
            //Verify grades are displayed
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifyGradesOfSubmittedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert grades have been found for submitted activity
            decimal submittedGradeValue = new GBStudentUXPage().
                GetGradeDisplayedForActivity();
            string submittedGrade = submittedGradeValue.ToString().Substring(
                Convert.ToInt32(ActivitySubmissionResource.
                ActivitySubmission_SubmittedGrade_Start_Index_value),
                Convert.ToInt32(ActivitySubmissionResource.
                ActivitySubmission_SubmittedGrade_End_Index_value));
            Logger.LogAssertion("VerifyGradesAreShownForGrading",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(submittedGrade,
                    ActivitySubmissionResource.
                    ActivitySubmision_SubmittedActivity_GradeValue));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifyGradesOfSubmittedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open The Manually Gradable Activity.
        /// </summary>
        [When(@"I open the 'Manually Gradable' Activity")]
        public void OpenTheManuallyGradableActivity()
        {
            //Open The Manually Gradable Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "OpenTheManuallyGradableActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Open The Manually Gradable Activity
            new CoursePreviewMainUXPage().LaunchTheActivityHED();
            //Attempt Essay Activity
            new CoursePreviewMainUXPage().AttemptEssayActivity(
                ActivitySubmissionResource.
                ActivitySubmision_EssayQuestion_Answer_Text_Value);
            Logger.LogMethodExit("ActivitySubmission",
                "OpenTheManuallyGradableActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity.
        /// </summary>
        [When(@"I submit the 'Manually Gradable' Activity")]
        public void SubmitTheActivity()
        {
            //Submit the Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "SubmitTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Declaration of object
            StudentPresentationPage studentPresentationPage =
                new StudentPresentationPage();
            //Select the window
            studentPresentationPage.SelectWebActivityWindow(ActivitySubmissionResource.
                ActivitySubmission_Quiz_WindowName);
            //Click the start button
            studentPresentationPage.EssayQuestionSubmission();             
            //Submit the Activity
            studentPresentationPage.FinishAndReturnToCourse();
            // Select close button on the Test window
            new InstructionsPage().ClickTestCloseButton();
            Logger.LogMethodExit("ActivitySubmission",
                "SubmitTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity In Course Material.
        /// </summary>
        [When(@"I submit the activity in course material")]
        public void SubmitTheActivityInCourseMaterial()
        {
            //Submit The Activity In Course Material
            Logger.LogMethodEntry("ActivitySubmission",
                "SubmitTheActivityInCourseMaterial"
                , base.IsTakeScreenShotDuringEntryExit);
            //Declaration of object
            StudentPresentationPage studentPresentationPage =
                new StudentPresentationPage();
            //Select the window
            studentPresentationPage.SelectWebActivityWindow(ActivitySubmissionResource.
                ActivitySubmission_Test_WindowName);
            // Attempt Activity 
            new StudentPresentationPage().SubmitTheActivityInCourseMaterial();            
            Logger.LogMethodExit("ActivitySubmission",
                "SubmitTheActivityInCourseMaterial"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Status Of Activity.
        /// </summary>
        /// <param name="activityStatus">This is The Activity Status.</param>
        [Then(@"I should see the status of activity as ""(.*)""")]
        public void VerifyStatusOfActivity(String activityStatus)
        {
            //Verify the Status Of Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifyStatusOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(Activity.ActivityTypeEnum.Quiz);
            //Assert the Activity Status
            Logger.LogAssertion("VerifyStatusOfActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityStatus, new CoursePreviewMainUXPage().
                    GetStatusOfActivity(activity.Name)));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifyStatusOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside the Folder.
        /// </summary>
        [When(@"I navigate inside the folder")]
        public void NavigateInsideTheFolder()
        {
            //Navigate Inside the Folder
            Logger.LogMethodEntry("ActivitySubmission",
                "NavigateInsideTheFolder",
                base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the Folder
            new GBLeftNavigationUXPage().NavigateInsideFolderHed();
            Logger.LogMethodExit("ActivitySubmission",
                "NavigateInsideTheFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Very the Score for Manually Graded Activity.
        /// </summary>
        [Then(@"I should see the grades for manually graded activity")]
        public void VerifyGradesForManuallyGradedActivity()
        {
            //Verify the Score of Manually Graded Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifyGradesForManuallyGradedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify Score of Manually Graded Activity
            Logger.LogAssertion("VerifyGradesForManuallyGradedActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(ActivitySubmissionResource.
                    ActivitySubmission_ManuallySubmitted_Activity_GradeValue,
                    new GBStudentUXPage().GetManuallyGradedScore(
                    ActivitySubmissionResource.
                    ActivitySubmision_ManuallyGradable_Activity_Name)));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifyGradesForManuallyGradedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Edited Grade in ViewSubmission Page
        /// </summary>
        /// <param name="editedGrade">This is Edited Grade</param>
        [Then(@"I should see the edited grade ""(.*)"" in view submission page")]
        public void VerifyTheEditedGradeInViewSubmissionPage(String editedGrade)
        {
            //Verify the Edited Grade in ViewSubmission Page
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifyTheEditedGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Edited Grade in ViewSubmission Page
            Logger.LogAssertion("VerifyGradeinViewSubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(editedGrade,
                    new ViewSubmissionPage().GetGradefromViewSubmissionPage()));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifyTheEditedGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open Activity In Course Materials Tab.
        /// </summary>
        [When(@"I open activity in course materials tab")]
        public void OpenActivityInCourseMaterialsTab()
        {
            //Open Activity In Course Materials Tab
            Logger.LogMethodEntry("ActivitySubmission", "OpenActivityInCourseMaterialsTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Open Activity In Course Materials
            new CoursePreviewMainUXPage().OpenActivityInCourseMaterials();
            Logger.LogMethodExit("ActivitySubmission", "OpenActivityInCourseMaterialsTab",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Start pre test from study plan window.
        /// </summary>
        /// <param name="activityType">This is Activity Type</param>
        [When(@"I submit the pretest of ""(.*)""")]
        public void StartPreTest(String activityType)
        {
            //Start pre test
            Logger.LogMethodEntry("ActivitySubmission", "StartPreTest",
              base.IsTakeScreenShotDuringEntryExit);
            //Created Class Object
            StudentPresentationPage studentpresentationpage =
                new StudentPresentationPage();
            // Click on begin button
            new DRTDefaultUXPage().ClickBeginButton();
            // Click continue button on activity alert pop up
            new ShowMessagePage().ClickContinueInActivityAlert();
            //Select Pretest Window
            studentpresentationpage.SelectPretestWindow();
            //Attempt The Activity
            studentpresentationpage.AttemptTheActivityInCourseMaterials(activityType);
            //Finish and return to course selection
            studentpresentationpage.ClickOnFinishAndReturnToCourse();
            Logger.LogMethodExit("ActivitySubmission", "StartPreTest",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the activity after launching it.
        /// </summary>
        /// <param name="activityType">This is the activity type</param>
        [When(@"I submit the posttest of ""(.*)""")]
        public void SubmitThepostActivity(String activityType)
        {
            //Submit the Activity
            Logger.LogMethodEntry("ActivitySubmission", "SubmitThepostActivity",
             base.IsTakeScreenShotDuringEntryExit);
            //Created Class Object
            StudentPresentationPage studentpresentationpage =
                new StudentPresentationPage();
            // Click on begin button
            new DRTDefaultUXPage().ClickPostTestBeginButton();
            //Select Posttest Window
            studentpresentationpage.SelectPosttestWindow();
            //Attempt The Activity
            studentpresentationpage.AttemptTheActivityInCourseMaterials(activityType);
            //Finish and return to course selection
            studentpresentationpage.ClickOnFinishAndReturnToCourse();
            // Click on return to course button
            new DRTDefaultUXPage().ClickReturnToCourseButton();
            Logger.LogMethodEntry("ActivitySubmission", "SubmitThepostActivity",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Status Of Assets In Course Materials.
        /// </summary>   
        /// <param name="assetname">This is Asset Name</param>
        /// <param name="activityStatus">This is Activity status.</param>
        [Then(@"I should see the status of ""(.*)"" asset as ""(.*)""")]
        public void StatusOfAssetsInCourseMaterials(string assetName, String activityStatus)
        {
            //Status Of Assets In Course Materials
            Logger.LogMethodEntry("ActivityStatus",
                "StatusOfAssetsInCourseMaterials",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert the Activity Status
            Logger.LogAssertion("VerifyStatusOfActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityStatus, new CoursePreviewMainUXPage().
                    GetStatusOfActivityInCourseMaterialsTab(assetName)));
            Logger.LogMethodExit("ActivityStatus",
                "StatusOfAssetsInCourseMaterials",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity In CourseMaterials.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="activityBehavioralModesEnum">This is Activity Behavioral Mode Enum.</param>
        [When(@"I click on ""(.*)"" activity of behavioral mode ""(.*)""")]
        public void ClickOnActivityInCourseMaterials(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum activityBehavioralModesEnum)
        {
            //Verify The Activity In Course Materials Tab
            Logger.LogMethodEntry("ActivitySubmission", "ClickOnActivityInCourseMaterials",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Avtivity From Memory
            Activity activity = Activity.Get(activityTypeEnum, activityBehavioralModesEnum);
            //Click On Activity In CourseMaterials
            new CoursePreviewMainUXPage().GetActivityNameInCourseMaterialsTab(activity.Name);
            //Click On Continue in Activity Alert Popup
            new ShowMessagePage().ClickContinueInActivityAlert();
            Logger.LogMethodExit("ActivitySubmission", "ClickOnActivityInCourseMaterials",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity.
        /// </summary>
        /// <param name="activityType">This is Activity Type.</param>
        [When(@"I submit the ""(.*)"" activity")]
        public void SubmitTheActivity(string activityType)
        {
            //Submit The Activity
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheActivity",
                 base.IsTakeScreenShotDuringEntryExit);
            StudentPresentationPage studentPresentationPage = new StudentPresentationPage();
            //Click Start Button On Presentation Window
            studentPresentationPage.ClickStartButtonOnPresentationWindow(activityType);
            //Attempt Question In Presentation Page
            studentPresentationPage.AttemptQuestionInPresentationPage();            
            Logger.LogMethodExit("ActivitySubmission", "SubmitTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open the Activity As Student.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity by Type Enum.</param>
        [When(@"I open the ""(.*)"" Activity")]
        public void OpenTheActivityForSubmission(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Open The Activity As Student
            Logger.LogMethodEntry("ActivitySubmission", "OpenTheActivityForSubmission",
                base.IsTakeScreenShotDuringEntryExit);
            // Switch to default window after closing of presentation pop up            
            //Launch The Activity
            new CoursePreviewMainUXPage().OpenActivity(activityTypeEnum);
            Logger.LogMethodExit("ActivitySubmission", "OpenTheActivityForSubmission",
                base.IsTakeScreenShotDuringEntryExit);            
        }
        [Then(@"I should see the status of activity with learnosity audio question as ""(.*)""")]
        public void VerifyStatusOfActivityWithLearnosityAudioQuestion(String activityStatus)
        {
            //Verify the Status Of Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifyStatusOfActivityWithLearnosityAudioQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert the Activity Status
            Logger.LogAssertion("VerifyStatusOfActivityWithLearnosityAudioQuestion",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityStatus, new CoursePreviewMainUXPage().
                    GetStatusOfActivity(ActivitySubmissionResource.
                    ActivitySubmission_Contains_Learnosity_Audio_Question_Activity_Name)));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifyStatusOfActivityWithLearnosityAudioQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open the Activity with Learnosity audio question As Student.
        /// </summary>
        [When(@"I open the activity with learnosity audio essay question")]
        public void OpenTheActivityWithLearnosityAudioEssayQuestion()
        {
            Logger.LogMethodEntry("ActivitySubmission", "OpenTheActivityWithLearnosityAudioEssayQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            // Switch to default window after closing of presentation pop up            
            //Launch The Activity
            new CoursePreviewMainUXPage().OpenActivity(ActivitySubmissionResource.
                ActivitySubmission_Contains_Learnosity_Audio_Question_Activity_Name);
            Logger.LogMethodExit("ActivitySubmission", "OpenTheActivityWithLearnosityAudioEssayQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Submit The Activity with Learnosity Audio question.
        /// </summary>
        [When(@"I submit the 'Manually Gradable' Activity with learnosity audio question")]
        public void SubmitTheActivityWithLearnosityAudioQuestion()
        {
            //Submit the Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "SubmitTheActivityWithLearnosityAudioQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            //Declaration of object
            StudentPresentationPage studentPresentation =
                new StudentPresentationPage();
            //Select the window
            studentPresentation.SelectWebActivityWindow(ActivitySubmissionResource.
                ActivitySubmission_SAMActivity_WindowName);
            //Click the start button
            studentPresentation.AudioEssayQuestionSubmission();
            //Submit the Activity
            studentPresentation.FinishAndReturnToCourse();
            // Select close button on the Test window
            new InstructionsPage().ClickTestCloseButton();
            Logger.LogMethodExit("ActivitySubmission",
                "SubmitTheActivityWithLearnosityAudioQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the WL SAM activity to score 100.
        /// </summary>
        [When(@"I submit the SAM Activity to score '100'")]
        public void SubmitTheSAMActivity()
        {
            //Submit the WL SAM activity to score 100
            Logger.LogMethodEntry("ActivitySubmission",
                "SubmitTheSAMActivity",
                base.IsTakeScreenShotDuringEntryExit);
            new CourseContentUXPage().SubmitSAMActivityToScore100();
            Logger.LogMethodExit("ActivitySubmission",
               "SubmitTheSAMActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the WL SAM activity to score 0.
        /// </summary>
        [When(@"I submit SAM Activity to score '0'")]
        public void WhenISubmitSamActivity()
        {
            //Submit the WL SAM activity to score 0
            Logger.LogMethodEntry("ActivitySubmission",
                "WhenISubmitSamActivity",
                base.IsTakeScreenShotDuringEntryExit);
            new CourseContentUXPage().SubmitSamActivityToScore0();
            Logger.LogMethodExit("ActivitySubmission",
               "WhenISubmitSamActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }


    }
}
