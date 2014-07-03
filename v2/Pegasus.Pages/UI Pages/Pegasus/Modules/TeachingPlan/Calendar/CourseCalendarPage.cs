using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes.Channels;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan.Calendar;

namespace Pegasus.Pages.UI_Pages
{
    //This Class Handles Course Calendar Page actions
    public class CourseCalendarPage : BasePage
    {

        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(CourseCalendarPage));


        /// <summary>
        /// Get Activity Name
        /// </summary>
        /// <param name="windowName">This is Window Name</param>
        /// <param name="activityName">This is Activity Name</param>
        /// <returns>Activity Name</returns>
        public String GetActivityName(string windowName,string activityName)
        {
            //Get Activity Name
            logger.LogMethodEntry("CourseCalendarPage", "GetActivityName",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getActivityName=string.Empty;
            try
            {
                //Wait for Window                
                base.WaitUntilWindowLoads(windowName);
                //Select Window
                base.SelectWindow(windowName);
                base.WaitForElement(By.Id(CourseCalendarPageResource.
                    CourseCalendar_Page_Frame_Id_Locator));
                //Select the Calendar Frame
                base.SwitchToIFrame(CourseCalendarPageResource.
                    CourseCalendar_Page_Frame_Id_Locator);
                base.WaitForElement(By.ClassName(CourseCalendarPageResource.
                    CourseCalendar_Page_ActivityName_ClassName_Locator));
                //Get Activity Count
                int getActivityCount = base.GetElementCountByXPath(CourseCalendarPageResource.
                    CourseCalendar_Page_ActivityCount_Xpath_Locator);
                for (int initialCount = Convert.ToInt32(CourseCalendarPageResource.
                    CourseCalendar_Page_ActivityInitialCount_Xpath_Locator); 
                    initialCount <= Convert.ToInt32(CourseCalendarPageResource.
                    CourseCalendar_Page_ActivityInitialCount_Xpath_Locator)
                    + getActivityCount; initialCount++)
                {
                    //Wait for the Element
                    base.WaitForElement(By.XPath(string.Format(CourseCalendarPageResource.
                        CourseCalendar_Page_GetActivityName_Xpath_Locator, initialCount)));
                    //Get Activity Name
                    getActivityName = base.GetElementTextByXPath(string.Format(CourseCalendarPageResource.
                        CourseCalendar_Page_GetActivityName_Xpath_Locator,initialCount));                   
                    if (getActivityName.Contains(activityName))
                        break;
                }                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("CourseCalendarPage", "GetActivityName",
                base.isTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Click On Calendar Icon
        /// </summary>
        public void ClickOnCalendarIcon()
        {
            logger.LogMethodEntry("CourseCalendarPage", "ClickOnCalendarIcon",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Overview Window
                base.SelectWindow(CourseCalendarPageResource.
                    CourseCalendar_Page_CourseMaterials_Window_Name);
                base.WaitForElement(By.Id(CourseCalendarPageResource.
                    CourseCalendar_Page_Frame_Id_Locator));
                base.SwitchToIFrame(CourseCalendarPageResource.
                    CourseCalendar_Page_Frame_Id_Locator);
                //Wait for Icon
                base.WaitForElement(By.XPath(CourseCalendarPageResource.
                    CourseCalendar_Page_CalendarIcon_Xpath_Locator));
                //Click On Calendar Icon
                base.ClickImageByXPath(CourseCalendarPageResource.
                    CourseCalendar_Page_CalendarIcon_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("CourseCalendarPage", "ClickOnCalendarIcon",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Status Of Submitted Activity. 
        /// </summary>
        /// <param name="activityType">This is Activity.</param>
        /// <returns>Activity Status.</returns>
        public String GetStatusOfSubmittedActivityInCalendar(
            string assetName)
        {
            //Get Status Of Submitted Activity 
            logger.LogMethodEntry("CourseCalendarPage", "GetStatusOfSubmittedActivityInCalendar",
                    base.isTakeScreenShotDuringEntryExit);
            //Initialize getStatusText variable
            string getActivitySubmittedStatus = string.Empty;            
            string getActivityName = string.Empty;
            try
            {
                //Select Window And Frame
                this.SelectWindowAndFrame();
                //Total Row count of the Assets  
                base.WaitForElement(By.XPath(CourseCalendarPageResource.
                    CourseCalendar_Page_Activity_Count_Xpath_Locator));
                int getActivityCount = base.GetElementCountByXPath(CourseCalendarPageResource.
                    CourseCalendar_Page_Activity_Count_Xpath_Locator);
                for (int setRowCount = Convert.ToInt32(CourseCalendarPageResource.
                    CourseCalendar_Page_ActivityInitialCount_Xpath_Locator);
                       setRowCount <= getActivityCount; setRowCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(CourseCalendarPageResource.
                     CourseCalendar_Page_GetActivityName_Xpath_Locator, setRowCount)));
                    //Getting the assets name               
                    getActivityName = base.GetElementTextByXPath
                     (string.Format(CourseCalendarPageResource.
                     CourseCalendar_Page_GetActivityName_Xpath_Locator, setRowCount));
                    if (getActivityName == assetName)
                    {
                        //Get the status text                    
                        getActivitySubmittedStatus = base.GetElementTextByXPath(string.
                        Format(CourseCalendarPageResource.
                        CourseCalendar_Page_ActivityStatus_Xpath_Locator, setRowCount));
                        break;
                    }
                }
                base.SelectWindow(CourseCalendarPageResource.
                CourseCalendar_Page_CourseMaterials_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseCalendarPage", "GetStatusOfSubmittedActivityInCalendar",
                    base.isTakeScreenShotDuringEntryExit);
            return getActivitySubmittedStatus;
        }

        /// <summary>
        /// Select Window And Frame.
        /// </summary>
        private void SelectWindowAndFrame()
        {
            //Select Window And Frame
            logger.LogMethodEntry("CourseCalendarPage", "SelectWindowAndFrame",
                    base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(CourseCalendarPageResource.
                CourseCalendar_Page_CourseMaterials_Window_Name);
            //Select Window
            base.SelectWindow(CourseCalendarPageResource.
                CourseCalendar_Page_CourseMaterials_Window_Name);
            //Switch To Frame
            base.SwitchToIFrameById(CourseCalendarPageResource.
                CourseCalendar_Page_Frame_Id_Locator);
            logger.LogMethodExit("CourseCalendarPage", "SelectWindowAndFrame",
                    base.isTakeScreenShotDuringEntryExit);
        }
    }
}
