using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages;
using Pegasus.Automation.DataTransferObjects;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
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
    }
}
