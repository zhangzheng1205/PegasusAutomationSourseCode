using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Calendar
{
    public class CalendarDefaultUX : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        // Purpose: To SelectCalendar Setup Button
        public void ToSelectCalendarSetupButton()
        {
            GenericHelper.SelectWindow("Calendar");
            if (WebDriver.FindElement(By.Id("ctl00_ctl00_phBody_PageContent_calendarContainer_ucCalHeader_lnkCalendarSetup")).Displayed)
            {
                GenericHelper.Logs("Calendar is already set up by the user, hence no need to set up again!", "Passed");
            }
            else
            {
                GenericHelper.WaitUntilElement(By.Id("ctl00_ctl00_phBody_PageContent_FrmEmptyCal"));
                WebDriver.SwitchTo().Frame("ctl00_ctl00_phBody_PageContent_FrmEmptyCal");
                GenericHelper.WaitUntilElement(By.Id("btn_CalSetUp"));
                WebDriver.FindElement(By.Id("btn_CalSetUp")).Click();
                Thread.Sleep(2000);
                WebDriver.SwitchTo().ActiveElement();
                GenericHelper.SelectWindow("Calendar");
                if (!GenericHelper.IsElementPresent(By.Id("lightboxid")))
                {
                    WebDriver.FindElement(By.Id("btn_CalSetUp")).Click();
                }
                GenericHelper.WaitUntilElement(By.Id("lightboxid"));
                WebDriver.FindElement(By.Id("lightboxid"));
                WebDriver.SwitchTo().Frame("lightboxid");
                WebDriver.SwitchTo().Frame("FrmPeriod");
                GenericHelper.WaitUntilElement(By.XPath("//img[contains(@src,'/images/icn_addAns.gif')]"));
                WebDriver.FindElement(By.XPath("//img[contains(@src,'/images/icn_addAns.gif')]")).Click();
                Thread.Sleep(2000);
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.WaitUntilElement(By.Id("lightboxid"));
                WebDriver.SwitchTo().Frame("lightboxid");
                GenericHelper.WaitUntilElement(By.Id("frmCreatePeriod"));
                WebDriver.SwitchTo().Frame("frmCreatePeriod");
                GenericHelper.WaitUntilElement(By.Id("DrpPeriodOrder"));
                WebDriver.FindElement(By.Id("DrpPeriodOrder")).FindElement(By.CssSelector("option[value='2']")).Click();
                GenericHelper.WaitUntilElement(By.Id("txtPeriodName"));
                WebDriver.FindElement(By.Id("txtPeriodName")).SendKeys("Calendar_Automation");
                WebDriver.FindElement(By.Id("ChkMon")).Click();
                WebDriver.FindElement(By.Id("ChkTue")).Click();
                WebDriver.FindElement(By.Id("ChkWed")).Click();
                WebDriver.FindElement(By.Id("ChkThu")).Click();
                WebDriver.FindElement(By.Id("ChkFri")).Click();
                WebDriver.FindElement(By.Id("ChkSat")).Click();
                WebDriver.FindElement(By.Id("ChkSun")).Click();
                //Purpose: Selecting Value From Drop Down
                {
                    try
                    {
                        IWebElement selectValue = WebDriver.FindElement(By.Id("DrpCourseAsso"));
                        Thread.Sleep(3000);
                        SelectElement selectElement = new SelectElement(selectValue);
                        selectElement.SelectByIndex(1);
                        GenericHelper.WaitUntilElement(By.Id("btn_Finish"));
                        WebDriver.FindElement(By.Id("btn_Finish")).Click();
                        Thread.Sleep(30000); //This I have added to avoid HTTP connection break while loading calendar
                        WebDriver.SwitchTo().DefaultContent();
                        GenericHelper.SelectWindow("Calendar");
                        GenericHelper.WaitUntilElement(By.Id("lightboxid"));
                        WebDriver.SwitchTo().Frame("lightboxid");
                        GenericHelper.WaitUntilElement(By.Id("btn_Finish"));
                        IWebElement finishButton = WebDriver.FindElement(By.Id("btn_Finish"));
                        new Actions(WebDriver).Click(finishButton).Perform();
                        Thread.Sleep(30000); //This I have added to avoid HTTP connection break while loading calendar
                        WebDriver.SwitchTo().DefaultContent();
                    }
                    catch (NoSuchElementException e)
                    {
                        GenericHelper.Logs(e.ToString(), "FAILED");
                        throw new Exception(e.ToString());
                    }
                    catch (WebDriverException e)
                    {
                        GenericHelper.Logs(e.ToString(), "FAILED");
                        throw new Exception(e.ToString());
                    }
                }
            }
        }

        // Code to Drag and drop the activity in to the right frame
        public void ToDragAndDrop()
        {
            try
            {
                GenericHelper.SelectWindow("Calendar");
                string courseNameFolder = DatabaseTools.GetActivityName(Enumerations.ActivityType.Folder);
                // Code to Drag and drop the activity in to the right frame
                int rowNo = 2;
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='TreeViewContainer']/table[" + rowNo + "]"));
                string getcourseName = WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + rowNo + "]")).Text.Trim();
                if (courseNameFolder == getcourseName)
                {
                    WebDriver.FindElement(By.XPath("//table[@id='grdCourse']/tbody/tr[" + rowNo + "]/td/INPUT[contains(@onclick,'ToGetCourseID(this);')]")).Click();
                    GenericHelper.Logs("ContainerCourse has been successfully selected", "passed");
                }
                while (courseNameFolder != getcourseName)
                {
                    rowNo = rowNo + 1;
                    getcourseName = WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + rowNo + "]")).Text.Trim();

                    if (courseNameFolder == getcourseName)
                    {
                        IWebElement movetoQuestion =
                            WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + rowNo + "]"));

                        IWebElement pickFolder = WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + rowNo + "]/tbody/tr/td[3]/descendant::div[@title='Benchmark Tests']"));
                        if (Browser.Equals("FF") || Browser.Equals("GC"))
                        {
                            if (Browser.Equals("FF"))
                            {

                                WebDriver.FindElement(
                                    By.XPath("//div[@id='TreeViewContainer']/table[" + rowNo +
                                             "]/tbody/tr/td[3]/descendant::div[@title='Benchmark Tests']")).SendKeys("");
                            }
                            IWebElement sourceElement = WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + rowNo + "]/tbody/tr/td[3]/descendant::div[@title='Benchmark Tests']"));
                            IWebElement element = WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + rowNo + "]/tbody/tr/td[2]/descendant::img[@onclick='ImitateGridTreeNodeExpand(this)']"));
                            IWebElement target = WebDriver.FindElement(By.XPath("//span[@class='dvDueAssignmentsTodayHeaderTextCss']"));
                            (new Actions(WebDriver)).DragAndDrop(element, target).Build().Perform();
                            Thread.Sleep(5000);
                            IWebElement element1 = WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + rowNo + "]/tbody/tr/td[2]/descendant::img[@onclick='ImitateGridTreeNodeExpand(this)']"));
                            IWebElement target1 = WebDriver.FindElement(By.XPath("//span[@class='dvDueAssignmentsTodayHeaderTextCss']"));
                            (new Actions(WebDriver)).DragAndDrop(element1, target1).Build().Perform();
                            Thread.Sleep(5000);
                            break;
                        }
                        else
                        {
                            // Purpose: Grab Calendar Element
                            Actions builder = new Actions(WebDriver);
                            GenericHelper.WaitUntilElement(
                                By.XPath("//div[@id='TreeViewContainer']/table[" + rowNo +
                                         "]/tbody/tr/td[3]/descendant::div[@title='Benchmark Tests']"));
                            WebDriver.FindElement(By.XPath("//div[@id='TreeViewContainer']/table[" + rowNo + "]/tbody/tr/td[3]/descendant::div[@title='Benchmark Tests']")).SendKeys("");
                            builder.ClickAndHold(pickFolder).Build().Perform();
                            // Purpose: Switch to the Frame (you havent told webdriver to un-grab)
                            WebDriver.SwitchTo().DefaultContent();
                            // Purpose: Move and Drop Element on Calendar
                            IWebElement targetElement = WebDriver.FindElement(By.XPath("//div[@class='dvDueAssignmentsTodayHeaderCss']"));
                            builder.MoveToElement(targetElement).Release().Build().Perform();
                            Thread.Sleep(5000);
                            break;
                        }
                    }
                }
            }
            catch (WebDriverException e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose: To Verify the activity in the right frame
        public void ToVerifyTheActivity()
        {
            try
            {
                IWebElement redText = WebDriver.FindElement(By.XPath("//div[@class='dvDueAssignmentsTodayCss']"));
                if (redText.Text.Contains("Your content is being prepared and will be available soon."))
                {
                    GenericHelper.Logs("Activity has been successfully moved to the right frame of Calendar Set up", "Passed");
                }
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
                while (sw.Elapsed.Minutes < minutesToWait)
                {
                    Thread.Sleep(5000);
                    GenericHelper.SelectWindow("Calendar");
                    IWebElement redTextverification = WebDriver.FindElement(By.XPath("//div[@class='dvDueAssignmentsTodayCss']"));

                    if (!redTextverification.Text.Contains("Your content is being"))
                    {
                        GenericHelper.Logs("Calendar contents are available in the right frame and are in available state",
                                           "passed");
                        break;
                    }
                    IWebElement redTextClass =
                         WebDriver.FindElement(By.XPath("//div[@class='dvDivDueAssignmentPreparingText']"));
                    Actions builder = new Actions(WebDriver);
                    builder.MoveToElement(redTextClass).Build().Perform();

                    if (redTextverification.Text.Contains("Your content is being"))
                    {
                        WebDriver.Navigate().Refresh();
                    }
                    else
                    {
                        GenericHelper.Logs(string.Format("Calendar contents are available in the right frame after '{0}' minutes.", minutesToWait), "PASSED");
                        break;
                    }
                }
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.SelectWindow("Calendar");
            }
            catch (WebDriverException e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose: To go back from calendar page
        public void ToGoBackFromCalendar()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("ctl00$ctl00$phHeader$ucs_Header$Backbutton"));
                WebDriver.FindElement(By.Id("ctl00$ctl00$phHeader$ucs_Header$Backbutton")).Click();
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
            }
            catch (WebDriverException e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        /// <summary>
        /// This method is for the Select Date range and assigned date
        /// </summary>
        public void SelectAssignedDateAndSetDateRange()
        {
            try
            {
                string startDate = DateTime.Now.AddDays(-4).ToString("MM/dd/yyyy");
                GenericHelper.SelectWindow("Assign");
                Assert.AreEqual("Assign", WebDriver.Title);

                GenericHelper.WaitUntilElement(By.Id("rdAssigned"));
                if (WebDriver.FindElement(By.Id("rdAssigned")).Selected)
                {
                    GenericHelper.WaitUntilElement(By.Id("rdNotAssigned"));
                    WebDriver.FindElement(By.Id("rdNotAssigned")).Click();
                    GenericHelper.WaitUntilElement(By.Id("rdAlwaysAvailabletoStud"));
                    WebDriver.FindElement(By.Id("rdAlwaysAvailabletoStud")).Click();
                    WebDriver.FindElement(By.CssSelector("#btn_save_assign > span > span")).Click();
                    bool isThinkingIndicatorShown = GenericHelper.ThinkingIndicatorProcessing();
                    if (isThinkingIndicatorShown)
                    {
                        GenericHelper.Logs("Thinking Indicator has been loaded", "Passed");
                    }
                    else
                    {
                        Assert.Fail("Thinking Indicator is still showing");
                    }
                    GenericHelper.WaitUtilWindow("Calendar");
                    GenericHelper.SelectWindow("Calendar");
                    new DrtDefaultUxPage().ClickOnCmenuStudyPlan();
                    new DrtDefaultUxPage().OpenAssignementPropertiesOfAlreadyAssignedStudyPlan();
                }
                else
                {
                    WebDriver.FindElement(By.Id("rdAssigned")).Click();
                    GenericHelper.WaitUntilElement(By.Id("rdSetAvailableDate"));
                    WebDriver.FindElement(By.Id("rdSetAvailableDate")).Click();
                    GenericHelper.WaitUntilElement(By.Id("txtFromDate"));
                    WebDriver.FindElement(By.Id("txtFromDate")).Click();
                    WebDriver.FindElement(By.Id("txtFromDate")).SendKeys(startDate);
                    GenericHelper.WaitUntilElement(By.Id("chkNoEndDate"));
                    WebDriver.FindElement(By.Id("chkNoEndDate")).Click();
                    GenericHelper.WaitUntilElement(By.CssSelector("#btn_save_assign > span > span"));
                    WebDriver.FindElement(By.CssSelector("#btn_save_assign > span > span")).Click();
                    bool isThinkingIndicatorShown = GenericHelper.ThinkingIndicatorProcessing();
                    if (isThinkingIndicatorShown)
                    {
                        GenericHelper.Logs("Thinking Indicator has been loaded", "Passed");
                    }
                    else
                    {
                        Assert.Fail("Thinking Indicator is still showing");
                    }

                }
            }
            catch (WebDriverException e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
