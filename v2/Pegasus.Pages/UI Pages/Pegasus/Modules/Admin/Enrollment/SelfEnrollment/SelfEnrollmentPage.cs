using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
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
        public void SmsStudentEnrolledInCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            // Enroll SMS Student In a Course 
            Logger.LogMethodEntry("SelfEnrollmentPage", "SMSStudentEnrolledInCourse",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.ClearTextById(SelfEnrollmentPageResource.
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
                    case Course.CourseTypeEnum.HSSMyPsychLabProgram:
                        // Enter section id in the Textfield
                        base.FillTextBoxById(SelfEnrollmentPageResource.
                            SelfEnrollment_Page_CourseID_TextBox_Id_Locator,
                            course.SectionId);
                        break;
                    case Course.CourseTypeEnum.InstructorCourse:
                    case Course.CourseTypeEnum.MyItLabInstructorCourse:
                    case Course.CourseTypeEnum.MyTestInstructorCourse:
                        // Enter Instructor course id in the Text field
                        base.FillTextBoxById(SelfEnrollmentPageResource.
                        SelfEnrollment_Page_CourseID_TextBox_Id_Locator,
                        course.InstructorCourseId);
                        break;
                }
                this.EnrollSmsUserInCourse();
                //Store Enrollment Date
                course.EnrollmentDate = DateTime.Now;
                Thread.Sleep(5000);
            }                
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SelfEnrollmentPage", "SMSStudentEnrolledInCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Global Home Window.
        /// </summary>
        private void SelectGlobalHomeWindow()
        {
            //Logger entry
            Logger.LogMethodEntry("SelfEnrollmentPage", "SelectGlobalHomeWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilWindowLoads(SelfEnrollmentPageResource.
                SelfEnrollment_Page_GlobalHome_Window_Title_Name);
            //Select Window
            base.SelectWindow(SelfEnrollmentPageResource.
                SelfEnrollment_Page_GlobalHome_Window_Title_Name);
            //Logger exit
            Logger.LogMethodExit("SelfEnrollmentPage", "SelectGlobalHomeWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course And Enroll User In a Course.
        /// </summary>
        private void EnrollSmsUserInCourse()
        {
            // Select Course And Enroll User
            Logger.LogMethodEntry("SelfEnrollmentPage", "EnrollSMSUserInCourse",
               base.IsTakeScreenShotDuringEntryExit);
            // Wait For Element
            base.WaitForElement(By.CssSelector(SelfEnrollmentPageResource.
                SelfEnrollment_Page_CourseID_Span_CssSelector_Locator),10);
            // Click Course ID Button
            IWebElement getConfirmButton = base.GetWebElementPropertiesByCssSelector(SelfEnrollmentPageResource.
                SelfEnrollment_Page_CourseID_Span_CssSelector_Locator);
            base.ClickByJavaScriptExecutor(getConfirmButton);
            // Check Is User Already Enrolled Error Message Present
            if (IsUserAlreadyEnrolledInCourseMessagePresent())
            {
                // click on cancel button
                this.ClickOnCancelButton();
            }
            else
            {
                // Click on confirm button
                this.ClickOnConfirmButton();
            }
            // Select Window
            this.SelectGlobalHomeWindow();
            Logger.LogMethodExit("SelfEnrollmentPage", "EnrollSMSUserInCourse",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on enroll cancel button.
        /// </summary>
        private void ClickOnCancelButton()
        {
            Logger.LogMethodEntry("SelfEnrollmentPage", "ClickOnCancelButton",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(SelfEnrollmentPageResource.
                SelfEnrollment_Page_CancelButton_Id_Locator));
            base.ClickButtonById(SelfEnrollmentPageResource.
                SelfEnrollment_Page_CancelButton_Id_Locator);
            Logger.LogMethodExit("SelfEnrollmentPage", "ClickOnCancelButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on enroll cancel button.
        /// </summary>
        private void ClickOnConfirmButton()
        {
            Logger.LogMethodEntry("SelfEnrollmentPage", "ClickOnConfirmButton",
             base.IsTakeScreenShotDuringEntryExit);
            //Wait For Confirm Button
            base.WaitForElement(
                By.CssSelector(SelfEnrollmentPageResource.
                    SelfEnrollment_Page_CourseID_Confirm_Button_CssSelector_Locator),10);
            IWebElement getConfirmbutton = base.GetWebElementPropertiesByCssSelector
                (SelfEnrollmentPageResource.
                    SelfEnrollment_Page_CourseID_Confirm_Button_CssSelector_Locator);
            //Click On Confirm Button
            base.ClickByJavaScriptExecutor(getConfirmbutton);
            Logger.LogMethodExit("SelfEnrollmentPage", "ClickOnConfirmButton",
             base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
            //Is Message Present
            bool isErrorMessagePresent = base.IsElementPresent(By.Id(SelfEnrollmentPageResource.
                SelfEnrollment_Page_UserAlreadyEnrolled_ErrorMessage_Id_Locator), 5);
            //Logger exit
            Logger.LogMethodExit("SelfEnrollmentPage",
                "IsUserAlreadyEnrolledInCourseMessagePresent",
                base.IsTakeScreenShotDuringEntryExit);
            return isErrorMessagePresent;
        }
    }
}
