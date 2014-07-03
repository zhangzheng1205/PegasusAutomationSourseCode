using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement
{
    public class AddButtonPage : BasePage
    {
        //Purpose: To Click ADD button to associate course to product
        public void ClickAddButton()
        {
            try
            {
                bool isManageProductsWindowPresent = GenericHelper.WaitUtilWindow("Manage Products");
                if (isManageProductsWindowPresent)
                {
                    GenericHelper.SelectWindow("Manage Products");
                    GenericHelper.WaitUntilElement(By.Id("ifrmWorkspace"));
                    WebDriver.SwitchTo().Frame("ifrmWorkspace");
                    GenericHelper.WaitUntilElement(By.Id("ifrmMiddle"));
                    WebDriver.SwitchTo().Frame("ifrmMiddle");
                    GenericHelper.WaitUntilElement(By.Id("btnProgramCourses"));
                    bool isProgramCoursesButtonEnabled = WebDriver.FindElement(By.Id("btnProgramCourses")).Enabled;
                    if (isProgramCoursesButtonEnabled)
                    {
                        IWebElement btnProgramCourses = WebDriver.FindElement(By.Id("btnProgramCourses"));
                        new Actions(WebDriver).Click(btnProgramCourses).Perform();
                        WebDriver.SwitchTo().DefaultContent();
                        GenericHelper.WaitUntilElement(By.Id("tdAddNewCourse"));
                        IWebElement tdAddNewCourse = WebDriver.FindElement(By.Id("tdAddNewCourse"));
                        new Actions(WebDriver).Click(tdAddNewCourse).Perform();
                    }
                    else
                    {
                        GenericHelper.Logs("'Program Courses' button not get enabled when selecting course in order to associate to product.", "FAILED");
                        throw new SystemException("'Program Courses' button not get enabled when selecting course in order to associate to product.");
                    }
                }
                else
                {
                    GenericHelper.Logs("'Manage Products' window not present in order to associate course to product.", "FAILED");
                    throw new NoSuchWindowException("'Manage Products' window not present in order to associate course to product.");
                }

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
