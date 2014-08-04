using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.WritingSpace.
    Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class contains Actions related to Launching the Tool.
    /// </summary>
    [Binding]
    public class LaunchTool : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(LaunchTool));

        /// <summary>
        /// Display Of Course Links.
        /// </summary>
        [Then(@"I should see the course links")]
        public void DisplayOfCourseLinks()
        {
            //Display Of Course Links
            Logger.LogMethodEntry("LaunchTool", "DisplayOfCourseLinks",
                base.IsTakeScreenShotDuringEntryExit);
            //Display Of Course Links
            Logger.LogAssertion("VerifyDisplayOfCourseLinks",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new CourseHomeListItemViewPage().IsCourseLinksDisplayed()));
            Logger.LogMethodExit("LaunchTool", "DisplayOfCourseLinks",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click The Pegasus Subtab Link.
        /// </summary>
        /// <param name="tabName">This is Subtab link.</param>
        [When(@"I click the ""(.*)"" link")]
        public void ClickThePegasusSubtabLink(string tabName)
        {
            //Click The Pegasus Subtab Link
            Logger.LogMethodEntry("LaunchTool", "ClickThePegasusSubtabLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Pegasus Subtab Link
            new CourseHomeListItemViewPage().ClickPegasusSubtabLinkInCourseHome(tabName);
            Logger.LogMethodExit("LaunchTool", "ClickThePegasusSubtabLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add New Subtab Link To The Navigation Bar.
        /// </summary>
        [When(@"I add a new Tool/Asset launch subtab link to the navigation bar")]
        public void AddNewSubtabToTheNavigationBar()
        {
            //Add New Subtab To The Navigation Bar
            Logger.LogMethodEntry("LaunchTool", "AddNewSubtabToTheNavigationBar",
                base.IsTakeScreenShotDuringEntryExit);
            //Add New Subtab To The Navigation Bar
            new PostIndexMixedPage().AddNewToolLaunchSubtab(
                new PostIndexMixedPage().GetSubTabLinkName());
            Logger.LogMethodExit("LaunchTool", "AddNewSubtabToTheNavigationBar",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Paste CBOM Request.
        /// </summary>
        /// <param name="linkTypeEnum">This is MMND Link Type Enum.</param>
        [When(@"I paste CBOM request in Tool/Asset launch ""(.*)"" link")]
        public void PasteCBOMRequest(
            MmndToolLinks.LinkTypeEnum linkTypeEnum)
        {
            //Paste CBOM Request
            Logger.LogMethodEntry("LaunchTool", "PasteCBOMRequest",
                   base.IsTakeScreenShotDuringEntryExit);
            //Fetch the Tool link Name from Memory
            MmndToolLinks subtabLinkName = MmndToolLinks.Get(linkTypeEnum);
            //Paste CBOM Request
            new ManagePage().PasteTheCBOMRequest(subtabLinkName.Name);
            Logger.LogMethodExit("LaunchTool", "PasteCBOMRequest",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch Tool From SubTab.
        /// </summary>
        /// <param name="linkTypeEnum">This is MMND Link Type Enum.</param>
        [When(@"I launch Instructor tools from the Tool/Asset launch ""(.*)"" link")]
        public void LaunchInstructorToolFromSubTab(
            MmndToolLinks.LinkTypeEnum linkTypeEnum)
        {
            //Launch Tool From SubTab
            Logger.LogMethodEntry("LaunchTool", "LaunchInstructorToolFromSubTab",
                   base.IsTakeScreenShotDuringEntryExit);
            //Fetch the Tool link Name from Memory
            MmndToolLinks subtabLinkName = MmndToolLinks.Get(linkTypeEnum);
            //Launch Tool From SubTab            
            new ViewPage().PreviewInstructorTodaysViewLink(subtabLinkName.Name);
            Logger.LogMethodExit("LaunchTool", "LaunchInstructorToolFromSubTab",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Successfull Launch Of Instructor Tool.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [Then(@"I should see Instructor tool launched successfully for ""(.*)"" course")]
        public void SuccessfullLaunchOfInstructorTool(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Successfull Launch Of Instructor Tool
            Logger.LogMethodEntry("LaunchTool", "SuccessfullLaunchOfInstructorTool",
                   base.IsTakeScreenShotDuringEntryExit);
            //Get the Course Name
            Course course = Course.Get(courseTypeEnum);
            //Verify Launch Of Instructor Tool
            Logger.LogAssertion("VerifyInstructorToolLaunch",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(course.Name,
                    new ViewPage().GetTheCourseNameFromPegasusWindow(LaunchToolResource.
                    LaunchTool_Page_Instructor_Tool_Window_Title)));
            Logger.LogMethodExit("LaunchTool", "SuccessfullLaunchOfInstructorTool",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch Student Tool From SubTab.
        /// </summary>
        /// <param name="linkTypeEnum">This is MMND Link Type Enum.</param>
        [When(@"I launch Student tool from the Tool/Asset launch ""(.*)"" link")]
        public void LaunchStudentToolFromSubtabLink(
            MmndToolLinks.LinkTypeEnum linkTypeEnum)
        {
            //Launch Student Tool From SubTab
            Logger.LogMethodEntry("LaunchTool", "LaunchStudentToolFromSubtabLink",
                   base.IsTakeScreenShotDuringEntryExit);
            //Fetch the Tool link Name from Memory
            MmndToolLinks subtabLinkName = MmndToolLinks.Get(linkTypeEnum);
            //Launch Student Tool From SubTab            
            new ViewPage().PreviewStudentCourseCalendarLink(subtabLinkName.Name);
            Logger.LogMethodExit("LaunchTool", "LaunchStudentToolFromSubtabLink",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Successfull Launch Of Student Tool.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [Then(@"I should see Student tool launched successfully for ""(.*)"" course")]
        public void SuccessfullLaunchOfStudentTool(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Successfull Launch Of Student Tool
            Logger.LogMethodEntry("LaunchTool", "SuccessfullLaunchOfStudentTool",
                   base.IsTakeScreenShotDuringEntryExit);
            //Get the Course Name
            Course course = Course.Get(courseTypeEnum);
            //Verify Launch Of Student Tool
            Logger.LogAssertion("VerifyStudentToolLaunch",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(course.Name,
                    new ViewPage().GetTheCourseNameFromPegasusWindow(LaunchToolResource.
                    LaunchTool_Page_Student_Tool_Window_Title)));
            Logger.LogMethodExit("LaunchTool", "SuccessfullLaunchOfStudentTool",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch Asset Tool From Asset Launch Subtab.
        /// </summary>
        /// <param name="linkTypeEnum">This is MMND Link Type Enum.</param>
        [When(@"I launch Asset tool from the Tool/Asset launch ""(.*)"" link")]
        public void LaunchAssetToolFromAssetLaunchSubtabLink(
            MmndToolLinks.LinkTypeEnum linkTypeEnum)
        {
            //Launch Asset Tool From SubTab
            Logger.LogMethodEntry("LaunchTool", "LaunchAssetToolFromAssetLaunchSubtabLink",
                   base.IsTakeScreenShotDuringEntryExit);
            //Fetch the Tool link Name from Memory
            MmndToolLinks subtabLinkName = MmndToolLinks.Get(linkTypeEnum);
            //Launch Asset Tool From SubTab            
            new ViewPage().PreviewAssetLink(subtabLinkName.Name);
            Logger.LogMethodExit("LaunchTool", "LaunchAssetToolFromAssetLaunchSubtabLink",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Asset Tool Link Page.
        /// </summary>        
        [Then(@"I should see Asset tool launched successfully for the course")]
        public void DisplayOfAssetToolLinkPage()
        {
            //Successfull Launch Of Asset Tool
            Logger.LogMethodEntry("LaunchTool", "DisplayOfAssetToolLinkPage",
                   base.IsTakeScreenShotDuringEntryExit);
            //Verify Launch Of Asset Tool
            Logger.LogAssertion("VerifyAssetToolLaunch",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new ViewPage().IsAssetToolLinkPageDisplayed()));
            Logger.LogMethodExit("LaunchTool", "DisplayOfAssetToolLinkPage",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Log Out From MMND.
        /// </summary>
        [When(@"I log out from the application")]
        public void LogOutFromMMND()
        {
            //Log Out From MMND
            Logger.LogMethodEntry("LaunchTool", "LogOutFromMMND",
                   base.IsTakeScreenShotDuringEntryExit);
            //Log Out From MMND
            new ViewPage().SignOutFromMMND();
            Logger.LogMethodExit("LaunchTool", "LogOutFromMMND",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside Sub Tab Link Name.
        /// </summary>
        /// <param name="linkTypeEnum">This is MMND Link Type Enum.</param>
        [When(@"I navigate inside the ""(.*)"" subtab")]
        public void NavigateInsideTheSubtabLink(
            MmndToolLinks.LinkTypeEnum linkTypeEnum)
        {
            //Navigate Inside Sub Tab
            Logger.LogMethodEntry("LaunchTool", "NavigateInsideTheSubtabLink",
                   base.IsTakeScreenShotDuringEntryExit);
            //Fetch the Tool link Name from Memory
            MmndToolLinks subtabLinkName = MmndToolLinks.Get(linkTypeEnum);
            //Navigate to Sub Tab
            new ViewPage().NavigateInsideSubTabLink(subtabLinkName.Name);
            Logger.LogMethodExit("LaunchTool", "NavigateInsideTheSubtabLink",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fetch And Store Pegasus Course Id.
        /// </summary>
        [When(@"I fetch and store pegasus course id")]
        public void FetchAndStorePegasusCourseId()
        {
            //Fetch And Store Pegasus Course Id
            Logger.LogMethodEntry("LaunchTool", "FetchAndStorePegasusCourseId",
                   base.IsTakeScreenShotDuringEntryExit);
            //Click on Support Link
            new TodaysViewUXPage().ClickonSupportLink();
            //Fetch And Store CourseId
            new SupportPage().FetchAndStoreCourseId();            
            Logger.LogMethodExit("LaunchTool", "FetchAndStorePegasusCourseId",
                   base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
