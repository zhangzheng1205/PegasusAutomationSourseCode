#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains details of Welcome Message.
    /// </summary>
    [Binding]
    public class WelcomeMessage : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(WelcomeMessage));

        /// <summary>
        /// See The Welcome Message.
        /// </summary>
        [Then(@"I should see the welcome message")]
        public void SeeTheWelcomeMessage()
        {
            // See The Welcome Message
            Logger.LogMethodEntry("WelcomeMessage", "SeeTheWelcomeMessage",
                base.IsTakeScreenShotDuringEntryExit);
            // Welcome Message Should Be Displayed
            Logger.LogAssertion("VerifyTheWelcomeMessage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true,
                new WelcomeMessagesPage().IsWelcomeMessageDisplayed()));
            Logger.LogMethodExit("WelcomeMessage", "SeeTheWelcomeMessage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close The Welcome Message Popup.
        /// </summary>
        [When(@"I close the welcome message")]
        public void CloseTheWelcomeMessagePopup()
        {
            // Close The Welcome Message Popup
            Logger.LogMethodEntry("WelcomeMessage", "CloseTheWelcomeMessagePopup",
                base.IsTakeScreenShotDuringEntryExit);
            //Close The Welcome Message LightBox
            new WelcomeMessagesPage().CloseWelcomeMessageLightBox();
            Logger.LogMethodExit("WelcomeMessage", "CloseTheWelcomeMessagePopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Aide Close The Welcome Message Popup.
        /// </summary>
        [When(@"I close the welcome message lightbox")]
        public void AideCloseTheWelcomeMessagePopup()
        {
            // Close The Welcome Message Popup
            Logger.LogMethodEntry("WelcomeMessage", "AideCloseTheWelcomeMessagePopup",
                base.IsTakeScreenShotDuringEntryExit);
            //Close The Welcome Message LightBox
            new WelcomeMessagesPage().AideCloseWelcomeMessageLightBox();
            Logger.LogMethodExit("WelcomeMessage", "AideCloseTheWelcomeMessagePopup",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// The Welcome Message Popup Should Be Closed.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        [Then(@"I should see the welcome message popup closed successfully for ""(.*)""")]
        public void WelcomeMessagePopupWindow(
            User.UserTypeEnum userTypeEnum)
        {
            //The Welcome Message Popup Should Be Closed
            Logger.LogMethodEntry("WelcomeMessage", "WelcomeMessagePopupWindow",
               base.IsTakeScreenShotDuringEntryExit);
            //Check If The Poup Is Present
            Logger.LogAssertion("VerifyIfTheWelcomeMessagePopupIsClosed",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(false, new WelcomeMessagesPage().
                    IsWelcomeMessageLightBoxPresent()));
            //Closing the Announcement(s)
            new AnnouncementPopUpLightBoxUXPage().CloseAnnouncementPopUpInDigitalPath(userTypeEnum);
            Logger.LogMethodExit("WelcomeMessage", "WelcomeMessagePopupWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }

        /// <summary>
        /// Start New WebDriver Instance Before Scenario.
        /// </summary>
        [BeforeScenario]
        public static void StartIeWebDriver()
        {

        }

    }
}
