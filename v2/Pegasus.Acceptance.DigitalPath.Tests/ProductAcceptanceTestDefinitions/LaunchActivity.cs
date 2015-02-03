#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Launch Activity actions.
    /// </summary>
    [Binding]
    public class LaunchActivity : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(LaunchActivity));
        
        /// <summary>
        /// Function describles the action of clicking cmenu option for an activity.
        /// </summary>
        /// <param name="cmenuOptionName">This is the cmenu option name.</param>
        /// <param name="userTypeEnum">This is User type</param>
        [When(@"I click on ""(.*)"" cmenu option of activity in ""(.*)""")]
        public void ClickOnCmenuOptionOfActivity(
            String cmenuOptionName, User.UserTypeEnum userTypeEnum)
        {
            //Verify the click of Cmenu options in my course frame for an activity
            Logger.LogMethodEntry("LaunchActivity", "ClickOnCmenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Launch activity action
            new CourseContentUXPage().PerformMouseOverOnCMenuOptionOfActivity(cmenuOptionName,userTypeEnum);
            Logger.LogMethodExit("LaunchActivity", "ClickOnCmenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the presentation window launch.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type enum.</param>
        [Then(@"I should see the SSP Pretest successfully launch by ""(.*)""")]
        public void LaunchTheSkillStudyPlanPreTestActivity(
            User.UserTypeEnum userTypeEnum)
        {
            // Open The Activity 
            Logger.LogMethodEntry("LaunchActivity", "LaunchTheSkillStudyPlanPreTestActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert for Launch of PreTest Presentation window
            Logger.LogAssertion("VerifyPrsentationLaunch", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new PlayerTestPage().IsSkillStudyPlanPreTestPreviewLaunched()));
            // Switch to different roles as per the activity presentation behaviour
            switch (userTypeEnum)
            {
                // Close Activity by Ws Teacher
                case User.UserTypeEnum.WsTeacher:
                    new DRTPreviewUXPage().ClickOnCancelButton();
                    break;
                // Close Activity by Ws Student
                case User.UserTypeEnum.WsStudent:
                    new DRTPreviewUXPage().ClickOnReturnToCourseButton();
                    break;
            }
            Logger.LogMethodExit("LaunchActivity", "LaunchTheSkillStudyPlanPreTestActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Lauch The Activity.
        /// </summary>
        [Then(@"I should see the Test activity successfully launched")]
        public void LaunchTheTestActivity()
        {
            // Open The Activity 
            Logger.LogMethodEntry("LaunchActivity", "LaunchTheTestActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert for Launch of Presentation window
            Logger.LogAssertion("VerifyPrsentationLaunch", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new PlayerTestPage().IsMgmTestActivityLauched()));
            Logger.LogMethodExit("LaunchActivity", "LaunchTheTestActivity",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Open The Activity As Student.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity by Type</param>
        [When(@"I open the ""(.*)"" Activity")]
        public void OpenTheActivity(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Open The Activity As Student
            Logger.LogMethodEntry("LaunchActivity", "OpenTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Launch The Activity
            new CoursePreviewMainUXPage().OpenActivity(activityTypeEnum);
            Logger.LogMethodExit("LaunchActivity", "OpenTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch The Pretest.
        /// </summary>
        [When(@"I launch the Pretest")]
        public void LaunchPretest()
        {
            // Open The Pretest As Student
            Logger.LogMethodEntry("LaunchActivity", "LaunchPretest",
                base.IsTakeScreenShotDuringEntryExit);
            //Launch The Pretest
            new CoursePreviewMainUXPage().LaunchPretest();
            Logger.LogMethodExit("LaunchActivity", "LaunchPretest",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Preview The Pretest by WS teacher.
        /// </summary>
        [When(@"I preview the PreTest of the Skill Study Plan")]
        public void PreviewSkillStudyPlanPreTestByTeacher()
        {
            // Preview the Pretest As WS teacher
            Logger.LogMethodEntry("LaunchActivity", "PreviewSkillStudyPlanPreTestByTeacher",
                base.IsTakeScreenShotDuringEntryExit);
            //Launch The Pretest
            new DRTPreviewUXPage().PreviewPreTestInStudyPlan();
            Logger.LogMethodExit("LaunchActivity", "PreviewSkillStudyPlanPreTestByTeacher",
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
        /// Deinitialize Pegasus test after the execution of Scenario.
        /// </summary>
       [AfterScenario]
        public static void TearDownBrowser()
        {
            
        }

        /// <summary>
        /// Start New WebDriver Instance Before Scenario
        /// </summary>
        [BeforeScenario]
        public static void StartIeWebDriver()
        {
            
        }


    }
}
