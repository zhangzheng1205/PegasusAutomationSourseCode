using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.eCollege;
using Pegasus.Pages.UI_Pages.Integration.eCollege.CampusAdmin;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handle Course creation 
    /// action on ECollege portal. 
    /// </summary>
    public class SingleCrsCreationBottomPage : BasePage
    {
        /// <summary>
        /// The Static instance of the Logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(SingleCrsCreationBottomPage));

        /// <summary>
        /// Create ECollege Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        public void CreateSingleCourseRequest(
            Course.CourseTypeEnum courseTypeEnum)
        {
            Logger.LogMethodEntry("SingleCrsCreationBottomPage",
                "CreateSingleCourseRequest", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Frame
                this.SelectBottomContentAreaFrame();
                //Select Enrollable Area Drop Down Value
                this.EnterCourseInformation();
                //Enter Course Code of ECollege Course 
                this.EnterCoureCode();
                //Enter Display Course Code of ECollege Course
                this.EnterDisplayCourseCode();
                //Enter Course Tilte of ECollege Course
                String getCourseTitle = this.EnterCourseTitle();
                //Enter Course Credit Information
                this.EnterCourseCreditInformation();
                //Click On Next Button
                this.ClickNextCourseButton();
                //Submit The Course Information
                this.SubmitPreviewCourseInformation();
                //Strore Course Information In Memory
                this.StoreECollegeCourseInformationInMemory
                    (getCourseTitle, courseTypeEnum);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
                "CreateSingleCourseRequest", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Course Preview Information.
        /// </summary>
        private void SubmitPreviewCourseInformation()
        {
            //Submit The Course
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
              "SubmitPreviewCourseInformation", base.isTakeScreenShotDuringEntryExit);
            //Click on Submit Button 
            base.WaitForElement(By.Name(SingleCrsCreationBottomPageResource
                                            .SingleCrsCreationBottom_Page_Submit_Button_Name_Locator));
            //Click on Button
            base.SelectButtonByName(SingleCrsCreationBottomPageResource
                                       .SingleCrsCreationBottom_Page_Submit_Button_Name_Locator);
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
              "SubmitPreviewCourseInformation", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Next Course Button.
        /// </summary>
        private void ClickNextCourseButton()
        {
            //Click Next Button
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
               "ClickNextCourseButton", base.isTakeScreenShotDuringEntryExit);
            //Select Top Content Area frame
            SelectTopContentAreaFrame();
            //Wait for Next Button 
            base.WaitForElement(By.Name(
                SingleCrsCreationBottomPageResource.
                    SingleCrsCreationBottom_Page_Next_button_Name_Locator));
            //Click on Next Button 
            base.SelectButtonByName(SingleCrsCreationBottomPageResource.
                     SingleCrsCreationBottom_Page_Next_button_Name_Locator);
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
               "ClickNextCourseButton", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Course Credit Information.
        /// </summary>
        private void EnterCourseCreditInformation()
        {
            //Enter Course Credit Information
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
                "EnterCourseCreditInformation", base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            WaitForElement(By.Name(SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_CreditContactHours_TextBox_Name_Locator));
            //Fill Text in TextBox
            base.FillTextBoxByName(SingleCrsCreationBottomPageResource.
                 SingleCrsCreationBottom_Page_CreditContactHours_TextBox_Name_Locator,
                  SingleCrsCreationBottomPageResource.
                  SingleCrsCreationBottom_Page_CreditContactHours_Value);
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
                "EnterCourseCreditInformation", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Top Content Area Frame To 
        /// Enter Course Information. 
        /// </summary>
        private void SelectTopContentAreaFrame()
        {
            Logger.LogMethodEntry("SingleCrsCreationBottomPage",
                "SelectTopContentAreaFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectAdministrationPagesWindow();
            //Select Frame Content
            base.SwitchToIFrame(SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_Content_Frame_Name_Locator);
            // Select TopContentArea Frame
            base.SwitchToIFrame(SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_TopContentArea_Frame_Name_Locator);
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
                "SelectTopContentAreaFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter course information that will be 
        /// referenced by your online institution.
        /// </summary>
        private void EnterCourseInformation()
        {
            //Enter Course Information
            Logger.LogMethodEntry("SingleCrsCreationBottomPage",
                "EnterCourseInformation",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Name(
                SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_EnrollableArea_DropDown_Name_Locator));
            //Select TPI Cert in Enrollable Drop down 
            base.SelectDropDownValueThroughTextByName(
                SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_EnrollableArea_DropDown_Name_Locator,
                SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_EnrollableCourse_DropDown_Value);
            //Select Exiting Term from Term Drop Down.
            base.SelectDropDownValueThroughTextByName(
                SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_Term_Dropdown_Name_Locator,
                SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_ExistingTerm_Name_Locator);
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
                "EnterCourseInformation",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to Bottom Content Area Frame on 
        /// Enter Course Information. 
        /// </summary>
        private void SelectBottomContentAreaFrame()
        {
            //Select Frame
            Logger.LogMethodEntry("SingleCrsCreationBottomPage",
                "SelectBottomContentAreaFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectAdministrationPagesWindow();
            //Select Frame Content
            base.SwitchToIFrame(SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_Content_Frame_Name_Locator);
            //Select Frame 'BottomContentArea'
            base.SwitchToIFrame(SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_BottomContentArea_Frame_Name_Locator);
            //Wait for Enrollable Area Drop Down
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
                "SelectBottomContentAreaFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Display Course Code Information of ECollege Course.
        /// </summary>
        private void EnterDisplayCourseCode()
        {
            //Enter Display Course Code Information
            Logger.LogMethodEntry("SingleCrsCreationBottomPage",
                "EnterDisplayCourseCode",
                base.isTakeScreenShotDuringEntryExit);
            //Genrate guid for Display Course Code
            Guid generateDispalyCourseCode = Guid.NewGuid();
            base.WaitForElement(By.Name(SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_DisplayCourseCode_TextBox_Name_Locator));
            //Enter Text In TextBox
            base.FillTextBoxByName(SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_DisplayCourseCode_TextBox_Name_Locator,
                    generateDispalyCourseCode.ToString());
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
                "EnterDisplayCourseCode",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Course Code of ECollege Course.
        /// </summary>
        private void EnterCoureCode()
        {
            //Enter Course Code
            Logger.LogMethodEntry("SingleCrsCreationBottomPage", "EnterCoureCode",
                base.isTakeScreenShotDuringEntryExit);
            //Generate Course Code
            String getCourseCode = base.GetRandomNumber(SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_CourseCode_CharacterSet, 5);
            //Wait For Element
            base.WaitForElement(By.Name(
                SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_CourseCode_TextBox_Name_Locator));
            //Enter Course Code In TextBox
            base.FillTextBoxByName(SingleCrsCreationBottomPageResource.
                  SingleCrsCreationBottom_Page_CourseCode_TextBox_Name_Locator,
                  getCourseCode);
            Logger.LogMethodExit("SingleCrsCreationBottomPage", "EnterCoureCode",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Course Title of ECollege Course.
        /// </summary>
        private String EnterCourseTitle()
        {
            Logger.LogMethodEntry("SingleCrsCreationBottomPage",
                "EnterCourseTitle", base.isTakeScreenShotDuringEntryExit);
            //Genrate guid for Course tilte 
            Guid generateCourseTitleGuid = Guid.NewGuid();
            // Wait for Element 
            base.WaitForElement(By.Name(
                SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_CourseTitle_TextBox_Name_Locator));
            //Enter Course Title 
            base.FillTextBoxByName(SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_CourseTitle_TextBox_Name_Locator,
                generateCourseTitleGuid.ToString());
            //Log course name in logger file
            CourseName = generateCourseTitleGuid.ToString();
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
                "EnterCourseTitle", base.isTakeScreenShotDuringEntryExit);
            return generateCourseTitleGuid.ToString();
        }

        /// <summary>
        /// Select Administration Pages Window.
        /// </summary>
        private void SelectAdministrationPagesWindow()
        {
            //Select Window
            Logger.LogMethodEntry("SingleCrsCreationBottomPage",
             "SelectAdministrationPagesWindow", base.isTakeScreenShotDuringEntryExit);
            //Wait For Window Gets Load
            base.WaitUntilWindowLoads(SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_AdministrationPages_Window_Title);
            //Select Administration Pages
            base.SelectWindow(SingleCrsCreationBottomPageResource.
                SingleCrsCreationBottom_Page_AdministrationPages_Window_Title);
            Logger.LogMethodEntry("SingleCrsCreationBottomPage",
             "SelectAdministrationPagesWindow", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Course Information In Memory.
        /// </summary>
        /// <param name="courseName">This is course name.</param>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        private void StoreECollegeCourseInformationInMemory(
            String courseName, Course.CourseTypeEnum courseTypeEnum)
        {
            //Save Course in Memory
            Logger.LogMethodEntry("SingleCrsCreationBottomPage",
                "StoreECollegeCourseInformationInMemory",
                base.isTakeScreenShotDuringEntryExit);
            //Save Course Properties in Memory
            Course newCourse = new Course
            {
                Name = courseName,
                CourseType = courseTypeEnum,
                IsCreated = true,
            };
            //Save the Course Name
            newCourse.StoreCourseInMemory();
            Logger.LogMethodExit("SingleCrsCreationBottomPage",
                "StoreECollegeCourseInformationInMemory",
                base.isTakeScreenShotDuringEntryExit);

        }
    }
}