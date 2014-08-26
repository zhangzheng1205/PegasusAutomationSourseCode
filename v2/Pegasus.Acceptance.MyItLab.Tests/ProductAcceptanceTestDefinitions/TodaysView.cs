using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Discussion;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public class TodaysView : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(TodaysView));

        /// <summary>
        /// Clicks on the New Grades Alert option.
        /// </summary>
        [When(@"I click New Grades alert option")]
        public void ClickNewGradesAlertOption()
        {
            //Clicking the New Grades link
            Logger.LogMethodEntry("TodaysView", "ClickNewGradesAlertOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Clicking on the New Grades Link
            new TodaysViewUXPage().ClickNewGradesOption();
            Logger.LogMethodExit("TodaysView", "ClickNewGradesAlertOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click View Submission Cmenu Option.
        /// </summary>       
        [When(@"I click the cmenu option 'ViewAllSubmissions' in student side")]
        public void ClickViewSubmissionCmenuOption()
        {
            // Click View Submission Cmenu Option
            Logger.LogMethodEntry("TodaysView", "ClickViewSubmissionCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Click The View Submission Cmenu Option
            new TodaysViewUXPage().ClickTheViewSubmissionCmenuOption();
            Logger.LogMethodEntry("TodaysView", "ClickViewSubmissionCmenuOption",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Grade in ViewSubmission Page.
        /// </summary>
        /// <param name="newGrade">This is score.</param>
        [Then(@"I should see the grade ""(.*)"" in view submission page")]
        public void VerifyTheGradeInViewSubmissionPage(String newGrade)
        {
            //Verify the Grade in ViewSubmission Page
            Logger.LogMethodEntry("TodaysView", "VerifyTheGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Edited Grade in ViewSubmission Page
            Logger.LogAssertion("VerifyGradeinViewSubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(newGrade,
                    new ViewSubmissionPage().GetSubmittedGradeInViewSubmissionPage()));
            Logger.LogMethodExit("TodaysView", "VerifyTheGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Submitted Activity Name.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="activityBehavioralModeEnum">This is Behavioral Mode Enum.</param>        
        [Then(@"I should see the successfully submitted ""(.*)"" name of behavioral mode ""(.*)""")]
        public void VerifyTheSubmittedActivityName(
            Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum activityBehavioralModeEnum)
        {
            // Verify The Submitted Activity Name
            Logger.LogMethodEntry("TodaysView", "VerifyTheSubmittedActivityName",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum, activityBehavioralModeEnum);
            //Assert Submitted Activity name present            
            Logger.LogAssertion("VerifyTheSubmittedActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new TodaysViewUXPage().GetSubmittedActivityNameByStudent()));
            Logger.LogMethodEntry("TodaysView", "VerifyTheSubmittedActivityName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Channels in Today's View Page
        /// </summary>
        /// <param name="channels">Channels</param>
        [Then(@"I should see the ""(.*)"" channels in 'Todays view' page")]
        public void VerifyChanneslInTodaysViewPage(string channels)
        {
            //Verify Channels in Today's View Page
            Logger.LogMethodEntry("TodaysView", "VerifyChanneslInTodaysViewPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify Channels in Today's View Page
            Logger.LogAssertion("VerifyChannels",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(channels, new TodaysViewUXPage().GetNotificationsChannelTitle()));
            Logger.LogMethodEntry("TodaysView", "VerifyChanneslInTodaysViewPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Alerts in Notification Channel.
        /// </summary>
        /// <param name="alertcount">Alert Count to be Validated.</param>
        [Then(@"I should see the alert count updated as ""(.*)"" in ""(.*)"" channel")]
        public void ValidateUnreadMessageAlertCount(int alertCount, string channelName)
        {
            //Verify Alert count in Unread Messages Notification channel
            Logger.LogMethodEntry("TodaysView", "ValidateUnreadMessageAlertCount",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert the alert count displayed in Unread Messages channel
            Logger.LogAssertion("VerifyUnreadMessageAlerts", ScenarioContext.Current.
                ScenarioInfo.Title,
                () => Assert.AreEqual(alertCount, new TodaysViewUXPage().GetAlertCount(channelName)));
            Logger.LogMethodEntry("TodaysView", "ValidateUnreadMessageAlertCount",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the content count in alert channel.
        /// </summary>
        /// <param name="activityCount">Activity count.</param>
        /// <param name="channelName">Channel name from which the count should be retrieved.</param>
        [Then(@"I should see ""(.*)"" activity in the ""(.*)"" channel")]
        public void ValidateActivityCountInNotPassedChannel(int activityCount, string channelName)
        {
            //Click on Back navigation link
            Logger.LogMethodEntry("TodaysView", "ValidateActivityCountInNotPassedChannel",
                base.IsTakeScreenShotDuringEntryExit);
            //Validate the activity count displayed in Not passed channel
            Logger.LogAssertion("ValidateActivityCountInNotPassedChannel", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityCount,
                    new TodaysViewUXPage().GetCountFromAlertChannels(channelName)));
            Logger.LogMethodExit("TodaysView", "ValidateActivityCountInNotPassedChannel",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Notification Channel Option.
        /// </summary>
        /// <param name="channelOption">This is Channel Option.</param>
        [When(@"I click on the ""(.*)"" option")]
        public void ClickOnAlertChannelOption(string channelOption)
        {
            //Click On Notification Channel Option
            Logger.LogMethodEntry("TodaysView", "ClickOnNotificationChannelOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Performance channel Option
            new TodaysViewUXPage().ClickonNotificationChannelOption(channelOption);
            Logger.LogMethodExit("TodaysView", "ClickOnNotificationChannelOption",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Expand the student name in
        /// Past due submitted alert channel.
        /// </summary>
        [When(@"I click on the expand icon of student")]
        public void ExpandStudentNameinPastDueSubmittedChannel()
        {
            //Exapnd Student name to view past due submitted activity
            Logger.LogMethodEntry("TodaysView", "ExpandStudentNameinPastDueSubmittedChannel",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Expand icon displayed for student name
            new TodaysViewUXPage().ClickonExpandIconInPastDueSubmittedChannel();
            Logger.LogMethodExit("TodaysView", "ExpandStudentNameinPastDueSubmittedChannel",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the Past due submitted activity name.
        /// </summary>
        /// <param name="activityName">Activity name to be verified</param>
        [Then(@"I should see the activity name ""(.*)""")]
        public void ValidateActivityNameInPastDueSubmittedChannel(string activityName)
        {
            //Validate the past due submitted activity name
            Logger.LogMethodEntry("TodaysView", "ValidateActivityNameInPastDueSubmittedChannel",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert the activity name displayed in the Past due submitted channel
            Logger.LogAssertion("ValidateActivityNameInPastDueSubmittedChannel",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(activityName, new TodaysViewUXPage().GetActivityNameInPastDueSubmittedChannel()));
            Logger.LogMethodExit("TodaysView", "ValidateActivityNameInPastDueSubmittedChannel",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of student 
        /// first, last name in Past due submitted channel
        /// </summary>
        /// <param name="studentName">Student first,</param>
        [Then(@"I should see student First, Last name ""(.*)"" in Past Due: Submitted channel")]
        public void ValidateStudentNameInPastDueSubmittedChannel(string studentName)
        {

            //Click on Back navigation link
            Logger.LogMethodEntry("TodaysView", "ValidateStudentNameInPastDueSubmittedChannel",
                base.IsTakeScreenShotDuringEntryExit);
            //Validate student first, last name in past due submitted channel
            Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", ScenarioContext.Current
                .ScenarioInfo.Title, () => Assert.AreEqual(studentName, new
                    TodaysViewUXPage().GetStudentNameFromPastDueSubmittedChannel()));
            Logger.LogMethodExit("TodaysView", "ValidateStudentNameInPastDueSubmittedChannel",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on cmenu icon of Discussion topic.
        /// </summary>
        /// <param name="activityName">Discussion topic name.</param>
        [When(@"I click on cmenu icon of Discussion topic ""(.*)""")]
        public void AccesCmenuOptionOfDiscussionTopic(string discussionTopicName)
        {
            //Click On Cmenu icon of discussion topic
            Logger.LogMethodEntry("TodaysView", "ClickonCmenuOptionOfDiscussionTopic",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the cmenu icon of discussion topic in unread discussions alert channel
            new TodaysViewUXPage().ClickOnCmenuIconOfDiscussionTopic(discussionTopicName);
            Logger.LogMethodExit("TodaysView", "ClickonCmenuOptionOfDiscussionTopic",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Validate display of discussion frame
        ///in DiscussionMainUX page.
        /// </summary>
        /// <param name="discussionFrameTitle">Discussion frame title.</param>
        [Then(@"I should see the ""(.*)"" frame")]
        public void ValidateDisplayofDiscussionFrame(string discussionFrameTitle)
        {
            //Validate the display of Discussion frame in DiscussionMainUX page
            Logger.LogMethodEntry("TodaysView", "SelectMyProgressOption",
             base.IsTakeScreenShotDuringEntryExit);
            //Assert the discussion frame title from the DiscussionMainUX page
            Logger.LogAssertion("ValidateDisplayofDiscussionFrame", ScenarioContext.Current.ScenarioInfo.Title, ()
                => Assert.AreEqual(discussionFrameTitle, new DiscussionMainUXPage().GetDiscussionFrameTitle()));
            Logger.LogMethodExit("TodaysView", "ValidateDisplayofDiscussionFrame",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate overall grade displayed in 
        /// Student performance channel.
        /// </summary>
        /// <param name="Grade">Overall Grade.</param>
        [Then(@"I should see ""(.*)"" as overall Grade in ""(.*)"" alert channel")]
        public void ValidateGradeInStudentPerformanceChannel(string Grade, string channelName)
        {
            //Click On Notification Channel Option
            Logger.LogMethodEntry("TodaysView", "ValidateGradeInStudentPerformanceChannel",
                base.IsTakeScreenShotDuringEntryExit);
            //Validate overall grade in student performance channel
            Logger.LogAssertion("ValidateGradeInStudentPerformanceChannel", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(Grade, new TodaysViewUXPage().GetGradeFromStudentPerformanceChannel(channelName)));
            Logger.LogMethodExit("TodaysView", "ValidateGradeInStudentPerformanceChannel",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Validate the number of activity
        /// displayed in Past Due: Not submitted channel.
        /// </summary>
        /// <param name="activityCount">Past due not submitted activity count.</param>
        [Then(@"I should see ""(.*)"" activity in the Past Due: Not Submitted channel")]
        public void ValidateActivityCountInPastDueNotSubmittedChannel(int activityCount)
        {
            //Click on Back navigation link
            Logger.LogMethodEntry("TodaysView", "ValidateActivityCountInPastDueNotSubmittedChannel",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateActivityCountInPastDueNotSubmittedChannel", ScenarioContext.Current
                .ScenarioInfo.Title, () => Assert.AreEqual(activityCount,
                    new TodaysViewUXPage().GetActivityCountFromPastDueNotSubmittedChannel()));
            Logger.LogMethodExit("TodaysView", "ValidateActivityCountInPastDueNotSubmittedChannel",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the idle student name.
        /// </summary>
        /// <param name="Count">Number of idle students.</param>
        /// <param name="StudentName">Idle student first, last name.</param>
        /// <param name="channelName"></param>
        [Then(@"I should see ""(.*)"" Idle Student ""(.*)"" in ""(.*)"" channel")]
        public void ValidateIdleStudentName(int Count, string StudentName, string channelName)
        {
            //Verify Alert count in Idle Students Notification channel
            Logger.LogMethodEntry("TodaysView", "ValidateUnreadMessageAlertCount",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert the alert count displayed in Idle Students channel
            Logger.LogAssertion("VerifyUnreadMessageAlerts", ScenarioContext.Current.
                ScenarioInfo.Title,
                () => Assert.AreEqual(Count, new TodaysViewUXPage().GetCountFromAlertChannels(channelName)));
            //Assert the idle student name
            Logger.LogAssertion("VerifyUnreadMessageAlerts", ScenarioContext.Current.
                ScenarioInfo.Title,
                () => Assert.AreEqual(StudentName, new TodaysViewUXPage().GetStudentNameFromIdleStudents()));
            Logger.LogMethodEntry("TodaysView", "ValidateUnreadMessageAlertCount",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Verifies Sub tabs Under Main Tab.
        /// </summary>
        /// <param name="table">This is Table Reference.</param>
        [Then(@"I should see the following subtabs under Course Materials page")]
        [Then(@"I should see the following subtabs under Gradebook page")]
        [Then(@"I should see the following subtabs in Enrollments page")]
        [Then(@"I should see the following subtabs under Communicate page")]
        public void VerifySubTabsUnderMainTab(Table table)
        {
            //Verifies Sub tabs Under Main Tab
            Logger.LogMethodEntry("TodaysView", "VerifySubTabsUnderMainTab",
                base.IsTakeScreenShotDuringEntryExit);
            foreach (var tableRow in table.Rows)
            {
                //Assert correct pages are opened
                TableRow row = tableRow;
                Logger.LogAssertion("VerifySubTabsUnderMainTab", ScenarioContext.
                    Current.ScenarioInfo.Title,
                () => Assert.AreEqual(row[TodaysViewResource.
                    TodaysViewResource_WindowTitle_Text], new Pages.UI_Pages.TeachingPlanUxPage().
                    GetTabsWindowTitle(row[TodaysViewResource.
                    TodaysViewResource_SubTabName_Text], row[TodaysViewResource.
                    TodaysViewResource_WindowTitle_Text])));
            }
            Logger.LogMethodExit("TodaysView", "VerifySubTabsUnderMainTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Displays alert for New Grades.
        /// </summary>
        [Then(@"I should successfully see the alert for New Grades")]
        public void DisplayAlertForNewGrades()
        {
            //Displaying the Alert for New Grades
            Logger.LogMethodEntry("TodaysView", "DisplayAlertForNewGrades",
                base.IsTakeScreenShotDuringEntryExit);
            //Asserts if New Grades alerts are displayed
            Logger.LogAssertion("VerifyDisplayOfNewGrades",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreNotEqual(TodaysViewResource.
                    TodaysViewResource_NewGrade_Value,
                    new TodaysViewUXPage().GetNewGradesAlert()));
            Logger.LogMethodExit("TodaysView", "DisplayAlertForNewGrades",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on cmenu icon of the response posted
        /// for the discussion topic.
        /// </summary>
        /// <param name="postName">Name of the response posted.</param>
        [When(@"I click on cmenu of response ""(.*)"" posted")]
        public void ClickonCmenuIconOfResponse(string postName)
        {
            //Displaying the Alert for New Grades
            Logger.LogMethodEntry("TodaysView", "ClickonCmenuIconOfResponse",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the cmenu icon of the response posted for discussion topic
            new DiscussionMainUXPage().ClickOnCmenuOfResponse(postName);
            Logger.LogMethodExit("TodaysView", "ClickonCmenuIconOfResponse",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the cmenu option of the response posted.
        /// </summary>
        /// <param name="cmenuOption">Cmenu option to be selected.</param>
        [When(@"I select the cmenu option ""(.*)"" of the response posted")]
        public void ClickOnCmenuOptionOftheResponse(string cmenuOption)
        {
            //Click on the cmenu option of the response posted
            Logger.LogMethodEntry("TodaysView", "ClickOnCmenuOptionOftheResponse",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the cmenu option of the response posted for the discussion topic
            new DiscussionMainUXPage().SelectCmenuOption(cmenuOption);
            Logger.LogMethodExit("TodaysView", "ClickOnCmenuOptionOftheResponse",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to Last opened pop up.
        /// </summary>
        [When(@"I switch to ReadResponse pop up")]
        public void SwitchToPopUp()
        {

            //Switch to pop up
            Logger.LogMethodEntry("TodaysView", "SwitchToPopUp",
                base.IsTakeScreenShotDuringEntryExit);
            //Switch to the Last opened pop up.
            new DiscussionMainUXPage().SwitchToPopUp();
            Logger.LogMethodExit("TodaysView", "SwitchToPopUp",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Close button 
        /// in Read response pop up.
        /// </summary>
        [When(@"I click on the close button in ReadResponse pop up")]
        public void ClickOnCloseButtonInReadResponsePopUp()
        {
            //Click on Close button in read response pop up
            Logger.LogMethodEntry("TodaysView", "ClickOnCloseButtonInReadResponsePopUp",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Close button 
            new DiscussionMainUXPage().ClickOnCloseButtonInReadResponsePopUp();
            Logger.LogMethodEntry("TodaysView", "ClickOnCloseButtonInReadResponsePopUp",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Cance button in
        /// Discussion page
        /// </summary>
        [When(@"I click on cancel button in Discussion Page")]
        public void ClickonCancelButtonInDiscussionPage()
        {
            //Click on Close button in read response pop up
            Logger.LogMethodEntry("TodaysView", "ClickonCancelButtonInDiscussionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on cancel button
            new DiscussionMainUXPage().ClickOnCancelButton();
            Logger.LogMethodEntry("TodaysView", "ClickonCancelButtonInDiscussionPage",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Resource Tool From 'Tools' Dropdown.
        /// </summary>
        /// <param name="resourceToolName">This is Resource Tool Name.</param>
        [When(@"I select ""(.*)"" resource tool from 'Tools' dropdown")]
        public void SelectResourceToolFromDropdown(string resourceToolName)
        {
            //Select Resource Tool From 'Tools' Dropdown
            Logger.LogMethodEntry("TodaysView", "SelectResourceToolFromDropdown",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Resource Tool From 'Tools' Dropdown            
            new TodaysViewUXPage().SelectResourceToolFromToolsDropdown
               ((TodaysViewUXPage.ResourceToolsTypeEnum)Enum.Parse
               (typeof(TodaysViewUXPage.ResourceToolsTypeEnum), resourceToolName));
            Logger.LogMethodExit("TodaysView", "SelectResourceToolFromDropdown",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'My Progress' Option
        /// </summary>
        [When(@"I select 'My Progress' option")]
        public void SelectMyProgressOption()
        {
            //Select My Progress Option
            Logger.LogMethodEntry("TodaysView", "SelectMyProgressOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Select My Progress option
            new TodaysViewUXPage().SelectMyProgressOption();
            Logger.LogMethodExit("TodaysView", "SelectMyProgressOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Option of Activity
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        [When(@"I click on cmenu option of activity ""(.*)""")]
        public void ClickOnCmenuOptionOfActivity(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu Option of Activity
            Logger.LogMethodEntry("TodaysView", "ClickOnCmenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            new TodaysViewUXPage().ClickOnCmenuOptionOfAsset(activity.Name);
            Logger.LogMethodExit("TodaysView", "ClickOnCmenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I select the cmenu option ""(.*)"" of the activity")]
        public void SelectCmenuOfTheActivity(string cmenuOption)
        {
            Logger.LogMethodEntry("TodaysView", "SelectMyProgressOption",
             base.IsTakeScreenShotDuringEntryExit);
            new TodaysViewUXPage().SelectCmenuOption(cmenuOption);
            Logger.LogMethodExit("TodaysView", "SelectMyProgressOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify 'Verb Chart' Tool Launched Successfully.
        /// </summary>
        [Then(@"I should see the 'Verb Chart' tool launched successfully")]
        public void VerifyVerbChartToolLaunchedSuccessfully()
        {
            //Verify 'Verb Chart' Tool Launched Successfully
            Logger.LogMethodEntry("TodaysView",
                "VerifyVerbChartToolLaunchedSuccessfully",
             base.IsTakeScreenShotDuringEntryExit);
            //Asserts to Verify 'Verb Chart' Tool Launched Successfully
            Logger.LogAssertion("VerifyVerbChartToolLaunchedSuccessfully",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(TodaysViewResource.
                    TodaysViewResource_VerbChart_Label_Text,
                    new VerbChartUXPage().GetVerbChartLabel()));
            Logger.LogMethodExit("TodaysView",
                "VerifyVerbChartToolLaunchedSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
        }      

    }
}
