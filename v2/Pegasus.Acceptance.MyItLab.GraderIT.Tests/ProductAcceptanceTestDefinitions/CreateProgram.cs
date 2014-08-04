using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.GraderIT.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Create Program Page Actions.   
    /// </summary>
    [Binding]
    public class CreateProgram : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CreateProgram));

        /// <summary>
        /// Navigate to Manage Programs Page.
        /// </summary>
        [Given(@"I am on the 'Manage Programs' Page")]
        public void NavigateManageProgramsPage()
        {
            //Navigate to Manage Programs Page
            Logger.LogMethodEntry("CreateProgram",
                "NavigateManageProgramsPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Navigate to manage program page 
            new AdminToolPage().NavigateToManageProgramsPage();
            Logger.LogMethodExit("CreateProgram",
                "NavigateManageProgramsPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This step click on the create new program link.
        /// </summary>
        [When(@"I click on the Create New Program  Link")]
        public void ClickOnTheCreateNewProgramLink()
        {
            //Method to click on the create new program link 
            Logger.LogMethodEntry("CreateProgram", "ClickOnTheCreateNewProgramLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on new program link
            new ProgramManagementPage().ClickOnCreateNewProgramLink();
            Logger.LogMethodExit("CreateProgram", "ClickOnTheCreateNewProgramLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This step creates Hed Program in Course Space.
        /// </summary>
        /// <param name="programTypeEnum">This Is Program Type Enum.</param>
        [When(@"I create the ""(.*)"" Program in coursespace")]
        public void CreateTheHedProgramInCoursespace(
            Program.ProgramTypeEnum programTypeEnum)
        {
            //Create Hed Program
            Logger.LogMethodEntry("CreateProgram",
                "CreateTheHedProgramInCoursespace",
                base.IsTakeScreenShotDuringEntryExit);
            //Create New HED program
            new ProgramCreatePage().CreateNewProgram(programTypeEnum);
            Logger.LogMethodExit("CreateProgram",
                "CreateTheHedProgramInCoursespace",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
