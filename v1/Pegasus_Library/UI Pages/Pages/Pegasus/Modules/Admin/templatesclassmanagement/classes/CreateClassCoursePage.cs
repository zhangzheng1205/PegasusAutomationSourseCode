using System;
using System.Configuration;
using System.Globalization;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Framework.Common;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.templatesclassmanagement.classes
{
    public class CreateClassCoursePage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //Purpose: To Create Course using ML
        public void CreateCourseUsingML()
        {
            try
            {
                GenericHelper.SelectWindow("Create Course");
                bool isNoCousefoundPresent = GenericHelper.IsElementPresent(By.Id("_ctl0_lblNoCousefound"));
                if (isNoCousefoundPresent)
                {
                    GenericHelper.Logs("There are no items present to create course.", "FAILED");
                    throw new NoSuchElementException("There are no items present to create course.");
                }
                else
                {
                    GenericHelper.Logs("Course has been present to create course by CS Teacher.", "PASSED");
                }
                int producttablecount = WebDriver.FindElements(By.Id("tblCourseList")).Count;
                string productname = null;
                for (int i = 1; i <= producttablecount; i++)
                {
                    if (Browser.Equals("IE"))
                    {
                        productname = WebDriver.FindElement(By.XPath(div_productType + "/TABLE[" + producttablecount.ToString(CultureInfo.InvariantCulture) + "]")).GetAttribute("innerText");
                    }
                    if (Browser.Equals("FF") || Browser.Equals("GC"))
                    {
                        productname = WebDriver.FindElement(By.XPath(div_productType + "/TABLE[" + producttablecount.ToString(CultureInfo.InvariantCulture) + "]")).Text;
                    }
                    string getProductName = DatabaseTools.GetProduct(Enumerations.ProductInstance.NovaNET);
                    if (productname != null && getProductName.Contains(getProductName))
                    {
                        int courseCount = WebDriver.FindElements(By.XPath(div_productType + "/TABLE[" + producttablecount.ToString(CultureInfo.InvariantCulture) + "]/tbody/tr[2]/td/table/tbody/tr/td/div" + Table_CourseList)).Count;
                        WebDriver.FindElement(By.XPath(CheckboxCourse(i.ToString(CultureInfo.InvariantCulture), courseCount.ToString(CultureInfo.InvariantCulture)))).Click();
                        GenericHelper.WaitUntilElement(By.Id("btnFinish"));
                        WebDriver.FindElement(By.Id("btnFinish")).Click();
                        bool isCreateCoursePopUpClosed = GenericHelper.IsPopUpClosed(2);
                        if (isCreateCoursePopUpClosed)
                        {
                            GenericHelper.Logs("'Create Course' pop-up window closed successfuly.", "PASSED");
                        }
                        else
                        {
                            GenericHelper.Logs("'Create Course' pop-up window not closed successfuly.", "FAILED");
                            throw new SystemException("'Create Course' pop-up window not closed successfuly.");
                        }
                        break;
                    }
                    else if (i == producttablecount)
                    {
                        GenericHelper.Logs("Create course pop up does not contains required product and course hence unable to select the course.", "FAILED");
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                WebDriver.Close();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Define The Locator Property
        private string CheckboxCourse(string tablecnt, string rowcnt)
        {
            {
                return (div_productType + "/TABLE[" + tablecnt.ToString(CultureInfo.InvariantCulture) + "]/tbody/tr[2]/td/table/tbody/tr/td/div" + Table_CourseList + "/tbody/tr[" + rowcnt.ToString() + "]/td/input[@id='selectcheckbox']");
            }
        }

        //Purpose: To Define The Locator Property
        private string div_productType
        {
            get { return "//div[@id='_ctl0_pnlcontrolListNovaNetProductType']"; }
        }

        //Purpose: To Define The Locator Property
        private string Table_CourseList
        {
            get
            {
                return "//TABLE[@id='tblCourseList']";
            }
        }
    }
}
