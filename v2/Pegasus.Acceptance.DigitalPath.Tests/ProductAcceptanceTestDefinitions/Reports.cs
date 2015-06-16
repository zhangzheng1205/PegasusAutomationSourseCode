using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus.Pages.CommonPageObjects;
using Pegasus.Automation.DataTransferObjects;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using System.Configuration;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Discussion;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;

namespace Pegasus.Acceptance.DigitalPath.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    class Reports : PegasusBaseTestFixture
    {

        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(Reports));

        /// <summary>
        /// Click on report link under reports tab.
        /// </summary>
        /// <param name="reportName">Report name to access.</param>
        /// <param name="userTypeEnum">Type of user accessing reports link.</param>
        [When(@"I click on ""(.*)"" report link as ""(.*)""")]
        public void ClickOnReportLink(string reportName, User.UserTypeEnum userTypeEnum)
        {
            //Access reports link
            Logger.LogMethodEntry("Reports", "ClickOnReportLink",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on a report link under reports tab
            new RptMainUXPage().ClickReportLinkInReportsTab(reportName, userTypeEnum);
            Logger.LogMethodExit("Reports", "ClickOnReportLink",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select activity in reports criteria page.
        /// </summary>
        /// <param name="assessmentName">Name of the activity to select.</param>
        /// <param name="assessmentType">Button name in reports criteria page.</param>
        /// <param name="userTypeEnum">Type of user selecting activities.</param>
        [When(@"I select ""(.*)"" student in ""(.*)"" by ""(.*)""")]
        [When(@"I select ""(.*)"" asset in ""(.*)"" by ""(.*)""")]
        public void SelectActivityInReportsCriteriaPage(string assessmentName, string assessmentType,
            User.UserTypeEnum userTypeEnum)
        {
            //Select activity for which report needs to be run
            Logger.LogMethodEntry("Reports", "SelectActivityInReportsCriteriaPage",
               base.IsTakeScreenShotDuringEntryExit);
            //Select activity for which report needs to be run
            new RptMainUXPage().SelectSingleAssessment
                (assessmentName, assessmentType, userTypeEnum);
            Logger.LogMethodExit("Reports", "SelectActivityInReportsCriteriaPage",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select student in Individual student mastery cretiria page to generate the report
        /// </summary>
        /// <param name="assessmentName">This is the name of the Asset.</param>
        /// <param name="assessmentType">This is the asset type.</param>
        /// <param name="userTypeEnum">This is the usertype enum.</param>
        /// <param name="windowName">This is the window name</param>
        [When(@"I select ""(.*)"" in ""(.*)"" by ""(.*)"" in ""(.*)""")]
        public void SelectStudentInReportsCriteriaPage(string assessmentName, string assessmentType,
            User.UserTypeEnum userTypeEnum, string windowName)
        {
            //Select activity for which report needs to be run
            Logger.LogMethodEntry("Reports", "SelectActivityInReportsCriteriaPage",
               base.IsTakeScreenShotDuringEntryExit);
            //Select activity for which report needs to be run
            new RptMainUXPage().SelectSingleAssessment
                (assessmentName, assessmentType, userTypeEnum, windowName);
            Logger.LogMethodExit("Reports", "SelectActivityInReportsCriteriaPage",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student from the Select student popup
        /// </summary>
        /// <param name="studentUser">This is to get the Student user.</param>
        /// <param name="buttonName">This is to get the button name.</param>
        [When(@"I select a ""(.*)"" in ""(.*)""")]
        public void TeacherSelectStudentClassMastery(User.UserTypeEnum studentUser, string buttonName)
        {
            // Select Student from the add student popup
            Logger.LogMethodEntry("Reports", "TeacherSelectStudentClassMastery", base.IsTakeScreenShotDuringEntryExit);
            new RptMainUXPage().SelectStudentClassMasteryReport(studentUser, buttonName);
            Logger.LogMethodExit("Reports", "TeacherSelectStudentClassMastery", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate Student Display In Student Result Criteria Page
        /// </summary>
        /// <param name="userName">This is the username.</param>
        [Then(@"I should see the added Student ""(.*)"" in Report criteria page")]
        public void ValidateStudentDisplayInStudentResultCriteriaPage(User.UserTypeEnum userName)
        {
            //Validate the added student display in criteria 
            Logger.LogMethodEntry("Reports", "ValidateStudentDisplayInStudentResultCriteriaPage",
               base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userName);
            String userLastName = user.LastName.ToString();
            String userFirstName = user.FirstName.ToString();
            String userLastFirstName = (userLastName + ", " + userFirstName).Trim();
            String userDetails = userLastFirstName.Replace(", ", string.Empty).Trim();
            Logger.LogAssertion("ValidateStudentDisplayInStudentResultCriteriaPage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(userDetails, new RptMainUXPage().
                    getAddedStudentNameFromStudenActivityCriteriaPage()));
            Logger.LogMethodExit("Reports", "ValidateStudentDisplayInStudentResultCriteriaPage",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Mastery reports link
        /// </summary>
        [When(@"I generate the ""(.*)"" for ""(.*)"" skill")]
        public void SelectMasteryReportsLink(string instructorReportType, string skillName)
        {
            //Select Class Mastery Report link
            Logger.LogMethodEntry("ViewReports", "SelectInstructorReportsLink",
                base.IsTakeScreenShotDuringEntryExit);
            new RptMainUXPage().ClickTheMasteryReportsLink
            ((RptMainUXPage.PegasusInstructorReportEnum)Enum.Parse
            (typeof(RptMainUXPage.PegasusInstructorReportEnum), instructorReportType));
            Logger.LogMethodExit("ViewReports", "SelectInstructorReportsLink",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select students in reports criteria page.
        /// </summary>
        /// <param name="userTypeEnum">Type of user selecting students.</param>
        [When(@"I 'Select All' in 'Student Options' by ""(.*)""")]
        public void SelectStudentsInReportsCriteriaPage(User.UserTypeEnum userTypeEnum)
        {
            //Select students
            Logger.LogMethodEntry("Reports", "SelectStudentsInReportsCriteriaPage",
               base.IsTakeScreenShotDuringEntryExit);
            new RptMainUXPage().SelectAllStudent(userTypeEnum);
            Logger.LogMethodExit("Reports", "SelectStudentsInReportsCriteriaPage",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select save report check box.
        /// </summary>
        /// <param name="userTypeEnum">Type of user saving report.</param>
        [When(@"I select 'save settings to My Reports' option by ""(.*)""")]
        public void SelectSaveReportCheckBox(User.UserTypeEnum userTypeEnum)
        {
            //Select save report check box
            Logger.LogMethodEntry("Reports", "SelectStudentsInReportsCriteriaPage",
               base.IsTakeScreenShotDuringEntryExit);
            //Select save report settings check box
            new RptMainUXPage().SaveSettingsToMyReportCheckByUser(userTypeEnum);
            Logger.LogMethodExit("Reports", "SelectStudentsInReportsCriteriaPage",
              base.IsTakeScreenShotDuringEntryExit);
        }
         
        /// <summary>
        /// Click on run report button.
        /// </summary>
        /// <param name="buttonType">Button name.</param>
        /// <param name="userTypeEnum">Type of user running report.</param>
        [When(@"I click on the ""(.*)"" button in reports by ""(.*)""")]
        public void RunReport(string buttonType, User.UserTypeEnum userTypeEnum)
        {
            //Run report
            Logger.LogMethodEntry("Reports", "RunReport",base.IsTakeScreenShotDuringEntryExit);
            //Click on run report button
            new RptMainUXPage().ClickButtonInReportByUser(buttonType, userTypeEnum);
            Logger.LogMethodExit("Reports", "RunReport",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on create new report radio button.
        /// </summary>
        /// <param name="radiobuttonName">Name of radio button.</param>
        [When(@"I select ""(.*)"" radiobutton")]
        public void SelectCreateNewRadioButton(string radiobuttonName)
        {
            //Select create new report radio button
            Logger.LogMethodEntry("Reports", "SelectCreateNewRadioButton", 
                base.IsTakeScreenShotDuringEntryExit);
            new RptSaveSettingsPage().SelectRadioButtonInSaveSettingsPopup(
               (RptSaveSettingsPage.SaveSettingsPopupRadiobuttonTypeEnum)Enum.Parse(typeof(
               RptSaveSettingsPage.SaveSettingsPopupRadiobuttonTypeEnum), radiobuttonName));
            Logger.LogMethodExit("Reports", "SelectCreateNewRadioButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter report name.
        /// </summary>
        /// <param name="reportTypeEnum">Type of report.</param>
        [When(@"I enter the ""(.*)"" report name")]
        public void EnterReportNameToSave(Report.ReportTypeEnum reportTypeEnum)
        {
            //Enter report name for saving
            Logger.LogMethodEntry("Reports", "EnterReportNameToSave",
               base.IsTakeScreenShotDuringEntryExit);
            Guid reportName = Guid.NewGuid();
            RptSaveSettingsPage rptSaveSettingsPage = new RptSaveSettingsPage();
            //Enter Report Name
            rptSaveSettingsPage.EnterReportName(reportName);
            //Stor Report Name
            rptSaveSettingsPage.StoreReportDetailsInMemory(reportName, reportTypeEnum);
            Logger.LogMethodExit("Reports", "EnterReportNameToSave",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Skills radio button.
        /// </summary>
        /// <param name="radioButtonName">Radio button name.</param>
        [When(@"I select the ""(.*)"" radio button")]
        public void SelectRadioButtion(string radioButtonName)
        {
            //Select skill radio button for generating report
            Logger.LogMethodEntry("Reports", "SelectRadioButtion",
              base.IsTakeScreenShotDuringEntryExit);
            //Select skill radio button
            new RptCommonCriteriaPage().SelectSkillStdOption();
            Logger.LogMethodExit("Reports", "SelectRadioButtion",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on select skills/standards button.
        /// </summary>
        [When(@"I click on Select Standards button")]
        public void ClickOnSelectStandardsButton()
        {
            //Click on select skills/standards button for selecting skills/standards
            Logger.LogMethodEntry("Reports", "ClickOnSelectStandardsButton",
              base.IsTakeScreenShotDuringEntryExit);
            new RptCommonCriteriaPage().ClickSelectSkillButton();
            Logger.LogMethodExit("Reports", "ClickOnSelectStandardsButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select skills/Standards from the drop down.
        /// </summary>
        /// <param name="skillName">Skill name to be selected.</param>
        [When(@"I select ""(.*)"" skills from the drop down")]
        public void SelectSkillsFromTheDropDown(string skillName)
        {
            //Select skills from the drop down to add to reports
            Logger.LogMethodEntry("Reports", "SelectSkillsFromTheDropDown",
             base.IsTakeScreenShotDuringEntryExit);
            new RptCommonCriteriaPage().SelectTheSkillsFromLightBox(skillName);
            Logger.LogMethodExit("Reports", "SelectSkillsFromTheDropDown",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate data in generated report.
        /// </summary>
        /// <param name="columnName">Column name in generated report.</param>
        [Then(@"I should see ""(.*)"" data")]
        public void ValidateReportData(string columnName)
        {
            Logger.LogMethodEntry("Reports", "ValidateReportData",
             base.IsTakeScreenShotDuringEntryExit);
            new RptStudentActivityPage().GetStudentDataFromStudentActivityReport(columnName);
            Logger.LogMethodExit("Reports", "ValidateReportData",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch detailed report.
        /// </summary>
        [When(@"I Click on Detailed Report button")]
        public void ClickOnDetailedReportButton()
        {
            //Generate detailed report
            Logger.LogMethodEntry("Reports", "ClickOnDetailedReportButton",
               base.IsTakeScreenShotDuringEntryExit);
            new RptStudentActivityPage().SelectDetailedReport();
            Logger.LogMethodExit("Reports", "ClickOnDetailedReportButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the data in generated detailed student activity report.
        /// </summary>
        /// <param name="columnData">Column name to validate the data.</param>
        [Then(@"I should see ""(.*)"" data in detailed student activity pop up")]
        public void ValidateDataInGeneratedDetailedReport(string columnData)
        {
            //Validate the data in generated detailed student activity report.
            Logger.LogMethodEntry("Reports", "ValidateDataInGeneratedDetailedReport",
              base.IsTakeScreenShotDuringEntryExit);
            new RptDetailedStudentActivityPage().
                GetStudentDataFromDetailedStudentActivityReport(columnData);
            Logger.LogMethodExit("Reports", "ValidateDataInGeneratedDetailedReport",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Expand the row to view detailed report.
        /// </summary>
        [When(@"I expand the date in detailed student activity report pop up")]
        public void ExpandtheRowInDetailedActivityreportPopUp()
        {
            //Expand the row to view detailed report.
            Logger.LogMethodEntry("Reports", "ExpandtheRowInDetailedActivityreportPopUp",
              base.IsTakeScreenShotDuringEntryExit);
            new RptDetailedStudentActivityPage().ClickTheExpandLink(0);
            Logger.LogMethodExit("Reports", "ExpandtheRowInDetailedActivityreportPopUp",
          base.IsTakeScreenShotDuringEntryExit);
        }

        
        /// <summary>
        /// Click on button in save settings pop up.
        /// </summary>
        /// <param name="buttonName">Button name to click.</param>
        [When(@"I click on ""(.*)"" button")]
        public void ClickButtonInSaveSettingsPopUp(string buttonName)
        {
            //Click on button in save settings pop up
            Logger.LogMethodEntry("Reports", "ClickButtonInSaveSettingsPopUp",
               base.IsTakeScreenShotDuringEntryExit);
            //Click On Button In Save Settings Popup
            new RptSaveSettingsPage().ClickOnButtonInSaveSettingsPopup(
                (RptSaveSettingsPage.SaveSettingsPopupButtonTypeEnum)Enum.Parse(typeof(
                RptSaveSettingsPage.SaveSettingsPopupButtonTypeEnum), buttonName));
            Logger.LogMethodExit("Reports", "ClickButtonInSaveSettingsPopUp",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Navigate to reports tab.
        /// </summary>
        /// <param name="tabName">Tab name to navigate</param>
        [When(@"I navigate to the ""(.*)"" tab in DP class")]
        public void NavigateToReportsTab(string tabName)
        {
            //Navigate to tab in DP class course
            Logger.LogMethodEntry("Reports", "NavigateToReportsTab",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate to tab
            new TodaysViewUxPage().ClickLinkInMoreDropdown(tabName);
            Logger.LogMethodExit("Reports", "NavigateToReportsTab",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of pop up.
        /// </summary>
        /// <param name="expectedPageTitle">Window title.</param>
        [Then(@"I should see ""(.*)"" popup")]
        public void ValidateDisplayOfPopUp(String expectedPageTitle)
        {
            //Verify Correct Page Opened
            Logger.LogMethodEntry("Reports", "ValidateDisplayOfPopUp",
                base.IsTakeScreenShotDuringEntryExit);
            //wait for the window
            base.WaitUntilWindowLoads(expectedPageTitle);
            //Get current opened page title
            string actualPageTitle =
                WebDriver.Title.ToString(CultureInfo.InvariantCulture);
            //Assert we have correct page opened
            Logger.LogAssertion("ValidateDisplayOfPopUp",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedPageTitle, actualPageTitle));
            Logger.LogMethodExit("Reports", "ValidateDisplayOfPopUp",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate data displayed in generated report.
        /// </summary>
        /// <param name="activityName">Expected activity name.</param>
        /// <param name="courseTypeEnum">Course type.</param>
        /// <param name="averageScore">Expected average score.</param>
        [Then(@"I should see the ""(.*)"" with course name ""(.*)"" with average score ""(.*)""")]
        public void ValidateReportData(string activityName, Course.CourseTypeEnum courseTypeEnum, string averageScore)
        {
            // Verify The Activity Details In Activity Result By Student Report
            Logger.LogMethodEntry("Reports",
                "ValidateReportData",
            base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseTypeEnum);
            //Verify Activity name
            Logger.LogAssertion("VerifyStudentName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(activityName, new RptActivityResultByStudentPage().
              GetActivityDetailsInReport(1)));
            //Verify class name
            Logger.LogAssertion("VerifysectionName",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(course.Name, new RptActivityResultByStudentPage().
            GetSectionNameInInstructorReport()));
            //Verify average score
            Logger.LogAssertion("VerifyActivityAverageScore",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(averageScore, new RptActivityResultByStudentPage().
              GetAverageScoreInTheReport()));
            Logger.LogMethodExit("Reports",
                "ValidateReportData",
            base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see the ""(.*)"" class with course name ""(.*)""")]
        public void ValidateMasteryReportData(Class.ClassTypeEnum classTypeEnum, Course.CourseTypeEnum courseTypeEnum)
        {
            // Verify The Activity Details In Activity Result By Student Report
            Logger.LogMethodEntry("Reports",
                "ValidateMasteryReportData",
            base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseTypeEnum);
            Class className = Class.Get(classTypeEnum);
            //Verify Class name
            Logger.LogAssertion("VerifyStudentName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(className.Name, new RptActivityResultByStudentPage().GetClassNameInMasteryReport()));
            //Verify Course name
            Logger.LogAssertion("VerifysectionName",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(course.Name, new RptActivityResultByStudentPage().GetCourseNameInMasteryReport()));
            //////Verify Graphexistance
            //Logger.LogAssertion("VerifyActivityAverageScore",
            // ScenarioContext.Current.ScenarioInfo.Title, () =>
            //  Assert.AreEqual(true, new RptActivityResultByStudentPage().
            //  GetGraphExistanceStatus()));
            Logger.LogMethodExit("Reports",
                "ValidateMasteryReportData",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of score in the Reports page.
        /// </summary>
        /// <param name="p0"></param>
        [Then(@"I see ""(.*)"" score in the reports page")]
        public void ValidateScoreInReports(String score)
        {
            Logger.LogMethodEntry("Reports","ValidateScoreInReports",base.IsTakeScreenShotDuringEntryExit);

            RptActivityResultByStudentPage rptActivityResultByStudentPage = new RptActivityResultByStudentPage();
            rptActivityResultByStudentPage.getScoreClassMastaryReport();
            Logger.LogAssertion("VerifyActivityAverageScore", ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(score,rptActivityResultByStudentPage.getScoreClassMastaryReport()));
            Logger.LogMethodExit("Reports", "ValidateScoreInReports", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate the activity type displayed in generated report.
        /// </summary>
        /// <param name="activityType">Expected activity type.</param>
        [Then(@"I should see the ""(.*)"" as Activity type")]
        public void ValidateActivityType(string activityType)
        {
            //Validate activity type
            Logger.LogMethodEntry("Reports",
                "ValidateActivityType",
            base.IsTakeScreenShotDuringEntryExit);
            //Validate expected and actual activity types are matching
            Logger.LogAssertion("ValidateActivityType",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(activityType, new RptAllAssessmentAllStudentPage().GetActivityType()));
            Logger.LogMethodExit("Reports",
                "ValidateActivityType",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate attempt number from generated report.
        /// </summary>
        /// <param name="attemptNumber">Expected attempt number.</param>
        /// <param name="userType">Type of user generating report.</param>
        [Then(@"I should see the Attempt number as ""(.*)"" for ""(.*)"" in ""(.*)"" report")]
        public void ValidateAttemptNumber(string attemptNumber, User.UserTypeEnum userType, string reportName)
        {
            //Validat attempt number
            Logger.LogMethodEntry("Reports",
               "ValidateAttemptNumber",
           base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userType);
            //Validat expected and actual attempt numbers are matching
            Logger.LogAssertion("ValidateAttemptNumber",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(attemptNumber, new RptAllAssessmentAllStudentPage().
              GetAttemptFromReportsWindow(user.Name, reportName)));
            Logger.LogMethodExit("Reports", "ValidateAttemptNumber",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate percentage from generated report
        /// </summary>
        /// <param name="percentage">Expected percentage.</param>
        /// <param name="userTypeEnum">Type of user.</param>
        [Then(@"I should see the ""(.*)"" in Percent column for ""(.*)"" in ""(.*)"" report")]
        public void ValidatePercentageDisplay(string percentage, User.UserTypeEnum userTypeEnum, 
            string reportName)
        {
            Logger.LogMethodEntry("Reports","ValidatePercentageDisplay",
           base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            //Validate expected and actual percentage are matching
            Logger.LogAssertion("ValidatePercentageDisplay",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(percentage, new RptAllAssessmentAllStudentPage().
              GetstudentPercentFromReportsWindow(user.LastName, reportName)));
            Logger.LogMethodExit("Reports", "ValidatePercentageDisplay",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Run Saved report from reports tab.
        /// </summary>
        /// <param name="reportActionOption">Type of action to be performed on saved report.</param>
        /// <param name="reportTypeEnum">Type of report.</param>
        /// <param name="userTypeEnum"></param>
        [When(@"I select ""(.*)"" for ""(.*)"" report in 'My Reports' grid by ""(.*)""")]
        public void RunSavedReport(string reportActionOption, Report.ReportTypeEnum reportTypeEnum, User.UserTypeEnum userTypeEnum)
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
        /// Verify the details of "Student report by activity" report generated.
        /// </summary>
        /// <param name="courseTypeEnum"></param>
        /// <param name="userTypeEnum"></param>
        /// <param name="averageScore">This is the Average score.</param>      
        [Then(@"I should see the course name ""(.*)"" for ""(.*)"" with average score ""(.*)""")]
        public void VerifySectionNameAndAverageScoreInStudentReportByActivity(
            Course.CourseTypeEnum courseTypeEnum, User.UserTypeEnum userTypeEnum, string averageScore)
        {
            //Verify the details of "Student report by activity" report generated
            Logger.LogMethodEntry("Reports",
                "VerifySectionNameAndAverageScoreInStudentReportByActivity",
            base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseTypeEnum);
            string studentName = new RptStudentReportByActivityPage().
                GetStudentUsername(userTypeEnum);
            User user = User.Get(userTypeEnum);
            //Verify student name
            Logger.LogAssertion("VerifyStudentName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(studentName, new RptStudentReportByActivityPage().
              GetStudentAndSectionNameInReport(1)));
            //Verify section name
            Logger.LogAssertion("VerifysectionName",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(course.Name, new RptStudentReportByActivityPage().
            GetStudentAndSectionNameInReport(2)));
            //Verify Average score
            Logger.LogAssertion("VerifyStudentAveragescore",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(averageScore, new RptStudentReportByActivityPage().
              GetAverageScoreInReport()));
            Logger.LogMethodExit("Reports",
                "VerifySectionNameAndAverageScoreInStudentReportByActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify the details of the Student report by activity Report.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="activityType">This is the activity type.</param>
        [Then(@"I should see ""(.*)"" ""(.*)"" details in the report")]
        public void VerifyTheReportDetailsInStudentRepoprtByActivity(
            string activityName, string activityType)
        {
            // Verify the details of the Student report by activity Report
            Logger.LogMethodEntry("Reports",
                "VerifyTheReportDetailsInStudentRepoprtByActivity",
            base.IsTakeScreenShotDuringEntryExit);
            //Verify activity name
            Logger.LogAssertion("VerifyActivityName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(activityName, new RptStudentReportByActivityPage().
              GetReportDetails(1)));
            //Verify Activity type
            Logger.LogAssertion("VerifyActivityType",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(activityType, new RptStudentReportByActivityPage().
              GetReportDetails(2)));
            Logger.LogMethodExit("Reports",
                "VerifyTheReportDetailsInStudentRepoprtByActivity",
            base.IsTakeScreenShotDuringEntryExit);
        }


    }
}
