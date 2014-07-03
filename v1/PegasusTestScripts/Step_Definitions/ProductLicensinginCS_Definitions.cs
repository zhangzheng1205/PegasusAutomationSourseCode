using System;
using OpenQA.Selenium;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference;
using TechTalk.SpecFlow;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class ProductLicensinginCSDefinitions : BaseTestScript
    {
        //Purpose: Calling of Other Page Class Methods
        private readonly OrganizationManagementPage _objOrg = new OrganizationManagementPage();
        private readonly ManageOrganizationPage _objManageOrg = new ManageOrganizationPage();
        private readonly LicensesPage _objLicense = new LicensesPage();

        // Purpose: To select the organization

        [When("I select the Organization")]
        public void SelectTheOrganization()
        {
            try
            {
                _objOrg.ManageDistrictLevel();
            }

            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose: To select the Licenses Tab
        [Given("I select the Licenses Tab")]
        [Then("I select the Licenses Tab")]
        public void SelectLicensesTab()
        {
            try
            {
                _objManageOrg.SelectLicensesTab();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose  -  To create the product License
        [When("I create the \"(.*)\" product License")]
        public void WhenICreateTheSchoolProductLicense(string productInstance)
        {
            try
            {
                _objLicense.CreateLicenses(productInstance);
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
