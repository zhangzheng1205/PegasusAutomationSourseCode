using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Integration.Hed.ETextS11.Tests.IntegrationAcceptanceTestDefinitions;

namespace Pegasus.Integration.ETextS11.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles SMS Registration Page Actions
    /// also responsible to create SMS user registeration.
    /// </summary>
    [Binding]
    public class SMSRegistration : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(SMSRegistration));        

        /// <summary>
        /// Accept The License Agreement And Privacy Policy Button Clicked by SMS Admin.
        /// </summary>
        [When(@"I accept the License Agreement and Privacy Policy of SMS")]
        public void AcceptTheLicenseAgreementAndPrivacyPolicyOfSMS()
        {
            // I Accept Button Clicked by SMS Admin 
            Logger.LogMethodEntry("SMSRegistration",
                "AcceptTheLicenseAgreementAndPrivacyPolicyOfSMS",
                base.isTakeScreenShotDuringEntryExit);
            // Click I Accept Button
            new ConsentPage().ClickIAcceptButtonBySMSAdmin();
            Logger.LogMethodExit("SMSRegistration",
                "AcceptTheLicenseAgreementAndPrivacyPolicyOfSMS",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Register a New SMS User.
        /// </summary>
        /// <param name="userTypeEnum">This is SMS User Type Enum.</param>
        [When(@"I register new SMS user as ""(.*)""")]
        public void RegisterNewSMSUser(User.UserTypeEnum userTypeEnum)
        {
            // Create New SMS User
            Logger.LogMethodEntry("SMSRegistration", "RegisterNewSMSUser",
                base.isTakeScreenShotDuringEntryExit);
            //submit Access Information 
            new Reg1Page().EnterSMSUserAccessInformation(userTypeEnum);
            //Submit Account Information
            new Reg2Page().EnterSMSUserAccountInformation();
            Logger.LogMethodExit("SMSRegistration", "RegisterNewSMSUser",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display of SMS User Create Success Message.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see the Confirmation and Summary for ""(.*)"" registeration")]
        public void DisplayTheConfirmationAndSummaryForSMSUserRegisteration
            (User.UserTypeEnum userTypeEnum)
        {
            // SMS User Created with Confirmation and Summary
            Logger.LogMethodEntry("SMSRegistration",
                "DisplayTheConfirmationAndSummaryForSMSUserRegisteration",
                base.isTakeScreenShotDuringEntryExit);
            //Assert SMS User Created and Saved in Memory
            Logger.LogAssertion("VerifySMSUserCreated",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(SMSRegistrationResource.
                    SMSRegisteration_ConfirmationandSummary_Window_Title_Name,
                    new ConsentPage().GetPageTitle));
            Logger.LogMethodExit("SMSRegistration",
                "DisplayTheConfirmationAndSummaryForSMSUserRegisteration",
                base.isTakeScreenShotDuringEntryExit);
        }

    }
}
