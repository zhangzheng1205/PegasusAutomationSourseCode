using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook
{
    public class GBStudentPage : BasePage
    {
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //purpose : To navigate To BenchmarkTests Folder Under Grades Tab
        public void NavigateToBenchmarkTestsFolderUnderGradesTab()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("Frame1"));
                WebDriver.SwitchTo().Frame("Frame1");
                Thread.Sleep(1000);
                WebDriver.FindElement(By.PartialLinkText("Benchmark Tests")).SendKeys("");
                WebDriver.FindElement(By.PartialLinkText("Benchmark Tests")).Click();
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Open Authored Activity
        public void OpenBenchmarkTest1ActivityInGradesTab()
        {
            try
            {
                Actions builder = new Actions(WebDriver);
                GenericHelper.SelectDefaultWindow();
                WebDriver.SwitchTo().ActiveElement();
                WebDriver.SwitchTo().Frame("srcGBFrame");
                GenericHelper.WaitUntilElement(By.Id("_ctl0_InnerPageContent_AllItem"));
                if (Browser.Equals("FF"))
                {
                    GenericHelper.WaitUntilElement(By.XPath("//table[@id='GridStudent']/tbody/tr/td[2]/span"));
                    WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/tbody/tr/td[2]/span")).SendKeys("");
                    WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/tbody/tr/td[2]/span")).Click();
                    IWebElement menu1 = WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/descendant::input[contains(@src,'/Pegasus/images/spacer.gif')]"));
                    menu1.Click();
                }
                if (Browser.Equals("IE"))
                {
                    GenericHelper.WaitUntilElement(By.XPath("//table[@id='GridStudent']/tbody/tr/td[2]/span"));
                    WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/tbody/tr/td[2]/span")).SendKeys("");
                    Thread.Sleep(2000);


                    IWebElement moreButton = WebDriver.FindElement(By.CssSelector("input.CV_DownImg.CV_imgMore"));
                    moreButton.Click();

                    GenericHelper.WaitUntilElement(By.PartialLinkText("Open"));
                    WebDriver.FindElement(By.PartialLinkText("Open")).Click();


                    GenericHelper.WaitUtilWindow("Quiz");
                    //WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/tbody/tr/td[2]/span")).Click();
                    //IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
                    //js.ExecuteScript("return $(\"span:contains('Benchmark Test 1')\").mouseover();");
                    // Mouse Hover to Main Menu

                    //bool isOpenOptionDispalyed = GenericHelper.IsElementPresent(By.PartialLinkText("Open"));
                    //if (!isOpenOptionDispalyed)
                    //{

                    //    if (GenericHelper.IsElementPresent(By.PartialLinkText("Open")))
                    //    {
                    //        GenericHelper.Logs("'Open' option not dislayed in the activity c-menu option.", "PASSED");
                    //    }
                    //    else
                    //    {
                    //        GenericHelper.Logs("'Open' option not dislayed in the activity c-menu option.", "FAILED");
                    //        throw new Exception("'Open' option not dislayed in the activity c-menu option.");
                    //    }
                    //}
                }
                if (Browser.Equals("GC"))
                {
                    IWebElement menu2 = WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/descendant::span[contains(@title, 'Benchmark Test 1')]"));
                    builder.MoveToElement(menu2).Build().Perform();
                    IWebElement menu1 = WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/descendant::input[contains(@src,'/Pegasus/images/spacer.gif')]"));
                    builder.MoveToElement(menu1).Click().Perform();
                }



            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purose: To verify the grades displayed under Grdes Tab for 'Benchmark Test 1' activity
        public void ToVerifyGradesUnderGradeTab()
        {
            try
            {
                GenericHelper.SelectWindow("Gradebook");
                WebDriver.SwitchTo().Frame("srcGBFrame");
                GenericHelper.WaitUntilElement(By.Id("_ctl0_InnerPageContent_AllItem"));
                WebDriver.SwitchTo().ActiveElement();
                #region BrowserSelection
                if (Browser.Equals("FF"))
                {
                    GenericHelper.WaitUntilElement(By.XPath("//table[@id='GridStudent']/tbody/tr/td[2]/span/span"));
                    if (WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/tbody/tr/td[2]/span/span")).Text.Contains("Benchmark Test 1"))
                    {
                        string viewGrades = WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/tbody/tr/td[3]")).Text.Trim();
                        if (viewGrades.Equals("--"))
                        {
                            GenericHelper.Logs(string.Format("Actaul Grade=  '{0}'  displayed for the activity, activity has not been submitted by the student.", viewGrades), "FAILED");
                            throw new Exception(string.Format("Actaul Grade=  '{0}'  displayed for the activity, activity has not been submitted by the student.", viewGrades));
                        }
                        if ("".Equals(viewGrades))
                        {
                            GenericHelper.Logs(string.Format("Actaul Grade=  '{0}'  displayed for the activity, grade not calculated for the submitted activity by the student.", viewGrades), "FAILED");
                            throw new Exception(string.Format("Actaul Grade=  '{0}'  displayed for the activity, grade not calculated for the submitted activity by the student.", viewGrades));
                        }
                        decimal intscore = Convert.ToDecimal(viewGrades);
                        if (intscore <= 0 || intscore > 0)
                        {
                            GenericHelper.Logs(" Activity Submission Grades are displayed and Student is Failed in the Activity.", "PASSED");
                        }
                        else
                        {
                            GenericHelper.Logs(" Activity Submission Grades are not displayed.", "FAILED");
                            throw new Exception("Activity Submission Grades are not displayed.");
                        }
                    }
                }
                if (Browser.Equals("IE"))
                {
                    GenericHelper.WaitUntilElement(By.XPath("//table[@id='GridStudent']/tbody/tr/td[2]/span/span"));
                    if (WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/tbody/tr/td[2]/span/span")).GetAttribute("innerText").Contains("Benchmark Test 1"))
                    {
                        string viewGrades = WebDriver.FindElement(By.XPath("//table[@id='GridStudent']/tbody/tr/td[3]")).Text;
                        if (viewGrades == null) throw new ArgumentNullException(string.Format("Grades value {0} is null.", null));
                        if (viewGrades.Equals("--"))
                        {
                            GenericHelper.Logs(string.Format("Actaul Grade=  '{0}'  displayed for the activity, activity has not been submitted by the student.", viewGrades), "FAILED");
                            throw new Exception(string.Format("Actaul Grade=  '{0}'  displayed for the activity, activity has not been submitted by the student.", viewGrades));
                        }
                        if (viewGrades.Equals(""))
                        {
                            GenericHelper.Logs(string.Format("Actaul Grade=  '{0}'  displayed for the activity, grade not calculated for the submitted activity by the student.", viewGrades), "FAILED");
                            throw new Exception(string.Format("Actaul Grade=  '{0}'  displayed for the activity, grade not calculated for the submitted activity by the student.", viewGrades));
                        }
                        decimal intscore = Convert.ToDecimal(viewGrades);
                        if (intscore <= 0 || intscore > 0)
                        {
                            GenericHelper.Logs(" Activity Submission Grades are displayed and Student is Failed in the Activity.", "PASSED");
                        }
                        else
                        {
                            GenericHelper.Logs(" Activity Submission Grades are not displayed.", "FAILED");
                            throw new Exception("Activity Submission Grades are not displayed.");
                        }
                    }
                    else
                    {
                        GenericHelper.Logs(" Activity named as 'Benchmark Test 1' not found under grades tab.", "FAILED");
                    }
                }
                #endregion BrowserSelection
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.SelectWindow("Gradebook");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
