using TechTalk.SpecFlow;
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Acceptance.MyTest.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handle the Preference settings.
    /// </summary>
    [Binding]
    public class Preferences : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Preferences));

        /// <summary>
        /// Navigate To Subtab In Preferences Page.
        /// </summary>
        /// <param name="subtabName">This is Subtab Name.</param>
        [When(@"I navigate to the ""(.*)"" tab in Preferences Page")]
        public void NavigateToSubtabInPreferences(String subtabName)
        {
            //Navigate To Subtab In Preferences Page
            Logger.LogMethodEntry("Preferences",
                "NavigateToSubtabInPreferences",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Subtab
            new GeneralPreferencesPage().ClickOntheSubtab(subtabName);
            Logger.LogMethodExit("Preferences",
                "NavigateToSubtabInPreferences",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of The Subtab,
        /// </summary>
        /// <param name="subtabName">This is Subtab Name,</param>
        [Then(@"I should be on the ""(.*)"" subtab")]
        public void DisplayOfTheSubtab(String subtabName)
        {
            //Display Of The Subtab
            Logger.LogMethodEntry("Preferences", "DisplayOfTheSubtab",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert the Subtab Name Displayed
            Logger.LogAssertion("VerifyTheDisplayOfSubtab",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(subtabName,
                    new GeneralPreferencesPage().GetSelectedSubtabName()));
            Logger.LogMethodExit("Preferences", "DisplayOfTheSubtab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable The MyTest Options.
        /// </summary>
        [When(@"I enable the 'MyTest' options")]
        public void EnableTheMyTestOptions()
        {
            //Enable The MyTest Options
            Logger.LogMethodEntry("Preferences", "EnableTheMyTestOptions",
              base.IsTakeScreenShotDuringEntryExit);
            //Enable The MyTest Options
            new MyTestPreferencesPage().EnableTheMyTestOptions();
            Logger.LogMethodExit("Preferences", "EnableTheMyTestOptions",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Saves The Preferences.
        /// </summary>
        [When(@"I save the Preferences")]
        public void SaveThePreferences()
        {
            //Click on the Save Preferences Button
            Logger.LogMethodEntry("Preferences",
                "SaveThePreferences",
                base.IsTakeScreenShotDuringEntryExit);
            //Save the Preferences
            new MyTestPreferencesPage().SaveThePreferences();
            Logger.LogMethodExit("Preferences",
                "SaveThePreferences",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Tab From Preferences.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>
        [When(@"I navigate back to the ""(.*)"" tab")]
        public void ClickOnTabFromPreferences(String tabName)
        {
            //Click On Tab From Preferences
            Logger.LogMethodEntry("Preferences",
                "ClickOnTabFromPreferences",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Tab From Preferences
            new CourseCopyPreferencesPage().
                ClickOnTabFromPreferences(tabName);
            Logger.LogMethodExit("Preferences",
                "ClickOnTabFromPreferences",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Preferences Settings In Activity Preference.
        /// </summary>
        [Then(@"I should see the 'Allow students to Try Again' checkbox selected")]
        public void VerifyThePreferencesSettingsInActivityPreference()
        {
            //Verify The Preferences Settings In Activity Preference
            Logger.LogMethodEntry("Preferences",
                "VerifyThePreferencesSettingsInActivityPreference",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert for Check Preferences Settings In Activity Preference.
            Logger.LogAssertion("VerifyPreferenceSettingsForActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new RandomAssessmentPage().
                      IsPresentThePreferenceSettingsInActivity()));
            Logger.LogMethodExit("Preferences",
                "VerifyThePreferencesSettingsInActivityPreference",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// click on Home sub tab in preference.
        /// </summary>
        /// <param name="subTabName">This is Subtab name.</param>
        [When(@"I click on the ""(.*)"" tab")]
        public void ClickOnTheHomeTab(String subTabName)
        {
            //Navigating to 'Home' sub tab
            Logger.LogMethodEntry("Preferences", "ClickOnTheHomeTab",
                 base.IsTakeScreenShotDuringEntryExit);
            //Navigating to 'Home' sub tab options from preference page
            new GeneralPreferencesPage().ClickonSubTabofPreference(subTabName);
            Logger.LogMethodExit("Preferences", "ClickOnTheHomeTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Enable Necessary General Tab Preference Settings.
        /// </summary>
        [When(@"I enable necessary general preference settings")]
        public void EnableNecessaryGeneralTabPreferenceSettings()
        {
            //Enable Necessary General Preference Settings
            Logger.LogMethodEntry("Preferences",
                "EnableNecessaryGeneralTabPreferenceSettings",
                   base.IsTakeScreenShotDuringEntryExit);
            //Intialize the objects
            ToolbarPreferencesPage toolbarPreferencePage = new ToolbarPreferencesPage();
            GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
            //Select Main Frame
            generalPreferencePage.SelectThePreferenceWindowWithFrame();            
            //Enable Embedded Report in General Preferences Page
            generalPreferencePage.EnableGeneralTabEmbeddedReportPreferenceSettings();
            //Enable Try Again Preference CheckBox
            toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
                PreferencesPage_EnableTryAgain_Checkbox_Id_Locator);
            //Save the preferences
            generalPreferencePage.SavePreferences();
            Logger.LogMethodExit("Preferences",
                "EnableNecessaryGeneralTabPreferenceSettings",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Enable Necessary MyTest Preference Settings .
        /// </summary>
        [When(@"I enable necessary MyTest preference settings")]
        public void EnableNecessaryMyTestPreferenceSettings()
        {
            //Enable Necessary MyTest Preference Settings
            Logger.LogMethodEntry("Preferences",
                "EnableNecessaryMyTestPreferenceSettings",
                   base.IsTakeScreenShotDuringEntryExit);
            //Intialize the objects
            ToolbarPreferencesPage toolbarPreferencePage = new ToolbarPreferencesPage();
            GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
            //Select Main Frame
            generalPreferencePage.SelectThePreferenceWindowWithFrame();
            //Allow this Master Course to be delivered as a MyTest Course Preference CheckBox
            toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
                PreferencesPage_DeliverAsMyTestCourse_Checkbox_Id_Locator);
            //Display My Questions Folder in Testbank and Manage Question Bank Preference CheckBox
            toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
                PreferencesPage_DisplayMyQuestionFolder_Checkbox_Id_Locator);
            //Display MyTest Folder in Course Materials Library Preference CheckBox
            toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
                PreferencesPage_DisplayCourseMaterialLibrary_Checkbox_Id_Locator);
            //Enable upgrade (show Upgrade button on toolbar)
            toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
                PreferencesPage_EnableUpgrade_Checkbox_Id_Locator);
            //Show MyTest on toolbar after upgrade 
            toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
                PreferencesPage_ShowMyTestToolBarUpgrade_Checkbox_Id_Locator);
            //Save the preferences
            generalPreferencePage.SavePreferences();
            Logger.LogMethodExit("Preferences",
                "EnableNecessaryMyTestPreferenceSettings",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Necessary Catalog Preference Settings.
        /// </summary>
        [When(@"I enable necessary catalog preference settings")]
        public void EnableNecessaryCatalogPreferenceSettings()
        {
            //Enable Necessary Catalog Preference Settings
            Logger.LogMethodEntry("Preference",
                "EnableNecessaryCatalogPreferenceSettings",
                base.IsTakeScreenShotDuringEntryExit);
            //Enable Catalog Preference Settings
            new CatalogPreferencesPage().EnableCatalogPreferenceSettings();
            Logger.LogMethodExit("Preference",
                "EnableNecessaryCatalogPreferenceSettings",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set The Preferences For Copy Content.
        /// </summary>
        [When(@"I set the preferences for Copy Content")]
        public void SetThePreferencesForCopyContent()
        {
            //Preference settings For Copy Content
            Logger.LogMethodEntry("Preferences",
                "SetThePreferencesForCopyContent",
                base.IsTakeScreenShotDuringEntryExit);
            //Set The Preferences For Copy Content
            new CourseCopyPreferencesPage().
                SetCopyContentPreference();
            Logger.LogMethodExit("Preferences",
                "SetThePreferencesForCopyContent",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
