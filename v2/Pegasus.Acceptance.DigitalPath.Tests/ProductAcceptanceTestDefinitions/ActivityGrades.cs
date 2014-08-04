#region

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
