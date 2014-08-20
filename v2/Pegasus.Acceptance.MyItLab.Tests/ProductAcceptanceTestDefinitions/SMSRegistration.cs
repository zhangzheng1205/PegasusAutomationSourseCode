using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyITLab.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles SMS Registration Page Actions
    /// also responsible to create SMS user registeration.
    /// </summary>
    [Binding]
    public class SmsRegistration : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(SmsRegistration));

        /// <summary>
        /// Accept The License Agreement And Privacy Policy 
        /// Button Clicked by SMS Admin.
        /// </summary>
        [When(@"I accept the License Agreement and Privacy Policy of SMS")]
        public void AcceptTheLicenseAgreementAndPrivacyPolicyOfSms()
        {
            // I Accept Button Clicked by SMS Admin 
            Logger.LogMethodEntry("SMSRegistration",
                "AcceptTheLicenseAgreementAndPrivacyPolicyOfSms",
                base.IsTakeScreenShotDuringEntryExit);
            // Click I Accept Button
            new ConsentPage().ClickIAcceptButtonBySMSAdmin();
            Logger.LogMethodExit("SMSRegistration",
                "AcceptTheLicenseAgreementAndPrivacyPolicyOfSms",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Register a New SMS User.
        /// </summary>
        /// <param name="userTypeEnum">This is user Type Enum.</param>
        [When(@"I register new SMS user as ""(.*)""")]
        public void RegisterNewSmsUser(User.UserTypeEnum userTypeEnum)
        {
            // Create New SMS User
            Logger.LogMethodEntry("SMSRegistration", "RegisterNewSmsUser",
                base.IsTakeScreenShotDuringEntryExit);
            //submit Access Information 
            new Reg1Page().EnterSmsUserAccessInformation(userTypeEnum);
            //Submit Account Information
            new Reg2Page().EnterSmsUserAccountInformation();
            Logger.LogMethodExit("SMSRegistration", "RegisterNewSmsUser",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Register a New SMS User based on scenario.
        /// </summary>
        /// <param name="scenarioName">This is scenario name for user should be created.</param>
        /// <param name="userTypeEnum">This is user type enum.</param>
        [When(@"I register new SMS user for ""(.*)"" as ""(.*)""")]
        public void RegisterNewSmsUserForDifferentScenarios(string scenarioName, User.UserTypeEnum userTypeEnum)
        {
            // Create New SMS User
            Logger.LogMethodEntry("SMSRegistration", "RegisterNewSmsUserForDifferentScenarios",
                base.IsTakeScreenShotDuringEntryExit);
            //submit Access Information 
            new Reg1Page().EnterSmsUserAccessInformationBasedOnScenario(scenarioName, userTypeEnum);
            //Submit Account Information
            new Reg2Page().EnterSmsUserAccountInformation();
            Logger.LogMethodExit("SMSRegistration", "RegisterNewSmsUserForDifferentScenarios",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Display of SMS User Create Success Message.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see the Confirmation and Summary for ""(.*)"" registeration")]
        public void DisplayTheConfirmationAndSummaryForSmsUserRegisteration
            (User.UserTypeEnum userTypeEnum)
        {
            // SMS User Created with Confirmation and Summary
            Logger.LogMethodEntry("SMSRegistration",
                "DisplayTheConfirmationAndSummaryForSMSUserRegisteration",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert SMS User Created and Saved in Memory
            Logger.LogAssertion("VerifySMSUserCreated",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(SMSRegistrationResource.
                    SMSRegisteration_ConfirmationandSummary_Window_Title_Name,
                    new ConsentPage().GetPageTitle));
            Logger.LogMethodExit("SMSRegistration",
                "DisplayTheConfirmationAndSummaryForSMSUserRegisteration",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
