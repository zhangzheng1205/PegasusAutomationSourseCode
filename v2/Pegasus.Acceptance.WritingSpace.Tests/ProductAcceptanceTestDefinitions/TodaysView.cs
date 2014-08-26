using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.WritingSpace.Tests.ProductAcceptanceTestDefinitions
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
        [When(@"I click on 'New Grades' alert option")]
        public void ClickNewGradesAlertOption()
        {
            //Clicking the New Grades link
            Logger.LogMethodEntry("TodaysView", "ClickNewGradesAlertOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            new CourseHomeListItemViewPage().SelectCourseHomeWindow();          
            //Click on the New Grades Link
            new TodaysViewUxPage().ClickNewGradesOption();
            Logger.LogMethodExit("TodaysView", "ClickNewGradesAlertOption",
                base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Verify Display of Writingspace Assessment in New Grades.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should not see the ""(.*)"" assessment")]
        public void VerifyDisplayofWritingspaceAssessmentInNewGrades(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Display of Writingspace Assessment in New Grades
            Logger.LogMethodEntry("TodaysView",
                "VerifyDisplayofWritingspaceAssessmentInNewGrades",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Activity
            Activity activity = Activity.Get(activityTypeEnum);
           // Assert Display of Writingspace Assessment in New Grades
            Logger.LogAssertion("VerifyDisplayofWritingspaceAssessmentInNewGrades",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreNotEqual(activity.Name,new TodaysViewUxPage().
                    GetWritingspaceAssessmentInNewGrades(activity.Name)));
            Logger.LogMethodExit("TodaysView",
                "VerifyDisplayofWritingspaceAssessmentInNewGrades",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display of Writingspace Assessment In New Grades For Student.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should not see the ""(.*)"" assessment for student")]
        public void VerifyDisplayofWritingspaceAssessmentInNewGradesForStudent(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify The Display of Writingspace Assessment in New Grades for Student
            Logger.LogMethodEntry("TodaysView",
                "VerifyDisplayofWritingspaceAssessmentInNewGradesForStudent",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Activity
            Activity activity = Activity.Get(activityTypeEnum);
            // Assert Display of Writingspace Assessment in New Grades for Student
            Logger.LogAssertion("VerifyDisplayofWritingspaceAssessmentInNewGradesforStudent",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreNotEqual(activity.Name, new TodaysViewUxPage().
                    GetWritingspaceAssessmentInNewGradesForStudent(activity.Name)));
            Logger.LogMethodExit("TodaysView",
                "VerifyDisplayofWritingspaceAssessmentInNewGradesForStudent",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display of Writingspace Assessment In Course Performance Channel.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should not see the ""(.*)"" assessment in course performance channel")]
        public void VerifyDisplayofWritingspaceAssessmentInCoursePerformance(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Display of Writingspace Assessment In Course Performance Channel
            Logger.LogMethodEntry("TodaysView",
                "VerifyDisplayofWritingspaceAssessmentInCoursePerformance",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Activity
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert Display of Writingspace Assessment in Course Performance Channel
            Logger.LogAssertion("VerifyDisplayofAssessmentinCoursePerformanceChannel",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreNotEqual(activity.Name,new TodaysViewUxPage().
                    GetAssessmentInCoursePerformance(activity.Name)));
            Logger.LogMethodExit("TodaysView",
                "VerifyDisplayofWritingspaceAssessmentInCoursePerformance",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Performance Channel Option.
        /// </summary>
        /// <param name="channelOption">This is Channel Option.</param>
        [When(@"I click on the ""(.*)"" option")]
        public void ClickOnPerformanceChannelOption(string channelOption)
        {
            //Click On Performance Channel Option
            Logger.LogMethodEntry("TodaysView", "ClickOnPerformanceChannelOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Performance channel Option
            new TodaysViewUxPage().ClickonNotificationChannelOption(channelOption);
            Logger.LogMethodExit("TodaysView", "ClickOnPerformanceChannelOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display of Writingspace Assessment In Student Performance Channel.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should not see the ""(.*)"" assessment in student performance channel")]
        public void VerifyDisplayofWritingspaceAssessmentInStudentPerformance(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Display of Writingspace Assessment In Student Performance Channel
            Logger.LogMethodEntry("TodaysView",
                "VerifyDisplayofWritingspaceAssessmentInStudentPerformance",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Activity
            Activity activity = Activity.Get(activityTypeEnum);
            //Get MMND Student
            User mmndStudent = User.Get(User.UserTypeEnum.MMNDStudent);
            //Assert Display of Writingspace Assessment in Student Performance Channel
            Logger.LogAssertion("VerifyDisplayofAssessmentinStudentPerformanceChannel",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreNotEqual(activity.Name,new TodaysViewUxPage().
                    GetAssessmentInStudentPerformance(activity.Name, mmndStudent.FirstName)));
            Logger.LogMethodExit("TodaysView",
                "VerifyDisplayofWritingspaceAssessmentInStudentPerformance",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display of Writingspace Assessment in My Progress Channel.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [Then(@"I should not see the ""(.*)"" assessment in 'My Progress' channel")]
        public void VerifyDisplayofWritingspaceAssessmentInMyProgress(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Display of Writingspace Assessment in My Progress Channel
            Logger.LogMethodEntry("TodaysView",
                "VerifyDisplayofWritingspaceAssessmentInMyProgress",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Activity
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert Display of Writingspace Assessment in My Progress Channel
            Logger.LogAssertion("VerifyDisplayofAssessmentinMyProgressChannel",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreNotEqual(activity.Name,new TodaysViewUxPage().
                    GetWritingspaceAssessmentInMyProgress(activity.Name)));
            Logger.LogMethodExit("TodaysView",
                "VerifyDisplayofWritingspaceAssessmentInMyProgress",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
