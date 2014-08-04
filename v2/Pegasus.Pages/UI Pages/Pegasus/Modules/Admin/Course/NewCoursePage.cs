using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Automation.DataTransferObjects;
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Type Format.
        /// </summary>
        /// <param name="courseFormatName">This is course format name.</param>
        private void SelectCourseFormat(String courseFormatName)
        {
            //Select Course Type Format
            logger.LogMethodEntry("NewCoursePage", "SelectCourseFormat",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewCoursePageResource.
                                          NewCourse_Page_CourseType_ComboBox_Id_Locator));
            //Select Drop Down Value
            base.SelectDropDownValueThroughTextByName(NewCoursePageResource.
                NewCourse_Page_CourseType_ComboBox_Id_Locator, courseFormatName);
            logger.LogMethodExit("NewCoursePage", "SelectCourseFormat",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window Create New Courses.
        /// </summary>
        private void SelectCreateNewCoursesWindow()
        {
            //Select New Course Window
            logger.LogMethodEntry("NewCoursePage", "SelectCreateNewCoursesWindow",
           base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window Loads
            base.WaitUntilWindowLoads(NewCoursePageResource.
                                          NewCourse_Page_CreateNewCourses_PopUp_Name);
            //Select New Course PopUp        
            base.SelectWindow(NewCoursePageResource.
                                  NewCourse_Page_CreateNewCourses_PopUp_Name);
            logger.LogMethodExit("NewCoursePage", "SelectCreateNewCoursesWindow",
         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Course Save Button.
        /// </summary>
        private void ClickOnSaveCourseButton()
        {
            //Click Course Save Button
            logger.LogMethodEntry("NewCoursePage", "ClickOnSaveCourseButton",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewCoursePageResource.
                                     NewCourse_Page_Save_Button_Id_Locator));
            //Get Save Button Property
            IWebElement getSaveButtonProperty = base.GetWebElementPropertiesById(
                NewCoursePageResource.NewCourse_Page_Save_Button_Id_Locator);
            //Click On The save Button
            base.ClickByJavaScriptExecutor(getSaveButtonProperty);           
            logger.LogMethodExit("NewCoursePage", "ClickOnSaveCourseButton",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Course Name In Text Box.
        /// </summary>
        /// <returns>Course Name.</returns>
        private String GetCourseName()
        {
            //Enter and Get Course Name
            logger.LogMethodEntry("NewCoursePage", "GetCourseName",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewCoursePageResource.
                                          NewCourse_Page_CourseName_TextBox_Id_Locator));
            //Clearing the Text if present earlier
            base.ClearTextById(NewCoursePageResource.
                                   NewCourse_Page_CourseName_TextBox_Id_Locator);
            //Genearate Course Name Guid
            Guid courseNameGuid = Guid.NewGuid();
            //Enter The Course Name
            base.FillTextBoxById(NewCoursePageResource.
                NewCourse_Page_CourseName_TextBox_Id_Locator, courseNameGuid.ToString());
            logger.LogMethodExit("NewCoursePage", "GetCourseName",
           base.IsTakeScreenShotDuringEntryExit);
            return courseNameGuid.ToString();
        }

        /// <summary>
        /// Select Course Copy Window.
        /// </summary>
        private void SelectCopyAsMasterCourseWindow()
        {
            //Select Copy Course Window
            logger.LogMethodEntry("NewCoursePage", "SelectCopyAsMasterCourseWindow",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window Loads
            base.WaitUntilWindowLoads(NewCoursePageResource.
                                          NewCourse_Page_CopyAsMasterCoursePopUp_Name);
            //Select Copy As Master Course PopUp        
            base.SelectWindow(NewCoursePageResource.
                                  NewCourse_Page_CopyAsMasterCoursePopUp_Name);
            logger.LogMethodEntry("NewCoursePage", "SelectCopyAsMasterCourseWindow",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select WorkSpace Name From DropDown.
        /// </summary>
        private void SelectWorkSpaceName()
        {
            //Select WorkSpace Name
            logger.LogMethodEntry("NewCoursePage", "SelectWorkSpaceName",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Drop down of workspace
            base.WaitForElement(By.Name(NewCoursePageResource.
                NewCourse_Page_CopyAsMasterCoursePopUp_Dropdown_Name));
            // select workspace
            base.SelectDropDownValueThroughTextByName(NewCoursePageResource.
                NewCourse_Page_CopyAsMasterCoursePopUp_Dropdown_Name,
                NewCoursePageResource.NewCourse_Page_CopyAsMasterCoursePopUp_Dropdown_Name_Value);
            logger.LogMethodEntry("NewCoursePage", "SelectWorkSpaceName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course copy To Another WorkSPace Option.
        /// </summary>
        private void SelectCopyToAnotherWorkspaceOption()
        {
            //Select Course Copy To Another WorkSpace Option
            logger.LogMethodEntry("NewCoursePage", "SelectCopyToAnotherWorkspaceOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the checkbox copy to another workspace
            base.WaitForElement(By.Id(NewCoursePageResource.
                                          NewCourse_Page_CopyAsMasterCoursePopUp_Checkbox_Id_Locator));
            //Focus On Element
            base.FocusOnElementById(NewCoursePageResource.
                                        NewCourse_Page_CopyAsMasterCoursePopUp_Checkbox_Id_Locator);
            //Click the checkbox
            base.SelectCheckBoxById(NewCoursePageResource.
                                       NewCourse_Page_CopyAsMasterCoursePopUp_Checkbox_Id_Locator);
            Thread.Sleep(Convert.ToInt32(NewCoursePageResource.
                                             NewCourse_Page_Total_Window_TimeValue));
            logger.LogMethodExit("NewCoursePage", "SelectCopyToAnotherWorkspaceOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Copy As Testing Course Window.
        /// </summary>
        private void SelectCopyAsTestingCourseWindow()
        {
            //Select Copy As Testing Course Window
            logger.LogMethodEntry("NewCoursePage", "SelectCopyAsTestingCourseWindow",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window Loads
            base.WaitUntilWindowLoads(NewCoursePageResource.
                                          NewCourse_Page_CopyAsTestingCoursePopUp_Name);
            //Select Copy As Master Course PopUp        
            base.SelectWindow(NewCoursePageResource.
                                  NewCourse_Page_CopyAsTestingCoursePopUp_Name);
            logger.LogMethodExit("NewCoursePage", "SelectCopyAsTestingCourseWindow",
          base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Save Course Properties in Memory
            Course newCourse = new Course
                        {
                            Name = courseName,
                            CourseType = courseTypeEnum,
                            IsCreated = true,
                            IsPreferenceStatus = true,
                            CreationDate = DateTime.Now,
                        };
            //Save the Course Name
            newCourse.StoreCourseInMemory();
            logger.LogMethodExit("NewCoursePage", "StoreCourseDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
