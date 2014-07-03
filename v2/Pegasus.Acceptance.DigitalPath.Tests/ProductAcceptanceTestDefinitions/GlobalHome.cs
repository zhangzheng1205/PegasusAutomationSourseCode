#region

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

            Product demoProduct = Product.Get(productType);
            Logger.LogAssertion("VerifyWelcomeMessageText", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.AreEqual
               (demoProduct.WelcomeMessage, new HomePage().GetWelcomeMessage()));

            Logger.LogMethodExit("GlobalHome", "VerifyProductInTheCurriculumChannel",
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
