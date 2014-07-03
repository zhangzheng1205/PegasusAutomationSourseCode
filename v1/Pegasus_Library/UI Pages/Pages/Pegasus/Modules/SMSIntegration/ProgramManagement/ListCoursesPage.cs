using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement
{
    public class ListCoursesPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //Purpose: to SearchCourse
        public void SearchCourse(string courseType)
        {
            try
            {
                string coursename = string.Empty;
                switch (courseType)
                {
                    case "Master Library":
                        coursename = DatabaseTools.GetEnabledCourse(Enumerations.CourseType.MasterLibrary);
                        break;
                    case "Container":
                        coursename = DatabaseTools.GetEnabledCourse(Enumerations.CourseType.ContainerCourse);
                        break;
                    case "Empty":
                        coursename = DatabaseTools.GetEnabledCourse(Enumerations.CourseType.EmptyCourse);
                        break;
                    case "Master Course":
                        coursename = DatabaseTools.GetEnabledCourse(Enumerations.CourseType.MasterCourse);
                        break;
                    case "AuthoredMasterLibrary":
                        coursename = DatabaseTools.GetEnabledCourse(Enumerations.CourseType.AuthoredMasterLibrary);
                        break;
                    case "MySpanishLab Master Course":
                        coursename = DatabaseTools.GetEnabledCourse(Enumerations.CourseType.MySpanishLabMasterCourse);
                        break;
                }
                GenericHelper.SelectDefaultWindow();
                GenericHelper.WaitUntilElement(By.Id("ifrmWorkspace"));
                WebDriver.SwitchTo().Frame("ifrmWorkspace");
                GenericHelper.WaitUntilElement(By.Id("ancLeftSearch"));
                IWebElement ancLeftSearch = WebDriver.FindElement(By.Id("ancLeftSearch"));
                new Actions(WebDriver).Click(ancLeftSearch).Perform();
                GenericHelper.WaitUntilElement(By.Id("ifrmLeft"));
                WebDriver.SwitchTo().Frame("ifrmLeft");
                GenericHelper.WaitUntilElement(By.Id("txtCourseDetail"));
                WebDriver.FindElement(By.Id("txtCourseDetail")).SendKeys(coursename);
                GenericHelper.WaitUntilElement(By.Id("btn_search"));
                IWebElement btnSearch = WebDriver.FindElement(By.Id("btn_search"));
                new Actions(WebDriver).Click(btnSearch).Perform();
                Thread.Sleep(5000);
                GenericHelper.WaitUntilElement(By.Id("grdCourse"));
                #region Browser Selection
                if (Browser.Equals("FF") || Browser.Equals("GC"))
                {
                    if (WebDriver.FindElement(By.Id("grdCourse")).Text.Contains(coursename))
                    {
                        GenericHelper.Logs(string.Format("Published Course '{0}' found in Manage products page", coursename), "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs(string.Format("Published Course '{0}' not found in Manage products page", coursename), "FAILED");
                        throw new NoSuchElementException(string.Format("Published Course '{0}' not found in Manage products page", coursename));
                    }
                }
                if (Browser.Equals("IE"))
                {
                    if (WebDriver.FindElement(By.Id("grdCourse")).GetAttribute("innerText").Contains(coursename))
                    {
                        GenericHelper.Logs(string.Format("Published Course '{0}' found in Manage products page", coursename), "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs(string.Format("Published Course '{0}' not found in Manage products page", coursename), "FAILED");
                        throw new NoSuchElementException(string.Format("Published Course '{0}' not found in Manage products page", coursename));
                    }
                }
                #endregion Browser Selection
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
                while (sw.Elapsed.Minutes < minutesToWait)
                {
                    if (GenericHelper.IsElementPresent(By.XPath(Text_AssignedToCopy)) == false) break;
                    {
                        GenericHelper.SelectDefaultWindow();
                        GenericHelper.WaitUntilElement(By.Id("ifrmWorkspace"));
                        WebDriver.SwitchTo().Frame("ifrmWorkspace");
                        GenericHelper.WaitUntilElement(By.Id("ancLeftSearch"));
                        IWebElement courseLeftSearch = WebDriver.FindElement(By.Id("ancLeftSearch"));
                        new Actions(WebDriver).Click(courseLeftSearch).Perform();
                        GenericHelper.WaitUntilElement(By.Id("ifrmLeft"));
                        WebDriver.SwitchTo().Frame("ifrmLeft");
                        GenericHelper.WaitUntilElement(By.Id("txtCourseDetail"));
                        WebDriver.FindElement(By.Id("txtCourseDetail")).SendKeys(coursename);
                        GenericHelper.WaitUntilElement(By.Id("btn_search"));
                        IWebElement buttonSearch = WebDriver.FindElement(By.Id("btn_search"));
                        new Actions(WebDriver).Click(buttonSearch).Perform();
                        Thread.Sleep(15000);
                        // GenericHelper.WaitUntilElement(By.Id("grdCourse"));
                        GenericHelper.WaitUntilElement(By.ClassName("grdCourseNameTextColCss"));
                    }
                }
                if (GenericHelper.IsElementPresent(By.XPath(Text_AssignedToCopy)))
                {
                    GenericHelper.Logs(string.Format("[AssignedToCopy] state has not validated under:'{0}' minutes for copying '{1}'.", minutesToWait, coursename), "FAILED");
                }
                else
                {
                    GenericHelper.Logs(string.Format("[AssignedToCopy] state has validated under:'{0}' minutes for copying '{1}'.", minutesToWait, coursename), "PASSED");
                }

                sw.Stop();
                sw = null;
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Click Select All CheckBox of course
        public void ClickSelectAllCheckBox()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("grdCourse$_ctrl0"));
                WebDriver.FindElement(By.Id("grdCourse$_ctrl0")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Click Course Cmenu
        public void ClickCmenu()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("grdCourse"));
                bool isCourseAlreadyPublished = GenericHelper.IsElementPresent(By.XPath("//table[@id='grdCourse']/tbody/tr/td[4]/img[contains(@src,'/images/SMSIntegration/ProgramManagement/icn_approvedStatus.gif')]"));
                if (isCourseAlreadyPublished)
                {
                    GenericHelper.Logs("Course is already published, so no need to publish it again.", "PASSED");
                    return;
                }
                else
                {
                    #region Browser Selection

                    if (Browser.Equals("IE"))
                    {
                        GenericHelper.WaitUntilElement(By.Id("grdCourse"));
                        GenericHelper.WaitUntilElement(By.XPath(Cmenu_Course));
                        WebDriver.FindElement(By.XPath(Cmenu_Course)).SendKeys("");
                        WebDriver.FindElement(By.XPath(Cmenu_Course)).Click();
                    }
                    if (Browser.Equals("FF"))
                    {
                        GenericHelper.WaitUntilElement(By.Id("grdCourse"));
                        GenericHelper.WaitUntilElement(By.XPath(Cmenu_Course));
                        WebDriver.FindElement(By.XPath(Cmenu_Course)).SendKeys("");
                        WebDriver.FindElement(By.XPath(Cmenu_Course)).Click();
                        WebDriver.FindElement(By.XPath(Cmenu_Course)).Click();
                    }

                    if (Browser.Equals("GC"))
                    {
                        GenericHelper.WaitUntilElement(By.Id("grdCourse"));
                        WebDriver.FindElement(By.XPath(Cmenu_Course)).Click();
                    }

                    #endregion Browser Selection
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: locator property defined
        private string Cmenu_Course
        {
            get { return "//table[@id='grdCourse']/tbody/tr/td[5]/center/a/img"; }
        }

        //Purpose: locator property defined
        private string Text_AssignedToCopy
        {
            get { return "//font[@class='reqCharRed']"; }
        }
    }
}
