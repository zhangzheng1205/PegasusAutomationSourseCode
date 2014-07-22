using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Integration.SIM5.SIM5Services.SIM5ContentBrowse;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles the Create Question action
    /// </summary>
    [Binding]
    public class CreateQuestion : PegasusBaseTestFixture
    {

        /// <summary>
        /// This is the logger
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
        /// Select Option In Course Materials.
        /// </summary>
        /// <param name="assetType">This is Asset Type</param>
        [When(@"I select ""(.*)"" option")]
        public void SelectOption(string assetType)
        {
            //Select Option In Course Materials
            Logger.LogMethodEntry("CreateQuestion", "SelectOption",
                base.isTakeScreenShotDuringEntryExit);
            //Select Option In Course Materials
            new QlGridUXPage().SelectOptionInCourseMaterials(assetType);
            Logger.LogMethodExit("CreateQuestion", "SelectOption",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Question Folder From SIM Repository.
        /// </summary>
        [When(@"I add the question folder from sim repository")]
        public void AddTheQuestionFolderFromSimRepository()
        {
            Logger.LogMethodEntry("CreateQuestion", "AddTheQuestionFolderFromSimRepository",
                base.isTakeScreenShotDuringEntryExit);
            //Select Question Folder
            new SIMRepositoryPage().AddQuestionFolder();
            Logger.LogMethodExit("CreateQuestion", "AddTheQuestionFolderFromSimRepository",
               base.isTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Verify The Created Question.
        /// </summary>
        /// <param name="questionName">This is Question Name</param>
        [Then(@"I should see the added question ""(.*)""")]
        public void VerifyTheCreatedQuestion(String questionName)
        {
            // Verify The Created Question Folder
            Logger.LogMethodEntry("CreateQuestion", "VerifyTheCreatedQuestion",
                 base.isTakeScreenShotDuringEntryExit);           
            //Assert Created Question 
            Logger.LogAssertion("VerifyTheCreatedQuestion", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(true,
                     new QlGridUXPage().GetSearchedFolderName(questionName).
                    Contains(questionName)));
            Logger.LogMethodExit("CreateQuestion", "VerifyTheCreatedQuestion",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Option Of Question
        /// </summary>
        /// <param name="cmenuOption">This Cmenu Option</param>
        /// <param name="questionName">This is Question Name</param>
        [When(@"I select cmenu ""(.*)"" option for question ""(.*)""")]
        public void SelectCmenuOption(string cmenuOption, String questionName)
        {
            //Click On Cmenu Option of Asset
            Logger.LogMethodEntry("CreateQuestion", "SelectCmenuOption",
                 base.isTakeScreenShotDuringEntryExit);
            //Click On Cmenu Option of Asset
            new QlGridUXPage().ClickOnCmenuOfAsset(questionName, cmenuOption);
            Logger.LogMethodExit("CreateQuestion", "SelectCmenuOption",
              base.isTakeScreenShotDuringEntryExit);
            
        }

        /// <summary>
        /// Create Grader IT Question In Manage Question Bank.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        /// <param name="projectName">This is Project Name.</param>
        [When(@"I create ""(.*)"" grader IT Question using ""(.*)"" project")]
        public void CreateGraderITQuestionInManageQuestionBank(
            Question.QuestionTypeEnum questionTypeEnum, String projectName)
        {
            // Create Grader IT Question In Manage Question Bank
            Logger.LogMethodEntry("CreateQuestion", 
                "CreateGraderITQuestionInManageQuestionBank",
                 base.isTakeScreenShotDuringEntryExit);
            //Create The GraderIT Question In Manage Question Bank
            new AutoGraderPage().
                CreateTheGraderITQuestionInManageQuestionBank(questionTypeEnum,projectName);
            Logger.LogMethodExit("CreateQuestion", 
                "CreateGraderITQuestionInManageQuestionBank",
              base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Add SIM Question 2010 from SIM Repository.
        /// </summary>
        /// <param name="simQuestionFolderName">SIM Question folder name.</param>
        [When(@"I Added ""(.*)"" SIM question from SIM Repository")]
        public void AddSIMQuestionFromSIMRepository(string simQuestionFolderName)
        {
            //Logger Entry
            Logger.LogMethodEntry("CreateQuestion",
                "AddSIMQuestionFromSIMRepository",
                 base.isTakeScreenShotDuringEntryExit);
            //Add SIM question from Repository
            new ContentBrowserUXPage().SelectSIMQuestionFolder(simQuestionFolderName);
            //Logger Exit
            Logger.LogMethodExit("CreateQuestion",
                "AddSIMQuestionFromSIMRepository",
              base.isTakeScreenShotDuringEntryExit);
           
        }

        /// <summary>
        /// Validate the availability of added SIM Question Folder from Repository.
        /// </summary>
        /// <param name="simQuestionFolderName">This is name of Question Folder</param>
        [Then(@"I should see the ""(.*)"" SIM question folder into question bank frame")]
        public void VerifyTheSIMQuestionFolderInQuestionBankFrame(Question.QuestionTypeEnum questionTypeEnum)
        {
            //Logger Entry
            Logger.LogMethodEntry("CreateQuestion",
                "VerifyTheSIMQuestionFolderInQuestionBankFrame",
                 base.isTakeScreenShotDuringEntryExit);
            Question questionSetName = Question.Get(questionTypeEnum);
            //Assert Created Question 
            Logger.LogAssertion("VerifyTheSIMQuestionFolderInQuestionBankFrame", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(true,
                     new QlGridUXPage().GetSearchedFolderName(questionSetName.Name).
                    Contains(questionSetName.Name)));
            //Logger Exit
            Logger.LogMethodExit("CreateQuestion",
                "VerifyTheSIMQuestionFolderInQuestionBankFrame",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Option Of Question.
        /// </summary>
        /// <param name="questionCmenuOption">This is Question Cmenu Option.</param>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        [When(@"I click on ""(.*)"" cmenu option of ""(.*)"" question in manage question bank")]
        public void ClickOnCmenuOptionOfQuestion(string questionCmenuOption,
            Question.QuestionTypeEnum questionTypeEnum)
        {
            //Click On Cmenu Option Of Question In Manage Question Bank
            Logger.LogMethodEntry("CreateQuestion", "ClickOnCmenuOptionOfQuestion"
              , base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Question question = Question.Get(questionTypeEnum);
            //Click On Cmenu Option Of Question
            new QlGridUXPage().ClickOnCmenuOfQuestion(question.Name, questionCmenuOption);
            Logger.LogMethodExit("CreateQuestion", "ClickOnCmenuOptionOfQuestion"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Question Edit Page.
        /// </summary>
        [Then(@"I should be on the edit page")]
        public void VerifyTheQuestionEditPage()
        {
            //Verify The Question Edit Page
            Logger.LogMethodEntry("CreateQuestion", "VerifyTheQuestionEditPage"
              , base.isTakeScreenShotDuringEntryExit);
            //Asserts To Verify The Question Edit Page
            Logger.LogAssertion("VerifyQuestionEditPage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new AutoGraderPage().IsQuestionTitleTextboxPresent()));
            Logger.LogMethodExit("CreateQuestion", "VerifyTheQuestionEditPage"
                , base.isTakeScreenShotDuringEntryExit);
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
            //Logger Exit
            Logger.LogMethodExit("CreateQuestion", "CreateQuestions",
                       base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create 2010 SIM Question set with specific question type. 
        /// </summary>
        /// <param name="questionType">This is question type enum.</param>
        [When(@"I Craeted Question Set with ""(.*)"" question type")]
        public void CraetedSIMQuestionSetWithQuestionType(Question.
            QuestionTypeEnum questionTypeEnum)
        {
           //Logger Entry
            Logger.LogMethodEntry("CreateQuestion",
                "CraetedSIMQuestionSetWithQuestionType",
                base.isTakeScreenShotDuringEntryExit);
            //Create 2010 SIM Questions set 
            new QuestionSetPage().CreateSIMQuestionsSet(questionTypeEnum);
            //Logger Exit
            Logger.LogMethodExit("CreateQuestion", 
                "CraetedSIMQuestionSetWithQuestionType",
                       base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Update The Question Set With QuestionType.
        /// </summary>
        /// <param name="questionTypeEnum">This is question type enum.</param>
        [When(@"I update the Question Set with ""(.*)"" question type")]
        public void UpdateTheQuestionSetWithQuestionType(Question.
            QuestionTypeEnum questionTypeEnum)
        {
            //Logger Entry
            Logger.LogMethodEntry("CreateQuestion",
                "UpdateTheQuestionSetWithQuestionType",
                base.isTakeScreenShotDuringEntryExit);
            //Edit the SIM Questions set 
            new QuestionSetPage().UpdateTheSIMQuestionsSet(questionTypeEnum);
            //Logger Exit
            Logger.LogMethodExit("CreateQuestion",
                "UpdateTheQuestionSetWithQuestionType",
                       base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Question.
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option.</param>
        /// <param name="questionName">This is Question Name.</param>
        [When(@"I click on ""(.*)"" cmenu option of ""(.*)"" question")]
        public void ClickOnCmenuOfQuestion(string cmenuOption, string questionName)
        {
            //Click On Cmenu Of Question
            Logger.LogMethodEntry("CreateQuestion", "ClickOnCmenuOfQuestion",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Cmenu Option Of Question
            new QlGridUXPage().ClickOnCmenuOfQuestion(questionName, cmenuOption);
            Logger.LogMethodExit("CreateQuestion", "ClickOnCmenuOfQuestion",
                      base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Point Value For The Added Question.
        /// </summary>
        /// <param name="pointValue">This is Set Point Value.</param>       
        [When(@"I set the point value ""(.*)"" for the added question")]
        public void SetPointValueForTheAddedQuestion(string pointValue)
        {
            //Set Point Value For The Added Question
            Logger.LogMethodEntry("CreateQuestion", "SetPointValueForTheAddedQuestion",
                base.isTakeScreenShotDuringEntryExit);
            //Set Point Value For Question
            new SimQuestionPointValuePage().
                SetPointValueForQuestion(pointValue);
            Logger.LogMethodExit("CreateQuestion", "SetPointValueForTheAddedQuestion",
                      base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Question Point Value.
        /// </summary>
        /// <param name="pointValue">This is Set Point Value.</param>
        /// <param name="questionName">This is Question Name.</param>
        [Then(@"I should see the point value ""(.*)"" for the added question ""(.*)""")]
        public void VerifyTheQuestionPointValue(string pointValue, string questionName)
        {
            //Verify The Question Point Value
            Logger.LogMethodEntry("CreateQuestion", "VerifyTheQuestionPointValue",
                base.isTakeScreenShotDuringEntryExit);
            //Asserts To Verify The Question Point Value
            Logger.LogAssertion("VerifyQuestionPointValue",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(pointValue,
                    new SimQuestionPointValuePage().GetQuestionPointValue(questionName)));
            Logger.LogMethodExit("CreateQuestion", "VerifyTheQuestionPointValue",
                      base.isTakeScreenShotDuringEntryExit);
        }

    }
}
