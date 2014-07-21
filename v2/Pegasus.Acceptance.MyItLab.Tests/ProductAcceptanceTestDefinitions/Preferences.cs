using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Location;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
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
        /// Navigate To Subtab In Preferences Page.
        /// </summary>
        /// <param name="subtabName">This is Subtab Name.</param>
        [When(@"I navigate to the ""(.*)"" tab in Preferences Page")]
        public void NavigateToSubtabInPreferences(String
            subtabName)
        {
            //Navigate To Subtab In Preferences Page
            Logger.LogMethodEntry("Preferences",
                "NavigateToSubtabInPreferences",
                base.isTakeScreenShotDuringEntryExit);
            //Click on the Subtab
            new GeneralPreferencesPage().ClickOntheSubtab(subtabName);
            Logger.LogMethodExit("Preferences",
                "NavigateToSubtabInPreferences",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Assert the Subtab Name Displayed
            Logger.LogAssertion("VerifyTheDisplayOfSubtab",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(subtabName,
                    new GeneralPreferencesPage().GetSelectedSubtabName()));
            Logger.LogMethodExit("Preferences", "DisplayOfTheSubtab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Home sub tab in preference
        /// </summary>
        /// <param name="subTabName">Preference Subtab name</param>
        [When(@"I click on the ""(.*)"" tab")]
        public void ClickOnPreferenceSubTab(string subTabName)
        {
            // Select the preference sub tab
            Logger.LogMethodEntry("Preferences", "ClickOnPreferenceSubTab",
                 base.isTakeScreenShotDuringEntryExit);
            // Navigating to given prefernce tab options from preference page
            new GeneralPreferencesPage().ClickonSubTabofPreference(subTabName);
            // Select the preference sub tab
            Logger.LogMethodExit("Preferences", "ClickOnPreferenceSubTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate given text present in the page
        /// </summary>
        /// <param name="text">This is text to Search</param>
        [Then(@"I should see the ""(.*)"" in the page")]
        public void ValidateTextInThePage(string text)
        {
            // Validate given text present in the page
            Logger.LogMethodEntry("Preferences", "ValidateTextInThePage",
                base.isTakeScreenShotDuringEntryExit);
            // Verifying the return text value is correct
            Logger.LogAssertion("VerifyTheText",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(text, new GeneralPreferencesPage().GetElementTextDisplayed()));
            // Validate given text present in the page
            Logger.LogMethodExit("Preferences", "ValidateTextInThePage",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To click on given link in Course preference page
        /// </summary>
        /// <param name="linkName">Link name which need to click</param>
        /// <param name="parentName">Parent of the given link</param>        
        [When(@"I click on ""(.*)"" link of ""(.*)""")]
        public void ClickOnLink(string linkName, string parentName)
        {
            // Click on given link
            Logger.LogMethodEntry("Preferences", "ClickOnLink",
                base.isTakeScreenShotDuringEntryExit);
            // Click on link
            new GeneralPreferencesPage().ClickOnLink((GeneralPreferencesPage.StudyPlanEnum)Enum.
                Parse(typeof(GeneralPreferencesPage.StudyPlanEnum), parentName));
            // Click on given link
            Logger.LogMethodExit("Preferences", "ClickOnLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To make sure given text is not exits
        /// </summary>
        /// <param name="searchText">Text which needs to check is exits</param>
        [Then(@"I should not see the ""(.*)"" in the page")]
        public void ValidateExitanceOfText(string searchText)
        {
            // Check is given text presents in the page
            Logger.LogMethodEntry("Preferences", "ValidateExitanceOfText",
                base.isTakeScreenShotDuringEntryExit);
            // To check given text is not exits in page
            Logger.LogAssertion("VerifyExitanceOfText",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreNotEqual(searchText, new GeneralPreferencesPage().
                 GetGivenTextFromPage(searchText)));
            // Check is given text presents in the page
            Logger.LogMethodExit("Preferences", "ValidateExitanceOfText",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Link Type Button
        /// </summary>
        /// <param name="buttonName">Button name which need to click</param>
        /// <param name="sourcePageTitle">Given button container</param>
        [When(@"I click on ""(.*)"" button in ""(.*)""")]
        public void ClickOnLinkTypeButton(string buttonName, string sourcePageTitle)
        {
            // Click on pegasus button, which is created using customize button
            Logger.LogMethodEntry("Preference", "ClickOnLinkTypeButton",
                base.isTakeScreenShotDuringEntryExit);
            // Click event get fire on given button, based on their ID ibtnCancel
            new GeneralPreferencesPage().ClickOnLinkTypeButton(buttonName, sourcePageTitle);
            // Click on pegasus button, which is created using customize button
            Logger.LogMethodExit("Preference", "ClickOnLinkTypeButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Necessary General Preference Settings.
        /// </summary>
        [When(@"I enable necessary general preference settings")]
        public void EnableNecessaryGeneralPreferenceSettings()
        {
            //Enable Necessary General Preference Settings
            Logger.LogMethodEntry("Preference",
                "EnableNecessaryGeneralPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
            //Enable General Preference Settings
            new GeneralPreferencesPage().EnableGeneralPreferenceSettings();
            Logger.LogMethodExit("Preference",
                "EnableNecessaryGeneralPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Enable Catalog Preference Settings
            new CatalogPreferencesPage().EnableCatalogPreferenceSettings();
            Logger.LogMethodExit("Preference",
                "EnableNecessaryCatalogPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Disable 'Hide MyCourse Materials on Creation' Preference.
        /// </summary>
        [When(@"I disable 'Hide My Course materials on creation' preference")]
        public void DisableHideMyCourseMaterialsonCreationPreference()
        {
            //Disable 'Hide MyCourse Materials on Creation' Preference
            Logger.LogMethodEntry("Preference",
                "DisableHideMyCourseMaterialsonCreationPreference",
                base.isTakeScreenShotDuringEntryExit);
            //Disable 'Hide MyCourse Materials on Creation' Preference
            new CourseMaterialPreferencePage().
                DisableHideMyCourseMaterialsPreference();
            Logger.LogMethodExit("Preference",
                "DisableHideMyCourseMaterialsonCreationPreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Necessary Grading Preference Settings.
        /// </summary>
        [When(@"I enable necessary grades preference settings")]
        public void EnableNecessaryGradingPreferenceSettings()
        {
            //Enable Necessary Grades Preference Settings
            Logger.LogMethodEntry("Preference",
                "EnableNecessaryGradingPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
            //Declare object
            GradingPreferencesPage gradePreferencesPage =
                new GradingPreferencesPage();
            //Select Grade Sub Tab Frame
            gradePreferencesPage.SelectGradeSubTabFrame();      
            //Enable 'Apply Grade Schema' Option
            gradePreferencesPage.EnableApplyGradeSchemaOption();
            //Enable Folder level Calculation checkbox
            gradePreferencesPage.EnableFolderLevelCalculationCheckbox();
            //Save The Preference
            new GeneralPreferencesPage().SavePreferences();
            Logger.LogMethodExit("Preference",
                "EnableNecessaryGradingPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable 'Enable SIM5 Questions' Preference.
        /// </summary>
        [When(@"I enable 'Enable SIM5 questions' preference")]
        public void EnableSIM5QuestionsPreference()
        {
            //Enable 'Enable SIM5 Questions' Preference
            Logger.LogMethodEntry("Preference", "EnableSIM5QuestionsPreference",
                base.isTakeScreenShotDuringEntryExit);
            //Enable 'Enable SIM5 Questions' Preference
            new QuestionsPreferencesPage().EnableSIM5QuestionsPreference();
            Logger.LogMethodExit("Preference", "EnableSIM5QuestionsPreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable 'Enable original SIM questions' preference in MYITLab course.
        /// </summary>
        [When(@"I enable 'Enable original SIM questions' preference")]
        public void EnableOriginalSIMQuestionsPreference()
        {
            //Enable 'Enable original SIM questions' Preference
            Logger.LogMethodEntry("Preference", "EnableOriginalSIMQuestionsPreference",
                base.isTakeScreenShotDuringEntryExit);
            //Enable 'Enable original SIM questions' Preference
            new QuestionsPreferencesPage().EnableOriginalSIMQuestionPreference();
            Logger.LogMethodExit("Preference", "EnableOriginalSIMQuestionsPreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable 'Grader Project' Question Type Preference.
        /// </summary>
        [When(@"I enable 'Grader Project' question type preference")]
        public void EnableGraderProjectQuestionTypePreference()
        {
            //Enable 'Grader Project' Question Type Preference
            Logger.LogMethodEntry("Preference",
                "EnableGraderProjectQuestionTypePreference",
                base.isTakeScreenShotDuringEntryExit);
            //Enable 'Grader Project' Question Type Preference
            new QuestionsPreferencesPage().EnableGraderProjectQuestionTypePreference();
            Logger.LogMethodExit("Preference",
                "EnableGraderProjectQuestionTypePreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable 'Display Integrity detection to students
        /// automatically for Grader projects' Preference.
        /// </summary>
        [When(@"I enable 'Display Integrity detection to students automatically for Grader projects' preference")]
        public void EnableDisplayIntegrityDetectionPreference()
        {
            //Enable 'Display Integrity detection to students
            //automatically for Grader projects' Preference
            Logger.LogMethodEntry("Preference",
                "EnableDisplayIntegrityDetectionPreference",
                base.isTakeScreenShotDuringEntryExit);
            //Enable 'Display Integrity detection to students
            //automatically for Grader projects' Preference
            new GradingPreferencesPage().EnableDisplayIntegrityDetectionPreference();
            Logger.LogMethodExit("Preference",
                "EnableDisplayIntegrityDetectionPreference",
                base.isTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Create Mac Address For Computer
        /// </summary>
        [When(@"I create the mac address for computer")]
        public void CreateTheMacAddressForComputer()
        {
            //Create Mac Address For Computer
            Logger.LogMethodEntry("Preference",
                "CreateTheMacAddressForComputer",
                base.isTakeScreenShotDuringEntryExit);
            //Add Mac Address For Computer
            new MacAddressDetailsPage().AddComputerMacAddress();
            Logger.LogMethodExit("Preference",
                "CreateTheMacAddressForComputer",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create The Location
        /// </summary>
        [When(@"I create the location")]
        public void CreateTheLocation()
        {
            //Create the Location
            Logger.LogMethodEntry("Preference",
                "CreateTheLocation",
                base.isTakeScreenShotDuringEntryExit);
            //Add Location
            new MacAddressDetailsPage().AddLocation();
            Logger.LogMethodExit("Preference",
               "CreateTheLocation",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Associate the Computer to Location
        /// </summary>
        [When(@"I associate the computer to location")]
        public void AssociateTheComputerToLocation()
        {
            //Associate The Computer To Location
            Logger.LogMethodEntry("Preference",
                "AssociateTheComputerToLocation",
                base.isTakeScreenShotDuringEntryExit);
            //Associate the Computer To Location
            new MacAddressDetailsPage().AssociateComputerToLocation();
            Logger.LogMethodExit("Preference",
               "AssociateTheComputerToLocation",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Instructor Resource Toolbar Preference.
        /// </summary>
        [When(@"I enable 'Enable Instructor Resource Toolbar Preference' preference")]
        public void EnableInstructorResourceToolbarPreference()
        {
            //Enable Instructor Resource Toolbar Preference
            Logger.LogMethodEntry("Preference", "EnableInstructorResourceToolbarPreference"
               , base.isTakeScreenShotDuringEntryExit);
            //Enable Instructor Resource Toolbar Preference
            new GeneralPreferencesPage().EnableInstructorResourceToolbarPreference();
            Logger.LogMethodExit("Preference", "EnableInstructorResourceToolbarPreference"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'Display as tab on main navigation row' Link.
        /// </summary>
        [When(@"I click on 'Display as tab on main navigation row' link under course materials")]
        public void ClickOnAssignmentCalendarDisplayLink()
        {
            //Click On 'Display as tab on main navigation row' Link
            Logger.LogMethodEntry("Preference",
                "ClickOnAssignmentCalendarDisplayLink"
               , base.isTakeScreenShotDuringEntryExit);
            //Click On 'Display as tab on main navigation row' Link
            new ToolbarPreferencesPage().ClickOnAssignmentCalendarDisplayLink();
            //Click on 'Save Preferences' Button
            new GeneralPreferencesPage().SavePreferences();
            Logger.LogMethodExit("Preference",
                "ClickOnAssignmentCalendarDisplayLink"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Display of Tab.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>
        [Then(@"I should see the ""(.*)"" tab as main tab")]
        public void VerifyTheDisplayOfTab(string tabName)
        {
            //Verify the Display of Tab
            Logger.LogMethodEntry("Preference", "VerifyTheDisplayOfTab"
               , base.isTakeScreenShotDuringEntryExit);
            // To Verify the Display of Tab
            Logger.LogAssertion("VerifyDisplayOfTab",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new ToolbarPreferencesPage().
                   IsTabDisplayAsMainTab(tabName)));
            Logger.LogMethodExit("Preference", "VerifyTheDisplayOfTab"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'Display under Content tab' Link Under.
        /// </summary>
        [When(@"I click on 'Display under Content tab' link under course materials")]
        public void ClickOnCalendarDisplayLinkUnderContentTab()
        {
            //Click On 'Display under Content tab' Link Under
            Logger.LogMethodEntry("Preference",
                "ClickOnCalendarDisplayLinkUnderContentTab"
               , base.isTakeScreenShotDuringEntryExit);
            GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
            //Select Main Frame
            generalPreferencePage.SelectThePreferenceWindowWithFrame();
            //Click On 'Display under Content tab' Link Under
            new ToolbarPreferencesPage().ClickOnTheAssignmentCalendarDisplayLink();
            //Click on 'Save Preferences' Button
            generalPreferencePage.SavePreferences();
            Logger.LogMethodExit("Preference",
                "ClickOnCalendarDisplayLinkUnderContentTab"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Calendar General Preference Settings.
        /// </summary>
        [When(@"I enable 'Enable Calendar' in general preference settings")]
        public void EnableCalendarGeneralPreferenceSettings()
        {
            //Enable Calendar General Preference Settings.
            Logger.LogMethodEntry("Preference",
                "EnableCalendarGeneralPreferenceSettings"
               , base.isTakeScreenShotDuringEntryExit);
            //Enable Calendar General Preference Settings.
            new GeneralPreferencesPage().EnableCalendarGeneralPreferenceSettings();
            Logger.LogMethodExit("Preference",
                "EnableCalendarGeneralPreferenceSettings"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The 'Enable Instructor Only assets' Preference Checkbox.
        /// </summary>
        [When(@"I select 'Enable Instructor Only assets' preference")]
        public void ClickOnTheInstructorOnlyassetsPreferenceCheckbox()
        {
            //Click On The 'Enable Instructor Only assets' Preference Checkbox
            Logger.LogMethodEntry("Preference",
                "ClickOnTheInstructorOnlyassetsPreferenceCheckbox"
               , base.isTakeScreenShotDuringEntryExit);
            //Click On The 'Enable Instructor Only assets' Preference Checkbox
            new LessonPlanPreferencesPage().
                ClickOnInstructorOnlyAssetsPreferenceCheckbox();
            Logger.LogMethodExit("Preference",
                "ClickOnTheInstructorOnlyassetsPreferenceCheckbox"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Calendar Prefernces Unchecked Locked And Disabled.
        /// </summary>
        [Then(@"I should see 'HED Calendar layout' and 'Skip Calendar Setup' prefernces unchecked locked and disabled")]
        public void VerifyCalendarPreferncesUncheckedLockedAndDisabled()
        {
            //Verify Calendar Prefernces Unchecked Locked And Disabled
            Logger.LogMethodEntry("Preference",
                "VerifyCalendarPreferncesUncheckedLockedAndDisabled"
               , base.isTakeScreenShotDuringEntryExit);
            // To Verify Calendar Prefernces Unchecked And Disabled
            Logger.LogAssertion("VerifyCalendarPreferencesStatus",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsFalse(new GeneralPreferencesPage().
                   IsCalendarPreferencesUncheckedDisabled()));
            // To Verify Calendar Prefernces Locked
            Logger.LogAssertion("VerifyCalendarPreferencesLockStatus",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new GeneralPreferencesPage().
                   IsCalendarPreferencesLockStatus()));
            Logger.LogMethodExit("Preference",
                "VerifyCalendarPreferncesUncheckedLockedAndDisabled"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Instructor Only assets Preference Status.
        /// </summary>
        [Then(@"I should see 'Enable Instructor Only assets' preference in disabled state")]
        public void VerifyInstructorOnlyassetsPreferenceStatus()
        {
            //Verify Instructor Only assets Preference Status
            Logger.LogMethodEntry("Preference",
                "VerifyInstructorOnlyassetsPreferenceStatus"
               , base.isTakeScreenShotDuringEntryExit);
            // To Verify Instructor Only assets Preference Status
            Logger.LogAssertion("VerifyInstructorOnlyAssetsPreferencesStatus",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsFalse(new LessonPlanPreferencesPage().
                   IsInstructorOnlyAssetsPreferenceEnabled()));
            Logger.LogMethodExit("Preference",
                "VerifyInstructorOnlyassetsPreferenceStatus"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Disable 'HED Calendar' Preference.
        /// </summary>
        [When(@"I disable the 'Enable Calendar' preference")]
        public void DisableTheHEDCalendarPreference()
        {
            //Disable 'HED Calendar' Preference
            Logger.LogMethodEntry("Preference",
                "DisableTheHEDCalendarPreference"
               , base.isTakeScreenShotDuringEntryExit);
            // Disable 'HED Calendar' Preference
            new GeneralPreferencesPage().DisableHedCalendarPreference();
            Logger.LogMethodExit("Preference",
                "DisableTheHEDCalendarPreference"
                , base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Set The Preferences For Copy Content
            new CourseCopyPreferencesPage().
                SetCopyContentPreference();
            Logger.LogMethodExit("Preferences",
                "SetThePreferencesForCopyContent",
                base.isTakeScreenShotDuringEntryExit);
        }
        
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
