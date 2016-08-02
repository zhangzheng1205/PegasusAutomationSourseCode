using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus.Pages.Exceptions;
using Pegasus.Automation;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages.Integration.MMND
{
   public class CourseLinks : BasePage
    {

        By coursetitle = By.CssSelector("h1.ng-binding");
        By availablelinks = By.CssSelector("#content>blockquote>p>a");
        By centerIframe = By.Id("centerIframe");
        By pegasuslandingpageheader = By.Id("_ctl0_InnerPageContent_divViewHedaer");

       public void getInsideFrame()
        {
            base.SwitchToDefaultPageContent();
            base.SwitchToIFrameBySource("http://coursehome.next.qaprod.ecollege.com");
            //IWebElement Iframe = base.GetWebElementProperties(centerIframe);
            //base.SwitchToIFrameByWebElement(Iframe);
        }

       /// <summary>
       /// Accepts coursetypeenum and compares the course displayed inside digital vellum with the expected course
       /// </summary>
       /// <param name="courseName, a CourseTypeEnum"></param>
       /// <returns>true if found</returns>

        public bool courseLoggedin(Course.CourseTypeEnum courseName)
        {

            bool success = false;

            string courseNameToMatch = new CourseHome().getCourseName(courseName);
            base.WaitForAjaxToComplete();
            base.WaitTillElementFound(coursetitle);
            
            string actualCourseDisplayed = base.GetWebElementProperties(coursetitle).Text.ToString();

            if(actualCourseDisplayed==courseNameToMatch)
                       success = true;

            
            return success;
        }


       /// <summary>
       /// This method acccepts the link that needs to be accessesd, searches for the given link and clicks on it if found.
       /// </summary>
       /// <param name="link">the pegasus link to be accessed</param>
       public void clickGivenLink(string link)
        {

            getInsideFrame();

           IList<IWebElement> listOfLinks = base.GetWebElementsProperties(availablelinks);

           foreach(IWebElement links in listOfLinks)
           {
               if (links.Text.ToString() == link)
               {
                   base.ClickByJavaScriptExecutor(links);
                   break;
               }
           }

           
        }
    /// <summary>
    /// This method returns true if the page to land matches the page landed
    /// </summary>
    /// <param name="link">Pegasus header page name</param>
    /// <returns>bool true or false</returns>
       public bool landedLink(string link)
       {
           base.WaitForAjaxToComplete();
           getInsideFrame();
           bool success = false;

           bool x = base.IsElementPresent(pegasuslandingpageheader, 10);
           IWebElement header = base.GetWebElementProperties(pegasuslandingpageheader);


           if (header.Text.ToString().Trim() == link)
               success = true;
           

           return success;
       }

    }
}
