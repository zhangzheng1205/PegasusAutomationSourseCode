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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.QuestionSet;


namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class all action related to Question Set page.
    /// </summary>
    public class QuestionSetPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(QlGridUXPage));

        /// <summary>
        /// Create 2010 SIM question set with given question type. 
        /// </summary>
        /// <param name="questionTypeEnum">This is Question type enum.</param>
        public void CreateSIMQuestionsSet(Question.QuestionTypeEnum questionTypeEnum)
        {
            //Logger Entry
            Logger.LogMethodEntry("QuestionSetPage", "CreateSIMQuestionsSet",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Genrate Guid for Question set name 
                Guid questionSetName = Guid.NewGuid();
                //Select Create Question Set window
                this.SelectCreateQuestionSetWindow();
                //Enter Question set name
                this.EnterQuestionSetName(questionSetName.ToString());
                //Store the SIMQuestion
                this.StoreTheSIMQuestionSetInMemory(questionSetName, questionTypeEnum);
                //Click On save and continue button 
                this.ClickOnSaveAndContinueButton();
                //Select Question grid set Iframe
                this.SwitchToQuestionSetGridIframe();
                //Add question from SIM Question folder
                this.AddQuestionsFromQuestionFolder(questionTypeEnum);
                //Click on Add Close button on Select Content window
                this.ClickOnAddCloseButton();
                //Select Create Question Set window
                this.SelectCreateQuestionSetWindow();
                //Click on save and return button
                this.ClickOnSaveAndReturnButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "CreateSIMQuestionsSet",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the craete QuestionSet Window.
        /// </summary>
        private void SelectCreateQuestionSetWindow()
        {
            //Logger Entry
            Logger.LogMethodEntry("QuestionSetPage", "SelectCreateQuestionSetWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Select 'Create Question Set' window
            base.WaitUntilWindowLoads(QuestionSetPageResource.
                QuestionSetPage_CreateQuestionSet_Window_name);
            base.SelectWindow(QuestionSetPageResource.
                QuestionSetPage_CreateQuestionSet_Window_name);
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "SelectCreateQuestionSetWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter name of SIM Questionset and save to In memory. 
        /// </summary>
        /// <param name="questionSetName">This is question set name.</param>
        private void EnterQuestionSetName(string questionSetName)
        {
            //Logger Entry
            Logger.LogMethodEntry("QuestionSetPage", "EnterQuestionSetName",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Question Set Name textbox
            base.WaitForElement(By.Id(QuestionSetPageResource.
                QuestionSetPage_QuestionSetName_Textbox_Id));
            base.GetWebElementPropertiesById(QuestionSetPageResource.
                QuestionSetPage_QuestionSetName_Textbox_Id).Clear();
            //Fill Question Set Name textbox with Guid number
            base.GetWebElementPropertiesById(QuestionSetPageResource.
                QuestionSetPage_QuestionSetName_Textbox_Id).
                  SendKeys(questionSetName.ToString());
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "EnterQuestionSetName",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save and return button on Create Question set
        /// window after cretaion of question set. 
        /// </summary>
        private void ClickOnSaveAndReturnButton()
        {
            //Logger Entry
            Logger.LogMethodEntry("QuestionSetPage", "ClickOnSaveAndReturnButton",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on save and return button
            base.WaitForElement(By.Id(QuestionSetPageResource.
                QuestionSetPage_SaveAndReturn_Button_Id));
            //Get the HTML Property of Save and return Button
            IWebElement getPropertyOfSaveAndReturnButton = base.
                GetWebElementPropertiesById(QuestionSetPageResource.
                QuestionSetPage_SaveAndReturn_Button_Id);
            //Click on Button
            base.ClickByJavaScriptExecutor(getPropertyOfSaveAndReturnButton);
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "ClickOnSaveAndReturnButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On And Close Button on Select Content 
        /// window after selecting questions.
        /// </summary>
        private void ClickOnAddCloseButton()
        {
            //Logger Entry
            Logger.LogMethodEntry("QuestionSetPage", "ClickOnAddAndCloseButton",
               base.IsTakeScreenShotDuringEntryExit);
            //Switch to "Select content" popup window
            this.SelectContentWindow();
            //Click on Add and close button 
            base.WaitForElement(By.Id(QuestionSetPageResource.
                QuestionSetPage_AddAndClose_Button_Id));
            IWebElement getPropertyOfAddandCloseButton =
                base.GetWebElementPropertiesById(QuestionSetPageResource.
                QuestionSetPage_AddAndClose_Button_Id);
            base.ClickByJavaScriptExecutor(getPropertyOfAddandCloseButton);
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "ClickOnAddAndCloseButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add SIM Question from SIM Repository Question Folder. 
        /// </summary>
        ///<param name="questionTypeEnum">This is question type enum.</param>
        private void AddQuestionsFromQuestionFolder(Question.
            QuestionTypeEnum questionTypeEnum)
        {
            //Logger Entry
            Logger.LogMethodEntry("QuestionSetPage", "AddQuestionsFromQuestionFolder",
               base.IsTakeScreenShotDuringEntryExit);
            //Select the diffrent Question Folder according to Question Set Enum
            switch (questionTypeEnum)
            {
                case Question.QuestionTypeEnum.SIM2010ExcelQuestionSet:
                    //Add SIM 2010 Excel Questions
                    this.AddSIM2010Question(QuestionSetPageResource.
                        QuestionSetPage_2010_Excel_Folder_Name);
                    break;
                case Question.QuestionTypeEnum.SIM2010MSAccessQuestionSet:
                    //Add SIM 2010 MSAcsess Question
                    this.AddSIM2010Question(QuestionSetPageResource.
                      QuestionSetPage_2010_Access_Folder_Name);
                    break;
                case Question.QuestionTypeEnum.SIM2010PowerPointQuestionSet:
                    //Add SIM 2010 PowerPoint Question
                    this.AddSIM2010Question(QuestionSetPageResource.
                      QuestionSetPage_2010_PowerPoint_Folder_Name);
                    break;
                case Question.QuestionTypeEnum.SIM2010WordQuestionSet:
                    //Add SIM 2010 Word Question
                    this.AddSIM2010Question(QuestionSetPageResource.
                      QuestionSetPage_2010_Word_Folder_Name);
                    break;
                case Question.QuestionTypeEnum.SIM2007ExcelQuestionSet:
                    //Add SIM 2007 Excel Question
                    this.AddSIM2007Question(QuestionSetPageResource.
                        QuestionSetPage_2007_Excel_Folder_Name);
                    break;
                case Question.QuestionTypeEnum.SIM2007WordQuestionSet:
                    //Add SIM 2007 Word Question
                    this.AddSIM2007Question(QuestionSetPageResource.
                        QuestionSetPage_2007_Word_Folder_Name);
                    break;
                case Question.QuestionTypeEnum.SIM2007PowerPointQuestionSet:
                    //Add SIM 2007 PowerPont Question
                    this.AddSIM2007Question(QuestionSetPageResource.
                        QuestionSetPage_2007_PowerPoint_Folder_Name);
                    break;
                case Question.QuestionTypeEnum.SIM2007MSAccessQuestionSet:
                    //Add SIM 2007 Access Question
                    this.AddSIM2007Question(QuestionSetPageResource.
                        QuestionSetPage_2007_Access_Folder_Name);
                    break;
            }
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "AddQuestionsFromQuestionFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add SIM2007 Question.
        /// </summary>
        /// <param name="questionFolderName">This is name of question folder.</param>
        private void AddSIM2007Question(string questionFolderName)
        {
            //Add SIM2007 Question 
            Logger.LogMethodEntry("QuestionSetPage", "AddSIM2007Question",
               base.IsTakeScreenShotDuringEntryExit);
            //Click On SIM2007 Question Folder
            this.ClickOnSIM2007QuestionFolder();
            //Select SIMQuestion Set From Select Content
            this.SelectSIMQuestionSetFromSelectContent(questionFolderName);
            Logger.LogMethodExit("QuestionSetPage", "AddSIM2007Question",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On SIM2007 Question Folder.
        /// </summary>
        private void ClickOnSIM2007QuestionFolder()
        {
            //Click On SIM2007 Question Folder
            Logger.LogMethodEntry("QuestionSetPage", "ClickOnSIM2007QuestionFolder",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on Add Question Link on create Question set page
            this.ClickOnAddQuestionLink();
            //Switch to "Select content" popup window
            this.SelectContentWindow();
            //select Left Iframe 
            new ContentBrowserUXPage().SwitchToPopupPageContentIFrameLeft();
            //Click on "GO! Office 2007" folder
            base.WaitForElement(By.PartialLinkText(QuestionSetPageResource.
                QuestionSetPage_GOOffice2007_Folder_Name));
            ClickLinkByPartialLinkText(QuestionSetPageResource.
                QuestionSetPage_GOOffice2007_Folder_Name);
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "ClickOnSIM2007QuestionFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add SIM questions into question set from SIM Repository. 
        /// </summary>
        /// <param name="questionFolderName">This is name of question folder.</param>
        public void AddSIM2010Question(String questionFolderName)
        {
            //Add SIM questions into question set from SIM Repository
            Logger.LogMethodEntry("QuestionSetPage", "AddSIM2010Question",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click On SIM2010 Question Folder
                this.ClickOnSIM2010QuestionFolder();
                //Select SIMQuestion Set From Select Content
                this.SelectSIMQuestionSetFromSelectContent(questionFolderName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }   
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "AddSIM2010Question",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select SIMQuestion Set From Select Content.
        /// </summary>
        /// <param name="questionFolderName">This is name of question folder.</param>
        private void SelectSIMQuestionSetFromSelectContent(string questionFolderName)
        {
            //Select SIMQuestion Set From Select Content
            Logger.LogMethodEntry("QuestionSetPage",
                "SelectSIMQuestionSetFromSelectContent",
              base.IsTakeScreenShotDuringEntryExit);
            //Click on expected Question type folder
            base.WaitForElement(By.PartialLinkText(questionFolderName));
            ClickLinkByPartialLinkText(questionFolderName);
            //Validate the checkbox status of folder in SIM Repository
            this.ValidateTheCheckBoxStatusOfQuestionFolder();
            //Select checkbox for all questions 
            base.WaitForElement(By.Id(QuestionSetPageResource.
                QuestionSetPage_AllQuestion_Checkboc_Id));
            base.SelectCheckBoxById(QuestionSetPageResource.
                QuestionSetPage_AllQuestion_Checkboc_Id);
            //Select Content_Window
            this.SelectContentWindow();
            Logger.LogMethodExit("QuestionSetPage", 
                "SelectSIMQuestionSetFromSelectContent",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On SIM2010 Question Folder.
        /// </summary>
        private void ClickOnSIM2010QuestionFolder()
        {
            //Click On SIM2010 Question Folder
            Logger.LogMethodEntry("QuestionSetPage", "ClickOnSIM2010QuestionFolder",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on Add Question Link on create Question set page
            this.ClickOnAddQuestionLink();
            //Switch to "Select content" popup window
            this.SelectContentWindow();
            //select Left Iframe 
            new ContentBrowserUXPage().SwitchToPopupPageContentIFrameLeft();
            //Click on "GO! Office 2010" folder
            base.WaitForElement(By.PartialLinkText(QuestionSetPageResource.
                QuestionSetPage_GOOffice2010_Folder_Name));
            ClickLinkByPartialLinkText(QuestionSetPageResource.
                QuestionSetPage_GOOffice2010_Folder_Name);
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "ClickOnSIM2010QuestionFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the "Select Content" Window.
        /// </summary>
        private void SelectContentWindow()
        {
            //Logger Entry
            Logger.LogMethodEntry("QuestionSetPage", "SelectContentWindow",
              base.IsTakeScreenShotDuringEntryExit);
            //Select 'SelectContent' window
            base.WaitUntilWindowLoads(QuestionSetPageResource.
               QuestionSetPage_SelectContent_Window_name);
            base.SelectWindow(QuestionSetPageResource.
               QuestionSetPage_SelectContent_Window_name);
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "SelectContentWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the checkbox status of Question folder in SIM Repository.
        /// </summary>
        private void ValidateTheCheckBoxStatusOfQuestionFolder()
        {
            //Logger Entry
            Logger.LogMethodEntry("QuestionSetPage",
                "ValidateTheCheckBoxStatusOfQuestionFolder",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for Checkbox corresponding to folder name  
            base.WaitForElement(By.XPath(QuestionSetPageResource.
                QuestionSetPage_Folder_CheckBox_Xpath));
            bool isCheckBoxEnabled = WebDriver.FindElement(By.XPath(
                QuestionSetPageResource.
                QuestionSetPage_Folder_CheckBox_Xpath)).Enabled;
            //Validate the status of check status 
            while (!isCheckBoxEnabled)
            {
                //Click on sub folder untill checkbox of question enable.
                base.WaitForElement(By.XPath(QuestionSetPageResource.
                    QuestionSetPage_Question_Folder_Xpath));
                ClickLinkByXPath(QuestionSetPageResource.
                    QuestionSetPage_Question_Folder_Xpath);
                //Wait for page load after click on folder
                Thread.Sleep(Convert.ToInt32(QuestionSetPageResource.
                    QuestionSetPage_Thread_Sleep_Time));
                isCheckBoxEnabled = WebDriver.FindElement(By.XPath(
                QuestionSetPageResource.
                QuestionSetPage_Folder_CheckBox_Xpath)).Enabled;
                if (isCheckBoxEnabled)
                {
                    break;
                }
            }
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage",
                "ValidateTheCheckBoxStatusOfQuestionFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Question Link.
        /// </summary>
        private void ClickOnAddQuestionLink()
        {
            //Logger Entry
            Logger.LogMethodEntry("QuestionSetPage", "ClickOnAddQuestionLink",
                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for Add Questions link on Questions tab
            base.WaitForElement(By.Id(QuestionSetPageResource.
                QuestionSetPage_AddQuestion_Link_Id));
            //Click on Add Question Link 
            base.ClickLinkById(QuestionSetPageResource.
                QuestionSetPage_AddQuestion_Link_Id);
            Logger.LogMethodExit("QuestionSetPage", "ClickOnAddQuestionLink",  
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on save and continue button on Create question set page.
        /// </summary>
        private void ClickOnSaveAndContinueButton()
        {
            //Logger Entry
            Logger.LogMethodEntry("QuestionSetPage", "ClickOnSaveAndContinueButton",
                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for save and continue button 
            base.WaitForElement(By.Id(QuestionSetPageResource.
                QuestionSetPage_SaveAndContinue_Button_Id));
            //Get Property of save and continue button
            IWebElement getPropertyOfSaveAndContinueButton =
                base.GetWebElementPropertiesById(QuestionSetPageResource.
                QuestionSetPage_SaveAndContinue_Button_Id);
            //Click on save and continue button
            base.ClickByJavaScriptExecutor(getPropertyOfSaveAndContinueButton);
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "ClickOnSaveAndContinueButton",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to Question Set Grid Iframe.
        /// </summary>
        private void SwitchToQuestionSetGridIframe()
        {
            //Logger Entry
            Logger.LogMethodEntry("QuestionSetPage", "SwitchToQuestionSetGridIframe",
                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for IfrmQuestionSetGrid Iframe
            base.WaitForElement(By.Id(QuestionSetPageResource.
                QuestionSetPage_QuestionSetGrid_Iframe_Id));
            //Switch to IfrmQuestionSetGrid Iframe
            base.SwitchToIFrame(QuestionSetPageResource.
                QuestionSetPage_QuestionSetGrid_Iframe_Id);
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "SwitchToQuestionSetGridIframe",
                   base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Store The SIM SIM 2010 QuestionSet In Memory.
        /// </summary>
        /// <param name="QuestionSetName">This is Questionset Name.</param>
        /// <param name="questionTypeEnum">This is question type enum.</param>
        private void StoreTheSIMQuestionSetInMemory(Guid QuestionSetName,
            Question.QuestionTypeEnum questionTypeEnum)
        {
            // Store The SIM Question Set In Memory
            Logger.LogMethodEntry("QuestionSetPage", "StoreTheSIMQuestionSetInMemory",
                   base.IsTakeScreenShotDuringEntryExit);
            //Store the SIM Question Set
            Question newQuestionType = new Question
            {
                Name = QuestionSetName.ToString(),
                QuestionType = questionTypeEnum,
                IsCreated = true,
            };
            newQuestionType.StoreQuestionInMemory();
            Logger.LogMethodExit("QuestionSetPage", "StoreTheSIMQuestionSetInMemory",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Edit QuestionSet Window.
        /// </summary>
        private void SelectEditQuestionSetWindow()
        {
            //Logger Entry
            Logger.LogMethodEntry("QuestionSetPage", "SelectEditQuestionSetWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Select 'Create Question Set' window
            base.WaitUntilWindowLoads(QuestionSetPageResource.
                QuestionSetPage_EditQuestionSet_Window_name);
            base.SelectWindow(QuestionSetPageResource.
                QuestionSetPage_EditQuestionSet_Window_name);
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage", "SelectEditQuestionSetWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Update The Question Set With QuestionType.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Set Type.</param>
        public void UpdateTheSIMQuestionsSet(
            Question.QuestionTypeEnum questionTypeEnum)
        {
            //Update The Question Set With QuestionType
            Logger.LogMethodEntry("QuestionSetPage", "UpdateTheSIMQuestionsSet",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Genrate Guid for Question set name 
                Guid questionSetName = Guid.NewGuid();
                //Select Create Question Set window
                this.SelectEditQuestionSetWindow();
                //Enter Question set name
                this.EnterQuestionSetName(questionSetName.ToString());
                //Store the SIMQuestion
                this.StoreTheSIMQuestionSetInMemory(
                                questionSetName, questionTypeEnum);                
                //Click on save and return button
                this.ClickOnEditedQuestionSaveAndReturnButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QuestionSetPage", "UpdateTheSIMQuestionsSet",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On EditedQuestion SaveAndReturn Button.
        /// </summary>
        private void ClickOnEditedQuestionSaveAndReturnButton()
        {
            //btnTabQuestionSetSave
            //Click On EditedQuestion SaveAndReturn Button.
            Logger.LogMethodEntry("QuestionSetPage", 
                "ClickOnEditedQuestionSaveAndReturnButton",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on save and return button
            base.WaitForElement(By.Id(QuestionSetPageResource.
                QuestionSetPage_EditedQuestion_SaveAndReturn_Button_Id));
            //Get the HTML Property of Save and return Button
            IWebElement getPropertyOfSaveAndReturnButton = base.
                GetWebElementPropertiesById(QuestionSetPageResource.
                QuestionSetPage_EditedQuestion_SaveAndReturn_Button_Id);
            //Click on Button
            base.ClickByJavaScriptExecutor(getPropertyOfSaveAndReturnButton);
            //Logger Exit
            Logger.LogMethodExit("QuestionSetPage",
                "ClickOnEditedQuestionSaveAndReturnButton",
               base.IsTakeScreenShotDuringEntryExit);
        }        
    }
}
