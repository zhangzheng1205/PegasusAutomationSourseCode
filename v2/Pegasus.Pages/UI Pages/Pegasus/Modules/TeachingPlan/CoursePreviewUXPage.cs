using System;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.CommonPageObjects;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;





namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Course Preview Page Actions.
    /// </summary>
    public class CoursePreviewUXPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(CoursePreviewUXPage));
        /// <summary>
        /// Get To Do Page window Title.
        /// If Window is accessible then window title should be as expected.
        /// </summary>
        /// <param name="tabName">This is name of the tab.</param>
        /// <returns>True if window title found as expected otherwirse false.</returns>
        public String GetToDoTabWindowTitle(string tabName)
        {
            //Get Window Title 
            logger.LogMethodEntry("CoursePreviewUXPage", "GetToDoTabWindowTitle",
               base.IsTakeScreenShotDuringEntryExit);
            //Initializing the variable
            string newTabName = tabName;
            if (tabName == CoursePreviewUXPageResource.
                CouresPreviewUX_Page_ToDo_Window_Title)
            {
                newTabName = CoursePreviewUXPageResource.
                    CouresPreviewUX_Page_AssignmentsToDo_Window_Title;
            }
            //Wait For Page To Get Switched
            base.WaitUntilPageGetSwitchedSuccessfully(newTabName);
            //Get Page Title
            string getWindowTitle = base.GetPageTitle;
            logger.LogMethodEntry("CoursePreviewUXPage", "GetToDoTabWindowTitle",
               base.IsTakeScreenShotDuringEntryExit);
            return getWindowTitle;
        }
        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectCourseMaterialsWindow()
        {
            //Select Window
            logger.LogMethodEntry("CoursePreviewUXPage", "SelectCourseMaterialsWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_Window_Title_Name_HED);
            base.SelectWindow(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_Window_Title_Name_HED);
            logger.LogMethodExit("CoursePreviewUXPage", "SelectCourseMaterialsWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Switch To Iframe
        /// </summary>
        private void SwitchToIframe()
        {
            //Switch To Iframe
            logger.LogMethodEntry("CoursePreviewUXPage", "SwitchToIframe",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_CoursePreview_IFrame_Id_Locator));
            //Switch To Frame
            base.SwitchToIFrame(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_CoursePreview_IFrame_Id_Locator);
            logger.LogMethodExit("CoursePreviewUXPage", "SwitchToIframe",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Get Activity Name In Course Materials Tab.
        /// </summary>
        /// <param name="assetName">This is Activity Name.</param>
        /// <returns>Activity Name</returns>
        public String GetActivityNameInCourseMaterialsTab(string assetName)
        {
            // Get Activity Name In Course Materials Tab
            logger.LogMethodEntry("CoursePreviewUXPage", "GetActivityNameInCourseMaterialsTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize getActivityText variable
            string getActivityName = string.Empty;
            try
            {
                //Select the window
                this.SelectCourseMaterialsWindow();
                //Siwtch to Iframe
                this.SwitchToIframe();
                Thread.Sleep(Convert.ToInt32(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Sleep_Time));
                base.WaitForElement(By.XPath(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Assets_Count_Xpath_Locator));
                //Total Row count of the Assets
                int getTotalRowCount = base.GetElementCountByXPath(
                    CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Assets_Count_Xpath_Locator);
                for (int setRowCount = Convert.ToInt32(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Loop_Initialization_Value);
                    setRowCount <= getTotalRowCount; setRowCount++)
                {
                    Thread.Sleep(Convert.ToInt32(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Sleep_Time));
                    base.WaitForElement(By.XPath(string.Format(CoursePreviewUXPageResource.
                     CoursePreviewUX_Page_Assets_Name_Xpath_Locator, setRowCount)));
                    //Getting the assets name               
                    getActivityName = base.GetElementTextByXPath
                     (string.Format(CoursePreviewUXPageResource.
                     CoursePreviewUX_Page_Assets_Name_Xpath_Locator, setRowCount));
                    if (getActivityName == assetName)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
                
            }
            logger.LogMethodEntry("CoursePreviewUXPage", "GetActivityNameInCourseMaterialsTab",
               base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }
        /// <summary>
        /// Launches the Etext Window.
        /// </summary>
        public void LaunchEText()
        {
            //Find EText Activity Present In Launch Window
            logger.LogMethodEntry("CoursePreviewUXPage", "LaunchEText",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(CoursePreviewUXPageResource.CoursePreviewUX_Page_Etext_Link));
                IWebElement EtextLink = base.GetWebElementPropertiesById(CoursePreviewUXPageResource.CoursePreviewUX_Page_Etext_Link);
                base.ClickByJavaScriptExecutor(EtextLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CoursePreviewUXPage", "LaunchEText",
               base.IsTakeScreenShotDuringEntryExit);

        }
        /// <summary>
        /// close the Etext Window.
        /// </summary>
        public void CloseEtextWindow()
        {
            logger.LogMethodEntry("CoursePreviewUXPage", "CloseEtextWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToLastOpenedWindow();
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CoursePreviewUXPage", "CloseEtextWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait for past due date icon to be displayed.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="activityUnderTabName">This is the Tab name.</param>
        /// <param name="userType">This is the user type enum.</param>
        public void WaitForPastDueDateIcon(string activityName, 
            string activityUnderTabName, User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("CoursePreviewUXPage", "WaitForPastDueDateIcon",
                base.IsTakeScreenShotDuringEntryExit);
            // Wait for past due date icon to be displayed
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                // Wait till entity enters from inactive state to active state
                int minutesToWait = Int32.Parse(ConfigurationManager.
                    AppSettings["AssignedToCopyInterval"]);
                while (stopwatch.Elapsed.TotalMinutes < 10)
                {
                    StudentPresentationPage studentPresentationPage =
                    new StudentPresentationPage();
                    //Select Window And Frame
                    studentPresentationPage.SelectWindowAndFrame();
                    //Get the class name of the icon
                    string dueDateClass = this.GetActivityClassName(activityName);
                    //Verify if Past Due date icon is displayed.
                    if (dueDateClass == CoursePreviewUXPageResource.
                        CoursePreviewUX_Page_PastDueDateIcon_Class_Id_Locator) break;
                    {
                        //Search the Entity
                        new TodaysViewUxPage().SelectTab(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_Window_Title_Name_HED);
                        new CommonPage().ManageTheActivityFolderLevelNavigation(
                        activityName, activityUnderTabName, userType);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CoursePreviewUXPage", "WaitForPastDueDateIcon",
               base.IsTakeScreenShotDuringEntryExit);

        }

            /// <summary>
            /// Returns the class name of the icon of the activity.
            /// </summary>
            /// <param name="activityName">This is the activity.</param>
            /// <returns></returns>
            private string  GetActivityClassName(string activityName)
        {
                // Returns the class name of the icon of the activity
            logger.LogMethodEntry("CoursePreviewUXPage", "GetActivityClassName",
            base.IsTakeScreenShotDuringEntryExit);
            // Returns the class name of the icon of the activity
            string activityLinkId = base.GetWebElementPropertiesByLinkText(activityName)
                .GetAttribute(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_Activity_WebElement_Property_Name);
            string pastDueDateIconId = CoursePreviewUXPageResource.
                CoursePreviewUX_Page_PastDueDateIcon_WebelementProperty_Id_PartialValue 
                + activityLinkId.Split('_')[1];
            // Returns the class name of the icon of the activity
            string pastDueDateClass = base.GetWebElementPropertiesByXPath(string.
                Format(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_PastDueDateIcon_Xpath_Locator, pastDueDateIconId)).
                GetAttribute("class");
            logger.LogMethodExit("CoursePreviewUXPage", "GetActivityClassName",
          base.IsTakeScreenShotDuringEntryExit);
            return pastDueDateClass;
            }
        
        }
    }


