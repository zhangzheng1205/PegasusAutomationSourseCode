using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
//using Pegasus.Pages.UI_Pages.Pegasus.Modules;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.CourseMaterials
{
   public class CourseMaterialPage:BasePage
    {
        private static readonly Logger logger = Logger.
            GetInstance(typeof(CourseMaterialPage));
    


    public void clicksubtab(string tabName)
    {
        base.WaitForElement(By.Id("trSubNavigationTab"),20);
        IWebElement mainTable = base.GetWebElementPropertiesByCssSelector("#trSubNavigationTab");

        IWebElement subTab;

        switch(tabName)
        {
            case "Completed":
                subTab = mainTable.FindElement(By.Id("3"));
                base.ClickByJavaScriptExecutor(subTab);
                break;

            case "To Do":
                subTab = mainTable.FindElement(By.Id("2"));
                base.ClickByJavaScriptExecutor(subTab);
                break;

            case "Course Calendar":
                subTab = mainTable.FindElement(By.Id("1"));
                base.ClickByJavaScriptExecutor(subTab);
                break;

            default: break;
        }
        

    }

      public void clickSubmission()
    {
          
          base.SwitchToIFrameById("ifrmCoursePreview");
          base.WaitForElement(By.Id("btnViewSubmission"), 20);

          IWebElement viewSubmission = base.GetWebElementPropertiesById("btnViewSubmission");

          ClickByJavaScriptExecutor(viewSubmission);

         
    }

      public void  viewSubmissionRecord()
      {

          base.SelectWindow("View Submissions");
         
          base.WaitForElement(By.Id("_ctl0_PopupPageContent_ucSubmissionList_gtStudents_items"), 20);

          IWebElement viewSubmission = base.GetWebElementPropertiesById("_ctl0_PopupPageContent_ucSubmissionList_gtStudents_items");

          IWebElement clickRecord = viewSubmission.FindElement(By.CssSelector("span[title='100 %']"));

          
          ClickByJavaScriptExecutor(clickRecord);

                    
      }

       public bool submittedAnswersPresent()
      {
          bool status = base.IsElementPresent(By.Id("_ctl0_PopupPageContent_SubmissionHeaderMaster_StudentHeader_lblGradeBook"), 20);
          return status;
      }

       public void printOption()
       {
           base.SelectWindow("View Submissions");

           base.WaitForElement(By.Id("_ctl0:PopupPageContent:SubmissionHeaderMaster:StudentHeader:divPrint"), 20);

           IWebElement viewPrint = base.GetWebElementPropertiesById("_ctl0:PopupPageContent:SubmissionHeaderMaster:StudentHeader:divPrint");

           //IWebElement clickPrint = viewPrint.FindElement(By.CssSelector("span[title='100 %']"));
           
           ClickByJavaScriptExecutor(viewPrint);
       }



   }

}
