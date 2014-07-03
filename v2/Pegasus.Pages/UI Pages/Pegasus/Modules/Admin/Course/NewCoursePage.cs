﻿using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Course;
using Pegasus.Pages.Exceptions;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Pegasus New Course Page Actions.
    /// </summary>
    public class NewCoursePage : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(NewCoursePage));

        /// <summary>
        /// Creating Course Copy As Master Course.
        /// </summary> 
        /// <param name="courseTypeEnum">This is course type emum.</param>
        public void CopyCourseAsMasterCourse(Course.CourseTypeEnum courseTypeEnum)
        {
            //Creating Master Course Copy
            logger.LogMethodEntry("NewCoursePage", "CopyCourseAsMasterCourse",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Created Guid Copy Course Name
                SelectCopyAsMasterCourseWindow();
                //Enter Course Name
                String getCourseDetails = this.GetCourseName();
                //Click To Save Course
                ClickOnSaveCourseButton();
                // Save Copied Course Name in Memory
                this.StoreCourseDetailsInMemory(getCourseDetails, courseTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("NewCoursePage", "CopyCourseAsMasterCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Creat a New Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type emum.</param>
        /// <param name="courseFormatOption">This is course format option name.</param>
        public void CreateNewCourse(Course.CourseTypeEnum courseTypeEnum, String courseFormatOption)
        {
            //Creating New Course
            logger.LogMethodEntry("NewCoursePage", "CreateNewCourse",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectCreateNewCoursesWindow();
                //Select the Course Format
                this.SelectCourseFormat(courseFormatOption);
                //Enter Course Name
                String courseName = this.GetCourseName();
                //Click Save To Course
                this.ClickOnSaveCourseButton();
                // Save New Course Name in Memory
                this.StoreCourseDetailsInMemory(courseName, courseTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("NewCoursePage", "CreateNewCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Copy Master Course In Other Workspace.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type emum.</param>
        public void CopyMasterCourseInDifferentWorkspace
            (Course.CourseTypeEnum courseTypeEnum)
        {
            //Copy Master Course In Different Workspace
            logger.LogMethodEntry("NewCoursePage", "CopyMasterCourseInDifferentWorkspace",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                SelectCopyAsMasterCourseWindow();
                //Enter Course Name
                String courseName = this.GetCourseName();
                //Select Option To Copy Course To Other WorkSpace
                this.SelectCopyToAnotherWorkspaceOption();
                //Select WorkSpace Name
                this.SelectWorkSpaceName();
                // Select Course Save Button
                this.ClickOnSaveCourseButton();
                // Store Course Information In Memory
                this.StoreCourseDetailsInMemory(courseName, courseTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("NewCoursePage", "CopyMasterCourseInDifferentWorkspace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Copy Course As Testing Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        public void CopyCourseAsTestingCourse
            (Course.CourseTypeEnum courseTypeEnum)
        {
            //Copy Course As Testing Course
            logger.LogMethodEntry("NewCoursePage", "CopyCourseAsTestingCourse",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectCopyAsTestingCourseWindow();
                //Enter Course Name
                String getCourseName = this.GetCourseName();
                //Click Course Save Button
                this.ClickOnSaveCourseButton();
                // Store Course Information In Memory
                this.StoreCourseDetailsInMemory(getCourseName, courseTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("NewCoursePage", "CopyCourseAsTestingCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Type Format.
        /// </summary>
        /// <param name="courseFormatName">This is course format name.</param>
        private void SelectCourseFormat(String courseFormatName)
        {
            //Select Course Type Format
            logger.LogMethodEntry("NewCoursePage", "SelectCourseFormat",
            base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewCoursePageResource.
                                          NewCourse_Page_CourseType_ComboBox_Id_Locator));
            //Select Drop Down Value
            base.SelectDropDownValueThroughTextByName(NewCoursePageResource.
                NewCourse_Page_CourseType_ComboBox_Id_Locator, courseFormatName);
            logger.LogMethodExit("NewCoursePage", "SelectCourseFormat",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window Create New Courses.
        /// </summary>
        private void SelectCreateNewCoursesWindow()
        {
            //Select New Course Window
            logger.LogMethodEntry("NewCoursePage", "SelectCreateNewCoursesWindow",
           base.isTakeScreenShotDuringEntryExit);
            //Wait For Window Loads
            base.WaitUntilWindowLoads(NewCoursePageResource.
                                          NewCourse_Page_CreateNewCourses_PopUp_Name);
            //Select New Course PopUp        
            base.SelectWindow(NewCoursePageResource.
                                  NewCourse_Page_CreateNewCourses_PopUp_Name);
            logger.LogMethodExit("NewCoursePage", "SelectCreateNewCoursesWindow",
         base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Course Save Button.
        /// </summary>
        private void ClickOnSaveCourseButton()
        {
            //Click Course Save Button
            logger.LogMethodEntry("NewCoursePage", "ClickOnSaveCourseButton",
              base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewCoursePageResource.
                                     NewCourse_Page_Save_Button_Id_Locator));
            //Get Save Button Property
            IWebElement getSaveButtonProperty = base.GetWebElementPropertiesById(
                NewCoursePageResource.NewCourse_Page_Save_Button_Id_Locator);
            //Click On The save Button
            base.ClickByJavaScriptExecutor(getSaveButtonProperty);           
            logger.LogMethodExit("NewCoursePage", "ClickOnSaveCourseButton",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Course Name In Text Box.
        /// </summary>
        /// <returns>Course Name.</returns>
        private String GetCourseName()
        {
            //Enter and Get Course Name
            logger.LogMethodEntry("NewCoursePage", "GetCourseName",
            base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewCoursePageResource.
                                          NewCourse_Page_CourseName_TextBox_Id_Locator));
            //Clearing the Text if present earlier
            base.ClearTextByID(NewCoursePageResource.
                                   NewCourse_Page_CourseName_TextBox_Id_Locator);
            //Genearate Course Name Guid
            Guid courseNameGuid = Guid.NewGuid();
            //Enter The Course Name
            base.FillTextBoxByID(NewCoursePageResource.
                NewCourse_Page_CourseName_TextBox_Id_Locator, courseNameGuid.ToString());
            logger.LogMethodExit("NewCoursePage", "GetCourseName",
           base.isTakeScreenShotDuringEntryExit);
            return courseNameGuid.ToString();
        }

        /// <summary>
        /// Select Course Copy Window.
        /// </summary>
        private void SelectCopyAsMasterCourseWindow()
        {
            //Select Copy Course Window
            logger.LogMethodEntry("NewCoursePage", "SelectCopyAsMasterCourseWindow",
            base.isTakeScreenShotDuringEntryExit);
            //Wait For Window Loads
            base.WaitUntilWindowLoads(NewCoursePageResource.
                                          NewCourse_Page_CopyAsMasterCoursePopUp_Name);
            //Select Copy As Master Course PopUp        
            base.SelectWindow(NewCoursePageResource.
                                  NewCourse_Page_CopyAsMasterCoursePopUp_Name);
            logger.LogMethodEntry("NewCoursePage", "SelectCopyAsMasterCourseWindow",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select WorkSpace Name From DropDown.
        /// </summary>
        private void SelectWorkSpaceName()
        {
            //Select WorkSpace Name
            logger.LogMethodEntry("NewCoursePage", "SelectWorkSpaceName",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Drop down of workspace
            base.WaitForElement(By.Name(NewCoursePageResource.
                NewCourse_Page_CopyAsMasterCoursePopUp_Dropdown_Name));
            // select workspace
            base.SelectDropDownValueThroughTextByName(NewCoursePageResource.
                NewCourse_Page_CopyAsMasterCoursePopUp_Dropdown_Name,
                NewCoursePageResource.NewCourse_Page_CopyAsMasterCoursePopUp_Dropdown_Name_Value);
            logger.LogMethodEntry("NewCoursePage", "SelectWorkSpaceName",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course copy To Another WorkSPace Option.
        /// </summary>
        private void SelectCopyToAnotherWorkspaceOption()
        {
            //Select Course Copy To Another WorkSpace Option
            logger.LogMethodEntry("NewCoursePage", "SelectCopyToAnotherWorkspaceOption",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the checkbox copy to another workspace
            base.WaitForElement(By.Id(NewCoursePageResource.
                                          NewCourse_Page_CopyAsMasterCoursePopUp_Checkbox_Id_Locator));
            //Focus On Element
            base.FocusOnElementByID(NewCoursePageResource.
                                        NewCourse_Page_CopyAsMasterCoursePopUp_Checkbox_Id_Locator);
            //Click the checkbox
            base.ClickCheckBoxById(NewCoursePageResource.
                                       NewCourse_Page_CopyAsMasterCoursePopUp_Checkbox_Id_Locator);
            Thread.Sleep(Convert.ToInt32(NewCoursePageResource.
                                             NewCourse_Page_Total_Window_TimeValue));
            logger.LogMethodExit("NewCoursePage", "SelectCopyToAnotherWorkspaceOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Copy As Testing Course Window.
        /// </summary>
        private void SelectCopyAsTestingCourseWindow()
        {
            //Select Copy As Testing Course Window
            logger.LogMethodEntry("NewCoursePage", "SelectCopyAsTestingCourseWindow",
               base.isTakeScreenShotDuringEntryExit);
            //Wait For Window Loads
            base.WaitUntilWindowLoads(NewCoursePageResource.
                                          NewCourse_Page_CopyAsTestingCoursePopUp_Name);
            //Select Copy As Master Course PopUp        
            base.SelectWindow(NewCoursePageResource.
                                  NewCourse_Page_CopyAsTestingCoursePopUp_Name);
            logger.LogMethodExit("NewCoursePage", "SelectCopyAsTestingCourseWindow",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Save Course In Memory .
        /// </summary>
        /// <param name="courseName">This is course name which is generated by Guid.</param>
        /// <param name="courseTypeEnum">This is Course type enum.</param>
        private void StoreCourseDetailsInMemory(String courseName, Course.CourseTypeEnum courseTypeEnum)
        {
            //Save Course in Memory
            logger.LogMethodEntry("NewCoursePage", "StoreCourseDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
            //Save Course Properties in Memory
            Course newCourse = new Course
                        {
                            Name = courseName,
                            CourseType = courseTypeEnum,
                            IsCreated = true,
                            IsPreferenceStatus = true,
                            creationDate = DateTime.Now,
                        };
            //Save the Course Name
            newCourse.StoreCourseInMemory();
            logger.LogMethodExit("NewCoursePage", "StoreCourseDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
