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
    public class RptSelectStudentsPage : BasePage
    {
        public void SelectStudent(string student)
        {
            try 
            {
            GenericHelper.WaitUntilElement(By.Id("GridStudent"));
            int rowCnt = WebDriver.FindElements(By.XPath("//table[@id='GridStudent']/tbody/tr")).Count;

            for (int i = 2; i <= rowCnt; i++)
            {
                string Student = WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/tbody/tr[" + i.ToString() + "]/td[2]/span")).GetAttribute("title");

                if (Student.Contains(student))
                {
                    WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/tbody/tr[" + i.ToString() + "]/td/input")).Click();
                    break;
                }

            }
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        public void ClickAddButton()
        {
            try 
            {
            WebDriver.FindElement(By.Id("imgAddSections")).Click();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        public void CheckSelectAll()
        {
            try 
            {
            WebDriver.FindElement(By.Id("chkSelectAll")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
