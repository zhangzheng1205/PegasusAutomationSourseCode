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
using Pegasus.Pages.UI_Pages.Integration.D2L.DirectIntegration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public class D2LDirect : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(D2LDirect));

        /// <summary>
        /// Login as D2L user to D2L portal
        /// </summary>
        /// <param name="userType">This is the user type enum.</param>
        [When(@"I login to D2L as ""(.*)""")]
        public void UserLoginToD2LPortal(User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("D2LDirect", "UserLoginToD2LPortal", base.IsTakeScreenShotDuringEntryExit);
            new D2LUserLogin().LoginToD2L(userType);
            logger.LogMethodExit("D2LDirect", "UserLoginToD2LPortal", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// D2L user enter into course
        /// </summary>
        /// <param name="courseType">This is the course type enum.</param>
        /// <param name="userType">This is the user type</param>
        [When(@"I enter into D2L direct course ""(.*)"" as ""(.*)""")]
        public void EnterIntoD2LDirectCourse(Course.CourseTypeEnum courseType, User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("D2LDirect", "EnterIntoD2LDirectCourse", base.IsTakeScreenShotDuringEntryExit);
            new D2LCourseActions().EnterIntoD2LCourse(courseType, userType);
            logger.LogMethodExit("D2LDirect", "EnterIntoD2LDirectCourse", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to tab in D2L portal page
        /// </summary>
        /// <param name="tabName">This is tab name.</param>
        [When(@"I navigate to D2L ""(.*)"" tab")]
        public void NavigateToTabInD2L(string tabName)
        {
            logger.LogMethodEntry("D2LDirect", "NavigateToTabInD2L", base.IsTakeScreenShotDuringEntryExit);
            new D2LCourseActions().ClickTabInD2L(tabName);
            logger.LogMethodExit("D2LDirect", "NavigateToTabInD2L", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click link in content page.
        /// </summary>
        /// <param name="linkName">This is the link name.</param>
        [When(@"I click on ""(.*)"" link in Content tab")]
        public void ClickOnLinkInContentTab(string linkName)
        {
            logger.LogMethodEntry("D2LDirect", "NavigateToTabInD2L", base.IsTakeScreenShotDuringEntryExit);
            new D2LCourseActions().ClicklinkInContentTab(linkName);
            logger.LogMethodExit("D2LDirect", "NavigateToTabInD2L", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on SSO link in pegasus SSO link
        /// </summary>
        /// <param name="linkName">This is the link name.</param>
        [When(@"I SSO to Pegasus by click on ""(.*)"" link")]
        public void SSOToPegasusByClickOnLink(string linkName)
        {
            logger.LogMethodEntry("D2LDirect", "SSOToPegasusByClickOnLink", base.IsTakeScreenShotDuringEntryExit);
            new D2LCourseActions().ClickSSOlinkInContentTab(linkName);
            logger.LogMethodExit("D2LDirect", "SSOToPegasusByClickOnLink", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the pegasus page display upon user cross over from D2L direct integration.
        /// </summary>
        /// <param name="pageName"></param>
        [Then(@"I should be on pegasus ""(.*)"" page as ""(.*)""")]
        public void ValidatePegasusGradebookPage(string pageName, User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("D2LDirect", "ValidatePegasusGradebookPage", base.IsTakeScreenShotDuringEntryExit);
            logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (true, new D2LCourseActions().GetGradeBookExistance(pageName, userType)));
            logger.LogMethodExit("D2LDirect", "ValidatePegasusGradebookPage", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}