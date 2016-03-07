#region
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
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
        public void CreateTheClass(
            Course.CourseTypeEnum courseTypeEnum)
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
        public void SearchClassInCoursespace(
            Class.ClassTypeEnum classTypeEnum)
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
        /// Verify Searched Class.
        /// </summary>
        /// <param name="classTypeEnum">This is Class Type Enum.</param>
        [Then(@"I should be able to see the searched ""(.*)"" class")]
        public void VerifySearchedClass(
            Class.ClassTypeEnum classTypeEnum)
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
        /// Enter as Demo Student.
        /// </summary>
        [When(@"I enter as Demo Student")]
        public void EnterAsDemoStudent()
        {
            //Enter as Demo Student
            Logger.LogMethodEntry("CreateClass", "EnterAsDemoStudent",
             base.IsTakeScreenShotDuringEntryExit);
            //Enter as Demo Student
            new TodaysViewUxPage().EnterAsDemoStudent();
            Logger.LogMethodExit("CreateClass", "EnterAsDemoStudent",
            base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class orgClass = Class.Get(classTypeEnum);
            // Assert Class Search
            Logger.LogAssertion("VerifyClassSearch", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(orgClass.Name,
                    new TodaysViewUxPage().GetClassName()));
            Logger.LogMethodExit("CreateClass", "VerifyTheClass",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Teacher View.
        /// </summary>
        [Then(@"I navigate back to Teacher view")]
        public void NavigateToTeacherView()
        {
            //Navigate to Teacher View
            Logger.LogMethodEntry("CreateClass", "NavigateToTeacherView",
             base.IsTakeScreenShotDuringEntryExit);
            //Assert Teacher View tabs displayed
            Logger.LogAssertion("VerifyNavigationOfTeacherView", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue
                (new TodaysViewUxPage().IsTeacherNavigatedBack()));
            Logger.LogMethodExit("CreateClass", "NavigateToTeacherView",
          base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
            //Navigate Outside of the Class
            new TodaysViewUxPage().NavigateOutsideFromClass(windowName);
            Logger.LogMethodExit("CreateClass", "NavigateOutsideOfTheClass",
        base.IsTakeScreenShotDuringEntryExit);
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
        /// Click on create button in Classes channel.
        /// </summary>
        [When(@"I click on Create button")]
        public void ClickOnCreateButtonInClassesChannel()
        {
            //Click on create button
            Logger.LogMethodEntry("CreateClass", "ClickOnCreateButton",
               base.IsTakeScreenShotDuringEntryExit);
            new HomePage().ClickOnCreateButton();
            Logger.LogMethodExit("CreateClass", "ClickOnCreateButton",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Digital Path teacher select class from the class selector dropdown
        /// </summary>
        /// <param name="className">This is a class type Enum.</param>
        [When(@"I select DigitalPath class ""(.*)"" from Class selector dropdown")]
        public void SelectDigitalPathClassFromClassSelectorDropdown(Class.ClassTypeEnum className)
        {
            // Select class from the dropdown
            Logger.LogMethodEntry("CreateClass", "SelectDigitalPathClassFromClassSelectorDropdown",base.IsTakeScreenShotDuringEntryExit);
            // Get the Class name from in memory
            Class classTitle = Class.Get(className);
            String classText = classTitle.Name.ToString();
            new TodaysViewUxPage().SelectClassFromClassSelectorDropdown(classText);
            Logger.LogMethodExit("CreateClass", "SelectDigitalPathClassFromClassSelectorDropdown", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter the class name.
        /// </summary>
        /// <param name="classType">Type of class.</param>
        [When(@"I enter class name of ""(.*)""")]
        public void EnterClassNameInClassCreationWizard(Class.ClassTypeEnum classType)
        {
            //Enter class name
            Logger.LogMethodEntry("CreateClass", "EnterClassNameInClassCreationWizard",
               base.IsTakeScreenShotDuringEntryExit);
            // Enter the class name in class creation wizard
            new frmSetupWizardPage().EnterClassName(classType);
            Logger.LogMethodExit("CreateClass", "EnterClassNameInClassCreationWizard",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on select product button
        /// </summary>
        [When(@"I click on Select product button")]
        public void ClickOnSelectProductButton()
        {
            //Click on select product button in class creation wizard
            Logger.LogMethodEntry("CreateClass", "ClickOnSelectProductButton",
               base.IsTakeScreenShotDuringEntryExit);
            new frmSetupWizardPage().ClickSelectProductButton();
            Logger.LogMethodExit("CreateClass", "ClickOnSelectProductButton",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the setup wizard display.
        /// </summary>
        /// <param name="pageTitle">Page title to validate.</param>
        [Then(@"I should see ""(.*)"" light box")]
        public void ValidatedisplayOfSetupWizardLightBox(string pageTitle)
        {
            /// Validate the setup wizard display
            Logger.LogMethodEntry("CreateClass", "ValidatedisplayOfSetupWizard",
               base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidatedisplayOfSetupWizard", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(pageTitle, new frmSetupWizardPage().GetSetupWizardPopUpTitle()));
            Logger.LogMethodExit("CreateClass", "ValidatedisplayOfSetupWizard",
          base.IsTakeScreenShotDuringEntryExit);
        }

       /// <summary>
        /// Validate page title in class creation wizard.
       /// </summary>
       /// <param name="pageTitle">Page title.</param>
        [Then(@"I should see ""(.*)"" page")]
        public void ValidateSelectProductPageDisplay(string pageTitle)
        {
            //Validate page title
            Logger.LogMethodEntry("CreateClass", "ValidateSelectProductPageDisplay",
              base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateSelectProductPageDisplay", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(pageTitle, new frmSetupWizardPage().GetPageTitleFromSetupWizard(pageTitle)));
            Logger.LogMethodExit("CreateClass", "ValidateSelectProductPageDisplay",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Choose the master library from select product page.
        /// </summary>
        [When(@"I select product ""(.*)"" ML")]
        public void SelectMasterLibrary(Course.CourseTypeEnum courseType)
        {
            //Select master library
            Logger.LogMethodEntry("CreateClass", "SelectMasterLibrary",
             base.IsTakeScreenShotDuringEntryExit);
            //Select master library
            Course course = Course.Get(courseType);
            new frmSetupWizardPage().SelectMasterLibrary(course.Name);
            Logger.LogMethodExit("CreateClass", "SelectMasterLibrary",
          base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I Click on Manage enrollments button")]
        public void ClickOnManageEnrollmentsButton()
        {
            //Select master library
            Logger.LogMethodEntry("CreateClass", "ClickOnManageEnrollmentsButton",
             base.IsTakeScreenShotDuringEntryExit);
            //Select master library
            new frmSetupWizardPage().ClickManageEnrollmentsButton();
            Logger.LogMethodExit("CreateClass", "ClickOnManageEnrollmentsButton",
          base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on save and exit button.
        /// </summary>
        [When(@"I click No,Save and Exit button")]
        public void ClickOnSaveAndExitButton()
        {
            //Click on save and exit button
            Logger.LogMethodEntry("CreateClass", "ClickOnSaveAndExitButton",
             base.IsTakeScreenShotDuringEntryExit);
            new frmSetupWizardPage().ClickOnSaveAndExitButton();
            Logger.LogMethodExit("CreateClass", "ClickOnSaveAndExitButton",
          base.IsTakeScreenShotDuringEntryExit);
        }

       
        /// <summary>
        /// Validate class display in classse channel.
        /// </summary>
        /// <param name="classTypeEnum">Class type enum</param>
        [Then(@"I should see ""(.*)"" class displayed in classes channel")]
        public void ValidateClassDisplayInClassesChannel(Class.ClassTypeEnum classTypeEnum)
        {
            //Validate class name
            Logger.LogMethodEntry("CreateClass", "ValidateClassDisplayInClassesChannel",
             base.IsTakeScreenShotDuringEntryExit);
            //Get class name from memory
            Class Class = Class.Get(classTypeEnum);
            string className = Class.Name.ToString();
            Logger.LogAssertion("ValidateClassDisplayInClassesChannel", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(className, new HomePage().GetDisplayClassName(className)));
            Logger.LogMethodExit("CreateClass", "ValidateClassDisplayInClassesChannel",
          base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see ""(.*)"" class for ""(.*)"" displayed in classes channel")]
        public void VerifyClassForMultipleMLDisplayedInClassesChannel(Class.ClassTypeEnum classTypeEnum,
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Validate class name
            Logger.LogMethodEntry("CreateClass", "VerifyClassForMultipleMLDisplayedInClassesChannel",
             base.IsTakeScreenShotDuringEntryExit);
            //Get class and course name from memory
            Class Class = Class.Get(classTypeEnum);
            Course Course = Course.Get(courseTypeEnum);
            string className = Class.Name + ": " + Course.Name;
            Logger.LogAssertion("ValidateClassDisplayInClassesChannel", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(className, new HomePage().GetDisplayClassName(className)));
            Logger.LogMethodExit("CreateClass", "VerifyClassForMultipleMLDisplayedInClassesChannel",
            base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should not see ""(.*)"" class for ""(.*)"" displayed in classes channel")]
        public void VerifyRemovalOfClassInClassesChannel(Class.ClassTypeEnum classTypeEnum,
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Validate class name
            Logger.LogMethodEntry("CreateClass", "VerifyRemovalOfClassInClassesChannel",
             base.IsTakeScreenShotDuringEntryExit);
            //Get class and course name from memory
            Class Class = Class.Get(classTypeEnum);
            Course Course = Course.Get(courseTypeEnum);
            string className = Class.Name + ": " + Course.Name;
            Logger.LogAssertion("ValidateClassDisplayInClassesChannel", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreNotEqual(className, new HomePage().GetDisplayClassName(className)));
            Logger.LogMethodExit("CreateClass", "VerifyRemovalOfClassInClassesChannel",
            base.IsTakeScreenShotDuringEntryExit);
        }


        [Then(@"I should see ""(.*)"" copy content class in classes channel")]
        public void ThenIShouldSeeCopyContentClassForDisplayedInClassesChannel(Class.ClassTypeEnum classTypeEnum)
        {
            //Get class name from memory
            Class Class = Class.Get(classTypeEnum);
            string copyClassName = "Copy Content - " + Class.Name;
            Logger.LogAssertion("ValidateClassDisplayInClassesChannel", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(copyClassName, new HomePage().GetDisplayClassName(copyClassName)));
        }



      
        /// <summary>
        /// Save the class.
        /// </summary>
        [When(@"I click on Save Class button")]
        public void ClickOnSaveClassButton()
        {
            //Save the class
            Logger.LogMethodEntry("CreateClass", "ClickOnSaveClassButton",
             base.IsTakeScreenShotDuringEntryExit);
            //Click on save class button
            new frmSetupWizardPage().ClickOnSaveClass();
            Logger.LogMethodExit("CreateClass", "ClickOnSaveClassButton",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate success message in class creatin wizard.
        /// </summary>
        /// <param name="successMessage">Success message to validate.</param>
        [Then(@"I should see the successfull message ""(.*)"" in setup wizard")]
        public void ValidateSuccessMessageInClassCreationWizard(string successMessage)
        {
            //Validate class creation success message
            Logger.LogMethodEntry("CreateClass", "ValidateSuccessMessageInClassCreationWizard",
             base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateSuccessMessageInClassCreationWizard", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(successMessage, new frmSetupWizardPage().GetClassCreationSuccessMessageInSetupWizard()));
            Logger.LogMethodExit("CreateClass", "ValidateSuccessMessageInClassCreationWizard",
          base.IsTakeScreenShotDuringEntryExit);

        }

        [When(@"I select the ""(.*)"" template")]
        public void SelectTheTemplate(Course.CourseTypeEnum courseTypeEnum)
        {
            //Validate class creation success message
            Logger.LogMethodEntry("CreateClass", "SelectTheTemplate",
             base.IsTakeScreenShotDuringEntryExit);
            //Fetch course name from memory
            Course course = Course.Get(courseTypeEnum);

            Logger.LogMethodExit("CreateClass", "SelectTheTemplate",
          base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I select ""(.*)"" ML in ""(.*)"" popup")]
        public void SelectMLInAddToClassPopup(Course.CourseTypeEnum courseTypeEnum, string windowName)
        {
            Logger.LogMethodEntry("CreateClass", "SelectMLInAddToClassPopup",
            base.IsTakeScreenShotDuringEntryExit);
          Course course = Course.Get(courseTypeEnum);
          new frmSetupWizardPage().
         SelectTemplateAtAddToClassPopup(course.Name);
          Logger.LogMethodExit("CreateClass", "SelectMLInAddToClassPopup",
      base.IsTakeScreenShotDuringEntryExit);
        }

       

        [When(@"I enter details for ""(.*)"" class copy")]
        public void EnterDetailsForClassCopy(Class.ClassTypeEnum classType)
        {
            Logger.LogMethodEntry("CreateClass", "EnterDetailsForClassCopy",
             base.IsTakeScreenShotDuringEntryExit);
            Class classDetails = Class.Get(classType);
            new frmSetupWizardPage().EnterCopyClassDetails(classDetails.Name);
            Logger.LogMethodExit("CreateClass", "EnterDetailsForClassCopy",
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
