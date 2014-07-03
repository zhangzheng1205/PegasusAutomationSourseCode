using System;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Template;
using TechTalk.SpecFlow;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class TemplateCreationInCSDefinitions : BaseTestScript
    {
        //Calling of other Class Methods
        private readonly ManageOrganizationPage _objManageOrg = new ManageOrganizationPage();
        private readonly ManageTemplatePage _objTemplate = new ManageTemplatePage();

        // purpose - To select library tab in manage organization page
        [Given("I select the Libraries Tab")]
        [Then("I select the Libraries Tab")]
        public void SelectTheLibrariesTab()
        {
            try
            {
                _objManageOrg.SelectLibrariesTab();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");              
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();                
                throw new Exception(e.ToString());
            }
        }

        // purpose - Create Template using container course
        [When("I created the Template using Container Course")]
        public void CreateTheTemplateUsingContainerCourse()
        {
            try
            {
                _objTemplate.ToSelectAddTemplate();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // purpose - Wait till the template gets created
        [When("I Wait for the template out from Assign To Copy State")]
        public void WaitForTemplatefromAssignToCopy()
        {
            try
            {
                _objTemplate.ToSearchForAssigned();
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
