using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.CourseAnnouncement;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TodaysView;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Announcement DefaultUX Page Actions
    /// </summary>
    public class AnnouncementDefaultUXPage : BasePage
    {

        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(AnnouncementDefaultUXPage));
        
        /// <summary>
        /// To Get Announcement Text which is in Top.
        /// </summary>
        /// <returns>Announcement Details.</returns>
        public String GetAnnouncementDetails(string announcementName)
        {
            // Get Announcement Text
            logger.LogMethodEntry("AnnouncementDefaultUXPage", "GetAnnouncementDetails",
                base.IsTakeScreenShotDuringEntryExit);
            // Intialization of string to get Announcement text
            string getAnnouncementText = string.Empty;
            try
            {
                //Wait for Element
                base.WaitForElement(By.XPath(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_AnnouncementCount_Xpath_Locator));
                //Get Count of Annoucement created
                int announcementCount = base.GetElementCountByXPath(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_AnnouncementCount_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_Loop_Initializer_Value);
                    rowCount <= announcementCount; rowCount++)
                {
                    // Get Annoucement Text
                    string getAnnouncementDetails = base.GetTitleAttributeValueByXPath(
                        string.Format(AnnouncementDefaultUXPageResource.
                        AnnouncementDefaultUX_Page_Annoucement_Link_Xpath_Locator, rowCount));
                    //Check required annoucement is present
                    if (getAnnouncementDetails.Contains(announcementName))
                    {
                        getAnnouncementText = getAnnouncementDetails;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementDefaultUXPage", "GetAnnouncementDetails",
               base.IsTakeScreenShotDuringEntryExit);
            return getAnnouncementText;
        }

        /// <summary>
        ///  Close Annoucement LightBox.
        /// </summary>
        public void CloseAnnoucementLightBox()
        {
            // Click close button
            logger.LogMethodEntry("AnnouncementDefaultUXPage", "CloseAnnoucementLightBox",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                WaitForElement(By.Id(AnnouncementDefaultUXPageResource.
                        AnnouncementDefaultUX_Page_AnnouncementsClose_Button_Id_Locator));
                //Focus on close button
                base.FocusOnElementById(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_AnnouncementsClose_Button_Id_Locator);
                //Intailize IWebElement for Close Button
                IWebElement annoucementCloseButton = base.GetWebElementPropertiesById(
                    AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_AnnouncementsClose_Button_Id_Locator);
                // Click close button
                base.ClickByJavaScriptExecutor(annoucementCloseButton);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementDefaultUXPage", "CloseAnnoucementLightBox",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Announcement Frame
        /// </summary>
        public void SelectAnnouncementFrame()
        {
            //Selecting  Announcement Frame
            logger.LogMethodEntry("AnnouncementDefaultUXPage", "SelectAnnouncementFrame",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select default content of page 
                base.SwitchToDefaultPageContent();
                base.WaitForElement(By.XPath(AnnouncementDefaultUXPageResource.
                        AnnouncementDefaultUX_Page_AnnouncementFrame_XPath_Locator));
                // Intialization of IWebElement for selecting frame
                IWebElement frame = WebDriver.FindElement(By.XPath(
                    AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_AnnouncementFrame_XPath_Locator));
                //Select Frame
                base.SwitchToIFrameByWebElement(frame);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementDefaultUXPage", "SelectAnnouncementFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Announcement Frame in Course space
        /// </summary>
        public void SelectAnnouncementFrameInCs()
        {
            //Selecting  Announcement Frame
            logger.LogMethodEntry("AnnouncementDefaultUXPage", "SelectAnnouncementFrameInCs",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select default content of page 
                base.SwitchToDefaultPageContent();
                //Select classes window
                base.SelectWindow(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Classes_Window_Title);
                // Select container frame
                base.SwitchToIFrame(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_CourseContainer_Frame_Id_Locator);
                base.WaitForElement(By.XPath(AnnouncementDefaultUXPageResource.
                        AnnouncementDefaultUX_Page_AnnouncementFrame_XPath_Locator));
                // Intialization of IWebElement for selecting frame
                IWebElement frame = WebDriver.FindElement(By.XPath(
                    AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_AnnouncementFrame_XPath_Locator));
                //Select Frame
                base.SwitchToIFrameByWebElement(frame);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementDefaultUXPage", "SelectAnnouncementFrameInCs",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the CreateAnnouncement Button.
        /// </summary>
        public void ClickCreateAnnouncementButton()
        {
            // Select CreateAnnouncement Button
            logger.LogMethodEntry("AnnouncementDefaultUXPage", "ClickCreateAnnouncementButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {               
                //Click Create Announcement Button
                base.WaitForElement(By.Id(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_CreateAnnouncement_Button_Id_Locator));
                base.FocusOnElementById(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_CreateAnnouncement_Button_Id_Locator);
                //Intailize IWebElement for CreateAnnouncement Button
                IWebElement createAnnouncementButton = base.GetWebElementPropertiesById(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_CreateAnnouncement_Button_Id_Locator);
                // Click close button
                base.ClickByJavaScriptExecutor(createAnnouncementButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementDefaultUXPage", "ClickCreateAnnouncementButton",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Get text of Successfull Message for creation of course announcement.
        /// </summary>
        /// <returns>Returns text of Successfull message. </returns>
        public string GetCourseAnnouncementSuccessfullMessage()
        {
            //Get success full message text
            logger.LogMethodEntry("AnnouncementDefaultUXPage", 
                "GetCourseAnnouncementSuccessfullMessage",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialization of string getSuccessMsg
            string getSuccessMessage = string.Empty;
            try
            {
                base.WaitForElement(By.Id(AnnouncementDefaultUXPageResource.
                   AnnouncementDefaultUX_Page_SuccessMessage_Id_Locator));
                // To get text of successfull message
                getSuccessMessage = base.GetElementTextById(AnnouncementDefaultUXPageResource.
                     AnnouncementDefaultUX_Page_SuccessMessage_Id_Locator);
                Thread.Sleep(Convert.ToInt32(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_ThreadSleep_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementDefaultUXPage",
                "GetCourseAnnouncementSuccessfullMessage",
               base.IsTakeScreenShotDuringEntryExit);
            return getSuccessMessage;
        }

        /// <summary>
        /// Click on the Dp Teacher of 'Create Announcement' Button
        /// </summary>
        public void ClickOnTheCreateAnnouncementButton()
        {
            // Select 'Create Announcement' Button
            logger.LogMethodEntry("AnnouncementDefaultUXPage",
                "ClickOnTheCreateAnnouncementButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectAnnouncementLightBoxFrame();
                //Click the 'Create Announcement' Button
                base.WaitForElement(By.Id(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_CreateAnnouncement_Button_Id_Locator));
                base.ClickButtonById(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_CreateAnnouncement_Button_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementDefaultUXPage",
                "ClickOnTheCreateAnnouncementButton",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select the Announcement frame
        /// </summary>
        public void SelectAnnouncementLightBoxFrame()
        {
            // Select Announcement frame
            logger.LogMethodEntry("AnnouncementDefaultUXPage",
                "SelectAnnouncementLightBoxFrame",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select default content of page 
                base.SwitchToDefaultPageContent();
                //Select Announcement frame
                base.WaitForElement(By.Id(AnnouncementDefaultUXPageResource.
                        AnnouncementDefaultUX_Page_Frame_Id_Locator));
                //Switch To Announcements Iframe
                base.SwitchToIFrame(AnnouncementDefaultUXPageResource.
                        AnnouncementDefaultUX_Page_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementDefaultUXPage",
                "SelectAnnouncementLightBoxFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Announcements Type In Dropdown
        /// </summary>
        /// <param name="announcementType">This is Annoucement Type</param>
        public void SelectAnnouncementsTypeInDropdown(string announcementType)
        {
            //Select SystemAnnouncements In Dropdown
            logger.LogMethodEntry("AnnouncementDefaultUXPage",
                "SelectAnnouncementsTypeInDropdown",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selecting frame
                this.SelectAnnouncementLightBoxFrame();
                base.WaitForElement(By.Id(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_ViewBy_DropDown_Id_Locator));
                // Select system announcement in 'View by' Dropdown
                base.SelectDropDownValueThroughTextById(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_ViewBy_DropDown_Id_Locator, announcementType);
                Thread.Sleep(Convert.ToInt32(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_ThreadSleep_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementDefaultUXPage",
                "SelectAnnouncementsTypeInDropdown",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Announcements Type In Dropdown HED
        /// </summary>
        /// <param name="annoucementType">This is Annoucement Type</param>
        public void SelectAnnouncementsTypeInDropDownHED(string annoucementType)
        {
            //Select Announcements Type In Dropdown HED
            logger.LogMethodEntry("AnnouncementDefaultUXPage",
                "SelectAnnouncementsTypeInDropDownHED",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(AnnouncementDefaultUXPageResource.
                            AnnouncementDefaultUX_Page_ViewBy_DropDown_Id_Locator));
                // Select system announcement in 'View by' Dropdown
                base.SelectDropDownValueThroughTextById(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_ViewBy_DropDown_Id_Locator, annoucementType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("AnnouncementDefaultUXPage",
                "SelectAnnouncementsTypeInDropDownHED",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Global Announcement frame.
        /// </summary>
        public void SelectGlobalAnnouncementframe()
        {
            //Select Announcements Type In Dropdown HED
            logger.LogMethodEntry("AnnouncementDefaultUXPage",
                "SelectGlobalAnnouncementframe",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_Window_Title_Name);
                base.SelectWindow(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_Window_Title_Name);
                //Wait for the element
                base.WaitForElement(By.XPath(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_Annoucement_LightBox_Frame_Xpath_Locator));
                IWebElement getframe = base.GetWebElementPropertiesByXPath(
                    AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_Annoucement_LightBox_Frame_Xpath_Locator);
                //Select the frame
                base.SwitchToIFrameByWebElement(getframe);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("AnnouncementDefaultUXPage",
                "SelectGlobalAnnouncementframe",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Class Announcements Type From Dropdown.
        /// </summary>
        /// <param name="announcementType">This is Announcement Type.</param>
        public void SelectClassAnnouncementsTypeFromDropdown(string announcementType)
        {
            //Select Class Announcements Type From Dropdown
            logger.LogMethodEntry("AnnouncementDefaultUXPage",
                "SelectClassAnnouncementsTypeFromDropdown",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {                
                //Declaration of class object
                AnnouncementDefaultUXPage announcementDefaultUxPage =
                    new AnnouncementDefaultUXPage();
                //Select the frame
                announcementDefaultUxPage.SelectGlobalAnnouncementframe();
                //Wait for the element
                base.WaitForElement(By.Id(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_ViewBy_DropDown_Id_Locator));
                // Select system announcement in 'View by' Dropdown
                base.SelectDropDownValueThroughTextById(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_ViewBy_DropDown_Id_Locator, announcementType);
                Thread.Sleep(Convert.ToInt32(AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_ThreadSleep_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementDefaultUXPage",
                "SelectClassAnnouncementsTypeFromDropdown",
               base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Get Display Of Announcement DropdownOptions.
        /// </summary>
        /// <param name="actualDropdownOption">This is Dropdown Options.</param>
        /// <returns>Dropdown Options Displayed.</returns>
        public string GetDisplayOfAnnouncementDropdownOptions(
            string actualDropdownOption)
        {
            //Get Display Of Announcement DropdownOptions
            logger.LogMethodEntry("AnnouncementDefaultUXPage",
                "GetDisplayOfAnnouncementDropdownOptions",
                   base.IsTakeScreenShotDuringEntryExit);
            //Initialize Activity Cmenuoptions Variable
            string getDisplayDropdownOptions = string.Empty;
            try
            {
                //Get the Dropdown options
                getDisplayDropdownOptions = base.GetElementTextById
                    (AnnouncementDefaultUXPageResource.
                    AnnouncementDefaultUX_Page_ViewBy_DropDown_Id_Locator);
                if (getDisplayDropdownOptions.Contains(actualDropdownOption))
                {
                    getDisplayDropdownOptions = actualDropdownOption;
                }
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AnnouncementDefaultUXPage",
                "GetDisplayOfAnnouncementDropdownOptions",
                   base.IsTakeScreenShotDuringEntryExit);
            return getDisplayDropdownOptions;
        }
    }
}
