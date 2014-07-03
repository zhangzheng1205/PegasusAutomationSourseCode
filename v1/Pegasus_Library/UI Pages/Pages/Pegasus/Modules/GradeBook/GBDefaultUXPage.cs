using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using OpenQA.Selenium.Interactions;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook
{
    public class GBDefaultUXPage : BasePage
    {
        //Purpose: To Search The Activity By Name
        public void SearchActivityByTitle(string actName)
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("Iframe1"));
                WebDriver.FindElement(By.Id("Iframe1"));
                WebDriver.SwitchTo().Frame("Iframe1");
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='rptrFolderContent']/div[2]/div[2]/span"));
                WebDriver.FindElement(By.XPath("//div[@id='rptrFolderContent']/div[2]/div[2]/span")).Click();
                GenericHelper.IsElementPresent(By.XPath("//div[@id='rptrFolderContent']/div[2]/div[@title='STUDENT ACTIVITIES MANUAL']"));
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='rptrFolderContent']/div[2]/div[@title='STUDENT ACTIVITIES MANUAL']"));
                WebDriver.FindElement(By.XPath("//div[@id='rptrFolderContent']/div[2]/div[@title='STUDENT ACTIVITIES MANUAL']")).Click();
                WebDriver.SwitchTo().DefaultContent();

                GenericHelper.WaitUntilElement(By.Id("srcGBFrame"));
                WebDriver.FindElement(By.Id("srcGBFrame"));
                WebDriver.SwitchTo().Frame("srcGBFrame");
                GenericHelper.IsElementPresent(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[2]/div"));


                GenericHelper.WaitUntilElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[2]/div"));
                IWebElement triangleButton = WebDriver.FindElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[2]/div"));
                new Actions(WebDriver).MoveToElement(triangleButton).Build().Perform();
                new Actions(WebDriver).MoveToElement(triangleButton).Click().Perform();
                Thread.Sleep(3000);
                //GenericHelper.WaitUntilElement(By.Id("titleSearch"));
                //WebDriver.FindElement(By.Id("titleSearch")).Click();
                //GenericHelper.WaitUntilElement(By.Id("txtSearch"));
                //WebDriver.FindElement(By.Id("txtSearch")).Clear();
                //WebDriver.FindElement(By.Id("txtSearch")).SendKeys(actName);
                //SendKeys.SendWait("{ENTER}");
                //Thread.Sleep(10000);
                //string activityName;
                //int cnt = 0;
                //GenericHelper.WaitUntilElement(By.Id("srcGBFrame"));
                //WebDriver.SwitchTo().Frame("srcGBFrame");
                //do
                //{
                //    GenericHelper.WaitUntilElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[2]/span/a"));
                //    activityName = WebDriver.FindElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[2]/span/a")).GetAttribute("title");
                //    Thread.Sleep(2000);
                //    cnt = cnt + 1;
                //    if (cnt == 60)
                //    {
                //        GenericHelper.Logs("Activity Not displayed after 2 Minutes of search", "FAILED");
                //        break;
                //    }

                //} while (activityName != actName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }
    }
}
