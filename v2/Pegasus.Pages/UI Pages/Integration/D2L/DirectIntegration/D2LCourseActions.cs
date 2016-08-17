using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;

namespace Pegasus.Pages.UI_Pages.Integration.D2L.DirectIntegration
{
    public class D2LCourseActions : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(D2LCourseActions));

        public void EnterIntoD2LCourse(Course.CourseTypeEnum courseType, User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("D2LCourseActions", "EnterIntoD2LCourse", base.IsTakeScreenShotDuringEntryExit);
        
            // Get the course name
            Course course = Course.Get(courseType);
            string courseName = course.Name.ToString();

            // Based on user type click on the course 
            switch (userType)
            {
                case User.UserTypeEnum.D2LDirectTeacher:
                    this.D2LUserEnterIntoCourse(courseType);
                    break;
                case User.UserTypeEnum.D2LDirectStudent:
                   // base.WaitUntilWindowLoads(base.GetPageTitle);

                    //Select the course and Click
                    base.WaitForElement(By.XPath(D2LCourseActionsResource.
                        D2LCourseAction_Page_CourseSelector_Xpath_Value));
                    base.ClickLinkByXPath(D2LCourseActionsResource.
                        D2LCourseAction_Page_CourseSelector_Xpath_Value);

                    base.WaitForElement(By.PartialLinkText(courseName));
                    base.ClickLinkByPartialLinkText(courseName);
                    break;
            }
            logger.LogMethodExit("D2LCourseActions", "EnterIntoD2LCourse", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select home page
        /// </summary>
        private void SelectHomePageWindow()
        {
            // Wait for windowload and select the window
            base.SwitchToPartialWindowTitle("Homepage");
        }

        /// <summary>
        /// D2L user enter into the course
        /// </summary>
        /// <param name="courseType">This is the course type enum.</param>
        protected void D2LUserEnterIntoCourse(Course.CourseTypeEnum courseType)
        {
            logger.LogMethodEntry("D2LCourseActions", "D2LUserEnterIntoCourse", base.IsTakeScreenShotDuringEntryExit);
            // Wait for home page to load and select the window
          

            // Get the course name
            Course course = Course.Get(courseType);
            string courseName = course.Name.ToString();

            // Wait for course title to load
            base.WaitForElement(By.PartialLinkText(courseName));

            // Click on the course name
            IWebElement getCourseName = base.GetWebElementPropertiesByPartialLinkText(courseName);
            base.PerformMouseClickAction(getCourseName);

            logger.LogMethodExit("D2LCourseActions", "D2LUserEnterIntoCourse", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to specified tab in D2L
        /// </summary>
        /// <param name="tabName">This is the tab name.</param>
        public void ClickTabInD2L(string tabName)
        {
            logger.LogMethodEntry("D2LCourseActions", "ClickTabInD2L", base.IsTakeScreenShotDuringEntryExit);
            // Click on tab in D2L page
            base.WaitForElement(By.PartialLinkText(tabName));
            IWebElement getTabName = base.GetWebElementPropertiesByPartialLinkText(tabName);
            base.PerformMouseClickAction(getTabName);
       

            logger.LogMethodExit("D2LCourseActions", "ClickTabInD2L", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click link in Content tab
        /// </summary>
        /// <param name="tabName">This is the link title.</param>
        public void ClicklinkInContentTab(string linkName)
        {
            logger.LogMethodEntry("D2LCourseActions", "ClicklinkInContentTab", base.IsTakeScreenShotDuringEntryExit);
           
            base.SwitchToPartialWindowTitle("Table of Contents");

            // Click link in content page
            base.WaitForElement(By.PartialLinkText(linkName));
            IWebElement clickFileIcon = base.GetWebElementPropertiesByLinkText(linkName);
            base.PerformMouseClickAction(clickFileIcon);

            logger.LogMethodExit("D2LCourseActions", "ClicklinkInContentTab", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// SSO to pegasus by click on the link in D2L portal
        /// </summary>
        /// <param name="tabName">This is the link title.</param>
        public void ClickSSOlinkInContentTab(string linkName)
        {
            logger.LogMethodEntry("D2LCourseActions", "ClicklinkInContentTab", base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToPartialWindowTitle("Pegasus Tools");

            bool jjkk = base.IsElementPresent(By.XPath(D2LCourseActionsResource.
                D2LCourseAction_Page_D2LIframe_Xpath_Value), 10);

            base.WaitForElement(By.XPath(D2LCourseActionsResource.
                D2LCourseAction_Page_D2LIframe_Xpath_Value));
            base.SwitchToIFrameByIndex(0);

            // Click link in content page
            base.WaitForElement(By.PartialLinkText(linkName));
            IWebElement clickFileIcon = base.GetWebElementPropertiesByLinkText(linkName);
            base.ClickByJavaScriptExecutor(clickFileIcon);

            logger.LogMethodExit("D2LCourseActions", "ClicklinkInContentTab", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of gradebook page for teacher
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <returns>This will return the icon existance status.</returns>
        public bool GetGradeBookExistance(string pageName, User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("D2LCourseActions", "GetGradeBookExistance",
                base.IsTakeScreenShotDuringEntryExit);
            bool pageStatus = false;
            base.SwitchToPartialWindowTitle("Pegasus Tools");

            switch (pageName)
            {
                case "Gradebook":
                    if (userType == User.UserTypeEnum.D2LDirectTeacher)
                    {
                        base.WaitForElement(By.XPath(D2LCourseActionsResource.
                D2LCourseAction_Page_D2LIframe_Xpath_Value));
                        base.SwitchToIFrameByIndex(0);
                        pageStatus = base.IsElementPresent(By.PartialLinkText("Gradebook"), 5);
                    }
                    else
                    {
                        base.WaitForElement(By.XPath(D2LCourseActionsResource.
                D2LCourseAction_Page_D2LIframe_Xpath_Value));
                        base.SwitchToIFrameByIndex(0);
                        pageStatus = base.IsElementPresent(By.ClassName(D2LCourseActionsResource.
                            D2LCourseAction_Page_Pegasus_GB_Classname), 5);
                    }
                    break;

                case "View All Course Materials":
                    base.WaitForElement(By.XPath(D2LCourseActionsResource.
                D2LCourseAction_Page_D2LIframe_Xpath_Value));
                    base.SwitchToIFrameByIndex(0);
                    base.SwitchToIFrameById("ifrmCoursePreview");
                    pageStatus = base.IsElementPresent(By.Id("_ctl0_InnerPageContent_divViewHedaer"), 5);
                    break;
            }
            base.SwitchToDefaultPageContent();
            logger.LogMethodExit("D2LCourseActions", "GetGradeBookExistance", 
                base.IsTakeScreenShotDuringEntryExit);
            return pageStatus;
        }

        /// <summary>
        /// To signout from D2L.
        /// </summary>
        public void D2LSignOut(User.UserTypeEnum userType)
        {
            //To signout from D2L
            logger.LogMethodEntry("D2LCourseActions", "D2LSignOut",
              base.IsTakeScreenShotDuringEntryExit);
            //Click on the User name to get Logout menu
            base.SwitchToPartialWindowTitle("Pegasus Tools");
            User user = User.Get(userType);
            string userName = user.FirstName + " " + user.LastName;
            bool pres = base.IsElementPresent(By.XPath(string.
                Format(D2LCourseActionsResource.
                D2LCourseAction_Page_UserNameDropDown_Xpath_Value,userName)), 10);
            IWebElement userNameMenu = base.GetWebElementPropertiesByXPath
                (string.Format(D2LCourseActionsResource.
                D2LCourseAction_Page_UserNameDropDown_Xpath_Value, userName));
            base.ClickByJavaScriptExecutor(userNameMenu);
            IWebElement logoutLink = base.GetWebElementPropertiesByLinkText
                (D2LCourseActionsResource.
                D2LCourseAction_Page_LogOut_LinkText_Value);
            base.ClickByJavaScriptExecutor(logoutLink);
            logger.LogMethodExit("D2LCourseActions", "D2LSignOut",
               base.IsTakeScreenShotDuringEntryExit);

        }
    }
}