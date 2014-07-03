using System;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Activity;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.ProgramAdmin.CourseTemplates;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool.ViewSubmission;
namespace Pegasus.ProductionDefect.TestScripts.ProductionDefect_StepDefinitions
{
    [Binding]
    public class US66348_StepDefinition : BaseTestScript
    {
        //Purpose: Calling Methods from Page Class
        private readonly ViewSubmissionPage _viewSubmissionPage = new ViewSubmissionPage();
        private readonly GBRoasterGridUXPage _rosterPage = new GBRoasterGridUXPage();
        private readonly ManageTemplatePage _sectionSearch = new ManageTemplatePage();
        private readonly CourseContentUXPage _openViewSubmission = new CourseContentUXPage();

        //Purpose: Get the Data from DB

        /// <summary>
        /// This step definition would select the view submission of the submitted activity
        /// </summary>
        [When(@"I open the view submission of the submitted activity")]
        public void WhenIOpenTheViewSubmissionOfTheSubmittedActivity()
        {
            try
            {
                _openViewSubmission.ToSelectSubmittedActivityFromTa();
                _viewSubmissionPage.OpenActivityViewSubmissionPage();
                _viewSubmissionPage.GiveSubmissionByTeacher("TeachingAssistant");

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        /// <summary>
        /// TO Verify Grades by TA
        /// </summary>
          [When(@"I verify the grades by TA")]
        public void ToVerifyGradesByTa()
          {
              try
              {
                  _viewSubmissionPage.OpenActivityViewSubmissionPage();
                  _viewSubmissionPage.VerifyGradesGivenByTa();

              }
              catch (Exception e)
              {
                  GenericHelper.Logs(e.ToString(), "FAILED");
                  Assert.Fail(e.ToString());
              } 
          }


        //Purpose: Step Definition for Creation of SMS User(s)
        [When(@"I Create a new SMS Student")]
        public void WhenICreateAnewSmsStudent()
        {
            try
            {
                GenericTestStep.StepToClickedTheIAcceptButton();
                GenericTestStep.StepToCreateNewSmsUser("CsSmsStudent");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        //Purpose:  Step Definition To promote the student as TA
        [When("I promote the student user as TA in Section")]
        [Given("Student is already promoted to TA if not then promote the student as TA")]
        public void GivenStudentisalreadypromotedtoTAifnotthenpromotethestudentasTa()
        {
            try
            {

                GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsInstructor");
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSInstructor();
                GenericTestStep.StepToIAmOnThePage("Global Home");
                GenericHelper.SelectWindow("Global Home");
                string courseName = DatabaseTools.GetCourse(Enumerations.CourseType.ProgramCourse).Trim();
                GenericHelper.WaitUntilElement(By.PartialLinkText(courseName));
                WebDriver.FindElement(By.PartialLinkText(courseName)).SendKeys("");
                WebDriver.FindElement(By.PartialLinkText(courseName)).Click();
                GenericTestStep.StepToIAmOnThePage("Program Administration");
                GenericHelper.SelectWindow("Program Administration");
                GenericTestStep.StepToNavigateToTheTab("Sections");
                // Will need to change this line as per the authored course
                GenericHelper.SelectWindow("Program Administration");
                string sectionName = DatabaseTools.GetSectionName(Enumerations.CourseType.ProgramCourse).Trim();
                _sectionSearch.ToSearchSection(sectionName);
                _sectionSearch.SelectSectionAfterSearch();
                GenericTestStep.StepToIAmOnThePage("Calendar");
                GenericHelper.SelectWindow("Calendar");
                GenericTestStep.StepToNavigateToTheTab("Enrollments");
                GenericTestStep.StepToIAmOnThePage("Roster");
                _rosterPage.ToGrantTAPrivilege();
                GenericTestStep.StepToIAmOnThePage("Roster");
                GenericTestStep.StepToIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        // purpose : Step definition to verify the enrollment of SMS student to the section
        [When(@"I enroll the student to the section")]
        public void WhenIEnrollTheStudentInToTheSection()
        {
            try
            {
                GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsStudent");
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSStudent();
                GenericTestStep.StepToCloseStudentHelpTextWindow();
                GenericHelper.SelectWindow("Global Home");
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.CloseAnnouncementPage();
                GenericTestStep.StepToEnrolStudentToCourse("ProductTypeProg");
                GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }       
    }
}
