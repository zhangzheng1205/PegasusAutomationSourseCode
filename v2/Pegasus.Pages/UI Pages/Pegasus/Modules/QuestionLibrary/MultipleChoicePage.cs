using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.QuestionLibrary;


namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handles Multiple Choice Page actions
    /// </summary>
    /// 
    public class MultipleChoicePage : BasePage
    {

        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(MultipleChoicePage));

        /// <summary>
        /// Check Is Updated Score Correct.
        /// </summary>
        /// <param name="score">This is Score</param>
        /// <returns>Updated Score Status</returns>
        public bool IsUpdatedScoreCorrect(string score)
        {
            //Check Is Updated Score Correct
            logger.LogMethodEntry("MultipleChoicePage", "IsUpdatedScoreCorrect",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool updatedScoreStatus = false;
            try
            {
                //Select Window
                this.SelectEditMultipleChoiceWindow();
                base.WaitForElement(By.Id(MultipleChoicePageResource.
                    MultipleChoice_Page_AddAnswer_Id_Locator));
                //Click on Button
                base.ClickButtonByID(MultipleChoicePageResource.
                    MultipleChoice_Page_AddAnswer_Id_Locator);
                base.WaitForElement(By.XPath(MultipleChoicePageResource.
                    MultipleChoice_Page_Answer_Option_Count_Xpath_Locator));
                //Get Answer Count
                int getAnswerOptionsCount = base.GetElementCountByXPath(MultipleChoicePageResource.
                    MultipleChoice_Page_Answer_Option_Count_Xpath_Locator);
                for (int setRowCount = Convert.ToInt32(MultipleChoicePageResource.
                    MultipleChoice_Page_Loop_Initial_Value);
                    setRowCount < getAnswerOptionsCount; setRowCount++)
                {
                    //Get Score
                    string getScore = base.GetValueAttributeByXPath(
                        string.Format(MultipleChoicePageResource.
                        MultipleChoice_Page_Answer_Score_Xpath_Locator, setRowCount));
                    if (getScore == score)
                    {
                        updatedScoreStatus = true;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MultipleChoicePage", "IsUpdatedScoreCorrect",
             base.isTakeScreenShotDuringEntryExit);
            return updatedScoreStatus;
        }

        /// <summary>
        /// Select Edit Multiple Choice Window.
        /// </summary>
        private void SelectEditMultipleChoiceWindow()
        {
            //Select Edit Multiple Choice Window
            logger.LogMethodEntry("MultipleChoicePage", "SelectEditMultipleChoiceWindow",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(MultipleChoicePageResource.
                    MultipleChoice_Page_Window_Title);
            base.SelectWindow(MultipleChoicePageResource.
                MultipleChoice_Page_Window_Title);
            logger.LogMethodExit("MultipleChoicePage", "SelectEditMultipleChoiceWindow",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Multiple Choice Question.
        /// </summary>
        public void CreateMultipleChoiceQuestion()
        {
            //Creaye Multiple Choice Question
            logger.LogMethodEntry("MultipleChoicePage", "CreateMultipleChoiceQuestion",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create Multiple Choice Window
                this.SelectCreateMultipleChoiceWindow();
                //Create Question
                string questionDetails = this.EnterQuestionTitle().ToString();
                //Click On View Source Button and Fill Question details
                this.ClickOnViewSourceAndEnterDataForMultipleChoiceQuestion(questionDetails);
                //Click On Add Answer Button
                this.ClickOnAddAnswerButtonOfMultipleChoiceQuestion();
                //Enter Text Value for Multiple Choice
                this.EnterTextValueForMultipleChoiceQuestion();
                //Click On Save and Close Button
                this.ClickONSaveAndCloseButtonOfMultipleChoiceQuestion();
                //Store Question Details In Memory
                this.StoreQuestionDetailsInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MultipleChoicePage", "CreateMultipleChoiceQuestion",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Muktiple Choice Window.
        /// </summary>
        private void SelectCreateMultipleChoiceWindow()
        {
            //Select Create Multiple Choice Window
            logger.LogMethodEntry("MultipleChoicePage", "SelectCreateMultipleChoiceWindow",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(MultipleChoicePageResource.
                MultipleChoice_Page_CreateMultipleChoice_Window);
            //Select Multiple Choice Window
            base.SelectWindow(MultipleChoicePageResource.
                MultipleChoice_Page_CreateMultipleChoice_Window);
            logger.LogMethodExit("MultipleChoicePage", "SelectCreateMultipleChoiceWindow",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Question Title.
        /// </summary>
        /// <returns>Question Title Guid</returns>
        private Guid EnterQuestionTitle()
        {
            //Enter Question Title
            logger.LogMethodEntry("MultipleChoicePage", "EnterQuestionTitle",
                base.isTakeScreenShotDuringEntryExit);
            //Generate Question Title Guid
            Guid questionTitle = Guid.NewGuid();
            base.WaitForElement(By.Id(MultipleChoicePageResource.
                MultipleChoice_Page_EnterQuestionTitle_Id_Locator));
            //Fill the Question Title
            base.FillTextBoxByID(MultipleChoicePageResource.
                MultipleChoice_Page_EnterQuestionTitle_Id_Locator, questionTitle.ToString());
            logger.LogMethodExit("MultipleChoicePage", "EnterQuestionTitle",
                base.isTakeScreenShotDuringEntryExit);
            return questionTitle;
        }

        /// <summary>
        /// Click on View Source Button and enter HTML Text.
        /// </summary>
        /// <param name="questionText">This is Question text.</param>
        private void ClickOnViewSourceAndEnterDataForMultipleChoiceQuestion
            (string questionText)
        {
            //Click On View Source Button and Enter Data
            logger.LogMethodEntry("MultipleChoicePage",
                "ClickOnViewSourceAndEnterDataForMultipleChoiceQuestion",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Frame
            base.WaitForElement(By.Id(MultipleChoicePageResource.
                MultipleChoice_Page_Frame_Id_Locator));
            base.SwitchToIFrame(MultipleChoicePageResource.
                MultipleChoice_Page_Frame_Id_Locator);
            //Wait for view Source Button
            base.WaitForElement(By.Id(MultipleChoicePageResource.
                MultipleChoice_Page_ViewSource_Button_Id_Locator));
            //Click on View Source Button
            base.ClickButtonByID(MultipleChoicePageResource.
                MultipleChoice_Page_ViewSource_Button_Id_Locator);
            base.WaitForElement(By.Id(MultipleChoicePageResource.
                MultipleChoice_Page_EnterTextHTML_Id_Locator));
            //Enter data
            base.FillTextBoxByID(MultipleChoicePageResource.
                MultipleChoice_Page_EnterTextHTML_Id_Locator, questionText);
            //Click on View Source Button
            base.ClickButtonByID(MultipleChoicePageResource.
                MultipleChoice_Page_ViewSource_Button_Id_Locator);
            logger.LogMethodExit("MultipleChoicePage",
                "ClickOnViewSourceAndEnterDataForMultipleChoiceQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Answer Button.
        /// </summary>
        private void ClickOnAddAnswerButtonOfMultipleChoiceQuestion()
        {
            //Click On Add Answer Button
            logger.LogMethodEntry("MultipleChoicePage", 
                "ClickOnAddAnswerButtonOfMultipleChoiceQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Matching Window
            this.SelectCreateMultipleChoiceWindow();
            base.WaitForElement(By.Id(MultipleChoicePageResource.
                MultipleChoice_Page_AddAnswer_Id_Locator));
            //Get Button Property
            IWebElement getAddAnswerButton = base.GetWebElementPropertiesById(
                MultipleChoicePageResource.MultipleChoice_Page_AddAnswer_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getAddAnswerButton);
            logger.LogMethodExit("MultipleChoicePage",
                "ClickOnAddAnswerButtonOfMultipleChoiceQuestion",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Text Value For Matching Question.
        /// </summary>
        private void EnterTextValueForMultipleChoiceQuestion()
        {
            //Enter Text Value For Matching Question
            logger.LogMethodEntry("MultipleChoicePage",
                "EnterTextValueForMultipleChoiceQuestion",
                base.isTakeScreenShotDuringEntryExit);
            for (int initialCount = Convert.ToInt32(MatchingPageResource.
                Matching_Page_TextBox_InitialValue); initialCount <= Convert.ToInt32(
                MatchingPageResource.Matching_Page_TextBox_MaxValue); initialCount++)
            {
                //Wait For Element
                base.WaitForElement(By.Id(string.Format(MultipleChoicePageResource.
                    MultipleChoice_Page_ChoiceTextField_Id_Locator, initialCount)));
                //Clear the Textbox
                base.ClearTextByID(string.Format(MultipleChoicePageResource.
                    MultipleChoice_Page_ChoiceTextField_Id_Locator, initialCount));
                //Fill the Text Box
                base.FillTextBoxByID(string.Format(MultipleChoicePageResource.
                    MultipleChoice_Page_ChoiceTextField_Id_Locator, initialCount),
                    MultipleChoicePageResource.MultipleChoice_Page_EnterText_TextValue +
                    initialCount.ToString());
            }
            logger.LogMethodExit("MultipleChoicePage",
                "EnterTextValueForMultipleChoiceQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save and Close button.
        /// </summary>
        private void ClickONSaveAndCloseButtonOfMultipleChoiceQuestion()
        {
            //Click on Save and Close Button
            logger.LogMethodEntry("MultipleChoicePage",
                "ClickONSaveAndCloseButtonOfMultipleChoiceQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Matching Window            
            base.WaitForElement(By.Id(MultipleChoicePageResource.
                MultipleChoice_Page_Save_Button_Id_Locator));
            //Get Button property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById(
                MultipleChoicePageResource.
                MultipleChoice_Page_Save_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("MultipleChoicePage", 
                "ClickONSaveAndCloseButtonOfMultipleChoiceQuestion",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Storde Question Detials in Memory.
        /// </summary>
        /// <param name="questionGuid">This is Question Name Generated by Guid.</param>
        private void StoreQuestionDetailsInMemory(string questionGuid)
        {
            //Store Question Details in Memory
            logger.LogMethodEntry("MultipleChoicePage", "StoreQuestionDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
            //Save Question Properties in Memory
            Question newQuestion = new Question
            {
                Name = questionGuid.ToString(),
                QuestionType = Question.QuestionTypeEnum.MultipleChoice,
                IsCreated = true,
            };
            newQuestion.StoreQuestionInMemory();
            logger.LogMethodExit("MultipleChoicePage", "StoreQuestionDetailsInMemory",
              base.isTakeScreenShotDuringEntryExit);
        }
    }
}
