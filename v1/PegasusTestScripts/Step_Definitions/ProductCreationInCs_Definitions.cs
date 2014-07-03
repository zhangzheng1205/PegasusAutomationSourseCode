using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class ProductCreationInCsDefinitions : BaseTestScript
    {
        // Calling of other classes
        readonly NewProductPage _newProductPage = new NewProductPage();
        readonly ManageProductsPage _manageProductsPage = new ManageProductsPage();
        //Purpose: Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        //Purpose: To click the 'Create New Product' link
        [Given(@"I Click on the 'Create New Product' link")]
        [When(@"I Click on the 'Create New Product' link")]
        [Then(@"I Click on the 'Create New Product' link")]
        public void GivenIClickTheCreateNewProgramLink()
        {
            try
            {
                GenericHelper.SelectWindow("Manage Products");
                _manageProductsPage.ClickCreateNewProductLink();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose: To Created Product
        [Given(@"I created the product")]
        [When(@"I created the product")]
        [Then(@"I created the product")]
        public void GivenICreatedTheProgram()
        {
            try
            {
                _newProductPage.CreateProduct();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }
    }
}

