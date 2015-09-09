#region

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.SSRSReports;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Integration.SSRSReports.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public sealed class Folder : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Folder));

        /// <summary>
        /// Verify Report link is present
        /// </summary>
        /// <param name="reportLink">This is the Name of the Report</param>
        [Then(@"I should see the '(.*)' link")]
        public void VerifyReportLink(string reportLink)
        {
            // Verify Report link is present
            Logger.LogMethodEntry("LoginLogout", "VerifyReportLink",
                base.IsTakeScreenShotDuringEntryExit);

            new FolderPage().verifyReportLinkPresent(reportLink);

            Logger.LogMethodExit("LoginLogout", "VerifyReportLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the report
        /// </summary>
        /// <param name="reportLink">This is the report name</param>
        [When(@"I click the '(.*)' link")]
        public void clickReport(string reportLink)
        {
            // Select the report
            Logger.LogMethodEntry("LoginLogout", "clickReport",
                base.IsTakeScreenShotDuringEntryExit);
            new FolderPage().SelectReport(reportLink);
            Logger.LogMethodExit("LoginLogout", "clickReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Generate the MIL3XReport
        /// </summary>
        /// <param name="reportName">This is the report name</param>
        [When(@"I generate the '(.*)' report")]
        [Then(@"I generate the '(.*)' report successfully")]
        public void generateSSRSReport(string reportName)
        {
            Logger.LogMethodEntry("LoginLogout", "generateMIL3XReport",
                base.IsTakeScreenShotDuringEntryExit);
            string reportStatus = "Success";
            //Verify the report is loaded
            Logger.LogAssertion("generateSSRSReport",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(reportStatus, new FolderPage().generateReport(reportName)));
            Logger.LogMethodExit("LoginLogout", "generateMIL3XReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the report is successfully generated
        /// </summary>
        /// <param name="reportName">This is the report name</param>
        [Then(@"I should see '(.*)' report generated successfully")]
        public void ReportGeneratedSuccessfully(string reportName)
        {
            Logger.LogMethodEntry("LoginLogout", "generateMIL3XReport",
                base.IsTakeScreenShotDuringEntryExit);
            string reportVerified = "Success";
            //Verify the report generated is correct
            Logger.LogAssertion("generateSSRSReport",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(reportVerified, new FolderPage().verifygeneratedReport(reportName)));
            Logger.LogMethodExit("LoginLogout", "generateMIL3XReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
