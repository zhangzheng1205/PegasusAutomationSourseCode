using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MLP.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles the different type of course association 
    /// to different type's of Product in Pegasus.
    /// </summary>
    [Binding]
    public class CourseAssociation : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CourseAssociation));

        /// <summary>
        /// Select Course For Association.
        /// </summary>
        [When(@"I select course in left frame")]
        public void SelectCourseTypeInLeftFrame()
        {
            //Select Course For Association
            Logger.LogMethodEntry("CourseAssociation",
                "SelectCourseTypeInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Select Approved Course
            new ListCoursesPage().SelectApprovedCourse();
            Logger.LogMethodExit("CourseAssociation",
                "SelectCourseTypeInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search and select product in the right frame.
        /// </summary>
        /// <param name="productTypeEnum">This is product by Type.</param>
        [When(@"I select product type ""(.*)"" in right frame")]
        public void SelectProductTypeInRightFrame(
            Product.ProductTypeEnum productTypeEnum)
        {
            //Select Product
            Logger.LogMethodEntry("CourseAssociation", "SelectProductTypeInRightFrame",
                base.isTakeScreenShotDuringEntryExit);
            // Purpose: To pick the product stored in memory
            Product product = Product.Get(productTypeEnum);
            //Click Search Product Link
            new ProductManagementContainerPage().ClickSearchProductLink();
            //Search Product
            new ProductSearchPage().SearchProduct(product.Name);
            Logger.LogMethodExit("CourseAssociation", "SelectProductTypeInRightFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Course association to the product.
        /// </summary>
        [When(@"I associate the course to Pegasus product")]
        public void AssociateTheCourseToPegasusProduct()
        {
            //Associate Course To Product
            Logger.LogMethodEntry("CourseAssociation",
                "AssociateTheCourseToPegasusProduct",
                base.isTakeScreenShotDuringEntryExit);
            //Click Program Course Add Button
            new AddButtonPage().ClickProgramCoursesAddButton();
            //Click Enrollment Mode Option
            new AdminToolPage().ClickAddNewCourseEnrollmentModeOption();
            //Created Page Object
            CourseEnrollmentModePage courseEnrollmentModePage =
                new CourseEnrollmentModePage();
            //Save Course Enrollment Mode
            courseEnrollmentModePage.SelectEnrollmentMode();
            //Click Enrollement Save Button
            courseEnrollmentModePage.ClickEnrollmentSaveButton();
            Logger.LogMethodExit("CourseAssociation",
                "AssociateTheCourseToPegasusProduct",
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
