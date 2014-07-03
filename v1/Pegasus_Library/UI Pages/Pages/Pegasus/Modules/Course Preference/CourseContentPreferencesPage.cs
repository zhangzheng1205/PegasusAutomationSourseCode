using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference
{
    public class CourseContentPreferencePage : BasePage
    {
        // Calling of other classes

        private string _strConnection =
            ConfigurationManager.ConnectionStrings["Pegasus_SpecFlow.Properties.Settings.BDD_DBConnectionString"].
                ConnectionString;


        // To Select Content subtab
        public void ToSelectContentSubTab()
        {
            GenericHelper.SelectWindow("Preferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.Id("atdContnet2"));
            IWebElement toSelectContentSubTab = WebDriver.FindElement(By.Id("atdContnet2"));
            new Actions(WebDriver).Click(toSelectContentSubTab).Perform();
            Thread.Sleep(2000);
        }

        // Method to set my Content preference
        public void ToSetContentPref()
        {
            GenericHelper.SelectWindow("Preferences");
            WebDriver.SwitchTo().ActiveElement();
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0_ContentHolderArea_chkAssign"));
            if (!WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkAssign")).Selected)
            {
                IWebElement chkAssign = WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkAssign"));
                new Actions(WebDriver).Click(chkAssign).Perform();
            }
            if (!WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkHideCourse")).Selected)
            {
                IWebElement chkHideCourse = WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkHideCourse"));
                new Actions(WebDriver).Click(chkHideCourse).Perform();
            }
            if (!WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkStuGroups")).Selected)
            {
                IWebElement chkStuGroups = WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkStuGroups"));
                new Actions(WebDriver).Click(chkStuGroups).Perform();
            }
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            IWebElement ifrmPreferences = WebDriver.FindElement(By.Id("_ctl0_ContentHolderHeader_lbtnSavePrefHeader"));
            new Actions(WebDriver).Click(ifrmPreferences).Perform();
        }
    }
}
