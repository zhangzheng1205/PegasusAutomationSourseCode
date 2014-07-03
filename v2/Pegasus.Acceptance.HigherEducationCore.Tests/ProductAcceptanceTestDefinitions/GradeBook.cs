using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.HigherEducation.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of GradeBook page 
    /// and handles Pegasus GradeBook Page Actions.
    /// </summary>
    [Binding]
    public class GradeBook : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(GradeBook));

        /// <summary>
        /// View grades in Gradebook.
        /// </summary>
        [Then(@"I should see the grades for submitted activity")]
        public void DisplayGradesForSubmittedActivity()
        {
            //View Grades by Instructor
            Logger.LogMethodEntry("GradeBook",
                "DisplayGradesForSubmittedActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Display Grade's For Submitted Activity
            Logger.LogAssertion("ViewGrades", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(GradeBookResource.
                    GradeBook_ActivityGrade_Score_Value.Substring(Convert.ToInt32(
                    GradeBookResource.GradeBook_Substring_Start_Index_Value_0), Convert.ToInt32(
                    GradeBookResource.GradeBook_Substring_End_Index_Value_2)), new GBFoldersPage().
                    GetActivityGrade().Substring(Convert.ToInt32(GradeBookResource.
                    GradeBook_Substring_Start_Index_Value_0), Convert.ToInt32(
                    GradeBookResource.GradeBook_Substring_End_Index_Value_2))));
            Logger.LogMethodExit("GradeBook",
                "DisplayGradesForSubmittedActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Manually Grade the Activity.
        /// </summary>        
        [When(@"I manually grade the activity")]
        public void ManuallyGradeTheActivity()
        {
            //Manually Grade the Activity
            Logger.LogMethodEntry("GradeBook",
                "ManuallyGradeTheActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Get the data from memory
            Activity activity = Activity.Get(Activity.ActivityTypeEnum.Quiz);
            //Open the Activity For Grading
            new GBInstructorUXPage().OpenActivityForGradingInHED(
                activity.Name);
            //Grade the Activity
            new GBGradeBatchUpdationPage().GradetheActivityInHED();
            Logger.LogMethodExit("GradeBook", "ManuallyGradeTheActivity",
               base.isTakeScreenShotDuringEntryExit);
        }       

        /// <summary>
        /// Click On The Content Cmenu Icon.
        /// </summary>
        [When(@"I click on the content cmenu icon")]
        public void ClickOnTheContentCmenuIcon()
        {
            //Click On The Content Cmenu Icon
            Logger.LogMethodEntry("GradeBook",
                "ClickOnTheContentCmenuIcon",
                 base.isTakeScreenShotDuringEntryExit);
            //Click On The Content Cmenu Icon
            new GBInstructorUXPage().ClickOnTheFirstColumnCmenuIcon();
            Logger.LogMethodExit("GradeBook",
                "ClickOnTheContentCmenuIcon",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Context Menu Option.
        /// </summary>
        /// <param name="contextMenuOption">This is the Context 
        /// Menu Option.</param>
        [Then(@"I should see the ""(.*)"" in the cmenu options")]
        public void DisplayOfContextMenuOption(String contextMenuOption)
        {
            //Verify the Display Of Context Menu Option
            Logger.LogMethodEntry("GradeBook", "DisplayOfContextMenuOption",
                 base.isTakeScreenShotDuringEntryExit);
            //Assert Display Of Context Menu Option
            Logger.LogAssertion("VerifyDisplayOfContextMenuOption",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(contextMenuOption, new GBInstructorUXPage().
                    GetContextMenuOptionDisplayed(contextMenuOption)));
            Logger.LogMethodExit("GradeBook", "DisplayOfContextMenuOption",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify GradeBook page loaded successfully
        /// </summary>
        [Then(@"I should see GradeBook page loaded successfully")]
        public void VerifyGradeBookPageLoadedSuccessfully()
        {
            //Verify GradeBook page loaded successfully
            Logger.LogMethodEntry("GBemailAddressPreference",
                "VerifyGradeBookPageLoadedSuccessfully",
            base.isTakeScreenShotDuringEntryExit);
            //Verify GradeBook page loaded successfully
            new GBInstructorUXPage().VerifyGradeBookPageLoaded();
            Logger.LogMethodExit("GBemailAddressPreference",
                "VerifyGradeBookPageLoadedSuccessfully",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Custom View sub tab in a gradeBook
        /// </summary>
        [When(@"I navigate to CustomView sub tab in a Page")]
        public void NavigateToCustomViewSubTab()
        {
            //Navigate to Custom View sub tab in a gradeBook
            Logger.LogMethodEntry("GBemailAddressPreference",
                "NavigateToCustomViewSubTab",
            base.isTakeScreenShotDuringEntryExit);
            // Navigate to Custom View Page in a GradeBook
            new GBInstructorUXPage().NavigateToCustomView();
            Logger.LogMethodExit("GBemailAddressPreference",
                "NavigateToCustomViewSubTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Custom View in Gradebook page loaded 
        /// </summary>
        [Then(@"I should be on CustomView in a GradeBook Page")]
        public void VerifyCustomViewLoadedinGradeBookPage()
        {
            //Verify Custom View in Gradebook page loaded 
            Logger.LogMethodEntry("GBemailAddressPreference",
                "VerifyCustomViewLoadedinGradeBookPage",
            base.isTakeScreenShotDuringEntryExit);
            //Verify Custom View in Gradebook page loaded 
            new GBInstructorUXPage().VerifyCustomViewPageLoadinGradeBook();
            Logger.LogMethodExit("GBemailAddressPreference",
                "VerifyCustomViewLoadedinGradeBookPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Nagivate to Grade Sub Tab in a GradeBook
        /// </summary>
        [When(@"I navigate to Grades Subtab in a GradeBook Page")]
        public void NavigateToGradesSubtabInAGradeBook()
        {
            //Nagivate to Grade Sub Tab in a GradeBook
            Logger.LogMethodEntry("GBemailAddressPreference",
                "NavigateToGradesSubtabInAGradeBook",
            base.isTakeScreenShotDuringEntryExit);
            // Nagivate to Grade Sub Tab in a GradeBook
            new GBInstructorUXPage().NavigateToGradesSubTabinGradeBook();
            Logger.LogMethodExit("GBemailAddressPreference",
                "NavigateToGradesSubtabInAGradeBook",
                base.isTakeScreenShotDuringEntryExit);
        }

        // Verify Course Materials Text In GradesTab.
        [Then(@"I should see the 'Course Materials' text in grades tab")]
        public void VerifyCourseMaterialsTextInGradesTab()
        {
            Logger.LogMethodEntry("GradeBook", "VerifyCourseMaterialsTextInGradesTab",
                base.isTakeScreenShotDuringEntryExit);
            //Verify CourseMaterails Text 
            Logger.LogAssertion("VerifyCourseMaterailsText", ScenarioContext.
                Current.ScenarioInfo.Title,
                () => Assert.AreEqual(GradeBookResource.GradeBook_Coursematerials_Text,
                    new GBStudentUXPage().GetCourseMaterailsText()));
            Logger.LogMethodExit("GradeBook", "VerifyCourseMaterialsTextInGradesTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        //Verify Activity Text In GradesTab.  
        [Then(@"I should see the 'Activity' column text in grades tab ""(.*)""")]
        public void VerifyActivityColumnTextInGradesTab(string items)
        {
            Logger.LogMethodEntry("GradeBook", "VerifyActivityColumnTextInGradesTab",
                base.isTakeScreenShotDuringEntryExit);
            //Verify Activity Column Text 
            Logger.LogAssertion("VerifyActivityColumnText", ScenarioContext.
                Current.ScenarioInfo.Title,
                () => Assert.AreEqual(GradeBookResource.GradeBook_Activity_Column_Text,
                    new GBStudentUXPage().GetActivityColumnText(items)));
            Logger.LogMethodExit("GradeBook", "VerifyActivityColumnTextInGradesTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        //Nagivate to Completed items in Grades. 
        [When(@"I click on 'Completed items' option in grades tab")]
        public void ClickOnGradebookCompleteditems()
        {
            Logger.LogMethodEntry("GradeBook", "ClickCompleteditems",
                base.isTakeScreenShotDuringEntryExit);
            //Click Completed items
            new GBStudentUXPage().ClickOnCompletedItems();
            Logger.LogMethodExit("GradeBook", "ClickCompleteditems",
                base.isTakeScreenShotDuringEntryExit);
        }

        //Nagivate to Assigned items in Grades. 
        [When(@"I click on 'Assigned items' option in grades tab")]
        public void ClickOnGradebookAssigneditems()
        {
            Logger.LogMethodEntry("GradeBook", "ClickAssigneditems",
                base.isTakeScreenShotDuringEntryExit);
            //Click Assigned items
            new GBStudentUXPage().ClickOnAssignedItems();
            Logger.LogMethodExit("GradeBook", "ClickAssigneditems",
                base.isTakeScreenShotDuringEntryExit);
        }

        //Click Asset Cmenu in Grades
        [When(@"I click on 'HomeWork' Cmenu option ViewReport in grades tab")]
        public void ClickOnGradesTabTestCmenu()
        {
            Logger.LogMethodEntry("GradeBook", "ClickOnGradesTabTestCmenu",
                base.isTakeScreenShotDuringEntryExit);
            //Click Cmenu Option
            new ViewSubmissionPage().ClickTheGradesTabCmenuOption(
                Activity.ActivityTypeEnum.HomeWork);
            Logger.LogMethodExit("GradeBook", "ClickOnGradesTabTestCmenu",
              base.isTakeScreenShotDuringEntryExit);
        }

        //Validate Activity Summary Report Data.
        [Then(@"I should see Activity Summary Report data in Pop up")]
        public void ValidateActivitySummaryReportData()
        {
            Logger.LogMethodEntry("GradeBook", "ValidateActivitySummaryReport",
                 isTakeScreenShotDuringEntryExit);
            // Compare Report Data 
            Logger.LogAssertion("ValidateActivitySummaryReportData",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                  Assert.AreEqual(GradeBookResource.GradeBook_HomeWork_Text,
                  new RptStuAssessmentSummaryPage().GetActivitySummaryReportData()));
            Logger.LogMethodExit("GradeBook", "ValidateActivitySummaryReport",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Associate the Activity to MyCourse Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavoiralModeTypeEnum">This is Behavioral Mode Type Enum.</param>
        [When(@"I associate the ""(.*)"" activity of behavioral mode ""(.*)"" to MyCourse frame")]
        public void AssociateTheActivityToMyCourseFrame(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum ActivityModeTypeEnum)
        {
            //Associate the Activity to MyCourse Frame
            Logger.LogMethodEntry("GradeBook", "AssociateTheActivityToMyCourseFrame",
                isTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum, ActivityModeTypeEnum);
            //Select Window
            contentLibraryUXPage.SelectTheWindowName(GradeBookResource.
                GradeBook_Coursematerials_Window_Title);
            //Select the frame
            contentLibraryUXPage.SelectAndSwitchtoFrame(GradeBookResource.
                GradeBook_Coursematerials_LeftFrame_Id_Locator);
            // Select the activity
            contentLibraryUXPage.SelectActivity(activity.Name);
            // Click on Activity Add Button
            contentLibraryUXPage.ClickOnActivityAddButton();
            Logger.LogMethodExit("GradeBook", "AssociateTheActivityToMyCourseFrame",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Activity Display in Gradebook for Enrollled Students
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type enum</param>
        /// <param name="userTypeEnum">This is User type</param>
        [Then(@"I should see the ""(.*)"" activity in Gradebook for all the enrollled ""(.*)""")]
        public void VerifyActivityDisplayInGradebookForEnrollledStudents(
            Activity.ActivityTypeEnum activityTypeEnum, User.UserTypeEnum userTypeEnum)
        {
            //Verify Activity Display in Gradebook for Enrollled Students
            Logger.LogMethodEntry("GradeBook",
                "VerifyActivityDisplayInGradebookForEnrollledStudents",
                 isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            //Assert Activity Name for Enrolled User in Gradebook
            Logger.LogAssertion("VerifyActivityDisplayInGradebook",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(GradeBookResource.GradeBook_ActivityStatus_Hyphen_Value,
                 new GBInstructorUXPage().GetActivityStatus
                 (activity.Name, user.LastName, user.FirstName)));
            Logger.LogMethodExit("GradeBook",
                "VerifyActivityDisplayInGradebookForEnrollledStudents",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Associate Contents To MyCourse Frame
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type</param>
        [When(@"I associate the ""(.*)"" activity to the MyCourse frame")]
        public void AssociateContentsToMyCourseFrame(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Associate Contents To MyCourse Frame
            Logger.LogMethodEntry("GradeBook", "AssociateContentsToMyCourseFrame",
                isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Select Window
            contentLibraryUXPage.SelectTheWindowName(GradeBookResource.
                GradeBook_Coursematerials_Window_Title);
            //Select the frame
            contentLibraryUXPage.SelectAndSwitchtoFrame(GradeBookResource.
                GradeBook_Coursematerials_LeftFrame_Id_Locator);
            // Select the activity
            contentLibraryUXPage.SelectActivity(activity.Name);
            // Click on Activity Add Button
            contentLibraryUXPage.ClickOnActivityAddButton();
            Logger.LogMethodExit("GradeBook", "AssociateContentsToMyCourseFrame",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Asset in Gradebook
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        /// <param name="behavoirlaModeTypeEnum">This is Behavoiral Mode Type Enum</param>
        [Then(@"I should see the ""(.*)"" asset of behaviorla mode ""(.*)"" in Gradebook")]
        public void VerifyTheAssetInGradebook(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavoirlaModeTypeEnum)
        {
            //Verify the Asset in Gradebook
            Logger.LogMethodEntry("GradeBook", "VerifyTheAssetInGradebook",
                isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum, behavoirlaModeTypeEnum);
            //Assert Activity Name in Gradebook
            Logger.LogAssertion("ValidateAssetName",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(activity.Name, new GBInstructorUXPage().
                 GetAssetInGradebook(activity.Name)));
            Logger.LogMethodExit("GradeBook", "VerifyTheAssetInGradebook",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Content In Gradebook
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        [Then(@"I should see the ""(.*)"" asset in Gradebook")]
        public void VerifyTheContentInGradebook(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify The Content In Gradebook
            Logger.LogMethodEntry("GradeBook", "VerifyTheContentInGradebook",
                isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert Activity Name in Gradebook
            Logger.LogAssertion("ValidateAssetName",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(activity.Name, new GBInstructorUXPage().
                 GetAssetInGradebook(activity.Name)));
            Logger.LogMethodExit("GradeBook", "VerifyTheContentInGradebook",
                  isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Activity Display in Gradebook for Enrollled Students.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavoiralModeTypeEnum">This is Behavioral Mode Type Enum.</param>
        /// <param name="userTypeEnum">This is User type Enum.</param>
        [Then(@"I should see the ""(.*)"" activity of behavioral mode ""(.*)"" in Gradebook for enrollled ""(.*)""")]
        public void VerifyActivityStatusInGradebook(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavoiralModeTypeEnum,
            User.UserTypeEnum userTypeEnum)
        {
            //Verify Activity Display in Gradebook for Enrollled Students
            Logger.LogMethodEntry("GradeBook",
                "VerifyActivityStatusInGradebook",
                 isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum, behavoiralModeTypeEnum);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            //Assert Activity Status for Enrolled User in Gradebook
            Logger.LogAssertion("VerifyActivityOfBehaviorlaModeInGradebook",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(GradeBookResource.GradeBook_ActivityStatus_Hyphen_Value,
                 new GBInstructorUXPage().GetActivityStatus
                 (activity.Name, user.LastName, user.FirstName)));
            Logger.LogMethodExit("GradeBook",
                "VerifyActivityStatusInGradebook",
                isTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Navigate To The Subfolder Of Asset In Gradebook.
        /// </summary>       
        /// <param name="subFolderName">This is SubFolder Name</param>
        [When(@"I navigate to the subfolder ""(.*)"" of asset in gradebook")]
        public void NavigateToTheSubfolderOfAssetInGradebook(string subFolderName)
        {
            // Navigate To The Subfolder Of Asset In Gradebook
            Logger.LogMethodEntry("GradeBook", "NavigateToTheSubfolderOfAssetInGradebook",
                 isTakeScreenShotDuringEntryExit);           
            //Navigate Inside Folder Asset
            new GBFoldersPage().NavigateInsideSubFolderAsset((GBFoldersPage.SubFolderAssetEnum)Enum.
                Parse(typeof(GBFoldersPage.SubFolderAssetEnum), subFolderName));
            Logger.LogMethodExit("GradeBook", "NavigateToTheSubfolderOfAssetInGradebook",
                isTakeScreenShotDuringEntryExit);
        }       

        /// <summary>
        /// Click On Cmenu Of Asset In Gradebook.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu type enum</param>
        /// <param name="assetName">This is Asset name</param>
        [When(@"I click on cmenu ""(.*)"" of asset ""(.*)""")]
        public void ClickOnCmenuOfAssetInGradebook(string assetCmenu,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu Of Asset In Gradebook
            Logger.LogMethodEntry("GradeBook", "ClickOnCmenuOfAssetInGradebook",
                  isTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Frame
            gbInstructorPage.SelectGradebookFrame();
            //Select The Cmenu Option Of Asset
            gbInstructorPage.SelectTheCmenuOptionOfAsset(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), activity.Name);
            Logger.LogMethodExit("GradeBook", "ClickOnCmenuOfAssetInGradebook",
                 isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display of Cmenu Option in Asset Cmenu Options
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option</param>
        /// <param name="assetName">This is Asset Name</param>
        [Then(@"I should see cmenu ""(.*)"" of asset ""(.*)""")]
        public void VerifyDisplayofCmenuOptionInAssetCmenuOptions(string cmenuOption,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Display of Cmenu Option in Asset Cmenu Options
            Logger.LogMethodEntry("GradeBook",
                "VerifyDisplayofCmenuOptionInAssetCmenuOptions",
           base.isTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Frame
            gbInstructorPage.SelectGradebookFrame();
            //Assert Display Of Context Menu Option
            Logger.LogAssertion("VerifyDisplayOfContextMenuOption",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(cmenuOption, gbInstructorPage.
                    GetCmenuOptionofAsset(cmenuOption, activity.Name)));
            Logger.LogMethodExit("GradeBook",
                "VerifyDisplayofCmenuOptionInAssetCmenuOptions",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Apply Grade Schema For the Submitted Activity
        /// </summary>
        [When(@"I 'Apply' the grade schema for the submitted activity")]
        public void ApplyGradeSchemaForSubmittedActivity()
        {
            //Apply Grade Schema For the Submitted Activity
            Logger.LogMethodEntry("GradeBook",
               "ApplyGradeSchemaForSubmittedActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Apply Button
            new GBSchemaPage().ClickOnApplyButton();
            Logger.LogMethodExit("GradeBook",
               "ApplyGradeSchemaForSubmittedActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Updated Schema
        /// </summary>
        /// <param name="schemaValue">This is Schema Value</param>
        [Then(@"I should see the updated schema value ""(.*)""")]
        public void VerifyUpdatedSchema(string schemaValue)
        {
            //Verify the Updated Schema
            Logger.LogMethodEntry("GradeBook",
               "VerifyUpdatedSchema",
                base.isTakeScreenShotDuringEntryExit);
            //Verify Schema Value
            Logger.LogAssertion("VerifySchemaValue", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(schemaValue, new GBFoldersPage().GetGradePresentInCell()));
            Logger.LogMethodExit("GradeBook",
               "VerifyUpdatedSchema",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Update The Schema Value For the Submitted Activity
        /// </summary>
        [When(@"I update the schema of the submitted activity")]
        public void UpdateTheSchemaOfTheSubmittedActivity()
        {
            //Update The Schema Value For the Submitted Activity
            Logger.LogMethodEntry("GradeBook",
               "UpdateTheSchemaOfTheSubmittedActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Update Schema
            new GBSchemaPage().ClickOnUpdateSchema();
            //Edit and Update Schema
            new GBSchemaCreatEditPage().EditAndUpdateSchema();
            Logger.LogMethodExit("GradeBook",
              "UpdateTheSchemaOfTheSubmittedActivity",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save the Update Schema
        /// </summary>
        [When(@"I save the Updated schema")]
        public void SaveTheUpdatedSchema()
        {
            //Save The Updated Schema
            Logger.LogMethodEntry("GradeBook",
               "SaveTheUpdatedSchema",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Apply Button to Save the Updated Schema
            new GBSchemaPage().ClickOnApplyButton();
            Logger.LogMethodExit("GradeBook",
              "SaveTheUpdatedSchema",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Asset in CustomView
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu</param>
        /// <param name="activityTypeEnum">This is Asset Name</param>
        [When(@"I click on cmenu ""(.*)"" of asset ""(.*)"" in Custom View")]
        public void ClickOnCmenuOfAssetInCustomView(string assetCmenu,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu Of Asset in CustomView
            Logger.LogMethodEntry("GradeBook", "ClickOnCmenuOfAssetInCustomView",
                  isTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Fetch Activity From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Custom View Window and Frame
            gbInstructorPage.SelectCustomViewWindowandFrame();
            //Select The Cmenu Option Of Asset
            gbInstructorPage.SelectTheCmenuOptionOfAsset(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), activity.Name);
            Logger.LogMethodExit("GradeBook", "ClickOnCmenuOfAssetInCustomView",
                 isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify All Submission For Particular Activity.
        /// </summary>
        [Then(@"I should see all submission for that particular activity")]
        public void VerifyAllSubmissionForParticularActivity()
        {
            //Verify All Submission For Particular Activity
            Logger.LogMethodEntry("GradeBook", "VerifyAllSubmissionForParticularActivity",
                base.isTakeScreenShotDuringEntryExit);
            // Assert view submission
            Logger.LogAssertion("VerifyAllSubmissionForActivity", ScenarioContext.
               Current.ScenarioInfo.Title, () => Assert.AreEqual(
                   GradeBookResource.GradeBook_Substring_View_NumberofSubmission_Value,
                  new ViewSubmissionPage().GetViewAllSubmissionCount()));
            Logger.LogMethodExit("GradeBook", "VerifyAllSubmissionForParticularActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Asset In Gradebook for TA
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu type enum</param>
        /// <param name="assetName">This is Asset name</param>
        [When(@"I click on cmenu ""(.*)"" of asset ""(.*)"" in TA")]
        public void ClickOnCmenuOfAssetInGradebookforTA(string assetCmenu, string assetName)
        {
            //Click On Cmenu Of Asset In Gradebook for TA
            Logger.LogMethodEntry("GradeBook", "ClickOnCmenuOfAssetInGradebookforTA",
                  isTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Select Frame
            gbInstructorPage.SelectGradebookFrame();
            //Select The Cmenu Option Of Asset
            gbInstructorPage.SelectTheCmenuOptionOfAssetinTA(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), assetName);
            Logger.LogMethodExit("GradeBook", "ClickOnCmenuOfAssetInGradebookforTA",
                 isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Asset in CustomView in TA
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu</param>
        /// <param name="assetName">This is Asset Name</param>
        [When(@"I click on cmenu ""(.*)"" of asset ""(.*)"" in Custom View for TA")]
        public void ClickOnCmenuOfAssetInCustomViewforTA(string assetCmenu,
            string assetName)
        {
            //Click On Cmenu Of Asset in CustomView in TA
            Logger.LogMethodEntry("GradeBook", "ClickOnCmenuOfAssetInCustomViewforTA",
                  isTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Select Custom View Window and Frame
            gbInstructorPage.SelectCustomViewWindowandFrame();
            //Select The Cmenu Option Of Asset
            gbInstructorPage.SelectTheCmenuOptionOfAssetinTA(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), assetName);
            Logger.LogMethodExit("GradeBook", "ClickOnCmenuOfAssetInCustomViewforTA",
                 isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display of Cmenu Option in Asset Cmenu Options in TA
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option</param>
        /// <param name="assetName">This is Asset Name</param>
        [Then(@"I should see cmenu ""(.*)"" of asset ""(.*)"" in TA")]
        public void VerifyDisplayofCmenuOptionInAssetCmenuOptionsinTA(string cmenuOption,
            string assetName)
        {
            //Verify Display of Cmenu Option in Asset Cmenu Options in TA
            Logger.LogMethodEntry("GradeBook",
                "VerifyDisplayofCmenuOptionInAssetCmenuOptionsinTA",
           base.isTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Select Frame
            gbInstructorPage.SelectGradebookFrame();
            //Assert Display Of Context Menu Option
            Logger.LogAssertion("VerifyDisplayOfContextMenuOption",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(cmenuOption, gbInstructorPage.
                    GetCmenuOptionofAssetinTA(cmenuOption, assetName)));
            Logger.LogMethodExit("GradeBook",
                "VerifyDisplayofCmenuOptionInAssetCmenuOptionsinTA",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity Under Grade Cell Cmenu Options.
        /// </summary>
        /// <param name="assetName">This is Asset name</param>
        [When(@"I click on Grade cell cmenu options of asset ""(.*)""")]
        public void ClickOnActivityUnderGradeCellCmenuOptions(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Activity Under Grade Cell Cmenu Options
            Logger.LogMethodEntry("GradeBook", "ClickOnActivityUnderGradeCellCmenuOptions",
                  isTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            Activity activity = Activity.Get(activityTypeEnum);
            //Click The Activity Under Grade Cell Cmenu
            new GBInstructorUXPage().ClickTheActivityUnderGradeCellCmenu(activity.Name);
            Logger.LogMethodExit("GradeBook", "ClickOnActivityUnderGradeCellCmenuOptions",
                isTakeScreenShotDuringEntryExit);
        }       

        /// <summary>
        /// Verify The Cmenu Under Grade Cell Activity
        /// </summary>
        [Then(@"I should see the cmenu under grade cell activity")]
        public void VerifyTheCmenuUnderGradeCellActivity()
        {
            //Verify The Cmenu Under Grade Cell Activity
            Logger.LogMethodEntry("GradeBook", "VerifyTheCmenuUnderGradeCellActivity",
                  isTakeScreenShotDuringEntryExit);
            //Assert Display Of Context Menu Option
            Logger.LogAssertion("VerifyTheCmenuUnderGradeCellActivity",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new GBInstructorUXPage().IsCmenuOptionsDisplayedUnderGradecellActivity()));
            Logger.LogMethodExit("GradeBook", "VerifyTheCmenuUnderGradeCellActivity",
                 isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select the Cmenu Option in Grade Cell.
        /// </summary>
        /// <param name="gradeCellCmenu">This is Garde cell cmenu</param>
        [When(@"I select the ""(.*)"" in grade cell cmenu option")]
        public void SelectCmenuOptionInGradeCell(string gradeCellCmenu)
        {
            //Select the Cmenu Option in Grade Cell
            Logger.LogMethodEntry("GradeBook",
                "SelectCmenuOptionInGradeCell",
                 base.isTakeScreenShotDuringEntryExit);
            //Select the Cmenu Option in Grade Cell
            new GBInstructorUXPage().SelectCmenuOptionInGradeCell(
                (GBInstructorUXPage.GradeCellCmenuOptionTypeEnum)Enum.Parse(
                typeof(GBInstructorUXPage.GradeCellCmenuOptionTypeEnum), gradeCellCmenu));
            Logger.LogMethodExit("GradeBook",
              "SelectCmenuOptionInGradeCell",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Update the Grade for the submitted activity
        /// </summary>
        [When(@"I update the grade for the submitted activity")]
        public void UpdateTheGradeForTheSubmittedActivity()
        {
            //Update the Grade for the submitted activity
            Logger.LogMethodEntry("GradeBook",
                "UpdateTheGradeForTheSubmittedActivity",
                 base.isTakeScreenShotDuringEntryExit);
            //Update the Grade For the Submitted Activity
            new GBInstructorUXPage().UpdateTheGradeForSubmittedActivity();
            Logger.LogMethodExit("GradeBook",
              "UpdateTheGradeForTheSubmittedActivity",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Updated Grade
        /// </summary>
        /// <param name="score">This is Score</param>
        /// <param name="assetName">This is Asset Name</param>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        [Then(@"I should see the updated grade ""(.*)"" for the asset ""(.*)"" for ""(.*)""")]
        public void VerifyTheUpdatedGrade(string score, string assetName, User.UserTypeEnum userTypeEnum)
        {
            //Verify the Updated Grade
            Logger.LogMethodEntry("GradeBook",
                "VerifyTheUpdatedGrade",
                 base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            //Select the window
            new GBInstructorUXPage().SelectGradebookFrame();
            //Verify Updated Grade
            Logger.LogAssertion("VerifyUpdatedGrade", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(score, new GBInstructorUXPage().
                    GetActivityStatus(assetName, user.LastName, user.FirstName)));
            Logger.LogMethodExit("GradeBook",
            "VerifyTheUpdatedGrade",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Grade Icon for Asset Grade
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        [Then(@"I should see the grade icon of ""(.*)"" for ""(.*)""")]
        public void VerifyGradeIconforAssetGrade(string assetName, User.UserTypeEnum userTypeEnum)
       {
           //Verify the Updated Grade
           Logger.LogMethodEntry("GradeBook","VerifyGradeIconforAssetGrade",
                base.isTakeScreenShotDuringEntryExit);
           //Fetch the data from memory
           User user = User.Get(userTypeEnum);
           //Verify Updated Grade
           Logger.LogAssertion("VerifyGradeIconforAssetGrade", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new GBInstructorUXPage().IsGradeCellIconPresent
                   (assetName,user.LastName,user.FirstName)));
           Logger.LogMethodExit("GradeBook","VerifyGradeIconforAssetGrade",
           base.isTakeScreenShotDuringEntryExit);
       }

        /// <summary>
        /// Verify The Instructor Updated View Grade History Score.
        /// </summary>
        /// <param name="userTypeEnum">This is user type</param>
        [Then(@"I should see the score by ""(.*)"" in grade history page")]
        public void VerifyTheInstructorUpdatedViewGradeHistoryScore(User.UserTypeEnum userTypeEnum)
        {
            //Verify The Instructor Updated View Grade History Score
            Logger.LogMethodEntry("GradeBook", "VerifyTheInstructorUpdatedViewGradeHistoryScore",
                 base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            //Verify Previous Old Score Grade
            Logger.LogAssertion("VerifyInstructorUpdatedViewHistoryGrades", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(GradeBookResource.
                    GradeBook_Substring_View_ViewGradeHistory_OldScore_Value, new GBGradeHistoryPage().
                    GetInstructorUpdatedViewGradeHistoryOldScore(user.LastName, user.FirstName)));
            //Verify Updated New Score Grade
            Logger.LogAssertion("VerifyInstructorUpdatedViewHistoryGrades", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(GradeBookResource.
                    GradeBook_Substring_View_ViewGradeHistory_NewScore_Value, new GBGradeHistoryPage().
                    GetInstructorUpdatedViewGradeHistoryNewScore(user.LastName, user.FirstName)));
            Logger.LogMethodExit("GradeBook", "VerifyTheInstructorUpdatedViewGradeHistoryScore",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Columns And Filter Options Displayed In Gradebook.
        /// </summary>
        [Then(@"I should see columns and filter options displayed in gradebook")]
        public void VerifyColumnsAndFilterOptionsDisplayedInGradebook()
        {
            //Verify Columns And Filter Options Displayed In Gradebook
            Logger.LogMethodEntry("GradeBook", "VerifyColumnsAndFilterOptionsDisplayedInGradebook",
                 base.isTakeScreenShotDuringEntryExit);
            //Verify Columns Displayed In Gradebook
            Logger.LogAssertion("VerifyColumnsDisplayedInGradebook", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue (
                    new GBStudentUXPage().IsColumnsDisplayedInGradebook()));
            //Verify Filter option Displayed In Gradebook
            Logger.LogAssertion("VerifyFilteroptionDisplayedInGradebook", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new GBStudentUXPage().IsFilterOptionsDisplayedInGradebook()));
            Logger.LogMethodExit("GradeBook", "VerifyColumnsAndFilterOptionsDisplayedInGradebook",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Folder Navigation Frame And Filter Dropdown
        /// </summary>
        [Then(@"I should see folder navigation frame and filter dropdown")]
        public void VerifyTheFolderNavigationFrameAndFilterDropdown()
        {
            // Verify The Folder Navigation Frame And Filter Dropdown
            Logger.LogMethodEntry("GradeBook","VerifyTheFolderNavigationFrameAndFilterDropdown",
                 base.isTakeScreenShotDuringEntryExit);
            //Verify Folder Frame Displayed In Gradebook
            Logger.LogAssertion("VerifyFolderFrameDisplayedInGradebook", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new GBStudentUXPage().IsFoldernavigationFrameDisplayedInGradebook()));
            //Verify Filter dropdown Displayed In Gradebook
            Logger.LogAssertion("VerifyColumnsDisplayedInGradebook", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new GBStudentUXPage().IsFilterDropDownDisplayedInGradebook()));
            Logger.LogMethodExit("GradeBook","VerifyTheFolderNavigationFrameAndFilterDropdown",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit The Grade In View Submission Window
        /// </summary>
        [When(@"I edit the grade in view submission window")]
        public void EditTheGradeInViewSubmissionWindow()
        {
            // Edit The Grade In View Submission Window
            Logger.LogMethodEntry("GradeBook", "EditTheGradeInViewSubmissionWindow",
                 base.isTakeScreenShotDuringEntryExit);
            //Edit Grades In View Submission page
            new ViewSubmissionPage().EditGradesInViewSubmissionPage();
            Logger.LogMethodExit("GradeBook", "EditTheGradeInViewSubmissionWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// click on create column drop down.
        /// </summary>
        [When(@"I click on the 'Create Column' drop down")]
        public void ClickOnTheCreateColumnDropDown()
        {
            // Open Create Total column pop up window
            Logger.LogMethodEntry("GradeBook", "ClickOnTheCreateColumnDropDown",
                base.isTakeScreenShotDuringEntryExit);
            //Click on Create Column DropDown
            new GBInstructorUXPage().ClickCreateColumnDropDown();
            Logger.LogMethodExit("GradeBook", "ClickOnTheCreateColumnDropDown",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Checkbox Of Activities In TotalColumn.
        /// </summary>
        /// <param name="activityTestTypeEnum">This ia Test Activity type</param>
        /// <param name="behavoirlaModeTypeEnum">This ia Test Activity behaviaral mode type</param>
        [When(@"I select checkbox of ""(.*)"" activity of behavioral mode ""(.*)""")]
        public void SelectCheckboxOfActivitiesInTotalColumn(Activity.ActivityTypeEnum 
            activityTestTypeEnum, Activity.ActivityBehavioralModesEnum 
            behavoirlaModeTypeEnum)
        {
            // Select Checkbox Of Activities In TotalColumn
            Logger.LogMethodEntry("GradeBook", "SelectCheckboxOfActivitiesInTotalColumn",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTestTypeEnum, behavoirlaModeTypeEnum);            
            //Sending first activity to for loop
            new GBInstructorUXPage().SelectActivityFromLeftFrame(activity.Name);
            Logger.LogMethodExit("GradeBook", "SelectCheckboxOfActivitiesInTotalColumn",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add button to Add selected Activities to right Iframe.
        /// </summary>
        [When(@"I should click on Add button")]
        public void ClickAddButtonToAddActivities()
        {
            //Click on add button to add activities
            Logger.LogMethodEntry("GradeBook", "ClickAddButtonToAddActivities",
                base.isTakeScreenShotDuringEntryExit);
            // Add activities to right frame
            new GBInstructorUXPage().AddActivitiesinRightFrame();
            Logger.LogMethodExit("GradeBook", "ClickAddButtonToAddActivities",
               base.isTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Enter Value In WeightBox.
        /// </summary>
        /// <param name="textBoxOption1">This is textbox1</param>
        /// <param name="textBoxOption2">This is textbox2</param>
        [When(@"I have entered ""(.*)"" and ""(.*)"" into weight box")]
        public void EnterValueInWeightBox(String textBoxOption1, String textBoxOption2)
        {
            //Enter integer values in weight box 
            Logger.LogMethodEntry("GradeBook", "EnterValueInWeightBox",
                base.isTakeScreenShotDuringEntryExit);           
            GBInstructorUXPage gbInstructorUXPage = new GBInstructorUXPage(); 
            //Enter value in First text box
            gbInstructorUXPage.EnterTheValueInTotalWeightTextbox((
                GBInstructorUXPage.TextTypeEnum)Enum.
                Parse(typeof(GBInstructorUXPage.TextTypeEnum),
                GradeBookResource.GradeBook_Page_First_TextBox_Option), textBoxOption1);
            //Enter value in Second text box
            gbInstructorUXPage.EnterTheValueInTotalWeightTextbox((
                GBInstructorUXPage.TextTypeEnum)Enum.
               Parse(typeof(GBInstructorUXPage.TextTypeEnum),
               GradeBookResource.GradeBook_Page_Second_TextBox_Option), textBoxOption2);
            Logger.LogMethodExit("GradeBook", "EnterValueInWeightBox",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Value In Total Weight Field.
        /// </summary>
        /// <param name="totalWeightValue">This is Total Weight Value</param>
        [Then(@"I should see the 'Total Weight' field with value ""(.*)""")]
        public void VerifyTheValueInTotalWeightField(string totalWeightValue)
        {
            //Verify The Value In Total Weight Field
            Logger.LogMethodEntry("GradeBook", "VerifyTheValueInTotalWeightField",
                base.isTakeScreenShotDuringEntryExit);
            //Verify The Value In Total Weight Field
            Logger.LogAssertion("VerifyTheValueInTotalWeightTextbox",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(totalWeightValue,
                   new GBTotalColumnPage().GetValueInTotalWeightField()));
            //Close Window
            new ManageOrganisationToolBarPage().CloseWindow(GradeBookResource.
                GradeBook_CreateTotalColumn_Window_Title);
            Logger.LogMethodExit("GradeBook", "VerifyTheValueInTotalWeightField",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Result In Total Weight.
        /// </summary>
        /// <param name="totalWeightScore">This is Total weight score</param>
        [Then(@"I should able to see the result in Total Weight is ""(.*)""")]
        public void VerifyTheResultInTotalWeight(String totalWeightScore)
        {
            //Verify The Result In Total Weight
            Logger.LogMethodEntry("GradeBook", "VerifyTheResultInTotalWeight",
                base.isTakeScreenShotDuringEntryExit);
            //Verifying the return value is correct.
            Logger.LogAssertion("VerifyResultInTotalWeight",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(totalWeightScore,
                   new GBInstructorUXPage().GetRestulInTotalWeightTextBox().
                   Substring(Convert.ToInt32(GradeBookResource.
                   GradeBook_Substring_Start_Index_Value_0),Convert.ToInt16(
                   GradeBookResource.GradeBook_Substring_End_Index_Value_2))));
            Logger.LogMethodExit("GradeBook", "VerifyTheResultInTotalWeight",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Option From Filter Content Type DropDown.
        /// </summary>
        /// <param name="activityType">This is activity type</param>
        [When(@"I click on the ""(.*)"" activity type in filter dropdown")]
        public void SelectOptionFromFilterContentTypeDropDown(string activityType)
        {
            //Click The Activity Type In Filter Dropdown
            Logger.LogMethodEntry("GradeBook", "SelectOptionFromFilterContentTypeDropDown",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Filter Content Type
            new GBStudentUXPage().SelectOptionFromFilterContentTypeDropDown(activityType);
            Logger.LogMethodExit("GradeBook", "SelectOptionFromFilterContentTypeDropDown",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Assets In Gradebook.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity Type Enum.</param>
        [Then(@"I should see the ""(.*)"" activity in Gradebook")]
        public void VerifyTheAssetsInGradebook(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click The Activity Type In Filter Dropdown
            Logger.LogMethodEntry("GradeBook", "VerifyTheAssetsInGradebook",
                base.isTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            //Verifying the asset name
            Logger.LogAssertion("VerifyTheAssetsName",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(activity.Name,
                   new GBStudentUXPage().VerifyTheAssetNameInGradebook(activity.Name)));
            Logger.LogMethodExit("GradeBook", "VerifyTheAssetsInGradebook",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Group In Enrollments Tab.
        /// </summary>        
        [When(@"I create group")]
        public void CreateGroupInEnrollmentTab()
        {
            //Create Group In Enrollments Tab
            Logger.LogMethodEntry("GradeBook", "CreateGroupInEnrollmentTab",
                base.isTakeScreenShotDuringEntryExit);
            //Create Group
            new GBGroupsDefaultUXPage().CreateGroup();
            Logger.LogMethodExit("GradeBook", "CreateGroupInEnrollmentTab",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enroll Student To Group.
        /// </summary>
        [When(@"I enroll student to group")]
        public void EnrollTheStudentToGroup()
        {
            //Enroll Student To Group
            Logger.LogMethodEntry("GradeBook", "EnrollTheStudentToGroup",
                base.isTakeScreenShotDuringEntryExit);
            //Enroll Student To Group
            new GBGroupsDefaultUXPage().EnrollStudentToGroup();
            Logger.LogMethodExit("GradeBook", "EnrollTheStudentToGroup",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Grade Cell Cmenu Of Activity In Gradebook.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I click on the Grade cell cmenu of ""(.*)"" activity in gradebook")]
        public void ClickTheGradeCellCmenuOfActivityInGradebook(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click The Grade Cell Cmenu Of Activity In Gradebook
            Logger.LogMethodEntry("GradeBook",
                "ClickTheGradeCellCmenuOfActivityInGradebook",
                isTakeScreenShotDuringEntryExit);
            //Intialize the object
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Get the activity from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Fetch User from memory
            User user = User.Get(User.UserTypeEnum.CsSmsStudent);
            //Select Window and Frame
            gbInstructorPage.SelectGradebookFrame();
            //Click on Activity Grade Cell Cmenu
            new GBInstructorUXPage().ClickTheActivityGradeCellCmenuInGradebook(
                activity.Name, user.FirstName, user.LastName);
            Logger.LogMethodExit("GradeBook",
                "ClickTheGradeCellCmenuOfActivityInGradebook",
                isTakeScreenShotDuringEntryExit);
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
