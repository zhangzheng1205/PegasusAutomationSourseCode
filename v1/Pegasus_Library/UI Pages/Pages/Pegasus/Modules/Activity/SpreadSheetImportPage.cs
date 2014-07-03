using System;
using System.Configuration;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Activity
{
    public class SpreadSheetImportPage : BasePage
    {
        // Purpose: Calling of other classes
        private string _strConnection = ConfigurationManager.ConnectionStrings["Pegasus_SpecFlow.Properties.Settings.BDD_DBConnectionString"].ConnectionString;

        // Purpose: Method to import SCO Meta Data 
        public void ImportScoMetaData()
        {
            GenericHelper.SelectWindow("Import SCO Metadata");
            WebDriver.SwitchTo().ActiveElement();
            string filePath = ConfigurationManager.AppSettings["SCOFilePath"];
            WebDriver.FindElement(By.Id("txtSpreadsheetFile")).SendKeys(filePath);
            WebDriver.FindElement(By.Id("cmdOK")).Click();
            GenericHelper.WaitUntilElement(By.XPath("//img[contains(@src,'/images/icn_success.gif')]"));
            IWebElement bodyTag = WebDriver.FindElement(By.TagName("body"));
            if (bodyTag.Text.Contains("Import is in progress and result will be sent in email. Click Cancel to close this window."))
            {
                GenericHelper.Logs("Import text has been verified", "Passed");
            }
           
            WebDriver.FindElement(By.Id("imgBtnCancel")).Click();
            GenericHelper.SelectWindow("Question Library");
        }
    }
}
