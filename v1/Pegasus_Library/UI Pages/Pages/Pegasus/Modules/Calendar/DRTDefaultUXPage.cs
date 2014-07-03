using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pegasus_DataAccess;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Calendar
{
    public class DrtDefaultUxPage : BasePage
    {

        //Pupose: Run code on the basis of Browser Selected
        private static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //Purpose - to click on I accept button
        public void EditTheStudyPlan()
        {
            try
            {
                // search study plan
                SearchStudyPlan();
                // click on cmenu of study plan
                ClickOnCmenuStudyPlan();
                GenericHelper.WaitUntilElement(By.Id("1"));
                WebDriver.FindElement(By.Id("1")).Click();
                GenericHelper.SelectWindow("Edit Study Plan");
                Assert.AreEqual("Edit Study Plan", WebDriver.Title);
                GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_txtModuleName"));
                WebDriver.FindElement(By.Id("_ctl0__ctl0_phBody_PageContent_txtModuleName")).Click();
                WebDriver.FindElement(By.Id("_ctl0__ctl0_phBody_PageContent_txtModuleName")).Clear();
                WebDriver.FindElement(By.Id("_ctl0__ctl0_phBody_PageContent_txtModuleName")).SendKeys(
                    "Readiness Check ChPA Edited");
                GenericHelper.WaitUntilElement(By.CssSelector("#_ctl0__ctl0_phBody_PageContent_lbtnSave > span > span"));
                WebDriver.FindElement(By.CssSelector("#_ctl0__ctl0_phBody_PageContent_lbtnSave > span > span")).Click();
                GenericHelper.SelectWindow("Calendar");
                Assert.AreEqual("Calendar", WebDriver.Title);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }

        /// <summary>
        /// This method is to search the study plan and click on cmenu
        /// </summary>
        public void SearchStudyPlan()
        {
            GenericHelper.SelectWindow("Calendar");
            bool thinkingIndicatornotShown = GenericHelper.ThinkingIndicatorProcessing();
            if (thinkingIndicatornotShown)
            {
                GenericHelper.Logs("Thinking Indicator has been loaded", "Passed");
            }
            else
            {
                Assert.Fail("Thinking Indicator is still showing");
            }
            Assert.AreEqual("Calendar", WebDriver.Title);
            GenericHelper.WaitUntilElement(
                By.Id("ctl00_ctl00_phBody_PageContent_ucLeftNavigationContainer_ucContentFilter_acSearchPanel_txtSearch"));
            WebDriver.FindElement(
                By.Id("ctl00_ctl00_phBody_PageContent_ucLeftNavigationContainer_ucContentFilter_acSearchPanel_txtSearch"))
                .Click
                ();
            WebDriver.FindElement(
                By.Id("ctl00_ctl00_phBody_PageContent_ucLeftNavigationContainer_ucContentFilter_acSearchPanel_txtSearch"))
                .Clear
                ();
            WebDriver.FindElement(
                By.Id("ctl00_ctl00_phBody_PageContent_ucLeftNavigationContainer_ucContentFilter_acSearchPanel_txtSearch"))
                .
                SendKeys("Readiness Check ChPA");
            GenericHelper.WaitUntilElement(
                (By.Id(
                    "ctl00_ctl00_phBody_PageContent_ucLeftNavigationContainer_ucContentFilter_acSearchPanel_btnSearchGo")));
            IWebElement goButton = WebDriver.FindElement(
                   By.Id(
                       "ctl00_ctl00_phBody_PageContent_ucLeftNavigationContainer_ucContentFilter_acSearchPanel_btnSearchGo"));
            // click on go button by java script executor
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].click();", goButton);
            bool thinkingIndicatornotShownAfterGo = GenericHelper.ThinkingIndicatorProcessing();
            if (thinkingIndicatornotShownAfterGo)
            {
                GenericHelper.Logs("Thinking Indicator has been loaded", "Passed");
            }
            else
            {
                Assert.Fail("Thinking Indicator is still showing");
            }

        }

        /// <summary>
        /// This method is for clicking C menu of study plan
        /// </summary>
        public void ClickOnCmenuStudyPlan()
        {
            GenericHelper.SelectWindow("Calendar");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int secondsToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
            while (stopWatch.Elapsed.TotalSeconds < secondsToWait)
            {
                // putting check to verify if the searched asset is shown or not
                if (!GenericHelper.WaitUntilElement(By.Id("tdAssetIcon")))
                {
                    //Refresh page to get the searched text box again
                    WebDriver.Navigate().Refresh();
                    SearchStudyPlan();
                }
                else
                {
                    break;
                }
            }
            GenericHelper.WaitUntilElement(By.Id("tdAssetIcon"));
            IWebElement cmenuhover = WebDriver.FindElement(By.Id("tdAssetIcon"));
            new Actions(WebDriver).MoveToElement(cmenuhover).Build().Perform();
            GenericHelper.WaitUntilElement(By.XPath("//img[@class='ES_CMenuImg']"));
            IWebElement cmenuclick = WebDriver.FindElement(By.XPath("//img[@class='ES_CMenuImg']"));
            new Actions(WebDriver).Click(cmenuclick).Perform();

        }

        /// <summary>
        /// This method is for opening the assignement property of study plan
        /// </summary>
        public void OpenAssignementPropertiesOfStudyPlan()
        {
            SearchStudyPlan();
            ClickOnCmenuStudyPlan();
            WebDriver.FindElement(By.XPath("//div[@class='Classcmenu_main']/div[2]/div[3]/span")).Click();
            GenericHelper.WaitUtilWindow("Assign");
            new CalendarDefaultUX().SelectAssignedDateAndSetDateRange();
            GenericHelper.WaitUtilWindow("Calendar");
        }

        /// <summary>
        /// This method is for opening the assignement property of already assigned study plan
        /// </summary>
        public void OpenAssignementPropertiesOfAlreadyAssignedStudyPlan()
        {
            WebDriver.FindElement(By.XPath("//div[@class='Classcmenu_main']/div[2]/div[3]/span")).Click();
            GenericHelper.WaitUtilWindow("Assign");
            new CalendarDefaultUX().SelectAssignedDateAndSetDateRange();
            GenericHelper.WaitUtilWindow("Calendar");
        }
    }
}
