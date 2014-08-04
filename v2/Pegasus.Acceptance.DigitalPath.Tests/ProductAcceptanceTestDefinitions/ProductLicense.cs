using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace Pegasus.Acceptance.DigitalPath.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public class ProductLicense : BasePage
    {

        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ProductLicense));

        /// <summary>
        /// 
        /// </summary>
        [When(@"I click on the Add Products Option")]
        public void ClickOnTheAddProductsOption()
        {
            //Click on Add Products Option
            Logger.LogMethodEntry("ProductLicense",
                "ClickOnTheAddProductsOption",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on Add Product Link
            new LicensesPage().ClickAddProductOptionLink();
            Logger.LogMethodExit("ProductLicense",
                "ClickOnTheAddProductsOption",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// License same DigitalPath Demo Product multiple times
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        [When(@"I create (.*) license for the ""(.*)"" product")]
        public void WhenICreateLicenseForTheProduct(int ProductLicenseCount, Product.ProductTypeEnum
            productTypeEnum)
        {
            //License the Product
            Logger.LogMethodEntry("ProductLicense", "LicenseTheProduct",
               base.IsTakeScreenShotDuringEntryExit);
            //To select the product stored in memory
            Product product = Product.Get(productTypeEnum);
            //To add same product Multiple Times
            var produtname = product.Name;
            for (int i = 1; i <= ProductLicenseCount; i++)
            {
                //License the Product
                new AvailableProductsPage().LicenseProduct(produtname);
                //Enter License Details
                new CreateLicensePage().EnterLicenseDetail(productTypeEnum);
                if (i != ProductLicenseCount)
                {
                    //Click on Add Product Link
                    new LicensesPage().ClickAddProductOptionLink();
                }
            }

            Logger.LogMethodExit("ProductLicense", "LicenseTheProduct",
            base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
            //To select the product stored in memory
            License license = License.Get(licenseTypeEnum);
            //Search Licensed Product
            new LicensesPage().SearchLicensedProduct(license.Name);
            Logger.LogMethodExit("ProductLicense",
                "SearchLicensedProductInCoursespace",
            base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
            //To select the product stored in memory
            License license = License.Get(licenseTypeEnum);
            // Assert Licensed Product Search
            Logger.LogAssertion("VerifyProductSearch", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(license.Name,
                    new LicensesPage().GetLicensedProduct()));
            Logger.LogMethodExit("ProductLicense",
                "VerifySearchedLicensedProduct",
            base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //To select the product stored in memory
            List<Product> products = new List<Product>();
            products = Product.GetAll(productTypeEnum);
            for (int i = 1; i <= ProductLicenseCount; i++)
            {
                //License the Product
                new AvailableProductsPage().LicenseProduct(products[i - 1].Name);
                //Enter License Details
                new CreateLicensePage().EnterLicenseDetail(productTypeEnum);
                if (i != ProductLicenseCount)
                {
                    //Click on Add Product Link
                    new LicensesPage().ClickAddProductOptionLink();
                }
            }

            Logger.LogMethodExit("ProductLicense", "LicenseTheProduct",
            base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
