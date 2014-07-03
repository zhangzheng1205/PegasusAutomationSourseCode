using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using OpenQA.Selenium.Interactions;
using Framework.Common;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using System.Linq;
namespace Pegasus.AdminToolPage
{
    public class AdminToolPage : BasePage
    {
        //Purpose: Calling Method From Page Class
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        static int? _isCoursePresent = null;

        #region locators
        // Purpose: Locator Property Defined
        public string ImageCourseSearch
        {
            get { return "//img[contains(@src,'/images/btn_search.gif')]"; }
        }

        // Purpose: Locator Property Defined
        public string ImageContextmenu
        {
            get { return "//img[contains(@src,'/images/admin/icn_contextual.gif')]"; }
        }

        // Purpose: Locator Property Defined
        private string Text_Username
        {
            get
            {
                return "//TABLE[@id='grdUser']/tbody/tr/td[3]/span";
            }
        }
        // Purpose: Locator Property Defined
        private string Text_AssignedToCopy
        {
            get { return "//table[@id='grdCourse']/tbody/tr/td[3]/font"; }
        }
        // Purpose: Locator Property Defined
        private string ImageCourseCmenu
        {
            get { return "//table[@id='grdCourse']/tbody/tr/td[8]/center/a/img[contains(@src,'/images/admin/icn_contextual.gif')]"; }
        }
        # endregion

        //Purpose: Method To Search Course in WS
        public void CourseSearch(string coursename)
        {
            try
            {
                if (WebDriver.FindElement(By.Id("ancRightSearch")).Displayed)
                {
                    WebDriver.FindElement(By.Id("ancRightSearch")).Click();
                }
                GenericHelper.WaitUntilElement(By.Id("ifrmright"));
                WebDriver.SwitchTo().Frame("ifrmright");
                GenericHelper.WaitUntilElement(By.Id("txtCourseDetail"));
                Thread.Sleep(5000);//I added because to wait for the serch panel display.
                if (WebDriver.FindElement(By.Id("txtCourseDetail")).Displayed)
                {
                    WebDriver.FindElement(By.Id("txtCourseDetail")).SendKeys(coursename);
                }
                else
                {
                    GenericHelper.Logs("Course detail text box is not displayed", "Failed");
                }
                GenericHelper.WaitUntilElement(By.XPath(ImageCourseSearch));
                WebDriver.FindElement(By.XPath(ImageCourseSearch)).Click();
                GenericHelper.WaitUntilElement(By.XPath(ImageContextmenu));
                // Purpose: Verify the Course in Right Frame after Search Action
                if (Browser.Equals("FF") || Browser.Equals("GC"))
                {
                    GenericHelper.WaitUntilElement(By.Id("grdCourse"));
                    string getPresentCourseinFF = WebDriver.FindElement(By.Id("grdCourse")).Text;
                    _isCoursePresent = getPresentCourseinFF.IndexOf(coursename, System.StringComparison.Ordinal);
                }
                if (Browser.Equals("IE"))
                {
                    GenericHelper.WaitUntilElement(By.Id("grdCourse"));
                    string getPresentCourse = WebDriver.FindElement(By.Id("grdCourse")).GetAttribute("innerText");
                    _isCoursePresent = getPresentCourse.IndexOf(coursename, System.StringComparison.Ordinal);
                }
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                Thread.Sleep(3000);
                if (_isCoursePresent < 0)
                {
                    GenericHelper.Logs("Course not displayed in Frame: " + coursename, "FAILED");
                    Assert.Fail("Course not displayed in Frame: " + coursename);
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Method To Search User in WS
        public void UserSearch(string username)
        {
            if (WebDriver.FindElement(By.Id("ancLeftSearch")).Displayed)
                WebDriver.FindElement(By.Id("ancLeftSearch")).Click();
            WebDriver.SwitchTo().Frame("ifrmleft");
            GenericHelper.WaitUntilElement(By.Id("txtUserDetail"));
            WebDriver.FindElement(By.Id("txtUserDetail")).SendKeys(username);
            GenericHelper.WaitUntilElement(By.XPath(ImageCourseSearch));
            WebDriver.FindElement(By.XPath(ImageCourseSearch)).Click();
            // Purpose: Verify the User in Left Frame after Search Action
            string getUserName = WebDriver.FindElement(By.XPath(Text_Username)).GetAttribute("title");
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            if (username.Contains(getUserName))
            {
                GenericHelper.Logs(string.Format("User '{0}' displayed in the Frame after do Search.", username), "PASSED");
            }
            else
            {
                GenericHelper.Logs(string.Format("User '{0}' not displayed in the Frame after do Search.", username), "FAILED");
                Assert.Fail(string.Format("User '{0}' not displayed in the Frame after do Search.", username));
            }
        }

        //Purpose: Method To get username from DB for the usertype
        public string GetWsUserNameDb(string usertype)
        {
            string username = string.Empty;

            switch (usertype)
            {
                case "Teacher":
                    // user will be fetched fm db
                    username = DatabaseTools.GetUsername(Enumerations.UserType.WsTeacher);
                    break;
                case "Student":
                    // user will be fetched fm db
                    username = DatabaseTools.GetUsername(Enumerations.UserType.WsStudent);
                    break;
            }
            return username;
        }

        //Purpose : To check for Assigned To Copy State
        public void CheckAssignedToCopyState(string copyCourseName)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
            while (sw.Elapsed.TotalMinutes < minutesToWait)
            {
                GenericHelper.WaitUntilElement(By.Id("ifrmright"));
                WebDriver.SwitchTo().Frame("ifrmright");
                if (GenericHelper.IsElementPresent(By.XPath(Text_AssignedToCopy)) == false) break;
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                //Purpose: Calling Method For Course Search
                CourseSearch(copyCourseName);
                Thread.Sleep(15000);
            }
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            GenericHelper.WaitUntilElement(By.Id("ifrmright"));
            WebDriver.SwitchTo().Frame("ifrmright");
            if (GenericHelper.IsElementPresent(By.XPath(Text_AssignedToCopy)))
            {
                GenericHelper.Logs(string.Format("[AssignedToCopy] State for Copied Course not approved under TimeInterval '{0}' minutes", sw.Elapsed.TotalMinutes), "FAILED");
                Assert.Fail(string.Format("[AssignedToCopy] State for Copied Course not approved under TimeInterval '{0}' minutes", sw.Elapsed.TotalMinutes));
            }
            else
            {
                GenericHelper.Logs(string.Format("[AssignedToCopy] State for Copied Course approved under TimeInterval '{0}' minutes(s)", sw.Elapsed.TotalMinutes), "PASSED");
            }
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
        }

         //Purpose : To verify for Assigned To Copy State
        public void verifyAssignedToCopyState(string copyCourseName)
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());

            CourseSearch(copyCourseName);
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            GenericHelper.WaitUntilElement(By.Id("ifrmright"));
            WebDriver.SwitchTo().Frame("ifrmright");
            if (GenericHelper.IsElementPresent(By.XPath(Text_AssignedToCopy)))
            {
                GenericHelper.Logs("[AssignedToCopy] State for Copied Course  exists" , "FAILED");
                Assert.Fail("[AssignedToCopy] State for Copied Course  exists");
            }
            else
            {
                GenericHelper.Logs("[AssignedToCopy] State for Copied Course not exists", "PASSED");
            }
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
        }

        //Purpose: To search and open the course
        public void SelectCourse(string courseType)
        {
            switch (courseType)
            {
                case "AuthoredMasterLibrary":
                    string masterLibrary = DatabaseTools.GetCourse(Enumerations.CourseType.AuthoredMasterLibrary);
                    CourseSearch(masterLibrary);
                    GenericHelper.WaitUntilElement(By.Id("ifrmright"));
                    WebDriver.SwitchTo().Frame("ifrmright");
                    IWebElement masterLibraryCourse = WebDriver.FindElement(By.LinkText(masterLibrary));
                    new Actions(WebDriver).Click(masterLibraryCourse).Perform();
                    break;
                case "Container":
                    string container = DatabaseTools.GetCourse(Enumerations.CourseType.ContainerCourse);
                    CourseSearch(container);
                    GenericHelper.WaitUntilElement(By.Id("ifrmright"));
                    WebDriver.SwitchTo().Frame("ifrmright");
                    IWebElement containerCourse = WebDriver.FindElement(By.LinkText(container));
                    new Actions(WebDriver).Click(containerCourse).Perform();
                    break;
                case "Empty":
                    string emptyClass = DatabaseTools.GetCourse(Enumerations.CourseType.EmptyCourse);
                    CourseSearch(emptyClass);
                    GenericHelper.WaitUntilElement(By.Id("ifrmright"));
                    WebDriver.SwitchTo().Frame("ifrmright");
                    IWebElement emptyCourse = WebDriver.FindElement(By.LinkText(emptyClass));
                    new Actions(WebDriver).Click(emptyCourse).Perform();
                    break;
                case "Testing":
                    string testingCourse = DatabaseTools.GetCourse(Enumerations.CourseType.TestingCourse);
                    //CourseSearch(testingCourse);
                    GenericHelper.WaitUntilElement(By.Id("ifrmright"));
                    WebDriver.SwitchTo().Frame("ifrmright");
                    IWebElement testingCourseName = WebDriver.FindElement(By.LinkText(testingCourse));
                    testingCourseName.Click();
                    break;
            }
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());

        }

        //Purpose: To search and select the user
        public void SelectUser(string username)
        {
            UserSearch(username);
            GenericHelper.WaitUntilElement(By.Id("ifrmleft"));
            WebDriver.SwitchTo().Frame("ifrmleft");
            GenericHelper.WaitUntilElement(By.Id("grdUser$_ctrl0"));
            GenericHelper.WaitUntilElement(By.Id("grdUser$_ctrl1"));
            Thread.Sleep(3000);
            WebDriver.FindElement(By.Id("grdUser$_ctrl1")).Click();
            GenericHelper.WaitUntilElement(By.Id("lnkDeleteUser"));
            IWebElement isLinkEnabled = WebDriver.FindElement(By.Id("lnkDeleteUser"));
            if (!isLinkEnabled.Enabled)
            {
                GenericHelper.Logs("User not selected to enroll into the course", "FAILED");
                Assert.Fail("User not selected to enroll into the course");
            }
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
        }

        //Purpose: To enrolled the user as Teacher to Course
        public void EnrollUserAsTeacher()
        {
            GenericHelper.WaitUntilElement(By.Id("ifrmMiddle"));
            WebDriver.SwitchTo().Frame("ifrmMiddle");
            WebDriver.FindElement(By.Id("btnEnroll")).Click();
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            GenericHelper.WaitUntilElement(By.Id("tdInst"));
            WebDriver.FindElement(By.Id("tdInst")).Click();
        }

        //Purpose: To verify enrolled is user present with role name
        public void VerifyEnrolledUser()
        {
            WebDriver.SwitchTo().Frame("ifrmright");
            string username = DatabaseTools.GetUsername(Enumerations.UserType.WsTeacher);
            string enrolledUser = string.Empty;
            int rownum = 0;
            for (int i = 1; i <= 30; i++)
            {
                enrolledUser = WebDriver.FindElement(By.XPath("//TABLE[@id='dgUserEnrollList']/tbody/tr[" + i.ToString(CultureInfo.InvariantCulture) + "]/td[2]/span")).GetAttribute("title");
                rownum = rownum + 1;
                if (username == enrolledUser)
                    break;
            }

            if (username == enrolledUser)
                GenericHelper.Logs("Enrolled user displayed inside the course", "PASSED");
            else
                GenericHelper.Logs("Enrolled user not displayed inside the course", "FAILED");

            if (Browser.Equals("FF") || Browser.Equals("GC"))
            {
                string userRole = WebDriver.FindElement(By.XPath("//TABLE[@id='dgUserEnrollList']/tbody/tr[" + rownum.ToString(CultureInfo.InvariantCulture) + "]/td[3]")).Text;
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                if (userRole == "Teacher")
                    GenericHelper.Logs("User Enrolled as Teacher to course", "PASSED");
                else
                    GenericHelper.Logs("User not Enrolled as Teacher to course", "FAILED");
            }

            if (Browser.Equals("IE"))
            {
                string userRole =
                    WebDriver.FindElement(
                        By.XPath("//TABLE[@id='dgUserEnrollList']/tbody/tr[" +
                                 rownum.ToString(CultureInfo.InvariantCulture) + "]/td[3]")).GetAttribute("innerText");
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                if (userRole == "Teacher")
                    GenericHelper.Logs("User Enrolled as Teacher to course", "PASSED");
                else
                    GenericHelper.Logs("User not Enrolled as Teacher to course", "FAILED");
            }
        }

        //Purpose: To click course cmenu
        public void ClickCourseCmenu()
        {
            GenericHelper.WaitUntilElement(By.Id("ifrmright"));
            WebDriver.SwitchTo().Frame("ifrmright");
            GenericHelper.WaitUntilElement(By.XPath(ImageCourseCmenu));
            IWebElement imageCourseCmenu = WebDriver.FindElement(By.XPath(ImageCourseCmenu));
            imageCourseCmenu.SendKeys("");
            new Actions(WebDriver).Click(imageCourseCmenu).Perform();
        }

        //Purpose: To check Assign To Copy Status is present or not
        public void IsAssignToCopyStatusPresent()
        {
            WebDriver.SwitchTo().Frame("ifrmright");
            if (GenericHelper.IsElementPresent(By.XPath(Text_AssignedToCopy)))
            {
                GenericHelper.Logs(string.Format("[AssignedToCopy] State still remains for ML/MC"), "FAILED");
                Assert.Fail(string.Format("[AssignedToCopy] State still remains for ML/MC and can not be published"));
            }
            else
            {
                GenericHelper.Logs(string.Format("[AssignedToCopy] State is not present for ML/MC"), "PASSED");
            }
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
        }
    }
}
