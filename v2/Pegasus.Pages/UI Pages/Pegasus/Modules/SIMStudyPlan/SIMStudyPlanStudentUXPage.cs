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
            Logger.GetInstance(typeof(TeachingPlanUxPage));

        /// <summary>
        /// Launch SIM Study Plan Pre test by SMS Student
        /// </summary>
        public void LaunchSIMStudyPlanPreTestByStudent()
        {
            // Logger Enrty
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", 
                "LaunchSIMStudyPlanPreTestByStudent",
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Asset.
        /// </summary>        
        public void ClickOnCmenuOfAsset()
        {
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "ClickOnCmenuOfAsset",
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "SelectWindow",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(SIMStudyPlanStudentUXPageResource.
                SIMStudyPlanStudentUXPage_MyItLabStudyplan_Window_Name);
            //Select Window
            base.SelectWindow(SIMStudyPlanStudentUXPageResource.
                SIMStudyPlanStudentUXPage_MyItLabStudyplan_Window_Name);
            Logger.LogMethodExit("SIMStudyPlanStudentUXPage", "SelectWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select View Grades Cmenu Option
        /// </summary>
        public void SelectViewGradesCmenuOption()
        {
            //Select View Grades Cmenu Option
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "SelectViewGradesCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Pre Test Cmenu Option 
        /// </summary>
        private void ClickOnPreTestCmenuOption()
        {
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "ClickOnPreTestCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On View Grades Option
        /// </summary>
        private void ClickOnViewGradesOption()
        {
            //Click On View Grades Option
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "ClickOnViewGradesOption",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(SIMStudyPlanStudentUXPageResource.
                SIMStudyPlanStudentUXPage_ViewGrade_Cmenu_Option_Id_Locator));
            //Get View Grades Option
            IWebElement getViewGradesOption = base.GetWebElementPropertiesById(SIMStudyPlanStudentUXPageResource.
                SIMStudyPlanStudentUXPage_ViewGrade_Cmenu_Option_Id_Locator);
            //Click On View Grades Option
            base.ClickByJavaScriptExecutor(getViewGradesOption);
            Logger.LogMethodExit("SIMStudyPlanStudentUXPage", "ClickOnViewGradesOption",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check 'Start PreTest' Button Present.
        /// </summary>
        /// <returns>Status of 'Start PreTest' Button.</returns>
        public bool IsStartPreTestButtonPresent()
        {
            //Check 'Start PreTest' Button Present
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "IsStartPreTestButtonPresent",
                base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
            return isStartPreTestButtonPresent;
        }

        /// <summary>
        /// Select 'Start Training' button.
        /// </summary>
        public void SelectStartTrainingButton()
        {
            //Select start training button
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "SelectStartTrainingButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath("//div[@id = 'DTContainer']/div[2]/div/div/div[8]/div"));
                        //Click on 'Start Training' button                
                        IWebElement clickStartTraining= base.GetWebElementPropertiesByXPath(
                         "//div[@id = 'DTContainer']/div[2]/div/div/div[8]/div");
                        base.ClickByJavaScriptExecutor(clickStartTraining);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SIMStudyPlanStudentUXPage", "SelectStartTrainingButton",
             base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Select 'Start Training' button.
        /// </summary>
        public void SelectStartButton(string activityType)
        {
            //Select start training button
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "SelectStartTrainingButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (activityType)
                {
                    case "Start Training":
                        base.WaitForElement(By.XPath(SIMStudyPlanStudentUXPageResource.
                         SIMStudyPlanStudentUXPage_StartTrainingButton_XPathLocator));
                        //Click on 'Start Training' button                
                        IWebElement clickStartTraining = base.GetWebElementPropertiesByXPath(
                         SIMStudyPlanStudentUXPageResource.
                          SIMStudyPlanStudentUXPage_StartTrainingButton_XPathLocator);
                        base.ClickByJavaScriptExecutor(clickStartTraining);
                        break;
                    case "Start Post-Test":
                        base.WaitForElement(By.XPath(SIMStudyPlanStudentUXPageResource.
                          SIMStudyPlanStudentUXPage_StartPostTestButton_XPathLocator));
                        //Click on 'Start Training' button                
                        IWebElement clickStartPostTest = base.GetWebElementPropertiesByXPath(
                         SIMStudyPlanStudentUXPageResource.
                          SIMStudyPlanStudentUXPage_StartPostTestButton_XPathLocator);
                        base.ClickByJavaScriptExecutor(clickStartPostTest);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SIMStudyPlanStudentUXPage", "SelectStartTrainingButton",
             base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Fetch the score of the activity.
        /// </summary>
        /// <returns>Activity name.</returns>
        public string GetActivityScore()
        {
            Logger.LogMethodEntry("SIMStudyPlanStudentUXPage", "GetActivityScore",
                base.IsTakeScreenShotDuringEntryExit);
            string activityScore = string.Empty;
            try
            {
                base.SelectWindow(SIMStudyPlanStudentUXPageResource.
                        SIMStudyPlanStudentUXPage_WindowName);
                base.WaitForElement(By.XPath(SIMStudyPlanStudentUXPageResource.
                    SIMStudyPlanStudentUXPage_ActivityScore_XPathLocator));
                //Get activity score
                activityScore = base.GetElementTextByXPath(
                    SIMStudyPlanStudentUXPageResource.
                    SIMStudyPlanStudentUXPage_ActivityScore_XPathLocator);
                //Click on cancel button
                base.WaitForElement(By.Id(SIMStudyPlanStudentUXPageResource
                    .SIMStudyPlanStudentUXPage_CancelButton_IdLocator));
                IWebElement clickCancel = base.GetWebElementPropertiesById
                    (SIMStudyPlanStudentUXPageResource
                    .SIMStudyPlanStudentUXPage_CancelButton_IdLocator);
                base.ClickByJavaScriptExecutor(clickCancel);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SIMStudyPlanStudentUXPage", "GetActivityScore",
            base.IsTakeScreenShotDuringEntryExit);
            return activityScore;
        }
     }
}
