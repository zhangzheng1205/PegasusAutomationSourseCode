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
    /// This Class Handles QlGridUX Page actions
    /// </summary>
    public class QlGridUXPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(QlGridUXPage));

        /// <summary>
        /// Select Add Course Materials Button.
        /// </summary>       
        public void SelectAddCourseMaterialsButton()
        {
            //Select Add Course Materials Button
            Logger.LogMethodEntry("QlGridUXPage", "SelectAddCourseMaterialsButton",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {                
                base.RefreshTheCurrentPage();
                //Select Question Bank Window
                this.SelectQuestionBankWindow();                
                base.WaitForElement(By.XPath (QlGridUXPageResource.
                    QlGridUX_Page_AddCourseMaterials_Xpath_Locator));
                //Get Element Property
                IWebElement getAddCourseMaterialsProperty =
                    base.GetWebElementPropertiesByXPath(QlGridUXPageResource.
                    QlGridUX_Page_AddCourseMaterials_Xpath_Locator);
                //Click On 'Add Course Materials' Button
                base.ClickByJavaScriptExecutor(getAddCourseMaterialsProperty);            
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "SelectAddCourseMaterialsButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question Type.
        /// </summary>
        /// <param name="questionType">This is Question Type.</param>
        public void SelectQuestionType(String questionType)
        {
            //Select Question Type
            Logger.LogMethodEntry("QlGridUXPage", "SelectQuestionType",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Question Bank Window
                this.SelectQuestionBankWindow();
                base.WaitForElement(By.LinkText(questionType));
                //Get Button Property
                IWebElement getButtonProperty = base.
                    GetWebElementPropertiesByLinkText(questionType);
                base.ClickByJavaScriptExecutor(getButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "SelectQuestionType",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question Bank Window.
        /// </summary>
        public void SelectQuestionBankWindow()
        {
            //Select Question Bank Window
            Logger.LogMethodEntry("QlGridUXPage", "SelectQuestionBankWindow",
                  base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(QlGridUXPageResource.
                    QlGridUX_Page_Question_Bank_WindowName_Locator);
            //Select Question Bank Window
            base.SelectWindow(QlGridUXPageResource.
                    QlGridUX_Page_Question_Bank_WindowName_Locator);
            base.WaitForElement(By.Id(QlGridUXPageResource.
                QlGridUX_Page_QuestionLibrary_Frame_Id_Locator));
            //Switch To Frame
            base.SwitchToIFrame(QlGridUXPageResource.
                QlGridUX_Page_QuestionLibrary_Frame_Id_Locator);
            Logger.LogMethodExit("QlGridUXPage", "SelectQuestionBankWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Questions.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        public void CreateQuestions(
            Question.QuestionTypeEnum questionTypeEnum)
        {
            //Create Questions
            Logger.LogMethodEntry("QlGridUXPage", "CreateQuestions",
                  base.IsTakeScreenShotDuringEntryExit);
            switch (questionTypeEnum)
            {
                case Question.QuestionTypeEnum.DropDownList:
                    //Create 'Drop Down List' Question
                    new PullDownListPage().CreateDropDownListQuestion();
                    break;
                case Question.QuestionTypeEnum.EntryList:
                    //Create 'Entry List' Question
                    new EntryListPage().CreateEntryListQuestion();
                    break;
                case Question.QuestionTypeEnum.Essay:
                    //Create 'Essay' Question
                    new EssayPage().CreateEssayQuestion();
                    break;
                case Question.QuestionTypeEnum.FileUpload:
                    //Create 'File Upload' Question
                    new FileUploadPage().CreateFileUploadQuestion();
                    break;
                case Question.QuestionTypeEnum.FillInTheBlank:
                    //Create 'Fill In The Blank' Question
                    new FillInTheBlanksPage().CreateFillInTheBlanksQuestion();
                    break;
                case Question.QuestionTypeEnum.Matching:
                    //Create 'Matching' Question
                    new MatchingPage().CreateMatchingQuestion();
                    break;
                case Question.QuestionTypeEnum.MultipleResponse:
                    //Create 'Multiple Response'Question
                    new MultipleResponsePage().CreateMultipleResponseQuestion();
                    break;
                //Create 'TextMatch'Question
                case Question.QuestionTypeEnum.TextMatch:
                    new TextMatchPage().CreateTextMatchQuestion();
                    break;
                //Create 'Numeric'Question
                case Question.QuestionTypeEnum.Numeric:
                    new NumericPage().CreateNumericQuestion();
                    break;
                //Create 'Multiple Choice'Question
                case Question.QuestionTypeEnum.MultipleChoice:
                    new MultipleChoicePage().CreateMultipleChoiceQuestion();
                    break;
                //Create 'Ranking'Question
                case Question.QuestionTypeEnum.Ranking:
                    new RankingPage().CreateRankingQuestion();
                    break;

            }
            Logger.LogMethodExit("QlGridUXPage", "CreateQuestions",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// ClipBoard Items Text Displayed.
        /// </summary>
        /// <returns>ClipBoard Items Text</returns>
        public String GetClipBoardItemsTextDisplayed()
        {
            //Is ClipBoard Items Displayed
            Logger.LogMethodEntry("QlGridUXPage", "GetClipBoardItemsTextDisplayed",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getClipBoardItemsTextDisplayed = string.Empty;
            try
            {
                //Select Question Bank Window
                this.SelectQuestionBankWindow();
                //Delete options displayed                
                string getDeleteText = base.GetElementTextById(QlGridUXPageResource.
                    QlGridUX_Page_Clipboard_Delete_Id_Locator).Trim();
                //Copy options displayed                
                string getCopyText = base.GetElementTextById(QlGridUXPageResource.
                    QlGridUX_Page_Clipboard_Copy_Id_Locator).Trim();
                //Cut options displayed
                string getCutText = base.GetElementTextById(QlGridUXPageResource.
                    QlGridUX_Page_Clipboard_Cut_Id_Locator).Trim();
                //Paste options displayed                
                string getPasteText = base.GetElementTextById(QlGridUXPageResource.
                    QlGridUX_Page_Clipboard_Paste_Id_Locator).Trim();
                //Reports options displayed                
                string getReportsText = base.GetElementTextById(QlGridUXPageResource.
                    QlGridUX_Page_Clipboard_Report_Id_Locator).Trim();
                //All clipboard items displayed
                getClipBoardItemsTextDisplayed = getDeleteText + getCopyText + 
                    getCutText + getPasteText + getReportsText;                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "GetClipBoardItemsTextDisplayed",
              base.IsTakeScreenShotDuringEntryExit);
            return getClipBoardItemsTextDisplayed;
        }

        /// <summary>
        /// Select The Question From QuestionBank.
        /// </summary>
        /// <param name="questionName">This is question type.</param>
        public void SelectTheQuestionFromQuestionBank(
            String questionName)
        {
            //Select The Question From QuestionBank
            Logger.LogMethodEntry("QlGridUXPage", "SelectTheQuestionFromQuestionBank",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click On The Question Folder
                this.ClickOnTheQuestionFolder(QlGridUXPageResource.QlGridUX_Page_Folder_Name);
                //Click On The Question Folder
                this.ClickOnTheQuestionFolder(QlGridUXPageResource.QlGridUX_Page_SecondFolder_Name);
                //Select the Question 
                int rowCount=this.GetAssetRowCount(questionName);
                //Selct Question Checkbox
                this.SelectCheckbox(rowCount);               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "SelectTheQuestionFromQuestionBank",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Checkbox.
        /// </summary>
        /// <param name="rowCount">This is Asset RowCount</param>
        private void SelectCheckbox(int rowCount)
        {
            //Select Checkbox
            Logger.LogMethodEntry("QlGridUXPage", "SelectCheckbox",
             base.IsTakeScreenShotDuringEntryExit);
            //Wait for Question Xpath
            base.WaitForElement(By.XPath(string.Format(QlGridUXPageResource.
              QlGridUX_Page_Select_Checkbox_QuestionName_Xpath_Locator, rowCount)));
            base.SelectCheckBoxByXPath(String.Format(QlGridUXPageResource.
              QlGridUX_Page_Select_Checkbox_QuestionName_Xpath_Locator, rowCount));
            Logger.LogMethodExit("QlGridUXPage", "SelectCheckbox",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Question Folder.
        /// </summary>
        /// <param name="folderNmae">This is Folder Name</param>
        public void ClickOnTheQuestionFolder(String folderNmae)
        {
            //Click On The Question Folder
            Logger.LogMethodEntry("QlGridUXPage", "ClickOnTheQuestionFolder",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Question Bank Window
                this.SelectQuestionBankWindow();
                //Wait for the folder
                base.WaitForElement(By.PartialLinkText(folderNmae));
                IWebElement getFolderProperty = base.GetWebElementPropertiesByPartialLinkText
                    (folderNmae);
                //Click on folder link
                base.ClickByJavaScriptExecutor(getFolderProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "ClickOnTheQuestionFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Asset Row Count.
        /// </summary>
        /// <param name="assetName">This is Question name.</param>
        private int GetAssetRowCount(String assetName)
        {
            //Get Asset Row Count
            Logger.LogMethodEntry("QlGridUXPage", "GetAssetRowCount",
             base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssetName = string.Empty;
            int getRowCount = Convert.ToInt32(QlGridUXPageResource.
                    QlGridUX_Page_RowCount_Initial_Value);
            //Select Question Bank Window
            this.SelectQuestionBankWindow();
            //Get Asset Count
            int getAssetCount = base.GetElementCountByXPath(QlGridUXPageResource.
                QlGridUX_Page_Question_Count_Xpath_Locator);
            for (int setRowCount = Convert.ToInt32(QlGridUXPageResource.
                QlGridUX_Page_Loop_Initial_Value); setRowCount <= getAssetCount; setRowCount++)
            {
                if(base.IsElementPresent(By.XPath(string.Format(QlGridUXPageResource.
                    QlGridUX_Page_Question_Name_Xpath_Locator, setRowCount)), 
                    Convert.ToInt32(QlGridUXPageResource.QlGridUX_Page_WaitforLocator)))
                {
                    //Wait for Element
                base.WaitForElement(By.XPath(string.Format(QlGridUXPageResource.
                    QlGridUX_Page_Question_Name_Xpath_Locator, setRowCount)));
                //Get Asset Name
                getAssetName = base.GetElementTextByXPath(string.Format(
                 QlGridUXPageResource.
                     QlGridUX_Page_Question_Name_Xpath_Locator, setRowCount));
                if (getAssetName.Contains(assetName))
                {
                    getRowCount = setRowCount;
                    break;
                }
                }                     
            }
            Logger.LogMethodExit("QlGridUXPage", "GetAssetRowCount",
          base.IsTakeScreenShotDuringEntryExit);
            return getRowCount;
        }

        /// <summary>
        /// Select Option In Course Materials.
        /// </summary>
        /// <param name="option">This is option In Course Materials</param>
        public void SelectOptionInCourseMaterials(String option)
        {
            //Select Option In Course Materials
            Logger.LogMethodEntry("QlGridUXPage", "SelectOptionInCourseMaterials",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Question Bank Window                                         
                this.SelectQuestionBankWindow();
                base.WaitForElement(By.PartialLinkText(option));
                //Get Button Property
                IWebElement getButtonProperty = base.
                    GetWebElementPropertiesByPartialLinkText(option);
                //Click On Button
                base.ClickByJavaScriptExecutor(getButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "SelectOptionInCourseMaterials",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Searched Folder Name.
        /// </summary>
        /// <param name="activityType">This is Activity Type</param>
        /// <returns>Searched Folder Name</returns>
        public String GetSearchedFolderName(String activityType)
        {
            //Get Searched Folder Name
            Logger.LogMethodEntry("QlGridUXPage", "getSearchedFolderName",
                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssetName = string.Empty;
            try
            {
                //Select Question Bank Window                                         
                this.SelectQuestionBankWindow();
                //Click On search Link
                this.ClickOnSearchLink();
                //Fill Search Text And Click on Go Button
                this.FillSearchTextAndClickonGoButton(activityType);
                //Select Question Bank Window                                         
                this.SelectQuestionBankWindow();
                base.WaitForElement(By.XPath(QlGridUXPageResource.
                    QlGridUX_Page_SearchedFolder_Xpath_Locator));
                //Get Asset Name
                getAssetName = base.GetElementTextByXPath(QlGridUXPageResource.
                    QlGridUX_Page_SearchedFolder_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "getSearchedFolderName",
               base.IsTakeScreenShotDuringEntryExit);
            return getAssetName;
        }

        /// <summary>
        /// Click On search Link.
        /// </summary>
        private void ClickOnSearchLink()
        {
            //Click On search Link
            Logger.LogMethodEntry("QlGridUXPage", "ClickOnSearchLink",
                  base.IsTakeScreenShotDuringEntryExit);
            if (!base.IsElementPresent(By.Id(QlGridUXPageResource.
                QlGridUX_Page_ClearResult_Link_Id_Locator),
                Convert.ToInt32(QlGridUXPageResource.QlGridUX_Page_WaitforLocator)))
            {
                base.WaitForElement(By.Id(QlGridUXPageResource.
                    QlGridUX_Page_SearchButton_Id_Locator));
                //Get Search Button property
                IWebElement getSearchButtonProperty =
                    base.GetWebElementPropertiesById(QlGridUXPageResource.
                    QlGridUX_Page_SearchButton_Id_Locator);
                //Click on Search Button
                base.ClickByJavaScriptExecutor(getSearchButtonProperty);
            }
            Logger.LogMethodExit("QlGridUXPage", "ClickOnSearchLink",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Search Text And Click on Go Button.
        /// </summary>
        /// <param name="activityType">This is Activity Type</param>
        private void FillSearchTextAndClickonGoButton(
            String activityType)
        {
            //Fill Search Text And Click on Go Button
            Logger.LogMethodEntry("QlGridUXPage", "FillSearchTextAndClickonGoButton",
                  base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(QlGridUXPageResource.
                QlGridUX_Page_SearchText_Id_Locator));
            base.ClearTextById(QlGridUXPageResource.
                QlGridUX_Page_SearchText_Id_Locator);
            //Fill Folder Name
            base.FillTextBoxById(QlGridUXPageResource.
                QlGridUX_Page_SearchText_Id_Locator, activityType);
            base.WaitForElement(By.Id(QlGridUXPageResource.
                QlGridUX_Page_GoButton_Id_Locator));
            //Get Go Button Property
            IWebElement getGoButtonProperty = base.GetWebElementPropertiesById(
                QlGridUXPageResource.QlGridUX_Page_GoButton_Id_Locator);
            //Click on Go Button
            base.ClickByJavaScriptExecutor(getGoButtonProperty);
            Thread.Sleep(Convert.ToInt32(QlGridUXPageResource.
                QlGridUX_Page_Thread_WaitTime_Value));
            Logger.LogMethodExit("QlGridUXPage", "FillSearchTextAndClickonGoButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Is ClipBoard Items Get Enabled State. 
        /// </summary>
        /// <returns>Clipboard items enabled state</returns>
        public Boolean IsClipBoardItemsGetEnabledState()
        {
            //Is ClipBoard Items Get Enabled State 
            Logger.LogMethodEntry("QlGridUXPage", "IsClipBoardItemsDisplayedEnabledState",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isClipBoardItemsgetEnabledStateDisplayed = false;
            try
            {
                //Select Question Bank Window
                this.SelectQuestionBankWindow();
                //Delete options displayed
                bool isDeleteOptionDisplayed = base.IsElementPresent(By.Id(QlGridUXPageResource.
                    QlGridUX_Page_Clipboard_Delete_Id_Locator));
                //Copy options displayed
                bool isCopyOptionDisplayed = base.IsElementPresent(By.Id(QlGridUXPageResource.
                    QlGridUX_Page_Clipboard_Copy_Id_Locator));
                //Cut options displayed
                bool isCutOptionDisplayed = base.IsElementPresent(By.Id(QlGridUXPageResource.
                    QlGridUX_Page_Clipboard_Cut_Id_Locator));
                //All clipboard items displayed
                isClipBoardItemsgetEnabledStateDisplayed = isDeleteOptionDisplayed &&
                    isCopyOptionDisplayed && isCutOptionDisplayed;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "IsClipBoardItemsDisplayedEnabledState",
              base.IsTakeScreenShotDuringEntryExit);
            return isClipBoardItemsgetEnabledStateDisplayed;
        }

        /// <summary>
        ///Paste Option Get Displayed Enabled State.
        /// </summary>
        /// <returns>Paste option in enabled state.</returns>
        public Boolean IsPasteOptionGetDisplayedEnabledState()
        {
            //Paste Option Get Displayed Enabled State
            Logger.LogMethodEntry("QlGridUXPage", "IsPasteOptionGetDisplayedEnabledState",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isPasteOptionDisplayedEnabledState = false;
            try
            {
                //Select Question Bank Window
                this.SelectQuestionBankWindow();
                //Paste options displayed
                isPasteOptionDisplayedEnabledState=base.IsElementEnabledById(
                    QlGridUXPageResource.QlGridUX_Page_Clipboard_Paste_Id_Locator); 
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "IsPasteOptionGetDisplayedEnabledState",
              base.IsTakeScreenShotDuringEntryExit);
            return isPasteOptionDisplayedEnabledState;
        }

        /// <summary>
        ///Click On Copy Clipboard Option.
        /// </summary>
        public void ClickOnCopyClipboardOption()
        {
            //Click On Copy Clipboard Option
            Logger.LogMethodEntry("QlGridUXPage", "ClickOnCopyClipboardOption",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(QlGridUXPageResource.
                        QlGridUX_Page_Clipboard_Copy_Id_Locator));
                IWebElement getCopyproperty = base.GetWebElementPropertiesById
                    (QlGridUXPageResource.
                        QlGridUX_Page_Clipboard_Copy_Id_Locator);
                //Click on the 'Copy' option
                base.ClickByJavaScriptExecutor(getCopyproperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "ClickOnCopyClipboardOption",
              base.IsTakeScreenShotDuringEntryExit);
        }      

        /// <summary>
        /// Click On Cmenu Of Folder.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        /// <param name="assetCmenuOption">Thos is Asset Cmenu Option.</param>
        public void ClickOnCmenuOfAsset(String assetName, 
            String assetCmenuOption)
        {
            //Click On Cmenu Of Folder
            Logger.LogMethodEntry("QlGridUXPage", "ClickOnCmenuOfAsset",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Initialize Variable
                int rowCount = Convert.ToInt32(QlGridUXPageResource.
                    QlGridUX_Page_RowCount_Initial_Value);
                //Get Asset Row Count
                rowCount = this.GetAssetRowCount(assetName);
                base.WaitForElement(By.XPath(string.Format(QlGridUXPageResource.
                    QlGridUX_Page_Question_Name_Xpath_Locator, rowCount)));
                //Get Element Property
                IWebElement getFolder = base.GetWebElementPropertiesByXPath(string.Format(
                     QlGridUXPageResource.QlGridUX_Page_Question_Name_Xpath_Locator, rowCount));
                //Perform Mousehover
                base.PerformMouseHoverByJavaScriptExecutor(getFolder);
                //Get Element Property
                IWebElement getCmenuIcon = base.GetWebElementPropertiesByXPath((string.Format
                    (QlGridUXPageResource.QlGridUX_Page_Folder_CmenuIcon_Xpath_Locator, rowCount)));
                //Click on Cmenu Icon
                base.ClickByJavaScriptExecutor(getCmenuIcon);
                //Get Element Property
                IWebElement getCmenuOption = base.
                    GetWebElementPropertiesByPartialLinkText(assetCmenuOption);
                //Click on Cmenu Option
                base.ClickByJavaScriptExecutor(getCmenuOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "ClickOnCmenuOfAsset",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Score For Questions.
        /// </summary>
        public void SetScoreForQuestions(String score)
        {
            //Set Score For Questions
            Logger.LogMethodEntry("QlGridUXPage", "SetScoreForQuestions",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Folder Level Preferences Window
                this.SelectFolderLevelPreferencesWindow();
                base.WaitForElement(By.Id(QlGridUXPageResource.
                    QlGridUX_Page_Score_Checkbox_Id_Locator));
                //Enter Score and Save
                this.EnterScoreAndSave(score);
                //Select Pegasus Window
                this.SelectPegasusWindow();
                base.WaitForElement(By.Id(QlGridUXPageResource.
                    QlGridUX_Page_Ok_Button_Id_Locator));
                //Click on Ok Button
                base.ClickButtonById(QlGridUXPageResource.
                    QlGridUX_Page_Ok_Button_Id_Locator);
                //Select Question Bank Window                
                base.WaitUntilWindowLoads(QlGridUXPageResource.
                    QlGridUX_Page_Question_Bank_WindowName_Locator);
                base.SelectWindow(QlGridUXPageResource.
                    QlGridUX_Page_Question_Bank_WindowName_Locator);
                base.WaitForElement(By.Id(QlGridUXPageResource.
                    QlGridUX_Page_QuestionLibrary_Frame_Id_Locator));
                //Refresh The Frame
                base.RefreshIFrameByJavaScriptExecutor(QlGridUXPageResource.
                    QlGridUX_Page_QuestionLibrary_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "SetScoreForQuestions",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Score And Save.
        /// </summary>
        /// <param name="score">This is Score</param>
        private void EnterScoreAndSave(String score)
        {
            //Enter Score And Save
            Logger.LogMethodEntry("QlGridUXPage", "EnterScoreAndSave",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Checkbox
            base.SelectCheckBoxById(QlGridUXPageResource. 
                QlGridUX_Page_Score_Checkbox_Id_Locator);
            base.WaitForElement(By.Id(QlGridUXPageResource.
                QlGridUX_Page_Score_Textbox_Id_Locator));
            //Fill Score in Textbox
            base.FillTextBoxById(QlGridUXPageResource.
                QlGridUX_Page_Score_Textbox_Id_Locator, score);
            IWebElement getApplyToAllButton = base.
                GetWebElementPropertiesByPartialLinkText
                (QlGridUXPageResource.
                QlGridUX_Page_ApplyToAllButton_PartialLinkText_Value);
            //Click on Button
            base.ClickByJavaScriptExecutor(getApplyToAllButton);
            Logger.LogMethodExit("QlGridUXPage", "EnterScoreAndSave",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Pegasus Window.
        /// </summary>
        private void SelectPegasusWindow()
        {
            //Select Pegasus Window
            Logger.LogMethodEntry("QlGridUXPage", "SelectPegasusWindow",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(QlGridUXPageResource.QlGridUX_Page_Pegasus_Window_Title);
            //Select Window
            base.SelectWindow(QlGridUXPageResource.QlGridUX_Page_Pegasus_Window_Title);
            Logger.LogMethodExit("QlGridUXPage", "SelectPegasusWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Folder Level Preferences Window.
        /// </summary>
        private void SelectFolderLevelPreferencesWindow()
        {
            //Select Folder Level Preferences Window
            Logger.LogMethodEntry("QlGridUXPage", "SelectFolderLevelPreferencesWindow",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(QlGridUXPageResource.
                QlGridUX_Page_FolderLevelPreferences_Window_Title);
            //Select Window
            base.SelectWindow(QlGridUXPageResource.
                QlGridUX_Page_FolderLevelPreferences_Window_Title);
            Logger.LogMethodExit("QlGridUXPage", "SelectFolderLevelPreferencesWindow",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Question.
        /// </summary>
        /// <param name="questionName">This is Question Name.</param>
        /// <param name="questionCmenuOption">This is Question Cmenu Option.</param>
        public void ClickOnCmenuOfQuestion(string questionName, string questionCmenuOption)
        {
            //Click On Cmenu Of Question
            Logger.LogMethodEntry("QlGridUXPage", "ClickOnCmenuOfQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Question Bank Window                                         
                this.SelectQuestionBankWindow();
                //Click On search Link
                this.ClickOnSearchLink();
                //Fill Search Text And Click on Go Button
                this.FillSearchTextAndClickonGoButton(questionName);
                //Select Question Cmenu
                this.SelectQuestionCmenu(questionCmenuOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "ClickOnCmenuOfQuestion",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question Cmenu.
        /// </summary>
        /// <param name="questionCmenuOption">This is Question Cmenu.</param>
        private void SelectQuestionCmenu(string questionCmenuOption)
        {
            //Select Question Cmenu
            Logger.LogMethodEntry("QlGridUXPage", "SelectQuestionCmenu",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(QlGridUXPageResource.
                QlGridUX_Page_Searched_QuestionName_Xpath_Locator));
            //Get Element Property
            IWebElement getQuestionNameProperty =
                base.GetWebElementPropertiesByXPath(QlGridUXPageResource.
                QlGridUX_Page_Searched_QuestionName_Xpath_Locator);
            //Mouse Hover On Question
            base.PerformMouseHoverByJavaScriptExecutor(getQuestionNameProperty);
            base.WaitForElement(By.ClassName(QlGridUXPageResource.
                QlGridUX_Page_CmenuIcon_ClassName_Locator));
            //Get Element Property
            IWebElement getCmenuIconProperty =
                base.GetWebElementPropertiesByClassName(QlGridUXPageResource.
                QlGridUX_Page_CmenuIcon_ClassName_Locator);
            //Click On Cmenu Icon
            base.ClickByJavaScriptExecutor(getCmenuIconProperty);
            IWebElement getCmenuOptionProperty;
            if (questionCmenuOption == QlGridUXPageResource.
                             QlGridUX_Page_Delete)
            {
               //Get all delete links
                ICollection<IWebElement> GetAllDeleteOption=
                    base.GetWebElementsCollectionByPartialLinkText
                    (questionCmenuOption);
                //Get Element Property
                getCmenuOptionProperty = GetAllDeleteOption.ElementAt(1);
            }
            else
            {
                base.WaitForElement(By.PartialLinkText(questionCmenuOption));
                //Get Element Property
                getCmenuOptionProperty =
                base.GetWebElementPropertiesByPartialLinkText(questionCmenuOption);
            }           
            //Click On Cmenu Option
            base.ClickByJavaScriptExecutor(getCmenuOptionProperty);
            Logger.LogMethodExit("QlGridUXPage", "SelectQuestionCmenu",
             base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify the question added in Map Learning Objectives to Questions tab.
        /// </summary>
        /// <param name="questionName">This is question Name.</param>
        public bool VerifyTheQuestionAdded(string questionName)
        {
            //Verify the question added
            Logger.LogMethodEntry("QlGridUXPage", "VerifyTheQuestionAdded",
                base.IsTakeScreenShotDuringEntryExit);
            this.SelectQuestionBankWindow();
            bool returnValue = false;
            try
            {
                int gridPages=1;
                //Check for Paginator
                if (IsElementPresent(By.XPath(QlGridUXPageResource.
                    QlGridUX_page_Paginator_Total_Page_Xpath),5))
                {
                 //Get Page count element
                 IWebElement gridPageCount = base.GetWebElementPropertiesByXPath(QlGridUXPageResource.
                    QlGridUX_page_Paginator_Total_Page_Xpath);
                 //Set page count
                 gridPages = Convert.ToInt32(gridPageCount.Text.Substring
                            (gridPageCount.Text.Length - 1));
                }
                for (int counter = 0; counter <= gridPages; counter++)
                {
                 //Check question present in current page or not.
                if (IsElementPresent(By.XPath
                    (string.Format(QlGridUXPageResource.
                    QlGridUX_page_Question_title_Xpath, questionName)),5))
                    {
                       base.FocusOnElementByXPath(string.Format(QlGridUXPageResource.
                      QlGridUX_page_Question_title_Xpath, questionName));
                    returnValue=true;
                        break ;
                    }
                    else
                    {
                        if (IsElementPresent(By.XPath(QlGridUXPageResource.
                            QlGridUX_page_Paginator_Next_Xpath),5))
                        {
                        //Get next button   
                        IWebElement nextButton = base.GetWebElementPropertiesByXPath
                            (QlGridUXPageResource.
                            QlGridUX_page_Paginator_Next_Xpath);
                         //Click on Next button
                            base.ClickByJavaScriptExecutor(nextButton);
                        }
                    }
                }
               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("QlGridUXPage", "VerifyTheQuestionAdded",
               base.IsTakeScreenShotDuringEntryExit);
            return returnValue;
        }
    }
}
