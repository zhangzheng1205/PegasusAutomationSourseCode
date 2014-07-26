using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Users;
using Pegasus.Automation.DataTransferObjects;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus RptSaveSettings Page Actions
    /// The class name is bad because as in Pegasus
    /// </summary>
    public class RptSaveSettingsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptSaveSettingsPage));

        /// <summary>
        /// This is the enum available for Radiobuttons in Save Settings Popup
        /// </summary>
        public enum SaveSettingsPopupRadiobuttonTypeEnum
        {
            /// <summary>
            /// 'Create new report' Radiobutton In Save Settings Popup
            /// </summary>
            Createnewreport = 1,
            /// <summary>
            /// 'Replace existing report' Radiobutton In Save Settings Popup
            /// </summary>
            Replaceexistingreport = 2            
        }

        // <summary>
        /// This is the enum available for Buttons in Save Settings Popup
        /// </summary>
        public enum SaveSettingsPopupButtonTypeEnum
        {
            /// <summary>
            /// 'Save Only' Button In Save Settings Popup
            /// </summary>
            SaveOnly = 1,
            /// <summary>
            /// 'Save and Run' Button In Save Settings Popup
            /// </summary>
            SaveandRun = 2,
            /// <summary>
            /// 'Cancel' Button In Save Settings Popup
            /// </summary>
            Cancel = 3
        }

        /// <summary>
        /// Select Radiobutton In Save Settings Popup.
        /// </summary>
        /// <param name="SaveSettingsPopupRadiobuttonTypeEnum">
        /// This is Save Settings Popup Radiobutton Enum.</param>
        public void SelectRadioButtonInSaveSettingsPopup(
            SaveSettingsPopupRadiobuttonTypeEnum SaveSettingsPopupRadiobuttonTypeEnum)
        {
            //Select Radiobutton In Save Settings Popup
            logger.LogMethodEntry("RptSaveSettingsPage", "SelectRadioButtonInSaveSettingsPopup",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (SaveSettingsPopupRadiobuttonTypeEnum)
                {
                    case SaveSettingsPopupRadiobuttonTypeEnum.Createnewreport:
                        //Select Window
                        this.SelectWindow();
                        if (!IsElementSelectedByXPath(RptSaveSettingsPageResource.
                            RptSaveSettingsPage_Resource_Createnewreport_Radiobutton_Xpath_Locator))
                        {
                            //Select 'Create new report' Radiobutton 
                            base.SelectRadioButtonByXPath(RptSaveSettingsPageResource.
                            RptSaveSettingsPage_Resource_Createnewreport_Radiobutton_Xpath_Locator);
                        }
                        break;
                    case SaveSettingsPopupRadiobuttonTypeEnum.Replaceexistingreport:
                        //Select Window
                        this.SelectWindow();
                        if (!IsElementSelectedByXPath(RptSaveSettingsPageResource.
                            RptSaveSettingsPage_Resource_CreatenewreportRadio_Xpath_Locator))
                        {
                            //Select 'Replace Existing Report' Radiobutton 
                            base.SelectRadioButtonByXPath(RptSaveSettingsPageResource.
                            RptSaveSettingsPage_Resource_CreatenewreportRadio_Xpath_Locator);
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveSettingsPage", "SelectRadioButtonInSaveSettingsPopup",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("RptSaveSettingsPage", "SelectWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.WaitUntilWindowLoads(RptSaveSettingsPageResource.
                RptSaveSettingsPage_Resource_Window_Name);
            base.SelectWindow(RptSaveSettingsPageResource.
                RptSaveSettingsPage_Resource_Window_Name);
            logger.LogMethodExit("RptSaveSettingsPage", "SelectWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Report Name.
        /// </summary>  
        /// <param name="reportName">This is Report Name.</param>
        public void EnterReportName(Guid reportName)
        {
            //Enter Report Name
            logger.LogMethodEntry("RptSaveSettingsPage", "EnterReportName",
                base.isTakeScreenShotDuringEntryExit);
            try
            {               
                //Select Window
                this.SelectWindow();
                //Wait For Report Name Textbox
                base.WaitForElement(By.Id(RptSaveSettingsPageResource.
                    RptSaveSettingsPage_Resource_ReportName_Text_Id_Locator));
                base.ClearTextById(RptSaveSettingsPageResource.
                    RptSaveSettingsPage_Resource_ReportName_Text_Id_Locator);
                //Fill Report Name
                base.FillTextBoxById(RptSaveSettingsPageResource.
                    RptSaveSettingsPage_Resource_ReportName_Text_Id_Locator,
                    reportName.ToString());                              
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveSettingsPage", "EnterReportName",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Report Details In Memory.
        /// </summary>
        /// <param name="reportName">This is Report Name.</param>
        /// <param name="reportTypeEnum">This is Report Type Enum.</param>
        public void StoreReportDetailsInMemory(Guid reportName,
            Report.ReportTypeEnum reportTypeEnum)
        {
            //Store Report Details In Memory
            logger.LogMethodEntry("RptSaveSettingsPage", "StoreReportDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                Report report = new Report
                   {
                       //Report Details
                       Name = reportName.ToString(),
                       ReportType = reportTypeEnum,
                       IsCreated = true,
                   };
                report.StoreReportInMemory();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveSettingsPage", "StoreReportDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button In Save Settings Popup.
        /// </summary>
        /// <param name="SaveSettingsPopupButtonTypeEnum">
        /// This is Save Settings Popup Button Enum.</param>
        public void ClickOnButtonInSaveSettingsPopup(
            SaveSettingsPopupButtonTypeEnum SaveSettingsPopupButtonTypeEnum)
        {
            //Click On Button In Save Settings Popup
            logger.LogMethodEntry("RptSaveSettingsPage", "ClickOnButtonInSaveSettingsPopup",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (SaveSettingsPopupButtonTypeEnum)
                {
                    case RptSaveSettingsPage.SaveSettingsPopupButtonTypeEnum.SaveandRun:
                        //Click On Save And Run
                        this.ClickOnSaveAndRun();
                        break;
                    case RptSaveSettingsPage.SaveSettingsPopupButtonTypeEnum.SaveOnly:
                        //Click On Save Only
                        this.ClickOnSaveOnly();
                        break;
                    case RptSaveSettingsPage.SaveSettingsPopupButtonTypeEnum.Cancel:
                        //Click On Cancel
                        this.ClickOnCancel();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveSettingsPage", "ClickOnButtonInSaveSettingsPopup",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cancel.
        /// </summary>
        private void ClickOnCancel()
        {
            //Click On Cancel
            logger.LogMethodEntry("RptSaveSettingsPage", "ClickOnCancel",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectWindow();
            base.WaitForElement(By.Id(RptSaveSettingsPageResource.
                RptSaveSettingsPage_Resource_Cancel_Button_Id_locator));
            //Click On 'Cancel' Button
            base.ClickButtonById(RptSaveSettingsPageResource.
                RptSaveSettingsPage_Resource_Cancel_Button_Id_locator);
            Thread.Sleep(Convert.ToInt32(RptSaveSettingsPageResource.
                RptSaveSettingsPage_Resource_Wait_Time_Value));
            logger.LogMethodExit("RptSaveSettingsPage", "ClickOnCancel",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save Only.
        /// </summary>
        private void ClickOnSaveOnly()
        {
            //Click On Save Only
            logger.LogMethodEntry("RptSaveSettingsPage", "ClickOnSaveOnly",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectWindow();
            base.WaitForElement(By.Id(RptSaveSettingsPageResource.
                RptSaveSettingsPage_Resource_SaveOnly_Button_Id_Locator));
            //Click On 'Save Only' Button
            base.ClickButtonById(RptSaveSettingsPageResource.
                RptSaveSettingsPage_Resource_SaveOnly_Button_Id_Locator);
            Thread.Sleep(Convert.ToInt32(RptSaveSettingsPageResource.
                RptSaveSettingsPage_Resource_Wait_Time_Value));
            logger.LogMethodExit("RptSaveSettingsPage", "ClickOnSaveOnly",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save And Run.
        /// </summary>
        private void ClickOnSaveAndRun()
        {
            //Click On Save And Run
            logger.LogMethodEntry("RptSaveSettingsPage", "ClickOnSaveAndRun",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectWindow();
            base.WaitForElement(By.Id(RptSaveSettingsPageResource.
                RptSaveSettingsPage_Resource_SaveandRun_Button_Id_locator));
            //Click On 'Save and Run' Button
            base.ClickButtonById(RptSaveSettingsPageResource.
                RptSaveSettingsPage_Resource_SaveandRun_Button_Id_locator);
            Thread.Sleep(Convert.ToInt32(RptSaveSettingsPageResource.
                RptSaveSettingsPage_Resource_Wait_Time_Value));
            logger.LogMethodExit("RptSaveSettingsPage", "ClickOnSaveAndRun",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Report Displayed In Dropdown.
        /// </summary>
        /// <param name="reportName">This is Report Name.</param>
        /// <returns>Report Name.</returns>
        public bool IsReportDisplayedInDropdown(string reportName)
        {
            //Verify Report Displayed In Dropdown
            logger.LogMethodEntry("RptSaveSettingsPage", "IsReportDisplayedInDropdown",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isReportDisplayed = false;
            try
            {
                //Select Window
                this.SelectWindow();
                base.WaitForElement(By.Id(RptSaveSettingsPageResource.
                    RptSaveSettingsPage_ReplaceExistingReport_Dropdown_Id_Locator));
                //Select Report In Dropdown
                base.SelectDropDownValueThroughTextById(RptSaveSettingsPageResource.
                    RptSaveSettingsPage_ReplaceExistingReport_Dropdown_Id_Locator, reportName);
                //Get Report
                string getReportName = base.GetElementTextById(RptSaveSettingsPageResource.
                    RptSaveSettingsPage_ReplaceExistingReport_Dropdown_Id_Locator);
                if (getReportName.Contains(reportName))
                {
                    isReportDisplayed = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveSettingsPage", "IsReportDisplayedInDropdown",
                base.isTakeScreenShotDuringEntryExit);
            return isReportDisplayed;
        }
       
    }
}
