using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.User;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Search Users Page Actions
    /// </summary>
    public class SearchUsersPage: BasePage 
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(SearchUsersPage));

        /// <summary>
        /// Searching User In The Left Frame
        /// </summary>
        /// <param name="username">This Is UserName</param>
        public void SearchUser(string username)
        {
            //Searching User In The Left Frame
            logger.LogMethodEntry("SearchUsersPage", "SearchUser", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch To Left Frame
                base.SwitchToIFrame(SearchUsersPageResource.
                    SearchUsers_Page_leftFrame_Id_Locator);
                base.WaitForElement(By.Id(SearchUsersPageResource.
                    SearchUsers_Page_UserDetailTextBox_Id_Locator));
                //Enter The UserName In the Search Box
                base.GetWebElementPropertiesById(SearchUsersPageResource.
                    SearchUsers_Page_UserDetailTextBox_Id_Locator).SendKeys(username);
                // Click On The Search Image
                base.WaitForElement(By.XPath(SearchUsersPageResource.
                    SearchUsers_Page_ImageCourseSearch_Xpath_Locator));
                IWebElement getSearchButton = base.GetWebElementPropertiesByXPath
                    (SearchUsersPageResource.
                    SearchUsers_Page_ImageCourseSearch_Xpath_Locator);
                //Get Web Element 
                base.ClickByJavaScriptExecutor(getSearchButton);
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
           logger.LogMethodExit("SearchUsersPage", "SearchUser",
               base.IsTakeScreenShotDuringEntryExit);            
        }
    }
}
