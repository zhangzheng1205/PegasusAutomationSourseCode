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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SIMStudyPlan;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles SIMStudyPlanStudentUXPage Page Actions.
    /// </summary>

    public class SIMStudyPlanStudentUXPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(TeachingPlanUXPage));

        /// <summary>
        /// Launch SIM Study Plan Pre test by SMS Student
        /// </summary>
        public void LaunchSIMStudyPlanPreTestByStudent()
        {
            // Logger Enrty
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", 
                "LaunchSIMStudyPlanPreTestByStudent",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for 'Start Pre test' element 
                base.WaitForElement(By.XPath(SIMStudyPlanStudentUXPageResource.
                    SIMStudyPlanStudentUXPage_StartPreTest_Button_Xpath_Locator));
                //Get the HTML property of element 
                IWebElement getPropertyOfStartPreTest = base.
                    GetWebElementPropertiesByXPath(SIMStudyPlanStudentUXPageResource.
                    SIMStudyPlanStudentUXPage_StartPreTest_Button_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getPropertyOfStartPreTest);
                //Handle Activity Alert validation Popup of pre test
                if(base.IsPopupPresent(SIMStudyPlanStudentUXPageResource.
                    SIMStudyPlanStudentUXPage_Activity_Alert_PopUp_Name))
                {
                    //Wait for contineo button on Pop up
                    base.WaitForElement(By.Id(SIMStudyPlanStudentUXPageResource.
                        SIMStudyPlanStudentUXPage_Contineo_Button_Id));
                    //Get The HTML property of button 
                    IWebElement getHTMLPropertyOfContinueButton =
                        base.GetWebElementPropertiesById(
                        SIMStudyPlanStudentUXPageResource.
                        SIMStudyPlanStudentUXPage_Contineo_Button_Id);
                    //Click on Continue button
                    base.ClickByJavaScriptExecutor(getHTMLPropertyOfContinueButton);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("SIMStudyPlanStudentUXPage",
               "LaunchSIMStudyPlanPreTestByStudent",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Asset.
        /// </summary>        
        public void ClickOnCmenuOfAsset()
        {
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "ClickOnCmenuOfAsset",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectWindow();
                base.WaitForElement(By.XPath(SIMStudyPlanStudentUXPageResource.
                    SIMStudyPlanStudentUXPage_Submission_Expand_Xpath_Locator));
                //Get Element Property
                IWebElement getCmenuIconProperty = 
                    base.GetWebElementPropertiesByXPath(SIMStudyPlanStudentUXPageResource.
                    SIMStudyPlanStudentUXPage_Submission_Expand_Xpath_Locator);
                //Click On Cmenu Icon
                base.ClickByJavaScriptExecutor(getCmenuIconProperty);
                base.WaitForElement(By.Id(SIMStudyPlanStudentUXPageResource.
                    SIMStudyPlanStudentUXPage_ViewSubmission_Cmenu_Option_Id_Locator));
                //Click On 'View Submission' Option
                base.ClickLinkById(SIMStudyPlanStudentUXPageResource.
                    SIMStudyPlanStudentUXPage_ViewSubmission_Cmenu_Option_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SIMStudyPlanStudentUXPage", "ClickOnCmenuOfAsset",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "SelectWindow",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(SIMStudyPlanStudentUXPageResource.
                SIMStudyPlanStudentUXPage_MyItLabStudyplan_Window_Name);
            //Select Window
            base.SelectWindow(SIMStudyPlanStudentUXPageResource.
                SIMStudyPlanStudentUXPage_MyItLabStudyplan_Window_Name);
            Logger.LogMethodExit("SIMStudyPlanStudentUXPage", "SelectWindow",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select View Grades Cmenu Option
        /// </summary>
        public void SelectViewGradesCmenuOption()
        {
            //Select View Grades Cmenu Option
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "SelectViewGradesCmenuOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Study Plan Window
                this.SelectWindow();
                //Click On Pre Test Cmenu Option
                this.ClickOnPreTestCmenuOption();
                //Click On View Grades Option
                this.ClickOnViewGradesOption();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SIMStudyPlanStudentUXPage", "SelectViewGradesCmenuOption",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Pre Test Cmenu Option 
        /// </summary>
        private void ClickOnPreTestCmenuOption()
        {
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "ClickOnPreTestCmenuOption",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Pre Test Cmenu Option 
            base.WaitForElement(By.XPath(SIMStudyPlanStudentUXPageResource.
                   SIMStudyPlanStudentUXPage_Submission_Expand_Xpath_Locator));
            //Get Element Property
            IWebElement getCmenuIconProperty =
                base.GetWebElementPropertiesByXPath(SIMStudyPlanStudentUXPageResource.
                SIMStudyPlanStudentUXPage_Submission_Expand_Xpath_Locator);
            //Click On Cmenu Icon
            base.ClickByJavaScriptExecutor(getCmenuIconProperty);
            Logger.LogMethodExit("SIMStudyPlanStudentUXPage", "ClickOnPreTestCmenuOption",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On View Grades Option
        /// </summary>
        private void ClickOnViewGradesOption()
        {
            //Click On View Grades Option
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "ClickOnViewGradesOption",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(SIMStudyPlanStudentUXPageResource.
                SIMStudyPlanStudentUXPage_ViewGrade_Cmenu_Option_Id_Locator));
            //Get View Grades Option
            IWebElement getViewGradesOption = base.GetWebElementPropertiesById(SIMStudyPlanStudentUXPageResource.
                SIMStudyPlanStudentUXPage_ViewGrade_Cmenu_Option_Id_Locator);
            //Click On View Grades Option
            base.ClickByJavaScriptExecutor(getViewGradesOption);
            Logger.LogMethodExit("SIMStudyPlanStudentUXPage", "ClickOnViewGradesOption",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check 'Start PreTest' Button Present.
        /// </summary>
        /// <returns>Status of 'Start PreTest' Button.</returns>
        public bool IsStartPreTestButtonPresent()
        {
            //Check 'Start PreTest' Button Present
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "IsStartPreTestButtonPresent",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isStartPreTestButtonPresent = false;
            try
            {
                //Select Window
                this.SelectWindow();
                //Wait for Element
                base.WaitForElement(By.XPath(SIMStudyPlanStudentUXPageResource.
                    SIMStudyPlanStudentUXPage_StartPreTest_Button_Xpath_Locator));
                if (base.IsElementPresent(By.XPath(SIMStudyPlanStudentUXPageResource.
                    SIMStudyPlanStudentUXPage_StartPreTest_Button_Xpath_Locator)))
                {
                    isStartPreTestButtonPresent = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SIMStudyPlanStudentUXPage", "IsStartPreTestButtonPresent",
              base.isTakeScreenShotDuringEntryExit);
            return isStartPreTestButtonPresent;
        }
    }
}
