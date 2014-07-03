using System;
using System.Globalization;
using System.Configuration;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using Pegasus.Pages.Exceptions;
using System.IO;
using OpenQA.Selenium.Interactions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles New Product Page Actions.
    /// </summary>
    public class NewProductPage : BasePage
    {

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = Logger.GetInstance(typeof(NewProductPage));


        /// <summary>
        /// Create New Product.
        /// </summary>
        /// <param name="productTypeEnum">This is product type enum.</param>
        /// <param name="programTypeEnum">This is program type enum.</param>
        public void CreateNewProduct
            (Product.ProductTypeEnum productTypeEnum,
            Program.ProgramTypeEnum programTypeEnum)
        {
            //Create New product
            Logger.LogMethodEntry("NewProductPage", "CreateNewProduct",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectCreateNewProductWindow();
                //Enter Product Name
                String productName = this.EnterProductName(productTypeEnum);
                //Click On Search Program Link
                ClickSearchProgramsLink();
                //Enter Program Name To Search
                EnterProgramNameToSearch(programTypeEnum);
                //Select Program Name
                this.SelectProgramNameInTheSearchFrame();
                //Create Product Based on Type
                EnterDetailsBasedOnProductType(productTypeEnum);
                String demoAccessCode = NewProductPageResource.
                NewProduct_Page_AccessCode_Characterset_Value.ToString();
                //Click To Save Button
                this.ClickToSaveProduct();
                //Store Product Details in Memory
                StoreProductDetailsInMemory(productTypeEnum, productName, demoAccessCode);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
                throw;
            }
            Logger.LogMethodExit("NewProductPage", "CreateNewProduct",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Product Based on Type.
        /// </summary>
        /// <param name="productTypeEnum">This is product type enum.</param>
        private void EnterDetailsBasedOnProductType
            (Product.ProductTypeEnum productTypeEnum)
        {
            Logger.LogMethodEntry("NewProductPage", "EnterDetailsBasedOnProductType",
               base.isTakeScreenShotDuringEntryExit);
            switch (productTypeEnum)
            {
                case Product.ProductTypeEnum.HedCoreGeneral:
                case Product.ProductTypeEnum.HedMilGeneral:
                    //Enter Product Details
                    this.EnterDetailsForGeneralTypeProductForHed();
                    break;
                case Product.ProductTypeEnum.HedCoreProgram:
                    //Enter Product Details
                    this.EnterDetailsForProgramTypeProductForHed();
                    //Select Discipline Option Value
                    SelectDisciplineNameToCreateHedProgramTypeProduct();
                    break;
                case Product.ProductTypeEnum.HedMilProgram:
                    //Enter Product Details
                    this.EnterDetailsForProgramTypeProductForHed();
                    //Select Discipline Option Value
                    SelectDisciplineNameToCreateHedProgramTypeProduct();
                    //Select MyItLab Program Admin Reporting CheckBox
                    this.SelectMyItLabProgramAdminReportingCheckBox();
                    break;
                //Create Digital Path and NovaNET Product
                case Product.ProductTypeEnum.DigitalPath:
                case Product.ProductTypeEnum.PromotedAdminDigitalPath:
                case Product.ProductTypeEnum.NovaNET:
                    //Select License and Product Type Options    
                    this.SelectEnableLicensingAndProductTypeOptions(productTypeEnum);
                    //Enter Product Details
                    this.UploadBannerAndIconImagesForSchoolProduct(productTypeEnum);
                    break;
                case Product.ProductTypeEnum.DigitalPathDemo:
                    //Select License and Product Type Options    
                    this.SelectEnableLicensingAndProductTypeOptions(productTypeEnum);
                    //Enter Demo Access Code
                    this.EnterDemoAccessCode();
                    //Enter welcome message
                    this.EnterWelcomeMessage();
                    //Upload Banner Image for Demo Product
                    this.UploadBannerAndIconImagesForSchoolProduct(productTypeEnum);
                    break;
            }
            Logger.LogMethodExit("NewProductPage", "EnterDetailsBasedOnProductType",
               base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter Demo Access Code for Demo Product.
        /// </summary>
        private void EnterDemoAccessCode()
        {
            //Log Method Entry
            Logger.LogMethodEntry("NewProductPage", "EnterDemoAccessCode",
              base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(NewProductPageResource.
                NewProduct_Page_DemoProduct_Checkbox_Id_Locator));
            //Click Demo Product CheckBox
            IWebElement demoProductCheckbox = base.GetWebElementPropertiesById
                (NewProductPageResource.NewProduct_Page_DemoProduct_Checkbox_Id_Locator);
            base.ClickByJavaScriptExecutor(demoProductCheckbox);
            base.WaitForElement(By.Id(NewProductPageResource.
                NewProduct_Page_AccessCode_Textbox_Id_Locator));
            //Enter Access code in Textbox
            base.FillTextBoxByID(NewProductPageResource.
                NewProduct_Page_AccessCode_Textbox_Id_Locator,
                base.GetRandomNumber(NewProductPageResource.
                NewProduct_Page_AccessCode_Characterset_Value, 7));
            Logger.LogMethodExit("NewProductPage", "EnterDemoAccessCode",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Welcome Message for Demo Product.
        /// </summary>
        private void EnterWelcomeMessage()
        {
            //Log Method Entry
            Logger.LogMethodEntry("NewProductPage", "EnterWelcomeMessage",
              base.isTakeScreenShotDuringEntryExit);
            //Switch To Frame
            base.SwitchToIFrame(NewProductPageResource.
            NewProduct_Page_Welcome_Message_Editor_ID_Locator);
            //Click on Text Editor
            base.ClickButtonByClassName("WebEditor");          
            //Enter Welcome message in Welcome Message editor
            base.FillTextBoxByClassName("WebEditor", "Welcome To Demo Product");
            //switch back to the DefaultContent
            base.SwitchToDefaultPageContent();
            Logger.LogMethodExit("NewProductPage", "EnterWelcomeMessage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Name of The Program To Search.
        /// </summary>
        /// <param name="programTypeEnum">This is program type enum.</param>
        private void EnterProgramNameToSearch
            (Program.ProgramTypeEnum programTypeEnum)
        {
            //Enter Program Name In The Search Box
            Logger.LogMethodEntry("NewProductPage", "EnterProgramNameToSearch",
               base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewProductPageResource.
            NewProduct_Page_IFrameSearchProgram_Id_Locator));
            //Switch To Frame
            base.SwitchToIFrame(NewProductPageResource.
            NewProduct_Page_IFrameSearchProgram_Id_Locator);
            base.WaitForElement(By.Id(NewProductPageResource.
                NewProduct_Page_Hed_ProductName_Id_Locator));
            //Get Program from Memory
            Program program = Program.Get(programTypeEnum);
            base.FillTextBoxByID(NewProductPageResource.
                NewProduct_Page_Hed_ProductName_Id_Locator, program.Name);
            //Click Button
            base.ClickButtonByID(NewProductPageResource.NewProduct_Page_SearchButton_Id_Locator);
            Logger.LogMethodExit("NewProductPage", "EnterProgramNameToSearch",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Search Programs Link.
        /// </summary>
        private void ClickSearchProgramsLink()
        {
            //Click Program Search Link
            Logger.LogMethodEntry("NewProductPage", "ClickSearchProgramsLink",
             base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(NewProductPageResource.
                                  NewProduct_Page_Window_Title_Name);
            base.WaitForElement(By.Id(NewProductPageResource.
                                          NewProduct_Page_RightSearch_Id_Locator));
            //Get Search Button Property
            IWebElement getSearchButtonProperty = base.GetWebElementPropertiesById(NewProductPageResource.
                                          NewProduct_Page_RightSearch_Id_Locator);
            base.ClickByJavaScriptExecutor(getSearchButtonProperty);
            Logger.LogMethodExit("NewProductPage", "ClickSearchProgramsLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Program Name In The Searched Frame.
        /// </summary>
        private void SelectProgramNameInTheSearchFrame()
        {
            // Select Created Program
            Logger.LogMethodEntry("NewProductPage", "SelectProgramNameInTheSearchFrame",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(NewProductPageResource.
                NewProduct_Page_PegasusDataGrid_Id_Locator));
            //Wait for Element
            base.WaitForElement(By.Id(NewProductPageResource.
                NewProduct_Page_PegasusDataGrid_Ctrl1_Id_Locator));
            //Select Program Name
            if (!base.IsElementSelectedById(NewProductPageResource.
                NewProduct_Page_PegasusDataGrid_Ctrl1_Id_Locator))
            {
                //Click Button
                base.ClickButtonByID(NewProductPageResource.
                    NewProduct_Page_PegasusDataGrid_Ctrl1_Id_Locator);
            }
            //Select Default Page
            base.SwitchToDefaultPageContent();
            Logger.LogMethodExit("NewProductPage", "SelectProgramNameInTheSearchFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click To Save Product Button.
        /// </summary>
        private void ClickToSaveProduct()
        {
            //Click Product Save Button
            Logger.LogMethodEntry("NewProductPage", "ClickToSaveProduct",
        base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewProductPageResource.
                                          NewProduct_Page_SaveButton_Id_Locator));
            IWebElement getSaveButtonProperty = base.GetWebElementPropertiesById(NewProductPageResource.
                                          NewProduct_Page_SaveButton_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getSaveButtonProperty);
            base.IsPopUpClosed(2);
            Logger.LogMethodExit("NewProductPage", "ClickToSaveProduct",
        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Product Details For Program Type Product.
        /// </summary>
        private void EnterDetailsForProgramTypeProductForHed()
        {
            // Create Program Type Product
            Logger.LogMethodEntry("NewProductPage", "EnterDetailsForProgramTypeProductForHed",
               base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(NewProductPageResource.
                NewProduct_Page_Window_Title_Name);
            base.WaitForElement(By.Id(NewProductPageResource.
                NewProduct_Page_SMSID_TextBox_Id_Locator));
            //Insert Text in Text Box
            base.FillTextBoxByID(NewProductPageResource.
                NewProduct_Page_SMSID_TextBox_Id_Locator,
                AutomationConfigurationManager.SMSMuduleId);
            //Wait For Element
            base.WaitForElement(By.Id(NewProductPageResource.
                NewProduct_Page_ProgramType_CheckBox_Id_Locator));
            IWebElement getProgramTyprCheckBoxProperty = base.GetWebElementPropertiesById(
                NewProductPageResource.NewProduct_Page_ProgramType_CheckBox_Id_Locator);
            base.ClickByJavaScriptExecutor(getProgramTyprCheckBoxProperty);
            Logger.LogMethodExit("NewProductPage", "EnterDetailsForProgramTypeProductForHed",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Discipline Options To Create Hed Product.
        /// </summary>
        private void SelectDisciplineNameToCreateHedProgramTypeProduct()
        {
            //Select Discipline To Create Product
            Logger.LogMethodEntry("NewProductPage", "SelectDisciplineNameToCreateHedProgramTypeProduct",
               base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewProductPageResource.
                                          NewProduct_Page_Discipline_DropDown_Id_Locator));
            //Insert Empty String
            base.FillEmptyTextByID(NewProductPageResource.
                                       NewProduct_Page_Discipline_DropDown_Id_Locator);
            //Select Drop Down Value
            base.SelectDropDownValueThroughTextByID(NewProductPageResource.
                                                NewProduct_Page_Discipline_DropDown_Id_Locator,
                                            NewProductPageResource.NewProduct_Page_Discipline_DropDown_Value);
            Logger.LogMethodExit("NewProductPage", "SelectDisciplineNameToCreateHedProgramTypeProduct",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Product Details To Create Hed Core General Type Product.
        /// </summary>
        private void EnterDetailsForGeneralTypeProductForHed()
        {
            // Create Hed Core General Product
            Logger.LogMethodEntry("NewProductPage", "EnterDetailsForGeneralTypeProductForHed",
               base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(NewProductPageResource.
                NewProduct_Page_Window_Title_Name);
            //Wait for Element
            base.WaitForElement(By.Id(NewProductPageResource.
                NewProduct_Page_SMSID_TextBox_Id_Locator));
            //Insert Text in Text Box
            base.FillTextBoxByID(NewProductPageResource.
                NewProduct_Page_SMSID_TextBox_Id_Locator,
                AutomationConfigurationManager.SMSMuduleId);
            Logger.LogMethodExit("NewProductPage", "EnterDetailsForGeneralTypeProductForHed",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Upload BannerAnd Icon Images For School Product.
        /// </summary>
        /// <param name="productTypeEnum">This is product type enum.</param>
        private void UploadBannerAndIconImagesForSchoolProduct
            (Product.ProductTypeEnum productTypeEnum)
        {
            // Create Product
            Logger.LogMethodEntry("NewProductPage", "UploadBannerAndIconImagesForSchoolProduct",
                base.isTakeScreenShotDuringEntryExit);
            switch (productTypeEnum)
            {
                case Product.ProductTypeEnum.DigitalPath:
                case Product.ProductTypeEnum.PromotedAdminDigitalPath:
                    //Upload Banner Image
                    this.UploadProductBannerImageForDigitalPathProduct();
                    //Upload Product Icon Image
                    this.UploadProductIconImageForDigitalPathProduct();
                    break;
                case Product.ProductTypeEnum.DigitalPathDemo:
                    //Upload Banner Image
                    this.UploadProductBannerImageForDigitalPathProduct();
                    //Upload Product Icon Image
                    this.UploadProductIconImageForDigitalPathProduct();
                    //Upload Welcome Banner Image
                    this.UploadWelcomeBannerImageForNovanetDemoProduct();
                    break;
            }
            Logger.LogMethodExit("NewProductPage", "UploadBannerAndIconImagesForSchoolProduct",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Product Name in TextBox.
        /// </summary>
        /// <param name="productTypeEnum">This is product type enum.</param>
        /// <returns>Product Name Guid.</returns>
        private string EnterProductName(Product.ProductTypeEnum
            productTypeEnum)
        {
            Logger.LogMethodEntry("NewProductPage", "EnterProductName",
           base.isTakeScreenShotDuringEntryExit);
            //This is product name guid
            Guid productNameGuid = Guid.NewGuid();
            switch (productTypeEnum)
            {
                case Product.ProductTypeEnum.DigitalPath:
                case Product.ProductTypeEnum.NovaNET:
                case Product.ProductTypeEnum.DigitalPathDemo:
                case Product.ProductTypeEnum.PromotedAdminDigitalPath:
                    //Wait For The Product Name Textbox
                    base.WaitForElement(By.Id(NewProductPageResource.
                                                  NewProduct_Page_School_ProductName_Id_Locator));
                    //Enter The Product Name
                    base.FillTextBoxByID(NewProductPageResource.
                                             NewProduct_Page_School_ProductName_Id_Locator,
                                             productNameGuid.ToString());
                    break;
                case Product.ProductTypeEnum.HedCoreGeneral:
                case Product.ProductTypeEnum.HedCoreProgram:
                case Product.ProductTypeEnum.HedMilGeneral:
                case Product.ProductTypeEnum.HedMilProgram:
                    //Wait For The Product Name Textbox
                    base.WaitForElement(By.Id(NewProductPageResource.
                                                 NewProduct_Page_Hed_ProductName_Id_Locator));
                    //Enter The Product Name
                    base.FillTextBoxByID(NewProductPageResource.
                                             NewProduct_Page_Hed_ProductName_Id_Locator,
                                             productNameGuid.ToString());
                    break;
            }
            Logger.LogMethodExit("NewProductPage", "EnterProductName",
          base.isTakeScreenShotDuringEntryExit);
            return productNameGuid.ToString();
        }

        /// <summary>
        /// Select Create New Window.
        /// </summary>
        private void SelectCreateNewProductWindow()
        {
            //Select Window
            Logger.LogMethodEntry("NewProductPage", "SelectCreateNewProductWindow",
          base.isTakeScreenShotDuringEntryExit);
            //Wait For Create New product Window
            base.WaitUntilWindowLoads(NewProductPageResource.
                                          NewProduct_Page_Window_Title_Name);
            //Switch To Create New Product Window
            base.SelectWindow(NewProductPageResource.
                                  NewProduct_Page_Window_Title_Name);
            Logger.LogMethodExit("NewProductPage", "SelectCreateNewProductWindow",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Licensing And Product Type For Synapse Product.
        /// <param name="productTypeEnum">This is product by type enum.</param>
        /// </summary>
        private void SelectEnableLicensingAndProductTypeOptions
            (Product.ProductTypeEnum productTypeEnum)
        {
            // Select Licensing And Product Type For Synapse Product
            Logger.LogMethodEntry("NewProductPage", "SelectEnableLicensingAndProductTypeOptions",
              base.isTakeScreenShotDuringEntryExit);
            switch (productTypeEnum)
            {
                case Product.ProductTypeEnum.DigitalPath:
                case Product.ProductTypeEnum.PromotedAdminDigitalPath:
                    //Select Digital Path License and Product
                    this.SelectDigitalPathEnableLicesingOptionValue();
                    SelectDigitalPathProductTypeOptionValue();
                    break;
                case Product.ProductTypeEnum.NovaNET:
                    //Select NovaNET License and Product
                    this.SelectNovaNETEnableLicensingOptionValue();
                    this.SelectNovaNETProductTypeOptionValue();
                    break;
                case Product.ProductTypeEnum.DigitalPathDemo:
                    this.SelectNovaNETEnableLicensingOptionValue();
                    this.SelectDigitalPathProductTypeOptionValue();
                    break;
            }
            Logger.LogMethodExit("NewProductPage", "SelectEnableLicensingAndProductTypeOptions",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select NovaNET Enable Licesing Option Value.
        /// </summary>
        private void SelectNovaNETEnableLicensingOptionValue()
        {
            //Select NovaNET License and Product
            Logger.LogMethodEntry("NewProductPage", "SelectNovaNETEnableLicensingOptionValue",
             base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewProductPageResource.
                                                NewProduct_Page_LicensingType_DropDown_Id_Locator));
            //Focus on Element
            base.FocusOnElementByID(NewProductPageResource.
                NewProduct_Page_LicensingType_DropDown_Id_Locator);
            // Select Licensing Type
            base.SelectDropDownValueThroughTextByID(NewProductPageResource.
                                                NewProduct_Page_LicensingType_DropDown_Id_Locator,
                                            NewProductPageResource.NewProduct_Page_Concurrent_LicensingType_DropDown_Value);
            Logger.LogMethodExit("NewProductPage", "SelectNovaNETEnableLicensingOptionValue",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select NovaNET Product Type Option Value.
        /// </summary>
        private void SelectNovaNETProductTypeOptionValue()
        {
            Logger.LogMethodEntry("NewProductPage", "SelectNovaNETProductTypeOptionValue",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewProductPageResource.
                                          NewProduct_Page_ProductType_DropDown_Id_Locator));
            //Focus On Product Type DropDown
            base.FocusOnElementByID(NewProductPageResource.
                                        NewProduct_Page_ProductType_DropDown_Id_Locator);
            //Select Product Type
            base.SelectDropDownValueThroughTextByID(NewProductPageResource.
                                                        NewProduct_Page_ProductType_DropDown_Id_Locator,
                                                    NewProductPageResource.NewProduct_Page_NovaNET_ProductType_DropDown_Value);
            Logger.LogMethodExit("NewProductPage", "SelectNovaNETProductTypeOptionValue",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Digital Path Enable Licesing Option Value.
        /// </summary>
        private void SelectDigitalPathEnableLicesingOptionValue()
        {
            //Select Digital Path Enable License Option Value
            Logger.LogMethodEntry("NewProductPage", "SelectDigitalPathEnableLicesingOptionValue",
                 base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement((By.Id(NewProductPageResource.
                NewProduct_Page_LicensingType_DropDown_Id_Locator)));
            //Focus on Element
            base.FocusOnElementByID(NewProductPageResource.
                NewProduct_Page_LicensingType_DropDown_Id_Locator);
            // Select Licensing Type
            base.SelectDropDownValueThroughTextByID(NewProductPageResource.
                NewProduct_Page_LicensingType_DropDown_Id_Locator,
                NewProductPageResource.NewProduct_Page_Seat_LicensingType_DropDown_Value);
            Logger.LogMethodExit("NewProductPage", "SelectDigitalPathEnableLicesingOptionValue",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select DP Product Type Option Value.
        /// </summary>
        private void SelectDigitalPathProductTypeOptionValue()
        {
            //Select Product Type Option Value.
            Logger.LogMethodEntry("NewProductPage", "SelectDigitalPathProductTypeOptionValue",
                 base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewProductPageResource.
                                          NewProduct_Page_ProductType_DropDown_Id_Locator));
            //Focus On Product Type DropDown
            base.FocusOnElementByID(NewProductPageResource.
                                        NewProduct_Page_ProductType_DropDown_Id_Locator);
            //Select Product Type
            base.SelectDropDownValueThroughTextByID(NewProductPageResource.
                                                        NewProduct_Page_ProductType_DropDown_Id_Locator,
                                                    NewProductPageResource.NewProduct_Page_Basal_ProductType_DropDown_Value);
            Logger.LogMethodExit("NewProductPage", "SelectDigitalPathProductTypeOptionValue",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Upload Product Banner Image.
        /// </summary>
        private void UploadProductBannerImageForDigitalPathProduct()
        {
            //Upload Banner Image
            Logger.LogMethodEntry("NewProductPage", "UploadProductBannerImageForDigitalPathProduct",
              base.isTakeScreenShotDuringEntryExit);
            //Get the Banner Image path from AppConfig
            string getBannerFilePath = (AutomationConfigurationManager.TestDataPath
                + NewProductPageResource.NewProduct_Page_BannerImage_Name).Replace("file:\\", "");
            //Upload Banner Image
            base.UploadFile(getBannerFilePath, By.Id(NewProductPageResource.
                NewProduct_Page_Button_BrowseBannerImage_Id_Locator));
            Logger.LogMethodExit("NewProductPage", "UploadProductBannerImageForDigitalPathProduct",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Upload Product Icon Image.
        /// </summary>
        private void UploadProductIconImageForDigitalPathProduct()
        {
            //Upload Banner Image
            Logger.LogMethodEntry("NewProductPage", "UploadProductIconImageForDigitalPathProduct",
              base.isTakeScreenShotDuringEntryExit);
            //Select Default Window
            base.SelectDefaultWindow();
            //Select Create New Product Page
            base.SelectWindow(NewProductPageResource.
                                  NewProduct_Page_Window_Title_Name);
            //Get the Icon Image path from AppConfig
            string getIconFilePath = (AutomationConfigurationManager.TestDataPath
                + NewProductPageResource.NewProduct_Page_IconImage_Name).Replace("file:\\", "");
            //Upload Icon Image
            base.UploadFile(getIconFilePath, By.Id(NewProductPageResource.
                NewProduct_Page_Button_BrowseIconImage_Id_Locator));
            Logger.LogMethodExit("NewProductPage",
                "UploadProductIconImageForDigitalPathProduct", base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Upload Demo Product Welcome Banner Image.
        /// </summary>
        private void UploadWelcomeBannerImageForNovanetDemoProduct()
        {
            //Upload Banner Image
            Logger.LogMethodEntry("NewProductPage", "UploadWelcomeBannerImageForNovanetDemoProduct",
              base.isTakeScreenShotDuringEntryExit);
            //Select Default Window
            base.SelectDefaultWindow();
            //Select Create New Product Page
            base.SelectWindow(NewProductPageResource.
                                  NewProduct_Page_Window_Title_Name);
            //Get the Icon Image path from AppConfig
            string getIconFilePath = (AutomationConfigurationManager.TestDataPath
                + NewProductPageResource.NewProduct_Page_IconImage_Name).Replace("file:\\", "");
            //Upload Icon Image
            base.UploadFile(getIconFilePath, By.Id(NewProductPageResource.
                NewProduct_Page_Button_BrowseWelcomeImage_Id_Locator));
            Logger.LogMethodExit("NewProductPage",
                "UploadWelcomeBannerImageForNovanetDemoProduct", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save Product in memory against Pegasus Product Type.
        /// </summary>
        /// <param name="productTypeEnum">This is Product Type .</param>
        /// <param name="productName">This is Product Name Guid.</param>
        private void StoreProductDetailsInMemory
            (Product.ProductTypeEnum productTypeEnum,
            String productName, String demoAccessCode = "")
        {
            //Save Copy Course in Memory
            Logger.LogMethodEntry("NewProductPage", "StoreProductDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
            Product newProduct = new Product
              {
                  //Product Details
                  Name = productName,
                  ProductType = productTypeEnum,
                  DemoAccessCode = demoAccessCode,
                  IsCreated = true,
              };
            newProduct.StoreProductInMemory();
            Logger.LogMethodExit("NewProductPage", "StoreProductDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select MyItLab Program Admin Reporting
        /// </summary>
        private void SelectMyItLabProgramAdminReportingCheckBox()
        {
            //Select MyItLab Program Admin Reporting
            Logger.LogMethodEntry("NewProductPage", "SelectMyItLabProgramAdminReportingCheckBox",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(NewProductPageResource.
                NewProduct_Page_MyItLabProgramAdminReporting_Id_Locator));
            //Select the Check Box Property
            IWebElement getCheckBoxProperty = base.
                GetWebElementPropertiesById(NewProductPageResource.
                NewProduct_Page_MyItLabProgramAdminReporting_Id_Locator);
            //Select the Checkbox
            base.ClickByJavaScriptExecutor(getCheckBoxProperty);
            Logger.LogMethodExit("NewProductPage", "SelectMyItLabProgramAdminReportingCheckBox",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
