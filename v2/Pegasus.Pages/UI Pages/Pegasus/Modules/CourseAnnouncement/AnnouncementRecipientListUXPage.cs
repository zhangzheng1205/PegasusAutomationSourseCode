using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.CourseAnnouncement;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Announcement RecipientList Page Actions
    /// </summary>
    public class AnnouncementRecipientListUXPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(AnnouncementRecipientListUXPage));

        /// <summary>
        /// Add Recipients To Create Course Announcements.        
        /// </summary>
        public void AddRecipients()
        {
            // Add Recipients
            logger.LogMethodEntry("AnnouncementRecipientListUXPage", "AddRecipients"
                , base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Adding Recipients
                base.WaitForElement(By.XPath(AnnouncementRecipientListUXPageResource.
                        AnnouncementRecipientListUX_Page_RecipientFrame_XPath_Locator));
                // Intialization of IWebElement for selecting RecipientFrame
                IWebElement frame = base.GetWebElementPropertiesByXPath(AnnouncementRecipientListUXPageResource.
                          AnnouncementRecipientListUX_Page_RecipientFrame_XPath_Locator);
                //Select RecipientFrame
                base.SwitchToIFrameByWebElement(frame);         
                base.WaitForElement(By.Id(AnnouncementRecipientListUXPageResource.
                     AnnouncementRecipientListUX_Page_SelectAll_CheckBox_Id_Locator));
                // Select 'SelectAll' CheckBox if not selected
                IWebElement selectAllCheckbox=base.GetWebElementPropertiesById(AnnouncementRecipientListUXPageResource.
                     AnnouncementRecipientListUX_Page_SelectAll_CheckBox_Id_Locator);
                if (!selectAllCheckbox.Selected)
                {   base.ClickCheckBoxById(AnnouncementRecipientListUXPageResource.
                    AnnouncementRecipientListUX_Page_SelectAll_CheckBox_Id_Locator);}                              
                //Click AddRecipients Button                
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesById
                    (AnnouncementRecipientListUXPageResource.
                    AnnouncementRecipientListUX_Page_AddRecipients_Button_Id_Locator));
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);                     
            }
            logger.LogMethodExit("AnnouncementRecipientListUXPage", "AddRecipients",
                            base.isTakeScreenShotDuringEntryExit);
        }
    }
}
