using System;
using System.Globalization;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.PegasusTest;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handle the All action on PrintTool page.
    /// </summary>
    public class PrintToolPage : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
             Logger.GetInstance(typeof(PrintToolPage));

        /// <summary>
        /// Validate the displaying of Print element on My Test download page.
        /// </summary>
        public bool IsPrintOptionsPresentOnPrintPage()
        {
            //logger Entry
            Logger.LogMethodEntry("PrintToolPage", "IsPrintOptionsPresentOnPrintPage",
                base.isTakeScreenShotDuringEntryExit);
            bool isAllPrintDeatilsPresent = true;
            try
            {
                //Switch To Default Page Content
                base.SwitchToDefaultPageContent();
                //Select IFrame
                this.SelectDownloadLightBoxIFrame();
                //Validate the status of 'Create multiple versions' checkbox
                bool isCreateMultipleVersionsChecked =
                   this.IsCreateMultipleVersionsCheckBoxChecked();
                // Validate the status of 'Include Area For Student Response' Checkbox.
                bool isIncludeAreaForStudentResponseChecked =
                   this.IsIncludeAreaForStudentResponseCheckBoxChecked();
                // Validate the status of 'Include Answer Key In' checkbox.
                bool isIncludeAnswerKeyInChecked =
                    this.IsIncludeAnswerKeyInCheckBoxChecked();
                //Get the final status of all default Print options on Print page
                isAllPrintDeatilsPresent = isCreateMultipleVersionsChecked ||
                    isIncludeAreaForStudentResponseChecked || isIncludeAnswerKeyInChecked;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //logger Exit
            Logger.LogMethodExit("PrintToolPage",
                "IsPrintOptionsPresentOnPrintPage",
                base.isTakeScreenShotDuringEntryExit);
            return isAllPrintDeatilsPresent;
        }

        /// <summary>
        /// Select Download LightBox IFrame. 
        /// </summary>
        private void SelectDownloadLightBoxIFrame()
        {
            //logger Entry
            Logger.LogMethodEntry("PrintToolPage",
                "SelectDownloadLightBoxIFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Iframe 
            base.WaitForElement(By.Id(PrintToolPageResource.
                PrintToolPage_Iframe_Id_Locator));
            //switch to Iframe
            base.SwitchToIFrameById(PrintToolPageResource.
                PrintToolPage_Iframe_Id_Locator);
            //logger Exit
            Logger.LogMethodExit("PrintToolPage",
                "SelectDownloadLightBoxIFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the status of 'Include Answer Key In' checkbox.
        /// </summary>
        /// <returns>status of checkbox.</returns>
        private bool IsIncludeAnswerKeyInCheckBoxChecked()
        {
            //logger Entry
            Logger.LogMethodEntry("PrintToolPage",
                "IsIncludeAnswerKeyInCheckBoxChecked",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the variable
            bool isIncludeAnswerKeyInChecked = true;
            //Wait for 'Include answer key in' checkbox
            base.WaitForElement(By.Id(PrintToolPageResource.
                PrintToolPage_IncludeAnswerKeyInCheckBox_Id));
            //Get the status of 'Include answer key in' checkbox
            isIncludeAnswerKeyInChecked = base.IsElementSelectedById(
                PrintToolPageResource.
                PrintToolPage_IncludeAnswerKeyInCheckBox_Id);
            //logger Exit
            Logger.LogMethodExit("PrintToolPage",
                "IsIncludeAnswerKeyInCheckBoxChecked",
                base.isTakeScreenShotDuringEntryExit);
            return isIncludeAnswerKeyInChecked;
        }

        /// <summary>
        /// Validate the status of 'Include Area For Student Response' Checkbox.
        /// </summary>
        /// <returns>status of checkbox.</returns>
        private bool IsIncludeAreaForStudentResponseCheckBoxChecked()
        {
            //logger Entry
            Logger.LogMethodEntry("PrintToolPage",
                "IsIncludeAreaForStudentResponseCheckBoxChecked",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the variable
            bool isIncludeAreaForStudentResponseChecked = true;
            //Wait for Include area for student response checkbox
            base.WaitForElement(By.Id(PrintToolPageResource.
                PrintToolPage_IncludeAreaForStudentResponseCheckBox_Id));
            //Validate the status of 'Include area for student response checkbox' 
            isIncludeAreaForStudentResponseChecked =
                base.IsElementSelectedById(PrintToolPageResource.
                PrintToolPage_IncludeAreaForStudentResponseCheckBox_Id);
            //logger Exit
            Logger.LogMethodExit("PrintToolPage",
                "IsIncludeAreaForStudentResponseCheckBoxChecked",
                base.isTakeScreenShotDuringEntryExit);
            return isIncludeAreaForStudentResponseChecked;
        }

        /// <summary>
        /// Validate the status of 'Create multiple versions' checkbox.
        /// </summary>
        /// <returns>status of checkbox. </returns>
        private bool IsCreateMultipleVersionsCheckBoxChecked()
        {
            //logger Entry
            Logger.LogMethodEntry("PrintToolPage",
                "IsCreateMultipleVersionsCheckBoxChecked",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the variable
            bool isCreateMultipleVersionsChecked = true;
            //Wait for 'Create multiple versions' checkbox
            base.WaitForElement(By.Id(PrintToolPageResource.
                PrintToolPage_CreateMmultipleVersions_Checkbox_Id));
            isCreateMultipleVersionsChecked = base.
                IsElementSelectedById(PrintToolPageResource.
                PrintToolPage_CreateMmultipleVersions_Checkbox_Id);
            //logger Exit
            Logger.LogMethodExit("PrintToolPage",
                "IsCreateMultipleVersionsCheckBoxChecked",
                base.isTakeScreenShotDuringEntryExit);
            return isCreateMultipleVersionsChecked;
        }

        /// <summary>
        /// Select the checkbox of Print option on MyTest Download page.
        /// </summary>
        /// <param name="printOptionName">This is name of Print option.</param>
        public void SelectCheckboxOfPrintOption(String printOptionName)
        {
            //logger Entry
            Logger.LogMethodEntry("PrintToolPage", "SelectCheckboxOfPrintOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for table element 
                base.WaitForElement(By.XPath(PrintToolPageResource.
                    PrintToolPage_Table_Row_Xpath_Locator));
                //Select print option check box
                this.SelectCheckBoxOfOption(printOptionName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //logger Exit
            Logger.LogMethodExit("PrintToolPage", "SelectCheckboxOfPrintOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select print option check box.
        /// </summary>
        /// <param name="printOptionName">This is name of checkbox.</param>
        private void SelectCheckBoxOfOption(String printOptionName)
        {
            //logger Entry
            Logger.LogMethodEntry("PrintToolPage", "SelectCheckBoxOfOption",
                base.isTakeScreenShotDuringEntryExit);
            //Get Total rows count of table
            int getTotalRowCount = base.GetElementCountByXPath(
                PrintToolPageResource.PrintToolPage_Table_Row_Xpath_Locator);
            //Match the expected Print option name 
            for (int setRowCount = 1; setRowCount <= getTotalRowCount;
                setRowCount++)
            {
                //Get The Element Text of Row 
                String getTextOfRowElement = base.GetElementTextByXPath(
                    string.Format(PrintToolPageResource.
                    PrintToolPage_Table_Row_Xpath_Pointer_Locator, setRowCount));
                if (getTextOfRowElement.Contains(printOptionName))
                {
                    //Get the property of Print option checkbox
                    IWebElement getPropertyOfPrintOptionCheckBox = base.
                        GetWebElementPropertiesByXPath(
                        string.Format(PrintToolPageResource.
                        PrintToolPage_CheckBox_Xpath_Pointer_Locator, setRowCount));
                    //Click on check box
                    base.ClickByJavaScriptExecutor(getPropertyOfPrintOptionCheckBox);
                    break;
                }
            }
            //logger Exit
            Logger.LogMethodExit("PrintToolPage", "SelectCheckBoxOfOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Get The Text of Selected dropdown option.
        /// </summary>
        ///<returns>Return the text of selected dropdown option.</returns>
        public String GetTextOfSelectedDropDownOption()
        {
            //logger Entry
            Logger.LogMethodEntry("PrintToolPage", "GetTextOfSelectedDropDownOption",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the variable
            String getTextOfDropdownOption = string.Empty;
            try
            {
                //Wait for selected dropdown option
                base.WaitForElement(By.XPath(PrintToolPageResource.
                    PrintToolPage_DropDown_SelectedOption_Xpath_Locator));
                //Get the text of selected dropdown option
                getTextOfDropdownOption = base.GetElementTextByXPath(
                    PrintToolPageResource.
                    PrintToolPage_DropDown_SelectedOption_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //logger Exit
            Logger.LogMethodExit("PrintToolPage", "GetTextOfSelectedDropDownOption",
                base.isTakeScreenShotDuringEntryExit);
            return getTextOfDropdownOption;
        }

        /// <summary>
        /// Validate the status of default select radio button option
        /// of Include area for student response' section.
        /// </summary>
        /// <param name="nameOfRadioButtonOption">This is name of radio button option.</param>
        /// <returns>Return the status of radio button.</returns>
        public bool IsRadioButtonChecked(string nameOfRadioButtonOption)
        {
            //Logger Entry
            Logger.LogMethodEntry("PrintToolPage", "IsRadioButtonChecked",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize bool varialbe 
            bool isRadioButtonChecked = false;
            try
            {
                //Wait for row of 'Include area for student response' section
                base.WaitForElement(By.XPath(PrintToolPageResource.
                    PrintToolPage_IncludeASResponse_Row_Xpath_Locator));
                //Get the total row count of 'Include area for student response' section
                int getTotalRowCount = base.GetElementCountByXPath(PrintToolPageResource.
                     PrintToolPage_IncludeASResponse_Row_Xpath_Locator);
                //Get the status of expected radio button option.
                isRadioButtonChecked = this.GetStatusOfRadioButton(nameOfRadioButtonOption,
                    isRadioButtonChecked, getTotalRowCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("PrintToolPage", "IsRadioButtonChecked",
                base.isTakeScreenShotDuringEntryExit);
            //Return the radio button status
            return isRadioButtonChecked;
        }

        /// <summary>
        /// Get the status of radio button option in 
        /// 'Include area for student response' section
        /// </summary>
        /// <param name="nameOfRadioButtonOption">This is name of radio button option.</param>
        /// <param name="radioButtonCheckedStatus">This is status of radio button.</param>
        /// <param name="countOfTotalRow">This is total number of row.</param>
        /// <returns>status of radio button.</returns>
        private bool GetStatusOfRadioButton(string nameOfRadioButtonOption,
            bool radioButtonCheckedStatus, int countOfTotalRow)
        {
            //Logger Entry
            Logger.LogMethodEntry("PrintToolPage", "GetStatusOfRadioButton",
                base.isTakeScreenShotDuringEntryExit);
            //Check the expected radio buton option
            for (int setRowCounter = 1; setRowCounter <= countOfTotalRow;
                setRowCounter++)
            {
                //Get the Text of row of 'Include area for student response' section
                String getTextOfRow = base.GetElementTextByXPath(
                 String.Format(PrintToolPageResource.
                 PrintToolPage_IncludeASResponse_Row_Pointer_Xpath_Locator,
                 setRowCounter));
                //Match the expected radio button name 
                if (getTextOfRow.Contains(nameOfRadioButtonOption))
                {
                    //Get the status of radio button
                    radioButtonCheckedStatus = base.IsElementSelected(By.
                       XPath(String.Format(PrintToolPageResource.
                       PrintToolPage_IncludeASResponse_Row_RadioButton_Xpath_Locator,
                       setRowCounter)));
                    break;
                }
            }
            //Logger Exit
            Logger.LogMethodExit("PrintToolPage", "GetStatusOfRadioButton",
                base.isTakeScreenShotDuringEntryExit);
            return radioButtonCheckedStatus;
        }

        /// <summary>
        /// Validate the status of radion button of 'Include answer key in' section.
        /// </summary>
        /// <param name="nameOfRadioButtonOption">This is name of radion button option name.</param>
        /// <returns>status of radio button.</returns>
        public bool IsFileRadioButtonChecked(string nameOfRadioButtonOption)
        {
            //Logger Entry
            Logger.LogMethodEntry("PrintToolPage", "IsFileRadioButtonChecked",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize variable
            bool isRadioButtonChecked = false;
            try
            {
                //Wait for element 
                base.WaitForElement(By.XPath(PrintToolPageResource.
                    PrintToolPage_IncludeAnswerKeyIn_Span_Xpath_Locator));
                //Get Total Span count of 'Include answer key in' section
                int getTotalCountOfSpan = base.
                    GetElementCountByXPath(PrintToolPageResource.
                    PrintToolPage_IncludeAnswerKeyIn_Span_Xpath_Locator);
                //Check the expected radio buton option
                isRadioButtonChecked = GetStatusOfRadioButtonOfIncludeAnswerKey(
                    nameOfRadioButtonOption, isRadioButtonChecked, getTotalCountOfSpan);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("PrintToolPage", "IsFileRadioButtonChecked",
                base.isTakeScreenShotDuringEntryExit);
            return isRadioButtonChecked;
        }

        /// <summary>
        /// Get the status of expected radion button of 
        /// 'Include answer key in' section.
        /// </summary>
        /// <param name="nameOfRadioButtonOption">Name of radio button.</param>
        /// <param name="radioButtonCheckedSatus">Status of radio button.</param>
        /// <param name="countOfTotalSpan">Count of span.</param>
        /// <returns>Status of radio button.</returns>
        private bool GetStatusOfRadioButtonOfIncludeAnswerKey(string
            nameOfRadioButtonOption, bool radioButtonCheckedSatus, int countOfTotalSpan)
        {
            //Logger Entry
            Logger.LogMethodEntry("PrintToolPage", "GetStatusOfRadioButtonOfIncludeAnswerKey",
                base.isTakeScreenShotDuringEntryExit);
            //Check the expected radio buton option
            for (int setCountOfSpan = 1; setCountOfSpan <= countOfTotalSpan;
                setCountOfSpan++)
            {
                //Get the text of option in 'Include answer key in' section
                String getTextOfOption = base.GetElementTextByXPath(
                    string.Format(PrintToolPageResource.
                   PrintToolPage_IncludeAnswerKeyIn_Span_Counter_Xpath_Locator,
                   setCountOfSpan));
                //Match the expected radio button option name 
                if (getTextOfOption.Contains(nameOfRadioButtonOption))
                {
                    //Get the status of readio button
                    radioButtonCheckedSatus = base.IsElementSelected(By.XPath(
                        string.Format(PrintToolPageResource.
                    PrintToolPage_IncludeAnswerKeyIn_RadioButton_Counter_Xpath_Locator,
                    setCountOfSpan)));
                    break;
                }
            }
            //Logger Exit
            Logger.LogMethodExit("PrintToolPage", "GetStatusOfRadioButtonOfIncludeAnswerKey",
                base.isTakeScreenShotDuringEntryExit);
            return radioButtonCheckedSatus;
        }

        /// <summary>
        /// Click on cancel button on My test download popup.
        /// </summary>
        public void ClickOnCancelButton()
        {
            //Logger Entry
            Logger.LogMethodEntry("PrintToolPage", "ClickOnCancelButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Switch To Default Page Content
                base.SwitchToDefaultPageContent();
                //Select LightBox
                this.SelectDownloadLightBoxIFrame();
                //Wait for element 
                base.WaitForElement(By.Id(PrintToolPageResource.
                    PrintToolPage_Cancel_Button_ID_Locator));
                //Get property of Button
                IWebElement getPropertyOfButton = base.
                    GetWebElementPropertiesById(PrintToolPageResource.
                    PrintToolPage_Cancel_Button_ID_Locator);
                //Click on button.
                base.ClickByJavaScriptExecutor(getPropertyOfButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("PrintToolPage", "ClickOnCancelButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Multiple Version of MyTest.
        /// </summary>
        /// <param name="versionNumber">This is MyTest Version Number.</param>
        public void CreateMultipleVersionsTest(int versionNumber)
        {
            //Logger Entry
            Logger.LogMethodEntry("PrintToolPage", "CreateMultipleVersionsTest",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(Convert.ToInt32(PrintToolPageResource.
                    PrintToolPage_MyTest_CustomWait));
                //Switch To Default Page Content
                base.SwitchToDefaultPageContent();
                //Select LightBox
                this.SelectDownloadLightBoxIFrame();
                //Wait for 'Create multiple versions' checkbox
                base.WaitForElement(By.Id(PrintToolPageResource.
                    PrintToolPage_CreateMmultipleVersions_Checkbox_Id));
                //Get Checkbox Element Property
                IWebElement getCheckBoxProperty = base.
                    GetWebElementPropertiesById(PrintToolPageResource.
                        PrintToolPage_CreateMmultipleVersions_Checkbox_Id);
                //Select Checkbox
                base.ClickByJavaScriptExecutor(getCheckBoxProperty);
                //Wait for Enter Version Number Element
                base.WaitForElement(By.Id(PrintToolPageResource.
                    PrintToolPage_CreateMmultipleVersions_Textbox_Id_Locator));
                //Clear TextBox Value
                base.ClearTextByID(PrintToolPageResource.
                    PrintToolPage_CreateMmultipleVersions_Textbox_Id_Locator);
                //Enter Version Number
                base.FillTextBoxByID(PrintToolPageResource.
                    PrintToolPage_CreateMmultipleVersions_Textbox_Id_Locator,
                    versionNumber.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("PrintToolPage", "CreateMultipleVersionsTest",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Download Button.
        /// </summary>
        public void ClickOnDownloadButton()
        {
            //Logger Entry
            Logger.LogMethodEntry("PrintToolPage", "ClickOnDownloadButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.Id(PrintToolPageResource.
                    PrintToolPage_Download_Button_Id_Locator));
                //Get Button Property
                IWebElement getDownloadButtonElementProperty = base.
                    GetWebElementPropertiesById(PrintToolPageResource.
                        PrintToolPage_Download_Button_Id_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getDownloadButtonElementProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("PrintToolPage", "ClickOnDownloadButton",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}

