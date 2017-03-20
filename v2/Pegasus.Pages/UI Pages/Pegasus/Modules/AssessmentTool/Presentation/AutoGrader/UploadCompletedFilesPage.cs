using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Common;
using System.Threading;
using System.Diagnostics;


namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation.AutoGrader
{
    /// <summary>
    //
    ///
    /// 
    /// </summary>

    public class UploadCompletedFilesPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(UploadCompletedFilesPage));

        /// <summary>
        /// Upload the Grader IT file based on the activity and 
        /// submission score type
        /// by selecting from appropriate path.
        /// </summary>
        /// <param name="uploadFileName">File name to be uploaded.</param>
        public void UploadGraderItFile(String uploadFileName)
        {
            //Upload graderIT file
            logger.LogMethodEntry("UploadCompletedFilesPage", "UploadGraderItFile",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.WaitUntilPopUpLoads(UploadCompletedFilesResource.
                    UploadCompleteFile_Popup_Title_Value);
                //Select Window
                base.SelectWindow(UploadCompletedFilesResource.
                    UploadCompleteFile_Popup_Title_Value);
                //Grader IT File Upload.
                switch (uploadFileName)
                {
                    // Upload Grader Excel file for 100% Score.
                    case "Grader Excel file for 100%":
                        string getGraderItExcelFilePathFor100Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                          UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_Excel_File_100Percent_Path).
                            Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItExcelFilePathFor100Percent, By.Id(UploadCompletedFilesResource.
                            UploadCompleteFile_Button_Browse_Id_value));
                        //Get Save and Return Button Property
                        IWebElement getUploadButtonPropertyForExcel100Percent = base.GetWebElementPropertiesById(
                            UploadCompletedFilesResource.UploadCompleteFile_Upload_Button_Id_value);
                        //Click on the Save and Return button 
                        base.ClickByJavaScriptExecutor(getUploadButtonPropertyForExcel100Percent);
                        break;

                    // Upload Grader Excel file for 0% Score.
                    case "Grader Excel file for 0%":
                        string getGraderItExcelFilePathFor0Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                          UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_Excel_File_0Percent_Path).
                            Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItExcelFilePathFor0Percent, By.Id(UploadCompletedFilesResource.
                            UploadCompleteFile_Button_Browse_Id_value));
                        //Get Save and Return Button Property
                        IWebElement getUploadButtonPropertyForExcel0Percent = base.GetWebElementPropertiesById(
                            UploadCompletedFilesResource.UploadCompleteFile_Upload_Button_Id_value);
                        //Click on the Save and Return button 
                        base.ClickByJavaScriptExecutor(getUploadButtonPropertyForExcel0Percent);
                        break;

                    // Upload Grader Excel file for 70% Score.
                    case "Grader Excel file for 70%":
                        string getGraderItExcelFilePathFor70Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                          UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_Excel_File_70Percent_Path).
                            Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItExcelFilePathFor70Percent, By.Id(UploadCompletedFilesResource.
                            UploadCompleteFile_Button_Browse_Id_value));
                        //Get Save and Return Button Property
                        IWebElement getUploadButtonPropertyForExcel70Percent = base.GetWebElementPropertiesById(
                            UploadCompletedFilesResource.UploadCompleteFile_Upload_Button_Id_value);
                        //Click on the Save and Return button 
                        base.ClickByJavaScriptExecutor(getUploadButtonPropertyForExcel70Percent);
                        break;

                    // Upload Grader Word file for 70% Score.
                    case "Grader Word file for 70%":
                        string getGraderItWordFilePathFor70Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                        UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_Word_File_70Percent_Path).
                        Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItWordFilePathFor70Percent, By.Id(UploadCompletedFilesResource.
                        UploadCompleteFile_Button_Browse_Id_value));
                        //Get Save and Return Button Property
                        IWebElement getUploadButtonPropertyForWord70Percent = base.GetWebElementPropertiesById(
                        UploadCompletedFilesResource.UploadCompleteFile_Upload_Button_Id_value);
                        //Click on the Save and Return button 
                        base.ClickByJavaScriptExecutor(getUploadButtonPropertyForWord70Percent);
                        break;

                    // Upload Grader Word file for 0% Score.
                    case "Grader Word file for 0%":
                        string getGraderItWordFilePathFor0Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                        UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_Word_File_0Percent_Path).
                        Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItWordFilePathFor0Percent, By.Id(UploadCompletedFilesResource.
                        UploadCompleteFile_Button_Browse_Id_value));
                        //Get Save and Return Button Property
                        IWebElement getUploadButtonPropertyForWord0Percent = base.GetWebElementPropertiesById(
                        UploadCompletedFilesResource.UploadCompleteFile_Upload_Button_Id_value);
                        //Click on the Save and Return button 
                        base.ClickByJavaScriptExecutor(getUploadButtonPropertyForWord0Percent);
                        break;

                    // Upload Grader Word file for 100% Score.
                    case "Grader Word file for 100%":
                        string getGraderItWordFilePathFor100Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                        UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_Word_File_100Percent_Path).
                        Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItWordFilePathFor100Percent, By.Id(UploadCompletedFilesResource.
                        UploadCompleteFile_Button_Browse_Id_value));
                        //Get Save and Return Button Property
                        IWebElement getUploadButtonPropertyForWord100Percent = base.GetWebElementPropertiesById(
                        UploadCompletedFilesResource.UploadCompleteFile_Upload_Button_Id_value);
                        //Click on the Save and Return button 
                        base.ClickByJavaScriptExecutor(getUploadButtonPropertyForWord100Percent);
                        break;

                    // Upload Grader Power Point file for 100% Score.
                    case "Grader Power Point file for 100%":
                        string getGraderItPowerPointFilePathFor100Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                        UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_PowerPoint_File_100Percent_Path).
                        Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItPowerPointFilePathFor100Percent, By.Id(UploadCompletedFilesResource.
                        UploadCompleteFile_Button_Browse_Id_value));
                        //Get Save and Return Button Property
                        IWebElement getUploadButtonPropertyForPowerPoint100Percent = base.GetWebElementPropertiesById(
                        UploadCompletedFilesResource.UploadCompleteFile_Upload_Button_Id_value);
                        //Click on the Save and Return button 
                        base.ClickByJavaScriptExecutor(getUploadButtonPropertyForPowerPoint100Percent);
                        break;

                    // Upload Grader Power Point file for 0% Score.
                    case "Grader Power Point file for 0%":
                        string getGraderItPowerPointFilePathFor0Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                        UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_PowerPoint_File_0Percent_Path).
                        Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItPowerPointFilePathFor0Percent, By.Id(UploadCompletedFilesResource.
                        UploadCompleteFile_Button_Browse_Id_value));
                        //Get Save and Return Button Property
                        IWebElement getUploadButtonPropertyForPowerPoint0Percent = base.GetWebElementPropertiesById(
                        UploadCompletedFilesResource.UploadCompleteFile_Upload_Button_Id_value);
                        //Click on the Save and Return button 
                        base.ClickByJavaScriptExecutor(getUploadButtonPropertyForPowerPoint0Percent);
                        break;

                    // Upload Grader Power Point file for 70% Score.
                    case "Grader Power Point file for 70%":
                        string getGraderItPowerPointFilePathFor70Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                        UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_PowerPoint_File_70Percent_Path).
                        Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItPowerPointFilePathFor70Percent, By.Id(UploadCompletedFilesResource.
                        UploadCompleteFile_Button_Browse_Id_value));
                        //Get Save and Return Button Property
                        IWebElement getUploadButtonPropertyForPowerPoint70Percent = base.GetWebElementPropertiesById(
                        UploadCompletedFilesResource.UploadCompleteFile_Upload_Button_Id_value);
                        //Click on the Save and Return button 
                        base.ClickByJavaScriptExecutor(getUploadButtonPropertyForPowerPoint70Percent);
                        break;

                    // Upload Grader Access file for 70% Score.
                    case "Grader Access file for 70%":
                        string getGraderItAccessFilePathFor70Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                        UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_Access_File_70Percent_Path).
                        Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItAccessFilePathFor70Percent, By.Id(UploadCompletedFilesResource.
                        UploadCompleteFile_Button_Browse_Id_value));
                        //Get Save and Return Button Property
                        IWebElement getUploadButtonPropertyForAccess70Percent = base.GetWebElementPropertiesById(
                        UploadCompletedFilesResource.UploadCompleteFile_Upload_Button_Id_value);
                        //Click on the Save and Return button 
                        base.ClickByJavaScriptExecutor(getUploadButtonPropertyForAccess70Percent);
                        break;

                    // Upload Grader Access file for 0% Score.
                    case "Grader Access file for 0%":
                        string getGraderItAccessFilePathFor0Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                        UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_Access_File_0Percent_Path).
                        Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItAccessFilePathFor0Percent, By.Id(UploadCompletedFilesResource.
                        UploadCompleteFile_Button_Browse_Id_value));
                        //Get Save and Return Button Property
                        IWebElement getUploadButtonPropertyForAccess0Percent = base.GetWebElementPropertiesById(
                        UploadCompletedFilesResource.UploadCompleteFile_Upload_Button_Id_value);
                        //Click on the Save and Return button 
                        base.ClickByJavaScriptExecutor(getUploadButtonPropertyForAccess0Percent);
                        break;

                    // Upload Grader Access file for 100% Score.
                    case "Grader Access file for 100%":
                        string getGraderItAccessFilePathFor100Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                        UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_Access_File_100Percent_Path).
                        Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItAccessFilePathFor100Percent, By.Id(UploadCompletedFilesResource.
                        UploadCompleteFile_Button_Browse_Id_value));
                        //Get Save and Return Button Property
                        IWebElement getUploadButtonPropertyForAccess100Percent = base.GetWebElementPropertiesById(
                        UploadCompletedFilesResource.UploadCompleteFile_Upload_Button_Id_value);
                        //Click on the Save and Return button 
                        base.ClickByJavaScriptExecutor(getUploadButtonPropertyForAccess100Percent);
                        break;
                }
                Thread.Sleep(Convert.ToInt32(PresentationPageResource.
                PresentationPage_Page_Element_WaitTime_Value));
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ImportUsersPage", "UploadBulkUserFile",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Upload the Grader IT file based on the activity and 
        /// submission score type
        /// by selecting from appropriate path.
        /// </summary>
        /// <param name="uploadFileName">File name to be uploaded.</param>
        public void UploadGraderItFile2016(String uploadFileName)
        {
            //Upload graderIT file
            logger.LogMethodEntry("UploadCompletedFilesPage", "UploadGraderItFile",
                base.IsTakeScreenShotDuringEntryExit);
            Process process;
            try
            {
                Thread.Sleep(10000);
                switch (uploadFileName)
                {
                    case "Grader Word file for 0%":
                        process = Process.Start(@"E:\SeleniumGrid\AutoItScripts\UploadGrader2016WordFor0Score.exe");
                        break;

                    case "Grader Word file for 70%":
                        process = Process.Start(@"E:\SeleniumGrid\AutoItScripts\UploadGrader2016WordFor70Score.exe");
                        break;

                    case "Grader Word file for 100%":
                        process = Process.Start(@"E:\SeleniumGrid\AutoItScripts\UploadGrader2016WordFor100Score.exe");
                        break;

                    case "Grader Excel file for 0%":
                        process = Process.Start(@"E:\SeleniumGrid\AutoItScripts\UploadGrader2016ExcelFor0Score.exe");
                        break;

                    case "Grader Excel file for 70%":
                        process = Process.Start(@"E:\SeleniumGrid\AutoItScripts\UploadGrader2016ExcelFor70Score.exe");
                        break;

                    case "Grader Excel file for 100%":
                        process = Process.Start(@"E:\SeleniumGrid\AutoItScripts\UploadGrader2016ExcelFor100Score.exe");
                        break;

                    case "Grader Access file for 0%":
                        process = Process.Start(@"E:\SeleniumGrid\AutoItScripts\UploadGrader2016AccessFor0Score.exe");
                        break;

                    case "Grader Access file for 70%":
                        process = Process.Start(@"E:\SeleniumGrid\AutoItScripts\UploadGrader2016AccessFor70Score.exe");
                        break;

                    case "Grader Access file for 100%":
                        process = Process.Start(@"E:\SeleniumGrid\AutoItScripts\UploadGrader2016AccessFor100Score.exe");
                        break;

                    case "Grader PowerPoint file for 0%":
                        process = Process.Start(@"E:\SeleniumGrid\AutoItScripts\UploadGrader2016PowerPointFor0Score.exe");
                        break;

                    case "Grader PowerPoint file for 70%":
                        process = Process.Start(@"E:\SeleniumGrid\AutoItScripts\UploadGrader2016PowerPointFor70Score.exe");
                        break;

                    case "Grader PowerPoint file for 100%":
                        process = Process.Start(@"E:\SeleniumGrid\AutoItScripts\UploadGrader2016PowerPointFor100Score.exe");
                        break;

                }
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ImportUsersPage", "UploadBulkUserFile",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}