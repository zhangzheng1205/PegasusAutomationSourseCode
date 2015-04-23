﻿#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using System;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class has functionality to view grades.
    /// </summary>
    [Binding]
    public class ActivityGrades : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(ActivityGrades));

        /// <summary>
        ///Verify The Grade In View Submission Page. 
        /// </summary>       
        [Then(@"I should see the 'Grade' in View Submission page")]
        public void VerifyTheGradeInViewSubmissionPage()
        {
            //Verify The Grade In View Submission Page  
            Logger.LogMethodEntry("ActivityGrades",
                "VerifyTheGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert for score
            Logger.LogAssertion("VerifyTheScore", ScenarioContext.
                Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(ActivityGradesResource.
                ActivityGrades_ViewSubmission_Score_Value,
                 new ViewSubmissionPage().GetScoreResultInViewSubmissionPage()));           
            Logger.LogMethodExit("ActivityGrades",
                "VerifyTheGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }
    
        /// <summary>
        /// Verify The Grade In GradeBook Page.
        /// </summary>
        /// <param name="assetTypeEnum">This is Asset type by enum.</param>
        [Then(@"I should see the ""(.*)"" for 'Grade' in GradeBook tab")]
        public void VerifyTheGradeInGradeBookPage(
            Activity.ActivityTypeEnum assetTypeEnum)
        {
            //Verify The Grade In GradeBook Page
            Logger.LogMethodEntry("ActivityGrades",
                "VerifyTheGradeInGradeBookPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert for Grade
            Logger.LogAssertion("VerifyTheScore", ScenarioContext.
                Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(ActivityGradesResource.
                ActivityGrades_ViewSubmission_Score_Value,
                 new GBStudentUXPage().
                 GetScoreResultInGradeBookPage(assetTypeEnum)));
            Logger.LogMethodExit("ActivityGrades",
                "VerifyTheGradeInGradeBookPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
       ///Click On The Grades Tab Cmenu Option.
        /// </summary>      
        /// <param name="activityTypeEnum">This is asset type enum.</param>     
        [When(@"I click on the ""(.*)"" cmenu option")]       
       public void ClickOnTheGradesTabCmenuOption(
            Activity.ActivityTypeEnum activityTypeEnum)
       {
           //Click On The Grades Tab Cmenu Option  
           Logger.LogMethodEntry("ActivityGrades",
               "ClickOnTheGradesTabCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
           //Click The Grades Tab Cmenu Option          
           new ViewSubmissionPage().
               ClickTheGradesTabCmenuOption(activityTypeEnum);
           Logger.LogMethodExit("ActivityGrades",
               "ClickOnTheGradesTabCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
       }
       
        /// <summary>
       /// Check The Assets Name In Grades Tab.
        /// </summary>       
        /// <param name="activityTypeEnum">This is Asset type enum.</param>     
        [When(@"I check the ""(.*)"" in Grades Tab")]
       public void CheckTheAssetsNameInGradesTab(
            Activity.ActivityTypeEnum activityTypeEnum)
       {
           // Check The Assets Name In Grades Tab
           Logger.LogMethodEntry("ActivityGrades","CheckTheAssetsNameInGradesTab",
               base.IsTakeScreenShotDuringEntryExit);
           //Check The Asset Name Contains In Grades Tab       
           new ViewSubmissionPage().
               CheckTheAssetNameContainsInGradesTab(activityTypeEnum);
           Logger.LogMethodExit("ActivityGrades","CheckTheAssetsNameInGradesTab",
               base.IsTakeScreenShotDuringEntryExit);
       }

        /// <summary>
        /// Open The StudyPaln Activity In Grades Tab.
        /// </summary>
        /// <param name="activityTypeEnum">This is Asset type enum.</param>
        [When(@"I open the activity named as ""(.*)"" in Grades Tab")]
        public void OpenTheStudyPalnActivityInGradesTab(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Open The StudyPaln Activity In Grades Tab
            Logger.LogMethodEntry("ActivityGrades", 
                "OpenTheStudyPalnActivityInGradesTab",
               IsTakeScreenShotDuringEntryExit);
            //Check The Asset Name Contains In Grades Tab       
            new ViewSubmissionPage().
                CheckTheAssetNameContainsInGradesTab(activityTypeEnum);
            Logger.LogMethodExit("ActivityGrades", 
                "OpenTheStudyPalnActivityInGradesTab",
                IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click On Cmenu Of Asset In Gradebook.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu type enum</param>
        /// <param name="assetName">This is Asset name</param>
        [When(@"I click on cmenu option ""(.*)"" of asset ""(.*)""")]
        public void ClickOnCmenuOfAssetInGradebookDP(string assetCmenuOption,
            string assetName)
        {
            //Click On Cmenu Of Asset In Gradebook
            Logger.LogMethodEntry("GradeBook", "ClickOnCmenuOfAssetInGradebookHed",
                  IsTakeScreenShotDuringEntryExit);
            GBDefaultUXPage gbDefaultUXPage = new GBDefaultUXPage();
            //Select The Cmenu Option Of Asset
            new GBStudentUXPage().SelectCmenuOptionOnactivity(assetCmenuOption, assetName);
            //gbDefaultUXPage.SelectTheCmenuOptionOfAssetK12(assetCmenuOption, assetName);
            Logger.LogMethodExit("GradeBook", "ClickOnCmenuOfAssetInGradebookHed",
                 IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on View Grades button of the asset in the gradebook
        /// </summary>
        /// <param name="assetName">This is Asset name</param>
        [When(@"I click on View Grades button of asset ""(.*)""")]
        public void ClickViewGradesButtonOfAsset(string assetName)
        {
            // click on View Grades button
            Logger.LogMethodEntry("ActivityGrades", "ClickViewGradesButtonOfAsset",
                  IsTakeScreenShotDuringEntryExit);
            GBDefaultUXPage gbDefaultUXPage = new GBDefaultUXPage();
            gbDefaultUXPage.ClickViewGradesButton(assetName);
            Logger.LogMethodExit("ActivityGrades", "ClickViewGradesButtonOfAsset",
                  IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Verify Student Submission Score In ViewSubmission Page.
        /// </summary>
        /// <param name="submissionScore">This is Submission Score.</param>
        [Then(@"I should see ""(.*)"" score in view submission page")]
        public void VerifyStudentSubmissionScoreInViewSubmissionPage(string submissionScore)
        {
            // Verify Student Submission Score In ViewSubmission Page
            Logger.LogMethodEntry("Gradebook", "VerifyStudentSubmissionScoreInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (submissionScore, new ViewSubmissionPage().GetSubmissionScoreInViewSubmissionPage()));
            Logger.LogMethodExit("Gradebook", "VerifyStudentSubmissionScoreInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on View Submission Cmenu option of the Asset
        /// </summary>
        /// <param name="cmenuName">This is Cmenu option name.</param>
        /// <param name="activityName">This is activity name.</param>
        [When(@"I click on cmenu option ""(.*)"" of the asset ""(.*)""")]
        public void ClickViewSubmissionCmenuOptionOfAsset(string cmenuName, string activityName)
        {
            Logger.LogMethodEntry("Gradebook", "ClickViewSubmissionCmenuOptionOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
            // Click "View All Submissions" for the specified activity in gradebookK12
            GBDefaultUXPage gbDefaultUXPage = new GBDefaultUXPage();
            gbDefaultUXPage.ClickViewAllSubmissionsInGradebookK12(cmenuName, activityName);
            Logger.LogMethodEntry("Gradebook", "ClickViewSubmissionCmenuOptionOfAsset",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click view submission cmenu option for Studyplan
        /// </summary>
        /// <param name="cmenuName">This is the Cmenu option name.</param>
        /// <param name="activityName">This is Activity name.</param>
        [When(@"I click on cmenu option ""(.*)"" of Studyplan asset ""(.*)""")]
        public void ClickViewSubmissionCmenuOptionOfStudyplanAsset(string cmenuName, string activityName)
        {
            Logger.LogMethodEntry("Gradebook", "ClickViewSubmissionCmenuOptionOfStudyplanAsset",
                base.IsTakeScreenShotDuringEntryExit);
            // Click "View All Submissions" for the specified activity in gradebookK12
            GBDefaultUXPage gbDefaultUXPage = new GBDefaultUXPage();
            gbDefaultUXPage.ClickViewAllSubmissionsForStudyPlan(cmenuName, activityName);
            Logger.LogMethodEntry("Gradebook", "ClickViewSubmissionCmenuOptionOfStudyplanAsset",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify Edited Submission Score In ViewSubmission Page.
        /// </summary>
        /// <param name="submissionScore">This is Submission Score.</param>
        [Then(@"I should see ""(.*)"" score in the view submission page for a student ""(.*)""")]
        public void VerifyEditedScoreInViewSubmissionPage
            (string submissionScore, User.UserTypeEnum userTypeEnum)
        {
            // Verify Student Submission Score In ViewSubmission Page
            Logger.LogMethodEntry("ActivityGrades",
                "VerifyEditedScoreInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            //Assert Grades of Submitted Activity
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (submissionScore, new ViewSubmissionPage().
                 GetEditedSubmissionScore(user.LastName, user.FirstName)));
            Logger.LogMethodExit("ActivityGrades",
                "VerifyEditedScoreInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click View grade option of Studyplan in Gradebook.
        /// </summary>
        /// <param name="studyPlanName">This is studyplan name.</param>
        [When(@"I click on view grade option of ""(.*)"" in Gradebook")]
        public void ClickViewGradeOptionInGradebook(string studyPlanName)
        {
            // Click view grade button of Study plan in the Gradebook
            Logger.LogMethodEntry("ActivityGrades",
               "ClickViewGradeOptionInGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            GBDefaultUXPage gbDefaultUXPage = new GBDefaultUXPage();
            gbDefaultUXPage.ClickViewGradeOptionforStudyPlan(studyPlanName);
            Logger.LogMethodEntry("ActivityGrades",
               "ClickViewGradeOptionInGradebook",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search an asset at Gradebook in DP.
        /// </summary>
        /// <param name="assetName">This is the Asset name.</param>
        [When(@"I search ""(.*)"" in Gradebook")]
        public void WhenISearchInGradebook(string assetName)
        {
            //Search an asset at Gradebook in DP
            Logger.LogMethodEntry("ActivityGrades",
             "WhenISearchInGradebook",
             base.IsTakeScreenShotDuringEntryExit);
            //Search an asset at Gradebook in DP
            GBDefaultUXPage gbDefaultUXPage = new GBDefaultUXPage();
            gbDefaultUXPage.SearchAssetInDPInstructorGradebook(assetName);
            Logger.LogMethodEntry("ActivityGrades",
              "WhenISearchInGradebook",
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
