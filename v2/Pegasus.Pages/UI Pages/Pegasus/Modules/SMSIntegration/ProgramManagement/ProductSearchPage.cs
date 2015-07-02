using System;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Product Search Page Actions.
    /// </summary>
    public class ProductSearchPage : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(ProductSearchPage));

        /// <summary>
        /// Search The Product in Course Space.
        /// </summary>
        /// <param name="productName">This is Product Name.</param>
        public void SearchProduct(String productName)
        {
            //Search Product
            Logger.LogMethodEntry("ProductSearchPage", "SearchProduct"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Enter Product Name and Click on Search Button
                Thread.Sleep(10000);
                this.EnterProductNameandClickonSearchButton(productName);          
                //Search Product in Product Frame
                new ManageProductsPage().SelectProductInProductFrame(productName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductSearchPage", "SearchProduct"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Product Name and Click on Search Button.
        /// </summary>
        /// <param name="productName">This is Product Name.</param>
        public void EnterProductNameandClickonSearchButton(String productName)
        {
            //Click on Search Button
            Logger.LogMethodEntry("ProductSearchPage",
                "EnterProductNameandClickonSearchButton"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch To Active Element 
                base.SwitchToActivePageElement();
                //Wait For Element
                Thread.Sleep(5000);
                base.WaitForElement(By.Id(ProductSearchPageResource.
                    ProductSearch_Page_ProgramName_TextBox_Id_Locator));
                //Insert Product Name in Text Box
                base.FillTextBoxById(ProductSearchPageResource.
                    ProductSearch_Page_ProgramName_TextBox_Id_Locator, productName);
                //Wait for Element
                base.WaitForElement(By.Id(ProductSearchPageResource.
                    ProductSearch_Page_SearchButton_Id_Locator));
                //Get Search Button Properties
                IWebElement productSearchButton = base.GetWebElementPropertiesById
                    (ProductSearchPageResource.ProductSearch_Page_SearchButton_Id_Locator);
                base.ClickByJavaScriptExecutor(productSearchButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductSearchPage",
                "EnterProductNameandClickonSearchButton"
                , base.IsTakeScreenShotDuringEntryExit);
        }
        
    }
}
