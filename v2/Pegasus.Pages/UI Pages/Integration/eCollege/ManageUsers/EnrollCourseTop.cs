using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Integration.eCollege;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.eCollege.ManageUsers;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handle enrollment
    /// of ECollege Users into Term and Course.
    /// </summary>

    public class EnrollCourseTop : BasePage
    {
        /// <summary>
        ///  Static instance of the logger.
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(EnrollCourseTop));

        /// <summary>
        /// Enroll into Term and course.
        /// </summary>
        /// <param name="userTypeEnum">This is user type Enum.</param>
        /// <param name="courseTypeEnum">This is course type Enum./</param>
        public void EnrollUserToECollegeCourse(User.UserTypeEnum userTypeEnum,
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Enroll ECollege user into Term and Course
            logger.LogMethodEntry("EnrollCourseTop", "EnrollUserToECollegeCourse",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to TopContentArea Frame 
                this.SelectTopContentAreaFrame();
                //Select Term 
                this.SelectTermFromDropDown();
                //Select User check box 
                this.SelectUserCheckBox();
                //Click on Next button after select user
                this.ClickNextButtonOnSelectUserPage();
                //Select User role form dropdown
                this.SelectUserRole(userTypeEnum);
                //Select course checkbox element 
                this.SelectCourseCheckBox(courseTypeEnum);
                //Click Enroll button 
                this.ClickEnrollButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("EnrollCourseTop", "EnrollUserToECollegeCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Check Box.
        /// </summary>
        /// <param name="courseTypeEnum">This is ECollege Course Type Enum.</param>
        private void SelectCourseCheckBox(Course.CourseTypeEnum courseTypeEnum)
        {
            //Select course's checkbox
            logger.LogMethodEntry("EnrollCourseTop", "SelectCourseCheckBox",
                base.isTakeScreenShotDuringEntryExit);
            //Switch to BottomContentArea Frame
            this.SelectBottomContentAreaFrame();
            // Get the ecollege course name
            this.SelectECollegeCourseName(courseTypeEnum);
            logger.LogMethodExit("EnrollCourseTop", "SelectCourseCheckBox",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get ECollge Course Name from
        /// select Course table. 
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        private void SelectECollegeCourseName(Course.CourseTypeEnum courseTypeEnum)
        {
            //Get ECollege course name fron table 
            logger.LogMethodEntry("EnrollCourseTop", "SelectECollegeCourseName",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Table element that contain Coursename
            base.WaitForElement(By.XPath(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectCourse_Table_Xpath_Locator));
            //Get Course Title form In Memory
             Course course = Course.Get(courseTypeEnum);
            //Paging handle
            this.FindCourseNameInSelectCourse(course.Name);
            //Get course row count 
            int getTotalCourseRowCount = base.GetElementCountByXPath(
                EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectCourse_Table_Xpath_Locator);
            //Iterate For Respective Course In Table
            for (int setCourseRowCount = 3; setCourseRowCount <
                getTotalCourseRowCount; setCourseRowCount++)
            {
                //Get  Course Name
                String getECollgeCourseName =
                    base.GetInnerTextAttributeValueByXPath(String.Format(
                    EnrollCourseTopResource.
                    EnrollCourseTop_Page_Table_CourseRow_Xpath_Locator,
                        setCourseRowCount));
                if (getECollgeCourseName.Contains(course.Name))
                {
                    //Click on Course checkBox
                    this.ClickOnCourseCheckbox(setCourseRowCount);
                    break;
                }
            }
            logger.LogMethodExit("EnrollCourseTop", "SelectECollegeCourseName",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Find the Course in Select Course.
        /// Handling Paging.
        /// </summary>
        /// <param name="courseName">This is Course Name.</param>
        private void FindCourseNameInSelectCourse(string courseName)
        {
            //Find Course in select Course 
            logger.LogMethodEntry("EnrollCourseTop"
                , "FindCourseNameInSelectCourse", base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectCourse_Table_Xpath_Locator));
            // Purpose: To Check if the Course Name is Visible on the Page
            while (!base.IsElementContainsInnerTextByXPath(EnrollCourseTopResource
                    .EnrollCourseTop_Page_SelectCourse_Table_body_Xpath_Locator,
                    courseName))
            {
                //Switch to BottomContentArea Frame
                this.SelectBottomContentAreaFrame();
                //Validate existance of element 
                bool isNextLinkEnable = base.IsElementDisplayedByPartialLinkText
                    (EnrollCourseTopResource.
                    EnrollCourseTop_Page__NextLink_PartialText_Locator);
                if (!isNextLinkEnable)
                {
                    break;
                }
                //Click on Next button of paging 
                this.ClickOnPagingNextButtonLink();
                //Wait for page load
                Thread.Sleep(Convert.ToInt32(EnrollCourseTopResource.
                    EnrollCourseTop_Page_Thread_SleepTime_Value_Paging_NextLink));
            }
            logger.LogMethodExit("EnrollCourseTop",
                "FindCourseNameInSelectCourse", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Next button of paging 
        /// </summary>
        private void ClickOnPagingNextButtonLink()
        {
            logger.LogMethodEntry("EnrollCourseTop",
               "ClickOnPagingNextButtonLink", base.isTakeScreenShotDuringEntryExit);
            //Get Button Property
            IWebElement getLinkProperty = base.GetWebElementPropertiesByPartialLinkText
                (EnrollCourseTopResource.
                EnrollCourseTop_Page__NextLink_PartialText_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getLinkProperty);
            //Wait For Element
            base.WaitForElement(By.XPath(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectCourse_Table_Xpath_Locator));
            logger.LogMethodExit("EnrollCourseTop",
               "ClickOnPagingNextButtonLink", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Course CheckBox.
        /// </summary>
        /// <param name="courseRowCount">This is course row count.<param>
        private void ClickOnCourseCheckbox(int courseRowCount)
        {
            //Click on Checkbox corresponding to selected course
            logger.LogMethodEntry("EnrollCourseTop", "ClickOnCourseCheckbox",
                 base.isTakeScreenShotDuringEntryExit);
            //Wait for checkbox element
            base.WaitForElement(By.XPath(String.Format(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectCourse_CheckBox_Xpath_Locator,
                courseRowCount)));
            //Get property of element
            IWebElement getCourseCheckBoxElementProperty = base.
                GetWebElementPropertiesByXPath(String.Format(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectCourse_CheckBox_Xpath_Locator,
                courseRowCount));
            //Click on checkbox
            base.ClickByJavaScriptExecutor(getCourseCheckBoxElementProperty);
            logger.LogMethodExit("EnrollCourseTop", "ClickOnCourseCheckbox",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select next button then
        /// clcik on Enroll to finish user Enrollment.
        /// </summary>
        private void ClickEnrollButton()
        {
            //Click on Enroll Button
            logger.LogMethodEntry("EnrollCourseTop", "ClickEnrollButton",
                base.isTakeScreenShotDuringEntryExit);
            //Switch to SelectTopContentAreaFrame
            this.SelectTopContentAreaFrame();
            //wait for element 
            base.WaitForElement(By.XPath(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectCourse_NextButton_Xpath_Locator));
            IWebElement nextbuttonSelectcourseElement = base.
                GetWebElementPropertiesByXPath(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectCourse_NextButton_Xpath_Locator);
            base.ClickByJavaScriptExecutor(nextbuttonSelectcourseElement);
            Thread.Sleep(Convert.ToInt32(EnrollCourseTopResource.
                EnrollCourseTop_Page_Thread_SleepTime_Enroll_button));
            // Wait for Enroll Element 
            base.WaitForElement(By.XPath(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectCourse_Enroll_Xpath_Locator));
            IWebElement enrollelement = base.GetWebElementPropertiesByXPath(
                EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectCourse_Enroll_Xpath_Locator);
            //Click on Enroll button
            base.ClickByJavaScriptExecutor(enrollelement);
            logger.LogMethodExit("EnrollCourseTop", "ClickEnrollButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select User Role from 
        /// SelectUserStatus_DropDown.
        /// </summary>
        /// <param name="userTypeEnum">User Type Enum.</param>
        private void SelectUserRole(User.UserTypeEnum userTypeEnum)
        {
            //Select User Role from Dropdown
            logger.LogMethodEntry("EnrollCourseTop", "SelectUserRole",
               base.isTakeScreenShotDuringEntryExit);
            //Switch to Top Conten Area Frame
            this.SelectTopContentAreaFrame();
            //Select User Rool from User status drop down
            base.WaitForElement(By.Name(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectUserStatus_DropDown_ID_Locator));
            //Get property of User Status drop down
            IWebElement userStatusElement = base.
                GetWebElementPropertiesByName(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectUserStatus_DropDown_ID_Locator);
            // Click on User status drop down
            base.ClickByJavaScriptExecutor(userStatusElement);
            //Select user role from dropdown
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.ECollegeTeacher:
                    //Select Teacher role from dropdown
                    this.SelectTeacherRoleFromDropdown();
                    break;
                case User.UserTypeEnum.ECollegeStudent:
                    //Select Student role from dropdown
                    this.SelectStudentRoleFromDropdown();
                    break;
            }
            logger.LogMethodExit("EnrollCourseTop", "SelectUserRole",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student role from dropdown.
        /// </summary>
        private void SelectStudentRoleFromDropdown()
        {
            //Select Student role from dropdown
            logger.LogMethodEntry("EnrollCourseTop", "SelectStudentRoleFromDropdown",
             base.isTakeScreenShotDuringEntryExit);
            base.SelectDropDownValueThroughTextByName(
                EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectUserStatus_DropDown_ID_Locator,
                EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectUserStatus_DropDown_ID_Student_Value);
            logger.LogMethodExit("EnrollCourseTop", "SelectStudentRoleFromDropdown",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// //Select Teacher role from dropdown.
        /// </summary>
        private void SelectTeacherRoleFromDropdown()
        {
            //Select Teacher role from dropdown
            logger.LogMethodEntry("EnrollCourseTop", "SelectTeacherRoleFromDropdown",
            base.isTakeScreenShotDuringEntryExit);
            base.SelectDropDownValueThroughTextByName(
                EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectUserStatus_DropDown_ID_Locator,
                EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectUserStatus_DropDown_ID_Teacher_Value);
            logger.LogMethodExit("EnrollCourseTop", "SelectTeacherRoleFromDropdown",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select next button after select user.
        /// </summary>
        private void ClickNextButtonOnSelectUserPage()
        {
            //Click on Naxt button 
            logger.LogMethodEntry("EnrollCourseTop",
           "ClickNextButtonOnSelectUserPage", base.isTakeScreenShotDuringEntryExit);
            //Switch to TopContentAreaFrame
            this.SelectTopContentAreaFrame();
            //Wait for Next button 
            base.WaitForElement(By.Name(EnrollCourseTopResource.
                EnrollCourseTop_Page_NextButton_Name_Locator));
            //Click on Next button
            IWebElement nextbuttonElement = base.
                GetWebElementPropertiesByName(EnrollCourseTopResource.
                EnrollCourseTop_Page_NextButton_Name_Locator);
            base.ClickByJavaScriptExecutor(nextbuttonElement);
            logger.LogMethodExit("EnrollCourseTop", "ClickNextButtonOnSelectUserPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select User Checkbox.
        /// </summary>
        private void SelectUserCheckBox()
        {
            //Select Checkbox corresponding to userName
            logger.LogMethodEntry("EnrollCourseTop",
           "SelectUserCheckBox",
           base.isTakeScreenShotDuringEntryExit);
            //Switch to SelectBottomContentFrame
            this.SelectBottomContentAreaFrame();
            //Wait for Select User Checkbox element
            base.WaitForElement(By.Name(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectUser_CheckBox_Name_Locator));
            //Select User Checkbox element
            IWebElement userCheckboxElement = base.GetWebElementPropertiesByName(
                EnrollCourseTopResource.
                 EnrollCourseTop_Page_SelectUser_CheckBox_Name_Locator);
            base.ClickByJavaScriptExecutor(userCheckboxElement);
            logger.LogMethodExit("EnrollCourseTop", "SelectUserCheckBox",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Term Name form SelectTerm Dropdown.
        /// </summary>
        private void SelectTermFromDropDown()
        {
            //Select Term From DropDown 
            logger.LogMethodEntry("EnrollCourseTop",
            "SelectTermFromDropDown",
            base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Name(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectTerm_DropDown_ID_Locator));
            //Select Please Select Term DropDown value
            base.SelectDropDownValueThroughTextByName(EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectTerm_DropDown_ID_Locator,
                EnrollCourseTopResource.
                EnrollCourseTop_Page_SelectTerm_DropDown_Value);
            logger.LogMethodExit("EnrollCourseTop", "SelectTermFromDropDown",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select BottomContentArea Frame.
        /// </summary>
        private void SelectBottomContentAreaFrame()
        {
            //Select BottomContentArea Frame
            logger.LogMethodEntry("EnrollCourseTop",
            "SelectBottomContentAreaFrame",
            base.isTakeScreenShotDuringEntryExit);
            //Select Content frame
            this.SelectContentFrame();
            //Wait for BottomContentArea Frame
            base.WaitForElement(By.Name(EnrollCourseTopResource.
                EnrollCourseTop_Page_BottomContentArea_Frame_Title));
            //Switch BottomContentArea Frame
            base.SwitchToIFrame(EnrollCourseTopResource.
                EnrollCourseTop_Page_BottomContentArea_Frame_Title);
            logger.LogMethodExit("EnrollCourseTop",
           "SelectBottomContentAreaFrame",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select TopContentArea Frame.
        /// </summary>
        private void SelectTopContentAreaFrame()
        {
            //Select TopContentArea Frame
            logger.LogMethodEntry("EnrollCourseTop",
            "SelectTopContentAreaFrame",
             base.isTakeScreenShotDuringEntryExit);
            //Select ContentFrame
            this.SelectContentFrame();
            //Wait for TopContentArea Frame
            base.WaitForElement(By.Name(EnrollCourseTopResource.
                EnrollCourseTop_Page_TopContentArea_Frame_Title));
            //Switch to TopContentArea Frame 
            base.SwitchToIFrame(EnrollCourseTopResource.
                EnrollCourseTop_Page_TopContentArea_Frame_Title);
            logger.LogMethodExit("EnrollCourseTop",
            "SelectTopContentAreaFrame",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select ContentFrame.
        /// </summary>
        private void SelectContentFrame()
        {
            //Select ContentFrame
            logger.LogMethodEntry("EnrollCourseTop",
            "SelectContentFrame",
            base.isTakeScreenShotDuringEntryExit);
            //Wait For Window Gets Load
            base.WaitUntilWindowLoads(EnrollCourseTopResource.
                EnrollCourseTop_Page_AdministrationPages_Window_Title);
            //Select Administration Pages
            base.SelectWindow(EnrollCourseTopResource.
                EnrollCourseTop_Page_AdministrationPages_Window_Title);
            //Wait for Content frame load
            base.WaitForElement(By.Name(EnrollCourseTopResource.
                EnrollCourseTop_Page_Content_Frame_Title));
            //Select Content Frame
            base.SwitchToIFrame(EnrollCourseTopResource.
                EnrollCourseTop_Page_Content_Frame_Title);
            logger.LogMethodExit("EnrollCourseTop",
            "SelectContentFrame",
            base.isTakeScreenShotDuringEntryExit);
        }
    }
}
