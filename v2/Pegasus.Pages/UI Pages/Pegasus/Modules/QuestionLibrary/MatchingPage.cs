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
    /// This Class Handles Matching Page Actions
    /// </summary>
    public class MatchingPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(MatchingPage));

        /// <summary>
        /// Create Matching Question
        /// </summary>
        public void CreateMatchingQuestion()
        {
            //Create Matching Question
            logger.LogMethodEntry("MatchingPage", "CreateMatchingQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create Matching Window
                this.SelectCreateMatchingWindow();
                //Create Question
                string questionDetails = this.EnterQuestionTitle().ToString();
                //Click on View Source Button and Enter data
                this.ClickOnViewSourceAndEnterDataForMatchingQuestion(questionDetails);
                //Click on Add Answer Button
                this.ClickOnAddAnswerButtonOfMatchingQuestion();
                //Enter Text Value For Matching Question
                this.EnterTextValueForMatchingQuestion();
                //Enter Text Value Matching for Matching Question
                this.EnterMatchingTextValueForMatchingQuestion();
                //Click On Save and Close Button
                this.ClickONSaveAndCloseButtonOfMatchingQuestion();
                //Store Question Details In Memory
                this.StoreQuestionDetailsInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MatchingPage", "CreateMatchingQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Create Matching' Window
        /// </summary>
        private void SelectCreateMatchingWindow()
        {
            //Select 'Create Matching' Window
            logger.LogMethodEntry("MatchingPage", "SelectCreateMatchingWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the window to load
            base.WaitUntilWindowLoads(MatchingPageResource.
                Matching_Page_CreateMatching_Window_Name);
            //Select Create Matching Window
            base.SelectWindow(MatchingPageResource.
                Matching_Page_CreateMatching_Window_Name);
            logger.LogMethodExit("MatchingPage", "SelectCreateMatchingWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Question Title
        /// </summary>
        /// <returns>Question Title Guid</returns>
        private Guid EnterQuestionTitle()
        {
            //Enter Question Title
            logger.LogMethodEntry("MatchingPage", "EnterQuestionTitle",
                base.IsTakeScreenShotDuringEntryExit);
            //Generate Question Title Guid
            Guid questionTitle = Guid.NewGuid();
            base.WaitForElement(By.Id(MatchingPageResource.
                Matching_Page_EnterQuestionTitle_Id_Locator));
            //Fill the Question Title
            base.FillTextBoxById(MatchingPageResource.
                Matching_Page_EnterQuestionTitle_Id_Locator, questionTitle.ToString());
            logger.LogMethodExit("MatchingPage", "EnterQuestionTitle",
                base.IsTakeScreenShotDuringEntryExit);
            return questionTitle;
        }

        /// <summary>
        /// Add Pallette Characters
        /// </summary>
        private void AddPalletteCharacters()
        {
            //Add Pallette Characters
            logger.LogMethodEntry("MatchingPage", "AddPalletteCharacters",
                base.IsTakeScreenShotDuringEntryExit);
            //Add a character
            this.ClickOnCharacterPalleteButton(MatchingPageResource.
                Matching_Page_CharacterPalletea_Xpath_Locator_one);
            //Add e character
            this.ClickOnCharacterPalleteButton(MatchingPageResource.
                Matching_Page_CharacterPalletee_Xpath_Locator_two);
            //Add i character
            this.ClickOnCharacterPalleteButton(MatchingPageResource.
                Matching_Page_CharacterPalletei_Xpath_Locator_three);
            //Add o character
            this.ClickOnCharacterPalleteButton(MatchingPageResource.
                Matching_Page_CharacterPalleteo_Xpath_Locator_four);
            //Add u character
            this.ClickOnCharacterPalleteButton(MatchingPageResource.
                Matching_Page_CharacterPalleteu_Xpath_Locator_five);
            logger.LogMethodExit("MatchingPage", "AddPalletteCharacters",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Character Pallette
        /// </summary>
        /// <param name="locator">This is Locator of Pallete Character</param>
        private void ClickOnCharacterPalleteButton(string locator)
        {
            //Click on Character Pallette
            logger.LogMethodEntry("MatchingPage", "ClickOnCharacterPalleteButton",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(locator));
            base.FocusOnElementByXPath(locator);
            //Get Button Property
            IWebElement getButtonProperty = base.GetWebElementPropertiesByXPath(locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("MatchingPage", "ClickOnCharacterPalleteButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on View Source Button and enter HTML Text
        /// </summary>
        /// <param name="questionText">This is Question text</param>
        private void ClickOnViewSourceAndEnterDataForMatchingQuestion
            (string questionText)
        {
            //Click On View Source Button and Enter Data
            logger.LogMethodEntry("MatchingPage",
                "ClickOnViewSourceAndEnterDataForEntryListQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Frame
            base.WaitForElement(By.Id(MatchingPageResource.
                Matching_Page_Frame_Id_Locator));
            base.SwitchToIFrame(MatchingPageResource.
                Matching_Page_Frame_Id_Locator);
            //Wait for view Source Button
            base.WaitForElement(By.Id(MatchingPageResource.
                Matching_Page_ViewSource_Button_Id_Locator));
            //Click on View Source Button
            base.ClickButtonById(MatchingPageResource.
                Matching_Page_ViewSource_Button_Id_Locator);
            base.WaitForElement(By.Id(MatchingPageResource.
                Matching_Page_EnterTextHTML_Id_Locator));
            //Enter data
            base.FillTextBoxById(MatchingPageResource.
                Matching_Page_EnterTextHTML_Id_Locator, questionText);
            //Click on View Source Button
            base.ClickButtonById(MatchingPageResource.
                Matching_Page_ViewSource_Button_Id_Locator);
            logger.LogMethodExit("MatchingPage",
                "ClickOnViewSourceAndEnterDataForEntryListQuestion",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Text Value For Matching Question
        /// </summary>
        private void EnterTextValueForMatchingQuestion()
        {
            //Enter Text Value For Matching Question
            logger.LogMethodEntry("MatchingPage",
                "EnterTextValueForMatchingQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            for (int initialCount = Convert.ToInt32(MatchingPageResource.
                Matching_Page_TextBox_InitialValue); initialCount <= Convert.ToInt32(
                MatchingPageResource.Matching_Page_TextBox_MaxValue); initialCount++)
            {
                //Wait For Element
                base.WaitForElement(By.Id(string.Format(MatchingPageResource.
                    Matching_Page_TextField_TextBox_Id_Locator, initialCount)));
                //Clear the Textbox
                base.ClearTextById(string.Format(MatchingPageResource.
                    Matching_Page_TextField_TextBox_Id_Locator, initialCount));
                //Fill the Text Box
                base.FillTextBoxById(string.Format(MatchingPageResource.
                    Matching_Page_TextField_TextBox_Id_Locator, initialCount),
                    MatchingPageResource.Matching_Page_EnterText_TextValue +
                    initialCount.ToString());
            }
            logger.LogMethodExit("MatchingPage",
                "EnterTextValueForMatchingQuestion",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Matching Text For Matching Question
        /// </summary>
        private void EnterMatchingTextValueForMatchingQuestion()
        {
            //Enter Matching Text For Matching Question
            logger.LogMethodEntry("MatchingPage",
                "EnterMatchingTextValueForMatchingQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            for (int initialCount = Convert.ToInt32(MatchingPageResource.
                Matching_Page_TextBox_InitialValue); initialCount <= Convert.ToInt32(
                MatchingPageResource.Matching_Page_TextBox_MaxValue); initialCount++)
            {
                //Wait for Element
                base.WaitForElement(By.Id(string.Format(MatchingPageResource.
                    Matching_Page_MatchingTextField_Id_Locator, initialCount)));
                //Clear the Text Box
                base.ClearTextById(string.Format(MatchingPageResource.
                    Matching_Page_MatchingTextField_Id_Locator, initialCount));
                //Fill the Texbox
                base.FillTextBoxById(string.Format(MatchingPageResource.
                    Matching_Page_MatchingTextField_Id_Locator, initialCount),
                    MatchingPageResource.Matching_Page_EnterMatchingText_TextValue
                    + initialCount.ToString());
            }
            logger.LogMethodExit("MatchingPage",
                "EnterMatchingTextValueForMatchingQuestion",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Answer Button
        /// </summary>
        private void ClickOnAddAnswerButtonOfMatchingQuestion()
        {
            //Click On Add Answer Button
            logger.LogMethodEntry("MatchingPage", "ClickOnAddAnswerButtonOfMatchingQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Matching Window
            this.SelectCreateMatchingWindow();
            base.WaitForElement(By.Id(MatchingPageResource.
                Matching_Page_AddAnswer_Button_Id_Locator));
            //Get Button Property
            IWebElement getAddAnswerButton = base.GetWebElementPropertiesById(
                MatchingPageResource.Matching_Page_AddAnswer_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getAddAnswerButton);
            logger.LogMethodExit("MatchingPage", "ClickOnAddAnswerButtonOfMatchingQuestion",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save and Close button
        /// </summary>
        private void ClickONSaveAndCloseButtonOfMatchingQuestion()
        {
            //Click on Save and Close Button
            logger.LogMethodEntry("MatchingPage", "ClickONSaveAndCloseButtonOfMatchingQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Matching Window            
            base.WaitForElement(By.Id(MatchingPageResource.
                Matching_Page_Save_Button_Id_Locator));
            //Get Button property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById(MatchingPageResource.
                Matching_Page_Save_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("MatchingPage", "ClickONSaveAndCloseButtonOfMatchingQuestion",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Storde Question Detials in Memory
        /// </summary>
        /// <param name="questionGuid">This is Question Name Generated by Guid</param>
        private void StoreQuestionDetailsInMemory(string questionGuid)
        {
            //Store Question Details in Memory
            logger.LogMethodEntry("MatchingPage", "storeQuestionDetailsInMemory",
               base.IsTakeScreenShotDuringEntryExit);
            //Save Question Properties in Memory
            Question newQuestion = new Question
            {
                Name = questionGuid.ToString(),
                QuestionType = Question.QuestionTypeEnum.Matching,
                IsCreated = true,
            };
            newQuestion.StoreQuestionInMemory();
            logger.LogMethodExit("MatchingPage", "storeQuestionDetailsInMemory",
              base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
