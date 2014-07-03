using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  This class handles Pegasus Course Copy Preferences Page Actions
    /// </summary>
    public class CourseCopyPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(CourseCopyPreferencesPage));

        /// <summary>
        /// Select The Main Preferences Frame
        /// </summary>
        public void SelectTheMainPreferencesFrame()
        {
            //Select The Main Preferences Frame
            logger.LogMethodEntry("CourseCopyPreferencesPage", "SelectTheMainPreferencesFrame", 
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_Preferences_Window_Title);
                //Select the Preferences Window
                base.SelectWindow(CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_Preferences_Window_Title);
                //Select the Main Frame
                base.SwitchToIFrame(CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_Preferences_Main_Frame_Id_Locator);
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }            
            logger.LogMethodExit("CourseCopyPreferencesPage", "SelectTheMainPreferencesFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Sets Copy Content Preference
        /// </summary>
        public void SetCopyContentPreference()
        {
            //Set Copy Content Preference
            logger.LogMethodEntry("CourseCopyPreferencesPage", "SetCopyContentPreference", 
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Main Frame
                this.SelectTheMainPreferencesFrame();
                base.WaitForElement(By.Id(CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_CopyContent_Link_Id_Locator));    
                IWebElement getCopyLink=base.GetWebElementPropertiesById
                    (CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_CopyContent_Link_Id_Locator);
                //Clicks on the copy Content Link
                base.ClickByJavaScriptExecutor(getCopyLink);
                //Select the Main Frame
                this.SelectTheMainPreferencesFrame();
                //Wait for the Element and Click            
                base.WaitForElement(By.Id(CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_Checkbox_CoursesAsFolders_Id_Locator));
                //Verify if it is Selected
                if ( !(base.GetWebElementPropertiesById(CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_Checkbox_CoursesAsFolders_Id_Locator).Selected) )
                {
                    IWebElement getContentPageCheckbox=base.GetWebElementPropertiesById
                        (CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_Checkbox_CoursesAsFolders_Id_Locator);
                    //Check the 'Display courses as folders on the Content page' Checkbox
                    base.ClickByJavaScriptExecutor(getContentPageCheckbox);
                }
                //Save the Preferences
                new GeneralPreferencesPage().SavePreferences();
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseCopyPreferencesPage", "SetCopyContentPreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable 'Copy Content' Option from Content Library to Course Content
        /// </summary>
        public void EnableCopyContentOption()
        {
            //Enable 'Copy Content' Option from Content Library to Course Content
            logger.LogMethodEntry("CourseCopyPreferencesPage", "EnableCopyContentOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Main Frame
                this.SelectTheMainPreferencesFrame();
                //Wait for the element
                base.WaitForElement(By.Id(CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_CopyContent_Id_Locator));
                base.SelectRadioButtonById(CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_CopyContent_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseCopyPreferencesPage", "EnableCopyContentOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Tab From Preferences.
        /// </summary>
        /// <param name="tabName">This is TabName.</param>
        public void ClickOnTabFromPreferences(string tabName)
        {
            //Click On Tab From Preferences
            logger.LogMethodExit("CourseCopyPreferencesPage", "ClickOnTabFromPreferences",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Window
                base.SelectWindow(CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_Preferences_Window_Title);
                //Wait for the Tab 
                base.WaitForElement(By.XPath(String.Format(CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_TabName_Title_Attribute_XPath_Locator,tabName)));
                base.FocusOnElementByXPath(String.Format(CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_TabName_Title_Attribute_XPath_Locator, tabName));
                //Click on the Tab
                base.ClickLinkByXPath(String.Format(CourseCopyPreferencesPageResource.
                    CourseCopyPreferencesPage_TabName_Title_Attribute_XPath_Locator, tabName));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseCopyPreferencesPage", "ClickOnTabFromPreferences",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
