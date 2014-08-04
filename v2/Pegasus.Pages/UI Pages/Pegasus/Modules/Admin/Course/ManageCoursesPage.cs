using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using System.Configuration;
using System.Threading;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Course;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Text.RegularExpressions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Manage Courses Page Actions.
    /// </summary>
    public class ManageCoursesPage : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ManageCoursesPage));

        /// <summary>
        /// This is the Assigned to Copy Interval Time.
        /// </summary>
        static readonly int GetTimeToWaitForAssignedToCopyState = Int32.Parse
            (ConfigurationManager.AppSettings["AssignedToCopyInterval"]);

        /// <summary>
        ///  Select Course Enrollement Window.
        /// </summary>
        public void SelectCourseEnrollementWindow()
        {
            //Find Course Present In Course Grid
            Logger.LogMethodEntry("ManageCoursesPage", "SelectCourseEnrollementWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Getting Out Of The Frame
                base.WaitUntilWindowLoads(ManageCoursesPageResource.
                    ManageCourses_Page_Window_Name_CourseEnrollment);
                base.SelectWindow(ManageCoursesPageResource.
                    ManageCourses_Page_Window_Name_CourseEnrollment);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "SelectCourseEnrollementWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Course C-Menu Option.
        /// </summary>
        /// <param name="courseCMenuOptionName">
        /// This is course cmenu option name.</param>
        public void ClickCourseCMenuOption(
            String courseCMenuOptionName)
        {
            //To Click On The Course Cmenu Option
            Logger.LogMethodEntry("ManageCoursesPage", "ClickCourseCMenuOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select Base Window
                base.SelectDefaultWindow();
                //Select IFrame
                this.SelectIFrameRight();
                // Wait Untill Course Cmenu Appears
                base.WaitForElement(By.XPath(ManageCoursesPageResource.
                     ManageCourses_Page_CourseCmenu_Image_Xpath_Locator));
                //Get HTML Element Property for Cmenu
                IWebElement imageCourseCMenu = base.GetWebElementPropertiesByXPath
                    (ManageCoursesPageResource.
                    ManageCourses_Page_CourseCmenu_Image_Xpath_Locator);
                imageCourseCMenu.SendKeys(string.Empty);
                //Click on the Course CMenu 
                base.ClickByJavaScriptExecutor(imageCourseCMenu);
                base.WaitForElement(By.PartialLinkText(courseCMenuOptionName));
                //Get HTML Element Property for Cmenu Option
                IWebElement clickCourseCMenuOption =
                    base.GetWebElementPropertiesByPartialLinkText(courseCMenuOptionName);
                //Click on the Course CMenu Option
                base.ClickByJavaScriptExecutor(clickCourseCMenuOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "ClickCourseCMenuOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select IFrame.
        /// </summary>
        private void SelectIFrameRight()
        {
            //Select IFrame
            Logger.LogMethodEntry("ManageCoursesPage", "SelectIFrameRight",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(ManageCoursesPageResource.
                 ManageCourses_Page_RightFrame_Id_Locator));
            //Switch To IFrame
            base.SwitchToIFrame(ManageCoursesPageResource
                                    .ManageCourses_Page_RightFrame_Id_Locator);
            Logger.LogMethodExit("ManageCoursesPage", "SelectIFrameRight",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Approve the course from [Assigned To Copy] State
        /// </summary>
        /// <param name="searchRadioButton">This is Search Radio Button Enum.</param>
        /// <param name="courseName">This is the Course Name.</param>
        /// <param name="dropdownOption">This is Dropdown Option.</param>
        public void ApproveAssignedToCopyState(
            SearchCoursesPage.SearchRadioButtonEnum searchRadioButton,
            String courseName, string dropdownOption)
        {
            // Approve the course from [Assigned To Copy] State
            Logger.LogMethodEntry("ManageCoursesPage", "ApproveAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Stop Watch
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                //Wait Upto Expiry Time
                while (stopWatch.Elapsed.TotalMinutes < GetTimeToWaitForAssignedToCopyState)
                {
                    //Switch to default window
                    base.SwitchToDefaultWindow();
                    //Select IFrame
                    this.SelectIFrameRight();
                    //Find Element is Present
                    if (base.IsElementPresent(By.XPath(ManageCoursesPageResource.
                        ManageCourses_Page_AssignedToCopy_Label_XPath_Locator),
                        Convert.ToInt32(ManageCoursesPageResource.
                        ManageCourses_Page_TimeOut_InSeconds)) == false) break;
                    base.SwitchToDefaultWindow();
                    //Search course
                    new SearchCoursesPage().SearchCourse(
                        searchRadioButton, courseName, dropdownOption);
                    Thread.Sleep(Convert.ToInt32(ManageCoursesPageResource.
                        ManageCourses_Page_Sleep_Time_For_AssignedToCopyState));
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "ApproveAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Verifies the [AssignedToCopy] text present even after the specified time.
        /// </summary>
        /// <returns>Assigned to copy text, if it is present after specified time.</returns>
        public String GetAssignedToCopyTextPresentAfterSpecifiedTime()
        {
            //Course [AssignedToCopy] text present after specified time
            Logger.LogMethodEntry("ManageCoursesPage",
                "GetAssignedToCopyTextPresentAfterSpecifiedTime",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized Get String Variable
            string getAssignedToCopyText = string.Empty;
            try
            {
                // Switch to window and frame
                base.SelectDefaultWindow();
                //Select IFrame
                this.SelectIFrameRight();
                //To get [AssignedToCopy] text
                bool isAssignedToCopyTextPresent = base.IsElementPresent
                    (By.XPath(ManageCoursesPageResource
                     .ManageCourses_Page_AssignedToCopy_Label_XPath_Locator),
                     Convert.ToInt32(ManageCoursesPageResource
                     .ManageCourses_Page_Custom_TimeToWait_Element));
                // Change bool value to string
                getAssignedToCopyText = isAssignedToCopyTextPresent.ToString();
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage",
                "GetAssignedToCopyTextPresentAfterSpecifiedTime",
                base.IsTakeScreenShotDuringEntryExit);
            return getAssignedToCopyText;
        }

        /// <summary>
        /// Select Course From The Right Frame.
        /// </summary>
        /// <param name="courseName">This Is The Course Name.</param>
        public void SelectCourse(String courseName)
        {
            //Selection Of Course From The Right Frame
            Logger.LogMethodEntry("ManageCoursesPage", "SelectCourse",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch To Default Window
                base.SelectDefaultWindow();
                base.WaitForElement(By.Id(ManageCoursesPageResource.
                    ManageCourses_Page_RightFrame_Id_Locator));
                //Swith To IFrame
                base.SwitchToIFrame(ManageCoursesPageResource.
                    ManageCourses_Page_RightFrame_Id_Locator);
                // Select The Course
                IWebElement masterLibraryCourse =
                    base.GetWebElementPropertiesByLinkText(courseName);
                //Click on Course Name
                base.ClickByJavaScriptExecutor(masterLibraryCourse);
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "SelectCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Searched Course Name.
        /// </summary>
        /// <returns>Course Name.</returns>
        public String GetSearchedCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Get Searched Course Name
            Logger.LogMethodEntry("ManageCoursesPage", "GetSearchedCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Variable Declaration
            string getCourseName = string.Empty;
            try
            {
                //Select Default Window
                base.SelectWindow(ManageCoursesPageResource.
                    ManageCourses_Page_Window_Name_CourseEnrollment);
                //Select IFrame
                this.SelectIFrameRight();
                if (courseTypeEnum.Equals(Course.CourseTypeEnum
                    .CopiedDigitsAuthoredCourse))
                {
                    //Get The Searched Course Name
                    base.WaitForElement(By.XPath(ManageCoursesPageResource.
                        ManageCourses_Page_SearchedCourseNameCopied_Xpath_Locator));
                    //Get the Course Name
                    getCourseName = base.GetTitleAttributeValueByXPath
                        (ManageCoursesPageResource.
                        ManageCourses_Page_SearchedCourseNameCopied_Xpath_Locator);
                }
                else
                {
                    //Get The Searched Course Name
                    base.WaitForElement(By.XPath(ManageCoursesPageResource.
                        ManageCourses_Page_SearchedCourseName_Xpath_Locator));
                    //Get the Course Name
                    getCourseName = base.GetTitleAttributeValueByXPath(ManageCoursesPageResource.
                        ManageCourses_Page_SearchedCourseName_Xpath_Locator);
                }
                //Switch To Default Page Content
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "GetSearchedCourse",
                   base.IsTakeScreenShotDuringEntryExit);
            return getCourseName;
        }

        /// <summary>
        ///Click On The Cmenu Option Of CTC Course.
        /// </summary>
        public void ClickOnTheCmenuOptionOfCTCCourse()
        {
            //Click On The Cmenu Option Of CTC Course 
            Logger.LogMethodEntry("ManageCoursesPage", "ClickOnTheCmenuOptionOfCTCCourse",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select Course Enrollment Right Frame
                new SearchCoursesPage().SelectCourseEnrollmentRightFrame();
                // Wait Untill Course Cmenu Appears
                base.WaitForElement(By.XPath(ManageCoursesPageResource.
                     ManageCourses_Page_CourseCmenu_Image_Xpath_Locator));
                //Get HTML Element Property for Cmenu
                IWebElement imageCourseCMenu = base.GetWebElementPropertiesByXPath
                    (ManageCoursesPageResource.
                    ManageCourses_Page_CourseCmenu_Image_Xpath_Locator);
                imageCourseCMenu.SendKeys(string.Empty);
                //Click on the Course CMenu 
                base.ClickByJavaScriptExecutor(imageCourseCMenu);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "ClickOnTheCmenuOptionOfCTCCourse",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Is Default Cmenu Options Displayed In CTC.
        /// </summary>
        /// <returns>Cmenu options.</returns>
        public Boolean IsDefaultCmenuOptionsDisplayedInCTC()
        {
            //Is Default Cmenu Options Displayed In CTC
            Logger.LogMethodEntry("ManageCoursesPage", "IsDefaultCmenuOptionsDisplayedInCTC",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isDefaultCmenuOptionsDisplayed = false;
            try
            {
                //Edit Course Info Cmenu options
                bool isEditCourseInfoDisplayed = base.IsElementPresent(By.PartialLinkText
                    (ManageCoursesPageResource.ManageCourses_Page_EditCourseInfo_Name));
                //Copy As Master Course Cmenu options
                bool isCopyAsMasterCourseDisplayed = base.IsElementPresent(By.PartialLinkText
                    (ManageCoursesPageResource.ManageCourses_Page_CopyASMasterCourse_Name));
                //Copy As Testing Course Cmenu options
                bool isCopyAsTestingCourseDisplayed = base.IsElementPresent(By.PartialLinkText
                    (ManageCoursesPageResource.ManageCourses_Page_CopyAsTestingCourse_Name));
                //Inactive Cmenu options
                bool isInactiveDisplayed = base.IsElementPresent(By.PartialLinkText
                    (ManageCoursesPageResource.ManageCourses_Page_InActive_Name));
                //Delete Cmenu options
                bool isDeleteDisplayed = base.IsElementPresent(By.PartialLinkText
                    (ManageCoursesPageResource.ManageCourses_Page_Delete_Name));
                isDefaultCmenuOptionsDisplayed = isEditCourseInfoDisplayed &&
                    isCopyAsMasterCourseDisplayed && isCopyAsTestingCourseDisplayed
                    && isInactiveDisplayed && isDeleteDisplayed;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "IsDefaultCmenuOptionsDisplayedInCTC",
                  base.IsTakeScreenShotDuringEntryExit);
            return isDefaultCmenuOptionsDisplayed;
        }

        /// <summary>
        /// Get Cmenu Option of Course.
        /// </summary>
        /// <returns>cMenu Options.</returns>
        public String GetCmenuOptionOfCourse()
        {
            //Get cMenu Options of Courses
            Logger.LogMethodEntry("ManageCoursesPage", "GetCmenuOptionOfCourse",
               base.IsTakeScreenShotDuringEntryExit);
            string getCmenuOptions = string.Empty;
            try
            {
                //Select Course Enrollement Window
                base.SelectWindow(ManageCoursesPageResource.
                        ManageCourses_Page_Window_Name_CourseEnrollment);
                //Select IFrame
                this.SelectIFrameRight();
                base.WaitForElement(By.XPath(ManageCoursesPageResource.
                    ManageCourses_Page_GetcMenuOption_Xpath_Locator));
                //Get Course cmenu Option
                String getCourseCmenuOptions = base.GetElementTextByXPath(ManageCoursesPageResource.
                    ManageCourses_Page_GetcMenuOption_Xpath_Locator);
                getCmenuOptions = Regex.Replace(getCourseCmenuOptions, @"\r\n\ ", string.Empty).Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "GetCmenuOptionOfCourse",
                base.IsTakeScreenShotDuringEntryExit);
            return getCmenuOptions;
        }

        /// <summary>
        /// Get Course Type.
        /// </summary>
        /// <returns>Course Type.</returns>
        public String GetCourseType()
        {
            //Get Course Type
            Logger.LogMethodEntry("ManageCoursesPage", "GetCourseType",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getCourseType = string.Empty;
            try
            {
                //Select Course Enrollement Window
                base.SelectWindow(ManageCoursesPageResource.
                        ManageCourses_Page_Window_Name_CourseEnrollment);
                base.WaitForElement(By.Id(ManageCoursesPageResource.
                    ManageCourses_Page_RightFrame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(ManageCoursesPageResource.
                    ManageCourses_Page_RightFrame_Id_Locator);
                base.WaitForElement(By.XPath(ManageCoursesPageResource.
                    ManageCourse_Page_GetCourseType_Xpath_Locator));
                //Get Course Type
                getCourseType = base.GetElementTextByXPath(ManageCoursesPageResource.
                    ManageCourse_Page_GetCourseType_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "GetCourseType",
               base.IsTakeScreenShotDuringEntryExit);
            return getCourseType;
        }

        /// <summary>
        /// Get Course Status.
        /// </summary>
        /// <returns>Course Status.</returns>
        public String GetCourseStatus()
        {
            //Get Course Status
            Logger.LogMethodEntry("ManageCoursesPage", "GetCourseStatus",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getCourseStatus = string.Empty;
            try
            {
                //Select Course Enrollement Window
                base.SelectWindow(ManageCoursesPageResource.
                        ManageCourses_Page_Window_Name_CourseEnrollment);
                //Select IFrame
                this.SelectIFrameRight();
                base.WaitForElement(By.XPath(ManageCoursesPageResource.
                    ManageCourse_page_GetCourseStatus_Xpath_Locator));
                //Get Course Status
                getCourseStatus = base.GetElementTextByXPath(ManageCoursesPageResource.
                    ManageCourse_page_GetCourseStatus_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "GetCourseStatus",
                base.IsTakeScreenShotDuringEntryExit);
            return getCourseStatus;
        }

        /// <summary>
        /// Get Date Month Year from Manage Frame.
        /// </summary>
        /// <returns>Created Date Month Year of Course.</returns>
        public String GetDateMonthYearFromManageFrame()
        {
            //Get DateMonthYear from Manage Frame
            Logger.LogMethodEntry("ManageCoursesPage", "GetDateMonthYearFromManageFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getDateMonthYear = string.Empty;
            try
            {
                //Select Course Enrollement Window
                base.SelectWindow(ManageCoursesPageResource.
                        ManageCourses_Page_Window_Name_CourseEnrollment);
                //Select IFrame
                this.SelectIFrameRight();
                base.WaitForElement(By.XPath(ManageCoursesPageResource.
                    ManageCourses_Page_GetDayMonthYear_Xpath_Locator));
                //Get DayMonthYear
                getDateMonthYear = base.GetElementTextByXPath(ManageCoursesPageResource.
                    ManageCourses_Page_GetDayMonthYear_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "GetDateMonthYearFromManageFrame",
              base.IsTakeScreenShotDuringEntryExit);
            return getDateMonthYear;
        }

        /// <summary>
        /// Get New Search Button Name.
        /// </summary>
        /// <returns>New Search Button Name.</returns>
        public String GetNewSearchButtonName()
        {
            //Get New Search Button Name
            Logger.LogMethodEntry("ManageCoursesPage", "GetNewSearchButtonName",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getNewSearchButtonText = string.Empty;
            try
            {
                //Select Course Enrollement Window
                base.SelectWindow(ManageCoursesPageResource.
                            ManageCourses_Page_Window_Name_CourseEnrollment);
                base.WaitForElement(By.Id(ManageCoursesPageResource.
                    ManageCourses_Page_NewSearch_Id_Locator));
                //Get New Search Button Text 
                getNewSearchButtonText = base.GetElementTextById(ManageCoursesPageResource.
                    ManageCourses_Page_NewSearch_Id_Locator);
                string[] getNewSearchButton = getNewSearchButtonText.Split(Convert.ToChar(
                    ManageCoursesPageResource.ManageCourses_Page_SpecialCharacter_NewSearch_Value));
                //Get Splitted New Search Button Text
                getNewSearchButtonText = getNewSearchButton[Convert.ToInt32(ManageCoursesPageResource.
                    ManageCourses_Page_NewSearchButton_Split_Value)].Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "GetNewSearchButtonName",
             base.IsTakeScreenShotDuringEntryExit);
            return getNewSearchButtonText;
        }

        /// <summary>
        /// Get Delete Selected Course Button Name.
        /// </summary>
        /// <returns>Delete Selected Course Button Name.</returns>
        public String GetDeleteSelectedCoursesButtonName()
        {
            //Get Delete Course Button Name
            Logger.LogMethodEntry("ManageCoursesPage", "GetDeleteSelectedCoursesButtonName",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getDeleteSelectedCourseButtonText = string.Empty;
            try
            {
                //Select Course Enrollement WIndow
                base.SelectWindow(ManageCoursesPageResource.
                            ManageCourses_Page_Window_Name_CourseEnrollment);
                //Select IFrame
                this.SelectIFrameRight();
                base.WaitForElement(By.Id(ManageCoursesPageResource.
                    ManageCourses_Page_DeleteSelectedCourses_Id_Locator));
                //Get Delete Course Button
                getDeleteSelectedCourseButtonText = base.GetElementTextById(ManageCoursesPageResource.
                    ManageCourses_Page_DeleteSelectedCourses_Id_Locator).Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "GetDeleteSelectedCoursesButtonName",
             base.IsTakeScreenShotDuringEntryExit);
            return getDeleteSelectedCourseButtonText;
        }

        /// <summary>
        /// Fetch And Store Course Workspace Id.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        public void FetchAndStoreCourseWorkspaceId(Course.CourseTypeEnum courseTypeEnum)
        {
            //Fetch And Store Course Workspace Id
            Logger.LogMethodEntry("ManageCoursesPage", "FetchAndStoreCourseWorkspaceId",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Initialize Variable
                string getWorkspaceId = string.Empty;
                //Select Course Enrollment Window.
                this.SelectCourseEnrollmentWindow();
                //Select Right Frame
                this.SelectIFrameRight();
                base.WaitForElement(By.XPath(ManageCoursesPageResource.
                    ManageCourses_Page_Workspace_Id_Xpath_Locator));
                //Fetch Workspace Id
                getWorkspaceId = base.GetElementTextByXPath(ManageCoursesPageResource.
                    ManageCourses_Page_Workspace_Id_Xpath_Locator);
                //Store Workspace Id
                this.StoreWorkspaceId(courseTypeEnum, getWorkspaceId);  
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "FetchAndStoreCourseWorkspaceId",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Workspace Id.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        /// <param name="getWorkspaceId">This is WorkSpace Id.</param>
        private void StoreWorkspaceId
            (Course.CourseTypeEnum courseTypeEnum, string getWorkspaceId)
        {
            //Store Workspace Id
            Logger.LogMethodEntry("ManageCoursesPage", "StoreWorkspaceId",
            base.IsTakeScreenShotDuringEntryExit);
            //Store Workspace Id
            Course course = Course.Get(courseTypeEnum);
            course.WorkSpaceId = getWorkspaceId;
            Logger.LogMethodExit("ManageCoursesPage", "StoreWorkspaceId",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Enrollment Window.
        /// </summary>
        private void SelectCourseEnrollmentWindow()
        {
            //Select Course Enrollment Window
            Logger.LogMethodEntry("ManageCoursesPage", "SelectCourseEnrollmentWindow",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ManageCoursesPageResource.
                            ManageCourses_Page_Window_Name_CourseEnrollment);
            //Select Window
            base.SelectWindow(ManageCoursesPageResource.
                            ManageCourses_Page_Window_Name_CourseEnrollment);           
            Logger.LogMethodExit("ManageCoursesPage", "SelectCourseEnrollmentWindow",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Column Headers In Manage Course Frame.
        /// </summary>
        /// <returns>Column Headers In Manage Course Frame.</returns>
        public String GetColumnHeadersInManageCourseFrame()
        {
            //Get Column Headers In Manage Course Frame
            Logger.LogMethodEntry("ManageCoursesPage", "GetColumnHeadersInManageCourseFrame",
             base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getColumnHeadersText = string.Empty;            
            try
            {
                //Select Course Enrollment Window
                this.SelectCourseEnrollmentWindow();
                //Select Right Frame
                this.SelectIFrameRight();
                base.WaitForElement(By.XPath(ManageCoursesPageResource.
                    ManageCourses_Page_ColumnHeader_Count_Xpath));
                //Get Column Header Count
                int getColumnHeadersCount = base.GetElementCountByXPath(ManageCoursesPageResource.
                    ManageCourses_Page_ColumnHeader_Count_Xpath);
                for (int headerCount = Convert.ToInt32(ManageCoursesPageResource.
                    ManageCourses_Page_Loop_Initial_Value);
                    headerCount <= getColumnHeadersCount; headerCount++)
                {
                    //Focus On Element
                    base.FocusOnElementByXPath(ManageCoursesPageResource.
                        ManageCourses_Page_CourseCmenu_Image_Xpath_Locator);
                    //Get Column Header Text
                    getColumnHeadersText += base.GetElementTextByXPath(string.Format(
                        ManageCoursesPageResource.
                        ManageCourses_Page_Column_Header_Xpath_Locator, headerCount));
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "GetColumnHeadersInManageCourseFrame",
             base.IsTakeScreenShotDuringEntryExit);
            return getColumnHeadersText;
        }

        /// <summary>
        /// Delete The Created Course In Manage Course Frame.
        /// </summary>
        public void DeleteTheCreatedCourseInManageCourseFrame()
        {
            //Delete The Created Course In Manage Course Frame
            Logger.LogMethodEntry("ManageCoursesPage",
                "DeleteTheCreatedCourseInManageCourseFrame",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Default Window
                base.SelectWindow(ManageCoursesPageResource.
                    ManageCourses_Page_Window_Name_CourseEnrollment);
                //Select IFrame
                this.SelectIFrameRight();
                //Select Course Checkbox
                this.SelectCourseCheckbox();
                //Select Delete Course Link
                this.ClickOnDeleteCourseLink();                
                //Click The Pegasus Alert Ok Button
                this.ClickThePegasusAlertOkButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }           
            Logger.LogMethodExit("ManageCoursesPage",
                "DeleteTheCreatedCourseInManageCourseFrame",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Pegasus Alert Ok Button.
        /// </summary>
        private void ClickThePegasusAlertOkButton()
        {
            //Click The Pegasus Alert Ok Button
            Logger.LogMethodEntry("ManageCoursesPage","ClickThePegasusAlertOkButton",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ManageCoursesPageResource.
                    ManageCourses_Page_Pegasus_WindowName);
            base.SelectWindow(ManageCoursesPageResource.
                ManageCourses_Page_Pegasus_WindowName);
            //Wait for the element
            base.WaitForElement(By.Id(ManageCoursesPageResource.
                ManageCourses_Page_PegasusAlert_OkButton_Id_Locator));
            IWebElement getOkButton = base.GetWebElementPropertiesById
                (ManageCoursesPageResource.
                ManageCourses_Page_PegasusAlert_OkButton_Id_Locator);
            //Select the Delete link
            base.ClickByJavaScriptExecutor(getOkButton);
            Thread.Sleep(Convert.ToInt32(ManageCoursesPageResource.
                ManageCourses_Page_WaitElement_Value));
            Logger.LogMethodExit("ManageCoursesPage", "ClickThePegasusAlertOkButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Delete Course Link.
        /// </summary>
        private void ClickOnDeleteCourseLink()
        {
            //Click On Delete Course Link
            Logger.LogMethodEntry("ManageCoursesPage", "ClickOnDeleteCourseLink",
             base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(ManageCoursesPageResource.
                ManageCourses_Page_DeleteLink_Id_Locator));
            IWebElement getSelectDeleteLink = base.GetWebElementPropertiesById
                (ManageCoursesPageResource.
                ManageCourses_Page_DeleteLink_Id_Locator);
            //Select the Delete link
            base.ClickByJavaScriptExecutor(getSelectDeleteLink);
            Logger.LogMethodExit("ManageCoursesPage", "ClickOnDeleteCourseLink",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Checkbox.
        /// </summary>
        private void SelectCourseCheckbox()
        {
            //Select Course Checkbox
            Logger.LogMethodEntry("ManageCoursesPage", "SelectCourseCheckbox",
             base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(ManageCoursesPageResource.
                ManageCourses_Page_SelectCourseCheckbox_Id_Locator));
            IWebElement getSelectCourseCheckbox = base.GetWebElementPropertiesById
                (ManageCoursesPageResource.
                ManageCourses_Page_SelectCourseCheckbox_Id_Locator);
            //Select the checkbox
            base.ClickByJavaScriptExecutor(getSelectCourseCheckbox);
            Logger.LogMethodExit("ManageCoursesPage","SelectCourseCheckbox",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Message In Manage Course Frame.
        /// </summary>
        /// <param name="message">This is Course message.</param>
        /// <returns>Message.</returns>
        public string GetMessageInManageCourseFrame(string message)
        {
            //Get Message In Manage Course Frame
            Logger.LogMethodEntry("ManageCoursesPage", "GetMessageInManageCourseFrame",
             base.IsTakeScreenShotDuringEntryExit);
            //Variable Declaration
            string getCourseMessage = string.Empty;
            try
            {
                this.SelectCourseEnrollementWindow();
                //Select IFrame
                this.SelectIFrameRight();
                base.WaitForElement(By.XPath(ManageCoursesPageResource.
                    ManageCourses_Page_Message_Course_Xpath_Locator));
                //Get New Search Button Text 
                getCourseMessage = base.GetElementTextByXPath(ManageCoursesPageResource.
                    ManageCourses_Page_Message_Course_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageCoursesPage", "GetMessageInManageCourseFrame",
            base.IsTakeScreenShotDuringEntryExit);
            return getCourseMessage;
        }
    }
}
