#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// 
    /// </summary>
    [Binding]
    public class EditActivity : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(EditActivity));

        /// <summary>
        /// Edit Badged Activity 
        /// </summary>
        /// <param name="activityBehavioralModesEnum">This is Activity Behavioral Mode.</param>
        [When(@"I edit the ""(.*)"" Badged activity")]
        public void EditBagedActivity(
            Activity.ActivityBehavioralModesEnum
            activityBehavioralModesEnum)
        {
            // Edit Badged Activity 
            Logger.LogMethodEntry("EditActivity", "EditBagedActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Get Activity Name
            String getBadgedActivityName = string.Empty;
            switch (activityBehavioralModesEnum)
            {
                case Activity.ActivityBehavioralModesEnum.BasicRandom:
                    //Basic random Activity type.
                    getBadgedActivityName = EditActivityResource.
                        EditActivity_BasicRandomBaged_ActivtyName;
                    break;
                case Activity.ActivityBehavioralModesEnum.Assignment:
                    //Assigment Activity type.
                    getBadgedActivityName = EditActivityResource.
                        EditActivity_AssignmentBaged_ActivtyName;
                    break;
                case Activity.ActivityBehavioralModesEnum.DocBased:
                    //Doc Based Activity type.
                    getBadgedActivityName = EditActivityResource.
                        EditActivity_DocBasedBaged_ActivtyName;
                    break;
                case Activity.ActivityBehavioralModesEnum.SkillBased:
                    //Skill Based Activity type.
                    getBadgedActivityName = EditActivityResource.
                        EditActivity_SkillBasedBaged_ActivtyName;
                    break;
                case Activity.ActivityBehavioralModesEnum.Adaptive:
                    //Adaptive Activity type.
                    getBadgedActivityName = EditActivityResource.
                        EditActivity_AdaptiveBaged_ActivtyName;
                    break;
            }
            //Edit Activity
            EditTheActivity(getBadgedActivityName);
            Logger.LogMethodExit("EditActivity", "EditBagedActivity",
                base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Edit Pre test in Badged Study plan. 
        /// </summary>
        /// <param name="activityBehavioralModesEnum">This is Activity Behavioral Mode.</param>
        [When(@"I edit Badged SIM study plan \[Pretest<Training] having ""(.*)"" activity as pre test")]
        public void EditPreTestBadgedStudyPlan(
            Activity.ActivityBehavioralModesEnum
            activityBehavioralModesEnum)
        {
            // Edit Pre test in Badged Study plan
            Logger.LogMethodEntry("EditActivity", "EditBadgedStudyPlan",
               base.isTakeScreenShotDuringEntryExit);
            String badgedStudyPlan = string.Empty;
            switch (activityBehavioralModesEnum)
            {
                case Activity.ActivityBehavioralModesEnum.DocBased:
                    //Doc Based Study Plan.
                    badgedStudyPlan = EditActivityResource.
                        EditActivity_DocBased_Pre_Test_BadgedStudyPlanName;
                    break;
                case Activity.ActivityBehavioralModesEnum.SkillBased:
                    //Skill Based Study Plan.
                    badgedStudyPlan = EditActivityResource.
                        EditActivity_SkillBased_Pre_Test_BadgedStudyPlanName;
                    break;
            }
            EditTheActivity(badgedStudyPlan);
            Logger.LogMethodExit("EditActivity", "EditBadgedStudyPlan",
                base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Edit Post test in Badged Study plan. 
        /// </summary>
        /// <param name="activityBehavioralModesEnum">This is Activity Behavioral Mode.</param>
        [When(@"I edit Badged SIM study plan \[Pretest<Training<Posttest] having ""(.*)"" activity as Post test")]
        public void EditPostTestBadgedStudyPlan(
            Activity.ActivityBehavioralModesEnum
            activityBehavioralModesEnum)
        {
            // Edit Post test in Badged Study plan
            Logger.LogMethodEntry("EditActivity", "EditPostTestBadgedStudyPlan",
               base.isTakeScreenShotDuringEntryExit);
            String badgedStudyPlan = string.Empty;
            switch (activityBehavioralModesEnum)
            {
                case Activity.ActivityBehavioralModesEnum.DocBased:
                    //Doc Based Study Plan.
                    badgedStudyPlan = EditActivityResource.
                        EditActivity_DocBased_Post_Test_BadgedStudyPlanName;
                    break;
                case Activity.ActivityBehavioralModesEnum.SkillBased:
                    //Skill Based Study Plan.
                    badgedStudyPlan = EditActivityResource.
                        EditActivity_SkillBased_Post_Test_BadgedStudyPlanName;
                    break;
            }
            EditTheActivity(badgedStudyPlan);
            Logger.LogMethodExit("EditActivity", "EditPostTestBadgedStudyPlan",
                base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Edit Post test in Badged Study plan having Training mode 
        /// </summary>
        /// <param name="activityBehavioralModesEnum">This is Activity Behavioral Mode.</param>
        [When(@"I edit Badged SIM study plan \[Training<Posttest] having ""(.*)"" activity as Post test")]
        public void EditTrainingPostTestBadgedStudyPlan(
            Activity.ActivityBehavioralModesEnum
            activityBehavioralModesEnum)
        {
            // Edit Post test in Badged Study plan having Training mode  
            Logger.LogMethodEntry("EditActivity", "EditTrainingPostTestBadgedStudyPlan",
               base.isTakeScreenShotDuringEntryExit);
            String badgedStudyPlan = string.Empty;
            switch (activityBehavioralModesEnum)
            {
                case Activity.ActivityBehavioralModesEnum.DocBased:
                    //Doc Based Study Plan.
                    badgedStudyPlan = EditActivityResource.
                        EditActivity_DocBased_Training_Post_Test_BadgedStudyPlanName;
                    break;
                case Activity.ActivityBehavioralModesEnum.SkillBased:
                    //Skill Based Study Plan.
                    badgedStudyPlan = EditActivityResource.
                     EditActivity_SkillBased_Training_Post_Test_BadgedStudyPlanName;
                    break;
            }
            EditTheActivity(badgedStudyPlan);
            Logger.LogMethodExit("EditActivity",
                "EditTrainingPostTestBadgedStudyPlan",
                base.isTakeScreenShotDuringEntryExit);
        }

        ///  <summary>
        ///  Edit Actvity . 
        ///  </summary>
        /// <param name="activtyName">This is a actvity name.</param>
        private void EditTheActivity(string activtyName)
        {

            Logger.LogMethodEntry("EditActivity", "EditTheActivity",
                base.isTakeScreenShotDuringEntryExit);
            // Edit Activity 
            new TeachingPlanUXPage().ClickOnActivity(activtyName);
            Logger.LogMethodExit("EditActivity", "EditTheActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit pre test or post test in Study plan . 
        /// </summary>
        ///  <param name="testType">Test type</param>
        [When(@"I edit the ""(.*)""")]
        public void EditSimStudyPlan(string testType)
        {

            Logger.LogMethodEntry("EditActivity", "EditPreTest",
                base.isTakeScreenShotDuringEntryExit);
            // Edit pre test or post test in Study plan
            new SIMStudyPlanDefaultUXPage().EditSimStudyPlan(testType);
            Logger.LogMethodExit("EditActivity", "EditPreTest",
                base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Validate Visibilty Questions Tab for Badged Activity  
        /// </summary>
        /// <param name="activityBehavioralModesEnum">This is Activity Behavioral Mode.</param>
        [Then(@"I should see the Questions tab should be suppressed for ""(.*)"" Badged activity")]
        public void ValidateVisibiltyQuestionsTab(
            Activity.ActivityBehavioralModesEnum
            activityBehavioralModesEnum)
        {
            // Validate Visibilty Questions Tab for Badged Activity 
            Logger.LogMethodEntry("EditActivity", "ValidateVisibiltyQuestionsTab",
                base.isTakeScreenShotDuringEntryExit);
            bool isQuestionTabsDisplayed = false;
            switch (activityBehavioralModesEnum)
            {
                case Activity.ActivityBehavioralModesEnum.BasicRandom:
                    //Basic random Activity type.
                    isQuestionTabsDisplayed = new RandomAssessmentPage().
                        isQuestionsTabVisible();
                    break;
                case Activity.ActivityBehavioralModesEnum.Assignment:
                    //Assigment Activity type.
                    isQuestionTabsDisplayed = new AssignmentPage().
                        isQuestionsTabVisibile();
                    break;
                case Activity.ActivityBehavioralModesEnum.DocBased:
                    //Doc Based Activity type.
                    isQuestionTabsDisplayed = new DocBasedAssessmentPage().
                        isQuestionsTabVisibe();
                    break;
                case Activity.ActivityBehavioralModesEnum.SkillBased:
                    //Skill Based Activity type.
                    isQuestionTabsDisplayed = new SkillBasedAssessmentPage().
                        isQuestionsTabVisibile();
                    break;
                case Activity.ActivityBehavioralModesEnum.Adaptive:
                    //Adaptive Activity type.
                    isQuestionTabsDisplayed = new AdaptiveAssessmentPage().
                        isQuestionsTabVisible();
                    break;
            }
            //Verify the Questions Tab
            Logger.LogAssertion("VerifyQuestionsTabVisibilty",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsFalse(isQuestionTabsDisplayed));

            Logger.LogMethodExit("EditActivity", "ValidateVisibiltyQuestionsTab",
                base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Validate Visibilty Questions Tab for Sim Study Plan  
        /// </summary>
        ///<param name="testType">This is Test type in Sim Study plan .</param>
        /// <param name="activityBehavioralModesEnum">This is Activity Behavioral Mode.</param>
        [Then(@"I should see the Questions tab should be suppressed for ""(.*)"" having ""(.*)"" Activity")]
        public void ValidateVisibiltyQuestionsTabSimStudyPlan(string testType,
            Activity.ActivityBehavioralModesEnum activityBehavioralModesEnum)
        {
            // Validate Visibilty Questions Tab for Badged Sim Study Plan 
            Logger.LogMethodEntry("EditActivity", "ValidateVisibiltyQuestionsTabSimStudyPlan",
                base.isTakeScreenShotDuringEntryExit);
            bool isQuestionTabsDisplayed = false;
            switch (activityBehavioralModesEnum)
            {
                case Activity.ActivityBehavioralModesEnum.DocBased:
                    //Doc Based Activity type.
                    isQuestionTabsDisplayed = new DocBasedAssessmentPage().
                        isQuestionsTabVisibleInSimStudyPlan(testType);
                    break;
                case Activity.ActivityBehavioralModesEnum.SkillBased:
                    //Skill Based Activity type.
                    isQuestionTabsDisplayed = new SkillBasedAssessmentPage().
                        isQuestionsTabVisibileInSimStudyPlan(testType);
                    break;

            }
            //Verify the Questions Tab
            Logger.LogAssertion("VerifyQuestionsTabVisibiltyInSimStudyPlan",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsFalse(isQuestionTabsDisplayed));

            Logger.LogMethodExit("EditActivity", "ValidateVisibiltyQuestionsTabSimStudyPlan",
                base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Click on tab of Edit SIM Study Plan page.
        /// </summary>
        /// <param name="tabName">This is name of tab.</param>
        [When(@"I Click on ""(.*)"" Tab of Edit SIM PreTest")]
        public void ClickOnTabOfEditSIMPreTest(string tabName)
        {
            //Logger Entry
            Logger.LogMethodEntry("EditActivity", "ClickOnTabOfEditSIMPreTest",
                    base.isTakeScreenShotDuringEntryExit);
            //Click on tab of Edit SIM Study Plan 
            new SkillBasedAssessmentPage().
                ClickOnTabOfEditSIMStudyPlanPreTest(tabName);
            //Logger Exit
            Logger.LogMethodExit("EditActivity", "ClickOnTabOfEditSIMPreTest",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the Set time Interval time for SIM Study Plan Pre Test.
        /// </summary>
        /// <param name="timeInMinute">This is time in minute.</param>
        [When(@"I enter ""(.*)"" minute in Set time limit for activity preference")]
        public void EnterTimeInSetTimeLimitForActivityPreference(int timeInMinute)
        { 
            //Logger Entry
            Logger.LogMethodEntry("EditActivity", 
                "EnterTimeInSetTimeLimitForActivityPreference",
                    base.isTakeScreenShotDuringEntryExit);
            //Instance of SkillBasedAssessmentPage
            SkillBasedAssessmentPage SkillBasedAssessmentPageObject=
                new SkillBasedAssessmentPage();
            //Enter Time in Mitute textbox of Set Time Limit for activity preference
            SkillBasedAssessmentPageObject.EnterTimeInActivityPreference(timeInMinute);
            //Click on save and return button of activity
            SkillBasedAssessmentPageObject.ClickOnSaveAndReturnOfSIMStudyPlanPreTest();
            //Logger Exit
            Logger.LogMethodExit("EditActivity", 
                "EnterTimeInSetTimeLimitForActivityPreference",
                    base.isTakeScreenShotDuringEntryExit);
        }

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
