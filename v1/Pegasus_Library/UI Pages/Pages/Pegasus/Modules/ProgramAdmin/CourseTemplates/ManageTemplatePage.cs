using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.ProgramAdmin.Sections;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.ProgramAdmin.CourseTemplates
{
    public class ManageTemplatePage : BasePage
    {
        /// <summary>
        /// To Fetch Associated Master Course Name From DataBase
        /// </summary>
        readonly string _masterCourse = DatabaseTools.GetCourse(Enumerations.CourseType.MySpanishLabMasterCourse);

        /// <summary>
        /// Purpose: To Create Template
        /// </summary>
        public void ToCreateTemplate()
        {
            GenericHelper.SelectWindow("Program Administration");
            WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
            GenericHelper.WaitUntilElement(By.Id("grdTemplateSection$divContent"));
            IWebElement masterCourse = WebDriver.FindElement(By.Id("grdTemplateSection$divContent"));
            if (masterCourse == null) throw new ArgumentNullException("templat" + "eCourse is null");
            if (masterCourse.Text.Contains(_masterCourse))
            {
                GenericHelper.Logs("Associated Master Course has present in the Template Tab.", "PASSED");
            }
            else
            {
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.SelectWindow("Program Administration");
                WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                GenericHelper.WaitUntilElement(By.XPath("//IMG[@class='CursorHand']"));
                WebDriver.FindElement(By.XPath("//IMG[@class='CursorHand']")).Click();
                new AddNewTemplatePage().AddNewTemplate();
                GenericHelper.SelectWindow("Program Administration");
                WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                GenericHelper.WaitUntilElement(By.Id("grdTemplateSection$divContent"));
                IWebElement masterCourseTemplate = WebDriver.FindElement(By.Id("grdTemplateSection$divContent"));
                if (masterCourseTemplate.Text.Contains(_masterCourse))
                {
                    GenericHelper.Logs("Template created sucessfully in the Template Tab.", "PASSED");
                }
            }
            bool isTemplateInActiveState = ToVerifyTemplateInactiveState();
            if (isTemplateInActiveState)
            {
                GenericHelper.Logs("Template active state validated successfully in prescribed interval of time.", "PASSED");
            }
            else
            {
                GenericHelper.Logs("Template active state not validated successfully in prescribed interval of time.", "FAILED");
                Assert.Fail("Template active state validated successfully in prescribed interval of time.");
            }
        }

        /// <summary>
        /// Purpose: To Search Template
        /// </summary>
        public void ToSearchTemplate()
        {
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.SelectWindow("Program Administration");
            WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
            GenericHelper.WaitUntilElement(By.PartialLinkText("Search"));
            WebDriver.FindElement(By.PartialLinkText("Search")).Click();
            WebDriver.SwitchTo().ActiveElement();
            GenericHelper.WaitUntilElement(By.Id("ddSearchCondition"));
            new SelectElement(WebDriver.FindElement(By.Id("ddSearchCondition"))).SelectByText("Contains");
            GenericHelper.WaitUntilElement(By.Id("txtSectionDetail"));
            WebDriver.FindElement(By.Id("txtSectionDetail")).Clear();
            WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(_masterCourse);
            GenericHelper.WaitUntilElement(By.Id("lnkbuttonsearch"));
            WebDriver.FindElement(By.Id("lnkbuttonsearch")).Click();
        }

        /// <summary>
        /// Purpose: To Verify Template Inactive State and Validate
        /// </summary>
        public bool ToVerifyTemplateInactiveState()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
            while (stopwatch.Elapsed.TotalMinutes < minutesToWait)
            {
                IWebElement assignedToCopyText = WebDriver.FindElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table"));
                if (assignedToCopyText.Text.Contains("[Request is Processing") == false) break;
                {
                    ToSearchTemplate();
                    Thread.Sleep(15000);
                }
            }
            return true;
        }

        /// <summary>
        /// Purpose: To Click Add Section Link
        ///  </summary>
        public void ToClickAddSectionsLink()
        {
            GenericHelper.SelectWindow("Program Administration");
            WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
            GenericHelper.WaitUntilElement(By.XPath("//IMG[@class='CursorHand']"));
            WebDriver.FindElement(By.XPath("//IMG[@class='CursorHand']")).Click();
        }

        /// <summary>
        /// Purpose: Get Section ID
        /// </summary>
        /// <returns></returns>
        public void GetSectionID()
        {
            string sectionName = new AddNewSectionPage().AddNewSection();
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.SelectWindow("Program Administration");
            bool isSuccessMesageDisplayed = GenericHelper.VerifySuccesfullMessage("Section added successfully.");
            if (isSuccessMesageDisplayed)
            {
                GenericHelper.Logs("Section added successful message displayed.", "PASSED");
                DatabaseTools.UpdateSectionName(sectionName);
            }
            else
            {
                GenericHelper.Logs("Section added successful message not displayed.", "FAILED");
                Assert.Fail("Section added successful message displayed.");
            }
            WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
            GenericHelper.WaitUntilElement(By.Id("grdTemplateSection"));
            string getSectionID = WebDriver.FindElement(By.XPath("//table[@id = 'grdTemplateSection']/tbody/tr/td[6]")).Text;
            if (getSectionID == null) throw new ArgumentNullException("getSectio" + "nID id null");
            WebDriver.SwitchTo().DefaultContent();
            string sectionCourse = DatabaseTools.GetCourse(Enumerations.CourseType.ProgramCourse);
            DatabaseTools.UpdateEnrolCourseID(sectionCourse, getSectionID);
        }

        /// <summary>
        ///  Purpose: To Verify Inactive State of Program Section
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public bool ToVerifySectionInactiveState(string sectionName)
        {
            WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
            GenericHelper.WaitUntilElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody/tr/td[2]"));
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
            while (stopWatch.Elapsed.TotalMinutes < minutesToWait)
            {
                IWebElement assignedToCopyText = WebDriver.FindElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody"));
                if (assignedToCopyText.Text.Contains("[Request is Processing") == false) break;
                {
                    ToSearchSection(sectionName);
                    Thread.Sleep(15000);
                }
            }
            stopWatch.Stop();
            stopWatch = null;
            return true;
        }

        /// <summary>
        ///  Purpose: To Search Section
        /// </summary>
        /// <param name="sectionName"></param>
        public void ToSearchSection(string sectionName)
        {
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.SelectWindow("Program Administration");
            WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
            GenericHelper.WaitUntilElement(By.PartialLinkText("Search"));
            WebDriver.FindElement(By.PartialLinkText("Search")).Click();
            WebDriver.SwitchTo().ActiveElement();
            GenericHelper.WaitUntilElement(By.Id("txtSectionDetail"));
            WebDriver.FindElement(By.Id("txtSectionDetail")).Clear();
            WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(sectionName);
            GenericHelper.WaitUntilElement(By.Id("lnkbuttonsearch"));
            WebDriver.FindElement(By.Id("lnkbuttonsearch")).Click();
        }

        /// <summary>
        /// This method is to select the section to navigate inside it
        /// </summary>
        /// <param name="sectionName">This is the section name</param>
        public void SelectSectionAfterSearch()
        {
            GenericHelper.WaitUntilElement(By.XPath("//div[@id='grdTemplateSection$divContent']/descendant::th[@class='thCourseInQ']/span"));
            IWebElement templateClick = WebDriver.FindElement(By.XPath("//div[@id='grdTemplateSection$divContent']/descendant::th[@class='thCourseInQ']/span"));
            templateClick.Click();
            GenericHelper.WaitUtilWindow("Calendar");
        }

        //To search for assigned template in HED program admin
        public void ToSearchForAssignedHedProgramAdmin()
        {
            try
            {
                GenericHelper.ToVerifyTemplateInactiveState();
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody/tr/td[2]"));
                IWebElement redTextPresent = WebDriver.FindElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody/tr/td[2]"));
                if (redTextPresent.Text.Contains("[Request is Processing"))
                {
                    GenericHelper.Logs(string.Format("[Request is Processing] state has not validated  for copying template."), "FAILED");
                    WebDriver.Close();
                    Assert.Fail(string.Format("[Request is Processing state has not validated  for copying  template."));
                }
                else
                {
                    GenericHelper.WaitUntilElement(By.XPath("//div[@id='grdTemplateSection$divContent']/descendant::th[@class='thCourseInQ']/span"));
                    IWebElement templateClick = WebDriver.FindElement(By.XPath("//div[@id='grdTemplateSection$divContent']/descendant::th[@class='thCourseInQ']/span"));
                    templateClick.Click();
                    GenericHelper.WaitUtilWindow("Calendar");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //To search for assigned template in HED program admin
        public void ToCreateSections()
        {
            try
            {
                GenericHelper.SelectWindow("Program Administration");
                WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                GenericHelper.WaitUntilElement(By.XPath("//IMG[@class='CursorHand']"));
                WebDriver.FindElement(By.XPath("//IMG[@class='CursorHand']")).Click();
                GenericHelper.SelectWindow("Create New Section");
                GenericHelper.WaitUntilElement(By.Id("txtCourseName"));
                string sectionName = GenericHelper.GenerateUniqueVariable("Section");
                WebDriver.FindElement(By.Id("txtCourseName")).SendKeys(sectionName);
                GenericHelper.WaitUntilElement(By.Id("templatelist"));
                new SelectElement(WebDriver.FindElement(By.Id("templatelist"))).SelectByIndex(1);
                GenericHelper.WaitUntilElement(By.Id("noslist"));
                WebDriver.FindElement(By.Id("noslist")).SendKeys("1");
                string startDate = DateTime.Now.ToString("MM/dd/yyyy");
                string endDate = DateTime.Now.AddDays(90).ToString("MM/dd/yyyy");
                GenericHelper.WaitUntilElement(By.Id("txtStartDate"));
                WebDriver.FindElement(By.Id("txtStartDate")).SendKeys(startDate);
                GenericHelper.WaitUntilElement(By.Id("txtEndDate"));
                WebDriver.FindElement(By.Id("txtEndDate")).SendKeys(endDate);
                GenericHelper.WaitUntilElement(By.Id("btnAddClose"));
                WebDriver.FindElement(By.Id("btnAddClose")).Click();
                GenericHelper.SelectWindow("Program Administration");
                GenericHelper.VerifySuccesfullMessage("Section added successfully.");
                WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody/tr/td[2]"));
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
                while (sw.Elapsed.Minutes < minutesToWait)
                {
                    IWebElement assignedToCopyText = WebDriver.FindElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody"));
                    if (assignedToCopyText.Text.Contains("[Request is Processing") == false) break;
                    {
                        WebDriver.SwitchTo().DefaultContent();
                        GenericHelper.SelectWindow("Program Administration");
                        WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                        Thread.Sleep(6000);
                        GenericHelper.WaitUntilElement(By.PartialLinkText("Search"));
                        WebDriver.FindElement(By.PartialLinkText("Search")).Click();
                        WebDriver.SwitchTo().ActiveElement();
                        GenericHelper.WaitUntilElement(By.Id("txtSectionDetail"));
                        WebDriver.FindElement(By.Id("txtSectionDetail")).Clear();
                        WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(sectionName);
                        GenericHelper.WaitUntilElement(By.Id("lnkbuttonsearch"));
                        WebDriver.FindElement(By.Id("lnkbuttonsearch")).Click();
                        Thread.Sleep(8000);
                        WebDriver.SwitchTo().DefaultContent();
                        GenericHelper.SelectWindow("Program Administration");
                        GenericHelper.WaitUntilElement(By.Id("_ctl0_PageContent_ifrmMiddle"));
                        WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                        GenericHelper.WaitUntilElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody/tr/td[2]"));
                    }
                }
                sw.Stop();
                sw = null;
                IWebElement redTextPresent = WebDriver.FindElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody/tr/td[2]"));
                if (redTextPresent.Text.Contains("[Request is Processing"))
                {
                    GenericHelper.Logs(string.Format("[Request is Processing state has not validated under:'{0}' minutes for copying section", minutesToWait), "FAILED");
                    WebDriver.Close();
                    Assert.Fail(string.Format("[Request is Processing state has not validated under:'{0}' minutes for copying section", minutesToWait));
                }
                else
                {
                    GenericHelper.Logs(string.Format("[Request is Processing state has validated under:'{0}' minutes for copying section.", minutesToWait), "PASSED");
                    DatabaseTools.UpdateSectionName(sectionName);
                    GenericHelper.WaitUntilElement(By.XPath("//div[@id='grdTemplateSection$divContent']/descendant::th[@class='thCourseInQ']/span"));
                    
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

    }
}
