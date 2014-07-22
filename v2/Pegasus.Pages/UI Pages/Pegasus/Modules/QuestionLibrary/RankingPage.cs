using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.QuestionLibrary;

namespace Pegasus.Pages.UI_Pages
{
    public class RankingPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RankingPage));

        /// <summary>
        /// Create Ranking Question.
        /// </summary>
        public void CreateRankingQuestion()
        {
            //Create Ranking Question
            logger.LogMethodEntry("RankingPage", "CreateRankingQuestion",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create Ranking Window
                this.SelectCreateRankingWindow();
                //Enter the Question title
                string questionDetails = this.EnterQuestionTitle().ToString();
                //Click On ViewSource And Enter Data For Ranking Question
                this.ClickOnViewSourceAndEnterDataForRankingQuestion(questionDetails);
                //Click On AddAnswer Button Of Multiple Choice Question
                this.ClickOnAddAnswerButtonOfMultipleChoiceQuestion();
                //Enter TextValue For Ranking Question
                this.EnterTextValueForRankingQuestion();
                //Enter Score For Ranking Question
                this.EnterScoreForRankingQuestion();
                //Click On SaveAndClose Button Of Ranking Question
                this.ClickONSaveAndCloseButtonOfRankingQuestion();
                //Store Question Details In Memory
                this.StoreQuestionDetailsInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RankingPage", "CreateRankingQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Ranking Window.
        /// </summary>
        private void SelectCreateRankingWindow()
        {
            //Select Create Ranking Window
            logger.LogMethodEntry("RankingPage", "SelectCreateRankingWindow",
               base.isTakeScreenShotDuringEntryExit);
            //Select the window
            base.WaitUntilWindowLoads(RankingPageResource.
                Ranking_Page_CreateRanking_Window_Name);
            base.SelectWindow(RankingPageResource.
                Ranking_Page_CreateRanking_Window_Name);
            logger.LogMethodExit("RankingPage", "SelectCreateRankingWindow",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Question Title.
        /// </summary>
        /// <returns>Question Title Guid.</returns>
        private Guid EnterQuestionTitle()
        {
            //Enter Question Title
            logger.LogMethodEntry("RankingPage", "EnterQuestionTitle",
                base.isTakeScreenShotDuringEntryExit);
            //Generate Question Title Guid
            Guid questionTitle = Guid.NewGuid();
            base.WaitForElement(By.Id(RankingPageResource.
                Ranking_Page_EnterQuestionTitle_Id_Locator));
            //Fill the Question Title
            base.FillTextBoxByID(RankingPageResource.
                Ranking_Page_EnterQuestionTitle_Id_Locator, 
                questionTitle.ToString());
            logger.LogMethodExit("RankingPage", "EnterQuestionTitle",
                base.isTakeScreenShotDuringEntryExit);
            return questionTitle;
        }        

        /// <summary>
        /// Click on View Source Button and enter HTML Text.
        /// </summary>
        /// <param name="questionText">This is Question text.</param>
        private void ClickOnViewSourceAndEnterDataForRankingQuestion
            (string questionText)
        {
            //Click On View Source Button and Enter Data
            logger.LogMethodEntry("RankingPage",
                "ClickOnViewSourceAndEnterDataForRankingQuestion",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Frame
            base.WaitForElement(By.Id(RankingPageResource.
                Ranking_Page_Frame_Id_Locator));
            base.SwitchToIFrame(RankingPageResource.
                Ranking_Page_Frame_Id_Locator);
            //Wait for view Source Button
            base.WaitForElement(By.Id(RankingPageResource.
                Ranking_Page_ViewSource_Button_Id_Locator));
            //Click on View Source Button
            base.ClickButtonByID((RankingPageResource.
                Ranking_Page_ViewSource_Button_Id_Locator));
            base.WaitForElement(By.Id(RankingPageResource.
                Ranking_Page_EnterTextHTML_Id_Locator));
            //Enter data
            base.FillTextBoxByID(RankingPageResource.
                Ranking_Page_EnterTextHTML_Id_Locator, questionText);
            //Click on View Source Button
            base.ClickButtonByID(RankingPageResource.
                Ranking_Page_ViewSource_Button_Id_Locator);
            logger.LogMethodExit("RankingPage",
                "ClickOnViewSourceAndEnterDataForRankingQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Answer Button Of Multiple Choice Question.
        /// </summary>
        private void ClickOnAddAnswerButtonOfMultipleChoiceQuestion()
        {
            //Click On Add Answer Button Of Multiple Choice Question
            logger.LogMethodEntry("RankingPage", 
                "ClickOnAddAnswerButtonOfMultipleChoiceQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Matching Window
            this.SelectCreateRankingWindow();
            base.WaitForElement(By.Id(RankingPageResource.
                Ranking_Page_AddAnswer_Button_Id_Locator));
            //Get Button Property
            IWebElement getAddAnswerButton = base.GetWebElementPropertiesById(
                RankingPageResource.Ranking_Page_AddAnswer_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getAddAnswerButton);
            logger.LogMethodExit("RankingPage",
                "ClickOnAddAnswerButtonOfMultipleChoiceQuestion",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Text Value For Matching Question.
        /// </summary>
        private void EnterTextValueForRankingQuestion()
        {
            //Enter Text Value For Matching Question
            logger.LogMethodEntry("RankingPage",
                "EnterTextValueForRankingQuestion",
                base.isTakeScreenShotDuringEntryExit);
            for (int initialCount = Convert.ToInt32(RankingPageResource.
                Ranking_Page_TextBox_InitialValue); initialCount <= Convert.ToInt32(
                RankingPageResource.Ranking_Page_TextBox_MaxValue); initialCount++)
            {
                //Wait For Element
                base.WaitForElement(By.Id(string.Format(RankingPageResource.
                    Ranking_Page_ChoiceTextField_Id_Locator, initialCount)));
                //Clear the Textbox
                base.ClearTextByID(string.Format(RankingPageResource.
                    Ranking_Page_ChoiceTextField_Id_Locator, initialCount));
                //Fill the Text Box
                base.FillTextBoxByID(string.Format(RankingPageResource.
                    Ranking_Page_ChoiceTextField_Id_Locator, initialCount),
                    RankingPageResource.Ranking_Page_EnterText_TextValue +
                    initialCount.ToString());
            }
            logger.LogMethodExit("RankingPage",
                "EnterTextValueForRankingQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Score For Ranking Question.
        /// </summary>
        private void EnterScoreForRankingQuestion()
        {
            //Enter Score For Ranking Question
            logger.LogMethodEntry("MultipleChoicePage", 
                "EnterScoreForRankingQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RankingPageResource.
                     Ranking_Page_TextBox_Score_Id_Locator));
            base.ClearTextByID(RankingPageResource.
                     Ranking_Page_TextBox_Score_Id_Locator);
            //Enter the score
            base.FillTextBoxByID(RankingPageResource.
                     Ranking_Page_TextBox_Score_Id_Locator, 
                RankingPageResource.Ranking_Page_TextBox_ScoreValue);
            logger.LogMethodExit("RankingPage",
                "EnterScoreForRankingQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save and Close button.
        /// </summary>
        private void ClickONSaveAndCloseButtonOfRankingQuestion()
        {
            //Click on Save and Close Button
            logger.LogMethodEntry("MultipleChoicePage",
                "ClickONSaveAndCloseButtonOfRankingQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Matching Window            
            base.WaitForElement(By.Id(RankingPageResource.
                Ranking_Page_Save_Button_Id_Locator));
            //Get Button property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById(
                RankingPageResource.Ranking_Page_Save_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("MultipleChoicePage", 
                "ClickONSaveAndCloseButtonOfRankingQuestion",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Storde Question Detials in Memory.
        /// </summary>
        /// <param name="questionGuid">This is Question Name Generated by Guid</param>
        private void StoreQuestionDetailsInMemory(string questionGuid)
        {
            //Store Question Details in Memory
            logger.LogMethodEntry("MultipleChoicePage", "StoreQuestionDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
            //Save Question Properties in Memory
            Question newQuestion = new Question
            {
                Name = questionGuid.ToString(),
                QuestionType = Question.QuestionTypeEnum.Ranking,
                IsCreated = true,
            };
            newQuestion.StoreQuestionInMemory();
            logger.LogMethodExit("MultipleChoicePage", "StoreQuestionDetailsInMemory",
              base.isTakeScreenShotDuringEntryExit);
        }
    }
}
