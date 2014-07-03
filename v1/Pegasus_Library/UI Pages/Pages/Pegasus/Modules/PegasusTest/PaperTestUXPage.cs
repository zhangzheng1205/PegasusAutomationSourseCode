using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus_Library.Code_Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pegasus_Library.Library;
using System.Threading;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.PegasusTest;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.PegasusTest
{
    public class PaperTestUXPage: BasePage 
    {
        readonly MyTestUXPage _myTestUxPage =new MyTestUXPage();

        ///Purpose : to save and close the test
        public bool SaveTest()
        {
            try
            {
            GenericHelper.SelectDefaultWindow();
            WebDriver.FindElement(By.Id("_ctl0__ctl0_phBody_PageContent_spanSave")).Click();
            WebDriver.SwitchTo().DefaultContent();
            WebDriver.FindElement(By.Id("_ctl0__ctl0_phBody_PageContent_lnkSaveClose")).Click();
            Thread.Sleep(2000);
            return _myTestUxPage.VerifySuccesfullMessage("Test saved successfully.");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        ///Purpose : To select TrueFalse question option to create TrueFalse question type
        public void SelectTrueFalseQuestion()
        {
            try 
            {
            GenericHelper.SelectDefaultWindow();
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_spanQuestions"));
            WebDriver.FindElement(By.Id("_ctl0__ctl0_phBody_PageContent_spanQuestions")).Click();
            WebDriver.FindElement(By.Id("_ctl0__ctl0_phBody_PageContent_spnTF")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
