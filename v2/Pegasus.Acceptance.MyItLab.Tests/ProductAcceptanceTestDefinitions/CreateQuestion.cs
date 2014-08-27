using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Integration.SIM5.SIM5Services.SIM5ContentBrowse;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
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
                base.IsTakeScreenShotDuringEntryExit);
            //Select Add Course Materials Button
            new QlGridUXPage().SelectAddCourseMaterialsButton();
            Logger.LogMethodExit("CreateQuestion",
                "SelectAddCourseMaterialsOption",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Select Question Type
            new QlGridUXPage().SelectQuestionType(questionType);
            Logger.LogMethodExit("CreateQuestion", "SelectQuestionType",
               base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Select Option In Course Materials
            new QlGridUXPage().SelectOptionInCourseMaterials(assetType);
            Logger.LogMethodExit("CreateQuestion", "SelectOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Question Folder From SIM Repository.
        /// </summary>
        [When(@"I add the question folder from sim repository")]
        public void AddTheQuestionFolderFromSimRepository()
        {
            Logger.LogMethodEntry("CreateQuestion", "AddTheQuestionFolderFromSimRepository",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Question Folder
            new SIMRepositoryPage().AddQuestionFolder();
            Logger.LogMethodExit("CreateQuestion", "AddTheQuestionFolderFromSimRepository",
               base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
            //Assert Created Question 
            Logger.LogAssertion("VerifyTheCreatedQuestion", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(true,
                     new QlGridUXPage().GetSearchedFolderName(questionName).
                    Contains(questionName)));
            Logger.LogMethodExit("CreateQuestion", "VerifyTheCreatedQuestion",
              base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
            //Click On Cmenu Option of Asset
            new QlGridUXPage().ClickOnCmenuOfAsset(questionName, cmenuOption);
            Logger.LogMethodExit("CreateQuestion", "SelectCmenuOption",
              base.IsTakeScreenShotDuringEntryExit);

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
                 base.IsTakeScreenShotDuringEntryExit);
            //Create The GraderIT Question In Manage Question Bank
            new AutoGraderPage().
                CreateTheGraderITQuestionInManageQuestionBank(questionTypeEnum, projectName);
            Logger.LogMethodExit("CreateQuestion",
                "CreateGraderITQuestionInManageQuestionBank",
              base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
            //Add SIM question from Repository
            new ContentBrowserUXPage().SelectSIMQuestionFolder(simQuestionFolderName);
            //Logger Exit
            Logger.LogMethodExit("CreateQuestion",
                "AddSIMQuestionFromSIMRepository",
              base.IsTakeScreenShotDuringEntryExit);

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
                 base.IsTakeScreenShotDuringEntryExit);
            Question questionSetName = Question.Get(questionTypeEnum);
            //Assert Created Question 
            Logger.LogAssertion("VerifyTheSIMQuestionFolderInQuestionBankFrame", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(true,
                     new QlGridUXPage().GetSearchedFolderName(questionSetName.Name).
                    Contains(questionSetName.Name)));
            //Logger Exit
            Logger.LogMethodExit("CreateQuestion",
                "VerifyTheSIMQuestionFolderInQuestionBankFrame",
              base.IsTakeScreenShotDuringEntryExit);
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
              , base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Question question = Question.Get(questionTypeEnum);
            //Click On Cmenu Option Of Question
            new QlGridUXPage().ClickOnCmenuOfQuestion(question.Name, questionCmenuOption);
            Logger.LogMethodExit("CreateQuestion", "ClickOnCmenuOptionOfQuestion"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Question Edit Page.
        /// </summary>
        [Then(@"I should be on the edit page")]
        public void VerifyTheQuestionEditPage()
        {
            //Verify The Question Edit Page
            Logger.LogMethodEntry("CreateQuestion", "VerifyTheQuestionEditPage"
              , base.IsTakeScreenShotDuringEntryExit);
            //Asserts To Verify The Question Edit Page
            Logger.LogAssertion("VerifyQuestionEditPage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new AutoGraderPage().IsQuestionTitleTextboxPresent()));
            Logger.LogMethodExit("CreateQuestion", "VerifyTheQuestionEditPage"
                , base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Create Questions
            new QlGridUXPage().CreateQuestions(questionTypeEnum);
            //Logger Exit
            Logger.LogMethodExit("CreateQuestion", "CreateQuestions",
                       base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Create 2010 SIM Questions set 
            new QuestionSetPage().CreateSIMQuestionsSet(questionTypeEnum);
            //Logger Exit
            Logger.LogMethodExit("CreateQuestion",
                "CraetedSIMQuestionSetWithQuestionType",
                       base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Edit the SIM Questions set 
            new QuestionSetPage().UpdateTheSIMQuestionsSet(questionTypeEnum);
            //Logger Exit
            Logger.LogMethodExit("CreateQuestion",
                "UpdateTheQuestionSetWithQuestionType",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on 'Create New Question' Link
        /// </summary>      
        [When(@"I click on ""(.*)"" link")]
        public void ClickOnCreateNewQuestionLink(string createQuestion)
        {
            //Logger Entry
            Logger.LogMethodEntry("CreateQuestion",
                "ClickOnCreateNewQuestionLink",
                base.IsTakeScreenShotDuringEntryExit);
            new SkillBasedAssessmentPage().ClickOnCreateNewQuestion();
            Logger.LogMethodExit("CreateQuestion",
               "ClickOnCreateNewQuestionLink",
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify if all native questions are present
        /// </summary>      
        [Then(@"I should see all native questions present")]
        public void VerifyAllNativeQuestionsPresent()
        {
            //Logger Entry
            Logger.LogMethodEntry("CreateQuestion",
                "VerifyAllNativeQuestionsPresent",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify if all native questions are present
            Logger.LogAssertion("VerifyAllNativeQuestionsPresence",
                ScenarioContext.Current.ScenarioInfo.Title, () =>                  
                Assert.IsTrue(new CreateQuestionPage().IsAllNativeQuestionsPresent()));            
            Logger.LogMethodExit("CreateQuestion",
               "VerifyAllNativeQuestionsPresent",
                      base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Cmenu Option Of Question
            new QlGridUXPage().ClickOnCmenuOfQuestion(questionName, cmenuOption);
            Logger.LogMethodExit("CreateQuestion", "ClickOnCmenuOfQuestion",
                      base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Set Point Value For Question
            new SimQuestionPointValuePage().
                SetPointValueForQuestion(pointValue);
            Logger.LogMethodExit("CreateQuestion", "SetPointValueForTheAddedQuestion",
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add questions into activity
        /// </summary>
        /// <param name="activityType">This is Question Type.</param> 
        /// /// <param name="activityType">This is Question Name.</param> 
        [When(@"I add ""(.*)"" question in created ""(.*)"" activity")]
        [When(@"I add ""(.*)"" question as ""(.*)"" in created activity and save this activity")]
         public void AddQuestionIntoActivity(string questionType, string questionName)
        {
            Logger.LogMethodEntry("CreateQuestion", "AddQuestionIntoActivity",
                 base.IsTakeScreenShotDuringEntryExit);
            switch (questionType)
            {
                 case "SIM5":
                    //Click on Select Questions from Bank
                    new SkillBasedAssessmentPage().SelectQuestionFromQuestionBank();
                    //Click on Advanced Search option
                    new ContentBrowserUXPage().SearchAndAddSIM5question();
                    break;
                case "Native":
                    //Create Pegasus native questions
                    new SkillBasedAssessmentPage().CreateNativeQuestion(questionName);
                    break;
            }
            
            Logger.LogMethodExit("CreateQuestion", "AddQuestionIntoActivity",
                     base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Asserts To Verify The Question Point Value
            Logger.LogAssertion("VerifyQuestionPointValue",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(pointValue,
                    new SimQuestionPointValuePage().GetQuestionPointValue(questionName)));
            Logger.LogMethodExit("CreateQuestion", "VerifyTheQuestionPointValue",
                      base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
