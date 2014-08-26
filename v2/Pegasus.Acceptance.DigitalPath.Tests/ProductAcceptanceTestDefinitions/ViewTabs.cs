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
    /// This class handles the view and access the tabs
    /// on user home page.
    /// </summary>
    [Binding]
    public class ViewTabs : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(ViewTabs));

        /// <summary>
        /// Tab Accessiblitiy on Today's View Page.
        /// </summary>
        /// <param name="tabWindowTitle">This is Tab Window Title.</param>
        [Then(@"I should able to access the ""(.*)"" tab")]
        public void AccessTheTab(String tabWindowTitle)
        {
            //Verify the Accessibility of Tab
            Logger.LogMethodEntry("ViewTabs", "AccessTheTab",
               base.IsTakeScreenShotDuringEntryExit);
            //Initializing the variable
            string newTabName = tabWindowTitle;
            if (tabWindowTitle == ViewTabsResource.ViewTabs_AssignmentsToDo_Window_Title)
            {
                newTabName = ViewTabsResource.ViewTabs_ToDo_Window_Title;
            }
            //Assert Accessibility for Tab on Today's View Page.
            Logger.LogAssertion("VerifyTabAccessbilityByTitle", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                (tabWindowTitle, new TodaysViewUxPage().GetTodaysViewTabTitle
                ((TodaysViewUxPage.TodaysViewTabType)Enum.Parse
                (typeof(TodaysViewUxPage.TodaysViewTabType), newTabName))));
            Logger.LogMethodExit("ViewTabs", "AccessTheTab",
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
