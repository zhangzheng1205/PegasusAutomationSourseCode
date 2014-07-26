using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Linq;
using System.Text;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Configuration;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Grading Preferences Page Actions
    /// </summary>
    public class GradingPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(GradingPreferencesPage));
        public bool IsCheckedBeforeDL, IsLockedBeforeDL = false;

        /// <summary>
        /// Click on Grading Option
        /// </summary>
        public void ClickOnGradingOption()
        {
            //Click on Grading Option
            logger.LogMethodEntry("GradingPreferencesPage", "ClickOnGradingOption",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Grade Sub Tab Frame
                this.SelectGradeSubTabFrame();
                //check for the presence of required Sub tab id                
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GradingSubtab));
                //click on grading link
                IWebElement getSubTabtoGrading = base.GetWebElementPropertiesById(
                    GradingPreferencesPageResource.GradingPrefernces_Page_GradingSubtab);
                //click on the IwebElement selected
                base.ClickByJavaScriptExecutor(getSubTabtoGrading);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "ClickOnGradingOption",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the email preference text 
        /// </summary>
        /// <returns>Mail text</returns>
        public String GetIncludeMailText()
        {
            //Get the email preference text 
            logger.LogMethodEntry("GradingPreferencesPage", "GetIncludeMailText",
            base.isTakeScreenShotDuringEntryExit);
            //Variable Initialization
            string getMailText = string.Empty;
            try
            {
                //Select Grade Sub Tab Frame
                this.SelectGradeSubTabFrame(); 
                base.WaitForElement(By.XPath(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailText_Xpath_Locator));
                //Fetching the text attribute
                getMailText = base.GetElementTextByXPath(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailText_Xpath_Locator).Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "GetIncludeMailText",
            base.isTakeScreenShotDuringEntryExit);
            return getMailText;
        }

        /// <summary>
        /// To get the email preference check box status
        /// </summary>
        /// <returns>boolean check box status</returns>
        public Boolean IsVerifyTheIncludeMailCheckBoxStatus()
        {
            //To get the email preference check box status
            logger.LogMethodEntry("GradingPreferencesPage", "IsVerifyTheIncludeMailCheckBoxStatus",
            base.isTakeScreenShotDuringEntryExit);
            //Variable Initialization
            bool IsChecked = false;
            try
            {
                //Select Grade Sub Tab Frame
                this.SelectGradeSubTabFrame();               
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Id_Locator));
                //Fetch the check box selection property
                IsChecked = base.GetWebElementPropertiesById(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Id_Locator).Selected;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "IsVerifyTheIncludeMailCheckBoxStatus",
            base.isTakeScreenShotDuringEntryExit);
            return IsChecked;
        }

        /// <summary>
        ///Select Grade Sub Tab Frame        
        /// </summary>
        public void SelectGradeSubTabFrame()
        {
            //Select Grade Sub Tab Frame  
            logger.LogMethodEntry("GradingPreferencesPage", "SelectGradeSubTabFrame",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(GradingPreferencesPageResource.
                    GradingPrefernces_Page_Text_Preferences);
                //Selecting the preferences window
                base.SelectWindow(GradingPreferencesPageResource.
                    GradingPrefernces_Page_Text_Preferences);
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_Iframe_Preferences));
                //Switch to required iframe
                base.SwitchToIFrame(GradingPreferencesPageResource.
                    GradingPrefernces_Page_Iframe_Preferences);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "SelectGradeSubTabFrame",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  To click on the mail check box and save the preferences
        /// </summary>
        public void ClickTheMailCheckBoxAndSavePreference()
        {
            //To click on the mail check box and save the preferences
            logger.LogMethodEntry("GradingPreferencesPage", "ClickTheMailCheckBoxAndSavePreference",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Grade Sub Tab Frame
                this.SelectGradeSubTabFrame();                           
                //Click on check box
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Id_Locator));
                IWebElement chkIncludeMailCheckBox = base.GetWebElementPropertiesById(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Id_Locator);
                //Click on the IwebElement selected
                base.ClickByJavaScriptExecutor(chkIncludeMailCheckBox);
                //Click On Save Preferences Button
                this.ClickOnSavePreferencesButton();
                //Wait till the window loads and shows saved successfully message
                base.WaitUntilWindowLoads(GradingPreferencesPageResource.
                    GradingPrefernces_Page_Text_Preferences);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "ClickTheMailCheckBoxAndSavePreference",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save Preferences Button.
        /// </summary>
        private void ClickOnSavePreferencesButton()
        {
            //Click On Save Preferences Button
            logger.LogMethodEntry("GradingPreferencesPage", "ClickOnSavePreferencesButton",
            base.isTakeScreenShotDuringEntryExit);
            //Click on save preference button
            base.WaitForElement(By.Id(GradingPreferencesPageResource.
                GradingPrefernces_Page_SavePreferences_Id_Locator));
            IWebElement savePrefHeader = base.GetWebElementPropertiesById(GradingPreferencesPageResource.
                GradingPrefernces_Page_SavePreferences_Id_Locator);
            //Click on the IwebElement selected
            base.ClickByJavaScriptExecutor(savePrefHeader);
            logger.LogMethodExit("GradingPreferencesPage", "ClickOnSavePreferencesButton",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To click on download icon in order to download the preferences 
        /// </summary>
        public void ClickOnDownloadIcon()
        {
            //To click on download icon in order to download the preferences
            logger.LogMethodEntry("GradingPreferencesPage", "ClickOnDownloadIcon",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Grade Sub Tab Frame
                this.SelectGradeSubTabFrame();
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_DownloadPreferenceIcon_Id_Locator));
                //Get web element property
                IWebElement getclickOnDownloadIcon = base.GetWebElementPropertiesById
                    (GradingPreferencesPageResource.
                    GradingPrefernces_Page_DownloadPreferenceIcon_Id_Locator);
                //Click on the IwebElement selected
                base.ClickByJavaScriptExecutor(getclickOnDownloadIcon);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "ClickOnDownloadIcon",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To select Current Page option for preference download
        /// </summary>
        public void SelectCurrentPageOption()
        {
            //To select Current Page option for preference download
            logger.LogMethodEntry("GradingPreferencesPage", "SelectCurrentPageOption",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Grade Sub Tab Frame
                this.SelectGradeSubTabFrame();
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Download_Temp_Locator));
                //Select the drop down value
                base.SelectDropDownValueThroughTextById(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Download_Temp_Locator,
                    GradingPreferencesPageResource.GradingPrefernces_Page_Current_Page);
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_SavePreferences_Id_Locator));
                //Click on save preferences button
                base.ClickButtonById(GradingPreferencesPageResource.
                    GradingPrefernces_Page_SavePreferences_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "SelectCurrentPageOption",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify if Current Page option is selected for preference download
        /// </summary>
        /// <returns>Boolean Current page download option selection</returns>
        public Boolean IsCurrentPageSelected()
        {
            //To verify if Current Page option is selected for preference download
            logger.LogMethodEntry("GradingPreferencesPage", "IsCurrentPageSelected",
            base.isTakeScreenShotDuringEntryExit);
            //Variable Initialization
            bool isValueisCurrentPageOptionSelected = false;
            try
            {
                //Select Grade Sub Tab Frame
                this.SelectGradeSubTabFrame();
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Download_Temp_Locator));
                //Check for the presence of the property "selected" for the option[1] by XPath
                isValueisCurrentPageOptionSelected = base.IsElementPresent
                    (By.XPath(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Download_CP_Locator),
                    Convert.ToInt32(GradingPreferencesPageResource.
                    GradingPrefernces_Page_CustomTimetoWait));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "IsCurrentPageSelected",
            base.isTakeScreenShotDuringEntryExit);
            return isValueisCurrentPageOptionSelected;
        }

        /// <summary>
        /// To select All Pages option for preference download
        /// </summary>
        public void SelectAllPages()
        {
            logger.LogMethodEntry("GradingPreferencesPage", "SelectAllPages",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Grade Sub Tab Frame
                this.SelectGradeSubTabFrame();
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Download_Temp_Locator));
                //select the drop down value
                base.SelectDropDownValueThroughTextById(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Download_Temp_Locator,
                    GradingPreferencesPageResource.GradingPrefernces_Page_All_Pages);
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_SavePreferences_Id_Locator));
                //click on save preferences button
                base.ClickButtonById(GradingPreferencesPageResource.
                    GradingPrefernces_Page_SavePreferences_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "SelectAllPages",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify if All Pages option is selected for preference download
        /// </summary>
        /// <returns>Boolean All pages download option selection</returns>
        public Boolean IsAllPagesSelected()
        {
            logger.LogMethodEntry("GradingPreferencesPage", "IsAllPagesSelected",
            base.isTakeScreenShotDuringEntryExit);
            bool isAllPagesOptionSelected = false;
            try
            {
                //Select Grade Sub Tab Frame
                this.SelectGradeSubTabFrame();
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Download_Temp_Locator));
                //check for the presence of the property "selected" for the option[2] by XPath
                isAllPagesOptionSelected = base.IsElementPresent(By.XPath
                    (GradingPreferencesPageResource.GradingPrefernces_Page_GetIncludeMailCheckBox_Download_AP_Locator),
                    Convert.ToInt32(GradingPreferencesPageResource.GradingPrefernces_Page_CustomTimetoWait));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "IsAllPagesSelected",
            base.isTakeScreenShotDuringEntryExit);
            return isAllPagesOptionSelected;
        }

        /// <summary>
        /// To download the preferences and save to an excel file
        /// </summary>
        public void SaveTheDownloadedPreferences()
        {

            logger.LogMethodEntry("GradingPreferencesPage", "SaveTheDownloadedPreferences",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get Excelsheet File Path 
                Thread.Sleep(Convert.ToInt32(GradingPreferencesPageResource.
                    GradingPrefernces_Page_SleepTime_Value));
                string getExeFilePath = (AutomationConfigurationManager.TestDataPath  +
                   GradingPreferencesPageResource.GradingPrefernces_Page_AutoIT_ExeFilepath_Locator).
                   Replace("file:\\", "");
                //Path of the Excel file need to saved
                string getExcelFilePathSaved = (AutomationConfigurationManager.TestDataPath +
                    GradingPreferencesPageResource.GradingPrefernces_Page_AutoIT_ExeFilepath_Locator).
                    Replace("file:\\", "");
                string[] PathName = getExcelFilePathSaved.Split(Convert.ToChar
                    (GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_Data_colon));
                //Array of string
                string getExcelFileDriveSaved = PathName[0];
                getExcelFileDriveSaved = getExcelFileDriveSaved + GradingPreferencesPageResource.
                    GradingPrefernces_Page_CP_Preferences_DownloadedFilepath_Locator;
                //Run AutoIT.exe file               
                Process.Start(getExeFilePath, getExcelFileDriveSaved);
                Thread.Sleep(Convert.ToInt32(GradingPreferencesPageResource.
                    GradingPrefernces_Page_Sleep_Value));
                logger.LogMessage("GradingPreferencesPage", "SaveTheCurrentPageDownloadedPreferences",
                    "Launched AutoIT for Saving Current Page Downloaded Preferences", true);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "SaveTheDownloadedPreferences",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify if the downloaded email preference status is matching the UI value when 
        /// Current Page option is selected
        /// </summary>
        /// <returns>Boolean data match status with current page option after download</returns>
        public Boolean CheckDataWithCurrentPage()
        {
            logger.LogMethodEntry("GradingPreferencesPage", "CheckDataWithCurrentPage",
            base.isTakeScreenShotDuringEntryExit);
            //variable Initialization
            bool valueDataMatch = false;
            try
            {
                //Path of the Excel file need to saved
                string getExcelFilePathSaved = (AutomationConfigurationManager.TestDataPath +
                    GradingPreferencesPageResource.GradingPrefernces_Page_AutoIT_ExeFilepath_Locator).
                    Replace("file:\\", "");
                //Array of string
                string[] PathName = getExcelFilePathSaved.Split(Convert.ToChar
                       (GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_Data_colon));
                //Get Excelsheet File Path 
                string getExcelFileDriveSaved = PathName[0];

                getExcelFileDriveSaved = getExcelFileDriveSaved + GradingPreferencesPageResource.
                    GradingPrefernces_Page_CP_Preferences_DownloadedFilepath_Locator;

                //Fetch the csv string in the excel sheet to a variable
                string excelCheckBoxValueLockString = this.ReadDownloadedPreferenceFileData(getExcelFileDriveSaved,
                       Convert.ToInt32(GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_PageNum),
                       Convert.ToInt32(GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_RowNum_CP),
                       Convert.ToInt32(GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_ColNum));

                //Fetch the actual word from the CSV string
                string getExcelCheckBoxValue = this.GetWordFromIndex(excelCheckBoxValueLockString, 2);
                //Compare data in the downloaded file and on the page
                if (this.IsChkMatch(getExcelCheckBoxValue) )
                    valueDataMatch = true;
                else
                    valueDataMatch = false;
                //Log a message after data comparison is complete
                logger.LogMessage("GradingPreferencesPage", "CheckDataWithCurrentPage", "Data comparison complete for Current Page option", true);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "CheckDataWithCurrentPage",
            base.isTakeScreenShotDuringEntryExit);
            return valueDataMatch;
        }

        /// <summary>
        /// To verify if the downloaded email preference status is matching the UI value when
        /// All Pages option is selected
        /// </summary>
        /// <returns>Boolean data match status with All pages option after download</returns>
        public Boolean CheckDataWithAllPages()
        {
            logger.LogMethodEntry("GradingPreferencesPage", "CheckDataWithAllPages",
            base.isTakeScreenShotDuringEntryExit);
            bool valueDataMatch = false;
            try
            {
                //Path of the Excel file need to saved
                string getExcelFilePathSaved = (Path.GetDirectoryName
                    (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) +
                    GradingPreferencesPageResource.GradingPrefernces_Page_AutoIT_ExeFilepath_Locator).
                    Replace("file:\\", "");
                //Array of string
                string[] PathName = getExcelFilePathSaved.Split(Convert.ToChar
                       (GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_Data_colon));
                //Get Excelsheet File Path 
                string getExcelFileDriveSaved = PathName[0];

                getExcelFileDriveSaved = getExcelFileDriveSaved + GradingPreferencesPageResource.
                    GradingPrefernces_Page_CP_Preferences_DownloadedFilepath_Locator;

                //fetch the csv string in the excel sheet to a variable
                string excelCheckBoxValueLockString = this.ReadDownloadedPreferenceFileData(getExcelFileDriveSaved,
                       Convert.ToInt32(GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_PageNum),
                       Convert.ToInt32(GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_RowNum_AP),
                       Convert.ToInt32(GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_ColNum));

                //fetch the actual word that represents the preference status from the CSV string
                string getExcelCheckBoxValue = this.GetWordFromIndex(excelCheckBoxValueLockString, 2);

                string excelCheckBoxLockStatus = this.GetWordFromIndex(excelCheckBoxValueLockString, 3);
                //compare data in the downloaded file and on the page
                if (this.IsChkMatch(getExcelCheckBoxValue))
                    valueDataMatch = true;
                else
                    valueDataMatch = false;
                //log a message after data comparison is complete
                logger.LogMessage("GradingPreferencesPage", "CheckDataWithAllPages",
                    "Data comparison complete for All Pages option", true);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "CheckDataWithAllPages",
            base.isTakeScreenShotDuringEntryExit);
            return valueDataMatch;
        }

        /// <summary>
        /// To verify if the email preference is checked on the UI before downloading and compare
        /// it with the preference check status in the downloaded file
        /// </summary>
        /// <param name="getExcelCheckBoxValue"></param>
        /// <returns>Boolean check box status match on ui and downloaded file</returns>
        public Boolean IsChkMatch(string getExcelCheckBoxValue)
        {
            logger.LogMethodEntry("GradingPreferencesPage", "IsChkMatch",
            base.isTakeScreenShotDuringEntryExit);
            logger.LogMethodExit("GradingPreferencesPage", "IsChkMatch",
            base.isTakeScreenShotDuringEntryExit);
            //comparing the check status before and after download
            //comparing the UI values to the excel file values
            if ((!this.IsCheckedBeforeDL && getExcelCheckBoxValue == 
                GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_Chk) || 
                (!this.IsCheckedBeforeDL && getExcelCheckBoxValue == 
                GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_UnChk))
                return true;
            else
                return false;
        }

        /// <summary>
        /// To verify if the email preference is locked on the UI before downloading and compare 
        /// it with the preference lock status in the downloaded file
        /// </summary>
        /// <param name="excelcheckboxlockstatus"></param>
        /// <returns>Boolean lock status match on ui and downloaded file</returns>
        public Boolean IslockMatch(string excelcheckboxlockstatus)
        {
            logger.LogMethodEntry("GradingPreferencesPage", "IslockMatch",
            base.isTakeScreenShotDuringEntryExit);
            logger.LogMethodExit("GradingPreferencesPage", "IslockMatch",
            base.isTakeScreenShotDuringEntryExit);
            //comparing the lock status before and after download
            //comparing the UI values to the excel file values
            if ((this.IsLockedBeforeDL && excelcheckboxlockstatus == 
                GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_Lock) || 
                (!this.IsLockedBeforeDL && excelcheckboxlockstatus == 
                GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_UnLock))
                return true;
            else
                return false;
        }

        /// <summary>
        /// To read the downloaded preference excel file data 
        /// </summary>
        /// <param name="filePath">Excel file path</param>
        /// <param name="sheetNumber">Excel sheet number</param>
        /// <param name="rowNumber">Row number in the excel sheet</param>
        /// <param name="colNumber">Column number in the excel sheet</param>
        /// <returns>Data string in CSV format</returns>
        public string ReadDownloadedPreferenceFileData(string filePath, int sheetNumber, int rowNumber, int colNumber)
        {

            //Read Preference File Data
            logger.LogMethodEntry("GradingPreferencesPage", "ReadDownloadedPreferenceFileData",
            base.isTakeScreenShotDuringEntryExit);
            string data = string.Empty;

            try
            {
                Excel.Application excelApplication;
                Excel.Workbook excelWorkBook;
                Excel.Worksheet excelWorkSheet;
                Excel.Range range;
                object missingValue = System.Reflection.Missing.Value;
                //Creating excel application object
                excelApplication = new Excel.Application();
                //Read workbook
                excelWorkBook = excelApplication.Workbooks.Open
                    (filePath, 0, false, 5, string.Empty, string.Empty, true,
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
                    GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_Tab_Value,
                    false, false, 0, true, 1, 0);
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(sheetNumber);
                range = excelWorkSheet.UsedRange;
                try
                {
                    //Get the Excel data
                    data = (string)(excelWorkSheet.Cells[rowNumber, colNumber] as Excel.Range).Value2;
                    //Kill the process
                    killprocess(GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_Name);
                    // return data;
                }
                catch (Exception)
                {
                    //Get the Excel Data
                    data = (string)(excelWorkSheet.Cells[rowNumber, colNumber] as Excel.Range).Value2;
                    //Kill the process
                    killprocess(GradingPreferencesPageResource.GradingPrefernces_Page_ExcelSheet_Name);
                    //return data.ToString();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "ReadDownloadedPreferenceFileData",
            base.isTakeScreenShotDuringEntryExit);
            return data.ToString();

        }

        /// <summary>
        /// To get the word in the array at given index
        /// </summary>
        /// <param name="csv">The csv string</param>
        /// <param name="index">index of the word required</param>
        /// <returns>The word required</returns>
        public string GetWordFromIndex(string csv, int index)
        {
            logger.LogMethodEntry("GradingPreferencesPage", "GetWordFromIndex",
            base.isTakeScreenShotDuringEntryExit);
            //split the csv string by the occurence of comma and fill the array
            string[] words = csv.Split(',');
            //log a message after individual data words retrieval is complete
            logger.LogMessage("GradingPreferencesPage", "GetWordFromIndex", "Data retrieved to array from CSV", true);
            logger.LogMethodExit("GradingPreferencesPage", "GetWordFromIndex",
            base.isTakeScreenShotDuringEntryExit);
            return words[index];
        }

        /// <summary>
        /// Kill Excel Process
        /// </summary>
        /// <param name="pathName">path name of the process</param>
        public void killprocess(string pathName)
        {
            //Kill Excel Process
            logger.LogMethodEntry("GradingPreferencesPage", "killprocess",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.StartsWith(pathName))
                    {
                        clsProcess.Kill();
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "killprocess",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To note the check and lock status of Email preference before 
        /// downloading the preferences on work space
        /// </summary>
        public void VerifyCheckLockStatusBeforeDownload()
        {
            logger.LogMethodEntry("GradingPreferencesPage", "VerifyCheckLockStatusBeforeDownload",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Grade Sub Tab Frame
                this.SelectGradeSubTabFrame();
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Id_Locator));
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailLock_Id_Locator));
                //Populating the variables to the preference status before download and use those variables to verify the downloaded file values
                bool isCheckedBeforedownloading = base.GetWebElementPropertiesById(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_Id_Locator).Selected;
                bool isLockedBeforedownloading = base.IsElementPresent(By.XPath(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailCheckBox_LockClosed_Xpath_Locator),
                    Convert.ToInt32(GradingPreferencesPageResource.GradingPrefernces_Page_CustomTimetoWait));
                //Log a message when before download statuses are noted 
                logger.LogMessage("GradingPreferencesPage", "VerifyCheckLockStatusBeforeDownload",
                    "Status before download are noted", true);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "VerifyCheckLockStatusBeforeDownload",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify if the email preference is present or not on the web page UI
        /// </summary>
        /// <returns>Boolean status of the preference text presence</returns>
        public Boolean IsPreferencePresent()
        {
            logger.LogMethodEntry("GradingPreferencesPage", "IsPreferencePresent",
            base.isTakeScreenShotDuringEntryExit);
            //Variable Initialization
            bool isPreferencePresent = false;
            try
            { //Select Grade Sub Tab Frame
                this.SelectGradeSubTabFrame();
                //check for the presence of the preference text
                isPreferencePresent = base.IsElementPresent(By.XPath(GradingPreferencesPageResource.
                    GradingPrefernces_Page_GetIncludeMailText_Xpath_Locator),
                    Convert.ToInt32(GradingPreferencesPageResource.
                    GradingPrefernces_Page_CustomTimetoWait));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", "IsPreferencePresent",
            base.isTakeScreenShotDuringEntryExit);
            return isPreferencePresent;
        }
        /// <summary>
        /// Enable 'Apply Grade Schema' Option
        /// </summary>
        public void EnableApplyGradeSchemaOption()
        {
            //Enable 'Apply Grade Schema' Option
            logger.LogMethodEntry("GradingPreferencesPage", 
                "EnableApplyGradeSchemaOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Enable Glossary Preference                
                new GeneralPreferencesPage().EnableGeneralPreferenceSettings
                    (GradingPreferencesPageResource.
                    GradingPrefernces_Page_GradeSchema_Lock_Id_Locator,
                    GradingPreferencesPageResource.
                        GradingPreferencesPage_ApplyGradeSchema_Id_Locator);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage", 
                "EnableApplyGradeSchemaOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Display Integrity Detection Preference.
        /// </summary>
        public void EnableDisplayIntegrityDetectionPreference()
        {
            //Enable Display Integrity Detection Preference
            logger.LogMethodEntry("GradingPreferencesPage",
                "EnableDisplayIntegrityDetectionPreference",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window And Frame
                this.SelectGradeSubTabFrame();
                //Wait For 'Display Integrity detection to students
                //automatically for Grader projects' Preference Checkbox
                base.WaitForElement(By.Id(GradingPreferencesPageResource.
                    GradingPrefernces_Page_IntegrityDetection_Preference_Id_Locator));
                if (!base.IsElementSelectedById(GradingPreferencesPageResource.
                    GradingPrefernces_Page_IntegrityDetection_Preference_Id_Locator))
                {
                    //Get Lock Icon Status
                    string getGraderIntegrityDetectionLockIconStatus =
                        base.GetClassAttributeValueById(GradingPreferencesPageResource.
                        GradingPrefernces_Page_IntegrityDetection_LockIcon_Id_Locator);
                    if (getGraderIntegrityDetectionLockIconStatus ==
                        QuestionsPreferencesPageResource.
                        QuestionsPreferences_Page_LockIcon_Status_Value)
                    {
                        //Click On Lock Icon to Unlock Preference
                        base.ClickButtonById(GradingPreferencesPageResource.
                        GradingPrefernces_Page_IntegrityDetection_LockIcon_Id_Locator);
                    }
                    //Select 'Display Integrity detection to students
                    //automatically for Grader projects' Preference Checkbox
                    base.SelectCheckBoxById(GradingPreferencesPageResource.
                    GradingPrefernces_Page_IntegrityDetection_Preference_Id_Locator);
                }
                //Click On Save Preferences Button
                this.ClickOnSavePreferencesButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage",
                "EnableDisplayIntegrityDetectionPreference",
                base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enable Folder Level Calculation Checkbox.
        /// </summary>
        public void EnableFolderLevelCalculationCheckbox()
        {
            //Enable Folder Level Calculation Checkbox
            logger.LogMethodEntry("GradingPreferencesPage",
              "EnableFolderLevelCalculationCheckbox",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                if (!base.IsElementSelectedById(GradingPreferencesPageResource.
                        GradingPrefernces_Page_FolderLevel_Id_Locator))
                {
                    //Get Folder Level Checkbox Property
                    IWebElement getFolderLevelCheckboxproperty = base.
                        GetWebElementPropertiesById(GradingPreferencesPageResource.
                    GradingPrefernces_Page_FolderLevel_Id_Locator);
                    //Click on Folder Level Checkbox
                    base.ClickByJavaScriptExecutor(getFolderLevelCheckboxproperty);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage",
                "EnableFolderLevelCalculationCheckbox",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Grading Preference Settings.
        /// </summary>
        public void EnableGradingPreferenceSettings()
        {
            //Enable Grading Preference Settings
            logger.LogMethodEntry("GradingPreferencesPage",
            "EnableGradingPreferenceSettings", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Declare the obeject for page
                GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
                //Select the window
                generalPreferencePage.SelectThePreferenceWindowWithFrame();
                //Enable  percentage or raw score at the course level Preference,send lock and checkbox id
                generalPreferencePage.EnableGeneralPreferenceSettings(
                       GradingPreferencesPageResource.
                       GradingPreferences_Page_Rawscore_Lock_Id_Locator,
                       GradingPreferencesPageResource.
                       GradingPreferences_Page_Rawscore_Checkbox_Id_Locator);
                //Use raw score grades for this course 
                this.SelectRawScoreGrades();
                //Save the preferences
                generalPreferencePage.SavePreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage",
             "EnableGradingPreferenceSettings", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Raw Score Grades.
        /// </summary>
        private void SelectRawScoreGrades()
        {
            //Select Raw Score Grades
            logger.LogMethodEntry("GradingPreferencesPage",
            "SelectRawScoreGrades", base.isTakeScreenShotDuringEntryExit);
            //wait for the element
            base.WaitForElement(By.Id(GradingPreferencesPageResource.
                GradingPreferences_Page_Rawscore_Radiobutton_Id_Locator));
            if (!base.IsElementSelectedById(GradingPreferencesPageResource.
                GradingPreferences_Page_Rawscore_Radiobutton_Id_Locator))
            {
                IWebElement getRawScore = base.GetWebElementPropertiesById
                (GradingPreferencesPageResource.
                GradingPreferences_Page_Rawscore_Radiobutton_Id_Locator);
                //Click the Row Score grades for course
                base.ClickByJavaScriptExecutor(getRawScore);
            }
            logger.LogMethodExit("GradingPreferencesPage",
              "SelectRawScoreGrades", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Filter Content Type Preference Option.
        /// </summary>
        public void EnableFilterContentTypePreferenceOption()
        {
            //Enable Filter Content Type Preference Option
            logger.LogMethodEntry("GradingPreferencesPage",
            "EnableFilterContentTypePreferenceOption",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Enable 'Filter Content Type' Preference                
                new GeneralPreferencesPage().EnableGeneralPreferenceSettings
                    (GradingPreferencesPageResource.
                    GradingPrefernces_Page_FilterContentType_Lock_Id_Locator,
                    GradingPreferencesPageResource.
                    GradingPrefernces_Page_FilterContentType_Checkbox_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage",
              "EnableFilterContentTypePreferenceOption", 
              base.isTakeScreenShotDuringEntryExit);
        }
    }
}
