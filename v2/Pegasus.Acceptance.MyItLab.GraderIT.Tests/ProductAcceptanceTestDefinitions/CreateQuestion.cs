using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Integration.SIM5.SIM5Services.SIM5ContentBrowse;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyITLab.GraderIT.Tests.ProductAcceptanceTestDefinitions
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
        private static readonly Logger Logger =
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
        /// Create Grader IT Question In CourseSpace.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        /// <param name="projectName">This is Project Name.</param>
        [When(@"I create ""(.*)"" grader IT Question using ""(.*)"" project in 'CourseSpace'")]
        public void CreateGraderITQuestionInCourseSpace(
            Question.QuestionTypeEnum questionTypeEnum, String projectName)
        {
            // Create Grader IT Question In Manage Question Bank
            Logger.LogMethodEntry("CreateQuestion",
                "CreateGraderITQuestionInManageQuestionBank",
                 base.IsTakeScreenShotDuringEntryExit);
            //Create The GraderIT Question In Manage Question Bank
            new AutoGraderPage().
                CreateTheGraderITQuestionInCourseSpace(questionTypeEnum, projectName);
            Logger.LogMethodExit("CreateQuestion",
                "CreateGraderITQuestionInManageQuestionBank",
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
        /// Click on the alert OK button
        /// </summary>
        [When(@"I click on the alert OK button")]
        public void DeleteAutoGraderQuestion()
        {
            //Click on the alert 'OK' button
            Logger.LogMethodEntry("CreateQuestion", "DeleteAutoGraderQuestion",
                 base.IsTakeScreenShotDuringEntryExit);
            //Click on the alert OK button of Asset
            new ShowMessagePage().ClickOnPegasusAlertOkButton();
            Logger.LogMethodExit("CreateQuestion", "DeleteAutoGraderQuestion",
              base.IsTakeScreenShotDuringEntryExit);

        }
        /// <summary>
        /// Verify the question added in Map Learning Objectives to Questions tab.
        /// </summary>
        /// <param name="questionTypeEnum">This is question Type Enum.</param>
        [Then(@"I should see ""(.*)"" in the Map Learning Objectives in Questions tab")]
        public void VerifyTheQuestionAdded( Question.QuestionTypeEnum questionTypeEnum)
        {
            //Verify the question added
            Logger.LogMethodEntry("CreateQuestion", "VerifyTheQuestionAdded",
                 base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Question question = Question.Get(questionTypeEnum);
            //Asserts To Verify the question added
            Logger.LogAssertion("VerifyTheQuestionAdded",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new QlGridUXPage().
               VerifyTheQuestionAdded(question.Name)));
            Logger.LogMethodExit("CreateQuestion", "VerifyTheQuestionAdded",
              base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Verify the 'Edit Grader Project Instruction' control on the Page.
        /// </summary>
        [Then("I should see instead of 'Preference', 'Edit Grader Project Instruction' is visible")]
        public void DisplayEditGraderProjectInstruction()
        {
            // Method To Verify 'Edit Grader Project Instruction' control on the Page
            Logger.LogMethodEntry("CreateQuestion", "DisplayTheSuccessfullMessage",
                base.IsTakeScreenShotDuringEntryExit);
            //Asserts To Verify 'Edit Grader Project Instruction' control on the Page
            Logger.LogAssertion("VerifyTheEditGraderProjectInstruction",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue( new AutoGraderPage().
              DisplayEditGraderProjectInstruction()));           
            Logger.LogMethodExit("CreateQuestion", "DisplayTheSuccessfullMessage",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
