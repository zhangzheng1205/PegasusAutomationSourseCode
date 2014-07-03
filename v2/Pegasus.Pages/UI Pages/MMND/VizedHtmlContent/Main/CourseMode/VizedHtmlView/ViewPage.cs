using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.MMND.VizedHtmlContent.Main.CourseMode.VizedHtmlView;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles View Page related Actions
    /// </summary>
    public class ViewPage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ViewPage));
                
        /// <summary>
        /// Preview Instructor Todays View Link.
        /// </summary>
        /// <param name="subtabLinkName">This is Tool/Asset launch Subtab Link Name.</param>
        public void PreviewInstructorTodaysViewLink(string subtabLinkName)
        {
            //Preview Instructor Todays View Link
            logger.LogMethodEntry("ViewPage", "PreviewInstructorTodaysViewLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {                
                //Select the Window
                base.SelectWindow(subtabLinkName);
                //Wait for the Frame
                base.WaitForElement(By.Id(ViewPageResource.
                    ViewPage_Frame_CenterIFrame_Id_Locator));
                base.SwitchToIFrame(ViewPageResource.
                    ViewPage_Frame_CenterIFrame_Id_Locator);
                //Wait for the 'Todays_View' link
                base.WaitForElement(By.PartialLinkText(ViewPageResource.
                    ViewPage_Instructor_Tool_PartialLink_Locator));
                base.FocusOnElementByPartialLinkText(ViewPageResource.
                    ViewPage_Instructor_Tool_PartialLink_Locator);
                //Press Enter Key and Accept the Alert
                this.PressEnterKeyAndAcceptTheAlert();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewPage", "PreviewInstructorTodaysViewLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Press Enter Key and Accept the Alert.
        /// </summary>
        public void PressEnterKeyAndAcceptTheAlert()
        {
            //Press Enter Key
            logger.LogMethodEntry("ViewPage", "PressEnterKeyAndAcceptTheAlert",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the "Todays View" link
                base.PressKey(ViewPageResource.ViewPage_Enter_Key_Text);
                //Wait for 3 secs
                Thread.Sleep(Convert.ToInt32(ViewPageResource.ViewPage_Sleep_Time));
                //Accept the Alert
                base.PressKey(ViewPageResource.ViewPage_Enter_Key_Text);
                //Wait for 3 secs
                Thread.Sleep(Convert.ToInt32(ViewPageResource.ViewPage_Sleep_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewPage", "PressEnterKeyAndAcceptTheAlert",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Preview Student Course Calendar Link
        /// </summary>
        /// <param name="subtabLinkName">This is Tool/Asset launch Subtab Link Name</param>
        public void PreviewStudentCourseCalendarLink(string subtabLinkName)
        {
            //Preview Student Course Calendar Link
            logger.LogMethodEntry("ViewPage", "PreviewStudentCourseCalendarLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Window
                base.SelectWindow(subtabLinkName);
                //Wait for the Frame
                base.WaitForElement(By.Id(ViewPageResource.
                    ViewPage_Frame_CenterIFrame_Id_Locator));
                base.SwitchToIFrame(ViewPageResource.
                    ViewPage_Frame_CenterIFrame_Id_Locator);
                //Wait for the 'Course_Calendar' link
                base.WaitForElement(By.PartialLinkText(ViewPageResource.
                    ViewPage_Student_Tool_PartialLink_Locator));
                base.FocusOnElementByPartialLinkText(ViewPageResource.
                    ViewPage_Student_Tool_PartialLink_Locator);
                //Press Enter Key and Accept the Alert
                this.PressEnterKeyAndAcceptTheAlert();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewPage", "PreviewStudentCourseCalendarLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Course Name From Pegasus Window
        /// </summary>
        /// <param name="windowName">This is window Name</param>
        /// <returns>Displayed Course Name</returns>
        public String GetTheCourseNameFromPegasusWindow(string windowName)
        {
            //Get The Course Name From Pegasus Window
            logger.LogMethodEntry("ViewPage", "GetTheCourseNameFromPegasusWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getCourseName = string.Empty;
            try
            {
                //Wait for Pegasus Window
                base.WaitUntilWindowLoads(windowName);
                //Select the Window
                base.SelectWindow(windowName);                
                getCourseName = base.GetElementTextByClassName(ViewPageResource.
                    ViewPage_CourseName_ClassName_Locator);                
                //Close the window
                base.CloseBrowserWindow();
                base.IsPopUpClosed(Convert.ToInt32(ViewPageResource.
                    ViewPage_Pegasus_Window_Count_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewPage", "GetTheCourseNameFromPegasusWindow",
                base.isTakeScreenShotDuringEntryExit);
            return getCourseName;
        }

        /// <summary>
        /// Sign Out From MMND
        /// </summary>
        public void SignOutFromMMND()
        {
            //Sign Out From MMND
            logger.LogMethodEntry("ViewPage", "SignOutFromMMND",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Default Window
                base.SelectDefaultWindow();
                base.WaitForElement(By.PartialLinkText(ViewPageResource.
                    ViewPage_SignOut_PartialLink_Locator));
                //Click on SignOut link
                base.ClickByJavaScriptExecutor(base.
                    GetWebElementPropertiesByPartialLinkText(ViewPageResource.
                    ViewPage_SignOut_PartialLink_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewPage", "SignOutFromMMND",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Preview Asset Link
        /// </summary>
        /// <param name="subtabLinkName">This is Tool/Asset launch Subtab Link Name</param>
        public void PreviewAssetLink(string subtabLinkName)
        {            
            //Preview Instructor Todays View Link
            logger.LogMethodEntry("ViewPage", "PreviewAssetLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Window
                base.SelectWindow(subtabLinkName);
                //Wait for the Frame
                base.WaitForElement(By.Id(ViewPageResource.
                    ViewPage_Frame_CenterIFrame_Id_Locator));
                base.SwitchToIFrame(ViewPageResource.
                    ViewPage_Frame_CenterIFrame_Id_Locator);
                //Wait for the link
                base.WaitForElement(By.PartialLinkText(ViewPageResource.
                    ViewPage_Asset_Tool_Link_Text_Locator));
                base.FocusOnElementByPartialLinkText(ViewPageResource.
                    ViewPage_Asset_Tool_Link_Text_Locator);
                //Press Enter Key and Accept the Alert
                this.PressEnterKeyAndAcceptTheAlert();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewPage", "PreviewAssetLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// IsAsset Tool Link Page Displayed
        /// </summary>
        /// <returns>True if Assert tool link is Displayed otherwise False</returns>
        public Boolean IsAssetToolLinkPageDisplayed()
        {
            //Is Asset Tool Link Page Displayed
            logger.LogMethodEntry("ViewPage", "IsAssetToolLinkPageDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isCoursePreviewLinkDisplayed = false;            
            try
            {
                //Wait for the Window to Load
                base.WaitUntilWindowLoads(ViewPageResource.
                    ViewPage_Asset_Tool_Window_Title);
                base.SelectWindow(ViewPageResource.
                    ViewPage_Asset_Tool_Window_Title);
                //Wait for the Element
                base.WaitForElement(By.ClassName(ViewPageResource.
                    ViewPage_CourseName_ClassName_Locator));
                isCoursePreviewLinkDisplayed = base.IsElementPresent(By.ClassName(
                    ViewPageResource.ViewPage_CourseName_ClassName_Locator));
                //Close the window
                base.CloseBrowserWindow();
                base.IsPopUpClosed(Convert.ToInt32(ViewPageResource.
                    ViewPage_Pegasus_Window_Count_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewPage", "IsAssetToolLinkPageDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            return isCoursePreviewLinkDisplayed;
        }

        /// <summary>
        /// Navigate Inside Sub Tab Link.
        /// </summary>
        /// <param name="subtabLinkName">This is SubTabLinkName.</param>
        public void NavigateInsideSubTabLink(string subtabLinkName)
        {
            //Navigate Inside Sub Tab Link
            logger.LogMethodExit("ViewPage", "NavigateInsideSubTabLink",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Course Home Window
                this.SelectCourseHomeWindow();
                base.WaitForElement(By.PartialLinkText(subtabLinkName));
                IWebElement getPartialLinkText = 
                    base.GetWebElementPropertiesByPartialLinkText(subtabLinkName);
                //Click on Sub Tab Link Name
                base.ClickByJavaScriptExecutor(getPartialLinkText);
                base.WaitUntilWindowLoads(subtabLinkName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewPage", "NavigateInsideSubTabLink",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Home Window.
        /// </summary>
        private void SelectCourseHomeWindow()
        {
            //Select Course Home Window
            logger.LogMethodExit("ViewPage", "SelectCourseHomeWindow",
              base.isTakeScreenShotDuringEntryExit);
            //Select Course Home Window
            base.WaitUntilWindowLoads(ViewPageResource.
                ViewPage_CourseHome_Window_Name);
            base.SelectWindow(ViewPageResource.
                ViewPage_CourseHome_Window_Name);
            logger.LogMethodExit("ViewPage", "SelectCourseHomeWindow",
            base.isTakeScreenShotDuringEntryExit);
        }
    }
}
