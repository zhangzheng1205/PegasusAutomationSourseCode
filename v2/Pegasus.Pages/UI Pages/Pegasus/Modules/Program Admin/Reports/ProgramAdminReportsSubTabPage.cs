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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Reports;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Program Administration Reports Sub Tab Actions.
    /// </summary>
    public class ProgramAdminReportsSubTabPage : BasePage
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
            //1st frame
            base.WaitForElement(By.Id("_ctl0_PageContent_ifrmMiddle"));
            //Switch to Frame
            base.SwitchToIFrame("_ctl0_PageContent_ifrmMiddle");
            //2nd frame
          /*  base.WaitForElement(By.Id("__hifSmartNav"));
            //Switch to Frame
            base.SwitchToIFrame("__hifSmartNav");*/
            //3rd frame
            bool jk = base.IsElementPresent(By.Id(ProgramAdminReportsSubTabPageResource.
                ProgramAdmin_Page_Frame_Id_Locator),10);
            base.WaitForElement(By.Id(ProgramAdminReportsSubTabPageResource.
                ProgramAdmin_Page_Frame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(ProgramAdminReportsSubTabPageResource.
                ProgramAdmin_Page_Frame_Id_Locator);
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
                getCriteriaPageHeading = base.GetElementInnerTextByXPath
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
                case "Learning Aid Usage":
                    //Click 'Learning Aid Usage' report link
                    new RptMainUXPage().ClickReportLink(ProgramAdminReportsSubTabPageResource.
                    ProgramAdminReportsSubTab_LearningAidUsage_Link_Id_locator);
                    break;
                case "Integrity Violation":
                    //Click 'Integrity Violation' report link
                    new RptMainUXPage().ClickReportLink(ProgramAdminReportsSubTabPageResource.
                    ProgramAdminReportsSubTab_IntegrityViolation_Link_Id_locator);                   
                    break;
                case "Certificate of Completion (Custom)":
                    //Click 'Activity Results (Multiple Students)' report link
                    new RptMainUXPage().ClickReportLink(ProgramAdminReportsSubTabPageResource.
                     ProgramAdminReportsSubTab_CustomCertificate_Report_Id_Locator); 
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
            this.SwitchToProgramAdminWindow();
            //Switch to 'Mainframe' iframe in 'Program  Administration' page
            this.SwitchToMainFrame();
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
                case "Select Sections":
                    new RptMainUXPage().OpenAssessmentWindow(assessmentType, "Select Sections");
                    //Selects the expected training and click 'Add'
                    new RptMainUXPage().AddAssessment(assessmentName);
                    break;
                case "Select Study Plans":
                    new RptMainUXPage().OpenAssessmentWindow(assessmentType, "Select Study Plan");
                    //Selects the expected training and click 'Add'
                    new RptMainUXPage().AddAssessment(assessmentName);
                    break;
                case "Select Student":
                    new RptMainUXPage().OpenAssessmentWindow(assessmentType, "Select Student");
                    //Selects the expected activity and click 'Add'
                    new RptMainUXPage().AddHSSCsSmsStudent((User.UserTypeEnum)
                         Enum.Parse(typeof(User.UserTypeEnum), assessmentName));
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
            bool jk = base.IsElementPresent(By.XPath(ProgramAdminReportsSubTabPageResource.
            ProgramAdminReportsSubTab_CriteriaPage_SelectStudents_XPath_locator),10);
            base.WaitForElement(By.XPath(ProgramAdminReportsSubTabPageResource.
            ProgramAdminReportsSubTab_CriteriaPage_SelectStudents_XPath_locator));
            IWebElement getSelectStudentsButton = base.GetWebElementPropertiesByXPath
                   (ProgramAdminReportsSubTabPageResource.
            ProgramAdminReportsSubTab_CriteriaPage_SelectStudents_XPath_locator);
            //Click on the report link
            base.ClickByJavaScriptExecutor(getSelectStudentsButton);
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
                        IWebElement getCmenuRunReport = base.GetWebElementPropertiesById
                                       (ProgramAdminReportsSubTabPageResource.
                        ProgramAdminReportsSubTab_MyReports_ReportCmenuRunReport_Id_Locator);
                                     //Click on cmenu of the asset
                                   base.ClickByJavaScriptExecutor(getCmenuRunReport);
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

        /// <summary>
        /// Select Section Based On Template.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="templateName"></param>
         public void SelectSectionBasedOnTemplate(string sectionName, string templateName)
        {
            Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", "SelectSectionBasedOnTemplate",
               base.IsTakeScreenShotDuringEntryExit);
            OpenSectionWindow();
            string getActivityName=string.Empty;
           //Get the count of Templates
            int getRowCount = base.GetElementCountByXPath(ProgramAdminReportsSubTabPageResource.
                ProgramAdminReportsSubTab_SelectSections_GridCount_Xpath_locator);
           for (int initialCount =1;initialCount <= getRowCount; initialCount++)
                {
                     base.WaitForElement(By.XPath(string.
                    Format(
                        ProgramAdminReportsSubTabPageResource.
                        ProgramAdminReportsSubTab_SelectSections_TemplateName_Xpath_locator, initialCount)));
                    //Get the template name
                    string getTemplateName=base.GetElementTextByXPath(string.Format(
                         ProgramAdminReportsSubTabPageResource.
                        ProgramAdminReportsSubTab_SelectSections_TemplateName_Xpath_locator, initialCount));
                    if (getTemplateName.Contains(templateName))
                    {
                        base.WaitForElement(By.XPath(string.
                        Format( ProgramAdminReportsSubTabPageResource.
                            ProgramAdminReportsSubTab_SelectSections_TemplateExpand_Icon_Xpath_locator, initialCount)));
                        //Click on expand image of the template
                        IWebElement clickExpand = base.GetWebElementPropertiesByXPath(string.Format(
                            ProgramAdminReportsSubTabPageResource.
                            ProgramAdminReportsSubTab_SelectSections_TemplateExpand_Icon_Xpath_locator, initialCount));
                        base.ClickByJavaScriptExecutor(clickExpand);
                        //Get the Count of sections displayed
                        initialCount++;
                        int getSectionCount = base.GetElementCountByXPath(string.Format(
                             ProgramAdminReportsSubTabPageResource.
                             ProgramAdminReportsSubTab_SelectSections_SectionCount_Xpath_locator, initialCount));
                        for (int sectionCount = 1; sectionCount <= getSectionCount; sectionCount++)
                        {
                            base.WaitForElement(By.XPath(string.
                               Format(ProgramAdminReportsSubTabPageResource.
                                 ProgramAdminReportsSubTab_SelectSections_SectionName_Xpath_locator, initialCount,
                                 sectionCount)));
                            //Get the section name
                            string getSectionName = base.GetElementTextByXPath(string.Format(
                                ProgramAdminReportsSubTabPageResource.
                                 ProgramAdminReportsSubTab_SelectSections_SectionName_Xpath_locator, initialCount,
                                 sectionCount));
                            if (getSectionName.Contains(sectionName))
                            {
                                //Click on the check box of the section
                                IWebElement selectCheckBox = base.GetWebElementPropertiesByXPath(string.Format(
                                    ProgramAdminReportsSubTabPageResource.
                                   ProgramAdminReportsSubTab_SelectSections_SectionCheckBox_Xpath_locator,
                                   initialCount, sectionCount));
                                base.ClickByJavaScriptExecutor(selectCheckBox);
                                break;
                            }
                        }
                        break;
                    }
                }
           new RptSelectSectionsPage().ClickAddandCloseButton();
           Logger.LogMethodExit("ProgramAdminReportsSubTabPage", "SelectSectionBasedOnTemplate",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Opens the selec setion window.
        /// </summary>
         public void OpenSectionWindow()
         {
             Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", "OpenSectionWindow",
                   base.IsTakeScreenShotDuringEntryExit);
             try
             {
                 base.SwitchToLastOpenedWindow();
                 this.SwitchToMainFrame();
                 bool msdhf = base.IsElementPresent(By.XPath(ProgramAdminReportsSubTabPageResource.
                     ProgramAdminReportsSubTab_SelectSections_Button_Xpath_locator), 10);
                 base.WaitForElement(By.XPath(
                     ProgramAdminReportsSubTabPageResource.
                     ProgramAdminReportsSubTab_SelectSections_Button_Xpath_locator));
                 IWebElement getButton = base.GetWebElementPropertiesByXPath(
                     ProgramAdminReportsSubTabPageResource.
                     ProgramAdminReportsSubTab_SelectSections_Button_Xpath_locator);
                 //Click assesment button
                 base.ClickByJavaScriptExecutor(getButton);
                 //Switch to window
                 base.WaitUntilWindowLoads(
                     ProgramAdminReportsSubTabPageResource.
                     ProgramAdminReportsSubTab_SelectSections_Window_Title_Locator);
                 base.SelectWindow(
                     ProgramAdminReportsSubTabPageResource.
                     ProgramAdminReportsSubTab_SelectSections_Window_Title_Locator);
             }
             catch (Exception e)
             {
                 ExceptionHandler.HandleException(e);
             }
             Logger.LogMethodExit("ProgramAdminReportsSubTabPage", "OpenSectionWindow",
                   base.IsTakeScreenShotDuringEntryExit);
         }


         /// <summary>
         /// Select Section Based On Template.
         /// </summary>
         /// <param name="sectionName"></param>
         /// <param name="templateName"></param>
         public void SelectSectionBasedOnTemplateInHSS(string sectionName, string templateName, string assessmentType)
         {
             Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", "SelectSectionBasedOnTemplate",
                base.IsTakeScreenShotDuringEntryExit);
             this.ClickOnSelectSectionUnHSS(assessmentType);
             string getActivityName = string.Empty;
             //Get the count of Templates
             int getRowCount = base.GetElementCountByXPath(ProgramAdminReportsSubTabPageResource.
                 ProgramAdminReportsSubTab_SelectSections_GridCount_Xpath_locator);
             for (int initialCount = 1; initialCount <= getRowCount; initialCount++)
             {
                 base.WaitForElement(By.XPath(string.
                Format(
                    ProgramAdminReportsSubTabPageResource.
                    ProgramAdminReportsSubTab_SelectSections_TemplateName_Xpath_locator, initialCount)));
                 //Get the template name
                 string getTemplateName = base.GetElementTextByXPath(string.Format(
                      ProgramAdminReportsSubTabPageResource.
                     ProgramAdminReportsSubTab_SelectSections_TemplateName_Xpath_locator, initialCount));
                 if (getTemplateName == templateName)
                 {
                     base.WaitForElement(By.XPath(string.
                     Format(ProgramAdminReportsSubTabPageResource.
                         ProgramAdminReportsSubTab_SelectSections_TemplateExpand_Icon_Xpath_locator, initialCount)));
                     //Click on expand image of the template
                     IWebElement clickExpand = base.GetWebElementPropertiesByXPath(string.Format(
                         ProgramAdminReportsSubTabPageResource.
                         ProgramAdminReportsSubTab_SelectSections_TemplateExpand_Icon_Xpath_locator, initialCount));
                     base.ClickByJavaScriptExecutor(clickExpand);
                     //Get the Count of sections displayed
                     initialCount++;
                     int getSectionCount = base.GetElementCountByXPath(string.Format(
                          ProgramAdminReportsSubTabPageResource.
                          ProgramAdminReportsSubTab_SelectSections_SectionCount_Xpath_locator, initialCount));
                     for (int sectionCount = 1; sectionCount <= getSectionCount; sectionCount++)
                     {
                         base.WaitForElement(By.XPath(string.
                            Format(ProgramAdminReportsSubTabPageResource.
                              ProgramAdminReportsSubTab_SelectSections_SectionName_Xpath_locator, initialCount,
                              sectionCount)));
                         //Get the section name
                         string getSectionName = base.GetElementTextByXPath(string.Format(
                             ProgramAdminReportsSubTabPageResource.
                              ProgramAdminReportsSubTab_SelectSections_SectionName_Xpath_locator, initialCount,
                              sectionCount));
                         if (getSectionName.Contains(sectionName))
                         {
                             //Click on the check box of the section
                             IWebElement selectCheckBox = base.GetWebElementPropertiesByXPath(string.Format(
                                 ProgramAdminReportsSubTabPageResource.
                                ProgramAdminReportsSubTab_SelectSections_SectionCheckBox_Xpath_locator,
                                initialCount, sectionCount));
                             base.ClickByJavaScriptExecutor(selectCheckBox);
                             break;
                         }
                     }
                     break;
                 }
             }
             new RptSelectSectionsPage().ClickAddandCloseButton();
             Logger.LogMethodExit("ProgramAdminReportsSubTabPage", "SelectSectionBasedOnTemplate",
              base.IsTakeScreenShotDuringEntryExit);
         }

         private void ClickOnSelectSectionUnHSS(string assessmentType)
         {
             Logger.LogMethodEntry("ProgramAdminReportsSubTabPage", "SelectSectionBasedOnTemplate",
                base.IsTakeScreenShotDuringEntryExit);
             this.SwitchToProgramAdminWindow();
             //Switch to 'Mainframe' iframe in 'Program  Administration' page
             this.SwitchToMainFrame();
             base.WaitForElement(By.XPath(string.
                           Format(RptMainUXPageResource.
                                  RptmainUX_Page_AssesmentButton_Xpath_Locator, assessmentType)));
             IWebElement getButton = base.GetWebElementPropertiesByXPath(string.
                     Format(RptMainUXPageResource.
                            RptmainUX_Page_AssesmentButton_Xpath_Locator, assessmentType));
             //Click assesment button
             base.ClickByJavaScriptExecutor(getButton);
             //Switch to window
             base.WaitUntilWindowLoads(assessmentType);
             base.SelectWindow(assessmentType);
             Logger.LogMethodExit("ProgramAdminReportsSubTabPage", "SelectSectionBasedOnTemplate",
              base.IsTakeScreenShotDuringEntryExit);
         }
    }
}