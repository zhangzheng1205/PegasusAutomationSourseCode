using System;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Course;
using System.Text.RegularExpressions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Search Courses Page Actions.
    /// </summary>
    public class SearchCoursesPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(SearchCoursesPage));

        /// <summary>
        /// This the enum available for Display All Link type Enum.
        /// </summary>
        public enum DisplayAllLinkTypeEnum
        {
            /// <summary>
            /// Asset type for EnrollmentUsers
            /// </summary>
            EnrollmentDisplayAllUsers = 1,
            /// <summary>
            /// Asset type for EnrollmentCourses
            /// </summary>
            EnrollmentDisplayAllCourses = 2,
            /// <summary>
            ///  Asset type for AdministratorsUsers
            /// </summary>
            AdministratorsDisplayAllUsers = 3,
        }

        /// <summary>
        /// This the enum for manage course frame buttons.
        /// </summary>
        public enum ManageCourseFrameButtons
        {
            /// <summary>
            /// CreateNewCourse button
            /// </summary>
            CreateNewCourse = 1,
            /// <summary>
            /// DisplayAllCourses button
            /// </summary>
            DisplayAllCourses = 2,
            /// <summary>
            ///  Search Button
            /// </summary>
            Search = 3,
        }

        /// <summary>
        /// This the enum for search radio button.
        /// </summary>
        public enum SearchRadioButtonEnum
        {
            /// <summary>
            /// Course Name Radio button
            /// </summary>
            CourseName = 1,
            /// <summary>
            /// WorkSpace Id Radio button
            /// </summary>
            WSId = 2,
        }

        /// <summary>
        /// Search Course In Right Frame.
        /// </summary>
        /// <param name="searchCriteriaRadioButtonEnum">This is search criteria radio button option.</param>
        /// <param name="searchParameter">This is search Parameter.</param>
        /// <param name="dropdownOptionName">This is Dropdown Option Name.</param>
        public void SearchCourse(SearchRadioButtonEnum searchCriteriaRadioButtonEnum,
            String searchParameter, String dropdownOptionName)
        {
            //Search Course and Course Found in Course Grid
            Logger.LogMethodEntry("SearchCoursesPage", "SearchCourse",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectCourseEnrollmentWindow();
                //Click on New Searck Link
                this.ClickOnNewSearchLink();
                //Select Right Frame
                this.SelectIFrameRight();
                //Select Radio Button
                this.SelectRadioButton(searchCriteriaRadioButtonEnum);
                //Select Dropdown Option
                this.SelectFilterDropdownOption(dropdownOptionName);
                //Enter Search Parameter In the Search Box
                this.EnterSearchParameterInTheSearchBox(searchParameter);
                //Click on Search Button
                this.ClickOnSearchButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SearchCoursesPage", "SearchCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Radio Button.
        /// </summary>
        /// <param name="searchRadioButton">This is Search Radio Button.</param>
        private void SelectRadioButton(
            SearchRadioButtonEnum searchRadioButton)
        {
            //Select Radio Button
            Logger.LogMethodEntry("SearchCoursesPage", "SelectRadioButton",
               base.isTakeScreenShotDuringEntryExit);
            switch (searchRadioButton)
            {
                case SearchRadioButtonEnum.CourseName:
                    base.WaitForElement(By.Id(SearchCoursesPageResource
                     .SearchCourses_Page_CourseName_RadioButton_Id));
                    //Select Course Name Radio Button
                    base.SelectRadioButtonById(SearchCoursesPageResource
                     .SearchCourses_Page_CourseName_RadioButton_Id);
                    break;
                case SearchRadioButtonEnum.WSId:
                    base.WaitForElement(By.Id(SearchCoursesPageResource.
                    SearchCourses_Page_WSId_RadioButton_Id));
                    //Select Course Name Radio Button
                    base.SelectRadioButtonById((SearchCoursesPageResource.
                    SearchCourses_Page_WSId_RadioButton_Id));
                    break;
            }
            Logger.LogMethodExit("SearchCoursesPage", "SelectRadioButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Enrollment Window.
        /// </summary>
        private void SelectCourseEnrollmentWindow()
        {
            //Select Window
            Logger.LogMethodEntry("SearchCoursesPage", "SelectCourseEnrollmentWindow",
              base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(SearchCoursesPageResource.
                                  SearchCourses_Page_Window_Name_CourseEnrollment);
            Logger.LogMethodExit("SearchCoursesPage", "SelectCourseEnrollmentWindow",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On New Search Link.
        /// </summary>
        private void ClickOnNewSearchLink()
        {
            //Click On New Search Link
            Logger.LogMethodEntry("SearchCoursesPage", "ClickOnNewSearchLink",
             base.isTakeScreenShotDuringEntryExit);
            //Click On Search Link if Displaying
            if (base.GetWebElementPropertiesById(SearchCoursesPageResource.
                                                     SearchCourses_Page_Search_Link_Id_Locator).Displayed)
            {
                //Wait For Element
                base.WaitForElement(By.Id(SearchCoursesPageResource.
                                          SearchCourses_Page_Search_Link_Id_Locator));
                //Submit Button
                base.SubmitButtonById(SearchCoursesPageResource.
                                          SearchCourses_Page_Search_Link_Id_Locator);
                //Pause For Sleep Time 
                Thread.Sleep(Convert.ToInt32
                    (SearchCoursesPageResource.SearchCourses_Page_SleepTime_Value));
            }
            Logger.LogMethodExit("SearchCoursesPage", "ClickOnNewSearchLink",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select IFrame.
        /// </summary>
        private void SelectIFrameRight()
        {
            //Select IFrame Right
            Logger.LogMethodEntry("SearchCoursesPage", "SelectIFrameRight",
             base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(SearchCoursesPageResource.
                                          SearchCourses_Page_RightFrame_Id_Locator));
            // Switch To Right Frame
            base.SwitchToIFrame(SearchCoursesPageResource.
                                    SearchCourses_Page_RightFrame_Id_Locator);
            Logger.LogMethodExit("SearchCoursesPage", "SelectIFrameRight",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Search Button.
        /// </summary>
        private void ClickOnSearchButton()
        {
            //Click on Course Search Button
            Logger.LogMethodEntry("SearchCoursesPage", "ClickOnSearchButton",
             base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(SearchCoursesPageResource.
                                             SearchCourses_Page_CourseSearch_Image_XPath_Locator));
            //Get Image Button Property
            IWebElement getImageProperty = base.GetWebElementPropertiesByXPath(
                SearchCoursesPageResource.
                                       SearchCourses_Page_CourseSearch_Image_XPath_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getImageProperty);
            Logger.LogMethodExit("SearchCoursesPage", "ClickOnSearchButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Search parameter In Search Box.
        /// </summary>
        /// <param name="searchParameter">This is a search parameter name.</param>
        private void EnterSearchParameterInTheSearchBox(
            String searchParameter)
        {
            //Enter Search parameter In Search Box
            Logger.LogMethodEntry("SearchCoursesPage", "EnterSearchParameterInTheSearchBox",
              base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(SearchCoursesPageResource.
                                     SearchCourses_Page_CourseDetail_TextBox_Id_Locator));
            //Enter Search parameter
            base.FillTextBoxByID(SearchCoursesPageResource.
                                     SearchCourses_Page_CourseDetail_TextBox_Id_Locator, searchParameter);
            Logger.LogMethodExit("SearchCoursesPage", "EnterSearchParameterInTheSearchBox",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click On The Display All Link Button
        /// </summary>
        ///<param name="displayAllLinkTypeEnum">This is display link type</param>
        public void ClickOnTheDisplayAllLinkButton
            (DisplayAllLinkTypeEnum displayAllLinkTypeEnum)
        {
            //Click On The Display All Link Button
            Logger.LogMethodEntry("SearchCoursesPage", "ClickOnTheDisplayAllLinkButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (displayAllLinkTypeEnum)
                {
                    //This is for "Display All Courses" button
                    case DisplayAllLinkTypeEnum.EnrollmentDisplayAllCourses:
                        //Select Course Enrollment Right Frame
                        this.SelectCourseEnrollmentRightFrame();
                        break;
                    //This is for "Display All Users" button
                    case DisplayAllLinkTypeEnum.AdministratorsDisplayAllUsers:
                        //Select Administators Frame
                        this.SelectAdministatorsFrame();
                        break;
                }
                //Click Display All Link
                this.ClickDisplayAllLink();
                switch (displayAllLinkTypeEnum)
                {
                    //Select the Course Enrollment window
                    case DisplayAllLinkTypeEnum.EnrollmentDisplayAllCourses:
                        base.SelectWindow(SearchCoursesPageResource.
                              SearchCourses_Page_Window_Name_CourseEnrollment);
                        break;
                    //Select the Administrators Tool window
                    case DisplayAllLinkTypeEnum.AdministratorsDisplayAllUsers:
                        base.SelectWindow(SearchCoursesPageResource.
                              SearchCourses_Page_Window_Name_Administators);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SearchCoursesPage", "ClickOnTheDisplayAllLinkButton",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Display All Link
        /// </summary>
        private void ClickDisplayAllLink()
        {
            //Click Display All Link
            Logger.LogMethodEntry("SearchCoursesPage", "ClickDisplayAllLink",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.ClassName(SearchCoursesPageResource.
                SearchCourses_Page_Displayallcourse_Button_Class_Locator));
            base.FocusOnElementByClassName(SearchCoursesPageResource.
                SearchCourses_Page_Displayallcourse_Button_Class_Locator);
            //Get web element
            IWebElement getDisplayallcourse = base.GetWebElementPropertiesByClassName
                (SearchCoursesPageResource.
                SearchCourses_Page_Displayallcourse_Button_Class_Locator);
            //Click the Display all course button
            base.ClickByJavaScriptExecutor(getDisplayallcourse);
            Thread.Sleep(Convert.ToInt32(SearchCoursesPageResource.
                            SearchCourses_Page_Search_Time_Value));
            Logger.LogMethodExit("SearchCoursesPage", "ClickDisplayAllLink",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Enrollment Right Frame
        /// </summary>
        public void SelectCourseEnrollmentRightFrame()
        {
            //Select Course Enrollment Right Frame
            Logger.LogMethodEntry("SearchCoursesPage", "SelectCourseEnrollmentRightFrame",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the window
                base.WaitUntilWindowLoads(SearchCoursesPageResource.
                    SearchCourses_Page_Window_Name_CourseEnrollment);
                base.SelectWindow(SearchCoursesPageResource.
                    SearchCourses_Page_Window_Name_CourseEnrollment);
                //Select Frrame
                base.SwitchToIFrame(SearchCoursesPageResource.
                    SearchCourses_Page_RightFrame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SearchCoursesPage", "SelectCourseEnrollmentRightFrame",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Administators Frame
        /// </summary>
        private void SelectAdministatorsFrame()
        {
            //Select Administators Frame
            Logger.LogMethodEntry("SearchCoursesPage", "SelectAdministatorsFrame",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the window
                base.WaitUntilWindowLoads(SearchCoursesPageResource.
                       SearchCourses_Page_Window_Name_Administators);
                base.SelectWindow(SearchCoursesPageResource.
                    SearchCourses_Page_Window_Name_Administators);
                //Select Frrame
                base.SwitchToIFrame(SearchCoursesPageResource.
                    SearchCourses_Page_LeftFrame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SearchCoursesPage", "SelectAdministatorsFrame",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify button availability in manage course frame
        /// </summary>
        /// <param name="manageFrameButtons">This is manage Frame button</param>
        /// <param name="getButtonName">This is the button name</param>
        /// <returns>True of False</returns>
        public Boolean IsButtonDisplayed(
            ManageCourseFrameButtons manageFrameButtons,
            String getButtonName)
        {
            //Select Administators Frame
            Logger.LogMethodEntry("SearchCoursesPage", "IsButtonDisplayed",
               base.isTakeScreenShotDuringEntryExit);
            bool isButtonDisplayed = false;
            try
            {
                //Wait for the window
                base.WaitUntilWindowLoads(SearchCoursesPageResource.
                       SearchCourses_Page_Window_Name_CourseEnrollment);
                base.SelectWindow(SearchCoursesPageResource.
                    SearchCourses_Page_Window_Name_CourseEnrollment);
                //Select Frame
                base.SwitchToIFrame(SearchCoursesPageResource.
                    SearchCourses_Page_RightFrame_Id_Locator);
                switch (manageFrameButtons)
                {
                    // Create new course button
                    case ManageCourseFrameButtons.CreateNewCourse:
                        isButtonDisplayed =
                base.IsElementDisplayedByPartialLinkText(SearchCoursesPageResource.
                SearchCourses_Page_CreateNewCourses_PartialLinkText);
                        break;

                    // Display all courses button
                    case ManageCourseFrameButtons.DisplayAllCourses:
                        isButtonDisplayed =
                  base.IsElementDisplayedByPartialLinkText(SearchCoursesPageResource.
                  SearchCourses_Page_DisplayAllCourses_PartialLinkText);
                        break;

                    // Search button
                    case ManageCourseFrameButtons.Search:
                        isButtonDisplayed = base.IsElementPresent
                        (By.XPath(SearchCoursesPageResource.
                        SearchCourses_Page_CourseSearch_Image_XPath_Locator));
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SearchCoursesPage", "IsButtonDisplayed",
                 base.isTakeScreenShotDuringEntryExit);
            return isButtonDisplayed;
        }

        /// <summary>
        /// Verify radio button availability in manage course frame
        /// </summary>
        /// <param name="getRadioButtonName">This is the radio button</param>
        /// <returns>True of False</returns>
        public Boolean IsRadioButtonDisplayed(
            String getRadioButtonName)
        {
            //Select Administators Frame
            Logger.LogMethodEntry("SearchCoursesPage", "IsRadioButtonDisplayed",
               base.isTakeScreenShotDuringEntryExit);
            bool isRadioButtonDisplayed = false;
            try
            {
                //Wait for the window
                base.WaitUntilWindowLoads(SearchCoursesPageResource.
                       SearchCourses_Page_Window_Name_CourseEnrollment);
                base.SelectWindow(SearchCoursesPageResource.
                    SearchCourses_Page_Window_Name_CourseEnrollment);
                //Select Frrame
                base.SwitchToIFrame(SearchCoursesPageResource.
                    SearchCourses_Page_RightFrame_Id_Locator);
                isRadioButtonDisplayed =
                      base.IsElementPresent(By.Id(SearchCoursesPageResource
                      .SearchCourses_Page_CourseName_RadioButton_Id));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SearchCoursesPage", "IsRadioButtonDisplayed",
                 base.isTakeScreenShotDuringEntryExit);
            return isRadioButtonDisplayed;
        }

        /// <summary>
        /// Verify Display of text field in manage course frame
        /// </summary>
        /// <returns>True of False</returns>
        public Boolean IsTextFieldPresentInCourseFrame()
        {
            //Select Administators Frame
            Logger.LogMethodEntry("SearchCoursesPage", "IsTextFieldPresentInCourseFrame",
               base.isTakeScreenShotDuringEntryExit);
            bool isTextFieldDisplayed = false;
            try
            {
                //Wait for the window
                base.WaitUntilWindowLoads(SearchCoursesPageResource.
                       SearchCourses_Page_Window_Name_CourseEnrollment);
                base.SelectWindow(SearchCoursesPageResource.
                    SearchCourses_Page_Window_Name_CourseEnrollment);
                //Select Frrame
                base.SwitchToIFrame(SearchCoursesPageResource.
                    SearchCourses_Page_RightFrame_Id_Locator);
                // Verify if the text field is displayed
                isTextFieldDisplayed =
                      base.IsElementPresent(By.Id(SearchCoursesPageResource
                      .SearchCourses_Page_TextBox_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SearchCoursesPage", "IsTextFieldPresentInCourseFrame",
                 base.isTakeScreenShotDuringEntryExit);
            return isTextFieldDisplayed;
        }

        /// <summary>
        /// Verify Display of filters in manage course frame
        /// </summary>
        /// <returns>Filters Name</returns>
        public String GetFiltersName()
        {
            //Get Filters name in manage course frame
            Logger.LogMethodEntry("SearchCoursesPage", "GetFiltersName",
               base.isTakeScreenShotDuringEntryExit);
            String getAllFilters = string.Empty;
            try
            {
                //Wait for the window
                base.WaitUntilWindowLoads(SearchCoursesPageResource.
                       SearchCourses_Page_Window_Name_CourseEnrollment);
                base.SelectWindow(SearchCoursesPageResource.
                    SearchCourses_Page_Window_Name_CourseEnrollment);
                //Select Frrame
                base.SwitchToIFrame(SearchCoursesPageResource.
                    SearchCourses_Page_RightFrame_Id_Locator);
                // Get filters name 
                String getFiltersName = base.GetElementTextByID(SearchCoursesPageResource
                                                                    .SearchCourses_Page_FiltersDropDown_Id_Locator);
                getAllFilters = Regex.Replace(getFiltersName, @"\s*", string.Empty).Trim();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SearchCoursesPage", "GetFiltersName",
                 base.isTakeScreenShotDuringEntryExit);
            return getAllFilters;
        }

        /// <summary>
        /// Select Filter Dropdown Option.
        /// </summary>
        /// <param name="dropdownOption">This is Filter Dropdown Option.</param>
        private void SelectFilterDropdownOption(String dropdownOption)
        {
            //Select Filter Dropdown Option
            Logger.LogMethodEntry("SearchCoursesPage", "SelectFilterDropdownOption",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(SearchCoursesPageResource
                .SearchCourses_Page_FiltersDropDown_Id_Locator));
            //Select Dropdown Option
            base.SelectDropDownValueThroughTextByID(SearchCoursesPageResource
                .SearchCourses_Page_FiltersDropDown_Id_Locator, dropdownOption);
            Logger.LogMethodExit("SearchCoursesPage", "SelectFilterDropdownOption",
                 base.isTakeScreenShotDuringEntryExit);
        }

    }
}
