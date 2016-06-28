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
                "SubmitTheSAMActivity",
                base.IsTakeScreenShotDuringEntryExit);
            bool found = new CourseContentUXPage().SubmitSAMActivityToSeeCorrectAnswers();
            Assert.AreEqual(true, found);
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
        /// 
        /// </summary>
        /// <param name="availaibilityStatus"></param>
        [Then(@"I should the availibility of Save For Later is ""(.*)"" in ""(.*)"" Activity Presentation Window")]
        public void VerifyTheAvailibilityOfSaveForLater(bool availaibilityStatus,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            Logger.LogMethodEntry("ActivitySubmission",
          "VerifyTheAvailibilityOfSaveForLater",
          base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            string windowTitle = activity.Name.ToString();
            //Switch to Activity Presentation Window
            base.WaitUntilWindowLoads(windowTitle);
            Assert.AreEqual(availaibilityStatus, 
                new StudentPresentationPage().VerifySaveForLaterButton());
            Logger.LogMethodExit("ActivitySubmission",
         "VerifyTheAvailibilityOfSaveForLater",
         base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I Verify Confirmation Message on Save the Activity for later")]
        public void SaveTheActivityForLater()
        {
            Logger.LogMethodEntry("ActivitySubmission",
          "SaveTheActivityForLater",
          base.IsTakeScreenShotDuringEntryExit);
            new StudentPresentationPage().ClickOnSaveForLater();
            Logger.LogMethodExit("ActivitySubmission",
         "SaveTheActivityForLater",
         base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see ""(.*)"" questions answers saved in Page ""(.*)"" of ""(.*)"" Activity Presentation Window")]
        public void VerifySaveForLaterData(int questionCount, int pageNumber, 
            Activity.ActivityTypeEnum activityTypeEnum)
        {

            Logger.LogMethodEntry("ActivitySubmission",
          "VerifySaveForLaterData",
          base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            string windowTitle = activity.Name.ToString();
            //Switch to Activity Presentation Window
            base.WaitUntilWindowLoads(windowTitle);
            Assert.IsTrue(new StudentPresentationPage().
                VerifySavedFillInTheBlanksQuestionAnswers(questionCount));

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
        /// <param name="activityTypeEnum"></param>
        [Then(@"I am on ""(.*)"" window")]
        [Given(@"I am on ""(.*)"" window")]
        public void SelectPresentationWindow(Activity.ActivityTypeEnum activityTypeEnum)
        {
            Activity activity = Activity.Get(activityTypeEnum);
            string windowTitle = activity.Name.ToString();
            //Switch to Activity Presentation Window
            base.WaitUntilWindowLoads(windowTitle);
        }

        /// <summary>
        /// Verify Beginning/end Messages at Presentation Window.
        /// </summary>
        /// <param name="p0">messageType</param>
        /// <param name="p1">availabilityStatus</param>
        [Then(@"I should see the availability of ""(.*)"" message is ""(.*)""")]
        public void VerifyMessagesInPresentation(string messageType,
            string availabilityStatus)
        {
            Assert.AreEqual(availabilityStatus, new StudentPresentationPage().
                VerifyMessageStatus(messageType).ToString());
        }

        /// <summary>
        /// Verify Message Button in Presentation Window
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        [Then(@"I should see see the availability of ""(.*)"" Button is ""(.*)""")]
        public void VerifyMessageButton(string buttonType, string availabilityStatus)
        {
            Assert.AreEqual(availabilityStatus, new StudentPresentationPage().
                VerifyMessageButtonStatus(buttonType).ToString());
        }

        /// <summary>
        /// Click Message Button.
        /// </summary>
        /// <param name="p0"></param>
        [When(@"I click on ""(.*)"" Button")]
        public void ClickOnMessageButton(string buttonType)
        {

            new StudentPresentationPage().
                  ClickMessageButton(buttonType);
        }

        /// <summary>
        /// Verify Activity Direction Lines.
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        [Then(@"I should see the availibility ""(.*)"" at Page is ""(.*)""")]
        public void VerifyActivityDirectionLines(string directionType, string availabilityStatus)
        {
            Assert.AreEqual(availabilityStatus, new StudentPresentationPage().
               VerifyActivityDirectionLine(directionType).ToString());

        }


        [Then(@"I should see the Section Direction lines for Section ""(.*)""")]
        public void VerifySectionDirectionLinesAtPresentation(string sectionNumber)
        {
            Assert.IsTrue(new StudentPresentationPage().
                VerifySectionDirectionLines(sectionNumber));
        }
    }
}
