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
    /// <summary>
    /// This Class Handles Numeric Page actions
    /// </summary>
    public class NumericPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(NumericPage));

        /// <summary>
        /// Create Numeric Question
        /// </summary>
        public void CreateNumericQuestion()
        {
            //Create Numeric Question
            logger.LogMethodEntry("NumericPage", "CreateNumericQuestion",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create Numeric Window
                this.SelectCreateNumericWindow();
                //Enter Question Title
                string questionDetails = this.EnterQuestionTitle().ToString();
                //Click On View Source Button and Fill Data
                this.ClickOnViewSourceAndEnterDataForNumericQuestion(questionDetails);
                //Add Pallette Characters
                this.AddPalletteCharacters();
                //Click On Add Answer Button
                this.ClickOnAddAnswerButtonOfNumericQuestion();
                //Fill Correct Score Value
                this.FillCorrectScoreValue(
                    NumericPageResource.Numeric_Page_CorrectAnswer_Value);
                //Fill From Range Score Values
                this.FillFromRangeScoreValues(
                    NumericPageResource.Numeric_Page_FromRange_Value);
                //Fill To Range Score Values
                this.FillToRangeScoreValues(
                    NumericPageResource.Numeric_Page_CorrectAnswer_Value);
                //Fill Score Value For Correct Answer
                this.FillScoreValueForCorrectAnswer(
                    NumericPageResource.Numeric_Page_FromRange_Value);
                //Fill Score Value for Incorrect Answer
                this.FillScoreValueForIncorrectAnswer(
                    NumericPageResource.Numeric_Page_IncorrectAnswer_Value);
                //Fill Range Score Value
                this.FillRangeScoreValue(
                    NumericPageResource.Numeric_Page_FromRange_Value);
                //Click on Save and Close Button
                this.ClickONSaveAndCloseButtonOfNumericQuestion();
                //Store Question Details
                this.StoreQuestionDetailsInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("NumericPage", "CreateNumericQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Numeric Window
        /// </summary>
        private void SelectCreateNumericWindow()
        {
            //Select Create Numeric Window
            logger.LogMethodEntry("NumericPage", "SelectCreateNumericWindow",
              base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(NumericPageResource.
                Numeric_Page_CreateNumeric_Window_Name);
            base.SelectWindow(NumericPageResource.
                Numeric_Page_CreateNumeric_Window_Name);
            logger.LogMethodExit("NumericPage", "SelectCreateNumericWindow",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Question Title.
        /// </summary>
        /// <returns>Question Title Guid</returns>
        private Guid EnterQuestionTitle()
        {
            //Enter Question Title
            logger.LogMethodEntry("NumericPage", "EnterQuestionTitle",
                base.isTakeScreenShotDuringEntryExit);
            //Generate Question Title Guid
            Guid questionTitle = Guid.NewGuid();
            base.WaitForElement(By.Id(NumericPageResource.
                Numeric_Page_EnterQuestionTitle_Id_Locator));
            //Fill the Question Title
            base.FillTextBoxById(NumericPageResource.
                Numeric_Page_EnterQuestionTitle_Id_Locator, questionTitle.ToString());
            logger.LogMethodExit("NumericPage", "EnterQuestionTitle",
                base.isTakeScreenShotDuringEntryExit);
            return questionTitle;
        }

        /// <summary>
        /// Click on View Source Button and enter HTML Text.
        /// </summary>
        /// <param name="questionText">This is Question text</param>
        private void ClickOnViewSourceAndEnterDataForNumericQuestion
            (string questionText)
        {
            //Click On View Source Button and Enter Data
            logger.LogMethodEntry("NumericPage",
                "ClickOnViewSourceAndEnterDataForNumericQuestion",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Frame
            base.WaitForElement(By.Id(NumericPageResource.
                Numeric_Page_Frame_Id_Locator));
            base.SwitchToIFrame(NumericPageResource.
                Numeric_Page_Frame_Id_Locator);
            //Wait for view Source Button
            base.WaitForElement(By.Id(NumericPageResource.
                Numeric_Page_ViewSource_Button_Id_Locator));
            //Click on View Source Button
            base.ClickButtonById(NumericPageResource.
                Numeric_Page_ViewSource_Button_Id_Locator);
            base.WaitForElement(By.Id(NumericPageResource.
                Numeric_Page_EnterTextHTML_Id_Locator));
            //Enter data
            base.FillTextBoxById(NumericPageResource.
                Numeric_Page_EnterTextHTML_Id_Locator, questionText);
            //Click on View Source Button
            base.ClickButtonById(NumericPageResource.
                Numeric_Page_ViewSource_Button_Id_Locator);
            logger.LogMethodExit("NumericPage",
                "ClickOnViewSourceAndEnterDataForNumericQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Pallette Characters.
        /// </summary>
        private void AddPalletteCharacters()
        {
            //Add Pallette Characters
            logger.LogMethodEntry("NumericPage", "AddPalletteCharacters",
                base.isTakeScreenShotDuringEntryExit);
            //Add a character
            this.ClickOnCharacterPalleteButton(NumericPageResource.
                Numeric_Page_CharacterPalletea_Xpath_Locator_one);
            //Add e character
            this.ClickOnCharacterPalleteButton(NumericPageResource.
                Numeric_Page_CharacterPalletee_Xpath_Locator_two);
            //Add i character
            this.ClickOnCharacterPalleteButton(NumericPageResource.
                Numeric_Page_CharacterPalletei_Xpath_Locator_three);
            //Add o character
            this.ClickOnCharacterPalleteButton(NumericPageResource.
                Numeric_Page_CharacterPalleteo_Xpath_Locator_four);
            //Add u character
            this.ClickOnCharacterPalleteButton(NumericPageResource.
                Numeric_Page_CharacterPalleteu_Xpath_Locator_five);
            logger.LogMethodExit("NumericPage", "AddPalletteCharacters",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Character Pallette.
        /// </summary>
        /// <param name="locator">This is Locator of Pallete Character</param>
        private void ClickOnCharacterPalleteButton(string locator)
        {
            //Click on Character Pallette
            logger.LogMethodEntry("NumericPage", "ClickOnCharacterPalleteButton",
            base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(locator));
            base.FocusOnElementByXPath(locator);
            //Get Button Property
            IWebElement getButtonProperty = base.GetWebElementPropertiesByXPath(locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("NumericPage", "ClickOnCharacterPalleteButton",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Answer Button
        /// </summary>
        private void ClickOnAddAnswerButtonOfNumericQuestion()
        {
            //Click on Add Answer Button
            logger.LogMethodEntry("NumericPage", "ClickOnAddAnswerButtonOfNumericQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            this.SelectCreateNumericWindow();
            base.WaitForElement(By.Id(NumericPageResource.
                Numeric_Page_AddAnswer_Button_Id_Locator));
            //Get Button Property
            IWebElement getAddAnswerButton = base.GetWebElementPropertiesById(
                NumericPageResource.Numeric_Page_AddAnswer_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getAddAnswerButton);
            logger.LogMethodExit("NumericPage", "ClickOnAddAnswerButtonOfNumericQuestion",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill The Correct Score Value
        /// </summary>
        /// <param name="scoreValue">This is Score Value</param>
        private void FillCorrectScoreValue(string scoreValue)
        {
            //Fill The Correct Score Value
            logger.LogMethodEntry("NumericPage", "FillCorrectScoreValue",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(NumericPageResource.
                Numeric_Page_CorrectAnswer_Id_Locator));
            base.ClearTextById(NumericPageResource.
                Numeric_Page_CorrectAnswer_Id_Locator);
            base.FillTextBoxById(NumericPageResource.
                Numeric_Page_CorrectAnswer_Id_Locator, scoreValue);
            logger.LogMethodExit("NumericPage", "FillCorrectScoreValue",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill From Range Score Value
        /// </summary>
        /// <param name="fromRangeScoreValue">This is From Range Score Value</param>
        private void FillFromRangeScoreValues(string fromRangeScoreValue)
        {
            //Fill From Range Score Value
            logger.LogMethodEntry("NumericPage", "FillFromRangeScoreValues",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(NumericPageResource.
                Numeric_Page_FromRange_Id_Locator));
            //Clear the Text Box
            base.ClearTextById(NumericPageResource.
                 Numeric_Page_FromRange_Id_Locator);
            //Fill the Text Box with From Range Score Value
            base.FillTextBoxById(NumericPageResource.
                 Numeric_Page_FromRange_Id_Locator,
                 fromRangeScoreValue);
            logger.LogMethodExit("NumericPage", "FillFromRangeScoreValues",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill To Range Score Value
        /// </summary>
        /// <param name="toRangeScoreValue">This is to Range Score Value</param>
        private void FillToRangeScoreValues(string toRangeScoreValue)
        {
            //Fill To Range Score Value
            logger.LogMethodEntry("NumericPage", "FillToRangeScoreValues",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(NumericPageResource.
                Numeric_Page_ToRange_Id_Locator));
            //Clear the Text Box
            base.ClearTextById(NumericPageResource.
                Numeric_Page_ToRange_Id_Locator);
            //Fill the Text Box with to Range Score Value
            base.FillTextBoxById(NumericPageResource.
                Numeric_Page_ToRange_Id_Locator, toRangeScoreValue);
            logger.LogMethodExit("NumericPage", "FillToRangeScoreValues",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Score Value For Correct Answer
        /// </summary>
        /// <param name="correctScoreValue">This is Correct Score Value</param>
        private void FillScoreValueForCorrectAnswer(string correctScoreValue)
        {
            //Fill Score Value For Correct Answer
            logger.LogMethodEntry("NumericPage", "FillScoreValueForCorrectAnswer",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(NumericPageResource.
                Numeric_Page_CorrectScore_Id_Locator));
            //Clear the Text Box
            base.ClearTextById(NumericPageResource.
                Numeric_Page_CorrectScore_Id_Locator);
            base.FillTextBoxById(NumericPageResource.
                Numeric_Page_CorrectScore_Id_Locator, correctScoreValue);
            logger.LogMethodExit("NumericPage", "FillScoreValueForCorrectAnswer",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Score Value For In Correct Answer
        /// </summary>
        /// <param name="inCorrectScoreValue">This is InCorrect Score Value</param>
        private void FillScoreValueForIncorrectAnswer(string inCorrectScoreValue)
        {
            //Fill Score Value For InCorrect Answer
            logger.LogMethodEntry("NumericPage", "FillScoreValueForIncorrectAnswer",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(NumericPageResource.
                Numeric_Page_IncorrectAnswer_Id_Locator));
            //Clear the Text Box
            base.ClearTextById(NumericPageResource.
                Numeric_Page_IncorrectAnswer_Id_Locator);
            //Fill The Text Box With Incorrect Score Value
            base.FillTextBoxById(NumericPageResource.
                Numeric_Page_IncorrectAnswer_Id_Locator,
                inCorrectScoreValue);
            logger.LogMethodExit("NumericPage", "FillScoreValueForIncorrectAnswer",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill The Range Score Value
        /// </summary>
        /// <param name="rangeScoreValue">This is Range Score Value</param>
        private void FillRangeScoreValue(string rangeScoreValue)
        {
            logger.LogMethodEntry("NumericPage", "FillRangeScoreValue",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(NumericPageResource.
                Numeric_Page_RangeScore_Id_Locator));
            //Clear Text Box
            base.ClearTextById(NumericPageResource.
                Numeric_Page_RangeScore_Id_Locator);
            //Fill the Text Box with Range Score Value
            base.FillTextBoxById(NumericPageResource.
                Numeric_Page_RangeScore_Id_Locator, rangeScoreValue);
            logger.LogMethodExit("NumericPage", "FillRangeScoreValue",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save and Close button
        /// </summary>
        private void ClickONSaveAndCloseButtonOfNumericQuestion()
        {
            //Click on Save and Close Button
            logger.LogMethodEntry("NumericPage", "ClickONSaveAndCloseButtonOfNumericQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Matching Window            
            base.WaitForElement(By.Id(NumericPageResource.
                Numeric_Page_Save_Button_Id_Locator));
            //Get Button property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById(NumericPageResource.
                Numeric_Page_Save_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("NumericPage", "ClickONSaveAndCloseButtonOfNumericQuestion",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Storde Question Detials in Memory
        /// </summary>
        /// <param name="questionGuid">This is Question Name Generated by Guid</param>
        private void StoreQuestionDetailsInMemory(string questionGuid)
        {
            //Store Question Details in Memory
            logger.LogMethodEntry("NumericPage", "StoreQuestionDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
            //Save Question Properties in Memory
            Question newQuestion = new Question
            {
                Name = questionGuid.ToString(),
                QuestionType = Question.QuestionTypeEnum.Numeric,
                IsCreated = true,
            };
            newQuestion.StoreQuestionInMemory();
            logger.LogMethodExit("NumericPage", "StoreQuestionDetailsInMemory",
              base.isTakeScreenShotDuringEntryExit);
        }
    }
}
