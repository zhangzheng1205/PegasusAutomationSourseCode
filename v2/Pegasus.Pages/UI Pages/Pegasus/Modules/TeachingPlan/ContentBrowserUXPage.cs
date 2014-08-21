using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Content Browser Page Actions.
    /// </summary>
    public class ContentBrowserUXPage : BasePage
    {
        /// <summary>
        /// This is the static instance of logger
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ContentBrowserUXPage));

        /// <summary>
        /// Select Activity For Study Plan Pre Test.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SelectActivityForPreTest(String activityName)
        {
            //Select Activity for Study Plan Pre Test
            Logger.LogMethodEntry("ContentBrowserUXPage", "SelectActivityForPreTest",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Content Browser Window
            try
            {
                base.WaitUntilPopUpLoads(ContentBrowserUXPageResource.
                       ContentBrowserUX_Page_Window_Title_Name);
                base.SelectWindow(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Window_Title_Name);
                //Switch to iframe
                this.SwitchToPopupPageContentIFrameLeft();
                //Get Activity Count
                SelectCheckBoxOfActivity(activityName);
                base.WaitUntilPopUpLoads(ContentBrowserUXPageResource.
                       ContentBrowserUX_Page_Window_Title_Name);
                //Select Window
                base.SelectWindow(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Window_Title_Name);
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AddandClose_Id_Locator));
                IWebElement getSaveCloseButton=base.GetWebElementPropertiesById
                    (ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AddandClose_Id_Locator);
                //Click on Add and CLose Button
                base.ClickByJavaScriptExecutor(getSaveCloseButton);

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            } 

            Logger.LogMethodExit("ContentBrowserUXPage", "SelectActivityForPreTest",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add SIM Question Folder from SIM Repository. 
        /// </summary>
        /// <param name="folderName">Name of SIM Question Folder.</param>
        public void SelectSIMQuestionFolder(String simQuestionFolderName)
        {
            //Logger Entry
            Logger.LogMethodEntry("ContentBrowserUXPage", "SelectSIMQuestionFolder",
                base.IsTakeScreenShotDuringEntryExit);
           
            try
            {
                base.WaitUntilWindowLoads(ContentBrowserUXPageResource.
                       ContentBrowserUX_Page_SelectQuestions_Window_Name);
                base.SelectWindow(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_SelectQuestions_Window_Name);
                //Switch to iframe
                this.SwitchToPopupPageContentIFrameLeft();
                //Get Activity Count
                SelectCheckBoxOfActivity(simQuestionFolderName);
                //Select Window
                base.SelectWindow(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_SelectQuestions_Window_Name);
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AddandClose_Id_Locator));
                //Click on Add and CLose Button
                IWebElement getPropertyOfAddAndCloseButton=base.
                    GetWebElementPropertiesById(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AddandClose_Id_Locator);
                base.ClickByJavaScriptExecutor(getPropertyOfAddAndCloseButton);

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            //Logger Exit
            Logger.LogMethodExit("ContentBrowserUXPage", "SelectSIMQuestionFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch To Popup Page Content iFrame Left.
        /// </summary>
        public void SwitchToPopupPageContentIFrameLeft()
        {
            //Logger entry
            Logger.LogMethodEntry("ContentBrowserUXPage",
                "SwitchToPopupPageContentIFrameLeft",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for web element
            base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_Frame_Id_Locator));
            //Select the Frame
            base.SwitchToIFrame(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_Frame_Id_Locator);
            //Logger exit
            Logger.LogMethodExit("ContentBrowserUXPage",
                "SwitchToPopupPageContentIFrameLeft",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Count.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        private void SelectCheckBoxOfActivity(String activityName)
        {
            Logger.LogMethodEntry("ContentBrowserUXPage", "GetActivityCount",
                base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(Convert.ToInt32(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_Sleep_Time));
            //Get Activity Count Present
            int getActivityCount = base.GetElementCountByXPath(
                ContentBrowserUXPageResource.
                  ContentBrowserUX_Page_ActivityCount_Xpath_Locator);
            for (int initialActivityCount = 1; initialActivityCount <=
                getActivityCount; initialActivityCount++)
            {
                //Get Activity Name
                String getActivityName = base.GetElementTextByXPath(
                    String.Format(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Student_Name_Xpath_Locator,
                    initialActivityCount));
                if (getActivityName.Contains(activityName))
                {
                    //Wait For Element
                    base.WaitForElement(By.XPath(String.Format(
                        ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Student_RadioButton_Xpath_Locator,
                    initialActivityCount)));
                    base.FocusOnElementByXPath(String.Format(
                        ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Student_RadioButton_Xpath_Locator,
                    initialActivityCount));
                    IWebElement getQuestionName = base.
                        GetWebElementPropertiesByXPath(
                        String.Format(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Student_RadioButton_Xpath_Locator,
                    initialActivityCount));
                    base.ClickByJavaScriptExecutor(getQuestionName);
                    break;
                }
            }
            Logger.LogMethodExit("ContentBrowserUXPage", "GetActivityCount",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selective Narative Image.
        /// </summary>
        /// <param name="imageName">Narative Image.</param>
        public void SelectNarativeImage(String imageName)
        {
            //Selective Narative Image
            Logger.LogMethodEntry("ContentBrowserUXPage", "SelectNarativeImage",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Select Content Window
                base.WaitUntilWindowLoads(ContentBrowserUXPageResource.
                        ContentBrowserUx_Page_SelectContent_Window_Name);
                base.SelectWindow(ContentBrowserUXPageResource.
                    ContentBrowserUx_Page_SelectContent_Window_Name);
                //Switch to Frame
                base.SwitchToIFrame(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Frame_Id_Locator);
                this.SelectCheckBoxOfActivity(imageName);
                //Select Select Content Window
                base.SelectWindow(ContentBrowserUXPageResource.
                    ContentBrowserUx_Page_SelectContent_Window_Name);
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AddandClose_Id_Locator));
                IWebElement getAssetSave = base.GetWebElementPropertiesById
                   (ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AddandClose_Id_Locator);
                //Click on Add and CLose Button
                base.ClickByJavaScriptExecutor(getAssetSave);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ContentBrowserUXPage", "SelectNarativeImage",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question.
        /// </summary>
        /// <param name="questionName">This is Question Name.</param>
        public void SelectQuestion(String questionName)
        {
            //Select Question 
            Logger.LogMethodEntry("ContentBrowserUXPage", "SelectQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectQuestionsWindow();
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Frame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Frame_Id_Locator);
                //Select Check Box of Question              
                this.SelectCheckBoxOfActivity(questionName);
                //Select Window
                base.SelectWindow(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_SelectQuestions_Window_Name);
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AddandClose_Id_Locator));
                IWebElement getAddCloseButton = base.GetWebElementPropertiesById
                (ContentBrowserUXPageResource.ContentBrowserUX_Page_AddandClose_Id_Locator);
                //Click on Add and CLose Button
                base.ClickByJavaScriptExecutor(getAddCloseButton);
                Thread.Sleep(Convert.ToInt32(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AfterClickSave_Button_Sleep_Time));
                base.IsPopUpClosed(2);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ContentBrowserUXPage", "SelectQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Questions Window.
        /// </summary>
        public void SelectQuestionsWindow()
        {
            //Logger entry
            Logger.LogMethodEntry("ContentBrowserUXPage", "SelectQuestionsWindow",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait for pop up window
            base.WaitUntilWindowLoads(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_SelectQuestions_Window_Name);
            //Select Select Questions Window
            base.SelectWindow(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_SelectQuestions_Window_Name);
            //Logger exit
            Logger.LogMethodExit("ContentBrowserUXPage", "SelectQuestionsWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'Add And Close' Button.
        /// </summary>
        public void ClickOnAddAndCloseButton()
        {
            //Click On 'Add And Close' Button
            Logger.LogMethodEntry("ContentBrowserUXPage", "ClickOnAddAndCloseButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the 'Save copy to' window
                base.WaitUntilWindowLoads(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Savecopyto_Window_Title_Name);
                base.SelectWindow(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Savecopyto_Window_Title_Name);
                //Wait for the 'Add and Close' button
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AddAndClose_Button_Id_Locator));
                IWebElement getAddCloseButton = base.GetWebElementPropertiesById
                         (ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AddAndClose_Button_Id_Locator);
                //Click on the Add and Close button
                base.ClickByJavaScriptExecutor(getAddCloseButton);
                Thread.Sleep(Convert.ToInt32(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AfterClickSave_Button_Sleep_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ContentBrowserUXPage", "ClickOnAddAndCloseButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Questions From Question Bank In Higher Ed.
        /// </summary>
        public void SelectQuestionsFromQuestionBankInHed()
        {
            //Logger entry
            Logger.LogMethodEntry("ContentBrowserUXPage",
                "SelectQuestionsFromQuestionBankInHed",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToLastOpenedWindow();
                //Select Window
                this.SelectQuestionsWindow();
                //Select IFrame
                this.SwitchToPopupPageContentIFrameLeft();
                //Get inside question level 1 folder 
                this.ClickOnQuestionFolderInHed(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Hed_QuestionFolder_Level1_Name);
                //Fetch the data from memory
                Question questionName = Question.Get(
                     Question.QuestionTypeEnum.TrueFalse);
                //Select Check Box of Question
                this.SelectCheckBoxOfActivity(questionName.Name);                
                //Wait for page load
                base.SetPageLoadWaitTime(5);
                //Click on the save ans close button
                this.ClickOnAddAndCloseButtonToSelectQuestions();                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger exit
            Logger.LogMethodExit("ContentBrowserUXPage",
                "SelectQuestionsFromQuestionBankInHed",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Question Folder to Navigate Inside. 
        /// </summary>
        /// <param name="questionFolderName">This is name of Question Folder</param>
        public void ClickOnQuestionFolderInHed(
            String questionFolderName)
        {
            //Logger entry
            Logger.LogMethodEntry("ContentBrowserUXPage",
                "ClickOnQuestionFolderInHed",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait for row element
            base.WaitForElement(By.XPath(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_QuestionContainer_Row_XPath_Locator));
            //Get content row count
            int getContentRows = base.GetElementCountByXPath(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_QuestionContainer_Row_XPath_Locator);
            for (int setQuestionFolderRowCount = 1;
                setQuestionFolderRowCount <= getContentRows;
                setQuestionFolderRowCount++)
            {
                //Wait for element
                base.WaitForElement(By.XPath(
                        String.Format(ContentBrowserUXPageResource.
                        ContentBrowserUX_Page_QuestionName_Link_XPath_Locator,
                            setQuestionFolderRowCount)));
                //Get content text
                String getContentText =
                    base.GetElementTextByXPath(
                        String.Format(ContentBrowserUXPageResource.
                        ContentBrowserUX_Page_QuestionName_Link_XPath_Locator,
                            setQuestionFolderRowCount));
                if (getContentText.Contains(questionFolderName))
                {
                    //Click on link
                    IWebElement getPropertyOfQuestionName = base.GetWebElementPropertiesByXPath
                        (String.Format(ContentBrowserUXPageResource.
                        ContentBrowserUX_Page_QuestionName_Link_XPath_Locator,
                        setQuestionFolderRowCount));
                    base.ClickByJavaScriptExecutor(getPropertyOfQuestionName);
                    break;
                }
            }
            //Wait to page load
            Thread.Sleep(Convert.ToInt32(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_Sleep_Time));
            Logger.LogMethodExit("ContentBrowserUXPage",
                "ClickOnQuestionFolderInHed",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Questions.
        /// </summary>
        private void SelectTheQuestions()
        {
            //Logger entry
            Logger.LogMethodEntry("ContentBrowserUXPage",
                "SelectTheQuestions",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait for element
            base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_SelectQuestion_Checkbox_Id_Locator));
            //Click on checkbox
            IWebElement getPropertyofCheckBox = base.
                GetWebElementPropertiesById(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_SelectQuestion_Checkbox_Id_Locator);
            base.ClickByJavaScriptExecutor(getPropertyofCheckBox);
            base.SwitchToDefaultPageContent();
            //Wait for page load
            base.SetPageLoadWaitTime(5);
            //Logger exit
            Logger.LogMethodEntry("ContentBrowserUXPage",
                "SelectTheQuestions",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add and Close Button.
        /// </summary>
        private void ClickOnAddAndCloseButtonToSelectQuestions()
        {
            //Logger entry
            Logger.LogMethodEntry("ContentBrowserUXPage",
                "ClickOnAddAndCloseButtonToSelectQuestions",
              base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectQuestionsWindow();
            //Wait for element
            base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_AddAndClose_Button_Id_Locator));
            //Get Html element
            IWebElement getPropertyofSaveandCloseButton = base.
                GetWebElementPropertiesById(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_AddAndClose_Button_Id_Locator);
            //Click on button
            base.ClickByJavaScriptExecutor(getPropertyofSaveandCloseButton);
            //Logger entry
            Thread.Sleep(Convert.ToInt32(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_Sleep_Time));
            Logger.LogMethodEntry("ContentBrowserUXPage",
                "ClickOnAddAndCloseButtonToSelectQuestions",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Question In SelectQuestion Window.
        /// </summary>
        /// <param name="questionName">This is Question Name.</param>
        public void SearchTheQuestionInSelectQuestionWindow(string questionName)
        {
            //Search The Question In SelectQuestion Window
            Logger.LogMethodEntry("ContentBrowserUXPage",
                "SearchTheQuestionInSelectQuestionWindow",
                          base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select The Question Window
                this.SelectQuestionsWindow();
                this.SwitchToPopupPageContentIFrameLeft();
                //Wait for the element
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Search_Textbox_Id_Locator));
                base.FillTextBoxById(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Search_Textbox_Id_Locator, questionName);
                //Wait for the 'GO' button
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Go_Button_Id_Locator));
                IWebElement getGoButton = base.GetWebElementPropertiesById
                    (ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Go_Button_Id_Locator);
                //Click the 'GO' button
                base.ClickByJavaScriptExecutor(getGoButton);
                Thread.Sleep(Convert.ToInt32(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AfterClickSave_Button_Sleep_Time));
                //Slect The Question Checkbox
                this.SlectTheQuestionCheckbox();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("ContentBrowserUXPage",
                "SearchTheQuestionInSelectQuestionWindow",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Slect The Question Checkbox.
        /// </summary>
        private void SlectTheQuestionCheckbox()
        {
            //Slect The Question Checkbox
            Logger.LogMethodEntry("ContentBrowserUXPage", "SlectTheQuestionCheckbox",
                          base.IsTakeScreenShotDuringEntryExit);
            //Wait for the Checkbox
            base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                ContentBrowserUX_Page_Question_Checkbox_Id_Locator));
            IWebElement getCheckbox = base.GetWebElementPropertiesById
                (ContentBrowserUXPageResource.
                ContentBrowserUX_Page_Question_Checkbox_Id_Locator);
            //Select the checkbox
            base.ClickByJavaScriptExecutor(getCheckbox);
            //Click On AddClose Button
            this.ClickOnAddCloseButton();
            Logger.LogMethodEntry("ContentBrowserUXPage", "SlectTheQuestionCheckbox",
                       base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Search and add SIM5 questions from bank.
        /// </summary>
        public void SearchAndAddSIM5question()
        {

            Logger.LogMethodEntry("ContentBrowserUXPage", "SearchAndAddSIM5question",
                          base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on Advanced Search option
                this.ClickOnAdvancedSearchLink();
                //Search SIM5 Question
                this.SearchSIM5Question();
                //Select and Add SIM5 question
                this.SelectAndAddSIM5Question();            
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("ContentBrowserUXPage", "SearchAndAddSIM5question",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select and add SIM5 Questions from Question Bank for SIM5 Activity.
        /// </summary>
        private void SelectAndAddSIM5Question()
        {
            Logger.LogMethodEntry("ContentBrowserUXPage", "SelectAndAddSIM5Question",
                          base.IsTakeScreenShotDuringEntryExit);
             try
             {
                 //Switch to last open window
                 base.SwitchToLastOpenedWindow();
                 //Switch to Iframe
                 base.SwitchToIFrameById(ContentBrowserUXPageResource.
                     ContentBrowserUX_Page_CourseMaterialsLibrary_Iframe_Id_Locator);
                 //Wait for element to select first SIM5 question
                 base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                     ContentBrowserUX_Page_CourseMaterialsLibrary_FirstSIM5Question_CheckBox_Id_Locator));
                 //Get checkbox property for first SIM5 question 
                 IWebElement GetFirstSIM5QuestionCheckBox = base.GetWebElementPropertiesById(ContentBrowserUXPageResource.
                     ContentBrowserUX_Page_CourseMaterialsLibrary_FirstSIM5Question_CheckBox_Id_Locator);
                 //Select first SIM5 question
                 base.ClickByJavaScriptExecutor(GetFirstSIM5QuestionCheckBox);
                 //Switch to last open Window
                 base.SwitchToLastOpenedWindow();
                 //Wait for Add and Close button
                 base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                     ContentBrowserUX_Page_AddAndClose_Button_Id_Locator));
                 //Get Property of Add and Close button
                 IWebElement GetAddAndCloseButton = base.GetWebElementPropertiesById(ContentBrowserUXPageResource.
                     ContentBrowserUX_Page_AddAndClose_Button_Id_Locator);
                 //Click on Add and Close button
                 base.ClickByJavaScriptExecutor(GetAddAndCloseButton);
             }
             catch (Exception e)
             {
                 ExceptionHandler.HandleException(e);
             }
             Logger.LogMethodEntry("ContentBrowserUXPage", "SelectAndAddSIM5Question",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        private void SearchSIM5Question()
        {

            Logger.LogMethodEntry("ContentBrowserUXPage", "SearchSIM5Question",
                          base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for last opened window
                base.SwitchToLastOpenedWindow();
                //Wait for element 'All Question Type'
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AdvancedSearch_AllQuestionTypes_CheckBox_IframeId_locator));
                //Switch to Iframe
                base.SwitchToIFrameById(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AdvancedSearch_AllQuestionTypes_CheckBox_IframeId_locator);
                //Wait for All QuestionTypes checkbox
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AdvancedSearch_AllQuestionTypes_CheckBox_Id));
                //Get Properity for All Question Types checkbox
                IWebElement GetAllQuestionTypeCheckBox = base.GetWebElementPropertiesById(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AdvancedSearch_AllQuestionTypes_CheckBox_Id);
                //Uncheck checkbox for All QuestionTypes
                base.ClickByJavaScriptExecutor(GetAllQuestionTypeCheckBox);
                //Wait for checkbox element for SIM5 Question
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AdvancedSearch_SIM5Question_CheckBox_Id));
                //Get WebElement property for SIM5 check box
                IWebElement GetSIM5CheckBox = base.GetWebElementPropertiesById(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AdvancedSearch_SIM5Question_CheckBox_Id);
                //Select the checkbox for SIM5 Question
                base.ClickByJavaScriptExecutor(GetSIM5CheckBox);
                //Click on Search button
                base.ClickButtonById(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AdvancedSearch_Search_Button_Id);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("ContentBrowserUXPage", "SearchSIM5Question",
                       base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Advanced Search Link
        /// </summary>
        private void ClickOnAdvancedSearchLink()
        {

            Logger.LogMethodEntry("ContentBrowserUXPage", "ClickOnAdvancedSearchLink",
                          base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for IFrame
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Frame_Id_Locator));
                //Switch to Iframe
                base.SwitchToIFrameById(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Frame_Id_Locator);
                //Wait for Element Advanced Search
                base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrtowserUX_Page_AdvancedSearch_Div_Id_locator));
                //Get property for Advanced Search option
                IWebElement GetAdvancedSearchOption = base.GetWebElementPropertiesById
                    (ContentBrowserUXPageResource.ContentBrtowserUX_Page_AdvancedSearch_Div_Id_locator);
                //Click on Advanced Search option
                base.ClickByJavaScriptExecutor(GetAdvancedSearchOption);
                //Move focus to last open window
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("ContentBrowserUXPage", "ClickOnAdvancedSearchLink",
                       base.IsTakeScreenShotDuringEntryExit);
        }
             

        /// <summary>
        /// Click On Add and Close Button.
        /// </summary>
        private void ClickOnAddCloseButton()
        {
            //Click On AddClose Button
            Logger.LogMethodEntry("ContentBrowserUXPage", "ClickOnAddCloseButton",
                          base.IsTakeScreenShotDuringEntryExit);
            //Select Questions Window
            this.SelectQuestionsWindow();
            //Wait for the element
            base.WaitForElement(By.Id(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AddandClose_Id_Locator));
            IWebElement getAddCloseButton = base.GetWebElementPropertiesById
                (ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AddandClose_Id_Locator);
            //Click on 'AddClose' button
            base.ClickByJavaScriptExecutor(getAddCloseButton);
            Thread.Sleep(Convert.ToInt32(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_AfterClickSave_Button_Sleep_Time));
            base.IsPopUpClosed(2);
            Logger.LogMethodEntry("ContentBrowserUXPage", "ClickOnAddCloseButton",
                       base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
