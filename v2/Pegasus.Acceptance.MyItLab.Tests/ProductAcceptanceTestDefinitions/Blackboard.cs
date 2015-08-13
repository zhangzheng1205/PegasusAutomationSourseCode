using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.CommonPageObjects;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages.Integration.Blackboard;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public class Blackboard : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CourseContent));

        /// <summary>
        /// Enter into Blackboard course.
        /// </summary>
        /// <param name="courseType">This is the course type enum.</param>
        [When(@"I enter into blackboard course ""(.*)""")]
        public void BBInstructorEnterIntoCourse(Course.CourseTypeEnum courseType)
        {
            // Enter into blackboard course
            Logger.LogMethodEntry("Blackboard", "BBInstructorEnterIntoCourse",
                base.IsTakeScreenShotDuringEntryExit);
            new BlackboardCourseAction().EnterIntoBBCourse(courseType);
            Logger.LogMethodExit("Blackboard", "BBInstructorEnterIntoCourse",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of home page in Blackboard portal
        /// </summary>
        /// <param name="pageTitle">This is the page title.</param>
        [Then(@"I should be displayed with ""(.*)""")]
        public void ValidateTheDisplayOfHomePage(string pageTitle)
        {
            Logger.LogMethodEntry("Blackboard", "BBInstructorEnterIntoCourse",
                 base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyCoursePresent", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(pageTitle, new BlackboardCourseAction().GetBBPageTitle()));
            Logger.LogMethodExit("Blackboard", "BBInstructorEnterIntoCourse",
                 base.IsTakeScreenShotDuringEntryExit);
        }


        [When(@"I click on the ""(.*)"" link")]
        public void WhenIClickOnTheLink(string linkName)
        {
            Logger.LogMethodEntry("Blackboard", "BBInstructorEnterIntoCourse",
                 base.IsTakeScreenShotDuringEntryExit);
            new BlackboardCourseAction().BBInstructorSSOToPegasus(linkName);
            Logger.LogMethodExit("Blackboard", "BBInstructorEnterIntoCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of full 'Grade Center : Full Grade Center' page.
        /// </summary>
        /// <param name="p0">This is the page name</param>
        [Then(@"I should be on the page ""(.*)""")]
        public void ValidatePageTitle(String expectedPageTitle)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("Blackboard", "ValidatePageTitle",
                IsTakeScreenShotDuringEntryExit);
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedPageTitle, new BlackboardCourseAction().getGradebookWindowTitle()));
            Logger.LogMethodExit("CommonSteps", "ShowThePageInPegass",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Instructor select 'pearosn course tool' from 'manage' dropdown
        /// </summary>
        /// <param name="optionName">This is the name of the option in the dropdown.</param>
        /// <param name="dropdownName">This is the dropdown name.</param>
        [When(@"I select option ""(.*)"" form ""(.*)"" dropdown")]
        public void BBInstructorSelectPearsonCourseTool(string optionName, string dropdownName)
        {
            // Select the option in the Manege dropdown
            Logger.LogMethodEntry("Blackboard", "BBInstructorSelectPearsonCourseTool", base.IsTakeScreenShotDuringEntryExit);
            new BlackboardCourseAction().bbInstructorSelectPearsonCourseTool(optionName, dropdownName);
            Logger.LogMethodExit("Blackboard", "BBInstructorSelectPearsonCourseTool", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// BB Instructor click onn submit button 'Refresh Pearson Grades for All Available Pearson Assignments'
        /// </summary>
        [When(@"I click on submit button")]
        public void ClickSubmitButton()
        {
            Logger.LogMethodEntry("Blackboard", "ClickSubmitButton", base.IsTakeScreenShotDuringEntryExit);
            new BlackboardCourseAction().clickSubmitButtonInBB();
            Logger.LogMethodExit("Blackboard", "ClickSubmitButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the Grades in 'Grade Center : Full Grade Center'
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        [Then(@"I should see the score ""(.*)"" for ""(.*)"" activity for ""(.*)"" in BlackBoard")]
        public void VerifyTheScoreOfActivityBB(
                    Grade.GradeTypeEnum score, string activityName, User.UserTypeEnum userTypeEnum)
        {
            //Verify The Score Of Activity
            Logger.LogMethodEntry("Blackboard",
                "VerifyTheScoreOfActivityBB",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            Grade grade = Grade.Get(score);
            string activityScore = grade.Score.ToString();
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (activityScore, new BlackboardCourseAction().GetActivityStatusBB(
                    activityName, user.LastName, user.FirstName, user.Name)));
            Logger.LogMethodExit("Blackboard",
                "VerifyTheScoreOfActivityBB",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the student grade in student gradebook
        /// </summary>
        /// <param name="activityScore"></param>
        /// <param name="activityName"></param>
        [Then(@"I should see ""(.*)"" score ""(.*)"" for the activity ""(.*)"" in course material page in Pegasus")]
        public void ValidateTheActivityScoreForTheActivityInCourseMaterialPage(string activityScore, Grade.GradeTypeEnum gradeType, string activityName)
        {
            //Validate the submitted activity score
            Logger.LogMethodEntry("CommonSteps",
                "ValidateActivityStatus",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateActivityStatus", ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.AreEqual(activityScore, new StudentPresentationPage().
                    GetActivityScoreFromCourseMaterialsPageBB(gradeType, activityName)));
            Logger.LogMethodExit("CommonSteps",
                "ValidateActivityStatus",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}