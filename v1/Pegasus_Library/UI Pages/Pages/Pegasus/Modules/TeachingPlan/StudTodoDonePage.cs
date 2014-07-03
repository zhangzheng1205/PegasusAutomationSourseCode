using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TeachingPlan
{
    public class StudTodoDonePage : BasePage 
    {

        public void SelectPastDueInDropDown()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("DdlView"));
                WebDriver.FindElement(By.Id("DdlView")).SendKeys("");
                new SelectElement(WebDriver.FindElement(By.Id("DdlView"))).SelectByText("Past Due");
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
            
        }

        public string getDateTextOfPastDueAsset(string asset)
        {
            GenericHelper.SelectDefaultWindow();
            WebDriver.SwitchTo().Frame("ifrmCoursePreview");
            int rowcnt = WebDriver.FindElements(By.XPath("//div[@id='TodoListpastDue']/div")).Count();
            string dateText = string.Empty;
            for (int i = 2; i <= rowcnt;i++ )
            {
               // WebDriver.FindElement(By.XPath("//div[@id='TodoListpastDue']/div[" + i.ToString() + "]")).SendKeys("");
                string assetName = WebDriver.FindElement(By.XPath("//div[@id='TodoListpastDue']/div[" + i.ToString() + "]")).GetAttribute("AssetName");
                if(assetName.Contains(asset))
                {
                   dateText= WebDriver.FindElement(
                        By.XPath("//div[@id='TodoListpastDue']/div[" + i.ToString() +
                                 "]/div/div[2]/table/tbody/tr/td[2]/div[4]")).GetAttribute("innerText");
                }
            }
            return dateText;
        }

        public void OpenStudyPlan(string asset)
        {

            GenericHelper.SelectDefaultWindow();
            WebDriver.SwitchTo().Frame("ifrmCoursePreview");
            int rowcnt = WebDriver.FindElements(By.XPath("//div[@id='TodoListpastDue']/div")).Count();
            string dateText = string.Empty;
            for (int i = 2; i <= rowcnt; i++)
            {
                // WebDriver.FindElement(By.XPath("//div[@id='TodoListpastDue']/div[" + i.ToString() + "]")).SendKeys("");
                string assetName = WebDriver.FindElement(By.XPath("//div[@id='TodoListpastDue']/div[" + i.ToString() + "]/div/div[2]/table/tbody/tr/td[2]/div")).GetAttribute("title");
                if (assetName.Contains(asset))
                {
                  IWebElement sp= WebDriver.FindElement(By.XPath("//div[@id='TodoListpastDue']/div[" + i.ToString() +"]/div/div[2]/table/tbody/tr/td[2]/div"));
                    Actions builder = new Actions(WebDriver);
                    builder.MoveToElement(sp).Click().Perform();
                    
                }
            }
            
        }
    }
}
