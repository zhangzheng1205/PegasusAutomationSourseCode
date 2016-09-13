﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.ViewSubmission;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class defines the actions of right activity frame of grade.
    /// </summary>
    public class GBStudentUXPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(GBStudentUXPage));

        /// <summary>
        /// Check Grade Of Submitted Activity.
        /// </summary>
        /// <returns>Activity Score.</returns>
        public Decimal GetGradeDisplayedForActivity()
        {
            //Check Grade Of Submitted Activity
            logger.LogMethodEntry("GBStudentUXPage", "GetGradeDisplayedForActivity",
                               base.IsTakeScreenShotDuringEntryExit);
            // Initialize the gradeScore 
            decimal getActivityScore = 0;
            //Get Grade Table Row Count
            int getGradeTableRowCount = Convert.ToInt32(GBStudentUXPageResource
                .GBStudentUXPage_ActivityTable_Row_Count);
            // Search Activity Name in table rows
            string getActivityMatchedInRow = base.GetElementTextByXPath(string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Activity_Table_Xpath_Locator,
                getGradeTableRowCount));
            // Get Grades value from activity table
            getActivityScore = GetGradesValueFromActivityTable
                (getActivityMatchedInRow, getGradeTableRowCount, getActivityScore);
            // Set focus on default window
            base.SwitchToDefaultPageContent();
            base.SelectWindow(GBLeftNavigationUXPageResource
                 .GBLeftNavigationUXPage_WindowName_Title);
            logger.LogMethodExit("GBStudentUXPage", " GetGradeDisplayedForActivity",
                        base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Get Grades from the Activity table under grades tab.
        /// </summary>
        /// <param name="getActivityMatchedInRow">This Is Activity Grade Row.</param>
        /// <param name="getGradeTableRowCount">This Activity grade Table Row Count.</param>
        /// <param name="getActivityScore">This is Activity Grades Score.</param>
        /// <returns>Grade Of The Activity.</returns>
        private Decimal GetGradesValueFromActivityTable(string getActivityMatchedInRow
            , int getGradeTableRowCount, decimal getActivityScore)
        {
            //Get Grades from the Activity table under grades tab
            logger.LogMethodEntry("GBStudentUXPage", "GetGradesValueFromActivityTable",
                             base.IsTakeScreenShotDuringEntryExit);
            while (!getActivityMatchedInRow.Contains
                        (GBStudentUXPageResource.GBStudentUXPage_Activity_Title_Name))
            {
                // Incrementing the grade table row by 1
                getGradeTableRowCount = getGradeTableRowCount + 1;
                base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Activity_Table_Xpath_Locator, getGradeTableRowCount)));
                // Look for activity name in next row
                if (base.GetElementTextByXPath(string.Format(
                     GBStudentUXPageResource.GBStudentUXPage_Activity_Table_Xpath_Locator
                   , getGradeTableRowCount)).Contains
                    (GBStudentUXPageResource.GBStudentUXPage_Activity_Title_Name))
                {
                    // Get Grades from the grades value column
                    string getGrades = base.GetElementTextByXPath(string.Format
                    (GBStudentUXPageResource
                       .GBStudentUXPage_ActivityTable_GradeColumn_Xpath_Locator
                     , getGradeTableRowCount));
                    // Convert grades to decimal value
                    getActivityScore = Convert.ToDecimal(getGrades);
                    break;
                }
            }
            logger.LogMethodExit("GBStudentUXPage", " GetGradesValueFromActivityTable",
                        base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }


        /// <summary>
        /// Get Post Test Score.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Score</returns>
        public String GetPostTestScore(string activityName)
        {
            //Get Post Test Score
            logger.LogMethodEntry("GBStudentUXPage", "GetPostTestScore",
                             base.IsTakeScreenShotDuringEntryExit);
            string getActivityScore = string.Empty;
            //Variable Declaration for Studyplan Name
            string studyPlanName = GBStudentUXPageResource.
                GBStudentUXPage_Studyplan_Name;
            try
            {
                //Sleep Time To Get Frame Back Load
                Thread.Sleep(Convert.ToInt32(GBStudentUXPageResource.
                    GBStudentUXPage_SleepTime_Value));
                //Select GradeBook Window
                this.SelectGradebookWindow();
                //Navigate Inside View Grades
                this.NavigateInsideViewGrade(studyPlanName);
                Thread.Sleep(Convert.ToInt32(GBStudentUXPageResource.
                        GBStudentUXPage_SleepTime_Value));
                // Get Activity Score In Gradebook
                getActivityScore = this.GetActivityScoreInGradebook(activityName);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "GetPostTestScore",
                        base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        ///Get Activity Score In Gradebook.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Score.</returns>
        public string GetActivityScoreInGradebook(string activityName)
        {
            //Get Activity Score In Gradebook
            logger.LogMethodEntry("GBStudentUXPage", "GetActivityScoreInGradebook",
                             base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getActivityScore = string.Empty;
            try
            {              
                //Wait For Element
                base.WaitForElement(By.XPath(GBStudentUXPageResource.
                GBStudentUXPage_Activity_Table_XPath_Count_Locator));
                //Get Activity Count
                int getActivityCount = base.GetElementCountByXPath(GBStudentUXPageResource.
                    GBStudentUXPage_Activity_Table_XPath_Count_Locator);
                for (int initialCount = Convert.ToInt32(
                    GBStudentUXPageResource.GBStudentUXPage_Initial_Value);
                    initialCount <= getActivityCount; initialCount++)
                {
                    //Wait For Student Grid Element
                    WaitForElement(By.Id(GBStudentUXPageResource.
                        GBStudentUXPage_Student_Grid_Id_Locator));
                    //Wait for Activity Xpath
                    base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                        GBStudentUXPage_Activity_Name_Xpath_Locator, initialCount)));
                    //Get Activity Name
                    string getActivityName = base.GetTitleAttributeValueByXPath(
                        string.Format(GBStudentUXPageResource.
                        GBStudentUXPage_Activity_Name_Xpath_Locator, initialCount)).Trim();
                    if (getActivityName == activityName)
                    {
                        //Get Activity Score
                        getActivityScore = this.GetActivityScore(getActivityScore, initialCount).Trim();
                        Thread.Sleep(2000);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "GetActivityScoreInGradebook",
                        base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Get Activity Score .
        /// </summary>
        /// <param name="getActivityScore">This is Activity Score.</param>
        /// <returns>Activity Score Value.</returns>
        private string GetActivityScore(string getActivityScore,int initialCount)
        {
            //Get Activity Score
            logger.LogMethodEntry("GBStudentUXPage", "GetActivityScore",
                             base.IsTakeScreenShotDuringEntryExit);
            //Wait for Activity Score 
            base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                GBStudentUXPage_GetActivityScore_Xpath_Locator, initialCount)));
            //Get Activity Score
            getActivityScore = base.GetElementTextByXPath(string.Format(GBStudentUXPageResource.
                GBStudentUXPage_GetActivityScore_Xpath_Locator, initialCount).Trim());
            logger.LogMethodExit("GBStudentUXPage", "GetActivityScore",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Get Activity Test Score
        /// </summary>
        /// <param name="getActivityScore">This is Activity Score.</param>
        /// <returns>Activity Score Value.</returns>
        private string GetActivityTestScore(string getActivityScore,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Get Activity Score
            logger.LogMethodEntry("GBStudentUXPage", "GetActivityTestScore",
                             base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                          ViewSubmission_Page_Activity_Table_XPath_Count_Locator));
            //Get Activity Count
            int getActivityCount = base.GetElementCountByXPath(ViewSubmissionPageResource.
                          ViewSubmission_Page_Activity_Table_XPath_Count_Locator);
            for (int setRowCount = Convert.ToInt32(GBStudentUXPageResource.GBStudentUXPage_Initial_Value);
                setRowCount <= getActivityCount; setRowCount++)
            {
                //Wait for Activity Xpath
                base.WaitForElement(By.XPath(string.Format(ViewSubmissionPageResource.
                   ViewSubmission_Page_Activity_Name_Xpath_Locator, setRowCount)));
                //Get Activity Name
                string getActivityName = base.GetElementTextByXPath
                    (string.Format(ViewSubmissionPageResource.
                                       ViewSubmission_Page_Activity_Name_Xpath_Locator, setRowCount));
                if (getActivityName == activityTypeEnum.ToString())
                {
                    //Wait for Activity Score 
                    base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                        GBStudentUXPage_Activity_Test_Score_Xpath_Locator, setRowCount)));
                    //Get Activity Score
                    getActivityScore = base.GetElementTextByXPath(string.Format(GBStudentUXPageResource.
                        GBStudentUXPage_Activity_Test_Score_Xpath_Locator, setRowCount)).Trim();
                    break;
                }
            }
            logger.LogMethodExit("GBStudentUXPage", "GetActivityTestScore",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Select GradeBook Window.
        /// </summary>
        public void SelectGradebookWindow()
        {
            //Select Gradebook Window
            logger.LogMethodEntry("GBStudentUXPage", "SelectGradebookWindow",
                             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Gradebook Window
                base.WaitUntilWindowLoads(GBStudentUXPageResource.
                    GBStudentUXPage_Gradebook_Name_Locator);
                base.SelectWindow(GBStudentUXPageResource.
                    GBStudentUXPage_Gradebook_Name_Locator);
                //Wait for Frame
                base.WaitForElement(By.Id(GBStudentUXPageResource.
                    GBStudentUXPage_ActivityFrame_Id_Locator));
                base.SwitchToIFrame(GBStudentUXPageResource.
                    GBStudentUXPage_ActivityFrame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", " SelectGradebookWindow",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside Activity Folder To View Grade.
        /// </summary>        
        public void NavigateInsideViewGrade(string studyPlanName)
        {
            logger.LogMethodEntry("GBStudentUXPage", " NavigateInsideViewGrade",
                       base.IsTakeScreenShotDuringEntryExit);
            //Variable Declaration of Assets     
            string getAssetNameName = string.Empty;
            try
            {              
                //Get Assets Count               
                int getAssetCount = base.GetElementCountByXPath(GBStudentUXPageResource.
                    GBStudentUXPage_Studyplanasset_RowCount_Xpath_Locator);
                for (int setRowCount = Convert.ToInt32(GBStudentUXPageResource.
                    GBStudentUXPage_Initial_Value); setRowCount <= getAssetCount; setRowCount++)
                {
                    //Get Asset Name                      
                    getAssetNameName = base.GetElementTextByXPath(string.Format
                        (GBStudentUXPageResource.GBStudentUXPage_Studyplanasset_Name_Xpath_Locator,
                        setRowCount));
                    if (getAssetNameName.Contains(studyPlanName))
                    {
                        //Wait for the element
                        base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                            GBStudentUXPage_Studyplanasset_Name_ViewGrade_Xpath_Locator, setRowCount)));
                        IWebElement getAssetName = base.GetWebElementPropertiesByXPath
                            (string.Format(GBStudentUXPageResource.
                            GBStudentUXPage_Studyplanasset_Name_ViewGrade_Xpath_Locator, setRowCount));
                        //Click on View Grade
                        base.ClickByJavaScriptExecutor(getAssetName);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", " NavigateInsideViewGrade",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Manually Graded Score
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        /// <returns>Manually Graded Score</returns>
        public String GetManuallyGradedScore(string activityName)
        {
            //Get Manually Graded Score
            logger.LogMethodEntry("GBStudentUXPage", "GetManuallyGradedScore",
                       base.IsTakeScreenShotDuringEntryExit);
            //Initialize getManuallyGradedScore Variable
            string getManuallyGradedScore = string.Empty;
            try
            {
                //Select Frame
                this.SelectGradebookWindow();
                base.WaitForElement(By.XPath(GBStudentUXPageResource.
                    GBStudentUXPage_Activity_Table_XPath_Count_Locator));
                //Get Activity Count
                int getActivityCount = GetElementCountByXPath(GBStudentUXPageResource.
                    GBStudentUXPage_Activity_Table_XPath_Count_Locator);
                for (int initialCount = Convert.ToInt32(GBStudentUXPageResource.
                    GBStudentUXPage_Initial_Value); initialCount < getActivityCount; initialCount++)
                {
                    //Wait for Activity 
                    base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                        GBStudentUXPage_GetActivityName_XPath_Locator, initialCount)));
                    //Get Activity Name
                    string getActivityName = base.GetTitleAttributeValueByXPath
                        (string.Format(GBStudentUXPageResource.
                        GBStudentUXPage_GetActivityName_XPath_Locator, initialCount).Trim());
                    if (getActivityName.Contains(activityName))
                    {
                        //Get Manually Graded Score
                        getManuallyGradedScore = base.GetTitleAttributeValueByXPath(string.Format(
                            GBStudentUXPageResource.GBStudentUXPage_GetActivityScore_Xpath_Locator,
                            initialCount)).Trim();
                        break;
                    }
                }
                base.SelectWindow(GBStudentUXPageResource.
                    GBStudentUXPage_Gradebook_Name_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "GetManuallyGradedScore",
                    base.IsTakeScreenShotDuringEntryExit);
            return getManuallyGradedScore;
        }
      
        /// <summary>
        /// Click The Asset Cmenu In Grade Tab
        /// </summary>
        /// <param name="activityTypeEnum">This is Asset type enum</param>
        public void VerifyTheAssetNameInGradeTab(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click The Asset Cmenu In Grade Tab
            logger.LogMethodEntry("GBStudentUXPage", "VerifyTheAssetNameInGradeTab",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                              ViewSubmission_Page_Activity_Table_XPath_Count_Locator));
                //Get Activity Count
                int getActivityCount = base.GetElementCountByXPath(ViewSubmissionPageResource.
                              ViewSubmission_Page_Activity_Table_XPath_Count_Locator);
                for (int setRowCount = 1; setRowCount <= getActivityCount; setRowCount++)
                {
                    //Wait for Activity Xpath
                    base.WaitForElement(By.XPath(string.Format(ViewSubmissionPageResource.
                       ViewSubmission_Page_Activity_Name_Xpath_Locator, setRowCount)));
                    //Get Activity Name
                    string getActivityName = base.GetElementTextByXPath
                        (string.Format(ViewSubmissionPageResource.
                                           ViewSubmission_Page_Activity_Name_Xpath_Locator, setRowCount));
                    if (getActivityName == activityTypeEnum.ToString())
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "VerifyTheAssetNameInGradeTab",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Score Result In GradeBook Page.
        /// </summary>
        /// <param name="activityTypeEnum">This is Asset type by enum.</param>
        /// <returns>Activity Grade Value</returns>
        public string GetScoreResultInGradeBookPage(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Get Score Result In GradeBook Page
            logger.LogMethodEntry("GBStudentUXPage", "GetScoreResultInGradeBookPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Intialize the activity grade variable
            string getActivityGrade = string.Empty;
            try
            {
                switch (activityTypeEnum)
                {
                    //Check grade for Studyplan 
                    case Activity.ActivityTypeEnum.StudyPlan:
                        //Get Activity Score
                        getActivityGrade = this.GetActivityScore(getActivityGrade, 
                            Convert.ToInt32(GBStudentUXPageResource.GBStudentUXPage_Initial_Value));
                        break;
                    //Check the grade for Test
                    case Activity.ActivityTypeEnum.Test:
                        getActivityGrade = this.GetActivityTestScore(getActivityGrade, activityTypeEnum);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "GetScoreResultInGradeBookPage",
                  base.IsTakeScreenShotDuringEntryExit);
            return getActivityGrade;
        }

        /// <summary>
        /// Verify AssetName And Triangle Cmenu In Grade Tab
        /// </summary>
        /// <param name="activityTypeEnum">This is Asset type enum</param>
        public void VerifyAssetNameAndClickTriangleOptionCmenu(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify AssetName And Triangle Cmenu In Grade Tab
            logger.LogMethodEntry("GBStudentUXPage", "VerifyAssetNameAndClickTriangleOptionCmenu",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Element
                base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                              ViewSubmission_Page_Activity_Table_XPath_Count_Locator));
                //Get Activity Count
                int getActivityCount = base.GetElementCountByXPath(ViewSubmissionPageResource.
                              ViewSubmission_Page_Activity_Table_XPath_Count_Locator);
                for (int setRowCount = Convert.ToInt32(GBStudentUXPageResource.GBStudentUXPage_Initial_Value);
                    setRowCount <= getActivityCount; setRowCount++)
                {
                    //Wait for Activity Xpath
                    base.WaitForElement(By.XPath(string.Format(ViewSubmissionPageResource.
                       ViewSubmission_Page_Activity_Name_Xpath_Locator, setRowCount)));
                    //Get Activity Name
                    string getActivityName = base.GetElementTextByXPath
                        (string.Format(ViewSubmissionPageResource.
                           ViewSubmission_Page_Activity_Name_Xpath_Locator, setRowCount));
                    if (getActivityName == activityTypeEnum.ToString())
                    {  // Activity Name "HomeWork"
                        if (getActivityName == Convert.ToString(Activity.ActivityTypeEnum.HomeWork))
                        {   //Click on HomeWork Triangle Option Cmenu
                            this.ClickHomeWorkTraingleImage();
                            break;
                        }
                        else//Click on Test Triangle Option Cmenu
                        {
                            new ViewSubmissionPage().ClickTheTestTraingleOptionCmenu(setRowCount);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "VerifyAssetNameAndClickTriangleOptionCmenu",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Course Materials Text.
        /// </summary>
        /// <returns>Returns CourseMaterials Text.</returns>
        public String GetCourseMaterailsText()
        {
            logger.LogMethodEntry("GBStudentUXPage", "GetCourseMaterailsText",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize string Variable
            string getCourseMaterailsText = string.Empty;
            try {
                //Wait For Gradebook Window
                base.SelectWindow(GBStudentUXPageResource.
                GBStudentUXPage_Gradebook_Name_Locator);
                //Wait For Left Frame(Course Materials)
                base.WaitForElement(By.Id(GBStudentUXPageResource.
                GBStudentUXPage_LeftIframe_Id_Locator));
                //Switch to Left Frame
                base.SwitchToIFrame(GBStudentUXPageResource.
                GBStudentUXPage_LeftIframe_Id_Locator);
                // Wait For Grades Leftframe name
                base.WaitForElement(By.Id(GBStudentUXPageResource.
                    GBStudentUXPage_Coursematerials_Text_Id_Locator));
                // Get Grades Leftframe Course Materails 
                getCourseMaterailsText = base.GetElementTextById
                    (GBStudentUXPageResource.
                    GBStudentUXPage_Coursematerials_Text_Id_Locator);
            }
            catch (Exception e) { ExceptionHandler.HandleException(e); }
            logger.LogMethodExit("GBStudentUXPage", "GetCourseMaterailsText",
                base.IsTakeScreenShotDuringEntryExit);
            return getCourseMaterailsText;
        }

        /// <summary>
        /// Get Activity Column Text
        /// </summary>
        /// <returns>Returns Activity Column Text</returns>
        public String GetActivityColumnText(string Items)
        {
            logger.LogMethodEntry("GBStudentUXPage", "GetActivityColumnText",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize string Variable
            string getActivityColumnText = string.Empty;
            try  {
                //Student Grades tab Right Frame
                this.LoadStudentGradesInRightFrame();
                 // Get Grades Rightframe Activity Column
                if (Items == GBStudentUXPageResource.
                    GBStudentUXPage_AllItems_Name) //All  Items
                {
                    getActivityColumnText = base.GetElementTextByXPath(
                     GBStudentUXPageResource.
                     GBStudentUXPage_Activity_Text_XPath_Locator).Trim();
                }
                else //Assigned Items OR Completed Items
                {
                    getActivityColumnText = base.GetElementTextByXPath(
                    GBStudentUXPageResource.
                    GBStudentUXPage_Assigneditems_Activity_Text_XPath_Locator)
                    .Trim();
                }
            }
            catch (Exception e) { ExceptionHandler.HandleException(e); }
            logger.LogMethodExit("GBStudentUXPage", "GetActivityColumnText",
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityColumnText;
        }

        //Click On Completed items
        public void ClickOnCompletedItems()
        {
            logger.LogMethodEntry("GBStudentUXPage", "ClickOnCompletedItems",
                base.IsTakeScreenShotDuringEntryExit);
            try{
                //Student Grades tab Right Frame
                this.LoadStudentGradesInRightFrame();
                base.WaitForElement(By.Id(GBStudentUXPageResource.
                    GBStudentUXPage_Completeditems_Id_Locator));
                //Get Completed items Link 
                IWebElement getCompletedItemsProperty = base.
                    GetWebElementPropertiesById(GBStudentUXPageResource.
                    GBStudentUXPage_Completeditems_Id_Locator);
                //Click On Completeditems Link
                base.ClickByJavaScriptExecutor(getCompletedItemsProperty); 
            }
            catch (Exception e) { ExceptionHandler.HandleException(e); }
            logger.LogMethodExit("GBStudentUXPage", "ClickOnCompletedItems",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //Click On Assigned items
        public void ClickOnAssignedItems()
        {
            logger.LogMethodEntry("GBStudentUXPage", "ClickOnAssignedItems",
                base.IsTakeScreenShotDuringEntryExit);
            try{
                //Student Grades tab Right Frame
                this.LoadStudentGradesInRightFrame();
                //Wait for Assigned Items Element
                base.WaitForElement(By.Id(GBStudentUXPageResource.
                    GBStudentUXPage_AssignedItems_Id_Locator));
                //Get Assigned items Link
                IWebElement getAssignedItemsProperty = base.
                    GetWebElementPropertiesById(GBStudentUXPageResource.
                    GBStudentUXPage_AssignedItems_Id_Locator);
                //Click On Assigneditems Link
                base.ClickByJavaScriptExecutor(getAssignedItemsProperty);
            }
            catch (Exception e) { ExceptionHandler.HandleException(e); }
            logger.LogMethodExit("GBStudentUXPage", "ClickOnAssignedItems",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// Load Student Grades tab Right Frame
        private void LoadStudentGradesInRightFrame()
        {
            logger.LogMethodEntry("GBStudentUXPage", "LoadStudentGradesInRightFrame",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait For Gradebook Window
            base.SelectWindow(GBStudentUXPageResource.
            GBStudentUXPage_Gradebook_Name_Locator);
            //Wait For Right Frame (All Items display)
            base.WaitForElement(By.Id(GBStudentUXPageResource.
                GBStudentUXPage_ActivityFrame_Id_Locator));
            //Switch to Right Frame (All Items display)
            base.SwitchToIFrame(GBStudentUXPageResource.
                GBStudentUXPage_ActivityFrame_Id_Locator);
            logger.LogMethodExit("GBStudentUXPage", "LoadStudentGradesInRightFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        //Click On HomeWork Traingle Cmenu Image
        private void ClickHomeWorkTraingleImage()
        {
            logger.LogMethodEntry("GBStudentUXPage", "ClickHomeWorkTraingleImage",
                 base.IsTakeScreenShotDuringEntryExit);
                base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                     GBStudentUXPage_HomeWork_Cmenu_Option_Name_Xpath_Locator)));
                //Title Attribute  "HomeWork" on the First Row in Gradebook
                IWebElement getTitleAttribute=base.GetWebElementPropertiesByXPath(
                     GBStudentUXPageResource.
                     GBStudentUXPage_HomeWork_Cmenu_Option_Name_Xpath_Locator);
                 //Perform mouse over action on "HomeWork" aseet
                base.PerformMouseHoverByJavaScriptExecutor(getTitleAttribute);
                base.WaitForElement(By.XPath(GBStudentUXPageResource.
                     GBStudentUXPage_HomeWork_Cmenu_Option_Name_Xpath_Locator));
                //Get Web Element Property
                IWebElement getTraingleButton = base.GetWebElementPropertiesByXPath((
                        GBStudentUXPageResource.
                     GBStudentUXPage_HomeWork_Cmenu_Option_Name_Xpath_Locator));
                //Click on the "HomeWork" cmenu option
                base.ClickByJavaScriptExecutor(getTraingleButton);
                //Get Web Element Property
                IWebElement getViewReportOption = base.
                    GetWebElementPropertiesByXPath(GBStudentUXPageResource.
                    GBStudentUXPage_HomeWork_Cmenu_Option_ViewReport_Xpath_Locator);
                //Click on View Report Cmenu Option
                base.ClickByJavaScriptExecutor(getViewReportOption);
            logger.LogMethodExit("GBStudentUXPage", "ClickHomeWorkTraingleImage",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check Columns Displayed in Gradebook.
        /// </summary>
        /// <returns>Column Name Displayed</returns>
        public bool IsColumnsDisplayedInGradebook()
        {
            //Check Columns Displayed in Gradebook
            logger.LogMethodEntry("GBStudentUXPage", "IsColumnsDisplayedInGradebook",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialze Variable
            bool isColumnsDisplayed = false;
            try
            {
                //Select the window
                this.SelectGradebookWindow();
                // Activity colunm text displayed
                bool isActivityDisplayed = base.IsElementPresent(By.ClassName(
                    GBStudentUXPageResource.GBStudentUXPage_Student_Activity_Displayed_Classname));
                // Grade colunm text displayed
                bool isGradeDisplayed = base.IsElementPresent(By.ClassName(
                    GBStudentUXPageResource.GBStudentUXPage_Student_Grade_Displayed_Classname));                
                isColumnsDisplayed = isActivityDisplayed && 
                    isGradeDisplayed;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "IsColumnsDisplayedInGradebook",
              base.IsTakeScreenShotDuringEntryExit);
            return isColumnsDisplayed;
        }

        /// <summary>
        /// Check Filter options Displayed in Gradebook
        /// </summary>
        /// <returns>Filter columns displayed</returns>
        public Boolean IsFilterOptionsDisplayedInGradebook()
        {
            //Check Filter options Displayed in Gradebook
            logger.LogMethodEntry("GBStudentUXPage", "IsFilterOptionsDisplayedInGradebook",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialze Variable
            bool isFilterColumnsDisplayed = false;
            try
            {
                //Select the window
                this.SelectGradebookWindow();
                // All Items filter colunm text displayed
                bool isAllItemsDisplayed = base.IsElementPresent(By.Id(
                    GBStudentUXPageResource.GBStudentUXPage_Student_AllItem_Displayed_Classname));
                // Completed Items filter colunm text displayed
                bool isCompletedFilterDisplayed = base.IsElementPresent(By.Id(
                 GBStudentUXPageResource.GBStudentUXPage_Student_CompletedFilter_Displayed_Classname));
                // Assigned Items filter colunm text displayed
                bool isAssignedItemsDisplayed = base.IsElementPresent(By.Id(
                    GBStudentUXPageResource.GBStudentUXPage_Student_AssignedItems_Displayed_Classname));
                isFilterColumnsDisplayed = isAllItemsDisplayed && 
                    isCompletedFilterDisplayed && isAssignedItemsDisplayed;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "IsFilterOptionsDisplayedInGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            return isFilterColumnsDisplayed;
        }

        /// <summary>
        /// Select Student Folder Navigation Frame. 
        /// </summary>
        public void SelectStudentFolderNavigationFrame()
        {
            //Select Student Folder Navigation Frame
            logger.LogMethodEntry("GBStudentUXPage", "SelectStudentFolderNavigationFrame",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Gradebook Window
                base.WaitUntilWindowLoads(GBStudentUXPageResource.
                    GBStudentUXPage_Gradebook_Name_Locator);
                base.SelectWindow(GBStudentUXPageResource.
                    GBStudentUXPage_Gradebook_Name_Locator);
                //Wait for the element
                base.WaitForElement(By.Id(GBFoldersPageResource.
                       GBFolders_Page_Student_FolderNavigation_Frame));
                //Select Frame
                base.SwitchToIFrame(GBFoldersPageResource.
                    GBFolders_Page_Student_FolderNavigation_Frame);
            }
            catch (Exception e)
            {
             ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "SelectStudentFolderNavigationFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Folder navigation Frame Displayed In Gradebook
        /// </summary>
        /// <returns>Folder navigation frame</returns>
        public Boolean IsFoldernavigationFrameDisplayedInGradebook()
        {
            //Folder navigation Frame Displayed In Gradebook
            logger.LogMethodEntry("GBStudentUXPage", "IsFoldernavigationFrameDisplayedInGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialze Variable
            bool isFolderNavigationFrameDisplayed = false;
            try
            {
                //Select the window
                base.SelectWindow(GBStudentUXPageResource.
                       GBStudentUXPage_Gradebook_Name_Locator);
                isFolderNavigationFrameDisplayed = base.IsElementPresent(By.Id(
                    GBFoldersPageResource.GBFolders_Page_Student_FolderNavigation_Frame));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }       
            logger.LogMethodExit("GBStudentUXPage", "IsFoldernavigationFrameDisplayedInGradebook",
              base.IsTakeScreenShotDuringEntryExit);
            return isFolderNavigationFrameDisplayed;
        }

        /// <summary>
        /// Filter DropDown Displayed In Gradebook
        /// </summary>
        /// <returns>Filter drop down</returns>
        public Boolean IsFilterDropDownDisplayedInGradebook()
        {
            //Filter DropDown Displayed In Gradebook
            logger.LogMethodEntry("GBStudentUXPage", "IsFilterDropDownDisplayedInGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialze Variable
            bool isFilterDropdownDisplayed = false;
            try
            {
                //Select gradebook window
                this.SelectGradebookWindow();
                isFilterDropdownDisplayed = base.IsElementPresent(By.Id(GBStudentUXPageResource.
                    GBStudentUXPage_Student_FilterDropdown_Displayed_Classname));
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "IsFilterDropDownDisplayedInGradebook",
              base.IsTakeScreenShotDuringEntryExit);
            return isFilterDropdownDisplayed;
        }

        /// <summary>
        /// Select Option From Filter Content Type DropDown.
        /// </summary>
        /// <param name="activityType">This is Activity Type</param>
        public void SelectOptionFromFilterContentTypeDropDown(string activityType)
        {
            //Select Option From Filter Content Type DropDown.
            logger.LogMethodEntry("GBStudentUXPage", 
                "SelectOptionFromFilterContentTypeDropDown",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select gradebook window
                this.SelectGradebookWindow();
                base.WaitForElement(By.Name(GBStudentUXPageResource.
                    GBStudentUXPage_Gradebook_Filterdropdown_Name));
                Thread.Sleep(Convert.ToInt32(GBStudentUXPageResource.
                    GBStudentUXPage_SleepTime_Value));
                //Select dropdown value 
                base.SelectDropDownValueThroughTextByName
                   (GBStudentUXPageResource.
                    GBStudentUXPage_Gradebook_Filterdropdown_Name, activityType);
            }
            catch (Exception e)
            {
             ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", 
                "SelectOptionFromFilterContentTypeDropDown",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Asset Name In Gradebook.
        /// </summary>
        /// <param name="activityName"></param>
        /// <returns>Asset name</returns>
        public string VerifyTheAssetNameInGradebook(string activityName)
        {
            //Verify The Asset Name In Gradebook
            logger.LogMethodEntry("GBStudentUXPage", "VerifyTheAssetNameInGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getActivityName = string.Empty;
            try
            {
                this.SelectGradebookWindow();                  
                //Wait For Element
                base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                              ViewSubmission_Page_Activity_Table_XPath_Count_Locator));
                //Get Activity Count
                int getActivityCount = base.GetElementCountByXPath(ViewSubmissionPageResource.
                              ViewSubmission_Page_Activity_Table_XPath_Count_Locator);
                for (int setRowCount = 1; setRowCount <= getActivityCount; setRowCount++)
                {                    
                    //Wait for Activity Xpath
                    base.WaitForElement(By.XPath(string.Format(ViewSubmissionPageResource.
                       ViewSubmission_Page_Activity_Name_Xpath_Locator, setRowCount)));
                    //Get Activity Name
                     getActivityName = base.GetTitleAttributeValueByXPath
                        (string.Format(ViewSubmissionPageResource.
                                ViewSubmission_Page_Activity_Name_Xpath_Locator, setRowCount));
                     if (getActivityName.Contains(activityName))
                    {
                       getActivityName=getActivityName.TrimStart();
                        break;                       
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "VerifyTheAssetNameInGradebook",
             base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary> 
        /// Get Activity Rowcount In Gradebook.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Rowcount.</returns>
        private int GetActivityRowcountInGradebook(string activityName)
        {
            //Get The Grades For Activity In Gradebook
            logger.LogMethodEntry("GBStudentUXPage",
                "GetActivityRowcountInGradebook",
                             base.IsTakeScreenShotDuringEntryExit);
            //Intialize the variable
            int getActivityCount = Convert.ToInt32(GBStudentUXPageResource.
                GBStudentUXPage_Rowcount_Initial_Value); 
            //Wait For Element
            base.WaitForElement(By.XPath(GBStudentUXPageResource.
               GBStudentUXPage_Activity_Table_XPath_Count_Locator));
            //Get Activity Count
            getActivityCount = base.GetElementCountByXPath(GBStudentUXPageResource.
                GBStudentUXPage_Activity_Table_XPath_Count_Locator);
            for (int initialCount = Convert.ToInt32(GBStudentUXPageResource.
                GBStudentUXPage_Initial_Value);
                initialCount <= getActivityCount; initialCount++)
            {
                //Wait for Activity Xpath
                base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                    GBStudentUXPage_Activity_Name_Xpath_Locator, initialCount)));
                //Get Activity Name
                string getActivityName = base.GetTitleAttributeValueByXPath(string.Format
                    (GBStudentUXPageResource.
                    GBStudentUXPage_Activity_Name_Xpath_Locator, initialCount));
                if (getActivityName.Contains(activityName))
                {
                    getActivityCount = initialCount;
                    break;
                }
            }  
            logger.LogMethodExit("GBStudentUXPage",
                "GetActivityRowcountInGradebook",
                        base.IsTakeScreenShotDuringEntryExit);
            return getActivityCount;
        }

        /// <summary>
        /// Click On Activity Cmenu In GradeBook.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="cmenuOption">This is Cmenu Option.</param>
        public void ClickOnActivityCmenuInGradeBook(string activityName, string cmenuOption)
        {
            //Click On Activity Cmenu In GradeBook
            logger.LogMethodEntry("GBStudentUXPage", "ClickOnActivityCmenuInGradeBook",
                            base.IsTakeScreenShotDuringEntryExit);
            //Intialize the variable
            int getRowCount = Convert.ToInt32(GBStudentUXPageResource.
                GBStudentUXPage_Rowcount_Initial_Value);           
            try
            {
                //Select GradeBook Window
                this.SelectGradebookWindow();
                //Get Activity Score
                getRowCount = this.GetActivityRowcountInGradebook(activityName);
                //Get Activity Score
                this.ClickTheCmenuOfActivityInGradeBook(getRowCount, cmenuOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "ClickOnActivityCmenuInGradeBook",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Asset Name In GradeBook.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Score.</returns>
        public String GetAssetScoreInGradeBook(string activityName)
        {
            //Get Asset Name In GradeBook
            logger.LogMethodEntry("GBStudentUXPage", "GetAssetScoreInGradeBook",
                             base.IsTakeScreenShotDuringEntryExit);
            //Intialize the variable
            string getActivityScore = string.Empty;
            int getRowCount = Convert.ToInt32(GBStudentUXPageResource.
                GBStudentUXPage_Rowcount_Initial_Value); 
            try
            {
                //Get Activity Score
                getRowCount = this.GetActivityRowcountInGradebook(activityName);
                //Get Activity Score
                getActivityScore = this.GetActivityGrade(getRowCount).Trim();
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "GetAssetScoreInGradeBook",
                       base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Get Activity Grade.
        /// </summary>
        /// <param name="initialCount">This is Activity Count.</param>
        /// <returns>Activity Score.</returns>
        private string GetActivityGrade(int initialCount)
        {
            //Get Activity Grade
            logger.LogMethodEntry("GBStudentUXPage", "GetActivityGrade",
                             base.IsTakeScreenShotDuringEntryExit);
            //Initialize the variable
            string getActivityScore = string.Empty;
            //Wait for Activity Score 
            base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Activity_Grade_Displayed_Xpath_Locator, initialCount)));
            //Get Activity Score
            getActivityScore = base.GetElementTextByXPath(string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Activity_Grade_Displayed_Xpath_Locator, initialCount));
            logger.LogMethodExit("GBStudentUXPage", "GetActivityGrade",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }
        
        /// <summary>
        /// Click The Cmenu Of Activity In GradeBook.
        /// </summary>
        /// <param name="getRowCount">This is RowCount.</param>
        /// /// <param name="cmenuOption">This is Cmenu Option.</param>
        private void ClickTheCmenuOfActivityInGradeBook(int getRowCount, string cmenuOption)
        {
            //Click The Cmenu Of Activity In GradeBook
            logger.LogMethodEntry("GBStudentUXPage", "ClickTheCmenuOfActivityInGradeBook",
                             base.IsTakeScreenShotDuringEntryExit);
            //Initialize the variable
            string getActivityScore = string.Empty;
            //Wait for Activity Score 
            base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Studyplanasset_Name_Xpath_Locator, getRowCount)));
            base.FocusOnElementByXPath(string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Studyplanasset_Name_Xpath_Locator, getRowCount));
            IWebElement getAssetName = base.GetWebElementPropertiesByXPath
                (string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Studyplanasset_Name_Xpath_Locator, getRowCount));
            //Perform Mouseover Action
            base.PerformMouseHoverByJavaScriptExecutor(getAssetName);
            Thread.Sleep(Convert.ToInt32(GBStudentUXPageResource.
                GBStudentUXPage_SleepTime_Value));
            //Wait for Activity Score 
            base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Asset_CmenuImage_Xpath_Locator, getRowCount)));
            IWebElement getCmenu = base.GetWebElementPropertiesByXPath
                (string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Asset_CmenuImage_Xpath_Locator, getRowCount));
            base.ClickByJavaScriptExecutor(getCmenu);
            //Wait for the element
            base.WaitForElement(By.PartialLinkText(cmenuOption));
            IWebElement getViewSubmissionLink = base.GetWebElementPropertiesByPartialLinkText
                (cmenuOption);
            //Click the 'View Submission' link
            base.ClickByJavaScriptExecutor(getViewSubmissionLink); 
            logger.LogMethodExit("GBStudentUXPage", "ClickTheCmenuOfActivityInGradeBook",
                    base.IsTakeScreenShotDuringEntryExit);           
        }

        /// <summary>
        /// Click On Activity Cmenu Option In GradeBook Of Student.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="cmenuOption">This is Cmenu Option.</param>
        public void ClickOnActivityCmenuOptionInGradeBookOfStudent(
            string activityName,string cmenuOption)
        {
            //Click On Activity Cmenu Option In GradeBook Of Student
            logger.LogMethodEntry("GBStudentUXPage", 
                "ClickOnActivityCmenuOptionInGradeBookOfStudent",
                             base.IsTakeScreenShotDuringEntryExit);
            //Intialize the variable
            int getRowCount = Convert.ToInt32(GBStudentUXPageResource.
                GBStudentUXPage_Rowcount_Initial_Value);
            try
            {
                //Get Activity Score
                getRowCount = this.GetActivityRowcountInGradebook(activityName);
                //Click On Cmenu Option of Activity In Gradebook
                this.ClickTheCmenuOfActivityInGradeBook(getRowCount, cmenuOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage",
                "ClickOnActivityCmenuOptionInGradeBookOfStudent",
                   base.IsTakeScreenShotDuringEntryExit);  
        }
        
        /// <summary>
        /// Get Asset Name In Gradebook.
        /// </summary>
        /// <param name="activtyName">This is Activity Name.</param>
        /// <returns>Activity Name.</returns>
        public String GetAssetNameInGradebook(string activtyName)
        {
            //Get Asset Name In Gradebook
            logger.LogMethodEntry("GBStudentUXPage", "GetAssetNameInGradebook",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize string varialbe 
            string getAssetNameInGradebook = string.Empty;
            try
            {
                //Get Asset Name
               getAssetNameInGradebook = new ContentLibraryUXPage().
                   GetTheDisplayOfActivityName(activtyName,
                   GBStudentUXPageResource.
                    GBStudentUXPage_Verify_GardebookActivity_Xpath_Locator);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage", "GetAssetNameInGradebook",
                base.IsTakeScreenShotDuringEntryExit);            
            return getAssetNameInGradebook;
        }

        /// <summary>
        /// Click On Writingspace Activity Cmenu For Student.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void ClickOnWritingspaceActivityCmenuForStudent(string activityName)
        {
            //Click On Writingspace Activity Cmenu For Student
            logger.LogMethodEntry("GBStudentUXPage",
                "ClickOnWritingspaceActivityCmenuForStudent",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {                
                //Get Activity Score
                int getRowCount = this.GetActivityRowcountInGradebook(activityName);
                //Mouse hover and Click on Activity Cmenu
                this.MousehoverandClickonActivityCmenu(getRowCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage",
                "ClickOnWritingspaceActivityCmenuForStudent",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Mouse hover and Click on Activity Cmenu.
        /// </summary>
        /// <param name="getRowCount">This is Activity Rowcount.</param>
        private void MousehoverandClickonActivityCmenu(int getRowCount)
        {
            //Mouse hover and Click on Activity Cmenu
            logger.LogMethodEntry("GBStudentUXPage",
                "MousehoverandClickonActivityCmenu",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait for an Element
            base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Studyplanasset_Name_Xpath_Locator, getRowCount)));
            IWebElement getAssetName = base.GetWebElementPropertiesByXPath
                (string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Studyplanasset_Name_Xpath_Locator, getRowCount));
            //Perform Mouseover Action
            base.PerformMouseHoverByJavaScriptExecutor(getAssetName);
            Thread.Sleep(Convert.ToInt32(GBStudentUXPageResource.
                GBStudentUXPage_SleepTime_Value));
            //Wait for an Element
            base.WaitForElement(By.XPath(string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Asset_CmenuImage_Xpath_Locator, getRowCount)));
            //Click on Activity Cmenu
            IWebElement getCmenu = base.GetWebElementPropertiesByXPath
                (string.Format(GBStudentUXPageResource.
                GBStudentUXPage_Asset_CmenuImage_Xpath_Locator, getRowCount));
            base.ClickByJavaScriptExecutor(getCmenu);
            logger.LogMethodExit("GBStudentUXPage",
                "MousehoverandClickonActivityCmenu",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Cmenu Option In Student Gradebook.
        /// </summary>   
        /// <param name="activityCmenu">This is Activity Cmenu.</param>
        /// <returns>Cmenu Option.</returns>
        public String GetActivityCmenuOptionInStudentGradebook(string activityCmenu)
        {
            //Get Activity Cmenu Option In Student Gradebook
            logger.LogMethodEntry("GBStudentUXPage",
                "GetActivityCmenuOptionInStudentGradebook",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getActivityCmenuOption = string.Empty;
            try
            {                
                base.WaitForElement(By.PartialLinkText(activityCmenu));
                //Get Activity Cmenu Option
                getActivityCmenuOption =
                    base.GetElementTextByPartialLinkText(activityCmenu).Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBStudentUXPage",
                "GetActivityCmenuOptionInStudentGradebook",
                          base.IsTakeScreenShotDuringEntryExit);
            return getActivityCmenuOption;
        }

        /// <summary>
        /// Get Activity Cmenu Option In Student Gradebook.
        /// </summary>   
        /// <param name="assetCmenu">This is Activity Cmenu.</param>
        /// <param name="assetName">This is Activity assetName.</param>
        public void SelectCmenuOptionOnactivity(string assetCmenu, string assetName)
        {
            logger.LogMethodEntry("GBStudentUXPage", "SelectCmenuOptionOnactivity",
            base.IsTakeScreenShotDuringEntryExit);
            GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
            //Select Frame
            gbInstructorPage.SelectGradebookFrame();
            //open View submission page
            this.GotoViewSubmissionPage(assetName,assetCmenu);
            logger.LogMethodExit("GBStudentUXPage", "SelectCmenuOptionOnactivity",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Opens the submission window.
        /// </summary>   
        /// <param name="assetCmenu">This is Activity Cmenu.</param>
        /// <param name="assetName">This is Activity assetName.</param>
        private void GotoViewSubmissionPage(string assetName, string assetCmenu)
        {
            logger.LogMethodEntry("GBStudentUXPage", "GotoViewSubmissionPage",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.CssSelector(GBStudentUXPageResource.
                GBStudentUXPage_GradeBook_assetCount_CssSelector_Locator));
            int assetCount = base.GetElementCountByCssSelector(GBStudentUXPageResource.
                GBStudentUXPage_GradeBook_assetCount_CssSelector_Locator);
            try
            {
                for (int i = 1; i <= assetCount; i++)
                {
                    base.WaitForElement(By.CssSelector(string.Format(GBStudentUXPageResource.
                        GBStudentUXPage_GradeBook_assetElement_CssSelector_Locator, i)));
                    IWebElement assetElement = base.GetWebElementPropertiesByCssSelector(
                        string.Format(GBStudentUXPageResource.
                        GBStudentUXPage_GradeBook_assetElement_CssSelector_Locator, i));
                    String elementText = assetElement.Text;
                    if (elementText.Equals(assetName))
                    {
                        base.PerformMouseHoverByJavaScriptExecutor(assetElement);
                        base.WaitForElement(By.CssSelector(string.Format(GBStudentUXPageResource.
                        GBStudentUXPage_GradeBook_assetElement_Cmenu_CssSelector_Locator, i)));
                        IWebElement cmenuOption = base.GetWebElementPropertiesByCssSelector(
                            string.Format(GBStudentUXPageResource.
                        GBStudentUXPage_GradeBook_assetElement_Cmenu_CssSelector_Locator, i));
                        Thread.Sleep(3000);
                        base.ClickByJavaScriptExecutor(cmenuOption);
                        base.WaitForElement(By.CssSelector(string.Format(GBStudentUXPageResource.
                            GBStudentUXPage_GradeBook_Temp_Cmenu_CssSelector_Locator, i)));
                        IWebElement TempReference = base.GetWebElementPropertiesByCssSelector(
                            string.Format(GBStudentUXPageResource.
                            GBStudentUXPage_GradeBook_Temp_Cmenu_CssSelector_Locator, i));
                        string referenceId = TempReference.GetAttribute(
                            string.Format(GBStudentUXPageResource.GBStudentUXPage_GradeBook_Cmenu_Reference_ID_Locator));
                        base.WaitForElement(By.CssSelector(string.Format(GBStudentUXPageResource.
                           GBStudentUXPage_GradeBook_Cmenu_ReferencesCount_CssSelector_Locator, referenceId)));
                        int count = base.GetElementCountByCssSelector(
                            string.Format(GBStudentUXPageResource.
                            GBStudentUXPage_GradeBook_Cmenu_ReferencesCount_CssSelector_Locator, referenceId));
                        for (int j = 1; j <= count; j++)
                        {
                            base.WaitForElement(By.CssSelector(string.Format(GBStudentUXPageResource.
                                GBStudentUXPage_GradeBook_Cmenu_ViewSubmissions_CssSelector_Locator, referenceId, j)));
                            IWebElement viewSubmissionOption = base.GetWebElementPropertiesByCssSelector(
                                string.Format(GBStudentUXPageResource.
                                GBStudentUXPage_GradeBook_Cmenu_ViewSubmissions_CssSelector_Locator, referenceId, j));
                            Thread.Sleep(2000);

                            if (viewSubmissionOption.Text.Contains(assetCmenu))
                            {
                                base.PerformMouseHoverByJavaScriptExecutor(viewSubmissionOption);
                                base.ClickByJavaScriptExecutor(viewSubmissionOption);
                                break;
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
            logger.LogMethodExit("GBStudentUXPage", "GotoViewSubmissionPage",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify if Badge icon is displayed in the Student Gradebook
        /// </summary>
        /// <param name="activityName"></param>
        /// <returns>True if Badge icon is displayed</returns>
        public bool isBadgePresent(string activityName)
        {
            logger.LogMethodEntry("GBStudentUXPage",
                "isBadgePresent",
                base.IsTakeScreenShotDuringEntryExit);
            bool IconPresent = false;
            new GBInstructorUXPage().SelectGradebookFrame();
            //Initialize Variable
            string getActivityStatusGrade = string.Empty;
            //Get Activity Column Count
            int getActivityCount = base.GetElementCountByCssSelector(
                GBStudentUXPageResource.
                GBStudentUXPage_GradeBook_assetCount_CssSelector_Locator);
            for (int columnCount = 1; columnCount <= getActivityCount;
                columnCount++)
            {
                string getActivityName = base.GetTitleAttributeValueByXPath
                (string.Format(GBStudentUXPageResource.
                        GBStudentUXPage_Activity_Name_Xpath_Locator, columnCount))
                        .Trim();
                if (getActivityName.Equals(activityName))
                {
                    bool isBadgePresent = base.IsElementPresent(By.XPath
                        (string.Format(GBStudentUXPageResource.
                        GBStudentUXPage_Badge_Icon_Percent_Score_Xpath_Locator, columnCount)), 10);
                    if (isBadgePresent)
                    {
                        IconPresent = true;
                        break;
                    }
                }
            }
            logger.LogMethodExit("GBStudentUXPage", "GetActivityColumnCount",
           base.IsTakeScreenShotDuringEntryExit);
            return IconPresent;
        }
    }
}