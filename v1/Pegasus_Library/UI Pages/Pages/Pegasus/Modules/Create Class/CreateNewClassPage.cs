using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Create_Class
{
    public class CreateNewClassPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        public static string Classname;

        //Purpose: locator property defined
        private string Text_AssignedToCopy
        {
            get { return "//font[@class='reqCharRed']"; }
        }

        // Purpose - Method To Create a Class Using Template
        public void ToCreateClass()
        {
            try
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
                WebDriver.SwitchTo().Frame("iframeCreateClass");
                GenericHelper.WaitUntilElement(By.Id("clsClassInformation_rdbChooseOrganisation"));
                if (!WebDriver.FindElement(By.Id("clsClassInformation_rdbChooseOrganisation")).Selected)
                {
                    GenericHelper.Logs("Class creation option by using template is disabled", "FAILED");
                    throw new Exception("Class creation option by using template is disabled");
                }
                WebDriver.FindElement(By.Id("clsClassInformation_rdbChooseOrganisation")).Click();
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.WaitUntilElement(By.Id("btnNext"));
                WebDriver.FindElement(By.Id("btnNext")).Click();
                WebDriver.SwitchTo().Frame("iframeCreateClass");
                string className = WebDriver.FindElement(By.XPath("//div[@id='clsClassContentList_pnlcontrolListContentType1']/table[" + tableNo + "]")).Text.Trim();
                string templateName = DatabaseTools.GetTemplate();
                if (templateName == null) throw new ArgumentNullException(string.Format("Template Name {0} is null", null));
                if (className == templateName)
                {
                    GenericHelper.WaitUntilElement(By.XPath("//div[@id='clsClassContentList_pnlcontrolListContentType1']/table[" + tableNo + "]/tbody/tr/td/input[@id='selectRadio']"));
                    WebDriver.FindElement(By.XPath("//div[@id='clsClassContentList_pnlcontrolListContentType1']/table[" + tableNo + "]/tbody/tr/td/input[@id='selectRadio']")).Click();
                }
                while (className != templateName)
                {
                    tableNo = tableNo + 1;
                    className = WebDriver.FindElement(By.XPath("//div[@id='clsClassContentList_pnlcontrolListContentType1']/table[" + tableNo + "]")).Text.Trim();
                    if (className == templateName)
                    {
                        GenericHelper.WaitUntilElement(By.XPath("//div[@id='clsClassContentList_pnlcontrolListContentType1']/table[" + tableNo + "]/tbody/tr/td/input[@id='selectRadio']"));
                        WebDriver.FindElement(By.XPath("//div[@id='clsClassContentList_pnlcontrolListContentType1']/table[" + tableNo + "]/tbody/tr/td/input[@id='selectRadio']")).Click();
                    }
                }
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.WaitUntilElement(By.Id("btnNext"));
                WebDriver.FindElement(By.Id("btnNext")).Click();
                bool isThinkingIndicator = GenericHelper.ThinkingIndicatorProcessing();
                if (isThinkingIndicator)
                {
                    GenericHelper.Logs("Thinking indicator has stopped loading", "Passed");
                }
                else
                {
                    GenericHelper.Logs("Thinking indicator is still showing on the screen", "Failed");
                    throw new Exception("Thinking indicator is still showing on the screen");
                }
                Thread.Sleep(10000); // This Thread I have added to avoid HTTP connection break! 
                GenericHelper.WaitUntilElement(By.Id("btnNext"));
                WebDriver.FindElement(By.Id("btnNext")).Click();
                GenericHelper.WaitUntilElement(By.Id("btnFinish"));
                WebDriver.FindElement(By.Id("btnFinish")).Click();
                DatabaseTools.UpdateClass(Enumerations.ClassType.NovaNETTemplate, Classname);
                //Purpose: Verifying Create Class Window Closed Successfully 
                bool isCreateClassWindowClosed = GenericHelper.IsPopUpClosed(3);
                if (isCreateClassWindowClosed)
                {
                    GenericHelper.Logs("Create Class' window has been closed successfully.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Create Class' window has not been closed successfully.", "FAILED");
                    throw new Exception("Create Class' window has not been closed successfully.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isCreateClassWindowPresent = GenericHelper.IsPopUpWindowPresent("Create Class");
                if (isCreateClassWindowPresent)
                {
                    GenericHelper.SelectWindow("Create Class");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        // Purpose: Create a Class Using ML
        public void ToCreateClassUsingML()
        {
            try
            {
                int rowNo = 1;
                WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == "Create Class");
                WebDriver.SwitchTo().Frame("iframeCreateClass");
                Classname = GenericHelper.GenerateUniqueVariable("ClassML");
                DatabaseTools.UpdateClass(Enumerations.ClassType.NovaNETMasterLibrary, Classname);
                WebDriver.FindElement(By.Id("clsClassInformation_txtNewClassName")).SendKeys(Classname);
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.WaitUntilElement(By.Id("btnNext"));
                WebDriver.FindElement(By.Id("btnNext")).Click();
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
                GenericHelper.IsPopUpClosed(3);
                ToSearchForAssigned((Enumerations.ClassType.NovaNETMasterLibrary));
                WebDriver.Close();
                GenericHelper.IsPopUpClosed(2);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isCreateClassWindowPresent = GenericHelper.IsPopUpWindowPresent("Create Class");
                if (isCreateClassWindowPresent)
                {
                    GenericHelper.SelectWindow("Create Class");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        //purpose - to search for assigned to copy class
        public void ToSearchForAssigned(Enumerations.ClassType classtype)
        {
            try
            {
                GenericHelper.SelectWindow("Manage Organization");
                WebDriver.SwitchTo().Frame("frm");
                GenericHelper.WaitUntilElement(By.Id("spnSearch"));
                WebDriver.FindElement(By.Id("spnSearch")).Click();
                string className = DatabaseTools.GetClass(classtype);
                GenericHelper.WaitUntilElement(By.Id("txtSectionDetail"));
                WebDriver.FindElement(By.Id("txtSectionDetail")).Clear();
                WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(className);
                GenericHelper.WaitUntilElement(By.Id("SearchSections"));
                IWebElement searchSection = WebDriver.FindElement(By.Id("SearchSections"));
                new Actions(WebDriver).Click(searchSection).Perform();
                // Purpose: Method To Verify Assigned to Copy State
                GenericHelper.SelectWindow("Manage Organization");
                WebDriver.SwitchTo().Frame("frm");
                GenericHelper.WaitUntilElement(By.Id("grdClasses$divContent"));
                #region Browser Selection
                if (Browser.Equals("FF") || Browser.Equals("GC"))
                {
                    if (WebDriver.FindElement(By.Id("grdClasses$divContent")).Text.Contains(className))
                    {
                        GenericHelper.Logs(string.Format("Class '{0}' found in the grid after searching it from the search option.", className), "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs(string.Format("Class '{0}' not found in the grid after searching it from the search option.", className), "FAILED");
                        throw new NoSuchElementException(string.Format("Class '{0}' not found in the grid after searching it from the search option.", className));
                    }
                }
                if (Browser.Equals("IE"))
                {
                    if (WebDriver.FindElement(By.Id("grdClasses$divContent")).GetAttribute("innerText").Contains(className))
                    {
                        GenericHelper.Logs(string.Format("Class '{0}' found in the grid after searching it from the search option.", className), "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs(string.Format("Class '{0}' not found in the grid after searching it from the search option.", className), "FAILED");
                        throw new NoSuchElementException(string.Format("Class '{0}' not found in the grid after searching it from the search option.", className));
                    }
                }
                #endregion Browser Selection
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
                while (sw.Elapsed.Minutes < minutesToWait)
                {
                    IWebElement redTextPresent = WebDriver.FindElement(By.TagName("body"));
                    if (redTextPresent.Text.Contains("[Assigned to copy]") == false) break;
                    {
                        GenericHelper.SelectWindow("Manage Organization");
                        WebDriver.SwitchTo().Frame("frm");
                        GenericHelper.WaitUntilElement(By.Id("spnSearch"));
                        WebDriver.FindElement(By.Id("spnSearch")).Click();
                        Thread.Sleep(5000);// This I added to load the search panel
                        GenericHelper.WaitUntilElement(By.Id("txtSectionDetail"));
                        WebDriver.FindElement(By.Id("txtSectionDetail")).Clear();
                        WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(className);
                        GenericHelper.WaitUntilElement(By.Id("SearchSections"));
                        IWebElement searchClass = WebDriver.FindElement(By.Id("SearchSections"));
                        new Actions(WebDriver).Click(searchClass).Perform();
                        Thread.Sleep(10000);
                        GenericHelper.SelectWindow("Manage Organization");
                        WebDriver.SwitchTo().Frame("frm");
                    }
                }
                if (GenericHelper.IsElementPresent(By.XPath(Text_AssignedToCopy)))
                {
                    GenericHelper.Logs(string.Format("[AssignedToCopy] state has not validated under:'{0}' minutes for copying '{1}'.", minutesToWait, className), "FAILED");
                }
                else
                {
                    GenericHelper.Logs(string.Format("[AssignedToCopy] state has validated under:'{0}' minutes for copying '{1}'.", minutesToWait, className), "PASSED");
                }
                sw.Stop();
                sw = null;
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Manage Organization"))
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        // Below code is for adding the course in to the class
        public void AddCourseInClass()
        {
            try
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
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Manage Content"))
                {
                    GenericHelper.SelectWindow("Manage Content");
                    WebDriver.Close();
                }
                if (GenericHelper.IsPopUpWindowPresent("Overview"))
                {
                    GenericHelper.SelectWindow("Overview");
                    WebDriver.Close();
                }
                if (GenericHelper.IsPopUpWindowPresent("Manage Organization"))
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        // Purpose: Method is for Adding the Course in to the Class
        public void EnterClassAsTeacherToUnhide()
        {
            try
            {
                GenericHelper.SelectWindow("Manage Organization");
                WebDriver.SwitchTo().Frame("frm");
                GenericHelper.WaitUntilElement(By.XPath("//table[@id='grdClasses']/descendant::img[contains(@src,'/Pegasus/images/TeachingPlan/icn_chapterSmall.gif')]"));
                IWebElement menu = WebDriver.FindElement(By.XPath("//table[@id='grdClasses']/descendant::img[contains(@src,'/Pegasus/images/TeachingPlan/icn_chapterSmall.gif')]"));
                Actions builder = new Actions(WebDriver);
                builder.MoveToElement(menu).Build().Perform();
                IWebElement menu1 = WebDriver.FindElement(By.XPath("//table[@id='grdClasses']/descendant::img[contains(@src,'/Pegasus/images/icn_down_opt.gif')]"));
                builder.MoveToElement(menu1).Click().Perform();
                IWebElement submenu = WebDriver.FindElement(By.PartialLinkText("Enter Class as Teacher"));
                builder.MoveToElement(submenu).Click().Perform();
                Thread.Sleep(30000);
                GenericHelper.SelectWindow("Overview");
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:_ctl0:Backbutton"));
                bool isContentPageLoaded = GenericHelper.IsElementPresent(By.Id("_ctl0:_ctl0:phHeader:_ctl0:Backbutton"));
                if (isContentPageLoaded)
                {
                    GenericHelper.Logs("User has been successfully entered the class as teacher", "Passed");
                }
                else
                {
                    GenericHelper.Logs("User has not been successfully entered the class as teacher", "Failed");
                    throw new ElementNotVisibleException("User has not been successfully entered the class as teacher");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Overview"))
                {
                    GenericHelper.SelectWindow("Overview");
                    WebDriver.Close();
                }
                if (GenericHelper.IsPopUpWindowPresent("Manage Organization"))
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }
    }
}
