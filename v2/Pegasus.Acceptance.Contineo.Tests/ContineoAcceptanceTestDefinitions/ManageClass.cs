#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.Contineo.Tests.
    ContineoAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles Manage Class Page actions.
    /// </summary>
    [Binding]
    public class ManageClass : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(ManageClass));

        /// <summary>
        /// Verify Enrolled Class In 'Overview' Tab.
        /// </summary>
        /// <param name="classTypeEnum">This is Class Type Enum.</param>
        [Then(@"I should see the Enrolled ""(.*)"" class displayed and accesible by student")]
        public void VerifyEnrolledClassInOverviewTab
            (Class.ClassTypeEnum classTypeEnum)
        {
            //Verify Enrolled Class In Overview Tab
            Logger.LogMethodEntry("ManageClass", "VerifyEnrolledClassInOverviewTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class className = Class.Get(classTypeEnum);
            //Assert Class Name
            Logger.LogAssertion("VerifyClassInOverviewTab", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(className.Name,
                    new TodaysViewUXPage().GetClassName()));
            Logger.LogMethodExit("ManageClass", "VerifyEnrolledClassInOverviewTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Class
        /// </summary>
        /// <param name="classTypeEnum">This is class Type Enum</param>
        [Then(@"I should able to see the ""(.*)"" class")]
        public void VerifyTheClass(
            Class.ClassTypeEnum classTypeEnum)
        {
            //Verify The Class
            Logger.LogMethodEntry("ManageClass", "VerifyTheClass",
               IsTakeScreenShotDuringEntryExit);
            //Get class from memory
            Class className = Class.Get(classTypeEnum);
            // Assert for classname
            Logger.LogAssertion("VerifyClassName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(className.Name,
                    new HomePage().GetDisplayClassName(className.Name)));
            Logger.LogMethodExit("ManageClass", "VerifyTheClass",
              IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// See The Welcome Message
        /// </summary>
        [Then(@"I should see the welcome message")]
        public void SeeTheWelcomeMessage()
        {
            // See The Welcome Message
            Logger.LogMethodEntry("ManageClass", "SeeTheWelcomeMessage",
                base.IsTakeScreenShotDuringEntryExit);
            // Welcome Message Should Be Displayed
            Logger.LogAssertion("VerifyTheWelcomeMessage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true,
                new WelcomeMessagesPage().IsWelcomeMessageDisplayed()));
            Logger.LogMethodExit("ManageClass", "SeeTheWelcomeMessage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close The Welcome Message Popup
        /// </summary>
        [When(@"I close the welcome message")]
        public void CloseTheWelcomeMessagePopup()
        {
            // Close The Welcome Message Popup
            Logger.LogMethodEntry("ManageClass", "CloseTheWelcomeMessagePopup",
                base.IsTakeScreenShotDuringEntryExit);
            //Close The Welcome Message LightBox
            new WelcomeMessagesPage().CloseWelcomeMessageLightBox();
            Logger.LogMethodExit("ManageClass", "CloseTheWelcomeMessagePopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// The Welcome Message Popup Should Be Closed
        /// </summary>
        [Then(@"I should see the welcome message popup closed successfully for ""(.*)""")]
        public void WelcomeMessagePopupWindow(
            User.UserTypeEnum userTypeEnum)
        {
            //The Welcome Message Popup Should Be Closed
            Logger.LogMethodEntry("ManageClass", "WelcomeMessagePopupWindow",
               base.IsTakeScreenShotDuringEntryExit);
            //Check If The Poup Is Present
            Logger.LogAssertion("VerifyIfTheWelcomeMessagePopupIsClosed",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(false, new WelcomeMessagesPage().
                    IsWelcomeMessageLightBoxPresent()));
            //Closing the Announcement(s)
            new AnnouncementPopUpLightBoxUXPage().CloseAnnouncementPopUpInDigitalPath(userTypeEnum);
            Logger.LogMethodExit("ManageClass", "WelcomeMessagePopupWindow",
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
