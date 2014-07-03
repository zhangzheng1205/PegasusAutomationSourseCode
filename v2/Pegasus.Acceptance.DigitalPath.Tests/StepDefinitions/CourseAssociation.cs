#region

using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.Definitions
{
    /// <summary>
    /// This class handles the, Associate Master Library To Product.
    /// </summary>
    [Binding]
    public class CourseAssociation:BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(CourseAssociation));

        /// <summary>
        /// Select Coursetype from left frame.
        /// </summary>
        [When(@"I select course in left frame")]
        public void SelectCourseTypeInLeftFrame()
        {
            //Select Coursetype from left frame
            logger.LogMethodEntry("CourseAssociation", "SelectCourseTypeInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Select Approved Course
            new ListCoursesPage().SelectApprovedCourse();
            logger.LogMethodExit("CourseAssociation", "SelectCourseTypeInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search and select the product in the right frame.
        /// </summary>
        /// <param name="productTypeEnum">This is product by Type.</param>
        [When(@"I select product type ""(.*)"" in right frame")]
        public void SelectProductTypeInRightFrame
            (Product.ProductTypeEnum productTypeEnum)
        {
            //Search and select Product in right frame
            logger.LogMethodEntry("CourseAssociation", "SelectProductTypeInRightFrame",
                base.isTakeScreenShotDuringEntryExit);
            //To select the product stored in memory
             Product product = Product.Get(productTypeEnum);
            //Click Search Product Link
            new ProductManagementContainerPage().ClickSearchProductLink();
            //Search the Product
            new ProductSearchPage().SearchProduct(product.Name);
            logger.LogMethodExit("CourseAssociation", "SelectProductTypeInRightFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Course association to the product.
        /// </summary>       
        [When(@"I associate the course to Pegasus product")]        
        public void AssociateTheCourseToPegasusProduct()
        {
            //Course association to the product
            logger.LogMethodEntry("CourseAssociation",
                "AssociateTheCourseToPegasusProduct",
                base.isTakeScreenShotDuringEntryExit);
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
            new ShowMessagePage().ClickTheAlertOkButton();
            logger.LogMethodExit("CourseAssociation",
                "AssociateTheCourseToPegasusProduct",
                base.isTakeScreenShotDuringEntryExit);
       }     
   }
}
