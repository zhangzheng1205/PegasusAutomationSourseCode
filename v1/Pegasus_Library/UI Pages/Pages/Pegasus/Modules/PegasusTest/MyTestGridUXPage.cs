using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus_Library.Code_Base;
using OpenQA.Selenium;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.PegasusTest
{
    public class MyTestGridUXPage:BasePage 
    {
        //Purpose: To click on Create New Test link
        public void ClickCreateNewTest()
        {
            WebDriver.SwitchTo().Frame("ifrmMyTestGrid");
            WebDriver.FindElement(By.Id("_ctl0:InnerPageContent:btnCreateNewTest")).Click();
            GenericHelper.SelectDefaultWindow();
        }


       




    }
}
