using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Integration.Hed.ETextS11.Tests.IntegrationAcceptanceTestDefinitions;

namespace Pegasus.Integration.ETextS11.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class Handles launch activity page actions
    /// </summary>
    [Binding]
    public class LaunchActivity : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(LaunchActivity));

        /// <summary>
        /// Asserts the Activity Name in My Course Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is the Activity by Type.</param>
        [Then(@"I should see ""(.*)"" Activity in the MyCourse Frame")]
        public void DisplayOfActivityInMyCourseFrame(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify the Activity Name added to the My Course Frame
            Logger.LogMethodEntry("LaunchActivity", "DisplayOfActivityInMyCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Gets the Activity name from Memory
             Activity activity = Activity.Get(activityTypeEnum);   
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetActivityName(activity.Name)));
            Logger.LogMethodExit("LaunchActivity", "DisplayOfActivityInMyCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Function describles the action of clicking cmenu option for an activity.
        /// </summary>
        /// <param name="cmenuOptionName">This is the cmenu option name.</param>
        /// <param name="userTypeEnum">This is User type</param>
        [When(@"I click on ""(.*)"" cmenu option of Activity in ""(.*)""")]
        public void ClickOnCmenuOptionOfActivity(String cmenuOptionName, 
            User.UserTypeEnum userTypeEnum)
        {
            //Verify the click of Cmenu options in Content library frame for an activity
            Logger.LogMethodEntry("LaunchActivity", "ClickOnCmenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Perform Mouse Over Mouse Over Activity action
            new CourseContentUXPage().PerformMouseOverOnCMenuOptionOfActivity
                (cmenuOptionName, userTypeEnum);
            Logger.LogMethodExit("LaunchActivity", "ClickOnCmenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close eText Presentation window.
        /// </summary>
        /// <param name="windowName">This is WindowName.</param>
        [When(@"I close etext ""(.*)"" presentation window")]
        public void CloseeTextPresentationWindow(String windowName)
        {
            //Close eText Presentation Window
            Logger.LogMethodEntry("LaunchActivity", "CloseeTextPresentationWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Close eText Presentation Window
            new CourseContentUXPage().CloseETextPresentationWindow(windowName);
            Logger.LogMethodExit("LaunchActivity", "CloseeTextPresentationWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Accept the Agreement.
        /// </summary>
        [When(@"I 'Accept Agreement' as 'HedWsInstructor'")]
        public void AcceptTheAgreement()
        {
            //Accept the Agreement
            Logger.LogMethodEntry("LaunchActivity", "AcceptTheAgreement",
                base.IsTakeScreenShotDuringEntryExit);
            //Accept Agreement
            new UserConsentPage().AcceptAgreement();
            Logger.LogMethodExit("LaunchActivity", "AcceptTheAgreement",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Validation Message of eText.
        /// </summary>
        /// <param name="validationMessage">This is eText Message.</param>
        [Then(@"I should see the message ""(.*)"" for etext")]
        public void VerifyValidationMessageofeText(String validationMessage)
        {
            //Verify the Validation Message of eText
            Logger.LogMethodEntry("LaunchActivity", "VerifyValidationMessageofeText",
                base.IsTakeScreenShotDuringEntryExit);
            //Asserts the eText Messagehewsecondinstructor
            Logger.LogAssertion("VerifyeTextMessage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(validationMessage,
                    new EbookIntegrationErrorPage().GetETextMessage()));
            Logger.LogMethodExit("LaunchActivity", "VerifyValidationMessageofeText",
              base.IsTakeScreenShotDuringEntryExit);
        }
      
        /// <summary>
        /// Click The Cmenu of Activity.
        /// </summary>
        /// <param name="cmenuOption">This is cmenu option.</param>
        [When(@"I ""(.*)"" the Activity")]
        public void ClickTheCmenuofActivity(String cmenuOption)
        {
            //Click The Cmenu of Activity
            Logger.LogMethodEntry("LaunchActivity", "ClickTheCmenuofActivity"
               , base.IsTakeScreenShotDuringEntryExit);
            //Click On Cmenu of Activity
            new CourseContentUXPage().ClickOnCmenuofActivity(cmenuOption);
            Logger.LogMethodExit("LaunchActivity", "ClickTheCmenuofActivity"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Enter Section As Instructor.
        /// </summary>
        /// <param name="cMenuOption">This is Cmenu option.</param>
        [When(@"I click the ""(.*)""")]
        public void ClickTheEnterSectionAsInstructor(String cMenuOption)
        {
            //Click The Enter Section As Instructor
            Logger.LogMethodEntry("LaunchActivity", "ClickTheEnterSectionAsInstructor"
                , base.IsTakeScreenShotDuringEntryExit);
            //Click On Cmenu of Enter Section As Instructor
            new ManageTemplatePage().
                ClickOnCmenuOfSectionOrTemplate(cMenuOption);
            Logger.LogMethodExit("LaunchActivity", "ClickTheEnterSectionAsInstructor"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open The Activity As Student.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity by Type Enum.</param>
        [When(@"I open the ""(.*)"" Activity")]
        public void OpenTheActivity(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Open The Activity As Student
            Logger.LogMethodEntry("LaunchActivity", "OpenTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Launch The Activity
            new CoursePreviewMainUXPage().OpenActivity(activityTypeEnum);
            Logger.LogMethodExit("LaunchActivity", "OpenTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify eText Launch.
        /// </summary>
        [Then(@"I should see the 'etext' launched successfully")]
        public void VerifyeTextLaunch()
        {
            // Verify eText Launch
            Logger.LogMethodEntry("LaunchActivity", "VerifyeTextLaunch",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyETextURL", ScenarioContext.
          Current.ScenarioInfo.Title, () => Assert.AreEqual(
              LaunchActivityResource.LaunchActivity_Page_eTextLaunch_URL,
           new LauncheTextPage().GetLaunchedeTextURL()));
            //Verify eText Flash element
            Logger.LogAssertion("VerifyETextFlashelement", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.IsTrue
                   (new LauncheTextPage().IsETextFlashElementPresent()));
            Logger.LogMethodExit("LaunchActivity", "VerifyeTextLaunch",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Go to Student View Link In Global HomePage.
        /// </summary>
        /// <param name="goToStudentViewLink">Go to Student View Link.</param>
        [When(@"I select the ""(.*)"" link in Global Home page")]
        public void SelectTheGotoStudentViewLinkInGlobalHomePage
            (String goToStudentViewLink)
        {
            //Select The Go to Student View Link In Global HomePage
            Logger.LogMethodEntry("LaunchActivity", 
                "SelectTheGotoStudentViewLinkInGlobalHomePage",
               base.IsTakeScreenShotDuringEntryExit);
            //Click The Go to Student View Link In Global HomePage
            new CalendarDefaultUXPage().
                ClickTheGotoStudentViewLinkInGlobalHomePage(goToStudentViewLink);
            Logger.LogMethodEntry("LaunchActivity",
                "SelectTheGotoStudentViewLinkInGlobalHomePage",
                 base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
