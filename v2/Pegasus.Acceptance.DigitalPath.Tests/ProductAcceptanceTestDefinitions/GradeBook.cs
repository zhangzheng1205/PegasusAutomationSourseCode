using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles GradeBook Page actions.
    /// </summary>
    [Binding]
    public class GradeBook : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(GradeBook));

        /// <summary>
        /// click on create column drop down.
        /// </summary>
        [When(@"I click on the 'Create Column' drop down")]
        public void ClickOnTheCreateColumnDropDown()
        {
            // Open Create Total column pop up window
            Logger.LogMethodEntry("GradeBook", "ClickOnTheCreateColumnDropDown",
                base.IsTakeScreenShotDuringEntryExit);
            new GBInstructorUXPage().ClickCreateColumnDropDown();
            Logger.LogMethodExit("GradeBook", "ClickOnTheCreateColumnDropDown",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select activities from Left Iframe.
        /// </summary>
        /// <param name="activityName1">This is the first activity name.</param>
        /// <param name="activityName2">This is the second activity name.</param>
        [When(@"I select checkbox of activities ""(.*)"" and ""(.*)""")]
        public void SelectCheckboxOfActivities(String activityName1, String activityName2)
        {
            // Select activities for adding
            Logger.LogMethodEntry("GradeBook", "SelectCheckboxOfActivities",
                base.IsTakeScreenShotDuringEntryExit);
            //Sending first activity to for loop
            new GBInstructorUXPage().SelectActivityFromLeftFrame(activityName1);
            //Sending second activity to for loop
            new GBInstructorUXPage().SelectActivityFromLeftFrame(activityName2);
            Logger.LogMethodExit("GradeBook", "SelectCheckboxOfActivities",
               base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click on Add button to Add selected Activities to right Iframe.
        /// </summary>
        [When(@"I should be click the on Add button")]
        public void ClickAddButtonToAddActivities()
        {
            //Click on add button to add activities
            Logger.LogMethodEntry("GradeBook", "ClickAddButtonToAddActivities",
                base.IsTakeScreenShotDuringEntryExit);
            // Add activities to right frame
            new GBInstructorUXPage().AddActivitiesinRightFrame();
            Logger.LogMethodExit("GradeBook", "ClickAddButtonToAddActivities",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Calculate the Total weight by passing numeric values to the text box.
        /// </summary>
        /// <param name="textOption1">This indicates the which text box.</param>
        /// <param name="textOption2">This is the numeric value to enter in text box.</param>
        [When(@"I have entered ""(.*)"" and ""(.*)"" into weight box")]
        public void EnterValueInWeightBox(String textOption1, String textOption2)
        {
            //Enter integer values in weight box 
            Logger.LogMethodEntry("GradeBook", "EnterValueInWeightBox",
                base.IsTakeScreenShotDuringEntryExit);
            //Enter value in First text box
            new GBInstructorUXPage().EnterTheValueInTotalWeightTextbox((
                GBInstructorUXPage.TextTypeEnum)Enum.
                Parse(typeof(GBInstructorUXPage.TextTypeEnum),
                GradeBookResource.GradeBook_Page_First_TextBox_Option), textOption1);
            //Enter value in Second text box
            new GBInstructorUXPage().EnterTheValueInTotalWeightTextbox((
                GBInstructorUXPage.TextTypeEnum)Enum.
               Parse(typeof(GBInstructorUXPage.TextTypeEnum),
               GradeBookResource.GradeBook_Page_Second_TextBox_Option), textOption2);
            Logger.LogMethodExit("GradeBook", "EnterValueInWeightBox",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Result will be displayed in the Total weight text box .
        /// </summary>
        [Then(@"I should able to see the result in Total Weight Textbox")]
        public void CheckTheResultInTotalWeightTextbox()
        {
            //Check result in TotalWeight Textbox
            Logger.LogMethodEntry("GradeBook", "CheckTheResultInTotalWeightTextbox",
                base.IsTakeScreenShotDuringEntryExit);
            //Verifying the return value is correct.
            Logger.LogAssertion("VerifyResultInTotalWeightTextbox",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(GradeBookResource.
                   GradeBook_Page_TotalWeight_TextBox_Result_Value,
                   new GBInstructorUXPage().GetRestulInTotalWeightTextBox()));
            Logger.LogMethodExit("GradeBook", "CheckTheResultInTotalWeightTextbox",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Of Asset and Select Apply Button.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I select ""(.*)"" cmenu of studyplan ""(.*)""")]
        public void SelectCmenuOfAssetandSelectApplyButton(string assetCmenu,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select Cmenu Of Asset and Select Apply Button
            Logger.LogMethodEntry("GradeBook", "SelectCmenuOfAssetandSelectApplyButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();   
            //Select Window and Frame
            new TodaysViewUxPage().SelectwindowandFrame();
            //Select Cmenu Of Asset
            gbInstructorPage.SelectCmenuOptionOfAssetinGradebook(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), activity.Name);
            //Click On Apply Button
            new GBSchemaPage().ClickOnApplyButton();
            Logger.LogMethodExit("GradeBook", "SelectCmenuOfAssetandSelectApplyButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Activity Status in Gradebook for Enrollled Students.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="activityStatus">This is Activity Status.</param>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see the ""(.*)"" activity status ""(.*)"" in Gradebook for the enrollled ""(.*)""")]
        public void VerifyTheActivityStatusInGradebook(
            Activity.ActivityTypeEnum activityTypeEnum,
           string activityStatus, User.UserTypeEnum userTypeEnum)
        {
            //Verify Activity Status in Gradebook for Enrollled Students
            Logger.LogMethodEntry("GradeBook",
                "VerifyTheActivityStatusInGradebook",
                 IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Fetch the data from memory
            User user = User.Get(userTypeEnum);
            //Select the window
            new TodaysViewUxPage().SelectwindowandFrame();
            //Assert Activity Status for Enrolled User in Gradebook
            Logger.LogAssertion("VerifyActivityDisplayInGradebook",
               ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(activityStatus,
                 new GBInstructorUXPage().GetActivityStatus
                 (activity.Name, user.LastName, user.FirstName)));
            Logger.LogMethodExit("GradeBook",
                "VerifyTheActivityStatusInGradebook",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On View Grade Of Asset.
        /// </summary>
        /// <param name="assetName">This is Activity Type Enum.</param>
        [When(@"I click on view grade of ""(.*)"" in Gradebook")]
        public void ClickOnViewGradeOfAsset(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On View Grade Of Asset
            Logger.LogMethodEntry("GradeBook","ClickOnViewGradeOfAsset",
                IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Select Window and Frame
            new TodaysViewUxPage().SelectwindowandFrame();
            //Get Activity Name and Click On View Grade Of Asset
            new GBInstructorUXPage().GetActivityName(activity.Name);
            Logger.LogMethodExit("GradeBook","ClickOnViewGradeOfAsset",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit The Grade.
        /// </summary>
        /// <param name="userScore">This is User Score.</param>
        /// <param name="maximumScore">This is Maximum Score.</param>
        [When(@"I edit the grade with user score ""(.*)"" and maximum score ""(.*)""")]
        public void EditTheGrade(string userScore, string maximumScore)
        {
            //Edit The Grade
            Logger.LogMethodEntry("GradeBook", "EditTheGrade",
                IsTakeScreenShotDuringEntryExit);
            //Edit Grade
            new GBGradeBatchUpdationPage().EditGrade(userScore, maximumScore);
            Logger.LogMethodExit("GradeBook", "EditTheGrade",
                IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select Asset Cmenu.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I select ""(.*)"" cmenu of ""(.*)""")]
        public void SelectAssetCmenu(string assetCmenu,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select Asset Cmenu
            Logger.LogMethodEntry("GradeBook", "SelectAssetCmenu",
                IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Select Window and Frame
            new TodaysViewUxPage().SelectwindowandFrame();
            //Select Cmenu Of Asset
            gbInstructorPage.SelectCmenuOptionOfAssetinGradebook(
                (GBInstructorUXPage.AssetCmenuOptionEnum)Enum.Parse(typeof(
                GBInstructorUXPage.AssetCmenuOptionEnum), assetCmenu), activity.Name);
            Logger.LogMethodExit("GradeBook", "SelectAssetCmenu",
                IsTakeScreenShotDuringEntryExit);
        }


    }
}
