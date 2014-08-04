using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment
{
    /// <summary>
    /// This Class handles the code of middle frame of Enrollment screen
    /// </summary>
    public class OrgEnrollmentPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(OrgEnrollmentPage));


        /// <summary>
        /// Select the Enroll Button
        /// </summary>
        public void SelectEnrollButton()
        {
            //Select the user from left frame
            logger.LogMethodEntry("OrgEnrollmentPage", "SelectEnrollButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select default window and switch to main frame
                base.SelectWindow(OrgAdminUserEnrollmentPageResource
                    .OrgAdminUserEnrollment_Page_WindowName_Title);
                base.SwitchToIFrame(OrgAdminUserEnrollmentPageResource
                    .OrgAdminUserEnrollment_Page_MainFrame_Id_Locator);
                // Switch to middle frame
                base.SwitchToIFrame(OrgEnrollmentPageResource
                    .OrgEnrollment_Page_MiddleFrame_Id_Locator);
                //Wait for the enroll button and select
                base.WaitForElement(By.Id(OrgEnrollmentPageResource
                    .OrgEnrollment_Page_EnrollButton_Id_Locator));
                IWebElement getAddButton=base.GetWebElementPropertiesById(
                    OrgEnrollmentPageResource
                    .OrgEnrollment_Page_EnrollButton_Id_Locator);
                //Click the add button
                base.ClickByJavaScriptExecutor(getAddButton);
                Thread.Sleep(Convert.ToInt32(OrgEnrollmentPageResource
                .OrgEnrollment_Page_ThreadTime_Value));
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Select the user from left frame
            logger.LogMethodExit("OrgEnrollmentPage", "SelectEnrollButton",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
