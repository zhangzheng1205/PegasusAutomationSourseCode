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
    /// This class contains "File Upload" Page Action Details
    /// </summary>
    public class FileUploadPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(FileUploadPage));

        /// <summary>
        /// Create 'File Upload' Question
        /// </summary>
        public void CreateFileUploadQuestion()
        {
            //Create 'File Upload' Question
            logger.LogMethodEntry("FileUploadPage", "CreateFileUploadQuestion",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the 'Create File Upload' Window
                this.SelectCreateFileUploadWindow();
                //Enter the Question title
                string questionDetails = this.EnterQuestionTitle().ToString();
                //Click on the HTML ViewSource button
                this.ClickHTMLViewSourceButton();
                //Enter the Question Text
                this.EnterQuestionText(questionDetails);
                //Again click on the viewsourse
                this.ClickHTMLViewSourceButton();
                //Append with character pallets
                this.AddCharactersFromCharacterPallette();
                //Click on the 'Add Edit Answer' tab
                this.ClilckOnAddEditAnswer();
                //Add Max score
                this.EnterScoreForQuestion();
                //Click on Save and Return
                this.ClickOnSaveAndReturnButton();
                //Store the Question in Memory
                this.StoreQuestionInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("FileUploadPage", "CreateFileUploadQuestion",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Question In Memory
        /// </summary>
        /// <param name="questionTitle">This is Question Title</param>
        private void StoreQuestionInMemory(string questionTitle)
        {
            //Store Question In Memory
            logger.LogMethodEntry("FileUploadPage", "StoreQuestionInMemory",
                base.isTakeScreenShotDuringEntryExit);
            Question question = new Question
            {
                Name = questionTitle,
                QuestionType = Question.QuestionTypeEnum.FileUpload,
                IsCreated = true
            }; question.StoreQuestionInMemory();
            logger.LogMethodExit("FileUploadPage", "StoreQuestionInMemory",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clilck On Add/Edit Answer
        /// </summary>
        private void ClilckOnAddEditAnswer()
        {
            //Click On Add/Edit Answer
            logger.LogMethodEntry("FileUploadPage", "ClilckOnAddEditAnswer",
                base.isTakeScreenShotDuringEntryExit);
            base.SwitchToDefaultPageContent();
            //Add Answer
            base.WaitForElement(By.Id(FileUploadPageResource.
                FileUploadPage_Add_Edit_Answer_Tab_Id_Locator));
            base.ClickButtonById(FileUploadPageResource.
                FileUploadPage_Add_Edit_Answer_Tab_Id_Locator);
            logger.LogMethodExit("FileUploadPage", "ClilckOnAddEditAnswer",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save And Return Button
        /// </summary>
        private void ClickOnSaveAndReturnButton()
        {
            //Click On Save And Return Button
            logger.LogMethodEntry("FileUploadPage", "ClickOnSaveAndReturnButton",
                base.isTakeScreenShotDuringEntryExit);
            base.SwitchToDefaultPageContent();
            base.WaitForElement(By.Id(FileUploadPageResource.
                FileUploadPage_SaveAndReturn_Id_Locator));
            //Click On Save and Return Button
            base.ClickButtonById(FileUploadPageResource.
                FileUploadPage_SaveAndReturn_Id_Locator);
            logger.LogMethodExit("FileUploadPage", "ClickOnSaveAndReturnButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Score For Question
        /// </summary>
        private void EnterScoreForQuestion()
        {
            //Enter Score For Question
            logger.LogMethodEntry("FileUploadPage", "EnterScoreForQuestion",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(FileUploadPageResource.
                FileUploadPage_Question_MaxScore_Id_Locator));
            //Enter Score For Question
            base.FillTextBoxById(FileUploadPageResource.
                FileUploadPage_Question_MaxScore_Id_Locator, FileUploadPageResource.
                FileUploadPage_Question_MaxScore_Value);
            logger.LogMethodExit("FileUploadPage", "EnterScoreForQuestion",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Question Text
        /// </summary>
        /// <param name="questionText">This is Question Text</param>
        private void EnterQuestionText(string questionText)
        {
            //Enter Question Text
            logger.LogMethodEntry("FileUploadPage", "EnterQuestionText",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the Question Text Area
            base.WaitForElement(By.Id(FileUploadPageResource.
                FileUploadPage_Question_HTML_TextArea_Id_Locator));
            base.FillTextBoxById(FileUploadPageResource.
                FileUploadPage_Question_HTML_TextArea_Id_Locator, questionText);
            logger.LogMethodExit("FileUploadPage", "EnterQuestionText",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Characters From Character Pallette
        /// </summary>
        private void AddCharactersFromCharacterPallette()
        {
            //Add Characters From Character Pallette
            logger.LogMethodEntry("FileUploadPage", "AddCharactersFromCharacterPallette",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(FileUploadPageResource.
                FileUploadPage_CharacterPallette_a_Id_Locator));
            //Add a character
            base.ClickButtonById(FileUploadPageResource.
                FileUploadPage_CharacterPallette_a_Id_Locator);
            //Add e character
            base.ClickButtonById(FileUploadPageResource.
                FileUploadPage_CharacterPallette_e_Id_Locator);
            //Add i character
            base.ClickButtonById(FileUploadPageResource.
                FileUploadPage_CharacterPallette_i_Id_Locator);
            //Add o character
            base.ClickButtonById(FileUploadPageResource.
                FileUploadPage_CharacterPallette_o_Id_Locator);
            //Add u character
            base.ClickButtonById(FileUploadPageResource.
                FileUploadPage_CharacterPallette_u_Id_Locator);
            logger.LogMethodExit("FileUploadPage", "AddCharactersFromCharacterPallette",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click HTML 'View Source' Button
        /// </summary>
        private void ClickHTMLViewSourceButton()
        {
            //Click HTML 'View Source' Button
            logger.LogMethodEntry("FileUploadPage", "ClickHTMLViewSourceButton",
                base.isTakeScreenShotDuringEntryExit);
            base.SwitchToDefaultPageContent();
            //Wait for the Frame
            base.WaitForElement(By.Id(FileUploadPageResource.
                FileUploadPage_HTMLEditor_Frame_Id_Locator));
            base.SwitchToIFrame(FileUploadPageResource.
                FileUploadPage_HTMLEditor_Frame_Id_Locator);
            //Wait for the ViewSource button
            base.WaitForElement(By.Id(FileUploadPageResource.
                FileUploadPage_HTMLEditor_ViewSource_Button_Id_Locator));
            base.ClickButtonById(FileUploadPageResource.
                FileUploadPage_HTMLEditor_ViewSource_Button_Id_Locator);
            logger.LogMethodExit("FileUploadPage", "ClickHTMLViewSourceButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Create File Upload' Window
        /// </summary>
        private void SelectCreateFileUploadWindow()
        {
            //Select 'Create File Upload' Window
            logger.LogMethodEntry("FileUploadPage", "SelectCreateFileUploadWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the window to load
            base.WaitUntilWindowLoads(FileUploadPageResource.
                FileUploadPage_CreateFileUpload_Window_Title);
            base.SelectWindow(FileUploadPageResource.
                FileUploadPage_CreateFileUpload_Window_Title);
            logger.LogMethodExit("FileUploadPage", "SelectCreateFileUploadWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Question Title
        /// </summary>
        /// <returns>Question Title Guid</returns>
        private Guid EnterQuestionTitle()
        {
            //Enter Question Title
            logger.LogMethodEntry("FileUploadPage", "EnterQuestionTitle",
                base.isTakeScreenShotDuringEntryExit);            
            //Generate Question Title Guid
            Guid questionTitle = Guid.NewGuid();
            base.WaitForElement(By.Id(FileUploadPageResource.
                FileUploadPage_Question_Label_Id_Locator));
            //Fill the Question Title
            base.FillTextBoxById(FileUploadPageResource.
                FileUploadPage_Question_Label_Id_Locator, questionTitle.ToString());
            logger.LogMethodExit("FileUploadPage", "EnterQuestionTitle",
                base.isTakeScreenShotDuringEntryExit);
            return questionTitle;
        }
    }
}
