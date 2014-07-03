using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.NovaNET.Tests.Definitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles the View Reports Actions.
    /// </summary
    [Binding]
    public class ViewReports : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(ViewReports));
      
        /// <summary>
       /// Generate Student Activity Report.
        /// </summary>
       /// <param name="instructorReportType">This is Instructor Report Type.</param>
       /// <param name="userType">This is user type</param>
       [When(@"I generate the ""(.*)"" of student ""(.*)""")]
        public void GenerateStudentActivityReport(
           String instructorReportType, User.UserTypeEnum userType)
       {
           //Generate Student Activity Report
           Logger.LogMethodEntry("ViewReports", "GenerateStudentActivityReport",
               base.isTakeScreenShotDuringEntryExit);
           User userName = User.Get(userType);
           //Converting String to Enum to pass report by type
           new RptMainUXPage().ManageInstructorReport
               ((RptMainUXPage.PegasusInstructorReportEnum)Enum.Parse
               (typeof(RptMainUXPage.PegasusInstructorReportEnum), instructorReportType),userName.Name);
           Logger.LogMethodExit("ViewReports", "GenerateStudentActivityReport",
                base.isTakeScreenShotDuringEntryExit);
       }

        /// <summary>
       /// Display The Grades Under Launched Report.
        /// </summary>
       [When(@"It Should display the grades under launched report")]
       public void DisplayTheGradesUnderLaunchedReport()
       {
           //Display The Grades Under Launched Report
           Logger.LogMethodEntry("ViewReports",
               "DisplayTheGradesUnderLaunchedReport",
               base.isTakeScreenShotDuringEntryExit);
           //Select Detailed Report
           new RptStudentActivityPage().SelectDetailedReport();
           Logger.LogMethodExit("ViewReports", 
               "DisplayTheGradesUnderLaunchedReport",
               base.isTakeScreenShotDuringEntryExit);
       }

        /// <summary>
       /// Display Score Under Launched Report.
        /// </summary>       
       [Then(@"It Should display the 'Score' under launched report")]
       public void DisplayScoreUnderLaunchedReport()
       {
           //Display Score Under Launched Report
           Logger.LogMethodEntry("ViewReports",
               "DisplayScoreUnderLaunchedReport",
               base.isTakeScreenShotDuringEntryExit);
           //Assert for score
           Logger.LogAssertion("VerifyTheScore", ScenarioContext.
               Current.ScenarioInfo.Title, () =>
               Assert.AreEqual(ViewReportResource.ViewReport_Score_Value,
                new RptDetailedStudentActivityPage().VerifyTheGradeDisplayed()));
           Logger.LogMethodExit("ViewReports",
               "DisplayScoreUnderLaunchedReport",
               base.isTakeScreenShotDuringEntryExit);
       }

        /// <summary>
       /// Click On The Close Button.
        /// </summary>
       [When(@"I click on the Close button")]
       public void ClickOnTheCloseButton()
       {
           //Click On The Close Button
           Logger.LogMethodEntry("ViewReports","ClickOnTheCloseButton",
               base.isTakeScreenShotDuringEntryExit);
           //Detailed Student Activity Close Button
           new RptDetailedStudentActivityPage().DetailedStudentActivityCloseButton();        
           //Student Activity Report Close Button
           new RptStudentActivityPage().StudentActivityReportCloseButton();
           Logger.LogMethodExit("ViewReports","ClickOnTheCloseButton",
               base.isTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       ///Select Mastery reports link
       /// </summary>
       [When(@"I generate the ""(.*)"" for ""(.*)"" skill")]
       public void SelectMasteryReportsLink(string instructorReportType, string skillName)
       {
           //Select Class Mastery Report link
           Logger.LogMethodEntry("ViewReports", "SelectInstructorReportsLink",
               base.isTakeScreenShotDuringEntryExit);
           new RptMainUXPage().ClickTheMasteryReportsLink
           ((RptMainUXPage.PegasusInstructorReportEnum)Enum.Parse
           (typeof(RptMainUXPage.PegasusInstructorReportEnum), instructorReportType));
           Logger.LogMethodExit("ViewReports", "SelectInstructorReportsLink",
                base.isTakeScreenShotDuringEntryExit);
       }
       /// <summary>
       ///Generate mastery report for the selected skill
       /// </summary>
       [Then(@"I should see the ""(.*)"" for ""(.*)"" skill")]
       public void GenerateMasteryReportForSkill(string instructorReportType, string skillName)
       {
           //Generate Class Mastery Report
           Logger.LogMethodEntry("ViewReports", "GenerateInstructorReports",
               base.isTakeScreenShotDuringEntryExit);
           //Converting String to Enum to pass report by type
           Logger.LogAssertion("VerifyMasteryReport", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.AreEqual
                   (ViewReportResource.ViewReport_SkillNameForMasteryReports_Value,
                  new RptMainUXPage().GenerateMasteryReportForSkill
           ((RptMainUXPage.PegasusInstructorReportEnum)Enum.Parse
           (typeof(RptMainUXPage.PegasusInstructorReportEnum), instructorReportType), skillName)));
           Logger.LogMethodExit("ViewReports", "GenerateInstructorReports",
                base.isTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Click On The Close Button.
       /// </summary>
       [When(@"I click the Close button")]
       public void ClickMasteryReportCloseButton()
       {
           //Click On The Close Button of Class Mastery Report
           Logger.LogMethodEntry("ViewReports", "ClickTheCloseButtonOfCMReport",
               base.isTakeScreenShotDuringEntryExit);
           //Student Activity Report Close Button
           new RptMasteryPage().MasteryReportCloseButton();
           Logger.LogMethodExit("ViewReports", "ClickTheCloseButtonOfCMReport",
               base.isTakeScreenShotDuringEntryExit);
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
