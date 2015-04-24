using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Planner.Calendar;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Empty Calendar frame code
    /// </summary>
    public class EmptyCalendarPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(EmptyCalendarPage));

        /// <summary>
        /// Select calender set up button in the right frame
        /// </summary>
        public void SelectCalendarSetUp()
        {

            //Select the calendar set up button
            logger.LogMethodEntry("EmptyCalendarPage", "SelectCalendarSetUp",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(EmptyCalendarPageResource
                    .EmptyCalendarPage_WindowName_Title);
                // Select planner window
                base.SelectWindow(EmptyCalendarPageResource
                    .EmptyCalendarPage_WindowName_Title);
                // Wait for Iframe and switch to frame
                base.WaitForElement(By.Id(EmptyCalendarPageResource
                    .EmptyCalendarPage_MainFrame_Id_Locator));
                Thread.Sleep(2000);
                base.SwitchToIFrame(EmptyCalendarPageResource
                    .EmptyCalendarPage_MainFrame_Id_Locator);
                base.SwitchToIFrame(EmptyCalendarPageResource
                    .EmptyCalendarPage_RightCalendarFrame_Id_Locator);
                if (base.IsElementPresent(By.CssSelector(EmptyCalendarPageResource
                    .EmptyCalendarPage_CalendarSetupButton_CSS_Locator), 10))
                {
                    // Wait for calendar set up button and click
                    base.WaitForElement(By.CssSelector(EmptyCalendarPageResource
                        .EmptyCalendarPage_CalendarSetupButton_CSS_Locator));
                    IWebElement getCalendarButton = base.GetWebElementPropertiesByCssSelector
                        (EmptyCalendarPageResource
                        .EmptyCalendarPage_CalendarSetupButton_CSS_Locator);
                    base.ClickByJavaScriptExecutor(getCalendarButton);
                    // Fetch class name 
                    Class orgClass = Class.Get(Class.ClassTypeEnum.DigitalPathMasterLibrary);
                    // Fetch course name 
                    Course course = Course.Get(Course.CourseTypeEnum.MasterLibrary);
                    // New instance of Emptycalendarpage to select calendar set up button
                    new CalendarDefaultGlobalUXPage().
                        ConfigureCalendarSetUp(orgClass.Name, course.Name);
                }
                else
                {
                    // Select "Planner" window
                    base.SelectWindow(EmptyCalendarPageResource.EmptyCalendarPage_WindowName_Title);
                    // Click on Setup link in the top rite navigation
                    IWebElement getSetupLink = base.GetWebElementPropertiesByClassName(
                        EmptyCalendarPageResource.EmptyCalendarPage_SetupLink_ClassName);
                    base.ClickByJavaScriptExecutor(getSetupLink);
                    // Wait for Iframe and switch to frame
                    base.SwitchToIFrameById(CalendarSetupPageResource.CalendarSetupPage_Main_Iframe_Id_Locator);
                    base.WaitForElement(By.Id(CalendarSetupPageResource.CalendarSetupPage_Wizard_frame_Id_Locator));
                    base.WaitForElement(By.Id("iframeSetUpWizard"),10);
                    base.SwitchToIFrameById("iframeSetUpWizard");
                    IWebElement getSetupCalenderLink = base.GetWebElementPropertiesByClassName("Image_Icon1Cale");
                    base.ClickByJavaScriptExecutor(getSetupCalenderLink);

                    Class orgClass = Class.Get(Class.ClassTypeEnum.DigitalPathMasterLibrary);
                    // Fetch course name 
                    Course course = Course.Get(Course.CourseTypeEnum.MasterLibrary);
                    new CalendarDefaultGlobalUXPage().
                    ConfigureCalendarSetUp(orgClass.Name, course.Name);
                }
                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("EmptyCalendarPage", "SelectCalendarSetUp",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on the Calendar Setup Button
        /// </summary>
        public void ClickOnCalendarSetupButton()
        {
            //Clicks on the Calendar Setup Button
            logger.LogMethodEntry("EmptyCalendarPage", "ClickOnCalendarSetupButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {                          
                //Select the 'Calendar' window
                base.SelectWindow(EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Window_Title_NN);
                base.WaitForElement(By.Id(EmptyCalendarPageResource.
                    EmptyCalendarPage_Main_Frame_Id_Locator_NN));
                //Select Frame
                base.SwitchToIFrame(EmptyCalendarPageResource.
                    EmptyCalendarPage_Main_Frame_Id_Locator_NN);
                Thread.Sleep(Convert.ToInt32(EmptyCalendarPageResource.
                      EmptyCalendarPage_WindowName_Time));
                //Wait for the calender button
                base.WaitForElement(By.Id(EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Setup_Button_Id_Locator_NN));
                IWebElement getCalenderBtnproperty=base.GetWebElementPropertiesById
                    (EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Setup_Button_Id_Locator_NN);
                //Click on the Button                
                base.ClickByJavaScriptExecutor(getCalenderBtnproperty);
                Thread.Sleep(Convert.ToInt32(EmptyCalendarPageResource.
                    EmptyCalendarPage_WindowName_Time));
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }            
            logger.LogMethodExit("EmptyCalendarPage", "ClickOnCalendarSetupButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Check The Status Of Calendar Setup Button 
        /// </summary>
        public void CheckTheStatusOfCalendarSetupButton()
        {
            //Check The Status Of Calendar Setup Button 
            logger.LogMethodEntry("EmptyCalendarPage", "CheckTheStatusOfCalendarSetupButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(EmptyCalendarPageResource.
                         EmptyCalendarPage_Calendar_Window_Title_NN);
                //Select the 'Calendar' window
                base.SelectWindow(EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Window_Title_NN);
                if (base.IsElementPresent(By.Id(EmptyCalendarPageResource.
                  EmptyCalendarPage_Main_Frame_Id_Locator_NN),
                  Convert.ToInt32(EmptyCalendarPageResource.EmptyCalendarPage_Iframe_Time_Value)))
                {
                    //Click on the 'Calendar Setup' button            
                    new EmptyCalendarPage().ClickOnCalendarSetupButton();
                    //Click on the Add Class and add the Calendar
                    new CalendarSetupPage().SetUpCalendar();
                    //Create Periods
                    new CreatePeriodsPage().CreatePeriods();
                    //Click on the Finish Button 
                    new CalendarSetupPage().ClickOnFinishButton();
                }
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
         logger.LogMethodExit("EmptyCalendarPage", "CheckTheStatusOfCalendarSetupButton",
              base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
