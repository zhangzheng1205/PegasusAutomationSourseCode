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
    /// This class handles the Course ID mapping to eCollege, related actions.
    /// </summary>
    public class CourseToolSettingsViewPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(CourseToolSettingsViewPage));

        /// <summary>
        /// Enter eCollege Course Id.
        /// </summary>
        /// <param name="ecollegeCourseId">This is eCollege Course Id.</param>
        public void EnterECollegeCourseId(string ecollegeCourseId)
        {
            //Enter eCollege Course Id
            Logger.LogMethodEntry("CourseToolSettingsViewPage", "EnterECollegeCourseId",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to Course Frame
                this.SwitchToCourseFrame();
                base.WaitForElement(By.Id(CourseToolSettingsViewPageResource.
                    CourseToolSettingsView_Page_Input_Course_Id_Locator));
                //Insert User Name in Username TextBox
                base.ClearTextByID(CourseToolSettingsViewPageResource.
                    CourseToolSettingsView_Page_Input_Course_Id_Locator);
                //Fill eCollege Course Id
                base.FillTextBoxByID(CourseToolSettingsViewPageResource.
                    CourseToolSettingsView_Page_Input_Course_Id_Locator, ecollegeCourseId);
                base.WaitForElement(By.Id(CourseToolSettingsViewPageResource.
                    CourseToolSettingsView_Page_SearchButton_Id_Locator));
                //Click On Search Button
                base.ClickButtonByID(CourseToolSettingsViewPageResource.
                    CourseToolSettingsView_Page_SearchButton_Id_Locator);
                //Switch to Course Frame
                this.SwitchToCourseFrame();
                base.WaitForElement(By.XPath(CourseToolSettingsViewPageResource.
                    CourseToolSettingsView_Page_EditButton_Xpath_Locator));
            }
            catch (Exception e) 
            {
               ExceptionHandler.HandleException(e);               
            }
            Logger.LogMethodExit("CourseToolSettingsViewPage", "EnterECollegeCourseId",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to Course Frame.
        /// </summary>
        private void SwitchToCourseFrame()
        {
            //Switch to Course Frame
            Logger.LogMethodEntry("CourseToolSettingsViewPage", "SwitchToCourseFrame",
             base.isTakeScreenShotDuringEntryExit);
            //Select Administrative Pages Window
            base.SelectWindow(CourseToolSettingsViewPageResource.
                CourseToolSettingsView_Page_Window_Name);
            base.WaitForElement(By.Name(CourseToolSettingsViewPageResource.
                CourseToolSettingsView_Page_Frame_Name_Locator));
            //Switch to frame
            base.SwitchToIFrame(CourseToolSettingsViewPageResource.
                CourseToolSettingsView_Page_Frame_Name_Locator);
            Logger.LogMethodExit("CourseToolSettingsViewPage", "SwitchToCourseFrame",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Message From MMND.
        /// </summary>
        /// <param name="message">Message.</param>
        public string GetMessageFromMMND(string message)
        {
            //Get Message From MMND
            Logger.LogMethodEntry("CourseToolSettingsViewPage","GetMessageFromMMND",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getMessageValidate = string.Empty;
            try
            {
                //Select Window
                SelectDefaultWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(CourseToolSettingsViewPageResource.
                    CourseToolSettingsView_Page_Course_Create_Message_Xpath_Locator));
                //Get message
                getMessageValidate = base.GetElementTextByXPath(
                    CourseToolSettingsViewPageResource.
                    CourseToolSettingsView_Page_Course_Create_Message_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseToolSettingsViewPage","GetMessageFromMMND",
            base.isTakeScreenShotDuringEntryExit);
            return getMessageValidate;
        }
    }
}
