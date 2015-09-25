using System;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus GBInstructorUX Page Actions
    /// </summary>
    public class GBInstructorUXPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(GBInstructorUXPage));

        /// <summary>
        /// This the enum available for Asset cmenu in gradebook
        /// </summary>
        public enum AssetCmenuOptionEnum
        {
            /// <summary>
            /// Asset cmenu option for Save To Custom View
            /// </summary>
            SavetoCustomView = 1,
            /// <summary>
            /// Asset cmenu option for Remove from Custom View
            /// </summary>
            RemovefromCustomView = 2,
            /// <summary>
            /// Asset cmenu option for Apply Grade Schema
            /// </summary>
            ApplyGradeSchema = 3,
            /// <summary>
            /// Asset cmenu option for View All Submissions
            /// </summary>
            ViewAllSubmissions = 4,
            /// <summary>
            /// Asset cmenu option for Modify Grade Schema
            /// </summary>
            ModifyGradeSchema = 5,
            /// <summary>
            /// Asset cmenu option for Remove Grade Schema
            /// </summary>
            RemoveGradeSchema = 6,
            /// <summary>
            /// Asset cmenu option for Edit Grades
            /// </summary>
            EditGrades = 7,
            /// <summary>
            /// Asset cmenu option for Hide student
            /// </summary>
            HideforStudent = 8,
            /// <summary>
            /// Asset cmenu option for Sychronize with LMS
            /// </summary>
            SynchronizewithLMS = 9,
            /// <summary>
            /// Asset cmenu option for Stop LMS Synchronization
            /// </summary>
            StopLMSSynchronization = 10,
            /// <summary>
            /// Asset cmenu option for Show for student
            /// </summary>
            ShowforStudent = 11,
            /// <summary>
            /// Asset cmenu option for View Submissions
            /// </summary>
            ViewSubmissions = 12
        }

        /// <summary>
        /// This is the enum available for Asset Grade Cell Cmenu
        /// </summary>
        public enum GradeCellCmenuOptionTypeEnum
        {
            /// <summary>
            /// Asset cmenu option for Edit Grade
            /// </summary>
            EditGrade = 1,
            /// <summary>
            /// Asset cmenu option for View Grade Submission
            /// </summary>
            ViewGradeSubmission = 2,
            /// <summary>
            /// Asset cmenu option for View Grade History
            /// </summary>
            ViewGradeHistory = 3
        }

        /// <summary>
        /// This is the type of the TextBox
        /// </summary>
        public enum TextTypeEnum
        {
            FirstText,
            SecondText,
        }

        public enum CustomColumnTypeEnum
        {
            Numeric = 1,
            Calculated = 2,
            SelectionList = 3,
            FreeText = 4,
            ImportGrades = 5,
            TotalColumn = 6
        }

        /// <summary>
        /// To check if grade is present in the grade cell for the activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Grade displayed in Activity grade cell.</returns>
        public String GetGradeDisplayedInTheGradeCell(string activityName)
        {
            //Check If Grade Is Present In The Grade Cell And Return The Grade
            logger.LogMethodEntry("GBInstructorUXPage", "GetGradeDisplayedInTheGradeCell",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Initialized Variable
            string getGradepresent = string.Empty;
            try
            {
                //Select Student Gradebook Frame
                this.SelectStudentGradebookFrame();
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                //Total Number Of Activities In The Folder
                int getColumnCount = base.GetElementCountByXPath(
                    (GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                //Get The Cell Value
                getGradepresent = this.GetTheCellValue(getColumnCount, activityName);
                //Switch To Default Window
                base.SelectWindow(GBFoldersPageResource
                    .GBFolders_Page_Gradebook_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetGradeDisplayedInTheGradeCell",
                                   base.IsTakeScreenShotDuringEntryExit);
            return getGradepresent;
        }

        /// <summary>
        /// Select Student Gradebook Frame.
        /// </summary>
        private void SelectStudentGradebookFrame()
        {
            // Select Student Gradebook Frame
            //Check If Grade Is Present In The Grade Cell And Return The Grade
            logger.LogMethodEntry("GBInstructorUXPage", "SelectStudentGradebookFrame",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Name(GBInstructorUXPageResource.
                    GBInstructorUX_Page_GradesFrame_Iframe_Name_Locator));
            //Switch Into The Student Gradebook Frame
            base.SwitchToIFrame(GBInstructorUXPageResource.
                GBInstructorUX_Page_GradesFrame_Iframe_Name_Locator);
            logger.LogMethodExit("GBInstructorUXPage", "SelectStudentGradebookFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Get The Grade Displayed For The Activity
        /// </summary>
        /// <param name="columnCount">This Is The Number Of Activities
        /// Column Inside The Folder</param>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>This returns the grade in the cell</returns>
        private String GetTheCellValue(int columnCount, string activityName)
        {
            //Get The Grade Displayed For The Activity
            logger.LogMethodEntry("GBInstructorUXPage", "GetTheCellValue",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Get The Activity Title
            string getAssignmentTitle = string.Empty;
            //Setting Column Number
            int setColumnNo;
            for (setColumnNo = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); setColumnNo <= columnCount; setColumnNo++)
            {
                //Check For The Assignment In GradeBook
                getAssignmentTitle = GetAssignmetTitle(getAssignmentTitle, setColumnNo);
                if (getAssignmentTitle.Contains(activityName))
                {
                    break;
                }
            }
            base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_GradeCell_Xpath_Locator, setColumnNo)));
            //Get The Grade In The Cell
            string getGradeFromCell = base.GetTitleAttributeValueByXPath
                ((string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_GradeCell_Xpath_Locator, setColumnNo)));
            logger.LogMethodExit("GBInstructorUXPage", "GetTheCellValue",
                                  base.IsTakeScreenShotDuringEntryExit);
            return getGradeFromCell;
        }

        /// <summary>
        /// Get Assignment Title
        /// </summary>
        /// <param name="assignmentTitle">This Is The Assignment Title</param>
        /// <param name="columnNo">This Is The Column Number Of Required Activity</param>
        /// <returns>Assignment title</returns>
        private String GetAssignmetTitle(
            string assignmentTitle, int columnNo)
        {
            // Get Assignment Title
            logger.LogMethodEntry("GBInstructorUXPage", "GetAssignmetTitle",
                                 base.IsTakeScreenShotDuringEntryExit);
            switch (base.Browser)
            {
                case PegasusBaseTestFixture.InternetExplorer:
                    {
                        //Get assignment title from Internet explorer
                        assignmentTitle = this.GetAssignmentTitleInInternetExplorer(assignmentTitle, columnNo);
                        break;
                    }
                case PegasusBaseTestFixture.FireFox:
                    {
                        //Get assignment title from Firefox
                        assignmentTitle = this.GetAssignmentTitleInFireFox(assignmentTitle, columnNo);
                        break;
                    }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetAssignmetTitle",
                                 base.IsTakeScreenShotDuringEntryExit);
            return assignmentTitle;
        }

        /// <summary>
        /// Get Assignment Title From Internet Explorer
        /// </summary>
        /// <param name="assignmentTitle">This Is The Assignment Title</param>
        /// <param name="columnNo">This Is The Column Number Of Required Activity</param>
        /// <returns>Assignment Title For FireFox</returns>
        private string GetAssignmentTitleInFireFox(
            string assignmentTitle, int columnNo)
        {
            if (assignmentTitle == null) throw new ArgumentNullException("assignmentTitle");
            //Get assignment title from Internet explorer
            logger.LogMethodEntry("GBInstructorUXPage", "AssignmentTitleFF",
                                  base.IsTakeScreenShotDuringEntryExit);
            assignmentTitle = base.GetTitleAttributeValueByXPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_AssignmentTitleFF_Xpath_Locator, columnNo));
            logger.LogMethodExit("GBInstructorUXPage", "AssignmentTitleFF",
                                  base.IsTakeScreenShotDuringEntryExit);
            return assignmentTitle;
        }

        /// <summary>
        /// Get assignment title from Firefox
        /// </summary>
        /// <param name="assignmentTitle">This Is The Assignment Title</param>
        /// <param name="columnNo">This Is The Column Number Of Required Activity</param>
        /// <returns>Assignment Title For Internet Explorer Browser</returns>
        private string GetAssignmentTitleInInternetExplorer(
            string assignmentTitle, int columnNo)
        {
            if (assignmentTitle == null) throw new ArgumentNullException("assignmentTitle");
            //Get assignment title from Firefox
            logger.LogMethodEntry("GBInstructorUXPage", "GetAssignmentTitleInInternetExplorer",
                                  base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_AssignmentTitleIE_Xpath_Locator, columnNo)));
            assignmentTitle = base.GetTitleAttributeValueByXPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_AssignmentTitleIE_Xpath_Locator, columnNo));
            logger.LogMethodExit("GBInstructorUXPage", "GetAssignmentTitleInInternetExplorer",
                                 base.IsTakeScreenShotDuringEntryExit);
            return assignmentTitle;
        }

        /// <summary>
        /// Click On Activity View Grades Button.
        /// </summary>
        public void ClickOnActivityViewGradesButton()
        {
            //Click On Activity View Grades Button
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnActivityViewGradesButton",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectGradebookFrame();
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_WaitWindowTime_Value));
                string activityName = GBInstructorUXPageResource.
                               GBInstructorUX_Page_ActivityName_Value;
                //Get Activity Name
                this.GetActivityName(activityName);
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ClickOnActivityViewGradesButton",
                                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Name.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void GetActivityName(string activityName)
        {
            // Get Activity Name
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityName",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Getting the counts of Activity                    
                int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator);
                for (int activityColumnNo = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value);
                activityColumnNo <= getActivityCount; activityColumnNo++)
                {
                    //Wait for Element
                    base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                        GBInstructorUX_Page_AssignmentTitle_Xpath_Locator, activityColumnNo)));
                    //Getting the Activity name
                    string getActivityName = base.GetTitleAttributeValueByXPath
                        (string.Format(GBInstructorUXPageResource.
                        GBInstructorUX_Page_AssignmentTitle_Xpath_Locator, activityColumnNo));
                    if (getActivityName.Contains(activityName))
                    {
                        //Click The View Grade Button.
                        this.ClickTheViewGradeButton(activityColumnNo);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityName",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click The View Grade Button.
        /// </summary>
        /// <param name="activityColumnNo">This is Column count.</param>
        private void ClickTheViewGradeButton(int activityColumnNo)
        {
            //Click The View Grade Button
            logger.LogMethodEntry("GBInstructorUXPage", "ClickTheViewGradeButton",
                 base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_GB_GradeCell_Xpath_Locator, activityColumnNo)));
            //Get Element Property
            IWebElement getGradeCell = base.GetWebElementPropertiesByXPath(string.Format
             (GBInstructorUXPageResource.GBInstructorUX_Page_GB_GradeCell_Xpath_Locator,
                activityColumnNo));
            //Mouse Hover on Element
            base.PerformMouseHoverByJavaScriptExecutor(getGradeCell);
            //Click on View Grades Button
            this.ClickonViewGradesButton();
            logger.LogMethodExit("GBInstructorUXPage", "ClickTheViewGradeButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on View Grades Button.
        /// </summary>
        private void ClickonViewGradesButton()
        {
            //Click on View Grades Button
            logger.LogMethodEntry("GBInstructorUXPage", "ClickonViewGradesButton",
                 base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBINstructorUX_Page_ViewGradesButton_Id_Locator));
            base.FocusOnElementById(GBInstructorUXPageResource.
                GBINstructorUX_Page_ViewGradesButton_Id_Locator);
            //Get Element Property
            IWebElement getViewGrades = base.GetWebElementPropertiesById
                (GBInstructorUXPageResource.
                GBINstructorUX_Page_ViewGradesButton_Id_Locator);
            //Click on View Grades Button
            base.ClickByJavaScriptExecutor(getViewGrades);
            Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_WaitWindowTime_Value));
            logger.LogMethodExit("GBInstructorUXPage", "ClickonViewGradesButton",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To check if grade is present in the grade cell for the activity
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        /// <returns>Grade displayed in Activity grade cell</returns>
        public String GetGradeDisplayedInTheGradeCellofSubmittedActivity(
            string activityName, User.UserTypeEnum userTypeEnum)
        {
            //Check if Grade is Present in the Grade Cell and Return the Grade
            logger.LogMethodEntry("GBInstructorUXPage",
                "GetGradeDisplayedInTheGradeCellofSubmittedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized Variable
            string getGradeOfSubmittedActivity = string.Empty;
            try
            {
                User user = User.Get(userTypeEnum);
                //Select Window
                this.SelectGradebookFrame();
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                //Total Number Of Activities
                int getActivityCount = base.GetElementCountByXPath(
                    (GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                //Get The Cell Value
                getGradeOfSubmittedActivity = this.GetGradeFromCell(getActivityCount,
                    activityName, user.Name);
                //Switch To Default Window
                base.SelectWindow(GBFoldersPageResource.GBFolders_Page_Gradebook_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage",
                "GetGradeDisplayedInTheGradeCellofSubmittedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            return getGradeOfSubmittedActivity;
        }

        /// <summary>
        /// Get Searched Activity Grade Displayed In The GradeCell.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userTypeEnum">This is User Name.</param>
        /// <returns>Grade.</returns>
        public string GetSearchedActivityGradeDisplayedInTheGradeCell(
            string activityName, User.UserTypeEnum userTypeEnum)
        {
            // Get Searched Activity Grade Displayed In The GradeCell
            logger.LogMethodEntry("GBInstructorUXPage",
                "GetSearchedActivityGradeDisplayedInTheGradeCell",
                     base.IsTakeScreenShotDuringEntryExit);
            //Initialized Variable
            string getGradeOfSubmittedActivity = string.Empty;
            string getAssignmentTitle = string.Empty;
            try
            {
                User user = User.Get(userTypeEnum);
                //Select Window
                this.SelectGradebookFrame();
                //Total Number Of Activities
                int getActivityCount = base.GetElementCountByXPath(
                    (GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                for (int activityColumnNumber = Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Initial_Value); activityColumnNumber <= getActivityCount;
                    activityColumnNumber++)
                {
                    getAssignmentTitle = this.GetSearchedAssetName(activityColumnNumber);
                    if (getAssignmentTitle.Contains(activityName))
                    {
                        //Check For The Assignment In GradeBook                   
                        getGradeOfSubmittedActivity = this.GetGradeBasedOnUserName(
                            user.Name, activityColumnNumber);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage",
                "GetSearchedActivityGradeDisplayedInTheGradeCell",
                  base.IsTakeScreenShotDuringEntryExit);
            return getGradeOfSubmittedActivity;
        }

        /// <summary>
        /// Get Searched Asset Name.
        /// </summary>
        /// <param name="activityColumnNumber">This is Activity column count.</param>
        /// <returns>Activity name.</returns>
        private string GetSearchedAssetName(int activityColumnNumber)
        {
            //Get Searched Asset Name
            logger.LogMethodEntry("GBInstructorUXPage", "GetSearchedAssetName",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_Searched_Activity_Name_Xpath_Locator,
                activityColumnNumber)));
            string getAssignmentTitle = base.GetTitleAttributeValueByXPath(string.Format(
                GBInstructorUXPageResource.
                    GBInstructorUX_Page_Searched_Activity_Name_Xpath_Locator,
                activityColumnNumber));
            logger.LogMethodExit("GBInstructorUXPage", "GetSearchedAssetName",
                  base.IsTakeScreenShotDuringEntryExit);
            return getAssignmentTitle;
        }

        /// <summary>
        /// To Get the Grade Displayed for the Activity
        /// </summary>
        /// <param name="activityCount">This Is the Number Of Activities</param>
        /// <param name="activityName">This is Activity Name</param>
        /// <param name="userName">This is User Name</param>
        /// <returns>This returns the grade in the cell</returns>
        private String GetGradeFromCell(int activityCount, string activityName, string userName)
        {
            //Get the Grade Displayed for the Activity
            logger.LogMethodEntry("GBInstructorUXPage", "GetGradeFromCell",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Get the Activity Title
            string getAssignmentTitle = string.Empty;
            //Setting Column Number
            int activityColumnNumber;
            for (activityColumnNumber = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); activityColumnNumber <= activityCount;
                activityColumnNumber++)
            {
                //Check For The Assignment In GradeBook
                getAssignmentTitle = GetAssignmetTitle(getAssignmentTitle, activityColumnNumber);
                if (getAssignmentTitle.Contains(activityName))
                {
                    break;
                }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetGradeFromCell",
                base.IsTakeScreenShotDuringEntryExit);
            return this.GetGradeBasedOnUserName(userName, activityColumnNumber);
        }

        /// <summary>
        /// Get the Grade Based On User Name.
        /// </summary>
        /// <param name="userName">This is User Name.</param>        
        /// <param name="activityColumnNumber">This is Activity Column Number.</param>
        /// <returns>Grade</returns>
        private string GetGradeBasedOnUserName(string userName, int activityColumnNumber)
        {
            //Get the Grade Based On User
            logger.LogMethodEntry("GBInstructorUXPage", "GetGradeBasedOnUserName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variables
            string getGrade = string.Empty;
            base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_UserCount_Xpath_Locator));
            //Get total user count
            int totalUserCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_UserCount_Xpath_Locator);
            for (int userRowCount = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); userRowCount <= totalUserCount;
                userRowCount++)
            {
                if (base.IsElementPresent(By.XPath(string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Synapse_GradeCell_Xpath_Locator,
                    activityColumnNumber, userRowCount)), Convert.ToInt32(
                    GBInstructorUXPageResource.GBInstructorUX_Page_Custom_WaitTime_Value)))
                {
                    //Get User name
                    string getUserName = base.GetTitleAttributeValueByXPath(string.
                        Format(GBInstructorUXPageResource.
                        GBInstructorUX_Page_User_Title_Xpath_Locator, userRowCount));
                    if (getUserName != null && getUserName.Contains(userName))
                    {
                        //Get The Grade In The Cell
                        getGrade = base.GetTitleAttributeValueByXPath(string.
                            Format(GBInstructorUXPageResource.
                            GBInstructorUX_Page_Synapse_GradeCell_Xpath_Locator,
                            activityColumnNumber, userRowCount));
                        break;
                    }
                }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetGradeBasedOnUserName",
                base.IsTakeScreenShotDuringEntryExit);
            return getGrade;
        }

        /// <summary>
        /// Manually Grade the Activity
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        public void OpenActivityForGradingInHed(
            string activityName)
        {
            //Manually Grade the Activity
            logger.LogMethodEntry("GBInstructorUXPage", "OpenActivityForGradingInHED",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Get the Activity Title
            string getAssignmentTitle = string.Empty;
            try
            {
                //Select the Frame
                this.SelectGradebookFrame();
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                //Total Number Of Activities
                int getActivityCount = base.GetElementCountByXPath(
                    (GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                //Setting Column Number
                int activityColumnNo;
                for (activityColumnNo = Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Initial_Value); activityColumnNo <= getActivityCount; activityColumnNo++)
                {
                    //Check For The Assignment In GradeBook
                    getAssignmentTitle = GetAssignmetTitle(getAssignmentTitle, activityColumnNo);
                    if (getAssignmentTitle.Contains(activityName))
                    {
                        break;
                    }
                }
                //Click on Activity Cmenu
                this.ClickOnActivityCmenu(activityColumnNo);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "OpenActivityForGradingInHED",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Activity Cmenu Option
        /// </summary>
        /// <param name="activityColumnNo">This is Activity Column Number</param>
        private void ClickOnActivityCmenu(
            int activityColumnNo)
        {
            //Click On Activity Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnActivityCmenu",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_CmenuOption_Xpath_Locator, activityColumnNo)));
            IWebElement getCmenuProperty = base.GetWebElementPropertiesByXPath
                (string.Format(GBInstructorUXPageResource.
                  GBInstructorUX_Page_CmenuOption_Xpath_Locator, activityColumnNo));
            base.FocusOnElementByXPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_CmenuOption_Xpath_Locator, activityColumnNo));
            //Click on Activity Cmenu Button
            base.ClickByJavaScriptExecutor(getCmenuProperty);
            base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_EditGrades_Xpath_Locator));
            IWebElement getEditGradeProperty = base.GetWebElementPropertiesByXPath(
                GBInstructorUXPageResource.GBInstructorUX_Page_EditGrades_Xpath_Locator);
            //Click On Edit Grades Option
            base.ClickByJavaScriptExecutor(getEditGradeProperty);
            Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                   GBInstructorUX_Page_WaitWindowTime_Value));
            logger.LogMethodExit("GBInstructorUXPage", "ClickOnActivityCmenu",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Frame.
        /// </summary>
        public void SelectGradebookFrame()
        {
            //Select the Frame
            logger.LogMethodEntry("GBInstructorUXPage", "SelectGradebookFrame",
                                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_Title);
                base.SelectWindow(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_Title);
                //Wait for Element         
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Synapse_GradesFrame_Iframe_Name_Locator));
                //Switch to FrameIframe1
                base.SwitchToIFrame(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Synapse_GradesFrame_Iframe_Name_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectGradebookFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select the Left Frame.
        /// </summary>
        public void SelectGradebookLeftFrame()
        {
            //Select the Frame
            logger.LogMethodEntry("GBInstructorUXPage", "SelectGradebookFrame",
                                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_Title);
                base.SelectWindow(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_Title);
                //Wait for Element         
                base.WaitForElement(By.Id("Iframe1"));
                //Switch to FrameIframe1
                base.SwitchToIFrame("Iframe1");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectGradebookFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The First Column Cmenu Icon
        /// </summary>
        public void ClickOnTheFirstColumnCmenuIcon()
        {
            //Click On The Course Column Cmenu Icon
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnTheFirstColumnCmenuIcon",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Window
                base.WaitUntilWindowLoads(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_Title);
                //Select the Frame
                this.SelectGradebookFrame();
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_FirstColumn_Cmenu_Icon_Xpath_Locator));
                //Click on the Context Menu Icon For First Column
                base.ClickImageByXPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_FirstColumn_Cmenu_Icon_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ClickOnTheFirstColumnCmenuIcon",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The First Column Cmenu Icon for HED Core
        /// </summary>
        public void ClickOnTheFirstColumnCmenuIconHedCore()
        {
            //Click On The Course Column Cmenu Icon
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnTheFirstColumnCmenuIconHEDCore",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Window
                base.WaitUntilWindowLoads(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_Title);
                //Select the Frame
                this.SelectGradebookFrame();
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_FirstColumn_Cmenu_Icon_Xpath_Locator));
                IWebElement getCmenuIconProperty = base.GetWebElementPropertiesByXPath(
                    GBInstructorUXPageResource.
                    GBInstructorUX_Page_FirstColumn_Cmenu_Icon_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getCmenuIconProperty);
                bool bhj = base.IsElementPresent(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_FirstColumn_Cmenu_Icon_Xpath_Locator), 10);
                //Click on the Context Menu Icon For First Column
                IWebElement getStudentName = base.GetWebElementPropertiesByXPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_FirstColumn_Cmenu_Icon_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getStudentName);
                //base.ClickImageByXPath(GBInstructorUXPageResource.
                //  GBInstructorUX_Page_FirstColumn_Cmenu_Icon_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ClickOnTheFirstColumnCmenuIconHEDCore",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Get Context Menu Option Displayed.
        /// </summary>
        /// <param name="contextMenuOption">This is The Context Menu Option.</param>
        /// <returns>Context Menu Option Displayed.</returns>
        public String GetContextMenuOptionDisplayed(
            string contextMenuOption)
        {
            //Get Context Menu Option Displayed
            logger.LogMethodEntry("GBInstructorUXPage", "GetContextMenuOptionDisplayed",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getContextMenuoptionName = string.Empty;
            try
            {
                //Select the Frame
                this.SelectGradebookFrame();
                //Wait for the Context Menu Options
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Table_Cmenu_Options_Id_Locator));
                //Get the Context Menu Options
                string getContextMenuOptions = base.GetElementTextById(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Table_Cmenu_Options_Id_Locator);
                if (getContextMenuOptions.Contains(contextMenuOption))
                {
                    getContextMenuoptionName = contextMenuOption;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetContextMenuOptionDisplayed",
                base.IsTakeScreenShotDuringEntryExit);
            return getContextMenuoptionName;
        }

        /// <summary>
        /// Download the Grade book into file of given type
        /// </summary>
        public void DownloadGradeBook()
        {
            //Download the Grade book into file of given type
            logger.LogMethodEntry("GBInstructorUXPage", "DownloadGradeBook",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to frame
                base.SelectWindow(GBInstructorUXPageResource.GBInstructorUX_Page_Window_Title);
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                        GBInstructorUX_Page_Bottom_Table));
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_imgDownLoad));
                //To Get Foucs for the Download Button
                base.FocusOnElementById(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_imgDownLoad);
                IWebElement downLoadButton = base.GetWebElementPropertiesById(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_imgDownLoad);
                //Click On Download Button
                base.ClickByJavaScriptExecutor(downLoadButton);
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_SleepTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "DownloadGradeBook",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To download the grade book and save to an excel file
        /// </summary>
        public void SaveDownloadedGradeBook()
        {
            //To download the grade book and save to an excel file
            logger.LogMethodEntry("GBInstructorUXPage", "SaveDownloadedGradeBook",
                                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_SleepTime_Value));
                //Get Excelsheet File Path 
                string getExeFilePath = (AutomationConfigurationManager.TestDataPath +
                   GBInstructorUXPageResource.GBInstructorUX_Page_AutoIT_ExeFilepath).
                   Replace("file:\\", "");
                //Path of the Excel file need to saved
                string getExcelFilePathSaved = (AutomationConfigurationManager.TestDataPath +
                    GBInstructorUXPageResource.GBInstructorUX_Page_AutoIT_ExeFilepath).
                    Replace("file:\\", "");
                string[] pathName = getExcelFilePathSaved.Split(Convert.ToChar
                    (GBInstructorUXPageResource.GBInstructorUX_Page_ExcelSheet_Data_colan));
                //Array of string
                string getExcelFileDriveSaved = pathName[0];
                getExcelFileDriveSaved = getExcelFileDriveSaved + GBInstructorUXPageResource.
                    GBInstructorUX_Page_DownLoad_DownloadedFilepath_Locator;
                //Run AutoIT.exe file               
                Process.Start(getExeFilePath, getExcelFileDriveSaved);
                //Added Thread sleep to Set a Time Interval for Auto IT To close
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.GBInstructorUX_Page_ExcelProcessSleepTime_Value));
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SaveDownloadedGradeBook", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student ID option from the drop down in the grade book
        /// </summary>
        public void SelectStudentId()
        {
            //Select Student ID option from the drop down in the grade book
            logger.LogMethodEntry("GBInstructorUXPage", "SelectStudentId",
                                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Gradebook Frame
                this.SelectGradebookFrame();
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Drop_Down_GB));
                //Get web element property
                IWebElement openDropDown = base.GetWebElementPropertiesById
                    (GBInstructorUXPageResource.GBInstructorUX_Page_Drop_Down_GB);
                //Click On Student ID/NAME drop down
                base.ClickByJavaScriptExecutor(openDropDown);
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_SleepTime_Value));
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Drop_Down_Select_GB));
                IWebElement selectOption = base.GetWebElementPropertiesById
                    (GBInstructorUXPageResource.GBInstructorUX_Page_Drop_Down_Text_ID);
                //Select the student id option by clicking it
                base.ClickByJavaScriptExecutor(selectOption);
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_SleepTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectStudentId", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student Name option from the drop down in the grade book
        /// </summary>
        public void SelectStudentName()
        {
            //Select Student Name option from the drop down in the grade book
            logger.LogMethodEntry("GBInstructorUXPage", "SelectStudentName",
                                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Gradebook Frame
                this.SelectGradebookFrame();
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Drop_Down_GB));
                IWebElement openDropDown = base.GetWebElementPropertiesById
                    (GBInstructorUXPageResource.GBInstructorUX_Page_Drop_Down_GB);
                //Click On Student ID/NAME drop down
                base.ClickByJavaScriptExecutor(openDropDown);
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_SleepTime_Value));
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Drop_Down_Select_GB));
                IWebElement selectOption = base.GetWebElementPropertiesById
                    (GBInstructorUXPageResource.GBInstructorUX_Page_Drop_Down_Text_Name);
                //select the student name option by clicking it
                base.ClickByJavaScriptExecutor(selectOption);
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_SleepTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectStudentName", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student Id and Name option from the drop down in the grade book
        /// </summary>
        public void SelectStudentIdAndName()
        {
            //Select Student Id and Name option from the drop down in the grade book
            logger.LogMethodEntry("GBInstructorUXPage", "SelectStudentIdAndName",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Gradebook Frame
                this.SelectGradebookFrame();
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Drop_Down_GB));
                IWebElement openDropDown = base.GetWebElementPropertiesById
                    (GBInstructorUXPageResource.GBInstructorUX_Page_Drop_Down_GB);
                //Click On Student ID/NAME drop down
                base.ClickByJavaScriptExecutor(openDropDown);
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_SleepTime_Value));
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Drop_Down_Select_GB));
                IWebElement selectOption = base.GetWebElementPropertiesById
                    (GBInstructorUXPageResource.GBInstructorUX_Page_Drop_Down_Text_Name_Id);
                //select the student name and id option by clicking it
                base.ClickByJavaScriptExecutor(selectOption);
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_SleepTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectStudentIdAndName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check the absence of EmailAddress Column in the excel file
        /// </summary>
        /// <returns>Boolean status of the EmailAddress absence</returns>
        public Boolean EmailAddressColumnAbsent()
        {
            //Check the absence of EmailAddress Column in the excel file
            logger.LogMethodEntry("GBInstructorUXPage", "EmailAddressColumnAbsent",
                base.IsTakeScreenShotDuringEntryExit);
            //Variable Initialization
            bool isAbsent = false;
            try
            {
                //Path of the Excel file need to saved
                string getExcelFilePathSaved = (Path.GetDirectoryName
                    (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) +
                    GBInstructorUXPageResource.GBInstructorUX_Page_AutoIT_ExeFilepath).
                    Replace("file:\\", "");
                //Array of string
                string[] PathName = getExcelFilePathSaved.Split(Convert.ToChar
                       (GBInstructorUXPageResource.GBInstructorUX_Page_ExcelSheet_Data_colan));
                //Get Excelsheet File Path 
                string getExcelFileDriveSaved = PathName[0];
                getExcelFileDriveSaved = getExcelFileDriveSaved + GBInstructorUXPageResource.
                    GBInstructorUX_Page_DownLoad_DownloadedFilepath_Locator;
                //fetch the csv string in the excel sheet to a variable
                string excelColumnListString = this.ReadDownloadedGbFileData(getExcelFileDriveSaved,
                       Convert.ToInt32(GBInstructorUXPageResource.GBInstructorUX_Page_ExcelSheet_PageNum),
                       Convert.ToInt32(GBInstructorUXPageResource.GBInstructorUX_Page_ExcelSheet_RowNum),
                       Convert.ToInt32(GBInstructorUXPageResource.GBInstructorUX_Page_ExcelSheet_ColNum));
                isAbsent = this.CheckString(excelColumnListString);
                //log a message after checking for the column is complete
                logger.LogMessage("GBInstructorUXPage", "EmailAddressColumnAbsent",
                    "check for EmailAddress column absence complete", true);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "EmailAddressColumnAbsent",
            base.IsTakeScreenShotDuringEntryExit);
            if (!isAbsent)
                return true;
            else
                return false;
        }

        /// <summary>
        /// To read the downloaded GB excel file data 
        /// </summary>
        /// <param name="filePath">Excel file path</param>
        /// <param name="sheetNumber">Excel sheet number</param>
        /// <param name="rowNumber">Row number in the excel sheet</param>
        /// <param name="colNumber">Column number in the excel sheet</param>
        /// <returns>Data string in CSV format</returns>
        public string ReadDownloadedGbFileData(string filePath,
            int sheetNumber, int rowNumber, int colNumber)
        {

            //Read GB File Data
            logger.LogMethodEntry("GBInstructorUXPage", "ReadDownloadedGBFileData", base.IsTakeScreenShotDuringEntryExit);
            string data = string.Empty;

            try
            {
                Excel.Application excelApplication;
                Excel.Workbook excelWorkBook;
                Excel.Worksheet excelWorkSheet;
                Excel.Range range;
                object missingValue = System.Reflection.Missing.Value;
                //Creating excel application object
                excelApplication = new Excel.Application();
                //Read workbook
                excelWorkBook = excelApplication.Workbooks.Open
                    (filePath, 0, false, 5, string.Empty, string.Empty, true,
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
                    GBInstructorUXPageResource.GBInstructorUX_Page_ExcelSheet_Tab_Value,
                    false, false, 0, true, 1, 0);
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(sheetNumber);
                range = excelWorkSheet.UsedRange;
                try
                {
                    //Get the Excel data
                    data = (string)(excelWorkSheet.Cells[rowNumber, colNumber] as Excel.Range).Value2;
                    //Kill the process
                    KillProcess(GBInstructorUXPageResource.GBInstructorUX_Page_ExcelSheet_Name);
                    // return data;
                }
                catch (Exception)
                {
                    //Get the Excel Data
                    data = (string)(excelWorkSheet.Cells[rowNumber, colNumber] as Excel.Range).Value2;
                    //Kill the process
                    KillProcess(GBInstructorUXPageResource.GBInstructorUX_Page_ExcelSheet_Name);
                    //return data.ToString();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ReadDownloadedGBFileData", base.IsTakeScreenShotDuringEntryExit);
            return data.ToString();

        }

        /// <summary>
        /// Kill Excel Process
        /// </summary>
        /// <param name="pathName">path name of the process</param>
        public void KillProcess(string pathName)
        {
            //Kill Excel Process
            logger.LogMethodEntry("GBInstructorUXPage", "KillProcess", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.StartsWith(pathName))
                    {
                        clsProcess.Kill();
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "KillProcess",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To get the word in the array at given index
        /// </summary>
        /// <param name="csv">The csv string</param>
        /// <param name="index">index of the word required</param>
        /// <returns>The text of the word required</returns>
        public string GetWordFromIndex(string csv, int index)
        {
            logger.LogMethodEntry("GBInstructorUXPage", "GetWordFromIndex", base.IsTakeScreenShotDuringEntryExit);
            //split the csv string by the occurence of comma and fill the array
            string[] words = csv.Split(',');
            //log a message after individual data words retrieval is complete
            logger.LogMessage("GBInstructorUXPage", "GetWordFromIndex", "Data retrieved to array from CSV", true);
            logger.LogMethodExit("GBInstructorUXPage", "GetWordFromIndex",
            base.IsTakeScreenShotDuringEntryExit);
            return words[index];
        }

        /// <summary>
        /// To check the presence of EmailAddress column in the csv string of column headings
        /// </summary>
        /// <param name="csv">The csv string</param>
        /// <returns>Boolean status of the occurance of the word required</returns>
        public Boolean CheckString(string csv)
        {
            logger.LogMethodEntry("GBInstructorUXPage", "CheckString", base.IsTakeScreenShotDuringEntryExit);
            //checking for the occurence of the word EmailAddress in the csv string
            Boolean isContains = csv.Contains(GBInstructorUXPageResource.GBInstructorUX_Page_Email_Column_Name);
            logger.LogMethodExit("GBInstructorUXPage", "CheckString",
            base.IsTakeScreenShotDuringEntryExit);
            return isContains;
        }

        /// <summary>
        /// Check the presence of EmailAddress Column at a given position
        /// </summary>
        /// <param name="index">position where the EmailAddress Column is present</param>
        /// <returns>Boolean value which represents the presence of the EmailAddress column</returns>
        public Boolean EmailAddressColumnPresent(int index)
        {
            //Check the presence of EmailAddress Column at a given position
            logger.LogMethodEntry("GBInstructorUXPage", "EmailAddressColumnPresent",
                base.IsTakeScreenShotDuringEntryExit);
            //Variable Initialization
            bool valueDataMatch = false;
            try
            {
                //Path of the Excel file need to saved
                string getExcelFilePathSaved = (Path.GetDirectoryName
                    (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) +
                    GBInstructorUXPageResource.GBInstructorUX_Page_AutoIT_ExeFilepath).
                    Replace("file:\\", "");
                //Array of string
                string[] pathName = getExcelFilePathSaved.Split(Convert.ToChar
                       (GBInstructorUXPageResource.GBInstructorUX_Page_ExcelSheet_Data_colan));
                //Get Excelsheet File Path 
                string getExcelFileDriveSaved = pathName[0];
                getExcelFileDriveSaved = getExcelFileDriveSaved + GBInstructorUXPageResource.
                    GBInstructorUX_Page_DownLoad_DownloadedFilepath_Locator;
                //fetch the csv string in the excel sheet to a variable
                string excelColumnListString = this.ReadDownloadedGbFileData(getExcelFileDriveSaved,
                       Convert.ToInt32(GBInstructorUXPageResource.GBInstructorUX_Page_ExcelSheet_PageNum),
                       Convert.ToInt32(GBInstructorUXPageResource.GBInstructorUX_Page_ExcelSheet_RowNum),
                       Convert.ToInt32(GBInstructorUXPageResource.GBInstructorUX_Page_ExcelSheet_ColNum));
                //fetch the actual word that represents the EmailAddress column name from the CSV string
                string excelColumnName = this.GetWordFromIndex(excelColumnListString, index);
                if (excelColumnName == GBInstructorUXPageResource.GBInstructorUX_Page_Email_Column_Name)
                    valueDataMatch = true;
                else
                    valueDataMatch = false;

                //Added code to Kill the Process of Excel and refreshed  the Current page
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_WaitWindowTime_Value));
                new RptMainUXPage().KillExcelProcess(GBInstructorUXPageResource.GBInstructorUX_Page_ProcessName);
                base.RefreshTheCurrentPage();
                //log a message after data check in the excel file is complete
                logger.LogMessage("GBInstructorUXPage", "EmailAddressColumnPresent",
                    "check for EmailAddress column presence complete", true);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "EmailAddressColumnPresent",
            base.IsTakeScreenShotDuringEntryExit);
            return valueDataMatch;
        }

        /// <summary>
        /// Select Import Grades option in the Grade book
        /// </summary>
        public void SelectImportGrades()
        {
            //Select Import Grades option in the Grade book
            logger.LogMethodEntry("GBInstructorUXPage", "SelectImportGrades",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Gradebook Frame
                this.SelectGradebookFrame();
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Create_Column_DropDown));

                //click on Create Column dropdown
                IWebElement selectCreateColumnOption = base.GetWebElementPropertiesById
                    (GBInstructorUXPageResource.GBInstructorUX_Page_Create_Column_DropDown);
                base.ClickByJavaScriptExecutor(selectCreateColumnOption);

                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_ImportGrade));

                //click on Import Grade
                IWebElement importGrade = base.GetWebElementPropertiesById
                    (GBInstructorUXPageResource.GBInstructorUX_Page_Window_ImportGrade);
                base.ClickByJavaScriptExecutor(importGrade);

                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_SleepTime_Value));
                base.WaitUntilWindowLoads(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_Window_Title);
                base.SelectWindow(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_Window_Title);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectImportGrades",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To select and upload the import grades file 
        /// </summary>
        public void SelectFileToUpload()
        {
            // To select and upload the import grades file 
            logger.LogMethodEntry("GBInstructorUXPage", "SelectFileToUpload",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //selecting the pop up window
                base.SelectWindow(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_Window_Title);
                //Get the Bulk User File Path
                string getImportGradesFilePath = (AutomationConfigurationManager.TestDataPath +
                   GBInstructorUXPageResource.GBInstructorUX_Page_ImportGrades_File_Path).
                    Replace("file:\\", "");
                //Upload the xls File by the browse button input id 
                base.UploadFile(getImportGradesFilePath, By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_Browse_Input_Id));
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_WaitWindowTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectFileToUpload",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To fill in the Column Name in the import grades pop up
        /// </summary>
        /// <param name="columName">Name of the new column</param>
        public void FillColumnName(string columName)
        {
            logger.LogMethodEntry("GBInstructorUXPage", "FillColumnName",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //selecting the pop up window
                base.SelectWindow(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_Window_Title);
                //Fill in the Column Name text box 
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_Column_Name_Id));
                base.FillTextBoxById(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_Column_Name_Id, columName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "FillColumnName",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To fill in the Column Number in the import grades pop up
        /// </summary>
        /// <param name="columNumber">index of the new column</param>       
        public void FillColumnNumber(string columNumber)
        {
            //To fill in the Column Number in the import grades pop up
            logger.LogMethodEntry("GBInstructorUXPage", "FillColumnNumber",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //selecting the pop up window
                base.SelectWindow(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_Window_Title);
                //Fill in the Column Number text box 
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_Column_Number_Id));
                base.FillTextBoxById(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_Column_Number_Id, columNumber);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "FillColumnNumber",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To click on OK button in the import grades pop up
        /// </summary>
        public void ClickOKButton()
        {
            // To click on OK button in the import grades pop up
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOKButton",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //selecting the pop up window
                base.SelectWindow(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_Window_Title);
                //Fill in the Column Number text box 
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_OK_Button_Id));
                base.ClickButtonById(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Pop_Up_OK_Button_Id);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ClickOKButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on create column drop down.
        /// </summary>
        public void ClickCreateColumnDropDown()
        {
            //Click on create column drop down
            logger.LogMethodEntry("GBInstructorUXPage", "ClickCreateColumnDropDown",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Gradebook Frame
                this.SelectGradebookFrame();
                //Wait for the element
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_CreateColumnDropDown_ID_Locator));
                IWebElement getColumnDropDown = base.GetWebElementPropertiesById
                    (GBInstructorUXPageResource.
                    GBInstructorUX_Page_CreateColumnDropDown_ID_Locator);
                //click on drop down
                base.ClickByJavaScriptExecutor(getColumnDropDown);
                //Click the 'Total Column'
                base.ClickLinkById(GBInstructorUXPageResource.
                    GBInstructorUX_Page_TotalColumnDropDown_ID_Locator);
                //Select Total Column Window
                this.SelectTotalColumnWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ClickCreateColumnDropDown",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Total Column Window
        /// </summary>
        private void SelectTotalColumnWindow()
        {
            //Select Total Column Window
            logger.LogMethodEntry("GBInstructorUXPage", "SelectTotalColumnWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //select the pop up window
            base.WaitUntilWindowLoads(GBInstructorUXPageResource.
                GBInstructorUX_Page_CreatTotlColum_Window_Name);
            base.SelectWindow(GBInstructorUXPageResource.
                GBInstructorUX_Page_CreatTotlColum_Window_Name);
            logger.LogMethodExit("GBInstructorUXPage", "SelectTotalColumnWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select activities from Left Iframe.  
        /// </summary>
        /// <param name="activityName">This is activity name</param>
        public void SelectActivityFromLeftFrame(string activityName)
        {
            //Select activities from Left Iframe 
            logger.LogMethodEntry("GBInstructorUXPage", "SelectActivityFromLeftFrame",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the total activity count
                int getActivityCount = this.GetActivityCount();
                //Write a for loop for selecting the checkboxes
                for (int initialCount = Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Initial_Value); initialCount <= getActivityCount;
                    initialCount++)
                {
                    if (base.IsElementPresent(By.XPath(string.Format(GBInstructorUXPageResource.
                         GBInstructorUX_Page_ActivityNameText_Xpath_Locator, initialCount)),
                         Convert.ToInt32(GBInstructorUXPageResource.
                         GBInstructorUX_Page_WaitTime_Value)))
                    {
                        string getActivityName = base.GetTitleAttributeValueByXPath(string.
                            Format(GBInstructorUXPageResource.
                             GBInstructorUX_Page_ActivityNameText_Xpath_Locator, initialCount));
                        //check for activity
                        if (getActivityName.Contains(activityName))
                        {
                            this.SelectTheActivityCheckBox(initialCount);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectActivityFromLeftFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Count.
        /// </summary>
        /// <returns>The Total Activity count</returns>
        private int GetActivityCount()
        {
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityCount",
                base.IsTakeScreenShotDuringEntryExit);
            //select window
            base.SelectWindow(GBInstructorUXPageResource.
                GBInstructorUX_Page_CreatTotlColum_Window_Name);
            // switch to iframe
            base.SwitchToIFrame(GBInstructorUXPageResource.
                 GBInstructorUX_Page_MyCourse_Frame_ID_Locator);
            //Wait for element
            base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                   GBInstructorUX_Page_ActivityCount_Xpath_Locator));
            int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_ActivityCount_Xpath_Locator);
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityCount",
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityCount;
        }

        /// <summary>
        /// Select The Activity CheckBox
        /// </summary>
        /// <param name="rowCount">This is the row count of the Activity</param>
        private void SelectTheActivityCheckBox(int rowCount)
        {
            //Select activities from Left Iframe 
            logger.LogMethodEntry("GBInstructorUXPage", "SelectTheActivityCheckBox",
                base.IsTakeScreenShotDuringEntryExit);
            //Select The Activity CheckBox
            base.FocusOnElementByXPath(string.Format(GBInstructorUXPageResource.
               GBInstructorUX_Page_ActivityNameText_Xpath_Locator, rowCount));
            //select checkbox box of activity
            base.SelectCheckBoxByXPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_Activity_Checkbox_XPath_Locator, rowCount));
            Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                GBInstrucotUX_Page_ActivitySelect_Thread_Time_Value));
            logger.LogMethodExit("GBInstructorUXPage", "SelectTheActivityCheckBox",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add selected Activities to right Iframe.
        /// </summary>
        public void AddActivitiesinRightFrame()
        {
            //Add selected Activities to right Iframe
            logger.LogMethodEntry("GBInstructorUXPage", "AddActivitiesinRightFrame",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Custom Column Window  
                String pagetitle = base.GetPageTitle;
                this.SelectTheWindowName(pagetitle);
                // wait for element     
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Add_Button_ID_Locator));
                // Click on add button in the popup window to add activities to right frame  
                IWebElement getButtonProperty = base.GetWebElementPropertiesById(
                    GBInstructorUXPageResource.GBInstructorUX_Page_Add_Button_ID_Locator);
                base.ClickByJavaScriptExecutor(getButtonProperty);
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstrucotUX_Page_ActivitySelect_Thread_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "AddActivitiesinRightFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Value In TotalWeight Textbox.
        /// </summary>
        /// <param name="textOption">This text box</param>
        /// <param name="textValue">This text box</param>
        public void EnterTheValueInTotalWeightTextbox(TextTypeEnum textOption,
            string textValue)
        {
            //Enter The Value In TotalWeight Textbox.
            logger.LogMethodEntry("GBInstructorUXPage", "EnterTheValueInTotalWeightTextbox",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //select pop up window
                this.SelectTotalColumnWindow();
                //Select Total Column Framework
                this.SelectTotalColumnFramework();
                //Select the text boxes and enter the values
                this.SelectTheTextboxAndEnterTvalue(textOption, textValue);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "EnterTheValueInTotalWeightTextbox",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Total Column Framework.
        /// </summary>
        private void SelectTotalColumnFramework()
        {
            //Select Total Column Framework
            logger.LogMethodEntry("GBInstructorUXPage", "SelectTotalColumnFramework",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_IFrame_selectedList_ID_Locator),
               Convert.ToInt32(GBInstructorUXPageResource.GBInstructorUX_Page_WaitTime_Value));
            base.SwitchToIFrame(GBInstructorUXPageResource.
                GBInstructorUX_Page_IFrame_selectedList_ID_Locator);
            logger.LogMethodExit("GBInstructorUXPage", "SelectTotalColumnFramework",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Text Type And Enter The TextBox Data.
        /// </summary>
        /// <param name="textTypeEnum">This is TextTypeEnum </param>
        /// <param name="textValue">This is Text Value</param>
        private void SelectTheTextboxAndEnterTvalue(TextTypeEnum textTypeEnum,
            string textValue)
        {
            //Select The Text Type And Enter The TextBox Data
            logger.LogMethodEntry("GBInstructorPage", "SelectTheTextboxAndEnterTvalue",
                base.IsTakeScreenShotDuringEntryExit);
            switch (textTypeEnum)
            {
                case TextTypeEnum.FirstText:
                    base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                        GBInstructorUX_Page_First_Text_Weight_Xpath_Locator));
                    // enter value in first text box
                    IWebElement getText1Property = base.GetWebElementPropertiesByXPath
                        (GBInstructorUXPageResource.
                            GBInstructorUX_Page_First_Text_Weight_Xpath_Locator);
                    getText1Property.SendKeys(textValue);
                    break;
                case TextTypeEnum.SecondText:
                    base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                       GBInstructorUX_Page_Second_Text_Weight_Xpath_Locator));
                    // enter value in second text box
                    IWebElement getText2Property = base.GetWebElementPropertiesByXPath
                        (GBInstructorUXPageResource.
                        GBInstructorUX_Page_Second_Text_Weight_Xpath_Locator);
                    getText2Property.SendKeys(textValue);
                    break;
            }
            logger.LogMethodExit("GBInstructorPage", "SelectTheTextboxAndEnterTvalue",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Result displayed in the Total weight text box. 
        /// </summary>
        /// <returns>TotalWeightCore</returns>
        public string GetRestulInTotalWeightTextBox()
        {
            //Get the Result displayed in the Total weight text box
            logger.LogMethodEntry("GBInstructorUXPage", "GetRestulInTotalWeightTextBox",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized variable
            string getTotalWeight = string.Empty;
            try
            {
                //Select Total Column Window
                this.SelectTotalColumnWindow();
                //switch to Iframe
                this.SelectTotalColumnFramework();
                //Wait for element
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_First_Text_Weight_Xpath_Locator),
                    Convert.ToInt32(GBInstructorUXPageResource.GBInstructorUX_Page_WaitTime_Value));
                // Focusing on first text box to get value in total weight text box
                base.FocusOnElementByXPath(GBInstructorUXPageResource.
                                 GBInstructorUX_Page_First_Text_Weight_Xpath_Locator);
                //Select Total Column Window
                this.SelectTotalColumnWindow();
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_TotalWeight_Text_XPath_Locator),
                       Convert.ToInt32(GBInstructorUXPageResource.
                       GBInstructorUX_Page_WaitTime_Value));
                //Get the value from total weight text box
                getTotalWeight = base.GetValueAttributeByXPath(GBInstructorUXPageResource.
                      GBInstructorUX_Page_TotalWeight_Text_XPath_Locator);
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetRestulInTotalWeightTextBox",
                 base.IsTakeScreenShotDuringEntryExit);
            return getTotalWeight;
        }

        /// <summary>
        /// Enable Synchronize With LMS cmenu preference of activity.
        /// </summary>
        public void EnableLmsSynchronizeOption()
        {
            //Enable LMS Synchronize Option of activity is enable in Gradebook
            logger.LogMethodEntry("GBInstructorUXPage", "EnableLMSSynchronizeOption",
                                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Name(GBInstructorUXPageResource.
                    GBInstructorUX_Page_GradesFrame_Iframe_Name_Locator));
                //Switch Into The Student Gradebook Frame
                base.SwitchToIFrame(GBInstructorUXPageResource.
                    GBInstructorUX_Page_GradesFrame_Iframe_Name_Locator);
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                //Total Number Of Activities In The Folder
                int getColumnCount = base.GetElementCountByXPath(
                    (GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                //Get The Row number of activity and enable preference
                this.OpenCMenuOptionForActivityInHed(getColumnCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "EnableLMSSynchronizeOption",
                                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the row number of activity to 
        /// enable Enable LMS SynchronizeOption preference. 
        /// </summary>
        /// <param name="columnCount">This number of activity column.</param>
        public void OpenCMenuOptionForActivityInHed(int columnCount)
        {
            //Validate the activity name
            logger.LogMethodEntry("GBInstructorUXPage",
            "OpenCMenuOptionForActivityInHED", base.IsTakeScreenShotDuringEntryExit);
            //Get The Activity Title
            string getAssignmentTitle = string.Empty;
            //Setting Column Number
            int setColumnNo;
            for (setColumnNo = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); setColumnNo <= columnCount; setColumnNo++)
            {
                //Check For The Assignment In GradeBook
                getAssignmentTitle = GetAssignmetTitle(getAssignmentTitle, setColumnNo);
                if (getAssignmentTitle == GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTitle_Value)
                {
                    break;
                }
            }
            this.ClickOnSynchronizeWithLmsActivityCmenu(setColumnNo);
            logger.LogMethodExit("GBInstructorUXPage", "OpenCMenuOptionForActivityInHED",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Activity C-menu option 
        /// Synchronize with LMS. 
        /// </summary>
        /// <param name="activityColumnNo">This number of activity column.</param>
        private void ClickOnSynchronizeWithLmsActivityCmenu(
            int activityColumnNo)
        {
            //Click On Activity Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage",
                "ClickOnSynchronizeWithLMSActivityCmenu",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Click on cmenu icon of activity on GradeBook Page
            this.ClickOnCmenuOfActivityOnGradebook(activityColumnNo);
            //Wait for Synchronize With LMS c-menu option
            base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_SynchronizeWithLMS_Cmenu_Xpath_Locator));
            //Get text of Synchornize with LMS cmenu option
            String getTextOfLmsCmenu = base.GetInnerTextAttributeValueByXPath(
                GBInstructorUXPageResource.
                GBInstructorUX_Page_SynchronizeWithLMS_Cmenu_Xpath_Locator);
            // Get property of Synchronize With LMS c-menu option
            IWebElement getEditGradeProperty = base.GetWebElementPropertiesByXPath
                (GBInstructorUXPageResource.
                GBInstructorUX_Page_SynchronizeWithLMS_Cmenu_Xpath_Locator);
            //Click On Synchronize With LMS c-menu option
            base.ClickByJavaScriptExecutor(getEditGradeProperty);
            logger.LogMethodExit("GBInstructorUXPage",
                "ClickOnSynchronizeWithLMSActivityCmenu",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on activity cmenu option.
        /// </summary>
        /// <param name="activityColumnNo">This is column number.</param>
        private void ClickOnCmenuOfActivityOnGradebook(int activityColumnNo)
        {
            //Click on cmenu option of activity
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnCmenuOfActivityOnGradebook",
                        base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_CmenuOption_Xpath_Locator, activityColumnNo)));
            //Get property of c-menu option button 
            IWebElement getCmenuProperty = base.GetWebElementPropertiesByXPath
                (string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_CmenuOption_Xpath_Locator, activityColumnNo));
            //Click on Activity Cmenu Button
            base.ClickByJavaScriptExecutor(getCmenuProperty);
            logger.LogMethodExit("GBInstructorUXPage", "ClickOnCmenuOfActivityOnGradebook",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify GradeBook page loaded successfully
        /// </summary>
        public void VerifyGradeBookPageLoaded()
        {
            //Verify GradeBook page loaded successfully
            logger.LogMethodEntry("GBInstructorUXPage", "VerifyGradeBookPageLoaded",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Gradebook Frame
                this.SelectGradebookFrame();
                //wait for element
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_Header_GardeBook_GBGridHeaderTable_ID_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "VerifyGradeBookPageLoaded",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Custom View in GradeBook.
        /// </summary>
        public void NavigateToCustomView()
        {
            //Navigate to CustomView in a gradeBook Page
            logger.LogMethodEntry("GBInstructorUXPage", "NavigateToCustomView",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //select window
                base.SelectWindow(GBInstructorUXPageResource.
                GBInstructorUX_Page_Window_Title);
                //wait for element
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_CustomViewTab_ID_Locator));
                //Get Element Property
                IWebElement getCustomView = base.
                    GetWebElementPropertiesById(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_CustomViewTab_ID_Locator);
                //Click on View Grades Sub Tab Button
                base.ClickByJavaScriptExecutor(getCustomView);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "NavigateToCustomView",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Verify CustomView Page Load in Gradebook
        /// </summary>
        public void VerifyCustomViewPageLoadinGradeBook()
        {
            //Confirm CustomView in a gradeBook Page
            logger.LogMethodEntry("GBInstructorUXPage", "VerifyCustomViewPageLoadinGradeBook",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Custom View Window and Frame
                this.SelectCustomViewWindowandFrame();
                //wait for element
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_Header_GardeBook_GBGridHeaderTable_ID_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("GBInstructorUXPage", "VerifyCustomViewPageLoadinGradeBook",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Custom View Window and Frame.
        /// </summary>
        public void SelectCustomViewWindowandFrame()
        {
            //Select Custom View Window and Frame
            logger.LogMethodEntry("GBInstructorUXPage", "SelectCustomViewWindowandFrame",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //select window
                base.SelectWindow(GBInstructorUXPageResource.
                    GBInstructorUX_Page_CustomView_Window_Title);
                //wait for element
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Synapse_GradesFrame_Iframe_Name_Locator));
                //switch to Iframe
                base.SwitchToIFrame(GBInstructorUXPageResource.
                GBInstructorUX_Page_Synapse_GradesFrame_Iframe_Name_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectCustomViewWindowandFrame",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Grades SubTab in GradeBook
        /// </summary>
        public void NavigateToGradesSubTabinGradeBook()
        {
            //Confirm CustomView in a gradeBook Page
            logger.LogMethodEntry("GBInstructorUXPage", "NavigateToGradesSubTabinGradeBook",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //select window
                base.SelectWindow(GBInstructorUXPageResource.
                    GBInstructorUX_Page_CustomView_Window_Title);
                //wait for element
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_GradesSubTab_ID_Locator));
                //Get Element Property
                IWebElement clickGradesTab = base.GetWebElementPropertiesById
                    (GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_GradesSubTab_ID_Locator);
                //Click on Grades Sub Tab Button
                base.ClickByJavaScriptExecutor(clickGradesTab);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("GBInstructorUXPage", "NavigateToGradesSubTabinGradeBook",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Activity Status.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userLastName">This is User Last name.</param>
        /// <param name="userFirstName">This is User First Name.</param>
        /// <returns>Activity Status.</returns>
        public string GetActivityStatus(string activityName, string userLastName,
            string userFirstName)
        {
            //Get the Activity Status
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityStatus",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getActivityStatusGrade = string.Empty;
            try
            {
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCount(activityName);
                //Get User Row Count
                int getUserRowCount = this.GetUserRowCount(userLastName, userFirstName);
                base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_ActivityStatus_Xpath_Locator,
                    getUserRowCount, getActivityColumnCount)));
                //Activity Status
                getActivityStatusGrade = base.GetElementTextByXPath(string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_ActivityStatus_Xpath_Locator,
                    getUserRowCount, getActivityColumnCount)).Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityStatus",
            base.IsTakeScreenShotDuringEntryExit);
            return getActivityStatusGrade.Trim();
        }

        /// <summary>
        /// Get Activity Column Count.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>This is Activity Column Number.</returns>
        private int GetActivityColumnCount(string activityName)
        {
            //Get Activity Column Count
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityColumnCount",
           base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            int activityColumnNumber = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Count_Value);
            this.SelectGradebookFrame();
            base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_AcitivityNames_Xpath_Locator));
            //Getting the counts of Activity                    
            int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_AcitivityNames_Xpath_Locator);
            for (int columnCount = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); columnCount <= getActivityCount;
                columnCount++)
            {
                //Wait for Element
                base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTitle_Xpath_Locator, columnCount)));
                base.FocusOnElementByXPath(string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTitle_Xpath_Locator, columnCount));
                //Getting the Activity name
                string getActivityName = base.GetTitleAttributeValueByXPath
                    (string.Format(GBInstructorUXPageResource.
                        GBInstructorUX_Page_AssignmentTitle_Xpath_Locator, columnCount));
                if (getActivityName.Contains(activityName))
                {
                    activityColumnNumber = columnCount;
                    break;
                }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityColumnCount",
           base.IsTakeScreenShotDuringEntryExit);
            return activityColumnNumber;
        }

        /// <summary>
        /// Get Activity Column Count for HED Core.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>This is Activity Column Number.</returns>
        private int GetActivityColumnCountHed(string activityName)
        {
            //Get Activity Column Count
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityColumnCountHED",
           base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            int activityColumnNumber = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Count_Value);
            //Getting the counts of Activity
            base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_AcitivityNames_Xpath_Locator));
            int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_AcitivityNames_Xpath_Locator);
            for (int columnCount = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); columnCount <= getActivityCount;
                columnCount++)
            {
                //Getting the Activity name
                string getActivityName = base.GetTitleAttributeValueByXPath
                    (string.Format(GBInstructorUXPageResource.
                        GBInstructorUX_Page_AssignmentTitleFF_Xpath_Locator, columnCount));
                if (getActivityName.Contains(activityName))
                {
                    activityColumnNumber = columnCount;
                    break;
                }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityColumnCountHED",
           base.IsTakeScreenShotDuringEntryExit);
            return activityColumnNumber;
        }
        /// <summary>
        /// Get Activity Column Count.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>This is Activity Column Number.</returns>
        private int GetNormalActivityColumnCount(string activityName)
        {
            //Get Activity Column Count
            logger.LogMethodEntry("GBInstructorUXPage", "GetNormalActivityColumnCount",
           base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            int activityColumnNumber = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Count_Value);
            //Getting the counts of Activity                    
            int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_AcitivityNames_Xpath_Locator);
            for (int columnCount = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); columnCount <= getActivityCount;
                columnCount++)
            {
                //Getting the Activity name
                string getActivityName = base.GetTitleAttributeValueByXPath
                    (string.Format(GBInstructorUXPageResource.
                        GBInstructorUX_Page_AssignmentTitle_TA_Xpath_Locator, columnCount));
                if (getActivityName.Contains(activityName))
                {
                    activityColumnNumber = columnCount;
                    break;
                }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetNormalActivityColumnCount",
           base.IsTakeScreenShotDuringEntryExit);
            return activityColumnNumber;
        }

        /// <summary>
        /// Get User Row Count.
        /// </summary>
        /// <param name="userLastName">This is User Last Name.</param>
        /// <param name="userFirstName">This is User First Name.</param>
        /// <returns>This is User Row Number.</returns>
        private int GetUserRowCount(string userLastName, string userFirstName)
        {
            //Get User Row Count
            logger.LogMethodEntry("GBInstructorUXPage", "GetUserRowCount",
           base.IsTakeScreenShotDuringEntryExit);
            this.SelectGradebookFrame();
            //Initialize VariableVariable
            int userRowNumber = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Count_Value);
            bool gggh12 = base.IsElementPresent(By.XPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_UserCount_Xpath_Locator),10);
            base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_UserCount_Xpath_Locator));
            //Get User Count
            int getUserCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_UserCount_Xpath_Locator);
            for (int userRowCount = Convert.ToInt32(GBInstructorUXPageResource.
                 GBInstructorUX_Page_Initial_Value); userRowCount <= getUserCount;
                 userRowCount++)
            {
                base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                        GBInstructorUX_Page_User_Title_Xpath_Locator, userRowCount)));
                //Get user Name
                string getUserName = base.GetTitleAttributeValueByXPath(
                    string.Format(GBInstructorUXPageResource.
                        GBInstructorUX_Page_User_Title_Xpath_Locator, userRowCount));
                if (getUserName.Contains(userLastName + GBInstructorUXPageResource.
                    GBInstructorUX_Page_Space_value + userFirstName))
                {
                    userRowNumber = userRowCount;
                    break;
                }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetUserRowCount",
           base.IsTakeScreenShotDuringEntryExit);
            return userRowNumber;
        }

        /// <summary>
        /// Get Asset in Gradebook
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        /// <returns>Activity Name</returns>
        public string GetAssetInGradebook(string activityName)
        {
            //Get Asset in Gradebook
            logger.LogMethodEntry("GBInstructorUXPage", "GetAssetInGradebook",
          base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getActivityName = string.Empty;
            try
            {
                // Select Frame
                this.SelectGradebookFrame();
                //Getting the counts of Activity                    
                int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AcitivityNames_Xpath_Locator);
                for (int columnCount = Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Initial_Value); columnCount <= getActivityCount;
                    columnCount++)
                {
                    //Wait for Element
                    base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                        GBInstructorUX_Page_AssetName_TA_Xpath_Locator, columnCount)));
                    //Getting the Activity name
                    getActivityName = base.GetTitleAttributeValueByXPath
                        (string.Format(GBInstructorUXPageResource.
                        GBInstructorUX_Page_AssetName_TA_Xpath_Locator,
                                           columnCount));
                    if (getActivityName == activityName)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetAssetInGradebook",
           base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Select The Cmenu Option Of Asset.
        /// </summary>
        /// <param name="assetCmenuOptionEnum">This is Asset cmenu options.</param>
        /// <param name="assetName">This is Asset name.</param>
        public void SelectTheCmenuOptionOfAsset(
            AssetCmenuOptionEnum assetCmenuOptionEnum, string assetName, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select The Cmenu Option Of Asset
            logger.LogMethodEntry("GBInstructorUXPage", "SelectTheCmenuOptionOfAsset",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Activity Column Count and Click Cmenu Icon
                int getActivityColumnCount = GetActivityColumnCountandClickCmenuIcon(assetName);
                //Click On Cmenu Of Asset In Gradebook
                this.ClickOnCmenuOfAssetInGradebook(
                    getActivityColumnCount, assetCmenuOptionEnum, activityTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectTheCmenuOptionOfAsset",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Cmenu Option Of Asset.
        /// </summary>
        /// <param name="assetCmenuOptionEnum">This is Asset cmenu options.</param>
        /// <param name="assetName">This is Asset name.</param>
        public void SelectTheCmenuOptionOfAssetHed(
            AssetCmenuOptionEnum assetCmenuOptionEnum, string assetName)
        {
            //Select The Cmenu Option Of Asset
            logger.LogMethodEntry("GBInstructorUXPage", "SelectTheCmenuOptionOfAssetHED",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Activity Column Count and Click Cmenu Icon
                int getActivityColumnCount = GetActivityColumnCountandClickCmenuIconHed(assetName);
                //Click On Cmenu Of Asset In Gradebook
                this.ClickOnCmenuOfAssetInGradebookHed(
                    getActivityColumnCount, assetCmenuOptionEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectTheCmenuOptionOfAssetHED",
             base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select Cmenu Option Of Asset In Gradebook.
        /// </summary>
        /// <param name="assetCmenuOptionEnum">This is Asset cmenu options.</param>
        /// <param name="assetName">This is Asset name.</param>
        public void SelectCmenuOptionOfAssetInGradebook(
            AssetCmenuOptionEnum assetCmenuOptionEnum, string assetName)
        {
            //Select The Cmenu Option Of Asset
            logger.LogMethodEntry("GBInstructorUXPage", "SelectTheCmenuOptionOfAsset",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Activity Column Count and Click Cmenu Icon
                int getActivityColumnCount = GetActivityColumnCountandClickCmenuIcon(assetName);
                //click Cmenu of Asset In Gradebook
                this.ClickCmenuofAssetInGradebook(assetCmenuOptionEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectTheCmenuOptionOfAsset",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Column Count and Click Cmenu Icon.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        /// <returns>Activity Column Count.</returns>
        public int GetActivityColumnCountandClickCmenuIcon(string assetName)
        {
            //Get Activity Column Count and Click Cmenu Icon
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityColumnCountandClickCmenuIcon",
           base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            int getActivityColumnCount = Convert.ToInt32(
                GBInstructorUXPageResource.GBInstructorUXPage_Initializer_Value);
            try
            {
                //Get Activity Column Count
                getActivityColumnCount = this.GetActivityColumnCount(assetName);
                //Click The Cmenu Icon In Gradebook
                this.ClickTheCmenuIconInGradebook(getActivityColumnCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityColumnCountandClickCmenuIcon",
           base.IsTakeScreenShotDuringEntryExit);
            return getActivityColumnCount;
        }

        /// <summary>
        /// Get Activity Column Count and Click Cmenu Icon.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        /// <returns>Activity Column Count.</returns>
        public int GetActivityColumnCountandClickCmenuIconHed(string assetName)
        {
            //Get Activity Column Count and Click Cmenu Icon
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityColumnCountandClickCmenuIconHED",
           base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            int getActivityColumnCount = Convert.ToInt32(
                GBInstructorUXPageResource.GBInstructorUXPage_Initializer_Value);
            try
            {
                //Get Activity Column Count
                getActivityColumnCount = this.GetActivityColumnCountHed(assetName);
                //Click The Cmenu Icon In Gradebook
                this.ClickTheCmenuIconInGradebook(getActivityColumnCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityColumnCountandClickCmenuIconHED",
           base.IsTakeScreenShotDuringEntryExit);
            return getActivityColumnCount;
        }
        /// <summary>
        /// Select The Cmenu Option Of Asset.
        /// </summary>
        /// <param name="assetCmenuOptionEnum">This is Asset cmenu options.</param>
        /// <param name="assetName">This is Asset name.</param>
        public void SelectTheCmenuOptionOfActivity(
            AssetCmenuOptionEnum assetCmenuOptionEnum, string assetName, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select The Cmenu Option Of Asset
            logger.LogMethodEntry("GBInstructorUXPage", "SelectTheCmenuOptionOfActivity",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Activity Column Count
                int getActivityColumnCount = this.GetNormalActivityColumnCount(assetName);
                //Click The Cmenu Icon In Gradebook
                this.ClickTheCmenuIconInGradebook(getActivityColumnCount);
                //Click On Cmenu Of Asset In Gradebook
                this.ClickOnCmenuOfAssetInGradebook(
                    getActivityColumnCount, assetCmenuOptionEnum, activityTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectTheCmenuOptionOfActivity",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Cmenu Option Of Asset in Gradebook.
        /// </summary>
        /// <param name="assetCmenuOptionEnum">This is Asset cmenu options.</param>
        /// <param name="assetName">This is Asset name.</param>
        public void SelectCmenuOptionOfAssetinGradebook(
            AssetCmenuOptionEnum assetCmenuOptionEnum, string assetName)
        {
            //Select The Cmenu Option Of Asset in Gradebook
            logger.LogMethodEntry("GBInstructorUXPage", "SelectCmenuOptionOfAssetinGradebook",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCount(assetName);
                //Click The Cmenu Icon In Gradebook
                this.ClickonAssetCmenuIconInGradebook(getActivityColumnCount);
                //Click On Cmenu Of Asset In Gradebook
                this.ClickOnCmenuOfAssetInGradebook(
                    getActivityColumnCount, assetCmenuOptionEnum, Activity.ActivityTypeEnum.Null);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectCmenuOptionOfAssetinGradebook",
             base.IsTakeScreenShotDuringEntryExit);
        }

        // <summary>
        /// Click On Cmenu Of Asset In Gradebook.
        /// </summary>
        /// <param name="getActivityColumnCount">This is asset count.</param>
        /// <param name="assetCmenuOptionEnum">Thia is asset cmenu option Enum.</param>
        private void ClickOnCmenuOfAssetInGradebook(
            int getActivityColumnCount, AssetCmenuOptionEnum assetCmenuOptionEnum, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Cmenu Of Asset In Gradebook
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnCmenuOfAssetInGradebook",
          base.IsTakeScreenShotDuringEntryExit);
            //click Cmenu of Asset In Gradebook
            this.ClickCmenuofAssetInGradebook(assetCmenuOptionEnum);
            switch (assetCmenuOptionEnum)
            {
                // Click 'Synchronize with LMS'
                case AssetCmenuOptionEnum.SynchronizewithLMS:
                    SynchronizeWithLMSCmenuOption(
                        getActivityColumnCount, AssetCmenuOptionEnum.SynchronizewithLMS, activityTypeEnum);
                    break;
                //Click 'Stop LMS synchronization'
                case AssetCmenuOptionEnum.StopLMSSynchronization:
                    SynchronizeWithLMSCmenuOption(
                        getActivityColumnCount, AssetCmenuOptionEnum.StopLMSSynchronization, activityTypeEnum);
                    break;
            }
            logger.LogMethodExit("GBInstructorUXPage", "ClickOnCmenuOfAssetInGradebook",
         base.IsTakeScreenShotDuringEntryExit);
        }

        // <summary>
        /// Click On Cmenu Of Asset In Gradebook.
        /// <summary>
        /// <param name="getActivityColumnCount">This is asset count.</param>
        /// <param name="assetCmenuOptionEnum">Thia is asset cmenu option Enum.</param>
        private void ClickOnCmenuOfAssetInGradebookHed(
            int getActivityColumnCount, AssetCmenuOptionEnum assetCmenuOptionEnum)
        {
            //Click On Cmenu Of Asset In Gradebook
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnCmenuOfAssetInGradebookHED",
          base.IsTakeScreenShotDuringEntryExit);
            //click Cmenu of Asset In Gradebook
            this.ClickCmenuofAssetInGradebook(assetCmenuOptionEnum);
            logger.LogMethodExit("GBInstructorUXPage", "ClickOnCmenuOfAssetInGradebookHED",
         base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// click Cmenu of Asset In Gradebook.
        /// </summary>        
        /// <param name="assetCmenuOptionEnum">This is asset cmenu option Enum.</param>
        public void ClickCmenuofAssetInGradebook(AssetCmenuOptionEnum assetCmenuOptionEnum)
        {
            //Click On Cmenu Of Asset In Gradebook
            logger.LogMethodEntry("GBInstructorUXPage", "clickCmenuofAssetInGradebook",
          base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (assetCmenuOptionEnum)
                {
                    //Click the 'View All Submission' cmenu
                    case AssetCmenuOptionEnum.ViewAllSubmissions:
                        this.SelectViewAllSubmissionCmenuOption();
                        break;
                    //Click the 'Apply Grade Schema' cmenu
                    case AssetCmenuOptionEnum.ApplyGradeSchema:
                        this.SelectApplyGradeSchemaCmenuOption();
                        break;
                    //Click the 'Remove from Custom View' cmenu
                    case AssetCmenuOptionEnum.RemovefromCustomView:
                        this.SelectRemovefromCustomViewCmenuOption();
                        break;
                    //Click the 'Save to Custom View' cmenu
                    case AssetCmenuOptionEnum.SavetoCustomView:
                        this.SelectSavetoCustomViewCmenuOption();
                        break;
                    //Click the 'Modify Grade Schema'
                    case AssetCmenuOptionEnum.ModifyGradeSchema:
                        this.SelectModifyGradeSchemaCmenuOption();
                        break;
                    //Click the 'Remove Grade Schema'
                    case AssetCmenuOptionEnum.RemoveGradeSchema:
                        this.SelectRemoveGradeSchemaCmenuOption();
                        break;
                    //Click the 'Edit Grades'
                    case AssetCmenuOptionEnum.EditGrades:
                        this.SelectTheEditGradesCmenuOption();
                        break;
                    //Click 'Hide for Student'
                    case AssetCmenuOptionEnum.HideforStudent:
                        this.SelectTheHideForStudentCmenuOption();
                        break;
                    //Click 'Show for Student'
                    case AssetCmenuOptionEnum.ShowforStudent:
                        this.SelectTheShowForStudentCmenuOption();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "clickCmenuofAssetInGradebook",
        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Hide For Student Cmenu Option.
        /// </summary>
        private void SelectTheHideForStudentCmenuOption()
        {
            //Select The Hide For Student Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "SelectTheHideForStudentCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_HideForStudent_Cmeenu_ID_Locator));
            IWebElement getSelectRemoveGradeSchemaCmenuOption =
                base.GetWebElementPropertiesById(GBInstructorUXPageResource.
                GBInstructorUX_Page_HideForStudent_Cmeenu_ID_Locator);
            //Click the 'Hide For Student' Cmenu Option
            base.ClickByJavaScriptExecutor(getSelectRemoveGradeSchemaCmenuOption);
            logger.LogMethodExit("GBInstructorUXPage", "SelectTheHideForStudentCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Edit Grades Cmenu Option.
        /// </summary>
        private void SelectTheEditGradesCmenuOption()
        {
            //Select The Edit Grades Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "SelectTheEditGradesCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_GradeColumn_EditGrade_ID_Locator));
            IWebElement getSelectRemoveGradeSchemaCmenuOption =
                base.GetWebElementPropertiesById(GBInstructorUXPageResource.
                GBInstructorUX_Page_GradeColumn_EditGrade_ID_Locator);
            //Click the 'Remove Grade Schema' Cmenu Option
            base.ClickByJavaScriptExecutor(getSelectRemoveGradeSchemaCmenuOption);
            logger.LogMethodExit("GBInstructorUXPage", "SelectTheEditGradesCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Cmenu Icon In Gradebook.
        /// </summary>
        /// <param name="getActivityColumnCount">This is Asset column count.</param>
        private void ClickTheCmenuIconInGradebook(int getActivityColumnCount)
        {
            // Click The Cmenu Icon In Gradebook
            logger.LogMethodEntry("GBInstructorUXPage", "ClickTheCmenuIconInGradebook",
                         base.IsTakeScreenShotDuringEntryExit);
            //Get Element Property
            IWebElement getCmenuIconProperty = base.GetWebElementPropertiesByXPath
                (String.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_Asset_Cmenuicon_Xpath_Locator, getActivityColumnCount));
            //Perform Mouse Click Action
            base.ClickByJavaScriptExecutor(getCmenuIconProperty);
            Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_SleepTime_Value));
            logger.LogMethodExit("GBInstructorUXPage", "ClickTheCmenuIconInGradebook",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Asset Cmenu Icon In Gradebook.
        /// </summary>
        /// <param name="getActivityColumnCount">This is Asset column count.</param>
        private void ClickonAssetCmenuIconInGradebook(int getActivityColumnCount)
        {
            // Click on Asset Cmenu Icon In Gradebook
            logger.LogMethodEntry("GBInstructorUXPage", "ClickonAssetCmenuIconInGradebook",
                         base.IsTakeScreenShotDuringEntryExit);
            //Wait for the cmenu icon
            base.WaitForElement(By.XPath(String.Format(GBInstructorUXPageResource.
                GBInstructorUXPage_Gradebook_CmenuIcon_Xpath_Locator, getActivityColumnCount)));
            //Get Element Property
            IWebElement getCmenuIconProperty = base.GetWebElementPropertiesByXPath
                (String.Format(GBInstructorUXPageResource.
                GBInstructorUXPage_Gradebook_CmenuIcon_Xpath_Locator, getActivityColumnCount));
            //Perform Mouse Click Action
            base.PerformMouseClickAction(getCmenuIconProperty);
            Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_SleepTime_Value));
            logger.LogMethodExit("GBInstructorUXPage", "ClickonAssetCmenuIconInGradebook",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Modify Grades Schema Cmenu Option
        /// </summary>
        private void SelectModifyGradeSchemaCmenuOption()
        {
            //Select Modify Grades Schema Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "SelectModifyGradeSchemaCmenuOption",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_ModifyGradeSchema_Cmenu_Id_Locator));
            IWebElement getSelectModifyGradeSchemaCmenuOption = base.GetWebElementPropertiesById(
                GBInstructorUXPageResource.GBInstructorUX_Page_ModifyGradeSchema_Cmenu_Id_Locator);
            //Click the 'Modify Grade Schema' Cmenu Option
            base.ClickByJavaScriptExecutor(getSelectModifyGradeSchemaCmenuOption);
            logger.LogMethodExit("GBInstructorUXPage", "SelectModifyGradeSchemaCmenuOption",
                                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Remove Grades Schema Cmenu Option
        /// </summary>
        private void SelectRemoveGradeSchemaCmenuOption()
        {
            //Select Modify Grades Schema Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "SelectRemoveGradeSchemaCmenuOption",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_RemoveGradeSchema_Cmenu_Id_Locator));
            IWebElement getSelectRemoveGradeSchemaCmenuOption = base.GetWebElementPropertiesById(
                GBInstructorUXPageResource.GBInstructorUX_Page_RemoveGradeSchema_Cmenu_Id_Locator);
            //Click the 'Remove Grade Schema' Cmenu Option
            base.ClickByJavaScriptExecutor(getSelectRemoveGradeSchemaCmenuOption);
            logger.LogMethodExit("GBInstructorUXPage", "SelectRemoveGradeSchemaCmenuOption",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Save to Custom View Cmenu Option
        /// </summary>
        private void SelectSavetoCustomViewCmenuOption()
        {
            // Select Save to Custom View Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "SelectSavetoCustomViewCmenuOption",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                        GBInstructorUX_Page_SavetoCustomView_Cmenu_Id_Locator));
            IWebElement getSavetoCustomViewcmenuOption = base.GetWebElementPropertiesById
                (GBInstructorUXPageResource.
                        GBInstructorUX_Page_SavetoCustomView_Cmenu_Id_Locator);
            //Click the 'Save to Custom View' cmenu option
            base.ClickByJavaScriptExecutor(getSavetoCustomViewcmenuOption);
            logger.LogMethodExit("GBInstructorUXPage", "SelectSavetoCustomViewCmenuOption",
                                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Remove from Custom View Cmenu Option
        /// </summary>
        private void SelectRemovefromCustomViewCmenuOption()
        {
            //Select Remove from Custom View Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "SelectRemovefromCustomViewCmenuOption",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for the cmenu            
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                        GBInstructorUX_Page_RemovefromCustomView_Cmenu_Id_Locator));
            IWebElement getRemovefromCustomViewCmenuoption = base.GetWebElementPropertiesById
                (GBInstructorUXPageResource.
                        GBInstructorUX_Page_RemovefromCustomView_Cmenu_Id_Locator);
            //Click the 'Remove from Custom View ' cmenu
            base.ClickByJavaScriptExecutor(getRemovefromCustomViewCmenuoption);
            logger.LogMethodExit("GBInstructorUXPage", "SelectRemovefromCustomViewCmenuOption",
                                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Apply Grade Schema Cmenu Option
        /// </summary>
        private void SelectApplyGradeSchemaCmenuOption()
        {
            //Select Apply Grade Schema Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "SelectApplyGradeSchemaCmenuOption",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for the cmenu
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                         GBInstructorUX_Page_ApplyGradeSchema_Cmenu_Id_Locator));
            IWebElement getApplyGradeSchemaCmenu = base.GetWebElementPropertiesById
                (GBInstructorUXPageResource.
                         GBInstructorUX_Page_ApplyGradeSchema_Cmenu_Id_Locator);
            //Click the 'Apply Grade Schema' cmenu option
            base.ClickByJavaScriptExecutor(getApplyGradeSchemaCmenu);
            logger.LogMethodExit("GBInstructorUXPage", "SelectApplyGradeSchemaCmenuOption",
                                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select View All Submission Cmenu Option
        /// </summary>
        private void SelectViewAllSubmissionCmenuOption()
        {
            //Select View All Submission Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "SelectViewAllSubmissionCmenuOption",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for the cmenu
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_ViewAllSubmission_Cmenu_Id_Locator));
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_ViewAllSubmission_Cmenu_Id_Locator));
            IWebElement getViewAllSubmissionCmenu = base.GetWebElementPropertiesById
                (GBInstructorUXPageResource.
                GBInstructorUX_Page_ViewAllSubmission_Cmenu_Id_Locator);
            base.ClickByJavaScriptExecutor(getViewAllSubmissionCmenu);
            logger.LogMethodExit("GBInstructorUXPage", "SelectViewAllSubmissionCmenuOption",
                                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Synchronize with LMS/Stop LMS Synchronization Cmenu Option
        /// </summary>
        private void SynchronizeWithLMSCmenuOption(int getActivityColumnCount, AssetCmenuOptionEnum LMSoption, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select View All Submission Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "SynchronizeWithLMSCmenuOption",
                                   base.IsTakeScreenShotDuringEntryExit);

            //Wait for the cmenu
            base.WaitForElement(By.Id(GBInstructorUXPageResource.GBInstructorUXPage_Gradebook_LMSCmenu_ID_Locator));
            IWebElement getLMSGradesynchCmenu = base.GetWebElementPropertiesById
                (GBInstructorUXPageResource.GBInstructorUXPage_Gradebook_LMSCmenu_ID_Locator);
            base.ClickByJavaScriptExecutor(getLMSGradesynchCmenu);

            if (LMSoption == AssetCmenuOptionEnum.SynchronizewithLMS)
            {
                this.updateActivityWithLMSSynchID(getActivityColumnCount, activityTypeEnum);
            }

            logger.LogMethodExit("GBInstructorUXPage", "SynchronizeWithLMSCmenuOption",
                                   base.IsTakeScreenShotDuringEntryExit);
        }

        private void updateActivityWithLMSSynchID(int getActivityColumnCount, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select LMS Grade Synch Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "updateActivityWithLMSSynchID",
                                   base.IsTakeScreenShotDuringEntryExit);

            //Wait for the LMS icon
            base.WaitForElement(By.XPath(String.Format
                (GBInstructorUXPageResource.GBInstructorUXPage_Gradebook_LMSImage_Xpath_Locator, getActivityColumnCount)));
            //Get Element Property
            IWebElement getLMSIconProperty = base.GetWebElementPropertiesByXPath(String.Format
                (GBInstructorUXPageResource.GBInstructorUXPage_Gradebook_LMSImage_Xpath_Locator, getActivityColumnCount));

            string LMSGradesynch = getLMSIconProperty.GetAttribute("title");
            string[] LMSAttribute = LMSGradesynch.Split(':');

            Activity activity = Activity.Get(activityTypeEnum);
            activity.ActivityId = LMSAttribute[1].Trim();
            activity.CreationDate = DateTime.Now;
            activity.UpdateActivityInMemory(activity);

            logger.LogMethodExit("GBInstructorUXPage", "updateActivityWithLMSSynchID",
                                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Cmenu Option of Asset.
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option.</param>
        /// <param name="assetName">This is Asset Name.</param>
        /// <returns>Cmenu Option.</returns>
        public string GetCmenuOptionofAsset(string cmenuOption, string assetName)
        {
            //Get Cmenu Option of Asset
            logger.LogMethodEntry("GBInstructorUXPage", "GetCmenuOptionofAsset",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getCmenuOption = string.Empty;
            try
            {
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCount(assetName);
                //Click the Cmenu Icon In Gradebook
                this.ClickTheCmenuIconInGradebook(getActivityColumnCount);
                //Get Cmenu Option
                getCmenuOption = this.GetContextMenuOptionDisplayed(cmenuOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetCmenuOptionofAsset",
                     base.IsTakeScreenShotDuringEntryExit);
            return getCmenuOption;
        }

        /// <summary>
        /// Select The Cmenu Option Of Asset in TA
        /// </summary>
        /// <param name="assetCmenuOptionEnum">This is Asset cmenu option</param>
        /// <param name="assetName">This is Asset name</param>
        public void SelectTheCmenuOptionOfAssetinTA(AssetCmenuOptionEnum
            assetCmenuOptionEnum, string assetName)
        {
            //Select The Cmenu Option Of Asset in TA
            logger.LogMethodEntry("GBInstructorUXPage", "SelectTheCmenuOptionOfAssetinTA",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCountforTA(assetName);
                //Click The Cmenu Icon In Gradebook
                this.ClickTheCmenuIconInGradebook(getActivityColumnCount);
                //Click On Cmenu Of Asset In Gradebook
                this.ClickOnCmenuOfAssetInGradebook(getActivityColumnCount,
                    assetCmenuOptionEnum, Activity.ActivityTypeEnum.Null);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectTheCmenuOptionOfAssetinTA",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Column Count in TA
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        /// <returns>This is Activity Column Number</returns>
        private int GetActivityColumnCountforTA(string activityName)
        {
            //Get Activity Column Count in TA
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityColumnCountforTA",
           base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getActivityName = string.Empty;
            //Initialize VariableVariable
            int activityColumnNumber = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Count_Value);
            //Getting the counts of Activity                    
            int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_AcitivityNames_Xpath_Locator);
            for (int columnCount = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); columnCount <= getActivityCount;
                columnCount++)
            {
                //Wait for Element
                base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTitle_TA_Xpath_Locator
                    , columnCount)));
                //Getting the Activity name
                getActivityName = base.GetTitleAttributeValueByXPath
                    (string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTitle_TA_Xpath_Locator,
                                       columnCount));
                if (getActivityName == activityName)
                {
                    activityColumnNumber = columnCount;
                    break;
                }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityColumnCountforTA",
           base.IsTakeScreenShotDuringEntryExit);
            return activityColumnNumber;
        }

        /// <summary>
        /// Get Cmenu Option of Asset in TA
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option</param>
        /// <param name="assetName">This is Asset Name</param>
        /// <returns>Cmenu Option</returns>
        public string GetCmenuOptionofAssetinTA(string cmenuOption, string assetName)
        {
            //Get Cmenu Option of Asset in TA
            logger.LogMethodEntry("GBInstructorUXPage", "GetCmenuOptionofAssetinTA",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getCmenuOption = string.Empty;
            try
            {
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCountforTA(assetName);
                //Click the Cmenu Icon In Gradebook
                this.ClickTheCmenuIconInGradebook(getActivityColumnCount);
                //Get Cmenu Option
                getCmenuOption = this.GetContextMenuOptionDisplayed(cmenuOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetCmenuOptionofAssetinTA",
                     base.IsTakeScreenShotDuringEntryExit);
            return getCmenuOption;
        }

        /// <summary>
        /// Click The Activity Under Grade Cell Cmenu.
        /// </summary>
        /// <param name="assetName">This is Asset name</param>
        public void ClickTheActivityUnderGradeCellCmenu(string assetName)
        {
            // Click The Activity Under Grade Cell Cmenu
            logger.LogMethodEntry("GBInstructorUXPage", "ClickTheActivityUnderGradeCellCmenu",
                                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Frame
                this.SelectGradebookFrame();
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCount(assetName);
                this.ClickTheActivityUnderGradeCellCmenuIcon(getActivityColumnCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ClickTheActivityUnderGradeCellCmenu",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Activity Under Grade Cell Cmenu icon
        /// </summary>
        /// <param name="getActivityColumnCount">This is colunm count</param>
        private void ClickTheActivityUnderGradeCellCmenuIcon(int getActivityColumnCount)
        {
            // Click The Activity Under Grade Cell Cmenu icon
            logger.LogMethodEntry("GBInstructorUXPage", "ClickTheActivityUnderGradeCellCmenuIcon",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_Undergrade_ColumnClick_Xpath_Locator, getActivityColumnCount)));
            IWebElement getCmenuImageButton = base.GetWebElementPropertiesByXPath
                (string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_Undergrade_ColumnClick_Xpath_Locator, getActivityColumnCount));
            base.ClickByJavaScriptExecutor(getCmenuImageButton);
            //Wait for Element
            base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_Undergrade_Cmenu_Xpath_Locator, getActivityColumnCount)));
            IWebElement getGradeCellCmenuProperty = base.GetWebElementPropertiesByXPath
                (string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_Undergrade_Cmenu_Xpath_Locator, getActivityColumnCount));
            //Mouse performance action
            base.PerformMouseHoverByJavaScriptExecutor(getGradeCellCmenuProperty);
            Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_WaitWindowTime_Value));
            //Wait for the element
            base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_Undergrade_Cmenu_Icon_Xpath_Locator, getActivityColumnCount)));
            IWebElement getCmenuIconButton = base.GetWebElementPropertiesByXPath
                (string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_Undergrade_Cmenu_Icon_Xpath_Locator, getActivityColumnCount));
            //Click the Image icon cmenu
            base.ClickByJavaScriptExecutor(getCmenuIconButton);
            logger.LogMethodExit("GBInstructorUXPage", "ClickTheActivityUnderGradeCellCmenuIcon",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Cmenu Option in Grades Cell.
        /// </summary>
        /// <param name="gradeCellCmenuOptionEnum">This is Grade Cell Cmenu Type Enum</param>
        public void SelectCmenuOptionInGradeCell(GradeCellCmenuOptionTypeEnum gradeCellCmenuOptionEnum)
        {
            //Select the Cmenu Option in Grades Cell
            logger.LogMethodEntry("GBInstructorUXPage", "SelectCmenuOptionInGradeCell",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (gradeCellCmenuOptionEnum)
                {
                    case GradeCellCmenuOptionTypeEnum.EditGrade:
                        //Click On Edit Grade Cmenu option in grade cell
                        this.ClickOnEditGradeCellCmenuOption();
                        break;
                    case GradeCellCmenuOptionTypeEnum.ViewGradeSubmission:
                        //Click On View Grade Submission Cmenu option in grade cell
                        this.ClickOnViewGradeSubmissionCellCmenuOption();
                        break;
                    case GradeCellCmenuOptionTypeEnum.ViewGradeHistory:
                        //Click On View Grade History Cell Cmenu Option
                        this.ClickOnViewGradeHistoryCellCmenuOption();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectCmenuOptionInGradeCell",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On View Grade History Cell Cmenu Option.
        /// </summary>
        private void ClickOnViewGradeHistoryCellCmenuOption()
        {
            //Click On View Grade History Cell Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnViewGradeHistoryCellCmenuOption",
                 base.IsTakeScreenShotDuringEntryExit);
            //Wait for the View Grade History Cell Cmenu Option
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_UnderGradecel_ViewHistory_Cmenu_Id_Locator));
            //Get Edit Grade Cmenu Option Property
            IWebElement getViewGradeHistoryCmenuOptionProperty = base.GetWebElementPropertiesById
                (GBInstructorUXPageResource.
                    GBInstructorUX_Page_UnderGradecel_ViewHistory_Cmenu_Id_Locator);
            //Click On  View Grade History Cmenu Option
            base.ClickByJavaScriptExecutor(getViewGradeHistoryCmenuOptionProperty);
            logger.LogMethodExit("GBInstructorUXPage", "ClickOnViewGradeHistoryCellCmenuOption",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Edit Grade Cell Cmenu Option.
        /// </summary>
        private void ClickOnEditGradeCellCmenuOption()
        {
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnEditGradeCellCmenuOption",
                 base.IsTakeScreenShotDuringEntryExit);
            //Click On Edit Grade Cell Cmenu Option
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_EditGrade_Cmenu_Id_Locator));
            //Get Edit Grade Cmenu Option Property
            IWebElement getEditGradeCmenuOptionProperty = base.GetWebElementPropertiesById
                (GBInstructorUXPageResource.
                GBInstructorUX_Page_EditGrade_Cmenu_Id_Locator);
            //Click On Edit Grade Cmenu Option
            base.ClickByJavaScriptExecutor(getEditGradeCmenuOptionProperty);
            logger.LogMethodExit("GBInstructorUXPage", "ClickOnEditGradeCellCmenuOption",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On View Grade/Submission Cell Cmenu Option.
        /// </summary>
        private void ClickOnViewGradeSubmissionCellCmenuOption()
        {
            //Click On View Grade/Submission Cell Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage",
                "ClickOnViewGradeSubmissionCellCmenuOption",
                 base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_ViewGradeSubmission_Cmenu_Id_Locator));
            //Get View Grade/Submission Cmenu Option Property
            IWebElement getViewGradeSubmissionCmenuOptionProperty =
                base.GetWebElementPropertiesById(GBInstructorUXPageResource.
                GBInstructorUX_Page_ViewGradeSubmission_Cmenu_Id_Locator);
            //Click On View Grade/Submission Cmenu Option
            base.ClickByJavaScriptExecutor(getViewGradeSubmissionCmenuOptionProperty);
            logger.LogMethodExit("GBInstructorUXPage",
                "ClickOnViewGradeSubmissionCellCmenuOption",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Update the grade For the Submitted Activity
        /// </summary>
        public void UpdateTheGradeForSubmittedActivity()
        {
            //Update the grade For the Submitted Activity
            logger.LogMethodEntry("GBInstructorUXPage", "UpdateTheGradeForSubmittedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Fill Edit Grade Score Value
                this.FillEditGradeScoreValue(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Input_ScoreValue);
                //Fill Edit Grade Max Score Value
                this.FillEditGradeMaxScoreValue(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Input_MaxScoreValue);
                //Click On Update Button
                this.ClickOnUpdateButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "UpdateTheGradeForSubmittedActivity",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill The Edit Grade Score Value
        /// </summary>
        /// <param name="scoreValue">This is Score Value</param>
        private void FillEditGradeScoreValue(string scoreValue)
        {
            //Fill The Edit Grade Score Value
            logger.LogMethodEntry("GBInstructorUXPage", "FillEditGradeScoreValue",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_Input_ScoreValue_Id_Locator));
            base.ClearTextById(GBInstructorUXPageResource.
                GBInstructorUX_Page_Input_ScoreValue_Id_Locator);
            //Fill The Score Value
            base.FillTextBoxById(GBInstructorUXPageResource.
                GBInstructorUX_Page_Input_ScoreValue_Id_Locator, scoreValue);
            logger.LogMethodExit("GBInstructorUXPage", "FillEditGradeScoreValue",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill The Edit Grade Max Score Value
        /// </summary>
        /// <param name="maxScoreValue">This is Max Score Value</param>
        private void FillEditGradeMaxScoreValue(string maxScoreValue)
        {
            //Fill The Edit Grade Max Score Value
            logger.LogMethodEntry("GBInstructorUXPage", "FillEditGradeMaxScoreValue",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_Input_MaxScoreValue_Id_Locator));
            base.ClearTextById(GBInstructorUXPageResource.
                GBInstructorUX_Page_Input_MaxScoreValue_Id_Locator);
            //Fill the Max Score Value
            base.FillTextBoxById(GBInstructorUXPageResource.
                GBInstructorUX_Page_Input_MaxScoreValue_Id_Locator, maxScoreValue);
            logger.LogMethodExit("GBInstructorUXPage", "FillEditGradeMaxScoreValue",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Update Button
        /// </summary>
        private void ClickOnUpdateButton()
        {
            //Click On Update Button
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnUpdateButton",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_Update_Button_Id_Locator));
            //Get Update Button Property
            IWebElement getUpdateButtonProperty = base.GetWebElementPropertiesById
                (GBInstructorUXPageResource.
                GBInstructorUX_Page_Update_Button_Id_Locator);
            //Click On Update Button
            base.ClickByJavaScriptExecutor(getUpdateButtonProperty);
            logger.LogMethodExit("GBInstructorUXPage", "ClickOnUpdateButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Verify Is Grade Cell Icon Present
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        /// <param name="userLastName">This is UserLast Name</param>
        /// <param name="userFirstName">This is UserFirst Name</param>
        /// <returns>True if the Grade Icon is Present, false otherwise.</returns>
        public Boolean IsGradeCellIconPresent(string activityName,
            string userLastName, string userFirstName)
        {
            //Verify Is Grade Cell Icon Present
            logger.LogMethodEntry("GBInstructorUXPage", "IsGradeCellIconPresent",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            Boolean isActivityGradeIconPresent = false;
            try
            {
                // Select Frame
                this.SelectGradebookFrame();
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCount(activityName);
                //Get User Row Count
                int getUserRowCount = this.GetUserRowCount(userLastName, userFirstName);
                //Verify Activity GradeIcon
                isActivityGradeIconPresent = base.IsElementPresent(By.XPath(String.Format(
                    GBInstructorUXPageResource.GBInstructorUX_Page_AssetCellGrade_Xpath_Locator,
                    (getUserRowCount + Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Initial_Value)), getActivityColumnCount)));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "IsGradeCellIconPresent",
            base.IsTakeScreenShotDuringEntryExit);
            return isActivityGradeIconPresent;
        }

        /// <summary>
        /// Displayed Cmenu options Under the Gradecell activity.
        /// </summary>
        /// <returns>Cmenu are present</returns>
        public Boolean IsCmenuOptionsDisplayedUnderGradecellActivity()
        {
            // Is Displayed Cmenu Under the Gradecell
            logger.LogMethodEntry("GBInstructorUXPage", "IsCmenuOptionsDisplayedUnderGradecellActivity",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isDefaultCmenuOptionsDisplayed = false;
            try
            {
                //Edit Grade Cmenu options
                bool isEditGradeDisplayed = base.IsElementPresent(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_UnderGradecel_EditGrade_Cmenu_Id_Locator));
                //View Submission Cmenu options
                bool isViewSubmissionDisplayed = base.IsElementPresent(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_UnderGradecel_ViewSubmission_Cmenu_Id_Locator));
                //View History Cmenu options
                bool isGradeHistoryDisplayed = base.IsElementPresent(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_UnderGradecel_ViewHistory_Cmenu_Id_Locator));
                isDefaultCmenuOptionsDisplayed = isEditGradeDisplayed &&
                    isViewSubmissionDisplayed && isGradeHistoryDisplayed;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "IsCmenuOptionsDisplayedUnderGradecellActivity",
              base.IsTakeScreenShotDuringEntryExit);
            return isDefaultCmenuOptionsDisplayed;
        }

        /// <summary>
        /// Get Grade Value Present In GradeCell.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Grade value.</returns>
        public string GetGradeValuePresentInGradeCell(string activityName)
        {
            //Get Grade Value Present In GradeCell
            logger.LogMethodEntry("GBInstructorUXPage", "GetGradeValuePresentInGradeCell",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialized Variable
            string getAssignmentTitle = string.Empty;
            string getActivityGrade = string.Empty;
            try
            {
                //Select Student Gradebook Frame
                this.SelectStudentGradebookFrame();
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                //Total Number Of Activities In The Folder
                int getColumnCount = base.GetElementCountByXPath(
                    (GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                for (int setColumnNo = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); setColumnNo <= getColumnCount; setColumnNo++)
                {
                    //Get the Asset name
                    getAssignmentTitle = base.GetTitleAttributeValueByXPath(
                        string.Format(GBInstructorUXPageResource.
                        GBInstructorUX_Page_AssignmentTitleIE_Xpath_Locator, setColumnNo));
                    if (getAssignmentTitle.Contains(activityName))
                    {
                        //Get Activity Schema Value
                        getActivityGrade = this.GetActivitySchemaValue(setColumnNo);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetGradeValuePresentInGradeCell",
               base.IsTakeScreenShotDuringEntryExit);
            return getActivityGrade;
        }

        /// <summary>
        /// Get Activity Schema Value.
        /// </summary>
        /// <param name="setColumnNo">This is Column Count.</param>
        /// <returns>Activity Schema value.</returns>
        private string GetActivitySchemaValue(int setColumnNo)
        {
            //Get Activity Schema Value
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivitySchemaValue",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getActivityGrade = string.Empty;
            //Wait for the element
            base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_ActivitySchemaValue_Xpath_Locator, setColumnNo)));
            //Get The Grade In The Cell
            getActivityGrade = base.GetTitleAttributeValueByXPath
                ((string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_ActivitySchemaValue_Xpath_Locator, setColumnNo)));
            //Switch To Default Window
            base.SelectWindow(GBFoldersPageResource
                .GBFolders_Page_Gradebook_WindowName);
            logger.LogMethodExit("GBInstructorUXPage", "GetActivitySchemaValue",
               base.IsTakeScreenShotDuringEntryExit);
            return getActivityGrade;
        }

        /// <summary>
        /// Click On Search Activity ViewGrades Button.
        /// </summary>
        public void ClickOnSearchActivityViewGradesButton()
        {
            //Click On Search Activity ViewGrades Button
            logger.LogMethodEntry("GBInstructorUXPage",
                "ClickOnSearchActivityViewGradesButton",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectGradebookFrame();
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_WaitWindowTime_Value));
                //Get Searched Activity Name
                this.GetSearchedActivityName();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage",
                "ClickOnSearchActivityViewGradesButton",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Searched Activity Name.
        /// </summary>
        private void GetSearchedActivityName()
        {
            // Get Searched Activity Name
            logger.LogMethodEntry("GBInstructorUXPage", "GetSearchedActivityName",
                 base.IsTakeScreenShotDuringEntryExit);
            //Getting the counts of Activity                    
            int getActivityCount = base.GetElementCountByXPath(
                GBInstructorUXPageResource.
                GBInstructorUX_Page_AssignmentCount_Xpath_Locator);
            for (int activityColumnNo = Convert.ToInt32(GBInstructorUXPageResource.
            GBInstructorUX_Page_Initial_Value);
            activityColumnNo <= getActivityCount; activityColumnNo++)
            {
                //Wait for Element
                base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Searched_Activity_Name_Xpath_Locator,
                    activityColumnNo)));
                //Getting the Activity name
                string getActivityName = base.GetTitleAttributeValueByXPath
                    (string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Searched_Activity_Name_Xpath_Locator,
                    activityColumnNo));
                if (getActivityName.Contains(GBInstructorUXPageResource.
                               GBInstructorUX_Page_ActivityName_Value))
                {
                    //Click The View Grade Button.
                    this.ClickTheViewGradeButton(activityColumnNo);
                    break;
                }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetSearchedActivityName",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Assignment Types Activity In Gradebook.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Name.</returns>
        public string GetAssignmentTypeActivityInGradebook(string activityName)
        {
            // Get Assignment Types Activity In Gradebook.
            logger.LogMethodEntry("GBInstructorUXPage",
                "GetAssignmentTypeActivityInGradebook",
                 base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            //Select Window
            this.SelectGradebookFrame();
            //Getting the counts of Activity                    
            int getActivityCount = base.GetElementCountByXPath(
                GBInstructorUXPageResource.
                GBInstructorUX_Page_AssignmentCount_Xpath_Locator);
            for (int activityColumnNo = Convert.ToInt32(GBInstructorUXPageResource.
            GBInstructorUX_Page_Initial_Value);
            activityColumnNo <= getActivityCount; activityColumnNo++)
            {
                //Wait for Element
                base.WaitForElement(By.XPath(string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_AssignmentTitleIE_Xpath_Locator,
                    activityColumnNo)));
                //Getting the Activity name
                getActivityName = base.GetTitleAttributeValueByXPath
                    (string.Format(GBInstructorUXPageResource.
                GBInstructorUX_Page_AssignmentTitleIE_Xpath_Locator,
                    activityColumnNo));
                if (getActivityName.Contains(activityName))
                {
                    break;
                }
            }
            logger.LogMethodExit("GBInstructorUXPage",
                "GetAssignmentTypeActivityInGradebook",
              base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Click On Asset View Grades Button.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void ClickOnAssetViewGradesButton(string activityName)
        {
            //Click On Activity View Grades Button
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnAssetViewGradesButton",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectGradebookFrame();
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_WaitWindowTime_Value));
                //Get Activity Name
                this.GetActivityName(activityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ClickOnAssetViewGradesButton",
                                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Apply Gradebook 'Assignment Types' Filter.
        /// </summary>
        public void ApplyGradebookAssignmentTypesFilter()
        {
            //Apply Gradebook 'Assignment Types' Filter
            logger.LogMethodEntry("GBInstructorUXPage", "ApplyGradebookAssignmentTypesFilter",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_Title);
                base.SelectWindow(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_Title);
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTypes_Filter_Id_Locator));
                //Click on 'Assignment Types' Filter Option
                base.ClickButtonById(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTypes_Filter_Id_Locator);
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTypes_HomeworkCheckbox_Xpath_Locator));
                //Selct 'Homework' Option in 'Assignment Types' Filter
                base.SelectCheckBoxByXPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTypes_HomeworkCheckbox_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ApplyGradebookAssignmentTypesFilter",
                                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check 'Assignment Types' Filter Apply In Gradebook.
        /// </summary>
        /// <returns></returns>
        public bool IsAssignmentTypesFilterApplyInGradebook()
        {
            //Check 'Assignment Types' Filter Apply In Gradebook
            logger.LogMethodEntry("GBInstructorUXPage",
                "IsAssignmentTypesFilterApplyInGradebook",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isAssignmentTypesFilterApply = false;
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_Title);
                base.SelectWindow(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Window_Title);
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTypes_Filter_Id_Locator));
                //Click on 'Assignment Types' Filter Option
                base.ClickButtonById(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTypes_Filter_Id_Locator);
                //Wait for 'Homework' Option in 'Assignment Types' Filter
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTypes_HomeworkCheckbox_Xpath_Locator));
                if (base.IsElementSelectedByXPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTypes_HomeworkCheckbox_Xpath_Locator))
                {
                    isAssignmentTypesFilterApply = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage",
                "IsAssignmentTypesFilterApplyInGradebook",
                                  base.IsTakeScreenShotDuringEntryExit);
            return isAssignmentTypesFilterApply;
        }

        /// <summary>
        /// Click The WritingSpace Activity Cmenu Option.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void ClickTheWritingSpaceActivityCmenuOption(string activityName)
        {
            //Click The WritingSpace Activity Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage",
                       "ClickTheWritingSpaceActivityCmenuOption",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                new CourseContentUXPage().SelectFrameInWindow(GBDefaultUXPageResource.
                    GBDefaultUXPage_Gradebook_CourseHome_Window,
                    GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_Center_Frame);
                //Switch to Frame
                base.SwitchToIFrame(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Synapse_GradesFrame_Iframe_Name_Locator);
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCount(activityName);
                //Click the cmenu options
                this.ClickTheCmenuIconInGradebook(getActivityColumnCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage",
                          "ClickTheWritingSpaceActivityCmenuOption",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Activity Cmenu Option.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void ClickTheActivityCmenuOption(string activityName)
        {
            //Click The Activity Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "ClickTheActivityCmenuOption",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                new CourseContentUXPage().SelectFrameInWindow(GBDefaultUXPageResource.
                    GBDefaultUXPage_Gradebook_CourseHome_Window,
                    GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_Center_Frame);
                //Switch to Frame
                base.SwitchToIFrame(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Synapse_GradesFrame_Iframe_Name_Locator);
                //Get Activity Column Count
                int getActivityColumnCount = this.GetNormalActivityColumnCount(activityName);
                //Click the cmenu options
                this.ClickTheCmenuIconInGradebook(getActivityColumnCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ClickTheActivityCmenuOption",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Display Of WritingSpace Activity Cmenu Options.
        /// </summary>
        /// <param name="actualCmenuOption">This is Cmenu Options.</param>
        /// <returns>Cmenu options.</returns>
        public String GetDisplayOfWritingSpaceActivityCmenuOptions(string actualCmenuOption)
        {
            //Get Display Of WritingSpace Activity Cmenu Options
            logger.LogMethodEntry("GBInstructorUXPage",
                "GetDisplayOfWritingSpaceActivityCmenuOptions",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialize Activity Cmenuoptions Variable
            string getDisplayOfActivityCmenuOptions = string.Empty;
            try
            {
                //Wait for the element
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Gradebook_Cmenuoptions));
                //Get the cmenu options
                getDisplayOfActivityCmenuOptions = base.GetElementTextByXPath
                    (GBInstructorUXPageResource.
                    GBInstructorUX_Page_Gradebook_Cmenuoptions);
                if (getDisplayOfActivityCmenuOptions.Contains(actualCmenuOption))
                {
                    //Compare the cmenu options
                    getDisplayOfActivityCmenuOptions = actualCmenuOption;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage",
                "GetDisplayOfWritingSpaceActivityCmenuOptions",
                          base.IsTakeScreenShotDuringEntryExit);
            return getDisplayOfActivityCmenuOptions;
        }

        /// <summary>
        /// Click On Activity Grade Cell Cmenu.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userFirstName">This is User First Name.</param>
        /// <param name="userLastName">This is User Last Name.</param>
        public void ClickOnActivityGradeCellCmenu(
            string activityName, string userFirstName, string userLastName)
        {
            //Click On Activity Grade Cell Cmenu
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityStatus",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCount(activityName);
                //Get User Row Count
                int getUserRowCount = this.GetUserRowCount(userLastName, userFirstName);
                base.FocusOnElementByXPath(string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_ActivityStatus_Xpath_Locator,
                    getUserRowCount + Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Increment_Value), getActivityColumnCount));
                IWebElement getGradeCmenu = base.GetWebElementPropertiesByXPath(
                    string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_ActivityStatus_Xpath_Locator,
                    getUserRowCount + Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Increment_Value), getActivityColumnCount));
                //Perform Mouse Hover on Grade
                base.PerformMouseHoverAction(getGradeCmenu);
                IWebElement getGradeCellCmenu = base.GetWebElementPropertiesByXPath
                    (string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_GradeCell_Cmenu_Xpath_Locator,
                    getUserRowCount + Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Increment_Value), getActivityColumnCount));
                //Click on Grade Cell Cmenu
                base.ClickByJavaScriptExecutor(getGradeCellCmenu);
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                   GBInstructorUX_Page_WaitWindowTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityStatus",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get 'Hide For Student' Success Message.
        /// </summary>
        /// <returns>Success Message.</returns>
        public String GetHideForStudentSuccessMessage()
        {
            //Get 'Hide For Student' Success Message
            logger.LogMethodEntry("GBInstructorUXPage", "GetHideForStudentSuccessMessage",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSuccessMessage = string.Empty;
            try
            {
                //Select Window and Frame
                new CourseContentUXPage().SelectFrameInWindow(
                    GBInstructorUXPageResource.GBInstructorUX_Page_CourseHome_Window_Title,
                    GBInstructorUXPageResource.GBInstructorUX_Page_CenterFrame_Id_Locator);
                //Wait for Element
                base.WaitForElement(By.ClassName(GBInstructorUXPageResource.
                    GBInstructorUX_Page_SuccessMessage_Classname_Locator));
                //Get Success Message
                getSuccessMessage = base.GetElementTextByClassName(GBInstructorUXPageResource.
                    GBInstructorUX_Page_SuccessMessage_Classname_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetHideForStudentSuccessMessage",
            base.IsTakeScreenShotDuringEntryExit);
            return getSuccessMessage;
        }

        /// <summary>
        /// Get Grade Cell Cmenu Option.
        /// </summary>
        /// <param name="gradeCellCmenuOption">This is Grade Cell Cmenu Option.</param>
        /// <returns>Grade Cell Cmenu Option.</returns>
        public String GetGradeCellCmenuOption(string gradeCellCmenuOption)
        {
            //Get Grade Cell Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "GetGradeCellCmenuOption",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getGradeCellCmenuText = string.Empty;
            try
            {
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_GradeCellCmenu_Options_Id_Locator));
                //Get Grade Cell Cmenu Option
                getGradeCellCmenuText = base.GetElementTextById(GBInstructorUXPageResource.
                    GBInstructorUX_Page_GradeCellCmenu_Options_Id_Locator);
                if (getGradeCellCmenuText.Contains(gradeCellCmenuOption))
                {
                    getGradeCellCmenuText = gradeCellCmenuOption;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetGradeCellCmenuOption",
            base.IsTakeScreenShotDuringEntryExit);
            return getGradeCellCmenuText;
        }

        /// <summary>
        /// Click On Activity Grade Cell Cmenu In Gradebook.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userFirstName">This is User First Name.</param>
        /// <param name="userLastName">This is User Last Name.</param>
        public void ClickTheActivityGradeCellCmenuInGradebook(
            string activityName, string userFirstName, string userLastName)
        {
            //Click On Activity Grade Cell Cmenu In Gradebook
            logger.LogMethodEntry("GBInstructorUXPage",
                "ClickTheActivityGradeCellCmenuInGradebook",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCount(activityName);
                //Get User Row Count
                int getUserRowCount = this.GetUserRowCount(userLastName, userFirstName);
                base.FocusOnElementByXPath(string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_ActivityStatus_Xpath_Locator,
                    getUserRowCount, getActivityColumnCount));
                IWebElement getGradeCmenu = base.GetWebElementPropertiesByXPath(
                    string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_ActivityStatus_Xpath_Locator,
                    getUserRowCount, getActivityColumnCount));
                //Perform Mouse Hover on Grade
                base.PerformMouseHoverAction(getGradeCmenu);
                IWebElement getGradeCellCmenu = base.GetWebElementPropertiesByXPath
                    (string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_GradeCell_Cmenu_Xpath_Locator,
                    getUserRowCount, getActivityColumnCount));
                //Click on Grade Cell Cmenu
                base.ClickByJavaScriptExecutor(getGradeCellCmenu);
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.
                   GBInstructorUX_Page_WaitWindowTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage",
                "ClickTheActivityGradeCellCmenuInGradebook",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Cmenu Option Of Asset.
        /// </summary>
        /// <param name="assetCmenuOptionEnum">This is Asset cmenu options.</param>
        /// <param name="assetName">This is Asset name.</param>
        public void SelectTheCmenuOptionOfAssetInGradebook(
            AssetCmenuOptionEnum assetCmenuOptionEnum, string assetName, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select The Cmenu Option Of Asset
            logger.LogMethodEntry("GBInstructorUXPage",
                "SelectTheCmenuOptionOfAssetInGradebook",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCount(assetName);
                //Click The Cmenu Icon In Gradebook
                this.ClickTheCmenuIconInNovaNetGradebook(getActivityColumnCount);
                //Click On Cmenu Of Asset In Gradebook
                this.ClickOnCmenuOfAssetInGradebook(
                    getActivityColumnCount, assetCmenuOptionEnum, activityTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage",
                "SelectTheCmenuOptionOfAssetInGradebook",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Cmenu Icon In NovaNet Gradebook.
        /// </summary>
        /// <param name="getActivityColumnCount">This is Column count.</param>
        private void ClickTheCmenuIconInNovaNetGradebook(int getActivityColumnCount)
        {
            // Click The Cmenu Icon In Gradebook
            logger.LogMethodEntry("GBInstructorUXPage", "ClickTheCmenuIconInNovaNetGradebook",
                         base.IsTakeScreenShotDuringEntryExit);
            //Wait for the cmenu icon
            base.WaitForElement(By.XPath(String.Format(GBInstructorUXPageResource.
                GBInstructorUXPage_Gradebook_CmenuImage_Xpath_Locator, getActivityColumnCount)));
            //Get Element Property
            IWebElement getCmenuIconProperty = base.GetWebElementPropertiesByXPath
                (String.Format(GBInstructorUXPageResource.
                GBInstructorUXPage_Gradebook_CmenuImage_Xpath_Locator, getActivityColumnCount));
            base.FocusOnElementByXPath(String.Format
                (GBInstructorUXPageResource.
                GBInstructorUXPage_Gradebook_CmenuImage_Xpath_Locator, getActivityColumnCount));
            base.ClickByJavaScriptExecutor(getCmenuIconProperty);
            logger.LogMethodExit("GBInstructorUXPage", "ClickTheCmenuIconInNovaNetGradebook",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on create column drop down.
        /// </summary>
        public void ClickOnCustomColumn(CustomColumnTypeEnum customColumnType)
        {
            //Click on create column drop down
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnCustomColumn",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Gradebook Frame
                this.SelectGradebookFrameForMMND();
                //Wait for the element
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_CreateColumnDropDown_ID_Locator));
                IWebElement getColumnDropDown = base.GetWebElementPropertiesById
                    (GBInstructorUXPageResource.
                    GBInstructorUX_Page_CreateColumnDropDown_ID_Locator);
                //click on drop down
                base.ClickByJavaScriptExecutor(getColumnDropDown);

                this.SelectCustomColumn(customColumnType);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ClickOnCustomColumn",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Generic Method to select custom column
        /// </summary>
        /// <param name="customColumnType">Custom Column Type Enum</param>
        private void SelectCustomColumn(CustomColumnTypeEnum customColumnType)
        {
            //Click on create column drop down
            logger.LogMethodEntry("GBInstructorUXPage", "SelectCustomColumn",
                base.IsTakeScreenShotDuringEntryExit);
            String getCustomcolumnName = String.Empty;
            try
            {
                switch (customColumnType)
                {
                    case CustomColumnTypeEnum.Calculated:
                        {
                            getCustomcolumnName = GBInstructorUXPageResource.GBInstructorUXPage_CustomColumn_Calculated_ID_Locator;
                            break;
                        }
                    case CustomColumnTypeEnum.FreeText:
                        {
                            getCustomcolumnName = GBInstructorUXPageResource.GBInstructorUXPage_CustomColumn_FreeText_ID_Locator;
                            break;
                        }
                    case CustomColumnTypeEnum.ImportGrades:
                        {
                            getCustomcolumnName = GBInstructorUXPageResource.GBInstructorUXPage_CustomColumn_ImportGrades_ID_Locator;
                            break;
                        }
                    case CustomColumnTypeEnum.Numeric:
                        {
                            getCustomcolumnName = GBInstructorUXPageResource.GBInstructorUXPage_CustomColumn_Numeric_ID_Locator;
                            break;
                        }
                    case CustomColumnTypeEnum.SelectionList:
                        {
                            getCustomcolumnName = GBInstructorUXPageResource.GBInstructorUXPage_CustomColumn_SelectionList_ID_Locator;
                            break;
                        }
                    case CustomColumnTypeEnum.TotalColumn:
                        {
                            getCustomcolumnName = GBInstructorUXPageResource.GBInstructorUXPage_CustomColumn_TotalColumn_ID_Locator;
                            break;
                        }
                }
                //Wait for the cmenu
                base.WaitForElement(By.Id(getCustomcolumnName));
                IWebElement getCustomcolumnType = base.GetWebElementPropertiesById(getCustomcolumnName);
                base.ClickByJavaScriptExecutor(getCustomcolumnType);
                Thread.Sleep(Convert.ToInt32(GBInstructorUXPageResource.GBInstructorUX_Page_WaitWindowTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectCustomColumn",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Custom Column Name and Save in Memory
        /// </summary>
        public void EnterCalculatedColumnName()
        {
            logger.LogMethodEntry("GBInstructorUXPage", "EnterCalculatedColumnName",
                base.IsTakeScreenShotDuringEntryExit);
            String ColumnName = string.Empty;
            //Generate Custom Column Name GUID
            Guid calculatedColumnName = Guid.NewGuid();
            //Select Window            
            this.SelectCalculatedColumnWindow();
            //Enter Custom Column Title
            base.WaitForElement(By.Id(GBInstructorUXPageResource.GBInstructorUXPage_TextBox_CalculatedColumnName_ID_Locator));
            //Fill the Custom Column Name in textbox
            base.FillTextBoxById(GBInstructorUXPageResource.GBInstructorUXPage_TextBox_CalculatedColumnName_ID_Locator, calculatedColumnName.ToString());
            ColumnName = base.GetValueAttributeById(GBInstructorUXPageResource.GBInstructorUXPage_TextBox_CalculatedColumnName_ID_Locator);
            this.StoreCustomColumnInMemory(ColumnName, Activity.ActivityTypeEnum.CalculatedColumn);
            logger.LogMethodExit("GBInstructorUXPage", "EnterCalculatedColumnName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select activities from Left Iframe.  
        /// </summary>
        /// <param name="activityName">This is activity name</param>
        public void SelectActivityFromLeftFrameForCustomColumn(string activityName)
        {
            //Select activities from Left Iframe 
            logger.LogMethodEntry("GBInstructorUXPage", "SelectActivityFromLeftFrameForCustomColumn",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the total activity count
                int getActivityCount = this.GetActivityCountForCalculatedColumn();
                //Write a for loop for selecting the checkboxes
                for (int initialCount = Convert.ToInt32(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Initial_Value); initialCount <= getActivityCount;
                    initialCount++)
                {
                    if (base.IsElementPresent(By.XPath(string.Format(GBInstructorUXPageResource.
                         GBInstructorUX_Page_ActivityNameText_Xpath_Locator, initialCount)),
                         Convert.ToInt32(GBInstructorUXPageResource.
                         GBInstructorUX_Page_WaitTime_Value)))
                    {
                        string getActivityName = base.GetTitleAttributeValueByXPath(string.
                            Format(GBInstructorUXPageResource.
                             GBInstructorUX_Page_ActivityNameText_Xpath_Locator, initialCount));
                        //check for activity
                        if (getActivityName.Contains(activityName))
                        {
                            this.SelectTheActivityCheckBox(initialCount);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectActivityFromLeftFrameForCustomColumn",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Count for Calculated Column.
        /// </summary>
        /// <returns>The Total Activity count</returns>
        private int GetActivityCountForCalculatedColumn()
        {
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityCountForCalculatedColumn",
                base.IsTakeScreenShotDuringEntryExit);
            //select window
            this.SelectCalculatedColumnWindow();
            // switch to iframe
            base.SwitchToIFrame(GBInstructorUXPageResource.GBInstructorUX_Page_MyCourse_LeftFrame_ID_Locator);
            //Wait for element
            base.WaitForElement(By.XPath(GBInstructorUXPageResource.GBInstructorUX_Page_ActivityCount_Xpath_Locator));
            int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_ActivityCount_Xpath_Locator);
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityCountForCalculatedColumn",
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityCount;
        }

        /// <summary>
        /// Select Calculated Column Window
        /// </summary>
        private void SelectCalculatedColumnWindow()
        {
            //Select Calculated Column Window
            logger.LogMethodEntry("GBInstructorUXPage", "SelectCalculatedColumnWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //select the pop up window
            base.WaitUntilWindowLoads(GBInstructorUXPageResource.
                GBInstructorUXPage_CalculatedColumn_Windiw_Title);
            base.SelectWindow(GBInstructorUXPageResource.
                GBInstructorUXPage_CalculatedColumn_Windiw_Title);
            logger.LogMethodExit("GBInstructorUXPage", "SelectCalculatedColumnWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the Save button
        /// </summary>
        public void ClickOnsaveButton()
        {
            logger.LogMethodEntry("GBInstructorUXPage", "ClickOnsaveButton",
                base.IsTakeScreenShotDuringEntryExit);
            this.SelectCalculatedColumnWindow();
            //Wait for element
            base.WaitForElement(By.Id(GBInstructorUXPageResource.GBInstructorUXPage_CustomColumn_Save_Button_ID_Locator));
            IWebElement getSaveButton = base.GetWebElementPropertiesById
                    (GBInstructorUXPageResource.GBInstructorUXPage_CustomColumn_Save_Button_ID_Locator);
            //click on drop down
            base.ClickByJavaScriptExecutor(getSaveButton);

            logger.LogMethodExit("GBInstructorUXPage", "ClickOnsaveButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Store the custom column in InMemory
        /// </summary>
        /// <param name="activityName">Custom Column Name to be saved</param>
        /// <param name="activityTypeEnum">Custom Column type to be saved</param>
        private void StoreCustomColumnInMemory(String columnName,
            Activity.ActivityTypeEnum columnTypeEnum)
        {
            logger.LogMethodEntry("GBInstructorUXPage", "StoreCustomColumnInMemory",
                base.IsTakeScreenShotDuringEntryExit);

            Activity newCustomColumn = new Activity
            {
                Name = columnName,
                ActivityType = columnTypeEnum,
                IsCreated = true,
            };
            //Saves the Custom column details
            newCustomColumn.StoreActivityInMemory();

            logger.LogMethodExit("GBInstructorUXPage", "StoreCustomColumnInMemory",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Show For Student Cmenu Option.
        /// </summary>
        private void SelectTheShowForStudentCmenuOption()
        {
            //Select The Show For Student Cmenu Option
            logger.LogMethodEntry("GBInstructorUXPage", "SelectTheShowForStudentCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(GBInstructorUXPageResource.
                GBInstructorUX_Page_ShowForStudent_Cmenu_ID_Locator));
            IWebElement getSelectShowForStudentCmenuOption =
                base.GetWebElementPropertiesById(GBInstructorUXPageResource.
                GBInstructorUX_Page_ShowForStudent_Cmenu_ID_Locator);
            //Click the 'Show For Student' Cmenu Option
            base.ClickByJavaScriptExecutor(getSelectShowForStudentCmenuOption);
            logger.LogMethodExit("GBInstructorUXPage", "SelectTheShowForStudentCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Gradebook Frame for MMND.
        /// </summary>
        public void SelectGradebookFrameForMMND()
        {
            //Select the Frame
            logger.LogMethodEntry("GBInstructorUXPage", "SelectGradebookFrameForMMND",
                                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Course Home Window
                new CourseContentUXPage().SelectFrameInWindow(GBDefaultUXPageResource.
                    GBDefaultUXPage_Gradebook_CourseHome_Window,
                    GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_Center_Frame);
                //Wait for Element         
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Synapse_GradesFrame_Iframe_Name_Locator));
                //Switch to Frame
                base.SwitchToIFrame(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Synapse_GradesFrame_Iframe_Name_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectGradebookFrameForMMND",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Window Name.
        /// </summary>
        /// <param name="windowName">This is Window Name.</param>
        public void SelectTheWindowName(string windowName)
        {
            //Select The Window Name
            logger.LogMethodEntry("ContentLibraryUXPage", "SelectTheWindowName",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(windowName);
                base.SelectWindow(windowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "SelectTheWindowName",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on MyCourse in Gradebook.
        /// </summary>  
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        public void ClickonMyCourseInGradebook(User.UserTypeEnum userTypeEnum)
        {
            //Click on MyCourse in Gradebook
            logger.LogMethodEntry("GBInstructorUXPage", "ClickonMyCourseInGradebook",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.CsSmsStudent:
                        //Select Window
                        base.WaitUntilWindowLoads(GBInstructorUXPageResource.
                            GBInstructorUX_Page_Window_Title);
                        base.SelectWindow(GBInstructorUXPageResource.
                            GBInstructorUX_Page_Window_Title);
                        //Click on Back Arrow to Navigate to Root Folder
                        IWebElement getBackIconProperty =
                            base.GetWebElementPropertiesById(GBInstructorUXPageResource.
                            GBInstructorUXPage_Back_Arrow_Link_Id_Locator);
                        base.ClickByJavaScriptExecutor(getBackIconProperty);
                        break;
                    case User.UserTypeEnum.CsSmsInstructor:
                        //Select the window
                        this.SelectGradebookFrame();
                        //Click on MyCourse Link
                        IWebElement getMyCourseLink = base.GetWebElementPropertiesById(
                            GBInstructorUXPageResource.GBInstructorUXPage_MyCourse_Link_Id_Locator);
                        base.ClickByJavaScriptExecutor(getMyCourseLink);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ClickonMyCourseInGradebook",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Activity Status.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userLastName">This is User Last name.</param>
        /// <param name="userFirstName">This is User First Name.</param>
        /// <returns>Activity Status.</returns>
        public string EditActivityScoreInPegasusByBBIns(Grade.GradeTypeEnum gradeType, Activity.ActivityTypeEnum activityType, string userLastName,
            string userFirstName)
        {
            //Get the Activity Status
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityStatus",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getEditedActivityStatusGrade = string.Empty;
            try
            {
                //Get Activity Column Count
                Activity activity = Activity.Get(activityType);
                String activityName = activity.Name.ToString();
                int getActivityColumnCount = this.GetActivityColumnCount(activityName);
                //Get User Row Count
                int getUserRowCount = this.GetUserRowCount(userLastName, userFirstName);
                this.SelectGradebookFrame();
                IWebElement getGradeScore = base.GetWebElementPropertiesByXPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]",
                getUserRowCount, getActivityColumnCount));
                base.PerformMouseHoverByJavaScriptExecutor(getGradeScore);
                bool hhj12 = base.IsElementPresent(By.XPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]",
                    getUserRowCount, getActivityColumnCount)), 10);
                base.WaitForElement(By.XPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]/span",
                    getUserRowCount, getActivityColumnCount)));
                IWebElement getGrade = base.GetWebElementPropertiesByXPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]/span",
                    getUserRowCount, getActivityColumnCount));
                base.PerformMouseHoverAction(getGrade);
                IWebElement getCmenu = base.GetWebElementPropertiesByXPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]/span/span",
                    getUserRowCount, getActivityColumnCount));
                base.PerformMouseHoverByJavaScriptExecutor(getCmenu);
                bool sdwq = base.IsElementPresent(By.XPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]/span/span[2]/img",
                    getUserRowCount, getActivityColumnCount)), 10);
                IWebElement getCmenuIcon = base.GetWebElementPropertiesByXPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]/span/span[2]/img",
                    getUserRowCount, getActivityColumnCount));
                base.ClickByJavaScriptExecutor(getCmenuIcon);
                base.WaitForElement(By.Id("_ctl0_InnerPageContent_lbleditgrade1"));
                base.ClickLinkById("_ctl0_InnerPageContent_lbleditgrade1");
                // Enter the value in numerator text box
                base.WaitForElement(By.Id("txtNewValue"));
                base.ClearTextById("txtNewValue");
                base.FillTextBoxById("txtNewValue", "70");
                // Enter the value in denominator
                base.WaitForElement(By.Id("txtNewMaxValue"));
                base.ClearTextById("txtNewMaxValue");
                base.FillTextBoxById("txtNewMaxValue", "100");
                // Get the edited score
                string actualEditedScore = base.GetElementTextById("idnewpercentage");
                string scoreAfterEdit1 = actualEditedScore.Replace("[", "");
                string scoreAfterEdit2 = scoreAfterEdit1.Replace("]", "");
                getEditedActivityStatusGrade = scoreAfterEdit2.Replace("%", "");
                // Click Update button in edit score lightbox
                base.WaitForElement(By.PartialLinkText("Update"));
                base.ClickButtonByPartialLinkText("Update");
                // Store the edited score in grade enum
                new ViewSubmissionPage().StoreGradeDetails(gradeType, getEditedActivityStatusGrade);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityStatus",
            base.IsTakeScreenShotDuringEntryExit);
            return getEditedActivityStatusGrade.Trim();
        }

        /// <summary>
        /// Get the Activity Status.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userLastName">This is User Last name.</param>
        /// <param name="userFirstName">This is User First Name.</param>
        /// <returns>Activity Status.</returns>
        public string EditActivityScoreInPegasusByMoodleIns(Grade.GradeTypeEnum gradeType, Activity.ActivityTypeEnum activityType, string userLastName,
            string userFirstName)
        {
            //Get the Activity Status
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityStatus",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getEditedActivityStatusGrade = string.Empty;
            try
            {
                //Get Activity Column Count
                Activity activity = Activity.Get(activityType);
                String activityName = activity.Name.ToString();
                int getActivityColumnCount = this.GetActivityColumnCountPegasusMoodle(activityName);
                //Get User Row Count
                int getUserRowCount = this.GetUserRowCount(userLastName, userFirstName);
                base.WaitUntilWindowLoads(base.GetPageTitle);
                base.SelectWindow(base.GetPageTitle);
                IWebElement getGradeScore = base.GetWebElementPropertiesByXPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]",
                getUserRowCount, getActivityColumnCount));
                base.PerformMouseHoverByJavaScriptExecutor(getGradeScore);
                base.WaitForElement(By.XPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]/span",
                    getUserRowCount, getActivityColumnCount)));
                IWebElement getGrade = base.GetWebElementPropertiesByXPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]/span",
                    getUserRowCount, getActivityColumnCount));
                base.PerformMouseHoverAction(getGrade);
                IWebElement getCmenu = base.GetWebElementPropertiesByXPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]/span/span",
                    getUserRowCount, getActivityColumnCount));
                base.PerformMouseHoverByJavaScriptExecutor(getCmenu);
                bool sdwq = base.IsElementPresent(By.XPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]/span/span[2]",
                    getUserRowCount, getActivityColumnCount)), 10);
                IWebElement getCmenuIcon = base.GetWebElementPropertiesByXPath(string.Format("//table[@id='GBGridDataTable']/tbody/tr[{0}]/td[{1}]/span/span[2]",
                    getUserRowCount, getActivityColumnCount));
                base.PerformMouseClickAction(getCmenuIcon);
                base.WaitForElement(By.Id("_ctl0_InnerPageContent_lbleditgrade1"));
                base.ClickLinkById("_ctl0_InnerPageContent_lbleditgrade1");
                // Enter the value in numerator text box
                base.WaitForElement(By.Id("txtNewValue"));
                base.ClearTextById("txtNewValue");
                base.FillTextBoxById("txtNewValue", "70");
                // Enter the value in denominator
                base.WaitForElement(By.Id("txtNewMaxValue"));
                base.ClearTextById("txtNewMaxValue");
                base.FillTextBoxById("txtNewMaxValue", "100");
                // Get the edited score
                string actualEditedScore = base.GetElementTextById("idnewpercentage");
                string scoreAfterEdit1 = actualEditedScore.Replace("[", "");
                string scoreAfterEdit2 = scoreAfterEdit1.Replace("]", "");
                getEditedActivityStatusGrade = scoreAfterEdit2.Replace("%", "");
                // Click Update button in edit score lightbox
                base.WaitForElement(By.PartialLinkText("Update"));
                base.ClickButtonByPartialLinkText("Update");
                // Store the edited score in grade enum
                new ViewSubmissionPage().StoreGradeDetails(gradeType, getEditedActivityStatusGrade);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityStatus",
            base.IsTakeScreenShotDuringEntryExit);
            return getEditedActivityStatusGrade.Trim();
        }


        /// <summary>
        /// Validate the GradeSync icon in gradebook
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <returns>This will return the icon existance status.</returns>
        public bool GetGBSyncIconStatus(string activityName)
        {
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityStatus", base.IsTakeScreenShotDuringEntryExit);
            bool IconStatus = false;
            //Initialize VariableVariable
            string getActivityStatusGrade = string.Empty;
            //Get Activity Column Count
            int getActivityCount = base.GetElementCountByXPath("//table[@id='GBGridDataTable']/tbody/tr[2]/td");
            for (int columnCount = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); columnCount <= getActivityCount;
                columnCount++)
            {
                string getActivityName = base.GetTitleAttributeValueByXPath
                (string.Format(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTitle_Xpath_Locator, columnCount));
                if (getActivityName.Equals(activityName))
                {
                    IconStatus = base.IsElementPresent(By.XPath(string.Format("//table[@id='GBGridHeaderTable']/tbody/tr[2]/td[{0}]/div[2]/span", columnCount)), 10);
                    break;
                }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityColumnCount",
           base.IsTakeScreenShotDuringEntryExit);
            return IconStatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scenerioName"></param>
        /// <param name="userTypeEnum"></param>
        public User FetchTheUserDetails(string scenerioName, User.UserTypeEnum studentName)
        {
            //Click on MyCourse in Gradebook
            logger.LogMethodEntry("GBInstructorUXPage", "FetchTheUserDetails",
                base.IsTakeScreenShotDuringEntryExit);
            //User declaration
            User user = new User();
            switch (scenerioName)
            {
                case "ZeroScore":
                    user = User.Get(CommonResource.CommonResource
                               .SMS_STU_UC1);
                    break;
                case "IdleScore":
                    user = User.Get(CommonResource.CommonResource
                              .SMS_STU_UC2);
                    break;
            }
            logger.LogMethodExit("LoginContentPage", "FetchTheUserDetails",
             base.IsTakeScreenShotDuringEntryExit);
            return user;
        }

        /// <summary>
        /// Get Activity Column Count.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>This is Activity Column Number.</returns>
        private int GetActivityColumnCountPegasusMoodle(string activityName)
        {
            //Get Activity Column Count
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityColumnCount",
           base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            int activityColumnNumber = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Count_Value);
            base.WaitUntilWindowLoads("Gradebook");
            base.SelectWindow("Gradebook");

            base.WaitForElement(By.Id("srcGBFrame"));
            base.SwitchToIFrame("srcGBFrame");

            base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_AcitivityNames_Xpath_Locator));
            //Getting the counts of Activity                    
            int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                GBInstructorUX_Page_AcitivityNames_Xpath_Locator);
            for (int columnCount = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); columnCount <= getActivityCount;
                columnCount++)
            {
                bool sdeew = base.IsElementPresent(By.XPath(string.Format("//table[@id='GBGridHeaderTable']/tbody/tr/td[{0}]/span/span", 2)), 10);
                //Wait for Element
                base.WaitForElement(By.XPath(string.Format("//table[@id='GBGridHeaderTable']/tbody/tr/td[{0}]/span/span", columnCount)));
                base.FocusOnElementByXPath(string.Format("//table[@id='GBGridHeaderTable']/tbody/tr/td[{0}]/span/span", columnCount));
                //Getting the Activity name
                string getActivityName = base.GetTitleAttributeValueByXPath
                    (string.Format("//table[@id='GBGridHeaderTable']/tbody/tr/td[{0}]/span/span", columnCount));
                if (getActivityName.Contains(activityName))
                {
                    activityColumnNumber = columnCount;
                    break;
                }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityColumnCount",
           base.IsTakeScreenShotDuringEntryExit);
            return activityColumnNumber;
        }
    }
}

