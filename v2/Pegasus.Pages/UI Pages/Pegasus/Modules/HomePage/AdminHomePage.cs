using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus AdminHomePage Page Actions
    /// </summary>
    public class AdminHomePage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(AdminHomePage));

        /// <summary>
        ///Enter In To Organization Level In Admin HomePage
        /// </summary>
        public void EnterInToOrganizationLevelInAdminHomePage()
        {
            //Enter In To Organization Level In Admin HomePage
            logger.LogMethodEntry("AdminHomePage", "EnterInToOrganizationLevelInAdminHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Admin Home page
                base.WaitUntilWindowLoads(AdminHomePageResource.AdminHome_Page_Window_Name);
                base.SelectWindow(AdminHomePageResource.AdminHome_Page_Window_Name);
                //Wait for the Organization link
                base.WaitForElement(By.Id(AdminHomePageResource.
                    AdminHome_Page_Organization_Link_Id_Locator));
                base.FocusOnElementById(AdminHomePageResource.
                    AdminHome_Page_Organization_Link_Id_Locator);
                //Get web element
                IWebElement getOrganizationNameLink = base.GetWebElementPropertiesById
                    (AdminHomePageResource.
                    AdminHome_Page_Organization_Link_Id_Locator);
                //Click the Organization Name link
                base.ClickByJavaScriptExecutor(getOrganizationNameLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AdminHomePage", "EnterInToOrganizationLevelInAdminHomePage",
                   base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
