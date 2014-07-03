#region

using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.Contineo.Tests.
    ContineoAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains details of Create Product.
    /// </summary>
    [Binding]
    public class CreateProduct : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(CreateProduct));

        /// <summary>
        /// Create New Pegasus Product.
        /// </summary>
        /// <param name="productTypeEnum">This is Product by Type. </param>
        /// <param name="programTypeEnum">This is Program by Type.</param>
        [When(@"I create the ""(.*)"" Product in coursespace using ""(.*)"" Program")]
        public void CreateProductUsingProgram(Product.ProductTypeEnum
           productTypeEnum, Program.ProgramTypeEnum programTypeEnum)
        {
            //Creation of DP Product
            Logger.LogMethodEntry("CreateProduct", "CreateProductUsingProgram",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Create new Product Link
            new ManageProductsPage().ClickOnCreateNewProductLink();
            //Create DP Product
            new NewProductPage().CreateNewProduct(productTypeEnum, programTypeEnum);
            Logger.LogMethodExit("VerifyCreateNewProduct", "CreateProductUsingProgram",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to  Manage Products Page.
        /// </summary>
        [Given(@"I am on the 'Manage Products' Page")]
        public void NavigateToManageProductsPage()
        {
            //Manage to navigate  Products Page
            Logger.LogMethodEntry("CreateProduct", "NavigateToManageProductsPage",
                base.isTakeScreenShotDuringEntryExit);
            //Navigate to Manage Products Page
            new AdminToolPage().NavigateManageProductsPage();
            Logger.LogMethodExit("CreateProduct", "NavigateToManageProductsPage",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Initialize Pegasus test before test execution starts
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
