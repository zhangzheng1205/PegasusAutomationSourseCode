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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan
{
    /// <summary>
    /// This Class Handles User Template Section Page actions
    /// </summary>
    public class UserTemplateSectionsPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(UserTemplateSectionsPage));


        /// <summary>
        /// Select Sections Check Box and Click Add Button
        /// </summary>
        public void SelectSectionsCheckBoxAndClickAddButton()
        {
            //Select All Sections Check Box and Click Add Button
            logger.LogMethodEntry("UserTemplateSectionsPage",
                "SelectSectionsCheckBoxAndClickAddButton", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Sections Check Box
                this.SelectSectionsCheckBox();
                //Click On Add Button
                this.ClickOnAddButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("UserTemplateSectionsPage",
                "SelectSectionsCheckBoxAndClickAddButton", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Sections Check Box.
        /// </summary>
        private void SelectSectionsCheckBox()
        {
            logger.LogMethodEntry("UserTemplateSectionsPage",
                "SelectSectionsCheckBox", base.isTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectWindow();
            base.WaitForElement(By.XPath(UserTemplateSectionsPageResource.
                UserTemplateSections_Section_CheckAll_Xpath_Locator));
            //Select Check All Option
            IWebElement getsectionCheckAll = 
                base.GetWebElementPropertiesByXPath(UserTemplateSectionsPageResource.
                UserTemplateSections_Section_CheckAll_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getsectionCheckAll);            
            logger.LogMethodEntry("UserTemplateSectionsPage", "SelectSectionsCheckBox",
                                   base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            logger.LogMethodEntry("UserTemplateSectionsPage",
                "SelectWindow", base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilPopUpLoads(UserTemplateSectionsPageResource.
                UserTemplateSections_Page_Window_Name);
            //Select Window
            base.SelectWindow(UserTemplateSectionsPageResource.
                UserTemplateSections_Page_Window_Name);
            logger.LogMethodEntry("UserTemplateSectionsPage",
                "SelectWindow",base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Button
        /// </summary>
        private void ClickOnAddButton()
        {
            logger.LogMethodEntry("UserTemplateSectionsPage", "ClickOnAddButton",
                                   base.isTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectWindow();
            base.WaitForElement(By.CssSelector(UserTemplateSectionsPageResource.
                UserTemplateSections_Add_Button_CssSelector_Locator));
            //Click on Add Button
            IWebElement getAddButton =
                base.GetWebElementPropertiesByCssSelector(UserTemplateSectionsPageResource.
                UserTemplateSections_Add_Button_CssSelector_Locator);
            base.ClickByJavaScriptExecutor(getAddButton);
            Thread.Sleep(Convert.ToInt32(UserTemplateSectionsPageResource.
                UserTemplateSections_Page_ElementTime_Value));
            logger.LogMethodEntry("UserTemplateSectionsPage", "ClickOnAddButton",
                                   base.isTakeScreenShotDuringEntryExit);
        }
    }
}
