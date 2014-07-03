using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.CourseAnnouncement;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using Pegasus.Pages.UI_Pages.Pegng;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Announcement PopUp LightBoxUX Page Actions
    /// </summary>
    public class AnnouncementPopUpLightBoxUXPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(AnnouncementPopUpLightBoxUXPage));

        /// <summary>
        /// Close Announcement
        /// </summary>        
        public void CloseAnnouncementPopUp()
        {
            // Close Announcement Pop Up If Present on Page
            logger.LogMethodEntry("AnnouncementPopUpLightBoxUXPage",
                "CloseAnnouncementPopUp", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.WaitUntilWindowLoads(HEDGlobalHomePageResource
                      .HEDGlobalHome_Page_Window_Title_Name);
                base.SelectWindow(HEDGlobalHomePageResource
                                      .HEDGlobalHome_Page_Window_Title_Name);
                //Checking for Announcement light box
                Boolean isAnnouncementLightBoxPresent = base.IsElementPresent
                  (By.Id(AnnouncementPopUpLightBoxUXPageResource
                  .AnnouncementPopUpLightBoxUX_Page_Light_Box_Id_Locator),
                  Convert.ToInt32(AnnouncementPopUpLightBoxUXPageResource.
                  AnnouncementLightBoxWaitTime));
                //Checking If Announcement Present
                if (isAnnouncementLightBoxPresent)
                {
                    base.SelectWindow(HEDGlobalHomePageResource
                                     .HEDGlobalHome_Page_Window_Title_Name);
                    // Switch to the light box of Announcement
                    base.SwitchToIFrame(AnnouncementPopUpLightBoxUXPageResource.
                        AnnouncementPopUpLightBoxUX_Page_Frame_Title_Name);
                    // Chcks multiple annoucnment                    
                    this.CheckForAnnouncementLightBox();
                    //Get Button Property
                    IWebElement getButtonProperty = base.GetWebElementPropertiesById
                        (AnnouncementPopUpLightBoxUXPageResource.
                        AnnouncementPopUpLightBoxUX_Page_Close_Button_Id_Locator);
                    // Clicks Close Button
                    base.ClickByJavaScriptExecutor(getButtonProperty);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementPopUpLightBoxUXPage", "CloseAnnouncementPopUp"
                , base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Close Announcement in Digital path
        /// </summary>        
        public void CloseAnnouncementPopUpInDigitalPath(User.UserTypeEnum userTypeEnum)
        {
            // Close Announcement Pop Up If Present on Page
            logger.LogMethodEntry("AnnouncementPopUpLightBoxUXPage",
                "CloseAnnouncementPopUpInDigitalPath", base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.RumbaTeacher:
                    case User.UserTypeEnum.DPCsTeacher:
                    case User.UserTypeEnum.RumbaNonPSNTeacher:
                        //Select Window
                        base.SelectWindow(AnnouncementPopUpLightBoxUXPageResource.
                            AnnouncementPopUpLightBoxUX_Page_DP_CSTeacher_Window_Title_Name);
                        break;
                    case User.UserTypeEnum.DPCsStudent:
                        //Select Window
                        base.SelectWindow(AnnouncementPopUpLightBoxUXPageResource.
                            AnnouncementPopUpLightBoxUX_Page_DP_CSStudent_Window_Title_Name);
                        break;
                }
                //Checking for Announcement light box
                Boolean isAnnouncementLightBoxPresent = base.IsElementPresent
                  (By.Id(AnnouncementPopUpLightBoxUXPageResource
                  .AnnouncementPopUpLightBoxUX_Page_Light_Box_Id_Locator),
                  Convert.ToInt32(AnnouncementPopUpLightBoxUXPageResource.
                  AnnouncementLightBoxWaitTime));
                //Checking If Announcement Present
                if (isAnnouncementLightBoxPresent)
                {
                    // Switch to the light box of Announcement
                    base.SwitchToIFrame(AnnouncementPopUpLightBoxUXPageResource.
                        AnnouncementPopUpLightBoxUX_Page_Frame_Title_Name);
                    // Chcks multiple annoucnment                    
                    this.CheckForAnnouncementLightBox();
                    // Clicks Close Button
                    base.GetWebElementPropertiesById(AnnouncementPopUpLightBoxUXPageResource.
                        AnnouncementPopUpLightBoxUX_Page_Close_Button_Id_Locator).Click();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementPopUpLightBoxUXPage",
                "CloseAnnouncementPopUpInDigitalPath", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check For Announcement LightBox
        /// </summary>
        private void CheckForAnnouncementLightBox()
        {
            // Check For Announcement LightBox
            logger.LogMethodEntry("AnnouncementPopUpLightBoxUXPage",
                "CheckForAnnouncementLightBox"
                , base.isTakeScreenShotDuringEntryExit);
            // check next button on announcement page
            while (base.IsElementPresent(By.Id(AnnouncementPopUpLightBoxUXPageResource.
                AnnouncementPopUpLightBoxUX_Page_Next_Link_Id_Locator),
                Convert.ToInt32(AnnouncementPopUpLightBoxUXPageResource.
                AnnouncementLightBoxWaitTime)))
            {
                //Click on the Next button            
                IWebElement getNextButtonProperty = base.GetWebElementPropertiesById
                    (AnnouncementPopUpLightBoxUXPageResource.
                    AnnouncementPopUpLightBoxUX_Page_Next_Link_Id_Locator);
                base.ClickByJavaScriptExecutor(getNextButtonProperty);
                // Break if close button is present
                if (base.IsElementPresent(By.Id(AnnouncementPopUpLightBoxUXPageResource.
                    AnnouncementPopUpLightBoxUX_Page_Close_Button_Id_Locator),
                    Convert.ToInt32(AnnouncementPopUpLightBoxUXPageResource.
                    AnnouncementLightBoxWaitTime)))
                {
                    break;
                }
            }
            logger.LogMethodExit("AnnouncementPopUpLightBoxUXPage",
                "CheckForAnnouncementLightBox"
                , base.isTakeScreenShotDuringEntryExit);
        }
    }
}
