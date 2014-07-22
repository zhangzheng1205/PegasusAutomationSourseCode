using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.HigherEducation.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the Announcement Related Actions.
    /// </summary>
    [Binding]
    public class ManageAnnouncement : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ManageAnnouncement));

        /// <summary>
        /// Changing the Time zone in My Profile to Indian GMT.
        /// </summary>
        [When(@"I change the WS Admin Time Zone to Indian GMT in MyProfile")]
        public void ChangeWSAdminTimeZoneToIndianGmt()
        {
            //Changing Time Zone to Indian GMT
            Logger.LogMethodEntry("ManageAnnouncement",
                "ChangeWSAdminTimeZoneToIndianGmt",
                base.isTakeScreenShotDuringEntryExit);
            //Click on My Profile Link
            new AdminToolPage().ClickMyProfileLinkByWSAdmin();
            //Changing the Time Zone
            new MyAccountSettingPage().ChangeTimeZoneInMyProfile(
                ManageAnnouncementResource.
                ManageAnnouncement_MyProfile_IndianTimeZone_Value);
            Logger.LogMethodExit("ManageAnnouncement",
                "ChangeWSAdminTimeZoneToIndianGmt",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Announcement.
        /// </summary>
        /// <param name="announcementTypeEnum">This is 
        /// Announcement Type Enum..</param>
        [When(@"I create ""(.*)"" Announcement")]
        public void CreateAnnouncement(
            Announcement.AnnouncementTypeEnum announcementTypeEnum)
        {
            //Creation of Announcement
            Logger.LogMethodEntry("ManageAnnouncement", "CreateAnnouncement",
                base.isTakeScreenShotDuringEntryExit);
            switch (announcementTypeEnum)
            {
                case Announcement.AnnouncementTypeEnum.CsSystem:
                case Announcement.AnnouncementTypeEnum.WsSystem:
                    //Click on Create Announcement Link
                    new AnnouncementArchivePage().ClickCreateAnnouncementLink();
                    //Creation of System Announcement
                    new CreateAnnouncementPage().
                        CreateSystemAnnouncement(announcementTypeEnum);
                    break;
                case Announcement.AnnouncementTypeEnum.CsCourse:
                    //Click On Manage All Button
                    new TodaysViewUXPage().ClickOnManageAllButtonHED();
                    //Create Course Announcement in CourseSpace
                    new CreateAnnouncementUXPage().
                        CreateAnnouncementInSideCourseHED(announcementTypeEnum);
                    break;
            }
            Logger.LogMethodExit("ManageAnnouncement", "CreateAnnouncement",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Changing Time Zone by Course Space User.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I change the Time Zone to Indian GMT in MyProfile by ""(.*)""")]
        public void ChangeCourseSpaceUserTimeZoneToIndianGmtInMyProfile(
            User.UserTypeEnum userTypeEnum)
        {
            //Changing Time Zone 
            Logger.LogMethodEntry("ManageAnnouncement",
                "ChangeCourseSpaceUserTimeZoneToIndianGmtInMyProfile",
                base.isTakeScreenShotDuringEntryExit);
            //Click on My Profile Link
            new HomePage().ClickMyProfileLink(userTypeEnum);
            //Changing the Time Zone
            new MyAccountSettingPage().ChangeTimeZoneInMyProfile(
                ManageAnnouncementResource.
                ManageAnnouncement_MyProfile_IndianTimeZone_Value);
            Logger.LogMethodExit("ManageAnnouncement",
                "ChangeCourseSpaceUserTimeZoneToIndianGmtInMyProfile",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Successfull Message In Announcements Frame.
        /// </summary>
        /// <param name="successMessage">This is Success Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in Announcements Frame")]
        public void VerifySuccessfullMessageInAnnouncementsFrame(
            String successMessage)
        {
            //Verify Display of Announcement Creation successfull message
            Logger.LogMethodEntry("ManageAnnouncement",
                "VerifySuccessfullMessageInAnnouncementsFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Assert for Successfull Message Displayed
            Logger.LogAssertion("VerifySuccessfullMessage",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(successMessage,
                    new AnnouncementDefaultUXPage().
                    GetCourseAnnouncementSuccessfullMessage()));
            //Close the light box
            new AnnouncementDefaultUXPage().CloseAnnoucementLightBox();
            Logger.LogMethodExit("ManageAnnouncement",
                "VerifySuccessfullMessageInAnnouncementsFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Annoucement Type in Drop Down.
        /// </summary>
        /// <param name="announcementType">This is Announment Type.</param>
        [When(@"I select ""(.*)"" in 'View by' drop down")]
        public void SelectAnnouncementTypeInDropDown(
            String announcementType)
        {
            //Select Annoucement Type in Drop Down
            Logger.LogMethodEntry("ManageAnnouncement",
                "SelectAnnouncementTypeInDropDown",
                base.isTakeScreenShotDuringEntryExit);
            //Click ManageAll Button
            new TodaysViewUXPage().ClickOnManageAllButtonHED();
            //Select Announcement Frame
            new CreateAnnouncementUXPage().SelectAnnouncmentFrame();
            //Select Announcement Type in Drop Down
            new AnnouncementDefaultUXPage().
                SelectAnnouncementsTypeInDropDownHED(announcementType);
            Logger.LogMethodExit("ManageAnnouncement",
                "SelectAnnouncementTypeInDropDown",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display Of Announcement.
        /// </summary>
        /// <param name="announcementTypeEnum">This is Announcement Type Enum.</param>
        [Then(@"I should see the details of ""(.*)"" Announcement in Announcement Light box")]
        public void VerifyDisplayOfAnnouncement(
            Announcement.AnnouncementTypeEnum
            announcementTypeEnum)
        {
            //Verify Display Of Announcement
            Logger.LogMethodEntry("ManageAnnouncement",
                "VerifyDisplayOfAnnouncement",
            base.isTakeScreenShotDuringEntryExit);
            //Verify Announcement Display
            new CreateAnnouncementUXPage().SelectAnnouncmentFrame();
            //Get Announcement Details from Memory
            Announcement announcement = Announcement.Get(announcementTypeEnum);
            //Assert for Announcement Display
            Logger.LogAssertion("VerifyDisplayOfAnnouncement",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(announcement.Name,
                    new AnnouncementDefaultUXPage().
                    GetAnnouncementDetails(announcement.Name)));
            // Close Annoucement LightBox
            new AnnouncementDefaultUXPage().CloseAnnoucementLightBox();
            Logger.LogMethodExit("ManageAnnouncement", "VerifyDisplayOfAnnouncement",
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
                ManageAnnouncementResource.ManageAnnouncement_MyProfile_IndianTimeZone_Value);
            Logger.LogMethodExit("ManageAnnouncement",
                "ChangeWSUserTimeZoneToIndianGmtInMyProfile",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the System Announcement in Announcement channel.
        /// </summary>
        /// <param name="announcementTypeEnum">This is Annoucement Type Enum.</param>
        [When(@"I click on the ""(.*)"" Announcement listed in Announcement Channel")]
        public void SelectAnnouncementInAnnouncementChannel(Announcement.
                                    AnnouncementTypeEnum announcementTypeEnum)
        {
            //Selecting announcement in global home page
            Logger.LogMethodEntry("ManageAnnouncement",
                "SelectAnnouncementInAnnouncementChannel",
                base.isTakeScreenShotDuringEntryExit);
            //Select Announcement 
            new MyPegasusUXPage().SelectAnnouncement(announcementTypeEnum);
            Logger.LogMethodExit("ManageAnnouncement",
                "SelectAnnouncementInAnnouncementChannel",
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
            // Close Annoucement LightBox
            announcementDefaultUxPage.CloseAnnoucementLightBox();
            Logger.LogMethodExit("ManageAnnouncement", "VerifyAnnouncementInAnnouncementFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
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
