using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Integration.eCollege;
using Pegasus.Pages.UI_Pages.Integration.eCollege.CampusAdmin;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handle the left navigation options.
    /// </summary>
    public partial class CampusAdminNavPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger.
        /// </summary>
        private static readonly Logger Logger = Logger.
            GetInstance(typeof(CampusAdminNavPage));

        /// <summary>
        /// Select the Administration Page link ECollege portal.
        /// </summary>
        public void SelectGlobalNavigationPageLink(
            String navigationPageLinkName)
        {
            //Select Administrative Pages Link
            Logger.LogMethodEntry("AdministrationPage", "SelectAdministrativePagesLink",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectAdministrationPagesWindow();
                //Select Top Frame
                this.SelectSubNavFrame();
                //Select SelectAdministration Pages
                base.WaitForElement(By.PartialLinkText(navigationPageLinkName));
                IWebElement getAdministrationLinkProperty = base.
                    GetWebElementPropertiesByPartialLinkText(navigationPageLinkName);
                base.ClickByJavaScriptExecutor(getAdministrationLinkProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdministrationPage", "SelectAdministrativePagesLink",
            base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select Administration Pages Window.
        /// </summary>
        private void SelectAdministrationPagesWindow()
        {
            //Select Window
            Logger.LogMethodEntry("CampusAdminNavPage",
               "SelectAdministrationPagesWindow", base.isTakeScreenShotDuringEntryExit);
            //Wait For Window Loads
            base.WaitUntilWindowLoads(CampusAdminNavPageResource.
                CampusAdminNav_Page_AdministrationPages_Window_Title);
            //Select Window
            base.SelectWindow(CampusAdminNavPageResource.
                                  CampusAdminNav_Page_AdministrationPages_Window_Title);
            Logger.LogMethodExit("CampusAdminNavPage",
               "SelectAdministrationPagesWindow", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Top Content Area Frame To 
        /// Enter Course Information. 
        /// </summary>
        private void SelectSubNavFrame()
        {
            Logger.LogMethodEntry("CampusAdminNavPage",
                "SelectTopContentAreaFrame",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Name(CampusAdminNavPageResource.
               CampusAdminNav_Page_subnav_Frame_Name_Locator));
            //Select Frame SubNav
            base.SwitchToIFrame(CampusAdminNavPageResource.
                CampusAdminNav_Page_subnav_Frame_Name_Locator);
             Logger.LogMethodExit("CampusAdminNavPage",
                "SelectTopContentAreaFrame",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
