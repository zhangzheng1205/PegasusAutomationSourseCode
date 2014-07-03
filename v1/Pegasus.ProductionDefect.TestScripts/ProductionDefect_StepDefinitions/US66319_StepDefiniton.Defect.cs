using System;
using System.Configuration;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
namespace Pegasus.ProductionDefect.TestScripts.ProductionDefect_StepDefinitions
{
    [Binding]
    public class US66319StepDefinitonDefect : BaseTestScript
    {
        //Purpose: Constant Declaration
        static readonly string Browser = ConfigurationSettings.AppSettings["browser"];

        //Purpose: Step Defenition for enrolling user to the master course
        [Given(@"User already created in the workspace if not then create the user in workspace")]
        public void GivenUserAlreadyCreatedInTheWorkspaceIfNotThenCreateTheUserInWrokspace()
        {
            try
            {
                string isUserAlreadyCreated = DatabaseTools.GetUsername(Enumerations.UserType.HedWsInstructor);
                if (isUserAlreadyCreated == null || isUserAlreadyCreated.Equals("False") || isUserAlreadyCreated.Equals(""))
                {
                    //Purpose: Steps To Create Test Data
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("HED WS Admin");
                    GenericTestStep.StepToLoggedIntoTheWorkspaceAsHedWsAdmin();
                    GenericTestStep.StepToItShouldBeOnPage("Course Enrollment");
                    GenericTestStep.StepToIAmOnTheUserCreationPage();
                    GenericTestStep.StepTocreatetheUser();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Defenition to create copy as Testing course
        [Given(@"Given Testing course copy already created if not then create the Testing course copy")]
        public void GivenGivenTestingCourseCopyAlreadyCreatedIfNotThenCreateTheTestingCourseCopy()
        {
            string isTestingCourseCopyAlreadyCreated = DatabaseTools.GetCourse(Enumerations.CourseType.TestingCourse);
            if (isTestingCourseCopyAlreadyCreated == null || isTestingCourseCopyAlreadyCreated.Equals("False") ||
                isTestingCourseCopyAlreadyCreated.Equals(""))
            {
                GenericTestStep.StepToBrowsedUrlForPegasusUser("HED WS Admin");
                GenericTestStep.StepToLoggedIntoTheWorkspaceAsHedWsAdmin();
                GenericTestStep.StepToIAmOnTheUserCreationPage();
                GenericTestStep.StepToSelectTheCourse("MySpanishLab AuthoredCourse");
                GenericTestStep.StepToClickOnTheCmenuOfCourse();
                GenericTestStep.StepToClickOnTheCourseCMenuOptionLink("Copy as Testing Course");
                GenericTestStep.StepToIShouldSeeTheNewPopup("Copy as Testing Course");
                GenericTestStep.StepToCopyTheCourseInSameWorkspace("Testing");
                GenericTestStep.StepToItShouldDisplaySuccessfulMessage("Copied as test course.");
                GenericTestStep.StepToWaitForTheTestingCourseOutFromAssignToCopyState();
            }
        }

        //Purpose: Step Defenition to enroll user in copy as Testing course
        [Given(@"Ws user is already enrolled in the Testing Course Copy if not then enroll the user in Testing Course Copy")]
        public void GivenWsUserIsAlreadyEnrolledInTheTestingCourseCopyIfNotThenEnrollTheUserInTestingCourseCopy()
        {
            string isWsUserAlreadyEnrolled = DatabaseTools.GetEnrolledUser(Enumerations.UserType.HedWsInstructor);
            if (isWsUserAlreadyEnrolled == null || isWsUserAlreadyEnrolled.Equals("False") || isWsUserAlreadyEnrolled.Equals(""))
            {
                GenericTestStep.StepToEnrolUserInTestingCopyCourse();
                GenericTestStep.StepToItShouldDisplaySuccessfulMessage("Instructors enrolled successfully.");
            }
        }

        //Purpose: Step Defenition to click on the edit preference link
        [When(@"I click  on edit link against any of the activity under preferences column")]
        public void WhenIClickOnEditLinkAgainstAnyOfTheActivityUnderPreferencesColumn()
        {
            try
            {
                GenericTestStep.SteptoSelectTheCourseNameWithPrefix("Testing");
                GenericTestStep.StepToItShouldBeOnPage("Calendar");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString()); throw;
            }
        }

        //Purpose: Step Defenition to click on the feedback sub-tab
        [When(@"I click on the feedback sub-tab")]
        public void WhenIClickOnTheFeedbackSubTab()
        {
            try
            {
                GenericTestStep.StepToNavigateToTheTab("Preferences");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString()); throw;
            }
        }

        //Purpose: Step Defenition to verify the status of the prefeence
        [Then(@"The 'Show Correct Answer' radio button selections should be retain")]
        public void ThenTheShowCorrectAnswerRadioButtonSelectionsShouldBeRetain()
        {
            try
            {
                GenericTestStep.StepToverifyFeedbackPrefernce();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString()); throw;
            }
        }
    }
}
