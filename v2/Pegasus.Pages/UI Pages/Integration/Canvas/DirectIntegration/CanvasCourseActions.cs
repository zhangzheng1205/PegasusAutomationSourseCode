using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;
using System.Globalization;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pegasus.Pages.UI_Pages.Integration.Canvas.DirectIntegration
{
    public class CanvasCourseActions : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        protected static Logger logger = Logger.GetInstance(typeof(CanvasCourseActions));

        /// <summary>
        /// Canvas user select link in the course landing page.
        /// </summary>
        /// <param name="linkName">This is the link name.</param>
        /// <param name="courseName">This is the course name.</param>
        /// <param name="userType">This is the user type enum.</param>
        public void SelectTabInCourseLandingPage(string linkName, string courseName, User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("CanvasCourseActions", "SelectTabInCourseLandingPage", base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(1000);
            base.WaitUntilWindowLoads(base.GetPageTitle);
            base.SelectWindow(base.GetPageTitle);

            switch (userType)
            {
                case User.UserTypeEnum.CanvasDirectTeacher:
                case User.UserTypeEnum.CanvasDirectStudent:
                    Thread.Sleep(1000);
                    base.FocusOnElementByPartialLinkText(linkName);
                    base.WaitForElement(By.PartialLinkText(linkName));
                    base.ClickLinkByPartialLinkText(linkName);
                    break;
            }
            logger.LogMethodExit("CanvasCourseActions", "SelectTabInCourseLandingPage", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Canvas user crossover to pegasus.
        /// </summary>
        /// <param name="linkName">This is the link name.</param>
        /// <param name="userType">This is the user type enum.</param>
        public void CrossOverToPegasus(string linkName, User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("CanvasCourseActions", "CrossOverToPegasus", base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(base.GetPageTitle);
            base.SelectWindow(base.GetPageTitle);

            switch (userType)
            {

                case User.UserTypeEnum.CanvasDirectTeacher:
                case User.UserTypeEnum.CanvasDirectStudent:
                    Thread.Sleep(1000);
                    base.FocusOnElementByPartialLinkText(linkName);
                    base.WaitForElement(By.PartialLinkText(linkName));
                    base.ClickLinkByPartialLinkText(linkName);
                    base.WaitUntilWindowLoads(base.GetPageTitle);
                    bool isButtonExist = base.IsElementPresent(By.ClassName(CanvasCourseActionsResource.
                        CanvasCourseAction_Page_CanvasPage_PegasusSSO_Button_ClassName_Value), 5);
                    if (isButtonExist.Equals(true))
                    {
                        Thread.Sleep(1000);
                        IWebElement getButton = base.GetWebElementPropertiesByClassName(CanvasCourseActionsResource.
                        CanvasCourseAction_Page_CanvasPage_PegasusSSO_Button_ClassName_Value);
                        base.ClickByJavaScriptExecutor(getButton);
                    }
                    break;
            }
            logger.LogMethodEntry("CanvasCourseActions", "CrossOverToPegasus", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of gradebook page for teacher
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <returns>This will return the icon existance status.</returns>
        public bool GetGradeBookExistance(string pageName, User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("CanvasCourseActions", "GetGradeBookExistance",
                base.IsTakeScreenShotDuringEntryExit);
            bool pageStatus = false;
            base.WaitUntilWindowLoads(base.GetPageTitle);
            base.SelectWindow(base.GetPageTitle);
            
            // Switch based on the Page name
            switch (pageName)
            {
                case "Gradebook":
                    if (userType == User.UserTypeEnum.CanvasDirectTeacher)
                    {
                        // Switch to iframe
                        base.SwitchToIFrameById(CanvasCourseActionsResource.
                            CanvasCourseAction_Page_GradeBook_Iframe_ID_Value);
                        // Get the status of Grade page existance
                        pageStatus = base.IsElementPresent(By.Id(CanvasCourseActionsResource.
                            CanvasCourseAction_Page_INSGradeBook_Header_ID_Value), 5);
                    }
                    else
                    {
                        // Switch to iframe
                        base.SwitchToIFrameById(CanvasCourseActionsResource.
                            CanvasCourseAction_Page_GradeBook_Iframe_ID_Value);
                        // Get the status of Grade page existance
                        pageStatus = base.IsElementPresent(By.ClassName(CanvasCourseActionsResource.
                            CanvasCourseAction_Page_STUGradeBook_GradeTitle_Class_Name), 5);
                    }
                    break;

                case "View All Course Materials":
                    base.WaitForElement(By.XPath("//iframe[contains(@class,'d2l-iframe')]"));
                    base.SwitchToIFrameByIndex(0);
                    base.SwitchToIFrameById("ifrmCoursePreview");
                    pageStatus = base.IsElementPresent(By.Id("_ctl0_InnerPageContent_divViewHedaer"), 5);
                    break;
            }

            logger.LogMethodExit("CanvasCourseActions", "GetGradeBookExistance", base.IsTakeScreenShotDuringEntryExit);
            return pageStatus;
        }

    }
}