using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Reports
{
    public class RptDetailedStudentActivityPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //Purpose: To verify the grades displayed in Detailed Student Activity Page
        public void VerifyGradeDisplayed()
        {
            Thread.Sleep(30000); //This I have added because of to avoid HTTP connection break
            try
            {
                bool isPagIsloading = GenericHelper.IsPopUpWindowPresent("Loading...");
                if (isPagIsloading)
                {
                    GenericHelper.SelectWindow("Loading...");
                    bool verifyLoadingText = GenericHelper.PageLoadingProcessing();
                    if (verifyLoadingText)
                    {
                        GenericHelper.Logs("Loading page has been loaded and navigated to the next page", "Passed");
                    }
                    else
                    {
                        GenericHelper.Logs("Loading page is still loading and did not navigate to the next page", "Failed");
                    }
                }
                bool isDetailedStudentActivityWindowOpened = GenericHelper.WaitUtilWindow("Detailed Student Activity Report");
                if (isDetailedStudentActivityWindowOpened)
                {
                    GenericHelper.SelectWindow("Detailed Student Activity Report");
                    GenericHelper.WaitUntilElement(By.Name("rptSessionDetailsContainer:_ctl1:btnExpandcolapse"));
                    WebDriver.FindElement(By.Name("rptSessionDetailsContainer:_ctl1:btnExpandcolapse")).Click();
                    GenericHelper.WaitUntilElement(By.ClassName("cssRptBstrstyle3"));
                    string isRecordDisplayedinreports = WebDriver.FindElement(By.ClassName("cssRptBstrstyle3")).Text;
                    if (isRecordDisplayedinreports.Contains("Benchmark Test 1"))
                    {
                        GenericHelper.Logs("'Student Activity' report has been successfully launched.", "PASSED");
                        string score = null;
                        if (Browser.Equals("IE"))
                        {
                            score = (WebDriver.FindElement(By.XPath("//tr[@Class='cssRptBstrstyle3']/td[6]")).GetAttribute("innerText")).Trim();
                        }
                        if (Browser.Equals("FF") || Browser.Equals("GC"))
                        {
                            score = (WebDriver.FindElement(By.XPath("//div[@id='rptSessionDetailsContainer__ctl1_InnerDiv']/table[2]/tbody/tr/td[6]")).Text).Trim();
                        }
                        if (score != null)
                        {
                            decimal intscore = Convert.ToDecimal(score.TrimEnd('%'));
                            if (intscore <= 0 || intscore > 0)
                            {
                                GenericHelper.Logs(string.Format("Student grade '{0}' has successfully displayed in 'Detailed Student Activity report'.", score), "PASSED");
                            }
                            else
                            {
                                GenericHelper.Logs(score + "grade not displayed in the 'Detailed Student Activity' report.", "FAILED");
                                throw new NoSuchElementException(score + "grade not displayed in the 'Detailed Student Activity' report.");
                            }
                        }
                    }
                    else
                    {
                        GenericHelper.Logs("'Student Activity' report has not launched.", "FAILED");
                    }
                }
                else
                {
                    GenericHelper.Logs("'Detailed Student Activity' report window not opened.", "FAILED");
                    throw new NoSuchWindowException("'Detailed Student Activity' report window not opened.");
                }
            }
            catch (WebDriverException e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isDetailedStudentActivityReportWindowOpened = GenericHelper.IsPopUpWindowPresent("Detailed Student Activity Report");
                if (isDetailedStudentActivityReportWindowOpened)
                {
                    GenericHelper.SelectWindow("Detailed Student Activity Report");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        // Purpose : to close the Detailed Student Activity Report page
        public void CloseWindow()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.ClassName("btn_syn_s"));
                WebDriver.FindElement(By.ClassName("btn_syn_s")).Click();
                bool isDetailedStudentActivityReportClosed = GenericHelper.IsPopUpClosed(3);
                if (isDetailedStudentActivityReportClosed)
                {
                    GenericHelper.Logs("'Detailed Student Activity Report' pop-up closed successfully.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("'Detailed Student Activity Report' pop-up not closed successfully.", "FAILED");
                    throw new Exception("'Detailed Student Activity Report' pop-up not closed successfully.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isDetailedStudentActivityReportWindowOpened = GenericHelper.IsPopUpWindowPresent("Detailed Student Activity Report");
                if (isDetailedStudentActivityReportWindowOpened)
                {
                    GenericHelper.SelectWindow("Detailed Student Activity Report");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }
    }
}
