using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains details of Create Program.
    /// </summary>
    [Binding]
    public class CreateProgram : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CreateProgram));

        /// <summary>
        /// Navigate to Manage Programs Page.
        /// </summary>
        [Given(@"I am on the 'Manage Programs' Page")]
        public void NavigateToManageProgramsPage()
        {
            //Navigate Manage Programs Page
            Logger.LogMethodEntry("CreateProgram",
                "NavigateToManageProgramsPage",
                base.isTakeScreenShotDuringEntryExit);
            //Navigate to Manage Program page 
            new AdminToolPage().NavigateToManageProgramsPage();
            Logger.LogMethodExit("CreateProgram",
                "NavigateToManageProgramsPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Create Program in Course Space.
        /// </summary>
        /// <param name="programTypeEnum">This Is Program by Type Enum.</param>
        [When(@"I create the ""(.*)"" Program in coursespace")]
        public void CreateProgramInCoursespace(
            Program.ProgramTypeEnum
            programTypeEnum)
        {
            //Create New Program
            Logger.LogMethodEntry("CreateProgram",
                "CreateProgramInCoursespace",
                base.isTakeScreenShotDuringEntryExit);
            //Click On 'Create New Program' Link
            new ProgramManagementPage().ClickOnCreateNewProgramLink();
            //Create New Program
            new ProgramCreatePage().CreateNewProgram(programTypeEnum);
            Logger.LogMethodExit("CreateProgram",
                "CreateProgramInCoursespace",
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
