using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducation.WL.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles the backdoor login actions.
    /// </summary>
    [Binding]
    public class BackdoorLogin : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is static instance of logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(BackdoorLogin));

        /// <summary>
        ///Verify the Contents Displayed In Preferences Page.
        /// </summary>
        [Then(@"I should see all the backdoor signin section in the 'Preferences' page")]
        public void VerifyTheContentsDisplayedInPreferencesPage()
        {
            //Verify the Contents Displayed In Preferences Page
            Logger.LogMethodEntry("MMNDBackdoorLogin",
                "VerifyTheContentsDisplayedInPreferencesPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert the Display Of Default contents in Preference page
            Logger.LogAssertion("VerifyDisplayOfDefaultcontentsinPreferencepage",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new PublisherCustomizationPage().
                    IsBackdoorContentsDisplayedInPreferencesPage()));
            Logger.LogMethodExit("MMNDBackdoorLogin",
                "VerifyTheContentsDisplayedInPreferencesPage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Welcome Text for Backdoor Login.
        /// </summary>
        [When(@"I enter the Backdoor Welcome text")]
        public void EnterTheBackdoorWelcomeText()
        {
            //Enter The Welcome Text for Backdoor login
            Logger.LogMethodEntry("MMNDBackdoorLogin",
                "EnterTheBackdoorWelcomeText",
                base.IsTakeScreenShotDuringEntryExit);
            //Fill Welcome Text for Backdoor login
            new PublisherCustomizationPage().FillBackdoorWelcomeText();
            Logger.LogMethodExit("MMNDBackdoorLogin",
                "EnterTheBackdoorWelcomeText",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Save Button in Preference.
        /// </summary>
        [When(@"I click on the Save button")]
        public void ClickOnTheSaveButtonInPreference()
        {
            //Click On The Save Button in Preference
            Logger.LogMethodEntry("MMNDBackdoorLogin",
                "ClickOnTheSaveButtonInPreference",
                base.IsTakeScreenShotDuringEntryExit);
            //Click The Save Button In Preference tab
            new PublisherCustomizationPage().ClickTheSaveButtonInPreferenceTab();
            Logger.LogMethodExit("MMNDBackdoorLogin",
                "ClickOnTheSaveButtonInPreference",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Welcome Text Displayed In Login Page.
        /// </summary>
        [Then(@"I should see the Welcome text displayed in login page")]
        public void WelcomeTextDisplayedInLoginPage()
        {
            //Welcome Text Displayed In Login Page
            Logger.LogMethodEntry("MMNDBackdoorLogin",
                "WelcomeTextDisplayedInLoginPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert for Welcome Message Displayed In Login Page
            Logger.LogAssertion("VerifyWelcomeMessageInLoginPage",
               ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(
                   BackdoorLoginResource.
                   CreateWorkspace_Workspaces_Backdoor_LoginPage_WelocmeMessage_Text,
                   new PublisherCustomizationPage().WelcomeMessageDisplayedInLoginPage()));
            Logger.LogMethodExit("MMNDBackdoorLogin",
                "WelcomeTextDisplayedInLoginPage",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify ForgotPassword and Registration button on Global Home Page.
        /// </summary>
        [Then("I should not see the Enroll To Course and Search Catalog button on the MyCourses and TestBank channel for \"(.*)\"")]
        [Then("I should not see the Enroll To Course button on the MyCourses and TestBank channel for \"(.*)\"")]
        public void VerifyEnrollToCourseAndSearchCatalogButtonVisiblity(String userRole)
        {
            //Verify EnrollToCourse And SearchCatalog Button Visiblity
            Logger.LogMethodEntry("MMNDBackdoorLogin",
                "VerifyEnrollToCourseAndSearchCatalogButtonVisiblity",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert if buttons should not be visible on Courses channel
            Logger.LogAssertion("MMNDBackdoorLogin",
                "VerifyEnrollToCourseAndSearchCatalogButtonVisiblity",
                () => Assert.IsFalse(new HEDGlobalHomePage()
                    .IsEnrollInCourseAndSearchCatalogButtonPresent((User.UserTypeEnum)
                Enum.Parse(typeof(User.UserTypeEnum), userRole))));
            Logger.LogMethodExit("MMNDBackdoorLogin",
                "VerifyEnrollToCourseAndSearchCatalogButtonVisiblity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify MyProfile and Feedback link on Global Home Page.
        /// </summary>
        [Then("I should not see the MyProfile and Feedback link on the global home page")]
        public void VerifyFeedbackAndMyProfileLink()
        {
            //verify visibility of MyProfile and Feedback link on Global Home Page
            Logger.LogMethodEntry("MMNDBackdoorLogin", "VerifyFeedbackAndMyProfileLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert visibility of MyProfile and Feedback link on Global Home Page
            Logger.LogAssertion("MMNDBackdoorLogin",
                "VerifyFeedbackAndMyProfileLink",
                () => Assert.IsFalse(new HEDGlobalHomePage()
                    .IsFeedbackAndMyProfileLingPresent()));
            Logger.LogMethodExit("MMNDBackdoorLogin", "VerifyFeedbackAndMyProfileLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Method to verify Sign out link.
        /// </summary>
        /// <param name="linkSignOut"></param>
        [Then("I should see \"(.*)\" link")]
        public void VerifySignOutLinkPresent(String linkSignOut)
        {
            //verify presence of Sign out link
            Logger.LogMethodEntry("MMNDBackdoorLogin", "VerifySignOutLinkPresent",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Sign out link object should not be null
            Logger.LogAssertion("MMNDBackdoorLogin",
                "VerifySignOutLinkPresent",
                () => Assert.IsNotNull(new HEDGlobalHomePage()
                    .GetSignOutLink(linkSignOut)));
            Logger.LogMethodExit("MMNDBackdoorLogin", "VerifySignOutLinkPresent",
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
