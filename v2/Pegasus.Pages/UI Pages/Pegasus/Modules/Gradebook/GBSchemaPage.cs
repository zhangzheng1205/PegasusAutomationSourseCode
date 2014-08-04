using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handels the GBSchema Page Actions
    /// </summary>
    public class GBSchemaPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(GBSchemaPage));


        /// <summary>
        /// Click On Apply Button.
        /// </summary>
        public void ClickOnApplyButton()
        {
            //Click On Apply Button
            logger.LogMethodEntry("GBSchemaPage", "ClickOnApplyButton",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select GradeBook Schema Window
                this.SelectGradeBookSchemaWindow();
                //Select Apply Button
                this.SelectApplyButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBSchemaPage", "ClickOnApplyButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Apply Button.
        /// </summary>
        private void SelectApplyButton()
        {
            //Select Apply Button
            logger.LogMethodEntry("GBSchemaPage", "SelectApplyButton",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GBSchemaPageResource.
                GBSchema_Page_Apply_Button_Id_Locator));
            IWebElement getApplyButtonProperty = base.GetWebElementPropertiesById(
                GBSchemaPageResource.GBSchema_Page_Apply_Button_Id_Locator);
            //Click On Apply Button
            base.ClickByJavaScriptExecutor(getApplyButtonProperty);
            Thread.Sleep(Convert.ToInt32(GBSchemaPageResource.GBSchema_Page_Wait_Time));
            logger.LogMethodExit("GBSchemaPage", "SelectApplyButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Update Schema 
        /// </summary>
        public void ClickOnUpdateSchema()
        {
            //Click On Update Schema 
            logger.LogMethodEntry("GBSchemaPage", "ClickOnUpdateSchema",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select GradeBook Schema Window
                this.SelectGradeBookSchemaWindow();
                //Click On Update Schema Option
                this.ClickOnUpdateSchemaOption();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBSchemaPage", "ClickOnUpdateSchema",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select GradeBook Schema Window.
        /// </summary>
        private void SelectGradeBookSchemaWindow()
        {
            //Select Gradebook Schema Window
            logger.LogMethodEntry("GBSchemaPage", "SelectGradeBookSchemaWindow",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(GBSchemaPageResource.
                GBSchema_Page_GradeBookSchema_Window_Name);
            //Select Gradebook schema Window
            base.SelectWindow(GBSchemaPageResource.
                GBSchema_Page_GradeBookSchema_Window_Name);
            logger.LogMethodExit("GBSchemaPage", "SelectGradeBookSchemaWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Update Schema Option.
        /// </summary>
        private void ClickOnUpdateSchemaOption()
        {
            //Click On Update Schema Option
            logger.LogMethodEntry("GBSchemaPage", "ClickOnUpdateSchemaOption",
                base.IsTakeScreenShotDuringEntryExit);            
            base.WaitForElement(By.Id(GBSchemaPageResource.
                GBSchema_Page_UpdateSchema_Button_Id_Locator));
            //Get Update Schema Button Property
            IWebElement getUpdateSchemaProperty = 
                base.GetWebElementPropertiesById(GBSchemaPageResource.
                GBSchema_Page_UpdateSchema_Button_Id_Locator);
            //Click On Update Schema Option
            base.ClickByJavaScriptExecutor(getUpdateSchemaProperty);
            logger.LogMethodExit("GBSchemaPage", "ClickOnUpdateSchemaOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Apply Button.
        /// </summary>
        public void ClickonApplyButton()
        {
            //Click On Apply Button
            logger.LogMethodEntry("GBSchemaPage", "ClickonApplyButton",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to Last Opened Window
                base.SwitchToLastOpenedWindow();
                //Select Apply Button
                this.SelectApplyButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBSchemaPage", "ClickonApplyButton",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
