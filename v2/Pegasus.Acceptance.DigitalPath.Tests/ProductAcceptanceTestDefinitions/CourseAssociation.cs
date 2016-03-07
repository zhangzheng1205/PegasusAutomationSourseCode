#region

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
    /// This class handles the, Associate Master Library To Product.
    /// </summary>
    [Binding]
    public class CourseAssociation : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CourseAssociation));

        /// <summary>
        /// Select Coursetype from left frame
        /// </summary>
        [When(@"I select course in left frame")]
        public void SelectCourseTypeInLeftFrame()
        {
            //Select Coursetype from left frame
            Logger.LogMethodEntry("CourseAssociation",
                "SelectCourseTypeInLeftFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Approved Course
            new ListCoursesPage().SelectApprovedCourse();
            Logger.LogMethodExit("CourseAssociation",
                "SelectCourseTypeInLeftFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search and select the product in the right frame.
        /// </summary>
        /// <param name="productTypeEnum">This is product type enum.</param>
        [When(@"I select product type ""(.*)"" in right frame")]
        public void SelectProductTypeInRightFrame(
            Product.ProductTypeEnum productTypeEnum)
        {
            //Search and select Product in right frame
            Logger.LogMethodEntry("CourseAssociation", "SelectProductTypeInRightFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //To select the product stored in memory
            Product product = Product.Get(productTypeEnum);
            //Click Search Product Link
            new ProductManagementContainerPage().ClickSearchProductLink();
            //Search the Product
            new ProductSearchPage().SearchProduct(product.Name);
            Logger.LogMethodExit("CourseAssociation", "SelectProductTypeInRightFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Course association to the product.
        /// </summary>       
        [When(@"I associate the course to Pegasus product")]
        public void AssociateTheCourseToPegasusProduct()
        {
            //Course association to the product
            Logger.LogMethodEntry("CourseAssociation",
                "AssociateTheCourseToPegasusProduct",
                base.IsTakeScreenShotDuringEntryExit);
            //Click Program Course Add Button
            new AddButtonPage().ClickProgramCoursesAddButton();
            //Click Enrollment Mode Option
            new AdminToolPage().ClickAddNewCourseEnrollmentModeOption();
            //To get the productId and ResourceId stored in memory
            License licence = License.Get(License.LicenseTypeEnum.Rumba);
            
            //Fill the productId and ResourceId 
            new CourseEnrollmentModePage().CreateLicensing
                (licence.ProductID, licence.ResourceID);
            //Create Page Object
            CourseEnrollmentModePage courseEnrollmentModePage =
                new CourseEnrollmentModePage();
            //Select Enrollement Course Enrollment Mode
            courseEnrollmentModePage.SelectEnrollmentMode();
            //Save To Associate Coure In Product
            courseEnrollmentModePage.ClickEnrollmentSaveButton();
            //Click on the alert "Ok" button      
            new ShowMessagePage().ClickTheAlertOkButton();
            Logger.LogMethodExit("CourseAssociation",
                "AssociateTheCourseToPegasusProduct",
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
