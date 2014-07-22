#region

using System;
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
    /// This Class Handles Send Messages Actions.
    /// </summary>
    [Binding]
    public class SendingMessages : PegasusBaseTestFixture
    {
        /// <summary>
        /// Static instance of the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(SendingMessages));

        /// <summary>
        /// Create Mail in CourseSpace.
        /// </summary>
        [When(@"I create mail by ""(.*)"" in CourseSpace")]
        public void CreateMailInCourseSpace(
            User.UserTypeEnum userTypeEnum)
        {
            //Create Mail in CourseSpace
            Logger.LogMethodEntry("SendingMessages", "CreateMailInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            //Create Mail in CourseSpace
            new MessageGridPage().CreateMailMessage(userTypeEnum);
            Logger.LogMethodExit("SendingMessages", "CreateMailInCourseSpace", 
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Send Mail to CourseSpace Users.
        /// </summary>
        [When(@"I send created mail to CourseSpace users")]
        public void SendMailToCourseSpaceUsers()
        {
            //Send Mail to CourseSpace Users
            Logger.LogMethodEntry("SendingMessages", "SendMailToCourseSpaceUsers", 
                base.isTakeScreenShotDuringEntryExit);
            //Send Mail to CourseSpace Users
            new MessageGridPage().SendMailToCourseSpaceUsers();
            Logger.LogMethodExit("SendingMessages", "SendMailToCourseSpaceUsers", 
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Check Successful message in Send Mail Popup.
        /// </summary>
        /// <param name="successMessage">This is Successful Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in the send mail popup")]
        public void CheckSuccessfullMessageInSendMailPopup(
            String successMessage)
        {
            //To Check Successful message in Send Mail Popup
            Logger.LogMethodEntry("SendingMessages", "CheckSuccessfullMessageInSendMailPopup",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Display of Success Message
            Logger.LogAssertion("VerifySuccessMessageforMailSent",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(successMessage,new MessageGridPage().
                    GetSuccessMessage()));
            Logger.LogMethodExit("SendingMessages", "CheckSuccessfullMessageInSendMailPopup",
                base.isTakeScreenShotDuringEntryExit);           
        }

        /// <summary>
        /// Close the Mail Pop Up.
        /// </summary>
        [When(@"I close the mail popup")]
        public void CloseMailPopUp()
        {
            //Close Mail Pop Up
            Logger.LogMethodEntry("SendingMessages", "CloseMailPopUp",
                base.isTakeScreenShotDuringEntryExit);
            //Close mail Popup
            new MessageGridPage().CloseMailPopup();
            Logger.LogMethodExit("SendingMessages", "CloseMailPopUp",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Mail Popup is Closed or Not.
        /// </summary>
        [Then(@"I should see the mail popup closed successfully")]
        public void MailPopUpSuccessfullyClosed()
        {
            //Verify Mail Popup Closed or Not
            Logger.LogMethodEntry("SendingMessages", "MailPopUpSuccessfullyClosed",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Mail Popup present or Not
            Logger.LogAssertion("VerifyMailPopupPresent",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(false,new HomePage().IsMailPopupPresent()));
            Logger.LogMethodExit("SendingMessages", "MailPopUpSuccessfullyClosed",
                base.isTakeScreenShotDuringEntryExit);
            
        }

        /// <summary>
        /// Initialize Pegasus test before test execution start.
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
