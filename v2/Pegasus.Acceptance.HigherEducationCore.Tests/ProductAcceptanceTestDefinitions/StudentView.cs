using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Page handles the Student view details.
    /// </summary>
    [Binding]
    public class StudentView : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(StudentView));

        /// <summary>
        /// Select The Go to Student View Link In Global HomePage.
        /// </summary>
        /// <param name="goToStudentViewLink">Go to Student View Link.</param>
        [When(@"I select the ""(.*)"" link in Global Home page")]
        public void SelectTheGotoStudentViewLinkInGlobalHomePage(
            String goToStudentViewLink)
        {
            //Select The Go to Student View Link In Global HomePage
            Logger.LogMethodEntry("StudentView", 
                "SelectTheGotoStudentViewLinkInGlobalHomePage",
               base.IsTakeScreenShotDuringEntryExit);
            //Click The Go to Student View Link In Global HomePage
           new CalendarDefaultUXPage().
               ClickTheGotoStudentViewLinkInGlobalHomePage(goToStudentViewLink);
            Logger.LogMethodEntry("StudentView",
                "SelectTheGotoStudentViewLinkInGlobalHomePage",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Instructor Should Turned As Student.
        /// </summary>
        /// <param name="welcomeStudentText">This is welcome student text.</param>
        [Then(@"I should see the Instructor should turned as ""(.*)"" in student side")]
        public void VerifyTheInstructorShouldTurnedAsStudent(
            String welcomeStudentText)
        {
            //Verify The Instructor Should Turned As Student
            Logger.LogMethodEntry("StudentView", 
                "VerifyTheInstructorShouldTurnedAsStudent",
               base.IsTakeScreenShotDuringEntryExit);
            //Verify welcome Student text
            Logger.LogAssertion("VerifyWelcomeStudentText", 
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(welcomeStudentText,
                    new TodaysViewUxPage().
                    GetWelcomeStudentTextMessage(welcomeStudentText))); 
            Logger.LogMethodEntry("StudentView",
                "VerifyTheInstructorShouldTurnedAsStudent",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
