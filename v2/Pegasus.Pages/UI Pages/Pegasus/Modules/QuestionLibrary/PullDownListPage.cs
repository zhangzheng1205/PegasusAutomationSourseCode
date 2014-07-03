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
    /// This Class Handles PullDownListPage actions
    /// </summary>
    public class PullDownListPage : BasePage
    {

        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(PullDownListPage));


        /// <summary>
        /// Create Drop Down List Question
        /// </summary>
        public void CreateDropDownListQuestion()
        {
            //Create Drop Down List Question
            logger.LogMethodEntry("PullDownListPage", "CreateDropDownListQuestion",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Enter Question Title
                string questionDetails = this.EnterDropDownListQuestionTitle().ToString();
                //Enter Row and Column No
                this.EnterRowAndColumnValueOfDropDownListQuestion();
                //Click on View Source button and enter data
                this.ClickOnViewSourceAndEnterDataForQuestion(questionDetails);
                //Click on Add Answer Button
                this.ClickOnAddAnswerButtonOfDropDownListQuestion();
                //Enter Answer for First two
                this.EnterFirstTwoAnswerValueOfDropDownListQuestion();
                //Enter Answer for second two
                this.EnterLastTwoScoreValueOfDropDOwnListQuestion();
                //Click on Save and Close button
                this.ClickOnSaveAndCloseButtonOfDropDownListQuestion();
                //Store Question Details in Memory
                this.storeQuestionDetailsInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PullDownListPage", "CreateDropDownListQuestion",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Drop Down List Question Title
        /// </summary>
        /// <returns>Question title GUID</returns>
        private Guid EnterDropDownListQuestionTitle()
        {
            //Enter Drop Down List Question Title
            logger.LogMethodEntry("PullDownListPage", "EnterDropDownListQuestionTitle",
                base.isTakeScreenShotDuringEntryExit);
            Guid questionTitle = Guid.NewGuid();
            //Select Create Drop Down List Window
            base.SelectWindow(PullDownListPageResource.
                PullDownList_Page_CreateDropdownList_Window_Name);
            base.WaitForElement(By.Id(PullDownListPageResource.
                PullDownList_Page_EnterQuestionTitle_Id_Locator));
            //Enter Title
            base.FillTextBoxByID(PullDownListPageResource.
                PullDownList_Page_EnterQuestionTitle_Id_Locator, questionTitle.ToString());
            logger.LogMethodExit("PullDownListPage", "EnterDropDownListQuestionTitle",
           base.isTakeScreenShotDuringEntryExit);
            return questionTitle;
        }

        /// <summary>
        /// Enter Row and Column Value
        /// </summary>
        private void EnterRowAndColumnValueOfDropDownListQuestion()
        {
            //Enter Row and Column Value
            logger.LogMethodEntry("PullDownListPage",
                "EnterRowAndColumnValueOfDropDownListQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Create Drop Down List Window
            base.SelectWindow(PullDownListPageResource.
                    PullDownList_Page_CreateDropdownList_Window_Name);
            base.WaitForElement(By.Id(PullDownListPageResource.
                PullDownList_Page_EnterRowNo_Id_Locator));
            //Fous of Row text Box
            base.FillEmptyTextByID(PullDownListPageResource.
                PullDownList_Page_EnterRowNo_Id_Locator);
            base.ClearTextByID(PullDownListPageResource.
                PullDownList_Page_EnterRowNo_Id_Locator);
            //Fill Row Number
            base.FillTextBoxByID(PullDownListPageResource.
                PullDownList_Page_EnterRowNo_Id_Locator, PullDownListPageResource.
                PullDownList_Page_EnterRowAndColumn_Value);
            base.WaitForElement(By.Id(PullDownListPageResource.
                PullDownList_Page_EnterColumnNo_Id_Locator));
            //Focus on Column Text Box
            base.FillEmptyTextByID(PullDownListPageResource.
                PullDownList_Page_EnterColumnNo_Id_Locator);
            base.ClearTextByID(PullDownListPageResource.
                PullDownList_Page_EnterColumnNo_Id_Locator);
            //Enter Column Number
            base.FillTextBoxByID(PullDownListPageResource.
                PullDownList_Page_EnterColumnNo_Id_Locator, PullDownListPageResource.
                PullDownList_Page_EnterRowAndColumn_Value);
            logger.LogMethodExit("PullDownListPage",
                "EnterRowAndColumnValueOfDropDownListQuestion",
           base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click On View Source Button and Enter Text
        /// </summary>
        /// <param name="questionText">This is Question Text</param>
        private void ClickOnViewSourceAndEnterDataForQuestion(string questionText)
        {
            //Click on View Source Button and Fill data
            logger.LogMethodEntry("PullDownListPage",
                "ClickOnViewSourceAndEnterDataForQuestion",
                base.isTakeScreenShotDuringEntryExit);
            //Select Create Drop Down List Window
            base.SelectWindow(PullDownListPageResource.
                PullDownList_Page_CreateDropdownList_Window_Name);
            base.WaitForElement(By.Id(PullDownListPageResource.
                PullDownList_Page_ViewSource_Button_Id_Locator));
            //Click on View Source Button
            base.ClickButtonByID(PullDownListPageResource.
                PullDownList_Page_ViewSource_Button_Id_Locator);
            base.WaitForElement(By.Id(PullDownListPageResource.
                PullDownList_Page_EnterTextHTML_Id_Locator));
            //Fill the Data
            base.FillTextBoxByID(PullDownListPageResource.
                PullDownList_Page_EnterTextHTML_Id_Locator, questionText);
            base.ClickButtonByID(PullDownListPageResource.
              PullDownList_Page_ViewSource_Button_Id_Locator);
            logger.LogMethodExit("PullDownListPage",
                "ClickOnViewSourceAndEnterDataForQuestion",
           base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Add Answer Button
        /// </summary>
        private void ClickOnAddAnswerButtonOfDropDownListQuestion()
        {
            //Click on Add Answer Button
            logger.LogMethodEntry("PullDownListPage",
                "ClickOnAddAnswerButtonOfDropDownListQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Window Create Drop Down List Window
            base.SelectWindow(PullDownListPageResource.
                PullDownList_Page_CreateDropdownList_Window_Name);
            base.WaitForElement(By.Id(PullDownListPageResource.
                PullDownList_Page_AddAnswer_Button_Id_Locator));
            //Get Button Property
            IWebElement getAddAnswerButton = base.GetWebElementPropertiesById(
                PullDownListPageResource.PullDownList_Page_AddAnswer_Button_Id_Locator);
            //CLick on Button
            base.ClickByJavaScriptExecutor(getAddAnswerButton);
            logger.LogMethodExit("PullDownListPage",
                "ClickOnAddAnswerButtonOfDropDownListQuestion",
          base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Enter First Two Answer Values
        /// </summary>
        private void EnterFirstTwoAnswerValueOfDropDownListQuestion()
        {
            //Enter First Two Answer Values
            logger.LogMethodEntry("PullDownListPage",
                "EnterFirstTwoAnswerValueOfDropDownListQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Create Drop Down List Window
            base.SelectWindow(PullDownListPageResource.
                    PullDownList_Page_CreateDropdownList_Window_Name);
            base.WaitForElement(By.Id(PullDownListPageResource.
                PullDownList_Page_AnswerValue_One_Id_Locator));
            base.ClearTextByID(PullDownListPageResource.
                PullDownList_Page_AnswerValue_One_Id_Locator);
            //Enter First Answer Value
            base.FillTextBoxByID(PullDownListPageResource.
                PullDownList_Page_AnswerValue_One_Id_Locator, PullDownListPageResource.
                PulldownList_Page_AnswerScore_Value_One);
            base.WaitForElement(By.Id(PullDownListPageResource.
                PullDownList_Page_AnswerValue_Two_Id_Locator));
            //Clear Text Bix
            base.ClearTextByID(PullDownListPageResource.
                PullDownList_Page_AnswerValue_Two_Id_Locator);
            //Enter Second Answer Value
            base.FillTextBoxByID(PullDownListPageResource.
                PullDownList_Page_AnswerValue_Two_Id_Locator, PullDownListPageResource.
                PulldownList_Page_AnswerScore_Value_two);
            logger.LogMethodExit("PullDownListPage",
                "EnterFirstTwoAnswerValueOfDropDownListQuestion",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Last Two Answer Values
        /// </summary>
        private void EnterLastTwoScoreValueOfDropDOwnListQuestion()
        {
            //Enter Last Two Answer Value
            logger.LogMethodEntry("PullDownListPage",
                "EnterLastTwoScoreValueOfDropDOwnListQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for Text Box
            base.WaitForElement(By.Id(PullDownListPageResource.
                    PullDownList_Page_AnswerValue_Three_Id_Locator));
            base.ClearTextByID(PullDownListPageResource.
                PullDownList_Page_AnswerValue_Three_Id_Locator);
            //Enter Third Answer Value
            base.FillTextBoxByID(PullDownListPageResource.
                PullDownList_Page_AnswerValue_Three_Id_Locator, PullDownListPageResource.
                PulldownList_Page_AnswerScore_Value_three);
            base.WaitForElement(By.Id(PullDownListPageResource.
                PullDownList_Page_AnswerValue_Four_Id_Locator));
            //Clear Text Box
            base.ClearTextByID(PullDownListPageResource.
                PullDownList_Page_AnswerValue_Four_Id_Locator);
            //Enter Last Answer Value
            base.FillTextBoxByID(PullDownListPageResource.
                PullDownList_Page_AnswerValue_Four_Id_Locator, PullDownListPageResource.
                PulldownList_Page_AnswerScore_Value_four);
            logger.LogMethodExit("PullDownListPage",
                "EnterLastTwoScoreValueOfDropDOwnListQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Save and Close Button
        /// </summary>
        private void ClickOnSaveAndCloseButtonOfDropDownListQuestion()
        {
            //Click on Save and Close Button
            logger.LogMethodEntry("PullDownListPage",
                "ClickOnSaveAndCloseButtonOfDropDownListQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Create Drop Down List Window
            base.SelectWindow(PullDownListPageResource.
                PullDownList_Page_CreateDropdownList_Window_Name);
            base.WaitForElement(By.Id(PullDownListPageResource.
                PullDownList_Page_Save_Button_Id_Locator));
            //Get Button Property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById(PullDownListPageResource.
                PullDownList_Page_Save_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("PullDownListPage",
                "ClickOnSaveAndCloseButtonOfDropDownListQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Storde Question Detials in Memory
        /// </summary>
        /// <param name="questionGuid">This is Question Name Generated by Guid</param>
        private void storeQuestionDetailsInMemory(string questionGuid)
        {
            //Store Question Details in Memory
            logger.LogMethodEntry("PullDownListPage", "storeQuestionDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
            //Save Question Properties in Memory
            Question newQuestion = new Question
            {
                Name = questionGuid.ToString(),
                QuestionType = Question.QuestionTypeEnum.DropDownList,
                IsCreated = true,
            };
            newQuestion.StoreQuestionInMemory();
            logger.LogMethodExit("PullDownListPage", "storeQuestionDetailsInMemory",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Pallette Characters
        /// </summary>
        private void AddPalletteCharacters()
        {
            //Add pallette Characters
            logger.LogMethodEntry("PullDownListPage", "AddPalletteCharacters",
            base.isTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            base.SelectWindow(PullDownListPageResource.
                PullDownList_Page_CreateDropdownList_Window_Name);
            //Add a character  
            this.ClickOnCharacterPalleteButton(PullDownListPageResource.
                PullDownList_Page_CharacterPallete_Xpath_Locator_one);
            //Add e character  
            this.ClickOnCharacterPalleteButton(PullDownListPageResource.
                PullDownList_Page_CharacterPallete_Xpath_Locator_two);
            //Add i character  
            this.ClickOnCharacterPalleteButton(PullDownListPageResource.
                PullDownList_Page_CharacterPallete_Xpath_Locator_three);
            //Add o character  
            this.ClickOnCharacterPalleteButton(PullDownListPageResource.
                PullDownList_Page_CharacterPallete_Xpath_Locator_four);
            //Add u character  
            this.ClickOnCharacterPalleteButton(PullDownListPageResource.
                PullDownList_Page_CharacterPallete_Xpath_Locator_five);
            logger.LogMethodExit("PullDownListPage", "AddPalletteCharacters",
            base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Character Pallette
        /// </summary>
        /// <param name="locator">This is Locator for Pallete Character</param>
        private void ClickOnCharacterPalleteButton(string locator)
        {
            //Click on Character Pallette
            logger.LogMethodEntry("PullDownListPage", "ClickOnCharacterPalleteButton",
            base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(locator));
            base.FocusOnElementByXPath(locator);
            //Get Button Property
            IWebElement getButtonProperty = base.GetWebElementPropertiesByXPath(locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("PullDownListPage", "ClickOnCharacterPalleteButton",
           base.isTakeScreenShotDuringEntryExit);
        }
    }


}

