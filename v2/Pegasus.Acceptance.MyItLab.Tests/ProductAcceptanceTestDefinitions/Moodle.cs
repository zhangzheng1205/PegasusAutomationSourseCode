using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using TechTalk.SpecFlow;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Integration.Moodle;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public class Moodle : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Moodle));

        /// <summary>
        /// Enter into Moodle kiosk course
        /// </summary>
        /// <param name="courseType">This is the course type enum.</param>
        [When(@"I enter into the moodle kiosk course ""(.*)""")]
        public void EnterIntoTheMoodleKioskCourse(Course.CourseTypeEnum courseType)
        {
            // Enter into course
            Logger.LogMethodEntry("Moodle", "EnterIntoTheMoodleKioskCourse", base.IsTakeScreenShotDuringEntryExit);
            new MoodleCourseActions().EnterIntoMoodleKioskCourse(courseType);
            Logger.LogMethodExit("Moodle", "EnterIntoTheMoodleKioskCourse", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on 'MyLab & Mastering Tools' link
        /// </summary>
        /// <param name="optionName">This is the option name.</param>
        [When(@"I click on ""(.*)""")]
        public void ClickMyLabMasteringTools(ToolLinks.LinkTypeEnum linkTypeEnum)
        {
            Logger.LogMethodEntry("Moodle", "ClickMyLabMasteringTools", base.IsTakeScreenShotDuringEntryExit);
            ToolLinks toolLinks = ToolLinks.Get(linkTypeEnum);
            string linkName = toolLinks.Name;
            new MoodleCourseActions().clickMyLabAndMasteringTools(linkName);
            Logger.LogMethodExit("Moodle", "ClickMyLabMasteringTools", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Pegasus SSO link in MMND page
        /// </summary>
        /// <param name="optionName">This is the option name.</param>
        /// <param name="userType">This is the user type enum.</param>
        [When(@"I click on MMND ""(.*)"" link as ""(.*)""")]
        public void ClickOnMMNDLink(string optionName, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("Moodle", "ClickOnMMNDLink", base.IsTakeScreenShotDuringEntryExit);
            new MoodleCourseActions().ssoToPegasusFromMMND(optionName, userType);
            Logger.LogMethodExit("Moodle", "ClickOnMMNDLink", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the page name display
        /// </summary>
        /// <param name="courseType">This is the course type enum.</param>
        [Then(@"I should be redirected to ""(.*)"" page")]
        public void VerifyMoodlePageName(Course.CourseTypeEnum courseType)
        {
            // Method To Verify the Success Message 
            Logger.LogMethodEntry("Moodle", "VerifyMoodlePageName",
                IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseType);
            string courseName = course.Name.ToString();
            Logger.LogAssertion("ToValidateTheMessageOnPopUp",
                            ScenarioContext.Current.ScenarioInfo.Title, ()
                           => Assert.AreEqual(courseName, new MoodleCourseActions().
                           GetCourseName()));
            Logger.LogMethodExit("Moodle", "VerifyMoodlePageName",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the moodle login page
        /// </summary>
        [Then(@"I should be on the moodle login page")]
        public void ValidateTheMoodleLoginPage()
        {
            // Method To Verify the moodle page existance
            Logger.LogMethodEntry("Moodle", "ValidateTheMoodleLoginPage",
                IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ToValidateThePageExistance",
                            ScenarioContext.Current.ScenarioInfo.Title, ()
                           => Assert.AreEqual(true, new MoodleCourseActions().
                           GetPageExistanceStatus()));
            Logger.LogMethodExit("Moodle", "ValidateTheMoodleLoginPage",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click link in the MMND portal page
        /// </summary>
        /// <param name="linkName">This is the link name.</param>
        /// <param name="pageName">This is the page name.</param>
        [When(@"I click ""(.*)"" link on ""(.*)"" page")]
        public void ClickLinkOnPage(string linkName, string pageName)
        {
            // Click link on the MMND page
            Logger.LogMethodEntry("Moodle", "ClickLinkOnPage", base.IsTakeScreenShotDuringEntryExit);
            new CourseHomePage().ClickLinkInMMNDPage(linkName, pageName);
            Logger.LogMethodExit("Moodle", "ClickLinkOnPage", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click link based on the option name
        /// </summary>
        /// <param name="linkName">This is the link name.</param>
        /// <param name="pageName">This is the page name.</param>
        [When(@"I click ""(.*)"" link in ""(.*)"" page")]
        public void ClickLinkInPearsonLinkPage(string linkName, string pageName)
        {
            Logger.LogMethodEntry("Moodle", "ClickLinkInPearsonLinkPage", base.IsTakeScreenShotDuringEntryExit);
            new CourseHomePage().ClickLinkInPearsonLinkPage(linkName, pageName);
            Logger.LogMethodExit("Moodle", "ClickLinkInPearsonLinkPage", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the page display
        /// </summary>
        /// <param name="pageName">This is the page name.</param>
        [Then(@"I should be ""(.*)"" page")]
        public void ValidatePageDisplay(string pageName)
        {
            // Validate the page display
            Logger.LogMethodEntry("Moodle", "ValidatePageDisplay", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ToValidateThePageExistance",
                ScenarioContext.Current.ScenarioInfo.Title, ()
               => Assert.AreEqual(pageName, new MoodleCourseActions().
               getGraderReportPage()));
            Logger.LogMethodEntry("Moodle", "ValidatePageDisplay", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click option from the Grade report dropdown
        /// </summary>
        /// <param name="optionName">This is the option name.</param>
        [When(@"I select option ""(.*)"" from Grader report dropdown")]
        public void SelectOptionFromGraderReportDropdown(string optionName)
        {
            Logger.LogMethodEntry("Moodle", "SelectOptionFromGraderReportDropdown", base.IsTakeScreenShotDuringEntryExit);
            new MoodleCourseActions().SelectOptionFromGraderReport(optionName);
            Logger.LogMethodExit("Moodle", "SelectOptionFromGraderReportDropdown", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click 'Sync MyLab & Mastering Grades' button
        /// </summary>
        [When(@"I click on 'Sync MyLab & Mastering Grades' button")]
        public void ClickSyncMyLabMasteringGradesButton()
        {
            Logger.LogMethodEntry("Moodle", "ClickSyncMyLabMasteringGradesButton", base.IsTakeScreenShotDuringEntryExit);
            new MoodleCourseActions().ClickSyncMyLabMasteringGradesButton();
            Logger.LogMethodExit("Moodle", "ClickSyncMyLabMasteringGradesButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Logout from moodle.
        /// </summary>
        /// <param name="linkName">This is logout link name.</param>
        [When(@"I ""(.*)"" of Moodle")]
        public void LogoutfromMoodle(string linkName)
        {
            Logger.LogMethodEntry("Moodle", "LogoutfromMoodle", base.IsTakeScreenShotDuringEntryExit);
            new MoodleCourseActions().clickMyLabAndMasteringTools(linkName);
            Logger.LogMethodExit("Moodle", "LogoutfromMoodle", base.IsTakeScreenShotDuringEntryExit);
        }


    }
}