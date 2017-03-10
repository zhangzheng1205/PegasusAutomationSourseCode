using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles Create Activity Actions.
    /// </summary>
    [Binding]
    public class CreateActivity : PegasusBaseTestFixture
    {

        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CreateActivity));


        /// <summary>
        /// Click On Add Course Materials Option. 
        /// </summary>
        [When(@"I select 'Add Course Materials' in 'My Course'")]
        public void ClickOnAddCourseMaterialsOption()
        {
            //Click On Add Course Materials Option
            Logger.LogMethodEntry("CreateActivity", "ClickOnAddCourseMaterialsOption",
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
            new ContentLibraryUXPage().ClickOnAddCourseMaterialsLink();
            Logger.LogMethodExit("CreateActivity", "ClickOnAddCourseMaterialsOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Activity of Behavioral Mode.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        /// <param name="behavioralModeEnum">This is behavioral mode enum.</param>
        [When(@"I create ""(.*)"" activity of behavioral mode ""(.*)"" type")]
        public void CreateActivityOfBehavioralModeType(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create Activity
            Logger.LogMethodEntry("CreateActivity", "CreateActivityOfBehavioralModeType",
               base.IsTakeScreenShotDuringEntryExit);
            //Create Activity
            new AddAssessmentPage().CreateActivity(activityTypeEnum, behavioralModeEnum);
            Logger.LogMethodExit("CreateActivity", "CreateActivityOfBehavioralModeType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create a SIM5 SkillBased Activity
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum</param>
        /// <param name="behavioralModeEnum">This is behavioral mode enum</param>
        [When(@"I create a ""(.*)"" of behavioral mode ""(.*)"" type")]
        public void CreateSIM5ActivityOfBehavioralModeSkillBasedType(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            Logger.LogMethodEntry("CreateActivity", "CreateActivityOfBehavioralModeSkillBasedType",
                base.IsTakeScreenShotDuringEntryExit);
            //Create Activity
            new AddAssessmentPage().CreateSIM5Activity(activityTypeEnum, behavioralModeEnum);
            Logger.LogMethodExit("CreateActivity", "CreateActivityOfBehavioralModeSkillBasedType",
                base.IsTakeScreenShotDuringEntryExit);
        }




        /// <summary>
        /// Create a SkillBased SIM5 Activity
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum</param>
        //[When(@"I create ""(.*)"" activity of behavioral mode SkillBased type")]
        //public void CreateSkillBasedSim5Activity(Activity.ActivityTypeEnum activityTypeEnum)
        //{
        //    //Create Activity
        //    Logger.LogMethodEntry("CreateActivity", "CreateActivityOfBehavioralModeType",
        //       base.IsTakeScreenShotDuringEntryExit);
        //    //Create Activity
        //    new AddAssessmentPage().CreateActivity(activityTypeEnum, 0);
        //    Logger.LogMethodExit("CreateActivity", "CreateActivityOfBehavioralModeType",
        //        base.IsTakeScreenShotDuringEntryExit);
        //}
        /// <summary>
        /// Create Instructor Gradable Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        /// <param name="behavioralModeEnum">This is behavioral mode enum.</param>
        [When(@"I create ""(.*)"" activity of behavioral mode ""(.*)"" type using Essay question")]
        public void CreateInstructorGradableActivity(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create Instructor Gradable Activity
            Logger.LogMethodEntry("CreateActivity", "CreateInstructorGradableActivity",
               base.IsTakeScreenShotDuringEntryExit);
            //Enter Activity Details and Click on Add Question Link
            new AddAssessmentPage().EnterActivityDetailsandClickonAddQuestion(activityTypeEnum);
            //Create Activity
            new AddAssessmentPage().CreateTheInstructorGradableActivity(
                activityTypeEnum);
            Logger.LogMethodExit("CreateActivity", "CreateInstructorGradableActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create SIMActivity Of Behavioral ModeType.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        /// <param name="behavioralModeEnum">This is behavioral mode enum.</param>
        [When(@"I create ""(.*)"" activity of behavioral mode ""(.*)"" type using SIM question")]
        public void CreateSIMActivityOfBehavioralModeType(
                      Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create SIMActivity Of Behavioral ModeType.
            Logger.LogMethodEntry("CreateActivity",
                "CreateSIMActivityOfBehavioralModeType",
               base.IsTakeScreenShotDuringEntryExit);
            //Create SIM Activity
            new AddAssessmentPage().CreateSIMActivity(activityTypeEnum, behavioralModeEnum);
            Logger.LogMethodExit("CreateActivity",
                "CreateSIMActivityOfBehavioralModeType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On ShowHide Status Option.
        /// </summary>
        [When(@"I click on 'ShowHide' option of Activity")]
        public void ClickOnShowHideStatusOption()
        {
            //Click On ShowHide Status Option
            Logger.LogMethodEntry("CreateActivity", "ClickOnShowHideStatusOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Activity Type
            new CourseContentUXPage().ClickTheShowHideStatusOption();
            Logger.LogMethodExit("CreateActivity", "ClickOnShowHideStatusOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create SIM Studyplan.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        /// <param name="behavioralModeEnum">This is behavioral mode enum.</param>
        [When(@"I create ""(.*)"" of behavioral mode ""(.*)"" type")]
        public void CreateSIMStudyplan(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create SIM Studyplan
            Logger.LogMethodEntry("CreateActivity", "CreateSIMStudyplan",
                base.IsTakeScreenShotDuringEntryExit);
            //Create SIM Studyplan
            new SIMStudyPlanDefaultUXPage().CreateSIMStudyPlan(
                activityTypeEnum, behavioralModeEnum);
            Logger.LogMethodExit("CreateActivity", "CreateSIMStudyplan",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the SIM Study Plan in Content Library frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        [Then(@"I should see ""(.*)"" activity in the Content Library Frame")]
        public void SeeActivityInTheContentLibraryFrame(Activity.ActivityTypeEnum
            activityTypeEnum)
        {
            //Logger Entry
            Logger.LogMethodEntry("CreateActivity", "SeeActivityInTheContentLibraryFrame",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            //Search SIM Study Plan activity
            new CourseContentUXPage().GetActivityName(activity.Name);
            //Logger Exit
            Logger.LogMethodExit("CreateActivity", "SeeActivityInTheContentLibraryFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on cmenu of activity.
        /// </summary>
        /// <param name="cmenuOptionName">This is cmenu name.</param>
        /// <param name="userTypeEnum">This is User type enum.</param>
        [When(@"I click on ""(.*)"" cmenu option of activity in ""(.*)""")]
        public void ClickOnCmenuOptionOfActivity(string cmenuOptionName,
            User.UserTypeEnum userTypeEnum)
        {
            //Logger Entry
            Logger.LogMethodEntry("CreateActivity", "ClickOnCmenuOptionOfActivity",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on Cmenu image of activity
            new CourseContentUXPage().ClickTheActivityCmneuImageIcon();
            //Click on cmenu option of activity
            new CourseContentUXPage().ClickTheCmenuOptionofActivity(cmenuOptionName);
            //Logger Exit
            Logger.LogMethodExit("CreateActivity", "ClickOnCmenuOptionOfActivity",
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
            //Enter Activity Details and Click on Add Question Link
            new AddAssessmentPage().EnterActivityDetailsandClickonAddQuestion(activityTypeEnum);
            //Select Create New Question Option
            randomTopicListPage.SelectCreateNewQuestionOption();
            //Select Question Type
            new SelectQuestionTypePage().ClickTheQuestionType();
            //Create True/False Question
            new TrueFalsePage().CreateTrueFalseQuestion();
            //enter the message
            new AddAssessmentPage().EnterActivityMessage();
            //Set Save for Later Preference
            new SkillBasedAssessmentPage().SetSaveforLaterPreference();
            //Click On Add And Close Button
            new ContentBrowserUXPage().ClickOnAddAndCloseButton();
            Logger.LogMethodExit("CreateActivity", "CreateTheActivityOfBehavioralModeType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create GraderIT Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Activity Behavioral mode type Enum.</param>
        [When(@"I create ""(.*)"" of grader activity of behavioral mode ""(.*)"" type")]
        public void CreateGraderITActivity(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create GraderIT Activity
            Logger.LogMethodEntry("CreateActivity", "CreateGraderITActivity",
               base.IsTakeScreenShotDuringEntryExit);
            //Create Object for RandomTopicList Page
            RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
            //Create Object for AutoGrader Page
            AutoGraderPage autoGraderPage = new AutoGraderPage();
            //Create Object for addAssessment Page
            AddAssessmentPage addAssessmentPage = new AddAssessmentPage();
            //Enter Activity Details and Click on Add Question Link
            addAssessmentPage.CreateSimGraderITActivity(
                activityTypeEnum, behavioralModeEnum);
            //Click On Add Question Link
            randomTopicListPage.ClickOnAddQuestionLink();
            //Select Create New Question link
            randomTopicListPage.ClickOnCreateNewQuestionLink();
            //Create Grader IT Question
            autoGraderPage.CreateGraderITQuestion(
                Question.QuestionTypeEnum.SIM5GraderQuestion);
            //Click On SaveAndReturn Button
            addAssessmentPage.ClickOnSaveAndReturnButton();
            Logger.LogMethodExit("CreateActivity", "CreateGraderITActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Course Materials Link.
        /// </summary>        
        [When(@"I click on the 'Add Course Materials' option")]
        public void ClickOnAddCourseMaterialsLink()
        {
            //Click On Add Course Materials Link
            Logger.LogMethodEntry("CreateActivity", "ClickOnAddCourseMaterialsLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Add Course Materials Option
            new CourseContentUXPage().ClickOnAddCourseMaterialsOption();
            Logger.LogMethodExit("CreateActivity", "ClickOnAddCourseMaterialsLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create The NonGradable Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is the Activity by Type.</param>
        [When(@"I create the nongradable ""(.*)"" activity")]
        public void CreateTheNonGradableActivity(
                         Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create The NonGradable Activity
            Logger.LogMethodEntry("CreateActivity",
                  "CreateTheNonGradableActivity",
                        base.IsTakeScreenShotDuringEntryExit);
            //Create The NonGradable Activity.
            new CourseContentUXPage().CreateTheNonGradableActivity(activityTypeEnum);
            Logger.LogMethodExit("CreateActivity",
                "CreateTheNonGradableActivity",
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Asserts the Activity Name in My Course Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is the Activity by Type.</param>
        [Then(@"I should see ""(.*)"" Activity in the MyCourse Frame")]
        public void DisplayOfActivityInMyCourseFrame(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify the Activity Name added to the My Course Frame
            Logger.LogMethodEntry("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Gets the Activity name from Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetActivityName(activity.Name)));
            Logger.LogMethodExit("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Activity Of BehavioralMode Type.
        /// </summary>
        /// <param name="activityTypeEnum">This is the Activity by Type.</param>
        /// <param name="behavioralModeEnum">This is Activity Behavioral mode type Enum.</param>
        [Then(@"I should see the ""(.*)"" activity of behavioral mode ""(.*)"" type using SIM question")]
        public void VerifyTheActivityOfBehavioralModeType(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralmode)
        {
            //Verify The Activity Of BehavioralMode Type
            Logger.LogMethodEntry("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Gets the Activity name from Memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralmode);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetActivityName(activity.Name)));
            Logger.LogMethodExit("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Cmenuof Activity.
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu option.</param>
        [When(@"I click the ""(.*)"" cmenu option")]
        public void ClickTheCmenuofActivity(string cmenuOption)
        {
            //Click The Cmenuof Activity
            Logger.LogMethodEntry("CreateActivity", "ClickTheCmenuofActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Cmenu of Activity
            new CourseContentUXPage().ClickOnCmenuofActivity(cmenuOption);
            Logger.LogMethodExit("CreateActivity", "ClickTheCmenuofActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign The Activity In Mycourse.
        /// </summary>
        [When(@"I assign the activity in mycourse")]
        public void AssignTheActivityInMycourse()
        {
            //Assign The Activity In Mycourse
            Logger.LogMethodEntry("CreateActivity", "AssignTheActivityInMycourse",
               base.IsTakeScreenShotDuringEntryExit);
            //Assign The Activity In course content
            new CourseContentUXPage().AssignTheActivityInCourseContent();
            Logger.LogMethodExit("CreateActivity", "AssignTheActivityInMycourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Feedback Preference.
        /// </summary>
        [When(@"I set the feedback preference")]
        public void SetTheFeedbackPreference()
        {
            //Set Feedback Preference
            Logger.LogMethodEntry("CreateActivity", "SetTheFeedbackPreference",
               base.IsTakeScreenShotDuringEntryExit);
            //Enable Feedback 'Never' Preference
            new SkillBasedAssessmentPage().EnableFeedbackNeverPreference();
            Logger.LogMethodExit("CreateActivity", "SetTheFeedbackPreference",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set The Feedback for Correct Answer Preference
        /// </summary>
        [When(@"I set the feedback correct answer preference")]
        public void SetTheFeedbackCorrectAnswerPreference()
        {
            //Set The feedback for correct Answer preference
            Logger.LogMethodEntry("CreateActivity", "SetTheFeedbackCorrectAnswerPreference",
               base.IsTakeScreenShotDuringEntryExit);
            //Create Object for RandomAssessment Page
            RandomAssessmentPage randomAssessmentpage = new RandomAssessmentPage();
            //Increae the Activity Attempt
            randomAssessmentpage.IncreaseActivityAttempt(CreateActivityResource.
                CreateActivity_Attempt_Value);
            //Enter Correct Answer Attempt Value
            randomAssessmentpage.EnterCorrectAnswerAttemptValue(CreateActivityResource.
                CreateActivity_AtAttempt_Value);
            //Enable the Attempt Option For Correct Answer
            randomAssessmentpage.EnableAtAttemptOptionForCorrectAnswer();
            //Click the Save and Return tab
            new RandomTopicListPage().ClickOnSaveAndReturnButtonInPreference();
            Logger.LogMethodExit("CreateActivity", "SetTheFeedbackCorrectAnswerPreference",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Course Materials Link in Content Library.
        /// </summary>        
        [When(@"I click on the 'Add Course Materials' option in Content Library")]
        public void ClickOnAddCourseMaterialsLinkInContentLibrary()
        {
            //Click On Add Course Materials Link
            Logger.LogMethodEntry("CreateActivity", "ClickOnAddCourseMaterialsLinkInContentLibrary",
                base.IsTakeScreenShotDuringEntryExit);

            //Click On Add Course Materials Option
            new ContentLibraryUXPage().ClickOnAddCourseMaterialsOptioninContentLibrary();

            Logger.LogMethodExit("CreateActivity", "ClickOnAddCourseMaterialsLinkInContentLibrary",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Necessary Details Begin Creation Of Assignment Behavioral Type.
        /// </summary>
        [When(@"I create activity with Assignment behavioral type")]
        public void EnterTheNecessaryDetailsBeginCreationOfAssignmentBehavioralType()
        {
            Logger.LogMethodEntry("CommonSteps",
                "EnterTheNecessaryDetailsBeginCreationOfAssignmentBehavioralType",
                IsTakeScreenShotDuringEntryExit);

            new AddAssessmentPage().EnterAssignmentActivityDetailsandClickSaveandContinue();

            Logger.LogMethodExit("CommonSteps",
                "EnterTheNecessaryDetailsBeginCreationOfAssignmentBehavioralType",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Messages Activity Sub-tab.
        /// </summary>
        [When(@"I click on the Messages activity subtab")]
        public void ClickOnTheMessagesActivitySubtab()
        {
            Logger.LogMethodEntry("CommonSteps",
                "ClickOnTheMessagesActivitySubtab",
                IsTakeScreenShotDuringEntryExit);

            new AddAssessmentPage().ClickonMessageTab();

            Logger.LogMethodExit("CommonSteps",
                "ClickOnTheMessagesActivitySubtab",
                IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify The Activity Beginning And End Messages are present in new activity
        /// which were previously set In Main Course Preferences.
        /// </summary>
        [Then(@"I should see the activity Beginning and End messages set in Main Course Preferences")]
        public void VerifyTheActivityBeginningAndEndMessagesSetInMainCoursePreferences()
        {
            Logger.LogMethodEntry("CommonSteps",
                "VerifyTheActivityBeginningAndEndMessagesSetInMainCoursePreferences",
                IsTakeScreenShotDuringEntryExit);

            //Asserts the Activity Name
            Logger.LogAssertion("VerifyBeginActivityDefaultMessage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(
                    new ActivitiesPreferencesPage().returnActivityBeginDefaultMessage(),
                    new AddAssessmentPage().returnBeginningofActivityDefaultMessageText()));
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyBeginActivityInstructorMessage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(
                    new ActivitiesPreferencesPage().returnActivityBeginInstructorMessage(),
                    new AddAssessmentPage().returnBeginningofActivityInstructorMessageText()));
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyEndActivityDefaultMessage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(
                    new ActivitiesPreferencesPage().returnActivityEndDefaultMessage(),
                    new AddAssessmentPage().returnEndofActivityDefaultMessageText()));
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyEndActivityInstructorMessage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(
                    new ActivitiesPreferencesPage().returnActivityEndInstructorMessage(),
                    new AddAssessmentPage().returnEndofActivityInstructorMessageText()));

            Logger.LogMethodExit("CommonSteps",
                "VerifyTheActivityBeginningAndEndMessagesSetInMainCoursePreferences",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify New Activity Type In The Add Course Materials Menu.
        /// </summary>
        /// <param name="activityTypeName">Activity Type Name</param>
        [Then(@"I should see the ""(.*)"" activity type in the Add Course Materials menu")]
        public void VerifyNewActivityTypeInTheAddCourseMaterialsMenu(string activityTypeName)
        {
            Logger.LogMethodEntry("CommonSteps", "VerifyNewActivityTypeInTheAddCourseMaterialsMenu",
                IsTakeScreenShotDuringEntryExit);

            //Assert we have correct page opened
            Logger.LogAssertion("VerifyNewActivityTypeName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityTypeName,
                    new ContentLibraryUXPage().
                    VerifyNewActivityType(activityTypeName)));

            Logger.LogMethodExit("CommonSteps", "VerifyNewActivityTypeInTheAddCourseMaterialsMenu",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Basic Random Activity Using True-False Question And HelpLinks.
        /// </summary>
        /// <param name="ActivityTypeEnum">Activity Type Enum</param>
        /// <param name="ActivityBehavioralModesEnum">Activity Behavioral Modes Enum</param>
        [When(@"I create ""(.*)"" activity of behavioral mode ""(.*)"" type using True-False question")]
        public void CreateBasicRandomActivityWithTrueFalseQuestionAndHelpLinks(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create Instructor Gradable Activity
            Logger.LogMethodEntry("CreateActivity",
                "CreateBasicRandomActivityUsingTrueandFalseQuestionAndHelpLinks",
               base.IsTakeScreenShotDuringEntryExit);

            //Enter Activity Details and Click on Add Question Link
            new AddAssessmentPage().EnterActivityDetailsandClickonAddQuestion(activityTypeEnum);
            //Create Activity
            new AddAssessmentPage().CreateActivityWithHelpLinks(activityTypeEnum);

            Logger.LogMethodExit("CreateActivity",
                "CreateBasicRandomActivityUsingTrueandFalseQuestionAndHelpLinks",
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
        /// Click on the asset type
        /// </summary>
        /// <param name="assetType">This is asset type.</param>
        [When(@"I click on the ""(.*)"" asset type")]
        public void WhenIClickOnTheAssetType(string assetType)
        {
            //Click On Activity Type
            Logger.LogMethodEntry("CreateActivity", "ClickOnTheSAMActivityType",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Activity Type
            new ContentLibraryUXPage().ClickOnActivityType(assetType);
            Logger.LogMethodExit("CreateActivity", "ClickOnTheSAMActivityType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Reorder the asset
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        [When(@"I reorder ""(.*)""")]
        public void ReorderAssetInCourseMaterial(Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("CreateActivity", "ClickOnTheSAMActivityType",
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().ReorderAssetInCourseMaterial(activityType);
            Logger.LogMethodExit("CreateActivity", "ClickOnTheSAMActivityType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click cmenu option of asset
        /// </summary>
        /// <param name="cmenuOptionName"></param>
        /// <param name="activityTypeEnum"></param>
        [When(@"I click on ""(.*)"" cmenu option of ""(.*)"" asset")]
        public void ClickCmenuOptionOfAsset(string cmenuOptionName, Activity.ActivityTypeEnum activityTypeEnum)
        {
            Logger.LogMethodEntry("CreateActivity", "ClickCmenuOptionOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().CourseMaterialCmenuFunctionlaity(cmenuOptionName, activityTypeEnum);
            Logger.LogMethodExit("CreateActivity", "ClickCmenuOptionOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Create Child Same Activity
        /// </summary>
        /// <param name="activityTypeEnum">This is the activity type enum</param>
        ///  <param name="activityTypeEnum">This is behavioral Mode</param>
        [When(@"I Create ""(.*)"" activity with Behavioral Mode ""(.*)""")]
        public void SelectBehavioralMode(Activity.ActivityTypeEnum activityTypeEnum, string behavioralMode)
        {
            Logger.LogMethodEntry("CreateActivity", "CreateChildSAMActivity",
                base.IsTakeScreenShotDuringEntryExit);
            AddAssessmentPage addAssessmentPage = new AddAssessmentPage();
            //Enter Activity Details and Click on Add Question Link
            addAssessmentPage.EnterActivityDetails(activityTypeEnum, behavioralMode);
            Logger.LogMethodExit("CreateActivity", "CreateChildSAMActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create asset type
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        [When(@"I create ""(.*)"" activity")]
        public void CreateActivityType(Activity.ActivityTypeEnum activityTypeEnum)
        {
            Logger.LogMethodEntry("CreateActivity", "CreateActivityType",
             base.IsTakeScreenShotDuringEntryExit);
            AddAssessmentPage addAssessmentPage = new AddAssessmentPage();
            //Enter Activity Details and Click on Add Question Link
            addAssessmentPage.EnterAssetDetails(activityTypeEnum);
            Logger.LogMethodExit("CreateActivity", "CreateActivityType",
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
        /// Configure Grades tab of Random activity
        /// </summary>
        [When(@"I configure the 'Grades' preference")]
        public void ConfigureGradesPreferenceSAMActivity()
        {
            Logger.LogMethodEntry("CreateActivity", 
                "ConfigureGradesPreferenceSAMActivity", 
                base.IsTakeScreenShotDuringEntryExit);
            AddAssessmentPage addAssessmentPage = new AddAssessmentPage();
            // Configure Grades
            addAssessmentPage.ConfigureGradesForSamActivity();
            Logger.LogMethodExit("CreateActivity", 
                "ConfigureGradesPreferenceSAMActivity", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Help links for SAM type Random activity 
        /// </summary>
        [When(@"I add 'HelpLinks'")]
        public void AddHelpLinksSAMActivity()
        {
            Logger.LogMethodEntry("CreateActivity", 
                "AddHelpLinksSAMActivity", base.IsTakeScreenShotDuringEntryExit);
            AddAssessmentPage addAssessmentPage = new AddAssessmentPage();
            //Enter HelpLinks
            addAssessmentPage.AddHelpLinks();
            Logger.LogMethodExit("CreateActivity", 
                "AddHelpLinksSAMActivity", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Questions To A Section.
        /// </summary>
        /// <param name="numberOfQuestions">This is Number of Questions to be Added.</param>
        /// <param name="questionType">This is Type of question to be Added.</param>
        /// <param name="sectionNumber">This is the Section Number.</param>
        [Then(@"I add '(.*)' questions of type ""(.*)"" at Section ""(.*)""")]
        public void AddQuestionsToASection(int numberOfQuestions, 
            string questionType, string sectionNumber)
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
            new AddAssessmentPage().SelectCreateRandomActivity();
            //Select Add Sections Option
            randomTopicListPage.SelectAddSectionsOptions(optionValue);
            randomTopicListPage.CreateSection(sectionName);
            Logger.LogMethodExit("CreateActivity", "CreateQuestionSection",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add/Edit/Delete Direction Lines to an activity Section.
        /// </summary>
        /// <param name="actionType">This is action to be performed.</param>
        /// <param name="sectionNumber">This is the section number.</param>
        [When(@"I ""(.*)"" Directions at Section ""(.*)""")]
        public void AddDirectionsAtSection(string actionType, string sectionNumber)
        {
            // Add/Edit/Delete Direction Lines to an activity Section
            Logger.LogMethodEntry("CreateActivity", "AddDirectionsAtSection",
            base.IsTakeScreenShotDuringEntryExit);
            RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
            // Add/Edit/Delete Direction Lines to an activity Section
            randomAssessmentPage.EnterDirectionLineToSection(actionType, sectionNumber);
            Logger.LogMethodExit("CreateActivity", "AddDirectionsAtSection",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verification of Section Direction Lines at Activity Creation Window.
        /// </summary>
        /// <param name="actionType">This is the action type performed on direction lines.</param>
        /// <param name="sectionNumber">This is the section number.</param>
        [Then(@"I should see Directions ""(.*)"" to Section ""(.*)""")]
        public void VerifyDirectionsAtSection(string actionType, string sectionNumber)
        {
            // Verification of Section Direction Lines at Activity Creation Window
            Logger.LogMethodEntry("CreateActivity", "VerifyDirectionsAtSection",
            base.IsTakeScreenShotDuringEntryExit);
            RandomAssessmentPage randomAssessmentPage = new RandomAssessmentPage();
            // Verification of Section Direction Lines at Activity Creation Window
            Assert.IsTrue(randomAssessmentPage.VerifyTheDirectionLines(actionType, sectionNumber));
            Logger.LogMethodExit("CreateActivity", "VerifyDirectionsAtSection",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate the lighbox name
        /// </summary>
        /// <param name="lightBoxName">This is lightbox name.</param>
        [Then(@"I should be on ""(.*)"" lightbox")]
        public void ValidateLightboxTitle(string lightBoxName)
        {
            Logger.LogMethodEntry("CreateActivity", "ValidateLightboxTitle",
            base.IsTakeScreenShotDuringEntryExit);
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyNewActivityTypeName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(lightBoxName,
                    new AddAssessmentPage().
                    GetLightBoxTitle(lightBoxName)));
            Logger.LogMethodExit("CreateActivity", "ValidateLightboxTitle",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the button in Add From Library Lightbox
        /// </summary>
        /// <param name="p0">This is the Button Name.</param>
        [When(@"I click on ""(.*)"" button in 'Add from Library' lightbox")]
        public void ClickOnButtonInAddFromLibraryLightbox(string buttonName)
        {
            Logger.LogMethodEntry("CreateActivity", "ClickOnButtonInAddFromLibraryLightbox",
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().ClickReturnToCourseMaterialsButton(buttonName);
            Logger.LogMethodExit("CreateActivity", "ClickOnButtonInAddFromLibraryLightbox",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click create new folder option.
        /// </summary>
        [When(@"I click on 'Folder' option")]
        public void ClickCreateFolder()
        {
            Logger.LogMethodEntry("CreateActivity", "ClickCreateFolder",
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().ClickCreateFolder();
            Logger.LogMethodExit("CreateActivity", "ClickCreateFolder", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Materials option in Course Material page
        /// </summary>
        [When(@"I click on 'Materials' option")]
        public void ClickMaterialsButton()
        {
            Logger.LogMethodEntry("CreateActivity", "ClickMaterialsButton", 
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().ClickCreateMaterials();
            Logger.LogMethodExit("CreateActivity", "ClickMaterialsButton", 
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate the activity creation in content frame
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        [Then(@"I should be displayed with ""(.*)"" in 'Manage Course Materials' frame")]
        public void ValidateTheDisplayedOfActivity(Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("CreateActivity", "ValidateTheDisplayedOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyNewActivityTypeName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityName,
                    new AddAssessmentPage().
                    GetActivityName(activityName)));
            Logger.LogMethodExit("CreateActivity", "ValidateTheDisplayedOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter inside the assettype
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        [When(@"I enter into ""(.*)"" folder")]
        public void EnterIntoFolder(Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("CreateActivity", "EnterIntoFolder",
                base.IsTakeScreenShotDuringEntryExit);
            // Get the activity name
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();
            new AddAssessmentPage().
                ClickActivityName(activityName);
            Logger.LogMethodExit("CreateActivity", "EnterIntoFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter inside the folder
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        /// <param name="pageName">This is page name.</param>
        [When(@"I enter into ""(.*)"" folder in ""(.*)"" frame")]
        public void WhenIEnterIntoFolderInFrame(Activity.ActivityTypeEnum activityType,
            string pageName)
        {
            Logger.LogMethodEntry("CreateActivity", "EnterIntoFolder",
                base.IsTakeScreenShotDuringEntryExit);
            // Get the activity name
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();
            new CoursePreviewUXPage().
                ClickActivityName(activityName, pageName);
            Logger.LogMethodExit("CreateActivity", "EnterIntoFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate the display of asset in Manage Course Materials 
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        /// <param name="tabName">This is tab name.</param>
        [Then(@"I should be displayed with ""(.*)"" in Manage Course Materials frame of ""(.*)"" tab")]
        public void ValidateDisplayOfAsset(Activity.ActivityTypeEnum activityTypeEnum, string tabName)
        {
            Logger.LogMethodEntry("CreateActivity", "ValidateDisplayOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            string activityName = activity.Name.ToString();
            Logger.LogAssertion("VerifyNewActivityTypeName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityName,
                    new CoursePreviewUXPage().GetAssetName(activityName, tabName)));

            Logger.LogMethodExit("CreateActivity", "ValidateDisplayOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Show option based on the asset status if hidden
        /// </summary>
        /// <param name="actionName">This is action name.</param>
        /// <param name="activityType">This is activity type.</param>
        /// <param name="tabName">This is tab name.</param>
        [When(@"I click ""(.*)"" of ""(.*)"" in ""(.*)"" tab")]
        public void ClickShowOptionOfAsset(string actionName,
            Activity.ActivityTypeEnum activityType, string tabName)
        {
            Logger.LogMethodEntry("CreateActivity", "ClickShowOptionOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().ClickShowOption(actionName, activityType, tabName);
            Logger.LogMethodExit("CreateActivity", "ClickShowOptionOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the asset status based on the asset display.
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        /// <param name="status">This is the asset status</param>
        [Then(@"I should see ""(.*)"" with ""(.*)"" status")]
        public void ValidateAssetStatus(Activity.ActivityTypeEnum activityType, string status)
        {
            Logger.LogMethodEntry("CreateActivity", "ClickShowOptionOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyNewActivityTypeName",
            ScenarioContext.Current.ScenarioInfo.Title,
            () => Assert.AreEqual(status,
                new CoursePreviewUXPage().GetAssetStatus(activityType)));
            Logger.LogMethodExit("CreateActivity", "ClickShowOptionOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Copy the asset in Manage course material
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        /// <param name="pageTitle">This is page title.</param>
        [When(@"I click 'Copy' of ""(.*)"" in ""(.*)"" tab")]
        public void ClickCopyOptionManageCourseMaterial(Activity.ActivityTypeEnum activityType, 
            string pageTitle)
        {
            Logger.LogMethodEntry("CreateActivity", 
                "ClickCopyOptionManageCourseMaterial",
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().ClickCopyOption(activityType, pageTitle);
            Logger.LogMethodExit("CreateActivity", 
                "ClickCopyOptionManageCourseMaterial",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the copied asset count
        /// </summary>
        /// <param name="copiedAssetCount">This is copied asset count.</param>
        [Then(@"I should be displayed with count ""(.*)"" in Paste button")]
        public void ValidateCopiedAssetCount(int copiedAssetCount)
        {
            Logger.LogMethodEntry("CreateActivity", "ValidateCopiedAssetCount",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyNewActivityTypeName",
            ScenarioContext.Current.ScenarioInfo.Title,
            () => Assert.AreEqual(copiedAssetCount,
                new CoursePreviewUXPage().GetCopiedAssetCount()));
            Logger.LogMethodExit("CreateActivity", "ValidateCopiedAssetCount",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Paste the copied asset in the manage course material
        /// </summary>
        /// <param name="pasteOptionType">This is paste option type.</param>
        [When(@"I click on 'Paste' button and I select ""(.*)"" option")]
        public void PasteTheCopiedAsset(string pasteOptionType)
        {
            Logger.LogMethodEntry("CreateActivity", "PasteTheCopiedAsset",
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().PasteTheCopiedAsset(pasteOptionType);
            Logger.LogMethodExit("CreateActivity", "PasteTheCopiedAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign the asset in manage course material
        /// </summary>
        /// <param name="tabName">This is page name.</param>
        [When(@"I click on 'Assign' button for ""(.*)"" in ""(.*)"" tab")]
        public void AssignAssetInManageCourse(Activity.ActivityTypeEnum activityType, 
            string tabName)
        {
            Logger.LogMethodEntry("CreateActivity", "AssignAssetInManageCourse",
            base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().ClickAssignOption(activityType,tabName);
            Logger.LogMethodExit("CreateActivity", "AssignAssetInManageCourse",
            base.IsTakeScreenShotDuringEntryExit);
        }


        [When(@"I click on 'Delete' button for ""(.*)"" in ""(.*)"" tab")]
        public void ClickOnButtonForInTab(Activity.ActivityTypeEnum activityType, 
            string pageTitle)
        {
            Logger.LogMethodEntry("CreateActivity", "AssignAssetInManageCourse",
            base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().ClickDeleteOption(activityType, pageTitle);
            Logger.LogMethodExit("CreateActivity", "AssignAssetInManageCourse",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="activityType"></param>
        /// <param name="pageName"></param>
        [Then(@"I should see ""(.*)"" status for ""(.*)"" in ""(.*)"" tab")]
        public void ValidateAssignmentStatus(string status, Activity.ActivityTypeEnum activityType, 
            string pageName)
        {
            Logger.LogMethodEntry("CreateActivity", "ValidateAssignmentStatus",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyNewActivityTypeName",
            ScenarioContext.Current.ScenarioInfo.Title,
            () => Assert.AreEqual(status,
                new CoursePreviewUXPage().GetAssignmentStatus(activityType, pageName)));
            Logger.LogMethodExit("CreateActivity", "ValidateAssignmentStatus",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the status message in course material page
        /// </summary>
        /// <param name="message">This is success message</param>
        /// <param name="pageName">This is page name.</param>
        [Then(@"I should see ""(.*)"" message in ""(.*)"" page")]
        public void ValidateStatusMessage(string message, string pageName)
        {
            Logger.LogMethodEntry("CreateActivity", "ValidateStatusMessage",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyNewActivityTypeName",
            ScenarioContext.Current.ScenarioInfo.Title,
            () => Assert.AreEqual(message,
                new CoursePreviewUXPage().GetSuccessMessage(pageName)));
            Logger.LogMethodExit("CreateActivity", "ValidateStatusMessage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on note icon in manage course material
        /// </summary>
        /// <param name="pageName">This is page name.</param>
        [When(@"I click on 'Note' icon in ""(.*)"" page")]
        public void ClickOnNoteIcon(string pageName)
        {
            Logger.LogMethodEntry("CreateActivity", "ClickOnNoteIcon",
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().ClickNoteIcon(pageName);
            Logger.LogMethodExit("CreateActivity", "ClickOnNoteIcon",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Edit button in Note lightbox
        /// </summary>
        [When(@"I click on 'Edit' button")]
        public void ClickEditButton()
        {
            Logger.LogMethodEntry("CreateActivity", "ClickOnNoteIcon",
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().ClickEditInNoteWindow();
            Logger.LogMethodExit("CreateActivity", "ClickOnNoteIcon",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of asset in My course frame 
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        /// <param name="pageName">This is page name.</param>
        [Then(@"I should be displayed with ""(.*)"" in ""(.*)"" frame")]
        public void ValidateTheDisplayOfAsset(Activity.ActivityTypeEnum activityType, 
            string pageName)
        {
            Logger.LogMethodEntry("CreateActivity", "ValidateTheDisplayOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyNewActivityTypeName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityName,
                    new CoursePreviewUXPage().
                    GetActivityInMyCourse(activityName, pageName)));
            Logger.LogMethodExit("CreateActivity", "ValidateTheDisplayOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of activity status
        /// </summary>
        /// <param name="status">This is activity status.</param>
        /// <param name="activityType">This is activity type enum.</param>
        [Then(@"I should be displayed with status ""(.*)"" for ""(.*)""")]
        public void ValidateDisplayOfActivityStatus(string status, Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("CreateActivity", "ValidateDisplayOfActivityStatus",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();
            //Assert we have correct page opened
            Logger.LogAssertion("ValidateDisplayOfActivityStatus",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(status,
                    new CoursePreviewUXPage().
                    GetActivityStatus(activityName, status)));
            Logger.LogMethodExit("CreateActivity", "ValidateDisplayOfActivityStatus",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate grades display in manage course material
        /// </summary>
        /// <param name="gradeTypeEnum">This is grade type enum.</param>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        /// <param name="pageName">This is page name.</param>
        [Then(@"I should see ""(.*)"" score for the activity ""(.*)"" in ""(.*)"" page")]
        public void ValidateTheGradesDisplayInManageCourseWork(Grade.GradeTypeEnum gradeTypeEnum, 
            Activity.ActivityTypeEnum activityTypeEnum, string pageName)
        {
            Logger.LogMethodEntry("CreateActivity", "ValidateTheGradesDisplayInManageCourseWork",
                base.IsTakeScreenShotDuringEntryExit);
            // Get the grade from inmemory
            Grade grade = Grade.Get(gradeTypeEnum);
            string gradeScore = grade.GradeScore.ToString();

            // Get activity name
            Activity activity = Activity.Get(activityTypeEnum);
            string activityName = activity.Name.ToString();

            //Assert we have correct page opened
            Logger.LogAssertion("ValidateDisplayOfActivityStatus",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(
                    new CoursePreviewUXPage().
                    GetGradeAndActivityStatus(gradeScore, activityName, pageName)));

            Logger.LogMethodExit("CreateActivity", 
                "ValidateTheGradesDisplayInManageCourseWork",
                base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Launch the asset by click on asset name.
        /// </summary>
        /// <param name="activityType">This ia activity type enum.</param>
        [When(@"I launch ""(.*)""")]
        public void StudentLaunchAsset(Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("CreateActivity", 
                "ValidateDisplayOfActivityStatus",
      base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();
            //Launch the asset by click on asset title
            new CoursePreviewUXPage().
                StudentLaunchAssetInCourseMaterials(activityName);
            Logger.LogMethodExit("CreateActivity", 
                "ValidateDisplayOfActivityStatus",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
