using System;
using System.Collections.Generic;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Users;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports
{
    /// <summary>
    /// This class handels all the 'Integrity Violation' Report generation page actions
    /// </summary>
    public class RptStudentIntegrityViolationPage : BasePage
    {
        /// <summary>
        /// Instance of logger
        /// </summary>
        private static Logger logger = Logger.
            GetInstance(typeof(RptStudentIntegrityViolationPage));

        /// <summary>
        /// Get the reports page name.
        /// </summary>
        /// <returns>Page name.</returns>
        public string GetPageName()
        {
            //Get the reports page name
            logger.LogMethodEntry("RptStudentIntegrityViolationPage", "GetPageName",
              base.IsTakeScreenShotDuringEntryExit);           
            string getPageHeading = string.Empty;
            base.SwitchToLastOpenedWindow();
            try
            {
                base.WaitForElement(By.Id(
                    RptStudentIntegrityViolationPageResource.
                    RptStudentIntegrityViolationPageResource_PageName_Id_Locator));
                //Get the text of the element
                getPageHeading = base.GetElementTextById(
                    RptStudentIntegrityViolationPageResource.
                    RptStudentIntegrityViolationPageResource_PageName_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentIntegrityViolationPage", "GetPageName",
              base.IsTakeScreenShotDuringEntryExit);
            return getPageHeading;
        }

        /// <summary>
        /// Select section from the dropdown.
        /// </summary>
        /// <param name="sectionID">This is Section ID.</param>
        public void SelectSectioFromTheDropDown(string sectionID)
        {
            //Select section from the dropdown
            logger.LogMethodEntry("RptStudentIntegrityViolationPage",
                "SelectSectioFromTheDropDown",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to window
                base.SwitchToLastOpenedWindow();
                //Select the section
                base.SelectDropDownValueThroughTextById(
                    RptStudentIntegrityViolationPageResource.
                    RptStudentIntegrityViolationPageResource_Section_Id_Locator,
                    sectionID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentIntegrityViolationPage",
                "SelectSectioFromTheDropDown",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the 'generate' button in reports.
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        public void SelectGenerateReport(string buttonName)
        {
            //Select the 'generate' button in reports
            logger.LogMethodEntry("RptStudentIntegrityViolationPage",
                "SelectSectioFromTheDropDown",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToLastOpenedWindow();
                //Click the button
                IWebElement clickButton = base.GetWebElementPropertiesByPartialLinkText
                    (buttonName);
                base.ClickByJavaScriptExecutor(clickButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentIntegrityViolationPage",
                "SelectSectioFromTheDropDown",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Integrity Violated reports details.
        /// </summary>
        /// <param name="rowNumber">This is the row number.</param>
        /// <param name="reportColumn">This is the report column data.</param>
        /// <returns></returns>
        public string GetIntegrityViolationReportDetails(int rowNumber, int reportColumn)
        {
            //Get the Integrity Violated reports details
            logger.LogMethodEntry("RptStudentIntegrityViolationPage",
                "GetIntegrityViolationReportDetails",
              base.IsTakeScreenShotDuringEntryExit);
            string getReportDetails = string.Empty;
            try
            {
                base.SwitchToLastOpenedWindow();
                base.WaitForElement(By.XPath(String.Format(
                    RptStudentIntegrityViolationPageResource.
             RptStudentIntegrityViolationPageResource__ReportDetails_XPath_Locator,
                               rowNumber, reportColumn)));
                //Get the report column details
                getReportDetails = base.GetElementTextByXPath(String.Format(
                    RptStudentIntegrityViolationPageResource.
             RptStudentIntegrityViolationPageResource__ReportDetails_XPath_Locator,
                               rowNumber, reportColumn));                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentIntegrityViolationPage",
                "GetIntegrityViolationReportDetails",
            base.IsTakeScreenShotDuringEntryExit);
            return getReportDetails;
        }

        /// <summary>
        /// Verify Integrity violated colum details in report.
        /// </summary>
        /// <param name="rowNumber">This is the row number.</param>
        /// <returns>Integrited violated column data.</returns>
        public string IsIntegrityViolated(int rowNumber)
        {
            //Verify Integrity violated colum details in report
            logger.LogMethodEntry("RptStudentIntegrityViolationPage",
                           "IsIntegrityViolated",
                         base.IsTakeScreenShotDuringEntryExit);
            string isIntegrityViolated = string.Empty;
            try
            {
                base.WaitForElement(By.XPath(
                    RptStudentIntegrityViolationPageResource.
        RptStudentIntegrityViolationPageResource__integrityViolatedColumnDetails_XPath_Locator));
                //get integrity violated column data      
                isIntegrityViolated = base.GetElementTextByXPath(
                    RptStudentIntegrityViolationPageResource.
        RptStudentIntegrityViolationPageResource__integrityViolatedColumnDetails_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentIntegrityViolationPage", "IsIntegrityViolated",
            base.IsTakeScreenShotDuringEntryExit);
            return isIntegrityViolated;
        }


    }
}
