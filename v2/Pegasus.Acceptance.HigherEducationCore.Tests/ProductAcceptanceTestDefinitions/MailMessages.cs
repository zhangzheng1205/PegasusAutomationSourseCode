using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducation.WL.Tests.
    ProductAcceptanceTestDefinitions
{
    [Binding]
    public class MailMessages : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(MailMessages));

        /// <summary>
        /// Select Mail Option
        /// </summary>
        [When(@"I select 'Mail' option")]
        public void SelectMailOption()
        {
            //Select Mail Option
            Logger.LogMethodEntry("MailMessages",
                "SelectMailOption",
               base.IsTakeScreenShotDuringEntryExit);
            //Click On Mail Option
            new ProntoChatPage().ClickOnMailOption();
            Logger.LogMethodExit("MailMessages",
                "SelectMailOption",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Mail Course Space Instructor
        /// </summary>
        /// <param name="mailTypeEnum">This is Mail Type Enum</param>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I create a mail by ""(.*)"" for ""(.*)""")]
        public void CreateMailByInCourseSpaceInstructor(
            Mail.MailTypeEnum mailTypeEnum,Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Mail By Course Space Instructor
            Logger.LogMethodEntry("MailMessages",
                "CreateMailByInCourseSpaceInstructor",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Compose New Option
            new MessageGridPage().SelectComposeNewOption();
            //Click On 'TO' Button
            new ComposeNewMailUXPage().ClickOnToButton();
            //Get Course Details From Memory
            Course course = Course.Get(courseTypeEnum);
            //Select Instructor Course Recipients
            new GlobalRecipientListUXPage().SelectInstructorCourseRecipients(course.Name);
            //Enter Subject Title and HTML Text
            new ComposeNewMailUXPage().EnterSubjectTitleAndHtmlText(mailTypeEnum);
            Logger.LogMethodExit("MailMessages",
                "CreateMailByInCourseSpaceInstructor",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Send Mail To CourseSpace Users
        /// </summary>
        [When(@"I send the created mail to CourseSpace users")]
        public void SendMailToCourseSpaceUsers()
        {
            //Send Mail to CourseSpace Users
            Logger.LogMethodEntry("MailMessages",
                "SendMailToCourseSpaceUsers",
               base.IsTakeScreenShotDuringEntryExit);
            //Click On Send Button
            new ComposeNewMailUXPage().ClickOnSendButton();
            Logger.LogMethodExit("MailMessages",
                "SendMailToCourseSpaceUsers",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Mail Sent By Instructor
        /// </summary>
        /// <param name="mailTypeEnum">This is MailTypeEnum</param>
        [Then(@"I should see the mail message sent by ""(.*)""")]
        public void VerifyMailSentByInstructor(Mail.MailTypeEnum mailTypeEnum)
        {
            //Verify Mail Sent By Instructor
            Logger.LogMethodEntry("MailMessages",
                "VerifyMailSentByInstructor",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Mail Message Details From Memory
            Mail mailMessage = Mail.Get(mailTypeEnum);
            // Assert Course Search
            Logger.LogAssertion("VerifyMail", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.AreEqual(mailMessage.Subject,
                  new MessageGridPage().GetMailSubjectFromInstructor(mailMessage.Subject)));
            Logger.LogMethodExit("MailMessages",
               "VerifyMailSentByInstructor",
                base.IsTakeScreenShotDuringEntryExit);
        }


    }
}
