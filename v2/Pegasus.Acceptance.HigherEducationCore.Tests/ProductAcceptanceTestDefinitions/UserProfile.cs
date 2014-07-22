using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles the User Profile Page actions.
    /// </summary>
    [Binding]
    public class UserProfile : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is logger.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(UserProfile));

        /// <summary>
        /// Click On My Profile Link Option.
        /// </summary>
        ///<param name="userType">This is User type by enum.</param>
        [When(@"I click on 'My Profile' option in ""(.*)""")]
        public void ClickMyProfileLinkOption(
            User.UserTypeEnum userType)
        {
            //Click On My Profile Link Option
            Logger.LogMethodEntry("UserProfile", "ClickMyProfileLinkOption",
                base.isTakeScreenShotDuringEntryExit);  
            //Click On My Profile Link Option
            new CalendarHEDDefaultUXPage().ClickOnMyProfileLink(userType);
            Logger.LogMethodExit("UserProfile", "ClickMyProfileLinkOption",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Change the 'My Profile' settings.
        /// </summary>
        [When(@"I change the 'My Profile' settings")]
        public void ChangeTheMyProfileSettings()
        {
            //Change the My Profile Settings
            Logger.LogMethodEntry("UserProfile", "ChangeTheMyProfileSettings",
                base.isTakeScreenShotDuringEntryExit);
            //Change the User Profile Settings
            new MyAccountSettingPage().ChangeUserProfileSettings();
            Logger.LogMethodExit("UserProfile", "ChangeTheMyProfileSettings",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Edit Pearson Account.
        /// </summary>
        [When(@"I click on 'Edit Pearson Account'")]
        public void ClickOnEditPearsonAccount()
        {
            //Click On Edit Pearson Account
            Logger.LogMethodEntry("UserProfile", "ClickOnEditPearsonAccount",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Edit the Pearson Account
            new MyAccountSettingPage().ClickOnEditPearsonAccountOption();
            Logger.LogMethodExit("UserProfile", "ClickOnEditPearsonAccount",
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
