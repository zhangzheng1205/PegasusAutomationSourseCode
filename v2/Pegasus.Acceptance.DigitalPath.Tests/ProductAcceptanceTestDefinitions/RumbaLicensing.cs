#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Integration.Rumba;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    ///<summary/>
    ///This class handles rumba licensing actions.
    ///<summary/>
    [Binding]
    public class RumbaLicensing : PegasusBaseTestFixture
    {
        /// <summary>
        /// Static instance of the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(RumbaLicensing));

        /// <summary>
        /// Login to Rumba as RAdmin.
        /// </summary>
        /// <param name="userTypeEnum">This Is User By Type Enum.</param>
        [When(@"I login to rumba as ""(.*)""")]
        public void LoginToRumba(User.UserTypeEnum userTypeEnum)
        {   //Login to Rumba
            Logger.LogMethodEntry("RumbaLicensing", "LoginToRumba",
                base.isTakeScreenShotDuringEntryExit);
            //Login To Rumba
            new SignInPage().LoginToRumba(userTypeEnum);
            Logger.LogMethodExit("RumbaLicensing", "LoginToRumba",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the SignOut link.
        /// </summary>
        /// <param name="linkSignOut">This is SignOut Link.</param>
        [When("I \"(.*)\" from Rumba")]
        public void SignOutFromRumba(String linkSignOut)
        {
            //Click on SignOut link
            Logger.LogMethodEntry("LoginLogout", "SignOutFromRumba",
                base.isTakeScreenShotDuringEntryExit);
            new SignInPage().ClickSignOutLink(linkSignOut);
            Logger.LogMethodExit("LoginLogout", "SignOutFromRumba",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate Logout From Rumba.
        /// </summary>
        /// <param name="signOutMessage">This Is The SignOut Message.</param>
        [Then(@"I should see the ""(.*)"" message")]
        public void ValidateLogoutFromRumba(String signOutMessage)
        {
            //Validate Logout From Rumba
            Logger.LogMethodEntry("LoginLogout", "ValidateLogoutFromRumba",
               base.isTakeScreenShotDuringEntryExit);
            //Assert Logout
            Logger.LogAssertion("ValidateLogout",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(signOutMessage, new SignInPage().GetRumbaUserSignOutMessage()));
            Logger.LogMethodExit("LoginLogout", "ValidateLogoutFromRumba",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create new organizational Product.
        /// </summary>
        [When(@"I create a organizational product")]
        public void CreateOrganizationalProduct()
        {
            //Create New Organizational Product
            Logger.LogMethodEntry("RumbaLicensing", "CreateOrganizationalProduct",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Create Product Link
            new WelcometoRADminPage().ClickonCreateProductLink();
            //Creates Rumba Product
            new CreateProductPage().CreateRumbaProduct();
            Logger.LogMethodExit("RumbaLicensing", "CreateOrganizationalProduct",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the product created successfully or not
        /// </summary>
        [Then(@"I should see the product successfully created with valid product id")]
        public void ProductSuccessfullyCreated()
        {
            //Verify the product created successfully or not
            Logger.LogMethodEntry("RumbaLicensing", "ProductSuccessfullyCreated",
                base.isTakeScreenShotDuringEntryExit);
            //Gets the product id from memory
            License license = License.Get(License.LicenseTypeEnum.Rumba);
            //Assert the product creation
            Logger.LogAssertion("VerifyProductSuccessfullyCreated", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                    (license.ProductID, new CreateProductPage().GetRumbaProductID()));
            Logger.LogMethodExit("RumbaLicensing", "ProductSuccessfullyCreated",
                base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Create resource.
        /// </summary>
        [When(@"I create a organizational resource")]
        public void CreateRumbaOrganizationalResource()
        {
            // Create resource
            Logger.LogMethodEntry("RumbaLicensing", "CreateRumbaOrganizationalResource",
                base.isTakeScreenShotDuringEntryExit);
            //Click on create resource link
            new WelcometoRADminPage().ClickCreateResourceLink();
            //Create Resource
            new CreateResourcePage().CreateRumbaResource();
            Logger.LogMethodExit("RumbaLicensing", "CreateRumbaOrganizationalResource",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the resource created successfuly or not.
        /// </summary>
        [Then(@"I should see the resource successfully created with valid resource id")]
        public void ResourceSuccessfullyCreated()
        {
            //Verify the resource created successfuly or not
            Logger.LogMethodEntry("RumbaLicensing", "ResourceSuccessfullyCreated",
                base.isTakeScreenShotDuringEntryExit);
            //Gets the resource id from the memory
            License licenses = License.Get(License.LicenseTypeEnum.Rumba);
            //Asserts resource creation        
            Logger.LogAssertion("VerifyResourceSuccessfullyCreated", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(licenses.ResourceID,
                    new CreateResourcePage().GetRumbaResourceId()));
            Logger.LogMethodExit("RumbaLicensing", "ResourceSuccessfullyCreated",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add the product id to resource id.
        /// </summary>
        [When(@"I add the created resource to the product")]
        public void AddRumbaResourceToRumbaProduct()
        {
            //Add the product id to resource id
            Logger.LogMethodEntry("RumbaLicensing", "AddRumbaResourceToRumbaProduct",
                base.isTakeScreenShotDuringEntryExit);
            //Creating Page Class Object
            ProductsAndResourcesPage productAndResourcesPage = new ProductsAndResourcesPage();
            //Click on Product and Resource
            productAndResourcesPage.ClickOnProductsAndResourcesTab();
            //To add the product id to resource id
            productAndResourcesPage.AddProductIDToResourceID();
            Logger.LogMethodExit("RumbaLicensing", "AddRumbaResourceToRumbaProduct",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Place a new order for a license to use a product.
        /// </summary>
        /// <param name="organizationLevelEnum">This is organization level enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        [When(@"I place a new order for a license to use a ""(.*)"" level product in ""(.*)""")]
        public void PlaceNewOrderForProductLicense(Organization.OrganizationLevelEnum
            organizationLevelEnum, Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Place A New Order For A License To Use A Product
            Logger.LogMethodEntry("RumbaLicensing", "PlaceNewOrderForProductLicense",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Place An Order Link
            new WelcometoRADminPage().ClickOnPlaceAnOrderLink();
            //Place an product license order
            new PlaceOrderPage().PlaceOrganizationLicenseOrder(
                organizationLevelEnum, organizationTypeEnum);
            Logger.LogMethodExit("RumbaLicensing", "PlaceNewOrderForProductLicense",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// The Resource Added In The Ceated Product.
        /// </summary>
        [Then(@"I should see the resource successfully added in the created product")]
        public void ResourceAddedInTheCreatedProduct()
        {
            // The Resource Added In The Ceated Product
            Logger.LogMethodEntry("RumbaLicensing", "ResourceAddedInTheCreatedProduct",
                base.isTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyResourceAddedToProduct",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(RumbaLicensingResource.RumbaLicensing_AddResource_SuccessMessage,
                    new ProductsAndResourcesPage().GetSuccessMessage()));
            Logger.LogMethodExit("RumbaLicensing", "ResourceAddedInTheCreatedProduct",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Product Order Placed Successfully.
        /// </summary>
        [Then(@"I should see product order placed successfully")]
        public void ProductOrderPlacedSuccessfully()
        {
            // Product Order Placed Successfully
            Logger.LogMethodEntry("RumbaLicensing", "ProductOrderPlacedSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Success Message
            Logger.LogAssertion("VerifyProductOrderPlacedSuccessfully",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true, new PlaceOrderPage().GetCreateLicenseSuccessMessage().
                Contains(RumbaLicensingResource.RumbaLicensing_PlaceOrderSuccessMessage)));
            Logger.LogMethodExit("RumbaLicensing", "ProductOrderPlacedSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Initialize Pegasus test before test execution start
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
