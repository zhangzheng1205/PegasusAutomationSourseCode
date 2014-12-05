using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Users;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;
using System;


namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports
{
    /// <summary>
    /// This class handles Student Report by Activity report Page Actions.  
    /// </summary>
    public class RptStudentReportByActivityPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(
            typeof(RptStudentReportByActivityPage));

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("RptStudentReportByActivityPage", "SelectWindow"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads("Report: Student Results by Activity");
            //Selecting the 'Student Results by Activity' window                
            base.SelectWindow("Report: Student Results by Activity");
            logger.LogMethodExit("RptStudentReportByActivityPage", "SelectWindow"
               , base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Get Student User name.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <returns>Student first and last name.</returns>
        public string GetStudentUsername(User.UserTypeEnum userTypeEnum)
        {
            //Get  User name.
            logger.LogMethodEntry("RptStudentReportByActivityPage", "GetStudentUsername",
                base.IsTakeScreenShotDuringEntryExit);
            string studentName = string.Empty;
            try
            {
                User user = User.Get(userTypeEnum);
                studentName = user.LastName + ", " + user.FirstName;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentReportByActivityPage", "GetStudentUsername",
                 base.IsTakeScreenShotDuringEntryExit);
            return studentName;
        }

        public string GetStudentAndSectionNameInReport(int reportDetails)
        {
            logger.LogMethodEntry("RptStudentReportByActivityPage", "GetStudentAndSectionNameInReport",
                base.IsTakeScreenShotDuringEntryExit);
            string getStudentReportName = String.Empty;
            //this.SelectWindow();
            base.SwitchToLastOpenedWindow();
            bool gf = base.IsElementPresent(By.XPath(
                "//div[@id='_ctl4_allAssementDetail1']"), 10);
            base.WaitForElement(By.XPath(String.Format(
                "//div[@id='_ctl4_allAssementDetail1']/table/tbody/tr[{0}]/td/div/table/tbody/tr/td/span",
                reportDetails)));
            getStudentReportName = base.GetElementTextByXPath(String.Format(
                "//div[@id='_ctl4_allAssementDetail1']/table/tbody/tr[{0}]/td/div/table/tbody/tr/td/span",
                reportDetails));
            logger.LogMethodExit("RptStudentReportByActivityPage", "GetStudentAndSectionNameInReport",
                 base.IsTakeScreenShotDuringEntryExit);
            return getStudentReportName;
        }

        public string GetAverageScoreInReport()
        {
            logger.LogMethodEntry("RptStudentReportByActivityPage", "GetAverageScoreInReport",
                base.IsTakeScreenShotDuringEntryExit);
            string getAverageScore = String.Empty;
            //this.SelectWindow();
            base.SwitchToLastOpenedWindow();
            bool gf = base.IsElementPresent(By.XPath("//div[@id='_ctl4_AveragePlaceHolder']/table/tbody/tr/td[1]/span"), 10);
            base.WaitForElement(By.XPath("//div[@id='_ctl4_SectionPlaceHolder']/table/tbody/tr/td[1]/span"));
            getAverageScore = base.GetElementTextByXPath("//div[@id='_ctl4_SectionPlaceHolder']/table/tbody/tr/td[1]/span");
            logger.LogMethodExit("RptStudentReportByActivityPage", "GetAverageScoreInReport",
                 base.IsTakeScreenShotDuringEntryExit);
            return getAverageScore;
        }

        public void ClickOnSelectStudent(string studentButtonName)
        {
            logger.LogMethodEntry("RptStudentReportByActivityPage", "ClickOnSelectStudent",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {

                base.SwitchToIFrameById("_ctl0_PageContent_ifrmMiddle");
                base.WaitForElement(By.XPath(String.Format("//a/span/span[text()='{0}'", studentButtonName)));
                IWebElement getStudentButton = base.GetWebElementPropertiesByXPath(string.
                        Format("//a/span/span[text()='{0}'", studentButtonName));
                //Click assesment button
                base.ClickByJavaScriptExecutor(getStudentButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentReportByActivityPage", "ClickOnSelectStudent",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        public string GetReportDetails(int reportColumn)
        {
            logger.LogMethodEntry("RptStudentReportByActivityPage", "GetReportDetails",
                base.IsTakeScreenShotDuringEntryExit);
            string getReportDetails = String.Empty;
            //this.SelectWindow();
            base.SwitchToLastOpenedWindow();
            bool gf = base.IsElementPresent(By.XPath(String.Format(
                "//table[@id='tblMainStyle']/tbody/tr/td[{0}]/span",
                reportColumn)), 10);
            base.WaitForElement(By.XPath(String.Format(
                "//table[@id='tblMainStyle']/tbody/tr/td[{0}]/span",
                reportColumn)));
            getReportDetails = base.GetElementTextByXPath(
                String.Format("//table[@id='tblMainStyle']/tbody/tr/td[{0}]/span",
                reportColumn));
            logger.LogMethodExit("RptStudentReportByActivityPage", "GetReportDetails",
                 base.IsTakeScreenShotDuringEntryExit);
            return getReportDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddStudentToReport(string studentButtonName, User.UserTypeEnum userTypeEnum)
        {
            logger.LogMethodEntry("RptStudentReportByActivityPage",
                "AddStudentToReport",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on 'Select Student' button
            this.ClickOnSelectStudent(studentButtonName);
            //Expand the students link
            bool jdfh = base.IsElementPresent(By.XPath("//table[@id='radPAdimStudents__ctl1']/tbody/tr/td[1]/img"), 10);
            IWebElement expandStudent = base.GetWebElementPropertiesByXPath(
                "//table[@id='radPAdimStudents__ctl1']/tbody/tr/td[1]/img");
            base.ClickByJavaScriptExecutor(expandStudent);
            this.SelectSingleStudent(userTypeEnum);
            logger.LogMethodExit("RptStudentReportByActivityPage",
                "AddStudentToReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        public void SelectSingleStudent(User.UserTypeEnum userTypeEnum)
        {
            logger.LogMethodEntry("SelectSingleStudent",
                "AddStudentToReport",
               base.IsTakeScreenShotDuringEntryExit);
            string getStudentName = string.Empty;
            User user = User.Get(userTypeEnum);
            string studentName = user.LastName + ", " + user.FirstName;
            //Expand the students link
            bool jdfh = base.IsElementPresent(By.XPath(
                "//table[@id='radPAdimStudents__ctl1__ctl6_Detail10']/tbody/tr"), 10);
            int getStudentListCount = base.GetElementCountByXPath(
                "//table[@id='radPAdimStudents__ctl1__ctl6_Detail10']/tbody/tr");
            for (int i = 1; i <= getStudentListCount; i++)
            {
                getStudentName = base.GetElementTextByXPath(String.Format(
                    "//table[@id='radPAdimStudents__ctl1__ctl6_Detail10']/tbody/tr[{0}]/td[2]", i));
                if (getStudentName == studentName)
                {
                    IWebElement getStudent = base.GetWebElementPropertiesByXPath(
                        String.Format("//table[@id='radPAdimStudents__ctl1__ctl6_Detail10']/tbody/tr[{0}]/td[2]", i));
                    base.ClickByJavaScriptExecutor(getStudent);
                    break;
                }
            }
            logger.LogMethodExit("SelectSingleStudent",
                "AddStudentToReport",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
