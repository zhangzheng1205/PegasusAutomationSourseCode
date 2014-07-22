using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Collections.Generic;
using System.Linq;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Text;
using Pegasus.Automation.DataTransferObjects;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Acceptance.NovaNET.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles the Activity Creation Actions.
    /// </summary>
    [Binding]
    public class CreateActivity : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CreateActivity));

        /// <summary>
        /// Select Asset Type From Add Content Link.
        /// </summary>
        /// <param name="optionName">This is Asset Type.</param>
        [When(@"I select on the ""(.*)"" from add content link")]
        public void SelectAssetTypeFromAddContentLink(string optionName)
        {
            //Select Asset Type From Add Content Link
            Logger.LogMethodEntry("CreateActivity", 
                "SelectAssetTypeFromAddContentLink",
                base.isTakeScreenShotDuringEntryExit);
            //Click on Add Content Button Options
            new ContentLibraryUXPage().ClickOnAddContentOption(optionName);
            Logger.LogMethodExit("CreateActivity", 
                "SelectAssetTypeFromAddContentLink",
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
    }
}
