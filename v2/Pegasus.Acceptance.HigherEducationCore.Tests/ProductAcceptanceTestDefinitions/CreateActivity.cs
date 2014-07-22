using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles Create Activity Actions.
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
        /// Click On Add Course Materials Option.
        /// </summary>        
        [When(@"I click on the 'Add Course Materials' option")]
        public void ClickOnAddCourseMaterialsLink()
        {
            //Click On Add Course Materials Option
            Logger.LogMethodEntry("CreateActivity",
                "ClickOnAddCourseMaterialsLink",
                base.isTakeScreenShotDuringEntryExit);
            //Declaration of object
            ContentLibraryUXPage contentLibrary = new ContentLibraryUXPage();
            //Select Window
            contentLibrary.SelectTheWindowName(CreateActivityResource.
                CreateActivity_CourseMaterials_Window_Title);
            //Select the frame
            contentLibrary.SelectAndSwitchtoFrame(CreateActivityResource.
                CreateActivity_CourseMaterials_Leftframe_Id_Locator);
            //Click On Add Course Materials Option
            contentLibrary.ClickOnAddCourseMaterialsLink();
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
        /// Create Activity.
        /// </summary>
        /// <param name="activityTypeEnum">
        /// This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">
        /// This is Behavioral Mode Enum.</param>
        [When(@"I create ""(.*)"" activity of behavioral mode ""(.*)"" type")]
        public void CreateActivities(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create Activity
            Logger.LogMethodEntry("CreateActivity", "CreateActivities",
                base.isTakeScreenShotDuringEntryExit);
            //Create Activity
            new AddAssessmentPage().CreateActivity(activityTypeEnum,
                behavioralModeEnum);
            Logger.LogMethodExit("CreateActivity", "CreateActivities",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Skill Study Plan Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="userTypeEnum">This is User Type by Enum.</param>
        [When(@"I create ""(.*)"" activity in ""(.*)""")]
        public void CreateSkillStudyPlanActivity(
             Activity.ActivityTypeEnum activityTypeEnum,
             User.UserTypeEnum userTypeEnum)
        {
            //Create Skill Study Plan Activity
            Logger.LogMethodEntry("CreateActivity", "CreateSkillStudyPlanActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Creating Object for Page Class
            DRTDefaultUXPage drtDefaultUXPage = new DRTDefaultUXPage();
            RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
            //Creating Skill Study Plan
            drtDefaultUXPage.CreateSkillStudyPlan(activityTypeEnum);
            //Click The Create PreTest link
            drtDefaultUXPage.ClickTheCreatePreTestLink();
            //Create PreTest Activity
            new AddAssessmentPage().CreatePreTestActivity();
            //Select Add Questions
            randomTopicListPage.SelectAddQuestionsLink();
            //Select Questions From SkillFrame
            new SkillStandardAlignedAssetsUXPage().SelectQuestionsFromSkillFrame();
            //Click On Save And Return Button()
            randomTopicListPage.ClickOnSaveAndReturnButton();         
            //Create PostTest Activity
            drtDefaultUXPage.CreatePostTestActivity();        
            Logger.LogMethodExit("CreateActivity", "CreateSkillStudyPlanActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Activity In Content Library Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is the Activity Type Enum.</param>
        [Then(@"I should see ""(.*)"" activity in the Content Library Frame")]
        public void DisplayOfActivityInContentLibraryFrame(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Display Of Activity In Content Library Frame
            Logger.LogMethodEntry("CreateActivity",
                "DisplayOfActivityInContentLibraryFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyActivityName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new ContentLibraryUXPage().
                    GetActivityNameInContentLibrary(activity.Name)));
            Logger.LogMethodExit("CreateActivity",
                "DisplayOfActivityInContentLibraryFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Function describles the action of clicking cmenu option for an activity.
        /// </summary>
        /// <param name="cmenuOptionName">This is the cmenu option name.</param>
        /// <param name="userTypeEnum">This is User type</param>
        [When(@"I click on ""(.*)"" cmenu option of activity in ""(.*)""")]
        public void ClickOnCmenuOptionOfActivity(String cmenuOptionName,
            User.UserTypeEnum userTypeEnum)
        {
            //Verify the click of Cmenu options in Content library frame for an activity
            Logger.LogMethodEntry("CreateActivity",
                "ClickOnCmenuOptionOfActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Perform Mouse Over Mouse Over Activity action
            new CourseContentUXPage().
                PerformMouseOverOnCMenuOptionOfActivity(
                cmenuOptionName, userTypeEnum);
            Logger.LogMethodExit("CreateActivity",
                "ClickOnCmenuOptionOfActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Preview The Pretest by WS teacher.
        /// </summary>
        [When(@"I preview the PreTest of the Skill Study Plan")]
        public void PreviewSkillStudyPlanPreTestByTeacher()
        {
            // Preview the Pretest As WS teacher
            Logger.LogMethodEntry("CreateActivity",
                "PreviewSkillStudyPlanPreTestByTeacher",
                base.isTakeScreenShotDuringEntryExit);
            //Launch The Pretest
            new DRTPreviewUXPage().PreviewPreTestInStudyPlan();
            Logger.LogMethodExit("CreateActivity",
                "PreviewSkillStudyPlanPreTestByTeacher",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Behavioral Mode Activity In Content Library Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavoirlaModeTypeEnum">This is Behavioral Mode Type Enum.</param>
        [Then(@"I should see ""(.*)"" activity of behaviorla mode ""(.*)"" in the Content Library Frame")]
        public void DisplayOfBehavioralModeActivityInTheContentLibraryFrame(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavoirlaModeTypeEnum)
        {
            //Display Of Behavioral Mode Activity In Content Library Frame
            Logger.LogMethodEntry("CreateActivity",
                "DisplayOfBehavioralModeActivityInTheContentLibraryFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum, behavoirlaModeTypeEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new ContentLibraryUXPage().GetActivityNameInContentLibrary(activity.Name)));
            Logger.LogMethodExit("CreateActivity",
                "DisplayOfBehavioralModeActivityInTheContentLibraryFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Gradable Asset.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type</param>
        [When(@"I create gradable asset of type ""(.*)""")]
        public void CreateGradableAssetOfBehavioralModeType
            (Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create Gradable Asset.
            Logger.LogMethodEntry("CreateActivity",
                "CreateGradableAssetOfBehavioralModeType",
                base.isTakeScreenShotDuringEntryExit);
            //Create Object for RandomTopicList Page
            RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
            //Enter Activity Details and Click on Add Question Link
            new AddAssessmentPage().EnterActivityDetailsandClickonAddQuestion(activityTypeEnum);
            //Select Create New Question Option
            randomTopicListPage.SelectCreateNewQuestionOption();
            //Select Question Type
            new SelectQuestionTypePage().ClickTheQuestionType();  
            //Create True/False Question
            new TrueFalsePage().CreateTrueFalseQuestion();
            //Click on Save and Return
            randomTopicListPage.ClickOnSaveAndReturnButton();
            Logger.LogMethodExit("CreateActivity",
               "CreateGradableAssetOfBehavioralModeType",
               base.isTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Create The NonGradable Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I create the nonGgadable ""(.*)"" activity")]
        public void CreateTheNonGradableActivity(
                         Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create The NonGradable Activity
            Logger.LogMethodEntry("CreateActivity",
                  "ClickOnAddCourseMaterialsLink",
                        base.isTakeScreenShotDuringEntryExit);
            //Create Link Asset
            new AddUrlPage().CreateLinkAsset(activityTypeEnum);
            Logger.LogMethodExit("CreateActivity",
                "ClickOnAddCourseMaterialsLink",
                      base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Create New Test under Manage Your Tests Frame.
        /// </summary>
        /// <param name="linkName">This is name of Link.</param>
        /// <param name="questionTypeEnum">This is question type enum.</param>
        [When(@"I click on the ""(.*)"" link in Manage Your Tests and created Test using ""(.*)"" question")]
        public void CreateMyTestActivityUsingQuestion
            (String linkName, Question.QuestionTypeEnum questionTypeEnum)
        {
            Logger.LogMethodEntry("CreateActivity", "CreateMyTestActivityUsingQuestion",
                 base.isTakeScreenShotDuringEntryExit);
            //Create New Test
            new MyTestGridUXPage().ClickOnLinkToSelect();
            //Created Page Class Object
            PaperTestUXPage paperTestUXPage = new PaperTestUXPage();
            //Select Create Question
            paperTestUXPage.SelectCreateQuestion(questionTypeEnum);
            //Create MyTest True and False Question
            new TrueFalsePage().CreateMyTestQuestion();
            //Save The MyTest Activity
            paperTestUXPage.SaveTheMyTestActivity();
            Logger.LogMethodExit("CreateActivity", "CreateMyTestActivityUsingQuestion",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Asserts the Activity Name in My Course Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is the Activity by Type Enum.</param>
        [Then(@"I should see ""(.*)"" activity of behavioral mode ""(.*)"" in MyCourse Frame")]
        public void DisplayOfActivityInMyCourseFrame(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum activityBehavioralModesEnum)
        {
            //Verify the Activity Name added to the My Course Frame
            Logger.LogMethodEntry("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Gets the Activity from Memory
            Activity activity = Activity.Get(activityTypeEnum, activityBehavioralModesEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyDisplayOfActivityInMyCourseFrame", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetActivityName(activity.Name)));
            Logger.LogMethodExit("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Activity Cmenu Option In MyCourse Frame.
        /// </summary>
        [When(@"I click the activity ShowHide cmenu option in MyCourse Frame")]
        public void ClickTheActivityCmenuOptionInMyCourseFrame()
        {
            //Click The Activity Cmenu Option In MyCourse Frame
            Logger.LogMethodEntry("CreateActivity",
                "ClickTheActivityCmenuOptionInMyCourseFrame",
               base.isTakeScreenShotDuringEntryExit);
            // Click On The Activity Cmenu In MyCourse Frame
            new CourseContentUXPage().ClickTheActivityShowHideCmenuInMyCourseFrame();
            Logger.LogMethodExit("CreateActivity",
                "ClickTheActivityCmenuOptionInMyCourseFrame",
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
            //Select Window
            contentLibraryUXPage.SelectTheWindowName(GradeBookResource.
                GradeBook_Coursematerials_Window_Title);
            //Select the frame
            contentLibraryUXPage.SelectAndSwitchtoFrame(GradeBookResource.
                GradeBook_Coursematerials_LeftFrame_Id_Locator);
            // Select the activity
            contentLibraryUXPage.SelectActivity(activity.Name);
            // Click on Activity Add Button
            contentLibraryUXPage.ClickOnActivityAddButton();
            Logger.LogMethodExit("CreateActivity", 
                "AssociateTheActivityFromContentLibraryToMyCourse",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create The NonGradable Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is the Activity by Type.</param>
        [When(@"I create the ""(.*)"" activity in Content Library")]
        public void CreateTheNonGradableActivityInContentLibrary(
                         Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create The NonGradable Activity
            Logger.LogMethodEntry("CreateActivity",
                  "CreateTheNonGradableActivityInContentLibrary",
                        base.isTakeScreenShotDuringEntryExit);
            //Create The NonGradable Activity.
            new ContentLibraryUXPage().
                CreateNonGradableActivityInContentlibrary(activityTypeEnum);
            Logger.LogMethodExit("CreateActivity",
                "CreateTheNonGradableActivityInContentLibrary",
                      base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Create The Audio Page Asset.
        /// </summary>
        /// <param name="pageAssetTypeEnum">This is Page Asset Type Enum.</param>
        [When(@"I create the Audio ""(.*)"" AssetType in Content Library")]
        public void CreateAudioPageAssetTypeInContentLibrary(
                       Activity.ActivityTypeEnum pageAssetTypeEnum)
        {
            //Create The Audio Page Asset
            Logger.LogMethodEntry("CreateActivity",
                "CreateAudioPageAssetTypeInContentLibrary",
                      base.isTakeScreenShotDuringEntryExit);
            //Create The Audio Page Asset
            new PegasusHTMLUXPage().
                RecordAudioFromPageAssetType(pageAssetTypeEnum);
            Logger.LogMethodExit("CreateActivity",
                "CreateAudioPageAssetTypeInContentLibrary",
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
