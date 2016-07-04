using Pearson.Pegasus.TestAutomation.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;

namespace Pegasus.Pages.UI_Pages.Integration.Canvas.DirectIntegration
{
    public class CanvasUserLogin : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        protected static Logger logger = Logger.GetInstance(typeof(CanvasUserLogin));

        /// <summary>
        /// Canvas user login
        /// </summary>
        public void UserLoginToCanvas(User.UserTypeEnum userType)
        {
            User user = User.Get(userType);
            string userName = user.Name.ToString();
            string passord = user.Password.ToString();

            // Wait for window
            base.WaitUntilWindowLoads(CanvasUserLoginResource.
                CanvasUserLogin_Page_LoginPage_PageTitle);
            base.SelectWindow(CanvasUserLoginResource.
                CanvasUserLogin_Page_LoginPage_PageTitle);

            // Enter user name
            base.WaitForElement(By.Id(CanvasUserLoginResource.
                CanvasUserLogin_Page_UserName_Textbox_ID_Value));
            base.ClearTextById(CanvasUserLoginResource.
                CanvasUserLogin_Page_UserName_Textbox_ID_Value);
            base.FillTextBoxById(CanvasUserLoginResource.
                CanvasUserLogin_Page_UserName_Textbox_ID_Value, userName);

            // Enter password
            base.WaitForElement(By.Id(CanvasUserLoginResource.
                CanvasUserLogin_Page_Password_Textbox_ID_Value));
            base.ClearTextById(CanvasUserLoginResource.
                CanvasUserLogin_Page_Password_Textbox_ID_Value);
            base.FillTextBoxById(CanvasUserLoginResource.
                CanvasUserLogin_Page_Password_Textbox_ID_Value, passord);

            // Click submit button
            IWebElement getSubmitButton = base.GetWebElementPropertiesById(CanvasUserLoginResource.
                CanvasUserLogin_Page_Password_Textbox_ID_Value);
            getSubmitButton.SendKeys(Keys.Return);
        }

        /// <summary>
        /// Canvas user enter into course.
        /// </summary>
        /// <param name="courseName">This is the course name.</param>
        public void CanvasUserEnterIntoCourse(string courseName)
        {
            logger.LogMethodEntry("CanvasUserLogin", "CanvasUserEnterIntoCourse", base.IsTakeScreenShotDuringEntryExit);
            
            //Wait for window to load
            base.WaitUntilWindowLoads("User Dashboard");
            base.SelectWindow("User Dashboard");
            //Click on course
            base.WaitForElement(By.PartialLinkText(courseName));
            base.FocusOnElementByPartialLinkText(courseName);
            IWebElement getCourseName = base.GetWebElementPropertiesByPartialLinkText(courseName);
            base.ClickByJavaScriptExecutor(getCourseName);
            logger.LogMethodExit("CanvasUserLogin", "CanvasUserEnterIntoCourse", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click close link by canvas user.
        /// </summary>
        /// <param name="linkName">This is the link name.</param>
        public void CanvasUserClickCloseLink(string linkName)
        {
            // Click close link
            logger.LogMethodEntry("CanvasUserLogin", "CanvasUserClickCloseLink", base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(base.GetPageTitle);
            base.SelectWindow(base.GetPageTitle);
            base.WaitForElement(By.PartialLinkText(linkName));
            base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByLinkText(linkName));
            logger.LogMethodExit("CanvasUserLogin", "CanvasUserClickCloseLink", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Canvas user logout of canvas portal
        /// </summary>
        /// <param name="userType">This is the user type enum.</param>
        public void CanvasUserLogout()
        {
            // Canvas user logout
            logger.LogMethodEntry("CanvasUserLogin", "CanvasUserLogout", base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToDefaultPageContent();
            base.SelectDefaultWindow();
            base.WaitForElement(By.PartialLinkText("Account"),10);
            base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByPartialLinkText("Account"));
            base.SelectDefaultWindow();
            bool pre = base.IsElementPresent(By.XPath("//button[contains(text(),'Logout')]"), 10);

            base.GetWebElementPropertiesByXPath("//button[contains(text(),'Logout')]").Click();
            logger.LogMethodExit("CanvasUserLogin", "CanvasUserLogout", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}