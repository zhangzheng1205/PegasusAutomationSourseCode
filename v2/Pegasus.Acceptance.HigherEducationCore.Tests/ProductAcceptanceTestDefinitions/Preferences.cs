﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the Details of Preferences Page.
    /// </summary>
    [Binding]
    public class Preferences : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(Preferences));

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
        /// Enable 'Apply Grade Schema' Option.
        /// </summary>
        [When(@"I enable the 'Apply Grade Schema' option")]
        public void EnableApplyGradeSchemaOption()
        {
            //Enable 'Apply Grade Schema' Option
            Logger.LogMethodEntry("Preferences", "EnableApplyGradeSchemaOption",
                base.isTakeScreenShotDuringEntryExit);
            //Enable 'Apply Grade Schema' Option
            new GradingPreferencesPage().EnableApplyGradeSchemaOption();
            Logger.LogMethodExit("Preferences", "EnableApplyGradeSchemaOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save The Preferences.
        /// </summary>
        [When(@"I save the Preferences")]
        public void SaveThePreferences()
        {
            //Save The Preferences
            Logger.LogMethodEntry("Preferences", "SaveThePreferences",
                base.isTakeScreenShotDuringEntryExit);
            //Save The Preferences
            new GeneralPreferencesPage().SavePreferences();
            Logger.LogMethodExit("Preferences", "SaveThePreferences",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable 'Copy Content' Option.
        /// </summary>
        [When(@"I enable the 'Copy Content' option")]
        public void EnableCopyContentOption()
        {
            //Enable 'Copy Content' Option
            Logger.LogMethodEntry("Preferences", "EnableCopyContentOption",
                base.isTakeScreenShotDuringEntryExit);
            //Enable 'Copy Content' Option From Content Library to Course Content
            new CourseCopyPreferencesPage().EnableCopyContentOption();
            Logger.LogMethodExit("Preferences", "EnableCopyContentOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Embeded Report option.
        /// </summary>
        [When(@"I enable the 'Enable Embedded Reporting' option")]
        public void EnableEmbededReporting()
        {
            Logger.LogMethodEntry("Preferences", "EnableEmbededReporting",
                base.isTakeScreenShotDuringEntryExit);
            //Enable Embedded Report in General Preferences Page
            GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
            //Select the Window
            generalPreferencePage.SelectThePreferenceWindowWithFrame();
            //Enable Embedded Report in General Preferences Page
            generalPreferencePage.EnableGeneralTabEmbeddedReportPreferenceSettings();
            Logger.LogMethodExit("Preferences", "EnableEmbededReporting",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Edit Link Option of Activity
        /// </summary>
        [When(@"I select the 'Edit' link option of activity in the preferences column 'Customize Activity Type'")]
        public void ClickEditLinkOptionOfActivityInThePreferencesColumn()
        {
            //Click On Edit Link Option of Activity
            Logger.LogMethodEntry("Preferences",
                "ClickEditLinkOptionOfActivityInThePreferencesColumn",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Edit Link Option Of Activity
            new ActivitiesPreferencesPage().ClickOnActivityEditOption();
            Logger.LogMethodExit("Preferences",
                "ClickEditLinkOptionOfActivityInThePreferencesColumn",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Default Option Of Activity
        /// </summary>
        /// <param name="defaultOptionText">This is Default Option</param>
        [Then(@"I should see default option of the activity ""(.*)""")]
        public void VerifyDefaultOptionOfTheActivity(String defaultOptionText)
        {
            //Verify Default Option Of Activity
            Logger.LogMethodEntry("Preferences",
                "VerifyDefaultOptionOfTheActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Submitted Activity name present            
            Logger.LogAssertion("VerifyDefaultOptionOfTheActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(defaultOptionText,
                    new DefaultPreferencesPage().GetNumberOfAttemptsText()));            
            Logger.LogMethodExit("Preferences",
                "VerifyDefaultOptionOfTheActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable desired Permissions for Teaching Assistant
        /// </summary>
        [When(@"I enable desired permissions for teaching assistant")]
        public void EnablePermissionsForTeachingAssistant()
        {
            //Enable desired Permissions for Teaching Assistant
            Logger.LogMethodEntry("Preferences","EnablePermissionsForTeachingAssistant",
                base.isTakeScreenShotDuringEntryExit);
            //Enable Permission Preferences
            new PermissionPreferencesPage().EnablePermissionPreferences();
            Logger.LogMethodExit("Preferences","EnablePermissionsForTeachingAssistant",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Enabled Permission Preferences in Reports Tab
        /// </summary>
        [Then(@"I should see enabled permission preferences in reports tab")]
        public void VerifyEnabledPermissionPreferencesInReportsTab()
        {
            //Verify Enabled Permission Preferences in Reports Tab
            Logger.LogMethodEntry("Preferences",
                "VerifyEnabledPermissionPreferencesInReportsTab",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Enabled Permission Preferences in Reports Tab are Present
            Logger.LogAssertion("VerifyEnabledPermissionsInReports",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new RptMainUXPage().IsPermissionsEnabledInReports()));             
            Logger.LogMethodExit("Preferences",
                "VerifyEnabledPermissionPreferencesInReportsTab",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Cmenu Option of Content in Mycourse
        /// </summary>
        [Then(@"I should see ""(.*)"" option of content in Mycourse")]
        public void VerifyCmenuOfContentInMycourse(
            String contentCmenu)
        {
            // Verify Cmenu Option of Content in Mycourse
            Logger.LogMethodEntry("Preferences",
                "VerifyCmenuOfContentInMycourse",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Cmenu Option of Content in Mycourse
            Logger.LogAssertion("VerifyCmenuOfContentInMycourse",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new CourseContentUXPage().
                    IsCmenuOptionofContentPresent(contentCmenu)));    
            Logger.LogMethodExit("Preferences",
                "VerifyCmenuOfContentInMycourse",
               base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
            //Navigating to 'Home' sub tab options from preference page
            new GeneralPreferencesPage().ClickonSubTabofPreference(subTabName);
            Logger.LogMethodExit("Preferences", "ClickOnTheHomeTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate Course Listing Options present in home page.
        /// </summary>
        /// <param name="title">This is page title.</param>
        [Then(@"I should see the ""(.*)"" in the page")]
        public void ValidateDisplayOfTitleInPage(String title)
        {
            //Validate Course Listing Options present in home page
            Logger.LogMethodEntry("Preferences", "ValidateDisplayOfTitleInPage",
                base.isTakeScreenShotDuringEntryExit);
            //Verifying the return title value is correct
            Logger.LogAssertion("VerifyTitleValueInHomePage",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(title, new GeneralPreferencesPage().
                 GetTitleValueInHomePage()));
            Logger.LogMethodExit("Preferences", "ValidateDisplayOfTitleInPage",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the 'Enable Badge' checkbox.
        /// </summary>
        [When(@"I select the Enable Badge checkbox")]
        public void SelectEnableBadgeCheckbox()
        {
            //Select the 'Enable Badge' checkbox            
            Logger.LogMethodEntry("Preferences", "SelectEnableBadgeCheckbox",
                base.isTakeScreenShotDuringEntryExit);
            //Check the Enable badge checkbox
            new GeneralPreferencesPage().CheckEnableBadgeCheckBox();
            Logger.LogMethodExit("Preferences", "SelectEnableBadgeCheckbox",
              base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Check Select Content button is enabled.
        /// </summary>        
        [Then(@"I should see the Select Content button enabled")]
        public void ValidateStateOfSelectContentButton()
        {
            //Check Select Content button is enabled          
            Logger.LogMethodEntry("Preferences", "ValidateStateOfSelectContentButton",
                base.isTakeScreenShotDuringEntryExit);
            //Check select content button is enabled
            Logger.LogAssertion("VerifyValidateStateOfSelectContentButton",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(null, new GeneralPreferencesPage().
                    GetSelectContentButtonStatus()));
            Logger.LogMethodExit("Preferences", "ValidateStateOfSelectContentButton",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the value in textbox fields.
        /// </summary>
        [When(@"I enter the TemplateID and Badge Threshold textbox fields")]
        public void EnterTheTextboxFields()
        {
            //Enter the value in textbox fields
            Logger.LogMethodEntry("Preferences", "EnterTheTextboxFields",
               base.isTakeScreenShotDuringEntryExit);
            //Check the textbox fields are entered
            new GeneralPreferencesPage().EnterValueinTextBoxFields();
            Logger.LogMethodExit("Preferences", "EnterTheTextboxFields",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the Select Content button.
        /// </summary>       
        [When(@"I click on Select Content button")]
        public void ClickOnSelectContentButton()
        {
            //Click the Select Content button            
            Logger.LogMethodEntry("Preferences", "ClickOnSelectContentButton",
               base.isTakeScreenShotDuringEntryExit);
            //Click the Select Content button
            new GeneralPreferencesPage().ClickTheSelectContentButton();
            Logger.LogMethodExit("Preferences", "ClickOnSelectContentButton",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// select the activity from the Assignment Selection popup.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        [When(@"I select the checkbox of activity ""(.*)""")]
        public void SelectSingleActivityFromCheckbox(
            String activityName)
        {
            //Select the single activity from pop up window
            Logger.LogMethodEntry("Preferences", "SelectSingleActivityFromCheckbox",
               base.isTakeScreenShotDuringEntryExit);
            //Select activity from checkbox
            new GeneralPreferencesPage().SelectSingleActivityFromPopUP(activityName);
            Logger.LogMethodExit("Preferences", "SelectSingleActivityFromCheckbox",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add and Close button to add activities to textbox field.
        /// </summary>
        [When(@"I should click on Add and Close button")]
        public void ClickOnAddAndCloseButton()
        {
            //Click on Add and Close button to add activities to textbox field            
            Logger.LogMethodEntry("Preferences", "ClickOnAddAndCloseButton",
               base.isTakeScreenShotDuringEntryExit);
            //Click the add and Close button
            new GeneralPreferencesPage().AddActivityToSelectContentTextField();
            Logger.LogMethodExit("Preferences", "ClickOnAddAndCloseButton",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This will validate the activity name in the SelectContent Textbox field.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        [Then(@"I should see the '(.*)' in the select content textbox field")]
        public void ValidateActivityNameInSelectContentTextbox(
            String activityName)
        {
            //Validate the activity name in the SelectContent Textbox field
            Logger.LogMethodEntry("Preferences", "ValidateActivityNameInSelectContentTextbox",
               base.isTakeScreenShotDuringEntryExit);
            //Check activityName is Same
            Logger.LogAssertion("VerifyActivityNameInSelectContentTextbox",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activityName, new GeneralPreferencesPage().
                getActivityNameInSelectContentTextbox()));
            Logger.LogMethodExit("Preferences", "ValidateActivityNameInSelectContentTextbox",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// select the multiple activities from the Assignment Selection popup.
        /// </summary>
        /// <param name="firstActivityName">First activity name.</param>
        /// <param name="secondActivityName">Second activity name.</param>
        [When(@"I select the checkbox of activities ""(.*)"" and ""(.*)""")]
        public void SelectMultipleActivitiesFromCheckbox(
            String firstActivityName,
            string secondActivityName)
        {
            //Select the multiple activities from pop up window
            Logger.LogMethodEntry("Preferences", "SelectMultipleActivitiesFromCheckbox",
               base.isTakeScreenShotDuringEntryExit);
            GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
            //Select first activity from checkbox
            generalPreferencePage.SelectSingleActivityFromPopUP(firstActivityName);
            //Select second activity from checkbox
            generalPreferencePage.SelectSingleActivityFromPopUP(secondActivityName);
            Logger.LogMethodExit("Preferences", "SelectMultipleActivitiesFromCheckbox",
              base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Check The Prefernces Option For Character Palate
        /// </summary>
        [When(@"I check the preference option for 'character palate'")]
        public void CheckThePreferenceOptionForcharacterpalate()
        {
            //Check The Prefernces Option For Character Palate
            Logger.LogMethodEntry("Preferences", "CheckThePreferenceOptionForcharacterpalate",
              base.isTakeScreenShotDuringEntryExit);
            GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
            //Enable Character Palate Check Box
            generalPreferencePage.EnableCharacterPalateCheckBox();
            //Click On Save Preferences
            generalPreferencePage.SavePreferences();
            Logger.LogMethodExit("Preferences", "CheckThePreferenceOptionForcharacterpalate",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Course Channel Preference.
        /// </summary>        
        [When(@"I enable the 'Instructors can customize their Home Page' option")]
        public void EnableCourseChannelPreference()
        {
            //Enable Course Channel Preference
            Logger.LogMethodEntry("Preferences", "EnableCourseChannelPreference",
                 base.isTakeScreenShotDuringEntryExit);
            //Enable Course Channel Option
            new CourseChannelPreferencesPage().EnableCourseChannelOption();
            //Save The Preferences
            new GeneralPreferencesPage().SavePreferences();
            Logger.LogMethodExit("Preferences", "EnableCourseChannelPreference",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Move Down Option Of Channel.
        /// </summary>
        /// <param name="option">This is Course Channel Option</param>
        [When(@"I click on ""(.*)"" option of calendar course channel")]
        public void ClickOnMoveDownOptionOfCalendarChannel(string option)
        {
            //Click On Move Down Option Of Channel
            Logger.LogMethodEntry("Preferences", "ClickOnMoveDownOptionOfCalendarChannel",
                  base.isTakeScreenShotDuringEntryExit);
            //Click On Move Down Option Of Channel
            new TodaysViewUXPage().ClickOnChannelMoveDownOption(option);
            Logger.LogMethodExit("Preferences", "ClickOnMoveDownOptionOfCalendarChannel",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display Of Channel.
        /// </summary>
        /// <param name="channelName">This is Channel Name</param>
       [Then(@"I should see the ""(.*)"" channel in first position")]
        public void VerifyDisplayOfChannel(string channelName)
        {
            //Verify Display Of Channel
            Logger.LogMethodEntry("Preferences",
                "VerifyDisplayOfChannel",
                  base.isTakeScreenShotDuringEntryExit);
            //Verify Display Of Channel
            Logger.LogAssertion("VerifyDisplayOfChannel",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(channelName,
                    new TodaysViewUXPage().getCourseChannelName()));
            Logger.LogMethodExit("Preferences",
                "VerifyDisplayOfChannel",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
       /// Click On Move Up Option Of Calendar Course Channel.
        /// </summary>
        /// <param name="option">This is Channel Option</param>
       [When(@"I click on the ""(.*)"" option of calendar course channel")]
       public void ClickOnMoveUpOptionOfCalendarCourseChannel(string option)
       {
           //Click On Option Of Course Channel
           Logger.LogMethodEntry("Preferences",
               "ClickOnMoveUpOptionOfCalendarCourseChannel",
                 base.isTakeScreenShotDuringEntryExit);
           //Click On Course Channel Option
           new TodaysViewUXPage().ClickOnCourseChannelMOveUpOption(option);
           Logger.LogMethodExit("Preferences",
               "ClickOnMoveUpOptionOfCalendarCourseChannel",
             base.isTakeScreenShotDuringEntryExit);
       }

        /// <summary>
       /// Remove Calendar Channel From Course Channel.
        /// </summary>
       [When(@"I remove the Calendar channel from course channel")]
       public void RemoveCalendarChannelFromCourseChannel()
       {
           //Remove Calendar Channel From Course Channel
           Logger.LogMethodEntry("Preferences", "RemoveCalendarChannelFromCourseChannel",
                  base.isTakeScreenShotDuringEntryExit);
           // Remove Calendar Channel From Course Channel
           new TodaysViewUXPage().RemoveCalendarChannel();
           Logger.LogMethodExit("Preferences", "RemoveCalendarChannelFromCourseChannel",
             base.isTakeScreenShotDuringEntryExit);
       }

        /// <summary>
       /// Verify Removed Channel.
        /// </summary>
        /// <param name="channelName">This is Channel Name</param>
       [Then(@"I should not see the ""(.*)"" channel")]
       public void VerifyRemovedChannel(string channelName)
       {
           //Verify Removed Channel
           Logger.LogMethodEntry("Preferences", "VerifyRemovedChannel",
                  base.isTakeScreenShotDuringEntryExit);
           //Assert Removed Channel
           Logger.LogAssertion("VerifyRemovedChannel",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreNotEqual(channelName,
                   new TodaysViewUXPage().getCourseChannelName()));
           Logger.LogMethodExit("Preferences", "VerifyRemovedChannel",
             base.isTakeScreenShotDuringEntryExit);
       }       

       /// <summary>
       /// Enable Schedule Activities Option.
       /// </summary>
       [When(@"I enable 'Schedule Activities' option")]
       public void EnableScheduleActivitiesOption()
       {
           //Enable Schedule Activities Option
           Logger.LogMethodEntry("Preferences", "EnableScheduleActivitiesOption",
                  base.isTakeScreenShotDuringEntryExit);
           //Enable 'Schedule Activities' Permission
           new PermissionPreferencesPage().EnableScheduleActivitiesPermission();
           Logger.LogMethodExit("Preferences", "EnableScheduleActivitiesOption",
             base.isTakeScreenShotDuringEntryExit);
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
                  base.isTakeScreenShotDuringEntryExit);
           GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
           //Select Main Frame
           generalPreferencePage.SelectThePreferenceWindowWithFrame();
           //Enable Calendar Preference
           generalPreferencePage.EnableGeneralTabCalendarPreferenceSettings();
           //Enable Embedded Report in General Preferences Page
           generalPreferencePage.EnableGeneralTabEmbeddedReportPreferenceSettings();
           //Enable Black board IM Preference Settings
           generalPreferencePage.EnableBlackboardIMPreferenceSettings();
           //Enable Character Palate Preference Settings
           generalPreferencePage.EnableCharacterPalatePreferenceSettings();
           //Save the preferences
           generalPreferencePage.SavePreferences();
           Logger.LogMethodExit("Preferences",
               "EnableNecessaryGeneralTabPreferenceSettings",
             base.isTakeScreenShotDuringEntryExit);
       }

        /// <summary>
       /// Enable Necessary Roster Preference Settings.
        /// </summary>
       [When(@"I enable necessary Roster preference settings")]
       public void EnableNecessaryRosterPreferenceSettings()
       {
           //Enable Necessary MyTest Preference Settings
           Logger.LogMethodEntry("Preferences",
               "EnableNecessaryRosterPreferenceSettings",
                  base.isTakeScreenShotDuringEntryExit);
           GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
           //Select Main Frame
           generalPreferencePage.SelectThePreferenceWindowWithFrame();
           //Select Manage Roster Preference Settings
           new RosterPreferencesPage().SelectManageRosterPreferenceSettings();
           //Save the preferences
           generalPreferencePage.SavePreferences();
           Logger.LogMethodExit("Preferences",
               "EnableNecessaryRosterPreferenceSettings",
             base.isTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Enable Necessary Grading Preference Settings.
       /// </summary>
       [When(@"I enable necessary grades preference settings")]
       public void EnableNecessaryGradingTabPreferenceSettings()
       {
           //Enable Necessary Grades Preference Settings
           Logger.LogMethodEntry("Preference",
               "EnableNecessaryGradingTabPreferenceSettings",
               base.isTakeScreenShotDuringEntryExit);
           GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
           //Select Main Frame
           generalPreferencePage.SelectThePreferenceWindowWithFrame();
           //Declare object
           GradingPreferencesPage gradePreferencesPage =
               new GradingPreferencesPage();
           //Enable 'Apply Grade Schema' Option
           gradePreferencesPage.EnableApplyGradeSchemaOption();
           //Enable Filter Content Type Preference Option
           gradePreferencesPage.EnableFilterContentTypePreferenceOption();
           //Save The Preference
           generalPreferencePage.SavePreferences();
           Logger.LogMethodExit("Preference",
               "EnableNecessaryGradingTabPreferenceSettings",
               base.isTakeScreenShotDuringEntryExit);
       }

        /// <summary>
       /// Enable Necessary Course Tools Tab Preference Settings.
        /// </summary>
       [When(@"I enable necessary course tools preference settings")]
       public void EnableNecessaryCourseToolsTabPreferenceSettings()
       {
           //Enable Necessary Course Tools Tab Preference Settings
           Logger.LogMethodEntry("Preference",
               "EnableNecessaryCourseToolsTabPreferenceSettings",
               base.isTakeScreenShotDuringEntryExit);
           ToolbarPreferencesPage toolbarPreferencePage = new ToolbarPreferencesPage();
           GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
           //Select Main Frame
           generalPreferencePage.SelectThePreferenceWindowWithFrame();
           //Enable the 'Assignment Calendar' link
           toolbarPreferencePage.ClickOnTheAssignmentCalendarDisplayLink();
           //Check the Calendar checkbox preference
           toolbarPreferencePage.SetCalendarCheckBoxPreference();
           //Select MyTestTab Enable the Preference CheckBox
           toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
               PreferencesPage_CourseTool_Select_MyTest_Checkbox_Id_Locator);
           //Select MapLearning Objectives Enable the Preference CheckBox
           toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
               PreferencesPage_CourseTool_Select_MapLearningObjectives_Checkbox_Id_Locator);
           //Select MapLearning Objectives To Question Enable the Preference CheckBox
           toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
               PreferencesPage_CourseTool_MapLearningObjectivesToQuestion_Checkbox_Id_Locator);
           //Select Communicate Teacher Side Enable the Preference CheckBox
           toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
               PreferencesPage_CourseTool_Communicate_TeacherSide_Checkbox_Id_Locator);
           //Select Communicate Mail Teacher Side Enable the Preference CheckBox
           toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
               PreferencesPage_CourseTool_Mail_TeacherSide_Checkbox_Id_Locator);
           //Select Communicate Student Side Enable the Preference CheckBox
           toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
               PreferencesPage_CourseTool_Communicate_StudentSide_Checkbox_Id_Locator);           
           //Select Communicate Mail Student Side Enable the Preference CheckBox
           toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
               PreferencesPage_CourseTool_Mail_StudentSide_Checkbox_Id_Locator);
           //Select Student Side Course Calendar By Default subtab
           toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
               PreferencesPage_CourseToolCourse_Calendar_RadioButton_Id_Locator);
           //Select Enrollment 'Manage Roster' By Default subtab
           toolbarPreferencePage.SelectCourseToolTabPreferenceCheckBox(PreferencesResource.
               PreferencesPage_CourseToolCourse_Enrollment_Roster_RadioButton_Id_Locator);
           //Save The Preference
           generalPreferencePage.SavePreferences();
           Logger.LogMethodExit("Preference",
               "EnableNecessaryCourseToolsTabPreferenceSettings",
               base.isTakeScreenShotDuringEntryExit);
       }

        /// <summary>
       /// Enable Necessary Activities Tab Preference Settings.
        /// </summary>
       [When(@"I enable necessary activities preference settings")]
       public void EnableNecessaryActivitiesTabPreferenceSettings()
       {
           //Enable Necessary Course Tools Tab Preference Settings
           Logger.LogMethodEntry("Preference",
               "EnableNecessaryActivitiesTabPreferenceSettings",
               base.isTakeScreenShotDuringEntryExit);
           GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
           //Select Main Frame
           generalPreferencePage.SelectThePreferenceWindowWithFrame();
           //Enable the Enable "Remove multiple attempt activities from a student’s To Do list when a student-
           //scores at or above the proficiency threshold" link
           new ActivitiesPreferencesPage().ClickTheRemoveMultipleAttemptCheckBox();
           //Save The Preference
           generalPreferencePage.SavePreferences();
           Logger.LogMethodExit("Preference",
               "EnableNecessaryActivitiesTabPreferenceSettings",
               base.isTakeScreenShotDuringEntryExit);
       }

        /// <summary>
       /// Enable Necessary StandardsAndSkills Tab Preference Settings.
        /// </summary>
       [When(@"I enable necessary Standards and Skills preference settings")]
       public void EnableNecessaryStandardsAndSkillsTabPreferenceSettings()
       {
           //Enable Necessary StandardsAndSkills Tab Preference Settings
           Logger.LogMethodEntry("Preference",
               "EnableNecessaryStandardsAndSkillsTabPreferenceSettings",
               base.isTakeScreenShotDuringEntryExit);
           GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
           //Select Main Frame
           generalPreferencePage.SelectThePreferenceWindowWithFrame();
           //Set The Course Standard Skill Preferences
           new StandardSkillPreferencesPage().SetTheCourseStandardSkillPreferences
               (PreferencesResource.PreferencesPage_SkillFramework_Name,
               PreferencesResource.PreferencesPage_StandardFramework_Name);
           generalPreferencePage.SavePreferences();
           Logger.LogMethodExit("Preference",
               "EnableNecessaryStandardsAndSkillsTabPreferenceSettings",
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
      
       /// <summary>
       /// Enable Blackboard Collaborate Voice Authoring Preference option.
       /// </summary>
       [When(@"I 'Enable Blackboard Collaborate Voice Authoring' preference option")]
       public void EnableBlackboardVoiceAuthoringOption()
       {
           // Enable Blackboard Collaborate Voice Authoring Preference option
           Logger.LogMethodEntry("Preference",
               "EnableBlackboardVoiceAuthoringOption",
               base.isTakeScreenShotDuringEntryExit);
           GeneralPreferencesPage generalPreferencePage = new GeneralPreferencesPage();
           //Select The Main Frame
           generalPreferencePage.SelectThePreferenceWindowWithFrame();
           //Enable Blackboard Collaborate Voice Authoring Option
           generalPreferencePage.EnableBlackBoardCollaborateVoiceAuthoring();
           //Save The Preference
           generalPreferencePage.SavePreferences();
           Logger.LogMethodExit("Preference",
              "EnableBlackboardVoiceAuthoringOption",
              base.isTakeScreenShotDuringEntryExit);
       }
      
    }
}
