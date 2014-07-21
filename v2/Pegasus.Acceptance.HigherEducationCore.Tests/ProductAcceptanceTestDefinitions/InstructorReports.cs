using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.HigherEducation.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of Instructor Report
    /// and to handle different types of instructor reports.
    /// </summary>
    [Binding]
    public class InstructorReports : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(InstructorReports));

        /// <summary>
        /// Generate Report by Selecting Activity and Student.
        /// </summary>
        /// <param name="instructorReportType">This is Instructor Report Type.</param>
        /// <param name="userType">This is user type</param>
         [When(@"I generate the ""(.*)"" of student ""(.*)""")]
        public void ManageInstructorReport(
             String instructorReportType, User.UserTypeEnum userType)
        {
            //Method to Generate Activity Result By Student Report
            Logger.LogMethodEntry("InstructorReports", "ManageInstructorReport",
                base.isTakeScreenShotDuringEntryExit);
            User userName = User.Get(userType);
            //Converting String to Enum to pass report by type
            new RptMainUXPage().ManageInstructorReport((RptMainUXPage.
                PegasusInstructorReportEnum)Enum.
                Parse(typeof(RptMainUXPage.PegasusInstructorReportEnum),
                instructorReportType),userName.Name);
            Logger.LogMethodExit("InstructorReports", "ManageInstructorReport",
                base.isTakeScreenShotDuringEntryExit);
        }
     
        /// <summary>
        ///  Verify Score and Activity Name in the Generated Report.
        /// </summary>
        [Then(@"I should successfully see the student name and score under launched report")]
        public void SeeTheStudentNameAndScoreUnderLaunchedReport()
        {
            //Method to Check Score and Student Name in the Launched Report 
            Logger.LogMethodEntry("InstructorReports",
                "SeeTheStudentNameAndScoreUnderLaunchedReport",
                 base.isTakeScreenShotDuringEntryExit);
            //Assert Activity Score
            Logger.LogAssertion("VerifyScore", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(InstructorReportsResource.
                    InstructorReports_ActivityGrade_Score_Value,
                    Convert.ToString(new RptAssessmentAllStudentsPage().
                    GetActivityScore().Substring(Convert.ToInt32(InstructorReportsResource.
                    InstructorReports_ActivityGrade_Substring_Start_Value), Convert.ToInt32(
                    InstructorReportsResource.InstructorReports_ActivityGrade_Substring_End_Value)))));
            //Assert Activity Name
            Logger.LogAssertion("VerifyName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(InstructorReportsResource
                    .InstructorReports_Student_LastName, Convert.ToString
                (new RptAssessmentAllStudentsPage().GetStudentName())));
            Logger.LogMethodExit("InstructorReports",
                "SeeTheStudentNameAndScoreUnderLaunchedReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Score and Activity Name in the Generated Report.
        /// </summary>
        [Then(@"I should successfully see the activity name and score under launched report")]
        public void VerifyTheActivityNameAndScoreUnderLaunchedReport()
        {
            //Method to Check Score and Student Name in the Launched Report 
            Logger.LogMethodEntry("InstructorReports",
                "VerifyTheActivityNameAndScoreUnderLaunchedReport",
                 base.isTakeScreenShotDuringEntryExit);
            //Assert Activity Score
            Logger.LogAssertion("VerifyActivityScore", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(InstructorReportsResource.
                    InstructorReports_Activity_Score_Value,
                    new RptAssessmentAllStudentsPage().GetManuallyGradedScore().Substring(
                    Convert.ToInt32(InstructorReportsResource.
                    InstructorReports_ActivityGrade_Substring_Start_Value), Convert.ToInt32(
                    InstructorReportsResource.InstructorReports_ActivityGrade_Substring_End_Value))));
            //Assert Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(InstructorReportsResource.InstructorReports_Activity_Name,
                    new RptAssessmentAllStudentsPage().GetActivityName()));
            Logger.LogMethodExit("InstructorReports",
               "VerifyTheActivityNameAndScoreUnderLaunchedReport",
               base.isTakeScreenShotDuringEntryExit);
        }

       /// <summary>
        /// Select Report And Click On Select Activity Button.
       /// </summary>
       /// <param name="buttonName">This is Button Name.</param>
        [When(@"I select the report and click on ""(.*)""")]
        public void SelectReportAndClickOnSelectActivityButton(string buttonName)
        {
            //Select Report And Click On Select Activity Button
            Logger.LogMethodEntry("InstructorReports",
                "SelectReportAndClickOnSelectActivityButton",
                 base.isTakeScreenShotDuringEntryExit);
            //Select Report
            new RptMainUXPage().SelectReport();
            //Select Activity Button In Report
            new RptGCOptionsUXPage().SelectButtonInReport(buttonName);
            Logger.LogMethodExit("InstructorReports",
               "SelectReportAndClickOnSelectActivityButton",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display Of Activity In Select Activities Window.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="activityBehavioralModesEnum">This is Activity Behavioral Mode Enum.</param>
        [Then(@"I should see ""(.*)"" activity of behavioral mode ""(.*)""")]
        public void VerifyDisplayOfActivityInSelectActivitiesWindow(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum activityBehavioralModesEnum)
        {
            //Verify Display Of Activity In Select Activities Window
            Logger.LogMethodEntry("InstructorReports",
                 "VerifyDisplayOfActivityInSelectActivitiesWindow",
                  base.isTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, activityBehavioralModesEnum);
            //Assert To Verify The Display Of Activity In Select Activities Window
            Logger.LogAssertion("VerifyDisplayOfActivityInSelectActivitiesWindow",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                (new RptSelectAssessmentsPage().GetActivityName(activity.Name))));            
            Logger.LogMethodExit("InstructorReports",
               "VerifyDisplayOfActivityInSelectActivitiesWindow",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Verify Display of StudyPlan, StudentName and Average Score in study Plan Results report window
        /// </summary>
        [Then(@"I should successfully see the studyplan name, student name and average score under launched report")]
        public void VerifyTheStudyPlanNameAndStudentNameUnderLaunchedReport()
        {
            //Method to Check Score and Student Name in the Launched Report 
            Logger.LogMethodEntry("InstructorReports",
                "VerifyTheStudyPlanNameAndStudentNameUnderLaunchedReport",
                 base.isTakeScreenShotDuringEntryExit);
            RptStuStudyPlanPage StuStudyPlanPage = new RptStuStudyPlanPage();
            //Assert StudyPlan Name
            Logger.LogAssertion("VerifyStudyPlanName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(InstructorReportsResource
                     .InstructorReports_StudyPlan_Name, StuStudyPlanPage.GetStudyPlanName()));            
            //Assert Student Name
            Logger.LogAssertion("VerifyStudentName", ScenarioContext.Current.ScenarioInfo.Title,
                 () => Assert.AreEqual(InstructorReportsResource
                     .InstructorReports_Student_LastName, StuStudyPlanPage.GetStudentName()));
            //Assert Student score
            Logger.LogAssertion("VerifyAverageScore", ScenarioContext.Current.ScenarioInfo.Title,
                 () => Assert.AreEqual(InstructorReportsResource
                     .InstructorReports_StudyPlan_Score, StuStudyPlanPage.GetAverageScore()));
            Logger.LogMethodExit("InstructorReports",
               "VerifyTheStudyPlanNameAndStudentNameUnderLaunchedReport",
               base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// This method is called before execution of test.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// This function is called after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }

    }
}
