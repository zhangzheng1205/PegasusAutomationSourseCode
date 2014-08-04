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
    ///  This class handles Pegasus LTIDefaultPreferences Page Actions
    /// </summary>
    class LTIDefaultPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(LTIDefaultPreferencesPage));

        /// <summary>
        /// Select 'LTI Default Preferences' Window.
        /// </summary>
        private void SelectLTIDefaultPreferencesWindow()
        {
            //Select 'Default Preferences' Window
            logger.LogMethodEntry("LTIDefaultPreferencesPage",
                "SelectLTIDefaultPreferencesWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Select 'LTI Default Preferences' window
            base.WaitUntilWindowLoads(string.Empty);
            base.SelectWindow(string.Empty);
            logger.LogMethodExit("LTIDefaultPreferencesPage",
               "SelectLTIDefaultPreferencesWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The LTI Option.
        /// </summary>        
        public void SelectTheLTIOption()
        {
            //Select The LTI Option.
            logger.LogMethodEntry("LTIDefaultPreferencesPage", "SelectTheLTIOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select 'LTI Default Preferences' Window
                this.SelectLTIDefaultPreferencesWindow();
                base.WaitForElement(By.Id(LTIDefaultPreferencesPageResource.
                    LTIDefaultPreferences_Page_ActivityAsPreTestPostTest_CheckBox_Id_Locator));
                //Get Checkbox status
                bool getElementStatus = base.IsElementSelected(By.Id(
                    LTIDefaultPreferencesPageResource.
                    LTIDefaultPreferences_Page_ActivityAsPreTestPostTest_CheckBox_Id_Locator));
                if (!getElementStatus)
                {                    
                    //Select the option
                    this.SelectTheOption(LTIDefaultPreferencesPageResource.
                        LTIDefaultPreferences_Page_Allow_ActivityAsPretest_Posttest_Option_Text);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("LTIDefaultPreferencesPage", "SelectTheLTIOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Option.
        /// </summary>
        /// <param name="optionName">This is Option Text</param>        
        private void SelectTheOption(string optionName)
        {
            //Select The Option
            logger.LogMethodEntry("LTIDefaultPreferencesPage", "SelectTheOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the Total options count
            int getTotalCount =
                base.GetElementCountByXPath(LTIDefaultPreferencesPageResource.
                LTIDefaultPreferences_Page_LTIPreferences_Div_XPath_Locator);
            for (int rowCount = Convert.ToInt32(LTIDefaultPreferencesPageResource.
                LTIDefaultPreferences_Page_Loop_Initializer_Value);
                rowCount <= getTotalCount; rowCount++)
            {
                //Get the Option Name
                string getOptionText = base.GetElementTextByXPath(String.Format(
                    LTIDefaultPreferencesPageResource.
                    LTIDefaultPreferences_Page_LTIPreferences_Option_Text_XPath_Locator, rowCount));
                if (getOptionText.Contains(optionName))
                {
                    this.UnLockTheOptionIfLocked(rowCount);
                    //Click on the Check box                    
                    base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                        String.Format(LTIDefaultPreferencesPageResource.
                        LTIDefaultPreferences_Page_LTIPreferences_Option_Checkbox_XPath_Locator,
                        rowCount)));                    
                    break;
                }
            }
            logger.LogMethodExit("LTIDefaultPreferencesPage", "SelectTheOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// UnLock The Option If Locked.
        /// </summary>
        /// <param name="rowCount">This is Option Row Count</param>
        private void UnLockTheOptionIfLocked(int rowCount)
        {
            //UnLock The Option If Locked
            logger.LogMethodEntry("LTIDefaultPreferencesPage", "UnLockTheOptionIfLocked",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Lock status
            base.WaitForElement(By.XPath(String.Format(LTIDefaultPreferencesPageResource.
                LTIDefaultPreferences_Page_LTIPreferences_Lock_Status_XPath_Locator,
                rowCount)));
            string getLockStatus = base.GetElementTextByXPath(String.Format(
                LTIDefaultPreferencesPageResource.
                LTIDefaultPreferences_Page_LTIPreferences_Lock_Status_XPath_Locator,
                rowCount));
            if (getLockStatus == LTIDefaultPreferencesPageResource.
                LTIDefaultPreferences_Page_LTIPreferences_Lock_Unavailable_Text)
            {
                //Click on the Lock Icon                        
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                    String.Format(LTIDefaultPreferencesPageResource.
                    LTIDefaultPreferences_Page_LTIPreferences_Lock_Icon_XPath_Locator,
                    rowCount)));
                Thread.Sleep(Convert.ToInt32(LTIDefaultPreferencesPageResource.
                    LTIDefaultPreferences_Page_Sleep_TimeToWait_Value));
            }
            logger.LogMethodExit("LTIDefaultPreferencesPage", "UnLockTheOptionIfLocked",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Apply to All button.
        /// </summary>
        public void ClickOnApplyAllButton()
        {
            //Click on the 'Apply to All' button
            logger.LogMethodEntry("LTIDefaultPreferencesPage",
                "ClickOnApplyAllButton",base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the 'Apply to All' button
                base.WaitForElement(By.Id(LTIDefaultPreferencesPageResource.
                    LTIDefaultPreferences_Page_ApplyToAll_Button_ID_Locator));
                base.ClickByJavaScriptExecutor(base.
                    GetWebElementPropertiesById(LTIDefaultPreferencesPageResource.
                    LTIDefaultPreferences_Page_ApplyToAll_Button_ID_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("LTIDefaultPreferencesPage",
               "ClickOnApplyAllButton",base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
