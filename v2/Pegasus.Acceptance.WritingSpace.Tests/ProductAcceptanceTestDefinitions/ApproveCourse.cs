using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.WritingSpace.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Approve Course Page Actions.
    /// </summary>
    [Binding]
    public class ApproveCourse : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ApproveCourse));

        /// <summary>
        /// Search Course In Course Space.
        /// </summary>
        /// <param name="courseTypeEnum">This is course by type enum.</param>
        [When("I search the \"(.*)\" course in coursespace")]
        public void SearchCourseInCourseSpace(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Search Course In Left Frame
            Logger.LogMethodEntry("ApproveCourse", "SearchCourseInCourseSpace",
               base.IsTakeScreenShotDuringEntryExit);
            PublishCourseSearchPage publishCourseSearchPage = new PublishCourseSearchPage();
            //Get the Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Search Course To Approve
            publishCourseSearchPage.SelectSearchCourseFrame(course.Name);
            //Select Course To Approve
            publishCourseSearchPage.SelectCourseToApprove(course.Name);
            Logger.LogMethodExit("ApproveCourse", "SearchCourseInCourseSpace",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Course Search In CourseSpace.
        /// </summary>
        /// <param name="courseTypeEnum">This is course by type enum.</param>
        [Then("I should be able to see the searched \"(.*)\" course in the left frame")]
        public void CheckSearchedCourseInCoreSpace(
            Course.CourseTypeEnum courseTypeEnum)
        {
            // Verify Course Search In CourseSpace
            Logger.LogMethodEntry("ApproveCourse",
                "CheckSearchedCourseInCoreSpace",
            base.IsTakeScreenShotDuringEntryExit);
            //Get Course Name From InMemory
            Course course = Course.Get(courseTypeEnum);
            // Assert Course Search
            Logger.LogAssertion("VerifySearchCourse", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.AreEqual(course.Name,
                  new ListCoursesPage().
                  GetSearchedCourseNameInCourseSpace(courseTypeEnum)));
            Logger.LogMethodExit("ApproveCourse",
                "CheckSearchedCourseInCoreSpace",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the c-menu option of the course.
        /// </summary>
        /// <param name="optionName">This is link option name.</param>
        [When("I click on \"(.*)\" cmenu option of course in coursespace")]
        public void ClickCMenuCourseOptionInCourseSpace(
            String optionName)
        {
            //Click Approve CMenu Option           
            Logger.LogMethodEntry("ApproveCourse",
                "ClickCMenuCourseOptionInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
            // Click on course cmenu in course space
            new ListCoursesPage().ClickCourseCMenuOption(optionName);
            Logger.LogMethodExit("ApproveCourse",
                "ClickCMenuCourseOptionInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course For Association.
        /// </summary>
        [When(@"I select course in left frame")]
        public void SelectCourseTypeInLeftFrame()
        {
            //Select Course For Association
            Logger.LogMethodEntry("ApproveCourse",
                "SelectCourseTypeInLeftFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Approved Course
            new ListCoursesPage().SelectApprovedCourse();
            Logger.LogMethodExit("ApproveCourse",
                "SelectCourseTypeInLeftFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search and select product in the right frame.
        /// </summary>
        /// <param name="productTypeEnum">This is product by Type Enum.</param>
        [When(@"I select product type ""(.*)"" in right frame")]
        public void SelectProductTypeInRightFrame(
            Product.ProductTypeEnum productTypeEnum)
        {
            //Select Product
            Logger.LogMethodEntry("ApproveCourse",
                "SelectProductTypeInRightFrame",
                base.IsTakeScreenShotDuringEntryExit);
            // Purpose: To pick the product stored in memory
            Product product = Product.Get(productTypeEnum);
            //Click Search Product Link
            new ProductManagementContainerPage().ClickSearchProductLink();
            //Search Product
            new ProductSearchPage().SearchProduct(product.Name);
            Logger.LogMethodExit("ApproveCourse",
                "SelectProductTypeInRightFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Associate The Course Through CCNGIntegration To Product.
        /// </summary>
        [When(@"I associate the Master Course through CCNG Integration to pegasus product")]
        public void AssociateTheCourseThroughCCNGIntegrationToProduct()
        {
            //Associate The Course Through CCNGIntegration To Product
            Logger.LogMethodEntry("ApproveCourse",
                "AssociateTheCourseThroughCCNGIntegrationToProduct",
                base.IsTakeScreenShotDuringEntryExit);
            //Click Program Course Add Button
            new AddButtonPage().ClickProgramCoursesAddButton();
            //Click Enrollment Mode Option
            new AdminToolPage().ClickAddNewCourseEnrollmentModeOption();
            //Create Page Object
            CourseEnrollmentModePage courseEnrollmentModePage =
                new CourseEnrollmentModePage();
            //Select Enrollement Course Enrollment Mode
            courseEnrollmentModePage.SelectEnrollmentMode();
            //Select CCNGIntegration PointID Checkbox
            courseEnrollmentModePage.SelectCCNGIntegrationPointIDCheckbox();
            //Save To Associate Coure In Product
            courseEnrollmentModePage.ClickEnrollmentSaveButton();
            Logger.LogMethodExit("ApproveCourse",
                "AssociateTheCourseThroughCCNGIntegrationToProduct",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Integration PointID In General Product.
        /// </summary>
        [When(@"I get the 'IntegrationPointID' in general product")]
        public void GetIntegrationPointIDInGeneralProduct()
        {
            //Get Integration PointID In General Product
            Logger.LogMethodEntry("ApproveCourse",
                "GetIntegrationPointIDInGeneralProduct",
                base.IsTakeScreenShotDuringEntryExit);
            ProductManagementContainerPage productManagementContainerPage =
                    new ProductManagementContainerPage();
            //Click on Product Course Preference Option
            productManagementContainerPage.ClickonProductCoursePreferenceOption();
            //Get Integration PointID
            productManagementContainerPage.GetIntegrationPointID();
            Logger.LogMethodExit("ApproveCourse",
                "GetIntegrationPointIDInGeneralProduct",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
