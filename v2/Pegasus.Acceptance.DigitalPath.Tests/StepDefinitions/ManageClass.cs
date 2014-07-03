#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.Definitions
{
    /// <summary>
    /// This Class Handles Manage Class Page actions.
    /// </summary>
    [Binding]
    public class ManageClass : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(ManageClass));

        /// <summary>
        /// Verify Enrolled Class In 'Overview' Tab.
        /// </summary>
        /// <param name="classTypeEnum">This is Class Type Enum.</param>
        [Then(@"I should see the Enrolled ""(.*)"" class displayed and accesible by student")]
        public void VerifyEnrolledClassInOverviewTab
            (Class.ClassTypeEnum classTypeEnum)
        {
            //Verify Enrolled Class In Overview Tab
            logger.LogMethodEntry("ManageClass", "VerifyEnrolledClassInOverviewTab",
                base.isTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class className = Class.Get(classTypeEnum);
            //Assert Class Name
            logger.LogAssertion("VerifyClassInOverviewTab", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(className.Name,
                    new TodaysViewUXPage().GetClassName()));
            logger.LogMethodExit("ManageClass", "VerifyEnrolledClassInOverviewTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Class
        /// </summary>
        /// <param name="classTypeEnum">This is class Type Enum</param>
        [Then(@"I should able to see the ""(.*)"" class")]
        public void VerifyTheClass(Class.ClassTypeEnum classTypeEnum)
        {
            //Verify The Class
            logger.LogMethodEntry("ManageClass", "VerifyTheClass",
               isTakeScreenShotDuringEntryExit);
            //Get class from memory
            Class className = Class.Get(classTypeEnum);
            // Assert for classname
            logger.LogAssertion("VerifyClassName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(className.Name,
                    new HomePage().GetDisplayClassName(className.Name)));
            logger.LogMethodExit("ManageClass", "VerifyTheClass",
              isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// See The Welcome Message
        /// </summary>
        [Then(@"I should see the welcome message")]
        public void SeeTheWelcomeMessage()
        {
            // See The Welcome Message
            logger.LogMethodEntry("ManageClass", "SeeTheWelcomeMessage",
                base.isTakeScreenShotDuringEntryExit);
            // Welcome Message Should Be Displayed
            logger.LogAssertion("VerifyTheWelcomeMessage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true,
                new WelcomeMessagesPage().IsWelcomeMessageDisplayed()));
            logger.LogMethodExit("ManageClass", "SeeTheWelcomeMessage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close The Welcome Message Popup
        /// </summary>
        [When(@"I close the welcome message")]
        public void CloseTheWelcomeMessagePopup()
        {
            // Close The Welcome Message Popup
            logger.LogMethodEntry("ManageClass", "CloseTheWelcomeMessagePopup",
                base.isTakeScreenShotDuringEntryExit);
            //Close The Welcome Message LightBox
            new WelcomeMessagesPage().CloseWelcomeMessageLightBox();
            logger.LogMethodExit("ManageClass", "CloseTheWelcomeMessagePopup",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// The Welcome Message Popup Should Be Closed
        /// </summary>
        [Then(@"I should see the welcome message popup closed successfully for ""(.*)""")]
        public void WelcomeMessagePopupWindow(User.UserTypeEnum userTypeEnum)
        {
            //The Welcome Message Popup Should Be Closed
            logger.LogMethodEntry("ManageClass", "WelcomeMessagePopupWindow",
               base.isTakeScreenShotDuringEntryExit);
            //Check If The Poup Is Present
            logger.LogAssertion("VerifyIfTheWelcomeMessagePopupIsClosed",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(false, new WelcomeMessagesPage().
                    IsWelcomeMessageLightBoxPresent()));
            //Closing the Announcement(s)
            new AnnouncementPopUpLightBoxUXPage().CloseAnnouncementPopUpInDigitalPath(userTypeEnum);
            logger.LogMethodExit("ManageClass", "WelcomeMessagePopupWindow",
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
