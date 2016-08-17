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

       //locators on this page
       By coursetitle = By.CssSelector("h1.ng-binding");
<<<<<<< Updated upstream
       By availablelinks = By.Id("content");
        By scanlinks = By.CssSelector("blockquote>p>a");
        By centerIframe = By.Id("centerIframe");
        By pegasuslandingpageheader = By.Id("_ctl0_InnerPageContent_divViewHedaer");
        By pegasusgbins = By.CssSelector("#CreateColumnButtton");
=======
       By availablelinks = By.CssSelector("radeditor>#content");
       By scanlinks = By.CssSelector("blockquote>p>a");
       By centerIframe = By.Id("centerIframe");
       By divHavingPegasus = By.Id("_ctl0__ctl0_phBody_PageContent_Div1");
       By pegasusCourseContent = By.Id("ifrmCoursePreview");
       By pegasuslandingpageheader = By.Id("_ctl0_InnerPageContent_divViewHedaer");
       By pegasusgbins = By.CssSelector("#CreateColumnButtton");
>>>>>>> Stashed changes

       //Iframes on this page
        /*string centerFrameSrc = "http://coursehome.next.qaprod.ecollege.com";
        string gbInsframeSrc = "GBInstructorUX.aspx?";
        string viewallframeSrc = "CoursePreviewMainUX.aspx?";*/

      /// <summary>
      /// Given a Iframe source, switches inside the Iframe
      /// </summary>
      /// <param name="frame"></param>
       
       public void getInsideFrame(By frame)
        {
<<<<<<< Updated upstream
            base.SwitchToDefaultPageContent();
            base.WaitForElement(By.CssSelector(string.Format("iframe[src*='{0}']", frame)));
            base.SwitchToIFrameBySource(frame);
            
=======

            IWebDriver mydriver = this.WebDriver;
            IWebElement finder = mydriver.FindElement(frame);
            base.SwitchToIFrameByWebElement(finder);
                                
>>>>>>> Stashed changes
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
            base.WaitForJSLoadToComplete();
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
           

<<<<<<< Updated upstream
            base.WaitForAjaxToComplete();
            getInsideFrame(centerFrameSrc);
           
          // base.WaitTillElementFound()
            //base.FindElementTill(availablelinks, 20);
=======
            base.SwitchToDefaultPageContent();
            base.WaitForJSLoadToComplete();
            base.WaitForAjaxToComplete();
                    
            base.WaitForElement(centerIframe);
            getInsideFrame(centerIframe);
>>>>>>> Stashed changes

            base.WaitForJSLoadToComplete();
            base.WaitForAjaxToComplete();

                base.WaitForElement(availablelinks);
                IWebElement linkobject = base.FindElementTill(availablelinks);


                IList<IWebElement> listOfLinks = linkobject.FindElements(scanlinks);

                foreach (IWebElement links in listOfLinks)
                {
                    if (links.Text.ToString() == link)
                    {
                        base.ClickByJavaScriptExecutor(links);
                        break;
                    }
                }


            
        }
    /// <summary>
    /// This method returns true if the page to land matches the page landed.
    /// </summary>
    /// <param name="link">Pegasus header page name</param>
    /// <returns>bool true or false</returns>
       public bool landedLink(string link)
       {
          
<<<<<<< Updated upstream
           base.WaitForAjaxToComplete();
           getInsideFrame(centerFrameSrc);

           base.WaitForElement(By.CssSelector("iframe[src*='CoursePreviewMainUX.aspx?']"));
           base.SwitchToIFrameBySource(viewallframeSrc);
=======
           base.SwitchToDefaultPageContent();

           base.WaitForJSLoadToComplete();
           base.WaitForAjaxToComplete(); 

>>>>>>> Stashed changes
           bool success = false;
           base.WaitForElement(centerIframe);
           getInsideFrame(centerIframe);

<<<<<<< Updated upstream
           bool x = base.IsElementPresent((pegasuslandingpageheader),10);
=======
           base.WaitForElement(divHavingPegasus);
           base.WaitForElement(pegasusCourseContent);
           getInsideFrame(pegasusCourseContent);
           base.WaitForElement(pegasuslandingpageheader);
           bool x = base.IsElementPresent(pegasuslandingpageheader);
>>>>>>> Stashed changes
           IWebElement header = base.GetWebElementProperties(pegasuslandingpageheader);


           if (header.Text.ToString().Trim() == link)
               success = true;
           

           return success;
       }

       public bool gradesInsPage()
       {

           bool success = false;
<<<<<<< Updated upstream
           
           getInsideFrame(centerFrameSrc);
           base.WaitForElement(By.CssSelector("iframe[src*='GBInstructorUX.aspx?']"));
           base.SwitchToIFrameBySource(gbInsframeSrc);
=======

           base.SwitchToDefaultPageContent();
           base.WaitForJSLoadToComplete();
>>>>>>> Stashed changes
           base.WaitForAjaxToComplete();

           base.WaitForElement(centerIframe);
           getInsideFrame(centerIframe);
           base.WaitForJSLoadToComplete();
           base.WaitForAjaxToComplete();

           base.WaitForElement(divHavingPegasus);
           

           base.WaitForElement(pegasusgbins);

          
           //base.SwitchToIFrameBySource(gbInsframeSrc);
           base.WaitForElement(pegasusgbins, 20);
           success = base.IsElementPresent(pegasusgbins);
           return success;
       }

    }
}
