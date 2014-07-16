using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class handles the Creation Question actions.
    /// </summary>
    [Binding]
    public class CreateQuestion : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(CreateQuestion));

        /// <summary>
        /// Select Add Course Materials Button.
        /// </summary>        
        [When(@"I select 'Add Course Materials' option")]
        public void SelectAddCourseMaterialsOption()
        {
            //Select Add Course Materails Button
            Logger.LogMethodEntry("CreateQuestion", 
                "SelectAddCourseMaterialsOption",
                base.isTakeScreenShotDuringEntryExit);
            //Select Add Course Materials Button
            new QlGridUXPage().SelectAddCourseMaterialsButton();
            Logger.LogMethodExit("CreateQuestion", 
                "SelectAddCourseMaterialsOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question Type.
        /// </summary>
        /// <param name="questionType">This is Question Type.</param>
        [When(@"I select ""(.*)"" question type")]
        public void SelectQuestionType(String questionType)
        {
            //Select Question Type
            Logger.LogMethodEntry("CreateQuestion", "SelectQuestionType",
                base.isTakeScreenShotDuringEntryExit);
            //Select Question Type
            new QlGridUXPage().SelectQuestionType(questionType);
            Logger.LogMethodExit("CreateQuestion", "SelectQuestionType",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Questions.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        [When(@"I create ""(.*)"" question")]
        public void CreateQuestions(
            Question.QuestionTypeEnum questionTypeEnum)
        {
            //Create Questions
            Logger.LogMethodEntry("CreateQuestion", "CreateQuestions",
                base.isTakeScreenShotDuringEntryExit);
            //Create Questions
            new QlGridUXPage().CreateQuestions(questionTypeEnum);
            Logger.LogMethodExit("CreateQuestion", "CreateQuestions",
                       base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Action Row ClipBoard Items.
        /// </summary>
        [Then(@"I should see the 'Delete','Copy','Cut','Paste','Reports' action row options")]
        public void VerifyTheActionRowClipBoardItems()
        {
            //Verify The Action Row ClipBoard Items
            Logger.LogMethodEntry("CreateQuestion", "VerifyTheActionRowClipBoardItems",
              base.isTakeScreenShotDuringEntryExit);
            //Assert Display Of Action Row ClipBoard Items
            Logger.LogAssertion("VerifyActionRowOptions",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(CreateQuestionResource.
                    CreateQuestion_DeleteCopyCutPasteReports_Appended_Text,
                    new QlGridUXPage().GetClipBoardItemsTextDisplayed()));
            Logger.LogMethodExit("CreateQuestion", "VerifyTheActionRowClipBoardItems",
               base.isTakeScreenShotDuringEntryExit);  
        }

        /// <summary>
        /// Select The Question From QuestionBank.
        /// </summary>
        /// <param name="questionName">This is Question Name.</param>
        [When(@"I select the ""(.*)"" question from question bank")]
        public void SelectTheQuestionFromQuestionBank(string questionName)
        {
            //Select The Question From QuestionBank
            Logger.LogMethodEntry("CreateQuestion", "SelectTheQuestionFromQuestionBank",
              base.isTakeScreenShotDuringEntryExit);
            //Select The Question From QuestionBank
            new QlGridUXPage().SelectTheQuestionFromQuestionBank(questionName);
            Logger.LogMethodExit("CreateQuestion", "SelectTheQuestionFromQuestionBank",
               base.isTakeScreenShotDuringEntryExit);  
        }

        /// <summary>
        /// Create Question Folder.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        [When(@"I create question ""(.*)""")]
        public void CreateQuestionFolder(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create Question Folder
            Logger.LogMethodEntry("CreateQuestion", "CreateQuestionFolder",
                base.isTakeScreenShotDuringEntryExit);
            // Create Folder
            new AddFolderPage().CreateTheFolder(activityTypeEnum);
            Logger.LogMethodExit("CreateQuestion", "CreateQuestionFolder",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select Option In Course Materials.
        /// </summary>
        /// <param name="assetType">This is Asset Type.</param>
        [When(@"I select ""(.*)"" option")]
        public void SelectOption(string option)
        {
            //Select Option In Course Materials
            Logger.LogMethodEntry("CreateQuestion", "SelectOption",
                base.isTakeScreenShotDuringEntryExit);
            //Select Option In Course Materials
            new QlGridUXPage().SelectOptionInCourseMaterials(option);
            Logger.LogMethodExit("CreateQuestion", "SelectOption",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Created Question Folder.
        /// </summary>
        /// <param name="activityTypeEnum">Activity Type Enum.</param>
        [Then(@"I should see the created question ""(.*)""")]
        public void VerifyTheCreatedQuestionFolder(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Verify The Created Question Folder
            Logger.LogMethodEntry("CreateQuestion", "VerifyTheCreatedQuestionFolder",
                 base.isTakeScreenShotDuringEntryExit);
            //Fetch Folder from Memory
            Activity getFolder = Activity.Get(Activity.ActivityTypeEnum.Folder);
            //Assert Created Question Folder
            Logger.LogAssertion("VerifyTheCreatedQuestionFolder",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                   Assert.AreEqual(getFolder.Name, new QlGridUXPage().
                   GetSearchedFolderName(getFolder.Name)));            
            Logger.LogMethodExit("CreateQuestion", "VerifyTheCreatedQuestionFolder",
              base.isTakeScreenShotDuringEntryExit);
        }
      
        /// <summary>
        /// Verify The ClipBoard Options Enabled.
        /// </summary>
        [Then(@"I should see 'Delete','Copy','Cut' options should get enabled")]
        public void VerifyTheClipBoardOptionsEnabled()
        {
            // Verify The ClipBoard Options Enabled
            Logger.LogMethodEntry("CreateQuestion", "VerifyTheClipBoardOptionsEnabled",
              base.isTakeScreenShotDuringEntryExit);
            //Assert for Verify The ClipBoard Options Enabled.
            Logger.LogAssertion("VerifyActionRowOptionsEnabled",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new QlGridUXPage().IsClipBoardItemsGetEnabledState()));
            Logger.LogMethodExit("CreateQuestion", "VerifyTheClipBoardOptionsEnabled",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Paste Options Get Enabled
        /// </summary>
        [Then(@"I should see 'Paste' options should get enabled")]
        public void VerifyThePasteOptionsGetEnabled()
        {
            //Verify The Paste Options Get Enabled
            Logger.LogMethodEntry("CreateQuestion", "VerifyThePasteOptionsGetEnabled",
              base.isTakeScreenShotDuringEntryExit);
            //Assert Display Of paste options get enabled
            Logger.LogAssertion("VerifyPasteOptionsEnabledState",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new QlGridUXPage().IsPasteOptionGetDisplayedEnabledState()));
            Logger.LogMethodExit("CreateQuestion", "VerifyThePasteOptionsGetEnabled",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Copy Clipboard Option
        /// </summary>
        [When(@"I click on the 'Copy' clipboard option")]
        public void ClickTheCopyClipboardOption()
        {
            // Click On Copy Clipboard Option
            Logger.LogMethodEntry("CreateQuestion", "ClickTheCopyClipboardOption",
              base.isTakeScreenShotDuringEntryExit);
            //Click On Copy Clipboard Option
            new QlGridUXPage().ClickOnCopyClipboardOption();
            Logger.LogMethodExit("CreateQuestion", "ClickTheCopyClipboardOption",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Folder In Question Bank.
        /// </summary>
        /// <param name="folderName">This is Folder Name</param>       
        [When(@"I navigate to folder ""(.*)""")]
        public void NavigateToFolderInQuestionBank(string folderName)
        {
            //Navigate To Folder In Question Bank
            Logger.LogMethodEntry("CreateQuestion", "NavigateToFolderInQuestionBank",
              base.isTakeScreenShotDuringEntryExit);
            //Navigate to Folder
            new QlGridUXPage().ClickOnTheQuestionFolder(folderName);
            Logger.LogMethodExit("CreateQuestion", "NavigateToFolderInQuestionBank",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Score For Questions In Folder Level.
        /// </summary>  
        /// <param name="score">This is Score</param>
        /// <param name="folderName">This is Folder Name</param>
        /// <param name="folderCmenuOption">This is Folder Cmenu Option</param>
        [When(@"I set the score ""(.*)"" for questions in ""(.*)"" folder using ""(.*)""")]
        public void SetScoreForQuestionsInFolderLevel
            (string score,string folderName,string folderCmenuOption)
        {
            //Set Score For Questions In Folder Level
            Logger.LogMethodEntry("CreateQuestion", "SetScoreForQuestionsInFolderLevel",
              base.isTakeScreenShotDuringEntryExit);
            QlGridUXPage qlGridUXPage = new QlGridUXPage();
            //Click On Cmenu Of Folder
            qlGridUXPage.ClickOnCmenuOfAsset(folderName, folderCmenuOption);
            //Set Score For Questions
            qlGridUXPage.SetScoreForQuestions(score);
            Logger.LogMethodExit("CreateQuestion", "SetScoreForQuestionsInFolderLevel",
               base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Verify The Updated Score Of Question.
        /// </summary>
        /// <param name="score">This is Score</param>
        /// <param name="questionName">This is Question Name</param>
        /// <param name="folderName">This is Folder Name</param>
        [Then(@"I should see the updated score ""(.*)"" for question ""(.*)"" in ""(.*)"" folder")]
        public void VerifyTheUpdatedScoreOfQuestion
            (string score,string questionName, string folderName)
        {
            //Verify The Updated Score Of Question
            Logger.LogMethodEntry("CreateQuestion", "VerifyTheUpdatedScoreOfQuestion",
              base.isTakeScreenShotDuringEntryExit);
            QlGridUXPage qlGridUXPage = new QlGridUXPage();
            //Click on Folder
            qlGridUXPage.ClickOnTheQuestionFolder(folderName);
            //Click On Cmenu of Asset
            qlGridUXPage.ClickOnCmenuOfAsset(questionName,
                CreateQuestionResource.CreateQuestion_Question_Edit_Cmenu_Value);
            //Assert Score of Question in Folder
            Logger.LogAssertion("VerifyTheUpdatedScoreOfQuestion",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                   Assert.IsTrue(new MultipleChoicePage().IsUpdatedScoreCorrect(score)));
            Logger.LogMethodExit("CreateQuestion", "VerifyTheUpdatedScoreOfQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Map Question To Skill.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        [When(@"I map ""(.*)"" question to skill")]
        public void MapQuestionToSkill(Question.QuestionTypeEnum questionTypeEnum)
        {
            //Map Question To Skill
            Logger.LogMethodEntry("CreateQuestion", "MapQuestionToSkill",
              base.isTakeScreenShotDuringEntryExit);
            //Fetch Question From Memory
            Question question = Question.Get(questionTypeEnum);
            //Map Question To Skill
            new SkillStandardAlignedAssetsUXPage().MapQuestionToTheSkill(question.Name);
            Logger.LogMethodExit("CreateQuestion", "MapQuestionToSkill",
               base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Create Essay Audio Questions.
        /// </summary>        
        [When(@"I create 'Essay audio' question type")]
        public void CreateAudioEssayQuestionType()
        {
            //Create Audio Essay Questions
            Logger.LogMethodEntry("CreateQuestion", "CreateAudioEssayQuestionType",
                base.isTakeScreenShotDuringEntryExit);
            //Create Audio Essay Questions
            new EssayPage().CreateAudioEssayQuestions();
            Logger.LogMethodExit("CreateQuestion", "CreateAudioEssayQuestionType",
                       base.isTakeScreenShotDuringEntryExit);
        }
                
        /// <summary>
        /// This method is called before execution of test.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// This function is called after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
