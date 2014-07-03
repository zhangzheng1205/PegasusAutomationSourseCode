using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MGM.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class has functionality to submit the activity in course space.
    /// </summary>
    [Binding]
    public class ActivitySubmission : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ActivitySubmission));

        /// <summary>
        /// Open the activity in view all content tab.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity tye enum.</param>
        [When(@"I open the activity named as ""(.*)""")]
        public void OpenTheActivity(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Open the Activity in Different Tab's
            Logger.LogMethodEntry("ActivitySubmission", "OpenTheActivity",
              base.isTakeScreenShotDuringEntryExit);
            //Get The activity from In- Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Content Window
            new CoursePreviewMainUXPage().SelectContentWindow();
            //Click To Open Activity
            new CoursePreviewMainUXPage().
                ClickActivityInViewAllContentTab(activity.Name);
            Logger.LogMethodEntry("ActivitySubmission", "OpenTheActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the activity after launching it.
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
            studentpresentationpage.AttemptTheActivityInDigitalPath(activityType);
            //Finish and return to course selection
            studentpresentationpage.FinishAndReturnToCourse();
            // select close button on the Test window
            new InstructionsPage().ClickTestCloseButton();
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheActivity",
          base.isTakeScreenShotDuringEntryExit);
        }      

        /// <summary>
        /// Start pre test from study plan window.
        /// </summary>
        [When(@"I start the Pre-Test")]
        public void StartPreTest()
        {
            //Start pre test
            Logger.LogMethodEntry("ActivitySubmission", "StartPreTest",
              base.isTakeScreenShotDuringEntryExit);
            // Click on begin button
            new DRTDefaultUXPage().ClickBeginButton();
            // Click continue button on activity alert pop up
            new ShowMessagePage().ClickContinueInActivityAlert();
            Logger.LogMethodExit("ActivitySubmission", "StartPreTest",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click return to course button on study plan window.
        /// </summary>
        [When(@"I click return to course button")]
        public void ClickReturnToCourseButton()
        {
            //Select return to course button to go back to Content page
            Logger.LogMethodEntry("ActivitySubmission", "ClickReturnToCourseButton",
              base.isTakeScreenShotDuringEntryExit);
            // Click on return to course button
            new DRTDefaultUXPage().ClickReturnToCourseButton();
            Logger.LogMethodExit("ActivitySubmission", "ClickReturnToCourseButton",
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

