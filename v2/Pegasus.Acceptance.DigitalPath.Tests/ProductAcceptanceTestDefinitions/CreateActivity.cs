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
    /// This class handles Create SkillStudyPlan actions
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
            //Select Window
            drtDefaultUXPage.SelectCreateSkillStudyplanWindow();
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
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Window and Frame
            contentLibraryUXPage.SelectLeftFrameInContentWindow();
            //Selects the Activity
            contentLibraryUXPage.SelectActivity(activity.Name);
            Logger.LogMethodExit("CreateActivity", "SelectTheActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Activity In Course Content.
        /// </summary>
        /// <param name="activity">This is Activity Name.</param>
        [When(@"I select the ""(.*)"" activity in Course Content")]
        public void VerifyTheActivityInCourseContent(string activity)
        {
            //Verify The Activity In Course Content
            Logger.LogMethodEntry("CreateActivity", "VerifyTheActivityInCourseContent",
                base.isTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Select Window and Frame
            contentLibraryUXPage.SelectLeftFrameInContentWindow();
            //Selects the Activity
            contentLibraryUXPage.SelectActivity(activity);
            Logger.LogMethodExit("CreateActivity", "VerifyTheActivityInCourseContent",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on the Add Button.
        /// </summary>
        [When(@"I Click on the Add button")]
        public void ClickOnTheAddButton()
        {
            //Clicks on the Add Button
            Logger.LogMethodEntry("CreateActivity", "ClickOnTheAddButton",
                base.isTakeScreenShotDuringEntryExit);
            //Click on the Add Button
            new ContentLibraryUXPage().ClickOnActivityAddButton();
            Logger.LogMethodExit("CreateActivity", "ClickOnTheAddButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Asserts the Activity Name in My Course Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is the Activity by Type Enum.</param>
        [Then(@"I should see ""(.*)"" activity in the MyCourse Frame")]
        public void DisplayOfActivityInMyCourseFrame(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify the Activity Name added to the My Course Frame
            Logger.LogMethodEntry("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Gets the Activity name from Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyAssignedActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetActivityName(activity.Name)));
            Logger.LogMethodExit("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Activity In The MyCourse.
        /// </summary>
        /// <param name="activity">This is Activity Name.</param>
        [Then(@"I should see ""(.*)"" activity in the MyCourse")]
        public void VerifyTheActivityInTheMyCourse(string activity)
        {
            //Verify The Activity In The MyCourse
            Logger.LogMethodEntry("CreateActivity",
                "VerifyTheActivityInTheMyCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyAssignedActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity,
                    new CourseContentUXPage().GetActivityName(activity)));
            Logger.LogMethodExit("CreateActivity",
                "VerifyTheActivityInTheMyCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Course Materials Option.
        /// </summary>        
        [When(@"I click on the 'Add Course Materials' option")]
        public void ClickOnAddCourseMaterialsLink()
        {
            //Click On Add Course Materials Option
            Logger.LogMethodEntry("CreateActivity",
                "ClickOnAddCourseMaterialsLink",
                base.isTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Select Window and Frame
            contentLibraryUXPage.SelectLeftFrameInContentWindow();
            //Click On Add Course Materials Option
            contentLibraryUXPage.ClickOnAddCourseMaterialsLink();
            Logger.LogMethodExit("CreateActivity",
                "ClickOnAddCourseMaterialsLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity Type.
        /// </summary>
        /// <param name="activityType">This is Activity Type.</param>
        [When(@"I click on the ""(.*)"" activity type")]
        public void ClickOnTheActivityType(String activityType)
        {
            //Click On Activity Type
            Logger.LogMethodEntry("CreateActivity", "ClickOnTheActivityType",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Activity Type
            new ContentLibraryUXPage().ClickOnActivityType(activityType);
            Logger.LogMethodExit("CreateActivity", "ClickOnTheActivityType",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Activity of Behavioral Mode.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>        
        [When(@"I create ""(.*)"" type activity of behavioral mode 'BasicRandom'")]
        public void CreateTheActivityOfBehavioralModeType(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create Activity
            Logger.LogMethodEntry("CreateActivity", "CreateTheActivityOfBehavioralModeType",
               base.isTakeScreenShotDuringEntryExit);
            //Create Object for RandomTopicList Page
            RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
            AddAssessmentPage addAssessmentPage = new AddAssessmentPage();
            //Enter Activity Details and Click on Add Question Link
            addAssessmentPage.EnterActivityDetailsandClickonAddQuestion(activityTypeEnum);
            //Select Create New Question Option
            randomTopicListPage.SelectTheCreateNewQuestionForAssetCreation
            (CreateActivityResource.
            CreateActivity_CreateNewQuestion_Xpath_Locator);
            //Select Question Type
            new SelectQuestionTypePage().ClickTheQuestionType();
            //Create True/False Question
            new TrueFalsePage().CreateTrueFalseQuestion();
            //Enter the message
            addAssessmentPage.EnterTheMessageForActivity();
            Logger.LogMethodExit("CreateActivity", "CreateTheActivityOfBehavioralModeType",
                base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Associate The Activity From Content Library To MyCourse.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I associate the ""(.*)"" activity Content Library to MyCourse frame")]
        public void AssociateTheActivityFromContentLibraryToMyCourse(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Associate The Activity From Content Library To MyCourse
            Logger.LogMethodEntry("CreateActivity", 
                "AssociateTheActivityFromContentLibraryToMyCourse",
                isTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Window and Frame
            contentLibraryUXPage.SelectLeftFrameInContentWindow();
            // Select the activity
            contentLibraryUXPage.SelectActivity(activity.Name);
            // Click on Activity Add Button
            contentLibraryUXPage.ClickOnActivityAddButton();
            Logger.LogMethodExit("CreateActivity", 
                "AssociateTheActivityFromContentLibraryToMyCourse",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Instructor Gradable Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        [When(@"I create ""(.*)"" activity of behavioral mode type using Essay question")]
        public void CreateGradableActivityWithEssayQuestion(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create Instructor Gradable Activity
            Logger.LogMethodEntry("CreateActivity",
                "CreateGradableActivityWithEssayQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Declaration of object
            AddAssessmentPage addAssessmentPage = new AddAssessmentPage();
            //Enter Activity Details and Click on Add Question Link
            addAssessmentPage.EnterActivityDetailsandClickonAddQuestion(activityTypeEnum);
            //Create Gradable Activity Using Essay Question
            addAssessmentPage.CreateGradableActivityUsingEssayQuestion(activityTypeEnum);
            Logger.LogMethodExit("CreateActivity",
                "CreateGradableActivityWithEssayQuestion",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Study Plan.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I create the ""(.*)"" asset")]
        public void CreateStudyplan(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create Study Plan
            Logger.LogMethodEntry("ActivitySubmission", "CreateStudyplan",
              base.isTakeScreenShotDuringEntryExit);
            //Create Study Plan.
            new DRTDefaultUXPage().CreateStudyPlan(activityTypeEnum);
            Logger.LogMethodExit("ActivitySubmission", "CreateStudyplan",
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
