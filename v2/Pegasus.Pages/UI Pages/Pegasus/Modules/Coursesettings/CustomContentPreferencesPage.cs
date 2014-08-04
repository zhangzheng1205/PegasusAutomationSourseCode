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
    ///  This class handles Pegasus Custom Content Preferences Page Actions
    /// </summary>
    public class CustomContentPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(CustomContentPreferencesPage));

        /// <summary>
        /// Set the Custom Content Preferences
        /// </summary>
        public void SetCustomContentPreferences()
        {
            //Set Custom Content Preferences
            logger.LogMethodEntry("CustomContentPreferencesPage", "SetCustomContentPreferences", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.ClickCustomContentLink();
                //Select the Main Window and Frame
                new CourseCopyPreferencesPage().SelectTheMainPreferencesFrame();
                //Selects the 'Custom Content' Preferences Options
                this.CustomContentPreferencesOptions();
                //Click on the Save Preferences button
                new ActivitiesPreferencesPage().SaveActivityPreferences();
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPreferencesPage", "SetCustomContentPreferences",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Sets 'Custom Content' Preferences Options
        /// </summary>
        private void CustomContentPreferencesOptions()
        {
            //Sets 'Custom Content' Preferences Options
            logger.LogMethodEntry("CustomContentPreferencesPage", "CustomContentPreferencesOptions",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for "Allow teacher to customize publisher content" check box
            base.WaitForElement(By.Id(CustomContentPreferencesPageResource.
                CustomCopyPreferencesPage_Link_CustomizePublisherContent_Id_Locator));
            //Click on "Allow teacher to customize publisher content" check box if not selected
            if ( !(base.GetWebElementPropertiesById(CustomContentPreferencesPageResource.
                CustomCopyPreferencesPage_Link_CustomizePublisherContent_Id_Locator).Selected) )
            {
                IWebElement getCustomizePublishContent=base.GetWebElementPropertiesById
                    (CustomContentPreferencesPageResource.
                CustomCopyPreferencesPage_Link_CustomizePublisherContent_Id_Locator);
                base.ClickByJavaScriptExecutor(getCustomizePublishContent);
            }
            //Click on "Allow teacher to customize organizational content" check box if not selected
            if ( !(base.GetWebElementPropertiesById(CustomContentPreferencesPageResource.
                CustomCopyPreferencesPage_Link_CustomizeOrganizationalContent_Id_Locator).Selected) )
            {
                IWebElement getCustomizeOrgContent=base.GetWebElementPropertiesById
                    (CustomContentPreferencesPageResource.
                CustomCopyPreferencesPage_Link_CustomizeOrganizationalContent_Id_Locator);
                base.ClickByJavaScriptExecutor(getCustomizeOrgContent);
            }
            //Click on "Allow teacher to create own content" check box if not selected
            if ( !(base.GetWebElementPropertiesById(CustomContentPreferencesPageResource.
                CustomCopyPreferencesPage_Link_CreateOwnContent_Id_Locator).Selected) )
            {
                IWebElement getCreateOwnContent=base.GetWebElementPropertiesById
                    (CustomContentPreferencesPageResource.
                CustomCopyPreferencesPage_Link_CreateOwnContent_Id_Locator);
                base.ClickByJavaScriptExecutor(getCreateOwnContent);
            }
            logger.LogMethodExit("CustomContentPreferencesPage", "CustomContentPreferencesOptions",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on 'Custom Content' Link
        /// </summary>
        private void ClickCustomContentLink()
        {
            //Clicks on 'Custom Content' Link
            logger.LogMethodEntry("CustomContentPreferencesPage", "ClickCustomContentLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Select the Main Window and Frame
            new CourseCopyPreferencesPage().SelectTheMainPreferencesFrame();
            //Click on the Custom Content Link
            base.WaitForElement(By.Id(CustomContentPreferencesPageResource.
                CustomCopyPreferencesPage_Link_CustomContent_Id_Locator));
            IWebElement getCustonContentLink=base.GetWebElementPropertiesById
                (CustomContentPreferencesPageResource.
                CustomCopyPreferencesPage_Link_CustomContent_Id_Locator);
            base.ClickByJavaScriptExecutor(getCustonContentLink);
            logger.LogMethodExit("CustomContentPreferencesPage", "ClickCustomContentLink",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
