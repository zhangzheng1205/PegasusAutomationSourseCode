using System;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.Enrollment;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class UserEnrollmentInClassDefinitions : BaseTestScript
    {
        private readonly EnrollClassesPage _enrollClassesPage = new EnrollClassesPage();
        private readonly UserEnrollmentPage _enrollmentPage = new UserEnrollmentPage();


        //Purpose : To select class
        [Given("I Select the \"(.*)\" class")]
        public void WhenISelectTheClass(string classType)
        {
            try
            {
                _enrollClassesPage.SelectClassWithClassType(classType);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");            
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Thread.Sleep(3000);
                throw new Exception(e.ToString());
            }
        }

        //Purpose: to select user
        [When("I select the \"(.*)\" under User Frame")]
        public void WhenISelectTheStudentUnderUserFrame(string userRole)
        {
            try
            {
                GenericHelper.SelectWindow("Manage Organization");
                _enrollmentPage.SelectUserToEnroll(userRole);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Thread.Sleep(3000);
                throw new Exception(e.ToString());
            }
        }

        //Purpose : to click enroll button
        [When(@"I click on the 'Enroll in Selected' button")]
        public void WhenIClickOnTheEnrollInSelectedButton()
        {
            try
            {
                _enrollmentPage.ClickEnrollButton();
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
