#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Create Announcement actions.
    /// </summary>
    [Binding]
    public class CreateAnnouncement : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CreateAnnouncement));

        /// <summary>
        /// Changing the Time zone in MyProfile to Indian GMT.
        /// </summary>
        [When(@"I changed the WS Admin Time Zone to Indian GMT in MyProfile")]
        public void ChangeWSAdminTimeZoneToIndianGmtInMyProfile()
        {
            //Changing Time Zone 
            Logger.LogMethodEntry("CreateAnnouncement",
                "ChangeWSAdminTimeZoneToIndianGmtInMyProfile",
                base.isTakeScreenShotDuringEntryExit);
            //Click on My Profile Link
            new AdminToolPage().ClickMyProfileLinkByWSAdmin();
            //Changing the Time Zone
            new MyAccountSettingPage().ChangeTimeZoneInMyProfile(
                CreateAnnouncementResource.
                CreateAnnouncement_MyProfile_IndianTimeZone_Value);
            Logger.LogMethodExit("CreateAnnouncement",
                "ChangeWSAdminTimeZoneToIndianGmtInMyProfile",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Change The Time Zone.
        /// </summary>
        [When(@"I changed the WS User Time Zone to Indian GMT in MyProfile")]
        public void ChangeWSUserTimeZoneToIndianGmtInMyProfile()
        {
            //Changing Time Zone 
            Logger.LogMethodEntry("CreateAnnouncement",
                "ChangeWSUserTimeZoneToIndianGmtInMyProfile",
                base.isTakeScreenShotDuringEntryExit);
            //Click on My Profile Link
            new MyPegasusUXPage().ClickMyProfileLinkByWSUser();
            //Changing the Time Zone
            new MyAccountSettingPage().ChangeTimeZoneInMyProfile(
                CreateAnnouncementResource.
                CreateAnnouncement_MyProfile_IndianTimeZone_Value);
            Logger.LogMethodExit("CreateAnnouncement",
                "ChangeWSUserTimeZoneToIndianGmtInMyProfile",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Creating System Announcement.
        /// </summary>
        /// <param name="announcementTypeEnum">This is announcement type enum.</param>
        [When(@"I create ""(.*)"" Announcement")]
        public void CreateSystemAnnouncement(Announcement.
                                    AnnouncementTypeEnum announcementTypeEnum)
        {
            //Creation of Announcement
            Logger.LogMethodEntry("CreateAnnouncement", "CreateSystemAnnouncement",
                base.isTakeScreenShotDuringEntryExit);
            //Click on Create Announcement Link
            new AnnouncementArchivePage().ClickCreateAnnouncementLink();
            //Creation of System Announcement
            new CreateAnnouncementPage().CreateSystemAnnouncement(announcementTypeEnum);
            Logger.LogMethodExit("CreateAnnouncement", "CreateSystemAnnouncement",
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
            Logger.LogMethodEntry("CreateAnnouncement",
                "SelectAnnouncementInAnnouncementChannel",
                base.isTakeScreenShotDuringEntryExit);
            //Select Announcement 
            new MyPegasusUXPage().SelectAnnouncement(announcementTypeEnum);
            Logger.LogMethodExit("CreateAnnouncement",
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
            Logger.LogMethodEntry("CreateAnnouncement", "VerifyAnnouncementInAnnouncementFrame",
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
            Logger.LogMethodExit("CreateAnnouncement", "VerifyAnnouncementInAnnouncementFrame",
               base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Verifying Display of Announcement in Light box.
        /// </summary>
        /// <param name="announcementTypeEnum">This is Annoucement Type Enum.</param>
        [Then(@"I should see the details of  ""(.*)"" Announcement in Announcement Light box")]
        public void VerifyAnnouncementInAnnouncementLightBox(Announcement.
                   AnnouncementTypeEnum announcementTypeEnum)
        {
            //Verifying Display of Announcement in lightbox
            Logger.LogMethodEntry("CreateAnnouncement",
                "VerifyAnnouncementInAnnouncementLightBox",
                base.isTakeScreenShotDuringEntryExit);
            //Get announcement From Memory
            Announcement announcement = Announcement.Get(announcementTypeEnum);
            //Declaration Page Class Object
            AnnouncementDefaultUXPage announcementDefaultUxPage =
                new AnnouncementDefaultUXPage();
            //Select Announcement Frame
            announcementDefaultUxPage.SelectAnnouncementLightBoxFrame();
            //Assert for Announcement Display
            Logger.LogAssertion("VerifyAnnouncementDisplay", ScenarioContext.
             Current.ScenarioInfo.Title, () => Assert.AreEqual(announcement.Name,
               announcementDefaultUxPage.GetAnnouncementDetails(announcement.Name)));
            // Close Annoucement LightBox
            announcementDefaultUxPage.CloseAnnoucementLightBox();
            Logger.LogMethodExit("CreateAnnouncement",
                "VerifyAnnouncementInAnnouncementLightBox",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Course Announcement.
        /// </summary>
        [When(@"I create Course Announcement")]
        public void CreateCourseAnnouncement()
        {
            //Creating Course Announcement
            Logger.LogMethodEntry("CreateAnnouncement", "CreateCourseAnnouncement",
                 base.isTakeScreenShotDuringEntryExit);
            //Course announcement creation
            new CreateAnnouncementUXPage().CreateCourseAnnouncement();
            Logger.LogMethodExit("CreateAnnouncement", "CreateCourseAnnouncement",
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
            Logger.LogMethodEntry("CreateAnnouncement",
                "VerifySuccessfullMessageInAnnouncementsFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Assert for Successfull Message Displayed
            Logger.LogAssertion("VerifyAnnouncementDisplay", ScenarioContext.
                   Current.ScenarioInfo.Title, () => Assert.AreEqual(successMessage,
                   new AnnouncementDefaultUXPage().GetCourseAnnouncementSuccessfullMessage()));
            //Close the light box
            new AnnouncementDefaultUXPage().CloseAnnoucementLightBox();
            Logger.LogMethodExit("CreateAnnouncement",
                "VerifySuccessfullMessageInAnnouncementsFrame",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the 'Messeges' link.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type Enum.</param>
        [When(@"I click on the Messages and select the View All link by ""(.*)""")]
        public void ClickMessegesLinkAndSelectViewAllLink(
            User.UserTypeEnum userTypeEnum)
        {
            //Click on the 'Messeges' link
            Logger.LogMethodEntry("CreateAnnouncement",
                "ClickMessegesLinkAndSelectViewAllLink",
                 base.isTakeScreenShotDuringEntryExit);
            //Click on the 'Messeges' Link and Select ViewAll Link
            new HomePage().SelectAnnouncementViewAllLink(userTypeEnum);
            Logger.LogMethodExit("CreateAnnouncement",
                "ClickMessegesLinkAndSelectViewAllLink",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the'Create Announcement' button.
        /// </summary>
        /// <param name="announcementType">This is Announcement Type.</param>
        [When(@"I create ""(.*)"" Announcement in coursespace")]
        public void CreateClassAnnouncementInCourseSpace(
            Announcement.AnnouncementTypeEnum announcementType)
        {
            //Click on the 'Create Announcement' button
            Logger.LogMethodEntry("CreateAnnouncement", "CreateClassAnnouncementInCourseSpace",
                 base.isTakeScreenShotDuringEntryExit);
            //Create the class Announcement           
            new CreateAnnouncementUXPage().CreateClassAnnouncement(announcementType);
            Logger.LogMethodExit("CreateAnnouncement", "CreateClassAnnouncementInCourseSpace",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Announcements Type in 'View by' Dropdown.
        /// </summary>
        /// <param name="announcementType">This is announcement by type.</param>
        [When(@"I select ""(.*)"" in 'View by' drop down")]
        public void SelectAnnouncementsInDropDown(
            String announcementType)
        {
            Logger.LogMethodEntry("CreateAnnouncement", "SelectAnnouncementsInDropDown",
                  base.isTakeScreenShotDuringEntryExit);
            //Select 'System Announcements' in Dropdown
            new AnnouncementDefaultUXPage().SelectAnnouncementsTypeInDropdown(announcementType);
            Logger.LogMethodExit("CreateAnnouncement", "SelectAnnouncementsInDropDown",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Changing Time Zone by Cs user.
        /// </summary>
        [When(@"I changed the CS User Time Zone to Indian GMT in MyProfile by ""(.*)""")]
        public void ChangeCsUserTimeZoneToIndianGmtInMyProfile(
            User.UserTypeEnum userType)
        {
            //Changing Time Zone 
            Logger.LogMethodEntry("CreateAnnouncement", "ChangeCsUserTimeZoneToIndianGmtInMyProfile",
                base.isTakeScreenShotDuringEntryExit);
            //Click on My Profile Link
            new HomePage().ClickMyProfileLink(userType);
            //Changing the Time Zone
            new MyAccountSettingPage().ChangeTimeZoneInMyProfile(CreateAnnouncementResource.
                CreateAnnouncement_MyProfile_IndianTimeZone_Value);
            Logger.LogMethodExit("CreateAnnouncement", "ChangeCsUserTimeZoneToIndianGmtInMyProfile",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create CS course announcement.
        /// </summary>
        [When(@"I create CS Course Announcement")]
        public void CreateCsCourseAnnouncement()
        {
            Logger.LogMethodEntry("CreateAnnouncement", "CreateCsCourseAnnouncement",
                base.isTakeScreenShotDuringEntryExit);
            //Click ManageAll Button
            new TodaysViewUXPage().ClickAnnouncementManageAllButton();
            //Create Course Announcement in CS
            new CreateAnnouncementUXPage().CreateCourseAnnouncementInCs();
            Logger.LogMethodExit("CreateAnnouncement", "CreateCsCourseAnnouncement",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>.
        /// Deinitialize Pegasus test after the execution of test
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
