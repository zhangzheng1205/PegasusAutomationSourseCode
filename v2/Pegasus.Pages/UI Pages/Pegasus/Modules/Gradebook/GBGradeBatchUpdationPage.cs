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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the view activity grades action.
    /// </summary>
    public class GBGradeBatchUpdationPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(GBGradeBatchUpdationPage));
        
        /// <summary>
        /// Manually Grade the Activity.
        /// </summary>
        public void GradetheActivityInHED()
        {
            //Manually Grade the Activity
            logger.LogMethodEntry("GBGradeBatchUpdationPage", "GradetheActivityInHED",
                                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Edit Grade Window
                this.SelectEditGradeWindow();
                //Input Score For Activity
                this.InputScoreValueForActivity();
                //Click The Edit Save Button
                this.ClickTheEditSaveButton(); 
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBGradeBatchUpdationPage", "GradetheActivityInHED",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Edit Save Button.
        /// </summary>
        private void ClickTheEditSaveButton()
        {
            //Click The Edit Save Button
            logger.LogMethodEntry("GBGradeBatchUpdationPage", "ClickTheEditSaveButton",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GBGradeBatchUpdationPageResource.
                      GBGradeBatchUpdate_Page_Button_Save_Id_Locator));
            IWebElement getSaveButton = base.GetWebElementPropertiesById
                (GBGradeBatchUpdationPageResource.
                GBGradeBatchUpdate_Page_Button_Save_Id_Locator);
            //Click on Save Button
            base.ClickByJavaScriptExecutor(getSaveButton);
            Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
               GBInstructorUX_Page_WaitWindowTime_Value));
            logger.LogMethodExit("GBGradeBatchUpdationPage", "ClickTheEditSaveButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit Grade Window.
        /// </summary>
        private void SelectEditGradeWindow()
        {
            //Select Edit Grade Window
            logger.LogMethodEntry("GBGradeBatchUpdationPage", "SelectEditGradeWindow",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for Edit Grades Window
            base.WaitUntilWindowLoads(GBGradeBatchUpdationPageResource.
                    GBGradeBatchUpdate_Page_EditGrades_Window_Name);
            base.SelectWindow(GBGradeBatchUpdationPageResource.
            GBGradeBatchUpdate_Page_EditGrades_Window_Name);
            logger.LogMethodExit("GBGradeBatchUpdationPage", "SelectEditGradeWindow",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Input Score For Activity.
        /// </summary>
        private void InputScoreValueForActivity()
        {
            //Input Score for Activity
            logger.LogMethodEntry("GBGradeBatchUpdationPage", "InputScoreValueForActivity",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for Score Input TextBox
            base.WaitForElement(By.XPath(GBGradeBatchUpdationPageResource.
                    GBGradeBatchUpdate_Page_Input_Textboxone_Xpath_Locator));
            IWebElement gettextboxproperty = base.GetWebElementPropertiesByXPath(
                GBGradeBatchUpdationPageResource.
                GBGradeBatchUpdate_Page_Input_Textboxone_Xpath_Locator);
            gettextboxproperty.Clear();
            //Fill Score
            gettextboxproperty.SendKeys(GBGradeBatchUpdationPageResource.
                GBGradeBatchUpdate_Page_Score_Input_Value_one);
            base.WaitForElement(By.XPath(GBGradeBatchUpdationPageResource.
                GBGradeBatchUPdate_Page_Input_TextBoxtwo_Xpath_Locator));
            //Get TextBox Property
            IWebElement gettextbox2Property = base.GetWebElementPropertiesByXPath(
                GBGradeBatchUpdationPageResource.
                GBGradeBatchUPdate_Page_Input_TextBoxtwo_Xpath_Locator);
            gettextbox2Property.Clear();
            //Fill Score
            gettextbox2Property.SendKeys(GBGradeBatchUpdationPageResource.
                GBGradeBatchUpdate_Page_Score_Input_Value_two);
            logger.LogMethodExit("GBGradeBatchUpdationPage", "InputScoreValueForActivity",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Grade the Activity In NovaNet.
        /// </summary>
        public void GradetheActivityInNovaNet()
        {
            //Grade the Activity In NovaNet
            logger.LogMethodEntry("GBGradeBatchUpdationPage",
                "GradetheActivityInNovaNet",                
                    base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Edit Grade Window
                this.SelectEditGradeWindow();
                //Input Score For Activity
                this.InputEditScoreValueForActivity();
                //Click The Edit Save Button
                this.ClickTheEditSaveButton();
                //Select GradeBook Window
                base.SelectWindow(GBGradeBatchUpdationPageResource.
                    GBGradeBatchUpdate_Page_Gradebook_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBGradeBatchUpdationPage",
                "GradetheActivityInNovaNet",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Input Edit Score Value For Activity.
        /// </summary>
        private void InputEditScoreValueForActivity()
        {
            //Input Edit Score Value For Activity
            logger.LogMethodEntry("GBGradeBatchUpdationPage", 
                "InputEditScoreValueForActivity",
                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for Score Input TextBox
            base.WaitForElement(By.XPath(GBGradeBatchUpdationPageResource.
                    GBGradeBatchUpdate_Page_Input_Textboxone_Xpath_Locator));
            IWebElement gettextboxproperty = base.GetWebElementPropertiesByXPath(
                GBGradeBatchUpdationPageResource.
                GBGradeBatchUpdate_Page_Input_Textboxone_Xpath_Locator);
            gettextboxproperty.Clear();
            //Fill Score
            gettextboxproperty.SendKeys(GBGradeBatchUpdationPageResource.
                GBGradeBatchUpdate_Page_Score_EditInput_Value_First);
            base.WaitForElement(By.XPath(GBGradeBatchUpdationPageResource.
                GBGradeBatchUPdate_Page_Input_TextBoxtwo_Xpath_Locator));
            //Get TextBox Property
            IWebElement gettextbox2Property = base.GetWebElementPropertiesByXPath(
                GBGradeBatchUpdationPageResource.
                GBGradeBatchUPdate_Page_Input_TextBoxtwo_Xpath_Locator);
            gettextbox2Property.Clear();
            //Fill Score
            gettextbox2Property.SendKeys(GBGradeBatchUpdationPageResource.
                GBGradeBatchUpdate_Page_Score_EditInput_Value_Second);
            logger.LogMethodExit("GBGradeBatchUpdationPage", 
                "InputEditScoreValueForActivity",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit Grade.
        /// </summary>
        /// <param name="scoreValue">This is Score Value.</param>
        public void EditGrade(string userScore, string maximumScore)
        {
            //Grade the Activity In NovaNet
            logger.LogMethodEntry("GBGradeBatchUpdationPage", "EditGrade",
                    base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Edit Grade Window
                this.SelectEditGradeWindow();
                base.ClearTextByXPath(GBGradeBatchUpdationPageResource.
                    GBGradeBatchUpdate_Page_UserScore_Text_Xpath_Locator);
                //Enter User Score
                base.FillTextBoxByXPath(GBGradeBatchUpdationPageResource.
                    GBGradeBatchUpdate_Page_UserScore_Text_Xpath_Locator, userScore);
                base.ClearTextByXPath(GBGradeBatchUpdationPageResource.
                    GBGradeBatchUpdate_Page_MaximumScore_Text_Xpath_Locator);
                //Enter Maximum Score
                base.FillTextBoxByXPath(GBGradeBatchUpdationPageResource.
                    GBGradeBatchUpdate_Page_MaximumScore_Text_Xpath_Locator, maximumScore);
                //Select Save Button
                IWebElement getSaveButton = base.GetWebElementPropertiesById(
                    GBGradeBatchUpdationPageResource.
                    GBGradeBatchUpdate_Page_Button_Save_Id_Locator);
                base.ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBGradeBatchUpdationPage", "EditGrade",
                   base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
