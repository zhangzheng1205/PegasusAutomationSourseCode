using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using Pegasus.Acceptance.DigitalPath.Tests.CommonProductAcceptanceTestDefinitions;
using System.Threading;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Acceptance.DigitalPath.Tests.ProductacceptanceTestDefinitions
{
    /// <summary>
    /// This class handles the Add Product use case 
    /// </summary>
    [Binding]
    public class setupwizard : PegasusBaseTestFixture
    {
        /// <summary>
        ///  The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(setupwizard));
        /// <summary>
        /// Click on Add Button in Curriculum Channel
        /// </summary>
        [When(@"I Click on Add button")]
        public void WhenIClickOnAddButton()
        {
            // Method to Click the Add Button in Curriculumn Channel of Home Page
            Logger.LogMethodEntry("setupwizard", "WhenIClickOnAddButton",
               IsTakeScreenShotDuringEntryExit);
            //Click On Add Product link
            new frmSetupWizardPage().ClickOnAddProduct();
            Logger.LogMethodEntry("setupwizard", "WhenIClickOnAddButton",
              IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select Product to Add 
        /// </summary>
        /// <param name="productName"></param>
        [When(@"I select ""(.*)"" Product")]
        public void WhenISelectProduct(Product.ProductTypeEnum productName)
        {
            //Method to select the Product using checkbox
            Logger.LogMethodEntry("setupwizard", "WhenISelectProduct",
              IsTakeScreenShotDuringEntryExit);
            //Get the Product Name from Test Data
            Product Product = Product.Get(productName);
            string prodName = Product.Name.ToString();
            // Select the Checkbox of Product
            new frmSetupWizardPage().SelectProduct(prodName);
            Logger.LogMethodEntry("setupwizard", "WhenISelectProduct",
             IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click on Save Button
        /// </summary>
        [When(@"I Click on the Save button")]
        public void WhenIClickOnTheSaveButton()
        {
            //Method to Add the selected Product by clicking Save button
            Logger.LogMethodEntry("setupwizard", "WhenIClickOnTheSaveButton",
               IsTakeScreenShotDuringEntryExit);
            //Click on Save button in setup wizard
            new frmSetupWizardPage().ClickOnSave();
            Logger.LogMethodEntry("setupwizard", "WhenIClickOnTheSaveButton",
               IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see the successfull message ""(.*)"" on setup wizard")]
        public void ValidateSuccessMessageInSetupWizard(string successMessage)
        {
            //Method to see the successmessege is as expected.
            Logger.LogMethodEntry("setupwizard", "ValidateSuccessMessageInSetupWizard",
            base.IsTakeScreenShotDuringEntryExit);
            //Validate class creation success message
            Logger.LogAssertion("ValidateSuccessMessageInSetupWizard", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(successMessage, new frmSetupWizardPage().GetAddProductSuccessMessageInSetupWizard()));
            Logger.LogMethodExit("setupwizard", "ValidateSuccessMessageInSetupWizard",
          base.IsTakeScreenShotDuringEntryExit);

        }
        [When(@"I Click On the Save and Exit button")]
        public void WhenIClickOnTheSaveAndExitButton()
        {
            //Method to close the Setup Wizard using 'No, Save and Exit' button
            Logger.LogMethodEntry("setupwizard", "WhenIClickOnTheSaveButton",
              IsTakeScreenShotDuringEntryExit);
            //Click on 'No, Save and Exit' button
            new frmSetupWizardPage().ClickonSaveandExit();
            Logger.LogMethodEntry("setupwizard", "WhenIClickOnTheSaveButton",
           IsTakeScreenShotDuringEntryExit);
        }

        //[Then(@"I should see the added ""(.*)"" Product in the Curriculum Channel")]
        //public void VerifyProductInCurriculumChannel(Product.ProductTypeEnum productName)
        //{
        //    Product Product = Product.Get(productName);
        //    string prodName = Product.Name.ToString();
        //    // Select the Checkbox of Product
        //    new frmSetupWizardPage().VerifyProductName(prodName);
        //    Logger.LogMethodEntry("setupwizard", "WhenISelectProduct",
        //     IsTakeScreenShotDuringEntryExit);
        //}

       /// <summary>
       /// Verify added product in Curriculum Channel.
       /// </summary>
       /// <param name="productName">This is the product name.</param>
        [Then(@"I should see the product ""(.*)"" in the Curriculum channel")]
        public void VerifyProductInTheCurriculumChannel(Product.ProductTypeEnum productName)
        {
            Product Product = Product.Get(productName);
            string prodName = Product.Name.ToString();
            //Validate class creation success message
            Logger.LogMethodEntry("SetUpWizard", "VerifyProductInTheCurriculumChannel",
             base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyProductInTheCurriculumChannel", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(prodName, new frmSetupWizardPage().VerifyProductName(prodName)));
            Logger.LogMethodExit("SetUpWizard", "VerifyProductInTheCurriculumChannel",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Remove subscribed product from curriculum channel
        /// </summary>
        /// <param name="cmenuOption"></param>
        /// <param name="productName"></param>
        [When(@"I click on ""(.*)"" option of product ""(.*)"" in the Curriculum channel")]
        public void ClickRemoveCurriculumOptionOfProductInTheCurriculumChannel(string cmenuOption, Product.ProductTypeEnum productName)
        {
            // Remove product from curriculum
            Product Product = Product.Get(productName);
            string prodName = Product.Name.ToString();
            Logger.LogMethodEntry("SetUpWizard", "ClickRemoveCurriculumOptionOfProductInTheCurriculumChannel",
             base.IsTakeScreenShotDuringEntryExit);
            new frmSetupWizardPage().RemoveProductFromCurriculum(cmenuOption, prodName);
            Logger.LogMethodExit("SetUpWizard", "ClickRemoveCurriculumOptionOfProductInTheCurriculumChannel",
            base.IsTakeScreenShotDuringEntryExit);
        }
    }
}



