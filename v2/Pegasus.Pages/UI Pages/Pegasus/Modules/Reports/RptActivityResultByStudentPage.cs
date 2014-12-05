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


namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports
{
    /// <summary>
    /// This class handles Activity Resukt by Student Page Actions.  
    /// </summary>
    public class RptActivityResultByStudentPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(
            typeof(RptActivityResultByStudentPage));

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("RptActivityResultByStudentPage", "SelectWindow"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads("Report: Activity Results by Student");
            //Selecting the 'Activity Result By Student' window                
            base.SelectWindow("Report: Activity Results by Student");
            logger.LogMethodExit("RptActivityResultByStudentPage", "SelectWindow"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        public string GetActivityDetailsInReport(int reportDetails)
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage", "GetStudentAndSectionNameInReport",
                base.IsTakeScreenShotDuringEntryExit);
            string getActivityDetails = string.Empty;
            //this.SelectWindow();
            base.SwitchToLastOpenedWindow();
            bool gf = base.IsElementPresent(By.XPath(
                "//div[@id='_ctl3_allAssementDetail1']"), 10);
            base.WaitForElement(By.XPath(string.Format(
                "//div[@id='_ctl3_allAssementDetail1']/table/tbody/tr[{0}]/td/div/table/tbody/tr/td/span",
                reportDetails)));
            getActivityDetails = base.GetElementTextByXPath(string.Format(
                "//div[@id='_ctl3_allAssementDetail1']/table/tbody/tr[{0}]/td/div/table/tbody/tr/td/span",
                reportDetails));
            logger.LogMethodExit("RptActivityResultByStudentPage", "GetStudentAndSectionNameInReport",
                 base.IsTakeScreenShotDuringEntryExit);
            return getActivityDetails;
        }

        public string GetAverageScoreInTheReport()
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage", "GetAverageScoreInTheReport",
                base.IsTakeScreenShotDuringEntryExit);
            string getAverageScore = string.Empty;
            base.SwitchToLastOpenedWindow();
            bool gf = base.IsElementPresent(By.XPath("//div[@id='_ctl3_AveragePlaceHolder']"), 10);
            //this.SelectWindow();
            base.SwitchToLastOpenedWindow();
            base.WaitForElement(By.XPath("//div[@id='_ctl3_AveragePlaceHolder']/table/tbody/tr/td[1]/span"));
            getAverageScore = base.GetElementTextByXPath("//div[@id='_ctl3_AveragePlaceHolder']/table/tbody/tr/td[1]/span");
            logger.LogMethodExit("RptActivityResultByStudentPage", "GetAverageScoreInTheReport",
                 base.IsTakeScreenShotDuringEntryExit);
            return getAverageScore;
        }

        public bool GetStudentNameInActivityResultByStudent(string studentName)
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage",
                "GetActivityDetailsInActivityResultByStudent",
                base.IsTakeScreenShotDuringEntryExit);
            bool isStudentPresent = false;
            string getStudentName = string.Empty;
            base.SwitchToLastOpenedWindow();
            base.WaitForElement(By.XPath(".//*[@id='lblContainer']/div/div/table[2]/tbody/tr/td/div/table/tbody/tr[1]/td[1]/span"));
            int getStudentNameCount = base.GetElementCountByXPath(
                ".//*[@id='lblContainer']/div/div/table[2]/tbody/tr/td/div/table/tbody/tr");
            for (int i = 1; i <= getStudentNameCount; i++)
            {
                base.WaitForElement(By.XPath(string.Format(
                    ".//*[@id='lblContainer']/div/div/table[2]/tbody/tr/td/div/table/tbody/tr[{0}]/td[1]/span", i)), 10);
                getStudentName = base.GetElementTextByXPath(string.Format(
                     ".//*[@id='lblContainer']/div/div/table[2]/tbody/tr/td/div/table/tbody/tr[{0}]/td[1]/span", i));
                if (getStudentName == studentName)
                {
                    isStudentPresent = true;
                    break;

                }
                i++;
            }
            logger.LogMethodExit("RptActivityResultByStudentPage",
            "GetActivityDetailsInActivityResultByStudent",
                 base.IsTakeScreenShotDuringEntryExit);
            return isStudentPresent;
        }

        public string GetStudentScoreInActivityResultByStudent(int scoreRow)
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage",
                "GetStudentScoreInActivityResultByStudent",
                base.IsTakeScreenShotDuringEntryExit);
            string getScore = string.Empty;
            base.SwitchToLastOpenedWindow();
            bool jh = base.IsElementPresent(By.XPath(string.Format(
                "html/body/form/span[2]/div/div/table[2]/tbody/tr/td/div/table/tbody/tr[{0}]/td[2]/table/tbody/tr[2]/td/table[1]/tbody/tr/td[4]", scoreRow)), 10);
            base.WaitForElement(By.XPath(string.Format(
                "html/body/form/span[2]/div/div/table[2]/tbody/tr/td/div/table/tbody/tr[{0}]/td[2]/table/tbody/tr[2]/td/table[1]/tbody/tr/td[4]", scoreRow)), 10);
            getScore = base.GetElementTextByXPath(string.Format(
                "html/body/form/span[2]/div/div/table[2]/tbody/tr/td/div/table/tbody/tr[{0}]/td[2]/table/tbody/tr[2]/td/table[1]/tbody/tr/td[4]", scoreRow));
            string studentPercentage = getScore.Split(' ')[0];
            logger.LogMethodExit("RptActivityResultByStudentPage",
                "GetActivityDetailsInActivityResultByStudent",
                     base.IsTakeScreenShotDuringEntryExit);
            return studentPercentage;
        }

    }
}
