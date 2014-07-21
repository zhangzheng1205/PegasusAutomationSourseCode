using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.PortalTest.Portal;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles UserLayoutRootNodeTarget Page actions
    /// </summary>
    public class UserLayoutRootNodeTargetPage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(UserLayoutRootNodeTargetPage));
        
        /// <summary>
        /// Get Course Search Term from Appconfig File
        /// </summary>
        readonly string getSearchTerm = ConfigurationManager.AppSettings[
            UserLayoutRootNodeTargetPageResource.
            UserLayoutRootNodeTargetPage_SearchTerm_AppSettings_Key_Value];

        static readonly double getSecondsToWait = Convert.ToDouble
        (ConfigurationManager.AppSettings["CourseLoadElementFindTimeOutInSeconds"]);

        /// <summary>
        /// Get Total Time to Wait for The Course To Be Active
        /// </summary>
        readonly int getTotalMinutes = Convert.ToInt32(ConfigurationManager.
            AppSettings[UserLayoutRootNodeTargetPageResource.
            UserLayoutRootNodeTargetPage_AssignedToCopyInterval_AppSettings_Key_Value]);

        /// <summary>
        /// Enter Access Code
        /// </summary>        
        public void EnterAccessCodeId()
        {
            //Enter Access Code and Seach The Courses
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "EnterAccessCodeId",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Window
                base.WaitUntilWindowLoads(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Window_Title);
                base.SelectWindow(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Window_Title);
                //Wait for the Search Radio Button
                base.WaitForElement(By.Id(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Search_RadioButton_Id_Locator));
                //Click on the Search Radio Button
                base.ClickButtonByID(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Search_RadioButton_Id_Locator);
                //Wait for The Search Textbox
                base.WaitForElement(By.Id(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Search_Textbox_Id_Locator));
                base.ClearTextByID(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Search_Textbox_Id_Locator);
                base.FillTextBoxByID(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Search_Textbox_Id_Locator,
                    getSearchTerm);
                //Click on GO button
                base.ClickButtonByID(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Go_Button_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "EnterAccessCodeId",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Course From List
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        public void SearchCourseFromList(Course.CourseTypeEnum courseTypeEnum)
        {
            //Search Course From List
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "SearchCourseFromList",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for 'Select Course Materials'
                base.WaitUntilWindowLoads(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_SelectCourseMaterials_Window_Title);
                base.SelectWindow(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_SelectCourseMaterials_Window_Title);
                //Get the Course Name
                base.WaitForElement(By.Id(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_SelectCourseMaterials_Div_SearchResults_Id_Locator));
                switch (courseTypeEnum)
                {
                    case Course.CourseTypeEnum.MMNDNonCoOrdinate:
                        {
                            //Click on the NonCoOrdinate Course Type button
                            this.ClickOnCourseTypeButton(UserLayoutRootNodeTargetPageResource.
                                UserLayoutRootNodeTargetPage_NonCoOrdinate_Course_Title);
                        }
                        break;
                    case Course.CourseTypeEnum.MMNDCoOrdinate:
                        {
                            //Click on the CoOrdinate Course Type button
                            this.ClickOnCourseTypeButton(UserLayoutRootNodeTargetPageResource.
                                UserLayoutRootNodeTargetPage_CoOrdinate_Course_Title);
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "SearchCourseFromList",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Course Type Button
        /// </summary>
        /// <param name="courseName">This is the Course Name</param>
        private void ClickOnCourseTypeButton(string courseName)
        {
            //Click On Course Type Button
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "ClickOnCourseTypeButton",
                base.isTakeScreenShotDuringEntryExit);
            //Get total Courses
            int getTotalCourses = base.GetElementCountByXPath(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_SelectCourseMaterials_TotalCourses_Xpath_Locator);
            //Click on the Course type button based on the Course
            for (int rowCount = Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_SelectCourseMaterials_Loop_Initializer);
                rowCount < getTotalCourses; rowCount++)
            {
                if (base.IsElementPresent(By.XPath(string.Format(UserLayoutRootNodeTargetPageResource.
                        UserLayoutRootNodeTargetPage_SelectCourseMaterials_CourseName_Xpath_Locator, rowCount)),
                    Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_SelectCourseMaterials_Customized_Time)))
                {
                    //Get the course Name
                    string getCourseName = base.GetElementTextByXPath(string.
                        Format(UserLayoutRootNodeTargetPageResource.
                        UserLayoutRootNodeTargetPage_SelectCourseMaterials_CourseName_Xpath_Locator, rowCount));
                    if (getCourseName.Contains(courseName))
                    {
                        //Click on the Course type button
                        base.ClickButtonByXPath(string.Format(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_SelectCourseMaterials_CourseType_Button_Xpath_Locator,
                            rowCount));
                        break;
                    }
                }
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "ClickOnCourseTypeButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Course Details
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        public void EnterCourseDetails(Course.CourseTypeEnum courseTypeEnum)
        {
            //Enter Course Details
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "EnterCourseDetails",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Window
                base.WaitUntilWindowLoads(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_EnterCourseInformation_Window_Title);
                base.SelectWindow(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_EnterCourseInformation_Window_Title);
                //Generate GUID for Course Name
                Guid course = Guid.NewGuid();
                //Enter Course Name
                this.EnterCourseName(course);
                //Enter Required Course Details
                this.EnterRequiredCourseDetails(courseTypeEnum);
                //Click on the Create Course Button
                this.ClickOnCreateCourseButton();
                //Store The Course Details
                this.StoreTheCourseDetails(courseTypeEnum, course.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "EnterCourseDetails",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Required Course Details
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        private void EnterRequiredCourseDetails(Course.CourseTypeEnum courseTypeEnum)
        {
            //Enter Required Course Details
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "EnterRequiredCourseDetails",
                base.isTakeScreenShotDuringEntryExit);            
            //Get Current Date
            string getCurrentDate = DateTime.Now.ToString(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_DateTime_Date_Parameter);
            //Get Current Month
            string getCurrentMonth = DateTime.Now.ToString(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_DateTime_Month_Parameter);
            //Get Current Year
            string getCurrentYear = DateTime.Now.ToString(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_DateTime_Year_Parameter);
            //Generate Enroll Start Date
            string getEnrollmentStartDate = getCurrentMonth + UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_Space_Value + getCurrentDate +
                UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_CommaAndSpace_Value
                + getCurrentYear;
            //Get Next Year
            string getNextYear = DateTime.Now.AddYears(Convert.ToInt32(
                UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_DateTime_NextYear_Value))
                .ToString(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_DateTime_Year_Parameter);
            //Generate Enroll End Date
            string getEnrollmentEndDate = getCurrentMonth + UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_Space_Value + getCurrentDate +
                UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_CommaAndSpace_Value
                + getNextYear;
            //Select Course/Enrollment Start and End Date
            this.SelectCourseAndEnrollmentDate(courseTypeEnum, 
                getEnrollmentStartDate, getEnrollmentEndDate);                        
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "EnterRequiredCourseDetails",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course/Enrollment Start and End Date
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        /// <param name="enrollStartDate">This is Enrollment Start Date</param>
        /// <param name="enrollEndDate">This is Enrollment End Date</param>
        private void SelectCourseAndEnrollmentDate(Course.CourseTypeEnum courseTypeEnum, 
            string enrollStartDate, string enrollEndDate)
        {
            //Select Course/Enrollment Start and End Date
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "SelectCourseAndEnrollmentDate",
                base.isTakeScreenShotDuringEntryExit);
            switch (courseTypeEnum)
            {
                case Course.CourseTypeEnum.MMNDNonCoOrdinate:
                    //Enter Enroll Start Date
                    this.EnterEnrollmentStartAndEndDate(enrollStartDate, enrollEndDate);
                    //Select Available For Copy option
                    base.ClickButtonByID(UserLayoutRootNodeTargetPageResource.
                        UserLayoutRootNodeTargetPage_EnterCourseInformation_AvailableForCopy_RadioButton_Id_Locator);
                    break;
                case Course.CourseTypeEnum.MMNDSection:
                    //Enter Enroll Start Date
                    this.EnterEnrollmentStartAndEndDate(enrollStartDate, enrollEndDate);
                    break;
            }
            //Enter Course Start And EndDate
            this.EnterCourseStartAndEndDate(enrollStartDate, enrollEndDate);
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "SelectCourseAndEnrollmentDate",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Enrollment Start And End Date
        /// </summary>
        /// <param name="enrollmentStartDate">This is Enrollment Start Date</param>
        /// <param name="enrollmentEndDate">This is Enrollment End Date</param>
        private void EnterEnrollmentStartAndEndDate(string enrollmentStartDate,
            string enrollmentEndDate)
        {
            //Enter Enrollment Start And End Date
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "EnterEnrollmentStartAndEndDate",
                base.isTakeScreenShotDuringEntryExit);
            //Enter Enroll Start Date
            base.ClearTextByID(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_EnrollStart_Id_Locator);
            base.FillTextBoxByID(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_EnrollStart_Id_Locator,
                enrollmentStartDate);
            //Fill Enroll End Date
            base.ClearTextByID(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_EnrollEnd_Id_Locator);
            base.FillTextBoxByID(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_EnrollEnd_Id_Locator,
                enrollmentEndDate);
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "EnterEnrollmentStartAndEndDate",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Course Start And End Date
        /// </summary>
        /// <param name="courseStartDate">This is Course Start Date</param>
        /// <param name="courseEndDate">This is Course End Date</param>
        private void EnterCourseStartAndEndDate(string courseStartDate, string courseEndDate)
        {
            //Enter Course Start And End Date
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "EnterCourseStartAndEndDate",
                base.isTakeScreenShotDuringEntryExit);
            //Fill Course Start Date
            base.ClearTextByID(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_CourseStart_Id_Locator);
            base.FillTextBoxByID(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_CourseStart_Id_Locator,
                courseStartDate);
            //Fill Course End Date
            base.ClearTextByID(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_CourseEnd_Id_Locator);
            base.FillTextBoxByID(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_CourseEnd_Id_Locator,
                courseEndDate);
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "EnterCourseStartAndEndDate",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store The Course Details
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        /// <param name="courseName">This is Course Name</param>
        private void StoreTheCourseDetails(Course.CourseTypeEnum courseTypeEnum, String courseName)
        {
            //Store The Course Details
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "StoreTheCourseDetails",
                base.isTakeScreenShotDuringEntryExit);
            //Store the Course
            Course course = new Course
            {
                Name = courseName,
                IsCreated = true,
                CourseType = courseTypeEnum
            }; course.StoreCourseInMemory();
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "StoreTheCourseDetails",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Course Name
        /// </summary>
        /// <param name="courseNameGUID">This is Course Name GUID</param>
        private void EnterCourseName(Guid courseNameGUID)
        {
            //Enter Course Name
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "EnterCourseName",
                base.isTakeScreenShotDuringEntryExit);            
            base.WaitForElement(By.Id(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_CourseName_Textbox_Id_Locator));
            //Clear the Text
            base.ClearTextByID(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_CourseName_Textbox_Id_Locator);
            //Enter Course Name
            base.FillTextBoxByID(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_CourseName_Textbox_Id_Locator,
                courseNameGUID.ToString());
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "EnterCourseName",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Create Course Button
        /// </summary>
        private void ClickOnCreateCourseButton()
        {
            //Click On Create Course Button
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "ClickOnCreateCourseButton",
                base.isTakeScreenShotDuringEntryExit);
            base.SelectWindow(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_Window_Title);            
            //Wait for "Create Course Now" option
            base.FocusOnElementByXPath(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_CreateCourseNow_Button_Xpath_Locator);
            base.ClickButtonByXPath(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_CreateCourseNow_Button_Xpath_Locator);
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "ClickOnCreateCourseButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Course Creation Successful Message
        /// </summary>
        /// <returns>Course Creation Successfull Message</returns>
        public String GetSuccessfullMessage()
        {
            //Get Course Creation Successful Message
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "GetsuccessfullMessage",
                base.isTakeScreenShotDuringEntryExit);
            //Initializing the Variable
            string getConfirmationMessage = string.Empty;
            try
            {
                //Wait for Course Create confirmation window
                base.WaitUntilWindowLoads(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Window_Title);
                base.SelectWindow(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Window_Title);
                //Get the Successfull Message
                getConfirmationMessage = base.GetElementTextByXPath(
                    UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Successful_Message_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "GetsuccessfullMessage",
                base.isTakeScreenShotDuringEntryExit);
            return getConfirmationMessage;
        }

        /// <summary>
        /// Get CourseId
        /// </summary>
        /// <returns>CourseId</returns>
        public String GetCourseId(Course.CourseTypeEnum courseTypeEnum)
        {
            //Get CourseId
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "GetCourseId",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getCourseId = string.Empty;
            try
            {
                //Select the Window
                base.SelectWindow(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Window_Title);
                switch (courseTypeEnum)
                {
                    //Fetch the course ID
                    case Course.CourseTypeEnum.MMNDSection:
                        getCourseId = this.GetSectionCourseId();
                        break;
                    case Course.CourseTypeEnum.MMNDCoOrdinate:
                    case Course.CourseTypeEnum.MMNDNonCoOrdinate:
                        getCourseId = base.GetElementTextByXPath(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_CourseCreateConfirmation_CourseId_Xpath_Locator);
                        break;
                }                
                //Update CourseId
                Course course = Course.Get(courseTypeEnum);
                course.ECollegeIntegrationId = getCourseId;                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "GetCourseId",
                base.isTakeScreenShotDuringEntryExit);
            return getCourseId;
        }

        /// <summary>
        /// Fetch the Section Course Id
        /// </summary>        
        /// <returns>Section Course Id</returns>
        private string GetSectionCourseId()
        {
            //Fetch the Section Course Id
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "GetSectionCourseId",
                base.isTakeScreenShotDuringEntryExit);
            string getCourseId = base.GetElementTextByXPath(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CourseCreateConfirmation_SectionDetail_Xpath_Locator);
            //Split the text
            string[] getCompleteCourseId = getCourseId.Split(Convert.ToChar(
                UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_EnterCourseInformation_Space_Value));
            //Fetch the Course Id
            getCourseId = getCompleteCourseId[Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Second_ArrayIndex_Value)].
                Trim(Convert.ToChar(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Split_By_Bracket_Character));
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "GetSectionCourseId",
                base.isTakeScreenShotDuringEntryExit);
            return getCourseId;
        }

        /// <summary>
        /// Logout Of MMND
        /// </summary>
        public void LogoutOfMMND()
        {
            //Logout Of MMND
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "LogoutOfMMND",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for 3 Seconds
                Thread.Sleep(Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_MyLabMasteringPearson_Window_Sleep_Value));
                //Select the Window
                base.SelectDefaultWindow();
                //Wait for the Signout Link
                base.WaitForElement(By.PartialLinkText(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_Signout_Link_PartialLinkText));
                //Focus On Sign Out
                base.FocusOnElementByPartialLinkText(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_Signout_Link_PartialLinkText);
                //Click on the Signout Link
                base.ClickLinkByPartialLinkText(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_Signout_Link_PartialLinkText);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "LogoutOfMMND",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Logout Of MMND As Student
        /// </summary>
        public void LogoutAsMMNDStudent()
        {
            //Logout Of MMND As Student
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "LogoutAsMMNDStudent",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Mylab Mastering Pearson Window
                this.SelectMylabMasteringPearsonWindow();
                //Wait for the Signout Link
                base.WaitForElement(By.Id(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_MyLabMasteringPearson_SignOut_Id_Locator));
                //Focus On Sign Out
                base.FocusOnElementByID(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_MyLabMasteringPearson_SignOut_Id_Locator);
                //Click on the Signout Link
                base.ClickLinkById(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_MyLabMasteringPearson_SignOut_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "LogoutAsMMNDStudent",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Course In Active State
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        public void VerifyCourseInActiveState(Course.CourseTypeEnum courseTypeEnum)
        {            
            //Verify Course In Active State
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "VerifyCourseInActiveState",
                base.isTakeScreenShotDuringEntryExit);            
            try
            {                
                //Get the Total Course count
                int getTotalCoursesCount = this.GetTotalCourseCount();
                //Get the Course Name From Memory
                Course course = Course.Get(courseTypeEnum);
                //Wait For The Course In Active State
                this.WaitForCourseInActiveState(course.Name, getTotalCoursesCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "VerifyCourseInActiveState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait For The Course In Active State
        /// </summary>
        /// <param name="courseName">This is Course Name</param>
        /// <param name="totalCoursesCount">Total Number of Courses</param>
        private void WaitForCourseInActiveState(string courseName, int totalCoursesCount)
        {
            //Wait For The Course In Active State
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "WaitForCourseInActiveState",
                base.isTakeScreenShotDuringEntryExit);
            //Start the Stop Watch
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();            
            for (int rowCount = Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Loop_Initializer);
                rowCount <= totalCoursesCount; rowCount++)
            {
                //Check if it is a Course or Section
                if ((base.IsElementPresent(By.XPath(string.Format(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_MyLabMasteringPearson_AssignedToCopy_Course_Name_Xpath_Locator,
                    rowCount)), Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Time))))
                {
                    //Get the course name
                    string getCourseName = base.GetElementTextByXPath(string.Format(UserLayoutRootNodeTargetPageResource.
                        UserLayoutRootNodeTargetPage_MyLabMasteringPearson_AssignedToCopy_Course_Name_Xpath_Locator,
                        rowCount));
                    if (getCourseName.Contains(courseName))
                    {
                        while (base.IsElementPresent(By.XPath(string.Format(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_MyLabMasteringPearson_AssignedToCopy_Course_Icon_Xpath_Locator,
                            rowCount)), Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Time)) &&
                            (stopwatch.Elapsed.TotalMinutes < getTotalMinutes))
                        {
                            //Refresh and Wait for some Time
                            this.RefreshCurrentPageAndWait();
                        }
                        break;
                    }
                }
                else
                {
                    //Get the course name
                    string getCourseName = base.GetElementTextByXPath(string.Format(UserLayoutRootNodeTargetPageResource.
                        UserLayoutRootNodeTargetPage_MyLabMasteringPearson_AssignedToCopy_Section_Name_Xpath_Locator,
                        rowCount));
                    if (getCourseName.Contains(courseName))
                    {
                        while (base.IsElementPresent(By.XPath(string.Format(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_MyLabMasteringPearson_AssignedToCopy_Section_Icon_Xpath_Locator,
                            rowCount)), Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Time)) &&
                            (stopwatch.Elapsed.TotalMinutes < getTotalMinutes))
                        {
                            //Refresh and Wait for some Time
                            this.RefreshCurrentPageAndWait();
                        }
                        break;
                    }
                }
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "WaitForCourseInActiveState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Total Course Count
        /// </summary>
        /// <returns>Total Course Count</returns>
        private int GetTotalCourseCount()
        {
            //Get Total Course Count
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "GetTotalCourseCount",
                base.isTakeScreenShotDuringEntryExit);
            //Select Mylab Mastering Pearson Window
            this.SelectMylabMasteringPearsonWindow();
            //Get the Total Courses Count
            int getTotalCoursesCount = base.GetElementCountByXPath(
                UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CourseCreateConfirmation_TotalCourses_Xpath_Locator);
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "GetTotalCourseCount",
                base.isTakeScreenShotDuringEntryExit);
            return getTotalCoursesCount;
        }

        /// <summary>
        /// Refresh Current Page And Wait
        /// </summary>
        private void RefreshCurrentPageAndWait()
        {
            //Refresh The page And Wait
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "RefreshCurrentPageAndWait",
                base.isTakeScreenShotDuringEntryExit);
            //Refresh And Wait
            base.RefreshTheCurrentPage();
            //Sleep for 10 secs
            Thread.Sleep(Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_MyLabMasteringPearson_ThreadValue));
            //Select Mylab Mastering Pearson Window
            this.SelectMylabMasteringPearsonWindow();
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "RefreshCurrentPageAndWait",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'Back To Your Courses Page' Button
        /// </summary>
        private void ClickOnBackToYourCoursesPageButton()
        {
            //Click On 'Back To Your Courses Page' Button
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", 
                "ClickOnBackToYourCoursesPageButton",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Window_Title);
            //Click On 'Back To Your Courses Page' Button
            base.ClickButtonByPartialLinkText(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CourseCreateConfirmation_BackToYourCoursesPage_Link_Text);
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", 
                "ClickOnBackToYourCoursesPageButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Course In Active State
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        /// <returns>True if the Course is in Active State otherwise False</returns>
        public Boolean IsTheCourseInActiveState(Course.CourseTypeEnum courseTypeEnum)
        {
            //Get The Course In Active State
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "IsTheCourseInActiveState",
                base.isTakeScreenShotDuringEntryExit);
            //Initializing Variables
            Boolean isAssignedToCopyIconPresent = true;            
            try
            {
                //Select Mylab Mastering Pearson Window
                this.SelectMylabMasteringPearsonWindow();               
                //Get the Total Course count
                int getTotalCoursesCount = this.GetTotalCourseCount();
                //Get the Course Name From Memory
                Course course = Course.Get(courseTypeEnum);
                //Is the Assigned to Copy Icon is Displayed
                isAssignedToCopyIconPresent = this.IsCourseInActiveState(getTotalCoursesCount,course.Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "IsTheCourseInActiveState",
                base.isTakeScreenShotDuringEntryExit);
            return isAssignedToCopyIconPresent;
        }

        /// <summary>
        /// Get Course in Active state
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        /// <param name="totalCoursesCount">Total Number Of Courses</param>
        /// <returns>True if the Course is in Active State otherwise False</returns>
        private Boolean IsCourseInActiveState(int totalCoursesCount, string courseName)
        {
            //Get Course in Active state
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "IsCourseInActiveState",
                base.isTakeScreenShotDuringEntryExit);
            //Initializing the Variables
            bool isAssignedToCopyIconPresent = true;
            string getCourseName = string.Empty;
            for (int rowCount = Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Loop_Initializer);
                rowCount <= totalCoursesCount; rowCount++)
            {
                //Check if it is a Course or Section
                if (base.IsElementPresent(By.XPath(string.Format(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_MyLabMasteringPearson_AssignedToCopy_Course_Name_Xpath_Locator,
                    rowCount)), Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Time)))
                {
                    //Get the course name
                    getCourseName = base.GetElementTextByXPath(string.Format(UserLayoutRootNodeTargetPageResource.
                        UserLayoutRootNodeTargetPage_MyLabMasteringPearson_AssignedToCopy_Course_Name_Xpath_Locator,
                        rowCount));
                    if (getCourseName.Contains(courseName))
                    {
                        //Check if the Assigned to Copy Icon is Displayed
                        isAssignedToCopyIconPresent = base.IsElementPresent(By.XPath(
                            string.Format(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_MyLabMasteringPearson_AssignedToCopy_Course_Icon_Xpath_Locator,
                            rowCount)), Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Time));
                        break;
                    }
                }
                else
                {
                    //Get the course name
                    getCourseName = base.GetElementTextByXPath(string.Format(UserLayoutRootNodeTargetPageResource.
                        UserLayoutRootNodeTargetPage_MyLabMasteringPearson_AssignedToCopy_Section_Name_Xpath_Locator,
                        rowCount));
                    if (getCourseName.Contains(courseName))
                    {
                        //Check if the Assigned to Copy Icon is Displayed
                        isAssignedToCopyIconPresent = base.IsElementPresent(By.XPath(
                            string.Format(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_MyLabMasteringPearson_AssignedToCopy_Section_Icon_Xpath_Locator,
                            rowCount)), Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Time));
                        break;
                    }
                }
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "IsCourseInActiveState",
                base.isTakeScreenShotDuringEntryExit);
            return isAssignedToCopyIconPresent;
        }

        /// <summary>
        /// Select CoOrdinate Course
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        public void SelectCoOrdinateCourse(Course.CourseTypeEnum courseTypeEnum)
        {            
            //Select CoOrdinate Course
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "SelectCoOrdinateCourse",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Window
                base.WaitUntilWindowLoads(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Window_Title);
                base.SelectWindow(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Window_Title);
                //Select the 'CoordinatorButton' Radio button
                base.WaitForElement(By.Id(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Section_RadioButton_Id_Locator));
                base.ClickButtonByID(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Section_RadioButton_Id_Locator);
                //Fetch the Course Details
                Course course = Course.Get(courseTypeEnum);                
                //Wait for Dropdown control
                base.WaitForElement(By.Name(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_CoOrdinatorCourse_DropDown_Name_Locator));
                //Select the Coordinate Course base on the Course Id
                this.SelectTheCoOrdinateCourseOption(course.ECollegeIntegrationId);            
                //Click on GO button
                base.ClickButtonByID(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Go_Button_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "SelectCoOrdinateCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The CoOrdinate Course Option
        /// </summary>
        /// <param name="courseId">This is Course Id</param>
        private void SelectTheCoOrdinateCourseOption(String courseId)
        {
            //Select The CoOrdinate Course Option
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "SelectTheCoOrdinateCourseOption",
                base.isTakeScreenShotDuringEntryExit);
            //Get the total count of the Options
            int getTotalDropDownOptionsCount = base.GetElementCountByXPath(
                UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Courses_DropDown_AllOptions_Xpath_Locator);
            //Select the Option from Drop down
            for (int rowCount = Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Courses_DropDown_Options_Initializer_Value);
                rowCount <= getTotalDropDownOptionsCount; rowCount++)
            {
                //Get the Drop Down Text
                string getDropDownOptionText = base.GetElementTextByXPath(string.Format(
                    UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_CreateOrCopyACourse_Courses_DropDown_Options_Xpath_Locator,
                    rowCount));
                if (getDropDownOptionText.Contains(courseId))
                {
                    //Select the Drop Down option
                    base.SelectDropDownValueThroughTextByName(UserLayoutRootNodeTargetPageResource.
                        UserLayoutRootNodeTargetPage_CreateOrCopyACourse_CoOrdinatorCourse_DropDown_Name_Locator,
                        getDropDownOptionText);
                    break;
                }
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "SelectTheCoOrdinateCourseOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create MMND Section
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        public void CreateMMNDSection(Course.CourseTypeEnum courseTypeEnum)
        {
            //Create MMND Section
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "CreateMMNDSection",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Window
                base.WaitUntilWindowLoads(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_EnterCourseInformation_Window_Title);
                base.SelectWindow(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_EnterCourseInformation_Window_Title);
                //Get GUID for Section
                Guid section = Guid.NewGuid();
                //Fill Section Name
                base.ClearTextByID(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_EnterCourseInformation_SectionName_Textbox_Id_Locator);
                base.FillTextBoxByID(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_EnterCourseInformation_SectionName_Textbox_Id_Locator,
                    section.ToString());                
                //Enter Required Course Details
                this.EnterRequiredCourseDetails(courseTypeEnum);
                //Click on the Create Course Button
                this.ClickOnCreateCourseButton();
                //Store The Course Details
                this.StoreTheCourseDetails(courseTypeEnum, section.ToString());                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "CreateMMNDSection",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        public void EnterIntoCourse(Course.CourseTypeEnum courseTypeEnum)
        {            
            //Enter Into Course
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "EnterIntoCourse",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get the Course Name
                Course course = Course.Get(courseTypeEnum);
                //Select Mylab Mastering Pearson Window
                this.SelectMylabMasteringPearsonWindow();
                //Click on the Course Name
                base.ClickLinkByPartialLinkText(course.Name);                                            
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "EnterIntoCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Show Content Security Message.
        /// </summary> 
        private void ClickTheShowContentSecurityMessage()
        {
            //Click The Show Content Security Message
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage",
                "ClickTheShowContentSecurityMessage",
                base.isTakeScreenShotDuringEntryExit);                              
                //Press TAB Key
                base.PressKey(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodetargetPage_TabKey);
                //Click on the "ENTER" key
                base.PressKey(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodetargetPage_EnterKey);
                //Sleep for 2 secs
                Thread.Sleep(Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_EnterAlert_Customized_Time));
                //Click on the "ENTER" key
                base.PressKey(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodetargetPage_EnterKey);
                Thread.Sleep(Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_ShowContent_Alert_DisplayTime));
            logger.LogMethodExit("UserLayoutRootNodeTargetPage",
                "ClickTheShowContentSecurityMessage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display Of Show Content Button.
        /// </summary>
        private void VerifyTheDisplayOfShowContentButton()
        {
            //Verify The Display Of Show Content Button.
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage",
                "VerifyTheDisplayOfShowContentButton",
                base.isTakeScreenShotDuringEntryExit);
            //Start Stop Watch
            Stopwatch stopWatch = new Stopwatch();            
            //Click The Show Content Security Message
            this.ClickTheShowContentSecurityMessage();
            stopWatch.Start();
            do
            {
                // Break In Case wait Time Finished
                if (stopWatch.Elapsed.TotalSeconds > getSecondsToWait) break; 
                if (base.IsElementPresent(By.Id(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodetargetPage_CourseLoad_List_Id_Locator),
                      Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                  UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Wait_Time)) == true)
                {                   
                    this.ClickTheShowContentSecurityMessage();
                }
                //Click Browser Confirmation Button
                this.ClickBrowserConfirmationButton(); 
                if (base.IsElementPresent(By.ClassName(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_eCollegeNotifier_Alert_Id_Locator),
                 Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                 UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Wait_Time)) == true)
                {
                    //Select the 'Notifier' button
                    base.WaitForElement(By.ClassName(UserLayoutRootNodeTargetPageResource.
                        UserLayoutRootNodeTargetPage_eCollegeNotifier_Alert_Id_Locator));
                    IWebElement getErrorShowMessage = base.GetWebElementPropertiesByClassName
                        (UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_eCollegeNotifier_Alert_Id_Locator);
                    //Click the alert close image
                    base.ClickByJavaScriptExecutor(getErrorShowMessage);
                    base.RefreshTheCurrentPage();
                    base.PressKey(UserLayoutRootNodeTargetPageResource.
                        UserLayoutRootNodetargetPage_EnterKey);
                    Thread.Sleep(Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                        UserLayoutRootNodeTargetPage_EnterAlert_Customized_Time));
                    //Click Browser Confirmation Button
                    this.ClickBrowserConfirmationButton();                   
                }
            }            
            while (!base.IsElementPresent(By.PartialLinkText(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CourseHome_Text), Convert.ToInt32
                (UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_SelectCourseMaterials_Customized_Time)));
            //Stop The Watch
            stopWatch.Stop();
            logger.LogMethodExit("UserLayoutRootNodeTargetPage",
                "VerifyTheDisplayOfShowContentButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Browser Confirmation Button.
        /// </summary>
        private void ClickBrowserConfirmationButton()
        {
            //Click Browser Confirmation Button
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage",
                "ClickBrowserConfirmationButton",
                base.isTakeScreenShotDuringEntryExit);
            //If Assigned To Copy Text Present 
            if (base.IsElementPresent(By.Id(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_BrowserConfirmation_Alert_Id_Locator),
                Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Wait_Time)) == true)
            {
                //Get the SupportPage Message
                IWebElement getSupportPageMessage = base.GetWebElementPropertiesById
                    (UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_BrowserConfirmation_Alert_Id_Locator);
                //Click the Message button
                base.ClickByJavaScriptExecutor(getSupportPageMessage);
                IWebElement getSupportPageMessage2 = base.GetWebElementPropertiesById
                    (UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_BrowserConfirmation_Alert_Id_Locator);
                //Click the Message button
                base.ClickByJavaScriptExecutor(getSupportPageMessage2);
                logger.LogMethodExit("UserLayoutRootNodeTargetPage",
               "ClickBrowserConfirmationButton",
               base.isTakeScreenShotDuringEntryExit);
            }
        }

        /// <summary>
        /// Verify The Support Page Alert Message.
        /// </summary>
        private void VerifyTheSupportPageAlertMessage(User.UserTypeEnum userTypeEnum)
        {
            //Verify The Support Page Alert Message
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage",
                "VerifyTheSupportPageAlertMessage",
                base.isTakeScreenShotDuringEntryExit);           
            //Start Stop Watch
            Stopwatch stopWatch = new Stopwatch();            
            this.ClickTheShowContentSecurityMessage();
            stopWatch.Start();
            do
            {
                // Break In Case wait Time Finished
                if (stopWatch.Elapsed.TotalSeconds > getSecondsToWait) break;
                if (base.IsElementPresent(By.Id("modifyMenuAnchor"),
                    Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                  UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Wait_Time)) == true)
                {
                    this.ClickTheShowContentSecurityMessage();
                }
                if (base.IsElementPresent(By.Id(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodetargetPage_CourseLoad_List_Id_Locator),
                      Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                  UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Wait_Time)) 
                                                                                     == true)
                {
                    base.RefreshTheCurrentPage();
                    //Click on the "ENTER" key
                    base.PressKey(UserLayoutRootNodeTargetPageResource.
                        UserLayoutRootNodetargetPage_EnterKey);
                }  
            }
            while (!base.IsElementPresent(By.PartialLinkText(UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CourseHome_Text), Convert.ToInt32
                (UserLayoutRootNodeTargetPageResource.
                UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Time)));
            //Stop The Watch
            stopWatch.Stop();        
            logger.LogMethodExit("UserLayoutRootNodeTargetPage",
                "VerifyTheSupportPageAlertMessage",
                base.isTakeScreenShotDuringEntryExit); 
        }

       
        /// <summary>
        /// Verify The Course Home Loaded Completly.
        /// </summary>
        private void VerifyTheCourseHomeLoadedCompletly(User.UserTypeEnum userTypeEnum)
        {
            //Verify The Course Home Loaded Completly
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage",
                "VerifyTheCourseHomeLoadedCompletly",
                base.isTakeScreenShotDuringEntryExit);           
            {
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.MMNDInstructor:
                         //If Assigned To Copy Text Present 
                        if (base.IsElementPresent(By.Id(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_BrowserConfirmation_Alert_Id_Locator),
                            Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_CourseCreateConfirmation_Customized_Wait_Time)) == true)
                        {
                            //Get the SupportPage Message
                            IWebElement getSupportPageMessage = base.GetWebElementPropertiesById
                                (UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_BrowserConfirmation_Alert_Id_Locator);
                            //Click the Message button
                            base.ClickByJavaScriptExecutor(getSupportPageMessage);
                            IWebElement getSupportPageMessage2 = base.GetWebElementPropertiesById
                                (UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_BrowserConfirmation_Alert_Id_Locator);
                            //Click the Message button
                            base.ClickByJavaScriptExecutor(getSupportPageMessage2);                            
                        }
                        break;
                    case User.UserTypeEnum.MMNDStudent:
                        base.RefreshTheCurrentPage();
                        base.PressKey(UserLayoutRootNodeTargetPageResource.
                                UserLayoutRootNodetargetPage_EnterKey);
                        Thread.Sleep(2000);
                         //If Assigned To Copy Text Present 
                        if (base.IsElementPresent(By.Id(UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_BrowserConfirmation_Alert_Id_Locator),
                            Convert.ToInt32(30)) == true)
                        {
                            //Get the SupportPage Message
                            IWebElement getStudentSupportPageMessage = base.GetWebElementPropertiesById
                                (UserLayoutRootNodeTargetPageResource.
                            UserLayoutRootNodeTargetPage_BrowserConfirmation_Alert_Id_Locator);
                            //Click the Message button
                            base.ClickByJavaScriptExecutor(getStudentSupportPageMessage);
                        }                        
                        break;
                }
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage",
             "VerifyTheCourseHomeLoadedCompletly",
             base.isTakeScreenShotDuringEntryExit);            
        }

        /// <summary>
        /// Select Mylab Mastering Pearson Window.
        /// </summary>
        public void SelectMylabMasteringPearsonWindow()
        {
            //Select Mylab Mastering Pearson Window
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", 
                "SelectMylabMasteringPearsonWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_MyLabMasteringPearson_Window_Title);
                base.SelectWindow(UserLayoutRootNodeTargetPageResource.
                    UserLayoutRootNodeTargetPage_MyLabMasteringPearson_Window_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", 
                "SelectMylabMasteringPearsonWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into MMND Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type.</param>
        /// <param name="userTypeEnum">This is User Type.</param>
        public void EnterIntoMMNDCourse(Course.CourseTypeEnum courseTypeEnum,
            User.UserTypeEnum userTypeEnum)
        {
            //Enter Into MMND Course
            logger.LogMethodEntry("UserLayoutRootNodeTargetPage", "EnterIntoMMNDCourse",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get the Course Name
                Course course = Course.Get(courseTypeEnum);
                //Select Mylab Mastering Pearson Window
                this.SelectMylabMasteringPearsonWindow();
                base.FocusOnElementByPartialLinkText(course.Name);
                IWebElement getCourseName = base.GetWebElementPropertiesByPartialLinkText
                    (course.Name);
                //Click on the Course Name
                base.ClickByJavaScriptExecutor(getCourseName);
                //Course Loaded based on the Browser
                switch (base.Browser)
                {
                    case PegasusBaseTestFixture.InternetExplorer:
                        switch (userTypeEnum)
                        {
                            case User.UserTypeEnum.MMNDInstructor:
                                //Sleep for 8 secs
                                Thread.Sleep(Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                                UserLayoutRootNodeTargetPage_CourseHome_ThreadValue));  
                                //Verify The ShowContent Message
                                this.VerifyTheDisplayOfShowContentButton();
                                break;
                            case User.UserTypeEnum.MMNDStudent:
                                //Sleep for 8 secs
                                Thread.Sleep(Convert.ToInt32(UserLayoutRootNodeTargetPageResource.
                                UserLayoutRootNodeTargetPage_CourseHome_ThreadValue));  
                                //Verify The Support Page Alert Message
                                this.VerifyTheSupportPageAlertMessage(userTypeEnum);
                                break;
                        }
                        break;  
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodeTargetPage", "EnterIntoMMNDCourse",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}


