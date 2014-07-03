using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Framework.Common;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.MyPegasus
{
    public class MyClassdefaultPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //Purpose: To click Create Course button in classes page
        public void ClickCreateCourse()
        {
            try
            {
                int rowcount = WebDriver.FindElements(By.XPath(Table_tblmain + "/tbody/tr")).Count;
                for (int i = 1; i <= rowcount; i++)
                {
                    string classname = null;
                    if (Browser.Equals("IE"))
                    {
                        classname = WebDriver.FindElement(By.XPath(Table_tblmain + "/tbody/tr[" + i.ToString(CultureInfo.InvariantCulture) + "]")).GetAttribute("innerText");
                    }
                    if (Browser.Equals("FF") || Browser.Equals("GC"))
                    {
                        classname = WebDriver.FindElement(By.XPath("//table[@id='tblMain']/tbody/tr[" + i + "]")).Text;
                    }
                    if (classname != null && classname.Contains(DatabaseTools.GetClass(Enumerations.ClassType.NovaNETTemplate)))
                    {
                        Thread.Sleep(2000);
                        if (Browser.Equals("FF") || Browser.Equals("IE"))
                        {
                            WebDriver.FindElement(By.XPath(Table_tblmain + "/tbody/tr[" + i.ToString(CultureInfo.InvariantCulture) + "]/td/div/table/tbody/tr/td" + Button_Createcourse)).SendKeys("");
                        }
                        WebDriver.FindElement(By.XPath(Table_tblmain + "/tbody/tr[" + i.ToString(CultureInfo.InvariantCulture) + "]/td/div/table/tbody/tr/td" + Button_Createcourse)).Click();
                        break;
                    }
                    else if (i == rowcount)
                    {
                        GenericHelper.Logs("Create course button not found for the corresponding class", "FAILED");
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Declare Locator Property
        private string Table_tblmain
        {
            get
            {
                return "//table[@id='tblMain']";
            }
        }

        //Purpose: To Declare Locator Property
        private string Button_Createcourse
        {
            get
            {
                return "//div[contains(@onclick,'Createcourse(this);')]";
            }
        }
    }
}
