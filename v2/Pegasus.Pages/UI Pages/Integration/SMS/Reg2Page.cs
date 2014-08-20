using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Integration.SMS;
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
        public void EnterSmsUserAccountInformation()
        {
            // Fill SMS User Account Information
            Logger.LogMethodEntry("Reg2Page", "EnterSmsUserAccountInformation",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.SelectWindow(Reg2PageResource.
                        Reg2_Page_AccountInformation_Window_Title_Name);
                //Wait for Element
                base.WaitForElement(By.Id(Reg2PageResource.
                    Reg2_Page_FirstName_TextBox_Id_Locator));
                base.ClearTextById(Reg2PageResource.
                    Reg2_Page_FirstName_TextBox_Id_Locator);
                //Enter Name And Email For SMS User
                this.EnterSmsUserPersonalInformation();
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
        /// Enter SMS User Personal Information
        /// </summary>
        private void EnterSmsUserPersonalInformation()
        {
            //Enter Personal Information
            Logger.LogMethodEntry("Reg2Page", "EnterSmsUserPersonalInformation",
                base.IsTakeScreenShotDuringEntryExit);
            //Enter First Name
            base.FillTextBoxById(Reg2PageResource.
                Reg2_Page_FirstName_TextBox_Id_Locator,
                Reg2PageResource.Reg2_Page_FirstName_TextBox_Value);
            //Wait For Element
            base.WaitForElement(By.Id(Reg2PageResource.
                Reg2_Page_LastName_TextBox_Id_Locator));
            base.ClearTextById(Reg2PageResource.
                Reg2_Page_LastName_TextBox_Id_Locator);
            //Enter Last Name
            base.FillTextBoxById(Reg2PageResource.
                Reg2_Page_LastName_TextBox_Id_Locator,
                Reg2PageResource.Reg2_Page_LastName_TextBox_Id_Value);
            //Enter Email Id
            this.EnterEmailIdForTheUser();
            Logger.LogMethodExit("Reg2Page", "EnterSmsUserPersonalInformation",
                base.IsTakeScreenShotDuringEntryExit);
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
