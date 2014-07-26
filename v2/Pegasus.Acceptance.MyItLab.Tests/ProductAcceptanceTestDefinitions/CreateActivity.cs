﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
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
        private static Logger Logger =
            Logger.GetInstance(typeof(CreateActivity));


        /// <summary>
        /// Click On Add Course Materials Option. 
        /// </summary>
        [When(@"I select 'Add Course Materials' in 'My Course'")]
        public void ClickOnAddCourseMaterialsOption()
        {
            //Click On Add Course Materials Option
            Logger.LogMethodEntry("CreateActivity", "ClickOnAddCourseMaterialsOption",
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
            new ContentLibraryUXPage().ClickOnAddCourseMaterialsLink();
            Logger.LogMethodExit("CreateActivity", "ClickOnAddCourseMaterialsOption",
                base.isTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Click On Activity Type.
        /// </summary>
        /// <param name="activityType">This is Activity Type.</param>
        [When(@"I click on the ""(.*)"" activity type")]
        public void ClickOnActivityType(String activityType)
        {
            //Click On The Activity Type
            Logger.LogMethodEntry("CreateActivity", "ClickOnTheActivityType",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Activity Type
            new ContentLibraryUXPage().ClickOnActivityType(activityType);
            Logger.LogMethodExit("CreateActivity", "ClickOnTheActivityType",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Activity of Behavioral Mode
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum</param>
        /// <param name="behavioralModeEnum">This is behavioral mode enum</param>
        [When(@"I create ""(.*)"" activity of behavioral mode ""(.*)"" type")]
        public void CreateActivityOfBehavioralModeType(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create Activity
            Logger.LogMethodEntry("CreateActivity", "CreateActivityOfBehavioralModeType",
               base.isTakeScreenShotDuringEntryExit);
            //Create Activity
            new AddAssessmentPage().CreateActivity(activityTypeEnum, behavioralModeEnum);
            Logger.LogMethodExit("CreateActivity", "CreateActivityOfBehavioralModeType",
                base.isTakeScreenShotDuringEntryExit);
        }

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
               base.isTakeScreenShotDuringEntryExit);
            //Enter Activity Details and Click on Add Question Link
            new AddAssessmentPage().EnterActivityDetailsandClickonAddQuestion(activityTypeEnum);
            //Create Activity
            new AddAssessmentPage().CreateTheInstructorGradableActivity(
                activityTypeEnum);
            Logger.LogMethodExit("CreateActivity", "CreateInstructorGradableActivity",
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
            //Create SIM Activity
            new AddAssessmentPage().CreateSIMActivity(activityTypeEnum, behavioralModeEnum);
            Logger.LogMethodExit("CreateActivity",
                "CreateSIMActivityOfBehavioralModeType",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On ShowHide Status Option.
        /// </summary>
        [When(@"I click on 'ShowHide' option of Activity")]
        public void ClickOnShowHideStatusOption()
        {
            //Click On ShowHide Status Option
            Logger.LogMethodEntry("CreateActivity", "ClickOnShowHideStatusOption",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Activity Type
            new CourseContentUXPage().ClickTheShowHideStatusOption();
            Logger.LogMethodExit("CreateActivity", "ClickOnShowHideStatusOption",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Create SIM Studyplan
            new SIMStudyPlanDefaultUXPage().CreateSIMStudyPlan(
                activityTypeEnum, behavioralModeEnum);
            Logger.LogMethodExit("CreateActivity", "CreateSIMStudyplan",
               base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            //Search SIM Study Plan activity
            new CourseContentUXPage().GetActivityName(activity.Name);
            //Logger Exit
            Logger.LogMethodExit("CreateActivity", "SeeActivityInTheContentLibraryFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on cmenu of activity.
        /// </summary>
        /// <param name="cmenuOptionName">This is cmenu name.</param>
        /// <param name="userTypeEnum">This is User type enum.</param>
        [When(@"I click on ""(.*)"" cmenu option of activity in ""(.*)""")]
        public void ClickOnCmenuOptionOfActivity(string cmenuOptionName,
            User.UserTypeEnum userTypeEnum )
        {
            //Logger Entry
            Logger.LogMethodEntry("CreateActivity", "ClickOnCmenuOptionOfActivity",
               base.isTakeScreenShotDuringEntryExit);
            //Click on Cmenu image of activity
            new CourseContentUXPage().ClickTheActivityCmneuImageIcon();
            //Click on cmenu option of activity
            new CourseContentUXPage().ClickTheCmenuOptionofActivity(cmenuOptionName);
            //Logger Exit
            Logger.LogMethodExit("CreateActivity", "ClickOnCmenuOptionOfActivity",
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
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);    
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Course Materials Link.
        /// </summary>        
        [When(@"I click on the 'Add Course Materials' option")]
        public void ClickOnAddCourseMaterialsLink()
        {
            //Click On Add Course Materials Link
            Logger.LogMethodEntry("CreateActivity", "ClickOnAddCourseMaterialsLink",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Add Course Materials Option
            new CourseContentUXPage().ClickOnAddCourseMaterialsOption();
            Logger.LogMethodExit("CreateActivity", "ClickOnAddCourseMaterialsLink",
                base.isTakeScreenShotDuringEntryExit);
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
                        base.isTakeScreenShotDuringEntryExit);
            //Create The NonGradable Activity.
            new CourseContentUXPage().CreateTheNonGradableActivity(activityTypeEnum);
            Logger.LogMethodExit("CreateActivity",
                "CreateTheNonGradableActivity",
                      base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Gets the Activity name from Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetActivityName(activity.Name)));
            Logger.LogMethodExit("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Gets the Activity name from Memory
            Activity activity = Activity.Get(activityTypeEnum,behavioralmode);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetActivityName(activity.Name)));
            Logger.LogMethodExit("CreateActivity", "DisplayOfActivityInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Click On Cmenu of Activity
            new CourseContentUXPage().ClickOnCmenuofActivity(cmenuOption);
            Logger.LogMethodExit("CreateActivity", "ClickTheCmenuofActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign The Activity In Mycourse.
        /// </summary>
        [When(@"I assign the activity in mycourse")]
        public void AssignTheActivityInMycourse()
        {
            //Assign The Activity In Mycourse
            Logger.LogMethodEntry("CreateActivity", "AssignTheActivityInMycourse",
               base.isTakeScreenShotDuringEntryExit);
            //Assign The Activity In course content
            new CourseContentUXPage().AssignTheActivityInCourseContent();
            Logger.LogMethodExit("CreateActivity", "AssignTheActivityInMycourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Feedback Preference.
        /// </summary>
        [When(@"I set the feedback preference")]
        public void SetTheFeedbackPreference()
        {
            //Set Feedback Preference
            Logger.LogMethodEntry("CreateActivity", "SetTheFeedbackPreference",
               base.isTakeScreenShotDuringEntryExit);
            //Enable Feedback 'Never' Preference
            new SkillBasedAssessmentPage().EnableFeedbackNeverPreference();
            Logger.LogMethodExit("CreateActivity", "SetTheFeedbackPreference",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set The Feedback for Correct Answer Preference
        /// </summary>
        [When(@"I set the feedback correct answer preference")]
        public void SetTheFeedbackCorrectAnswerPreference()
        {
            //Set The feedback for correct Answer preference
            Logger.LogMethodEntry("CreateActivity", "SetTheFeedbackCorrectAnswerPreference",
               base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Add Course Materials Link in Content Library.
        /// </summary>        
        [When(@"I click on the 'Add Course Materials' option in Content Library")]
        public void ClickOnAddCourseMaterialsLinkInContentLibrary()
        {
            //Click On Add Course Materials Link
            Logger.LogMethodEntry("CreateActivity", "ClickOnAddCourseMaterialsLinkInContentLibrary",
                base.isTakeScreenShotDuringEntryExit);

            //Click On Add Course Materials Option
            new ContentLibraryUXPage().ClickOnAddCourseMaterialsOptioninContentLibrary();

            Logger.LogMethodExit("CreateActivity", "ClickOnAddCourseMaterialsLinkInContentLibrary",
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter The Necessary Details Begin Creation Of Assignment Behavioral Type.
        /// </summary>
        [When(@"I enter the necessary details begin creation of Assignment behavioral type")]
        public void EnterTheNecessaryDetailsBeginCreationOfAssignmentBehavioralType()
        {
            Logger.LogMethodEntry("CommonSteps",
                "EnterTheNecessaryDetailsBeginCreationOfAssignmentBehavioralType",
                isTakeScreenShotDuringEntryExit);

            new AddAssessmentPage().EnterAssignmentActivityDetailsandClickSaveandContinue();

            Logger.LogMethodExit("CommonSteps",
                "EnterTheNecessaryDetailsBeginCreationOfAssignmentBehavioralType",
                isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On The Messages Activity Sub-tab.
        /// </summary>
        [When(@"I click on the Messages activity subtab")]
        public void ClickOnTheMessagesActivitySubtab()
        {
            Logger.LogMethodEntry("CommonSteps",
                "ClickOnTheMessagesActivitySubtab",
                isTakeScreenShotDuringEntryExit);

            new AddAssessmentPage().ClickonMessageTab();

            Logger.LogMethodExit("CommonSteps",
                "ClickOnTheMessagesActivitySubtab",
                isTakeScreenShotDuringEntryExit);
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
                isTakeScreenShotDuringEntryExit);

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
                isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify New Activity Type In The Add Course Materials Menu.
        /// </summary>
        /// <param name="activityTypeName">Activity Type Name</param>
        [Then(@"I should see the ""(.*)"" activity type in the Add Course Materials menu")]
        public void VerifyNewActivityTypeInTheAddCourseMaterialsMenu(string activityTypeName)
        {
            Logger.LogMethodEntry("CommonSteps", "VerifyNewActivityTypeInTheAddCourseMaterialsMenu",
                isTakeScreenShotDuringEntryExit);

            //Assert we have correct page opened
            Logger.LogAssertion("VerifyNewActivityTypeName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityTypeName,
                    new ContentLibraryUXPage().
                    VerifyNewActivityType(activityTypeName)));

            Logger.LogMethodExit("CommonSteps", "VerifyNewActivityTypeInTheAddCourseMaterialsMenu",
                isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);

            //Enter Activity Details and Click on Add Question Link
            new AddAssessmentPage().EnterActivityDetailsandClickonAddQuestion(activityTypeEnum);
            //Create Activity
            new AddAssessmentPage().CreateActivityWithHelpLinks(activityTypeEnum);

            Logger.LogMethodExit("CreateActivity", 
                "CreateBasicRandomActivityUsingTrueandFalseQuestionAndHelpLinks",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
