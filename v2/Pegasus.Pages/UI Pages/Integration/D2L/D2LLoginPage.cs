using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;


namespace Pegasus.Pages.UI_Pages.Integration.D2L
{
    public class D2LLoginPage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(D2LLoginPage));

        /// <summary>
        /// This method accepts username and password as string parameters
        /// Enters the user name and password in the login page and signs in the users
        /// </summary>
        
        public void LoginToD2L(string username, string password)
        {
            logger.LogMethodEntry("D2LLoginPage", "LoginToD2L",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for D2L login page
                base.WaitUntilWindowLoads(D2LLoginPageResource.D2LLoginPage_Window_Title);
                base.SelectWindow(D2LLoginPageResource.D2LLoginPage_Window_Title);
                //Wait for The UserName text box
                base.WaitForElement(By.Id(D2LLoginPageResource.
                    D2LLoginPage_Username_Textbox_Id_Locator));
                base.ClearTextById(D2LLoginPageResource.
                    D2LLoginPage_Username_Textbox_Id_Locator);
                //Fill User Name
                base.FillTextBoxById(D2LLoginPageResource.
                    D2LLoginPage_Username_Textbox_Id_Locator, username);
                //Fill Password
                base.ClearTextById(D2LLoginPageResource.
                    D2LLoginPage_Password_Textbox_Id_Locator);
                base.FillTextBoxById(D2LLoginPageResource.
                    D2LLoginPage_Password_Textbox_Id_Locator, password);
                //Click on Sign In
                //base.WaitForElement(By.Id(D2LLoginPageResource.
                  //  D2LLoginPage_Password_Textbox_Id_Locator));
             
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(D2LLoginPageResource.
                    D2LLoginPage_SignIn_Button_Id));
                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("D2LLoginPage", "LoginToD2L",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checks If User Logged In To D2L SuccessFully
        /// </summary>
        /// <returns>Return True if user logged in otherwise false.</returns>
        public Boolean IsUserLoggedInSuccessFully()
        {
            //Checks If User Logged In To D2L SuccessFully
            logger.LogMethodEntry("D2LLoginPage", "IsUserLoggedInSuccessFully",
                base.IsTakeScreenShotDuringEntryExit);
            //Initializing Variable
            Boolean isUserLoggedIn = false;
            try
            {
               
                base.WaitForElement(By.CssSelector(D2LLoginPageResource.D2LLoginPage_Home_Text));

               // Assign true if logged in successfully

              isUserLoggedIn = base.IsElementPresent(By.CssSelector(D2LLoginPageResource.
                   D2LLoginPage_Home_Text));

               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("D2LLoginPage", "IsUserLoggedInSuccessFully",
                base.IsTakeScreenShotDuringEntryExit);
            return isUserLoggedIn;
        }

        /// <summary>
        /// Blackboard user logout of Pegasus
        /// </summary>
       /* public void logoutOfPegasus()
        {
            base.NavigateToBrowseUrl("https://pearsonintegrationqa1.blackboard.com");
            base.WaitForElement(By.Id("topframe.logout.label"));
            IWebElement getLogoutIcon = base.GetWebElementPropertiesById("topframe.logout.label");
            base.ClickByJavaScriptExecutor(getLogoutIcon);
        }*/
    }
}
