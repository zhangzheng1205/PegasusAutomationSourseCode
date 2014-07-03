using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Planner.Calendar
{
    public class ShowAssignedContentListPage : BasePage
    {
        public void ClickYesButton()
        {
            GenericHelper.SelectWindow("Calendar");
            if (GenericHelper.IsElementPresent(By.Id("iframeContentList")))
            {
                WebDriver.SwitchTo().Frame("iframeContentList");
                Actions buider = new Actions(WebDriver);
                IWebElement YesButton = WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_btnYes"));
                buider.MoveToElement(YesButton).Click().Perform();
                GenericHelper.SelectDefaultWindow();
            }
        }

    }
}
