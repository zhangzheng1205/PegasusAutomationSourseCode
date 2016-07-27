using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Acceptance.HigherEducation.WL.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Automation.DataTransferObjects;
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Activity Type
            new ContentLibraryUXPage().ClickOnActivityType(activityType);
            Logger.LogMethodExit("CreateActivity", "ClickOnTheActivityType",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Create Activity
            new AddAssessmentPage().CreateActivity(activityTypeEnum,
                behavioralModeEnum);
            Logger.LogMethodExit("CreateActivity", "CreateActivities",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Creating Object for Page Class
            DrtDefaultUxPage drtDefaultUXPage = new DrtDefaultUxPage();
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Perform Mouse Over Mouse Over Activity action
            new CourseContentUXPage().
                PerformMouseOverOnCMenuOptionOfActivity(
                cmenuOptionName, userTypeEnum);
            Logger.LogMethodExit("CreateActivity",
                "ClickOnCmenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Launch The Pretest
            new DRTPreviewUXPage().PreviewPreTestInStudyPlan();
            Logger.LogMethodExit("CreateActivity",
                "PreviewSkillStudyPlanPreTestByTeacher",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum, behavoirlaModeTypeEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new ContentLibraryUXPage().GetActivityNameInContentLibrary(activity.Name)));
            Logger.LogMethodExit("CreateActivity",
                "DisplayOfBehavioralModeActivityInTheContentLibraryFrame",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
            //Create Link Asset
            new AddUrlPage().CreateLinkAsset(activityTypeEnum);
            Logger.LogMethodExit("CreateActivity",
                "ClickOnAddCourseMaterialsLink",
                      base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
            //Create New Test
            new MyTestGridUxPage().ClickOnLinkToSelect();
            //Created Page Class Object
            PaperTestUxPage paperTestUXPage = new PaperTestUxPage();
            //Select Create Question
            paperTestUXPage.SelectCreateQuestion(questionTypeEnum);
            //Create MyTest True and False Question
            new TrueFalsePage().CreateMyTestQuestion();
            //Save The MyTest Activity
            paperTestUXPage.SaveTheMyTestActivity();
            Logger.LogMethodExit("CreateActivity", "CreateMyTestActivityUsingQuestion",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Gets the Activity from Memory
            Activity activity = Activity.Get(activityTypeEnum, activityBehavioralModesEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyDisplayOfActivityInMyCourseFrame", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetActivityName(activity.Name)));
            Logger.LogMethodExit("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            // Click On The Activity Cmenu In MyCourse Frame
            new CourseContentUXPage().ClickTheActivityShowHideCmenuInMyCourseFrame();
            Logger.LogMethodExit("CreateActivity",
                "ClickTheActivityCmenuOptionInMyCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Declaration of object
            AddAssessmentPage addAssessmentPage = new AddAssessmentPage();
            //Enter Activity Details and Click on Add Question Link
            addAssessmentPage.EnterActivityDetailsandClickonAddQuestion(activityTypeEnum);
            //Create Gradable Activity Using Essay Question
            addAssessmentPage.CreateGradableActivityUsingEssayQuestion(activityTypeEnum);
            Logger.LogMethodExit("CreateActivity", 
                "CreateGradableActivityWithEssayQuestion",
                base.IsTakeScreenShotDuringEntryExit);
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
                IsTakeScreenShotDuringEntryExit);
            var contentLibraryUxPage = new ContentLibraryUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Window
            contentLibraryUxPage.SelectTheWindowName(GradeBookResource.
                GradeBook_Coursematerials_Window_Title);
            //Select the frame
            contentLibraryUxPage.SelectAndSwitchtoFrame(GradeBookResource.
                GradeBook_Coursematerials_LeftFrame_Id_Locator);
            // Select the activity
            contentLibraryUxPage.SelectActivity(activity.Name);
            // Click on Activity Add Button
            contentLibraryUxPage.ClickOnActivityAddButton();
            Logger.LogMethodExit("CreateActivity", 
                "AssociateTheActivityFromContentLibraryToMyCourse",
                IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
            //Create The NonGradable Activity.
            new ContentLibraryUXPage().
                CreateNonGradableActivityInContentlibrary(activityTypeEnum);
            Logger.LogMethodExit("CreateActivity",
                "CreateTheNonGradableActivityInContentLibrary",
                      base.IsTakeScreenShotDuringEntryExit);
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
                      base.IsTakeScreenShotDuringEntryExit);
            //Create The Audio Page Asset
            new PegasusHTMLUXPage().
                RecordAudioFromPageAssetType(pageAssetTypeEnum);
            Logger.LogMethodExit("CreateActivity",
                "CreateAudioPageAssetTypeInContentLibrary",
                      base.IsTakeScreenShotDuringEntryExit);
        }

        
        /// <summary>
        /// Preview The Audio Page Asset.
        /// </summary>
        /// <param name="cmenuOption">This is Page Cmenu Preview Option.</param>
        [When(@"I '(.*)' the HTML Page Asset")]
        public void PreviewTheHtmlPageAsset(string cmenuOption)
        {
            Logger.LogMethodEntry("CreateActivity", "PreviewTheHtmlPageAsset",
               base.IsTakeScreenShotDuringEntryExit);
           //Search For HTML Audio Page Asset
            new PegasusHTMLUXPage().SearchForAudioHTMLPage();           
            //Select Cmenu Option of Page Asset
            new ContentLibraryUXPage().SelectCmenuOptionOfActivity(cmenuOption);
            Logger.LogMethodExit("CreateActivity", "PreviewTheHtmlPageAsset",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The HTML Preview Page.
        /// </summary>
        [Then(@"I should able to see the preview page")]
        public void SelectHtmlPagePreviewPage()
        {
            Logger.LogMethodEntry("CreateActivity", "SelectHtmlPagePreviewPage",
               base.IsTakeScreenShotDuringEntryExit);
            // Select The HTML Preview Page
            new PegasusHTMLUXPage().SelectHTMLPreviewPage();
            Logger.LogMethodExit("CreateActivity", "SelectHtmlPagePreviewPage",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The HTML Play Button.
        /// </summary>
        [When(@"I click on the Play button")]
        public void ClickOnTheHtmlPlayButton()
        {
            Logger.LogMethodEntry("CreateActivity", "ClickOnTheHtmlPlayButton",
               base.IsTakeScreenShotDuringEntryExit);
            // Click The HTML Play Button
            new PegasusHTMLUXPage().ClickTheHTMLPlayButton();
            Logger.LogMethodExit("CreateActivity", "ClickOnTheHtmlPlayButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Play The Audio Successfully.
        /// </summary>
        [Then(@"I should play the audio successfully")]
        public void VerifyTheHtmlAudioPlayer()
        {
            Logger.LogMethodEntry("CreateActivity", "VerifyTheHtmlAudioPlayer",
               base.IsTakeScreenShotDuringEntryExit);
            //Play The Audio Successfully
            new PegasusHTMLUXPage().VerifyTheAudioPlayer();
            Logger.LogMethodExit("CreateActivity", "VerifyTheHtmlAudioPlayer",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create SAM activity type in Activity preference
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum</param>
        [When(@"I Create a new ""(.*)"" SAM activity type")]
        public void CreateSAMActivityTypeInActivityPreference(
                         Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create SAM Activity type
            Logger.LogMethodEntry("CreateActivity",
                "CreateSAMActivityTypeInActivityPreference",
               base.IsTakeScreenShotDuringEntryExit);
            // Click on Activity Name Link in ActivityPrefrence page
            new ActivitiesPreferencesPage().ClickAddActivityNameLinkInActivityPrefrence();

            //Store the activity name in memory
            new ActivitiesPreferencesPage().EnterActivityNameAndStoreActivityInMemory(activityTypeEnum);

            Logger.LogMethodExit("CreateActivity",
                "CreateSAMActivityTypeInActivityPreference",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click edit link of activity type to enable preferences
        /// </summary>
        /// <param name="activityTypeEnum"></param>
        [When(@"I click on ""(.*)"" edit link")]
        public void ClickActivityEditLinkInActivtyPreference(Activity.ActivityTypeEnum activityTypeEnum)
        {

            Logger.LogMethodEntry("CreateActivity",
                "ClickActivityEditLinkInActivtyPreference",
                base.IsTakeScreenShotDuringEntryExit);

            //Click Activtiy edit link
            new ActivitiesPreferencesPage().EditActivityPreference(activityTypeEnum);

            Logger.LogMethodExit("CreateActivity",
                "ClickActivityEditLinkInActivtyPreference",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Activity Type under 
        /// </summary>
        /// <param name="activityTypeEnum"></param>
        [When(@"I click on the ""(.*)"" SAM activity type")]
        public void ClickOnTheSAMActivityType(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Activity Type
            Logger.LogMethodEntry("CreateActivity", "ClickOnTheSAMActivityType",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            String generatedActivityName = activity.Name.ToString();
            //Click On Activity Type
            new ContentLibraryUXPage().ClickOnActivityType(generatedActivityName);
            Logger.LogMethodExit("CreateActivity", "ClickOnTheSAMActivityType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Child Same Activity
        /// </summary>
        /// <param name="activityTypeEnum">This is the activity type enum</param>
        [When(@"I Create ""(.*)"" SAM activity")]
        public void CreateChildSAMActivity(Activity.ActivityTypeEnum activityTypeEnum)
        {
            Logger.LogMethodEntry("CreateActivity", "CreateChildSAMActivity",
                base.IsTakeScreenShotDuringEntryExit);
            AddAssessmentPage addAssessmentPage = new AddAssessmentPage();
            //Enter Activity Details and Click on Add Question Link
            addAssessmentPage.EnterActivityDetailsandClickonAddQuestion(activityTypeEnum);
            Logger.LogMethodExit("CreateActivity", "CreateChildSAMActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

   
       /// <summary>
        /// Add question to activity using "Create New Question" option.
       /// </summary>
       /// <param name="questionType">Type of New Question Created.</param>
       /// <param name="questionCreationOption">Add Question Option.</param>
       [When(@"I create ""(.*)"" question type for at ""(.*)"" for Random Activity and Save Activity")]
        public void CreateQuestionForRandomActivity(string questionType, string questionCreationOption)

        {
            // Add question to activity using "Create New Question" option
            Logger.LogMethodEntry("CreateActivity", "CreateQuestionForRandomActivity",
              base.IsTakeScreenShotDuringEntryExit);
            RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
            //Select Expected Question Type
            new SelectQuestionTypePage().ClickTheExpectedQuestionType(questionType);
            //Create True/False Question
            new TrueFalsePage().CreateTrueFalseQuestion();
            //Click on Save and Return
            randomTopicListPage.ClickOnSaveAndReturnButton();
            Logger.LogMethodExit("CreateActivity", "CreateQuestionForRandomActivity",
             base.IsTakeScreenShotDuringEntryExit);
           
        }

        /// <summary>
        /// Option to Add Question.
        /// </summary>
       /// <param name="addQuestionOption">This is the option to add question.</param>
       [When(@"I Add Questions using ""(.*)"" option")]
       public void SelectOptionToAddQuestion(string addQuestionOption)
       {
           // Select Option to Add Question
           Logger.LogMethodEntry("CreateActivity", "SelectOptionToAddQuestion",
             base.IsTakeScreenShotDuringEntryExit);
           // Select Option to Add Question
           RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
           randomTopicListPage.SelectOptionForQuestionCreation(addQuestionOption);
           Logger.LogMethodExit("CreateActivity", "SelectOptionToAddQuestion",
            base.IsTakeScreenShotDuringEntryExit);
       }

        /// <summary>
        /// Select A Question From Bank.
        /// </summary>
       [When(@"I should Add question from Question Bank and Save Activity")]
       public void AddQuestionFromQuestionBankAndSaveActivity()
       {
           // Select A Question From Bank
           Logger.LogMethodEntry("CreateActivity", "AddQuestionFromQuestionBankAndSaveActivity",
            base.IsTakeScreenShotDuringEntryExit);
           // Select A Question From Bank
           new ContentBrowserMainUXPage().SelectAQuestionFromQuestionBank();
           //Click on Save and Return for Activity
           RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
           randomTopicListPage.ClickOnSaveAndReturnButton();
           Logger.LogMethodExit("CreateActivity", "AddQuestionFromQuestionBankAndSaveActivity",
          base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Select Questions from Question Group .
       /// </summary>
       /// <param name="questionTypeEnum">This is Question Group Name.</param>
       [When(@"I should select ""(.*)"" Question Group and Save Activity")]
       public void SelectQuestionGroupAndSaveActivity(Question.QuestionTypeEnum questionTypeEnum)
       {
           // Select Questions from Question Group
           Logger.LogMethodEntry("CreateActivity", "SelectQuestionGroupAndSaveActivity",
          base.IsTakeScreenShotDuringEntryExit);
           //Get the question Group Name
           Question question = Question.Get(questionTypeEnum);
           string questionGroupName = question.QuestionGroup.ToString();
           // Select Questions from Question Group
           new ContentBrowserMainUXPage().SelectAQuestionGroup(questionGroupName);
           //Click on Save and Return for Activity
           RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
           randomTopicListPage.ClickOnSaveAndReturnButton();
           Logger.LogMethodExit("CreateActivity", "SelectQuestionGroupAndSaveActivity",
          base.IsTakeScreenShotDuringEntryExit);


       }

        /// <summary>
        /// Create Question Section at Activity Creation.
        /// </summary>
        /// <param name="optionValue">Add Section Value.</param>
        /// <param name="sectionValue">This is Section Name</param>

       [When(@"I perform ""(.*)"" of name ""(.*)""")]
       public void CreateQuestionSection(string optionValue, string sectionName)
       {
           // Create Question Section at Activity Creation
           Logger.LogMethodEntry("CreateActivity", "CreateQuestionSection",
           base.IsTakeScreenShotDuringEntryExit);
           RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
           //Select Add Sections Option
           randomTopicListPage.SelectAddSectionsOptions(optionValue);
           randomTopicListPage.CreateSection(sectionName);
           Logger.LogMethodExit("CreateActivity", "CreateQuestionSection",
           base.IsTakeScreenShotDuringEntryExit);
       }

      
        /// <summary>
        /// Select expected option for add questionunder a section.
        /// </summary>
        /// <param name="optionValue">This is Add Question Option Under Section.</param>
       [When(@"select ""(.*)"" option at add question for Section ""(.*)""")]
       public void SelectOptionAtAddQuestionUnderSection(string optionValue,string sectionNumber)
       {
           // Select expected option for add questionunder a section
           Logger.LogMethodEntry("CreateActivity", "SelectOptionAtAddQuestionUnderSection",
           base.IsTakeScreenShotDuringEntryExit);
           // Select expected option for add questionunder a section
           RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
           randomTopicListPage.SectionAddQuestionsOptionsUnderSection(optionValue,sectionNumber);
           Logger.LogMethodExit("CreateActivity", "SelectOptionAtAddQuestionUnderSection",
           base.IsTakeScreenShotDuringEntryExit);
       }


        /// <summary>
       /// Add Questions To A Section.
       /// </summary>
       /// <param name="numberOfQuestions">This is Number of Questions to be Added.</param>
       /// <param name="questionType">This is Type of question to be Added.</param>
       /// <param name="sectionNumber">This is the Section Number.</param>
      [Then(@"I add '(.*)' questions of type ""(.*)"" at Section ""(.*)""")]
       public void AddQuestionsToASection(int numberOfQuestions, string questionType, string sectionNumber)
      {
          // Add Questions To A Section
          Logger.LogMethodEntry("CreateActivity", "AddQuestionsToASection",
          base.IsTakeScreenShotDuringEntryExit);
          RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
          // Add Questions To A Section
          randomTopicListPage.CreateSectionsWithMultipleQuestions(numberOfQuestions,
          questionType, sectionNumber);
          Logger.LogMethodExit("CreateActivity", "AddQuestionsToASection",
          base.IsTakeScreenShotDuringEntryExit);
      }
     


        /// <summary>
        /// Set Number Of Questions Per Page at Activity level.
        /// </summary>
        /// <param name="questionCount">This is number of qusetions.</param>
       [Then(@"I reset number of questions per page value as ""(.*)""")]
       public void SetNumberOfQuestionsPerPage(string questionCount)
       {
           // Set Number Of Questions Per Page at Activity level
           Logger.LogMethodEntry("CreateActivity",
            "SetNumberOfQuestionsPerPage",
          base.IsTakeScreenShotDuringEntryExit);
           RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
           // Set Number Of Questions Per Page at Activity level
           randomAssessmentPage.SetQuestionsPerPagePreference(questionCount);
           Logger.LogMethodExit("CreateActivity",
            "SetNumberOfQuestionsPerPage",
           base.IsTakeScreenShotDuringEntryExit);
       
       }

        /// <summary>
        /// Set Style Sheet Type at Activity level.
        /// </summary>
        /// <param name="sheetType">This is Style type.</param>
       [Then(@"I reset style sheet to ""(.*)""")]
       public void ResetStyleSheet(string sheetType)
       {
           // Set Style Sheet Type at Activity level
           Logger.LogMethodEntry("CreateActivity",
              "ResetStyleSheet",
          base.IsTakeScreenShotDuringEntryExit);
           RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
           // Set Style Sheet Type at Activity level
           randomAssessmentPage.SetStyleSheet(sheetType);
           Logger.LogMethodExit("CreateActivity",
             "ResetStyleSheet",
          base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Set Skip Question Preference at Activity Level.
       /// </summary>
       [Then(@"I check Allow students to skip questions")]
       public void CheckOrUnCheckSkipQuestionPreference()
       {
           // Set Skip Question Preference at Activity Level
           Logger.LogMethodEntry("CreateActivity",
               "PerformButtonActionsAtEditRandomActivityWindow",
           base.IsTakeScreenShotDuringEntryExit);
           RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
           // Set Skip Question Preference at Activity Level
           randomAssessmentPage.ClickSkipQuestion();
           Logger.LogMethodExit("CreateActivity",
              "PerformButtonActionsAtEditRandomActivityWindow",
           base.IsTakeScreenShotDuringEntryExit);
       }

        /// <summary>
        /// Click on buttons at Activity Creation Window.
        /// </summary>
        /// <param name="actionType">This is the action/button type.</param>
        /// <param name="tabName">This is tab name.</param>
       [Then(@"I perform ""(.*)"" for ""(.*)""")]
       [When(@"I perform ""(.*)"" for ""(.*)""")]
       public void PerformButtonActionsAtEditRandomActivityWindow(string actionType, string tabName)
       {
           // Click on buttons at Activity Creation Window
           Logger.LogMethodEntry("CreateActivity", 
               "PerformButtonActionsAtEditRandomActivityWindow",
           base.IsTakeScreenShotDuringEntryExit);
           RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
           // Click on buttons at Activity Creation Window
           randomTopicListPage.ButtonActionsForTabsAtEditRandomActivity(actionType, tabName);
           Logger.LogMethodExit("CreateActivity", 
               "PerformButtonActionsAtEditRandomActivityWindow",
           base.IsTakeScreenShotDuringEntryExit);
          
       }

        /// <summary>
        /// Enter the message in Meassages Tab at Activity Creation Window.
        /// </summary>
        /// <param name="messageType">This is Message Type.</param>
       [Then(@"I add ""(.*)"" message")]
       public void AddMessage(string messageType)
       {
           // Enter the message in Meassages Tab at Activity Creation Window
           Logger.LogMethodEntry("CreateActivity", "AddMessage",
           base.IsTakeScreenShotDuringEntryExit);
           RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
           // Enter the message in Meassages Tab at Activity Creation Window
           randomAssessmentPage.EnterMessagesValues(messageType);
           Logger.LogMethodExit("CreateActivity", "AddMessage",
           base.IsTakeScreenShotDuringEntryExit);
       }

        /// <summary>
        /// Add/Edit/Delete Direction Lines to an activity Section.
        /// </summary>
        /// <param name="actionType">This is action to be performed.</param>
        /// <param name="sectionNumber">This is the section number.</param>
       [When(@"I ""(.*)"" Directions at Section ""(.*)""")]
       public void AddDirectionsAtSection(string actionType,string sectionNumber)
       {
           // Add/Edit/Delete Direction Lines to an activity Section
           Logger.LogMethodEntry("CreateActivity", "AddDirectionsAtSection",
           base.IsTakeScreenShotDuringEntryExit);
           RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
           // Add/Edit/Delete Direction Lines to an activity Section
           randomAssessmentPage.EnterDirectionLineToSection(actionType,sectionNumber);
           Logger.LogMethodExit("CreateActivity", "AddDirectionsAtSection",
           base.IsTakeScreenShotDuringEntryExit);
       }

        /// <summary>
        /// Verification of Section Direction Lines at Activity Creation Window.
        /// </summary>
        /// <param name="actionType">This is the action type performed on direction lines.</param>
       /// <param name="sectionNumber">This is the section number.</param>
       [Then(@"I should see Directions ""(.*)"" to Section ""(.*)""")]
       public void VerifyDirectionsAtSection(string actionType,string sectionNumber)
       {
           // Verification of Section Direction Lines at Activity Creation Window
           Logger.LogMethodEntry("CreateActivity", "VerifyDirectionsAtSection",
           base.IsTakeScreenShotDuringEntryExit);
           RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
           // Verification of Section Direction Lines at Activity Creation Window
           Assert.IsTrue(randomAssessmentPage.VerifyTheDirectionLines(actionType,sectionNumber));
           Logger.LogMethodExit("CreateActivity", "VerifyDirectionsAtSection",
           base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Verify Section Direction Line Deletion.
       /// </summary>
       /// <param name="sectionNumber">This is the section number.</param>
       [Then(@"I should see Directions deleted at Section ""(.*)""")]
       public void VerifySectionDirectionDeletion(string sectionNumber)
       {
           // Verify Section Direction Line Deletion
           Logger.LogMethodEntry("CreateActivity", "VerifySectionDirectionDeletion",
           base.IsTakeScreenShotDuringEntryExit);
           // Verify Section Direction Line Deletion
           Assert.IsFalse(new RandomAssessmentPage().VerifyDirectionDeletion(sectionNumber));
           Logger.LogMethodExit("CreateActivity", "VerifySectionDirectionDeletion",
           base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Enable "Save response at the end of each page" preference at activity preference 
       /// </summary>
       [When(@"I check Save response at the end of each page")]
       public void EnableSaveResponseAtTheEndOfEachPagePreference()
       {
           Logger.LogMethodEntry("CreateActivity", "EnableSaveResponseAtTheEndOfEachPagePreference",
               base.IsTakeScreenShotDuringEntryExit);
           RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
           randomAssessmentPage.EnableSaveResponseAtEndOfThePageRandomActivity();
           Logger.LogMethodExit("CreateActivity", "EnableSaveResponseAtTheEndOfEachPagePreference",
               base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Enable "Save response at the end of each page" preference at activity preference 
       /// </summary>
       [When(@"I select Number of attempts is unlimited option")]
       public void EnableSelectNumberOfAttemptsIsUnlimitedPreferneceOption()
       {
           Logger.LogMethodEntry("CreateActivity", "EnableSelectNumberOfAttemptsIsUnlimitedPreferneceOption",
               base.IsTakeScreenShotDuringEntryExit);
           RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
           randomAssessmentPage.EnableNumberOfAttemptsIsUnlimitedOptionRandomActivity();
           Logger.LogMethodExit("CreateActivity", "EnableSelectNumberOfAttemptsIsUnlimitedPreferneceOption",
               base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Click on "Save and Return" button in preference page
       /// </summary>
       [When(@"I click on Save and Return button")]
       public void ClickOnSaveAndReturnButton()
       {
           Logger.LogMethodEntry("CreateActivity", "ClickOnSaveAndReturnButton",
             base.IsTakeScreenShotDuringEntryExit);
           RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
           randomAssessmentPage.ClickSaveAndReturnButton();
           Logger.LogMethodExit("CreateActivity", "ClickOnSaveAndReturnButton",
             base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// User search the activtiy in MyCourse frame of "Add from Library"
       /// </summary>
       /// <param name="activityType">This is acivity type enum.</param>
       /// <param name="tabName">This is tab name.</param>
       [When(@"I search ""(.*)"" in My Course frame  of ""(.*)"" tab")]
       public void SearchActivtiyInMyCourseFrameOfTab(Activity.ActivityTypeEnum activityType, string tabName)
       {
           Logger.LogMethodEntry("CreateActivity", "SearchActivtiyInMyCourseFrameOfTab",
               base.IsTakeScreenShotDuringEntryExit);
           new ContentLibraryUXPage().SearchActivityInMyCourse(activityType, tabName);
           Logger.LogMethodExit("CreateActivity", "SearchActivtiyInMyCourseFrameOfTab",
           base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Validate the display of searched activity In MyCourse Frame
       /// </summary>
       /// <param name="activityType">This is activity type enum.</param>
       /// <param name="tabName">This is tab name.</param>
       [Then(@"I should be displayed with ""(.*)"" in My Course frame  of ""(.*)"" tab")]
       public void ValidateTheDisplayOfSearchedActivityInMyCourseFrame(Activity.ActivityTypeEnum activityType, string tabName)
       {
           Logger.LogMethodEntry("CreateActivity", "ValidateTheDisplayOfSearchedActivityInMyCourseFrame",

  base.IsTakeScreenShotDuringEntryExit);
           Activity activity = Activity.Get(activityType);
           string activityName = activity.Name.ToString();
           Logger.LogAssertion("ValidateActivityHasBeenStartedAndSavedMessage", ScenarioContext.
           Current.ScenarioInfo.Title,
               () => Assert.AreEqual(activityName, new ContentLibraryUXPage().GetActivityNameFromMyCourseFrame(tabName)));
           Logger.LogMethodExit("CreateActivity", "ValidateTheDisplayOfSearchedActivityInMyCourseFrame",

  base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// User Click On Activity cmenu in MyCourse of ddd content from library
       /// </summary>
       /// <param name="cmenuOptionName">This is cmenu option name.</param>
       /// <param name="activityType">This is activity type.</param>
       /// <param name="tabName">This is tab name.</param>
       /// <param name="userType">This is user type.</param>
       [When(@"I click on ""(.*)""  of ""(.*)"" in  ""(.*)"" tab as ""(.*)""")]
       public void UserClickOnActivityCmenuInMyCourseOfAddContentFromLibrary(string cmenuOptionName, Activity.ActivityTypeEnum

activityType, string tabName, User.UserTypeEnum userType)
       {
           Logger.LogMethodEntry("CreateActivity", "UserClickOnActivityCmenuInMyCourseOfAddContentFromLibrary",
               base.IsTakeScreenShotDuringEntryExit);
           new ContentLibraryUXPage().ClickCmenuOptionBasedOnTheUserRole(cmenuOptionName, activityType, tabName, userType);

           Logger.LogMethodExit("CreateActivity", "UserClickOnActivityCmenuInMyCourseOfAddContentFromLibrary",
               base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Validate the display of submit student answer button in view subission page
       /// </summary>
       /// <param name="buttonName">This is button name.</param>
       /// <param name="pageName">This is page name.</param>
       [Then(@"I should see ""(.*)"" button in ""(.*)"" page")]
       public void ValidateTheDisplayofSubmitStudentAnswerButtonInViewSubissionPage(string buttonName, string pageName)
       {
           Logger.LogMethodEntry("CreateActivity", "ValidateTheDisplayofSubmitStudentAnswerButtonInViewSubissionPage",

base.IsTakeScreenShotDuringEntryExit);
           Logger.LogAssertion("ValidateTheDisplayofSubmitStudentAnswerButtonInViewSubissionPage", ScenarioContext.
             Current.ScenarioInfo.Title,
                 () => Assert.AreEqual(buttonName, new ContentLibraryUXPage().GetButtonNameFromViewSubmissionPage(pageName)));
           Logger.LogMethodExit("CreateActivity", "ValidateTheDisplayofSubmitStudentAnswerButtonInViewSubissionPage",

base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Instructor click on "Submit Student's Answer" button in "View Submission" page
       /// </summary>
       /// <param name="buttonName">This is button name.</param>
       /// <param name="pageTitle">This is page title.</param>
       [When(@"I click  ""(.*)"" button in ""(.*)"" page")]
       public void InstructorClickSubmitStudentAnswerButtonInViewSubmission(string buttonName, string pageTitle)
       {
           Logger.LogMethodEntry("CreateActivity", "InstructorClickSubmitStudentAnswerButtonInViewSubmission",

base.IsTakeScreenShotDuringEntryExit);
           new ViewSubmissionPage().ClickSubmitStudentAnswerbutton(buttonName, pageTitle);
           Logger.LogMethodExit("CreateActivity", "InstructorClickSubmitStudentAnswerButtonInViewSubmission",

base.IsTakeScreenShotDuringEntryExit);
       }


       /// <summary>
       /// Validate the "Question was not attempted" message display in view submission page
       /// </summary>
       /// <param name="messageText">This is message text.</param>
       [Then(@"I should be displayed with ""(.*)"" for unanswered question")]
       public void ValidateDisplayofQuestionWasNotAttemptedMessage(string messageText)
       {
           Logger.LogMethodEntry("CreateActivity", "ValidateDisplayofQuestionWasNotAttemptedMessage",

base.IsTakeScreenShotDuringEntryExit);
           Logger.LogAssertion("ValidateDisplayofQuestionWasNotAttemptedMessage", ScenarioContext.
             Current.ScenarioInfo.Title,
                 () => Assert.AreEqual(messageText, new ViewSubmissionPage().GetDisplayofQuestionWasNotAttemptedMessageText()));
           Logger.LogMethodExit("CreateActivity", "ValidateDisplayofQuestionWasNotAttemptedMessage",

base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Set Specify Number of Attempts to a given number
       /// </summary>
       /// <param name="allowedAttempts">This is the number of allowed attempts</param>
       [When(@"I set specify number of Attempts to ""(.*)""")]
       public void SetSpecifyNumberOfAttempts(string allowedAttempts)
       {
           Logger.LogMethodEntry("CreateActivity", "SetSpecifyNumberOfAttempts", base.IsTakeScreenShotDuringEntryExit);
           RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
           randomAssessmentPage.SpecifyNumberOfAttempts(allowedAttempts);
           Logger.LogMethodExit("CreateActivity", "SetSpecifyNumberOfAttempts", base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Save activity preference in create activity creation popup
       /// </summary>
       [When(@"I Save the activity")]
       public void SaveandReturnActivityPreference()
       {
           Logger.LogMethodEntry("CreateActivity", "SaveandReturnActivityPreference", base.IsTakeScreenShotDuringEntryExit);
           RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
           randomAssessmentPage.SaveandReturnPreferenceAtCreateRandomActivity();
           Logger.LogMethodExit("CreateActivity", "SaveandReturnActivityPreference", base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Add Help links for SAM type Random activity 
       /// </summary>
       [When(@"I add 'HelpLinks'")]
       public void AddHelpLinksSAMActivity()
       {
           Logger.LogMethodEntry("CreateActivity", "AddHelpLinksSAMActivity", base.IsTakeScreenShotDuringEntryExit);
           AddAssessmentPage addAssessmentPage = new AddAssessmentPage();
           //Enter HelpLinks
           addAssessmentPage.AddHelpLinks();
           Logger.LogMethodExit("CreateActivity", "AddHelpLinksSAMActivity", base.IsTakeScreenShotDuringEntryExit);
       }


       /// <summary>
       /// Configure Grades tab of Random activity
       /// </summary>
       [When(@"I configure the 'Grades' preference")]
       public void ConfigureGradesPreferenceSAMActivity()
       {
           Logger.LogMethodEntry("CreateActivity", "ConfigureGradesPreferenceSAMActivity", base.IsTakeScreenShotDuringEntryExit);
           AddAssessmentPage addAssessmentPage = new AddAssessmentPage();
           // Configure Grades
           addAssessmentPage.ConfigureGradesForSamActivity();
           Logger.LogMethodExit("CreateActivity", "ConfigureGradesPreferenceSAMActivity", base.IsTakeScreenShotDuringEntryExit);
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
