using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
using TechTalk.SpecFlow;
using Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation.AutoGrader;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
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
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ActivitySubmission));
        /// <summary>
        /// AssetId
        /// </summary>
        private string _assetId = string.Empty;
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
        public void OpenTheActivity(string activityName)
        {
            // Open The Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "OpenTheActivity",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Window And Frame
            new StudentPresentationPage().SelectWindowAndFrame();
            //Click The Activity In CourseMaterial
            new StudentPresentationPage().
                SelectActivityNameInCourseMaterialTab(activityName);
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

        /// <summary>
        /// Open the activity
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <param name="studentName">This is User type enum</param>
        [When(@"I launch the ""(.*)"" activity in content by ""(.*)""")]
        public void OpenTheActivityToLaunch(string activityName,
            User.UserTypeEnum studentName)
        {
            // Open The Activity
            Logger.LogMethodEntry("ActivitySubmission",
            "OpenTheActivityToLaunch",
            base.IsTakeScreenShotDuringEntryExit);
            StudentPresentationPage studentPresentationPage =
                new StudentPresentationPage();
            //Select Window And Frame
            studentPresentationPage.SelectWindowAndFrame();
            //wait for frame to load
            studentPresentationPage.WaitForActivitytoLoad(activityName);
            studentPresentationPage.SelectSimActivityStudentWindowName(studentName, activityName);
            Logger.LogMethodExit("ActivitySubmission", "OpenTheActivityToLaunch", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open the Pre-Test activity
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <param name="studentName">This is User type enum</param>
        [When(@"I launch the ""(.*)"" activity in content by ""(.*)"" for Pre-test")]
        public void LaunchTheActivityForPreTest(string activityName,
            User.UserTypeEnum studentName)
        {
            // Open The Activity
            Logger.LogMethodEntry("ActivitySubmission",
            "OpenTheActivityToLaunch",
            base.IsTakeScreenShotDuringEntryExit);
            StudentPresentationPage studentPresentationPage =
                new StudentPresentationPage();
            //Select Window And Frame
            studentPresentationPage.SelectWindowAndFrame();
            //wait for frame to load
            studentPresentationPage.WaitForActivitytoLoad(activityName);
            studentPresentationPage.SelectStartTraining();
            studentPresentationPage.SelectSimActivityStudentWindowName(studentName, ActivitySubmissionResource.ActivitySubmission_Resource_ExcelPreTest_Window_Name);
            Logger.LogMethodExit("ActivitySubmission", "OpenTheActivityToLaunch",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open The Activity To Launch Based On Scnerio.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <param name="studentName">This is User type enum</param>
        /// <param name="scenerioName">This is scenerio name.</param>
        [When(@"I launch the ""(.*)"" activity by ""(.*)"" with ""(.*)""")]
        public void OpenTheActivityToLaunchBasedOnScnerio(string activityName,
            User.UserTypeEnum studentName, string scenerioName)
        {
            //Open The Activity To Launch Based On Scnerio
            Logger.LogMethodEntry("ActivitySubmission",
            "OpenTheActivityToLaunchBasedOnScnerio",
            base.IsTakeScreenShotDuringEntryExit);
            StudentPresentationPage studentPresentationPage =
                new StudentPresentationPage();
            //Select Window And Frame
            studentPresentationPage.SelectWindowAndFrame();
            //wait for frame to load
            studentPresentationPage.WaitForActivitytoLoad(activityName);
            //Select the window
            studentPresentationPage.SelectSimActivityStudentWindowName(studentName, 
                activityName,scenerioName);
            Logger.LogMethodExit("ActivitySubmission", 
                "OpenTheActivityToLaunchBasedOnScnerio",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the pass due message
        /// </summary>
        /// /// <param>This is expected pass due message.</param>
        [Then(@"I should see the message ""(.*)"" in activity presentation page")]
        public void VerifyMessageInActivityPresentationPage(string expectedPastDueActivityMessage)
        {
            
            Logger.LogMethodEntry("ActivitySubmission",
            "VerifyMessageInActivityPresentationPage",
            base.IsTakeScreenShotDuringEntryExit);
            //Verify PastDue Message
            Logger.LogAssertion("VerifyActivitySubmission", ScenarioContext.
            Current.ScenarioInfo.Title,
            () => Assert.AreEqual(expectedPastDueActivityMessage,
            new StudentPresentationPage().
            GetActivityPastDueStatusMessage().Trim()));

            Logger.LogMethodExit("ActivitySubmission",
            "VerifyMessageInActivityPresentationPage",
            base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Submit the pass due message
        /// </summary>      
        /// <param>This is expected pass due message.</param>
        [When(@"I submit the past due ""(.*)"" activity")]
        public void WhenISubmitThePastDueActivity(string activityType)
        {
            //Submit the Activity
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheActivity",
             base.IsTakeScreenShotDuringEntryExit);           
                new StudentPresentationPage().SubmitPastDueActivity();                       
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheActivity",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Return to parent window
        /// </summary>   
        [Then(@"I should return to parent window")]
        public void ReturnToParentWindow()
        {
            Logger.LogMethodEntry("ActivitySubmission", "ReturnToParentWindow",
            base.IsTakeScreenShotDuringEntryExit);  
            //Return to parent window
            new StudentPresentationPage().ReturnToParentWindow();
            Logger.LogMethodEntry("ActivitySubmission", "ReturnToParentWindow",
           base.IsTakeScreenShotDuringEntryExit);

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

            this._assetId = new StudentPresentationPage().GetAssetIdFromUrl();
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
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), activity.Name, activityTypeEnum, _assetId);
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
            GBInstructorUXPage.AssetCmenuOptionEnum), cmenuOption), activityName, activityTypeEnum, _assetId);

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

        /// <summary>
        /// Click Download button to launch download file popup 
        /// in Test Presentation pop up
        /// </summary>
        [When(@"I click on Download Files button on Test Presentation pop up")]
        public void ClickTheDownloadFilesButton()
        {
            //Click on Download button.
            Logger.LogMethodEntry("ActivitySubmission", "ClickTheDownloadFilesButton",
                base.IsTakeScreenShotDuringEntryExit);
            PresentationPage presentationPage = new PresentationPage();
            presentationPage.ClickDownloadFilesButton();
            Logger.LogMethodExit("ActivitySubmission", "ClickTheDownloadFilesButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of Test Presentation PopUp With Buttons in it.
        /// </summary>
        /// <param name="popUp">PopUp Name</param>
        /// <param name="firstButton">Download Files button</param>
        /// <param name="secondButton">Upload Completed File</param>
        [Then(@"I should see a ""(.*)"" pop up displayed with ""(.*)"" button and ""(.*)"" button")]
        public void VerifyDisplayOfTestPresentationPopUpWithButtons(string popUp,
            string firstButton,
            string secondButton)
        {
            Logger.LogMethodEntry("ActivitySubmission",
                "VerifyDisplayOfTestPresentationPopUpWithButtons",
                base.IsTakeScreenShotDuringEntryExit);
            // Create an object of PresentationPage class
            PresentationPage presentationPage = new PresentationPage();
            // Assertion of Download Files button
            Assert.AreEqual(firstButton,
                            presentationPage.GetDownloadFilesButtonText());
            // Assertion of Upload Completed File
            Assert.AreEqual(secondButton,
                presentationPage.GetUploadCompletedFileButtonText());
            Logger.LogMethodExit("ContentLibrary",
               "VerifyAssetCopiedPosition",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on download file icon in Downloads Starting file popup
        /// </summary>
        /// <param name="fileName">File name to be downloaded</param>
        [When(@"I click on download icon of ""(.*)""")]
        public void ClickOnDownloadIconOfFile(string fileName)
        {
            // Click on download file icon
            Logger.LogMethodEntry("ActivitySubmission",
                "ClickOnDownloadIconOfFile",
                base.IsTakeScreenShotDuringEntryExit);
            var downLoadStartingFilesPage =
                new DownLoadStartingFilesPage();
            downLoadStartingFilesPage.ClickDownloadIconOfTheFile(fileName);
            // Click on download file icon
            Logger.LogMethodExit("ActivitySubmission",
                "ClickOnDownloadIconOfFile", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Close and Return button in Download Starting File Page.
        /// </summary>
        [When(@"I click on Close and Return button")]
        public void ClickCloseAndReturnButton()
        {
            // Click Close and Return button
            Logger.LogMethodEntry("ActivitySubmission",
                "ClickCloseAndReturnButton",
           base.IsTakeScreenShotDuringEntryExit);
            new DownLoadStartingFilesPage().
                ClickOnCloseAndReturnButton();
            Logger.LogMethodExit("ActivitySubmission",
                "ClickCloseAndReturnButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Upload Completed File button on Test Presentation pop up.
        /// </summary>
        [When(@"I click on Upload Completed File button on Test Presentation pop up")]
        public void ClickTheUploadCompletedFileButtonButton()
        {
            //Click Upload Completed File.
            Logger.LogMethodEntry("ActivitySubmission",
                "ClickTheUploadCompletedFileButtonButton",
                base.IsTakeScreenShotDuringEntryExit);
            PresentationPage presentationPage = new
                PresentationPage();
            presentationPage.ClickUploadCompletedFileButton();
        }

        /// <summary>
        /// Upload the downloaded file
        /// </summary>
        /// <param name="uploadFileName">File name to upload</param>
        [When(@"I upload the downloaded file ""(.*)""")]
        public void UploadTheDownloadedFile(string uploadFileName)
        {
            // Upload document
            Logger.LogMethodEntry("ActivitySubmission",
                "UploadTheDownloadedFile",
                base.IsTakeScreenShotDuringEntryExit);
            new UploadCompletedFilesPage().UploadGraderItFile(uploadFileName);
            Logger.LogMethodExit("ActivitySubmission", "UploadTheDownloadedFile",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// To Validate the obtained message on the Presentation popup page.
        /// </summary>
        /// <param name="message">Message displayed in the popup.</param>
        /// <param name="pageName">Popup Name</param>
        [Then(@"I should see message ""(.*)"" on ""(.*)"" popup page")]
        public void ValidateMessageDisplayOnPopup(string message, string pageName)
        {
            Logger.LogMethodEntry("ActivitySubmission",
               "ValidateTheMessage",
               base.IsTakeScreenShotDuringEntryExit);
            //To Verify The Message In Copy as Section Popup
            Logger.LogAssertion("ToValidateTheMessage",
                            ScenarioContext.Current.ScenarioInfo.Title, ()
                           => Assert.IsTrue(new PresentationPage().
                           ValidateTheMessageOnPopupPage(message, pageName)));
            Logger.LogMethodExit("ActivitySubmission",
           "ValidateTheMessage",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity 
        /// </summary>
        /// <param name="p0">activityType</param>
        [When(@"I submit ""(.*)"" activity")]
        public void SubmitGraderITActivity(String activityType)
        {
            //Submit the Activity
            Logger.LogMethodEntry("ActivitySubmission", "SubmitGraderITActivity",
             base.IsTakeScreenShotDuringEntryExit);
            new PresentationPage().ClickSubmitButton();
            Logger.LogMethodEntry("ActivitySubmission", "SubmitGraderITActivity",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Return To Course button.
        /// </summary>
        [When(@"I click on Return To Course button")]
        public void ClickReturnToCourseButton()
        {
            Logger.LogMethodEntry("ActivitySubmission", "ClickReturnToCourseButton",
              base.IsTakeScreenShotDuringEntryExit);
            new GraderFeedbackPage().ClickReturnToCourseButton();
            Logger.LogMethodExit("ActivitySubmission", "ClickReturnToCourseButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Refresh the View All Course Materials frame to navigate to root folder
        /// </summary>
        [When(@"I refresh the View All Course Materials frame")]
        public void RefreshViewAllCourseMaterialsFrame()
        {
            // Refresh the View All Course Materials frame
            Logger.LogMethodEntry("ActivitySubmission", "RefreshViewAllCourseMaterialsFrame",
              base.IsTakeScreenShotDuringEntryExit);
            new GraderFeedbackPage().RefreshCoursePreviewIframe();
            Logger.LogMethodExit("ActivitySubmission", "RefreshViewAllCourseMaterialsFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Sim5 Power Point Questions Submission.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        [When(@"I attempt questions ""(.*)"" in ""(.*)""")]
        public void AttemptSim5PowerPointQuestions(string score, string activityName)
        {
            //Sim5 Power Point Questions Submission
            Logger.LogMethodEntry("ActivitySubmission", "AttemptSim5PowerPointQuestions",
            IsTakeScreenShotDuringEntryExit);
            //Attempt Sim5 Power Point Questions
            new StudentPresentationPage().AttemptSim5PowerPointQuestions(activityName, score);
            Logger.LogMethodExit("ActivitySubmission", "AttemptSim5PowerPointQuestions",
            IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Sim5 Word Questions Submission.
        /// </summary>
        /// <param name="attemptPercentage"></param>
        /// <param name="activityName"></param>
        [When(@"I attempt questions for ""(.*)"" in activity ""(.*)""")]
        public void AttemptQuestionsForWordActivity(string attemptPercentage, string activityName)
        {
            //Sim5 Power Point Questions Submission
            Logger.LogMethodEntry("ActivitySubmission", "AttemptSim5PowerPointQuestions",
            IsTakeScreenShotDuringEntryExit);
            //Attempt Sim5 Power Point Questions
            new StudentPresentationPage().AttemptSim5WordActivityQuestions(attemptPercentage, activityName);
            Logger.LogMethodExit("ActivitySubmission", "AttemptSim5PowerPointQuestions",
            IsTakeScreenShotDuringEntryExit);
        }
    }

}
