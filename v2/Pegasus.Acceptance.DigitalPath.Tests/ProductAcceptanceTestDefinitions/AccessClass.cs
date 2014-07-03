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
    /// This class handles Access Class by Teacher.
    /// </summary>
    [Binding]
    public class AccessClass: PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(AccessClass));
               
        /// <summary>
        /// Verify The Product .
        /// </summary>
        /// <param name="productTypeEnum">This is for product by type enum.</param>
        [Then(@"I should be able to see the ""(.*)"" product")]
        public void VerifyTheProduct(
            Product.ProductTypeEnum productTypeEnum)
        {
            //Verify The Product
            Logger.LogMethodEntry("AccessClass", "VerifyTheProduct",
               isTakeScreenShotDuringEntryExit);
            //Get product from memory
            Product product = Product.Get(productTypeEnum);   
            //Assert for product name           
            Logger.LogAssertion("VerifyProductName",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual
                (product.Name, new HomePage().GetTheProduct(product.Name)));
            Logger.LogMethodExit("AccessClass", "VerifyTheProduct",
              isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Click on the "Add" button.
        /// </summary>
        [When(@"I click on the Add button")]
        public void ClickOnTheAddButton()
        {
            //Click on the "Add" button
            Logger.LogMethodEntry("AccessClass", "ClickOnTheAddButton",
               isTakeScreenShotDuringEntryExit);
            //Click the "Add" button
            new HomePage().ClickTheAddButton();
            Logger.LogMethodExit("AccessClass", "ClickOnTheAddButton",
              isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        ///Click on the "Cancel" button.
        /// </summary>       
        [When(@"I click on the Cancel button")]
        public void ClickOnTheCancelButton()
        {
            //Click on the "Cancel" button 
            Logger.LogMethodEntry("AccessClass", "ClickOnTheCancelButton",
               isTakeScreenShotDuringEntryExit);
            //Click the "Cancel" button
            new HomePage().ClickTheCancelButton();
            Logger.LogMethodExit("AccessClass", "ClickOnTheCancelButton",
              isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Verify The Class.
        /// </summary>
        /// <param name="classTypeEnum">This is class Type Enum.</param>
        [Then(@"I should able to see the ""(.*)"" class")]
        public void VerifyTheClass(
            Class.ClassTypeEnum classTypeEnum)
        {
            //Verify The Class
            Logger.LogMethodEntry("AccessClass", "VerifyTheClass",
               isTakeScreenShotDuringEntryExit);
            //Get class from memory
            Class className = Class.Get(classTypeEnum);
            // Assert for classname
            Logger.LogAssertion("VerifyClassName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(className.Name,
                    new HomePage().GetDisplayClassName(className.Name)));
            Logger.LogMethodExit("AccessClass", "VerifyTheClass",
              isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
