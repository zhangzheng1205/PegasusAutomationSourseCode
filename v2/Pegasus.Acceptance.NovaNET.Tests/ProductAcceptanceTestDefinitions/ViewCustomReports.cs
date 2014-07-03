using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles the View Reports Actions in Organization Admin.
    /// </summary
    [Binding]
    public class ViewCustomReports : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(ViewCustomReports));

        /// <summary>
        /// Generate Student Report In Organization Admin.
        /// </summary>
        /// <param name="instructorReportType">This is Instructor Report Type.</param>
        /// <param name="userType">This is user type</param>
        [When(@"I generate the ""(.*)"" in Organization Admin of student ""(.*)""")]
        public void GenerateStudentReportInOrganizationAdmin(
            String instructorReportType, User.UserTypeEnum userType)
        {
            //Generate Student Report In Organization Admin
            Logger.LogMethodEntry("ViewCustomReports", 
                "GenerateStudentReportInOrganizationAdmin",
                base.isTakeScreenShotDuringEntryExit);
            User user = User.Get(userType);
            //Converting String to Enum to pass report by type
            new RptMainUXPage().ManageInstructorReportInOrganizationAdmin
                ((RptMainUXPage.PegasusInstructorReportEnum)Enum.Parse
                (typeof(RptMainUXPage.PegasusInstructorReportEnum), 
                instructorReportType),user.Name);
            Logger.LogMethodExit("ViewCustomReports", 
                "GenerateStudentReportInOrganizationAdmin",
                 base.isTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Click The Close Button In Launched Report.
        /// </summary>
        [When(@"I click on the Close button in launched report")]
        public void ClickTheCloseButtonInLaunchedReport()
        {
            //Click The Close Button In Launched Report
            Logger.LogMethodEntry("ViewCustomReports", 
                "ClickTheCloseButtonInLaunchedReport",
                base.isTakeScreenShotDuringEntryExit);
            //Close Report Button In Organization Admin
            new RptDetailedStudentActivityPage().
                CloseReportButtonInOrganizationAdmin();
            //Close Student Avtivity Report  Button In Organization Admin
            new RptStudentActivityPage().
                CloseStudentAvtivityReportButtonInOrganizationAdmin();
            Logger.LogMethodExit("ViewCustomReports", 
                "ClickTheCloseButtonInLaunchedReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Download Report.
        /// </summary>
        [When(@"I select the 'DownloadReport' in Report tab")]
        public void SelectDownloadReport()
        {
            //Select Download Report
            Logger.LogMethodEntry("ViewCustomReports", 
                "SelectDownloadReport",
                base.isTakeScreenShotDuringEntryExit);
            //Select Download Report Option           
            new RptMainUXPage().SelectDownloadReportOption();
            Logger.LogMethodExit("ViewCustomReports", 
                "SelectDownloadReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Class Name.
        /// </summary>
        /// <param name="classTypeEnum">This is Class by Type Enum.</param>
        [Then(@"I should see the ""(.*)"" class")]
        public void VerifyTheClassName(Class.ClassTypeEnum 
            classTypeEnum)
        {
            // Verify The Class Name
            Logger.LogMethodEntry("ViewCustomReports", "VerifyTheClassName",
                base.isTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
          Class orgClass = Class.Get(classTypeEnum);
            // Assert Class name
            Logger.LogAssertion("VerifyClassSearch", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(orgClass.Name,
                    new RptMainUXPage().GetClassName()));
            //Delete Download Report
            new RptMainUXPage().DeleteDownloadReport();
            Logger.LogMethodExit("ViewCustomReports", "VerifyTheClassName",
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
