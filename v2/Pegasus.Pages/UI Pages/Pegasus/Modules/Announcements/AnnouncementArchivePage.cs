using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Announcements;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Announcement Archive Page Actions
    /// </summary>
    public class AnnouncementArchivePage : BasePage 
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(AnnouncementArchivePage));        

        /// <summary>
        /// Click on 'Create Announcement' Link.
        /// </summary>
        public void ClickCreateAnnouncementLink()
        {
            //Clicking Create Announcement Link.
            logger.LogMethodEntry("AnnouncementArchivePage", "ClickCreateAnnouncementLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Default Page Content
                base.SwitchToDefaultPageContent();
                //Select Announcement Window
                this.SelectAnnouncementWindow();               
                // Wait for CreateAnnouncement Link
                base.WaitForElement(By.Id(AnnouncementArchivePageResource.
                    AnnouncementArchive_Page_CreateAnnouncement_Link_Id_Locator));
                // Click Create Announcement Link
                base.ClickLinkByID(AnnouncementArchivePageResource.
                    AnnouncementArchive_Page_CreateAnnouncement_Link_Id_Locator);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementArchivePage", "ClickCreateAnnouncementLink",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Announcement Window.
        /// </summary>
        private void SelectAnnouncementWindow()
        {
            //Select Announcement Window
            logger.LogMethodEntry("AnnouncementArchivePage", "SelectAnnouncementWindow",
                base.isTakeScreenShotDuringEntryExit);
            // Select Parent window
            base.SelectWindow(AnnouncementArchivePageResource.
                AnnouncementArchive_Page_Window_Title);
            logger.LogMethodExit("AnnouncementArchivePage", "SelectAnnouncementWindow",
               base.isTakeScreenShotDuringEntryExit);
        }  
    }
}
