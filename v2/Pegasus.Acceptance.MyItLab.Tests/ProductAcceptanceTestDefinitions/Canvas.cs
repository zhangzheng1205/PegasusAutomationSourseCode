using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using TechTalk.SpecFlow;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Integration.Canvas.DirectIntegration;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public class Canvas : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        protected static Logger logger = Logger.GetInstance(typeof(Canvas));

        /// <summary>
        /// Canvas user login to canvas portal
        /// </summary>
        /// <param name="userType">This is the user type enum.</param>
        [When(@"I login to Canvas as ""(.*)""")]
        public void CanvasUserLogin(User.UserTypeEnum userType)
        {
            // Canvas user login
            logger.LogMethodEntry("Canvas", "CanvasUserLogin", base.IsTakeScreenShotDuringEntryExit);
            new CanvasUserLogin().UserLoginToCanvas(userType);
            logger.LogMethodExit("Canvas", "CanvasUserLogin", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// User enter into Canvas direct course.
        /// </summary>
        /// <param name="courseName">This is the course name.</param>
        [When(@"I enter into Canvas direct course ""(.*)""")]
        public void EnterIntoCanvasDirectCourse(string courseName)
        {
            logger.LogMethodEntry("Canvas", "EnterIntoCanvasDirectCourse", base.IsTakeScreenShotDuringEntryExit);
            new CanvasUserLogin().CanvasUserEnterIntoCourse(courseName);
            logger.LogMethodExit("Canvas", "EnterIntoCanvasDirectCourse", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click link in moodle portal inside the course
        /// </summary>
        /// <param name="linkName">This is the link name.</param>
        /// <param name="courseName">This is the course name.</param>
        /// <param name="userType">This is the user type enum.</param>
        [When(@"I click ""(.*)"" link in ""(.*)"" page as ""(.*)""")]
        public void ClickLinkInCanvasCourseLandingPage(string linkName, string courseName, User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("Canvas", "ClickLinkInCanvasCourseLandingPage", base.IsTakeScreenShotDuringEntryExit);
            new CanvasCourseActions().SelectTabInCourseLandingPage(linkName, courseName, userType);
            logger.LogMethodExit("Canvas", "ClickLinkInCanvasCourseLandingPage", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Canvas user crossover to Pegasus
        /// </summary>
        /// <param name="linkName">This is the link name.</param>
        /// <param name="userType">This is the usertype enum.</param>
        [When(@"I sso to pegasus by click on ""(.*)"" as ""(.*)""")]
        public void CanvasUsersSSOToPegasus(string linkName, User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("Canvas", "CanvasUsersSSOToPegasus", base.IsTakeScreenShotDuringEntryExit);
            new CanvasCourseActions().CrossOverToPegasus(linkName, userType);
            logger.LogMethodExit("Canvas", "CanvasUsersSSOToPegasus", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click close link in pegasus.
        /// </summary>
        /// <param name="linkName">This is the link name.</param>
        [When(@"I click on ""(.*)"" link in pegasus")]
        public void ClickCloseLink(string linkName)
        {
            //Click close link
            logger.LogMethodEntry("Canvas", "ClickCloseLink", base.IsTakeScreenShotDuringEntryExit);
            new CanvasUserLogin().CanvasUserClickCloseLink(linkName);
            logger.LogMethodExit("Canvas", "ClickCloseLink", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Canvas user logout from canvas portal
        /// </summary>
        /// <param name="p0"></param>
        [When(@"I logout of Canvas")]
        public void LogoutOfCanvas()
        {
            logger.LogMethodEntry("Canvas", "LogoutOfCanvas", base.IsTakeScreenShotDuringEntryExit);
            new CanvasUserLogin().CanvasUserLogout();
            logger.LogMethodExit("Canvas", "LogoutOfCanvas", base.IsTakeScreenShotDuringEntryExit);
        }

       /// <summary>
        /// Verify the expected Pegasus window on crossover.
       /// </summary>
       /// <param name="pageName">The expected Pegasus window</param>
       /// <param name="userType">This is User Type enum</param>

        [Then(@"I should see ""(.*)"" page of ""(.*)"" embedded at ""(.*)"" page" )]
        public void ValidateThePegasusPageDisplayForCanvasUser(string pageName, User.UserTypeEnum userType,string canvasPage)
        {
            logger.LogMethodEntry("CanvasCourseActions", "ValidateThePegasusPageDisplayForCanvasUser", base.IsTakeScreenShotDuringEntryExit);
              
            //Get current opened page title
            logger.LogAssertion("ValidateThePegasusPageDisplayForCanvasUser", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (true, new CanvasCourseActions().GetGradeBookExistance(pageName, userType,canvasPage)));

            logger.LogMethodExit("CanvasCourseActions", "ValidateThePegasusPageDisplayForCanvasUser", base.IsTakeScreenShotDuringEntryExit);
        }

    }
}