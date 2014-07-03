#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains details of Adding Questions
    /// and handling the question  creation actions.
    /// </summary>
    [Binding]
    public class CreateQuestion : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(CreateQuestion));

        /// <summary>
        /// Imports the MGM Cartridge.
        /// </summary>
        [When(@"I import the MGM cartridge")]
        public void ImportTheMGMCartridge()
        {
            //Imports the MGM Cartridge
            Logger.LogMethodEntry("CreateQuestion", "ImportTheMGMCartridge", 
                base.isTakeScreenShotDuringEntryExit);
            //Uploads the MGM cartridge Zip file
            new ImportCartridgePage().ImportMGMCartridge();
            Logger.LogMethodExit("CreateQuestion", "ImportTheMGMCartridge",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifies the Imported MGM Activity Name.
        /// </summary>
        /// <param name="activityName">This is the Activity Name.</param>
        [Then(@"I should see ""(.*)"" activity in the Content Library Frame")]
        public void DisplayOfActivityInContentLibraryFrame(string activityName)
        {
            //Verifies the MGM Activity Name
            Logger.LogMethodEntry("CreateQuestion", "DisplayOfActivityInContentLibraryFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(CreateQuestionResource.CreateQuestionResource_Activity_Name,
                    new ContentLibraryUXPage().GetAndStoreMGMTestActivity(activityName)));
            Logger.LogMethodExit("CreateQuestion", "DisplayOfActivityInContentLibraryFrame",
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
