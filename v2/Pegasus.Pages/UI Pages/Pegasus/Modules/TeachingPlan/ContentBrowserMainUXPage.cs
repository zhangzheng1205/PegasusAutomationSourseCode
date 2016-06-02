﻿using System;
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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Contetn Browser Main UX Page actions
    /// </summary>
    public class ContentBrowserMainUXPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ContentBrowserMainUXPage));


        /// <summary>
        /// Click on Add and Close Button.
        /// </summary>
        public void ClickOnAddAndCloseButton()
        {
            //Logger entry
            logger.LogMethodEntry("ContentBrowserMainUXPage",
                "ClickOnAddAndCloseButton",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for element
                base.WaitForElement(By.Id(ContentBrowserMainUXPageResource.
                    ContentBrowserMainUX_Page_AddandClose_Id_Locator));
                //Get Html element
                IWebElement getPropertyofSaveandCloseButton = base.
                    GetWebElementPropertiesById(ContentBrowserMainUXPageResource.
                    ContentBrowserMainUX_Page_AddandClose_Id_Locator);
                //Click on button
                base.ClickByJavaScriptExecutor(getPropertyofSaveandCloseButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("ContentBrowserMainUXPage",
                "ClickOnAddAndCloseButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Save Copy To
        /// </summary>
        public void SelectSaveCopyToWindow()
        {
            //Click On 'Add And Close' Button
            logger.LogMethodEntry("ContentBrowserMainUXPage", "SelectSaveCopyToWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the 'Save copy to' window
                base.WaitUntilWindowLoads(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Savecopyto_Window_Title_Name);
                base.SelectWindow(ContentBrowserUXPageResource.
                    ContentBrowserUX_Page_Savecopyto_Window_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentBrowserMainUXPage", "SelectSaveCopyToWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select Question.
        /// </summary>
        public void SelectQuestion()
        {
            //Select Question
            logger.LogMethodEntry("ContentBrowserMainUXPage", "SelectQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Question From Memory
            Question question = Question.Get(Question.QuestionTypeEnum.TrueFalse);
            try
            {
                //Select Question From Bank Option
                new RandomTopicListPage().SelectQuestionFromBankForBasicRandom();
                //Select Question Window
                this.SelectQuestionWindow();
                //Select Question From Question Window
                this.SelectTheQuestion(question);
                //Select Question Window
                this.SelectQuestionWindow();
                //Click On Add And Close Button
                this.ClickOnAddAndCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentBrowserMainUXPage", "SelectQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Question.
        /// </summary>
        /// <param name="question">This is Question GUID.</param>
        private void SelectTheQuestion(Question question)
        {
            //Select The Question
            logger.LogMethodEntry("ContentBrowserMainUXPage", "SelectTheQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ContentBrowserMainUXPageResource.
                ContentBrowserMainUX_Page_QuestionWindow_Frame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(ContentBrowserMainUXPageResource.
                ContentBrowserMainUX_Page_QuestionWindow_Frame_Id_Locator);
            base.WaitForElement(By.XPath(ContentBrowserMainUXPageResource.
                ContentBrowserMainUX_Page_QuestionCount_Xpath_Locator));
            //Get Question Count
            int getQuestionCount = base.GetElementCountByXPath(
                ContentBrowserMainUXPageResource.
                ContentBrowserMainUX_Page_QuestionCount_Xpath_Locator);
            for (int i = Convert.ToInt32(ContentBrowserMainUXPageResource.
                ContentBrowserMainUX_Page_Loop_Count); i <= getQuestionCount; i++)
            {
                base.WaitForElement(By.XPath(string.Format(
                    ContentBrowserMainUXPageResource.
                    ContentBrowserMainUX_Page_QuestionName_Xpath_Locator, i)));
                //Get Question Name
                string getQuestionName = base.GetElementTextByXPath(string.Format(
                     ContentBrowserMainUXPageResource.
                    ContentBrowserMainUX_Page_QuestionName_Xpath_Locator, i));
                if (getQuestionName == question.Name)
                {
                    base.WaitForElement(By.XPath(string.Format(
                        ContentBrowserMainUXPageResource.
                        ContentBrowserMainUX_Page_QuestionCheckbox_Xpath_Locator, i)));
                    //Select Question
                    base.SelectCheckBoxByXPath(string.Format(ContentBrowserMainUXPageResource.
                        ContentBrowserMainUX_Page_QuestionCheckbox_Xpath_Locator, i));
                    break;
                }
            }
            logger.LogMethodExit("ContentBrowserMainUXPage", "SelectTheQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question Window.
        /// </summary>
        private void SelectQuestionWindow()
        {
            //Select Question Window
            logger.LogMethodEntry("ContentBrowserMainUXPage", "SelectQuestionWindow",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Question Window
            base.WaitUntilWindowLoads(ContentBrowserMainUXPageResource.
                ContentBrowserMainUX_Page_QuestionWindow);
            base.SelectWindow(ContentBrowserMainUXPageResource.
                ContentBrowserMainUX_Page_QuestionWindow);
            logger.LogMethodExit("ContentBrowserMainUXPage", "SelectQuestionWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select a question from question bank.
        /// </summary>
        public void SelectAQuestionFromQuestionBank()
        {
            logger.LogMethodEntry("ContentBrowserMainUXPage", "SelectAQuestionFromQuestionBank",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Current window
                this.SelectQuestionWindow();
                base.WaitForElement(By.Id(ContentBrowserMainUXPageResource.
                   ContentBrowserMainUX_Page_QuestionWindow_Frame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(ContentBrowserMainUXPageResource.
                    ContentBrowserMainUX_Page_QuestionWindow_Frame_Id_Locator);
                //Navigate into the folders until the page list a Question
                bool questionPresent = base.IsElementPresent(By.ClassName("cssQuestionSImg"), 5);
                while (!questionPresent)
                {
                    bool pres = base.IsElementPresent(By.CssSelector("img[style*=folder_16]"), 10);
                    IWebElement questionFolder = base.GetWebElementPropertiesByCssSelector("img[style*=folder_16]");
                    base.ClickByJavaScriptExecutor(questionFolder);
                    questionPresent = base.IsElementPresent(By.ClassName("cssQuestionSImg"), 5);

                }
                //Check on Question's Check box 
                IWebElement questionCheckbox = base.GetWebElementPropertiesById("grdContentBrowser$_ctrl1");
                base.ClickByJavaScriptExecutor(questionCheckbox);
                base.SwitchToDefaultPageContent();
                //Close the window after selection
                this.ClickOnAddAndCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentBrowserMainUXPage", "SelectAQuestionFromQuestionBank",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Questions from Question Group.
        /// </summary>
        /// <param name="questionGroupName">This the question group name</param>
        public void SelectAQuestionGroup(string questionGroupName)
        {
            logger.LogMethodEntry("ContentBrowserMainUXPage", "SelectAQuestionGroup",
            base.IsTakeScreenShotDuringEntryExit);
            //Select the Current window
            try
            {
                this.SelectQuestionWindow();
                base.WaitForElement(By.Id(ContentBrowserMainUXPageResource.
                  ContentBrowserMainUX_Page_QuestionWindow_Frame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(ContentBrowserMainUXPageResource.
                    ContentBrowserMainUX_Page_QuestionWindow_Frame_Id_Locator);
                //Search for Question Group listed and check the relevant checkbox
                base.WaitForElement(By.Id("grdContentBrowser$_ctrl1"), 10);
                int questionGroupCount = base.GetElementCountByCssSelector("input[id='grdContentBrowser$_ctrl1']");
                for (int i = 1; i <= questionGroupCount; i++)
                {
                    IWebElement checkBoxElement = base.GetWebElementPropertiesByCssSelector(
                        string.Format("input[id='grdContentBrowser$_ctrl1']:nth-of-type({0})", i));
                    string checkBoxValue = checkBoxElement.GetAttribute("value");
                    string folderId = "tblID_" + checkBoxValue;
                    string folderName = base.GetElementInnerTextByCssSelector(string.Format
                        ("table[id='{0}'] > tbody > tr > td:nth-of-type(2) > a", folderId));
                    //select the group folder on match
                    if (folderName == questionGroupName)
                    {
                        base.ClickByJavaScriptExecutor(checkBoxElement);
                        break;
                    }
                }
                base.SwitchToDefaultPageContent();
                //Close the window after selection
                this.ClickOnAddAndCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
             logger.LogMethodExit("ContentBrowserMainUXPage", "SelectAQuestionGroup",
             base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
