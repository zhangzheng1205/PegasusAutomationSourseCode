using TechTalk.SpecFlow;
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Acceptance.MyTest.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handle all functionality of Activity submission Page.
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
        /// Open The Activity In Course Materials.
        /// </summary>
        /// <param name="activityTypeEnum">This is actvity type enum.</param>
        [When(@"I open the ""(.*)"" activity in Course Materials")]
        public void OpenTheActivityInCourseMaterials(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Open The Activity In Course Materials
            Logger.LogMethodEntry("ActivitySubmission",
                "OpenTheActivityInCourseMaterials",
                  base.isTakeScreenShotDuringEntryExit);
            //Fetch the activity from memory
            Activity activity = Activity.Get(activityTypeEnum);
            new CoursePreviewMainUXPage().
                OpenTheActivityInStudentCourseMaterials(activity.Name);
            Logger.LogMethodExit("ActivitySubmission",
                "OpenTheActivityInCourseMaterials",
                  base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Submit The Activty In Course Materials Tab.
        /// </summary>
        [When(@"I submit the Activty")]
        public void SubmitTheActivtyInCourseMaterialsTab()
        {
            // Submit The Activty In Course Materials Tab
            Logger.LogMethodEntry("ActivitySubmission", 
                "SubmitTheActivtyInCourseMaterialsTab",
                  base.isTakeScreenShotDuringEntryExit);
            // Submit The Activty In Course Materials Tab
            new StudentPresentationPage().SubmitTheActivityInCourseMaterialsTab();
            Logger.LogMethodExit("ActivitySubmission", 
                "SubmitTheActivtyInCourseMaterialsTab",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Try Again Button In Submission Page.
        /// </summary>
        /// <param name="tryAgainButton">This is Try Again Button.</param>
        [Then(@"I should see the 'Try Again' button in submission page")]
        public void VerifyTheTryAgainButtonInSubmissionPage()
        {
            // Submit The Activty In Course Materials Tab
            Logger.LogMethodEntry("ActivitySubmission", 
                "VerifyTheTryAgainButtonInSubmissionPage",
                  base.isTakeScreenShotDuringEntryExit);
            //Asserts the Try Again Button
            Logger.LogAssertion("VerifyTryAgainButton",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new StudentPresentationPage().
                    IsDisplayedTryAgainBttonInSubmissionPage()));  
            Logger.LogMethodExit("ActivitySubmission", 
                "VerifyTheTryAgainButtonInSubmissionPage",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display The Grades For Submitted Activity.
        /// </summary>
        [Then(@"I should see the 'MyTest' activity score in Gradebook")]
        public void DisplayTheGradesForSubmittedActivity()
        {
            //Display The Grades For Submitted Activity
            Logger.LogMethodEntry("ActivitySubmission",
                "DisplayTheGradesForSubmittedActivity",
                  base.isTakeScreenShotDuringEntryExit);
            //Creating object
            GBStudentUXPage gBStudentUXPage = new GBStudentUXPage();
            //Selecting the window
            gBStudentUXPage.SelectGradebookWindow();
                //Assert we have correct message displayed
            Logger.LogAssertion("VerifySbmittedActivityScore",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(ActivitySubmissionResource.
                    ActivitySubmission_Page_Grade_Score,
                    gBStudentUXPage.GetAssetScoreInGradeBook(
                    ActivitySubmissionResource.
                    ActivitySubmission_Page_MyTest_Activity_Name)));
            Logger.LogMethodExit("ActivitySubmission",
               "DisplayTheGradesForSubmittedActivity",
                 base.isTakeScreenShotDuringEntryExit);
        }
    }
}
