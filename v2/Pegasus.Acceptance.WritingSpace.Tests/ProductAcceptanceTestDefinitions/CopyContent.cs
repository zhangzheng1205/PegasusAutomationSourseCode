using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.WritingSpace.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles the copy content related usecase.
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
        /// Verify The Display Of Activity In View All Content.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param> 
        [Then(@"I should not see the ""(.*)"" activity in View All Content")]
        public void VerifyTheDisplayOfActivityInViewAllContent(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify The Display Of Activity In View All Content
            Logger.LogMethodEntry("CopyContent",
                "VerifyTheDisplayOfActivityInViewAllContent",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Verify the status activity
            Logger.LogAssertion("VerifyTheDisplayOfActivitys",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreNotEqual(activity.Name,new CoursePreviewMainUXPage().
                   GetDisplayOfActivityNameInViewAllContent(activity.Name)));
            Logger.LogMethodExit("CopyContent",
                "VerifyTheDisplayOfActivityInViewAllContent",
                 base.isTakeScreenShotDuringEntryExit);
        }

    }
}
