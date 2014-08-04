using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using System.Text;

namespace Pegasus.Acceptance.MMND.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class contains the definitions for Preferences scenarios.
    /// </summary>
    [Binding]
    public class Preferences : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = Logger.GetInstance(typeof(Preferences));

        /// <summary>
        /// Click on Home sub tab in preference.
        /// </summary>
        /// <param name="subTabName">Preference Subtab name.</param>
        [When(@"I click on the ""(.*)"" tab")]
        public void ClickOnPreferenceSubTab(string subTabName)
        {
            // Select the preference sub tab
            Logger.LogMethodEntry("Preferences", "ClickOnPreferenceSubTab",
                 base.IsTakeScreenShotDuringEntryExit);
            // Navigating to given prefernce tab options from preference page
            new GeneralPreferencesPage().ClickonSubTabofPreference(subTabName);
            // Select the preference sub tab
            Logger.LogMethodExit("Preferences", "ClickOnPreferenceSubTab",
                base.IsTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Enable The Grading Preference Settings.
        /// </summary>
        [When(@"I enable the necessary grading preference settings")]
        public void EnableTheGradingPreferenceSettings()
        {
            //Enable The Grading Preference Settings
            Logger.LogMethodEntry("Preferences", "EnableTheGradingPreferenceSettings",
                 base.IsTakeScreenShotDuringEntryExit);
            //Enable Grading Preference Settings
            new GradingPreferencesPage().EnableGradingPreferenceSettings();
            Logger.LogMethodExit("Preferences", "EnableTheGradingPreferenceSettings",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
