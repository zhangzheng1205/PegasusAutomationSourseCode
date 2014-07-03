using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Integration.eCollege;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using System.Threading;
using System.Diagnostics;
using System.Configuration;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the Home Page action by teacher.
    /// </summary>
    public class DotNextLaunchPage : BasePage
    {
        /// <summary>
        /// The Static instance of the Logger for the class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(DotNextLaunchPage));

        /// <summary>
        /// This is the Timeout variable called from AppSettings.
        /// </summary>
        private int getAssignedToCopyWaitTime = Convert.ToInt32(
           ConfigurationManager.AppSettings[DotNextLaunchPageResource.
           DotNextLaunchPage_AssignedToCopyInterval_Key_Name]);

        /// <summary>
        /// Click on left frame options.
        /// </summary>
        /// <param name="optionName">This is left frame option name.</param>
        public void ClickOnLeftFrameOption(String optionName)
        {
            //Click on left frame options
            logger.LogMethodEntry("DotNextLaunchPage", "ClickOnLeftFrameOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                SelectDefaultWindow();
                //Switch to frame
                this.SelectMainFrame();
                //Switch to sub frame
                base.WaitForElement(By.Name(DotNextLaunchPageResource.
                    DotNextLaunchPage_Left_SubFrame_Id_Locator));
                base.SwitchToIFrame(DotNextLaunchPageResource.
                    DotNextLaunchPage_Left_SubFrame_Id_Locator);
                //Click on Author link        
                IWebElement getAuthorLinkProperty = 
                    base.GetWebElementPropertiesById(optionName);
                base.ClickByJavaScriptExecutor(getAuthorLinkProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DotNextLaunchPage", "ClickOnLeftFrameOption",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on HTML link in Course Information.
        /// And Adding .next course link.
        /// </summary>
        public void ClickOnHtmlLinkInCourseIntroduction()
        {
            //Enter html link in text area
            logger.LogMethodEntry("DotNextLaunchPage", "ClickOnHtmlLinkInCourseIntroduction",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                SelectDefaultWindow();
                //Switch to frame
                this.SelectMainFrame();
                //Switch to sub frame
                SelectLeftFrame();
                //Click on HTML link
                IWebElement htmlLink = base.GetWebElementPropertiesByPartialLinkText
                    (DotNextLaunchPageResource.
                    DotNextLaunchPage_CourseIntroduction_HTML_PartialLink);
                ClickByJavaScriptExecutor(htmlLink);
                //Enter Course link
                IWebElement getNextCourse = base.GetWebElementPropertiesByXPath
                    (DotNextLaunchPageResource.DotNextLaunchPage_TextArea_Xpath);
                getNextCourse.SendKeys(DotNextLaunchPageResource.
                    DotNextLaunchPage_RootURL_For_Next_Course);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DotNextLaunchPage", "ClickOnHtmlLinkInCourseIntroduction",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on SaveChange Button.
        /// </summary>
        public void ClickOnSaveChangeButton()
        {
            //Click on SaveChange button 
            logger.LogMethodEntry("DotNextLaunchPage", "ClickOnSaveChangeButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                SelectDefaultWindow();
                //Select main frame
                this.SelectMainFrame();
                //Switch to Content sub frame
                this.SelectSubContentFrame();
                //Click on Save Changes button
                IWebElement clickSaveChangesButton = base.GetWebElementPropertiesByXPath
                    (DotNextLaunchPageResource.
                      DotNextLaunchPage_CourseIntroduction_SaveChangesButton_Xpath);
                ClickByJavaScriptExecutor(clickSaveChangesButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DotNextLaunchPage", "ClickOnSaveChangeButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verfication of Enter Course Link.
        /// </summary>
        /// <param name="enterCourseLink">This is enter course link.</param>
        public string VerficationOfCourseLink()
        {
            //Verify the Enter Course Link Text
            logger.LogMethodEntry("DotNextLaunchPage", "VerficationOfCourseLink",
                base.isTakeScreenShotDuringEntryExit);
            string getEnterCourseLinkTitle = null;
            try
            {
                SelectDefaultWindow();
                //Select Main frame
                SelectMainFrame();
                //Select sub content frame
                SelectSubContentFrame();
                //Get text of Enter course link
                getEnterCourseLinkTitle = base.GetElementTextByXPath
                    (DotNextLaunchPageResource.
                    DotNextLaunchPage_CourseLink_Text_Xpath);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DotNextLaunchPage", "VerficationOfCourseLink",
                  base.isTakeScreenShotDuringEntryExit);
            return getEnterCourseLinkTitle;
        }

        /// <summary>
        /// Select sub content frame.
        /// </summary>
        private void SelectSubContentFrame()
        {
            //Switch to Content sub frame
            logger.LogMethodEntry("DotNextLaunchPage", "SelectSubContentFrame",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(DotNextLaunchPageResource.
                DotNextLaunchPage_Left_SubContentFrame_Id_Locator));
            base.SwitchToIFrame(DotNextLaunchPageResource.
                DotNextLaunchPage_Left_SubContentFrame_Id_Locator);
            logger.LogMethodExit("DotNextLaunchPage", "SelectSubContentFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// select main frame.
        /// </summary>
        private void SelectMainFrame()
        {
            //switch to mail frame
            logger.LogMethodEntry("DotNextLaunchPage", "SelectMainFrame",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(DotNextLaunchPageResource.
                DotNextLaunchPage_Left_MainFrame_Id_Locator));
            base.SwitchToIFrame(DotNextLaunchPageResource.
                DotNextLaunchPage_Left_MainFrame_Id_Locator);
            logger.LogMethodExit("DotNextLaunchPage", "SelectMainFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select left frame.
        /// </summary>
        private void SelectLeftFrame()
        {
            //Select Left frame
            logger.LogMethodEntry("DotNextLaunchPage", "SelectLeftFrame",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(DotNextLaunchPageResource.
                DotNextLaunchPage_Left_SubContentFrame_Id_Locator));
            base.SwitchToIFrame(DotNextLaunchPageResource.
                DotNextLaunchPage_Left_SubContentFrame_Id_Locator);
            logger.LogMethodExit("DotNextLaunchPage", "SelectLeftFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selct top left frame.
        /// </summary>
        private void SelectLeftTopFrame()
        {
            //Switch to LeftTop frame
            logger.LogMethodEntry("DotNextLaunchPage", "SelectLeftTopFrame",
              base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(DotNextLaunchPageResource.
                DotNextLaunchPage_Top_SubFrame_Id_Locator));
            base.SwitchToIFrame(DotNextLaunchPageResource.
                DotNextLaunchPage_Top_SubFrame_Id_Locator);
            logger.LogMethodExit("DotNextLaunchPage", "SelectLeftTopFrame",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on left bottom button.
        /// </summary>
        /// <param name="buttonBottomFrame">This is name of bottom button.</param>
        public void ClickOnLeftBottomButton(
            string buttonBottomFrame)
        {
            //Click on LeftBottom button
            logger.LogMethodEntry("DotNextLaunchPage", "ClickOnLeftBottoButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select default window
                SelectDefaultWindow();
                this.SelectMainFrame();
                //this.SelectLeftFrame();
                base.WaitForElement(By.Id(DotNextLaunchPageResource.
                    DotNextLaunchPage_Left_SubFrame_Id_Locator));
                base.SwitchToIFrame(DotNextLaunchPageResource.
                    DotNextLaunchPage_Left_SubFrame_Id_Locator);
                //Click on ExitCourse button
                base.WaitForElement(By.Id(DotNextLaunchPageResource.
                    DotNextLaunchPage_CourseHome_Left_ExitCourse_Button_Id_Locator));
                //Get property of ExitCourse Button
                IWebElement getPropertyofExitCourseButton = base.
                    GetWebElementPropertiesById(DotNextLaunchPageResource.
                    DotNextLaunchPage_CourseHome_Left_ExitCourse_Button_Id_Locator);
                //Click on ExitCourse Button
                base.ClickByJavaScriptExecutor(getPropertyofExitCourseButton);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DotNextLaunchPage", "ClickOnLeftBottoButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Enter HED Course link
        /// </summary>
        public void ClickOnEnterCourseLink()
        {
            //Click on Enter HED Course link
            logger.LogMethodEntry("DotNextLaunchPage", "ClickOnEnterCourseLink",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select default window
                base.SelectDefaultWindow();
                //Switch to Main Frame
                base.WaitForElement(By.Id(DotNextLaunchPageResource.
                DotNextLaunchPage_Main_Frame_ID_locator));
                base.SwitchToIFrame(DotNextLaunchPageResource.
                DotNextLaunchPage_Main_Frame_ID_locator);
                //Switch to Content Frame
                base.WaitForElement(By.Id(DotNextLaunchPageResource.
                DotNextLaunchPage_Content_Frame_ID_locator));
                base.SwitchToIFrame(DotNextLaunchPageResource.
                DotNextLaunchPage_Content_Frame_ID_locator);
                //Click on Enter HED Course Link
                base.WaitForElement(By.PartialLinkText(DotNextLaunchPageResource.
                    DotNextLaunchPage_EnterCourseLink_PartialText_locator));
                IWebElement getPartialTextElementProperty = 
                    base.GetWebElementPropertiesByPartialLinkText
                                             (DotNextLaunchPageResource.
                    DotNextLaunchPage_EnterCourseLink_PartialText_locator);
                base.ClickByJavaScriptExecutor(getPartialTextElementProperty);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DotNextLaunchPage", "ClickOnEnterCourseLink",
            base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Switch to Course is not yet ready. 
        /// Please try again in a few minutes page after 
        /// launching ECollege course.
        /// </summary>
        /// <param name="pageName">This is Page name</param>
        public void SelectExpectedPage(String pageName)
        {
            //Switch to expected page
            logger.LogMethodEntry("DotNextLaunchPage", "SelectExpectedPage",
            base.isTakeScreenShotDuringEntryExit);

            try
            {
                //Wait for expected window for 10 second
                bool isPopupPresent = base.IsPopupPresent(pageName,
                    Convert.ToInt32(DotNextLaunchPageResource.
                    DotNextLaunchPage_Window_Load_Custome_WaitTime));
                //Validate the existance of expected window
                if (isPopupPresent)
                {
                    //Wait Page Get Switched Successfully
                    base.WaitUntilPageGetSwitchedSuccessfully(pageName);
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    while (stopWatch.Elapsed.Minutes < getAssignedToCopyWaitTime)
                    {
                        isPopupPresent = base.IsPopupPresent(pageName,
                       Convert.ToInt32(DotNextLaunchPageResource.
                       DotNextLaunchPage_Window_Load_Custome_WaitTime));
                        if (isPopupPresent)
                        {
                            //Close course not ready window
                            this.ClickOnCloseButtonOnCourseNotReadyPage(pageName);
                            if (base.IsPopUpClosed(2))
                            {
                                //Again launch course
                                this.ClickOnEnterCourseLink();
                            }
                        }
                        else
                        {
                            break; //Break If Pop Up Not Present
                        }
                    }
                    stopWatch.Stop();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DotNextLaunchPage", "SelectExpectedPage",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click on Close Button On CourseNotReadyPage.
        /// </summary>
        private void ClickOnCloseButtonOnCourseNotReadyPage(
            String pageName)
        {
            //Click on Close Button
            logger.LogMethodEntry("DotNextLaunchPage", "ClickOnCloseButtonOnCourseNotReadyPage",
                base.isTakeScreenShotDuringEntryExit);
            //Switch to window
            base.SelectWindow(pageName);
            Thread.Sleep(Convert.ToInt16(DotNextLaunchPageResource.
                DotNextLaunchPage_SleepTime));
            //Click on close window
            base.CloseBrowserWindow();
            logger.LogMethodExit("DotNextLaunchPage", "ClickOnCloseButtonOnCourseNotReadyPage",
                base.isTakeScreenShotDuringEntryExit);
        }

    }
}
