using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Report Assessment Certificate Page Actions
    /// </summary>
    public class ReportsAssessmentCertificatePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ReportsAssessmentCertificatePage));

        /// <summary>
        /// Select Certificate Of Completion Exam Window.
        /// </summary>
        public void SelectCertificateOfCompletionExamWindow()
        {
            //Select Certificate Of Completion Exam Window
            logger.LogMethodEntry("ReportsAssessmentCertificatePage",
                "SelectCertificateOfCompletionExamWindow",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(ReportsAssessmentCertificatePageResource.
                        ReportsAssessment_Page_CertificationOfCompletionExam_Window_Name);
                //Select Window
                base.SelectWindow(ReportsAssessmentCertificatePageResource.
                    ReportsAssessment_Page_CertificationOfCompletionExam_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ReportsAssessmentCertificatePage",
                "SelectCertificateOfCompletionExamWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Certificate Score
        /// </summary>
        /// <returns>Certificate Score.</returns>
        public String GetCertificateScore()
        {
            //Get Certificate Score
            logger.LogMethodEntry("ReportsAssessmentCertificatePage", "GetCertificateScore",
                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize varibale
            string getCertificateScore = string.Empty;            
            try
            {
                base.WaitForElement(By.Id(ReportsAssessmentCertificatePageResource.
                    ReportsAssessment_Page_Certificate_Score_Id_Locator));
                //Get Certificate Score
                getCertificateScore = base.GetElementTextById(
                    ReportsAssessmentCertificatePageResource.
                    ReportsAssessment_Page_Certificate_Score_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ReportsAssessmentCertificatePage", "GetCertificateScore",
               base.IsTakeScreenShotDuringEntryExit);
            return getCertificateScore;
        }

        /// <summary>
        /// Select Certificate Of Completion Training Window.
        /// </summary>
        public void SelectCertificateOfCompletionTrainingWindow()
        {
            //Select Certificate Of Completion Training Window
            logger.LogMethodEntry("ReportsAssessmentCertificatePage",
                "SelectCertificateOfCompletionTrainingWindow",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(ReportsAssessmentCertificatePageResource.
                        ReportsAssessment_Page_CertificationOfCompletionTraining_Window_Name);
                //Select Window
                base.SelectWindow(ReportsAssessmentCertificatePageResource.
                    ReportsAssessment_Page_CertificationOfCompletionTraining_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ReportsAssessmentCertificatePage",
                "SelectCertificateOfCompletionTrainingWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
