using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MLP.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// Thus class handle Launching of
    /// ECollege Course by ECollege users.
    /// </summary>
    [Binding]
    public class LaunchECollegeCourse : BasePage
    {
        /// <summary>
        ///The static instance of Logger for the class.
        /// </summary>
        private static Logger logger =
              Logger.GetInstance(typeof(LaunchECollegeCourse));

        /// <summary>
        /// Create Global Page Object.
        /// </summary>
        readonly DotNextLaunchPage dotNextLaunchPage = 
            new DotNextLaunchPage();

        /// <summary>
        /// Click on Enter Course Link to launch ECollege course.
        /// </summary>
        [When(@"I click on Enter Course Link option")]
        public void ClickOnEnterCourseLink()
        {
            //Click on Enter Course Link 
            logger.LogMethodEntry("LaunchECollegeCourse", "ClickOnEnterCourseLink",
                base.isTakeScreenShotDuringEntryExit);
            //Instance of Dot Next Launch Page
            dotNextLaunchPage.ClickOnEnterCourseLink();
            logger.LogMethodExit("LaunchECollegeCourse", "ClickOnEnterCourseLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select expected Page.
        /// </summary>
        /// <param name="pageName"> This is page name.</param>
        [When(@"I navigate on ""(.*)"" page")]
        public void SelectExpectedPage(String pageName)
        {
            //Switch to expected window
            logger.LogMethodEntry("LaunchECollegeCourse", "SelectExpectedPage",
               base.isTakeScreenShotDuringEntryExit);
            //Instance of Dot Next Launch Page
            dotNextLaunchPage.SelectExpectedPage(pageName);
            logger.LogMethodExit("LaunchECollegeCourse", "SelectExpectedPage",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts 
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
