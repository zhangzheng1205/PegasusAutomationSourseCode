using System;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.CourseCatalog;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.ProgramAdmin;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.ProgramAdmin.CourseTemplates;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.CatalogInstructor
{
    public class HEDGlobalHomePage : BasePage
    {
        private string _enrolledCourseId;
        /// <summary>
        /// Purpose: Get SMS User from DB
        /// </summary>
        private readonly string _getSMSInstructor = DatabaseTools.GetUsername(Enumerations.UserType.CsSmsInstructor);
        private readonly string _getEnrolInstructorCourseID = DatabaseTools.GetEnrolCourseID(Enumerations.CourseType.InstructorCourse);
        private readonly string _getSMSStudent = DatabaseTools.GetUsername(Enumerations.UserType.CsSmsStudent);
        private readonly string _getEnrolSectionCourseID = DatabaseTools.GetEnrolCourseID(Enumerations.CourseType.ProgramCourse);
       
        /// <summary>
        /// Purpose: Call Methods From Page Class
        /// </summary>
        private static readonly CourseCatalogMainPage CourseCatalogMainPage = new CourseCatalogMainPage();
        private static readonly ManageTemplatePage ManageTemplatePage = new ManageTemplatePage();

        /// <summary>
        /// Purpose - To Create Instructor Type Course
        /// </summary>
        /// <param name="courseType"></param>
        public void ToCreateCatalogCourse(string courseType)
        {
            try
            {
                GenericHelper.SelectWindow("Global Home");
                Assert.AreEqual("Global Home", WebDriver.Title);
                bool announcementClose = GenericHelper.CloseAnnouncementPage();
                if (announcementClose)
                {
                    GenericHelper.Logs("Annoucement page has been closed successfully", "Passed");
                }
                else
                {
                    GenericHelper.Logs("Annoucement page is still not closed", "Failed");
                }
                
                GenericHelper.WaitUntilElement(By.PartialLinkText("Search Catalog"));
                WebDriver.FindElement(By.PartialLinkText("Search Catalog")).Click();
                WebDriver.SwitchTo().DefaultContent();
                // Purpose: Calling Page Class Method
                string courseName = CourseCatalogMainPage.AddCourseInCatalog(courseType);
                if (courseName == null) throw new ArgumentNullException("instructor" + "CourseName is null");
                // Purpose: Calling Page Class Method
                CourseCatalogMainPage.ToVerifyCourseMailError();
                // Purpose: To Verify Course State
                bool isInactiveStatePresent = ToVerifyInactiveCourseState();
                if (isInactiveStatePresent)
                {
                    //Purpose: To Validate Course Created Successfully
                    string isCourseCreated = WebDriver.FindElement(By.Id("tblCourse")).Text;
                    if (isCourseCreated.Contains(courseName))
                    {
                        if (courseType.Equals("ProductTypeProg"))
                        {
                            DatabaseTools.UpdateCourse(Enumerations.CourseType.ProgramCourse, courseName);
                        }
                        if (courseType.Equals("MasterCourse"))
                        {
                            DatabaseTools.UpdateCourse(Enumerations.CourseType.InstructorCourse, courseName);
                        }
                        //Purpose: Update User Enrollment Status in DB
                        DatabaseTools.UpdateUserEnrollStatusTrue(_getSMSInstructor);
                        GenericHelper.Logs(string.Format("Course '{0}' has created successfully and showing in instructor global home page.", courseName), "PASSED");
                    }
                }
                else
                {
                    GenericHelper.Logs("Course has not created successfully and showing in instructor global home page.", "FAILED");
                    Assert.Fail("Course has not created successfully and showing in instructor global home page.");
                }
                if (courseType.Equals("MasterCourse"))
                {
                    string getInstructorCourseID = ToGetInstructorCourseID();
                    if (getInstructorCourseID == null) throw new ArgumentNullException("getInstruc" + "torID is null");
                    {
                        //Purpose: Update Enroll Course ID in DB
                        DatabaseTools.UpdateEnrolCourseID(courseName, getInstructorCourseID);
                    }
                }
                if (courseType.Equals("ProductTypeProg"))
                {
                    ToGetProgramSectionID();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
                GenericHelper.WaitUntilElement(By.CssSelector("#btnCancel > span > span"));
                WebDriver.FindElement(By.CssSelector("#btnCancel > span > span")).Click();
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.SelectWindow("Global Home");
                Assert.Fail(e.ToString());
            }
        }

        /// <summary>
        /// Purpose: To Go Out of the Inactive Sate of Instructor Course
        /// </summary>
        /// <returns>This method returns true/false</returns>
        public bool ToVerifyInactiveCourseState()
        {
            if (GenericHelper.IsElementPresent(By.ClassName("cssCourseInactive")))
            {
                //Loop to go out of the course inactive text
                while (GenericHelper.IsElementPresent(By.ClassName("cssCourseInactive")))
                {
                    WebDriver.FindElement(By.ClassName("cssCourseInactive")).SendKeys("");
                    GenericHelper.WaitUntilElement(By.Id("_ctl3__ctl3__ctl0__ctl1__ctl0_btnViewAll"));
                    WebDriver.FindElement(By.Id("_ctl3__ctl3__ctl0__ctl1__ctl0_btnViewAll")).SendKeys("");
                    WebDriver.FindElement(By.Id("_ctl3__ctl3__ctl0__ctl1__ctl0_btnViewAll")).Click();
                    WebDriver.SwitchTo().Frame(1);
                    GenericHelper.WaitUntilElement(By.Id("_ctl0_InnerPageContent_lnkClose"));
                    WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_lnkClose")).Click();
                    WebDriver.SwitchTo().DefaultContent();
                    Thread.Sleep(20000);
                    GenericHelper.SelectWindow("Global Home");
                    if (!GenericHelper.IsElementPresent(By.ClassName("cssCourseInactive")))
                    {
                        GenericHelper.Logs("Inactive state have been verified and Instructor course has been created", "Passed");
                        return true;
                    }
                }
            }
            else
            {
                GenericHelper.Logs("Inactive state is not showing for the instructor course", "Passed");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Purpose: To Fetch the Instructor Course ID from the Global Home Page
        /// </summary>
        /// <returns></returns>
        public string ToGetInstructorCourseID()
        {
            int divNo = 1;
            string courseNameInstructor = DatabaseTools.GetCourse(Enumerations.CourseType.InstructorCourse);
            GenericHelper.SelectWindow("Global Home");
            Assert.AreEqual("Global Home", WebDriver.Title);
            GenericHelper.WaitUntilElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]"));
            IWebElement divData = WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]"));
            if (!divData.Text.Contains(courseNameInstructor))
            {
                while (!divData.Text.Contains(courseNameInstructor))
                {
                    divNo = divNo + 1;
                    string divdata = WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]")).Text;
                    if (divdata.Contains(courseNameInstructor))
                    {
                        WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]")).SendKeys("");
                        string idText = WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]/descendant::span[@class='spnActive']")).Text;
                        int loc = idText.IndexOf(' ');
                        _enrolledCourseId = idText.Substring(loc).Trim();
                        if (!string.IsNullOrEmpty(_enrolledCourseId))
                        {
                            GenericHelper.Logs(string.Format("Course ID {0} has been fetched successfully", _enrolledCourseId), "Passed");
                        }
                        break;
                    }
                }
            }
            else
            {
                GenericHelper.WaitUntilElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]"));
                WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]")).SendKeys("");
                string idText = WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]/descendant::span[@class='spnActive']")).Text;
                int loc = idText.IndexOf(' ');
                _enrolledCourseId = idText.Substring(loc).Trim();
            }
            return _enrolledCourseId;
        }

        /// <summary>
        /// Purpose: To Get Program Section Course ID
        /// </summary>
        /// <returns></returns>
        public void ToGetProgramSectionID()
        {
            int divNo = 1;
            string courseName = DatabaseTools.GetCourse(Enumerations.CourseType.ProgramCourse);
            GenericHelper.SelectWindow("Global Home");
            Assert.AreEqual("Global Home", WebDriver.Title);
            GenericHelper.WaitUntilElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]"));
            IWebElement courseTable = WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]"));
            if (!courseTable.Text.Contains(courseName))
            {
                while (!courseTable.Text.Contains(courseName))
                {
                    divNo = divNo + 1;
                    string divdata = WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]")).Text;
                    if (divdata.Contains(courseName))
                    {
                        GenericHelper.WaitUntilElement(By.PartialLinkText(courseName));
                        WebDriver.FindElement(By.PartialLinkText(courseName)).Click(); break;
                    }
                }

                ManageTemplatePage.ToCreateTemplate();
                new ProgramAdminToolPage().SelectProgramAdminTab("Sections");
                ManageTemplatePage.GetSectionID();
            }
            else
            {
                GenericHelper.Logs(string.Format("Course '{0}' not found on global home page.", courseName), "FAILED");
                Assert.Fail(string.Format("Course '{0}' not found on global home page.", courseName));
            }
        }

        /// <summary>
        /// Purpose: To Enrol Student In the Respective Instructor Course 
        /// </summary>
        public void ToEnrolTheStudentToCourseID()
        {
            GenericHelper.SelectWindow("Global Home");
            Assert.AreEqual("Global Home", WebDriver.Title);
            GenericHelper.WaitUntilElement((By.XPath("//a[@id='_ctl3:_ctl2:_ctl0:_ctl0:_ctl0:btnEnrollCourse']/span/span")));
            WebDriver.FindElement(By.XPath("//a[@id='_ctl3:_ctl2:_ctl0:_ctl0:_ctl0:btnEnrollCourse']/span/span")).Click();
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.SelectWindow("Global Home");
            WebDriver.SwitchTo().Frame(1);
            GenericHelper.WaitUntilElement(By.Id("txtCourseID"));
            WebDriver.FindElement(By.Id("txtCourseID")).Clear();
            WebDriver.FindElement(By.Id("txtCourseID")).SendKeys(_enrolledCourseId);
            GenericHelper.WaitUntilElement(By.CssSelector("span > span"));
            WebDriver.FindElement(By.CssSelector("span > span")).Click();
            GenericHelper.WaitUntilElement(By.CssSelector("#btnConfirm > span > span"));
            WebDriver.FindElement(By.CssSelector("#btnConfirm > span > span")).Click();
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.SelectWindow("Global Home");
            IWebElement divData = WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody"));
            string dBcoursename = DatabaseTools.GetCourse(Enumerations.CourseType.InstructorCourse);
            if (divData.Text.Contains(dBcoursename))
            {
                GenericHelper.Logs("Enrolled course has been shown on the global home page for student", "Passed");
            }
        }

        /// <summary>
        /// Purpose: To Enrol Student In the Instructor Course 
        /// </summary>
        public void ToEnrolTheStudentToCourse(string courseType)
        {
            string courseName = DatabaseTools.GetCourse(Enumerations.CourseType.InstructorCourse);
            string ProgramName = DatabaseTools.GetSectionName(Enumerations.CourseType.ProgramCourse);

            GenericHelper.SelectWindow("Global Home");
            Assert.AreEqual("Global Home", WebDriver.Title);
            bool announcementClose = GenericHelper.CloseAnnouncementPage();
            if (announcementClose)
            {
                GenericHelper.Logs("Annoucement page has been closed successfully", "Passed");
            }
            else
            {
                GenericHelper.Logs("Annoucement page is still not closed", "Failed");
            }
            GenericHelper.WaitUntilElement(By.Id("_ctl3:_ctl2:_ctl0:_ctl0:_ctl0:btnEnrollCourse"));
            WebDriver.FindElement(By.Id("_ctl3:_ctl2:_ctl0:_ctl0:_ctl0:btnEnrollCourse")).Click();
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.SelectWindow("Global Home");
            WebDriver.SwitchTo().Frame(1);
            GenericHelper.WaitUntilElement(By.Id("txtCourseID"));
            WebDriver.FindElement(By.Id("txtCourseID")).Clear();
            if (courseType.Equals("MasterCourse"))
            {
                if (_getEnrolInstructorCourseID != null) WebDriver.FindElement(By.Id("txtCourseID")).SendKeys(_getEnrolInstructorCourseID);
            }
            if (courseType.Equals("ProductTypeProg"))
            {
                if (_getEnrolInstructorCourseID != null) WebDriver.FindElement(By.Id("txtCourseID")).SendKeys(_getEnrolSectionCourseID);
            }

            GenericHelper.WaitUntilElement(By.CssSelector("span > span"));
            WebDriver.FindElement(By.CssSelector("span > span")).Click();
            GenericHelper.WaitUntilElement(By.CssSelector("#btnConfirm > span > span"));
            WebDriver.FindElement(By.CssSelector("#btnConfirm > span > span")).Click();
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.SelectWindow("Global Home");
            IWebElement divData = WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody"));

            if (courseType.Equals("MasterCourse") && divData.Text.Contains(courseName))
            {
                GenericHelper.Logs("Enrolled course has been shown on the global home page for student.", "Passed");
                DatabaseTools.UpdateUserEnrollStatusTrue(_getSMSStudent);
            }
            else if (courseType.Equals("ProductTypeProg") && divData.Text.Contains(ProgramName))
            {
                GenericHelper.Logs("Enrolled course has been shown on the global home page for student.", "Passed");
                DatabaseTools.UpdateUserEnrollStatusTrue(_getSMSStudent);
            }

            else
            {
                GenericHelper.Logs("Enrolled course has not been shown on the global home page for student.", "Failed");
                Assert.Fail("Enrolled course has not been shown on the global home page for student.");
            }
        }


        /// <summary>
        /// this method is for the selection of section name from the global home page
        /// </summary>
        public void ToSelectSectionName()
        {
            bool isAnnouncementClosed = GenericHelper.CloseAnnouncementPage();
            if(isAnnouncementClosed)
            {
              GenericHelper.Logs("Announcement page is closed", "Passed");
            }
            else
            {
                GenericHelper.Logs("Announcement page is not closed", "Passed");
                Assert.Fail("Annoucement Page is not closed");
            }
            int divNo = 1;
            string courseName = DatabaseTools.GetSectionName(Enumerations.CourseType.ProgramCourse);
            GenericHelper.SelectWindow("Global Home");
            Assert.AreEqual("Global Home", WebDriver.Title);
            GenericHelper.WaitUntilElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]"));
            IWebElement courseTable = WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]"));
            if (!courseTable.Text.Contains(courseName))
            {
                while (!courseTable.Text.Contains(courseName))
                {
                    divNo = divNo + 1;
                    string divdata = WebDriver.FindElement(By.XPath("//table[@id='tblCourse']/tbody/tr/td/div[" + divNo + "]")).Text;
                    if (divdata.Contains(courseName))
                    {
                        GenericHelper.WaitUntilElement(By.PartialLinkText(courseName));
                        WebDriver.FindElement(By.PartialLinkText(courseName)).SendKeys("");
                        WebDriver.FindElement(By.PartialLinkText(courseName)).Click(); break;
                    }
                }

            }
            else
            {
                GenericHelper.Logs(string.Format("Course '{0}' not found on global home page.", courseName), "FAILED");
                Assert.Fail(string.Format("Course '{0}' not found on global home page.", courseName));
            }
        }
    }
}

