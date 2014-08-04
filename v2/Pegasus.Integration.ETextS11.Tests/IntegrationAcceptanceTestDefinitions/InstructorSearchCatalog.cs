using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.ETextS11.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains details of Instructor Search Catalog
    /// and handles Pegasus Instructor Search Catalog Page Actions.
    /// </summary>
    [Binding]
    public class InstructorSearchCatalog : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(InstructorSearchCatalog));

        /// <summary>
        /// Add Course From Search Catalog.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I add Product Course type ""(.*)"" course from Search Catalog")]
        public void SelectMasterCourseFromCatalog(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("InstructorSearchCatalog",
                "AddCourseFromSearchCatalog", base.IsTakeScreenShotDuringEntryExit);
            //Closing the Announcement(s)
            new AnnouncementPopUpLightBoxUXPage().CloseAnnouncementPopUp();
            //Click 'Search Catalog' Link 
            new HEDGlobalHomePage().ClickSearchCatalogOption();
            //Adding Course From Instructor Search Catalog
            new CourseCatalogMainPage().AddCourseFromSearchCatalog(courseTypeEnum);
            Logger.LogMethodExit("InstructorSearchCatalog",
                "AddCourseFromSearchCatalog", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Product From Search Catalog.
        /// </summary>
        /// <param name="productTypeEnum">This is product Type Enum.</param>
        [When(@"I add Product type ""(.*)"" from Search Catalog")]
        public void SelectProgramTypeProductFromCatalog(
            Product.ProductTypeEnum productTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("InstructorSearchCatalog",
                "AddProductFromSearchCatalog", base.IsTakeScreenShotDuringEntryExit);
            //Closing the Announcement(s)
            new AnnouncementPopUpLightBoxUXPage().CloseAnnouncementPopUp();
            //Click 'Search Catalog' Link 
            new HEDGlobalHomePage().ClickSearchCatalogOption();
            //Adding Product From Instructor Search Catalog
            new CourseCatalogMainPage().AddProductFromSearchCatalog(productTypeEnum);
            Logger.LogMethodExit("InstructorSearchCatalog",
                "AddProductFromSearchCatalog", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course To Validate Inactive State To Active State.
        /// </summary>
        [When(@"I select course to validate Inactive State to Active State on Global Home page")]
        public void ApproveInactiveStateOfCourseToActiveState()
        {
            //Select Course To Validate Inactive State To Active State
            Logger.LogMethodEntry("InstructorSearchCatalog",
                "ApproveInactiveStateOfCourseToActiveState",
                base.IsTakeScreenShotDuringEntryExit);
            //Create Page Class Object
            HEDGlobalHomePage hedGlobalHomepage = new HEDGlobalHomePage();
            //Approves Course in Active State
            hedGlobalHomepage.ApproveCoursePresentInAssignedToCopyState();            
            Logger.LogMethodExit("InstructorSearchCatalog",
                "ApproveInactiveStateOfCourseToActiveState",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Course Is Present In Active State.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [Then(@"I should see ""(.*)"" on the Global Home page in Active State")]
        public void VerifyInstructorCourseOnTheGlobalHomePageInActiveState
            (Course.CourseTypeEnum courseTypeEnum)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "VerifyInstructorCourseOnTheGlobalHomePageInActiveState",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Course Present In Active State
            Logger.LogAssertion("VerifyCoursePresentInActiveState", 
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsFalse(new HEDGlobalHomePage().
                    IsCoursePresentInAssignedToCopyState()));
            //Store Instructor Course Id
            new HEDGlobalHomePage().StoreInstructorCourseIDInMemory(courseTypeEnum);
            Logger.LogMethodExit("HEDGlobalHomePage", 
                "VerifyInstructorCourseOnTheGlobalHomePageInActiveState",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

    }
}
