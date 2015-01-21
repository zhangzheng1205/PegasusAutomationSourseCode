using System;
using System.ComponentModel;
using System.Globalization;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.PegasusTest;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Creation of MyTest Activity Actions.
    /// </summary>
    public class PaperTestUxPage : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PaperTestUxPage));

        /// <summary>
        /// Select To Create Question.
        /// </summary>
        /// <param name="questionTypeEnum">This is question type enum.</param>
        public void SelectCreateQuestion(
            Question.QuestionTypeEnum questionTypeEnum)
        {
            //Select Create Question
            Logger.LogMethodEntry("PaperTestUXPage", "SelectCreateQuestion",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // select MyTest window
                this.SelectMyTestWindow();
                // click on create question 
                this.ClickOnCreateQuestionAndGroupLink();
                // select Question
                this.SelectQuestionType(questionTypeEnum);
                // wait for popup load
                Thread.Sleep(Convert.ToInt32(PaperTestUXPageResource.
                    PaperTestUX_Page_CreateQuestion_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("PaperTestUXPage", "SelectCreateQuestion",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on click on create question and group link.
        /// </summary>
        private void ClickOnCreateQuestionAndGroupLink()
        {
            Logger.LogMethodEntry("PaperTestUXPage", "ClickOnCreateQuestionAndGroupLink",
               base.IsTakeScreenShotDuringEntryExit);
            IWebElement createQuestionGroupObject = base.GetWebElementPropertiesByCssSelector("img[id='Img4']");
            base.ClickByJavaScriptExecutor(createQuestionGroupObject);
            Logger.LogMethodExit("PaperTestUXPage", "ClickOnCreateQuestionAndGroupLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select MyTest Window.
        /// </summary>
        private void SelectMyTestWindow()
        {
            //Select MyTest Window.
            Logger.LogMethodEntry("PaperTestUXPage", "SelectMyTestWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilWindowLoads(PaperTestUXPageResource.
                PaperTestUX_Page_MyTest_Window_Title);
            //Select the window
            base.SelectWindow(PaperTestUXPageResource.
                PaperTestUX_Page_MyTest_Window_Title);
            //This is logger exit
            Logger.LogMethodExit("PaperTestUXPage", "SelectMyTestWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question Type.
        /// </summary>
        private void SelectQuestionType(
            Question.QuestionTypeEnum questionTypeEnum)
        {
            //Select Question Type
            Logger.LogMethodEntry("PaperTestUXPage", "SelectQuestionType",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the cmenu options list
            base.WaitForElement(By.Id(PaperTestUXPageResource.
                PaperTestUX_Page_CreateQuestion_CmenuList_Id_Locator));
            IWebElement getWebElement;
            switch (questionTypeEnum)
            {
                case Question.QuestionTypeEnum.TrueFalse:
                    //Wait for the Element
                    base.WaitForElement(By.XPath(PaperTestUXPageResource.
                        PaperTestUX_Page_CreateQuestion_Select_TrueFalse_Ques_Id_Locator));
                    //Get HTML Element Property for Cmenu Option
                    getWebElement = base.GetWebElementPropertiesByXPath(PaperTestUXPageResource.
                        PaperTestUX_Page_CreateQuestion_Select_TrueFalse_Ques_Id_Locator);
                    //Click on the TrueFalse Option
                    base.ClickByJavaScriptExecutor(getWebElement);
                    break;
                case Question.QuestionTypeEnum.CreateQuestionGroup:
                    //Wait for element 
                    base.WaitForElement(By.Id(PaperTestUXPageResource.
                        PaperTestUX_Page__QuestionGroup_Id_Locator));
                    getWebElement = GetWebElementPropertiesById(PaperTestUXPageResource.
                        PaperTestUX_Page__QuestionGroup_Id_Locator);
                    //Click on the Create Question Group Option
                    base.ClickByJavaScriptExecutor(getWebElement);
                    break;
                case Question.QuestionTypeEnum.Essay:
                    //Wait for element 
                    base.WaitForElement(By.Id(PaperTestUXPageResource.
                        PaperTestUX_Page__EssayQuestion_Id_Locator));
                    getWebElement = base.GetWebElementPropertiesById(PaperTestUXPageResource.
                        PaperTestUX_Page__EssayQuestion_Id_Locator);
                    //Click on the Eassy Question
                    base.ClickByJavaScriptExecutor(getWebElement);
                    break;
            }
            Logger.LogMethodExit("PaperTestUXPage", "SelectQuestionType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Save The MyTest Activity.
        /// </summary>
        public void SaveTheMyTestActivity()
        {
            //Save The MyTest Activity
            Logger.LogMethodEntry("PaperTestUXPage", "SaveTheMyTestActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // select MyTest window
                this.SelectMyTestWindow();
                // wait for page refresh 
                Thread.Sleep(Convert.ToInt32(
                    PaperTestUXPageResource.PaperTestUX_Page_Thred_Time_Value));
                IWebElement saveButtonObject = base.GetWebElementPropertiesByCssSelector("img[id='Img1']");
                // click save button
                base.ClickByJavaScriptExecutor(saveButtonObject);
                // save and close activity
                this.SaveAndCloseActivity();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("PaperTestUXPage", "SaveTheMyTestActivity",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save And Close Activity.
        /// </summary>
        private void SaveAndCloseActivity()
        {
            // save and close activity
            Logger.LogMethodEntry("PaperTestUXPage", "SaveAndCloseActivity",
                base.IsTakeScreenShotDuringEntryExit);
            // wait for page render 
            Thread.Sleep(Convert.ToInt32(
                PaperTestUXPageResource.PaperTestUX_Page_Thred_Time_Value));
            IWebElement getSaveCloseButtonObject = base.GetWebElementPropertiesByCssSelector("span[id='_ctl0__ctl0_phBody_PageContent_lnkSaveClose']");
            // click the save and close link
            base.ClickByJavaScriptExecutor(getSaveCloseButtonObject);
            Thread.Sleep(Convert.ToInt32(PaperTestUXPageResource.
                PaperTestUX_Page_CreateMyTest_Mesg_Time_Value));
            Logger.LogMethodEntry("PaperTestUXPage", "SaveAndCloseActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method will  handle enter random number for question to add in MyTest.
        /// </summary>
        /// <param name="randomQuestionNumber">This is number of question.</param>
        public void EnterRandomNumberToAddQuestion(
            int randomQuestionNumber)
        {
            //Entry Logger 
            Logger.LogMethodEntry("PaperTestUXPage", "EnterRandomNumberToAddQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select window
                this.SelectMyTestWindow();
                //Click on the First Level Folder
                this.ClickOnFolderInFilterTestBank(PaperTestUXPageResource.
                    PaperTestUX_Page_First_Level_Folder_Name);
                //Click on the Second Level Folder
                //this.ClickOnFolderInFilterTestBank(PaperTestUXPageResource.
               // PaperTestUX_Page_Second_Level_Folder_Name);
                //Click on the Third Level Folder
               // this.ClickOnFolderInFilterTestBank(PaperTestUXPageResource.
                //PaperTestUX_Page_Third_Level_Folder_Name);
                //Click on checkbox against question 
                this.ClickOnCheckBoxOfQuestion();
                //Enter Random Question number
                this.EnterRandomQuestionNumber(randomQuestionNumber);
                //Click on Add button to add question into Test
                this.ClickOnAddButton();
                //Wait for loading of popup window
                Thread.Sleep(Convert.ToInt32(PaperTestUXPageResource.
                    PaperTestUX_Page_Thred_Time_Value));

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            Logger.LogMethodExit("PaperTestUXPage", "EnterRandomNumberToAddQuestion",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add button to add question into Test.
        /// </summary>
        private void ClickOnAddButton()
        {
            //Loger Entry
            Logger.LogMethodEntry("PaperTestUXPage", "ClickOnAddButton",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for Add button 
            base.IsElementEnabledById(PaperTestUXPageResource.
                PaperTestUX_Page_Add_Button_Id_Locator);
            //Click Add button 
            IWebElement getHtmlPropertyOfAddButton = base.
                GetWebElementPropertiesById(PaperTestUXPageResource.
                PaperTestUX_Page_Add_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(getHtmlPropertyOfAddButton);
            //Loger Exit
            Logger.LogMethodExit("PaperTestUXPage", "ClickOnAddButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter question number into random Textbox.
        /// </summary>
        /// <param name="randomQuestionNumber">This is random question number.</param>
        private void EnterRandomQuestionNumber(
            int randomQuestionNumber)
        {
            //Loger Entry
            Logger.LogMethodEntry("PaperTestUXPage", "EnterRandomQuestionNumber",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for Number of random question to add TextBox
            base.WaitForElement(By.Id(PaperTestUXPageResource.
                PaperTestUX_Page_Random_Question_TextBox_Id_Locator));
            //Focus on text Box
            base.FocusOnElementById(PaperTestUXPageResource.
                PaperTestUX_Page_Random_Question_TextBox_Id_Locator);
            //Enter integer value in textbox
            base.FillTextBoxById(PaperTestUXPageResource.
                PaperTestUX_Page_Random_Question_TextBox_Id_Locator,
                randomQuestionNumber.ToString(CultureInfo.InvariantCulture));
            //Loger Exit
            Logger.LogMethodExit("PaperTestUXPage", "EnterRandomQuestionNumber",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click on checkbox of question to add that question into MyTest. 
        /// </summary>
        private void ClickOnCheckBoxOfQuestion()
        {
            //Loger Entry
            Logger.LogMethodEntry("PaperTestUXPage", "ClickOnCheckBoxOfQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for Check of Question
            base.WaitForElement(By.XPath(PaperTestUXPageResource.
                PaperTestUX_Page_Checkbox_Xpath_Locator));
            //Get CheckBox Element Property
            IWebElement getPropertyOfCheckBox = base.
                GetWebElementPropertiesByXPath(PaperTestUXPageResource.
                PaperTestUX_Page_Checkbox_Xpath_Locator);
            //Click on check box 
            base.ClickByJavaScriptExecutor(getPropertyOfCheckBox);
            //Loger Exit
            Logger.LogMethodExit("PaperTestUXPage", "ClickOnCheckBoxOfQuestion",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Handle Popup Window during adding duplicate question into MyTest.
        /// </summary>
        /// <param name="expectedPopupWindowName">
        /// This is expected pop up window name.</param>
        public void HandlePopupWindowOnMyTest(
            String expectedPopupWindowName)
        {
            //Logger Entry 
            Logger.LogMethodEntry("PaperTestUXPage", "HandlePopupWindowOnMyTest",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Validate popup window
                if (base.IsPopupPresent(expectedPopupWindowName,
                    Convert.ToInt32(PaperTestUXPageResource.
                    PaperTestUX_Page_Wait_Time_InSecond)))
                {
                    //Switch to popup window
                    base.WaitUntilPopUpLoads(expectedPopupWindowName);
                    //Wait for Ok button 
                    base.WaitForElement(By.Id(PaperTestUXPageResource.
                        PaperTestUX_Page_OK_Button_Id_Locator));
                    //Get property of OK button
                    IWebElement getPropertyOfOKButton = base.
                        GetWebElementPropertiesById(PaperTestUXPageResource.
                        PaperTestUX_Page_OK_Button_Id_Locator);
                    //Click on Ok button
                    base.ClickByJavaScriptExecutor(getPropertyOfOKButton);
                }
                //Switch to default page 
                base.SelectDefaultWindow();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            //Logger Exit 
            Logger.LogMethodExit("PaperTestUXPage", "HandlePopupWindowOnMyTest",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method handle the click on Folder name in FilterTestbank.
        /// </summary>
        /// <param name="folderName">This is folder name</param>
        private void ClickOnFolderInFilterTestBank(String folderName)
        {
            //Logger Entry 
            Logger.LogMethodEntry("PaperTestUXPage", "ClickOnFolderInFilterTestBank",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for element 
            base.WaitForElement(By.PartialLinkText(folderName));
            base.FillEmptyTextByPartialLinkText(folderName);
            //Click on Question Folder
            base.ClickLinkByPartialLinkText(folderName);
            Thread.Sleep(Convert.ToInt32(PaperTestUXPageResource.
                PaperTestUX_Page_CreateQuestion_Time_Value));
            // Logger Exit
            Logger.LogMethodExit("PaperTestUXPage", "ClickOnFolderInFilterTestBank",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close the My Test activity and then save 
        /// this test by clcik on save button on cancel popup window.
        /// </summary>
        public void CloseTheMyTestActivity()
        {
            //Logger Entry 
            Logger.LogMethodEntry("PaperTestUXPage", "CloseTheMyTestActivity",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select window
                this.SelectMyTestWindow();
                //Wait for element 
                base.WaitForElement(By.Id(PaperTestUXPageResource.
                    PaperTestUX_Page_Close_Button_Id_Locator));
                //Get HTML Property of close button 
                IWebElement getPropertyOfCloseButton = base.
                    GetWebElementPropertiesById(PaperTestUXPageResource.
                    PaperTestUX_Page_Close_Button_Id_Locator);
                //Click on save button 
                base.ClickByJavaScriptExecutor(getPropertyOfCloseButton);
                //Handle the Cancel Test Confirmation pop up
                this.HandleCancelTestConfirmationPopupWindow();

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            // Logger Exit
            Logger.LogMethodExit("PaperTestUXPage", "CloseTheMyTestActivity",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Handle Cancel Test Confirmation Popup Window.
        /// </summary>
        private void HandleCancelTestConfirmationPopupWindow()
        {
            // Logger Entry
            Logger.LogMethodEntry("PaperTestUXPage",
                "HandleCancelTestConfirmationPopupWindow",
            base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(Convert.ToInt32(PaperTestUXPageResource.
                PaperTestUX_Page_Wait_Time_InSecond));
            //Select the window
            base.WaitUntilWindowLoads(PaperTestUXPageResource.
                PaperTestUX_Page_Cancel_Test_Popup_Window_Name);
            base.SelectWindow(PaperTestUXPageResource.
                PaperTestUX_Page_Cancel_Test_Popup_Window_Name);
            //Validate popup exist
            if (base.IsElementPresent(By.Id(PaperTestUXPageResource.
                    PaperTestUX_Page_Cancel_Test_Popup_Save_Button_Id_Locator),
                Convert.ToInt32(PaperTestUXPageResource.
                PaperTestUX_Page_Wait_Time_InSecond)))
            {
                //Wait for save button
                base.WaitForElement(By.Id(PaperTestUXPageResource.
                    PaperTestUX_Page_Cancel_Test_Popup_Save_Button_Id_Locator));
                //Get HTML property of save button
                IWebElement getPropertyOfSaveButton = base.
                    GetWebElementPropertiesById(PaperTestUXPageResource.
                    PaperTestUX_Page_Cancel_Test_Popup_Save_Button_Id_Locator);
                //Click on save button
                base.ClickByJavaScriptExecutor(getPropertyOfSaveButton);
            }
            Logger.LogMethodExit("PaperTestUXPage",
                "HandleCancelTestConfirmationPopupWindow",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Expand Button In Filter TestBank.
        /// </summary>
        /// <param name="myQuestionFolder">This is folder name.</param>
        public void ClickOnExpandButtonInFilterTestBank(
            String myQuestionFolder)
        {
            //Click On Expand Button In Filter TestBank
            Logger.LogMethodEntry("PaperTestUXPage", "ClickOnExpandButtonInFilterTestBank",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select MyTest Window
                this.SelectMyTestWindow();
                //Click on the First Level Folder
                this.ClickOnFolderInFilterTestBank(myQuestionFolder);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PaperTestUXPage", "ClickOnExpandButtonInFilterTestBank",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select the question to Drag and drop In MyTest.
        /// </summary>
        /// <param name="questionName">This is Question Name.</param>
        public void SelectTheQuestionToDragAndDropToMyTest(string questionName)
        {
            // DragAndDrop Question In MyTest.
            Logger.LogMethodEntry("PaperTestUXPage", "SelectTheQuestionToDragAndDropToMyTest",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the question to Drag and drop In MyTest
                this.SelectMyTestWindow();
                //Get Question Count in  Filter Test Bank
                int getQuestionCount = this.GetQuestionCountInFilterTestBank(questionName);
                //Drag And Drop The Question To Manage User Test
                this.DragAndDropTheQuestionToManageUserTest(getQuestionCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PaperTestUXPage", "SelectTheQuestionToDragAndDropToMyTest",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// DragAndDrop The Question To Manage User Test
        /// </summary>
        /// <param name="getQuestionCount">This is question count</param>
        private void DragAndDropTheQuestionToManageUserTest(int getQuestionCount)
        {
            // DragAndDrop The Question To Manage User Test
            Logger.LogMethodEntry("PaperTestUXPage", "DragAndDropTheQuestionToManageUserTest",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for the drag element path
            base.WaitForElement(By.XPath(string.Format(PaperTestUXPageResource.
                PaperTestUX_Page_FilterTest_QuestionName_Xpath_Locator,
                getQuestionCount)));
            IWebElement getSourceElementLocationProperties = base.GetWebElementPropertiesByXPath(
                string.Format(PaperTestUXPageResource.
                PaperTestUX_Page_FilterTest_QuestionName_Xpath_Locator,
                getQuestionCount));
            //Wait for the drop element path
            base.WaitForElement(By.XPath(PaperTestUXPageResource.
               PaperTestUX_Page_DropQuestion_Destination_Xpath_Locator));
            IWebElement getTargetElementLocationProperties = base.GetWebElementPropertiesByXPath(
                PaperTestUXPageResource.
                    PaperTestUX_Page_DropQuestion_Destination_Xpath_Locator);
            //Click  action for drag and drop
            base.PerformDragAndDropAction(getSourceElementLocationProperties,
                getTargetElementLocationProperties);
            Thread.Sleep(Convert.ToInt32(PaperTestUXPageResource.
                PaperTestUX_Page_CreateQuestion_Time_Value));
            Logger.LogMethodExit("PaperTestUXPage", "DragAndDropTheQuestionToManageUserTest",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Get Question Count in  Filter Test Bank.
        /// </summary>
        /// <param name="questionName">This is Question Name.</param>
        /// <returns>Question count</returns>
        private int GetQuestionCountInFilterTestBank(string questionName)
        {
            //Get Question Count in  Filter Test Bank
            Logger.LogMethodEntry("PaperTestUXPage", "GetQuestionCountInFilterTestBank",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(PaperTestUXPageResource.
                PaperTestUX_Page_FilterTest_QuestionCount_Xpath_Locator));
            //Initialize VariableVariable Get total count           
            int getTotalQuestionCount = base.GetElementCountByXPath
                (PaperTestUXPageResource.PaperTestUX_Page_FilterTest_QuestionCount_Xpath_Locator);
            Thread.Sleep(Convert.ToInt32(
                    PaperTestUXPageResource.PaperTestUX_Page_Thred_Time_Value));
            for (int rowCount = 1; rowCount <= getTotalQuestionCount; rowCount++)
            {
                //Wait for the element
                base.WaitForElement(By.XPath(string.Format(PaperTestUXPageResource.
                    PaperTestUX_Page_FilterTest_QuestionName_Xpath_Locator, rowCount)));
                string test = base.GetElementTextByXPath
                    (string.Format(PaperTestUXPageResource.
                    PaperTestUX_Page_FilterTest_QuestionName_Xpath_Locator, rowCount));
                if (test.Contains(questionName))
                {
                    //Focus on the element
                    base.FocusOnElementByXPath(string.Format(PaperTestUXPageResource.
                    PaperTestUX_Page_FilterTest_QuestionName_Xpath_Locator, rowCount));
                    getTotalQuestionCount = rowCount;
                    break;
                }
            }
            Logger.LogMethodExit("PaperTestUXPage", "GetQuestionCountInFilterTestBank",
            base.IsTakeScreenShotDuringEntryExit);
            return getTotalQuestionCount;
        }

        /// <summary>
        /// GetConfirmation Message In PegasusPopup.
        /// </summary>
        /// <returns>This is confirmation message.</returns>
        public string GetConfirmationMessageInPegasusPopup()
        {
            //GetConfirmation Message In PegasusPopup
            Logger.LogMethodEntry("PaperTestUXPage", "GetConfirmationMessageInPegasusPopup",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getConfirmationMessage = string.Empty;
            try
            {
                //Select Pegasus Window
                this.SelectPegasusWindow();
                //wait for the element
                base.WaitForElement(By.Id(PaperTestUXPageResource.
                    PaperTestUX_Page_Pegasus_Window_Message_Id_Locator));
                //Get confirmation Message From Application
                getConfirmationMessage = base.GetElementTextById(PaperTestUXPageResource.
                    PaperTestUX_Page_Pegasus_Window_Message_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PaperTestUXPage", "GetConfirmationMessageInPegasusPopup",
            base.IsTakeScreenShotDuringEntryExit);
            //Return confirmation message 
            return getConfirmationMessage;
        }

        /// <summary>
        /// Select Pegasus Window.
        /// </summary>
        private void SelectPegasusWindow()
        {
            //Select Pegasus Window
            Logger.LogMethodEntry("PaperTestUXPage", "SelectPegasusWindow",
              base.IsTakeScreenShotDuringEntryExit);
            //Select the window
            base.WaitUntilPopUpLoads(PaperTestUXPageResource.
                PaperTestUX_Page_Popup_Pegasus_Window_Name);
            base.SelectWindow(PaperTestUXPageResource.
                PaperTestUX_Page_Popup_Pegasus_Window_Name);
            Logger.LogMethodExit("PaperTestUXPage", "SelectPegasusWindow",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Question Name from My Question folder in MyTest.
        /// </summary>
        /// <param name="questionName">This is name of question.</param>
        /// <returns>Question name.</returns>
        public string GetQuestionNameInMyTest(
            String questionName)
        {
            //Get Question Name In MyTest
            Logger.LogMethodEntry("PaperTestUXPage", "GetQuestionNameInMyTest",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getQuestionName = string.Empty;
            try
            {
                //Select MyTest Window
                this.SelectMyTestWindow();
                //Wait For My Question Folder UL element. 
                base.WaitForElement(By.XPath(PaperTestUXPageResource.
                    PaperTestUX_Page_MyQuestion_Folder_UL_Xpath_Locator));
                //Click on My Question Folder to expande
                this.ClickOnFolderInFilterTestBank(PaperTestUXPageResource.
                                    PaperTestUX_Page_MyQuestion_Folder_Name);
                //Get the expected question in My Question folder
                getQuestionName = this.FindQuestionInMyQuestionFolder(questionName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PaperTestUXPage", "GetQuestionNameInMyTest",
            base.IsTakeScreenShotDuringEntryExit);
            //Return question name 
            return getQuestionName;
        }

        /// <summary>
        /// Find the expected question in My Question Folder.
        /// </summary>
        /// <param name="questionName">This is name of question that user
        /// searching.</param>
        /// <returns>Return the name of question.</returns>
        private string FindQuestionInMyQuestionFolder(String questionName)
        {
            //Logger Entry
            Logger.LogMethodEntry("PaperTestUXPage", "FindQuestionInMyQuestionFolder",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getQuestionName = string.Empty;
            //Wait for question list LI of My Question folder
            base.WaitForElement(By.XPath(PaperTestUXPageResource.
                PaperTestUX_Page_MyQuestion_Folder_Question_LI_Xpath_Locator));
            //Get Question Count in My Question folder
            int getTotalQuestionRowCount = base.GetElementCountByXPath
                (PaperTestUXPageResource.
                PaperTestUX_Page_MyQuestion_Folder_Question_LI_Xpath_Locator);
            //Get the question name in my question folder
            getQuestionName = this.GetTheQuestionName(questionName, getQuestionName,
                getTotalQuestionRowCount);
            //Logger Exit
            Logger.LogMethodExit("PaperTestUXPage", "FindQuestionInMyQuestionFolder",
            base.IsTakeScreenShotDuringEntryExit);
            //Return question name 
            return getQuestionName;
        }

        /// <summary>
        /// Get the question name in my question folder.
        /// </summary>
        /// <param name="questionName">This is expectd queation name.</param>
        /// <param name="getQuestionName">This is variable for question name.</param>
        /// <param name="getTotalQuestionRowCount">This is count of question row.</param>
        /// <returns>return the expected question name.</returns>
        private string GetTheQuestionName(String questionName,
            string getQuestionName, int getTotalQuestionRowCount)
        {
            //Logger Entry
            Logger.LogMethodEntry("PaperTestUXPage", "GetTheQuestionName",
            base.IsTakeScreenShotDuringEntryExit);
            //Checking the availability of question In My Question folder Grid
            for (int setQuestionRowCount = 1; setQuestionRowCount
                <= getTotalQuestionRowCount;
                setQuestionRowCount++)
            {
                //Wait for Question Xpath
                base.WaitForElement(By.XPath(string.Format(PaperTestUXPageResource.
                 PaperTestUX_Page_MyQuestion_Folder_Question_LI_Variable_Xpath_Locator
                    , setQuestionRowCount)));
                //Get Question Name
                getQuestionName = base.GetInnerTextAttributeValueByXPath
                   (string.Format(PaperTestUXPageResource.
                 PaperTestUX_Page_MyQuestion_Folder_Question_LI_Variable_Xpath_Locator,
                 setQuestionRowCount)).
                   Replace(Environment.NewLine, String.Empty);
                //Validate expected question name 
                if (getQuestionName.Contains(questionName))
                {
                    //Assign the expected question name in getQuestionName
                    getQuestionName = questionName;
                    break;
                }
            }
            //Logger Exit
            Logger.LogMethodExit("PaperTestUXPage", "GetTheQuestionName",
            base.IsTakeScreenShotDuringEntryExit);
            return getQuestionName;
        }

        /// <summary>
        /// get The Question In Manage Your Test.
        /// </summary>
        /// <param name="questionName">This is Question Name.</param>
        /// <returns>Question name.</returns>
        public string getTheQuestionInManageYourTest(string questionName)
        {
            // get The Question In Manage Your Test
            Logger.LogMethodEntry("PaperTestUXPage", "getTheQuestionInManageYourTest",
           base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getQuestionName = string.Empty;
            try
            {
                //Select the window
                this.SelectMyTestWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(PaperTestUXPageResource.
                    PaperTestUX_Page_ManageYourTest_QuestionCount_Xpath_Locator));
                //Get Total Count
                int getTotalQuestionCount = base.GetElementCountByXPath(PaperTestUXPageResource.
                   PaperTestUX_Page_ManageYourTest_QuestionCount_Xpath_Locator);
                for (int setQuestionRowCount = 1; setQuestionRowCount <= getTotalQuestionCount;
                     setQuestionRowCount++)
                {
                    //Wait for the element
                    base.WaitForElement(By.XPath(string.Format(PaperTestUXPageResource.
                       PaperTestUX_Page_ManageYourTest_QuestionName_Xpath_Locator, setQuestionRowCount)));
                    //Get the Question Name
                    string getQuestionTitle = base.GetElementTextByXPath
                        (string.Format(PaperTestUXPageResource.
                       PaperTestUX_Page_ManageYourTest_QuestionName_Xpath_Locator, setQuestionRowCount));
                    getQuestionName = getQuestionTitle.Trim();
                    if (getQuestionName.Contains(questionName))
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PaperTestUXPage", "getTheQuestionInManageYourTest",
            base.IsTakeScreenShotDuringEntryExit);
            return getQuestionName;
        }

        /// <summary>
        /// Handle the action of click on ViewAllTest button inside test filder.
        /// </summary>
        public void ClickOnViewAllTestButtonInsideTest()
        {
            //Logger Entry
            Logger.LogMethodEntry("PaperTestUXPage", "ClickOnViewAllTestButtonInsideTest",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the View all Tests element
                base.WaitForElement(By.Id(PaperTestUXPageResource.
                    PaperTestUX_Page_Viewalltests_Button_Id_Locator));
                IWebElement getPropertyOfViewAllTests = base.
                    GetWebElementPropertiesById(PaperTestUXPageResource.
                    PaperTestUX_Page_Viewalltests_Button_Id_Locator);
                //Click on View All Tests button
                base.ClickByJavaScriptExecutor(getPropertyOfViewAllTests);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("PaperTestUXPage", "ClickOnViewAllTestButtonInsideTest",
                 base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate that button displaying on MyTest action row.
        /// </summary>
        /// <param name="buttonName">name of button.</param>
        /// <returns> Return the true if value display.
        /// otherwise return false.</returns>
        public bool IsButtonDisplayingInsideMyTestActivity(string buttonName)
        {
            //Logger Entry
            Logger.LogMethodEntry("PaperTestUXPage", "IsButtonDisplayingInsideMyTestActivity",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialize Varaiable
            bool isButtonDisplaying = false;
            try
            {
                //Select MyTest Window
                this.SelectMyTestWindow();
                //Wait for Div that contain all button
                base.WaitForElement(By.Id(PaperTestUXPageResource.
                    PaperTestUX_Page_MYTest_Div_ID_Locator));
                //Get the text of Div, that contain all buttons
                string getTextofElement = base.
                    GetElementTextById(PaperTestUXPageResource.
                    PaperTestUX_Page_MYTest_Div_ID_Locator).
                    Replace(Environment.NewLine, string.Empty);
                //Match the expected Button text
                if (getTextofElement.Contains(buttonName))
                {
                    //Return true if button displaying 
                    return isButtonDisplaying = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("PaperTestUXPage", "IsButtonDisplayingInsideMyTestActivity",
                 base.IsTakeScreenShotDuringEntryExit);
            return isButtonDisplaying;
        }

        /// <summary>
        /// Click The Download Option In ManageYourTest.
        /// </summary>
        public void ClickTheDownloadOptionInManageYourTest()
        {
            //Click The Download Option In ManageYourTest
            Logger.LogMethodEntry("PaperTestUXPage", "ClickTheDownloadOptionInManageYourTest",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select MyTest Window
                this.SelectMyTestWindow();
                //Wait for Div that contain all button
                base.WaitForElement(By.Id(PaperTestUXPageResource.
                    PaperTestUX_Page_MyTest_Download_Id_Locator));
                IWebElement getDownloadButton = base.GetWebElementPropertiesById
                    (PaperTestUXPageResource.
                    PaperTestUX_Page_MyTest_Download_Id_Locator);
                //Click the 'Download' button
                base.ClickByJavaScriptExecutor(getDownloadButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PaperTestUXPage", "ClickTheDownloadOptionInManageYourTest",
                 base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
