using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.StudyMaterialsExplorer
{
    public class StudentExplorePage : BasePage
    {
        //Purpose: Run code according To Browser Selection
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        string _foldername = null;

        //Purpose : To open the Benchmark Test 1 activity inside the Benchmark Tests folder under Practice Tab 
        public void NavigateToBenchmarkTest1ActivityAndOpen()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0_TreeViewStudent']"));
                for (int i = 1; i <= 15; i++)
                {
                    #region Browser Selection
                    if (Browser.Equals("FF") || Browser.Equals("GC"))
                    {
                        _foldername = WebDriver.FindElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0_TreeViewStudent']/table[" + i.ToString(CultureInfo.InvariantCulture) + "]")).Text.Trim();
                    }
                    if (Browser.Equals("IE"))
                    {
                        _foldername = WebDriver.FindElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0_TreeViewStudent']/table[" + i.ToString(CultureInfo.InvariantCulture) + "]")).GetAttribute("innerText");
                    }
                    #endregion Browser Selection

                    if (Browser.Equals("IE") || Browser.Equals("FF"))
                    {
                        if (_foldername.Contains("Benchmark Tests"))
                        {
                            WebDriver.FindElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0_TreeViewStudent']/table[" + i.ToString(CultureInfo.InvariantCulture) + "]/tbody/tr/td[2]/div/table/tbody/tr/td[2]/span")).SendKeys("");
                            WebDriver.FindElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0_TreeViewStudent']/table[" + i.ToString(CultureInfo.InvariantCulture) + "]/tbody/tr/td[2]/div/table/tbody/tr/td[2]/span")).Click();
                            Thread.Sleep(3000);
                            GenericHelper.WaitUntilElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0_TreeViewStudent']/div/table/tbody/tr/td[3]/div/table/tbody/tr/td[2]/span"));
                            WebDriver.FindElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0_TreeViewStudent']/div/table/tbody/tr/td[3]/div/table/tbody/tr/td[2]/span")).SendKeys("");
                            WebDriver.FindElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0_TreeViewStudent']/div/table/tbody/tr/td[3]/div/table/tbody/tr/td[2]/span")).Click();
                            Thread.Sleep(2000);
                            break;
                        }
                    }
                    if (Browser.Equals("GC"))
                    {
                        if (_foldername.Contains("Benchmark Tests"))
                        {
                            WebDriver.FindElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0_TreeViewStudent']/table[" + i.ToString(CultureInfo.InvariantCulture) + "]/tbody/tr/td[2]/div/table/tbody/tr/td[2]/span")).Click();
                            Thread.Sleep(3000);
                            GenericHelper.WaitUntilElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0_TreeViewStudent']/div/table/tbody/tr/td[3]/div/table/tbody/tr/td[2]/span"));
                            WebDriver.FindElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0_TreeViewStudent']/div/table/tbody/tr/td[3]/div/table/tbody/tr/td[2]/span")).Click();
                            Thread.Sleep(1000);
                            GenericHelper.WaitUtilWindow("Test");
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
