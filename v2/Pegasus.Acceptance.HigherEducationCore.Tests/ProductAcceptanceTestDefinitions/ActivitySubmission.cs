using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
using TechTalk.SpecFlow;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Acceptance.HigherEducation.WL.Tests.CommonProductAcceptanceTestDefinitions;
using System.Globalization;
using System.Threading;

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
        /// Attempt Fill In The Blanks Questions at Presentation Window based on the answer type.
        /// </summary>
        /// <param name="questionCount">Number of Questions to be Answered.</param>
        /// <param name="pageNumber">The Page Number.</param>
        /// <param name="activityTypeEnum">This the activity Type Enum.</param>
        [When(@"I attempt ""(.*)"" questions listed in Page ""(.*)"" of ""(.*)"" Activity Presentation Window with ""(.*)"" answer")]
        public void AttemptFillInTheBlanksQuestions(int questionCount, int pageNumber,
            Activity.ActivityTypeEnum activityTypeEnum, string answerType)
        {
            // Attempt Fill In The Blanks Questions at Presentation Window
            Logger.LogMethodEntry("ActivitySubmission",
             "AttemptSpecificNumberOfFillInTheBlanksQuestions",
             base.IsTakeScreenShotDuringEntryExit);
            //Get the Activity Details
            Activity activity = Activity.Get(activityTypeEnum);
            string windowTitle = activity.Name.ToString();
            //Switch to Activity Presentation Window
            base.WaitUntilWindowLoads(windowTitle);
            switch (answerType)
            {
                case "Valid":
                    // Attempt Fill In The Blanks Questions at Presentation Window with correct answer
                    new StudentPresentationPage().AttemptFillInTheBlanksQuestionsValidAnswer(questionCount);
                    break;
                case "In Valid":
                    // Attempt Fill In The Blanks Questions at Presentation Window with incorrect answer
                    new StudentPresentationPage().AttemptFillInTheBlanksQuestionsInValidAnswer(questionCount);
                    break;
            }
            Logger.LogMethodExit("ActivitySubmission",
             "AttemptSpecificNumberOfFillInTheBlanksQuestions",
             base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate for the feedback icon existance in presenation page 
        /// </summary>
        /// <param name="activityType">This is acivity type enum.</param>
        [Then(@"I should be displayed with Feedback Icon in ""(.*)"" window")]
        public void StudentValidateFeedbackIconExistance(Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("ActivitySubmission", "StudentValidateFeedbackIconExistance", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("activityStatus", ScenarioContext.Current.ScenarioInfo.
              Title, () => Assert.AreEqual(true, new CourseContentUXPage().GetFeedbackIconStatus(activityType)));
            Logger.LogMethodExit("ActivitySubmission", "StudentValidateFeedbackIconExistance", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Student click on Feedback Icon in presentaion window
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        [When(@"I click on the Feedback Icon in ""(.*)"" window")]
        public void ClickOnTheFeedbackIcon(Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("ActivitySubmission", "ClickOnTheFeedbackIcon", base.IsTakeScreenShotDuringEntryExit);
            new CourseContentUXPage().StudentClickFeedBackIcon(activityType);
            Logger.LogMethodExit("ActivitySubmission", "ClickOnTheFeedbackIcon", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get feedback text and validate
        /// </summary>
        /// <param name="feedBackText">This is feedback text.</param>
        /// <param name="activityType">This is activity type.</param>
        [Then(@"I should displayed with ""(.*)"" text in ""(.*)"" window")]
        public void ValidateFeedbackText(string feedBackText, Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("ActivitySubmission", "ValidateFeedbackText", base.IsTakeScreenShotDuringEntryExit);
            // Assert the expected and actual number of question in Presentation page
            Logger.LogAssertion("activityStatus", ScenarioContext.Current.ScenarioInfo.
            Title, () => Assert.AreEqual(feedBackText, new CourseContentUXPage().GetFeedbackText(activityType)));
            Logger.LogMethodExit("ActivitySubmission", "ValidateFeedbackText", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Student submit the answered activity
        /// </summary>
        /// <param name="activityType">This activity type enum.</param>
        [When(@"I submit the answered activity ""(.*)""")]
        public void SubmitTheAnsweredActivity(Activity.ActivityTypeEnum activityType)
        {
            // Submit the Activity
            Logger.LogMethodEntry("ActivitySubmission",
            "SubmitTheAnsweredActivity",
            base.IsTakeScreenShotDuringEntryExit);
            // Submit the Activity
            new CourseContentUXPage().StudentSubmitAnsweredActivity(activityType);
            Logger.LogMethodExit("ActivitySubmission",
           "SubmitTheAnsweredActivity",
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
            new DrtDefaultUxPage().ClickBeginButton();
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
            new DrtDefaultUxPage().ClickPostTestBeginButton();
            //Select Posttest Window
            studentpresentationpage.SelectPosttestWindow();
            //Attempt The Activity
            studentpresentationpage.AttemptTheActivityInCourseMaterials(activityType);
            //Finish and return to course selection
            studentpresentationpage.ClickOnFinishAndReturnToCourse();
            // Click on return to course button
            new DrtDefaultUxPage().ClickReturnToCourseButton();
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
        /// Submit the WL SAM activity to see correct Answers.
        /// </summary>
        [When(@"I submit the SAM Activity to score and to see correct answers")]
        public void WhenISubmitToSeeCorrectAnswers()
        {
            //Submit the WL SAM activity to score 100
            Logger.LogMethodEntry("ActivitySubmission",
                "WhenISubmitToSeeCorrectAnswers",
                base.IsTakeScreenShotDuringEntryExit);
            bool found = new CourseContentUXPage().SubmitSAMActivityToSeeCorrectAnswers();
            Assert.AreEqual(true, found);
            Logger.LogMethodExit("ActivitySubmission",
               "WhenISubmitToSeeCorrectAnswers",
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

        /// <summary>
        /// Verify Number of Question listed in Presentation Window.
        /// </summary>
        /// <param name="numberOfQuestions">Number of Questions.</param>
        /// <param name="pageNo">The Page Number.</param>
        /// <param name="activityTypeEnum">This is the activity type enum.</param>
        [Then(@"I should see '(.*)' questions listed in Page ""(.*)"" of ""(.*)"" Activity Presentation Window")]
        public void VerifyNumberOfQuestionsListedInPage(int numberOfQuestions, int pageNo,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Verify Number of Question listed in Presentation Window
            Logger.LogMethodEntry("ActivitySubmission",
              "VerifyNumberOfQuestionsListedInPage",
              base.IsTakeScreenShotDuringEntryExit);
            //Get the Activity Details
            Activity activity = Activity.Get(activityTypeEnum);
            string windowTitle = activity.Name.ToString();
            base.WaitUntilWindowLoads(windowTitle);
            // Assert the expected and actual number of question in Presentation page
            Assert.AreEqual(numberOfQuestions, new StudentPresentationPage().GetNumberOfQuetionsInAPage());
            Logger.LogMethodExit("ActivitySubmission",
              "VerifyNumberOfQuestionsListedInPage",
              base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Navigate to next page in Presentation Window.
        /// </summary>
        [When(@"I navigate to next page")]
        public void NavigateToNextPageInPresentationWindow()
        {
            // Navigate to next page in Presentation Window
            Logger.LogMethodEntry("ActivitySubmission",
             "NavigateToNextPageInPresentationWindow",
             base.IsTakeScreenShotDuringEntryExit);
            // Navigate to next page in Presentation Window
            new StudentPresentationPage().ClickNextPage();
            Logger.LogMethodExit("ActivitySubmission",
             "NavigateToNextPageInPresentationWindow",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt Fill In The Blanks Questions at Presentation Window.
        /// </summary>
        /// <param name="questionCount">Number of Questions to be Answered.</param>
        /// <param name="pageNumber">The Page Number.</param>
        /// <param name="activityTypeEnum">This the activity Type Enum.</param>
        [When(@"I attempt ""(.*)"" questions listed in Page ""(.*)"" of ""(.*)"" Activity Presentation Window")]
        public void AttemptSpecificNumberOfFillInTheBlanksQuestions(int questionCount, int pageNumber,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Attempt Fill In The Blanks Questions at Presentation Window
            Logger.LogMethodEntry("ActivitySubmission",
             "AttemptSpecificNumberOfFillInTheBlanksQuestions",
             base.IsTakeScreenShotDuringEntryExit);
            //Get the Activity Details
            Activity activity = Activity.Get(activityTypeEnum);
            string windowTitle = activity.Name.ToString();
            //Switch to Activity Presentation Window
            base.WaitUntilWindowLoads(windowTitle);
            // Attempt Fill In The Blanks Questions at Presentation Window
            new StudentPresentationPage().AttemptFillInTheBlanksQuestions(questionCount);
            Logger.LogMethodExit("ActivitySubmission",
             "AttemptSpecificNumberOfFillInTheBlanksQuestions",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Warning message on attempt is not complete on grading.
        /// </summary>
        [Then(@"I should see warning message on submission of activity for grading")]
        public void VerifyWarningMessageOnSubmissionOfIncompleteActivity()
        {
            // Verify Warning message on attempt is not complete on grading
            Logger.LogMethodEntry("ActivitySubmission",
           "VerifyWarningMessageOnSubmissionOfIncompleteActivity",
           base.IsTakeScreenShotDuringEntryExit);
            //this is the expected warning message
            string expectedWarning = "You must answer all questions before you can submit your work for grading.";
            // Verify Warning message on attempt is not complete on grading
            Assert.IsTrue(new StudentPresentationPage().VerifyWarningMessage(expectedWarning));
            Logger.LogMethodExit("ActivitySubmission",
          "VerifyWarningMessageOnSubmissionOfIncompleteActivity",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the Activity.
        /// </summary>
        [When(@"I should successfully submit activity for grading")]
        [Then(@"I should successfully submit activity for grading")]
        public void SubmitActivityForGrading()
        {
            // Submit the Activity
            Logger.LogMethodEntry("ActivitySubmission",
            "SubmitActivityForGrading",
            base.IsTakeScreenShotDuringEntryExit);
            // Submit the Activity
            new CourseContentUXPage().SubmitActivityCSDisplay();
            Logger.LogMethodExit("ActivitySubmission",
           "SubmitActivityForGrading",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Availibility Of Save For Later in Presentation Window in 
        /// default Style Sheet.
        /// </summary>
        /// <param name="availabilityStatus">This is expected availability status.</param>
        [Then(@"I should the availibility of Save For Later is ""(.*)"" in ""(.*)"" Activity Presentation Window")]
        public void VerifyTheAvailibilityOfSaveForLater(bool availabilityStatus,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Verify The Availibility Of Save For Later in Presentation Window in 
            // default Style Sheet
            Logger.LogMethodEntry("ActivitySubmission",
          "VerifyTheAvailibilityOfSaveForLater",
          base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            string windowTitle = activity.Name.ToString();
            //Switch to Activity Presentation Window
            base.WaitUntilWindowLoads(windowTitle);
            // Verify The Availibility Of Save For Later in Presentation Window in 
            // default Style Sheet
            Assert.AreEqual(availabilityStatus,
                new StudentPresentationPage().VerifySaveForLaterButton());
            Logger.LogMethodExit("ActivitySubmission",
         "VerifyTheAvailibilityOfSaveForLater",
         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save For Later in Default Style Sheet.
        /// </summary>
        [Then(@"I Verify Confirmation Message on Save the Activity for later")]
        public void SaveTheActivityForLater()
        {
            // Click on Save For Later in Default Style Sheet
            Logger.LogMethodEntry("ActivitySubmission",
          "SaveTheActivityForLater",
          base.IsTakeScreenShotDuringEntryExit);
            // Click on Save For Later in Default Style Sheet
            new StudentPresentationPage().ClickOnSaveForLater();
            Logger.LogMethodExit("ActivitySubmission",
         "SaveTheActivityForLater",
         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Data saved on performin "Save For Later".
        /// </summary>
        /// <param name="questionCount">This is the Question Number.</param>
        /// <param name="pageNumber">This is the Presentation Page Number.</param>
        /// <param name="activityTypeEnum">This the Acitivity Type Enum.</param>
        [Then(@"I should see ""(.*)"" questions answers saved in Page ""(.*)"" of ""(.*)"" Activity Presentation Window")]
        public void VerifySaveForLaterData(int questionCount, int pageNumber,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Verify the Data saved on performin "Save For Later"
            Logger.LogMethodEntry("ActivitySubmission",
          "VerifySaveForLaterData",
          base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            string windowTitle = activity.Name.ToString();
            //Switch to Activity Presentation Window
            base.WaitUntilWindowLoads(windowTitle);
            Assert.IsTrue(new StudentPresentationPage().
                VerifySavedFillInTheBlanksQuestionAnswersForRandomActivity(questionCount));

            Logger.LogMethodExit("ActivitySubmission",
          "VerifySaveForLaterData",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate activity status of the activity.
        /// </summary>
        /// <param name="activityStatus">This is the expected status.</param>
        /// <param name="activityName">This the activity name.</param>
        [Then(@"I should see the ""(.*)"" status for the activity ""(.*)""")]
        public void StatusForTheActivity(string activityStatus,
             Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Validate the submitted activity status
            Logger.LogMethodEntry("CommonSteps",
                "StatusForTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            string activityName = activity.Name;
            //Validate the submitted activity status
            Logger.LogAssertion("ValidateActivityStatus", ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.AreEqual(activityStatus, new StudentPresentationPage().
                    GetStatusOfSubmittedActivityInCourseMaterial(activityName)));
            Logger.LogMethodExit("CommonSteps",
                "StatusForTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to presentation window.
        /// </summary>
        /// <param name="activityTypeEnum">This the activity type</param>
        [Then(@"I am on ""(.*)"" window")]
        [When(@"I am on ""(.*)"" window")]
        [Given(@"I am on ""(.*)"" window")]
        public void SelectPresentationWindow(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Switch to presentation window
            Logger.LogMethodEntry("CommonSteps",
               "SelectPresentationWindow",
               base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            string windowTitle = activity.Name.ToString();
            //Switch to Activity Presentation Window
            base.WaitUntilWindowLoads(windowTitle);
            Logger.LogMethodExit("CommonSteps",
              "SelectPresentationWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the window existance
        /// </summary>
        /// <param name="activityTypeEnum">This the activity type</param>
        [Then(@"I should be on ""(.*)"" window")]
        public void ValidateWindowExistance(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Switch to presentation window
            Logger.LogMethodEntry("CommonSteps",
               "SelectPresentationWindow",
               base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            string windowTitle = activity.Name.ToString();
            //Switch to Activity Presentation Window
            base.WaitUntilWindowLoads(windowTitle);
            Logger.LogAssertion("ValidateActivityStatus", ScenarioContext.Current.ScenarioInfo.
            Title, () => Assert.AreEqual(windowTitle, new StudentPresentationPage().
             GetPageName()));
            new StudentPresentationPage().validateButtonExistanceAndClick();
            Logger.LogMethodExit("CommonSteps",
              "SelectPresentationWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify Beginning/end Messages at Presentation Window.
        /// </summary>
        /// <param name="messageType">messageType</param>
        /// <param name="availabilityStatus">availabilityStatus</param>
        [Then(@"I should see the availability of ""(.*)"" message is ""(.*)""")]
        public void VerifyMessagesInPresentation(string messageType,
            string availabilityStatus)
        {
            // Verify Beginning/end Messages at Presentation Window
            Logger.LogMethodEntry("CommonSteps",
            "VerifyMessagesInPresentation",
            base.IsTakeScreenShotDuringEntryExit);
            // Verify Beginning/end Messages at Presentation Window
            Assert.AreEqual(availabilityStatus, new StudentPresentationPage().
                VerifyMessageStatus(messageType).ToString());
            Logger.LogMethodExit("CommonSteps",
              "VerifyMessagesInPresentation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Message Button in Presentation Window.
        /// </summary>
        /// <param name="buttonType">This is the button type.</param>
        /// <param name="availabilityStatus">This is the expected availability status.</param>
        [Then(@"I should see see the availability of ""(.*)"" Button is ""(.*)""")]
        public void VerifyMessageButton(string buttonType, string availabilityStatus)
        {
            // Verify Message Button in Presentation Window
            Logger.LogMethodEntry("CommonSteps",
            "VerifyMessageButton",
            base.IsTakeScreenShotDuringEntryExit);
            Assert.AreEqual(availabilityStatus, new StudentPresentationPage().
                VerifyMessageButtonStatus(buttonType).ToString());
            Logger.LogMethodExit("CommonSteps",
             "VerifyMessageButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Message Button.
        /// </summary>
        /// <param name="p0">This is button type.</param>
        [When(@"I click on ""(.*)"" Button")]
        public void ClickMessageButton(string buttonType)
        {
            // Click Message Button
            Logger.LogMethodEntry("CommonSteps",
              "ClickMessageButton",
              base.IsTakeScreenShotDuringEntryExit);
            // Click Message Button
            new StudentPresentationPage().
                  ClickMessageButton(buttonType);
            Logger.LogMethodExit("CommonSteps",
            "ClickMessageButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Activity Direction Lines.
        /// </summary>
        /// <param name="directionType">This is direction line type.</param>
        /// <param name="availabilityStatus">This is direction line type.</param>
        [Then(@"I should see the availibility ""(.*)"" at Page is ""(.*)""")]
        public void VerifyActivityDirectionLines(string directionType, string availabilityStatus)
        {
            // Verify Activity Direction Lines
            Logger.LogMethodEntry("CommonSteps",
              "VerifyActivityDirectionLines",
              base.IsTakeScreenShotDuringEntryExit);
            // Verify Activity Direction Lines
            Assert.AreEqual(availabilityStatus, new StudentPresentationPage().
               VerifyActivityDirectionLine(directionType).ToString());
            Logger.LogMethodExit("CommonSteps",
            "VerifyActivityDirectionLines",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the activity status and validate the result
        /// </summary>
        /// <param name="activityStatus">This is activity status.</param>
        /// <param name="activityType">This is activity type enum.</param>
        /// <param name="pageName">This is page name.</param>
        [Then(@"I should see ""(.*)"" status for the activity ""(.*)"" from ""(.*)"" page")]
        public void ValidateTheActivityStatus(string activityStatus, Activity.ActivityTypeEnum activityType, string pageName)
        {
            Logger.LogMethodEntry("ActivitySubmission", "ValidateTheActivityStatus", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("activityStatus", ScenarioContext.Current.ScenarioInfo.
              Title, () => Assert.AreEqual(activityStatus, new CoursePreviewMainUXPage().GetActivityStatus(activityType,

pageName)));
            Logger.LogMethodExit("ActivitySubmission", "ValidateTheActivityStatus", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Student enter answers and click on Return To Course button
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        /// <param name="activityType">This is activity type enum.</param>
        [When(@"I click on ""(.*)"" button in ""(.*)"" window")]
        public void ClickOnReturnToCourseButton(string buttonName, Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("ActivitySubmission", "ClickOnReturnToCourseButton", base.IsTakeScreenShotDuringEntryExit);
            new StudentPresentationPage().ClickReturnToCourseButtonStudentPresentation(buttonName, activityType);
            Logger.LogMethodExit("ActivitySubmission", "ClickOnReturnToCourseButton", base.IsTakeScreenShotDuringEntryExit);
        }

        //When I click on "Try Again" button of "RegChildActivity" 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        [When(@"I click on ""(.*)"" button of ""(.*)""")]
        public void ClickOnButton(string buttonName, Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("ActivitySubmission", "ClickOnButton", base.IsTakeScreenShotDuringEntryExit);
            new StudentPresentationPage().ClickOnButtonStudentPresentation(buttonName, activityType);
            Logger.LogMethodExit("ActivitySubmission", "ClickOnButton", base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should be displayed with ""(.*)"" score page")]
        public void ValidateStudentScoreInViewSubmission(int score)
        {
            Logger.LogMethodEntry("ActivitySubmission", "ValidateActivityHasBeenStartedAndSavedMessage",
            base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateActivityHasBeenStartedAndSavedMessage", ScenarioContext.
        Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true, new ViewSubmissionPage().
        GetScoreInViewSubmission(score)));
            Logger.LogMethodExit("ActivitySubmission", "ValidateActivityHasBeenStartedAndSavedMessage",
                base.IsTakeScreenShotDuringEntryExit);
        }
        [When(@"I attempt questions listed in Page ""(.*)"" of ""(.*)"" Activity Presentation Window")]
        public void StudentAttemptQuestionsInActivityPresentationWindow(int questionCount,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Attempt Fill In The Blanks Questions at Presentation Window
            Logger.LogMethodEntry("ActivitySubmission",
             "StudentAttemptQuestionsInActivityPresentationWindow",
             base.IsTakeScreenShotDuringEntryExit);
            //Get the Activity Details
            Activity activity = Activity.Get(activityTypeEnum);
            string windowTitle = activity.Name.ToString();
            //Switch to Activity Presentation Window
            base.WaitUntilWindowLoads(windowTitle);
            // Attempt Fill In The Blanks Questions at Presentation Window
            new StudentPresentationPage().AttemptFillInTheBlanksQuestions(questionCount);
            Logger.LogMethodExit("ActivitySubmission",
             "StudentAttemptQuestionsInActivityPresentationWindow",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on next button in the activity presenation window to ansewer next question
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        [When(@"I click on next button in ""(.*)"" Activity Presentation Window")]
        public void ClickOnNextButtonInActivityPresentationWindow(Activity.ActivityTypeEnum activityTypeEnum)
        {
            Logger.LogMethodEntry("ActivitySubmission", "ClickOnNextButtonInActivityPresentationWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //new StudentPresentationPage().ClickNextButtonToAnswerNextQuestion();
            Logger.LogMethodExit("ActivitySubmission", "ClickOnNextButtonInActivityPresentationWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close activity presentation window abruptly
        /// </summary>
        [When(@"I close activity presenation window Abruptly")]
        public void CloseActivityPresenationWindowAbruptly()
        {
            Logger.LogMethodEntry("ActivitySubmission", "CloseActivityPresenationWindowAbruptly",
                base.IsTakeScreenShotDuringEntryExit);
            new StudentPresentationPage().ClosePersenationWindowAbruptly();
            Logger.LogMethodExit("ActivitySubmission", "CloseActivityPresenationWindowAbruptly",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// When I click on "View All Submission" of  "RegSAMActivity" Activity in "Course Materials" page
        /// </summary>
        /// <param name="assetCmenu">This is cmenu option name.</param>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        /// <param name="pageName">This is page name.</param>
        [When(@"I click on ""(.*)"" of  ""(.*)"" Activity in ""(.*)"" page")]
        public void ClickActivityCmenuOptionBasedOnPageName(string assetCmenu,
            Activity.ActivityTypeEnum activityTypeEnum, string pageName)
        {
            Logger.LogMethodEntry("ActivitySubmission", "ClickActivityCmenuOptionBasedOnPageName",
                base.IsTakeScreenShotDuringEntryExit);
            // Get Activity Name
            Activity activity = Activity.Get(activityTypeEnum);
            string activityName = activity.Name.ToString();
            new CoursePreviewUXPage().ClickCmenuOptionOfTheActivity(assetCmenu, activityName, pageName);
            Logger.LogMethodExit("ActivitySubmission", "ClickActivityCmenuOptionBasedOnPageName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Folder cmenu options
        /// </summary>
        /// <param name="assetCmenu">This is the c.menu option</param>
        /// <param name="activityTypeEnum">This is the activity type</param>
        /// <param name="pageName">This is the page name</param>
        [When(@"I click on ""(.*)"" of  ""(.*)"" Folder in ""(.*)"" page")]
        public void ClickOnOfFolder(string assetCmenu,
            Activity.ActivityTypeEnum activityTypeEnum, string pageName)
        {
            Logger.LogMethodEntry("ActivitySubmission", "ClickOnOfFolder",
                base.IsTakeScreenShotDuringEntryExit);
            // Get Folder Name
            Activity activity = Activity.Get(activityTypeEnum);
            string folderName = activity.Name.ToString();
            //Click on the folder cmenu options
            new CoursePreviewUXPage().ClickCmenuOptionOfTheFolder(assetCmenu, folderName, pageName);
            Logger.LogMethodExit("ActivitySubmission", "ClickOnOfFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Launch the activity based on the user type and page type provided
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <param name="pageName">This is the page name where the user action is intended to be performed.</param>
        [When(@"I launch the  ""(.*)"" Activity as ""(.*)"" from ""(.*)"" page")]
        public void LaunchTheActivityBasedOnTheUserRole(Activity.ActivityTypeEnum activityTypeEnum, User.UserTypeEnum userTypeEnum, string pageName)
        {
            Logger.LogMethodEntry("ActivitySubmission", "LaunchTheActivityBasedOnTheUserRole",

            base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewMainUXPage().LaunchTheActivityBasedOnTheUserTypeAndPage(activityTypeEnum, userTypeEnum, pageName);
            Thread.Sleep(1000);
            new StudentPresentationPage().SelectActivityPresentaionWindow();
            Logger.LogMethodExit("ActivitySubmission", "LaunchTheActivityBasedOnTheUserRole", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the page title 
        /// </summary>
        /// <param name="expectedPageTitle">This is expected page title</param>
        [Then(@"I should be on ""(.*)"" page")]
        public void ShowThePageInPegasus(Activity.ActivityTypeEnum activityType)
        {
            //Verify Correct Page Opened
            Logger.LogMethodEntry("CommonSteps", "ShowThePageInPegasus",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activityName = Activity.Get(activityType);
            string expectedPageTitle = activityName.Name.ToString();
            new StudentPresentationPage().SelectActivityPresentaionWindow();
            //Get current opened page title
            string actualPageTitle =
                WebDriver.Title.ToString(CultureInfo.InvariantCulture);
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedPageTitle, actualPageTitle));
            Logger.LogMethodExit("CommonSteps", "ShowThePageInPegass",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate Activity Has Been Started And Saved Message
        /// </summary>
        /// <param name="message">This is message title.</param>
        [Then(@"I should see the message ""(.*)"" in view submission page")]
        public void ValidateActivityHasBeenStartedAndSavedMessage(string message)
        {
            Logger.LogMethodEntry("ActivitySubmission", "ValidateActivityHasBeenStartedAndSavedMessage",

base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateActivityHasBeenStartedAndSavedMessage", ScenarioContext.
        Current.ScenarioInfo.Title,
                () => Assert.AreEqual(message, new ViewSubmissionPage().
        GetMessageInViewSubmission()));
            Logger.LogMethodExit("ActivitySubmission", "ValidateActivityHasBeenStartedAndSavedMessage",

base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify Activity Alter indicating activity can be tried only once and continue to the activity
        /// </summary>
        [When(@"I should see Activity Alter indicating activity can be tried only once")]
        public void VerifyActivityAlterIndicatingActivityCanBeTriedOnlyOnce()
        {
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifyActivityAlterIndicatingActivityCanBeTriedOnlyOnce",
                base.IsTakeScreenShotDuringEntryExit);
            //Switch to Activity Alert Window and click Continue button
            new ShowMessagePage().ClickContinueInActivityAlert();
            Logger.LogMethodExit("ActivitySubmission",
                "VerifyActivityAlterIndicatingActivityCanBeTriedOnlyOnce",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify message in the Test Presentation Window indicating there are no more attempts available for the activity
        /// </summary>
        /// <param name="message">This is the message</param>
        //[Then(@"I should see a message ""(.*)"" in the""(.*)"" Activity")]
        //[Then(@"I should see a message ""(.*)"" in the Test Presentation Window")]
        [Then(@"I should see a message ""(.*)"" in the ""(.*)"" Window")]
        public void VerifyMessageInTheTestPresentationWindow(string message,
            string windowName)
        {
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifyMessageInTheTestPresentationWindow",
                base.IsTakeScreenShotDuringEntryExit);
            ////Get the Activity Details
            //Activity activity = Activity.Get(activityTypeEnum);
            //string windowTitle = activity.Name.ToString();
            //Switch to Activity Presentation Window
            base.WaitUntilWindowLoads(windowName);
            Logger.LogAssertion("VerifyMessageInTheTestPresentationWindow",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(message, new StudentPresentationPage().
                   VerifyMessageInTestPresentationWindow()));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifyMessageInTheTestPresentationWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Section Direction Lines at Presentation Window.
        /// </summary>
        /// <param name="sectionNumber"></param>
        [Then(@"I should see the Section Direction lines for Section ""(.*)""")]
        public void VerifySectionDirectionLinesAtPresentation(string sectionNumber)
        {
            // Verify Section Direction Lines at Presentation Window
            Logger.LogMethodEntry("CommonSteps",
            "VerifySectionDirectionLinesAtPresentation",
            base.IsTakeScreenShotDuringEntryExit);
            // Verify Section Direction Lines at Presentation Window
            Assert.IsTrue(new StudentPresentationPage().
                VerifySectionDirectionLines(sectionNumber));
            Logger.LogMethodExit("CommonSteps",
            "VerifySectionDirectionLinesAtPresentation",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the score recorded in Gradebook is as per the score preference
        /// </summary>
        /// <param name="userType">This is the user role</param>
        /// <param name="gbScore">This is the Gradebook score preference</param>
        [Then(@"as ""(.*)"" I should see the ""(.*)"" score recorded")]
        public void TheScoreRecorded(User.UserTypeEnum userType, string gbScore)
        {
            // Verify the score recorded in Gradebook is as per the score preference
            Logger.LogMethodEntry("ActivitySubmission",
                "TheScoreRecorded"
                , base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyRecordedScoresMatchtheScorePreference",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(gbScore, new
                    ViewSubmissionPage().verifyGradebookScore(userType, gbScore)));
            Logger.LogMethodExit("ActivitySubmission",
               "TheScoreRecorded"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select answer for True/False question
        /// </summary>
        /// <param name="answerChoice">This is the answer choice</param>
        [When(@"I select ""(.*)"" answer for True/False question")]
        [Then(@"I select ""(.*)"" answer for True/False question")]
        public void SelectCAnswerForQuestion(string answerChoice)
        {
            //Select correct answer for the question
            Logger.LogMethodEntry("ActivitySubmission",
                "SelectCorrectAnswerForQuestion"
                , base.IsTakeScreenShotDuringEntryExit);
            new StudentPresentationPage().SelectAnswer(answerChoice);
            Logger.LogMethodExit("ActivitySubmission",
               "SelectCorrectAnswerForQuestion"
               , base.IsTakeScreenShotDuringEntryExit);

        }
    }
}
