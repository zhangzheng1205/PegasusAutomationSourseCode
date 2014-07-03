﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
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
                "SelectMasterCourseFromCatalog", base.isTakeScreenShotDuringEntryExit);
            //Closing the Announcement(s)
            new AnnouncementPopUpLightBoxUXPage().CloseAnnouncementPopUp();
            //Click 'Create a Course' Link             
            new HEDGlobalHomePage().ClickCreateaCourse();
            //Adding Course From Instructor Search Catalog
            new CourseCatalogMainPage().AddCourseFromSearchCatalog(courseTypeEnum);
            Logger.LogMethodExit("InstructorSearchCatalog",
                "SelectMasterCourseFromCatalog", base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Create Page Class Object
            HEDGlobalHomePage hedGlobalHomepage = new HEDGlobalHomePage();
            //Approves Course in Active State
            hedGlobalHomepage.ApproveCoursePresentInAssignedToCopyState();
            Logger.LogMethodExit("InstructorSearchCatalog",
                "ApproveInactiveStateOfCourseToActiveState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Course Is Present In Active State.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [Then(@"I should see ""(.*)"" on the Global Home page in Active State")]
        public void VerifyInstructorCourseOnTheGlobalHomePageInActiveState
            (Course.CourseTypeEnum courseTypeEnum)
        {
            Logger.LogMethodEntry("InstructorSearchCatalog",
                "VerifyInstructorCourseOnTheGlobalHomePageInActiveState",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Course Present In Active State
            Logger.LogAssertion("VerifyCoursePresentInActiveState",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsFalse(new HEDGlobalHomePage().
                    IsCoursePresentInAssignedToCopyState()));
            //Store Instructor Course Id
            new HEDGlobalHomePage().StoreInstructorCourseIDInMemory(courseTypeEnum);
            Logger.LogMethodExit("InstructorSearchCatalog",
                "VerifyInstructorCourseOnTheGlobalHomePageInActiveState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Product From Search Catalog.
        /// </summary>
        /// <param name="productTypeEnum">This is product Type</param>
        [When(@"I add Product type ""(.*)"" from Search Catalog")]
        public void SelectProgramTypeProductFromCatalog(
            Product.ProductTypeEnum productTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("InstructorSearchCatalog",
                "SelectProgramTypeProductFromCatalog", base.isTakeScreenShotDuringEntryExit);
            //Closing the Announcement(s)
            new AnnouncementPopUpLightBoxUXPage().CloseAnnouncementPopUp();
            //Click 'Create a Course' Link             
            new HEDGlobalHomePage().ClickCreateaCourse();
            //Adding Product From Instructor Search Catalog
            new CourseCatalogMainPage().AddProductFromSearchCatalog(productTypeEnum);
            Logger.LogMethodExit("InstructorSearchCatalog",
                "SelectProgramTypeProductFromCatalog", base.isTakeScreenShotDuringEntryExit);
        }

    }
}
