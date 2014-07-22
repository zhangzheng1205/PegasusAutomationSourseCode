using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.GraderIT.Tests.ProductAcceptanceTestDefinitions
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
        /// Search Asset In My Content Library.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralTypeEnum">This is Behavioral Type Enum.</param>
        [When(@"I search ""(.*)"" activity of behavioral mode ""(.*)"" type")]
        public void SearchAssetInContentLibrary(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralTypeEnum)
        {
            //Search Asset In Content Library Frame
            Logger.LogMethodEntry("CreateActivity", "SearchAssetInContentLibrary",
              base.isTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Fetch the activity from memory
           Activity activity = Activity.Get(activityTypeEnum, behavioralTypeEnum);
            //Select Window
            contentLibraryUXPage.SelectTheWindowName(CreateActivityResource.
                CreateActivity_CourseMaterials_Window_Title);
            //Select the frame
            contentLibraryUXPage.SelectAndSwitchtoFrame(CreateActivityResource.
                CreateActivity_CourseMaterials_Leftframe_Id_Locator);
            //Search Asset In Content Library Frame
            contentLibraryUXPage.SearchTheActivity(activity.Name);
            Logger.LogMethodExit("CreateActivity", " SearchAssetInContentLibrary",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Option of Activity
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option</param>
        [When(@"I select the Cmenu option ""(.*)""")]
        public void SelectCmenuOptionOfActivity(string cmenuOption)
        {
            //Select Cmenu Option of Activity
            Logger.LogMethodEntry("CreateActivity", "SelectCmenuOptionOfActivity",
               base.isTakeScreenShotDuringEntryExit);
            //Select Cmenu Option of Activity
            new ContentLibraryUXPage().SelectCmenuOptionOfActivity(cmenuOption);
            Logger.LogMethodExit("CreateActivity", "SelectCmenuOptionOfActivity",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create GraderIT Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Activity Behavioral mode type Enum.</param>
        [When(@"I create ""(.*)"" of grader activity of behavioral mode ""(.*)"" type using ""(.*)"" project in ""(.*)""")]
        public void CreateGraderITActivity(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum, String projectName,
            string tabName
            )
        
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
            autoGraderPage.CreateGraderITQuestionFromActivityAuthoring(
                Question.QuestionTypeEnum.SIM5GraderQuestion, projectName);
            //Click On SaveAndReturn Button
            addAssessmentPage.ClickOnSaveAndReturnButton();
            if (tabName == "MyCourse") {
                //Click On Add And Close Button
                new ContentBrowserUXPage().ClickOnAddAndCloseButton();
            }
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
        /// Search Asset In My Course.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralTypeEnum">This is Behavioral Type Enum.</param>
        [When(@"I search ""(.*)"" activity of behavioral mode ""(.*)"" type in Mycourse")]
        public void SearchAssetInMyCourse(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralTypeEnum)
        {
            //Search Asset In Content Library Frame
            Logger.LogMethodEntry("CreateActivity", "SearchAssetInContentLibrary",
              base.isTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Fetch the activity from memory
             Activity activity = Activity.Get(activityTypeEnum, behavioralTypeEnum);
            //Select Window
            contentLibraryUXPage.SelectTheWindowName(CreateActivityResource.
                CreateActivity_CourseMaterials_Window_Title);
            //Select the frame
            contentLibraryUXPage.SelectAndSwitchtoFrame(CreateActivityResource.
                CreateActivity_CourseMaterials_Rightframe_Id_Locator);
            //Search Asset In Content Library Frame
            contentLibraryUXPage.SearchTheActivity(activity.Name);
            Logger.LogMethodExit("CreateActivity", " SearchAssetInContentLibrary",
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
            contentLibraryUXPage.SelectLeftFrame();
            // Select the activity
            contentLibraryUXPage.SelectActivity(activity.Name);
            // Click on Activity Add Button
            contentLibraryUXPage.ClickOnActivityAddButton();
            Logger.LogMethodExit("CreateActivity",
                "AssociateTheActivityFromContentLibraryToMyCourse",
                isTakeScreenShotDuringEntryExit);
        }
    }

}
