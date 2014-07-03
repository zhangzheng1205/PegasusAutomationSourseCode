using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Enrollment;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Enrollment Main Page Actions
    /// </summary>
    public class EnrollmentMainPage :BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(EnrollmentMainPage));

        /// <summary>
        /// Click Enroll Button
        /// </summary>
        public void ClickEnrollButton()
        {
            //Click on Enroll Button
            logger.LogMethodEntry("EnrollmentMainPage", "ClickEnrollButton",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                new ProgramAdminToolPage().SelectFrame();
                //click enroll button
                base.WaitForElement(By.Id(EnrollmentMainPageResource.
                    EnrollmentMain_Page_EnrollButton_Id_Locator));
                //Click on Button
                base.ClickButtonByID(EnrollmentMainPageResource.
                    EnrollmentMain_Page_EnrollButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EnrollmentMainPage", "ClickEnrollButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add User Option link
        /// </summary>
        public void ClickonAddUserOption(string addUserOption)
        {
            // Click on Add User Option link
            logger.LogMethodEntry("EnrollmentMainPage", "ClickonAddUserOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Add User Option link
                base.WaitForElement(By.PartialLinkText(addUserOption));
                //Click on Link
                base.ClickLinkByPartialLinkText(addUserOption);
                //Thread value
                Thread.Sleep(Convert.ToInt32
                    (ProgramAdminManageCourseTemplatesPageResource
                    .ProgramAdminManageCourseTemplates_Page_ThreadTime_Value));
                //switch to window
                base.SwitchToDefaultPageContent();
                base.SelectWindow(ProgramAdminManageCourseTemplatesPageResource
                    .ProgramAdminManageCourseTemplates_Page_Window_Title_Name);

            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EnrollmentMainPage", "ClickonAddUserOption",
                          base.isTakeScreenShotDuringEntryExit);
        }
    }
}
