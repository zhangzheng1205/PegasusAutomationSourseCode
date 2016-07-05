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
    /// This class contains "Fill In The Blanks" Page Action Details
    /// </summary>
    public class FillInTheBlanksPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(FillInTheBlanksPage));
        
        /// <summary>
        /// Create 'Fill In The Blanks' Question
        /// </summary>
        public void CreateFillInTheBlanksQuestion()
        {
            //Create 'Fill In The Blanks' Question
            logger.LogMethodEntry("FillInTheBlanksPage", "CreateFillInTheBlanksQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Window
                this.SelectCreateFillInTheBlanksWindow();
                //Create Question
                string questionDetails = this.EnterQuestionTitle().ToString();
                //Add Blank Field
                this.AddBlankFieldAtTop();
                //Add Text for the Question
                this.AddTextForQuestionAndBlankAtTop(questionDetails +
                    FillInTheBlanksPageResource.FillInTheBlanksPage_Space_Value);
                //Add Text Field
                this.AddTextFieldAtTop();
                Thread.Sleep(Convert.ToInt32(FillInTheBlanksPageResource.
                    FillInTheBlanksPage_WaitTime_Value));
                //Add Text for the Blank
                this.AddTextForQuestionAndBlankAtTop(questionDetails);                
                //Click on the 'Add Score And Feedback' tab
                this.ClickOnAddScoreAndFeedBackTab();
                //Select Partial Grading option
                this.SelectPartialGradingOption();
                //Save the Question
                this.ClickOnSaveAndReturnButton();
                //Store the Question in Memory
                this.StoreQuestionInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("FillInTheBlanksPage", "CreateFillInTheBlanksQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        public void CreateFillInBlankAtActivityCreation()
        {
          
            //Create Question
            string questionDetails = this.EnterQuestionTitle().ToString();
            Guid activity = Guid.NewGuid();
            string randomValue = activity.ToString().Split('-')[0];
            //Add Blank Field
            this.AddBlankFieldAtTop();
            //Add Text for the Question
            this.AddTextForQuestionAndBlankAtTop("Answer");
            //Add Text Field
            this.AddTextFieldAtTop();
            Thread.Sleep(Convert.ToInt32(FillInTheBlanksPageResource.
                FillInTheBlanksPage_WaitTime_Value));
            //Add Text for the Blank
            this.AddTextForQuestionAndBlankAtTop("The answer to " + randomValue + " question is ");
            //Click on the 'Add Score And Feedback' tab
            this.ClickOnAddScoreAndFeedBackTab();
            //Select Partial Grading option
            this.SelectPartialGradingOption();
            //Save the Question
            this.ClickOnSaveAndReturnButton();


        }

        /// <summary>
        /// Store Question In Memory
        /// </summary>
        /// <param name="questionTitle">This is Question Title</param>
        private void StoreQuestionInMemory(string questionTitle)
        {
            //Store Question In Memory
            logger.LogMethodEntry("FillInTheBlanksPage", "StoreQuestionInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            Question question = new Question
            {
                Name = questionTitle,
                QuestionType = Question.QuestionTypeEnum.FillInTheBlank,
                IsCreated = true
            }; question.StoreQuestionInMemory();
            logger.LogMethodExit("FillInTheBlanksPage", "StoreQuestionInMemory",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Text For Question And Blank At Top
        /// </summary>
        /// <param name="textToEnterInTextField">This is Text to Enter in Text Field</param>
        private void AddTextForQuestionAndBlankAtTop(string textToEnterInTextField)
        {
            logger.LogMethodEntry("FillInTheBlanksPage", "AddTextForQuestionAndBlankAtTop",
                base.IsTakeScreenShotDuringEntryExit);
            //Add text for blank
            base.WaitForElement(By.Id(FillInTheBlanksPageResource.
                FillInTheBlanksPage_TextAndBlank_Field_AtTop_ID_Locator));
            base.FillTextBoxById(FillInTheBlanksPageResource.
                FillInTheBlanksPage_TextAndBlank_Field_AtTop_ID_Locator, textToEnterInTextField);
            logger.LogMethodExit("FillInTheBlanksPage", "AddTextForQuestionAndBlankAtTop",
                base.IsTakeScreenShotDuringEntryExit);
        }
                

        /// <summary>
        /// Add Text Field At Top
        /// </summary>
        private void AddTextFieldAtTop()
        {
            //Add Text Field At Top
            logger.LogMethodEntry("FillInTheBlanksPage", "AddTextFieldAtTop",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the Add Text link
            base.WaitForElement(By.XPath(FillInTheBlanksPageResource.
                FillInTheBlanksPage_AddText_Link_XPath_Locator));
            IWebElement getAddTextField = base.GetWebElementPropertiesByXPath
                (FillInTheBlanksPageResource.
                FillInTheBlanksPage_AddText_Link_XPath_Locator);
            base.ClickByJavaScriptExecutor(getAddTextField);
            //Wait for the Add Text Drop Down
            base.WaitForElement(By.Id(FillInTheBlanksPageResource.
                FillInTheBlanksPage_AddBlank_AddText_DropDown_Div_Id_Locator));  
            IWebElement getAddTopLink=base.GetWebElementPropertiesByPartialLinkText
                (FillInTheBlanksPageResource.
                FillInTheBlanksPage_AddAtTop_PartialLink_Text_Locator);
            //Click on the 'Add at Top' option
            base.ClickByJavaScriptExecutor(getAddTopLink);
            logger.LogMethodExit("FillInTheBlanksPage", "AddTextFieldAtTop",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Blank Field At Top
        /// </summary>
        private void AddBlankFieldAtTop()
        {
            //Add Blank Field At Top
            logger.LogMethodEntry("FillInTheBlanksPage", "AddBlankFieldAtTop",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(FillInTheBlanksPageResource.
                FillInTheBlanksPage_AddBlank_Link_XPath_Locator));
            IWebElement getAddBlankLink = base.GetWebElementPropertiesByXPath
                (FillInTheBlanksPageResource.
                FillInTheBlanksPage_AddBlank_Link_XPath_Locator);
            base.ClickByJavaScriptExecutor(getAddBlankLink);
            //Wait for the 'Add Blank' Drop Down
            base.WaitForElement(By.Id(FillInTheBlanksPageResource.
                FillInTheBlanksPage_AddBlank_AddText_DropDown_Div_Id_Locator));
            IWebElement getAddTopLink = base.GetWebElementPropertiesByPartialLinkText
                (FillInTheBlanksPageResource.
                FillInTheBlanksPage_AddAtTop_PartialLink_Text_Locator);
            //Click on the 'Add at Top' option
            base.ClickByJavaScriptExecutor(getAddTopLink);
            logger.LogMethodExit("FillInTheBlanksPage", "AddBlankFieldAtTop",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Pallette Characters
        /// </summary>
        private void AddPalletteCharacters()
        {
            logger.LogMethodEntry("FillInTheBlanksPage", "AddPalletteCharacters",
                base.IsTakeScreenShotDuringEntryExit);
            //Add Pallette Characters
            base.WaitForElement(By.Id(FillInTheBlanksPageResource.
                FillInTheBlanksPage_CharacterPallette_a_Id_Locator));
            IWebElement getCharactera = base.GetWebElementPropertiesById
                (FillInTheBlanksPageResource.
                FillInTheBlanksPage_CharacterPallette_a_Id_Locator);
            //Add a character
            base.ClickByJavaScriptExecutor(getCharactera);
            IWebElement getCharactere=base.GetWebElementPropertiesById
                (FillInTheBlanksPageResource.
                FillInTheBlanksPage_CharacterPallette_e_Id_Locator);
            //Add e character
            base.ClickByJavaScriptExecutor(getCharactere);
            IWebElement getCharacteri=base.GetWebElementPropertiesById
                (FillInTheBlanksPageResource.
                FillInTheBlanksPage_CharacterPallette_i_Id_Locator);
            //Add i character
            base.ClickByJavaScriptExecutor(getCharacteri);
            IWebElement getCharactero=base.GetWebElementPropertiesById
                (FillInTheBlanksPageResource.
                FillInTheBlanksPage_CharacterPallette_o_Id_Locator);
            //Add o character
            base.ClickByJavaScriptExecutor(getCharactero);
            IWebElement getCharacteru=base.GetWebElementPropertiesById
                (FillInTheBlanksPageResource.
                FillInTheBlanksPage_CharacterPallette_u_Id_Locator);
            //Add u character
            base.ClickByJavaScriptExecutor(getCharacteru);
            logger.LogMethodExit("FillInTheBlanksPage", "AddPalletteCharacters",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Question Title
        /// </summary>
        /// <returns>Question Title Guid</returns>
        private Guid EnterQuestionTitle()
        {
            //Enter Question Title
            logger.LogMethodEntry("FillInTheBlanksPage", "EnterQuestionTitle",
                base.IsTakeScreenShotDuringEntryExit);
            //Generate Question Title Guid
            Guid questionTitle = Guid.NewGuid();
            base.WaitForElement(By.Id(FillInTheBlanksPageResource.
                FillInTheBlanksPage_Question_Label_Id_Locator));
            //Fill the Question Title
            base.FillTextBoxById(FillInTheBlanksPageResource.
                FillInTheBlanksPage_Question_Label_Id_Locator, questionTitle.ToString());
            logger.LogMethodExit("FillInTheBlanksPage", "EnterQuestionTitle",
                base.IsTakeScreenShotDuringEntryExit);
            return questionTitle;
        }

        /// <summary>
        /// Select 'Create Fill In The Blanks' Window
        /// </summary>
        private void SelectCreateFillInTheBlanksWindow()
        {
            //Select 'Create File Upload' Window
            logger.LogMethodEntry("FillInTheBlanksPage", "SelectCreateFillInTheBlanksWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the window to load
            base.WaitUntilWindowLoads(FillInTheBlanksPageResource.
                FillInTheBlanksPage_CreateFillInTheBlank_Window_Title);
            base.SelectWindow(FillInTheBlanksPageResource.
                FillInTheBlanksPage_CreateFillInTheBlank_Window_Title);
            logger.LogMethodExit("FillInTheBlanksPage", "SelectCreateFillInTheBlanksWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save And Return Button
        /// </summary>
        private void ClickOnSaveAndReturnButton()
        {
            //Click On Save And Return Button
            logger.LogMethodEntry("FillInTheBlanksPage", "ClickOnSaveAndReturnButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Switch to the Parent Window
           // base.SwitchToDefaultPageContent();
            //Wait and click on the Save Button
            base.WaitForElement(By.Id(FillInTheBlanksPageResource.
                FillInTheBlanksPage_SaveAndReturn_Id_Locator));
            IWebElement getSaveReturnButton = base.GetWebElementPropertiesById
                (FillInTheBlanksPageResource.
                FillInTheBlanksPage_SaveAndReturn_Id_Locator);
            base.ClickByJavaScriptExecutor(getSaveReturnButton);
            bool addAndCloseButton = base.IsElementPresent(By.Id("_ctl0_PopupPageContent_imgBtnAdd_Close"), 10);
            if (addAndCloseButton)
                base.GetWebElementPropertiesById("_ctl0_PopupPageContent_imgBtnAdd_Close").Click();
            logger.LogMethodExit("FillInTheBlanksPage", "ClickOnSaveAndReturnButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'Add Score And FeedBack' Tab
        /// </summary>
        private void ClickOnAddScoreAndFeedBackTab()
        {
            //Click On 'Add Score And FeedBack' Tab
            logger.LogMethodEntry("FillInTheBlanksPage", "ClickOnAddScoreAndFeedBackTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the 'Add Score And FeedBack'
            base.WaitForElement(By.Id(FillInTheBlanksPageResource.
                FillInTheBlanksPage_AddScoreAndFeedback_Tab_Id_Locator));
            IWebElement getScoreFeedback = base.GetWebElementPropertiesById
                (FillInTheBlanksPageResource.
                FillInTheBlanksPage_AddScoreAndFeedback_Tab_Id_Locator);
            base.ClickByJavaScriptExecutor(getScoreFeedback);
            logger.LogMethodExit("FillInTheBlanksPage", "ClickOnAddScoreAndFeedBackTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Partial Grading' Option
        /// </summary>
        private void SelectPartialGradingOption()
        {
            //Select 'Partial Grading' Option
            logger.LogMethodEntry("FillInTheBlanksPage", "SelectPartialGradingOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the 'Partial Grading' Radio Button
            base.WaitForElement(By.Id(FillInTheBlanksPageResource.
                FillInTheBlanksPage_PartialGrading_RadioButton_Id_Locator));
            IWebElement getPartialRadioButton=base.GetWebElementPropertiesById
                (FillInTheBlanksPageResource.
                FillInTheBlanksPage_PartialGrading_RadioButton_Id_Locator);
            base.ClickByJavaScriptExecutor(getPartialRadioButton);
            logger.LogMethodExit("FillInTheBlanksPage", "SelectPartialGradingOption",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
