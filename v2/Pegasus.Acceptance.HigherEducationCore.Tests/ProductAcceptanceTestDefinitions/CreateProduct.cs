using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Create Product Page Actions
    /// and it also resposible to create different types of product
    /// in every Pegasus product instance.
    /// </summary>
    [Binding]
    public class CreateProduct : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CreateProduct));

        /// <summary>
        /// Click on the Create New Product Link.
        /// </summary>        
        [When(@"I click on the 'Create New Product' Link")]
        public void ClickOnTheLink()
        {
            //Click on the Link
            Logger.LogMethodEntry("CreateProduct", "ClickOnTheLink",
                base.isTakeScreenShotDuringEntryExit);
            //Declaration Page Class Object
            ManageProductsPage manageProductsPage =
                new ManageProductsPage();
            //Create New Product
            manageProductsPage.ClickOnCreateNewProductLink();
            Logger.LogMethodExit("CreateProduct", "ClickOnTheLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create New Pegasus Product.
        /// </summary>
        /// <param name="productTypeEnum">This is Product Type Enum.</param>
        /// <param name="programTypeEnum">This is Program Type Enum.</param>
        [When(@"I create ""(.*)"" type product using ""(.*)"" program type")]
        public void CreateProductUsingProgram(Product.ProductTypeEnum
            productTypeEnum, Program.ProgramTypeEnum programTypeEnum)
        {
            //Creation of Product
            Logger.LogMethodEntry("CreateProduct",
                "CreateProductUsingProgram",
                base.isTakeScreenShotDuringEntryExit);
            //Create Product
            new NewProductPage().CreateNewProduct(
                productTypeEnum, programTypeEnum);
            Logger.LogMethodExit("VerifyCreateNewProduct",
                "CreateProductUsingProgram",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to  Manage Products Page.
        /// </summary>
        [Given(@"I am on the 'Manage Products' Page")]
        public void NavigateToManageProductsPage()
        {
            //Manage to navigate  Products Page
            Logger.LogMethodEntry("CreateProduct",
                "NavigateToManageProductsPage",
                base.isTakeScreenShotDuringEntryExit);
            //Navigate to Manage Products Page
            new AdminToolPage().NavigateManageProductsPage();
            Logger.LogMethodExit("CreateProduct",
                "NavigateToManageProductsPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Option Of Product In Coursespace.
        /// </summary>
        /// <param name="cmenuOption">This is Product Cmenu Option.</param>
        [When(@"I click on ""(.*)"" cmenu option of product in coursespace")]
        public void SelectCmenuOptionOfProductInCoursespace(string cmenuOption)
        {
            //Select Cmenu Option Of Product In Coursespace
            Logger.LogMethodEntry("CreateProduct",
                "SelectCmenuOptionOfProductInCoursespace",
                base.isTakeScreenShotDuringEntryExit);
            //Select Product Cmenu Option
            new ManageProductsPage().SelectProductCmenuOption(cmenuOption);
            Logger.LogMethodExit("CreateProduct",
                "SelectCmenuOptionOfProductInCoursespace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Product In Right Frame.
        /// </summary>
        /// <param name="productTypeEnum">This is Product Type Enum.</param>
        [When(@"I search the product type ""(.*)"" in right frame")]
        public void SearchProductInRightFrame(Product.ProductTypeEnum
            productTypeEnum)
        {
            //Search Product In Right Frame
            Logger.LogMethodEntry("CreateProduct",
                "SearchProductInRightFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Get Product FromMemory
            Product product = Product.Get(productTypeEnum);
            //Click Search Product Link
            new ProductManagementContainerPage().ClickSearchProductLink();
            //Enter Product Name and Click on Search Button
            new ProductSearchPage().
                EnterProductNameandClickonSearchButton(product.Name);
            Logger.LogMethodExit("CreateProduct",
                "SearchProductInRightFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is called before execution of test.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// This function is called after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
