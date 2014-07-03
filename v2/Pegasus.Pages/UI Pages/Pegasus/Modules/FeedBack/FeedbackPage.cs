using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Linq;
using System.Text;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.FeedBack
{
    /// <summary>
    /// This class handles the Pegasus Feedback Page actions
    /// </summary>
    public class FeedbackPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger.
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(FeedbackPage));


        /// <summary>
        /// Get Feedback Options Text
        /// </summary>
        /// <returns>Feedback Options Text</returns>
        public String GetFeedbackOptionsText()
        {
            //Get Feedback Options Text
            logger.LogMethodEntry("FeedbackPage", "GetFeedbackOptionsText",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getFeedbackOptionsText = string.Empty;
            //Initialize Variable
            string getGeneralFeedbackText = string.Empty;
            //Initialize Variable
            string getCourseMaterailsFeedbackText = string.Empty;
            try
            {
                //Select FeedBack Window
                this.SelectFeedbackWindow();
                base.WaitForElement(By.Id(FeedbackPageResource.
                    Feedback_Page_GeneralFeedback_Id_Locator));
                base.WaitForElement(By.Id(FeedbackPageResource.
                    Feedback_Page_CourseMaterialsFeedback_Id_Locator));
                //Get General Feedback Text
                getGeneralFeedbackText = base.GetElementTextByID(FeedbackPageResource.
                    Feedback_Page_GeneralFeedback_Id_Locator);
                //Get Course Materials Feedback Text
                getCourseMaterailsFeedbackText = base.GetElementTextByID(FeedbackPageResource.
                    Feedback_Page_CourseMaterialsFeedback_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);      
            }
            logger.LogMethodExit("FeedbackPage", "GetFeedbackOptionsText",
              base.isTakeScreenShotDuringEntryExit);
            return getFeedbackOptionsText = getGeneralFeedbackText + getCourseMaterailsFeedbackText;
        }

        /// <summary>
        /// Select FeedBack Window
        /// </summary>
        private void SelectFeedbackWindow()
        {
            //Select FeedBack Window
            logger.LogMethodEntry("FeedbackPage", "SelectFeedbackWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Window
            base.WaitUntilWindowLoads(FeedbackPageResource.
                Feedback_Page_Window_Name);
            //Select Feedback Window
            base.SelectWindow(FeedbackPageResource.
                Feedback_Page_Window_Name);
            logger.LogMethodExit("FeedbackPage", "SelectFeedbackWindow",
              base.isTakeScreenShotDuringEntryExit);
        }
    }
}
