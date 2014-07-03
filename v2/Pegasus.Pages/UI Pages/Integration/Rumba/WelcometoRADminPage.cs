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
using Pegasus.Pages.UI_Pages.Integration.Rumba;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the Welcome to RADmin Page actions 
    /// </summary>
    public class WelcometoRADminPage : BasePage
    {
        // Static instance of the logger
        private static readonly Logger logger = Logger.
            GetInstance(typeof(WelcometoRADminPage));

        /// <summary>
        /// Click on Create product
        /// </summary>
        public void ClickonCreateProductLink()
        {
            //Click on Create product
            logger.LogMethodEntry("WelcometoRADminPage", "ClickonCreateProductLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.PartialLinkText(WelcometoRADminResource.
                    WelcomeRADmin_Page_CreateProduct_Link_Name));
                //Mouse Hover On Products and Resources
                IWebElement getProductLink = base.GetWebElementPropertiesByPartialLinkText
                    (WelcometoRADminResource.
                    WelcomeRADmin_Page_CreateProduct_Link_Name);
                //mouse over on the product link
                base.MouseOverByJavaScriptExecutor(getProductLink);        
                IWebElement getCreateProductLink = base.GetWebElementPropertiesByPartialLinkText
                    (WelcometoRADminResource.WelcomeRADmin_Page_CreateProduct_Text_Name);
                //Click on Element
                base.ClickByJavaScriptExecutor(getCreateProductLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("WelcometoRADminPage", "ClickonCreateProductLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Create Resource Link
        /// </summary>
        public void ClickCreateResourceLink()
        {
            //Click On Create Resource
            logger.LogMethodEntry("WelcometoRADminPage", "ClickCreateResourceLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {                
                String CurrentPage = base.GetPageTitle;
                base.SelectWindow(CurrentPage);
                //Wait For Element
                base.WaitForElement(By.XPath(WelcometoRADminResource.
                   WelcomeRADmin_Page_CreateResources_Xpath_Locator));               
                IWebElement getProRes = base.GetWebElementPropertiesByXPath
                    (WelcometoRADminResource.
                    WelcomeRADmin_Page_CreateResources_Xpath_Locator);
                //Mouseover on resource link
                base.MouseOverByJavaScriptExecutor(getProRes);         
                //Get Resource Property
                IWebElement getCreatedResource = base.GetWebElementPropertiesByPartialLinkText
                    (WelcometoRADminResource.WelcomeRADmin_Page_CreateResource_Text_Name);
                //Focus on Element
                base.FocusOnElementByPartialLinkText(WelcometoRADminResource.
                    WelcomeRADmin_Page_CreateResource_Text_Name);
                //Click On Create Resource
                base.ClickByJavaScriptExecutor(getCreatedResource);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("WelcometoRADminPage", "ClickCreateResourceLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click 'Place An Order' Link
        /// </summary>
        public void ClickOnPlaceAnOrderLink()
        {
            //Click On Place An Order Link
            logger.LogMethodEntry("WelcometoRADminPage", "ClickOnPlaceAnOrderLink",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {                
                //Wait For Element
                base.WaitForElement(By.PartialLinkText(WelcometoRADminResource.
                    WelcomeRADmin_Page_Licenses_Text_Name));
                //Mouse Hover On Licenses Property
                IWebElement getLicensesLink = base.GetWebElementPropertiesByPartialLinkText
                    (WelcometoRADminResource.WelcomeRADmin_Page_Licenses_Text_Name);
                //Perform Focus on Element
                base.MouseOverByJavaScriptExecutor(getLicensesLink);               
                //Click On Place An Order
                IWebElement getPlaceOrderLink = base.GetWebElementPropertiesByPartialLinkText
                    (WelcometoRADminResource.WelcomeRADmin_Page_PlaceAnOrder_Text_Name);
                //Click on Link
                base.ClickByJavaScriptExecutor(getPlaceOrderLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("WelcometoRADminPage", "ClickOnPlaceAnOrderLink",
                  base.isTakeScreenShotDuringEntryExit);
        }
    }
}
