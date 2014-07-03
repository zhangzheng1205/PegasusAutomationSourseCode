using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_DataAccess;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement
{
    public class CourseEnrollmentModePage : BasePage
    {
        //Purpose: To Click ADD button to Associate Course To Product
        public void ClickSaveButton()
        {
            try
            {
                bool isManageProductsWindowPresent = GenericHelper.WaitUtilWindow("Enrollment Mode");
                if (isManageProductsWindowPresent)
                {
                    GenericHelper.SelectWindow("Enrollment Mode");
                    GenericHelper.WaitUntilElement(By.Id("imgbtnSave"));
                    IWebElement imgbtnSave = WebDriver.FindElement(By.Id("imgbtnSave"));
                    new Actions(WebDriver).Click(imgbtnSave).Perform();
                    if (GenericHelper.IsPopUpClosed(2))
                    {
                        GenericHelper.Logs("'Enrollment Mode' pop up is closed on clicking save button", "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs("'Enrollment Mode' pop up is not closed on clicking the save button", "FAILED");
                        throw new Exception("'Enrollment Mode' pop up is not closed on clicking the save button");
                    }
                }
                else
                {
                    GenericHelper.Logs("'Enrollment Mode' window not present in order to enroll course to product.", "FAILED");
                    throw new NoSuchWindowException("'Enrollment Mode' window not present in order to enroll course to product.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isEnrollmentModeWindowPresent = GenericHelper.IsPopUpWindowPresent("Enrollment Mode");
                if (isEnrollmentModeWindowPresent)
                {
                    GenericHelper.SelectWindow("Enrollment Mode");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }
    }
}
