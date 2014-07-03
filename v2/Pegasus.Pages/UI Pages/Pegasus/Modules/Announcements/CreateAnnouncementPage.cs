using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Announcements;
using System.Threading;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the create announcement acctions.
    /// </summary>
    public class CreateAnnouncementPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(CreateAnnouncementPage));


        /// <summary>
        /// Creation of System Announcement.
        /// </summary>
        /// <param name="announcementTypeEnum">This is announcement by type.</param>
        public void CreateSystemAnnouncement(Announcement.
            AnnouncementTypeEnum announcementTypeEnum)
        {
            //Create System Announcement
            logger.LogMethodEntry("CreateAnnouncementPage", "CreateSystemAnnouncement",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Generate New Guid announcement Name
                Guid announcementGuid = Guid.NewGuid();
                //Select Create Announcement Window
                this.SelectCreateAnnouncementWindow();
                // Enter subject
                this.EnterSubject(announcementGuid.ToString());
                // Intialization from date for announcement
                DateTime fromDate = DateTime.Now.AddMinutes(Convert.ToInt32(
                    CreateAnnouncementPageResource.
                    CreateAnnouncement_AnnouncementFromDate_AddMinutes_Value));
                // Intialization of to date for announcement
                DateTime toDate = fromDate.AddHours(Convert.ToInt32(
                    CreateAnnouncementPageResource.
                    CreateAnnouncement_AnnouncementToDate_AddHours_Value));
                // Enter Start and End Date
                this.EnterAnnouncementFromAndToDate(fromDate, toDate, announcementTypeEnum);
                // Enter Start and End Hour
                this.EnterAnnouncementFromAndToHour(fromDate, toDate);
                // Enter Start and End Minute
                this.EnterAnnouncementFromAndToMinute(fromDate, toDate);
                // Click on Show Html image
                base.ClickButtonByID(CreateAnnouncementPageResource.
                    CreateAnnouncement_Page_ShowHTML_Image_Id_Locator);
                //Enter Description
                this.EnterAnnouncementDescription(announcementGuid);
                //Click Save Button
                base.ClickButtonByID(CreateAnnouncementPageResource.
                    CreateAnnouncement_Page_Save_Button_Id_Locator);
                Thread.Sleep(Convert.ToInt32(CreateAnnouncementPageResource.
                    CreateAnnouncement_Page_CustomTimeToWait_Value));
                // Check Create Announcement pop up is closed
                if (base.IsPopUpClosed(2))
                {
                    //Storing Announcement Name In Memory
                    this.StoreAnnouncementDetailsInMemory(announcementGuid, announcementTypeEnum);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateAnnouncementPage", "CreateSystemAnnouncement",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter subject.
        /// </summary>
        /// <param name="announcement">This is Announcement name.</param> 
        private void EnterSubject(string announcement)
        {
            //Enter subject for announcement
            logger.LogMethodEntry("CreateAnnouncementPage", "EnterSubject",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CreateAnnouncementPageResource.
               CreateAnnouncement_Page_Subject_TextBox_Id_Locator));
            // Enter subject
            base.FillTextBoxByID(CreateAnnouncementPageResource.
                CreateAnnouncement_Page_Subject_TextBox_Id_Locator, announcement);
            logger.LogMethodExit("CreateAnnouncementPage", "EnterSubject",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Create Announcement' Window.
        /// </summary>
        private void SelectCreateAnnouncementWindow()
        {
            //Selecting Create Announcement Window
            logger.LogMethodEntry("CreateAnnouncementPage", "SelectCreateAnnouncementWindow",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(CreateAnnouncementPageResource.
                CreateAnnouncement_Page_Window_Title);
            //Select Window
            base.SelectWindow(CreateAnnouncementPageResource.
                CreateAnnouncement_Page_Window_Title);
            logger.LogMethodExit("CreateAnnouncementPage", "SelectCreateAnnouncementWindow",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Description.
        /// </summary>
        /// <param name="announcementGuid">This is announcement Description Guid.</param>
        private void EnterAnnouncementDescription(Guid announcementGuid)
        {
            //Entering Description for announcement
            logger.LogMethodEntry("CreateAnnouncementPage", "EnterDescriptionForAnnouncement",
               base.isTakeScreenShotDuringEntryExit);
            WaitForElement(By.Id(CreateAnnouncementPageResource.
                  CreateAnnouncement_Page_HTMLEditor_TextArea_Id_Locator));
            //Enter Description in HTMLEditor TextArea
            base.FillTextBoxByID(CreateAnnouncementPageResource.
                  CreateAnnouncement_Page_HTMLEditor_TextArea_Id_Locator, announcementGuid.ToString());
            logger.LogMethodExit("CreateAnnouncementPage", "EnterDescriptionForAnnouncement",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Start and End Minute.
        /// </summary>
        /// <param name="fromDate">This is the startDate.</param>
        /// <param name="toDate">This is the endDate.</param>
        private void EnterAnnouncementFromAndToMinute(DateTime fromDate, DateTime toDate)
        {
            logger.LogMethodEntry("CreateAnnouncementPage", "EnterAnnouncementFromAndToMinute",
               base.isTakeScreenShotDuringEntryExit);
            // Focus on element
            base.FocusOnElementByID(CreateAnnouncementPageResource.
                       CreateAnnouncement_Page_StartMinute_TextBox_Id_Locator);
            base.ClearTextByID(CreateAnnouncementPageResource.
                      CreateAnnouncement_Page_StartMinute_TextBox_Id_Locator);
            //Enter Start Minute
            base.FillTextBoxByID(CreateAnnouncementPageResource.
                 CreateAnnouncement_Page_StartMinute_TextBox_Id_Locator,
                 fromDate.ToString(CreateAnnouncementPageResource.
                CreateAnnouncement_Page_MinuteFormat_Value));
            // Focus on element
            base.FocusOnElementByID(CreateAnnouncementPageResource.
                     CreateAnnouncement_Page_EndMinute_TextBox_Id_Locator);
            base.ClearTextByID(CreateAnnouncementPageResource.
                     CreateAnnouncement_Page_EndMinute_TextBox_Id_Locator);
            // Enter End Minute
            base.FillTextBoxByID(CreateAnnouncementPageResource.
                 CreateAnnouncement_Page_EndMinute_TextBox_Id_Locator,
                 toDate.ToString(CreateAnnouncementPageResource.
                CreateAnnouncement_Page_MinuteFormat_Value));
            logger.LogMethodExit("CreateAnnouncementPage", "EnterAnnouncementFromAndToMinute",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Start and End Hour.
        /// </summary>
        /// <param name="fromDate">This is the from Date.</param>
        /// <param name="toDate">This is the to Date.</param>
        private void EnterAnnouncementFromAndToHour(DateTime fromDate, DateTime toDate)
        {
            logger.LogMethodEntry("CreateAnnouncementPage", "EnterAnnouncementFromAndToHour",
               base.isTakeScreenShotDuringEntryExit);
            // Focus on element
            base.FocusOnElementByID(CreateAnnouncementPageResource.
                      CreateAnnouncement_Page_StartHour_TextBox_Id_Locator);
            base.ClearTextByID(CreateAnnouncementPageResource.
                  CreateAnnouncement_Page_StartHour_TextBox_Id_Locator);
            //Enter Start Hour
            base.FillTextBoxByID(CreateAnnouncementPageResource.
                  CreateAnnouncement_Page_StartHour_TextBox_Id_Locator,
                 fromDate.Hour.ToString());
            // Focus on element           
            base.FocusOnElementByID(CreateAnnouncementPageResource.
                       CreateAnnouncement_Page_EndHour_TextBox_Id_Locator);
            base.ClearTextByID(CreateAnnouncementPageResource.
                       CreateAnnouncement_Page_EndHour_TextBox_Id_Locator);
            //Enter End Hour
            base.FillTextBoxByID(CreateAnnouncementPageResource.
                  CreateAnnouncement_Page_EndHour_TextBox_Id_Locator,
                  toDate.Hour.ToString());
            logger.LogMethodExit("CreateAnnouncementPage", "EnterAnnouncementFromAndToHour",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Start and End Date.
        /// </summary>
        /// <param name="fromDate">This is the From Date.</param>
        /// <param name="toDate">This is the To Date.</param>
        /// <param name="announcementTypeEnum">This is Announcement Type Enum</param>
        private void EnterAnnouncementFromAndToDate(DateTime fromDate, DateTime toDate,
            Announcement.AnnouncementTypeEnum announcementTypeEnum)
        {
            //Entering Start and End Date  for Announcement
            logger.LogMethodEntry("CreateAnnouncementPage", "EnterAnnouncementFromAndToDate",
               base.isTakeScreenShotDuringEntryExit);
            switch (announcementTypeEnum)
            {
                case Announcement.AnnouncementTypeEnum.CsSystem:
                    //Enter Start  Date 
                    //string format = base.GetElementTextByID("txtStartDateTimeId_lblDateFormat");                    
                    base.FillTextBoxByID(CreateAnnouncementPageResource.
                        CreateAnnouncement_Page_StartDate_TextBox_Id_Locator,
                        fromDate.ToString(CreateAnnouncementPageResource.
                        CreateAnnouncement_Page_CsDateFormat_Value));
                    //Enter End Date
                    base.FillTextBoxByID(CreateAnnouncementPageResource.
                        CreateAnnouncement_Page_EndDate_TextBox_Id_Locator,
                        toDate.ToString(CreateAnnouncementPageResource.
                        CreateAnnouncement_Page_CsDateFormat_Value));
                    break;
                case Announcement.AnnouncementTypeEnum.WsSystem:
                    //Enter Start  Date 
                    base.FillTextBoxByID(CreateAnnouncementPageResource.
                        CreateAnnouncement_Page_StartDate_TextBox_Id_Locator,
                        fromDate.ToShortDateString());
                    //Enter End Date
                    base.FillTextBoxByID(CreateAnnouncementPageResource.
                        CreateAnnouncement_Page_EndDate_TextBox_Id_Locator,
                        toDate.ToShortDateString());
                    break;
            }
            logger.LogMethodExit("CreateAnnouncementPage", "EnterAnnouncementFromAndToDate",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Storing Announcement Name InMemory.
        /// </summary>
        /// <param name="announcementGuid">This is Announcement Name Guid.</param>
        /// <param name="announcementTypeEnum">This is Announcement type.</param>
        private void StoreAnnouncementDetailsInMemory(Guid announcementGuid,
            Announcement.AnnouncementTypeEnum announcementTypeEnum)
        {
            logger.LogMethodEntry("CreateAnnouncementPage", "StoreAnnouncementDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
            // Code need to be added
            Announcement announcement = new Announcement
            {
                //Store announcement Details
                Name = announcementGuid.ToString(),
                AnnouncementType = announcementTypeEnum,
                IsCreated = true
            };
            announcement.StoreAnnouncementInMemory();
            logger.LogMethodExit("CreateAnnouncementPage", "StoreAnnouncementDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
