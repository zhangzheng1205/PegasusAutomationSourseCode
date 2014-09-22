using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.CommonPageObjects;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This step definition class contains the details of
    /// display of assign contents .
    /// </summary>
    [Binding]
    public class CoursePreview : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
        Logger.GetInstance(typeof(CoursePreview));

        /// <summary>
        /// Verify Calendar Asset Icon
        /// </summary>
        [Then(@"I should see the calendar icon for assigned asset")]
        public void CalendarIconForAssignedAsset()
        {
            //Verify Calendar Asset Icon
            Logger.LogMethodEntry("CoursePreview", "CalendarIconForAssignedAsset",
            base.IsTakeScreenShotDuringEntryExit);
            CalendarFramePage calendarFramePage = new CalendarFramePage();
            //Select Course materials Window and Frame
            calendarFramePage.CoursematerialsWindowandFrame();
            //Verify Calendar Asset Icon
            Logger.LogAssertion("VerifyCalendarIcon", ScenarioContext.
            Current.ScenarioInfo.Title, () => Assert.IsTrue
            (calendarFramePage.IsCalendarIconPresent()));
            Logger.LogMethodExit("CoursePreview", "CalendarIconForAssignedAsset",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Calendar Icon
        /// </summary>
        [When(@"I click on the calendar icon of assigned asset")]
        public void ClickOnCalendarIconofAsset()
        {
            //Click on Calendar Icon
            Logger.LogMethodEntry("CoursePreview", "ClickOnCalendarIconofAsset",
            base.IsTakeScreenShotDuringEntryExit);
            CalendarFramePage calendarFramePage = new CalendarFramePage();
            //Select Course materials Window and Frame
            calendarFramePage.CoursematerialsWindowandFrame();
            //Click on Calendar Icon
            calendarFramePage.ClickOnCalendarIcon();
            Logger.LogMethodExit("CoursePreview", "ClickOnCalendarIconofAsset",
            base.IsTakeScreenShotDuringEntryExit);
        }
        
    }
}
