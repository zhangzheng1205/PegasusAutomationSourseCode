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
using Pegasus.Automation.DataTransferObjects;

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
        private static readonly Logger Logger =
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
               base.IsTakeScreenShotDuringEntryExit);
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
                    case RptMainUXPage.PegasusInstructorReportEnum.StudyPlanResults:
                        this.StudyPlanResultsReport(reportTypeEnum);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "ManageInstructorReport",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        ///Select Mastery Report link.
        /// </summary>
        public void ClickTheMasteryReportsLink(PegasusInstructorReportEnum reportTypeEnum)
        {
            Logger.LogMethodEntry("RptMainUXPage", "ClickTheInstructorReportsLink",
                base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Generate Mastery Reports.
        /// </summary>
        public String GenerateMasteryReportForSkill(PegasusInstructorReportEnum reportTypeEnum,
            string skillName)
        {
            Logger.LogMethodEntry("RptMainUXPage", "GenerateMasteryReportForSkill",
                base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
            return skillName;
        }

        /// <summary>
        ///Generate Class Mastery Report.
        /// </summary>
        private string GenerateClassMasteryReport(String skillName)
        {
            //Select The Student Activity Report
            Logger.LogMethodEntry("RptMainUXPage", "GenerateClassMasteryReport",
               base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("RptMainUXPage", "GenerateClassMasteryReport",
               base.IsTakeScreenShotDuringEntryExit);
            return skillName;
        }

        /// <summary>
        ///Generate Student Mastery Report.
        /// </summary>
        private string GenerateStudentMasteryReport(String skillName)
        {
            //Select The Student Activity Report
            Logger.LogMethodEntry("RptMainUXPage", "GenerateStudentMasteryReport",
               base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("RptMainUXPage", "GenerateStudentMasteryReport",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Click The Student Activity Link
            new RptStudentActivityPage().ClickTheStudentActivityLink();
            //Select The Students From LightBox
            new RptCommonCriteriaPage().SelectTheStudentsFromLightBox(userType);
            //Click Run Report
            new RptCommonCriteriaPage().ClickRunReport();
            Logger.LogMethodEntry("RptMainUXPage",
                "SelectStudentActivityReport",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Select Activity Result by Student Report
            this.SelectReport();
            //Select the Activity
            new RptGCOptionsUXPage().SelectActivity();
            //Select the Student
            new RptGCOptionsUXPage().SelectStudent(reportTypeEnum);
            //Generate the Activity Result By Student Report
            new RptGCOptionsUXPage().GenerateReport();
            Logger.LogMethodExit("InstructorReports", "ActivityResultbyStudentReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting Activity Result By Student Report.
        /// </summary>
        public void SelectReport()
        {
            //Select Activity Result by Student type Report
            Logger.LogMethodEntry("RptMainUXPage", "SelectReport",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Activity Result By Student Report Link.
        /// </summary>
        private void ClickonActivityResultByStudentReportLink()
        {
            //Click on Activity Result By Student Report Link
            Logger.LogMethodEntry("RptMainUXPage", "ClickonActivityResultByStudentReportLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Frame
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMain_Page_MainFrame_Id_Locator));
            base.SwitchToIFrame(RptMainUXPageResource.
                RptMain_Page_MainFrame_Id_Locator);
            //Select Activity Result By Student Report
            base.WaitForElement(By.XPath(RptMainUXPageResource.
                RptMainUX_Page_Report_Xpath_Locator));
            base.ClickButtonByXPath(RptMainUXPageResource.
                RptMainUX_Page_Report_Xpath_Locator);
            Logger.LogMethodExit("RptMainUXPage", "ClickonActivityResultByStudentReportLink",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student Results By Activity Report.
        /// </summary>
        private void SelectStudentResultByActivityReport()
        {
            //Select Student Results By Activity Report
            Logger.LogMethodEntry("RptMainUXPage",
                "SelectStudentResultByActivityReport",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Reports Window    
            base.SelectWindow(RptMainUXPageResource.
                RptMainUX_Page_Report_Window_Name);
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMain_Page_MainFrame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(RptMainUXPageResource.
                RptMain_Page_MainFrame_Id_Locator);
            base.WaitForElement(By.XPath(RptMainUXPageResource.
                RptMainUX_Page_StudentResultByActivityReport_Xpath_Locator));
            base.FocusOnElementByXPath(RptMainUXPageResource.
                RptMainUX_Page_StudentResultByActivityReport_Xpath_Locator);
            //Click On Student Result By Activity Report
            base.ClickButtonByXPath(RptMainUXPageResource.
                RptMainUX_Page_StudentResultByActivityReport_Xpath_Locator);
            Logger.LogMethodExit("RptMainUXPage", "SelectStudentResultByActivityReport",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Generate Study Plan results Type Report.
        /// </summary>
        /// <param name="reportTypeEnum">This is Report Type Enum.</param>
        private void StudyPlanResultsReport(
            PegasusInstructorReportEnum reportTypeEnum)
        {
            Logger.LogMethodEntry("RptMainUXPage", "StudyPlanResultsReport",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Study Plan Results Report Link
            this.SelectStudyPlanResultsReport();
            //Select the Study Plan 
            new RptSelectAssessmentsPage().SelectStudyPlanInStudyPlanResultsReport(
                RptMainUXPageResource.RptMainUX_Page_Ins_StudyPlan_Name);
            //Select the Student
            new RptGCOptionsUXPage().SelectStudentInStudyPlanResultsReport(reportTypeEnum);
            //Generate the Report
            new RptGCOptionsUXPage().GenerateReport();
            Logger.LogMethodExit("RptMainUXPage", "StudyPlanResultsReport",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Study Plan Results Report.
        /// </summary>
        private void SelectStudyPlanResultsReport()
        {
            Logger.LogMethodEntry("RptMainUXPage",
                "SelectStudyPlanResultsReport",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Reports Window    
            base.SelectWindow(RptMainUXPageResource.
                RptMainUX_Page_Report_Window_Name);
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMain_Page_MainFrame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(RptMainUXPageResource.
                RptMain_Page_MainFrame_Id_Locator);
            base.WaitForElement(By.XPath(RptMainUXPageResource.
                RptMainUX_Page_StudyPlanReport_Xpath_Locator));
            base.FocusOnElementByXPath(RptMainUXPageResource.
                RptMainUX_Page_StudyPlanReport_Xpath_Locator);
            //Click On Study Plan Results Report link
            base.ClickButtonByXPath(RptMainUXPageResource.
                RptMainUX_Page_StudyPlanReport_Xpath_Locator);
            Logger.LogMethodExit("RptMainUXPage", "SelectStudyPlanResultsReport",
              base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Report Frame.
        /// </summary>
        private void SelectReportFrame()
        {
            //Select Report Frame
            Logger.LogMethodEntry("RptMainUXPage", "SelectReportFrame",
             base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Custom Report In Organization Admin.
        /// </summary>
        private void SelectCustomReportInOrgnizationAdmin()
        {
            //Select Custom Report In Organization Admin              
            Logger.LogMethodEntry("RptMainUXPage",
                "SelectCustomReportInOrgnizationAdmin",
            base.IsTakeScreenShotDuringEntryExit);
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
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Ok Button.
        /// </summary>
        private void ClickTheOkButton()
        {
            // Click The Ok Button
            Logger.LogMethodEntry("RptMainUXPage", "ClickTheOkButton",
            base.IsTakeScreenShotDuringEntryExit);
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
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Custom Frame.
        /// </summary>
        public void SelectCustomFrame()
        {
            //Select Custom Frame
            Logger.LogMethodEntry("RptMainUXPage", "SelectCustomFrame",
            base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// //Select Download Report Option. 
        /// </summary>
        public void SelectDownloadReportOption()
        {
            //Select Download Report Option
            Logger.LogMethodEntry("RptMainUXPage", "SelectDownloadReportOption",
           base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
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
           base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
            return getDataFromSheet;
        }

        /// <summary>
        /// Kill Excel Process.
        /// </summary>
        /// <param name="processName">This is path name of the process.</param>
        /// Input Parammeter name Changed
        /// Changed Access Modifier Public to Access the Method , out of the class
        public void KillExcelProcess(String processName)
        {
            //Kill Excel Process
            Logger.LogMethodEntry("RptMainUXPage", "KillExcelProcess",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.StartsWith(processName))
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
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get ClassName.
        /// </summary>
        /// <returns>Class name.</returns>
        public string GetClassName()
        {
            //Get ClassName
            Logger.LogMethodEntry("RptMainUXPage", "GetClassName",
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            return getClassName;
        }

        /// <summary>
        ///Delete Download Report.
        /// </summary>
        public void DeleteDownloadReport()
        {
            //Delete Download Report
            Logger.LogMethodEntry("RptMainUXPage", "DeleteDownloadReport",
                base.IsTakeScreenShotDuringEntryExit);
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
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check Permissions Enabled in Reports
        /// </summary>
        /// <returns>Status of Permissions Enabled</returns>
        public bool IsPermissionsEnabledInReports()
        {
            //Check Permissions Enabled in Reports
            Logger.LogMethodEntry("RptMainUXPage", "IsPermissionsEnabledInReports",
                base.IsTakeScreenShotDuringEntryExit);
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
                getReportText = base.GetElementTextById(RptMainUXPageResource.
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
           base.IsTakeScreenShotDuringEntryExit);
            return getEnabledOptionsStatus;
        }

        /// <summary>
        /// Select Reports Window and Frame.
        /// </summary>
        public void SelectReportsWindowandFrame()
        {
            // Select Reports Window and Frame
            Logger.LogMethodEntry("RptMainUXPage", "SelectReportsWindowandFrame",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Reports Window    
                base.SelectWindow(RptMainUXPageResource.
                    RptMainUX_Page_Report_Window_Name);
                base.WaitForElement(By.Id(RptMainUXPageResource.
                    RptMain_Page_MainFrame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(RptMainUXPageResource.
                    RptMain_Page_MainFrame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "SelectReportsWindowandFrame",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Study Plan Single Student Report.
        /// </summary>
        public void ClickOnStudyPlanSingleStudentReport()
        {
            // Click On Study Plan Single Student Report
            Logger.LogMethodEntry("RptMainUXPage", "ClickOnStudyPlanSingleStudentReport",
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Exam Frequency Analysis Report.
        /// </summary>
        private void ClickTheExamFrequencyAnalysisReport()
        {
            //Click The Exam Frequency Analysis Report
            Logger.LogMethodEntry("RptMainUXPage",
               "ClickTheExamFrequencyAnalysisReport",
               base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Activity Results Single Student Report.
        /// </summary>
        private void ClickTheActivityResultsSingleStudentReport()
        {
            //Click The Activity Results Single Student Report
            Logger.LogMethodEntry("RptMainUXPage",
                "ClickTheActivityResultsSingleStudentReport",
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Training Frequency Analysis Report.
        /// </summary>
        private void ClickTheTrainingFrequencyAnalysisReport()
        {
            //Click The Training Frequency Analysis Report
            Logger.LogMethodEntry("RptMainUXPage",
                "ClickTheTrainingFrequencyAnalysisReport",
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Certificate Of Completion Exam.
        /// </summary>
        private void ClickTheCertificateCompletionExam()
        {
            //Click The Certificate Of Completion Exam
            Logger.LogMethodEntry("RptMainUXPage", "ClickTheCertificateCompletionExam",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMain_Page_CertificateOfExam_Id_Locator));
            IWebElement getExamCertificateLink = base.GetWebElementPropertiesById
                (RptMainUXPageResource.RptMain_Page_CertificateOfExam_Id_Locator);
            //Click On 'Certificate of Completion(Exam)' Certificate Link
            base.ClickByJavaScriptExecutor(getExamCertificateLink);
            Logger.LogMethodExit("RptMainUXPage", "ClickTheCertificateCompletionExam",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Certificate Completion Training.
        /// </summary>
        private void ClickTheCertificateCompletionTraining()
        {
            //Click The Certificate Completion Training
            Logger.LogMethodEntry("RptMainUXPage",
                "ClickTheCertificateCompletionTraining",
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Data For Exam Frequency Analysis Report.
        /// </summary>
        public void ClickTheExamFrequencyAnalysisReportLink()
        {
            //Click The Data For Exam Frequency Analysis Report
            Logger.LogMethodEntry("RptMainUXPage",
                "ClickTheExamFrequencyAnalysisReportLink",
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Select Exams.
        /// </summary>
        private void ClickTheSelectExams()
        {
            //Click The Select Exams
            Logger.LogMethodEntry("RptMainUXPage", "ClickTheSelectExams",
                 base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMainUX_Page_SelectExam_Button_Id_Locator));
            IWebElement getSelectExamsButton = base.GetWebElementPropertiesById
                (RptMainUXPageResource.
                RptMainUX_Page_SelectExam_Button_Id_Locator);
            //Click the 'Select Exams' button
            base.ClickByJavaScriptExecutor(getSelectExamsButton);
            Logger.LogMethodExit("RptMainUXPage", "ClickTheSelectExams",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Generate Instructor Reports by Types.
        /// </summary>
        /// <param name="pegasusInstructorReportEnum">This is Report Type Enum.</param>
        /// <param name="userLastName">This is User Lats Name.</param>
        /// <param name="activityName">This is Writingspace Activity.</param>
        public void GenerateInstructorReport(
            PegasusInstructorReportEnum pegasusInstructorReportEnum,
            string userLastName, string activityName)
        {
            //Generate Instructor Reports by Types
            Logger.LogMethodEntry("RptMainUXPage", "GenerateInstructorReport",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on 'Select Activity' and switch to 'Select Activities' window.
        /// </summary>
        /// /// <param name="assesmentName">This is the assessment to be selected.</param>
        public void SelectSingleActivity(string assesmentName)
        {
            // Click on 'Select Activity' and switch to 'Select Activities' window
            Logger.LogMethodEntry("RptMainUXPageResource", "SelectSingleActivity",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath(RptMainUXPageResource.
                    RptMainUX_Page_SelectActivity_Button_Xpath_Locator));
                IWebElement getButton = base.GetWebElementPropertiesByXPath(
                    RptMainUXPageResource.
                    RptMainUX_Page_SelectActivity_Button_Xpath_Locator);
                //Click assesment button
                base.ClickByJavaScriptExecutor(getButton);
                //Switch to window
                base.WaitUntilWindowLoads(RptMainUXPageResource.
                    RptMainUX_Page_SelectActivities_Window_Title_Value);
                base.SelectWindow(RptMainUXPageResource.
                    RptMainUX_Page_SelectActivities_Window_Title_Value);
                AddAssessment(assesmentName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPageResource", "SelectSingleActivity",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student.
        /// </summary>
        /// <param name="userLastName">This is User Last Name.</param>
        private void SelectStudent(string userLastName)
        {
            //Select Student
            Logger.LogMethodEntry("RptMainUXPage", "SelectStudent",
               base.IsTakeScreenShotDuringEntryExit);
            new CourseHomeListItemViewPage().SelectCourseHomeWindow();
            new RptGCOptionsUXPage().ClickonSelectStudent();
            base.SwitchToLastOpenedWindow();
            new RptSelectStudentsPage().SelectStudentToGenerateReport(userLastName);
            //Click on Add Button
            this.ClickonAddButton();
            Logger.LogMethodEntry("RptMainUXPage", "SelectStudent",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void SelectActivityInReport(string activityName)
        {
            //Select Activity
            Logger.LogMethodEntry("RptMainUXPage", "SelectActivityInReport",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            new CourseHomeListItemViewPage().SelectCourseHomeWindow();
            //Click on Activity Result By Student Report Link
            this.ClickonActivityResultByStudentReportLink();
            //Click on Select Activity
            new RptGCOptionsUXPage().ClickonSelectActivity();
            new RptSelectAssessmentsPage().
                SelectWtritingspaceActivityToGenerateReport(activityName);
            Logger.LogMethodEntry("RptMainUXPage", "SelectActivityInReport",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Button.
        /// </summary>
        private void ClickonAddButton()
        {
            //Click on Add Button
            Logger.LogMethodEntry("RptMainUXPage", "ClickonAddButton",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(RptSelectStudentsResource.
                  RptSelectStudents_Page_Ins_AddLinkText_Locator));
            //Click on Add Button 
            base.ClickButtonByPartialLinkText(RptSelectStudentsResource.
                RptSelectStudents_Page_Ins_AddLinkText_Locator);
            //Check If Window is Close
            base.IsPopUpClosed(Convert.ToInt32(RptSelectStudentsResource.
                RptSelectStudents_Page_Ins_Window_Count));
            Logger.LogMethodEntry("RptMainUXPage", "ClickonAddButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on a report link based on instructor.
        /// </summary>
        /// <param name="reportType">This is the report type.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        public void ClickTheReportLink(string reportType, User.UserTypeEnum userTypeEnum)
        {
            // Click on a report link based on instructor
            Logger.LogMethodEntry("RptMainUXPage", "ClickTheReportLink",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userTypeEnum)
                {
                    //Click on a report link if instructor is 'Program Admin'
                    case User.UserTypeEnum.HedProgramAdmin:
                        new ProgramAdminReportsSubTabPage().ClickOnReportLink(reportType);
                        break;
                    //Click on a report link if instructor is 'SMS Instructor'
                    case User.UserTypeEnum.CsSmsInstructor:
                        this.SwitchToReportsWindow();
                        //Switch to 'Reports' page 'Mainframe' iframe
                        this.SwitchToMainFrame();
                        switch (reportType)
                        {
                            case "Activity Result (Multiple students and activities)":
                                //Click 'Activity Result (Multiple students and activities)' report link
                                this.ClickReportLink(RptMainUXPageResource.
                                RptMainUX_Page_ActivityResultMultipleStudentsAndActivities_Link_Id_Locator);
                                break;
                            case "Exam Frequency Analysis":
                                //Click 'Exam Frequency Analysis' report link
                                this.ClickReportLink(RptMainUXPageResource.
                                    RptMainUX_Page_ExamFrequencyAnalysis_Link_Id_Locator);
                                break;
                            case "Training Frequency Analysis":
                                //Click 'Training Frequency Analysis' report link
                                this.ClickReportLink(RptMainUXPageResource.
                                    RptMainUX_Page_TrainingFrequencyAnalysis_Link_Id_Locator);
                                break;
                            case "Activity Results (Multiple Students)":
                                //Click 'Activity Results (Multiple Students)' report link
                                this.ClickReportLink(RptMainUXPageResource.
                                   RptMainUX_Page_ActivityResultMultipleStudents_Link_Id_Locator);
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "ClickTheReportLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        ///<summary>
        ///Click on the report link.
        ///<summary>
        /// <param name="linkId">This is the Id locator of the link.</param>
        public void ClickReportLink(String linkId)
        {
            //Click on the report link
            Logger.LogMethodEntry("RptMainUXPage", "ClickReportLink",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement getReportLink = base.GetWebElementPropertiesById
                    (linkId);
                //Click on the report link
                base.ClickByJavaScriptExecutor(getReportLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "ClickReportLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Perform 'Run Report' or 'Edit Settings' or 'Delete' at 'My reports' based on user.
        /// </summary>
        /// <param name="reportActionOption">This is action to be performed on report.</param>
        /// <param name="reportTypeEnum">This is report name enum.</param>
        /// <param name="userTypeEnum">This is user type enum.</param>
        public void PerformActionOnMyReports(string reportActionOption,
            Report.ReportTypeEnum reportTypeEnum,
           User.UserTypeEnum userTypeEnum)
        {
            // Perform 'Run Report' or 'Edit Settings' or 'Delete' at 'My reports' based on user.
            Logger.LogMethodEntry("RptMainUXPage", "PerformActionOnMyReports",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userTypeEnum)
                {
                    //Switch to this case when user is 'Program Admin'
                    case User.UserTypeEnum.HedProgramAdmin:
                    case User.UserTypeEnum.HSSProgramAdmin:
                        new ProgramAdminReportsSubTabPage().MyReportsActions
                            (reportActionOption, reportTypeEnum);
                        break;
                    //Switch to this case when user is 'SMS Instructor' or 'Section Instructor'
                    case User.UserTypeEnum.CsSmsInstructor:
                    case User.UserTypeEnum.HSSCsSmsInstructor:
                        this.SwitchToReportsWindow();
                        //Switch to 'Reports' page 'Mainframe' iframe
                        this.SwitchToMainFrame();
                        switch (reportActionOption)
                        {
                            //Perform 'Run Report' on selected report
                            case "Run Report": this.ClickReportCMenu(reportTypeEnum);
                                this.SelectTheReportCmenuOptions(RptMainUXPageResource.
                                    RptmainUX_Page_MyReports_ReportCmenuRunReport_Id_Locator);
                                break;
                            //Perform 'Edit Settings' on selected report
                            case "Edit Settings": this.ClickReportCMenu(reportTypeEnum);
                                this.SelectTheReportCmenuOptions(RptMainUXPageResource.
                                    RptmainUX_Page_MyReports_ReportCmenuEditSettings_Id_Locator);
                                break;
                            //Perform 'Delete' on selected report
                            case "Delete": this.ClickReportCMenu(reportTypeEnum);
                                this.SelectTheReportCmenuOptions(RptMainUXPageResource.
                                    RptmainUX_Page_MyReports_ReportCmenuDelete_Id_Locator);
                                break;
                        }
                        break;

                    case User.UserTypeEnum.DPCsTeacher:
                        switch (reportActionOption)
                        {
                            //Perform 'Run Report' on selected report
                            case "Run Report": this.ClickReportCMenu(reportTypeEnum);
                                this.SelectTheReportCmenuOptions(RptMainUXPageResource.
                                    RptmainUX_Page_MyReports_ReportCmenuRunReport_Id_Locator);
                                break;
                            //Perform 'Edit Settings' on selected report
                            case "Edit Settings": this.ClickReportCMenu(reportTypeEnum);
                                this.SelectTheReportCmenuOptions(RptMainUXPageResource.
                                    RptmainUX_Page_MyReports_ReportCmenuEditSettings_Id_Locator);
                                break;
                            //Perform 'Delete' on selected report
                            case "Delete": this.ClickReportCMenu(reportTypeEnum);
                                this.SelectTheReportCmenuOptions(RptMainUXPageResource.
                                    RptmainUX_Page_MyReports_ReportCmenuDelete_Id_Locator);
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "PerformActionOnMyReports",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Report Cmenu Options.
        /// </summary>
        /// <param name="selectElementId">This is attribute ID locator.</param>
        private void SelectTheReportCmenuOptions(string selectElementId)
        {
            //Select The Report Cmenu Options
            Logger.LogMethodEntry("RptMainUXPage", "SelectTheReportCmenuOptions",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(selectElementId));
            IWebElement getCmenuRunReport = base.GetWebElementPropertiesById
                (selectElementId);
            //Click on cmenu of the asset
            base.ClickByJavaScriptExecutor(getCmenuRunReport);
            Logger.LogMethodExit("RptMainUXPage", "SelectTheReportCmenuOptions",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on 'C menu' of a selected report in 'My Reports'.
        /// </summary>
        /// <param name="reportTypeEnum">This is report type enum.</param>
        public void ClickReportCMenu(Report.ReportTypeEnum reportTypeEnum)
        {
            // Click on 'C menu' of a selected report in 'My Reports'
            Logger.LogMethodEntry("RptMainUXPage", "ClickReportCMenu",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getSearchedReportName = string.Empty;
                base.WaitForElement(By.XPath(RptMainUXPageResource.
                    RptMainUX_Page_MyReportsCount_Xpath_Locator));
                //Get count of the reports listed under 'My Reports'
                int getActivityCount = base.GetElementCountByXPath(RptMainUXPageResource.
                    RptMainUX_Page_MyReportsCount_Xpath_Locator);
                int initialCountResource = 1;
                string actualMyReportName = string.Empty,
                cmenu = RptMainUXPageResource.RptmainUX_Page_MyReports_ActualReportCmenu_Xpath_Locator,
                reportName = RptMainUXPageResource.RptMainUX_Page_MyReports_ActualReport_Xpath_Locator;

                Report report = Report.Get(reportTypeEnum);
                actualMyReportName = report.Name;

                if (reportTypeEnum == Report.ReportTypeEnum.HSSStudentResultsbyActivity ||
                   reportTypeEnum == Report.ReportTypeEnum.HSSActivityResultsByStudent ||
                   reportTypeEnum == Report.ReportTypeEnum.HSSStudytPlanResults || reportTypeEnum == Report.ReportTypeEnum.DPActivityResultsByStudent)
                {
                    cmenu = RptMainUXPageResource.RptmainUX_Page_MyReports_ActualReportCmenu_Xpath_Locator2;
                    reportName = RptMainUXPageResource.RptMainUX_Page_MyReports_ActualReport_Xpath_Locator2;
                }

                //Search for expected report 
                for (int initialCount = initialCountResource;
                    initialCount <= getActivityCount; initialCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(reportName, initialCount)));
                    getSearchedReportName = base.GetElementTextByXPath(string.Format(reportName, initialCount));


                    //Click on 'C menu' of expected report
                    if (getSearchedReportName == actualMyReportName)
                    {
                        base.WaitForElement(By.XPath(string.Format(cmenu, initialCount)));
                        IWebElement getCmenu = base.GetWebElementPropertiesByXPath((string.Format(cmenu, initialCount)));
                        //Click on cmenu of the asset
                        base.ClickByJavaScriptExecutor(getCmenu);
                        Thread.Sleep(1000);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "ClickReportCMenu",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click 'Select Students' button and check 'Select All' at Students Option based on instructor.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        public void SelectAllStudent(User.UserTypeEnum userTypeEnum)
        {
            // Click 'Select Students' button and check 'Select All' at Students Option
            Logger.LogMethodEntry("RptMainUXPage", "SelectAllStudent",
              base.IsTakeScreenShotDuringEntryExit);
            IWebElement selectStudent;
            try
            {
                switch (userTypeEnum)
                {
                    //Switch to this case when user is 'Program Admin'
                    case User.UserTypeEnum.HedProgramAdmin:
                    case User.UserTypeEnum.HSSProgramAdmin:
                        new ProgramAdminReportsSubTabPage().SelectAllStudentsProgramAdmin();
                        break;
                    //Switch to this case when user is 'SMS Instructor'
                    case User.UserTypeEnum.CsSmsInstructor:
                    case User.UserTypeEnum.HSSCsSmsInstructor:
                        this.SwitchToReportsWindow();
                        //Switch to 'Reports' page 'Mainframe' iframe
                        this.SwitchToMainFrame();
                        base.WaitForElement(By.XPath(RptMainUXPageResource.
                            RptMainUX_Page_SelectStudentds_Button_Xpath_Locator));
                        //Click 'Select Students' button
                         selectStudent = base.GetWebElementPropertiesByXPath(
                            RptMainUXPageResource.
                            RptMainUX_Page_SelectStudentds_Button_Xpath_Locator);
                        base.ClickByJavaScriptExecutor(selectStudent);
                        //check 'Select All' at Students Option
                        new RptSelectStudentsPage().CheckSelectAll();
                        break;
                    case User.UserTypeEnum.DPCsTeacher:
                        //Switch to 'Reports' page 'Mainframe' iframe
                        base.SwitchToIFrameById("frmCourseContainer");
                        this.SwitchToMainFrame();
                        base.WaitForElement(By.XPath(RptMainUXPageResource.
                            RptMainUX_Page_SelectStudentds_Button_Xpath_Locator),5);
                        //Click 'Select Students' button
                         selectStudent = base.GetWebElementPropertiesByXPath(
                            RptMainUXPageResource.
                            RptMainUX_Page_SelectStudentds_Button_Xpath_Locator);
                        base.ClickByJavaScriptExecutor(selectStudent);
                        //check 'Select All' at Students Option
                        new RptSelectStudentsPage().CheckSelectAll();
                        break;
                }
                this.ClickAddButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            base.SwitchToDefaultWindow();
            Logger.LogMethodExit("RptMainUXPage", "SelectAllStudent",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// /// <summary>
        /// Switch to 'Reports' window.
        /// </summary>
        private void SwitchToReportsWindow()
        {
            Logger.LogMethodEntry("RptMainUXPage", "SwitchToReportsWindow",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(RptMainUXPageResource.RptMainUX_Page_Report_Window_Name);
            base.SelectWindow(RptMainUXPageResource.RptMainUX_Page_Report_Window_Name);
            Logger.LogMethodExit("RptMainUXPage", "SwitchToReportsWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to 'Mainframe' iframe.
        /// </summary>
        private void SwitchToMainFrame()
        {
            Logger.LogMethodEntry("RptMainUXPage", "SwitchToMainFrame",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(RptMainUXPageResource.
               RptMain_Page_MainFrame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrameById(RptMainUXPageResource.
                RptMain_Page_MainFrame_Id_Locator);
            Logger.LogMethodExit("RptMainUXPage", "SwitchToMainFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checks the 'Save Settings To My Reports' based on instructor.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        public void SaveSettingsToMyReportCheckByUser(User.UserTypeEnum userTypeEnum)
        {
            // Checks the 'Save Settings To My Reports' based on instructor
            Logger.LogMethodEntry("RptMainUXPage", "SaveSettingsToMyReportCheckByUser",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userTypeEnum)
                {
                    //Switch to this case when user is 'Program Admin'
                    case User.UserTypeEnum.HedProgramAdmin:
                        new ProgramAdminReportsSubTabPage().CheckSaveSettingsToMyReport();
                        break;
                    //Switch to this case when user is 'SMS Instructor'
                    case User.UserTypeEnum.CsSmsInstructor:
                    case User.UserTypeEnum.HSSCsSmsInstructor:
                        this.SwitchToReportsWindow();
                        //Switch to 'Reports' page 'Mainframe' iframe
                        this.SwitchToMainFrame();
                        //Check the checkbox
                        this.SelectCheckBoxSaveSettingsToMyReport();
                        break;
                    //Switch to this case when user is 'DP teacher'
                    case User.UserTypeEnum.DPCsTeacher:
                        //Switch to 'Reports' page iframe
                        base.SwitchToIFrameById(RptMainUXPageResource.
                            RptMainUXPage_ContainerFrame_Id_Locator);
                        this.SwitchToMainFrame();
                        //Check the checkbox
                        this.SelectCheckBoxSaveSettingsToMyReport();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "SaveSettingsToMyReportCheckByUser",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Checks the 'Save Settings To My Reports' checkbox.
        /// </summary>
        private void SelectCheckBoxSaveSettingsToMyReport()
        {
            //  Checks the 'Save Settings To My Reports' checkbox.
            Logger.LogMethodEntry("RptMainUXPage", "SelectCheckBoxSaveSettingsToMyReport",
            base.IsTakeScreenShotDuringEntryExit);
            base.FocusOnElementById(RptMainUXPageResource.
                RptMainUX_Page_SaveSettingsToMyReport_Checkbox_Id_Locator);
            base.WaitForElement(By.Id(RptMainUXPageResource.
                RptMainUX_Page_SaveSettingsToMyReport_Checkbox_Id_Locator));
            //Checks the checkbox
            base.SelectCheckBoxById(RptMainUXPageResource.
                RptMainUX_Page_SaveSettingsToMyReport_Checkbox_Id_Locator);
            Logger.LogMethodExit("RptMainUXPage", "SelectCheckBoxSaveSettingsToMyReport",
               base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Click buttons in criteria page base on instructor.
        /// </summary>
        /// <param name="buttonName">This is the button to be clicked.</param>
        /// <param name="userTypeEnum">This is user type enum.</param>
        public void ClickButtonInReportByUser(string buttonName,
            User.UserTypeEnum userTypeEnum)
        {
            // Click buttons in criteria page base on instructor
            Logger.LogMethodEntry("RptMainUXPage", "ClickButtonInReportByUser",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userTypeEnum)
                {
                    //Switch to this case when user is 'Program Admin'
                    case User.UserTypeEnum.HedProgramAdmin:
                        new ProgramAdminReportsSubTabPage().ClickButtonInReports(buttonName);
                        break;
                    //Switch to this case when user is 'SMS Instructor'
                    case User.UserTypeEnum.CsSmsInstructor:
                    case User.UserTypeEnum.HSSCsSmsInstructor:
                        this.SwitchToReportsWindow();
                        //Switch to 'Reports' page 'Mainframe' iframe
                        this.SwitchToMainFrame();
                        //Click on the expected button In Reports
                        this.ClickButtonInReport(buttonName);
                        break;
                    //Switch to this case when user is 'DP teacher'
                    case User.UserTypeEnum.DPCsTeacher:
                        //Clear all iframes selected
                        base.SwitchToDefaultPageContent();
                        //Switch to iframes in reports page
                        base.SwitchToIFrameById(RptMainUXPageResource.
                            RptMainUXPage_ContainerFrame_Id_Locator);
                        this.SwitchToMainFrame();
                        //Click on the expected button In Reports
                        this.ClickButtonInReport(buttonName);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "ClickButtonInReportByUser",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the button in 'Reports'.
        /// </summary>
        /// <param name="button">This is the button to be clicked.</param>
        public void ClickButtonInReport(string button)
        {
            //Click on the button In Reports
            Logger.LogMethodEntry("RptMainUXPage", "ClickButtonInReport",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.PartialLinkText(button));
                // Focus on Element
                base.FocusOnElementByPartialLinkText((button));
                //Click On Button
                IWebElement getButton = base.GetWebElementPropertiesByPartialLinkText(button);
                base.ClickByJavaScriptExecutor(getButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "ClickButtonInReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This selects the expected 'Activity' or 'Exam' or 'Training' based on user.
        /// </summary>
        /// <param name="assessmentName">This is the asset name.</param>
        /// <param name="assessmentType">This is the asset type.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        public void SelectSingleAssessment(string assessmentName,
            string assessmentType, User.UserTypeEnum userTypeEnum)
        {
            // This selects the expected 'Activity' or 'Exam' or 'Training' based on user
            Logger.LogMethodEntry("RptMainUXPage", "SelectSingleAssesment",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userTypeEnum)
                {
                    //Selects the activity when instructor is 'Program Admin'
                    case User.UserTypeEnum.HedProgramAdmin:
                    case User.UserTypeEnum.HSSProgramAdmin:
                        new ProgramAdminReportsSubTabPage().
                            SelectAnAssessment(assessmentType, assessmentName);
                        break;
                    //Selects the activity when instructor is 'SMS Instructor'
                    case User.UserTypeEnum.CsSmsInstructor:
                    case User.UserTypeEnum.HSSCsSmsInstructor:
                        this.SwitchToReportsWindow();
                        //Switch to 'Mainframe' iframe in 'Reports' page
                        this.SwitchToMainFrame();
                        switch (assessmentType)
                        {
                            case "Select Activities":
                                this.OpenAssessmentWindow(assessmentType, "Select Activities");
                                //Selects the expected activity and click 'Add'
                                this.AddAssessment(assessmentName);
                                break;
                            case "Select Exams":
                                this.OpenAssessmentWindow(assessmentType, "Select Exam");
                                //Selects the expected exam and click 'Add'
                                this.AddAssessment(assessmentName);
                                break;
                            case "Select Trainings":
                                this.OpenAssessmentWindow(assessmentType, "Select Training");
                                //Selects the expected training and click 'Add'
                                this.AddAssessment(assessmentName);
                                break;
                            case "Select Activity":
                                this.OpenAssessmentWindow(assessmentType, "Select Activities");
                                //Selects the expected activity and click 'Add'
                                this.AddAssessment(assessmentName);
                                break;
                            case "Select Study Plans":
                                this.OpenAssessmentWindow(assessmentType, "Select Study Plan");
                                //Selects the expected activity and click 'Add'
                                this.AddAssessment(assessmentName);
                                break;
                            case "Select Student":
                                this.OpenAssessmentWindow(assessmentType, "Select Student");
                                //Selects the expected activity and click 'Add'
                                this.AddHSSCsSmsStudent((User.UserTypeEnum)
                                     Enum.Parse(typeof(User.UserTypeEnum), assessmentName));
                                break;
                        }
                        break;

                    case User.UserTypeEnum.DPCsTeacher:
                        switch (assessmentType)
                        {
                            case "Select Activities":
                                this.OpenAssessmentWindow(assessmentType, "Select Activities");
                                //Selects the expected activity and click 'Add'
                                this.AddAssessment(assessmentName);
                                break;
                            case "Select Exams":
                                this.OpenAssessmentWindow(assessmentType, "Select Exam");
                                //Selects the expected exam and click 'Add'
                                this.AddAssessment(assessmentName);
                                break;
                            case "Select Trainings":
                                this.OpenAssessmentWindow(assessmentType, "Select Training");
                                //Selects the expected training and click 'Add'
                                this.AddAssessment(assessmentName);
                                break;
                            case "Select Activity":
                                this.OpenAssessmentWindow(assessmentType, "Select Activities");
                                //Selects the expected activity and click 'Add'
                                this.AddAssessment(assessmentName);
                                break;
                            case "Select Study Plans":
                                this.OpenAssessmentWindow(assessmentType, "Select Study Plan");
                                //Selects the expected activity and click 'Add'
                                this.AddAssessment(assessmentName);
                                break;
                            case "Select Student":
                                this.OpenAssessmentWindow(assessmentType, "Select Student");
                                //Selects the expected activity and click 'Add'
                                this.AddHSSCsSmsStudent((User.UserTypeEnum)
                                     Enum.Parse(typeof(User.UserTypeEnum), assessmentName));
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainRptMainUXPage", "SelectSingleAssesment",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This selects the expected assessment.
        /// </summary>
        /// <param name="studentName">This is the assessment to be selected.</param>
        public void AddHSSCsSmsStudent(User.UserTypeEnum studentType)
        {
            // This selects the expected Student From Xml
            Logger.LogMethodEntry("RptMainUXPage", "AddAssesment",
                  base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(studentType);
            String firstName = user.FirstName;
            String lastName = user.LastName;
            String studentName = lastName + ", " + firstName;
            // This Selects Expected Student From UI
            base.SwitchToLastOpenedWindow();
            string getSearchedStudentName = string.Empty;
            base.WaitForElement(By.XPath(
                RptMainUXPageResource.
                RptMainUXPage_SelectStudent_XPath_Locator));
            //Get count of the student listed 
            int getStudentCount = base.GetElementCountByXPath(
                RptMainUXPageResource.
                RptMainUXPage_SelectStudent_XPath_Locator);
            int initialCountStudent = 2;
            //Search for expected student
            for (int initialCount = initialCountStudent;
                initialCount <= getStudentCount; initialCount++)
            {
                base.WaitForElement(By.XPath(string.
                    Format(RptMainUXPageResource.
                    RptMainUXPage_SelectSingleStudent_XPath_Locator, initialCount)));
                getSearchedStudentName = base.GetElementTextByXPath(string.
                Format(RptMainUXPageResource.
                    RptMainUXPage_SelectSingleStudent_XPath_Locator, initialCount));
                //Click on 'Checkbox' of the student
                if (getSearchedStudentName == studentName)
                {
                    base.WaitForElement(By.XPath(string.Format(RptMainUXPageResource.
                    RptMainUXPage_ClickSingleStudent_XPath_Locator, initialCount)));
                    IWebElement selectStudent = base.GetWebElementPropertiesByXPath(
                        string.Format(RptMainUXPageResource.
                    RptMainUXPage_ClickSingleStudent_XPath_Locator, initialCount));
                    base.ClickByJavaScriptExecutor(selectStudent);
                    break;
                }
            }
            this.ClickAddButton();
            Logger.LogMethodExit("RptMainUXPage", "AddAssesment",
                     base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Click on 'Select Activity' and switch to 'Select Activities' window.
        /// </summary>
        /// /// <param name="activityName">This is the assessment to be selected.</param>
        public void SelectActivity(string activityName)
        {
            // Click on 'Select Activity' and switch to 'Select Activities' window
            Logger.LogMethodEntry("RptMainUXPageResource", "SelectActivity",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectReportWindowforLearningaidUsage();
                //Wait for the element
                base.WaitForElement(By.Id(RptMainUXPageResource.
                    RptMainUXPage_LearningAidUsage_ActivityButton_Id_Locator));
                IWebElement getButton = base.GetWebElementPropertiesById(
                   RptMainUXPageResource.
                    RptMainUXPage_LearningAidUsage_ActivityButton_Id_Locator);
                //Click assesment button
                base.ClickByJavaScriptExecutor(getButton);
                //Switch to window
                base.WaitUntilWindowLoads(RptMainUXPageResource.
                    RptMainUX_Page_SelectActivities_Window_Title_Value);
                base.SelectWindow(RptMainUXPageResource.
                    RptMainUX_Page_SelectActivities_Window_Title_Value);
                AddAssessment(activityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPageResource", "SelectActivity",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Report Window for Learningaid Usage.
        /// </summary>
        private void SelectReportWindowforLearningaidUsage()
        {
            //Select Report Window for Learningaid Usage
            Logger.LogMethodEntry("RptMainUXPageResource",
                "SelectReportWindowforLearningaidUsage",
                 base.IsTakeScreenShotDuringEntryExit);
            //Select the window
            base.WaitUntilWindowLoads(RptMainUXPageResource.
                RptMainUXPage_LearningAidUsage_WindowName);
            base.SelectWindow(RptMainUXPageResource.
                RptMainUXPage_LearningAidUsage_WindowName);
            base.SwitchToIFrame(RptMainUXPageResource.
                RptMainUXPage_PageContent_Middle_IFrame_Name);
            base.SwitchToIFrame(RptMainUXPageResource.
                RptMainUXPage_LearningAidUsage_frame_Value);
            Logger.LogMethodExit("RptMainUXPageResource",
                "SelectReportWindowforLearningaidUsage",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Opens the assesment window ad switch to it.
        /// </summary>
        /// <param name="assesmentType">This is the assesment button name.</param>
        /// <param name="assessmentWindow">This is the assesment window name.</param>
        public void OpenAssessmentWindow(string assesmentType, string assessmentWindow)
        {
            Logger.LogMethodEntry("RptMainUXPage", "OpenAssesmentWindow",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath(string.
                           Format(RptMainUXPageResource.
                                  RptmainUX_Page_AssesmentButton_Xpath_Locator, assesmentType)));
                IWebElement getButton = base.GetWebElementPropertiesByXPath(string.
                        Format(RptMainUXPageResource.
                               RptmainUX_Page_AssesmentButton_Xpath_Locator, assesmentType));
                //Click assesment button
                base.ClickByJavaScriptExecutor(getButton);
                //Switch to window
               base.WaitUntilWindowLoads(assessmentWindow);
                base.SelectWindow(assessmentWindow);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPage", "OpenAssesmentWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This selects the expected assessment.
        /// </summary>
        /// <param name="assesmentName">This is the assessment to be selected.</param>
        public void AddAssessment(string assesmentName)
        {
            // This selects the expected assessment
            Logger.LogMethodEntry("RptMainUXPage", "AddAssesment",
                  base.IsTakeScreenShotDuringEntryExit);
            string getSearchedAssesmentName = string.Empty;
            base.SwitchToLastOpenedWindow();
            base.WaitForElement(By.XPath(RptMainUXPageResource.
                RptMainUX_Page_MyReports_AssessmentCount_Xpath_Locator));
            //Get count of the reports listed under 'My Reports'
            int getActivityCount = base.GetElementCountByXPath(RptMainUXPageResource.
                RptMainUX_Page_MyReports_AssessmentCount_Xpath_Locator);
            int initialCountAssessment = Convert.ToInt32(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_Activity_RowNo);
            //Search for expected report 
            for (int initialCount = initialCountAssessment;
                initialCount <= getActivityCount; initialCount++)
            {
                base.WaitForElement(By.XPath(string.
                    Format(RptMainUXPageResource.
                    RptMainUX_Page_MyReports_ActualAssessment_Xpath_Locator, initialCount)));
                getSearchedAssesmentName = base.GetElementTextByXPath(string.
                Format(RptMainUXPageResource.
                RptMainUX_Page_MyReports_ActualAssessment_Xpath_Locator, initialCount));
                //Click on 'Checkbox' of the assessment
                if (getSearchedAssesmentName == assesmentName)
                {
                    base.WaitForElement(By.XPath(string.Format(RptMainUXPageResource.
                    RptmainUX_Page_MyReports_ActualAssessmentCheckBox_Xpath_Locator, initialCount)));
                    IWebElement selectActivity = base.GetWebElementPropertiesByXPath(string.Format(RptMainUXPageResource.
                    RptmainUX_Page_MyReports_ActualAssessmentCheckBox_Xpath_Locator, initialCount));
                    base.ClickByJavaScriptExecutor(selectActivity);
                    break;
                }
            }
            this.ClickAddButton();
            base.SwitchToDefaultWindow();
            Logger.LogMethodExit("RptMainUXPage", "AddAssesment",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on add button.
        /// </summary>
        private void ClickAddButton()
        {
            // Click on add button
            Logger.LogMethodEntry("RptMainUXPageResource", "ClickAddButton",
                  base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(RptMainUXPageResource.
                RptMainUX_Page_AssessmentWindow_Add_Button_Xpath_Locator));
            bool addButton = base.IsElementPresent(By.XPath(RptMainUXPageResource.
                RptMainUX_Page_AssessmentWindow_Add_Button_Xpath_Locator));
            // Click on add button
            IWebElement clickOnAdd = base.GetWebElementPropertiesByXPath(RptMainUXPageResource.
                RptMainUX_Page_AssessmentWindow_Add_Button_Xpath_Locator);
            base.ClickByJavaScriptExecutor(clickOnAdd);
            base.SwitchToDefaultWindow();
            Logger.LogMethodExit("RptMainUXPageResource", "ClickAddButton",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Returns the criteria page heading based on instructor type.
        /// </summary>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        /// <returns>The criteria page name.</returns>
        public string GetCriteriaPageName(User.UserTypeEnum userTypeEnum)
        {
            // Returns the criteria page name base on instructor type
            Logger.LogMethodEntry("RptMainUXPageResource", "GetCriteriaPageName",
                  base.IsTakeScreenShotDuringEntryExit);
            string getCriteriaPageName = string.Empty;
            try
            {
                switch (userTypeEnum)
                {
                    //Returns the criteria page heading when instructor in 'Program Admin'
                    case User.UserTypeEnum.HedProgramAdmin:
                        getCriteriaPageName = new ProgramAdminReportsSubTabPage().
                            GetCriteriaPageHeading();
                        break;
                    //Returns the criteria page heading when instructor in 'SMS Instructor'
                    case User.UserTypeEnum.CsSmsInstructor:
                        this.SwitchToReportsWindow();
                        //Switch to 'Mainframe' iframe at 'Reports page'
                        this.SwitchToMainFrame();
                        base.WaitForElement(By.XPath(RptMainUXPageResource.
                            RptMainUX_Page_ReportCriteriaPage_Heading_Xpath_Locator));
                        //Gets the text from the element
                        getCriteriaPageName = base.GetElementTextByXPath(RptMainUXPageResource.
                            RptMainUX_Page_ReportCriteriaPage_Heading_Xpath_Locator);
                        Thread.Sleep(Convert.ToInt32(RptMainUXPageResource.
                        RptMainUX_Page_ReportCriteriaPage_WindowTime));
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPageResource", "GetCriteriaPageName",
                        base.IsTakeScreenShotDuringEntryExit);
            //returns the text value
            return getCriteriaPageName;
        }

        /// <summary>
        /// Gets the Activity name displayed in the 'Activity Results (Multiple students and activities)' report.
        /// </summary>
        /// <returns>Returns the activity name.</returns>
        public string GetActivityNameFromReport()
        {
            // Gets the Activity name displayed in the report
            Logger.LogMethodEntry("RptMainUXPageResource", "GetActivityNameFromReport",
                  base.IsTakeScreenShotDuringEntryExit);
            string getActualActivityName = string.Empty;
            try
            {
                SwitchToGeneratedReportWindow(RptMainUXPageResource.
                        RptMainUX_Page_ActivityResultsMultipleStudentsAndActivitiesWindow_Title_Locator);
                bool head = base.IsElementPresent(By.XPath(RptMainUXPageResource.
                    RptMainUX_Page_ActivityResultsMultipleStudentsAndActivitiesReport_ActivityHeading_Xpath_Locator));
                base.WaitForElement(By.XPath(RptMainUXPageResource.
                    RptMainUX_Page_ActivityResultsMultipleStudentsAndActivitiesReport_ActivityHeading_Xpath_Locator));
                //Gets the text from the element
                getActualActivityName = base.GetElementTextByXPath(RptMainUXPageResource.
                    RptMainUX_Page_ActivityResultsMultipleStudentsAndActivitiesReport_ActivityHeading_Xpath_Locator);
                Thread.Sleep(Convert.ToInt32(RptMainUXPageResource.
                RptMainUX_Page_ReportCriteriaPage_WindowTime));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("RptMainUXPageResource", "GetActivityNameFromReport",
                        base.IsTakeScreenShotDuringEntryExit);
            return getActualActivityName;
        }

        /// <summary>
        /// /// <summary>
        /// Switch to 'Reports' window.
        /// </summary>
        private void SwitchToGeneratedReportWindow(string windowName)
        {
            // Switch to 'Reports' window
            Logger.LogMethodEntry("RptMainUXPage", "SwitchToGeneratedReportWindow",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(windowName);
            // Switch to 'Reports' window
            base.SelectWindow(windowName);
            Logger.LogMethodExit("RptSelectStudentsPage", "SwitchToGeneratedReportWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Certificates eports Name.
        /// </summary>
        /// <returns>Report Name.</returns>
        public string GetCertificatesReportsName()
        {

            Logger.LogMethodEntry("RptMainUXPage", "GetCertificatesReportsName",
              base.IsTakeScreenShotDuringEntryExit);
            string reportName = string.Empty;
            try
            {
                // switch to frame
                this.SwitchToProgramAdminReportsFrame();
                reportName = base.GetElementTextById(RptMainUXPageResource.
                   RptMainUXPage_CustomCertificate_Report_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("RptMainUXPage", "GetCertificatesReportsName",
              base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToDefaultPageContent();
            return reportName;
        }

        /// <summary>
        /// Switch To Program Admin Reports Frame.
        /// </summary>
        private void SwitchToProgramAdminReportsFrame()
        {
            // switch frame
            Logger.LogMethodEntry("RptMainUXPage", "SwitchToProgramAdminReportsFrame",
              base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToIFrame(RptMainUXPageResource
                .RptMainUXPage_PageContent_Middle_IFrame_Name);
            base.SwitchToIFrame(RptMainUXPageResource
                .RptMain_Page_MainFrame_Id_Locator);
            Logger.LogMethodExit("RptMainUXPage", "SwitchToProgramAdminReportsFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Report Frame Header.
        /// </summary>
        /// <returns>Report Frame Header.</returns>
        public string GetReportFrameHeader()
        {
            Logger.LogMethodEntry("RptMainUXPage", "GetReportFrameHeader",
              base.IsTakeScreenShotDuringEntryExit);
            string reportFrameHeader = string.Empty;
            try
            {
                reportFrameHeader = base.GetElementTextById("lblframeheader");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("RptMainUXPage", "GetReportFrameHeader",
              base.IsTakeScreenShotDuringEntryExit);
            return reportFrameHeader;
        }

        /// <summary>
        /// Click on a report link under reports tab.
        /// </summary>
        /// <param name="reportName">Report link name.</param>
        /// <param name="userTypeEnum">Type of user accessing report link.</param>
        public void ClickReportLinkInReportsTab(string reportName, User.UserTypeEnum userTypeEnum)
        {
            //Access report link
            Logger.LogMethodEntry("RptMainUXPage", "ClickReportLinkInReportsTab",
             base.IsTakeScreenShotDuringEntryExit);
            int getreportLinkCount;
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.HSSCsSmsInstructor:
                    base.SwitchToLastOpenedWindow();
                    base.SwitchToIFrame(RptMainPageResource.
                      RptMain_Page_MainFrame_Id_Locator);
                    //Get count of total number of reports listed under reports tab
                     getreportLinkCount = base.GetElementCountByXPath(
                        RptMainUXPageResource.
                        RptMainUXPage_HSSReport_Link_XPath_Locator);
                    //Search for expected report link
                    for (int i = 3; i <= getreportLinkCount; i++)
                    {
                        //Get report link name
                        string getreportLinkName = base.GetElementTextByXPath(
                            string.Format(
                            RptMainUXPageResource.
                            RptMainUXPage_HSSReportOption_Link_XPath_Locator, i));
                        //If expected report link found click on it
                        if (getreportLinkName == reportName)
                        {
                            IWebElement reportLinkName = base.GetWebElementPropertiesByXPath(
                                string.Format(
                                RptMainUXPageResource.
                            RptMainUXPage_HSSReportOption_Link_XPath_Locator, i));
                            //Click on report link
                            base.ClickByJavaScriptExecutor(reportLinkName);
                            break;
                        }
                    }
                    break;

                case User.UserTypeEnum.DPCsTeacher:
                    base.SwitchToIFrameById(RptMainUXPageResource.
                        RptMainUXPage_ContainerFrame_Id_Locator);
                    base.SwitchToIFrameById(RptMainPageResource.
                      RptMain_Page_MainFrame_Id_Locator);
                    base.WaitForElement(By.XPath(RptMainUXPageResource.
                        RptMainUXPage_HSSReport_Link_XPath_Locator));
                    //Get count of total number of reports listed under reports tab
                     getreportLinkCount = base.GetElementCountByXPath(
                        RptMainUXPageResource.
                        RptMainUXPage_HSSReport_Link_XPath_Locator);
                     //Search for expected report link
                    for (int i = 3; i <= getreportLinkCount; i++)
                    {
                        //Get report link name
                        string getreportLinkName = base.GetElementTextByXPath(
                            string.Format(
                            RptMainUXPageResource.
                            RptMainUXPage_HSSReportOption_Link_XPath_Locator, i));
                        //If expected report link found click on it
                        if (getreportLinkName == reportName)
                        {
                            IWebElement reportLinkName = base.GetWebElementPropertiesByXPath(
                                string.Format(
                                RptMainUXPageResource.
                            RptMainUXPage_HSSReportOption_Link_XPath_Locator, i));
                            //Click on report link
                            base.ClickByJavaScriptExecutor(reportLinkName);
                            break;
                        }
                    }
                    break;
            }
        }

        public string RptMainPageResourceRptMainUXPage_ContainerFrame_Id_Locator { get; set; }
    }
}

