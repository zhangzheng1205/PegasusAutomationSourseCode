using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment.SelfEnrollment;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Self Enrollment Page Actions
    /// </summary>
    public class SelfEnrollmentPage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(SelfEnrollmentPage));

        /// <summary>
        /// Enroll SMS Student In a Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by type enum.</param>
        public void SMSStudentEnrolledInCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            // Enroll SMS Student In a Course 
            Logger.LogMethodEntry("SelfEnrollmentPage", "SMSStudentEnrolledInCourse",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectGlobalHomeWindow();
                //Get HTML properties of IFrame
                IWebElement frame = base.GetWebElementPropertiesByXPath(
                    SelfEnrollmentPageResource.SelfEnrollment_Page_Frame_Xpath_Locator);
                //Switching to Frame
                base.SwitchToIFrameByWebElement(frame);
                base.WaitForElement(By.Id(SelfEnrollmentPageResource.
                    SelfEnrollment_Page_CourseID_TextBox_Id_Locator));
                base.ClearTextByID(SelfEnrollmentPageResource.
                    SelfEnrollment_Page_CourseID_TextBox_Id_Locator);
                //Get Course From Memory
                Course course = Course.Get(courseTypeEnum);
                // To Enroll student depending on the course
                switch (courseTypeEnum)
                {
                    case Course.CourseTypeEnum.ProgramCourse:
                    case Course.CourseTypeEnum.MyItLabProgramCourse:
                    case Course.CourseTypeEnum.HedMilAcceptanceSIMProgramCourse:
                    case Course.CourseTypeEnum.HedMilAcceptanceSIM5ProgramCourse:
                    case Course.CourseTypeEnum.MyITLabOffice2013Program:
                        // Enter section id in the Textfield
                        base.FillTextBoxByID(SelfEnrollmentPageResource.
                            SelfEnrollment_Page_CourseID_TextBox_Id_Locator,
                            course.SectionId);
                        break;
                    case Course.CourseTypeEnum.InstructorCourse:
                    case Course.CourseTypeEnum.MyItLabInstructorCourse:
                    case Course.CourseTypeEnum.MyTestInstructorCourse:
                        // Enter Instructor course id in the Text field
                        base.FillTextBoxByID(SelfEnrollmentPageResource.
                        SelfEnrollment_Page_CourseID_TextBox_Id_Locator,
                        course.InstructorCourseId);
                        break;
                }
                this.EnrollSMSUserInCourse();
                //Store Enrollment Date
                course.EnrollmentDate = DateTime.Now;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SelfEnrollmentPage", "SMSStudentEnrolledInCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Global Home Window.
        /// </summary>
        private void SelectGlobalHomeWindow()
        {
            //Logger entry
            Logger.LogMethodEntry("SelfEnrollmentPage", "SelectGlobalHomeWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilWindowLoads(SelfEnrollmentPageResource.
                SelfEnrollment_Page_GlobalHome_Window_Title_Name);
            //Select Window
            base.SelectWindow(SelfEnrollmentPageResource.
                SelfEnrollment_Page_GlobalHome_Window_Title_Name);
            //Logger exit
            Logger.LogMethodExit("SelfEnrollmentPage", "SelectGlobalHomeWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course And Enroll User In a Course.
        /// </summary>
        private void EnrollSMSUserInCourse()
        {
            // Select Course And Enroll User
            Logger.LogMethodEntry("SelfEnrollmentPage", "EnrollSMSUserInCourse",
               base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.CssSelector(SelfEnrollmentPageResource.
                SelfEnrollment_Page_CourseID_Span_CssSelector_Locator));
            //Click Course ID Button
            IWebElement getConfirmButton = base.GetWebElementPropertiesByCssSelector(SelfEnrollmentPageResource.
                SelfEnrollment_Page_CourseID_Span_CssSelector_Locator);
            base.ClickByJavaScriptExecutor(getConfirmButton);
            //base.ClickButtonByCssSelector(SelfEnrollmentPageResource.
            //    SelfEnrollment_Page_CourseID_Span_CssSelector_Locator);
            //Check Is User Already Enrolled Error Message Present
            if (IsUserAlreadyEnrolledInCourseMessagePresent())
            {
                //Click on cancel button
                this.ClickOnCancelButton();
            }
            else
            {
                //Click on confirm button
                this.ClickOnConfirmButton();
            }
            //Select Window
            this.SelectGlobalHomeWindow();
            Logger.LogMethodExit("SelfEnrollmentPage", "EnrollSMSUserInCourse",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on enroll cancel button.
        /// </summary>
        private void ClickOnCancelButton()
        {
            Logger.LogMethodEntry("SelfEnrollmentPage", "ClickOnCancelButton",
             base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(SelfEnrollmentPageResource.
                SelfEnrollment_Page_CancelButton_Id_Locator));
            base.ClickButtonByID(SelfEnrollmentPageResource.
                SelfEnrollment_Page_CancelButton_Id_Locator);
            Logger.LogMethodExit("SelfEnrollmentPage", "ClickOnCancelButton",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on enroll cancel button.
        /// </summary>
        private void ClickOnConfirmButton()
        {
            Logger.LogMethodEntry("SelfEnrollmentPage", "ClickOnConfirmButton",
             base.isTakeScreenShotDuringEntryExit);
            //Wait For Confirm Button
            base.WaitForElement(
                By.CssSelector(SelfEnrollmentPageResource.
                    SelfEnrollment_Page_CourseID_Confirm_Button_CssSelector_Locator));
            //Click On Confirm Button
            base.ClickButtonByCssSelector(SelfEnrollmentPageResource.
                SelfEnrollment_Page_CourseID_Confirm_Button_CssSelector_Locator);
            Logger.LogMethodExit("SelfEnrollmentPage", "ClickOnConfirmButton",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check if the already enrolled in course  message displayed.
        /// </summary>
        /// <returns>True if error message present else false.</returns>
        private Boolean IsUserAlreadyEnrolledInCourseMessagePresent()
        {
            //Logger entry
            Logger.LogMethodEntry("IsUserAlreadyEnrolledInCourse",
                "IsUserAlreadyEnrolledInCourseMessagePresent",
               base.isTakeScreenShotDuringEntryExit);
            //Is Message Present
            bool isErrorMessagePresent = base.IsElementPresent(By.Id(SelfEnrollmentPageResource.
                SelfEnrollment_Page_UserAlreadyEnrolled_ErrorMessage_Id_Locator), 10);
            //Logger exit
            Logger.LogMethodExit("SelfEnrollmentPage",
                "IsUserAlreadyEnrolledInCourseMessagePresent",
                base.isTakeScreenShotDuringEntryExit);
            return isErrorMessagePresent;
        }
    }
}
