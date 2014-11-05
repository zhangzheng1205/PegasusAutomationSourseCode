using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.LTISettings.Main.AdminMode.LTICourseToolSettings;
using Pegasus.Pages.UI_Pages.MMND.SecureEcollegeLabs.CCNG;
using Pegasus.Pages.UI_Pages.MMND.Students;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Register Page actions
    /// </summary>
    public class RegisterPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(RegisterPage));


        /// <summary>
        /// Enter Section Id
        /// </summary>
        /// <param name="sectionId">Section Id</param>
        public void EnterSectionId(string sectionId)
        {
            logger.LogMethodEntry("RegisterPage", "EnterSectionId",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Register Pearson my Mastering Window
                //base.SelectWindow(RegisterPageResource.
                //        Register_Page_RegisterPearsonMyLabMastering_Window_Name);
                base.SelectWindow("Register | Pearson MyLab & Mastering");
                base.WaitForElement(By.Id(RegisterPageResource.
                    Register_Page_Enter_Course_Id_Locator));
                //Enter Seciton Id
                base.FillTextBoxById(RegisterPageResource.
                    Register_Page_Enter_Course_Id_Locator, sectionId);
                base.WaitForElement(By.Id("course-id-button"));
                //Click On Register Course
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesById("course-id-button"));
                Thread.Sleep(Convert.ToInt32(RegisterPageResource.
                    Register_Page_Wait_Window_Sleep_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RegisterPage", "EnterSectionId",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Is Section name is Displayed
        /// </summary>
        /// <param name="sectionName">This is Section Name</param>
        /// <returns>Returns True if Section Name is displayed otherwise false</returns>
        public Boolean IsSectionNameDisplayed(string sectionName)
        {
            //Verify Is Section name is Displayed
            logger.LogMethodEntry("RegisterPage", "IsSectionNameDisplayed",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Varibale
            Boolean isSectionDisplayed = false;
            try
            {
                //Select Rrgister Pearson My Lab Mastering Window
                base.SelectWindow(RegisterPageResource.
                        Register_Page_RegisterPearsonMyLabMastering_Window_Name);                
                while (base.IsElementDisplayedById(RegisterPageResource.
                    Register_Page_StepWait_Id_Locator))
                {
                    Thread.Sleep(Convert.ToInt32(RegisterPageResource.Register_Page_Wait_Sleep_Value));
                }
                string getUrl = base.GetCurrentUrl;
                if ((getUrl.Contains(RegisterPageResource.Register_Page_Pending_GetURL)))
                {
                    //Click On Portal Url
                    this.ClickOnPortalUrlLink();
                    isSectionDisplayed = base.IsElementPresent(By.PartialLinkText(sectionName));
                }
                if ((getUrl.Contains(RegisterPageResource.Register_Page_Completed_GetURL)))
                {
                    //Click On Go To Button
                    this.ClickOnGoToButton();
                    isSectionDisplayed = base.IsElementPresent(By.PartialLinkText(sectionName));
                }
                if ((getUrl.Contains(RegisterPageResource.
                    Register_Page_AccessCode_GetURL)))
                {
                    //Enter Access Code
                    this.EnterAccessCodeAndRegister();
                    //Verify Is Section Name Displayed
                    isSectionDisplayed = this.IsSectionPresent(sectionName, isSectionDisplayed);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RegisterPage", "IsSectionNameDisplayed",
            base.IsTakeScreenShotDuringEntryExit);
            return isSectionDisplayed;
        }

        /// <summary>
        /// Verify Is Course Name Displayed
        /// </summary>
        /// <param name="sectionName">This is Section Name</param>
        /// <param name="isSectionDisplayed">This is Variable to Verify Course</param>
        /// <returns>Returns True if Section Name is displayed otherwise false</returns>
        private Boolean IsSectionPresent(string sectionName, Boolean isSectionDisplayed)
        {
            //Enter Access Code
            logger.LogMethodEntry("RegisterPage", "IsSectionPresent",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Registering Pearosn My Lab Mastering Widnow            
            base.WaitForElement(By.Id(RegisterPageResource.Register_Page_StepWait_Id_Locator));
            while (base.IsElementDisplayedById(RegisterPageResource.Register_Page_StepWait_Id_Locator))
            {
                Thread.Sleep(Convert.ToInt32(RegisterPageResource.Register_Page_Wait_Sleep_Value));
            }
            string getTheUrl = base.GetCurrentUrl;
            if ((getTheUrl.Contains(RegisterPageResource.Register_Page_Pending_GetURL)))
            {
                //Click On Portal URL
                this.ClickOnPortalUrlLink();
                isSectionDisplayed = base.IsElementPresent(By.PartialLinkText(sectionName));
            }
            else
            {
                //Click On Go To Button
                this.ClickOnGoToButton();
                isSectionDisplayed = base.IsElementPresent(By.PartialLinkText(sectionName));
            }
            logger.LogMethodExit("RegisterPage", "IsSectionPresent",
            base.IsTakeScreenShotDuringEntryExit);
            return isSectionDisplayed;
        }

        /// <summary>
        /// Enter Access Code and Register
        /// </summary>
        private void EnterAccessCodeAndRegister()
        {   
            //Enter Access Code and Register
            logger.LogMethodEntry("RegisterPage", "EnterAccessCodeAndRegister",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Register Pearson My Lab Mastering Window
            base.SelectWindow(RegisterPageResource.
            Register_Page_RegisterPearsonMyLabMastering_Window_Name);
            //Wait for Access Code Partial Link text
            base.WaitForElement(By.PartialLinkText(RegisterPageResource.
                Register_Page_AccessCode_LinkText_Locator));
            //Get Access Code Button Property
            IWebElement getAccessCode = base.GetWebElementPropertiesByPartialLinkText(
                RegisterPageResource.Register_Page_AccessCode_LinkText_Locator);
            //Click On Get Access Code Button
            base.ClickByJavaScriptExecutor(getAccessCode);
            base.WaitForElement(By.XPath(RegisterPageResource.
                Register_Page_EnterAccessCode_one_Xpath_Locator));
            //Enter the Access Code
            this.EntertheFirstThreeAccessCodeValues();
            base.WaitForElement(By.Id(RegisterPageResource.
                Register_Page_AccessCode_FinishButton_Id_Locator));
            base.FocusOnElementById(RegisterPageResource.
                Register_Page_AccessCode_FinishButton_Id_Locator);
            //Click On Finish Button
            base.ClickButtonById(RegisterPageResource.
                Register_Page_AccessCode_FinishButton_Id_Locator);
            //Select Register Pearosn My Lab Mastering Window
            base.SelectWindow(RegisterPageResource.
              Register_Page_RegisterPearsonMyLabMastering_Window_Name);
            logger.LogMethodExit("RegisterPage", "EnterAccessCodeAndRegister",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Go To Button
        /// </summary>
        private void ClickOnGoToButton()
        {
            //Click On Go To Button
            logger.LogMethodEntry("RegisterPage", "ClickOnGoToButton",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Register Pearson Lab Mastering Window
            base.SelectWindow(RegisterPageResource.
             Register_Page_RegisterPearsonMyLabMastering_Window_Name);
            //Wait for Go To Button
            base.WaitForElement(By.ClassName(RegisterPageResource.
                Register_Page_GoToButton_ClassName_Locator));
            //Click on Go To Button
            base.ClickButtonByClassName(RegisterPageResource.
                Register_Page_GoToButton_ClassName_Locator);
            //Select My Lab Mastering Pearson Window
            base.SelectWindow(RegisterPageResource.
               Register_Page_MyLabMasteringPearson_Window_Name);
            logger.LogMethodExit("RegisterPage", "ClickOnGoToButton",
          base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter the First Three Access Code
        /// </summary>
        private void EntertheFirstThreeAccessCodeValues()
        {
            //Enter First Three Access Code
            logger.LogMethodEntry("RegisterPage", "EntertheFirstThreeAccessCodeValues",
            base.IsTakeScreenShotDuringEntryExit);
            IWebElement textbox1 = base.GetWebElementPropertiesByXPath(
                    RegisterPageResource.Register_Page_EnterAccessCode_one_Xpath_Locator);
            //Enter Access Code 
            textbox1.SendKeys(RegisterPageResource.Register_Page_EnterAccessCode_one_Enter);
            base.WaitForElement(By.XPath(RegisterPageResource.
                Register_Page_EnterAccessCode_two_Xpath_Locator));
            IWebElement textbox2 = base.GetWebElementPropertiesByXPath(RegisterPageResource.
                Register_Page_EnterAccessCode_two_Xpath_Locator);
            //Enter Access Code
            textbox2.SendKeys(RegisterPageResource.Register_Page_EnterAccessCode_two_Enter);
            base.WaitForElement(By.XPath(RegisterPageResource.
                Register_Page_EnterAccessCode_three_Xpath_Locator));
            IWebElement textbox3 = base.GetWebElementPropertiesByXPath(RegisterPageResource.
                Register_Page_EnterAccessCode_three_Xpath_Locator);
            textbox3.SendKeys(RegisterPageResource.Register_Page_EnterAccessCode_three_Enter);
            //Enter Access Code
            this.EnterRestoftheAccessCodeValues();
            logger.LogMethodExit("RegisterPage", "EntertheFirstThreeAccessCodeValues",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the Rest of Access Code 
        /// </summary>
        private void EnterRestoftheAccessCodeValues()
        {
            //Enter Rest of the Access Code
            logger.LogMethodEntry("RegisterPage", "EnterRestoftheAccessCodeValues",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(RegisterPageResource.
                Register_Page_EnterAccessCode_four_Xpath_Locator));
            IWebElement textbox4 = base.GetWebElementPropertiesByXPath(RegisterPageResource.
                Register_Page_EnterAccessCode_four_Xpath_Locator);
            //Enter Access Code
            textbox4.SendKeys(RegisterPageResource.Register_Page_EnterAccessCode_four_Enter);
            base.WaitForElement(By.XPath(RegisterPageResource.
                Register_Page_EnterAccessCode_five_Xpath_Locator));
            IWebElement textbox5 = base.GetWebElementPropertiesByXPath(RegisterPageResource.
                Register_Page_EnterAccessCode_five_Xpath_Locator);
            //Enter Access Code
            textbox5.SendKeys(RegisterPageResource.Register_Page_EnterAccessCode_five_Enter);
            base.WaitForElement(By.XPath(RegisterPageResource.
                Register_Page_EnterAccessCode_Six_Xpath_Locator));
            IWebElement textbox6 = base.GetWebElementPropertiesByXPath(RegisterPageResource.
                Register_Page_EnterAccessCode_Six_Xpath_Locator);
            //Enter Access Code
            textbox6.SendKeys(RegisterPageResource.Register_Page_EnterAccessCode_six_Enter);
            logger.LogMethodExit("RegisterPage", "EnterRestoftheAccessCodeValues",
           base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Click On Portal URL
        /// </summary>
        private void ClickOnPortalUrlLink()
        {
            //Click On Portal URL
            logger.LogMethodEntry("RegisterPage", "ClickOnPortalUrlLink",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Register Pearson My Lab Mastering Window
            base.SelectWindow(RegisterPageResource.
            Register_Page_RegisterPearsonMyLabMastering_Window_Name);
            //Wait for Portal Partial Link Text
            base.WaitForElement(By.PartialLinkText(RegisterPageResource.
                Register_Page_PortalUrl_PartialLinkText_Locator));
            //Get Property of Portal URL
            IWebElement geturl = base.GetWebElementPropertiesByPartialLinkText(RegisterPageResource.
                    Register_Page_PortalUrl_PartialLinkText_Locator);
            //Click On Portal URL
            base.ClickByJavaScriptExecutor(geturl);
            base.WaitUntilWindowLoads(RegisterPageResource.
                Register_Page_MyLabMasteringPearson_Window_Name);
            //Select My Lab Masteing Pearson Window
            base.SelectWindow(RegisterPageResource.
                Register_Page_MyLabMasteringPearson_Window_Name);
            Thread.Sleep(Convert.ToInt32(RegisterPageResource.
                Register_Page_VerifyCourse_Sleep_Value));
            base.RefreshTheCurrentPage();
            //Select My Lab Mastering Pearson Window
            base.SelectWindow(RegisterPageResource.
                Register_Page_MyLabMasteringPearson_Window_Name);
            logger.LogMethodExit("RegisterPage", "ClickOnPortalUrlLink",
            base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
