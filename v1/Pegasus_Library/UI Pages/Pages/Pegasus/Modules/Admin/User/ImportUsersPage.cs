using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.User
{
    public class ImportUsersPage : BasePage
    {
        //Purpose: To Import The Bulk User Upload File
        public void ImportUsers()
        {
            try
            {
                GenericHelper.SelectWindow("Import Users");
                GenericHelper.FileUpload("BulkUser_Template.xls", By.Id("impBulkusers"));
                IWebElement closebutton = WebDriver.FindElement(By.Id("imgSaveClose"));
                closebutton.Click();
                Thread.Sleep(2000);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["WaitUntillElementSeconds"]);
                while (sw.Elapsed.Minutes < minutesToWait)
                {
                    if (sw.Elapsed.Minutes == minutesToWait && GenericHelper.IsWindowPresent("Import Users"))
                    {
                        if (GenericHelper.IsPopUpWindowPresent("Pegasus"))
                        {
                            WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == "Pegasus");
                            GenericHelper.WaitUntilElement(By.Id("imgOk"));
                            WebDriver.FindElement(By.Id("imgOk")).Click();
                            bool isImportUserPopUpWindowClosed = GenericHelper.IsPopUpClosed(4);
                            if (isImportUserPopUpWindowClosed)
                            {
                                GenericHelper.Logs(string.Format("Import Users window is closed after under the required time initerval '{0}' seconds", minutesToWait), "Passed");
                            }
                        }
                        else
                        {
                           // WebDriver.Close();
                            bool isImportUserWindowClosed = GenericHelper.IsPopUpClosed(3);
                            if (isImportUserWindowClosed)
                            {
                                GenericHelper.Logs(string.Format("Import Users window not closed after under the required time initerval '{0}' seconds", minutesToWait), "Failed");
                                break;
                            }
                        }
                    }
                    if (GenericHelper.IsPopUpWindowPresent("Pegasus"))
                    {
                        WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == "Pegasus");
                        GenericHelper.WaitUntilElement(By.Id("imgOk"));
                        WebDriver.FindElement(By.Id("imgOk")).Click();
                        bool isImportUserPopUpClosed = GenericHelper.IsPopUpClosed(4);
                        if (isImportUserPopUpClosed)
                        {
                            GenericHelper.Logs(string.Format("Import Users window is closed after under the required time initerval '{0}' seconds", minutesToWait), "Passed");
                            break;
                        }
                    }
                }
            }
            catch
                (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Import Users"))
                {
                    GenericHelper.SelectWindow("Import Users");
                    WebDriver.Close();
                }
                if (GenericHelper.IsPopUpWindowPresent("Pegasus"))
                {
                    GenericHelper.SelectWindow("Pegasus");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }
    }
}
