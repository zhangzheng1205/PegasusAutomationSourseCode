using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Select the Question Type
    /// </summary>
   public class SelectQuestionTypePage:BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
       private static Logger logger = Logger.GetInstance(typeof(SelectQuestionTypePage));

       /// <summary>
       /// Click the question type.
       /// </summary>
       public void ClickTheQuestionType()
       {
           //Click the question type
           logger.LogMethodEntry("SelectQuestionTypePage", "ClickTheQuestionType",
                  base.isTakeScreenShotDuringEntryExit);
           try
           {
               //Select Create New Question Window
               this.SelectCreateNewQuestionWindow();              
               base.WaitForElement(By.Id(SelectQuestionTypePageResource.
                 SelectQuestionType_Page_QuestionWindow_SelectQuesType_Title_ID_Locator));
               //Get web element
               IWebElement getTruefalsePropertyLink = base.GetWebElementPropertiesByXPath
                     (SelectQuestionTypePageResource.
                   SelectQuestionType_Page_QuestionType_TF_Title_Xpath_Locator);               
               //Click the "True/False" link
               base.ClickByJavaScriptExecutor(getTruefalsePropertyLink);
           }
           catch (Exception e)
           {
               ExceptionHandler.HandleException(e);
           }
           logger.LogMethodExit("SelectQuestionTypePage", "ClickTheQuestionType",
                base.isTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Click The Essay QuestionType.
       /// </summary>
       public void ClickTheEssayQuestionType()
       {
           // Click The Essay QuestionType
           logger.LogMethodEntry("SelectQuestionTypePage", "ClickTheEssayQuestionType",
                  base.isTakeScreenShotDuringEntryExit);
           try
           {
               //Select Create New Question Window
               this.SelectCreateNewQuestionWindow();
               base.WaitForElement(By.Id(SelectQuestionTypePageResource.
                 SelectQuestionType_Page_QuestionWindow_SelectQuesType_Title_ID_Locator));
               //Get web element
               IWebElement getEssayPropertyLink = base.GetWebElementPropertiesByXPath
                     (SelectQuestionTypePageResource.
                   SelectQuestionType_Page_QuestionType_Essay_Title_Xpath_Locator);
               //Click the "Essay" link
               base.ClickByJavaScriptExecutor(getEssayPropertyLink);
           }
           catch (Exception e)
           {
               ExceptionHandler.HandleException(e);
           }
           logger.LogMethodExit("SelectQuestionTypePage", "ClickTheEssayQuestionType",
                base.isTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Select Create New Question Window.
       /// </summary>
       public void SelectCreateNewQuestionWindow()
       {
           //Select Create New Question Window
           logger.LogMethodEntry("SelectQuestionTypePage", "SelectCreateNewQuestionWindow",
                  base.isTakeScreenShotDuringEntryExit);
           try
           {
               //Select the window  
               base.WaitUntilWindowLoads(SelectQuestionTypePageResource.
                   SelectQuestionType_Page_CreateNewQues_Window_Name);
               base.SelectWindow(SelectQuestionTypePageResource.
                   SelectQuestionType_Page_CreateNewQues_Window_Name);
               //Select the frame
               base.SwitchToIFrame(SelectQuestionTypePageResource.
                   SelectQuestionType_Page_Question_Frame_ID_Locator);
           }
           catch (Exception e)
           {
              ExceptionHandler.HandleException(e);
           }
           logger.LogMethodExit("SelectQuestionTypePage", "SelectCreateNewQuestionWindow",
                base.isTakeScreenShotDuringEntryExit);
       }
       /// <summary>
       /// Click The True-False QuestionType.
       /// </summary>
       public void ClickTheTrueFalseQuestionType()
       {
           // Click The Essay QuestionType
           logger.LogMethodEntry("SelectQuestionTypePage", "ClickTheTrueFalseQuestionType",
                  base.isTakeScreenShotDuringEntryExit);
           try
           {
               //Select Create New Question Window
               this.SelectCreateNewQuestionWindow();
               base.WaitForElement(By.Id(SelectQuestionTypePageResource.
                 SelectQuestionType_Page_QuestionWindow_SelectQuesType_Title_ID_Locator));
               //Get web element
               IWebElement getEssayPropertyLink = base.GetWebElementPropertiesByXPath
                     (SelectQuestionTypePageResource.
                   SelectQuestionType_Page_QuestionType_TF_Title_Xpath_Locator);
               //Click the "Essay" link
               base.ClickByJavaScriptExecutor(getEssayPropertyLink);
           }
           catch (Exception e)
           {
               ExceptionHandler.HandleException(e);
           }
           logger.LogMethodExit("SelectQuestionTypePage", "ClickTheTrueFalseQuestionType",
                base.isTakeScreenShotDuringEntryExit);
       }
    }
}
