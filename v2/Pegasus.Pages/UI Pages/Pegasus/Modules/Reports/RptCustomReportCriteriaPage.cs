using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Custom report Actions
    /// </summary>
    public class RptCustomReportCriteriaPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptCustomReportCriteriaPage));

        /// <summary>
        ///Select Organisations 
        /// </summary>
        public void SelectOrganization()
        {
            //Select Organisations 
            logger.LogMethodEntry("RptCustomReportCriteriaPage", "SelectOrganization",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selct the custom frame
                new RptMainUXPage().SelectCustomFrame();
                //Wait for the Select organization element           
                base.WaitForElement(By.XPath(RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_OrganizationBtn_Xpath_Locator));
                IWebElement getOrganization = base.GetWebElementPropertiesByXPath
                    (RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_OrganizationBtn_Xpath_Locator);
                //Click the Select organization button
                base.ClickByJavaScriptExecutor(getOrganization);
                Thread.Sleep(Convert.ToInt32(RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_OrganizationBtn_Window_Time));
                //Select Organization Name
                new RptSelectOrganisationsPage().SelectOrganizationName();
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptCustomReportCriteriaPage", "SelectOrganization",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select All Student
        /// </summary>
        public void SelectAllStudent()
        {
            //Select Organisations 
            logger.LogMethodEntry("RptCustomReportCriteriaPage", "SelectAllStudent",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selct the custom frame
                new RptMainUXPage().SelectCustomFrame();
                //Wait for the element
                base.WaitForElement(By.Id(RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_Select_Id_Locator));
                base.FocusOnElementById(RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_Select_Id_Locator);
                //Get web element
                IWebElement getAllStudent = base.GetWebElementPropertiesById
                    (RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_Select_Id_Locator);
                //Click the All Student check box
                base.ClickByJavaScriptExecutor(getAllStudent);
                Thread.Sleep(Convert.ToInt32(RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_OrganizationBtn_Window_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptCustomReportCriteriaPage", "SelectAllStudent",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Class Columns
        /// </summary>
        public void SelectClassColumns()
        {
            //Select Class Columns
            logger.LogMethodEntry("RptCustomReportCriteriaPage", "SelectClassColumns",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait for the Select class columns element           
                base.WaitForElement(By.Id(RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_Class_Column_Id_Locator));
                base.FocusOnElementById(RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_Class_Column_Id_Locator);
                //Get web element
                IWebElement getClassSelect = base.GetWebElementPropertiesById
                    (RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_Class_Column_Id_Locator);
                //Click checkbox of Select class columns   
                base.ClickByJavaScriptExecutor(getClassSelect);
                Thread.Sleep(Convert.ToInt32(RptCustomReportCriteriaPageResource.
                         RptCustomReportCriteria_Page_OrganizationBtn_Window_Time));               
                //Intialize Guid for organization
                Guid reportName = Guid.NewGuid();
                //Wait for the report textbox element
                base.WaitForElement(By.Id(RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_ReportName_textbox_Id_Locator));
                //Fill the name
                base.FillTextBoxById(RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_ReportName_textbox_Id_Locator,
                    reportName.ToString());
                //Wait for the Run report btn
                base.WaitForElement(By.Id(RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_RunReport_Btn_Id_Locator));
                IWebElement getRunReportBtn = base.GetWebElementPropertiesById
                    (RptCustomReportCriteriaPageResource.
                    RptCustomReportCriteria_Page_RunReport_Btn_Id_Locator);
                //Click the Run report button
                base.ClickByJavaScriptExecutor(getRunReportBtn);
                Thread.Sleep(Convert.ToInt32(RptCustomReportCriteriaPageResource.
                         RptCustomReportCriteria_Page_OrganizationBtn_Window_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptCustomReportCriteriaPage", "SelectClassColumns",
             base.IsTakeScreenShotDuringEntryExit);
        }        
    }
}
