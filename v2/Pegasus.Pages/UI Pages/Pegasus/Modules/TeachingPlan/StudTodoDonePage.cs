using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Diagnostics;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UITesting;
using System.Threading;
using OpenQA.Selenium.Remote;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles View Assigned Contents in To Do Tab.
    /// </summary>    
    public class StudTodoDonePage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(StudTodoDonePage));
        /// <summary>
        /// Get Wait Time From App Config File.
        /// </summary>
        static readonly double getSecondsToWait = Convert.ToDouble
        (ConfigurationManager.AppSettings["SIM5LaunchWaitTimeInSeconds"]);
        //Initialize Variable
        string getBrowserName = string.Empty;
        string getBrowserInformation = string.Empty;

        /// <summary>
        /// Get browser name from configuration.
        /// </summary>
        private String browser = ConfigurationManager.AppSettings["Browser"];

        /// <summary>
        /// Get Assigned Content In To Do Tab.
        /// </summary>
        /// <returns>Activity Name.</returns>
        public String GetAssignedContentInToDoTab(string activityName)
        {
            //Get Assigned Content In To Do Tab
            logger.LogMethodEntry("StudTodoDonePage", "GetAssignedContentInToDoTab",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getActivityName = string.Empty;
            try
            {
                //Select Window And Frame
                this.SelectWindowAndFrame();
                base.WaitForElement(By.XPath(StudTodoDonePageResource.
                    StudToDoDone_Page_Activity_Count_XPath));
                //Get Activity Count
                int getActivityCount = base.GetElementCountByXPath(StudTodoDonePageResource.
                    StudToDoDone_Page_Activity_Count_XPath);
                for (int setRowCount = Convert.ToInt32(StudTodoDonePageResource.
                    StudToDoDone_Page_Initial_Loop_Count_Value); 
                    setRowCount <= getActivityCount; setRowCount++)
                {                    
                    //Wait for Activity Xpath                    
                    base.WaitForElement(By.XPath(string.Format(StudTodoDonePageResource.
                        StudToDoDone_Page_ActivityName_Xpath_Locator, setRowCount)));
                    //Get Activity Name
                    getActivityName = base.GetElementTextByXPath
                        (string.Format(StudTodoDonePageResource.
                        StudToDoDone_Page_ActivityName_Xpath_Locator, setRowCount));
                    if (getActivityName == activityName)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudTodoDonePage", "GetAssignedContentInToDoTab",
               base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Select Window And Frame.
        /// </summary>
        private void SelectWindowAndFrame()
        {
            //Wait for the window
            base.WaitUntilWindowLoads(StudTodoDonePageResource.
                StudToDoDone_Page_ToDo_Tab_Name);
            base.SelectWindow(StudTodoDonePageResource.
                StudToDoDone_Page_ToDo_Tab_Name);
            //Select the Frame
            base.SwitchToIFrame(StudTodoDonePageResource.
                StudToDoDone_Page_ToDo_Frame_Name);
        }

        /// <summary>
        /// Get Assigned and Completed Content In Completed Tab.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Name</returns>
        public String GetAssignedCompletedContentInCompletedTab(string activityName)
        {
            //Get Assigned and Completed Content In Completed Tab
            logger.LogMethodEntry("StudTodoDonePage", "GetAssignedCompletedContentInCompletedTab",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getActivityName = string.Empty;
            try
            {
                //Select Window and Frame
                this.SelectDoneWindowAndFrame();
                //Wait for Element
                base.WaitForElement(By.XPath(StudTodoDonePageResource.
                    StudToDoDone_Page_Activity_Count_XPath));
                //Get Activity Count
                int getActivityCount = base.GetElementCountByXPath(StudTodoDonePageResource.
                    StudToDoDone_Page_Activity_Count_XPath);
                for (int setRowCount = Convert.ToInt32(StudTodoDonePageResource.
                    StudToDoDone_Page_Initial_Count); setRowCount <= getActivityCount; setRowCount++)
                {
                    //Wait for Activity Xpath                    
                    base.WaitForElement(By.XPath(string.Format(StudTodoDonePageResource.
                        StudToDoDone_Page_Activity_Name_Completed_Tab_XPath, setRowCount)));
                    //Get Activity Name
                    getActivityName = base.GetElementTextByXPath
                        (string.Format(StudTodoDonePageResource.
                        StudToDoDone_Page_Activity_Name_Completed_Tab_XPath, setRowCount));
                    if (getActivityName == activityName)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudTodoDonePage", "GetAssignedCompletedContentInCompletedTab",
               base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Select Window and Frame.
        /// </summary>
        private void SelectDoneWindowAndFrame()
        {
            //Select Window and Frame
            logger.LogMethodEntry("StudTodoDonePage", "SelectDoneWindowAndFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for the window
            base.WaitUntilWindowLoads(StudTodoDonePageResource.
                StudToDoDone_Page_Done_WindowName);
            //Select Window
            base.SelectWindow(StudTodoDonePageResource.
                StudToDoDone_Page_Done_WindowName);
            //Select the Frame
            base.SwitchToIFrame(StudTodoDonePageResource.
                StudToDoDone_Page_ToDo_Frame_Name);
            logger.LogMethodExit("StudTodoDonePage", "SelectDoneWindowAndFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity In Assignments Tab.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SelectActivityInAssignments(string activityName)
        {
            //Fetch User
            User user = User.Get(User.UserTypeEnum.HedMilPPEStudent);
            //Start Stop Watch
            Stopwatch stopWatch = new Stopwatch();
            //Select Window and Frame
            this.SelectWindowAndFrame();
            //Verify Activity Display In Assignment
            this.VerifyActivityDisplayInAssignment(activityName);
            base.WaitForElement(By.XPath(StudTodoDonePageResource.
                StudToDoDone_Page_ActivityCount_Xpath_Locator));
            //Get Activity Count
            int getActivityCount = base.GetElementCountByXPath(StudTodoDonePageResource.
                StudToDoDone_Page_ActivityCount_Xpath_Locator);
            for (int i = Convert.ToInt32(StudTodoDonePageResource.
                StudToDoDone_Page_Initial_Loop_Count_Value); i <= getActivityCount; i++)
            {
                //Get Actual Activity Name
                string getActualActivityName = GetActivityNameInAssignment(i);
                if (getActualActivityName == activityName)
                {
                    //Click on Activity and Calculate Time
                    this.ClickonActivityandCalculateTime(activityName, user, stopWatch, i);
                    //Get Transaction Time
                    double getTransactionTime = stopWatch.Elapsed.TotalSeconds;
                    //Transaction Time
                    TransactionTimings = activityName + StudTodoDonePageResource.
                                StudToDoDone_Page_LogText_LaunchTime + StudTodoDonePageResource.
                                StudToDoDone_Page_LogMessage_AssignmentOperator
                                + getTransactionTime.ToString() +
                                StudTodoDonePageResource.StudToDoDone_Page_Time_Metric;  
                    break;
                }
            }
            //Get Browser Information
            CurrentBrowserName = base.GetCurrentBrowserInformationByJavaScriptExecutor();
            logger.LogMethodExit("StudTodoDonePage", "SelectActivityInAssignments",
               base.IsTakeScreenShotDuringEntryExit);
        }
        

        /// <summary>
        /// Click on Activity and Calculate Time.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="user">This is User Type.</param>
        /// <param name="stopWatch">This is Stopwatch Instance.</param>
        /// <param name="i">This is Loop Value.</param>
        private void ClickonActivityandCalculateTime(string activityName,
            User user, Stopwatch stopWatch, int i)
        {
            base.WaitForElement(By.XPath(string.Format(StudTodoDonePageResource.
                StudToDoDone_Page_Activity_Xpath_Locator, i)));
            //Click on Activity
            IWebElement getActivity =
                base.GetWebElementPropertiesByXPath((string.Format(StudTodoDonePageResource.
                StudToDoDone_Page_Activity_Xpath_Locator, i)));
            base.ClickByJavaScriptExecutor(getActivity);
            //Stop Watch Starts
            stopWatch.Start();
            if (getBrowserName == StudTodoDonePageResource.
                StudToDoDone_Page_BrowserName_InternetExplorer)
            {
                base.WaitUntilWindowLoads(StudTodoDonePageResource.
                    StudToDoDone_Page_CompatibilityMessage_Window);
                //Select Window
                base.SelectWindow(StudTodoDonePageResource.
                    StudToDoDone_Page_CompatibilityMessage_Window);
                base.WaitForElement(By.PartialLinkText(StudTodoDonePageResource.
                    StudToDoDone_Page_ClickHere_Link_PartialLink_Locator));
                //Click on 'CLICK HERE' Link
                IWebElement getClickHereLink =
                    base.GetWebElementPropertiesByPartialLinkText(StudTodoDonePageResource.
                    StudToDoDone_Page_ClickHere_Link_PartialLink_Locator);
                base.ClickByJavaScriptExecutor(getClickHereLink);
            }
            //Select Activity Presentation Window
            this.SelectSIM5ActivityPresentationWindow(activityName, user);
            while(stopWatch.Elapsed.TotalSeconds < getSecondsToWait)
            {
                if (!base.IsElementDisplayedById(StudTodoDonePageResource.
                StudToDoDone_Page_Loading_Image_Id_Locator))
                {
                    break;
                }
            } 
            //Stop Watch Stops
            stopWatch.Stop();
        }

        /// <summary>
        /// Get Activity Name In Assignment.
        /// </summary>
        /// <param name="rowCount">This is Rowcount.</param>
        /// <returns>Activity Name.</returns>
        private string GetActivityNameInAssignment(int rowCount)
        {
            //Get Activity Name In Assignment
            base.WaitForElement(By.XPath(string.Format(StudTodoDonePageResource.
                StudToDoDone_Page_ActivityName_Xpath_Locator, rowCount)));
            //Get Activity Name
            string getActivityName =
                base.GetElementTextByXPath(string.Format(StudTodoDonePageResource.
                StudToDoDone_Page_ActivityName_Xpath_Locator, rowCount));
            //Get Actual Activity Name
            string getActualActivityName = getActivityName.Replace(StudTodoDonePageResource.
                StudToDoDone_Page_NewlineCharacter,
                StudTodoDonePageResource.StudToDoDone_Page_Null).Trim();
            return getActualActivityName;
        }

        /// <summary>
        /// Verify Activity Display In Assignment.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void VerifyActivityDisplayInAssignment(string activityName)
        {
            //Initialize Variable
            string getActivityText = string.Empty;
            do
            {
                //Get Browser Name
                this.GetBrowserName();
                if (getBrowserName == StudTodoDonePageResource.
                        StudToDoDone_Page_BrowserName_InternetExplorer)
                {
                    Thread.Sleep(Convert.ToInt32(StudTodoDonePageResource.
                        StudToDoDone_Page_ToDo_Wait_Time));
                    base.WaitForElement(By.Id(StudTodoDonePageResource.
                            StudToDoDone_Page_Activity_Text_ToDo_Id_Locator));
                    //Get Activity Text
                    getActivityText = base.GetElementInnerTextById(StudTodoDonePageResource.
                            StudToDoDone_Page_Activity_Text_ToDo_Id_Locator);
                }
                else
                {
                    Thread.Sleep(Convert.ToInt32(StudTodoDonePageResource.
                        StudToDoDone_Page_ToDo_Wait_Time));
                    base.WaitForElement(By.CssSelector(StudTodoDonePageResource.
                        StudToDoDone_Page_Activity_ToDo_Id_Locator));
                    //Get Activity Text
                    getActivityText =
                        base.GetElementInnerTextByCssSelector(StudTodoDonePageResource.
                         StudToDoDone_Page_Activity_ToDo_Id_Locator);
                }
                if (!getActivityText.Contains(activityName))
                {
                    base.WaitForElement(By.PartialLinkText(StudTodoDonePageResource.
                        StudToDoDone_Page_ShowMore_Button_Id_Locator));
                    //Get Show More Button Property
                    IWebElement getShowMoreButton =
                        base.GetWebElementPropertiesByPartialLinkText(StudTodoDonePageResource.
                        StudToDoDone_Page_ShowMore_Button_Id_Locator);
                    //Click on 'Show More' Button
                    base.ClickByJavaScriptExecutor(getShowMoreButton);
                }
            } while (!getActivityText.Contains(activityName));
        }

        /// <summary>
        /// Get Browser Name.
        /// </summary>
        private void GetBrowserName()
        {
            //Get Browser Information
            getBrowserInformation =
                base.GetCurrentBrowserInformationByJavaScriptExecutor();
            if (base.IsStringContainsTheSubString(getBrowserInformation,
                StudTodoDonePageResource.StudToDoDone_Page_BrowserName_Chrome))
            {
                //Get Browser Name
                getBrowserName = StudTodoDonePageResource.
                    StudToDoDone_Page_BrowserName_Chrome;
            }
            else if (base.IsStringContainsTheSubString(getBrowserInformation,
                StudTodoDonePageResource.StudToDoDone_Page_BrowserName_FireFox))
            {
                //Get Browser Name
                getBrowserName = StudTodoDonePageResource.
                StudToDoDone_Page_BrowserName_FireFox;
            }
            else
            {
                //Get Browser Name
                getBrowserName = StudTodoDonePageResource.
                    StudToDoDone_Page_BrowserName_InternetExplorer;
            }
        }

        /// <summary>
        /// Select SIM5 Activity Presentation Window.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="user">This is User.</param>
        private void SelectSIM5ActivityPresentationWindow(string activityName, User user)
        {
            //Select Activity Presentation Window
            base.WaitUntilWindowLoads(activityName + StudTodoDonePageResource.
                StudToDoDone_Page_Text_Seperator + user.LastName +
                StudTodoDonePageResource.StudToDoDone_Page_Space +
                user.FirstName);
            //Select Window
            base.SelectWindow(activityName + StudTodoDonePageResource.
                StudToDoDone_Page_Text_Seperator + user.LastName +
                StudTodoDonePageResource.StudToDoDone_Page_Space + user.FirstName);
        }

        /// <summary>
        /// Launch SIM5 Questions By Navigating.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="activityCount">This is Activity Count.</param>
        public void LaunchSIM5QuestionsByNavigating(string activityName, int questionCount)
        {
            //Launch SIM5 Questions By Navigating            
            try
            {
                //Fetch User
                User user = User.Get(User.UserTypeEnum.HedMilPPEStudent);
                //Start Stop Watch
                Stopwatch stopWatch = new Stopwatch();
                //Select Activity Presentation Window
                this.SelectSIM5ActivityPresentationWindow(activityName, user);
                for (int i = Convert.ToInt32(StudTodoDonePageResource.
                    StudToDoDone_Page_Initial_Loop_Count_Value);
                    i <= questionCount; i++)
                {  
                    base.WaitForElement(By.Id(StudTodoDonePageResource.
                        StudToDoDone_Page_Forward_Button_Id_Locator));
                    IWebElement getNextButton =
                        base.GetWebElementPropertiesById(StudTodoDonePageResource.
                        StudToDoDone_Page_Forward_Button_Id_Locator);
                    //Click on Next Button
                    base.ClickByJavaScriptExecutor(getNextButton);                   
                    stopWatch.Start();
                    //Select Activity Presentation Window
                    this.SelectSIM5ActivityPresentationWindow(activityName, user);
                    while (base.IsElementDisplayedById(StudTodoDonePageResource.
                        StudToDoDone_Page_Loading_Image_Id_Locator) &&
                        stopWatch.Elapsed.TotalSeconds < getSecondsToWait)
                    {
                        if (!base.IsElementDisplayedById(StudTodoDonePageResource.
                        StudToDoDone_Page_Loading_Image_Id_Locator))
                        {
                            break;
                        }
                    } 
                    stopWatch.Stop();
                    //Get Browser Information                    
                    CurrentBrowserName = base.GetCurrentBrowserInformationByJavaScriptExecutor();
                    //Question Launch Time
                    double getQuestionLaunchTime = stopWatch.Elapsed.TotalSeconds;
                    TransactionTimings = activityName + StudTodoDonePageResource.
                                StudToDoDone_Page_LogText_Question
                                + i + StudTodoDonePageResource.
                                StudToDoDone_Page_LogText_LoadTime + StudTodoDonePageResource.
                                    StudToDoDone_Page_LogMessage_AssignmentOperator +
                                    getQuestionLaunchTime.ToString() + StudTodoDonePageResource.
                                    StudToDoDone_Page_Time_Metric;       
                    logger.LogMethodExit("StudTodoDonePage", "LaunchSIM5QuestionsByNavigating",
                  base.IsTakeScreenShotDuringEntryExit);
                }
                //Click on Submit Button
                this.ClickonSubmitButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }
       
        /// <summary>
        /// Click on Submit Button.
        /// </summary>
        private void ClickonSubmitButton()
        {           
            //Click on Submit Button
            base.WaitForElement(By.Id(StudTodoDonePageResource.
                StudToDoDone_Page_Submit_Button_Id_Locator));
            //Click on Submit Button
            IWebElement getSubmitButton =
                base.GetWebElementPropertiesById(StudTodoDonePageResource.
                StudToDoDone_Page_Submit_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(getSubmitButton);
            base.WaitForElement(By.XPath(StudTodoDonePageResource.
                StudToDoDone_Page_Ok_Button_Xpath_Locator));
            //Click on Ok Button
            IWebElement getOkButtonProperty =
                base.GetWebElementPropertiesByXPath(StudTodoDonePageResource.
                StudToDoDone_Page_Ok_Button_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getOkButtonProperty);
        }
    }
}
