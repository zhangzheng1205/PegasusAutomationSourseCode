using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.DRT;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the actions of DRTPreviewUX Page
    /// This is bad class name as per Pegasus Page
    /// </summary>
    public class DRTPreviewUXPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(DRTPreviewUXPage));
        
        /// <summary>
        /// This function has code of clicking the preview option of pretest.
        /// </summary>
        public void PreviewPreTestInStudyPlan()
        {
            //Click on the preview option of pre test
            Logger.LogMethodEntry("DRTPreviewUXPage", "PreviewPreTestInStudyPlan",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.WaitUntilWindowLoads(DRTPreviewUXPageResource
                        .DRTPreviewUXPage_WindowTitleName);
                // Select window 
                base.SelectWindow(DRTPreviewUXPageResource
                    .DRTPreviewUXPage_WindowTitleName);
                Thread.Sleep(Convert.ToInt32(DRTPreviewUXPageResource
                    .DRTPreviewUXPage_ThreadTime_Value));
                //Wait For Element
                base.WaitForElement(By.CssSelector(DRTPreviewUXPageResource
                    .DRTPreviewUXPage_Cmenu_CSSSelector_Locator));
                // Get property activity cmenu option element
                IWebElement getActivityCMenuProperty = base.GetWebElementPropertiesByCssSelector
                    (DRTPreviewUXPageResource
                    .DRTPreviewUXPage_Cmenu_CSSSelector_Locator);
                //Click Cmenu Option
                base.ClickByJavaScriptExecutor(getActivityCMenuProperty);
                Thread.Sleep(Convert.ToInt32(DRTPreviewUXPageResource
                      .DRTPreviewUXPage_ThreadTime_Value));
                //Focus on the "Option" cmenu
                base.FocusOnElementByID(DRTPreviewUXPageResource.
                    DRTPreviewUXPage_Option_Id_Locator);
                // Click on preview option
                base.WaitForElement(By.LinkText(DRTPreviewUXPageResource
                    .DRTPreviewUXPage_LinkText_Preview_Locator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByPartialLinkText
                    (DRTPreviewUXPageResource.DRTPreviewUXPage_LinkText_Preview_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("DRTPreviewUXPage", "PreviewPreTestInStudyPlan",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This function has the code for clicking the cancel button
        /// </summary>
        public void ClickOnCancelButton()
        {
            // Handle the post actions of closing activity presentation window
            Logger.LogMethodEntry("DRTPreviewUXPage", "ClickOnCancelButton",
       base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select window and refresh the page        
                base.SelectWindow(DRTPreviewUXPageResource
                    .DRTPreviewUXPage_WindowTitleName);
                base.RefreshTheCurrentPage();
                //Click on cancel button
                base.WaitForElement(By.Id(DRTPreviewUXPageResource
                    .DRTPreviewUXPage_CancelButton_ID_Loactor));
                base.ClickButtonByID(DRTPreviewUXPageResource
                    .DRTPreviewUXPage_CancelButton_ID_Loactor);
                //Select Content window
                base.WaitUntilWindowLoads(DRTPreviewUXPageResource
                    .DRTPreviewUXPage_Content_WindowTitleName);
                base.SelectWindow(DRTPreviewUXPageResource
                    .DRTPreviewUXPage_Content_WindowTitleName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);

            }
            Logger.LogMethodExit("DRTPreviewUXPage", "ClickOnCancelButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This Function Has The Code For Clicking The Return To Course Button
        /// </summary>
        public void ClickOnReturnToCourseButton()
        {
            // Handle the post actions of closing activity presentation window
            Logger.LogMethodEntry("DRTPreviewUXPage", "ClickOnReturnToCourseButton",
       base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select window and refresh the page        
                base.SelectDefaultWindow();
                base.RefreshTheCurrentPage();
                //Click on Return to Course button
                base.WaitForElement(By.PartialLinkText(DRTPreviewUXPageResource
                    .DRTPreviewUXPage_LinkText_ReturnToCourse_Locator));
                base.ClickButtonByPartialLinkText(DRTPreviewUXPageResource
                    .DRTPreviewUXPage_LinkText_ReturnToCourse_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);

            }
            Logger.LogMethodExit("DRTPreviewUXPage", "ClickOnReturnToCourseButton",
                base.isTakeScreenShotDuringEntryExit);
        }

    }
}
