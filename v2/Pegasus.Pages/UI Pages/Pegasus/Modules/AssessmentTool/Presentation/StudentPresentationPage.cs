﻿using Microsoft.VisualStudio.TestTools.UITesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using Keys = OpenQA.Selenium.Keys;
using Pegasus.Automation;
using System.IO;
using System.Globalization;
using Pegasus.Pages.CommonPageObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Discussion;

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
        private const string ENV_PEG_AUTOMATION_BROWSER = "PEG_AUTOMATION_BROWSER";
        private const string APP_SETTINGS_BROWSER = "Browser";

        private int waitTimeOut = Convert.ToInt32(
            ConfigurationManager.AppSettings["ElementFindTimeOutInSeconds"]);
        PowerPointSim5Activity powerPoint = new PowerPointSim5Activity();
        /// <summary>
        /// Opens Activity Presentation Window.
        /// </summary>
        /// <returns>Activity Presentation Window Open Result.</returns>
        public Boolean IsActivityPresentationPageOpened()
        {
            //Opens Activity Presentation Window
            logger.LogMethodEntry("StudentPresentationPage",
                "IsActivityPresentationPageOpened",
                base.IsTakeScreenShotDuringEntryExit);
            Boolean isActivityPresentationPageDisplayed = false;
            try
            {
                //Select Window
                base.SelectWindow(StudentPresentationPageResource.
                        StudentPresentation_Page_Window_Title_Name);
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_AssessmentHolder_Id_Locator));
                // Is Activity Displayed in Presentation Window
                isActivityPresentationPageDisplayed = base.IsElementDisplayedById
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
                base.IsTakeScreenShotDuringEntryExit);
            return isActivityPresentationPageDisplayed;
        }
        /// <summary>
        /// Opens Amplifire Link Window.
        /// </summary>
        /// <returns>Amplifire Link Window Open Result.</returns>
        public Boolean IsAmplifireLinkPageOpened()
        {
            //Opens Amplifire Link Window
            logger.LogMethodEntry("StudentPresentationPage",
                "IsAmplifireLinkPageOpened",
                base.IsTakeScreenShotDuringEntryExit);
            Boolean isAmplifireLinkPageDisplayed = false;
            try
            {
                //Select Amplifire pop up Window               
                base.SwitchToLastOpenedWindow();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_LaunchAmplifireWindowClose_TimeValue));
                // Is Activity Displayed in Presentation Window
                isAmplifireLinkPageDisplayed = base.IsElementDisplayedById
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_AmplifireBookImage_Id_Locator);

                //Close The Window
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "IsAmplifireLinkPageOpened",
                base.IsTakeScreenShotDuringEntryExit);
            return isAmplifireLinkPageDisplayed;
        }

        /// <summary>
        /// Click on Back image icon
        /// in View all course materials.
        /// </summary>
        public void ClickOnBackIconInCourseMaterials()
        {
            //Click on back icon
            logger.LogMethodEntry("StudentPresentationPage",
               "ClickOnBackIconInCourseMaterials",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on back icon
            base.ClickButtonById(StudentPresentationPageResource.
                StudentPresentation_Back_Icon_Id_Locator);
            logger.LogMethodExit("StudentPresentationPage",
                "ClickOnBackIconInCourseMaterials",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Submit the activity in presentation window.
        /// </summary>
        public void AttemptActivity()
        {
            //Opens Activity Presentation Window
            logger.LogMethodEntry("StudentPresentationPage", "AttemptActivity",
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Pop Up Loads
            base.WaitUntilWindowLoads(StudentPresentationPageResource.
                StudentPrsentation_Page_Test_Window_Name);
            //Select Window
            base.SelectWindow(StudentPresentationPageResource.
                StudentPrsentation_Page_Test_Window_Name);
            logger.LogMethodExit("StudentPresentationPage", "SelectWindow",
                    base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Intialized Variable
            Boolean isQuestionSubmittedSuccessfully = false;
            try
            {
                // wait for try again button in presentation window
                base.WaitForElement(By.Id(StudentPresentationPageResource
                    .StudentPresentation_Page_Try_Button_Id_Locator));
                isQuestionSubmittedSuccessfully = base.IsElementDisplayedById
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
                "IsPostTestActivitySubmittedSuccessfully", base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Selects options/answers in Test window to complete submission
        /// </summary>
        private void AnswersFirstQuestionTestWindow()
        {
            //Selects options/answers in Test window to complete submission
            logger.LogMethodEntry("StudentPresentationPage",
                "AnswersSelectionInTestWindow",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_QuestionCount_Presentation_Xpath_Locator));
            //Get Number of count from the Div
            int getDivCount = base.GetElementCountByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_QuestionCount_Presentation_Xpath_Locator);
            // Loop to click options Div By Div

            //Checks whether div of question is present or not
            Boolean isNonAttemptedQuestionPresent = base.IsElementPresent(By.XPath
                    (string.Format(StudentPresentationPageResource
                    .StudentPresentation_Page_QuestionRadioButton_Xpath_Locator,
                    1)));
            if (isNonAttemptedQuestionPresent)
            {
                //Wait for radio button as per the DIV and clicks on it
                base.WaitForElement(By.XPath(string.Format(StudentPresentationPageResource
                    .StudentPresentation_Page_QuestionRadioButton_Xpath_Locator,
                    1)));
                //Clicks on the radio button of answers
                base.ClickButtonByXPath(string.Format(StudentPresentationPageResource.
                    StudentPresentation_Page_QuestionRadioButton_Xpath_Locator,
                    1));
            }
            logger.LogMethodExit("StudentPresentationPage",
                "AnswersSelectionInTestWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        ///  Check for the Display of Teacher View tabs
        /// </summary>
        /// <returns>Returns Teacher View tabs present results</returns>
        public Boolean IsNextButtonPresent()
        {
            logger.LogMethodEntry("StudentPresentationPage", "IsNextButtonPresent",
               base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
            return isNextButtonPresent;
        }

        /// <summary>
        /// Attempt The Post Test Activity By Student.
        /// </summary>
        public void AttemptPostTestActivity()
        {
            //Attempt The Activity
            logger.LogMethodEntry("StudentPresentationPage", "AttemptPostTestActivity",
              base.IsTakeScreenShotDuringEntryExit);
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
                base.ClickButtonById(StudentPresentationPageResource.
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(string.Format(StudentPresentationPageResource
               .StudentPresentation_Page_AnswerChoice_RadioButton_XPath_Locator,
               startQuestionNumber)));
            //Click on Radio Button
            base.SelectRadioButtonByXPath(string.Format(StudentPresentationPageResource
               .StudentPresentation_Page_AnswerChoice_RadioButton_XPath_Locator,
               startQuestionNumber));
            logger.LogMethodExit("StudentPresentationPage", "SelectPostTestAnswerChoice",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Next Question Button
        /// </summary>
        public void ClickNextQuestionButton()
        {
            //Click Next Question Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickNextQuestionButton",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait For Next Question Button
            base.WaitForElement(By.Id(StudentPresentationPageResource
               .StudentPresentation_Page_NextQuestion_Button_Id_Locator));
            //Get Button Property
            IWebElement getNextQuestionButtonProperty = base.GetWebElementPropertiesById
               (StudentPresentationPageResource.StudentPresentation_Page_NextQuestion_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getNextQuestionButtonProperty);
            logger.LogMethodExit("StudentPresentationPage", "ClickNextQuestionButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Submit For Grade Button.
        /// </summary>
        private void ClickOnSubmitForGradingButton()
        {
            //Click on Submit Grade Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSubmitForGradingButton",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click on Submit For Grade Button.
        /// </summary>
        private void ClickOnPastDueSubmitForGradingButton()
        {
            //Click on Submit Grade Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSubmitForGradingButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Button Property
            IWebElement getActivitySubmitButtonProperty = base.GetWebElementPropertiesByPartialLinkText(StudentPresentationPageResource.StudentPresentation_Page_FINISHSubmitforGrading_Button);
            base.ClickByJavaScriptExecutor(getActivitySubmitButtonProperty);
            logger.LogMethodExit("StudentPresentationPage", "ClickOnSubmitForGradingButton",
                base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select start button on the presentation window.
        /// </summary>
        /// <param name="activityType">This is the activity type.</param>
        public void ClickStartButtonOnPresentationWindow(
            string activityType)
        {
            logger.LogMethodEntry("StudentPresentationPage", "ClickStartButtonOnPresentationWindow",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
             base.IsTakeScreenShotDuringEntryExit);
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
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity By Student.
        /// </summary>
        public void SubmitThePostTestActivity()
        {
            //Submit The Activity
            logger.LogMethodEntry("StudentPresentationPage", "SubmitThePostTestActivity",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Finish Activity and Return to Course.
        /// </summary>
        public void FinishAndReturnToCourse()
        {
            //Finish Activity and Return To Course
            logger.LogMethodEntry("StudentPresentationPage", "FinishAndReturnToCourse",
              base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Return To Course Button In MyItLab.
        /// </summary>
        public void ClickOnReturnToCourseInMyitlab()
        {
            //Click On Return to Course
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnReturnToCourseInMyitlab",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_Sleep_Time));
                //Wait For Element
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPresentation_Page_ReturnToCourse_Button_Xpath_Locator));
                //Get Link Property
                IWebElement getReturnToCourseLinkProperties = base.
                    GetWebElementPropertiesByXPath
                    (StudentPresentationPageResource.
                    StudentPresentation_Page_ReturnToCourse_Button_Xpath_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getReturnToCourseLinkProperties);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                   StudentPresentation_Page_LaunchWindow_TimeValue));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickOnReturnToCourseInMyitlab",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Finish And Return To Course.
        /// </summary>
        public void ClickOnFinishAndReturnToCourse()
        {
            //Click On Finish And Return To Course
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnFinishAndReturnToCourse",
              base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Open Study Plan' Window.
        /// </summary>
        private void SelectOpenStudyPlanWindow()
        {
            //Select 'Open Study Plan' Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectOpenStudyPlanWindow",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(StudentPresentationPageResource.
                StudentPresentation_Page_OpenStudyPlan_Window_Name);
            //Select Window
            base.SelectWindow(StudentPresentationPageResource.
                StudentPresentation_Page_OpenStudyPlan_Window_Name);
            logger.LogMethodExit("StudentPresentationPage", "SelectOpenStudyPlanWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Finish Button In Course Materials.
        /// </summary>
        public void ClickOnFinishButtonInCourseMaterials()
        {
            //Click On Finish Button In Course Materials
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnFinishButtonInCourseMaterials",
              base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity.
        /// </summary>
        public void SubmitTheActivityHED()
        {
            //Submit The Activity
            logger.LogMethodEntry("StudentPresentationPage", "SubmitTheActivityHED",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Return To Course Button.
        /// </summary>
        public void ClickOnReturnToCourseButton()
        {
            //Click On Return To Course Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnReturnToCourseButton",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Submit Grade Button.
        /// </summary>
        private void ClickOnSubmitGradeButton()
        {
            //Click On Submit Grade Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSubmitGradeButton",
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Pretest Window.
        /// </summary>
        public void SelectPretestWindow()
        {
            //Select Pretest Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectPretestWindow",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Posttest Window.
        /// </summary>
        public void SelectPosttestWindow()
        {
            //Select Posttest Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectPosttestWindow",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity In Course Materials Tab.
        /// </summary>
        public void SubmitTheActivityInCourseMaterialsTab()
        {
            //Submit The Activity In Course Materials Tab
            logger.LogMethodEntry("StudentPresentationPage",
                "SubmitTheActivityInCourseMaterialsTab",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Web Activity Window.
        /// </summary>
        /// <param name="windowName">This is Window Name.</param>
        public void SelectWebActivityWindow(string windowName)
        {
            //Select Web Activity Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectWebActivityWindow",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                       base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
            return isTryAgainButtonDisplayed;
        }

        /// <summary>
        /// Attempt Question In Presentation Page.
        /// </summary>
        public void AttemptQuestionInPresentationPage()
        {
            logger.LogMethodEntry("StudentPresentationPage",
                "AttemptQuestionInPresentationPage",
                       base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Finish button.
        /// </summary>
        private void ClickOnFinishButton()
        {
            //Click on the Finish button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnFinishButton",
                     base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectTestWindow()
        {
            //Select Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectTestWindow",
                      base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(StudentPresentationPageResource.
                StudentPresentation_Page_TestTypeActivity_WindowName_Title);
            //Select Window
            base.SelectWindow(StudentPresentationPageResource.
                StudentPresentation_Page_TestTypeActivity_WindowName_Title);
            logger.LogMethodExit("StudentPresentationPage", "SelectTestWindow",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit SIM Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SubmitSIMActivity(String activityName)
        {
            logger.LogMethodEntry("StudentPresentationPage", "SubmitSIMActivity",
                       base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void ClickOnActivity(String activityName)
        {
            //Click On Activity
            logger.LogMethodEntry("StudentPresentationPage", "SubmitSIMActivity",
                      base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
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
                       base.IsTakeScreenShotDuringEntryExit);
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
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Insert Tab And Select Insert Object Dropdown Option.
        /// </summary>
        private void SelectInsertTabAndSelectInsertObjectDropdownOption()
        {
            //Select Insert Tab And Select Insert Object Dropdown Option
            logger.LogMethodEntry("StudentPresentationPage",
                "SelectInsertTabAndSelectInsertObjectDropdownOption",
                       base.IsTakeScreenShotDuringEntryExit);
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
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Text Cursor Position.
        /// </summary>
        private void SetTextCursorPosition()
        {
            //Set Text Cursor Position
            logger.LogMethodEntry("StudentPresentationPage", "SetTextCursorPosition",
                       base.IsTakeScreenShotDuringEntryExit);
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
            string getText = base.GetElementTextById(StudentPresentationPageResource.
                StudentPresentation_Page_FirstText_CursorPosition_Id_Locator);
            getText = base.GetElementTextById(StudentPresentationPageResource.
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
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window And Frame.
        /// </summary>
        public void SelectWindowAndFrame()
        {
            //Select Window And Frame
            logger.LogMethodEntry("StudentPresentationPage", "SelectWindowAndFrame",
                       base.IsTakeScreenShotDuringEntryExit);
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
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Status.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Status.</returns>
        public String GetActivityStatus(String activityName)
        {
            logger.LogMethodEntry("StudentPresentationPage",
                 "GetActivityStatus", base.IsTakeScreenShotDuringEntryExit);
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
                  "GetActivityStatus", base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Training Material Button.
        /// </summary>
        private void ClickOnTrainingMaterialButton()
        {
            //Click On Training Material Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnTrainingMaterialButton",
                        base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPresentation_Page_TraingMaterial_Button_Xpath_Locator));
            IWebElement getTrainingMaterial = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.
                StudentPresentation_Page_TraingMaterial_Button_Xpath_Locator);
            //Clicck on the 'Training Material' button
            base.ClickByJavaScriptExecutor(getTrainingMaterial);
            logger.LogMethodExit("StudentPresentationPage", "ClickOnTrainingMaterialButton",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill The Answer In TextBox.
        /// </summary>
        private void FillTheAnswerInTextBox()
        {
            // Fill The Answer In TextBox
            logger.LogMethodEntry("StudentPresentationPage", "FillTheAnswerInTextBox",
                   base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On PreTest Activity Button.
        /// </summary>
        private void ClickOnPreTestActivityButton()
        {
            //Click On PreTest Activity Button
            logger.LogMethodEntry("StudentPresentationPage",
                "ClickOnPreTestActivityButton",
                   base.IsTakeScreenShotDuringEntryExit);
            //Select MyItLab Window
            this.SelectMyItLabWindow();
            //Wait for the elemenet
            base.WaitForElement(By.ClassName(StudentPresentationPageResource.
                StudentPresentation_Page_PreTest_Link_Class_Locator));
            IWebElement getPretestLink = base.GetWebElementPropertiesByClassName
                (StudentPresentationPageResource.
                StudentPresentation_Page_PreTest_Link_Class_Locator);
            //Click on 'Pre-Test' Link
            base.ClickByJavaScriptExecutor(getPretestLink);
            //Click On Activity Alert Window
            this.ClickOnActivityAlertWindow();
            logger.LogMethodExit("StudentPresentationPage",
                "ClickOnPreTestActivityButton",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selec tMyItLab Window.
        /// </summary>
        private void SelectMyItLabWindow()
        {
            // Selec tMyItLab Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectMyItLabWindow",
                  base.IsTakeScreenShotDuringEntryExit);
            //Select the Pretest window
            base.WaitUntilWindowLoads(StudentPresentationPageResource.
                StudentPresentation_Page_StudyPlan_Window_Name);
            base.SelectWindow(StudentPresentationPageResource.
                StudentPresentation_Page_StudyPlan_Window_Name);
            logger.LogMethodExit("StudentPresentationPage", "SelectMyItLabWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity Alert Window.
        /// </summary>
        private void ClickOnActivityAlertWindow()
        {
            //Click On Activity Alert Window
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnActivityAlertWindow",
                       base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Asset Submission Ok Button.
        /// </summary>
        private void ClickTheAssetSubmissionOkButton()
        {
            //Click The Asset Submission Ok Button
            logger.LogMethodEntry("StudentPresentationPage",
                "ClickTheAssetSubmissionOkButton",
                       base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the submit button.
        /// </summary>
        public void ClickOnSubmitButton()
        {
            //Click the submit button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSubmitButton",
                        base.IsTakeScreenShotDuringEntryExit);
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
                //Get the Submit Assignment 'OK' button as WebElement
                IWebElement getSubmitAssignment = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.
                StudentPresentation_Page_SubmitAssignment_OK_Button_Id_Locator);
                //Click on the Submit Assignment 'OK' button
                base.ClickByJavaScriptExecutor(getSubmitAssignment);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickOnSubmitButton",
                        base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize getStatusText variable
            string getActivitySubmittedStatus = string.Empty;
            try
            {
                //Select Window And Frame
                this.SelectWindowAndFrame();
                //Get The Activity Name In CourseMaterial
                int activityColumnCount =
                    GetTheActivityNameInCourseMaterial(assetName);
                //Get the status text
                base.WaitForElement(By.XPath(string.
                Format(StudentPresentationPageResource.
                StudentPresentation_Page_Activity_Status_Xpath_Locator, activityColumnCount)));
                getActivitySubmittedStatus = base.GetElementTextByXPath(string.
                Format(StudentPresentationPageResource.
                StudentPresentation_Page_Activity_Status_Xpath_Locator, activityColumnCount));
                ////Select main Window
                //base.SelectWindow(StudentPresentationPageResource.
                //    StudentPresentation_Page_BaseWindow_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivitySubmittedStatus;
        }

        /// <summary>
        /// Get Status Of Submitted Grader IT Activity In CourseMaterial.
        /// </summary>
        /// <param name="assetName">This is Activity Name.</param>
        /// <returns>Activity Status.</returns>
        public string GetStatusOfSubmittedGraderItActivityInCourseMaterial(string assetName, string activityStatus
            , string activityUnderTabName, User.UserTypeEnum userTypeEnum)
        {
            //Get Status Of Submitted Activity In CourseMaterial
            logger.LogMethodEntry("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.IsTakeScreenShotDuringEntryExit);
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
                //Start Stop Watch 
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                //Clicks Till Course Gets Out of Inactive State
                //If still time is pending to verify assigned to copy state
                while (getActivitySubmittedStatus != activityStatus)
                {

                    if (stopWatch.Elapsed.TotalMinutes < 10 == false) break;

                    {
                        base.RefreshTheCurrentPage();
                        new CommonPage().ManageTheActivityFolderLevelNavigation(
                        assetName, activityUnderTabName, userTypeEnum);
                        //Select Window And Frame
                        this.SelectWindowAndFrame();
                        //Get The Activity Name In CourseMaterial
                        activityColumnCount =
                           this.GetTheActivityNameInCourseMaterial(assetName);
                        //Get the status text
                        getActivitySubmittedStatus = base.GetElementTextByXPath(string.
                        Format(StudentPresentationPageResource.
                        StudentPresentation_Page_Activity_Status_Xpath_Locator, activityColumnCount));
                        if (getActivitySubmittedStatus == activityStatus)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivitySubmittedStatus;
        }

        /// <summary>
        /// Get Status Of Submitted Activity In CourseMaterial.
        /// </summary>
        /// <param name="assetName">This is Activity Name.</param>
        /// <returns>Activity Status.</returns>
        public string GetStatusOfSubmittedActivityInCourseMaterialforHSS(string assetName)
        {
            //Get Status Of Submitted Activity In CourseMaterial
            logger.LogMethodEntry("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.IsTakeScreenShotDuringEntryExit);
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
                ////Select main Window
                base.SelectWindow(StudentPresentationPageResource.
                    StudentPresentation_Page_BaseWindow_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivitySubmittedStatus;
        }

        /// <summary>
        /// Get score of the activity submitted.
        /// </summary>
        /// <returns>Score of the activity.</returns>
        public string GetActivityScoreFromCourseMaterialsPage(string assetName)
        {
            //Get score Of Submitted Activity In CourseMaterial
            logger.LogMethodEntry("StudentPresentationPage",
                "GetActivityScoreFromCourseMaterialsPage",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize getStatusText variable
            string getActivitySubmittedScore = string.Empty;
            try
            {
                //Get the activty column count
                int activityColumnCount = this.GetTheActivityNameInCourseMaterial(assetName);
                //Get the score of the activity
                getActivitySubmittedScore = base.GetElementTextByXPath(
              string.Format(StudentPresentationPageResource.
              CoursePreviewMainUX_Page_ActivityScore_Xpath_Locator, activityColumnCount));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
              "GetActivityScoreFromCourseMaterialsPage",
                  base.IsTakeScreenShotDuringEntryExit);
            return getActivitySubmittedScore;
        }


        /// <summary>
        /// Click on submit button
        /// in SIM5 presentation window.
        /// </summary>
        /// <param name="activityName">Name of the activity.</param>
        public void SubmitSIMActivityWithoutAnswering(string applicationType,
            string activityMode, string activityName, string studentType)
        {
            //Submit SIM5 activity
            logger.LogMethodEntry("StudentPresentationPage",
                "SubmitSIMActivityWithoutAnswering",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectSimActivityZeroScoreStudentWindowName(activityName, studentType);
                //Answer incorrectly
                this.SIM5QuestionIncorrectAnswer(activityMode, applicationType, activityName);
                //Click on SIM5 activity Submit button
                this.ClickOnSim5ActivitySubmitButton();
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                 "SubmitSIMActivityWithoutAnswering",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Answer SIM5 activity incorrectly.
        /// </summary>
        /// <param name="activityMode">Mode of the activity(Training or Exam).</param>
        /// <param name="applicationType">Application type of SIM5 activity.</param>
        private void SIM5QuestionIncorrectAnswer(string activityMode, string applicationType, string activityName)
        {
            //Initialize variables
            string attemptRemaining = string.Empty;
            int attemptCount = 0;
            //Switch based on activity mode
            switch (activityMode)
            {

                case "Training":
                    switch (applicationType)
                    {
                        case "Word":
                        case "Excel":
                        case "PowerPoint":
                            //Get the attempt count
                            //Select Presentation Player Window
                            this.WaitForSim5PageLoad();
                            //this.SelectSimActivityNormalStudentWindowName(activityName);
                            attemptRemaining = base.GetElementTextById(StudentPresentationPageResource.
                              StudentPrsentation_Page_SIM5_AttemptRemaining_Id_Locator);
                            base.WaitForElement(By.Id(StudentPresentationPageResource.
                               StudentPrsentation_Page_SIM5_DesktopElement_Id_Locator));

                            IWebElement getPowerPointOptionProperty =
                           base.GetWebElementPropertiesById(StudentPresentationPageResource.
                                StudentPrsentation_Page_SIM5_DesktopElement_Id_Locator);
                            attemptCount = Int32.Parse(attemptRemaining);
                            //Start counter to based on the attempt count
                            for (int i = 1; i <= attemptCount; i++)
                            {
                                //Click on the Desktop icon in the SIM5 activity
                                base.PerformMouseHoverByJavaScriptExecutor(getPowerPointOptionProperty);
                                base.ClickByJavaScriptExecutor(getPowerPointOptionProperty);
                                Thread.Sleep(3000);
                            }
                            //Click on Ok button in the warning pop up
                            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                                StudentPrsentation_Page_SIM5_TrainingMode_WarningPopup_Ok_Button_Xpath));
                            base.ClickButtonByXPath(StudentPresentationPageResource.
                                StudentPrsentation_Page_SIM5_TrainingMode_WarningPopup_Ok_Button_Xpath);
                            break;
                    }
                    break;

                case "Exam":
                    switch (applicationType)
                    {
                        case "Word":
                        case "Excel":
                        case "PowerPoint":
                            //Get the attempt count

                            this.WaitForSim5PageLoad();
                            //this.SelectSimActivityNormalStudentWindowName(activityName);
                            attemptRemaining = base.GetElementTextById(StudentPresentationPageResource.
                              StudentPrsentation_Page_SIM5_AttemptRemaining_Id_Locator);
                            base.WaitForElement(By.Id(StudentPresentationPageResource.
                               StudentPrsentation_Page_SIM5_DesktopElement_Id_Locator));
                            base.PerformFocusOnElementActionById(StudentPresentationPageResource.
                                StudentPrsentation_Page_SIM5_DesktopElement_Id_Locator);
                            IWebElement getPowerPointOptionProperty =
                           base.GetWebElementPropertiesById(StudentPresentationPageResource.
                                StudentPrsentation_Page_SIM5_DesktopElement_Id_Locator);
                            attemptCount = Int32.Parse(attemptRemaining);
                            //Start counter to based on the attempt count
                            for (int i = 1; i <= attemptCount; i++)
                            {
                                //Click on the Desktop icon in the SIM5 activity
                                base.ClickByJavaScriptExecutor(getPowerPointOptionProperty);
                            }

                            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                           StudentPrsentation_Page_SIM5_Launch_Sleep_Time));
                            break;
                        case "Access":
                            //Get the attempt count
                            base.WaitForElement(By.Id(StudentPresentationPageResource.
                                StudentPrsentation_Page_SIM5_AttemptRemaining_Id_Locator));
                            attemptRemaining = base.GetElementTextById(StudentPresentationPageResource.
                                StudentPrsentation_Page_SIM5_AttemptRemaining_Id_Locator);
                            attemptCount = Int32.Parse(attemptRemaining);
                            //Start counter to based on the attempt count
                            for (int i = 1; i <= attemptCount; i++)
                            {
                                //Click on No spacing element displayed in SIM5 activity
                                base.ClickLinkByXPath(StudentPresentationPageResource.
                                    StudentPrsentation_Page_SIM5_NoSpacingElement_Xpath_Locator);
                            }
                            break;
                    }
                    Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                      StudentPrsentation_Page_SIM5_Launch_Sleep_Time));
                    break;
            }
        }

        public void WaitForSim5PageLoad()
        {
            bool isLoadImagePresent = base.IsElementPresent(By.CssSelector("#myItLabLogo"), 3);
            while (isLoadImagePresent == true)
            {
                isLoadImagePresent = base.IsElementPresent(By.CssSelector("#myItLabLogo"), 3);
            }
        }

        /// <summary>
        /// Select The SIMStudyplan Window.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void SelectTheSIMStudyplanWindow(string activityName)
        {
            User user = User.Get(User.UserTypeEnum.CsSmsStudent);
            //Select The SIMStudyplan Window
            logger.LogMethodEntry("StudentPresentationPage",
                "SelectTheSIMStudyplanWindow",
                     base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            base.WaitUntilWindowLoads(activityName + StudentPresentationPageResource.
               StudentPresentation_Page_SimPresentation_Window_Name);
            base.SelectWindow(activityName + StudentPresentationPageResource.
               StudentPresentation_Page_SimPresentation_Window_Name);
            logger.LogMethodExit("StudentPresentationPage",
                "SelectTheSIMStudyplanWindow",
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click StudyPlan Cancel Button.
        /// </summary>
        private void ClickStudyPlanCancelButton()
        {
            //Click StudyPlan Cancel Button
            logger.LogMethodEntry("StudentPresentationPage",
                "ClickStudyPlanCancelButton",
                         base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
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
                         base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
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
                      base.IsTakeScreenShotDuringEntryExit);
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
                    activityColumnNumber = rowCount;
                    break;
                }
            }
            logger.LogMethodExit("StudentPresentationPage",
                "GetTheActivityNameInCourseMaterial",
                        base.IsTakeScreenShotDuringEntryExit);
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
                      base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save For Later.
        /// </summary>
        public void ClickOnSaveForLater()
        {
            //Click On Save For Later
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSaveForLater",
                        base.IsTakeScreenShotDuringEntryExit);
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
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On FeedBack Icon
        /// </summary>
        public void ClickOnFeedbackIcon()
        {
            //Click On FeedBack Icon
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnFeedbackIcon",
                       base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Get FeedBack Text
        /// </summary>
        /// <returns>FeedBack Text</returns>
        public String getFeedBackText()
        {
            //Get Feedback Text
            logger.LogMethodEntry("StudentPresentationPage", "getFeedBackText",
                      base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
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
                      base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isFeedbackTextPresent = false;
            string getFeedbackText = string.Empty;
            try
            {
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPrsentation_Page_FeedbackText_Id_Locator));
                //Get Feedback Text
                getFeedbackText = base.GetElementTextById(
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
                    base.IsTakeScreenShotDuringEntryExit);
            return isFeedbackTextPresent;
        }

        /// <summary>
        /// Attempt The Gradable Asset.
        /// </summary>
        /// <param name="activityType">This is Activity type.</param>
        public void AttemptTheGradableAsset(string activityType)
        {
            //Attempt The Gradable Asset
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTheGradableAsset",
              base.IsTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("StudentPresentationPage", "AttemptTheGradableAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Essay Question Submission.
        /// </summary>
        public void EssayQuestionSubmission()
        {
            //Essay Question Submission
            logger.LogMethodEntry("StudentPresentationPage", "EssayQuestionSubmission",
              base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt Essay Question Submission.
        /// </summary>
        private void AttemptTheEssayQuestionSubmission()
        {
            //Attempt Essay Question Submission
            logger.LogMethodEntry("StudentPresentationPage",
                "AttemptTheEssayQuestionSubmission",
              base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity In Course Material.
        /// </summary>
        public void SubmitTheActivityInCourseMaterial()
        {
            //Submit The Activity In Course Material
            logger.LogMethodEntry("StudentPresentationPage", "SubmitTheActivityInCourseMaterial",
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit Activity.
        /// </summary>
        public void SubmitActivity()
        {
            //Submit Activity
            logger.LogMethodEntry("StudentPresentationPage", "SubmitActivity",
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Last Opened Window.
        /// </summary>
        public void SelectLastOpenedWindow()
        {
            //Select Last Opened Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectLastOpenedWindow",
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt The Activity In StudentSide.
        /// </summary>
        public void AttemptTheActivityInStudentSide()
        {
            //Attempt The Activity In StudentSide
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTheActivityInStudentSide",
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// verify Window Switching, which is a confirmation that activity is open in normal Browser mode
        /// </summary>
        public void verifyWindowSwitching()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTheActivityInStudentSide",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(15000);//Need to replace with appropriate Wait method in framework                
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait for Activity to Load
        /// </summary>
        public void WaitForActivitytoLoad(string activityName)
        {
            logger.LogMethodEntry("StudentPresentationPage", "WaitForActivitytoLoad",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {

                //Wait for element
                base.WaitForElement(By.PartialLinkText(activityName));
                //Get Element Property
                IWebElement getCmenuIconProperty1 = base.GetWebElementPropertiesByPartialLinkText(activityName);
                //Perform Mouse Hover on Cmenu Icon
                base.ClickByJavaScriptExecutor(getCmenuIconProperty1);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                                     StudentPresentation_Page_LaunchWindow_TimeValue));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "WaitForActivitytoLoad",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Activity pass due message
        /// </summary>
        public string GetActivityPastDueStatusMessage()
        {

            logger.LogMethodEntry("StudentPresentationPage", "GetActivityPastDueStatusMessage",
                base.IsTakeScreenShotDuringEntryExit);

            //Switch to last opened window
            base.SwitchToLastOpenedWindow();
            //Wait for element         
            base.WaitForElement(By.Id(StudentPresentationPageResource.StudentPresentation_Page_PassDue_Message_Id));
            //Get Actual Pass due message
            string actualPastDueActivityMessage = base.GetElementInnerTextById(StudentPresentationPageResource.
                StudentPresentation_Page_PassDue_Message_Id);
            logger.LogMethodExit("StudentPresentationPage", "GetActivityPastDueStatusMessage",
                    base.IsTakeScreenShotDuringEntryExit);
            return actualPastDueActivityMessage;
        }

        /// <summary>
        /// Submit the pass due activity
        /// </summary>
        public void SubmitPastDueActivity()
        {
            //Opens Activity Presentation Window
            logger.LogMethodEntry("StudentPresentationPage", "SubmitPastDueActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.SwitchToLastOpenedWindow();
                //Answers Selection in Presention window
                this.AnswersFirstQuestionTestWindow();
                //Click the Submit button
                this.ClickOnPastDueSubmitForGradingButton();
                //Click on the Finish button
                this.ClickOnFinishButton();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "SubmitPastDueActivity",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Return to parent window
        /// </summary>
        public void ReturnToParentWindow()
        {
            logger.LogMethodEntry("StudentPresentationPage", "ReturnToParentWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click On Return To Course Button  Return to Course
                IWebElement getReturnToCourseLinkProperties = base.GetWebElementPropertiesByPartialLinkText
                    (StudentPresentationPageResource
                    .StudentPresentation_Page_ReturntoCourse_Button_Text);
                //Click on Return to Course Button
                base.ClickByJavaScriptExecutor(getReturnToCourseLinkProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ReturnToParentWindow",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the activity in presentation window.
        /// </summary>
        public void AttemptActivityForSaveforlater()
        {
            //Opens Activity Presentation Window
            logger.LogMethodEntry("StudentPresentationPage", "AttemptActivityForSaveforlater",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.SwitchToLastOpenedWindow();
                //Answers Selection in Presention window
                this.AnswersSelectionInTestWindowForSingleQuestion();
                //Click the Submit button
                this.ClickOnSubmitForSaveforlater();
                //Click on the Finish button
                this.ClickOnFinishButton();
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
            logger.LogMethodExit("StudentPresentationPage", "AttemptActivityForSaveforlater",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Submit For Save for later.
        /// </summary>
        private void ClickOnSubmitForSaveforlater()
        {
            //Click on Submit Grade Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSubmitForSaveforlater",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Submit For Grading Button
            base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPresentation_Page_SubmitForSaveforlater_Button_Id_Locator));
            //Get Button Property
            IWebElement getActivitySubmitButtonProperty = base.GetWebElementPropertiesById
                (StudentPresentationPageResource.
                 StudentPresentation_Page_SubmitForSaveforlater_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getActivitySubmitButtonProperty);
            logger.LogMethodExit("StudentPresentationPage", "ClickOnSubmitForGradingButton",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Get the assetid from the current url.
        /// </summary>
        /// <returns></returns>
        public string GetAssetIdFromUrl()
        {
            logger.LogMethodEntry("StudentPresentationPage", "GetAssetIdFromUrl",
            base.IsTakeScreenShotDuringEntryExit);
            // Switch Window
            base.SwitchToLastOpenedWindow();
            // Wait for window
            base.WaitUntilWindowLoads(StudentPresentationPageResource.StudentPrsentation_Page_Presentation_Window_Name);
            //Get the current url
            string strURL = base.GetCurrentUrl;
            int searchIndex = strURL.IndexOf("intAssetID=") + 11;
            // Get the assetId
            string assetId = strURL.Substring(searchIndex, strURL.IndexOf('&', searchIndex) - searchIndex);
            logger.LogMethodExit("StudentPresentationPage", "GetAssetIdFromUrl",
            base.IsTakeScreenShotDuringEntryExit);
            return assetId;
        }

        /// <summary>
        /// Selects options/answers in Test window to complete submission
        /// </summary>
        private void AnswersSelectionInTestWindowForSingleQuestion()
        {
            //Selects options/answers in Test window to complete submission
            logger.LogMethodEntry("StudentPresentationPage",
                "AnswersSelectionInTestWindow",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_QuestionCount_Presentation_Xpath_Locator));
            //Get Number of count from the Div
            int getDivCount = base.GetElementCountByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_QuestionCount_Presentation_Xpath_Locator);
            // Loop to click options Div By Div

            //Checks whether div of question is present or not
            Boolean isNonAttemptedQuestionPresent = base.IsElementPresent(By.XPath
                    (string.Format(StudentPresentationPageResource
                    .StudentPresentation_Page_QuestionRadioButton_Xpath_Locator,
                    1)));
            if (isNonAttemptedQuestionPresent)
            {
                //Wait for radio button as per the DIV and clicks on it
                base.WaitForElement(By.XPath(string.Format(StudentPresentationPageResource
                    .StudentPresentation_Page_QuestionRadioButton_Xpath_Locator,
                    1)));
                //Clicks on the radio button of answers
                base.ClickButtonByXPath(string.Format(StudentPresentationPageResource.
                    StudentPresentation_Page_QuestionRadioButton_Xpath_Locator,
                    1));
            }

            logger.LogMethodExit("StudentPresentationPage",
                 "AnswersSelectionInTestWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// AudioEssay Question Submission.
        /// </summary>
        public void AudioEssayQuestionSubmission()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AudioEssayQuestionSubmission",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click the Start button
                new InstructionsPage().ClickTestStartButton();
                //Attempt Audio Essay Question Submission
                this.AttemptTheAudioEssayQuestionSubmission();
                //Click on Submit For Grade Button
                this.ClickOnSubmitForGradingButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AudioEssayQuestionSubmission",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Attempt Audio Essay Question Submission.
        /// </summary>
        private void AttemptTheAudioEssayQuestionSubmission()
        {
            //Attempt Essay Question Submission
            logger.LogMethodEntry("StudentPresentationPage",
                "AttemptTheAudioEssayQuestionSubmission",
              base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToLastOpenedWindow();
            //Select the window
            this.SelectWebActivityWindow(StudentPresentationPageResource.
                StudentPrsentation_Page_SAMActivity_WindowName_Locator);
            //Record the student response
            this.RecordAudio();
            //Wait for the element
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Essay_Textbox_Xpath_Locator));
            base.FillTextBoxByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Essay_Textbox_Xpath_Locator,
                StudentPresentationPageResource.
                StudentPrsentation_Page_Essay_Text);
            //Play the question text audio
            this.PlayAudio();
            logger.LogMethodExit("StudentPresentationPage",
                "AttemptTheAudioEssayQuestionSubmission",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Play Question text audio
        /// </summary>
        public void PlayAudio()
        {
            logger.LogMethodEntry("StudentPresentationPage", "PlayAudio",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click the Pegasus play button icon
                this.ClickAudioButton(StudentPresentationPageResource.
                 StudentPresentation_Page_AudioPlay_Button_Xpath_Locator);
                //Click the Learnosity audio voice tool play button
                this.ClickAudioButton(StudentPresentationPageResource.
                    StudentPresentation_Page_Learnosity_AudioPlay_Button_Xpath_Locator);
                //Play Audio for one minite
                this.AudioPlayForOneMin();
                //Click the Learnosity voice tool stop button
                this.ClickAudioButton(StudentPresentationPageResource.
                    StudentPresentation_Page_Learnosity_AudioPlay_Button_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "PlayAudio",
                     base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        ///Record Student audio response
        /// </summary>
        public void RecordAudio()
        {
            logger.LogMethodEntry("StudentPresentationPage", "RecordAudio",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click the Pegasus record button
                this.ClickAudioButton(StudentPresentationPageResource.
                     StudentPresentation_Page_AudioRecord_Button_Xpath_Locator);
                //Click the Learnosity audio voice tool record button
                this.ClickAudioButton(StudentPresentationPageResource.
                    StudentPresentation_Page_Learnosity_Record_button_Xpath_Locator);
                //Record the audio response for one minite
                this.RecordAudioForOneMinute();
                //Click the Learnosity voice tool stop recording button
                this.ClickAudioButton(StudentPresentationPageResource.
                    StudentPresentation_Page_Learnosity_Record_button_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "RecordAudio",
                     base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Play Audio For One minite.
        /// </summary>
        private void AudioPlayForOneMin()
        {

            logger.LogMethodEntry("StudentPresentationPage", "AudioPlayForOneMin",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Gets the audio play running time
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPresentation_Page_Learnosity_Play_CurrentTime_Span_Xpath_Locator));
                string getAudioCurretTime = base.GetElementTextByXPath(StudentPresentationPageResource.
                    StudentPresentation_Page_Learnosity_Play_CurrentTime_Span_Xpath_Locator);
                //Validate the audio played for one min
                if (Convert.ToInt32(getAudioCurretTime.Split(':')[0]) >= Convert.ToInt32(StudentPresentationPageResource.StudentPresentation_Page_Play_Time))
                    return;
                else
                    AudioPlayForOneMin();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AudioPlayForOneMin",
               base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click The Audio Button.
        /// </summary>
        private void ClickAudioButton(string buttonXPath)
        {
            // Click The HTML Page Audio Play Button
            logger.LogMethodEntry("StudentPresentationPage", "ClickAudioButton",
                      base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait For Element
                base.WaitForElement(By.XPath(buttonXPath));
                IWebElement getPlayButton = base.GetWebElementPropertiesByXPath(buttonXPath);
                //Click On Button
                base.ClickByJavaScriptExecutor(getPlayButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickAudioButton",
                     base.IsTakeScreenShotDuringEntryExit);

        }
        /// <summary>
        /// Record Audio for One Minute.
        /// </summary>
        public void RecordAudioForOneMinute()
        {
            //Record Audio for One Minute
            logger.LogMethodEntry("StudentPresentationPage", "RecordAudioForOneMinute",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Fetching The Recording Time Value
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
               StudentPresentation_Page_Learnosity_Record_CurrentTime_span_Xpath_Locator));
                string getRecordingCurretTime = base.GetElementTextByXPath(
                   StudentPresentationPageResource.StudentPresentation_Page_Learnosity_Record_CurrentTime_span_Xpath_Locator);
                //Reccursive Method To Record Audio For One Minute
                if (Convert.ToInt32(getRecordingCurretTime.Split(':')[0]) >=
                    Convert.ToInt32(StudentPresentationPageResource.StudentPresentation_Page_Recording_Time))
                {
                    return;
                }
                else
                {
                    RecordAudioForOneMinute();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "RecordAudioForOneMinute",
               base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Get the SIM5 assetid from the current url.
        /// </summary>
        /// <returns></returns>
        public string GetSim5AssetIdFromUrl(string assetName)
        {
            logger.LogMethodEntry("StudentPresentationPage", "GetSim5AssetIdFromUrl",
            base.IsTakeScreenShotDuringEntryExit);
            // Switch Window
            base.SwitchToLastOpenedWindow();
            // Wait for window
            base.WaitUntilWindowLoads(assetName + StudentPresentationPageResource.
            StudentPresentation_Page_SimPresentation_Window_Name);
            //Get the current url
            string strURL = base.GetCurrentUrl;
            int searchIndex = strURL.IndexOf("resLinkID=", System.StringComparison.Ordinal) + 10;
            // Get the assetId
            string assetId = strURL.Substring(searchIndex, strURL.IndexOf('&', searchIndex) - searchIndex);
            logger.LogMethodExit("StudentPresentationPage", "GetSim5AssetIdFromUrl",
            base.IsTakeScreenShotDuringEntryExit);
            return assetId;
        }

        /// <summary>
        /// Submit SIM5 Excel type activity.
        /// </summary>
        public void SubmitSimExcelTypeActivity(String activityName)
        {
            //Submit SIM5 Excel type activity
            logger.LogMethodEntry("SubmitSimExcelTypeActivity",
                "SubmitSIM5ExcelTypeActivity",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the SIM5 assignment launch window
                base.WaitUntilWindowLoads(activityName + StudentPresentationPageResource.
                StudentPresentation_Page_SimPresentation_Window_Name);
                //Select the SIM5 assignment launch window
                base.SelectWindow(activityName + StudentPresentationPageResource.
                StudentPresentation_Page_SimPresentation_Window_Name);
                //Answer first excel question
                this.StartingExcelNavigatingExcelAndNamingAndSavingAWorkbook();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_Launch_Sleep_Time));
                //Answer second question
                this.EnteringTextUsingAutoCompleteAndUsingTheNameBoxToSelectACell();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_Launch_Sleep_Time));
                //Answer third question
                this.AutoFillAndKeyboardShortcuts();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_Launch_Sleep_Time));
                //Answer Fourth question
                this.SettingCellWidthAndSelectingCellRangeToAlignData();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                   StudentPrsentation_Page_SIM5_Launch_Sleep_Time));
                //Answer Fifth excel quetion
                this.SettingDataInCell();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                   StudentPrsentation_Page_SIM5_Launch_Sleep_Time));
                //Anser sixth question
                this.ConstructingAFormulaAndUsingTheSumFunction();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                   StudentPrsentation_Page_SIM5_Launch_Sleep_Time));
                //Click on SIM5 activity Submit button
                this.ClickOnSim5ActivitySubmitButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                 "SubmitSimExcelTypeActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Setting Data In Cell.
        /// </summary>
        public void SettingDataInCell()
        {
            //Answer second Excel Question
            logger.LogMethodEntry("StudentPresentationPage",
            "SettingDataInCell",
            base.IsTakeScreenShotDuringEntryExit);
            //Fill B4 cell value
            PutExcelValueInCellAndPressFormulaButtonCenter(
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_B4_Cell_Id,
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_B4_Cell_Value);
            //Fill C4 cell value
            PutExcelValueInCellAndPressFormulaButtonCenter(
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_C4_Cell_Id,
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_C4_Cell_Value);
            //Fill D4 cell value
            PutExcelValueInCellAndPressFormulaButtonCenter(
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_D4_Cell_Id,
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_D4_Cell_Value);

            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Sleep_Time));

            //Fill B5 cell value
            PutExcelValueInCellAndPressFormulaButtonCenter(
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_B5_Cell_Id,
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_B5_Cell_Value);
            //Fill C5 cell value
            PutExcelValueInCellAndPressFormulaButtonCenter(
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_C5_Cell_Id,
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_C5_Cell_Value);
            //Fill D5 cell value
            PutExcelValueInCellAndPressFormulaButtonCenter(
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_D5_Cell_Id,
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_D5_Cell_Value);

            logger.LogMethodExit("StudentPresentationPage",
            "SettingDataInCell",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Put Excel Value In Cell And Press Formula Button Center.
        /// </summary>
        /// <param name="referenceCellId">Cell Id.</param>
        /// <param name="dataValue">Cell value.</param>
        private void PutExcelValueInCellAndPressFormulaButtonCenter(string referenceCellId, string dataValue)
        {
            //Fill Excel cell
            logger.LogMethodEntry("StudentPresentationPage",
            "PutExcelValueInCellAndPressFormulaButtonCenter",
            base.IsTakeScreenShotDuringEntryExit);

            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Sleep_Time));

            //Clear Reference Box
            base.ClearTextById(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in Reference Box
            base.FillTextBoxById(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator, referenceCellId);
            //Press Enter in Reference Box
            PressEnterKeyById(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator);

            //Clear Formula Box
            base.ClearTextById(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //Fill vlaue in Formula Box
            base.FillTextBoxById(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Excel_Formula_TextBox_Id_Locator, dataValue);
            //Get WebElement object for Cell A1
            IWebElement cellA1 = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_SIM5_Excel_A1_XPath_Locator);
            //Click on Cell A1 inorder to commit the change made to the Formula Box above
            base.PerformMouseClickAction(cellA1);

            logger.LogMethodExit("StudentPresentationPage",
            "PutExcelValueInCellAndPressFormulaButtonCenter",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Setting Cell Width And Selecting Cell Range To Align Data.
        /// </summary>
        public void SettingCellWidthAndSelectingCellRangeToAlignData()
        {
            //Submit SIM5 Excel type activity
            logger.LogMethodEntry("StudentPresentationPage",
            "SettingCellWidthAndSelectingCellRangeToAlignData",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Set Cell Width
                this.SetCellWidth();
                //Select Cell Range And Align Data
                this.SelectCellRangeAndAlignData();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
            "SettingCellWidthAndSelectingCellRangeToAlignData",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Set excel spread sheet Cell Width.
        /// </summary>
        private void SetCellWidth()
        {
            logger.LogMethodEntry("StudentPresentationPage",
            "SetCellWidth",
            base.IsTakeScreenShotDuringEntryExit);

            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Sleep_Time));
            //Clear Reference Box
            base.ClearTextById(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in Reference Box
            base.FillTextBoxById(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator,
            StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Excel_A1_Cell_Id);
            //Press Enter in Reference Box
            PressEnterKeyById(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //click on Format button by XPath
            IWebElement formatButton = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.StudentPresentation_Page_SIM5_Format_Button_XPath_Locator);
            base.ClickByJavaScriptExecutor(formatButton);
            //click on Column Width button by XPath in Format dropdown
            IWebElement columnWidthButton = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.StudentPresentation_Page_SIM5_ColumnWidth_Link_XPath_Locator);
            base.ClickByJavaScriptExecutor(columnWidthButton);
            //Clear the Column Width value text box
            base.ClearTextById(StudentPresentationPageResource.
                StudentPresentation_Page_SIM5_ColumnWidth_TextBox_ID_Locator);
            //enter the desired value in column width text box
            base.FillTextBoxById(StudentPresentationPageResource.
                StudentPresentation_Page_SIM5_ColumnWidth_TextBox_ID_Locator,
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_ColumnWidth_Value);
            //Get property for Column width OK button
            IWebElement clickOKButton = base.GetWebElementPropertiesById(
                StudentPresentationPageResource.StudentPresentation_Page_SIM5_ColumnWidth_OK_Button_ID_Locator);
            //click on ok button for setting the column width value
            base.ClickByJavaScriptExecutor(clickOKButton);

            logger.LogMethodExit("StudentPresentationPage",
            "SetCellWidth",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select Cell Range And Align Data.
        /// </summary>
        private void SelectCellRangeAndAlignData()
        {
            logger.LogMethodEntry("StudentPresentationPage",
            "SelectCellRangeAndAlignData",
            base.IsTakeScreenShotDuringEntryExit);

            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Sleep_Time));
            //Clear Reference Box
            base.ClearTextById(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in Reference Box
            base.FillTextBoxById(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator,
            StudentPresentationPageResource.StudentPrsentation_Page_SIM5_Excel_ThirdQuestion_B3_Cell_Id);
            //Press Enter in Reference Box
            PressEnterKeyById(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Get property B3 Cell
            IWebElement getCellB3 = base.GetWebElementPropertiesById(StudentPresentationPageResource.
                StudentPresentation_Page_SIM5_Excel_B3_Cell_ID_Locator);
            //Get property D3 Cell
            IWebElement getCellD3 = base.GetWebElementPropertiesById(StudentPresentationPageResource.
                StudentPresentation_Page_SIM5_Excel_D3_Cell_ID_Locator);
            //select and drag the range B3:D3
            base.PerformDragAndDropAction(getCellB3, getCellD3);
            //Get Center Button property
            IWebElement centerButton = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.StudentPresentation_Page_SIM5_AlignCenter_Button_XPath_Locator);
            //Click on Center Button
            base.ClickByJavaScriptExecutor(centerButton);

            logger.LogMethodExit("StudentPresentationPage",
            "SelectCellRangeAndAlignData",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Answers Autofill and Keyboard shortcuts
        /// </summary>     
        private void AutoFillAndKeyboardShortcuts()
        {
            //Answer third Excel Question       
            logger.LogMethodEntry("StudentPresentationPage",
                    "AutoFillAndKeyboardShortcuts",
                   base.IsTakeScreenShotDuringEntryExit);
            //Fill B3 cell value
            PutExcelValueInCell(
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_ThirdQuestion_B3_Cell_Id,
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_First_Activity_ThirdQuestion_B3_Cell_Value);
            //Clear reference box
            base.ClearTextById(StudentPresentationPageResource.
               StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in reference box
            base.FillTextBoxById(StudentPresentationPageResource.
               StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator, StudentPresentationPageResource.
               StudentPrsentation_Page_SIM5_Excel_ThirdQuestion_B3_Cell_Id);
            //Press enter
            this.PressEnterKeyById(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Wait for element Border bullet for cell B3
            base.WaitForElement(By.ClassName(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_Cell_B3_BorderBullet_ClassName_Locator));
            //Get web element property for border bullet element
            IWebElement getBorderBullet = base.GetWebElementPropertiesByClassName(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_Cell_B3_BorderBullet_ClassName_Locator);
            //select and drag the range B3:D3        
            base.PerformDragAndDropToOffset(getBorderBullet,
                Convert.ToInt32(StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_D3_Cell_OffsetX),
                Convert.ToInt32(StudentPresentationPageResource.StudentPresentation_Page_SIM5_Excel_D3_Cell_OffsetY));
            logger.LogMethodExit("StudentPresentationPage",
                "AutoFillAndKeyboardShortcuts",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Answers Constructing A Formula And Using The Sum Function.
        /// </summary>
        private void ConstructingAFormulaAndUsingTheSumFunction()
        {
            //Answer second Excel Question       
            logger.LogMethodEntry("StudentPresentationPage",
                    "ConstructingAFormulaAndUsingTheSumFunction",
                   base.IsTakeScreenShotDuringEntryExit);
            //Fill B8 cell value
            PutExcelValueInCell(
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_B8_Cell_Id,
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_First_Activity_B8_Cell_Value);
            //Fill C8 cell value
            PutExcelValueInCell(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_C8_Cell_Id,
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_First_Activity_C8_Cell_Value);
            //Fill D8 cell value
            PutExcelValueInCell(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_D8_Cell_Id,
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_First_Activity_D8_Cell_Value);
            logger.LogMethodExit("StudentPresentationPage",
                "ConstructingAFormulaAndUsingTheSumFunction",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Answers Starting Excel Navigating Excel And Naming And Saving A Workbook.
        /// </summary>
        private void StartingExcelNavigatingExcelAndNamingAndSavingAWorkbook()
        {

            //Answers first Excel Question            
            logger.LogMethodEntry("StudentPresentationPage",
                    "AnswersFirstExcelQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
            //Get Excel desktop icon button Property
            IWebElement getExcelIconButton = base.GetWebElementPropertiesById
                (StudentPresentationPageResource.
                 StudentPrsentation_Page_Excel_Icon_Id_Locator);
            //Click on Excel desktop icon button
            base.ClickByJavaScriptExecutor(getExcelIconButton);
            //Get Excel blank workbook icon button Property
            IWebElement getBlankWorkbookIconButton = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.
                 StudentPrsentation_Page_New_Excel_Workbook_Xpath_Locator);
            //Click on Excel blank workbook icon button

            base.ClickByJavaScriptExecutor(getBlankWorkbookIconButton);
            SaveFilesInUsb();
            logger.LogMethodExit("StudentPresentationPage",
                "AnswersFirstExcelQuestion",
              base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Save office file in USB in SIM5.
        /// </summary>
        private void SaveFilesInUsb()
        {
            //Save office file in USB in SIM5        
            logger.LogMethodEntry("StudentPresentationPage",
                    "SaveFilesInUsb",
                   base.IsTakeScreenShotDuringEntryExit);
            //Get Excel save icon button Property
            IWebElement getSaveIconButton = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.
                StudentPrsentation_Page_Excel_Save_Xpath_Locator);
            //Click on save icon button
            base.ClickByJavaScriptExecutor(getSaveIconButton);
            //Get  computer browse icon button Property
            IWebElement getComputerBrowseIconButton = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.
                 StudentPrsentation_Page_Save_MyComputer_Browse_Xpath_Locator);
            //Click on computer browse icon button
            base.ClickByJavaScriptExecutor(getComputerBrowseIconButton);
            //Get  USB disk icon button Property
            IWebElement getUsbDiskIconButton = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.
                 StudentPrsentation_Page_Save_USB_Disk_Xpath_Locator);
            //Click on USB disk icon button
            base.ClickByJavaScriptExecutor(getUsbDiskIconButton);

            //Get  New Folder button Property
            IWebElement getNewFolderButton = base.GetWebElementPropertiesById
                (StudentPresentationPageResource.
                 StudentPrsentation_Page_Save_New_Folder_ID_Locator);
            //Click on New Folder button
            base.ClickByJavaScriptExecutor(getNewFolderButton);
            //Get created new folder Property
            IWebElement getNewFolderName = base.GetWebElementPropertiesByClassName
                (StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_New_Folder_Class_Name);
            //focus on created new folder
            base.FocusOnElementByClassName(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_New_Folder_Class_Name);
            //Select all in New folder Text box
            base.ClearTextByClassName((StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_New_Folder_Class_Name));
            //Rename Folder name
            base.FillTextBoxByClassName(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_New_Folder_Class_Name,
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_Folder_Name);

            //Press Enter Key in New Folder text box
            base.PressEnterKeyByClassName(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_New_Folder_Class_Name);
            //Get open button Property
            IWebElement getOpenFileButton = base.GetWebElementPropertiesById
                (StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Open_button_Id_Locator);
            //Click on open button
            base.ClickByJavaScriptExecutor(getOpenFileButton);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));

            //Select all in file name Text box
            base.ClearTextById(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Save_File_TextBox_Id_Locator);
            //SSave file name
            base.FillTextBoxById(StudentPresentationPageResource.
                 StudentPrsentation_Page_SIM5_Save_File_TextBox_Id_Locator,
                 StudentPresentationPageResource.
                 StudentPrsentation_Page_SIM5_Save_Excel_File_Name);

            //Get save button Property
            IWebElement getSaveFileButton = base.GetWebElementPropertiesById(
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Save_button_Id_Locator);
            //Click on  save button
            base.ClickByJavaScriptExecutor(getSaveFileButton);

            logger.LogMethodExit("StudentPresentationPage",
                "SaveFilesInUsb",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Answers Entering Text Using AutoComplete And Using The NameBox To Select A Cell.
        /// </summary>
        private void EnteringTextUsingAutoCompleteAndUsingTheNameBoxToSelectACell()
        {
            //Answer second Excel Question       
            logger.LogMethodEntry("StudentPresentationPage",
                    "AnswerSecondExcelQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
            //Fill A1 cell value
            PutExcelValueInCell(
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_A1_Cell_Id,
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_First_Activity_A1_Cell_Value);
            //Fill A2 cell value
            PutExcelValueInCell(
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_A2_Cell_Id,
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_First_Activity_A2_Cell_Value);
            //Fill A4 cell value
            PutExcelValueInCell(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_A4_Cell_Id,
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_First_Activity_A4_Cell_Value);
            //Fill A5 cell value
            PutExcelValueInCell(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_A5_Cell_Id,
                StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_First_Activity_A5_Cell_Value);
            logger.LogMethodExit("StudentPresentationPage",
                "AnswerSecondExcelQuestion",
              base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Fill Excel cell.
        /// </summary>
        /// <param name="referenceCellId">Cell Id.</param>
        /// <param name="formulaValue">Cell value.</param>
        private void PutExcelValueInCell(string referenceCellId, string formulaValue)
        {
            //Fill Excel cell
            logger.LogMethodEntry("StudentPresentationPage",
                "PutExcelValueInCell",
               base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
            //Clear Reference Box
            base.ClearTextById(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in Reference Box 
            base.FillTextBoxById(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator, referenceCellId);
            //Press Enter in Reference Box
            PressEnterKeyById(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Clear Formula Box
            base.ClearTextById(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //Fill vlaue in Formula Box 
            base.FillTextBoxById(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_Formula_TextBox_Id_Locator, formulaValue);
            //Press Enter in Formula Box
            PressEnterKeyById(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            logger.LogMethodExit("StudentPresentationPage",
                "PutExcelValueInCell",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On SIM5 Activity Submit Button.
        /// </summary>
        public void ClickOnSim5ActivitySubmitButton()
        {
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSim5ActivitySubmitButton",
            base.IsTakeScreenShotDuringEntryExit);
            this.IsPageLoading();
            base.WaitForElement(By.Id(StudentPresentationPageResource.
            StudentPresentation_Page_Submit_Button_Id_Locator));
            //Click on Ok button
            IWebElement getSubmitButton = base.GetWebElementPropertiesById
            (StudentPresentationPageResource.
            StudentPresentation_Page_Submit_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(getSubmitButton);

            //Get the Submit Assignment 'OK' button as WebElement
            IWebElement getSubmitAssignment = base.GetWebElementPropertiesByXPath
            (StudentPresentationPageResource.
            StudentPresentation_Page_SubmitAssignment_OK_Button_Id_Locator);
            //Click on the Submit Assignment 'OK' button
            base.ClickByJavaScriptExecutor(getSubmitAssignment);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                                    StudentPresentation_Page_LaunchWindow_TimeValue));
            logger.LogMethodExit("StudentPresentationPage", "ClickOnSim5ActivitySubmitButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt Sim5 Power Point Questions.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void AttemptSim5PowerPointQuestions(string activityName, string score)
        {
            //Attempt Sim5 Power Point Questions
            logger.LogMethodEntry("StudentPresentationPage", "AttemptSim5PowerPointQuestions",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (score)
                {
                    case "100%": ServetyPercentScoringQuestions(activityName);
                        // ThirtyPercentScoringQuestions();
                        break;


                    case "70%": ServetyPercentScoringQuestions(activityName);
                        break;
                }
                //Click On SIM5 Activity Submit Button
                this.ClickOnSim5ActivitySubmitButton();
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptSim5PowerPointQuestions",
                base.IsTakeScreenShotDuringEntryExit);
        }

        private void ThirtyPercentScoringQuestions()
        {
            //Second Question Submission
            AttemptSecondQuestion();

            //Seventh Question Submission
            AttemptSeventhQuestion();

            //Twelfth Question submission
            AttempttwelfthQuestion();

            //Nineteenth Question submission
            //AttemptNineteenthQuestioin();
            //Twentieth Question submission
            //AttemptTwentiethQuestioin();

            //TwentyThird Question submission
            //AttemptTwentyThirdQuestioin();
            //TwentyFourth Question submission
            //AttemptTwentyFourthQuestioin();

            //Twentyninth Question submission
            //AttemptTwentyninthQuestioin();
            //Thirtyth Question submission
            //AttemptThirtythQuestioin();
        }

        private void ServetyPercentScoringQuestions(string activityName)
        {
            logger.LogMethodEntry("StudentPresentationPage", "ServetyPercentScoringQuestions",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //First Question Submission
                AttemptFirstQuestion(activityName);

                //Third Question Submission
                getQuestionNumber(3);
                AttemptThirdQuestion();
                //getQuestionNumber(4);

                //Fourth Question Submission
                AttemptFourthQuestion();
                //Sixth Question Submission
                getQuestionNumber(6);
                AttemptSixthQuestion();
                //Sixth Question Submission
                //Eight Question Submission
                getQuestionNumber(8);
                AttemptEightQuestion();
                //Ninth Question Submission
                AttemptNinthQuestion();
                //Tenth Question submission
                AttemptTenthQuestion();
                //Eleventh Question submission
                AttemptEleventhQuestion();
                //AttempttwelfthQuestion();
                //Thirteenth Question submission
                getQuestionNumber(13);
                AttemptThirteenthQuestion();
                getQuestionNumber(15);
                //Fifteenth Question submission
                AttemptFifteenthQuestioin();
                getQuestionNumber(14);
                //Fourteenth Question submission
                AttemptFourteenthQuestion();
                getQuestionNumber(16);
                //Sixteenth Question submission
                AttemptSixteenthQuestion();
                //Seventeenth Question submission
                getQuestionNumber(17);
                AttemptSeventeenthQuestioin();
                //Eighteenth Question submission
                AttemptEighteenthQuestioin();

                //TwentyFirst Question submission
                getQuestionNumber(21);
                AttemptTwentyFirstQuestioin();
                //TwentySecond Question submission
                AttemptTwentySecondQuestioin();

                //TwentyFifth Question submission
                getQuestionNumber(25);
                AttemptTwentyFifthQuestioin();
                //Twentysixth Question submission
                AttemptTwentysixthQuestioin();
                //TwentySeventh Question submission
                AttemptTwentySeventhQuestioin();
                //Twentyeightth Question submission
                AttemptTwentyeightthQuestioin();
                //ThirtyFirst Question submission
                getQuestionNumber(31);
                AttemptThirtyFirstQuestioin();
                //ThirtySecond Question submission
                AttemptThirtySecondQuestioin();
                //ThirtyThird Question submission
                AttemptThirtyThirdQuestioin();
                //Fifth Question Submission
                getQuestionNumber(5);
                AttemptFifthQuestion();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ServetyPercentScoringQuestions",
             base.IsTakeScreenShotDuringEntryExit);
        }

        public void getQuestionNumber(int questNo)
        {
            logger.LogMethodEntry("StudentPresentationPage", "QuestionNumber",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SetImplicitWaitTime(15);
                this.IsPageLoading();
                this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_ViewAll_ID_Locator));
                IWebElement getClickButtonProperty = base.GetWebElementPropertiesById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_ViewAll_ID_Locator);
                Thread.Sleep(3000);
                base.ClickByJavaScriptExecutor(getClickButtonProperty);
                //base.ClickButtonById(StudentPresentationPageResource.
                //StudentPrsentation_Page_PPT_ViewAll_ID_Locator);
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_ViewAll_Page_Xpath_Locator));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_ViewAll_Page_Xpath_Locator));
                //Get the question number
                IWebElement questLink = base.GetWebElementPropertiesByXPath(string.Format(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_ViewAll_Question_Xpath_Locator, questNo));
                base.ScrollElementByJavaScriptExecutor(questLink);
                base.PerformFocusOnElementActionByXPath(string.Format(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_ViewAll_Question_Xpath_Locator, questNo));
                this.IsElementDisplayedInUI(By.XPath(string.Format(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_ViewAll_Question_Xpath_Locator, questNo)));
                //Click on the question
                base.PerformDoubleClickAction(questLink);
                this.IsViewAllQuestionsPopUpClosed();
                this.IsPageLoading();
                base.SetImplicitWaitTime(15);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "QuestionNumber",
              base.IsTakeScreenShotDuringEntryExit);
        }

        //This method validates for page loading curtain display in SIM5 presentation page.
        public bool IsPageLoading(int timeOut = -1)
        {

            //If element not present then webdriver throw the exception, 
            //catch this exception so that outer code does not worry 
            //about this exception and existing logic which relies on TRUE/FALSE can work as it is except TimeoutException.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (timeOut == -1)
            {
                timeOut = this.waitTimeOut;
            }
            bool isThinkingIndicatorProcessing = true;
            try
            {
                while (stopWatch.Elapsed.TotalSeconds < timeOut && isThinkingIndicatorProcessing)
                {
                    isThinkingIndicatorProcessing = WebDriver.FindElement(By.Id(StudentPresentationPageResource.
                        StudentPrsentation_Page_SIM5_LoadingCurtain_Id_Locator)).Displayed;
                    if (isThinkingIndicatorProcessing == false)
                    {
                        break;
                    }
                }
            }
            //Exception Handling
            catch (Exception)
            {
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return isThinkingIndicatorProcessing;
        }

        private bool IsQuestionLoaded(string questionNumber, int timeOut = -1)
        {

            //If element not present then webdriver throw the exception, 
            //catch this exception so that outer code does not worry 
            //about this exception and existing logic which relies on TRUE/FALSE can work as it is except TimeoutException.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (timeOut == -1)
            {
                timeOut = this.waitTimeOut;
            }
            bool isThinkingIndicatorProcessing = true;
            try
            {
                while (stopWatch.Elapsed.TotalSeconds < timeOut)
                {
                    string getQuestionID = base.GetElementTextByXPath("//div[@id='quetionattempt']/span");
                    if (getQuestionID.Equals(questionNumber))
                    {
                        break;
                    }
                }
            }
            //Exception Handling
            catch (Exception)
            {
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return isThinkingIndicatorProcessing;
        }

        private bool IsViewAllQuestionsPopUpClosed(int timeOut = -1)
        {

            //If element not present then webdriver throw the exception, 
            //catch this exception so that outer code does not worry 
            //about this exception and existing logic which relies on TRUE/FALSE can work as it is except TimeoutException.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (timeOut == -1)
            {
                timeOut = this.waitTimeOut;
            }
            bool isThinkingIndicatorProcessing = true;
            try
            {
                while (stopWatch.Elapsed.TotalSeconds < timeOut)
                {
                    if (!WebDriver.FindElement(By.Id("ViewAllFrame")).Displayed)
                    {
                        break;
                    }
                }
            }
            //Exception Handling
            catch (Exception)
            {
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return isThinkingIndicatorProcessing;
        }

        private bool IsElementDisplayedInUI(By by, int timeOut = -1)
        {

            //If element not present then webdriver throw the exception, 
            //catch this exception so that outer code does not worry 
            //about this exception and existing logic which relies on TRUE/FALSE can work as it is except TimeoutException.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (timeOut == -1)
            {
                timeOut = this.waitTimeOut;
            }
            bool isThinkingIndicatorProcessing = true;
            try
            {
                while (stopWatch.Elapsed.TotalSeconds < timeOut)
                {
                    if (WebDriver.FindElement(by).Displayed)
                    {
                        break;
                    }
                }
            }
            //Exception Handling
            catch (Exception)
            {
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return isThinkingIndicatorProcessing;
        }

        private bool IsProcessingCurtainLoading(int timeOut = -1)
        {

            //If element not present then webdriver throw the exception, 
            //catch this exception so that outer code does not worry 
            //about this exception and existing logic which relies on TRUE/FALSE can work as it is except TimeoutException.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (timeOut == -1)
            {
                timeOut = this.waitTimeOut;
            }
            bool isThinkingIndicatorProcessing = true;
            try
            {
                while (isThinkingIndicatorProcessing && stopWatch.Elapsed.TotalSeconds < timeOut)
                {
                    isThinkingIndicatorProcessing = WebDriver.FindElement(By.Id
                        (StudentPresentationPageResource.
                        StudentPrsentation_Page_SIM5_LoadingCurtain_Id_Locator)).Displayed;
                }
            }
            //Exception Handling
            catch (Exception)
            {
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return isThinkingIndicatorProcessing;
        }

        public void AttemptTwentyFirstQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTwentyFirstQuestioin",
                    base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("21");
                this.IsPageLoading();
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //click on Home Tab  and click on Replace button
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_HomeTab_CSSLocator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_21_ReplaceButton_Xpath_Locator));
                // type Pike Market in Find what textbox
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_21_SearchText_Xpath_Locator));
                base.FillTextBoxByXPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_21_SearchText_Xpath_Locator,
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_21_SearchText_Value);
                //type Pike Place Market in Relplace with Text box
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_21_ReplaceText_Xpath_Locator));
                base.FillTextBoxByXPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_21_ReplaceText_Xpath_Locator,
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_21_ReplaceText_Value);
                //click on "Replace All"
                base.ClickButtonById(StudentPresentationPageResource.StudentPrsentation_Page_PPT_21_ReplaceAll_ID_Locator);
                // click on OK on message box and click on close
                base.ClickButtonById(StudentPresentationPageResource.StudentPrsentation_Page_PPT_OkButton_ID_Locator);
                base.ClickButtonById(StudentPresentationPageResource.StudentPrsentation_Page_PPT_21_CloseButton_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptTwentyFirstQuestioin",
              base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptEighteenthQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptEighteenthQuestioin",
                    base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("18");
                //click slide 1 and click on on Home tab.        
                //base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath("//*[@id='1']/div/ul/li[6]"));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_HomeTab_CSSLocator));
                //click on new slide arrow in slides gropup and then click on Reuse slides
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_18_NewSlideArrow_Xpath_Locator);
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_18_ReusedSlides_Xpath_Locator);
                //click on browse in reuse pane an then click on browse file
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_18_BrowseFile_Xpath_Locator);
                base.ClickButtonById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_18_BrowseFileOption_ID_Locator);
                //select or click on 1B_slides.pptx in browse dialogue box
                base.ClickImageByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_18_Image_Xpath_Locator);
                // click on open
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_18_OpenButton_Xpath_Locator);
                // under reused pane click on slide 1
                IWebElement slide1 = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_18_ReusedSlide1_Xpath_Locator);
                base.ClickByJavaScriptExecutor(slide1);
                //in slide pane click on slide 7
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPresentation_Page_PPT_Slide7_Value);
                // under reused pane click on slide 4
                IWebElement slide4 = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_18_ReusedSlide4_Xpath_Locator);
                base.ClickByJavaScriptExecutor(slide4);
                // click on close on reused pane
                base.ClickImageByXPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_18_CloseButton_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptEighteenthQuestioin",
              base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptTwentiethQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTwentiethQuestioin",
            base.IsTakeScreenShotDuringEntryExit);

            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
             StudentPrsentation_Page_SIM5_Sleep_Time));
            // click on slide 9 and press delete
            this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPresentation_Page_PPT_Slide9_Value);
            IWebElement slide4 = base.GetWebElementPropertiesByXPath("//*[@id='2_PPTSlideThumbnails_SVM_018']/div[1]/div[2]/div/img");
            base.PerformMouseRightClickAction(slide4);
            base.PressKey(Keys.Delete);
            // move the Slide 4 to the slide 8 position
            this.ClickOnElementByXpath("//div[@id='2_PPTSlideThumbnails_SVM_013']/div[1]/div[2]/div/img");
            IWebElement slideoldPostiotion = base.GetWebElementPropertiesByXPath("//*[@id='2_PPTSlideThumbnails_SVM_013']/div[1]/div[2]/div[1]/img");
            IWebElement slideNewPostiotion = base.GetWebElementPropertiesByXPath("//*[@id='2_PPTSlideThumbnails_SVM_017']/div[1]/div[2]/div[1]/img");
            //  base.PerformDragAndDropAction(slideoldPostiotion, slideNewPostiotion);
            base.DragAndDropWebElement(slideoldPostiotion, slideNewPostiotion);

            //var builder = new Actions(WebDriver);
            //builder.ClickAndHold(slideoldPostiotion);
            //builder.MoveToElement(slideNewPostiotion,29,805);
            //builder.Perform();
            //Thread.Sleep(250);
            //builder.Release(slideoldPostiotion);
            //builder.Perform();
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
             StudentPrsentation_Page_SIM5_Sleep_Time));

            logger.LogMethodExit("StudentPresentationPage", "AttemptTwentiethQuestioin",
              base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptTwentySeventhQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTwentySeventhQuestioin",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("27");
                this.IsPageLoading();
                // click on Layout under home tab with slide 1
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_HomeTab_Xpath_Locator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_27_Layout_Xpath_Locator));
                // Click on section header
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_27_SectionHeader_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptTwentySeventhQuestioin",
             base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptTwentyFifthQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTwentyFifthQuestioin",
          base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("25");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                // StudentPrsentation_Page_SIM5_Sleep_Time));
                // click on th paragraph present in left side of slide 5
                IWebElement Subtitle = base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_25_Paragraph_CSSLocator);
                base.PerformMoveToElementClickAction(Subtitle);
                // on home page tab under paragrapth click on center button
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_HomeTab_Xpath_Locator));
                // Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                //StudentPrsentation_Page_SIM5_Sleep_Time));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_25_CenterAllign_Xpath_Locator));
                // click on slide 4
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPresentation_Page_PPT_Slide4_Value);
                // click on slide title and press cntrl+E
                IWebElement title = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_TwentyFifthQuestion_TitleBox_Xpath_Locator);
                base.PerformMoveToElementClickAction(title);
                Actions builder = new Actions(WebDriver);
                builder.SendKeys("\u0005").Perform();
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                // click on sub title and press cntrl+E
                IWebElement Subtitlea = base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_25_Paragraph_CSSLocator);
                base.PerformMoveToElementClickAction(Subtitlea);
                builder.SendKeys("\u0005").Perform();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptTwentyFifthQuestioin",
              base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptTwentySecondQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTwentySecondQuestioin",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("22");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsPageLoading();
                //click on design tab with slide 1
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_DesignTab_Xpath_Locator));
                IWebElement getDesignTabProperty = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_DesignTab_Xpath_Locator);
                base.PerformFocusOnElementActionByXPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_DesignTab_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getDesignTabProperty);
                // under variants group right click on third theme
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_22_Frame3_Xpath_Locator));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_22_Frame3_Xpath_Locator));
                IWebElement Thirdelement = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_22_Frame3_Xpath_Locator);
                base.PerformMouseRightClickAction(Thirdelement);
                // click on "Apply to selected slides"
                IWebElement ApplyToselectedElement = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_22_ApplyToSelectedlSlidesButton_Xpath_Locator);
                base.PerformMoveToElementClickAction(ApplyToselectedElement);
                // under variants group right click on first theme 
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_22_Frame1_Xpath_Locator));
                IWebElement Firstelement = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_22_Frame1_Xpath_Locator);
                base.PerformMouseRightClickAction(Firstelement);
                // click on "Apply to selected slides"
                bool stss = base.IsElementPresent(By.XPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_22_ApplyToAllSlidesButton_Xpath_Locator));
                IWebElement ApplyToAllElement = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_22_ApplyToAllSlidesButton_Xpath_Locator);
                base.PerformMoveToElementClickAction(ApplyToAllElement);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptTwentySecondQuestioin",
              base.IsTakeScreenShotDuringEntryExit);
        }


        public void AttemptTwentysixthQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTwentysixthQuestioin",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("26");
                // click on paragraph on slide 5  
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPresentation_Page_PPT_Slide5_Value));
                //select the paragrapth
                base.WaitForElement(By.ClassName(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_26_Title_ClassName_Locator));
                IWebElement Subtitlea = base.GetWebElementPropertiesByClassName(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_26_Title_ClassName_Locator);
                base.PerformMoveToElementClickAction(Subtitlea);
                //on home tab click on line spacing under paragraph group
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_HomeTab_Xpath_Locator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_26_LineSpacing_Xpath_Locator));
                //click on 2.0
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_26_LineSpacingOption_Xpath_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptTwentysixthQuestioin",
              base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptTwentyeightthQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTwentyeightthQuestioin",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("28");
                this.IsPageLoading();
                Actions builder = new Actions(WebDriver);
                // click on SLide sorter Icon in status bar
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_27_SlideSorter_Xpath_Locator);
                //Press delete on Slide 1 
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_27_Slide1_Xpath_Locator);
                builder.SendKeys(Keys.Delete).Perform();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptTwentyeightthQuestioin",
              base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptThirtySecondQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptThirtySecondQuestioin",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("32");
                Actions builder = new Actions(WebDriver);
                // on transation tab click on duration up arrow under timing group twice till duration = 1.75
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_TransactionTab_CSSLocator));
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_SlideToWait_Xpath_Locator));
                this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.StudentPrsentation_Page_PPT_32_Upbutton_ID_Locator));
                IWebElement Applybutton = base.GetWebElementPropertiesById(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_32_Upbutton_ID_Locator);
                base.PerformMouseClickAction(Applybutton);
                base.PerformMouseClickAction(Applybutton);
                // click on apply to all under timing group
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_31_ApplyToAllOptions_Xpath_Locator));
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                //click on slide show tool bar and click on Start from begining
                base.WaitForElement(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_SlideShowTab_Xpath_Locator));
                base.SetImplicitWaitTime(15);
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_SlideShowTab_Xpath_Locator));
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                  StudentPrsentation_Page_SIM5_Sleep_Time));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_11_FromBeginingButton_Xpath_Locator));
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                 StudentPrsentation_Page_SIM5_Sleep_Time));
                // press space bar to proceed to slide 2
                for (int i = 0; i < 7; i++)
                {

                    builder.SendKeys(Keys.Enter).Perform();
                    Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                     StudentPrsentation_Page_SIM5_Sleep_Time));
                }
                // Press Esc to return Normal view
                builder.SendKeys(Keys.Escape).Perform();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptThirtySecondQuestioin",
            base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptThirtyFirstQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptThirtyFirstQuestioin",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("31");
                this.IsPageLoading();
                //click on Transaction Tab and click on downward arrow under transaction this slide section
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_TransactionTab_Xpath_Locator));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_31_DownarrowButton_Xpath_Locator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_31_DownarrowButton_Xpath_Locator));
                // click on "fade" under subtitle
                base.WaitForElement(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_31_FadeButton_Xpath_Locator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_31_FadeButton_Xpath_Locator));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_31_EffectOptions_Xpath_Locator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_31_EffectOptions_Xpath_Locator));
                // click on apply to all under timing group
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_31_SmoothlyOptions_Xpath_Locator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_31_SmoothlyOptions_Xpath_Locator));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_31_ApplyToAllOptions_Xpath_Locator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_31_ApplyToAllOptions_Xpath_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptThirtyFirstQuestioin",
            base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptThirtyThirdQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptThirtyThirdQuestioin",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("33");
                this.IsPageLoading();
                Actions builder = new Actions(WebDriver);
                // on status bar click on reading view icon
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_33_ReadingViewIcon_XPath_Locator));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_33_ReadingViewIcon_XPath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_33_ReadingViewIcon_XPath_Locator);
                this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ThirtyThirdQuestion_ReadViewSlide_Id_Locator));
                // press space bar to proceed to slide 2
                builder.SendKeys(Keys.Space).Perform();
                Thread.Sleep(1000);
                // press space bar to proceed to slide 3
                builder.SendKeys(Keys.Space).Perform();
                Thread.Sleep(1000);
                //Click on Normal view icon
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_Question33_NormalViewIcon_Xpath_Locator));
                IWebElement getNormalViewIconProperty = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_Question33_NormalViewIcon_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getNormalViewIconProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptThirtyThirdQuestioin",
                      base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptSeventeenthQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptSeventeenthQuestioin",
          base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("17");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsPageLoading();
                //click on design Tab and click on slide size in Cusomize group
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_DesignTab_Xpath_Locator));
                IWebElement getDesignTabProperty = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_DesignTab_Xpath_Locator);
                base.PerformFocusOnElementActionByXPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_DesignTab_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getDesignTabProperty);
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_SlideToWait_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_17_SlideSizeButton_Xpath_Locator);
                // select widescreen
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_17_SlidetypeButton_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_17_SlidetypeButton_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptSeventeenthQuestioin",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptSixteenthQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptSixteenthQuestion",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("16");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                NavigateToFileTabAndSelectParticularScreen();
                // click on Notes pages
                IWebElement Xelement = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_16_NotesButton_Xpath_Locator);
                base.PerformMouseClickAction(Xelement);
                // click on slides text box and type 3
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                base.FillTextBoxByXPath("//div[@class='editPagesToPrintWrap general-textbox accessible filemenu-manipulator']/input",
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_16_NotesInputButton_value);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                //click on Notes pages button
                this.IsElementDisplayedInUI(By.XPath("//div[@class='print-page-container relative-pos']/span/div/div/div/div/div/span/img"));
                IWebElement element = base.GetWebElementPropertiesByXPath("//div[@class='print-page-container relative-pos']/span/div/div/div/div/div/span/img");
                base.PerformMouseClickAction(element);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                // in lower section select Frame slides
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_16_FrameSLidesButton_Xpath_Locator));
                IWebElement FrameEle = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_16_FrameSLidesButton_Xpath_Locator);
                base.ClickByJavaScriptExecutor(FrameEle);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                bool checkElement = base.IsElementPresent(By.XPath("//div[@id='4']/div[2]/div[3]/div[6]/div[3]/div/div"));
                this.IsElementDisplayedInUI(By.XPath("//div[@id='4']/div[2]/div[3]/div[6]/div[3]/div/div"));
                //click on print
                IWebElement PrintButton = base.GetWebElementPropertiesById(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_15_PrintButton_ID_Locator);
                base.ClickByJavaScriptExecutor(PrintButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptSixteenthQuestion",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        public void NavigateToFileTabAndSelectParticularScreen()
        {

            //click on File Tab
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
            StudentPrsentation_Page_PPT_FileTab_Xpath_Locator));
            this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
            StudentPrsentation_Page_PPT_FileTab_Xpath_Locator));
            this.ClickOnElementByXpath(StudentPresentationPageResource.
            StudentPrsentation_Page_PPT_FileTab_Xpath_Locator);
            base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
            // click on print
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
            StudentPrsentation_Page_PPT_15_PrintOption_Xpath_Locator));
            this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
            StudentPrsentation_Page_PPT_15_PrintOption_Xpath_Locator));
            this.ClickOnElementByXpath(StudentPresentationPageResource.
            StudentPrsentation_Page_PPT_15_PrintOption_Xpath_Locator);
            base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
            // click ok 6 sides horizontal screen or click Full Page slides
            this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_SlideStyle_Xpath_Locator));
            IWebElement element = base.GetWebElementPropertiesByXPath(
            StudentPresentationPageResource.StudentPrsentation_Page_PPT_SlideStyle_Xpath_Locator);
            base.PerformMouseClickAction(element);
        }

        public void AttemptFifteenthQuestioin()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptFifteenthQuestioin",
          base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("15");
                this.IsPageLoading();
                NavigateToFileTabAndSelectParticularScreen();
                //click on 6 slides horizontal button
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_15__Slidehorizontal_Xpath_Locator));
                IWebElement Xelement = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_15__Slidehorizontal_Xpath_Locator);
                base.PerformMouseClickAction(Xelement);
                // click on print button
                IWebElement PrintButton = base.GetWebElementPropertiesById(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_15_PrintButton_ID_Locator);
                base.ClickByJavaScriptExecutor(PrintButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptFifteenthQuestioin",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptFourteenthQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptFourteenthQuestion",
          base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("14");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_InsertTab_Xpath_Locator));
                //click on Insert Tab
                IWebElement getInsertTabProperty = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_InsertTab_Xpath_Locator);
                base.PerformMouseHoverAction(getInsertTabProperty);
                base.PerformClickAction(getInsertTabProperty);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                // click on Header and footer under Text group      
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_13_HeaderButton_Xpath_Locator));
                // In slide tab click on slide Number checkbox          
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_14_SlideTab_Xpath_Locator);
                base.SelectCheckBoxById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_14_SLideNoCheckBox_ID_Locator);
                //click on "dont show on title slide" check box          
                base.SelectCheckBoxById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_14_TitleCheckBox_ID_Locator);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                // click Apply to All
                IWebElement Applybutton = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_13_AppyToAll_Xpath_Locator);
                base.PerformMouseClickAction(Applybutton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptFourteenthQuestion",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptThirteenthQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptThirteenthQuestion",
          base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("13");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //click on Insert Tab
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_InsertTab_Xpath_Locator));
                // click on Header and footer under Text group
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_13_HeaderButton_Xpath_Locator));
                // navigate to Notes and handouts
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_13_NotesTab_Xpath_Locator);
                // check Date and Time Option
                base.SelectCheckBoxById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_13_DateTimeCheckBox_Xpath_Locator);
                // check footer check box
                base.SelectCheckBoxById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_13_FooterCheckBox_Xpath_Locator);
                // Type "1A_KWT_Overview"
                base.FocusOnElementByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_13_FooterTextBox_Xpath_Locator);
                base.FillTextBoxByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_13_FooterTextBox_Xpath_Locator,
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_13_FooterTextBox_Value);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                // click Apply to All
                IWebElement Applybutton = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_13_AppyToAll_Xpath_Locator);
                base.PerformMouseClickAction(Applybutton);
                this.SwitchToLastOpenedWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptThirteenthQuestion",
             base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttempttwelfthQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttempttwelfthQuestion",
          base.IsTakeScreenShotDuringEntryExit);

            try
            {
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                //click on slide show tool bar and under Monitors group check "Use Presenter View"
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_SlideShowTab_Xpath_Locator));
                IWebElement slideShowTab = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_SlideShowTab_Xpath_Locator);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                base.ClickByJavaScriptExecutor(slideShowTab);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
               StudentPrsentation_Page_SIM5_Sleep_Time));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_PresenterCheckBox_XPath_Locator));
                IWebElement presenterCheckBox = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_PresenterCheckBox_XPath_Locator);
                base.ClickByJavaScriptExecutor(presenterCheckBox);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                   StudentPrsentation_Page_SIM5_Sleep_Time));
                // Press Alt+F5
                base.PerformKeyDownThenPressKeyToElement(Keys.Alt, Keys.F5, 1);

                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                 StudentPrsentation_Page_SIM5_Sleep_Time));
                // click Advance to next slide twice 
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
               StudentPrsentation_Page_PPT_12_NextSlideButton_XPath_Locator));
                for (int i = 0; i < 2; i++)
                {
                    base.ClickButtonByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_12_NextSlideButton_XPath_Locator);
                    Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_Sleep_Time));
                }
                // click on the Make the Text larger Icon   
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_Font_XPath_Locator));
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_Font_XPath_Locator);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                //click on "See all slides"     
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_AllSlides_XPath_Locator));
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_AllSlides_XPath_Locator);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                //click Slide 1   
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_Slides1_XPath_Locator));
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_Slides1_XPath_Locator);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                 StudentPrsentation_Page_SIM5_Sleep_Time));
                // click on End slide show  
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_EndSlideShow_XPath_Locator));
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_EndSlideShow_XPath_Locator);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttempttwelfthQuestion",
            base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptEleventhQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptEleventhQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("11");
                Actions builder = new Actions(WebDriver);
                //click on slide show tool bar and click on Start from begining
                base.WaitForElement(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_SlideShowTab_Xpath_Locator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_SlideShowTab_Xpath_Locator));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_11_FromBeginingButton_Xpath_Locator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_11_FromBeginingButton_Xpath_Locator));
                // press space bar to proceed to slide 2-6
                for (int i = 0; i < 5; i++)
                {
                    builder.SendKeys(Keys.Enter).Perform();
                    Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                          StudentPrsentation_Page_SIM5_Sleep_Time));
                }
                // Press Esc to return Normal view
                builder.SendKeys(Keys.Escape).Perform();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptEleventhQuestion",
            base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptTenthQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptTenthQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("10");
                this.IsPageLoading();
                //click on slide 4 
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPresentation_Page_PPT_Slide4_Value);
                // click on the picture 
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_TitleOfSLide_CssLocator));
                //click on format tab
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_FormatTab_CSSLocator));
                // click on Artistic Effect and select glow diffused
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_10_ArtisticEffectsButton_Xpath_Locator));
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_10_ArtisticEffectsButton_Xpath_Locator);
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_10_GlowDiffusedButton_Xpath_Locator));
                base.ClickButtonByXPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_10_GlowDiffusedButton_Xpath_Locator);
                //Remove the artistic effect from the SLide 4 by selecting None on Artistic effect
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_TitleOfSLide_CssLocator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_FormatTab_CSSLocator));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_10_ArtisticEffectsButton_Xpath_Locator));
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_10_ArtisticEffectsButton_Xpath_Locator);
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_10_NoneButton_Xpath_Locator));
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_10_NoneButton_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptTenthQuestion",
             base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptNinthQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptNinthQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("9");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //click on slide 4
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPresentation_Page_PPT_Slide4_Value);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //click on pitcure
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_TitleOfSLide_CssLocator));
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //click on format tab
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_FormatTab_CSSLocator));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_9_DownArrow_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_9_DownArrow_Xpath_Locator);
                // select simple black pitcure style
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_9_PitctureStyle_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_9_PitctureStyle_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptNinthQuestion",
            base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptEightQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptEightQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("8");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPresentation_Page_PPT_Slide2_Value));
                //click on slide 2
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPresentation_Page_PPT_Slide2_Value);
                // this.ClickOnElementByXpath("//div[@id='5']/div[3]/div[1]/div");
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_TitleOfSLide_CssLocator));
                base.SwitchToLastOpenedWindow();
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_8_ImageIcon1_ID_Locator));
                //  click on image "1A_Glacier.jpg"
                base.ClickImageById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_8_ImageIcon1_ID_Locator);
                //click on Insert button
                // this.ClickOnElementByXpath("//div[@id='6-ButtonInsert']/div[1]");
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_8_InsertButton_CSSLocator));
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPresentation_Page_PPT_Slide4_Value));
                base.ClickButtonByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_EightQuestion_Slide4_Xpath_Locator);
                // this.ClickOnElementByXpath("//div[@id='3']/div[5]/div[2]/ul/li[1]");
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_8_ContentTitleButton_CSSLocator));
                //  click on image 
                this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_8_ImageIcon2_ID_Locator));
                base.ClickImageById(StudentPresentationPageResource.StudentPrsentation_Page_PPT_8_ImageIcon2_ID_Locator);
                //click on Insert button
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_8_InsertButton_CSSLocator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptEightQuestion",
          base.IsTakeScreenShotDuringEntryExit);
        }

        public void AttemptSeventhQuestion()
        {
            //Attempt Seventh Question
            logger.LogMethodEntry("StudentPresentationPage", "AttemptSeventhQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            //click on slide 2 bottom of the page
            bool t = base.IsElementPresent(By.XPath("//div[@id='ContentDiv_TP_3']/ul/li/span"));
            IWebElement getCursorLocation = base.GetWebElementPropertiesByXPath("//div[@id='ContentDiv_TP_3']/ul/li");
            base.ClickByJavaScriptExecutor(getCursorLocation);
            base.PerformFocusOnElementActionByXPath("//div[@id='ContentDiv_TP_3']/ul/li");
            //Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
            // StudentPrsentation_Page_SIM5_Sleep_Time));
            // base.PlaceCursorPosition(getCursorLocation,988,40);
            // base.PerformMouseClickAction(getCursorLocation);
            // base.PressKey("{END}");
            // base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_EnterKey_Value);
            //Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
            //StudentPrsentation_Page_SIM5_Sleep_Time));
            //base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_Down_Key_Value);
            // base.FillTextBoxByXPath("//div[@id='ContentDiv_TP_3']/ul/li/span", "tset");

            //WebDriver.FindElement(By.XPath("//div[@id='ContentDiv_TP_3']/ul/li")).SendKeys(Keys.Space);
            ((IJavaScriptExecutor)WebDriver).ExecuteScript(String.Format("arguments[0].innerHTML = '{0}'", "<p>a</p>"), getCursorLocation);
            base.FillTextToInnerHtmlByXpathFillTexttoInnerHtmlThroughJavaScriptExecutor(
               "//div[@id='ContentDiv_TP_3']/ul/li/span",
               "a");
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
            base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_EnterKey_Value);
            //Click and place cursor Location
            //this.ClickOnElementByXpath("//div[@id='ContentDiv_TP_3']/ul/li");
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
            base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_Down_Key_Value);
            //click on slide 3
            this.ClickOnElementByXpath("//div[@id='2_PPTSlideThumbnails_SVM_012']/div[1]/div[2]/div/img");
            //Create New Slide
            bool dct = base.IsElementPresent(By.XPath("//ul[@id='ribbon-tab-Home']/li[2]/span/span[1]/span/span[1]/div[1]/div[1]/span/div[1]"));
            this.ClickOnElementByXpath("//ul[@id='ribbon-tab-Home']/li[2]/span/span[1]/span/span[1]/div[1]/div[1]/span/div[1]");
            bool dt = base.IsElementPresent(By.XPath("//ul[@id='ribbon-tab-Home']/li[2]/span/span[1]/span/span[1]/div[1]/div[2]/div/div[1]/div[4]/div"));
            this.ClickOnElementByXpath("//ul[@id='ribbon-tab-Home']/li[2]/span/span[1]/span/span[1]/div[1]/div[2]/div/div[1]/div[4]/div");
            logger.LogMethodExit("StudentPresentationPage", "AttemptSeventhQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Attempt Sixth Question.
        /// </summary>
        public void AttemptSixthQuestion()
        {
            //Attempt Sixth Question
            logger.LogMethodEntry("StudentPresentationPage", "AttemptSixthQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("6");
                base.SetImplicitWaitTime(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //Click on Notes
                IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
                js.ExecuteScript(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_Notes_JS_Locator);
                IWebElement notesClick = base.GetWebElementPropertiesById(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_6_NotesIcon_ID_Locator);
                base.PerformMouseClickAction(notesClick);
                base.FillTextToInnerHtmlByXpathFillTexttoInnerHtmlThroughJavaScriptExecutor(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_6_NotesIcon_Xpath_Locator,
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_6_Notes_Value);
                //Click and place cursor Location
                Actions builder = new Actions(WebDriver);
                builder.SendKeys(Keys.End).Perform();
                builder.SendKeys(Keys.Delete).Perform();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptSixthQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt Fifth Question.
        /// </summary>
        public void AttemptFifthQuestion()
        {
            //Attempt Fifth Question
            logger.LogMethodEntry("StudentPresentationPage", "AttemptFifthQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("5");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsPageLoading();
                //Enter Text In First Bulleted Point
                this.EnterTextInFirstBulletedPoint();
                //Enter Text In Second Bulleted Point
                this.EnterTextInSecondBulletedPoint();
                //Enter Text In Third Bulleted Point
                this.EnterTextInThirdBulletedPoint();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptFifthQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Text In Third Bulleted Point.
        /// </summary>
        public void EnterTextInThirdBulletedPoint()
        {
            //Enter Text In Third Bulleted Point
            logger.LogMethodEntry("StudentPresentationPage", "EnterTextInThirdBulletedPoint",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Actions builder = new Actions(WebDriver);
                //Click and Place Cursor Location
                IWebElement getCursorLocation = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Second_Bulleted_Point_Text_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getCursorLocation);
                base.PlaceCursorPosition(getCursorLocation, Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_Cursor_Xaxis_Value), Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_Cursor_Yaxis_Value));
                builder.SendKeys(Keys.Down).Perform();
                builder.SendKeys(Keys.Enter).Perform();
                // builder.SendKeys(Keys.Enter).Perform();
                //base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_Down_Key_Value);
                //base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_EnterKey_Value);
                //Click on 'Increase List Level' Option
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_IncreaseList_Level_Xpath_Locator);
                //Enter Text in bulleted Point
                base.FillTextToInnerHtmlByXpathFillTexttoInnerHtmlThroughJavaScriptExecutor("//div[@id='ContentDiv_TP_4']/ul/li[4]/span",
                    StudentPresentationPageResource.StudentPrsentation_Page_Third_Bulleted_Point_Text_Value);
                builder.SendKeys(Keys.End).Perform();
                //base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_EndKey_Value);
                this.SwitchToLastOpenedWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "EnterTextInThirdBulletedPoint",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Text In Second Bulleted Point.
        /// </summary>
        public void EnterTextInSecondBulletedPoint()
        {
            //Enter Text In Second Bulleted Point
            logger.LogMethodEntry("StudentPresentationPage", "EnterTextInSecondBulletedPoint",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SetImplicitWaitTime(5);
                Actions builder = new Actions(WebDriver);
                //Click and Place Cursor Location
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_First_Bulleted_Point_Text_Xpath_Locator));
                IWebElement getCursorLocation = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_First_Bulleted_Point_Text_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getCursorLocation);
                base.SetImplicitWaitTime(5);
                base.PlaceCursorPosition(getCursorLocation, Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_Cursor_Xaxis_Value), Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_Cursor_Yaxis_Value));
                builder.SendKeys(Keys.End + Keys.Enter).Perform();
                //base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_EndKey_Value);
                //base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_Down_Key_Value);
                //base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_EnterKey_Value);
                //Click on 'Decrease List Level' Option
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_DecreaseList_Level_Xpath_Locator);
                //Enter Text in bulleted Point
                // base.FillTextBoxByCssSelector("li.GreenDisc1A05A1Level1",
                //  StudentPresentationPageResource.StudentPrsentation_Page_Second_Bulleted_Point_Text_Value);
                base.FillTextToInnerHtmlByXpathFillTexttoInnerHtmlThroughJavaScriptExecutor("//div[@id='ContentDiv_TP_4']/ul/li[3]/span",
                   StudentPresentationPageResource.StudentPrsentation_Page_Second_Bulleted_Point_Text_Value);
                builder.SendKeys(Keys.End).Perform();
                // base.PressKey("{END}");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "EnterTextInSecondBulletedPoint",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Text In First Bulleted Point.
        /// </summary>
        public void EnterTextInFirstBulletedPoint()
        {
            //Enter Text In First Bulleted Point
            logger.LogMethodEntry("StudentPresentationPage", "EnterTextInFirstBulletedPoint",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {

                //Click and Place Cursor Location
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_First_Bulleted_Point_Xpath_Locator));
                IWebElement getCursorLocation = base.GetWebElementPropertiesByXPath(
                    StudentPresentationPageResource.StudentPrsentation_Page_First_Bulleted_Point_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getCursorLocation);
                base.PlaceCursorPosition(getCursorLocation, 50, 50);
                base.SetImplicitWaitTime(5);
                //base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_EnterKey_Value);
                Actions builder = new Actions(WebDriver);
                builder.SendKeys(Keys.Enter + Keys.Tab).Perform();
                //base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_Tab_Key_Value);
                // builder.SendKeys(Keys.Tab).Perform();
                //Enter Text in bulleted Point
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_First_Bulleted_Point_Text_Xpath_Locator));
                base.FillTextToInnerHtmlByXpathFillTexttoInnerHtmlThroughJavaScriptExecutor(
                    StudentPresentationPageResource.StudentPrsentation_Page_First_Bulleted_Point_Text_Xpath_Locator,
                    StudentPresentationPageResource.StudentPrsentation_Page_First_Bulleted_Point_Text_Value);
                base.SetImplicitWaitTime(5);
                builder.SendKeys(Keys.End).Perform();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "EnterTextInFirstBulletedPoint",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt Fourth Question.
        /// </summary>
        public void AttemptFourthQuestion()
        {
            //Attempt Fourth Question
            logger.LogMethodEntry("StudentPresentationPage", "AttemptFourthQuestion",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {
                Actions builder = new Actions(WebDriver);
                this.IsQuestionLoaded("4");
                base.SetImplicitWaitTime(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsPageLoading();
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_SlideToWait_Xpath_Locator));
                //Select Panoromic Slide and Enter Title
                this.SelectPanoromicSlideandEnterTitle();
                base.SetImplicitWaitTime(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //Create New Slide
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_NewSlide_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_NewSlide_Xpath_Locator);
                //Create Title and Content Slide
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Content_Slide));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Content_Slide);
                Thread.Sleep(1000);
                ////Click on Title Content
                IWebElement getTitleBoxProperty = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getTitleBoxProperty);
                IWebElement getTitleProperty = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Xpath_Locator);
                base.PlaceCursorPosition(getTitleProperty, Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_Cursor_Xaxis_Value), Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_Cursor_Yaxis_Value));
                base.FillTextToInnerHtmlByXpathFillTexttoInnerHtmlThroughJavaScriptExecutor(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Xpath_Locator,
                    StudentPresentationPageResource.StudentPrsentation_Page_Title_Content_Slide_Title_Value);
                IWebElement Perfclick = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                 StudentPrsentation_Page_Title_Xpath_Locator);
                base.PerformMouseClickAction(Perfclick);
                //base.PressKey(StudentPresentationPageResource.StudentPrsentation_Page_Down_Key_Value);
                builder.SendKeys(Keys.End + Keys.Tab).Perform();
                base.SetImplicitWaitTime(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                // builder.SendKeys(Keys.Tab).Perform();
                //Click on Content
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                   StudentPrsentation_Page_Content_Text));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Content_Text);
                base.SetImplicitWaitTime(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                base.FillTextToInnerHtmlByXpathFillTexttoInnerHtmlThroughJavaScriptExecutor(StudentPresentationPageResource.
                    StudentPrsentation_Page_Content_Text, StudentPresentationPageResource.
                    StudentPrsentation_Page_Content_FirstBullet_Text);
                //Click on tab key
                builder.SendKeys(Keys.Tab).Perform();
                //this.IsProcessingCurtainLoading();
                base.SetImplicitWaitTime(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptFourthQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Panoromic Slide and Enter Title.
        /// </summary>
        public void SelectPanoromicSlideandEnterTitle()
        {
            //Select Panoromic Slide and Enter Title
            logger.LogMethodEntry("StudentPresentationPage", "SelectPanoromicSlideandEnterTitle",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Home Tab
                //this.ClickOnElementByXpath(StudentPresentationPageResource.
                //  StudentPrsentation_Page_Home_Tab_Xpath_Locator);
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Home_Tab_Xpath_Locator));
                IWebElement getHomeTabProperties = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Home_Tab_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getHomeTabProperties);
                //IWebElement getNewSlideButtonProperty = base.GetWebElementPropertiesByCssSelector
                //    ("img[src='app/Comps/Common/Ribbon/img/Ppt/Home/Slides/Slides_New Slide.png']");
                //base.PerformMouseClickAction(getNewSlideButtonProperty);
                //Create New Slide
                //base.WaitForElement(By.ClassName("SIMSGenericContextUsed"));
                //IWebElement getNewSlideProperties = base.GetWebElementPropertiesByCssSelector
                //  ("img[src='app/Comps/Common/Ribbon/img/Ppt/Home/Slides/Slides_New Slide.png']");
                //base.ClickByJavaScriptExecutor(getNewSlideProperties);
                IWebElement getNewSlideProperties = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                 StudentPrsentation_Page_NewSlide_Xpath_Locator);
                base.PerformMouseHoverAction(getNewSlideProperties);
                base.PerformMouseClickAction(getNewSlideProperties);
                //this.ClickOnElementByXpath(StudentPresentationPageResource.
                //     StudentPrsentation_Page_NewSlide_Xpath_Locator);
                //base.MouseOverByJavaScriptExecutor(getNewSlideProperties);
                //base.PerformClickAction(getNewSlideProperties);
                //this.ClickOnElementByXpath(StudentPresentationPageResource.
                // StudentPrsentation_Page_NewSlide_Xpath_Locator);
                //Select Panoromic Slide
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Panoramic_Slide_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Panoramic_Slide_Xpath_Locator);
                //Enter Title
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Xpath_Locator);
                base.FillTextToInnerHtmlByXpathFillTexttoInnerHtmlThroughJavaScriptExecutor(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Xpath_Locator, StudentPresentationPageResource.
                    StudentPrsentation_Page_Fourth_Question_Title_Value);
                Actions builder = new Actions(WebDriver);
                Thread.Sleep(3000);
                builder.SendKeys(Keys.End + Keys.Tab).Perform();
                //IWebElement Perfclick = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                //    StudentPrsentation_Page_Title_Xpath_Locator);
                //base.PerformMouseClickAction(Perfclick);
                //base.PressKey(StudentPresentationPageResource.StudentPrsentation_Page_Down_Key_Value);
                // this.IsProcessingCurtainLoading();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "SelectPanoromicSlideandEnterTitle",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt Third Question.
        /// </summary>
        public void AttemptThirdQuestion()
        {
            //Attempt Third Question
            logger.LogMethodEntry("StudentPresentationPage", "AttemptThirdQuestion",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {
                //this.IsProcessingCurtainLoading();
                //Navigate to Design Tab
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Design_Tab_Xpath_Locator));
                IWebElement getPageDesignTabProperty = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                 StudentPrsentation_Page_Design_Tab_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getPageDesignTabProperty);
                //this.ClickOnElementByXpath(StudentPresentationPageResource.
                //  StudentPrsentation_Page_Design_Tab_Xpath_Locator);
                //Click on Design Theme More Button
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Design_Theme_Xpath_Locator);
                //Select Organic Theme
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Organic_Theme_Xpath_Locator);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptThirdQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt Second Question.
        /// </summary>
        public void AttemptSecondQuestion()
        {
            //Attempt Second Question
            logger.LogMethodEntry("StudentPresentationPage", "AttemptSecondQuestion",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
           StudentPrsentation_Page_SIM5_Sleep_Time));
                //Click And Enter Title
                this.ClickAndEnterTitle();
                //Click And Enter Sub Title
                this.ClickAndEnterSubTitle();
                //Select Save and Browse Option
                this.SelectSaveandBrowseOption();
                //Create New Folder and Open
                this.CreateNewFolderandOpen();
                //Enter File Name and Save
                this.EnterFileNameandSave();
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                   StudentPrsentation_Page_SIM5_Sleep_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptSecondQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter File Name and Save.
        /// </summary>
        public void EnterFileNameandSave()
        {
            //Enter File Name and Save
            logger.LogMethodEntry("StudentPresentationPage", "EnterFileNameandSave",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {

                //Enter File Name
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPrsentation_Page_File_Name_Textbox_Id_Locator));
                base.ClearTextById(StudentPresentationPageResource.
                    StudentPrsentation_Page_File_Name_Textbox_Id_Locator);
                base.FillTextBoxById(StudentPresentationPageResource.
                    StudentPrsentation_Page_File_Name_Textbox_Id_Locator,
                    StudentPresentationPageResource.StudentPrsentation_Page_File_Name_Value);
                //Click on Save Button
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                   StudentPrsentation_Page_Save_Button_ID_Locator));
                base.ClickButtonById(StudentPresentationPageResource.
                   StudentPrsentation_Page_Save_Button_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "EnterFileNameandSave",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create New Folder and Open.
        /// </summary>
        public void CreateNewFolderandOpen()
        {
            //Create New Folder and Open
            logger.LogMethodEntry("StudentPresentationPage", "CreateNewFolderandOpen",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {
                //Click on New Folder
                base.WaitForElement(By.Id(StudentPresentationPageResource.StudentPrsentation_Page_NewFolder_Option_Id_Locator));
                IWebElement getNewFolderOptionProperty = base.GetWebElementPropertiesById(
                    StudentPresentationPageResource.StudentPrsentation_Page_NewFolder_Option_Id_Locator);
                base.ClickByJavaScriptExecutor(getNewFolderOptionProperty);
                //Enter Folder Name
                base.WaitForElement(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_FolderName_Textbox_Xpath_Locator));
                IWebElement getNewFolderNameProperty = base.GetWebElementPropertiesByClassName(
              StudentPresentationPageResource.StudentPrsentation_Page_FolderName_Textbox_Xpath_Locator);
                IWebElement getElementProperty = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.StudentPrsentation_Page_FolderName_Textbox_Xpath_Locator);
                base.ClearTextByXPath(StudentPresentationPageResource.StudentPrsentation_Page_FolderName_Textbox_Xpath_Locator);
                base.FillTextBoxByXPath(StudentPresentationPageResource.StudentPrsentation_Page_FolderName_Textbox_Xpath_Locator,
                    StudentPresentationPageResource.StudentPrsentation_Page_Folder_Name_Value);
                base.PressEnterKeyByXPath(StudentPresentationPageResource.StudentPrsentation_Page_FolderName_Textbox_Xpath_Locator);
                //Click on Open
                base.WaitForElement(By.Id(StudentPresentationPageResource.StudentPrsentation_Page_Open_Option_Id_Locator));
                IWebElement getFolderProperty = base.GetWebElementPropertiesById(
                    StudentPresentationPageResource.StudentPrsentation_Page_Open_Option_Id_Locator);
                base.ClickByJavaScriptExecutor(getFolderProperty);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_Time_to_Wait));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "CreateNewFolderandOpen",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Save and Browse Option.
        /// </summary>
        private void SelectSaveandBrowseOption()
        {
            logger.LogMethodEntry("StudentPresentationPage", "SelectSaveandBrowseOption",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Save and Browse Option
                //Click on Save Icon
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_Time_to_Wait));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_2_SaveIcon_Xpath_Locator));
                IWebElement save = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_2_SaveIcon_Xpath_Locator);
                base.PerformMouseClickAction(save);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_Time_to_Wait));
                //Click on Computer Option
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Computer_Option_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Computer_Option_Xpath_Locator);
                //Click on Browse
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_Time_to_Wait));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Browse_Option_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Browse_Option_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "SelectSaveandBrowseOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Sub Title And Enter Sub Title.
        /// </summary>
        private void ClickAndEnterSubTitle()
        {
            //Click on Add Sub Title And Enter Sub Title
            logger.LogMethodEntry("StudentPresentationPage", "ClickAndEnterSubTitle",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {
                //Click on Add Sub Title
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_SubTitle_FirstText_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_SubTitle_FirstText_Xpath_Locator);
                //Enter Sub Title 'Your Travel'
                base.FillTextToInnerHtmlByXpathFillTexttoInnerHtmlThroughJavaScriptExecutor(StudentPresentationPageResource.
                    StudentPrsentation_Page_SubTitle_FirstText_Xpath_Locator,
                    StudentPresentationPageResource.StudentPrsentation_Page_SubTitle_FirstText_Value);
                IWebElement getAddTitleProperty =
                         base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                         StudentPrsentation_Page_SubTitle_FirstText_Xpath_Locator);
                base.PerformMouseClickAction(getAddTitleProperty);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_Time_to_Wait));
                //base.PlaceCursorPosition(getAddTitleProperty, Convert.ToInt32(StudentPresentationPageResource.
                //    StudentPrsentation_Page_Cursor_Xaxis_Value), Convert.ToInt32(StudentPresentationPageResource.
                //    StudentPrsentation_Page_Cursor_Yaxis_Value));
                //base.PressKey(StudentPresentationPageResource.StudentPrsentation_Page_Down_Key_Value);
                //base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_EndKey_Value);
                base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_EnterKey_Value);
                //Enter Sub Title 'Your Way'
                base.FillTextToInnerHtmlByXpathFillTexttoInnerHtmlThroughJavaScriptExecutor(StudentPresentationPageResource.
                StudentPrsentation_Page_SubTitle_SecondText_Xpath_Locator,
                StudentPresentationPageResource.StudentPrsentation_Page_SubTitle_SecondText_Value);
                base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_EnterKey_Value);
                base.PressKey("{HOME}");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "ClickAndEnterSubTitle",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Title And Enter Title.
        /// </summary>
        private void ClickAndEnterTitle()
        {
            //Click on Add Title And Enter Title
            logger.LogMethodEntry("StudentPresentationPage", "ClickAndEnterTitle",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {
                //Click on Add Title
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_TextArea_Xpath_Locator);
                base.WaitForElement(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_Title_TextArea_Xpath_Locator));
                //Enter Title
                base.FillTextToInnerHtmlByXpathFillTexttoInnerHtmlThroughJavaScriptExecutor(
                    StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_TextArea_Xpath_Locator,
                    StudentPresentationPageResource.StudentPrsentation_Page_Title_Text_Value);
                IWebElement getAddTitleProperty =
                    base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_TextArea_Xpath_Locator);
                base.PerformMouseClickAction(getAddTitleProperty);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_Time_to_Wait));
                base.PlaceCursorPosition(getAddTitleProperty, Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_Cursor_Xaxis_Value), Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_Cursor_Yaxis_Value));
                base.PressKey(StudentPresentationPageResource.StudentPrsentation_Page_Down_Key_Value);
                base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_EndKey_Value);
                base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_DeleteKey_Value);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_Sleep_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "ClickAndEnterTitle",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Element By Xpath.
        /// </summary>
        /// <param name="elementAttribute">This is an Attribute.</param>
        public void ClickOnElementByXpath(string elementAttribute)
        {
            //Click On Element By Xpath
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnElementByXpath",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Element
            IWebElement getElementProperty = base.GetWebElementPropertiesByXPath(elementAttribute);
            base.ClickByJavaScriptExecutor(getElementProperty);
            logger.LogMethodExit("StudentPresentationPage", "ClickOnElementByXpath",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt First Question.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void AttemptFirstQuestion(string activityName)
        {
            //Attempt First Question
            logger.LogMethodEntry("StudentPresentationPage", "AttemptFirstQuestion",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {
                //Select Presentation Player Window
                this.SelectPresentationPlayerWindow(activityName);
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPrsentation_Page_PowerPoint_Option_Id_Locator));
                base.PerformFocusOnElementActionById(StudentPresentationPageResource.
                StudentPrsentation_Page_PowerPoint_Option_Id_Locator);
                //base.FocusOnElementById(StudentPresentationPageResource.
                //StudentPrsentation_Page_PowerPoint_Option_Id_Locator);
                //Select Power Point Option            
                IWebElement getPowerPointOptionProperty =
                    base.GetWebElementPropertiesById(StudentPresentationPageResource.
                    StudentPrsentation_Page_PowerPoint_Option_Id_Locator);
                base.ClickByJavaScriptExecutor(getPowerPointOptionProperty);
                //Select Facet Template
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Facet_Template_Xpath_Locator);
                //Click on Create Option
                IWebElement getCreateOptionProperty =
                    base.GetWebElementPropertiesById(StudentPresentationPageResource.
                    StudentPrsentation_Page_Create_Option_Id_Locator);
                base.ClickByJavaScriptExecutor(getCreateOptionProperty);
                this.IsProcessingCurtainLoading();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptFirstQuestion",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Presentation Player Window.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SelectPresentationPlayerWindow(string activityName)
        {
            //Select Presentation Player Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectPresentationPlayerWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Student Details From Memory
            User user = User.Get(User.UserTypeEnum.CsSmsStudent);
            // Wait for window
            base.WaitUntilWindowLoads(activityName +
                StudentPresentationPageResource.StudentPrsentation_Page_Space_Hypen_Value + user.FirstName +
                StudentPresentationPageResource.StudentPrsentation_Page_Space_Value + user.LastName);
            //Select Window
            base.SelectWindow(activityName +
                StudentPresentationPageResource.StudentPrsentation_Page_Space_Hypen_Value + user.FirstName +
                StudentPresentationPageResource.StudentPrsentation_Page_Space_Value + user.LastName);
            logger.LogMethodExit("StudentPresentationPage", "SelectPresentationPlayerWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select SIM5Activity Student Window.
        /// </summary>
        /// <param name="studentName">This is user type enum.</param>
        /// <param name="activityName">This is activity name.</param>
        /// <param name="scenerioName">This is scenario name.</param>
        public void SelectSimActivityStudentWindowName(User.UserTypeEnum studentName,
            string activityName, string scenerioName = "Default Value")
        {
            //Select Presentation Player Window
            logger.LogMethodEntry("StudentPresentationPage", "SelectSIM5ActivityStudentWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                User user = new User();
                if (scenerioName != "Default Value")
                {
                    switch (scenerioName)
                    {
                        case "ZeroScore":
                            user = User.Get(CommonResource.CommonResource
                                       .SMS_STU_UC1);
                            break;
                        case "setidle":
                            user = User.Get(CommonResource.CommonResource
                                      .SMS_STU_UC2);
                            break;
                        case "100Score":
                            user = User.Get(User.UserTypeEnum.CsSmsStudent);
                            break;
                    }
                }
                else
                {
                    //Wait for the SIM5 assignment launch window
                    user = User.Get(studentName);
                }

                if (ConfigurationManager.AppSettings[StudentPresentationPageResource.Browser_Key]
                    == StudentPresentationPageResource.IE_Browser_Value)
                {
                    base.WaitUntilWindowLoads(StudentPresentationPageResource.
                        StudentPresentation_Page_Sim5_Title_Value);
                    base.SelectWindow(StudentPresentationPageResource.
                        StudentPresentation_Page_Sim5_Title_Value);
                    IWebElement clickHere = base.GetWebElementPropertiesByClassName(StudentPresentationPageResource.
                        StudentPresentation_Page_ClickHereToContinue_ClassLocator_Value);
                    base.ClickByJavaScriptExecutor(clickHere);
                }
                // Wait for window
                base.WaitUntilWindowLoads(activityName + " - " + user.FirstName + " " + user.LastName);
                base.SelectWindow(activityName + " - " + user.FirstName + " " + user.LastName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "SelectSIM5ActivityStudentWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select SIMActivity ZeroScore Student WindowName.
        /// </summary>
        /// <param name="activityName"></param>
        public void SelectSimActivityZeroScoreStudentWindowName(string activityName, string studentType)
        {
            //Select Presentation Player Window
            logger.LogMethodEntry("StudentPresentationPage",
                "SelectSimActivityZeroScoreStudentWindowName",
                base.IsTakeScreenShotDuringEntryExit);
            switch (studentType)
            {
                case "ZeroScore": User user1 = User.Get(CommonResource.CommonResource
                                      .SMS_STU_UC1);
                    // Wait for window
                    base.WaitUntilWindowLoads(activityName + " - " + user1.FirstName + " " + user1.LastName);
                    base.SelectWindow(activityName + " - " + user1.FirstName + " " + user1.LastName);
                    break;
                case "100Score": User user2 = User.Get(User.UserTypeEnum.CsSmsStudent);
                    base.WaitUntilWindowLoads(activityName + " - " + user2.FirstName + " " + user2.LastName);
                    base.SelectWindow(activityName + " - " + user2.FirstName + " " + user2.LastName);
                    break;
            }

            logger.LogMethodExit("StudentPresentationPage",
                "SelectSimActivityZeroScoreStudentWindowName",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select SIMActivity 100 score Student WindowName.
        /// </summary>
        /// <param name="activityName"></param>
        public void SelectSimActivityNormalStudentWindowName(string activityName)
        {
            //Select Presentation Player Window
            logger.LogMethodEntry("StudentPresentationPage",
                "SelectSimActivityNormalStudentWindowName",
                base.IsTakeScreenShotDuringEntryExit);
            User user = User.Get(User.UserTypeEnum.CsSmsStudent);
            // Wait for window
            base.WaitUntilWindowLoads(activityName + " - " + user.FirstName + " " + user.LastName);
            base.SelectWindow(activityName + " - " + user.FirstName + " " + user.LastName);
            logger.LogMethodExit("StudentPresentationPage",
                "SelectSimActivityNormalStudentWindowName",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="?"></param>
        public void AttemptSim5WordActivityQuestions(string attemptPercentage, string activityName)
        {
            logger.LogMethodEntry("StudentPresentationPage", "SelectSimActivityNormalStudentWindowName",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                if (attemptPercentage.Equals("100%"))
                {
                    AttemptSim5WordactivityQuestionsToScore100Percent(activityName);
                    // ThirtyPercentScoringQuestions();
                }
                else if (attemptPercentage.Equals("70%"))
                {
                    AttemptSim5WordactivityQuestionsToScore70Percent(activityName);
                }
                //Click On SIM5 Activity Submit Button
                this.ClickOnSim5ActivitySubmitButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptSim5WordActivityQuestions",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt Sim5 Word Questions for 100 percent.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void AttemptSim5WordactivityQuestionsToScore100Percent(string activityName)
        {
            //Attempt Sim5 Power Point Questions
            logger.LogMethodEntry("StudentPresentationPage", "AttemptSim5WordactivityQuestionsToScore100Percent",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //First Question Submission
                AttemptingFirstWordQuestion(activityName);
                Thread.Sleep(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
                ClickOnSim5NextQuestionButton();
                Thread.Sleep(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
                //Third Question Submission
                AttemptingThirdWordQuestion();
                Thread.Sleep(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
                ClickOnSim5NextQuestionButton();
                Thread.Sleep(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
                //Fifth Question Submission
                AttemptingFifthWordQuestion();
                Thread.Sleep(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
                ClickOnSim5NextQuestionButton();
                Thread.Sleep(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
                Thread.Sleep(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
                // Seventh Question Submission
                AttemptingSeventhWordQuestion();
                Thread.Sleep(Convert.ToInt32

(StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
                // Eighth Question Submission
                AttemptingEighthWordQuestion();
                Thread.Sleep(Convert.ToInt32

(StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
                // Ninth Question Submission
                AttemptingNinthWordQuestion();
                Thread.Sleep(Convert.ToInt32

(StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
                // Tenth Question Submission
                AttemptingTenthWordQuestion();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AttemptSim5PowerPointQuestions",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt Sim5 Word Questions for 70 percent.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void AttemptSim5WordactivityQuestionsToScore70Percent(string activityName)
        {
            //Attempt Sim5 Power Point Questions
            logger.LogMethodEntry("StudentPresentationPage", "AttemptSim5WordactivityQuestionsToScore70Percent",
                base.IsTakeScreenShotDuringEntryExit);
            try
            { //First Question Submission
                new StudentPresentationPage().SelectSimActivityNormalStudentWindowName
                  (activityName);
                //Forteenth Question Submission
                powerPoint.JumpToQuestion("14");
                AttemptingForteenthWordQuestion();
                //Twelfth Question Submission
                powerPoint.JumpToQuestion("12");
                AttemptingTwelfthWordQuestion();
                //Fourth Question Submission
                powerPoint.JumpToQuestion("4");
                AttemptingFourthWordQuestion();
                //Sixteenth Question Submission
                powerPoint.JumpToQuestion("16");
                AttemptingSixteenthWordQuestion();
                //Fifteenth Question Submission
                powerPoint.JumpToQuestion("15");
                AttemptingFifteenthWordQuestion();
                //First Question Submission
                powerPoint.JumpToQuestion("1");
                AttemptingFirstWordQuestion(activityName);
                //Second Question Submission
                powerPoint.JumpToQuestion("2");
                AttemptingSecondWordQuestion();
                //Fifth Question Submission
                powerPoint.JumpToQuestion("5");
                AttemptingFifthWordQuestion();
                // Seventh Question Submission
                powerPoint.JumpToQuestion("7");             
                AttemptingSeventhWordQuestion();
                //Eighth Question Submission
                powerPoint.JumpToQuestion("8");
                AttemptingEighthWordQuestion();
                //Ninth Question Submission
                powerPoint.JumpToQuestion("9");
                AttemptingNinthWordQuestion();
                //Tenth Question Submission
                powerPoint.JumpToQuestion("10");
                AttemptingTenthWordQuestion();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
                logger.LogMethodExit("StudentPresentationPage", "AttemptSim5WordactivityQuestionsToScore70Percent",
                   base.IsTakeScreenShotDuringEntryExit);
            }
        }

        private void JumpToWordQuestion(string questionNumber)
        {
            //Select question from View all questions pop up
            logger.LogMethodEntry("StudentPresentationPage", "JumpToWordQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            this.SelectLastOpenedWindow();
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
            StudentPrsentation_Page_SIM5_Sleep_Time));
            this.IsPageLoading();
            this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.
            StudentPrsentation_Page_PPT_ViewAll_ID_Locator));
            //Click on View all button 
            IWebElement getClickButtonProperty = base.
                GetWebElementPropertiesById(StudentPresentationPageResource.
             StudentPrsentation_Page_PPT_ViewAll_ID_Locator);
            base.ClickByJavaScriptExecutor(getClickButtonProperty);
            this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__ViewAllQuestions_QuestionsList_Xpath_Locator));
            base.IsElementPresent(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__ViewAllQuestions_QuestionsList_Xpath_Locator), 5);
            //Get total number of questions present in view all questions pop up    
            int getTotalQuestions = base.GetElementCountByXPath(StudentPresentationPageResource.
                        StudentPrsentation_Page_Worddocument__ViewAllQuestions_QuestionsList_Xpath_Locator);
            //Click on the required question
            for (int i = 1; i <= getTotalQuestions; i++)
            {
                string getQuestionNumber = base.GetElementTextByXPath(string.
                    Format(StudentPresentationPageResource.
                    StudentPrsentation_Page_Worddocument__ViewAllQuestionsPopUp_QuestionPath_Xpath_Locator, i));
                if (getQuestionNumber.Equals(questionNumber))
                {
                    Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
               StudentPrsentation_Page_SIM5_Sleep_Time));
                    IWebElement getQuestionRowProperty = base.
                        GetWebElementPropertiesByXPath(string.
                    Format(StudentPresentationPageResource.
                    StudentPrsentation_Page_Worddocument__ViewAllQuestionsPopUp_QuestionPath_Xpath_Locator, i));
                    base.PerformDoubleClickAction(getQuestionRowProperty);
                    break;
                }

            }
            this.IsViewAllQuestionsPopUpClosed();
            logger.LogMethodExit("StudentPresentationPage", "JumpToWordQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempting Second Word Question.
        /// Inserting Text from Another Document .
        /// </summary>
        private void AttemptingSecondWordQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingSecondWordQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsPageLoading();
                //Validate proper question loaded
                this.IsQuestionLoaded("2");
                base.SwitchToLastOpenedWindow();
                this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.
                    StudentPrsentation_Page_Worddocument_SecondQuestion_TextBox_Id_Locator));
                //Click on the text box
                base.ClickLinkById(StudentPresentationPageResource.
                    StudentPrsentation_Page_Worddocument_SecondQuestion_TextBox_Id_Locator);
                //Press control and End keys
                Actions builder = new Actions(WebDriver);
                builder.SendKeys(Keys.Control + Keys.End).Build().Perform();
                //Click Insert tab
                powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Worddocument_InsertTab_Xpath_Locator);
                base.SetImplicitWaitTime(Convert.ToInt32(
                    StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));

                //Click Insert icon
                powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Worddocument_InsertIcon_Xpath_Locator);


                //Click Insert text option
                powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Worddocument_InsertText_Xpath_Locator);

                base.SetImplicitWaitTime(Convert.ToInt32(
                    StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_Worddocument_InsertDocumentPopUp_Xpath_Locator));
                this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.
                    StudentPrsentation_Page_Worddocument_DocumentToInsert_Xpath_Locator));
                //Double click on the document required to insert
                IWebElement getDocumentProperty = base.GetWebElementPropertiesById(StudentPresentationPageResource.
                    StudentPrsentation_Page_Worddocument_DocumentToInsert_Xpath_Locator);
                Thread.Sleep(2000);
                base.PerformDoubleClickAction(getDocumentProperty);

            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("StudentPresentationPage", "AttemptingSecondWordQuestion",
               base.IsTakeScreenShotDuringEntryExit);
        }


        private bool isQuestionCompleted(int timeOut = -1)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (timeOut == -1)
            {
                timeOut = this.waitTimeOut;
            }
            bool isQuestionCompleted = false;
            try
            {
                while (stopWatch.Elapsed.TotalSeconds < timeOut)
                {
                    if (WebDriver.FindElement(By.Id(StudentPresentationPageResource.
                        StudentPrsentation_Page_Worddocument_TaskCompletedLightBox_Id_Locator)).Displayed)
                    {
                        base.SetImplicitWaitTime(
                            Convert.ToInt32(StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                        break;
                    }
                }
            }
            //Exception Handling
            catch (Exception)
            {
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return isQuestionCompleted;
        }

        /// <summary>
        /// Attempt First Word Question.
        /// Starting a New Word Document .
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void AttemptingFirstWordQuestion(string activityName)
        {
            //Attempt First Question
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingFirstWordQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Presentation Player Window               
            this.IsQuestionLoaded("1");
            //Select Word document Option
            base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__Id_Locator));
            IWebElement getWordOptionProperty = base.
                GetWebElementPropertiesById(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__Id_Locator);
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(getWordOptionProperty);
            Thread.Sleep(3000);
            //Select blank Template
            this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Blankdocument__Xpath_Locator));
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Blankdocument__Xpath_Locator);
            //Click on Create Option
            base.SwitchToActivePageElement();
            this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.
                StudentPrsentation_Page_Textfill__Id_Locator));
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
               StudentPrsentation_Page_SIM5_Sleep_Time));
            base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPrsentation_Page_Textfill__Id_Locator));
            base.FillTextBoxById(StudentPresentationPageResource.
                StudentPrsentation_Page_Textfill__Id_Locator,
                StudentPresentationPageResource.StudentPrsentation_Page_Text_tofill);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_Thread_sleep));
           
            Actions builder = new Actions(WebDriver);
            builder.SendKeys(Keys.Enter).Build().Perform();
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
           
            builder.SendKeys(Keys.Enter).Build().Perform();

            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
               StudentPrsentation_Page_SIM5_Sleep_Time));
            logger.LogMethodExit("StudentPresentationPage", "AttemptingFirstWordQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Attempting Third Word Question
        /// </summary>
        /// <param name="activityName"></param>
        private void AttemptingThirdWordQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingThirdWordQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToLastOpenedWindow();
            //Select Text.
            IWebElement element = base.GetWebElementPropertiesByXPath

         (StudentPresentationPageResource.StudentPrsentation_Page_Textselect_Xpath_locator);
            // assuming driver is a well behaving WebDriver
            Actions actions = new Actions(WebDriver);
            // and some variation of this:
            actions.MoveToElement(element, 1, 11)
                .ClickAndHold()
                .MoveByOffset(1, 11)
                .Release()
                .Perform();
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_Thread_sleep));
            base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Shadow_Dropdown_Xpath_locator);
            //Select Blue Accent Effect.
            base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Shadow_Xpath_locator);
            //Select Shadow Effect.
            base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Shadoweffect_Xpath_locator);
            IWebElement shadowLink = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.StudentPrsentation_Page_Shadowlink_Xpath_locator);
            base.PerformMouseHoverAction(shadowLink);
            //Select Color Drop Down.
            IWebElement perspectiveShadow = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.
                StudentPrsentation_Page_Persoectivelink_Xpath_locator);
            base.ScrollElementByJavaScriptExecutor(perspectiveShadow);
            base.FocusOnElementByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Persoectivelink_Xpath_locator);
            base.PerformMoveToElementClickAction(perspectiveShadow);
            base.SwitchToLastOpenedWindow();
            //Slect Blue Color.
            IWebElement colorDropdown = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.
                StudentPrsentation_Page_Colordropdown_Xpath_locator);
            base.ClickByJavaScriptExecutor(colorDropdown);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_Thread_sleep));
            IWebElement blueColor = base.GetWebElementPropertiesByXPath
                 (StudentPresentationPageResource.StudentPrsentation_Page_Color_Xpath_locator);
            base.ClickByJavaScriptExecutor(blueColor);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_Thread_sleep));
            base.ClickImageByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Centertext_Xpath_locator);
            IWebElement fontSize = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.StudentPrsentation_Page_Textsize_Xpath_locator);
            base.DoubleClickByJavaScriptExecuter(fontSize);
            base.ClearTextByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Textsize_Xpath_locator);
            base.FillTextBoxByXPath
                (StudentPresentationPageResource.StudentPrsentation_Page_Textsize_Xpath_locator,
                StudentPresentationPageResource.StudentPrsentation_Page_Textsize);
            base.PressKey(StudentPresentationPageResource.StudentPresentation_Page_EnterKey_Value);
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_Thread_sleep));
            logger.LogMethodExit("StudentPresentationPage", "AttemptingThirdWordQuestion",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempting Fourth Word Question.
        /// Inserting Pictures .
        /// </summary>
        public void AttemptingFourthWordQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingFourthWordQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            powerPoint.IsQuestionLoaded("4");
            Thread.Sleep(10000);
            //Position the insertion point to the left of the paragraph that 
            //begins STATEMENT: Some shark species
            Actions builder = new Actions(WebDriver);
            for (int i = 1; i <= 14; i++)
            {
                builder.SendKeys(Keys.ArrowDown).Perform();
                Thread.Sleep(2000);

            }

            for (int i = 1; i <= 18; i++)
            {
                builder.SendKeys(Keys.ArrowLeft).Perform();
                Thread.Sleep(2000);

            }

            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_Insert_Tab_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_Insert_Pictures_Icon_XPath_Locator);


            //Double click on the document required to insert
            this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Question4_Picture_Icon_Id_Locator));
            IWebElement getDocumentProperty = base.GetWebElementPropertiesById(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Question4_Picture_Icon_Id_Locator);
            Thread.Sleep(2000);
            base.PerformDoubleClickAction(getDocumentProperty);
            logger.LogMethodExit("StudentPresentationPage", "AttemptingFourthWordQuestion",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempting Fifth Word Question.
        /// Wrapping Text Around a Picture Using Layout Options .
        /// </summary>

        private void AttemptingFifthWordQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingFifthWordQuestion",
           base.IsTakeScreenShotDuringEntryExit);
            //Change the wrapping style of the picture to Tight
            this.IsPageLoading();
            this.IsQuestionLoaded("5");
            //With the picture selected, to the right of the picture, 
            //click the Layout Options button.
            //Under With Text Wrapping, click the first option—Tight.
            base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPrsentation_Page_Image_Id_Locator));
            IWebElement Thirdelement = base.GetWebElementPropertiesById
                (StudentPresentationPageResource.StudentPrsentation_Page_Image_Id_Locator);
            Thread.Sleep(3000);
            base.PerformMouseRightClickAction(Thirdelement);
            Thread.Sleep(3000);

            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Raptext_Xpath_Locator));
            IWebElement rapText = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.StudentPrsentation_Page_Raptext_Xpath_Locator);
            Thread.Sleep(3000);
            base.PerformMouseHoverByJavaScriptExecutor(rapText);
            Thread.Sleep(3000);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Raptext_Option_Xpath_Locator);

            //Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
            logger.LogMethodExit("StudentPresentationPage", "AttemptingFifthWordQuestion",
           base.IsTakeScreenShotDuringEntryExit);

        }
        /// <summary>
        /// Attempting Seventh Word Question.
        ///  Moving a Picture.
        /// </summary>
        private void AttemptingSeventhWordQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingSeventhWordQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            //Change the picture position so that it is right aligned horizontally relative to the margin.
            this.IsPageLoading();
            this.IsQuestionLoaded("7");
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Formattool_Tab_Xpath_Locator));
            base.ClickLinkByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Formattool_Tab_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PageOptions_Xpath_Locator);

            //Selcting position tab.
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_MoreOptions_Xpath_Locator));
            base.ClickLinkByXPath
                (StudentPresentationPageResource.StudentPrsentation_Page_MoreOptions_Xpath_Locator);
            //Positioning the image in layout frame.
            //Selecting button in layout frame.
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
               StudentPrsentation_Page_PageAlign_Xpath_Locator);

            //Selecting right align.
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
              StudentPrsentation_Page_RightAlign_Xpath_Locator));
            base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_RightAlign_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
              StudentPrsentation_Page_RightAlignOption_Xpath_Locator);

            //Selecting Margin align.
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
              StudentPrsentation_Page_MarginAlign_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
              StudentPrsentation_Page_MarginAlignOption_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
              StudentPrsentation_Page_Pagealign_Okbutton_Xpath_Locator);
            //Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.StudentPrsentation_Page_Thread_sleep));
            logger.LogMethodExit("StudentPresentationPage", "AttemptingSeventhWordQuestion",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Attempting Eighth Word Question.
        /// Applying Picture Styles.
        /// </summary>
        private void AttemptingEighthWordQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingEighthWordQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            //Apply the Divot bevel picture effect—under Bevel,
            //in the third row, the first effect—to the picture.
            this.IsPageLoading();
            this.IsQuestionLoaded("8");
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Formattool_Tab_Xpath_Locator));
            base.ClickLinkByXPath
                (StudentPresentationPageResource.
                StudentPrsentation_Page_Formattool_Tab_Xpath_Locator);
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Pictureeffects_Xpath_Locator));
            base.ClickLinkByXPath
                (StudentPresentationPageResource.
                StudentPrsentation_Page_Pictureeffects_Xpath_Locator);
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_BevelOption_Xpath_Locator));
            IWebElement bevel = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.StudentPrsentation_Page_BevelOption_Xpath_Locator);
            Thread.Sleep(3000);
            base.PerformMouseHoverByJavaScriptExecutor(bevel);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_BevelImage_Xpath_Locator);

            logger.LogMethodExit("StudentPresentationPage", "AttemptingEighthWordQuestion",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempting Ninth Word Question.
        /// Applying Artistic Effects .
        /// </summary>
        private void AttemptingNinthWordQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingNinthWordQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            //Apply the Plastic Wrap artistic effect—fourth row, fifth effect—to the picture. 
            //Close any open dialog boxes or task panes.
            this.IsPageLoading();
            this.IsQuestionLoaded("9");
            //Selecting picture effect
            this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Formattool_Tab_Xpath_Locator));
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Formattool_Tab_Xpath_Locator);
            base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
            // base.ClickLinkByXPath(StudentPresentationPageResource.StudentPrsentation_Page_Formattool_Tab_Xpath_Locator);
            this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PictureEffect_Xpath_Locator));
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PictureEffect_Xpath_Locator);

            // base.ClickLinkByXPath(StudentPresentationPageResource.StudentPrsentation_Page_PictureEffect_Xpath_Locator);
            this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_Effect_Image_Xpath_Locator));
            //base.ClickImageByXPath(StudentPresentationPageResource.StudentPrsentation_Page_Effect_Image_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
              StudentPrsentation_Page_Effect_Image_Xpath_Locator);

            logger.LogMethodExit("StudentPresentationPage", "AttemptingNinthWordQuestion",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempting Tenth Word Question.
        /// Adding a Page Border .
        /// </summary>
        private void AttemptingTenthWordQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingTenthWordQuestion",
           base.IsTakeScreenShotDuringEntryExit);
           //Add a Box setting page border to the document
           //Use the first style, and the color Dark Blue, Text 2—in the fourth column, the first color
            this.IsPageLoading();
            this.IsQuestionLoaded("10");
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_DesineTab_Xpath_Locator));
            base.ClickLinkByXPath
                (StudentPresentationPageResource.StudentPrsentation_Page_DesineTab_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PageBorders_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_BoxOption_Xpath_Locator);
            base.WaitForElement(By.XPath(StudentPresentationPageResource.
                 StudentPrsentation_Page_ColorDrop_Xpath_Locator));
            IWebElement colorArrow = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.StudentPrsentation_Page_ColorDrop_Xpath_Locator);
            Thread.Sleep(3000);
            base.PerformMoveToElementClickAction(colorArrow);
            Thread.Sleep(3000);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_BlueColor_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                 StudentPrsentation_Page_ButtonOk_Xpath_Locator);

            logger.LogMethodExit("StudentPresentationPage", "AttemptingTenthWordQuestion",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempting Twelfth Word Question.
        /// Typing Text in a Shape and Formatting a Shape 
        /// </summary>
        public void AttemptingTwelfthWordQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingTwelfthWordQuestion",
         base.IsTakeScreenShotDuringEntryExit);
            //Part 1-Type Shark Conservation Week in the shape
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_QsFourteen_TextBox_Xpath_Locator);
            Actions builder = new Actions(WebDriver);
            builder.SendKeys("Shark Conservation Week").Perform();

            //Part 2-Select the text and apply Bold,
            //increase the font size to 22, 
            //and change the font color to Dark Blue, Text 2, Darker 50%—in the fourth column

            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_Bold_Icon_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_FontSize_ListArrow_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_FontSize_22_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_FontColor_ListArrow_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_FontColor_DarkBlu50_XPath_Locator);

            //Part 3-Change the Shape Fill to Dark Blue, Text 2, Lighter 80%—in the fourth column, the second color
            //Change the Shape Outline to Dark Blue, Text 2—in the fourth column, the first color
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_Ribbon_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_ShapeFill_ListArrow_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_FontColor_DarkBlu80_XPath_Locator);

            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_ShapeOutline_ListArrow_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_FontColor_DarkBlueText2_XPath_Locator);

            logger.LogMethodExit("StudentPresentationPage", "AttemptingTwelfthWordQuestion",
         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Word Sim5 Forteenth Question Attempt.
        /// Sizing, Positioning, and Formatting a Text Box .
        /// </summary>
        public void AttemptingForteenthWordQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingForteenthWordQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            //Change the text box Horizontal Alignment to Centered relative to the Page. 
            //Change the Vertical Absolute position to 1.25 below the Margin. 
            //Change the text box Height to 1.25.
            //Setting the text box
            Actions builder = new Actions(WebDriver);
            Thread.Sleep(2000);
            //Select Text Box
            IWebElement textBox = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_QsFourteen_TextBox_Xpath_Locator);
            Thread.Sleep(2000);
            base.PerformMouseClickAction(textBox);
            Thread.Sleep(2000);
            // Select DRAWING TOOLS FORMAT tab
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_Ribbon_Xpath_Locator);
            // Select position
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_Position_Ribbon_Xpath_Locator);
           // More Layout Options
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_MoreLayoutOption_Ribbon_Xpath_Locator);
            //Change the text box Horizontal Alignment to Centered relative to the Page. 
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_HorizontalAllignment_Radio_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_HorizontalAllignment_DefaultValue_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_HorizontalAllignment_Value_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_HorizontalAllignment_RelativeToDefaultValue_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_HorizontalAllignment_RelativeToValue_Xpath_Locator);
            //Change the Vertical Absolute position to 1.25 below the Margin. 

            IWebElement radioButton1 = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_Vertical_Radio_Xpath_Locator);
            Thread.Sleep(2000);
            base.PerformMouseClickAction(radioButton1);
            Thread.Sleep(2000);
           
            builder.SendKeys(Keys.Tab).Perform();
            Thread.Sleep(2000);
            builder.SendKeys("7.35").Perform();
            Thread.Sleep(2000);
            builder.SendKeys(Keys.Tab).Perform();
            Thread.Sleep(2000);
            builder.SendKeys(Keys.ArrowDown).Perform();
            Thread.Sleep(2000);
            builder.SendKeys("m").Perform();
            Thread.Sleep(2000);
            builder.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(2000);
            builder.SendKeys(Keys.Tab).Perform();
            Thread.Sleep(2000);

            //Change the text box Height to 1.25 and Width to 3.5
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_MoreLayoutOption_SizeTab_Xpath_Locator);

            IWebElement radioButton2 = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_Width_Radio_Xpath_Locator);
            Thread.Sleep(2000);
            base.PerformMouseClickAction(radioButton2);
            Thread.Sleep(2000);
            builder.SendKeys(Keys.Tab).Perform();
            Thread.Sleep(2000);
            builder.SendKeys("3.5").Perform();
            Thread.Sleep(2000);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_MoreLayoutOption_OK_Button_Xpath_Locator);
            //Apply a Shape Style to the text box—in the last row, the second style—Intense Effect - Blue, Accent 1.
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_ShapeStlye_ListIcon_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_ShapeStlye_Xpath_Locator);
            //Apply a Shadow effect to the text box using the Outer, 
            //Offset Diagonal Top Left shadow—in the third row, the third style. 
            // Close any opened dialog boxes or panes.
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_ShapeEffect_ListIcon_Xpath_Locator);
            IWebElement textBox3 = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_ShapeEffect_Shadow_List_Xpath_Locator);
            Thread.Sleep(2000);
            base.PerformMouseClickAction(textBox3);
            Thread.Sleep(2000);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_DrawingToolFormatTab_ShapeEffect_Shadow_Xpath_Locator);
            logger.LogMethodExit("StudentPresentationPage", "AttemptingForteenthWordQuestion",
          base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Attempting Fifteenth Word Question.
        /// Adding a File Name to the Footer .
        /// </summary>
        public void AttemptingFifteenthWordQuestion()
        {
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingFifteenthWordQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            //Add the File Name to the footer of the document
            //Close the footer

            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_Insert_Tab_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_Insert_Footer_ArrowList_XPath_Locator);
            //Add the File Name to the footer of the document
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_Insert_Footer_EditFooter_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_HeaderFooterTools_DocumentInfo_ArrowList_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_HeaderFooterTools_DocumentInfo_Filename_XPath_Locator);
            //Close the footer
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_HeaderFooterTools_CloseHeaderFooter_Icon_XPath_Locator);

            logger.LogMethodExit("StudentPresentationPage", "AttemptingFifteenthWordQuestion",
          base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Attempting Sixteenth Word Question.
        /// Adding Document Properties and Previewing and Printing a Document .
        /// </summary>
        public void AttemptingSixteenthWordQuestion()
        {
            //In the Document Properties, change the Tags to sharks, conservation 
            //and then change the Subject to Marine Biology, 201 (include the commas). 
            //Press TAB. If necessary, close the Document Panel and open Backstage.
            //Display the Print Preview of the document. Print the document.
            logger.LogMethodEntry("StudentPresentationPage", "AttemptingSixteenthWordQuestion",
           base.IsTakeScreenShotDuringEntryExit);
            //Open Info page fro File menu
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument_Ribbon_File_Tab_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__File_Info_ShowAllProperties_Link_XPath_Locator);
            Actions builder = new Actions(WebDriver);
            //change the Tags to sharks, conservation using keyboard shortcut keys
            builder.SendKeys(Keys.F10).Perform();
            Thread.Sleep(2000);
            builder.SendKeys("I").Perform();
            Thread.Sleep(2000);
            builder.SendKeys("S").Perform();
            Thread.Sleep(2000);
            builder.SendKeys("2").Perform();
            Thread.Sleep(2000);
            builder.SendKeys(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__Question16_Tag_Value).Perform();
            Thread.Sleep(2000);
            builder.SendKeys(Keys.F10).Perform();
            Thread.Sleep(2000);

            //change the Subject to Marine Biology, 201
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__File_Info_Properties_ArrowList_Link_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__File_Info_Properties_AdvancedProperties_Link_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__File_Info_Properties_AdvancedProperties_Summary_Tab_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__File_Info_Properties_AdvancedProperties_Summary_Subject_TextInput_XPath_Locator);
            base.FillTextBoxByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__File_Info_Properties_AdvancedProperties_Summary_Subject_TextInput_XPath_Locator
                , StudentPresentationPageResource.StudentPrsentation_Page_Worddocument__Question16_Subject_Value);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__File_Info_Properties_AdvancedProperties_Ok_Button_XPath_Locator);

            //Display the Print Preview of the document. Print the document.
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__File_Print_Link_XPath_Locator);
            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__File_Print_Print_Button_XPath_Locator);

            logger.LogMethodExit("StudentPresentationPage", "AttemptingSixteenthWordQuestion",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Sim5 Next Question Button.
        /// </summary>

        public void ClickOnSim5NextQuestionButton()
        {
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSim5NextQuestionButton",
         base.IsTakeScreenShotDuringEntryExit);
            base.FocusOnElementById


(StudentPresentationPageResource.StudentPrsentation_Page_Worddocument__Forwardbutton_id_Locator);
            IWebElement forwardButton = base.GetWebElementPropertiesById
                (StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__Forwardbutton_id_Locator);
            base.ClickByJavaScriptExecutor(forwardButton);
            Thread.Sleep(Convert.ToInt32
                (StudentPresentationPageResource.StudentPrsentation_Page_Sleep_time));
            logger.LogMethodExit("StudentPresentationPage", "ClickOnSim5NextQuestionButton",
         base.IsTakeScreenShotDuringEntryExit);
        }

        public void SelectStartTraining()
        {
            logger.LogMethodEntry("StudentPresentationPage", "SelectStartTraining",
            base.IsTakeScreenShotDuringEntryExit);
            IWebElement StartTestButton = base.GetWebElementPropertiesByXPath
                 (StudentPresentationPageResource.
                 StudentPresentation_Page_StartPreTest_Xpath_Locator);
            base.ClickByJavaScriptExecutor(StartTestButton);
            logger.LogMethodExit("StudentPresentationPage", "SelectStartTraining",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close the window abruptly.
        /// </summary>
        public void CloseWindow()
        {
            //Close the Window
            logger.LogMethodEntry("StudentPresentationPage", "CloseWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToLastOpenedWindow();
                //Close the Window
                base.CloseBrowserWindow();
                string browserName = Environment.GetEnvironmentVariable(ENV_PEG_AUTOMATION_BROWSER);
                if (string.IsNullOrEmpty(browserName))
                {
                    browserName = ConfigurationManager.AppSettings[APP_SETTINGS_BROWSER];
                    if (browserName == StudentPresentationPageResource.Chrome_Browser_Value)
                    {
                        base.SwitchToDefaultWindow();
                        base.RefreshTheCurrentPage();
                        base.WaitUntilWindowLoads("Course Materials");
                        base.SelectWindow("Course Materials");
                        base.SwitchToIFrame("ifrmCoursePreview");
                        base.WaitForElement(By.LinkText("Chapter 1: The Science of Psychology"));
                        IWebElement getFolderLink = base.GetWebElementPropertiesByLinkText
                            ("Chapter 1: The Science of Psychology");
                        Thread.Sleep(Convert.ToInt32(CommonPageResource.
                       CommonPage_FolderNavigation_Sleep_Time));
                        base.ClickByJavaScriptExecutor(getFolderLink);
                        base.SwitchToDefaultWindow();

                    }
                    else
                    {
                        base.AcceptAlert();
                        base.SwitchToDefaultWindow();
                    }
                    //Switch to Default Window

                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "CloseWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Answer the Questions of activity.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="activityBehaviourType">This is the activityBehaviourType of an activity.</param>
        /// <param name="activityType">This is the activity type.</param>
        /// <param name="optionType">This is the Type of answer that has to be updated.</param>
        public void AnswerActivityQuestions(ActivityQuestionsList.ActivityNameEnum activityName,
            ActivityQuestionsList.ActivityBehaviourTypeEnum activityBehaviourType,
            ActivityQuestionsList.ActivityTypeEnum activityType, String OptionType, String TestType = "Default Type")
        {
            // Answer the Questions of activity
            logger.LogMethodEntry("StudentPresentationPage", "AnswerActivityQuestions",
                base.IsTakeScreenShotDuringEntryExit);
            string ActualQuestion = String.Empty;
            try
            {
                base.WaitForElement(By.CssSelector(StudentPresentationPageResource.
                        StudentPresentation_Page_HSS_Activity_QuestionCount_Value));
                int QuestionCount = base.GetElementCountByCssSelector(
                        StudentPresentationPageResource.
                        StudentPresentation_Page_HSS_Activity_QuestionCount_Value);
                if (OptionType.Equals(StudentPresentationPageResource.
                    StudentPresentation_Page_HSS_Activity_Partial_AnswerOptionValue)
                    && (TestType.Equals("Default Type")))
                {
                    QuestionCount = 2;
                    OptionType = StudentPresentationPageResource.
                        StudentPresentation_Page_HSS_Activity_Correct_AnswerOptionValue;
                }
                if (!(TestType.Equals("Default Type")))
                {
                    OptionType = StudentPresentationPageResource.
                        StudentPresentation_Page_HSS_Activity_Correct_AnswerOptionValue;
                }
                for (int NthQuestion = 1; NthQuestion <= QuestionCount; NthQuestion++)
                {
                    while (NthQuestion > 18 && !(TestType.Equals("Default Type"))
                        && OptionType.Equals(StudentPresentationPageResource.
                        StudentPresentation_Page_HSS_Activity_Correct_AnswerOptionValue))
                    {
                        OptionType = StudentPresentationPageResource.
                            StudentPresentation_Page_HSS_Activity_inCorrect_AnswerOptionValue;
                        break;
                    }

                    IList<IWebElement> Qus = WebDriver.FindElements(By.ClassName(
                        StudentPresentationPageResource.
                        StudentPresentation_Page_HSS_Activity_Question_Value));
                    foreach (IWebElement element in Qus)
                    {
                        if (element.Text.Equals(String.Empty)) continue;
                        else
                        {
                            ActualQuestion = element.Text;
                            String Option = base.GetQuestionOptionName(activityType,
                                activityBehaviourType, activityName, ActualQuestion, OptionType);
                            if (Option.Contains("|"))
                            {
                                string[] words = Option.Split('|');
                                foreach (string word in words)
                                {
                                    base.WaitForElement(By.LinkText(word));
                                    IWebElement SelectOption = base.
                                        GetWebElementPropertiesByLinkText(word);
                                    base.ClickByJavaScriptExecutor(SelectOption);
                                }
                            }
                            else
                            {
                                int numberOption = 0;
                                bool result = int.TryParse(Option, out numberOption);
                                if (numberOption != 0)
                                {
                                    for (int NthOption = 1; NthOption <= 8; NthOption++)
                                    {
                                        if (NthOption % 2 != 0)
                                        {
                                            base.WaitForElement(By.XPath(string.Format(
                                                StudentPresentationPageResource.
                                                StudentPresentation_Page_HSS_Activity_NumericOption_Xpath_Locator,
                                                NthQuestion, NthOption)));
                                            IWebElement RadioOption = base.
                                                GetWebElementPropertiesByXPath(string.Format(
                                                StudentPresentationPageResource.
                                                StudentPresentation_Page_HSS_Activity_NumericOption_Xpath_Locator,
                                                NthQuestion, NthOption));
                                            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                                            StudentPresentation_Page_LaunchWindow_TimeValue));
                                            String TempOption = RadioOption.Text;
                                            if (TempOption.Equals(Option))
                                            {
                                                base.ClickByJavaScriptExecutor(RadioOption);
                                                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                                                StudentPresentation_Page_LaunchWindow_TimeValue));
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    IWebElement SelectOption = base.
                                        GetWebElementPropertiesByLinkText(Option);
                                    Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                                           StudentPresentation_Page_LaunchWindow_TimeValue));
                                    base.ClickByJavaScriptExecutor(SelectOption);

                                }
                            }
                            base.WaitForElement(By.Id(StudentPresentationPageResource.
                                StudentPresentation_Page_HSS_Activity_NextButton_ID_Locator));
                            IWebElement NextQuestButton = base.GetWebElementPropertiesById(
                                StudentPresentationPageResource.
                                StudentPresentation_Page_HSS_Activity_NextButton_ID_Locator);
                            base.ClickByJavaScriptExecutor(NextQuestButton);
                            break;
                        }
                    }

                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "AnswerActivityQuestions",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on SubmitForGrading.
        /// </summary>
        public void SubmitForGrading()
        {
            //Click on SubmitForGrading
            logger.LogMethodEntry("StudentPresentationPage", "SubmitForGrading",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_HSS_Activity_SubmitButton_ID_Locator));
                IWebElement SubmitButton = base.GetWebElementPropertiesById(
                        StudentPresentationPageResource.
                        StudentPresentation_Page_HSS_Activity_SubmitButton_ID_Locator);
                base.ClickByJavaScriptExecutor(SubmitButton);
                //Click on Finish button
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_HSS_Activity_FinishButton_ID_Locator));
                IWebElement FinishButton = base.GetWebElementPropertiesById(
                    StudentPresentationPageResource.StudentPresentation_Page_HSS_Activity_FinishButton_ID_Locator);
                base.ClickByJavaScriptExecutor(FinishButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "SubmitForGrading",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the score of the activity.
        /// </summary>
        /// <returns>Activity score.</returns>
        public string GetActivityScore()
        {
            //Get the score of the activity
            logger.LogMethodEntry("StudentPresentationPage", "GetActivityScore",
            base.IsTakeScreenShotDuringEntryExit);
            string actualScore = string.Empty;
            try
            {
                base.WaitForElement(By.XPath(
                        StudentPresentationPageResource.
                        StudentPresentation_Page_Exem_ActivityScore_XPath_Locator));
                IWebElement getScore = base.GetWebElementPropertiesByXPath(
                        StudentPresentationPageResource.
                        StudentPresentation_Page_Exem_ActivityScore_XPath_Locator);
                actualScore = getScore.Text;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "GetActivityScore",
            base.IsTakeScreenShotDuringEntryExit);
            return actualScore;
        }

        /// <summary>
        /// Click on return to  course.
        /// </summary>
        public void ReturnBackToCourseSpace()
        {
            //Click on return to  course.
            logger.LogMethodEntry("StudentPresentationPage", "RuturnBackToCourseSpace",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_HSS_Activity_ReturnToCourseButton_ID_Locator));
                IWebElement getReturnToCourseButton = base.GetWebElementPropertiesById(
                        StudentPresentationPageResource.
                        StudentPresentation_Page_HSS_Activity_ReturnToCourseButton_ID_Locator);

                base.ClickByJavaScriptExecutor(getReturnToCourseButton);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "RuturnBackToCourseSpace",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on View all submission.
        /// </summary>
        public void ClickOnViewSubmission()
        {
            //Click on View all submission
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnViewSubmission",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window And Frame
                this.SelectWindowAndFrame();
                //Click on view submission button
                base.WaitForElement(By.ClassName(StudentPresentationPageResource.
                    StudentPrsentation_Page_Activity_ViewSubmission_ClassName_Locator));
                IWebElement getViewSubmissionButton = base.
                    GetWebElementPropertiesByClassName(StudentPresentationPageResource.
                    StudentPrsentation_Page_Activity_ViewSubmission_ClassName_Locator);
                base.ClickByJavaScriptExecutor(getViewSubmissionButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickOnViewSubmission",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the activity score of the student.
        /// </summary>
        /// <returns>Activity score.</returns>
        public string GetSubmissionScoreByStudent()
        {
            logger.LogMethodEntry("StudentPresentationPage", "GetSubmissionScoreByStudent",
            base.IsTakeScreenShotDuringEntryExit);
            string actualScore = string.Empty;
            try
            {
                base.SwitchToLastOpenedWindow();

                base.WaitForElement(By.XPath(
                    StudentPresentationPageResource.
                    StudentPresentation_Page_HSS_Activity_SubmissionScore_Xpath_Locator));
                IWebElement getScore = base.GetWebElementPropertiesByXPath(
                    StudentPresentationPageResource.
                    StudentPresentation_Page_HSS_Activity_SubmissionScore_Xpath_Locator);
                actualScore = getScore.Text;
                base.ClickByJavaScriptExecutor(getScore);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "GetSubmissionScoreByStudent",
            base.IsTakeScreenShotDuringEntryExit);
            return actualScore;
        }

        /// <summary>
        /// Get the activity grade of the student.
        /// </summary>
        /// <returns>Activity grade.</returns>
        public string GetactivityGradeByStudent()
        {
            logger.LogMethodEntry("StudentPresentationPage", "GetactivityGradeByStudent",
            base.IsTakeScreenShotDuringEntryExit);
            string actualScore = string.Empty;
            try
            {
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_HSS_Activity_activityGrade_ID_Locator));
                IWebElement activityGrade = base.GetWebElementPropertiesById(
                    StudentPresentationPageResource.
                    StudentPresentation_Page_HSS_Activity_activityGrade_ID_Locator);
                actualScore = activityGrade.Text;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "GetactivityGradeByStudent",
            base.IsTakeScreenShotDuringEntryExit);
            return actualScore;
        }

        /// <summary>
        /// Get the Student details.
        /// </summary>
        /// <returns>Student details.</returns>
        public string getStudentDetails()
        {
            logger.LogMethodEntry("StudentPresentationPage", "getStudentDetails",
            base.IsTakeScreenShotDuringEntryExit);
            string studentDetail = string.Empty;
            try
            {
                base.WaitForElement(By.Id(
                        StudentPresentationPageResource.
                        StudentPresentation_Page_HSS_Activity_StudentDetails_ID_Locator));
                IWebElement StudentDetails = base.GetWebElementPropertiesById(
                    StudentPresentationPageResource.
                    StudentPresentation_Page_HSS_Activity_StudentDetails_ID_Locator);
                studentDetail = StudentDetails.Text;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "getStudentDetails",
            base.IsTakeScreenShotDuringEntryExit);
            return studentDetail;
        }

        /// <summary>
        /// Click on Save For Later Option.
        /// </summary>
        public void ClickOnSaveForLaterOption()
        {
            // Click on Save For Later Option
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnSaveForLaterOption",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                         StudentPresentation_Page_HSS_Activity_SaveForLater_ID_Locator));
                IWebElement getSaveForLaterButton = base.GetWebElementPropertiesById(
                         StudentPresentationPageResource.
                         StudentPresentation_Page_HSS_Activity_SaveForLater_ID_Locator);
                base.ClickByJavaScriptExecutor(getSaveForLaterButton);
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_HSS_Activity_ConfirmSave_ID_Locator));
                IWebElement getSaveButton = base.GetWebElementPropertiesById(
                    StudentPresentationPageResource.
                    StudentPresentation_Page_HSS_Activity_ConfirmSave_ID_Locator);
                // Click on Save For Later Option
                base.ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickOnSaveForLaterOption",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch the Studyplan Pre Test / Post Test.
        /// </summary>
        /// <param name="TestType">This is the test type.</param>
        public void ClickOpenToLaunchTheQuestions(string TestType)
        {
            //Launch the test
            logger.LogMethodEntry("StudentPresentationPage", "ClickOpenToLaunchTheQuestions",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (TestType)
                {
                    case "PreTest": LaunchThePreTestQuestions();
                        break;
                    case "PostTest": LaunchThePostTestQuestions();
                        break;
                }
                //CLick on 'Open' option
                IWebElement OpenButton = base.GetWebElementPropertiesById(
                    StudentPresentationPageResource.
                    StudentPresentation_Page_StudyPlan_Open_ID_Locator);
                base.PerformMoveToElementClickAction(OpenButton);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPresentation_Page_Sleep_Value));
                base.SwitchToLastOpenedWindow();
                //Wait for 'Continue' button and click
                if (TestType.Equals("PreTest"))
                {
                    base.WaitForElement(By.Id(StudentPresentationPageResource.
                        StudentPresentation_Page_StudyPlan_Continue_ID_Locator));
                    IWebElement ContinueButton = base.GetWebElementPropertiesById(
                        StudentPresentationPageResource.
                        StudentPresentation_Page_StudyPlan_Continue_ID_Locator);
                    base.PerformMoveToElementClickAction(ContinueButton);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ClickOpenToLaunchTheQuestions",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Pre Test cmenu.
        /// </summary>
        private void LaunchThePreTestQuestions()
        {
            //Click on Pre Test cmenu
            logger.LogMethodEntry("StudentPresentationPage", "LaunchThePreTestQuestions",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(
                       StudentPresentationPageResource.
                       StudentPresentation_Page_Pretest_Cmenu_ID_Locator));
                IWebElement cMmenuButton = base.GetWebElementPropertiesById(
                    StudentPresentationPageResource.
                    StudentPresentation_Page_Pretest_Cmenu_ID_Locator);
                base.ClickByJavaScriptExecutor(cMmenuButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "LaunchThePreTestQuestions",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Post Test cmenu.
        /// </summary>
        private void LaunchThePostTestQuestions()
        {
            //Click on Post Test cmenu
            logger.LogMethodEntry("StudentPresentationPage", "LaunchThePostTestQuestions",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPresentation_Page_Posttest_Cmenu_ID_Locator));
                IWebElement cMenuButton = base.GetWebElementPropertiesById(
                        StudentPresentationPageResource.
                        StudentPresentation_Page_Posttest_Cmenu_ID_Locator);
                base.ClickByJavaScriptExecutor(cMenuButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "LaunchThePostTestQuestions",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Return to Course.
        /// </summary>
        public void ReturnToCourseSpace()
        {

            logger.LogMethodEntry("StudentPresentationPage", "ReturnToCourseSpace",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to window
                this.SwitchToWindow(StudentPresentationPageResource.
                    StudentPresentation_Page_OpenStudyPlan_Window_Name);
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                    StudentPrsentation_Page_OpenStudyPlan_ReturnToCourseButton_Id_Value));
                IWebElement returnBackToCourse = base.
                    GetWebElementPropertiesById(StudentPresentationPageResource.
                    StudentPrsentation_Page_OpenStudyPlan_ReturnToCourseButton_Id_Value);
                //Click on buttton
                base.ClickByJavaScriptExecutor(returnBackToCourse);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage", "ReturnToCourseSpace",
             base.IsTakeScreenShotDuringEntryExit);

        }

        private void SwitchToWindow(string windowName)
        {
            base.WaitUntilWindowLoads(windowName);
            base.SelectWindow(windowName);
        }

        /// <summary>
        /// Get asset status value.
        /// </summary>
        /// <param name="assetName">This is asset name.</param>
        /// <param name="windowName">This is window name.</param>
        /// <returns>The status value of asset.</returns>
        public string GetStatusOfSubmittedActivityInAssignmentsPage(string assetName, string windowName)
        {
            //Get Status Of Submitted Activity In CourseMaterial
            logger.LogMethodEntry("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize getStatusText variable
            string getActivitySubmittedStatus = string.Empty;
            try
            {
                this.SwitchToWindow(windowName);
                //Switch To Frame
                base.SwitchToIFrameById(StudentPresentationPageResource.
                    StudentPresentation_Page_Content_Frame_Id_Locator);
                base.WaitForElement(By.CssSelector(StudentPresentationPageResource.
                    StudentPresentation_CompletedActivity_Records_CssSelector_Value));
                int Test = base.GetElementCountByCssSelector(StudentPresentationPageResource.
                    StudentPresentation_CompletedActivity_Records_CssSelector_Value);
                for (int i = 2; i <= Test; i++)
                {
                    //Find the expected asset

                    base.WaitForElement(By.CssSelector(string.
                        Format(StudentPresentationPageResource.
                        StudentPresentation_CompletedActivity_AssetName_CssSelector_Value, i)));
                    IWebElement Text = base.GetWebElementPropertiesByCssSelector
                        ((string.Format(StudentPresentationPageResource.
                        StudentPresentation_CompletedActivity_AssetName_CssSelector_Value, i)));
                    Thread.Sleep(3000);
                    String ativityName = Text.Text;

                    if (ativityName.Equals(assetName))
                    {

                        base.WaitForElement(By.CssSelector(String.Format(StudentPresentationPageResource.
                            StudentPresentation_CompletedActivity_AssetStatusText_CssSelector_Value, i)));
                        IWebElement cmenuOption = base.GetWebElementPropertiesByCssSelector((String.
                            Format(StudentPresentationPageResource.
                            StudentPresentation_CompletedActivity_AssetStatusText_CssSelector_Value, i)));
                        Thread.Sleep(3000);
                        //Get the status value of the asset
                        getActivitySubmittedStatus = cmenuOption.Text;
                        break;
                    }
                }
                base.SelectWindow(windowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.IsTakeScreenShotDuringEntryExit);
            //Return the status value of the asset
            return getActivitySubmittedStatus;
        }

        /// <summary>
        /// Get score of the activity submitted.
        /// </summary>
        /// <returns>Score of the activity.</returns>
        public string GetActivityScoreFromCourseMaterialsPageBB(Grade.GradeTypeEnum gradeType, string assetName)
        {
            //Get score Of Submitted Activity In CourseMaterial
            logger.LogMethodEntry("StudentPresentationPage",
                "GetActivityScoreFromCourseMaterialsPage",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize getStatusText variable
            string getActivitySubmittedScore = string.Empty;
            try
            {
                //Get the activty column count
                int activityColumnCount = this.GetTheActivityNameInCourseMaterial(assetName);
                //Get the score of the activity
                getActivitySubmittedScore = base.GetElementTextByXPath(
              string.Format(StudentPresentationPageResource.
              CoursePreviewMainUX_Page_ActivityScore_Xpath_Locator, activityColumnCount));
                getActivitySubmittedScore = getActivitySubmittedScore.Replace("%", "");
                // Store the edited score in grade enum
                new ViewSubmissionPage().StoreGradeDetails(gradeType, getActivitySubmittedScore);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
              "GetActivityScoreFromCourseMaterialsPage",
                  base.IsTakeScreenShotDuringEntryExit);
            return getActivitySubmittedScore;
        }
    }
}