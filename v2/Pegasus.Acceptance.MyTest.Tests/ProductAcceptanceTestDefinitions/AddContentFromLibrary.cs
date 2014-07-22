using Pegasus.Automation.DataTransferObjects;
using TechTalk.SpecFlow;
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Acceptance.MyTest.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handle all functionality of Add From Library Page.
    /// </summary>
    [Binding]
    class AddContentFromLibrary : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(AddContentFromLibrary));

        /// <summary>
        /// Click on folder in Add Course Materials pane.
        /// </summary>
        /// <param name="expectedFolderName">This is name of folder.</param>
        [When(@"I click on '(.*)' folder in Add Course Materials")]
        public void ClickOnFolderInAddCourseMaterials(string expectedFolderName)
        {
            //Click on folder in Add Course Materials pane
            Logger.LogMethodEntry("AddContentFromLibrary", "ClickOnFolderInAddCourseMaterials",
                base.isTakeScreenShotDuringEntryExit);
            //Click on MyTest folder in Add From Library
            new TeachingPlanUXPage().
                ClickOnFolderInAddCourseMaterialsFrame(expectedFolderName);
            //Logger exist
            Logger.LogMethodExit("AddContentFromLibrary", "ClickOnFolderInAddCourseMaterials",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the availability of MyTest assets in My Test Folder.
        /// on Add content from library page.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        [Then(@"I should see the '(.*)' in My Test Folder in Add content from library")]
        public void SeeTheMyTestInMyTestFolder(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Logger Enrty
            Logger.LogMethodEntry("AddContentFromLibrary", "SeeTheMyTestInMyTestFolder",
                base.isTakeScreenShotDuringEntryExit);
            //Get the name of My Test assets
            Activity activity = Activity.Get(activityTypeEnum);
            //Assert Display of My Test assest in MYTest Folder
            Logger.LogAssertion("VerifySuccessfullMessage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new TeachingPlanUXPage().GetMyTestAssestsName(
                    activity.Name)));
            //Logger exist
            Logger.LogMethodExit("AddContentFromLibrary", "SeeTheMyTestInMyTestFolder",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Contents From Content Library To MyCourse Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type.</param>
        [When(@"I add the ""(.*)"" activity from Content Library to MyCourse frame")]
        public void AddContentsFromContentLibraryToMyCourseFrame(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Add Contents From Content Library To MyCourse Frame
            Logger.LogMethodEntry("AddContentFromLibrary",
                "AddContentsFromContentLibraryToMyCourseFrame",
                isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Select Window
            contentLibraryUXPage.SelectTheWindowName(AddContentFromLibraryResource.
                AddContentFromLibrarry_CourseMaterials_Window_Title);
            //Select the frame
            contentLibraryUXPage.SelectAndSwitchtoFrame(AddContentFromLibraryResource.
                AddContentFromLibrarry_CourseMaterials_LeftFrame_Id_Locator);
            // Select the activity
            contentLibraryUXPage.SelectActivity(activity.Name);
            // Click on Activity Add Button
            contentLibraryUXPage.ClickOnActivityAddButton();
            Logger.LogMethodExit("AddContentFromLibrary",
                "AddContentsFromContentLibraryToMyCourseFrame",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Contents From Content Library To MyCourse Frame in CourseSpace.
        /// </summary>
        [When(@"I add the 'MyTest' activity from Content Library to MyCourse frame in CourseSpace")]
        public void AddContentsFromContentLibraryToMyCourseFrameInCourseSpace()
        {
            //Add Contents From Content Library To MyCourse Frame in CourseSpace
            Logger.LogMethodEntry("AddContentFromLibrary",
                "AddContentsFromContentLibraryToMyCourseFrameInCourseSpace",
                isTakeScreenShotDuringEntryExit);            
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Select Window
            contentLibraryUXPage.SelectTheWindowName(AddContentFromLibraryResource.
                AddContentFromLibrarry_CourseMaterials_Window_Title);
            //Select the frame
            contentLibraryUXPage.SelectAndSwitchtoFrame(AddContentFromLibraryResource.
                AddContentFromLibrarry_CourseMaterials_LeftFrame_Id_Locator);
            // Select the activity
            contentLibraryUXPage.SelectActivity(AddContentFromLibraryResource.
                    AddContentFromLibrary_MyTestActivity_Name);
            // Click on Activity Add Button
            contentLibraryUXPage.ClickOnActivityAddButton();
            Logger.LogMethodExit("AddContentFromLibrary",
                "AddContentsFromContentLibraryToMyCourseFrameInCourseSpace",
                isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Asserts the Activity Name in My Course Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is the Activity by Type Enum.</param>
        [Then(@"I should see ""(.*)"" activity in the MyCourse Frame")]
        public void DisplayOfActivityInMyCourseFrame(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify the Activity Name added to the My Course Frame
            Logger.LogMethodEntry("AddContentFromLibrary", "DisplayOfActivityInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Gets the Activity name from Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyAssignedActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetActivityName(activity.Name)));
            Logger.LogMethodExit("AddContentFromLibrary", "DisplayOfActivityInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Asserts the Activity Name in My Course Frame In CourseSpace.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        [Then(@"I should see ""(.*)"" activity in the MyCourse Frame in CourseSpace")]
        public void DisplayOfActivityInMyCourseFrameInCourseSpace(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Asserts the Activity Name in My Course Frame In CourseSpace
            Logger.LogMethodEntry("AddContentFromLibrary", 
                "DisplayOfActivityInMyCourseFrameInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the activity from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyAssignedActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetActivityName(activity.Name)));
            Logger.LogMethodExit("AddContentFromLibrary",
                "DisplayOfActivityInMyCourseFrameInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Click The Activity Cmenu Option In MyCourse Frame.
        /// </summary>
        [When(@"I click the activity ShowHide cmenu option in MyCourse Frame")]
        public void ClickTheActivityCmenuOptionInMyCourseFrame()
        {
            //Click The Activity Cmenu Option In MyCourse Frame
            Logger.LogMethodEntry("AddContentFromLibrary",
                "ClickTheActivityCmenuOptionInMyCourseFrame",
               base.isTakeScreenShotDuringEntryExit);
            // Click On The Activity Cmenu In MyCourse Frame
            new CourseContentUXPage().ClickTheActivityShowHideCmenuInMyCourseFrame();
            Logger.LogMethodExit("AddContentFromLibrary",
                "ClickTheActivityCmenuOptionInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Activity CmenuOption In MyCourseFrame.
        /// </summary>
        [When(@"I click the activity cmenu option in MyCourse Frame")]
        public void SelectTheActivityCmenuOptionInMyCourseFrame()
        {
            //Select The Activity CmenuOption In MyCourseFrame
            Logger.LogMethodEntry("AddContentFromLibrary",
                "SelectTheActivityCmenuOptionInMyCourseFrame",
               base.isTakeScreenShotDuringEntryExit);
            // Click On The Activity Cmenu In MyCourse Frame
            new CourseContentUXPage().ClickTheActivityCmneuImageIcon();
            Logger.LogMethodExit("AddContentFromLibrary",
                "SelectTheActivityCmenuOptionInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Click On ShowHide Status Option.
        /// </summary>
        [When(@"I click on 'ShowHide' option of Activity")]
        public void ClickOnShowHideStatusOption()
        {
            //Click On ShowHide Status Option
            Logger.LogMethodEntry("AddContentFromLibrary", "ClickOnShowHideStatusOption",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Activity Type
            new CourseContentUXPage().ClickTheShowHideStatusOption();
            Logger.LogMethodExit("AddContentFromLibrary", "ClickOnShowHideStatusOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Cmenu of Activity.
        /// </summary>
        /// <param name="cmenuOption">This is cmenu option.</param>
        [When(@"I click on ""(.*)"" cmenu option")]
        public void ClickTheCmenuofActivity(
            String cmenuOption)
        {
            //Click The Cmenu of Activity
            Logger.LogMethodEntry("AddContentFromLibrary", "ClickTheCmenuofActivity"
               , base.isTakeScreenShotDuringEntryExit);
            //Click On Cmenu of Activity
            new CourseContentUXPage().ClickTheCmenuOptionofActivity(cmenuOption);
            Logger.LogMethodExit("AddContentFromLibrary", "ClickTheCmenuofActivity"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display Of CMenu Options For Activity.
        /// </summary>
        /// <param name="table">This is Table Reference.</param>
        [Then(@"I should able to see the Display of c-menu options for activity")]
        public void VerifyTheDisplayOfCMenuOptionsForActivity(Table table)
        {
            //Verify The Display Of CMenu Options For Activity.
            Logger.LogMethodEntry("AddContentFromLibrary",
                 "VerifyTheDisplayOfCMenuOptionsForActivity",
                 base.isTakeScreenShotDuringEntryExit);
            foreach (var tableRow in table.Rows)
            {
                //Assert correct pages are opened
                TableRow row = tableRow;
                Logger.LogAssertion("VerifyCmenuOptions", ScenarioContext.
                    Current.ScenarioInfo.Title,
                () => Assert.AreEqual(row[AddContentFromLibraryResource.
                    AddContentFromLibrary_Expected_Cmenu_Options_Displayed],
                    new CourseContentUXPage().GetDisplayOfActivityCmenuOptions(row[
                    AddContentFromLibraryResource.
                    AddContentFromLibrary_Actual_Cmenu_Options_Displayed])));
            }
            Logger.LogMethodExit("AddContentFromLibrary",
                "VerifyTheDisplayOfCMenuOptionsForActivity",
                  base.isTakeScreenShotDuringEntryExit);
        }

    }
}
