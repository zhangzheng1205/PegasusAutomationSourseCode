﻿using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using System.Diagnostics;
using OpenQA.Selenium;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles demo account Page actions.
    /// </summary>
    public class DemoAccountRegistrationPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(DemoAccountRegistrationPage));

        readonly string _demoAccountRegistrationUrl;

        /// <summary>
        /// Get Wait Limit Time From Config.
        /// </summary>
        private readonly int _getWaitTimeOut = Convert.ToInt32(
            ConfigurationManager.AppSettings["ElementFindTimeOutInSeconds"]);

        /// <summary>
        /// Construct a object of type DemoAccountRegistrationPage.
        /// </summary>
        /// <param name="userTypeEnum">Type of the user.</param>
        public DemoAccountRegistrationPage(User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("DemoAccountRegistrationPage", "DemoAccountRegistrationPage",
               base.IsTakeScreenShotDuringEntryExit);

            if (userTypeEnum == User.UserTypeEnum.DPDemoUser)
            {
                _demoAccountRegistrationUrl = AutomationConfigurationManager.CourseSpaceUrlRoot
                    + DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_PageName;
            }
            Logger.LogMethodExit("DemoAccountRegistrationPage", "DemoAccountRegistrationPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigates to demo user account registration url.
        /// </summary>
        public void GoToDemoAccountRegistrationUrl()
        {
            Logger.LogMethodEntry("DemoAccountRegistrationPage", "GoToDemoAccountRegistrationUrl",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Url Successfully Browsed
                if (IsUrlBrowsedSuccessful())
                {
                    //Open Url in Browser
                    base.NavigateToBrowseUrl(this._demoAccountRegistrationUrl);
                }
                else
                {
                    throw new Exception("Browser cannot display the webpage");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            Logger.LogMethodExit("DemoAccountRegistrationPage", "GoToDemoAccountRegistrationUrl",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Registers a account as demo user.
        /// </summary>
        /// <param name="userTypeEnum"></param>
        public void RegisterDemoAccount(User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("DemoAccountRegistrationPage", "RegisterDemoAccount"
             , base.IsTakeScreenShotDuringEntryExit);

            string userUniqueId = Guid.NewGuid().ToString();
            SelectDemoAccountRegistrationWindow();
            EnterDemoUserDetails(userUniqueId);
            RegisterDemoAccount();
            SaveUserInMemory(userUniqueId);
            Logger.LogMethodExit("DemoAccountRegistrationPage", "RegisterDemoAccount",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check thr Url Browsed Successfully.
        /// </summary>
        /// <returns>True if Url browsed successfully else false.</returns>
        /// <remarks>Slow web page loading or page not found then this 
        /// method open the Url in the address bar and wait till specified time
        ///  to page get successfully browse.</remarks>
        public Boolean IsUrlBrowsedSuccessful()
        {
            //Start Stop Watch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Get Image Present On The Page
            String getCurrentPageTitle = base.GetPageTitle;
            if (getCurrentPageTitle.Equals(LoginPageResource.
                LoginPage_NoConnect_Window_Title) || getCurrentPageTitle.Equals
                (LoginPageResource.Login_Page_404Error_Window_Title))
            {
                while (stopWatch.Elapsed.TotalSeconds < _getWaitTimeOut)
                {
                    //Navigate Base Url
                    base.NavigateToBrowseUrl(this._demoAccountRegistrationUrl);
                    getCurrentPageTitle = base.GetPageTitle;
                    if (!getCurrentPageTitle.Equals(LoginPageResource.
                        LoginPage_NoConnect_Window_Title) && !getCurrentPageTitle.Equals
                (LoginPageResource.Login_Page_404Error_Window_Title))
                    {
                        stopWatch.Stop();
                        return true;
                    }
                }
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return true;
        }

        /// <summary>
        /// Gets the message from message box.
        /// </summary>       
        /// <returns></returns>
        public String GetSuccessMessageFromMessageBox()
        {
            Logger.LogMethodEntry("DemoAccountRegistrationPage", "GetSuccessMessageFromMessageBox"
             , base.IsTakeScreenShotDuringEntryExit);

            try
            {
                base.WaitForElement(By.Id(DemoAccountRegistrationPageResource.
                    DemoAccountRegistration_Page_MsgBox_IFrame_Id_Locator));
                //Switch To light box
                base.SwitchToIFrame(DemoAccountRegistrationPageResource.
                    DemoAccountRegistration_Page_MsgBox_IFrame_Id_Locator);
                base.ClickButtonById(DemoAccountRegistrationPageResource.
                    DemoAccountRegistration_Page_MsgBox_Form_Id_Locator);
                //get the message displayed on light box.
                return base.GetElementTextByXPath(DemoAccountRegistrationPageResource.
                    DemoAccountRegistration_Page_MsgBox_SuccessSpan_XPath_Locator);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            Logger.LogMethodExit("DemoAccountRegistrationPage", "GetSuccessMessageFromMessageBox",
                 base.IsTakeScreenShotDuringEntryExit);

            return String.Empty;
        }

        /// <summary>
        /// Selects the demo user account registration window.
        /// </summary>
        private void SelectDemoAccountRegistrationWindow()
        {
            Logger.LogMethodEntry("DemoAccountRegistrationPage", "SelectDemoAccountRegistrationWindow"
              , base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads("");
            base.SelectWindow("");
            Logger.LogMethodExit("DemoAccountRegistrationPage", "SelectDemoAccountRegistrationWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enters demo user's details on Registration page.
        /// </summary>
        private void EnterDemoUserDetails(string userUniqueId)
        {
            Logger.LogMethodEntry("DemoAccountRegistrationPage", "EnterUserDetails"
              , base.IsTakeScreenShotDuringEntryExit);

            base.RefreshTheCurrentPage();
            Product demoProduct = Product.Get(Product.ProductTypeEnum.DigitalPathDemo);

            //Wait for last element (Registraion button) to load
            base.WaitForElement(By.Id(DemoAccountRegistrationPageResource.
                DemoAccountRegistration_Page_Register_Button_Id_Locator));

            //User Name
            base.FillTextBoxById(DemoAccountRegistrationPageResource.
                DemoAccountRegistration_Page_Name_TextBox_Id_Locator,
               DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_Name_Value);

            //Email
            base.FillTextBoxById(DemoAccountRegistrationPageResource.
                DemoAccountRegistration_Page_Email_TextBox_Id_Locator,
               DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_Email_Value);

            //Login name
            base.FillTextBoxById(DemoAccountRegistrationPageResource.
                DemoAccountRegistration_Page_UserName_TextBox_Id_Locator,
               userUniqueId);

            //Password
            base.ClickButtonById(DemoAccountRegistrationPageResource.
                DemoAccountRegistration_Page_PasswordWM_TextBox_IE_Id_Locator);
            base.WaitForElement(By.Id(DemoAccountRegistrationPageResource.
                DemoAccountRegistration_Page_Password_TextBox_Id_Locator));
            base.FillTextBoxById(DemoAccountRegistrationPageResource.
                DemoAccountRegistration_Page_Password_TextBox_Id_Locator,
               DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_Password_Value);

            //Demo Access code
            base.WaitForElement(By.Id(DemoAccountRegistrationPageResource.
                DemoAccountRegistration_Page_AccessCode_TextBox_Id_Locator));
            base.FillTextBoxById(DemoAccountRegistrationPageResource.
                DemoAccountRegistration_Page_AccessCode_TextBox_Id_Locator,
               demoProduct.DemoAccessCode);

            //Select State
            base.SelectDropDownValueThroughIndexById(DemoAccountRegistrationPageResource.
                DemoAccountRegistration_Page_State_Select_Id_Locator,
               Convert.ToInt32(DemoAccountRegistrationPageResource.
               DemoAccountRegistration_Page_State_Select_Index_Value));

            //Zip Code
            base.IsElementEnabledById(DemoAccountRegistrationPageResource.
                DemoAccountRegistration_Page_Zipcode_TextBox_Id_Locator);
            base.FillTextBoxById(DemoAccountRegistrationPageResource
                .DemoAccountRegistration_Page_Zipcode_TextBox_Id_Locator,
                DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_Zipcode_Value);

            Logger.LogMethodExit("DemoAccountRegistrationPage", "EnterUserDetails"
              , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks Register button to Register the demo user account.
        /// </summary>
        private void RegisterDemoAccount()
        {
            //Page have some validations scripts which require some time to be executed.
            Thread.Sleep(Convert.ToInt32(DemoAccountRegistrationPageResource
                .DemoAccountRegistration_Page_RegisterTimeToWait_Value));
            base.WaitForElement(By.Id(DemoAccountRegistrationPageResource
                .DemoAccountRegistration_Page_Register_Button_Id_Locator));
            IWebElement registerButton = base.GetWebElementPropertiesById(
                DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_Register_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(registerButton);
        }

        /// <summary>
        /// Saves user in Memory.
        /// </summary>
        private void SaveUserInMemory(string userUniqueId)
        {
            var user = new User()
            {
                UserType = User.UserTypeEnum.DPDemoUser,
                Name = userUniqueId,
                Password = DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_Password_Value,
                IsCreated = true,
                CreationDate = DateTime.UtcNow
            };
            user.StoreUserInMemory();
        }
    }
}
