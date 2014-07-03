using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  This class handles Pegasus ToolbarPreferencesPage Page Actions.
    /// </summary>
    public class ToolbarPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(ToolbarPreferencesPage));

        /// <summary>
        /// Click On Assignment Calendar Display as Main Tab Link.
        /// </summary>
        public void ClickOnAssignmentCalendarDisplayLink()
        {
            //Click On Assignment Calendar Display as Main Tab Link
            logger.LogMethodEntry("ToolbarPreferencesPage",
                "ClickOnAssignmentCalendarDisplayLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window and Frame
                new GeneralPreferencesPage().SelectThePreferenceWindowWithFrame();
                //Click On Assignment Calendar Display Link
                ClickOnTheAssignmentCalendarDisplayLink();
                base.WaitForElement(By.Id(ToolbarPreferencesPageResource.
                    ToolbarPreferences_Page_AssignmentCalendar_Checkbox_Id_Locator));
                //Get Assignment Calendar Checkbox Property
                IWebElement getAssignmentCalendarCheckbox=base.GetWebElementPropertiesById
                    (ToolbarPreferencesPageResource.
                    ToolbarPreferences_Page_AssignmentCalendar_Checkbox_Id_Locator);
                //Select Assignment Calendar Checkbox
                base.ClickByJavaScriptExecutor(getAssignmentCalendarCheckbox);               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ToolbarPreferencesPage",
                "ClickOnAssignmentCalendarDisplayLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Assignment Calendar Display Link.
        /// </summary>
        public void ClickOnTheAssignmentCalendarDisplayLink()
        {
            //Click On Assignment Calendar Display Link
            logger.LogMethodEntry("ToolbarPreferencesPage",
                "ClickOnTheAssignmentCalendarDisplayLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {               
                base.WaitForElement(By.XPath(ToolbarPreferencesPageResource.
                    ToolbarPreferences_Page_AssignmentCalendarDisplay_Link_Xpath_Locator));
                //Get Assignment Calendar Display Link Property
                IWebElement getCalendarDisplayLink = base.GetWebElementPropertiesByXPath
                    (ToolbarPreferencesPageResource.
                    ToolbarPreferences_Page_AssignmentCalendarDisplay_Link_Xpath_Locator);
                //Click on Assignment Calendar Display Link
                base.ClickByJavaScriptExecutor(getCalendarDisplayLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ToolbarPreferencesPage",
                "ClickOnTheAssignmentCalendarDisplayLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Tab Display as Main Tab.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>
        /// <returns>Status Of Display Of Tab.</returns>
        public bool IsTabDisplayAsMainTab(string tabName)
        {
            //Verify Tab Display as Main Tab
            logger.LogMethodEntry("ToolbarPreferencesPage",
                 "IsTabDisplayAsMainTab",
                 base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isTabPresent = false;
            string getTabsName = string.Empty;
            try
            {
                base.WaitForElement(By.Id(ToolbarPreferencesPageResource.
                        ToolbarPreferences_Page_MainTabs_Name_Id_Locator));
                //Get Tabs Name
                getTabsName = base.GetElementTextByID(ToolbarPreferencesPageResource.
                    ToolbarPreferences_Page_MainTabs_Name_Id_Locator);
                if (getTabsName.Contains(tabName))
                {
                    isTabPresent = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ToolbarPreferencesPage",
                "IsTabDisplayAsMainTab",
                base.isTakeScreenShotDuringEntryExit);
            return isTabPresent;
        }

        /// <summary>
        /// Set Calendar CheckBox Preference.
        /// </summary>
        public void SetCalendarCheckBoxPreference()
        {
            //Set Calendar CheckBox Preference
            logger.LogMethodEntry("ToolbarPreferencesPage",
                "SetCalendarCheckBoxPreference",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Assignment Calendar Display Link Property
                this.SelectCourseToolTabPreferenceCheckBox(ToolbarPreferencesPageResource.
                    ToolbarPreferences_Page_AssignmentCalendar_Checkbox_Id_Locator);
                //Select Assignment Calendar radio Button
                this.SelectCourseToolTabPreferenceCheckBox(ToolbarPreferencesPageResource.
                    ToolbarPreferences_Page_AssignmentCalendar_RadioButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ToolbarPreferencesPage",
                "SetCalendarCheckBoxPreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select CourseTool Tab Preference CheckBox .
        /// </summary>
        /// <param name="selectorId">This is CourseTool Preferences Selector Id.</param>
        public void SelectCourseToolTabPreferenceCheckBox(string selectorId)
        {
            //Select CourseTool Tab Preference CheckBox
            logger.LogMethodEntry("ToolbarPreferencesPage",
                "SelectCourseToolTabPreferenceCheckBox",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                if (base.IsElementPresent(By.Id(selectorId), 5))
                {
                    //Wait for the element
                    base.WaitForElement(By.Id(selectorId));
                    base.FocusOnElementByID(selectorId);
                    //Get CourseTool Tab Preference CheckBox Property
                    IWebElement getPreferenceDisplayCheckbox = base.GetWebElementPropertiesById
                        (selectorId);
                    //Click CourseTool Tab Preference CheckBox
                    base.ClickByJavaScriptExecutor(getPreferenceDisplayCheckbox);
                }            
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ToolbarPreferencesPage",
                "SelectCourseToolTabPreferenceCheckBox",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
