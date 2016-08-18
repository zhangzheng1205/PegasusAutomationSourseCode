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
       By availablelinks = By.Id("content");
        By scanlinks = By.CssSelector("blockquote>p>a");
        By centerIframe = By.Id("centerIframe");
        By pegasusViewAllCourseMaterialframe = By.Id("ifrmCoursePreview");
        By PegasusGradebookframe = By.Id("srcGBFrame");
        By pegasusViewAllCourseMaterialHeader = By.Id("_ctl0_InnerPageContent_divViewHedaer");
        By pegasusgbins = By.CssSelector("#CreateColumnButtton");

       //Iframes on this page
        string centerFrameSrc = "http://coursehome.next.qaprod.ecollege.com";
        string gbInsframeSrc = "GBInstructorUX.aspx?";
        string viewallframeSrc = "CoursePreviewMainUX.aspx?";

      /// <summary>
      /// Given a Iframe source, switches inside the Iframe
      /// </summary>
      /// <param name="frame"></param>
       
       public void getInsideFrame(string frame)
        {
            base.SwitchToDefaultPageContent();
            base.WaitForElement(By.CssSelector(string.Format("iframe[src*='{0}']", frame)));
            base.SwitchToIFrameBySource(frame);
            
            
        }

       public void getInsideFrame(By frame)
       {
          IWebDriver myDriver= this.WebDriver;
          base.WaitForElement(frame);
          myDriver.SwitchTo().Frame(myDriver.FindElement(frame));

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

            base.SwitchToDefaultWindow(); 
            
            
            getInsideFrame(centerIframe);

            base.WaitForDocumentLoadToComplete();
            base.WaitForAjaxToComplete();
          
            IWebElement linkobject = base.FindElementTill(availablelinks); 

                        
           IList<IWebElement> listOfLinks = linkobject.FindElements(scanlinks);

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
    /// This method returns true if the page to land matches the page landed.
    /// </summary>
    /// <param name="link">Pegasus header page name</param>
    /// <returns>bool true or false</returns>
       public bool viewAllContentPegaus(string link)
       {

           base.SwitchToDefaultWindow();

           
           getInsideFrame(centerIframe);
           base.WaitForDocumentLoadToComplete();
           base.WaitForAjaxToComplete();

           getInsideFrame(pegasusViewAllCourseMaterialframe);
           base.WaitForDocumentLoadToComplete();
           base.WaitForAjaxToComplete();

           //base.WaitForElement(By.CssSelector("iframe[src*='CoursePreviewMainUX.aspx?']"));
           //base.SwitchToIFrameBySource(viewallframeSrc);
           
           bool success = false;

           bool x = base.IsElementPresent((pegasusViewAllCourseMaterialHeader),10);
           IWebElement header = base.GetWebElementProperties(pegasusViewAllCourseMaterialHeader);


           if (header.Text.ToString().Trim() == link)
               success = true;
           

           return success;
       }

       public bool gradesInsPagePegasus()
       {
           bool success = false;
           base.SwitchToDefaultWindow();


           getInsideFrame(centerIframe);
           base.WaitForDocumentLoadToComplete();
           base.WaitForAjaxToComplete();

           getInsideFrame(PegasusGradebookframe);
           base.WaitForDocumentLoadToComplete();
           base.WaitForAjaxToComplete();

           //getInsideFrame(centerFrameSrc);
           //base.WaitForElement(By.CssSelector("iframe[src*='GBInstructorUX.aspx?']"));
           //base.SwitchToIFrameBySource(gbInsframeSrc);
           //base.WaitForAjaxToComplete();
           success = base.IsElementPresent(pegasusgbins);
           return success;
       }

    }
}
