#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Overview Tab actions in Course Space. 
    /// </summary>
    [Binding]
    public class Overview : PegasusBaseTestFixture
    {
        ///<summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(Overview));

        /// <summary>
        /// Verify Class Present In The Overview Tab.
        /// </summary>
        /// <param name="classTypeEnum">This is is class by type.</param>
        [Then(@"I should see the ""(.*)"" class present in the overview tab")]
        public void ClassPresentInTheOverviewTab(
            Class.ClassTypeEnum classTypeEnum)
        {
            //Verify Class Name In Overview Tab
            Logger.LogMethodEntry("Overview", "ClassPresentInTheOverviewTab",
          base.IsTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class orgClass = Class.Get(classTypeEnum);
            // Assert Class Search
            Logger.LogAssertion("VerifyClassPresentInOverviewTab", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(orgClass.Name,
                    new TodaysViewUxPage().GetClassName()));
            Logger.LogMethodExit("Overview", "ClassPresentInTheOverviewTab",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Calendar Asset Icon.
        /// </summary>
        [Then(@"I should see the calendar icon for assigned asset")]
        public void CalendarIconForAssignedAsset()
        {
            //Verify Calendar Asset Icon
            Logger.LogMethodEntry("Overview", "CalendarIconForAssignedAsset",
         base.IsTakeScreenShotDuringEntryExit);
            CalendarFramePage calendarFramePage = new CalendarFramePage();
            //Select Overview Window and Frame
            calendarFramePage.SelectOverviewWindowandFrame();
            //Verify Calendar Asset Icon
            Logger.LogAssertion("VerifyCalendarIcon", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue
                (calendarFramePage.IsCalendarIconPresent()));
            Logger.LogMethodExit("Overview", "CalendarIconForAssignedAsset",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Calendar Icon.
        /// </summary>
        [When(@"I click on the calendar icon of assigned asset")]
        public void ClickOnCalendarIconofAsset()
        {
            //Click on Calendar Icon
            Logger.LogMethodEntry("Overview", "ClickOnCalendarIconofAsset",
          base.IsTakeScreenShotDuringEntryExit);
            CalendarFramePage calendarFramePage = new CalendarFramePage();
            //Select Overview Window and Frame
            calendarFramePage.SelectOverviewWindowandFrame();
            //Click on Calendar Icon
            calendarFramePage.ClickOnCalendarIcon();
            Logger.LogMethodExit("Overview", "ClickOnCalendarIconofAsset",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the assigned activity name.
        /// </summary>
        /// <param name="activityName"></param>
        [Then(@"I should see the assigned asset ""(.*)""")]
        public void VerifyTheAssignedAsset(String activityName)
        {
            Logger.LogMethodEntry("Overview", "VerifyTheAssignedAsset",
          base.IsTakeScreenShotDuringEntryExit);            
            // Assert Activity Search
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityName,
                    new CourseCalendarPage().GetActivityName(OverviewResource.
                    Overview_Content_Window_Name, activityName)));
            Logger.LogMethodExit("Overview", "VerifyTheAssignedAsset",
          base.IsTakeScreenShotDuringEntryExit);
            
        }

        /// <summary>
        /// Select class from class selector dropdown.
        /// </summary>
        /// <param name="classTypeEnum">This is class type.</param>
        [When(@"I select ""(.*)"" from the class selector dropdown")]
        public void StudentSelectClassFromTheClassSelectorDropdown(Class.ClassTypeEnum classTypeEnum)
        {
            Logger.LogMethodEntry("Overview", "StudentSelectClassFromTheClassSelectorDropdown", base.IsTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class orgClass = Class.Get(classTypeEnum);
            string className = orgClass.Name.ToString();
            TodaysViewUxPage todaysViewUxPage = new TodaysViewUxPage();
            // Select class
            todaysViewUxPage.StudentSelectClass(className);
            Logger.LogMethodExit("Overview", "StudentSelectClassFromTheClassSelectorDropdown", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Channels in Overview Page
        /// </summary>
        /// <param name="channels">Channels</param>
        [Then(@"I should see the ""(.*)"" channels in Overview page")]
        public void VerifyChanneslInOverviewPage(string channels)
        {
            //Verify Channels in Today's View Page
            Logger.LogMethodEntry("TodaysView", "VerifyChanneslInOverviewPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify Channels in Today's View Page
            Logger.LogAssertion("VerifyChannels",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(channels, new TodaysViewUxPage().GetNotificationsChannelTitleK12()));
            Logger.LogMethodEntry("TodaysView", "VerifyChanneslInOverviewPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see the alert count updated as ""(.*)"" in ""(.*)"" channel")]
        public void ValidateUnreadMessageAlertCountK12(int alertCount, string channelName)
        {
            //Verify Alert count in Unread Messages Notification channel
            Logger.LogMethodEntry("TodaysView", "ValidateUnreadMessageAlertCountK12",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert the alert count displayed in Unread Messages channel
            Logger.LogAssertion("VerifyUnreadMessageAlerts", ScenarioContext.Current.
                ScenarioInfo.Title,
                () => Assert.AreEqual(alertCount, new TodaysViewUxPage().GetAlertCountK12(channelName)));
            Logger.LogMethodEntry("TodaysView", "ValidateUnreadMessageAlertCountK12",
              base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I click on the ""(.*)"" option")]
        public void ClickOnAlertChannelOptionK12(string channelOption)
        {
            //Click On Notification Channel Option
            Logger.LogMethodEntry("TodaysView", "ClickOnAlertChannelOptionK12",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Performance channel Option
            new TodaysViewUxPage().ClickNotificationChannelOptionK12(channelOption);
            Logger.LogMethodExit("TodaysView", "ClickOnAlertChannelOptionK12",
                base.IsTakeScreenShotDuringEntryExit);
        }


        [Then(@"I should see ""(.*)"" activity in the ""(.*)"" channel")]
        public void ValidateActivityCountInNotPassedChannelK12(int activityCount, string channelName)
        {
            //Click on Back navigation link
            Logger.LogMethodEntry("TodaysView", "ValidateActivityCountInNotPassedChannelK12",
                base.IsTakeScreenShotDuringEntryExit);
            //Validate the activity count displayed in Not passed channel
            Logger.LogAssertion("ValidateActivityCountInNotPassedChannel", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityCount,
                    new TodaysViewUxPage().GetCountFromAlertChannelsK12(channelName)));
            base.SelectDefaultWindow();
            Logger.LogMethodExit("TodaysView", "ValidateActivityCountInNotPassedChannelK12",
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
        public void ValidateIdleStudentNameK12(int Count, User.UserTypeEnum userTypeEnum,
            string scenarioName, string channelName)
        {
            //Verify Alert count in Idle Students Notification channel
            Logger.LogMethodEntry("TodaysView", "ValidateIdleStudentNameK12",
                base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userTypeEnum);
            String StudentName = user.LastName + " , " + user.FirstName;
            //Assert the alert count displayed in Idle Students channel
            Logger.LogAssertion("ValidateIdleStudentNameK12", ScenarioContext.Current.
                ScenarioInfo.Title,
                () => Assert.AreEqual(Count, new TodaysViewUxPage().GetCountFromAlertChannelsK12(channelName)));
            //Assert the idle student name
            Logger.LogAssertion("ValidateIdleStudentNameK12", ScenarioContext.Current.
                ScenarioInfo.Title,
                () => Assert.AreEqual(StudentName, new TodaysViewUxPage().GetStudentNameFromIdleStudentsK12()));
            base.SelectDefaultWindow();
            Logger.LogMethodEntry("TodaysView", "ValidateIdleStudentNameK12",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the eText dropdown in the Course Tool Bar
        /// </summary>
        /// <param name="eText">eText name</param>
        [When(@"I click on '(.*)' dropdown")]
        public void ClickETextDropdown(Activity.ActivityTypeEnum eText)
        {
            //Click the eText dropdown in the Course Tool Bar
            Logger.LogMethodEntry("TodaysView", "ClickETextDropdown",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the eText dropdown icon
            new TodaysViewUxPage().ClickETextDropdownIcon(eText);

            Logger.LogMethodExit("TodaysView", "ClickETextDropdown",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
