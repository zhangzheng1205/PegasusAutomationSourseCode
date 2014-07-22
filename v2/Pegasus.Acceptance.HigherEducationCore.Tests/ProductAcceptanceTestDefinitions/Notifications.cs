using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.HigherEducation.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the Activity Alert/Notification details
    /// and handles Pegasus Alert/Notification Page Actions.
    /// </summary>
    [Binding]
    public class Notifications : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(Notifications));

        /// <summary>
        /// Navigate to Today's View page.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>
        [When(@"I navigate to ""(.*)"" page by More option")]
        public void NavigateToTodaysViewTab(String tabName)
        {
            //Navigate to the Todays View page 
            Logger.LogMethodEntry("Notifications", "NavigateToTodaysViewTab",
                base.isTakeScreenShotDuringEntryExit);
            //Click on the Today's view option
            new CalendarHEDDefaultUXPage().ClickOnTodaysViewOption(tabName);
            Logger.LogMethodExit("Notifications", "NavigateToTodaysViewTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Displays alert for New Grades.
        /// </summary>
        [Then(@"I should successfully see the alert for New Grades")]
        public void DisplayAlertForNewGrades()
        {
            //Displaying the Alert for New Grades
            Logger.LogMethodEntry("Notifications", "DisplayAlertForNewGrades",
                base.isTakeScreenShotDuringEntryExit);
            //Asserts if New Grades alerts are displayed
            Logger.LogAssertion("VerifyDisplayOfNewGrades",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreNotEqual(NotificationsResource.
                    NotificationsResource_Submitted_Grades,
                    new TodaysViewUXPage().GetNewGradesAlert()));
            Logger.LogMethodExit("Notifications", "DisplayAlertForNewGrades",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on the New Grades Alert option.
        /// </summary>
        [When(@"I click New Grades alert option")]
        public void ClickNewGradesAlertOption()
        {
            //Clicking the New Grades link
            Logger.LogMethodEntry("Notifications", "ClickNewGradesAlertOption",
                base.isTakeScreenShotDuringEntryExit);
            //Clicking on the New Grades Link
            new TodaysViewUXPage().ClickNewGradesOption();
            Logger.LogMethodExit("Notifications", "ClickNewGradesAlertOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validates the Notification of submitted activity name.
        /// </summary>
        [Then(@"I should successfully see the submitted activity name")]
        public void DisplayOfSubmittedActivityName()
        {
            //Display of Activity Name as Notification
            Logger.LogMethodEntry("Notifications", "DisplayOfSubmittedActivityName",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Submitted Activity name present            
            Logger.LogAssertion("VerifySubmittedActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(NotificationsResource.
                    NotificationsResource_Submitted_ActivityName,
                    new TodaysViewUXPage().GetSubmittedActivityName()));
            Logger.LogMethodEntry("Notifications", "DisplayOfSubmittedActivityName",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Support Link In Global Homepage.
        /// </summary>
        /// <param name="userTypeEnum">This is User type Enum.</param>
        [When(@"I click the 'Support' link by ""(.*)"" in global homepage")]
        public void ClickTheSupportLinkInGlobalHomepage(
            User.UserTypeEnum userTypeEnum)
        {
            //Click The Support Link In Global Homepage
            Logger.LogMethodEntry("Notifications", "ClickTheSupportLinkInGlobalHomepage",
                base.isTakeScreenShotDuringEntryExit);
            // Click The Support Link In Global Homepage
            new CalendarHEDDefaultUXPage().ClickTheSuportLinkInGlobalHomepage(userTypeEnum);
            Logger.LogMethodEntry("Notifications", "ClickTheSupportLinkInGlobalHomepage",
                 base.isTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Click The Link In Global Homepage.
        /// </summary>
        /// <param name="globalHomePageLink">This is global homepage link</param>
        [When(@"I click the ""(.*)"" link in global homepage")]
        public void ClickTheLinkInGlobalHomepage(string globalHomePageLink)
        {
            //Click The Link In Global Homepage.
            Logger.LogMethodEntry("Notifications", "ClickTheLinkInGlobalHomepage",
                base.isTakeScreenShotDuringEntryExit);
            // Click The Link In Global Homepage 
            new TodaysViewUXPage().ClickTheLinkInGlobalHomePage(
                (TodaysViewUXPage.GlobalHomePageLinkTypeEnum)Enum.Parse
                (typeof(TodaysViewUXPage.GlobalHomePageLinkTypeEnum), globalHomePageLink));
            Logger.LogMethodEntry("Notifications", "ClickTheLinkInGlobalHomepage",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The UserName In Support Popup.
        /// </summary>
        /// <param name="userTypeEnum">This is User type Enum.</param>
        [Then(@"I should see the user name of ""(.*)"" in popup")]
        public void VerifyTheUserNameInSupportPopup(
            User.UserTypeEnum userTypeEnum)
        {
            //Verify The UserName In Support Popup
            Logger.LogMethodEntry("Notifications", "VerifyTheUserNameInSupportPopup",
                base.isTakeScreenShotDuringEntryExit);
            //Get User Name from Memory
            User user = User.Get(userTypeEnum);
            //Assert for user name present            
            Logger.LogAssertion("VerifySubmittedActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.Name, new CalendarHEDDefaultUXPage().
                    GetUserNameInSupportPopup()));
            Logger.LogMethodEntry("Notifications", "VerifyTheUserNameInSupportPopup",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Help PageText
        /// </summary>
        [Then(@"I should see the 'Welcome' link text")]
        public void VerifyTheHelpPageText()
        {
            //Verify The Help PageText
            Logger.LogMethodEntry("Notifications", "VerifyTheHelpPageText",
                base.isTakeScreenShotDuringEntryExit);
            //Verify Help PageText
            Logger.LogAssertion("VerifyHomePageText", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new TodaysViewUXPage().IsVerifyTheHelpLinkPageTextPresent()));    
            Logger.LogMethodExit("Notifications", "VerifyTheHelpPageText",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Submitted Activity Name.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should see the successfully submitted ""(.*)"" activity name")]
        public void VerifyTheSubmittedActivityName(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Verify The Submitted Activity Name
            Logger.LogMethodEntry("Notifications", "VerifyTheSubmittedActivityName",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert Submitted Activity name present            
            Logger.LogAssertion("VerifyTheSubmittedActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new TodaysViewUXPage().GetSubmittedActivityNameByStudent()));
            Logger.LogMethodEntry("Notifications", "VerifyTheSubmittedActivityName",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Click View Submission Cmenu Option
        /// </summary>       
        [When(@"I click the cmenu option 'ViewAllSubmissions' in student side")]
        public void ClickViewSubmissionCmenuOption()
        {
            // Click View Submission Cmenu Option
            Logger.LogMethodEntry("Notifications", "ClickViewSubmissionCmenuOption",
                base.isTakeScreenShotDuringEntryExit);
            //Click The View Submission Cmenu Option
            new TodaysViewUXPage().ClickTheViewSubmissionCmenuOption();                             
            Logger.LogMethodEntry("Notifications", "ClickViewSubmissionCmenuOption",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Grade in ViewSubmission Page
        /// </summary>
        /// <param name="newGrade">This is score</param>
        [Then(@"I should see the grade ""(.*)"" in view submission page")]
        public void VerifyTheGradeInViewSubmissionPage(String newGrade)
        {            
            //Verify the Grade in ViewSubmission Page
            Logger.LogMethodEntry("Notifications", "VerifyTheGradeInViewSubmissionPage",
                base.isTakeScreenShotDuringEntryExit);
            //Click on Submission Grade          
            new ViewSubmissionPage().ClickonSubmissionGrade();
            //Assert Edited Grade in ViewSubmission Page
            Logger.LogAssertion("VerifyGradeinViewSubmission", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(newGrade,
                    new ViewSubmissionPage().GetGradeInStudentViewSubmissionPage()));
            Logger.LogMethodExit("Notifications", "VerifyTheGradeInViewSubmissionPage",
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
