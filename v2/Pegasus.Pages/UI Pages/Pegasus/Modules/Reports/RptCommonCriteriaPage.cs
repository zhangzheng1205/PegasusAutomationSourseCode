using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports
{
    /// <summary>
    /// This class handles Student Activity Actions
    /// </summary>
    public class RptCommonCriteriaPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptCommonCriteriaPage));

        /// <summary>
        ///Select The Students From LightBox
        /// </summary>
        /// <param name="userType">This is User type</param>
        public void SelectTheStudentsFromLightBox(string userType)
        {
            //Select The Students From LightBox
            logger.LogMethodEntry("RptCommonCriteriaPage",
                "SelectTheStudentsFromLightBox",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select The Report frame
                this.SelectTheReportFrame();
                //Wait for the Element
                base.WaitForElement(By.ClassName(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectStudent_Id_Locator));
                IWebElement getStudent = base.GetWebElementPropertiesByClassName
                    (RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectStudent_Id_Locator);
                //Click the "Select Students"
                base.ClickByJavaScriptExecutor(getStudent);
                //Select Report LightBox Frame
                this.SelectReportLightBoxFrame();
                //Click The Student CheckBox
                this.ClickTheStudentCheckBox(userType);
                //Select The Report frame
                this.SelectTheReportFrame();               
                //Wait for the element
                base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectStudent_TextBox_Id_Locator));
                string isStudentSelected = base.GetElementTextById
                    (RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectStudent_TextBox_Id_Locator);                            
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }        
            logger.LogMethodExit("RptCommonCriteriaPage",
                "SelectTheStudentsFromLightBox",
                base.isTakeScreenShotDuringEntryExit);
        }
      
        /// <summary>
        ///Click The Student CheckBox
        /// </summary>
        /// <param name="userType">This is user type</param>
        private void ClickTheStudentCheckBox(String userType)
        {
            //Click The Student CheckBox
            logger.LogMethodEntry("RptCommonCriteriaPage",
             "ClickTheStudentCheckBox",
             base.isTakeScreenShotDuringEntryExit);
            //Wait for the expand button
            base.WaitForElement(By.XPath(RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectStudent_Expandbtn_Xpath_Locator));
            IWebElement getExpandbutton = base.GetWebElementPropertiesByXPath
                (RptCommonCriteriaPageResource.RptCommonCriteria_Page_SelectStudent_Expandbtn_Xpath_Locator);
            //Click on the expand link
            base.ClickByJavaScriptExecutor(getExpandbutton);
            //Get Count of students
            int getStudentCount = base.GetElementCountByXPath
                (RptCommonCriteriaPageResource.RptCommonCriteria_Page_SelectStudent_UserCount_Xpath_Locator);
            for (int rowCount = 1; rowCount <= getStudentCount; rowCount++)
            {
                //Get Student Name
                string getStudentName = base.GetElementTextByXPath
                    (string.Format(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectStudent_UserName_Xpath_Locator, rowCount));
                if (getStudentName.Contains(userType))
                {
                    base.WaitForElement(By.XPath(string.Format(RptCommonCriteriaPageResource.
                        RptCommonCriteria_Page_SelectStudent_User_Checkbox_Xpath_Locator, rowCount)));
                    base.FocusOnElementByXPath(string.Format(RptCommonCriteriaPageResource.
                        RptCommonCriteria_Page_SelectStudent_User_Checkbox_Xpath_Locator, rowCount));
                    //Click on Student checkbox Button
                    base.ClickButtonByXPath(string.Format(RptCommonCriteriaPageResource.
                        RptCommonCriteria_Page_SelectStudent_User_Checkbox_Xpath_Locator, rowCount));
                    break;
                }
            }
            //Wait for the element
            base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
             RptCommonCriteria_Page_SelectStudent_Lightbox_AddButton_Id_Locator));
            IWebElement getAddButton = base.GetWebElementPropertiesById
                (RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectStudent_Lightbox_AddButton_Id_Locator);
            //Click the "Add And Close" button
            base.ClickByJavaScriptExecutor(getAddButton);
            logger.LogMethodExit("RptCommonCriteriaPage",
               "ClickTheStudentCheckBox",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Report LightBox Frame
        /// </summary>
        private void SelectReportLightBoxFrame()
        {
            //Select Report LightBox Frame
            logger.LogMethodEntry("RptCommonCriteriaPage",
              "SelectReportLightBoxFrame",
              base.isTakeScreenShotDuringEntryExit);
            //Select the window
            base.SelectWindow(RptCommonCriteriaPageResource.
               RptCommonCriteria_Page_Report_Window_Name); 
            //Select the Iframe
            base.SwitchToIFrame(RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectStudent_Iframe_Id_Locator);
            logger.LogMethodExit("RptCommonCriteriaPage",
               "SelectReportLightBoxFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        #region Mastery reports

        /// <summary>
        ///Select The Report frame for skill/standard
        /// </summary>
        private void SelectTheReportFrameForSkills()
        {
            //Select The Report frame
            logger.LogMethodEntry("RptCommonCriteriaPage",
               "SelectTheReportFrameForSkills",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_Report_Window_Name);
                //Select the Report Window
                base.SelectWindow(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_Report_Window_Name);
                base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectSkillStd_Iframe_Id_Locator));
                //Select the Frame
                base.SwitchToIFrame(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectSkillStd_Iframe_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptCommonCriteriaPage",
               "SelectTheReportFrameForSkills",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select The Students frame for skill/standard report
        /// </summary>
        private void SelectStudentFrameForMastery()
        {
            //Select The Report frame
            logger.LogMethodEntry("RptCommonCriteriaPage",
               "SelectStudentFrameForMastery",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_Report_Window_Name);
                //Select the Report Window
                base.SelectWindow(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_Report_Window_Name);
                base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectStudentForMastery_Iframe_Id_Locator));
                //Select the Frame
                base.SwitchToIFrame(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectStudentForMastery_Iframe_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptCommonCriteriaPage",
               "SelectStudentFrameForMastery",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Skills/Standard Radio button
        /// </summary>
        public void SelectSkillStdOption()
        {
            //
            logger.LogMethodEntry("RptCommonCriteriaPage", "SelectSkillStdOption",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectTheReportFrame();
                //Select "Skill" or "Standard" radio button
                base.SelectRadioButtonById(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectSkillStd_RadioButton_Id_Locator);
                this.ClickSelectSkillButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptCommonCriteriaPage", "SelectSkillStdOption",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Select Skills button
        /// </summary>
        private void ClickSelectSkillButton()
        {
            //Click the "Select Skills" button
            logger.LogMethodEntry("RptCommonCriteriaPage", "ClickSelectSkillButton",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.ClassName(RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectSkills_Id_Locator));
            IWebElement getSkillsProperties = base.GetWebElementPropertiesByClassName
                (RptCommonCriteriaPageResource.RptCommonCriteria_Page_SelectSkills_Id_Locator);
            base.ClickByJavaScriptExecutor(getSkillsProperties);
            Thread.Sleep(Convert.ToInt32(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_RunReport_Button_TimeValue));
            logger.LogMethodExit("RptCommonCriteriaPage", "ClickSelectSkillButton",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Students From LightBox for Mastery Reports
        /// </summary>
        public void SelectTheSkillsFromLightBox(String skillName)
        {
            //Select The Students From LightBox
            logger.LogMethodEntry("RptCommonCriteriaPage", "SelectTheSkillsFromLightBox",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Report LightBox Frame
                this.SelectTheReportFrameForSkills();
                //Wait for the selct option dropdown for class
                base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectSkills_Dropdown_Id_Locator));
                base.SelectDropDownValueThroughTextById(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectSkills_Dropdown_Id_Locator, skillName);
                //Select Skills from treeview
                this.SelectSkillsFromTreeview();
                //Click  on Add Image
                this.AddSkillsFromLeftToRight();
                //Click on Use Selected Skills button
                this.ClickUseSelectedSkills();

                Thread.Sleep(Convert.ToInt32(RptCommonCriteriaPageResource.
                     RptCommonCriteria_Page_RunReport_Button_TimeValue));
                //Select The Report frame
                this.SelectTheReportFrame();
                //Wait for the element
                base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                     RptCommonCriteria_Page_SelectSkills_TextBox_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptCommonCriteriaPage", "SelectTheSkillsFromLightBox",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select The Skills/Standards for Mastery reports From Treeview 
        /// </summary>
        private void SelectSkillsFromTreeview()
        {
            logger.LogMethodEntry("RptCommonCriteriaPage", "SelectSkillsFromTreeview",
                base.isTakeScreenShotDuringEntryExit);
            //Select the skills from tree view
            base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectSkills_Checkbox_Id_Locator));
            IWebElement getSelectSkills = base.GetWebElementPropertiesById
                (RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectSkills_Checkbox_Id_Locator);
            //Click the treeview checkbox
            base.SelectCheckBoxById(RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectSkills_Checkbox_Id_Locator);
            logger.LogMethodExit("RptCommonCriteriaPage", "SelectSkillsFromTreeview",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Add Skills/Standards from Left grid to Righ Grid On Click of Add image button 
        /// </summary>
        private void AddSkillsFromLeftToRight()
        {
            logger.LogMethodEntry("RptCommonCriteriaPage", "AddSkillsFromLeftToRight",
                base.isTakeScreenShotDuringEntryExit);
            //Click the "Add" button
            base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectSkills_AddImage_Id_Locator));
            IWebElement addSkillsButtonProperties = base.GetWebElementPropertiesById
            (RptCommonCriteriaPageResource.
            RptCommonCriteria_Page_SelectSkills_AddImage_Id_Locator);
            base.ClickByJavaScriptExecutor(addSkillsButtonProperties);
            base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_CheckSkills_Checkbox_Id_Locator));
            logger.LogMethodExit("RptCommonCriteriaPage", "AddSkillsFromLeftToRight",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click on Use Selected Skills button 
        /// </summary>
        private void ClickUseSelectedSkills()
        {
            logger.LogMethodEntry("RptCommonCriteriaPage", "ClickUseSelectedSkills",
                base.isTakeScreenShotDuringEntryExit);
            //Click on "UseSelectedSkills" button
            base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
               RptCommonCriteria_Page_SelectSkills_UseSelectedSkills_Id_Locator));
            IWebElement getSelectedSkillsProperties = base.GetWebElementPropertiesById
                (RptCommonCriteriaPageResource.
               RptCommonCriteria_Page_SelectSkills_UseSelectedSkills_Id_Locator);
            base.ClickByJavaScriptExecutor(getSelectedSkillsProperties);
            logger.LogMethodExit("RptCommonCriteriaPage", "ClickUseSelectedSkills",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Students From LightBox For Mastery Reports
        /// </summary>
        public void SelectTheStudentsForSkillsFromLightBox()
        {
            //Select The Students From LightBox
            logger.LogMethodEntry("RptCommonCriteriaPage",
                "SelectTheStudentsForSkillsFromLightBox",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectTheReportFrame();
                //Click on "Select Students" button
                this.ClickStudentsForMasteryReports();
                Thread.Sleep(Convert.ToInt32(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_RunReport_Button_TimeValue));
                //Select student Pop up
                this.SelectStudentFrameForMastery();
                //Select student from student pop up
                this.SelectStudentsForMasteryReports();
                Thread.Sleep(Convert.ToInt32(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_RunReport_Button_TimeValue));
                this.SelectTheReportFrame();
                base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SaveReport_Checkbox_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptCommonCriteriaPage",
                "SelectTheStudentsForSkillsFromLightBox",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click on Select Students button for Mastery reports 
        /// </summary>
        private void ClickStudentsForMasteryReports()
        {
            //Select The Students From LightBox
            logger.LogMethodEntry("RptCommonCriteriaPage",
                "ClickStudentsForMasteryReports", base.isTakeScreenShotDuringEntryExit);
            //Click The "Select Students" Button
            base.WaitForElement(By.PartialLinkText(RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectStudent_Button_Link_Locator));
            IWebElement getStudentProperties = base.GetWebElementPropertiesByPartialLinkText
                (RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectStudent_Button_Link_Locator);
            base.ClickByJavaScriptExecutor(getStudentProperties);
            logger.LogMethodExit("RptCommonCriteriaPage",
                "ClickStudentsForMasteryReports", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click on Select Students button for Mastery reports 
        /// </summary>
        private void SelectStudentsForMasteryReports()
        {

            logger.LogMethodEntry("RptCommonCriteriaPage",
                "SelectStudentsForMasteryReports", base.isTakeScreenShotDuringEntryExit);
            //Select All Studets Check Box
            base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_SelectStudentForMastery_CheckboxId_Locator));
            IWebElement getStudentForMastery = base.GetWebElementPropertiesById
                (RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectStudentForMastery_CheckboxId_Locator);
            base.ClickByJavaScriptExecutor(getStudentForMastery);
            //Click on Add Button
            base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectStudent_Lightbox_AddButton_Id_Locator));
            IWebElement addStudentForMastery = base.GetWebElementPropertiesById
                (RptCommonCriteriaPageResource.
                RptCommonCriteria_Page_SelectStudent_Lightbox_AddButton_Id_Locator);
            base.ClickByJavaScriptExecutor(addStudentForMastery);

            logger.LogMethodExit("RptCommonCriteriaPage",
                "SelectStudentsForMasteryReports", base.isTakeScreenShotDuringEntryExit);
        }

        #endregion

        /// <summary>
        ///Select The Report frame
        /// </summary>
        public void SelectTheReportFrame()
        {
            //Select The Report frame
            logger.LogMethodEntry("RptCommonCriteriaPage",
               "SelectTheReportFrame",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Report Window
                base.SelectWindow(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_Report_Window_Name);
                base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_Report_Iframe_Id_Locator));
                //Select the Frame
                base.SwitchToIFrame(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_Report_Iframe_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
             logger.LogMethodExit("RptCommonCriteriaPage",
                "SelectTheReportFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click Run Report
        /// </summary>
        public void ClickRunReport()
        {
            //Click Run Report
            logger.LogMethodEntry("RptCommonCriteriaPage","ClickRunReport",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_RunReport_Button_Id_Locator));
                IWebElement getButton = base.GetWebElementPropertiesById
                    (RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_RunReport_Button_Id_Locator);
                //Click the "Run Report" Button
                base.ClickByJavaScriptExecutor(getButton);
                Thread.Sleep(Convert.ToInt32(RptCommonCriteriaPageResource.
                    RptCommonCriteria_Page_RunReport_Button_TimeValue));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptCommonCriteriaPage","ClickRunReport",
               base.isTakeScreenShotDuringEntryExit);            
        }
    }
}
