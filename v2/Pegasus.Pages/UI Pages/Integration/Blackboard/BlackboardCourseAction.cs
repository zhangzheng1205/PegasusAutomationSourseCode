using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Pegasus.Pages.UI_Pages.Integration.Blackboard
{
    public class BlackboardCourseAction : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(MyPearsonLoginPage));

        /// <summary>
        /// Enter into blackboard course
        /// </summary>
        /// <param name="courseType">This is the course type enum.</param>
        public void EnterIntoBBCourse(Course.CourseTypeEnum courseType)
        {
            // Enter into Blackboard course
            logger.LogMethodEntry("BlackboardCourseAction", "EnterIntoBBCourse",
                base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseType);
            String courseName = course.Name.ToString();
            // Wait untill the course loads
            base.WaitForElement(By.PartialLinkText(courseName));
            base.ClickLinkByPartialLinkText(courseName);
            logger.LogMethodEntry("BlackboardCourseAction", "EnterIntoBBCourse",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the page title.
        /// </summary>
        /// <returns>Course Present Text.</returns>
        public string GetBBPageTitle()
        {
            // Course Present on Global Home Page
            logger.LogMethodEntry("BlackboardCourseAction"
                , "GetPageTitle",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized page Text
            string getPageText = string.Empty;
            try
            {
                //Set Thread To Wait
                Thread.Sleep(Convert.ToInt32(HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_ThreadSleep_Value));
                //Get Course Text
                getPageText = base.GetPageTitle;

                if (getPageText.Contains(BlackboardCourseActionResource.
                    BlackboardCourseActionPage_HomePage_Title))
                {
                    getPageText = BlackboardCourseActionResource.
                    BlackboardCourseActionPage_HomePage_Title;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("BlackboardCourseAction", "GetCoursePresentInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            return getPageText;
        }

        /// <summary>
        /// Blackboard Instructor crossover to Pegasus
        /// </summary>
        /// <param name="linkName">This is the name of the link.</param>
        public void BBInstructorSSOToPegasus(string linkName)
        {
            //Blackboard instructor crossover to pegasus
            logger.LogMethodEntry("BlackboardCourseAction", "BBInstructorSSOToPegasus",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SelectDefaultWindow();
                base.WaitUntilWindowLoads(base.GetPageTitle);
                base.SelectWindow(base.GetPageTitle);
                //Click on the link in Blackboard portal
                Thread.Sleep(2000);
                // Click link in content page
                base.WaitForElement(By.LinkText(linkName));
                base.ClickLinkByLinkText(linkName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("BlackboardCourseAction", "BBInstructorSSOToPegasus",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Gradebook window title
        /// </summary>
        /// <returns>This will return window title.</returns>
        public string getGradebookWindowTitle()
        {
            logger.LogMethodEntry("BlackboardCourseAction", "getGradebookWindowTitle", base.IsTakeScreenShotDuringEntryExit);
            string actualPageTitle = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(base.GetPageTitle);
                Thread.Sleep(10000);
                actualPageTitle = base.GetElementTextById("pageTitleText");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("BlackboardCourseAction", "getGradebookWindowTitle", base.IsTakeScreenShotDuringEntryExit);
            return actualPageTitle;
        }

        /// <summary>
        /// Blackboard Instructor select 'Pearson course tool' 
        /// from 'Manage course' dropdown.
        /// </summary>
        /// <param name="optionName">This is the option name in the dropdown.</param>
        /// <param name="dropdownName">This is the dropdown name.</param>
        public void bbInstructorSelectPearsonCourseTool(string optionName, string dropdownName)
        {
            logger.LogMethodEntry("BlackboardCourseAction", "getGradebookWindowTitle",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(base.GetPageTitle);
                base.WaitForElement(By.PartialLinkText(dropdownName));
                Thread.Sleep(1000);
                IWebElement getManageDropdown = base.GetWebElementPropertiesByLinkText(dropdownName);
                base.PerformMouseHoverByJavaScriptExecutor(getManageDropdown);
                base.WaitForElement(By.PartialLinkText(optionName));
                IWebElement getPearsonCourseTool = base.GetWebElementPropertiesByPartialLinkText(optionName);
                base.ClickByJavaScriptExecutor(getPearsonCourseTool);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("BlackboardCourseAction", "getGradebookWindowTitle",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click submit button
        /// </summary>
        public void clickSubmitButtonInBB()
        {
            // Click submit button
            logger.LogMethodEntry("BlackboardCourseAction", "clickSubmitButtonInBB", base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Name("top_Submit"));
            IWebElement getSubmitButton = base.GetWebElementPropertiesByName(
                BlackboardCourseActionResource.BlackboardCourseActionPage_SubmitButton_Id_Locator);
            base.ClickByJavaScriptExecutor(getSubmitButton);
            base.AcceptAlert();
            logger.LogMethodExit("BlackboardCourseAction", "clickSubmitButtonInBB", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Activity Status.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userLastName">This is User Last name.</param>
        /// <param name="userFirstName">This is User First Name.</param>
        /// <returns>Activity Status.</returns>
        public string GetActivityStatusBB(string activityName, string userLastName,
            string userFirstName, string userName)
        {
            //Get the Activity Status
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityStatus",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getActivityStatusGrade = string.Empty;
            string getactivityScore = string.Empty;
            try
            {
                //Get Activity Column Count
                int getUserRowCount = this.GetUserRowCount(userLastName, userFirstName, userName);
                int getActivityColumnCount = this.GetActivityColumnCount(activityName);
                getActivityColumnCount = getActivityColumnCount - 3;
                //Get User Row Count
                bool hhjd2 = base.IsElementPresent(By.XPath(string.Format(BlackboardCourseActionResource.
                    BlackboardCourseActionPage_GetActivityStatus_Xpath_Locator,
                    getUserRowCount, getActivityColumnCount)),10);
                base.WaitForElement(By.XPath(string.Format(BlackboardCourseActionResource.
                    BlackboardCourseActionPage_GetActivityStatus_Xpath_Locator,
                    getUserRowCount, getActivityColumnCount)));
                //Activity Status
                getActivityStatusGrade = base.GetElementTextByXPath(string.Format(
                    BlackboardCourseActionResource.
                    BlackboardCourseActionPage_GetActivityStatus_Xpath_Locator,
                    getUserRowCount, getActivityColumnCount)).Trim();
                getactivityScore = getActivityStatusGrade.Substring(0, 3);
                if (getactivityScore.Contains("."))
                {
                    getActivityStatusGrade = getactivityScore.Replace(".", "");
                    getactivityScore = getActivityStatusGrade.Trim();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityStatus",
            base.IsTakeScreenShotDuringEntryExit);
            return getactivityScore.Trim();
        }

        /// <summary>
        /// Get Activity Column Count.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>This is Activity Column Number.</returns>
        private int GetActivityColumnCount(string activityName)
        {
            //Expand the folder in Curriculum tab
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ExpandSubFolderInPlannerTab",
                  base.IsTakeScreenShotDuringEntryExit);
            int activityColumnNumber = Convert.ToInt32(2);
            try
            {
                int pixelValueToSrollDown = 1000;
                string getActivityName = string.Empty;
                //Getting the counts of Activity      
                base.WaitForElement(By.XPath(BlackboardCourseActionResource.
                BlackboardCourseActionPage_GetActivityCount_Xpath_Locator));
                int getActivityCount = base.GetElementCountByXPath(BlackboardCourseActionResource.
                    BlackboardCourseActionPage_GetActivityCount_Xpath_Locator);
                //Loop through to scroll the page left
                for (int scrollBarPosition = 1; scrollBarPosition <= 1000; scrollBarPosition++)
                {
                    // Loop to get the activity from the table
                    for (int columnCount = 2; columnCount <= getActivityCount; columnCount++)
                    {
                        getActivityName = base.GetTitleAttributeValueByXPath
                        (string.Format(BlackboardCourseActionResource.
                        BlackboardCourseActionPage_BB_GetActivityName_Xpath_Locator, columnCount));

                        //Check whether fetched activity name is same as expected sub folder name
                        if (getActivityName.Equals(activityName))
                        {
                            activityColumnNumber = columnCount;
                            break;
                        }
                    }
                    if (getActivityName.Equals(activityName))
                    {
                        break;
                    }
                    IWebElement getscroll = base.GetWebElementPropertiesByXPath(
                        BlackboardCourseActionResource.BlackboardCourseActionPage_Scrollbar_Xpath_Locator);
                    IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
                    pixelValueToSrollDown = pixelValueToSrollDown + 100;
                    js.ExecuteScript("arguments[0].scrollLeft = arguments[1];", getscroll, pixelValueToSrollDown);
                    Thread.Sleep(2000);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ExpandSubFolderInPlannerTab",
                 base.IsTakeScreenShotDuringEntryExit);
            return activityColumnNumber;
        }

        /// <summary>
        /// Get User Row Count.
        /// </summary>
        /// <param name="userLastName">This is User Last Name.</param>
        /// <param name="userFirstName">This is User First Name.</param>
        /// <returns>This is User Row Number.</returns>
        private int GetUserRowCount(string userLastName, string userFirstName, string userName)
        {
            //Get User Row Count
            logger.LogMethodEntry("GBInstructorUXPage", "GetUserRowCount",
           base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            int userRowNumber = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Count_Value);
            base.WaitForElement(By.XPath(BlackboardCourseActionResource.
                BlackboardCourseActionPage_BBGradbook_Rowcount_Xpath_Locator));
            //Get User Count
            int getUserCount = base.GetElementCountByXPath(BlackboardCourseActionResource.
                BlackboardCourseActionPage_BBGradbook_Rowcount_Xpath_Locator);
            for (int userRowCount = Convert.ToInt32(GBInstructorUXPageResource.
                 GBInstructorUX_Page_Initial_Value); userRowCount <= getUserCount;
                 userRowCount++)
            {
                base.WaitForElement(By.XPath(string.Format(BlackboardCourseActionResource.
                    BlackboardCourseActionPage_BBGradbook_getUsername_Xpath_Locator, userRowCount)));
                //Get user Name
                string getUserName = base.GetTitleAttributeValueByXPath(
                    string.Format(BlackboardCourseActionResource.
                    BlackboardCourseActionPage_BBGradbook_getUsername_Xpath_Locator, userRowCount));
                if (getUserName.Equals(userName.ToLower()))
                {
                    userRowNumber = userRowCount;
                    break;
                }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetUserRowCount",
           base.IsTakeScreenShotDuringEntryExit);
            return userRowNumber;
        }

        /// <summary>
        /// Click Sign out link on the page.
        /// </summary>
        /// <param name="linkSignOut">This is SingOut Link.</param>
        public void SignOutByHigherEdUsers(String linkSignOut)
        {
            //Complete SingOut Process
            logger.LogMethodEntry("AdminToolPage", "SignOutByHigherEdUsers",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Default Window           
                base.SelectWindow(base.GetPageTitle);
                //Wait For Element
                base.WaitForElement((By.PartialLinkText(linkSignOut)));
                //Get Element Property
                IWebElement getLinkProperty = base.
                    GetWebElementPropertiesByPartialLinkText(linkSignOut);
                //Click SignOut Link
                base.ClickByJavaScriptExecutor(getLinkProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AdminToolPage", "SignOutByHigherEdUsers",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}