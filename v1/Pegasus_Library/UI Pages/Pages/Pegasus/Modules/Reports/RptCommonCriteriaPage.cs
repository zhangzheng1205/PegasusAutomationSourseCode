using System;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Reports
{
    public class RptCommonCriteriaPage : BasePage
    {

        //Purpose: To Select Students for generating the student activity report
        public void SelectStudents()
        {
            try
            {
                bool isReporstWindowOpened = GenericHelper.WaitUtilWindow("Reports");
                if (isReporstWindowOpened)
                {
                    GenericHelper.SelectWindow("Reports");
                    GenericHelper.WaitUntilElement(By.Id("Mainframe"));
                    WebDriver.SwitchTo().Frame("Mainframe");
                    GenericHelper.WaitUntilElement(By.ClassName("btn_sel_stu"));
                    IWebElement btnSelStu = WebDriver.FindElement(By.ClassName("btn_sel_stu"));
                    btnSelStu.Click();
                    WebDriver.SwitchTo().DefaultContent();
                    GenericHelper.SelectDefaultWindow();
                    GenericHelper.WaitUntilElement(By.Id("idFrameSelectStudentByGroup"));
                    WebDriver.SwitchTo().Frame("idFrameSelectStudentByGroup");
                    Thread.Sleep(4000);
                    GenericHelper.WaitUntilElement(By.Id("radSelectStudents__ctl1"));
                    string isCoursePresentInReport = WebDriver.FindElement(By.Id("radSelectStudents__ctl1")).Text;
                    if (isCoursePresentInReport != null)
                    {
                        GenericHelper.Logs("Course displayed while selecting student in the 'Student Activity' report.", "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs("Course not displayed while selecting student in the 'Student Activity' report.", "FAILED");
                        throw new NoSuchElementException("Course not displayed while selecting student in the 'Student Activity' report.");
                    }
                    GenericHelper.WaitUntilElement(By.Name("itemcheck"));
                    WebDriver.FindElement(By.Name("itemcheck")).Click();
                    GenericHelper.WaitUntilElement(By.Id("imgAddSections"));
                    WebDriver.FindElement(By.Id("imgAddSections")).Click();
                    Thread.Sleep(10000);
                    WebDriver.SwitchTo().DefaultContent();
                    GenericHelper.WaitUntilElement(By.Id("Mainframe"));
                    WebDriver.SwitchTo().Frame("Mainframe");
                    GenericHelper.WaitUntilElement(By.Id("_ctl0_InnerPageContent_txtStudents"));
                    string isStudentSelected = WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_txtStudents")).GetAttribute("value");
                    if (isStudentSelected != null)
                    {
                        GenericHelper.Logs("Student successfuly selected in order to generate student activity report.", "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs("Student not selected in order to generate student activity report.", "FAILED");
                        throw new SystemException("Student not selected in order to generate student activity report.");
                    }
                    WebDriver.SwitchTo().DefaultContent();
                }
                else
                {
                    GenericHelper.Logs("'Reports' window not opened.", "FAILED");
                    throw new NoSuchWindowException("'Reports' window not opened.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To click on RunReport button
        public void RunReport()
        {
            try
            {
                GenericHelper.SelectDefaultWindow();
                GenericHelper.WaitUntilElement(By.Id("Mainframe"));
                WebDriver.SwitchTo().Frame("Mainframe");
                GenericHelper.WaitUntilElement(By.Id("_ctl0:InnerPageContent:img_run_report"));
                WebDriver.FindElement(By.Id("_ctl0:InnerPageContent:img_run_report")).SendKeys("");
                WebDriver.FindElement(By.Id("_ctl0:InnerPageContent:img_run_report")).Click();
                Thread.Sleep(6000);
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
