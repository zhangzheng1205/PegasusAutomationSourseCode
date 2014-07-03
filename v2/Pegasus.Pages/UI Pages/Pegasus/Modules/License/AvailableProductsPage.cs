using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Templates;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes.Channels;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.License;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{   
    /// <summary>
    /// This Class Handles Avilable Produsts Page actions
    /// </summary>
    public class AvailableProductsPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(AvailableProductsPage));

        /// <summary>
        /// License the Product
        /// </summary>
        /// <param name="product">This is Product Name</param>
        public void LicenseProduct(string product)
        {
            //License the Product
            logger.LogMethodEntry("AvailableProductsPage", "LicenseProduct",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(AvailableProductsPageResource.
                        AvailableProducts_Page_Window_Title);
                //Select Add Products Window
                base.SelectWindow(AvailableProductsPageResource.
                    AvailableProducts_Page_Window_Title);
                base.WaitForElement(By.Id(AvailableProductsPageResource.
                    AvailableProducts_Page_Product_Frame_Id));
                base.SwitchToIFrame(AvailableProductsPageResource.
                    AvailableProducts_Page_Product_Frame_Id);
                this.SearchProduct(product);
                //Select Add Product Window
                base.SelectWindow(AvailableProductsPageResource.
                    AvailableProducts_Page_Window_Title);
                base.WaitForElement(By.Id(AvailableProductsPageResource.
                    AvailableProducts_Page_Continue_Button_Id));
                //Get Button Property
                IWebElement getContinueButtonProperty = base.GetWebElementPropertiesById(AvailableProductsPageResource.
                    AvailableProducts_Page_Continue_Button_Id);
                //Click on Continue Button
                base.ClickByJavaScriptExecutor(getContinueButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("AvailableProductsPage", "LicenseProduct",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the Product
        /// </summary>
        /// <param name="product">This is Product Name</param>
        private void SearchProduct(string product)
        {
            //Search the Product
            logger.LogMethodEntry("AvailableProductsPage", "SearchProduct",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.ClassName(AvailableProductsPageResource.
                AvailableProducts_Page_Search_Button_ClassName));
            //Get Button Property
            IWebElement getSearchProperty = base.GetWebElementPropertiesByClassName(AvailableProductsPageResource.
                AvailableProducts_Page_Search_Button_ClassName);
            //Click on Search Button
            base.ClickByJavaScriptExecutor(getSearchProperty);
            base.WaitForElement(By.Id(AvailableProductsPageResource.
                AvailableProducts_Page_EmptyBox_Product_Id));
            //Fill Product Name
            base.FillTextBoxByID(AvailableProductsPageResource.
                AvailableProducts_Page_EmptyBox_Product_Id, product);
            base.WaitForElement(By.Id(AvailableProductsPageResource.
                AvailableProducts_Page_Search_Button_Id));
            //Click on Search Button
            base.ClickButtonByID(AvailableProductsPageResource.
                AvailableProducts_Page_Search_Button_Id);
            base.WaitForElement(By.ClassName(AvailableProductsPageResource.
                AvailableProducts_Page_Select_ClassName));
            //Select the Product
            this.SelectProduct();
            logger.LogMethodExit("AvailableProductsPage", "SearchProduct",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Product
        /// </summary>
        private void SelectProduct()
        {
            //Select the Product
            logger.LogMethodEntry("AvailableProductsPage", "SelectProduct",
              base.isTakeScreenShotDuringEntryExit);
            //Get Button Property
            IWebElement getSelectProperty = base.GetWebElementPropertiesByClassName(AvailableProductsPageResource.
                AvailableProducts_Page_Select_ClassName);
            //Click on Select Button
            base.ClickByJavaScriptExecutor(getSelectProperty);
            //Select Add Product Window
            base.SelectWindow(AvailableProductsPageResource.
                AvailableProducts_Page_Window_Title);
            base.WaitForElement(By.Id(AvailableProductsPageResource.
                AvailableProducts_Page_ProductSelected_Frame_Id));
            //Switch to Product Selected Frame
            base.SwitchToIFrame(AvailableProductsPageResource.
                AvailableProducts_Page_ProductSelected_Frame_Id);
            base.WaitForElement(By.XPath(AvailableProductsPageResource.
                AvailableProducts_Page_Products_Xpath));
            logger.LogMethodExit("AvailableProductsPage", "SelectProduct",
                base.isTakeScreenShotDuringEntryExit);
        }

    }
}
