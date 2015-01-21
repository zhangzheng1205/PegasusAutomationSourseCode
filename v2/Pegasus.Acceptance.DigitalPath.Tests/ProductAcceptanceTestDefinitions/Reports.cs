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
        [Then(@"I should see the Attempt number as ""(.*)"" for ""(.*)""")]
        public void ValidateAttemptNumber(string attemptNumber, User.UserTypeEnum userType)
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
              GetAttemptFromReportsWindow(user.Name)));
            Logger.LogMethodExit("Reports", "ValidateAttemptNumber",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate percentage from generated report
        /// </summary>
        /// <param name="percentage">Expected percentage.</param>
        /// <param name="userTypeEnum">Type of user.</param>
        [Then(@"I should see the ""(.*)"" in Percent column for ""(.*)""")]
        public void ValidatePercentageDisplay(string percentage, User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("Reports","ValidatePercentageDisplay",
           base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            //Validate expected and actual percentage are matching
            Logger.LogAssertion("ValidatePercentageDisplay",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(percentage, new RptAllAssessmentAllStudentPage().GetstudentPercentFromReportsWindow(user.Name)));
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


    }
}
