using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Integration.MGM.Tests.CommonIntegrationAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MGM.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Create SkillStudyPlan actions.
    /// </summary>
    [Binding]
    public class CreateActivity : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CreateActivity));

        /// <summary>
        /// Click on Add Content Button Options.
        /// </summary>
        /// <param name="optionName">Option name.</param>
        [When(@"I click on the ""(.*)"" link")]
        public void ClickOnTheLink(String optionName)
        {
            //Create Skill Study Plan
            Logger.LogMethodEntry("CreateActivity", "ClickOnTheLink",
                base.isTakeScreenShotDuringEntryExit);
            //Click on Add Content Button Options
            new ContentLibraryUXPage().ClickOnAddContentOption(optionName);
            Logger.LogMethodExit("CreateActivity", "ClickOnTheLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Skill Study Plan.
        /// </summary>
        [When(@"I create SkillStudyPlan")]
        public void CreateSkillStudyPlanActivity()
        {
            //Create Skill Study Plan
            Logger.LogMethodEntry("CreateActivity", "CreateSkillStudyPlanActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Creating Object for Page Class
            DRTDefaultUXPage drtDefaultUXPage = new DRTDefaultUXPage();
            //Creating Skill Study Plan
            drtDefaultUXPage.AddPreTestToSkillStudyPlan();
            //create PreTest
            drtDefaultUXPage.CreatePreTest();
            //Save the Study Plan
            drtDefaultUXPage.ClickOnSaveCloseButtonOfSkillStudyPlan();
            Logger.LogMethodExit("CreateActivity", "CreateSkillStudyPlanActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects the Activity in Content Library Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity by Type Enum.</param>
        [When(@"I select the ""(.*)"" activity")]
        public void SelectTheActivity(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Selects the Activity in Content Library Frame
            Logger.LogMethodEntry("CreateActivity", "SelectTheActivity",
                base.isTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Gets the Activity name from Memory
            Activity activity = Activity.Get(CommonStepsResource.
                CommonSteps_DigitalPath_Activity_Test_UC1);
            //Select Window and Frame
            contentLibraryUXPage.SelectLeftFrameInContentWindow();
            //Selects the Activity
            contentLibraryUXPage.SelectActivity(activity.Name);
            Logger.LogMethodExit("CreateActivity", "SelectTheActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on Add Button.
        /// </summary>
        [When(@"I Click on Add button")]
        public void ClickOnTheAddButton()
        {
            //Clicks on the Add Button
            Logger.LogMethodEntry("CreateActivity", "ClickOnTheAddButton",
                base.isTakeScreenShotDuringEntryExit);
            //Click on the Add Button
            new CourseContentUXPage().ClickOnAddButton();
            Logger.LogMethodExit("CreateActivity", "ClickOnTheAddButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on the Add Button.
        /// </summary>
        [When(@"I Click on the Add button")]
        public void ClickOnAddButton()
        {
            //Clicks on the Add Button
            Logger.LogMethodEntry("CreateActivity", "ClickOnAddButton",
                base.isTakeScreenShotDuringEntryExit);
            //Click on the Add Button
            new ContentLibraryUXPage().ClickOnActivityAddButton();
            Logger.LogMethodExit("CreateActivity", "ClickOnAddButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Asserts the Activity Name in My Course Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is the Activity by Type Enum.</param>
        [Then(@"I should see ""(.*)"" activity in the MyCourse Frame")]
        public void DisplayOfActivityInMyCourseFrame(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify the Activity Name added to the My Course Frame
            Logger.LogMethodEntry("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
            Activity activity = null;
            switch (activityTypeEnum)
            {
                case Activity.ActivityTypeEnum.Test:
                    //Gets the Activity name from Memory
                    activity = Activity.Get(CommonStepsResource.
                        CommonSteps_DigitalPath_Activity_Test_UC1);
                    break;
                case Activity.ActivityTypeEnum.SkillStudyPlan:
                    //Gets the Activity name from Memory
                    activity = Activity.Get(CommonStepsResource.
                        CommonSteps_DigitalPath_Activity_SkillStudyPlan_UC1);
                    break;
            }
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyAssignedActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetTheActivityName(activity.Name)));
            Logger.LogMethodExit("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Customize Single Content.
        /// </summary>
        [When(@"I customize single content")]
        public void CustomizeSingleContent()
        {
            //Customize Single Content
            Logger.LogMethodEntry("CreateActivity", "CustomizeSingleContent",
                base.isTakeScreenShotDuringEntryExit);
            //Customize Single Content
            new MathXLAssessmentPage().CustomizeTheSingleContent();
            Logger.LogMethodExit("CreateActivity", "CustomizeSingleContent",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Searched Activity Name.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type enum.</param>
        [When(@"I search the content of type ""(.*)"" in MyCourse Frame")]
        public void SearchTheContentinMyCourseFrame(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Get the Searched Activity Name
            Logger.LogMethodEntry("CreateActivity", "SearchTheContentinMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Gets the Activity name from Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Get the Searched Activity Name
            new CourseContentUXPage().GetTheActivityName(activity.Name);
            Logger.LogMethodExit("CreateActivity", "SearchTheContentinMyCourseFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Customize the Content.
        /// </summary>       
        [When(@"I customize the content 'SkillStudyPlan'")]
        public void CustomizeTheContent()
        {
            //Customize the Content
            Logger.LogMethodEntry("CreateActivity", "CustomizeTheContent",
                base.isTakeScreenShotDuringEntryExit);
            //Customize the Content
            new DRTDefaultUXPage().CustomizeTheContent();
            Logger.LogMethodExit("CreateActivity", "CustomizeTheContent",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Copy State for Contents in MyCourse Frame.
        /// </summary>
        [When(@"I verify the copy state for contents in MyCourse Frame")]
        public void VerifyTheCopyStateForContentsInMyCourseFrame()
        {
            //Verify the Copy State for Contents in MyCourse Frame
            Logger.LogMethodEntry("CreateActivity", "CustomizeTheContent",
                  base.isTakeScreenShotDuringEntryExit);
            //Verify the Copy State for Contents in MyCourse Frame
            new CourseContentUXPage().VerifyCopyStateforContentsinMycourseFrame();
            Logger.LogMethodExit("CreateActivity", "CustomizeTheContent",
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
