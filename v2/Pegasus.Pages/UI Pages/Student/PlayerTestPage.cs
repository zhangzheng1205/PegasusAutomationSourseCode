using System;
using System.Windows.Forms;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using System.Threading;
using System.Configuration;
using System.Diagnostics;
using Pegasus.Pages.UI_Pages.Student;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles PlayerTest Presentation Page Actions
    /// </summary>
    public class PlayerTestPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = Logger.GetInstance(typeof(PlayerTestPage));

        /// <summary>
        /// Get Wait Time From App Config File.
        /// </summary>
        static readonly double getSecondsToWait = Convert.ToDouble
        (ConfigurationManager.AppSettings[PlayerTestPageResource.
        PlayerTestPage_TimeOut_Config_Key]);

        /// <summary>
        /// Launch The Activity
        /// </summary>
        /// <returns>Overview Button Present Result</returns>
        public Boolean IsMGMTestActivityLauched()
        {
            //Launching The Activity
            Logger.LogMethodEntry("PlayerTestPage", "IsMGMTestActivityLauched",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isPlayerTestPresent = false;
            try
            {
                Thread.Sleep(Convert.ToInt32(PlayerTestPageResource
                    .PlayerTextPage_Launch_TimeElement));
                base.SwitchToLastOpenedWindow();
                //Wait for Element
                base.WaitForElement(By.PartialLinkText(PlayerTestPageResource.
                    PlayerTextPage_Overview_Button_PartialLink_Locator));
                //Checks the presence of overview button
                isPlayerTestPresent = base.IsElementPresent(By.PartialLinkText(
                    PlayerTestPageResource.
                    PlayerTextPage_Overview_Button_PartialLink_Locator));
                //Close The Window
                base.CloseBrowserWindow();
                Thread.Sleep(Convert.ToInt32(PlayerTestPageResource.
                    PlayerTestPage_ThreadSleepToClosePopUp_Value));
                //Used SendKeys to Close modal pop up
                SendKeys.SendWait(PlayerTestPageResource.PlayerTestPage_EnterKey_Value);
                Thread.Sleep(Convert.ToInt32(PlayerTestPageResource
                    .PlayerTextPage_Launch_TimeElement));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PlayerTestPage", "IsMGMTestActivityLauched",
              base.isTakeScreenShotDuringEntryExit);
            return isPlayerTestPresent;
        }

        /// <summary>
        /// Validat MGM Test launched by student.
        /// </summary>
        /// <returns></returns>
        public Boolean IsMGMTestActivityLauchedByStudent()
        {
            //Launching The Activity
            Logger.LogMethodEntry("PlayerTestPage", "IsMGMTestActivityLauched",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isProductHeaderPresent = false;
            try
            {
                //Select Presentation Window
                this.SelectPresentationWindow();
                //Wait for ProductHeader Image Element
                base.WaitForElement(By.Id(
                    PlayerTestPageResource.PlayerTestPage_ProductHeader_Text_ID));
                //Checks the presence of overview button
                isProductHeaderPresent = base.IsElementPresent(By.Id(
                    PlayerTestPageResource.PlayerTestPage_ProductHeader_Text_ID));
                //Close The Window
                base.CloseBrowserWindow();
                Thread.Sleep(Convert.ToInt32(PlayerTestPageResource.
                    PlayerTestPage_ThreadSleepToClosePopUp_Value));
                //Used SendKeys to Close modal pop up
                SendKeys.SendWait(PlayerTestPageResource.PlayerTestPage_EnterKey_Value);
                Thread.Sleep(Convert.ToInt32(PlayerTestPageResource
                    .PlayerTestPage_ThreadSleep_Value));
                //Select window and refresh the page                   
                base.SelectWindow(PlayerTestPageResource.
                    PlayerTestPage_MainPageContent_WindowName_Title);
                base.RefreshTheCurrentPage();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PlayerTestPage", "IsMGMTestActivityLauched",
              base.isTakeScreenShotDuringEntryExit);
            return isProductHeaderPresent;

        }
        /// <summary>
        /// This function checks whether PreTest has been launched successfully
        /// </summary>
        /// <returns>Overview Buttton Present Result</returns>
        public Boolean IsSkillStudyPlanPreTestPreviewLaunched()
        {
            Logger.LogMethodEntry("PlayerTestPage", "IsSkillStudyPlanPreTestPreviewLaunched",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isOverviewButtonPresent = false;
            try
            {
                //Select Presentation Window
                this.SelectPresentationWindow();
                isOverviewButtonPresent = base.IsElementPresent
                    (By.XPath(PlayerTestPageResource.
                    PlayerTestPage_OverviewButton_Xpath_Locator));
                //Close The Window
                base.CloseBrowserWindow();
                Thread.Sleep(Convert.ToInt32(PlayerTestPageResource.
                    PlayerTestPage_ThreadSleep_Value));
                //Used SendKeys to Close modal pop up
                base.PressKey(PlayerTestPageResource.PlayerTestPage_EnterKey_Value);
                Thread.Sleep(Convert.ToInt32(PlayerTestPageResource
                    .PlayerTestPage_ThreadSleep_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PlayerTestPage", "IsSkillStudyPlanPreTestPreviewLaunched",
              base.isTakeScreenShotDuringEntryExit);
            return isOverviewButtonPresent;
        }

        /// <summary>
        /// Select Presentation Window
        /// </summary>
        private void SelectPresentationWindow()
        {
            //Select Presentation Window
            Logger.LogMethodEntry("PlayerTestPage", "SelectPresentationWindow",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable to Get Window Name
            string getwindowName = string.Empty;
            //Initialize Variable to Get Base Window Name
            string getbaseWindowName = string.Empty;
            //Select Default Window
            base.SelectDefaultWindow();
            //Get Base Window Title
            getbaseWindowName = base.GetWindowTitleByJavaScriptExecutor();
            //Start Stop Watch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            do
            {
                try
                {
                    Thread.Sleep(Convert.ToInt32(PlayerTestPageResource.
                        PlayerTestPage_CustomTimeForActivtiyLaunch_Value));
                    //Switch to Last Opened Window
                    base.SwitchToLastOpenedWindow();
                    //Get Window Name
                    getwindowName = base.GetWindowTitleByJavaScriptExecutor();
                }
                catch { }

            } while (getwindowName == getbaseWindowName
                && stopWatch.Elapsed.TotalSeconds < getSecondsToWait && getwindowName != null);
            //Select Window
            base.SelectWindow(getwindowName);
            Logger.LogMethodExit("PlayerTestPage", "SelectPresentationWindow",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
