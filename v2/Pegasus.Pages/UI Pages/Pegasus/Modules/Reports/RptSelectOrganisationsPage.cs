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
   public class RptSelectOrganisationsPage :BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
       private static Logger logger = Logger.GetInstance(typeof(RptSelectOrganisationsPage));

       /// <summary>
       ///Select Organization Name
       /// </summary>
       public void SelectOrganizationName()
       {
           //Select Organization Name
           logger.LogMethodEntry("RptSelectOrganisationsPage", "SelectOrganizationName",
           base.isTakeScreenShotDuringEntryExit);
           //Select Organizationb window opened
           base.SelectWindow(RptSelectOrganisationsPageResource.
               RptSelectOrganisations_Page_Organization_Window_Name);
           //Wait for the organization checkbox
           base.WaitForElement(By.Id(RptSelectOrganisationsPageResource.
               RptSelectOrganisations_Page_Organization_Name_Id_Locator));
           base.FocusOnElementByID(RptSelectOrganisationsPageResource.
               RptSelectOrganisations_Page_Organization_Name_Id_Locator);
           //Get web element
           IWebElement getOrganization=base.GetWebElementPropertiesById
               (RptSelectOrganisationsPageResource.
               RptSelectOrganisations_Page_Organization_Name_Id_Locator);
           //Click the checkbox
           base.ClickByJavaScriptExecutor(getOrganization);
           //Wait for the Add close btn          
           base.WaitForElement(By.Id(RptSelectOrganisationsPageResource.
               RptSelectOrganisations_Page_Organization_CloseBtn_Id_Locator));
           IWebElement getAddCloseBtn = base.GetWebElementPropertiesById
               (RptSelectOrganisationsPageResource.
               RptSelectOrganisations_Page_Organization_CloseBtn_Id_Locator);
           //Click the close button
           base.ClickByJavaScriptExecutor(getAddCloseBtn);
           Thread.Sleep(Convert.ToInt32(RptMainUXPageResource.
                 RptMain_Page_StudentActivity_Window_Time));
           logger.LogMethodExit("RptSelectOrganisationsPage", "SelectOrganizationName",
            base.isTakeScreenShotDuringEntryExit);
       }
    }
}
