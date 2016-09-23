using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.D2L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Globalization;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Pegasus.Pages.UI_Pages.Integration.D2L
{
    public class D2LCourseAction : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(D2LCourseAction));

        /// <summary>
        /// This method accepts returns the home page title
        /// </summary>



        //Selects Pegasus course link from home page
        public void D2LCourseSelect(string courseName)
        {
            logger.LogMethodEntry("D2LCourseAction", "D2LCourseSelect",
                 base.IsTakeScreenShotDuringEntryExit);


            try
            {

                //Wait for the cmenu dropdown arrow
                base.WaitForElement(By.XPath(D2LCourseActionResource.
                                      D2L_CourseSelection_Dropdown_Id_Locator));


                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath
                     (D2LCourseActionResource.D2L_CourseSelection_Dropdown_Id_Locator));


                base.WaitForElement(By.PartialLinkText(courseName));

                IWebElement myCourse = base.GetWebElementPropertiesByLinkText(courseName);

                base.ClickByJavaScriptExecutor(myCourse);



            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("D2LCourseAction", "D2LCourseSelect",
                 base.IsTakeScreenShotDuringEntryExit);

        }

        //Clicks MMND Link

        public Boolean D2LMmndLink()
        {
            logger.LogMethodEntry("D2LCourseAction", "D2LMmndLink",
               base.IsTakeScreenShotDuringEntryExit);

            Boolean MmndLink = false;
            try
            {
                base.SelectWindow("Homepage - D2L Kiosk Integration for Automation - Pegasus");
                base.SwitchToIFrameByIndex(0);

                base.WaitForElement(By.LinkText("Pearson's MyLab and Mastering"));

                MmndLink = base.IsElementPresent(By.LinkText("Pearson's MyLab and Mastering"), 10);



                //MmndLink = base.IsElementPresent(By.XPath("//body/div[1]/div/div/ul/li/a"));


            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }


            logger.LogMethodEntry("D2LCourseAction", "D2LMmndLink",
                base.IsTakeScreenShotDuringEntryExit);
            return MmndLink;
        }

        //checks for pagetitle expected vs actual

        public void PageTitle(string expectedPageTitle)
        {
            logger.LogMethodEntry("D2LCourseAction", "PageTitle",
                base.IsTakeScreenShotDuringEntryExit);

            string actualPageTitle = WebDriver.Title.ToString(CultureInfo.InvariantCulture);

            logger.LogAssertion("verifyPageTitle",
            ScenarioContext.Current.ScenarioInfo.
                 Title, () => Assert.AreEqual(expectedPageTitle, actualPageTitle));

            logger.LogMethodEntry("D2LCourseAction", "PageTitle",
                base.IsTakeScreenShotDuringEntryExit);
        }

        public void SelectPegasusCourseFromD2LKiosk(Course.CourseTypeEnum courseTypeEnum)
        {
            Course course = Course.Get(courseTypeEnum);
            string courseName = course.Name;
            base.WaitForElement(By.CssSelector("#studlinks>h3>a"));
            string d = base.GetElementInnerTextByCssSelector("#studlinks>h3>a");
            IWebElement c = base.GetWebElementPropertiesByCssSelector("#studlinks>h3>a");

            if (d == courseName)

                base.ClickByJavaScriptExecutor(c);
        }

        public void SelectMMNDCourseLink()
        {
            //base.SwitchToIFrameByIndex(0);
            bool pres = base.IsElementPresent(By.CssSelector
                ("iframe[src*='/d2l/lms/remoteplugins/lti/launchLti.d2l?']"), 10);
             WebDriver.SwitchTo().Frame(WebDriver.FindElement(By.CssSelector
                ("iframe[src*='/d2l/lms/remoteplugins/lti/launchLti.d2l?']")));
          

            string c = base.GetElementInnerTextByCssSelector(".pure-menu.pure-menu-open>ul>li>a");
            base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(".pure-menu.pure-menu-open>ul>li>a"));
        }

    }
}

