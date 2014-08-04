using System;
using System.Collections.Generic;
using System.Linq;
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
                base.IsTakeScreenShotDuringEntryExit);
            //Uploads the MGM cartridge Zip file
            new ImportCartridgePage().ImportMGMCartridge();
            Logger.LogMethodExit("CreateQuestion", "ImportTheMGMCartridge",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifies the Imported MGM Activity Name.
        /// </summary>
        /// <param name="activityTable">This is the activity type enum</param>
        [Then(@"I should see  activity in the Content Library Frame")]
        [Then(@"I should see Topic (.*) Test activity in the Content Library Frame")]
        public void DisplayOfActivityInContentLibraryFrame(Table activityTable)
        {
            //Verifies the MGM Activity Name
            Logger.LogMethodEntry("CreateQuestion", "DisplayOfActivityInContentLibraryFrame",
                base.IsTakeScreenShotDuringEntryExit);
            IEnumerable<string> getActivities = activityTable.Rows.Select(o => o["ActivityType"]).ToList();
            foreach (String activities in getActivities)
            {
               // TableRow row = tableRow;
                Activity.ActivityTypeEnum activityEnum = (Activity.ActivityTypeEnum)
                    Enum.Parse(typeof(Activity.ActivityTypeEnum), activities);
                //Asserts the Activity Name
                Activity activity = Activity.Get(activityEnum);
                Logger.LogAssertion("VerifyActivityName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new ContentLibraryUXPage().GetActivityName(activityEnum)));
            }
            Logger.LogMethodExit("CreateQuestion", "DisplayOfActivityInContentLibraryFrame",
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
