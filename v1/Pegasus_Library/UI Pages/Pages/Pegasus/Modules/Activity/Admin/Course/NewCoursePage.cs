using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Framework.Common;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using System.Linq;
using Pegasus_Library.Library;
namespace Pegasus.NewCoursPage
{
    public class NewCoursePage : BasePage
    {
        private static string courseName;
        public void CreateCourse(string coursetype)
        {
            GenericHelper.SelectWindow("Create New Courses");
            courseName = GenericHelper.GenerateUniqueVariable(coursetype);
            WebDriver.FindElement(By.Id("txtCourseName")).SendKeys(courseName);
            // Purpose: Fetch Coursename From DB   

            WebDriver.FindElement(By.LinkText("Save")).Click();
            bool isCreateCourseWindowClosed = GenericHelper.IsPopUpClosed(2);
            if (isCreateCourseWindowClosed)
            {
                switch (coursetype)
                {
                    case "BDDML":
                        DatabaseTools.UpdateCourse(Enumerations.CourseType.MasterLibrary, courseName);
                        break;
                    case "BDDCC":
                        DatabaseTools.UpdateCourse(Enumerations.CourseType.ContainerCourse, courseName);
                        break;
                    case "BDDEC":
                        DatabaseTools.UpdateCourse(Enumerations.CourseType.EmptyCourse, courseName);
                        break;
                    case "BDDMC":
                        DatabaseTools.UpdateCourse(Enumerations.CourseType.MasterCourse, courseName);
                        break;
                }
                GenericHelper.Logs("As 'Create New Courses' pop-up closed on clicking save button the course is updated in DB" + courseName, "PASSED");
            }
            else
            {
                GenericHelper.Logs("As 'Create New Courses' pop-up not closed on clicking save button the course is not updated in DB" + courseName, "FAILED");
            }
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            GenericHelper.VerifySuccesfullMessage("New course created successfully.");
        }

        //Purpose: To Copy HED Autohored  Course
        public void CopyCourse(string copyCourseName)
        {
            try
            {
                if (copyCourseName.Equals("Master"))
                {
                    GenericHelper.SelectWindow("Copy as Master Course");
                    courseName = GenericHelper.GenerateUniqueVariable("MySpanishLab");
                }
                if (copyCourseName.Equals("Testing"))
                {
                    GenericHelper.SelectWindow("Copy as Testing Course");
                    courseName = GenericHelper.GenerateUniqueVariable("TestingCourse");
                }
                GenericHelper.WaitUntilElement(By.Id("txtCourseName"));
                WebDriver.FindElement(By.Id("txtCourseName")).Clear();
                WebDriver.FindElement(By.Id("txtCourseName")).SendKeys(copyCourseName);
                WebDriver.FindElement(By.Id("imgbtnSave")).Click();
                Thread.Sleep(3000);
                bool isCourseCopyWindowClosed = GenericHelper.IsPopUpClosed(2);
                if (isCourseCopyWindowClosed)
                {
                    if (copyCourseName.Contains("MySpanishLab"))
                    {
                        GenericHelper.Logs(string.Format("HED Authored Course '{0}' has been copied successfully.", copyCourseName), "PASSED");
                        DatabaseTools.UpdateCourse(Enumerations.CourseType.MySpanishLabMasterCourse, copyCourseName);
                    }
                    else if (copyCourseName.Contains("TestingCourse"))
                    {
                        GenericHelper.Logs(string.Format("Authored Course '{0}' has been copied successfully.", copyCourseName), "PASSED");
                        DatabaseTools.UpdateCourse(Enumerations.CourseType.TestingCourse, copyCourseName);
                    }
                    else
                    {
                        GenericHelper.Logs(string.Format("Authored Course '{0}' has been copied successfully.", copyCourseName), "PASSED");
                        DatabaseTools.UpdateCourse(Enumerations.CourseType.AuthoredMasterLibrary, copyCourseName); 
                    }
                }
                else
                {
                    GenericHelper.Logs(string.Format("Authored Course '{0}' has not been copied successfully.", copyCourseName), "FAILED");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isCopyasMasterCourseWindowPresent = GenericHelper.IsPopUpWindowPresent("Copy as Master Course");
                if (isCopyasMasterCourseWindowPresent)
                {
                    GenericHelper.SelectWindow("Copy as Master Course");
                    WebDriver.Close();
                }
                Assert.Fail(e.ToString());
            }
        }
    }
}
