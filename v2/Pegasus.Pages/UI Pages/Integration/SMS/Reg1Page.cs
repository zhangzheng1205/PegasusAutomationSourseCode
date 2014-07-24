using System;
using OpenQA.Selenium;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Integration.SMS;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  Enters the basic registeration details of SMS User
    /// Name of class is bad because of, it is so in Pegasus
    /// </summary>
    public class Reg1Page : BasePage
    {

        //Getting SMS MMND Instructor Access Code From Configuration File.
        string getSMSMMNDInstructor = ConfigurationManager.AppSettings[
            Reg1PageResource.Reg1_Page_SMS_AccessCode_MMNDInstructor];

        /// <summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(Reg1Page));

        /// <summary>
        /// Fill SMS User Access Information
        /// </summary>
        /// <param name="userType">This is User Type</param>
        public void EnterSMSUserAccessInformation(User.UserTypeEnum userType)
        {
            // Fill SMS User Access Information
            logger.LogMethodEntry("Reg1Page", "EnterSMSUserAccessInformation",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Generate SMS User Login Name
                Guid userNameSMSGuid = Guid.NewGuid();
                base.SelectWindow(Reg1PageResource.
                    Reg1_Page_AccessInformation_Window_Page_Title);
                //Wait For Element
                base.WaitForElement(By.Id(Reg1PageResource.
                    Reg1_Page_AccountNo_RadioButton_Id_Locator));
                // Is Element Already Selected
                if (!base.IsElementSelectedById(Reg1PageResource.
                    Reg1_Page_AccountNo_RadioButton_Id_Locator))
                {
                    base.FocusOnElementByID(Reg1PageResource.
                        Reg1_Page_AccountNo_RadioButton_Id_Locator);
                    IWebElement getAccountNumRadioButton = base.GetWebElementPropertiesById
                        (Reg1PageResource.
                        Reg1_Page_AccountNo_RadioButton_Id_Locator);
                    base.ClickByJavaScriptExecutor(getAccountNumRadioButton);
                }
                // Enter the SMS User Details and Get Password
                string getSMSUserPassword = EnterSMSUserDetails(userType, userNameSMSGuid);
                //Save SMS User Details in Memory
                StoreSMSUserInMemory(userType, userNameSMSGuid, getSMSUserPassword);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("Reg1Page", "EnterSMSUserAccessInformation",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the SMS user details
        /// </summary>
        /// <param name="userType">This is the user type</param>
        /// <param name="userNameSMSGuid">This is the auto generated username</param>
        private string EnterSMSUserDetails(User.UserTypeEnum userType, Guid userNameSMSGuid)
        {
            // Enter the SMS user details
            logger.LogMethodEntry("Reg1Page", "EnterSMSUserDetails",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator));
            base.ClearTextByID(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator);
            //Fill the User name in Text Box 
            base.FillTextBoxByID(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator,
                userNameSMSGuid.ToString());
            //Wait For Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator));
            //Clear the Text Box
            base.ClearTextByID(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator);
            //Enter SMS User Details (Extracted Method)
            string getSMSUserPassword = this.EnterSMSUserLoginDetails(userType);
            //Enter SMS User Access Code
            this.EnterSMSUserAccessCode(userType);
            logger.LogMethodExit("Reg1Page", "EnterSMSUserDetails",
               base.isTakeScreenShotDuringEntryExit);
            return getSMSUserPassword;
        }

        /// <summary>
        /// Enter SMS User Login Details
        /// </summary>   
        private string EnterSMSUserLoginDetails(User.UserTypeEnum userType)
        {
            //Enter SMS User Details
            logger.LogMethodEntry("Reg1Page", "EnterSMSUserLoginDetails",
                base.isTakeScreenShotDuringEntryExit);
            // Generate SMS User Password
            string getSMSUserPassword = Reg1PageResource.
                Reg1_Page_SMSUser_Password_Value;
            //Enter Password in Text Box
            base.FillTextBoxByID(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator,
                Reg1PageResource.Reg1_Page_SMSUser_Password_Value);
            //Wait For Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_CreateLoginPasswordRetype_TextBox_Id_Locator));
            //Clear the Text Box
            base.ClearTextByID(Reg1PageResource.
                Reg1_Page_CreateLoginPasswordRetype_TextBox_Id_Locator);
            //Enter Password in Re-Type Text Box
            base.FillTextBoxByID(Reg1PageResource.
                Reg1_Page_CreateLoginPasswordRetype_TextBox_Id_Locator,
                                 Reg1PageResource.Reg1_Page_SMSUser_Password_Value);
            //Click on TextBox to Enter Access Code Details
            this.ClickTextBoxToEnterSMSAccessCode(userType);
            logger.LogMethodExit("Reg1Page", "EnterSMSUserLoginDetails",
                base.isTakeScreenShotDuringEntryExit);
            return getSMSUserPassword;
        }

        /// <summary>
        /// Click on TextBox to Enter Access Code Details
        /// </summary>
        /// <param name="userType">This is UserType</param>
        private void ClickTextBoxToEnterSMSAccessCode(User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("Reg1Page", "ClickTextBoxToEnterSMSAccessCode",
               base.isTakeScreenShotDuringEntryExit);
            //Click on TextBox to Enter Access Code Details
            switch (userType)
            {
                case User.UserTypeEnum.CsSmsInstructor:
                case User.UserTypeEnum.CsSmsStudent:
                case User.UserTypeEnum.MMNDInstructor:
                    //Execute According To Browser Selected
                    switch (base.Browser)
                    {
                        //This is for Internet Explorer Browser
                        case PegasusBaseTestFixture.InternetExplorer:
                            this.ClickTextBoxToEnterSMSAccessCodeInInternetExplorer();
                            base.SwitchToActivePageElement();
                            break;
                        //This is for Chrome and FireFox Browser
                        case PegasusBaseTestFixture.FireFox:
                        case PegasusBaseTestFixture.Chrome:
                            this.ClickTextBoxToEnterSMSAccessCodeInFireFoxAndChrome();
                            base.SwitchToActivePageElement();
                            break;
                    }
                    break;
                case User.UserTypeEnum.MMNDStudent:
                    //Wait for Next Button
                    base.WaitForElement((By.Id(Reg1PageResource.
                         Reg1_Page_Next_Button_Id_Locator)));
                    base.FocusOnElementByID(Reg1PageResource.
                        Reg1_Page_Next_Button_Id_Locator);
                    //Click on Next Button
                    base.ClickButtonByID(Reg1PageResource.
                        Reg1_Page_Next_Button_Id_Locator);
                    //Wait untill next page
                    base.WaitUntilWindowLoads(Reg1PageResource.
                        Reg1_Page_Next_Window_Page_Title);
                    break;
            }
            logger.LogMethodExit("Reg1Page", "ClickTextBoxToEnterSMSAccessCode",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Text Box To Enter SMS Access Code In FireFox And Chrome
        /// </summary>
        private void ClickTextBoxToEnterSMSAccessCodeInFireFoxAndChrome()
        {
            //Click text Box For Enter Access Code
            logger.LogMethodEntry("Reg1Page", "ClickTextBoxToEnterSMSAccessCodeInFireFoxAndChrome",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(Reg1PageResource.
                Reg1_Page_AcToggleSingle_Image_XPath_Locator));
            //Click on Element
            base.ClickImageByXPath(Reg1PageResource.
                Reg1_Page_AcToggleSingle_Image_XPath_Locator);
            logger.LogMethodExit("Reg1Page", "ClickTextBoxToEnterSMSAccessCodeInFireFoxAndChrome",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Text Box To Enter SMS Access Code
        /// </summary>
        private void ClickTextBoxToEnterSMSAccessCodeInInternetExplorer()
        {
            //Click Text Box For Enter Access Code
            logger.LogMethodEntry("Reg1Page", "ClickTextBoxToEnterSMSAccessCodeInInternetExplorer",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(Reg1PageResource.
                Reg1_Page_AcToggleSingle_Image_XPath_Locator));
            IWebElement getAccessCode = base.GetWebElementPropertiesByXPath
                (Reg1PageResource.
                Reg1_Page_AcToggleSingle_Image_XPath_Locator);
            //Click on Text Box Link
            base.ClickByJavaScriptExecutor(getAccessCode);
            logger.LogMethodExit("Reg1Page", "ClickTextBoxToEnterSMSAccessCodeInInternetExplorer",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Authenticate SMS User by Access Code
        /// </summary>
        /// <param name="userType">This is SMS User Type</param>
        private void EnterSMSUserAccessCode(User.UserTypeEnum userType)
        {
            // Fill SMS User Access Code
            logger.LogMethodEntry("Reg1Page", "EnterSMSUserAccessCode",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(Reg1PageResource.Reg1_Page_AccessInformation_Window_Page_Title);
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_Access1_TextBox_Id_Locator));
            base.ClearTextByID(Reg1PageResource.
                Reg1_Page_Access1_TextBox_Id_Locator);
            // Fill SMS User Access Code by User Type
            switch (userType)
            {
                //Store SMS Instructor
                case User.UserTypeEnum.CsSmsInstructor:
                    this.EnterSMSAccessCodeForInstructor();
                    break;
                //Store SMS Student
                case User.UserTypeEnum.CsSmsStudent:
                    this.EnterSMSAccessCodeForStudent();
                    break;
                //Store MMND SMS Intructor
                case User.UserTypeEnum.MMNDInstructor:
                    this.EnterSMSAccessCodeForMMNDInstructor();
                    break;
            }
            base.WaitForElement((By.Id(Reg1PageResource.
                Reg1_Page_Next_Button_Id_Locator)));
            base.FocusOnElementByID(Reg1PageResource.
                Reg1_Page_Next_Button_Id_Locator);
            IWebElement getNextButton = base.GetWebElementPropertiesById
                (Reg1PageResource.
                Reg1_Page_Next_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(getNextButton);
            //Wait To Page Get Switched Successfully
            base.WaitUntilPageGetSwitchedSuccessfully(Reg1PageResource.
                Reg1_Page_Next_Window_Page_Title);
            //Wait until next page
            base.WaitUntilWindowLoads(Reg1PageResource.
                Reg1_Page_Next_Window_Page_Title);
            logger.LogMethodExit("Reg1Page", "EnterSMSUserAccessCode",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SMS Access Code For Student
        /// </summary>
        private void EnterSMSAccessCodeForStudent()
        {
            //Enter Student SMS Code
            logger.LogMethodEntry("Reg1Page", "EnterSMSAccessCodeForStudent",
                base.isTakeScreenShotDuringEntryExit);
            //Enter SMS Code in Text Box
            base.FillTextBoxByID(Reg1PageResource.Reg1_Page_Access1_TextBox_Id_Locator,
                                 AutomationConfigurationManager.SmsStudentAccessCode);
            logger.LogMethodExit("Reg1Page", "EnterSMSAccessCodeForStudent",
                base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Enter SMS Access Code For Instructor
        /// </summary>
        private void EnterSMSAccessCodeForInstructor()
        {
            //Enter Instructor SMS Code
            logger.LogMethodEntry("Reg1Page", "EnterSMSAccessCodeForInstructor",
                base.isTakeScreenShotDuringEntryExit);
            //Enter SMS Code in Text Box
            base.FillTextBoxByID(Reg1PageResource.Reg1_Page_Access1_TextBox_Id_Locator,
                                 AutomationConfigurationManager.SmsInstructorAccessCode);
            logger.LogMethodExit("Reg1Page", "EnterSMSAccessCodeForInstructor",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter MMND SMS Access Code For Instructor
        /// </summary>
        private void EnterSMSAccessCodeForMMNDInstructor()
        {
            //Enter MMND Instructor SMS code
            logger.LogMethodEntry("Reg1Page", "EnterSMSAccessCodeForMMNDInstructor",
                base.isTakeScreenShotDuringEntryExit);
            //Enter SMS code in the Text Box
            base.FillTextBoxByID(Reg1PageResource.Reg1_Page_Access1_TextBox_Id_Locator,
                                 getSMSMMNDInstructor);
            logger.LogMethodExit("Reg1Page", "EnterSMSAccessCodeForMMNDInstructor",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SMS User Access Information
        /// </summary>
        /// <param name="userType">This is User Type</param>
        public void EnterSMSUserAccessInformationforMMNDStudent(User.UserTypeEnum userType)
        {
            //Fill SMS User Access Information
            logger.LogMethodEntry("Reg1Page", "EnterSMSUserAccessInformationforMMNDStudent",
                base.isTakeScreenShotDuringEntryExit);
            //Generate SMS User Login Name
            Guid userNameSMSGuid = Guid.NewGuid();
            base.SelectWindow(Reg1PageResource.
                Reg1_Page_AccessInformation_Window_Page_Title);
            //Wait For Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_AccountNo_RadioButton_Id_Locator));
            //Is Element Already Selected
            if (!base.IsElementSelectedById(Reg1PageResource.
                Reg1_Page_AccountNo_RadioButton_Id_Locator))
            {
                base.FocusOnElementByID(Reg1PageResource.
                    Reg1_Page_AccountNo_RadioButton_Id_Locator);
                base.ClickButtonByID(Reg1PageResource.
                    Reg1_Page_AccountNo_RadioButton_Id_Locator);
            }
            //Enter User Name
            this.EnterUserName(userNameSMSGuid);
            string getSMSUserPassword = this.EnterSMSUserLoginDetails(userType);
            //Save SMS User Details in Memory
            StoreSMSUserInMemory(userType, userNameSMSGuid, getSMSUserPassword);
            logger.LogMethodExit("Reg1Page", "EnterSMSUserAccessInformationforMMNDStudent",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter User Name
        /// </summary>
        /// <param name="userNameSMSGuid">This is userName</param>
        private void EnterUserName(Guid userNameSMSGuid)
        {
            logger.LogMethodEntry("Reg1Page", "EnterUserName",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator));
            base.ClearTextByID(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator);
            //Fill the User name in Text Box 
            base.FillTextBoxByID(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator,
                userNameSMSGuid.ToString());
            //Wait For Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator));
            //Clear the Text Box
            base.ClearTextByID(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator);
            logger.LogMethodExit("Reg1Page", "EnterUserName",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Save SMS User in memory against User Type
        /// </summary>
        /// <param name="userType">This is User Type</param>
        /// <param name="usernameGuid">This is Guid Username</param>
        /// <param name="password">This is Password</param>
        public void StoreSMSUserInMemory(User.UserTypeEnum userType,
            Guid usernameGuid, string password)
        {
            //Save SMS User in Memory
            logger.LogMethodEntry("Reg1Page", "StoreSMSUserInMemory",
                base.isTakeScreenShotDuringEntryExit);
            switch (userType)
            {
                //Save SMS Student
                case User.UserTypeEnum.CsSmsStudent:
                case User.UserTypeEnum.HedTeacherAssistant:
                case User.UserTypeEnum.CsSmsInstructor:
                case User.UserTypeEnum.MMNDInstructor:
                case User.UserTypeEnum.MMNDStudent:
                    //Save SMS Instructor in Memory
                    this.InsertUserDetailsInMemory(userType, usernameGuid, password);
                    break;
            }
            logger.LogMethodExit("Reg1Page", "StoreSMSUserInMemory",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Insert User Properties In Memory.
        /// </summary>
        /// <param name="usernameGuid">This is Guid Username.</param>
        /// <param name="password">This is Password.</param>
        /// <param name="userType">This is User type.</param>
        private void InsertUserDetailsInMemory(User.UserTypeEnum userType, Guid usernameGuid, string password)
        {
            // save sms1 user 
            logger.LogMethodEntry("Reg1Page", "InsertUserDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
            User userSMSInstructor = new User
                                         {
                                             // save sms user properties
                                             Name = usernameGuid.ToString(),
                                             Password = password,
                                             UserType = userType,
                                             IsCreated = true,
                                         };
            userSMSInstructor.StoreUserInMemory();
            logger.LogMethodExit("Reg1Page", "InsertUserDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
        }


    }
}
