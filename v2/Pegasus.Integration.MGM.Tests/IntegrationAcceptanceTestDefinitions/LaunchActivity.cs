using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MGM.Tests.
    IntegrationAcceptanceTestDefinitions
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
        /// <param name="userTypeEnum">This is User type enum.</param>
        [When(@"I click on ""(.*)"" cmenu option of activity in ""(.*)""")]
        public void ClickOnCmenuOptionOfActivity(
            String cmenuOptionName, User.UserTypeEnum userTypeEnum)
        {
            //Verify the click of Cmenu options in my course frame for an activity
            Logger.LogMethodEntry("LaunchActivity", "ClickOnCmenuOptionOfActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Launch activity action
            new CourseContentUXPage().PerformMouseOverOnCMenuOptionOfActivity(
                cmenuOptionName, userTypeEnum);
            Logger.LogMethodExit("LaunchActivity", "ClickOnCmenuOptionOfActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the presentation window launch.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type Enum.</param>
        [Then(@"I should see the SSP Pretest successfully launch by ""(.*)""")]
        public void LaunchTheSkillStudyPlanPreTestActivity(
            User.UserTypeEnum userTypeEnum)
        {
            // Open The Activity 
            Logger.LogMethodEntry("LaunchActivity", "LaunchTheSkillStudyPlanPreTestActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Assert for Launch of PreTest Presentation window
            Logger.LogAssertion("VerifyPrsentationLaunch", ScenarioContext.
                Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new PlayerTestPage().
                    IsSkillStudyPlanPreTestPreviewLaunched()));
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Lauch The Activity.
        /// </summary>
        [Then(@"I should see the Test activity successfully launched")]
        public void LaunchTheTestActivity()
        {
            // Open The Activity 
            Logger.LogMethodEntry("LaunchActivity", "LaunchTheTestActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Assert for Launch of Presentation window
            Logger.LogAssertion("VerifyPrsentationLaunch", ScenarioContext.
                Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new PlayerTestPage().IsMGMTestActivityLauched()));
            Logger.LogMethodExit("LaunchActivity", "LaunchTheTestActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch The MGM Test activity by Student.
        /// </summary>
        [Then(@"I should see the Test activity successfully launched by Student")]
        public void LaunchMGMTestActivityByStudent()
        {
            // Open The Activity 
            Logger.LogMethodEntry("LaunchActivity", "LaunchMGMTestActivityByStudent",
                base.isTakeScreenShotDuringEntryExit);
            //Assert for Launch of Presentation window
            Logger.LogAssertion("VerifyPrsentationLaunch",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new PlayerTestPage().
                    IsMGMTestActivityLauchedByStudent()));
            Logger.LogMethodExit("LaunchActivity", "LaunchMGMTestActivityByStudent",
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
