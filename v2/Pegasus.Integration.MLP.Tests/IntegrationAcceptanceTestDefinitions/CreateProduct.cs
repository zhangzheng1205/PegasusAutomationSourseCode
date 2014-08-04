using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MLP.Tests.Definitions
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
        /// This is the logger.
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
                base.IsTakeScreenShotDuringEntryExit);
            //Declaration Page Class Object
            ManageProductsPage manageProductsPage = 
                new ManageProductsPage();
            //Create New Product
            manageProductsPage.ClickOnCreateNewProductLink();
            Logger.LogMethodExit("CreateProduct", "ClickOnTheLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create New Pegasus Product.
        /// </summary>
        /// <param name="productTypeEnum">This is Product Type enum.</param>
        /// <param name="programTypeEnum">This is Program Type enum.</param>
        [When(@"I create ""(.*)"" type product using ""(.*)"" program type")]
        public void CreateProductUsingProgram(Product.ProductTypeEnum
            productTypeEnum, Program.ProgramTypeEnum programTypeEnum)
        {
            //Creation of Product
            Logger.LogMethodEntry("CreateProduct", 
                "CreateProductUsingProgram",
                base.IsTakeScreenShotDuringEntryExit);
            //Create Product
            new NewProductPage().CreateNewProduct(
                productTypeEnum, programTypeEnum);
            Logger.LogMethodExit("VerifyCreateNewProduct", 
                "CreateProductUsingProgram",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Navigate to Manage Products Page
            new AdminToolPage().NavigateManageProductsPage();
            Logger.LogMethodExit("CreateProduct", 
                "NavigateToManageProductsPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

    }
}
