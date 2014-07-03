using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Pegasus_DataAccess;
using System;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus.LoginPage
{
    public class LoginPage : BasePage
    {
        private IWebElement _iElement;
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        // Purpose: Method To Login In Ws by Ws Admin
        public void Login(string un, string pwd, string applLoginMode, string userType)
        {
            try
            {
                GenericHelper.WaitUntillWindowAndElement("Pegasus Login", By.Id("username"));
                WebDriver.Manage().Cookies.DeleteAllCookies();
                WebDriver.FindElement(By.Id("username")).SendKeys(un);
                WebDriver.FindElement(By.Id("password")).SendKeys(pwd);
                WebDriver.FindElement(By.ClassName("lgn_btn")).Submit();
                Thread.Sleep(10000);
                if (!(GenericHelper.WaitUntillWindowAndElement("Global Home", By.XPath(LogOut)) || GenericHelper.WaitUntillWindowAndElement("Course Enrollment", By.XPath(LogOut)) || GenericHelper.WaitUntillWindowAndElement("Update My Pearson account", By.XPath(LogOut)) || GenericHelper.IsElementPresent(By.ClassName("dvBgColourErrorCodesConsent"))))
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        WebDriver.FindElement(By.Id("username")).SendKeys(un);
                        WebDriver.FindElement(By.Id("password")).SendKeys(pwd);
                        WebDriver.FindElement(By.ClassName("lgn_btn")).Submit();
                        if (GenericHelper.WaitUntillWindowAndElement("Global Home", By.XPath(LogOut)) || GenericHelper.WaitUntillWindowAndElement("Course Enrollment", By.XPath(LogOut)) || GenericHelper.WaitUntillWindowAndElement("Update My Pearson account", By.XPath(LogOut)) || GenericHelper.IsElementPresent(By.ClassName("dvBgColourErrorCodesConsent")) == true) break;
                        else
                        {
                            if (i == 3)
                            {
                                string currentUrl = WebDriver.Url;
                                GenericHelper.Logs(string.Format("Not able to login due to build slowness or session out problem, the current Url is '{0}' , Please Try Again", currentUrl), "FAILED");
                                throw new Exception(string.Format("Not able to login due to build slowness or or session out problem, the current Url is '{0}' , Please Try Again", currentUrl));
                            }
                        }
                    }
                }
                bool firstUserLogin = WebDriver.Url.Contains("resetpwd") | WebDriver.Url.Contains("ResetPassword");
                if (firstUserLogin)
                {
                    switch (applLoginMode)
                    {
                        // Purpose: Login with Ws Teacher for First Time
                        case "workspace":
                            GenericHelper.WaitUntilElement(By.Id("txtCurrentPassword"));
                            WebDriver.FindElement(By.Id("txtCurrentPassword")).SendKeys(pwd);
                            GenericHelper.WaitUntilElement(By.Id("txtNewPassword"));
                            WebDriver.FindElement(By.Id("txtNewPassword")).SendKeys(pwd + "4");
                            GenericHelper.WaitUntilElement(By.Id("txtConfirmPassword"));
                            WebDriver.FindElement(By.Id("txtConfirmPassword")).SendKeys(pwd + "4");
                            GenericHelper.WaitUntilElement(By.Id("btnSave"));
                            WebDriver.FindElement(By.Id("btnSave")).Click();
                            Thread.Sleep(2000);
                            if (GenericHelper.IsElementPresent(By.Id("_ctl6__ctl1_imageIcon")))
                            {
                                for (int i = 1; i <= 3; i++)
                                {
                                    WebDriver.FindElement(By.Id("username")).SendKeys(un);
                                    WebDriver.FindElement(By.Id("password")).SendKeys(pwd);
                                    WebDriver.FindElement(By.ClassName("lgn_btn")).Submit();
                                    Thread.Sleep(2000);
                                    if (!GenericHelper.IsElementPresent(By.Id("_ctl6__ctl1_imageIcon")) == true) break;
                                    else
                                    {
                                        if (i == 3)
                                        {
                                            string currentUrl = WebDriver.Url;
                                            GenericHelper.Logs(string.Format("Not able to login due to build slowness or session out problem, the current Url is '{0}' , Please Try Again", currentUrl), "FAILED");
                                            throw new Exception(string.Format("Not able to login due to build slowness or or session out problem, the current Url is '{0}' , Please Try Again", currentUrl));
                                        }
                                    }
                                }
                            }
                            break;
                        // Purpose: Login with Cs Teacher for First Time
                        case "coursespace":
                            GenericHelper.WaitUntilElement(By.Id("ChkPrivacy"));
                            IWebElement chkPrivacy = WebDriver.FindElement(By.Id("ChkPrivacy"));
                            new Actions(WebDriver).Click(chkPrivacy).Perform();
                            GenericHelper.WaitUntilElement(By.Id("ChkTermsOfUse"));
                            IWebElement chkTermsOfUse = WebDriver.FindElement(By.Id("ChkTermsOfUse"));
                            new Actions(WebDriver).Click(chkTermsOfUse).Perform();
                            GenericHelper.WaitUntilElement(By.Id("_ctl4__ctl1_btnContinue"));
                            IWebElement btnContinue = WebDriver.FindElement(By.Id("_ctl4__ctl1_btnContinue"));
                            new Actions(WebDriver).Click(btnContinue).Perform();
                            GenericHelper.WaitUntilElement(By.Id("CurrentPassword"));
                            WebDriver.FindElement(By.Id("CurrentPassword")).SendKeys(pwd);
                            Thread.Sleep(3000);
                            GenericHelper.WaitUntilElement(By.Id("NewPassword"));
                            WebDriver.FindElement(By.Id("NewPassword")).SendKeys(pwd + "4");
                            GenericHelper.WaitUntilElement(By.Id("ConfirmNewPassword"));
                            WebDriver.FindElement(By.Id("ConfirmNewPassword")).SendKeys(pwd + "4");
                            _iElement = WebDriver.FindElement(By.Id("SecurityQuestion"));
                            SelectElement selectElement1 = new SelectElement(_iElement);
                            selectElement1.SelectByText("Your city of birth?");
                            WebDriver.FindElement(By.Id("SecQuestionAnswertxt")).SendKeys("Mysore");
                            GenericHelper.WaitUntilElement(By.Id("imgbtnSave"));
                            WebDriver.FindElement(By.Id("imgbtnSave")).Click();
                            Thread.Sleep(3000);
                            if (GenericHelper.IsElementPresent(By.Id("_ctl6__ctl1_imageIcon")))
                            {
                                for (int i = 1; i <= 3; i++)
                                {
                                    WebDriver.FindElement(By.Id("username")).SendKeys(un);
                                    WebDriver.FindElement(By.Id("password")).SendKeys(pwd);
                                    WebDriver.FindElement(By.ClassName("lgn_btn")).Submit();
                                    Thread.Sleep(2000);
                                    if (!GenericHelper.IsElementPresent(By.Id("_ctl6__ctl1_imageIcon")) == true) break;
                                    else
                                    {
                                        if (i == 3)
                                        {
                                            string currentUrl = WebDriver.Url;
                                            GenericHelper.Logs(string.Format("Not able to login due to build slowness or session out problem, the current Url is '{0}' , Please Try Again", currentUrl), "FAILED");
                                            throw new Exception(string.Format("Not able to login due to build slowness or or session out problem, the current Url is '{0}' , Please Try Again", currentUrl));
                                        }
                                    }
                                }
                            }
                            break;
                    }
                    switch (userType)
                    {
                        case "WSAdmin":
                            DatabaseTools.UpdatePassword("WSAdmin", pwd + "4");
                            break;
                        case "WSTeacher":
                            DatabaseTools.UpdatePassword(un, pwd + "4");
                            break;
                        case "WSStudent":
                            DatabaseTools.UpdatePassword("WSStudent", pwd + "4");
                            break;
                        case "CSTeacher":
                            DatabaseTools.UpdatePassword(un, pwd + "4");
                            break;
                        case "HEDWSInstructor":
                            DatabaseTools.UpdatePassword(un, pwd + "4");
                            break;
                    }
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
