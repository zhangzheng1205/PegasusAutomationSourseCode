using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    public class MyTestPreferencesPage : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(MyTestPreferencesPage));

        /// <summary>
        /// Enable The MyTest Options.
        /// </summary>
        public void EnableTheMyTestOptions()
        {
            //Enable The MyTest Options
            Logger.LogMethodEntry("MyTestPreferencesPage", "EnableTheMyTestOptions",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Preference window
                new CourseCopyPreferencesPage().SelectTheMainPreferencesFrame();
                //Wait for the element
                base.WaitForElement(By.Id(MyTestPreferencesPageResource.
                    MyTestPreferences_Page_DisplayMyTestFolder_Option_Id_Locator));
                if (!(base.GetWebElementPropertiesById(MyTestPreferencesPageResource.
                    MyTestPreferences_Page_DisplayMyTestFolder_Option_Id_Locator).Selected))
                {
                    //Click the checkbox of ' Display MyTest Folder in Course Materials Library'
                    base.ClickButtonById(MyTestPreferencesPageResource.
                    MyTestPreferences_Page_DisplayMyTestFolder_Option_Id_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }          
            Logger.LogMethodExit("MyTestPreferencesPage", "EnableTheMyTestOptions",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save The Preferences.
        /// </summary>
        public void SaveThePreferences()
        {
            //Save The Preferences
            Logger.LogMethodEntry("MyTestPreferencesPage", "SaveThePreferences",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the preference window
                new CourseCopyPreferencesPage().SelectTheMainPreferencesFrame();
                //Wait For Save Preferences Button
                base.WaitForElement(By.PartialLinkText(MyTestPreferencesPageResource.
                    MyTestPreferences_Page_SavePreference_Button));
                //Get HTML Element Property for save preference button
                IWebElement getSavePreferences = base.GetWebElementPropertiesByPartialLinkText
                    (MyTestPreferencesPageResource.
                         MyTestPreferences_Page_SavePreference_Button);
                //Click on the save preference button
                base.ClickByJavaScriptExecutor(getSavePreferences);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestPreferencesPage", "SaveThePreferences",
             base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
