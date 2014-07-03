using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Framework.Common;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using System.Linq;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Activity
{
    public class MyPegasusUxPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        // To select the course from the global home page
        public void ToSelectMasterLibrary(string courseName)
        {
            try
            {
                Thread.Sleep(2000);
                string coursename = string.Empty;
                switch (courseName)
                {
                    case "BDDML":
                        // course will be fetched fm db
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.MasterLibrary);
                        break;
                    case "BDDCC":
                        // course will be fetched fm db
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.ContainerCourse);
                        break;
                    case "BDDEC":
                        // course will be fetched fm db
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.EmptyCourse);
                        break;
                    case "BDDMC":
                        // course will be fetched fm db
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.MasterLibrary);
                        break;
                    case "Testing":
                        // course will be fetched fm db
                        coursename = DatabaseTools.GetCourse(Enumerations.CourseType.TestingCourse);
                        break;
                }
                GenericHelper.WaitUntilElement(By.PartialLinkText(coursename));
                WebDriver.FindElement(By.PartialLinkText(coursename)).Click();
                if (!Browser.Equals("GC"))
                {
                    WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(120));
                }
                if (Browser.Equals("GC"))
                {
                    Thread.Sleep(120000);
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
            }
        }

        // Purpose: To Select the Class name the Global Home page
        public void ToSelectClassName()
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            if (GenericHelper.IsElementPresent(By.Id("lightboxid")))
            {
                bool isAnnouncementClose = GenericHelper.CloseAnnouncementPage();
                if (isAnnouncementClose)
                {
                    GenericHelper.Logs("Announcement Pop up has been closed successfully", "Passed");
                }
                else
                {
                    GenericHelper.Logs("Announcement Pop up has not been closed", "Failed");
                }
            }
            GenericHelper.WaitUntilElement(By.ClassName("NNclassesname"));
            WebDriver.FindElement(By.ClassName("NNclassesname")).Click();
        }
    }
}
