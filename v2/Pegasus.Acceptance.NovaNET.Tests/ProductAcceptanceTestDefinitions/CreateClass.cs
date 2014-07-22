using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles the create class actions.
    /// </summary>
    [Binding]
    public class CreateClass : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(CreateClass));

        /// <summary>
        /// Click on Add Classes Option Link.
        /// </summary>
        [When(@"I click on the Add Classes Option")]
        public void ClickOnTheAddClassesOptionLink()
        {
            //Click on Add Classes Option
            Logger.LogMethodEntry("CreateClass", 
                "ClickOnTheAddClassesOptionLink",
               base.isTakeScreenShotDuringEntryExit);
            //Click on Add Classes Option
            new ManageClassManagementPage().ClickAddClassesOptionLink();
            Logger.LogMethodExit("CreateClass", 
                "ClickOnTheAddClassesOptionLink",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Class Using Template.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I create the class using ""(.*)"" template")]
        public void CreateClassUsingTemplate(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Class Using Template.
            Logger.LogMethodEntry("CreateClass", "CreateClassUsingTemplate",
               base.isTakeScreenShotDuringEntryExit);
            //Get the Template Name From Memory
            Course course = Course.Get(courseTypeEnum);
            //Declaration Page Class Object
            ClassUserControlsPage classUserControlsPage = new ClassUserControlsPage();
            //Create Class Using Template
            classUserControlsPage.CreateClassUsingTemplate(course.TemplateName);
            //Click the Finish Button
            classUserControlsPage.ClickTheCreateClassFinishButton();
            Logger.LogMethodExit("CreateClass", "CreateClassUsingTemplate",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Class Using MasterLibrary Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I create class using ""(.*)"" course")]
        public void CreateClassUsingMasterLibraryCourse(Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Class Using MasterLibrary Course
            Logger.LogMethodEntry("CreateClass", "CreateClassUsingMasterLibraryCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Get the Template Name From Memory
            Course course = Course.Get(courseTypeEnum);
            //Declaration Page Class Object
            ClassUserControlsPage classUserControlsPage = new ClassUserControlsPage();
            //Create Class Using Template
            classUserControlsPage.CreateClassUsingNovanetMasterLibrary(course.Name);
            Logger.LogMethodExit("CreateClass", "CreateClassUsingMasterLibraryCourse",
            base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Create Class Using Template In Global Home.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I create the class using ""(.*)"" template in Global Home")]
        public void CreateClassUsingTemplateInGlobalHome(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Class Using Template In Global Home
            Logger.LogMethodEntry("CreateClass",
                "CreateClassUsingTemplateInGlobalHome",
               base.isTakeScreenShotDuringEntryExit);
            //Get the Template Name From Memory
            Course course = Course.Get(courseTypeEnum);
            //Declaration Page Class Object
            ClassUserControlsPage classUserControlsPage = new ClassUserControlsPage();
            //Create Class Using Template
            classUserControlsPage.CreateClassUsingTemplate(course.TemplateName);
            Logger.LogMethodExit("CreateClass", 
                "CreateClassUsingTemplateInGlobalHome",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The User From Create Class Window.
        /// </summary>
        [When(@"I select the user from create class window")]
        public void SelectTheUserFromCreateClassWindow()
        {
            //Select The User From Create Class Window.
            Logger.LogMethodEntry("CreateClass",
                "SelectTheUserFromCreateClassWindow",
               base.isTakeScreenShotDuringEntryExit);
            //Declaration Page Class Object
            ClassUserControlsPage classUserControlsPage = new ClassUserControlsPage();
            //Click The 'Create New' Dropdown
            classUserControlsPage.ClickTheCreateNewDropdown();
            Logger.LogMethodExit("CreateClass",
                "SelectTheUserFromCreateClassWindow",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Class in CourseSpace.
        /// </summary>
        /// <param name="classTypeEnum">This is Class by Type Enum.</param>
        [When(@"I search ""(.*)"" class in Coursespace")]
        public void SearchClassInCoursespace(
            Class.ClassTypeEnum classTypeEnum)
        {
            //Search class in Course Space
            Logger.LogMethodEntry("CreateClass", "SearchClassInCoursespace",
              base.isTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class orgClass = Class.Get(classTypeEnum);
            //Search Class
            new ManageClassManagementPage().
                ClassSearchInCoursespace(orgClass.Name);
            Logger.LogMethodExit("CreateClass", "SearchClassInCoursespace",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Searched Class.
        /// </summary>
        /// <param name="classTypeEnum">This is Class by Type Enum.</param>
        [Then(@"I should be able to see the searched ""(.*)"" class")]
        public void VerifySearchedClass(
            Class.ClassTypeEnum classTypeEnum)
        {
            Logger.LogMethodEntry("CreateClass", "VerifySearchedClass",
               base.isTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class orgClass = Class.Get(classTypeEnum);
            // Assert Class Search
            Logger.LogAssertion("VerifyClassSearch", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(orgClass.Name,
                    new ManageClassManagementPage().GetSearchedClass()));
            Logger.LogMethodExit("CreateClass", "VerifySearchedClass",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on CmenuOption Enter Class as Teacher.
        /// </summary>
        [When(@"I click on Enter Class as Teacher cmenu option of class in coursespace")]
        public void ClickOnCmenuOptionOfClassEnterClassAsTeacher()
        {
            //Click on Cmenu option Enter Class as Teacher
            Logger.LogMethodEntry("CreateClass", 
                "ClickOnCmenuOptionOfClassEnterClassAsTeacher",
               base.isTakeScreenShotDuringEntryExit);
            //Click On Class Cmenu Option Enter Class As Teacher
            new ManageClassManagementPage().
                ClickOnClassCmenuOptionEnterClassAsTeacher();
            //Select Overview Window
            new ManageClassManagementPage().SelectOverViewWindow();
            Logger.LogMethodExit("CreateClass", 
                "ClickOnCmenuOptionOfClassEnterClassAsTeacher",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Move The Master Library to Right Frame.
        /// </summary>
        [When(@"I move the ML to right frame")]
        public void MoveMasterLibraryToRightFrame()
        {
            //Move the Master Library to Right Frame
            Logger.LogMethodEntry("CreateClass", "MoveMasterLibraryToRightFrame",
               base.isTakeScreenShotDuringEntryExit);
            //Click on Master Library CheckBox
            new CourseContentUXPage().ClickOnMasterLibraryCheckBox();
            //Click on Add Button
            new CourseContentUXPage().ClickOnAddButton();
            Logger.LogMethodExit("CreateClass", "MoveMasterLibraryToRightFrame",
           base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Wait for class to get in Available state.
        /// </summary>
        [Then(@"I wait for the class to get in available state")]
        public void GetClassInAvailableState()
        {
            //Get the CLass in Available state
            Logger.LogMethodEntry("CreateClass", "GetClassInAvailableState",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for Master Library to Copy
            new CourseContentUXPage().WaitMasterLibraryToGetInPrepareState();
            Logger.LogMethodExit("CreateClass", "GetClassInAvailableState",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Home Button.
        /// </summary>
        [When(@"I select the Home button")]
        public void SelectTheHomeButton()
        {
            //Select Home Button
            Logger.LogMethodEntry("CreateClass", "SelectTheHomeButton",
               base.isTakeScreenShotDuringEntryExit);
            //Select the Home Button
            new TodaysViewUXPage().SelectHomeButton();
            Logger.LogMethodExit("CreateClass", "SelectTheHomeButton",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait for the Class to Copy.
        /// </summary>
        /// <param name="classTypeEnum">This is Class by Type.</param>
        [When(@"I wait for class ""(.*)"" to copy")]
        public void WaitForClassToCopy(
            Class.ClassTypeEnum classTypeEnum)
        {
            //Wait for Class to Copy
            Logger.LogMethodEntry("CreateClass", "WaitForClassToCopy",
               base.isTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class orgClass = Class.Get(classTypeEnum);
            //Check For Class Assigned
            new ManageClassManagementPage().
                SearchClassForAssignedToCopyState(orgClass.Name);
            Logger.LogMethodExit("CreateClass", "WaitForClassToCopy",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Create Class Button In Global Home.
        /// </summary>
        [When(@"I click on 'Create Class' button in Global home")]
        public void ClickOnCreateClassButtonInGlobalHome()
        {
            //Click On Create Class Button In Global Home
            Logger.LogMethodEntry("CreateClass",
                "ClickOnCreateClassButtonInGlobalHome",
               base.isTakeScreenShotDuringEntryExit);
            // Click On Create Class Button In Global Home
            new MyPegasusUXPage().ClickOnCretaeClassButtonInGlobalHome();
            Logger.LogMethodExit("CreateClass",
                "ClickOnCreateClassButtonInGlobalHome",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display The Successfull Message In CreateClassPopup.
        /// </summary>
        /// <param name="successMessage">Successfull message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in Create Class Popup")]
        public void DisplayTheSuccessfullMessageInCreateClassPopup(
            string successMessage)
        {
            //Click On Create Class Button In Global Home
            Logger.LogMethodEntry("CreateClass",
                "DisplayTheSuccessfullMessageInCreateClassPopup",
               base.isTakeScreenShotDuringEntryExit);
            // Assert for Successfull message
            Logger.LogAssertion("VerifySuccessfullMesssage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(successMessage,
                    new CreateClassCoursePage().GetSuccessfullMessageFromCreateClassWindow()));
            //Click the Finish Button
            new ClassUserControlsPage().ClickTheCreateClassFinishButton();
            Logger.LogMethodExit("CreateClass",
                "DisplayTheSuccessfullMessageInCreateClassPopup",
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
