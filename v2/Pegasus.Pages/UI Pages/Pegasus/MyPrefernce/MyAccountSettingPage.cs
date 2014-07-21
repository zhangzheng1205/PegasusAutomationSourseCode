using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.MyPrefernce;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the MyAccountSetting Page Actions
    /// </summary>
    public class MyAccountSettingPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(MyAccountSettingPage));

        /// <summary>
        /// Changing the Time Zone.
        /// </summary>
        /// <param name="timeZone">This is TimeZone.</param>
        public void ChangeTimeZoneInMyProfile(string timeZone)
        {
            //Change of Time Zone 
            logger.LogMethodEntry("MyAccountSettingPage", "ChangeTimeZoneInMyProfile",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Changing the Time Zone                
                base.WaitForElement(By.XPath(MyAccountSettingPageResource.
                    MyAccountSetting_Page_MyProfile_Frame_Xpath_Locator));
                //Get properties of IFrame
                IWebElement frameProperties = base.GetWebElementPropertiesByXPath
                    (MyAccountSettingPageResource.
                    MyAccountSetting_Page_MyProfile_Frame_Xpath_Locator);
                //Switching to Frame
                base.SwitchToIFrameByWebElement(frameProperties);
                base.WaitForElement(By.Id(MyAccountSettingPageResource.
                    MyAccountSetting_Page_TimeZone_DropDown_Id_Locator));
                // Select TimeZone from Drop down
                base.SelectDropDownValueThroughTextById(MyAccountSettingPageResource.
                    MyAccountSetting_Page_TimeZone_DropDown_Id_Locator, timeZone);               
                base.WaitForElement(By.Id(MyAccountSettingPageResource.
                    MyAccountSetting_Page_Save_Button_Id_Locator));
                //Click Save Button
                base.FocusOnElementByID(MyAccountSettingPageResource.
                    MyAccountSetting_Page_Save_Button_Id_Locator);
                IWebElement getSaveButtonProperties=base.GetWebElementPropertiesById(
                    MyAccountSettingPageResource.MyAccountSetting_Page_Save_Button_Id_Locator);
                //Click on button
                base.ClickByJavaScriptExecutor(getSaveButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyAccountSettingPage", "ChangeTimeZoneInMyProfile",
               base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Changing the Time Zone To India
        /// </summary>
        /// <param name="timeZone">This is TimeZone</param>
        public void ChangeTimeZoneInCsAdminMyProfile(string timeZone)
        {
            //Change of Time Zone 
            logger.LogMethodEntry("MyAccountSettingPage", "ChangeTimeZoneInCsAdminMyProfile",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Switch To Default Page Element
                base.SwitchToDefaultPageContent();
                //Changing the Time Zone in Dp instance
                base.WaitForElement(By.Id(MyAccountSettingPageResource.
                    MyAccountSetting_DpPage_MyProfile_Frame_Id_Locator));
                //Switching to Frame
                base.SwitchToIFrame(MyAccountSettingPageResource.
                    MyAccountSetting_DpPage_MyProfile_Frame_Id_Locator);
                base.WaitForElement(By.Id(MyAccountSettingPageResource.
                    MyAccountSetting_Page_TimeZone_DropDown_Id_Locator));
                // Select TimeZone from Drop down
                base.SelectDropDownValueThroughTextById(MyAccountSettingPageResource.
                    MyAccountSetting_Page_TimeZone_DropDown_Id_Locator, timeZone);
                //Click Save Button
                base.FocusOnElementByID(MyAccountSettingPageResource.
                    MyAccountSetting_Page_Save_Button_Id_Locator);
                //Click on Button
                base.ClickButtonByID(MyAccountSettingPageResource.
                    MyAccountSetting_Page_Save_Button_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyAccountSettingPage", "ChangeTimeZoneInCsAdminMyProfile",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Change User Profile Settings
        /// </summary>
        public void ChangeUserProfileSettings()
        {
            //Change User Profile Settings
            logger.LogMethodEntry("MyAccountSettingPage", "ChangeUserProfileSettings",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Close the Current Browser Window
                base.CloseBrowserWindow();
                //Select the Default Window
                base.SelectDefaultWindow();
                //Change the Locale Prefernces
                this.ChangeLocalePrefernces(MyAccountSettingPageResource.
                        MyAccountSetting_Page_LocaleOption_EnglishUnitedKingdom_Value);
                Thread.Sleep(Convert.ToInt32(MyAccountSettingPageResource.
                    MyAccountSetting_Page_WaitTime));
                //Change Help Language
                this.ChangeHelpLanguage(MyAccountSettingPageResource.
                    MyAccountSetting_Page_OnScreenLanguageOption_Japanese_Value);
                Thread.Sleep(Convert.ToInt32(MyAccountSettingPageResource.
                    MyAccountSetting_Page_WaitTime));
                //Change Locale Prefernces Number Value
                this.ChangeLocalePrefernceNumberValue();
                Thread.Sleep(Convert.ToInt32(MyAccountSettingPageResource.
                    MyAccountSetting_Page_WaitTime));
                //Change Locale Prefernce Number Value
                this.ChangeLocalePrefernceTimeDisplay();
                Thread.Sleep(Convert.ToInt32(MyAccountSettingPageResource.
                    MyAccountSetting_Page_WaitTime));
                //Change Localse Prefernces Date display
                this.ChangeLocalePreferenceDateDisplay();
                Thread.Sleep(Convert.ToInt32(MyAccountSettingPageResource.
                    MyAccountSetting_Page_WaitTime));
                //Change Locale Prefernces Long Date
                this.ChangeLocalePreferenceLongDate();
                Thread.Sleep(Convert.ToInt32(MyAccountSettingPageResource.
                    MyAccountSetting_Page_WaitTime));
                base.SelectDefaultWindow();
                //Change Time Zone
                this.ChangeTimeZoneInMyProfile(MyAccountSettingPageResource.
                    MyAccountSetting_Page_ManageAnnouncement_MyProfile_IndianTimeZone_Value);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyAccountSettingPage", "ChangeUserProfileSettings",
              base.isTakeScreenShotDuringEntryExit);
        }
        

        /// <summary>
        /// Change Locale Preferences
        /// </summary>
        /// <param name="timeFormat">This is Time Format</param>
        public void ChangeLocalePrefernces(string timeFormat)
        {
            //Change Locale Preferences
            logger.LogMethodEntry("MyAccountSettingPage", "ChangeLocalPrefernces",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Changing the Time Zone                
                base.WaitForElement(By.XPath(MyAccountSettingPageResource.
                    MyAccountSetting_Page_MyProfile_Frame_Xpath_Locator));
                //Get properties of IFrame
                IWebElement frameProperties = base.GetWebElementPropertiesByXPath
                    (MyAccountSettingPageResource.
                    MyAccountSetting_Page_MyProfile_Frame_Xpath_Locator);
                //Switching to Frame
                base.SwitchToIFrameByWebElement(frameProperties);
                base.WaitForElement(By.Id(MyAccountSettingPageResource.
                    MyAccountSetting_Page_LocalePreferences_Id_Locator));
                //Select Time Format
                base.SelectDropDownValueThroughTextById(MyAccountSettingPageResource.
                    MyAccountSetting_Page_LocalePreferences_Id_Locator, timeFormat);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("MyAccountSettingPage", "ChangeLocalPrefernces",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Change Screen Language
        /// </summary>
        /// <param name="languageType">This is Language Type</param>
        private void ChangeScreenLanguage(string languageType)
        {
            //Change Screen Language
            logger.LogMethodEntry("MyAccountSettingPage", "ChangeScreenLanguage",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MyAccountSettingPageResource.
                MyAccountSetting_Page_ScreenLanguage_Id_Locator));
            //Select Language
            base.SelectDropDownValueThroughTextById(MyAccountSettingPageResource.
                MyAccountSetting_Page_ScreenLanguage_Id_Locator, languageType);
            logger.LogMethodExit("MyAccountSettingPage", "ChangeScreenLanguage",
               base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Change Help Language
        /// </summary>
        /// <param name="helpLanguageType">This is Help Language Type</param>
        private void ChangeHelpLanguage(string helpLanguageType)
        {
            //Change Help Language
            logger.LogMethodEntry("MyAccountSettingPage", "ChangeHelpLanguage",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MyAccountSettingPageResource.
                MyAccountSetting_Page_HelpLanguage_Id_Locator));
            //Select Help Language
            base.SelectDropDownValueThroughTextById(MyAccountSettingPageResource.
                MyAccountSetting_Page_HelpLanguage_Id_Locator, helpLanguageType);
            logger.LogMethodExit("MyAccountSettingPage", "ChangeHelpLanguage",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Change Locale Perefernce Number Value
        /// </summary>
        private void ChangeLocalePrefernceNumberValue()
        {
            //Change Locale Perefernce Number Value
            logger.LogMethodEntry("MyAccountSettingPage", "ChangeLocalePrefernceNumberValue",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MyAccountSettingPageResource.
                MyAccountSetting_Page_LocalePrefernceNumber_Id_Locator));
            //Select Locale Prefernce Number Value
            base.SelectDropDownValueThroughIndexById(MyAccountSettingPageResource.
                MyAccountSetting_Page_LocalePrefernceNumber_Id_Locator, Convert.ToInt32(MyAccountSettingPageResource.
                MyAccountSetting_Page_LocalePrefernces_DropDownValue));
            logger.LogMethodExit("MyAccountSettingPage", "ChangeLocalePrefernceNumberValue",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Change Locale Prefernce Time Display
        /// </summary>
        private void ChangeLocalePrefernceTimeDisplay()
        {
            //Change Locale Prefernce Time Display
            logger.LogMethodEntry("MyAccountSettingPage", "ChangeLocalePrefernceTimeDisplay",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MyAccountSettingPageResource.
                MyAccountSetting_Page_LocaleTimeDisplay_Id_Locator));
            //Change Locale Prefernce Time Display
            base.SelectDropDownValueThroughIndexById(MyAccountSettingPageResource.
                MyAccountSetting_Page_LocaleTimeDisplay_Id_Locator, 
                Convert.ToInt32(MyAccountSettingPageResource.
                MyAccountSetting_Page_LocalePrefernces_DropDownValue));
            logger.LogMethodExit("MyAccountSettingPage", "ChangeLocalePrefernceTimeDisplay",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Change Locale Prefernce Date Display
        /// </summary>
        private void ChangeLocalePreferenceDateDisplay()
        {
            //Change Locale Prefernce Date Display
            logger.LogMethodEntry("MyAccountSettingPage", "ChangeLocalePreferenceDateDisplay",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MyAccountSettingPageResource.
                MyAccountSetting_Page_LocaleDateDisplay_Id_Locator));
            //Change Locale Prefernce Date Display
            base.SelectDropDownValueThroughIndexById(MyAccountSettingPageResource.
                MyAccountSetting_Page_LocaleDateDisplay_Id_Locator,
                Convert.ToInt32(MyAccountSettingPageResource.
                MyAccountSetting_Page_LocalePrefernces_DropDownValue));
            logger.LogMethodExit("MyAccountSettingPage", "ChangeLocalePreferenceDateDisplay",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Change Locale prefernce Long Date
        /// </summary>
        private void ChangeLocalePreferenceLongDate()
        {
            //Change Locale prefernce Long Date
            logger.LogMethodEntry("MyAccountSettingPage", "ChangeLocalePreferenceLongDate",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MyAccountSettingPageResource.
                MyAccountSetting_Page_LocaleLongDate_Id_Locator));
            //Change Locale prefernce Long Date
            base.SelectDropDownValueThroughIndexById(MyAccountSettingPageResource.
                MyAccountSetting_Page_LocaleLongDate_Id_Locator, 
                Convert.ToInt32(MyAccountSettingPageResource.
                MyAccountSetting_Page_LocalePrefernces_DropDownValue));
            logger.LogMethodExit("MyAccountSettingPage", "ChangeLocalePreferenceLongDate",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Edit Pearson Account
        /// </summary>
        public void ClickOnEditPearsonAccountOption()
        {
            //Click On Edit Pearson Account Option
            logger.LogMethodEntry("MyAccountSettingPage", "ClickOnEditPearsonAccountOption",
               base.isTakeScreenShotDuringEntryExit);
            try
            {            
                //Wait for the Frame                
                base.WaitForElement(By.XPath(MyAccountSettingPageResource.
                    MyAccountSetting_Page_MyProfile_Frame_Xpath_Locator));
                //Get properties of IFrame
                IWebElement frameProperties = base.GetWebElementPropertiesByXPath
                    (MyAccountSettingPageResource.
                    MyAccountSetting_Page_MyProfile_Frame_Xpath_Locator);
                //Switch To Frame
                base.SwitchToIFrameByWebElement(frameProperties);
                base.WaitForElement(By.Id(MyAccountSettingPageResource.
                    MyAccountSetting_Page_EditPearsonAccount_Id_Locator));
                IWebElement getEditPearsonAccount=base.GetWebElementPropertiesById
                    (MyAccountSettingPageResource.
                    MyAccountSetting_Page_EditPearsonAccount_Id_Locator);
                //Click on Edit Pearson Account
                base.ClickByJavaScriptExecutor(getEditPearsonAccount);
                //Wait for Log In to your pearson account profile window
                base.WaitUntilWindowLoads(MyAccountSettingPageResource.
                    MyAccountSetting_Page_LogIntoyourPearsonAccountProfile_Window_Name);
                //Select Log In to your pearson account profile window
                base.SelectWindow(MyAccountSettingPageResource.
                    MyAccountSetting_Page_LogIntoyourPearsonAccountProfile_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyAccountSettingPage", "ClickOnEditPearsonAccountOption",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get My Profile Frame Options
        /// </summary>
        /// <returns>MyProfileFrameOptions</returns>
        public String GetMyProfileFrameOptions()
        {
            //Get My Profile Frame Options
            logger.LogMethodEntry("MyAccountSettingPage", "GetMyProfileFrameOptions",
               base.isTakeScreenShotDuringEntryExit);
            //Get My Profile Frame Options
            string getMyProfileFrameOptions = string.Empty;
            //Get My Profile Text
            string getMyProfileText = string.Empty;
            //Get My Pearson Account
            string getMyPearsonAccountText = string.Empty;
            //Get Time Zone Text
            string getTimeZoneText = string.Empty;
            //Get Localization Text
            string getLocalizationText = string.Empty;
            try
            {
                //Switch to Iframe
                this.SwitchToIFrame();
                //Get MyProfile Text
                getMyProfileText = base.GetElementTextByID(MyAccountSettingPageResource.
                    MyAccountSetting_Page_MyProfile_Id_Locator);
                //Get Pearson Account Text
                getMyPearsonAccountText = base.GetElementTextByID(MyAccountSettingPageResource.
                    MyAccountSetting_Page_MyPearsonAccount_Id_Locator);
                //Get Time Zone Text
                getTimeZoneText = base.GetElementTextByID(MyAccountSettingPageResource.
                    MyAccountSetting_Page_TimeZone_Id_Locator);
                //Get Localization Text
                getLocalizationText = base.GetElementTextByID(MyAccountSettingPageResource.
                    MyAccountSetting_Page_Localization_Id_Locator);
                base.RefreshTheCurrentPage();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyAccountSettingPage", "GetMyProfileFrameOptions",
             base.isTakeScreenShotDuringEntryExit);
            return getMyProfileFrameOptions = getMyProfileText + getMyPearsonAccountText 
                + getTimeZoneText + getLocalizationText;
        }              

        /// <summary>
        /// Switch To IFrame
        /// </summary>
        private void SwitchToIFrame()
        {
            //Switch to Iframe
            logger.LogMethodEntry("MyAccountSettingPage", "SwitchToIFrame",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(MyAccountSettingPageResource.
                    MyAccountSetting_Page_MyProfile_Frame_Xpath_Locator));
            //Get properties of IFrame
            IWebElement frameProperties = base.GetWebElementPropertiesByXPath
                (MyAccountSettingPageResource.
                MyAccountSetting_Page_MyProfile_Frame_Xpath_Locator);
            //Switching to Frame
            base.SwitchToIFrameByWebElement(frameProperties);
            logger.LogMethodExit("MyAccountSettingPage", "SwitchToIFrame",
             base.isTakeScreenShotDuringEntryExit);
        }
    }
}
