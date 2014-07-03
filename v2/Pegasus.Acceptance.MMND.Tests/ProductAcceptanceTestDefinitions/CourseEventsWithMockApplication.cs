using System;
using System.Configuration;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MMND.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class is responisble for handling Course Events for Mock Application.
    /// </summary>
    [Binding]
    public class CourseEventsWithMockApplication:PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the Course.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CourseEventsWithMockApplication));

        /// <summary>
        ///Get External CourseID URL.
        /// </summary>
        String getLMSGradeSynchMockApplicationUrl = ConfigurationManager.
            AppSettings["GetLMSGradeSynchMockURLRoot"];
       
        /// <summary>
        /// Browse the LMS GradeSynch Mock Application URL
        /// </summary>
        [Given(@"I browse the LMS Grade Synch Mock Application URL")]
        public void BrowseTheLMSGradeSynchMockApplicationURL()
        {
            //Browse The Mock Application for LMS Grade Synch URL
            Logger.LogMethodEntry("CourseEventsWithMockApplication",
                "BrowseTheLMSGradeSynchMockApplicationURL",
             base.isTakeScreenShotDuringEntryExit);
            //  Browse The Mock Application for LMS Grade Synch URL
            new PostRestServicePage().BrowseTheLMSGradeSynchMockApplicationURL
                (getLMSGradeSynchMockApplicationUrl);
            Logger.LogMethodExit("CourseEventsWithMockApplication",
                "BrowseTheLMSGradeSynchMockApplicationURL",
           base.isTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see the LMS Grade Synch Mock Application with Item Save event posted for ""(.*)"" activity")]
        public void VerifyItemGradesInLMSGradeSynchMockApplication(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Browse The Mock Application for LMS Grade Synch URL.
            Logger.LogMethodEntry("CourseEventsWithMockApplication",
                "BrowseTheLMSGradeSynchMockApplicationURL",
             base.isTakeScreenShotDuringEntryExit);
            PostRestServicePage objPostRestServicePage = new PostRestServicePage();
            objPostRestServicePage.LoadWindow(); 
            Logger.LogAssertion("VerifyTheItemSaveResponse", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.AreEqual(true,
                   objPostRestServicePage.GetTheResponseFromLMSMockAppication(activityTypeEnum)));
            Logger.LogMethodExit("CourseEventsWithMockApplication",
                "BrowseTheLMSGradeSynchMockApplicationURL",
           base.isTakeScreenShotDuringEntryExit);
        }

    }
}
