using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using OpenQA.Selenium;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TeachingPlan
{
    public class ContentBrowserMainUXPage : BasePage 
    {

        public void ClickAddAndClose()
        {
            try
            {
                GenericHelper.SelectWindow("Create New Question");
                WebDriver.SwitchTo().Frame("frmSelectQuestion");
                WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_imgBtnAdd_Close")).Click();
            }
            catch(Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
