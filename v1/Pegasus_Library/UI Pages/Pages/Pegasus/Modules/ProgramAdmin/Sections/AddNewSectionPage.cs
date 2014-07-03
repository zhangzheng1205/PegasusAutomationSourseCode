using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.ProgramAdmin.Sections
{
    public class AddNewSectionPage : BasePage
    {
        /// <summary>
        /// Purpose: Add New Section
        /// </summary>
        public string AddNewSection()
        {
            string sectionName = GenericHelper.GenerateUniqueVariable("Section");
           try
            {
                GenericHelper.SelectWindow("Program Administration");
                WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                GenericHelper.WaitUntilElement(By.XPath("//IMG[@class='CursorHand']"));
                WebDriver.FindElement(By.XPath("//IMG[@class='CursorHand']")).Click();
                GenericHelper.SelectWindow("Create New Section");
                GenericHelper.WaitUntilElement(By.Id("txtCourseName"));
                WebDriver.FindElement(By.Id("txtCourseName")).SendKeys(sectionName);
                GenericHelper.WaitUntilElement(By.Id("templatelist"));
                new SelectElement(WebDriver.FindElement(By.Id("templatelist"))).SelectByIndex(1);
                GenericHelper.WaitUntilElement(By.Id("noslist"));
                WebDriver.FindElement(By.Id("noslist")).SendKeys("1");
                string startDate = DateTime.Now.ToString("MM/dd/yyyy");
                string endDate = DateTime.Now.AddDays(90).ToString("MM/dd/yyyy");
                GenericHelper.WaitUntilElement(By.Id("txtStartDate"));
                WebDriver.FindElement(By.Id("txtStartDate")).SendKeys(startDate);
                GenericHelper.WaitUntilElement(By.Id("txtEndDate"));
                WebDriver.FindElement(By.Id("txtEndDate")).SendKeys(endDate);
                GenericHelper.WaitUntilElement(By.Id("btnAddClose"));
                WebDriver.FindElement(By.Id("btnAddClose")).Click();
                GenericHelper.SelectWindow("Program Administration");
                GenericHelper.VerifySuccesfullMessage("Section added successfully.");
                WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody/tr/td[2]"));
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
                while (sw.Elapsed.Minutes < minutesToWait)
                {
                    IWebElement assignedToCopyText = WebDriver.FindElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody"));
                    if (assignedToCopyText.Text.Contains("[Request is Processing") == false) break;
                    {
                        WebDriver.SwitchTo().DefaultContent();
                        GenericHelper.SelectWindow("Program Administration");
                        WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                        Thread.Sleep(6000);
                        GenericHelper.WaitUntilElement(By.PartialLinkText("Search"));
                        WebDriver.FindElement(By.PartialLinkText("Search")).Click();
                        WebDriver.SwitchTo().ActiveElement();
                        GenericHelper.WaitUntilElement(By.Id("txtSectionDetail"));
                        WebDriver.FindElement(By.Id("txtSectionDetail")).Clear();
                        WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(sectionName);
                        GenericHelper.WaitUntilElement(By.Id("lnkbuttonsearch"));
                        WebDriver.FindElement(By.Id("lnkbuttonsearch")).Click();
                        Thread.Sleep(8000);
                        WebDriver.SwitchTo().DefaultContent();
                        GenericHelper.SelectWindow("Program Administration");
                        GenericHelper.WaitUntilElement(By.Id("_ctl0_PageContent_ifrmMiddle"));
                        WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                        GenericHelper.WaitUntilElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody/tr/td[2]"));
                    }
                }
                sw.Stop();
                sw = null;
                IWebElement redTextPresent = WebDriver.FindElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody/tr/td[2]"));
                if (redTextPresent.Text.Contains("[Request is Processing"))
                {
                    GenericHelper.Logs(string.Format("[Request is Processing state has not validated under:'{0}' minutes for copying section", minutesToWait), "FAILED");
                    WebDriver.Close();
                    Assert.Fail(string.Format("[Request is Processing state has not validated under:'{0}' minutes for copying section", minutesToWait));
                }
                else
                {
                    GenericHelper.Logs("Section active state validated successfully in prescribed interval of time.",
                                       "PASSED");
                }
              
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
                
            }
            return sectionName;
        }
    }
}
