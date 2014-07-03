using System;
using System.Configuration;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using Pegasus.NewCoursPage;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Activity;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.User;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.CatalogInstructor;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference;
using OpenQA.Selenium;
using System.Threading;
using System.Linq;
using Framework.Common;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSUserCreation;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TeachingPlan;


namespace Pegasus.ProductionDefect.TestScripts.ProductionDefect_StepDefinitions
{
    public class GenericTestStep : BaseTestScript
    {
        //Purpose: Constant Declaration
        public IWebDriver Webd;
        private static readonly LoginPage.LoginPage LoginPage = new LoginPage.LoginPage();
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";
        //Purpose: Calling Method From Page Class
        private static readonly AdminToolPage.AdminToolPage WsEnrollmentPage = new AdminToolPage.AdminToolPage();
        private static readonly NewCoursePage NewCoursePage = new NewCoursePage();
        private static readonly PublishingNotesPage.PublishingNotesPage PublishingNotesPage = new PublishingNotesPage.PublishingNotesPage();
        private static readonly ManageProductsPage ManageProductsPage = new ManageProductsPage();
        private static readonly ListCoursesPage CoursesPage = new ListCoursesPage();
        private static readonly ProgramCreatePage ProgramCreatePage = new ProgramCreatePage();
        private static readonly ProgramManagementPage ProgramManagementPage = new ProgramManagementPage();
        private static readonly NewProductPage NewProductPage = new NewProductPage();
        private static readonly ProductSearchPage ProductSearchPage = new ProductSearchPage();
        private static readonly HEDGlobalHomePage HEDGlobalHomePage = new HEDGlobalHomePage();
        private static readonly CourseEnrollmentModePage CourseEnrollmentModePage = new CourseEnrollmentModePage();
        private static readonly AddButtonPage AddButtonPage = new AddButtonPage();
        private static readonly FrmRegisterPage RegisterPage = new FrmRegisterPage();
        private static readonly NewUserPage Createuser = new NewUserPage();
        private static readonly MyPegasusUxPage ObjUxPage = new MyPegasusUxPage();
        private static readonly ActivityPreferencesPage Feedback = new ActivityPreferencesPage();
        private static readonly AdminToolPage.AdminToolPage WSEnrollmentpage = new AdminToolPage.AdminToolPage();
        private static readonly ContentLibraryUXPage ContentLibraryUxPage = new ContentLibraryUXPage();
        private static readonly TeachingplanUXPage TeachingplanUxPage = new TeachingplanUXPage();

        // Purpose : Test Step to Browse Url  for Pegasus User(s)     
        public static void StepToBrowsedUrlForPegasusUser(string usertype)
        {
            try
            {
                string browserName = null;
                switch (usertype)
                {
                    // *****PEGSAUS USER LOGIN MANAGEMENT******//

                    #region WS Admin Login
                    case "WS Admin":
                        browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                        if (browserName != "Course Enrollment")
                        {
                            WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.WsAdmin));
                            if (!GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")))
                            {
                                for (int i = 1; i <= 3; i++)
                                {
                                    WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.WsAdmin));
                                    if (GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")) == true) break;
                                    else
                                    {
                                        if (i == 3)
                                        {
                                            GenericHelper.Logs("Page Not Loaded, Please Try Again", "FAILED");
                                            throw new Exception("Page Not Loaded, Please Try Again");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                    #endregion WS Admin Login

                    #region WS Teacher Login
                    case "WSTeacher":
                        string browswerNameteach = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                        if (browswerNameteach != "Global Home" || !WebDriver.Url.Contains("ws"))
                        {
                            WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.WsTeacher));
                            if (!GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")))
                            {
                                for (int i = 1; i <= 3; i++)
                                {
                                    WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.WsTeacher));
                                    if (GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")) == true) break;
                                    else
                                    {
                                        if (i == 3)
                                        {
                                            GenericHelper.Logs("Page Not Loaded, Please Try Again", "FAILED");
                                            throw new Exception("Page Not Loaded, Please Try Again");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                    #endregion WS Teacher Login

                    #region CS Teacher Login
                    case "CSTeacher":
                        browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                        if (browserName != "Global Home")
                        {
                            WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsTeacher));
                            string browswerWindowName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                            if (browswerWindowName != "Global Home")
                            {
                                if (!GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")))
                                {
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsTeacher));
                                        if (GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")) == true) break;
                                        else
                                        {
                                            if (i == 3)
                                            {
                                                GenericHelper.Logs("Page Not Loaded, Please Try Again", "FAILED");
                                                throw new Exception("Page Not Loaded, Please Try Again");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                    #endregion CS Teacher Login

                    #region CS Student Login
                    case "CsStudent":
                        string browswerName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                        if (browswerName != "Global Home")
                        {
                            WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsStudent));
                            string browswerWindowName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                            if (browswerWindowName != "Global Home")
                            {
                                if (!GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")))
                                {
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        WebDriver.Navigate().GoToUrl(
                                            DatabaseTools.GetUrl(Enumerations.UserType.CsStudent));
                                        if (GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")) == true) break;
                                        else
                                        {
                                            if (i == 3)
                                            {
                                                GenericHelper.Logs("Page Not Loaded, Please Try Again", "FAILED");
                                                throw new Exception("Page Not Loaded, Please Try Again");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                    #endregion CS Student Login

                    #region CS Admin Login
                    case "CS Admin":
                        GenericHelper.SelectDefaultWindow();
                        if (!GenericHelper.IsElementPresent(By.PartialLinkText("PKT Integration")))
                        {
                            WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsAdmin));
                            if (!GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")))
                            {
                                for (int i = 1; i <= 3; i++)
                                {
                                    WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsAdmin));
                                    if (GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")) == true) break;
                                    else
                                    {
                                        if (i == 3)
                                        {
                                            GenericHelper.Logs("Page Not Loaded, Please Try Again", "FAILED");
                                            throw new Exception("Page Not Loaded, Please Try Again");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                    #endregion CS Admin Login

                    #region SMSRegistration
                    case "SMSRegistration":
                        browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                        if (browserName != "License Agreement and Privacy Policy")
                        {
                            WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.SMSRegistration));
                            if (!GenericHelper.WaitUntilElement((By.CssSelector("img[alt=\"Log In\"]"))))
                            {
                                for (int i = 1; i <= 3; i++)
                                {
                                    WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.SMSRegistration));
                                    if (GenericHelper.WaitUntilElement((By.CssSelector("img[alt=\"Log In\"]"))) == true) break;
                                    else
                                    {
                                        if (i == 3)
                                        {
                                            GenericHelper.Logs("Page Not Loaded, Please Try Again", "FAILED");
                                            throw new Exception("Page Not Loaded, Please Try Again");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;

                    #endregion SMSRegistration

                    #region HED WS Admin Login
                    case "HED WS Admin":
                        browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                        if (browserName != "Course Enrollment")
                        {
                            WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.HedWsAdmin));
                            if (!GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")))
                            {
                                for (int i = 1; i <= 3; i++)
                                {
                                    WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.HedWsAdmin));
                                    if (GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")) == true) break;
                                    else
                                    {
                                        if (i == 3)
                                        {
                                            GenericHelper.Logs("Page Not Loaded, Please Try Again", "FAILED");
                                            throw new Exception("Page Not Loaded, Please Try Again");
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            return;
                        }
                        break;
                    #endregion HED WS Admin Login

                    #region HED CS Admin Login
                    case "HED CS Admin":
                        GenericHelper.SelectDefaultWindow();
                        if (!GenericHelper.IsElementPresent(By.PartialLinkText("PKT Integration")))
                        {
                            WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.HedCsAdmin));
                            if (!GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")))
                            {
                                for (int i = 1; i <= 3; i++)
                                {
                                    WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.HedCsAdmin));
                                    if (GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")) == true) break;
                                    else
                                    {
                                        if (i == 3)
                                        {
                                            GenericHelper.Logs("Page Not Loaded, Please Try Again", "FAILED");
                                            throw new Exception("Page Not Loaded, Please Try Again");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                    #endregion HED CS Admin Login

                    #region HED CSTeacher Login
                    case "CsSmsInstructor":
                        browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                        if (browserName != "Global Home")
                        {
                            WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsSmsInstructor));
                            string browswerWindowName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                            if (browswerWindowName != "Global Home")
                            {
                                if (!GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")))
                                {
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsSmsInstructor));
                                        if (GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")) == true) break;
                                        else
                                        {
                                            if (i == 3)
                                            {
                                                GenericHelper.Logs("Page Not Loaded, Please Try Again", "FAILED");
                                                throw new Exception("Page Not Loaded, Please Try Again");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                    #endregion HED CSTeacher Login

                    #region HED CSstudent Login
                    case "CsSmsStudent":
                        browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                        if (browserName != "Global Home")
                        {
                            WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsSmsStudent));
                            string browswerWindowName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                            if (browswerWindowName != "Global Home")
                            {
                                if (!GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")))
                                {
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsSmsInstructor));
                                        if (GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")) == true) break;
                                        else
                                        {
                                            if (i == 3)
                                            {
                                                GenericHelper.Logs("Page Not Loaded, Please Try Again", "FAILED");
                                                throw new Exception("Page Not Loaded, Please Try Again");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                    #endregion HED CSstudent Login

                    #region HED WS Teacher Login
                    case "HEDTeacher":
                        string browswerNameteachHED = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                        if (browswerNameteachHED != "Global Home" || !WebDriver.Url.Contains("ws"))
                        {
                            WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.HedWsInstructor));
                            if (!GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")))
                            {
                                for (int i = 1; i <= 3; i++)
                                {
                                    WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.HedWsInstructor));
                                    if (GenericHelper.IsElementPresent(By.Id("ImgPoweredBy")) == true) break;
                                    else
                                    {
                                        if (i == 3)
                                        {
                                            GenericHelper.Logs("Page Not Loaded, Please Try Again", "FAILED");
                                            throw new Exception("Page Not Loaded, Please Try Again");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                    #endregion WS Teacher Login
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Test Step To Login as WS Teacher
        public static void StepToLoggedIntoTheWorkspaceAsWsTeacher()
        {
            try
            {
                string url = WebDriver.Url;
                if (url.Contains("ws") && GenericHelper.IsElementPresent(By.ClassName("ancCourseNameStuViewCls")))
                {
                    StepTonIselectGlobalHomeButton();
                }
                else if (url.Contains("ws") && WebDriver.Title.ToString(CultureInfo.InvariantCulture) == "Global Home")
                {

                }
                else
                {
                    string wsUserDb = DatabaseTools.GetUsername(Enumerations.UserType.WsTeacher);
                    string wsPwdDb = DatabaseTools.GetPassword(Enumerations.UserType.WsTeacher);
                    //Purpose: Credentials will be Taken From DB
                    LoginPage.Login(wsUserDb, wsPwdDb, "workspace", "WSTeacher");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Test Step To Login as WS Admin
        public static void StepToLoggedIntoTheWorkspaceAsWsAdmin()
        {
            try
            {
                string browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                if (browserName != "Course Enrollment")
                {
                    string wsAdminUserDb = DatabaseTools.GetUsername(Enumerations.UserType.WsAdmin);
                    string wsAdminPwdDb = DatabaseTools.GetPassword(Enumerations.UserType.WsAdmin);
                    //Purpose: Credentials will be Taken From DB
                    LoginPage.Login(wsAdminUserDb, wsAdminPwdDb, "workspace", "WSAdmin");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Test Step To Login as HED WS Admin
        public static void StepToLoggedIntoTheWorkspaceAsHedWsAdmin()
        {
            try
            {
                string browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                if (browserName != "Course Enrollment")
                {
                    string wsAdminUserDb = DatabaseTools.GetUsername(Enumerations.UserType.HedWsAdmin);
                    string wsAdminPwdDb = DatabaseTools.GetPassword(Enumerations.UserType.HedWsAdmin);
                    //Purpose: Credentials will be Taken From DB
                    LoginPage.Login(wsAdminUserDb, wsAdminPwdDb, "workspace", "WSAdmin");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Test Step To Login as HED CS Admin
        public static void StepToLoggedIntoTheCourseSpaceAsCSAdmin()
        {
            try
            {
                GenericHelper.SelectDefaultWindow();
                if (!GenericHelper.IsElementPresent(By.PartialLinkText("PKT Integration")))
                {
                    string wsAdminUserDb = DatabaseTools.GetUsername(Enumerations.UserType.CsAdmin);
                    string wsAdminPwdDb = DatabaseTools.GetPassword(Enumerations.UserType.CsAdmin);
                    //Purpose: Credentials will be Taken From DB
                    LoginPage.Login(wsAdminUserDb, wsAdminPwdDb, "coursespace", "CSAdmin");
                    GenericHelper.WaitUntillWindowAndElement("Course Enrollment", By.PartialLinkText("Publishing"));
                }
                else
                {
                    return;
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Test Step To Login as HED CS Admin
        public static void StepToLoggedIntoTheCourseSpaceAsHedCSAdmin()
        {
            try
            {
                GenericHelper.SelectDefaultWindow();
                if (!GenericHelper.IsElementPresent(By.PartialLinkText("PKT Integration")))
                {
                    string wsAdminUserDb = DatabaseTools.GetUsername(Enumerations.UserType.HedCsAdmin);
                    string wsAdminPwdDb = DatabaseTools.GetPassword(Enumerations.UserType.HedCsAdmin);
                    //Purpose: Credentials will be Taken From DB
                    LoginPage.Login(wsAdminUserDb, wsAdminPwdDb, "coursespace", "CSAdmin");
                    GenericHelper.WaitUntillWindowAndElement("Course Enrollment", By.PartialLinkText("Publishing"));
                }
                else
                {
                    return;
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Test Step To Verify Page is Opened 
        public static void StepToItShouldBeOnPage(string pageName)
        {
            try
            {
                GenericHelper.SelectWindow(pageName);
                string browserName = null;
                if (Browser.Equals("FF") || Browser.Equals("GC"))
                {
                    browserName = WebDriver.Title;
                }
                if (Browser.Equals("IE"))
                {
                    browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                }
                if (browserName == pageName)
                {
                    GenericHelper.Logs(pageName + " Page is displayed.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs(pageName + " Page is not displayed.", "FAILED");
                    throw new NoSuchWindowException(pageName + " Page is not displayed.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                StepToIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Test Step To Verify Page Name   
        public static void StepToIShouldSeeTheNewPopup(string pageName)
        {
            try
            {
                string popupName = null;
                GenericHelper.WaitUtilWindow(pageName);
                popupName = WebDriver.WindowHandles.Last();
                if (popupName == pageName)
                {
                    GenericHelper.Logs(pageName + " popup is displayed.", "PASSED");
                }
                else if (popupName != pageName)
                {
                    popupName = WebDriver.WindowHandles.First();
                    if (popupName == pageName)
                    {
                        GenericHelper.Logs(pageName + " popup is displayed.", "PASSED");
                    }
                }
                else
                {
                    GenericHelper.Logs(pageName + " popup is not displayed.", "FAILED");
                    throw new NoSuchWindowException(pageName + " popup is not displayed.");
                }
            }
            catch (Exception e)
            {
                if (Browser.Equals("FF") || Browser.Equals("IE"))
                {
                    BackedSelenium.SelectWindow("");
                }
                if (Browser.Equals("GC"))
                {
                    GenericHelper.SelectDefaultWindow();
                }
                IWebElement clickLogoutLink = WebDriver.FindElement((By.XPath(LogOut)));
                if (clickLogoutLink.Displayed && clickLogoutLink.Enabled)
                {
                    WebDriver.SwitchTo().DefaultContent();
                    new Actions(WebDriver).Click(clickLogoutLink).Perform();
                }
                Thread.Sleep(7000);
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Test Step To Verify Success Message in Work Spoce
        public static void StepToItShouldDisplaySuccessfulMessage(string successMsg)
        {
            try
            {
                if (Browser.Equals("FF") || Browser.Equals("IE"))
                {
                    BackedSelenium.SelectWindow("");
                }
                if (Browser.Equals("GC"))
                {
                    GenericHelper.SelectDefaultWindow();
                }
                bool ismessagedisplayed = GenericHelper.VerifySuccesfullMessage(successMsg);
                if (ismessagedisplayed == true)
                {
                    GenericHelper.Logs(successMsg + " Successful message displayed", "PASSED");
                }
                else
                {
                    GenericHelper.Logs(successMsg + " Successful message not displayed", "FAILED");
                    throw new Exception(successMsg + " Successful message not displayed");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
            }
        }

        // Purpose : Test Step To Verify Success Message in Course Space
        public static void StepToItShouldDisplaySuccessfulMessageInPage(string successMsg, string page)
        {
            try
            {
                GenericHelper.SelectWindow(page);
                bool ismessagedisplayed = GenericHelper.VerifySuccesfullMessage(successMsg);
                if (ismessagedisplayed)
                {
                    GenericHelper.Logs(successMsg + " Successful message displayed", "PASSED");
                }
                else
                {
                    GenericHelper.Logs(successMsg + " Successful message not displayed", "FAILED");
                    throw new Exception(successMsg + " Successful message not displayed");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isManageOrganizationWindowPresent = GenericHelper.IsPopUpWindowPresent("Manage Organization");
                if (isManageOrganizationWindowPresent)
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                StepToIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Test Step To Click on Logout Link From Ws
        public static void StepToIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication()
        {
            try
            {
                if (Browser.Equals("FF") || Browser.Equals("IE"))
                {
                    WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                }
                if (Browser.Equals("GC"))
                {
                    GenericHelper.SelectDefaultWindow();
                }
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.WaitUntilElement((By.XPath(LogOut)));
                IWebElement clickLogoutLink = WebDriver.FindElement((By.XPath(LogOut)));
                if (clickLogoutLink.Displayed && clickLogoutLink.Enabled)
                {
                    clickLogoutLink.Click();
                }
                bool logout = WebDriver.Url.Contains("logout") || WebDriver.Url.Contains("frmLogOut");
                if (logout)
                {
                    GenericHelper.Logs("Logout from the application successfull.", "PASSED");
                }
                else
                {
                    if (!logout)
                    {
                        clickLogoutLink.Click();
                    }
                    else
                    {
                        GenericHelper.Logs("Logout from the application unsuccessfull.", "FAILED");
                        throw new Exception("Logout from the application unsuccessfull.");
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Test Step To Click on Logout Link From Ws
        public static void StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.XPath("//a[contains(@id,'_testLogOut')]"));
                IWebElement clickLogoutLink = WebDriver.FindElement(By.XPath("//a[contains(@id,'_testLogOut')]"));
                if (clickLogoutLink.Displayed && clickLogoutLink.Enabled)
                {
                    clickLogoutLink.Click();
                }
                bool logout = WebDriver.Url.Contains("logout") || WebDriver.Url.Contains("frmLogOut");
                if (logout)
                {
                    GenericHelper.Logs("Logout from application is successfull", "PASSED");
                }
                else
                {
                    if (!logout)
                    {
                        clickLogoutLink.Click();
                    }
                    else
                    {
                        GenericHelper.Logs("Logout from the application unsuccessfull.", "FAILED");
                        throw new Exception("Logout from the application unsuccessfull.");
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Test Step to Select the Specified Tab or Sub Tab in Work Space
        public static void StepToNavigateToTheTab(string tab)
        {
            try
            {
                Thread.Sleep(5000);
                string beforeUrl = WebDriver.Url;
                GenericHelper.WaitUntilElement(By.PartialLinkText(tab));
                WebDriver.FindElement(By.PartialLinkText(tab)).Click();
                if (WebDriver.Url == beforeUrl)
                {
                    WebDriver.FindElement(By.PartialLinkText(tab)).Click();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Test Step to Select the Specified Tab or Sub Tab in Course Space
        public static void StepToSwitchToTheTab(string tab)
        {
            try
            {
                string beforeUrl = WebDriver.Url;
                GenericHelper.WaitUntilElement(By.PartialLinkText(tab));
                WebDriver.FindElement(By.PartialLinkText(tab)).Click();
                if (WebDriver.Url == beforeUrl)
                {
                    WebDriver.FindElement(By.PartialLinkText(tab)).Click();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Test Step to Select the course in globalhome of workspace
        public static void StepToSelectTheCreatedCourse(string course)
        {
            try
            {
                GenericHelper.WaitUntilElement(By.PartialLinkText(course));
                WebDriver.FindElement(By.PartialLinkText(course)).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Test Step To Click on a particular link
        public static void StepToClickOnTheLink(String linkName)
        {
            try
            {
                GenericHelper.WaitUntilElement(By.LinkText(linkName));
                WebDriver.FindElement(By.LinkText(linkName)).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Test Step To Verify ST Environment Working Fine
        public static void StepToSetupSTEnvironment(string sTurl)
        {
            try
            {
                WebDriver.Navigate().GoToUrl(sTurl);
                IWebElement homePageElement = WebDriver.FindElement(By.Id("ImgPoweredBy"));
                if (homePageElement.Displayed)
                {
                    GenericHelper.Logs("Smoke Environment Setup Completed", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Smoke Environment Setup Completed", "FAILED");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Test Step To Verify The Page Name
        public static void StepToIAmOnThePage(string pageName)
        {
            try
            {
                Thread.Sleep(3000);
                string popup = WebDriver.WindowHandles.Last();
                string popupName = WebDriver.SwitchTo().Window(popup).Title;
                if (popupName == pageName)
                {
                    GenericHelper.Logs(pageName + " page is dispalyed.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs(pageName + " page is not dispalyed.", "FAILED");
                    throw new NoSuchWindowException(pageName + " page is not dispalyed.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                StepToIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To verify UserCreation/Course creation page is present
        public static void StepToIAmOnTheUserCreationPage()
        {
            try
            {
                string browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                if (browserName == "Course Enrollment")
                    GenericHelper.Logs("WS Course Enrollment Page is displayed", "PASSED");
                else
                    GenericHelper.Logs("WS Course Enrollment Page is not displayed", "FAILED");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To click CreateNewUser/CreateNewCourse link 
        public static void StepToClickedOnTheLink(string linkName, string frame)
        {
            try
            {

                WebDriver.SwitchTo().Frame("ifrm" + frame + "");
                GenericHelper.WaitUntilElement(By.PartialLinkText(linkName));
                WebDriver.FindElement(By.PartialLinkText(linkName)).Click();
                Thread.Sleep(2000);
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step To Select Home Button
        public static void StepToSelectHomeButton()
        {
            try
            {
                Thread.Sleep(1000);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step To Select Global Home Button
        public static void StepTonIselectGlobalHomeButton()
        {
            try
            {
                Thread.Sleep(1000);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To Click on Specified Link
        public static void StepToClickedOnTheApproveCourseLink(string linktext)
        {
            try
            {
                GenericHelper.WaitUntilElement(By.PartialLinkText(linktext));
                IWebElement clickApproveLink = WebDriver.FindElement(By.PartialLinkText(linktext));
                new Actions(WebDriver).MoveToElement(clickApproveLink).Click(clickApproveLink).Perform();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To Click on The Search/View Button
        public static void StepToClickedOnSearchViewButton(string frameId)
        {
            try
            {
                WebDriver.SwitchTo().ActiveElement();
                WebDriver.SwitchTo().Frame(frameId);
                GenericHelper.WaitUntilElement(By.Id("btnShowHide"));
                WebDriver.FindElement(By.Id("btnShowHide")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To Search any Level Organization From the Organization Tab
        public static void StepToSearchTheOrganization(string levelName)
        {
            try
            {
                switch (levelName)
                {
                    case "District":
                        string distName = DatabaseTools.GetOrganization(Enumerations.OrgLevelType.District).Trim();
                        new OrganizationManagementPage().SearchAndSelectOrg(distName);
                        break;
                    case "State":
                        string stateName = DatabaseTools.GetOrganization(Enumerations.OrgLevelType.State).Trim();
                        new OrganizationManagementPage().SearchAndSelectOrg(stateName);
                        break;
                    case "School":
                        string schoolName = DatabaseTools.GetOrganization(Enumerations.OrgLevelType.School).Trim();
                        new OrganizationManagementPage().SearchAndSelectOrg(schoolName);
                        break;
                    case "Region":
                        string regionName = DatabaseTools.GetOrganization(Enumerations.OrgLevelType.Region).Trim();
                        new OrganizationManagementPage().SearchAndSelectOrg(regionName);
                        break;
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                StepToIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step  To close the Manage Organization Window and Log Out From the Application
        public static void StepToClosetheManageOrganizationAndLogOutFromTheApplication()
        {
            try
            {
                WebDriver.Close();
                GenericHelper.SelectWindow("Organization Management");
                WebDriver.FindElement(By.LinkText("Sign out")).Click();
                WebDriver.Manage().Cookies.DeleteAllCookies();
                Thread.Sleep(3000);
                bool logout = WebDriver.Url.Contains("logout");
                if (logout)
                    GenericHelper.Logs("logout successful", "PASSED");
                else
                    GenericHelper.Logs("logout failed", "FAILED");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To login as CS Student
        public static void StepToLoggedIntoTheCourseSpaceAsCSStudent()
        {
            try
            {
                string browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                if (browserName != "Global Home")
                {
                    GenericHelper.SelectDefaultWindow();
                    WebDriver.Manage().Cookies.DeleteAllCookies();
                    string csUserUNDb = DatabaseTools.GetEnrolledUserLoginName(Enumerations.UserType.CsStudent);
                    string csUserPwdDb = DatabaseTools.GetEnrolledUserPassword(Enumerations.UserType.CsStudent);
                    if (GenericHelper.IsElementPresent(By.Id("_ctl6_PegasushelloK5_lblWelcomeText")))
                    {
                        if (Browser.Equals("IE"))
                        {
                            if (
                                !WebDriver.FindElement(By.Id("_ctl6_PegasushelloK5_lblWelcomeText")).GetAttribute("innerText").Contains("Welcome " + csUserUNDb))
                            {
                                WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsTeacher));
                                LoginPage.Login(csUserUNDb, csUserPwdDb, "coursespace", "CSStudent");
                            }
                        }
                        if (Browser.Equals("FF") || Browser.Equals("GC"))
                        {
                            if (
                                   !WebDriver.FindElement(By.Id("_ctl6_PegasushelloK5_lblWelcomeText")).Text.Contains("Welcome " + csUserUNDb))
                            {
                                WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsTeacher));
                                LoginPage.Login(csUserUNDb, csUserPwdDb, "coursespace", "CSStudent");
                            }
                        }
                    }
                    else
                    {
                        WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsTeacher));
                        LoginPage.Login(csUserUNDb, csUserPwdDb, "coursespace", "CSStudent");
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To Login as CS Teacher
        public static void StepToLoggedIntoTheCourseSpaceAsCSTeacher()
        {
            try
            {
                string browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                if (browserName != "Global Home")
                {
                    GenericHelper.SelectDefaultWindow();
                    Thread.Sleep(1000);
                    string csUserUNDb = DatabaseTools.GetEnrolledUserLoginName(Enumerations.UserType.CsTeacher);
                    string csUserPwdDb = DatabaseTools.GetEnrolledUserPassword(Enumerations.UserType.CsTeacher);
                    if (GenericHelper.IsElementPresent(By.Id("_ctl7_GlobalHomeToolBarUC_lblWelcomeText1")))
                    {
                        if (Browser.Equals("FF") || Browser.Equals("GC"))
                        {
                            if (!WebDriver.FindElement(By.Id("_ctl7_GlobalHomeToolBarUC_lblWelcomeText1")).Text.Contains("Welcome " + csUserUNDb))
                            {
                                LoginPage.Login(csUserUNDb, csUserPwdDb, "coursespace", "CSTeacher");
                            }
                        }
                        if (Browser.Equals("IE"))
                        {
                            if (!WebDriver.FindElement(By.Id("_ctl7_GlobalHomeToolBarUC_lblWelcomeText1")).GetAttribute("innerText").Contains("Welcome " + csUserUNDb))
                            {
                                LoginPage.Login(csUserUNDb, csUserPwdDb, "coursespace", "CSTeacher");
                            }
                        }
                    }
                    else
                    {
                        LoginPage.Login(csUserUNDb, csUserPwdDb, "coursespace", "CSTeacher");
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To Login as SMS Instructor
        public static void StepToLoggedIntoTheCourseSpaceAsSMSInstructor()
        {
            try
            {
                string browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                if (browserName != "Global Home")
                {
                    string csUserUNDb = DatabaseTools.GetEnrolledUserLoginName(Enumerations.UserType.CsSmsInstructor);
                    string csUserPwdDb = DatabaseTools.GetEnrolledUserPassword(Enumerations.UserType.CsSmsInstructor);
                    if (GenericHelper.IsElementPresent(By.Id("DivWelcome")))
                    {

                        if (Browser.Equals("IE"))
                        {
                            if (!WebDriver.FindElement(By.Id("DivWelcome")).GetAttribute("innerText").Contains("Welcome " + csUserUNDb))
                            {
                                GenericHelper.WaitUntillWindowAndElement("Pegasus Login", By.Id("loginname"));
                                WebDriver.Manage().Cookies.DeleteAllCookies();
                                WebDriver.FindElement(By.Id("loginname")).SendKeys(csUserUNDb);
                                WebDriver.FindElement(By.Id("password")).SendKeys(csUserPwdDb);
                                WebDriver.FindElement(By.ClassName("lgn_btn")).Submit();
                                Thread.Sleep(10000);
                                if (!(GenericHelper.WaitUntillWindowAndElement("Global Home", By.XPath(LogOut))))
                                {
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        WebDriver.FindElement(By.Id("loginname")).SendKeys(csUserUNDb);
                                        WebDriver.FindElement(By.Id("password")).SendKeys(csUserPwdDb);
                                        WebDriver.FindElement(By.ClassName("lgn_btn")).Submit();
                                        if (GenericHelper.WaitUntillWindowAndElement("Global Home", By.XPath(LogOut)) == true) break;
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
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }



        /// <summary>
        /// This method is for login with teaching assistant
        /// </summary>
        public static void StepToLoggedIntoTheCourseSpaceAsTeachingAssistant()
        {
            try
            {
                string browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                if (browserName != "Global Home")
                {
                    GenericHelper.SelectDefaultWindow();
                    Thread.Sleep(1000);
                    string csUserUNDb = DatabaseTools.GetEnrolledTAUserName(Enumerations.UserType.CsTeachingAssitant);
                    string csUserPwdDb = DatabaseTools.GetEnrolledTAPassword(Enumerations.UserType.CsTeachingAssitant);
                    if (GenericHelper.IsElementPresent(By.Id("DivWelcome")))
                    {
                        if (Browser.Equals("IE"))
                        {
                            if (!WebDriver.FindElement(By.Id("DivWelcome")).GetAttribute("innerText").Contains("Welcome " + csUserUNDb))
                            {
                                GenericHelper.WaitUntillWindowAndElement("Pegasus Login", By.Id("loginname"));
                                WebDriver.Manage().Cookies.DeleteAllCookies();
                                WebDriver.FindElement(By.Id("loginname")).SendKeys(csUserUNDb);
                                WebDriver.FindElement(By.Id("password")).SendKeys(csUserPwdDb);
                                WebDriver.FindElement(By.ClassName("lgn_btn")).Submit();
                                Thread.Sleep(10000);
                                if (!(GenericHelper.WaitUntillWindowAndElement("Global Home", By.XPath(LogOut))))
                                {
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        WebDriver.FindElement(By.Id("loginname")).SendKeys(csUserUNDb);
                                        WebDriver.FindElement(By.Id("password")).SendKeys(csUserPwdDb);
                                        WebDriver.FindElement(By.ClassName("lgn_btn")).Submit();
                                        if (GenericHelper.WaitUntillWindowAndElement("Global Home", By.XPath(LogOut)) == true) break;
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
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
        //Purpose: Step To Login as SMS Instructor
        public static void StepToLoggedIntoTheCourseSpaceAsSMSStudent()
        {
            try
            {
                string windowName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                if (windowName != "Global Home")
                {
                    Thread.Sleep(1000);
                    string csUserUNDb = DatabaseTools.GetEnrolledUserLoginName(Enumerations.UserType.CsSmsStudent);
                    string csUserPwdDb = DatabaseTools.GetEnrolledUserPassword(Enumerations.UserType.CsSmsStudent);
                    if (GenericHelper.IsElementPresent(By.Id("DivWelcome")))
                    {
                        if (Browser.Equals("IE"))
                        {
                            if (!WebDriver.FindElement(By.Id("DivWelcome")).GetAttribute("innerText").Contains("Welcome " + csUserUNDb))
                            {
                                GenericHelper.WaitUntillWindowAndElement("Pegasus Login", By.Id("loginname"));
                                WebDriver.Manage().Cookies.DeleteAllCookies();
                                WebDriver.FindElement(By.Id("loginname")).SendKeys(csUserUNDb);
                                WebDriver.FindElement(By.Id("password")).SendKeys(csUserPwdDb);
                                WebDriver.FindElement(By.ClassName("lgn_btn")).Submit();
                                Thread.Sleep(10000);
                                if (!(GenericHelper.WaitUntillWindowAndElement("Global Home", By.XPath(LogOut))))
                                {
                                    for (int i = 1; i <= 3; i++)
                                    {
                                        WebDriver.FindElement(By.Id("username")).SendKeys(csUserUNDb);
                                        WebDriver.FindElement(By.Id("password")).SendKeys(csUserPwdDb);
                                        WebDriver.FindElement(By.ClassName("lgn_btn")).Submit();
                                        if (GenericHelper.WaitUntillWindowAndElement("Global Home", By.XPath(LogOut)) == true) break;
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
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To verify courses for TA on global home page
        public static void StepToVerifyCoursesforTA()
        {
            try
            {
                GenericHelper.SelectWindow("Global Home");
                bool announcementClose = GenericHelper.CloseAnnouncementPage();
                if (announcementClose)
                {
                    GenericHelper.Logs("Announcement page has been closed successfully", "Passed");
                }
                else
                {
                    GenericHelper.Logs("Announcement page is still not closed", "Failed");
                }
                IWebElement divData = WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody"));
                string dBcoursename = DatabaseTools.GetCourse(Enumerations.CourseType.InstructorCourse);
                if (divData.Text.Contains(dBcoursename))
                {
                    GenericHelper.Logs("Enrolled IC Course1 displayed in the My Courses and Testbanks Channel to SMS Student who is promoted as Teaching Assistant.", "Passed");
                }
                else
                {
                    GenericHelper.Logs("Enrolled IC Course1 not displayed in the My Courses and Testbanks Channel to SMS Student who is promoted as Teaching Assistant.", "Failed");
                    Assert.Fail("Enrolled IC Course1 not displayed in the My Courses and Testbanks Channel to SMS Student who is promoted as Teaching Assistant.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                Assert.Fail(e.ToString());
                StepToIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
            }
        }

        //Purpose: Step To Login as HED WS Instructor
        public static void StepToLoggedIntoTheCourseSpaceAsHEDTeacher()
        {

            try
            {
                string url = WebDriver.Url;
                if (url.Contains("ws") && GenericHelper.IsElementPresent(By.ClassName("ancCourseNameStuViewCls")))
                {
                    StepTonIselectGlobalHomeButton();
                }
                else if (url.Contains("ws") &&
                         WebDriver.Title.ToString(CultureInfo.InvariantCulture) == "Global Home")
                {

                }
                else
                {
                    string wsUserDb = DatabaseTools.GetUsername(Enumerations.UserType.HedWsInstructor);
                    string wsPwdDb = DatabaseTools.GetPassword(Enumerations.UserType.HedWsInstructor);
                    //Purpose: Credentials will be Taken From DB
                    LoginPage.Login(wsUserDb, wsPwdDb, "workspace", "HEDWSInstructor");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To Update the Preference Status of Course
        public static void StepToUpdateThePreferenceStatusInDBForBDDCC(string course)
        {
            try
            {
                string coursename = string.Empty;
                switch (course)
                {
                    case "BDDCC":
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.ContainerCourse);
                        break;
                    case "BDDEC":
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.EmptyCourse);
                        break;
                }
                bool ismessagedisplayed = GenericHelper.VerifySuccesfullMessage("Preferences updated successfully.");
                if (ismessagedisplayed == true)
                {
                    DatabaseTools.UpdateCoursePrferenceStatusTrue(coursename);
                    GenericHelper.Logs("As successful displayed for preference saved, PreferenceStatus as True updated for course" + coursename, "PASSED");
                }
                else
                {
                    DatabaseTools.UpdateCoursePrferenceStatusFalse(coursename);
                    GenericHelper.Logs("As successful not displayed for preference saved, PreferenceStatus as False updated for course" + coursename, "FAILED");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To Update the Publish Status of Course
        public static void SteptToUpdateThePublishStatusOfTheCourseInDB(string course)
        {
            try
            {
                string coursename = string.Empty;
                switch (course)
                {
                    case "BDDCC":
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.ContainerCourse);
                        break;
                    case "BDDEC":
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.EmptyCourse);
                        break;
                    case "BDDML":
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.MasterLibrary);
                        break;
                    case "Authored Master Library":
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.AuthoredMasterLibrary);
                        break;
                    case "AuthoredMasterCourse":
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.MySpanishLabMasterCourse);
                        break;
                }
                bool ismessagedisplayed = GenericHelper.VerifySuccesfullMessage("Course published successfully.");
                if (ismessagedisplayed == true)
                {
                    DatabaseTools.UpdateCoursePublishStatusTrue(coursename);
                    GenericHelper.Logs("As successful message displayed for course publish, publish status as 'True' updated for course" + coursename, "PASSED");
                }
                else
                {
                    DatabaseTools.UpdateCoursePublishStatusFalse(coursename);
                    GenericHelper.Logs("As successful message not displayed for course publish, publish status as 'False' updated for course" + coursename, "FAILED");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To Update the Publish Status of Course
        public static void StepToUpdateTheEnrollStatusOfTheUserInDB(string user)
        {
            try
            {
                string username = string.Empty;
                switch (user)
                {
                    case "CsTeacher":
                        username = DatabaseTools.GetUsername(Enumerations.UserType.CsTeacher);
                        break;
                    case "CsStudent":
                        username = DatabaseTools.GetUsername(Enumerations.UserType.CsStudent);
                        break;
                    case "WsTeacher":
                        username = DatabaseTools.GetUsername(Enumerations.UserType.WsTeacher);
                        break;
                }
                bool ismessagedisplayed = GenericHelper.VerifySuccesfullMessage("Users enrolled successfully.");
                if (ismessagedisplayed == true)
                {
                    DatabaseTools.UpdateUserEnrollStatusTrue(username);
                    GenericHelper.Logs("As successful message displayed for course publish, publish status as 'True' updated for course" + username, "PASSED");
                }
                else
                {
                    DatabaseTools.UpdateUserEnrollStatusFalse(username);
                    GenericHelper.Logs("As successful message not displayed for course publish, publish status as 'False' updated for course" + username, "FAILED");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To Select The Course From DB
        public static void StepToSelectTheCourse(string courseType)
        {
            try
            {
                switch (courseType)
                {
                    case "MySpanishLab AuthoredCourse":
                        string authoredMasterCourse = DatabaseTools.GetCourse(Enumerations.CourseType.MySpanishLabAuthoredCourse);
                        WsEnrollmentPage.CourseSearch(authoredMasterCourse);
                        break;
                    case "MySpanishLab Authored Master Course":
                        string masterCourse = DatabaseTools.GetCourse(Enumerations.CourseType.MySpanishLabMasterCourse);
                        WsEnrollmentPage.CourseSearch(masterCourse);
                        break;
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Click C-menu Option of the Course
        public static void StepToClickOnTheCmenuOfCourse()
        {
            try
            {
                WsEnrollmentPage.ClickCourseCmenu();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Click course name from the global home page
        public static void SteptoSelectTheCourseNameWithPrefix(String coursename)
        {
            try
            {
                GenericHelper.SelectWindow("Global Home");
                ObjUxPage.ToSelectMasterLibrary(coursename);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        //Purpose: Step To created the WS instructor
        public static void StepTocreatetheUser()
        {
            try
            {
                GenericHelper.SelectWindow("Course Enrollment");
                WebDriver.SwitchTo().Frame("ifrmleft");
                GenericHelper.WaitUntilElement(By.PartialLinkText("Create New User"));
                WebDriver.FindElement(By.PartialLinkText("Create New User")).Click();
                GenericStepDefinition.ThenIShouldSeeTheNewPopup("Create New User");
                Createuser.ToCreateWSuser("instructor");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Click on C-menu Option Link of the Course
        public static void StepToClickOnTheCourseCMenuOptionLink(string linktext)
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("grdCourse"));
                bool isCourseAlreadyPublished = GenericHelper.IsElementPresent(By.XPath("//table[@id='grdCourse']/tbody/tr/td[4]/img[contains(@src,'/images/SMSIntegration/ProgramManagement/icn_approvedStatus.gif')]"));
                if (isCourseAlreadyPublished)
                {
                    return;
                }
                GenericHelper.WaitUntilElement(By.PartialLinkText(linktext));
                IWebElement clickApproveLink = WebDriver.FindElement(By.PartialLinkText(linktext));
                new Actions(WebDriver).MoveToElement(clickApproveLink).Click(clickApproveLink).Perform();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Copy the Course To Same Workspace
        public static void StepToCopyTheCourseInSameWorkspace(string copyCourseName)
        {
            try
            {
                NewCoursePage.CopyCourse(copyCourseName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Wait for the Authored Course Out From [Assign To Copy] State
        public static void StepToWaitForTheCourseOutFromAssignToCopyState()
        {
            string mcName = DatabaseTools.GetCourse(Enumerations.CourseType.MySpanishLabMasterCourse);
            try
            {
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                WsEnrollmentPage.CourseSearch(mcName);
                WsEnrollmentPage.CheckAssignedToCopyState(mcName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Wait for the Authored Course Out From [Assign To Copy] State
        public static void StepToWaitForTheTestingCourseOutFromAssignToCopyState()
        {
            string tcName = DatabaseTools.GetCourse(Enumerations.CourseType.TestingCourse);
            try
            {
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                WsEnrollmentPage.CourseSearch(tcName);
                WsEnrollmentPage.CheckAssignedToCopyState(tcName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose : Step To Enter Publishing Notes
        public static void StepToEnterThePublishingNotes()
        {
            # region Handling Session Out Issue in Build
            bool isPegasuLoginWindowPresent = GenericHelper.IsPopUpWindowPresent("Pegasus Login");
            if (isPegasuLoginWindowPresent)
            {
                return;
            }
            #endregion Handling Session Out Issue in Build
            try
            {
                GenericHelper.WaitUntillWindowAndElement("Publishing Notes", By.Id("txtPublishNotes"));
                PublishingNotesPage.EnterPublishNotes();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Click on Pulish Button
        public static void StepToClickOnThePublishButton()
        {
            try
            {
                GenericHelper.SelectWindow("Publishing Notes");
                PublishingNotesPage.ClickPublishButton();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Navigate on 'Manage Products' Page
        public static void StepToItShouldShowTheManageProductsPage()
        {
            try
            {
                ManageProductsPage.NavigateToManageProductsPage();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Approve the Course
        public static void StepToSelectTheCourseToApprove(string courseType)
        {
            try
            {
                CoursesPage.SearchCourse(courseType);
                CoursesPage.ClickCmenu();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Create the HED Program
        public static void StepToCreateTheHedProgram()
        {
            try
            {
                ProgramCreatePage.CreateHEDProgram();
            }
            catch (Exception e)
            {

                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Navigate on 'Manage Programs' Page
        public static void StepToItShouldShowTheManageProgramsPage()
        {
            try
            {
                ProgramManagementPage.NavigatingToManageProgramsPage();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Click the Create New Program Link
        public static void StepToClickTheCreateNewProgramLink()
        {
            try
            {
                GenericHelper.SelectWindow("Manage Programs");

                ProgramManagementPage.ClickCreateNewProgramLink();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }

        }

        //Purpose: Step To Create Hed Program
        public static void StepToCreateHedProgram()
        {
            try
            {
                ProgramCreatePage.CreateHEDProgram();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Click the Create New Prodict Link
        public static void StepToClickTheCreateNewProductLink()
        {
            try
            {
                GenericHelper.SelectWindow("Manage Products");
                ManageProductsPage.ClickCreateNewProductLink();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }

        }

        //Purpose: Step To Create general type Product
        public static void StepToCreateHedGeneralTypeProduct(string productType)
        {
            try
            {
                if (productType == "HedCoreGeneral")
                    NewProductPage.CreateHedProduct(Enumerations.ProductInstance.HedCoreGeneral);
                if (productType == "HedCoreProgram")
                    NewProductPage.CreateHedProduct(Enumerations.ProductInstance.HedCoreProgram);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To select course in manage products page
        public static void StepToSelectCourseInManageProductsPage(string courseType)
        {
            try
            {
                CoursesPage.SearchCourse(courseType);
                CoursesPage.ClickSelectAllCheckBox();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Select the Product in the Right Frame
        public static void StepToSelectTheProductInTheRightFrame(string productInstance)
        {
            try
            {
                ProductSearchPage.SearchProductAndOpen(productInstance);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Add course to product
        public static void StepToAssociateTheCourseToProduct()
        {
            try
            {
                AddButtonPage.ClickAddButton();
                CourseEnrollmentModePage.ClickSaveButton();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Create Instructor Course from the Catalog
        public static void StepToCreateInstructorCourse()
        {
            try
            {
                HEDGlobalHomePage.ToCreateCatalogCourse("MasterCourse");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Get the Course ID from the Global Home Page
        public static void StepToEnrollStudentToInstructorCourse()
        {
            try
            {
                HEDGlobalHomePage.ToGetInstructorCourseID();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Get the Course ID from the Global Home Page
        public static void StepToEnrollStudenttoCourseId()
        {
            try
            {
                HEDGlobalHomePage.ToEnrolTheStudentToCourseID();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: To Create Program Course From the Catalog
        public static void StepToCreateProgramCourse()
        {
            try
            {
                HEDGlobalHomePage.ToCreateCatalogCourse("ProductTypeProg");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose:Step To Click the I Accept Button
        public static void StepToClickedTheIAcceptButton()
        {
            try
            {
                RegisterPage.ToClickIAcceptButton();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose:Step To Create New SMS User(s)
        public static void StepToCreateNewSmsUser(string userType)
        {
            try
            {
                RegisterPage.ToCreateSmsUser(userType);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose:Step To Verify Feedback Preference
        public static void StepToverifyFeedbackPrefernce()
        {
            try
            {
                Feedback.ToSelectActivitiesSubtab();
                Feedback.ToVerifyFeedbackPreference();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose:Step To Enrol User In Copy Testing Course
        public static void StepToEnrolUserInTestingCopyCourse()
        {
            try
            {
                string username = DatabaseTools.GetUsername(Enumerations.UserType.HedWsInstructor);
                WSEnrollmentpage.SelectCourse("Testing");
                WSEnrollmentpage.SelectUser(username);
                WSEnrollmentpage.EnrollUserAsTeacher();
                DatabaseTools.UpdateUserEnrollStatusTrue(username);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Enrol Student To Instructor Course
        public static void StepToEnrolStudentToCourse(string courseType)
        {
            try
            {
                HEDGlobalHomePage.ToEnrolTheStudentToCourse(courseType);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To select the section name from global home page
        public static void StepToSelectTheSectionName()
        {
            try
            {
                HEDGlobalHomePage.ToSelectSectionName();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Close Student Help Text Window in HED
        public static void StepToCloseStudentHelpTextWindow()
        {
            try
            {
                bool isStudentHelpTextWindowClose = GenericHelper.CloseStudentHelpTextWindow();
                if (isStudentHelpTextWindowClose)
                {
                    GenericHelper.Logs("'Student Help Text' window closed successfully.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("'Student Help Text' window not closed successfully.", "FAILED");
                    Assert.Fail("'Student Help Text' window not closed successfully.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                bool isStudentHelpTextWindowPresent = GenericHelper.IsPopUpWindowPresent("Student Help Text");
                if (isStudentHelpTextWindowPresent)
                {
                    GenericHelper.SelectWindow("Student Help Text");
                    WebDriver.Close();
                }
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step To Navigate into Activity Folder
        public static void StepToNavigateInTheEssayTypeActivityFolder()
        {
            GenericHelper.SelectWindow("Course Materials");
            WebDriver.SwitchTo().Frame("ifrmCoursePreview");
            StepToClickOnTheLink("Capítulo Preliminar 0A: Para empezar");
            StepToClickOnTheLink("STUDENT ACTIVITIES MANUAL");
        }

        //Purpose: Step To Submit Essay Type Activity By Student
        public static void StepToSubmitEssayTypeActivitybyStudent(string activityName)
        {
            WebDriver.SwitchTo().DefaultContent();
            bool isTestPresentationWindowPresent = GenericHelper.IsPopUpWindowPresent("Test Presentation");
            if (isTestPresentationWindowPresent)
            {
                GenericHelper.SelectWindow("Test Presentation");
                bool isErrorMessagePresent = GenericHelper.IsElementPresent(By.Id("lblErrorMessage"));
                if (isErrorMessagePresent)
                {
                    GenericHelper.Logs("Problem opening the activity. Please close the window and try to open the activity again.", "FAILED");
                    Assert.Fail("Problem opening the activity. Please close the window and try to open the activity again.");
                }
            }
            GenericHelper.SelectWindow("SAM Activity");
            WebDriver.Manage().Window.Maximize();
            for (int i = 1; i <= 8; i++)
            {
                GenericHelper.WaitUntilElement(By.XPath("//div[@id = 'nextQuextion']/div[" + i + "]/table/tbody/tr[2]/td/div/table/tbody/tr/td[2]/table/tbody/tr[2]/td/table/tbody/tr/td/textarea"));
                WebDriver.FindElement(By.XPath("//div[@id = 'nextQuextion']/div[" + i + "]/table/tbody/tr[2]/td/div/table/tbody/tr/td[2]/table/tbody/tr[2]/td/table/tbody/tr/td/textarea")).SendKeys("Lorem Ipsum is simply dummy text");
            }
            GenericHelper.WaitUntilElement(By.Id("btnSubmit1"));
            WebDriver.FindElement(By.Id("btnSubmit1")).Click();
            GenericHelper.WaitUntilElement(By.Id("_ctl0:APH:btnfinish"));
            WebDriver.FindElement(By.Id("_ctl0:APH:btnfinish")).Click();
            GenericHelper.WaitUntilElement(By.Id("_ctl0:btnReturnCourse"));
            WebDriver.FindElement(By.Id("_ctl0:btnReturnCourse")).Click();
            bool isActivitySubmitted = GenericHelper.IsPopUpClosed(2);
            if (isActivitySubmitted)
            {
                GenericHelper.Logs("Essay type activity has submitted successfully by the student.", "PASSED");
                DatabaseTools.UpdateSubmissionStatusOfActivity(activityName);
            }
            else
            {
                GenericHelper.Logs("Essay type activity has not submitted successfully by the student.", "FAILED");
                Assert.Fail("Essay type activity has not submitted successfully by the student.");
            }
        }

        //Purpose: Step To Verify Successful Message for Edit Study Plan
        public static void StepToVerifySuccessfulMessageForEditStudyPlan(string sucessMessage)
        {
            bool isSuccessMessageDisplayed = GenericHelper.VerifySuccesfullMessage(sucessMessage);
            if (isSuccessMessageDisplayed)
            {
                GenericHelper.Logs("No Exception thrown in the log files (Exception: INSERT statement conflicted with the FOREIGN KEY constraint 'FK_tblAssetLinks_tblAssetsLeft'. The conflict occurred in database 'Pegasus11_A', table 'PegTables.tblAssets', column 'AssetID'.", "PASSED");
            }
            else
            {
                GenericHelper.Logs("Exception thrown in the log files (Exception: INSERT statement conflicted with the FOREIGN KEY constraint 'FK_tblAssetLinks_tblAssetsLeft'. The conflict occurred in database 'Pegasus11_A', table 'PegTables.tblAssets', column 'AssetID'.", "FAILED");
                Assert.Fail("Exception thrown in the log files (Exception: INSERT statement conflicted with the FOREIGN KEY constraint 'FK_tblAssetLinks_tblAssetsLeft'. The conflict occurred in database 'Pegasus11_A', table 'PegTables.tblAssets', column 'AssetID'.");
            }
        }

        //Purpose: Step To  Add The Activity To MyCourse
        public static void StepToAddTheActivityToMyCourse(string actName)
        {

            ContentLibraryUxPage.SelectAsset(actName);
            GenericHelper.SelectDefaultWindow();
            TeachingplanUxPage.ClickAddButton();

        }

        //Purpose: Step To select the course from Globalhome page
        public static void StepToselectthecoursefromGlobalhomepage()
        {
            bool announcementClose = GenericHelper.CloseAnnouncementPage();
            if (announcementClose)
            {
                GenericHelper.Logs("Annoucement page has been closed successfully", "Passed");
            }
            else
            {
                GenericHelper.Logs("Annoucement page is still not closed", "Failed");
            }
            string courseName = DatabaseTools.GetCourse(Enumerations.CourseType.InstructorCourse).Trim();
            GenericHelper.WaitUntilElement(By.PartialLinkText(courseName));
            WebDriver.FindElement(By.PartialLinkText(courseName)).SendKeys("");
            WebDriver.FindElement(By.PartialLinkText(courseName)).Click();

        }
    }
}
