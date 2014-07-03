using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Integration.eCollege;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MLP.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles authoring of eCollege course.
    /// </summary>
    [Binding]
    public class AuthoreECollegeCourse : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(AuthoreECollegeCourse));

        /// <summary>
        /// Enter inside the course.
        /// </summary>
        /// <param name="courseTypeEnum">This is course name enum.</param>
        [When(@"I enter inside ""(.*)"" course")]
        public void EnterInsideECollegeCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Enter inside the course
            logger.LogMethodEntry("AuthoreECollegeCourse", "EnterInsideECollegeCourse",
                base.isTakeScreenShotDuringEntryExit);
            new ECPWireframePage().SelectECollegeCourse(courseTypeEnum);
            logger.LogMethodExit("AuthoreECollegeCourse", "EnterInsideECollegeCourse",
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click on left frame option.
        /// </summary>
        /// <param name="optionName">This is left frame option name.</param>
        [When(@"I select ""(.*)"" Option in left frame")]
        public void SelectLeftFrameOption(String optionName)
        {
            //Click on left frame option 
            logger.LogMethodEntry("AuthoreECollegeCourse", "SelectLeftFrameOption",
                 base.isTakeScreenShotDuringEntryExit);
            //Click on Author link 
            new DotNextLaunchPage().ClickOnLeftFrameOption(optionName);
            logger.LogMethodExit("AuthoreECollegeCourse", "SelectLeftFrameOption",
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Authoring of course.
        /// </summary>
        [When(@"I author the ECollege Course")]
        public void AuthoringTheECollegeCourse()
        {
            //Authoring the course
            logger.LogMethodEntry("AuthoreECollegeCourse", "AuthoringTheECollegeCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Click on HTMl link and Save Changes
            DotNextLaunchPage dotNextLaunchPage = new DotNextLaunchPage();
            dotNextLaunchPage.ClickOnHtmlLinkInCourseIntroduction();
            dotNextLaunchPage.ClickOnSaveChangeButton();
            logger.LogMethodExit("AuthoreECollegeCourse", "AuthoringTheECollegeCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verification of Enter Course Link. 
        /// </summary>
        /// <param name="enterCourseLink">This is Enter Course Link text.</param>
        [Then(@"I should see the ""(.*)"" on course home page")]
        public void VerificationOfEnterCourseLink(
            String enterCourseLink)
        {
            //Verification on Enter Course Link
            logger.LogMethodEntry("AuthoreECollegeCourse", "VerificationOfEnterCourseLink",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Course Link
            logger.LogAssertion("VerifyEnterCourseLink", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                    (enterCourseLink, new DotNextLaunchPage().
                    VerficationOfCourseLink()));
            logger.LogMethodExit("AuthoreECollegeCourse", "VerificationOfEnterCourseLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on left side button.
        /// </summary>
        /// <param name="buttonBottomFrame">This is name of button.</param>
        [When(@"I click on ""(.*)"" button from bottom left frame")]
        public void ClickOnButtonFromBottomLeftFrame(
            String buttonBottomFrame)
        {
            //Click on left side button
            logger.LogMethodEntry("AuthoreECollegeCourse", "ClickOnButtonFromBottomLeftFrame",
                 base.isTakeScreenShotDuringEntryExit);
            //Click on left side button
            new DotNextLaunchPage().ClickOnLeftBottomButton(buttonBottomFrame);
            logger.LogMethodExit("AuthoreECollegeCourse", "ClickOnButtonFromBottomLeftFrame",
                 base.isTakeScreenShotDuringEntryExit);
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
