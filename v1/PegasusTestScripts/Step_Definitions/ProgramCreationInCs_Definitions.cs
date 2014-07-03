using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class ProgramCreationInCsDefinitions:BaseTestScript
    {
        // Calling of other classes
        private readonly ProgramCreatePage _programCreatePage = new ProgramCreatePage();
        private readonly ProgramManagementPage _programManagementPage = new ProgramManagementPage();
        //Purpose: Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        //Purpose: To click on 'Create New Program' link
        [When(@"I click the 'Create New Program' link")]
        [Then(@"I click the 'Create New Program' link")]
        [Given(@"I click the 'Create New Program' link")]
        public void GivenIClickTheCreateNewProgramLink()
        {
            try
            {
             GenericHelper.SelectWindow("Manage Programs");
                _programManagementPage.ClickCreateNewProgramLink();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();              
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To create the program
        [When(@"I created the program")]
        [Then(@"I created the program")]
        [Given(@"I created the program")]
        public void GivenICreatedTheProgram()
        {
            try
            {
              _programCreatePage.CreateProgram();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To verify the control is on 'Manage Programs' page
        [Then(@"It should show the 'Manage Programs' page")]
        public void ThenItShouldShowTheManageProgramsPage()
        {
            try
            {
                _programManagementPage.NavigatingToManageProgramsPage();
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
