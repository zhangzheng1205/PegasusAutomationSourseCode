using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Create Question actions.
    /// </summary>
     public class CreateQuestionPage : BasePage
    {
        private static readonly Logger logger =
        Logger.GetInstance(typeof(CreateQuestionPage));


        /// <summary>
        /// Create New Questions from Activity.
        /// </summary>
        public void ClickOnQuestionLink(string questionName)
        {
            logger.LogMethodEntry("CreateQuestionPage",
            "ClickOnTrueFalseQuestionLink",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SelectWindow(CreateQuestionPageResource.CreateQuestionPage_Window_Title_Locator);
                //Switch to Last Open Window
                //base.SwitchToLastOpenedWindow();
                //Wait for Iframe
                base.WaitForElement(By.Id(CreateQuestionPageResource.
                CreateQuestionPage_Iframe_Id_Locator));
                //Switch to IFrame
                base.SwitchToIFrameById(CreateQuestionPageResource.
                CreateQuestionPage_Iframe_Id_Locator);
                //Get property for 'True/False' question link
                IWebElement getQuestionName = base.GetWebElementPropertiesByPartialLinkText
                (questionName);
                //Click on 'True/False' question link
                base.ClickByJavaScriptExecutor(getQuestionName);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateQuestionPage",
            "ClickOnTrueFalseQuestionLink",
            base.IsTakeScreenShotDuringEntryExit);

        }

       

    }
}
