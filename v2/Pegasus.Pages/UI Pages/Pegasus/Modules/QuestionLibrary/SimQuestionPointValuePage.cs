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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.QuestionLibrary;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles SimQuestionPointValue Page actions
    /// </summary>
    public class SimQuestionPointValuePage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(SimQuestionPointValuePage));

        /// <summary>
        /// Set Point Value For Question.
        /// </summary>
        /// <param name="pointValue">This is Point Value.</param>  
        public void SetPointValueForQuestion(string pointValue)
        {
            //Set Point Value For Question
            Logger.LogMethodEntry("SimQuestionPointValuePage",
                "SetPointValueForQuestion",base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select 'Set Point Value' Window
                this.SelectSetPointValueWindow();
                base.WaitForElement(By.Id(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_Score_Textbox_Id_Locator));
                //Clear Score Textbox
                base.ClearTextByID(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_Score_Textbox_Id_Locator);
                //Enter Score
                base.FillTextBoxByID(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_Score_Textbox_Id_Locator,
                    pointValue.ToString());
                base.WaitForElement(By.Id(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_SaveAndClose_Button_Id_Locator));
                //Get 'Save and Close' Button Property
                IWebElement getSaveAndCloseButton =
                    base.GetWebElementPropertiesById(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_SaveAndClose_Button_Id_Locator);
                //Click On 'Save and Close' Button
                base.ClickByJavaScriptExecutor(getSaveAndCloseButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SimQuestionPointValuePage",
                "SetPointValueForQuestion",base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Set Point Value' Window.
        /// </summary>
        private void SelectSetPointValueWindow()
        {
            //Select 'Set Point Value' Window
            Logger.LogMethodEntry("SimQuestionPointValuePage",
                "SelectSetPointValueWindow", base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(SimQuestionPointValuePageResource.
                SimQuestionPointValue_Page_Resource_SetPointValue_Window);
            //Select Window
            base.SelectWindow(SimQuestionPointValuePageResource.
                SimQuestionPointValue_Page_Resource_SetPointValue_Window);
            Logger.LogMethodExit("SimQuestionPointValuePage",
                "SelectSetPointValueWindow", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Question Point Value.
        /// </summary>
        /// <param name="questionName">This is Question Name.</param>
        /// <returns>Question Point Value.</returns>
        public string GetQuestionPointValue(string questionName)
        {
            //Set Point Value For Question
            Logger.LogMethodEntry("SimQuestionPointValuePage",
                "SetPointValueForQuestion", base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getPointValue = string.Empty;
            try
            {
                //Select 'Question Bank' Window
                this.SelectQuestionBankWindow();
                base.WaitForElement(By.Id(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_QuestionLibrary_Frame_Id_Locator));
                //Switch to 'Question Library' Frame
                base.SwitchToIFrameById(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_QuestionLibrary_Frame_Id_Locator);
                //Click On Searched Course
                this.ClickOnSearchedQuestion();
                //Select 'Question Bank' Window
                this.SelectQuestionBankWindow();
                base.WaitForElement(By.Id(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_Preview_Frame_Id_Locator));
                //Switch to Preview Frame
                base.SwitchToIFrameById(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_Preview_Frame_Id_Locator);
                base.WaitForElement(By.Id(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_PointValue_Id_Locator));
                //Get Point Value
                getPointValue = base.GetElementTextByID(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_PointValue_Id_Locator).Substring(
                    Convert.ToInt32(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_Substring_Initial_Value),
                    Convert.ToInt32(SimQuestionPointValuePageResource.
                    SimQuestionPointValue_Page_Resource_Substring_Final_Value));               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SimQuestionPointValuePage",
                "SetPointValueForQuestion", base.isTakeScreenShotDuringEntryExit);
            return getPointValue;
        }

        /// <summary>
        /// Click On Searched Question.
        /// </summary>
        private void ClickOnSearchedQuestion()
        {
            //Click On Searched Question
            Logger.LogMethodEntry("SimQuestionPointValuePage",
               "ClickOnSearchedQuestion", base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(SimQuestionPointValuePageResource.
                SimQuestionPointValue_Page_Resource_SearchedQuestion_Xpath_Locator));
            //Get Searched Question Property
            IWebElement getQuestionName =
                base.GetWebElementPropertiesByXPath(SimQuestionPointValuePageResource.
                SimQuestionPointValue_Page_Resource_SearchedQuestion_Xpath_Locator);
            //Click On Searched Question
            base.ClickByJavaScriptExecutor(getQuestionName);
            Logger.LogMethodExit("SimQuestionPointValuePage",
                "ClickOnSearchedQuestion", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question Bank Window.
        /// </summary>
        private void SelectQuestionBankWindow()
        {
            //Select Question Bank Window
            Logger.LogMethodEntry("SimQuestionPointValuePage",
              "SelectQuestionBankWindow", base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(SimQuestionPointValuePageResource.
                SimQuestionPointValue_Page_Resource_QuestionBank_Window);
            //Select Window
            base.SelectWindow(SimQuestionPointValuePageResource.
                SimQuestionPointValue_Page_Resource_QuestionBank_Window);
            Logger.LogMethodExit("SimQuestionPointValuePage",
                "SelectQuestionBankWindow", base.isTakeScreenShotDuringEntryExit);
        }
    }
}
