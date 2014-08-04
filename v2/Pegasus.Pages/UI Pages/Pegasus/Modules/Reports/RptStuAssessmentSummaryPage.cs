using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;

namespace Pegasus.Pages.UI_Pages
{
   //This Class Handles Pegasus RptStuAssessmentSummary Page Actions
   public class RptStuAssessmentSummaryPage : BasePage 
    {
       //This is Logger
       private static readonly Logger logger = 
           Logger.GetInstance(typeof(RptStuAssessmentSummaryPage));
      /// <summary>
      ///Validate Report Data
      /// </summary>
      /// <returns> String Activity Name "HomeWork"</returns>
       public string GetActivitySummaryReportData()
        {
            logger.LogMethodEntry("RptStuAssessmentSummaryPage", 
                "GetActivitySummaryReportData",IsTakeScreenShotDuringEntryExit);
            string Title = string.Empty;
            try{
                //Wait for the Report Pop up
                base.WaitUntilWindowLoads(RptStuAssessmentSummaryPageResource.
                    RptActivitySummarypage_Window_Name);
                //Select Activity Summary Report window
                base.SelectWindow(RptStuAssessmentSummaryPageResource.
                    RptActivitySummarypage_Window_Name);
                //Validate ActivityName
                Title = this.GetActivityName();
                //Get Close Button
                IWebElement GetCloseButtonProperty = 
                          base.GetWebElementPropertiesByXPath(
                          RptStuAssessmentSummaryPageResource.
                          RptActivitySummarypage_Closebutton_Xpath_Locator);
                //Click Close Button
                base.ClickByJavaScriptExecutor(GetCloseButtonProperty);
            }
            catch (Exception e) { ExceptionHandler.HandleException(e); }
            logger.LogMethodExit("RptStuAssessmentSummaryPage", 
             "GetActivitySummaryReportData",IsTakeScreenShotDuringEntryExit);
            return Title;
        }

       /// <summary>
       /// Validate Title & Score
       /// </summary>
       /// <returns>String Activity Name "HomeWork"</returns>
       private string GetActivityName()
       {
           logger.LogMethodEntry("RptStuAssessmentSummaryPage", 
               "GetActivityName",IsTakeScreenShotDuringEntryExit);
           // Get "HomeWork" Text by Xpath
           string GetAssetTitle = base.GetElementTextByXPath(
                          RptStuAssessmentSummaryPageResource.
                          RptActivitySummarypage_Activity_Title_Xpath_Locator);
           //Compare "HomeWork" Text.
           if(GetAssetTitle == RptStuAssessmentSummaryPageResource.
                            RptActivitySummarypage_Activity_Title)
           {
               //Get Score "100%(2.0/2.0)"
               string Score = base.GetElementTextByXPath(
                   RptStuAssessmentSummaryPageResource.
                   RptActivitySummarypage_Activity_Score_Xpath_Locator);
               //Compare Score "100%(2.0/2.0)"
               if (Score == RptStuAssessmentSummaryPageResource.
                   RptActivitySummarypage_Activity_Score)
               {    //Set Value as "HomeWork" .
                   GetAssetTitle = RptStuAssessmentSummaryPageResource.
                                RptActivitySummarypage_Activity_Title;
               }
           }
           logger.LogMethodExit("RptStuAssessmentSummaryPage", 
               "GetActivityName",IsTakeScreenShotDuringEntryExit);
           return GetAssetTitle;
       }
    }
}
