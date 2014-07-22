#region

using System;
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
    /// This class handles Overview Tab actions in Course Space. 
    /// </summary>
    [Binding]
    public class Overview : PegasusBaseTestFixture
    {
        ///<summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(Overview));

        /// <summary>
        /// Verify Class Present In The Overview Tab.
        /// </summary>
        /// <param name="classTypeEnum">This is is class by type.</param>
        [Then(@"I should see the ""(.*)"" class present in the overview tab")]
        public void ClassPresentInTheOverviewTab(
            Class.ClassTypeEnum classTypeEnum)
        {
            //Verify Class Name In Overview Tab
            Logger.LogMethodEntry("Overview", "ClassPresentInTheOverviewTab",
          base.isTakeScreenShotDuringEntryExit);
            //Get The Class Name Stored In Memory
            Class orgClass = Class.Get(classTypeEnum);
            // Assert Class Search
            Logger.LogAssertion("VerifyClassPresentInOverviewTab", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(orgClass.Name,
                    new TodaysViewUXPage().GetClassName()));
            Logger.LogMethodExit("Overview", "ClassPresentInTheOverviewTab",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Calendar Asset Icon.
        /// </summary>
        [Then(@"I should see the calendar icon for assigned asset")]
        public void CalendarIconForAssignedAsset()
        {
            //Verify Calendar Asset Icon
            Logger.LogMethodEntry("Overview", "CalendarIconForAssignedAsset",
         base.isTakeScreenShotDuringEntryExit);
            CalendarFramePage calendarFramePage = new CalendarFramePage();
            //Select Overview Window and Frame
            calendarFramePage.SelectOverviewWindowandFrame();
            //Verify Calendar Asset Icon
            Logger.LogAssertion("VerifyCalendarIcon", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue
                (calendarFramePage.IsCalendarIconPresent()));
            Logger.LogMethodExit("Overview", "CalendarIconForAssignedAsset",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Calendar Icon.
        /// </summary>
        [When(@"I click on the calendar icon of assigned asset")]
        public void ClickOnCalendarIconofAsset()
        {
            //Click on Calendar Icon
            Logger.LogMethodEntry("Overview", "ClickOnCalendarIconofAsset",
          base.isTakeScreenShotDuringEntryExit);
            CalendarFramePage calendarFramePage = new CalendarFramePage();
            //Select Overview Window and Frame
            calendarFramePage.SelectOverviewWindowandFrame();
            //Click on Calendar Icon
            calendarFramePage.ClickOnCalendarIcon();
            Logger.LogMethodExit("Overview", "ClickOnCalendarIconofAsset",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the assigned activity name.
        /// </summary>
        /// <param name="activityName"></param>
        [Then(@"I should see the assigned asset ""(.*)""")]
        public void VerifyTheAssignedAsset(String activityName)
        {
            Logger.LogMethodEntry("Overview", "VerifyTheAssignedAsset",
          base.isTakeScreenShotDuringEntryExit);            
            // Assert Activity Search
            Logger.LogAssertion("VerifyActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activityName,
                    new CourseCalendarPage().GetActivityName(OverviewResource.
                    Overview_Content_Window_Name, activityName)));
            Logger.LogMethodExit("Overview", "VerifyTheAssignedAsset",
          base.isTakeScreenShotDuringEntryExit);
            
        }
    }
}
