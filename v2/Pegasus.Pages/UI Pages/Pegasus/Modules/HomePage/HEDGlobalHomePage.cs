using System;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using System.Diagnostics;
using System.Configuration;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus HED Global Home Page Actions.
    /// </summary>
    public class HEDGlobalHomePage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(HEDGlobalHomePage));

        /// <summary>
        /// Get Total Time To Wait For Assigned TO Copy State.
        /// </summary>
        readonly int _minutesToWait = Int32.Parse(ConfigurationManager.
            AppSettings["AssignedToCopyInterval"]);

        /// <summary>
        /// Declared variable.
        /// </summary>
        private string _getInstructorCourseId = null;

        /// <summary>
        /// Click Search Catalog Link on Global Home Page.
        /// </summary>
        public void ClickSearchCatalogOption()
        {
            // Click Search Catalog Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickSearchCatalogOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectHedGlobalHomePageWindow();
                //Wait and Click on the Search Catalog option
                base.WaitForElement(By.PartialLinkText(HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_SearchCatalog_LinkButton_PartialLinkText_Locator));
                //Get Link Property
                IWebElement getLinkProperty = base.GetWebElementPropertiesByPartialLinkText
                    (HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_SearchCatalog_LinkButton_PartialLinkText_Locator);
                //Click on Link
                base.ClickByJavaScriptExecutor(getLinkProperty);
                base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);
                base.SelectWindow(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);
                //Switching to the Iframe
                new CourseCatalogMainPage().SwitchToCatalogIFrame();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickSearchCatalogOption",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click Create a Course On Global Home Page.
        /// </summary>
        public void ClickCreateaCourse()
        {
            //Click Create a Course Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickCreateaCourse",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Global Home Window
                this.SelectHedGlobalHomePageWindow();
                base.WaitForElement(By.LinkText(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_CreateaCourse_LinkButton_Locator));
                //Get Link Property
                IWebElement getLinkProperty = base.GetWebElementPropertiesByLinkText(
                    HEDGlobalHomePageResource.HEDGlobalHome_Page_CreateaCourse_LinkButton_Locator);
                base.ClickByJavaScriptExecutor(getLinkProperty);
                base.SelectWindow(HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_Window_Title_Name);
                //Switching to the Iframe
                new CourseCatalogMainPage().SwitchToCatalogIFrame();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickCreateaCourse",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Approve The Course From InActive State To Active State.
        /// </summary>
        public void ApproveCoursePresentInAssignedToCopyState()
        {
            //Approve The Course From InActive State To Active State
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "ApproveCoursePresentInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Set Thread To Wait
                Thread.Sleep(Convert.ToInt32(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_ThreadSleep_Value));
                base.SelectDefaultWindow();
                //Select Global Home window
                base.SelectWindow(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);
                //If Assgined To Copy Text Present
                if (base.IsElementPresent(By.ClassName(HEDGlobalHomePageResource
                        .HEDGlobalHome_Page_CourseInactive_Text_ClassName_Locator)
                        , Convert.ToInt32(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_TimeInSeconds)))
                {
                    this.WaitForCourseGetOutOfAssignedToCopyState();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage",
                "ApproveCoursePresentInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait For Course Get Out Of Assigned To Copy State.
        /// </summary>
        private void WaitForCourseGetOutOfAssignedToCopyState()
        {
            //Wait Through Stop Watch To Course Get Out of Assigned State
            Logger.LogMethodExit("HEDGlobalHomePage",
               "WaitForCourseGetOutOfAssignedToCopyState",
               base.IsTakeScreenShotDuringEntryExit);
            //Start Stop Watch 
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Clicks Till Course Gets Out of Inactive State
            while (base.IsElementPresent(By.ClassName(HEDGlobalHomePageResource
               .HEDGlobalHome_Page_CourseInactive_Text_ClassName_Locator)
               , Convert.ToInt32(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_TimeInSeconds)))
            {
                //If still time is pending to verify assigned to copy state
                if (stopWatch.Elapsed.TotalMinutes < _minutesToWait == false) break;
                {
                    Thread.Sleep(Convert.ToInt32(HEDGlobalHomePageResource.
                          HEDGlobalHome_Page_ThreadSleep_Value));
                    //Close Announcement Page If Present
                    this.OpenAndCloseAnnouncementPage();
                    //If Assgined To Copy Text Present
                    if (!base.IsElementPresent(By.ClassName(HEDGlobalHomePageResource
                          .HEDGlobalHome_Page_CourseInactive_Text_ClassName_Locator),
                           Convert.ToInt32(HEDGlobalHomePageResource.
                           HEDGlobalHome_Page_TimeInSeconds)))
                    {
                        break;
                    }
                }
            }
            Logger.LogMethodExit("HEDGlobalHomePage",
               "WaitForCourseGetOutOfAssignedToCopyState",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Refresh The Global Home Page.
        /// </summary>
        public void RefreshTheGlobalHomePage()
        {
            //Refresh The Page To Get The Course Displayed
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "RefreshTheGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Set Thread To Wait
                Thread.Sleep(Convert.ToInt32(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_ThreadSleep_Value));
                base.SwitchToDefaultPageContent();
                //Select Global Home Window
                base.SelectWindow(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);
                //Close Announcement Page If Present
                this.OpenAndCloseAnnouncementPage();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage",
                "RefreshTheGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Is Assigned To Copy Text Present.
        /// </summary>
        /// <returns>Returns False If Course Is in Active State 
        /// otherwise Wait To Get In Active State.</returns>
        public bool IsCoursePresentInAssignedToCopyState()
        {
            //Is Assigned To Copy Text Present
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "IsCoursePresentInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized Bool Variable
            bool isAssignedToCopyTextPresent = false;
            try
            {
                //Switch To Default Window
                base.SwitchToDefaultPageContent();
                //Select Global Home window
                base.SelectWindow(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);
                //Is Assgined To Copy Text Present
                isAssignedToCopyTextPresent = base.IsElementPresent(
                    By.ClassName(HEDGlobalHomePageResource
                        .HEDGlobalHome_Page_CourseInactive_Text_ClassName_Locator)
                        , Convert.ToInt32(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_TimeInSeconds));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage",
                "IsCoursePresentInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            return isAssignedToCopyTextPresent;
        }

        /// <summary>
        /// Open and Close Announcement page in validating inactive state.
        /// </summary>
        private void OpenAndCloseAnnouncementPage()
        {
            //Close Announcement page in verifying inactive state
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "OpenAndCloseAnnounmentPage"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_AnnouncementsManageAll_Button_Id_Locator));
            //Fill Text Box With Empty String
            base.FillEmptyTextById(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_AnnouncementsManageAll_Button_Id_Locator);
            IWebElement getManageButton = base.GetWebElementPropertiesById
                (HEDGlobalHomePageResource
                .HEDGlobalHome_Page_AnnouncementsManageAll_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(getManageButton);
            //Switch to frame of Announcement
            SwitchToAnnouncementIFrame();
            // Click on Close Button of Announcement
            CloseAnnouncement();
            base.SelectWindow(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Window_Title_Name);
            Logger.LogMethodExit("HEDGlobalHomePage",
                "OpenAndCloseAnnounmentPage"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Closing the Announcement.
        /// </summary>
        private void CloseAnnouncement()
        {
            //Click on the Close button of the Announcement
            Logger.LogMethodEntry("HEDGlobalHomePage", "CloseAnnouncement",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the Close button
            base.WaitForElement(By.Id(HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_AnnouncementsClose_Link_Id_Locator));
            IWebElement getCloseButton = base.GetWebElementPropertiesById
                (HEDGlobalHomePageResource
                .HEDGlobalHome_Page_AnnouncementsClose_Link_Id_Locator);
            //Click on the Close button
            base.ClickByJavaScriptExecutor(getCloseButton);
            base.SwitchToDefaultPageContent();
            //Set Thread To Wait
            Thread.Sleep(Convert.ToInt32(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_Course_Custom_TimeToWait));
            Logger.LogMethodEntry("HEDGlobalHomePage", "CloseAnnouncement",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Added Course From Search Catalog Present on Global Home Page.
        /// </summary>
        /// <returns>Course Present Text.</returns>
        public String GetCoursePresentInGlobalHomePage()
        {
            // Course Present on Global Home Page
            Logger.LogMethodEntry("HEDGlobalHomePage"
                , "GetCoursePresentInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized Course Text
            string getCourseText = string.Empty;
            try
            {
                //Select Window
                this.SelectHedGlobalHomePageWindow();
                //Set Thread To Wait
                Thread.Sleep(Convert.ToInt32(HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_ThreadSleep_Value));
                //Wait for Element
                base.WaitForElement(By.Id(HEDGlobalHomePageResource
                         .HEDGlobalHome_Page_Course_Table_Id_Locator));
                //Get Course Text
                getCourseText = base.GetElementTextById(HEDGlobalHomePageResource
                        .HEDGlobalHome_Page_Course_Table_Id_Locator);
                //Select Global Home Window
                base.SelectWindow(HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_Window_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "GetCoursePresentInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            return getCourseText;

        }

        /// <summary>
        /// Store Instructor Course Id in Memory.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        public void StoreInstructorCourseIdInMemory(Course.CourseTypeEnum courseTypeEnum)
        {
            //Get Instructor Course Id and Store In Memory
            Logger.LogMethodEntry("HEDGlobalHomePage", "StoreInstructorCourseIDInMemory"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (courseTypeEnum)
                {
                    case Course.CourseTypeEnum.MyTestBankCourse:
                        break;
                    default:
                        //Get Instructor Course ID
                        string getInstructorCourseId = this.GetInstructorCourseId(courseTypeEnum);
                        //Store Instructor Course Id In Memory
                        this.StoreInstructorCourseIdInMemory(getInstructorCourseId, courseTypeEnum);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "StoreInstructorCourseIDInMemory"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Instructor Course ID from the Global Home Page.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <returns>Instructor Course ID.</returns>
        private String GetInstructorCourseId(Course.CourseTypeEnum courseTypeEnum)
        {
            //Get Instructor Course ID from Global Home Page
            Logger.LogMethodEntry("HEDGlobalHomePage", "GetInstructorCourseId"
                , base.IsTakeScreenShotDuringEntryExit);
            //Initialize Course Table Div Count
            const int getCourseDivCount = 1;
            //Select Window
            this.SelectHedGlobalHomePageWindow();
            base.WaitForElement(By.XPath(string.Format
                (HEDGlobalHomePageResource
                .HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, getCourseDivCount)));
            //Get Element Property
            IWebElement getCourseDivText = base.GetWebElementPropertiesByXPath(
                string.Format(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, getCourseDivCount));
            //Get Instructor Course Id
            string getInstructorCourseId = GetInstructorCourseIdFromDiv(
                getCourseDivCount, getCourseDivText, courseTypeEnum);
            Logger.LogMethodExit("HEDGlobalHomePage", "GetInstructorCourseId"
                , base.IsTakeScreenShotDuringEntryExit);
            return getInstructorCourseId;
        }

        /// <summary>
        /// Get Instructor Course ID From Global Home Page.
        /// </summary>
        /// <param name="courseDivCount">This is course div count.</param>
        /// <param name="courseDivText">This is course div text.</param>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <returns>Instructor Course ID.</returns>
        private string GetInstructorCourseIdFromDiv(int courseDivCount,
            IWebElement courseDivText, Course.CourseTypeEnum courseTypeEnum)
        {
            //Get Instructor Course ID
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "GetInstructorCourseIdFromDiv", base.IsTakeScreenShotDuringEntryExit);
            //Get Instructor Course Id
            string getInstructorCourseId;
            Course course = Course.Get(courseTypeEnum);
            //If Instructor Course Present in 1 Div
            if (!courseDivText.Text.Contains(course.Name))
            {
                //Fetch Instructor Course ID Form Non First Div
                getInstructorCourseId = this.GetInstructorCourseIdFromNonFirstDiv
                    (courseDivCount, courseDivText, course);
            }
            else
            {
                //Fetch Instructor Course ID From First Div
                getInstructorCourseId = GetInstructorCourseIdFromFirstDiv(courseDivCount);
            }
            Logger.LogMethodExit("HEDGlobalHomePage",
                 "GetInstructorCourseIdFromDiv", base.IsTakeScreenShotDuringEntryExit);
            return getInstructorCourseId;
        }

        /// <summary>
        /// Get Instructor Course Id From First Div.
        /// </summary>
        /// <param name="courseDivCount">This is Course Div Count.</param>
        private string GetInstructorCourseIdFromFirstDiv(int courseDivCount)
        {
            //Get Instructor Course ID
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "GetInstructorCourseIdFromFirstDiv", base.IsTakeScreenShotDuringEntryExit);
            // Wait for the course name
            base.WaitForElement(By.XPath(string.Format(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, courseDivCount)));
            // // Gets control to the course
            base.FillEmptyTextByXPath(string.Format(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, courseDivCount));
            // Get the Text of Row 
            string getInstructorCourseId = base.GetElementTextByXPath
                (string.Format(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Course_Table_ActiveSpan_XPath_Locator,
                courseDivCount));
            //Get Instructor Course Text Line Number
            int getInstructorCourseTextLineNumber = getInstructorCourseId.IndexOf(' ');
            getInstructorCourseId = getInstructorCourseId.Substring(getInstructorCourseTextLineNumber).Trim();
            Logger.LogMethodExit("HEDGlobalHomePage",
                "GetInstructorCourseIdFromFirstDiv", base.IsTakeScreenShotDuringEntryExit);
            return getInstructorCourseId;
        }

        /// <summary>
        /// Get Instructor Course ID When Course is not Present.
        /// in Div First.
        /// </summary>
        /// <param name="coursePresentDivNumber">This is Div Count.</param>
        /// <param name="courseDivText">This is Div Text.</param>
        /// <param name="course">This is Course Name.</param>
        /// <returns>Instructor Course ID.</returns>
        private string GetInstructorCourseIdFromNonFirstDiv(int coursePresentDivNumber,
            IWebElement courseDivText, Course course)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "GetInstructorCourseIdFromNonFirstDiv"
                , base.IsTakeScreenShotDuringEntryExit);
            while (!courseDivText.Text.Contains(course.Name))
            {
                coursePresentDivNumber = coursePresentDivNumber + 1;
                //Gets the course name of first row
                string getPresentDivText = base.GetElementTextByXPath(string.Format
                    (HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_Course_Table_Row_XPath_Locator,
                    coursePresentDivNumber));
                if (getPresentDivText.Contains(course.Name))
                {
                    // Put Focus on the Course Row
                    base.FillEmptyTextByXPath(string.Format(HEDGlobalHomePageResource.
                  HEDGlobalHome_Page_Course_Table_Row_XPath_Locator,
                  coursePresentDivNumber));
                    // Get the Texts from the Course Row
                    string getTextFromCourseRow = base.GetElementTextByXPath
                        (string.Format(HEDGlobalHomePageResource.
                 HEDGlobalHome_Page_Course_Table_ActiveSpan_XPath_Locator, coursePresentDivNumber));
                    //Get the Location of Space to fetch numbers available after space
                    int getInstructorCourseIdLineNumber = getTextFromCourseRow.IndexOf(' ');
                    _getInstructorCourseId = getTextFromCourseRow.
                        Substring(getInstructorCourseIdLineNumber).Trim();
                    break;
                }
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "GetInstructorCourseIdFromNonFirstDiv",
                base.IsTakeScreenShotDuringEntryExit);
            return _getInstructorCourseId;
        }

        /// <summary>
        /// Store Course Instructor ID in Memory.
        /// </summary>
        /// <param name="instructorCourseId">This is Instructor Course ID.</param>
        /// <param name="courseTypeEnum">This is Course Type enum.</param>
        private void StoreInstructorCourseIdInMemory(string instructorCourseId,
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Save Instructor Course ID in Memory
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "StoreInstructorCourseIdInMemory",
                                  base.IsTakeScreenShotDuringEntryExit);
            Course hedProductCourse = Course.Get(courseTypeEnum);
            hedProductCourse.InstructorCourseId = instructorCourseId;
            Logger.LogMethodExit("HEDGlobalHomePage",
        "StoreInstructorCourseIdInMemory"
        , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click 
        /// In a Course Link on Global Home Page.
        /// </summary>
        public void ClickOnEnrollInCourseButton()
        {
            //Click Enroll In a Course Link on Global Home Page
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickOnEnrollInCourseButton",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);
                // Click Enroll In a Course Link
                base.SelectWindow(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);
                //Wait For Element
                base.WaitForElement(By.PartialLinkText(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_EnrollInCourse_Button_PartialLinkText_Locator));
                //Get Button Property
                IWebElement getButtonProperty = base.GetWebElementPropertiesByPartialLinkText
                    (HEDGlobalHomePageResource.HEDGlobalHome_Page_EnrollInCourse_Button_PartialLinkText_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickOnEnrollInCourseButton"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Inside the Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        /// <param name="userTypeEnum">This is user type enum.</param>
        public void EnterInsideCourse(Course.CourseTypeEnum courseTypeEnum,
            User.UserTypeEnum userTypeEnum)
        {
            //Enter Inside the Course
            Logger.LogMethodEntry("HEDGlobalHomePage", "EnterInsideCourse"
              , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Course From Memory
                Course course = Course.Get(courseTypeEnum);
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.HedCoreAcceptanceInstructor:
                    case User.UserTypeEnum.HedCoreAcceptanceStudent:
                    case User.UserTypeEnum.HedWsInstructor:
                    case User.UserTypeEnum.HedWsStudent:
                    case User.UserTypeEnum.HedProgramAdmin:
                    case User.UserTypeEnum.AmpProgramAdmin:
                    case User.UserTypeEnum.HSSProgramAdmin:
                    case User.UserTypeEnum.HedMilAcceptanceInstructor:
                    case User.UserTypeEnum.WLProgramAdmin:
                    case User.UserTypeEnum.RegHedWsInstructor:
                    case User.UserTypeEnum.RegHedWsStudent:
                    case User.UserTypeEnum.S11eTextInstructor:
                    case User.UserTypeEnum.S11eTextStudent:
                        switch (courseTypeEnum)
                        {
                            //Course Type Enum
                            case Course.CourseTypeEnum.ProgramCourse:
                            case Course.CourseTypeEnum.MyItLabProgramCourse:
                            case Course.CourseTypeEnum.MySpanishLabMaster:
                            case Course.CourseTypeEnum.RegMySpanishLabMaster:
                            case Course.CourseTypeEnum.AmpWSCourse:
                            case Course.CourseTypeEnum.MyItLabSIM5MasterCourse:
                            case Course.CourseTypeEnum.MyItLabSIMMasterCourse:
                            case Course.CourseTypeEnum.MyItLabInstructorCourse:
                            case Course.CourseTypeEnum.InstructorCourse:
                            case Course.CourseTypeEnum.HEDGeneral:
                            case Course.CourseTypeEnum.HedMilAcceptanceSIMProgramCourse:
                            case Course.CourseTypeEnum.HedMilAcceptanceSIM5ProgramCourse:
                            case Course.CourseTypeEnum.HedCoreAcceptanceProgramCourse:
                            case Course.CourseTypeEnum.MyTestInstructorCourse:
                            case Course.CourseTypeEnum.MyTestBankCourse:
                            case Course.CourseTypeEnum.HedEmptyClass:
                            case Course.CourseTypeEnum.GraderITSIM5Course:
                            case Course.CourseTypeEnum.MyITLabOffice2013Program:
                            case Course.CourseTypeEnum.HedMyPsychLabProgram:
                            case Course.CourseTypeEnum.MySpanishLabTestingMaster:
                            case Course.CourseTypeEnum.HSSMyPsychLabProgram:
                            case Course.CourseTypeEnum.MySpanishLabProgram:
                            case Course.CourseTypeEnum.AmpProgramCourse:
                            case Course.CourseTypeEnum.MyITLabOffice2013ProgramCourseCreation:
                            case Course.CourseTypeEnum.eTextCourse:
                                //Open the Course
                                this.OpenTheCourse(course.Name);
                                break;
                        }
                        break;
                    case User.UserTypeEnum.HedTeacherAssistant:
                    case User.UserTypeEnum.CsSmsStudent:
                    case User.UserTypeEnum.HSSCsSmsStudent:
                    case User.UserTypeEnum.WLCsSmsStudent:
                    case User.UserTypeEnum.AmpCsSmsStudent:
                    case User.UserTypeEnum.RegCsSmsStudent:
                        switch (courseTypeEnum)
                        {
                            case Course.CourseTypeEnum.ProgramCourse:
                            case Course.CourseTypeEnum.HedMyPsychLabProgram:
                            case Course.CourseTypeEnum.HSSMyPsychLabProgram:
                            case Course.CourseTypeEnum.MySpanishLabMaster:
                            case Course.CourseTypeEnum.RegMySpanishLabMaster:
                            case Course.CourseTypeEnum.MyITLabOffice2013Program:
                            case Course.CourseTypeEnum.MySpanishLabProgram:
                                //Open the Course
                                this.OpenTheCourse(course.SectionName);
                                break;
                            case Course.CourseTypeEnum.MyItLabProgramCourse:
                                //Open the Course
                                this.OpenTheCourse(course.SectionName +
                                    HEDGlobalHomePageResource.HEDGlobalHome_Page_SectionValue);
                                break;
                            case Course.CourseTypeEnum.InstructorCourse:
                            case Course.CourseTypeEnum.RegWLMasterCourse:
                            case Course.CourseTypeEnum.AmpInstructorCourse:
                            case Course.CourseTypeEnum.MyTestInstructorCourse:
                            case Course.CourseTypeEnum.MyItLabInstructorCourse:
                            case Course.CourseTypeEnum.HedMyItLabPPECourse:
                            case Course.CourseTypeEnum.HedMilSelfStudy:
                                //Open the Course
                                this.OpenTheCourse(course.Name);
                                break;
                        }
                        break;
                    case User.UserTypeEnum.CsSmsInstructor:
                    case User.UserTypeEnum.RegCsSmsInstructor:
                    case User.UserTypeEnum.AmpCsSmsInstructor:
                    case User.UserTypeEnum.HSSCsSmsInstructor:
                    case User.UserTypeEnum.WLCsSmsInstructor:
                    case User.UserTypeEnum.MyTestSmsInstructor:
                        switch (courseTypeEnum)
                        {
                            case Course.CourseTypeEnum.ProgramCourse:
                            case Course.CourseTypeEnum.MyTestInstructorCourse:
                            case Course.CourseTypeEnum.MyTestBankCourse:
                            case Course.CourseTypeEnum.MyItLabProgramCourse:
                            case Course.CourseTypeEnum.MyItLabInstructorCourse:
                            case Course.CourseTypeEnum.InstructorCourse:
                            case Course.CourseTypeEnum.AmpInstructorCourse:
                            case Course.CourseTypeEnum.RegWLMasterCourse:


                                //Open the Program Course
                                this.OpenTheCourse(course.Name);
                                break;
                            case Course.CourseTypeEnum.MyITLabOffice2013Program:
                            case Course.CourseTypeEnum.HSSMyPsychLabProgram:
                            case Course.CourseTypeEnum.MySpanishLabProgram:
                            case Course.CourseTypeEnum.MySpanishLabProgramMyTest:
                                //Open the Course
                                this.OpenTheCourse(course.SectionName);
                                break;
                        }
                        break;
                }
                //Store User Last Login Details In Memory
                this.StoreUserLastLoginDetailsInMemory();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "EnterInsideCourse"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store User Last Login Details In Memory.
        /// </summary>
        private void StoreUserLastLoginDetailsInMemory()
        {
            //Store User Last Login Details In Memory
            Logger.LogMethodEntry("HEDGlobalHomePage", "StoreUserLastLoginDetailsInMemory"
              , base.IsTakeScreenShotDuringEntryExit);
            //Get User From Memory
            User user = User.Get(User.UserTypeEnum.CsSmsStudent);
            //Update Last Login Date
            user.LastLogin = DateTime.Now;
            Logger.LogMethodExit("HEDGlobalHomePage", "StoreUserLastLoginDetailsInMemory"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open The Course.
        /// </summary>
        /// <param name="courseName">This is Course Name.</param>
        public void OpenTheCourse(String courseName)
        {
            // Open Course by clicking on course Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "OpenTheCourse"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);
                //Select Window
                base.SelectWindow(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);
                //Click Course Name Link
                ClickOnCourseLink(courseName);
                CourseName = courseName;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "OpenTheCourse"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Course Link To Open.
        /// </summary>
        /// <param name="courseName">This is Course Name.</param>
        private void ClickOnCourseLink(String courseName)
        {
            // Search and Click Course Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickOnCourseLink"
                , base.IsTakeScreenShotDuringEntryExit);
            //Get Course Row Counter
            const int getCourseRowCounter = 1;
            base.WaitForElement(
                By.XPath(string.Format(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Course_Table_Row_XPath_Locator,
                                       getCourseRowCounter)));
            // Click the course name
            ClickCourseNameOnHomePage(courseName, getCourseRowCounter);
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickOnCourseLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the course on home page.
        /// </summary>
        /// <param name="courseName">This is the course name.</param>
        /// <param name="courseDivCounter">This is the div count.</param>
        private void ClickCourseNameOnHomePage1
            (string courseName, int courseDivCounter)
        {
            //Get HTML Element Property 
            //HEDGlobalHomePageResource.
            //HEDGlobalHome_Page_Course_Table_Row_XPath_Locator
            IWebElement courseTable = base.GetWebElementPropertiesByXPath(
                string.Format("//div[@class='channel-content']/div/div/div[{0}]", courseDivCounter));
            if (!courseTable.Text.Equals(courseName))
            {
                //Get The Course From Each Row
                while (!courseTable.Text.Equals(courseName))
                {
                    courseDivCounter = courseDivCounter + 1;

                    string getCourseNameFromApplication = base.GetInnerTextAttributeValueByXPath(
                    string.Format(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Course_Name_XPath_Locator, courseDivCounter));

                    //Get Course Row Text
                    string getCourseRowText = base.GetElementTextByXPath(string.Format(
                      HEDGlobalHomePageResource.
                      HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, courseDivCounter));
                    //If Course Present on the User Home Page
                    if (getCourseNameFromApplication.Equals(courseName))
                    {
                        //Wait For Element
                        base.WaitForElement(By.PartialLinkText(courseName));
                        //Clicks on the course
                        base.FillEmptyTextByPartialLinkText(courseName);
                        IWebElement getCourseName = base.GetWebElementPropertiesByPartialLinkText
                            (courseName);
                        //Click on Link
                        base.ClickByJavaScriptExecutor(getCourseName);
                        break;
                    }
                }
            }
            else
            {
                //Clicks on the course name
                base.FillEmptyTextByPartialLinkText(courseName);

                base.WaitForElement(By.PartialLinkText(courseName));
                // base.WaitForElement(By.PartialLinkText(courseName));
                IWebElement getCourseName = base.GetWebElementPropertiesByPartialLinkText(courseName);
                base.ClickByJavaScriptExecutor(getCourseName);
            }
        }

        /// <summary>
        /// This methord is to refresh browser till Instructor course copy
        /// </summary>
        /// <param name="courseName">This is course name choosen to create.</param>
        /// <param name="courseCopyStatusMessageMyTest">This is course copy status message.</param>
        private void ClickCourseNameOnHomePage(string courseName, int courseDivCounter)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickCourseNameOnHomePage"
            , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                                           HEDGlobalHome_Page_Window_Title_Name);
                base.SelectWindow(HEDGlobalHomePageResource.
                                   HEDGlobalHome_Page_Window_Title_Name);
                // Get course count
                int getCourseCount = base.GetElementCountByXPath(HEDGlobalHomePageResource.
                    HEDGlobalHome_GetCourse_Count_Xparth_Locator);
                for (int i = courseDivCounter; i <= getCourseCount; i++)
                {

                    string getCourseName = base.GetInnerTextAttributeValueByXPath(
                    string.Format(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Course_Name_XPath_Locator, i));
                    //Get Course Row Text
                    string getCourseRowText = base.GetElementTextByXPath(string.Format(
                    HEDGlobalHomePageResource.HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, i));
                    if (getCourseName.Equals(courseName))
                    {
                        // Enter inside course
                        IWebElement getCourse = base.GetWebElementPropertiesByXPath(string.Format(
                            HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_Course_Name_XPath_Locator, i));
                        base.ClickByJavaScriptExecutor(getCourse);
                        break;
                    }

                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickCourseNameOnHomePage"
            , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Course Name.
        /// </summary>
        /// <returns>Course Name.</returns>
        public String GetCourseName()
        {
            // Get The User Name After Enter In Course
            string getCourseName = string.Empty;
            Logger.LogMethodEntry("HEDGlobalHomePage", "GetCourseName",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Default Window
                base.SelectDefaultWindow();
                base.WaitForElement(By.ClassName(HEDGlobalHomePageResource.
                      HEDGlobalHome_Page_CourseNavigation_Title_ClassName_Locator));
                //Get the UserName
                getCourseName = base.GetElementTextByClassName
                   (HEDGlobalHomePageResource.
                       HEDGlobalHome_Page_CourseNavigation_Title_ClassName_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "GetCourseName",
                base.IsTakeScreenShotDuringEntryExit);
            return getCourseName;
        }

        /// <summary>
        /// Switching To Announcement Iframe.
        /// </summary>
        private void SwitchToAnnouncementIFrame()
        {
            //Switch To Announcement Iframe
            Logger.LogMethodEntry("HEDGlobalHomePage", "SwitchToAnnouncementIframe",
                      base.IsTakeScreenShotDuringEntryExit);
            // Wait for the IFrame
            base.WaitForElement(By.XPath(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_AnnouncementFrame_XPath_Locator));
            //Switch to Iframe     
            base.SwitchToIFrameByWebElement(base.GetWebElementPropertiesByXPath(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_AnnouncementFrame_XPath_Locator));
            Logger.LogMethodExit("HEDGlobalHomePage", "SwitchToAnnouncementIframe",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'My Profile' Link.
        /// </summary>
        public void ClickOnMyProfileLink()
        {
            //Click On 'My Profile' Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickOnMyProfileLink",
                      base.IsTakeScreenShotDuringEntryExit);
            try
            {

                base.WaitUntilWindowLoads("Global Home");
                base.SelectWindow("Global Home");
                //Wait For Element
                //base.isElementDisplayedInPage(By.XPath("//a[contains(@id, 'ancMyAccount')]"));
                //base.isElementDisplayedInPage(By.CssSelector("a[id*='_ancMyAccount']"));
                base.WaitForElement(By.CssSelector("a[id*='_ancMyAccount']"));
                //Get Element Property
                IWebElement getLinkProperty = base.
                    GetWebElementPropertiesByCssSelector("a[id*='_ancMyAccount']");
                //Click My Profile Link
                base.ClickByJavaScriptExecutor(getLinkProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickOnMyProfileLink",
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Enroll In a Course and Search catalog Link on Global Home Page.
        /// </summary>
        /// <param name="userTypeEnum"></param>
        /// <returns></returns>
        public Boolean IsEnrollInCourseAndSearchCatalogButtonPresent
            (User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "IsEnrollInCourseAndSearchCatalogButtonPresent",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isDefaultContentsDisplayed = false;
            try
            {
                //Select HED Global home page window
                this.SelectHedGlobalHomePageWindow();
                //Get EnrollInCourse Button Status
                bool isEnrollInCourseButtonPresent = base.IsElementPresent(By.Id
                    (HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_EnrollInCourse_Button_Id_Locator),
                    Convert.ToInt32(HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_Custom_TimeToWait));
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.HedCoreAcceptanceInstructor:
                        //Get Search Catalog Button 
                        bool isSearchCatalogButtonPresent = base.IsElementPresent(By.Id
                            (HEDGlobalHomePageResource
                            .HEDGlobalHome_Page_SearchCatalog_Button_Id_Locator),
                            Convert.ToInt32(HEDGlobalHomePageResource.HEDGlobalHome_Page_Custom_TimeToWait));
                        isDefaultContentsDisplayed = isEnrollInCourseButtonPresent ||
                        isSearchCatalogButtonPresent;
                        break;
                    case User.UserTypeEnum.HedCoreAcceptanceStudent:
                        isDefaultContentsDisplayed = isEnrollInCourseButtonPresent;
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "IsEnrollInCourseAndSearchCatalogButtonPresent"
                , base.IsTakeScreenShotDuringEntryExit);
            return isDefaultContentsDisplayed;
        }

        /// <summary>
        /// Select HEDGlobal Home page window.
        /// </summary>
        private void SelectHedGlobalHomePageWindow()
        {
            //Logger enrty
            Logger.LogMethodEntry("HEDGlobalHomePage", "SelectHedGlobalHomePageWindow"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait for window
            base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Window_Title_Name);
            //Select Window
            base.SelectWindow(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Window_Title_Name);
            //Logger exit
            Logger.LogMethodExit("HEDGlobalHomePage", "SelectHedGlobalHomePageWindow"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Feedback and MyProfile Link on Global Home Page.
        /// </summary>
        public Boolean IsFeedbackAndMyProfileLingPresent()
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "IsFeedbackAndMyProfileLingPresent",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isDefaultContentsDisplayed = false;
            try
            {
                // Click Enroll In a Course Link
                base.SelectWindow(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);
                //Get EnrollInCourse Button 
                bool isMyProfileLinkPresent = base.IsElementPresent(By.Id
                    (HEDGlobalHomePageResource.HEDGlobalHome_Page_MyProfile_Id_Locator)
                    , Convert.ToInt32(HEDGlobalHomePageResource.HEDGlobalHome_Page_Custom_TimeToWait));
                //Get Search Catalog Button 
                bool isFeedbackLinkPresent = base.IsElementPresent(By.Id
                    (HEDGlobalHomePageResource.HEDGlobalHome_Page_Feedback_Id_Locator)
                    , Convert.ToInt32(HEDGlobalHomePageResource.HEDGlobalHome_Page_Custom_TimeToWait));

                isDefaultContentsDisplayed = isMyProfileLinkPresent ||
                    isFeedbackLinkPresent;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "IsFeedbackAndMyProfileLingPresent"
                , base.IsTakeScreenShotDuringEntryExit);
            return isDefaultContentsDisplayed;
        }

        /// <summary>
        /// Click Sign out link on the page.
        /// </summary>
        /// <param name="linkSignOut">This is SingOut Link.</param>
        /// <returns>LinkProperties object</returns>
        public IWebElement GetSignOutLink(String linkSignOut)
        {
            //Complete SingOut Process
            Logger.LogMethodEntry("HEDGlobalHomePage", "GetSignOutLink",
                base.IsTakeScreenShotDuringEntryExit);
            IWebElement getLinkProperty = null;
            try
            {
                //Select Default Window           
                base.SelectDefaultWindow();
                //Wait For Element
                base.WaitForElement((By.PartialLinkText(linkSignOut)));
                //Get Element Property
                getLinkProperty = base.
                    GetWebElementPropertiesByPartialLinkText(linkSignOut);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "GetSignOutLink",
                base.IsTakeScreenShotDuringEntryExit);
            return getLinkProperty;
        }

        /// <summary>
        /// Click The Help Link In Global Homepage. 
        /// </summary>
        public void ClickTheHelpLinkInGlobalHomePage()
        {
            //Click The Help Link In Global Homepage 
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickTheHelpLinkInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Help_Link_Id_Locator));
                IWebElement getHelpLinkProperty = base.GetWebElementPropertiesById
                    (HEDGlobalHomePageResource.HEDGlobalHome_Page_Help_Link_Id_Locator);
                //Click the Help link
                base.ClickByJavaScriptExecutor(getHelpLinkProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickTheHelpLinkInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Click The Help Link In Global Homepage in TA.
        /// </summary>
        public void ClickTheHelpLinkInGlobalHomePageInTa()
        {
            // Click The Help Link In Global Homepage in TA
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickTheHelpLinkInGlobalHomePageInTa",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_TA_Help_Link_Id_Locator));
                IWebElement getHelpLinkProperty = base.GetWebElementPropertiesById
                    (HEDGlobalHomePageResource.HEDGlobalHome_Page_TA_Help_Link_Id_Locator);
                //Click the Help link
                base.ClickByJavaScriptExecutor(getHelpLinkProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickTheHelpLinkInGlobalHomePageInTa",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the UpgradeAvailabe Text of Testbank on Global Home Page.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        public void ClickOnUpgradeAvailableOfTestBank(Course.CourseTypeEnum
            courseTypeEnum)
        {
            //Logger Entry
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickOnUpgradeAvailableOfTestBank",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select HED Global home page
                this.SelectHedGlobalHomePageWindow();
                //Handle Announcment pop up 
                this.OpenAndCloseAnnouncementPage();
                Course courseName = Course.Get(courseTypeEnum);
                //Wait for Course List Div
                base.WaitForElement(By.XPath(HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_Course_Table_Div_XPath_Locator));
                //Get The Total number of course 
                int getTotalCourseCount = base.
                    GetElementCountByXPath(HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_Course_Table_Div_XPath_Locator);
                //Get the course name and click on UpgradeAvailabe link
                this.ClickOnUpgradeAvailableLink(getTotalCourseCount, courseName.Name);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            //Logger Exist
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickOnUpgradeAvailableOfTestBank",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the name of course/testbank and click on upgradeAvailable link. 
        /// </summary>
        /// <param name="courseCount">This is number of Total
        /// course available on Home page.</param>
        /// <param name="courseName">This is name of course.</param>
        private void ClickOnUpgradeAvailableLink(int courseCount,
            String courseName)
        {
            //Logger Entry
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickOnUpgardeAvailableLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Search expected Testbank/Course Name 
            for (int setCourseDivCount = 1; setCourseDivCount <=
                courseCount; setCourseDivCount++)
            {
                //Get the Course Name Text
                String getCourseName = base.GetElementTextByXPath(string.Format(
                    HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Course_Table_Row_XPath_Locator,
                    setCourseDivCount));
                //Match the  expected course name from List of courses 
                if (getCourseName.Contains(courseName))
                {
                    //wait for UpgradeAvailabe text of testBank
                    base.WaitForElement(By.XPath(String.Format(
                        HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_Course_Table_UpgradeAvailable_XPath_Locator,
                        setCourseDivCount)));
                    //Get The HTML Property of UpgradeAvailabe link
                    IWebElement getPropertyOfUpgradeAvailableLink = base.
                        GetWebElementPropertiesByXPath(String.Format(HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_Course_Table_UpgradeAvailable_XPath_Locator,
                        setCourseDivCount));
                    //Click on UpgradeAvailabe Link
                    base.ClickByJavaScriptExecutor(getPropertyOfUpgradeAvailableLink);
                    break;
                }
            }
            //Logger Exit
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickOnUpgardeAvailableLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the status of KeepMeTestCourse CheckBox on Upgrade popup.
        /// </summary>
        /// <returns>Return the status of checkbox.</returns>
        public Boolean IsStatusOfKeepMeTestCourseCheckBoxEnabled()
        {
            //Logger Entry
            Logger.LogMethodEntry("HEDGlobalHomePage", "IsStatusOFKeepMeTestCourseCheckBoxEnabled",
                base.IsTakeScreenShotDuringEntryExit);
            bool isCheckboxEnabled = false;
            try
            {
                //Select Upgrade popup window
                this.SelectUpgradePopupWindow();
                //Wait for KeepMeTestCourse check box on popup
                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_UpgradeCheckBox_Id_Locator_On_Popup));
                //Get HTML property of KeepMeTestCourse CheckBox 
                IWebElement getPropertyOfCheckbox = base.
                    GetWebElementPropertiesById(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_UpgradeCheckBox_Id_Locator_On_Popup);
                //Get the status of checkbox 
                isCheckboxEnabled = getPropertyOfCheckbox.Selected;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("HEDGlobalHomePage", "IsStatusOFKeepMeTestCourseCheckBoxEnabled",
                base.IsTakeScreenShotDuringEntryExit);
            return isCheckboxEnabled;
        }

        /// <summary>
        /// Select Upgrade Popup Window. 
        /// </summary>
        private void SelectUpgradePopupWindow()
        {
            //Logger Entry
            Logger.LogMethodEntry("HEDGlobalHomePage", "SelectUpgradePopupWindow",
                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for Pop up Window
            base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Upgrade_Popup_Window_Name);
            //Switch on Popup window
            base.SelectWindow(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Upgrade_Popup_Window_Name);
            //Logger Exit
            Logger.LogMethodExit("HEDGlobalHomePage", "SelectUpgradePopupWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close upgrade popup window.
        /// </summary>
        public void CloseUpgradePopupWindow()
        {
            //Logger Entry
            Logger.LogMethodEntry("HEDGlobalHomePage", "CloseUpgradePopupWindow",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Close the popup window
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("HEDGlobalHomePage", "CloseUpgradePopupWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get MyCourse Name In GlobalHome.
        /// </summary>
        /// <param name="courseName">This is Course Name.</param>
        /// <returns>Course Name.</returns>
        public string GetMyCourseNameInGlobalHome(string courseName)
        {
            // Get MyCourse Name In GlobalHome
            Logger.LogMethodEntry("HEDGlobalHomePage", "GetMyCourseNameInGlobalHome",
                   base.IsTakeScreenShotDuringEntryExit);
            //Initialize the vatiable
            string getCourseName = string.Empty;
            try
            {
                //Select window
                this.SelectGlobalHomepage();
                //Getting the counts of Activity                    
                int totalCourseCount = base.GetElementCountByXPath
                    (HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Course_Table_Div_XPath_Locator);
                for (int courseRowCount = Convert.ToInt32(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_LoopIntializer_Value);
                          courseRowCount <= totalCourseCount; courseRowCount++)
                {
                    //Wait for Element
                    base.WaitForElement(By.XPath(string.Format
                       (HEDGlobalHomePageResource.
                         HEDGlobalHome_Page_CourseName_Xpath_Locator, courseRowCount)));
                    //Getting the Course name
                    getCourseName = base.GetElementTextByXPath
                        (string.Format(HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_CourseName_Xpath_Locator, courseRowCount));
                    if (getCourseName.Contains(courseName))
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "GetMyCourseNameInGlobalHome",
                  base.IsTakeScreenShotDuringEntryExit);
            return getCourseName;
        }

        /// <summary>
        /// Select Global Homepage.
        /// </summary>
        private void SelectGlobalHomepage()
        {
            // Select Global Homepage.
            Logger.LogMethodEntry("HEDGlobalHomePage", "SelectGlobalHomepage",
                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for window
            base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Window_Title_Name);
            //Select Window
            base.SelectWindow(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Window_Title_Name);
            Logger.LogMethodExit("HEDGlobalHomePage", "SelectGlobalHomepage",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Announcement Manage All Button.
        /// </summary>
        /// <returns>Manage All Button Present.</returns>
        public Boolean IsAnnouncementChannelManageAllButtonDisplayed()
        {
            //Verify The Announcement Manage All Button
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "IsAnnouncementChannelManageAllButtonDisplayed",
                   base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isManageAllButtonDisplayedInAnnouncementChannel = false;
            try
            {
                //Select for window
                this.SelectGlobalHomepage();
                //Manage All button displayed
                isManageAllButtonDisplayedInAnnouncementChannel = base.IsElementPresent(
                    By.Id(HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_AnnouncementsManageAll_Button_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage",
                "IsAnnouncementChannelManageAllButtonDisplayed",
                  base.IsTakeScreenShotDuringEntryExit);
            return isManageAllButtonDisplayedInAnnouncementChannel;
        }

        /// <summary>
        /// Is Course Present In GlobalHome Page.
        /// </summary>
        /// <param name="sectionName">This is section name.</param>
        /// <returns>section name.</returns>
        public bool IsCoursePresentInGlobalHomePage(string sectionName)
        {
            //Is Course Present In GlobalHome Page
            Logger.LogMethodEntry("HEDGlobalHomePage", "IsCoursePresentInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized Course Text
            bool isCourseText = false;
            try
            {
                //Select Window
                this.SelectHedGlobalHomePageWindow();
                //Set Thread To Wait
                Thread.Sleep(Convert.ToInt32(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Course_Load_TimeValue));
                //Wait for Element
                base.WaitForElement(By.Id(HEDGlobalHomePageResource
                         .HEDGlobalHome_Page_Course_Table_Id_Locator));
                //Get Course Text
                isCourseText = base.IsElementPresent(By.PartialLinkText(sectionName));
                //Select Global Home Window
                base.SelectWindow(HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_Window_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "IsCoursePresentInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            return isCourseText;
        }

        /// <summary>
        /// Store user profile date and time in memory.
        /// </summary>
        public void setUserCurrentDate()
        {
            // Store user profile date and time in memory
            Logger.LogMethodEntry("HEDGlobalHomePage", "setUserCurrentDate",
               base.IsTakeScreenShotDuringEntryExit);
            //Select MyProfile frame
            try
            {
                this.SelectMyProfileIframe();
                //get the date value from dropdown
                base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_MyProfile_Date_Dropdown_Xpath_Locator));
                String currentDate = base.GetElementTextByXPath(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_MyProfile_Date_Dropdown_Xpath_Locator);
                //get the time value from dropdown
                base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                   HEDGlobalHome_Page_MyProfile_Time_Dropdown_Xpath_Locator));
                String currentTime = base.GetElementTextByXPath(HEDGlobalHomePageResource.
                   HEDGlobalHome_Page_MyProfile_Time_Dropdown_Xpath_Locator);
                //store date and time in memory
                String instance = currentDate + " " + currentTime;
                DateTime datetime = Convert.ToDateTime(instance);
                User user = User.Get(User.UserTypeEnum.CsSmsInstructor);
                user.CurrentProfileDateTime = datetime;
                base.WaitForElement(By.Id("imgbtnCancel"));
                IWebElement cancelButton = base.GetWebElementPropertiesById("imgbtnCancel");
                base.ClickByJavaScriptExecutor(cancelButton);
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "setUserCurrentDate",
                 base.IsTakeScreenShotDuringEntryExit);


        }

        /// <summary>
        /// Select MyProfile Iframe.
        /// </summary>
        private void SelectMyProfileIframe()
        {
            //Select MyProfile Iframe
            Logger.LogMethodEntry("HEDGlobalHomePage", "SelectMyProfileIframe",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_MyProfileFrame_XPath_Locator));
            IWebElement frame = WebDriver.FindElement(By.XPath(
                   HEDGlobalHomePageResource.
                HEDGlobalHome_Page_MyProfileFrame_XPath_Locator));
            //Select MyProfile Iframe
            base.SwitchToIFrameByWebElement(frame);
            Logger.LogMethodExit("HEDGlobalHomePage", "SelectMyProfileIframe",
                 base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Get lightbox name
        /// </summary>
        /// <param name="pageTitle">This is Page title.</param>
        /// <returns>Return lightbox name.</returns>
        public string GetLightboxTitle(string lightboxName)
        {
            //Returns the name of light box
            Logger.LogMethodEntry("HEDGlobalHomePage", "GetLightboxTitle",
                base.IsTakeScreenShotDuringEntryExit);

            string getLightboxName = null;
            //Wait for th window to load
            base.WaitUntilWindowLoads(base.GetPageTitle);
            try
            {
                //Check for lightbox
                switch (lightboxName)
                {
                    case "My Profile":
                        //Wait for My Profile light box
                        base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_MyProfileLightBox_XPath_Locator));
                        IWebElement getProfile = base.GetWebElementPropertiesByXPath(
                            HEDGlobalHomePageResource.HEDGlobalHomePage_HomePage_MyProfileLightBox_XPath_Locator);
                        base.SwitchToIFrameByWebElement(getProfile);
                        //Wait for My Profile light box
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_MyProfileLightBox_ID_Locator));
                        //Get the name of the lightbox
                        getLightboxName = base.GetElementInnerTextById(
                            HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_MyProfileLightBox_ID_Locator);
                        base.ClickButtonById(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_MyProfileLightBox_Cancel_ID_Locator);
                        break;

                    case "My Pearson account":

                        //Wait for My Profile light box
                        base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_MyProfileLightBox_XPath_Locator));
                        IWebElement getPopupTitle = base.GetWebElementPropertiesByXPath(
                            HEDGlobalHomePageResource.HEDGlobalHomePage_HomePage_MyProfileLightBox_XPath_Locator);
                        base.SwitchToIFrameByWebElement(getPopupTitle);
                        //Wait for My Profile light box
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                             HEDGlobalHomePage_TodaysView_MyProfilePopUpname_Id_Locator));
                        //Get the name of the lightbox
                        getLightboxName = base.GetElementInnerTextById(
                            HEDGlobalHomePageResource.HEDGlobalHomePage_TodaysView_MyProfilePopUpname_Id_Locator);
                        //Click on cancel button
                        base.ClickButtonById("imgbtnCancel");
                        break;

                    case "Basic Preferences":
                        //Switch to last opened window
                        base.SwitchToLastOpenedWindow();
                        //Wait for My Profile light box
                        base.WaitForElement(By.ClassName(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_MyProfileLightBox_BasicPreference_ClassName_Locator));
                        //Get the name of the lightbox
                        getLightboxName = base.GetInnerTextAttributeValueByClassName(
                            HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_MyProfileLightBox_BasicPreference_ClassName_Locator);
                        break;

                    case "Create a Course":
                        //Wait for Enroll in a Course light box
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_CreateaCourse_ID_Locator));
                        //Get the name of the lightbox
                        getLightboxName = base.GetInnerTextAttributeValueById(
                            HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_CreateaCourse_ID_Locator);
                        break;

                    //case "Enroll in a Course":
                    //    //Wait for Enroll in a Course light box
                    //    base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                    //        HEDGlobalHomePage_HomePage_EnrollInCourse_ID_Locator));
                    //    //Get the name of the lightbox
                    //    getLightboxName = base.GetInnerTextAttributeValueById(
                    //        HEDGlobalHomePageResource.
                    //        HEDGlobalHomePage_HomePage_EnrollInCourse_ID_Locator);
                    //    break;

                    case "Update Course":
                    case "Enroll in a Course":
                        //Wait for Enroll in a Course light box
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_Update_Course_ID_Locator));
                        //Get the name of the lightbox
                        getLightboxName = base.GetInnerTextAttributeValueById(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_Update_Course_ID_Locator);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "GetLightboxTitle",
                base.IsTakeScreenShotDuringEntryExit);
            return getLightboxName;
        }

        /// <summary>
        /// Get the channel name
        /// </summary>
        /// <param name="channelName">This is Channel Name.</param>
        /// <returns>Return the channel name.</returns>
        public string GetINSChannelDetails(string pageTitle, string channelName)
        {
            Logger.LogMethodEntry("TodaysViewUXPage", "GetINSChannelDetails",
                                  base.IsTakeScreenShotDuringEntryExit);
            string returnChannelName = string.Empty;
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(pageTitle);

                switch (channelName)
                {
                    case "My Courses and Testbanks":
                        //Wait for the element to load
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_MyCoursesandTestbanks_Channel_ID));
                        returnChannelName = base.GetInnerTextAttributeValueById
                            (HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_MyCoursesandTestbanks_Channel_ID);
                        break;

                    case "Announcements":
                        //Wait for the element to load
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_Announcement_Channel_ID));
                        returnChannelName = base.GetInnerTextAttributeValueById(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_Announcement_Channel_ID);
                        break;

                    case "Notifications":
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_Notification_Channel_ID));
                        returnChannelName = base.GetInnerTextAttributeValueById(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_Notification_Channel_ID);
                        break;

                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TodaysViewUXPage", "GetINSChannelDetails",
                                 base.IsTakeScreenShotDuringEntryExit);
            // Convert the text to lowercase and return the value
            return returnChannelName.ToLower();
        }

        /// <summary>
        /// Get the name of channel 
        /// </summary>
        /// <param name="channelName">This is Channel Name.</param>
        /// <returns>Return name of channel.</returns>
        public string GetStudChannelDetails(string pageTitle, string channelName)
        {
            Logger.LogMethodEntry("TodaysViewUXPage", "GetStudChannelDetails",
                                  base.IsTakeScreenShotDuringEntryExit);
            string returnChannelName = string.Empty;
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(pageTitle);

                switch (pageTitle)
                {
                    case "Today's View":
                        switch (channelName)
                        {
                            case "Notifications":
                                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                                    HEDGlobalHomePage_TodaysView_Notification_Channel_ID));
                                returnChannelName = base.GetInnerTextAttributeValueById(
                                    HEDGlobalHomePageResource.
                                    HEDGlobalHomePage_TodaysView_Notification_Channel_ID);
                                break;

                            case "Announcements":
                                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                                    HEDGlobalHomePage_TodaysView_Announcement_Channel_ID));
                                returnChannelName = base.GetInnerTextAttributeValueById(
                                    HEDGlobalHomePageResource.
                                    HEDGlobalHomePage_TodaysView_Announcement_Channel_ID);
                                break;

                            case "Calendar":
                                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                                      HEDGlobalHomePage_TodaysView_Calendar_Channel_ID));
                                returnChannelName = base.GetInnerTextAttributeValueById(
                                    HEDGlobalHomePageResource.
                                      HEDGlobalHomePage_TodaysView_Calendar_Channel_ID);
                                break;
                        }
                        break;

                    case "Global Home":
                        switch (channelName)
                        {
                            case "My Courses and Testbanks":
                                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                                    HEDGlobalHome_Page_MyCoursesandTestbanks_Channel_ID));
                                returnChannelName = base.GetInnerTextAttributeValueById(HEDGlobalHomePageResource.
                                    HEDGlobalHome_Page_MyCoursesandTestbanks_Channel_ID);
                                break;

                            case "Announcements":
                                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                                    HEDGlobalHome_Page_Announcement_Channel_ID));
                                returnChannelName = base.GetInnerTextAttributeValueById(HEDGlobalHomePageResource.
                                    HEDGlobalHome_Page_Announcement_Channel_ID);
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TodaysViewUXPage", "GetStudChannelDetails",
                                 base.IsTakeScreenShotDuringEntryExit);
            // Convert the text to lowercase and return the value
            return returnChannelName.ToLower();
        }

        /// <summary>
        /// Get the status of channel existance
        /// </summary>
        /// <param name="channelName">This is Channel Name.</param>
        /// <returns>Return status of channel existance.</returns>
        public string GetMyCoursesTestbanksButtonDetails(string buttonName)
        {
            Logger.LogMethodEntry("TodaysViewUXPage", "GetMyCoursesTestbanksButtonDetails",
                                 base.IsTakeScreenShotDuringEntryExit);
            string returnButtonName = string.Empty;
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(base.GetPageTitle);

                switch (buttonName)
                {
                    case "Create a Course":
                        // Get text from the application
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_CreateaCourse_Button_ID_Locator));
                        returnButtonName = base.GetValueAttributeById(HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_CreateaCourse_Button_ID_Locator);
                        break;

                    case "Enroll in a Course":
                        // Get text from the application
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_EnrollCourse_Button_ID_Locator));
                        returnButtonName = base.GetValueAttributeById(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_EnrollCourse_Button_ID_Locator);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TodaysViewUXPage", "GetMyCoursesTestbanksButtonDetails",
                                 base.IsTakeScreenShotDuringEntryExit);
            // Convert the text to lowercase and return the value
            return returnButtonName.ToLower();
        }

        /// <summary>
        /// Get the name of channel 
        /// </summary>
        /// <param name="channelName">This is Channel Name.</param>
        /// <returns>Return name of channel.</returns>
        public string GetAnnouncementsButtonDetails(string buttonName)
        {
            Logger.LogMethodEntry("TodaysViewUXPage", "GetAnnouncementsButtonDetails",
                                 base.IsTakeScreenShotDuringEntryExit);
            string returnbuttonName = string.Empty;
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(base.GetPageTitle);

                switch (buttonName)
                {
                    case "Manage All":
                        // Get text from the application
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_ManageAll_Button_ID_Locator));
                        returnbuttonName = base.GetInnerTextAttributeValueById(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_ManageAll_Button_ID_Locator);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TodaysViewUXPage", "GetAnnouncementsButtonDetails",
                                 base.IsTakeScreenShotDuringEntryExit);
            // Convert the text to lowercase and return the value
            return returnbuttonName.ToLower();
        }

        /// <summary>
        /// Click on create a course catalog 
        /// </summary>
        /// <param name="channelName">This is button Name.</param>
        public void ClickOptionsInMyCoursesTestbanksChannel(string buttonName, User.UserTypeEnum userType)
        {
            base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Window_Title_Name);
            try
            {
                switch (buttonName)
                {
                    case "Create a Course":
                        // Get text from the application
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_CreateaCourse_Button_ID_Locator));
                        base.ClickButtonById(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_CreateaCourse_Button_ID_Locator);
                        break;


                    case "Enroll in a Course":
                        switch (userType)
                        {

                            case User.UserTypeEnum.CsSmsInstructor:
                                // Get text from the application
                                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                                HEDGlobalHome_Page_EnrollinaCourse_Button_ID_Locator));

                                base.FocusOnElementById(HEDGlobalHomePageResource.
                                    HEDGlobalHome_Page_EnrollinaCourse_Button_ID_Locator);
                                base.ClickButtonById(HEDGlobalHomePageResource.
                                    HEDGlobalHome_Page_EnrollinaCourse_Button_ID_Locator);
                                break;

                            case User.UserTypeEnum.CsSmsStudent:
                                // Get text from the application
                                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                                    HEDGlobalHome_Page_EnrollCourse_Button_ID_Locator));
                                base.FocusOnElementById(HEDGlobalHomePageResource.
                                    HEDGlobalHome_Page_EnrollCourse_Button_ID_Locator);
                                base.ClickButtonById(HEDGlobalHomePageResource.
                                    HEDGlobalHome_Page_EnrollCourse_Button_ID_Locator);
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
        }


        /// <summary>
        /// Click on the Manage All option in Announcement channel
        /// </summary>
        /// <param name="channelName">This is the channel name.</param>
        public void ClickOptionsInAnnouncementsChannel(string channelName)
        {
            base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Window_Title_Name);
            switch (channelName)
            {
                case "Manage All":
                    // Get text from the application
                    base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_ManageAll_Button_ID_Locator));
                    base.ClickButtonById(HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_ManageAll_Button_ID_Locator);
                    break;
            }
        }


        /// <summary>
        /// Enter CourseId in Enroll in a Course wizard 
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        public void EnterCourseID(Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "EnterCourseID", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get course ID from InMemory
                Course course = Course.Get(courseType);
                string courseID = course.InstructorCourseId.ToString();
                // Wait for Course ID text box to load
                base.SelectWindow(base.GetPageTitle);
                base.SwitchToIFrameById("openModalPopupframe");

                //base.SwitchToIFrameById(HEDGlobalHomePageResource.
                //    HEDGlobalHomePage_HomePageIframe_ID_Locator);
                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                       HedGlobalHome_Page_CourseID_TextBox_Id_Locator));
                // Fill textbox with course ID
                base.FillTextBoxById(HEDGlobalHomePageResource.
                       HedGlobalHome_Page_CourseID_TextBox_Id_Locator, courseID);
                // Click submit button
                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_EnrollInCourse_SubmitButtonl_ID_Locator));
                base.ClickButtonById(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_EnrollInCourse_SubmitButtonl_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "EnterCourseID", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter CourseId in Enroll in a Course wizard 
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        public void EnterCourseIsbn(Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "EnterCourseID", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get course ID from InMemory
                Course course = Course.Get(courseType);
                string courseISBN = course.ISBN.ToString();
                // Wait for Course ID text box to load
                base.SelectWindow(base.GetPageTitle);
                //Swith to create course Iframe
                base.SwitchToIFrameById(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_SwitchToCCFrame_Id_Locator);
                //Clear the course name textbox
                base.ClearTextById(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_CourseNameTextbox_Id_Locator);
                // Fill textbox with course ID
                base.FillTextBoxById(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_CourseNameTextbox_Id_Locator, courseISBN);
                // Click submit button
                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_SingleCourseCreation_NextButton_Id_Locator));
                base.ClickButtonById(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_SingleCourseCreation_NextButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "EnterCourseID", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// This methord is to get the options available in Enroll In Course
        /// </summary>
        /// <param name="stepCount">This is step count available in "Enroll In Course" lightbox.</param>
        /// <param name="stepName">This is step name available in "Enroll In Course" lightbox.</param>
        /// <returns>Return status.</returns>
        public bool GetEnrollInCourseOptions(int stepCount, string stepName)
        {
            bool returnStatus = false;

            base.SelectWindow(base.GetPageTitle);
            base.SwitchToIFrameById(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePageIframe_ID_Locator);
            switch (stepCount)
            {
                case 1:
                    //Get the step count from teh enrollment window
                    base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                        HEDGlobalHomePage_HomePage_EnrollInACourse_Step1Count_XPath_Locator));
                    string count = base.GetInnerTextAttributeValueByXPath(HEDGlobalHomePageResource.
                        HEDGlobalHomePage_HomePage_EnrollInACourse_Step1Count_XPath_Locator);
                    int appCount = Convert.ToInt32(count);
                    base.WaitForElement(By.ClassName(HEDGlobalHomePageResource.
                        HEDGlobalHomePage_HomePage_EnrollInACourse_Step1Name_ClassName_Locator));
                    string appStepName = base.GetInnerTextAttributeValueByClassName(HEDGlobalHomePageResource.
                        HEDGlobalHomePage_HomePage_EnrollInACourse_Step1Name_ClassName_Locator);

                    if (appCount == stepCount && appStepName == stepName)
                    {
                        returnStatus = true;
                    }
                    break;

                case 2:
                    base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                        HEDGlobalHomePage_HomePage_EnrollInACourse_Step2Count_XPath_Locator));
                    count = base.GetInnerTextAttributeValueByXPath(HEDGlobalHomePageResource.
                        HEDGlobalHomePage_HomePage_EnrollInACourse_Step2Count_XPath_Locator);
                    appCount = Convert.ToInt32(count);
                    if (appCount == stepCount)
                    {
                        returnStatus = true;
                    }
                    break;
            }


            return returnStatus;
        }

        /// <summary>
        /// Get the course enrollment success message from the application.
        /// </summary>
        /// <returns>Return success message.</returns>
        public string getSuccessMessage()
        {
            string returnSuccessMessage = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(base.GetPageTitle);
                base.SelectWindow(base.GetPageTitle);

                // Switch to Iframe
                base.SwitchToIFrameById("openModalPopupframe");
                //base.SwitchToIFrameById(HEDGlobalHomePageResource.
                //    HEDGlobalHomePage_HomePageIframe_ID_Locator);
                bool ds = base.IsElementPresent(By.XPath("//div[@class='span11 success-msg']"), 10);
                base.WaitForElement(By.XPath("//div[@class='span11 success-msg']"));
                returnSuccessMessage = base.GetInnerTextAttributeValueByXPath("//div[@class='span11 success-msg']");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return returnSuccessMessage;
        }

        /// <summary>
        /// This methord is to get the course name.
        /// </summary>
        /// <returns>Return the course name.</returns>
        public string getCourseName()
        {
            string returnCourseName = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(base.GetPageTitle);
                base.SelectWindow(base.GetPageTitle);

                // Switch to Iframe
                //base.SwitchToIFrameById(HEDGlobalHomePageResource.
                //    HEDGlobalHomePage_HomePageIframe_ID_Locator);
                base.SwitchToIFrameById("openModalPopupframe");
                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_CourseNameFromTheTable_Id_Locator));
                returnCourseName = base.GetInnerTextAttributeValueById(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_CourseNameFromTheTable_Id_Locator);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return returnCourseName;
        }

        /// <summary>
        /// Confirm the enrollment for the user
        /// </summary>
        /// <param name="buttonName"></param>
        public void ClickConfirmButtoninEnrollACourse(string buttonName)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickButton", base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(base.GetPageTitle);
            base.SelectWindow(base.GetPageTitle);
            base.SwitchToIFrameById("openModalPopupframe");
            //base.SwitchToIFrameById(HEDGlobalHomePageResource.
            //        HEDGlobalHomePage_HomePageIframe_ID_Locator);
            base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                HEDGlobalHomePage_HomePage_EnrollInACourse_Confirm_Id_Locator));
            base.ClickButtonById(HEDGlobalHomePageResource.
                HEDGlobalHomePage_HomePage_EnrollInACourse_Confirm_Id_Locator);

            Logger.LogMethodExit("HEDGlobalHomePage", "ClickButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the enrolled course details from "My Courses and Testbanks " channel
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        /// <param name="frameName">This is frame name.</param>
        /// <returns>Return status of course display</returns>
        public bool GetEnrolledCourseDetailsInChannel(Course.CourseTypeEnum courseType, string frameName)
        {
            bool returnCourseDisplay = false;
            try
            {
                Course course = Course.Get(courseType);
                string courseName = course.Name.ToString();
                base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);
                //Select Window
                base.SelectWindow(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);

                returnCourseDisplay = getCourseName(courseName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return returnCourseDisplay;
        }
        /// <summary>
        /// This methord is to get the course name from "My Courses and Testbanks" channel
        /// </summary>
        /// <param name="courseName">This is course type enum.</param>
        /// <returns>Return course existance status.</returns>
        private bool getCourseName(string courseName)
        {
            bool returnStatus = false;
            // Search and Click Course Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickOnCourseLink"
                , base.IsTakeScreenShotDuringEntryExit);
            //Get Course Row Counter
            const int getCourseRowCounter = 1;
            base.WaitForElement(
                By.XPath(string.Format(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Course_Table_Row_XPath_Locator,
                                       getCourseRowCounter)));
            // Click the course name
            returnStatus = GetCourseNameOnHomePage(courseName, getCourseRowCounter);

            Logger.LogMethodExit("HEDGlobalHomePage", "ClickOnCourseLink",
                base.IsTakeScreenShotDuringEntryExit);
            return returnStatus;
        }

        /// <summary>
        /// Select the course on home page.
        /// </summary>
        /// <param name="courseName">This is the course name.</param>
        /// <param name="courseDivCounter">This is the div count.</param>
        private bool GetCourseNameOnHomePage
            (string courseName, int courseDivCounter)
        {
            bool returnStatus = false;
            //Get HTML Element Property 
            IWebElement courseTable = base.GetWebElementPropertiesByXPath(
                string.Format(HEDGlobalHomePageResource.
                HEDGlobalHomePage_HomePage_CourseTotalCount_XPath_Locator, courseDivCounter));
            if (!courseTable.Text.Contains(courseName))
            {
                //Get The Course From Each Row
                while (!courseTable.Text.Contains(courseName))
                {
                    courseDivCounter = courseDivCounter + 1;
                    //Get Course Row Text
                    string getCourseRowText = base.GetElementTextByXPath(string.Format(
                      HEDGlobalHomePageResource.
                      HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, courseDivCounter));
                    //If Course Present on the User Home Page
                    if (getCourseRowText.Contains(courseName))
                    {
                        returnStatus = true;
                        break;
                    }
                }
            }
            return returnStatus;
        }

        /// <summary>
        /// Click open button of the course.
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        public void ClickOpenButtonOfCourse(Course.CourseTypeEnum courseTypeEnum, User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickOpenButtonOfCourse", base.IsTakeScreenShotDuringEntryExit);
            //Enter Inside the Course

            try
            {
                //Get Course From Memory
                Course course = Course.Get(courseTypeEnum);
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.HedCoreAcceptanceInstructor:
                    case User.UserTypeEnum.HedCoreAcceptanceStudent:
                    case User.UserTypeEnum.HedWsInstructor:
                    case User.UserTypeEnum.HedWsStudent:
                    case User.UserTypeEnum.HedProgramAdmin:
                    case User.UserTypeEnum.AmpProgramAdmin:
                    case User.UserTypeEnum.HSSProgramAdmin:
                    case User.UserTypeEnum.HedMilAcceptanceInstructor:
                    case User.UserTypeEnum.WLProgramAdmin:
                    case User.UserTypeEnum.RegHedWsInstructor:
                    case User.UserTypeEnum.RegHedWsStudent:
                    case User.UserTypeEnum.S11eTextInstructor:
                    case User.UserTypeEnum.S11eTextStudent:
                        switch (courseTypeEnum)
                        {
                            //Course Type Enum
                            case Course.CourseTypeEnum.ProgramCourse:
                            case Course.CourseTypeEnum.MyItLabProgramCourse:
                            case Course.CourseTypeEnum.MySpanishLabMaster:
                            case Course.CourseTypeEnum.RegMySpanishLabMaster:
                            case Course.CourseTypeEnum.AmpWSCourse:
                            case Course.CourseTypeEnum.MyItLabSIM5MasterCourse:
                            case Course.CourseTypeEnum.MyItLabSIMMasterCourse:
                            case Course.CourseTypeEnum.MyItLabInstructorCourse:
                            case Course.CourseTypeEnum.InstructorCourse:
                            case Course.CourseTypeEnum.HEDGeneral:
                            case Course.CourseTypeEnum.HedMilAcceptanceSIMProgramCourse:
                            case Course.CourseTypeEnum.HedMilAcceptanceSIM5ProgramCourse:
                            case Course.CourseTypeEnum.HedCoreAcceptanceProgramCourse:
                            case Course.CourseTypeEnum.MyTestInstructorCourse:
                            case Course.CourseTypeEnum.MyTestBankCourse:
                            case Course.CourseTypeEnum.HedEmptyClass:
                            case Course.CourseTypeEnum.GraderITSIM5Course:
                            case Course.CourseTypeEnum.MyITLabOffice2013Program:
                            case Course.CourseTypeEnum.HedMyPsychLabProgram:
                            case Course.CourseTypeEnum.MySpanishLabTestingMaster:
                            case Course.CourseTypeEnum.HSSMyPsychLabProgram:
                            case Course.CourseTypeEnum.MySpanishLabProgram:
                            case Course.CourseTypeEnum.AmpProgramCourse:
                            case Course.CourseTypeEnum.MyITLabOffice2013ProgramCourseCreation:
                            case Course.CourseTypeEnum.eTextCourse:
                                //Open the Course
                                this.ClickOpenButtonOfTheCourse(course.Name);
                                break;
                        }
                        break;
                    case User.UserTypeEnum.HedTeacherAssistant:
                    case User.UserTypeEnum.HSSCsSmsStudent:
                    case User.UserTypeEnum.WLCsSmsStudent:
                    case User.UserTypeEnum.AmpCsSmsStudent:
                    case User.UserTypeEnum.RegCsSmsStudent:
                        switch (courseTypeEnum)
                        {
                            case Course.CourseTypeEnum.ProgramCourse:
                            case Course.CourseTypeEnum.HedMyPsychLabProgram:
                            case Course.CourseTypeEnum.HSSMyPsychLabProgram:
                            case Course.CourseTypeEnum.MySpanishLabMaster:
                            case Course.CourseTypeEnum.RegMySpanishLabMaster:
                            case Course.CourseTypeEnum.MyITLabOffice2013Program:
                            case Course.CourseTypeEnum.MySpanishLabProgram:
                                //Open the Course
                                this.ClickOpenButtonOfTheCourse(course.SectionName);
                                break;
                            case Course.CourseTypeEnum.MyItLabProgramCourse:
                                //Open the Course
                                this.ClickOpenButtonOfTheCourse(course.SectionName +
                                    HEDGlobalHomePageResource.HEDGlobalHome_Page_SectionValue);
                                break;
                            case Course.CourseTypeEnum.InstructorCourse:
                            case Course.CourseTypeEnum.RegWLMasterCourse:
                            case Course.CourseTypeEnum.AmpInstructorCourse:
                            case Course.CourseTypeEnum.MyTestInstructorCourse:
                            case Course.CourseTypeEnum.MyItLabInstructorCourse:
                            case Course.CourseTypeEnum.HedMyItLabPPECourse:
                            case Course.CourseTypeEnum.HedMilSelfStudy:
                                //Open the Course
                                this.ClickOpenButtonOfTheCourse(course.Name);
                                break;
                        }
                        break;
                    case User.UserTypeEnum.CsSmsInstructor:
                    case User.UserTypeEnum.RegCsSmsInstructor:
                    case User.UserTypeEnum.AmpCsSmsInstructor:
                    case User.UserTypeEnum.HSSCsSmsInstructor:
                    case User.UserTypeEnum.WLCsSmsInstructor:
                    case User.UserTypeEnum.MyTestSmsInstructor:
                    case User.UserTypeEnum.CsSmsStudent:
                        switch (courseTypeEnum)
                        {
                            case Course.CourseTypeEnum.ProgramCourse:
                            case Course.CourseTypeEnum.MyTestInstructorCourse:
                            case Course.CourseTypeEnum.RegMyITLabNewCourseForEnrollment:
                            case Course.CourseTypeEnum.MyTestBankCourse:
                            case Course.CourseTypeEnum.MyItLabProgramCourse:
                            case Course.CourseTypeEnum.MyItLabInstructorCourse:
                            case Course.CourseTypeEnum.InstructorCourse:
                            case Course.CourseTypeEnum.AmpInstructorCourse:
                            case Course.CourseTypeEnum.RegWLMasterCourse:
                            case Course.CourseTypeEnum.RegMyITLabNewlyCreatedCourse:
                            case Course.CourseTypeEnum.MyItLabAuthoredCourse:
                                //Open the Program Course
                                this.ClickOpenButtonOfTheCourse(course.Name);
                                break;
                            case Course.CourseTypeEnum.MyITLabOffice2013Program:
                            case Course.CourseTypeEnum.HSSMyPsychLabProgram:
                            case Course.CourseTypeEnum.MySpanishLabProgram:
                            case Course.CourseTypeEnum.MySpanishLabProgramMyTest:
                                //Open the Course
                                this.ClickOpenButtonOfTheCourse(course.SectionName);
                                break;

                        }
                        break;
                }
                //Store User Last Login Details In Memory
                this.StoreUserLastLoginDetailsInMemory();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickOpenButtonOfCourse", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open The Course.
        /// </summary>
        /// <param name="courseName">This is Course Name.</param>
        public void ClickOpenButtonOfTheCourse(String courseName)
        {
            // Open Course by clicking on course Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "OpenTheCourse"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Window_Title_Name);
                //Select Window
                base.SelectWindow(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Window_Title_Name);
                //Click Course Name Link
                ClickOnOpenButton(courseName);
                CourseName = courseName;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "OpenTheCourse"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Course Link To Open.
        /// </summary>
        /// <param name="courseName">This is Course Name.</param>
        private void ClickOnOpenButton(String courseName)
        {
            // Search and Click Course Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickOnCourseLink"
                , base.IsTakeScreenShotDuringEntryExit);
            //Get Course Row Counter
            const int getCourseRowCounter = 1;
            base.WaitForElement(
            By.XPath(string.Format(HEDGlobalHomePageResource.
            HEDGlobalHome_Page_Course_Table_Row_XPath_Locator,
                           getCourseRowCounter)));
            // Click the course name
            ClickOpenButtonOnHomePage(courseName, getCourseRowCounter);
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickOnCourseLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// This methord is to refresh browser till Instructor course copy
        /// </summary>
        /// <param name="courseName">This is course name choosen to create.</param>
        /// <param name="courseCopyStatusMessageMyTest">This is course copy status message.</param>
        private void ClickOpenButtonOnHomePage(string courseName, int courseDivCounter)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickCourseNameOnHomePage"
            , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                                           HEDGlobalHome_Page_Window_Title_Name);
                base.SelectWindow(HEDGlobalHomePageResource.
                                   HEDGlobalHome_Page_Window_Title_Name);
                // Get course count
                int getCourseCount = base.GetElementCountByXPath(HEDGlobalHomePageResource.
                    HEDGlobalHome_GetCourse_Count_Xparth_Locator);
                for (int i = courseDivCounter; i <= getCourseCount; i++)
                {
                    // Get Course name
                    string getCourseName = base.GetInnerTextAttributeValueByXPath(
                    string.Format(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Course_Name_XPath_Locator, i));

                    if (getCourseName.Equals(courseName))
                    {
                        // Enter inside course
                        IWebElement getCourse = base.GetWebElementPropertiesByXPath(string.Format(
                            HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_OpenButton_XPath_Locator, i));
                        base.ClickByJavaScriptExecutor(getCourse);
                        break;
                    }

                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickCourseNameOnHomePage"
            , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to get the options available on my testbank
        /// </summary>
        /// <param name="stepCount">This is step count available in "Enroll In Course" lightbox.</param>
        /// <param name="stepName">This is step name available in "Enroll In Course" lightbox.</param>
        /// <param name="popUpName">This is popup name available in "Enroll In Course" lightbox.</param>
        /// <returns>Return status.</returns>
        public bool GetCourseOptions(int stepCount, string stepName, string popUpName, User.UserTypeEnum userType)
        {

            Logger.LogMethodEntry("HEDGlobalHomePage", "GetCourseOptions"
                , base.IsTakeScreenShotDuringEntryExit);
            //Set default returnstatus to false
            bool returnStatus = false;
            //Select the current window
            base.SelectWindow(base.GetPageTitle);
            try
            {
                //Switch to identified popup
                switch (popUpName)
                {
                    //Select create a course popup
                    case "Create a Course":
                        {
                            base.SwitchToIFrameById(HEDGlobalHomePageResource.
                                HEDGlobalHomePage_HomePage_CreateaCourse_IFrame_Id_Locator);
                            switch (stepCount)
                            {
                                case 1:
                                    //Get appliation step count
                                    base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                                    HEDGlobalHomePage_HomePage_CreateaCourse_Step1Count_XPath_Locator));
                                    string count = base.GetInnerTextAttributeValueByXPath
                                        (HEDGlobalHomePageResource.
                                        HEDGlobalHomePage_HomePage_CreateaCourse_Step1Count_XPath_Locator);
                                    int appCount = Convert.ToInt32(count);
                                    //Get appliation step name
                                    base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                                        HEDGlobalHomePage_HomePage_AppStepname_CreateCourse_XPath_Locator));
                                    string appStepName = base.GetInnerTextAttributeValueByXPath(HEDGlobalHomePageResource.
                                        HEDGlobalHomePage_HomePage_AppStepname_CreateCourse_XPath_Locator);
                                    //Compare appcount and aname with expected ount and name
                                    if (appCount == stepCount && appStepName == stepName)
                                    {
                                        //return the status as true condition satisfied
                                        returnStatus = true;
                                    }
                                    break;
                                case 2:
                                    //Get appliation step count
                                    base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                                        HEDGlobalHomePage_HomePage_CreateaCourse_Step2Count_XPath_Locator));
                                    //Store cont to count variable
                                    count = base.GetInnerTextAttributeValueByXPath(HEDGlobalHomePageResource.
                                        HEDGlobalHomePage_HomePage_CreateaCourse_Step2Count_XPath_Locator);
                                    appCount = Convert.ToInt32(count);
                                    if (appCount == stepCount)
                                    {
                                        returnStatus = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    //Select enroll in a course popup
                    case "Enroll in a Course":

                        switch (userType)
                        {
                            case User.UserTypeEnum.CsSmsInstructor:
                                {
                                    // base.SwitchToIFrameById("openModalPopupframe")
                                    base.SwitchToIFrameById(HEDGlobalHomePageResource.
                                    HEDGlobalHomePage_HomePage_CreateaCourse_IFrame_Id_Locator);

                                    switch (stepCount)
                                    {
                                        case 1:
                                            //Get application step count
                                            base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                                                HEDGlobalHomePage_HomePage_EnrollInACourse_Step1Count_XPath_Locator));
                                            string count = base.GetInnerTextAttributeValueByXPath(HEDGlobalHomePageResource.
                                                HEDGlobalHomePage_HomePage_EnrollInACourse_Step1Count_XPath_Locator);
                                            int appCount = Convert.ToInt32(count);
                                            //Get appliation step name
                                            bool sjk = base.IsElementPresent(By.XPath("//div[@class='width-110 pull-left']/label"), 10);
                                            base.WaitForElement(By.XPath("//div[@class='width-110 pull-left']/label"));
                                            string appStepName = base.GetInnerTextAttributeValueByXPath("//div[@class='width-110 pull-left']/label");
                                            //base.WaitForElement(By.ClassName(HEDGlobalHomePageResource.
                                            //    HEDGlobalHomePage_HomePage_EnrollInACourse_Step1Name_ClassName_Locator));
                                            //string appStepName = base.GetInnerTextAttributeValueByClassName(HEDGlobalHomePageResource.
                                            //    HEDGlobalHomePage_HomePage_EnrollInACourse_Step1Name_ClassName_Locator);
                                            //Compare appcount and aname with expected ount and name
                                            if (appCount == stepCount && appStepName == stepName)
                                            {
                                                //return the status as true condition satisfied
                                                returnStatus = true;
                                            }
                                            break;
                                        case 2:
                                            //Get appliation step count
                                            base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                                                HEDGlobalHomePage_HomePage_EnrollInACourse_Step2Count_XPath_Locator));
                                            count = base.GetInnerTextAttributeValueByXPath(HEDGlobalHomePageResource.
                                                HEDGlobalHomePage_HomePage_EnrollInACourse_Step2Count_XPath_Locator);
                                            appCount = Convert.ToInt32(count);
                                            if (appCount == stepCount)
                                            {
                                                returnStatus = true;
                                            }
                                            break;
                                    }
                                }
                                break;

                            case User.UserTypeEnum.CsSmsStudent:
                                {
                                    base.SwitchToIFrameById("openModalPopupframe");
                                    //base.SwitchToIFrameById(HEDGlobalHomePageResource.
                                    //    HEDGlobalHomePage_HomePageIframe_ID_Locator);
                                    switch (stepCount)
                                    {
                                        case 1:
                                            //Get application step count
                                            base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                                                HEDGlobalHomePage_HomePage_EnrollnCourse_StudStep2_XPath_Locator));
                                            string count = base.GetInnerTextAttributeValueByXPath
                                                (HEDGlobalHomePageResource.
                                                HEDGlobalHomePage_HomePage_EnrollnCourse_StudStep2_XPath_Locator);
                                            int appCount = Convert.ToInt32(count);
                                            //Get appliation step name
                                            base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                                                HEDGlobalHomePage_HomePage_EnrollInACourse_StepName2Student_XPath_Locator));
                                            string appStepName = base.GetInnerTextAttributeValueByXPath
                                                (HEDGlobalHomePageResource.
                                                HEDGlobalHomePage_HomePage_EnrollInACourse_StepName2Student_XPath_Locator);
                                            //Compare appcount and appname with expected ount and name
                                            if (appCount == stepCount && appStepName == stepName)
                                            {
                                                //return the status as true condition satisfied
                                                returnStatus = true;
                                            }
                                            break;
                                        case 2:
                                            //Get appliation step count
                                            base.WaitForElement(By.XPath(HEDGlobalHomePageResource.
                                                HEDGlobalHomePage_HomePage_EnrollInACourse_Step2Count_XPath_Locator));
                                            count = base.GetInnerTextAttributeValueByXPath(HEDGlobalHomePageResource.
                                                HEDGlobalHomePage_HomePage_EnrollInACourse_Step2Count_XPath_Locator);
                                            appCount = Convert.ToInt32(count);
                                            //Compare the appcount with the step count
                                            if (appCount == stepCount)
                                            {
                                                returnStatus = true;
                                            }
                                            break;
                                    }
                                }
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "GetCourseOptions"
             , base.IsTakeScreenShotDuringEntryExit);
            //Return the status
            return returnStatus;
        }

        /// <summary>
        /// This methord is to create course based on course ISBN
        /// </summary>
        /// <param name="btnName">This is button to create course.</param>
        /// <param name="courseType">This is course choosen to create.</param>
        public void CreateICCourseByISBN(string btnName, Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "CreateICCourseByISBN"
            , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the course
                base.ClickButtonById(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_CreateCourse_ISBN_Id_Locator);
                //Get course name from the inmemory
                string courseNameGUID = this.GenerateCourseGUID(courseType);
                this.StoreCourseGUID(courseNameGUID, courseType);
                //Fill the course name
                this.FillCourseDetails(courseNameGUID);
                this.GetCourseID(courseType, courseNameGUID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);

            }
            Logger.LogMethodExit("HEDGlobalHomePage", "CreateICCourseByISBN"
             , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseType"></param>
        /// <param name="courseNameGUID"></param>
        private void GetCourseID(Course.CourseTypeEnum courseType, string courseNameGUID)
        {
            //Get the course ID and store to inmemory
            int rowCount = base.GetElementCountByXPath(HEDGlobalHomePageResource.
           HEDGlobalHomePage_GetCourseCount_XPath_Locator);

            for (int i = 1; i <= rowCount; i++)
            {
                string courseTable = base.GetElementTextByXPath(string.Format(
                    HEDGlobalHomePageResource.HEDGlobalHome_Page_Course_Name_XPath_Locator, i));
                if (courseTable.Contains(courseNameGUID))
                {
                    //Get the ID of the course
                    string courseId = base.GetElementTextByXPath(string.Format(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_GetCreatedCourseID_XPath_Locator, i));
                    string courseIDForEnrollment = courseId.Substring(4);
                    this.StoreCourseIdGUID(courseIDForEnrollment, courseNameGUID, courseType);
                    break;
                }
            }
        }

        /// <summary>
        /// This methord is to check the copy status of created course
        /// </summary>
        /// <param name="courseType">This is course choosen to create.</param>
        /// /// <param name="frameName">This is frame name where course is copied.</param>
        public bool GetCreatedCourseDetailsInChannel(Course.CourseTypeEnum courseType, string frameName)
        {

            Logger.LogMethodEntry("HEDGlobalHomePage", "GetCreatedCourseDetailsInChannel"
                , base.IsTakeScreenShotDuringEntryExit);
            bool getCopyCompleteStatus = false;
            try
            {
                //Get Course name
                Course course = Course.Get(courseType);
                string courseName = course.Name.ToString();
                //Assign copy status 
                string courseCopyStatusMessageIC = HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_CopyStatus_Text_Id_Locator;
                string courseCopyStatusMessageMyTest = HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_CopyStatus_MyTest_Id_Locator;
                switch (courseType)
                {
                    case Course.CourseTypeEnum.MyItLabAuthoredCourse:
                    case Course.CourseTypeEnum.RegMyITLabNewlyCreatedCourse:
                    case Course.CourseTypeEnum.MyItLabInstructorCourse:
                        getCopyCompleteStatus = this.SearchForNewlyCreatedCourse(courseName, courseCopyStatusMessageIC);
                        break;
                    case Course.CourseTypeEnum.MyTestAuthoredCourse:
                        this.refreshTillMyTestCourseCopy(courseName, courseCopyStatusMessageMyTest);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "GetCreatedCourseDetailsInChannel"
             , base.IsTakeScreenShotDuringEntryExit);
            return getCopyCompleteStatus;
        }

        /// <summary>
        /// This methord is to refresh browser till Instructor course copy
        /// </summary>
        /// <param name="courseName">This is course name choosen to create.</param>
        /// <param name="courseCopyStatusMessageMyTest">This is course copy status message.</param>
        public bool SearchForNewlyCreatedCourse(string courseName, string courseCopyStatusMessageIC)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "refreshTillMyTestCourseCopy"
            , base.IsTakeScreenShotDuringEntryExit);
            bool getCopyCompleteStatus = false;
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                                           HEDGlobalHome_Page_Window_Title_Name);
                base.SelectWindow(HEDGlobalHomePageResource.
                                   HEDGlobalHome_Page_Window_Title_Name);
                //Initiate the stop watch
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                // Wait till entity enters from inactive state to active state
                int minutesToWait = Int32.Parse(ConfigurationManager.
                    AppSettings[HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_CopyInterval_time_Text_Id_Locator]);
                bool asd = base.IsElementPresent(By.XPath("//div[@id='tblCourse']/div/div"), 10);
                int getCourseCount = base.GetElementCountByXPath("//div[@id='tblCourse']/div/div");
                for (int i = 1; i <= getCourseCount; i++)
                {
                    bool asqwd = base.IsElementPresent(
                    By.XPath(string.Format("//div[@id ='tblCourse']/div/div[{0}]/div/div/div/table/tbody/tr/td/div/div/div/a", i)), 10);
                    string getCourseName = base.GetInnerTextAttributeValueByXPath(
                    string.Format(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Course_Name_XPath_Locator, i));
                    //Get Course Row Text
                    string getCourseRowText = base.GetElementTextByXPath(string.Format(
                    HEDGlobalHomePageResource.HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, i));
                    if (getCourseName.Equals(courseName) == true &&
                           getCourseRowText.Contains(courseCopyStatusMessageIC) == true)
                    {
                        while (stopwatch.Elapsed.TotalMinutes < minutesToWait)
                        {
                            getCourseRowText = base.GetElementTextByXPath(string.Format(
                        HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, i));
                            if (getCourseName.Equals(courseName) == true &&
                           getCourseRowText.Contains(courseCopyStatusMessageIC) == true)
                            {
                                //Refresh the page till course successfuly copied
                                base.RefreshTheCurrentPage();
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                getCopyCompleteStatus = true;
                                break;
                            }
                        }
                        break;
                    }

                    else if (getCourseName.Equals(courseName) == true &&
                           getCourseRowText.Contains(courseCopyStatusMessageIC) == false)
                    {
                        getCopyCompleteStatus = true;
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "refreshTillMyTestCourseCopy"
            , base.IsTakeScreenShotDuringEntryExit);

            return getCopyCompleteStatus;
        }


        /// <summary>
        /// This methord is to refresh browser till Instructor course copy
        /// </summary>
        /// <param name="courseName">This is course name choosen to create.</param>
        /// <param name="courseCopyStatusMessageMyTest">This is course copy status message.</param>
        private void refreshTillIcCourseCopy(string courseName, string courseCopyStatusMessageIC)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "GetCreatedCourseDetailsInChannel"
    , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Initialize the div counter
                int courseDivCounter = 1;
                //Get HTML Element Property 
                IWebElement courseTable = base.GetWebElementPropertiesByXPath(
                string.Format(string.Format(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Course_Name_XPath_Locator, courseDivCounter)));
                //Initiate the stop watch
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                // Wait till entity enters from inactive state to active state
                int minutesToWait = Int32.Parse(ConfigurationManager.
                    AppSettings[HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_CopyInterval_time_Text_Id_Locator]);
                while (!courseTable.Text.Contains(courseName))
                {
                    courseDivCounter = courseDivCounter + 1;
                    //Get Course Row Text
                    string getCourseRowText = base.GetElementTextByXPath(string.Format(
                    HEDGlobalHomePageResource.HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, courseDivCounter));
                    //Compare the row text and identify the course
                    if (getCourseRowText.Contains(courseName) && getCourseRowText.Contains(courseCopyStatusMessageIC))
                    {
                        while (stopwatch.Elapsed.TotalMinutes < minutesToWait)
                        {
                            getCourseRowText = base.GetElementTextByXPath(string.Format(
                        HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, courseDivCounter));
                            if (getCourseRowText.Contains(courseName) == true &&
                           getCourseRowText.Contains(courseCopyStatusMessageIC) == false) break;
                            {
                                //Refresh the page till course successfuly copied
                                base.RefreshTheCurrentPage();
                                Thread.Sleep(1000);
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "refreshTillMyTestCourseCopy"
             , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to refresh browser till Mytest course copy
        /// </summary>
        /// <param name="courseName">This is course name choosen to create.</param>
        /// <param name="courseCopyStatusMessageMyTest">This is course copy status message.</param>
        private void refreshTillMyTestCourseCopy(string courseName, string courseCopyStatusMessageMyTest)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "refreshTillMyTestCourseCopy"
    , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Initialize the div counter
                int courseDivCounter = 1;
                //Get HTML Element Property 
                IWebElement courseTable = base.GetWebElementPropertiesByXPath(
                string.Format(string.Format(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Course_Name_XPath_Locator, courseDivCounter)));
                //Initiate the stop watch
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                // Wait till entity enters from inactive state to active state
                int minutesToWait = Int32.Parse(ConfigurationManager.
                    AppSettings[HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_CopyInterval_time_Text_Id_Locator]);
                while (!courseTable.Text.Contains(courseName))
                {
                    courseDivCounter = courseDivCounter + 1;
                    //Get Course Row Text
                    string getCourseRowText = base.GetElementTextByXPath(string.Format(
                    HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, courseDivCounter));
                    //Compare the row text and identify the course
                    if (getCourseRowText.Contains(courseName) &&
                        getCourseRowText.Contains(courseCopyStatusMessageMyTest))
                    {
                        while (stopwatch.Elapsed.TotalMinutes < minutesToWait)
                        {
                            getCourseRowText = base.GetElementTextByXPath(string.Format(
                        HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, courseDivCounter));
                            if (getCourseRowText.Contains(courseName) == true &&
                           getCourseRowText.Contains(courseCopyStatusMessageMyTest) == false) break;
                            {
                                base.RefreshTheCurrentPage();
                                Thread.Sleep(1000);
                            }
                        }
                        break;
                    }
                }
                Logger.LogMethodExit("HEDGlobalHomePage", "refreshTillMyTestCourseCopy"
                 , base.IsTakeScreenShotDuringEntryExit);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Select discipline by dropdown option.
        /// </summary>
        /// <param name="dropdownOption">This is Dropdown Option.</param>
        public void SelectDisciplineByDropdownOption(string dropdownOption)
        {
            //Select 'View By' Dropdown Option
            Logger.LogMethodEntry("HEDGlobalHomePage", "SelectDisciplineByDropdownOption",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select browse by discipline radio button
                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_BrowseByDiscipline_Id_Locator));
                base.SelectRadioButtonById(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_BrowseByDiscipline_Id_Locator);
                //Focus on dropdown option
                base.FocusOnElementById(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_SelectDiscipline_Id_Locator);
                //Click on drop down option and select All discipline
                base.SelectDropDownValueThroughTextById(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_SelectDiscipline_Id_Locator, dropdownOption);
                //Click on next button
                base.ClickButtonById(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_HomePage_SingleCourseCreation_NextButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "SelectDisciplineByDropdownOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to create IC course by discipline
        /// </summary>
        /// <param name="courseType">This is course choosen to create.</param>
        /// /// <param name="frameName">This is frame name where course is copied.</param>
        public void CreateCourseByDiscipline(string btnName, Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "CreateICCourseByDiscipline"
                    , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                int i = Convert.ToInt32(1);
                //Get course name
                Course courseName = Course.Get(courseType);
                string actualCourseName = courseName.Name.ToString();
                //Generate the unique GUID
                string courseNameGUID = this.GenerateCourseGUID(courseType);
                //Store the GUID in memory
                this.StoreCourseGUID(courseNameGUID, courseType);

                switch (courseType)
                {
                    //Create course of type instructor
                    case Course.CourseTypeEnum.MyItLabAuthoredCourse:
                    case Course.CourseTypeEnum.RegMyITLabNewlyCreatedCourse:
                        this.CreateInstructorCourse(actualCourseName, courseNameGUID);
                        //Get the course Id of the course and store in inmemory
                        this.GetCourseIDFromAPP(courseNameGUID, courseType);
                        break;
                    //Create course of type mytest
                    case Course.CourseTypeEnum.MyTestAuthoredCourse:
                        this.CreateMyTestCourse(actualCourseName, courseNameGUID);
                        //Get the course Id of the course and store in inmemory
                        this.GetCourseIDFromAPP(courseNameGUID, courseType);
                        break;
                    //Create course of type program
                    case Course.CourseTypeEnum.MyITLabOffice2013Program:
                        this.CreateProgramCourse(actualCourseName, courseType, courseNameGUID);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "CreateICCourseByDiscipline"
            , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create instructor course
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        private void CreateInstructorCourse(string actualCourseName, string courseNameGUID)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "CreateInstructorCourse",
            base.IsTakeScreenShotDuringEntryExit);                         
                bool getNextButtonStatus;
                //Fetch the Next button status
                getNextButtonStatus = base.IsElementPresent(By.XPath("//div[@id='_ctl8_UCPagingNexGen_UCPaging']/ul//li[@class='next disabled']"), 10);
                while (!getNextButtonStatus)
                {
                    //Fetch the total number of pages including navigators
                    int getTotalPagesCount = base.GetElementCountByXPath("//div[@id='_ctl8_UCPagingNexGen_UCPaging']/ul/li");
                    for (int i = 3; i <= getTotalPagesCount - 2; i++)
                    {
                        base.WaitForElement(By.XPath(string.Format("//div[@id='_ctl8_UCPagingNexGen_UCPaging']/ul/li[{0}]", i)));
                        //Click on the corresponding page number  
                        IWebElement goToPage = base.GetWebElementPropertiesByXPath(string.Format("//div[@id='_ctl8_UCPagingNexGen_UCPaging']/ul/li[{0}]", i));
                        base.ClickByJavaScriptExecutor(goToPage);
                        {
                            //Fetch the row count of Courses in catalog page 
                            int CourseRowCount = base.GetElementCountByXPath(HEDGlobalHomePageResource.
                        HEDGlobalHomePage_HomePage_GetCourse_Table_XPath_Locator);
                            for (int j = 1; j <= CourseRowCount; j++)
                            {
                                //Get the course name from catalog
                                string courseTable = base.GetElementTextByXPath(string.Format(HEDGlobalHomePageResource.
                                    HEDGlobalHomePage_HomePage_GetCourseText_Table_XPath_Locator, j));
                                if (courseTable.Contains(actualCourseName))
                                {
                                    //Get the master course name to create course
                                    IWebElement selectCourse = base.GetWebElementPropertiesByXPath
                                        (string.Format(HEDGlobalHomePageResource.
                                    HEDGlobalHomePage_HomePage_SelectCourse_Button_XPath_Locator, j));
                                    base.ClickByJavaScriptExecutor(selectCourse);
                                    //Fill the program details
                                    this.FillCourseDetails(courseNameGUID);
                                    return;

                                }
                            }       
                        }
                        if (i == getTotalPagesCount - 2)
                        {
                            //Get the Next button 
                            int getNextButton = getTotalPagesCount - 1;
                            //Click on Next button 
                            IWebElement goToNextPage = base.GetWebElementPropertiesByXPath(
                                string.Format("//div[@id='rptCoursePreview-pagination-selection']/ul//li[{0}]",
                                getNextButton));
                            base.ClickByJavaScriptExecutor(goToNextPage);
                        }                        
                    }
                    getNextButtonStatus = base.IsElementPresent(By.XPath("//div[@id='rptCoursePreview-pagination-selection']/ul//li[@class='next disabled']"), 10);
                }
            }

        /// <summary>
        /// Create Mytest course
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        private void CreateMyTestCourse(string actualCourseName, string courseNameGUID)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "CreateMyTestCourse"
            , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get total pages on catalog
                string pageNumberCount = base.GetElementInnerTextById(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_PageCount_ID_Locator);
                int totalPageCount = Convert.ToInt32(pageNumberCount);
                for (int j = 1; j <= totalPageCount; j++)
                {
                    //Get the course ID and store to inmemory
                    int CourseRowCount = base.GetElementCountByXPath(HEDGlobalHomePageResource.
                        HEDGlobalHomePage_HomePage_GetCourse_Table_XPath_Locator);
                    for (int i = 1; i <= CourseRowCount; i++)
                    {
                        string courseTable = base.GetElementTextByXPath(string.Format(HEDGlobalHomePageResource.
            HEDGlobalHomePage_HomePage_GetCourseText_Table_XPath_Locator, i));
                        if (courseTable.Contains(actualCourseName))
                        {
                            //Get the master course name to create course
                            IWebElement selectTestbank = base.GetWebElementPropertiesByXPath
                                (string.Format(HEDGlobalHomePageResource.
                                HEDGlobalHomePage_HomePage_TestBank_Button_XPath_Locator, i));
                            base.ClickByJavaScriptExecutor(selectTestbank);
                            this.FillCourseDetails(courseNameGUID);
                            return;
                        }
                    }
                    //Click on next link
                    base.ClickLinkById(HEDGlobalHomePageResource.
                        HEDGlobalHomePage_NextLink_ID_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "CreateMyTestCourse"
            , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Program course
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        private void CreateProgramCourse(string actualCourseName,
            Course.CourseTypeEnum courseType, string courseNameGUID)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "CreateProgramCourse"
            , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get total pages on catalog
                string pageNumberCount = base.GetElementInnerTextByXPath("//td[@class='tdPagingPadTop']/span/a[4]");
                int totalPageCount = Convert.ToInt32(pageNumberCount);
                base.ClickLinkByXPath("//td[@class='tdPagingPadTop']/a[2]");
                for (int j = 1; j <= totalPageCount; j++)
                {

                    //Get the course ID and store to inmemory
                    int CourseRowCount = base.GetElementCountByXPath(HEDGlobalHomePageResource.
                        HEDGlobalHomePage_HomePage_GetCourse_Table_XPath_Locator);

                    for (int i = 1; i <= CourseRowCount; i++)
                    {
                        //Check the availability of master course mapped to general product 
                        bool coursetableValue = base.IsElementPresent
                            (By.XPath(string.Format(HEDGlobalHomePageResource.
                        HEDGlobalHomePage_HomePage_GetCourseText_Table_XPath_Locator, i)), 2);
                        if (coursetableValue)
                        {
                            string courseTable = base.GetElementTextByXPath
                                (string.Format(HEDGlobalHomePageResource.
                                     HEDGlobalHomePage_HomePage_GetCourseText_Table_XPath_Locator, i));
                            if (courseTable.Contains(actualCourseName))
                            {
                                break;
                            }
                        }
                        else
                        {
                            string programCourseType = base.GetElementTextByXPath
                                (string.Format(HEDGlobalHomePageResource.
                                HEDGlobalHomePage_HomePage_ProgramRow_XPath_Locator, i));
                            if (programCourseType.Contains(actualCourseName))
                            {
                                //Get the master course name to create course
                                IWebElement selectCourse = base.GetWebElementPropertiesByXPath
                                    (string.Format(HEDGlobalHomePageResource.
                                HEDGlobalHomePage_HomePage_SelectCourse_Button_XPath_Locator, i));
                                base.ClickByJavaScriptExecutor(selectCourse);
                                //Fill the program details
                                string programName = courseNameGUID.ToString();
                                //string ProgamCourseName = programName + "Program";
                                this.FillCourseDetails(programName);
                                return;
                            }
                        }
                    }
                    //Click on next link
                    base.ClickLinkByXPath("//td[@class='tdPagingPadTop']/span/a[2]");
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "CreateProgramCourse"
            , base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// To store the course ID to inmemory
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        private void GetCourseIDFromAPP(string courseNameGUID, Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "GetCourseIDFromAPP"
           , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the course ID and store to inmemory
                int rowCount = base.GetElementCountByXPath(HEDGlobalHomePageResource.
             HEDGlobalHomePage_GetCourseCount_XPath_Locator);
                for (int i = 1; i <= rowCount; i++)
                {
                    string courseTable = base.GetElementTextByXPath(string.Format(HEDGlobalHomePageResource.
                        HEDGlobalHome_Page_Course_Name_XPath_Locator, i));
                    if (courseTable.Contains(courseNameGUID))
                    {
                        //Get the ID of the course
                        string courseId = base.GetElementTextByXPath(string.Format
                        (HEDGlobalHomePageResource.HEDGlobalHome_Page_GetCourseId_XPath_Locator, i));
                        //Remove the ID: prefix
                        string courseIDForEnrollment = courseId.Substring(4);
                        //Store the course ID in memory
                        this.StoreCourseIdGUID(courseIDForEnrollment, courseNameGUID, courseType);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "GetCourseIDFromAPP"
            , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to generate the GUID for course name
        /// </summary>
        /// <param name="courseType">This is course choosen to create.</param>
        private string GenerateCourseGUID(Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "GenerateCourseGUID"
       , base.IsTakeScreenShotDuringEntryExit);
            // Generate GUID for course
            Guid CourseGUID = Guid.NewGuid();
            //Get the system date
            String date = DateTime.Now.ToString("yyyy/MM/dd");
            //Fetch the random value
            string randomValue = CourseGUID.ToString().Split('-')[0];
            //Store empty value to courseNameGUID variable
            string courseNameGUID = string.Empty;
            //Append the data and New Course string
            courseNameGUID = "Auto-" + date + "-" + randomValue + "-New Course";
            //Store the course name to inmemory
            this.StoreCourseGUID(courseNameGUID, courseType);
            Logger.LogMethodExit("HEDGlobalHomePage", "GenerateCourseGUID"
            , base.IsTakeScreenShotDuringEntryExit);
            //Return the course name
            return courseNameGUID;
        }

        /// <summary>
        /// This methord is to generate the GUID for course name
        /// </summary>
        /// <param name="courseType">This is course choosen to create.</param>
        private string GenerateCopiedCourseGUID(Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "GenerateCourseGUID"
       , base.IsTakeScreenShotDuringEntryExit);
            // Generate GUID for course
            Guid CourseGUID = Guid.NewGuid();
            //Get the system date
            String date = DateTime.Now.ToString("yyyy/MM/dd");
            //Fetch the random value
            string randomValue = CourseGUID.ToString().Split('-')[0];
            //Store empty value to courseNameGUID variable
            string courseNameGUID = string.Empty;
            //Append the data and New Course string
            courseNameGUID = "Auto-" + date + "-" + randomValue + "- Course Copy";
            //Store the course name to inmemory
            this.StoreCourseGUID(courseNameGUID, courseType);
            Logger.LogMethodExit("HEDGlobalHomePage", "GenerateCourseGUID"
            , base.IsTakeScreenShotDuringEntryExit);
            //Return the course name
            return courseNameGUID;
        }

        /// <summary>
        /// This methord is to store the GUID in inmemory
        /// </summary>
        /// <param name="courseNameGUID">This is generated course GUID.</param>
        /// <param name="courseType">This is course choosen to create.</param>
        private void StoreCourseGUID(string courseNameGUID, Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "StoreCourseGUID"
       , base.IsTakeScreenShotDuringEntryExit);
            //Create an object and Store the generated course GUID
            Course hedMILProductCourse;
            hedMILProductCourse = new Course
            {
                //Store Course Details
                Name = courseNameGUID.ToString(),
                CourseType = courseType,
                IsCreated = true,
            };
            //Call store method using an object
            hedMILProductCourse.StoreCourseInMemory();
            Logger.LogMethodExit("HEDGlobalHomePage", "StoreCourseGUID"
            , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to store the GUID in inmemory
        /// </summary>
        /// <param name="courseNameGUID">This is generated course GUID.</param>
        /// <param name="courseType">This is course choosen to create.</param>
        private void StoreCourseIdGUID(string courseIDForEnrollment, string courseNameGUID,
            Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "StoreCourseGUID"
       , base.IsTakeScreenShotDuringEntryExit);
            //Create an object and Store the generated course GUID
            Course hedMILProductCourse;
            hedMILProductCourse = new Course
            {
                //Store Course Details
                Name = courseNameGUID.ToString(),
                InstructorCourseId = courseIDForEnrollment.ToString(),
                CourseType = courseType,
                IsCreated = true,
            };
            //Call store method using an object
            hedMILProductCourse.StoreCourseInMemory();
            Logger.LogMethodExit("HEDGlobalHomePage", "StoreCourseGUID"
            , base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// This methord is to store the GUID in inmemory
        /// </summary>
        /// <param name="courseNameGUID">This is generated course GUID.</param>
        /// <param name="courseType">This is course choosen to create.</param>
        private void FillCourseDetails(string courseNameGUID)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "FillCourseDetails"
       , base.IsTakeScreenShotDuringEntryExit);
            //Fill the course name
            base.FillTextBoxById(HEDGlobalHomePageResource.
                HEDGlobalHomePage_HomePage_EnterCourseName_Id_Locator, courseNameGUID);
            //Fill description to course description
            base.FillTextBoxById(HEDGlobalHomePageResource.
                HEDGlobalHomePage_HomePage_EnterCourseDesc_Id_Locator, courseNameGUID);
            //Click on finish button
            base.ClickButtonById(HEDGlobalHomePageResource.
                HEDGlobalHomePage_HomePage_CreateCourse_FinishButton_Id_Locator);
            Logger.LogMethodExit("HEDGlobalHomePage", "FillCourseDetails"
            , base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// This methord is to select the cmenu option
        /// </summary>
        /// <param name="cmenuOption">This is cmenu option to select.</param>
        /// <param name="courseType">This is course choosen to create.</param>
        /// <param name="userType">This is user type.</param>
        public void CmenuOptionForCourse(string cmenuOption, Course.CourseTypeEnum courseType,
            User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "CmenuOptionForCourse"
                   , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get he course type from the inmemory
                this.GetRequiredCourse(courseType);
                //Choose the c-menu option
                switch (cmenuOption)
                {
                    //Select edit course infor cmenu option
                    case "Edit Course Info":
                        base.ClickLinkByPartialLinkText(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_EditCourseInfo_Cmenu_LinkText_Locator);
                        //Focus on the cmenu virtical strip and pull down the menu
                        break;
                    //Select mark for deletion cmenu option
                    case "Mark for Deletion":
                        base.WaitUntilWindowLoads(base.GetPageTitle);
                        base.ClickLinkByPartialLinkText(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_MarkforDeletion_Cmenu_LinkText_Locator);
                        base.WaitUntilWindowLoads(base.GetPageTitle);
                        Thread.Sleep(2000);
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_Deletpopup_Id_Locator));
                        Thread.Sleep(1000);
                        base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_DeletOk_Id_Locator));
                        IWebElement getElement = base.GetWebElementPropertiesById(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_DeletOk_Id_Locator);
                        base.PerformMouseClickAction(getElement);
                        break;
                    //Select copy as instructor course cmenu option
                    case "Copy as Instructor Course":
                        base.ClickLinkByPartialLinkText(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_CopyasInstructorCourse_Cmenu_LinkText_Locator);
                        base.WaitUntilWindowLoads(base.GetPageTitle);
                        base.SwitchToIFrameById(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_CopyasInstructorCourse_Iframe_ID_Locator);
                        //Get course name
                        Course courseName = Course.Get(courseType);
                        string actualCourseName = courseName.Name.ToString();
                        //Generate the unique GUID
                        string courseNameGUID = this.GenerateCopiedCourseGUID(courseType);
                        //Clear the Course name text box
                        base.WaitForElement(By.Id("txtCourseName"));
                        base.ClearTextById("txtCourseName");
                        //Fill the course name textbox
                        base.FillTextBoxById("txtCourseName", courseNameGUID);
                        bool saw = base.IsElementPresent(By.Id("imgbtnSave"), 10);
                        base.WaitForElement(By.Id("imgbtnSave"));
                        IWebElement getButton = base.GetWebElementPropertiesById(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_CopyasInstructorCourseSave_Button_ID_Locator);
                        base.PerformMouseClickAction(getButton);
                        //Fetch course ID from InMemory
                        this.GetCourseID(courseType, courseNameGUID);
                        break;

                    //Select unmark for deletion cmenu option
                    case "Unmark for Deletion":
                        base.ClickLinkByPartialLinkText(HEDGlobalHomePageResource.
                            HEDGlobalHomePage_HomePage_UnmarkforDeletion_Cmenu_LinkText_Locator);
                        break;
                }
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "CmenuOptionForCourse"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the success message from the UI
        /// </summary>
        /// <returns>Return success message.</returns>
        public string GetSuccessMessage(string pageName)
        {
            string message = string.Empty;
            try
            {
                switch (pageName)
                {
                    case "Global Home":
                        base.WaitUntilWindowLoads(pageName);
                        base.WaitForElement(By.Id("_ctl12__ctl1_lblMessage"));
                        message = base.GetInnerTextAttributeValueById("_ctl12__ctl1_lblMessage");
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return message;
        }

        /// <summary>
        /// This methord is to update the name of the course
        /// </summary>
        /// <param name="btnname">This is update button.</param>
        /// <param name="courseType">This is course choosen to create.</param>
        public void UpdateCourseInfo(string btnname, Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "UpdateCourseInfo"
                , base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToIFrameById(HEDGlobalHomePageResource.
            HEDGlobalHomePage_HomePage_CopyasInstructorCourse_Iframe_ID_Locator);
            //Clear the desc text box
            base.ClearTextById("txtCourseDescription");
            //Update the desc 
            string CourseDesc = "This is MyItLab Updated Course description";
            base.FillTextBoxById("txtCourseDescription", CourseDesc);
            //Click on update button
            base.ClickButtonById(HEDGlobalHomePageResource.
            HEDGlobalHomePage_HomePage_CopyasInstructorCourseSave_Button_ID_Locator);
            Logger.LogMethodExit("HEDGlobalHomePage", "UpdateCourseInfo"
            , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to check the updated course name
        /// </summary>
        /// <param name="courseType">This is course choosen to create.</param>
        public void DisplayOfUpdateCourseName(Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "DisplayOfUpdateCourseName"
                , base.IsTakeScreenShotDuringEntryExit);
            Course courseName = Course.Get(courseType);
            string actualCourseName = courseName.Name.ToString();
            string updatedCourseTitle = actualCourseName + "Updated";
            //Look for updated course
            base.WaitUntilWindowLoads(HEDGlobalHomePageResource.HEDGlobalHome_Page_Window_Title_Name);

            int rowCount = base.GetElementCountByXPath(HEDGlobalHomePageResource.
                HEDGlobalHomePage_GetCourseCount_XPath_Locator);

            for (int i = 1; i <= rowCount; i++)
            {
                //Get the course name from the table
                string appCourseName = base.GetElementTextByXPath(string.Format(HEDGlobalHomePageResource.
                HEDGlobalHomePage_GetCourseTitle_CourseListGrid_XPath_Locator, i));
                //Compare the row text and identify the course
                if (appCourseName.Contains(updatedCourseTitle))
                {
                    break;
                }
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "DisplayOfUpdateCourseName"
            , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to get the required course name
        /// </summary>
        /// <param name="courseType">This is course choosen to create.</param>
        private void GetRequiredCourse(Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "GetRequiredCourse"
                , base.IsTakeScreenShotDuringEntryExit);

            //Get course name
            Course coursename = Course.Get(courseType);
            string actualCourseName = coursename.Name.ToString();
            //Get the total number of course form the table
            int getCourseCount = base.GetElementCountByXPath(HEDGlobalHomePageResource.
                HEDGlobalHomePage_GetCourseCount_XPath_Locator);
            //Compare the row text and identify the course
            for (int i = 1; i <= getCourseCount; i++)
            {
                string courseTitle = base.GetElementTextByXPath(string.Format(HEDGlobalHomePageResource.
                    HEDGlobalHomePage_GetCourseTitle_CourseListGrid_XPath_Locator, i));
                if (courseTitle.Contains(actualCourseName))
                {
                    //Focus on the cmenu virtical strip and pull down the menu
                    IWebElement cMenu = base.GetWebElementPropertiesByXPath(string.Format(HEDGlobalHomePageResource.
                        HEDGlobalHomePage_Course_CmenuOption_XPath_Locator, i));
                    base.ClickByJavaScriptExecutor(cMenu);
                    break;
                }
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "GetRequiredCourse"
            , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to check the course status
        /// </summary>
        /// <param name="courseStatus">This is course status.</param>
        /// <param name="courseType">This is course choosen to create.</param>

        public bool CourseStatusOnHomePage(string courseStatus, Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "CourseStatusOnHomePage"
                , base.IsTakeScreenShotDuringEntryExit);
            bool returnCourseStatus = false;
            //Get course name
            Course coursename = Course.Get(courseType);
            //Get the actual course name
            string actualCourseName = coursename.Name.ToString();
            int getCourseCount = base.GetElementCountByXPath
                (HEDGlobalHomePageResource.HEDGlobalHomePage_GetCourseCount_XPath_Locator);
            //Compare the row text and identify the course
            for (int i = 1; i <= getCourseCount; i++)
            {
                //Gett he course details form the course table
                string courseTitle = base.GetElementTextByXPath(string.Format
                    (HEDGlobalHomePageResource.HEDGlobalHomePage_GetCourseTitle_CourseListGrid_XPath_Locator, i));
                //Compare the row text and identify the course
                string statusOfCourse = base.GetElementTextByXPath(string.Format
                    (HEDGlobalHomePageResource.HEDGlobalHomePage_StatusOfCourse_CourseListGrid_XPath_Locator, i));
                //Compare course and status of the course
                if (courseTitle.Contains(actualCourseName) == true && statusOfCourse.Contains(courseStatus) == true)
                {
                    returnCourseStatus = true;
                    break;
                }
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "CourseStatusOnHomePage"
                , base.IsTakeScreenShotDuringEntryExit);
            //Return the the status if course exists
            return returnCourseStatus;

        }

        /// <summary>
        /// This methord is to check the program name created.
        /// </summary>
        /// <param name="programName">This is program name.</param>
        /// <param name="userType">This is user type where course is created.</param>
        public bool ProgramDisplayOnHomePage(Course.CourseTypeEnum programName, User.UserTypeEnum userType)
        {
            bool returnCourseStatus = false;
            //Get course name
            Course coursename = Course.Get(programName);
            //Get the actual course name
            string actualCourseName = coursename.Name.ToString();
            try
            {
                int getCourseCount = base.GetElementCountByXPath
                       (HEDGlobalHomePageResource.HEDGlobalHomePage_GetCourseCount_XPath_Locator);
                //Compare the row text and identify the course
                for (int i = 1; i <= getCourseCount; i++)
                {
                    //Gett he course details form the course table
                    string courseTitle = base.GetElementTextByXPath(string.Format
                        (HEDGlobalHomePageResource.HEDGlobalHomePage_GetCourseTitle_CourseListGrid_XPath_Locator, i));
                    //Compare course and status of the course
                    if (courseTitle.Equals(actualCourseName))
                    {
                        returnCourseStatus = true;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Return the the status if program exists
            return returnCourseStatus;
        }        
    }
}
