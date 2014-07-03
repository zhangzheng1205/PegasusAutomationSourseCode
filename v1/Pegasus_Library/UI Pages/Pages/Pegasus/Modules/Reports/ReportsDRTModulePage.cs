using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Reports
{
    public class ReportsDRTModulePage: BasePage
    {
        // Purpose : To get class avg in study plan results reports
        public string GetClassAvg()
        {
            try 
            {
            GenericHelper.WaitUntilElement(By.Id("tdClassAvg"));
            string classAvg = WebDriver.FindElement(By.Id("tdClassAvg")).GetAttribute("innerText");

            string[] classavg = classAvg.Split('%');
            return classavg[0];
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }


        // purpose : to get user avg of study plan results reports
        public string GetUserAvg()
        {
            try 
            {
            GenericHelper.WaitUntilElement(By.Id("tdView"));
            string userAvg = WebDriver.FindElement(By.Id("tdView")).GetAttribute("innerText");

            string[] usrAvg = userAvg.Split('%');
            return usrAvg[0];
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }


        // Purpose : To get class avg of 2nd study plan in study plan results reports
        public string GetClassAvgOfSecondSp()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='MainDiv']/table[2]/tbody/tr[2]/td[6]"));
                string classAvg = WebDriver.FindElement(By.XPath("//div[@id='MainDiv']/table[2]/tbody/tr[2]/td[6]")).GetAttribute("innerText");

                string[] classavg = classAvg.Split('%');
                return classavg[0];
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }


        // purpose : to get user avg of 2nd study plan in study plan results reports
        public string GetUserAvgOfSecondSp()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='MainDiv']/table[3]/tbody/tr[2]/td/table/tbody/tr[3]/td[4]/table/tbody/tr/td[6]"));
                string userAvg = WebDriver.FindElement(By.XPath("//div[@id='MainDiv']/table[3]/tbody/tr[2]/td/table/tbody/tr[3]/td[4]/table/tbody/tr/td[6]")).GetAttribute("innerText");

                string[] usrAvg = userAvg.Split('%');
                return usrAvg[0];
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
