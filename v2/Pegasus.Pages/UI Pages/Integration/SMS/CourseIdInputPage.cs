using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Integration.SMS;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handles the Course Id Input Page Actions
    /// </summary>
    public class CourseIdInputPage : BasePage
    {
        //Getting SMS MMND Student Access Code From Configuration File.
        string getSMSMMNDStudent = ConfigurationManager.AppSettings[
            CourseIdInputPageResource.CourseIdInput_Page_SMS_AccessCode_MMNDStudent];

        /// <summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(CourseIdInputPage));

        /// <summary>
        /// Verify FindCourse Button
        /// </summary>
        /// <returns>Find Course Button</returns>
        public Boolean IsFindCourseButtonPresent()
        {
            //Verfy Accept Button
            logger.LogMethodEntry("CourseIdInputPage", "IsFindCourseButtonPresent",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            bool isFindCourseButtonPresent = false;
            try
            {
                //Wait for Selection Window
                base.WaitUntilWindowLoads(CourseIdInputPageResource.
                       CourseIdInput_Page_ProductSelection_Window_Name);
                base.SelectWindow(CourseIdInputPageResource.
                    CourseIdInput_Page_ProductSelection_Window_Name);
                //Wait for Submit Button
                base.WaitForElement(By.Id(CourseIdInputPageResource.
                    CourseIdInput_Page_FindCourse_Id_Locator));
                //Verify Find Course Button
                isFindCourseButtonPresent = base.IsElementPresent(By.Id(
                    CourseIdInputPageResource.CourseIdInput_Page_FindCourse_Id_Locator),
                    Convert.ToInt32(CourseIdInputPageResource.
                    CourseIdInput_Page_Custom_TimeToWait_Element));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("CourseIdInputPage", "IsFindCourseButtonPresent",
                base.IsTakeScreenShotDuringEntryExit);
            return isFindCourseButtonPresent;
        }

        /// <summary>
        /// Enter Course Id.
        /// </summary>
        /// <param name="courseId">This is Course Id.</param>
        public void EnterCourseId(string courseId)
        {
            //Enter Course Id
            logger.LogMethodEntry("CourseIdInputPage", "EnterCourseId",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Product Selection Window
                base.SelectWindow(CourseIdInputPageResource.
                        CourseIdInput_Page_ProductSelection_Window_Name);
                base.WaitForElement(By.Id(CourseIdInputPageResource.
                    CourseIdInput_Page_InputCourse_Id_Locator));
                //Enter Course Id
                base.FillTextBoxById(CourseIdInputPageResource.
                    CourseIdInput_Page_InputCourse_Id_Locator, courseId);
                base.WaitForElement(By.Id(CourseIdInputPageResource.
                    CourseIdInput_Page_FindCourse_Id_Locator));
                //Click on Find Course Button
                base.ClickButtonById(CourseIdInputPageResource.
                    CourseIdInput_Page_FindCourse_Id_Locator);
                //Wait for the element
                base.WaitForElement(By.Id(CourseIdInputPageResource.
                    CourseIdInput_Page_UseAccessCode_RadioButton_Id_Locator));
                IWebElement getRadioButton = base.GetWebElementPropertiesById
                    (CourseIdInputPageResource.
                    CourseIdInput_Page_UseAccessCode_RadioButton_Id_Locator);
                //Select the radio button
                base.ClickByJavaScriptExecutor(getRadioButton);
                base.WaitForElement(By.Id(CourseIdInputPageResource.
                    CourseIdInput_Page_Text_AccessCode_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("CourseIdInputPage", "EnterCourseId",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Access Code
        /// </summary>
        public void EnterAccessCode()
        {
            //Enter Access Code
            logger.LogMethodEntry("CourseIdInputPage", "EnterAccessCode",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Access Code button
                base.WaitForElement(By.Id(CourseIdInputPageResource.
                        CourseIdInput_Page_Text_AccessCode_Id_Locator));
                base.FocusOnElementById(CourseIdInputPageResource.
                    CourseIdInput_Page_Text_AccessCode_Id_Locator);
                //Click on Access Code Button
                base.ClickButtonById(CourseIdInputPageResource.
                    CourseIdInput_Page_Text_AccessCode_Id_Locator);
                base.WaitForElement(By.Id(CourseIdInputPageResource.
                    CourseIdInput_Page_Input_AccessCode_Id_Locator));
                //Enter Access Code
                base.FillTextBoxById(CourseIdInputPageResource.
                    CourseIdInput_Page_Input_AccessCode_Id_Locator,
                    getSMSMMNDStudent);
                //Wait for Next Button
                base.WaitForElement(By.Id(CourseIdInputPageResource.
                    CourseIdInput_Page_NextButton_Id_Locator));
                base.FocusOnElementById(CourseIdInputPageResource.
                    CourseIdInput_Page_NextButton_Id_Locator);
                //Click on Next Button
                base.ClickButtonById(CourseIdInputPageResource.
                    CourseIdInput_Page_NextButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                   
            }
            logger.LogMethodExit("CourseIdInputPage", "EnterAccessCode",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter NonCoordinator Course Id.
        /// </summary>
        /// <param name="courseId">This is Course Id.</param>
        public void EnterNonCoordinatorCourseId(string courseId)
        {
            //Enter NonCoordinator Course Id
            logger.LogMethodEntry("CourseIdInputPage", "EnterNonCoordinatorCourseId",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectWindow();
                //Wait for Course Id Text
                base.WaitForElement(By.Id(CourseIdInputPageResource.
                    CourseIdInput_Page_CourseId_Text_Id_Locator));
                base.ClearTextById(CourseIdInputPageResource.
                    CourseIdInput_Page_CourseId_Text_Id_Locator);
                //Fill Course Id
                base.FillTextBoxById(CourseIdInputPageResource.
                    CourseIdInput_Page_CourseId_Text_Id_Locator, courseId);
                base.WaitForElement(By.Id(CourseIdInputPageResource.
                    CourseIdInput_Page_CourseId_Continue_Button_Id_Locator));
                //Click on Continue Button
                base.ClickButtonById(CourseIdInputPageResource.
                    CourseIdInput_Page_CourseId_Continue_Button_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseIdInputPage", "EnterNonCoordinatorCourseId",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("CourseIdInputPage", "SelectWindow",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(CourseIdInputPageResource.
                CourseIdInput_Page_Window_Title);
            //Select Window
            base.SelectWindow(CourseIdInputPageResource.
                CourseIdInput_Page_Window_Title);
            logger.LogMethodExit("CourseIdInputPage", "SelectWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Student Enrollment Confirmation Message.
        /// </summary>
        /// <returns>Student Enrollment Confirmation Message.</returns>
        public String GetStudentEnrollmentConfirmationMessage()
        {
            //Get Student Enrollment Confirmation Message
            logger.LogMethodEntry("CourseIdInputPage", "GetStudentEnrollmentConfirmationMessage",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable            
            string getConfirmationMessageText = string.Empty;
            try
            {
                //Select Window
                this.SelectWindow();
                base.WaitForElement(By.XPath(CourseIdInputPageResource.
                    CourseIdInput_Page_Confirmation_Message_Xpath_Locator));
                //Get Confirmation Message
                getConfirmationMessageText = 
                    base.GetElementTextByXPath(CourseIdInputPageResource.
                    CourseIdInput_Page_Confirmation_Message_Xpath_Locator);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseIdInputPage", "GetStudentEnrollmentConfirmationMessage",
                base.IsTakeScreenShotDuringEntryExit);
            return getConfirmationMessageText;
        }
        
    }
}
