using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// Contains Register Demo Account related steps
    /// </summary>
    [Binding]
    public class RegisterDemoAccount : PegasusBaseTestFixture
    {

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(RegisterDemoAccount));

        /// <summary>
        /// Browse the Register Demo Account URL
        /// </summary>
        /// <param name="pageName">Name of the page</param>
        [Given(@"I browsed the url for ""(.*)"" Page")]
        [When(@"I browse the url for ""(.*)"" Page")]
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

        /// <summary>
        /// Registers a new demo account
        /// </summary>
        /// <param name="userType">User type</param>
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

        /// <summary>
        /// Verify the success message in Message light box
        /// </summary>
        /// <param name="message">Success message</param>
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

        /// <summary>
        /// Ensures that atleast one product should be licenced in an organsisation
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="licenceCount">Number of licences</param>
        [Given(@"One ""(.*)"" Product should be licensed (.*) times with same organization")]
        public void OneProductShouldBeLicensedInOrganization(Product.ProductTypeEnum productType
            , int licenceCount)
        {
            Logger.LogMethodEntry("RegisterDemoAccount",
                "OneProductShouldBeLicensedInOrganization",
              base.isTakeScreenShotDuringEntryExit);
            //Ensure that product exists
            Product.Get(productType);
            User.GetAll(User.UserTypeEnum.DPDemoUser).Single(
                u => u.ProductInstance == "1")
                .CreationDate = DateTime.Now;          
            Logger.LogMethodExit("RegisterDemoAccount",
                "OneProductShouldBeLicensedInOrganization",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Multiple demo products should be created with same access code.
        /// </summary>
        /// <param name="productCount">Number of products</param>
        /// <param name="productType">type of product</param>
        [Given(@"(.*) ""(.*)"" Product created with same access code and licencesed in a organsation")]
        public void MultipleProductCreatedWithSameAccessCodeAndLicencesed(int productCount, Product.ProductTypeEnum productType)
        {
            Logger.LogMethodEntry("RegisterDemoAccount",
                "MultipleProductCreatedWithSameAccessCodeAndLicencesed",
              base.isTakeScreenShotDuringEntryExit);
            User.GetAll(User.UserTypeEnum.DPDemoUser).Single(
                u => u.ProductInstance == "2")
                .CreationDate = DateTime.Now;   
            //Ensure that products exists
           Assert.IsTrue( Product.GetAll(productType).Count >= productCount );
            Logger.LogMethodExit("RegisterDemoAccount",
                "MultipleProductCreatedWithSameAccessCodeAndLicencesed",
            base.isTakeScreenShotDuringEntryExit);
        }

                   

    }
}
