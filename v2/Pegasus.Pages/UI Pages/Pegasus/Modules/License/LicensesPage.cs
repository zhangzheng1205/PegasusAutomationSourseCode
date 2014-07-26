using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.License;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handles License Page Actions
    /// </summary>
    public class LicensesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(LicensesPage));


        /// <summary>
        /// Click on Add Classes Option Link
        /// </summary>
        public void ClickAddProductOptionLink()
        {
            //Click on Add Product Option
            logger.LogMethodEntry("LicensesPage", "ClickAddProductOptionLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.SelectWindow(LicensePageResource.
                       License_Page_ManageOrganization_Window_Locator);
                //Wait For Element
                base.WaitForElement(By.Id(LicensePageResource.
                    License_Page_Frame_Id_Locator));
                //Switch to Frame                
                base.SwitchToIFrame(LicensePageResource.
                    License_Page_Frame_Id_Locator);
                Thread.Sleep(Convert.ToInt32(LicensePageResource.
                    License_Page_SleepTime_Value));
                base.WaitForElement(By.ClassName(LicensePageResource.
                    License_Page_AddProduct_ClassName_Locator));
                //Get Button Property
                IWebElement getAddProductButtonProperty = base.GetWebElementPropertiesByClassName(
                    LicensePageResource.License_Page_AddProduct_ClassName_Locator);
                ////Click on Add Products Button
                base.ClickByJavaScriptExecutor(getAddProductButtonProperty);
                base.WaitUntilWindowLoads(LicensePageResource.
                    License_Page_AvailableProducts_Window_Locator);
                //Select Add Products Window
                base.SelectWindow(LicensePageResource.
                    License_Page_AvailableProducts_Window_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("LicensesPage", "ClickAddProductOptionLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Searched Licensed Product
        /// </summary>
        /// <param name="licenseName">This is license Name.</param>
        public void SearchLicensedProduct(string licenseName)
        {
            //Search License
            logger.LogMethodEntry("LicensesPage", "SearchLicensedProduct",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(LicensePageResource.
                       License_Page_ManageOrganization_Window_Locator);
            //Wait For Element
            base.WaitForElement(By.Id(LicensePageResource.
                    License_Page_Frame_Id_Locator));
            base.SwitchToIFrame(LicensePageResource.
                    License_Page_Frame_Id_Locator);
            //Click on Search Button of Product
            this.ClickOnProductSearchButton(licenseName);
            logger.LogMethodExit("LicensesPage", "SearchLicensedProduct",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Search Button of Product
        /// </summary>
        /// <param name="product">This is Product Name</param>
        private void ClickOnProductSearchButton(string product)
        {
            //Click on Search Button of Product
            logger.LogMethodEntry("LicensesPage", "ClickOnProductSearchButton",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for Search Product Button
            base.WaitForElement(By.Id(LicensePageResource.
                License_Page_SearchProducts_Button_Id_Locator));
            base.FocusOnElementById(LicensePageResource.
                License_Page_SearchProducts_Button_Id_Locator);
            //Click on Search Product Button
            base.ClickButtonById(LicensePageResource.
                License_Page_SearchProducts_Button_Id_Locator);
            base.WaitForElement(By.Id(LicensePageResource.
                License_Page_Product_Input_Id_Locator));
            //Fill Product Name
            base.FillTextBoxById(LicensePageResource.
                License_Page_Product_Input_Id_Locator, product);
            base.WaitForElement(By.Id(LicensePageResource.
                License_Page_Search_Button_Id_Locator));
            //Click on Search Button
            base.ClickButtonById(LicensePageResource.
                License_Page_Search_Button_Id_Locator);
            logger.LogMethodExit("LicensesPage", "ClickOnProductSearchButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Licensed Product
        /// </summary>
        /// <returns>Licensed Product Name</returns>
        public String GetLicensedProduct()
        {
            //Get Licensed Product Name
            logger.LogMethodEntry("LicensesPage", "GetLicensedProduct",
                base.isTakeScreenShotDuringEntryExit);
            //Initializing getProductName Variable
            string getLicenseName = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(LicensePageResource.
                       License_Page_ManageOrganization_Window_Locator);
                //Select Manage Organization Window
                base.SelectWindow(LicensePageResource.
                       License_Page_ManageOrganization_Window_Locator);
                base.WaitForElement(By.Id(LicensePageResource.
                    License_Page_Frame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(LicensePageResource.
                    License_Page_Frame_Id_Locator);
                //Wait For Element
                base.WaitForElement(By.XPath(LicensePageResource.
                    License_Page_ProductName_Xpath_Locator));
                //Get Class Name
                getLicenseName = base.GetTitleAttributeValueByXPath(
                    LicensePageResource.License_Page_ProductName_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("LicensesPage", "GetLicensedProduct",
                base.isTakeScreenShotDuringEntryExit);
            return getLicenseName;
        }
    }
}
