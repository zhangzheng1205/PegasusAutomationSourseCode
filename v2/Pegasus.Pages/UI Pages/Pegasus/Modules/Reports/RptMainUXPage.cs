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

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus RptMainUX Page Actions
    /// </summary>
    public class RptMainUXPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(RptMainUXPage));

        /// <summary>
        /// This is the Bulk Upload Interval Time from AppSettings.
        /// </summary>
        static readonly int GetMinutesToWait = Int32.Parse
            (ConfigurationManager.AppSettings[RptMainUXPageResource
            .RptMainUX_Page_AssignToCopy_AppConfig_Key]);

        /// <summary>
        /// This is the Pegasus Intructor Type Reports.
        /// </summary>
        public enum PegasusInstructorReportEnum
        {
            /// <summary>
            /// Activity Result by Student Report Type
            /// </summary>
            ActivityResultsbyStudent = 1,
            /// <summary>
            /// Student Result by Activity Report Type
            /// </summary>
            StudentResultsbyActivity = 2,
            /// <summary>
            /// Student Activity Report
            /// </summary>            
            StudentActivityReport = 3,
            /// <summary>
            /// Custom Activity Report
            /// </summary>
            CustomActivityReport = 4,
            ///<summary>
            ///Class Mastery Report
            ///</summary>
            ClassMasteryReport = 5,
            ///<summary>
            ///Individual Student Mastery Report
            ///</summary>
            IndividualStudentMasteryReport = 6,
            /// <summary>
            /// Study Plan Report Type
            /// </summary>
            StudyPlanResults = 7,
            /// <summary>
            /// Training Frequency Analysis Report Type.
            /// </summary>
            TrainingFrequencyAnalysis = 8,
            /// <summary>
            /// Activity Results Single Student Report Type.
            /// </summary>
            ActivityResultsSingleStudent = 9,
            /// <summary>
            /// Exam Frequency Analysis Report Type.
            /// </summary>
            ExamFrequencyAnalysis = 10
        }

        /// <summary>
        /// This is the Pegasus Intructor Certificate Types.
        /// </summary>
        public enum PegasusInstructorCertificateTypeEnum
        {
            /// <summary>
            /// 'Certificate of Completion(Training)' Certificate Type
            /// </summary>
            CertificateofCompletionTraining = 1,
            CertificateofCompletionExam = 2
        }

        /// <summary>
        /// Manage Instructor type Report in Pegasus.
        /// </summary>
        /// <param name="reportTypeEnum">This is Report Type Enum.</param>
        /// <param name="userType">This is user type</param>
        public void ManageInstructorReport(
            PegasusInstructorReportEnum reportTypeEnum, String userType)
        {
            //Manage Instructor Reports by Types
            Logger.LogMethodEntry("RptMainUXPage", "ManageInstructorReport",
               base.isTakeScreenShotDuringEntryExit);
            //Select According to Pegasus Report type            
            try
            {
                //Report Type
                switch (reportTypeEnum)
                {
                    //Generate Activity Result by Student Report
                    case RptMainUXPage.PegasusInstructorReportEnum.ActivityResultsbyStudent:
                        this.ActivityResultbyStudentReport(reportTypeEnum);
                        break;
                    case RptMainUXPage.PegasusInstructorReportEnum.StudentActivityReport:
                        this.SelectStudentActivityReport(userType);
                        break;
                    case RptMainUXPage.PegasusInstructorReportEnum.StudentResultsbyActivity:
                        this.StudentResultByActivityReport(reportTypeEnum);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("RptMainUXPage", "ManageInstructorReport",
               base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        ///Select Mastery Report link.
        /// </summary>
        public void ClickTheMasteryReportsLink(PegasusInstructorReportEnum reportTypeEnum)
        {
            Logger.LogMethodEntry("RptMainUXPage", "ClickTheInstructorReportsLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (reportTypeEnum)
                {
                    //Class Mastery Report
                    case RptMainUXPage.PegasusInstructorReportEnum.ClassMasteryReport:
                        new RptMasteryPage().ClickTheClassMasteryLink();
                        break;
                    //Individual Student Mastery Report
                    case RptMainUXPage.PegasusInstructorReportEnum.IndividualStudentMasteryReport:
                        new RptMasteryPage().ClickTheStudentMasteryLink();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "ClickTheInstructorReportsLink",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Generate Mastery Reports.
        /// </summary>
        public String GenerateMasteryReportForSkill(PegasusInstructorReportEnum reportTypeEnum, string skillName)
        {
            try
            {
                switch (reportTypeEnum)
                {
                    //Class Mastery Report
                    case RptMainUXPage.PegasusInstructorReportEnum.ClassMasteryReport:
                        skillName = GenerateClassMasteryReport(skillName);
                        break;
                    //Individual Student Mastery Report
                    case RptMainUXPage.PegasusInstructorReportEnum.IndividualStudentMasteryReport:
                        skillName = GenerateStudentMasteryReport(skillName);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "GenerateMasteryReportForSkill",
             base.isTakeScreenShotDuringEntryExit);
            return skillName;
        }

        /// <summary>
        ///Generate Class Mastery Report.
        /// </summary>
        private string GenerateClassMasteryReport(String skillName)
        {
            //Select The Student Activity Report
            Logger.LogMethodEntry("RptMainUXPage", "GenerateClassMasteryReport",
               base.isTakeScreenShotDuringEntryExit);
            RptCommonCriteriaPage rptCommonCriteriaPage = new RptCommonCriteriaPage();
            //Select "Skills" or "Standard" radio button and click on "Select Skills" button            
            rptCommonCriteriaPage.SelectSkillStdOption();
            //Select the skills from Light box
            rptCommonCriteriaPage.SelectTheSkillsFromLightBox(skillName);
            //Select The Students From LightBox
            rptCommonCriteriaPage.SelectTheStudentsForSkillsFromLightBox();
            //Click Run Report
            rptCommonCriteriaPage.ClickRunReport();
            //Validate skill name
            skillName = new RptMasteryPage().ValidateSkillNameForMasteryReport();
            Logger.LogMethodEntry("RptMainUXPage", "GenerateClassMasteryReport",
               base.isTakeScreenShotDuringEntryExit);
            return skillName;
        }

        /// <summary>
        ///Generate Student Mastery Report.
        /// </summary>
        private string GenerateStudentMasteryReport(String skillName)
        {
            //Select The Student Activity Report
            Logger.LogMethodEntry("RptMainUXPage", "GenerateStudentMasteryReport",
               base.isTakeScreenShotDuringEntryExit);
            RptCommonCriteriaPage rptCommonCriteriaPage = new RptCommonCriteriaPage();
            //Select The Students From LightBox
            rptCommonCriteriaPage.SelectTheStudentsForSkillsFromLightBox();
            //Select "Skills" or "Standard" radio button and click on "Select Skills" button            
            rptCommonCriteriaPage.SelectSkillStdOption();
            //Select the skills from Light box
            rptCommonCriteriaPage.SelectTheSkillsFromLightBox(skillName);
            //Click Run Report
            rptCommonCriteriaPage.ClickRunReport();
            //Validate skill name
            skillName = new RptMasteryPage().ValidateSkillNameForMasteryReport();
            Logger.LogMethodEntry("RptMainUXPage", "GenerateStudentMasteryReport",
               base.isTakeScreenShotDuringEntryExit);
            return skillName;
        }

        //===========Mastery Reports - End=====================

        /// <summary>
        ///Select The Student Activity Report.
        /// </summary>
        /// <param name="userType">This is User type</param>
        private void SelectStudentActivityReport(string userType)
        {
            //Select The Student Activity Report
            Logger.LogMethodEntry("InstructorReports",
                "SelectStudentActivityReport",
               base.isTakeScreenShotDuringEntryExit);
            //Click The Student Activity Link
            new RptStudentActivityPage().ClickTheStudentActivityLink();
            //Select The Students From LightBox
            new RptCommonCriteriaPage().SelectTheStudentsFromLightBox(userType);
            //Click Run Report
            new RptCommonCriteriaPage().ClickRunReport();
            Logger.LogMethodEntry("RptMainUXPage",
                "SelectStudentActivityReport",
               base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Generating Activity Result By Student Type Report.
        /// </summary>
        /// <param name="reportTypeEnum">This is report type enum.</param>
        private void ActivityResultbyStudentReport(
            PegasusInstructorReportEnum reportTypeEnum)
        {
            //Generating the Activity Result By Student Report
            Logger.LogMethodEntry("InstructorReports", "ActivityResultbyStudentReport",
               base.isTakeScreenShotDuringEntryExit);
            //Select Activity Result by Student Report
            this.SelectReport();
            //Select the Activity
            new RptGCOptionsUXPage().SelectActivity();
            //Select the Student
            new RptGCOptionsUXPage().SelectStudent(reportTypeEnum);
            //Generate the Activity Result By Student Report
            new RptGCOptionsUXPage().GenerateReport();
            Logger.LogMethodExit("InstructorReports", "ActivityResultbyStudentReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting Activity Result By Student Report.
        /// </summary>
        public void SelectReport()
        {
            //Select Activity Result by Student type Report
            Logger.LogMethodEntry("RptMainUXPage", "SelectReport",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to Default Page
                base.SwitchToDefaultWindow();
                //Click on Activity Result By Student Report Link
                this.ClickonActivityResultByStudentReportLink();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "SelectReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Activity Result By Student Report Link.
        /// </summary>
        private void ClickonActivityResultByStudentReportLink()
        {
            //Click on Activity Result By Student Report Link
            Logger.LogMethodEntry("RptMainUXPage", "ClickonActivityResultByStudentReportLink",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Frame
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMain_Page_Frame_Id_Locator));
            base.SwitchToIFrame(RptMainUXPageResource.
                RptMain_Page_Frame_Id_Locator);
            //Select Activity Result By Student Report
            base.WaitForElement(By.XPath(RptMainUXPageResource.
                RptMainUX_Page_Report_Xpath_Locator));
            base.ClickButtonByXPath(RptMainUXPageResource.
                RptMainUX_Page_Report_Xpath_Locator);
            Logger.LogMethodExit("RptMainUXPage", "ClickonActivityResultByStudentReportLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Generate Student Result By Activity Type Report.
        /// </summary>
        /// <param name="reportTypeEnum">This is Report Type Enum.</param>
        private void StudentResultByActivityReport(
            PegasusInstructorReportEnum reportTypeEnum)
        {
            //Generate Student Result By Activity Type Report
            Logger.LogMethodEntry("RptMainUXPage", "StudentResultByActivityReport",
                base.isTakeScreenShotDuringEntryExit);
            //Select Student Results By Activity Report
            this.SelectStudentResultByActivityReport();
            //Select the Student
            new RptGCOptionsUXPage().SelectStudentInStudentResultByActivityReport(reportTypeEnum);
            //Select the Activity 
            new RptSelectAssessmentsPage().SelectActivityInStudentResultsByActivityReport(
                RptMainUXPageResource.RptMainUX_Page_Ins_Activity_Name);
            //Generate the Report
            new RptGCOptionsUXPage().GenerateReport();
            Logger.LogMethodExit("RptMainUXPage", "StudentResultByActivityReport",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student Results By Activity Report.
        /// </summary>
        private void SelectStudentResultByActivityReport()
        {
            //Select Student Results By Activity Report
            Logger.LogMethodEntry("RptMainUXPage",
                "SelectStudentResultByActivityReport",
               base.isTakeScreenShotDuringEntryExit);
            //Select Reports Window    
            base.SelectWindow(RptMainUXPageResource.
                RptMainUX_Page_Report_Window_Name);
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMain_Page_Frame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(RptMainUXPageResource.
                RptMain_Page_Frame_Id_Locator);
            base.WaitForElement(By.XPath(RptMainUXPageResource.
                RptMainUX_Page_StudentResultByActivityReport_Xpath_Locator));
            base.FocusOnElementByXPath(RptMainUXPageResource.
                RptMainUX_Page_StudentResultByActivityReport_Xpath_Locator);
            //Click On Student Result By Activity Report
            base.ClickButtonByXPath(RptMainUXPageResource.
                RptMainUX_Page_StudentResultByActivityReport_Xpath_Locator);
            Logger.LogMethodExit("RptMainUXPage", "SelectStudentResultByActivityReport",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Manage Instructor Report In Organization Admin.
        /// </summary>
        /// <param name="reportTypeEnum">This is Report Type Enum.</param>
        /// <param name="userType">This is User type</param>
        public void ManageInstructorReportInOrganizationAdmin(
            PegasusInstructorReportEnum reportTypeEnum, String userType)
        {
            //Manage Instructor Report In Organization Admin
            Logger.LogMethodEntry("RptMainUXPage", "ManageInstructorReportInOrganizationAdmin",
              base.isTakeScreenShotDuringEntryExit);
            //Select According to Pegasus Report type            
            try
            {
                //Report Type
                switch (reportTypeEnum)
                {
                    //Generate Activity Result by Student Report                   
                    case RptMainUXPage.PegasusInstructorReportEnum.StudentActivityReport:
                        this.SelectStudentActivityReportInOrganizationAdmin(userType);
                        break;
                    //Generate Activity Result by Custom Report                   
                    case RptMainUXPage.PegasusInstructorReportEnum.CustomActivityReport:
                        this.SelectCustomReportInOrgnizationAdmin();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "ManageInstructorReportInOrganizationAdmin",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student Activity Report In Organization Admin.
        /// </summary>
        /// <param name="userType">This is user type</param>
        private void SelectStudentActivityReportInOrganizationAdmin(string userType)
        {
            //Select Student Activity Report In Organization Admin
            Logger.LogMethodEntry("RptMainUXPage",
                "SelectStudentActivityReportInOrganizationAdmin",
             base.isTakeScreenShotDuringEntryExit);
            //Select Report Frame
            this.SelectReportFrame();
            //Wait for the Student Activity link
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMain_Page_StudentActivity_Link_Id_Locator));
            IWebElement getStudentLink = base.GetWebElementPropertiesById
                (RptMainUXPageResource.RptMain_Page_StudentActivity_Link_Id_Locator);
            //Click the Student Activity link
            base.ClickByJavaScriptExecutor(getStudentLink);
            Thread.Sleep(Convert.ToInt32(RptMainUXPageResource.
                RptMain_Page_StudentActivity_Window_Time));
            //Select Add Class
            new RptPadminCriteriaPage().SelectAddClass(userType);
            Logger.LogMethodExit("RptMainUXPage",
                "SelectStudentActivityReportInOrganizationAdmin",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Report Frame.
        /// </summary>
        private void SelectReportFrame()
        {
            //Select Report Frame
            Logger.LogMethodEntry("RptMainUXPage", "SelectReportFrame",
             base.isTakeScreenShotDuringEntryExit);
            //Wait for the window loads
            base.WaitUntilWindowLoads(RptMainUXPageResource.
                RptMain_Page_ManageOrg_Window_Name);
            base.SelectWindow(RptMainUXPageResource.
                RptMain_Page_ManageOrg_Window_Name);
            //Select the frames
            base.SwitchToIFrame(RptMainUXPageResource.
                RptMain_Page_ManageOrg_Window_Frame_Name);
            base.SwitchToIFrame(RptMainUXPageResource.
                RptMain_Page_ManageOrg_Window_MainFrame_Name);
            Logger.LogMethodExit("RptMainUXPage", "SelectReportFrame",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Custom Report In Organization Admin.
        /// </summary>
        private void SelectCustomReportInOrgnizationAdmin()
        {
            //Select Custom Report In Organization Admin              
            Logger.LogMethodEntry("RptMainUXPage",
                "SelectCustomReportInOrgnizationAdmin",
            base.isTakeScreenShotDuringEntryExit);
            //Select Report Frame
            this.SelectReportFrame();
            //Wait for the Custom report link
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMainUX_Page_CustomReport_Link_Id_Locator));
            IWebElement getCustomtLink = base.GetWebElementPropertiesById
                (RptMainUXPageResource.
                RptMainUX_Page_CustomReport_Link_Id_Locator);
            //Click the Custom report link
            base.ClickByJavaScriptExecutor(getCustomtLink);
            Thread.Sleep(Convert.ToInt32(RptMainUXPageResource.
                RptMain_Page_StudentActivity_Window_Time));
            //Declaration Page Class Object
            RptCustomReportCriteriaPage RptCustomReportCriteriaPage =
                new RptCustomReportCriteriaPage();
            //Select organization
            RptCustomReportCriteriaPage.SelectOrganization();
            //Select the Course
            new RptSelectCoursesPage().SelectTheCourse();
            //Select all students
            RptCustomReportCriteriaPage.SelectAllStudent();
            //Select Class Columns
            RptCustomReportCriteriaPage.SelectClassColumns();
            //Click The Ok Button
            this.ClickTheOkButton();
            Logger.LogMethodExit("RptMainUXPage", "SelectCustomReportInOrgnizationAdmin",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Ok Button.
        /// </summary>
        private void ClickTheOkButton()
        {
            // Click The Ok Button
            Logger.LogMethodEntry("RptMainUXPage", "ClickTheOkButton",
            base.isTakeScreenShotDuringEntryExit);
            //Wait for the OK btn
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMain_Page_Ok_Btn_Id_Locator));
            IWebElement getOkBtnProperty = base.GetWebElementPropertiesById
                (RptMainUXPageResource.
                RptMain_Page_Ok_Btn_Id_Locator);
            //Click the OK btn
            base.ClickByJavaScriptExecutor(getOkBtnProperty);
            Stopwatch stopwatch = new Stopwatch();
            //Stopwatch started
            stopwatch.Start();
            //Initialize Variable
            string message = string.Empty;
            do
            {   //Delay
                Thread.Sleep(Convert.ToInt32(RptMainUXPageResource.
                    RptMain_Page_CustomReport_Cmenu_Window_Time));
                base.RefreshTheCurrentPage();
                //Select Report Frame
                this.SelectReportFrame();
                //Get message
                message = base.GetElementTextByXPath(RptMainUXPageResource.
                    RptMain_Page_CustomReport_AssignCopystate_Xpath_Locator);
            }
            while (message.Contains(RptMainUXPageResource.
                RptMain_Page_CustomReport_AssignCopystate_Mesg) &&
                        stopwatch.Elapsed.TotalMinutes < GetMinutesToWait);
            Logger.LogMethodExit("RptMainUXPage", "ClickTheOkButton",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Custom Frame.
        /// </summary>
        public void SelectCustomFrame()
        {
            //Select Custom Frame
            Logger.LogMethodEntry("RptMainUXPage", "SelectCustomFrame",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the window loads
                base.WaitUntilWindowLoads(RptMainUXPageResource.
                    RptMain_Page_ManageOrg_Window_Name);
                base.SelectWindow(RptMainUXPageResource.
                    RptMain_Page_ManageOrg_Window_Name);
                //Select the frame
                base.SwitchToIFrame(RptMainUXPageResource.
                    RptMain_Page_ManageOrg_Window_Frame_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "SelectCustomFrame",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// //Select Download Report Option. 
        /// </summary>
        public void SelectDownloadReportOption()
        {
            //Select Download Report Option
            Logger.LogMethodEntry("RptMainUXPage", "SelectDownloadReportOption",
           base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Report Frame
                this.SelectReportFrame();
                //Wait for the img button
                base.WaitForElement(By.XPath(RptMainUXPageResource.
                    RptMainUX_Page_CustomReport_Triangle_img_Xpath_Locator));
                base.FocusOnElementByXPath(RptMainUXPageResource.
                    RptMainUX_Page_CustomReport_Triangle_img_Xpath_Locator);
                //Get web element
                IWebElement getImgCmenu = base.GetWebElementPropertiesByXPath
                    (RptMainUXPageResource.
                    RptMainUX_Page_CustomReport_Triangle_img_Xpath_Locator);
                //Click the img button
                base.ClickByJavaScriptExecutor(getImgCmenu);
                Thread.Sleep(Convert.ToInt32(RptMainUXPageResource.
                    RptMainUX_Page_CustomReport_WindowTime));
                //Wait for the cmenu
                base.WaitForElement(By.Id(RptMainUXPageResource.
                    RptMainUX_Page_CustomReport_Cmenu_Id_Locator));
                base.WaitForElement(By.Id(RptMainUXPageResource.
                    RptMainUX_Page_CustomReport_CmenuOption_Id_Locator));
                IWebElement getDownloadreport = base.GetWebElementPropertiesById
                    (RptMainUXPageResource.
                    RptMainUX_Page_CustomReport_CmenuOption_Id_Locator);
                //Click the DownloadReport option
                base.ClickByJavaScriptExecutor(getDownloadreport);
                Thread.Sleep(Convert.ToInt32(RptMainUXPageResource.
                    RptMain_Page_StudentActivity_Window_Time));
                //Save The Custom Report
                this.SaveTheCustomReport();
                Thread.Sleep(Convert.ToInt32(RptMainUXPageResource.
                    RptMainUX_Page_CustomReport_DownloadReport_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "SelectDownloadReportOption",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save The Custom Report
        /// </summary>
        private void SaveTheCustomReport()
        {
            //Save The Custom Report
            Logger.LogMessage("RptMainUXPage", "SaveTheCustomReport",
                "Reached report download", true);
            //Get Excelsheet File Path 
            string getExeFilePath = (AutomationConfigurationManager.TestDataPath +
               RptMainUXPageResource.RptMainUX_Page_AutoIT_ExeFilepath_Locator).
               Replace("file:\\", "");
            //Path of the Excel file need to saved
            string getExcelFilePathSaved = (AutomationConfigurationManager.TestDataPath +
                RptMainUXPageResource.RptMainUX_Page_AutoIT_ExeFilepath_Locator).
                Replace("file:\\", "");
            string[] PathName = getExcelFilePathSaved.Split(Convert.ToChar
                (RptMainUXPageResource.RptMainUX_Page_ExcelSheet_Data_colan));
            //Array of string
            string getExcelFileDriveSaved = PathName[0];
            getExcelFileDriveSaved = getExcelFileDriveSaved + RptMainUXPageResource.
                RptMainUX_Page_CustomReport_DownloadedFilepath_Locator;
            //Run AutoIT.exe file               
            Process.Start(getExeFilePath, getExcelFileDriveSaved);
            Logger.LogMessage("RptMainUXPage", "SaveTheCustomReport",
                "Launched AutoIT for Saving Downloaded Report", true);
        }

        /// <summary>
        /// Read Custom Report Data.
        /// </summary>
        /// <param name="filePath">Path of the excelsheet.</param>
        /// <param name="sheetNumber">ExcelSheet Number.</param>
        /// <param name="rowNumber">ExcelSheet row Number.</param>
        /// <param name="colNumber">ExcelSheet column Number.</param>
        /// <returns>Excel Data</returns>
        private string ReadCustomReportData(String filePath, int sheetNumber,
            int rowNumber, int colNumber)
        {
            //Read Custom Report Data
            Logger.LogMethodEntry("RptMainUXPage", "ReadCustomReportData",
           base.isTakeScreenShotDuringEntryExit);
            //Initialized String
            String getDataFromSheet = String.Empty;
            try
            {
                //Creating excel application object
                Excel.Application excelApplication = new Excel.Application();
                //Read workbook
                Excel.Workbook excelWorkBook = excelApplication.Workbooks.Open
                    (filePath, 0, false, 5, string.Empty, string.Empty, true,
                     Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
                     RptMainUXPageResource.RptMainUX_Page_ExcelSheet_Tab_Value,
                     false, false, 0, true, 1, 0);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkBook.
                    Worksheets.Item[sheetNumber];
                Excel.Range range = excelWorkSheet.UsedRange;
                try
                {
                    //Get the Excel data
                    getDataFromSheet = (String)(range.Cells[rowNumber, colNumber] as Excel.Range).Value2;
                    //Kill the process
                    KillExcelProcess(RptMainUXPageResource.RptMainUX_Page_ExcelSheet_Name);
                    // return data;
                }
                catch (Exception)
                {
                    //Get the Excel Data
                    getDataFromSheet = (String)(range.Cells[rowNumber, colNumber] as Excel.Range).Value2;
                    //Kill the process
                    KillExcelProcess(RptMainUXPageResource.RptMainUX_Page_ExcelSheet_Name);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "ReadCustomReportData",
              base.isTakeScreenShotDuringEntryExit);
            return getDataFromSheet;
        }

        /// <summary>
        /// Kill Excel Process.
        /// </summary>
        /// <param name="ProcessName">This is path name of the process.</param>
        /// Input Parammeter name Changed
        /// Changed Access Modifier Public to Access the Method , out of the class
        public void KillExcelProcess(String ProcessName)
        {
            //Kill Excel Process
            Logger.LogMethodEntry("RptMainUXPage", "KillExcelProcess",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.StartsWith(ProcessName))
                    {
                        clsProcess.Kill();
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "KillExcelProcess",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get ClassName.
        /// </summary>
        /// <returns>Class name.</returns>
        public string GetClassName()
        {
            //Get ClassName
            Logger.LogMethodEntry("RptMainUXPage", "GetClassName",
                base.isTakeScreenShotDuringEntryExit);
            //Initializing getClassName Variable
            string getClassName = string.Empty;
            try
            {
                //Path of the Excel file need to saved
                string getExcelFilePathSaved = (AutomationConfigurationManager.TestDataPath +
               RptMainUXPageResource.RptMainUX_Page_AutoIT_ExeFilepath_Locator).
               Replace("file:\\", "");
                string[] PathName = getExcelFilePathSaved.Split(Convert.ToChar
                   (RptMainUXPageResource.RptMainUX_Page_ExcelSheet_Data_colan));
                //Array of string
                string getExcelFileDriveSaved = PathName[0];
                getExcelFileDriveSaved = getExcelFileDriveSaved + RptMainUXPageResource.
                    RptMainUX_Page_CustomReport_DownloadedFilepath_Locator;
                //Get Excelsheet File Path   
                string courseOptionsName = this.ReadCustomReportData(getExcelFileDriveSaved,
                   Convert.ToInt32(RptMainUXPageResource.RptMainUX_Page_ExcelSheet_PageNum),
                   Convert.ToInt32(RptMainUXPageResource.RptMainUX_Page_ExcelSheet_RowNum),
                   Convert.ToInt32(RptMainUXPageResource.RptMainUX_Page_ExcelSheet_ColNum));
                //Getting the colon index
                int colonindex = courseOptionsName.IndexOf(Convert.ToChar
                    (RptMainUXPageResource.RptMainUX_Page_ExcelSheet_Data_colan));
                //Getting the class name
                getClassName = courseOptionsName.Substring(colonindex + Convert.ToInt32
                    (RptMainUXPageResource.RptMainUX_Page_ExcelSheet_Data_Slash),
                    Convert.ToInt32
                    (RptMainUXPageResource.RptMainUX_Page_ExcelSheet_Data_Guid));
                //Delay time                
                Thread.Sleep(Convert.ToInt32(RptMainUXPageResource.
                    RptMain_Page_CustomReport_Cmenu_Window_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "GetClassName",
               base.isTakeScreenShotDuringEntryExit);
            return getClassName;
        }

        /// <summary>
        ///Delete Download Report.
        /// </summary>
        public void DeleteDownloadReport()
        {
            //Delete Download Report
            Logger.LogMethodEntry("RptMainUXPage", "DeleteDownloadReport",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Path of the Excel file need to saved
                string getExcelFilePathSaved = (Path.GetDirectoryName
                    (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) +
                    RptMainUXPageResource.RptMainUX_Page_AutoIT_ExeFilepath_Locator).
                    Replace("file:\\", "");
                string[] PathName = getExcelFilePathSaved.Split(Convert.ToChar
                   (RptMainUXPageResource.RptMainUX_Page_ExcelSheet_Data_colan));
                //Array of string
                string getExcelFileDriveSaved = PathName[0];
                getExcelFileDriveSaved = getExcelFileDriveSaved + RptMainUXPageResource.
                    RptMainUX_Page_CustomReport_DownloadedFilepath_Locator;
                //Delete the file
                File.Delete(getExcelFileDriveSaved);
                base.RefreshTheCurrentPage();
                //Select Report Frame
                this.SelectReportFrame();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "DeleteDownloadReport",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check Permissions Enabled in Reports
        /// </summary>
        /// <returns>Status of Permissions Enabled</returns>
        public bool IsPermissionsEnabledInReports()
        {
            //Check Permissions Enabled in Reports
            Logger.LogMethodEntry("RptMainUXPage", "IsPermissionsEnabledInReports",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool getEnabledOptionsStatus = false;
            string getReportText = string.Empty;
            try
            {
                //Select Reports Window and Frame
                this.SelectReportsWindowandFrame();
                base.WaitForElement(By.Id(RptMainUXPageResource.
                    RptMainUX_Page_CourseReports_Table_Id_Locator));
                //Get Reports Text
                getReportText = base.GetElementTextByID(RptMainUXPageResource.
                    RptMainUX_Page_CourseReports_Table_Id_Locator);
                //Get Status of Enabled Permissions Status in Report
                getEnabledOptionsStatus = getReportText.Contains(RptMainUXPageResource.
                    RptMainUX_Page_ActivityResults_Report_Value)
                    && getReportText.Contains(RptMainUXPageResource.
                    RptMainUX_Page_StudentResults_Report_Value) &&
                    getReportText.Contains(RptMainUXPageResource.
                    RptMainUX_Page_StudyPlanResult_Report_Value) &&
                    getReportText.Contains(RptMainUXPageResource.
                    RptMainUX_Page_QuestionAnalysis_Report_Value);
                base.SelectWindow(RptMainUXPageResource.
                    RptMainUX_Page_Report_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "IsPermissionsEnabledInReports",
           base.isTakeScreenShotDuringEntryExit);
            return getEnabledOptionsStatus;
        }

        /// <summary>
        /// Select Reports Window and Frame.
        /// </summary>
        public void SelectReportsWindowandFrame()
        {
            // Select Reports Window and Frame
            Logger.LogMethodEntry("RptMainUXPage", "SelectReportsWindowandFrame",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Reports Window    
                base.SelectWindow(RptMainUXPageResource.
                    RptMainUX_Page_Report_Window_Name);
                base.WaitForElement(By.Id(RptMainUXPageResource.
                    RptMain_Page_Frame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(RptMainUXPageResource.
                    RptMain_Page_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "SelectReportsWindowandFrame",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Study Plan Single Student Report.
        /// </summary>
        public void ClickOnStudyPlanSingleStudentReport()
        {
            // Click On Study Plan Single Student Report
            Logger.LogMethodEntry("RptMainUXPage", "ClickOnStudyPlanSingleStudentReport",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Reports Window and Frame
                this.SelectReportsWindowandFrame();
                base.WaitForElement(By.Id(RptMainUXPageResource.
                    RptMainUX_Page_StudyPlanSingleStudent_Link_Id_Locator));
                //Get Element Property
                IWebElement getStudyPlanReportLink =
                    base.GetWebElementPropertiesById(RptMainUXPageResource.
                    RptMainUX_Page_StudyPlanSingleStudent_Link_Id_Locator);
                //Click On Study Plan Single Student
                base.ClickByJavaScriptExecutor(getStudyPlanReportLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "ClickOnStudyPlanSingleStudentReport",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Report Name.
        /// </summary>
        /// <param name="reportName">This is Report Name.</param>
        /// <returns>Report Name.</returns>
        public String GetReportName(string reportName)
        {
            //Get Report Name
            Logger.LogMethodEntry("RptMainUXPage", "GetReportName",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getReportName = string.Empty;
            try
            {
                //Select Window And Frame
                this.SelectReportsWindowandFrame();
                base.WaitForElement(By.XPath(RptMainUXPageResource.
                    RptMainUX_Page_ReportCount_Xpath_Locator));
                //Get Report Count
                int getReportCount = base.GetElementCountByXPath(RptMainUXPageResource.
                    RptMainUX_Page_ReportCount_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(RptMainUXPageResource.
                    RptMainUX_Page_Loop_Initializer); rowCount <= getReportCount; rowCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(RptMainUXPageResource.
                        RptMainUX_Page_ReportName_Xpath_Locator, rowCount)));
                    //Get Report Name
                    getReportName = base.GetElementTextByXPath(string.Format(RptMainUXPageResource.
                        RptMainUX_Page_ReportName_Xpath_Locator, rowCount));
                    if (getReportName == reportName)
                    {
                        getReportName = reportName;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "GetReportName",
                    base.isTakeScreenShotDuringEntryExit);
            return getReportName;
        }

        /// <summary>
        /// Click On Report Type Link.
        /// </summary>
        /// <param name="reportTypeEnum">This is Report type Enum.</param>
        public void ClickOnReportTypeLink(PegasusInstructorReportEnum reportTypeEnum)
        {
            //Click On Report Type Link
            Logger.LogMethodEntry("RptMainUXPage", "ClickOnReportTypeLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window and Frame
                this.SelectReportsWindowandFrame();
                switch (reportTypeEnum)
                {
                    //Click On 'Training Frequency Analysis' Report Link
                    case RptMainUXPage.PegasusInstructorReportEnum.TrainingFrequencyAnalysis:
                        //Click The Training Frequency Analysis Report
                        this.ClickTheTrainingFrequencyAnalysisReport();
                        break;
                    case RptMainUXPage.PegasusInstructorReportEnum.ActivityResultsSingleStudent:
                        //Click The Activity Results Single Student Report
                        this.ClickTheActivityResultsSingleStudentReport();
                        break;
                    case RptMainUXPage.PegasusInstructorReportEnum.ExamFrequencyAnalysis:
                        //Click The Exam Frequency Analysis Report
                        this.ClickTheExamFrequencyAnalysisReport();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "ClickOnReportTypeLink",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Exam Frequency Analysis Report.
        /// </summary>
        private void ClickTheExamFrequencyAnalysisReport()
        {
            //Click The Exam Frequency Analysis Report
            Logger.LogMethodEntry("RptMainUXPage",
               "ClickTheExamFrequencyAnalysisReport",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMainUX_Page_ExamsFrequencyAnalysis_Link_Id_Locator));
            IWebElement getExamFrequencyAnalysisReport =
                base.GetWebElementPropertiesById
                (RptMainUXPageResource.
                RptMainUX_Page_ExamsFrequencyAnalysis_Link_Id_Locator);
            //Click On 'Exam Frequency Analysis' report Link
            base.ClickByJavaScriptExecutor(getExamFrequencyAnalysisReport);
            Logger.LogMethodExit("RptMainUXPage",
                "ClickTheExamFrequencyAnalysisReport",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Activity Results Single Student Report.
        /// </summary>
        private void ClickTheActivityResultsSingleStudentReport()
        {
            //Click The Activity Results Single Student Report
            Logger.LogMethodEntry("RptMainUXPage",
                "ClickTheActivityResultsSingleStudentReport",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMainUX_Page_ActivityResultSingleStudent_Link_Id_Locator));
            IWebElement getActivityResulyReport = base.GetWebElementPropertiesById
                (RptMainUXPageResource.
                RptMainUX_Page_ActivityResultSingleStudent_Link_Id_Locator);
            //Click On 'Activity Results for Single Student' report Link
            base.ClickByJavaScriptExecutor(getActivityResulyReport);
            Logger.LogMethodExit("RptMainUXPage",
                "ClickTheActivityResultsSingleStudentReport",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Training Frequency Analysis Report.
        /// </summary>
        private void ClickTheTrainingFrequencyAnalysisReport()
        {
            //Click The Training Frequency Analysis Report
            Logger.LogMethodEntry("RptMainUXPage",
                "ClickTheTrainingFrequencyAnalysisReport",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMainUX_Page_TrainingFrequencyAnalysis_Link_Id_Locator));
            IWebElement getTrainingFrequencyReport = base.GetWebElementPropertiesById
                (RptMainUXPageResource.
                RptMainUX_Page_TrainingFrequencyAnalysis_Link_Id_Locator);
            //Click On 'Training Frequency Analysis' Report Link
            base.ClickByJavaScriptExecutor(getTrainingFrequencyReport);
            Logger.LogMethodExit("RptMainUXPage",
                "ClickTheTrainingFrequencyAnalysisReport",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Certificate Type Link.
        /// </summary>
        /// <param name="certificateTypeEnum">This is Certificate Type Enum.</param>
        public void ClickOnCertificateTypeLink(
            PegasusInstructorCertificateTypeEnum certificateTypeEnum)
        {
            //Click On Certificate Type Link
            Logger.LogMethodEntry("RptMainUXPage", "ClickOnCertificateTypeLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window and Frame
                this.SelectReportsWindowandFrame();
                switch (certificateTypeEnum)
                {
                    //Click On 'Certificate of Completion(Training)' Certificate Link
                    case RptMainUXPage.PegasusInstructorCertificateTypeEnum.
                                               CertificateofCompletionTraining:
                        //Click The Certificate Of Completion Training
                        this.ClickTheCertificateCompletionTraining();
                        break;
                    //Click On 'Certificate of Completion(Exam)' Certificate Link
                    case RptMainUXPage.PegasusInstructorCertificateTypeEnum.
                                                     CertificateofCompletionExam:
                        //Click The Certificate Of Completion Exam
                        this.ClickTheCertificateCompletionExam();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "ClickOnCertificateTypeLink",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Certificate Of Completion Exam.
        /// </summary>
        private void ClickTheCertificateCompletionExam()
        {
            //Click The Certificate Of Completion Exam
            Logger.LogMethodEntry("RptMainUXPage", "ClickTheCertificateCompletionExam",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMain_Page_CertificateOfExam_Id_Locator));
            IWebElement getExamCertificateLink = base.GetWebElementPropertiesById
                (RptMainUXPageResource.RptMain_Page_CertificateOfExam_Id_Locator);
            //Click On 'Certificate of Completion(Exam)' Certificate Link
            base.ClickByJavaScriptExecutor(getExamCertificateLink);
            Logger.LogMethodExit("RptMainUXPage", "ClickTheCertificateCompletionExam",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Certificate Completion Training.
        /// </summary>
        private void ClickTheCertificateCompletionTraining()
        {
            //Click The Certificate Completion Training
            Logger.LogMethodEntry("RptMainUXPage",
                "ClickTheCertificateCompletionTraining",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMainUX_Page_CertificationofCompletionTraining_Link_Id_Locator));
            IWebElement getTrainingCertificateLink = base.GetWebElementPropertiesById
                (RptMainUXPageResource.
                RptMainUX_Page_CertificationofCompletionTraining_Link_Id_Locator);
            //Click On 'Certificate of Completion(Training)' Certificate Link
            base.ClickByJavaScriptExecutor(getTrainingCertificateLink);
            Logger.LogMethodExit("RptMainUXPage",
                "ClickTheCertificateCompletionTraining",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Data For Exam Frequency Analysis Report.
        /// </summary>
        public void ClickTheExamFrequencyAnalysisReportLink()
        {
            //Click The Data For Exam Frequency Analysis Report
            Logger.LogMethodEntry("RptMainUXPage",
                "ClickTheExamFrequencyAnalysisReportLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window and Frame
                this.SelectReportsWindowandFrame();
                //Wait for the element
                base.WaitForElement(By.Id(RptMainUXPageResource.
                    RptMainUX_Page_ExamsFrequency_MostRecent_Id_Locator));
                IWebElement getMostRecentButton = base.GetWebElementPropertiesById
                    (RptMainUXPageResource.
                    RptMainUX_Page_ExamsFrequency_MostRecent_Id_Locator);
                //Click the 'Most Recent' Radio button
                base.ClickByJavaScriptExecutor(getMostRecentButton);
                //Click The Select Exams
                this.ClickTheSelectExams();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage",
                "ClickTheExamFrequencyAnalysisReportLink",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Select Exams.
        /// </summary>
        private void ClickTheSelectExams()
        {
            //Click The Select Exams
            Logger.LogMethodEntry("RptMainUXPage", "ClickTheSelectExams",
                 base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMainUX_Page_SelectExam_Button_Id_Locator));
            IWebElement getSelectExamsButton = base.GetWebElementPropertiesById
                (RptMainUXPageResource.
                RptMainUX_Page_SelectExam_Button_Id_Locator);
            //Click the 'Select Exams' button
            base.ClickByJavaScriptExecutor(getSelectExamsButton);
            Logger.LogMethodExit("RptMainUXPage", "ClickTheSelectExams",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Generate Instructor Reports by Types.
        /// </summary>
        /// <param name="pegasusInstructorReportEnum">This is Report Type Enum.</param>
        /// <param name="userName">This is User Lats Name.</param>
        /// <param name="activityName">This is Writingspace Activity.</param>
        public void GenerateInstructorReport(
            PegasusInstructorReportEnum pegasusInstructorReportEnum,
            string userLastName, string activityName)
        {
            //Generate Instructor Reports by Types
            Logger.LogMethodEntry("RptMainUXPage", "GenerateInstructorReport",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (pegasusInstructorReportEnum)
                {
                    //Generate Activity Result by Student Report
                    case RptMainUXPage.PegasusInstructorReportEnum.ActivityResultsbyStudent:  
                        //Select Activity
                        this.SelectActivityInReport(activityName);
                        //Select Student
                        this.SelectStudent(userLastName);
                        //Select Window
                        new CourseHomeListItemViewPage().SelectCourseHomeWindow();
                        //Click on Run Report
                        new RptGCOptionsUXPage().ClickonGenerateReport();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("RptMainUXPage", "GenerateInstructorReport",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student.
        /// </summary>
        /// <param name="userLastName">This is User Last Name.</param>
        private void SelectStudent(string userLastName)
        {
            //Select Student
            Logger.LogMethodEntry("RptMainUXPage", "SelectStudent",
               base.isTakeScreenShotDuringEntryExit);
            new CourseHomeListItemViewPage().SelectCourseHomeWindow();
            new RptGCOptionsUXPage().ClickonSelectStudent();
            base.SwitchToLastOpenedWindow();
            new RptSelectStudentsPage().SelectStudentToGenerateReport(userLastName);
            //Click on Add Button
            this.ClickonAddButton();
            Logger.LogMethodEntry("RptMainUXPage", "SelectStudent",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void SelectActivityInReport(string activityName)
        {
            //Select Activity
            Logger.LogMethodEntry("RptMainUXPage", "SelectActivityInReport",
               base.isTakeScreenShotDuringEntryExit);
            //Select Window
            new CourseHomeListItemViewPage().SelectCourseHomeWindow();
            //Click on Activity Result By Student Report Link
            this.ClickonActivityResultByStudentReportLink();
            //Click on Select Activity
            new RptGCOptionsUXPage().ClickonSelectActivity();
            new RptSelectAssessmentsPage().
                SelectWtritingspaceActivityToGenerateReport(activityName);
            Logger.LogMethodEntry("RptMainUXPage", "SelectActivityInReport",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Button.
        /// </summary>
        private void ClickonAddButton()
        {
            //Click on Add Button
            Logger.LogMethodEntry("RptMainUXPage", "ClickonAddButton",
              base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(RptSelectStudentsResource.
                  RptSelectStudents_Page_Ins_AddLinkText_Locator));
            //Click on Add Button 
            base.ClickButtonByPartialLinkText(RptSelectStudentsResource.
                RptSelectStudents_Page_Ins_AddLinkText_Locator);
            //Check If Window is Close
            base.IsPopUpClosed(Convert.ToInt32(RptSelectStudentsResource.
                RptSelectStudents_Page_Ins_Window_Count));
            Logger.LogMethodEntry("RptMainUXPage", "ClickonAddButton",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}

