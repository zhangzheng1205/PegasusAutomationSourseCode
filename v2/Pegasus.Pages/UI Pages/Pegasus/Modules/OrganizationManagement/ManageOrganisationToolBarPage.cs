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
        private static Logger logger = Logger.GetInstance(typeof(ManageOrganisationToolBarPage));        

        /// <summary>
        /// Selects the Manage Organization Window
        /// </summary>
        public void SelectManageOrganizationWindow()
        {
            //Selects the Manage Organization Window
            logger.LogMethodEntry("ManageOrganisationToolBarPage", 
                "SelectManageOrganizationWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Manage Organization Window
                base.SelectWindow(ManageOrganisationToolBarPageResource.
                    ManageOrganisationToolBar_Page_Window_Name);
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageOrganisationToolBarPage", 
                "SelectManageOrganizationWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="windowName">This is Window Name</param>
        public void CloseWindow(string windowName)
        {
            //Close the Window
            logger.LogMethodEntry("ManageOrganisationToolBarPage", "CloseWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Window
                base.SelectWindow(windowName);
                //Close the Window
                base.CloseBrowserWindow();
                //Switch to Default Window
                base.SwitchToDefaultWindow();                
            }
            catch ( Exception e )
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageOrganisationToolBarPage", "CloseWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on the Enrollment Tab
        /// </summary>
        public void ClickOnEnrollmentTab()
        {
            //Click on the Enrollment Tab
            logger.LogMethodEntry("ManageOrganisationToolBarPage", "ClickOnEnrollmentTab",
                base.isTakeScreenShotDuringEntryExit);
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
                if ( getTabName != ManageOrganisationToolBarPageResource.
                    ManageOrganisationToolBar_Page_Enrollment_Tabname )
                {
                    //Clicks on the Enrollment Tab
                    base.ClickButtonByPartialLinkText(ManageOrganisationToolBarPageResource.
                        ManageOrganisationToolBar_Page_Enrollment_Tabname);
                }
                //Switch to Left Frame 
                this.SwitchToLeftFrame();                
            }
            catch ( Exception e )
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageOrganisationToolBarPage", "ClickOnEnrollmentTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch To Left Frame
        /// </summary>
        private void SwitchToLeftFrame()
        {
            //Select the Left frame
            logger.LogMethodEntry("ManageOrganisationToolBarPage", "SwitchToLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("ManageOrganisationToolBarPage", "SwitchToLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
        }
      
        /// <summary>
        ///Navigate To Properties Sub Tab In Management Organization
        /// </summary>
        /// <param name="tabName">This is tab name</param>
        public void NavigateToPropertiesSubTabInManagementOrganization(string tabName)
        {
            //Navigate To Properties Sub Tab In Management Organization
            logger.LogMethodEntry("ManageOrganisationToolBarPage",
                "NavigateToPropertiesSubTabInManagementOrganization",
                base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("ManageOrganisationToolBarPage",
                "NavigateToPropertiesSubTabInManagementOrganization",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Classes Tab
        /// </summary>
        public void ClickOnClassesTab()
        {
            //Click on the Classes Tab
            logger.LogMethodEntry("ManageOrganisationToolBarPage", "ClickOnClassesTab",
                base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("ManageOrganisationToolBarPage", "ClickOnClassesTab",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
