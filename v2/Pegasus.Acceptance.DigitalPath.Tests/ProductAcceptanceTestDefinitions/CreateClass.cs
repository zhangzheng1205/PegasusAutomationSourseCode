#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
               base.isTakeScreenShotDuringEntryExit);
            //Click on Add Classes Option
            new ManageClassManagementPage().ClickAddClassesOptionLink();
            Logger.LogMethodExit("CreateClass", "ClickOnTheAddClassesOptionLink",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Create Class.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I create the class using ""(.*)"" course")]
        public void CreateTheClass(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Class
            Logger.LogMethodEntry("CreateClass", "CreateTheClass",
              base.isTakeScreenShotDuringEntryExit);
            //Get The Master Library Name Stored In Memory
            Course masterLibrary = Course.Get(courseTypeEnum);
            //Create Class
            new ClassUserControlsPage().
                CreateClassUsingMasterLibrary(masterLibrary.Name);
            Logger.LogMethodExit("CreateClass", "CreateTheClass",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Class in CourseSpace.
        /// </summary>
        /// <param name="classTypeEnum">This is Class Type Enum.</param>
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
            new ManageClassManagementPage().ClassSearchInCoursespace(orgClass.Name);
            Logger.LogMethodExit("CreateClass", "SearchClassInCoursespace",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Searched Class.
        /// </summary>
        /// <param name="classTypeEnum">This is Class Type Enum.</param>
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
            Logger.LogMethodEntry("CreateClass", "ClickOnCmenuOptionOfClassEnterClassAsTeacher",
               base.isTakeScreenShotDuringEntryExit);
            //Click On Class Cmenu Option Enter Class As Teacher
            new ManageClassManagementPage().ClickOnClassCmenuOptionEnterClassAsTeacher();
            //Select Course window
            new ManageClassManagementPage().SelectCourseWindow();
            Logger.LogMethodExit("CreateClass", "ClickOnCmenuOptionOfClassEnterClassAsTeacher",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select and Enter Inside the Course.
        /// </summary>
        [When(@"I select the course and enter inside the course")]
        public void SelectTheCourseAndEnterInside()
        {
            //Select and Enter Inside the Course
            Logger.LogMethodEntry("CreateClass", "SelectTheCourseAndEnterInside",
               base.isTakeScreenShotDuringEntryExit);
            //Enter Inside the Course
            new SelectClassCourseFolderPage().EnterInsideCourse();
            Logger.LogMethodExit("CreateClass", "SelectTheCourseAndEnterInside",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Default Tabs for Teacher View.
        /// </summary>
        [Then(@"I should see the default tabs for teacher view")]
        public void VerifyDefaultTabsForTeacherView()
        {
            //Verify Default Tabs for Teacher View
            Logger.LogMethodEntry("CreateClass", "VerifyDefaultTabsForTeacherView",
             base.isTakeScreenShotDuringEntryExit);
            //Assert Teacher View tabs displayed
            Logger.LogAssertion("VerifyDefaultTabsForTeacherView", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                (true, new TodaysViewUXPage().IsTeacherViewTabsPresent()));
            Logger.LogMethodExit("CreateClass", "VerifyDefaultTabsForTeacherView",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter as Demo Student.
        /// </summary>
        [When(@"I enter as Demo Student")]
        public void EnterAsDemoStudent()
        {
            //Enter as Demo Student
            Logger.LogMethodEntry("CreateClass", "EnterAsDemoStudent",
             base.isTakeScreenShotDuringEntryExit);
            //Enter as Demo Student
            new TodaysViewUXPage().EnterAsDemoStudent();
            Logger.LogMethodExit("CreateClass", "EnterAsDemoStudent",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Class Name.
        /// </summary>
        /// <param name="classTypeEnum">This is Class Type Enum.</param>
        [Then(@"I should see the ""(.*)"" class")]
        public void VerifyTheClass(
            Class.ClassTypeEnum classTypeEnum)
        {
            //Verify the Class Name
            Logger.LogMethodEntry("CreateClass", "VerifyTheClass",
             base.isTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class orgClass = Class.Get(classTypeEnum);
            // Assert Class Search
            Logger.LogAssertion("VerifyClassSearch", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(orgClass.Name,
                    new TodaysViewUXPage().GetClassName()));
            Logger.LogMethodExit("CreateClass", "VerifyTheClass",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Teacher View.
        /// </summary>
        [Then(@"I navigate back to Teacher view")]
        public void NavigateToTeacherView()
        {
            //Navigate to Teacher View
            Logger.LogMethodEntry("CreateClass", "NavigateToTeacherView",
             base.isTakeScreenShotDuringEntryExit);
            //Assert Teacher View tabs displayed
            Logger.LogAssertion("VerifyNavigationOfTeacherView", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue
                (new TodaysViewUXPage().IsTeacherNavigatedBack()));
            Logger.LogMethodExit("CreateClass", "NavigateToTeacherView",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigating Outside of Class.
        /// </summary>
        /// /// <param name="windowName">This is windowName.</param>
        [When(@"I navigate outside of the class from ""(.*)"" window")]
        public void NavigateOutsideOfTheClass(
            String windowName)
        {
            //Navigate outise the class
            Logger.LogMethodEntry("CreateClass", "NavigateOutsideOfTheClass",
             base.isTakeScreenShotDuringEntryExit);
            //Navigate Outside of the Class
            new TodaysViewUXPage().NavigateOutsideFromClass(windowName);
            Logger.LogMethodExit("CreateClass", "NavigateOutsideOfTheClass",
        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait for the Class to Copy.
        /// </summary>
        /// <param name="classTypeEnum">This is Class Type Enum.</param>
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
