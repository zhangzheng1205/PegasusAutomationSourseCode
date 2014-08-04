using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Enrollment Page Actions
    /// </summary>
    public class AdminEnrollment : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(AdminEnrollment));


        /// <summary>
        /// Find Promoted admin in frame
        /// </summary>
        /// <param name="getAdminName">This is the user name</param>
        public void FindPromotedAdminInFrame()
        {
            //Click Cmenu of promoted admin
            logger.LogMethodEntry("AdminEnrollment", "ClickCmenuOfPromotedAdmin",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select Administration tool window
                base.SelectWindow(AdminEnrollmentResource.
                    AdminEnrollmentPage_WindowName);
                base.WaitForElement(By.Id(AdminEnrollmentResource.
                    AdminEnrollmentPage_RightFrame_Id_Locator));
                // Switch to right i frame
                base.SwitchToIFrame(AdminEnrollmentResource.
                    AdminEnrollmentPage_RightFrame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AdminEnrollment", "SaveTheManageAccessSaveButton",
               base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Click Cmenu image 
        /// </summary>
        /// <param name="getUserName">This is the user name</param>
        public void ClickCmenuImage(String getUserName)
        {
            // Click Cmenu image
            logger.LogMethodEntry("AdminEnrollment", "ClickCmenuOfAdminName",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Count total rows
                int getRowCount = base.GetElementCountByXPath(AdminEnrollmentResource.
                     AdminEnrollmentPage_TableFrame_CountRow_Xpath);
                for (int tableRow = 1; tableRow <= getRowCount; tableRow++)
                {
                    // Get the row text
                    string getAdminName = base.GetElementTextByXPath
                        (string.Format(AdminEnrollmentResource.
                      AdminEnrollmentPage_AdminNameTableRow_Xpath_Locator, tableRow));
                    // Get initial characters of admin user name
                    string getInitialName = getAdminName.Substring(0, 7);
                    if (getUserName.Contains(getInitialName))
                    {
                        // focus on the particular row
                        base.FillEmptyTextByXPath(string.Format(AdminEnrollmentResource.
                         AdminEnrollmentPage_AdminNameTableRow_Xpath_Locator, tableRow));
                        // Wait for the Cmenu Image being displayed and click
                        base.WaitForElement(By.XPath(string.Format(AdminEnrollmentResource.
                          AdminEnrollmentPage_ContextMenu_AdminName_Xpath_Locator, tableRow)));
                        base.FocusOnElementByXPath(string.Format(AdminEnrollmentResource.
                          AdminEnrollmentPage_ContextMenu_AdminName_Xpath_Locator, tableRow));
                        //Get web element
                        IWebElement getCmenuUnEnroll=base.GetWebElementPropertiesByXPath
                            (string.Format(AdminEnrollmentResource.
                          AdminEnrollmentPage_ContextMenu_AdminName_Xpath_Locator, tableRow));
                        base.ClickByJavaScriptExecutor(getCmenuUnEnroll);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AdminEnrollment", "ClickCmenuOfAdminName",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Get Cmenu option for promoted workspace admin
        /// </summary>
        public String GetCmenuOptionForWorkspaceAdmin()
        {
            //Get Unenroll option for workspace admin
            logger.LogMethodEntry("AdminEnrollment", "GetCmenuOptionForWorkspaceAdmin",
               base.IsTakeScreenShotDuringEntryExit);
            string getCmenuOption = string.Empty;
            try
            {
                // Get Unenroll Text for workspace admin
                base.WaitForElement(By.XPath(AdminEnrollmentResource
                    .AdminEnrollmentPage_Unenroll_Text_Xpath_Locator));
                getCmenuOption = base.GetElementTextByXPath(AdminEnrollmentResource
                     .AdminEnrollmentPage_Unenroll_Text_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AdminEnrollment", "GetCmenuOptionForWorkspaceAdmin",
               base.IsTakeScreenShotDuringEntryExit);
            return getCmenuOption.Trim();
        }


        /// <summary>
        /// Get all User CMenu Options for Admin
        /// </summary>
        /// <returns>Cmenu options</returns>
        public String GetCMenuOptionsOfAdmin()
        {
            //Check If the User CMenu Options are Displayed
            logger.LogMethodEntry("AdminEnrollment", "GetCMenuOptionsOfAdmin"
                , base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string ContextMenuNames = string.Empty;
            try
            {
                ContextMenuNames = base.GetElementTextByClassName(AdminEnrollmentResource.AdminEnrollmentPage_Cmenu_Div);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AdminEnrollment", "GetCMenuOptionsOfAdmin"
                , base.IsTakeScreenShotDuringEntryExit);
            return ContextMenuNames;
        }

    }
}
