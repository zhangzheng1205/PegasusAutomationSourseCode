using System;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Reports
{
    public class RptStudentActivityPage : BasePage
    {
        //Purpose : to click on DetailedReport link in 'Student Activity Report' page
        public void SelectDetailedReport()
        {
            Thread.Sleep(30000);//This I have added because of to avoid HTTP connection break
            try
            {
                bool isPagIsloading = GenericHelper.IsPopUpWindowPresent("Loading...");
                if (isPagIsloading)
                {
                    GenericHelper.SelectWindow("Loading...");
                    bool waitForReportGetLoaded = GenericHelper.PageLoadingProcessing();
                    if (waitForReportGetLoaded)
                    {
                        GenericHelper.Logs("Loading page has been loaded and navigated to the next page.", "Passed");
                    }
                    else
                    {
                        GenericHelper.Logs("Loading page is still loading and did not navigate to the next page.", "Failed");
                        throw new SystemException("Loading page is still loading and did not navigate to the next page.");
                    }
                }
                bool isStudentActivityWindowOpened = GenericHelper.WaitUtilWindow("Student Activity Report");
                if (isStudentActivityWindowOpened)
                {
                    GenericHelper.SelectWindow("Student Activity Report");
                    GenericHelper.WaitUntilElement(By.XPath("//div[@id='DivGrid']/table/tbody/tr/td[13]/span"));
                    WebDriver.FindElement(By.XPath("//div[@id='DivGrid']/table/tbody/tr/td[13]/span")).Click();
                    Thread.Sleep(60000); // This I added because to avoid HTTP connection break while launching report
                }
                else
                {
                    GenericHelper.Logs("'Student Activity Report' pop-up not found.", "FAILED");
                    throw new NoSuchWindowException("'Student Activity Report' pop-up not found.");
                }
            }
            catch (WebDriverException e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isDetailedStudentActivityReportWindowOpened = GenericHelper.IsPopUpWindowPresent("Student Activity Report");
                if (isDetailedStudentActivityReportWindowOpened)
                {
                    GenericHelper.SelectWindow("'Student Activity Report");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        //Purpose: to close 'Student Activity Report' window
        public void CloseWindow()
        {
            try
            {
                GenericHelper.SelectWindow("Student Activity Report");
                GenericHelper.WaitUntilElement(By.ClassName("btn_syn_s"));
                WebDriver.FindElement(By.ClassName("btn_syn_s")).Click();
                bool isDetailedStudentActivityReportClosed = GenericHelper.IsPopUpClosed(2);
                if (isDetailedStudentActivityReportClosed)
                {
                    GenericHelper.Logs("'Student Activity Report' pop-up closed successfully.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("'Student Activity Report' pop-up not closed successfully.", "FAILED");
                    throw new Exception("'Student Activity Report' pop-up not closed successfully.");
                }
            }
            catch (WebDriverException e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isDetailedStudentActivityReportWindowOpened = GenericHelper.IsPopUpWindowPresent("Student Activity Report");
                if (isDetailedStudentActivityReportWindowOpened)
                {
                    GenericHelper.SelectWindow("'Student Activity Report");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }
    }
}
