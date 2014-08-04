#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Create Course Copy Page Actions.
    /// </summary>
    [Binding]
    public class ManageCourse : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(ManageCourse));

        /// <summary>
        /// Verify button availability on the screen.
        /// </summary>
        /// <param name="getButtonName">This is the Button name.</param>
        [Then(@"I should see ""(.*)"" button")]
        public void VerifyButtonAvailability(String getButtonName)
        {
            // Check availability of button
            Logger.LogMethodEntry("ManageCourse", "VerifyButtonAvailability",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert the Display Of button in manage course frame
            Logger.LogAssertion("VerifyDisplayOfButtons",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.
                    IsTrue(new SearchCoursesPage().
                    IsButtonDisplayed((SearchCoursesPage.ManageCourseFrameButtons)Enum.Parse
                (typeof(SearchCoursesPage.ManageCourseFrameButtons), getButtonName), getButtonName)));
            Logger.LogMethodExit("ManageCourse", "VerifyButtonAvailability",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify radio button availability on the screen.
        /// </summary>
        /// <param name="radioButtonName">This is the button name.</param>
        [Then(@"I should see ""(.*)"" radio button")]
        public void VerifyRadioButtonAvailability(
            String radioButtonName)
        {
            //Check availability of RadioButton
            Logger.LogMethodEntry("ManageCourse", "VerifyRadioButtonAvailability",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert the Display Of radio button in manage course frame
            Logger.LogAssertion("VerifyDisplayOfRadioButtons",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.
                    IsTrue(new SearchCoursesPage().
                    IsRadioButtonDisplayed(radioButtonName)));
            Logger.LogMethodExit("ManageCourse", "VerifyRadioButtonAvailability",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify text field next to the filters in manage course frame.
        /// </summary>
        [Then(@"I should see Text field next to the Filters")]
        public void VerifyTextFieldInManageCourseFrame()
        {
            //Check availability of text field
            Logger.LogMethodEntry("ManageCourse", "VerifyTextFieldInManageCourseFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert the availability of text field in manage course frame
            Logger.LogAssertion("VerifyDisplayOfTextField",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.
                    IsTrue(new SearchCoursesPage().
                    IsTextFieldPresentInCourseFrame()));
            Logger.LogMethodExit("ManageCourse", "VerifyTextFieldInManageCourseFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Equals, Contains, Begins With and Ends With Filters in manage course frame.
        /// </summary>
        [Then(@"I should see Equals, Contains, Begins With and Ends With Filters")]
        public void VerifyFiltersInManageCourseFrame()
        {
            //Check availability of filters
            Logger.LogMethodEntry("ManageCourse", "VerifyFiltersInManageCourseFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert the availability of fitlers in manage course frame
            Logger.LogAssertion("VerifyDisplayOfFilters",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.
                    AreEqual(ManageCourseResource.ManageCourse_FiltersName, new SearchCoursesPage().
                    GetFiltersName()));
            Logger.LogMethodExit("ManageCourse", "VerifyFiltersInManageCourseFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
