using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Template
{
    public class ManageTemplatePage : BasePage
    {
      //Purpose: Run code according To Browser Selection
        private static readonly string Browser = ConfigurationManager.AppSettings["browser"];

       //Purpose: Method to Select Licenses Tab
        public void ToSelectAddTemplate()
        {
            try
            {
                GenericHelper.SelectWindow("Manage Organization");
                WebDriver.SwitchTo().Frame("frm");
                GenericHelper.WaitUntilElement(By.XPath("//IMG[@class='tdAddImg']"));
                WebDriver.FindElement(By.XPath("//IMG[@class='tdAddImg']")).Click();
                WebDriver.FindElement(By.XPath("//TR[@id='trTemplate']")).Click();
                WebDriver.SwitchTo().ActiveElement();
                bool isAddTemplateWindowOpened = GenericHelper.WaitUtilWindow("Add Template");
                if (isAddTemplateWindowOpened)
                {
                    //Purpose: Calling Method To Create Template
                    new AddTemplatePage().ToCreateTemplate();
                }
                else
                {
                    GenericHelper.Logs("'Add Template' pop-up not opened for template creation.", "FAILED");
                    Assert.Fail("'Add Template' pop-up not opened for template creation.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Manage Organization"))
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Method To Verify Assigned To Copy State
        public void ToSearchForAssigned()
        {
            try
            {
                GenericHelper.SelectWindow("Manage Organization");
                WebDriver.SwitchTo().Frame("frm");
                GenericHelper.WaitUntilElement(By.Id("spnSearch"));
                WebDriver.FindElement(By.Id("spnSearch")).Click();
                WebDriver.SwitchTo().ActiveElement();
                string templateName = DatabaseTools.GetTemplate();
                GenericHelper.WaitUntilElement(By.Id("txtSectionDetail"));
                WebDriver.FindElement(By.Id("txtSectionDetail")).Clear();
                WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(templateName);
                GenericHelper.WaitUntilElement(By.Id("btnSearch"));
                WebDriver.FindElement(By.Id("btnSearch")).Click();
                //Purpose:  Verify Template [Assigned to Copy] State
                GenericHelper.WaitUntilElement(By.Id("ifrmleft"));
                WebDriver.SwitchTo().Frame("ifrmleft");
                GenericHelper.WaitUntilElement(By.Id("grdTemplateClass"));
                //Purpose: Executing Code according To Browser Selection

                #region Browser Selection

                if (Browser.Equals("FF") || Browser.Equals("GC"))
                {
                    if (WebDriver.FindElement(By.Id("grdTemplateClass")).Text.Contains("Template"))
                    {
                        GenericHelper.Logs(
                            string.Format("Template '{0}' Found after searching in the grid.", templateName), "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs(string.Format("Template '{0}' not Found after searching in the grid.", templateName), "FAILED");
                        Assert.Fail(string.Format("Template '{0}' not Found after searching in the grid.", templateName));
                    }
                }
                if (Browser.Equals("IE"))
                {
                    if (WebDriver.FindElement(By.Id("grdTemplateClass")).GetAttribute("innerText").Contains("Template"))
                    {
                        GenericHelper.Logs(
                            string.Format("Template '{0}' Found after searching in the grid.", templateName), "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs(string.Format("Template '{0}' not Found after searching in the grid.", templateName), "FAILED");
                        Assert.Fail(string.Format("Template '{0}' not Found after searching in the grid.", templateName));
                    }
                }

                #endregion Browser Selection

                Stopwatch sw = new Stopwatch();
                sw.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
                while (sw.Elapsed.Minutes < minutesToWait)
                {
                    IWebElement redTextPresent = WebDriver.FindElement(By.Id("grdTemplateClass"));
                    if (redTextPresent.Text.Contains("[Assigned to copy]") == false) break;
                    {
                        WebDriver.SwitchTo().DefaultContent();
                        GenericHelper.SelectWindow("Manage Organization");
                        WebDriver.SwitchTo().Frame("frm");
                        Thread.Sleep(6000);
                        GenericHelper.WaitUntilElement(By.Id("spnSearch"));
                        WebDriver.FindElement(By.Id("spnSearch")).Click();
                        WebDriver.SwitchTo().ActiveElement();
                        GenericHelper.WaitUntilElement(By.Id("txtSectionDetail"));
                        WebDriver.FindElement(By.Id("txtSectionDetail")).Clear();
                        WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(templateName);
                        GenericHelper.WaitUntilElement(By.Id("btnSearch"));
                        WebDriver.FindElement(By.Id("btnSearch")).Click();
                        Thread.Sleep(8000);
                        GenericHelper.WaitUntilElement(By.Id("ifrmleft"));
                        WebDriver.SwitchTo().Frame("ifrmleft");
                        GenericHelper.WaitUntilElement(By.Id("grdTemplateClass"));
                    }
                }
                sw.Stop();
                sw = null;
                IWebElement redTextPresent1 = WebDriver.FindElement(By.Id("grdTemplateClass"));
                if (redTextPresent1.Text.Contains("Assigned to copy"))
                {

                    GenericHelper.Logs(string.Format("[AssignedToCopy] state has not validated under:'{0}' minutes for copying '{1}'.", minutesToWait, templateName), "FAILED");
                   Assert.Fail(string.Format("[AssignedToCopy] state has not validated under:'{0}' minutes for copying '{1}'.", minutesToWait, templateName));
                }
                else
                {
                    GenericHelper.Logs(
                        string.Format("[AssignedToCopy] state has validated under:'{0}' minutes for copying '{1}'.",
                                      minutesToWait, templateName), "PASSED");
                }
                WebDriver.Close();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Manage Organization"))
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        

       
    }
}
