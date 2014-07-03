using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus_Library.Code_Base;
using System.Threading;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Library;
using OpenQA.Selenium;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Common
{
    public class ShowMessagePage : BasePage
    {

        //purpose : To Click Continue button in Activity Alert pop up
        public void ClickContinue()
        {
            GenericHelper.WaitUtilWindow("Activity Alert");
            GenericHelper.SelectWindow("Activity Alert");
            GenericHelper.WaitUntilElement(By.Id("imgOk"));
            WebDriver.FindElement(By.Id("imgOk")).Click();

        }

        //purpose : To Click ok button in Pegasus pop up
        public void ClickOk()
        {
            GenericHelper.WaitUtilWindow("Pegasus");
            GenericHelper.SelectWindow("Pegasus");
            GenericHelper.WaitUntilElement(By.Id("imgOk"));
            WebDriver.FindElement(By.Id("imgOk")).Click();
            Thread.Sleep(4000);
        }
    }
}
