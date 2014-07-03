using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook
{
    public partial class GBRoasterDefaultPage : BasePage
    {
        //Purpose: To select Student option in Roster Page
        public void SelectRoasterStudentOption()
        {
            GenericHelper.SelectWindow("Roster");
            WebDriver.SwitchTo().Frame("frameRoster");
            GenericHelper.WaitUntilElement(By.Id("_ctl0:InnerPageContent:btn_CreateUser"));
            WebDriver.FindElement(By.Id("_ctl0:InnerPageContent:btn_CreateUser")).Click();
            IWebElement optionStudent = WebDriver.FindElement(By.Id("trStudent"));
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("$(arguments[0]).click()", optionStudent);
        }
    }
}
