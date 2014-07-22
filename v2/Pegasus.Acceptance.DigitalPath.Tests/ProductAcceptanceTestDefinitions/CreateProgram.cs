#region

using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains details of Create Program.
    /// </summary>
    [Binding]
    public class CreateProgram: PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(CreateProgram));

        /// <summary>
        /// This step creates Digital Path Program in Course Space.
        /// </summary>
        /// <param name="programTypeEnum">This Is program Type Enum.</param>
        [When(@"I create the ""(.*)"" Program in coursespace")]
        public void CreateTheDigitalPathProgramInCoursespace(
            Program.ProgramTypeEnum programTypeEnum)
        {
            //Create Digital Type Program
            Logger.LogMethodEntry("CreateProgram", "CreateTheDigitalPathProgramInCoursespace",
                base.isTakeScreenShotDuringEntryExit);
            //Click On New Program Link
            new ProgramManagementPage().ClickOnCreateNewProgramLink();
            //Create New Digital Path Program
            new ProgramCreatePage().CreateNewProgram(programTypeEnum);
            Logger.LogMethodExit("CreateProgram", "CreateTheDigitalPathProgramInCoursespace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Manage Programs Page.
        /// </summary>
        [Given(@"I am on the 'Manage Programs' Page")]
        [When(@"I am on the 'Manage Programs' Page")]
        public void NavigateManageProgramsPage()
        {
            //Navigate Manage Programs Page
            Logger.LogMethodEntry("CreateProgram", "NavigateManageProgramsPage",
                base.isTakeScreenShotDuringEntryExit);
            //Navigate to manage program page 
            new AdminToolPage().NavigateToManageProgramsPage();
            Logger.LogMethodExit("CreateProgram", "NavigateManageProgramsPage",
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
