using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public class ApproveCourse : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ApproveCourse));


        /// <summary>
        /// Search Course In Course Space.
        /// </summary>
        /// <param name="courseTypeEnum">This is course by type enum.</param>
        [When("I search the \"(.*)\" course in coursespace")]
        public void SearchCourseInCourseSpace(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Search Course In Left Frame
            Logger.LogMethodEntry("ApproveCourse", "SearchCourseInCourseSpace",
               base.IsTakeScreenShotDuringEntryExit);
            //Get the Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Search Course To Approve
            new PublishCourseSearchPage().SelectSearchCourseFrame(course.Name);
            //Select Course To Approve
            new PublishCourseSearchPage().SelectCourseToApprove(course.Name);
            Logger.LogMethodExit("ApproveCourse", "SearchCourseInCourseSpace",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Course Search In CourseSpace.
        /// </summary>
        /// <param name="courseTypeEnum">This is course by type enum.</param>
        [Then("I should be able to see the searched \"(.*)\" course in the left frame")]
        public void CheckSearchedCourseInCoreSpace(
            Course.CourseTypeEnum courseTypeEnum)
        {
            // Verify Course Search In CourseSpace
            Logger.LogMethodEntry("ApproveCourse",
                "CheckSearchedCourseInCoreSpace",
            base.IsTakeScreenShotDuringEntryExit);
            //Get Course Name From InMemory
            Course course = Course.Get(courseTypeEnum);
            // Assert Course Search
            Logger.LogAssertion("VerifySearchCourse", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.AreEqual(course.Name,
                  new ListCoursesPage().
                  GetSearchedCourseNameInCourseSpace(courseTypeEnum)));
            Logger.LogMethodExit("ApproveCourse",
                "CheckSearchedCourseInCoreSpace",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on the c-menu option of the course.
        /// </summary>
        /// <param name="optionName">This is link option name.</param>
        [When("I click on \"(.*)\" cmenu option of course in coursespace")]
        public void ClickCMenuCourseOptionInCourseSpace(
            String optionName)
        {
            //Click Approve CMenu Option           
            Logger.LogMethodEntry("ApproveCourse",
                "ClickCMenuCourseOptionInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
            // Click on course cmenu in course space
            new ListCoursesPage().ClickCourseCMenuOption(optionName);
            Logger.LogMethodExit("ApproveCourse",
                "ClickCMenuCourseOptionInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
