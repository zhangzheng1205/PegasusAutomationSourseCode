using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.LtiIntegeration.RLCNUtility;
using Pegasus.Automation.DataTransferObjects;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles RLCN Utility Actions.
    /// </summary>
    public class RLCNUtilityPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(RLCNUtilityPage));

        //initialize variable storing count of dropdown list values
        int ddlcount = 0;

        /// <summary>
        /// Trigger Failed RLCN Requests
        /// </summary>
        public void TriggerFailedRLCNRequests()
        {
            //Select RLCN Failed Requests Window
            Logger.LogMethodEntry("RLCNUtilityPage", "TriggerFailedRLCNRequests",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the RLCN Failed Requests Window
                this.SelectRLCNFailedRequestsWindow();

                //Get count of values in the Database dropdown
                ddlcount = base.GetElementCountByCssSelector(
                    RLCNUtilityPageResource.RLCNUtility_Page_DataBase_Name_DropDown_CSSSelector_Locator);
                //Check for failed RLCN Requests in all the Databases
                for (int i = 0; i <= ddlcount-1; i++)
                {
                    //Select Name of the DataBase
                    this.SelectDataBase(i);
                    //Select From date
                    this.SelectFromandToDates();
                    //Click the Fetch button
                    this.ClickFetchButton();
                    //Get the course title
                    bool coursePresent = base.IsElementPresent(By.XPath(
                        RLCNUtilityPageResource.RLCNUtility_Page_CourseTitle_Xpath_Locator), 10);
                    //verify if failed RLCN requests are available
                    if (coursePresent)
                    {
                        //Gets the name of the course from the RLCN page
                        base.WaitForElement(By.XPath(
                            RLCNUtilityPageResource.RLCNUtility_Page_CourseTitle_Xpath_Locator));
                        String courseTitle = base.GetWebElementPropertiesByXPath(
                            RLCNUtilityPageResource.RLCNUtility_Page_CourseTitle_Xpath_Locator).GetAttribute("innerText");
                        //Get the Course From Memory
                        Course courseDP = Course.Get(Course.CourseTypeEnum.MasterLibrary);
                        string courseName = courseDP.Name.ToString();
                        //Verify course in RLCN Page is same as course in Memory
                        if (courseTitle == courseName)
                        {
                            this.ClickResolve();
                            break;
                        }
                        else
                            continue;
                    }
                    //else
                    //    continue;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("RLCNUtilityPage", "TriggerFailedRLCNRequests",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select Trigger Failed RLCNRequests Window.
        /// </summary>
        private void SelectRLCNFailedRequestsWindow()
        {
            //Select Trigger Failed RLCNRequests Window
            Logger.LogMethodEntry("RLCNUtilityPage", "SelectRLCNFailedRequestsWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window Loads
            base.WaitUntilWindowLoads(RLCNUtilityPageResource.
                RLCNUtility_Page_RLCNFailedRequests_Window_Title_Locator);
            //Select Window
            base.SelectWindow(RLCNUtilityPageResource.
                RLCNUtility_Page_RLCNFailedRequests_Window_Title_Locator);
            Logger.LogMethodExit("RLCNUtilityPage", "SelectRLCNFailedRequestsWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select DataBase.
        /// </summary>
        private void SelectDataBase(int indexcount)
        {
            //Select DataBase
            Logger.LogMethodEntry("RLCNUtilityPage", "SelectDataBase",
                base.IsTakeScreenShotDuringEntryExit);
            //Select DataBase Name value from dropdown
            int dropdownvalueindex = indexcount;
                base.SelectDropDownValueThroughIndexById
                    (RLCNUtilityPageResource.RLCNUtility_Page_DataBase_Name_DropDown_Id_Locator, 
                    dropdownvalueindex);
            Logger.LogMethodExit("RLCNUtilityPage", "SelectDataBase",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select From and To dates.
        /// </summary>
        private void SelectFromandToDates()
        {
            //Select Trigger Failed RLCNRequests Window
            Logger.LogMethodEntry("RLCNUtilityPage", "SelectFromAndToDates",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on date picker of start date
            //base.WaitForElement(By.XPath(RLCNUtilityPageResource.
            //    RLCNUtility_Page_StartDatePicker_Image_Xpath_Locator));
            //IWebElement fromDateWidget = base.GetWebElementPropertiesByXPath
            //   (RLCNUtilityPageResource.
            //    RLCNUtility_Page_StartDatePicker_Image_Xpath_Locator);
            base.ClearTextById(RLCNUtilityPageResource.
                RLCNUtility_Page_StartDate_Text_ID_Locator);
            //base.ClickByJavaScriptExecutor(fromDateWidget);
            this.SelectFromDate();
            //Click on date picker of end date
            base.WaitForElement(By.XPath(RLCNUtilityPageResource.
                RLCNUtility_Page_EndDatePicker_Image_Xpath_Locator));
            IWebElement toDateWidget = base.GetWebElementPropertiesByXPath
                (RLCNUtilityPageResource.RLCNUtility_Page_EndDatePicker_Image_Xpath_Locator);
            base.ClearTextById(RLCNUtilityPageResource.
                RLCNUtility_Page_EndDate_Text_ID_Locator);
            base.ClickByJavaScriptExecutor(toDateWidget);
            this.SelectDatefromWidget();
            Logger.LogMethodExit("RLCNUtilityPage", "SelectFromAndToDates",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select from date
        /// </summary>
        private void SelectFromDate()
        {
            //Select From date
            Logger.LogMethodEntry("RLCNUtilityPage", "SelectDatefromWidget",
                base.IsTakeScreenShotDuringEntryExit);
            //Get date time from memory
            User user = User.Get(User.UserTypeEnum.DPCsTeacher);
            DateTime dateTime = user.CurrentProfileDateTime.AddDays(-300);
            //Convert to string
            string currentDateTime = dateTime.ToString();
            //Split Date and Time
            string currentTime = currentDateTime.Split(' ')[1];
            string fromDate = currentDateTime.Split(' ')[0];
            //Fill From Date
            base.GetWebElementPropertiesById(RLCNUtilityPageResource.
                RLCNUtility_Page_StartDate_Text_ID_Locator);
            base.FillTextBoxById(RLCNUtilityPageResource.
                RLCNUtility_Page_StartDate_Text_ID_Locator, fromDate);

        }

        /// <summary>
        /// Select date from calendar widget.
        /// </summary>
         private void SelectDatefromWidget()
        {
            //Select Trigger Failed RLCNRequests Window
            Logger.LogMethodEntry("RLCNUtilityPage", "SelectDatefromWidget",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on date picker of start date
            try
            {
                //Select date
                Thread.Sleep(Convert.ToInt32(RLCNUtilityPageResource.
                    RLCNUtility_Page_SleepTime_Value));
                int calendarRowCount = base.GetElementCountByXPath(RLCNUtilityPageResource.
                    RLCNUtility_Page_Calendar_RowCount_Xpath_Locator);
                for (int i = 1; i <= calendarRowCount; i++)
                {
                    int calendarColumnCount = base.GetElementCountByXPath(String.
                        Format(RLCNUtilityPageResource.
                        RLCNUtility_Page_Calendar_ColumnCount_Xpath_Locator, i));
                    for (int j = 1; j <= calendarColumnCount; j++)
                    {
                        //Verify if date value is present or blank in a cell in calendar
                        bool dayValuePresent = base.IsElementPresent(By.XPath(String.
                            Format(RLCNUtilityPageResource.
                            RLCNUtility_Page_Calendar_DateValueInColumn_Xpath_Locator, i, j)), 3);
                        if (dayValuePresent)
                        {
                            //Gets the date value from calendar
                            IWebElement getDateValue = base.GetWebElementPropertiesByXPath(String.
                                Format(RLCNUtilityPageResource.
                                RLCNUtility_Page_Calendar_DateValueInColumn_Xpath_Locator, i, j));
                            //Get the class name of the date 
                            string dateClass = getDateValue.GetAttribute("class");
                            if (dateClass == RLCNUtilityPageResource.
                                RLCNUtility_Page_CurrentDate_ClassName_Locator)
                                {
                                Thread.Sleep(Convert.ToInt32(RLCNUtilityPageResource.
                                    RLCNUtility_Page_SleepTime_Value));
                                base.ClickByJavaScriptExecutor(getDateValue);
                                Thread.Sleep(Convert.ToInt32(RLCNUtilityPageResource.
                                    RLCNUtility_Page_SleepTime_Value));
                                break;
                                }
                        }
                    }
                }
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);

            }
            Logger.LogMethodExit("RLCNUtilityPage", "SelectDatefromWidget",
                base.IsTakeScreenShotDuringEntryExit);
        }

         /// <summary>
         /// Click the Fetch button.
         /// </summary>
         private void ClickFetchButton()
        {
            //Click Fetch Button
            Logger.LogMethodEntry("RLCNUtilityPage", "ClickFetchButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for button to load
            base.WaitForElement(By.XPath(RLCNUtilityPageResource.
                RLCNUtility_Page_Fetch_Button_Xpath_Locator));
            IWebElement fetchButton = base.GetWebElementPropertiesByXPath(
                RLCNUtilityPageResource.RLCNUtility_Page_Fetch_Button_Xpath_Locator);
            //Click button
            base.ClickByJavaScriptExecutor(fetchButton);
            Logger.LogMethodExit("RLCNUtilityPage", "ClickFetchButton",
                base.IsTakeScreenShotDuringEntryExit);
        }


        private void getCourseList()
         {
             //Get Course list from RLCN failed Requests
             Logger.LogMethodEntry("RLCNUtilityPage", "getCourseList",
                 base.IsTakeScreenShotDuringEntryExit);
             Thread.Sleep(Convert.ToInt32(RLCNUtilityPageResource.
                     RLCNUtility_Page_SleepTime_Value));
             int courseList = base.GetElementCountByXPath(RLCNUtilityPageResource.
                 RLCNUtility_Page_CourseTitle_Count_Xpath_Locator);
             Logger.LogMethodExit("RLCNUtilityPage", "getCourseList",
                  base.IsTakeScreenShotDuringEntryExit);
         }


        /// <summary>
        /// Click on Resolve link
        /// </summary>
        private void ClickResolve()
         {
            //Click Resolve Link
             Logger.LogMethodEntry("RLCNUtilityPage", "ClickResolve",
                 base.IsTakeScreenShotDuringEntryExit);
            //Wait for link to load
             base.WaitForElement(By.XPath(RLCNUtilityPageResource.
                 RLCNUtility_Page_Resolve_Link_Xpath_Locator));
             IWebElement resolveLink = base.GetWebElementPropertiesByXPath(
                 RLCNUtilityPageResource.RLCNUtility_Page_Resolve_Link_Xpath_Locator);
            //Click link
             base.ClickByJavaScriptExecutor(resolveLink);
             Logger.LogMethodExit("RLCNUtilityPage", "ClickResolve",
                 base.IsTakeScreenShotDuringEntryExit);
         }

    }
}