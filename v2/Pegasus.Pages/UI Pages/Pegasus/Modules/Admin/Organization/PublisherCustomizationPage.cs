using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.IO;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Organization;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class contains 'Publisher Customization' Page Actions 
    /// </summary>
    public class PublisherCustomizationPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(PublisherCustomizationPage));

        /// <summary>
        /// Check if the Default Contents are Displayed In 'Preferences' Page
        /// </summary>
        /// <returns>True if Default Contents are Displayed In 
        /// 'Preferences' Page otherwise False</returns>
        public Boolean IsDefaultContentsDisplayedInPreferencesPage()
        {
            //Check if the Default Contents are Displayed In 'Preferences' Page
            logger.LogMethodEntry("PublisherCustomizationPage",
                "IsDefaultContentsDisplayedInPreferencesPage",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isDefaultContentsDisplayed = false;
            try
            {
                //Select Preference Frame
                this.SelectPreferenceFrame();               
                //Check if the 'Sign in Page' label is displayed
                bool isSignInPageLabelDisplayed = base.IsElementPresent(By.Id
                    (PublisherCustomizationPageResource.
                    PublisherCustomization_Page_Pref_SigninPage_Text_Id_Locator));
                //Check if the 'Branding Image Text Field' is displayed
                bool isBrandingImageTextFieldDisplayed = base.IsElementPresent(By.Id
                    (PublisherCustomizationPageResource.
                    PublisherCustomization_Page_Pref_Upload_Button_Id_Locator));
                //Check if the 'Welcome Text Field' is displayed
                bool isWelcomeTextFieldDisplayed = base.IsElementPresent(By.Id
                    (PublisherCustomizationPageResource.
                    PublisherCustomization_Page_Pref_Welcome_Text_Id_Locator));               
                //Check if the 'Registration URL Field' is displayed
                bool isRegistrationURLFieldDisplayed = base.IsElementPresent(By.Id
                    (PublisherCustomizationPageResource.
                    PublisherCustomization_Page_Pref_Url_Textbox_Id_Locator));
                //Check if the 'Save Changes Button' is displayed
                bool isSaveChangesButtonDisplayed = base.IsElementPresent(By.Id
                    (PublisherCustomizationPageResource.
                    PublisherCustomization_Page_Pref_Save_Button_Id_Locator));                
                isDefaultContentsDisplayed = isSignInPageLabelDisplayed &&
                    isBrandingImageTextFieldDisplayed && isWelcomeTextFieldDisplayed
                    && isRegistrationURLFieldDisplayed && isSaveChangesButtonDisplayed;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PublisherCustomizationPage",
                "IsDefaultContentsDisplayedInPreferencesPage",
                base.isTakeScreenShotDuringEntryExit);
            return isDefaultContentsDisplayed;
        }

        /// <summary>
        /// Select Preference Frame
        /// </summary>
        private void SelectPreferenceFrame()
        {
            //Select Preference Frame
            logger.LogMethodEntry("PublisherCustomizationPage", "SelectPreferenceFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Wait and Select Preferences window
            base.WaitUntilWindowLoads(PublisherCustomizationPageResource.
                PublisherCustomization_Page_Preference_Window_Name);
            base.SelectWindow(PublisherCustomizationPageResource.
                PublisherCustomization_Page_Preference_Window_Name);
            //Wait for the Frame
            base.WaitForElement(By.Id(PublisherCustomizationPageResource.
                PublisherCustomization_Page_Preference_Frame_Name));
            base.SwitchToIFrame(PublisherCustomizationPageResource.
                PublisherCustomization_Page_Preference_Frame_Name);
            logger.LogMethodExit("PublisherCustomizationPage", "SelectPreferenceFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Upload The Branding Image In Preference
        /// </summary>
        public void UploadBrandingImageInPreference()
        {
            //Upload The Branding Image In Preference
            logger.LogMethodEntry("PublisherCustomizationPage",
                "UploadBrandingImageInPreference",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the upload button
                base.WaitForElement(By.Id(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_Pref_Upload_Button_Id_Locator));
                //Get the Bulk User File Path
                string getBrandingImageFilePath = (AutomationConfigurationManager.TestDataPath
                + PublisherCustomizationPageResource.
                    PublisherCustomization_Page_Pref_Upload_Img_Path).
                    Replace("file:\\", "");                
                //Upload the Branding image
                base.UploadFile(getBrandingImageFilePath,
                    By.Id(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_Pref_Upload_Button_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PublisherCustomizationPage", 
                "UploadBrandingImageInPreference",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Welcome Text And URL
        /// </summary>
        public void FillWelcomeTextAndURL()
        {
            //Fill Welcome Text And URL
            logger.LogMethodEntry("PublisherCustomizationPage",
               "FillWelcomeTextAndURL",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Fill the Welcome text
                base.GetWebElementPropertiesById(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_Pref_Welcome_Text_Id_Locator).Clear();
                base.GetWebElementPropertiesById(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_Pref_Welcome_Text_Id_Locator)
                        .SendKeys(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_WelcomeMessage_Value);
                //Fill the URL text
                base.GetWebElementPropertiesById(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_Pref_Url_Textbox_Id_Locator).Clear();
                base.GetWebElementPropertiesById(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_Pref_Url_Textbox_Id_Locator)
                        .SendKeys(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_URL_Text_Value);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PublisherCustomizationPage",
                "FillWelcomeTextAndURL",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Save Button In PreferenceTab
        /// </summary>
        public void ClickTheSaveButtonInPreferenceTab()
        {
            //Click The Save Button In PreferenceTab
            logger.LogMethodEntry("PublisherCustomizationPage", "ClickTheSaveButtonInPreferenceTab",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_Pref_Save_Button_Id_Locator));
                IWebElement getSaveButton = base.GetWebElementPropertiesById
                (PublisherCustomizationPageResource.
                        PublisherCustomization_Page_Pref_Save_Button_Id_Locator);
                //Click the Save button
                base.ClickByJavaScriptExecutor(getSaveButton);
                base.WaitForElement(By.Id(PublisherCustomizationPageResource.
                    PublisherCustomization_Page_SuccessMessage_Id_Locator));
                //Refresh the Current Page
                base.RefreshTheCurrentPage();
                //Wait for Prefernces Window
                base.WaitUntilWindowLoads(PublisherCustomizationPageResource.
                PublisherCustomization_Page_Preference_Window_Name);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PublisherCustomizationPage", "ClickTheSaveButtonInPreferenceTab",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Welcome Message Displayed In Login Page
        /// </summary>
        /// <returns>Message</returns>
        public string WelcomeMessageDisplayedInLoginPage()
        {
            //Welcome Message Displayed In Login Page
            logger.LogMethodEntry("PublisherCustomizationPage",
               "WelcomeMessageDisplayedInLoginPage",
               base.isTakeScreenShotDuringEntryExit);
            //Intialize the welcome message
            string getWelcomeMessage = string.Empty;
            try
            {
                //Wait for the window
                base.WaitUntilWindowLoads(PublisherCustomizationPageResource.
                    PublisherCustomization_Page_LoginPage_Window_Name);
                base.SelectWindow(PublisherCustomizationPageResource.
                    PublisherCustomization_Page_LoginPage_Window_Name);
                //Wait for the element
                base.WaitForElement(By.Id(PublisherCustomizationPageResource.
                    PublisherCustomization_Page_WelcomeMessage_Id_Locator));
                getWelcomeMessage = base.GetElementTextById(
                    PublisherCustomizationPageResource.
                    PublisherCustomization_Page_WelcomeMessage_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PublisherCustomizationPage",
               "WelcomeMessageDisplayedInLoginPage",
             base.isTakeScreenShotDuringEntryExit);
            return getWelcomeMessage;
        }

        /// <summary>
        /// Check if the Default Contents are Displayed In 'Preferences' Page
        /// </summary>
        /// <returns>True if Default Contents are Displayed In 
        /// 'Preferences' Page otherwise False</returns>
        public Boolean IsBackdoorContentsDisplayedInPreferencesPage()
        {
            //Check if the Default Contents are Displayed In 'Preferences' Page
            logger.LogMethodEntry("PublisherCustomizationPage",
                "IsBackdoorContentsDisplayedInPreferencesPage",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isDefaultContentsDisplayed = false;
            try
            {
                //Select Preference Frame
                this.SelectPreferenceFrame();
                //Check if the 'Sign in Page' label is displayed
                bool isBackdoorSignInPageLabelDisplayed = base.IsElementPresent(By.Id
                    (PublisherCustomizationPageResource.
                    PublisherCustomization_Page_Pref_Backdoor_SigninPage_Text_Id_Locator));
                //Check if the 'Welcome Text Field' is displayed
                bool isBackdoorWelcomeTextFieldDisplayed = base.IsElementPresent(By.Id
                    (PublisherCustomizationPageResource.
                    PublisherCustomization_Page_Pref_Backdoor_Welcome_Text_Id_Locator));
                isDefaultContentsDisplayed = isBackdoorSignInPageLabelDisplayed &&
                    isBackdoorWelcomeTextFieldDisplayed;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PublisherCustomizationPage",
                "IsBackdoorContentsDisplayedInPreferencesPage",
                base.isTakeScreenShotDuringEntryExit);
            return isDefaultContentsDisplayed;
        }

        /// <summary>
        /// Fill Welcome Text And URL
        /// </summary>
        public void FillBackdoorWelcomeText()
        {
            //Fill Welcome Text And URL
            logger.LogMethodEntry("PublisherCustomizationPage",
               "FillBackdoorWelcomeText",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Backdoor signin Welcome text box
                base.WaitForElement(By.Id(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_Pref_Backdoor_Welcome_Text_Id_Locator));
                //Fill the Welcome text
                base.GetWebElementPropertiesById(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_Pref_Backdoor_Welcome_Text_Id_Locator).Clear();
                base.GetWebElementPropertiesById(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_Pref_Backdoor_Welcome_Text_Id_Locator)
                        .SendKeys(PublisherCustomizationPageResource.
                        PublisherCustomization_Page_Backdoor_WelcomeMessage_Value);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PublisherCustomizationPage",
                "FillBackdoorWelcomeText",
              base.isTakeScreenShotDuringEntryExit);
        }

    }
}
