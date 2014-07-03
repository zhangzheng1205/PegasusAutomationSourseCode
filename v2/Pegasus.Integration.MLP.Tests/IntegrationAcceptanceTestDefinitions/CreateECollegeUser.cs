using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MLP.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handle the ECollege user creation.
    /// </summary>
    [Binding]
    public class CreateECollegeUser : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CreateECollegeUser));

        /// <summary>
        /// Create ECollege Teacher
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I create a new ""(.*)"" user")]
        public void CreateECollegeTeacher(
            User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("CreateECollegeUser", "CreateECollegeTeacher",
                base.isTakeScreenShotDuringEntryExit);
            //Instance of ManageUserContent 
            new ManageUsersContentPage().CreateECollegeUser(userTypeEnum);
            Logger.LogMethodExit("CreateECollegeUser", "CreateECollegeTeacher",
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
