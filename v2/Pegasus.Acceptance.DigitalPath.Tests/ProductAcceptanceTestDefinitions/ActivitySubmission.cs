#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.DRT;
using TechTalk.SpecFlow;
using System.Threading;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class has functionality to submit the activity in course space.
    /// </summary>
    [Binding]
    public class ActivitySubmission : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ActivitySubmission));

        /// <summary>
        /// Open the activity in view all content tab.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I open ""(.*)"" activity")]
        public void OpenActivityfromToDo(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Open the Activity in Different Tab's
            Logger.LogMethodEntry("ActivitySubmission", "OpenTheActivity",
              base.IsTakeScreenShotDuringEntryExit);
            //Fetctb Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            string activityName = activity.Name.ToString();
            //Select Content Window
            new CoursePreviewUXPage().LaunchAssetFromToDoTab(activityName);
            Logger.LogMethodEntry("ActivitySubmission", "OpenTheActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open the activity in view all content tab.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I open the activity named as ""(.*)""")]
        public void OpenTheActivity(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Open the Activity in Different Tab's
            Logger.LogMethodEntry("ActivitySubmission", "OpenTheActivity",
              base.IsTakeScreenShotDuringEntryExit);
            //Fetctb Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Content Window
            new CoursePreviewMainUXPage().SelectContentWindow();
            //Click To Open Activity
            new CoursePreviewMainUXPage().
                ClickActivityInViewAllContentTab(activity.Name);
            Logger.LogMethodEntry("ActivitySubmission", "OpenTheActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        ///// <summary>
        ///// Open the activity in To Do tab.
        ///// </summary>
        ///// <param name="activityTypeEnum">This is the Activity Type Enum</param>
        //[When(@"I open the activity named as ""(.*)"" from To Do tab")]
        //public void OpenActivityFromToDo(Activity.ActivityTypeEnum activityTypeEnum)
        //{
        //    Logger.LogMethodEntry("ActivitySubmission", "OpenActivityFromToDo",
        //       base.IsTakeScreenShotDuringEntryExit);
        //    //Fetctb Activity From Memory
        //    Activity activity = Activity.Get(activityTypeEnum);
        //    //Select Content Window
        //    new CoursePreviewMainUXPage().SelectContentWindow();
        //    //Click To Open Activity
        //    new CoursePreviewMainUXPage().
        //        ClickActivityInToDoTab(activity.Name);
        //    Logger.LogMethodExit("ActivitySubmission", "OpenActivityFromToDo",
        //       base.IsTakeScreenShotDuringEntryExit);
        //}

        /// <summary>
        /// Submit the activity after launching it.
        /// </summary>
        /// <param name="activityType">This is the activity type.</param>
        [When(@"I submit the ""(.*)"" activity")]
        public void SubmitTheActivity(String activityType)
        {
            //Submit the Activity
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheActivity",
             base.IsTakeScreenShotDuringEntryExit);
            //Created Class Object
            StudentPresentationPage studentpresentationpage =
                new StudentPresentationPage();
            //Attempt The Activity
            studentpresentationpage.AttemptTheActivityInDigitalPath(activityType);
            //Finish and return to course selection
            studentpresentationpage.FinishAndReturnToCourse();
            // select close button on the Test window
            new InstructionsPage().ClickTestCloseButton();
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheActivity",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Start pre test from study plan window.
        /// </summary>
        [When(@"I start the Pre-Test")]
        public void StartPreTest()
        {
            //Start pre test
            Logger.LogMethodEntry("ActivitySubmission", "StartPreTest",
              base.IsTakeScreenShotDuringEntryExit);
            // Click on begin button
            new DrtDefaultUxPage().ClickBeginButton();
            // Click continue button on activity alert pop up
            new ShowMessagePage().ClickContinueInActivityAlert();
            Logger.LogMethodExit("ActivitySubmission", "StartPreTest",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click return to course button on study plan window.
        /// </summary>
        [When(@"I click return to course button")]
        public void ClickReturnToCourseButton()
        {
            //Select return to course button to go back to Content page
            Logger.LogMethodEntry("ActivitySubmission", "ClickReturnToCourseButton",
              base.IsTakeScreenShotDuringEntryExit);
            // Click on return to course button
            new DrtDefaultUxPage().ClickReturnToCourseButton();
            Logger.LogMethodExit("ActivitySubmission", "ClickReturnToCourseButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Status Of Assets In View All Content.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type enum.</param>
        /// <param name="activityStatus">This is Activity status.</param>
        [Then(@"I should see the status of ""(.*)"" assets as ""(.*)""")]
        public void StatusOfAssetsInViewAllContent(
        Activity.ActivityTypeEnum activityTypeEnum, String activityStatus)
        {
            //Status Of Assets In View All Content
            Logger.LogMethodEntry("ActivitySubmission",
            "StatusOfAssetsInViewAllContent", base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert the Activity Status
            Logger.LogAssertion("VerifyStatusOfActivity",
            ScenarioContext.Current.ScenarioInfo.Title,
            () => Assert.AreEqual(activityStatus, new CoursePreviewMainUXPage().
            GetStatusOfActivityInViewAllContentTab(activity.Name)));
            Logger.LogMethodExit("ActivitySubmission",
            "StatusOfAssetsInViewAllContent", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Study Plan Activity.
        /// </summary>
        [When(@"I submit the StudyPlan activity")]
        public void SubmitTheStudyPlanActivity()
        {
            //Submit The Study Plan Activity
            Logger.LogMethodEntry("ActivitySubmission", "SubmitTheStudyPlanActivity",
              base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            new StudentPresentationPage().SelectLastOpenedWindow();
            //Attempt The Activity            
            new StudentPresentationPage().SubmitActivity();
            Logger.LogMethodExit("ActivitySubmission", "SubmitTheStudyPlanActivity",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// See The Asset Displayed Under Tab.
        /// </summary>
        /// <param name="assetName">This is asset name.</param>
        /// <param name="underTabName">This is Tab name.</param>
        [Then(@"I should see ""(.*)"" displayed under ""(.*)"" tab")]
        public void SeeTheAssetDisplayedUnderTab(string assetName, string underTabName)
        {
            // see asset displayed under Tab
            Logger.LogMethodEntry("ActivitySubmission", "SeeTheAssetDisplayedUnderTab",
             base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("SeeTheAssetDisplayedUnderTab",
           ScenarioContext.Current.ScenarioInfo.Title,
           () => Assert.IsTrue(new CoursePreviewUXPage()
                .GetAssetNameDisplayedUnderTab(underTabName).Contains(assetName)));
            Logger.LogMethodExit("ActivitySubmission", "SeeTheAssetDisplayedUnderTab",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Button Next To The Study Plan.
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        /// <param name="assetName">This is asset name.</param>
        [When(@"I click on ""(.*)"" button next to the asset ""(.*)""")]
        public void ClickOnButtonNextToTheStudyPlan(string buttonName, string assetName)
        {
            // click on button next study plan
            Logger.LogMethodEntry("ActivitySubmission", "ClickOnButtonNextToTheStudyPlan",
            base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().
                ClickOnButtonNextToTheAsset(buttonName, assetName);
            Logger.LogMethodExit("ActivitySubmission", "ClickOnButtonNextToTheStudyPlan",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// See The Study Plan Page Will Be Opened With PreTest Study Material Frame.
        /// </summary>
        /// <param name="pageName">This is page name.</param>
        /// <param name="assetName">This is asset name.</param>
        [Then(@"I should see study plan page ""(.*)"" will be opened with ""(.*)"" pre test /Study Material frame")]
        public void SeeTheStudyPlanPageWillBeOpenedWithPreTestStudyMaterialFrame(string pageName, string assetName)
        {
            // see study plan page
            Logger.LogMethodEntry("ActivitySubmission", "SeeTheStudyPlanPageWillBeOpenedWithPreTestStudyMaterialFrame",
            base.IsTakeScreenShotDuringEntryExit);
            DrtDefaultUxPage drtDefaultUxPage = new DrtDefaultUxPage();
            Logger.LogAssertion("VerifyPreTestStudyMaterialName",
                 ScenarioContext.Current.ScenarioInfo.Title,
                 () => Assert.AreEqual(assetName, drtDefaultUxPage.GetStudyPlanAssetName(assetName)));
            Logger.LogAssertion("VerifyStudyPlanPageName",
                 ScenarioContext.Current.ScenarioInfo.Title,
                 () => Assert.AreEqual(pageName, drtDefaultUxPage.GetStudyPlanWindowTitle()));
            Logger.LogMethodExit("ActivitySubmission", "SeeTheStudyPlanPageWillBeOpenedWithPreTestStudyMaterialFrame",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button Under PreTest Frame.
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        [When(@"I click on ""(.*)"" button under pre test frame")]
        public void ClickOnButtonUnderPreTestFrame(string buttonName)
        {
            // click on button under pre test frame
            Logger.LogMethodEntry("ActivitySubmission", "ClickOnButtonUnderPreTestFrame",
          base.IsTakeScreenShotDuringEntryExit);
            new DrtDefaultUxPage().ClickOnButtonObject(buttonName);
            Logger.LogMethodExit("ActivitySubmission", "ClickOnButtonUnderPreTestFrame",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// See The Alert Message With Button.
        /// </summary>
        /// <param name="messageText">This is message.</param>
        /// <param name="buttonNameFirst">This is 1 button name.</param>
        /// <param name="buttonNameSecond">This is 2 button name.</param>
        [Then(@"I should see alert message ""(.*)"" with ""(.*)"" and ""(.*)"" button")]
        public void SeeTheAlertMessageWithButton(string messageText, string buttonNameFirst, string buttonNameSecond)
        {
            // see alert message with button
            Logger.LogMethodEntry("ActivitySubmission", "SeeTheAlertMessageWithButton",
            base.IsTakeScreenShotDuringEntryExit);
            ShowMessagePage showMessagePage = new ShowMessagePage();
            Logger.LogAssertion("VerifyActivityAlertMessage",
                   ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual
                       (messageText, showMessagePage.GetActivityAlertMessage()));
            Logger.LogAssertion("VerifyContinueButtonPresentInAlertWindow",
                   ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue
                       (showMessagePage.IsContinueButtonPresentInAlertWindow()));
            Logger.LogAssertion("VerifyCancelButtonPresentInAlertWindow",
                   ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue
                       (showMessagePage.IsCancelButtonPresentInAlertWindow()));
            Logger.LogMethodExit("ActivitySubmission", "SeeTheAlertMessageWithButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button In Activity Alert PopUp.
        /// </summary>
        /// <param name="alertButtonName">This is button name.</param>
        [When(@"I click on ""(.*)"" button in activity alert pop up")]
        public void ClickOnButtonInActivityAlertPopUp(string alertButtonName)
        {
            // click on button in activity alert pop up
            Logger.LogMethodEntry("ActivitySubmission", "ClickOnButtonInActivityAlertPopUp",
            base.IsTakeScreenShotDuringEntryExit);
            new ShowMessagePage().ClickContinueButtonInActivityAlertPopUp();
            Logger.LogMethodExit("ActivitySubmission", "ClickOnButtonInActivityAlertPopUp",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// See The PreTest Presentation Page Displayed.
        /// </summary>
        /// <param name="presentationPageTitle">This is page title.</param>
        [Then(@"I should see pre test presentation page ""(.*)"" should be displayed for ""(.*)"" student")]
        public void SeeThePreTestPresentationPageDisplayed(string presentationPageTitle, 
            User.UserTypeEnum userTypeEnum)
        {
            string windowTitle = string.Empty;
            User user = User.Get(userTypeEnum);
            windowTitle = presentationPageTitle + user.FirstName + " " + user.LastName;
             // see pre test presentation page displayed
            Logger.LogMethodEntry("ActivitySubmission", "SeeThePreTestPresentationPageDisplayed",
            base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyPresentationPageWindowTitle",
               ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue
            (new LTIToolLaunchPage().GetPresentationPageWindowTitle(windowTitle).Contains(windowTitle)));
            Logger.LogMethodExit("ActivitySubmission", "SeeThePreTestPresentationPageDisplayed",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Answer The Questions For Activity To Score.
        /// </summary>
        /// <param name="assetName">This is asset name.</param>
        /// <param name="scoreAchieve">This is score to schieve.</param>
        [When(@"I answer all the questions incorrectly for activity ""(.*)"" to score ""(.*)""")]
        public void AnswerTheQuestionsForActivityToScore(string assetName, string scoreAchieve)
        {
            // answer questions for activity to score
            Logger.LogMethodEntry("ActivitySubmission", "AnswerTheQuestionsForActivityToScore",
            base.IsTakeScreenShotDuringEntryExit);
            new MathxlPlayerTestPage().AttemptMgmActivity(assetName, scoreAchieve);
            Thread.Sleep(12000);
            Logger.LogMethodExit("ActivitySubmission", "AnswerTheQuestionsForActivityToScore",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// See The Page Displayed With Score And For Each Question.
        /// </summary>
        /// <param name="pageName">This is page name.</param>
        /// <param name="buttonName">This is button name.</param>
        [Then(@"I should see ""(.*)"" page should be displayed with score and for each question along with button ""(.*)""")]
        public void SeeThePageDisplayedWithScoreAndForEachQuestionAlongWithButton(string pageName, string buttonName)
        {
            // see page displayed with score and for each question
            Logger.LogMethodEntry("ActivitySubmission", "SeeThePageDisplayedWithScoreAndForEachQuestionAlongWithButton",
            base.IsTakeScreenShotDuringEntryExit);
            OverviewTestPage overviewTestPage = new OverviewTestPage();
            Logger.LogAssertion("VerifyPageDisplayed",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(pageName, overviewTestPage.GetPageName(pageName)));
            Logger.LogAssertion("VerifyButtonPresent",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(buttonName, overviewTestPage.GetButtonName()));
            Logger.LogMethodExit("ActivitySubmission", "SeeThePageDisplayedWithScoreAndForEachQuestionAlongWithButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button In Page.
        /// </summary>
        /// <param name="clickToButtonName">This is button name.</param>
        /// <param name="pageName">This is page name.</param>
        [When(@"I click on ""(.*)"" button in ""(.*)"" page")]
        public void ClickOnButtonInPage(string clickToButtonName, string pageName)
        {
            // click on button in page
            Logger.LogMethodEntry("ActivitySubmission", "ClickOnButtonInPage",
          base.IsTakeScreenShotDuringEntryExit);
            new OverviewTestPage().ClickOnButtonInPage(clickToButtonName, pageName);
            Logger.LogMethodExit("ActivitySubmission", "ClickOnButtonInPage",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// See The Control Navigate To Study Plan Page.
        /// </summary>
        /// <param name="achivedScore">This is achieved score.</param>
        [Then(@"I should see control navigate to study plan page and pre test score should be displayed as “(.*)%” under pre test frame")]
        public void SeeControlNavigateToStudyPlanPageAndPreTestAndScoreShouldBeDisplayedAsUnderPreTestFrame(int achivedScore)
        {
            // see control navigate study plan page
            Logger.LogMethodEntry("ActivitySubmission", "SeeControlNavigateToStudyPlanPageAndPreTestAndScoreShouldBeDisplayedAsUnderPreTestFrame",
            base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyPageDisplayed",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(achivedScore, new DrtDefaultUxPage().GetScoreInStudyPlanTestFrame()));
            Logger.LogMethodExit("ActivitySubmission", "SeeControlNavigateToStudyPlanPageAndPreTestAndScoreShouldBeDisplayedAsUnderPreTestFrame",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button In Study Plan Page.
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        [When(@"I click on ""(.*)"" button in study plan page")]
        public void ClickOnButtonInStudyPlanPage(string buttonName)
        {
            // click on button in study plan page
            Logger.LogMethodEntry("ActivitySubmission", "ClickOnButtonInStudyPlanPage",
            base.IsTakeScreenShotDuringEntryExit);
            new DrtDefaultUxPage().ClickOnButtonObject(buttonName);
            Logger.LogMethodExit("ActivitySubmission", "ClickOnButtonInStudyPlanPage",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// See The Submitted Activity Should Be Displayed In Tab.
        /// </summary>
        /// <param name="assetName">This is asset name.</param>
        /// <param name="underTabName">This is Tab name.</param>
        /// <param name="achievedScore">This is score value.</param>
        /// <param name="assetStatusButton">This is asset status button name.</param>
        /// <param name="buttonName">This is button name.</param>
        [Then(@"I should see submitted activity ""(.*)"" should be displayed in ""(.*)"" Tab as “(.*)%” score and status ""(.*)"" with ""(.*)"" button")]
        public void SeeSubmittedActivityShouldBeDisplayedInTabAsScoreAndStatusWithButton(string assetName, string underTabName, Decimal achievedScore, string assetStatusButton, string buttonName)
        {
            // see submitted activity in page
            Logger.LogMethodEntry("ActivitySubmission", "SeeSubmittedActivityShouldBeDisplayedInTabAsScoreAndStatusWithButton",
           base.IsTakeScreenShotDuringEntryExit);
            CoursePreviewUXPage coursePreviewUxPage = new CoursePreviewUXPage();
            Logger.LogAssertion("VerifySubmissionScore", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(achievedScore, coursePreviewUxPage.GetAssetScore(assetName, underTabName)));
            Logger.LogAssertion("VerifyTryAgainButtonPresent", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(buttonName, coursePreviewUxPage.GetTryAgainButtonText()));
            Logger.LogAssertion("VerifyImDoneButtonPresent", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(assetStatusButton, coursePreviewUxPage.GetImDoneButtonText()));
            Logger.LogMethodEntry("ActivitySubmission", "SeeSubmittedActivityShouldBeDisplayedInTabAsScoreAndStatusWithButton",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetName">This is asset name.</param>
        /// <param name="underTabName">This is Tab name.</param>
        /// <param name="achievedScore">This is score value.</param>
        /// <param name="buttonName">This is button name.</param>
        [Then(@"I should see submitted activity ""(.*)"" should be displayed in ""(.*)"" Tab as “(.*)” score with ""(.*)"" button")]
        public void VerifySubmittedActivityScoreAndStatus(string assetName, string underTabName, string achievedScore, string buttonName)
        {
            Logger.LogMethodEntry("ActivitySubmission", "VerifySubmittedActivityScoreAndStatus",
         base.IsTakeScreenShotDuringEntryExit);
            CoursePreviewUXPage coursePreviewUxPage = new CoursePreviewUXPage();
            Logger.LogAssertion("VerifySubmissionScore", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(achievedScore, coursePreviewUxPage.GetAssetScore(assetName, underTabName)));
            Logger.LogAssertion("VerifyTryAgainButtonPresent", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(buttonName, coursePreviewUxPage.GetTryAgainButtonText()));
            base.SelectDefaultWindow();
            Logger.LogMethodEntry("ActivitySubmission", "VerifySubmittedActivityScoreAndStatus",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the activity is submitted in To Do tab when status is not enabled
        /// </summary>
        /// <param name="buttonName"></param>
        [Then(@"I should see submitted activity ""(.*)"" button")]
        public void VerifyActivityIsSubmittedInToDo(string buttonName)
        {
            Logger.LogMethodEntry("ActivitySubmission", "VerifySubmittedActivityScoreAndStatus",
                base.IsTakeScreenShotDuringEntryExit);
            CoursePreviewUXPage coursePreviewUxPage = new CoursePreviewUXPage();
            Logger.LogAssertion("VerifyTryAgainButtonPresent", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(buttonName, coursePreviewUxPage.GetTryAgainButtonText()));
            base.SelectDefaultWindow();
            Logger.LogMethodEntry("ActivitySubmission", "VerifySubmittedActivityScoreAndStatus",
           base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
