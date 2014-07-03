using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.ETextS11.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the Details of EText Preferences Page.
    /// </summary>
    [Binding]
    public class ETextPreference : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(ETextPreference));

        /// <summary>
        /// Select LTI tool in preference.
        /// </summary>
        /// <param name="subTabName">This is tab name.</param>
        [When(@"I select the '(.*)' sub tab")]
        [When(@"I select '(.*)' sub tab")]
        public void SelectPreferenceSubTab(String subTabName)
        {
            //Display Of The Subtab.
            Logger.LogMethodEntry("ETextPreference", "SelectLTIToolSubTab",
                base.isTakeScreenShotDuringEntryExit);
            new GeneralPreferencesPage().ClickOntheSubtab(subTabName);
            Logger.LogMethodExit("ETextPreference", "SelectLTIToolSubTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable eText tool link in LTI Tool link.
        /// </summary>
        [When(@"I set the '(.*)' in enable state")]
        public void SetTheETextToolInEnableState(String ltiToolType)
        {
            Logger.LogMethodEntry("ETextPreference", "SetTheETextToolInEnableState",
                base.isTakeScreenShotDuringEntryExit);
            //Enable LTI Tools Preference
            new LTIToolsPreferencesPage().GetLTIToolStatus(ltiToolType);
            Logger.LogMethodExit("ETextPreference", "SetTheETextToolInEnableState",
                base.isTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Enter the eText details.
        /// </summary>
        [When(@"I enter the eText details")]
        public void EnterTheETextDetails()
        {
            //Enter EText Preference Details
            Logger.LogMethodEntry("ETextPreference", "EnterTheETextDetails",
                 base.isTakeScreenShotDuringEntryExit);
            //Object created 
            CourseMaterialPreferencePage courseMaterialPreferencePage 
                = new CourseMaterialPreferencePage();
            courseMaterialPreferencePage.SetETextPreferenceInCourseMaterialTab();
            Logger.LogMethodExit("ETextPreference", "EnterTheETextDetails",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
