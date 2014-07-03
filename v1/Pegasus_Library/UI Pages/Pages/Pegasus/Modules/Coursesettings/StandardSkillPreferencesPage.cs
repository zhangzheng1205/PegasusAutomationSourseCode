using System;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using System.Linq;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Coursesettings
{
    public class StandardSkillPreferencesPage: BasePage
    {
        //Purpose: To Add New Skill FrameWork
        public void AddNewSkillFrameWork()
        {
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");

            //Purpose: To Select Skills and Standards Radio Button
            if (!WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_rdrStandards")).Selected)
            {
                GenericHelper.WaitUntilElement(By.Id("_ctl0_ContentHolderArea_rdrStandards"));
                WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_rdrStandards")).Click();
                Thread.Sleep(4000);
            }
            WebDriver.SwitchTo().Frame("_ctl0_ContentHolderArea_frmSkillFrameworks");
            // Purpose: To Add New Framework
            GenericHelper.WaitUntilElement(By.Id("img3"));
            WebDriver.FindElement(By.Id("img3")).Click();
            Thread.Sleep(3000);
            GenericHelper.SelectWindow("Skill Framework");
            GenericHelper.WaitUntilElement(By.Id("grdFramework$_ctrl1"));
            WebDriver.FindElement(By.Id("grdFramework$_ctrl1")).Click();
            WebDriver.FindElement(By.Id("btnSaveClose")).Click();
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
          //  GenericHelper.IsPopUpClosed("Skill Framework");
            
        }

        //Purpose : To save preferences
        public void SavePreferences()
        {
            try 
            {
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0_ContentHolderHeader_lbtnSavePrefHeader"));
            WebDriver.FindElement(By.Id("_ctl0_ContentHolderHeader_lbtnSavePrefHeader")).Click();
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To Select Neither Radio Button
        public void SelectNeitherRadioButtonAndSave()
        {
            try 
            {

            GenericHelper.SelectDefaultWindow();
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0_ContentHolderArea_rdrNeither"));
            WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_rdrNeither")).Click();
            WebDriver.FindElement(By.Id("_ctl0_ContentHolderHeader_lbtnSavePrefHeader")).Click();
            GenericHelper.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }


    }
}
