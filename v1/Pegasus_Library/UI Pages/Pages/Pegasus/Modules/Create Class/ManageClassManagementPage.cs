using System;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Create_Class
{
    public class ManageClassManagementPage : BasePage
    {
        //Purpose: To Click Add Class Menu Option Link
        public void ToselectAddClass()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("frm"));
                WebDriver.SwitchTo().Frame("frm");
                GenericHelper.WaitUntilElement(By.XPath("//IMG[@class='tdAddImg']"));
                WebDriver.FindElement(By.XPath("//IMG[@class='tdAddImg']")).Click();
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
