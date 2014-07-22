﻿using System;
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

        //Get the WaitTime
        int getWaitTimeinSeconds = Int32.Parse(ConfigurationManager.
                AppSettings[HEDGlobalHomePageResource.
                HEDGlobalHome_Page_ElementFindTimeoutInSeconds]);

        /// <summary>
        /// Get Total Time To Wait For Assigned TO Copy State.
        /// </summary>
        int minutesToWait = Int32.Parse(ConfigurationManager.
            AppSettings["AssignedToCopyInterval"]);

        /// <summary>
        /// Declared variable.
        /// </summary>
        private string getInstructorCourseID = null;

        /// <summary>
        /// Click Search Catalog Link on Global Home Page.
        /// </summary>
        public void ClickSearchCatalogOption()
        {
            // Click Search Catalog Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickSearchCatalogOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectHEDGlobalHomePageWindow();
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
                base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click Create a Course On Global Home Page.
        /// </summary>
        public void ClickCreateaCourse()
        {
            //Click Create a Course Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickCreateaCourse",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Global Home Window
                this.SelectHEDGlobalHomePageWindow();
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
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Approve The Course From InActive State To Active State.
        /// </summary>
        public void ApproveCoursePresentInAssignedToCopyState()
        {
            //Approve The Course From InActive State To Active State
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "ApproveCoursePresentInAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Set Thread To Wait
                Thread.Sleep(Convert.ToInt32(HEDGlobalHomePageResource.
                            HEDGlobalHome_Page_ThreadSleep_Value));
                base.SwitchToDefaultPageContent();
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait For Course Get Out Of Assigned To Copy State.
        /// </summary>
        private void WaitForCourseGetOutOfAssignedToCopyState()
        {
            //Wait Through Stop Watch To Course Get Out of Assigned State
            Logger.LogMethodExit("HEDGlobalHomePage",
               "WaitForCourseGetOutOfAssignedToCopyState",
               base.isTakeScreenShotDuringEntryExit);
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
                if (stopWatch.Elapsed.TotalMinutes < minutesToWait == false) break;
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
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Refresh The Global Home Page.
        /// </summary>
        public void RefreshTheGlobalHomePage()
        {
            //Refresh The Page To Get The Course Displayed
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "RefreshTheGlobalHomePage",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                , base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_AnnouncementsManageAll_Button_Id_Locator));
            //Fill Text Box With Empty String
            base.FillEmptyTextByID(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_AnnouncementsManageAll_Button_Id_Locator);
            IWebElement getManageButton=base.GetWebElementPropertiesById
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
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Closing the Announcement.
        /// </summary>
        private void CloseAnnouncement()
        {
            //Click on the Close button of the Announcement
            Logger.LogMethodEntry("HEDGlobalHomePage", "CloseAnnouncement",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Initialized Course Text
            string getCourseText = string.Empty;
            try
            {
                //Select Window
                this.SelectHEDGlobalHomePageWindow();
                //Set Thread To Wait
                Thread.Sleep(Convert.ToInt32(HEDGlobalHomePageResource
                    .HEDGlobalHome_Page_ThreadSleep_Value));
                //Wait for Element
                base.WaitForElement(By.Id(HEDGlobalHomePageResource
                         .HEDGlobalHome_Page_Course_Table_Id_Locator));
                //Get Course Text
                getCourseText = base.GetElementTextByID(HEDGlobalHomePageResource
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
                base.isTakeScreenShotDuringEntryExit);
            return getCourseText;

        }

        /// <summary>
        /// Store Instructor Course Id in Memory.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        public void StoreInstructorCourseIDInMemory(Course.CourseTypeEnum courseTypeEnum)
        {
            //Get Instructor Course Id and Store In Memory
            Logger.LogMethodEntry("HEDGlobalHomePage", "StoreInstructorCourseIDInMemory"
                , base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (courseTypeEnum)
                {
                    case Course.CourseTypeEnum.MyTestBankCourse:
                        break;
                    default:
                        //Get Instructor Course ID
                        string getInstructorCourseID = this.GetInstructorCourseID(courseTypeEnum);
                        //Store Instructor Course Id In Memory
                        this.StoreInstructorCourseIDInMemory(getInstructorCourseID, courseTypeEnum);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "StoreInstructorCourseIDInMemory"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Instructor Course ID from the Global Home Page.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <returns>Instructor Course ID.</returns>
        private String GetInstructorCourseID(Course.CourseTypeEnum courseTypeEnum)
        {
            //Get Instructor Course ID from Global Home Page
            Logger.LogMethodEntry("HEDGlobalHomePage", "GetInstructorCourseID"
                , base.isTakeScreenShotDuringEntryExit);
            //Initialize Course Table Div Count
            const int getCourseDivCount = 1;
            //Select Window
            this.SelectHEDGlobalHomePageWindow();
            base.WaitForElement(By.XPath(string.Format
                (HEDGlobalHomePageResource
                .HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, getCourseDivCount)));
            //Get Element Property
            IWebElement getCourseDivText = base.GetWebElementPropertiesByXPath(
                string.Format(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, getCourseDivCount));
            //Get Instructor Course Id
            string getInstructorCourseId = GetInstructorCourseIDFromDiv(
                getCourseDivCount, getCourseDivText, courseTypeEnum);
            Logger.LogMethodExit("HEDGlobalHomePage", "GetInstructorCourseID"
                , base.isTakeScreenShotDuringEntryExit);
            return getInstructorCourseId;
        }

        /// <summary>
        /// Get Instructor Course ID From Global Home Page.
        /// </summary>
        /// <param name="courseDivCount">This is course div count.</param>
        /// <param name="courseDivText">This is course div text.</param>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <returns>Instructor Course ID.</returns>
        private string GetInstructorCourseIDFromDiv(int courseDivCount,
            IWebElement courseDivText, Course.CourseTypeEnum courseTypeEnum)
        {
            //Get Instructor Course ID
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "GetInstructorCourseIDFromDiv", base.isTakeScreenShotDuringEntryExit);
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
                 "GetInstructorCourseIDFromDiv", base.isTakeScreenShotDuringEntryExit);
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
                "GetInstructorCourseIdFromFirstDiv", base.isTakeScreenShotDuringEntryExit);
            // Wait for the course name
            base.WaitForElement(By.XPath(string.Format(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, courseDivCount)));
            // // Gets control to the course
            base.FillEmptyTextByXPath(string.Format(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, courseDivCount));
            // Get the Text of Row 
            string getInstructorCourseID = base.GetElementTextByXPath
                (string.Format(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Course_Table_ActiveSpan_XPath_Locator,
                courseDivCount));
            //Get Instructor Course Text Line Number
            int getInstructorCourseTextLineNumber = getInstructorCourseID.IndexOf(' ');
            getInstructorCourseID = getInstructorCourseID.Substring(getInstructorCourseTextLineNumber).Trim();
            Logger.LogMethodExit("HEDGlobalHomePage",
                "GetInstructorCourseIdFromFirstDiv", base.isTakeScreenShotDuringEntryExit);
            return getInstructorCourseID;
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
                , base.isTakeScreenShotDuringEntryExit);
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
                    getInstructorCourseID = getTextFromCourseRow.
                        Substring(getInstructorCourseIdLineNumber).Trim();
                    break;
                }
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "GetInstructorCourseIdFromNonFirstDiv",
                base.isTakeScreenShotDuringEntryExit);
            return getInstructorCourseID;
        }

        /// <summary>
        /// Store Course Instructor ID in Memory.
        /// </summary>
        /// <param name="instructorCourseID">This is Instructor Course ID.</param>
        /// <param name="courseTypeEnum">This is Course Type enum.</param>
        private void StoreInstructorCourseIDInMemory(string instructorCourseID,
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Save Instructor Course ID in Memory
            Logger.LogMethodEntry("HEDGlobalHomePage",
                "StoreInstructorCourseIDInMemory",
                                  base.isTakeScreenShotDuringEntryExit);
            Course hedProductCourse = Course.Get(courseTypeEnum);
            hedProductCourse.InstructorCourseId = instructorCourseID;
            Logger.LogMethodExit("HEDGlobalHomePage",
        "StoreInstructorCourseIDInMemory"
        , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Enroll In a Course Link on Global Home Page.
        /// </summary>
        public void ClickOnEnrollInCourseButton()
        {
            //Click Enroll In a Course Link on Global Home Page
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickOnEnrollInCourseButton",
                                  base.isTakeScreenShotDuringEntryExit);
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
                , base.isTakeScreenShotDuringEntryExit);
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
              , base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get Course From Memory
                Course course = Course.Get(courseTypeEnum);
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.HedCoreAcceptanceInstructor:
                    case User.UserTypeEnum.HedCoreAcceptanceStudent:
                    case User.UserTypeEnum.HedWsInstructor:
                    case User.UserTypeEnum.CsSmsInstructor:
                    case User.UserTypeEnum.HedMilAcceptanceInstructor:
                        switch (courseTypeEnum)
                        {
                            //Course Type Enum
                            case Course.CourseTypeEnum.ProgramCourse:
                            case Course.CourseTypeEnum.MyItLabProgramCourse:
                            case Course.CourseTypeEnum.MySpanishLabMaster:
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
                                //Open the Course
                                this.OpenTheCourse(course.Name);
                                break;
                        }
                        break;
                    case User.UserTypeEnum.HedTeacherAssistant:
                    case User.UserTypeEnum.CsSmsStudent:
                        switch (courseTypeEnum)
                        {
                            case Course.CourseTypeEnum.ProgramCourse:
                            case Course.CourseTypeEnum.MySpanishLabMaster:
                            case Course.CourseTypeEnum.MyITLabOffice2013Program:
                                //Open the Course
                                this.OpenTheCourse(course.SectionName);
                                break;
                            case Course.CourseTypeEnum.MyItLabProgramCourse:
                                //Open the Course
                                this.OpenTheCourse(course.SectionName +
                                    HEDGlobalHomePageResource.HEDGlobalHome_Page_SectionValue);
                                break;
                            case Course.CourseTypeEnum.InstructorCourse:
                            case Course.CourseTypeEnum.MyTestInstructorCourse:
                            case Course.CourseTypeEnum.MyItLabInstructorCourse:
                            case Course.CourseTypeEnum.HedMyItLabPPECourse:
                                //Open the Course
                                this.OpenTheCourse(course.Name);
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
               , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store User Last Login Details In Memory.
        /// </summary>
        private void StoreUserLastLoginDetailsInMemory()
        {
            //Store User Last Login Details In Memory
            Logger.LogMethodEntry("HEDGlobalHomePage", "StoreUserLastLoginDetailsInMemory"
              , base.isTakeScreenShotDuringEntryExit);
            //Get User From Memory
            User user = User.Get(User.UserTypeEnum.CsSmsStudent);
            //Update Last Login Date
            user.LastLogin = DateTime.Now;
            Logger.LogMethodExit("HEDGlobalHomePage", "StoreUserLastLoginDetailsInMemory"
               , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open The Course.
        /// </summary>
        /// <param name="courseName">This is Course Name.</param>
        public void OpenTheCourse(String courseName)
        {
            // Open Course by clicking on course Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "OpenTheCourse"
                , base.isTakeScreenShotDuringEntryExit);
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
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Course Link To Open.
        /// </summary>
        /// <param name="courseName">This is Course Name.</param>
        private void ClickOnCourseLink(String courseName)
        {
            // Search and Click Course Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickOnCourseLink"
                , base.isTakeScreenShotDuringEntryExit);
            //Get Course Row Counter
            const int getCourseRowCounter = 1;
            base.WaitForElement(
                By.XPath(string.Format(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Course_Table_Row_XPath_Locator,
                                       getCourseRowCounter)));
            // Click the course name
            ClickCourseNameOnHomePage(courseName, getCourseRowCounter);
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickOnCourseLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the course on home page.
        /// </summary>
        /// <param name="courseName">This is the course name.</param>
        /// <param name="courseDivCounter">This is the div count.</param>
        private void ClickCourseNameOnHomePage
            (string courseName, int courseDivCounter)
        {
            //Get HTML Element Property
            IWebElement courseTable = base.GetWebElementPropertiesByXPath(
                string.Format(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Course_Table_Row_XPath_Locator, courseDivCounter));
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
                IWebElement getCourseName = base.GetWebElementPropertiesByPartialLinkText
                    (courseName);
                base.ClickByJavaScriptExecutor(getCourseName);
            }
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
                                  base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            return getCourseName;
        }

        /// <summary>
        /// Switching To Announcement Iframe.
        /// </summary>
        private void SwitchToAnnouncementIFrame()
        {
            //Switch To Announcement Iframe
            Logger.LogMethodEntry("HEDGlobalHomePage", "SwitchToAnnouncementIframe",
                      base.isTakeScreenShotDuringEntryExit);
            // Wait for the IFrame
            base.WaitForElement(By.XPath(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_AnnouncementFrame_XPath_Locator));
            //Switch to Iframe     
            base.SwitchToIFrameByWebElement(base.GetWebElementPropertiesByXPath(HEDGlobalHomePageResource
                .HEDGlobalHome_Page_AnnouncementFrame_XPath_Locator));
            Logger.LogMethodExit("HEDGlobalHomePage", "SwitchToAnnouncementIframe",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'My Profile' Link.
        /// </summary>
        public void ClickOnMyProfileLink()
        {
            //Click On 'My Profile' Link
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickOnMyProfileLink",
                      base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Global Home window
                base.SelectWindow(HEDGlobalHomePageResource.HEDGlobalHome_Page_Window_Title_Name);
                base.WaitForElement(By.Id(HEDGlobalHomePageResource.
                    HEDGlobalHome_Page_MyProfile_Id_Locator));
                //Click on the Link
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesById(
                    HEDGlobalHomePageResource.HEDGlobalHome_Page_MyProfile_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickOnMyProfileLink",
                      base.isTakeScreenShotDuringEntryExit);
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
                                  base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isDefaultContentsDisplayed = false;
            try
            {
                //Select HED Global home page window
                this.SelectHEDGlobalHomePageWindow();
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
                , base.isTakeScreenShotDuringEntryExit);
            return isDefaultContentsDisplayed;
        }

        /// <summary>
        /// Select HEDGlobal Home page window.
        /// </summary>
        private void SelectHEDGlobalHomePageWindow()
        {
            //Logger enrty
            Logger.LogMethodEntry("HEDGlobalHomePage", "SelectHEDGlobalHomePageWindow"
                , base.isTakeScreenShotDuringEntryExit);
            //Wait for window
            base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Window_Title_Name);
            //Select Window
            base.SelectWindow(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Window_Title_Name);
            //Logger exit
            Logger.LogMethodExit("HEDGlobalHomePage", "SelectHEDGlobalHomePageWindow"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Feedback and MyProfile Link on Global Home Page.
        /// </summary>
        public Boolean IsFeedbackAndMyProfileLingPresent()
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "IsFeedbackAndMyProfileLingPresent",
                                  base.isTakeScreenShotDuringEntryExit);
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
                , base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            return getLinkProperty;
        }

        /// <summary>
        /// Click The Help Link In Global Homepage. 
        /// </summary>
        public void ClickTheHelpLinkInGlobalHomePage()
        {
            //Click The Help Link In Global Homepage 
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickTheHelpLinkInGlobalHomePage",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Click The Help Link In Global Homepage in TA.
        /// </summary>
        public void ClickTheHelpLinkInGlobalHomePageInTA()
        {
            // Click The Help Link In Global Homepage in TA
            Logger.LogMethodEntry("HEDGlobalHomePage", "ClickTheHelpLinkInGlobalHomePageInTA",
               base.isTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("HEDGlobalHomePage", "ClickTheHelpLinkInGlobalHomePageInTA",
                base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select HED Global home page
                this.SelectHEDGlobalHomePageWindow();
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the status of KeepMeTestCourse CheckBox on Upgrade popup.
        /// </summary>
        /// <returns>Return the status of checkbox.</returns>
        public Boolean IsStatusOfKeepMeTestCourseCheckBoxEnabled()
        {
            //Logger Entry
            Logger.LogMethodEntry("HEDGlobalHomePage", "IsStatusOFKeepMeTestCourseCheckBoxEnabled",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            return isCheckboxEnabled;
        }

        /// <summary>
        /// Select Upgrade Popup Window. 
        /// </summary>
        private void SelectUpgradePopupWindow()
        {
            //Logger Entry
            Logger.LogMethodEntry("HEDGlobalHomePage", "SelectUpgradePopupWindow",
                   base.isTakeScreenShotDuringEntryExit);
            //Wait for Pop up Window
            base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Upgrade_Popup_Window_Name);
            //Switch on Popup window
            base.SelectWindow(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Upgrade_Popup_Window_Name);
            //Logger Exit
            Logger.LogMethodExit("HEDGlobalHomePage", "SelectUpgradePopupWindow",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close upgrade popup window.
        /// </summary>
        public void CloseUpgradePopupWindow()
        {
            //Logger Entry
            Logger.LogMethodEntry("HEDGlobalHomePage", "CloseUpgradePopupWindow",
                   base.isTakeScreenShotDuringEntryExit);
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
                  base.isTakeScreenShotDuringEntryExit);
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
                   base.isTakeScreenShotDuringEntryExit);  
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
                  base.isTakeScreenShotDuringEntryExit);
            return getCourseName;
        }

        /// <summary>
        /// Select Global Homepage.
        /// </summary>
        private void SelectGlobalHomepage()
        {
            // Select Global Homepage.
            Logger.LogMethodEntry("HEDGlobalHomePage", "SelectGlobalHomepage",
                   base.isTakeScreenShotDuringEntryExit);
            //Wait for window
            base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Window_Title_Name);
            //Select Window
            base.SelectWindow(HEDGlobalHomePageResource.
                HEDGlobalHome_Page_Window_Title_Name);
            Logger.LogMethodExit("HEDGlobalHomePage", "SelectGlobalHomepage",
                 base.isTakeScreenShotDuringEntryExit);
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
                   base.isTakeScreenShotDuringEntryExit);
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
                  base.isTakeScreenShotDuringEntryExit);
            return isManageAllButtonDisplayedInAnnouncementChannel;
        }
    }
}
