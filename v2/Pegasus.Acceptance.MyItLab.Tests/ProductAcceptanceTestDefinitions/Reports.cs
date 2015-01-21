using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages;
using Pegasus.Automation.DataTransferObjects;
using TechTalk.SpecFlow;
using Pegasus.Pages.CommonResource;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public class Reports : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(Reports));

        /// <summary>
        /// Click On Report In Activity Reports Panel.
        /// </summary>
        /// <param name="reportType">This is Report Type.</param>
        [When(@"I click on ""(.*)"" report in 'Activity Reports' panel")]
        public void ClickOnReportInActivityReportsPanel(string reportType)
        {
            //Click On Report In Activity Reports Panel
            Logger.LogMethodEntry("Reports", "ClickOnReportInActivityReportsPanel",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Frame
            new RptMainPage().SelectReportFrame();
            //Click On Report In Activity Results Panel
            new RptMainPage().ClickOnReportInActivityResultsPanel(reportType);
            Logger.LogMethodExit("Reports", "ClickOnReportInActivityReportsPanel",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Options To Generate Report.
        /// </summary>
        [When(@"I select options to generate report")]
        public void SelectOptionsToGenerateReport()
        {
            //Select Options To Generate Report
            Logger.LogMethodEntry("Reports", "SelectOptionsToGenerateReport",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Select Sections button
            new RptSaveReportPage().SelectSectionToGenerateReport();
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.MyItLabProgramCourse);
            //Get Activity From Memory
            Activity activity = Activity.Get(Activity.ActivityTypeEnum.SIM5Activity,
                Activity.ActivityBehavioralModesEnum.SkillBased);
            //Select the Section
            new RptSelectSectionsPage().SelectSection(course.SectionName +
                ReportsResource.Report_Resource_Space_Value);
            // Click AddandClose button to close SelectSections PopUp
            new RptSelectSectionsPage().ClickAddandCloseButton();
            //Click on Select students button
            new RptSaveReportPage().ClickOnSelectStudentButton();
            //Select Window
            new RptSelectStudentsPage().SelectStudentWindow();
            //Select Student
            new RptSelectStudentsPage().SelectStudentInProgramAdminReport();
            //Select Activities
            new RptSaveReportPage().SelectActivities(activity.Name);
            //Select Window And Frame
            new RptSaveReportPage().SelectWindowAndFrame();
            //Select Date
            new RptSaveReportPage().SelectDate();
            Logger.LogMethodExit("Reports", "SelectOptionsToGenerateReport",
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
            Logger.LogMethodEntry("Reports", "ClickOnButtonInReports",
               base.IsTakeScreenShotDuringEntryExit);
            //Select the window
            new RptSaveReportPage().SelectWindowAndFrame();
            //Click on Button
            new RptSaveReportPage().ClickOnButtonInReports(buttonName);
            Logger.LogMethodExit("Reports", "ClickOnButtonInReports",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Activity Details Under Launched Report.
        /// </summary>
        /// <param name="activityScore">This is Activity Score.</param>
        /// <param name="activityTypeEnum">This is Activitytype Enum.</param>
        /// <param name="activityBehavioralModeEnum">This is Activitybehavioralmode Enum.</param>
        [Then(@"I should see the score ""(.*)"" of ""(.*)"" activity of behavioral mode ""(.*)"" type under launched report")]
        public void VerifyTheActivityDetailsUnderLaunchedReport(int activityScore,
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum activityBehavioralModeEnum)
        {
            //Verify The Activity Details Under Launched Report
            Logger.LogMethodEntry("Reports", "VerifyTheActivityDetailsUnderLaunchedReport",
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, activityBehavioralModeEnum);
            //Assert Activity Score
            Logger.LogAssertion("VerifyActivityScore", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityScore.ToString(), new RptAssessmentAllStudentsPage().
                    GetSubmittedActivityScore()));
            //Assert Activity Name
            Logger.LogAssertion("VerifyActivityScore", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name, new RptAssessmentAllStudentsPage().
                    GetSubmittedActivityName()));
            Logger.LogMethodExit("Reports", "VerifyTheActivityDetailsUnderLaunchedReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Study Plan Report Single Student Link.
        /// </summary>
        [When(@"I click on 'Study Plan Single Student' report link")]
        public void ClickOnStudyPlanReportSingleStudentLink()
        {
            //Click On Study Plan Report Single Student Link
            Logger.LogMethodEntry("Reports", "ClickOnStudyPlanReportSingleStudentLink",
               base.IsTakeScreenShotDuringEntryExit);
            //Click On Study Plan Report Single Student Link
            new RptMainUXPage().ClickOnStudyPlanSingleStudentReport();
            Logger.LogMethodExit("Reports", "ClickOnStudyPlanReportSingleStudentLink",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Study Plan Report.
        /// </summary>        
        [When(@"I select options to create 'Study Plan Single Student' report")]
        public void CreateStudyPlanReport()
        {
            //Create Study Plan Report
            Logger.LogMethodEntry("Reports", "CreateStudyPlanReport",
               base.IsTakeScreenShotDuringEntryExit);
            //Create Study Plan Report
            new RptSaveReportPage().CreateStudyPlanReport();
            Logger.LogMethodExit("Reports", "CreateStudyPlanReport",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Radiobutton In Save Settings To MyReports Popup.
        /// </summary>
        /// <param name="radiobuttonName">This is Radiobutton Name.</param>
        [When(@"I select ""(.*)"" radiobutton")]
        public void SelectRadiobuttonInSaveSettingsToMyReportsPopup(string radiobuttonName)
        {
            Logger.LogMethodEntry("Reports",
                "SelectRadiobuttonInSaveSettingsToMyReportsPopup",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Radiobutton In Save Settings Popup
            new RptSaveSettingsPage().SelectRadioButtonInSaveSettingsPopup(
                (RptSaveSettingsPage.SaveSettingsPopupRadiobuttonTypeEnum)Enum.Parse(typeof(
                RptSaveSettingsPage.SaveSettingsPopupRadiobuttonTypeEnum), radiobuttonName));
            Logger.LogMethodExit("Reports",
                "SelectRadiobuttonInSaveSettingsToMyReportsPopup",
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
            Logger.LogMethodEntry("Reports", "ClickOnTheButtonInSaveSettingsPopup",
              base.IsTakeScreenShotDuringEntryExit);
            //Click On Button In Save Settings Popup
            new RptSaveSettingsPage().ClickOnButtonInSaveSettingsPopup(
                (RptSaveSettingsPage.SaveSettingsPopupButtonTypeEnum)Enum.Parse(typeof(
                RptSaveSettingsPage.SaveSettingsPopupButtonTypeEnum), buttonName));
            Logger.LogMethodExit("Reports", "ClickOnTheButtonInSaveSettingsPopup",
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
            Logger.LogMethodEntry("Reports", "EnterAndStoreReportName",
              base.IsTakeScreenShotDuringEntryExit);
            //Generate GUID For Report Name
            Guid reportName = Guid.NewGuid();
            RptSaveSettingsPage rptSaveSettingsPage = new RptSaveSettingsPage();
            //Enter Report Name
            rptSaveSettingsPage.EnterReportName(reportName);
            //Stor Report Name
            rptSaveSettingsPage.StoreReportDetailsInMemory(reportName, reportTypeEnum);
            Logger.LogMethodExit("Reports", "EnterAndStoreReportName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button In Reports.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        [When(@"I click on ""(.*)"" button in reports")]
        public void ClickOnTheButtonInReports(string buttonName)
        {
            //Click On Button In Reports
            Logger.LogMethodEntry("Reports", "ClickOnTheButtonInReports",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on Button
            new RptSaveReportPage().ClickOnTheButtonInReports(buttonName);
            Logger.LogMethodExit("Reports", "ClickOnTheButtonInReports",
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
            Logger.LogMethodEntry("Reports",
                 "VerifyPopupClosed", base.IsTakeScreenShotDuringEntryExit);
            //Assert To Verify Popup Closed
            Logger.LogAssertion("VerifyPopupClosed", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsFalse(
                    base.IsPopupPresent(windowName,
                    Convert.ToInt32(ReportsResource.Report_Resource_TimeToWait_Value))));
            Logger.LogMethodExit("Reports",
               "VerifyPopupClosed", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Report In Dropdown.
        /// </summary>
        /// <param name="reportTypeEnum">This is Report Type Enum.</param>
        [Then(@"I should see ""(.*)"" report in dropdown")]
        public void VerifyReportInDropdown(Report.ReportTypeEnum reportTypeEnum)
        {
            //Verify Report In Dropdown
            Logger.LogMethodEntry("Reports", "VerifyReportInDropdown",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Report From Memory
            Report report = Report.Get(reportTypeEnum);
            //Assert To Verify Existing Report In Dropdown
            Logger.LogAssertion("VerifyExistingReportInDropdown", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new RptSaveSettingsPage().IsReportDisplayedInDropdown(report.Name)));
            Logger.LogMethodExit("Reports", "VerifyReportInDropdown",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Report In MyReports Grid.
        /// </summary>
        /// <param name="reportTypeEnum">This is Report Type Enum.</param>
        [Then(@"I should see the ""(.*)"" report in 'My Reports' grid")]
        public void VerifyReportInMyReportsGrid(Report.ReportTypeEnum reportTypeEnum)
        {
            //Verify Report In MyReports Grid
            Logger.LogMethodEntry("Reports", "VerifyReportInMyReportsGrid",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Report From Memory
            Report report = Report.Get(reportTypeEnum);
            //Assert To Verify Saved Report In My Reports Grid
            Logger.LogAssertion("VerifyReportInMyReports", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(report.Name,
                    new RptMainUXPage().GetReportName(report.Name)));
            Logger.LogMethodExit("Reports", "VerifyReportInMyReportsGrid",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Report Type.
        /// </summary>
        /// <param name="reportType">This is Report Type.</param>
        [When(@"I click on ""(.*)"" report type")]
        public void ClickOnReportType(string reportType)
        {
            //Click On Report Type
            Logger.LogMethodEntry("Reports", "ClickOnReportType",
             base.IsTakeScreenShotDuringEntryExit);
            //Click On Report Type Link
            new RptMainUXPage().ClickOnReportTypeLink(
                (RptMainUXPage.PegasusInstructorReportEnum)Enum.Parse(typeof(
                RptMainUXPage.PegasusInstructorReportEnum), reportType));
            Logger.LogMethodExit("Reports", "ClickOnReportType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Valid Data In Fields To Generate Report.
        /// </summary>
        [When(@"I enter the valid data in the fields to generate report")]
        public void EnterValidDataInFieldsToGenerateReport()
        {
            //Enter Valid Data In Fields To Generate Report
            Logger.LogMethodEntry("Reports", "EnterValidDataInFieldsToGenerateReport",
            base.IsTakeScreenShotDuringEntryExit);
            //Enter Data In Fields To Generate Report
            new RptSaveReportPage().EnterDataInFieldsToGenerateReport();
            Logger.LogMethodExit("Reports", "EnterValidDataInFieldsToGenerateReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Data To Generate Training Frequency Report.
        /// </summary>
        [When(@"I enter the valid data in the fields to 'Training Frequency Analysis' generate report")]
        public void EnterDataToGenerateTrainingFrequencyReport()
        {
            //Enter Valid Data In Fields To Generate Report
            Logger.LogMethodEntry("Reports", "EnterDataToGenerateTrainingFrequencyReport",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Training Most Recent Radio Button
            new RptSaveReportPage().SelectTrainingMostRecentRadioButton();
            //Enter Data In Fields To Generate Report
            new RptSaveReportPage().EnterDataInFieldsToGenerateReport();
            Logger.LogMethodExit("Reports", "EnterDataToGenerateTrainingFrequencyReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Score In Generated Report.
        /// </summary>
        /// <param name="activityScore">This is Activity Score.</param>
        [Then(@"I should see the score ""(.*)"" in generated report")]
        public void VerifyTheScoreInGeneratedReport(string activityScore)
        {
            //Verify The Score In Generated Report
            Logger.LogMethodEntry("Reports", "VerifyTheScoreInGeneratedReport",
            base.IsTakeScreenShotDuringEntryExit);
            //Assert To Verify Score in Generated Report
            Logger.LogAssertion("VerifyScoreInReport", ScenarioContext.
             Current.ScenarioInfo.Title, () => Assert.AreEqual(activityScore,
             new RptTrainingFreqAnalysisPage().GetActivityScoreFromGeneratedReport()));
            Logger.LogMethodExit("Reports", "VerifyTheScoreInGeneratedReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Activity Result Generate Report By Instructor.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activty Type Enum.</param>
        [When(@"I select options to generate report by instructor for ""(.*)""")]
        public void ActivityResultGenerateReportByInstructor(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Activity Result Generate Report By Instructor
            Logger.LogMethodEntry("Reports",
                "ActivityResultGenerateReportByInstructor",
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch the activity from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Report window and Frame
            new RptMainUXPage().SelectReportsWindowandFrame();
            //Generate Report For Activity Result Single Student
            new RptSaveReportPage().
                SelectOptionstoGenerateActivityResultReport(activity.Name);
            Logger.LogMethodExit("Reports",
                "ActivityResultGenerateReportByInstructor",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Verify The Score of Activity Result Single Student.
        /// </summary>
        /// <param name="activityScore">This is Activity Score.</param>
        [Then(@"I should see the score ""(.*)"" in Activity Result Single Student generated report")]
        public void ToVerifyTheScoreofActivityResultSingleStudent(string activityScore)
        {
            //To Verify The Score of Activity Result Single Student
            Logger.LogMethodEntry("Reports",
                "ToVerifyTheScoreofActivityResultSingleStudent",
            base.IsTakeScreenShotDuringEntryExit);
            //Assert To Verify Score in Generated Report
            Logger.LogAssertion("VerifyScoreInReport", ScenarioContext.
             Current.ScenarioInfo.Title, () => Assert.AreEqual(activityScore,
             new RptStudentAllAssessmentsPage().
                       GetActivityResultSingleStudentScoreInReport()));
            Logger.LogMethodExit("Reports",
                "ToVerifyTheScoreofActivityResultSingleStudent",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Data For Exam Frequency Analysis Report.
        /// </summary>
        [When(@"I enter the exam frequency analysis valid data in the fields to generate report")]
        public void EnterTheDataForExamFrequencyAnalysisReport()
        {
            //Enter The Data For Exam Frequency Analysis Report
            Logger.LogMethodEntry("Reports",
                "EnterTheDataForExamFrequencyAnalysisReport",
            base.IsTakeScreenShotDuringEntryExit);
            //Click the Exam Frequency Analysis Generate Report
            new RptMainUXPage().ClickTheExamFrequencyAnalysisReportLink();
            //Select The Exams Activity In Report
            new RptSelectAssessmentsPage().SelectTheExamsActivityInReport();
            Logger.LogMethodExit("Reports",
                "EnterTheDataForExamFrequencyAnalysisReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Score In Exam Frequency Analysis Report.
        /// </summary>
        /// <param name="activityScore">This is Activity Score.</param>
        [Then(@"I should see the score ""(.*)"" in Exam Frequency Analysis generated report")]
        public void VerifyTheScoreInExamFrequencyAnalysisReport(String activityScore)
        {
            //To Verify The Score of Activity Result Single Student
            Logger.LogMethodEntry("Reports",
                "VerifyTheScoreInExamFrequencyAnalysisReport",
            base.IsTakeScreenShotDuringEntryExit);
            //Assert To Verify Score in Generated Report
            Logger.LogAssertion("VerifyScoreInReport", ScenarioContext.
             Current.ScenarioInfo.Title, () => Assert.AreEqual(activityScore,
                 new RptExamFreqAnalysisPage().GetExamFrequencyAnalysisScoreInReport()));
            Logger.LogMethodExit("Reports",
                "VerifyTheScoreInExamFrequencyAnalysisReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Certificate In Report Panel
        /// </summary>
        /// <param name="reportType">This is Report Type</param>
        [When(@"I click on ""(.*)"" certificate report in 'Activity Reports' panel")]
        public void ClickOnCertificateReportInPanel(string reportType)
        {
            Logger.LogMethodEntry("Reports", "ClickTheCloseButtonInReportPage",
               base.IsTakeScreenShotDuringEntryExit);
            //Click On Certificate In Activity Results Panel
            new RptMainPage().ClickOnCertificateInActivityResultsPanel(reportType);
            Logger.LogMethodExit("Reports", "ClickTheCloseButtonInReportPage",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Options For Certificate Of Completion
        /// </summary>
        [When(@"I select options for 'Certificate of Completion Exam'")]
        public void SelectOptionsForCertificateOfCompletion()
        {
            //Select Options for Certificate Of Completion
            Logger.LogMethodEntry("Reports", "SelectOptionsForCertificateOfCompletion",
               base.IsTakeScreenShotDuringEntryExit);
            //Create Object
            RptSaveReportPage saveReportPage = new RptSaveReportPage();
            //Create Object
            RptSelectSectionsPage selectSectionPage = new RptSelectSectionsPage();
            //Create Object
            RptSelectStudentsPage selectStudentPage = new RptSelectStudentsPage();
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.MyItLabProgramCourse);
            //Get Activity From Memory
            Activity activity = Activity.Get(Activity.ActivityTypeEnum.SIM5Activity,
                Activity.ActivityBehavioralModesEnum.SkillBased);
            //Click on the Select Sections button
            saveReportPage.SelectSectionToGenerateReport();
            //Select Section
            selectSectionPage.SelectSectionAndClickAddButton
                (course.SectionName +
                ReportsResource.Report_Resource_Space_Value);
            //Click On Select Exam
            new ProgramAdminToolPage().ClickOnSelectExam();
            //Select Exam Asset
            new RptSelectAssessmentsPage().SelectExamAsset(activity.Name);
            //Click on Select students button
            saveReportPage.ClickOnSelectStudentButton();
            //Select Window
            selectStudentPage.SelectStudentsWindow();
            //Select Student
            selectStudentPage.SelectStudentInProgramAdminReport();
            //Select Date
            saveReportPage.SelectDate();
            Logger.LogMethodExit("Reports", "SelectOptionsForCertificateOfCompletion",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Exam Score.
        /// </summary>
        /// <param name="score">This is Score.</param>
        [Then(@"I should see the exam score ""(.*)"" in 'Certificate of Completion Exam' page")]
        public void VerifyTheExamScore(string score)
        {
            //Verify the Exam Score
            Logger.LogMethodEntry("Reports", "VerifyTheExamScore",
               base.IsTakeScreenShotDuringEntryExit);
            //Select 'Certificate Of Completion Exam' Window
            new ReportsAssessmentCertificatePage().
                SelectCertificateOfCompletionExamWindow();
            //Assert to Verify the Submission in View Submission Page
            Logger.LogAssertion("VerifySubmissionInViewSubmission",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(score,
                 new ReportsAssessmentCertificatePage().GetCertificateScore()));
            Logger.LogMethodExit("Reports", "VerifyTheExamScore",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Certificate Type.
        /// </summary>
        /// <param name="certificateType">This is Certificate Type.</param>
        [When(@"I click on ""(.*)"" certificate type")]
        public void ClickOnCertificateType(string certificateType)
        {
            //Click On Certificate Type
            Logger.LogMethodEntry("Reports", "ClickOnCertificateType",
             base.IsTakeScreenShotDuringEntryExit);
            //Click On Certificate Type Link
            new RptMainUXPage().ClickOnCertificateTypeLink(
                (RptMainUXPage.PegasusInstructorCertificateTypeEnum)Enum.Parse(typeof(
                RptMainUXPage.PegasusInstructorCertificateTypeEnum), certificateType));
            Logger.LogMethodExit("Reports", "ClickOnCertificateType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Valid Data In Fields To Generate Certificate.
        /// </summary>
        [When(@"I enter the valid data in the fields to generate certificate")]
        public void EnterValidDataInFieldsToGenerateCertificate()
        {
            //Enter Valid Data In Fields To Generate Certificate
            Logger.LogMethodEntry("Reports",
                "EnterValidDataInFieldsToGenerateCertificate",
             base.IsTakeScreenShotDuringEntryExit);
            //Enter Valid Data In Fields To Generate Certificate
            new RptSaveReportPage().EnterDataInFieldsToGenerateCertificate();
            Logger.LogMethodExit("Reports",
                "EnterValidDataInFieldsToGenerateCertificate",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Score In Generated Certificate.
        /// </summary>
        /// <param name="score">This is Score.</param>
        [Then(@"I should see the training score ""(.*)"" in 'Certificate of Completion Training' certificate")]
        public void VerifyTheTrainingScore(string score)
        {
            //Verify The Score In Generated Certificate
            Logger.LogMethodEntry("Reports", "VerifyTheTrainingScore",
             base.IsTakeScreenShotDuringEntryExit);
            //Select 'Certificate Of Completion Training' Window
            new ReportsAssessmentCertificatePage().
                SelectCertificateOfCompletionTrainingWindow();
            //Asserts to Verify Score in Generated Certificate
            Logger.LogAssertion("VerifyScoreInGeneratedCertificate",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(score,
                    new ReportsAssessmentCertificatePage().GetCertificateScore()));
            Logger.LogMethodExit("Reports", "VerifyTheTrainingScore",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Valid Data In The Fields To Generate Exam Report.
        /// </summary>
        [When(@"I enter the valid data in the fields to generate certificate for Exam report")]
        public void EnterTheValidDataInTheFieldsToGenerateExamReport()
        {
            //Enter The Valid Data In The Fields To Generate Exam Report
            Logger.LogMethodEntry("Reports",
                "EnterTheValidDataInTheFieldsToGenerateExamReport",
            base.IsTakeScreenShotDuringEntryExit);
            RptSaveReportPage rptSaveReportPage = new RptSaveReportPage();
            //Select Report Window and Frame
            rptSaveReportPage.SelectReportWindowAndFrame();
            //Select Save Settings To My Reports Checkbox
            rptSaveReportPage.EnterTheDataFieldsToGenerateExamReport();
            Logger.LogMethodExit("Reports",
                "EnterTheValidDataInTheFieldsToGenerateExamReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'save settings to My Reports' Option.
        /// </summary>
        [When(@"I select 'save settings to My Reports' option")]
        public void SelectSaveSettingsToMyReportsOption()
        {
            //Select 'save settings to My Reports' Option
            Logger.LogMethodEntry("Reports", "SelectSaveSettingsToMyReportsOption",
            base.IsTakeScreenShotDuringEntryExit);
            RptSaveReportPage rptSaveReportPage = new RptSaveReportPage();
            //Select Report Window and Frame
            rptSaveReportPage.SelectReportWindowAndFrame();
            //Select Save Settings To My Reports Checkbox
            rptSaveReportPage.SelectSaveSettingsToMyReportsOption();
            Logger.LogMethodExit("Reports", "SelectSaveSettingsToMyReportsOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on a report link based on instructor.
        /// </summary>
        /// <param name="reportType">This is the report type.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [When(@"I click on ""(.*)"" report link as ""(.*)""")]
        public void ClickOnReportLink(string reportType, User.UserTypeEnum userTypeEnum)
        {
            //Click on a report link based on instructor
            Logger.LogMethodEntry("Reports", "ClickOnReportLink",
            base.IsTakeScreenShotDuringEntryExit);
            //Click on a report link based on instructor
            new RptMainUXPage().ClickTheReportLink(reportType, userTypeEnum);
            Logger.LogMethodExit("Reports", "ClickOnReportLink",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Perform 'Run Report' or 'Edit Settings' or 'Delete' at 'My reports' based on user.
        /// </summary>
        /// <param name="reportActionOption">Action to be performed on the report.</param>
        /// <param name="reportTypeEnum">Report name enum.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [When(@"I select ""(.*)"" for ""(.*)"" report in 'My Reports' grid by ""(.*)""")]
        public void MyReportActionsThroughCmenu(string reportActionOption,
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
        /// Select All Students Based on instructor.
        /// </summary>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [When(@"I 'Select All' in 'Student Options' by ""(.*)""")]
        public void SelectAllStudents(User.UserTypeEnum userTypeEnum)
        {
            // Check 'Select All' at Students Option base on instructor
            Logger.LogMethodEntry("Reports", "SelectAllStudents",
           base.IsTakeScreenShotDuringEntryExit);
            // Check 'Select All' at Students Option base on instructor
            new RptMainUXPage().SelectAllStudent(userTypeEnum);
            Logger.LogMethodExit("Reports", "SelectAllStudents",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check 'Save settings to my report' base on instructor.
        /// </summary>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [When(@"I select 'save settings to My Reports' option by ""(.*)""")]
        public void CheckSaveSettingsToMyReportsOption(User.UserTypeEnum userTypeEnum)
        {
            //Select 'save settings to My Reports' Option
            Logger.LogMethodEntry("Reports", "SelectSaveSettingsToMyReportsOption",
            base.IsTakeScreenShotDuringEntryExit);
            new RptMainUXPage().SaveSettingsToMyReportCheckByUser(userTypeEnum);
            Logger.LogMethodExit("Reports", "SelectSaveSettingsToMyReportsOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Run Report' or 'Cancel' button based on instructor .
        /// </summary>
        /// <param name="buttonType">This is the action to be performed.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [When(@"I click on the ""(.*)"" button in reports by ""(.*)""")]
        public void ClickReportButton(string buttonType, User.UserTypeEnum userTypeEnum)
        {
            // Select 'Run Report' or 'Cancel' button based on user 
            Logger.LogMethodEntry("Reports", "ClickReportButton",
            base.IsTakeScreenShotDuringEntryExit);
            // Select 'Run Report' or 'Cancel' button based on user 
            new RptMainUXPage().ClickButtonInReportByUser(buttonType, userTypeEnum);
            Logger.LogMethodExit("Reports", "ClickReportButton",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// This selects assessment from assessment window based on user.
        /// </summary>
        /// <param name="assessmentName">This is the asset name.</param>
        /// <param name="assessmentType">This is the asset type.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [When(@"I select ""(.*)"" asset in ""(.*)"" by ""(.*)""")]
        public void SelectTheAssessmentInReport(string assessmentName,
            string assessmentType, User.UserTypeEnum userTypeEnum)
        {
            // This selects assessment from assessment window
            Logger.LogMethodEntry("Reports", "SelectTheAssessmentInReport",
            base.IsTakeScreenShotDuringEntryExit);
            // This selects assessment from assessment window
            new RptMainUXPage().SelectSingleAssessment
                (assessmentName, assessmentType, userTypeEnum);
            Logger.LogMethodExit("Reports", "SelectTheAssessmentInReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the opened criteria page based on user.
        /// </summary>
        /// <param name="criteriaPageName">This is the name of the criteria page.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [Then(@"I should open ""(.*)"" criteria page as ""(.*)""")]
        public void VerifyCriteriaPageOpened(string criteriaPageName, User.UserTypeEnum userTypeEnum)
        {
            // Verify the opened criteria page based on user
            Logger.LogMethodEntry("Reports", "VerifyCriteriaPageOpened",
            base.IsTakeScreenShotDuringEntryExit);
            // Verify the opened criteria page based on user
            Logger.LogAssertion("VerifyCriteriaPageOpened",
              ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(criteriaPageName,
                new RptMainUXPage().GetCriteriaPageName(userTypeEnum)));
            Logger.LogMethodExit("Reports", "VerifyCriteriaPageOpened",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify expected activity in 'Activity Results (Multiple students and activities)' report
        /// </summary>
        /// <param name="expectedActivity">This is the expected activity.</param>
        [Then(@"I should see ""(.*)""")]
        public void VerifyExpectedActivity(string expectedActivity)
        {
            Logger.LogMethodEntry("Reports", "VerifyExpectedActivity",
            base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyCriteriaPageOpened",
              ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(expectedActivity,
                new RptMainUXPage().GetActivityNameFromReport()));
            Logger.LogMethodExit("Reports", "VerifyExpectedActivity",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify report heading ,section name and average score.
        /// </summary>
        /// <param name="reportHeading">This is a heading in the report.</param>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <param name="averageScore">This is average score value.</param>
        [Then(@"I should see the ""(.*)"" with section ""(.*)"" average score ""(.*)""")]
        public void VerifyMultipleActivityReportDataInMultipleStudentAndActivities(string reportHeading,
            Course.CourseTypeEnum courseTypeEnum, string averageScore)
        {
            // Verify report heading ,section name and average score
            Logger.LogMethodEntry("Reports",
                "VerifyMultipleActivityReportDataInMultipleStudentAndActivities",
            base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseTypeEnum);
            //Asserts Report heading value
            Logger.LogAssertion("VerifyCriteriaPageOpened",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                  Assert.AreEqual(reportHeading,
                  new RptAllAssessmentAllStudentPage().GetActivityHeading()));
            //Assert report section name
            Logger.LogAssertion("VerifyCriteriaPageOpened",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                  Assert.AreEqual(course.SectionName,
                   new RptAllAssessmentAllStudentPage().GetSectionName()));
            //Assert report average score value
            Logger.LogAssertion("VerifyCriteriaPageOpened",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
               Assert.AreEqual(averageScore,
               new RptAllAssessmentAllStudentPage().GetAverageScore()));
            Logger.LogMethodExit("Reports",
                "VerifyMultipleActivityReportDataInMultipleStudentAndActivities",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verfies data displayed for the 100% scoring student in the report.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <param name="attempCount">This is the attempt count.</param>
        /// <param name="scorePercentage">This is the score.</param>
        [Then(@"I should see the ""(.*)"" along with attempt as ""(.*)"" score as ""(.*)""")]
        public void Verify100ScoringStudentActivityReportDataInMultipleStudentAndActivities
            (User.UserTypeEnum userTypeEnum,
            string attempCount, string scorePercentage)
        {
            // Verify report heading ,section name and average score
            Logger.LogMethodEntry("Reports",
                "Verify100ScoringStudentActivityReportDataInMultipleStudentAndActivities",
                base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            String firstName = user.FirstName;
            String lastName = user.LastName;
            String studentName = lastName + ", " + firstName;
            //Verify student name
            Logger.LogAssertion("VerifyStudentPresent",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new RptAllAssessmentAllStudentPage().
              IsStudentPresent(studentName)));
            //Verify attempt value
            Logger.LogAssertion("Verify100ScoringStudentAttempts",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(attempCount,
             new RptAllAssessmentAllStudentPage().GetStudentAttempt(studentName)));
            //Verify student score value
            Logger.LogAssertion("VerifyStudentPresent",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new RptAllAssessmentAllStudentPage().
             IsStudentScorePercentagePresent(
                 scorePercentage, studentName)));
            Logger.LogMethodExit("Reports",
       "Verify100ScoringStudentActivityReportDataInMultipleStudentAndActivities",
     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verfies data displayed for the 0% scoring student in the report.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <param name="attempCount"></param>
        /// <param name="scorePercentage"></param>
        [Then(@"I should see 'Zero' ""(.*)"" along with attempt as ""(.*)"" score as ""(.*)""")]
        public void VerifyZeroScoringStudentActivityReportDataInMultipleStudentAndActivities(User.UserTypeEnum userTypeEnum,
            string attempCount, string scorePercentage)
        {
            // Verify report heading ,section name and average score
            Logger.LogMethodEntry("Reports",
              "VerifyZeroScoringStudentActivityReportDataInMultipleStudentAndActivities",
              base.IsTakeScreenShotDuringEntryExit);
            string studentName = new RptAllAssessmentAllStudentPage().
                GetZeroScoreUsername(userTypeEnum);
            //Verify student name
            Logger.LogAssertion("VerifyZeroScoringStudentPresent",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new RptAllAssessmentAllStudentPage().
              IsStudentPresent(studentName)));
            //Verify attempt value
            Logger.LogAssertion("VerifyZeroScoringStudentAttempts",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(attempCount,
             new RptAllAssessmentAllStudentPage().GetStudentAttempt(studentName)));
            //Verify student score
            Logger.LogAssertion("VerifyStudentPresent",
           ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new RptAllAssessmentAllStudentPage().
            IsStudentScorePercentagePresentProgramAdmin(
                scorePercentage, studentName)));
            Logger.LogMethodExit("Reports",
           "VerifyZeroScoringStudentActivityReportDataInMultipleStudentAndActivities",
         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects a section under a template.
        /// </summary>
        /// <param name="sectionNameTypeEnum">This is section name enum.</param>
        /// <param name="templateNameTypeEnum">This is Template name enum.</param>
        [When(@"I select ""(.*)"" section under ""(.*)"" template in 'Section Options'")]
        public void SelectSectionBasedOnTemplate(Course.CourseTypeEnum sectionNameTypeEnum,
            Course.CourseTypeEnum templateNameTypeEnum)
        {
            // Selects a section under a template
            Logger.LogMethodEntry("Reports",
              "SelectSectionBasedOnTemplate",
              base.IsTakeScreenShotDuringEntryExit);
            Course template = Course.Get(templateNameTypeEnum);
            Course course = Course.Get(sectionNameTypeEnum);
            // Selects a section under a template
            new ProgramAdminReportsSubTabPage().SelectSectionBasedOnTemplate
                (course.SectionName, template.Name);
            Logger.LogMethodExit("Reports",
                "SelectSectionBasedOnTemplate",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify report heading and average score when generated by Progam Admin.
        /// </summary>
        /// <param name="reportHeading">This is report heading.</param>
        /// <param name="averageScore">This is average score.</param>
        [Then(@"I should see the ""(.*)"" with average score ""(.*)""")]
        public void VerifyActivityReportDataInMultipleStudentAndActivitiesAtProgramAdmin(string reportHeading,
            string averageScore)
        {
            // Verify report heading ,section name and average score
            Logger.LogMethodEntry("Reports",
                "VerifyActivityReportDataInMultipleStudentAndActivitiesAtProgramAdmin",
            base.IsTakeScreenShotDuringEntryExit);
            //Asserts Report heading value
            Logger.LogAssertion("VerifyCriteriaPageOpened",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                  Assert.AreEqual(reportHeading,
                  new RptAllAssessmentAllStudentPage().GetActivityHeading()));
            //Assert report average score value
            Logger.LogAssertion("VerifyCriteriaPageOpened",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
               Assert.AreEqual(averageScore,
               new RptAllAssessmentAllStudentPage().GetAverageScore()));
            Logger.LogMethodExit("Reports",
                "VerifyActivityReportDataInMultipleStudentAndActivitiesAtProgramAdmin",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verfies data displayed for the 100% scoring student in the Program Admin report.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <param name="sectionNameTypeEnum">This is section name enum.</param>
        /// <param name="attempCount">This is the attempt count.</param>
        /// <param name="scorePercentage">This is the score.</param>
        [Then(@"I should see the ""(.*)"" along with section ""(.*)"" attempt as ""(.*)"" submitted as score as ""(.*)""")]
        public void Verify100ScoreStudentReportDataInMultipleStudentAndActivitiesAtProgramAdmin(
            User.UserTypeEnum userTypeEnum, Course.CourseTypeEnum sectionNameTypeEnum
            , string attempCount, string scorePercentage)
        {
            Logger.LogMethodEntry("Reports",
            "Verify100ScoreStudentReportDataInMultipleStudentAndActivitiesAtProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            String studentName = user.LastName + ", " + user.FirstName;
            Course course = Course.Get(sectionNameTypeEnum);
            //Asserts student name
            Logger.LogAssertion("VerifyStudentPresent",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new RptAllAssessmentAllStudentPage().
              IsStudentPresent(studentName)));
            //Assert student section name
            Logger.LogAssertion("VerifyCriteriaPageOpened",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                  Assert.AreEqual(course.SectionName,
                   new RptAllAssessmentAllStudentPage().GetStudentSectionName(studentName)));
            //Asserts student attempts
            Logger.LogAssertion("Verify100ScoringStudentAttempts",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(attempCount,
             new RptAllAssessmentAllStudentPage().GetStudentAttemptProgramAdmin(studentName)));
            //Asserts student score
            Logger.LogAssertion("VerifyStudentPresent",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new RptAllAssessmentAllStudentPage().
             IsStudentScorePercentagePresentProgramAdmin(
                 scorePercentage, studentName)));
            Logger.LogMethodExit("Reports",
                "Verify100ScoreStudentReportDataInMultipleStudentAndActivitiesAtProgramAdmin",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verfies data displayed for the Zero scoring student in the report.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <param name="sectionNameTypeEnum"></param>
        /// <param name="attempCount">This is the attempt count.</param>
        /// <param name="scorePercentage">This is the score.</param>
        [Then(@"I should see 'Zero' ""(.*)"" along with section ""(.*)"" attempt as ""(.*)"" submitted as score as ""(.*)""")]
        public void VerifyZeroScoringStudentActivityReportDataInMultipleStudentAndActivitiesbyProgramAdmin(
            User.UserTypeEnum userTypeEnum, Course.CourseTypeEnum sectionNameTypeEnum,
            string attempCount, string scorePercentage)
        {
            // Verify report heading ,section name and average score
            Logger.LogMethodEntry("Reports",
              "VerifyZeroScoringStudentActivityReportDataInMultipleStudentAndActivitiesbyProgramAdmin",
              base.IsTakeScreenShotDuringEntryExit);
            string studentName = new RptAllAssessmentAllStudentPage().
                GetZeroScoreUsername(userTypeEnum);
            Course course = Course.Get(sectionNameTypeEnum);
            //Asserts student name
            Logger.LogAssertion("VerifyZeroScoringStudentPresent",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new RptAllAssessmentAllStudentPage().
              IsStudentPresent(studentName)));
            //Assert student section name
            Logger.LogAssertion("VerifyCriteriaPageOpened",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                  Assert.AreEqual(course.SectionName,
                   new RptAllAssessmentAllStudentPage().GetStudentSectionName(studentName)));
            //Asserts student attempts
            Logger.LogAssertion("VerifyZeroScoringStudentAttempts",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(attempCount,
             new RptAllAssessmentAllStudentPage().GetStudentAttemptProgramAdmin(studentName)));
            //Asserts student score
            Logger.LogAssertion("VerifyStudentPresent",
           ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new RptAllAssessmentAllStudentPage().
            IsStudentScorePercentagePresentProgramAdmin(
                scorePercentage, studentName)));
            Logger.LogMethodExit("Reports",
               "VerifyZeroScoringStudentActivityReportDataInMultipleStudentAndActivitiesbyProgramAdmin",
             base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>

        /// <summary>
        /// Select an activity.
        /// </summary>
        /// <param name="activityName">This is activity to be selected.</param>
        [When(@"I select ""(.*)"" asset in 'Select Activity'")]
        public void AddSingleActivity(string activityName)
        {
            // Select an activity
            Logger.LogMethodEntry("Reports",
            "AddSingleActivity",
            base.IsTakeScreenShotDuringEntryExit);
            // Select an activity
            new RptMainUXPage().SelectSingleActivity(activityName);
            Logger.LogMethodExit("Reports",
             "AddSingleActivity",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifies multiple values in “Activity Results (Multiple Students)" Report.
        /// </summary>
        /// <param name="reportHeading">This is report heading.</param>
        /// <param name="courseTypeEnum">This is course type enum name.</param>
        /// <param name="averageScore">This is average score.</param>
        [Then(@"I should see the ""(.*)"" along with section ""(.*)"" average score ""(.*)""")]
        public void VerifyActivityReportDataInMultipleStudents(string reportHeading,
           Course.CourseTypeEnum courseTypeEnum, string averageScore)
        {
            // Verify report heading ,section name and average score
            Logger.LogMethodEntry("Reports",
                "VerifyActivityReportDataInMultipleStudents",
            base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseTypeEnum);
            //Asserts Report heading value
            Logger.LogAssertion("VerifyCriteriaPageOpened",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                  Assert.AreEqual(reportHeading,
                  new RptAssessmentAllStudentsPage().GetActivityHeading()));
            //Assert report section name
            Logger.LogAssertion("VerifyCriteriaPageOpened",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                  Assert.AreEqual(course.SectionName,
                   new RptAssessmentAllStudentsPage().GetSectionName()));
            //Assert report average score value
            Logger.LogAssertion("VerifyCriteriaPageOpened",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
               Assert.AreEqual(averageScore,
               new RptAssessmentAllStudentsPage().GetAverageScore()));
            Logger.LogMethodExit("Reports",
                "VerifyActivityReportDataInMultipleStudents",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select activity in Learning Aid Usage report generation.
        /// </summary>
        /// <param name="activityName">This is a activity name.</param>
        [When(@"I select the ""(.*)"" asset in'Select Activity'")]
        public void AddActivity(string activityName)
        {
            // Select an activity
            Logger.LogMethodEntry("Reports", "AddActivity",
            base.IsTakeScreenShotDuringEntryExit);
            // Select an activity
            new RptMainUXPage().SelectActivity(activityName);
            Logger.LogMethodExit("Reports", "AddActivity",
           base.IsTakeScreenShotDuringEntryExit);
        }


        [Then(@"I should see the ""(.*)"" along with attempt as ""(.*)"" submitted as score as ""(.*)""")]
        public void Verify100ScoreStudentReportDataInMultipleStudentInReports(User.UserTypeEnum userTypeEnum,
            string attempCount, string scorePercentage)
        {
            // Verify report heading ,section name and average score
            Logger.LogMethodEntry("Reports",
                "Verify100ScoreStudentReportDataInMultipleStudentInReports",
                base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            String firstName = user.FirstName;
            String lastName = user.LastName;
            String studentName = lastName + ", " + firstName;
            //Verifies student name
            Logger.LogAssertion("VerifyStudentPresent",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new RptAssessmentAllStudentsPage().
              IsStudentPresent(studentName)));
            //Verifies attemp value
            Logger.LogAssertion("Verify100ScoringStudentAttempts",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(attempCount,
             new RptAssessmentAllStudentsPage().GetStudentAttempt(studentName)));
            //Verify score value
            Logger.LogAssertion("VerifyStudentPresent",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new RptAssessmentAllStudentsPage().
             IsStudentScorePercentagePresent(
                 scorePercentage, studentName)));
            Logger.LogMethodExit("Reports",
                "Verify100ScoreStudentReportDataInMultipleStudentInReports",
              base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see 'Zero' ""(.*)"" along with attempt as ""(.*)"" submitted as score as ""(.*)""")]
        public void VerifyZeroScoreStudentReportDataInMultipleStudentInReports(User.UserTypeEnum userTypeEnum,
            string attempCount, string scorePercentage)
        {
            // Verify report heading ,section name and average score
            Logger.LogMethodEntry("Reports",
              "VerifyZeroScoreStudentReportDataInMultipleStudentInReports",
              base.IsTakeScreenShotDuringEntryExit);
            string studentName = new RptAllAssessmentAllStudentPage().
                GetZeroScoreUsername(userTypeEnum);
            //Verifies student name
            Logger.LogAssertion("VerifyStudentPresent",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new RptAssessmentAllStudentsPage().
              IsStudentPresent(studentName)));
            //Verifies attemp value
            Logger.LogAssertion("Verify100ScoringStudentAttempts",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(attempCount,
             new RptAssessmentAllStudentsPage().GetStudentAttempt(studentName)));
            //Verify score value
            Logger.LogAssertion("VerifyStudentPresent",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new RptAssessmentAllStudentsPage().
             IsStudentScorePercentagePresent(
                 scorePercentage, studentName)));
            Logger.LogMethodExit("Reports",
           "VerifyZeroScoreStudentReportDataInMultipleStudentInReports",
         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifying All the Elements Displayed for first question in Exam Frequency report.
        /// </summary>
        /// <param name="questionName">This is Question Name.</param>
        /// <param name="questionType">This is Question Type.</param>
        /// <param name="applicationType">This is Application Name.</param>
        /// <param name="score">This is Correct Percentage.</param>
        [Then(@"I should see questions details ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void VerifyFirstQuestionDetailsInExamFrequencyReport(string questionName,
            string questionType, string applicationType, string score)
        {
            // Verifying All the Elements Displayed for first question in Exam Frequency report
            Logger.LogMethodEntry("Reports", "VerifyFirstQuestionDetailsInExamFrequencyReport",
               base.IsTakeScreenShotDuringEntryExit);
            //Verifying Activityt Question Displayed in Report
            Logger.LogAssertion("VerifyQuestionName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(questionName.ToString(),
                    new RptExamFreqAnalysisPage().GetExamFrequencyAnalysisReportQuestionName()));
            //Verifying Activity Type Displayed in Report
            Logger.LogAssertion("VerifyQuestionType", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(questionType.ToString(),
                  new RptExamFreqAnalysisPage().GetExamFrequencyAnalysisReportTypeName()));
            //Verifying Application Name Displayed in Report
            Logger.LogAssertion("VerifyApplicationType", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(applicationType.ToString(),
                  new RptExamFreqAnalysisPage().GetExamFrequencyAnalysisReportApplicationName()));
            //Verifying Correct Percentage Displayed in Report
            Logger.LogAssertion("VerifyCorrectPercentage", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(score.ToString(),
                  new RptExamFreqAnalysisPage().GetExamFrequencyAnalysisCorrectPercentInReport()));
            Logger.LogMethodEntry("Reports", "VerifyFirstQuestionDetailsInExamFrequencyReport",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the attempt details for first question in Exam Frequency report.
        /// </summary>
        /// <param name="correctAttempt">This is Correct Attempt.</param>
        /// <param name="inCorrectAttempt">This is Incorrect Attempt.</param>
        /// <param name="skippedAttempt">This is Skipped Attempt.</param>
        [Then(@"I should see correct incorrect and skipped attempt details ""(.*)"" ""(.*)"" ""(.*)""")]
        public void VerifyAttemptDetails(int correctAttempt, int inCorrectAttempt, int skippedAttempt)
        {
            //Verify the attempt details for first question in Exam Frequency report
            Logger.LogMethodEntry("Reports", "VerifyAttemptDetails",
             base.IsTakeScreenShotDuringEntryExit);
            //Verifying Question Correct Attempt Displayed in Report
            Logger.LogAssertion("VerifyCorrectAttempt", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(correctAttempt.ToString(),
                    new RptExamFreqAnalysisPage().GetFirstQuestionCorrectAttempt()));
            //Verifying Question InCorrect Attempt Displayed in Report.
            Logger.LogAssertion("VerifyInCorrectAttempt", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(inCorrectAttempt.ToString(),
                  new RptExamFreqAnalysisPage().GetFirstQuestionIncorrectAttempt()));
            //Verifying Question Skipped Attempt Displayed in Report.
            Logger.LogAssertion("VerifySkippedAttempt", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(skippedAttempt.ToString(),
                  new RptExamFreqAnalysisPage().GetFirstQuestionSkippedAttempt()));
            Logger.LogMethodExit("Reports", "VerifyAttemptDetails",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the details for second question in Exam Frequency report.
        /// </summary>
        /// <param name="questionName">This is Question Name.</param>
        /// <param name="questionType">This is Question Type.</param>
        /// <param name="applicationName">This is Application Name.</param>
        /// <param name="percentScore">This is Correct Percentage.</param>
        [Then(@"I should see question detail ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void VerifySecondQuestionsDetails(string questionName,
            string questionType, string applicationName, string percentScore)
        {
            // Verify the details for second question in Exam Frequency report
            Logger.LogMethodEntry("Reports", "VerifySecondQuestionsDetails",
               base.IsTakeScreenShotDuringEntryExit);
            //Verifying Activity Question Displayed in Report
            Logger.LogAssertion("VerifyQuestionName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(questionName.ToString(),
                    new RptExamFreqAnalysisPage().GetExamFrequencySecondQuestionName()));
            //Verifying Activity Type Displayed in Report
            Logger.LogAssertion("VerifyQuestionType", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(questionType.ToString(), new RptExamFreqAnalysisPage().
                 GetExamFrequencySecondQuestionType()));
            //Verifying Application Name Displayed in Report
            Logger.LogAssertion("VerifyApplicationName", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(applicationName.ToString(), new RptExamFreqAnalysisPage().
                 GetExamFrequencySecondApplicationName()));
            //Verifying Correct Percentage Displayed in Report
            Logger.LogAssertion("VerifyPercentage", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(percentScore.ToString(), new RptExamFreqAnalysisPage().
                   GetExamFrequencySecondActivityPercent()));
            Logger.LogMethodEntry("Reports", "VerifySecondQuestionsDetails",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the attempt details for second question Exam Frequency report.
        /// </summary>
        /// <param name="correctAttempt">This is Correct Attempt.</param>
        /// <param name="inCorrectAttempt">This is Incorrect Attempt.</param>
        /// <param name="skippedAttempt">>This is Skipped Attempt.</param>
        [Then(@"I should see attempt correct incorrect and skipped details ""(.*)"" ""(.*)"" ""(.*)""")]
        public void VerifyAttemptCorrectIncorrectAndSkippedDetailsDisplayed(int correctAttempt,
            int inCorrectAttempt, int skippedAttempt)
        {
            //Verify the attempt details for second question Exam Frequency report
            Logger.LogMethodEntry("Reports", "VerifyAttemptCorrectIncorrectAndSkippedDetailsDisplayed",
             base.IsTakeScreenShotDuringEntryExit);
            //Verifying Question Correct Attempt Displayed in Report
            Logger.LogAssertion("VerifyCorrectAttemptDetails", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(correctAttempt.ToString(), new RptExamFreqAnalysisPage().
                     GetExamFrequencySecondQuestionCorrectAttemptDetails()));
            //Verifying Question InCorrect Attempt Displayed in Report
            Logger.LogAssertion("VerifyInCorrectAttemptDetails", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(inCorrectAttempt.ToString(), new RptExamFreqAnalysisPage().
                 GetExamFrequencySecondQuestionInCorrectAttemptDetails()));
            //Verifying Question Skipped Attempt Displayed in Report
            Logger.LogAssertion("VerifySkippedAttemptDetails", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(skippedAttempt.ToString(), new RptExamFreqAnalysisPage().
                 GetExamFrequencySecondQuestionSkippedAttemptDetails()));
            Logger.LogMethodExit("Reports", "VerifyAttemptCorrectIncorrectAndSkippedDetailsDisplayed",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the average score and activity name in Training frequency analysis report.
        /// </summary>
        /// <param name="chapterName">This is a Chapter name.</param>
        /// <param name="score">This is the Score.</param>
        [Then(@"I should see the ""(.*)"" along with average score ""(.*)""")]
        public void NameAverageScoreDisplayed(string chapterName, string score)
        {
            //Verify the average score and activity name in Training Frequency Analysis Report
            Logger.LogMethodEntry("Reports", "NameAverageScoreDisplayed",
                base.IsTakeScreenShotDuringEntryExit);
            // Verifying the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.Current.ScenarioInfo.Title,
             () => Assert.AreEqual(chapterName.ToString(), new RptTrainingFreqAnalysisPage().
                   GetFrequencyAnalysisActivityNameInReport(chapterName)));
            // Verifying the Activity Score
            Logger.LogAssertion("VerifyActivityScore", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(score.ToString(), new RptTrainingFreqAnalysisPage().
                    GetFrequencyAnalysisScoreInReport(chapterName, score)));
            Logger.LogMethodExit("Reports", "NameAverageScoreDisplayed",
         base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Verify the detalils for first activity in training frequency report. 
        /// </summary>
        /// <param name="questionName">This is the question name.</param>
        /// <param name="applicationName">This is the application name.</param>
        /// <param name="percentScore">this is the percent score.</param>
        [Then(@"I should see question details ""(.*)"" ""(.*)"" ""(.*)""")]
        public void VerifyTrainingfrequencyFirstQuestionDetails(string questionName, string applicationName, string percentScore)
        {
            //Verify the Detalils for First Activity In Training Frequency report
            Logger.LogMethodEntry("Reports", "VerifyTrainingfrequencyFirstQuestionDetails",
             base.IsTakeScreenShotDuringEntryExit);
            //verify Activity question name
            Logger.LogAssertion("VerifyActivityNameDisplayed", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(questionName.ToString(), new RptTrainingFreqAnalysisPage().
                    GetTrainingFrequencyFirstQuestionName()));
            //verify Activity application
            Logger.LogAssertion("VerifyApplicationDisplayed", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(applicationName.ToString(), new RptTrainingFreqAnalysisPage().
                   GetTrainingFrequencyFirstApplicationName()));
            //verify Activity score
            Logger.LogAssertion("VerifySimActivityDetailsDisplayed", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(percentScore.ToString(), new RptTrainingFreqAnalysisPage().
                   GetTrainingFrequencyFirstQuestionPercentage()));
            Logger.LogMethodExit("Reports", "VerifyTrainingfrequencyFirstQuestionDetails",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify the detalils for second activity
        /// </summary>
        /// <param name="simQuestion"></param>
        /// <param name="simApplication"></param>
        /// <param name="simPercentage"></param>
        [Then(@"I should see training question details ""(.*)"" ""(.*)"" ""(.*)""")]
        public void GetTrainingfrequencySecondQuestionDetails(string simQuestion,
            string simApplication, string simPercentage)
        {
            Logger.LogMethodEntry("Reports", "VerifySimActivityDetailsDisplayed",
             base.IsTakeScreenShotDuringEntryExit);
            //Verify the question name
            Logger.LogAssertion("VerifySimActivityDetailsDisplayed", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(simQuestion.ToString(), new RptTrainingFreqAnalysisPage().
                   GetTrainingFrequencyAnalysisSecondQuestionName()));
            //Verify the application name in report
            Logger.LogAssertion("VerifySimActivityDetailsDisplayed", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(simApplication.ToString(), new RptTrainingFreqAnalysisPage().
                   GetTrainingFrequencyAnalysisSecondApplicationName()));
            //Verify the score details in report
            Logger.LogAssertion("VerifySimActivityDetailsDisplayed", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(simPercentage.ToString(), new RptTrainingFreqAnalysisPage().
                   GetTrainingFrequencyAnalysisSecondQuestionPercentage()));
            Logger.LogMethodExit("Reports", "VerifySimActivityDetailsDisplayed",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify the report detalils in training frequency report by program admin.
        /// </summary>
        /// <param name="questionName">This is a questionName.</param>
        /// <param name="courseTypeEnum">This is course name enum.</param>
        /// <param name="applicationName">This is a applicationName.</param>
        /// <param name="percentScore">This is a percentScore.</param>
        [Then(@"I should see the question details ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void VerifyTrainingFrequencyQuestionDetailsByProgramAdmin(string questionName,
           Course.CourseTypeEnum courseTypeEnum, string applicationName, string percentScore)
        {
            Logger.LogMethodEntry("Reports",
                "VerifyTrainingFrequencyQuestionDetailsByProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseTypeEnum);
            //Verify the question name
            Logger.LogAssertion("VerifyQuestionDisplayed",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new RptTrainingFreqAnalysisPage().
              IsQuestionPresent(questionName)));
            //Assert the application name
            Logger.LogAssertion("VerifyApplicationName",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(applicationName, new RptTrainingFreqAnalysisPage().
             GetQuestionDetails(questionName, 2)));
            //Assert the section name
            Logger.LogAssertion("VerifyApplicationName",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(course.SectionName, new RptTrainingFreqAnalysisPage().
             GetQuestionDetails(questionName, 3)));
            //Assert the score
            Logger.LogAssertion("VerifyApplicationName",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(percentScore, new RptTrainingFreqAnalysisPage().
             GetQuestionDetails(questionName, 6)));
            Logger.LogMethodExit("Reports",
                "VerifyTrainingFrequencyQuestionDetailsByProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Report details in Exam frequency analysis by Program Admin.
        /// </summary>
        /// <param name="questionName">This is a QuestionName.</param>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <param name="questionType">This is a Question type.</param>
        /// <param name="applicationName">This is a Application name.</param>
        /// <param name="percentScore">This is a Score.</param>
        [Then(@"I should see details of the question ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void VerifyExamFrequencyQuestionDetailsByProgramAdmin(
            string questionName, Course.CourseTypeEnum courseTypeEnum, string questionType,
            string applicationName, string percentScore)
        {
            Logger.LogMethodEntry("Reports",
                "VerifyExamFrequencyQuestionDetailsByProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseTypeEnum);
            //Verify the question name
            Logger.LogAssertion("VerifyQuestionDisplayed",
              ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new RptExamFreqAnalysisPage().
              IsQuestionPresentInExamFrequencyAnalysis(questionName)));
            //Assert the section name
            Logger.LogAssertion("VerifyApplicationName",
              ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(course.SectionName, new RptExamFreqAnalysisPage().
             GetExamFrequencyAnalysisQuestionDetails(questionName, 3)));
            //Assert the question type name
            Logger.LogAssertion("VerifyApplicationName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(questionType, new RptExamFreqAnalysisPage().
             GetExamFrequencyAnalysisQuestionDetails(questionName, 2)));
            //Assert the application name
            Logger.LogAssertion("VerifyApplicationName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(applicationName, new RptExamFreqAnalysisPage().
             GetExamFrequencyAnalysisQuestionDetails(questionName, 4)));
            //Assert the score
            Logger.LogAssertion("VerifyApplicationName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(percentScore, new RptExamFreqAnalysisPage().
            GetExamFrequencyAnalysisQuestionDetails(questionName, 7)));
            Logger.LogMethodExit("Reports",
                "VerifyExamFrequencyQuestionDetailsByProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Verify the Report details in Learning Aid Usage by Program Admin.
        /// </summary>
        /// <param name="questionName">This is a Question name.</param>
        /// <param name="questionType">This is a Question type.</param>
        /// <param name="sectionName">This is a Section name.</param
        /// <param name="applicationName">This is a Application name.</param>        
        /// <param name="practiceScore">This is a practiceScore.</param>
        /// <param name="videoScore">This is a videoScore.</param>
        [Then(@"I should see the details for the question ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void VerifyLearningAidUsageReportDetailsByProgramAdmin(
           string questionName, string questionType,
           Course.CourseTypeEnum courseTypeEnum,
           string applicationName, string practiceScore, string videoScore)
        {
            Logger.LogMethodEntry("Reports",
                "VerifyLearningAidUsageReportDetailsByProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseTypeEnum);
            //Verify question name
            Logger.LogAssertion("VerifyQuestionNameDisplayed",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new RptLearningAidFrequencyPage().
             IsQuestionPresentInLearningAidUsageReport(questionName)));
            //verify question details
            Logger.LogAssertion("VerifyquestionType",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
               Assert.AreEqual(questionType, new RptLearningAidFrequencyPage().
              GetLearningAidUsageQuestionDetails(questionName, 2)));
            //Assert the question type name
            Logger.LogAssertion("VerifysectionName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(course.SectionName, new RptLearningAidFrequencyPage().
             GetLearningAidUsageQuestionDetails(questionName, 3)));
            //Assert the application name
            Logger.LogAssertion("VerifyApplicationName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(applicationName, new RptLearningAidFrequencyPage().
             GetLearningAidUsageQuestionDetails(questionName, 4)));
            Logger.LogAssertion("VerifyPractiseScore",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(practiceScore, new RptLearningAidFrequencyPage().
             GetLearningAidUsageQuestionDetails(questionName, 6)));
            Logger.LogAssertion("VerifyVideoScore",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(videoScore, new RptLearningAidFrequencyPage().
             GetLearningAidUsageQuestionDetails(questionName, 7)));
            Logger.LogMethodExit("Reports",
                "VerifyLearningAidUsageReportDetailsByProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// Verify the average score and activity name in Learning Aid Usage Report.
        /// </summary>
        /// <param name="chapterName">This is a Chapter name.</param>
        /// <param name="score">This is the Score.</param>
        [Then(@"I should see  ""(.*)"" along with average score ""(.*)""")]
        public void VerifyNameAverageScore(string chapterName, string score)
        {
            //Verify the average score and activity name in Training Frequency Analysis Report
            Logger.LogMethodEntry("Reports", "NameAverageScoreDisplayed",
                base.IsTakeScreenShotDuringEntryExit);
            // Verifying the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.Current.ScenarioInfo.Title,
             () => Assert.AreEqual(chapterName.ToString(), new RptLearningAidFrequencyPage().
                 GetLearningAidUsageActivityNameInReport(chapterName)));
            // Verifying the Activity Score
            Logger.LogAssertion("VerifyActivityScore", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(score.ToString(), new RptLearningAidFrequencyPage().
                   GetLearningAidUsageScoreInReport(score)));
            Logger.LogMethodExit("Reports", "NameAverageScoreDisplayed",
         base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Verify Integrity violation report page.
        /// </summary>
        /// <param name="criteriaPageName">This is the page name.</param>        
        [Then(@"I should be on ""(.*)"" page as HedProgramAdmin")]
        public void VerifyIntegrityViolationReportPage(string criteriaPageName)
        {
            // Verify the opened criteria page based on user
            Logger.LogMethodEntry("Reports", "VerifyIntegrityViolationReportPage",
            base.IsTakeScreenShotDuringEntryExit);
            // Verify the opened criteria page based on user
            Logger.LogAssertion("VerifyCriteriaPageOpened",
              ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(criteriaPageName,
                new RptStudentIntegrityViolationPage().GetPageName()));
            Logger.LogMethodExit("Reports", "VerifyIntegrityViolationReportPage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select section in Integrity violation report generation.
        /// </summary>
        /// <param name="courseTypeEnum">This is a section name.</param>
        [When(@"I select section ID from the dropdown in ""(.*)"" course")]
        public void SelectSectionId(Course.CourseTypeEnum courseTypeEnum)
        {
            //Select section in Integrity violation report generation
            Logger.LogMethodEntry("Reports",
                "SelectSectionID",
                base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseTypeEnum);
            new RptStudentIntegrityViolationPage().
                SelectSectioFromTheDropDown(course.SectionId);
            Logger.LogMethodExit("Reports",
                "SelectSectionID",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click 'Generate' button in reports.
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        [When(@"I click  ""(.*)"" button")]
        public void ClickGenerateButton(string buttonName)
        {
            //Click 'Generate' button in reports
            Logger.LogMethodEntry("Reports",
                "ClickGenerateButton",
                  base.IsTakeScreenShotDuringEntryExit);
            new RptStudentIntegrityViolationPage().SelectGenerateReport(buttonName);
            Logger.LogMethodExit("Reports",
               "SelectSectionID",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the details in Integrity violation report.
        /// </summary>
        /// <param name="rowNumber">This is row number.</param>
        /// <param name="userTypeEnum">This is expected student name enum.</param>
        /// <param name="activityName">This is activity name.</param>
        /// <param name="integrityLevel">This is integrity level.</param>
        /// <param name="integrityViolation">This is integrity violation.</param>
        [Then(@"I should see row ""(.*)"" in the report ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" column details")]
        public void VerifyIntegrityViolationReportDetails(int rowNumber, User.UserTypeEnum userTypeEnum,
            string activityName, string integrityLevel, string integrityViolation)
        {
            //Verify the details in Integrity violation report
            Logger.LogMethodEntry("Reports",
                "VerifyIntegrityViolationReportDetails",
                  base.IsTakeScreenShotDuringEntryExit);
            //Get user details
            User user = User.Get(userTypeEnum);
            //Verify Expected student name
            Logger.LogAssertion("VerifyUserDetailsPresent", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(user.FirstName + " " + user.LastName,
                   new RptStudentIntegrityViolationPage().
            GetIntegrityViolationReportDetails(rowNumber, 1)));
            //Verify Activity name
            Logger.LogAssertion("VerifyActivityName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(activityName, new RptStudentIntegrityViolationPage().
            GetIntegrityViolationReportDetails(rowNumber, 5)));
            //Verify Integrity level
            Logger.LogAssertion("VerifyIntegrityLevel",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(integrityLevel, new RptStudentIntegrityViolationPage().
           GetIntegrityViolationReportDetails(rowNumber, 7)));
            //Verify integrity violated or not
            Logger.LogAssertion("VerifyIntegrityViolation",
           ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.AreEqual(integrityViolation, new RptStudentIntegrityViolationPage().
          IsIntegrityViolated(rowNumber)));
            Logger.LogMethodExit("Reports",
               "VerifyIntegrityViolationReportDetails",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the 'Zero Scoring Student'details in Integrity violation report.
        /// </summary>
        /// <param name="rowNumber">This is row number.</param>
        /// <param name="scenerioName">This is the type of student.</param>
        /// <param name="userTypeEnum">This is Expected student name.</param>
        /// <param name="activityName">This is activity name.</param>
        /// <param name="integrityLevel">This is integrity level.</param>
        /// <param name="integrityViolation">This is integrity violation.</param>
        [Then(@"I should see row ""(.*)"" in the report ""(.*)"" for ""(.*)"" ""(.*)"" with ""(.*)"" ""(.*)"" column details")]
        public void VerifyIntegrityViolationReportDetailsForZeroScoreSudent
            (int rowNumber, string scenerioName, User.UserTypeEnum userTypeEnum,
            string activityName, string integrityLevel, string integrityViolation)
        {
            //Verify the 'Zero Scoring Student'details in Integrity violation report.
            Logger.LogMethodEntry("Reports",
                "VerifyIntegrityViolationReportDetailsForZeroScoreSudent",
                  base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = new GBInstructorUXPage().FetchTheUserDetails(scenerioName, userTypeEnum);
            //Verify Expected student name
            Logger.LogAssertion("VerifyUserDetailsPresent", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(user.FirstName + " " + user.LastName,
                   new RptStudentIntegrityViolationPage().
            GetIntegrityViolationReportDetails(rowNumber, 1)));
            //Verify Activity name
            Logger.LogAssertion("VerifyActivityName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(activityName, new RptStudentIntegrityViolationPage().
            GetIntegrityViolationReportDetails(rowNumber, 5)));
            //Verify Integrity level
            Logger.LogAssertion("VerifyIntegrityLevel",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(integrityLevel, new RptStudentIntegrityViolationPage().
           GetIntegrityViolationReportDetails(rowNumber, 7)));
            //Verify integrity violated or not
            Logger.LogAssertion("VerifyIntegrityViolation",
           ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.AreEqual(integrityViolation, new RptStudentIntegrityViolationPage().
          IsIntegrityViolated(rowNumber)));
            Logger.LogMethodExit("Reports",
                "VerifyIntegrityViolationReportDetailsForZeroScoreSudent",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// See Report Under Report Page.
        /// </summary>
        /// <param name="reportName">This is report name.</param>
        [Then(@"I should see ""(.*)"" report under report page")]
        public void SeeReportUnderReportPage(string reportName)
        {
            // verify report present on page
            Logger.LogMethodEntry("Reports", "SeeReportUnderReportPage",
               base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyReportIsPresent", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(reportName,
                  new RptMainUXPage().GetCertificatesReportsName()));
            Logger.LogMethodExit("Reports", "SeeReportUnderReportPage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// View Report Page Opened.
        /// </summary>
        /// <param name="reportPageHeader">This is report header.</param>
        [Then(@"I should see ""(.*)"" header present")]
        public void ViewReportPageOpened(string reportPageHeader)
        {
            // verify report opened and report header present.
            Logger.LogMethodEntry("Reports", "ViewReportPageOpened",
               base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyReportHeaderIsPresent", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(reportPageHeader,
                  new RptMainUXPage().GetReportFrameHeader()));
            Logger.LogMethodExit("Reports", "ViewReportPageOpened",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify the 'Learning Aid Frequency' report details by Section instructor.
        /// </summary>
        /// <param name="rowNumber">This is the question row number.</param>
        /// <param name="questionName">This is the question name.</param>
        /// <param name="questionType">This is the question type.</param>
        /// <param name="sectionName">This is the section name.</param>
        /// <param name="applicationName">This is the application name.</param>
        /// <param name="practiseScore">This is the practise score.</param>
        /// <param name="videoScore">This is the video score.</param>
        [Then(@"I should see the details of the row number ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""")]
        public void VerifyLearningAidFrequencyReportBySectionInstructor(int rowNumber, string questionName,
            string questionType, string sectionName, string applicationName,
            string practiseScore, string videoScore)
        {
            //Verify the 'Learning Aid Frequency' report details by Section instructor
            Logger.LogMethodEntry("Reports",
                "VerifyLearningAidFrequencyReportBySectionInstructor",
                  base.IsTakeScreenShotDuringEntryExit);
            //Verify Question name
            Logger.LogAssertion("VerifyQuestionNameDisplayed",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new RptLearningAidFrequencyPage().
             IsQuestionPresentInLearningAidUsageReport(questionName)));
            //Verify Question type
            Logger.LogAssertion("VerifyIntegrityLevel",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(questionType, new RptLearningAidFrequencyPage().
           GetLearningAidFrequencyQuestionDetailsBySectionInstructor(
           questionName, rowNumber, 2)));
            //Verify Application Name
            Logger.LogAssertion("VerifyIntegrityViolation",
           ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.AreEqual(applicationName, new RptLearningAidFrequencyPage().
          GetLearningAidFrequencyQuestionDetailsBySectionInstructor(
          questionName, rowNumber, 4)));
            //Verify Practise Score 
            Logger.LogAssertion("VerifyIntegrityViolation",
           ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.AreEqual(practiseScore, new RptLearningAidFrequencyPage().
          GetLearningAidFrequencyQuestionDetailsBySectionInstructor(
          questionName, rowNumber, 6)));
            //Verify Video Score 
            Logger.LogAssertion("VerifyIntegrityViolation",
           ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.AreEqual(videoScore, new RptLearningAidFrequencyPage().
          GetLearningAidFrequencyQuestionDetailsBySectionInstructor(
          questionName, rowNumber, 7)));
            Logger.LogMethodExit("Reports",
               "VerifyLearningAidFrequencyReportBySectionInstructor",
               base.IsTakeScreenShotDuringEntryExit);
        }      

    }

}

