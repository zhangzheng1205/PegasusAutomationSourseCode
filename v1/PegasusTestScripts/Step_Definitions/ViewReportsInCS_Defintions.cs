using System;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Reports;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class ViewReportsInCSDefintions : BaseTestScript
    {
        //Purpose: Calling Methods From Page class
        readonly private RptDetailedStudentActivityPage _rptdetailedStudentActivityPage = new RptDetailedStudentActivityPage();
        readonly private RptStudentActivityPage _rptStudentActivityPage = new RptStudentActivityPage();
        readonly private RptMainPage _rptMainPage = new RptMainPage();
        readonly private RptCommonCriteriaPage _rptCommonCriteriaPage = new RptCommonCriteriaPage();
        
        //Purpose: to generate the Student Activity report
        [When(@"I generates the Student Activity report")]
        public void WhenIGeneratesTheStudentActivityReport()
        {
            try
            {
                //Purpose: Click Student Act Link
                _rptMainPage.SelectStudentActivity();

                //Purpose: Select Student Report
                _rptCommonCriteriaPage.SelectStudents();

                //Purpose: Run Report
                _rptCommonCriteriaPage.RunReport();
            }
            catch (WebDriverException e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
               GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To verify grades under Student Activity report
        [Then(@"It should display the grades under launched report")]
        public void ThenItShouldDisplayTheGradesUnderLaunchedReport()
        {
            try
            {
                _rptStudentActivityPage.SelectDetailedReport();
                _rptdetailedStudentActivityPage.VerifyGradeDisplayed();
                _rptdetailedStudentActivityPage.CloseWindow();
                _rptStudentActivityPage.CloseWindow();
                GenericHelper.SelectDefaultWindow();
            }
            catch (WebDriverException e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericHelper.SelectWindow("Reports");
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }
    }
}
