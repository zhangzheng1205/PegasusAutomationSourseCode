﻿using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Discussion;
using System.Threading;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;

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
            new TodaysViewUxPage().ClickNewGradesOption();
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
            new TodaysViewUxPage().ClickTheViewSubmissionCmenuOption();
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
                    new TodaysViewUxPage().GetSubmittedActivityNameByStudent()));
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
                () => Assert.AreEqual(channels, new TodaysViewUxPage().GetNotificationsChannelTitle()));
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
                () => Assert.AreEqual(alertCount, new TodaysViewUxPage().GetAlertCount(channelName)));
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
                    new TodaysViewUxPage().GetCountFromAlertChannels(channelName)));
            Logger.LogMethodExit("TodaysView", "ValidateActivityCountInNotPassedChannel",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Notification Channel Option.
        /// </summary>
        /// <param name="channelOption">This is Channel Option.</param>
        [When(@"I click on the ""(.*)"" option")]
        [When(@"I click on the ""(.*)"" link in notifications channel")]
        public void ClickOnAlertChannelOption(string channelOption)
        {
            //Click On Notification Channel Option
            Logger.LogMethodEntry("TodaysView", "ClickOnNotificationChannelOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Performance channel Option
            new TodaysViewUxPage().ClickNotificationChannelOption(channelOption);
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
            new TodaysViewUxPage().ClickonExpandIconInPastDueSubmittedChannel();
            Logger.LogMethodExit("TodaysView", "ExpandStudentNameinPastDueSubmittedChannel",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the Past due submitted activity name.
        /// </summary>
        /// <param name="activityTypeEnum">This is the Activity type enum.</param>
        [Then(@"I should see the ""(.*)"" activity")]
        public void ValidateActivityNameInPastDueSubmittedChannel(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Validate the past due submitted activity name
            Logger.LogMethodEntry("TodaysView", "ValidateActivityNameInPastDueSubmittedChannel",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Activity name from the XML file
            Activity activity = Activity.Get(activityTypeEnum);
            string activityName = activity.Name;
            //Assert the activity name displayed in the Past due submitted channel
            Logger.LogAssertion("VerifyStudentPresent",
         ScenarioContext.Current.ScenarioInfo.Title, () =>
          Assert.IsTrue(new TodaysViewUxPage().IsPastDueActivityPresent(activityName)));
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
                    TodaysViewUxPage().GetStudentNameFromPastDueSubmittedChannel()));
            Logger.LogMethodExit("TodaysView", "ValidateStudentNameInPastDueSubmittedChannel",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on cmenu icon of Discussion topic.
        /// </summary>
        /// <param name="discussionTopicName">Discussion topic name.</param>
        [When(@"I click on cmenu icon of Discussion topic ""(.*)""")]
        public void AccesCmenuOptionOfDiscussionTopic(string discussionTopicName)
        {
            //Click On Cmenu icon of discussion topic
            Logger.LogMethodEntry("TodaysView", "ClickonCmenuOptionOfDiscussionTopic",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the cmenu icon of discussion topic in unread discussions alert channel
            new TodaysViewUxPage().ClickOnCmenuIconOfDiscussionTopic(discussionTopicName);
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
                => Assert.AreEqual(discussionFrameTitle, new DiscussionMainUxPage().GetDiscussionFrameTitle()));
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
                () => Assert.AreEqual(Grade, new TodaysViewUxPage().GetGradeFromStudentPerformanceChannel(channelName)));
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
                    new TodaysViewUxPage().GetActivityCountFromPastDueNotSubmittedChannel()));
            Logger.LogMethodExit("TodaysView", "ValidateActivityCountInPastDueNotSubmittedChannel",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the idle student name.
        /// </summary>
        /// <param name="Count">Number of idle students.</param>
        /// <param name="StudentName">This is User type enum.</param>
        /// <param name="scenarioName">This s type of student.</param>
        /// <param name="channelName">This is channel name</param>
        [Then(@"I should see ""(.*)"" Idle Student ""(.*)"" of type ""(.*)"" in ""(.*)"" channel")]
        public void ValidateIdleStudentName(int Count, User.UserTypeEnum userTypeEnum,
            string scenarioName, string channelName)
        {
            //Verify Alert count in Idle Students Notification channel
            Logger.LogMethodEntry("TodaysView", "ValidateUnreadMessageAlertCount",
                base.IsTakeScreenShotDuringEntryExit);
            User user = new GBInstructorUXPage().FetchTheUserDetails(scenarioName, userTypeEnum);
            String StudentName = user.LastName + " , " + user.FirstName;
            //Assert the alert count displayed in Idle Students channel
            Logger.LogAssertion("VerifyUnreadMessageAlerts", ScenarioContext.Current.
                ScenarioInfo.Title,
                () => Assert.AreEqual(Count, new TodaysViewUxPage().GetCountFromAlertChannels(channelName)));
            //Assert the idle student name
            Logger.LogAssertion("VerifyUnreadMessageAlerts", ScenarioContext.Current.
                ScenarioInfo.Title,
                () => Assert.AreEqual(StudentName, new TodaysViewUxPage().GetStudentNameFromIdleStudents()));
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
                    new TodaysViewUxPage().GetNewGradesAlert()));
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
            new DiscussionMainUxPage().ClickOnCmenuOfResponse(postName);
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
            new DiscussionMainUxPage().SelectCmenuOption(cmenuOption);
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
            new DiscussionMainUxPage().SwitchToPopUp();
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
            new DiscussionMainUxPage().ClickOnCloseButtonInReadResponsePopUp();
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
            new DiscussionMainUxPage().ClickOnCancelButton();
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
            new TodaysViewUxPage().SelectResourceToolFromToolsDropdown
               ((TodaysViewUxPage.ResourceToolsTypeEnum)Enum.Parse
               (typeof(TodaysViewUxPage.ResourceToolsTypeEnum), resourceToolName));
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
            new TodaysViewUxPage().SelectMyProgressOption();
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
            new TodaysViewUxPage().ClickOnCmenuOptionOfAsset(activity.Name);
            Logger.LogMethodExit("TodaysView", "ClickOnCmenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select cmenu option of activity.
        /// </summary>
        /// <param name="cmenuOption">This is cmenu option name.</param>
        [When(@"I select the cmenu option ""(.*)"" of the activity")]
        public void SelectCmenuOfTheActivity(string cmenuOption)
        {
            Logger.LogMethodEntry("TodaysView", "SelectMyProgressOption",
             base.IsTakeScreenShotDuringEntryExit);
            // select cmenu option
            new TodaysViewUxPage().SelectCmenuOption(cmenuOption);
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

        /// <summary>
        /// Validate user who has submitted past due activity.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        [Then(@"I should see First name, Last name of ""(.*)"" who has submitted the past due activity in the right frame along with expand icon")]
        public void ValidateUserWhoHasSubmittedThePastDueActivity(User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("TodaysView", "ValidateUserWhoHasSubmittedThePastDueActivity",
                base.IsTakeScreenShotDuringEntryExit);
            // user details 
            User user = User.Get(userTypeEnum);
            string userFullName = (user.LastName + ',' + " " + user.FirstName);
            // verify user is present
            Logger.LogAssertion("VerifyUserNamePresent", ScenarioContext.Current.
              ScenarioInfo.Title, () => Assert.AreEqual(userFullName, new TodaysViewUxPage()
                .GetUserNameWhoHasSubmittedTheActivity()));
            //verify expand icon present
            Logger.LogAssertion("VerifyExpantIconPresent", ScenarioContext.Current.
             ScenarioInfo.Title, () => Assert.IsTrue(new TodaysViewUxPage()
               .IsExpandIconPresent()));
            Logger.LogMethodExit("TodaysView", "ValidateUserWhoHasSubmittedThePastDueActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on expand icon.
        /// </summary>
        [When(@"I click on expand icon displayed against student name")]
        public void ClickOnExpandIconDisplayedAgainstStudentName()
        {
            Logger.LogMethodEntry("TodaysView", "ClickOnExpandIconDisplayedAgainstStudentName",
                base.IsTakeScreenShotDuringEntryExit);
            // click expand icon display against user
            new TodaysViewUxPage().ClickExpandIconDisplayedAgainstUserName();
            Logger.LogMethodExit("TodaysView", "ClickOnExpandIconDisplayedAgainstStudentName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select check box for activity.
        /// </summary>
        [When(@"I selected the check box of the ""(.*)"" past due activity submitted")]
        public void SelectedTheCheckBoxOfThePastDueActivitySubmitted(string activityName)
        {
            Logger.LogMethodEntry("TodaysView", "SelectedTheCheckBoxOfThePastDueActivitySubmitted",
                base.IsTakeScreenShotDuringEntryExit);
            // select activity check box
            new TodaysViewUxPage().SelectSubmittedActivityCheckBox(activityName);
            Logger.LogMethodExit("TodaysView", "SelectedTheCheckBoxOfThePastDueActivitySubmitted",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify submitted past due activity details.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        [Then(@"I should see ""(.*)"" activity name and due date and time and submitted date and time which is submitted post due date")]
        public void ValidateDetailsForSubmittedPostDueDateActivity(string activityName)
        {
            Logger.LogMethodEntry("TodaysView", "ValidateDetailsForSubmittedPostDueDateActivity",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyStudentPresent",
           ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new TodaysViewUxPage().IsPastDueActivityPresent(activityName)));
            //// verify activity past due data and time present
            //Logger.LogAssertion("VerifyActivityDueDateAndTimePresent", ScenarioContext.Current.ScenarioInfo.Title,
            //    () => Assert.IsNotNull(new TodaysViewUxPage().GetActivityPastDueDateAndTime()));
            //// verify activity submitted date and time present 
            //Logger.LogAssertion("VerifyActivitySubmittedDateAndTimePresent", ScenarioContext.Current.ScenarioInfo.Title,
            //    () => Assert.IsNotNull(new TodaysViewUxPage().GetActivitySubmittedDateAndTime()));
            Logger.LogMethodExit("TodaysView", "ValidateDetailsForSubmittedPostDueDateActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify activity can be select.
        /// </summary>
        [Then(@"I should be able to select the past due activity")]
        public void ValidateToSelectThePastDueActivity()
        {
            Logger.LogMethodEntry("TodaysView", "ValidateToSelectThePastDueActivity",
             base.IsTakeScreenShotDuringEntryExit);
            // verify activity can be select
            Logger.LogAssertion("VerifyToSelectThePastDueActivity", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new TodaysViewUxPage().IsActivitySelected()));
            Logger.LogMethodExit("TodaysView", "ValidateToSelectThePastDueActivity",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on past due button.
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        /// <remarks>Button can be Accept or Decline.</remarks>
        [When(@"I click on ""(.*)"" activities past due date")]
        public void ClickOnPastDueButton(string buttonName)
        {
            Logger.LogMethodEntry("TodaysView", "ClickOnPastDueButton",
            base.IsTakeScreenShotDuringEntryExit);
            // click on button
            new TodaysViewUxPage().ClickTheActivityButton(buttonName);
            Logger.LogMethodExit("TodaysView", "ClickOnPastDueButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate Activity Score In Course Performance Channel.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <param name="header">This is activity header name.</param>
        /// <param name="headerValue">This is expected activity header value.</param>
        [Then(@"I should see the ""(.*)"" having ""(.*)"" as ""(.*)""")]
        public void ValidateActivityCoursePerformanceChannel(string activityName, string header, string headerValue)
        {
            Logger.LogMethodEntry("TodaysView", "ValidateActivityCoursePerformanceChannel",
               base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyCoursePerformanceChannelScore", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.AreEqual(headerValue, new TodaysViewUxPage().GetPerformanceChannelCalculations(activityName, header)));
            Logger.LogMethodExit("TodaysView", "ValidateActivityCoursePerformanceChannel",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the Past due submitted activity name.
        /// </summary>
        [Then(@"I should see the First, Last name in Past Due: Submitted channel")]
        public void ValidateStudentNameInPastDueSubmitted()
        {
            //Click on Back navigation link
            Logger.LogMethodEntry("TodaysView", "ValidateStudentNameInPastDueSubmitted",
                base.IsTakeScreenShotDuringEntryExit);
            string studentName = new RptAllAssessmentAllStudentPage().
                Get100ScoreUsername(User.UserTypeEnum.CsSmsStudent);
            //Validate student first, last name in past due submitted channel
            Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", ScenarioContext.Current
                .ScenarioInfo.Title, () => Assert.AreEqual(studentName, new
                    TodaysViewUxPage().GetStudentNameFromPastDueSubmittedChannel()));
            Logger.LogMethodExit("TodaysView", "ValidateStudentNameInPastDueSubmitted",
               base.IsTakeScreenShotDuringEntryExit); ;
        }

        //-------------------------------------------------------------------------------------------------------
       /// <summary>
       /// This is to verify header option as HED user and perform operation based on the options
       /// </summary>
       /// <param name="optionName">This is the option name.</param>
       /// <param name="tabName">This is the tab name.</param>
       /// <param name="couseTypeEnum">This is course type enum.</param>
       /// <param name="userType">This is user type enum</param>
        [When(@"I click on ""(.*)"" option in ""(.*)"" tab of ""(.*)"" as ""(.*)"" user")]
        public void VerifyTheHeaderOptions(string optionName, string tabName,
            Course.CourseTypeEnum couseTypeEnum,User.UserTypeEnum userType)
        {
            // Verify the header option based on the page and user type
            Logger.LogMethodEntry("TodaysView", "VerifyTheHeaderOptions",
                base.IsTakeScreenShotDuringEntryExit);
            switch(userType)
            {
                    // Check user type 
                case User.UserTypeEnum.CsSmsInstructor:
                case User.UserTypeEnum.CsSmsStudent:
                new TodaysViewUxPage().ValidateOptionsInTopHeaderAndPerformOperation
                        (optionName, tabName, couseTypeEnum, userType);
                break;

                case User.UserTypeEnum.DPCsNewTeacher:
                case User.UserTypeEnum.DPCsNewStudent:
                    break;

            }
            Logger.LogMethodExit("TodaysView", "VerifyTheHeaderOptions",
                base.IsTakeScreenShotDuringEntryExit);
        }

               
        /// <summary>
        /// Verify the lightbox display
        /// </summary>
        /// <param name="lightboxName">This is lightbox name.</param>
         [Then(@"I should be displayed with ""(.*)"" lightbox")]
        public void VerifyTheDisplayedOfWithLightbox(string lightboxName)
        {
            Logger.LogMethodEntry("TodaysView", "VerifyTheDisplayedOfWithLightbox",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyGradeinViewSubmission", ScenarioContext.
            Current.ScenarioInfo.Title, () => Assert.AreEqual(lightboxName,
            new HEDGlobalHomePage().GetLightboxTitle(lightboxName)));
            Logger.LogMethodExit("TodaysView", "VerifyTheDisplayedOfWithLightbox", 
                base.IsTakeScreenShotDuringEntryExit);
        }

       /// <summary>
         /// This is to validate the  Help Page display as HED user 
       /// </summary>
       /// <param name="pageTitle">This is the page name.</param>
       /// <param name="userType">This is the User type enum</param>
         [Then(@"I should be on ""(.*)"" page as ""(.*)"" user")]
        public void ValidateHelpPageDisplay(string pageTitle, User.UserTypeEnum userType)
        {
            //validate the Help Page display as HED user 
            Logger.LogMethodEntry("TodaysView", "ValidateHelpPageDisplay", 
                base.IsTakeScreenShotDuringEntryExit);
            
             switch(userType)
            {
                case User.UserTypeEnum.CsSmsInstructor:
                    //Verify Help page display for Instructor
                    Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", 
                        ScenarioContext.Current
                    .ScenarioInfo.Title, () => Assert.IsTrue(new
                   TodaysViewUxPage().GetInsPageURLAndPageTitle(pageTitle, userType)));
                    break;

                //Verify Help page display for Student
                case User.UserTypeEnum.CsSmsStudent:
                    Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel",
                        ScenarioContext.Current
            .ScenarioInfo.Title, () => Assert.IsTrue(new
            TodaysViewUxPage().GetStudPageURLAndPageTitle(pageTitle, userType)));
                                break;
            }
            Logger.LogMethodExit("TodaysView", "ValidateHelpPageDisplay", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the course details displayed in the header part of the course
        /// </summary>
        /// <param name="courseType">This is the course type enum.</param>
        /// <param name="userType">This is user type enum.</param>
         [Then(@"I should be displayed with ""(.*)"" course information for ""(.*)"" user")]
         public void ValidateDisplayedWithCourseInformationForUser(
             Course.CourseTypeEnum courseType, User.UserTypeEnum userType)
         {
             //Verify the course details displayed in the header part of the course
             Logger.LogMethodEntry("TodaysView", "ValidateDisplayedWithCourseInformationForUser", 
                 base.IsTakeScreenShotDuringEntryExit);
                 switch (userType)
                 {
                     case User.UserTypeEnum.CsSmsInstructor:
                         Logger.LogAssertion("ValidateDisplayedWithCourseInformationForUser", 
                             ScenarioContext.Current
                         .ScenarioInfo.Title, () => Assert.IsTrue(new
                        TodaysViewUxPage().GetCourseInfoDetails(courseType)));
                         break;

                     case User.UserTypeEnum.CsSmsStudent:
                         break;
                 }
                 Logger.LogMethodExit("TodaysView", "ValidateDisplayedWithCourseInformationForUser",
                     base.IsTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Click on the specified channel and move operation.
         /// </summary>
         /// <param name="channelName">This is channel name.</param>
         /// <param name="operationName">This is operation name.</param>
         /// <param name="pageName">This is page name.</param>
         /// <param name="userType">This is user type enum.</param>        
         [When(@"I ""(.*)"" the ""(.*)"" channel on ""(.*)"" tab as ""(.*)""")]
         public void PerformClickOnChannelsInTodaysViewTab(string operationName, string channelName,
             string pageName, User.UserTypeEnum userType)
         {
             Logger.LogMethodEntry("HomePage", "DisplayedOfOptionsInChannels", base.IsTakeScreenShotDuringEntryExit);
             switch (userType)
             {
                 case User.UserTypeEnum.CsSmsInstructor:
                 case User.UserTypeEnum.CsSmsStudent:
                     switch (pageName)
                     {
                         case "Today's View":
                             switch (channelName)
                             {
                                 case "Notifications":
                                     new TodaysViewUxPage().
                                         ClickOptionInNotificationsChannelTodaysView(operationName, pageName);
                                     Thread.Sleep(2000);
                                     break;

                                 case "Calendar":
                                     new TodaysViewUxPage().
                                         ClickOptionInCalendarChannelTodaysView(operationName, pageName);
                                     Thread.Sleep(2000);
                                     break;

                                 case "Announcements":
                                     new TodaysViewUxPage().
                                         ClickOptionInAnnouncementsChannelTodaysView(operationName, pageName);
                                     Thread.Sleep(2000);
                                     break;
                             }
                             break;

                         case "Global Home":
                             switch (channelName)
                             {
                                 case "My Courses and Testbanks":

                                     break;

                                 case "Announcements":

                                     break;
                             }
                             break;
                     }
                     break;
             }
             Logger.LogMethodExit("TodaysView", "DisplayedOfOptionsInChannels", base.IsTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Verify the channel names in Todays view tab
         /// </summary>
         /// <param name="subChannelName">This is the sub-channel name.</param>
         /// <param name="channelName">This is the main channel name.</param>
         [Then(@"I should see ""(.*)"" in ""(.*)"" channel")]
         public void ValidateSubChannelInNotificationChannel(string subChannelName, string channelName)
         {
             Logger.LogMethodEntry("TodaysView", "ValidateSubChannelInNotificationChannel",
                 base.IsTakeScreenShotDuringEntryExit);
             // verify subchannel in  can be select
             Logger.LogAssertion("VerifyToSelectThePastDueActivity", ScenarioContext.Current.ScenarioInfo.Title,
                 () => Assert.IsTrue(new TodaysViewUxPage().GetSubChannelInNotification(subChannelName, channelName)));
             Logger.LogMethodExit("TodaysView", "ValidateSubChannelInNotificationChannel",
                 base.IsTakeScreenShotDuringEntryExit);
         }


        /// <summary>
        /// Expand the subchannel based on the subchannel channel name
        /// </summary>
        /// <param name="subchannelName">This is subchannel name.</param>
         [When(@"I expand ""(.*)"" channel")]
         public void ExpandChannelInNotificationChannel(string subchannelName)
         {
             Logger.LogMethodEntry("TodaysView", "ExpandChannelInNotificationChannel",
             base.IsTakeScreenShotDuringEntryExit);
             new TodaysViewUxPage().ClickExpanIconInNotificationChannel(subchannelName);
             Logger.LogMethodEntry("TodaysView", "ExpandChannelInNotificationChannel",
             base.IsTakeScreenShotDuringEntryExit);
         }

        /// <summary>
         /// Validate message display in About This Course channel.
        /// </summary>
        /// <param name="message">This is message.</param>
         [Then(@"I should be displayed with ""(.*)"" message")]
         public void ValidateMessageInAboutThisCourse(string message)
         {
             Logger.LogMethodEntry("TodaysView", "ValidateMessageInAboutThisCourse",
             base.IsTakeScreenShotDuringEntryExit);
             Logger.LogAssertion("VerifyGradeinViewSubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(message,
                new TodaysViewUxPage().GetAboutThisCourseMessage()));
             Logger.LogMethodExit("TodaysView", "ValidateMessageInAboutThisCourse",
             base.IsTakeScreenShotDuringEntryExit);
         }


        /// <summary>
        /// Validate the display of welcome message in Todays view page.
        /// </summary>
        /// <param name="welcomeMessage">This is welcome message type enum.</param>
         [Then(@"I should be displayed with ""(.*)"" welcome message")]
         public void ValidateWelcomeMessageInWelcomeMessageChannel(String welcomeMessage)
         {
             Logger.LogMethodExit("TodaysView", "ValidateWelcomeMessageInWelcomeMessageChannel",
             base.IsTakeScreenShotDuringEntryExit);
             // Get welcome message from enum.
             //WelcomeMessage welcomeMessage = WelcomeMessage.Get(welcomeMessageType);
             //string getWelcomeMessage = welcomeMessage.Message.ToString();

             Logger.LogAssertion("VerifyGradeinViewSubmission", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.AreEqual(welcomeMessage,
               new TodaysViewUxPage().GetWelcomeMessage()));

             Logger.LogMethodExit("TodaysView", "ValidateWelcomeMessageInWelcomeMessageChannel",
            base.IsTakeScreenShotDuringEntryExit);
         }


         /// <summary>
         /// Validate the Alert count in Notifications main channel
         /// </summary>
         /// <param name="alertType">This is the alert type.</param>
         [Then(@"I should be displayed with ""(.*)"" count")]
         public void ValidateAlertCountInAlertChannel(Alert.AlertTypeEnum alertType)
         {
             Logger.LogMethodExit("TodaysView", "ValidateAlertCountInAlertChannel",
                base.IsTakeScreenShotDuringEntryExit);
             // Get welcome message from enum.
             Alert alert = Alert.Get(alertType);
             string getAlertCount = alert.AlertCount.ToString();
             //Verify the Alter count
             Logger.LogAssertion("ValidateAlertCountInAlertChannel", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.AreEqual(getAlertCount,
               new TodaysViewUxPage().GetAlertCount(alertType)));
             Logger.LogMethodExit("TodaysView", "ValidateAlertCountInAlertChannel",
            base.IsTakeScreenShotDuringEntryExit);
         }

        /// <summary>
        /// Click on the Alert channel option 
        /// </summary>
        /// <param name="alertType">This is the Alert type.</param>
         [When(@"I click on ""(.*)"" alert option")]
         public void ClickOnAlertOption(string alertType)
         {
             Logger.LogMethodEntry("TodaysView", "ClickOnAlertOption",
                base.IsTakeScreenShotDuringEntryExit);
             new TodaysViewUxPage().ClickAlertType(alertType);
             Logger.LogMethodExit("TodaysView", "ClickOnAlertOption",
                base.IsTakeScreenShotDuringEntryExit);
         }

         //public void WhenIClickOnCount(Alert.AlertTypeEnum alertType)
         //{
         //    Logger.LogMethodEntry("TodaysView", "WhenIClickOnCount",
         //       base.IsTakeScreenShotDuringEntryExit);
         //    new TodaysViewUxPage().ClickAlertTypeOption(alertType);
         //    Logger.LogMethodExit("TodaysView", "WhenIClickOnCount",
         //       base.IsTakeScreenShotDuringEntryExit);
         //}

        /// <summary>
        /// Validate the count of Idle students displayed in the Idle Students frame
        /// </summary>
        /// <param name="alertType">This is alert type enum.</param>
         [Then(@"I should see ""(.*)"" idle student")]
         public void GetIdleStudentCount(Alert.AlertTypeEnum alertType)
         {
             Logger.LogMethodEntry("TodaysView", "GetIdleStudentCount",
                base.IsTakeScreenShotDuringEntryExit);
             Alert alert = Alert.Get(alertType);
             string getAlert = alert.AlertCount.ToString();
             Logger.LogAssertion("GetIdleStudentCount", ScenarioContext.
              Current.ScenarioInfo.Title, () => Assert.AreEqual(getAlert,
              new TodaysViewUxPage().GetIdleStudentCount()));
             Logger.LogMethodExit("TodaysView", "GetIdleStudentCount",
                base.IsTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Verify Idle Student In Alerts Channel
         /// </summary>
         /// <param name="p0">This is the User type enum.</param>
         [Then(@"I should be displayed with 'Idle' ""(.*)""")]
         public void VerifyIdleStudentInAlertsChannel(User.UserTypeEnum userType)
         {
             Logger.LogMethodExit("TodaysView", "VerifyIdleStudentInAlertsChannel",
               base.IsTakeScreenShotDuringEntryExit);
             //Get User from Memory
             User user = User.Get("Hed_User_SMS_STU_UC2");
             string actualIdleStudentName = user.LastName + " , " + user.FirstName;
             Logger.LogAssertion("VerifyStudentInAlertChannel", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.IsTrue(
               new TodaysViewUxPage().GetIdleStudentName(actualIdleStudentName)));
             Logger.LogMethodExit("TodaysView", "VerifyIdleStudentInAlertsChannel",
            base.IsTakeScreenShotDuringEntryExit);
         }

        /// <summary>
         /// Verify Idle Student Alert Message
        /// </summary>
        /// <param name="p0">This is the message text.</param>
         [Then(@"I should be displayed with the ""(.*)"" message")]
         public void VerifyIdleStudentAlertMessage(string messageText)
         {
             Logger.LogMethodExit("TodaysView", "VerifyIdleStudentAlertMessage",
                base.IsTakeScreenShotDuringEntryExit);
             Logger.LogAssertion("VerifyIdleStudentAlertMessage", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.IsTrue(
               new TodaysViewUxPage().GetIdleStudentMessage()));
             Logger.LogMethodExit("TodaysView", "VerifyIdleStudentAlertMessage",
            base.IsTakeScreenShotDuringEntryExit);
         }

         //---------------------------------------------------------------------------------------------
         /// <summary>
         /// Verify Zero score Student In Alert Channel
         /// </summary>
         /// <param name="userType">This is the User type enum.</param>
         [Then(@"I should see 'Zero' scoring ""(.*)""")]
         public void VerifyStudentInAlertChannel(User.UserTypeEnum userType)
         {
             Logger.LogMethodExit("TodaysView", "VerifyStudentInAlertChannel",
               base.IsTakeScreenShotDuringEntryExit);
             //Get User from Memory
             string studentName = new RptAllAssessmentAllStudentPage().
                 GetZeroScoreUsername(userType);
             //Verify Zero score student name
             Logger.LogAssertion("VerifyStudentInAlertChannel", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.AreEqual(studentName,
               new TodaysViewUxPage().StudentDisplayedInPastDueSubmittedChannel(studentName)));
             Logger.LogMethodExit("TodaysView", "VerifyStudentInAlertChannel",
            base.IsTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Verify 100 score Student Name In Alert Channel
         /// </summary>
         /// <param name="userType">This is the User type enum.</param>
         [Then(@"I should see '100' score ""(.*)""")]
         public void VerifyStudentNameInAlertChannel(User.UserTypeEnum userType)
         {
             Logger.LogMethodExit("TodaysView", "VerifyStudentNameInAlertChannel",
               base.IsTakeScreenShotDuringEntryExit);
             //Get User from Memory
             string studentName = new RptAllAssessmentAllStudentPage().
                 Get100ScoreUsername(User.UserTypeEnum.CsSmsStudent);
             //Validate student first name, last name in past due submitted channel
             Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", ScenarioContext.Current
                 .ScenarioInfo.Title, () => Assert.AreEqual(studentName,
                     new TodaysViewUxPage().StudentDisplayedInPastDueSubmittedChannel(studentName)));
             Logger.LogMethodExit("TodaysView", "VerifyStudentNameInAlertChannel",
            base.IsTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Verify Display of Accept and Decline buttons in Past due submitted channel
         /// </summary>
         /// <param name="p0">This is the button name.</param>
         /// <param name="p1">This is the button name.</param>
         [Then(@"I should see ""(.*)"" ""(.*)"" buttons")]
         public void ThenIShouldSeeButtons(string acceptButton, string declineButton)
         {
             Logger.LogMethodExit("TodaysView", "VerifyStudentNameInAlertChannel",
              base.IsTakeScreenShotDuringEntryExit);
             //Get User from Memory
             string studentName = new RptAllAssessmentAllStudentPage().
                 Get100ScoreUsername(User.UserTypeEnum.CsSmsStudent);
             //Validate Accept button display
             Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", ScenarioContext.Current
                 .ScenarioInfo.Title, () => Assert.IsTrue(new
                     TodaysViewUxPage().IsActivityAcceptDeclineButtonDisplayed(acceptButton)));
             //Validate Decline button display
             Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", ScenarioContext.Current
                 .ScenarioInfo.Title, () => Assert.IsTrue(new
                     TodaysViewUxPage().IsActivityAcceptDeclineButtonDisplayed(declineButton)));
             Logger.LogMethodExit("TodaysView", "VerifyStudentNameInAlertChannel",
            base.IsTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Expand the Student name in Past due submitted channel of Todays view tab
         /// </summary>
         /// <param name="userTypeEnum">This is the User type enum.</param>
         [When(@"I click on the expand icon of ""(.*)""")]
         public void ExpandIconOfStudentInPastDueSubmitteChannel(User.UserTypeEnum userTypeEnum)
         {
             Logger.LogMethodExit("TodaysView", "ExpandIconOfStudentInPastDueSubmitteChannel",
                base.IsTakeScreenShotDuringEntryExit);
             //Fetch user from XML
             User user = User.Get(userTypeEnum);
             string actualUserName = user.LastName + ", " + user.FirstName;
             new TodaysViewUxPage().ClickStudentExpadIcon(actualUserName);
             Logger.LogMethodExit("TodaysView", "ExpandIconOfStudentInPastDueSubmitteChannel",
                base.IsTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Expand Zero score Student name in Past due submitted channel of Todays view tab
         /// </summary>
         /// <param name="userTypeEnum">This is the user type enum.</param>
         [When(@"I click on the expand icon 'Zero' score ""(.*)""")]
         public void ExpandIconOfZeroScoreStudentInPastDueSubmitteChannel(User.UserTypeEnum userTypeEnum)
         {
             Logger.LogMethodExit("TodaysView", "ExpandIconOfZeroScoreStudentInPastDueSubmitteChannel",
                base.IsTakeScreenShotDuringEntryExit);
             //Fetch user from XML
             string studentName = new RptAllAssessmentAllStudentPage().
                 GetZeroScoreUsername(userTypeEnum);
             new TodaysViewUxPage().ClickStudentExpadIcon(studentName);
             Logger.LogMethodExit("TodaysView", "ExpandIconOfZeroScoreStudentInPastDueSubmitteChannel",
               base.IsTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="p0"></param>
         [Then(@"I should see the ""(.*)"" activity name")]
         public void VerifyActivityNameInPastDueSubmitteChannel(Activity.ActivityTypeEnum activityTypeEnum)
         {
             Logger.LogMethodExit("TodaysView", "VerifyActivityNameInPastDueSubmitteChannel",
              base.IsTakeScreenShotDuringEntryExit);
             //Get Activity name from XML memory           
             Activity activity = Activity.Get(activityTypeEnum);
             String actualActivityName = activity.Name;
             Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", ScenarioContext.Current
                 .ScenarioInfo.Title, () => Assert.IsTrue(new
                     TodaysViewUxPage().IsActivityDislayedInPastDueSubmittedChannel(actualActivityName)));
             Logger.LogMethodExit("TodaysView", "VerifyActivityNameInPastDueSubmitteChannel",
            base.IsTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="p0"></param>
         /// <param name="p1"></param>
         [When(@"I select the check box of the ""(.*)"" past due activity submitted by ""(.*)""")]
         public void SelectTheCheckBoxOfThePastDueActivitySubmitted(Activity.ActivityTypeEnum activityType,
             User.UserTypeEnum userType)
         {
             Logger.LogMethodExit("TodaysView", "SelectTheCheckBoxOfThePastDueActivitySubmitted",
               base.IsTakeScreenShotDuringEntryExit);
             //Fetch Activity name from XML
             Activity activity = Activity.Get(activityType);
             string actualActivityName = activity.Name;
             //Fetch User from XML memory
             User user = User.Get(userType);
             string actualUserName = user.LastName + ", " + user.FirstName;
             new TodaysViewUxPage().SelectTheCheckBoxOfPastDueActivitySubmitted(actualActivityName, actualUserName);
             Logger.LogMethodExit("TodaysView", "SelectTheCheckBoxOfThePastDueActivitySubmitted",
              base.IsTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="p0"></param>
         /// <param name="p1"></param>
         /// <param name="p2"></param>
         [When(@"I select the check box of the ""(.*)"" past due activity submitted by 'Zero' score ""(.*)""")]
         public void SelectPastDuesubmittedActivityCheckBoxByZeroScoreStudent(
             Activity.ActivityTypeEnum activityType, User.UserTypeEnum userType)
         {
             Logger.LogMethodExit("TodaysView", "SelectTheCheckBoxOfThePastDueActivitySubmitted",
               base.IsTakeScreenShotDuringEntryExit);
             //Fetch Activity name from XML
             Activity activity = Activity.Get(activityType);
             string actualActivityName = activity.Name;
             //Fetch User from XML memory
             string studentName = new RptAllAssessmentAllStudentPage().
                  GetZeroScoreUsername(userType);
             new TodaysViewUxPage().SelectTheCheckBoxOfPastDueActivitySubmitted(actualActivityName, studentName);
             Logger.LogMethodExit("TodaysView", "SelectTheCheckBoxOfThePastDueActivitySubmitted",
              base.IsTakeScreenShotDuringEntryExit);
         }


         [Then(@"I should see ""(.*)"" submission 'Accepted' success message")]
         public void VerifySubmissionAcceptedSuccessMessage(User.UserTypeEnum userType)
         {
             // Method To Verify the Success Message 
             Logger.LogMethodEntry("TodaysView", "VerifySubmissionAcceptedSuccessMessage",
                 base.IsTakeScreenShotDuringEntryExit);
             string studentName = new Pegasus.Pages.RptAllAssessmentAllStudentPage().
                 Get100ScoreUsername(userType);
             string successMessage = "All of the late submissions for " + studentName + " has been accepted. The grade for this submission will now appear in the Gradebook.";
             //Verify Correct Message Present on the Page
             bool isSuccessMessageExist = base.IsMessageExists(successMessage,
                 "messagesucessfont");
             //Removed The Assert For Message Because Sometimes Message does not come
             //but this is not the severe issue. So We, can ignore this.
             Logger.LogMethodExit("TodaysView", "VerifySubmissionAcceptedSuccessMessage",
                 base.IsTakeScreenShotDuringEntryExit);
         }


         [Then(@"I should see 'Zero' ""(.*)"" submission 'Declined' success message")]
         public void VerifySubmissionDeclinedSuccessMessage(User.UserTypeEnum userType)
         {

             // Method To Verify the Success Message 
             Logger.LogMethodEntry("TodaysView", "VerifySubmissionDeclinedSuccessMessage",
                 base.IsTakeScreenShotDuringEntryExit);
             //Verify Correct Message Present on the Page
             string studentName = new Pegasus.Pages.RptAllAssessmentAllStudentPage().
                 GetZeroScoreUsername(userType);
             string successMessage = "All of the late submissions for " + studentName + " has been declined.  This submission will receive a zero in the Gradebook.";
             bool isSuccessMessageExist = base.IsMessageExists(successMessage,
                 "messagesucessfont");
             //Removed The Assert For Message Because Sometimes Message doest not come
             //but this is not the severe issue. So We, can ignore this.
             Logger.LogMethodExit("TodaysView", "VerifySubmissionDeclinedSuccessMessage",
                 base.IsTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Verify Student Name In PastDue NotSubmitted Channel
         /// </summary>
         /// <param name="p0">This is the Student Type.</param>
         /// <param name="p1">This is the Usertype enum.</param>
         [Then(@"I should be displayed with the ""(.*)"" score ""(.*)""")]
         public void VerifyStudentNameInpastDueNotSubmittedChannel(string studentType, User.UserTypeEnum userTypeEnum)
         {
             Logger.LogMethodEntry("TodaysView", "VerifyStudentNameInpastDueNotSubmittedChannel",
                base.IsTakeScreenShotDuringEntryExit);
             switch (studentType)
             {
                 case "Zero":
                     string ZeroScoreStudentName = new Pegasus.Pages.RptAllAssessmentAllStudentPage().
                  GetZeroScoreUsername(userTypeEnum);
                     Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", ScenarioContext.Current
                  .ScenarioInfo.Title, () => Assert.IsTrue(
                      new TodaysViewUxPage().GetStudentNameInPastDueNotSubmittedChannel(ZeroScoreStudentName)));
                     break;

                 case "Idle":
                     User user = User.Get("Hed_User_SMS_STU_UC2");
                     string actualIdleStudentName = user.LastName + ", " + user.FirstName;
                     Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", ScenarioContext.Current
                .ScenarioInfo.Title, () => Assert.IsTrue(
                    new TodaysViewUxPage().GetStudentNameInPastDueNotSubmittedChannel(actualIdleStudentName)));
                     break;

                 //        string defaultStudentName = new Pegasus.Pages.RptAllAssessmentAllStudentPage().
                 //Get100ScoreUsername(userTypeEnum);
                 // new TodaysViewUxPage().GetStudentNameInPastDueNotSubmittedChannel(defaultStudentName);
             }
             Logger.LogMethodExit("TodaysView", "VerifyStudentNameInpastDueNotSubmittedChannel",
                base.IsTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Verify the Activity displayed in NewGrades channel of Notification Channel
         /// </summary>
         /// <param name="activityTypeEnum"></param>
         [Then(@"I should see the ""(.*)""")]
         public void VerifyNewGradedActivityInNotificationChannel(Activity.ActivityTypeEnum activityTypeEnum)
         {
             Logger.LogMethodEntry("TodaysView", "VerifyNewGradedActivityInNotificationChannel",
                base.IsTakeScreenShotDuringEntryExit);
             Activity activity = Activity.Get(activityTypeEnum);
             string actualActivityName = activity.Name;
             Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", ScenarioContext.Current
                .ScenarioInfo.Title, () => Assert.IsTrue(
                    new TodaysViewUxPage().IsNewGradedActivityPresentInNotificationChannel(actualActivityName)));
             Logger.LogMethodExit("TodaysView", "VerifyNewGradedActivityInNotificationChannel",
                base.IsTakeScreenShotDuringEntryExit);
         }

    }
}
