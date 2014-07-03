using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Planner.Calendar;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Calendar Setup code
    /// </summary>
    public class CalendarSetupPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(CalendarSetupPage));

        /// <summary>
        /// SetUp the Calendar
        /// </summary>
        public void SetUpCalendar()
        {
            //SetUp the Calendar
            logger.LogMethodEntry("CalendarSetupPage", "SetUpCalendar",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the 'Calendar' window
                base.SelectWindow(EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Window_Title_NN);
                base.WaitForElement(By.Id(CalendarSetupPageResource.
                    CalendarSetupPage_Main_Iframe_Id_Locator));
                //Switch to Calendar Setup Main Frame
                base.SwitchToIFrame(CalendarSetupPageResource.
                    CalendarSetupPage_Main_Iframe_Id_Locator);
                //Switch to Calendar Setup Periods Frame
                base.WaitForElement(By.Id(CalendarSetupPageResource.
                    CalendarSetupPage_Period_Iframe_Id_Locator));
                base.SwitchToIFrame(CalendarSetupPageResource.
                    CalendarSetupPage_Period_Iframe_Id_Locator);
                //Wait for the Link Image
                base.WaitForElement(By.Id(CalendarSetupPageResource.
                    CalendarSetupPage_Image_AddClass_Id_Locator));
                //Click on the Add Class Link by Image
                base.ClickByJavaScriptExecutor(
                    base.GetWebElementPropertiesById(CalendarSetupPageResource.
                    CalendarSetupPage_Image_AddClass_Id_Locator));
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarSetupPage", "SetUpCalendar",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Finish Button
        /// </summary>
        public void ClickOnFinishButton()
        {
            //Click On Finish Button
            logger.LogMethodEntry("CalendarSetupPage", "ClickOnFinishButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the 'Calendar' window
                base.SelectWindow(EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Window_Title_NN);
                //Switch to Frame
                base.SwitchToIFrame(CalendarSetupPageResource.
                        CalendarSetupPage_Main_Iframe_Id_Locator);
                //Click on the Finish button
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesById(
                    CalendarSetupPageResource.CalendarSetupPage_Button_Finish_Id_Locator));
                Thread.Sleep(Convert.ToInt32(EmptyCalendarPageResource.
                    EmptyCalendarPage_WindowName_FinishBtn_Time));
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarSetupPage", "ClickOnFinishButton",
                base.isTakeScreenShotDuringEntryExit);            
        }
    }
}
