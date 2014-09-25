using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducation.WL.Tests.
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
        [When(@"I clicked on the ""(.*)"" link")]
        public void ClickedOnTheStudentEnrollmentLink(
            String getReportLink)
        {
            // Click on the Student Enrollment link
            Logger.LogMethodEntry("ProgramAdminReports",
                "ClickedOnTheStudentEnrollmentLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Student Enrollment link
            new RptMainPage().SelectReport(getReportLink);
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
            new RptSaveReportPage().SelectSectionToGenerateReport();
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);
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
            new RptSaveReportPage().ClickOnSelectStudentButton();
            //Select Window
            new RptSelectStudentsPage().SelectStudentsWindow();
            // Select Student
            new RptSelectStudentsPage().SelectStudentInProgramAdminReport();
            Logger.LogMethodExit("ProgramAdminReports", "SelectStudent",
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
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);
            //Assert to verify section name
            Logger.LogAssertion("VerifySectionName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(course.SectionName
                    + ProgramAdminReportsResource.ProgramAdminReports_Page_Space_Value_One,
                    rptStudentUsagePage.
                    GetSectionName((RptStudentUsagePage.ProgramAdminReportType)Enum.
                    Parse(typeof(RptStudentUsagePage.ProgramAdminReportType), reportType))));
            //Assert to verify status
            Logger.LogAssertion("VerifyStatus", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.AreEqual(ProgramAdminReportsResource.
                 ProgramAdminReports_Page_Status_Value, rptStudentUsagePage.GetStatusText
                 ((RptStudentUsagePage.ProgramAdminReportType)Enum.
                Parse(typeof(RptStudentUsagePage.ProgramAdminReportType), reportType))));
            Logger.LogMethodExit("ProgramAdminReports", "ProgramAdminReportLaunchedSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Select Sections.
        /// </summary>
        [When(@"I clicked on 'Select Sections'")]
        public void ClickOnSelectSections()
        {
            // Click On Select Sections
            Logger.LogMethodEntry("ProgramAdminReports", "ClickOnSelectSections",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Select Sections button
            new RptSaveReportPage().SelectSectionToGenerateReport();
            Logger.LogMethodExit("ProgramAdminReports", "ClickOnSelectSections",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Show/Hide Sections Link.
        /// </summary>        
        [When(@"I click on 'Show Sections' link")]
        [When(@"I click on 'Hide Sections' link")]
        public void ClickOnShowHideSectionsLink()
        {
            //Click On Show/Hide Sections Link
            Logger.LogMethodEntry("ProgramAdminReports",
                "ClickOnShowHideSectionsLink",
               base.IsTakeScreenShotDuringEntryExit);
            //Click On Show/Hide Sections Link
            new RptSelectSectionsPage().ClickOnShowHideSectionLink();
            Logger.LogMethodExit("ProgramAdminReports",
                "ClickOnShowHideSectionsLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display Of Section.
        /// </summary>
        [Then(@"I should see the section")]
        public void VerifyTheDisplayOfSection()
        {
            //Verify The Display Of Section
            Logger.LogMethodEntry("ProgramAdminReports", "VerifyTheDisplayOfSection",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);
            //Assert to verify section name
            Logger.LogAssertion("VerifyTheDisplayOfSection", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new RptSelectSectionsPage().IsSectionNameDisplay(course.SectionName +
                    ProgramAdminReportsResource.ProgramAdminReports_Page_Space_Value_One)));
            Logger.LogMethodExit("ProgramAdminReports", "VerifyTheDisplayOfSection",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Hidden State Of Section And Display Of Expand Button.
        /// </summary>
        [Then(@"I should not see the section")]
        public void VerifyHiddenStateOfSectionAndDisplayOfExpandButton()
        {
            //Verify The Hidden State Of Section
            Logger.LogMethodEntry("ProgramAdminReports",
                "VerifyHiddenStateOfSectionAndDisplayOfExpandButton",
               base.IsTakeScreenShotDuringEntryExit);
            RptSelectSectionsPage rptSelectSelectionsPage = new RptSelectSectionsPage();
            //Assert to Verify The Hidden State Of Section
            Logger.LogAssertion("VerifyTheHiddenStateOfSections", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsFalse(
                    rptSelectSelectionsPage.IsSectionPresent()));
            //Assert to Verify The Display Of Expand Button
            Logger.LogAssertion("VerifyTheDisplayOfExpandButton", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                    (ProgramAdminReportsResource.
                    ProgramAdminReports_Page_Expand_Button_Title_Value,
                    rptSelectSelectionsPage.GetExpandCollapseButtonTitle()));
            Logger.LogMethodExit("ProgramAdminReports",
                "VerifyHiddenStateOfSectionAndDisplayOfExpandButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Message In Select Sections PopUp.
        /// </summary>
        /// <param name="message">This is Error Message In Select Sections Popup.</param>
        [Then(@"I should see the message ""(.*)"" in select sections popup")]
        public void VerifyTheMessageInSelectSectionsPopUp(string message)
        {
            //Verify The Message In Select Sections PopUp
            Logger.LogMethodEntry("ProgramAdminReports",
                "VerifyTheMessageInSelectSectionsPopUp",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert to verify message in select sections pop up
            Logger.LogAssertion("VerifyTheMessageInSelectSectionsPopUp", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(message,
                    new RptSelectSectionsPage().GetSelectSectionsPopupMessage()));
            Logger.LogMethodExit("ProgramAdminReports",
                "VerifyTheMessageInSelectSectionsPopUp",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Expand Link.
        /// </summary>
        [When(@"I click on expand link")]
        public void ClickOnExpandLink()
        {
            //Click On Expand Link
            Logger.LogMethodEntry("ProgramAdminReports", "ClickOnExpandLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Expand Link
            new RptSelectSectionsPage().ClickOnExpandLink();
            Logger.LogMethodExit("ProgramAdminReports", "ClickOnExpandLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Collapse Link.
        /// </summary>
        [When(@"I click on collapse link")]
        public void ClickOnCollapseLink()
        {
            //Click On Collapse Link
            Logger.LogMethodEntry("ProgramAdminReports", "ClickOnCollapseLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Collapse Link
            new RptSelectSectionsPage().ClickOnCollapseLink();
            Logger.LogMethodExit("ProgramAdminReports", "ClickOnCollapseLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button In Select Sections Popup.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        [When(@"I click on ""(.*)"" button in select sections popup")]
        public void ClickOnButtonInSelectSectionsPopup(string buttonName)
        {
            //Click On Button In Select Sections Popup
            Logger.LogMethodEntry("ProgramAdminReports", "ClickOnButtonInSelectSectionsPopup",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Button In Select Sections Popup
            new RptSelectSectionsPage().ClickOnTheButtonInSelectSectionsPopup(
                (RptSelectSectionsPage.
                SelectSectionsPopupButtonTypeEnum)Enum.Parse(typeof(
                RptSelectSectionsPage.SelectSectionsPopupButtonTypeEnum), buttonName));
            Logger.LogMethodExit("ProgramAdminReports", "ClickOnButtonInSelectSectionsPopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Radio Button In Section Options Frame.
        /// </summary>
        /// <param name="statusRadioButtonName">This is Section Status Radio Button Name.</param>
        [When(@"I select ""(.*)"" radio button in section options")]
        public void SelectRadioButtonInSectionOptions(string statusRadioButtonName)
        {
            //Select Radio Button In Section Options Frame
            Logger.LogMethodEntry("ProgramAdminReports", "SelectRadioButtonInSectionOptions",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Radio Button In Section Options Frame
            new RptSaveReportPage().SelectSectionStatusRadioButton(
                (RptSaveReportPage.SectionStatusRadioButtonTypeEnum)Enum.Parse(typeof(
                RptSaveReportPage.SectionStatusRadioButtonTypeEnum), statusRadioButtonName));
            Logger.LogMethodExit("ProgramAdminReports", "SelectRadioButtonInSectionOptions",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display Of Both Active And Inactive Sections.
        /// </summary>
        [Then(@"I should see both active and inactive sections")]
        public void VerifyDisplayOfBothActiveAndInactiveSections()
        {
            //Verify Display Of Both Active And Inactive Sections
            Logger.LogMethodEntry("ProgramAdminReports",
                "VerifyDisplayOfBothActiveAndInactiveSections",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);
            //Assert to verify First section name
            Logger.LogAssertion("VerifyTheDisplayOfSections", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new RptSelectSectionsPage().IsSectionNameDisplay(course.Name +
                    ProgramAdminReportsResource.ProgramAdminReports_Page_Space_Value_One)));
            //Assert to verify Second section name
            Logger.LogAssertion("VerifyTheDisplayOfSections", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new RptSelectSectionsPage().IsSectionNameDisplay(course.Name +
                    ProgramAdminReportsResource.ProgramAdminReports_Page_Space_Value_Two)));
            Logger.LogMethodExit("ProgramAdminReports",
                "VerifyDisplayOfBothActiveAndInactiveSections",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Save Settings To My Reports Option.
        /// </summary>
        [When(@"I select 'save settings to My Reports' option")]
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
        /// Verify The Enrollment Date In Student Enrollment Report.
        /// </summary>
        [Then(@"I should see the enrollment date")]
        public void VerifyTheEnrollmentDateInStudentEnrollmentReport()
        {
            //Verify The Enrollment Date In Student Enrollment Report
            Logger.LogMethodEntry("ProgramAdminReports",
                "VerifyTheEnrollmentDateInStudentEnrollmentReport",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);
            //Get Enrollment Date
            string enrollmentDate = course.EnrollmentDate.ToString(
                ProgramAdminReportsResource.ProgramAdminReports_Page_Date_Format);
            //Assert to verify The Display Of Enrollment Date In Student Enrollment Report
            Logger.LogAssertion("VerifyTheEnrollmentDateInStudentEnrollmentReport", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(enrollmentDate,
                    new RptStudentUsagePage().GetEnrollmentDate()));
            Logger.LogMethodExit("ProgramAdminReports",
                "VerifyTheEnrollmentDateInStudentEnrollmentReport",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Last Login Date In Student Enrollment Report.
        /// </summary>
        [Then(@"I should see the last login date in report")]
        public void VerifyTheLastLoginDateInStudentEnrollmentReport()
        {
            //Verify The Last Login Date In Student Enrollment Report
            Logger.LogMethodEntry("ProgramAdminReports",
                "VerifyTheLastLoginDateInStudentEnrollmentReport",
               base.IsTakeScreenShotDuringEntryExit);
            //Get User From Memory            
            User user = User.Get(User.UserTypeEnum.CsSmsStudent);
            //Get Last Login Date
            string lastLoginDate = user.LastLogin.ToString(
                ProgramAdminReportsResource.ProgramAdminReports_Page_Date_Format);
            //Assert to verify The Display Of Last Login Date In Student Enrollment Report
            Logger.LogAssertion("VerifyTheLastLoginInStudentEnrollmentReport", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(lastLoginDate,
                    new RptStudentUsagePage().GetLastLoginDate()));
            Logger.LogMethodExit("ProgramAdminReports",
               "VerifyTheLastLoginDateInStudentEnrollmentReport",
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
        /// Verify Display Of All The Fields In Student Enrollment Report.
        /// </summary>
        [Then(@"I should see all the fields in 'Student Enrollment' report")]
        public void VerifyDisplayOfAllTheFieldsInStudentEnrollmentReport()
        {
            //Verify Display Of All The Fields In Student Enrollment Report
            Logger.LogMethodEntry("ProgramAdminReports",
                  "VerifyDisplayOfAllTheFieldsInStudentEnrollmentReport",
                  base.IsTakeScreenShotDuringEntryExit);
            //Fetch Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);
            //Assert To Verify Display Of Section Options Fields
            Logger.LogAssertion("VerifySectionOptionsFields", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(ProgramAdminReportsResource.
                    ProgramAdminReports_Page_SectionOptions_AllFields_Text + course.SectionName
                    + ProgramAdminReportsResource.ProgramAdminReports_Page_Space_Value_One,
                    new RptSaveReportPage().GetSectionOptionsFields()));
            //Assert To Verify Display Of Student Options Fields
            Logger.LogAssertion("VerifyStudentOptionsFields", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new RptSaveReportPage().IsStudentOptionsFieldsPresent()));
            //Assert To Verify Display Of Date Options Fields
            Logger.LogAssertion("VerifyDateOptionsFields", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new RptSaveReportPage().IsDateOptionsFieldsPresent()));
            //Assert To Verify Display Of Paging Options Fields
            Logger.LogAssertion("VerifyPagingOptionsFields", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new RptSaveReportPage().IsPagingOptionsFieldsPresent())); 
            Logger.LogMethodExit("ProgramAdminReports",
              "VerifyDisplayOfAllTheFieldsInStudentEnrollmentReport",
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
