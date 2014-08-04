using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Diagnostics;
using System.Configuration;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.OrganizationManagement;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the, action of different level's of Organization
    /// </summary>
    public class OrganizationSearchPage : BasePage
    { /// <summary>
        /// This is the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(OrganizationSearchPage));

        /// <summary>
        /// Click on the 'Add'Organization Link
        /// </summary>
        public void ClickOnTheAddOrganizationLink()
        {
            //Click on the 'Add'Organization link
            logger.LogMethodEntry("OrganizationSearchPage", "ClickOnTheAddOrganizationLink",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.WaitUntilWindowLoads(OrganizationSearchPageResource.
                    OrganizationSearch_Page_OrganizationManagement_Window_Title);
                //Select Organization Management Window
                base.SelectWindow(OrganizationSearchPageResource.
                    OrganizationSearch_Page_OrganizationManagement_Window_Title);
                //Wait For Element
                base.WaitForElement(By.Id(OrganizationSearchPageResource.
                    OrganizationSearch_Page_Frame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(OrganizationSearchPageResource.
                    OrganizationSearch_Page_Frame_Id_Locator);
                //Wait for the element to display
                base.WaitForElement(By.XPath(OrganizationSearchPageResource.
                    OrganizationSearch_Page_AddLinkOrganization_Img_Xpath_Locator));
                base.IsElementSelected(By.XPath(OrganizationSearchPageResource.
                    OrganizationSearch_Page_AddLinkOrganization_Img_Xpath_Locator));
                IWebElement getAddLink = base.GetWebElementPropertiesByXPath
                    (OrganizationSearchPageResource.
                    OrganizationSearch_Page_AddLinkOrganization_Img_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getAddLink);
                //Switch To Base Window
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrganizationSearchPage", "ClickOnTheAddOrganizationLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the 'Select Organization' link
        /// </summary>
        public void ClickOnTheSelectOrganizationLink()
        {
            //Click on the 'Select Organization' link
            logger.LogMethodEntry("OrganizationSearchPage", "ClickOnTheSelectOrganizationLink",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.SelectWindow(OrganizationSearchPageResource.
                    OrganizationSearch_Page_OrganizationManagement_Window_Title);
                base.SwitchToIFrame(OrganizationManagementPageResource.
                    OrganizationManagement_Page_Frame_Id_Locator);
                //Wait for the element to display
                base.WaitForElement(By.XPath(OrganizationSearchPageResource.
                    OrganizationSearch_Page_SelectOrganization_Img_Xpath_Locator));
                base.IsElementSelected(By.XPath(OrganizationSearchPageResource.
                    OrganizationSearch_Page_SelectOrganization_Img_Xpath_Locator));
                //Click 'Select Organization'link
                WebDriver.FindElement(By.XPath(OrganizationSearchPageResource.
                    OrganizationSearch_Page_SelectOrganization_Img_Xpath_Locator)).Click();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrganizationSearchPage", "ClickOnTheSelectOrganizationLink",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Manage Button of Organization
        /// </summary>
        public void ClickOnManageButtonOfOrganization()
        {
            //Click on Manage Button Of Organization
            logger.LogMethodEntry("OrganizationSearchPage", "ClickOnManageButtonOfOrganization",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Organization Management window
                base.WaitUntilWindowLoads(OrganizationSearchPageResource.
                    OrganizationSearch_Page_OrganizationManagement_Window_Name);
                base.SelectWindow(OrganizationSearchPageResource.
                    OrganizationSearch_Page_OrganizationManagement_Window_Name);
                //Wait for Workspace Frame ID
                base.WaitForElement(By.Id(OrganizationSearchPageResource.
                    OrganizationSearch_Page_Frame_Id_Locator));
                base.SwitchToIFrame(OrganizationSearchPageResource.
                    OrganizationSearch_Page_Frame_Id_Locator);
                //Wait for Manage Button
                base.WaitForElement(By.Id(OrganizationSearchPageResource.
                    OrganizationSearch_Page_Manage_Button_Id_Locator));
                //Get Button Property
                IWebElement getManageButtonProperty = base.GetWebElementPropertiesById(OrganizationSearchPageResource.
                    OrganizationSearch_Page_Manage_Button_Id_Locator);
                //Click on Manage Button
                base.ClickByJavaScriptExecutor(getManageButtonProperty);
                base.WaitUntilWindowLoads(OrganizationSearchPageResource.
                    OrganizationSearch_Page_ManageOrganization_Window_Name);
                //Select ManageOrganization Window
                base.SelectWindow(OrganizationSearchPageResource.
                    OrganizationSearch_Page_ManageOrganization_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrganizationSearchPage", "ClickOnManageButtonOfOrganization",
                base.IsTakeScreenShotDuringEntryExit);

        }
    }
}
