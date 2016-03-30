using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.PortalTest;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Login to MMND actions
    /// </summary>
    public class MyPearsonLoginPage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(MyPearsonLoginPage));

        /// <summary>
        /// Login to MMND
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        public void LoginToMMND(string username,string password)
        {
            //Login to MMND
            logger.LogMethodEntry("MyPearsonLoginPage", "LoginToMMND",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {            
                //Wait for The Window
                base.WaitUntilWindowLoads(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_Window_Title);
                base.SelectWindow(MyPearsonLoginPageResource.MyPearsonLoginPage_Window_Title);
                //Wait for The UserName text box
                base.WaitForElement(By.Id(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_Username_Textbox_Id_Locator));
                base.ClearTextById(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_Username_Textbox_Id_Locator);
                //Fill User Name
                base.FillTextBoxById(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_Username_Textbox_Id_Locator, username);
                base.WaitForElement(By.Id(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_Password_Textbox_Id_Locator));
                //Fill Password
                base.ClearTextById(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_Password_Textbox_Id_Locator);
                base.FillTextBoxById(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_Password_Textbox_Id_Locator, password);
                //Click on Sign In
                base.WaitForElement(By.XPath(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_SignIn_Button_Xpath_Locator));
                base.ClickByJavaScriptExecutor(base.
                    GetWebElementPropertiesByXPath(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_SignIn_Button_Xpath_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyPearsonLoginPage", "LoginToMMND",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Successfully Logged Out Of MMND
        /// </summary>
        /// <returns>Successfull Message</returns>
        public String GetSuccessfullyLoggedOutOfMMNDMessage()
        {
            //Successfully Logged Out Of MMND
            logger.LogMethodEntry("MyPearsonLoginPage", "GetSuccessfullyLoggedOutOfMMNDMessage",
                base.IsTakeScreenShotDuringEntryExit);
            //Initializing the Variable
            string getSuccessfullMessage = string.Empty;
            try
            {
                //Wait for the Window 'MyLab / Mastering | Pearson'
                base.WaitUntilWindowLoads(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_Window_Title);
                base.SelectWindow(MyPearsonLoginPageResource.MyPearsonLoginPage_Window_Title);
                //Wait for the Successfull Message
                base.WaitForElement(By.Id(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_Successfull_LogOut_Message_Id_Locator));
                getSuccessfullMessage = base.GetElementTextById(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_Successfull_LogOut_Message_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyPearsonLoginPage", "GetSuccessfullyLoggedOutOfMMNDMessage",
                base.IsTakeScreenShotDuringEntryExit);
            return getSuccessfullMessage;
        }

        /// <summary>
        /// Checks If User Logged In To MMND SuccessFully
        /// </summary>
        /// <returns>Return True if user logged in otherwise false.</returns>
        public Boolean IsUserLoggedInSuccessFully()
        {
            //Checks If User Logged In To MMND SuccessFully
            logger.LogMethodEntry("MyPearsonLoginPage", "IsUserLoggedInSuccessFully",
                base.IsTakeScreenShotDuringEntryExit);
            //Initializing Variable
            Boolean isUserLoggedIn = false;
            try
            {
                Thread.Sleep(Convert.ToInt32(MyPearsonLoginPageResource.
                    MyPearsonLoginPage_Custom_WaitTime_Element));
                //Wait for The Window
                base.WaitUntilWindowLoads(MyPearsonLoginPageResource.
                    MyPearsonHomePage_Window_Title);
                base.SelectWindow(MyPearsonLoginPageResource.MyPearsonHomePage_Window_Title);
                //Wait for the Sign Out link
                base.WaitForElement(By.PartialLinkText(MyPearsonLoginPageResource.
                        MyPearsonLoginPage_Signout_Link_Title_Locator));
                isUserLoggedIn = base.IsElementPresent(By.PartialLinkText(
                    MyPearsonLoginPageResource.MyPearsonLoginPage_Signout_Link_Title_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyPearsonLoginPage", "IsUserLoggedInSuccessFully",
                base.IsTakeScreenShotDuringEntryExit);
            return isUserLoggedIn;
        }
    }
}
