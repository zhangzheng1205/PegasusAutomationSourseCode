using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{

    [Binding]
    public class RegisterDemoAccount : PegasusBaseTestFixture
    {

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(RegisterDemoAccount));


        [Given(@"I browsed the url for ""(.*)"" Page")]
        public void BrowseRegisterDemoAccountURL(String pageName)
        {
            Logger.LogMethodEntry("RegisterDemoAccount", "BrowseRegisterDemoAccountURL",
             base.isTakeScreenShotDuringEntryExit);
            if (pageName.Equals("RegisterYourDemoAccount"))
            {
               new DemoAccountRegistrationPage(User.UserTypeEnum.DPDemoUser).GoToDemoAccountRegistrationUrl();
              
            }
            Logger.LogMethodExit("RegisterDemoAccount", "BrowseRegisterDemoAccountURL",
                base.isTakeScreenShotDuringEntryExit);
        }


        [When(@"I register account as ""(.*)"" using my demo access code")]
        public void RegisterNewDemoAccount(string userType)
        {
            Logger.LogMethodEntry("RegisterDemoAccount", "RegisterNewDemoAccount",
              base.isTakeScreenShotDuringEntryExit);
            User.UserTypeEnum userTypeEnum = (User.UserTypeEnum)Enum.Parse(typeof(User.UserTypeEnum), userType);
            new DemoAccountRegistrationPage(userTypeEnum).RegisterDemoAccount(userTypeEnum);

            Logger.LogMethodExit("RegisterDemoAccount", "RegisterNewDemoAccount",
                base.isTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see the successful message box ""(.*)""")]
        public void ThenIShouldSeeTheSuccessfulMessageBox(string message)
        {
            Logger.LogMethodEntry("RegisterDemoAccount", "ThenIShouldSeeTheSuccessfulMessageBox",
             base.isTakeScreenShotDuringEntryExit);

            Assert.AreEqual(message,
            new DemoAccountRegistrationPage(User.UserTypeEnum.DPDemoUser).GetSuccessMessageFromMessageBox());

            Logger.LogMethodExit("RegisterDemoAccount", "ThenIShouldSeeTheSuccessfulMessageBox",
                base.isTakeScreenShotDuringEntryExit);
        }


    }
}
