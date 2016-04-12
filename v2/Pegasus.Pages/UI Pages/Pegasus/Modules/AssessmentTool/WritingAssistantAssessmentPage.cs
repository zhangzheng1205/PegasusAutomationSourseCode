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
    public class WritingAssistantAssessmentPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(WritingAssistantAssessmentPage));

        /// <summary>
        /// Create an activity
        /// </summary>
        /// <param name="activityType">This is the activity type</param>
        /// <param name="activityBehavioralMode">This is the behavioral type</param>
        public void createActivity()
        {
            // Create an activity
            Logger.LogMethodEntry("WritingAssistantAssessmentPage", "createActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Add assessment details
                this.addActivityDetails();
                //Add questions
                this.addQuestions();
                //Save the activity
                IWebElement getSaveandReturn = base.GetWebElementPropertiesById(
                    WritingAssistantAssessmentPageResource.
                    WritingAssistantAssessmentPage_SaveandReturn_Id_Locator);
                base.ClickByJavaScriptExecutor(getSaveandReturn);
                Logger.LogMethodExit("WritingAssistantAssessmentPage", "addQuestions",
                    base.IsTakeScreenShotDuringEntryExit);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("WritingAssistantAssessmentPage", "createActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Activity Details
        /// </summary>
        private void addActivityDetails()
        {
            Logger.LogMethodEntry("WritingAssistantAssessmentPage", "addActivityDetails",
                base.IsTakeScreenShotDuringEntryExit);

            //Generate Activity Name GUID
            Guid activityName = Guid.NewGuid();
            base.GetWebElementPropertiesById(WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_ActivityName_Id_Locator);
            //Clear the Activity Name text box
            base.ClearTextById(WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_ActivityName_Id_Locator);
            //Add the activity name
            base.FillTextBoxById(WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_ActivityName_Id_Locator,
                activityName.ToString());
            //Click Save and Continue
            IWebElement saveAndContinue = base.GetWebElementPropertiesById(
                WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_SaveandContinue_Id_Locator);
            base.ClickByJavaScriptExecutor(saveAndContinue);

            Logger.LogMethodExit("WritingAssistantAssessmentPage", "addActivityDetails",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Questions from Question Bank
        /// </summary>
        private void addQuestions()
        {
            Logger.LogMethodEntry("WritingAssistantAssessmentPage", "addQuestions",
                base.IsTakeScreenShotDuringEntryExit);
            //Switch to Questions tab
            base.WaitUntilWindowLoads(WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_ActivityCreation_Window_Name);
            base.SelectWindow(WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_ActivityCreation_Window_Name);
            //Click on Add Questions
            IWebElement getAddQuestions = base.GetWebElementPropertiesById(
                WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_AddQuestions_Id_Locator);
            base.ClickByJavaScriptExecutor(getAddQuestions);
            base.WaitUntilWindowLoads(WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_ActivityCreation_Window_Name);
            bool isSelectQuestionsPresent = base.IsElementPresent(By.XPath(
                WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_SelectQuestions_XPath_Loctor), 10);
            //Click Select Questions from Library
            IWebElement getSelectQuestions = base.GetWebElementPropertiesByXPath(
                WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_SelectQuestions_XPath_Loctor);
            base.PerformMouseHoverAction(getSelectQuestions);
            base.PerformMouseClickAction(getSelectQuestions);
            //Open folder and select question
            this.addQuestion();
        }

        private void addQuestion()
        {
            Logger.LogMethodEntry("WritingAssistantAssessmentPage", "addQuestionfromFolder",
                base.IsTakeScreenShotDuringEntryExit);
            Question question = Question.Get(Question.QuestionTypeEnum.AutoGradedEssayFeedback);
            string questionTitle = question.Name.ToString();
            //Switch to Questions tab
            base.WaitUntilWindowLoads(WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_SelectQuestions_Window_Name);
            base.SelectWindow(WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_SelectQuestions_Window_Name);
            //Search Question
            base.SwitchToIFrame(WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_SelectQuestions_IFrame_Id_Locator);
            base.GetWebElementPropertiesById(WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_SearchQuestion_Id_Locator);
            base.FillTextBoxById(WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_SearchQuestion_Id_Locator, questionTitle);
            //Click the Go Button
            IWebElement goButton = base.GetWebElementPropertiesById(
                WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_SearchButton_Id_Locator);
            base.ClickByJavaScriptExecutor(goButton);
            //Verify if the question is present
            bool isQuestionPresent = base.IsElementDisplayedInPage(By.XPath(
                WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_SearchedQuestion_XPath_Locator), true, 10);
            if (isQuestionPresent)
            {
                base.SelectCheckBoxById(WritingAssistantAssessmentPageResource.
                WritingAssistantAssessmentPage_QuestionCheckBox_Id_Locator);
            }
            else
            {
                throw new ArgumentException("Question was not found");
            }
            //Switch back to the Select Question Window
            base.SwitchToLastOpenedWindow();
            //Click Save and Close Button
            IWebElement getSaveAndClose = base.GetWebElementPropertiesById(
                    WritingAssistantAssessmentPageResource.
                    WritingAssistantAssessmentPage_SaveandClose_Id_Locator);
            base.ClickByJavaScriptExecutor(getSaveAndClose);
            base.SwitchToLastOpenedWindow();
            Logger.LogMethodExit("WritingAssistantAssessmentPage", "addQuestionfromFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}