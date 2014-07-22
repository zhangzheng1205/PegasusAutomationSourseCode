using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MMND.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the actions related to 'Course Copy'/'Course Creation'
    /// </summary>
    [Binding]
    public class CreateCourse : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(CreateCourse));
        
        /// <summary>
        /// Select 'Create/Copy Course' Option
        /// </summary>
        [When(@"I select 'Create/Copy course' option")]
        public void SelectCreateCopyCourseOption()
        {
            //Select 'Create/Copy Course' Option
            Logger.LogMethodEntry("CreateCourse", "SelectCreateCopyCourseOption", 
                base.isTakeScreenShotDuringEntryExit);
            //Click on the 'Create/Copy Course' button
            new UserLayoutRootNodePage().ClickOntheCreateCopyCourseButton();
            Logger.LogMethodExit("CreateCourse", "SelectCreateCopyCourseOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Access Code Id
        /// </summary>
        [When(@"I enter the access code id")]
        public void EnterTheAccessCodeId()
        {
            //Enter The Access Code Id
            Logger.LogMethodEntry("CreateCourse", "EnterTheAccessCodeId",
                base.isTakeScreenShotDuringEntryExit);
            //Enter The Access Code
            new UserLayoutRootNodeTargetPage().EnterAccessCodeId();
            Logger.LogMethodExit("CreateCourse", "EnterTheAccessCodeId",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course From The List
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I select ""(.*)"" course from the list")]
        public void SelectCourseFromTheList(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Select Course From The List
            Logger.LogMethodEntry("CreateCourse", "SelectCourseFromTheList",
                base.isTakeScreenShotDuringEntryExit);
            //Search the Course From List
            new UserLayoutRootNodeTargetPage().SearchCourseFromList(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "SelectCourseFromTheList",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Course Details
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I create ""(.*)"" course")]
        public void CreateMMNDCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Enter The Course Details
            Logger.LogMethodEntry("CreateCourse", "CreateMMNDCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Enter The Course Details
            new UserLayoutRootNodeTargetPage().EnterCourseDetails(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "CreateMMNDCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Course Created Successfully
        /// </summary>
        [Then(@"The course should be successfully created")]
        public void CourseCreatedSuccessfully()
        {
            //Course Created Successfully
            Logger.LogMethodEntry("CreateCourse", "CourseCreatedSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
            //Assert the Course Creation
            Logger.LogAssertion("VerifyCourseCreation",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(
                    CreateCourseResource.CreateCourse_CourseCopy_Confirmation_Message, 
                    new UserLayoutRootNodeTargetPage().GetSuccessfullMessage()));
            Logger.LogMethodExit("CreateCourse", "CourseCreatedSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get CourseId Of Course
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I fetch the course id of ""(.*)"" course")]
        public void FetchCourseIdOfCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Fetch the Course Id
            Logger.LogMethodEntry("CreateCourse", "FetchCourseIdOfCourse",
               base.isTakeScreenShotDuringEntryExit);
            //Fetch the Course Id
            new UserLayoutRootNodeTargetPage().GetCourseId(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "FetchCourseIdOfCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Course
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I verify the ""(.*)"" course from processing state")]
        public void VerifyTheCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify The Course
            Logger.LogMethodEntry("CreateCourse", "VerifyTheCourse",
               base.isTakeScreenShotDuringEntryExit);
            //Verify The Course in Active state
            new UserLayoutRootNodeTargetPage().VerifyCourseInActiveState(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "VerifyTheCourse",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Section
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I verify the ""(.*)"" section from processing state")]
        public void VerifyTheSectionInActiveState(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify The Section
            Logger.LogMethodEntry("CreateCourse", "VerifyTheSectionInActiveState",
               base.isTakeScreenShotDuringEntryExit);
            //Verify The Section in Active state
            new UserLayoutRootNodeTargetPage().VerifyCourseInActiveState(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "VerifyTheSectionInActiveState",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Logout Succesfully From MMND
        /// </summary>
        [Then(@"I should see the application logout successfully")]
        public void LogoutSuccesfullyFromMMND()
        {
            //Verify The Course
            Logger.LogMethodEntry("CreateCourse", "LogoutSuccesfullyFromMMND",
               base.isTakeScreenShotDuringEntryExit);
            //Verify The Succesfully Logout From MMND
            Logger.LogAssertion("VerifySuccessfulLogout",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(
                    CreateCourseResource.CreateCourse_Logout_Confirmation_Message,
                    new MyPearsonLoginPage().GetSuccessfullyLoggedOutOfMMNDMessage()));
            Logger.LogMethodExit("CreateCourse", "LogoutSuccesfullyFromMMND",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display Of Course In Active State
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [Then(@"I should see the ""(.*)"" course in active state")]
        public void DisplayOfCourseInActiveState(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Display Of Course In Active State
            Logger.LogMethodEntry("CreateCourse", "DisplayOfCourseInActiveState",
               base.isTakeScreenShotDuringEntryExit);
            //Verify The Course In Active State
            Logger.LogAssertion("VerifyCourseInActiveState",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsFalse(
                new UserLayoutRootNodeTargetPage().IsTheCourseInActiveState(courseTypeEnum)));
            Logger.LogMethodExit("CreateCourse", "DisplayOfCourseInActiveState",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select CoOrdinate Course From The Dropdown
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I select ""(.*)"" course from the dropdown")]
        public void SelectCoOrdinateCourseFromTheDropdown(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Select CoOrdinate Course From The Dropdown
            Logger.LogMethodEntry("CreateCourse", "SelectCoOrdinateCourseFromTheDropdown",
                base.isTakeScreenShotDuringEntryExit);
            //Select the Course
            new UserLayoutRootNodeTargetPage().SelectCoOrdinateCourse(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "SelectCoOrdinateCourseFromTheDropdown",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create MMND Section
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I create ""(.*)""")]
        public void CreateMMNDSection(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Create MMND Section
            Logger.LogMethodEntry("CreateCourse", "CreateMMNDSection",
                base.isTakeScreenShotDuringEntryExit);
            //Create MMND Section
            new UserLayoutRootNodeTargetPage().CreateMMNDSection(courseTypeEnum);
            Logger.LogMethodExit("CreateCourse", "CreateMMNDSection",
                base.isTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Start New WebDriver Instance Before Scenario
        /// </summary>
        [BeforeScenario("CreateNonCoOrdinateCourse", "CreateCoOrdinateCourse", "CreateSectionCourse")]
        public static void StartIeWebDriver()
        {
            new CreateCourse().ResetWebdriver();
        }

        /// <summary>
        /// Stop WebDriver Instance after Scenario
        /// </summary>
        [AfterScenario("CreateMMNDInstructor")]
        public static void StopIeWebDriver()
        {
            new CreateCourse().WebDriverCleanUp();
        }

    }
}
