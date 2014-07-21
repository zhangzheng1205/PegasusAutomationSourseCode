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
    /// This class contains details of Create Product.
    /// </summary>
    [Binding]
    public class CreateProduct : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(CreateProduct));

        /// <summary>
        /// Create New Pegasus Product.
        /// </summary>
        /// <param name="productTypeEnum">This is Product Type Enum.</param>
        /// <param name="programTypeEnum">This is Program Type Enum.</param>
        [When(@"I create the ""(.*)"" Product in coursespace using ""(.*)"" Program")]
        public void CreateProductUsingProgram(Product.ProductTypeEnum
           productTypeEnum, Program.ProgramTypeEnum programTypeEnum)
        {
            //Creation of DP Product
            Logger.LogMethodEntry("CreateProduct", "CreateProductUsingProgram",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Create new Product Link
            new ManageProductsPage().ClickOnCreateNewProductLink();
            //Create DP Product
            new NewProductPage().CreateNewProduct(productTypeEnum, programTypeEnum);
            Logger.LogMethodExit("VerifyCreateNewProduct", "CreateProductUsingProgram",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to  Manage Products Page.
        /// </summary>
        [Given(@"I am on the 'Manage Products' Page")]
        [When(@"I am on the 'Manage Products' Page")]
        public void NavigateToManageProductsPage()
        {
            //Manage to navigate  Products Page
            Logger.LogMethodEntry("CreateProduct", "NavigateToManageProductsPage",
                base.isTakeScreenShotDuringEntryExit);
            //Navigate to Manage Products Page
            new AdminToolPage().NavigateManageProductsPage();
            Logger.LogMethodExit("CreateProduct", "NavigateToManageProductsPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Disable Course In Product.
        /// </summary>
        [When(@"I disable the course in product")]
        public void DisableCourseInProduct()
        {
            //Disable Course In Product
            Logger.LogMethodEntry("CreateProduct", "DisableCourseInProduct",
                base.isTakeScreenShotDuringEntryExit);
            //Enable Hide In Catalog Preference
            new CourseEnrollmentModePage().EnableHideInCatalogPreference();            
            Logger.LogMethodExit("CreateProduct", "DisableCourseInProduct",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Cmenu.
        /// </summary>
        /// <param name="courseCmenuOption">This is Course Cmenu Option.</param>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I select ""(.*)"" cmenu of ""(.*)"" course")]
        public void SelectCmenuOfCourse(string courseCmenuOption,
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Select Course Cmenu
            Logger.LogMethodEntry("CreateProduct", "SelectCmenuOfCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Get the Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Select Course Cmenu
            new ProductCoursesPage().
                SelectCourseContextualMenuOptionInProduct(course.Name, courseCmenuOption);
            Logger.LogMethodExit("CreateProduct", "SelectCmenuOfCourse",
                base.isTakeScreenShotDuringEntryExit);
            
        }

        /// <summary>
        /// Verify The Course State.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        /// <param name="courseState">This is Course State.</param>
        [Then(@"I should see the ""(.*)"" course in ""(.*)"" state")]
        public void VerifyTheCourseState(Course.CourseTypeEnum courseTypeEnum,
            string courseState)
        {
            //Verify The Course State
            Logger.LogMethodEntry("CreateProduct", "VerifyTheCourseState",
                base.isTakeScreenShotDuringEntryExit);
            //Get the Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Asserts the Course Status
            Logger.LogAssertion("VerifyCourseStatus", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(courseState,
                    new ProductCoursesPage().GetCourseState(course.Name)));
            Logger.LogMethodExit("CreateProduct", "VerifyTheCourseState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Product Cmenu Option.
        /// </summary>
        [When(@"I click the product cmenu option")]
        public void ClickTheProductCmenuOption()
        {
            //Click The Product Cmenu Option
            Logger.LogMethodEntry("CreateProduct",
                "ClickTheProductCmenuOption",
                base.isTakeScreenShotDuringEntryExit);
            //Click The Product Cmenu Option
            new ProductCoursesPage().ClickTheProductCmenuOption();
            Logger.LogMethodExit("CreateProduct", 
                "ClickTheProductCmenuOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Product In Right Frame.
        /// </summary>
        /// <param name="productTypeEnum">This is Product Type Enum.</param>
        [When(@"I search the product type ""(.*)"" in right frame")]
        public void SearchProductInRightFrame(Product.ProductTypeEnum
            productTypeEnum)
        {
            //Search Product In Right Frame
            Logger.LogMethodEntry("CreateProduct",
                "SearchProductInRightFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Get Product FromMemory
            Product product = Product.Get(productTypeEnum);
            //Click Search Product Link
            new ProductManagementContainerPage().ClickSearchProductLink();
            //Enter Product Name and Click on Search Button
            new ProductSearchPage().
                EnterProductNameandClickonSearchButton(product.Name);
            Logger.LogMethodExit("CreateProduct",
                "SearchProductInRightFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display Of CMenu Options For Product.
        /// </summary>
        /// <param name="table">This is Table Reference.</param>
        [Then(@"I should able to see the Display of c-menu options for product")]
        public void VerifyTheDisplayOfCMenuOptionsForProduct(Table table)
        {
            //Verify The Display Of CMenu Options For Product.
            Logger.LogMethodEntry("CreateProduct",
                 "VerifyTheDisplayOfCMenuOptionsForProduct",
                 base.isTakeScreenShotDuringEntryExit);
            foreach (var tableRow in table.Rows)
            {
                //Assert Display of Activity Cmenu Options
                TableRow row = tableRow;
                Logger.LogAssertion("VerifyCmenuOptions", ScenarioContext.
                    Current.ScenarioInfo.Title,
                () => Assert.AreEqual(row[CreateProductResource.
                    CreateProduct_Page_Expectedresult_Value],
                    new ProductCoursesPage().GetDisplayOfProductCmenuOptions(row[
                    CreateProductResource.CreateProduct_Page_Actualresult_Value])));
            }
            Logger.LogMethodExit("CreateProduct",
                "VerifyTheDisplayOfCMenuOptionsForProduct",
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
