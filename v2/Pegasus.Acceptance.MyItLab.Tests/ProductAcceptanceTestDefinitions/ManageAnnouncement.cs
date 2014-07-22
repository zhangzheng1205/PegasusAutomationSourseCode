using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles Announcement Actions.
    /// </summary>
    [Binding]
    public class ManageAnnouncement : PegasusBaseTestFixture
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ManageAnnouncement));

        /// <summary>
        /// VerifSy The CourseName In GlobalHome.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [Then(@"I should see the ""(.*)"" mycourse in global home")]
        public void VerifSyTheCourseNameInGlobalHome(Course.CourseTypeEnum courseTypeEnum)
        {
            //VerifSy The CourseName In GlobalHome
            Logger.LogMethodEntry("ManageAnnouncement", "VerifSyTheCourseNameInGlobalHome",
               base.isTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Course course = Course.Get(courseTypeEnum);
            //Get MyCourse Name In GlobalHome
            Logger.LogAssertion("VerifyCourseName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(course.Name,
                     new HEDGlobalHomePage().GetMyCourseNameInGlobalHome(course.Name)));
            Logger.LogMethodExit("ManageAnnouncement", "VerifSyTheCourseNameInGlobalHome",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The ManageAll Buuton In Announcement Channel.
        /// </summary>
        [Then(@"I shold the 'Manage All' buuton in announcement channel")]
        public void VerifyTheManageAllBuutonInAnnouncementChannel()
        {
            //Verify The ManageAll Buuton In Announcement Channel
            Logger.LogMethodEntry("ManageAnnouncement",
                "VerifyTheManageAllBuutonInAnnouncementChannel",
               base.isTakeScreenShotDuringEntryExit);
            //Verify The Announcement Manage All Button
            Logger.LogAssertion("VerifyTheAnnouncementManageAllButton",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new HEDGlobalHomePage().
                   IsAnnouncementChannelManageAllButtonDisplayed()));
            Logger.LogMethodExit("ManageAnnouncement",
                "VerifyTheManageAllBuutonInAnnouncementChannel",
               base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Change The Time Zone.
        /// </summary>
        [When(@"I changed the WS User Time Zone to Indian GMT in MyProfile")]
        public void ChangeWSUserTimeZoneToIndianGmtInMyProfile()
        {
            //Changing Time Zone 
            Logger.LogMethodEntry("ManageAnnouncement",
                "ChangeWSUserTimeZoneToIndianGmtInMyProfile",
                base.isTakeScreenShotDuringEntryExit);
            //Click on My Profile Link
            new MyPegasusUXPage().ClickMyProfileLinkByWSUser();
            //Changing the Time Zone
            new MyAccountSettingPage().ChangeTimeZoneInMyProfile(
                ManageAnnouncementResource.
                ManageAnnouncement_MyProfile_IndianTimeZone_Value);
            Logger.LogMethodExit("ManageAnnouncement",
                "ChangeWSUserTimeZoneToIndianGmtInMyProfile",
               base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Verifying Display of Announcement in Announcement Frame.
        /// </summary>
        /// <param name="announcementTypeEnum">This is Annoucement Type Enum.</param>
        [Then(@"I should see the details of  ""(.*)"" Announcement in Announcement Frame")]
        public void VerifyAnnouncementInAnnouncementFrame(Announcement.
                   AnnouncementTypeEnum announcementTypeEnum)
        {
            //Verifying Display of Announcement in Announcement frame
            Logger.LogMethodEntry("ManageAnnouncement", "VerifyAnnouncementInAnnouncementFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Get announcement From Memory
            Announcement announcement = Announcement.Get(announcementTypeEnum);
            //Declaration Page Class Object
            AnnouncementDefaultUXPage announcementDefaultUxPage =
                new AnnouncementDefaultUXPage();
            //Select Announcement Frame
            announcementDefaultUxPage.SelectAnnouncementFrame();
            //Assert for Announcement Display
            Logger.LogAssertion("VerifyAnnouncementDisplay", ScenarioContext.
             Current.ScenarioInfo.Title, () => Assert.AreEqual(announcement.Name,
               announcementDefaultUxPage.GetAnnouncementDetails(announcement.Name)));
            //Close the light box
            announcementDefaultUxPage.CloseAnnoucementLightBox();
            Logger.LogMethodExit("ManageAnnouncement", "VerifyAnnouncementInAnnouncementFrame",
               base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Create Course Announcement In GlobalHome.
        /// </summary>
        /// <param name="announcementTypeEnum">This is Announcement Type Enum.</param>
        [When(@"I create ""(.*)"" course Announcement")]
        public void CreateCourseAnnouncementInWorkspaceGlobalHome(
            Announcement.AnnouncementTypeEnum announcementTypeEnum)
        {
            //Create Course Announcement In GlobalHome
            Logger.LogMethodEntry("ManageAnnouncement",
                "CreateCourseAnnouncementInWorkspaceGlobalHome",
                    base.isTakeScreenShotDuringEntryExit);
            //Course announcement creation in workspace global home
            new CreateAnnouncementUXPage().
                CreateCourseAnnouncementInWorkSpaceGlobalHome(announcementTypeEnum);
            Logger.LogMethodExit("ManageAnnouncement",
                "CreateCourseAnnouncementInWorkspaceGlobalHome",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifying successfull message for Course Announcement Creation.
        /// </summary>
        /// <param name="successMessage">This is successfull message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in Announcements Frame")]
        public void VerifySuccessfullMessageInAnnouncementsFrame(
            String successMessage)
        {
            //Verify Display of Announcement Creation successfull message 
            Logger.LogMethodEntry("ManageAnnouncement",
                "VerifySuccessfullMessageInAnnouncementsFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Assert for Successfull Message Displayed
            Logger.LogAssertion("VerifyAnnouncementMessage", ScenarioContext.
                   Current.ScenarioInfo.Title, () => Assert.AreEqual(successMessage,
                   new AnnouncementDefaultUXPage().GetCourseAnnouncementSuccessfullMessage()));
            Logger.LogMethodExit("ManageAnnouncement",
                "VerifySuccessfullMessageInAnnouncementsFrame",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The View By Dropdown Of Announcement.
        /// </summary>
        [When(@"I click the ""(.*)"" View By dropdown")]
        public void ClickTheViewByDropdownOfAnnouncement(string announcementType)
        {
            //Click The View By Dropdown Of Announcement
            Logger.LogMethodEntry("ManageAnnouncement",
                "ClickTheViewByDropdownOfAnnouncement",
                base.isTakeScreenShotDuringEntryExit);
            //Click The View By Dropdown Of Announcement
            new AnnouncementDefaultUXPage().
                SelectClassAnnouncementsTypeFromDropdown(announcementType);
            Logger.LogMethodExit("ManageAnnouncement",
                "ClickTheViewByDropdownOfAnnouncement",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Displayed Announcement Dropdown Options.
        /// </summary>
        /// <param name="table">This is Table Reference.</param>
        [Then(@"I should see the displayed dropdown options")]
        public void VerifyTheDisplayedAnnouncementDropdownOptions(Table table)
        {
            //Verify The Displayed Announcement Dropdown Options
            Logger.LogMethodEntry("ManageAnnouncement",
                "VerifyTheDisplayedAnnouncementDropdownOptions",
                      base.isTakeScreenShotDuringEntryExit);
            foreach (var tableRow in table.Rows)
            {
                //Assert correct dropdown options are opened
                TableRow row = tableRow;
                Logger.LogAssertion("VerifyDropdownOptions", ScenarioContext.
                    Current.ScenarioInfo.Title,
                () => Assert.AreEqual(row[ManageAnnouncementResource.
                    ManageAnnouncement_Expected_Result],
                    new AnnouncementDefaultUXPage().
                    GetDisplayOfAnnouncementDropdownOptions(row[
                    ManageAnnouncementResource.
                    ManageAnnouncement_Actual_Result])));
                Logger.LogMethodExit("ManageAnnouncement",
                   "VerifyTheDisplayedAnnouncementDropdownOptions",
                         base.isTakeScreenShotDuringEntryExit);
            }
        }
    }
}
