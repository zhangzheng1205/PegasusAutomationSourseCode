using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  This class handles Pegasus StandardSkillPreferences Page Actions
    /// </summary>
    public class StandardSkillPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(StandardSkillPreferencesPage));
        
        /// <summary>
        /// Select Standard Skill Radio Button.
        /// </summary>
        private void SelectStandardSkillRadioButton()
        {
            //Select Standard Skill Radio Button
            logger.LogMethodEntry("StandardSkillPreferencesPage",
              "SelectStandardSkillRadioButton", base.IsTakeScreenShotDuringEntryExit);
            //Wait For The Skills and Standards radio Button
            base.WaitForElement(By.Id(StandardSkillPreferencesPageResource.
                StandardSkillPreferences_Page_SkillsandStandards_RadioButton_Id_Locator));
            IWebElement getSkillstandard = base.GetWebElementPropertiesById
                (StandardSkillPreferencesPageResource.
                StandardSkillPreferences_Page_SkillsandStandards_RadioButton_Id_Locator);
            //Enble The Skills and Standards radio Button
            base.ClickByJavaScriptExecutor(getSkillstandard);
            logger.LogMethodExit("StandardSkillPreferencesPage",
              "SelectStandardSkillRadioButton", base.IsTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Click The Skill Standard Add framework Button.
        /// </summary>
        /// <param name="addFrameworkButtonId">This is Add Framework Button Id.</param>
        /// <param name="frameId">This is Iframe Id.</param>
        private void ClickTheSkillstandardAddFrameworkButton(string frameId, 
            string addFrameworkButtonId)
        {
            //Click The Add framework Button
            logger.LogMethodEntry("StandardSkillPreferencesPage",
             "ClickTheSkillstandardAddFrameworkButton", 
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(frameId));
            //Switch To Skills Iframe
            base.SwitchToIFrame(frameId);
            //Wait For The Add Framework link
            base.WaitForElement(By.Id(addFrameworkButtonId));
            IWebElement getAddSkillFramework = base.GetWebElementPropertiesById
                (addFrameworkButtonId);
            base.ClickByJavaScriptExecutor(getAddSkillFramework);
            logger.LogMethodExit("StandardSkillPreferencesPage",
              "ClickTheSkillstandardAddFrameworkButton", 
              base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Save Preferences
        /// </summary>
        public void SaveSkillPreferences()
        {
            //Save Skill Preferences
            logger.LogMethodEntry("StandardSkillPreferencesPage",
               "SaveSkillPreferences", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(Convert.ToInt32(StandardSkillPreferencesPageResource.
                    StandardSkillPreferences_Page_ThreadSleep_Value));
                //Select Default Window
                base.SelectWindow(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_WindowName);
                //Select Iframe
                base.SwitchToIFrame(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_PreferencesPage_Iframe_Id_Locator);
                //Wait For Save Preferences Button
                base.WaitForElement(By.PartialLinkText(LTIToolsPreferencesPageResource.
                        LTIToolsPreferences_Page_SavePreferences_Button_PartialText_Locator),
                        Convert.ToInt32(LTIToolsPreferencesPageResource.
                        LTIToolsPreferences_Page_TimeToWait_Value));
                //Get HTML Element Property for Cmenu
                IWebElement SavePreferences = base.GetWebElementPropertiesByPartialLinkText
                 (LTIToolsPreferencesPageResource.
                        LTIToolsPreferences_Page_SavePreferences_Button_PartialText_Locator);
                SavePreferences.SendKeys(string.Empty);
                //Click on the Course CMenu 
                base.ClickByJavaScriptExecutor(SavePreferences);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StandardSkillPreferencesPage",
               "SaveSkillPreferences", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set The Course Standard Skill Preferences.
        /// </summary>
        /// <param name="skillFrameName">This is SkillFramework Name.</param>
        /// <param name="StandardFrameName">This is StandardFramework Name.</param>
        public void SetTheCourseStandardSkillPreferences(string skillFrameName,
            string StandardFrameName)
        {
            // Set The Course Standard Skill Preferences
            logger.LogMethodEntry("StandardSkillPreferencesPage",
              "SetTheCourseStandardSkillPreferences", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                StandardSkillsGridPage standardSkillsGridpPage = new StandardSkillsGridPage();
                //Select Standard Skill Radio Button
                this.SelectStandardSkillRadioButton();
                //Click The Skill Addframework Button
                this.ClickTheSkillstandardAddFrameworkButton(
                    StandardSkillPreferencesPageResource.
                StandardSkillPreferences_Page_Skill_Iframe, 
                StandardSkillPreferencesPageResource.
                StandardSkillPreferences_Page_SkillStandard_AddFramework_Button_Id_Locator);
                //Select Skill framework
                standardSkillsGridpPage.SelectSkillFramework(skillFrameName);
                //Select the preferences window
                new GeneralPreferencesPage().SelectThePreferenceWindowWithFrame();
                //Click The Standard Addframework Button
                this.ClickTheSkillstandardAddFrameworkButton
                    (StandardSkillPreferencesPageResource.
                    StandardSkillPreferences_Page_Standard_Iframe, 
                    StandardSkillPreferencesPageResource.
                StandardSkillPreferences_Page_SkillStandard_AddFramework_Button_Id_Locator);
                //Select Skill framework
                standardSkillsGridpPage.SelectStandardFramework(StandardFrameName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StandardSkillPreferencesPage",
              "SetTheCourseStandardSkillPreferences", base.IsTakeScreenShotDuringEntryExit);
        } 
    }
}
