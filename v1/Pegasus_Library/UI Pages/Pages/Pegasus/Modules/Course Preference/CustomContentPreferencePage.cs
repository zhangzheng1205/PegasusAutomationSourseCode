using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference
{
    public class CustomContentPreferencePage : BasePage
    {
        // Calling of other classes
        private string _strConnection =
            ConfigurationManager.ConnectionStrings["Pegasus_SpecFlow.Properties.Settings.BDD_DBConnectionString"].
                ConnectionString;

        //To Select Custom content sub tab
        public void ToSelectCustomContentSubTab()
        {
            GenericHelper.SelectWindow("Preferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.Id("atdContnet32"));
            IWebElement selectCustomContentSubTab = WebDriver.FindElement(By.Id("atdContnet32"));
            new Actions(WebDriver).Click(selectCustomContentSubTab).Perform();
            Thread.Sleep(2000);
        }


        // Method to set the Custom content preference
        public void ToCheckCustomContent()
        {
            GenericHelper.SelectWindow("Preferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0_ContentHolderArea_chkCustomizeContent"));
            if (!WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkCustomizeContent")).Selected)
            {
                IWebElement chkCustomizeContent = WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkCustomizeContent"));
                new Actions(WebDriver).Click(chkCustomizeContent).Perform();
            }
            if (!WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_CheckCustomizeOrgContent")).Selected)
            {
                IWebElement checkCustomizeOrgContent = WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_CheckCustomizeOrgContent"));
                new Actions(WebDriver).Click(checkCustomizeOrgContent).Perform();
            }
            if (!WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_CheckCreateOwnContent")).Selected)
            {
                IWebElement checkCreateOwnContent = WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_CheckCreateOwnContent"));
                new Actions(WebDriver).Click(checkCreateOwnContent).Perform();
            }
            WebDriver.SwitchTo().DefaultContent();
            new CourseCopyPreferencesPage().ToSelectSaveButton();
            Thread.Sleep(3000);
        }
    }
}
