using System;
using System.Globalization;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.Rumba;
using System.Threading;
using System.Configuration;
using System.Diagnostics;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles products and resources page actions
    /// </summary>

    public class ProductsAndResourcesPage : BasePage
    {
        // Static instance of the logger
        private static readonly Logger logger = Logger.
            GetInstance(typeof(CreateResourcePage));

        /// <summary>
        /// Get Wait Time From App Config File.
        /// </summary>
        static readonly double getSecondsToWait = Convert.ToDouble
        (ConfigurationManager.AppSettings[ProductsAndResourcesPageResource.
        ProductsAndResources_Page_TimeOut_Config_Key]);

        /// <summary>
        /// Click products And Resources Tab
        /// </summary>
        public void ClickOnProductsAndResourcesTab()
        {
            //Click products And Resources Tab
            logger.LogMethodEntry("ProductsAndResourcesPage ",
                "ClickOnProductsAndResourcesTab",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.PartialLinkText(ProductsAndResourcesPageResource.
                    ProductsAndResources_Page_ProductAndResourcesTab_Text_Locator));
                IWebElement getProductResourceLink=base.GetWebElementPropertiesByPartialLinkText
                    (ProductsAndResourcesPageResource.
                    ProductsAndResources_Page_ProductAndResourcesTab_Text_Locator);
                //Click ProductsAndResources Tab Link
                base.ClickByJavaScriptExecutor(getProductResourceLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProductsAndResourcesPage ",
                "ClickOnProductsAndResourcesTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add product Id to resource Id
        /// </summary>
        public void AddProductIDToResourceID()
        {
            // Add product Id to resource Id
            logger.LogMethodEntry("ProductsAndResourcesPage ", "AddProductIDToResourceID",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get license from memory
                License license = License.Get(License.LicenseTypeEnum.Rumba);
                //Wait for Window
                base.WaitUntilWindowLoads(ProductsAndResourcesPageResource.
                    ProductsAndResources_Page_Window_Title_Name);
                //Select the Window
                base.SelectWindow(ProductsAndResourcesPageResource.
                    ProductsAndResources_Page_Window_Title_Name);
                //Search And Select Product
                this.SearchAndSelectProduct(license);
                //Search And Select Resource
                this.SearchAndSelectResource(license);
                //Add Resource
                this.AddResource();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProductsAndResourcesPage ", "AddProductIDToResourceID",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Resource To Product
        /// </summary>
        private void AddResource()
        {
            //Add Resource To Product
            logger.LogMethodEntry("ProductsAndResourcesPage ", "AddResource",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait For The Add Button
            base.WaitForElement(By.Id(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_AddButton_Id_Locator));
            base.FocusOnElementById(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_AddButton_Id_Locator);
            //Click on The Add Button            
            IWebElement getAddButton = base.GetWebElementPropertiesById
                (ProductsAndResourcesPageResource.
                ProductsAndResources_Page_AddButton_Id_Locator);
            base.ClickByJavaScriptExecutor(getAddButton);
            //Click OK button In The Set Resources Popup
            base.WaitForElement(By.XPath(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_SetResourcesPopup_Ok_Button_Xpath_Locator));
            base.ClickButtonByXPath(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_SetResourcesPopup_Ok_Button_Xpath_Locator);
            //Click OK button In The Add Resources Popup
            base.WaitForElement(By.Id(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_AddResourcesPopup_Ok_Button_Id_Locator));
            base.ClickButtonById(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_AddResourcesPopup_Ok_Button_Id_Locator);
            logger.LogMethodExit("ProductsAndResourcesPage ", "AddResource",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search And Add Resource
        /// </summary>
        /// <param name="licenceResourceId">This Is Resource Id</param>
        private void SearchAndSelectResource(License licenceResourceId)
        {
            // Search And Add Resource
            logger.LogMethodEntry("ProductsAndResourcesPage ", "SearchAndSelectResource",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_ResourcesTab_Xpath_locator));
            //Get Tab Property
            IWebElement getResourceTabProperty = base.GetWebElementPropertiesByXPath
                (ProductsAndResourcesPageResource.
                ProductsAndResources_Page_ResourcesTab_Xpath_locator);
            //Click On Resource Tab
            base.ClickByJavaScriptExecutor(getResourceTabProperty);
            //Start Stop Watch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            do
            {
                if (stopWatch.Elapsed.TotalSeconds > getSecondsToWait) break; // Break In Case wait Time Finished
                base.WaitForElement(By.Id(ProductsAndResourcesPageResource.
                    ProductsAndResources_Page_ResourcesearchTextBox_Id_Locator));
                //Clear The Search text box And Fill The Resource Id
                base.ClearTextById(ProductsAndResourcesPageResource.
                    ProductsAndResources_Page_ResourcesearchTextBox_Id_Locator);
                base.FillTextBoxById(ProductsAndResourcesPageResource.
                    ProductsAndResources_Page_ResourcesearchTextBox_Id_Locator,
                    Convert.ToString(licenceResourceId.ResourceID));
                IWebElement getSearchButton=base.GetWebElementPropertiesById
                    (ProductsAndResourcesPageResource.
                    ProductsAndResources_Page_ResourcesearchButton_Id_Locator);
                //Click On The Search Button
                base.ClickByJavaScriptExecutor(getSearchButton);
                Thread.Sleep(Convert.ToInt32(ProductsAndResourcesPageResource.
                    ProductsAndResources_Page_ThreadTime_Value));
            }
            while (!IsElementPresent(By.Id(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_ResourceCheckbox_Id_Locator +
                licenceResourceId.ResourceID.ToString(CultureInfo.InvariantCulture)),
                Convert.ToInt32(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_TimeToWait)));
            //Stop The Watch
            stopWatch.Stop();
            this.SelectSearchedResource(licenceResourceId);
            logger.LogMethodExit("ProductsAndResourcesPage ", "SearchAndSelectResource",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Searched Resource
        /// </summary>
        /// <param name="licenceResourceId">This is Resource Id</param>
        private void SelectSearchedResource(License licenceResourceId)
        {
            //Select Searched Resource
            logger.LogMethodEntry("ProductsAndResourcesPage ", "SelectSearchedResource",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For The Searched Resource
            base.WaitForElement(By.Id(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_ResourceCheckbox_Id_Locator +
                licenceResourceId.ResourceID.ToString(CultureInfo.InvariantCulture)));
            //Focus on Element
            base.FocusOnElementById(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_ResourceCheckbox_Id_Locator +
                licenceResourceId.ResourceID.ToString());
            IWebElement getSelectCheckbox=base.GetWebElementPropertiesById
                (ProductsAndResourcesPageResource.
                ProductsAndResources_Page_ResourceCheckbox_Id_Locator +
                licenceResourceId.ResourceID.ToString(CultureInfo.InvariantCulture));
            // Select The Searched Resource
            base.ClickByJavaScriptExecutor(getSelectCheckbox);
            logger.LogMethodExit("ProductsAndResourcesPage ", "SelectSearchedResource",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search and Select Product
        /// </summary>
        /// <param name="licenceProductId">This Is Product Id</param>
        private void SearchAndSelectProduct(License licenceProductId)
        {
            //Search And Select Product
            logger.LogMethodEntry("ProductsAndResourcesPage ", "SearchAndSelectProduct",
                base.IsTakeScreenShotDuringEntryExit);
            //Start Stop Watch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            do
            {
                if (stopWatch.Elapsed.TotalSeconds > getSecondsToWait) break; // Break In Case wait Time Finished
                //Wait for Element
                base.WaitForElement(By.Id(ProductsAndResourcesPageResource.
                    ProductsAndResources_Page_Product_Search_Text_Id_Locator));
                base.ClearTextById(ProductsAndResourcesPageResource.
                    ProductsAndResources_Page_Product_Search_Text_Id_Locator);
                //Fills the Product Id
                base.FillTextBoxById(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_Product_Search_Text_Id_Locator,
                    Convert.ToString(licenceProductId.ProductID));
                IWebElement getSearchButton=base.GetWebElementPropertiesById
                    (ProductsAndResourcesPageResource.
                    ProductsAndResources_Page_Product_Search_Button_Id_Locator);
                //Clicks Search Button
                base.ClickByJavaScriptExecutor(getSearchButton);
                Thread.Sleep(Convert.ToInt32(ProductsAndResourcesPageResource.
                     ProductsAndResources_Page_ThreadTime_Value));
            }
            while (!IsElementPresent(By.XPath(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_SearchedProduct_Xpath_Locator),
                Convert.ToInt32(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_TimeToWait)));
            //Stop The Watch
            stopWatch.Stop();
            //Wait for  element
            base.WaitForElement(By.XPath(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_SearchedProduct_Xpath_Locator));
            //Focus On The Searched Product
            base.FocusOnElementByXPath(ProductsAndResourcesPageResource.
                ProductsAndResources_Page_SearchedProduct_Xpath_Locator);
            IWebElement GetSearchedProduct=base.GetWebElementPropertiesByXPath(
                ProductsAndResourcesPageResource.
                ProductsAndResources_Page_SearchedProduct_Xpath_Locator);
            //Click OnThe Searched Product
            base.ClickByJavaScriptExecutor(GetSearchedProduct);
            logger.LogMethodExit("ProductsAndResourcesPage ", "SearchAndSelectProduct",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Success Message
        /// </summary>
        /// <returns>SuccessMessage</returns>
        public String GetSuccessMessage()
        {
            // Get Success Message
            logger.LogMethodEntry("ProductsAndResourcesPage ", "GetSuccessMessage",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string successMessage = string.Empty;
            //Get Successmessage From Application
            try
            {
                base.WaitForElement(By.XPath(ProductsAndResourcesPageResource.
                        ProductsAndResources_Page_Successmessage_xpath_locator));
                //Get Successmessage From Application
                successMessage = base.GetElementTextByXPath
                        (ProductsAndResourcesPageResource.
                        ProductsAndResources_Page_Successmessage_xpath_locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProductsAndResourcesPage ", "GetSuccessMessage",
                base.IsTakeScreenShotDuringEntryExit);
            return successMessage;
        }
    }
}
