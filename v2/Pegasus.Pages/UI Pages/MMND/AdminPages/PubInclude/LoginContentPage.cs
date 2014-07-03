using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.AdminPages.PubInclude;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class Contains the actions related to Login Content page.
    /// </summary>
    public class LoginContentPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(LoginContentPage));

        /// <summary>
        /// Login as Admin User in MMND Cert.
        /// </summary>
        /// <param name="userName">This is Username.</param>
        /// <param name="password">This is Password.</param>
        public void Login(string userName, string password)
        {
            //Login as Admin User
            Logger.LogMethodEntry("LoginContentPage", "Login",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Administrative Pages Window
                base.SelectWindow(LoginContentPageResource.
                        LoginContent_Page_AdministrativePages_Window_Name);
                base.WaitForElement(By.Name(LoginContentPageResource.
                    LoginContent_Page_Content_ClassName_Locator));
                //Switch to Frame
                base.SwitchToIFrame(LoginContentPageResource.
                    LoginContent_Page_Content_ClassName_Locator);
                //Enter Username
                EnterUserName(userName);
                //Enter Password
                EnterPassword(password);
                base.WaitForElement(By.Id(LoginContentPageResource.
                    LoginContent_Page_Login_Button_Id_Locator));
                //Click on Login Button
                base.ClickButtonByID(LoginContentPageResource.
                    LoginContent_Page_Login_Button_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LoginContentPage", "Login",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Login Password for MMND Admin.
        /// </summary>
        /// <param name="password">This is password.</param>
        private void EnterPassword(string password)
        {
            //Enter Admin Password
            Logger.LogMethodEntry("LoginContentPage", "EnterPassword",
              base.isTakeScreenShotDuringEntryExit);
            //Wait for Password Textbox
            base.WaitForElement(By.Id(LoginContentPageResource.
                LoginContent_Page_Password_Id_Locator));
            base.ClearTextByID(LoginContentPageResource.
                LoginContent_Page_Password_Id_Locator);
            //Enter Password
            base.FillTextBoxByID(LoginContentPageResource.
                LoginContent_Page_Password_Id_Locator, password);
            Logger.LogMethodExit("LoginContentPage", "EnterPassword",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Login UserName for MMND Admin.
        /// </summary>
        /// <param name="userName">This is username.</param>
        private void EnterUserName(string userName)
        {
            //Enter Admin Username
            Logger.LogMethodEntry("LoginContentPage", "EnterUserName",
             base.isTakeScreenShotDuringEntryExit);
            //Wait for UserName TextBox
            base.WaitForElement(By.Id(LoginContentPageResource.
                LoginContent_Page_UserName_Id_Locator));
            base.ClearTextByID(LoginContentPageResource.
                LoginContent_Page_UserName_Id_Locator);
            //Enter UserName
            base.FillTextBoxByID(LoginContentPageResource.
                LoginContent_Page_UserName_Id_Locator, userName);
            Logger.LogMethodExit("LoginContentPage", "EnterUserName",
             base.isTakeScreenShotDuringEntryExit);
        }
    }
}
