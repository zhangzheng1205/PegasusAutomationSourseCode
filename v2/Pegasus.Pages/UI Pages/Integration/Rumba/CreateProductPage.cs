using System;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.Rumba;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles create product page actions.
    /// </summary>
    public class CreateProductPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger.
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(CreateProductPage));

        /// <summary>
        /// Creates Rumba Product.
        /// </summary>
        public void CreateRumbaProduct()
        {
            //Create Product
            logger.LogMethodEntry("CreateProductPage", "CreateRumbaProduct",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generate new guid for product name
                Guid productname = Guid.NewGuid();
                //Wait until Create product window exist
                base.WaitUntilWindowLoads(CreateProductPageResource.
                    CreateProduct_Page_Window_Title_Name);
                //Enter Product Details
                this.EnterProductDetails(productname);
                //To Select Organization
                this.EnterOrganizationNameInRumba();
                //Fill the Enter The Display Information
                this.EnterTheDisplayInformation();
                //Wait For Element
                base.WaitForElement(By.Id(CreateProductPageResource.
                    CreateProduct_Page_CreateProduct_Button_Id_Locator));
                IWebElement getCreateProductButton = base.GetWebElementPropertiesById
                    (CreateProductPageResource.
                    CreateProduct_Page_CreateProduct_Button_Id_Locator);
                //Click on Submit button
                base.ClickByJavaScriptExecutor(getCreateProductButton);
                //Select Window
                base.SelectWindow(CreateProductPageResource.
                    CreateProduct_Page_PageTitle + productname);
                //Get the product id
                string getProductID = base.GetElementTextByXPath(CreateProductPageResource.
                    CreateProduct_Page_Productid_Display_Xpath);
                //Save the product id in memory
                SaveProductIdInMemory(Convert.ToInt32(getProductID));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateProductPage", "CreateRumbaProduct",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill the Enter The Display Information.
        /// </summary>
        private void EnterTheDisplayInformation()
        {
            //Fill the Enter The Display Information
            logger.LogMethodEntry("CreateProductPage", "EnterTheDisplayInformation",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(CreateProductPageResource.
                CreateProduct_Page_DisplayInformation_Image_Xpath_Locator));
            IWebElement getDisplayInformation = base.GetWebElementPropertiesByXPath
           (CreateProductPageResource.CreateProduct_Page_DisplayInformation_Image_Xpath_Locator);
            //Click the Display Information
            base.ClickByJavaScriptExecutor(getDisplayInformation);
            //Wait for the element
            base.WaitForElement(By.XPath(CreateProductPageResource.
                CreateProduct_Page_DefaultLanguage_Image_Xpath_Locator));
            IWebElement getDefaultLanguages = base.GetWebElementPropertiesByXPath
                (CreateProductPageResource.
                CreateProduct_Page_DefaultLanguage_Image_Xpath_Locator);
            //Click the Default Languages
            base.ClickByJavaScriptExecutor(getDefaultLanguages);
            //Enter The Display Information Details
            this.EnterTheDisplayInformationDetails();
            logger.LogMethodExit("CreateProductPage", "EnterTheDisplayInformation",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Display Information Details.
        /// </summary>
        public void EnterTheDisplayInformationDetails()
        {
            //Enter The Display Information Details
            logger.LogMethodEntry("CreateProductPage", "EnterTheDisplayInformationDetails",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Display Information Name element
                base.WaitForElement(By.Id(CreateProductPageResource.
                    CreateProduct_Page_ProductResourseDisplay_Name_id_Locator));
                //Enter Display Information Name
                base.FillTextBoxById(CreateProductPageResource.
                    CreateProduct_Page_ProductResourseDisplay_Name_id_Locator,
                    CreateProductPageResource.
                    CreateProduct_Page_ProductResourseDisplay_Name);
                //Enter Short Description
                base.FillTextBoxById(CreateProductPageResource.
                    CreateProduct_Page_ShortDescriptionName_id_Locator,
                    CreateProductPageResource.
                    CreateProduct_Page_ShortDescriptionName);
                //Enter Long Description
                base.FillTextBoxById(CreateProductPageResource.
                    CreateProduct_Page_LongDescriptionName_id_Locator,
                    CreateProductPageResource.
                    CreateProduct_Page_LongDescriptionName);
                //Select Billing Type
                base.SelectDropDownValueThroughTextById(CreateProductPageResource.
                    CreateProduct_Page_DisplayLanguage_id_Locator,
                    CreateProductPageResource.CreateProduct_Page_SelectLanguage);
                this.ClickAddButtonInDisplayInformation();
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }    
            logger.LogMethodExit("CreateProductPage", "EnterTheDisplayInformationDetails",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Add Button In Display Information.
        /// </summary>
        private void ClickAddButtonInDisplayInformation()
        {
            //Click Add Button In Display Information
            logger.LogMethodEntry("CreateProductPage", "ClickAddButtonInDisplayInformation",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the Add Button element
            base.WaitForElement(By.Id(CreateProductPageResource.
                CreateProduct_Page_Add_Button_Id_Locator));
            IWebElement getAddButton = base.GetWebElementPropertiesById
                (CreateProductPageResource.
                CreateProduct_Page_Add_Button_Id_Locator);
            //Click on Add button
            base.ClickByJavaScriptExecutor(getAddButton);
            logger.LogMethodExit("CreateProductPage", "ClickAddButtonInDisplayInformation",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Organization Name In Rumba.
        /// </summary>
        private void EnterOrganizationNameInRumba()
        {
            //To Select Organization
            logger.LogMethodEntry("CreateProductPage", "EnterOrganizationNameInRumba",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(CreateProductPageResource.
                CreateProduct_Page_PearsonOrganizationandMarket_Xpath));
            //Get Element HTML Property
            IWebElement getPearsonOrganizationMarketImage =
                GetWebElementPropertiesByXPath(CreateProductPageResource.
                CreateProduct_Page_PearsonOrganizationandMarket_Xpath);
            //Move Focus on Element
            base.PerformMoveToElementAction(getPearsonOrganizationMarketImage);
            //Click on Element
            base.ClickByJavaScriptExecutor(getPearsonOrganizationMarketImage);
            //Selects the school curriculum
            IWebElement autocomplete = GetWebElementPropertiesById(CreateProductPageResource.
                CreateProduct_Page_PearsonOrganizationandMarket_PearsonOrganization_Text_id_locator);
            //Select Organization From Auto Fill
            SelectRumbaOrganizationFromAutoFill(autocomplete);
            Thread.Sleep(Convert.ToInt32(CreateProductPageResource.
                CreateProduct_Page_ThreadSleepTime));
            logger.LogMethodExit("CreateProductPage", "EnterOrganizationNameInRumba",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Organization From AutoFill Menu Items.
        /// </summary>
        /// <param name="autocomplete">This is AutoFill Menu Web Element. </param>
        private void SelectRumbaOrganizationFromAutoFill(IWebElement autocomplete)
        {
            //Select Pearson Organization From AutoFill Menu Items
            logger.LogMethodEntry("CreateProductPage", "SelectRumbaOrganizationFromAutoFill",
              base.IsTakeScreenShotDuringEntryExit);
            //Clear Auto Complete Text Box            
            base.ClearTextById(CreateProductPageResource.
                CreateProduct_Page_PearsonOrganizationandMarket_PearsonOrganization_Text_id_locator);
            autocomplete.SendKeys(CreateProductPageResource.
                CreateProduct_Page_PearsonOrganizationandMarket_Value);
            Thread.Sleep(Convert.ToInt32(CreateProductPageResource.
                CreateProduct_Page_ThreadSleepTime));
            //Get the Element Property
            base.WaitForElement(By.CssSelector(CreateProductPageResource.
                CreateProduct_Page_PearsonOrganizationandMarket_CSSSelector));
            IWebElement autocompleteElement = GetWebElementPropertiesByCssSelector
                (CreateProductPageResource.CreateProduct_Page_PearsonOrganizationandMarket_CSSSelector);
            //Clicks on selected text in autocomplete
            autocompleteElement.Click();
            logger.LogMethodExit("CreateProductPage", "SelectRumbaOrganizationFromAutoFill",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Product Details.
        /// </summary>
        /// <param name="productName">This is Product Name.</param>
        private void EnterProductDetails(Guid productName)
        {
            //Enter Product Details
            logger.LogMethodEntry("CreateProductPage", "EnterProductDetails",
                base.IsTakeScreenShotDuringEntryExit);
            //Selects the window
            base.SelectWindow(CreateProductPageResource.
                CreateProduct_Page_Window_Title_Name);
            IWebElement getInternalNameImag = base.GetWebElementPropertiesByXPath
                (CreateProductPageResource.
               CreateProduct_Page_InternalNameDescriptionandTargetUser_Xpath);
            base.ClickByJavaScriptExecutor(getInternalNameImag);
            //Wait for the element
            base.WaitForElement(By.Id(CreateProductPageResource.
              CreateProduct_Page_ProductName_id_Locator));
            //Fills the product name
            base.FillTextBoxById(CreateProductPageResource.
              CreateProduct_Page_ProductName_id_Locator, productName.ToString());
            // Fill Product Description And Order Number
            this.FillProductDescriptionAndOrderNumber(productName);
            logger.LogMethodExit("CreateProductPage", "EnterProductDetails",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Product Description And Order Number.
        /// </summary>
        /// <param name="productName">This is Product Name.</param>
        private void FillProductDescriptionAndOrderNumber(Guid productName)
        {
            //Fills the description And Order Number
            logger.LogMethodEntry("CreateProductPage", "FillProductDescriptionAndOrderNumber",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CreateProductPageResource.
               CreateProduct_Page_InternalDescription_id_Locator));
            //Enter Description
            base.FillTextBoxById(CreateProductPageResource.
                CreateProduct_Page_InternalDescription_id_Locator, productName.ToString());
            IWebElement getOrderBilling = base.GetWebElementPropertiesByXPath
                (CreateProductPageResource.
               CreateProduct_Page_OrderingandBillingSystems_Xpath);
            base.ClickByJavaScriptExecutor(getOrderBilling);
            base.FocusOnElementById(CreateProductPageResource.
                CreateProduct_Page_OrderingandBillingSystems_Dropdown_id_Locator);
            //Select Billing Type
            base.SelectDropDownValueThroughTextById(CreateProductPageResource.
                CreateProduct_Page_OrderingandBillingSystems_Dropdown_id_Locator,
                CreateProductPageResource.
                CreateProduct_Page_OrderingandBillingSystems_Dropdown_Value);
            base.ClearTextById(CreateProductPageResource.
               CreateProduct_Page_OrderingandBillingSystems_Enter13digit_Text_id_Locator);
            string getOrderId = this.GetRandomOrderID();
            //Enters the 13 digit unique number
            base.FillTextBoxById(CreateProductPageResource.
                CreateProduct_Page_OrderingandBillingSystems_Enter13digit_Text_id_Locator,
                getOrderId);
            //Store The Order Id In Memory
            this.SaveOrderIdInMemory(getOrderId);
            logger.LogMethodExit("CreateProductPage", "FillProductDescriptionAndOrderNumber",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save the product id in memory.
        /// </summary>
        /// <param name="productId">This is Product Id.</param>
        private void SaveProductIdInMemory(int productId)
        {
            //Save the product id in memory
            logger.LogMethodEntry("CreateProductPage", "SaveProductIdInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            //Save the product details
            License license = License.Get(License.LicenseTypeEnum.Rumba);
            license.ProductID = productId;
            //Stores the license details
            logger.LogMethodExit("CreateProductPage", "SaveProductIdInMemory",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store The Order ID In Memory.
        /// </summary>
        /// <param name="orderId">This is Order ID.</param>
        private void SaveOrderIdInMemory(string orderId)
        {
            //Save the Order id in memory
            logger.LogMethodEntry("CreateProductPage", "SaveOrderIdInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            //Save the product details
            License license = new License
            {
                OrderId = orderId,
                LicenseType = License.LicenseTypeEnum.Rumba,
                IsCreated = true
            };
            //Stores the license details
            license.StoreLicenseInMemory();
            logger.LogMethodExit("CreateProductPage", "SaveOrderIdInMemory",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Rumba Product ID.
        /// </summary>
        /// <returns>Product id.</returns>
        public int GetRumbaProductID()
        {
            //Gets the product id
            logger.LogMethodEntry("CreateProductPage",
                "GetRumbaProductID", base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            int getProductId = Convert.ToInt32(CreateProductPageResource.
                CreateProduct_Page_ProductId_DefaultValue);
            try
            {
                //Get Product Id 
                getProductId = Convert.ToInt32(base.GetElementTextByXPath
                        (CreateProductPageResource.
                        CreateProduct_Page_Productid_Display_Xpath));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateProductPage",
            "GetRumbaProductID", base.IsTakeScreenShotDuringEntryExit);
            return getProductId;
        }

        /// <summary>
        /// Generate The 13 Digit Random Number For Order ID.
        /// </summary>
        /// <returns>13 Digit Order ID.</returns>
        private String GetRandomOrderID()
        {
            //Generates Random Order ID
            logger.LogMethodEntry("CreateProductPage",
                "GetRandomOrderID", base.IsTakeScreenShotDuringEntryExit);
            //Get 13 Digit Order ID
            string getOrderId = base.GetRandomNumber(CreateProductPageResource.CreateProduct_Page_Random_CharacterSet_String,
                Convert.ToInt32(CreateProductPageResource.CreateProduct_Page_Random_Number_Length)).
                ToString(CultureInfo.InvariantCulture);
            logger.LogMethodExit("CreateProductPage",
                 "GetRandomOrderID", base.IsTakeScreenShotDuringEntryExit);
            //Return Order ID
            return getOrderId;
        }
    }
}
