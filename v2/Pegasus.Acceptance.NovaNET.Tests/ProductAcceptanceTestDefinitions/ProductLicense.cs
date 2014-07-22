using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class Handles Product License actions.
    /// </summary>
    [Binding]
    public class ProductLicense : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(ProductLicense));
        
        //Click on Add Products Option .
        [When(@"I click on the Add Products Option")]
        public void ClickOnTheAddProductsOption()
        {
            //Click on Add Products Option
            Logger.LogMethodEntry("ProductLicense", 
                "ClickOnTheAddProductsOption",
               base.isTakeScreenShotDuringEntryExit);
            //Click on Add Product Link
            new LicensesPage().ClickAddProductOptionLink();
            Logger.LogMethodExit("ProductLicense", 
                "ClickOnTheAddProductsOption",
            base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// License the Product.
        /// </summary>
        /// <param name="productTypeEnum">This is product 
        /// by Type Enum.</param>
        [When(@"I create license for the ""(.*)"" product")]
        public void LicenseTheProduct(Product.ProductTypeEnum 
            productTypeEnum)
        {
            //License the Product
            Logger.LogMethodEntry("ProductLicense", "LicenseTheProduct",
               base.isTakeScreenShotDuringEntryExit);
            //To select the product stored in memory
            Product product = Product.Get(productTypeEnum);
            //License the Product
            new AvailableProductsPage().LicenseProduct(product.Name);
            //Enter License Details
            new CreateLicensePage().EnterLicenseDetail(productTypeEnum);
            Logger.LogMethodExit("ProductLicense", "LicenseTheProduct",
            base.isTakeScreenShotDuringEntryExit);
        }

       
       
        /// <summary>
        /// License multiple DigitalPath Demo Product
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        [When(@"I create (.*) licenses for different ""(.*)"" product")]
        public void WhenICreateLicensesForDifferentProduct(int ProductLicenseCount, Product.ProductTypeEnum
            productTypeEnum)
        {
            //License the Product
            Logger.LogMethodEntry("ProductLicense", "LicenseTheProduct",
               base.isTakeScreenShotDuringEntryExit);
            //To select the product stored in memory
            List<Product> products = new List<Product>();
            products = Product.GetAll(productTypeEnum);
            for (int i = 1; i <= ProductLicenseCount; i++)
            {
                //License the Product
                new AvailableProductsPage().LicenseProduct(products[i-1].Name);
                //Enter License Details
                new CreateLicensePage().EnterLicenseDetail(productTypeEnum);
                if (i != ProductLicenseCount)
                {
                    //Click on Add Product Link
                    new LicensesPage().ClickAddProductOptionLink();
                }
            }

            Logger.LogMethodExit("ProductLicense", "LicenseTheProduct",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the Licensed Product.
        /// </summary>
        /// <param name="licenseTypeEnum">This is license 
        /// by Type Enum.</param>
        [When(@"I search ""(.*)"" licensed product in Coursespace")]
        public void SearchLicensedProductInCoursespace(
            License.LicenseTypeEnum licenseTypeEnum)
        {
            Logger.LogMethodEntry("ProductLicense", 
                "SearchLicensedProductInCoursespace",
              base.isTakeScreenShotDuringEntryExit);
            //To select the product stored in memory
            License license = License.Get(licenseTypeEnum);
            //Search Licensed Product
            new LicensesPage().SearchLicensedProduct(license.Name);
            Logger.LogMethodExit("ProductLicense",
                "SearchLicensedProductInCoursespace",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Pegasus License product.
        /// </summary>
        /// <param name="licenseTypeEnum">This is 
        /// license by Type Enum.</param>
        [Then(@"I should be able to see the searched ""(.*)"" licensed product in the frame")]
        public void VerifySearchedLicensedProduct(
            License.LicenseTypeEnum licenseTypeEnum)
        {
            Logger.LogMethodEntry("ProductLicense", 
                "VerifySearchedLicensedProduct",
              base.isTakeScreenShotDuringEntryExit);
            //To select the product stored in memory
            License license = License.Get(licenseTypeEnum);
            // Assert Licensed Product Search
            Logger.LogAssertion("VerifyProductSearch", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(license.Name,
                    new LicensesPage().GetLicensedProduct()));
            Logger.LogMethodExit("ProductLicense", 
                "VerifySearchedLicensedProduct",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter into the Organization.
        /// </summary>
        [Given(@"I enter into the organization")]
        public void EnterIntoTheOrganization()
        {
            //Enter into the Organization
            Logger.LogMethodEntry("ProductLicense", 
                "EnterIntoTheOrganization",
              base.isTakeScreenShotDuringEntryExit);
            //Click on Manage Button
            new OrganizationSearchPage().ClickOnManageButtonOfOrganization();
            Logger.LogMethodExit("ProductLicense", 
                "EnterIntoTheOrganization",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
       
    }
}
