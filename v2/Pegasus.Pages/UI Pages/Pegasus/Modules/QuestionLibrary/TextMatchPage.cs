using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// <summary>
    /// This Class Handles Text Match Page actions
    /// </summary>
    public class TextMatchPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(TextMatchPage));

        /// <summary>
        /// Create Text Match Question.
        /// </summary>
        public void CreateTextMatchQuestion()
        {
            //Create Text Match Question
            logger.LogMethodEntry("TextMatchPage", "CreateTextMatchQuestion",
                base.isTakeScreenShotDuringEntryExit);
            //Enter Question Title
            string questionDetails = this.EnterTitleForTextMatch().ToString();
            //Click on View Source Button and Enter data
            this.ClickOnViewSourceAndEnterDataForTextMatchQuestion(questionDetails);
            //Click On Add Answer Button
            this.ClickOnAddAnswerButtonOfTextmatchQuestion();
            //Enter the Number Of Lines For Answer Text Box
            this.EnterTheNumberOfLinesForAnswerTextBox();
            //Fill KeyWord Values
            this.FillKeywordValues();
            //Fill Score Values
            this.FillScoreValues();
            //Click On Save and Close Button
            this.ClickONSaveAndCloseButtonOfTextMatchQuestion();
            //Store Question Details In Memory
            this.StoreQuestionDetailsInMemory(questionDetails);
            logger.LogMethodExit("TextMatchPage", "CreateTextMatchQuestion",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Title.
        /// </summary>
        /// <returns>This is Question title GUID</returns>
        private Guid EnterTitleForTextMatch()
        {
            //Enter Title
            logger.LogMethodEntry("TextMatchPage", "EnterTitleForTextMatch",
                base.isTakeScreenShotDuringEntryExit);
            Guid questionTitle = Guid.NewGuid();
            //Select Entry List Window
            base.SelectWindow(TextMatchPageResource.
                TextMatch_Page_CreateTextMatch_Window_Name);
            base.WaitForElement(By.Id(TextMatchPageResource.
                TextMatch_Page_EnterQuestionTitle_Id_Locator));
            //Enter Title
            base.FillTextBoxByID(TextMatchPageResource.
                TextMatch_Page_EnterQuestionTitle_Id_Locator, questionTitle.ToString());
            logger.LogMethodExit("TextMatchPage", "EnterTitleForTextMatch",
               base.isTakeScreenShotDuringEntryExit);
            return questionTitle;
        }

        /// <summary>
        /// Click on View Source Button and enter HTML Text.
        /// </summary>
        /// <param name="questionText">This is Question text</param>
        private void ClickOnViewSourceAndEnterDataForTextMatchQuestion
            (string questionText)
        {
            //Click On View Source Button and Enter Data
            logger.LogMethodEntry("TextMatchPage",
                "ClickOnViewSourceAndEnterDataForTextMatchQuestion",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Frame
            base.WaitForElement(By.Id(TextMatchPageResource.
                TextMatch_Page_Frame_Id_Locator));
            base.SwitchToIFrame(TextMatchPageResource.
                TextMatch_Page_Frame_Id_Locator);
            //Wait for view Source Button
            base.WaitForElement(By.Id(TextMatchPageResource.
                TextMatch_Page_ViewSource_Button_Id_Locator));
            //Click on View Source Button
            base.ClickButtonByID(TextMatchPageResource.
                TextMatch_Page_ViewSource_Button_Id_Locator);
            base.WaitForElement(By.Id(TextMatchPageResource.
                TextMatch_Page_EnterTextHTML_Id_Locator));
            //Enter data
            base.FillTextBoxByID(TextMatchPageResource.
                TextMatch_Page_EnterTextHTML_Id_Locator, questionText);
            //Click on View Source Button
            base.ClickButtonByID(TextMatchPageResource.
                TextMatch_Page_ViewSource_Button_Id_Locator);
            logger.LogMethodExit("TextMatchPage",
                "ClickOnViewSourceAndEnterDataForTextMatchQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Pallette Characters.
        /// </summary>
        private void AddPalletteCharacters()
        {
            //Add pallette Characters
            logger.LogMethodEntry("TextMatchPage", "AddPalletteCharacters",
            base.isTakeScreenShotDuringEntryExit);
            //Add a character  
            this.ClickOnCharacterPalleteButton(TextMatchPageResource.
                TextMatch_Page_CharacterPallete_Xpath_Locator_one);
            //Add e character  
            this.ClickOnCharacterPalleteButton(TextMatchPageResource.
                TextMatch_Page_CharacterPallete_Xpath_Locator_two);
            //Add i character  
            this.ClickOnCharacterPalleteButton(TextMatchPageResource.
                TextMatch_Page_CharacterPallete_Xpath_Locator_three);
            //Add o character  
            this.ClickOnCharacterPalleteButton(TextMatchPageResource.
                TextMatch_Page_CharacterPallete_Xpath_Locator_Four);
            //Add u character  
            this.ClickOnCharacterPalleteButton(TextMatchPageResource.
                TextMatch_Page_CharacterPallete_Xpath_Locator_Five);
            logger.LogMethodExit("TextMatchPage", "AddPalletteCharacters",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Character Pallette.
        /// </summary>
        /// <param name="locator">This is Locator of Pallete Character</param>
        private void ClickOnCharacterPalleteButton(string locator)
        {
            //Click on Character Pallette
            logger.LogMethodEntry("TextMatchPage", "ClickOnCharacterPalleteButton",
            base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(locator));
            base.FocusOnElementByXPath(locator);
            //Get Button Property
            IWebElement getButtonProperty = base.GetWebElementPropertiesByXPath(locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("TextMatchPage", "ClickOnCharacterPalleteButton",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Answer Button.
        /// </summary>
        private void ClickOnAddAnswerButtonOfTextmatchQuestion()
        {
            logger.LogMethodEntry("TextMatchPage",
                "ClickOnAddAnswerButtonOfTextmatchQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            base.SelectWindow(TextMatchPageResource.
                TextMatch_Page_CreateTextMatch_Window_Name);
            base.WaitForElement(By.Id(TextMatchPageResource.
                TextMatch_Page_AddAnswer_Button_Id_Locator));
            //Get Button Property
            IWebElement getAddAnswerButton = base.GetWebElementPropertiesById(
                TextMatchPageResource.TextMatch_Page_AddAnswer_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getAddAnswerButton);
            logger.LogMethodExit("TextMatchPage",
                "ClickOnAddAnswerButtonOfTextmatchQuestion",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Number Of Lines For Answer TextBox.
        /// </summary>
        private void EnterTheNumberOfLinesForAnswerTextBox()
        {
            //Enter Number Of Lines For Answer TextBox
            logger.LogMethodEntry("TextMatchPage",
                "EnterTheNumberOfLinesForAnswerTextBox",
             base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(TextMatchPageResource.
                TextMatch_Page_NumberOfLines_Id_Locator));
            //Clear Text Box
            base.ClearTextByID(TextMatchPageResource.
                TextMatch_Page_NumberOfLines_Id_Locator);
            //Fill Text With the Number of Lines
            base.FillTextBoxByID(TextMatchPageResource.
                TextMatch_Page_NumberOfLines_Id_Locator,
                TextMatchPageResource.TextMatch_Page_NumberOfLines_Value);
            logger.LogMethodExit("TextMatchPage",
                "EnterTheNumberOfLinesForAnswerTextBox",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Keyword Values.
        /// </summary>
        private void FillKeywordValues()
        {
            //Fill Keyword Values
            logger.LogMethodEntry("TextMatchPage", "FillKeywordValues",
             base.isTakeScreenShotDuringEntryExit);
            for (int initialCount = Convert.ToInt32(TextMatchPageResource.
                TextMatch_Page_InitialValue); initialCount <= Convert.ToInt32(
                TextMatchPageResource.TextMatch_Page_MaxValue); initialCount++)
            {
                {
                    base.WaitForElement(By.Id(string.Format(
                        TextMatchPageResource.TextMatch_Page_KeyWord_Id_Locator, initialCount)));
                    //Clear Text Box
                    base.ClearTextByID(string.Format(
                        TextMatchPageResource.TextMatch_Page_KeyWord_Id_Locator, initialCount));
                    //Fill Text Box with keyword value
                    base.FillTextBoxByID(string.Format(
                        TextMatchPageResource.TextMatch_Page_KeyWord_Id_Locator,
                        initialCount), initialCount.ToString());
                }
            }
            logger.LogMethodExit("TextMatchPage", "FillKeywordValues",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Score Values.
        /// </summary>
        private void FillScoreValues()
        {
            //Fill Score Values
            logger.LogMethodEntry("TextMatchPage", "FillScoreValues",
             base.isTakeScreenShotDuringEntryExit);
            for (int initialCount = Convert.ToInt32(TextMatchPageResource.
                TextMatch_Page_InitialValue); initialCount <= Convert.ToInt32(
                TextMatchPageResource.TextMatch_Page_MaxValue); initialCount++)
            {
                {
                    base.WaitForElement(By.Id(string.Format(TextMatchPageResource.
                        TextMatch_Page_Score_Id_Locator, initialCount)));
                    //Clear Text Box
                    base.ClearTextByID(string.Format(TextMatchPageResource.
                        TextMatch_Page_Score_Id_Locator, initialCount));
                    //Fill Text box with Score Value
                    base.FillTextBoxByID(string.Format(TextMatchPageResource.
                        TextMatch_Page_Score_Id_Locator, initialCount), initialCount.ToString());
                }
            }
            logger.LogMethodExit("TextMatchPage", "FillScoreValues",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save and Close button.
        /// </summary>
        private void ClickONSaveAndCloseButtonOfTextMatchQuestion()
        {
            //Click on Save and Close Button
            logger.LogMethodEntry("TextMatchPage",
                "ClickONSaveAndCloseButtonOfTextMatchQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            base.WaitForElement(By.Id(TextMatchPageResource.
                TextMatch_Page_Save_Button_Id_Locator));
            //Get Button property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById(
                TextMatchPageResource.
                TextMatch_Page_Save_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("TextMatchPage",
                "ClickONSaveAndCloseButtonOfTextMatchQuestion",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Storde Question Detials in Memory
        /// </summary>
        /// <param name="questionGuid">This is Question Name Generated by Guid</param>
        private void StoreQuestionDetailsInMemory(string questionGuid)
        {
            //Store Question Details in Memory
            logger.LogMethodEntry("MatchingPage", "storeQuestionDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
            //Save Question Properties in Memory
            Question newQuestion = new Question
            {
                Name = questionGuid.ToString(),
                QuestionType = Question.QuestionTypeEnum.TextMatch,
                IsCreated = true,
            };
            newQuestion.StoreQuestionInMemory();
            logger.LogMethodExit("MatchingPage", "storeQuestionDetailsInMemory",
              base.isTakeScreenShotDuringEntryExit);
        }


    }
}
