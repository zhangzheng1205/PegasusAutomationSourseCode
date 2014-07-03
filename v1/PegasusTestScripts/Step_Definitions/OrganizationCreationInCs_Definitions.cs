using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_DataAccess;
using Framework.Common;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.OrganizationManagement;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class OrganizationCreationInCsDefinitions : BaseTestScript
    {
        //Purpose: Calling Page Class
        readonly CreateOrganisationPage _createOrganisation = new CreateOrganisationPage();
        readonly OrganizationManagementPage _organizationManagement = new OrganizationManagementPage();
        // Purpose: Contant Declaration
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //Purpose : To Click on the 'Create New Organisation' button
        [Given(@"I Click on the 'Create New Organisation' button")]
        public void GivenIClickOnTheCreateNewOrganisationButton()
        {
            try
            {
                _organizationManagement.ClickCreateNewOrganisationButton();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Thread.Sleep(3000);
                throw new Exception(e.ToString());
            }
        }

        // Purpose: To create District level of Organization at root
        [Given(@"I create District as root level of organization")]
        public void GivenICreateDistrictAsRootLevelOfOrganization()
        {
            try
            {
                _createOrganisation.CreateDistrictAtRootLevel();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Thread.Sleep(3000);
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To search and select the Organization 
        [Given(@"I selected the District Level of Organization\.")]
        public void GivenISelectedTheDistrictLevelOfOrganization()
        {
            try
            {
                string distName = DatabaseTools.GetOrganization(Enumerations.OrgLevelType.District);
                _organizationManagement.SearchAndSelectOrg(distName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Thread.Sleep(3000);
                throw new Exception(e.ToString());
            }
        }


        // Purpose: To create school level of Organization
        [Given(@"I Create School level of Organization")]
        public void GivenICreateSchoolLevelOfOrganization()
        {
            try
            {
                _organizationManagement.ClickAddSchool();
                _createOrganisation.CreateSchool();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Thread.Sleep(3000);
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To verify the control is on 'Organization Management' page
        [When(@"I go to the 'Organization Management' page")]
        [Given(@"It should show the 'Organization Admin' page")]
        public void GivenItShouldShowTheOrganizationAdminPage()
        {
            try
            {
                _organizationManagement.NavigatingToOrganizationManagementPage();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Thread.Sleep(3000);
                throw new Exception(e.ToString());
            }
        }
    }
}
