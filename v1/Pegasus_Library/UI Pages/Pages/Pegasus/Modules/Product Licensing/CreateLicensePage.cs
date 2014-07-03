using System;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference
{
    public class CreateLicensePage : BasePage
    {
        //Purpose: Method To Create product License
        public void EnterLicenseDetail()
        {
            try
            {
                GenericHelper.SelectWindow("Create License");
                string startDate = DateTime.Now.ToString("MM/dd/yyyy");
                string endDate = DateTime.Now.AddDays(90).ToString("MM/dd/yyyy");
                GenericHelper.WaitUntilElement(By.Id("txtfromdate"));
                WebDriver.FindElement(By.Id("txtfromdate")).SendKeys(startDate);
                GenericHelper.WaitUntilElement(By.Id("txttodate"));
                WebDriver.FindElement(By.Id("txttodate")).SendKeys(endDate);
                GenericHelper.WaitUntilElement(By.Id("txtquntity"));
                WebDriver.FindElement(By.Id("txtquntity")).SendKeys("100");
                GenericHelper.WaitUntilElement(By.Id("ImgSaveclose"));
                WebDriver.FindElement(By.Id("ImgSaveclose")).Click();
                bool isCreateLicenseWindowClosed = GenericHelper.IsPopUpClosed(3);
                if (isCreateLicenseWindowClosed)
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    GenericHelper.Logs("Product License pop-up window has been closed successfully and license has been created successfully.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Product License pop-up window has not been closed successfully and license has not been created successfully.", "FAILED");
                    throw new Exception("Product License pop-up window has not been closed successfully and license has not been created successfully.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isWindowPresentProductSelection = GenericHelper.IsPopUpWindowPresent("Create License");
                if (isWindowPresentProductSelection)
                {
                    GenericHelper.SelectWindow("Create License");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }
    }
}
