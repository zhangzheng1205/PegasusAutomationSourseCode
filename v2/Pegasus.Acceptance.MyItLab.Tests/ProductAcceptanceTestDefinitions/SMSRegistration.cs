using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Integration.SMS;
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
        Reg1Page reg1page = new Reg1Page();
        Reg2Page reg2page = new Reg2Page();

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
        /// Create new user.
        /// </summary>
        /// <param name="userTypeEnum"></param>
        /// <param name="mode"></param>
        [When(@"I register new SMS user as ""(.*)"" with ""(.*)"" mode")]
        public void RegisterNewSmsUser(User.UserTypeEnum userTypeEnum,string mode)
        {
            // Create New SMS User
            Logger.LogMethodEntry("SMSRegistration", "RegisterNewSmsUser",
                base.IsTakeScreenShotDuringEntryExit);
            //submit Access Information 
            reg1page.EnterSmsUserAccessInformation(userTypeEnum, mode);
            //Submit Account Information
            reg2page.EnterSmsUserAccountOtherInformation(userTypeEnum, mode);
            Logger.LogMethodExit("SMSRegistration", "RegisterNewSmsUser",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Register a New SMS User based on scenario.
        /// </summary>
        /// <param name="scenarioName">This is scenario name for user should be created.</param>
        /// <param name="userTypeEnum">This is user type enum.</param>
        [When(@"I register new SMS user for ""(.*)"" as ""(.*)""")]
        public void RegisterNewSmsUserForDifferentScenarios(string scenarioName,
            User.UserTypeEnum userTypeEnum)
        {
            // Create New SMS User
            Logger.LogMethodEntry("SMSRegistration", "RegisterNewSmsUserForDifferentScenarios",
                base.IsTakeScreenShotDuringEntryExit);
            //submit Access Information 
            reg1page.EnterSmsUserAccessInformationBasedOnScenario(scenarioName, userTypeEnum);
            //Submit Account Information
            reg2page.EnterSmsUserAccountInformation(userTypeEnum, scenarioName);
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

       /// <summary>
        /// Create 'n' number of SMS users(student/instructor) from runtime generated values/Static Excel values.
       /// </summary>
       /// <param name="count">This is the number of users.</param>
       /// <param name="userTypeEnum">This is the type of user.</param>
       /// <param name="mode">This is the mode of user generation.</param>
       /// <param name="smsUser">This is the user type creating user.</param>
        [Given(@"I create '(.*)' users of type ""(.*)"" with mode ""(.*)"" as ""(.*)""")]
        public void CreateBulkSMSUsers(int count, User.UserTypeEnum userTypeEnum, string mode,User.UserTypeEnum smsUser)
        {
            //Create 'n' number of SMS users(student/instructor) from runtime generated values/Static Excel values
            Logger.LogMethodEntry("SMSRegistration",
               "CreateBulkSMSUsers",
               base.IsTakeScreenShotDuringEntryExit);
            //Create 'n' number of SMS users(student/instructor) from runtime generated values/Static Excel values
            reg1page.BulkUserCreation(count, userTypeEnum, mode, smsUser);
            Logger.LogMethodExit("SMSRegistration",
                "CreateBulkSMSUsers",
                base.IsTakeScreenShotDuringEntryExit);
        }


    }
}
