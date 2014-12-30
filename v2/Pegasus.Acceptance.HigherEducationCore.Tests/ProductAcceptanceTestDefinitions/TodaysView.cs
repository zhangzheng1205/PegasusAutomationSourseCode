using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducation.WL.Tests.
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
        private static readonly Logger Logger =
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
                IsTakeScreenShotDuringEntryExit);
            // To validate the page with given text
            Logger.LogAssertion("TodaysView", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(text, new TodaysViewUxPage().
                    ValidateThePageWithText(TodaysViewResource.TodaysView_HeaderClassName)));
            // To validate the student name
            Logger.LogAssertion("TodaysView", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(TodaysViewResource.TodaysView_ManuallyGradable_Student_Name,
                    new TodaysViewUxPage().ValidateTheStudentName(TodaysViewResource.
                    TodaysView_ManuallyGradable_Student_Name)));
            // Check the text in given page
            Logger.LogMethodExit("TodaysView", "ValidateThePageWithText",
                    IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To submit manual gradable activity.
        /// </summary>
        [When(@"I open the 'Manually Gradable' activity")]
        public void OpenActivity()
        {
            // To submit manual gradable activity
            Logger.LogMethodEntry("TodaysView", "OpenActivity",
                IsTakeScreenShotDuringEntryExit);
            // Open The Manually Gradable Activity
            new TodaysViewUxPage().LaunchTheActivityHed();
            //Attempt Essay Activity
            new TodaysViewUxPage().AttemptEssayActivity(TodaysViewResource
                .TodaysView_EssayQuestion_Answer_Text_Value);
            // To submit manual gradable activity
            Logger.LogMethodExit("TodaysView", "OpenActivity",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity.
        /// </summary>
        [When(@"I submit the 'Manually Gradable' activity")]
        public void SubmitTheActivity()
        {
            // Submit the Activity
            Logger.LogMethodEntry("TodaysView", "SubmitTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            // Submit the Activity
            new TodaysViewUxPage().SubmitTheActivityHed();
            // Submit the Activity
            Logger.LogMethodExit("TodaysView", "SubmitTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            // Assert the Activity Status
            Logger.LogAssertion("VerifyStatusOfActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityStatus, new CoursePreviewMainUXPage().
                    GetStatusOfActivity(TodaysViewResource.
                    TodaysView_ManuallyGradable_Activity_Name)));
            // Verify the Status Of Activity
            Logger.LogMethodExit("TodaysView", "VerifyStatusOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Manually Grade the Activity.
        /// </summary>        
        [When(@"I manually grade the activity in gradebook")]
        public void ManuallyGradeTheActivity()
        {
            // Manually Grade the Activity
            Logger.LogMethodEntry("TodaysView", "ManuallyGradeTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            // Open the Activity For Grading
            new TodaysViewUxPage().OpenActivityForGradingInHed(TodaysViewResource.
                    TodaysView_ManuallyGradable_Activity_Name);
            // Comment the Activity
            new TodaysViewUxPage().EnterInstructorComments();
            // Manually Grade the Activity
            Logger.LogMethodExit("TodaysView", "ManuallyGradeTheActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on student tree view Expand icon.
        /// </summary>
        [When(@"I click on student tree view expand icon")]
        public void ClickOnExpandIcon()
        {
            // Click on student tree view Expand icon
            Logger.LogMethodEntry("TodaysView", "ClickOnExpandIcon",
                base.IsTakeScreenShotDuringEntryExit);
            // Click On Expand Icon
            new TodaysViewUxPage().ClickOnExpandIcon();
            // Click on student tree view Expand icon
            Logger.LogMethodExit("TodaysView", "ClickOnExpandIcon",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            // TO check submitted activity existance
            Logger.LogAssertion("TodaysView", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityName, new TodaysViewUxPage().CheckSubmittedActitvityName(activityName)));
            // To check submitted activity name
            Logger.LogMethodExit("TodaysView", "CheckSubmittedActitvityName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open the Customize Notifications pop up.
        /// </summary>
        [When(@"I click on the CUSTOMIZE button")]
        public void ClickOnTheCustomizeButton()
        {
            //Click on Customize button to Open the Customize Notifications pop up
            Logger.LogMethodEntry("TodaysView", "ClickOnTheCustomizeButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Open the Customize Notifications PopUp Window
            new TodaysViewUxPage().OpenCustomizeNotificationPopUp();
            Logger.LogMethodExit("TodaysView", "ClickOnTheCustomizeButton",
                    base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Assert We Have Correct Pop Up Window Opened
            Logger.LogAssertion("VerifyOpenedPopUpTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(popUpName, new TodaysViewUxPage().
                    GetCustomizeNotificationPopUpWindowTitle()));
            Logger.LogMethodExit("CommonSteps", "ValidatePopupWindow",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Select the Default channel in drop down
            new TodaysViewUxPage().SelectTheDefaultChannel(channelName);
            Logger.LogMethodExit("TodaysView", "SelectTheChannelAsDefault",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// UnCheck the 'Notify me when student have unread instructor comments' option in Window.
        /// </summary>        
        [When(@"I uncheck the 'Notify me when student have unread instructor comments' checkbox option")]
        public void UncheckTheCheckboxOption()
        {
            // UnCheck the 'Notify me when student have unread instructor comments' option 
            Logger.LogMethodEntry("TodaysView", "UncheckTheCheckboxOption",
                base.IsTakeScreenShotDuringEntryExit);
            // UnCheck the checkbox option in pop up Window
            new TodaysViewUxPage().UnCheckNotifyMeCheckboxOption();
            Logger.LogMethodExit("TodaysView", "UncheckTheCheckboxOption",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This will close the light box on click of Save and Close button.
        /// </summary>
        [When(@"I click on Save and Close button")]
        public void ClickOnSaveAndCloseButton()
        {
            //Click on Save and Close button and Close the pop up 
            Logger.LogMethodEntry("TodaysView", "ClickOnSaveAndCloseButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Save and Close button
            new TodaysViewUxPage().ClickTheSaveAndCloseButton();
            Logger.LogMethodExit("TodaysView", "ClickOnSaveAndCloseButton",
                 base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Unread Comments Present in Today's View page
            Logger.LogAssertion("VerifyUnreadCommentsChannel",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreNotEqual(channelName, new TodaysViewUxPage().
                    GetUnreadCommentsInTodaysViewPage(channelName)));
            Logger.LogMethodExit("CommonSteps", "ValidateUnreadCommentsInTodaySViewPage",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Unread Comments Present in Today's View page
            Logger.LogAssertion("VerifyDisplayOfUnreadCommentsChannel",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(channelName, new TodaysViewUxPage().
                    GetUnreadCommentsInTodaysViewPage(channelName)));
            Logger.LogMethodExit("CommonSteps", "VerifyDisplayOfChannelInTodaysViewPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check the 'Notify me when student have unread instructor comments' option in Window.
        /// </summary>
        [When(@"I check the 'Notify me when student have unread instructor comments' checkbox option")]
        public void CheckTheNotifyMeCheckboxOption()
        {
            //Check the 'Notify me when student have unread instructor comments' option
            Logger.LogMethodEntry("TodaysView", "CheckTheNotifyMeCheckboxOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Check the checkbox option in pop up Window
            new TodaysViewUxPage().CheckNotifyMeCheckboxOption();
            Logger.LogMethodExit("TodaysView", "CheckTheNotifyMeCheckboxOption",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Instructor Comments channel in Today's View Page.
        /// </summary>
        /// <param name="channels">Channels name.</param>
        [Then(@"I should see the ""(.*)"" channels in 'Todays view' page")]
        public void VerifyChanneslInTodaysViewPage(string channels)
        {
            //Verify Instructor Comments channel in Today's View Page
            Logger.LogMethodEntry("TodaysView", "VerifyChanneslInTodaysViewPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify Instructor Comments channel in Today's View Page
            Logger.LogAssertion("VerifyChannels",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(channels, new TodaysViewUxPage().
                    GetInstructorCommentsChannelTitle(channels)));
            Logger.LogMethodEntry("TodaysView", "VerifyChanneslInTodaysViewPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Alerts Count in Instructor Comments Channel.
        /// </summary>
        /// <param name="alertCount">Alert Count to be Validated.</param>
        /// <param name="channelName">This is channel name.</param>
        [Then(@"I should see the alert count updated as ""(.*)"" in ""(.*)"" channel")]
        public void ValidateInstructorCommentsAlertCount(int alertCount, string channelName)
        {
            // Verify Alerts Count in Instructor Comments Channel
            Logger.LogMethodEntry("TodaysView", "ValidateInstructorCommentsAlertCount",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert the alert count displayed in Instructor Comments channel
            Logger.LogAssertion("VerifyInstructorCommentsAlerts", ScenarioContext.Current.
                ScenarioInfo.Title,
                () => Assert.AreEqual(alertCount, new TodaysViewUxPage().
                    GetAlertCount(channelName)));
            Logger.LogMethodEntry("TodaysView", "ValidateInstructorCommentsAlertCount",
              base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Instructor Comments Channel Option.
        /// </summary>
        /// <param name="channelOption">This is Channel Option.</param>
        [When(@"I click on the ""(.*)"" option")]
        public void ClickOnInstructorCommentsOption(string channelOption)
        {
            //Click On Instructor Comments Channel Option
            Logger.LogMethodEntry("TodaysView", "ClickOnInstructorCommentsOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Instructor Comments channel Option
            new TodaysViewUxPage().ClickNotificationChannelOption(channelOption);
            Logger.LogMethodExit("TodaysView", "ClickOnInstructorCommentsOption",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify The Activity Name In The Instructor Comments Channel.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        [Then(@"I should see the activity ""(.*)"" in the Instructor Comments channel")]
        public void VerifyActivityNameInChannel(string activityName)
        {
            //Verify The Activity Name In The Instructor Comments Channel           
            Logger.LogMethodEntry("TodaysView", "VerifyActivityNameInChannel",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert the Activity Name In The Instructor Comments Channel 
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.Current.
                ScenarioInfo.Title,
                () => Assert.AreEqual(activityName,
                    new TodaysViewUxPage().
                    GetActivityNameOfInstructorCommentsChannel(activityName)));
            Logger.LogMethodEntry("TodaysView", "VerifyActivityNameInChannel",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Availablity of the Getting Started Channel
        /// </summary>
        /// <param name="expectedFrameTitle">This is Channel name.</param>
        [Then(@"I should see the ""(.*)"" channel")]
        public void VerifyTheChannelTitleText(string expectedFrameTitle)
        {
            //Verify Correct Frame Title
            Logger.LogMethodEntry("TodaysView", "VerifyTheChannelTitleText",
                base.IsTakeScreenShotDuringEntryExit);
            // Object Declaration
            TodaysViewUxPage ChannelTitle = new TodaysViewUxPage();
            //Assert we have correct Channel frame title
            Logger.LogAssertion("VerifyChannelTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedFrameTitle, ChannelTitle.GetChannelTitle()));
            Logger.LogMethodExit("TodaysView", "VerifyTheChannelTitleText",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Availablity of Contents inside the Getting Started Channel.
        /// </summary>
        /// <param name="gettingStartedContent">This is Getting started Content text.</param>
        [Then(@"I should see the ""(.*)"" inside the Getting started channel")]
        public void VerifyTheGettingStartedContentText(string gettingStartedContent)
        {
            //Verify Correct Contents inside the Getting Started
            Logger.LogMethodEntry("TodaysView", "GettingStartedContent",
                base.IsTakeScreenShotDuringEntryExit);
            // Object Declaration
            TodaysViewUxPage ChannelContents = new TodaysViewUxPage();
            //Assert we have correct Contents of Getting Started
            Logger.LogAssertion("VerifyChannelContentText",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(gettingStartedContent,
                    ChannelContents.GettingStartedContentText()));
            Logger.LogMethodExit("TodaysView", "VerifyTheGettingStartedContentText",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Activity Displayed In The Instructor Grading Channel
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        [Then(@"I should see the activity ""(.*)"" in the Instructor grading channel")]
        public void ActivityDisplayedInTheInstructorGradingChannel(string activityName)
        {
            //Verify Correct Contents inside the Getting Started
            Logger.LogMethodEntry("TodaysView", "GettingStartedContent",
                base.IsTakeScreenShotDuringEntryExit);
            // Object Declaration
            TodaysViewUxPage ChannelContents = new TodaysViewUxPage();
            //Assert we have correct Contents of Getting Started
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.Current.
                  ScenarioInfo.Title, () => Assert.AreEqual
                      (activityName, new TodaysViewUxPage().
                      GetActivityNameOfInstructorCommentsChannel(activityName)));
            Logger.LogMethodExit("TodaysView", "VerifyTheGettingStartedContentText",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityName"></param>
        [Then(@"I should see the ""(.*)"" activity in the Instructor grading channel")]
        public void VerifyActivityInTheInstructorGradingChannel(string activityName)
        {
            //Verify The Activity Name In The Instructor Comments Channel           
            Logger.LogMethodEntry("TodaysView", "VerifyActivityInTheInstructorGradingChannel",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert the Activity Name In The Instructor Comments Channel 
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.Current.
                ScenarioInfo.Title,
                () => Assert.AreEqual(activityName,
                    new TodaysViewUxPage().
                    GetActivityNameOfInstrucorGradingChannel(activityName)));
            Logger.LogMethodEntry("TodaysView", "VerifyActivityInTheInstructorGradingChannel",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the activity cmenu.
        /// </summary>
        /// <param name="cmenuOption">This is the cmenu option.</param>
        /// <param name="activityName">This is the activity name.</param>
        [When(@"I click on ""(.*)"" of the activity ""(.*)""")]
        public void ViewAllSubmissionOfTheActivity(string cmenuOption, string activityName)
        {
            //Click on the activity cmenu
            Logger.LogMethodEntry("TodaysView", "GettingStartedContent",
                  base.IsTakeScreenShotDuringEntryExit);
            new TodaysViewUxPage().ClickActivityCmenu(activityName);
            Logger.LogMethodExit("TodaysView", "VerifyTheGettingStartedContentText",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Perform 'Mark as read' for the activity.
        /// </summary>
        /// <param name="activityButton">This is the button name.</param>
        [When(@"I click on ""(.*)"" button displayed in the right frame")]
        public void MarkAsReadForTheActivity(string activityButton)
        {
            //Click on 'Mark as read' for the activity.
            Logger.LogMethodEntry("TodaysView", "MarkAsReadForTheActivity",
                  base.IsTakeScreenShotDuringEntryExit);
            new TodaysViewUxPage().OpenActivityDetails(activityButton);
            Logger.LogMethodExit("TodaysView", "MarkAsReadForTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }        
    }
}