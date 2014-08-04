﻿using System;
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
    /// This Class Handles Essay Page actions
    /// </summary>
    public class EssayPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(EssayPage));

        /// <summary>
        /// Create Essay Question
        /// </summary>
        public void CreateEssayQuestion()
        {
            //Create Essay Question
            logger.LogMethodEntry("EssayPage", "CreateEssayQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectEssayWindow();
                //Enter Title for Essay Question
                string questionDetails = this.EnterTitleOfEssayQuestion().ToString();
                //Select HTML Frame
                this.SelectHTMLFrame();                
                //Click On View Source button and Enter Data
                this.ClickOnViewSourceOfEssayQuestionandEnterText(questionDetails);                
                //Click On Browse Button
                this.ClickOnBrowseButtonOfEssayQuestion();
                Activity activity = Activity.Get(Activity.ActivityTypeEnum.Page);
                //Add Narative Image
                new ContentBrowserUXPage().SelectNarativeImage(activity.Name);
                this.SelectEssayWindow();
                //Click on Add Text Settings
                this.ClickOnAddTextSettings();
                //Enter Score For Essay Question
                this.EnterScoreValueForEssayQuestion();                
                //Click On Save and Close Button
                this.ClickONSaveAndCloseButtonOfEssayQuestion();
                //Wait for 'True/False' question window to close
                base.IsPopUpClosed(Convert.ToInt32(TrueFalsePageResource.
                    TrueFalse_Page_Window_Count));
                //Store Question Details in Memory
                this.storeQuestionDetailsInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EssayPage", "CreateEssayQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }      
      
         /// <summary>
        /// Create Audio Essay Question.
        /// </summary>
        public void CreateAudioEssayQuestions()
        {
            //Create Audio Essay Question
            logger.LogMethodEntry("EssayPage", "CreateAudioEssayQuestions",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {  
                this.SelectEssayWindow();
                //Enter Title for Essay Question
                string questionDetails = this.EnterTitleOfEssayQuestion().ToString();
                //Select HTML Frame
                this.SelectHTMLFrame();
                //Click On View Source button and Enter Data
                this.ClickOnViewSourceOfEssayQuestionandEnterText(questionDetails);
                //Record Audio For Essay Question
                new AudioRecorderPage().RecordAudio();
                this.SelectEssayWindow();
                //Click on Add Text Settings
                this.ClickOnAddTextSettings();
                //Enter Score For Essay Question
                this.EnterScoreValueForEssayQuestion();
                //Enter Audio Input Details
                this.EnableAudioInputCheckBox();
                //Click On Save and Close Button
                this.ClickONSaveAndCloseButtonOfEssayQuestion();
                //Wait for 'True/False' question window to close
                base.IsPopUpClosed(Convert.ToInt32(TrueFalsePageResource.
                    TrueFalse_Page_Window_Count));
                //Store Question Details in Memory
                this.storeAudioQuestionDetailsInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EssayPage", "CreateAudioEssayQuestions",
                base.IsTakeScreenShotDuringEntryExit);
        }
       
        ///<summary>
        /// Enable Audio Input CheckBox.
        ///</summary>
        private void EnableAudioInputCheckBox()
        {
            logger.LogMethodEntry("EssayPage",
                "EnableAudioInputCheckBox",
                base.IsTakeScreenShotDuringEntryExit);
            //Enable AudioInput Checkbox
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_AudioInput_Checkbox_Id_Locator));
            // Get CheckBox Id Property
            IWebElement getIdProperty = base.GetWebElementPropertiesById(
                EssayPageResource.Essay_Page_AudioInput_Checkbox_Id_Locator);
            //Enable on Audio Input CheckBox
            ClickByJavaScriptExecutor(getIdProperty);
            // Enter Audio Input Time to Record Value    
            this.EnterAudioInputTimingsValue();
            logger.LogMethodExit("EssayPage",
                "EnableAudioInputCheckBox",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter Audio Input Time to Record Value.      
        /// </summary>
        private void EnterAudioInputTimingsValue()
        {
            //Enter Audio Input Time to Record Value
            logger.LogMethodEntry("EssayPage",
                "EnterAudioInputTimingsValue",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_AudioInput_MinTime_Id_Locator));
            //Clear Minutes TextBox Value
            base.ClearTextById(EssayPageResource.
                Essay_Page_AudioInput_MinTime_Id_Locator);
            //Enter Minutes TextBox Value
            base.FillTextBoxById(EssayPageResource.
                Essay_Page_AudioInput_MinTime_Id_Locator,
                EssayPageResource.Essay_Page_AudioInput_Minutes_Time_Value);
            base.WaitForElement(By.Id(EssayPageResource.
               Essay_Page_AudioInput_Seconds_Time_Id_Locator));
            //Clear Seconds TextBox Value
            base.ClearTextById(EssayPageResource.
                Essay_Page_AudioInput_Seconds_Time_Id_Locator);
            //Enter Seconds TextBox Value
            base.FillTextBoxById(EssayPageResource.
                Essay_Page_AudioInput_Seconds_Time_Id_Locator,
                EssayPageResource.Essay_Page_AudioInput_Seconds_Time_Value);
            logger.LogMethodExit("EssayPage",
                "EnterAudioInputTimingsValue",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Storde Audio Essay Question Detials in Memory.
        /// </summary>
        /// <param name="questionGuid">This is Question Name Generated by Guid.</param>
        private void storeAudioQuestionDetailsInMemory(string questionGuid)
        {
            //Store Audio Essay Question Details in Memory
            logger.LogMethodEntry("EssayPage", "storeAudioQuestionDetailsInMemory",
               base.IsTakeScreenShotDuringEntryExit);
            //Save Audio Essay Question Properties in Memory
            Question newQuestion = new Question
            {
                QuestionId = CommonResource.CommonResource.HigherEdCore_Audio_EssayQuestion_UC1,
                Name = questionGuid.ToString(),
                QuestionType = Question.QuestionTypeEnum.Essay,
                IsCreated = true,
            };
            newQuestion.StoreQuestionInMemory();
            logger.LogMethodExit("EssayPage", "storeAudioQuestionDetailsInMemory",
              base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Create EssayQuestion Inside The Activity.
        /// </summary>
        public void CreateEssayQuestionInsideTheActivity()
        {
            //Create EssayQuestion Inside The Activity
            logger.LogMethodEntry("EssayPage", "CreateEssayQuestionInsideTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create New Question Window
                this.SelectCreateNewQuestionWindow();
                //Enter Title for Essay Question
                string questionDetails = this.EnterTitleOfEssayQuestion().ToString();
                //Select HTML Window And Frame
                this.SelectHTMLWindowAndFrame();
                //Click On View Source button and Enter Data
                this.ClickOnViewSourceOfEssayQuestionandEnterText(questionDetails);
                //Select Create New Question Window
                this.SelectCreateNewQuestionWindow();
                //Click on Add Text Settings
                this.ClickOnAddTextSettings();
                //Enter Score For Essay Question
                this.EnterScoreValueForEssayQuestion();
                //Click On Save and Close Button
                this.ClickONSaveAndCloseButtonOfEssayQuestion();
                //Store Question Details in Memory
                this.storeQuestionDetailsInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EssayPage", "CreateEssayQuestionInsideTheActivity",
               base.IsTakeScreenShotDuringEntryExit);           
        }

        /// <summary>
        /// Select HTML Window And Frame.
        /// </summary>
        private void SelectHTMLWindowAndFrame()
        {
            //Select HTML Window And Frame
            logger.LogMethodEntry("EssayPage", "SelectHTMLWindowAndFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Create New Question Window
            this.SelectCreateNewQuestionWindow();
            base.SwitchToIFrame(EssayPageResource.
                Essay_Page_HTMLFrame_Id_Locator);
            logger.LogMethodExit("EssayPage", "SelectHTMLWindowAndFrame",
               base.IsTakeScreenShotDuringEntryExit);         
        }

        /// <summary>
        /// Select Create New Question Window.
        /// </summary>
        private void SelectCreateNewQuestionWindow()
        {
            //Select Create New Question Window
            logger.LogMethodEntry("EssayPage", "SelectCreateNewQuestionWindow",
                base.IsTakeScreenShotDuringEntryExit);           
            //Select Create Essay Window
            base.WaitUntilWindowLoads(EssayPageResource.
                Essay_Page_Select_CreateQuestion_Window_Name);
            base.SelectWindow(EssayPageResource.
                Essay_Page_Select_CreateQuestion_Window_Name);
            //Select the frame
            base.SwitchToIFrame(EssayPageResource.
                Essay_Page_Select_CreateQuestion_Frame);
            logger.LogMethodExit("EssayPage", "SelectCreateNewQuestionWindow",
               base.IsTakeScreenShotDuringEntryExit);  
        }

        /// <summary>
        /// Enter Question Title For Essay Question.
        /// </summary>
        /// <returns>Question Title Guid.</returns>
        private Guid EnterTitleOfEssayQuestion()
        {
            //Enter Question Title For Essay Question
            logger.LogMethodEntry("EssayPage", "EnterTitleOfEssayQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            Guid questionTitle = Guid.NewGuid();            
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_EnterQuestionTitle_Id_Locator));
            //Enter Question Title
            base.FillTextBoxById(EssayPageResource.
                Essay_Page_EnterQuestionTitle_Id_Locator, questionTitle.ToString());
            logger.LogMethodExit("EssayPage", "EnterTitleOfEssayQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            return questionTitle;
        }

        /// <summary>
        /// Click On Browse Button of Essay Question
        /// </summary>
        private void ClickOnBrowseButtonOfEssayQuestion()
        {
            //CLick On Browse Button of Essay Question
            logger.LogMethodEntry("EssayPage", "ClickOnBrowseButtonOfEssayQuestion",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(EssayPageResource.Essay_Page_CreateEssay_Window_Name);
            //Select Create Essay Window
            base.SelectWindow(EssayPageResource.Essay_Page_CreateEssay_Window_Name);
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_Browse_Button_Id_Locator));
            //Get Button property
            IWebElement getBrowseButtonProperty = base.GetWebElementPropertiesById(
                EssayPageResource.Essay_Page_Browse_Button_Id_Locator);
            //Click On Button
            base.ClickByJavaScriptExecutor(getBrowseButtonProperty);
            logger.LogMethodExit("EssayPage", "ClickOnBrowseButtonOfEssayQuestion",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save and Close Button.
        /// </summary>
        private void ClickONSaveAndCloseButtonOfEssayQuestion()
        {
            //Click On Save and Close Button
            logger.LogMethodEntry("EssayPage", 
                "ClickONSaveAndCloseButtonOfEssayQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_Save_Button_Id_Locator));
            //Get Button Property 
            IWebElement getButtonProperty = base.GetWebElementPropertiesById(
                EssayPageResource.Essay_Page_Save_Button_Id_Locator);
            //Click On Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("EssayPage", 
                "ClickONSaveAndCloseButtonOfEssayQuestion",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Score Value for Essay Question.
        /// </summary>
        private void EnterScoreValueForEssayQuestion()
        {
            //Enter Score Value for Essay Question
            logger.LogMethodEntry("EssayPage", 
                "EnterScoreValueForEssayQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Create Essay Window
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_MaxScore_Id_Locator));
            //Clear Text Box of Max Score
            base.ClearTextById(EssayPageResource.
                Essay_Page_MaxScore_Id_Locator);
            //Enter Max Score
            base.FillTextBoxById(EssayPageResource.
                Essay_Page_MaxScore_Id_Locator, EssayPageResource.
                Essay_Page_MaxScore_Value);
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_NumberOfWords_Id_Locator));
            //Clear Text Box of Number of Words
            base.ClearTextById(EssayPageResource.
                Essay_Page_NumberOfWords_Id_Locator);
            //Enter Score Value for Number of Words
            base.FillTextBoxById(EssayPageResource.
                Essay_Page_NumberOfWords_Id_Locator, EssayPageResource.
                Essay_Page_NumberOfWords_Value);
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_NumberOfLines_Id_Locator));
            //Clear Text Box of Number of Lines
            base.ClearTextById(EssayPageResource.
                Essay_Page_NumberOfLines_Id_Locator);
            //Enter Score value for Number of Lines
            base.FillTextBoxById(EssayPageResource.
                Essay_Page_NumberOfLines_Id_Locator, EssayPageResource.
                Essay_Page_NumberOfLines_Value);
            logger.LogMethodExit("EssayPage", 
                "EnterScoreValueForEssayQuestion",
             base.IsTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Click On Add Text Settings.
        /// </summary>
        private void ClickOnAddTextSettings()
        {
            //Click On Add Text Settings
            logger.LogMethodEntry("EssayPage", "ClickOnAddTextSettings",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_Answer_Button_Id_Locator));
            //Get Button Property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById
                (EssayPageResource.Essay_Page_Answer_Button_Id_Locator);
            //Click On Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("EssayPage", "ClickOnAddTextSettings",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On View Source Button and Enter Text.
        /// </summary>
        /// <param name="questionText">This is Question Text.</param>
        private void ClickOnViewSourceOfEssayQuestionandEnterText(string questionText)
        {
            //Click On View Source Button of Essay Question
            logger.LogMethodEntry("EssayPage", 
                "ClickOnViewSourceOfEssayQuestionandEnterText",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_ViewSource_Button_Id_Locator));
            IWebElement getHTMLSourceButton = base.GetWebElementPropertiesById
                (EssayPageResource.
                Essay_Page_ViewSource_Button_Id_Locator);
            //Click On View Source Button
            base.ClickByJavaScriptExecutor(getHTMLSourceButton);
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_EnterText_HTML_Id_Locator));
            //Enter Text 
            base.FillTextBoxById(EssayPageResource.
                Essay_Page_EnterText_HTML_Id_Locator, questionText);
            IWebElement getSourceButton=base.GetWebElementPropertiesById
                (EssayPageResource.
                Essay_Page_ViewSource_Button_Id_Locator);
            //Click On View Source Button
            base.ClickByJavaScriptExecutor(getSourceButton);
            logger.LogMethodExit("EssayPage", 
                "ClickOnViewSourceOfEssayQuestionandEnterText",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Storde Question Detials in Memory.
        /// </summary>
        /// <param name="questionGuid">This is Question Name Generated by Guid.</param>
        private void storeQuestionDetailsInMemory(string questionGuid)
        {
            //Store Question Details in Memory
            logger.LogMethodEntry("EssayPage", "storeQuestionDetailsInMemory",
               base.IsTakeScreenShotDuringEntryExit);
            //Save Question Properties in Memory
            Question newQuestion = new Question
            {
                Name = questionGuid.ToString(),
                QuestionType = Question.QuestionTypeEnum.Essay,
                IsCreated = true,
            };
            newQuestion.StoreQuestionInMemory();
            logger.LogMethodExit("EssayPage", "storeQuestionDetailsInMemory",
              base.IsTakeScreenShotDuringEntryExit);            
        }      
       
        /// <summary>
        /// Add Pallette Characters.
        /// </summary>
        private void AddPalletteCharacters()
        {
            logger.LogMethodEntry("EssayPage", "AddPalletteCharacters",
            base.IsTakeScreenShotDuringEntryExit);            
            //Add Pallette Characters
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_one));
            //Add a character
            base.FocusOnElementById(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_one);
            base.ClickButtonById(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_one);
            //Add e character
            base.FocusOnElementById(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_two);
            base.ClickButtonById(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_two);
            //Add i character
            base.FocusOnElementById(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_three);
            base.ClickButtonById(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_three);
            //Add o character
            base.FocusOnElementById(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_four);
            base.ClickButtonById(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_four);
            //Add u character
            base.FocusOnElementById(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_five);
            base.ClickButtonById(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_five);
            logger.LogMethodExit("EssayPage", "AddPalletteCharacters",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Essay Question window.
        /// </summary>
        private void SelectEssayWindow()
        {
            //Select Essay Question window
            logger.LogMethodEntry("EssayPage", "SelectEssayWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Create Essay Window
            base.WaitUntilWindowLoads(EssayPageResource.Essay_Page_CreateEssay_Window_Name);
            base.SelectWindow(EssayPageResource.Essay_Page_CreateEssay_Window_Name);
            logger.LogMethodExit("EssayPage", "SelectEssayWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select HTML Frame.
        /// </summary>
        private void SelectHTMLFrame()
        {
            //Select HTML Frame
            logger.LogMethodEntry("EssayPage", "SelectHTMLFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Create Essay Window
            base.SelectWindow(EssayPageResource.Essay_Page_CreateEssay_Window_Name);
            base.WaitForElement(By.Id(EssayPageResource.Essay_Page_HTMLFrame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(EssayPageResource.Essay_Page_HTMLFrame_Id_Locator);
            logger.LogMethodExit("EssayPage", "SelectHTMLFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }    
    }
}
