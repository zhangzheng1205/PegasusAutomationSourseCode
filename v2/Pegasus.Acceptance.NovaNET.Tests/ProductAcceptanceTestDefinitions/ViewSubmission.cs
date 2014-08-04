using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.NovaNET.Tests.Definitions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class is responsible to create activity, submit activity
    /// and verify the grades for activity actions.
    /// </summary>
    [Binding]
    public class ViewSubmission : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(ViewSubmission));

        /// <summary>
        /// Lanch the Activity in the tabs.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity Type Enum. </param>
        /// <param name="tabName">This is Tab name. </param>
        [When(@"I open the activity named as ""(.*)"" in ""(.*)"" tab")]
        public void OpenTheActivityInTab(Activity.ActivityTypeEnum activityTypeEnum,
            String tabName)
        {
            //Open the Activity in Different Tab's
            Logger.LogMethodEntry("ViewSubmission", "OpenTheActivityInTab",
              base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Click To Open Activity
            new CoursePreviewMainUXPage().OpenActivityInTab(activity.Name,
                 (CoursePreviewMainUXPage.OpenActivityTab)Enum.Parse
                 (typeof(CoursePreviewMainUXPage.OpenActivityTab), tabName));
            Logger.LogMethodEntry("ViewSubmission", "OpenTheActivityInTab",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display of Grade for Submitted Activity.
        /// </summary>
        /// <param name="activityScore">This is Activity Score.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
       [Then(@"I should see the grade ""(.*)"" of the submitted activity named as ""(.*)""")]
        public void DisplayTheGradeUnderGradeColumnOfTheSubmittedActivity
            (string activityScore, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Display of Grade for Submitted Activity
            Logger.LogMethodEntry("ViewSubmission", 
                "DisplayOfGradeUnderGradeColumnforSubmittedActivity",
              base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            GBStudentUXPage gbStudentUXpage = new GBStudentUXPage();
            //Select Window
            gbStudentUXpage.SelectGradebookWindow();
            //Assert we have correct message displayed
            Logger.LogAssertion("VerifySbmittedActivityScore",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityScore,
                    gbStudentUXpage.GetActivityScoreInGradebook(activity.Name)));
            Logger.LogMethodEntry("ViewSubmission", 
                "DisplayOfGradeUnderGradeColumnforSubmittedActivity",
           base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Lauch The Activity.
        /// </summary>
        [Then(@"I should see the activity launched successfully")]
        public void ActivityLaunchedSuccessfully()
        {
            //Display of Grade for Submitted Activity
            Logger.LogMethodEntry("ViewSubmission", "ActivityLaunchedSuccessfully",
              base.IsTakeScreenShotDuringEntryExit);
            //Created Page Class Object
            InstructorPresentationPage instructorPresentationPage =
                new InstructorPresentationPage();
            //Assert Activity Launched Successfully
            Logger.LogAssertion("VerifyActivityLaunchedSuccessfully",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(instructorPresentationPage.IsPostTestActivityLaunched()));
            //Close Activity Presentaion Window
            instructorPresentationPage.CloseActivityPresentationWindow();
            Logger.LogMethodEntry("ViewSubmission", "ActivityLaunchedSuccessfully",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the Activity Launched Successfully
        /// </summary>       
        [Then(@"I should see the activity launched successfully in 'ViewAllContent' tab")]
        public void SubmitActivityLaunchedSuccessfully()
        {
            //Submit the Activity Launched Successfully
            Logger.LogMethodEntry("ViewSubmission", "SubmitActivityLaunchedSuccessfully",
             base.IsTakeScreenShotDuringEntryExit);
            //Created Page Class Object
            InstructorPresentationPage instructorPresentationPage =
                new InstructorPresentationPage();
            //Assert Activity Launched Successfully
            Logger.LogAssertion("VerifyActivityLaunchedSuccessfully",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(instructorPresentationPage.IsPostTestActivityLaunchedInContentPage()));    
            Logger.LogMethodEntry("ViewSubmission", "SubmitActivityLaunchedSuccessfully",
         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the Activity.
        /// </summary>
        [When(@"I submit the activity")]
        public void SubmitTheActivity()
        {
            //Submit the Activity
            Logger.LogMethodEntry("ViewSubmission", "SubmitTheActivity",
             base.IsTakeScreenShotDuringEntryExit);
            //Created Class Object
            StudentPresentationPage studentpresentationpage =
                new StudentPresentationPage();
            //Select the window
            studentpresentationpage.SelectWebActivityWindow("Test");
            studentpresentationpage.AttemptTheActivityInStudentSide();            
            Logger.LogMethodEntry("ViewSubmission", "SubmitTheActivity",
          base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Status Of Assets In View All Content.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type enum.</param>
        /// <param name="activityStatus">This is Activity status.</param>
        [Then(@"I should see the status of ""(.*)"" assets as ""(.*)""")]
        public void StatusOfAssetsInViewAllContent(
            Activity.ActivityTypeEnum activityTypeEnum, String activityStatus)
        {
            //Status Of Assets In View All Content
            Logger.LogMethodEntry("ActivityStatus",
                "StatusOfAssetsInViewAllContent", base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert the Activity Status
            Logger.LogAssertion("VerifyStatusOfActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityStatus, new CoursePreviewMainUXPage().
                    GetStatusOfActivityInViewAllContentTab(activity.Name)));
            Logger.LogMethodExit("ActivityStatus",
                "StatusOfAssetsInViewAllContent", base.IsTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Initialize Pegasus test before test execution starts
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
