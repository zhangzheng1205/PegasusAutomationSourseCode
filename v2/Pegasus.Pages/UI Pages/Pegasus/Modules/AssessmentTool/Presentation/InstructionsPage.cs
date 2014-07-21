﻿using System;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation
{
    /// <summary>
    /// This class handles instruction page actions.
    /// </summary>
    public class InstructionsPage : BasePage
    {
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(InstructionsPage));

        /// <summary>
        /// Click start button from instruction page.
        /// </summary>
        public void ClickTestStartButton()
        {
            // Click To Start Activity
            logger.LogMethodEntry("InstructionsPage", "ClickTestStartButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Wait For Start Button
                base.WaitForElement(By.Id(InstructionsPageResource
                    .Instructions_Page_ActivityStart_Button_Id_Locator));
                //Get Start Button Properties
                IWebElement getActivityStartButtonProperties =
                    base.GetWebElementPropertiesById(InstructionsPageResource
                    .Instructions_Page_ActivityStart_Button_Id_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getActivityStartButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("InstructionsPage", "ClickTestStartButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Close button from instruction page.
        /// </summary>
        public void ClickTestCloseButton()
        {
            //Click To Close Activity
            logger.LogMethodEntry("InstructionsPage", "ClickTestCloseButton",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Wait For Stop Button
                base.WaitForElement(By.Id(InstructionsPageResource
                    .Instructions_Page_ActivityClose_Button_Id_Locator));
                base.FocusOnElementByID(InstructionsPageResource
                    .Instructions_Page_ActivityClose_Button_Id_Locator);
                //Get Stop Button Properties
                IWebElement getActivityStartButtonProperties =
                    base.GetWebElementPropertiesById(InstructionsPageResource
                    .Instructions_Page_ActivityClose_Button_Id_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getActivityStartButtonProperties);
                Thread.Sleep(Convert.ToInt32(InstructionsPageResource.
                    Instructions_Page_Wait_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("InstructionsPage", "ClickTestCloseButton",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Button Text.
        /// </summary>
        /// <returns>This Returns Button Text.</returns>
        public string GetButtonText()
        {
            //Get Button Text
            logger.LogMethodEntry("InstructionsPage", "GetButtonText",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getButtonText = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(InstructionsPageResource.
                    Instructions_Page_WindowName);
                //Select Window
                base.SelectWindow(InstructionsPageResource.
                    Instructions_Page_WindowName);
                // Wait For Start Button
                base.WaitForElement(By.Id(InstructionsPageResource
                    .Instructions_Page_ActivityStart_Button_Id_Locator));
                //Get Button Text
                getButtonText = base.GetElementTextByID(InstructionsPageResource
                    .Instructions_Page_ActivityStart_Button_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("InstructionsPage", "GetButtonText",
              base.isTakeScreenShotDuringEntryExit);
            return getButtonText;
        }
    }
}
