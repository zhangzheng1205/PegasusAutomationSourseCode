using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages;
using Pegasus.Automation.DataTransferObjects;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.WritingSpace.Tests.ProductAcceptanceTestDefinitions
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
        /// Select Options to Generate Report By Instructor.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activty Type Enum.</param>
        [When(@"I select options to generate report by instructor for ""(.*)"" Activity")]
        public void SelectOptionstoGenerateReportByInstructor(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Select Options to Generate Report By Instructor
            Logger.LogMethodEntry("Reports",
                "SelectOptionstoGenerateReportByInstructor",
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch the activity from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Report window and Frame
            new RptMainUXPage().SelectReportsWindowandFrame();
            //Select Options to Generate Report
            new RptSaveReportPage().
                SelectOptionstoGenerateActivityResultReport(activity.Name);
            Logger.LogMethodExit("Reports",
                "SelectOptionstoGenerateReportByInstructor",
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
        /// To Verify The Score in Activity Result Single Student Report.
        /// </summary>
        /// <param name="activityScore">This is Activity Score.</param>
        [Then(@"I should see the score ""(.*)"" in Activity Result Single Student generated report")]
        public void ToVerifyScoreinActivityResultSingleStudentReport(string activityScore)
        {
            //To Verify The Score in Activity Result Single Student Report
            Logger.LogMethodEntry("Reports",
                "ToVerifyScoreinActivityResultSingleStudentReport",
            base.IsTakeScreenShotDuringEntryExit);
            //Assert To Verify Score in Generated Report
            Logger.LogAssertion("VerifyScoreInReport", ScenarioContext.
             Current.ScenarioInfo.Title, () => Assert.AreEqual(activityScore,
             new RptStudentAllAssessmentsPage().
                       GetActivityResultSingleStudentScoreInReport()));
            Logger.LogMethodExit("Reports",
                "ToVerifyScoreinActivityResultSingleStudentReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Generate Instructor Report.
        /// </summary>
        /// <param name="instructorReportType">This is Instructor Report Type.</param>
        /// <param name="userType">This is user type Enum.</param>
        [When(@"I generate the ""(.*)"" report of ""(.*)""")]
        public void ManageInstructorReport(
             String instructorReportType, User.UserTypeEnum userType)
        {
            //Generate Instructor Report
            Logger.LogMethodEntry("Reports", "ManageInstructorReport",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Username
            User userName = User.Get(userType);
            //Fetch Writing space Activity
            Activity activityName = Activity.Get(Activity.ActivityTypeEnum.WritingSpace);
            //Generate Instructor Report
            new RptMainUXPage().GenerateInstructorReport((RptMainUXPage.
                PegasusInstructorReportEnum)Enum.
                Parse(typeof(RptMainUXPage.PegasusInstructorReportEnum),
                instructorReportType), userName.LastName, activityName.Name);
            Logger.LogMethodExit("Reports", "ManageInstructorReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Verify Score and Student Name in the Generated Report.
        /// </summary>
        [Then(@"I should successfully see the student name and score under launched report")]
        public void VerifyStudentNameAndScoreUnderLaunchedReport()
        {
            //Verify Score and Student Name in the Generated Report 
            Logger.LogMethodEntry("InstructorReports",
                "VerifyStudentNameAndScoreUnderLaunchedReport",
                 base.IsTakeScreenShotDuringEntryExit);
            //Fetch User
            User user = User.Get(User.UserTypeEnum.MMNDStudent);            
            //Assert Activity Score
            Logger.LogAssertion("VerifyScore", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(ReportsResource.Reports_Writingspace_Activity_Score_Value,
                    Convert.ToString(new RptAssessmentAllStudentsPage().
                    GetWritingspaceActivityScore().Substring(Convert.ToInt32(
                    ReportsResource.Reports_ActivityScore_Start_Index_Value), Convert.ToInt32(
                    ReportsResource.Reports_ActivityScore_Boundary_Index_Value)))));
            //Assert Student Name
            Logger.LogAssertion("VerifyName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.LastName, Convert.ToString
                (new RptAssessmentAllStudentsPage().GetWritingspaceStudentNameInReport())));
            Logger.LogMethodExit("InstructorReports",
                "VerifyStudentNameAndScoreUnderLaunchedReport",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
