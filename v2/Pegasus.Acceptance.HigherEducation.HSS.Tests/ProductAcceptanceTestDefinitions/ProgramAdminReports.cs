using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducation.HSS.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Program Admin Reports actions.
    /// </summary>
    [Binding]
    public class ProgramAdminReports : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ProgramAdminReports));

        /// <summary>
        /// Click the Student Enrollment link.
        /// </summary>
        [When(@"I clicked on the ""(.*)"" report link")]
        public void ClickedOnReportLink(
            String reportLink)
        {
            // Click on the Student Enrollment link
            Logger.LogMethodEntry("ProgramAdminReports",
                "ClickedOnTheStudentEnrollmentLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Student Enrollment link
            new RptMainPage().SelectReportLinkType(reportLink);
            Logger.LogMethodExit("ProgramAdminReports",
                "ClickedOnTheStudentEnrollmentLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the section.
        /// </summary>
        [When(@"I select Section")]
        public void SelectSection()
        {
            // Select the section to generate the report
            Logger.LogMethodEntry("ProgramAdminReports", "SelectSection",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Select Sections button
            new RptSaveReportPage().HSSSelectSectionToGenerateReport();
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.HSSMyPsychLabProgram);
            // Select the Section
            new RptSelectSectionsPage().SelectSection(course.SectionName);
            // Click AddandClose button to close SelectSections PopUp
            new RptSelectSectionsPage().ClickAddandCloseButton();
            Logger.LogMethodExit("ProgramAdminReports", "SelectSection",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the student.
        /// </summary>
        [When(@"I select Student")]
        public void SelectStudent()
        {
            // Select the student to generate the report
            Logger.LogMethodEntry("ProgramAdminReports", "SelectStudent",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Select students button
            new RptSaveReportPage().HSSClickOnSelectStudentButton();
            //Select Window
            new RptSelectStudentsPage().SelectStudentsWindow();
            // Select Student
            new RptSelectStudentsPage().SelectStudentInProgramAdminReport();
            Logger.LogMethodExit("ProgramAdminReports", "SelectStudent",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the activity.
        /// </summary>
        /// <param name="activity">Name of the activity</param>
        [When(@"I select Activity ""(.*)""")]
        public void WhenISelectActivity(string activity)
        {
            // Select the section to generate the report
            Logger.LogMethodEntry("ProgramAdminReports", "SelectActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Select Sections button
            new RptSelectAssessmentsPage().ClickOnSelectActivity();
            // Select the Section
            new RptSelectAssessmentsPage().SelectActivity(activity);
            // Click AddandClose button to close SelectSections PopUp
            new RptSelectAssessmentsPage().ClickAddButton();
            Logger.LogMethodExit("ProgramAdminReports", "SelectActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button In Reports.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        [When(@"I click on the ""(.*)"" button in reports")]
        public void ClickOnButtonInReports(string buttonName)
        {
            //Click On Button In Reports
            Logger.LogMethodEntry("ProgramAdminReports", "ClickOnButtonInReports",
               base.IsTakeScreenShotDuringEntryExit);
            //Select the window
            new RptSaveReportPage().SelectWindowAndFrame();
            //Click on Button
            new RptSaveReportPage().ClickOnButtonInReports(buttonName);
            Logger.LogMethodExit("ProgramAdminReports", "ClickOnButtonInReports",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Student Enrollment report as launched successfully.
        /// </summary>
        /// <param name="reportType">This is the report type.</param>
        [Then(@"I should see ""(.*)"" report launched successfully")]
        public void ProgramAdminReportLaunchedSuccessfully(String reportType)
        {
            //Verification of tudent Enrollment report launched successfully
            Logger.LogMethodEntry("ProgramAdminReports", "ProgramAdminReportLaunchedSuccessfully",
               base.IsTakeScreenShotDuringEntryExit);
            // Creating Object of class RptStudentUsagePage
            RptStudentUsagePage rptStudentUsagePage = new RptStudentUsagePage();
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.HSSMyPsychLabProgram);
            //Assert to verify section name
            Logger.LogAssertion("VerifySectionName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(course.SectionName,
                    rptStudentUsagePage.
                    GetSectionName((RptStudentUsagePage.ProgramAdminReportType)Enum.
                    Parse(typeof(RptStudentUsagePage.ProgramAdminReportType), reportType))));
            User user = User.Get(User.UserTypeEnum.HSSCsSmsStudent);
            String lastName = user.LastName;
            //Assert to verify student
            Logger.LogAssertion("VerifyStatus", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.IsTrue(rptStudentUsagePage.GetStatusText
                 ((RptStudentUsagePage.ProgramAdminReportType)Enum.
                Parse(typeof(RptStudentUsagePage.ProgramAdminReportType), reportType))
                .Contains(lastName)));
            Logger.LogMethodExit("ProgramAdminReports", "ProgramAdminReportLaunchedSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Save Settings To My Reports Option.
        /// </summary>
        [Then(@"I select 'save settings to My Reports' option")]
        public void SelectSaveSettingsToMyReportsOption()
        {
            //Select Save Settings To My Reports Option
            Logger.LogMethodEntry("ProgramAdminReports",
                "SelectSaveSettingsToMyReportsOption",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Save Settings To My Reports Checkbox
            new RptSaveReportPage().SelectSaveSettingsToMyReportsCheckbox();
            Logger.LogMethodExit("ProgramAdminReports",
                "SelectSaveSettingsToMyReportsOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Radiobutton In Save Settings To MyReports Popup.
        /// </summary>
        /// <param name="radiobuttonName">This is Radiobutton Name.</param>
        [When(@"I select ""(.*)"" radiobutton")]
        public void SelectRadiobuttonInSaveSettingsToMyReportsPopup(string radiobuttonName)
        {
            Logger.LogMethodEntry("ProgramAdminReports",
                "SelectRadiobuttonInSaveSettingsToMyReportsPopup",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Radiobutton In Save Settings Popup
            new RptSaveSettingsPage().SelectRadioButtonInSaveSettingsPopup(
                (RptSaveSettingsPage.SaveSettingsPopupRadiobuttonTypeEnum)Enum.Parse(typeof(
                RptSaveSettingsPage.SaveSettingsPopupRadiobuttonTypeEnum), radiobuttonName));
            Logger.LogMethodExit("ProgramAdminReports",
                "SelectRadiobuttonInSaveSettingsToMyReportsPopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter And Store Report Name.
        /// </summary>
        /// <param name="reportTypeEnum">This is Report Type Enum.</param>
        [When(@"I enter the ""(.*)"" report name")]
        public void EnterAndStoreReportName(Report.ReportTypeEnum reportTypeEnum)
        {
            //Enter And Store Report Name
            Logger.LogMethodEntry("ProgramAdminReports", "EnterAndStoreReportName",
              base.IsTakeScreenShotDuringEntryExit);
            //Generate GUID For Report Name
            Guid reportName = Guid.NewGuid();
            RptSaveSettingsPage rptSaveSettingsPage = new RptSaveSettingsPage();
            //Enter Report Name
            rptSaveSettingsPage.EnterReportName(reportName);
            //Stor Report Name
            rptSaveSettingsPage.StoreReportDetailsInMemory(reportName, reportTypeEnum);
            Logger.LogMethodExit("ProgramAdminReports", "EnterAndStoreReportName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button In Save Settings Popup.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        [When(@"I click on ""(.*)"" button")]
        public void ClickOnTheButtonInSaveSettingsPopup(string buttonName)
        {
            //Click On Button In Save Settings Popup
            Logger.LogMethodEntry("ProgramAdminReports", "ClickOnTheButtonInSaveSettingsPopup",
              base.IsTakeScreenShotDuringEntryExit);
            //Click On Button In Save Settings Popup
            new RptSaveSettingsPage().ClickOnButtonInSaveSettingsPopup(
                (RptSaveSettingsPage.SaveSettingsPopupButtonTypeEnum)Enum.Parse(typeof(
                RptSaveSettingsPage.SaveSettingsPopupButtonTypeEnum), buttonName));
            Logger.LogMethodExit("ProgramAdminReports", "ClickOnTheButtonInSaveSettingsPopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display OfReport In MyReports Grid.
        /// </summary>
        /// <param name="reportTypeEnum">This is Report Type Enum</param>
        [Then(@"I should see the ""(.*)"" report in 'My Reports' grid")]
        public void VerifyTheDisplayOfReportInMyReportsGrid(Report.ReportTypeEnum reportTypeEnum)
        {
            Logger.LogMethodEntry("ProgramAdminReports", "VerifyTheDisplayOfReportInMyReportsGrid",
              base.IsTakeScreenShotDuringEntryExit);
            //Get Report From Memory
            Report report = Report.Get(reportTypeEnum);
            //Assert to verify The Display Of Report In My Reports
            Logger.LogAssertion("VerifyTheDisplayOfReportInMyReportsGrid", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(report.Name,
                    new RptMainPage().GetReportName()));
            Logger.LogMethodExit("ProgramAdminReports", "VerifyTheDisplayOfReportInMyReportsGrid",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Popup Closed.
        /// </summary>
        /// <param name="windowName">This is Window Name.</param>
        [Then(@"I should see the ""(.*)"" popup closed")]
        public void VerifyPopupClosed(string windowName)
        {
            //Verify Popup Closed
            Logger.LogMethodEntry("ProgramAdminReports",
                 "VerifyPopupClosed", base.IsTakeScreenShotDuringEntryExit);
            //Assert To Verify Popup Closed
            Logger.LogAssertion("VerifyPopupClosed", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsFalse(base.IsPopupPresent(windowName,
                    Convert.ToInt32(ProgramAdminReportsResource.ProgramAdminReports_Page_Wait_Time))));
            Logger.LogMethodExit("ProgramAdminReports",
               "VerifyPopupClosed", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        ///Perform 'Run Report' or 'Edit Settings' or 'Delete' at 'My reports' based on user.
        /// </summary>
        /// <param name="reportActionOption">Action to be performed on the report.</param>
        /// <param name="reportTypeEnum">Report name enum.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [When(@"I select ""(.*)"" for ""(.*)"" report in 'My Reports' grid by ""(.*)""")]
        public void WhenISelectForReportInGridBy(string reportActionOption,
            Report.ReportTypeEnum reportTypeEnum,
           User.UserTypeEnum userTypeEnum)
        {
            //Perform 'Run Report' or 'Edit Settings' or 'Delete' at 'My reports' based on user
            Logger.LogMethodEntry("Reports", "MyReportActionsThroughCmenu",
            base.IsTakeScreenShotDuringEntryExit);
            //Perform 'Run Report' or 'Edit Settings' or 'Delete' at 'My reports' based on user
            new RptMainUXPage().PerformActionOnMyReports
                (reportActionOption, reportTypeEnum, userTypeEnum);
            Logger.LogMethodExit("Reports", "MyReportActionsThroughCmenu",
              base.IsTakeScreenShotDuringEntryExit);        
        }


        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }


    }
}
