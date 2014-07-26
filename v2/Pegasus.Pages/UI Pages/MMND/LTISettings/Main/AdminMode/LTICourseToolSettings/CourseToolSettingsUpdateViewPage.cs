using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.LTISettings.Main.AdminMode.LTICourseToolSettings;


namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class Handles CourseToolSettingsUpdateViewPage actions
    /// </summary>
    public class CourseToolSettingsUpdateViewPage : BasePage 
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(CourseToolSettingsUpdateViewPage));

        /// <summary>
        /// Click On Edit Button.
        /// </summary>
        public void ClickOnEditButton()
        {
            //Click On Edit Button
            logger.LogMethodEntry("CourseToolSettingsUpdateViewPage", "ClickOnEditButton",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Edit Button
                base.WaitForElement(By.Id(CourseToolSettingsUpdateViewPageResource.
                        CourseToolSettingsUpdateView_Page_EditButton_Id_Locator));
                //Click On Edit Button
                base.ClickButtonById(CourseToolSettingsUpdateViewPageResource.
                    CourseToolSettingsUpdateView_Page_EditButton_Id_Locator);
                base.WaitForElement(By.Name(CourseToolSettingsUpdateViewPageResource.
                    CourseToolSettingsUPdateView_Page_Input_Course_Name_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                   
            }
            logger.LogMethodExit("CourseToolSettingsUpdateViewPage", "ClickOnEditButton",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get SuccessFull Message
        /// </summary>
        /// <returns>Success Message</returns>
        public string GetSuccessfullMessage()
        {
            //Get SuccessFull Message
            logger.LogMethodEntry("CourseToolSettingsUpdateViewPage", "GetSuccessfullMessage",
              base.isTakeScreenShotDuringEntryExit);
            //Initializing Variable
            string getSuccessMessage = string.Empty;
            try
            {
                //Select Administrative Pages Window
                base.SelectWindow(CourseToolSettingsUpdateViewPageResource.
                        CourseToolSettingsUpdateView_Page_Window_Name);
                base.WaitForElement(By.Name(CourseToolSettingsUpdateViewPageResource.
                    CourseToolSettingsUpdateView_Page_Frame_Name_Locator));
                //Switch to Frame
                base.SwitchToIFrame(CourseToolSettingsUpdateViewPageResource.
                    CourseToolSettingsUpdateView_Page_Frame_Name_Locator);
                base.WaitForElement(By.XPath(CourseToolSettingsUpdateViewPageResource.
                    CourseToolSettingsUPdateView_Page_GetSuccessMessage_XPath_Locator));
                //Get Successfull Message
                getSuccessMessage = base.GetElementTextByXPath(CourseToolSettingsUpdateViewPageResource.
                    CourseToolSettingsUPdateView_Page_GetSuccessMessage_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                 
            }
            logger.LogMethodExit("CourseToolSettingsUpdateViewPage", "GetSuccessfullMessage",
            base.isTakeScreenShotDuringEntryExit);
            return getSuccessMessage;
        }
    }
}
