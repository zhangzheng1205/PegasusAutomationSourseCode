using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.HigherEducation.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles the user mail actions.
    /// </summary>
    [Binding]
    public class GBemailAddressPreference : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(GBemailAddressPreference));

        /// <summary>
        /// Select grading tab in the preferences.
        /// </summary>
        [When(@"I select 'Grading' sub tab/Option")]
        public void SelectGradingTab()
        {
            //Select grading tab in the preferences
            Logger.LogMethodEntry("GBemailAddressPreference",
                "SelectGradingTab",
               base.isTakeScreenShotDuringEntryExit);
            //Click on Grading Option
            new GradingPreferencesPage().ClickOnGradingOption();
            Logger.LogMethodExit("GBemailAddressPreference",
                "SelectGradingTab",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get default state of the email preference.
        /// </summary>
        [Then(@"I should see the new preference in unchecked state by default")]
        public void CheckDefaultValue()
        {
            //Get default state of the email preference
            Logger.LogMethodEntry("GBemailAddressPreference",
                "CheckDefaultValue",
              base.isTakeScreenShotDuringEntryExit);
            //Verify default state of the email preference
            Logger.LogAssertion("CheckDefaultValue",
                ScenarioContext.Current.ScenarioInfo.Title, ()
               => Assert.IsFalse(new GradingPreferencesPage().
               IsVerifyTheIncludeMailCheckBoxStatus()));
            Logger.LogMethodExit("GBemailAddressPreference",
                "CheckDefaultValue",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the email preference presence.
        /// </summary>
        [Then(@"I should see the 'include email addresses in Gradebook export file' preference")]
        public void CheckPreferenceText()
        {
            //Verify the email preference presence
            Logger.LogMethodEntry("GBemailAddressPreference",
                "CheckPreferenceText",
              base.isTakeScreenShotDuringEntryExit);
            //Assert email preference
            Logger.LogAssertion("CheckPreferenceText", ScenarioContext.
                Current.ScenarioInfo.Title, ()
                => Assert.AreEqual(GBemailAddressPreferenceResource.
                GBemailAddressPrefernce_IncludeEmailAddress,
                new GradingPreferencesPage().GetIncludeMailText()));
            Logger.LogMethodExit("GBemailAddressPreference",
                "CheckPreferenceText",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the new preference check box with saving.
        /// </summary>
        [When(@"I check the new preference checkbox")]
        public void ModifyCheckBoxAndSave()
        {
            //Click the new preference check box with saving
            Logger.LogMethodEntry("GBemailAddressPreference",
                "ModifyCheckBoxAndSave",
              base.isTakeScreenShotDuringEntryExit);
            //Click on Check box
            new GradingPreferencesPage().ClickTheMailCheckBoxAndSavePreference();
            Logger.LogMethodExit("GBemailAddressPreference",
                "ModifyCheckBoxAndSave",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get check status of the email preference.
        /// </summary>
        [Then(@"I should see the check box as checked according to the user action")]
        public void GetCheckedStatusAfterUserAction()
        {
            //Get check status of the email preference
            Logger.LogMethodEntry("GBemailAddressPreference",
                "GetCheckedStatusAfterUserAction",
              base.isTakeScreenShotDuringEntryExit);
            //Verify check status of the email preference
            Logger.LogAssertion("GetCheckedStatusAfterUserAction",
                ScenarioContext.Current.ScenarioInfo.Title, ()
               => Assert.IsTrue(new GradingPreferencesPage().
               IsVerifyTheIncludeMailCheckBoxStatus()));
            Logger.LogMethodExit("GBemailAddressPreference",
                "GetCheckedStatusAfterUserAction",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get uncheck status of the email preference.
        /// </summary>
        [Then(@"I should see the check box as unchecked according to the user action")]
        public void GetUnCheckedStatusAfterUserAction()
        {
            //Get uncheck status of the email preference
            Logger.LogMethodEntry("GBemailAddressPreference",
                "GetUnCheckedStatusAfterUserAction",
              base.isTakeScreenShotDuringEntryExit);
            //Verify uncheck status of the email preference
            Logger.LogAssertion("GetUnCheckedStatusAfterUserAction",
                ScenarioContext.Current.ScenarioInfo.Title, ()
               => Assert.IsFalse(new GradingPreferencesPage().
               IsVerifyTheIncludeMailCheckBoxStatus()));
            Logger.LogMethodExit("GBemailAddressPreference",
                "GetUnCheckedStatusAfterUserAction",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on download of preferences icon.
        /// </summary>
        [When(@"I should click on Download icon")]
        public void ClickOnDownloadIcon()
        {
            //Click on download of preferences icon
            Logger.LogMethodEntry("GBemailAddressPreference",
                "ClickOnDownloadIcon",
              base.isTakeScreenShotDuringEntryExit);
            //Click on download of preferences icon
            new GradingPreferencesPage().ClickOnDownloadIcon();
            Logger.LogMethodExit("GBemailAddressPreference",
                "ClickOnDownloadIcon",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Current Page option.
        /// </summary>
        [When(@"I select Current Page Option")]
        public void SelectCurrentPageOption()
        {
            //Select Current Page option
            Logger.LogMethodEntry("GBemailAddressPreference",
                "SelectCurrentPageOption",
              base.isTakeScreenShotDuringEntryExit);
            //Select Current Page Option
            new GradingPreferencesPage().SelectCurrentPageOption();
            Logger.LogMethodExit("GBemailAddressPreference",
                "SelectCurrentPageOption",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save the downloaded preferences file.
        /// </summary>
        [Then(@"I should save the downloaded file")]
        public void SaveTheDownloadedFile()
        {
            //Save the downloaded preferences file
            Logger.LogMethodEntry("GBemailAddressPreference",
                "SaveTheDownloadedFile",
              base.isTakeScreenShotDuringEntryExit);
            //Save the downloaded preferences file
            new GradingPreferencesPage().SaveTheDownloadedPreferences();
            Logger.LogMethodExit("GBemailAddressPreference",
                "SaveTheDownloadedFile",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check if Current Page option for download of 
        /// preferences is selected or not.
        /// </summary>
        [Then(@"I should see current pages option selected")]
        public void CheckCurrentPagesOptionSelected()
        {
            //Check if Current Page option for download of preferences is selected or not
            Logger.LogMethodEntry("GBemailAddressPreference",
                "CheckCurrentPagesOptionSelected",
              base.isTakeScreenShotDuringEntryExit);
            //Verify Current Page option for download of preferences is selected or not
            Logger.LogAssertion("CheckCurrentPagesOptionSelected",
                ScenarioContext.Current.ScenarioInfo.Title, ()
             => Assert.IsTrue(new GradingPreferencesPage().
             IsCurrentPageSelected()));
            Logger.LogMethodExit("GBemailAddressPreference",
                "CheckCurrentPagesOptionSelected",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select All Pages option.
        /// </summary>
        [When(@"I select All Pages Option")]
        public void SelectAllPagesOption()
        {
            //Select All Pages option
            Logger.LogMethodEntry("GBemailAddressPreference",
                "SelectAllPagesOption",
              base.isTakeScreenShotDuringEntryExit);
            //Select All Pages option
            new GradingPreferencesPage().SelectAllPages();
            Logger.LogMethodExit("GBemailAddressPreference",
                "SelectAllPagesOption",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check if All Pages option for download of 
        /// preferences is selected or not.
        /// </summary>
        [Then(@"I should see all pages option selected")]
        public void CheckAllPagesOptionSelected()
        {
            //Check if All Pages option for download of preferences is selected or not
            Logger.LogMethodEntry("GBemailAddressPreference",
                "CheckAllPagesOptionSelected",
              base.isTakeScreenShotDuringEntryExit);
            //Verify All Pages option for download of preferences is selected or not
            Logger.LogAssertion("CheckAllPagesOptionSelected",
                ScenarioContext.Current.ScenarioInfo.Title, ()
             => Assert.IsTrue(new GradingPreferencesPage().
             IsAllPagesSelected()));
            Logger.LogMethodExit("GBemailAddressPreference",
                "CheckAllPagesOptionSelected",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check if Current Page download values match 
        /// with the UI preference settings.
        /// </summary>
        [Then(@"I read the current page saved file on WS to check if the downloaded values match with the UI settings")]
        public void ReadCurrentPageSavedFile()
        {
            //Check if Current Page download values match with the UI preference settings
            Logger.LogMethodEntry("GBemailAddressPreference",
                "ReadCurrentPageSavedFile",
              base.isTakeScreenShotDuringEntryExit);
            //Verify Current Page download values match with the UI preference settings
            Logger.LogAssertion("ReadCurrentPageSavedFile", ScenarioContext.Current.
                ScenarioInfo.Title, ()
                => Assert.IsTrue(new GradingPreferencesPage().
                CheckDataWithCurrentPage()));
            Logger.LogMethodExit("GBemailAddressPreference",
                "ReadCurrentPageSavedFile",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check if All Pages download values match with the UI preference settings.
        /// </summary>
        [Then(@"I read the all pages saved file on WS to check if the downloaded values match with the UI settings")]
        public void ReadAllPagesSavedFile()
        {
            //Check if All Pages download values match with the UI preference settings
            Logger.LogMethodEntry("GBemailAddressPreference",
                "ReadAllPagesSavedFile",
              base.isTakeScreenShotDuringEntryExit);
            //Verify All Pages download values match with the UI preference settings
            Logger.LogAssertion("ReadAllPagesSavedFile", ScenarioContext.Current.
                ScenarioInfo.Title, ()
                => Assert.IsTrue(new GradingPreferencesPage().
                CheckDataWithAllPages()));
            Logger.LogMethodExit("GBemailAddressPreference",
                "ReadAllPagesSavedFile",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To read the email preference status before 
        /// downloading the preferences.
        /// </summary>
        [Then(@"I should check the preference status on WS UI before download")]
        public void CheckStatusBeforeDownload()
        {
            //To read the email preference status before downloading the preferences
            Logger.LogMethodEntry("GBemailAddressPreference",
                "CheckStatusBeforeDownload",
              base.isTakeScreenShotDuringEntryExit);
            //Verify email preference status before downloading the preferences
            new GradingPreferencesPage().VerifyCheckLockStatusBeforeDownload();
            Logger.LogMethodExit("GBemailAddressPreference",
                "CheckStatusBeforeDownload",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Check if the preference is not available in the published course.
        /// </summary>
        [Then(@"I should see that the preference as not available in the published course")]
        public void PreferenceAbsentAfterPublishing()
        {
            //Check if the preference is not available in the published course
            Logger.LogMethodEntry("GBemailAddressPreference",
                "PreferenceAbsentAfterPublishing",
              base.isTakeScreenShotDuringEntryExit);
            //Verify preference availability in the published course
            Logger.LogAssertion("PreferenceAbsentAfterPublishing",
                ScenarioContext.Current.ScenarioInfo.Title, ()
                => Assert.IsFalse(new GradingPreferencesPage().
                IsPreferencePresent()));
            Logger.LogMethodExit("GBemailAddressPreference",
                "PreferenceAbsentAfterPublishing",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student ID option from the drop down in the grade book page.
        /// </summary>
        [When(@"I select Student ID in the dropdown")]
        public void StudentIDSelection()
        {
            // Select Student ID option from the drop down in the grade book page
            Logger.LogMethodEntry("GBemailAddressPreference", "click on studentID selection",
            base.isTakeScreenShotDuringEntryExit);
            // Select Student ID option from the drop down in the grade book page
            new GBInstructorUXPage().SelectStudentId();
            Logger.LogMethodExit("GBemailAddressPreference", "click on studentID selection",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student ID and Student NAME option from 
        /// the drop down in the grade book page.
        /// </summary>
        [When(@"I select Student ID and Student NAME in the dropdown")]
        public void StudentIDAndStudentNameSelection()
        {
            //Select Student ID and Student NAME option from the drop down in the grade book page
            Logger.LogMethodEntry("GBemailAddressPreference",
                "StudentIDAndStudentNameSelection",
             base.isTakeScreenShotDuringEntryExit);
            //Select Student ID and Student NAME option from the drop down in the grade book page
            new GBInstructorUXPage().SelectStudentIdAndName();
            Logger.LogMethodExit("GBemailAddressPreference",
                "StudentIDAndStudentNameSelection",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student name option from the drop down in the grade book page.
        /// </summary>
        [When(@"I select Student NAME in the dropdown")]
        public void StudentNameSelection()
        {
            // Select Student name option from the drop down in the grade book page
            Logger.LogMethodEntry("GBemailAddressPreference",
                "StudentNameSelection",
             base.isTakeScreenShotDuringEntryExit);
            // Select Student name option from the drop down in the grade book page
            new GBInstructorUXPage().SelectStudentName();
            Logger.LogMethodExit("GBemailAddressPreference",
                "StudentNameSelection",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the absence of EmailAddress column in the exported excel file.
        /// </summary>
        [Then(@"I read the saved file to check if the EmailAddress colum is absent")]
        public void CheckEmailAddressColumnAbsence()
        {
            //Verify the absence of EmailAddress column in the exported excel file
            Logger.LogMethodEntry("GBemailAddressPreference",
                "CheckEmailAddressColumnAbsence",
              base.isTakeScreenShotDuringEntryExit);
            //Assert absence of EmailAddress column in the exported excel file
            Logger.LogAssertion("CheckEmailAddressColumnAbsence",
                ScenarioContext.Current.ScenarioInfo.Title, ()
                => Assert.IsTrue(new GBInstructorUXPage().
                EmailAddressColumnAbsent()));
            Logger.LogMethodExit("GBemailAddressPreference",
                "CheckEmailAddressColumnAbsence",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Function to verify the presence of EmailAddress column 
        /// in the exported excel file in the SECOND position.
        /// </summary>
        [Then(@"I read the saved file to check if the EmailAddress column is present in the SECOND column")]
        public void CheckIfEmailAddressColumnIsInColTwo()
        {
            Logger.LogMethodEntry("GBemailAddressPreference",
                "CheckIfTheEmailAddressColumnIsInColTwo",
             base.isTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("CheckIfTheEmailAddressColumnIsInColTwo",
                ScenarioContext.Current.ScenarioInfo.Title, ()
                => Assert.IsTrue(new GBInstructorUXPage().EmailAddressColumnPresent
                (Convert.ToInt32(GBemailAddressPreferenceResource.
                GBemailAddressPrefernce_FirstColumn_Value))));
            Logger.LogMethodExit("GBemailAddressPreference",
                "CheckIfTheEmailAddressColumnIsInColTwo",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the presence of EmailAddress column in the 
        /// exported excel file in the THIRD position.
        /// </summary>
        [Then(@"I read the saved file to check if the EmailAddress column is present in the THIRD column")]
        public void CheckIfEmailAddressColumnIsInColThree()
        {
            // Verify the presence of EmailAddress column in the exported excel file in the THIRD position
            Logger.LogMethodEntry("GBemailAddressPreference",
                "CheckIfTheEmailAddressColumnIsInColThree",
             base.isTakeScreenShotDuringEntryExit);
            //Assert presence of EmailAddress column in the exported excel file in the THIRD position
            Logger.LogAssertion("CheckIfTheEmailAddressColumnIsInColThree",
                ScenarioContext.Current.ScenarioInfo.Title, ()
                => Assert.IsTrue(new GBInstructorUXPage().EmailAddressColumnPresent
                (Convert.ToInt32(GBemailAddressPreferenceResource.
                GBemailAddressPrefernce_ThirdColumn_Value))));
            Logger.LogMethodExit("GBemailAddressPreference",
                "CheckIfTheEmailAddressColumnIsInColThree",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the presence of EmailAddress column in the 
        /// exported excel file in the FOURTH position.
        /// </summary>
        [Then(@"I read the saved file to check if the EmailAddress column is present in the FOURTH column")]
        public void CheckIfEmailAddressColumnIsInColFour()
        {
            //Verify the presence of EmailAddress column in the exported excel file in the FOURTH position
            Logger.LogMethodEntry("GBemailAddressPreference",
                "CheckIfTheEmailAddressColumnIsInColFour",
             base.isTakeScreenShotDuringEntryExit);
            //Assert presence of EmailAddress column in the exported excel file in the FOURTH position
            Logger.LogAssertion("CheckIfTheEmailAddressColumnIsInColFour",
                ScenarioContext.Current.ScenarioInfo.Title, ()
                => Assert.IsTrue(new GBInstructorUXPage().
                EmailAddressColumnPresent(Convert.ToInt32
                (GBemailAddressPreferenceResource.
                GBemailAddressPrefernce_FourthColumn_Value))));
            Logger.LogMethodExit("GBemailAddressPreference",
                "CheckIfTheEmailAddressColumnIsInColFour",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save the downloaded Grade Book file.
        /// </summary>
        [Then(@"I should save the downloaded GB file")]
        public void SaveTheDownloadedGbFile()
        {
            // Save the downloaded Grade Book file
            Logger.LogMethodEntry("GBemailAddressPreference",
                "SaveTheDownloadedGbFile",
              base.isTakeScreenShotDuringEntryExit);
            // Save the downloaded Grade Book file
            new GBInstructorUXPage().SaveDownloadedGradeBook();
            Logger.LogMethodExit("GBemailAddressPreference",
                "SaveTheDownloadedGbFile",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Download the grade book based on the file type selection.
        /// </summary>
        [When(@"I should download the grade book")]
        public void DownloadGradeBook()
        {
            //Download the grade book based on the file type selection
            Logger.LogMethodEntry("GBemailAddressPreference",
                "DownloadGradeBook",
             base.isTakeScreenShotDuringEntryExit);
            //Download Gradebook
            new GBInstructorUXPage().DownloadGradeBook();
            Logger.LogMethodExit("GBemailAddressPreference",
                "DownloadGradeBook",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select import grades option from the create column 
        /// dropdown in the grade book .
        /// </summary>
        [When(@"I click on create column dropdown to select Import Grades option")]
        public void SelectImportGrades()
        {
            // Select import grades option from the create column dropdown in the grade book
            Logger.LogMethodEntry("GBemailAddressPreference",
                "SelectImportGrades",
             base.isTakeScreenShotDuringEntryExit);
            // Select import grades option from the create column dropdown in the grade book
            new GBInstructorUXPage().SelectImportGrades();
            Logger.LogMethodExit("GBemailAddressPreference",
                "SelectImportGrades",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the file to be uploaded in the import grades pop up.
        /// </summary>
        [Then(@"I should select the file to be uploaded")]
        public void SelectFileForUpload()
        {
            // Select the file to be uploaded in the import grades pop up
            Logger.LogMethodEntry("GBemailAddressPreference",
                "SelectFileForUpload",
               base.isTakeScreenShotDuringEntryExit);
            // Select the file to be uploaded in the import grades pop up
            new GBInstructorUXPage().SelectFileToUpload();
            Logger.LogMethodExit("GBemailAddressPreference",
                "SelectFileForUpload",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Column Name in the import grades pop up.
        /// </summary>
        [Then(@"I should provide the Column Name")]
        public void FillInColumnName()
        {
            // Fill Column Name in the import grades pop up
            Logger.LogMethodEntry("GBemailAddressPreference", "FillInColumnName",
             base.isTakeScreenShotDuringEntryExit);
            // Fill Column Name in the import grades pop up
            new GBInstructorUXPage().FillColumnName(
                GBemailAddressPreferenceResource.
                GBemailAddressPrefernce_New_Column_Name);
            Logger.LogMethodExit("GBemailAddressPreference", "FillInColumnName",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill the Column Number in the import grades pop up.
        /// </summary>
        [Then(@"I should indicate the Column Number")]
        public void FillInColumnNumber()
        {
            // Fill the Column Number in the import grades pop up
            Logger.LogMethodEntry("GBemailAddressPreference",
                "FillInColumnNumber",
            base.isTakeScreenShotDuringEntryExit);
            // Fill the Column Number in the import grades pop up
            new GBInstructorUXPage().FillColumnNumber(
                GBemailAddressPreferenceResource.
                GBemailAddressPrefernce_New_Column_Number);
            Logger.LogMethodExit("GBemailAddressPreference",
                "FillInColumnNumber",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on OK button in the import grades pop up.
        /// </summary>
        [Then(@"I should click on OK button")]
        public void ClickOkToUpload()
        {
            // Click on OK button in the import grades pop up
            Logger.LogMethodEntry("GBemailAddressPreference",
                "ClickOKToUpload",
           base.isTakeScreenShotDuringEntryExit);
            // Click on OK button in the import grades pop up
            new GBInstructorUXPage().ClickOKButton();
            Logger.LogMethodExit("GBemailAddressPreference",
                "ClickOKToUpload",
                base.isTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// This method is called before execution of test.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// This function is called after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
