using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus.PublishingNotesPage
{
    public class PublishingNotesPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        //Purpose:// Constant Declaration
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        // Purpose:  To enter Publishing notes
        public void EnterPublishNotes()
        {
            WebDriver.FindElement(By.Id("txtPublishNotes")).SendKeys("Automation: Course Published");
        }

        //Purpose: To Click on Pulish button
        public void ClickPublishButton()
        {
            try
            {
                if (Browser.Equals("FF"))
                {
                    GenericHelper.WaitUntilElement(By.Id("imgbtnSave"));
                    WebDriver.FindElement(By.Id("imgbtnSave")).SendKeys("");
                    WebDriver.FindElement(By.Id("imgbtnSave")).Click();
                    Thread.Sleep(6000);
                }
                if (Browser.Equals("GC") || Browser.Equals("IE"))
                {
                    GenericHelper.WaitUntilElement(By.Id("imgbtnSave"));
                    IWebElement menu = WebDriver.FindElement(By.Id("imgbtnSave"));
                    var builder = new Actions(WebDriver);
                    builder.MoveToElement(menu).Build().Perform();
                    builder.MoveToElement(menu).Click().Perform();
                    Thread.Sleep(6000);
                }
                bool isPublishingWindowClosed = GenericHelper.IsPopUpClosed(2);
                if (isPublishingWindowClosed)
                {
                    GenericHelper.Logs("'Publishing Notes' pop-up has been closed successfully", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("'Publishing Notes' pop-up has not been closed successfully", "FAILED");
                    WebDriver.Close();
                    throw new Exception("'Publishing Notes' pop-up has not been closed successfully");
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
