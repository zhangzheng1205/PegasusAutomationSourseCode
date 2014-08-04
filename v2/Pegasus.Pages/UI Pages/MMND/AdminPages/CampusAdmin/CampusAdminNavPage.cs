using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.AdminPages.CampusAdmin;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains details of CampusAdminNavPage.
    /// </summary>
    public partial class CampusAdminNavPage : BasePage
    {
        /// <summary>
        /// Click On Course Tool Settings Option.
        /// </summary>
        public void ClickOnCourseToolSettings()
        {
            Logger.LogMethodEntry("CampusAdminNavPage", "ClickOnCourseToolSettings",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select AAdministrative Pages Window
                base.SelectWindow(CampusAdminNavPageResource.
                        CampusAdminNav_Page_Window_Name);
                base.WaitForElement(By.Name(CampusAdminNavPageResource.
                    CampusAdminNav_Page_Frame_Name_Locator));
                //Switch to Frame
                base.SwitchToIFrame(CampusAdminNavPageResource.
                    CampusAdminNav_Page_Frame_Name_Locator);
                base.WaitForElement(By.PartialLinkText(CampusAdminNavPageResource.
                    CampusAdminNav_Page_CourseToolSettings_Link_Locator));
                //Click On CourseToolSettings
                base.ClickButtonByPartialLinkText(CampusAdminNavPageResource.
                    CampusAdminNav_Page_CourseToolSettings_Link_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CampusAdminNavPage", "ClickOnCourseToolSettings",
               base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
