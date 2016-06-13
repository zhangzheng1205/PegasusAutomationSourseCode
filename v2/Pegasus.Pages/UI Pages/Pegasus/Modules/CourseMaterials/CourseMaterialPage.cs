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


       public bool ManageMaterials(string materialToFind)
       {
           logger.LogMethodEntry("CourseMaterialPage", "ManageMaterials",
                base.IsTakeScreenShotDuringEntryExit);

           bool materialFound = false;

           try
           {
               base.SwitchToWindow("Course Materials");
               base.SwitchToDefaultPageContent();
               bool x = base.IsElementPresent(By.Id("_ctl0_innerBody"), 20);
               base.WaitForElement(By.Id("ifrmCoursePreview"));
               
               base.SwitchToIFrameById("ifrmCoursePreview");

               base.WaitForElement(By.Id("tblCoursePreview"));

               IWebElement Table = base.GetWebElementPropertiesById("tblCoursePreview");

               int a = Table.FindElements(By.CssSelector("#tblCoursePreview>tbody>tr")).Count;

               for (int i = 1; i <= a; i++)
               {
                   IWebElement linkfinder = Table.FindElement(By.CssSelector(String.Format(".cssRowHeight.CV_GridBackGroundColor.ui-draggable.ui-droppable:nth-child({0}) .CV_tdName>a", i)));
                   string linkName = linkfinder.Text;
                   if(linkName==materialToFind)
                   {
                       materialFound = true;
                       break;
                   }

               }

              
               
           }

           catch (Exception e)
           {
               Console.WriteLine(e.Message);
           }

           
           logger.LogMethodEntry("CourseMaterialPage", "ManageMaterials",
                base.IsTakeScreenShotDuringEntryExit);
           return materialFound;
       }

       public bool LaunchMaterials(string materialToFind)
       {
           logger.LogMethodEntry("CourseMaterialPage", "LaunchMaterials",
                base.IsTakeScreenShotDuringEntryExit);

           bool amplifire = false;
          
           try
           {

               base.SwitchToWindow("Course Materials");
               base.SwitchToDefaultPageContent();
               //bool x = base.IsElementPresent(By.Id("_ctl0_innerBody"),20);
               base.WaitForElement(By.Id("ifrmCoursePreview"));

               base.SwitchToIFrameById("ifrmCoursePreview");

               base.WaitForElement(By.Id("tblCoursePreview"));

               IWebElement Table = base.GetWebElementPropertiesById("tblCoursePreview");

               int a = Table.FindElements(By.CssSelector("#tblCoursePreview>tbody>tr")).Count;

               for (int i = 1; i <= a; i++)
               {
                   IWebElement linkfinder = Table.FindElement(By.CssSelector(String.Format(".cssRowHeight.CV_GridBackGroundColor.ui-draggable.ui-droppable:nth-child({0})", i)));
                   IWebElement linkfinders = linkfinder.FindElement(By.CssSelector(".CV_tdName>a"));
                   string linkName = linkfinders.Text;
                   if (linkName == materialToFind)
                   {
                       IWebElement clickMenu = linkfinder.FindElement(By.CssSelector(".CV_DownImg.CV_imgMore"));
                       base.ClickByJavaScriptExecutor(clickMenu);
                     
                       break;
                   }

               }
               base.SwitchToDefaultPageContent();

               base.WaitForElement(By.Id("ifrmCoursePreview"));

               base.SwitchToIFrameById("ifrmCoursePreview");


               bool y = base.IsElementDisplayedInPage(By.CssSelector(".Classcmenu_main[style*='block']"),true);

               IWebElement cMenu = base.GetWebElementPropertiesByCssSelector(".Classcmenu_main[style*='block']");
                              
               IWebElement openMenu = cMenu.FindElement(By.Id("2"));
               
               base.ClickByJavaScriptExecutor(openMenu);

               base.WaitUntilPopUpLoads("amplifire", 200);

              amplifire= base.IsWindowsExists("amplifire");
               
                            


           }

           catch (Exception e)
           {
               Console.WriteLine(e.Message);
           }

           
           logger.LogMethodEntry("CourseMaterialPage", "LaunchMaterials",
                base.IsTakeScreenShotDuringEntryExit);
           return amplifire;
       }


       public bool Amplifire(string AmpLink)

       {
           logger.LogMethodEntry("CourseMaterialPage", "Amplifire",
               base.IsTakeScreenShotDuringEntryExit);
           bool amplifire = false;

           try
           {
               base.SwitchToWindow("amplifire");

               
               switch(AmpLink)

               {
                   case "Amplifire Content - Automation":

                   case "Amplifire Content BLANK TARGET - Automation":

                       base.WaitForElementDisplayedInUi(By.ClassName("pageTitle"));
                       amplifire = base.IsElementDisplayedInPage(By.CssSelector(".pageTitle"), true);
                       break;

                   case "Amplifire Reporting - Automation":

                       base.WaitForElementDisplayedInUi(By.ClassName("r-tabs-anchor"));
                       amplifire = base.IsElementDisplayedInPage(By.CssSelector(".r-tabs-anchor>a>p"), true);
                       break;

                   default: break;
                       

               }

           }

           catch(Exception e)
           {

               Console.WriteLine(e.Message);
           }

               logger.LogMethodEntry("CourseMaterialPage", "Amplifire",
                base.IsTakeScreenShotDuringEntryExit);

               return amplifire;
      }
       
               


       public void CloseAmplifire()
       {
           logger.LogMethodEntry("CourseMaterialPage", "CloseAmplifire",
                base.IsTakeScreenShotDuringEntryExit);

           base.SwitchToWindow("amplifire");
           base.CloseBrowserWindow();

           logger.LogMethodEntry("CourseMaterialPage", "CloseAmplifire",
                base.IsTakeScreenShotDuringEntryExit);

       }
   }

}
