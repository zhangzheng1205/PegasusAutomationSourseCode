using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.ProgramAdmin
{
    public class ProgramAdminToolPage : BasePage
    {
        /// <summary>
        /// Purpose: To Select Program Admin Tab
        /// </summary>
        /// <param name="tabName"></param>
        public void SelectProgramAdminTab(string tabName)
        {
            GenericHelper.SelectWindow("Program Administration");
            GenericHelper.WaitUntilElement(By.PartialLinkText(tabName));
            WebDriver.FindElement(By.PartialLinkText(tabName)).Click();
        }
    }
}
