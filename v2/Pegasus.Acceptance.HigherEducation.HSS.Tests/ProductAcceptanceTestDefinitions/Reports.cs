using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages;
using Pegasus.Automation.DataTransferObjects;
using TechTalk.SpecFlow;
using Pegasus.Pages.CommonResource;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;


namespace Pegasus.Acceptance.HigherEducation.HSS.Tests.ProductAcceptanceTestDefinitions
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
        /// Verify the details of "Student report by activity" report generated.
        /// </summary>
        /// <param name="courseTypeEnum"></param>
        /// <param name="userTypeEnum"></param>
        /// <param name="averageScore">This is the Average score.</param>      
        [Then(@"I should see the section name ""(.*)"" for ""(.*)"" with average score ""(.*)""")]
        public void VerifySectionNameAndAverageScoreInStudentReportByActivity(
            Course.CourseTypeEnum courseTypeEnum, User.UserTypeEnum userTypeEnum, string averageScore)
        {
            //Verify the details of "Student report by activity" report generated
            Logger.LogMethodEntry("Reports",
                "VerifySectionNameAndAverageScoreInStudentReportByActivity",
            base.IsTakeScreenShotDuringEntryExit);
            string studentName = new RptStudentReportByActivityPage().
                GetStudentUsername(userTypeEnum);
            Course course = Course.Get(courseTypeEnum);
            User user = User.Get(userTypeEnum);
            //Verify student name
            Logger.LogAssertion("VerifyStudentName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(studentName, new RptStudentReportByActivityPage().
              GetStudentAndSectionNameInReport(1)));
            //Verify section name
            Logger.LogAssertion("VerifysectionName",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(course.SectionName, new RptStudentReportByActivityPage().
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
        /// <summary>
        /// Verify The Activity Details In Activity Result By Student Report.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <param name="averageScore">This is expected average score.</param>
        [Then(@"I should see the ""(.*)"" with section name ""(.*)"" with average score ""(.*)""")]
        public void VerifyTheActivityDetailsInActivityResultByStudentReport(string activityName,
            Course.CourseTypeEnum courseTypeEnum, string averageScore)
        {
            // Verify The Activity Details In Activity Result By Student Report
            Logger.LogMethodEntry("Reports",
                "VerifyTheActivityDetailsInActivityResultByStudentReport",
            base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseTypeEnum);
            //Verify Activity name
            Logger.LogAssertion("VerifyStudentName",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(activityName, new RptActivityResultByStudentPage().
              GetActivityDetailsInReport(1)));
            //Verify section name
            Logger.LogAssertion("VerifysectionName",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(course.SectionName, new RptActivityResultByStudentPage().
            GetActivityDetailsInReport(2)));
            //Verify average score
            Logger.LogAssertion("VerifyActivityAverageScore",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(averageScore, new RptActivityResultByStudentPage().
              GetAverageScoreInTheReport()));
            Logger.LogMethodExit("Reports",
                "VerifyTheActivityDetailsInActivityResultByStudentReport",
            base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Verify Zero Scoring Details In Activity Report By Student.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <param name="scorePercentage">This is expected percentage.</param>
        [Then(@"I should see 'Zero' ""(.*)"" along with submitted score as ""(.*)""")]
        public void VerifyZeroScoringDetailsInActivityReportByStudent(
            User.UserTypeEnum userTypeEnum, string scorePercentage)
        {
            // Verify report heading ,section name and average score
            Logger.LogMethodEntry("Reports",
              "VerifyZeroScoringDetailsInActivityReportByStudent",
              base.IsTakeScreenShotDuringEntryExit);
            string studentName = new RptAllAssessmentAllStudentPage().
                GetZeroScoreUsername(userTypeEnum);
            //Verify student name
            Logger.LogAssertion("VerifyZeroScoringStudentPresent",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new RptActivityResultByStudentPage().
              GetStudentNameInActivityResultByStudent(studentName)));
            //Verify student score
            Logger.LogAssertion("VerifyStudentPresent",
           ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(scorePercentage, new RptActivityResultByStudentPage().
            GetStudentScoreInActivityResultByStudent(1)));
            Logger.LogMethodExit("Reports",
           "VerifyZeroScoringDetailsInActivityReportByStudent",
         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify 100 Scoring Details In Activity Report By Student
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <param name="scorePercentage">This is the percentage.</param>
        [Then(@"I should see the ""(.*)"" along with attempt submitted as score as ""(.*)""")]
        public void Verify100ScoringDetailsInActivityReportByStudent
            (User.UserTypeEnum userTypeEnum,
             string scorePercentage)
        {
            // Verify report heading ,section name and average score
            Logger.LogMethodEntry("Reports",
                "Verify100ScoringDetailsInActivityReportByStudent",
                base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            String firstName = user.FirstName;
            String lastName = user.LastName;
            String studentName = lastName + ", " + firstName;
            //Verify student name
            Logger.LogAssertion("VerifyZeroScoringStudentPresent",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new RptActivityResultByStudentPage().
              GetStudentNameInActivityResultByStudent(studentName)));
            //Verify student score value
            Logger.LogAssertion("VerifyStudentPresent",
            ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(scorePercentage, new RptActivityResultByStudentPage().
            GetStudentScoreInActivityResultByStudent(1)));
            Logger.LogMethodExit("Reports",
       "Verify100ScoringDetailsInActivityReportByStudent",
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
        /// Verify score in study plan report.
        /// </summary>
        /// <param name="averageScore">This is the expected average score.</param>
        [Then(@"I should see average score ""(.*)""")]
        public void StudyPlanAverageScoreDisplayed(string averageScore)
        {
            // Verify score in study plan report
            Logger.LogMethodEntry("Reports", "StudyPlanAverageScoreDisplayed",
          base.IsTakeScreenShotDuringEntryExit);
            // Verifying the Activity Score
            Logger.LogAssertion("StudyPlanAverageScoreDisplayed", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(averageScore.ToString(), new RptStudyPlanReportPage().
                   GetAverageHSSstudyPlanScoreInReport()));
            Logger.LogMethodEntry("Reports", "StudyPlanAverageScoreDisplayed",
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
        /// Verify Student Study Plan Details In Reports
        /// </summary>
        /// <param name="userTypeEnum"></param>
        /// <param name="preTestScore"></param>
        /// <param name="postTestScore"></param>
        [Then(@"I should see 'Zero' ""(.*)"" along with Pre-test ""(.*)"" Post-test ""(.*)""")]
        public void VerifyStudentStudyPlanDetailsInReports(User.UserTypeEnum userTypeEnum,
            string preTestScore, string postTestScore)
        {
            // Verify report heading ,section name and average score
            Logger.LogMethodEntry("Reports",
              "VerifyZeroScoreStudentReportDataInMultipleStudentInReports",
              base.IsTakeScreenShotDuringEntryExit);
            string studentName = new RptAllAssessmentAllStudentPage().
                GetZeroScoreUsername(userTypeEnum);
            //Verifies student name
            Logger.LogAssertion("GetStudentNameInStudtPlanActivity",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new RptStudyPlanReportPage().
              GetStudentNameInStudtPlanActivity(studentName)));
            //Verifies Pre test Score value
            Logger.LogAssertion("GetStudentStudyPlanPreTestScore",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(preTestScore,
             new RptStudyPlanReportPage().GetStudentStudyPlanPreTestScore(studentName, 2)));
            //Verify  Post Test score value
            Logger.LogAssertion("GetStudentStudyPlanPostTestScore",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(preTestScore,
             new RptStudyPlanReportPage().GetStudentStudyPlanPostTestScore(studentName, 2)));
            Logger.LogMethodExit("Reports",
           "VerifyStudentStudyPlanDetailsInReports",
         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify report heading ,section name and average score in study plan report.
        /// </summary>
        /// <param name="userTypeEnum"></param>
        /// <param name="attempCount"></param>
        /// <param name="scorePercentage"></param>
        [Then(@"I should see the ""(.*)"" along with  Pre-test ""(.*)"" Post-test ""(.*)""")]
        public void Verify100ScoreStudentDetailsInHSSStudyPlanReports(User.UserTypeEnum userTypeEnum,
          string preTestScore, string postTestScore)
        {
            // Verify report heading ,section name and average score
            Logger.LogMethodEntry("Reports",
                "Verify100ScoreStudentDetailsInHSSStudyPlanReports",
                base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            String firstName = user.FirstName;
            String lastName = user.LastName;
            String studentName = lastName + ", " + firstName;
            //Verifies student name
            Logger.LogAssertion("GetStudentNameInStudtPlanActivity",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new RptStudyPlanReportPage().
              GetStudentNameInStudtPlanActivity(studentName)));
            //Verifies attemp value
            Logger.LogAssertion("GetStudentStudyPlanPreTestScore",
              ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.AreEqual(preTestScore,
              new RptStudyPlanReportPage().
              GetStudentStudyPlanPreTestScore(studentName, 6)));
            //Verify score value
            Logger.LogAssertion("GetStudentStudyPlanPostTestScore",
           ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.AreEqual(postTestScore,
             new RptStudyPlanReportPage().
             GetStudentStudyPlanPostTestScore(studentName, 6)));
            Logger.LogMethodExit("Reports",
                "Verify100ScoreStudentDetailsInHSSStudyPlanReports",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select student for report generation.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <param name="studentButtonName">This is button name.</param>
        [When(@"I select ""(.*)"" student in ""(.*)""")]
        public void SelectStudentByProgramAdmin(User.UserTypeEnum userTypeEnum,
            string studentButtonName)
        {
            // Select student for report generation
            Logger.LogMethodEntry("Reports",
                             "SelectStudentByProgramAdmin",
                             base.IsTakeScreenShotDuringEntryExit);
            new RptStudentReportByActivityPage().AddStudentToReport(
                studentButtonName, userTypeEnum);
            Logger.LogMethodExit("Reports",
               "SelectStudentByProgramAdmin",
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
