using System;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class CourseAssociationToProductInCsDefinitions : BaseTestScript
    {
        // Purpose: Calling Methods of Page Class
        readonly ListCoursesPage _coursesPage = new ListCoursesPage();
        readonly ProductSearchPage _productSearchPage = new ProductSearchPage();
        private readonly CourseEnrollmentModePage _courseEnrollmentModePage = new CourseEnrollmentModePage();
        private readonly AddButtonPage _addButtonPage = new AddButtonPage();
        private readonly ManageProductsPage _manageProductsPage = new ManageProductsPage();

        //Purpose: To select the Product in the right frame
        [Given("I select the \"(.*)\" product in the right frame")]
        public void GivenISelectTheSchoolProductInTheRightFrame(string productInstance)
        {
            try
            {
                _productSearchPage.SearchProductAndOpen(productInstance);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To select the Course
        [Given("I select the \"(.*)\" course")]
        public void GivenISelectTheCourse(string courseType)
        {
            try
            {
                _coursesPage.SearchCourse(courseType);
                _coursesPage.ClickSelectAllCheckBox();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To associate the course to product
        [When(@"I associate the course to product")]
        public void WhenIAssociateTheCourseToProduct()
        {
            try
            {
                _addButtonPage.ClickAddButton();
                _courseEnrollmentModePage.ClickSaveButton();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To verify the control is on 'Manage Products' page
        [Given(@"It should show the 'Manage Products' page")]
        [Then(@"It should show the 'Manage Products' page")]
        public void ThenItShouldShowTheManageProductsPage()
        {
            try
            {
                _manageProductsPage.NavigateToManageProductsPage();
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
