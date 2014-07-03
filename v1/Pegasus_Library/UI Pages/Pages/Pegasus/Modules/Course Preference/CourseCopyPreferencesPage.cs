using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference
{
    public class CourseCopyPreferencesPage : BasePage
    {
        // To Select copy content sub tab
        public void ToSelectCopyContentSubtab()
        {
            GenericHelper.SelectWindow("Preferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.Id("atdContnet22"));
            IWebElement contentsubTab = WebDriver.FindElement(By.Id("atdContnet22"));
            new Actions(WebDriver).Click(contentsubTab).Perform();
        }

        // Method to check the DCF checkbox
        public void ToCheckDcfCheckbox()
        {
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.SelectWindow("Preferences");
            WebDriver.SwitchTo().ActiveElement();
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0_ContentHolderArea_chkCoursesAsFolders"));
            if (!WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkCoursesAsFolders")).Selected)
            {
                IWebElement checkDCFCheckbox = WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkCoursesAsFolders"));
                new Actions(WebDriver).Click(checkDCFCheckbox).Perform();
            }
            WebDriver.SwitchTo().DefaultContent();
        }

        public void ToSelectSaveButton()
        {
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.ClassName("btn_syn_s"));
            IWebElement selectSaveButton = WebDriver.FindElement(By.ClassName("btn_syn_s"));
            new Actions(WebDriver).Click(selectSaveButton).Perform();
            GenericHelper.SelectDefaultWindow();
        }
    }
}
