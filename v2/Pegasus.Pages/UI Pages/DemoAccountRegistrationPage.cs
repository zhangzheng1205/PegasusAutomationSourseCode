using System;
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
        private static Logger logger = Logger.GetInstance(typeof(DemoAccountRegistrationPage));

        readonly string demoAccountRegistrationURL;
        
        /// <summary>
        /// Get Wait Limit Time From Config.
        /// </summary>
        private int getWaitTimeOut = Convert.ToInt32(
            ConfigurationManager.AppSettings["ElementFindTimeOutInSeconds"]);

        /// <summary>
        /// Construct a object of type DemoAccountRegistrationPage.
        /// </summary>
        /// <param name="userTypeEnum">Type of the user</param>
        public DemoAccountRegistrationPage(User.UserTypeEnum userTypeEnum)
         {
             logger.LogMethodEntry("DemoAccountRegistrationPage", "DemoAccountRegistrationPage",
                base.isTakeScreenShotDuringEntryExit);

             if (userTypeEnum == User.UserTypeEnum.DPDemoUser)
             {
                 demoAccountRegistrationURL = AutomationConfigurationManager.CourseSpaceURLRoot
                     + DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_PageName;                
             }
             logger.LogMethodExit("DemoAccountRegistrationPage", "DemoAccountRegistrationPage", base.isTakeScreenShotDuringEntryExit);
         }

        /// <summary>
        /// Navigates to demo user account registration url.
        /// </summary>
        public void GoToDemoAccountRegistrationUrl()
        {
            logger.LogMethodEntry("DemoAccountRegistrationPage", "GoToDemoAccountRegistrationUrl",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get Url Successfully Browsed
                if (IsUrlBrowsedSuccessful())
                {
                    //Open Url in Browser
                    base.NavigateToBrowseUrl(this.demoAccountRegistrationURL);
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
            logger.LogMethodExit("DemoAccountRegistrationPage", "GoToDemoAccountRegistrationUrl",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Registers a account as demo user.
        /// </summary>
        /// <param name="userTypeEnum"></param>
        public void RegisterDemoAccount(User.UserTypeEnum userTypeEnum)
        {
            logger.LogMethodEntry("DemoAccountRegistrationPage", "RegisterDemoAccount"
             , base.isTakeScreenShotDuringEntryExit);

            string userUniqueId = Guid.NewGuid().ToString();
            SelectDemoAccountRegistrationWindow();
            EnterDemoUserDetails(userUniqueId);
            RegisterDemoAccount();
            SaveUserInMemory(userUniqueId);

            logger.LogMethodExit("DemoAccountRegistrationPage", "RegisterDemoAccount",
                 base.isTakeScreenShotDuringEntryExit);
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
                 while (stopWatch.Elapsed.TotalSeconds < getWaitTimeOut)
                 {
                     //Navigate Base Url
                     base.NavigateToBrowseUrl(this.demoAccountRegistrationURL);
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
             logger.LogMethodEntry("DemoAccountRegistrationPage", "GetSuccessMessageFromMessageBox"
              , base.isTakeScreenShotDuringEntryExit);
                       
            try
            {
                base.WaitForElement(By.Id(DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_MsgBox_IFrame_Id_Locator));
                //Switch To light box
                base.SwitchToIFrame(DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_MsgBox_IFrame_Id_Locator);
                base.ClickButtonByID(DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_MsgBox_Form_Id_Locator);
                //get the message displayed on light box.
                return base.GetElementTextByXPath(DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_MsgBox_SuccessSpan_XPath_Locator);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            logger.LogMethodExit("DemoAccountRegistrationPage", "GetSuccessMessageFromMessageBox",
                 base.isTakeScreenShotDuringEntryExit);

             return String.Empty;
         }

        /// <summary>
        /// Selects the demo user account registration window.
        /// </summary>
        private void SelectDemoAccountRegistrationWindow()
         {
             logger.LogMethodEntry("DemoAccountRegistrationPage", "SelectDemoAccountRegistrationWindow"
               , base.isTakeScreenShotDuringEntryExit);
             base.WaitUntilWindowLoads("");
             base.SelectWindow("");
             logger.LogMethodExit("DemoAccountRegistrationPage", "SelectDemoAccountRegistrationWindow",
                 base.isTakeScreenShotDuringEntryExit);
         }

        /// <summary>
        /// Enters demo user's details on Registration page.
        /// </summary>
        private void EnterDemoUserDetails(string userUniqueId)
         {
             logger.LogMethodEntry("DemoAccountRegistrationPage", "EnterUserDetails"
               , base.isTakeScreenShotDuringEntryExit);

             base.RefreshTheCurrentPage();
             Product demoProduct = Product.Get(Product.ProductTypeEnum.DigitalPathDemo);

             //Wait for last element (Registraion button) to load
             base.WaitForElement(By.Id(DemoAccountRegistrationPageResource.
                 DemoAccountRegistration_Page_Register_Button_Id_Locator));

             //User Name
             base.FillTextBoxByID(DemoAccountRegistrationPageResource.
                 DemoAccountRegistration_Page_Name_TextBox_Id_Locator,
                DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_Name_Value);

             //Email
             base.FillTextBoxByID(DemoAccountRegistrationPageResource.
                 DemoAccountRegistration_Page_Email_TextBox_Id_Locator,
                DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_Email_Value);

            //Login name
             base.FillTextBoxByID(DemoAccountRegistrationPageResource.
                 DemoAccountRegistration_Page_UserName_TextBox_Id_Locator,
                userUniqueId);

            //Password
             base.ClickButtonByID(DemoAccountRegistrationPageResource.
                 DemoAccountRegistration_Page_PasswordWM_TextBox_IE_Id_Locator);
             base.WaitForElement(By.Id(DemoAccountRegistrationPageResource.
                 DemoAccountRegistration_Page_Password_TextBox_Id_Locator));
             base.FillTextBoxByID(DemoAccountRegistrationPageResource.
                 DemoAccountRegistration_Page_Password_TextBox_Id_Locator,
                DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_Password_Value);

            //Demo Access code
             base.WaitForElement(By.Id(DemoAccountRegistrationPageResource.
                 DemoAccountRegistration_Page_AccessCode_TextBox_Id_Locator));
             base.FillTextBoxByID(DemoAccountRegistrationPageResource.
                 DemoAccountRegistration_Page_AccessCode_TextBox_Id_Locator,
                demoProduct.DemoAccessCode);   
          
             //Select State
             base.SelectDropDownValueThroughIndexById(DemoAccountRegistrationPageResource.
                 DemoAccountRegistration_Page_State_Select_Id_Locator,
                Convert.ToInt32(DemoAccountRegistrationPageResource.
                DemoAccountRegistration_Page_State_Select_Index_Value));

             //Zip Code
             base.IsElementEnabledByID(DemoAccountRegistrationPageResource.
                 DemoAccountRegistration_Page_Zipcode_TextBox_Id_Locator);
             base.FillTextBoxByID(DemoAccountRegistrationPageResource
                 .DemoAccountRegistration_Page_Zipcode_TextBox_Id_Locator,
                 DemoAccountRegistrationPageResource.DemoAccountRegistration_Page_Zipcode_Value);

             logger.LogMethodExit("DemoAccountRegistrationPage", "EnterUserDetails"
               , base.isTakeScreenShotDuringEntryExit);
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
            User user = new User()
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
