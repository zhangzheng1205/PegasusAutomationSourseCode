using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes.Channels;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class Handles Calendar Frame Page actions
    /// </summary>
    public class CalendarFramePage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(CalendarFramePage));

        /// <summary>
        /// Calendar Icon of Asset
        /// </summary>
        /// <returns>Calendar Icon of Asset</returns>
        public Boolean IsCalendarIconPresent()
        {
            //Verify Calendar Icon
            logger.LogMethodEntry("CalendarFramePage", "IsCalendarIconPresent",
            base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isCalendarIconPresent = false;
            try
            {                
                //Wait for Calendar icon
                base.WaitForElement(By.XPath(CalendarFramePageResource.
                    CalendarFrame_Page_CalendarIcon_Xpath_Locator));
                //Verify Calendar icon
                isCalendarIconPresent = base.IsElementPresent(By.XPath(
                   CalendarFramePageResource.CalendarFrame_Page_CalendarIcon_Xpath_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarFramePage", "IsCalendarIconPresent",
            base.isTakeScreenShotDuringEntryExit);
            return isCalendarIconPresent;
        }

        /// <summary>
        /// Select Overview Window and Frame
        /// </summary>
        public void SelectOverviewWindowandFrame()
        {
            //Select Overview Window and Frame
            logger.LogMethodEntry("CalendarFramePage", "SelectOverviewWindowandFrame",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Overview Window
                base.SelectWindow(CalendarFramePageResource.
                    CalendarFrame_Page_Overview_Window_Name);
                //Wait for Frame
                base.WaitForElement(By.Id(CalendarFramePageResource.
                    CalendarFrame_Page_Frame_Id_Locator));
                //Select Calendar Frame
                base.SwitchToIFrame(CalendarFramePageResource.
                    CalendarFrame_Page_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarFramePage", "SelectOverviewWindowandFrame",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Materials Window and Frame
        /// </summary>
        public void CoursematerialsWindowandFrame()
        {
            //Select Course Materials Window and Frame
            logger.LogMethodEntry("CalendarFramePage", "CoursematerialsWindowandFrame",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Course Materials Window
                base.SelectWindow(CalendarFramePageResource.
                    CalendarFrame_Page_CourseMaterials_Window_Name);
                //Wait for Frame
                base.WaitForElement(By.Id(CalendarFramePageResource.
                    CalendarFrame_Page_Preview_Frame_Id_Locator));
                //Select Calendar Frame
                base.SwitchToIFrame(CalendarFramePageResource.
                    CalendarFrame_Page_Preview_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarFramePage", "CoursematerialsWindowandFrame",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Calendar Icon.
        /// </summary>
        public void ClickOnCalendarIcon()
        {
            //Click on Calendar Icon
            logger.LogMethodEntry("CalendarFramePage", "ClickOnCalendarIcon",
            base.isTakeScreenShotDuringEntryExit);
            try
            {               
                //Wait for Icon
                base.WaitForElement(By.XPath(CalendarFramePageResource.
                    CalendarFrame_Page_CalendarIcon_Xpath_Locator));
                base.FocusOnElementByXPath(CalendarFramePageResource.
                    CalendarFrame_Page_CalendarIcon_Xpath_Locator);
                //Click On Calendar Icon                
                IWebElement getCalendarIcon = base.GetWebElementPropertiesByXPath
                    (CalendarFramePageResource.CalendarFrame_Page_CalendarIcon_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getCalendarIcon);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarFramePage", "ClickOnCalendarIcon",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window And Frame.
        /// </summary>
        public void SelectWindowAndFrame()
        {
            //Select Window And Frame            
            logger.LogMethodEntry("CalendarFramePage", "SelectWindowAndFrame",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(CalendarFramePageResource.
                        CalendarFrame_Page_TodaysView_Window_Title);
                //Select Window
                base.SelectWindow(CalendarFramePageResource.
                    CalendarFrame_Page_TodaysView_Window_Title);
                base.WaitForElement(By.Id(CalendarFramePageResource.
                    CalendarFrame_Page_Preview_CalendarFrame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(CalendarFramePageResource.
                    CalendarFrame_Page_Preview_CalendarFrame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarFramePage", "SelectWindowAndFrame",
            base.isTakeScreenShotDuringEntryExit);
        }
    }
}
