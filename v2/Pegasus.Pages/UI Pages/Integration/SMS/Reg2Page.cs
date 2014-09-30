using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Integration.SMS;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// Enters the basic registeration details of SMS User
    /// Name of class is bad because of, it is so in Pegasus
    /// </summary>
    public class Reg2Page : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(Reg2Page));

        /// <summary>
        /// Fill SMS User Account Information for Registeration
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        /// <param name="scenarioName">This is scenarion name.</param>
        public void EnterSmsUserAccountInformation(User.UserTypeEnum userType,
            string scenarioName="Default Value")
        {
            // Fill SMS User Account Information
            Logger.LogMethodEntry("Reg2Page", "EnterSmsUserAccountInformation",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Enter SmsUser Personal Information.
               string getLastName = this.EnterSmsUserPersonalInformation(userType);
               string getFirstName = this.EnterSmsFirstNameDetails();
               if (scenarioName != "Default Value")
               {
                   //Update The User LastName In Memory
                   this.UpdateTheUserLastNameInMemoryOnScenerioBasis(userType, 
                       getLastName, scenarioName,getFirstName);
               }
               else
               {
                   //Update The User LastName In Memory
                   this.UpdateTheUserLastNameInMemory(userType, getLastName, getFirstName);
               }
                base.WaitForElement(By.Id(Reg2PageResource.
                    Reg2_Page_Entered_Country_DropDown_Id_Locator));
                //Select Drop Down Value
                base.SelectDropDownValueThroughTextById(Reg2PageResource.
                    Reg2_Page_Entered_Country_DropDown_Id_Locator,
                    Reg2PageResource.Reg2_Page_Entered_Country_DropDown_Value);
                //Enter SMS User School Information
                this.EnterSmsUserSchoolInformation();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Reg2Page", "EnterSmsUserAccountInformation",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SmsFirst Name Details.
        /// </summary>
        /// <returns></returns>
        private string EnterSmsFirstNameDetails()
        {
            //Enter Personal Information
            Logger.LogMethodEntry("Reg2Page", "EnterSmsFirstNameDetails",
                base.IsTakeScreenShotDuringEntryExit);          
            //Initialize Variable
            string getUserFirstName = Reg2PageResource.
                Reg2_Page_FirstName_TextBox_Value;
            //Select Window
            base.SelectWindow(Reg2PageResource.
                    Reg2_Page_AccountInformation_Window_Title_Name);
            //Wait for Element
            base.WaitForElement(By.Id(Reg2PageResource.
                Reg2_Page_FirstName_TextBox_Id_Locator));
            base.ClearTextById(Reg2PageResource.
                Reg2_Page_FirstName_TextBox_Id_Locator);
            //Enter First Name
            base.FillTextBoxById(Reg2PageResource.
                Reg2_Page_FirstName_TextBox_Id_Locator,
                getUserFirstName);
            Logger.LogMethodExit("Reg2Page", "EnterSmsFirstNameDetails",
            base.IsTakeScreenShotDuringEntryExit);
            return getUserFirstName;
        }

        /// <summary>
        /// Update The User LastName In Memory.
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        /// <param name="getLastName">This is last name.</param>
        private void UpdateTheUserLastNameInMemory(User.UserTypeEnum userType,
            string lastName,string firstName)
        {
            //Update The User LastName In Memory
            Logger.LogMethodEntry("Reg2Page", "UpdateTheUserLastNameInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            //The the user details from memory
            User user = User.Get(userType);
            user.LastName = lastName;
            user.FirstName = firstName;
            //Update the last name in memory
            user.UpdateUserInMemory(user);
            Logger.LogMethodExit("Reg2Page", "UpdateTheUserLastNameInMemory",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Update The User LastName In Memory On Scenerio Basis.
        /// </summary>
        /// <param name="userType">This Is User Type Enum.</param>
        /// <param name="getLastName">This Is Last Name.</param>
        /// <param name="scenarioName">This Is scenerion Basis Name.</param>
        private void UpdateTheUserLastNameInMemoryOnScenerioBasis(User.UserTypeEnum userType, 
            string lastName, string scenarioName,string firstName)
        {
            //Update The User LastName In Memory On Scenerio Basis
            Logger.LogMethodEntry("Reg2Page", "UpdateTheUserLastNameInMemoryOnScenerioBasis",
                base.IsTakeScreenShotDuringEntryExit);
               switch (scenarioName)
               {
                   case "scoring 0":
                       User user = User.Get(CommonResource.CommonResource
                         .SMS_STU_UC1);
                       user.LastName = lastName;
                       user.FirstName = firstName;
                       user.UpdateUserInMemory(user);
                       break;
                   case "set idle":
                       User user2 = User.Get(CommonResource.CommonResource
                         .SMS_STU_UC2);
                       user2.LastName = lastName;
                       user2.FirstName = firstName;
                       user2.UpdateUserInMemory(user2);
                       break;
               }
               Logger.LogMethodExit("Reg2Page", "UpdateTheUserLastNameInMemoryOnScenerioBasis",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SMS User Personal Information
        /// </summary>
        /// /// <param name="userType">This is user type enum.</param>
        public string EnterSmsUserPersonalInformation(User.UserTypeEnum userType)
        {
            //Enter Personal Information
            Logger.LogMethodEntry("Reg2Page", "EnterSmsUserPersonalInformation",
                base.IsTakeScreenShotDuringEntryExit);
            //Generate GUID for customize Activity Name
            Guid userLastName = Guid.NewGuid();
            //Initialize Variable
            string getUserLastName = string.Empty;
            try
            {
                //Select Window
                base.SelectWindow(Reg2PageResource.
                        Reg2_Page_AccountInformation_Window_Title_Name); 
                //Splitt User Last Name
                string[] getSplittedUserLastName = userLastName.ToString().Split('-');
                //Get Splitted User Last Name
                getUserLastName = getSplittedUserLastName[1];
                //Wait For Element
                base.WaitForElement(By.Id(Reg2PageResource.
                    Reg2_Page_LastName_TextBox_Id_Locator));
                base.ClearTextById(Reg2PageResource.
                    Reg2_Page_LastName_TextBox_Id_Locator);
                //Enter Last Name
                base.FillTextBoxById(Reg2PageResource.
                    Reg2_Page_LastName_TextBox_Id_Locator,
                    getUserLastName);
                //Enter Email Id
                this.EnterEmailIdForTheUser();                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Reg2Page", "EnterSmsUserPersonalInformation",
                base.IsTakeScreenShotDuringEntryExit);
            return getUserLastName;
        }
        
        /// <summary>
        /// Enter the Email id details for the user
        /// </summary>
        private void EnterEmailIdForTheUser()
        {
            //Enter the Email id details for the user
            Logger.LogMethodEntry("Reg2Page", "EnterEmailIdForTheUser",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(Reg2PageResource.
                Reg2_Page_Email_TextBox_Id_Locator));
            base.ClearTextById(Reg2PageResource.
                Reg2_Page_Email_TextBox_Id_Locator);
            //Enter Email Id
            base.FillTextBoxById(Reg2PageResource.
                Reg2_Page_Email_TextBox_Id_Locator, 
                Reg2PageResource.Reg2_Page_Email_TextBox_Value);
            //Wait For Element
            base.WaitForElement(By.Id(Reg2PageResource.
                Reg2_Page_EmailConfirm_TextBox_Id_Locator));
            //Clear Text Box Value
            base.ClearTextById(Reg2PageResource.
                Reg2_Page_EmailConfirm_TextBox_Id_Locator);
            //Enter Confirmation Email
            base.FillTextBoxById(Reg2PageResource.
                Reg2_Page_EmailConfirm_TextBox_Id_Locator,
                Reg2PageResource.Reg2_Page_Email_TextBox_Value);
            Logger.LogMethodExit("Reg2Page", "EnterEmailIdForTheUser",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SMS User School Information for Registeration
        /// </summary>
        private void EnterSmsUserSchoolInformation()
        {
            // Enter SMS User School Information
            Logger.LogMethodEntry("Reg2Page", "EnterSmsUserSchoolInformation",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(Reg2PageResource.
                Reg2_Page_OtherSchoolName_TextBox_Id_Locator));
            //Enter School Name
            base.FillTextBoxById(Reg2PageResource.
                Reg2_Page_OtherSchoolName_TextBox_Id_Locator,
                Reg2PageResource.Reg2_Page_OtherSchoolName_TextBox_Value);
            base.WaitForElement(By.Id(Reg2PageResource.
                Reg2_Page_OtherSchoolCity_TextBox_Id_Locator));
            //Entyer City
            base.FillTextBoxById(Reg2PageResource.
                Reg2_Page_OtherSchoolCity_TextBox_Id_Locator,
                Reg2PageResource.Reg2_Page_OtherSchoolCity_TextBox_Value);
            base.WaitForElement(By.Name(Reg2PageResource.
                Reg2_Page_Person_VerifyQuestion_DropDown_Name_Locator));
            //Select Verification Question
            base.SelectDropDownValueThroughTextByName(Reg2PageResource.
                Reg2_Page_Person_VerifyQuestion_DropDown_Name_Locator,
                Reg2PageResource.Reg2_Page_Person_VerifyQuestion_DropDown_Value);
            //Enter SMS Personal Account Information
            this.EnterSmsUserSecurityInformation();
            Logger.LogMethodExit("Reg2Page", "EnterSmsUserSchoolInformation",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SMS User Security Information
        /// </summary>
        private void EnterSmsUserSecurityInformation()
        {
            //Enter SMS User Security Information
            Logger.LogMethodEntry("Reg2Page", "EnterSmsUserSecurityInformation",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element City textbox
            base.WaitForElement(By.Id(Reg2PageResource.
                                          Reg2_Page_Password3_TextBox_Id_Locator));
            base.ClearTextById(Reg2PageResource.Reg2_Page_Password3_TextBox_Id_Locator);
            //Fill City text box
            base.FillTextBoxById(Reg2PageResource.Reg2_Page_Password3_TextBox_Id_Locator,
                                 Reg2PageResource.Reg2_Page_Password3_TextBox_Value);
            base.WaitForElement(By.Id(Reg2PageResource.
                                          Reg2_Page_Next_Button_Id_Locator));
            IWebElement getNextClickButton = base.GetWebElementPropertiesById
                (Reg2PageResource.Reg2_Page_Next_Button_Id_Locator);
            //Click on the Next button
            base.ClickByJavaScriptExecutor(getNextClickButton);
            //Wait To Page Get Switched Successfully
            base.WaitUntilPageGetSwitchedSuccessfully(Reg2PageResource.
                                     Reg2_Page_ConfirmationandSummary_Window_Title_Name);
            //Wait For Window
            base.WaitUntilWindowLoads(Reg2PageResource.
                                     Reg2_Page_ConfirmationandSummary_Window_Title_Name);
            Logger.LogMethodExit("Reg2Page", "EnterSmsUserSecurityInformation",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
