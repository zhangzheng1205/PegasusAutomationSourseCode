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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }      
      
         /// <summary>
        /// Create Audio Essay Question.
        /// </summary>
        public void CreateAudioEssayQuestions()
        {
            //Create Audio Essay Question
            logger.LogMethodEntry("EssayPage", "CreateAudioEssayQuestions",
                base.isTakeScreenShotDuringEntryExit);
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
                this.RecordAudioforEssayQuestion();
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
                this.storeQuestionDetailsInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EssayPage", "CreateAudioEssayQuestions",
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Record Audio for Essay Question.
        /// </summary>
        public void RecordAudioforEssayQuestion()
        {
            //Create Audio Essay Question
            logger.LogMethodEntry("EssayPage", "RecordAudioforEssayQuestion",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Select Record Audio Window
                this.SelectRecordAudioWindow();
                //Wait For Record Button Class Name
                base.WaitForElement(By.ClassName(
                    EssayPageResource.Essay_Page_RecordButton_ClassName));
                IWebElement getRecordButton = base.GetWebElementPropertiesByClassName(
                     EssayPageResource.Essay_Page_RecordButton_ClassName);
                //Click On Record Button To Start Recording
                base.ClickByJavaScriptExecutor(getRecordButton);
                // Recording Audio for One Minute
                this.RecordAudioForOneMinute();
                //Click On Record Button To Stop Recording 
                base.ClickByJavaScriptExecutor(getRecordButton);
                // Save Audio Recorded input value
                this.SaveAudioRecordingValue();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }           
            logger.LogMethodExit("EssayPage", "RecordAudioforEssayQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Record Audio Window.
        /// </summary>
        private void SelectRecordAudioWindow()
        {
            logger.LogMethodEntry("EssayPage", "SelectRecordAudioWindow",
               base.isTakeScreenShotDuringEntryExit);
            //Click On Record Audio Image
            base.WaitForElement(By.Id(
                EssayPageResource.Essay_Page_AudioRecord_Image_Id_Locator));
            base.ClickImageById(
                EssayPageResource.Essay_Page_AudioRecord_Image_Id_Locator);
            //Switch To Popup Window
            base.WaitUntilPopUpLoads(
                EssayPageResource.Essay_Page_RecordAudio_Window_Name);
            base.SelectWindow(
                EssayPageResource.Essay_Page_RecordAudio_Window_Name);
            logger.LogMethodExit("EssayPage", "SelectRecordAudioWindow",
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Record Audio for One Minute.
        /// </summary>
        private void RecordAudioForOneMinute()
        {
            //Record Audio for One Minute
            logger.LogMethodEntry("EssayPage", "RecordAudioForOneMinute",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Fetching The Recording Time Value
                base.WaitForElement(By.ClassName(
                    EssayPageResource.Essay_Page_CurrentTime_ClassName));
                string getRecordingCurretTime = base.GetElementTextByClassName(
                    EssayPageResource.Essay_Page_CurrentTime_ClassName);
                //Reccursive Method To Record Audio For One Minute
                if (Convert.ToInt32(getRecordingCurretTime.Split(':')[0]) >=
                    Convert.ToInt32(EssayPageResource.Essay_Page_AudioInput_Minutes_Time_Value))
                {
                    return;
                }
                else{
                    RecordAudioForOneMinute();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EssayPage", "RecordAudioForOneMinute",
               base.isTakeScreenShotDuringEntryExit);   
        }
        /// <summary>
        /// Save Audio Recorded input value.
        /// </summary>
        private void SaveAudioRecordingValue()
        {
            logger.LogMethodEntry("EssayPage", "SaveAudioRecordingValue",
                base.isTakeScreenShotDuringEntryExit);
            //Wait Till Record Saving Message Disappears
            bool getIsSaveButtonEnabled = false;
            do
            {
                getIsSaveButtonEnabled = base.IsElementEnabledByID(
                    EssayPageResource.Essay_Page_SaveAndClose_Id_Locator);

            } while (getIsSaveButtonEnabled == false);
            // Wait For SaveButton ID
            base.WaitForElement(By.Id(
                EssayPageResource.Essay_Page_SaveAndClose_Id_Locator));
            IWebElement getSaveButtonId = base.GetWebElementPropertiesById(
                EssayPageResource.Essay_Page_SaveAndClose_Id_Locator);
            //Click On Save And Close Button
            base.ClickByJavaScriptExecutor(getSaveButtonId);
            logger.LogMethodExit("EssayPage", "SaveAudioRecordingValue",
               base.isTakeScreenShotDuringEntryExit);   
        }
        ///<summary>
        /// Enable Audio Input CheckBox.
        ///</summary>
        private void EnableAudioInputCheckBox()
        {
            logger.LogMethodEntry("EssayPage",
                "EnableAudioInputCheckBox",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter Audio Input Time to Record Value.      
        /// </summary>
        private void EnterAudioInputTimingsValue()
        {
            //Enter Audio Input Time to Record Value
            logger.LogMethodEntry("EssayPage",
                "EnterAudioInputTimingsValue",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_AudioInput_MinTime_Id_Locator));
            //Clear Minutes TextBox Value
            base.ClearTextByID(EssayPageResource.
                Essay_Page_AudioInput_MinTime_Id_Locator);
            //Enter Minutes TextBox Value
            base.FillTextBoxByID(EssayPageResource.
                Essay_Page_AudioInput_MinTime_Id_Locator,
                EssayPageResource.Essay_Page_AudioInput_Minutes_Time_Value);
            base.WaitForElement(By.Id(EssayPageResource.
               Essay_Page_AudioInput_Seconds_Time_Id_Locator));
            //Clear Seconds TextBox Value
            base.ClearTextByID(EssayPageResource.
                Essay_Page_AudioInput_Seconds_Time_Id_Locator);
            //Enter Seconds TextBox Value
            base.FillTextBoxByID(EssayPageResource.
                Essay_Page_AudioInput_Seconds_Time_Id_Locator,
                EssayPageResource.Essay_Page_AudioInput_Seconds_Time_Value);
            logger.LogMethodExit("EssayPage",
                "EnterAudioInputTimingsValue",
                base.isTakeScreenShotDuringEntryExit);
        }       
        /// <summary>
        /// Create EssayQuestion Inside The Activity.
        /// </summary>
        public void CreateEssayQuestionInsideTheActivity()
        {
            //Create EssayQuestion Inside The Activity
            logger.LogMethodEntry("EssayPage", "CreateEssayQuestionInsideTheActivity",
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);           
        }

        /// <summary>
        /// Select HTML Window And Frame.
        /// </summary>
        private void SelectHTMLWindowAndFrame()
        {
            //Select HTML Window And Frame
            logger.LogMethodEntry("EssayPage", "SelectHTMLWindowAndFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Select Create New Question Window
            this.SelectCreateNewQuestionWindow();
            base.SwitchToIFrame(EssayPageResource.
                Essay_Page_HTMLFrame_Id_Locator);
            logger.LogMethodExit("EssayPage", "SelectHTMLWindowAndFrame",
               base.isTakeScreenShotDuringEntryExit);         
        }

        /// <summary>
        /// Select Create New Question Window.
        /// </summary>
        private void SelectCreateNewQuestionWindow()
        {
            //Select Create New Question Window
            logger.LogMethodEntry("EssayPage", "SelectCreateNewQuestionWindow",
                base.isTakeScreenShotDuringEntryExit);           
            //Select Create Essay Window
            base.WaitUntilWindowLoads(EssayPageResource.
                Essay_Page_Select_CreateQuestion_Window_Name);
            base.SelectWindow(EssayPageResource.
                Essay_Page_Select_CreateQuestion_Window_Name);
            //Select the frame
            base.SwitchToIFrame(EssayPageResource.
                Essay_Page_Select_CreateQuestion_Frame);
            logger.LogMethodExit("EssayPage", "SelectCreateNewQuestionWindow",
               base.isTakeScreenShotDuringEntryExit);  
        }

        /// <summary>
        /// Enter Question Title For Essay Question.
        /// </summary>
        /// <returns>Question Title Guid.</returns>
        private Guid EnterTitleOfEssayQuestion()
        {
            //Enter Question Title For Essay Question
            logger.LogMethodEntry("EssayPage", "EnterTitleOfEssayQuestion",
                base.isTakeScreenShotDuringEntryExit);
            Guid questionTitle = Guid.NewGuid();            
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_EnterQuestionTitle_Id_Locator));
            //Enter Question Title
            base.FillTextBoxByID(EssayPageResource.
                Essay_Page_EnterQuestionTitle_Id_Locator, questionTitle.ToString());
            logger.LogMethodExit("EssayPage", "EnterTitleOfEssayQuestion",
               base.isTakeScreenShotDuringEntryExit);
            return questionTitle;
        }

        /// <summary>
        /// Click On Browse Button of Essay Question
        /// </summary>
        private void ClickOnBrowseButtonOfEssayQuestion()
        {
            //CLick On Browse Button of Essay Question
            logger.LogMethodEntry("EssayPage", "ClickOnBrowseButtonOfEssayQuestion",
             base.isTakeScreenShotDuringEntryExit);
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
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save and Close Button.
        /// </summary>
        private void ClickONSaveAndCloseButtonOfEssayQuestion()
        {
            //Click On Save and Close Button
            logger.LogMethodEntry("EssayPage", 
                "ClickONSaveAndCloseButtonOfEssayQuestion",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_Save_Button_Id_Locator));
            //Get Button Property 
            IWebElement getButtonProperty = base.GetWebElementPropertiesById(
                EssayPageResource.Essay_Page_Save_Button_Id_Locator);
            //Click On Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("EssayPage", 
                "ClickONSaveAndCloseButtonOfEssayQuestion",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Score Value for Essay Question.
        /// </summary>
        private void EnterScoreValueForEssayQuestion()
        {
            //Enter Score Value for Essay Question
            logger.LogMethodEntry("EssayPage", 
                "EnterScoreValueForEssayQuestion",
               base.isTakeScreenShotDuringEntryExit);
            //Select Create Essay Window
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_MaxScore_Id_Locator));
            //Clear Text Box of Max Score
            base.ClearTextByID(EssayPageResource.
                Essay_Page_MaxScore_Id_Locator);
            //Enter Max Score
            base.FillTextBoxByID(EssayPageResource.
                Essay_Page_MaxScore_Id_Locator, EssayPageResource.
                Essay_Page_MaxScore_Value);
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_NumberOfWords_Id_Locator));
            //Clear Text Box of Number of Words
            base.ClearTextByID(EssayPageResource.
                Essay_Page_NumberOfWords_Id_Locator);
            //Enter Score Value for Number of Words
            base.FillTextBoxByID(EssayPageResource.
                Essay_Page_NumberOfWords_Id_Locator, EssayPageResource.
                Essay_Page_NumberOfWords_Value);
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_NumberOfLines_Id_Locator));
            //Clear Text Box of Number of Lines
            base.ClearTextByID(EssayPageResource.
                Essay_Page_NumberOfLines_Id_Locator);
            //Enter Score value for Number of Lines
            base.FillTextBoxByID(EssayPageResource.
                Essay_Page_NumberOfLines_Id_Locator, EssayPageResource.
                Essay_Page_NumberOfLines_Value);
            logger.LogMethodExit("EssayPage", 
                "EnterScoreValueForEssayQuestion",
             base.isTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Click On Add Text Settings.
        /// </summary>
        private void ClickOnAddTextSettings()
        {
            //Click On Add Text Settings
            logger.LogMethodEntry("EssayPage", "ClickOnAddTextSettings",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_Answer_Button_Id_Locator));
            //Get Button Property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById
                (EssayPageResource.Essay_Page_Answer_Button_Id_Locator);
            //Click On Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("EssayPage", "ClickOnAddTextSettings",
             base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
            base.FillTextBoxByID(EssayPageResource.
                Essay_Page_EnterText_HTML_Id_Locator, questionText);
            IWebElement getSourceButton=base.GetWebElementPropertiesById
                (EssayPageResource.
                Essay_Page_ViewSource_Button_Id_Locator);
            //Click On View Source Button
            base.ClickByJavaScriptExecutor(getSourceButton);
            logger.LogMethodExit("EssayPage", 
                "ClickOnViewSourceOfEssayQuestionandEnterText",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Storde Question Detials in Memory.
        /// </summary>
        /// <param name="questionGuid">This is Question Name Generated by Guid.</param>
        private void storeQuestionDetailsInMemory(string questionGuid)
        {
            //Store Question Details in Memory
            logger.LogMethodEntry("EssayPage", "storeQuestionDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
            //Save Question Properties in Memory
            Question newQuestion = new Question
            {
                Name = questionGuid.ToString(),
                QuestionType = Question.QuestionTypeEnum.Essay,
                IsCreated = true,
            };
            newQuestion.StoreQuestionInMemory();
            logger.LogMethodExit("EssayPage", "storeQuestionDetailsInMemory",
              base.isTakeScreenShotDuringEntryExit);            
        }      
       
        /// <summary>
        /// Add Pallette Characters.
        /// </summary>
        private void AddPalletteCharacters()
        {
            logger.LogMethodEntry("EssayPage", "AddPalletteCharacters",
            base.isTakeScreenShotDuringEntryExit);            
            //Add Pallette Characters
            base.WaitForElement(By.Id(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_one));
            //Add a character
            base.FocusOnElementByID(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_one);
            base.ClickButtonByID(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_one);
            //Add e character
            base.FocusOnElementByID(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_two);
            base.ClickButtonByID(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_two);
            //Add i character
            base.FocusOnElementByID(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_three);
            base.ClickButtonByID(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_three);
            //Add o character
            base.FocusOnElementByID(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_four);
            base.ClickButtonByID(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_four);
            //Add u character
            base.FocusOnElementByID(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_five);
            base.ClickButtonByID(EssayPageResource.
                Essay_Page_CharacterPallete_Id_Locator_five);
            logger.LogMethodExit("EssayPage", "AddPalletteCharacters",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Essay Question window.
        /// </summary>
        private void SelectEssayWindow()
        {
            //Select Essay Question window
            logger.LogMethodEntry("EssayPage", "SelectEssayWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Select Create Essay Window
            base.WaitUntilWindowLoads(EssayPageResource.Essay_Page_CreateEssay_Window_Name);
            base.SelectWindow(EssayPageResource.Essay_Page_CreateEssay_Window_Name);
            logger.LogMethodExit("EssayPage", "SelectEssayWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select HTML Frame.
        /// </summary>
        private void SelectHTMLFrame()
        {
            //Select HTML Frame
            logger.LogMethodEntry("EssayPage", "SelectHTMLFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Select Create Essay Window
            base.SelectWindow(EssayPageResource.Essay_Page_CreateEssay_Window_Name);
            base.WaitForElement(By.Id(EssayPageResource.Essay_Page_HTMLFrame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(EssayPageResource.Essay_Page_HTMLFrame_Id_Locator);
            logger.LogMethodExit("EssayPage", "SelectHTMLFrame",
                base.isTakeScreenShotDuringEntryExit);
        }    
    }
}
