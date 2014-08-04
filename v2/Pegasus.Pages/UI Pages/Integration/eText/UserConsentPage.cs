using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.eText;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Page Handles User Consent Page actions.
    /// </summary>
    public class UserConsentPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(UserConsentPage));

        /// <summary>
        /// Accept Agreement.
        /// </summary>
        public void AcceptAgreement()
        {
            //Accept Agreement
            Logger.LogMethodEntry("UserConsentPage", "AcceptAgreement",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Check expected window is exist for 10 second
                bool isPopupPresent = base.IsPopupPresent(UserConsentPageResource.
                UserConsent_Page_Window_Name, Convert.ToInt32
                (UserConsentPageResource.UserConsent_Page_Window_Load_WaitTime));
                //Validate Accept Agreement page is exist or not
                if (isPopupPresent)
                {
                    //Select Window
                    this.SelectEndUserLicenseAgreementAndPrivacyPolicyWindow();
                    //Wait For Element
                    base.WaitForElement(By.Id(UserConsentPageResource.
                        UserConsent_Page_SubmitButton_Id_Locator));
                    //Get Button Property
                    IWebElement getButtonProperty =
                        base.GetWebElementPropertiesById(UserConsentPageResource.
                        UserConsent_Page_SubmitButton_Id_Locator);
                    //Click on Button
                    base.ClickByJavaScriptExecutor(getButtonProperty);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("UserConsentPage", "AcceptAgreement",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select EText Launch Window.
        /// </summary>
        private void SelectEndUserLicenseAgreementAndPrivacyPolicyWindow()
        {
            Logger.LogMethodEntry("UserConsentPage",
                "SelectEndUserLicenseAgreementAndPrivacyPolicyWindow",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window Loads
            base.WaitUntilWindowLoads(UserConsentPageResource.
                UserConsent_Page_Window_Name);
            //Select Window
            base.SelectWindow(UserConsentPageResource.
                 UserConsent_Page_Window_Name);
            Logger.LogMethodExit("UserConsentPage",
                 "SelectEndUserLicenseAgreementAndPrivacyPolicyWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
