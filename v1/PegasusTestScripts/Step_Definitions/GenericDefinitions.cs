using System;
using System.Configuration;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using Pegasus.LoginPage;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System.Threading;
using System.Linq;
using Framework.Common;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class GenericDefinitions : BaseTestScript
    {
        //Purpose: Constant Declaration
        public IWebDriver Webd;
        private static readonly LoginPage LoginPage = new LoginPage();
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        // Purpose : Step to Browse Url  for Pegasus User(s)     
        [Given("I have browsed url for \"(.*)\"")]
        [Then("I have browsed url for \"(.*)\"")]
        public static void GivenIHaveBrowsedUrlForWsAdmin(string usertype)
        {

            try
            {
                string browserName = null;
                switch (usertype)
                {
                    // *****PEGASUS USER LOGIN MANAGEMENT******//

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
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To Login as WS Teacher
        [When(@"I have logged into the work space as WS Teacher")]
        public static void WhenIHaveLoggedIntoTheWorkspaceAsWsTeacher()
        {
            try
            {
                string url = WebDriver.Url;
                if (url.Contains("ws") && GenericHelper.IsElementPresent(By.ClassName("ancCourseNameStuViewCls")))
                {
                    ThenIselectHomeButton();
                }
                else if (url.Contains("ws") && WebDriver.Title.ToString(CultureInfo.InvariantCulture) == "Global Home")
                {

                }
                else
                {
                    string wsUserDb = DatabaseTools.GetUsername(Enumerations.UserType.WsTeacher);
                    if (wsUserDb == null) throw new ArgumentNullException("wsUserDb is NULL, Us" + "er not fulfilling his login criteria.");
                    string wsPwdDb = DatabaseTools.GetPassword(Enumerations.UserType.WsTeacher);
                    if (wsPwdDb == null) throw new ArgumentNullException("wsPwdDb is NULL, Us" + "er not fulfilling his login criteria.");
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

        //Purpose: Step To Login as WS Admin
        [When(@"I have logged into the work space as WSAdmin")]
        public static void WhenIHaveLoggedIntoTheWorkspaceAsWsAdmin()
        {
            try
            {
                string browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                if (browserName != "Course Enrollment")
                {
                    string wsAdminUserDb = DatabaseTools.GetUsername(Enumerations.UserType.WsAdmin);
                    if (wsAdminUserDb == null) throw new ArgumentNullException("wsAdminUserDb is NULL, Us" + "er not fullfilling his login criteria.");
                    string wsAdminPwdDb = DatabaseTools.GetPassword(Enumerations.UserType.WsAdmin);
                    if (wsAdminPwdDb == null) throw new ArgumentNullException("wsAdminPwdDb is NULL, Us" + "er not fullfilling his login criteria.");
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

        //Purpose: Step To Login as CS Admin
        [Given(@"I have logged into the Course space as CSAdmin")]
        [When(@"I have logged into the Course space as CSAdmin")]
        public void WhenIHaveLoggedIntoTheCourseSpaceAsCSAdmin()
        {
            try
            {
                GenericHelper.SelectDefaultWindow();
                if (!GenericHelper.IsElementPresent(By.PartialLinkText("PKT Integration")))
                {
                    string wsAdminUserDb = DatabaseTools.GetUsername(Enumerations.UserType.CsAdmin);
                    if (wsAdminUserDb == null) throw new ArgumentNullException("wsAdminUserDb is NULL, Us" + "er not fullfilling his login criteria.");
                    string wsAdminPwdDb = DatabaseTools.GetPassword(Enumerations.UserType.CsAdmin);
                    if (wsAdminPwdDb == null) throw new ArgumentNullException("wsAdminPwdDb is NULL, Us" + "er not fullfilling his login criteria.");
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

        // Purpose : Step To Verify Page is Opened 
        [Given("Im on the \"(.*)\" page")]
        [Then("It should show the \"(.*)\" page")]
        [Then("It should be on \"(.*)\" page")]
        public static void ThenItShouldBeOnPage(string pageName)
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
                ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step To Verify Page Name   
        [Then("I should see the \"(.*)\" popup")]
        public static void ThenIShouldSeeTheNewPopup(string pageName)
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

        // Purpose : Step To Verify Success Message 
        [Then("It should display successful message \"(.*)\"")]
        public static void ThenItShouldDisplaySuccessfulMessage(string successMsg)
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
                    GenericHelper.Logs(successMsg + " :successful message displayed.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs(successMsg + " :successful message not displayed.", "FAILED");
                    Assert.Fail(successMsg + " :successful message not displayed.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        [Then("It should display successful message \"(.*)\" in \"(.*)\" page")]
        public void ThenItShouldDisplaySuccessfulMessageInPage(string successMsg, string page)
        {
            try
            {
                GenericHelper.SelectWindow(page);
                bool ismessagedisplayed = GenericHelper.VerifySuccesfullMessage(successMsg);
                if (ismessagedisplayed)
                {
                    GenericHelper.Logs(successMsg + " : successful message displayed.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs(successMsg + " : successful message not displayed.", "FAILED");
                    Assert.Fail(successMsg + ": successful message not displayed.");
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
                ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step To Click on Logout Link From Ws
        [Then(@"I clicked on the Logout link to get logged out from the application")]
        public static void ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication()
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
                        Assert.Fail("Logout from the application unsuccessfull.");
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step To Click on Logout Link From Ws
        [When(@"I clicked on the Logout link to get logged out from the application")]
        public static void ClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication()
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
                        Assert.Fail("Logout from the application unsuccessfull.");
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Step to Select the specified tab or subtab
        [Given("I selected the \"(.*)\" sub tab")]
        [When("I selected the \"(.*)\" sub tab")]
        [Then("I selected the \"(.*)\" sub tab")]
        [Given("I navigate to the \"(.*)\" Tab")]
        [Then("I navigate to the \"(.*)\" Tab")]
        [When("I navigate to the \"(.*)\" Tab")]
        public static void GivenINavigateToTheTab(string tab)
        {
            try
            {
                GenericHelper.WaitUntilElement(By.PartialLinkText(tab));
                WebDriver.FindElement(By.PartialLinkText(tab)).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Step to Select the specified tab or subtab
        [When("I select the \"(.*)\" sub tab")]
        [When("I navigate to the \"(.*)\" tab")]
        [Then("I navigate to the \"(.*)\" tab")]
        public static void NavigateToTheTab(string tab)
        {
            try
            {
                GenericHelper.WaitUntilElement(By.PartialLinkText(tab));
                WebDriver.FindElement(By.PartialLinkText(tab)).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Step to Select the course in globalhome of workspace
        [Given("I select the created \"(.*)\"")]
        public static void WhenISelectTheCreatedCourse(string course)
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

        //Purpose : Step To Click on a particular link
        [Then("I Click on the \"(.*)\" link")]
        public static void ThenIClickOnTheLink(String linkName)
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

        //Purpose : Verify ST Environment Working Fine
        [Then(@"I should be able to access (.*) pages")]
        [Then("I should be able to access \"(.*)\" pages")]
        public static void SetupSTEnvironment(string sTurl)
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

        // Purpose : Step to verify the page name
        [Given("I am on the \"(.*)\" page")]
        public static void GivenIAmOnThePage(string pageName)
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
                ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To verify UserCreation/Course creation page is present
        [Given(@"I am on the Course Creation page")]
        [Given(@"I am on the User Creation Page")]
        public static void GivenIAmOnTheUserCreationPage()
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
        [Given("I clicked on the \"(.*)\" link in \"(.*)\" frame")]
        public static void WhenIClickedOnTheCreateNewLink(string linkName, string frame)
        {
            try
            {

                WebDriver.SwitchTo().Frame("ifrm" + frame + "");
                GenericHelper.WaitUntilElement(By.PartialLinkText(linkName));
                WebDriver.FindElement(By.PartialLinkText(linkName)).Click();
                Thread.Sleep(2000);
                WebDriver.SwitchTo().Window("");
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : To Select Home Button
        [When(@"I select the Home button to go back on Global Home page")]
        public static void WhenIselectHomeButton()
        {
            try
            {
                Thread.Sleep(1000);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:_ctl0:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:_ctl0:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : To Select Global Home Button
        [Then(@"I select the Home button to go back on Global Home page")]
        public static void ThenIselectHomeButton()
        {
            try
            {
                Thread.Sleep(1000);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:_ctl0:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:_ctl0:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To click on specified link
        [Then("I clicked on the \"(.*)\" link")]
        [Given("I clicked on the \"(.*)\" link")]
        public void WhenIClickedOnTheApproveCourseLink(string linktext)
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

        //Purpose: To Click on the search/view button
        [When("I clicked on the Search/View button in \"(.*)\" frame")]
        public void ClickedOnSearchViewButton(string frameId)
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

        //Purpose: To search any level organization from the Organization tab
        [When("I search the \"(.*)\" level organization")]
        public void IsearchTheOrganization(string levelName)
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
                ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To close the Manage Organization Window and log out from the application
        [Then(@"I close the Manage Organization Window and log out from the application")]
        [When(@"I close the Manage Organization Window and log out from the application")]
        public static void WhenIClosetheManageOrganizationAndLogOutFromTheApplication()
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

        //Purpose: To login as CS student
        [When(@"I have logged into the course space as CS Student")]
        public void WhenIHaveLoggedIntoTheCourseSpaceAsCSStudent()
        {
            try
            {
                string browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                if (browserName != "Global Home")
                {
                    GenericHelper.SelectDefaultWindow();
                    WebDriver.Manage().Cookies.DeleteAllCookies();
                    string csUserUNDb = DatabaseTools.GetEnrolledUserLoginName(Enumerations.UserType.CsStudent);
                    if (csUserUNDb == null) throw new ArgumentNullException("csUserUNDb is NULL, Us" + "er not fullfilling his login criteria.");
                    string csUserPwdDb = DatabaseTools.GetEnrolledUserPassword(Enumerations.UserType.CsStudent);
                    if (csUserPwdDb == null) throw new ArgumentNullException("csUserPwdDb is NULL, Us" + "er not fullfilling his login criteria.");
                    if (GenericHelper.IsElementPresent(By.Id("_ctl6_PegasushelloK5_lblWelcomeText")))
                    {
                        if (Browser.Equals("IE"))
                        {
                            if (
                                !WebDriver.FindElement(By.Id("_ctl6_PegasushelloK5_lblWelcomeText")).GetAttribute("innerText").Contains("Welcome " + csUserUNDb))
                            {
                                WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsTeacher));
                                LoginPage.Login(csUserUNDb, csUserPwdDb, "coursespace", "CSStudent");
                                Thread.Sleep(60000);//This I have added To Avoid HTTP Connection Break Due To Slow Loading
                            }
                        }
                        if (Browser.Equals("FF") || Browser.Equals("GC"))
                        {
                            if (
                                   !WebDriver.FindElement(By.Id("_ctl6_PegasushelloK5_lblWelcomeText")).Text.Contains("Welcome " + csUserUNDb))
                            {
                                WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsTeacher));
                                LoginPage.Login(csUserUNDb, csUserPwdDb, "coursespace", "CSStudent");
                                Thread.Sleep(60000);//This I have added To Avoid HTTP Connection Break Due To Slow Loading
                            }
                        }
                    }
                    else
                    {
                        WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.CsTeacher));
                        LoginPage.Login(csUserUNDb, csUserPwdDb, "coursespace", "CSStudent");
                        Thread.Sleep(60000);//This I have added To Avoid HTTP Connection Break Due To Slow Loading
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To login as CS Teacher
        [When(@"I have logged into the course space as CS Teacher")]
        public void WhenIHaveLoggedIntoTheCourseSpaceAsCSTeacher()
        {
            try
            {
                string browserName = WebDriver.Title.ToString(CultureInfo.InvariantCulture);
                if (browserName != "Global Home")
                {
                    GenericHelper.SelectDefaultWindow();
                    Thread.Sleep(1000);
                    string csUserUNDb = DatabaseTools.GetEnrolledUserLoginName(Enumerations.UserType.CsTeacher);
                    if (csUserUNDb == null) throw new ArgumentNullException("csUserUNDb is NULL, Us" + "er not fullfilling his login criteria.");
                    string csUserPwdDb = DatabaseTools.GetEnrolledUserPassword(Enumerations.UserType.CsTeacher);
                    if (csUserPwdDb == null) throw new ArgumentNullException("csUserPwdDb is NULL, Us" + "er not fullfilling his login criteria.");
                    if (GenericHelper.IsElementPresent(By.Id("_ctl7_GlobalHomeToolBarUC_lblWelcomeText1")))
                    {
                        if (Browser.Equals("FF") || Browser.Equals("GC"))
                        {
                            if (!WebDriver.FindElement(By.Id("_ctl7_GlobalHomeToolBarUC_lblWelcomeText1")).Text.Contains("Welcome " + csUserUNDb))
                            {
                                LoginPage.Login(csUserUNDb, csUserPwdDb, "coursespace", "CSTeacher");
                                Thread.Sleep(60000);//This I have added To Avoid HTTP Connection Break Due To Slow Loading
                            }
                        }
                        if (Browser.Equals("IE"))
                        {
                            if (!WebDriver.FindElement(By.Id("_ctl7_GlobalHomeToolBarUC_lblWelcomeText1")).GetAttribute("innerText").Contains("Welcome " + csUserUNDb))
                            {
                                LoginPage.Login(csUserUNDb, csUserPwdDb, "coursespace", "CSTeacher");
                                Thread.Sleep(60000);//This I have added To Avoid HTTP Connection Break Due To Slow Loading
                            }
                        }
                    }
                    else
                    {
                        LoginPage.Login(csUserUNDb, csUserPwdDb, "coursespace", "CSTeacher");
                        Thread.Sleep(60000);//This I have added To Avoid HTTP Connection Break Due To Slow Loading
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To update the preference status of course
        [Then(@"Update the preference status in DB for (.*)")]
        public void ThenUpdateThePreferenceStatusInDBForBDDCC(string course)
        {
            try
            {
                string coursename = string.Empty;
                bool ismessagedisplayed = false;
                switch (course)
                {
                    case "BDDCC":
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.ContainerCourse);
                        ismessagedisplayed = GenericHelper.VerifySuccesfullMessage("Preferences updated successfully.");
                        break;
                    case "BDDEC":
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.EmptyCourse);
                        ismessagedisplayed = GenericHelper.VerifySuccesfullMessage("Preferences updated successfully.");
                        break;
                }
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

        //Purpose: To update the Publish status of course
        [Then(@"I Update the publish status in DB for (.*)")]
        public void ThenUpdateThePublishStatusOfTheCourseInDB(string course)
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

        //Purpose: To update the Publish status of course
        [Then("I Update the Enroll status in DB for \"(.*)\" Enrollment")]
        public void ThenUpdateTheEnrollStatusOfTheUserInDB(string user)
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
                    GenericHelper.Logs("As successful message has displayed for course enrollment in class, enroll status as 'True' updated for course" + username, "PASSED");
                }
                else
                {
                    DatabaseTools.UpdateUserEnrollStatusFalse(username);
                    GenericHelper.Logs(string.Format("As successful message has not displayed for course enrollment in class, enroll status as 'False' updated for course" + username), "FAILED");
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