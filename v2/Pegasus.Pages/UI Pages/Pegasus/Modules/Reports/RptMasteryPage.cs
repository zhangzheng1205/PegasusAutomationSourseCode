using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Class Mastery Actions
    /// </summary>
    public class RptMasteryPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptMasteryPage));

        /// <summary>
        /// Click The Class Mastery Link
        /// </summary>
        public void ClickTheClassMasteryLink()
        {
            //Click The "Class Mastery link"           
            logger.LogMethodEntry("RptMasteryPage","ClickTheClassMasteryLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click the "Class Mastery" Link
                new RptCommonCriteriaPage().SelectTheReportFrame();                
                base.WaitForElement(By.XPath(RptMasteryPageResource.
                    RptMastery_Page_SelectClassMastery_Xpath_Locator));
                base.FocusOnElementByXPath(RptMasteryPageResource.
                    RptMastery_Page_SelectClassMastery_Xpath_Locator);
                IWebElement getClassMasteryLinkProperties = base.GetWebElementPropertiesByXPath
                    (RptMasteryPageResource.
                    RptMastery_Page_SelectClassMastery_Xpath_Locator);                
                base.ClickByJavaScriptExecutor(getClassMasteryLinkProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMasteryPage","ClickTheClassMasteryLink",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Class Mastery Link
        /// </summary>
        public void ClickTheStudentMasteryLink()
        {
            //Click The "Class Mastery link"           
            logger.LogMethodEntry("RptMasteryPage", "ClickTheStudentMasteryLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click the "Individual Student Mastery" Link
                new RptCommonCriteriaPage().SelectTheReportFrame();
                base.WaitForElement(By.XPath(RptMasteryPageResource.
                    RptMastery_Page_SelectStudentMastery_Xpath_Locator));
                base.FocusOnElementByXPath(RptMasteryPageResource.
                    RptMastery_Page_SelectStudentMastery_Xpath_Locator);
                IWebElement getStudentMasteryLinkProperties = base.GetWebElementPropertiesByXPath
                    (RptMasteryPageResource.
                    RptMastery_Page_SelectStudentMastery_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getStudentMasteryLinkProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMasteryPage", "ClickTheStudentMasteryLink",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click on Close Button Of Mastery report 
        /// </summary>
        public void MasteryReportCloseButton()
        {
            //
            logger.LogMethodEntry("RptMasteryPage", "MasteryReportCloseButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click the "Close" button
                base.WaitUntilWindowLoads(RptMasteryPageResource.
                       RptMastery_Page_SelectMasteryReport_Window_Name);
                base.SelectWindow(RptMasteryPageResource.
                       RptMastery_Page_SelectMasteryReport_Window_Name);
                base.WaitForElement(By.ClassName(RptMasteryPageResource.
                    RptMastery_Page_SelectMasteryReport_CloseButton_ClassName));
                base.FocusOnElementByClassName(RptMasteryPageResource.
                    RptMastery_Page_SelectMasteryReport_CloseButton_ClassName);
                IWebElement getCloseButtonProperties = base.
                 GetWebElementPropertiesByClassName(RptMasteryPageResource.
                    RptMastery_Page_SelectMasteryReport_CloseButton_ClassName);
                base.ClickByJavaScriptExecutor(getCloseButtonProperties);
                Thread.Sleep(Convert.ToInt32(RptMasteryPageResource.
                    RptMastery_Page_CloseButton_Click_TimeValue));
                base.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMasteryPage", "MasteryReportCloseButton",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        ///Verify the selected skill is present in the generated mastery report
        /// </summary>
        public String ValidateSkillNameForMasteryReport()
        {
            logger.LogMethodEntry("RptMasteryPage", "ValidateSkillNameForMasteryReport",
                base.IsTakeScreenShotDuringEntryExit);
            String skillName = String.Empty;
            try
            {
                //very the selected skill is present in the generated report
                base.WaitUntilWindowLoads(RptMasteryPageResource.
                       RptMastery_Page_SelectMasteryReport_Window_Name);
                base.SelectWindow(RptMasteryPageResource.
                       RptMastery_Page_SelectMasteryReport_Window_Name);
                base.WaitForElement(By.Id(RptMasteryPageResource.
                    RptClassMastery_Page_SelectClassMastery_SkillName_Id_Locator));
                skillName = base.GetElementTextById(RptMasteryPageResource.
                    RptClassMastery_Page_SelectClassMastery_SkillName_Id_Locator).Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMasteryPage", "ValidateSkillNameForMasteryReport",
                base.IsTakeScreenShotDuringEntryExit);
            return skillName;
        }
    }
}
