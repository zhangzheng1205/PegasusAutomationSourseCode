#region

using System.Linq;
using System.Collections.Generic;
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
    /// This class handles Global Home Page actions.
    /// </summary>
    [Binding]
    public class GlobalHome : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(GlobalHome));

        /// <summary>
        /// Verifying the Display of Global Home Page tabs.
        /// </summary>
        [Then(@"I should see the Home Page tabs")]
        public void DisplayHomePageTabs()
        {
            //Verify Global Home Page Tabs
            Logger.LogMethodEntry("GlobalHome", "DisplayHomePageTabs",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Global Home Page tabs displayed
            Logger.LogAssertion("VerifyDisplayOfHomePageTabs", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                (true, new HomePage().IsGlobalHomeTabsPresent()));
            Logger.LogMethodExit("GlobalHome", "DisplayHomePageTabs",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Enrolled Classes in the Classes Frame.
        /// </summary>
        /// <param name="classTypeEnum">This is Class by type enum.</param>
        [Then(@"I should see the Enrolled ""(.*)"" in classes frame")]
        public void VerifyEnrolledClassesInClassesFrame(
            Class.ClassTypeEnum classTypeEnum)
        {
            //Verify the Enrolled Classes in the Clasees Frame
            Logger.LogMethodEntry("GlobalHome", "VerifyEnrolledClassesInClassesFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class className = Class.Get(classTypeEnum);
            //Assert Class Name Displayed
            Logger.LogAssertion("VerifyDisplayOfClassName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                (className.Name, new HomePage().GetClassName()));
            Logger.LogMethodExit("GlobalHome", "VerifyEnrolledClassesInClassesFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Product in the Curriculum channel.
        /// </summary>
        /// <param name="productTypeEnum">This is Product Type</param>
        [Then(@"I should see the ""(.*)"" Product in the Curriculum Channel")]
        public void VerifyProductInTheCurriculumChannel(
            Product.ProductTypeEnum productTypeEnum)
        {
            //Verify the Product in the curriculum channel
            Logger.LogMethodEntry("GlobalHome", "VerifyProductInTheCurriculumChannel",
               base.IsTakeScreenShotDuringEntryExit);
            // Get the Product name from memory
            Product product = Product.Get(productTypeEnum);
            //Assert Product Name Displayed
            Logger.LogAssertion("VerifyDisplayOfProductName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                (product.Name, new ContentLibraryPage().GetProductName()));
            Logger.LogMethodExit("GlobalHome", "VerifyProductInTheCurriculumChannel",
                base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see display of welcome message for ""(.*)""")]
        public void VerifyWelcomeMessageText(Product.ProductTypeEnum productType)
        {
            Logger.LogMethodEntry("GlobalHome", "VerifyProductInTheCurriculumChannel",
               base.IsTakeScreenShotDuringEntryExit);

            VerifyDisplayOfWelcomeBannerImageAndMessageOneByOne(1);

            Logger.LogMethodExit("GlobalHome", "VerifyProductInTheCurriculumChannel",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Welcome Message text and button type on Welcome message light box.
        /// </summary>
        /// <param name="noOfProduct">Number of product</param>
        /// <param name="buttonText">Expected text on button</param>
        [Then(@"Only ""(.*)"" Welcome message should display with ""(.*)"" button instead of Next button\.")]
        public void VerifyWelcomeMessageTextAndButtonType(int noOfProduct, string buttonText)
        {
            Logger.LogMethodEntry("GlobalHome", "VerifyWelcomeMessageTextAndButtonType",
               base.IsTakeScreenShotDuringEntryExit);

            Product demoProduct = Product.Get(Product.ProductTypeEnum.DigitalPathDemo);
                        //Assert button type
            Logger.LogAssertion("VerifyWelcomeMessageTextAndButtonType", ScenarioContext.
                   Current.ScenarioInfo.Title, () => Assert.AreEqual
                   (buttonText, new HomePage().GetWelcomeMessageButtonText()));
            //Assert welcome message
            VerifyDisplayOfWelcomeBannerImageAndMessageOneByOne(1);

            Logger.LogMethodExit("GlobalHome", "VerifyWelcomeMessageTextAndButtonType",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the display of Welcome banner images one by one on Welcome message light box.
        /// </summary>
        /// <param name="bannerCount">Number of Welcome banner images</param>
        [Then(@"I can see display of (.*) welcome banner image and welcome message one by one")]
        public void VerifyDisplayOfWelcomeBannerImageAndMessageOneByOne(int bannerCount)
        {
            Logger.LogMethodEntry("GlobalHome",
               "VerifyDisplayOfWelcomeBannerImagesOneByOne",
             base.IsTakeScreenShotDuringEntryExit);

            List<Product> demoProductList = Product.GetAll(
                Product.ProductTypeEnum.DigitalPathDemo);
            HomePage homePage = new HomePage();

            for (int index = 0; index < bannerCount; index++)
            {
                VerifyDisplayOfWelcomeBannerImageMessage(homePage,
                    demoProductList);
                //navigate to next banner or enter to global home
                homePage.ClickWelcomeMessageBoxNavigationButton();
            }

            Logger.LogMethodExit("GlobalHome",
                "VerifyDisplayOfWelcomeBannerImagesOneByOne",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the display of Welcome banner image and welcome message
        /// </summary>
        /// <param name="imageBlobId">Id of Welcome banner image blob</param>
        private void VerifyDisplayOfWelcomeBannerImageMessage(HomePage homePage
            , List<Product> demoProductList)
        {
            Logger.LogMethodEntry("GlobalHome",
              "VerifyDisplayOfWelcomeBannerImage",
            base.IsTakeScreenShotDuringEntryExit);

            foreach(Product demoProduct in demoProductList)
            {
                if (string.IsNullOrWhiteSpace(
                    demoProduct.WelcomeBannerBlobId)) { continue; }
                if (homePage.GetWelcomeBannerSrcAttribute()
                .EndsWith(demoProduct.WelcomeBannerBlobId))
                {     
                    //Further validate welcome message
                    Logger.LogAssertion("VerifyDisplayOfWelcomeBannerImage", 
                        ScenarioContext.Current.ScenarioInfo.Title,
                        () => Assert.AreEqual(demoProduct.WelcomeMessage, 
                            homePage.GetWelcomeMessage()));
                    return;
                }
            };

            Logger.LogAssertion("VerifyDisplayOfWelcomeBannerImage", 
                ScenarioContext.Current.ScenarioInfo.Title, 
                () => Assert.Fail());

            Logger.LogMethodExit("GlobalHome",
                "VerifyDisplayOfWelcomeBannerImage",
            base.IsTakeScreenShotDuringEntryExit);
        }

       /// <summary>
        /// Verify the display of Product branding images
       /// </summary>
       /// <param name="productCount">Number of products.</param>
       /// <param name="productType">Type of product.</param>
        [Then(@"I should see the display of (.*) ""(.*)"" Product branding images")]
        public void VerifyDisplayOfProductBrandingImages(int productCount,Product.ProductTypeEnum productType)
        {
            Logger.LogMethodEntry("GlobalHome",
              "VerifyDisplayOfProductBrandingImages",
            base.IsTakeScreenShotDuringEntryExit);

            IList<Product> demoProductList = Product.GetAll(productType);            
            IList<string> productIdList =  new HomePage().GetProductIdOfProductBrandingImagesDispayed();
            var result = demoProductList.Where(product => productIdList.Contains(product.ProductId));
            Assert.AreEqual(productCount, result.Count());
            Logger.LogMethodExit("GlobalHome",
                "VerifyDisplayOfProductBrandingImages",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select Cmenu option of Class.
        /// </summary>
        /// <param name="className">Name of class whose cmenu option need to be selected.</param>
        /// <param name="cmenuOption">Cmenu option to select.</param>
        [When(@"I click on Cmenu option of Class ""(.*)"" and select ""(.*)"" option")]
        public void SelectCmenuOptionOfClass(Class.ClassTypeEnum classTypeEnum, string cmenuOption)
        {
            Logger.LogMethodEntry("GlobalHome",
              "SelectCmenuOptionOfClass",
            base.IsTakeScreenShotDuringEntryExit);
            //Get class name from memory
            Class Class = Class.Get(classTypeEnum);
            string className = Class.Name.ToString();
            //Click on cmenu icon of class and select the required option
            new HomePage().ClickOnCmenuIconOfClassAndSelectOption(className, cmenuOption);
            Logger.LogMethodExit("GlobalHome",
                "SelectCmenuOptionOfClass",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Digital Path product from the curriculum dropdown
        /// </summary>
        /// <param name="productName">This is for the Product Name.</param>
        [When(@"I select ""(.*)"" Product in the Curriculum dropdown")]
        public void SelectProductInTheCurriculumDropdown(Product.ProductTypeEnum productName)
        {
            Logger.LogMethodEntry("GlobalHome", "SelectProductInTheCurriculumDropdown",base.IsTakeScreenShotDuringEntryExit);
            Product product = Product.Get(productName);
            string productTitle = product.Name.ToString();
            new ContentLibraryPage().SelectProductFromCurriculumDropdown(productTitle);
            Logger.LogMethodExit("GlobalHome", "SelectProductInTheCurriculumDropdown", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Validate success message in Home page
        /// </summary>
        /// <param name="successMessage">This is the success message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in Home tab")]
        public void VaidateSuccessfullMessageInHomeTab(string successMessage)
        {
            //Verify Successfull Message In Home Tab
            Logger.LogMethodEntry("GlobalHome", "VaidateSuccessfullMessageInHomeTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Display of Success Message
            Logger.LogAssertion("VerifySuccessfullMessage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(successMessage, new HomePage().GetSuccessMessageHomePage()));
            Logger.LogMethodExit("GlobalHome", "VaidateSuccessfullMessageInHomeTabv",
                base.IsTakeScreenShotDuringEntryExit);
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
