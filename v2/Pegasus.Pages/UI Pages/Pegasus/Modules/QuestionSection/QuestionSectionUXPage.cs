using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.QuestionSection;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the create question group actions.
    /// </summary>
    public class QuestionSectionUXPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(QuestionSectionUXPage));

        /// <summary>
        /// Create question group.
        /// </summary>
        public void CreateQuestionGroup()
        {
            //Logger entry
            Logger.LogMethodEntry("QuestionSectionUXPage",
                "CreateQuestionGroup", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select window
                this.SelectQuestionGroupWindow();
                //Enter group name
                this.EnterGroupName();
                //Enter text in HTML editor
                this.EnterTextInHTMLEditor();
                //Click add question from bank
                this.ClickAddFromQuestionBank();
                //Select Question
                new ContentBrowserUXPage().SelectQuestionsFromQuestionBankInHed();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger exit
            Logger.LogMethodExit("QuestionSectionUXPage",
                "CreateQuestionGroup", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Add From Question Bank Image.
        /// </summary>
        private void ClickAddFromQuestionBank()
        {
            //Logger entry
            Logger.LogMethodEntry("QuestionSectionUXPage",
                "ClickAddFromQuestionBank", base.isTakeScreenShotDuringEntryExit);
            //Wait for web element
            base.WaitForElement(By.Id(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_AddQuestion_Tab_Id_Locator));
            //Get HTML Peroperty od Add Question Tab
            IWebElement getPropertyofAddQuestionTab = 
                base.GetWebElementPropertiesById(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_AddQuestion_Tab_Id_Locator);
            //Click on button
            base.ClickByJavaScriptExecutor(getPropertyofAddQuestionTab);
            //Wait for web element
            base.WaitForElement(By.Id(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_QuestionGroup_IFrame_Id_Locator));
            //Switch to iframe
            base.SwitchToIFrameById(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_QuestionGroup_IFrame_Id_Locator);
            //Wait for web element
            base.WaitForElement(
                By.ClassName(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_AddFromQuestionBank_Image_Id_Locator));
            //Get HTML Peroperty Add from Question Bank
            IWebElement getPropertyofAddFromQuestionBank = base.
                GetWebElementPropertiesByClassName(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_AddFromQuestionBank_Image_Id_Locator);
            //Click on Add from Question Bank image
            base.ClickByJavaScriptExecutor(getPropertyofAddFromQuestionBank);
            Thread.Sleep(Convert.ToInt32(QuestionSectionUXPageResource.
               QuestionSectionUX_Page_Wait_Time_Value));
            Logger.LogMethodExit("QuestionSectionUXPage",
                "ClickAddFromQuestionBank", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Text In HTML Editor.
        /// </summary>
        private void EnterTextInHTMLEditor()
        {
            //Logger entry
            Logger.LogMethodEntry("QuestionSectionUXPage",
                "EnterTextInHTMLEditor", base.isTakeScreenShotDuringEntryExit);
            //Wait for web element
            base.WaitForElement(By.Id(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_EditDirections_Div_Id_Locator));
            //Wait for web element
            base.WaitForElement(
                By.Id(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_HTMLEditor_ViewSource_Button_Id_Locator));
            IWebElement getViewSourceButton=base.GetWebElementPropertiesById
                (QuestionSectionUXPageResource.
                QuestionSectionUX_Page_HTMLEditor_ViewSource_Button_Id_Locator);
            //Click on button
            base.ClickByJavaScriptExecutor(getViewSourceButton);
            //Wait for web element
            base.WaitForElement(By.Id(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_HTMLEditor_TextArea_Id_Locator));
            //Created  HTML text guid
            Guid htmlEditorTextGuid = Guid.NewGuid();
            //Fill text in editor
            base.FillTextBoxById(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_HTMLEditor_TextArea_Id_Locator,
                htmlEditorTextGuid.ToString());
            //Click on button
            base.ClickByJavaScriptExecutor(getViewSourceButton);
            //Logger exit
            Logger.LogMethodExit("QuestionSectionUXPage",
                "EnterTextInHTMLEditor", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Group Name.
        /// </summary>
        private void EnterGroupName()
        {
            //Logger entry
            Logger.LogMethodEntry("QuestionSectionUXPage",
                "EnterGroupName", base.isTakeScreenShotDuringEntryExit);
            //Created group name guid
            Guid groupNameGuid = Guid.NewGuid();
            //Wait for web element
            base.WaitForElement(By.Id(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_GroupName_TextBox_Id_Locator));
            //Enter group name
            base.FillTextBoxById(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_GroupName_TextBox_Id_Locator,
                groupNameGuid.ToString());
            //Logger exit
            Logger.LogMethodExit("QuestionSectionUXPage",
                "EnterGroupName", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question Group Window.
        /// </summary>
        private void SelectQuestionGroupWindow()
        {
            //Logger entry
            Logger.LogMethodEntry("QuestionSectionUXPage",
                "SelectQuestionGroupWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for window
            base.WaitUntilWindowLoads(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_Window_Title);
            //Select window
            base.SelectWindow(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_Window_Title);
            //Logger entry
            Logger.LogMethodEntry("QuestionSectionUXPage",
                "SelectQuestionGroupWindow",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Click on Save and Close Button.
        /// </summary>
        public void ClickOnSaveAndCloseButton()
        {
            //Logger entry
            Logger.LogMethodEntry("QuestionSectionUXPage",
                "ClickOnSaveAndCloseButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectQuestionGroupWindow();                
                //Wait for element
                base.WaitForElement(By.Id(QuestionSectionUXPageResource.
                    QuestionSectionUX_Page_SaveandClose_Button_Id_Locator));
                //Click on button
                IWebElement getPropertyOfSaveAndCloseButton = base.
                    GetWebElementPropertiesById(QuestionSectionUXPageResource.
                    QuestionSectionUX_Page_SaveandClose_Button_Id_Locator);
                base.ClickByJavaScriptExecutor(getPropertyOfSaveAndCloseButton);
                //Sleep time
                Thread.Sleep(Convert.ToInt32(QuestionSectionUXPageResource.
                QuestionSectionUX_Page_Wait_Time_Value));
                //Validate the displaying of Duplicate question Pegasus pop window 
                new ShowMessagePage().HandleDuplicateTestQuestionsPopupWindow();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            //Logger entry
            Logger.LogMethodEntry("QuestionSectionUXPage",
                "ClickOnSaveAndCloseButton",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
