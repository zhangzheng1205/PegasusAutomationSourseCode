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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using System.Configuration;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Reports;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Program Administration Reports Sub Tab Actions.
    /// </summary>
    class ProgramAdminReportsSubTabPage : BasePage
    {

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ProgramAdminReportsSubTabPage));

        /// <summary>
        /// Switch to 'Program Administration' window.
        /// </summary>
        private void SwitchToProgramAdminWindow()
        {
            // Switch to 'Program Administration' window
            Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", "SwitchToProgramAdminWindow",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ProgramAdminReportsSubTabPageResource.
                ProgramAdmin_Page_Report_Window_Name);
            // Switch to 'Program Administration' window
            base.SelectWindow(ProgramAdminReportsSubTabPageResource.
                ProgramAdmin_Page_Report_Window_Name);
            Logger.LogMethodExit("ProgramAdminReportsSubTabPage", "SwitchToProgramAdminWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to 'Mainframe' iframe.
        /// </summary>
        private void SwitchToMainFrame()
        {
            // Switch to 'Mainframe' iframe
            Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", "SwitchToMainFrame",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(RptMainUXPageResource.
               RptMain_Page_Frame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(RptMainUXPageResource.
                RptMain_Page_Frame_Id_Locator);
            Logger.LogMethodExit("ProgramAdminReportsSubTabPage", "SwitchToMainFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Returns the criteria page heading.
        /// </summary>
        /// <returns>Returns the criteria page heading.</returns>
        public string GetCriteriaPageHeading()
        {
            //Returns the criteria page heading.
            Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", "GetCriteriaPageHeading",
              base.IsTakeScreenShotDuringEntryExit);
            string getCriteriaPageHeading = string.Empty;
            try
            {
                this.SwitchToProgramAdminWindow();
                //Switch to 'Mainframe' iframe in 'Program  Administration' page
                this.SwitchToMainFrame();
                base.WaitForElement(By.XPath(ProgramAdminReportsSubTabPageResource.
                    ProgramAdmin_Page_ReportCriteriaPage_Heading_Xpath_Locator));
                //Gets the text of the element
                getCriteriaPageHeading = base.GetInnerTextAttributeValueByXPath
                    (ProgramAdminReportsSubTabPageResource.
                    ProgramAdmin_Page_ReportCriteriaPage_Heading_Xpath_Locator);
                Thread.Sleep(Convert.ToInt32(ProgramAdminReportsSubTabPageResource.
                   ProgramAdmin_Page_ReportCriteriaPage_WindowTime));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProgramAdminReportsSubTabPage", " GetCriteriaPageHeading",
              base.IsTakeScreenShotDuringEntryExit);
            //returns the text value 
            return getCriteriaPageHeading;
        }

        /// <summary>
        /// Clicks on report link at 'Program Administration-Reports' sub tab.
        /// </summary>
        /// <param name="reportName">This is report link name.</param>
        public void ClickOnReportLink(string reportName)
        {
            // Clicks on report link at 'Program Administration-Reports' sub tab.
            Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", " ClickOnReportLink",
              base.IsTakeScreenShotDuringEntryExit);
            //Switch to 'Mainframe' iframe in 'Program Administration-Reports' sub tab.
            this.SwitchToProgramAdminWindow();            
            this.SwitchToMainFrame();
            switch (reportName)
            {
                case "Activity Result (Multiple students and activities)":
                    //Click 'Activity Result (Multiple students and activities)' report link
                    new RptMainUXPage().ClickReportLink(ProgramAdminReportsSubTabPageResource.
                       ProgramAdminReportsSubTab_ActivityResultMultipleStudentsAndActivities_Link_Id_locator);
                    break;
                case "Exam Frequency Analysis":
                    //Click 'Exam Frequency Analysis' report link
                    new RptMainUXPage().ClickReportLink(ProgramAdminReportsSubTabPageResource.
                        ProgramAdminReportsSubTab_ExamFrequencyAnalysis_Link_Id_locator);
                    break;
                case "Training Frequency Analysis":
                    //Click 'Exam Frequency Analysis' report link
                    new RptMainUXPage().ClickReportLink(ProgramAdminReportsSubTabPageResource.
                        ProgramAdminReportsSubTab_TrainingFrequencyAnalysis_Link_Id_locator);
                    break;
                case "Activity Results (Multiple Students)":
                    //Click 'Exam Frequency Analysis' report link
                    new RptMainUXPage().ClickReportLink(ProgramAdminReportsSubTabPageResource.
                        ProgramAdminReportsSubTab_ActivityResultMultipleStudents_Link_Id_locator);
                    break;
            }
            Logger.LogMethodExit("ProgramAdminReportsSubTabPage", " ClickOnReportLink",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  This selects assessment from assessment window.
        /// </summary>
        /// <param name="assessmentType">This is the asset type.</param>
        /// <param name="assessmentName">This is the asset name.</param>
        public void SelectAnAssessment(string assessmentType, string assessmentName)
        {
            //  This selects assessment from assessment window
            Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", " SelectAnAssessment",
             base.IsTakeScreenShotDuringEntryExit);
            SwitchToProgramAdminWindow();
            //Switch to 'Mainframe' iframe in 'Program  Administration' page
            SwitchToMainFrame();
            switch (assessmentType)
            {
                case "Select Activities":
                    new RptMainUXPage().OpenAssessmentWindow(assessmentType, "Select Activities");
                    //Selects the expected activity and click 'Add'
                    new RptMainUXPage().AddAssessment(assessmentName);
                    break;
                case "Select Exams":
                    new RptMainUXPage().OpenAssessmentWindow(assessmentType, "Select Exam");
                    //Selects the expected exam and click 'Add'
                    new RptMainUXPage().AddAssessment(assessmentName);
                    break;
                case "Select Trainings":
                    new RptMainUXPage().OpenAssessmentWindow(assessmentType, "Select Training");
                    //Selects the expected training and click 'Add'
                    new RptMainUXPage().AddAssessment(assessmentName);
                    break;
            }
            Logger.LogMethodExit("ProgramAdminReportsSubTabPage", "SelectAnAssessment",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check 'Select All' at Students option.
        /// </summary>
        public void SelectAllStudentsProgramAdmin()
        {
            // Check 'Select All' at Students option
            Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", " SelectAllStudentsProgramAdmin",
              base.IsTakeScreenShotDuringEntryExit);
            this.SwitchToProgramAdminWindow();
            //Switch to 'Mainframe' iframe in 'Program  Administration' page
            this.SwitchToMainFrame();
            base.WaitForElement(By.XPath(ProgramAdminReportsSubTabPageResource.
                ProgramAdmin_Page_Report_Window_Name));
            //Click 'Select Students' button
            base.ClickButtonByXPath("//a/span[text()='Select Students']");
            //check 'Select All' at Students Option
            new RptSelectStudentsPage().CheckSelectAll();
            Logger.LogMethodExit("ProgramAdminReportsSubTabPage", "SelectAllStudentsProgramAdmin",
              base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Check 'Save Settings To My Report' check box.
        /// </summary>
        public void CheckSaveSettingsToMyReport()
        {
            // Check 'Save Settings To My Report' check box
            Logger.LogMethodEntry("ProgramAdminReportsSubTabPage",
                "CheckSaveSettingsToMyReport",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.SwitchToProgramAdminWindow();
                //Switch to 'Mainframe' iframe in 'Program  Administration' page
                this.SwitchToMainFrame();
                // Check 'Save Settings To My Report' check box
                this.SelectCheckBoxSaveSettingsToMyReport();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
           Logger.LogMethodExit("ProgramAdminReportsSubTabPage",
               "CheckSaveSettingsToMyReport",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Run Report' or 'Cancel' button based on user .
        /// </summary>
        /// <param name="buttonType"></param>
        public void ClickButtonInReports(string buttonType)
        {
            // Select 'Run Report' or 'Cancel' button based on user 
            Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", " ClickButtonInReports",
             base.IsTakeScreenShotDuringEntryExit);
            SwitchToProgramAdminWindow();
            //Switch to 'Mainframe' iframe in 'Program  Administration' page
            SwitchToMainFrame();
            //Click the button
            new RptMainUXPage().ClickButtonInReport(buttonType);
            Logger.LogMethodExit("ProgramAdminReportsSubTabPage", "ClickButtonInReports",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Perform 'Run Report' or 'Edit Settings' or 'Delete' at 'My reports' based on user.
        /// </summary>
        /// <param name="reportActionOption">Action to be performed on the report.</param>
        /// <param name="reportTypeEnum">Report name enum.</param>
        public void MyReportsActions(string reportActionOption, Report.ReportTypeEnum reportTypeEnum)
        {
            //Perform 'Run Report' or 'Edit Settings' or 'Delete' at 'My reports' based on user
            Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", " MyReportsActions",
             base.IsTakeScreenShotDuringEntryExit);
            this.SwitchToProgramAdminWindow();
            //Switch to 'Mainframe' iframe in 'Program  Administration' page
            this.SwitchToMainFrame();
            switch (reportActionOption)
            {
                //Perform 'Run Report' on selected report
                case "Run Report": 
                    new RptMainUXPage().ClickReportCMenu(reportTypeEnum);
                    base.WaitForElement(By.Id(ProgramAdminReportsSubTabPageResource.
                        ProgramAdminReportsSubTab_MyReports_ReportCmenuRunReport_Id_Locator));
                    base.ClickLinkById(ProgramAdminReportsSubTabPageResource.
                        ProgramAdminReportsSubTab_MyReports_ReportCmenuRunReport_Id_Locator);
                    break;
                //Perform 'Edit Settings' on selected report
                case "Edit Settings":
                    new RptMainUXPage().ClickReportCMenu(reportTypeEnum);
                    base.WaitForElement(By.Id(ProgramAdminReportsSubTabPageResource.
                        ProgramAdminReportsSubTab_MyReports_ReportCmenuEditSettings_Id_Locator));
                    base.ClickLinkById(ProgramAdminReportsSubTabPageResource.
                        ProgramAdminReportsSubTab_MyReports_ReportCmenuEditSettings_Id_Locator);
                    break;
                //Perform 'Delete' on selected report
                case "Delete":
                    new RptMainUXPage().ClickReportCMenu(reportTypeEnum);
                    base.WaitForElement(By.Id(ProgramAdminReportsSubTabPageResource.
                        ProgramAdminReportsSubTab_MyReports_ReportCmenuDelete_Id_Locator));
                    base.ClickLinkById(ProgramAdminReportsSubTabPageResource.
                        ProgramAdminReportsSubTab_MyReports_ReportCmenuDelete_Id_Locator);
                    break;
            }
            Logger.LogMethodExit("ProgramAdminReportsSubTabPage", "MyReportsActions",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Checks the 'Save Settings To My Reports' checkbox.
        /// </summary>
        private void SelectCheckBoxSaveSettingsToMyReport()
        {
            //  Checks the 'Save Settings To My Reports' checkbox.
            Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", 
                "SelectCheckBoxSaveSettingsToMyReport",
            base.IsTakeScreenShotDuringEntryExit);
            base.FocusOnElementById(ProgramAdminReportsSubTabPageResource.
               ProgramAdmin_Page_SaveSettingsToMyReport_Checkbox_Id_Locator);
            base.WaitForElement(By.Id(ProgramAdminReportsSubTabPageResource.
                ProgramAdmin_Page_SaveSettingsToMyReport_Checkbox_Id_Locator));
            //Checks the checkbox
            base.SelectCheckBoxById(ProgramAdminReportsSubTabPageResource.
                ProgramAdmin_Page_SaveSettingsToMyReport_Checkbox_Id_Locator);
            Logger.LogMethodExit("ProgramAdminReportsSubTabPage",
                "SelectCheckBoxSaveSettingsToMyReport",
               base.IsTakeScreenShotDuringEntryExit);

        }
    }
}