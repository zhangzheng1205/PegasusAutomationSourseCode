using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducation.HSS.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of GradeBook page 
    /// and handles Pegasus GradeBook Page Actions.
    /// </summary>
    [Binding]
    public class GradeBook : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(GradeBook));

        /// <summary>
        /// Click On Cmenu Of Asset In Gradebook.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu type enum.</param>
        /// <param name="assetName">This is Asset name.</param>
        [When(@"I click on cmenu option ""(.*)"" of asset ""(.*)""")]
        public void ClickOnCmenuOfAssetInGradebookHED(string assetCmenu,
            string assetName)
        {
            //Click On Cmenu Of Asset In Gradebook
            Logger.LogMethodEntry("GradeBook", 
                "ClickOnCmenuOfAssetInGradebookHED",
                  IsTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Select Frame
            gbInstructorPage.SelectGradebookFrame();
            //Select The Cmenu Option Of Asset
            gbInstructorPage.SelectTheCmenuOptionOfAssetHED(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), assetName);
            Logger.LogMethodExit("GradeBook", 
                "ClickOnCmenuOfAssetInGradebookHED",
                 IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on cmenu option in gradebook.
        /// </summary>
        /// <param name="assetCmenu">This is cmenu option.</param>
        /// <param name="assetName">This is asset name.</param>
        [When(@"I click on cmenu option ""(.*)"" of asset ""(.*)"" in grades tab")]
        public void ClickOnCmenuOptionOfAssetInGradesTab(string assetCmenu,
            string assetName)
        {
            //Click On Cmenu Of Asset In Gradebook
            Logger.LogMethodEntry("GradeBook",
                "ClickOnCmenuOfAssetInGradebookHED",
                  IsTakeScreenShotDuringEntryExit);
            //Click On Cmenu Of Asset In Gradebook
            new GBStudentUXPage().SelectCmenuOptionOnactivity(assetCmenu, assetName);
            Logger.LogMethodExit("GradeBook", 
                "ClickOnCmenuOfAssetInGradebookHED",
                 IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify Student Submission Score In ViewSubmission Page.
        /// </summary>
        /// <param name="submissionScore">This is Submission Score.</param>
        [Then(@"I should see ""(.*)"" score in view submission page for a student ""(.*)""")]
        public void VerifyStudentSubmissionScoreInViewSubmissionPage
            (string submissionScore, User.UserTypeEnum userTypeEnum)
        {
            // Verify Student Submission Score In ViewSubmission Page
            Logger.LogMethodEntry("Gradebook", 
                "VerifyStudentSubmissionScoreInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (submissionScore, new ViewSubmissionPage().
                 GetSubmissionScoreByStudent(user.LastName, user.FirstName)));
            Logger.LogMethodExit("Gradebook",
                "VerifyStudentSubmissionScoreInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search student from student frame of view submission page.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        [Then(@"I should search student ""(.*)"" from student frame in view submission page")]
        public void SearchStudentFromStudentFrameInViewSubmissionPage
            (User.UserTypeEnum userTypeEnum)
        {
            //Select Button In View Submission Page
            Logger.LogMethodEntry("Gradebook",
                "SearchStudentFromStudentFrameInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            // Search the particular student and perform click for that
            new ViewSubmissionPage().ClickStudent(new ViewSubmissionPage().
                SearchStudentByLastAndFirstName(user.LastName, user.FirstName));
            Logger.LogMethodExit("Gradebook", 
                "SearchStudentFromStudentFrameInViewSubmissionPage",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Options In ViewSubmission Page (ex Accept, Decline and etc.,).
        /// </summary>
        /// <param name="declineOption">This is Decline Option.</param>
        /// <param name="acceptOption">This is Accept Option.</param>
        [Then(@"I should see ""(.*)"" and ""(.*)"" options in instructor view submission page")]
        public void VerifyOptionsInViewSubmissionPageInstructor
            (string declineOption, string acceptOption)
        {
            //Verify Options In ViewSubmission Page
            Logger.LogMethodEntry("Gradebook", 
                "VerifyOptionsInViewSubmissionPageInstructor",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify 'Decline' and 'Accept' Option Displayed in View Submission Page
            new ViewSubmissionPage().
                IsDeclineAcceptOptionDisplayedInstructor(declineOption, acceptOption);
            Logger.LogMethodExit("Gradebook", 
                "VerifyOptionsInViewSubmissionPageInstructor",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Button In View Submission Page.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        [When(@"I select the option ""(.*)"" in view submission page")]
        public void SelectButtonInViewSubmissionPage(string buttonName)
        {
            //Select Button In View Submission Page
            Logger.LogMethodEntry("Gradebook", 
                "SelectButtonInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Button In View Submission Page
            new ViewSubmissionPage().ClickOnButtonInViewSubmissionPage(buttonName);
            Logger.LogMethodExit("Gradebook",
                "SelectButtonInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get student score and validate.
        /// </summary>
        /// <param name="score">This is the expected score.</param>
        [Then(@"I should see ""(.*)"" score in view submission page")]
        public void ValidateStudentScore(string score)
        {
            //Select Button In View Submission Page
            Logger.LogMethodEntry("Gradebook", 
                "ShouldSeeScoreInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (score, new ViewSubmissionPage().GetStudentScore()));
            Logger.LogMethodExit("Gradebook", 
                "ShouldSeeScoreInViewSubmissionPage",
            base.IsTakeScreenShotDuringEntryExit);
        }

       
    }
}
