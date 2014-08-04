using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.CourseMail;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles the Global Recipients List UX Page Actions
    /// </summary>
    public class GlobalRecipientListUXPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(GlobalRecipientListUXPage));

        /// <summary>
        /// Select Instructor Course Recipients
        /// </summary>
        /// <param name="courseName">This is Course Name</param>
        public void SelectInstructorCourseRecipients(string courseName)
        {
            //Select Instructor Course Recipients
            logger.LogMethodEntry("GlobalRecipientListUXPage",
                "SelectInstructorCourseRecipients",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch To IFrame
                this.SwitchToIFrame();
                //Select Instructor Course
                this.SelectInstructorCourse(courseName);
                //Click On Add Recipents
                this.ClickOnAddRecipients();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GlobalRecipientListUXPage",
                "SelectInstructorCourseRecipients",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Instructor Course
        /// </summary>
        /// <param name="courseName">This is Course Name</param>
        private void SelectInstructorCourse(string courseName)
        {
            //Select Instructor Course
            logger.LogMethodEntry("GlobalRecipientListUXPage", "SelectInstructorCourse",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(GlobalRecipientListUXResource.
                GlobalRecipientListUX_CourseCount_XPath_Locator));
            //Get Course Count
            int getCourseCount = base.GetElementCountByXPath(GlobalRecipientListUXResource.
                GlobalRecipientListUX_CourseCount_XPath_Locator);
            for (int initialCount = Convert.ToInt32(GlobalRecipientListUXResource.
                GlobalRecipientListUX_CourseName_InitialValue); initialCount <= getCourseCount; initialCount++)
            {
                //Get Course Name
                string getCourseName = base.
                    GetElementTextByXPath(string.Format(GlobalRecipientListUXResource.
                    GlobalRecipientListUX_GetCourseName_Xpath_Locator, initialCount));
                if (getCourseName == courseName)
                {
                    //Get CheckBox Property
                    IWebElement getCheckBoxProperty = base.
                        GetWebElementPropertiesByXPath(string.Format(GlobalRecipientListUXResource.
                        GlobalRecipientListUX_GetCourseCheckbox_Xpath_Locator, initialCount));
                    //Click On Check Box
                    base.ClickByJavaScriptExecutor(getCheckBoxProperty);
                }
            }
            logger.LogMethodExit("GlobalRecipientListUXPage", "SelectInstructorCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Recipients
        /// </summary>
        private void ClickOnAddRecipients()
        {
            //Click On Add Recipients
            logger.LogMethodEntry("GlobalRecipientListUXPage", "ClickOnAddRecipients",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GlobalRecipientListUXResource.
                GlobalRecipientListUX_AddRecipient_Button_Id_Locator));
            //Get Add Recipients Button Property
            IWebElement getAddRecipientsButtonProperty = base.GetWebElementPropertiesById(
                GlobalRecipientListUXResource.GlobalRecipientListUX_AddRecipient_Button_Id_Locator);
            //Click On Add Recipients Button
            base.ClickByJavaScriptExecutor(getAddRecipientsButtonProperty);
            logger.LogMethodExit("GlobalRecipientListUXPage", "ClickOnAddRecipients",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch To IFrame
        /// </summary>
        private void SwitchToIFrame()
        {
            //Switch To IFrame
            logger.LogMethodEntry("GlobalRecipientListUXPage", "SwitchToIFrame",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GlobalRecipientListUXResource.
                GlobalRecipientListUX_Frame_Id_Locator));
            //Switch To IFrame
            base.SwitchToIFrameById(GlobalRecipientListUXResource.
                GlobalRecipientListUX_Frame_Id_Locator);
            logger.LogMethodExit("GlobalRecipientListUXPage", "SwitchToIFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
