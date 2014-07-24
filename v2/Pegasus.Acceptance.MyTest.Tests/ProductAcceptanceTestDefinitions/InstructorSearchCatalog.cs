using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyTest.Tests.
    ProductAcceptanceTestDefinitions
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
        [When(@"I add TestBank from Course type ""(.*)"" course from Search Catalog")]
        public void SelectMasterCourseFromCatalog(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("InstructorSearchCatalog",
                "AddCourseFromSearchCatalog", base.isTakeScreenShotDuringEntryExit);
            //Closing the Announcement(s)
            new AnnouncementPopUpLightBoxUXPage().CloseAnnouncementPopUp();
            //Click 'Search Catalog' Link 
            new HEDGlobalHomePage().ClickSearchCatalogOption();
            //Adding TestBank Course From Instructor Search Catalog
            new CourseCatalogMainPage().AddTestBankFromSearchCatalog(courseTypeEnum);
            Logger.LogMethodExit("InstructorSearchCatalog",
                "AddCourseFromSearchCatalog", base.isTakeScreenShotDuringEntryExit);
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
                "AddProductFromSearchCatalog", base.isTakeScreenShotDuringEntryExit);
            //Closing the Announcement(s)
            new AnnouncementPopUpLightBoxUXPage().CloseAnnouncementPopUp();
            //Click 'Search Catalog' Link 
            new HEDGlobalHomePage().ClickSearchCatalogOption();
            //Adding Product From Instructor Search Catalog
            new CourseCatalogMainPage().AddProductFromSearchCatalog(productTypeEnum);
            Logger.LogMethodExit("InstructorSearchCatalog",
                "AddProductFromSearchCatalog", base.isTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("HEDGlobalHomePage", 
                "VerifyInstructorCourseOnTheGlobalHomePageInActiveState",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Course Present In Active State
            Logger.LogAssertion("VerifyCoursePresentInActiveState", 
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsFalse(new HEDGlobalHomePage().
                    IsCoursePresentInAssignedToCopyState()));
            //Store Instructor Course Id
            new HEDGlobalHomePage().StoreInstructorCourseIDInMemory(courseTypeEnum);
            Logger.LogMethodExit("HEDGlobalHomePage", 
                "VerifyInstructorCourseOnTheGlobalHomePageInActiveState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Verifies Sub tabs Under Main Tab.
        /// </summary>
        /// <param name="table">This is Table Reference.</param>
        [Then(@"I should see the following subtabs under Course Materials page")]
        [Then(@"I should see the following subtabs under Gradebook page")]
        [Then(@"I should see the following subtabs in Enrollments page")]
        public void VerifySubTabsUnderMainTab(Table table)
        {
            //Verifies Sub tabs Under Main Tab
            Logger.LogMethodEntry("InstructorSearchCatalog",
                "VerifySubTabsUnderMainTab",
                base.isTakeScreenShotDuringEntryExit);
            foreach (var tableRow in table.Rows)
            {
                //Assert correct pages are opened
                TableRow row = tableRow;
                Logger.LogAssertion("VerifySubTabsUnderMainTab", ScenarioContext.
                    Current.ScenarioInfo.Title,
                () => Assert.AreEqual(row[InstructorSearchCatalogResource.
                    InstructorSearchCatalog_WindowTitle_Text], new TeachingPlanUxPage().
                    GetTabsWindowTitle(row[InstructorSearchCatalogResource.
                    InstructorSearchCatalog_SubTabName_Text], row[InstructorSearchCatalogResource.
                    InstructorSearchCatalog_WindowTitle_Text])));
            }
            Logger.LogMethodExit("InstructorSearchCatalog", 
                "VerifySubTabsUnderMainTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Verify Tabs in Course.
        /// </summary>
        /// <param name="table">This is Table Reference</param>
        [Then(@"I should see the following tabs")]
        public void VerifyTabsInCourse(Table table)
        {
            //Verify Tabs in Course
            Logger.LogMethodEntry("InstructorSearchCatalog",
                "VerifyTabsInCourse",
                base.isTakeScreenShotDuringEntryExit);
            foreach (var tableRow in table.Rows)
            {
                //Assert correct pages are opened
                TableRow row = tableRow;
                Logger.LogAssertion("VerifyTabsInCourse", ScenarioContext.
                    Current.ScenarioInfo.Title,
                () => Assert.AreEqual(row[InstructorSearchCatalogResource.
                    InstructorSearchCatalog_WindowTitle_Text], new TeachingPlanUxPage().
                    GetTabsWindowTitle(row[InstructorSearchCatalogResource.
                    InstructorSearchCatalog_TabName_Text], row[InstructorSearchCatalogResource.
                    InstructorSearchCatalog_WindowTitle_Text])));
            }
            Logger.LogMethodExit("InstructorSearchCatalog",
                "VerifyTabsInCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Message In Search Catalog.
        /// </summary>
        /// <param name="message">This is Message</param>
        [Then(@"I should see the message ""(.*)""")]
        public void VerifyTheMessageInSearchCatalog(string message)
        {
            Logger.LogMethodEntry("InstructorSearchCatalog",
                "VerifyTheMessageInSearchCatalog",
                base.isTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyTheMessageInSearchCatalog", ScenarioContext.
                    Current.ScenarioInfo.Title,
                () => Assert.AreEqual(message,new CourseCatalogMainPage().
                    GetMessageInSearchCatalog()));
            Logger.LogMethodExit("InstructorSearchCatalog",
                "VerifyTheMessageInSearchCatalog",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Invalid Search Parameter In Search Catalog.
        /// </summary>
        /// <param name="searchParameter">This is Search Parameter</param>
        [When(@"I enter the invalid search parameter ""(.*)"" in search catalog")]
        public void EnterInvalidSearchParameterInSearchCatalog(string searchParameter)
        {
            //Enter Invalid Search Parameter In Search Catalog
            Logger.LogMethodEntry("InstructorSearchCatalog",
                 "EnterInvalidSearchParameterInSearchCatalog",
                 base.isTakeScreenShotDuringEntryExit);
            //Click 'Search Catalog' Button
            new HEDGlobalHomePage().ClickSearchCatalogOption();
            // Enter Search Parameter In Catalog
            new CourseCatalogMainPage().EnterSearchParameterInCatalog(searchParameter);
            Logger.LogMethodExit("InstructorSearchCatalog",
                "EnterInvalidSearchParameterInSearchCatalog",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Next Button.
        /// </summary>
        [When(@"I click on next button")]
        public void ClickOnNextButton()
        {
            //Click On Next Button
            Logger.LogMethodEntry("InstructorSearchCatalog",
                  "ClickOnNextButton",
                  base.isTakeScreenShotDuringEntryExit);
            //Click On Next Button
            new CourseCatalogMainPage().ClickOnNextButton();
            Logger.LogMethodExit("InstructorSearchCatalog",
               "ClickOnNextButton",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On OK Button In UpgrdePage.
        /// </summary>
        [When(@"I click on 'OK' button")]
        public void ClickOnOKButtonInUpgradePage()
        {
            //Click On OK Button In UpgrdePage
            Logger.LogMethodEntry("InstructorSearchCatalog",
                  "ClickOnOKButtonInUpgradePage",
                      base.isTakeScreenShotDuringEntryExit);
            //Click The OK Button In UpgrdePage
            new MyTestUXPage().ClickTheOkButtonInUpgradePage();
            Logger.LogMethodExit("InstructorSearchCatalog",
               "ClickOnOKButtonInUpgradePage",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enroll SMS student in course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I enroll SMS Student in ""(.*)""")]
        public void EnrollSMSStudentInCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("UserEnrollment",
                "EnrollSMSStudentInCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Assert student Help Text Window Closed
            new StudentHelpTextPage().ManageStudentHelpTextWindow();
            //Closing the Announcement(s)
            new AnnouncementPopUpLightBoxUXPage().CloseAnnouncementPopUp();
            // Click 'Enroll In a Course' Button 
            new HEDGlobalHomePage().ClickOnEnrollInCourseButton();
            // To Enroll student depending on the course
            new SelfEnrollmentPage().SmsStudentEnrolledInCourse(courseTypeEnum);
            Logger.LogMethodExit("UserEnrollment",
                "EnrollSMSStudentInCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify InstructorCourse displays in global home page.
        /// </summary>
        [Then(@"I should see enrolled InstructorCourse in Global Home Page")]
        public void DisplayOfEnrolledInstructorCourseInGlobalHomePage()
        {
            //InstructorCourse Display in Global Home Page
            Logger.LogMethodEntry("UserEnrollment",
               "DisplayOfEnrolledInstructorCourseInGlobalHomePage",
               base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.MyTestInstructorCourse);
            //Assert course displays in global home page
            Logger.LogAssertion("VerifySmsStudentEnrollInCourse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(true,
                    new HEDGlobalHomePage().GetCoursePresentInGlobalHomePage().
                    Contains(course.Name)));
            Logger.LogMethodExit("UserEnrollment",
                "DisplayOfEnrolledInstructorCourseInGlobalHomePage",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is called before execution of test.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// This function is called after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }

    }
}
