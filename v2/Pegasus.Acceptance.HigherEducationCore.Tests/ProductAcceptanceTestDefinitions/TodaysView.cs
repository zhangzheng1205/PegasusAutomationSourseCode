using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.HigherEducation.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class contains the definitions for Today's view scenarios.
    /// </summary>
    [Binding]
    public class TodaysView : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>       
        private static Logger Logger = 
            Logger.GetInstance(typeof(TodaysView));

        /// <summary>
        /// To check presen of text in given frame/page.
        /// </summary>
        /// <param name="text">Text to verify the presence.</param>
        /// <param name="page">Page where we need to sech the text.</param>
        [Then(@"I should see the ""(.*)"" and student in ""(.*)""")]
        public void ValidateThePageWithText(String text, String page)
        {
            // Check the text in given page
            Logger.LogMethodEntry("TodaysView", "ValidateThePageWithText",
                isTakeScreenShotDuringEntryExit);
            // To validate the page with given text
            Logger.LogAssertion("TodaysView", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(text, new TodaysViewUXPage().
                    ValidateThePageWithText(TodaysViewResource.TodaysView_HeaderClassName)));
            // To validate the student name
            Logger.LogAssertion("TodaysView", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(TodaysViewResource.TodaysView_ManuallyGradable_Student_Name,
                    new TodaysViewUXPage().ValidateTheStudentName(TodaysViewResource.
                    TodaysView_ManuallyGradable_Student_Name)));
            // Check the text in given page
            Logger.LogMethodExit("TodaysView", "ValidateThePageWithText",
                    isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To submit manual gradable activity.
        /// </summary>
        [When(@"I open the 'Manually Gradable' activity")]
        public void OpenActivity()
        {
            // To submit manual gradable activity
            Logger.LogMethodEntry("TodaysView", "OpenActivity",
                isTakeScreenShotDuringEntryExit);
            // Open The Manually Gradable Activity
            new TodaysViewUXPage().LaunchTheActivityHED();
            //Attempt Essay Activity
            new TodaysViewUXPage().AttemptEssayActivity(TodaysViewResource
                .TodaysView_EssayQuestion_Answer_Text_Value);
            // To submit manual gradable activity
            Logger.LogMethodExit("TodaysView", "OpenActivity",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity.
        /// </summary>
        [When(@"I submit the 'Manually Gradable' activity")]
        public void SubmitTheActivity()
        {
            // Submit the Activity
            Logger.LogMethodEntry("TodaysView", "SubmitTheActivity",
                base.isTakeScreenShotDuringEntryExit);
            // Submit the Activity
            new TodaysViewUXPage().SubmitTheActivityHED();
            // Submit the Activity
            Logger.LogMethodExit("TodaysView", "SubmitTheActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Status Of Activity.
        /// </summary>
        /// <param name="activityStatus">This is The Activity Status.</param>
        [Then(@"I should see the status of manually gradable activity as ""(.*)""")]
        public void VerifyStatusOfActivity(String activityStatus)
        {
            // Verify the Status Of Activity
            Logger.LogMethodEntry("TodaysView", "VerifyStatusOfActivity",
                base.isTakeScreenShotDuringEntryExit);
            // Assert the Activity Status
            Logger.LogAssertion("VerifyStatusOfActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityStatus, new CoursePreviewMainUXPage().
                    GetStatusOfActivity(TodaysViewResource.
                    TodaysView_ManuallyGradable_Activity_Name)));
            // Verify the Status Of Activity
            Logger.LogMethodExit("TodaysView", "VerifyStatusOfActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Manually Grade the Activity.
        /// </summary>        
        [When(@"I manually grade the activity in gradebook")]
        public void ManuallyGradeTheActivity()
        {
            // Manually Grade the Activity
            Logger.LogMethodEntry("TodaysView", "ManuallyGradeTheActivity",
                base.isTakeScreenShotDuringEntryExit);
            // Open the Activity For Grading
            new TodaysViewUXPage().OpenActivityForGradingInHED(TodaysViewResource.
                    TodaysView_ManuallyGradable_Activity_Name);
            // Comment the Activity
            new TodaysViewUXPage().EnterInstructorComments();
            // Manually Grade the Activity
            Logger.LogMethodExit("TodaysView", "ManuallyGradeTheActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on student tree view Expand icon.
        /// </summary>
        [When(@"I click on student tree view expand icon")]
        public void ClickOnExpandIcon()
        {
            // Click on student tree view Expand icon
            Logger.LogMethodEntry("TodaysView", "ClickOnExpandIcon",
                base.isTakeScreenShotDuringEntryExit);
            // Click On Expand Icon
            new TodaysViewUXPage().ClickOnExpandIcon();
            // Click on student tree view Expand icon
            Logger.LogMethodExit("TodaysView", "ClickOnExpandIcon",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To check submitted activity name.
        /// </summary>
        /// <param name="activityName">Name of the submitted activity.</param>
        [Then(@"I should see the activity name ""(.*)"" in the page")]
        public void CheckSubmittedActitvityName(String activityName)
        {
            // To check submitted activity name
            Logger.LogMethodEntry("TodaysView", "CheckSubmittedActitvityName",
                base.isTakeScreenShotDuringEntryExit);
            // TO check submitted activity existance
            Logger.LogAssertion("TodaysView", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityName, new TodaysViewUXPage().CheckSubmittedActitvityName(activityName)));
            // To check submitted activity name
            Logger.LogMethodExit("TodaysView", "CheckSubmittedActitvityName",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open the Customize Notifications pop up.
        /// </summary>
        [When(@"I click on the CUSTOMIZE button")]
        public void ClickOnTheCustomizeButton()
        {
            //Click on Customize button to Open the Customize Notifications pop up
            Logger.LogMethodEntry("TodaysView", "ClickOnTheCustomizeButton",
                base.isTakeScreenShotDuringEntryExit);
            //Open the Customize Notifications PopUp Window
            new TodaysViewUXPage().OpenCustomizeNotificationPopUp();
            Logger.LogMethodExit("TodaysView", "ClickOnTheCustomizeButton",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifies the Pop Up Opened.
        /// Verifies the Correct Pop Up Opened.
        /// </summary>
        /// <param name="popUpName">This is the pop Up Name.</param>
        [Then(@"I should be on ""(.*)"" popup Window")]
        public void ValidatePopupWindow(String popUpName)
        {
            //Verify Correct Pop Up Opened
            Logger.LogMethodEntry("CommonSteps", "ValidatePopupWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Assert We Have Correct Pop Up Window Opened
            Logger.LogAssertion("VerifyOpenedPopUpTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(popUpName, new TodaysViewUXPage().
                    GetCustomizeNotificationPopUpWindowTitle()));
            Logger.LogMethodExit("CommonSteps", "ValidatePopupWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set the channel as default.
        /// </summary>
        /// <param name="channelName">This is Channel Name.</param>
        [When(@"I select the ""(.*)"" channel as default in Default View drop down")]
        public void SelectTheChannelAsDefault(String channelName)
        {
            //To select the default channel             
            Logger.LogMethodEntry("TodaysView", "SelectTheChannelAsDefault",
                base.isTakeScreenShotDuringEntryExit);
            //Select the Default channel in drop down
            new TodaysViewUXPage().SelectTheDefaultChannel(channelName);
            Logger.LogMethodExit("TodaysView", "SelectTheChannelAsDefault",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// UnCheck the 'Notify me when student have unread instructor comments' option in Window.
        /// </summary>        
        [When(@"I uncheck the 'Notify me when student have unread instructor comments' checkbox option")]
        public void UncheckTheCheckboxOption()
        {
            // UnCheck the 'Notify me when student have unread instructor comments' option 
            Logger.LogMethodEntry("TodaysView", "UncheckTheCheckboxOption",
                base.isTakeScreenShotDuringEntryExit);
            // UnCheck the checkbox option in pop up Window
            new TodaysViewUXPage().UnCheckNotifyMeCheckboxOption();
            Logger.LogMethodExit("TodaysView", "UncheckTheCheckboxOption",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This will close the light box on click of Save and Close button.
        /// </summary>
        [When(@"I click on Save and Close button")]
        public void ClickOnSaveAndCloseButton()
        {
            //Click on Save and Close button and Close the pop up 
            Logger.LogMethodEntry("TodaysView", "ClickOnSaveAndCloseButton",
                base.isTakeScreenShotDuringEntryExit);
            //Click on Save and Close button
            new TodaysViewUXPage().ClickTheSaveAndCloseButton();
            Logger.LogMethodExit("TodaysView", "ClickOnSaveAndCloseButton",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the Unread Comments channel removed in Today's View page.
        /// </summary>
        /// <param name="channelName">This is Channel Name.</param>
        [Then(@"I should not see ""(.*)"" Channel in Today's view page")]
        public void ValidateUnreadCommentsInTodaysViewPage(String channelName)
        {
            //Verify Unread Comments channel avilable in Today's View page
            Logger.LogMethodEntry("CommonSteps", "ValidateUnreadCommentsInTodaySViewPage",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Unread Comments Present in Today's View page
            Logger.LogAssertion("VerifyUnreadCommentsChannel",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreNotEqual(channelName, new TodaysViewUXPage().
                    GetUnreadCommentsInTodaysViewPage(channelName)));
            Logger.LogMethodExit("CommonSteps", "ValidateUnreadCommentsInTodaySViewPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the Unread Comments channel avilable in Today's View page.
        /// </summary>
        /// <param name="channelName">This is Channel Name.</param>
        [Then(@"I should see ""(.*)"" Channel in Today's view page")]
        public void VerifyDisplayOfChannelInTodaysViewPage(String channelName)
        {
            //Verify Unread Comments channel avilable in Today's View page
            Logger.LogMethodEntry("CommonSteps", "VerifyDisplayOfChannelInTodaysViewPage",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Unread Comments Present in Today's View page
            Logger.LogAssertion("VerifyDisplayOfUnreadCommentsChannel",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(channelName, new TodaysViewUXPage().
                    GetUnreadCommentsInTodaysViewPage(channelName)));
            Logger.LogMethodExit("CommonSteps", "VerifyDisplayOfChannelInTodaysViewPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check the 'Notify me when student have unread instructor comments' option in Window.
        /// </summary>
        [When(@"I check the 'Notify me when student have unread instructor comments' checkbox option")]
        public void CheckTheNotifyMeCheckboxOption()
        {
            //Check the 'Notify me when student have unread instructor comments' option
            Logger.LogMethodEntry("TodaysView", "CheckTheNotifyMeCheckboxOption",
                base.isTakeScreenShotDuringEntryExit);
            //Check the checkbox option in pop up Window
            new TodaysViewUXPage().CheckNotifyMeCheckboxOption();
            Logger.LogMethodExit("TodaysView", "CheckTheNotifyMeCheckboxOption",
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
