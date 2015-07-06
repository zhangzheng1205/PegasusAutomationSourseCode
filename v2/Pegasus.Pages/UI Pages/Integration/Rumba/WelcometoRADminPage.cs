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
        /// Mouse over Products and Resources menu
        /// </summary>
        public void selectProductandResources()
        {
            //Hover on Products and Resources
            logger.LogMethodEntry("WelcometoRADminPage", "selectProductandResources",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                String CurrentPage = base.GetPageTitle;
                base.SelectWindow(CurrentPage);
                base.WaitForElement(By.CssSelector(WelcometoRADminResource.
                WelcomeRADmin_Page_CreateProductandResources_CSSSelector));
                IWebElement getProRes = base.GetWebElementPropertiesByXPath(WelcometoRADminResource.
                WelcomeRADmin_Page_CreateProductandResources_Xpath_Locator);
                Thread.Sleep(2000);
                //Focus on Products and Resources
                base.PerformMouseHoverAction(getProRes);
                base.PerformFocusOnElementAction(getProRes);
                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("WelcometoRADminPage", "selectProductandResources",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Create product
        /// </summary>
        public void ClickonCreateProductLink()
        {
            //Click on Create product
            logger.LogMethodEntry("WelcometoRADminPage", "ClickonCreateProductLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                selectProductandResources();
                base.WaitForElement(By.XPath(WelcometoRADminResource.
                WelcomeRADmin_Page_CreateProducts_Xpath_Locator));
                base.IsElementPresent(By.LinkText(WelcometoRADminResource.WelcomeRADmin_Page_CreateProduct_Text_Name), 20);
                IWebElement getCreateProductLink = base.GetWebElementPropertiesByXPath
                    (WelcometoRADminResource.WelcomeRADmin_Page_CreateProducts_Xpath_Locator);
                //Click on Element
                base.ClickByJavaScriptExecutor(getCreateProductLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("WelcometoRADminPage", "ClickonCreateProductLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Create Resource Link
        /// </summary>
        public void ClickCreateResourceLink()
        {
            //Click On Create Resource
            logger.LogMethodEntry("WelcometoRADminPage", "ClickCreateResourceLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                selectProductandResources();         
                base.IsElementPresent(By.LinkText(WelcometoRADminResource.WelcomeRADmin_Page_CreateResource_Text_Name), 20);
                IWebElement getCreateResourceLink = base.GetWebElementPropertiesByPartialLinkText
                    (WelcometoRADminResource.WelcomeRADmin_Page_CreateResource_Text_Name);
                base.PerformMouseHoverAction(getCreateResourceLink);
                base.PerformFocusOnElementAction(getCreateResourceLink);
                //Click on Element
                base.ClickByJavaScriptExecutor(getCreateResourceLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("WelcometoRADminPage", "ClickCreateResourceLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click 'Place An Order' Link
        /// </summary>
        public void ClickOnPlaceAnOrderLink()
        {
            //Click On Place An Order Link
            logger.LogMethodEntry("WelcometoRADminPage", "ClickOnPlaceAnOrderLink",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                String CurrentPage = base.GetPageTitle;
                base.SelectWindow(CurrentPage);
                base.WaitForElement(By.CssSelector(WelcometoRADminResource.
                WelcomeRADmin_Page_CreateProductandResources_CSSSelector));
                IWebElement licenses = base.GetWebElementPropertiesByXPath(WelcometoRADminResource.
                    WelcomeRADmin_Page_Licenses_Xpath_Locator);
                Thread.Sleep(2000);
                //Mouse hover on Licenses
                base.PerformMouseHoverAction(licenses);
                //Focus on Place an Order link
                IWebElement getPlaceOrderLink = base.GetWebElementPropertiesByXPath
                    (WelcometoRADminResource.WelcomeRADmin_Page_PlaceAnOrder_Xpath_Locator);
                //Click on Link
                base.ClickByJavaScriptExecutor(getPlaceOrderLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("WelcometoRADminPage", "ClickOnPlaceAnOrderLink",
                  base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
