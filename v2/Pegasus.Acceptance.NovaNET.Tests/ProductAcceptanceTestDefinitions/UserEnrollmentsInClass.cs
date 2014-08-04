using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles the User Enrollments Actions.
    /// </summary>
    [Binding]
    public class UserEnrollmentsInClass : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(UserEnrollmentsInClass));

        /// <summary>
        /// Select Template Class.
        /// </summary>
        /// <param name="classTypeEnum">This is class type enum.</param>
        [When(@"I enter in to ""(.*)"" class")]
        public void EnterInToTheTemplateClass(Class.ClassTypeEnum 
            classTypeEnum)
        {
            //Select Template Class
            Logger.LogMethodEntry("UserEnrollmentsInClass", 
                "EnterInToTheTemplateClass",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the Class Name Stored in Memory
             Class className = Class.Get(classTypeEnum);
            //Enter in to Template Class
            new MyPegasusUXPage().EnterInToTemplateClass(className.Name);
            Logger.LogMethodExit("UserEnrollmentsInClass", 
                "EnterInToTheTemplateClass",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Roaster in Preferences Tab.
        /// </summary>
        [When(@"I enable roster in Preferences tab")]
        public void EnableRoasterInPreferencesTab()
        {
            //Enable Roaster in Preferences Tab
            Logger.LogMethodEntry("UserEnrollmentsInClass", 
                "EnableRoasterInPreferencesTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Roster Preference
            new GeneralPreferencesPage().ClickonRosterPreference();
            //Enable Roster Preference
            new RosterPreferencesPage().EnableRosterPreference();
            Logger.LogMethodExit("UserEnrollmentsInClass", 
                "EnableRoasterInPreferencesTab",
                base.IsTakeScreenShotDuringEntryExit);            
        }

        /// <summary>
        /// Create User as Coursespace Teacher.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I create ""(.*)"" user as coursespace teacher")]
        public void CreateUserAsCoursespaceTeacher(
            User.UserTypeEnum userTypeEnum)
        {
            //Create the User
            Logger.LogMethodEntry("UserEnrollmentsInClass", 
                "CreateUserAsCoursespaceTeacher",
                 base.IsTakeScreenShotDuringEntryExit);
            //Click on Create New Button to Create User
            new GBRosterGridUXPage().ClickonCreateNewButtonToCreateUser();
            //Create New User
            new AddUserPage().CreateNewUser(userTypeEnum);
            Logger.LogMethodExit("UserEnrollmentsInClass", 
                "CreateUserAsCoursespaceTeacher",
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
