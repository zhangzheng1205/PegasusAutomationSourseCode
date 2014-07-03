using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.ProgramAdmin.CourseTemplates
{
    public class AddNewTemplatePage : BasePage
    {
        /// <summary>
        /// Purpose: To Add New Template
        /// </summary>
        public void AddNewTemplate()
        {
            GenericHelper.SelectWindow("Add New Template");
            GenericHelper.WaitUntilElement(By.Id("btnAddTemplate"));
            WebDriver.FindElement(By.Id("btnAddTemplate")).Click();
        }
    }
}
