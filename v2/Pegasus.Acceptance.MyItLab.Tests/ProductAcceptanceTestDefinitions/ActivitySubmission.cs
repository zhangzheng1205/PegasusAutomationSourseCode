using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles Activity Submission Actions.
    /// </summary>

    [Binding]
    public class ActivitySubmission : PegasusBaseTestFixture
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ActivitySubmission));

        /// <summary>
        /// Submit The Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode Enum.</param>
        [When(@"I submit the ""(.*)"" activity of behavioral mode ""(.*)"" type")]
        public void SubmitTheActivity(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Submit The Activity
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheActivity",
               base.isTakeScreenShotDuringEntryExit);
            CalendarFramePage calendarFramePage = new CalendarFramePage();
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralModeEnum);
            //Select Window And Frame
            calendarFramePage.SelectWindowAndFrame();
            //Click On Calendar Icon
            calendarFramePage.ClickOnCalendarIcon();
            //Submit SIM Activity
            new StudentPresentationPage().SubmitSIMActivity(activity.Name);
            Logger.LogMethodExit("ActivitySubmission", "SubmitTheActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Sim Activity Submission In CourseMaterials.
        /// </summary>
        /// <param name="activityStatus">This is Activity Status.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode Enum.</param>
        [Then(@"I should see the ""(.*)"" status of the ""(.*)"" activity of behavioral mode ""(.*)"" type")]
        public void VerifySimActivitySubmissionInCourseMaterials(string activityStatus,
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Verify Sim Activity Submission In CourseMaterials
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifySimActivitySubmissionInCourseMaterials",
               base.isTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralModeEnum);
            // Assert Activity Submission
            Logger.LogAssertion("VerifyActivitySubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityStatus,
                    new StudentPresentationPage().
                    GetStatusOfSubmittedActivityInCourseMaterial(activity.Name)));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifySimActivitySubmissionInCourseMaterials",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Sim Activity Submission In Calendar.
        /// </summary>
        /// <param name="activityStatus">This is Activity Status.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode Enum.</param>
        [Then(@"I should see ""(.*)"" status of the ""(.*)"" activity of behavioral mode ""(.*)"" type")]
        public void VerifySimActivitySubmissionInCalendar(string activityStatus,
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Verify Sim Activity Submission In Calendar
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifySimActivitySubmissionInCalendar",
               base.isTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralModeEnum);
            // Assert Activity Submission
            Logger.LogAssertion("VerifyActivitySubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityStatus,
                    new CourseCalendarPage().
                    GetStatusOfSubmittedActivityInCalendar(activity.Name)));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifySimActivitySubmissionInCalendar",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The StudyPlan Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode Enum.</param>
        [When(@"I submit the ""(.*)"" activity of behavioral mode type ""(.*)"" using Training Material")]
        public void SubmitTheTrainingMaterialStudyPlanActivity(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Submit The StudyPlan Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "SubmitTheTrainingMaterialStudyPlanActivity",
               base.isTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralModeEnum);
            //Submit SIM StudyPlan Activity
            new StudentPresentationPage().
                SubmitTrainingMaterialSIMStudyPlanActivity(activity.Name);
            Logger.LogMethodExit("ActivitySubmission",
                "SubmitTheTrainingMaterialStudyPlanActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Submit The StudyPlan Pretest Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode Enum.</param>
        [When(@"I submit the ""(.*)"" pretest activity of behavioral mode type ""(.*)""")]
        public void SubmitTheStudyPlanPretestActivity(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Submit The StudyPlan Pretest Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "SubmitTheStudyPlanPretestActivity",
               base.isTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralModeEnum);
            //Submit SIM StudyPlan Activity
            new StudentPresentationPage().
                SubmitSIMStudyPlanPreTestActivity(activity.Name);
            Logger.LogMethodExit("ActivitySubmission",
                "SubmitTheStudyPlanPretestActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the activity.
        /// </summary>
        /// <param name="activityType">This is the activity type.</param>
        [When(@"I submit the ""(.*)"" activity")]
        public void SubmitTheActivity(String activityType)
        {
            //Submit the Activity
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheActivity",
             base.isTakeScreenShotDuringEntryExit);
            //Created Class Object
            StudentPresentationPage studentpresentationpage =
                new StudentPresentationPage();
            //Attempt The Activity
            studentpresentationpage.AttemptTheBehavioralModeTypeActivity(activityType);
            //Finish and return to course selection
            studentpresentationpage.ClickOnFinishButtonInCourseMaterials();
            //Click On Feedback Icon
            studentpresentationpage.ClickOnFeedbackIcon();
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheActivity",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Status Of The Activity.
        /// </summary>
        /// <param name="activityStatus">This is Activity Status.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should see the ""(.*)"" status of the ""(.*)"" activity type")]
        public void VerifyStatusOfTheActivity(string activityStatus,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Verify Status Of The Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifyStatusOfTheActivity",
               base.isTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            // Assert Activity Submission
            Logger.LogAssertion("VerifyActivitySubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityStatus,
                    new StudentPresentationPage().
                    GetStatusOfSubmittedActivityInCourseMaterial(activity.Name)));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifyStatusOfTheActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open The Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I open the activity named as ""(.*)""")]
        public void OpenTheActivity(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Open The Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "OpenTheActivity",
               base.isTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Window And Frame
            new StudentPresentationPage().SelectWindowAndFrame();
            //Click The Activity In CourseMaterial
            new StudentPresentationPage().
                SelectActivityNameInCourseMaterialTab(activity.Name);
            Logger.LogMethodExit("ActivitySubmission",
                "OpenTheActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity Save For Later.
        /// </summary>
        /// <param name="activityType">This is Activity Type.</param>
        [When(@"I submit the activity ""(.*)"" save for later")]
        public void SubmitTheActivitySaveForLater(String activityType)
        {
            //Submit The Activity Save For Later.
            Logger.LogMethodEntry("ActivitySubmission",
                "SubmitTheActivitySaveForLater",
             base.isTakeScreenShotDuringEntryExit);
            //Created Class Object
            StudentPresentationPage studentpresentationpage =
                new StudentPresentationPage();
            //Select The Activity presentation window
            studentpresentationpage.ClickStartButtonOnPresentationWindow(
                activityType);
            //Click On Save For Later
            studentpresentationpage.ClickOnSaveForLater();
            Logger.LogMethodExit("ActivitySubmission",
                "SubmitTheActivitySaveForLater",
          base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify Feedback Option in Presentation Page
        /// </summary>
        /// <param name="feedBackOption">This is Feedback option</param>
        [Then(@"I should see the ""(.*)"" in the 'Test Presentation Page'")]
        public void VerifyFeedbackInPresentationPage(string feedBackOption)
        {
            //Verify Feedback Option In Presentation Page
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifyFeedbackInPresentationPage",
             base.isTakeScreenShotDuringEntryExit);
            //Created Class Object
            StudentPresentationPage studentpresentationpage = new StudentPresentationPage();
            Logger.LogAssertion("VerifyFeedbackInPresentationPage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(feedBackOption,
                    studentpresentationpage.getFeedBackText()));
            Logger.LogMethodExit("ActivitySubmission", "VerifyFeedbackInPresentationPage",
                base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Close the Test Presentation Page
        /// </summary>
        [When(@"I close the Test Presentation Page")]
        public void CloseTheTestPresentationPage()
        {
            //Close the Test Presentation Page
            Logger.LogMethodEntry("ActivitySubmission",
                "CloseTheTestPresentationPage",
             base.isTakeScreenShotDuringEntryExit);
            //Click On Return To Course
            new StudentPresentationPage().ClickOnReturnToCourseInMyitlab();
            // select close button on the Test window
            new InstructionsPage().ClickTestCloseButton();
            Logger.LogMethodExit("ActivitySubmission", "CloseTheTestPresentationPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Feedback Text In Student Presentation Page.
        /// </summary>
        /// <param name="feedbackOption">This is Feedback Option.</param>
        [Then(@"I should not see the ""(.*)"" in the 'Homework Presentation Page'")]
        public void VerifyFeedbackTextInStudentPresentationPage(string feedbackOption)
        {
            //Verify Feedback Text In Student Presentation Page
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifyFeedbackTextInStudentPresentationPage",
             base.isTakeScreenShotDuringEntryExit);
            //Assert to Verify Feedback Text In Student Presentation Page
            Logger.LogAssertion("VerifyFeedbackTextInPresentationPage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsFalse(
                    new StudentPresentationPage().IsFeedbackTextPresent(feedbackOption)));
            //Close the Presentation Window
            new ManageOrganisationToolBarPage().CloseWindow(ActivitySubmissionResource.
                ActivitySubmission_Resource_Homework_Window_Name);
            Logger.LogMethodExit("ActivitySubmission",
                "VerifyFeedbackTextInStudentPresentationPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Manual Gradable Activity.
        /// </summary>
        /// <param name="activityType">This is Activty type.</param>
        [When(@"I submit the manual gradable ""(.*)"" activity")]
        public void SubmitTheManualGradableActivity(String activityType)
        {
            //Submit The Manual Gradable Activity
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheManualGradableActivity",
             base.isTakeScreenShotDuringEntryExit);
            //Created Class Object
            StudentPresentationPage studentpresentationpage =
                new StudentPresentationPage();
            //Attempt The Activity         
            studentpresentationpage.AttemptTheGradableAsset(activityType);
            //Finish and return to course selection
            studentpresentationpage.ClickOnFinishButtonInCourseMaterials();
            //Click On Return To Course
            studentpresentationpage.ClickOnReturnToCourseInMyitlab();
            // select close button on the Test window
            new InstructionsPage().ClickTestCloseButton();
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheManualGradableActivity",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        [When(@"I open ""(.*)"" activity")]
        public void OpenActivity(string activityName)
        {
            //Select Activity                   
            new StudTodoDonePage().SelectActivityInAssignments(activityName);
        }

        /// <summary>
        /// Launch SIM5 Questions By Navigating.
        /// </summary>
        /// <param name="activityCount">This is Question Count.</param>
        /// <param name="activityName">This is Activity Name.</param>
        [When(@"I launch SIM5 ""(.*)"" questions in ""(.*)"" activity")]
        public void LaunchSIMQuestions(int questionCount, string activityName)
        {
            //Launch SIM5 Questions By Navigating        
            new StudTodoDonePage().LaunchSIM5QuestionsByNavigating(activityName, questionCount);
        }
        /// <summary>
        /// Activity should get successfully Launched In Browser Normal Mode
        /// </summary>
        [Then(@"I should see the activity successfully launched in browser normal mode")]
        public void ActivitySuccessfullyLaunchedInBrowserNormalMode()
        {
            Logger.LogMethodEntry("ActivitySubmission", "ActivitySuccessfullyLaunchedInBrowserNormalMode",
                base.isTakeScreenShotDuringEntryExit);
            //Verify that control switches from SIM5 activity launch popup to the 'Course Materials' page
            new StudentPresentationPage().verifyWindowSwitching();

            Logger.LogMethodEntry("ActivitySubmission", "ActivitySuccessfullyLaunchedInBrowserNormalMode",
                base.isTakeScreenShotDuringEntryExit);
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
