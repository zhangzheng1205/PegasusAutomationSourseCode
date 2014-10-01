using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class Handles launch activity page actions
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
        /// Open SIM Study Plan As Student.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity by Type Enum.</param>
        [When(@"I open the ""(.*)"" Activity")]
        public void OpenTheSimStudyPlan(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Open The Activity As Student
            Logger.LogMethodEntry("LaunchActivity", "OpenTheSimStudyPlan",
                base.IsTakeScreenShotDuringEntryExit);
            //Launch The Activity
            new CoursePreviewMainUXPage().OpenActivity(activityTypeEnum);
            Logger.LogMethodExit("LaunchActivity", "OpenTheSimStudyPlan",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Start Pre test button of SIM Study Plan by SMS Student
        /// </summary>
        [When(@"I click on Start Pre test button of SIM Study Plan by SMS Student")]
        public void LaunchPreTestOfSimStudyPlanBySmsStudent()
        {
            //Logger Enrty
            Logger.LogMethodEntry("LaunchActivity",
                "LaunchPreTestOfSimStudyPlanBySmsStudent",
                base.IsTakeScreenShotDuringEntryExit);
            //Launch SIM Study Plan Pre Test
            new SIMStudyPlanStudentUXPage().LaunchSIMStudyPlanPreTestByStudent();
            //Logger Exit
            Logger.LogMethodExit("LaunchActivity",
                "LaunchPreTestOfSimStudyPlanBySmsStudent",
                base.IsTakeScreenShotDuringEntryExit);
            
        }

        /// <summary>
        /// Submit the SIM Study plan pre test. 
        /// </summary>
        /// <param name="activityTyepEnum">This activity type enum.</param>
        [When(@"I Submit the SIM Study Plan ""(.*)""")]
        public void SubmitTheSimStudyPlanPreTest(Activity.ActivityTypeEnum activityTyepEnum)
        {
            //Logger Enrty
            Logger.LogMethodEntry("LaunchActivity",
                "SubmitTheSimStudyPlanPreTest",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Activity name from memeory
            Activity activity= Activity.Get(activityTyepEnum);
            //Launch SIM Study Plan Pre Test
            new StudentPresentationPage().SubmitSIMStudyPlanPreTestActivityByStudent(activity.Name);
            //Logger Exit
            Logger.LogMethodExit("LaunchActivity",
                "SubmitTheSimStudyPlanPreTest",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Option Of Activity
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option</param>
        /// <param name="activityTypeEnum">This is activity type enum</param>
        [When(@"I select cmenu option ""(.*)"" of activity ""(.*)""")]
        public void SelectCmenuOptionOfActivity(string cmenuOption, 
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select Cmenu Option Of Activity
            Logger.LogMethodEntry("LaunchActivity","SelectCmenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Activity Name from Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Activity Cmenu Option
            new CoursePreviewMainUXPage().SelectActivityCmenuOption((CoursePreviewMainUXPage.ActivityCmenuEnum)
                Enum.Parse(typeof(CoursePreviewMainUXPage.ActivityCmenuEnum), cmenuOption), activity.Name);
            Logger.LogMethodExit("LaunchActivity","SelectCmenuOptionOfActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Asset Information In Frame
        /// </summary>
        /// <param name="activityTypeEnum">This is activity Type Enum</param>
        [Then(@"I should see the ""(.*)"" in Information frame")]
        public void VerifyAssetInInformationFrame(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Asset Information In Frame
            Logger.LogMethodEntry("LaunchActivity", "VerifyAssetInInformationFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Activity Name From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Verify Question Status
            Logger.LogAssertion("VerifyAssetName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name, new AssetInformationPage().GetActivityName()));
            Logger.LogMethodExit("LaunchActivity", "VerifyAssetInInformationFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit SIM5 Excel type activity.
        /// <param name="activityName">This of the activity name.</param>
        /// </summary>
        [When(@"I should answer activity ""(.*)"" correctly and click on Submit button")]
        public void SubmitSim5ExcelTypeActivity(String activityName)
        {
            //Submit SIM5 Excel type activity
            Logger.LogMethodEntry("LaunchActivity", "SubmitSim5ExcelTypeActivity",
                base.IsTakeScreenShotDuringEntryExit);
            new SIM5FramePage().SubmitSim5ExcelActivityExcelChapter1SkillBasedTraining(activityName);
            Logger.LogMethodExit("LaunchActivity", "SubmitSim5ExcelTypeActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Submit button in SIM5
        /// presentation page after answering a question incorrectly.
        /// </summary>
        /// <param name="activityMode">This is activity mode name.</param>
        /// <param name="activityName">This of the activity name.</param>
        /// <param name="applicationType">This is activity type name.</param>
        [When(@"I click on submit button answering incorrectly of ""(.*)"" type ""(.*)"" mode activity ""(.*)""")]
        public void ClickonSubmitButtonAfterAnsweringIncorrectly(string applicationType,
            string activityMode, string activityName)
        {
            //Submit SIM5 Excel type activity
            Logger.LogMethodEntry("LaunchActivity", "ClickonSubmitButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on submit button
            new StudentPresentationPage().SubmitSIMActivityWithoutAnswering
                (applicationType, activityMode, activityName);
            Logger.LogMethodExit("LaunchActivity", "ClickonSubmitButton",
               base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
