using System;
using System.Configuration;
using System.Threading;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook
{
    public class GBRoasterGridUXPage : BasePage
    {
        //To grant TA privileges
        public void ToGrantTAPrivilege()
        {
            string studentName = DatabaseTools.GetUsername(Enumerations.UserType.CsSmsStudent);
            studentName = studentName.Substring(0, 15);
            int rowno = 1;
            GenericHelper.SelectWindow("Roster");
            WebDriver.SwitchTo().Frame("frameRoster");
            GenericHelper.WaitUntilElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]"));
            string rowData = WebDriver.FindElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]")).Text;
            if (!rowData.Contains(studentName))
            {
                while (!rowData.Contains(studentName))
                {
                    rowno = rowno + 1;
                    string rowDataNextRow = WebDriver.FindElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]")).Text;
                    if (rowDataNextRow.Contains(studentName))
                    {
                        GenericHelper.Logs("Row has the name for student whom grant TA would be done", "Passed");
                        string mouseHovertext =
                           WebDriver.FindElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]/td[3]/span")).Text;
                        IWebElement mouseHover = WebDriver.FindElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]/td[3]/span/span"));
                        new Actions(WebDriver).MoveToElement(mouseHover).Build().Perform();
                        GenericHelper.WaitUntilElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]/td[3]/span/img"));
                        WebDriver.FindElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]/td[3]/span/img")).SendKeys("");
                        Thread.Sleep(2000);

                        //Java script to click on the cmenu
                        IWebElement element = WebDriver.FindElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]/td[3]/span/img"));
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriver;
                        executor.ExecuteScript("arguments[0].click();", element);

                        GenericHelper.WaitUntilElement(By.PartialLinkText("Grant TA Privileges"));
                        WebDriver.FindElement(By.PartialLinkText("Grant TA Privileges")).Click();

                        string roleText =
                       WebDriver.FindElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]/td[7]")).Text;
                        if (roleText.Contains("Teaching Assistant"))
                        {
                            GenericHelper.Logs("Role has been updated to Teaching assistant", "Passed");
                            DatabaseTools.UpdateUserPromotedStatusTrue(studentName);
                        }
                        WebDriver.SwitchTo().DefaultContent();
                        GenericHelper.SelectWindow("Roster");
                        break;
                    }

                }
            }
            else
            {
                GenericHelper.Logs("Row has the name for student whom grant TA would be done", "Passed");
                string mouseHovertext =
                   WebDriver.FindElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]/td[3]/span")).Text;
                IWebElement mouseHover = WebDriver.FindElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]/td[3]/span/span"));
                new Actions(WebDriver).MoveToElement(mouseHover).Build().Perform();
                GenericHelper.WaitUntilElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]/td[3]/span/img"));
                WebDriver.FindElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]/td[3]/span/img")).SendKeys("");
                Thread.Sleep(2000);

                //Java script to click on the cmenu
                IWebElement element = WebDriver.FindElement(By.CssSelector("img.GBTextAlign"));
                IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriver;
                executor.ExecuteScript("arguments[0].click();", element);
              
                GenericHelper.WaitUntilElement(By.PartialLinkText("Grant TA Privileges"));
                WebDriver.FindElement(By.PartialLinkText("Grant TA Privileges")).Click();

                string roleText =
               WebDriver.FindElement(By.XPath("//table[@id='GridRoster']/tbody/tr[" + rowno + "]/td[7]")).Text;
                if (roleText.Contains("Teaching Assistant"))
                {
                    GenericHelper.Logs("Role has been updated to Teaching assistant", "Passed");
                    DatabaseTools.UpdateUserPromotedStatusTrue(studentName);
                }
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.SelectWindow("Roster");
            }

        }


        //To verify courses for TA 
        public void ToGrantCoursesforTa()
        {

        }
    }
}
