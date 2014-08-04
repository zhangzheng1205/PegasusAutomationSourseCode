using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Integration.SMS;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains the details of SMS user registeration for Step 1
    /// Step1 includes to accept the Terms and Conditions
    /// </summary>
    public class ConsentPage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(ConsentPage));

        /// <summary>
        /// Get the current page tile name
        /// </summary>
        public String CurrentPageTitle
        {
            get { return base.WebDriver.Title; }
        }

        /// <summary>
        /// Property to find IAccept button present on the SMS Admin page
        /// </summary>
        public bool IsPearsonLogoPresent
        {
            get
            {
                return base.IsElementPresent(By.XPath
                    (ConsentPageResource.Consent_Page_Pearson_Logo_Image_XPath_Locator));
            }
        }

        /// <summary>
        /// Accept License Agreement and Privacy Policy SMS by SMS Admin
        /// </summary>
        public void ClickIAcceptButtonBySMSAdmin()
        {
            // Accept License Agreement and Privacy Policy SMS
            logger.LogMethodEntry("ConsentPage", "ClickIAcceptButtonBySMSAdmin",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // select window
                base.SelectWindow(ConsentPageResource.Consent_Page_Window_Page_Name);
                // wait for element to apppear
                base.WaitForElement(By.XPath(ConsentPageResource.
                    Consent_Page_IAccept_Button_Image_XPath_Locator));
                // perform focus on element
                base.PerformFocusOnElementActionByXPath(ConsentPageResource.
                Consent_Page_IAccept_Button_Image_XPath_Locator);
                // web element property
                IWebElement IAcceptButtonProperty = base.GetWebElementPropertiesByXPath
                (ConsentPageResource.
                Consent_Page_IAccept_Button_Image_XPath_Locator);
                // click on button
                base.ClickByJavaScriptExecutor(IAcceptButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ConsentPage", "ClickIAcceptButtonBySMSAdmin",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Accept Button
        /// </summary>
        /// <returns>Accept Button</returns>
        public Boolean IsAcceptButtonPresent()
        {
            //Verfy Accept Button
            logger.LogMethodEntry("ConsentPage", "IsAcceptButtonPresent",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            Boolean isAcceptButtonPresent = false;
            try
            {
                //Select Window
                base.SelectWindow(ConsentPageResource.Consent_Page_Window_Page_Name);
                base.WaitForElement(By.XPath(ConsentPageResource.
                       Consent_Page_IAccept_Button_Image_XPath_Locator));
                //Check for Accept Button
                isAcceptButtonPresent = base.IsElementPresent(By.XPath(ConsentPageResource.
                        Consent_Page_IAccept_Button_Image_XPath_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ConsentPage", "IsAcceptButtonPresent",
                base.IsTakeScreenShotDuringEntryExit);
            return isAcceptButtonPresent;
        }
    }
}
