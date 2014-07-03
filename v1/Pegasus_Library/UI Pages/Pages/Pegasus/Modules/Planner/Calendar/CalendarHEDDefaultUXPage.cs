using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using OpenQA.Selenium;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Common;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Planner.Calendar
{
    public class CalendarHEDDefaultUXPage: BasePage 
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        private ShowMessagePage _showMessagePage = new ShowMessagePage();
        //purpose : to Assign Activity To CurrentDate
        public void AssignActivityToCurrentDate(string ActName)
        {
            GenericHelper.WaitUntilElement(By.XPath("//td[@class='HighlightTodayCell']"));
          // string currentDate =WebDriver.FindElement(By.XPath("//td[@class='HighlightTodayCell']/div/div/a")).GetAttribute("title");

            //act
            int cnt=WebDriver.FindElements(By.XPath("//div[@id='TreeViewContainer']/table")).Count();

            for(int i=1 ;i<=cnt;i++)
            {
                string activityName =
                    WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table["+i.ToString()+"]")).GetAttribute("innerText");
                if (activityName.Contains(ActName))
                {
                    WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table["+i.ToString()+"]")).SendKeys("");
                    IWebElement target = WebDriver.FindElement(By.XPath("//td[@class='HighlightTodayCell']"));
                    IWebElement element= WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + i.ToString() +"]/tbody/tr/td[3]/table/tbody/tr/td/div"));
                    (new Actions(WebDriver)).DragAndDrop(element, target).Build().Perform();
                    Thread.Sleep(6000);
                    break;
                }
            }

        }

        //purpose : to Assign Activity To CurrentDate In Search View
        public void AssignActivityToCurrentDateInSearchView(string ActName)
        {
            GenericHelper.WaitUntilElement(By.XPath("//td[@class='HighlightTodayCell']"));
            // string currentDate =WebDriver.FindElement(By.XPath("//td[@class='HighlightTodayCell']/div/div/a")).GetAttribute("title");

            //act
            int cnt = WebDriver.FindElements(By.XPath("//div[@id='grdSearch_Container']/div")).Count();

            for (int i = 1; i <= cnt; i++)
            {
                string activityName =
                    WebDriver.FindElement(By.XPath("//div[@id='grdSearch_Container']/div[" + i.ToString() + "]")).GetAttribute("innerText");
                if (activityName.Contains(ActName))
                {
                    //WebDriver.FindElement(By.XPath("//div[@id='grdSearch_Container']/div[" + i.ToString() + "]")).SendKeys("");
                    IWebElement target = WebDriver.FindElement(By.XPath("//td[@class='HighlightTodayCell']"));
                    IWebElement element = WebDriver.FindElement(By.XPath("//div[@id='grdSearch_Container']/div[" + i.ToString() + "]/div/div/div/table/tbody/tr/td[3]/div"));
                    (new Actions(WebDriver)).DragAndDrop(element, target).Build().Perform();
                    Thread.Sleep(6000);
                    break;
                }
            }

        }

         public void UnAssignActivityInSearchView(string actname)
         {
             //act
             int cnt = WebDriver.FindElements(By.XPath("//div[@id='grdSearch_Container']/div")).Count();
             for (int i = 1; i <= cnt; i++)
             {
                 string activityName =
                     WebDriver.FindElement(By.XPath("//div[@id='grdSearch_Container']/div[" + i.ToString() + "]")).GetAttribute("innerText");
                 if (activityName.Contains(actname))
                 {
                     
                     WebDriver.FindElement(By.XPath("//div[@id='grdSearch_Container']/div[" + i.ToString() + "]/div/div/div/table/tbody/tr/td[1]/input")).Click();
                     
                     Thread.Sleep(6000);
                     break;
                 }
             }

             WebDriver.FindElement(By.Id("ctl00$ctl00$phBody$PageContent$ucLeftNavigationContainer$ucContentFilter$btnAssignUnassign")).SendKeys("");
             WebDriver.FindElement(By.Id("ctl00$ctl00$phBody$PageContent$ucLeftNavigationContainer$ucContentFilter$btnAssignUnassign")).Click();
             Thread.Sleep(6000);

             if (GenericHelper.IsPopUpWindowPresent("Pegasus"))
             {
                 _showMessagePage.ClickOk();
             }

         }
        //Purpose : to Verify Clock Image For CurrentDate In Calendar
        public bool VerifyClockImageForCurrentDateInCalendar()
        {
           // WebDriver.FindElement(By.XPath("//td[@class='HighlightTodayCell']/div[2]/div[3]/div/div/div/div[@class='dueImgAssignment']"));
            return GenericHelper.IsElementPresent(
                By.XPath("//td[@class='HighlightTodayCell']/div[2]/div[3]/div/div/div/div[@class='dueImgAssignment']"));
        }

        //public void ClickOnTheCurrentDate()
        //{
        //    GenericHelper.WaitUntilElement(By.XPath("//td[@class='HighlightTodayCell']"));
        //    WebDriver.FindElement(By.XPath("//td[@class='HighlightTodayCell']")).Click();
        //}

        //Purpose : to click viewAdvancedCalendar button
        public void ClickViewAdvancedCalendar()
        {
            GenericHelper.WaitUntilElement(By.Id("ctl00_ctl00_phBody_PageContent_calendarContainer_ucCalHeader_ViewAdvCal"));
            WebDriver.FindElement(By.Id("ctl00_ctl00_phBody_PageContent_calendarContainer_ucCalHeader_ViewAdvCal")).Click();
            Thread.Sleep(6000);
        }

        //Purpose : to click on current Date in Advanced Calendar view
        public void  ClickOnCurrentDateInAdvancedCalendar()
        {
            GenericHelper.WaitUntilElement(By.XPath("//td[@class='rsTodayCell']"));
           // WebDriver.FindElement(By.XPath("//td[@class='rsTodayCell']")).Click();
            GenericHelper.WaitUntilElement(By.XPath("//td[@CurrentDay='True']"));
            WebDriver.FindElement(By.XPath("//td[@CurrentDay='True']")).Click();
            Thread.Sleep(6000);
            GenericHelper.SelectDefaultWindow();
        }

        //Purpose: to select checkbox of Sp in advance calender view
        public void SelectCheckBoxOfActivityInAdvanceView(string actName)
        {
            int cnt = WebDriver.FindElements(By.XPath("//div[@class='dvDueAssignments dvAssignmentscss']/div")).Count();
            for (int i=1;i<=cnt; i++)
            {
                string activityName =
                    WebDriver.FindElement(
                        By.XPath("//div[@class='dvDueAssignments dvAssignmentscss']/div[" + i.ToString() + "]")).
                        GetAttribute("innerText");

                if(activityName.Contains(actName))
                {
                     WebDriver.FindElement(By.XPath("//div[@class='dvDueAssignments dvAssignmentscss']/div[" + i.ToString() + "]/div[2]/input")).Click();
                    break;
                }
            }
        }

        //Purpose: to Verify Move Button is Enabled
        public bool VerifyIsMoveButtonEnabled()
        {
            GenericHelper.WaitUntilElement(By.Id("ctl00$ctl00$phBody$PageContent$calendarContainer$BtnMove"));
            if(WebDriver.FindElement(By.Id("ctl00$ctl00$phBody$PageContent$calendarContainer$BtnMove")).Enabled)
            {
              return true;
            }
            else
            {
               return false;
            }
            
        }

        //Purpose: to click Move Button 
        public void ClickMoveButton()
        {
            WebDriver.FindElement(By.Id("ctl00$ctl00$phBody$PageContent$calendarContainer$BtnMove")).Click();
            Thread.Sleep(6000);
        }


        //Purpose: to select checkbox of Sp
        public void SelectCheckBoxOfActivity(string actName)
        {
            //string currentDate = WebDriver.FindElement(By.XPath("//td[@class='HighlightTodayCell']/div/div/a")).GetAttribute("title");

            //act
            int cnt = WebDriver.FindElements(By.XPath("//div[@id='TreeViewContainer']/table")).Count();

            for (int i = 1; i <= cnt; i++)
            {
            string activityName =WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table["+i.ToString()+"]")).GetAttribute("innerText");
                if(activityName.Contains(actName))

                {
                    WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + i.ToString() + "]/tbody/tr/td")).SendKeys("");
                    WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + i.ToString() + "]/tbody/tr/td/input")).Click();
                    break;
                }
            }
        }

        //Purpose: to UnAssign Activity
        public void UnAssignActivity(string actName)
        {
            SelectCheckBoxOfActivity(actName);
            WebDriver.FindElement(By.Id("ctl00$ctl00$phBody$PageContent$ucLeftNavigationContainer$ucContentFilter$btnAssignUnassign")).SendKeys("");
            WebDriver.FindElement(By.Id("ctl00$ctl00$phBody$PageContent$ucLeftNavigationContainer$ucContentFilter$btnAssignUnassign")).Click();
            Thread.Sleep(4000);
            
        }

        public string GetPreviousDateLocator()
        {

            GenericHelper.WaitUntilElement(By.XPath("//td[@class='HighlightTodayCell']"));
            string currentDay =WebDriver.FindElement(By.XPath("//td[@class='HighlightTodayCell']/div/div/a")).GetAttribute("title");

            DateTime dateTime = new DateTime();
            string today = DateTime.Today.ToShortDateString();

            
            string previousDate = DateTime.Today.AddDays(-1).ToShortDateString();

            if (currentDay != today)
            {
                previousDate = DateTime.Today.AddDays(-2).ToShortDateString();
                //this case will happen only before 10.30 am ,after 10.30 application date and system date will be same
            }
            string currentDate = DateTime.Today.ToShortDateString();
            string todaydate = Convert.ToString(currentDate);
            string[] dt = todaydate.Split('/');
            


            int countRow =WebDriver.FindElements(By.XPath("//div[@class='rsContent rsMonthView']/table/tbody/tr[2]/td/div/table/tbody/tr")).Count();

            int countCol = 7; //no of days in week
            string locator = string.Empty;

            if(dt[1]!="1")
            {
            for (int i=1 ; i<=countRow ; i++)
            {
                for (int j = 1; j <= countCol; j++)
                {
                    string date =
                        WebDriver.FindElement(
                            By.XPath("//div[@class='rsContent rsMonthView']/table/tbody/tr[2]/td/div/table/tbody/tr[" +
                                     i.ToString() + "]/td[" + j.ToString() + "]/div/div/a")).GetAttribute("title");
                    if (date==previousDate)
                    {
                        locator =
                            "//div[@class='rsContent rsMonthView']/table/tbody/tr[2]/td/div/table/tbody/tr[" +
                            i.ToString() + "]/td[" + j.ToString() + "]";

                      // WebDriver.FindElement(By.XPath("//div[@class='rsContent rsMonthView']/table/tbody/tr[2]/td/div/table/tbody/tr[" +i.ToString() + "]/td[" + j.ToString() + "]")).Click();
                       break;

                    }
                }
            }
          }
            //else
            //{
            //    need to add logic if date is 1
            //}

          return locator;


        }



        //purpose : to Assign Activity To previous date
        public void AssignActivityToPreviousDate(string ActName)
        {
            GenericHelper.WaitUntilElement(By.XPath("//td[@class='HighlightTodayCell']"));
            // string currentDate =WebDriver.FindElement(By.XPath("//td[@class='HighlightTodayCell']/div/div/a")).GetAttribute("title");

            //act
            int cnt = WebDriver.FindElements(By.XPath("//div[@id='TreeViewContainer']/table")).Count();

            for (int i = 1; i <= cnt; i++)
            {
                string activityName =
                    WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + i.ToString() + "]")).GetAttribute("innerText");
                if (activityName.Contains(ActName))
                {
                    IWebElement target = WebDriver.FindElement(By.XPath(GetPreviousDateLocator()));

                    WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + i.ToString() + "]")).SendKeys("");
                   
                    IWebElement element = WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + i.ToString() + "]/tbody/tr/td[3]/table/tbody/tr/td/div"));
                    (new Actions(WebDriver)).DragAndDrop(element, target).Build().Perform();
                    Thread.Sleep(6000);
                    break;
                }
            }


        }


        //Purpose: To navigate to the Today's View 
        public void NavigateToTodaysViewTab()
        {
            try
            {
                GenericHelper.SelectDefaultWindow();
                GenericHelper.WaitUntilElement(By.Id("divMore"));
                WebDriver.FindElement(By.Id("divMore")).Click();
                GenericHelper.WaitUntilElement(By.PartialLinkText("Today's View"));
                WebDriver.FindElement(By.PartialLinkText("Today's View")).Click();
                if (!Browser.Equals("GC"))
                {
                    WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(120));
                }
                if (Browser.Equals("GC"))
                {
                    Thread.Sleep(3000);
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Click
        public void ClickMyProfile()
        {
            GenericHelper.SelectWindow("Calendar");
            WebDriver.FindElement(By.Id("ctl00_ctl00_phHeader_ucs_Header_ucs_HelloObject_ancMyAccount")).SendKeys("");
            WebDriver.FindElement(By.Id("ctl00_ctl00_phHeader_ucs_Header_ucs_HelloObject_ancMyAccount")).Click();
            Thread.Sleep(5000);
            
        }
        
        //Purpose: ToSearchActivty
        public void SearchActivty(string Actname)
        {
            GenericHelper.WaitUntilElement(
                By.Id("ctl00_ctl00_phBody_PageContent_ucLeftNavigationContainer_ucContentFilter_acSearchPanel_txtSearch"));
            WebDriver.FindElement(By.Id("ctl00_ctl00_phBody_PageContent_ucLeftNavigationContainer_ucContentFilter_acSearchPanel_txtSearch")).Clear();
            WebDriver.FindElement(By.Id("ctl00_ctl00_phBody_PageContent_ucLeftNavigationContainer_ucContentFilter_acSearchPanel_txtSearch")).SendKeys(Actname);

            WebDriver.FindElement(By.Id("ctl00_ctl00_phBody_PageContent_ucLeftNavigationContainer_ucContentFilter_acSearchPanel_btnSearchGo")).Click();


            bool waitForThinkingIndicatorClose = GenericHelper.ThinkingIndicatorProcessing();
            if (waitForThinkingIndicatorClose)
            {
                GenericHelper.Logs("Acitivity Search.", "PASSED");
            }
            else
            {
                GenericHelper.Logs("Acitivity Search.", "FAILED");
                throw new Exception("Acitivity Search .");
            }
        }

        //Purpose: To Click Activity Cmenu In Search View
        public void ClickActivityCmenuInSearchView(string actName)
        {
            int cnt = WebDriver.FindElements(By.XPath("//div[@id='grdSearch_Container']/div")).Count();

            for (int i = 1; i <= cnt; i++)
            {
                string activityName =
                    WebDriver.FindElement(By.XPath("//div[@id='grdSearch_Container']/div[" + i.ToString() + "]")).GetAttribute("innerText");
                if (activityName.Contains(actName))
                {
                    IWebElement asset = WebDriver.FindElement(By.XPath("//div[@id='grdSearch_Container']/div[" + i.ToString() + "]/div/div/div/table/tbody/tr/td[3]/div"));

                    IWebElement cmenu = WebDriver.FindElement(By.XPath("//div[@id='grdSearch_Container']/div[" + i.ToString() + "]/div/div/div/table/tbody/tr/td[5]/img"));
                    Actions builder = new Actions(WebDriver);
                    builder.MoveToElement(asset).Build().Perform();
                    builder.MoveToElement(cmenu).Click().Perform();
                    Thread.Sleep(6000);
                    break;
                }
            }
        }

        //Purpose: To Select Assignment Properties Cmenu Option
        public void SelectAssignmentPropertiesCmenuOption()
        {
            try
            {
                WebDriver.FindElement(By.XPath("//div[@title='Assignment Properties']")).Click();
                //WebDriver.FindElement(By.PartialLinkText("Assignment Properties")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
