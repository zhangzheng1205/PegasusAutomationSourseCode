using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MGM.Tests.
    IntegrationAcceptanceTestDefinitions
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
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CreateClass));

        /// <summary>
        /// Click on Add Classes Option Link.
        /// </summary>
        [When(@"I click on the Add Classes Option")]
        public void ClickOnTheAddClassesOptionLink()
        {
            //Click on Add Classes Option
            Logger.LogMethodEntry("CreateClass", "ClickOnTheAddClassesOptionLink",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on Add Classes Option
            new ManageClassManagementPage().ClickAddClassesOptionLink();
            Logger.LogMethodExit("CreateClass", "ClickOnTheAddClassesOptionLink",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Create Class.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I create the class using ""(.*)"" course")]
        public void CreateTheClass(Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Class
            Logger.LogMethodEntry("CreateClass", "CreateTheClass",
              base.IsTakeScreenShotDuringEntryExit);
            //Get The Master Library Name Stored In Memory
            Course masterLibrary = Course.Get(courseTypeEnum);
            //Create Class
            new ClassUserControlsPage().
                CreateClassUsingMasterLibrary(masterLibrary.Name);
            Logger.LogMethodExit("CreateClass", "CreateTheClass",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Class in CourseSpace.
        /// </summary>
        /// <param name="classTypeEnum">This is Class Type Enum.</param>
        [When(@"I search ""(.*)"" class in Coursespace")]
        public void SearchClassInCoursespace(Class.ClassTypeEnum classTypeEnum)
        {
            //Search class in Course Space
            Logger.LogMethodEntry("CreateClass", "SearchClassInCoursespace",
              base.IsTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class orgClass = Class.Get(classTypeEnum);
            //Search Class
            new ManageClassManagementPage().ClassSearchInCoursespace(orgClass.Name);
            Logger.LogMethodExit("CreateClass", "SearchClassInCoursespace",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait for the Class to Copy.
        /// </summary>
        /// <param name="classTypeEnum">This is Class Type Enum.</param>
        [When(@"I wait for class ""(.*)"" to copy")]
        public void WaitForClassToCopy(Class.ClassTypeEnum classTypeEnum)
        {
            //Wait for Class to Copy
            Logger.LogMethodEntry("CreateClass", "WaitForClassToCopy",
               base.IsTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class orgClass = Class.Get(classTypeEnum);
            //Check For Class Assigned
            new ManageClassManagementPage().
                SearchClassForAssignedToCopyState(orgClass.Name);
            Logger.LogMethodExit("CreateClass", "WaitForClassToCopy",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Searched Class.
        /// </summary>
        /// <param name="classTypeEnum">This is Class Type Enum.</param>
        [Then(@"I should be able to see the searched ""(.*)"" class")]
        public void VerifySearchedClass(Class.ClassTypeEnum classTypeEnum)
        {
            Logger.LogMethodEntry("CreateClass", "VerifySearchedClass",
               base.IsTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class orgClass = Class.Get(classTypeEnum);
            // Assert Class Search
            Logger.LogAssertion("VerifyClassSearch", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(orgClass.Name,
                    new ManageClassManagementPage().GetSearchedClass()));
            Logger.LogMethodExit("CreateClass", "VerifySearchedClass",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on CmenuOption Enter Class as Teacher.
        /// </summary>
        [When(@"I click on Enter Class as Teacher cmenu option of class in coursespace")]
        public void ClickOnCmenuOptionOfClassEnterClassAsTeacher()
        {
            //Click on Cmenu option Enter Class as Teacher
            Logger.LogMethodEntry("CreateClass", "ClickOnCmenuOptionOfClassEnterClassAsTeacher",
               base.IsTakeScreenShotDuringEntryExit);
            //Click On Class Cmenu Option Enter Class As Teacher
            new ManageClassManagementPage().ClickOnClassCmenuOptionEnterClassAsTeacher();
            //Select Course window
            new ManageClassManagementPage().SelectCourseWindow();
            Logger.LogMethodExit("CreateClass", "ClickOnCmenuOptionOfClassEnterClassAsTeacher",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select and Enter Inside the Course.
        /// </summary>
        [When(@"I select the course and enter inside the course")]
        public void SelectTheCourseAndEnterInside()
        {
            //Select and Enter Inside the Course
            Logger.LogMethodEntry("CreateClass", "SelectTheCourseAndEnterInside",
               base.IsTakeScreenShotDuringEntryExit);
            //Enter Inside the Course
            new SelectClassCourseFolderPage().EnterInsideCourse();
            Logger.LogMethodExit("CreateClass", "SelectTheCourseAndEnterInside",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Default Tabs for Teacher View.
        /// </summary>
        [Then(@"I should see the default tabs for teacher view")]
        public void VerifyDefaultTabsForTeacherView()
        {
            //Verify Default Tabs for Teacher View
            Logger.LogMethodEntry("CreateClass", "VerifyDefaultTabsForTeacherView",
             base.IsTakeScreenShotDuringEntryExit);
            //Assert Teacher View tabs displayed
            Logger.LogAssertion("VerifyDefaultTabsForTeacherView", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                (true, new TodaysViewUxPage().IsTeacherViewTabsPresent()));
            Logger.LogMethodExit("CreateClass", "VerifyDefaultTabsForTeacherView",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigating Outside of Class.
        /// </summary>
        [When(@"I navigate outside of the class from ""(.*)"" window")]
        public void NavigateOutsideOfTheClass(String windowName)
        {
            //Navigate outside the class
            Logger.LogMethodEntry("CreateClass", "NavigateOutsideOfTheClass",
             base.IsTakeScreenShotDuringEntryExit);
            //Navigate Outside of the Class
            new TodaysViewUxPage().NavigateOutsideFromClass(windowName);
            Logger.LogMethodExit("CreateClass", "NavigateOutsideOfTheClass",
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
