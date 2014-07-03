using System;
using System.Configuration;
using Framework.Common;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.Enrollment
{
    public class EnrollClassesPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        #region
        private string ImageExpand
        {
            get { return "//img[contains(@src,'/Pegasus/images/Admin/Class/plus.gif')]"; }
        }
        #endregion

        //Purpose : To select the class in Enrollment tab of Manage Organization Page
        public void SelectClass(Enumerations.ClassType classType)
        {
            try
            {
            string classname = DatabaseTools.GetClass(classType);
            GenericHelper.SelectWindow("Manage Organization");
            GenericHelper.WaitUntilElement(By.Id("frm"));
            WebDriver.SwitchTo().Frame("frm");
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.WaitUntilElement(By.Id("frm"));
            WebDriver.SwitchTo().Frame("frm");
            WebDriver.SwitchTo().Frame("ifrmright");
            GenericHelper.WaitUntilElement(By.Id("spnSearch"));
            WebDriver.FindElement(By.Id("spnSearch")).Click();
            GenericHelper.WaitUntilElement(By.Id("txtSectionDetail"));
            WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(classname);
            GenericHelper.WaitUntilElement(By.Id("btnSearch"));
            WebDriver.FindElement(By.Id("btnSearch")).Click();
            try
            {
                bool isEnrollTablePresent = GenericHelper.IsElementPresent(By.Id("MainTable"));
                if (isEnrollTablePresent)
                {
                    string noRecordMessagePresent = WebDriver.FindElement(By.Id("MainTable")).Text;
                    if (noRecordMessagePresent.Contains("There are no classes or courses available to you."))
                    {
                        GenericHelper.Logs("There are no classes or courses available to you.", "FAILED");
                        throw new NoSuchElementException("There are no classes or courses available to you.");
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
            GenericHelper.WaitUntilElement(By.XPath("//table[@class='CourseLabelHeight']/tbody/tr/td/span"));
            #region Browser Selection
            if (Browser.Equals("FF") || Browser.Equals("GC"))
            {
                if (classname.StartsWith(WebDriver.FindElement(By.XPath("//table[@class='CourseLabelHeight']/tbody/tr/td/span")).Text.TrimEnd('.')))
                {
                    GenericHelper.WaitUntilElement(By.XPath(ImageExpand));
                    WebDriver.FindElement(By.XPath(ImageExpand)).Click();
                    GenericHelper.WaitUntilElement(By.CssSelector("input[id$='allcourse']"));
                    WebDriver.FindElement(By.CssSelector("input[id$='allcourse']")).Click();
                    GenericHelper.Logs("Searched class " + classname + " found", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Searched class " + classname + " not found", "FAILED");
                }
            }
            if (Browser.Equals("IE"))
            {
                if (classname.StartsWith(WebDriver.FindElement(By.XPath("//table[@class='CourseLabelHeight']/tbody/tr/td/span")).Text.TrimEnd('.')))
                {
                    GenericHelper.WaitUntilElement(By.Id("grdEnrollmentClasses__ctl0_expandImgDiv"));
                    WebDriver.FindElement(By.Id("grdEnrollmentClasses__ctl0_expandImgDiv")).Click();
                    GenericHelper.WaitUntilElement(By.CssSelector("input[id$='allcourse']"));
                    WebDriver.FindElement(By.CssSelector("input[id$='allcourse']")).Click();
                    GenericHelper.Logs("Searched class " + classname + " found", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Searched class " + classname + " not found", "FAILED");
                }
            }
            #endregion Browser Selection
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

        //Purpose: To select the class with ClassType
        public void SelectClassWithClassType(string classType)
        {
           try 
           {
            switch (classType)
            {
                case "Template":
                    SelectClass(Enumerations.ClassType.NovaNETTemplate);
                    break;
                case "Master Library":
                    SelectClass(Enumerations.ClassType.NovaNETMasterLibrary);
                    break;
                case "Placeholder":
                    SelectClass(Enumerations.ClassType.NovaNETPlaceHolder);
                    break;
            }
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
    }
}
