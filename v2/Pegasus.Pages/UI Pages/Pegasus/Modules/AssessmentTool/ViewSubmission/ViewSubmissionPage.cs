using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.ViewSubmission;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Text.RegularExpressions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains the details of View Submission
    /// </summary>
    public class ViewSubmissionPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ViewSubmissionPage));

        /// <summary>
        ///Click the StudyPlan Triangle Option Cmenu
        /// </summary>        
        private void ClickTheStudyPlanTriangleOptionCmenu()
        {
            //Click the StudyPlan Triangle Option Cmenu
            logger.LogMethodEntry("ViewSubmissionPage", "ClickTheStudyPlanTriangleOptionCmenu",
                 base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                ViewSubmission_Page_Studyplan_Name_Cmenu_Xpath_Locator));
            base.FocusOnElementByXPath(ViewSubmissionPageResource.
               ViewSubmission_Page_Studyplan_Name_Cmenu_Xpath_Locator);
            //Get Web Element Property
            IWebElement getTitleAttribute = base.
                GetWebElementPropertiesByXPath(ViewSubmissionPageResource.
               ViewSubmission_Page_Studyplan_Name_Cmenu_Xpath_Locator);
            //Perform mouse over action
            base.PerformMouseHoverByJavaScriptExecutor(getTitleAttribute);
            //Focus on the Cmenu option
            base.FocusOnElementByClassName(ViewSubmissionPageResource.
                ViewSubmission_Page_Asset_TraingleOption_Cmenu_ClassName_Locator);
            IWebElement getTraingleButton = base.
                GetWebElementPropertiesByClassName(ViewSubmissionPageResource.
                ViewSubmission_Page_Asset_TraingleOption_Cmenu_ClassName_Locator);
            //Click on Cmenu Option
            base.ClickByJavaScriptExecutor(getTraingleButton);
            //Get Web Element Property of View Submission Option
            IWebElement getViewSubmissionOption = base.
                GetWebElementPropertiesByXPath(ViewSubmissionPageResource.
                ViewSubmission_Page_Activity_Cmenu_Option_Name_Xpath_Locator);
            //Click on View Submission Cmenu Option
            base.ClickByJavaScriptExecutor(getViewSubmissionOption);
            logger.LogMethodExit("ViewSubmissionPage", "ClickTheStudyPlanTriangleOptionCmenu",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click The Test Traingle Option Cmenu 
        /// </summary>
        /// <param name="setRowCount">This is Row Count</param>
        public void ClickTheTestTraingleOptionCmenu(int setRowCount)
        {
            //Click The Test Traingle Option Cmenu 
            logger.LogMethodEntry("ViewSubmissionPage", "ClickTheTestTraingleOptionCmenu",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.XPath(string.Format(ViewSubmissionPageResource.
                    ViewSubmission_Page_Test_Name_Cmenu_Xpath_Locator, setRowCount)));
                IWebElement getTitleAttribute = base.
                    GetWebElementPropertiesByXPath(string.Format(ViewSubmissionPageResource.
                    ViewSubmission_Page_Test_Name_Cmenu_Xpath_Locator, setRowCount));
                //Perform mouse over action on "Test" aseet
                base.PerformMouseHoverByJavaScriptExecutor(getTitleAttribute);
                //Wait for the element
                base.WaitForElement(By.XPath(string.Format(ViewSubmissionPageResource.
                    ViewSubmission_Page_Test_TraingleOption_Cmenu_Xpath_Locator, setRowCount)));
                base.FocusOnElementByXPath(string.Format(ViewSubmissionPageResource.
                    ViewSubmission_Page_Test_TraingleOption_Cmenu_Xpath_Locator, setRowCount));
                //Get Web Element Property
                IWebElement getTraingleButton = base.GetWebElementPropertiesByXPath
                    (string.Format(ViewSubmissionPageResource.
                    ViewSubmission_Page_Test_TraingleOption_Cmenu_Xpath_Locator, setRowCount));
                //Click on the "Test" cmenu option
                base.ClickByJavaScriptExecutor(getTraingleButton);
                //Get Web Element Property
                IWebElement getViewSubmissionOption = base.
                    GetWebElementPropertiesByXPath(ViewSubmissionPageResource.
                    ViewSubmission_Page_Activity_Cmenu_Option_Name_Xpath_Locator);
                //Click on View Submission Cmenu Option
                base.ClickByJavaScriptExecutor(getViewSubmissionOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage", "ClickTheTestTraingleOptionCmenu",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Score Result In View Submission Page
        /// </summary>
        /// <returns>Score result</returns>
        public string GetScoreResultInViewSubmissionPage()
        {
            // Get Score Result In View Submission Page
            logger.LogMethodEntry("ViewSubmissionPage", "GetScoreResultInViewSubmissionPage",
                 base.isTakeScreenShotDuringEntryExit);
            //Intialize the activity score variable
            string getActivityScore = string.Empty;
            try
            {
                //Select the window name
                base.WaitUntilWindowLoads(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Window_Name);
                base.SelectWindow(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Window_Name);
                //Wait for the element
                base.WaitForElement(By.ClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Score_ClassName_Locator));
                IWebElement getSubmissionScore = base.
                    GetWebElementPropertiesByClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Score_ClassName_Locator);
                //Click the score link
                base.ClickByJavaScriptExecutor(getSubmissionScore);
                Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.
                  ViewSubmission_Page_ViewGrade_Button_Time_Value));
                //Wait for the element
                base.WaitForElement(By.ClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_CheckScore_ClassName_Locator));
                //Get Activity Name
                getActivityScore = base.GetElementTextByClassName(ViewSubmissionPageResource.
                     ViewSubmission_Page_ViewSubmission_CheckScore_ClassName_Locator).Trim();
                string[] getScoreResult = getActivityScore.Split(Convert.ToChar(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_ScoreResult_Char));
                //Split the score result
                getActivityScore = getScoreResult[Convert.ToInt32(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_ScoreResult_Int)];
                //Close View Submission Button
                this.CloseViewSubmissionButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage", "GetScoreResultInViewSubmissionPage",
             base.isTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Close View Submission Button
        /// </summary>
        private void CloseViewSubmissionButton()
        {
            //Close View Submission Button
            logger.LogMethodEntry("ViewSubmissionPage", "CloseViewSubmissionButton",
                 base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Closebtn_Id_Locator));
            base.FocusOnElementById(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Closebtn_Id_Locator);
            //Click the "Close" button
            base.ClickButtonById(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Closebtn_Id_Locator);
            Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.
                 ViewSubmission_Page_ViewGrade_Button_Time_Value));
            logger.LogMethodExit("ViewSubmissionPage", "CloseViewSubmissionButton",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Grades Tab Cmenu Option  
        /// </summary>      
        /// <param name="activityTypeEnum">This is Asset Name</param>
        public void ClickTheGradesTabCmenuOption(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Click The Grades Tab Cmenu Option
            logger.LogMethodEntry("ViewSubmissionPage", "ClickTheGradesTabCmenuOption",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select GradeBook Window
                new GBStudentUXPage().SelectGradebookWindow();
                switch (activityTypeEnum)
                {
                    //Click the cmenu option for Studyplan 
                    case Activity.ActivityTypeEnum.StudyPlan:
                        //Select Assigned Items Option
                        this.SelectAssignedItemsOption();
                        //Navigate Inside View Grades
                        new GBStudentUXPage().NavigateInsideViewGrade(activityTypeEnum.ToString());
                        Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.
                            ViewSubmission_Page_ViewGrade_Button_Time_Value));
                        //Verify The Asset Name in Grade Tab
                        new GBStudentUXPage().VerifyTheAssetNameInGradeTab(activityTypeEnum);
                        this.ClickTheStudyPlanTriangleOptionCmenu();
                        break;
                    //Click the cmenu option for Test 
                    case Activity.ActivityTypeEnum.Test:
                        //Select Assigned Items Option
                        this.SelectAssignedItemsOption();
                        //Verify the asset name and Click Traingle Option Cmenu of Asset in Grade Tab
                        new GBStudentUXPage().VerifyAssetNameAndClickTriangleOptionCmenu(activityTypeEnum);
                        break;
                    //Click the cmenu option HomeWork 
                    case Activity.ActivityTypeEnum.HomeWork:
                        //Verify the asset name and Click Traingle Option Cmenu of Asset in Grade Tab
                        new GBStudentUXPage().VerifyAssetNameAndClickTriangleOptionCmenu(activityTypeEnum);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage", "ClickTheGradesTabCmenuOption",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check The Asset Name Contains In Grades Tab.
        /// </summary>      
        /// <param name="activityTypeEnum">This is Asset by Type.</param>
        public void CheckTheAssetNameContainsInGradesTab(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Check The Asset Name Contains In Grades Tab
            logger.LogMethodEntry("ViewSubmissionPage", "CheckTheAssetNameContainsInGradesTab",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select GradeBook Window
                new GBStudentUXPage().SelectGradebookWindow();
                switch (activityTypeEnum)
                {
                    //Check for Studyplan 
                    case Activity.ActivityTypeEnum.StudyPlan:
                        //Select Assigned Items Option
                        this.SelectAssignedItemsOption();
                        //Verify The Asset Name In Grade Tab
                        new GBStudentUXPage().VerifyTheAssetNameInGradeTab(activityTypeEnum);
                        //Navigate Inside View Grades
                        new GBStudentUXPage().NavigateInsideViewGrade(activityTypeEnum.ToString());
                        Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.
                            ViewSubmission_Page_ViewGrade_Button_Time_Value));
                        break;
                    //Check for Test 
                    case Activity.ActivityTypeEnum.Test:
                        //Select Assigned Items Option
                        this.SelectAssignedItemsOption();
                        //Verify The Asset Name In Grade Tab
                        new GBStudentUXPage().VerifyTheAssetNameInGradeTab(activityTypeEnum);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage", "CheckTheAssetNameContainsInGradesTab",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Assigned Items Option
        /// </summary>
        private void SelectAssignedItemsOption()
        {
            //Select Assigned Items Option
            logger.LogMethodEntry("ViewSubmissionPage", "SelectAssignedItemsOption",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Assigned Items Option
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_AssignedItems_Id_Locator));
            //Get Assigned Items Property
            IWebElement getAssignedItemsOption = base.GetWebElementPropertiesById(
                ViewSubmissionPageResource.ViewSubmission_Page_AssignedItems_Id_Locator);
            //Click On Assigned Items Option
            base.ClickByJavaScriptExecutor(getAssignedItemsOption);
            Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewGrade_Button_Time_Value));
            logger.LogMethodExit("ViewSubmissionPage", "SelectAssignedItemsOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get View All Submission Count.
        /// </summary>
        /// <returns>All submission count</returns>
        public String GetViewAllSubmissionCount()
        {
            //Get View All Submission Count
            logger.LogMethodEntry("ViewSubmissionPage", "GetViewAllSubmissionCount",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            int getSubmissionCount = Convert.ToInt32(ViewSubmissionPageResource.
                     ViewSubmission_Page_Initial_Count_Value);
            try
            {
                //Select View Submission Window
                this.SelectViewSubmissionWindow();
                //Expand TheS tudent In ViewSubmission
                this.ExpandTheStudentInViewSubmission();
                //Wait for the element
                base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Allsubmission_Xpath_Locator));
                getSubmissionCount =
                    base.GetElementCountByXPath(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Allsubmission_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage", "GetViewAllSubmissionCount",
                           base.isTakeScreenShotDuringEntryExit);
            return getSubmissionCount.ToString();
        }

        /// <summary>
        /// Expand The Student In ViewSubmission.
        /// </summary>
        private void ExpandTheStudentInViewSubmission()
        {
            //Expand The Student In ViewSubmission
            logger.LogMethodEntry("ViewSubmissionPage", "ExpandTheStudentInViewSubmission",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Expand_Xpath_Locator));
            IWebElement getExpandButton =
                base.GetWebElementPropertiesByXPath(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Expand_Xpath_Locator);
            //Click the expand button
            base.ClickByJavaScriptExecutor(getExpandButton);
            Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.
                ViewSubmission_Page_Activity_Time_Value));
            logger.LogMethodExit("ViewSubmissionPage", "ExpandTheStudentInViewSubmission",
                           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select View Submission Window.
        /// </summary>
        private void SelectViewSubmissionWindow()
        {
            //Select View Submission Window
            logger.LogMethodEntry("ViewSubmissionPage", "SelectViewSubmissionWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Select the window          
            base.WaitUntilWindowLoads(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Window_Name);
            base.SelectWindow(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Window_Name);
            logger.LogMethodExit("ViewSubmissionPage", "SelectViewSubmissionWindow",
                          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Grade from View Submission Page.
        /// </summary>
        /// <returns>Grade</returns>
        public string GetGradefromViewSubmissionPage()
        {
            //Get Grade from View Submission Page
            logger.LogMethodEntry("ViewSubmissionPage",
                "GetGradefromViewSubmissionPage",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getGrade = string.Empty;
            try
            {
                //Select View Submission Window
                this.SelectViewSubmissionWindow();
                //Wait for Element
                base.WaitForElement(By.Id(ViewSubmissionPageResource.
                    ViewSubmission_Page_RevisedGrade_Id_Locator));
                //Get Grade
                getGrade = base.GetElementTextById(ViewSubmissionPageResource.
                    ViewSubmission_Page_RevisedGrade_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage",
                "GetGradefromViewSubmissionPage",
                           base.isTakeScreenShotDuringEntryExit);
            return getGrade.Substring(Convert.ToInt32(ViewSubmissionPageResource.
                ViewSubmission_Page_Initial_Count_Value),
                Convert.ToInt32(ViewSubmissionPageResource.
                ViewSubmission_Page_GradeSplit_Boundary_Value));
        }

        /// <summary>
        /// Click On Save Button.
        /// </summary>
        private void ClickOnSaveButton()
        {
            //Click On Save Button
            logger.LogMethodEntry("ViewSubmissionPage",
                "ClickOnSaveButton",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_Save_Button_Id_Locator));
            IWebElement getSaveCloseButton = base.GetWebElementPropertiesById
                (ViewSubmissionPageResource.
                ViewSubmission_Page_Save_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(getSaveCloseButton);
            Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.
                  ViewSubmission_Page_ViewGrade_Button_Time_Value));
            logger.LogMethodExit("ViewSubmissionPage",
               "ClickOnSaveButton",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit Grades In ViewSubmission Page.
        /// </summary>
        public void EditGradesInViewSubmissionPage()
        {
            //Edit Grades In ViewSubmission Page
            logger.LogMethodEntry("ViewSubmissionPage", "EditGradesInViewSubmissionPage",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select View Submission Window
                this.SelectViewSubmissionWindow();
                //Expand TheS tudent In ViewSubmission
                this.ExpandTheStudentInViewSubmission();
                //Wait for the element
                base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Allsubmission_Xpath_Locator));
                IWebElement getExpanStudentName = base.GetWebElementPropertiesByXPath
                    (ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Allsubmission_Xpath_Locator);
                //Click on Expand student link
                base.ClickByJavaScriptExecutor(getExpanStudentName);
                //Click The Edit Link
                this.ClickTheEditLink();
                //Update The Grade In ViewSubmission
                this.UpdateTheGradeInViewSubmission();
                //Click On Update Button In ViewSubmission
                this.ClickOnUpdateButtonInViewSubmission();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage", "EditGradesInViewSubmissionPage",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Update Button In ViewSubmission.
        /// </summary>
        private void ClickOnUpdateButtonInViewSubmission()
        {
            //Click On Update Button In ViewSubmission
            logger.LogMethodEntry("ViewSubmissionPage", "ClickOnUpdateButtonInViewSubmission",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_Update_Button_Id_Locator));
            IWebElement getUpdateButton = base.GetWebElementPropertiesById
                (ViewSubmissionPageResource.ViewSubmission_Page_Update_Button_Id_Locator);
            //Click on 'Update' Button
            base.ClickByJavaScriptExecutor(getUpdateButton);
            logger.LogMethodExit("ViewSubmissionPage", "ClickOnUpdateButtonInViewSubmission",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Update The Grade In ViewSubmission.
        /// </summary>
        private void UpdateTheGradeInViewSubmission()
        {
            //Update The Grade In ViewSubmission
            logger.LogMethodEntry("ViewSubmissionPage", "UpdateTheGradeInViewSubmission",
               base.isTakeScreenShotDuringEntryExit);
            //Fill Edit Grade Score Value
            this.FillEditGradeScoreValue(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_ScoreValue);
            //Fill Edit Grade Max Score Value
            this.FillEditGradeMaximumScoreValue(ViewSubmissionPageResource.
                ViewSubmission_Page_MaxValue_ScoreValue);
            logger.LogMethodExit("ViewSubmissionPage", "UpdateTheGradeInViewSubmission",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Edit Grade ScoreValue.
        /// </summary>
        /// <param name="scoreValue">This is score value</param>
        private void FillEditGradeScoreValue(string scoreValue)
        {
            // Fill Edit Grade ScoreValue
            logger.LogMethodEntry("ViewSubmissionPage", "FillEditGradeScoreValue",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_ScoreValue_Id_Locator));
            base.ClearTextById(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_ScoreValue_Id_Locator);
            //Fill The Score Value
            base.FillTextBoxById(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_ScoreValue_Id_Locator, scoreValue);
            logger.LogMethodExit("ViewSubmissionPage", "FillEditGradeScoreValue",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Edit Grade Maximum ScoreValue.
        /// </summary>
        /// <param name="maximumScoreValue">This is maximum score</param>
        private void FillEditGradeMaximumScoreValue(string maximumScoreValue)
        {
            //Fill Edit Grade Maximum ScoreValue
            logger.LogMethodEntry("ViewSubmissionPage", "FillEditGradeMaximumScoreValue",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_MaxScoreValue_Id_Locator));
            base.ClearTextById(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_MaxScoreValue_Id_Locator);
            //Fill the Max Score Value
            base.FillTextBoxById(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_MaxScoreValue_Id_Locator, maximumScoreValue);
            logger.LogMethodExit("ViewSubmissionPage", "FillEditGradeMaximumScoreValue",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Edit Link.
        /// </summary>
        private void ClickTheEditLink()
        {
            //Click The Edit Link
            logger.LogMethodEntry("ViewSubmissionPage", "ClickTheEditLink",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for the 'Edit' link
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_Edit_Link_Id_Locator));
            IWebElement getEditLink = base.GetWebElementPropertiesById
                (ViewSubmissionPageResource.ViewSubmission_Page_Edit_Link_Id_Locator);
            //Click on 'Edit' link
            base.ClickByJavaScriptExecutor(getEditLink);
            logger.LogMethodExit("ViewSubmissionPage", "ClickTheEditLink",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Student Expand Link.
        /// </summary>
        public void ClickTheStudentExpandLink()
        {
            //Click The Student Expand Link
            logger.LogMethodEntry("ViewSubmissionPage", "ClickTheStudentExpandLink",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select View Submission Window
                this.SelectViewSubmissionWindow();
                //Expand TheS tudent In ViewSubmission
                this.ExpandTheStudentInViewSubmission();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage", "ClickTheStudentExpandLink",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Expand Link
        /// </summary>
        private void ClickExpandButton()
        {
            //Click The Expand Link
            logger.LogMethodEntry("ViewSubmissionPage", "ClickExpandButton",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Allsubmission_Xpath_Locator));
            IWebElement getExpanStudentName = base.GetWebElementPropertiesByXPath
                (ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Allsubmission_Xpath_Locator);
            //Click on Expand student link
            base.ClickByJavaScriptExecutor(getExpanStudentName);
            logger.LogMethodExit("ViewSubmissionPage", "ClickExpandButton",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Grade from Student ViewSubmission Page
        /// </summary>
        /// <returns>Grade</returns>
        public String GetGradefromStudentViewSubmissionPage()
        {
            // Get Grade from Student ViewSubmission Page
            logger.LogMethodEntry("ViewSubmissionPage", "GetGradefromStudentViewSubmissionPage",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getGrade = string.Empty;
            try
            {
                //Wait for Element
                base.WaitForElement(By.ClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_ScoreResult_Class_Locator));
                //Get Grade
                getGrade = base.GetElementTextByClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_ScoreResult_Class_Locator);
                //Split the value
                getGrade = getGrade.Substring((getGrade.IndexOf(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_ScoreResult_Char) - Convert.ToInt32
                    (ViewSubmissionPageResource.ViewSubmission_Page_ViewSubmission_Score_SplitValue)),
                    Convert.ToInt32(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Score_SplitValue)).Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage", "GetGradefromStudentViewSubmissionPage",
              base.isTakeScreenShotDuringEntryExit);
            return getGrade;
        }

        /// <summary>
        /// Get Submitted Grade In ViewSubmission Page.
        /// </summary>
        /// <returns>Get Submitted Grade In ViewSubmission Page.</returns>
        public string GetSubmittedGradeInViewSubmissionPage()
        {
            //Get Submitted Grade In ViewSubmission Page
            logger.LogMethodEntry("ViewSubmissionPage",
                "GetSubmittedGradeInViewSubmissionPage",
                base.isTakeScreenShotDuringEntryExit);
            //Intialize the variable
            string getScore = string.Empty;
            try
            {
                //Select View Submission Window
                this.SelectViewSubmissionWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                       ViewSubmission_Page_ViewSubmission_StudentExpand_Xpath_Locator));
                //Get Grade
                getScore = base.GetElementTextByXPath(ViewSubmissionPageResource.
                       ViewSubmission_Page_ViewSubmission_StudentExpand_Xpath_Locator);
                getScore = getScore.Substring(Convert.ToInt32
                    (ViewSubmissionPageResource.ViewSubmission_Page_Initial_Count_Value),
                    Convert.ToInt32(
                   ViewSubmissionPageResource.ViewSubmission_Page_Substring_Split_Count_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage",
                "GetSubmittedGradeInViewSubmissionPage",
                           base.isTakeScreenShotDuringEntryExit);
            return getScore;
        }

        /// <summary>
        /// Select the Submission Frame
        /// </summary>
        public void SelectTheSubmissionFrame()
        {
            //Select the Submission Frame
            logger.LogMethodEntry("ViewSubmissionPage",
                "SelectTheSubmissionFrame", base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                        ViewSubmission_Page_ViewSubmission_Xpath_Locator));
                //Get Submission Property
                IWebElement getSubmissionProperty = base.GetWebElementPropertiesByXPath
                    (ViewSubmissionPageResource.ViewSubmission_Page_ViewSubmission_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getSubmissionProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage",
                "SelectTheSubmissionFrame", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Question Status
        /// </summary>
        /// <returns>Question status</returns>
        public String GetQuestionStatus()
        {
            //Get The Question Status
            logger.LogMethodEntry("ViewSubmissionPage",
                "GetQuestionStatus", base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getQuestionStatus = string.Empty;
            try
            {
                //Wait for Question status element
                base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                        ViewSubmission_Page_GetQuestionStatus_Xpath_Locator));
                getQuestionStatus = base.GetElementTextByXPath(ViewSubmissionPageResource.
                        ViewSubmission_Page_GetQuestionStatus_Xpath_Locator);
                //Get Correct answer
                string[] getCorrectAnswer = getQuestionStatus.Split(Convert.ToChar(
                    ViewSubmissionPageResource.ViewSubmission_Page_StatusSpecialCharacter_Char));
                getQuestionStatus = getCorrectAnswer[1].Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage",
                "GetQuestionStatus", base.isTakeScreenShotDuringEntryExit);
            return getQuestionStatus;
        }

        /// <summary>
        /// Get the Total time taken of SIM Study Plan Pre test on View Submission page. 
        /// </summary>
        /// <returns>Time taken of Pre Test.</returns>
        public String GetTotalTimeTaken()
        {
            //Logger Entry
            logger.LogMethodEntry("ViewSubmissionPage",
               "GetTotalTimeTaken", base.isTakeScreenShotDuringEntryExit);
            string getTextOfDivTime = string.Empty;
            try
            {
                Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.
                  ViewSubmission_Page_ViewGrade_Button_Time_Value));
                //Wait for Time takem element 
                base.WaitForElement(By.Id(ViewSubmissionPageResource.
                    ViewSubmission_Page_TimeTaken_Div_Id_Locator));
                //Get Text of Time div
                getTextOfDivTime = base.GetElementTextById(ViewSubmissionPageResource.
                    ViewSubmission_Page_TimeTaken_Div_Id_Locator).
                    Remove(0, Convert.ToInt16(ViewSubmissionPageResource.
                    ViewSubmission_Page_Subsrting_End_Index));
                //Trim the extra character and return only "minute:second" time formate.
                getTextOfDivTime = getTextOfDivTime.Substring(Convert.ToInt32(
                    ViewSubmissionPageResource.ViewSubmission_Page_Subsrting_Start_Index),
                    getTextOfDivTime.Length - Convert.ToInt32(
                    ViewSubmissionPageResource.ViewSubmission_Page_Subsrting_End_Index));
                Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.
                  ViewSubmission_Page_ViewGrade_Button_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            logger.LogMethodExit("ViewSubmissionPage",
              "GetTotalTimeTaken", base.isTakeScreenShotDuringEntryExit);
            //Return the actual time taken 
            return getTextOfDivTime;
        }

        /// <summary>
        /// Get Submission Count In View Submission.
        /// </summary>
        /// <returns>Submission Count.</returns>
        public String GetSubmissionCountInViewSubmission()
        {
            //Get Submission Count In View Submission
            logger.LogMethodEntry("ViewSubmissionPage",
               "GetSubmissionCountInViewSubmission", base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSubmissionCount = string.Empty; ;
            try
            {
                //Select Window
                this.SelectViewSubmissionWindow();
                base.WaitForElement(By.ClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_DateTimeColumn_SubmissionList_ClassName_Locator));
                //Click On DateTime Column In Submission List
                base.ClickButtonByClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_DateTimeColumn_SubmissionList_ClassName_Locator);
                base.WaitForElement(By.Id(ViewSubmissionPageResource.
                    ViewSubmission_Page_SubmissionCount_Id_Locator));
                //Get Submission Count
                getSubmissionCount = base.GetElementTextById(ViewSubmissionPageResource.
                    ViewSubmission_Page_SubmissionCount_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage",
              "GetSubmissionCountInViewSubmission", base.isTakeScreenShotDuringEntryExit);
            return getSubmissionCount;
        }

        /// <summary>
        /// Select Submission In View Submission Window
        /// </summary>
        public void SelectSubmissionInViewSubmissionWindow()
        {
            //
            logger.LogMethodEntry("ViewSubmissionPage",
              "SelectSubmissionInViewSubmissionWindow", base.isTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectViewSubmissionWindow();
                //Wait for the element
                base.WaitForElement(By.ClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Score_ClassName_Locator));
                IWebElement getSubmissionScore = base.
                    GetWebElementPropertiesByClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Score_ClassName_Locator);
                //Click the score link
                base.ClickByJavaScriptExecutor(getSubmissionScore);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("ViewSubmissionPage",
              "SelectSubmissionInViewSubmissionWindow", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Send Message Option
        /// </summary>
        public void SelectSendMessageOption()
        {
            //Select Send Message Option
            logger.LogMethodEntry("ViewSubmissionPage",
              "SelectSendMessageOption", base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(ViewSubmissionPageResource.
                        ViewSubmission_Page_SendMessage_Id_Locator));
                //Get Send Message Property
                IWebElement getSendMessageproperty = base.GetWebElementPropertiesById
                    (ViewSubmissionPageResource.
                    ViewSubmission_Page_SendMessage_Id_Locator);
                //Click On Send Message
                base.ClickByJavaScriptExecutor(getSendMessageproperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("ViewSubmissionPage",
            "SelectSendMessageOption", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get SaveForLater Display Message.
        /// </summary>
        /// <returns>Display Message.</returns>
        public string GetSaveForLaterDisplayMessage()
        {
            //Get SaveForLater Display Message
            logger.LogMethodEntry("ViewSubmissionPage", "GetSaveForLaterDisplayMessage",
                base.isTakeScreenShotDuringEntryExit);
            //Intialize the variable
            string getDisplayMessage = string.Empty;
            try
            {
                //Select View Submission Window
                this.SelectViewSubmissionWindow();
                //Expand TheS tudent In ViewSubmission
                this.ExpandTheStudentSubmission();
                //Wait for the element
                base.WaitForElement(By.Id(ViewSubmissionPageResource.
                    ViewSubmission_Page_SaveForLater_Message_Id_Locator));
                //Get the message
                getDisplayMessage = base.GetElementTextById(ViewSubmissionPageResource.
                    ViewSubmission_Page_SaveForLater_Message_Id_Locator);
                //Close ViewSubmission Button
                this.CloseViewSubmissionButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("ViewSubmissionPage", "GetSaveForLaterDisplayMessage",
                base.isTakeScreenShotDuringEntryExit);
            return getDisplayMessage;
        }

        /// <summary>
        /// Expand The Student Submission.
        /// </summary>
        private void ExpandTheStudentSubmission()
        {
            //Expand The Student Submission
            logger.LogMethodEntry("ViewSubmissionPage", "ExpandTheStudentSubmission",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                ViewSubmission_Page_Student_Submission_Expand_Xpath_Locator));
            IWebElement getExpandButton =
                base.GetWebElementPropertiesByXPath(ViewSubmissionPageResource.
                ViewSubmission_Page_Student_Submission_Expand_Xpath_Locator);
            //Click the expand button
            base.ClickByJavaScriptExecutor(getExpandButton);
            Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.
                ViewSubmission_Page_Activity_Time_Value));
            logger.LogMethodEntry("ViewSubmissionPage", "ExpandTheStudentSubmission",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit The Manual Grade In View Submission Page.
        /// </summary>
        public void EditTheManualGradeInViewSubmissionPage()
        {
            // Edit The Manual Grade In View Submission Page
            logger.LogMethodEntry("ViewSubmissionPage",
                "EditTheManualGradeInViewSubmissionPage",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select View Submission Window
                this.SelectViewSubmissionWindow();
                //Expand TheS tudent In ViewSubmission
                this.ExpandTheStudentInViewSubmission();
                //Wait for the element
                base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Allsubmission_Xpath_Locator));
                IWebElement getExpanStudentName = base.GetWebElementPropertiesByXPath
                    (ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Allsubmission_Xpath_Locator);
                //Click on Expand student link
                base.ClickByJavaScriptExecutor(getExpanStudentName);
                //Wait for the element
                base.WaitForElement(By.ClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_GradeTextbox_ClassName_Locator));
                base.ClearTextByClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_GradeTextbox_ClassName_Locator);
                base.FillTextBoxByClassName(ViewSubmissionPageResource.
                 ViewSubmission_Page_GradeTextbox_ClassName_Locator,
                 ViewSubmissionPageResource.ViewSubmission_Page_GradeTextbox_Value);
                this.ClickOnSaveButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("ViewSubmissionPage",
                "EditTheManualGradeInViewSubmissionPage",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Submission Count In View Submission.
        /// </summary>
        /// <returns>Submission Count.</returns>
        public string GetAttemptByTheStudentInSubmissionPage()
        {
            //Get Submission Count In View Submission
            logger.LogMethodEntry("ViewSubmissionPage",
                "GetAttemptByTheStudentInSubmissionPage",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSubmissionCount = string.Empty; ;
            try
            {
                //Select Window
                this.SelectViewSubmissionWindow();
                //Wait for the element
                base.WaitForElement(By.Id(ViewSubmissionPageResource.
                    ViewSubmission_Page_SubmissionCount_Id_Locator));
                //Get Submission Count
                getSubmissionCount = base.GetElementTextById(ViewSubmissionPageResource.
                    ViewSubmission_Page_SubmissionCount_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage",
              "GetAttemptByTheStudentInSubmissionPage",
              base.isTakeScreenShotDuringEntryExit);
            return getSubmissionCount;
        }

        /// <summary>
        /// Edit The Score In ViewSubmission Page.
        /// </summary>
        public void EditTheScoreInViewSubmissionPage()
        {
            //Edit The Score In ViewSubmission Page
            logger.LogMethodEntry("ViewSubmissionPage",
                "EditTheManualGradeInViewSubmissionPage",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Edit Grades In ViewSubmission Page
                this.EditGradesInViewSubmissionPage();
                //Click On Save Button
                this.ClickOnSaveButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("ViewSubmissionPage",
                "EditTheManualGradeInViewSubmissionPage",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Submission Grade.
        /// </summary>
        public void ClickonSubmissionGrade()
        {
            //Click on Submission Grade
            logger.LogMethodEntry("ViewSubmissionPage", "ClickonSubmissionGrade",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select View Submission Window
                this.SelectViewSubmissionWindow();
                base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                    ViewSubmission_Page_Grade_ViewSubmission_Xpath_Locator));
                //Click on Grade in Submission Page
                IWebElement getSubmissionGradeProperty =
                    base.GetWebElementPropertiesByXPath(ViewSubmissionPageResource.
                    ViewSubmission_Page_Grade_ViewSubmission_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getSubmissionGradeProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage", "ClickonSubmissionGrade",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Grade In Student ViewSubmission Page.
        /// </summary>
        /// <returns>Grade</returns>
        public String GetGradeInStudentViewSubmissionPage()
        {
            // Get Grade In Student ViewSubmission Page
            logger.LogMethodEntry("ViewSubmissionPage", "GetGradeInStudentViewSubmissionPage",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getGrade = string.Empty;
            string getSplittedGrade = string.Empty;
            try
            {
                //Wait for Element
                base.WaitForElement(By.ClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_ScoreResult_Class_Locator));
                //Get Grade
                getGrade = base.GetElementTextByClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_ScoreResult_Class_Locator);
                //Get Splitted Grade
                getSplittedGrade = Regex.Split(getGrade, ViewSubmissionPageResource.
                    ViewSubmission_Page_StatusSpecialCharacter_Char)
                    [Convert.ToInt16(ViewSubmissionPageResource.
                    ViewSubmission_Page_Index_Value_One)].
                    Split(Convert.ToChar(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_ScoreResult_Char))
                    [Convert.ToInt16(ViewSubmissionPageResource.
                    ViewSubmission_Page_Index_Value_Zero)];
                getSplittedGrade = getSplittedGrade.Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage", "GetGradeInStudentViewSubmissionPage",
              base.isTakeScreenShotDuringEntryExit);
            return getSplittedGrade;
        }

        /// <summary>
        /// Select The Cmenu Option Of Asset.
        /// </summary>
        /// <param name="assetCmenuOptionEnum">This is Asset cmenu options.</param>
        /// <param name="assetName">This is Asset name.</param>
        public void SelectAssetCMenuOption(
          GBInstructorUXPage.AssetCmenuOptionEnum assetCmenuOptionEnum,
          string assetName, Activity.ActivityTypeEnum activityTypeEnum, string assetId)
        {
            //Select The Cmenu Option Of Asset
            logger.LogMethodEntry("ViewSubmissionPage", "SelectAssetCMenuOption",
           base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click On Cmenu Of Asset
                this.ClickOnCmenuOfAsset(assetCmenuOptionEnum, activityTypeEnum, assetName, assetId);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ViewSubmissionPage", "SelectAssetCMenuOption",
             base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Cmenu Of Asset.
        /// </summary>
        /// <param name="getActivityColumnCount">This is asset count.</param>
        /// <param name="assetCmenuOptionEnum">Thia is asset cmenu option.</param>
        private void ClickOnCmenuOfAsset(
              GBInstructorUXPage.AssetCmenuOptionEnum assetCmenuOptionEnum,
             Activity.ActivityTypeEnum activityTypeEnum, string assetName, string assetId)
        {
            //Click On Cmenu 
            logger.LogMethodEntry("ViewSubmissionPage", "ClickOnCmenuOfAsset",
            base.isTakeScreenShotDuringEntryExit);
            // It opens the c-menu 
            ClickOnCmenuAssetIcon(assetName, assetId);
            switch (assetCmenuOptionEnum)
            {
                //Click the 'View Submission' cmenu
                case GBInstructorUXPage.AssetCmenuOptionEnum.ViewSubmissions:
                    this.SelectViewSubmissionCmenuOption();
                    break;

            }
            logger.LogMethodExit("ViewSubmissionPage", "ClickOnCmenuOfAsset",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select View Submission Cmenu Option.
        /// </summary>
        private void SelectViewSubmissionCmenuOption()
        {
            //Select View Submission Cmenu Option
            logger.LogMethodEntry("ViewSubmissionPage", "SelectViewSubmissionCmenuOption",
                                   base.isTakeScreenShotDuringEntryExit);
            // Wait for the cmenu
            base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                ViewSubmission_Page_Asset_CmenuViewSubmission_Xpath_Locator));
            // Click on the ViewSubmission c-menu
            IWebElement getViewAllSubmissionCmenu = base.GetWebElementPropertiesByXPath
                (ViewSubmissionPageResource.
                ViewSubmission_Page_Asset_CmenuViewSubmission_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getViewAllSubmissionCmenu);
            logger.LogMethodExit("ViewSubmissionPage", "SelectViewSubmissionCmenuOption",
                                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Cmenu Icon In Asset.
        /// </summary>
        /// <param name="getActivityColumnCount">This is Asset column count.</param>
        private void ClickOnCmenuAssetIcon(string assetName, string assetId)
        {
            // Click The Cmenu Icon In Asset
            logger.LogMethodEntry("ViewSubmissionPage", "ClickTheCmenuIcon",
                         base.isTakeScreenShotDuringEntryExit);

            // This function is used to check the iframe and if exists then switch to that frame
            this.SelectIFrame(assetName);

            // This code checks the link exists
            if (base.IsElementPresent(By.PartialLinkText(assetName), 5))
            {
                //Wait for element
                base.WaitForElement(By.PartialLinkText(assetName));
                //Perform Mouse Hover on Cmenu Icon
                base.PerformMouseHoverAction(base.GetWebElementPropertiesByPartialLinkText(assetName));
            }
            // This function is used to click on c-menu image icon for Course Materials/Assingments/TO Do/Completed
            string strViewSubmissionXpath = this.ClickOnImageIcon(assetId, assetName);

            base.WaitForElement(By.XPath(strViewSubmissionXpath));
            IWebElement getCmenuIconProperty = base.GetWebElementPropertiesByXPath(strViewSubmissionXpath);
            //Perform Mouse Hover on Cmenu Icon
            base.PerformMouseHoverAction(getCmenuIconProperty);
            //Perform Mouse Click Action
            base.PerformMouseClickAction(getCmenuIconProperty);
            Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.ViewSubmission_Page_SleepTime_Value));
            logger.LogMethodExit("ViewSubmissionPage", "ClickTheCmenuIcon",
                          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Iframe.
        /// </summary>
        private void SelectIFrame(string assetName)
        {
            //Select IFrame
            logger.LogMethodEntry("ViewSubmissionPage", "SelectIFrame",
               base.isTakeScreenShotDuringEntryExit);
            //This condition checks Iframe exists  
            if (base.IsElementPresent(By.Id(ViewSubmissionPageResource.
                 ViewSubmission_Page_ViewSubmission_Iframe_Id_Locator), 5))
            {
                //Wait for the element    
                base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Iframe_Id_Locator));
                // Switch to the To Do Iframe
                base.SwitchToIFrameById(ViewSubmissionPageResource.
                 ViewSubmission_Page_ViewSubmission_Iframe_Id_Locator);

            }

            logger.LogMethodExit("ViewSubmissionPage", "SelectIFrame",
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Image Icon.
        /// </summary>
        /// <returns></returns>
        private string ClickOnImageIcon(string assetId, string assetName)
        {
            logger.LogMethodEntry("ViewSubmissionPage", "ClickOnImageIcon",
            base.isTakeScreenShotDuringEntryExit);
            string strViewSubmissionXpath;
            // Modified the xpath for the To Do tab based on the assetid
            strViewSubmissionXpath = ViewSubmissionPageResource.ViewSubmission_Page_Asset_ToDo_Cmenuicon_Xpath_Locator;
            strViewSubmissionXpath = strViewSubmissionXpath.Replace("assetId", assetId);
            if (base.IsElementPresent(By.XPath(strViewSubmissionXpath),5)) { }
            else
            {
                // Modified the xpath for the Assignment/CourseMaterial/Completed based on the assetid
                strViewSubmissionXpath = ViewSubmissionPageResource.ViewSubmission_Page_Asset_Cmenuicon_Xpath_Locator;
                strViewSubmissionXpath = strViewSubmissionXpath.Replace("assetId", assetId);

            }
            logger.LogMethodExit("ViewSubmissionPage", "ClickOnImageIcon",
            base.isTakeScreenShotDuringEntryExit);
            return strViewSubmissionXpath;
        }



    }
}
