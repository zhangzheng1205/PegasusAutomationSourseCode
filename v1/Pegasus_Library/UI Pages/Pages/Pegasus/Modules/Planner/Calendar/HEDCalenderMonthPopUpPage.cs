using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using OpenQA.Selenium;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Planner.Calendar
{
    public class HEDCalenderMonthPopUpPage : BasePage 
    {

        public void SelectTommorowDate()
        {
            DateTime dateTime = new DateTime();
            string Tomorrow = DateTime.Today.AddDays(1).ToShortDateString();

            string today = DateTime.Today.ToShortDateString();
            GenericHelper.WaitUntilElement(By.Id("lightboxid"));
            WebDriver.SwitchTo().Frame("lightboxid");
            string todaydate =
    WebDriver.FindElement(By.XPath("//td[@CurrentDay='True']/div/div/a")).GetAttribute("title");

            //DateTime dt = Convert.ToDateTime(todaydate);
            if (todaydate != today)
            {
                Tomorrow = DateTime.Today.ToShortDateString();
                //this case will happen only before 10.30 am ,after 10.30 application date and system date will be same
            }

           
            WebDriver.FindElement(By.Id("calendarContainer_txtSelectDate")).Clear();
            WebDriver.FindElement(By.Id("calendarContainer_txtSelectDate")).SendKeys(Tomorrow);
            WebDriver.FindElement(By.Id("calendarContainer_btnNavSelectedDate")).SendKeys("");
            WebDriver.FindElement(By.Id("calendarContainer_btnNavSelectedDate")).Click();
            Thread.Sleep(5000);
            WebDriver.FindElement(By.Id("imgBtnSave")).Click();
        }
    }
}
