using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook
{
    public class GBInstructorUXPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //Purpose : To open the Benchmark Tests Folder
        public void NavigateToBenchmarkTestsFolderUnderGradeBookTab()
        {
            try
            {
                string folderName = null;
                GenericHelper.SelectWindow("Gradebook");
                GenericHelper.WaitUntilElement(By.Id("Iframe1"));
                WebDriver.SwitchTo().Frame("Iframe1");
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='rptrFolderContent']"));
                string iFrameContent = WebDriver.FindElement(By.XPath("//div[@id='rptrFolderContent']")).Text.Trim();
                if (iFrameContent.Contains("Benchmark Tests"))
                {
                    int foldercount = WebDriver.FindElements(By.XPath("//div[@id='rptrFolderContent']/div")).Count();
                    for (int i = 1; i <= foldercount; i++)
                    {
                        if (Browser.Equals("FF") || Browser.Equals("GC"))
                        {
                            folderName = WebDriver.FindElement(By.XPath("//div[@id='rptrFolderContent']/div[" + i.ToString(CultureInfo.InvariantCulture) + "]")).Text;
                        }
                        if (Browser.Equals("IE"))
                        {
                            folderName = WebDriver.FindElement(By.XPath("//div[@id='rptrFolderContent']/div[" + i.ToString(CultureInfo.InvariantCulture) + "]")).GetAttribute("innerText");
                        }
                        if (folderName != null && folderName.Contains("Benchmark Tests"))
                        {
                            Thread.Sleep(3000);
                            if (Browser.Equals("FF") || Browser.Equals("IE"))
                            {
                                WebDriver.FindElement(By.XPath("//div[@id='rptrFolderContent']/div[" + i.ToString(CultureInfo.InvariantCulture) + "]/div[2]/span")).SendKeys("");
                            }
                            WebDriver.FindElement(By.XPath("//div[@id='rptrFolderContent']/div[" + i.ToString(CultureInfo.InvariantCulture) + "]/div[2]/span")).Click();
                            WebDriver.SwitchTo().DefaultContent();
                            break;
                        }
                    }
                }
                else
                {
                    GenericHelper.Logs("Authored Activity is not found under Gradebook Filters.", "FAILED");
                    throw new Exception("Authored Activity is not found under Gradebook Filters.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To Verify The Grade Displayed
        public void VerifyTheGradeDisplayed()
        {
            try
            {
                GenericHelper.SelectWindow("Gradebook");
                GenericHelper.WaitUntilElement(By.Id("srcGBFrame"));
                WebDriver.SwitchTo().Frame("srcGBFrame");
                GenericHelper.WaitUntilElement(By.XPath("//table[@id='GBGridLeftTableHolder']/tbody/tr"));
                int studentcount = WebDriver.FindElements(By.XPath("//table[@id='GBGridLeftTableHolder']/tbody/tr")).Count();
                for (int i = 1; i < studentcount; i++)
                {
                    string isStudentDisplayed = WebDriver.FindElement(By.XPath("//table[@id='GBGridLeftTableHolder']/tbody/tr[" + i.ToString(CultureInfo.InvariantCulture) + "]/td[2]")).GetAttribute("Title");
                    string getStudenFromDB = DatabaseTools.GetUsername(Enumerations.UserType.CsStudent);
                    if (isStudentDisplayed.Contains(getStudenFromDB))
                    {
                        string grade = WebDriver.FindElement(By.XPath("//table[@id='GBGridDataTable']/tbody/tr[" + i.ToString(CultureInfo.InvariantCulture) + "]/td[5]")).GetAttribute("title").Trim();
                        try
                        {
                            if (grade.Equals("--"))
                            {
                                GenericHelper.Logs(string.Format("Actaul Grade=  '{0}'  displayed for the activity, activity has not been submitted by the student.", grade), "FAILED");
                                throw new Exception(string.Format("Actaul Grade=  '{0}'  displayed for the activity, activity has not been submitted by the student.", grade));
                            }
                            if (grade.Equals(""))
                            {
                                GenericHelper.Logs(string.Format("Actaul Grade=  '{0}'  displayed for the activity, grade not calculated for the submitted activity by the student.", grade), "FAILED");
                                throw new Exception(string.Format("Actaul Grade=  '{0}'  displayed for the activity, grade not calculated for the submitted activity by the student.", grade));
                            }
                        }
                        catch (Exception e)
                        {
                            WebDriver.SwitchTo().DefaultContent();
                            GenericHelper.SelectWindow("Gradebook");
                            GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                            WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                            GenericHelper.SelectWindow("Global Home");
                            GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                            throw e;
                        }
                        decimal intscore = Convert.ToDecimal(grade);
                        if (intscore <= 0 || intscore > 0)
                        {
                            GenericHelper.Logs("Actual Grade= " + grade + " displayed for the submitted activity by student", "PASSED");
                        }
                        else
                        {
                            GenericHelper.Logs("Actaul Grade= " + grade + "  displayed for the submitted activity by student", "FAILED");
                        }
                    }
                    else
                    {
                        GenericHelper.Logs("Created Student has not displayed in the Gradebook.", "FAILED ");
                        throw new Exception("Created Student has not displayed in the Gradebook.");
                    }
                    GenericHelper.SelectDefaultWindow();
                    break;
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Click Activity C-Menu Option
        public void ClickActivityCmenu(string activityName)
        {
            try
            {

                GenericHelper.WaitUntilElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[2]/span"));
                Int32 columncnt = WebDriver.FindElements(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td")).Count();

                for (int i = 2; i <= columncnt; i++)
                {
                    string actName = WebDriver.FindElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[" + i + "]/span/a")).GetAttribute("title");

                    if (actName == activityName)
                    {

                        IWebElement element = WebDriver.FindElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[" + i + "]/div"));
                        // IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriver;
                        // executor.ExecuteScript("arguments[0].click();", element);
                        Actions builder = new Actions(WebDriver);
                        // IWebElement Cmenu = WebDriver.FindElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[2]/div"));
                        builder.MoveToElement(element).Build().Perform();
                        builder.MoveToElement(element).Click().Perform();

                        break;
                    }


                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To Click on View Submission Link
        public void ClickViewAllSubmissionsLink()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("_ctl0_InnerPageContent_lblviewallsubmissions"));

                WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_lblviewallsubmissions")).Click();
                Thread.Sleep(2000);
                WebDriver.SwitchTo().DefaultContent();
                bool isViewSubmissonWindowOpened = GenericHelper.IsPopUpWindowPresent("View Submission");
                if (isViewSubmissonWindowOpened)
                {
                    GenericHelper.SelectWindow("View Submission");
                    WebDriver.Manage().Window.Maximize();
                }
                else
                {
                    GenericHelper.Logs("'View Submission' window not opened.", "FAILED");
                    Assert.Fail("'View Submission' window not opened.");
                }

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        //Purpose: To Click viewgrades of Study plan

        public void ClickViewGrades(string SpName)
        {
            try
            {
                // GenericHelper.WaitUntilElement(By.Id("srcGBFrame"));
                // WebDriver.SwitchTo().Frame("srcGBFrame");
                GenericHelper.WaitUntilElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[2]/span"));
                Int32 columncnt = WebDriver.FindElements(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td")).Count();

                for (int i = 2; i <= columncnt; i++)
                {
                    // WebDriver.FindElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[" + i + "]/span/a")).SendKeys("");
                    string actName = WebDriver.FindElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[" + i + "]/span/a")).GetAttribute("title");

                    if (actName == SpName)
                    {
                        // GenericHelper.SelectDefaultWindow();
                        // WebDriver.SwitchTo().Frame("srcGBFrame");
                        // IWebElement element = WebDriver.FindElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[" + i + "]"));
                        IWebElement element = WebDriver.FindElement(By.XPath("//table[@id='GBGridHeaderTable']/tbody/tr/td[" + i + "]/span/a"));
                        // IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriver;
                        // executor.ExecuteScript("arguments[0].click();", element);
                        Actions builder = new Actions(WebDriver);
                        IWebElement Cmenu = WebDriver.FindElement(By.XPath("//table[@id='GBGridDataTable']/tbody/tr[2]/td[" + i + "]"));
                        builder.MoveToElement(Cmenu).Build().Perform();
                        // int Xpoint = element.Location.X;
                        // int Ypoint = element.Location.Y;
                        // Point obj = new Point(425, 225);
                        // Thread.Sleep(2000);
                        // Mouse.Hover(obj);
                        // Thread.Sleep(3000);
                        //Mouse.Move(new Point(425 + 20, 225 + 120));
                        //Mouse.Move(new Point(425 + 30, 225 + 122));
                        Thread.Sleep(2000);
                        IWebElement ViewGrades = WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_viewgrade"));
                        //builder.MoveByOffset(0,-100).Build().Perform();
                        //  WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_viewgrade")).Click();
                        builder.MoveToElement(ViewGrades).Perform();
                        // builder.MoveToElement(ViewGrades).Build().Perform();
                        builder.Click(ViewGrades).Perform();
                        // ViewGrades.SendKeys("");
                        // ViewGrades.Click();
                        // Point fgs=WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_viewgrade")).Location;

                        break;
                    }



                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To verify due date
        public bool VerifyDate(string datedue)
        {
            string date1 =
                WebDriver.FindElement(By.XPath("//table[@id='tblGBRepHtbl2']/tbody/tr/td/span")).GetAttribute("innerText");
            string date2 =
                WebDriver.FindElement(By.XPath("//table[@id='tblGBRepHtbl2']/tbody/tr/td[2]/span")).GetAttribute("innerText");
            if (date1.Contains(datedue) && date2.Contains(datedue))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
