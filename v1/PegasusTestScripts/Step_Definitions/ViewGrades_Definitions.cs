using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.MyPegasus;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class ViewGradesDefinitions : BaseTestScript
    {
        //Purpose: Calling Page Class Method
        readonly GBInstructorUXPage _gbInstructorUxPage  = new GBInstructorUXPage();
        readonly MyPegasusPage _myPegasusPage= new MyPegasusPage();

        //Purpose: Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        //Purpose: To select the course on cs student login
        [When("I select the course with prefix \"(.*)\" as CSteacher")]
        public void WhenISelectTheCourseWithPrefixBddmlasCSstudent(string course)
        {
            try
            {
                _myPegasusPage.ClickOnCourseAsTeacher();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Thread.Sleep(3000);
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To open Benchmark Tests Folder in GradeBook Tab and Verify the grades displayed
        [Then(@"It should display the grade under activity column of the submitted activity")]
        public void ThenItShouldDisplayTheGradeUnderActivityColumnOfTheSubmittedActivity()
        {
            try
            {
                _gbInstructorUxPage.NavigateToBenchmarkTestsFolderUnderGradeBookTab();
                _gbInstructorUxPage.VerifyTheGradeDisplayed();
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

