﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.QuestionLibrary;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Create TrueFalse Question Type.
    /// </summary>
    public class AutoGraderPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(AutoGraderPage));

        /// <summary>
        /// Select Create New Question Window And Frame.
        /// </summary>
        private void SelectCreateNewQuestionWindowAndFrame()
        {
            //Create SIM Studyplan
            Logger.LogMethodEntry("AutoGraderPage",
                "SelectCreateNewQuestionWindowAndFrame",
                base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(Convert.ToInt32(AutoGraderPageResource.
                AutoGraderPageResourse_GraderIt_Wait_Time_Value));
            //Select Create New Question Window And Frame
            base.WaitUntilWindowLoads(AutoGraderPageResource.
                AutoGraderPageResourse_CreateNewQuestion_WindowName);
            base.SelectWindow(AutoGraderPageResource.
                AutoGraderPageResourse_CreateNewQuestion_WindowName);
            //Select Question frame
            base.SwitchToIFrame(AutoGraderPageResource.
                AutoGraderPageResourse_CreateNewQuestion_Frame);
            Logger.LogMethodExit("AutoGraderPage",
                "SelectCreateNewQuestionWindowAndFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Grader IT Question.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        public void CreateGraderITQuestion(Question.QuestionTypeEnum questionTypeEnum)
        {
            //Create SIM Studyplan
            Logger.LogMethodEntry("AutoGraderPage", "CreateGraderITQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create New Question Window And Frame
                this.SelectCreateNewQuestionWindowAndFrame();
                //Enter The Grader Question Name
                this.EnterTheGraderQuestionName(questionTypeEnum);
                //Select Project Question From Project Creation Tool
                this.SelectProjectQuestionFromProjectCreationTool();
                //Select Create New Question Window And Frame
                this.SelectCreateNewQuestionWindowAndFrame();
                //Wait for the Maximum score
                base.WaitForElement(By.Id(AutoGraderPageResource.
                    AutoGraderPageResourse_MaximumScore_TextBox_Id_Locator));
                base.FillTextBoxById(AutoGraderPageResource.
                    AutoGraderPageResourse_MaximumScore_TextBox_Id_Locator,
                    AutoGraderPageResource.AutoGraderPageResourse_MaximumScore_Value);
                //Click On SaveAndClose Button
                this.ClickOnSaveAndCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AutoGraderPage", "CreateGraderITQuestion",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Grader Question Name.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        private void EnterTheGraderQuestionName(
            Question.QuestionTypeEnum questionTypeEnum)
        {
            //Enter The Grader Question Name
            Logger.LogMethodEntry("AutoGraderPage", "EnterTheGraderQuestionName",
                base.IsTakeScreenShotDuringEntryExit);
            //Create Sim GraderIT Activity
            Guid QuestionName = Guid.NewGuid();
            //Wait for the element
            base.WaitForElement(By.Id(AutoGraderPageResource.
                AutoGraderPageResourse_CreateNewQuestion_TextBox_Id_Locator));
            //Fill the question  name
            base.FillTextBoxById(AutoGraderPageResource.
                AutoGraderPageResourse_CreateNewQuestion_TextBox_Id_Locator,
                QuestionName.ToString());
            //Wait for the element
            base.WaitForElement(By.Id(AutoGraderPageResource.
                AutoGraderPageResourse_CreateNewQuestion_Answer_Button_Id_Locator));
            IWebElement getAddAnswer = base.GetWebElementPropertiesById
                (AutoGraderPageResource.
                AutoGraderPageResourse_CreateNewQuestion_Answer_Button_Id_Locator);
            //Click the Add Answer Button
            base.ClickByJavaScriptExecutor(getAddAnswer);
            //Wait for the lement
            base.WaitForElement(By.Id(AutoGraderPageResource.
                AutoGraderPageResourse_CreateNewQuestion_Project_Id_Locator));
            IWebElement getSelectProjectButton = base.GetWebElementPropertiesById
                (AutoGraderPageResource.
                AutoGraderPageResourse_CreateNewQuestion_Project_Id_Locator);
            //Click the ProjectId Button
            base.ClickByJavaScriptExecutor(getSelectProjectButton);
            //Store The Grader Question In Memory
            this.StoreTheGraderQuestionInMemory(questionTypeEnum, QuestionName);
            Logger.LogMethodExit("AutoGraderPage", "EnterTheGraderQuestionName",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store The Grader Question In Memory.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        /// <param name="QuestionName">This is Question Name.</param>
        private void StoreTheGraderQuestionInMemory(
            Question.QuestionTypeEnum questionTypeEnum, Guid QuestionName)
        {
            // Store The Grader Question In Memory
            Logger.LogMethodEntry("AutoGraderPage", "StoreTheGraderQuestionInMemory",
                   base.IsTakeScreenShotDuringEntryExit);
            //Store the Grader Question
            Question newQuestionType = new Question
            {
                Name = QuestionName.ToString(),
                QuestionType = questionTypeEnum,
                IsCreated = true,
            };
            newQuestionType.StoreQuestionInMemory();
            Logger.LogMethodExit("AutoGraderPage", "StoreTheGraderQuestionInMemory",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On SaveAndClose Button.
        /// </summary>
        private void ClickOnSaveAndCloseButton()
        {
            //Click On SaveAndClose Button
            Logger.LogMethodEntry("AutoGraderPage", "ClickOnSaveAndCloseButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Click The Question SaveButton
            this.ClickTheQuestionSaveButton();
            //Select Create New Question Window And Frame
            this.SelectCreateNewQuestionWindowAndFrame();
            //Wait for the element
            base.WaitForElement(By.Id(AutoGraderPageResource.
                AutoGraderPageResourse_AddClose_Button_Id_Locator));
            IWebElement getAddCloseButton = base.GetWebElementPropertiesById
                (AutoGraderPageResource.
                AutoGraderPageResourse_AddClose_Button_Id_Locator);
            //Click on Add Close button
            base.ClickByJavaScriptExecutor(getAddCloseButton);
            Thread.Sleep(Convert.ToInt32(AutoGraderPageResource.
                AutoGraderPageResourse_ThreadTime_Value));
            Logger.LogMethodExit("AutoGraderPage", "ClickOnSaveAndCloseButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Question SaveButton.
        /// </summary>
        private void ClickTheQuestionSaveButton()
        {
            //Click The Question SaveButton
            Logger.LogMethodEntry("AutoGraderPage", "ClickTheQuestionSaveButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(AutoGraderPageResource.
                AutoGraderPageResourse_SaveClose_Button_Id_Locator));
            IWebElement getSaveAndCloseButton = base.GetWebElementPropertiesById
                (AutoGraderPageResource.
                AutoGraderPageResourse_SaveClose_Button_Id_Locator);
            //Click the 'Save And Close' button
            base.ClickByJavaScriptExecutor(getSaveAndCloseButton);
            Logger.LogMethodExit("AutoGraderPage", "ClickTheQuestionSaveButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Project Question From Project Creation Tool.
        /// </summary>
        private void SelectProjectQuestionFromProjectCreationTool()
        {
            //Select Project Question From Project Creation Tool
            Logger.LogMethodEntry("AutoGraderPage",
                "SelectProjectQuestionFromProjectCreationTool",
                base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(Convert.ToInt32(AutoGraderPageResource.
                AutoGraderPageResourse_Wait_Time_Value));

            //Select Project Creation Tool Window
            this.SelectProjectCreationToolWindow();
            //Get  the Project Name
            string getProjectName = AutoGraderPageResource.
                AutoGraderPageResourse_GraderProject_Name;
            //Select The Project ID
            this.SelectTheProject(getProjectName);
            Logger.LogMethodExit("AutoGraderPage",
                "SelectProjectQuestionFromProjectCreationTool",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Project Creation Tool Window.
        /// </summary>
        private void SelectProjectCreationToolWindow()
        {
            //Select Project Creation Tool Window
            Logger.LogMethodEntry("AutoGraderPage", "SelectProjectCreationToolWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Select the Project Creation tool window
            base.WaitUntilWindowLoads(AutoGraderPageResource.
                AutoGraderPageResourse_ProjectCreationTool_WindowName);
            base.SelectWindow(AutoGraderPageResource.
                AutoGraderPageResourse_ProjectCreationTool_WindowName);
            Logger.LogMethodExit("AutoGraderPage", "SelectProjectCreationToolWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create The GraderIT Question In ManageQuestionBank.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        /// <param name="projectName">This is Project Name.</param>
        public void CreateTheGraderITQuestionInManageQuestionBank(
            Question.QuestionTypeEnum questionTypeEnum, string projectName)
        {
            //Create The GraderIT Question In ManageQuestionBank
            Logger.LogMethodEntry("AutoGraderPage",
                "CreateTheGraderITQuestionInManageQuestionBank",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Enter The Grader Question Name
                this.EnterTheGraderQuestionName(questionTypeEnum);
                //Select Project Creation Tool Window
                this.SelectProjectCreationToolWindow();
                //Select The Project 
                this.SelectTheProject(projectName);
                base.SelectDefaultWindow();
                //Wait for the Maximum score
                base.WaitForElement(By.Id(AutoGraderPageResource.
                    AutoGraderPageResourse_MaximumScore_TextBox_Id_Locator));
                if (base.IsElementEnabledById(string.Format((AutoGraderPageResource.
                    AutoGraderPageResourse_MaximumScore_TextBox_Id_Locator))))
                {
                    //Fill Score for 2007 type question
                    base.FillTextBoxById(AutoGraderPageResource.
                    AutoGraderPageResourse_MaximumScore_TextBox_Id_Locator,
                    AutoGraderPageResource.AutoGraderPageResourse_MaximumScore_Value);
                }
                //Click The Question SaveButton
                this.ClickTheQuestionSaveButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AutoGraderPage",
                "CreateTheGraderITQuestionInManageQuestionBank",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Project.
        /// </summary>
        /// <param name="projectName">This is Project Name.</param>
        private void SelectTheProject(string projectName)
        {
            //Select The Project
            Logger.LogMethodEntry("AutoGraderPage", "SelectTheProject",
                base.IsTakeScreenShotDuringEntryExit);
            //Maxmize pop-up window
            base.MaximizeWindow();
            //Wait for project load
            Thread.Sleep(Convert.ToInt32(AutoGraderPageResource.
                AutoGraderPageResourse_GraderIt_Wait_Time_Value));
            //Wait for the element
            base.WaitForElement(By.XPath(AutoGraderPageResource.
             AutoGraderPageResourse_GradeIT_Projects_Tab_Xpath_Locator));
            //Get GraderProject Button
            IWebElement getGraderProjectsButton =
                base.GetWebElementPropertiesByXPath(AutoGraderPageResource.
                AutoGraderPageResourse_GradeIT_Projects_Tab_Xpath_Locator);
            //Click on GraderProject Button
            base.ClickByJavaScriptExecutor(getGraderProjectsButton);
            SearchTheProject(projectName);
            Logger.LogMethodExit("AutoGraderPage", "SelectTheProject",
               base.IsTakeScreenShotDuringEntryExit);
        }

         /// <summary>
        /// Search The Project.
        /// </summary>
        /// <param name="projectName">This is Project Name.</param>
        private void SearchTheProject(string projectName)
        {
            //Select The Project
            Logger.LogMethodEntry("AutoGraderPage", "SearchTheProject",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for project load
            Thread.Sleep(Convert.ToInt32(AutoGraderPageResource.
                AutoGraderPageResourse_GraderIt_Wait_Time_Value));
            //Wait for the element
            base.WaitForElement(By.Id(AutoGraderPageResource.
                AutoGraderPageResourse_GradeIT_Projects_Search_Box_Id_Locator));
            //Fill the Project name
            base.FillTextBoxById(AutoGraderPageResource.
                AutoGraderPageResourse_GradeIT_Projects_Search_Box_Id_Locator,
                projectName);
            //Wait for the element
            base.WaitForElement(By.XPath(AutoGraderPageResource.
                AutoGraderPageResourse_GradeIT_Projects_Search_Xpath_Locator));
            //Get Search Button on PCT
            IWebElement getSearchButton = base.GetWebElementPropertiesByXPath
                (AutoGraderPageResource.
                AutoGraderPageResourse_GradeIT_Projects_Search_Xpath_Locator);
            //Click on Search buttun
            base.ClickByJavaScriptExecutor(getSearchButton);
            //Wait for project load
            Thread.Sleep(Convert.ToInt32(AutoGraderPageResource.
                AutoGraderPageResourse_GraderIt_Wait_Time_Value));
            base.WaitForElement(By.XPath(AutoGraderPageResource.
             AutoGraderPageResourse_ProjectTotalCount_Xpath_Locator));
            //Get the total count of the Project name
            int getTotalCourseCount = base.GetElementCountByXPath(
                AutoGraderPageResource.
                   AutoGraderPageResourse_ProjectTotalCount_Xpath_Locator);
            for (int setProjectDivCount = 1; setProjectDivCount <=
                            getTotalCourseCount; setProjectDivCount++)
            {
                //Get the Project Name Text
                String getProjectName = base.GetElementTextByXPath(
                    string.Format(AutoGraderPageResource.
                    AutoGraderPageResourse_Project_Name_Xpath_Locator,
                    setProjectDivCount));
                //Match the  expected course name from List of courses 
                if (getProjectName.Contains(projectName))
                {
                    //Perform MouseAction For ProjectName
                    this.PerformMouseActionForProjectName(setProjectDivCount);
                    break;
                }
            }
            Logger.LogMethodExit("AutoGraderPage", "SearchTheProject",
              base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Perform Mouse Action For ProjectName.
        /// </summary>
        /// <param name="setProjectDivCount">This is Project Count.</param>
        private void PerformMouseActionForProjectName(int setProjectDivCount)
        {
            //Perform Mouse Action For ProjectName
            Logger.LogMethodEntry("AutoGraderPage",
                "PerformMouseActionForProjectName",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(string.Format(AutoGraderPageResource.
                 AutoGraderPageResourse_Project_Name_Mouseover_Xpath_Locator,
                 setProjectDivCount)));
            IWebElement getSelectedProject = base.GetWebElementPropertiesByXPath
                (string.Format(AutoGraderPageResource.
                AutoGraderPageResourse_Project_Name_Mouseover_Xpath_Locator,
                setProjectDivCount));

            //base.PerformMouseHoverAction(getSelectButtonID);
            base.MouseOverByJavaScriptExecutor(getSelectedProject);
            //base.PerformMouseHoverByJavaScriptExecutor(getSelectButtonID);

            //Wait for the element
            base.WaitForElement(By.XPath(string.Format(AutoGraderPageResource.
                AutoGraderPageResourse_SelectProject_Click_Xpath_Locator,
                setProjectDivCount)));
            IWebElement getSelectProject = base.GetWebElementPropertiesByXPath
                (string.Format(AutoGraderPageResource.
                AutoGraderPageResourse_SelectProject_Click_Xpath_Locator,
                setProjectDivCount));
            //Click on 'Select Project' button
            base.ClickByJavaScriptExecutor(getSelectProject);
            Thread.Sleep(Convert.ToInt32(AutoGraderPageResource.
                AutoGraderPageResourse_ThreadTime_Value));
            Logger.LogMethodExit("AutoGraderPage",
                "PerformMouseActionForProjectName",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Question Title Textbox In Edit Window.
        /// </summary>
        /// <returns>Status of Question Title Textbox.</returns>
        public bool IsQuestionTitleTextboxPresent()
        {
            //Verify Question Title Textbox In Edit Window
            Logger.LogMethodEntry("AutoGraderPage", "IsQuestionTitleTextboxPresent",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isQuestionTitleTextboxPresent = false;
            try
            {
                Thread.Sleep(Convert.ToInt32(AutoGraderPageResource.
                        AutoGraderPageResourse_Wait_Time_Value));
                //Wait For Question Title Textbox
                base.WaitForElement(By.Id(AutoGraderPageResource.
                    AutoGraderPageResourse_CreateNewQuestion_TextBox_Id_Locator));
                if (base.IsElementPresent(By.Id(AutoGraderPageResource.
                    AutoGraderPageResourse_CreateNewQuestion_TextBox_Id_Locator),
                    Convert.ToInt32(AutoGraderPageResource.AutoGraderPageResourse_Element_Wait_Time)))
                {
                    isQuestionTitleTextboxPresent = true;
                    base.WaitForElement(By.Id(AutoGraderPageResource.
                        AutoGraderPageResourse_Cancel_Button_Id_Locator));
                    //Click On Cancel Button
                    base.ClickButtonById(AutoGraderPageResource.
                        AutoGraderPageResourse_Cancel_Button_Id_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AutoGraderPage", "IsQuestionTitleTextboxPresent",
               base.IsTakeScreenShotDuringEntryExit);
            return isQuestionTitleTextboxPresent;
        }
        /// <summary>
        /// Create Grader IT Question from  activity authoring.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        /// <param name="questionTypeEnum">This is project Name.</param>
        public void CreateGraderITQuestionFromActivityAuthoring(
            Question.QuestionTypeEnum questionTypeEnum, string projectName)
        {
            //Create Grader IT Question from  activity authoring
            Logger.LogMethodEntry("AutoGraderPage", "CreateGraderITQuestionFromActivityAuthoring",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create New Question Window And Frame
                this.SelectCreateNewQuestionWindowAndFrame();
                //Enter The Grader Question Name
                this.EnterTheGraderQuestionName(questionTypeEnum);
                //Select Project Question From Project Creation Tool
                this.SelectProjectCreationToolWindow();
                //Select The Project 
                this.SelectTheProject(projectName);
                //Select Create New Question Window And Frame
                this.SelectCreateNewQuestionWindowAndFrame();
                //Wait for the Maximum score
                base.WaitForElement(By.Id(AutoGraderPageResource.
                    AutoGraderPageResourse_MaximumScore_TextBox_Id_Locator));
                if (base.IsElementEnabledById(string.Format((AutoGraderPageResource.
                    AutoGraderPageResourse_MaximumScore_TextBox_Id_Locator))))
                {
                    //Fill Score for 2007 type question
                    base.FillTextBoxById(AutoGraderPageResource.
                    AutoGraderPageResourse_MaximumScore_TextBox_Id_Locator,
                    AutoGraderPageResource.AutoGraderPageResourse_MaximumScore_Value);
                }
                //Click On SaveAndClose Button
                this.ClickOnSaveAndCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AutoGraderPage", "CreateGraderITQuestionFromActivityAuthoring",
               base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        ///  Verify the 'Edit Grader Project Instruction' control on the Page.
        /// </summary>
        public bool DisplayEditGraderProjectInstruction()
        {
            Logger.LogMethodEntry("AutoGraderPage", "DisplayEditGraderProjectInstruction",
                base.IsTakeScreenShotDuringEntryExit);
            bool isElementPresent = false;
            try
            {
                //Wait for the Element
                base.WaitForElement(By.Id(AutoGraderPageResource.
                    AutoGraderPageResourse_Edit_Grader_Project_Instruction));
                if (IsElementEnabledById(AutoGraderPageResource.
                    AutoGraderPageResourse_Edit_Grader_Project_Instruction))
                {
                    isElementPresent = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AutoGraderPage", "DisplayEditGraderProjectInstruction",
              base.IsTakeScreenShotDuringEntryExit);
            return isElementPresent;
        }
        /// <summary>
        /// Create The GraderIT Question In Cours-space.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        /// <param name="projectName">This is Project Name.</param>
        public void CreateTheGraderITQuestionInCourseSpace(
            Question.QuestionTypeEnum questionTypeEnum, string projectName)
        {
            //Create The GraderIT Question In CourseSpace
            Logger.LogMethodEntry("AutoGraderPage",
                "CreateTheGraderITQuestionInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Enter The Grader Question Name
                this.EnterTheGraderQuestionName(questionTypeEnum);
                //Select Project Creation Tool Window
                this.SelectProjectCreationToolWindow();
                //Maxmize pop-up window
                base.MaximizeWindow();
                //Select The Project 
                this.SearchTheProject(projectName);
                base.SelectDefaultWindow();
                //Wait for the Maximum score
                base.WaitForElement(By.Id(AutoGraderPageResource.
                    AutoGraderPageResourse_MaximumScore_TextBox_Id_Locator));
                if (base.IsElementEnabledById(string.Format((AutoGraderPageResource.
                    AutoGraderPageResourse_MaximumScore_TextBox_Id_Locator))))
                {
                    //Fill Score for 2007 type question
                    base.FillTextBoxById(AutoGraderPageResource.
                    AutoGraderPageResourse_MaximumScore_TextBox_Id_Locator,
                    AutoGraderPageResource.AutoGraderPageResourse_MaximumScore_Value);
                }
                //Click The Question SaveButton
                this.ClickTheQuestionSaveButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AutoGraderPage",
                "CreateTheGraderITQuestionInCourseSpace",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create The GraderIT Question In Coursespace.
        /// </summary>
        /// <param name="questionTypeEnum">This is Question Type Enum.</param>
        /// <param name="projectName">This is Project Name.</param>
        public void CSTeacherCreateGraderITQuestion(
            Question.QuestionTypeEnum questionTypeEnum, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create The GraderIT Question In CourseSpace
            Logger.LogMethodEntry("AutoGraderPage",
                "CreateTheGraderITQuestionInCourseSpace",
                base.IsTakeScreenShotDuringEntryExit);
            Activity project = Activity.Get(activityTypeEnum);
            string projectName = project.Name.ToString();
            try
            {
                //Enter The Grader Question Name
                this.EnterTheGraderQuestionName(questionTypeEnum);
                //Select Project Creation Tool Window
                this.SelectProjectCreationToolWindow();
                //Maxmize pop-up window
                base.MaximizeWindow();
                //Select The Project 
                this.SearchTheProject(projectName);
                base.SelectDefaultWindow();
                //Click The Question SaveButton
                this.ClickTheQuestionSaveButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AutoGraderPage",
                "CreateTheGraderITQuestionInCourseSpace",
               base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
