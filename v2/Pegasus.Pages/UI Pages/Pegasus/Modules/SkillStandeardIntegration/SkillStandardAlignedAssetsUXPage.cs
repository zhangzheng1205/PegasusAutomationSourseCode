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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SkillStandeardIntegration;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Skill study plan Page actions
    /// </summary>
    public class SkillStandardAlignedAssetsUXPage:BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(SkillStandardAlignedAssetsUXPage));

        /// <summary>
        /// Select Questions From SkillFrame.
        /// </summary>
        public void SelectQuestionsFromSkillFrame()
        {
            // Select Questions From SkillFrame
            logger.LogMethodEntry("SkillStandardAlignedAssetsUXPage", "SelectQuestionsFromSkillFrame",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {   
                //Select Window and Frame
                this.SelectQuestionFrame();
                base.WaitForElement(By.XPath(SkillStandardAlignedAssetsUXResource.
                    SkillStandardAlignedAssetsUX_Page_Select_Skill_Frame_Xpath_Locator));
                //Get web element
                IWebElement getSkillFrameLink = base.GetWebElementPropertiesByXPath
                    (SkillStandardAlignedAssetsUXResource.
                    SkillStandardAlignedAssetsUX_Page_Select_Skill_Frame_Xpath_Locator);
                //Click on the skill frame
                base.ClickByJavaScriptExecutor(getSkillFrameLink); 
                //Select the question frame
                this.SelectQuestionFrame();
                //Select Question Checkbox
                this.SelectQuestionCheckbox();
                base.SelectWindow(SkillStandardAlignedAssetsUXResource.
                   SkillStandardAlignedAssetsUX_Page_SelectQuestion_Window_Name);
                //Click On Save Button In Select Question Popup
                this.ClickOnSaveButtonInSelectQuestionPopup();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }         
            logger.LogMethodExit("SkillStandardAlignedAssetsUXPage", "SelectQuestionsFromSkillFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question Checkbox.
        /// </summary>
        public void SelectQuestionCheckbox()
        {
            // Select Question Checkbox
            logger.LogMethodEntry("SkillStandardAlignedAssetsUXPage", "SelectQuestionCheckbox",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath(SkillStandardAlignedAssetsUXResource.
                        SkillStandardAlignedAssetsUX_Page_Select_Checkbox_Question_Xpath_Locator));
                //Get web element
                IWebElement getSelectQuestion = GetWebElementPropertiesByXPath
                    (SkillStandardAlignedAssetsUXResource.
                    SkillStandardAlignedAssetsUX_Page_Select_Checkbox_Question_Xpath_Locator);
                //Click check box of questions
                base.ClickByJavaScriptExecutor(getSelectQuestion);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillStandardAlignedAssetsUXPage", "SelectQuestionCheckbox",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save Button In Select Question Popup
        /// </summary>
        private void ClickOnSaveButtonInSelectQuestionPopup()
        {
            // Select Questions Frame
            logger.LogMethodEntry("SkillStandardAlignedAssetsUXPage",
                "ClickOnSaveButtonInSelectQuestionPopup",
                 base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_SelectQues_SaveClose_Button_Id_Locator));
            IWebElement getCloseSelectQuestionButton = base.GetWebElementPropertiesById
                (SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_SelectQues_SaveClose_Button_Id_Locator);
            //Click on the save button
            base.ClickByJavaScriptExecutor(getCloseSelectQuestionButton);
            //Select the window
            base.WaitUntilWindowLoads(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_CreateSkillStudyPlan_Window_Name);
            base.SelectWindow(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_CreateSkillStudyPlan_Window_Name);
            logger.LogMethodExit("SkillStandardAlignedAssetsUXPage", 
                "ClickOnSaveButtonInSelectQuestionPopup",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Questions Frame.
        /// </summary>
        public void SelectQuestionFrame()
        {
            // Select Questions Frame
            logger.LogMethodEntry("SkillStandardAlignedAssetsUXPage", "SelectQuestionFrame",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(SkillStandardAlignedAssetsUXResource.
                    SkillStandardAlignedAssetsUX_Page_SelectQuestion_Window_Name);
                base.SelectWindow(SkillStandardAlignedAssetsUXResource.
                    SkillStandardAlignedAssetsUX_Page_SelectQuestion_Window_Name);
                //select the frame
                base.SwitchToIFrame(SkillStandardAlignedAssetsUXResource.
                    SkillStandardAlignedAssetsUX_Page_SelectQuestion_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }    
            logger.LogMethodExit("SkillStandardAlignedAssetsUXPage", "SelectQuestionFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Map Question To The Skill.
        /// </summary>
        /// <param name="questionName">This is Question Name.</param>
        public void MapQuestionToTheSkill(string questionName)
        { 
            // Map Question To The Skill
            logger.LogMethodEntry("SkillStandardAlignedAssetsUXPage", "MapQuestionToTheSkill",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Navigate Inside Skill In Skill Frame
                this.NavigateInsideSkill();
                //Select Question In Question Bank
                this.SelectQuestionInQuestionBank(questionName);
                //Click on Add Button
                this.ClickonAddButton();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillStandardAlignedAssetsUXPage", "MapQuestionToTheSkill",
                base.isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Navigate Inside Skill.
        /// </summary>
        private void NavigateInsideSkill()
        {
            //Navigate Inside Skill
            logger.LogMethodEntry("SkillStandardAlignedAssetsUXPage", "NavigateInsideSkill",
                 base.isTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectAlignContentToSkilllWindow();
            base.WaitForElement(By.Id(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_QuestionBank_Frame_Id_Locator));
            //select the frame
            base.SwitchToIFrame(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_QuestionBank_Frame_Id_Locator);
            base.WaitForElement(By.XPath(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_SkillFramework_Xpath_Locator));
            //Select Skill Framework
            IWebElement getSkillFramework =
                base.GetWebElementPropertiesByXPath(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_SkillFramework_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getSkillFramework);
            //Select Window
            this.SelectAlignContentToSkilllWindow();
            base.WaitForElement(By.Id(SkillStandardAlignedAssetsUXResource.
               SkillStandardAlignedAssetsUX_Page_QuestionBank_Frame_Id_Locator));
            //select the frame
            base.SwitchToIFrame(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_QuestionBank_Frame_Id_Locator);
            base.WaitForElement(By.XPath(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_Skill_Xpath_Locator));
            //Select the Skill
            IWebElement getSkillProperty =
                base.GetWebElementPropertiesByXPath(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_Skill_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getSkillProperty);
            logger.LogMethodExit("SkillStandardAlignedAssetsUXPage", "NavigateInsideSkill",
                base.isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Click on Add Button.
        /// </summary>
        private void ClickonAddButton()
        {
            //Click on Add Button
            logger.LogMethodEntry("SkillStandardAlignedAssetsUXPage", "ClickonAddButton",
                 base.isTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectAlignContentToSkilllWindow();
            base.WaitForElement(By.Id(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_Add_Button_Id_Locator));
            //Click on Add Button
            IWebElement getAddButtonProperty =
                base.GetWebElementPropertiesById(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_Add_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(getAddButtonProperty);
            logger.LogMethodExit("SkillStandardAlignedAssetsUXPage", "ClickonAddButton",
                base.isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Select Question In Question Bank.
        /// </summary>
        /// <param name="questionName">This is Question Name.</param>
        private void SelectQuestionInQuestionBank(string questionName)
        {
            //Select Question In Question Bank
            logger.LogMethodEntry("SkillStandardAlignedAssetsUXPage", "SelectQuestionInQuestionBank",
                 base.isTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectAlignContentToSkilllWindow();
            base.WaitForElement(By.Id(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_Skill_Frame_Id_Locator));
            //select the frame
            base.SwitchToIFrame(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_Skill_Frame_Id_Locator);
            base.WaitForElement(By.XPath(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_QuestionCount_Xpath_Locator));
            //Get Question Count
            int getQuestionCount = base.GetElementCountByXPath(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_QuestionCount_Xpath_Locator);
            for (int i = Convert.ToInt32(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_Loop_Initializer_Value);
                i <= getQuestionCount; i++)
            {
                base.WaitForElement(By.XPath(string.Format(SkillStandardAlignedAssetsUXResource.
                    SkillStandardAlignedAssetsUX_Page_QuestionName_Xpath_Locator, i)));
                //Get Question Name
                string getQuestionName = 
                    base.GetElementTextByXPath(string.Format(SkillStandardAlignedAssetsUXResource.
                    SkillStandardAlignedAssetsUX_Page_QuestionName_Xpath_Locator, i));
                string getActualQuestionName = getQuestionName.Replace(
                    "\r\n",
                    string.Empty).Trim();
                if (getActualQuestionName.Contains(questionName))
                {
                    base.WaitForElement(By.XPath(string.Format(
                        SkillStandardAlignedAssetsUXResource.
                        SkillStandardAlignedAssetsUX_Page_QuestionCheckbox_Xpath_Locator, i)));
                    IWebElement getSelector=base.GetWebElementPropertiesByXPath
                        (string.Format(SkillStandardAlignedAssetsUXResource.
                        SkillStandardAlignedAssetsUX_Page_QuestionCheckbox_Xpath_Locator, i));
                    //Select Question Checkbox
                    base.ClickByJavaScriptExecutor(getSelector);
                }
            }
            logger.LogMethodExit("SkillStandardAlignedAssetsUXPage", "SelectQuestionInQuestionBank",
                base.isTakeScreenShotDuringEntryExit); 
        }

        private void SelectAlignContentToSkilllWindow()
        {
            logger.LogMethodEntry("SkillStandardAlignedAssetsUXPage",
                "SelectAlignContentToSkilllWindow",
                 base.isTakeScreenShotDuringEntryExit);
            //Select the window
            base.WaitUntilWindowLoads(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_Window_Name);
            //Select Window
            base.SelectWindow(SkillStandardAlignedAssetsUXResource.
                SkillStandardAlignedAssetsUX_Page_Window_Name);
            logger.LogMethodExit("SkillStandardAlignedAssetsUXPage",
                "SelectAlignContentToSkilllWindow",
               base.isTakeScreenShotDuringEntryExit); 
        }
    }
}
