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
    /// This class is responsible to view and read
    /// mail message's send by the different user's.
    /// </summary>
    [Binding]
    public class ViewMailMessage : PegasusBaseTestFixture
    {
        /// <summary>
        /// Static instance of the logger.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(ViewMailMessage));

        /// <summary>
        /// Enter in mail box.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        [When(@"I enter in the ""(.*)"" mail inbox")]
        public void EnterInTheMailInbox(
            User.UserTypeEnum userTypeEnum)
        {
            //Click Message View All Link
            Logger.LogMethodEntry("ViewMailMessage", "EnterInTheMailInbox",
                base.isTakeScreenShotDuringEntryExit);
            //Click on Link To Get Inbox
            new HomePage().ClickMessagesViewAllLink(userTypeEnum);
            Logger.LogMethodExit("ViewMailMessage", "EnterInTheMailInbox",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the mail message in inbox.
        /// </summary>
        /// <param name="mailTypeEnum">This is mail type enum.</param>
        [Then(@"I should see the mail message sent by the ""(.*)""")]
        public void SeeTheMailMessageSentByTheUser(
            Mail.MailTypeEnum mailTypeEnum)
        {
            Logger.LogMethodEntry("ViewMailMessage", "SeeTheMailMessageSentByTheUser",
               base.isTakeScreenShotDuringEntryExit);
            //Get Mail Message Details From Memory
            Mail mailMessage = Mail.Get(mailTypeEnum);
            // Assert Mail Message Viewed Successfully
            Logger.LogAssertion("VerifyViewMailMessage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(mailMessage.Subject,
                    new MessageGridPage().GetMailMessageSubject()));
            Logger.LogMethodEntry("ViewMailMessage", "SeeTheMailMessageSentByTheUser",
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
