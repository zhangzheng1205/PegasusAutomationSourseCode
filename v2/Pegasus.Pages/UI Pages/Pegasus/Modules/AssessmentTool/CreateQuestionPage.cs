using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool;
using System;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Create Question actions.
    /// </summary>
    class CreateQuestionPage : BasePage
    {
        private static readonly Logger logger =
        Logger.GetInstance(typeof(CreateQuestionPage));


        /// <summary>
        /// Create New Questions from Activity.
        /// </summary>
        public void ClickOnTrueFalseQuestionLink()
        {
            logger.LogMethodEntry("CreateQuestionPage",
            "ClickOnTrueFalseQuestionLink",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to Last Open Window
                base.SwitchToLastOpenedWindow();
                //Wait for Iframe
                base.WaitForElement(By.Id(CreateQuestionPageResource.
                CreateQuestionPage_Iframe_Id_Locator));
                //Switch to IFrame
                base.SwitchToIFrameById(CreateQuestionPageResource.
                CreateQuestionPage_Iframe_Id_Locator);
                //Get property for 'True/False' question link
                IWebElement GetTrueFalseQuestion = base.GetWebElementPropertiesByPartialLinkText
                (CreateQuestionPageResource.CreateQuestionPage_TrueFalse_PartialText_Locator);
                //Click on 'True/False' question link
                base.ClickByJavaScriptExecutor(GetTrueFalseQuestion);

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
