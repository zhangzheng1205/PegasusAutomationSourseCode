using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.QuestionLibrary;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handles Entry List Page actions
    /// </summary>
    public class EntryListPage : BasePage
    {

        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(EntryListPage));


        /// <summary>
        /// Create Entry List Question
        /// </summary>
        public void CreateEntryListQuestion()
        {
            //Create Essay Question
            logger.LogMethodEntry("EntryListPage", "CreateEntryListQuestion",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Enter Question Title
                string questionDetails = this.EnterTitleForEntryList().ToString();
                //Click on View Source Button and Enter data
                this.ClickOnViewSourceAndEnterDataForEntryListQuestion(questionDetails);
                //Add Pallette Characters
                this.AddPalletteCharacters();
                //Click on Add Answer Button
                this.ClickOnAddAnswerButtonOfEntryListQuestion();
                //Enter First Two Text
                this.EnterFirstTwoTextForEntryListQuestion();
                //Enter Last Two Text
                this.EnterLastTwoTextForEntryListQuestion();
                //Enter First Two Answer
                this.EnterFirstTwoAnswerForEntryListQuestion();
                //Enter Last Two Answer
                this.EnterLastTwoAnswerForEntryListQuestion();
                //Enter First Two Correct Score Value
                this.EnterFirstTwoCorrectScoreValueOfEntryListQuestion();
                //Enter Last Two Correct Score Value
                this.EnterLastTwoCorrectScoreValueOfEntryListQuestion();
                //Enter First Two Incorrect Score Value
                this.EnterFirstTwoIncorrectScoreValueOfEntryListQuestion();
                //Enter Last Two Incorrect Score Value
                this.EnterLastTwoIncorrectScoreValueOfEntryListQuestion();
                //Click on Save and Close Button
                this.ClickONSaveAndCloseButtonOfEntryListQuestion();
                //Store Question Details in Memory
                this.StoreQuestionDetailsInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EntryListPage", "CreateEntryListQuestion",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Title
        /// </summary>
        /// <returns>This is Question title GUID</returns>
        private Guid EnterTitleForEntryList()
        {
            //Enter Title
            logger.LogMethodEntry("EntryListPage", "EnterTitleForEntryList",
                base.isTakeScreenShotDuringEntryExit);
            Guid questionTitle = Guid.NewGuid();
            //Select Entry List Window
            base.SelectWindow(EntryListPageResource.
                EntryList_Page_CreateEntryList_Id_Locator);
            base.WaitForElement(By.Id(EntryListPageResource.
                EntryList_Page_EnterQuestionTitle_Id_Locator));
            //Enter Title
            base.FillTextBoxByID(EntryListPageResource.
                EntryList_Page_EnterQuestionTitle_Id_Locator, questionTitle.ToString());
            logger.LogMethodExit("EntryListPage", "EnterTitleForEntryList",
               base.isTakeScreenShotDuringEntryExit);
            return questionTitle;
        }

        /// <summary>
        /// Click on View Source Button and enter HTML Text
        /// </summary>
        /// <param name="questionText">This is Question text</param>
        private void ClickOnViewSourceAndEnterDataForEntryListQuestion(string questionText)
        {
            //Click On View Source Button and Enter Data
            logger.LogMethodEntry("EntryListPage",
                "ClickOnViewSourceAndEnterDataForEntryListQuestion",
                base.isTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            base.SelectWindow(EntryListPageResource.
                EntryList_Page_CreateEntryList_Id_Locator);
            //Wait for view Source Button
            base.WaitForElement(By.Id(EntryListPageResource.
                EntryList_Page_ViewSource_Button_Id_Locator));
            //Click on View Source Button
            base.ClickButtonByID(EntryListPageResource.
                EntryList_Page_ViewSource_Button_Id_Locator);
            base.WaitForElement(By.Id(EntryListPageResource.
                EntryList_Page_EnterTextHTML_Id_Locator));
            //Enter data
            base.FillTextBoxByID(EntryListPageResource.
                EntryList_Page_EnterTextHTML_Id_Locator, questionText);
            //Click on View Source Button
            base.ClickButtonByID(EntryListPageResource.
                EntryList_Page_ViewSource_Button_Id_Locator);
            logger.LogMethodExit("EntryListPage",
                "ClickOnViewSourceAndEnterDataForEntryListQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Add Answer Button
        /// </summary>
        private void ClickOnAddAnswerButtonOfEntryListQuestion()
        {
            logger.LogMethodEntry("EntryListPage", "ClickOnAddAnswerButtonOfEntryListQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            base.SelectWindow(EntryListPageResource.
                EntryList_Page_CreateEntryList_Id_Locator);
            base.WaitForElement(By.Id(EntryListPageResource.
                EntryList_Page_AddAnswer_Button_Id_Locator));
            //Get Button Property
            IWebElement getAddAnswerButton = base.GetWebElementPropertiesById(
                EntryListPageResource.EntryList_Page_AddAnswer_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getAddAnswerButton);
            logger.LogMethodExit("EntryListPage", "ClickOnAddAnswerButtonOfEntryListQuestion",
              base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Click on Save and Close button
        /// </summary>
        private void ClickONSaveAndCloseButtonOfEntryListQuestion()
        {
            //Click on Save and Close Button
            logger.LogMethodEntry("EntryListPage", "ClickONSaveAndCloseButtonOfEntryListQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            base.SelectWindow(EntryListPageResource.
                EntryList_Page_CreateEntryList_Id_Locator);
            base.WaitForElement(By.Id(EntryListPageResource.
                EntryList_Page_Save_Button_Id_Locator));
            //Get Button property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById(EntryListPageResource.
                EntryList_Page_Save_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("EntryListPage", "ClickONSaveAndCloseButtonOfEntryListQuestion",
          base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter First Two Text Value
        /// </summary>
        private void EnterFirstTwoTextForEntryListQuestion()
        {
            //Enter First Two Text Value
            logger.LogMethodEntry("EntryListPage", "EnterFirstTwoTextForEntryListQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            base.SelectWindow(EntryListPageResource.
                EntryList_Page_CreateEntryList_Id_Locator);
            base.WaitForElement(By.Id(EntryListPageResource.
                EntryList_Page_EnterText_One_Id_Locator));
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EntryList_Page_EnterText_One_Id_Locator);
            //Enter First Text Value in Text Box
            base.FillTextBoxByID(EntryListPageResource.
                EntryList_Page_EnterText_One_Id_Locator, EntryListPageResource.
                EnterList_Page_EnterText_TextValue_One);
            base.WaitForElement(By.Id(EntryListPageResource.
                EntryList_Page_EnterText_two_Id_Locator));
            //Focus On Text Box
            base.FocusOnElementByID(EntryListPageResource.
                EntryList_Page_EnterText_two_Id_Locator);
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EntryList_Page_EnterText_two_Id_Locator);
            //Enter Second Text Value in Text Box
            base.FillTextBoxByID(EntryListPageResource.
                EntryList_Page_EnterText_two_Id_Locator, EntryListPageResource.
                EnterList_Page_EnterText_TextValue_Two);
            logger.LogMethodExit("EntryListPage", "EnterFirstTwoTextForEntryListQuestion",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Last Two Text 
        /// </summary>
        private void EnterLastTwoTextForEntryListQuestion()
        {
            //Enter Last Two Text 
            logger.LogMethodEntry("EntryListPage", "EnterLastTwoTextForEntryListQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for Text Box
            base.WaitForElement(By.Id(EntryListPageResource.
                EntryList_Page_EnterText_three_Id_Locator));
            //Focus on Text Box
            base.FocusOnElementByID(EntryListPageResource.
                EntryList_Page_EnterText_three_Id_Locator);
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EntryList_Page_EnterText_three_Id_Locator);
            //Enter Third Text Value in Text Box
            base.FillTextBoxByID(EntryListPageResource.
                EntryList_Page_EnterText_three_Id_Locator, EntryListPageResource.
                EnterList_Page_EnterText_TextValue_Three);
            base.WaitForElement(By.Id(EntryListPageResource.
                EntryList_Page_EnterText_Four_Id_Locator));
            //Focus on Text Box
            base.FocusOnElementByID(EntryListPageResource.
                EntryList_Page_EnterText_Four_Id_Locator);
            base.ClearTextByID(EntryListPageResource.
                EntryList_Page_EnterText_Four_Id_Locator);
            //Enter Fourth Text Value in Text Box
            base.FillTextBoxByID(EntryListPageResource.
                EntryList_Page_EnterText_Four_Id_Locator, EntryListPageResource.
                EnterList_Page_EnterText_TextValue_Four);
            logger.LogMethodExit("EntryListPage", "EnterLastTwoTextForEntryListQuestion",
             base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter First Two Answer for Entry List
        /// </summary>
        private void EnterFirstTwoAnswerForEntryListQuestion()
        {
            //Enter First Two Answer for Entry List
            logger.LogMethodEntry("EntryListPage", "EnterFirstTwoAnswerForEntryListQuestion",
              base.isTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            base.SelectWindow(EntryListPageResource.
                EntryList_Page_CreateEntryList_Id_Locator);
            base.WaitForElement(By.Id(EntryListPageResource.
                EnterList_Page_AnswerTextBox_Id_Locator_one));
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EnterList_Page_AnswerTextBox_Id_Locator_one);
            //Enter First Answer in Text box
            base.FillTextBoxByID(EntryListPageResource.
                EnterList_Page_AnswerTextBox_Id_Locator_one, EntryListPageResource.
                EnterList_Page_Answer_Text_One);
            base.WaitForElement(By.Id(EntryListPageResource.
                EnterList_Page_AnswerTextBox_Id_Locator_Two));
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EnterList_Page_AnswerTextBox_Id_Locator_Two);
            //Enter Second Answer in Text Box
            base.FillTextBoxByID(EntryListPageResource.
                EnterList_Page_AnswerTextBox_Id_Locator_Two, EntryListPageResource.
                EnterList_Page_Answer_Text_Two);
            logger.LogMethodExit("EntryListPage", "EnterFirstTwoAnswerForEntryListQuestion",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Last Two Answer In Entry List
        /// </summary>
        private void EnterLastTwoAnswerForEntryListQuestion()
        {
            //Enter Last Two Answer In Entry List
            logger.LogMethodEntry("EntryListPage", "EnterLastTwoAnswerForEntryListQuestion",
              base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(EntryListPageResource.
                EnterList_Page_AnswerTextBox_Id_Locator_Three));
            //Clear Text box
            base.ClearTextByID(EntryListPageResource.
                EnterList_Page_AnswerTextBox_Id_Locator_Three);
            //Enter Third Answer in Text Box
            base.FillTextBoxByID(EntryListPageResource.
                EnterList_Page_AnswerTextBox_Id_Locator_Three, EntryListPageResource.
                EnterList_Page_Answer_Text_Three);
            base.WaitForElement(By.Id(EntryListPageResource.
                EnterList_Page_AnswerTextBox_Id_Locator_Four));
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EnterList_Page_AnswerTextBox_Id_Locator_Four);
            //Enter Fourth Answer in Text Box
            base.FillTextBoxByID(EntryListPageResource.
                EnterList_Page_AnswerTextBox_Id_Locator_Four, EntryListPageResource.
                EnterList_Page_Answer_Text_Four);
            logger.LogMethodExit("EntryListPage", "EnterLastTwoAnswerForEntryListQuestion",
            base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Enter Correct Score Value
        /// </summary>
        private void EnterFirstTwoCorrectScoreValueOfEntryListQuestion()
        {
            //Enter Correct Score Value
            logger.LogMethodEntry("EntryListPage",
                "EnterFirstTwoCorrectScoreValueOfEntryListQuestion",
              base.isTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            base.SelectWindow(EntryListPageResource.
                EntryList_Page_CreateEntryList_Id_Locator);
            base.WaitForElement(By.Id(EntryListPageResource.
                EnterList_Page_CorrectAnswer_Id_Locator_one));
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EnterList_Page_CorrectAnswer_Id_Locator_one);
            //Enter First Correct Score
            base.FillTextBoxByID(EntryListPageResource.
                EnterList_Page_CorrectAnswer_Id_Locator_one, EntryListPageResource.
                EnterList_Page_CorrectScore_Value);
            base.WaitForElement(By.Id(EntryListPageResource.
                EnterList_Page_CorrectAnswer_Id_Locator_two));
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EnterList_Page_CorrectAnswer_Id_Locator_two);
            //Enter Second Correct Score
            base.FillTextBoxByID(EntryListPageResource.
                EnterList_Page_CorrectAnswer_Id_Locator_two, EntryListPageResource.
                EnterList_Page_CorrectScore_Value);
            logger.LogMethodExit("EntryListPage",
                "EnterFirstTwoCorrectScoreValueOfEntryListQuestion",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter last Two Score Value
        /// </summary>
        private void EnterLastTwoCorrectScoreValueOfEntryListQuestion()
        {
            //Enter Last Two Correct Score Value
            logger.LogMethodEntry("EntryListPage",
                "EnterLastTwoCorrectScoreValueOfEntryListQuestion",
              base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(EntryListPageResource.
                EnterList_Page_CorrectAnswer_Id_Locator_three));
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EnterList_Page_CorrectAnswer_Id_Locator_three);
            //Enter Third Correct Score Value
            base.FillTextBoxByID(EntryListPageResource.
                EnterList_Page_CorrectAnswer_Id_Locator_three, EntryListPageResource.
                EnterList_Page_CorrectScore_Value);
            base.WaitForElement(By.Id(EntryListPageResource.
                EnterList_Page_CorrectAnswer_Id_Locator_four));
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EnterList_Page_CorrectAnswer_Id_Locator_four);
            //Enter fourth Correct score Value
            base.FillTextBoxByID(EntryListPageResource.
                EnterList_Page_CorrectAnswer_Id_Locator_four, EntryListPageResource.
                EnterList_Page_CorrectScore_Value);
            logger.LogMethodExit("EntryListPage",
                "EnterLastTwoCorrectScoreValueOfEntryListQuestion",
            base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter Incorrect Score Value
        /// </summary>
        private void EnterFirstTwoIncorrectScoreValueOfEntryListQuestion()
        {
            //Enter Incorrect Score Value
            logger.LogMethodEntry("EntryListPage",
                "EnterFirstTwoIncorrectScoreValueOfEntryListQuestion",
              base.isTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            base.SelectWindow(EntryListPageResource.
                EntryList_Page_CreateEntryList_Id_Locator);
            base.WaitForElement(By.Id(EntryListPageResource.
                EnterList_Page_IncorrectAnswer_Id_Locator_one));
            //Clear Text Box
            base.ClearTextByID((EntryListPageResource.
                EnterList_Page_IncorrectAnswer_Id_Locator_one));
            //Enter First Incorrect Score Value
            base.FillTextBoxByID(EntryListPageResource.
                EnterList_Page_IncorrectAnswer_Id_Locator_one, EntryListPageResource.
                EnterList_Page_IncorrectScore_Value);
            base.WaitForElement(By.Id(EntryListPageResource.
                EnterList_Page_IncorrectAnswer_Id_Locator_two));
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EnterList_Page_IncorrectAnswer_Id_Locator_two);
            //Enter Second Incorrect Score Value
            base.FillTextBoxByID(EntryListPageResource.
                EnterList_Page_IncorrectAnswer_Id_Locator_two, EntryListPageResource.
                EnterList_Page_IncorrectScore_Value);
            logger.LogMethodExit("EntryListPage",
                "EnterFirstTwoIncorrectScoreValueOfEntryListQuestion",
            base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter Last Two Incorrect Score value
        /// </summary>
        private void EnterLastTwoIncorrectScoreValueOfEntryListQuestion()
        {
            //Enter Last Two Incorrect Score Value
            logger.LogMethodEntry("EntryListPage",
                "EnterLastTwoIncorrectScoreValueOfEntryListQuestion",
              base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(EntryListPageResource.
                EnterList_Page_IncorrectAnswer_Id_Locator_three));
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EnterList_Page_IncorrectAnswer_Id_Locator_three);
            //Enter Third Incorrect Score Value
            base.FillTextBoxByID(EntryListPageResource.
                EnterList_Page_IncorrectAnswer_Id_Locator_three, EntryListPageResource.
                EnterList_Page_IncorrectScore_Value);
            base.WaitForElement(By.Id(EntryListPageResource.
                EnterList_Page_IncorrectAnswer_Id_Locator_four));
            //Clear Text Box
            base.ClearTextByID(EntryListPageResource.
                EnterList_Page_IncorrectAnswer_Id_Locator_four);
            //Enter Fourth Incorrect Score Value
            base.FillTextBoxByID(EntryListPageResource.
                EnterList_Page_IncorrectAnswer_Id_Locator_four, EntryListPageResource.
                EnterList_Page_IncorrectScore_Value);
            logger.LogMethodExit("EntryListPage",
                "EnterLastTwoIncorrectScoreValueOfEntryListQuestion",
            base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Storde Question Detials in Memory
        /// </summary>
        /// <param name="questionGuid">This is Question Name Generated by Guid</param>
        private void StoreQuestionDetailsInMemory(string questionGuid)
        {
            //Store Question Details in Memory
            logger.LogMethodEntry("EntryListPage", "storeQuestionDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
            //Save Question Properties in Memory
            Question newQuestion = new Question
            {
                Name = questionGuid.ToString(),
                QuestionType = Question.QuestionTypeEnum.EntryList,
                IsCreated = true,
            };
            newQuestion.StoreQuestionInMemory();
            logger.LogMethodExit("EntryListPage", "storeQuestionDetailsInMemory",
              base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Add Pallette Characters
        /// </summary>
        private void AddPalletteCharacters()
        {
            //Add pallette Characters
            logger.LogMethodEntry("EntryListPage", "AddPalletteCharacters",
            base.isTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            base.SelectWindow(EntryListPageResource.
                EntryList_Page_CreateEntryList_Id_Locator);
            //Add a character  
            this.ClickOnCharacterPalleteButton(EntryListPageResource.
                EntryList_Page_CharacterPallete_Xpath_Locator_one);
            //Add e character  
            this.ClickOnCharacterPalleteButton(EntryListPageResource.
                EntryList_Page_CharacterPallete_Xpath_Locator_two);
            //Add i character  
            this.ClickOnCharacterPalleteButton(EntryListPageResource.
                EntryList_Page_CharacterPallete_Xpath_Locator_three);
            //Add o character  
            this.ClickOnCharacterPalleteButton(EntryListPageResource.
                EntryList_Page_CharacterPallete_Xpath_Locator_Four);
            //Add u character  
            this.ClickOnCharacterPalleteButton(EntryListPageResource.
                EntryList_Page_CharacterPallete_Xpath_Locator_Five);
            logger.LogMethodExit("EntryListPage", "AddPalletteCharacters",
            base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Character Pallette
        /// </summary>
        /// <param name="locator">This is Locator of Pallete Character</param>
        private void ClickOnCharacterPalleteButton(string locator)
        {
            //Click on Character Pallette
            logger.LogMethodEntry("EntryListPage", "ClickOnCharacterPalleteButton",
            base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(locator));
            base.FocusOnElementByXPath(locator);
            //Get Button Property
            IWebElement getButtonProperty = base.GetWebElementPropertiesByXPath(locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("EntryListPage", "ClickOnCharacterPalleteButton",
            base.isTakeScreenShotDuringEntryExit);
        }
    }
}
