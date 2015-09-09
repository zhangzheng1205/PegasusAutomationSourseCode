#region

using System;
using System.Threading;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Integration.Contineo;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;

#endregion


namespace Pegasus.Pages.UI_Pages.Integration.Contineo
{
    public class CentralAdminDashboardPage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CentralAdminDashboardPage));

        /// <summary>
        /// Verify that Central Admin Page is open
        /// </summary>
        public string IsCentralAdminPageOpen()
        {
            Logger.LogMethodEntry("CentralAdminDashboardPage", "IsCentralAdminPageOpen",
                    base.IsTakeScreenShotDuringEntryExit);
            string getActualPageTitle = null;
            try
            {
                //Wait For Window Loads
                base.WaitUntilWindowLoads(CentralAdminDashboardPageResource.
                    CentralAdminDashboardPage_Window_Title_Locator);
                //Select Window
                base.SelectWindow(CentralAdminDashboardPageResource.
                    CentralAdminDashboardPage_Window_Title_Locator);
                //Get current opened page title
                getActualPageTitle = GetPageTitle;
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CentralAdminDashboardPage", "IsCentralAdminPageOpen",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActualPageTitle;
        }

        /// <summary>
        /// Click on PSNPlus link in CAT to SSO to PSNPlus
        /// </summary>
        public void SSOtoPSNPlus(string LMSName)
        {
            Logger.LogMethodEntry("CentralAdminDashboardPage", "SSOtoPSNPlus",
                    base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Verify PSNPlus link is present
                this.VerifyPSNPlusLink(LMSName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CentralAdminDashboardPage", "SSOtoPSNPlus",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify if PSNPlus link is present.
        /// </summary>
        /// <param name="lmsName">This is the name of the link title.</param>
        private void VerifyPSNPlusLink(string lmsName)
        {
            Logger.LogMethodEntry("CentralAdminDashboardPage", "VerifyPSNPlusLink",
                    base.IsTakeScreenShotDuringEntryExit);
            //Get count of LMS listed under Learning Systems in CAT
            int LMScount = base.GetElementCountByXPath(
                CentralAdminDashboardPageResource.CentralAdminDashboardPage_LMS_Count);
            for (int i = 1; i <= LMScount; i++)
            {
                //Get LMS name from application
                IWebElement getLinkName = base.GetWebElementPropertiesByXPath(String.
                    Format(CentralAdminDashboardPageResource.
                    CentralAdminDashboardPage_LMS_Title_Xpath_Locator, i));
                string getLMSName = getLinkName.GetAttribute("title").ToString();
                if(getLMSName == lmsName)
                {
                    bool isLinkPresent = base.IsElementPresent(By.XPath(string.
                        Format(CentralAdminDashboardPageResource.
                        CentralAdminDashboardPage_LMS_Name_IMG_Xpath_Locator, i)), 10);
                    //Get LMS name from application
                    IWebElement getLink = base.GetWebElementPropertiesByXPath(String.
                        Format(CentralAdminDashboardPageResource.
                        CentralAdminDashboardPage_LMS_Name_IMG_Xpath_Locator, i));
                    base.ClickByJavaScriptExecutor(getLink);
                    Thread.Sleep(3000);
                    break;
                }
            }
                Logger.LogMethodExit("CentralAdminDashboardPage", "VerifyPSNPlusLink",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// User SignOut from CAT
        /// </summary>
        /// <param name="userTypeEnum">This user type role.</param>
        public void SignOutfromCAT(User.UserTypeEnum userTypeEnum)
        {
            //Contineo user SignOut from CAT
            Logger.LogMethodEntry("CentralAdminDashboardPage", "SignOutfromCAT",
                        base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for SignOut link to load
                base.WaitForElement(By.PartialLinkText(CentralAdminDashboardPageResource.
                    CentralAdminDashboardPage_SignOut_Link_PartialLinkText_Locator), 10);
                //Click Sign Out link
                base.ClickLinkByPartialLinkText(CentralAdminDashboardPageResource.
                    CentralAdminDashboardPage_SignOut_Link_PartialLinkText_Locator);
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CentralAdminDashboardPage", "SignOutfromCAT",
                        base.IsTakeScreenShotDuringEntryExit);
        }
    }
}