using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus RptMain Page Actions
    /// The call name is bad because as it is in Pegasus
    /// </summary>
    public class RptMainPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptMainPage));

        /// <summary>
        /// Select Report.
        /// </summary>
        /// <param name="getReportName">This is the report name.</param>
        public void SelectReport(string getReportName)
        {
            //Select report
            logger.LogMethodEntry("RptMainPage", "SelectReport",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select report frame
                SelectReportFrame();
                // Click on report link
                ClickOnReportLink(getReportName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMainPage", "SelectReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Report.
        /// </summary>
        /// <param name="getReportName">This is the report name.</param>
        public void SelectReportLinkType(string getReportName)
        {
            //Select report
            logger.LogMethodEntry("RptMainPage", "SelectReportLinkType",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select report frame
                SelectReportFrame();
                // Click on report link
                ClickOnReportLinkType(getReportName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMainPage", "SelectReportLinkType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student Enrollment reports option.
        /// </summary>
        public void SelectReportFrame()
        {
            //Select Program admin report frame
            logger.LogMethodEntry("RptMainPage", "SelectReportFrame",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SelectWindow(RptMainPageResource
                    .RptMain_Page_MainWindowName);
                // Select frame
                base.WaitForElement(By.Id(RptMainPageResource.
                    RptMain_Page_MiddleFrame_Id_Locator));
                base.SwitchToIFrame(RptMainPageResource.
                    RptMain_Page_MiddleFrame_Id_Locator);
                // Select main Frame
                base.WaitForElement(By.Id(RptMainPageResource.
                    RptMain_Page_MainFrame_Id_Locator));
                base.SwitchToIFrame(RptMainPageResource.
                    RptMain_Page_MainFrame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMainPage", "SelectReportFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search report on page by its name and click on it.
        /// </summary>
        /// <param name="getReportName">This is the report name.</param>
        public void ClickOnReportLink(string getReportName)
        {
            //Select Student Enrollement Report
            logger.LogMethodEntry("RptMainPage", "ClickOnReportLink",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath(RptMainPageResource
                    .RptMain_Page_tablerow_count));
                // Get total row count
                int getTotalRowCount = base.GetElementCountByXPath(RptMainPageResource
                    .RptMain_Page_WindowName_Title);
                // Loop to search through report name and click on it
                for (int getRowCount = Convert.ToInt32(RptMainPageResource.
                    RptMain_Page_Loop_Initial_Value); getRowCount >= getTotalRowCount;
                    getRowCount++)
                {
                    // Get report name row wise
                    string getReportNameFromRow = base.GetElementTextByXPath
                        (string.Format(RptMainPageResource
                        .RptMain_Page_ReportName_Xpath_Locator, getRowCount));
                    // When Report name matched below code will be executed
                    if (getReportNameFromRow.Contains(getReportName))
                    {
                        base.WaitForElement(By.XPath
                            (string.Format(RptMainPageResource
                            .RptMain_Page_ReportName_Xpath_Locator, getRowCount)));
                        // Click on matched report name
                        IWebElement reportName = base.GetWebElementPropertiesByXPath
                            (string.Format(RptMainPageResource
                           .RptMain_Page_ReportName_Xpath_Locator, getRowCount));
                        base.ClickByJavaScriptExecutor(reportName);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMainPage", "ClickOnReportLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search report on page by its name and click on it.
        /// </summary>
        /// <param name="getReportName">This is the report name.</param>
        public void ClickOnReportLinkType(string getReportName)
        {
            //Select Student Enrollement Report
            logger.LogMethodEntry("RptMainPage", "ClickOnReportLinkType",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath(RptMainPageResource
                    .RptMain_Page_tablerow_count));
                base.WaitForElement(By.Id(RptMainPageResource.RptMain_Page_Report_Type_Link));
                // Click on matched report name
                IWebElement reportName = base.GetWebElementPropertiesById(RptMainPageResource.RptMain_Page_Report_Type_Link);
                base.ClickByJavaScriptExecutor(reportName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMainPage", "ClickOnReportLinkType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Report Name.
        /// </summary>
        /// <returns>Report Name.</returns>
        public String GetReportName()
        {
            logger.LogMethodEntry("RptMainPage", "GetReportName",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getReportName = string.Empty;
            try
            {
                // Select Report Frame
                SelectReportFrame();
                base.WaitForElement(By.XPath(RptMainPageResource.
                    RptMain_Page_ReportName_MyReports_XpathLocator));
                //Get Report Name
                getReportName = base.GetElementTextByXPath(RptMainPageResource.
                    RptMain_Page_ReportName_MyReports_XpathLocator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMainPage", "GetReportName",
                base.IsTakeScreenShotDuringEntryExit);
            return getReportName;
        }

        /// <summary>
        /// Click On Report In Activity Results Panel.
        /// </summary>
        /// <param name="reportType">This is Report Type.</param>
        public void ClickOnReportInActivityResultsPanel(string reportType)
        {
            //Click On Report In Activity Results Panel
            logger.LogMethodEntry("RptMainPage", "GetReportName",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getReportName = string.Empty;
            try
            {
                base.WaitForElement(By.XPath(RptMainPageResource.
                    RptMain_Page_Report_Count_Xpath_Locator));
                //Get Count
                int getCount = base.GetElementCountByXPath(RptMainPageResource.
                    RptMain_Page_Report_Count_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(RptMainPageResource.
                    RptMain_Page_Loop_Initial_Value);
                    rowCount <= getCount; rowCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(RptMainPageResource.
                        RptMain_Page_Report_Name_Xpath_Locator, rowCount)));
                    //Get Report Name
                    getReportName =
                        base.GetElementTextByXPath(string.Format(RptMainPageResource.
                        RptMain_Page_Report_Name_Xpath_Locator, rowCount));
                    if (getReportName == reportType)
                    {
                        //Click On Report
                        base.ClickLinkByXPath(string.Format(RptMainPageResource.
                            RptMain_Page_ReportType_Name_Xpath_Locator, rowCount));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMainPage", "GetReportName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Certificate In Activity Results Panel
        /// </summary>
        /// <param name="reportType">This is Report Type</param>
        public void ClickOnCertificateInActivityResultsPanel(string reportType)
        {
            //Click On Certificate In Activity Results Panel
            logger.LogMethodEntry("RptMainPage", "ClickOnCertificateInActivityResultsPanel",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getCertificateName = string.Empty;
            try
            {
                //Select Report Frame
                this.SelectReportFrame();
                base.WaitForElement(By.XPath(RptMainPageResource.
                    RptMain_Page_ExamCertificate_Xpath_Locator));
                //Get Certificate Count
                int getCertificateCount = base.GetElementCountByXPath(
                    RptMainPageResource.RptMain_Page_ExamCertificate_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(
                    RptMainPageResource.RptMain_Page_Loop_Initial_Value);
                    rowCount <= getCertificateCount; rowCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(RptMainPageResource.
                        RptMain_Page_GetCertificateName_Xpath_Locator, rowCount)));
                    //Get Certificate Name
                    getCertificateName = base.GetElementTextByXPath(
                        string.Format(RptMainPageResource.
                        RptMain_Page_GetCertificateName_Xpath_Locator, rowCount));
                    if (getCertificateName == reportType)
                    {
                        //Get Certificate Property
                        IWebElement getCertificateProperty = base.GetWebElementPropertiesByXPath(
                            string.Format(RptMainPageResource.
                            RptMain_Page_CertificateName_Xpath_Locator, rowCount));
                        //Click On Certificate
                        base.ClickByJavaScriptExecutor(getCertificateProperty);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMainPage", "ClickOnCertificateInActivityResultsPanel",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Save report check box
        /// </summary>
        /// <param name="checkbox id">HTML check box id</param>
        public void selectCheckBox(string chkID)
        {
            logger.LogMethodEntry("RptMainPage", "selectCheckBox",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(RptMainPageResource.RptMain_Page_Report_Save_CheckBox));
                base.SelectCheckBoxById(RptMainPageResource.RptMain_Page_Report_Save_CheckBox);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMainPage", "selectCheckBox",
              base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
