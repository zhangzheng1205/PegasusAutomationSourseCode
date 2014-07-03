using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pegasus_Library.Code_Base;
using OpenQA.Selenium;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.MyPrefernce;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Planner.Calendar;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentSchedule
{
    public class AssignContentPage:BasePage 
    {
        MyAccountSettingPage _myAccountSettingPage =new MyAccountSettingPage();
        CalendarHEDDefaultUXPage _calendarHedDefaultUxPage =new CalendarHEDDefaultUXPage();

        public void SelectAssignedRadioButton()
        {
            GenericHelper.WaitUntilElement(By.Id("rdAssigned"));
            WebDriver.FindElement(By.Id("rdAssigned")).Click();
        }

        public void SetDateAndTime(string Date, string Time)
        {
            
            

            //DateTime dt = Convert.ToDateTime(Date);
           // DateTime dt = Convert.ToDateTime("11/6/2012");

            string timeanddate = (Date + " " + Time);
            DateTime dt1 = Convert.ToDateTime(timeanddate).AddMinutes(2);

            string condt1 = dt1.ToString();

            string[] TimeStamp = condt1.Split(' ');

            string AsigningDate = TimeStamp[0];
            string AssigningMeridian = TimeStamp[2];

           // string AssingingTime = TimeStamp[1];
            string[] AssingingTimeArray = TimeStamp[1].Split(':');

            string AssiningHour = AssingingTimeArray[0];
            string AssiningMin = AssingingTimeArray[1];
            

            

            GenericHelper.SelectWindow("Assign");
            
            WebDriver.FindElement(By.Id("rdAssigned")).SendKeys("");
          //  WebDriver.FindElement(By.Id("rdAssigned")).Click();
            IWebElement radiobutton = WebDriver.FindElement(By.Id("rdAssigned"));

            Actions builder = new Actions(WebDriver);
           // builder.MoveToElement(radiobutton).Build().Perform();
            builder.MoveToElement(radiobutton).Click().Perform();

          
            WebDriver.FindElement(By.Id("txtDueDate")).SendKeys("");
            WebDriver.FindElement(By.Id("txtDueDate")).Clear();
            WebDriver.FindElement(By.Id("txtDueDate")).SendKeys(AsigningDate);
            WebDriver.FindElement(By.Id("txtdHrs")).SendKeys("");
            WebDriver.FindElement(By.Id("txtdHrs")).Clear();
            WebDriver.FindElement(By.Id("txtdHrs")).SendKeys(AssiningHour);
            WebDriver.FindElement(By.Id("txtdMins")).SendKeys("");
            WebDriver.FindElement(By.Id("txtdMins")).Clear();
            WebDriver.FindElement(By.Id("txtdMins")).SendKeys(AssiningMin);

            WebDriver.FindElement(By.Id("CMBAMPMDUEDT")).SendKeys("");
            new SelectElement(WebDriver.FindElement(By.Id("CMBAMPMDUEDT"))).SelectByText(AssigningMeridian);
            Thread.Sleep(3000);

            WebDriver.FindElement(By.Id("btn_save_assign")).SendKeys("");
            WebDriver.FindElement(By.Id("btn_save_assign")).Click();
            Thread.Sleep(4000);
        }
    }
}
