using System.Configuration;
using Framework.Core.Library;
using OpenQA.Selenium;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Create_Class
{
    public class ManageClassManagementPage : BasePage
    {
        //Purpose: To Click Add Class Menu Option Link
        public void ToselectAddClass()
        {
            GenericHelper.SelectWindow("Manage Organization");
            WebDriver.SwitchTo().Frame("frm");
            GenericHelper.WaitUntilElement(By.XPath("//IMG[@class='tdAddImg']"));
            WebDriver.FindElement(By.XPath("//IMG[@class='tdAddImg']")).Click();
        }
    }
}
