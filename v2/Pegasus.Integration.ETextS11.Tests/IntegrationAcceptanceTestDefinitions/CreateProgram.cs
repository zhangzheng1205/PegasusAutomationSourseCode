using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.ETextS11.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class responsible to create Program Creation
    /// also responsible to create program in different Pegausus
    /// product.
    /// </summary>
    [Binding]
    public class CreateProgram : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(CreateProgram));

        /// <summary>
        /// This step click on the create new program link.
        /// </summary>
        [When(@"I click on the Create New Program  Link")]
        public void ClickOnTheCreateNewProgramLink()
        {
            //Method to click on the create new program link 
            Logger.LogMethodEntry("CreateProgram",
                "ClickOnTheCreateNewProgramLink",
                base.isTakeScreenShotDuringEntryExit);
            //Click on new program link
            new ProgramManagementPage().ClickOnCreateNewProgramLink();
            Logger.LogMethodExit("CreateProgram", 
                "ClickOnTheCreateNewProgramLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This step creates Hed Core Program in Course Space.
        /// </summary>
        /// <param name="programTypeEnum">This Is Program Type Enum.</param>
        [When(@"I create the ""(.*)"" Program in coursespace")]
        public void CreateTheHedProgramInCoursespace(
            Program.ProgramTypeEnum programTypeEnum)
        {
            //Create Hed Program
            Logger.LogMethodEntry("CreateProgram", 
                "CreateTheHedProgramInCoursespace",
                base.isTakeScreenShotDuringEntryExit);
            //New HED Core program create
            new ProgramCreatePage().CreateNewProgram(programTypeEnum);
            Logger.LogMethodExit("CreateProgram", 
                "CreateTheHedProgramInCoursespace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Manage Programs Page.
        /// </summary>
        [Given(@"I am on the 'Manage Programs' Page")]
        public void NavigateManageProgramsPage()
        {
            //Navigate Manage Programs Page
            Logger.LogMethodEntry("CreateProgram", 
                "NavigateManageProgramsPage",
                base.isTakeScreenShotDuringEntryExit);
            //Navigate to manage program page 
            new AdminToolPage().NavigateToManageProgramsPage();
            Logger.LogMethodExit("CreateProgram", 
                "NavigateManageProgramsPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

    }
}
