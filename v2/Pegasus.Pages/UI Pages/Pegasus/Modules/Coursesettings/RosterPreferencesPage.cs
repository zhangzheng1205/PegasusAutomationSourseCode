using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    // <summary>
    /// This Class Handles Roster Preferences Page Actions
    /// </summary>
    public class RosterPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(RosterPreferencesPage));

        /// <summary>
        /// Enable Roster Preference
        /// </summary>
        public void EnableRosterPreference()
        {
            //Enable Roster Preference
            logger.LogMethodEntry("RosterPreferencesPage", "EnableRosterPreference",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for element
                base.WaitForElement(By.Id(RosterPreferencesPageResource.
                    RosterPreferences_Page_Frame_Id_Locator));
                //Switch to frame
                base.SwitchToIFrame(RosterPreferencesPageResource.
                    RosterPreferences_Page_Frame_Id_Locator);
                base.WaitForElement(By.Id(RosterPreferencesPageResource.
                    RosterPreferences_Page_Roster_Checkbox_Id_Locator));
                if (!base.IsElementSelectedById(RosterPreferencesPageResource.
                    RosterPreferences_Page_Roster_Checkbox_Id_Locator))
                {
                    //Get element property
                    IWebElement getRosterCheckbox = base.GetWebElementPropertiesById
                        (RosterPreferencesPageResource.
                        RosterPreferences_Page_Roster_Checkbox_Id_Locator);
                    //Click checkbox
                    base.ClickByJavaScriptExecutor(getRosterCheckbox);
                }
                base.WaitForElement(By.Id(RosterPreferencesPageResource.
                    RosterPreferences_Page_RegistrationURL_Textbox_Id_Locator));
                //Clear Textbox
                base.ClearTextByID(RosterPreferencesPageResource.
                    RosterPreferences_Page_RegistrationURL_Textbox_Id_Locator);
                //Enter Regestration URL
                base.FillTextBoxByID(RosterPreferencesPageResource.
                    RosterPreferences_Page_RegistrationURL_Textbox_Id_Locator, 
                    RosterPreferencesPageResource.RosterPreferences_Page_RegistrationURL_Value);
                base.WaitForElement(By.PartialLinkText(RosterPreferencesPageResource.
                    RosterPreferences_Page_SavePreferences_Button_Id_Locator));
                //Click on save preferences button
                base.ClickButtonByPartialLinkText(RosterPreferencesPageResource.
                    RosterPreferences_Page_SavePreferences_Button_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RosterPreferencesPage", "EnableRosterPreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Manage Roster Preference Settings.
        /// </summary>
        public void SelectManageRosterPreferenceSettings()
        {
            //Select Manage Roster Preference Settings
            logger.LogMethodEntry("RosterPreferencesPage",
                "SelectManageRosterPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select The Enable Manage Roster
                new GeneralPreferencesPage().EnableGeneralPreferenceSettings
                    (RosterPreferencesPageResource.
                    RosterPreferences_Page_ManageRoster_Lock_Id_Locator,
                    RosterPreferencesPageResource.
                        RosterPreferences_Page_Roster_Checkbox_Id_Locator);
            }
            catch (Exception e)
            {                
              ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RosterPreferencesPage",
                "SelectManageRosterPreferenceSettings",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
