using System;
using Pegasus.Automation.DataTransferObjects;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool
{
    public class WritingCoachQuestionListPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(WritingCoachQuestionListPage));

        /// <summary>
        /// Verify Writing Assistant Activity is launched.
        /// </summary>
        public Boolean IsWritingAssistantActivityLaunched()
        {
            //Verify Writing Assistant Activity is launched.
            Logger.LogMethodEntry("WritingCoachQuestionListPage", "IsWritingAssistantActivityLauched",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            bool isWritingAssistantActivityLaunched = false;
            try
            {
                Thread.Sleep(2000);
                base.SwitchToLastOpenedWindow();
                Thread.Sleep(5000);
                base.SwitchToLastOpenedWindow();
                //Wait for Element
                //base.WaitForElement(By.Id(WritingCoachQuestionListPageResource.
                //    WritingCoachQuestionListPage_Activity_Title_Id_Locator));
                bool ele = base.IsElementPresent(By.XPath(WritingCoachQuestionListPageResource.
                    WritingCoachQuestionListPage_FullEssay_RadioButton_XPath_Locator), 10);
                IWebElement getfullEssayRadioButton = base.GetWebElementPropertiesByXPath(
                    WritingCoachQuestionListPageResource.
                    WritingCoachQuestionListPage_FullEssay_RadioButton_XPath_Locator);
                base.FocusOnElementByXPath(WritingCoachQuestionListPageResource.
                   WritingCoachQuestionListPage_FullEssay_RadioButton_XPath_Locator);
                //Thread.Sleep(2000);
                //Select for Paragraph and Essay Mode
                base.ClickByJavaScriptExecutor(getfullEssayRadioButton);
                //Click Next Button
                IWebElement nextButton = base.GetWebElementPropertiesById(
                        WritingCoachQuestionListPageResource.
                        WritingCoachQuestionListPage_NextButton_Id_Locator);
                base.ClickByJavaScriptExecutor(nextButton);
                //Switch to the presentation window
                base.WaitUntilWindowLoads(WritingCoachQuestionListPageResource.
                    WritingCoachQuestionListPage_Activity_Window_Name_Locator);
                base.SelectWindow(WritingCoachQuestionListPageResource.
                    WritingCoachQuestionListPage_Activity_Window_Name_Locator);
                string actualWindowName = base.GetPageTitle;
                if (actualWindowName == WritingCoachQuestionListPageResource.
                    WritingCoachQuestionListPage_Activity_Window_Name_Locator)
                {
                    if (base.IsElementDisplayedInPage(By.Id(
                        WritingCoachQuestionListPageResource.
                        WritingCoachQuestionListPage_Writing_Coach_Banner_Id_Locator),
                        true, 10))
                    {
                        isWritingAssistantActivityLaunched = true;
                    }
                }
                //Answer the Writing Coach Activity
                this.AnswerWritingCoachActivity();
                //Submit the Activity
                this.submitActivity();
                //Close the presentation
                this.closeActivity();
                //Switch to Main Window
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("WritingCoachQuestionListPage", "IsWritingAssistantActivityLauched",
                base.IsTakeScreenShotDuringEntryExit);
            return isWritingAssistantActivityLaunched;
        }

        /// <summary>
        /// Answer Writing Coach Activity
        /// </summary>
        private void AnswerWritingCoachActivity()
        {
            Logger.LogMethodEntry("WritingCoachQuestionListPage", "AnswerWritingCoachActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the answer text
            string answer = WritingCoachQuestionListPageResource.
                WritingCoachQuestionListPage_AsnwerText;
            //Identify Answer Area
            base.GetWebElementPropertiesById(WritingCoachQuestionListPageResource.
                WritingCoachQuestionListPage_TextArea_Id_Locator);
            //Add the answer text
            base.FillTextBoxById(WritingCoachQuestionListPageResource.
                WritingCoachQuestionListPage_TextArea_Id_Locator, answer);
            Logger.LogMethodExit("WritingCoachQuestionListPage", "AnswerWritingCoachActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the Activity
        /// </summary>
        private void submitActivity()
        {
            Logger.LogMethodEntry("WritingCoachQuestionListPage", "submitActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the Submit for Grading Button
            IWebElement submitforGrading = base.GetWebElementPropertiesById(
                WritingCoachQuestionListPageResource.
                WritingCoachQuestionListPage_SubmitforGrading_Id_Locator);
            //Click Submit for Grading Button
            base.ClickByJavaScriptExecutor(submitforGrading);
            //Get Finish Button
            IWebElement finishButton = base.GetWebElementPropertiesById(
                WritingCoachQuestionListPageResource.
                WritingCoachQuestionListPage_FinishButton_Id_Locator);
            //Click Finish Button
            base.ClickByJavaScriptExecutor(finishButton);
            //Get Return to Course Button
            IWebElement returnToCourse = base.GetWebElementPropertiesById(
                WritingCoachQuestionListPageResource.
                WritingCoachQuestionListPage_ReturnToCourse_Button_Id_Locator);
            //Click Return to Course Button
            base.ClickByJavaScriptExecutor(returnToCourse);
            Logger.LogMethodExit("WritingCoachQuestionListPage", "submitActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close Presentation Activity
        /// </summary>
        private void closeActivity()
        {
            //Click Close button
            Logger.LogMethodExit("WritingCoachQuestionListPage", "closeActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Close button
            IWebElement closeButton = base.GetWebElementPropertiesById(
                WritingCoachQuestionListPageResource.
                WritingCoachQuestionListPage_CloseButton_Id_Locator);
            //Click Close button
            base.ClickByJavaScriptExecutor(closeButton);
            Logger.LogMethodExit("WritingCoachQuestionListPage", "closeActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}