using System;
using OpenQA.Selenium;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Integration.SMS;
using Pegasus.Pages.Exceptions;
using Bytescout.Spreadsheet;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  Enters the basic registeration details of SMS User
    /// Name of class is bad because of, it is so in Pegasus.
    /// </summary>
    public class Reg1Page : BasePage
    {

        //Getting SMS MMND Instructor Access Code From Configuration File.
        readonly string _getSmsmmndInstructor = ConfigurationManager.AppSettings[
            Reg1PageResource.Reg1_Page_SMS_AccessCode_MMNDInstructor];

        /// <summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(Reg1Page));

        /// <summary>
        /// Fill SMS User Access Information.
        /// </summary>
        /// <param name="userType">This is User Type.</param>
        public void EnterSmsUserAccessInformation(User.UserTypeEnum userType,string mode)
        {
            // Fill SMS User Access Information
            Logger.LogMethodEntry("Reg1Page", "EnterSmsUserAccessInformation",
                base.IsTakeScreenShotDuringEntryExit);
            Guid userNameSmsGuid=Guid.Empty;
            string  getSmsUserPassword=string.Empty;
           
            try
            {
               
                        // Generate SMS User Login Name
                        userNameSmsGuid = Guid.NewGuid();
                        //Convert GUID to String
                        string userNameSmsGuidString = userNameSmsGuid.ToString();
                        string password = "Password@1";
                        //Fetch access code based on user type
                        string accessCode = GetAccessCode(mode, userType);
                        // select sms user account number
                        this.SelectSmsUserAccountNumber();
                        //Enter the data
                        this.EnterUserCreationDetails(userType, userNameSmsGuidString, password,accessCode,  mode);
                        //Save SMS User Details in Memory
                        StoreSmsUserInMemory(userType, userNameSmsGuidString, password);
                         

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Reg1Page", "EnterSmsUserAccessInformation",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Sms User Account Number.
        /// </summary>
        private void SelectSmsUserAccountNumber()
        {
            Logger.LogMethodExit("Reg1Page", "SelectSmsUserAccountNumber",
                base.IsTakeScreenShotDuringEntryExit);
            base.SelectWindow(Reg1PageResource.
                Reg1_Page_AccessInformation_Window_Page_Title);
            //Wait For Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_AccountNo_RadioButton_Id_Locator));
            // Is Element Already Selected
            if (!base.IsElementSelectedById(Reg1PageResource.
                Reg1_Page_AccountNo_RadioButton_Id_Locator))
            {
                base.FocusOnElementById(Reg1PageResource.
                    Reg1_Page_AccountNo_RadioButton_Id_Locator);
                IWebElement getAccountNumRadioButton = base.GetWebElementPropertiesById
                    (Reg1PageResource.
                        Reg1_Page_AccountNo_RadioButton_Id_Locator);
                base.ClickByJavaScriptExecutor(getAccountNumRadioButton);
            }
            Logger.LogMethodExit("Reg1Page", "SelectSmsUserAccountNumber",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the SMS user details
        /// </summary>
        /// <param name="userType">This is the user type.</param>
        /// <param name="userNameSmsGuid">This is the auto generated username.</param>
        private string EnterSmsUserDetails(User.UserTypeEnum userType, string userNameSmsGuid)
        {
            // Enter the SMS user details
            Logger.LogMethodEntry("Reg1Page", "EnterSmsUserDetails",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator));
            base.ClearTextById(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator);
            //Fill the User name in Text Box 
            base.FillTextBoxById(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator,
                userNameSmsGuid);
            //Wait For Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator));
            //Clear the Text Box
            base.ClearTextById(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator);
            //Enter SMS User Details (Extracted Method)
            string getSmsUserPassword = this.EnterSmsUserLoginDetails(userType);
            //Enter SMS User Access Code
            this.EnterSmsUserAccessCode(userType);
            Logger.LogMethodExit("Reg1Page", "EnterSmsUserDetails",
               base.IsTakeScreenShotDuringEntryExit);
            return getSmsUserPassword;
        }

        /// <summary>
        /// Enter SMS User Login Details.
        /// </summary>   
        private string EnterSmsUserLoginDetails(User.UserTypeEnum userType)
        {
            //Enter SMS User Details
            Logger.LogMethodEntry("Reg1Page", "EnterSmsUserLoginDetails",
                base.IsTakeScreenShotDuringEntryExit);
            // Generate SMS User Password
            string getSmsUserPassword = Reg1PageResource.
                Reg1_Page_SMSUser_Password_Value;
            //Enter Password in Text Box
            base.FillTextBoxById(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator,
                Reg1PageResource.Reg1_Page_SMSUser_Password_Value);
            //Wait For Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_CreateLoginPasswordRetype_TextBox_Id_Locator));
            //Clear the Text Box
            base.ClearTextById(Reg1PageResource.
                Reg1_Page_CreateLoginPasswordRetype_TextBox_Id_Locator);
            //Enter Password in Re-Type Text Box
            base.FillTextBoxById(Reg1PageResource.
                Reg1_Page_CreateLoginPasswordRetype_TextBox_Id_Locator,
                                 Reg1PageResource.Reg1_Page_SMSUser_Password_Value);
            //Click on TextBox to Enter Access Code Details
            this.ClickTextBoxToEnterSmsAccessCode(userType);
            Logger.LogMethodExit("Reg1Page", "EnterSmsUserLoginDetails",
                base.IsTakeScreenShotDuringEntryExit);
            return getSmsUserPassword;
        }

        /// <summary>
        /// Click on TextBox to Enter Access Code Details.
        /// </summary>
        /// <param name="userType">This is UserType.</param>
        private void ClickTextBoxToEnterSmsAccessCode(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("Reg1Page", "ClickTextBoxToEnterSMSAccessCode",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on TextBox to Enter Access Code Details
            switch (userType)
            {
                case User.UserTypeEnum.CsSmsInstructor:
                case User.UserTypeEnum.CsSmsStudent:
                case User.UserTypeEnum.MMNDInstructor:
                case User.UserTypeEnum.HedProgramAdmin:
                    //Execute According To Browser Selected
                    switch (base.Browser)
                    {
                        //This is for Internet Explorer Browser
                        case PegasusBaseTestFixture.InternetExplorer:
                            this.ClickTextBoxToEnterSmsAccessCodeInInternetExplorer();
                            base.SwitchToActivePageElement();
                            break;
                        //This is for Chrome and FireFox Browser
                        case PegasusBaseTestFixture.FireFox:
                        case PegasusBaseTestFixture.Chrome:
                            this.ClickTextBoxToEnterSmsAccessCodeInFireFoxAndChrome();
                            base.SwitchToActivePageElement();
                            break;
                    }
                    break;
                case User.UserTypeEnum.MMNDStudent:
                    //Wait for Next Button
                    base.WaitForElement((By.Id(Reg1PageResource.
                         Reg1_Page_Next_Button_Id_Locator)));
                    base.FocusOnElementById(Reg1PageResource.
                        Reg1_Page_Next_Button_Id_Locator);
                    //Click on Next Button
                    base.ClickButtonById(Reg1PageResource.
                        Reg1_Page_Next_Button_Id_Locator);
                    //Wait untill next page
                    base.WaitUntilWindowLoads(Reg1PageResource.
                        Reg1_Page_Next_Window_Page_Title);
                    break;
            }
            Logger.LogMethodExit("Reg1Page", "ClickTextBoxToEnterSMSAccessCode",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Text Box To Enter SMS Access Code In FireFox And Chrome.
        /// </summary>
        private void ClickTextBoxToEnterSmsAccessCodeInFireFoxAndChrome()
        {
            //Click text Box For Enter Access Code
            Logger.LogMethodEntry("Reg1Page", "ClickTextBoxToEnterSmsAccessCodeInFireFoxAndChrome",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(Reg1PageResource.
                Reg1_Page_AcToggleSingle_Image_XPath_Locator));
            //Click on Element
            base.ClickImageByXPath(Reg1PageResource.
                Reg1_Page_AcToggleSingle_Image_XPath_Locator);
            Logger.LogMethodExit("Reg1Page", "ClickTextBoxToEnterSmsAccessCodeInFireFoxAndChrome",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Text Box To Enter SMS Access Code.
        /// </summary>
        private void ClickTextBoxToEnterSmsAccessCodeInInternetExplorer()
        {
            //Click Text Box For Enter Access Code
            Logger.LogMethodEntry("Reg1Page", "ClickTextBoxToEnterSmsAccessCodeInInternetExplorer",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(Reg1PageResource.
                Reg1_Page_AcToggleSingle_Image_XPath_Locator));
            IWebElement getAccessCode = base.GetWebElementPropertiesByXPath
                (Reg1PageResource.
                Reg1_Page_AcToggleSingle_Image_XPath_Locator);
            //Click on Text Box Link
            base.ClickByJavaScriptExecutor(getAccessCode);
            Logger.LogMethodExit("Reg1Page", "ClickTextBoxToEnterSmsAccessCodeInInternetExplorer",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Authenticate SMS User by Access Code.
        /// </summary>
        /// <param name="userType">This is SMS User Type.</param>
        private void EnterSmsUserAccessCode(User.UserTypeEnum userType)
        {
            // Fill SMS User Access Code
            Logger.LogMethodEntry("Reg1Page", "EnterSmsUserAccessCode",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(Reg1PageResource.Reg1_Page_AccessInformation_Window_Page_Title);
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_Access1_TextBox_Id_Locator));
            base.ClearTextById(Reg1PageResource.
                Reg1_Page_Access1_TextBox_Id_Locator);
            // Fill SMS User Access Code by User Type
            switch (userType)
            {
                //Store SMS Instructor
                case User.UserTypeEnum.CsSmsInstructor:
                case User.UserTypeEnum.HedProgramAdmin:
                    this.EnterSmsAccessCodeForInstructor();
                    break;
                //Store SMS Student
                case User.UserTypeEnum.CsSmsStudent:
                    this.EnterSmsAccessCodeForStudent();
                    break;
                //Store MMND SMS Intructor
                case User.UserTypeEnum.MMNDInstructor:
                    this.EnterSmsAccessCodeForMmndInstructor();
                    break;
            }
            base.WaitForElement((By.Id(Reg1PageResource.
                Reg1_Page_Next_Button_Id_Locator)));
            base.FocusOnElementById(Reg1PageResource.
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
            Logger.LogMethodExit("Reg1Page", "EnterSmsUserAccessCode",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SMS Access Code For Student.
        /// </summary>
        private void EnterSmsAccessCodeForStudent()
        {
            //Enter Student SMS Code
            Logger.LogMethodEntry("Reg1Page", "EnterSmsAccessCodeForStudent",
                base.IsTakeScreenShotDuringEntryExit);
            //Enter SMS Code in Text Box
            base.FillTextBoxById(Reg1PageResource.Reg1_Page_Access1_TextBox_Id_Locator,
                                 AutomationConfigurationManager.SmsStudentAccessCode);
            Logger.LogMethodExit("Reg1Page", "EnterSmsAccessCodeForStudent",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Enter SMS Access Code For Instructor.
        /// </summary>
        private void EnterSmsAccessCodeForInstructor()
        {
            //Enter Instructor SMS Code
            Logger.LogMethodEntry("Reg1Page", "EnterSmsAccessCodeForInstructor",
                base.IsTakeScreenShotDuringEntryExit);
            //Enter SMS Code in Text Box
            base.FillTextBoxById(Reg1PageResource.Reg1_Page_Access1_TextBox_Id_Locator,
                                 AutomationConfigurationManager.SmsInstructorAccessCode);
            Logger.LogMethodExit("Reg1Page", "EnterSmsAccessCodeForInstructor",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter MMND SMS Access Code For Instructor.
        /// </summary>
        private void EnterSmsAccessCodeForMmndInstructor()
        {
            //Enter MMND Instructor SMS code
            Logger.LogMethodEntry("Reg1Page", "EnterSmsAccessCodeForMmndInstructor",
                base.IsTakeScreenShotDuringEntryExit);
            //Enter SMS code in the Text Box
            base.FillTextBoxById(Reg1PageResource.Reg1_Page_Access1_TextBox_Id_Locator,
                                 _getSmsmmndInstructor);
            Logger.LogMethodExit("Reg1Page", "EnterSmsAccessCodeForMmndInstructor",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SMS User Access Information.
        /// </summary>
        /// <param name="userType">This is User Type.</param>
        public void EnterSmsUserAccessInformationforMmndStudent(User.UserTypeEnum userType)
        {
            //Fill SMS User Access Information
            Logger.LogMethodEntry("Reg1Page", "EnterSMSUserAccessInformationforMMNDStudent",
                base.IsTakeScreenShotDuringEntryExit);
            //Generate SMS User Login Name
            Guid userNameSmsGuid = Guid.NewGuid();
            base.SelectWindow(Reg1PageResource.
                Reg1_Page_AccessInformation_Window_Page_Title);
            //Wait For Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_AccountNo_RadioButton_Id_Locator));
            //Is Element Already Selected
            if (!base.IsElementSelectedById(Reg1PageResource.
                Reg1_Page_AccountNo_RadioButton_Id_Locator))
            {
                base.FocusOnElementById(Reg1PageResource.
                    Reg1_Page_AccountNo_RadioButton_Id_Locator);
                base.ClickButtonById(Reg1PageResource.
                    Reg1_Page_AccountNo_RadioButton_Id_Locator);
            }
            //Enter User Name
            this.EnterUserName(userNameSmsGuid);
            string getSmsUserPassword = this.EnterSmsUserLoginDetails(userType);
            //Save SMS User Details in Memory
            StoreSmsUserInMemory(userType, userNameSmsGuid.ToString(), getSmsUserPassword);
            Logger.LogMethodExit("Reg1Page", "EnterSMSUserAccessInformationforMMNDStudent",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter User Name.
        /// </summary>
        /// <param name="userNameSmsGuid">This is userName.</param>
        private void EnterUserName(Guid userNameSmsGuid)
        {
            Logger.LogMethodEntry("Reg1Page", "EnterUserName",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator));
            base.ClearTextById(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator);
            //Fill the User name in Text Box 
            base.FillTextBoxById(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator,
                userNameSmsGuid.ToString());
            //Wait For Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator));
            //Clear the Text Box
            base.ClearTextById(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator);
            Logger.LogMethodExit("Reg1Page", "EnterUserName",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Save SMS User in memory against User Type.
        /// </summary>
        /// <param name="userType">This is User Type.</param>
        /// <param name="usernameGuid">This is Guid Username.</param>
        /// <param name="password">This is Password.</param>
        public void StoreSmsUserInMemory(User.UserTypeEnum userType,
            string usernameGuid, string password)
        {
            //Save SMS User in Memory
            Logger.LogMethodEntry("Reg1Page", "StoreSMSUserInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            switch (userType)
            {
                //Save SMS Student
                case User.UserTypeEnum.CsSmsStudent:
                case User.UserTypeEnum.HedTeacherAssistant:
                case User.UserTypeEnum.CsSmsInstructor:
                case User.UserTypeEnum.MMNDInstructor:
                case User.UserTypeEnum.MMNDStudent:
                case User.UserTypeEnum.HedProgramAdmin:
                    //Save SMS Instructor in Memory
                    this.InsertUserDetailsInMemory(userType, usernameGuid, password);
                    break;
            }
            Logger.LogMethodExit("Reg1Page", "StoreSMSUserInMemory",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Insert User Properties In Memory.
        /// </summary>
        /// <param name="usernameGuid">This is Guid Username.</param>
        /// <param name="password">This is Password.</param>
        /// <param name="userType">This is User type.</param>
        private void InsertUserDetailsInMemory(User.UserTypeEnum userType,
            string usernameGuid, string password)
        {
            // save sms user 
            Logger.LogMethodEntry("Reg1Page", "InsertUserDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            var user = new User
                                         {
                                             // save sms user properties
                                             Name = usernameGuid,
                                             Password = password,
                                             UserType = userType,
                                             IsCreated = true,
                                         };
            user.StoreUserInMemory();            
            Logger.LogMethodExit("Reg1Page", "InsertUserDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SmsUser Access Information Based On Scenario.
        /// </summary>
        /// <param name="scenarioName">This is Scenerio Name.</param>
        /// <param name="userType">This is User Type Enum.</param>
        public void EnterSmsUserAccessInformationBasedOnScenario(string scenarioName, 
            User.UserTypeEnum userType)
        {
            // Fill SMS User Access Information
            Logger.LogMethodEntry("Reg1Page", "EnterSmsUserAccessInformationBasedOnScenario",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // sms user login name
                Guid userNameSmsGuid = Guid.NewGuid();
                // select sms user account number
                this.SelectSmsUserAccountNumber();
                // sms user details and get password
                string getSmsUserPassword = EnterSmsUserDetails(userType, userNameSmsGuid.ToString());
                //Enter SMS User Personal Information and Get User Last Name
                switch (userType)
                {
                    case User.UserTypeEnum.CsSmsStudent:
                        switch (scenarioName)
                        {
                            case "scoring 0":
                                InsertUserDetailsInMemoryBasedOnScenario(CommonResource.CommonResource
                                    .SMS_STU_UC1, userNameSmsGuid,
                                    getSmsUserPassword);
                                break;
                            case "set idle":
                                InsertUserDetailsInMemoryBasedOnScenario(CommonResource.CommonResource
                                    .SMS_STU_UC2, userNameSmsGuid,
                                  getSmsUserPassword);
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Reg1Page", "EnterSmsUserAccessInformationBasedOnScenario",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Insert User Details In Memory.
        /// </summary>
        /// <param name="userId">This is User Id.</param>
        /// <param name="usernameGuid">This is User Name GUID.</param>
        /// <param name="password">This is Password.</param>
        private void InsertUserDetailsInMemoryBasedOnScenario(string userId,
            Guid usernameGuid, string password)
        {
            // save sms user 
            Logger.LogMethodEntry("Reg1Page", "InsertUserDetailsInMemoryBasedOnScenario",
                base.IsTakeScreenShotDuringEntryExit);
            var user = new User
            {
                // save sms user properties
                Name = usernameGuid.ToString(),
                Password = password,
                UserId = userId,
                IsCreated = true,
            };
            user.StoreUserInMemory();
            Logger.LogMethodExit("Reg1Page", "InsertUserDetailsInMemoryBasedOnScenario",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Create 'n' number of SMS users(student/instructor) from runtime generated values/Static 
        /// Excel values.
        /// </summary>
        /// <param name="userCount">This is number of user.</param>
        /// <param name="userTypeEnum">This is the type of user.</param>
        /// <param name="mode">This is the mode of user generation.</param>
        /// <param name="smsUser">This is the user creating users.</param>
        public void BulkUserCreation(int userCount,User.UserTypeEnum userTypeEnum,string mode,
            User.UserTypeEnum smsUser)
        {
            // Create 'n' number of SMS users(student/instructor) from runtime generated 
            //values/Static Excel values
            Logger.LogMethodEntry("Reg1Page", "BulkUserCreation",
               base.IsTakeScreenShotDuringEntryExit);
            //Select either generation using dynamic runtime values or static excel values
            try
            {
                switch (mode)
                {
                    //Create using dynamic runtime values
                    case "BulkRuntime":
                        ExcelReadWrite excelReadAndWrite = new ExcelReadWrite();
                        AddExcelSheetHeaders(excelReadAndWrite);
                        //Create using dynamic runtime values
                        CreateBulkUserUsingRunTimeValues(userCount, userTypeEnum, mode, smsUser, 
                            excelReadAndWrite);
                        //Saving the excel spreadsheet instance as Excel File.
                        excelReadAndWrite.SaveExcelFile("Trial01");
                        break;
                    //Create using ststic excel values.
                    case "BulkExcel":
                        ExcelReadWrite excelRead = new ExcelReadWrite();
                        Reg2Page reg2 = new Reg2Page();
                        //Access the excel file to read the user details to be entered for user creation
                        excelRead.OpenExcelFile(@"D:\AutomationGeneratedExcelFiles\Trial02.xlsx", "Sheet01");
                        //Create using ststic excel values.
                        CreateBulkUserUsingExcelValues(userCount, userTypeEnum, mode,
                            smsUser, excelRead, reg2);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Reg1Page", "BulkUserCreation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Adding headers to excel created at runtime.
        /// </summary>
        /// <param name="excelReadAndWrite">This is the excel sheet instance.</param>
        private void AddExcelSheetHeaders(ExcelReadWrite excelReadAndWrite)
        {
            // Adding headers to excel created at runtime
            Logger.LogMethodEntry("Reg1Page", "AddExcelSheetHeaders",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //declaring Headers values.
                string[] headers = new string[5] { "Sl.no", "UserName", "Password", "FirstName",
                            "LastName" };
                //create excel sheet instance 
                excelReadAndWrite.GetExcelInstance("Sheet01");
                //Updating header values at excel sheet
                excelReadAndWrite.AddHeaders(5, headers);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Reg1Page", "AddExcelSheetHeaders",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create using static excel values.
        /// </summary>
        /// <param name="userCount">This is the number of users.</param>
        /// <param name="userTypeEnum">This is type of user.</param>
        /// <param name="mode">This is the mode of user creation.</param>
        /// <param name="smsUser">This is the user performing the operation.</param>
        /// <param name="excelRead">This the excel spreadsheet instance.</param>
        /// <param name="reg2">this is class  Reg2Page instance. </param>
        private void CreateBulkUserUsingExcelValues(int userCount, User.UserTypeEnum userTypeEnum,
            string mode, User.UserTypeEnum smsUser, ExcelReadWrite excelRead, Reg2Page reg2)
        {
            // Create using static excel values
            Logger.LogMethodEntry("Reg1Page", "CreateBulkUserUsingExcelValues",
            base.IsTakeScreenShotDuringEntryExit);
            //For eachuser perform below action
            try
            {
                for (int i = 1; i <= userCount; i++)
                {
                    //URL launch step starting from second user
                    //For first user action is handled by Backgroung step
                    if (i > 1)
                    {
                        LaunchSMSRegistrationPage(smsUser);
                    }
                    //Click I Accept Button
                    new ConsentPage().ClickIAcceptButtonBySMSAdmin();
                    string[] a = new string[12];
                    a = excelRead.ReadExcelCellDataValues(i, 12);
                    //Select Sms User Account Number
                    this.SelectSmsUserAccountNumber();
                    // Enter the SMS User Details and Get Password
                    //Pass  userName , password , accessCode from excel   
                    EnterUserCreationDetails(userTypeEnum, a[1], a[2], a[3], mode);
                    //Pass userFirstName ,getUserLastName ,mailId ,country,school,schoolCity ,securityQuestion,securityAnswer
                    reg2.EnterUserOtherDetails(a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11]);
                    //Verify Confirmation page
                    string confirmationPageTitle = new ConsentPage().GetPageTitle;

                    if (confirmationPageTitle == "Confirmation and Summary")
                        continue;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
           Logger.LogMethodExit("Reg1Page", "CreateBulkUserUsingExcelValues",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch SMS registration page.
        /// </summary>
        /// <param name="smsUser">This is the type of user performing the operation.</param>
        private void LaunchSMSRegistrationPage(User.UserTypeEnum smsUser)
        {
            // Launch SMS registration page
            Logger.LogMethodEntry("Reg1Page", "CreateBulkUserUsingExcelValues",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                BrowsePegasusUserURL loginPage = new BrowsePegasusUserURL(smsUser);
                //Login  the type of the user
                Boolean isBasePegasusUrlBrowsedSuccessful =
                loginPage.IsUrlBrowsedSuccessful();
                //Check Is Url Browsed Successfully
                if (isBasePegasusUrlBrowsedSuccessful)
                {
                    //Open Url in Browser
                    loginPage.GoToLoginUrl();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Reg1Page", "CreateBulkUserUsingExcelValues",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create using dynamic runtime values.
        /// </summary>
        /// <param name="userCount">This is the number of users.</param>
        /// <param name="userTypeEnum">This is the type of user.</param>
        /// <param name="mode">This is the mode of user creation.</param>
        /// <param name="smsUser">This is the user performing the operation.</param>
        /// <param name="excelReadAndWrite">This the excel spreadsheet instance.</param>
        private void CreateBulkUserUsingRunTimeValues(int userCount, User.UserTypeEnum userTypeEnum, string mode, User.UserTypeEnum smsUser, ExcelReadWrite excelReadAndWrite)
        {
            // Create using dynamic runtime values
            Logger.LogMethodEntry("Reg1Page", "CreateBulkUserUsingRunTimeValues",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                for (int i = 1; i <= userCount; i++)
                {
                    //URL launch step starting from second user
                    //For first user action is handled by Backgroung step
                    if (i > 1)
                    {
                        LaunchSMSRegistrationPage(smsUser);
                    }
                    //Click Accept Button By SMSAdmin
                    new ConsentPage().ClickIAcceptButtonBySMSAdmin();
                    //Fill SMS User Access Information
                    this.EnterSmsUserAccessInformation(userTypeEnum, mode);
                    //Fill SMS User Account Information for Registeration
                    new Reg2Page().EnterSmsUserAccountOtherInformation(userTypeEnum, mode);
                    //Get the values stored in enum during runtime
                    User user = User.Get(userTypeEnum);
                    //Assign the values picked from enum into an array
                    string[] rowValues = new string[5] { i.ToString(), user.Name, user.Password, user.FirstName, user.LastName };
                    //Write the value into excel sheet
                    excelReadAndWrite.AddRowData(i, 5, rowValues);
                    //Verify Confirmation page
                    string confirmationPageTitle = new ConsentPage().GetPageTitle;

                    if (confirmationPageTitle == "Confirmation and Summary")
                        continue;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Reg1Page", "CreateBulkUserUsingRunTimeValues",
       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the SMS user details
        /// </summary>
        /// <param name="userType">This is the user type.</param>
        /// <param name="userNameSmsGuid">This is the auto generated username.</param>
        public void EnterUserCreationDetails(User.UserTypeEnum userType, string userName, string password,string accessCode,string mode)
        {
            // Enter the SMS user details
            Logger.LogMethodEntry("Reg1Page", "EnterUserCreationDetails",
               base.IsTakeScreenShotDuringEntryExit);
            try 
	      {	        
		    //Wait for Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator));
            base.ClearTextById(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator);
            //Fill the User name in Text Box 
            base.FillTextBoxById(Reg1PageResource.
                Reg1_Page_New_SMSUser_Loginname_TextBox_Id_Locator,
                userName);
            //Wait For Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator));
            //Clear the Text Box
            base.ClearTextById(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator);
            //Enter Password in Text Box
            base.FillTextBoxById(Reg1PageResource.
                Reg1_Page_CreateLoginPassword_TextBox_Id_Locator,
               password);
            //Wait For Element
            base.WaitForElement(By.Id(Reg1PageResource.
                Reg1_Page_CreateLoginPasswordRetype_TextBox_Id_Locator));
            //Clear the Text Box
            base.ClearTextById(Reg1PageResource.
                Reg1_Page_CreateLoginPasswordRetype_TextBox_Id_Locator);
            //Enter Password in Re-Type Text Box
            base.FillTextBoxById(Reg1PageResource.
                Reg1_Page_CreateLoginPasswordRetype_TextBox_Id_Locator,
                                 password);
            //Click on TextBox to Enter Access Code Details
            this.ClickTextBoxToEnterSmsAccessCode(userType);
            //Enter SMS User Access Code
            EnterTheSmsUserAccessCode(accessCode);
	   }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Reg1Page", "EnterUserCreationDetails",
               base.IsTakeScreenShotDuringEntryExit);
          }

        /// <summary>
        /// Fetch Access Code based on User Type.
        /// </summary>
        /// <param name="mode">This is the mode type.</param>
        /// <param name="userType">This is the user type.</param>
        /// <returns>Returns the access code.</returns>
        public string GetAccessCode(string mode, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("Reg1Page", "GetAccessCode",
             base.IsTakeScreenShotDuringEntryExit);
            string accessCode=string.Empty;
         try 
	   {
           switch (mode)
           {
               case "BulkRuntime":
               case "Single":
                   switch (userType)
                   {
                       //Store SMS Instructor
                       case User.UserTypeEnum.CsSmsInstructor:
                       case User.UserTypeEnum.HedProgramAdmin:
                           accessCode = AutomationConfigurationManager.SmsInstructorAccessCode;
                           break;
                       //Store SMS Student
                       case User.UserTypeEnum.CsSmsStudent:
                           accessCode = AutomationConfigurationManager.SmsStudentAccessCode;
                           break;
                       //Store MMND SMS Intructor
                       case User.UserTypeEnum.MMNDInstructor:
                           accessCode = _getSmsmmndInstructor;
                           break;
                   }

                   break;
               case "BulkExcel":
                   break;
           }
	    }
	  catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
             
        
              Logger.LogMethodExit("Reg1Page", "GetAccessCode",
               base.IsTakeScreenShotDuringEntryExit);
         
            return accessCode;
        }

        /// <summary>
        /// Authenticate SMS User by Access Code.
        /// </summary>
        /// <param name="userType">This is SMS User Type.</param>
        private void EnterTheSmsUserAccessCode(string accessCode)
        {
            // Fill SMS User Access Code
            Logger.LogMethodEntry("Reg1Page", "EnterSmsUserAccessCode",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.SelectWindow(Reg1PageResource.Reg1_Page_AccessInformation_Window_Page_Title);
                base.WaitForElement(By.Id(Reg1PageResource.
                    Reg1_Page_Access1_TextBox_Id_Locator));
                base.ClearTextById(Reg1PageResource.
                    Reg1_Page_Access1_TextBox_Id_Locator);
                // Fill SMS User Access Code by User Type
                base.FillTextBoxById(Reg1PageResource.Reg1_Page_Access1_TextBox_Id_Locator,
                                    accessCode);
                base.WaitForElement((By.Id(Reg1PageResource.
                    Reg1_Page_Next_Button_Id_Locator)));
                base.FocusOnElementById(Reg1PageResource.
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
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
             
            Logger.LogMethodExit("Reg1Page", "EnterSmsUserAccessCode",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
