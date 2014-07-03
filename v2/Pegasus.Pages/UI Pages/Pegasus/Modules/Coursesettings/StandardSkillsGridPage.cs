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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  This class handles Pegasus StandardSkillsGrid Page Actions
    /// </summary>
    public class StandardSkillsGridPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(StandardSkillsGridPage));

        /// <summary>
        /// Get The Skill Name If Added Earlier
        /// </summary>
        /// <returns>The Skill Name</returns>
        public String GetSkillNameIsDisplayed(string skillFrameName)
        {
            //Get The Skill Name If Added Earlier
            logger.LogMethodEntry("StandardSkillsGridPage",
              "GetSkillNameIsDisplayed", base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSkillName = string.Empty;
            try
            {
                //Get The Number Of Skills Added
                int getRowCount = base.GetElementCountByXPath(
                        StandardSkillsGridPageResource.
                        StandardSkillGrid_Page_RowCount_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(StandardSkillsGridPageResource.
                    StandardSkillGrid_Page_StartingRowNumber_Value);
                    rowCount <= getRowCount; rowCount++)
                {
                    //Get The Name Of The Skill Present
                    getSkillName = base.GetElementTextByXPath(
                       string.Format(StandardSkillsGridPageResource.
                       StandardSkillGrid_Page_SkillName_Xpath_Locator, rowCount));
                    if (getSkillName == StandardSkillsGridPageResource.
                        StandardSkillGrid_Page_SkillToSelect_Value)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StandardSkillsGridPage",
              "GetSkillNameIsDisplayed", base.isTakeScreenShotDuringEntryExit);
            return getSkillName;
        }

        /// <summary>
        /// Get The Row Cont Of The Skill Standard Frame.
        /// </summary>
        /// <returns>The Row Number.</returns>
        public int GetRowCountOfSkillStandardFrame(string skillFrameName)
        {
            //Get The Row Cont Of The Skill Standard Frame
            logger.LogMethodEntry("StandardSkillsGridPage",
              "GetRowCountOfSkillStandardFrame", base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSkillName = string.Empty;
            int rowCount = int.MinValue;
            try
            {
                //Get The Number Of Skills/Standard Framework Added
                int getRowCount = base.GetElementCountByXPath(StandardSkillsGridPageResource.
                    StandardSkillGrid_Page_RowCount_Xpath_Locator);
                for (rowCount = Convert.ToInt32(StandardSkillsGridPageResource.
                    StandardSkillGrid_Page_StartingRowNumberInPopup_Value);
                    rowCount <= getRowCount; rowCount++)
                {
                    //Get The Name Of The Skill Present
                    getSkillName = base.GetElementTextByXPath
                       (string.Format(StandardSkillsGridPageResource.
                       StandardSkillGrid_Page_SkillName_Xpath_Locator, rowCount));
                    if (getSkillName.Contains(skillFrameName))
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StandardSkillsGridPage",
              "GetRowCountOfSkillStandardFrame", base.isTakeScreenShotDuringEntryExit);
            return rowCount;
        }

        /// <summary>
        /// Select Skill Framework.
        /// </summary>
        /// <param name="skillFrameName">This is Seelect The Framework.</param>
        public void SelectSkillFramework(string skillFrameName)
        {
            //Select Skill Framework
            logger.LogMethodEntry("StandardSkillsGridPage",
             "SelectSkillFramework", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Skill Framework Window
                this.SelectSkillStandardFrameWorkWindow(StandardSkillsGridPageResource.
                StandardSkillGrid_Page_SkillFramework_PopupName);
                //Seach The Frame
                this.SearchTheFrame(skillFrameName);                
                //Get the total count            
                int getRowNumber = this.GetRowCountOfSkillStandardFrame(skillFrameName);
                //Select Framework CheckBox
                this.SelectFrameworkCheckBox(getRowNumber);
                //Click The SaveClose Button
                this.ClickTheSaveCloseButton(); 
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StandardSkillsGridPage",
            "SelectSkillFramework", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Seach The Frame.
        /// </summary>
        /// <param name="skillFrameName">This is Frame Name.</param>
        private void SearchTheFrame(string skillFrameName)
        {
            //Click The SaveClose Button
            logger.LogMethodEntry("StandardSkillsGridPage",
             "SearchTheFrame", base.isTakeScreenShotDuringEntryExit);
            //Wait For The Skill Framework Name Textbox
            base.WaitForElement(By.Id(StandardSkillsGridPageResource.
                StandardSkillGrid_Page_SkillFrameworkName_Input_Id_Locator),
                Convert.ToInt32(StandardSkillsGridPageResource.
                StandardSkillGrid_Page_TimeToWait_Value));
            //Enter Skill Name Need To Be Added
            base.FillTextBoxByID(StandardSkillsGridPageResource.
                StandardSkillGrid_Page_SkillFrameworkName_Input_Id_Locator,
                skillFrameName);
            IWebElement getViewButton = base.GetWebElementPropertiesById
                (StandardSkillsGridPageResource.
                StandardSkillGrid_Page_View_Link_Id_Locator);
            //Click On View Button
            base.ClickByJavaScriptExecutor(getViewButton);
            Thread.Sleep(Convert.ToInt32(StandardSkillsGridPageResource.
                StandardSkillGrid_Page_SleepTime));
            logger.LogMethodExit("StandardSkillsGridPage",
            "SearchTheFrame", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The SaveClose Button.
        /// </summary>
        private void ClickTheSaveCloseButton()
        {
            //Click The SaveClose Button
            logger.LogMethodEntry("StandardSkillsGridPage",
             "ClickTheSaveCloseButton", base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(StandardSkillsGridPageResource.
                StandardSkillGrid_Page_SaveAndClose_Link_Id_Locator));
            //Click On Save And Close Button
            IWebElement getSaveCloseButton = base.GetWebElementPropertiesById
                (StandardSkillsGridPageResource.
                StandardSkillGrid_Page_SaveAndClose_Link_Id_Locator);
            base.ClickByJavaScriptExecutor(getSaveCloseButton);
            Thread.Sleep(Convert.ToInt32(StandardSkillsGridPageResource.
                StandardSkillGrid_Page_SleepTime));
            logger.LogMethodExit("StandardSkillsGridPage",
            "ClickTheSaveCloseButton", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Framework CheckBox.
        /// </summary>
        /// <param name="getRowNumber">This is Row Count Of Framework.</param>
        private void SelectFrameworkCheckBox(int getRowNumber)
        {
            //Select Framework CheckBox
            logger.LogMethodEntry("StandardSkillsGridPage",
             "SelectFrameworkCheckBox", base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(string.Format(StandardSkillsGridPageResource.
                StandardSkillGrid_Page_SkillCheckbox_Xpath_Locator, getRowNumber)));
            IWebElement getChekox = base.GetWebElementPropertiesByXPath
                (string.Format(StandardSkillsGridPageResource.
                StandardSkillGrid_Page_SkillCheckbox_Xpath_Locator, getRowNumber));
            base.ClickByJavaScriptExecutor(getChekox);
            logger.LogMethodExit("StandardSkillsGridPage",
            "SelectFrameworkCheckBox", base.isTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Select Standard Framework.
        /// </summary>
        /// <param name="StandardFrameName">This is Standard FrameWork Name.</param>
        public void SelectStandardFramework(string StandardFrameName)
        {
            //Select Standard Framework
            logger.LogMethodEntry("StandardSkillsGridPage",
              "SelectStandardFramework", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Standard Framework Window
                this.SelectSkillStandardFrameWorkWindow(StandardSkillsGridPageResource.
                    StandardSkillGrid_Page_StandardFramework_Window);
                //Seach The Frame
                this.SearchTheFrame(StandardFrameName);  
                //Get the total count            
                int getRowNumber = this.GetRowCountOfSkillStandardFrame(StandardFrameName);
                //Select Framework CheckBox
                this.SelectFrameworkCheckBox(getRowNumber);
                //Click The SaveClose Button
                this.ClickTheSaveCloseButton(); 
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StandardSkillsGridPage",
            "SelectStandardFramework", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Skill Standard FrameWork Window.
        /// </summary>
        /// <param name="windowName">This is Window Name.</param>
        private void SelectSkillStandardFrameWorkWindow(string windowName)
        {
            //Select Skill FrameWork Window
            logger.LogMethodEntry("StandardSkillsGridPage",
            "SelectSkillStandardFrameWorkWindow",
            base.isTakeScreenShotDuringEntryExit);
            // Wait For The Skill Framework Popup
            base.WaitUntilWindowLoads(windowName);
            //Select Popup
            base.SelectWindow(windowName);
            logger.LogMethodExit("StandardSkillsGridPage",
            "SelectSkillStandardFrameWorkWindow", 
            base.isTakeScreenShotDuringEntryExit);
        }
    }
}
