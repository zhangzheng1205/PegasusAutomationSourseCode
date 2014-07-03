using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Template
{
    public class AddTemplatePage : BasePage
    {
        //Purpose: Method to select Licenses Tab
        public void ToCreateTemplate()
        {
            string templateName = GenericHelper.GenerateUniqueVariable("Template");
            try
            {
                GenericHelper.SelectWindow("Add Template");
                GenericHelper.WaitUntilElement(By.Id("txtTempname"));
                WebDriver.FindElement(By.Id("txtTempname")).SendKeys(templateName);
                WebDriver.FindElement(By.Id("txtTempDesc")).SendKeys(GenericHelper.GenerateUniqueVariable("DescriptionTemplate"));
                GetCcNameandMatch();
                WebDriver.FindElement(By.Id("imgbtnAddTemplate")).Click();
                Thread.Sleep(60000);//This I have added because of page get submit
                bool isCreateTemplateWindowClosed = GenericHelper.IsPopUpClosed(3);
                if (isCreateTemplateWindowClosed)
                {
                    GenericHelper.Logs("'Add Template' window has been closed successfully.", "PASSED");
                    //Purpose: If Create Template' window has been closed successfull then update Template Name in DB
                    DatabaseTools.UpdateTemplate(templateName);
                }
                else
                {
                    GenericHelper.Logs("'Add Template' window has not been closed after the given time interval due to slowness or program text.", "Failed");
                    Assert.Fail("'Add Template' window has not been closed after the given time interval due to slowness or program text.");
                    //Purpose: Handling Template Program To Get Ready
                    #region WaitForProgramToGetReady
                    bool isAddTemplateWindowPresent = GenericHelper.IsPopUpWindowPresent("Add Template");
                    if (isAddTemplateWindowPresent)
                    {
                        GenericHelper.SelectWindow("Add Template");
                        bool isErrMsgPresent = GenericHelper.IsElementPresent(By.Id("lblErrMsg"));
                        if (isErrMsgPresent)
                        {
                            string templateErrMsg = WebDriver.FindElement(By.Id("lblErrMsg")).Text;
                            if (templateErrMsg.Contains("Program is not yet"))
                            {
                                GenericHelper.Logs("'Program is not yet ready. Please try again on few minutes.' text is displayed", "Passed");
                                Stopwatch sw = new Stopwatch();
                                sw.Start();
                                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
                                while (sw.Elapsed.TotalMinutes < minutesToWait)
                                {
                                    Thread.Sleep(10000);
                                    if (!GenericHelper.IsElementPresent((By.Id("lblErrMsg"))))
                                    {
                                        break;
                                    }
                                    string templateProgramErrMsg = WebDriver.FindElement(By.Id("lblErrMsg")).Text;
                                    if (
                                        !templateProgramErrMsg.Contains("Program is not yet"))
                                    {
                                        GenericHelper.Logs("'Program is not yet ready. Please try again on few minutes' is validated aready for creation .", "PASSED");
                                        break;
                                    }
                                    else
                                    {
                                        WebDriver.Close();
                                        GenericHelper.SelectWindow("Manage Organization");
                                        WebDriver.SwitchTo().Frame("frm");
                                        GenericHelper.WaitUntilElement(By.XPath("//IMG[@class='tdAddImg']"));
                                        WebDriver.FindElement(By.XPath("//IMG[@class='tdAddImg']")).Click();
                                        if (!WebDriver.FindElement(By.XPath("//TR[@id='trTemplate']")).Displayed)
                                        {
                                            WebDriver.FindElement(By.XPath("//IMG[@class='tdAddImg']")).Click();
                                        }
                                        WebDriver.FindElement(By.XPath("//TR[@id='trTemplate']")).Click();
                                        WebDriver.SwitchTo().ActiveElement();
                                        GenericHelper.SelectWindow("Add Template");
                                        GenericHelper.WaitUntilElement(By.Id("txtTempname"));
                                        templateName = GenericHelper.GenerateUniqueVariable("Template");
                                        WebDriver.FindElement(By.Id("txtTempname")).SendKeys(templateName);
                                        WebDriver.FindElement(By.Id("txtTempDesc")).SendKeys(GenericHelper.GenerateUniqueVariable("DescriptionTemplate"));
                                        GetCcNameandMatch();
                                        WebDriver.FindElement(By.Id("imgbtnAddTemplate")).Click();
                                    }
                                }
                                if (GenericHelper.IsPopUpWindowPresent("Add Template"))
                                {
                                    GenericHelper.Logs("Program is not yet ready for template creation in specified interval of time .", "FAILED");
                                    Assert.Fail(string.Format("Program is not yet ready for template creation in specified interval of {0} time ", sw.Elapsed.TotalMinutes));
                                }

                                sw.Stop();
                                sw = null;
                            }
                            else
                            {
                                GenericHelper.Logs("Program is not yet ready for template creation in specified interval of time.", "FAILED");
                                Assert.Fail("Program is not yet ready for template creation in specified interval of time.");
                            }
                        }
                        else
                        {
                            GenericHelper.Logs("'.", "FAILED");
                            Assert.Fail("'Add Template' pop-up window has not been closed successfully.");
                        }
                    }
                    #endregion WaitForProgramToGetReady
                    else
                    {
                        GenericHelper.Logs("'Add Template' window has been closed successfully.", "PASSED");
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isAddTemplate = GenericHelper.IsPopUpWindowPresent("Add Template");
                if (isAddTemplate)
                {
                    GenericHelper.SelectWindow("Add Template");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Select the Container Course To Create Template
        public void GetCcNameandMatch()
        {
            try
            {
                int rowNo = 2;
                string dBcourseName = DatabaseTools.GetEnabledCourse(Enumerations.CourseType.ContainerCourse).Trim();
                string courseFrameMsg = WebDriver.FindElement(By.XPath("//table[@id='grdCourse']")).Text;
                if (courseFrameMsg.Contains("There are no courses"))
                {
                    GenericHelper.Logs("There is no container course(s) available to create Template.", "Failed");
                    WebDriver.Close();
                    Assert.Fail("There is no container course(s) available to create Template.");
                }
                GenericHelper.WaitUntilElement(
                    By.XPath("//table[@id='grdCourse']/tbody/tr[" + rowNo + "]/td[contains(@class,'RdColumnAlignName')]"));
                string getCcName = WebDriver.FindElement(By.XPath("//table[@id='grdCourse']/tbody/tr[" + rowNo + "]/td[contains(@class,'RdColumnAlignName')]")).Text.Trim();
                if (dBcourseName == getCcName)
                {
                    GenericHelper.WaitUntilElement(
                        By.XPath("//table[@id='grdCourse']/tbody/tr[" + rowNo +
                                 "]/td/INPUT[contains(@onclick,'ToGetCourseID(this);')]"));
                    WebDriver.FindElement(By.XPath("//table[@id='grdCourse']/tbody/tr[" + rowNo + "]/td/INPUT[contains(@onclick,'ToGetCourseID(this);')]")).Click();
                    GenericHelper.Logs("ContainerCourse has been successfully selected", "passed");
                }
                else
                {
                    GenericHelper.Logs("ContainerCourse fetched from DB is not present in the 'Add Template' pop-up.", "Failed");
                    Assert.Fail("ContainerCourse fetched from DB is not present in the 'Add Template' pop-up.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}