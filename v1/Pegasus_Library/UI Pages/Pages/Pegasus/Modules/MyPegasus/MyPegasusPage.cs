using System;
using System.Configuration;
using System.Globalization;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using System.Linq;
using System.Threading;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.MyPegasus
{
    public class MyPegasusPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        string Browser = ConfigurationManager.AppSettings["browser"];

        //Purpose : to Select the class created using template option in Global home page
        public void SelectTemplateClass()
        {
            try
            {
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                if (GenericHelper.IsElementPresent(By.Id("lightboxid")))
                {
                    bool isAnnouncementClose = GenericHelper.CloseAnnouncementPage();
                    if (isAnnouncementClose)
                    {
                        GenericHelper.Logs("Announcement Pop up has been closed successfully", "Passed");
                    }
                    else
                    {
                        GenericHelper.Logs("Announcement Pop up has not been closed", "Failed");
                    }
                }
                GenericHelper.WaitUntilElement(By.Id("tblMain"));
                int classCount = WebDriver.FindElements(By.XPath("//table[@id='tblMain']/tbody/tr")).Count;
                string classname = string.Empty;
                for (int i = 1; i <= classCount; i++)
                {
                    if (Browser.Equals("IE"))
                    {
                        classname = WebDriver.FindElement(By.XPath("//table[@id='tblMain']/tbody/tr[" + i.ToString(CultureInfo.InvariantCulture) + "]")).GetAttribute("innerText");
                    }
                    if (Browser.Equals("FF") || Browser.Equals("GC"))
                    {
                        classname = WebDriver.FindElement(By.XPath("//table[@id='tblMain']/tbody/tr[" + i.ToString(CultureInfo.InvariantCulture) + "]")).Text;
                    }

                    if (classname.Contains(DatabaseTools.GetClass(Enumerations.ClassType.NovaNETTemplate)))
                    {
                        if (Browser.Equals("FF") || Browser.Equals("IE"))
                        {
                            WebDriver.FindElement(By.XPath("//table[@id='tblMain']/tbody/tr[" + i.ToString(CultureInfo.InvariantCulture) + "]/td/div/table/tbody/tr/td/div/div")).SendKeys("");
                        }
                        WebDriver.FindElement(By.XPath("//table[@id='tblMain']/tbody/tr[" + i.ToString(CultureInfo.InvariantCulture) + "]/td/div/table/tbody/tr/td/div/div")).Click();
                        break;
                    }
                    else if (i == classCount)
                    {
                        GenericHelper.Logs(DatabaseTools.GetClass(Enumerations.ClassType.NovaNETTemplate) + " class not found in global home page", "FAILED");
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }

        }

        //Purpose: To Wait For Add Channel Pane
        public void WaitForAddchannels()
        {
            GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
        }

        //Purpose: To select the course in global home page As Teacher
        public void ClickOnCourseAsTeacher()
        {
            try
            {
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                if (GenericHelper.IsElementPresent(By.Id("lightboxid")))
                {
                    bool isAnnouncementClose = GenericHelper.CloseAnnouncementPage();
                    if (isAnnouncementClose)
                    {
                        GenericHelper.Logs("Announcement Pop up has been closed successfully", "Passed");
                    }
                    else
                    {
                        GenericHelper.Logs("Announcement Pop up has not been closed", "Failed");
                    }
                }
                GenericHelper.WaitUntilElement(By.ClassName("cssQuickLink"));
                bool isClassPresent = GenericHelper.IsElementPresent(By.ClassName("cssQuickLink"));
                if (isClassPresent)
                {
                    WebDriver.FindElement(By.ClassName("cssQuickLink")).Click();
                }
                else
                {
                    GenericHelper.Logs("Class not visible to the Teacher, so unable to proceed.", "FAILED");
                    Assert.Fail("Class not visible to the Teacher, so unable to proceed.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To select the course in global home page As Student
        public void ClickOnCourseAsStudent()
        {
            try
            {
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                if (GenericHelper.IsElementPresent(By.Id("lightboxid")))
                {
                    bool isAnnouncementClose = GenericHelper.CloseAnnouncementPage();
                    if (isAnnouncementClose)
                    {
                        GenericHelper.Logs("Announcement Pop up has been closed successfully", "Passed");
                    }
                    else
                    {
                        GenericHelper.Logs("Announcement Pop up has not been closed", "Failed");
                    }
                }
                GenericHelper.WaitUntilElement(By.ClassName("CourseNameFont"));
                bool isClassPresent = GenericHelper.IsElementPresent(By.ClassName("CourseNameFont"));
                if (isClassPresent)
                {
                    WebDriver.FindElement(By.ClassName("CourseNameFont")).Click();
                    Thread.Sleep(10000);
                    if (!WebDriver.Url.Contains("TodaysViewUX"))
                    {
                        WebDriver.FindElement(By.ClassName("CourseNameFont")).Click();
                        Thread.Sleep(10000);
                    }
                }
                else
                {
                    GenericHelper.Logs("Class not visible to the Student, so unable to proceed.", "FAILED");
                    Assert.Fail("Class not visible to the Student, so unable to proceed.");
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
