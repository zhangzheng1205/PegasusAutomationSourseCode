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
        /// AssetId
        /// </summary>
        private string AssetId = string.Empty;
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
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralModeEnum);
            // Assert Activity Submission
            Logger.LogAssertion("VerifyActivitySubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityStatus,
                    new StudentPresentationPage().
                    GetStatusOfSubmittedActivityInCourseMaterial(activity.Name)));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifySimActivitySubmissionInCourseMaterials",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralModeEnum);
            // Assert Activity Submission
            Logger.LogAssertion("VerifyActivitySubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityStatus,
                    new CourseCalendarPage().
                    GetStatusOfSubmittedActivityInCalendar(activity.Name)));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifySimActivitySubmissionInCalendar",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralModeEnum);
            //Submit SIM StudyPlan Activity
            new StudentPresentationPage().
                SubmitTrainingMaterialSIMStudyPlanActivity(activity.Name);
            Logger.LogMethodExit("ActivitySubmission",
                "SubmitTheTrainingMaterialStudyPlanActivity",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralModeEnum);
            //Submit SIM StudyPlan Activity
            new StudentPresentationPage().
                SubmitSIMStudyPlanPreTestActivity(activity.Name);
            Logger.LogMethodExit("ActivitySubmission",
                "SubmitTheStudyPlanPretestActivity",
               base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
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
          base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            // Assert Activity Submission
            Logger.LogAssertion("VerifyActivitySubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityStatus,
                    new StudentPresentationPage().
                    GetStatusOfSubmittedActivityInCourseMaterial(activity.Name)));
            Logger.LogMethodExit("ActivitySubmission",
                "VerifyStatusOfTheActivity",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Window And Frame
            new StudentPresentationPage().SelectWindowAndFrame();
            //Click The Activity In CourseMaterial
            new StudentPresentationPage().
                SelectActivityNameInCourseMaterialTab(activity.Name);
            Logger.LogMethodExit("ActivitySubmission",
                "OpenTheActivity",
               base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
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
          base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
            //Created Class Object
            StudentPresentationPage studentpresentationpage = new StudentPresentationPage();
            Logger.LogAssertion("VerifyFeedbackInPresentationPage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(feedBackOption,
                    studentpresentationpage.getFeedBackText()));
            Logger.LogMethodExit("ActivitySubmission", "VerifyFeedbackInPresentationPage",
                base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
            //Click On Return To Course
            new StudentPresentationPage().ClickOnReturnToCourseInMyitlab();
            // select close button on the Test window
            new InstructionsPage().ClickTestCloseButton();
            Logger.LogMethodExit("ActivitySubmission", "CloseTheTestPresentationPage",
                base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
            //Assert to Verify Feedback Text In Student Presentation Page
            Logger.LogAssertion("VerifyFeedbackTextInPresentationPage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsFalse(
                    new StudentPresentationPage().IsFeedbackTextPresent(feedbackOption)));
            //Close the Presentation Window
            new ManageOrganisationToolBarPage().CloseWindow(ActivitySubmissionResource.
                ActivitySubmission_Resource_Homework_Window_Name);
            Logger.LogMethodExit("ActivitySubmission",
                "VerifyFeedbackTextInStudentPresentationPage",
                base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
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
          base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Verify that control switches from SIM5 activity launch popup to the 'Course Materials' page
            new StudentPresentationPage().verifyWindowSwitching();

            Logger.LogMethodEntry("ActivitySubmission", "ActivitySuccessfullyLaunchedInBrowserNormalMode",
                base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I launch the activity named as ""(.*)"" in Course Materials")]
        public void OpenTheActivityToLaunch(string activityName)
        {
            // Open The Activity
            Logger.LogMethodEntry("ActivitySubmission",
            "OpenTheActivity",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Window And Frame
            new StudentPresentationPage().SelectWindowAndFrame();
            //wait for frame to load
            new StudentPresentationPage().WaitForActivitytoLoad(activityName);
            //Get asset id
            this.AssetId = new StudentPresentationPage().GetSIM5AssetIdFromUrl(activityName);
            //Click The Activity In CourseMaterial
            //new StudentPresentationPage().SelectActivityNameInCourseMaterialTab(activityName);
            Logger.LogMethodExit("ActivitySubmission", "OpenTheActivity", base.IsTakeScreenShotDuringEntryExit);
        }


        /// </summary>
        [Then(@"I should see the message ""(.*)"" in activity presentation page")]
        public void VerifyMessageInActivityPresentationPage(string expectedPastDueActivityMessage)
        {
            //Verify PastDue Message
            Logger.LogMethodEntry("ActivitySubmission",
            "VerifyMessageInActivityPresentationPage",
            base.IsTakeScreenShotDuringEntryExit);

            Logger.LogAssertion("VerifyActivitySubmission", ScenarioContext.
            Current.ScenarioInfo.Title,

            () => Assert.AreEqual(expectedPastDueActivityMessage,
            new StudentPresentationPage().
            GetActivityPastDueStatusMessage().Trim()));

            Logger.LogMethodExit("ActivitySubmission",
            "VerifyMessageInActivityPresentationPage",
            base.IsTakeScreenShotDuringEntryExit);
        }




        [When(@"I submit the past due ""(.*)"" activity")]
        public void WhenISubmitThePastDueActivity(string activityType)
        {
            //Submit the Activity
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheActivity",
             base.IsTakeScreenShotDuringEntryExit);
            //Created Class Object
            StudentPresentationPage studentpresentationpage =
                new StudentPresentationPage();

            //Attempt The Activity
            //studentpresentationpage.AttemptTheBehavioralModeTypeActivity(activityType);

            // studentpresentationpage.AttemptTheActivityInCourseMaterials(activityType);
            studentpresentationpage.SubmitPastDueActivity();

            //Finish and return to course selection
            //studentpresentationpage.ClickOnFinishButtonInCourseMaterials();
            //Click On Feedback Icon
            // studentpresentationpage.ClickOnFeedbackIcon();
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheActivity",
            base.IsTakeScreenShotDuringEntryExit);
        }


        [Then(@"I should return to parent window")]
        public void ThenIShouldReturnToParentWindow()
        {
            new StudentPresentationPage().ReturnToParentWindow();
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
        /// Attempt The Activity For Save for later.
        /// </summary>
        /// <param name="activityType"></param>
        [When(@"I submit the activity ""(.*)"" for save for later")]
        public void AttemptTheActivityForSaveforlater(string activityType)
        {
            //Launching of Activity Presentation Window
            Logger.LogMethodEntry("ActivitySubmission",
                "AttemptTheActivityForSaveforlater"
                , base.IsTakeScreenShotDuringEntryExit);
            //Select The Activity presentation window
            //new StudentPresentationPage().ClickStartButtonOnPresentationWindow(
            //    activityType);

            this.AssetId = new StudentPresentationPage().GetAssetIdFromUrl();
            // Attempt Activity 
            new StudentPresentationPage().AttemptActivityForSaveforlater();
            Logger.LogMethodExit("ActivitySubmission",
                "AttemptTheActivityForSaveforlater"
                , base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click On Submission List For Saveforlater.
        /// </summary>
        [When(@"I click on submission list for save for later")]
        public void ClickOnSubmissionListForSaveforlater()
        {
            //Selecting the submission list for displaying the message
            Logger.LogMethodEntry("ActivitySubmission",
                "ClickOnSubmissionListForSaveforlater"
                , base.IsTakeScreenShotDuringEntryExit);
            new ViewSubmissionPage().SelectTheSubmissionFrame();
            Logger.LogMethodExit("ActivitySubmission",
                "ClickOnSubmissionListForSaveforlater"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The SaveForLater Display Message.
        /// </summary>
        /// <param name="messageText">Display Message.</param>
        [Then(@"I should see the message ""(.*)"" for save for later")]
        public void VerifyTheSaveForLaterDisplayMessage(string messageText)
        {
            // Verify The SaveForLater Display Message
            Logger.LogMethodEntry("ActivitySubmission", "VerifyTheSaveForLaterDisplayMessage",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify the InProgress Status
            Logger.LogAssertion("VerifySendMessageButton",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(messageText.Trim(), new ViewSubmissionPage().
                    GetSaveForLaterDisplayMessage().Trim()));
            Logger.LogMethodExit("ActivitySubmission", "VerifyTheSaveForLaterDisplayMessage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Asset From StudentSide.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu type enum</param>
        /// <param name="assetName">This is Asset name</param>
        [When(@"I click on cmenu ""(.*)"" of asset ""(.*)"" for save for later")]
        public void ClickOnCmenuOfAssetFromStudentSide(string assetCmenu,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu Of Asset 
            Logger.LogMethodEntry("GradeBook", "ClickOnCmenuOfAssetInGradebook",
                  IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            ViewSubmissionPage objViewSubmissionPage = new ViewSubmissionPage();
            //Select The Cmenu Option Of Asset
            objViewSubmissionPage.SelectAssetCMenuOption(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), activity.Name, activityTypeEnum, AssetId);
            Logger.LogMethodExit("GradeBook", "ClickOnCmenuOfAssetInGradebook",
                 IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Cmenu Of Asset In Course Materials.
        /// </summary>
        /// <param name="cmenuOption">C-menu Option</param>
        /// <param name="activityName">Activity Name</param>
        /// <param name="activityTypeEnum">Activity Type enum</param>
        [When(@"I click on cmenu ""(.*)"" of asset ""(.*)"" with mode ""(.*)"" in Course Materials")]
        public void ClickOnCmenuOfAssetInCourseMaterials(string cmenuOption, string activityName, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu Of Asset
            Logger.LogMethodEntry("GradeBook", "SubmitTheSIM5Activity",
            IsTakeScreenShotDuringEntryExit);

            //Click On Cmenu Of Asset
            ViewSubmissionPage objViewSubmissionPage = new ViewSubmissionPage();

            //Select The Cmenu Option Of Asset
            objViewSubmissionPage.SelectAssetCMenuOption(
            (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
            GBInstructorUXPage.AssetCmenuOptionEnum), cmenuOption), activityName, activityTypeEnum, AssetId);

            Logger.LogMethodExit("GradeBook", "SubmitTheSIM5Activity",
            IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On The Last Submission from submission list in view submission window.
        /// </summary>
        [When(@"I click on the last submission")]
        public void ClickOnTheLastSubmission()
        {
            Logger.LogMethodEntry("GradeBook", "SubmitTheSIM5Activity",
            IsTakeScreenShotDuringEntryExit);
            //Click on last submission
            new ViewSubmissionPage().SelectLastSubmissionInViewSubmissionWindow();

            Logger.LogMethodExit("GradeBook", "SubmitTheSIM5Activity",
            IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify the Gradebook Grade value On View Submission Page.
        /// </summary>
        /// <param name="gradeValue">Gradebook Grade value in view submission page</param>
        [Then(@"I should see the grade is ""(.*)"" in View Submission page")]
        public void VerifyGradebookGradeOnViewSubmissionPage(string gradeValue)
        {
            Logger.LogMethodEntry("GradeBook", "VerifyGradebookGradeOnViewSubmissionPage",
            IsTakeScreenShotDuringEntryExit);

            Logger.LogAssertion("VerifyGradebookGradeOnViewSubmissionPage", ScenarioContext.
            Current.ScenarioInfo.Title, () => Assert.AreEqual(gradeValue,
            new ViewSubmissionPage().GetGradebookGradeOnViewSubmissionPage()));

            Logger.LogMethodExit("GradeBook", "VerifyGradebookGradeOnViewSubmissionPage",
            IsTakeScreenShotDuringEntryExit);
        }


    }
}
