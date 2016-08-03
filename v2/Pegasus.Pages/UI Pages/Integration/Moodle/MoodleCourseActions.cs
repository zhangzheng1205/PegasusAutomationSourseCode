using Pearson.Pegasus.TestAutomation.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using System.Diagnostics;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;

namespace Pegasus.Pages.UI_Pages.Integration.Moodle
{
    public class MoodleCourseActions : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(MoodleCourseActions));

        /// <summary>
        /// Moodle user enter into Moodle kiosk course
        /// </summary>
        /// <param name="courseType">This is the course type enum.</param>
        public void EnterIntoMoodleKioskCourse(Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("Moodle", "EnterIntoMoodleKioskCourse", base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseType);
            string courseName = course.Name.ToString();
            base.WaitForElement(By.PartialLinkText(MoodleCourseActionsResource.
                MoodleCourseActionsPage_CourseSelector_Text_Value));
            // Click course based on the course name
            base.WaitForElement(By.PartialLinkText(courseName));
            IWebElement courseNameText = base.GetWebElementPropertiesByPartialLinkText(courseName);
            base.ClickByJavaScriptExecutor(courseNameText);
            Logger.LogMethodExit("Moodle", "EnterIntoMoodleKioskCourse", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait for window to load
        /// </summary>
        private void waitForWindowToLoad()
        {
            // Wait for window to load
            Logger.LogMethodEntry("MoodleCourseActions", "waitForWindowToLoad", base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(base.GetPageTitle);
            base.SelectWindow(base.GetPageTitle);
            Logger.LogMethodExit("MoodleCourseActions", "waitForWindowToLoad", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click 'MyLab & Mastering Tools' link in moodle page
        /// </summary>
        /// <param name="optionName"></param>
        public void clickMyLabAndMasteringTools(string linkName)
        {
            Logger.LogMethodEntry("Moodle", "clickMyLabAndMasteringTools", base.IsTakeScreenShotDuringEntryExit);
            // wait for window to load
            waitForWindowToLoad();
            // wait for 'MyLab & Mastering Tools' and click on the link
            base.WaitForElement(By.PartialLinkText(linkName));
            IWebElement getMyLabMasteringToolLink = base.GetWebElementPropertiesByPartialLinkText(linkName);
            base.ClickByJavaScriptExecutor(getMyLabMasteringToolLink);
            Logger.LogMethodExit("Moodle", "clickMyLabAndMasteringTools", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Pegasus SSO link in MMND embaded page
        /// </summary>
        /// <param name="optionName">This is the option name.</param>
        /// <param name="userType">This is the user type enum.</param>
        public void ssoToPegasusFromMMND(string optionName, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("Moodle", "ssoToPegasusFromMMND", base.IsTakeScreenShotDuringEntryExit);
            // wait for window to load
            Thread.Sleep(20000);
            waitForWindowToLoad();
            base.WaitForElement(By.Id(MoodleCourseActionsResource.
                MoodleCourseActionsPage_ContentFrame_Id_Locator));
            switch (userType)
            {
                // Perform user action based on the user type 
                case User.UserTypeEnum.MoodleKioskTeacher:
                    this.instructorClickSSOLink(optionName);
                    break;

                case User.UserTypeEnum.MoodleKioskStudent:
                    this.instructorClickSSOLink(optionName);
                    break;
            }
            Logger.LogMethodExit("Moodle", "ssoToPegasusFromMMND", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Instrutor click on SSO link in 
        /// </summary>
        /// <param name="optionName"></param>
        protected void instructorClickSSOLink(string optionName)
        {
            Logger.LogMethodEntry("Moodle", "instructorClickSSOLink", base.IsTakeScreenShotDuringEntryExit);
            // wait for window to load
            waitForWindowToLoad();
            base.WaitForElement(By.Id(MoodleCourseActionsResource.
                MoodleCourseActionsPage_ContentFrame_Id_Locator));
            switch (optionName)
            {
                case "MyPsychLab Gradebook":
                    // Execute the autoIT exe file and click on gradebook link
                    Thread.Sleep(20000);
                    Process.Start((AutomationConfigurationManager.TestDataPath
                                       + MoodleCourseActionsResource.
                                       MoodleCourseActionsPage_AutoIt_InstructorGB_ExeFile_Path).Replace("file:\\", ""));
                    break;

                case "MMND MyPsychLab Gradebook":
                    // Execute the autoIT exe file and click on gradebook link
                    Thread.Sleep(20000);
                    Process.Start((AutomationConfigurationManager.TestDataPath
                                       + MoodleCourseActionsResource.
                                       MoodleCourseActionsPage_AutoIt_MMNDInstructorGB_ExeFile_Path).Replace("file:\\", ""));
                    break;
            }
            Logger.LogMethodExit("Moodle", "ssoToPegasusFromMMND", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Student click on SSO link in 
        /// </summary>
        /// <param name="optionName"></param>
        protected void studentClickSSOLink(string optionName)
        {
            Logger.LogMethodEntry("Moodle", "instructorClickSSOLink", base.IsTakeScreenShotDuringEntryExit);
            // wait for window to load
            waitForWindowToLoad();
            base.WaitForElement(By.Id(MoodleCourseActionsResource.
                MoodleCourseActionsPage_ContentFrame_Id_Locator));
            switch (optionName)
            {
                case "MyPsychLab Assignment Calendar":
                    // Click on Gradebook link using autoit
                    Process.Start((AutomationConfigurationManager.TestDataPath
                                       + "\\TestData\\GBClick.exe").Replace("file:\\", ""));
                    break;

                case "MyPsychLab Course Home":
                    // Click on Gradebook link using autoit
                    Process.Start((AutomationConfigurationManager.TestDataPath
                                       + "\\TestData\\GBClick.exe").Replace("file:\\", ""));
                    break;
            }
            Logger.LogMethodExit("Moodle", "ssoToPegasusFromMMND", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get course name form moodle page.
        /// </summary>
        /// <returns></returns>
        public string GetCourseName()
        {
            string courseName = string.Empty;
            base.SwitchToDefaultWindow();
            base.WaitUntilWindowLoads(base.GetPageTitle);
            base.SelectWindow(base.GetPageTitle);
            // Get the text on the current page
            courseName = base.GetElementTextByClassName(MoodleCourseActionsResource.
                MoodleCourseActionsPage_MainHeader_Class_Name);
            return courseName;
        }

        /// <summary>
        /// Get course name form moodle page.
        /// </summary>
        /// <returns></returns>
        public Boolean GetPageExistanceStatus()
        {
            // Get the page existance status
            bool getPageExistanceStatus = false;
            base.WaitUntilWindowLoads(base.GetPageTitle);
            base.SelectWindow(base.GetPageTitle);
            getPageExistanceStatus = base.IsElementPresent(By.PartialLinkText(MoodleCourseActionsResource.
                MoodleCourseActionsPage_Login_PartialLinkText_Value), 2);
            return getPageExistanceStatus;
        }

        /// <summary>
        /// Get the page name of Grader Report Page
        /// </summary>
        /// <returns>This wil return the page name.</returns>
        public string getGraderReportPage()
        {
            Logger.LogMethodEntry("CourseHomePage", "getGraderReportPage", base.IsTakeScreenShotDuringEntryExit);
            string pageName = string.Empty;
            waitForWindowToLoad();
            base.WaitForElement(By.ClassName("main"));
            pageName = base.GetElementTextByClassName("main");
            Logger.LogMethodExit("CourseHomePage", "getGraderReportPage", base.IsTakeScreenShotDuringEntryExit);
            return pageName;
        }

        /// <summary>
        /// Select option from the Grader report dropdown
        /// </summary>
        /// <param name="optionName">This is the option name.</param>
        public void SelectOptionFromGraderReport(string optionName)
        {
            Logger.LogMethodEntry("CourseHomePage", "SelectOptionFromGraderReport", base.IsTakeScreenShotDuringEntryExit);
            waitForWindowToLoad();
            base.WaitForElement(By.Name("jump"));
            base.PerformClickAndHoldAction(base.GetWebElementPropertiesByName("jump"));
            bool asdq3 = base.IsElementPresent(By.XPath("//select[@name ='jump']/optgroup[5]/option[3]"), 10);
            base.PerformMouseClickAction(base.GetWebElementPropertiesByXPath("//select[@name ='jump']/optgroup[5]/option[3]"));
            Logger.LogMethodExit("CourseHomePage", "SelectOptionFromGraderReport", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click 'Sync MyLab Mastering Grades' button
        /// </summary>
        public void ClickSyncMyLabMasteringGradesButton()
        {
            Logger.LogMethodEntry("MoodleCourseActions", "ClickSyncMyLabMasteringGradesButton", base.IsTakeScreenShotDuringEntryExit);
            waitForWindowToLoad();
            base.WaitForElement(By.Id("id_submitbutton"));
            base.ClickButtonById("id_submitbutton");
            Logger.LogMethodExit("MoodleCourseActions", "ClickSyncMyLabMasteringGradesButton", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}