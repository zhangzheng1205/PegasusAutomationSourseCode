using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Integration.Hed.MLP.Tests.IntegrationAcceptanceTestDefinitions;

namespace Pegasus.Integration.MLP.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles the activity submission related actions.
    /// </summary>
    [Binding]
    public class ActivitySubmission : PegasusBaseTestFixture
    {

        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
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
            Logger.LogAssertion("VerifyGradesAreShownForGrading",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(submittedGradeValue,
                    Convert.ToDecimal(ActivitySubmissionResource.
                    ActivitySubmision_SubmittedActivity_GradeValue)));
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
            //Submit the Activity
            new StudentPresentationPage().SubmitTheActivityHED();
            Logger.LogMethodExit("ActivitySubmission",
                "SubmitTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
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
            //Assert the Activity Status
            Logger.LogAssertion("VerifyStatusOfActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityStatus, new CoursePreviewMainUXPage().
                    GetStatusOfActivity(ActivitySubmissionResource.
                    ActivitySubmision_ManuallyGradable_Activity_Name)));
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
