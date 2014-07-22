using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details user's in Pegasus
    /// also handles the creation of different type of user's
    /// in Pegasus for each instances.
    /// </summary>
    [Binding]
    public class CreateUser : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CreateUser));

        /// <summary>
        /// Create New User In Pegasus.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When("I create a new \"(.*)\" user")]
        public void CreateNewUser(User.UserTypeEnum userTypeEnum)
        {
            //Create Users by Type in Pegasus
            Logger.LogMethodEntry("CreateUser", "CreateNewUser",
                base.isTakeScreenShotDuringEntryExit);
            //Create New User 
            new NewUserPage().CreateNewUserInWorkSpace(userTypeEnum);
            Logger.LogMethodExit("CreateUser", "CreateNewUser",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is called before execution of test.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// This function is called after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
