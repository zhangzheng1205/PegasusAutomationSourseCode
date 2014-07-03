using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.MyPegasus;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.templatesclassmanagement.classes;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class CourseCreationbyCsTeacherDefinitions : BaseTestScript
    {
        //Purpose: Calling Page Class
        readonly MyClassdefaultPage _myClassdefaultPage = new MyClassdefaultPage();
        readonly CreateClassCoursePage _createClassCoursePage = new CreateClassCoursePage();
        //Purpose: Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        //Purpose: To click Create Course button in classes page
        [When(@"I select the 'Create Course' option in 'Classes' Page")]
        public void WhenISelectTheCreateCourseOptionInClassesPage()
        {
            try
            {
                _myClassdefaultPage.ClickCreateCourse();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Create Course using ML
        [When(@"I created the course using ML's")]
        [Then(@"I created the course using ML's")]
        public void ThenICreatedTheCourseUsingMLS()
        {
            try
            {
                bool isCreateCourseWindowOpened = GenericHelper.IsPopUpWindowPresent("Create Course");
                if (isCreateCourseWindowOpened)
                {
                    _createClassCoursePage.CreateCourseUsingML();
                }
                else
                {
                    GenericHelper.Logs("'Create Course' pop-up window not opened.", "FAILED");
                    throw new NoSuchWindowException("'Create Course' pop-up window not opened.");
                }
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
