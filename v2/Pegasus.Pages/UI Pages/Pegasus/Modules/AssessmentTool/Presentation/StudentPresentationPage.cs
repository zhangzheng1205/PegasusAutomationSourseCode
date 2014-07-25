﻿using System;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using System.Windows.Forms;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
using Microsoft.VisualStudio.TestTools.UITesting;
using System.Drawing;
using System.Diagnostics;
using System.Configuration;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Student Presentation Page Actions.
    /// </summary>
    public class StudentPresentationPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static Logger logger =
            Logger.GetInstance(typeof(StudentPresentationPage));

        private int waitTimeOut = Convert.ToInt32(
            ConfigurationManager.AppSettings["ElementFindTimeOutInSeconds"]);
        /// <summary>
        /// Opens Activity Presentation Window.
        /// </summary>
        /// <returns>Activity Presentation Window Open Result.</returns>
        public Boolean IsActivityPresentationPageOpened()
        {
            //Opens Activity Presentation Window
            logger.LogMethodEntry("StudentPresentationPage",
                "IsActivityPresentationPageOpened",
                base.isTakeScreenShotDuringEntryExit);
            Boolean isActivityPresentationPageDisplayed = false;
            try
            {
                //Select Window
                base.SelectWindow(StudentPresentationPageResource.
                        StudentPresentation_Page_Window_Title_Name);
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_AssessmentHolder_Id_Locator));
                // Is Activity Displayed in Presentation Window
                isActivityPresentationPageDisplayed = base.IsElementDisplayedByID
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_AssessmentHolder_Id_Locator);
                //Close The Window
                base.CloseBrowserWindow();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_LaunchWindow_TimeValue));
                //Used SendKeys to Close modal pop up
                SendKeys.SendWait(StudentPresentationPageResource.
                    StudentPresentation_Page_EnterKey_Value);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource
                    .StudentPresentation_Page_LaunchWindowClose_TimeValue));
                base.SelectWindow(StudentPresentationPageResource
                    .StudentPresentation_Page_BaseWindow_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "IsActivityPresentationPageOpened",
                base.isTakeScreenShotDuringEntryExit);
            return isActivityPresentationPageDisplayed;
        }

        /// <summary>
        /// Submit the activity in presentation window.
        /// </summary>
        public void AttemptActivity()
        {
            //Opens Activity Presentation Window
            logger.LogMethodEntry("StudentPresentationPage", "AttemptActivity",
                base.isTakeScreenShotDuringEntryExit);
            try
            {                
                //Select Window
                this.SelectWindow();
                //Answers Selection in Presention window
                this.AnswersSelectionInTestWindow();
                //Click the Submit button
                this.ClickOnSubmitForGradingButton();
                //Click on the Finish button
                this.ClickOnFinishButton();
                //Click On Return To Course Button
                this.ClickOnReturnToCourseButton();
                // Switch to default window after closing of presentation pop up
                base.WaitUntilWindowLoads(StudentPresentationPageResource
                     .StudentPresentation_Page_BaseWindow_Title_Name);
                base.SelectWindow(StudentPresentationPageResource
                     .StudentPresentation_Page_BaseWindow_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptActivity",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Pop Up Loads
            base.WaitUntilWindowLoads(StudentPresentationPageResource.
                StudentPrsentation_Page_Test_Window_Name);
            //Select Window
            base.SelectWindow(StudentPresentationPageResource.
                StudentPrsentation_Page_Test_Window_Name);
            logger.LogMethodExit("StudentPresentationPage", "SelectWindow",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checks whether question have been submitted successfuly.
        /// </summary>
        /// <returns>Availability of try again  button after submits activity</returns>
        public Boolean IsPostTestActivitySubmittedSuccessfully()
        {
            //Submit Activity Successfully
            logger.LogMethodEntry("IsPostTestActivitySubmittedSuccessfully",
                "IsActivitySubmittedSuccessfully",
               base.isTakeScreenShotDuringEntryExit);
            //Intialized Variable
            Boolean isQuestionSubmittedSuccessfully = false;
            try
            {
                // wait for try again button in presentation window
                base.WaitForElement(By.Id(StudentPresentationPageResource
                    .StudentPresentation_Page_Try_Button_Id_Locator));
                isQuestionSubmittedSuccessfully = base.IsElementDisplayedByID
                    (StudentPresentationPageResource
                         .StudentPresentation_Page_Try_Button_Id_Locator);
                //Click On Return To Course Button
                this.ClickOnReturnToCourseButton();
                // Switch to default window after closing of presentation pop up
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource
                    .StudentPresentation_Page_TimeToWait));
                base.SelectWindow(StudentPresentationPageResource
                     .StudentPresentation_Page_BaseWindow_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "IsPostTestActivitySubmittedSuccessfully", base.isTakeScreenShotDuringEntryExit);
            return isQuestionSubmittedSuccessfully;
        }

        /// <summary>
        /// Selects options/answers in Test window to complete submission
        /// </summary>
        private void AnswersSelectionInTestWindow()
        {
            //Selects options/answers in Test window to complete submission
            logger.LogMethodEntry("StudentPresentationPage",
                "AnswersSelectionInTestWindow",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_QuestionCount_Presentation_Xpath_Locator));
            //Get Number of count from the Div
            int getDivCount = base.GetElementCountByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_QuestionCount_Presentation_Xpath_Locator);
            // Loop to click options Div By Div
            for (int questionDivNumber = 1;
                questionDivNumber <= getDivCount; questionDivNumber++)
            {
                //Checks whether div of question is present or not
                Boolean isNonAttemptedQuestionPresent = base.IsElementPresent(By.XPath
                        (string.Format(StudentPresentationPageResource
                        .StudentPresentation_Page_QuestionRadioButton_Xpath_Locator,
                        questionDivNumber)));
                if (isNonAttemptedQuestionPresent)
                {
                    //Wait for radio button as per the DIV and clicks on it
                    base.WaitForElement(By.XPath(string.Format(StudentPresentationPageResource
                        .StudentPresentation_Page_QuestionRadioButton_Xpath_Locator,
                        questionDivNumber)));
                    //Clicks on the radio button of answers
                    base.ClickButtonByXPath(string.Format(StudentPresentationPageResource.
                        StudentPresentation_Page_QuestionRadioButton_Xpath_Locator,
                        questionDivNumber));
                }
            }
            logger.LogMethodExit("StudentPresentationPage",
                "AnswersSelectionInTestWindow",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Check for the Display of Teacher View tabs
        /// </summary>
        /// <returns>Returns Teacher View tabs present results</returns>
        public Boolean IsNextButtonPresent()
        {
            logger.LogMethodEntry("StudentPresentationPage", "IsNextButtonPresent",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isNextButtonPresent = false;
            try
            {
                //Switch To Last Opened Window
                base.SwitchToLastOpenedWindow();
                //Get window title
                string getWindowTitle = base.GetWindowTitleByJavaScriptExecutor();
                //Wait For Window
                base.WaitUntilWindowLoads(getWindowTitle);
                //Select Window
                base.SelectWindow(getWindowTitle);
                base.WaitForElement(By.PartialLinkText(StudentPresentationPageResource.
                    StudentPresentation_Page_NextQuestion_Button_Locator));
                //Verify Display of Next Button
                isNextButtonPresent = IsElementDisplayedByPartialLinkText(
                    StudentPresentationPageResource.
                    StudentPresentation_Page_NextQuestion_Button_Locator);
                //Close Current Window
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "IsNextButtonPresent",
              base.isTakeScreenShotDuringEntryExit);
            return isNextButtonPresent;
        }

        /// <summary>
        /// Attempt The Post Test Activity By Student.
        /// </summary>
        public void AttemptPostTestActivity()
        {
            //Attempt The Activity
            logger.LogMethodEntry("StudentPresentationPage", "AttemptPostTestActivity",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the window loads
                base.WaitUntilWindowLoads(StudentPresentationPageResource.
                    StudentPresentation_Page_Content_Window_Title_Name);
                base.SelectWindow(StudentPresentationPageResource.
                    StudentPresentation_Page_Content_Window_Title_Name);
                //Select the frame
                base.SwitchToIFrame(StudentPresentationPageResource.
                    StudentPresentation_Page_Content_Frame_Id_Locator);
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                     StudentPresentation_Page_PostTest_Id_Locator));
                //Click on Button
                base.ClickButtonByID(StudentPresentationPageResource.
                    StudentPresentation_Page_PostTest_Id_Locator);
                // Wait and Select Window
                base.WaitUntilWindowLoads(StudentPresentationPageResource
                    .StudentPresentation_Page_StudyPlanTypeActivity_PostTest_Window_Title_Name);
                base.SelectWindow(StudentPresentationPageResource
                    .StudentPresentation_Page_StudyPlanTypeActivity_PostTest_Window_Title_Name);
                //Click on Activity Start Button
                new InstructionsPage().ClickTestStartButton();
                //Wait For Element
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPresentation_Page_QuestionNavigation_Id_Locator));
                //Get Total Question Count
                int getTotalQuestionCount = base.GetElementCountByXPath(StudentPresentationPageResource.
                    StudentPresentation_Page_QuestionNavigation_Id_Locator);
                //Attempt all available questions  
                for (int startQuestionNumber = 1; startQuestionNumber
                    <= getTotalQuestionCount; startQuestionNumber++)
                {
                    //Select Answer Choice
                    this.SelectPostTestAnswerChoice(startQuestionNumber);
                    if (startQuestionNumber == getTotalQuestionCount)
                    {
                        //Click on Submit For Grading Button
                        this.ClickOnSubmitForGradingButton();
                        break;
                    }
                    //Click Next Question Button
                    this.ClickNextQuestionButton();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptPostTestActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Answer Choice.
        /// </summary>
        /// <param name="startQuestionNumber">This is the current question number.</param>
        private void SelectPostTestAnswerChoice(
            int startQuestionNumber)
        {
            //Select Answer Choice
            logger.LogMethodEntry("StudentPresentationPage", "SelectPostTestAnswerChoice",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(string.Format(StudentPresentationPageResource
               .StudentPresentation_Page_AnswerChoice_RadioButton_XPath_Locator,
               startQuestionNumber)));
            //Click on Radio Button
            base.SelectRadioButtonByXPath(string.Format(StudentPresentationPageResource
               .StudentPresentation_Page_AnswerChoice_RadioButton_XPath_Locator,
               startQuestionNumber));
            logger.LogMethodExit("StudentPresentationPage", "SelectPostTestAnswerChoice",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Next Question Button
        /// </summary>
        private void ClickNextQuestionButton()
        {
            //Click Next Question Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickNextQuestionButton",
              base.isTakeScreenShotDuringEntryExit);
            //Wait For Next Question Button
            base.WaitForElement(By.Id(StudentPresentationPageResource
               .StudentPresentation_Page_NextQuestion_Button_Id_Locator));
            //Get Button Property
            IWebElement getNextQuestionButtonProperty = base.GetWebElementPropertiesById
               (StudentPresentationPageResource.StudentPresentation_Page_NextQuestion_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getNextQuestionButtonProperty);
            logger.LogMethodExit("StudentPresentationPage", "ClickNextQuestionButton",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Submit For Grade Button.
        /// </summary>
        private void ClickOnSubmitForGradingButton()
        {
            //Click on Submit Grade Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSubmitForGradingButton",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Submit For Grading Button
            base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPresentation_Page_SubmitForGrading_Button_Id_Locator));
            //Get Button Property
            IWebElement getActivitySubmitButtonProperty = base.GetWebElementPropertiesById
                (StudentPresentationPageResource.
                  StudentPresentation_Page_SubmitForGrading_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getActivitySubmitButtonProperty);
            logger.LogMethodExit("StudentPresentationPage", "ClickOnSubmitForGradingButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt the Activity By Student in view all content tab
        /// </summary>
        /// <param name="activityType">This is the activity type</param>
        public void AttemptTheActivityInDigitalPath(
            string activityType)
        {
            //Attempt The Activity
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTheActivityInDigitalPath",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Initialize div section count to one
                int divSectionCount = 1;
                ClickStartButtonOnPresentationWindow(activityType);
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                       StudentPresentation_Page_QuestionNavigation_Id_Locator));
                //Get Total Quuestion Count
                int getTotalQuestionCount = base.GetElementCountByXPath(StudentPresentationPageResource.
                    StudentPresentation_Page_QuestionNavigation_Id_Locator);
                //Attempt all available questions  
                for (int startQuestionNumber = 1;
                    startQuestionNumber <= getTotalQuestionCount; startQuestionNumber++, divSectionCount++)
                {

                    //Select Answer Choice
                    SelectAnswersChoiceOfActivity(startQuestionNumber, activityType, divSectionCount);
                    if (startQuestionNumber == getTotalQuestionCount)
                    {
                        //Click on Submit For Grade Button
                        this.ClickOnSubmitForGradingButton();
                        break;
                    }
                    //Click Next Question Button
                    this.ClickNextQuestionButton();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptTheActivityInDigitalPath",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt The Behavioral Mode Type Activity.
        /// </summary>
        /// <param name="activityType">This is Activity Type.</param>
        public void AttemptTheBehavioralModeTypeActivity(string activityType)
        {
            //Attempt The Behavioral Mode Type Activity
            logger.LogMethodEntry("StudentPresentationPage", 
                "AttemptTheBehavioralModeTypeActivity",
              base.isTakeScreenShotDuringEntryExit);
            try
            { 
                //Click the start button
                ClickStartButtonOnPresentationWindow(activityType);
                //Wait for the element
                 base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPresentation_Page_Asset_Radio_Button_Xpath_locator));
                IWebElement getRadioButton = base.GetWebElementPropertiesByXPath
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_Asset_Radio_Button_Xpath_locator);
                //Select the radio button
                base.ClickByJavaScriptExecutor(getRadioButton);                
                //Click on Submit For Grade Button
                this.ClickOnSubmitForGradingButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "AttemptTheBehavioralModeTypeActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt the Activity By Student in Course Materials tab.
        /// </summary>
        /// <param name="activityType">This is the activity type</param>
        public void AttemptTheActivityInCourseMaterials(
            string activityType)
        {
            //Attempt The Activity
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTheActivityInCourseMaterials",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Initialize div section count to one
                int divSectionCount = Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_Initial_Value);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_CustomWait_Time));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPresentation_Page_Questions_Count_Xpath_Locator));
                //Get Total Quuestion Count
                int getTotalQuestionCount = base.GetElementCountByXPath
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_Questions_Count_Xpath_Locator);
                //Attempt all available questions  
                for (int startQuestionNumber = Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_Initial_Value);
                    startQuestionNumber <= getTotalQuestionCount; startQuestionNumber++, divSectionCount++)
                {
                    //Select Answer Choice
                    SelectAnswersChoiceOfActivity(startQuestionNumber, activityType, divSectionCount);
                    if (startQuestionNumber == getTotalQuestionCount)
                    {
                        //Click on Submit For Grade Button
                        this.ClickOnSubmitForGradingButton();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptTheActivityInCourseMaterials",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select start button on the presentation window.
        /// </summary>
        /// <param name="activityType">This is the activity type.</param>
        public void ClickStartButtonOnPresentationWindow(
            string activityType)
        {
            logger.LogMethodEntry("StudentPresentationPage", "ClickStartButtonOnPresentationWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Switch on the basis of activity type
                switch (activityType)
                {
                    case "StudyPlan": // Have hardcoded because it was expecting a constant value
                        // Wait and Select Window
                        base.WaitUntilWindowLoads(StudentPresentationPageResource
                            .StudentPresentation_Page_StudyPlanTypeActivity_WindowName);
                        base.SelectWindow(StudentPresentationPageResource
                            .StudentPresentation_Page_StudyPlanTypeActivity_WindowName);
                        // Start Activity
                        new InstructionsPage().ClickTestStartButton();
                        break;
                    case "Test": // Have hardcoded because it was expecting a constant value
                        // Wait and Select Window
                        base.WaitUntilWindowLoads(StudentPresentationPageResource
                            .StudentPresentation_Page_TestTypeActivity_WindowName_Title);
                        base.SelectWindow(StudentPresentationPageResource
                            .StudentPresentation_Page_TestTypeActivity_WindowName_Title);
                        // Start Activity
                        new InstructionsPage().ClickTestStartButton();
                        break;
                    case "HomeWork": // Have hardcoded because it was expecting a constant value
                        // Wait and Select Window
                        base.WaitUntilWindowLoads(StudentPresentationPageResource.
                            StudentPresentation_Page_Homework_Window_Name);
                        base.SelectWindow(StudentPresentationPageResource.
                            StudentPresentation_Page_Homework_Window_Name);
                        // Start Activity
                        new InstructionsPage().ClickTestStartButton();
                        break;
                    case "Quiz": // Have hardcoded because it was expecting a constant value
                        // Wait and Select Window
                        base.WaitUntilWindowLoads(StudentPresentationPageResource.
                            StudentPrsentation_Page_ActivityQuiz_WindowName_Locator);
                        base.SelectWindow(StudentPresentationPageResource.
                            StudentPrsentation_Page_ActivityQuiz_WindowName_Locator);
                        // Start Activity
                        new InstructionsPage().ClickTestStartButton();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickStartButtonOnPresentationWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Answer's Choice on presentation window.
        /// </summary>
        /// <param name="startQuestionNumber">This is current question number.</param>
        /// <param name="activityType">This is activity type</param>
        /// <param name="sectionCount">This is div section count</param>
        private void SelectAnswersChoiceOfActivity(
            int startQuestionNumber, String activityType, int sectionCount)
        {
            //Select Answer Choice
            logger.LogMethodEntry("StudentPresentationPage", "SelectAnswersChoiceOfActivity",
             base.isTakeScreenShotDuringEntryExit);
            // Selection on the basis of activity
            switch (activityType)
            {
                case "StudyPlan":// Have hardcoded because it is expecting a constant value                
                    //Wait For Element
                    base.WaitForElement(By.XPath(string.Format(StudentPresentationPageResource
                      .StudentPresentation_Page_StudyPlan_AnswersChoice_Xpath_Locator, sectionCount
                      )));
                    //Select Radio Button
                    base.SelectRadioButtonByXPath(string.Format(StudentPresentationPageResource
                      .StudentPresentation_Page_StudyPlan_AnswersChoice_Xpath_Locator, sectionCount));
                    break;
                case "Test":// Have hardcoded because it was expecting a constant value
                    //Wait For Element
                    base.WaitForElement(By.XPath(string.Format(StudentPresentationPageResource
                      .StudentPresentation_Page_TestActivityAnswer_XPath_Locator,
                      startQuestionNumber)));
                    //Select Radio Button
                    base.SelectRadioButtonByXPath(string.Format(StudentPresentationPageResource
                      .StudentPresentation_Page_TestActivityAnswer_XPath_Locator,
                      startQuestionNumber));
                    break;
            }
            logger.LogMethodExit("StudentPresentationPage", "SelectAnswersChoiceOfActivity",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity By Student.
        /// </summary>
        public void SubmitThePostTestActivity()
        {
            //Submit The Activity
            logger.LogMethodEntry("StudentPresentationPage", "SubmitThePostTestActivity",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait Till Non-Titled Pop Up Window Load Properly
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_CustomWait_Time));
                //Wait For Element
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_MasterFinish_Button_Id_Locator));
                //Get Button Property
                IWebElement getMasterFinishButtonProperty = WebDriver.FindElement(By.Id
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_MasterFinish_Button_Id_Locator));
                //Click On Button
                base.ClickByJavaScriptExecutor(getMasterFinishButtonProperty);
                //Finish and Return to Course
                this.FinishAndReturnToCourse();
                //Close Activity
                new InstructionsPage().ClickTestCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "SubmitThePostTestActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Finish Activity and Return to Course.
        /// </summary>
        public void FinishAndReturnToCourse()
        {
            //Finish Activity and Return To Course
            logger.LogMethodEntry("StudentPresentationPage", "FinishAndReturnToCourse",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click On Finish Button In Course Materials
                this.ClickOnFinishButtonInCourseMaterials();
                //Wait Till Non-Titled Pop Up Window Load Properly
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                   StudentPresentation_Page_CustomWait_Time));
                //Wait For Element
                base.WaitForElement(By.PartialLinkText(StudentPresentationPageResource
                   .StudentPresentation_Page_ReturnToCourse_Button_Id_Locator));
                //Get Link Property
                IWebElement getReturnToCourseLinkProperties = base.
                    GetWebElementPropertiesByPartialLinkText
                    (StudentPresentationPageResource.
                     StudentPresentation_Page_ReturnToCourse_Button_Id_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getReturnToCourseLinkProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "FinishAndReturnToCourse",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Return To Course Button In MyItLab.
        /// </summary>
        public void ClickOnReturnToCourseInMyitlab()
        {
            //Click On Return to Course
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnReturnToCourseInMyitlab",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.PartialLinkText(StudentPresentationPageResource
                   .StudentPresentation_Page_ReturnToCourse_Button_Id_Locator));
                //Get Link Property
                IWebElement getReturnToCourseLinkProperties = base.
                    GetWebElementPropertiesByPartialLinkText
                    (StudentPresentationPageResource.
                     StudentPresentation_Page_ReturnToCourse_Button_Id_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getReturnToCourseLinkProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickOnReturnToCourseInMyitlab",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Finish And Return To Course.
        /// </summary>
        public void ClickOnFinishAndReturnToCourse()
        {
            //Click On Finish And Return To Course
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnFinishAndReturnToCourse",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click On Finish Button In Course Materials
                this.ClickOnFinishButtonInCourseMaterials();
                //Wait For Element
                base.WaitForElement(By.PartialLinkText(StudentPresentationPageResource.
                    StudentPresentation_Page_RETURNToCourse_Button_Id_Locator_HED));
                //Get Link Property
                IWebElement getReturnToCourseLinkProperties = base.
                    GetWebElementPropertiesByPartialLinkText
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_RETURNToCourse_Button_Id_Locator_HED);
                //Click on Button
                base.ClickByJavaScriptExecutor(getReturnToCourseLinkProperties);
                //Select 'Open Study Plan' Window
                this.SelectOpenStudyPlanWindow();
                //Refresh The Page
                base.RefreshTheCurrentPage();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_Sleep_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickOnFinishAndReturnToCourse",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Open Study Plan' Window.
        /// </summary>
        private void SelectOpenStudyPlanWindow()
        {
            //Select 'Open Study Plan' Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectOpenStudyPlanWindow",
             base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(StudentPresentationPageResource.
                StudentPresentation_Page_OpenStudyPlan_Window_Name);
            //Select Window
            base.SelectWindow(StudentPresentationPageResource.
                StudentPresentation_Page_OpenStudyPlan_Window_Name);
            logger.LogMethodExit("StudentPresentationPage", "SelectOpenStudyPlanWindow",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Finish Button In Course Materials.
        /// </summary>
        public void ClickOnFinishButtonInCourseMaterials()
        {
            //Click On Finish Button In Course Materials
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnFinishButtonInCourseMaterials",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                   StudentPresentation_Page_ActivityFinish_Button_Id_Locator));
                //Get Finish Button Property
                IWebElement getFinishButtonProperty = WebDriver.FindElement
                    (By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_ActivityFinish_Button_Id_Locator));
                //Click on Button
                base.ClickByJavaScriptExecutor(getFinishButtonProperty);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickOnFinishButtonInCourseMaterials",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity.
        /// </summary>
        public void SubmitTheActivityHED()
        {
            //Submit The Activity
            logger.LogMethodEntry("StudentPresentationPage", "SubmitTheActivityHED",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click On Submit Grade Button
                this.ClickOnSubmitGradeButton();
                //Click On Return To Course Button
                this.ClickOnReturnToCourseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "SubmitTheActivityHED",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Return To Course Button.
        /// </summary>
        public void ClickOnReturnToCourseButton()
        {
            //Click On Return To Course Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnReturnToCourseButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.PartialLinkText(StudentPresentationPageResource.
                        StudentPresentation_Page_RETURNToCourse_Button_Id_Locator_HED));
                //Get Link Property
                IWebElement getReturnToCourseLinkProperties = base.
                    GetWebElementPropertiesByPartialLinkText(StudentPresentationPageResource.
                    StudentPresentation_Page_RETURNToCourse_Button_Id_Locator_HED);
                //Click on Button
                base.ClickByJavaScriptExecutor(getReturnToCourseLinkProperties);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickOnReturnToCourseButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Submit Grade Button.
        /// </summary>
        private void ClickOnSubmitGradeButton()
        {
            //Click On Submit Grade Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSubmitGradeButton",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPresentation_Page_MasterFinish_Button_Id_Locator));
            //Get Button Property
            IWebElement getMasterFinishButtonProperty = WebDriver.FindElement(By.Id
                (StudentPresentationPageResource.
                StudentPresentation_Page_MasterFinish_Button_Id_Locator));
            //Click On Button
            base.ClickByJavaScriptExecutor(getMasterFinishButtonProperty);
            //Wait For Element
            base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPresentation_Page_ActivityFinish_Button_Id_Locator));
            //Get Finish Button Property
            IWebElement getFinishButtonProperty = WebDriver.FindElement(By.Id
                (StudentPresentationPageResource
                .StudentPresentation_Page_ActivityFinish_Button_Id_Locator));
            //Click on Button
            base.ClickByJavaScriptExecutor(getFinishButtonProperty);
            logger.LogMethodExit("StudentPresentationPage", "ClickOnSubmitGradeButton",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Pretest Window.
        /// </summary>
        public void SelectPretestWindow()
        {
            //Select Pretest Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectPretestWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(StudentPresentationPageResource.
                    StudentPresentation_Page_StudyPlanTypeActivity_WindowName);
                //Select Window
                base.SelectWindow(StudentPresentationPageResource.
                    StudentPresentation_Page_StudyPlanTypeActivity_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "SelectPretestWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Posttest Window.
        /// </summary>
        public void SelectPosttestWindow()
        {
            //Select Posttest Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectPosttestWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(StudentPresentationPageResource.
                    StudentPresentation_Page_StudyPlanTypeActivity_PostTest_Window_Title_Name);
                //Select Window
                base.SelectWindow(StudentPresentationPageResource.
                    StudentPresentation_Page_StudyPlanTypeActivity_PostTest_Window_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "SelectPosttestWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity In Course Materials Tab.
        /// </summary>
        public void SubmitTheActivityInCourseMaterialsTab()
        {
            //Submit The Activity In Course Materials Tab
            logger.LogMethodEntry("StudentPresentationPage",
                "SubmitTheActivityInCourseMaterialsTab",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                this.SelectWebActivityWindow(StudentPresentationPageResource.
                StudentPresentation_Page_WebActivity_Window_Name);
                //Click on the Next Button
                this.ClickNextQuestionButton();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                   StudentPresentation_Page_LaunchWindow_TimeValue));
                //Select the window
                this.SelectWebActivityWindow(StudentPresentationPageResource.
                StudentPresentation_Page_WebActivity_Window_Name);
                //Wait for element
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPresentation_Page_Select_QuestionRadioButton_Xpath_Locator));
                //Get the web element
                IWebElement getRadioButtonElementProperty = base.GetWebElementPropertiesByXPath
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_Select_QuestionRadioButton_Xpath_Locator);
                //Click on the redio button
                base.ClickByJavaScriptExecutor(getRadioButtonElementProperty);
                //Click On Submit Grade Button
                this.ClickOnSubmitGradeButton();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                   StudentPresentation_Page_LaunchWindow_TimeValue));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "SubmitTheActivityInCourseMaterialsTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Web Activity Window.
        /// </summary>
        /// <param name="windowName">This is Window Name.</param>
        public void SelectWebActivityWindow(string windowName)
        {
            //Select Web Activity Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectWebActivityWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(windowName);
                base.SelectWindow(windowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "SelectWebActivityWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Is Displayed Try Again Btton In Submission Page.
        /// </summary>
        /// <returns>Try Again Button.</returns>
        public bool IsDisplayedTryAgainBttonInSubmissionPage()
        {
            //Is Displayed Try Again Btton In Submission Page
            logger.LogMethodEntry("StudentPresentationPage",
                "IsDisplayedTryAgainBttonInSubmissionPage",
                       base.isTakeScreenShotDuringEntryExit);
            //Intialize the variable
            bool isTryAgainButtonDisplayed = false;
            try
            {
                //Select the window
                this.SelectWebActivityWindow(StudentPresentationPageResource.
                StudentPresentation_Page_WebActivity_Window_Name);
                //Wait for the element
                base.WaitForElement(By.Id(StudentPresentationPageResource
                        .StudentPresentation_Page_Try_Button_Id_Locator));
                isTryAgainButtonDisplayed = base.IsElementPresent(By.Id
                    (StudentPresentationPageResource
                        .StudentPresentation_Page_Try_Button_Id_Locator));
                //Click On Return To Course Button
                this.ClickOnReturnToCourseButton();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                   StudentPresentation_Page_LaunchWindow_TimeValue));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                  "IsDisplayedTryAgainBttonInSubmissionPage",
                        base.isTakeScreenShotDuringEntryExit);
            return isTryAgainButtonDisplayed;
        }

        /// <summary>
        /// Attempt Question In Presentation Page.
        /// </summary>
        public void AttemptQuestionInPresentationPage()
        {
            logger.LogMethodEntry("StudentPresentationPage",
                "AttemptQuestionInPresentationPage",
                       base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Generate GUID For Answer Text
                Guid answer = new Guid();
                // Wait and Select Window
                this.SelectTestWindow();
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPresentation_Page_AnswerTextbox_Xpath_Locator));
                //Enter Answer
                base.FillTextBoxByXPath(StudentPresentationPageResource.
                    StudentPresentation_Page_AnswerTextbox_Xpath_Locator, answer.ToString());
                //Click on the submit for grading button
                this.ClickOnSubmitForGradingButton();
                //Click on the Finish button
                this.ClickOnFinishButton();
                //Click On Return To Course Button
                this.ClickOnReturnToCourseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                  "AttemptQuestionInPresentationPage",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Finish button.
        /// </summary>
        private void ClickOnFinishButton()
        {
            //Click on the Finish button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnFinishButton",
                     base.isTakeScreenShotDuringEntryExit);
            //Wait for finish button
            base.WaitForElement(By.XPath(StudentPresentationPageResource
                .StudentPresentation_Page_Finish_Button_Xpath_Locator));
            IWebElement getFinishButton = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource
                .StudentPresentation_Page_Finish_Button_Xpath_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getFinishButton);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_Sleep_Value));
            logger.LogMethodExit("StudentPresentationPage", "ClickOnFinishButton",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectTestWindow()
        {
            //Select Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectTestWindow",
                      base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(StudentPresentationPageResource.
                StudentPresentation_Page_TestTypeActivity_WindowName_Title);
            //Select Window
            base.SelectWindow(StudentPresentationPageResource.
                StudentPresentation_Page_TestTypeActivity_WindowName_Title);
            logger.LogMethodExit("StudentPresentationPage", "SelectTestWindow",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit SIM Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SubmitSIMActivity(String activityName)
        {
            logger.LogMethodEntry("StudentPresentationPage", "SubmitSIMActivity",
                       base.isTakeScreenShotDuringEntryExit);
            try
            {
                if (!Playback.IsInitialized)
                {
                    Playback.Initialize();
                }
                //Select Window And Frame
                this.SelectWindowAndFrame();                 
                //Click On Activity
                this.ClickOnActivity(activityName);        
                //Select Window
                this.SelectTheSIMStudyplanWindow(activityName);
                //Set Text Cursor Position
                this.SetTextCursorPosition();
                //Select Insert Tab And Select Insert Object Dropdown Option
                this.SelectInsertTabAndSelectInsertObjectDropdownOption();
                //Add the File
                this.AddFile();
                //Click The Asset Submission Ok Button
                this.ClickTheAssetSubmissionOkButton();                
                Playback.Cleanup();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "SubmitSIMActivity",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void ClickOnActivity(String activityName)
        {
            //Click On Activity
            logger.LogMethodEntry("StudentPresentationPage", "SubmitSIMActivity",
                      base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPresentation_Page_Activity_Count_Xpath_Locator));
            //Get Activity Count
            int getActivityCount = base.GetElementCountByXPath(StudentPresentationPageResource.
                StudentPresentation_Page_Activity_Count_Xpath_Locator);
            for (int rowCount = Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Loop_InitialValue);
                rowCount <= getActivityCount; rowCount++)
            {
                base.WaitForElement(By.XPath(string.Format(StudentPresentationPageResource.
                    StudentPresentation_Page_Activity_Name_Xpath_Locator, rowCount)));
                //Get Activity Name
                string getActivityName =
                    base.GetElementTextByXPath(string.Format(StudentPresentationPageResource.
                    StudentPresentation_Page_Activity_Name_Xpath_Locator, rowCount));
                if (getActivityName.Contains(activityName))
                {
                    //Click On Activity
                    base.ClickLinkByXPath(string.Format(StudentPresentationPageResource.
                        StudentPresentation_Page_Activity_Xpath_Locator, rowCount));
                    break;
                }
            }
            logger.LogMethodExit("StudentPresentationPage", "SubmitSIMActivity",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Ok Button.
        /// </summary>
        /// <param name="xValue">This is X Coordinator Value.</param>
        /// <param name="yValue">This is Y Coordinator Value.</param>
        public void ClickOnOkButton(string xValue, string yValue)
        {
            //Click On Ok Button            
            try
            {
                //Get Ok Button Property
                IWebElement getCustomMessageWindowProperty = base.GetWebElementPropertiesByXPath(
                    StudentPresentationPageResource.
                    StudentPresentation_Page_MessageWindow_Ok_Button_Xpath_Locator);
                Point getOkButtonPosition =
                    new Point((getCustomMessageWindowProperty.Location.X +
                        Convert.ToInt32(xValue)),
                        (getCustomMessageWindowProperty.Location.Y +
                        Convert.ToInt32(yValue)));
                //Mouse Hover
                Mouse.Hover(getOkButtonPosition);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_Sleep_Value));
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_Sleep_Value));
                //Click on the Ok Button
                Mouse.Click(getOkButtonPosition);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_Sleep_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }            
        }

        /// <summary>
        /// Add File.
        /// </summary>
        private void AddFile()
        {
            //Add File
            logger.LogMethodEntry("StudentPresentationPage", "AddFile",
                       base.isTakeScreenShotDuringEntryExit);
            Keyboard.SendKeys(StudentPresentationPageResource.
                StudentPresentation_Page_Add_File_Name);
            base.PressKey(StudentPresentationPageResource.
                StudentPresentation_Page_Tab_Key_Value);
            base.PressKey(StudentPresentationPageResource.
                StudentPresentation_Page_Tab_Key_Value);
            base.PressKey(StudentPresentationPageResource.
                StudentPresentation_Page_EnterKey_Value);
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPresentation_Page_MessageWindow_Ok_Button_Xpath_Locator));
            logger.LogMethodExit("StudentPresentationPage", "AddFile",
                       base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Insert Tab And Select Insert Object Dropdown Option.
        /// </summary>
        private void SelectInsertTabAndSelectInsertObjectDropdownOption()
        {
            //Select Insert Tab And Select Insert Object Dropdown Option
            logger.LogMethodEntry("StudentPresentationPage",
                "SelectInsertTabAndSelectInsertObjectDropdownOption",
                       base.isTakeScreenShotDuringEntryExit);
            //Click on the Insert tab
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPresentation_Page_InsertTab_SIM_Player_Xpath_Locator));
            IWebElement getInsertProperty = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.
                StudentPresentation_Page_InsertTab_SIM_Player_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getInsertProperty);
            //click on  Insert Object Dropdown
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                 StudentPresentation_Page_InsertObject_Dropdown_Xpath_Locator));
            IWebElement getInsertObjectDropDownproperty = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.
                StudentPresentation_Page_InsertObject_Dropdown_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getInsertObjectDropDownproperty);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Sleep_Value));
            //click on the Insert Object Dropdown option
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPresentation_Page_InsertObject_Dropdown_Option_Xpath_Locator));
            IWebElement getInsertObjectDropdownOption = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.
                StudentPresentation_Page_InsertObject_Dropdown_Option_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getInsertObjectDropdownOption);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Sleep_Value));
            logger.LogMethodExit("StudentPresentationPage",
                "SelectInsertTabAndSelectInsertObjectDropdownOption",
                       base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Text Cursor Position.
        /// </summary>
        private void SetTextCursorPosition()
        {
            //Set Text Cursor Position
            logger.LogMethodEntry("StudentPresentationPage", "SetTextCursorPosition",
                       base.isTakeScreenShotDuringEntryExit);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Sleep_Value));
            //Get the Cursor Position
            IWebElement getFirstTextDefaultCursorPosition = base.GetWebElementPropertiesById(
                StudentPresentationPageResource.
                StudentPresentation_Page_FirstText_CursorPosition_Id_Locator);
            //Get Exact Cursor Position
            Point getFirstTextExactCursorPosition =
                new Point((getFirstTextDefaultCursorPosition.Location.X +
                    Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_Text_Cursor_Position_Xaxis_Value)),
                    (getFirstTextDefaultCursorPosition.Location.Y +
                    Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_Text_Cursor_Position_Yaxis_Value)));
            //Click on the Cursor location to display the cursor
            Mouse.Click(getFirstTextExactCursorPosition);
            //Get text to move the cursor to the Last position           
            string getText = base.GetElementTextByID(StudentPresentationPageResource.
                StudentPresentation_Page_FirstText_CursorPosition_Id_Locator);
            getText = base.GetElementTextByID(StudentPresentationPageResource.
                StudentPresentation_Page_SecondText_CursorPosition_Id_Locator) + getText;
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Sleep_Value));
            for (int cursorPosition = Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Loop_Initializer_Value);
                cursorPosition < getText.Length + Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Loop_Boundary_Additional_Value); cursorPosition++)
            {
                //Press Right Key
                base.PressKey(StudentPresentationPageResource.
                    StudentPresentation_Page_RightKey_Value);
            }
            logger.LogMethodExit("StudentPresentationPage", "SetTextCursorPosition",
                      base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window And Frame.
        /// </summary>
        public void SelectWindowAndFrame()
        {
            //Select Window And Frame
            logger.LogMethodEntry("StudentPresentationPage", "SelectWindowAndFrame",
                       base.isTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                        StudentPresentation_Page_Sleep_Value));
                 base.WaitUntilWindowLoads(StudentPresentationPageResource.
                    StudentPresentation_Page_BaseWindow_Title_Name);
                //Select Window
                base.SelectWindow(StudentPresentationPageResource.
                    StudentPresentation_Page_BaseWindow_Title_Name);
                //Switch To Frame
                base.SwitchToIFrameById(StudentPresentationPageResource.
                    StudentPresentation_Page_Content_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }          
            logger.LogMethodExit("StudentPresentationPage", "SelectWindowAndFrame",
                      base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Status.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Status.</returns>
        public String GetActivityStatus(String activityName)
        {
            logger.LogMethodEntry("StudentPresentationPage",
                 "GetActivityStatus", base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSubmittedActivityStatus = string.Empty;
            try
            {
                //Select Window And Frame
                this.SelectWindowAndFrame();
                //Get Status Of Submitted Activity
                getSubmittedActivityStatus = new CoursePreviewMainUXPage().
                    GetStatusOfSubmittedActivity(activityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                  "GetActivityStatus", base.isTakeScreenShotDuringEntryExit);
            return getSubmittedActivityStatus;
        }

        /// <summary>
        /// Submit Training Material SIM StudyPlan Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SubmitTrainingMaterialSIMStudyPlanActivity(string activityName)
        {
            //Submit Training Material SIM StudyPlan Activity
            logger.LogMethodEntry("StudentPresentationPage",
                "SubmitTrainingMaterialSIMStudyPlanActivity",
                        base.isTakeScreenShotDuringEntryExit);
            try
            {
                if (!Playback.IsInitialized)
                {
                    Playback.Initialize();
                }
                //Select Window And Frame
                this.SelectWindowAndFrame();
                //Click The Activity In CourseMaterial
                this.SelectActivityNameInCourseMaterialTab(activityName);
                //Click On Training Material button
                this.ClickOnTrainingMaterialButton();
                //Fetch Activity From Memory
                Activity activityPretest = Activity.Get(
                      Activity.ActivityTypeEnum.Sim5PreTest);
                //Select StudyPlan Traning Material Window
                this.SelectStudyPlanTraningMaterialWindow(activityPretest.Name);  
                // Fill The Answer In TextBox
                this.FillTheAnswerInTextBox();
                //Click The SimStudyPlan Ok Button
                this.ClickTheAssetSubmissionOkButton();
                Playback.Cleanup();
                //Select MyItLab Window
                this.SelectMyItLabWindow();
                //Click StudyPlan Cancel Button
                this.ClickStudyPlanCancelButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "SubmitTrainingMaterialSIMStudyPlanActivity",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select StudyPlan Traning Material Window.
        /// </summary>
        /// <param name="activityName">This is Pretest Activity Name.</param>
        private void SelectStudyPlanTraningMaterialWindow(string activityName)
        {
            //Select StudyPlan Traning Material Window
            logger.LogMethodEntry("StudentPresentationPage",
                "SelectStudyPlanTraningMaterialWindow",
                        base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.WaitUntilWindowLoads(activityName + StudentPresentationPageResource.
                StudentPresentation_Page_TraingMaterial_Window_Name + 
                StudentPresentationPageResource.
               StudentPresentation_Page_SimPresentation_Window_Name);
            base.SelectWindow(activityName + StudentPresentationPageResource.
                StudentPresentation_Page_TraingMaterial_Window_Name +
                StudentPresentationPageResource.
               StudentPresentation_Page_SimPresentation_Window_Name);   
            logger.LogMethodExit("StudentPresentationPage",
                "SelectStudyPlanTraningMaterialWindow",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Training Material Button.
        /// </summary>
        private void ClickOnTrainingMaterialButton()
        {
            //Click On Training Material Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnTrainingMaterialButton",
                        base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPresentation_Page_TraingMaterial_Button_Xpath_Locator));
            IWebElement getTrainingMaterial = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.
                StudentPresentation_Page_TraingMaterial_Button_Xpath_Locator);
            //Clicck on the 'Training Material' button
            base.ClickByJavaScriptExecutor(getTrainingMaterial);
            logger.LogMethodExit("StudentPresentationPage", "ClickOnTrainingMaterialButton",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill The Answer In TextBox.
        /// </summary>
        private void FillTheAnswerInTextBox()
        {
            // Fill The Answer In TextBox
            logger.LogMethodEntry("StudentPresentationPage","FillTheAnswerInTextBox",
                   base.isTakeScreenShotDuringEntryExit);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_FillText_TextBoxPosition_Value));
            //Fill the Answer
            Keyboard.SendKeys(StudentPresentationPageResource.
                StudentPresentation_Page_Fill_A1_Answer);
            //Press DownArrow Key
            base.PressKey(StudentPresentationPageResource.
                StudentPresentation_Page_Down_Key_Value);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_FillText_TextBoxPosition_Value));
            //Fill the Answer
            Keyboard.SendKeys(StudentPresentationPageResource.
                StudentPresentation_Page_Fill_A2_Answer);            
            //Press DownArrow Key
            base.PressKey(StudentPresentationPageResource.
                StudentPresentation_Page_Down_Key_Value);
            base.PressKey(StudentPresentationPageResource.
                StudentPresentation_Page_Down_Key_Value);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_FillText_TextBoxPosition_Value));
            //Fill the Answer
            Keyboard.SendKeys(StudentPresentationPageResource.
                StudentPresentation_Page_Fill_A4_Answer);
            base.PressKey(StudentPresentationPageResource.
                StudentPresentation_Page_Down_Key_Value);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_FillText_TextBoxPosition_Value));
            Keyboard.SendKeys(StudentPresentationPageResource.
                StudentPresentation_Page_Fill_A5_Answer);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_FillText_TextBoxPosition_Value));
            //Press Enter Key
            base.PressKey(StudentPresentationPageResource.
                StudentPresentation_Page_EnterKey_Value);            
            logger.LogMethodExit("StudentPresentationPage", "FillTheAnswerInTextBox",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On PreTest Activity Button.
        /// </summary>
        private void ClickOnPreTestActivityButton()
        {
            //Click On PreTest Activity Button
            logger.LogMethodEntry("StudentPresentationPage",
                "ClickOnPreTestActivityButton",
                   base.isTakeScreenShotDuringEntryExit);
            //Select MyItLab Window
            this.SelectMyItLabWindow();            
            //Wait for the elemenet
            base.WaitForElement(By.ClassName(StudentPresentationPageResource.
                StudentPresentation_Page_PreTest_Link_Class_Locator));
            IWebElement getPretestLink=base.GetWebElementPropertiesByClassName
                (StudentPresentationPageResource.
                StudentPresentation_Page_PreTest_Link_Class_Locator);
            //Click on 'Pre-Test' Link
            base.ClickByJavaScriptExecutor(getPretestLink);
            //Click On Activity Alert Window
            this.ClickOnActivityAlertWindow();
            logger.LogMethodExit("StudentPresentationPage",
                "ClickOnPreTestActivityButton",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selec tMyItLab Window.
        /// </summary>
        private void SelectMyItLabWindow()
        {
            // Selec tMyItLab Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectMyItLabWindow",
                  base.isTakeScreenShotDuringEntryExit);
            //Select the Pretest window
            base.WaitUntilWindowLoads(StudentPresentationPageResource.
                StudentPresentation_Page_StudyPlan_Window_Name);
            base.SelectWindow(StudentPresentationPageResource.
                StudentPresentation_Page_StudyPlan_Window_Name);
            logger.LogMethodExit("StudentPresentationPage", "SelectMyItLabWindow",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity Alert Window.
        /// </summary>
        private void ClickOnActivityAlertWindow()
        {
            //Click On Activity Alert Window
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnActivityAlertWindow",
                       base.isTakeScreenShotDuringEntryExit);
            //Select the Pretest window
            base.WaitUntilWindowLoads(StudentPresentationPageResource.
                StudentPresentation_Page_Activity_Alert_Window_Name);
            base.SelectWindow(StudentPresentationPageResource.
                StudentPresentation_Page_Activity_Alert_Window_Name);
            //Wait for the elemenet
            base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPresentation_Page_Alert_Continue_Button_Id_Locator));
            IWebElement getContinueButton = base.GetWebElementPropertiesById
                (StudentPresentationPageResource.
                StudentPresentation_Page_Alert_Continue_Button_Id_Locator);
            //Click on 'Continue' button
            base.ClickByJavaScriptExecutor(getContinueButton);
            logger.LogMethodExit("StudentPresentationPage", "ClickOnActivityAlertWindow",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Asset Submission Ok Button.
        /// </summary>
        private void ClickTheAssetSubmissionOkButton()
        {
            //Click The Asset Submission Ok Button
            logger.LogMethodEntry("StudentPresentationPage",
                "ClickTheAssetSubmissionOkButton",
                       base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Ok_Button_MessageBox_Xpath_Locator));
            base.FocusOnElementByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Ok_Button_MessageBox_Xpath_Locator);
            //Click on Ok button
            IWebElement getOkButton = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.
                StudentPrsentation_Page_Ok_Button_MessageBox_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getOkButton);            
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Sleep_Value));
            logger.LogMethodExit("StudentPresentationPage",
                "ClickTheAssetSubmissionOkButton",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the submit button.
        /// </summary>
        public void ClickOnSubmitButton()
        {
            //Click the submit button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSubmitButton",
                        base.isTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                       StudentPresentation_Page_FillText_TextBoxPosition_Value));
                //Wait for the element
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_StudyPlan_Submit_Button_Id_Locator));
                IWebElement getSubmitButton = base.GetWebElementPropertiesById
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_StudyPlan_Submit_Button_Id_Locator);
                //Click the submit button
                base.ClickByJavaScriptExecutor(getSubmitButton);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_FillText_TextBoxPosition_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickOnSubmitButton",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Status Of Submitted Activity In CourseMaterial.
        /// </summary>
        /// <param name="assetName">This is Activity Name.</param>
        /// <returns>Activity Status.</returns>
        public string GetStatusOfSubmittedActivityInCourseMaterial(string assetName)
        {
            //Get Status Of Submitted Activity In CourseMaterial
            logger.LogMethodEntry("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.isTakeScreenShotDuringEntryExit);
            //Initialize getStatusText variable
            string getActivitySubmittedStatus = string.Empty;
            try
            {
                //Select Window And Frame
                this.SelectWindowAndFrame();
                //Get The Activity Name In CourseMaterial
                int activityColumnCount =
                    this.GetTheActivityNameInCourseMaterial(assetName);
                //Get the status text
                getActivitySubmittedStatus = base.GetElementTextByXPath(string.
                Format(StudentPresentationPageResource.
                StudentPresentation_Page_Activity_Status_Xpath_Locator, activityColumnCount));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.isTakeScreenShotDuringEntryExit);
            return getActivitySubmittedStatus;
        }

        /// <summary>
        /// Select The SIMStudyplan Window.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void SelectTheSIMStudyplanWindow(string activityName)
        {
            //Select The SIMStudyplan Window
            logger.LogMethodEntry("StudentPresentationPage",
                "SelectTheSIMStudyplanWindow",
                     base.isTakeScreenShotDuringEntryExit);
            //Select Window
           base.WaitUntilWindowLoads(activityName + StudentPresentationPageResource.
              StudentPresentation_Page_SimPresentation_Window_Name);
           base.SelectWindow(activityName + StudentPresentationPageResource.
              StudentPresentation_Page_SimPresentation_Window_Name);
            logger.LogMethodExit("StudentPresentationPage", 
                "SelectTheSIMStudyplanWindow",
                      base.isTakeScreenShotDuringEntryExit);
        }       

        /// <summary>
        /// Click StudyPlan Cancel Button.
        /// </summary>
        private void ClickStudyPlanCancelButton()
        {
            //Click StudyPlan Cancel Button
            logger.LogMethodEntry("StudentPresentationPage",
                "ClickStudyPlanCancelButton",
                         base.isTakeScreenShotDuringEntryExit);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_FillText_TextBoxPosition_Value));
            //Wait for the element
            base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPresentation_Page_Studyplan_Cancel_Id_Locator));
            IWebElement getCancelButton = base.GetWebElementPropertiesById
                (StudentPresentationPageResource.
                StudentPresentation_Page_Studyplan_Cancel_Id_Locator);
            //Click the 'Cancel' Button
            base.ClickByJavaScriptExecutor(getCancelButton);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_FillText_TextBoxPosition_Value));
            logger.LogMethodExit("StudentPresentationPage",
                "ClickStudyPlanCancelButton",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit SIM StudyPlan PreTest Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SubmitSIMStudyPlanPreTestActivity(string activityName)
        {
            //Submit SIM StudyPlan PreTest Activity
            logger.LogMethodEntry("StudentPresentationPage",
                "SubmitSIMStudyPlanPreTestActivity",
                         base.isTakeScreenShotDuringEntryExit);
            try
            {
                if (!Playback.IsInitialized)
                {
                    Playback.Initialize();
                }
                //Select Window And Frame
                this.SelectWindowAndFrame();
                //Click The Activity In CourseMaterial
                this.SelectActivityNameInCourseMaterialTab(activityName);               
                //Click On PreTest Activity Button
                this.ClickOnPreTestActivityButton();
                //Fetch Activity From Memory
                Activity activityPretest = Activity.Get(
                    Activity.ActivityTypeEnum.Sim5PreTest);
                //Select The SIMStudyplan Window
                this.SelectTheSIMStudyplanWindow(activityPretest.Name);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_CustomWait_Time));
                //Click the 'Submit' button
                this.ClickOnSubmitButton();
                //Click The SimStudyPlan Ok Button
                this.ClickTheAssetSubmissionOkButton();
                //Clear the Initializer
                Playback.Cleanup();
                //Select MyItLab Window
                this.SelectMyItLabWindow();
                //Click StudyPlan Cancel Button
                this.ClickStudyPlanCancelButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "SubmitSIMStudyPlanPreTestActivity",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Activity Name In CourseMaterial.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private int GetTheActivityNameInCourseMaterial(string activityName)
        {
            //Get The Activity Name In CourseMaterial
            logger.LogMethodEntry("StudentPresentationPage",
                "GetTheActivityNameInCourseMaterial",
                      base.isTakeScreenShotDuringEntryExit);
             //Initialize VariableVariable
            int activityColumnNumber = Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Loop_Initializer_Value); 
            //Wait for the element
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPresentation_Page_Activity_TotalCount_Xpath_locator));
            //Get Activity Count
            int getActivityCount = base.GetElementCountByXPath(StudentPresentationPageResource.
                StudentPresentation_Page_Activity_TotalCount_Xpath_locator);
            for (int rowCount = Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Loop_InitialValue);
                rowCount <= getActivityCount; rowCount++)
            {
                //Get Activity Name
                string getActivityName =
                    base.GetElementTextByXPath(string.Format
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_Asset_Name_Xpath_locator, rowCount));
                if (getActivityName.Contains(activityName))
                {
                    activityColumnNumber=rowCount;
                    break;
                }
            }
            logger.LogMethodExit("StudentPresentationPage",
                "GetTheActivityNameInCourseMaterial",
                        base.isTakeScreenShotDuringEntryExit);
            return activityColumnNumber;
        }

        /// <summary>
        /// Select Activity Name In CourseMaterial Tab.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SelectActivityNameInCourseMaterialTab(string activityName)
        {
            //Select Activity Name In CourseMaterial Tab
            logger.LogMethodEntry("StudentPresentationPage",
                "SelectActivityNameInCourseMaterialTab",
                      base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get The Activity Name In CourseMaterial
                int activityColumnCount =
                    this.GetTheActivityNameInCourseMaterial(activityName);
                //get the web element
                IWebElement getActivityNameLink = base.GetWebElementPropertiesByXPath
                    (string.Format(StudentPresentationPageResource.
                      StudentPresentation_Page_Asset_LinkName_Xpath_locator,
                               activityColumnCount));
                //Click On Activity
                base.ClickByJavaScriptExecutor(getActivityNameLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "SelectActivityNameInCourseMaterialTab",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit SIM Study Plan Pre test.
        /// </summary>
        /// <param name="activityName">This is Activity name.</param>
        public void SubmitSIMStudyPlanPreTestActivityByStudent(string activityName)
        {
            //Logger Entry
            logger.LogMethodEntry("StudentPresentationPage",
                "SubmitSIMStudyPlanPreTestActivityByStudent",
                        base.isTakeScreenShotDuringEntryExit);
            try
            {
                if (!Playback.IsInitialized)
                {
                    Playback.Initialize();
                }
                //Select The SIMStudyplan Window
                this.SelectTheSIMStudyplanWindow(activityName);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Thread_Time));
                //Click The SimStudyPlan Ok Button
                this.ClickTheAssetSubmissionOkButton();
                //Clear the Initializer
                Playback.Cleanup();
                //Select MyItLab Window
                this.SelectMyItLabWindow();
                //Click StudyPlan Cancel Button
                this.ClickStudyPlanCancelButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            logger.LogMethodExit("StudentPresentationPage",
                "SubmitSIMStudyPlanPreTestActivityByStudent",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save For Later.
        /// </summary>
        public void ClickOnSaveForLater()            
        {
            //Click On Save For Later
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSaveForLater",
                        base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_SaveForLater_Id_Locator));
                //Get Link Property
                IWebElement getReturnToCourseLinkProperties = base.
                    GetWebElementPropertiesById
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_SaveForLater_Id_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getReturnToCourseLinkProperties);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource
                    .StudentPresentation_Page_LaunchWindowClose_TimeValue));
                //Wait for the element
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_Save_Button_Id_Locator));
                IWebElement getSaveButton = base.GetWebElementPropertiesById
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_Save_Button_Id_Locator);
                //Click on save button
                base.ClickByJavaScriptExecutor(getSaveButton);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource
                    .StudentPresentation_Page_LaunchWindowClose_TimeValue));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickOnSaveForLater",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On FeedBack Icon
        /// </summary>
        public void ClickOnFeedbackIcon()
        {
            //Click On FeedBack Icon
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnFeedbackIcon",
                       base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Element
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_Feedback_Button_Id));
                IWebElement getFeedBackProperty = base.GetWebElementPropertiesById(
                    StudentPresentationPageResource.StudentPresentation_Page_Feedback_Button_Id);
                //Click On Feedback Property
                base.ClickByJavaScriptExecutor(getFeedBackProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickOnFeedbackIcon",
                    base.isTakeScreenShotDuringEntryExit);
            
        }

        /// <summary>
        /// Get FeedBack Text
        /// </summary>
        /// <returns>FeedBack Text</returns>
        public String getFeedBackText()
        {
            //Get Feedback Text
            logger.LogMethodEntry("StudentPresentationPage", "getFeedBackText",
                      base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getFeedbackText = string.Empty;            
            try
            {
                //Get Feedback Text
                getFeedbackText = base.GetElementTextByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_FeedbackText_Xpath_Locator);
                string[] split = getFeedbackText.Split(Convert.ToChar(
                    StudentPresentationPageResource.StudentPresentation_Page_Feedback_colon));
                getFeedbackText = split[Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Return_Value)];
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }        
            logger.LogMethodExit("StudentPresentationPage", "getFeedBackText",
                    base.isTakeScreenShotDuringEntryExit);
            return getFeedbackText;
        }

        /// <summary>
        /// Verify Feedback Text Present in Presentation Page.
        /// </summary>
        /// <param name="feedbackOption">This is Feedback Option.</param>
        /// <returns>Feedback Text Status In Presentation Page.</returns>
        public bool IsFeedbackTextPresent(string feedbackOption)
        {
            //Verify Feedback Text Present in Presentation Page
            logger.LogMethodEntry("StudentPresentationPage", "IsFeedbackTextPresent",
                      base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isFeedbackTextPresent = false;
            string getFeedbackText = string.Empty;
            try
            {
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPrsentation_Page_FeedbackText_Id_Locator));
                //Get Feedback Text
                getFeedbackText = base.GetElementTextByID(
                    StudentPresentationPageResource.
                    StudentPrsentation_Page_FeedbackText_Id_Locator);
                if (getFeedbackText.Contains(feedbackOption))
                {
                    isFeedbackTextPresent = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "IsFeedbackTextPresent",
                    base.isTakeScreenShotDuringEntryExit);
            return isFeedbackTextPresent;
        }

        /// <summary>
        /// Attempt The Gradable Asset.
        /// </summary>
        /// <param name="activityType">This is Activity type.</param>
        public void AttemptTheGradableAsset(string activityType)
        {
            //Attempt The Gradable Asset
            logger.LogMethodEntry("StudentPresentationPage","AttemptTheGradableAsset",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click the start button
                ClickStartButtonOnPresentationWindow(activityType);
                //Wait for the element
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Essay_Textbox_Xpath_Locator));
                base.FillTextBoxByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Essay_Textbox_Xpath_Locator,
                    StudentPresentationPageResource.
                    StudentPrsentation_Page_Essay_Text);               
                //Click on Submit For Grade Button
                this.ClickOnSubmitForGradingButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage","AttemptTheGradableAsset",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Essay Question Submission.
        /// </summary>
        public void EssayQuestionSubmission()
        {
            //Essay Question Submission
            logger.LogMethodEntry("StudentPresentationPage", "EssayQuestionSubmission",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click the Start button
                new InstructionsPage().ClickTestStartButton();
                //Attempt Essay Question Submission
                this.AttemptTheEssayQuestionSubmission();               
                //Click on Submit For Grade Button
                this.ClickOnSubmitForGradingButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "EssayQuestionSubmission",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt Essay Question Submission.
        /// </summary>
        private void AttemptTheEssayQuestionSubmission()
        {
            //Attempt Essay Question Submission
            logger.LogMethodEntry("StudentPresentationPage", 
                "AttemptTheEssayQuestionSubmission",
              base.isTakeScreenShotDuringEntryExit);
            base.SwitchToLastOpenedWindow();
            //Select the window
            this.SelectWebActivityWindow("Quiz");
            //Wait for the element
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Essay_Textbox_Xpath_Locator));
            base.FillTextBoxByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Essay_Textbox_Xpath_Locator,
                StudentPresentationPageResource.
                StudentPrsentation_Page_Essay_Text);
            logger.LogMethodExit("StudentPresentationPage", 
                "AttemptTheEssayQuestionSubmission",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity In Course Material.
        /// </summary>
        public void SubmitTheActivityInCourseMaterial()
        {
            //Submit The Activity In Course Material
            logger.LogMethodEntry("StudentPresentationPage", "SubmitTheActivityInCourseMaterial",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Submit Activity
                this.SubmitActivity();
                // Switch to default window after closing of presentation pop up
                base.WaitUntilWindowLoads(StudentPresentationPageResource
                     .StudentPresentation_Page_BaseWindow_Title_Name);
                base.SelectWindow(StudentPresentationPageResource
                     .StudentPresentation_Page_BaseWindow_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "SubmitTheActivityInCourseMaterial",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit Activity.
        /// </summary>
        public void SubmitActivity()
        {
            //Submit Activity
            logger.LogMethodEntry("StudentPresentationPage", "SubmitActivity",
                base.isTakeScreenShotDuringEntryExit);
            try
            {                
                //Attempt The Activity In StudentSide
                this.AttemptTheActivityInStudentSide();                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "SubmitActivity",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Last Opened Window.
        /// </summary>
        public void SelectLastOpenedWindow()
        {
            //Select Last Opened Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectLastOpenedWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToLastOpenedWindow();
                //Get Window Title
                string windowTitle = base.GetPageTitle;
                base.WaitUntilWindowLoads(windowTitle);
                //Select Presentation Window
                base.SelectWindow(windowTitle);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "SelectLastOpenedWindow",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt The Activity In StudentSide.
        /// </summary>
        public void AttemptTheActivityInStudentSide()
        {
            //Attempt The Activity In StudentSide
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTheActivityInStudentSide",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Declare the obejects
                InstructionsPage instructionsPage = new InstructionsPage();
                //Click the Start button
                instructionsPage.ClickTestStartButton();
                //Wait for the element
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                   StudentPresentation_Page_Asset_Radio_Button_Xpath_locator));
                IWebElement getRadioButton = base.GetWebElementPropertiesByXPath
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_Asset_Radio_Button_Xpath_locator);
                //Select the radio button
                base.ClickByJavaScriptExecutor(getRadioButton);
                //Click on the submit for grading button
                this.ClickOnSubmitForGradingButton();
                //Click on the Finish button
                this.ClickOnFinishButton();
                //Click On Return To Course Button
                this.ClickOnReturnToCourseInMyitlab();
                // Select close button on the Test window
                instructionsPage.ClickTestCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptTheActivityInStudentSide",
                    base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// verify Window Switching, which is a confirmation that activity is open in normal Browser mode
        /// </summary>
        public void verifyWindowSwitching()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTheActivityInStudentSide",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(15000);                
                //base.WaitUntilPopUpLoads("SIM 5 - ws student", 15);
                base.SwitchToLastOpenedWindow();
                string Sim5Title = WebDriver.Title;
                string SimURL = WebDriver.Url;
                string currHandle1 = WebDriver.CurrentWindowHandle;
                base.SwitchToDefaultWindow();
                string PTitle = WebDriver.Title;
                string strPURL = WebDriver.Url;
                string currHandle2 = WebDriver.CurrentWindowHandle;
                base.SwitchToLastOpenedWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptTheActivityInStudentSide",
                    base.isTakeScreenShotDuringEntryExit);
        }
    }
}
