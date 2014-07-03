using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Framework.Common;
using Framework.Core.Library;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_DataAccess;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Create_Class
{
    public class CreateNewClassPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        public static string Classname;

        // Purpose - Method To Create a Class Using Template
        public void ToCreateClass()
        {
            int tableNo = 1;
            Thread.Sleep(3000);
            WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == "Create Class");
            WebDriver.SwitchTo().Frame("iframeCreateClass");
            Classname = GenericHelper.GenerateUniqueVariable("ClassTemp");
            GenericHelper.WaitUntilElement(By.Id("clsClassInformation_txtNewClassName"));
            WebDriver.FindElement(By.Id("clsClassInformation_txtNewClassName")).SendKeys(Classname);
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.WaitUntilElement(By.Id("btnNext"));
            WebDriver.FindElement(By.Id("btnNext")).Click();
            Thread.Sleep(2000);
            WebDriver.SwitchTo().Frame("iframeCreateClass");
            GenericHelper.WaitUntilElement(By.Id("clsClassInformation_rdbChooseOrganisation"));
            if (!WebDriver.FindElement(By.Id("clsClassInformation_rdbChooseOrganisation")).Selected)
            {
                GenericHelper.Logs("Class creation option is disabled", "FAILED");
                WebDriver.Close();
                throw new Exception("Class creation option is disabled");
            }
            WebDriver.FindElement(By.Id("clsClassInformation_rdbChooseOrganisation")).Click();
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.WaitUntilElement(By.Id("btnNext"));
            WebDriver.FindElement(By.Id("btnNext")).Click();
            Thread.Sleep(2000);
            WebDriver.SwitchTo().Frame("iframeCreateClass");
            string className = WebDriver.FindElement(By.XPath("//div[@id='clsClassContentList_pnlcontrolListContentType1']/table[" + tableNo + "]")).Text.Trim();
            string templateName = DatabaseTools.GetTemplate();
            if (className == templateName)
            {
                WebDriver.FindElement(By.XPath("//div[@id='clsClassContentList_pnlcontrolListContentType1']/table[" + tableNo + "]/tbody/tr/td/input[@id='selectRadio']")).Click();
            }
            while (className != templateName)
            {
                tableNo = tableNo + 1;
                className = WebDriver.FindElement(By.XPath("//div[@id='clsClassContentList_pnlcontrolListContentType1']/table[" + tableNo + "]")).Text.Trim();
                if (className == templateName)
                {
                    WebDriver.FindElement(By.XPath("//div[@id='clsClassContentList_pnlcontrolListContentType1']/table[" + tableNo + "]/tbody/tr/td/input[@id='selectRadio']")).Click();
                }
            }
            WebDriver.SwitchTo().DefaultContent();
            WebDriver.FindElement(By.Id("btnNext")).Click();
            GenericHelper.WaitUntilElement(By.Id("btnNext"));
            WebDriver.FindElement(By.Id("btnNext")).Click();
            GenericHelper.WaitUntilElement(By.Id("btnFinish"));
            WebDriver.FindElement(By.Id("btnFinish")).Click();
            GenericHelper.IsPopUpClosed("Create Class");
            ToSearchForAssigned((Enumerations.ClassType.Template));
            DatabaseTools.UpdateClass(Enumerations.ClassType.Template, Classname);
        }

        // purpose - below function to create a class using ML
        public void ToCreateClassUsingML()
        {
            int rowNo = 1;
            Thread.Sleep(2000);
            WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == "Create Class");
            WebDriver.SwitchTo().Frame("iframeCreateClass");
            Classname = GenericHelper.GenerateUniqueVariable("ClassML");
            DatabaseTools.UpdateClass(Enumerations.ClassType.MasterLibrary, Classname);
            WebDriver.FindElement(By.Id("clsClassInformation_txtNewClassName")).SendKeys(Classname);
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.WaitUntilElement(By.Id("btnNext"));
            WebDriver.FindElement(By.Id("btnNext")).Click();
            Thread.Sleep(2000);
            WebDriver.SwitchTo().Frame("iframeCreateClass");
            GenericHelper.WaitUntilElement(By.Id("clsClassInformation_rdbChooseProduct"));
            WebDriver.FindElement(By.Id("clsClassInformation_rdbChooseProduct")).Click();
            WebDriver.SwitchTo().DefaultContent();
            WebDriver.FindElement(By.Id("btnNext")).Click();
            Thread.Sleep(2000);
            WebDriver.SwitchTo().Frame("iframeCreateClass");
            string className = WebDriver.FindElement(By.XPath("//table[@id='tblCourseList']/tbody/tr[" + rowNo + "]")).Text.Trim();
            string dbmlName = DatabaseTools.GetCourse(Enumerations.CourseType.MasterLibrary).Trim();
            if (className == dbmlName)
            {
                WebDriver.FindElement(By.XPath("//table[@id='tblCourseList']/tbody/tr[" + rowNo + "]/td/input[@id='selectcheckbox']")).Click();
            }
            while (className != dbmlName)
            {
                rowNo = rowNo + 1;
                className = WebDriver.FindElement(By.XPath("//table[@id='tblCourseList']/tbody/tr[" + rowNo + "]")).Text.Trim();
                if (className == dbmlName)
                {
                    WebDriver.FindElement(By.XPath("//table[@id='tblCourseList']/tbody/tr[" + rowNo + "]/td/input[@id='selectcheckbox']")).Click();
                }
            }
            WebDriver.SwitchTo().DefaultContent();
            WebDriver.FindElement(By.Id("btnNext")).Click();
            GenericHelper.WaitUntilElement(By.Id("btnNext"));
            WebDriver.FindElement(By.Id("btnNext")).Click();
            GenericHelper.WaitUntilElement(By.Id("btnFinish"));
            WebDriver.FindElement(By.Id("btnFinish")).Click();
            GenericHelper.IsPopUpClosed("Create Class");
            ToSearchForAssigned((Enumerations.ClassType.MasterLibrary));
            WebDriver.Close();
            GenericHelper.IsPopUpClosed("Manage Organization");
        }

        //purpose - to search for assigned to copy class
        public void ToSearchForAssigned(Enumerations.ClassType classtype)
        {
            GenericHelper.SelectWindow("Manage Organization");
            GenericHelper.WaitUntilElement(By.Id("frm"));
            WebDriver.SwitchTo().Frame("frm");
            GenericHelper.WaitUntilElement(By.Id("spnSearch"));
            WebDriver.FindElement(By.Id("spnSearch")).Click();
            WebDriver.SwitchTo().ActiveElement();
            string className = DatabaseTools.GetClass(classtype);
            GenericHelper.WaitUntilElement(By.Id("txtSectionDetail"));
            WebDriver.FindElement(By.Id("txtSectionDetail")).Clear();
            WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(className);
            WebDriver.FindElement(By.Id("SearchSections")).Click();
            Thread.Sleep(3000);
            // Purpose: Method To Verify Assigned to Copy State
            GenericHelper.SelectWindow("Manage Organization");
            WebDriver.SwitchTo().Frame("frm");
            GenericHelper.WaitUntilElement(By.Id("grdClasses$divContent"));
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
            while (sw.Elapsed.Minutes < minutesToWait)
            {
                IWebElement redTextPresent = WebDriver.FindElement(By.TagName("body"));
                if (redTextPresent.Text.Contains("[Assigned to copy]"))
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    GenericHelper.WaitUntilElement(By.Id("frm"));
                    WebDriver.SwitchTo().Frame("frm");
                    Thread.Sleep(20000);
                    GenericHelper.WaitUntilElement(By.Id("spnSearch"));
                    WebDriver.FindElement(By.Id("spnSearch")).Click();
                    Thread.Sleep(3000);
                    WebDriver.SwitchTo().ActiveElement();
                    GenericHelper.WaitUntilElement(By.Id("txtSectionDetail"));
                    WebDriver.FindElement(By.Id("txtSectionDetail")).Clear();
                    WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(className);
                    WebDriver.FindElement(By.Id("SearchSections")).Click();
                    Thread.Sleep(3000);
                    WebDriver.SwitchTo().ActiveElement();
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.SwitchTo().Frame("frm");
                    GenericHelper.WaitUntilElement(By.Id("grdClasses$divContent"));
                    #region Browser Selection
                    if (Browser.Equals("FF"))
                    {
                        if (WebDriver.FindElement(By.Id("grdClasses$divContent")).Text.Contains(className))
                        {
                            GenericHelper.Logs("Class found in the grid after searching it from the search option", "PASSED");
                        }
                        else
                        {
                            GenericHelper.Logs("Class not found in the grid after searching it from the search option", "FAILED");
                        }
                    }
                    if (Browser.Equals("IE"))
                    {
                        if (WebDriver.FindElement(By.Id("grdClasses$divContent")).GetAttribute("innerText").Contains(className))
                        {
                            GenericHelper.Logs("Class found in the grid after searching it from the search option", "PASSED");
                        }
                        else
                        {
                            GenericHelper.Logs("Class not found in the grid after searching it from the search option", "FAILED");
                        }
                    }
                    #endregion Browser Selection
                }
                else
                {
                    break;
                }
            }
            try
            {
                IWebElement redTextPresent = WebDriver.FindElement(By.TagName("body"));
                if (redTextPresent.Text.Contains("[Assigned to copy]"))
                {
                    GenericHelper.Logs(string.Format("[AssignedToCopy] state has not validated under:'{0}' minutes for copying '{1}'.", minutesToWait, className), "FAILED");
                }
                else
                {
                    GenericHelper.Logs(string.Format("[AssignedToCopy] state has validated under:'{0}' minutes for copying '{1}'.", minutesToWait, className), "PASSED");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.Message, "FAILED");
            }
            sw.Stop();
            sw = null;
        }

        // Below code is for adding the course in to the class
        public void AddCourseInClass()
        {
            GenericHelper.SelectWindow("Manage Organization");
            WebDriver.SwitchTo().Frame("frm");
            GenericHelper.WaitUntilElement(By.XPath("//table[@id='grdClasses']/descendant::img[contains(@src,'/Pegasus/images/TeachingPlan/icn_chapterSmall.gif')]"));
            IWebElement menu = WebDriver.FindElement(By.XPath("//table[@id='grdClasses']/descendant::img[contains(@src,'/Pegasus/images/TeachingPlan/icn_chapterSmall.gif')]"));
            var builder = new Actions(WebDriver);
            builder.MoveToElement(menu).Build().Perform();
            GenericHelper.WaitUntilElement(By.XPath("//table[@id='grdClasses']/descendant::img[contains(@src,'/Pegasus/images/icn_down_opt.gif')]"));
            IWebElement menu1 = WebDriver.FindElement(By.XPath("//table[@id='grdClasses']/descendant::img[contains(@src,'/Pegasus/images/icn_down_opt.gif')]"));
            builder.MoveToElement(menu1).Click().Perform();
            GenericHelper.WaitUntilElement(By.PartialLinkText("Manage Content"));
            IWebElement submenu = WebDriver.FindElement(By.PartialLinkText("Manage Content"));
            builder.MoveToElement(submenu).Click().Perform();
            WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == "Manage Content");
            WebDriver.FindElement(By.XPath("//INPUT[@name='rdrTempML']")).Click();
            WebDriver.FindElement(By.Id("btnEnterCourse")).Click();
            WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == "Overview");
            GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
            WebDriver.Close();
        }

        // Purpose: Method is for Adding the Course in to the Class
        public void EnterClassAsTeacherToUnhide()
        {
            GenericHelper.SelectWindow("Manage Organization");
            WebDriver.SwitchTo().Frame("frm");
            Actions builder = new Actions(WebDriver);
            GenericHelper.WaitUntilElement(By.XPath("//table[@id='grdClasses']/descendant::img[contains(@src,'/Pegasus/images/TeachingPlan/icn_chapterSmall.gif')]"));
            WebDriver.FindElement(By.XPath("//table[@id='grdClasses']/descendant::img[contains(@src,'/Pegasus/images/TeachingPlan/icn_chapterSmall.gif')]")).SendKeys("");
            IWebElement abc = WebDriver.FindElement(By.XPath("//table[@id='grdClasses']/descendant::img[contains(@src,'/Pegasus/images/TeachingPlan/icn_chapterSmall.gif')]"));
            abc.Click();
            Thread.Sleep(2000);
            GenericHelper.WaitUntilElement(By.XPath("//table[@id='grdClasses']/descendant::img[contains(@src,'/Pegasus/images/icn_down_opt.gif')]"));
            WebDriver.FindElement(By.XPath("//table[@id='grdClasses']/descendant::img[contains(@src,'/Pegasus/images/icn_down_opt.gif')]")).Click();
            IWebElement cmenu = WebDriver.FindElement(By.PartialLinkText("Enter Class as Teacher"));
            builder.MoveToElement(cmenu).Click().Perform();
            Thread.Sleep(5000);
            GenericHelper.SelectWindow("Overview");
            WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
            GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
        }
    }
}
