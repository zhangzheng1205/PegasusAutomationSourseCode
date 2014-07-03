using System;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.CatalogInstructor;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook;
using TechTalk.SpecFlow;
namespace Pegasus.ProductionDefect.TestScripts.ProductionDefect_StepDefinitions
{
    [Binding]
    public class US66333StepDefinitonDefect:BaseTestScript
    {
        // Purpose: Calling Methods From Page Class
        readonly HEDGlobalHomePage _toCreateinstructorCourse = new HEDGlobalHomePage();
        private readonly GBRoasterGridUXPage _rosterPage = new GBRoasterGridUXPage();

        //Purpose- Step Definition to CreateIC Course from the Catalog
        [When(@"I created Instructor course from the authored course")]
        public void CreateInstructorCourse()
        {
            try
            {
                _toCreateinstructorCourse.ToCreateCatalogCourse("MasterCourse");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" +"ght: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step Definition to Get the Course ID 
        [When(@"I get the course ID of instructor course")]
        public void WhenIgettheCourseIDofInstructorCourse()
        {
            try
            {
                GenericTestStep.StepToIAmOnThePage("Global Home");
                GenericTestStep.StepToEnrollStudentToInstructorCourse();
                GenericTestStep.StepToIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition enrolling SMS student to Course
        [When(@"I enroll the student to the course")]
        public void WhenIenrollthestudenttotheCourse()
        {
            try
            {
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSStudent();
                GenericTestStep.StepToIAmOnThePage("Global Home");
                GenericTestStep.StepToEnrollStudenttoCourseId();
                GenericTestStep.StepToIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition To Grant TA role to Student
        [When(@"I grant the student as TA")]
        public void WhenIGrantthestudentasTa()
        {
            try
            {
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSInstructor();
                GenericTestStep.StepToIAmOnThePage("Global Home");
                GenericHelper.SelectWindow("Global Home");
                string courseName = DatabaseTools.GetCourse(Enumerations.CourseType.InstructorCourse).Trim();
                GenericHelper.WaitUntilElement(By.PartialLinkText(courseName));
                WebDriver.FindElement(By.PartialLinkText(courseName)).SendKeys("");
                WebDriver.FindElement(By.PartialLinkText(courseName)).Click();
                GenericTestStep.StepToIAmOnThePage("Calendar");
                // Will need to change this line as per the authored course
                GenericHelper.SelectWindow("Calendar");
                GenericTestStep.StepToNavigateToTheTab("Enrollments");
                GenericTestStep.StepToIAmOnThePage("Roster");
                _rosterPage.ToGrantTAPrivilege();
                GenericTestStep.StepToIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }
    }
}
