using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.ETextS11.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles Create Activity Actions.
    /// </summary>
    [Binding]
    public class CreateActivity : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(CreateActivity));

        /// <summary>
        /// Click On Add Course Materials Link.
        /// </summary>        
        [When(@"I click on the 'Add Course Materials' option")]
        public void ClickOnAddCourseMaterialsLink()
        {
            //Click On Add Course Materials Link
            Logger.LogMethodEntry("CreateActivity", "ClickOnAddCourseMaterialsLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Add Course Materials Option
            new CourseContentUXPage().ClickOnAddCourseMaterialsOption();
            Logger.LogMethodExit("CreateActivity", "ClickOnAddCourseMaterialsLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Activity Type.
        /// </summary>
        /// <param name="activityType">This is Activity Type.</param>
        [When(@"I click on the ""(.*)"" activity type")]
        public void ClickOnTheActivityType(String activityType)
        {
            //Click On The Activity Type
            Logger.LogMethodEntry("CreateActivity", "ClickOnTheActivityType",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Activity Type
            new ContentLibraryUXPage().ClickOnActivityType(activityType);
            Logger.LogMethodExit("CreateActivity", "ClickOnTheActivityType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create EText Link Asset.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity enum.</param>
        [When(@"I create ""(.*)"" activity")]
        public void CreateETextLinkAsset(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create EText Link Asset
            Logger.LogMethodEntry("CreateActivity", "CreateETextLinkAsset",
                base.IsTakeScreenShotDuringEntryExit);
            //Create eText Link Activity 
            new AddeBookLinkPage().CreateeTextLinkAsset(activityTypeEnum);
            Logger.LogMethodExit("CreateActivity", "CreateETextLinkAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On ShowHide Status Option.
        /// </summary>
        [When(@"I click on 'ShowHide' option of Activity")]
        public void ClickOnShowHideStatusOption()
        {
            //Click On ShowHide Status Option
            Logger.LogMethodEntry("CreateActivity", "ClickOnShowHideStatusOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Activity Type
            new CourseContentUXPage().ClickTheShowHideStatusOption();
            Logger.LogMethodExit("CreateActivity", "ClickOnShowHideStatusOption",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
