using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.CourseCatalog
{
    public class CourseCatalogMainPage : BasePage
    {

        private static string _catalogDbCourse;

        /// <summary>
        /// Purpose: To Search and Add Course From Catalog
        /// </summary>
        public string AddCourseInCatalog(string courseType)
        {
            string courseName = string.Empty;
            GenericHelper.SelectWindow("Global Home");
            WebDriver.SwitchTo().Frame(1);
            if (courseType.Equals("ProductTypeProg"))
            {
                GenericHelper.WaitUntilElement(By.Id("rndDiscipline"));
                WebDriver.FindElement(By.Id("rndDiscipline")).Click();
                new SelectElement(WebDriver.FindElement(By.Id("drdDiscipline"))).SelectByText("Art");
                courseName = GenericHelper.GenerateUniqueVariable("PRGCOURSE");
            }
            if (courseType.Equals("MasterCourse"))
            {
                GenericHelper.WaitUntilElement(By.Id("txtProductTextBook"));
                WebDriver.FindElement(By.Id("txtProductTextBook")).Clear();
                WebDriver.FindElement(By.Id("txtProductTextBook")).SendKeys("¡Anda! Curso elemental, 1e");
                courseName = GenericHelper.GenerateUniqueVariable("INSCOURSE");
            }
            GenericHelper.WaitUntilElement(By.CssSelector("span > span"));
            WebDriver.FindElement(By.CssSelector("span > span")).Click();
            //Purpose: To Search Course From Catalog
            ToSearchCourseInCatalog(courseType);
            GenericHelper.WaitUntilElement(By.Id("txtProductName"));
            WebDriver.FindElement(By.Id("txtProductName")).Clear();
            WebDriver.FindElement(By.Id("txtProductName")).SendKeys(courseName);
            GenericHelper.WaitUntilElement(By.Id("txtDesc"));
            WebDriver.FindElement(By.Id("txtDesc")).Clear();
            WebDriver.FindElement(By.Id("txtDesc")).SendKeys("BDD Course Description");
            GenericHelper.WaitUntilElement(By.CssSelector("#btnFinish > span > span"));
            WebDriver.FindElement(By.CssSelector("#btnFinish > span > span")).Click();
            return courseName;
        }

        /// <summary>
        /// Purpose: To Verify the Mail Error on the Catalog Light Box 
        /// </summary>
        public void ToVerifyCourseMailError()
        {
            try
            {
                if (GenericHelper.IsElementPresent(By.ClassName("messageBoardTextAlr")))
                {
                    IWebElement errorText = WebDriver.FindElement(By.ClassName("messageBoardTextAlr"));

                    //Condition to check the error message after clicking on the finish button
                    if (errorText.Text.Contains("There was an error"))
                    {
                        GenericHelper.Logs("Error Message is being shown hence clicking on the cancel button", "Passed");
                        GenericHelper.WaitUntilElement(By.CssSelector("#btnCancel > span > span"));
                        WebDriver.FindElement(By.CssSelector("#btnCancel > span > span")).Click();
                        WebDriver.SwitchTo().DefaultContent();
                        GenericHelper.SelectWindow("Global Home");
                        WebDriver.Navigate().Refresh();
                        //Condition to check the course is inactive after clicking on the finish button
                        if (GenericHelper.IsElementPresent(By.ClassName("cssCourseInactive")))
                        {
                            GenericHelper.Logs("Course is in inactive state hence need to wait", "Passed");
                        }
                    }
                }
                else
                {
                    WebDriver.SwitchTo().DefaultContent();
                    GenericHelper.SelectWindow("Global Home");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                GenericHelper.WaitUntilElement(By.CssSelector("#btnCancel > span > span"));
                WebDriver.FindElement(By.CssSelector("#btnCancel > span > span")).Click();
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.SelectWindow("Global Home");
                Assert.Fail(e.ToString());
            }
        }

        /// <summary>
        /// Purpose: To search Product Type Program
        /// </summary>
        /// <param name="courseType"></param>
        public void ToSearchCourseInCatalog(string courseType)
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("spanSearchCatalog"));
                if (courseType.Equals("ProductTypeProg"))
                {
                    _catalogDbCourse = DatabaseTools.GetProduct(Enumerations.ProductInstance.HedCoreProgram);
                }
                if (courseType.Equals("MasterCourse"))
                {
                    _catalogDbCourse = DatabaseTools.GetCourse(Enumerations.CourseType.MySpanishLabMasterCourse);
                }
                var sw = new Stopwatch();
                sw.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
                int courseTableRow = 1;
                // Purpose: To Check if the Course Name is Visible on the Page
                for (int i = 1; !WebDriver.FindElement(By.Id("spanSearchCatalog")).Text.Contains(_catalogDbCourse); i++)
                {
                    GenericHelper.WaitUntilElement(By.Id("_ctl3_UCPaging_lnkNext"));
                    WebDriver.FindElement(By.Id("_ctl3_UCPaging_lnkNext")).Click();
                    GenericHelper.WaitUntilElement((By.Id("spanSearchCatalog")));
                }
                // Purpose: To Search the Course Through Each Rows
                while (sw.Elapsed.Minutes < minutesToWait)
                {
                    string searchcourseNameRow = WebDriver.FindElement(By.XPath("//span[@id='spanSearchCatalog']/table/tbody/tr[2]/td/div/table/tbody/tr/td/table[" + courseTableRow + "]")).Text;
                    if (searchcourseNameRow.Contains(_catalogDbCourse))
                    {
                        WebDriver.FindElement(By.XPath("//span[@id='spanSearchCatalog']/table/tbody/tr[2]/td/div/table/tbody/tr/td/table[" + courseTableRow + "]/tbody/tr/td[3]/div/a/span/span")).SendKeys("");
                        WebDriver.FindElement(By.XPath("//span[@id='spanSearchCatalog']/table/tbody/tr[2]/td/div/table/tbody/tr/td/table[" + courseTableRow + "]/tbody/tr/td[3]/div/a/span/span")).Click();
                        break;
                    }
                    courseTableRow = courseTableRow + 1;
                }
                sw.Stop();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                GenericHelper.WaitUntilElement(By.CssSelector("#btnCancel > span > span"));
                WebDriver.FindElement(By.CssSelector("#btnCancel > span > span")).Click();
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.SelectWindow("Global Home");
                Assert.Fail(e.ToString());
            }
        }
    }
}
