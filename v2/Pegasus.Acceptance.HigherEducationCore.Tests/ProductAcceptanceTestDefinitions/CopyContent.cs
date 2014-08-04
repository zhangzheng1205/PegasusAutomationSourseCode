using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles Actions Related to 'Copy Content'.
    /// </summary>
    [Binding]
    public class CopyContent : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(CopyContent));

        /// <summary>
        /// Click On Tab From Preferences.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>
        [When(@"I navigate back to the ""(.*)"" tab")]
        public void ClickOnTabFromPreferences(String tabName)
        {
            //Click On Tab From Preferences
            Logger.LogMethodEntry("CopyContent",
                "ClickOnTabFromPreferences",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Tab From Preferences
            new CourseCopyPreferencesPage().
                ClickOnTabFromPreferences(tabName);
            Logger.LogMethodExit("CopyContent", 
                "ClickOnTabFromPreferences",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of 'Copy Content' Option Text.
        /// </summary>
        /// <param name="copyContentOptionText">
        /// This is Copy Content option Text</param>
        [Then(@"I should see the ""(.*)"" option displayed in the 'Course Materials' tab")]
        public void DisplayOfCopyContentOptionText(String copyContentOptionText)
        {
            //Display Of 'Copy Content' Option Text
            Logger.LogMethodEntry("CopyContent", 
                "DisplayOfCopyContentOptionText",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert The Display Of 'Copy Content' Option Text
            Logger.LogAssertion("VerifyTheDisplayOfCopyContentOptionText",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(copyContentOptionText,
                    new TeachingPlanUxPage().
                    GetTheCopyContentOptionTextDisplayed()));            
            Logger.LogMethodExit("CopyContent",
                "DisplayOfCopyContentOptionText",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the 'Change Source' option.
        /// </summary>
        [When(@"I click on the 'Change Source' option")]
        public void ClickOnTheChangeSourceOption()
        {
            //Click on the 'Change Source' option
            Logger.LogMethodEntry("CopyContent",
                "ClickOnTheChangeSourceOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the 'Change Source' option
            new TeachingPlanUxPage().ClickOnTheChangeSourceOption();
            Logger.LogMethodExit("CopyContent",
                "ClickOnTheChangeSourceOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Target Course In The Copy Content Dropdown.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [Then(@"I should see the ""(.*)"" source course in the dropdown")]
        public void DisplayOfTargetCourseInTheCopyContentDropdown(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Display Of Target Course In The Copy Content Dropdown
            Logger.LogMethodEntry("CopyContent",
                "DisplayOfTargetCourseInTheCopyContentDropdown",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the Course
            Course course = Course.Get(courseTypeEnum);
            //Assert The Display Of Target Course In The Copy Content Dropdown
            Logger.LogAssertion("VerifyTheDisplayOfCopyContentOptionText",
                ScenarioContext.Current.ScenarioInfo.Title,() => Assert.AreEqual(course.Name,
                    new CourseBrowserPage().GetTheTargetCourseDisplayed(course.Name)));
            Logger.LogMethodExit("CopyContent", 
                "DisplayOfTargetCourseInTheCopyContentDropdown",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Source Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is 
        /// Course Type Enum</param>
        [When(@"I click on the ""(.*)"" source course")]
        public void ClickOnTheSourceCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Click On The Source Course
            Logger.LogMethodEntry("CopyContent", 
                "ClickOnTheSourceCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the Course Name
            Course course = Course.Get(courseTypeEnum);
            //Click On the Source Course
            new CourseBrowserPage().
                SelectTheSourceCourseForCopyContent(course.Name);
            Logger.LogMethodExit("CopyContent", "ClickOnTheSourceCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Activity From Source Course.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        [When(@"I select the ""(.*)"" activity in source course")]
        public void SelectTheActivityFromSourceCourse(String activityName)
        {
            //Select The Activity From Source Course
            Logger.LogMethodEntry("CopyContent", 
                "SelectTheActivityFromSourceCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Select The Activity From Source Course
            new CourseContentUXPage().
                SelectTheActivityForCopyContent(activityName);
            Logger.LogMethodExit("CopyContent", 
                "SelectTheActivityFromSourceCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save the Activity to Course Content.
        /// </summary>
        [When(@"I add the Activity to Course Content in target course")]
        public void AddTheActivityToCourseContent()
        {
            //Save the Activity to Course Content
            Logger.LogMethodEntry("CopyContent", 
                "AddTheActivityToCourseContent",
                base.IsTakeScreenShotDuringEntryExit);
            //Save the Activity to Course Content
            new ContentBrowserUXPage().ClickOnAddAndCloseButton();
            Logger.LogMethodExit("CopyContent", 
                "AddTheActivityToCourseContent",
                base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Click on The Activity Add Button.
        /// </summary>
        [When(@"I click on the Add button")]
        public void ClickOnTheAddButton()
        {
            //Click on The Activity Add Button
            Logger.LogMethodEntry("CopyContent", 
                "ClickOnTheAddButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on The Activity Add Button
            new ContentLibraryUXPage().ClickOnActivityAddButton();
            Logger.LogMethodExit("CopyContent", "ClickOnTheAddButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Copied Activity In 'Course Content'.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        [Then(@"I should see ""(.*)"" activity in course content in target course")]
        public void DisplayOfCopiedActivityInCourseContent(
            String activityName)
        {
            //Display Of Copied Activity In 'Course Content'
            Logger.LogMethodEntry("CopyContent", 
                "DisplayOfCopiedActivityInCourseContent",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert The Display Of Target Course In The Copy Content Dropdown
            Logger.LogAssertion("VerifyTheDisplayOfCopiedActivityInCourseContent",
                ScenarioContext.Current.ScenarioInfo.Title,() => 
                    Assert.AreEqual(activityName,
                    new CourseContentUXPage().
                    GetAssetNameFromCourseContent(activityName)));
            Logger.LogMethodExit("CopyContent",
                "DisplayOfCopiedActivityInCourseContent",
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
