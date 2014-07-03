using System;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.ProgramAdmin.CourseTemplates;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool.ViewSubmission;
namespace Pegasus.ProductionDefect.TestScripts.ProductionDefect_StepDefinitions
{
    [Binding]
    public class US66320StepDefinitonDefect : BaseTestScript
    {
        //Purpose: Calling Methods from Page Class
        private readonly GBInstructorUXPage _gbInstructorUXPage = new GBInstructorUXPage();
        private readonly ViewSubmissionPage _viewSubmissionPage = new ViewSubmissionPage();
        private readonly GBDefaultUXPage _gbDefaultUxPage = new GBDefaultUXPage();
        private readonly GBRoasterGridUXPage _rosterPage = new GBRoasterGridUXPage();
        private readonly ManageTemplatePage _SectionSearch = new ManageTemplatePage();

        //Purpose: Get the Data from DB
        readonly string _courseName = DatabaseTools.GetCourse(Enumerations.CourseType.InstructorCourse).Trim();
        private readonly string _activityName = DatabaseTools.GetActivityName(Enumerations.ActivityType.Essay);


        //Purpose:  Step Definition To Submit Activity by the Student
        [Given(@"Activity is already submitted by the student if not then submit the activity by the student")]
        public void GivenActivityIsAlreadySubmittedByTheStudentIfNotThenSubmitTheActivityByTheStudent()
        {
            try
            {

                string isActivityAlreadySubmitted = DatabaseTools.GetSubmissionStatusOfActivity(Enumerations.ActivityType.Essay);
                if (isActivityAlreadySubmitted == null || isActivityAlreadySubmitted.Equals("False") || isActivityAlreadySubmitted.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsStudent");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSStudent();
                    GenericTestStep.StepToCloseStudentHelpTextWindow();
                    GenericTestStep.StepToItShouldBeOnPage("Global Home");
                    GenericTestStep.StepToSelectTheCreatedCourse(_courseName);
                    GenericTestStep.StepToItShouldBeOnPage("Today's View");
                    GenericTestStep.StepToNavigateToTheTab("Course Materials");
                    GenericTestStep.StepToNavigateInTheEssayTypeActivityFolder();
                    if (_activityName != null) GenericTestStep.StepToClickOnTheLink(_activityName);
                    GenericTestStep.StepToSubmitEssayTypeActivitybyStudent(_activityName);
                    GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        //Purpose:  Step Definition To Submit Activity by the Student
        [Given(@"Manual Graded question is already submitted by the student if not then submit the manual graded question by the student")]
        public void GivenManualGradedQuestionIsAlreadySubmittedIfNotThenSubmitTheManualGraded()
        {
            try
            {

                string isActivityAlreadySubmitted = DatabaseTools.GetSubmissionStatusOfActivity(Enumerations.ActivityType.Essay);
                if (isActivityAlreadySubmitted == null || isActivityAlreadySubmitted.Equals("False") || isActivityAlreadySubmitted.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsStudent");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSStudent();
                    GenericTestStep.StepToCloseStudentHelpTextWindow();
                    GenericTestStep.StepToItShouldBeOnPage("Global Home");
                    GenericTestStep.StepToSelectTheSectionName();
                    GenericTestStep.StepToItShouldBeOnPage("Today's View");
                    GenericTestStep.StepToNavigateToTheTab("Course Materials");
                    GenericTestStep.StepToNavigateInTheEssayTypeActivityFolder();
                    if (_activityName != null) GenericTestStep.StepToClickOnTheLink(_activityName);
                    GenericTestStep.StepToSubmitEssayTypeActivitybyStudent(_activityName);
                    GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                    // To submit grades by teacher
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
                    GenericHelper.SelectWindow("Program Administration");
                    string sectionName = DatabaseTools.GetSectionName(Enumerations.CourseType.ProgramCourse).Trim();
                    _SectionSearch.ToSearchSection(sectionName);
                    _SectionSearch.SelectSectionAfterSearch();
                    GenericTestStep.StepToIAmOnThePage("Calendar");
                    GenericHelper.SelectWindow("Calendar");
                    GenericTestStep.StepToNavigateToTheTab("Gradebook");
                    GenericHelper.SelectWindow("Gradebook");
                    _gbDefaultUxPage.SearchActivityByTitle("SAM 0A-33 El mundo hispano.");
                    _gbInstructorUXPage.ClickActivityCmenu("SAM 0A-33 El mundo hispano.");
                    _gbInstructorUXPage.ClickViewAllSubmissionsLink();
                    _viewSubmissionPage.OpenActivityViewSubmissionPage();
                    _viewSubmissionPage.GiveSubmissionByTeacher("Teacher");
                    GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

       

        //Purpose: Step Definition To Select View All Submission of the Essay Type Activity
        [When(@"I  click on the c-menu icon of activity column which has essay submitted and select view all submission")]
        public void WhenIClickOnTheCMenuIconOfActivityColumnWhichHasEssaySubmittedAndSelectViewAllSubmission()
        {
            try
            {
                _gbDefaultUxPage.SearchActivityByTitle("SAM 0A-33 El mundo hispano.");
              //  _gbInstructorUXPage.ClickActivityCmenu("SAM 0A-33 El mundo hispano.");
                _gbInstructorUXPage.ClickViewAllSubmissionsLink();
                _viewSubmissionPage.OpenActivityViewSubmissionPage();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        [When(@"I entered the text in HTML editor where student submitted answers displays of (.*) essay question")]
        public void WhenIEnteredTheTextInHTMLEditorWhereStudentSubmittedAnswersDisplaysOfFirstEssayQuestion(string questionOrder)
        {
            try
            {

                switch (questionOrder)
                {
                    case "first":
                        _viewSubmissionPage.EnterCommentsAndPlaceCursorInFirstEditor();
                        break;
                    case "second":
                        _viewSubmissionPage.EnterCommentsAndPlaceCursorInSecondEditor();

                        break;
                }
                //    
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition To Verify Blue Colour Instructor Comments
        [Then(@"It should display blue colour Instructor comments and upon placing cursor the colour of student answer should not change for (.*) essay question")]
        public void ThenItShouldDisplayBlueColourInstructorCommentsForFirstEssayQuestion(string questionOrder)
        {
            try
            {
                switch (questionOrder)
                {
                    case "first":
                        _viewSubmissionPage.VerifyStudentAndInstructorCommentTextColorInFirstEditor();
                        break;
                    case "second":
                        _viewSubmissionPage.VerifyStudentAndInstructorCommentTextColorInSecondEditor();
                        WebDriver.Close();
                        break;
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        [Then(@"Upon placing cursor the colour of student answer should not change")]
        public void ThenUponPlacingCursorTheColourOfStudentAnswerShouldNotChange()
        {
            try
            {

                _viewSubmissionPage.VerifyStudentAndInstructorCommentTextColorInSecondEditor();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        [Then(@"I close the viewsubmission window")]
        public void ThenICloseTheViewsubmissionWindow()
        {
            try
            {
                GenericHelper.SelectWindow("View Submission");
                WebDriver.Close();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

    }
}
