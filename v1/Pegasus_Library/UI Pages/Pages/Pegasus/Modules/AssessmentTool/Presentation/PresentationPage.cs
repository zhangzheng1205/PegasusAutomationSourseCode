using System;
using System.Configuration;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool.Presentation
{
    public class PresentationPage : BasePage
    {
        //Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //Purpose : To verify activity has launched by the student side
        public void VerifyActivityLaunch()
        {
            try
            {
                if (GenericHelper.WaitUntillWindowAndElement("Test", By.ClassName("btn_p")))
                {
                    WebDriver.Manage().Window.Maximize();
                    GenericHelper.WaitUntilElement(By.ClassName("btn_p"));
                    WebDriver.FindElement(By.ClassName("btn_p")).Click();
                    Thread.Sleep(15000); // This I have added to wait for the activity to get loded
                    GenericHelper.WaitUntilElement(By.ClassName("btn_next_quest"));
                    IWebElement isactivitylaunched = WebDriver.FindElement(By.ClassName("btn_next_quest"));
                    if (isactivitylaunched.Displayed)
                    {
                        GenericHelper.Logs("Activity launched successfully by the student.", "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs("Activity not launched successfully by the student.", "FAILED");
                        Assert.Fail("Activity not launched successfully by the student.");
                    }
                }
                else
                {
                    GenericHelper.Logs("Activity Presentation Window not Opened.", "FAILED");
                    Assert.Fail("Activity Presentation Window not Opened.");
                }
                WebDriver.Close();
                GenericHelper.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Test"))
                {
                    GenericHelper.SelectWindow("Test");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To Attempt and Submit Basic/Random Type Authored Activity by Student
        public void SubmittingBenchmarkTest1()
        {
            try
            {
                GenericHelper.SelectWindow("Quiz");
                GenericHelper.WaitUntilElement(By.Id("btnOpen"));
                WebDriver.FindElement(By.Id("btnOpen")).Click();
                //Thread.Sleep(15000);// This I have added to wait for the activity to get loded
                //Purpose: Verifying Activity Already Been Attempted

                bool isPageLoaded = GenericHelper.WaitForUrlGetChange("intAssetID");
                if (!isPageLoaded)
                {
                    GenericHelper.Logs("Activity Presentation page has not loaded in the ideal time interval.", "FAILED");
                    Assert.Fail("Activity Presentation page has not loaded in the ideal time interval");
                }

                if (Browser.Equals("IE") || Browser.Equals("FF"))
                {

                    //Purpose: Clicking First option of Answer(s)
                    GenericHelper.WaitUntilElement(By.XPath("//table[@id='MainQuestionLayoutDefault']/tbody/tr[2]/td/table/tbody/tr[3]/td[2]/input"));
                    IWebElement clickAnswerOption = WebDriver.FindElement(By.XPath("//table[@id='MainQuestionLayoutDefault']/tbody/tr[2]/td/table/tbody/tr[3]/td[2]/input"));
                    clickAnswerOption.Click();
                    GenericHelper.WaitUntilElement(By.Id("btnSubmit1"));
                    WebDriver.FindElement(By.Id("btnSubmit1")).Click();
                    GenericHelper.WaitUntilElement(By.Id("_ctl0:APH:btnfinish"));
                    IWebElement btnfinish = WebDriver.FindElement(By.Id("_ctl0:APH:btnfinish"));
                    new Actions(WebDriver).Click(btnfinish).Perform();
                }
                if (Browser.Equals("GC"))
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
                    js.ExecuteScript("return $(\"a:contains('Finish')\").click();");
                    Thread.Sleep(7000);
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                WebDriver.Close();
                throw new Exception(e.ToString());
            }
        }

        //Purpose : to verify the activity submission      
        public void ToVerifyActivitySubmission()
        {
            try
            {
                //Purpose: Wait for Activity Presentation page gets loded
                bool waitForThinkingIndicatorClose = GenericHelper.ThinkingIndicatorProcessing();
                if (waitForThinkingIndicatorClose)
                {
                    GenericHelper.Logs("Activity Submission page has been successfully loaded.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Activity Submission page has not been successfully loaded under ideal time interval.", "FAILED");
                    Assert.Fail("Activity Submission page has not been successfully loaded under ideal time interval.");
                }
                WebDriver.SwitchTo().DefaultContent();
                if (GenericHelper.IsElementPresent((By.PartialLinkText("Return to Course"))))
                {
                    GenericHelper.Logs("Activity submitted by the student successfully.", "PASSED");

                    GenericHelper.WaitUntilElement(By.PartialLinkText("Return to Course"));
                    WebDriver.FindElement(By.PartialLinkText("Return to Course")).Click();

                    GenericHelper.SelectWindow("Quiz");
                    GenericHelper.WaitUntilElement(By.Id("btnClose"));
                    IWebElement clickClose = WebDriver.FindElement(By.Id("btnClose"));
                    clickClose.Click();
                    Thread.Sleep(3000);
                }
                else
                {
                    GenericHelper.Logs("Activity not submitted by student successfully.", "FAILED");
                }

                if (GenericHelper.IsPopUpClosed(2))
                {
                    GenericHelper.Logs("Presentation window closed on clicking 'Return to Course'", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Presentation window not closed on clicking 'Return to Course'", "FAILED");
                    WebDriver.Close();
                    Assert.Fail("Presentation window not closed on clicking 'Return to Course'");
                }
                GenericHelper.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Quiz"))
                {
                    GenericHelper.SelectWindow("Quiz");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }
    }
}
