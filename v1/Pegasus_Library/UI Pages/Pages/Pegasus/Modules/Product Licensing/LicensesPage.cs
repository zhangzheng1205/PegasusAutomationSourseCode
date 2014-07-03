using System;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Framework.Common;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference
{
    public class LicensesPage : BasePage
    {
        //Purpose: Method to Select Licenses Tab
        public void CreateLicenses(string productInstance)
        {
            try
            {
                GenericHelper.SelectWindow("Manage Organization");
                WebDriver.FindElement(By.Id("frm"));
                WebDriver.SwitchTo().Frame("frm");
                GenericHelper.WaitUntilElement(By.Id("lblAddproducts"));
                WebDriver.FindElement(By.Id("lblAddproducts")).Click();
                switch (productInstance)
                {
                    case "NovaNET":
                        new ProductDefaultPage().SelectProduct(Enumerations.ProductInstance.NovaNET);
                        break;
                    case "DigitalPath":
                        new ProductDefaultPage().SelectProduct(Enumerations.ProductInstance.DigitalPath);
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
