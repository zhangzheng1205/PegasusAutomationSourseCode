using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    ///  This class handles Create Announcement actions.
    /// </summary>
    [Binding]
    public class CreateAnnouncement : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CreateAnnouncement));

        /// <summary>
        /// Click On Manage All Button In GlobalHome.
        /// </summary>
        [When(@"I click on the 'Manage All' button in global home")]
        public void ClickOnManageAllButtonInGlobalHome()
        {
            //Click On Manage All Button In GlobalHome
            Logger.LogMethodEntry("CreateAnnouncement",
                  "ClickOnManageAllButtonInGlobalHome",
                             base.isTakeScreenShotDuringEntryExit);
            //Click The Manage All Button In GlobalHome
            new HomePage().ClickTheManageAllButtonInGlobalHome();
            Logger.LogMethodExit("CreateAnnouncement",
                  "ClickOnManageAllButtonInGlobalHome",
                            base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Create Class Announcement In CourseSpace.
        /// </summary>
        /// <param name="announcementType">This is Announcement Type.</param>
        [When(@"I create ""(.*)"" Announcement in coursespace")]
        public void CreateClassAnnouncementInCourseSpace(
            Announcement.AnnouncementTypeEnum announcementType)
        {
            //Create Class Announcement In CourseSpace
            Logger.LogMethodEntry("CreateAnnouncement", 
                "CreateClassAnnouncementInCourseSpace",
                 base.isTakeScreenShotDuringEntryExit);
            //Create the class Announcement           
            new CreateAnnouncementUXPage().
                CreateClassAnnouncementInGlobalHome(announcementType);
            Logger.LogMethodExit("CreateAnnouncement", 
                "CreateClassAnnouncementInCourseSpace",
              base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verifying successfull message for Course Announcement Creation.
        /// </summary>
        /// <param name="successMessage">This is successfull message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in Announcements Frame")]
        public void VerifySuccessfullMessageInAnnouncementsFrame(
            string successMessage)
        {
            //Verify Display of Announcement Creation successfull message 
            Logger.LogMethodEntry("CreateAnnouncement",
                "VerifySuccessfullMessageInAnnouncementsFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Assert for Successfull Message Displayed
            Logger.LogAssertion("", ScenarioContext.
                Current.ScenarioInfo.Title, 
                () => Assert.AreEqual(successMessage,
                new AnnouncementDefaultUXPage().
                GetCourseAnnouncementSuccessfullMessage()));
            //Close the light box
            new AnnouncementDefaultUXPage().CloseAnnoucementLightBox();
            Logger.LogMethodExit("CreateAnnouncement",
                "VerifySuccessfullMessageInAnnouncementsFrame",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Announcements Type in 'View by' Dropdown.
        /// </summary>
        /// <param name="announcementType">This is announcement by type.</param>
        [When(@"I select ""(.*)"" in 'View by' drop down")]
        public void SelectAnnouncementsInDropDown(
            string announcementType)
        {
            Logger.LogMethodEntry("CreateAnnouncement", 
                "SelectAnnouncementsInDropDown",
                  base.isTakeScreenShotDuringEntryExit);
            //Select 'System Announcements' in Dropdown
            new AnnouncementDefaultUXPage().
                SelectClassAnnouncementsTypeFromDropdown(announcementType);
            Logger.LogMethodExit("CreateAnnouncement",
                "SelectAnnouncementsInDropDown",
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
            //Select the frame
            announcementDefaultUxPage.SelectGlobalAnnouncementframe();
            //Assert for Announcement Display
            Logger.LogAssertion("VerifyAnnouncementDisplay", ScenarioContext.
             Current.ScenarioInfo.Title, () => Assert.AreEqual(announcement.Name,
               announcementDefaultUxPage.GetAnnouncementDetails(announcement.Name)));
            //Close the light box
            announcementDefaultUxPage.CloseAnnoucementLightBox();
            Logger.LogMethodExit("CreateAnnouncement",
                "VerifyAnnouncementInAnnouncementLightBox",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
