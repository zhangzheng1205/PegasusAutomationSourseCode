using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference;
using TechTalk.SpecFlow;
using System.Threading;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.User;

namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class UserSCreationInCsDefinitions : BaseTestScript
    {
        //Purpose: Using Readonly Object
        readonly OrganizationManagementPage _organizationManagement = new OrganizationManagementPage();
        readonly ManageUserPage _manageUserPage = new ManageUserPage();
        readonly ImportUsersPage _importUsersPage = new ImportUsersPage();
        //Purpose: To verify control is in Manage Organization page
        [Given(@"I am on the 'Manage Organization' page")]
        public void GivenIAmOnTheManageOrganizationPage()
        {
            try
            {
                _organizationManagement.GoToManageOrganizationPage();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To create CS user
        [When(@"I created the CsUser as Student")]
        [When(@"I created the CsUser as Teacher")]
        [When(@"I created the CsUser as OrgAdmin")]
        public void WhenICreatedTheUserAsStudent(Table table)
        {
            try
            {
                bool isWindowPresent = GenericHelper.IsPopUpWindowPresent("Manage Organization");
                if (isWindowPresent)
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.SwitchTo().DefaultContent();
                }
                else
                {
                   // WebDriver.Close();
                    string schoolName = DatabaseTools.GetOrganization(Enumerations.OrgLevelType.School);
                    _organizationManagement.SearchAndSelectOrg(schoolName);
                }
                // Purpose: To Create Users
                _manageUserPage.Createusers(table);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Manage Organization"))
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose: to select 'Import Users from File' option
        [When(@"I select the Bulk user upload option")]
        public void WhenISelectTheBulkUserUploadOption()
        {
            try
            {
                _manageUserPage.SelectImportUsers();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose: to Import the users 
        [When(@"I Import a bulk user\(s\) file")]
        public void WhenIImportABulkUserSFile()
        {
            try
            {
                _importUsersPage.ImportUsers();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose: to verify upload text displayed after file upload
        [Then(@"It should successfully upload the users")]
        public void ThenItShouldSuccessfullyUploadTheUsers()
        {
            try
            {
                _manageUserPage.verifyBulkRegistration();

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
