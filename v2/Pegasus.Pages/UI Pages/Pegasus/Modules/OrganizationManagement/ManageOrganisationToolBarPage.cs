using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.OrganizationManagement;
using System.Configuration;
using System.Threading;
using System.IO;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains the actions related to the different subtabs of 
    /// Manage Organization page
    /// </summary>
    public class ManageOrganisationToolBarPage : BasePage
    {
        /// <summary>
        /// This is the static instance of logger
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(ManageOrganisationToolBarPage));

        /// <summary>
        /// Selects the Manage Organization Window
        /// </summary>
        public void SelectManageOrganizationWindow()
        {
            //Selects the Manage Organization Window
            Logger.LogMethodEntry("ManageOrganisationToolBarPage",
                "SelectManageOrganizationWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Manage Organization Window
                base.SelectWindow(ManageOrganisationToolBarPageResource.
                    ManageOrganisationToolBar_Page_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageOrganisationToolBarPage",
                "SelectManageOrganizationWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="windowName">This is Window Name</param>
        public void CloseWindow(string windowName)
        {
            //Close the Window
            Logger.LogMethodEntry("ManageOrganisationToolBarPage", "CloseWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Window
                base.SelectWindow(windowName);
                //Close the Window
                base.CloseBrowserWindow();
                //Switch to Default Window
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageOrganisationToolBarPage", "CloseWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on the Enrollment Tab
        /// </summary>
        public void ClickOnEnrollmentTab()
        {
            //Click on the Enrollment Tab
            Logger.LogMethodEntry("ManageOrganisationToolBarPage", "ClickOnEnrollmentTab",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Manage Organization Window
                new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
                //Get the Selected Tabname
                base.FocusOnElementByClassName(ManageOrganisationToolBarPageResource.
                    ManageOrganisationToolBar_Page_Selected_Tab_ClassName_Locator);
                //Get Selected Tab Name
                string getTabName = base.GetElementTextByClassName(ManageOrganisationToolBarPageResource.
                    ManageOrganisationToolBar_Page_Selected_Tab_ClassName_Locator);
                if (getTabName != ManageOrganisationToolBarPageResource.
                    ManageOrganisationToolBar_Page_Enrollment_Tabname)
                {
                    //Clicks on the Enrollment Tab
                    base.ClickButtonByPartialLinkText(ManageOrganisationToolBarPageResource.
                        ManageOrganisationToolBar_Page_Enrollment_Tabname);
                }
                //Switch to Left Frame 
                this.SwitchToLeftFrame();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageOrganisationToolBarPage", "ClickOnEnrollmentTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch To Left Frame
        /// </summary>
        private void SwitchToLeftFrame()
        {
            //Select the Left frame
            Logger.LogMethodEntry("ManageOrganisationToolBarPage", "SwitchToLeftFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Select the Manage Organization Window
            new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
            //Wait for the Frame
            base.WaitForElement(By.Id(ManageOrganisationToolBarPageResource.
                ManageOrganisationToolBar_Page_Iframe_Id_Locator));
            //Switch to Main Frame
            base.SwitchToIFrame(ManageOrganisationToolBarPageResource.
                ManageOrganisationToolBar_Page_Iframe_Id_Locator);
            //Switch to Left Frame
            base.SwitchToIFrame(OrgAdminUserEnrollmentPageResource.
                OrgAdminUserEnrollment_Page_LeftFrame_Id_Locator);
            //Wait for Create Users Link
            base.WaitForElement(By.Id(ManageOrganisationToolBarPageResource.
                ManageOrganisationToolBar_Page_CreateUsers_Link_Id_Locator));
            Logger.LogMethodExit("ManageOrganisationToolBarPage", "SwitchToLeftFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Navigate To Properties Sub Tab In Management Organization
        /// </summary>
        /// <param name="tabName">This is tab name</param>
        public void NavigateToPropertiesSubTabInManagementOrganization(string tabName)
        {
            //Navigate To Properties Sub Tab In Management Organization
            Logger.LogMethodEntry("ManageOrganisationToolBarPage",
                "NavigateToPropertiesSubTabInManagementOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the window loads
                base.WaitUntilWindowLoads(ManageOrganisationToolBarPageResource.
                    ManageOrganisationToolBar_Page_Window_Name);
                base.SelectWindow(ManageOrganisationToolBarPageResource.
                    ManageOrganisationToolBar_Page_Window_Name);
                //Wait For Element
                base.WaitForElement((By.PartialLinkText(tabName)));
                //Get Element Property          
                IWebElement getTabProperty = base.GetWebElementPropertiesByPartialLinkText(tabName);
                //Click on Tab   
                base.ClickByJavaScriptExecutor(getTabProperty);
                //Wait For Page Load 
                Thread.Sleep(Convert.ToInt32(ManageOrganisationToolBarPageResource.
                     ManageOrganisationToolBar_Page_SleepTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageOrganisationToolBarPage",
                "NavigateToPropertiesSubTabInManagementOrganization",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Classes Tab
        /// </summary>
        public void ClickOnClassesTab()
        {
            //Click on the Classes Tab
            Logger.LogMethodEntry("ManageOrganisationToolBarPage", "ClickOnClassesTab",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Manage Organization Window
                new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
                //Get the Selected Tabname
                base.FocusOnElementByClassName(ManageOrganisationToolBarPageResource.
                    ManageOrganisationToolBar_Page_Selected_Tab_ClassName_Locator);
                //Get Selected Tab Name
                string getTabName = base.GetElementTextByClassName(ManageOrganisationToolBarPageResource.
                    ManageOrganisationToolBar_Page_Selected_Tab_ClassName_Locator);
                if (getTabName != ManageOrganisationToolBarPageResource.
                    ManageOrganisationToolBar_Page_Classes_Tabname)
                {
                    //Clicks on the Classes Tab
                    base.ClickButtonByPartialLinkText(ManageOrganisationToolBarPageResource.
                        ManageOrganisationToolBar_Page_Classes_Tabname);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageOrganisationToolBarPage", "ClickOnClassesTab",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
