using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSUserCreation
{
    public class FrmRegisterPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private static string smsUserName;
        //Purpose - to click on I accept button
        public void ToClickIAcceptButton()
        {
            try
            {
                GenericHelper.SelectWindow("License Agreement and Privacy Policy");
                Assert.AreEqual("License Agreement and Privacy Policy", WebDriver.Title);
                GenericHelper.WaitUntilElement((By.CssSelector("img[alt=\"Log In\"]")));
                WebDriver.FindElement(By.CssSelector("img[alt=\"Log In\"]")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "failed");
                Assert.Fail(string.Format("Exception of type {0} cau" +
                                            "ght: {1}", e.GetType(), e.Message));
            }
        }

        // purpose - To Create SMSuser  
        public void ToCreateSmsUser(string userType)
        {
            try
            {
                GenericHelper.SelectWindow("Access Information");
                Assert.AreEqual("Access Information", WebDriver.Title);
                GenericHelper.WaitUntilElement((By.Id("accountNo")));
                if (!WebDriver.FindElement(By.Id("accountNo")).Selected)
                {
                    WebDriver.FindElement(By.Id("accountNo")).Click();
                }
                GenericHelper.WaitUntilElement((By.Id("new_smsuser_loginname")));
                WebDriver.FindElement(By.Id("new_smsuser_loginname")).Clear();
                if (userType.Equals("CsSmsInstructor"))
                {
                    smsUserName = GenericHelper.GenerateUniqueVariable("smsins");
                }
                if (userType.Equals("CsSmsStudent"))
                {
                    smsUserName = GenericHelper.GenerateUniqueVariable("smsstu");
                }
                WebDriver.FindElement(By.Id("new_smsuser_loginname")).SendKeys(smsUserName);
                GenericHelper.WaitUntilElement((By.Id("createLoginPassword")));
                WebDriver.FindElement(By.Id("createLoginPassword")).Clear();
                WebDriver.FindElement(By.Id("createLoginPassword")).SendKeys("password1");
                GenericHelper.WaitUntilElement((By.Id("createLoginPasswordRetype")));
                WebDriver.FindElement(By.Id("createLoginPasswordRetype")).Clear();
                WebDriver.FindElement(By.Id("createLoginPasswordRetype")).SendKeys("password1");
                GenericHelper.WaitUntilElement(By.PartialLinkText("Switch to a single box for pasting your access code"));
                WebDriver.FindElement(By.PartialLinkText("Switch to a single box for pasting your access code")).Click();
                WebDriver.SwitchTo().ActiveElement();
                GenericHelper.SelectWindow("Access Information");
                GenericHelper.WaitUntilElement((By.Id("access1")));
                WebDriver.FindElement(By.Id("access1")).Clear();
                switch (userType)
                {
                    case "CsSmsInstructor": WebDriver.FindElement(By.Id("access1")).SendKeys("PGCIEN-CAPT-SOME-GALA-THOU-FROM"); break;

                    case "CsSmsStudent": WebDriver.FindElement(By.Id("access1")).SendKeys("PGCISN-MALL-SOME-GALA-DASH-KAKI"); break;
                }
                GenericHelper.WaitUntilElement((By.Id("next")));
                WebDriver.FindElement(By.Id("next")).Click();
                GenericHelper.SelectWindow("Account Information");
                Assert.AreEqual("Account Information", WebDriver.Title);
                GenericHelper.WaitUntilElement(By.Id("firstName"));
                WebDriver.FindElement(By.Id("firstName")).Clear();
                WebDriver.FindElement(By.Id("firstName")).SendKeys(smsUserName);
                GenericHelper.WaitUntilElement(By.Id("lastName"));
                WebDriver.FindElement(By.Id("lastName")).Clear();
                WebDriver.FindElement(By.Id("lastName")).SendKeys(smsUserName);
                GenericHelper.WaitUntilElement(By.Id("emailAddy"));
                WebDriver.FindElement(By.Id("emailAddy")).Clear();
                WebDriver.FindElement(By.Id("emailAddy")).SendKeys("manish.singh@imfinity.com");
                GenericHelper.WaitUntilElement(By.Id("emailAddyConfirm"));
                WebDriver.FindElement(By.Id("emailAddyConfirm")).Clear();
                WebDriver.FindElement(By.Id("emailAddyConfirm")).SendKeys("manish.singh@imfinity.com");
                GenericHelper.WaitUntilElement(By.Id("entered_countryid"));
                new SelectElement(WebDriver.FindElement(By.Id("entered_countryid"))).SelectByText("India");
                GenericHelper.WaitUntilElement(By.Id("otherSchoolName"));
                WebDriver.FindElement(By.Id("otherSchoolName")).SendKeys("PegasusSchool");
                GenericHelper.WaitUntilElement(By.Id("otherSchoolCity"));
                WebDriver.FindElement(By.Id("otherSchoolCity")).SendKeys("NewDelhi");
                GenericHelper.WaitUntilElement(By.Name("person_verifyquestionid"));
                new SelectElement(WebDriver.FindElement(By.Name("person_verifyquestionid"))).SelectByText("What town was I born in?");
                GenericHelper.WaitUntilElement(By.Id("password3"));
                WebDriver.FindElement(By.Id("password3")).Clear();
                WebDriver.FindElement(By.Id("password3")).SendKeys("NewDelhi");
                GenericHelper.WaitUntilElement(By.Id("next"));
                WebDriver.FindElement(By.Id("next")).Click();
                GenericHelper.WaitUtilWindow("Confirmation and Summary");
                bool isConfirmationWindowPresent = GenericHelper.IsWindowPresent("Confirmation and Summary");
                if (isConfirmationWindowPresent)
                {
                    GenericHelper.SelectWindow("Confirmation and Summary");
                    Assert.AreEqual("Confirmation and Summary", WebDriver.Title);
                    if (GenericHelper.IsElementPresent(By.CssSelector("img.logInNow")))
                    {
                        #region Selecting SMS User Type
                        switch (userType)
                        {
                            case "CsSmsInstructor": DatabaseTools.UpdateUserDb(Enumerations.UserType.CsSmsInstructor, smsUserName, "password1", "manish.singh@imfinity.com", 13, true);
                                GenericHelper.Logs(string.Format("SMS User has been successfully created with {0}", smsUserName), "Passed"); break;
                            case "CsSmsStudent": DatabaseTools.UpdateUserDb(Enumerations.UserType.CsSmsStudent, smsUserName, "password1", "manish.singh@imfinity.com", 14, true);
                                GenericHelper.Logs(string.Format("SMS User has been successfully created with {0}", smsUserName), "Passed");
                                break;
                        }
                        #endregion Selecting SMS User Type
                    }
                }
                else
                {
                    GenericHelper.Logs(string.Format("SMS User has not created with {0}", smsUserName), "Failed");
                    Assert.Fail("SMS User has not created with {0}", smsUserName);
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "failed");
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }
    }
}
