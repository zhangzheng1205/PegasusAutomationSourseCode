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
        private static readonly Logger logger = Logger.GetInstance(typeof(Reg2Page));

        /// <summary>
        /// Fill SMS User Account Information for Registeration
        /// </summary>
        public void EnterSMSUserAccountInformation()
        {
            // Fill SMS User Account Information
            logger.LogMethodEntry("Reg2Page", "EnterSMSUserAccountInformation",
                base.isTakeScreenShotDuringEntryExit);
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
                this.EnterSMSUserPersonalInformation();
                base.WaitForElement(By.Id(Reg2PageResource.
                    Reg2_Page_Entered_Country_DropDown_Id_Locator));
                //Select Drop Down Value
                base.SelectDropDownValueThroughTextById(Reg2PageResource.
                    Reg2_Page_Entered_Country_DropDown_Id_Locator,
                    Reg2PageResource.Reg2_Page_Entered_Country_DropDown_Value);
                //Enter SMS User School Information
                this.EnterSMSUserSchoolInformation();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("Reg2Page", "EnterSMSUserAccountInformation",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SMS User Personal Information
        /// </summary>
        private void EnterSMSUserPersonalInformation()
        {
            //Enter Personal Information
            logger.LogMethodEntry("Reg2Page", "EnterSMSUserPersonalInformation",
                base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("Reg2Page", "EnterSMSUserPersonalInformation",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the Email id details for the user
        /// </summary>
        private void EnterEmailIdForTheUser()
        {
            //Enter the Email id details for the user
            logger.LogMethodEntry("Reg2Page", "EnterEmailIdForTheUser",
                base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("Reg2Page", "EnterEmailIdForTheUser",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SMS User School Information for Registeration
        /// </summary>
        private void EnterSMSUserSchoolInformation()
        {
            // Enter SMS User School Information
            logger.LogMethodEntry("Reg2Page", "EnterSMSUserSchoolInformation",
                base.isTakeScreenShotDuringEntryExit);
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
            EnterSMSUserSecurityInformation();
            logger.LogMethodExit("Reg2Page", "EnterSMSUserSchoolInformation",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SMS User Security Information
        /// </summary>
        private void EnterSMSUserSecurityInformation()
        {
            //Enter SMS User Security Information
            logger.LogMethodEntry("Reg2Page", "EnterSMSUserSecurityInformation",
                base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("Reg2Page", "EnterSMSUserSecurityInformation",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
