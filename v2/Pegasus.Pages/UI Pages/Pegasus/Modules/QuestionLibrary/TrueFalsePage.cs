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
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.QuestionLibrary;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Create TrueFalse Question Type.
    /// </summary>
    public class TrueFalsePage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(TrueFalsePage));

        /// <summary>
        /// Create Fill in the Blank Question.
        /// </summary>       
        public void CreateFillInTheBlankQuestion()
        {
            // Create Fill in the Blank Question
            Logger.LogMethodEntry("TrueFalsePage", "CreateFIBQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
            //Intialize Guid for question
            Guid questionTrueFalse = Guid.NewGuid();
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(TrueFalsePageResource.
                    TrueFalse_Page_QuestionName_Title_Id_Locator));
                //Fill the Question name title text
                base.FillTextBoxById(TrueFalsePageResource.
                    TrueFalse_Page_QuestionName_Title_Id_Locator,
                    questionTrueFalse.ToString());
                Thread.Sleep(Convert.ToInt32(TrueFalsePageResource.
                TrueFalse_Page_Activity_SaveAndClose_TimeValue));
                //Store the Question
                this.StoreTheQuestion(questionTrueFalse);
                //Fill the Discription for HTML Editor
                this.FillTheDiscriptionForHTMLEditor();
                //Click The Activity Save Button
                this.ClickTheActivitySaveButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TrueFalsePage", "CreateFIBQuestion",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store the Question.
        /// </summary>
        /// <param name="questionTrueFalse">
        /// This is Question true/false type Guid.</param>
        private void StoreTheQuestion(Guid questionTrueFalse)
        {
            // Store the Question
            Logger.LogMethodEntry("TrueFalsePage", "StoreTheQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
            //Store the TrueFalse Question
            Question newQuestionType = new Question
            {
                Name = questionTrueFalse.ToString(),
                QuestionType = Question.QuestionTypeEnum.TrueFalse,
                IsCreated = true,
            };
            newQuestionType.StoreQuestionInMemory();
            Logger.LogMethodExit("TrueFalsePage", "StoreTheQuestion",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill the Discription for HTML Editor.
        /// </summary>
        private void FillTheDiscriptionForHTMLEditor()
        {
            //Fill the Discription for HTML Editor
            Logger.LogMethodEntry("TrueFalsePage",
                "FillTheDiscriptionForHTMLEditor",
                   base.IsTakeScreenShotDuringEntryExit);
            //Intialize Guid for question
            Guid questionTrueFalse = Guid.NewGuid();
            //Select  the frame
            base.SwitchToIFrame(TrueFalsePageResource.
                TrueFalse_Page_HTMLEditorQues_Frame_Id_Locator);
            // Click on ShowHTML button
            base.WaitForElement(By.Id(TrueFalsePageResource.
            TrueFalse_Page_HTMLEditorQues_ViewsourceButton_Id_Locator));
            IWebElement getHtmldesc = base.
                GetWebElementPropertiesById(TrueFalsePageResource.
            TrueFalse_Page_HTMLEditorQues_ViewsourceButton_Id_Locator);
            //Click the ViewSource button
            base.ClickByJavaScriptExecutor(getHtmldesc);
            //Wait for the element
            base.WaitForElement(By.Id(TrueFalsePageResource.
                TrueFalse_Page_QuestionDiscription_Id_Locator));
            //Fill the discription
            base.FillTextBoxById(TrueFalsePageResource.
                TrueFalse_Page_QuestionDiscription_Id_Locator,
                questionTrueFalse.ToString());
            //Click the ViewSource button
            base.ClickByJavaScriptExecutor(getHtmldesc);
            Logger.LogMethodExit("TrueFalsePage",
                "FillTheDiscriptionForHTMLEditor",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Activity Save Button.
        /// </summary>
        private void ClickTheActivitySaveButton()
        {
            //Click The Activity Save Button
            Logger.LogMethodEntry("TrueFalsePage", "ClickTheActivitySaveButton",
                   base.IsTakeScreenShotDuringEntryExit);
            //Select the window
            base.SelectWindow(TrueFalsePageResource.
                TrueFalse_Page_CreateNewQues_Window_Name);
            base.SwitchToIFrame(TrueFalsePageResource.
                TrueFalse_Page_Question_Frame_ID_Locator);
            //Wait for the element
            base.WaitForElement(By.Id(TrueFalsePageResource.
               TrueFalse_Page_SaveAndClose_Ques_Button_Id_Locator));
            base.FocusOnElementById(TrueFalsePageResource.
               TrueFalse_Page_SaveAndClose_Ques_Button_Id_Locator);
            //Click the "SaveAndClose" button
            base.ClickButtonById(TrueFalsePageResource.
               TrueFalse_Page_SaveAndClose_Ques_Button_Id_Locator);
            //Select the frame
            new CustomContentPage().SelectCurriculumFrame();
            base.WaitForElement(By.Id(TrueFalsePageResource.
               TrueFalse_Page_Activity_SaveAndClose_Button_Id_Locator));
            //Click the "SaveAndClose" button
            base.ClickButtonById(TrueFalsePageResource.
               TrueFalse_Page_Activity_SaveAndClose_Button_Id_Locator);
            Thread.Sleep(Convert.ToInt32(TrueFalsePageResource.
                TrueFalse_Page_Activity_SaveAndClose_Mesg_TimeValue));
            Logger.LogMethodExit("TrueFalsePage", "ClickTheActivitySaveButton",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create MyTest Question.
        /// </summary>
        public void CreateMyTestQuestion()
        {
            //Create MyTest Question
            Logger.LogMethodEntry("TrueFalsePage", "CreateMyTestQuestion",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generate Guid for question
                Guid questionNameGuid = Guid.NewGuid();
                //Select Window
                this.SelectTrueAndFalseWindow();
                //Wait for the element
                base.WaitForElement(By.Id(TrueFalsePageResource.
                    TrueFalse_Page_QuestionName_Title_Id_Locator));
                base.FocusOnElementById(TrueFalsePageResource.
                        TrueFalse_Page_QuestionName_Title_Id_Locator);
                //Fill the Question name title text
                base.FillTextBoxById(TrueFalsePageResource.
                    TrueFalse_Page_QuestionName_Title_Id_Locator,
                    questionNameGuid.ToString());
                Thread.Sleep(Convert.ToInt32(TrueFalsePageResource.
                TrueFalse_Page_Activity_SaveAndClose_TimeValue));
                //Fill the Discription for HTML Editor
                this.FillTheDiscriptionForHTMLEditor();
                //Select Window
                this.SelectTrueAndFalseWindow();
                base.WaitForElement(By.Id(TrueFalsePageResource.
                TrueFalse_Page_AddAnswer_Button_Id_Locator));
                IWebElement getAddTextButton = base.GetWebElementPropertiesById
                    (TrueFalsePageResource.
                TrueFalse_Page_AddAnswer_Button_Id_Locator);
                base.ClickByJavaScriptExecutor(getAddTextButton);
                //Click Ques SaveAndClose Button
                this.ClickQuesSaveAndCloseButton();
                //Wait for 'True/False' question window to close
                base.IsPopUpClosed(Convert.ToInt32(TrueFalsePageResource.
                    TrueFalse_Page_Window_Count));
                //Store the Question
                this.StoreTheQuestion(questionNameGuid);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TrueFalsePage", "CreateMyTestQuestion",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select True And False Window.
        /// </summary>
        private void SelectTrueAndFalseWindow()
        {
            //This is logger entry
            Logger.LogMethodExit("TrueFalsePage", "SelectTrueAndFalseWindow",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for pop up to load
            base.WaitUntilWindowLoads(TrueFalsePageResource.
                TrueFalse_Page_QuestionName_TF_Window_Name);
            //Select window
            base.SelectWindow(TrueFalsePageResource.
                TrueFalse_Page_QuestionName_TF_Window_Name);
            //This is logger exit
            Logger.LogMethodExit("TrueFalsePage", "SelectTrueAndFalseWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create True/False Question.
        /// </summary>
        public void CreateTrueFalseQuestion()
        {
            //Create True/False Question
            Logger.LogMethodEntry("TrueFalsePage", "CreateTrueFalseQuestion",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {


                //Enter Question Title
                Guid questionTrueFalse = this.EnterQuestionTitle();
                //Store the Question
                this.StoreTheQuestion(questionTrueFalse);
                //Fill the Discription for HTML Editor
                this.FillTheDiscriptionForHTMLEditor();
                //Enter Feedback
                this.EnterFeedback();
                //Select Window
                new SelectQuestionTypePage().SelectCreateNewQuestionWindow();
                //Wait for the element
                base.WaitForElement(By.Id(TrueFalsePageResource.
                   TrueFalse_Page_SaveAndClose_Ques_Button_Id_Locator));
                base.FocusOnElementById(TrueFalsePageResource.
                   TrueFalse_Page_SaveAndClose_Ques_Button_Id_Locator);
                //Get web element
                IWebElement getSaveCloseButton = base.GetWebElementPropertiesById
                    (TrueFalsePageResource.
                    TrueFalse_Page_SaveAndClose_Ques_Button_Id_Locator);
                //Click the "SaveAndClose" button
                base.ClickByJavaScriptExecutor(getSaveCloseButton);
                Thread.Sleep(Convert.ToInt32(TrueFalsePageResource.
                TrueFalse_Page_Activity_SaveAndClose_TimeValue));
                //Click on Add and Close
                this.ClickonAddandClose();
                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TrueFalsePage", "CreateTrueFalseQuestion",
                 base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Create a new True/False Question.
        /// </summary>
        public void CreateNewTrueFalseQuestion()
        {
            //Create a new True/False Question
            Logger.LogMethodEntry("TrueFalsePage", "CreateNewTrueFalseQuestion",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Enter Question Title
                Guid questionTrueFalse = this.EnterQuestionTitle();
                //Store the Question
                this.StoreTheQuestion(questionTrueFalse);
                //Fill the Discription for HTML Editor
                this.FillTheDiscriptionForHTMLEditor();
                //Enter Feedback
                this.EnterFeedback();
              
                //Wait for the element
                base.WaitForElement(By.Id(TrueFalsePageResource.
                   TrueFalse_Page_SaveAndClose_Ques_Button_Id_Locator));
                base.FocusOnElementById(TrueFalsePageResource.
                   TrueFalse_Page_SaveAndClose_Ques_Button_Id_Locator);
                //Get web element
                IWebElement getSaveCloseButton = base.GetWebElementPropertiesById
                    (TrueFalsePageResource.
                    TrueFalse_Page_SaveAndClose_Ques_Button_Id_Locator);
                //Click the "SaveAndClose" button
                base.ClickByJavaScriptExecutor(getSaveCloseButton);
                Thread.Sleep(Convert.ToInt32(TrueFalsePageResource.
                TrueFalse_Page_Activity_SaveAndClose_TimeValue));
                //Click on 'Add and Close' button
                this.ClickonAddandCloseButton();
                //Click on Save and Return
                new SkillBasedAssessmentPage().SaveandReturn();
                        }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TrueFalsePage", "CreateNewTrueFalseQuestion",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Feedback.
        /// </summary>
        private void EnterFeedback()
        {
            //Enter Feedback
            Logger.LogMethodEntry("TrueFalsePage", "EnterFeedback",
                  base.IsTakeScreenShotDuringEntryExit);
            new SelectQuestionTypePage().SelectCreateNewQuestionWindow();
            base.WaitForElement(By.Id(TrueFalsePageResource.
                TrueFalse_Page_AddAnswer_Button_Id_Locator));
            IWebElement getAddAnswerButton = base.GetWebElementPropertiesById
                (TrueFalsePageResource.
                TrueFalse_Page_AddAnswer_Button_Id_Locator);
            //Click On 'Add Answer' Button
            base.ClickByJavaScriptExecutor(getAddAnswerButton);
            base.WaitForElement(By.Id(TrueFalsePageResource.
                TrueFalse_Page_Feedback_Yes_Radiobutton_Id_Locator));
            //Enter Correct Feedback
            base.FillTextBoxById(TrueFalsePageResource.
                TrueFalse_Page_Feedback_Yes_Radiobutton_Id_Locator,
                TrueFalsePageResource.TrueFalse_Page_Correct_Feedback_Value);
            base.WaitForElement(By.Id(TrueFalsePageResource.
                TrueFalse_Page_Feedback_No_Radiobutton_Id_Locator));
            //Enter Wrong Feedback
            base.FillTextBoxById(TrueFalsePageResource.
                TrueFalse_Page_Feedback_No_Radiobutton_Id_Locator,
                TrueFalsePageResource.TrueFalse_Page_Wrong_Feedback_Value);
            Logger.LogMethodExit("TrueFalsePage", "EnterFeedback",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add and Close.
        /// </summary>
        private void ClickonAddandClose()
        {
            //Click on Add and Close
            Logger.LogMethodEntry("TrueFalsePage", "ClickonAddandClose",
                  base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            new SelectQuestionTypePage().SelectCreateNewQuestionWindow();
            //Wait for the 'Add and Close' button
            base.WaitForElement(By.Id(TrueFalsePageResource.
                TrueFalse_Page_SaveandCloseButton_Id_Locator));
            IWebElement getAddCloseButton=base.GetWebElementPropertiesById
            (TrueFalsePageResource.
                TrueFalse_Page_SaveandCloseButton_Id_Locator);
            //Click on 'Add and Close' button
            base.ClickByJavaScriptExecutor(getAddCloseButton);            
            base.IsPopUpClosed(Convert.ToInt32(TrueFalsePageResource.
                   TrueFalse_Page_Window_Count));
            //Select 'Create'Random'Activity' Window
            this.SelectCreateRandomActivityWindow();
            Logger.LogMethodExit("TrueFalsePage", "ClickonAddandClose",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add and Close button.
        /// </summary>
        private void ClickonAddandCloseButton()
        {
            //Click on 'Add and Close' button
            Logger.LogMethodEntry("TrueFalsePage", "ClickonAddandCloseButton",
                  base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            new SelectQuestionTypePage().SelectCreateNewQuestionWindow();
            //Wait for the 'Add and Close' button
            base.WaitForElement(By.Id(TrueFalsePageResource.
                TrueFalse_Page_SaveandCloseButton_Id_Locator));
            IWebElement getAddCloseButton = base.GetWebElementPropertiesById
            (TrueFalsePageResource.
                TrueFalse_Page_SaveandCloseButton_Id_Locator);
            //Click on 'Add and Close' button
            base.ClickByJavaScriptExecutor(getAddCloseButton);
            base.IsPopUpClosed(Convert.ToInt32(TrueFalsePageResource.
                   TrueFalse_Page_Window_Count));
            
            Logger.LogMethodExit("TrueFalsePage", "ClickonAddandCloseButton",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Create'Random'Activity' Window.
        /// </summary>
        private void SelectCreateRandomActivityWindow()
        {
            //Select 'Create'Random'Activity' Window
            Logger.LogMethodEntry("TrueFalsePage", "SelectCreateRandomActivityWindow",
                  base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(TrueFalsePageResource.
                TrueFalse_Page_CreateRandomActivity_WindowName);
            //Select Window
            base.SelectWindow(TrueFalsePageResource.
                TrueFalse_Page_CreateRandomActivity_WindowName);
            Logger.LogMethodExit("TrueFalsePage", "SelectCreateRandomActivityWindow",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Question Title.
        /// </summary>
        /// <returns>This is Question Title Guid.</returns>
        private Guid EnterQuestionTitle()
        {
            //Enter Question Title
            Logger.LogMethodEntry("TrueFalsePage", "EnterQuestionTitle",
                  base.IsTakeScreenShotDuringEntryExit);
            //Generate Guid for question
            Guid questionTrueFalse = Guid.NewGuid();
            //Select Window
            new SelectQuestionTypePage().SelectCreateNewQuestionWindow();
            //Wait for the element
            base.WaitForElement(By.Id(TrueFalsePageResource.
                TrueFalse_Page_QuestionName_Title_Id_Locator));
            base.FocusOnElementById(TrueFalsePageResource.
                    TrueFalse_Page_QuestionName_Title_Id_Locator);
            //Fill the Question name title text
            base.FillTextBoxById(TrueFalsePageResource.
                TrueFalse_Page_QuestionName_Title_Id_Locator,
                questionTrueFalse.ToString());
            Thread.Sleep(Convert.ToInt32(TrueFalsePageResource.
            TrueFalse_Page_Activity_SaveAndClose_TimeValue));
            Logger.LogMethodExit("TrueFalsePage", "EnterQuestionTitle",
                 base.IsTakeScreenShotDuringEntryExit);
            return questionTrueFalse;
        }

        /// <summary>
        /// Click Ques SaveAndClose Button.
        /// </summary>
        private void ClickQuesSaveAndCloseButton()
        {
            //Click Ques SaveAndClose Button
            Logger.LogMethodEntry("TrueFalsePage",
                "ClickQuesSaveAndCloseButton",
                 base.IsTakeScreenShotDuringEntryExit);
            //Select the window
            base.SelectWindow(TrueFalsePageResource.
                TrueFalse_Page_QuestionName_TF_Window_Name);
            //Wait for the element
            base.WaitForElement(By.Id(TrueFalsePageResource.
               TrueFalse_Page_SaveAndClose_Ques_Button_Id_Locator));
            base.FocusOnElementById(TrueFalsePageResource.
               TrueFalse_Page_SaveAndClose_Ques_Button_Id_Locator);
            IWebElement getSaveCloseButton=base.GetWebElementPropertiesById
                (TrueFalsePageResource.
               TrueFalse_Page_SaveAndClose_Ques_Button_Id_Locator);
            //Click the "SaveAndClose" button
            base.ClickByJavaScriptExecutor(getSaveCloseButton);
            Logger.LogMethodExit("TrueFalsePage",
                "ClickQuesSaveAndCloseButton",
                 base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
