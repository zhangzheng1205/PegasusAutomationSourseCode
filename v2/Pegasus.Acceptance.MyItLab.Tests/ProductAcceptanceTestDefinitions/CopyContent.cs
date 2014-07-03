using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public class CopyContent : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CopyContent));


        /// <summary>
        /// Search Section
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I search the ""(.*)"" first section")]
        public void SearchFirstSection(Course.CourseTypeEnum courseTypeEnum)
        {
            //Search Section
            Logger.LogMethodEntry("CopyContent", "SearchFirstSection",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Search Section
            new ManageTemplatePage().SearchSection(course.SectionName + 
                CopyContentResource.CopyContent_SecondSection_Value);
            Logger.LogMethodExit("CopyContent", " SearchFirstSection",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Asset In Course Materials Library
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        [When(@"I search the ""(.*)"" in Course Materials Library")]
        public void SearchAssetInCourseMaterialsLibrary(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Search Asset In Course Materials Library
            Logger.LogMethodEntry("CopyContent", "SearchAssetInCourseMaterialsLibrary",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Search Asset
            new ContentLibraryUXPage().GetActivityNameInContentLibrary(activity.Name);
            Logger.LogMethodExit("CopyContent", "SearchAssetInCourseMaterialsLibrary",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Option of Activity
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option</param>
        [When(@"I select the Cmenu option ""(.*)""")]
        public void SelectCmenuOptionOfActivity(string cmenuOption)
        {
            //Select Cmenu Option of Activity
            Logger.LogMethodEntry("CopyContent", "SelectCmenuOptionOfActivity",
               base.isTakeScreenShotDuringEntryExit);
            //Select Cmenu Option of Activity
            new ContentLibraryUXPage().SelectCmenuOptionOfActivity(cmenuOption);
            Logger.LogMethodExit("CopyContent", "SelectCmenuOptionOfActivity",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Sections
        /// </summary>
        [When(@"I select the 'Multiple Sections'")]
        public void SelectSections()
        {
            //Select Sections
            Logger.LogMethodEntry("CopyContent", "SelectSections",
             base.isTakeScreenShotDuringEntryExit);
            //Select Sections
            new UserTemplateSectionsPage().SelectSectionsCheckBoxAndClickAddButton();
            Logger.LogMethodExit("CopyContent", " SelectSections",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Home Button
        /// </summary>
        [When(@"I select 'Home' option")]
        public void SelectHomeButton()
        {
            //Select Home Button
            Logger.LogMethodEntry("CopyContent", "SelectHomeButton",
            base.isTakeScreenShotDuringEntryExit);
            TeachingPlanUXPage teachingPlanUxPage = new TeachingPlanUXPage();
            //Select Course Materials Window
            teachingPlanUxPage.SelectCourseMaterialsWindow();
            //Click On Home Button
            teachingPlanUxPage.ClickOnHomeButton();
            Logger.LogMethodExit("CopyContent", " SelectHomeButton",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Second Section
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I search the ""(.*)"" second section")]
        public void SearchSecondSection(Course.CourseTypeEnum courseTypeEnum)
        {
            //Search Section
            Logger.LogMethodEntry("CopyContent", "SearchSecondSection",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Search Section
            new ManageTemplatePage().SearchSection(course.SectionName + 
                CopyContentResource.CopyContent_FirstSection_Value);
            Logger.LogMethodExit("CopyContent", " SearchSecondSection",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Asset In My Course Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I search the ""(.*)"" in My Course frame")]
        public void SearchAssetInMyCourseFrame(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Search Asset In My Course Frame
            Logger.LogMethodEntry("CopyContent", "SearchAssetInMyCourseFrame",
              base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Search Asset In My Course Frame
            new CourseContentUXPage().SearchAssetInMyCourseFrame(activity.Name);
            Logger.LogMethodExit("CopyContent", " SearchAssetInMyCourseFrame",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Activity Cmenu Option In MyCourse Frame.
        /// </summary>
        [When(@"I click the activity ShowHide cmenu option in MyCourse Frame")]
        public void ClickTheActivityCmenuOptionInMyCourseFrame()
        {
            //Click The Activity Cmenu Option In MyCourse Frame
            Logger.LogMethodEntry("CopyContent",
                "ClickTheActivityCmenuOptionInMyCourseFrame",
               base.isTakeScreenShotDuringEntryExit);
            // Click On The Activity Cmenu In MyCourse Frame
            new CourseContentUXPage().ClickOnShowHideCmenuOptionforAssetInFireFox();
            Logger.LogMethodExit("CopyContent",
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
            Logger.LogMethodEntry("CopyContent",
                "SelectTheActivityCmenuOptionInMyCourseFrame",
               base.isTakeScreenShotDuringEntryExit);
            // Click On The Activity Cmenu In MyCourse Frame
            new CourseContentUXPage().ClickTheActivityCmneuImageIcon();
            Logger.LogMethodExit("CopyContent",
                "SelectTheActivityCmenuOptionInMyCourseFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Asset Name In 'My Course' Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        [Then(@"I should see the ""(.*)"" in 'My Course'")]
        public void VerifyAssetNameInMyCourse(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify The Asset Name In 'My Course' Frame
            Logger.LogMethodEntry("CopyContent", "VerifyAssetNameInMyCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Verify The Searched Asset Name
            Logger.LogAssertion("VerifyAssetName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetAssetNameFromMyCourseTab(activity.Name)));
            Logger.LogMethodExit("CopyContent", "VerifyAssetNameInMyCourse",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Cmenu of Activity.
        /// </summary>
        /// <param name="cmenuOption">This is cmenu option.</param>
        [When(@"I click on ""(.*)"" cmenu option")]
        public void ClickTheCmenuofActivity(string cmenuOption)
        {
            //Click The Cmenu of Activity
            Logger.LogMethodEntry("CopyContent", "ClickTheCmenuofActivity"
               , base.isTakeScreenShotDuringEntryExit);
            //Click On Cmenu of Activity
            new CourseContentUXPage().ClickTheCmenuOptionofActivity(cmenuOption);
            Logger.LogMethodExit("CopyContent", "ClickTheCmenuofActivity"
                , base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify Activity Name
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        [Then(@"I should see the activity ""(.*)"" in 'Course Materials'")]
        public void VerifyActivityName(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Activity Name
            Logger.LogMethodEntry("CopyContent", "VerifyActivityName"
              , base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Asserts the Ativity Name
            Logger.LogAssertion("VerifyActivityName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new CoursePreviewUXPage().
                    GetActivityNameInCourseMaterialsTab(activity.Name)));
            Logger.LogMethodExit("CopyContent", "VerifyActivityName"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Asset In My Content Library.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralTypeEnum">This is Behavioral Type Enum.</param>
        [When(@"I search ""(.*)"" activity of behavioral mode ""(.*)"" type")]
        public void SearchAssetInContentLibrary(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralTypeEnum)
        {
            //Search Asset In Content Library Frame
            Logger.LogMethodEntry("CopyContent", "SearchAssetInContentLibrary",
              base.isTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Fetch the activity from memory
            Activity activity = Activity.Get(activityTypeEnum, behavioralTypeEnum);
            //Select Window
            contentLibraryUXPage.SelectTheWindowName(CopyContentResource.
                CopyContent_CourseMaterials_Window_Title);
            //Select the frame
            contentLibraryUXPage.SelectAndSwitchtoFrame(CopyContentResource.
                CopyContent_CourseMaterials_LeftFrame_Id_Locator);
            //Search Asset In Content Library Frame
            contentLibraryUXPage.SearchTheActivity(activity.Name);            
            Logger.LogMethodExit("CopyContent", " SearchAssetInContentLibrary",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Assigned' Radiobutton.
        /// </summary>
        [When(@"I select 'Assigned' radiobutton")]
        public void SelectAssignedRadiobutton()
        {
            //Select 'Assigned' Radiobutton
            Logger.LogMethodEntry("CopyContent", "SelectAssignedRadiobutton",
              base.isTakeScreenShotDuringEntryExit);
            //Select 'Assigned' Radiobutton
            new AssignContentPage().SelectAssignedRadiobutton();
            Logger.LogMethodExit("CopyContent", " SelectAssignedRadiobutton",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Set availability date range' Radiobutton.
        /// </summary>
        [When(@"I select 'Set availability date range' radiobutton")]
        public void SelectSetavailabilitydaterangeRadiobutton()
        {
            //Select 'Set availability date range' Radiobutton
            Logger.LogMethodEntry("CopyContent",
                "SelectSetavailabilitydaterangeRadiobutton",
              base.isTakeScreenShotDuringEntryExit);
            //Select 'Set availability date range' Radiobutton
            new AssignContentPage().SelectSetavailabilitydaterangeRadiobutton();
            Logger.LogMethodExit("CopyContent",
                " SelectSetavailabilitydaterangeRadiobutton",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable 'Do Not Provide An End Date' Option.
        /// </summary>
        [When(@"I enable 'Do not provide an End Date' option")]
        public void EnableDoNotProvideAnEndDateOption()
        {
            //Enable 'Do Not Provide An End Date' Option
            Logger.LogMethodEntry("CopyContent",
                "EnableDoNotProvideAnEndDateOption",
              base.isTakeScreenShotDuringEntryExit);
            //Select 'Do Not Provide An End Date' Option
            new AssignContentPage().SelectDoNotProvideEndDateOption();
            Logger.LogMethodExit("CopyContent",
                " EnableDoNotProvideAnEndDateOption",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The 'Start PreTest' Button.
        /// </summary>
        [Then(@"I should see the 'Start Pre-Test' button")]
        public void VerifyTheStartPreTestButton()
        {
            //Verify The 'Start PreTest' Button
            Logger.LogMethodEntry("CopyContent",
                "VerifyTheStartPreTestButton",
              base.isTakeScreenShotDuringEntryExit);
            //Verify The 'Start PreTest' Button
            Logger.LogAssertion("VerifyStartPretestButton",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new SIMStudyPlanStudentUXPage().
                    IsStartPreTestButtonPresent()));
            Logger.LogMethodExit("CopyContent",
                " VerifyTheStartPreTestButton",
              base.isTakeScreenShotDuringEntryExit);
        }

    }
}
