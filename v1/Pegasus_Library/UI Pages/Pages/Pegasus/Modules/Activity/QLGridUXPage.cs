using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Actions = OpenQA.Selenium.Interactions.Actions;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Activity
{
    public class QLGridUXPage : BasePage
    {
        // Calling of other classes

        private string _strConnection =
            ConfigurationManager.ConnectionStrings["Pegasus_SpecFlow.Properties.Settings.BDD_DBConnectionString"].
                ConnectionString;

        // Purpose - to click search/view button

        public void ToClickSearchViewbutton()
        {

            string getQuestionName = DatabaseTools.GetQuestionName(Enumerations.QuestionType.SCO);
            WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_ucSearchPanel_txtSearch")).SendKeys(getQuestionName);
            WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_ucSearchPanel_cmdSearchGo")).Click();
            WebDriver.SwitchTo().ActiveElement();
            IWebElement toverifytablecontent = WebDriver.FindElement(By.Id("dgContentLibrary$contentCntr"));
            if (toverifytablecontent.Displayed)
            {
                GenericHelper.Logs("SCO Questions table has been loaded successfully", "Passed");
            }
            IWebElement menu = WebDriver.FindElement(By.XPath("//table[@id='dgContentLibrary']/descendant::td[contains(@class, 'es_qlTD')]"));
            Actions builder = new Actions(WebDriver);
            builder.MoveToElement(menu).Build().Perform();
            IWebElement menu1 = WebDriver.FindElement(By.XPath("//table[@id='dgContentLibrary']/descendant::td[contains(@class, 'es_qlTD2')]"));
            builder.MoveToElement(menu1).Click().Perform();
            IWebElement submenu = WebDriver.FindElement(By.PartialLinkText("Preview"));
            builder.MoveToElement(submenu).Click().Perform();
            Thread.Sleep(3000);
            GenericHelper.SelectWindow("Tryout");
            bool toVerifyFlash = WebDriver.FindElement(By.XPath("//div[starts-with(@id,'divSCOFrame')]")).Displayed;
            if (toVerifyFlash)
            {
                GenericHelper.Logs("SCO Frame is displayed successfully", "Passed");
            }
            bool toVerifyFlashFrame = WebDriver.FindElement(By.XPath("//iframe[starts-with(@id, 'iFrameSCO')]")).Displayed;
            if (toVerifyFlashFrame)
            {
                GenericHelper.Logs("SCO Content is displayed successfully", "Passed");
            }

            WebDriver.SwitchTo().Frame(0);

            IWebElement isErrorPresent = WebDriver.FindElement(By.TagName("body"));
            if (isErrorPresent.Text.Contains("Server"))
            {
                GenericHelper.Logs("There is no SCO Content", "Failed");
            }
            Thread.Sleep(3000);
            WebDriver.Close();
        }
    }
}
