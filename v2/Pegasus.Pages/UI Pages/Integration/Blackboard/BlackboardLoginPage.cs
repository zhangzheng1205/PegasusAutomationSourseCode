using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pegasus.Pages.UI_Pages.Integration.Blackboard
{
    public class BlackboardLoginPage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(MyPearsonLoginPage));

        /// <summary>
        /// Login to Blackboard
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        public void LoginToBB(string username, string password)
        {
            //Login to Blackboard
            logger.LogMethodEntry("BlackboardLoginPage", "LoginToMMND",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for The Window
                base.WaitUntilWindowLoads(BlackboardLoginPageResource.BlackboardLoginPage_Window_Title);
                base.SelectWindow(BlackboardLoginPageResource.BlackboardLoginPage_Window_Title);
                //Wait for The UserName text box
                base.WaitForElement(By.Id(BlackboardLoginPageResource.
                    BlackboardLoginPage_Username_Textbox_Id_Locator));
                base.ClearTextById(BlackboardLoginPageResource.
                    BlackboardLoginPage_Username_Textbox_Id_Locator);
                //Fill User Name
                base.FillTextBoxById(BlackboardLoginPageResource.
                    BlackboardLoginPage_Username_Textbox_Id_Locator, username);
                base.WaitForElement(By.Id(BlackboardLoginPageResource.
                    BlackboardLoginPage_Username_Textbox_Id_Locator));
                //Fill Password
                base.ClearTextById(BlackboardLoginPageResource.
                    BlackboardLoginPage_Password_Textbox_Id_Locator);
                base.FillTextBoxById(BlackboardLoginPageResource.
                    BlackboardLoginPage_Password_Textbox_Id_Locator, password);
                //Click on Sign In
                base.WaitForElement(By.Id(BlackboardLoginPageResource.
                    BlackboardLoginPage_Password_Textbox_Id_Locator));
                bool chy = base.IsElementPresent(By.XPath(BlackboardLoginPageResource.
                    BlackboardLoginPage_SignIn_Button_XPath_Locator), 10);
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(BlackboardLoginPageResource.
                    BlackboardLoginPage_SignIn_Button_XPath_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("BlackboardLoginPage", "LoginToMMND",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checks If User Logged In To Blackboard SuccessFully
        /// </summary>
        /// <returns>Return True if user logged in otherwise false.</returns>
        public Boolean IsUserLoggedInSuccessFully()
        {
            //Checks If User Logged In To MMND SuccessFully
            logger.LogMethodEntry("BlackboardLoginPage", "IsUserLoggedInSuccessFully",
                base.IsTakeScreenShotDuringEntryExit);
            //Initializing Variable
            Boolean isUserLoggedIn = false;
            try
            {
                Thread.Sleep(Convert.ToInt32(BlackboardLoginPageResource.
                    BlackboardLoginPage_Custom_TimeToWait_Element));
                //Wait for the Sign Out link
                base.WaitForElement(By.Id(BlackboardLoginPageResource.
                    BlackboardLoginPage_Signout_Id_Locator));
                isUserLoggedIn = base.IsElementPresent(By.Id(BlackboardLoginPageResource.
                    BlackboardLoginPage_Signout_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("BlackboardLoginPage", "IsUserLoggedInSuccessFully",
                base.IsTakeScreenShotDuringEntryExit);
            return isUserLoggedIn;
        }

        /// <summary>
        /// Blackboard user logout of Pegasus
        /// </summary>
        public void logoutOfPegasus()
        {
            base.NavigateToBrowseUrl("https://pearsonintegrationqa1.blackboard.com");
            base.WaitForElement(By.Id("topframe.logout.label"));
            IWebElement getLogoutIcon = base.GetWebElementPropertiesById("topframe.logout.label");
            base.ClickByJavaScriptExecutor(getLogoutIcon);
        }
    }
}