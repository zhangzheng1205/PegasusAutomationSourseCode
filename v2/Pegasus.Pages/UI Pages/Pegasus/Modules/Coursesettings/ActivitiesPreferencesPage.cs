using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  This class handles Pegasus ActivitiesPreferences Page Actions.
    /// </summary>
    public class ActivitiesPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(ActivitiesPreferencesPage));

        /// <summary>
        /// Save Activity Preferences.
        /// </summary>
        public void SaveActivityPreferences()
        {
            //Save Preferences
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "SaveActivityPreferences", base.isTakeScreenShotDuringEntryExit);
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
                IWebElement getSavePreferences = base.GetWebElementPropertiesByPartialLinkText
                 (LTIToolsPreferencesPageResource.
                        LTIToolsPreferences_Page_SavePreferences_Button_PartialText_Locator);
                getSavePreferences.SendKeys(string.Empty);
                //Click on the Course CMenu 
                base.ClickByJavaScriptExecutor(getSavePreferences);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "SaveActivityPreferences", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity Edit Option.
        /// </summary>
        public void ClickOnActivityEditOption()
        {
            //Click On Activity Edit Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
                "ClickOnActivityEditOption", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Prefernces Window
                base.SelectWindow(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_Preferences_Window_Name);
                base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_Frame_Id_Locator));
                //Switch to Iframe
                base.SwitchToIFrame(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_Frame_Id_Locator);
                //Click On Edit Option
                this.ClickOnEditOption();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "ClickOnActivityEditOption", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Edit Option.
        /// </summary>
        private void ClickOnEditOption()
        {
            //Click On Edit Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "ClickOnEditOption", base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EditButton_Id_Locator));
            //Get Edit Option Property
            IWebElement getEditOptionProperty = base.GetWebElementPropertiesById(
                ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EditButton_Id_Locator);
            //Click On Edit Option
            base.ClickByJavaScriptExecutor(getEditOptionProperty);
            logger.LogMethodExit("ActivitiesPreferencesPage",
                "ClickOnEditOption", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Allow Activity To Be Used As Pretest Or Posttest' Option.
        /// </summary>
        public void SelectAllowActivityToBeUsedAsPretestOrPosttestOption()
        {
            //Select 'Allow Activity To Be Used As Pretest Or Posttest' Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "SelectAllowActivityToBeUsedAsPretestOrPosttestOption", 
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the Activities Link
                new GeneralPreferencesPage().ClickonSubTabofPreference(
                    ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_Activities_Link_PartialText_Locator);
                //Select Preferences Window
                this.SelectPreferencesWindow();
                //Select Iframe
                this.SelectPreferencesMainFrame();
                //Click on the MGM Edit Link
                this.ClickOnMGMTestEditLink();
                LTIDefaultPreferencesPage lTIDefaultPrefrences = 
                    new LTIDefaultPreferencesPage();
                //Select the Option            
                lTIDefaultPrefrences.SelectTheLTIOption();
                lTIDefaultPrefrences.ClickOnApplyAllButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage",
                "SelectAllowActivityToBeUsedAsPretestOrPosttestOption", 
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'MGM Test' Edit Link.
        /// </summary>
        private void ClickOnMGMTestEditLink()
        {
            //Click On 'MGM Test' Edit Link
            logger.LogMethodEntry("ActivitiesPreferencesPage","ClickOnMGMTestEditLink",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the Element
            base.WaitForElement(By.XPath(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EditMathXLTestPreference_Link_Xpath_Locator));
            //Click on the Link
            base.ClickByJavaScriptExecutor(base.
                GetWebElementPropertiesByXPath(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EditMathXLTestPreference_Link_Xpath_Locator));            
            logger.LogMethodExit("ActivitiesPreferencesPage","ClickOnMGMTestEditLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Preferences Window.
        /// </summary>
        private void SelectPreferencesWindow()
        {
            //Select Preferences window
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "SelectPreferencesWindow", base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Preferences_Window_Name);
            //Select Preferences Window
            base.SelectWindow(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Preferences_Window_Name);
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "SelectPreferencesWindow", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Preferences Main Frame.
        /// </summary>
        private void SelectPreferencesMainFrame()
        {
            //Select Preferences Main Frame.
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "SelectPreferencesMainFrame", base.isTakeScreenShotDuringEntryExit);
            //Switch to Iframe
            base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Frame_Id_Locator));
            base.SwitchToIFrame(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Frame_Id_Locator);
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "SelectPreferencesMainFrame", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Remove Multiple Attempt CheckBox.
        /// </summary>
        public void ClickTheRemoveMultipleAttemptCheckBox()
        {
            //Click The Remove Multiple Attempt CheckBox
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "ClickTheRemoveMultipleAttemptCheckBox",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Enable 'Remove Multople attempt Preference                
                new GeneralPreferencesPage().EnableGeneralPreferenceSettings
                    (ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_removeMultipleAttempt_Lock_Id_Locator,
                    ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_removeMultipleAttempt_Checkbox_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "ClickTheRemoveMultipleAttemptCheckBox",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
