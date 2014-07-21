#region

using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
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
                base.isTakeScreenShotDuringEntryExit);
            //Assert Global Home Page tabs displayed
            Logger.LogAssertion("VerifyDisplayOfHomePageTabs", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                (true, new HomePage().IsGlobalHomeTabsPresent()));
            Logger.LogMethodExit("GlobalHome", "DisplayHomePageTabs",
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class className = Class.Get(classTypeEnum);
            //Assert Class Name Displayed
            Logger.LogAssertion("VerifyDisplayOfClassName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                (className.Name, new HomePage().GetClassName()));
            Logger.LogMethodExit("GlobalHome", "VerifyEnrolledClassesInClassesFrame",
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
            // Get the Product name from memory
            Product product = Product.Get(productTypeEnum);
            //Assert Product Name Displayed
            Logger.LogAssertion("VerifyDisplayOfProductName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                (product.Name, new ContentLibraryPage().GetProductName()));
            Logger.LogMethodExit("GlobalHome", "VerifyProductInTheCurriculumChannel",
                base.isTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see display of welcome message for ""(.*)""")]
        public void VerifyWelcomeMessageText(Product.ProductTypeEnum productType)
        {
            Logger.LogMethodEntry("GlobalHome", "VerifyProductInTheCurriculumChannel",
               base.isTakeScreenShotDuringEntryExit);

            VerifyDisplayOfWelcomeBannerImageAndMessageOneByOne(1);

            Logger.LogMethodExit("GlobalHome", "VerifyProductInTheCurriculumChannel",
               base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);

            Product demoProduct = Product.Get(Product.ProductTypeEnum.DigitalPathDemo);
                        //Assert button type
            Logger.LogAssertion("VerifyWelcomeMessageTextAndButtonType", ScenarioContext.
                   Current.ScenarioInfo.Title, () => Assert.AreEqual
                   (buttonText, new HomePage().GetWelcomeMessageButtonText()));
            //Assert welcome message
            VerifyDisplayOfWelcomeBannerImageAndMessageOneByOne(1);

            Logger.LogMethodExit("GlobalHome", "VerifyWelcomeMessageTextAndButtonType",
               base.isTakeScreenShotDuringEntryExit);
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
             base.isTakeScreenShotDuringEntryExit);

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
            base.isTakeScreenShotDuringEntryExit);
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
            base.isTakeScreenShotDuringEntryExit);

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
            base.isTakeScreenShotDuringEntryExit);
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
            base.isTakeScreenShotDuringEntryExit);

            IList<Product> demoProductList = Product.GetAll(productType);            
            IList<string> productIdList =  new HomePage().GetProductIdOfProductBrandingImagesDispayed();
            var result = demoProductList.Where(product => productIdList.Contains(product.ProductId));
            Assert.AreEqual(productCount, result.Count());
            Logger.LogMethodExit("GlobalHome",
                "VerifyDisplayOfProductBrandingImages",
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
