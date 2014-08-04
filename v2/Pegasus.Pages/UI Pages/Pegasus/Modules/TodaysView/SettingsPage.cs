using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TodaysView;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Settings Page Actions
    /// </summary>
    public class SettingsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(SettingsPage));

        /// <summary>
        /// Enable the New Grades Option
        /// </summary>
        public void EnableNewGradesOption()
        {
            //Enabling the New Grades Option
            logger.LogMethodEntry("SettingsPage", "EnableNewGradesOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to Frame
                base.SwitchToIFrame(SettingsPageResource.SettingsPageResource_Frame_Id_Locator);
                //Focus on the New Grades Link option
                base.WaitForElement(By.Id(SettingsPageResource.
                    SettingsPageResource_Checkbox_NewGrades_Id_Locator));
                base.GetWebElementPropertiesById(SettingsPageResource.
                    SettingsPageResource_Checkbox_NewGrades_Id_Locator).SendKeys(string.Empty);
                //Check if the New Grades Checkbox is displayed with text 
                if (base.IsElementDisplayedById(SettingsPageResource.
                    SettingsPageResource_Checkbox_NewGrades_Id_Locator))
                {
                    //Click on the New Grades Checkbox with text 
                    base.SelectCheckBoxById(SettingsPageResource.
                     SettingsPageResource_Checkbox_NewGrades_Id_Locator);
                    //Clicking on the Save and Close button
                    ClickToSaveAndCloseButton();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SettingsPage", "EnableNewGradesOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on the Save and Close button in the Customize Notifications page
        /// </summary>
        private void ClickToSaveAndCloseButton()
        {
            //Saving the settings for New Grades
            logger.LogMethodEntry("SettingsPage", "ClickToSaveAndCloseButton",
                base.IsTakeScreenShotDuringEntryExit);
            IWebElement getSaveCloseButton = base.GetWebElementPropertiesByPartialLinkText
                (SettingsPageResource.
                SettingsPageResource_Button_SaveandClose_Title);
            //Click on the Save and Close Link Button
            base.ClickByJavaScriptExecutor(getSaveCloseButton);
            base.IsPopUpClosed(2);
            logger.LogMethodExit("SettingsPage", "ClickToSaveAndCloseButton",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
