using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.ViewSubmission;
using Pegasus.Pages.Exceptions;
using System.Text.RegularExpressions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

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
        private static readonly Logger Logger = Logger.GetInstance(typeof(ViewSubmissionPage));

        /// <summary>
        ///Click the StudyPlan Triangle Option Cmenu
        /// </summary>        
        private void ClickTheStudyPlanTriangleOptionCmenu()
        {
            //Click the StudyPlan Triangle Option Cmenu
            Logger.LogMethodEntry("ViewSubmissionPage", "ClickTheStudyPlanTriangleOptionCmenu",
                 base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage", "ClickTheStudyPlanTriangleOptionCmenu",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click The Test Traingle Option Cmenu 
        /// </summary>
        /// <param name="setRowCount">This is Row Count</param>
        public void ClickTheTestTraingleOptionCmenu(int setRowCount)
        {
            //Click The Test Traingle Option Cmenu 
            Logger.LogMethodEntry("ViewSubmissionPage", "ClickTheTestTraingleOptionCmenu",
                 base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage", "ClickTheTestTraingleOptionCmenu",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Score Result In View Submission Page
        /// </summary>
        /// <returns>Score result</returns>
        public string GetScoreResultInViewSubmissionPage()
        {
            // Get Score Result In View Submission Page
            Logger.LogMethodEntry("ViewSubmissionPage", "GetScoreResultInViewSubmissionPage",
                 base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage", "GetScoreResultInViewSubmissionPage",
             base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Close View Submission Button
        /// </summary>
        private void CloseViewSubmissionButton()
        {
            //Close View Submission Button
            Logger.LogMethodEntry("ViewSubmissionPage", "CloseViewSubmissionButton",
                 base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage", "CloseViewSubmissionButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Grades Tab Cmenu Option  
        /// </summary>      
        /// <param name="activityTypeEnum">This is Asset Name</param>
        public void ClickTheGradesTabCmenuOption(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Click The Grades Tab Cmenu Option
            Logger.LogMethodEntry("ViewSubmissionPage", "ClickTheGradesTabCmenuOption",
                 base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage", "ClickTheGradesTabCmenuOption",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check The Asset Name Contains In Grades Tab.
        /// </summary>      
        /// <param name="activityTypeEnum">This is Asset by Type.</param>
        public void CheckTheAssetNameContainsInGradesTab(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Check The Asset Name Contains In Grades Tab
            Logger.LogMethodEntry("ViewSubmissionPage", "CheckTheAssetNameContainsInGradesTab",
                 base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage", "CheckTheAssetNameContainsInGradesTab",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Assigned Items Option
        /// </summary>
        private void SelectAssignedItemsOption()
        {
            //Select Assigned Items Option
            Logger.LogMethodEntry("ViewSubmissionPage", "SelectAssignedItemsOption",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage", "SelectAssignedItemsOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Student click on cmenu option for activity.
        /// </summary>
        /// <param name="assetCmenu">This is Cmenu option.</param>
        /// <param name="activityName">This is activity name.</param>
        public void ClickCmenuOptionByStudentOfActivtiy(string assetCmenu, string activityName)
        {
            base.WaitForElement(By.PartialLinkText(activityName));
            IWebElement getActivityLink = base.GetWebElementPropertiesByPartialLinkText(activityName);
            base.PerformMouseHoverByJavaScriptExecutor(getActivityLink);
            //Get ID of the activity name
            string getCmenuElementID = base.GetIdAttributeValueByPartialLinkText(activityName);
            //Remove the text and get the assetid of the activity
            string cmenuProperty = getCmenuElementID.Remove(0, 8);
            //Generate the asset cmenu icon id by appending the assetID with "tdContext_"
            string cmenuID = "tdContext_" + cmenuProperty;
            string cmenuIconID = cmenuID.Trim();
            // Perform java script mouse click 
            IWebElement getCmenuIcon = base.GetWebElementPropertiesById(cmenuIconID);
            base.PerformMouseClickAction(getCmenuIcon);

            // Launch the cmenu option based on the input provided
            switch (assetCmenu)
            {
                case "View Submissions":
                    //Click on view submission cmenu option
                    IWebElement getViewSubmission = base.GetWebElementPropertiesByXPath(ViewSubmissionPageResource.
                        ViewSubmission_Page_ViewSubmission_Student_ActivityCmenu);
                    base.PerformMouseClickAction(getViewSubmission);
                    break;
            }
        }

        /// <summary>
        /// Get message from view submission popup
        /// </summary>
        /// <returns>This methord returns the message in view submission page.</returns>
        public string GetMessageInViewSubmission()
        {
            //Get Message In Search Catalog
            Logger.LogMethodEntry("CourseCatalogMainPage", "GetMessageInSearchCatalog"
                 , base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getMessage = string.Empty;
            try
            {
                //Select View Submission Window
                this.SelectViewSubmissionWindow();

                // Get grades from view submission popup
                string getGrades = base.GetElementTextByClassName("item3");

                if (getGrades == "--")
                {
                    // Click on the grades based on the match condition
                    IWebElement getGradesProperty = base.GetWebElementPropertiesByClassName(ViewSubmissionPageResource.
                        ViewSubmission_Page_ViewSubmission_Score_ClassName_Locator);
                    base.ClickByJavaScriptExecutor(getGradesProperty);
                    getMessage = base.GetElementTextByClassName(ViewSubmissionPageResource.
                        ViewSubmission_Page_ViewSubmission_GetMessageText_ClassName);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseCatalogMainPage", "GetMessageInSearchCatalog"
                , base.IsTakeScreenShotDuringEntryExit);
            return getMessage;
        }

        /// <summary>
        /// Get message from view submission popup
        /// </summary>
        /// <returns>This methord returns the message in view submission page.</returns>
        public int GetScoreInViewSubmission(int score)
        {
            //Get Message In Search Catalog
            Logger.LogMethodEntry("CourseCatalogMainPage", "GetMessageInSearchCatalog"
                 , base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            int getMessage = 0;
            try
            {
                //Select View Submission Window
                this.SelectViewSubmissionWindow();

                // Get grades from view submission popup
                string getGrades = base.GetElementTextByClassName("item3");

                if (getGrades == "--")
                {
                    // Click on the grades based on the match condition
                    IWebElement getGradesProperty = base.GetWebElementPropertiesByClassName(ViewSubmissionPageResource.
                        ViewSubmission_Page_ViewSubmission_Score_ClassName_Locator);
                    base.ClickByJavaScriptExecutor(getGradesProperty);
                    //getMessage = base.GetElementTextByClassName(ViewSubmissionPageResource.
                    //    ViewSubmission_Page_ViewSubmission_GetMessageText_ClassName);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseCatalogMainPage", "GetMessageInSearchCatalog"
                , base.IsTakeScreenShotDuringEntryExit);
            return getMessage;
        }


        /// <summary>
        /// Get View All Submission Count.
        /// </summary>
        /// <returns>All submission count</returns>
        public String GetViewAllSubmissionCount()
        {
            //Get View All Submission Count
            Logger.LogMethodEntry("ViewSubmissionPage", "GetViewAllSubmissionCount",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage", "GetViewAllSubmissionCount",
                           base.IsTakeScreenShotDuringEntryExit);
            return getSubmissionCount.ToString();
        }

        /// <summary>
        /// Get Student score
        /// </summary>
        /// <returns></returns>
        public string GetStudentScoreViewSubmission()
        {
            Logger.LogMethodEntry("ViewSubmissionPage",
            "GetStudentScore", base.IsTakeScreenShotDuringEntryExit);
            string getScore = string.Empty;
            //Select View Submission Window
            this.SelectViewSubmissionWindow();
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_StudentSubmission_Grade_Id_Locator));
            //Get Score
            getScore = base.GetElementTextById(ViewSubmissionPageResource.
                ViewSubmission_Page_StudentSubmission_Grade_Id_Locator);
            // Eliminate % delimeter from getScore
            getScore = getScore.Replace(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Grade_Delimiter, string.Empty).Trim();
            //close the view submission window
            base.CloseBrowserWindow();
            Logger.LogMethodEntry("ViewSubmissionPage",
            "GetStudentScore", base.IsTakeScreenShotDuringEntryExit);

            return getScore;
        }

        /// <summary>
        /// Expand The Student In ViewSubmission.
        /// </summary>
        private void ExpandTheStudentInViewSubmission()
        {
            //Expand The Student In ViewSubmission
            Logger.LogMethodEntry("ViewSubmissionPage", "ExpandTheStudentInViewSubmission",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage", "ExpandTheStudentInViewSubmission",
                           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select View Submission Window.
        /// </summary>
        private void SelectViewSubmissionWindow()
        {
            //Select View Submission Window
            Logger.LogMethodEntry("ViewSubmissionPage", "SelectViewSubmissionWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Select the window          
            //base.WaitUntilWindowLoads(ViewSubmissionPageResource.
            //    ViewSubmission_Page_ViewSubmission_Window_Name);
            base.SwitchToWindow(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Window_Name);
            Logger.LogMethodExit("ViewSubmissionPage", "SelectViewSubmissionWindow",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Grade from View Submission Page.
        /// </summary>
        /// <returns>Grade</returns>
        public string GetGradefromViewSubmissionPage()
        {
            //Get Grade from View Submission Page
            Logger.LogMethodEntry("ViewSubmissionPage",
                "GetGradefromViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage",
                "GetGradefromViewSubmissionPage",
                           base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("ViewSubmissionPage",
                "ClickOnSaveButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_Save_Button_Id_Locator));
            IWebElement getSaveCloseButton = base.GetWebElementPropertiesById
                (ViewSubmissionPageResource.
                ViewSubmission_Page_Save_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(getSaveCloseButton);
            Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.
                  ViewSubmission_Page_ViewGrade_Button_Time_Value));
            Logger.LogMethodExit("ViewSubmissionPage",
               "ClickOnSaveButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit Grades In ViewSubmission Page.
        /// </summary>
        public void EditGradesInViewSubmissionPage()
        {
            //Edit Grades In ViewSubmission Page
            Logger.LogMethodEntry("ViewSubmissionPage", "EditGradesInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage", "EditGradesInViewSubmissionPage",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Update Button In ViewSubmission.
        /// </summary>
        private void ClickOnUpdateButtonInViewSubmission()
        {
            //Click On Update Button In ViewSubmission
            Logger.LogMethodEntry("ViewSubmissionPage", "ClickOnUpdateButtonInViewSubmission",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_Update_Button_Id_Locator));
            IWebElement getUpdateButton = base.GetWebElementPropertiesById
                (ViewSubmissionPageResource.ViewSubmission_Page_Update_Button_Id_Locator);
            //Click on 'Update' Button
            base.ClickByJavaScriptExecutor(getUpdateButton);
            Logger.LogMethodExit("ViewSubmissionPage", "ClickOnUpdateButtonInViewSubmission",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Update The Grade In ViewSubmission.
        /// </summary>
        private void UpdateTheGradeInViewSubmission()
        {
            //Update The Grade In ViewSubmission
            Logger.LogMethodEntry("ViewSubmissionPage", "UpdateTheGradeInViewSubmission",
               base.IsTakeScreenShotDuringEntryExit);
            //Fill Edit Grade Score Value
            this.FillEditGradeScoreValue(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_ScoreValue);
            //Fill Edit Grade Max Score Value
            this.FillEditGradeMaximumScoreValue(ViewSubmissionPageResource.
                ViewSubmission_Page_MaxValue_ScoreValue);
            Logger.LogMethodExit("ViewSubmissionPage", "UpdateTheGradeInViewSubmission",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Edit Grade ScoreValue.
        /// </summary>
        /// <param name="scoreValue">This is score value</param>
        private void FillEditGradeScoreValue(string scoreValue)
        {
            // Fill Edit Grade ScoreValue
            Logger.LogMethodEntry("ViewSubmissionPage", "FillEditGradeScoreValue",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_ScoreValue_Id_Locator));
            base.ClearTextById(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_ScoreValue_Id_Locator);
            //Fill The Score Value
            base.FillTextBoxById(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_ScoreValue_Id_Locator, scoreValue);
            Logger.LogMethodExit("ViewSubmissionPage", "FillEditGradeScoreValue",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Edit Grade Maximum ScoreValue.
        /// </summary>
        /// <param name="maximumScoreValue">This is maximum score</param>
        private void FillEditGradeMaximumScoreValue(string maximumScoreValue)
        {
            //Fill Edit Grade Maximum ScoreValue
            Logger.LogMethodEntry("ViewSubmissionPage", "FillEditGradeMaximumScoreValue",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_MaxScoreValue_Id_Locator));
            base.ClearTextById(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_MaxScoreValue_Id_Locator);
            //Fill the Max Score Value
            base.FillTextBoxById(ViewSubmissionPageResource.
                ViewSubmission_Page_Input_MaxScoreValue_Id_Locator, maximumScoreValue);
            Logger.LogMethodExit("ViewSubmissionPage", "FillEditGradeMaximumScoreValue",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Edit Link.
        /// </summary>
        private void ClickTheEditLink()
        {
            //Click The Edit Link
            Logger.LogMethodEntry("ViewSubmissionPage", "ClickTheEditLink",
               base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(3000);
            //Wait for the 'Edit' link
            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_Edit_Link_Id_Locator));
            IWebElement getEditLink = base.GetWebElementPropertiesById
                (ViewSubmissionPageResource.ViewSubmission_Page_Edit_Link_Id_Locator);
            //Click on 'Edit' link
            base.ClickByJavaScriptExecutor(getEditLink);
            Logger.LogMethodExit("ViewSubmissionPage", "ClickTheEditLink",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Student Expand Link.
        /// </summary>
        public void ClickTheStudentExpandLink()
        {
            //Click The Student Expand Link
            Logger.LogMethodEntry("ViewSubmissionPage", "ClickTheStudentExpandLink",
               base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage", "ClickTheStudentExpandLink",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Expand Link
        /// </summary>
        private void ClickExpandButton()
        {
            //Click The Expand Link
            Logger.LogMethodEntry("ViewSubmissionPage", "ClickExpandButton",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Allsubmission_Xpath_Locator));
            IWebElement getExpanStudentName = base.GetWebElementPropertiesByXPath
                (ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Allsubmission_Xpath_Locator);
            //Click on Expand student link
            base.ClickByJavaScriptExecutor(getExpanStudentName);
            Logger.LogMethodExit("ViewSubmissionPage", "ClickExpandButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Grade from Student ViewSubmission Page
        /// </summary>
        /// <returns>Grade</returns>
        public String GetGradefromStudentViewSubmissionPage()
        {
            // Get Grade from Student ViewSubmission Page
            Logger.LogMethodEntry("ViewSubmissionPage", "GetGradefromStudentViewSubmissionPage",
               base.IsTakeScreenShotDuringEntryExit);
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
                    ViewSubmission_Page_ViewSubmission_ScoreResult_Char, StringComparison.Ordinal) - Convert.ToInt32
                    (ViewSubmissionPageResource.ViewSubmission_Page_ViewSubmission_Score_SplitValue)),
                    Convert.ToInt32(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Score_SplitValue)).Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage", "GetGradefromStudentViewSubmissionPage",
              base.IsTakeScreenShotDuringEntryExit);
            return getGrade;
        }

        /// <summary>
        /// Get Submitted Grade In ViewSubmission Page.
        /// </summary>
        /// <returns>Get Submitted Grade In ViewSubmission Page.</returns>
        public string GetSubmittedGradeInViewSubmissionPage()
        {
            //Get Submitted Grade In ViewSubmission Page
            Logger.LogMethodEntry("ViewSubmissionPage",
                "GetSubmittedGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage",
                "GetSubmittedGradeInViewSubmissionPage",
                           base.IsTakeScreenShotDuringEntryExit);
            return getScore;
        }

        /// <summary>
        /// Select the Submission Frame
        /// </summary>
        public void SelectTheSubmissionFrame()
        {
            //Select the Submission Frame
            Logger.LogMethodEntry("ViewSubmissionPage",
                "SelectTheSubmissionFrame", base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage",
                "SelectTheSubmissionFrame", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Question Status
        /// </summary>
        /// <returns>Question status</returns>
        public String GetQuestionStatus()
        {
            //Get The Question Status
            Logger.LogMethodEntry("ViewSubmissionPage",
                "GetQuestionStatus", base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage",
                "GetQuestionStatus", base.IsTakeScreenShotDuringEntryExit);
            return getQuestionStatus;
        }

        /// <summary>
        /// Get the Total time taken of SIM Study Plan Pre test on View Submission page. 
        /// </summary>
        /// <returns>Time taken of Pre Test.</returns>
        public String GetTotalTimeTaken()
        {
            //Logger Entry
            Logger.LogMethodEntry("ViewSubmissionPage",
               "GetTotalTimeTaken", base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage",
              "GetTotalTimeTaken", base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("ViewSubmissionPage",
               "GetSubmissionCountInViewSubmission", base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage",
              "GetSubmissionCountInViewSubmission", base.IsTakeScreenShotDuringEntryExit);
            return getSubmissionCount;
        }

        /// <summary>
        /// Select Submission In View Submission Window
        /// </summary>
        public void SelectSubmissionInViewSubmissionWindow()
        {
            //
            Logger.LogMethodEntry("ViewSubmissionPage",
              "SelectSubmissionInViewSubmissionWindow", base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("ViewSubmissionPage",
              "SelectSubmissionInViewSubmissionWindow", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Send Message Option
        /// </summary>
        public void SelectSendMessageOption()
        {
            //Select Send Message Option
            Logger.LogMethodEntry("ViewSubmissionPage",
              "SelectSendMessageOption", base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("ViewSubmissionPage",
            "SelectSendMessageOption", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get SaveForLater Display Message.
        /// </summary>
        /// <returns>Display Message.</returns>
        public string GetSaveForLaterDisplayMessage()
        {
            //Get SaveForLater Display Message
            Logger.LogMethodEntry("ViewSubmissionPage", "GetSaveForLaterDisplayMessage",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("ViewSubmissionPage", "GetSaveForLaterDisplayMessage",
                base.IsTakeScreenShotDuringEntryExit);
            return getDisplayMessage;
        }

        /// <summary>
        /// Expand The Student Submission.
        /// </summary>
        private void ExpandTheStudentSubmission()
        {
            //Expand The Student Submission
            Logger.LogMethodEntry("ViewSubmissionPage", "ExpandTheStudentSubmission",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("ViewSubmissionPage", "ExpandTheStudentSubmission",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit The Manual Grade In View Submission Page.
        /// </summary>
        public void EditTheManualGradeInViewSubmissionPage()
        {
            // Edit The Manual Grade In View Submission Page
            Logger.LogMethodEntry("ViewSubmissionPage",
                "EditTheManualGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("ViewSubmissionPage",
                "EditTheManualGradeInViewSubmissionPage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Submission Count In View Submission.
        /// </summary>
        /// <returns>Submission Count.</returns>
        public string GetAttemptByTheStudentInSubmissionPage()
        {
            //Get Submission Count In View Submission
            Logger.LogMethodEntry("ViewSubmissionPage",
                "GetAttemptByTheStudentInSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("ViewSubmissionPage",
              "GetAttemptByTheStudentInSubmissionPage",
              base.IsTakeScreenShotDuringEntryExit);
            return getSubmissionCount;
        }

        /// <summary>
        /// Edit The Score In ViewSubmission Page.
        /// </summary>
        public void EditTheScoreInViewSubmissionPage()
        {
            //Edit The Score In ViewSubmission Page
            Logger.LogMethodEntry("ViewSubmissionPage",
                "EditTheManualGradeInViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("ViewSubmissionPage",
                "EditTheManualGradeInViewSubmissionPage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Instructor click no "Submit Student's Answer" button in "View Submission" page
        /// </summary>
        /// <param name="pageName">This is page Name.</param>
        public void ClickSubmitStudentAnswerbutton(string buttonName, string pageTitle)
        {
            Logger.LogMethodEntry("ViewSubmissionPage", "ClickSubmitStudentAnswerbutton", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill page loads
                base.WaitUntilPopUpLoads(pageTitle);
                bool llkk = base.IsElementPresent(By.LinkText(buttonName), 5);
                // Wait for "Submit Student's Answer" button to load in "View Submission" page
                base.WaitForElement(By.LinkText(buttonName));
                base.ClickButtonByLinkText(buttonName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage", "ClickSubmitStudentAnswerbutton", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Submission Grade.
        /// </summary>
        public void ClickonSubmissionGrade()
        {
            //Click on Submission Grade
            Logger.LogMethodEntry("ViewSubmissionPage", "ClickonSubmissionGrade",
               base.IsTakeScreenShotDuringEntryExit);
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
                Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.
                    ViewSubmission_Page_SleepTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage", "ClickonSubmissionGrade",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Grade In Student ViewSubmission Page.
        /// </summary>
        /// <returns>Grade.</returns>
        public String GetGradeInStudentViewSubmissionPage()
        {
            // Get Grade In Student ViewSubmission Page
            Logger.LogMethodEntry("ViewSubmissionPage", "GetGradeInStudentViewSubmissionPage",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSplittedGrade = string.Empty;
            try
            {
                //Wait for Element
                base.WaitForElement(By.ClassName(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_ScoreResult_Class_Locator));
                //Get Grade
                string getGrade = base.GetElementTextByClassName(ViewSubmissionPageResource.
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
            Logger.LogMethodExit("ViewSubmissionPage", "GetGradeInStudentViewSubmissionPage",
              base.IsTakeScreenShotDuringEntryExit);
            return getSplittedGrade;
        }

        /// <summary>
        /// Check for "Question was not attempted" message existance.
        /// </summary>
        /// <returns>This returns  Question Was Not Attempted Message Text</returns>
        public string GetDisplayofQuestionWasNotAttemptedMessageText()
        {
            Logger.LogMethodEntry("ViewSubmissionPage", "GetDisplayofQuestionWasNotAttemptedMessageText", base.IsTakeScreenShotDuringEntryExit);
            string DisplayofQuestionWasNotAttemptedMessageText = null;
            try
            {
                // Wait till the popup loads
                base.WaitUntilPopUpLoads(base.GetPageTitle);
                // Check if "Question was not attempted"
                bool getMessageExistance = base.IsElementPresent(By.LinkText(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_QuestionNotAttempted_Text), 5);
                if (getMessageExistance == true)
                {
                    DisplayofQuestionWasNotAttemptedMessageText = ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_QuestionNotAttempted_Text;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage", "GetDisplayofQuestionWasNotAttemptedMessageText", base.IsTakeScreenShotDuringEntryExit);
            return DisplayofQuestionWasNotAttemptedMessageText;
        }

        /// <summary>
        /// Select The Cmenu Option Of Asset.
        /// </summary>
        /// <param name="assetCmenuOptionEnum">This is asset cmenu options.</param>
        /// <param name="assetName">This is Asset name.</param>
        /// <param name="activityTypeEnum">This is asset type enum.</param>
        /// <param name="assetId">Thia is asset Id.</param>
        public void SelectAssetCMenuOption(
          GBInstructorUXPage.AssetCmenuOptionEnum assetCmenuOptionEnum,
          string assetName, Activity.ActivityTypeEnum activityTypeEnum, string assetId)
        {
            //Select The Cmenu Option Of Asset
            Logger.LogMethodEntry("ViewSubmissionPage", "SelectAssetCMenuOption",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click On Cmenu Of Asset
                this.ClickOnCmenuOfAsset(assetCmenuOptionEnum, activityTypeEnum, assetName, assetId);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage", "SelectAssetCMenuOption",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Of Asset.
        /// </summary>
        /// <param name="assetName">This is asset name.</param>
        /// <param name="assetId">Thia is asset Id.</param>
        /// <param name="assetCmenuOptionEnum">This is asset cmenu option name.</param>
        /// <param name="activityTypeEnum">This is asset type enum.</param>
        private void ClickOnCmenuOfAsset(
              GBInstructorUXPage.AssetCmenuOptionEnum assetCmenuOptionEnum,
             Activity.ActivityTypeEnum activityTypeEnum, string assetName, string assetId)
        {
            //Click On Cmenu 
            Logger.LogMethodEntry("ViewSubmissionPage", "ClickOnCmenuOfAsset",
            base.IsTakeScreenShotDuringEntryExit);
            // It opens the c-menu 
            ClickOnCmenuAssetIcon(assetName, assetId);
            switch (assetCmenuOptionEnum)
            {
                //Click the 'View Submission' cmenu
                case GBInstructorUXPage.AssetCmenuOptionEnum.ViewSubmissions:
                    this.SelectViewSubmissionCmenuOption();
                    break;

            }
            Logger.LogMethodExit("ViewSubmissionPage", "ClickOnCmenuOfAsset",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select View Submission Cmenu Option.
        /// </summary>
        private void SelectViewSubmissionCmenuOption()
        {
            //Select View Submission Cmenu Option
            Logger.LogMethodEntry("ViewSubmissionPage", "SelectViewSubmissionCmenuOption",
                                   base.IsTakeScreenShotDuringEntryExit);
            // Wait for the cmenu
            base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                ViewSubmission_Page_Asset_CmenuViewSubmission_Xpath_Locator));
            // Click on the ViewSubmission c-menu
            IWebElement getViewAllSubmissionCmenu = base.GetWebElementPropertiesByXPath
                (ViewSubmissionPageResource.
                ViewSubmission_Page_Asset_CmenuViewSubmission_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getViewAllSubmissionCmenu);
            Logger.LogMethodExit("ViewSubmissionPage", "SelectViewSubmissionCmenuOption",
                                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Cmenu Icon In Asset.
        /// </summary>
        /// <param name="assetName">This is asset name.</param>
        /// <param name="assetId">This is asset Id.</param>
        private void ClickOnCmenuAssetIcon(string assetName, string assetId)
        {
            // Click The Cmenu Icon In Asset
            Logger.LogMethodEntry("ViewSubmissionPage", "ClickTheCmenuIcon",
                         base.IsTakeScreenShotDuringEntryExit);

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
            Logger.LogMethodExit("ViewSubmissionPage", "ClickTheCmenuIcon",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Iframe.
        /// </summary>
        private void SelectIFrame(string assetName)
        {
            //Select IFrame
            Logger.LogMethodEntry("ViewSubmissionPage", "SelectIFrame",
               base.IsTakeScreenShotDuringEntryExit);
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

            Logger.LogMethodExit("ViewSubmissionPage", "SelectIFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Image Icon.
        /// </summary>
        /// <returns></returns>
        private string ClickOnImageIcon(string assetId, string assetName)
        {
            Logger.LogMethodEntry("ViewSubmissionPage", "ClickOnImageIcon",
            base.IsTakeScreenShotDuringEntryExit);
            // Modified the xpath for the To Do tab based on the assetid
            string strViewSubmissionXpath = ViewSubmissionPageResource.ViewSubmission_Page_Asset_ToDo_Cmenuicon_Xpath_Locator;
            base.PerformMouseHoverAction(base.GetWebElementPropertiesByPartialLinkText(assetName));
            strViewSubmissionXpath = strViewSubmissionXpath.Replace("assetId", assetId);
            if (base.IsElementPresent(By.XPath(strViewSubmissionXpath), 5)) { }
            else
            {
                // Modified the xpath for the Assignment/CourseMaterial/Completed based on the assetid
                strViewSubmissionXpath = ViewSubmissionPageResource.ViewSubmission_Page_Asset_Cmenuicon_Xpath_Locator;
                strViewSubmissionXpath = strViewSubmissionXpath.Replace("assetId", assetId);

            }
            Logger.LogMethodExit("ViewSubmissionPage", "ClickOnImageIcon",
            base.IsTakeScreenShotDuringEntryExit);
            return strViewSubmissionXpath;
        }

        /// <summary>
        /// Get Submission Score In View Submission Page.
        /// </summary>
        /// <returns>This is Submission Score.</returns>
        public string GetSubmissionScoreInViewSubmissionPage()
        {
            //Get Submission Score In View Submission Page
            Logger.LogMethodEntry("ViewSubmissionPage",
                "GetSubmissionScoreInViewSubmissionPage",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSubmissionScore = string.Empty;
            try
            {
                //Click on Submission Grade
                this.ClickonSubmissionGrade();
                bool dfdf = base.IsElementPresent(By.Id(ViewSubmissionPageResource.
                    ViewSubmission_Page_GradeScore_Id_Locator), 10);
                //Get Submission Grade
                getSubmissionScore = base.GetElementTextById(ViewSubmissionPageResource.
                    ViewSubmission_Page_GradeScore_Id_Locator);
                getSubmissionScore = (Regex.Split(getSubmissionScore,
                    ": (.*)%")[1]).Split('.')[0];
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage",
                "GetSubmissionScoreInViewSubmissionPage",
            base.IsTakeScreenShotDuringEntryExit);
            return getSubmissionScore;
        }

        /// <summary>
        /// Get Submission Score In View Submission for a student
        /// </summary>
        /// <returns>This is Submission Score.</returns>
        public string GetSubmissionScoreByStudent(string lastname, string firstname)
        {
            //Get Submitted Grade In ViewSubmission Page
            Logger.LogMethodEntry("ViewSubmissionPage",
                "GetSubmissionScoreByStudent",
                base.IsTakeScreenShotDuringEntryExit);
            //Intialize the variable
            string getScore = string.Empty;
            try
            {
                // Get student property by searching sent student
                IWebElement getStudentProperty = this.SearchStudentByLastAndFirstName(lastname, firstname);
                // Click on student index
                this.ClickStudent(getStudentProperty);
                //Select View Submission Window
                this.SelectViewSubmissionWindow();
                base.WaitForElement(By.Id(ViewSubmissionPageResource.
                    ViewSubmission_Page_StudentSubmission_Grade_Id_Locator));
                //Get Score
                getScore = base.GetElementTextById(ViewSubmissionPageResource.
                    ViewSubmission_Page_StudentSubmission_Grade_Id_Locator);
                // Eliminate % delimeter from getScore
                getScore = getScore.Replace(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Grade_Delimiter, string.Empty).Trim();
                //close the view submission window
                base.CloseBrowserWindow();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage",
                "GetSubmissionScoreInViewSubmissionPageHEDCore",
                           base.IsTakeScreenShotDuringEntryExit);
            return getScore;
        }

        /// <summary>
        /// This private function will return web element of given student
        /// </summary>
        /// <param name="lastname">last name of the student</param>
        /// <param name="firstname">first name of the student</param>
        /// <returns></returns>
        public IWebElement SearchStudentByLastAndFirstName(string lastname, string firstname)
        {
            Logger.LogMethodEntry("ViewSubmissionPage",
            "SearchStudentByLastAndFirstName", base.IsTakeScreenShotDuringEntryExit);
            string name = lastname + ", " + firstname;
            IWebElement getSubmissionGradeProperty = null;
            //Intialize the variable
            string getScore = string.Empty;
            //Select View Submission Window
            this.SelectViewSubmissionWindow();
            base.WaitForElement(By.XPath(ViewSubmissionPageResource.
               ViewSubmission_Page_ViewSubmission_Xpath_Locator));
            int studentCount = base.GetElementCountByXPath(ViewSubmissionPageResource.ViewSubmission_Page_ViewSubmission_Xpath_Locator);
            for (int studentIndex = Convert.ToInt16(ViewSubmissionPageResource.ViewSubmission_Page_Index_Value_One);
                studentIndex <= studentCount; studentIndex++)
            {
                string getStudent = base.GetTitleAttributeValueByXPath(
                    String.Format(ViewSubmissionPageResource.ViewSubmission_Page_ViewSubmission_Student_Xpath_Locator, studentIndex));
                base.WaitForElement(By.XPath(
                    string.Format(ViewSubmissionPageResource.ViewSubmission_Page_ViewSubmission_Student_Xpath_Locator, studentIndex)));

                if (getStudent == name)
                {
                    // Get web element for the particulat student index
                    getSubmissionGradeProperty =
                        base.GetWebElementPropertiesByXPath(
                        string.Format(ViewSubmissionPageResource.ViewSubmission_Page_ViewSubmission_Student_Xpath_Locator, studentIndex));
                    break;
                }
            }
            Logger.LogMethodExit("ViewSubmissionPage",
                    "SearchStudentByLastAndFirstName", base.IsTakeScreenShotDuringEntryExit);
            return getSubmissionGradeProperty;
        }
        /// <summary>
        /// Click on particular student by combination of last and first name
        /// </summary>
        /// <param name="getStudentProperty">This is webelement property.</param>
        public void ClickStudent(IWebElement getStudentProperty)
        {
            Logger.LogMethodEntry("ViewSubmissionPage",
            "ClickStudent", base.IsTakeScreenShotDuringEntryExit);
            // Click on particular student index
            base.ClickByJavaScriptExecutor(getStudentProperty);
            Thread.Sleep(Convert.ToInt32(ViewSubmissionPageResource.ViewSubmission_Page_SleepTime_Value));
            Logger.LogMethodExit("ViewSubmissionPage",
                "ClickStudent", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Student score
        /// </summary>
        /// <returns></returns>
        public string GetStudentScore()
        {
            Logger.LogMethodEntry("ViewSubmissionPage",
            "GetStudentScore", base.IsTakeScreenShotDuringEntryExit);
            string getScore = string.Empty;
            //Select View Submission Window
            this.SelectViewSubmissionWindow();

            base.WaitForElement(By.Id(ViewSubmissionPageResource.
                ViewSubmission_Page_StudentSubmission_Grade_Id_Locator));
            //Get Score
            getScore = base.GetElementTextById(ViewSubmissionPageResource.
                ViewSubmission_Page_StudentSubmission_Grade_Id_Locator);
            // Eliminate % delimeter from getScore
            getScore = getScore.Replace(ViewSubmissionPageResource.
                ViewSubmission_Page_ViewSubmission_Grade_Delimiter, string.Empty).Trim();
            //close the view submission window
            base.CloseBrowserWindow();
            Logger.LogMethodEntry("ViewSubmissionPage",
            "GetStudentScore", base.IsTakeScreenShotDuringEntryExit);

            return getScore;
        }
        /// <summary>
        /// Select Last Submission from Submission List In View Submission Window.
        /// </summary>
        public void SelectLastSubmissionInViewSubmissionWindow()
        {
            //
            Logger.LogMethodEntry("ViewSubmissionPage",
            "SelectLastSubmissionInViewSubmissionWindow", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the View Submission window
                this.SelectViewSubmissionWindow();

                //Get the Collection of all the Submission in Submission List
                ICollection<IWebElement> getAllSubmissionsInSubmissionList = base.GetWebElementsCollectionByClassName(
                ViewSubmissionPageResource.ViewSubmission_Page_ViewSubmission_Score_ClassName_Locator);

                //Get the Last submission from the collection of Submissions in Submission List
                IWebElement getLastSubmission = getAllSubmissionsInSubmissionList.Last();

                //Click the score link
                base.ClickByJavaScriptExecutor(getLastSubmission);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("ViewSubmissionPage",
            "SelectLastSubmissionInViewSubmissionWindow", base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify Gradebook Grade value On ViewSubmission Page.
        /// </summary>
        /// <returns></returns>
        public string GetGradebookGradeOnViewSubmissionPage()
        {
            //get Gradebook Grade text from View Submission page
            string getGradebookGradeText = base.GetElementTextByXPath(ViewSubmissionPageResource.
            ViewSubmission_Page_GradebookGrade_XPath_Locator);

            //Split Gradebook Grade text from View Submission page to get Grade Value component
            string[] getGradebookGradeTextElements = getGradebookGradeText.Split(Convert.ToChar(
            ViewSubmissionPageResource.ViewSubmission_Page_StatusSpecialCharacter_Char));

            //populate Gradebook Grade from View Submission page
            string gradebookGrade = getGradebookGradeTextElements[1].ToString(CultureInfo.InvariantCulture).Trim();

            //return Gradebook Grade from View Submission page
            return gradebookGrade;
        }

        /// <summary>
        /// Verify Decline and Accept Option Displayed in View Submission Page for Past Due Submission.
        /// </summary>
        /// <param name="declineOption">This is Decline Option.</param>
        /// <param name="acceptOption">This is Accept Option.</param>
        public Boolean IsDeclineAcceptOptionDisplayed(string declineOption, string acceptOption)
        {
            //Verify Decline and Accept Option Displayed in View Submission Page for Past Due Submission
            Logger.LogMethodEntry("ViewSubmissionPage",
                "IsDeclineAcceptOptionDisplayed",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isDeclineOptionDisplayed = false;
            bool isAcceptOptionDisplayed = false;
            try
            {
                //Click on Submission Grade
                this.ClickonSubmissionGrade();
                //Verify Decline Option Displayed
                isDeclineOptionDisplayed =
                    base.IsElementDisplayedByPartialLinkText(declineOption);
                //Verify Accept Option Displayed
                isAcceptOptionDisplayed =
                    base.IsElementDisplayedByPartialLinkText(acceptOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage",
                "IsDeclineAcceptOptionDisplayed",
            base.IsTakeScreenShotDuringEntryExit);
            return (isDeclineOptionDisplayed && isAcceptOptionDisplayed);
        }

        /// <summary>
        /// Click On Button In View Submission Page.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        public void ClickOnButtonInViewSubmissionPage(string buttonName)
        {
            //Click On Button In View Submission Page
            Logger.LogMethodEntry("ViewSubmissionPage",
                "ClickOnButtonInViewSubmissionPage",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select View Submission Window
                this.SelectViewSubmissionWindow();
                //Get Button Property
                IWebElement getButtonProperty =
                    base.GetWebElementPropertiesByPartialLinkText(buttonName);
                //Click on Button
                base.ClickByJavaScriptExecutor(getButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage",
                "ClickOnButtonInViewSubmissionPage",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Decline and Accept Option Displayed in View Submission Page for Past Due Submission.
        /// </summary>
        /// <param name="declineOption">This is Decline Option.</param>
        /// <param name="acceptOption">This is Accept Option.</param>
        public Boolean IsDeclineAcceptOptionDisplayedInstructor(string declineOption, string acceptOption)
        {
            //Verify Decline and Accept Option Displayed in View Submission Page for Past Due Submission
            Logger.LogMethodEntry("ViewSubmissionPage",
                "IsDeclineAcceptOptionDisplayedInstructor",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isDeclineOptionDisplayed = false;
            bool isAcceptOptionDisplayed = false;
            try
            {
                //Verify Decline Option Displayed
                isDeclineOptionDisplayed =
                    base.IsElementDisplayedByPartialLinkText(declineOption);
                //Verify Accept Option Displayed
                isAcceptOptionDisplayed =
                    base.IsElementDisplayedByPartialLinkText(acceptOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage",
                "IsDeclineAcceptOptionDisplayedInstructor",
            base.IsTakeScreenShotDuringEntryExit);
            return (isDeclineOptionDisplayed && isAcceptOptionDisplayed);
        }

        /// <summary>
        /// Click on the given student in View Submission page.
        /// </summary>
        /// <param name="studentName">This is the Student Name</param>
        public void ClickStudentByLastAndFirstName(string studentName)
        {
            Logger.LogMethodEntry("ViewSubmissionPage",
            "SearchStudentByLastAndFirstName", base.IsTakeScreenShotDuringEntryExit);
            //Intialize the variable
            string getScore = string.Empty;
            //Select View Submission Window
            try
            {
                this.SelectViewSubmissionWindow();
                base.WaitForElement(By.XPath(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Xpath_Locator), 10);
                int studentCount = base.GetElementCountByXPath(ViewSubmissionPageResource.
                    ViewSubmission_Page_ViewSubmission_Xpath_Locator);
                for (int studentIndex = Convert.ToInt16(ViewSubmissionPageResource.
                    ViewSubmission_Page_Index_Value_One);
                    studentIndex <= studentCount; studentIndex++)
                {
                    string getStudent = base.GetTitleAttributeValueByXPath(
                        String.Format(ViewSubmissionPageResource.
                        ViewSubmission_Page_ViewSubmission_Student_Xpath_Locator,
                        studentIndex));
                    base.WaitForElement(By.XPath(
                        string.Format(ViewSubmissionPageResource.
                        ViewSubmission_Page_ViewSubmission_Student_Xpath_Locator,
                        studentIndex)));

                    if (getStudent == studentName)
                    {
                        // Get web element for the particular student and click
                        IWebElement getStudentName = base.
                            GetWebElementPropertiesByXPath(
                             string.Format(ViewSubmissionPageResource.
                             ViewSubmission_Page_ViewSubmission_Student_Xpath_Locator,
                             studentIndex));
                        base.ClickByJavaScriptExecutor(getStudentName);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage",
                    "SearchStudentByLastAndFirstName", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Provide feedback to the student.
        /// </summary>
        /// <param name="feedbackText">This is the Feedback that has to be given.</param>
        public void InstructorFeedbackToStudent(string feedbackText)
        {
            //Provide feedback to the student
            Logger.LogMethodEntry("ViewSubmissionPage",
                        "InstructorFeedbackToStudent",
                        base.IsTakeScreenShotDuringEntryExit);
            this.SelectViewSubmissionWindow();
            try
            {
                //Click on 'Add Feedback'
                base.WaitForElement(By.PartialLinkText(ViewSubmissionPageResource.
                    ViewSubmission_Page_AddFeedback_PartialLinkText_Locator));
                IWebElement getFeedbackButton = base.
                GetWebElementPropertiesByPartialLinkText(ViewSubmissionPageResource.
                    ViewSubmission_Page_AddFeedback_PartialLinkText_Locator);
                base.ClickByJavaScriptExecutor(getFeedbackButton);
                base.SwitchToLastOpenedWindow();
                //Enter the Feedback in the textbox
                base.FillTextBoxById(ViewSubmissionPageResource.
                  ViewSubmission_Page_FeedbackTextbox_Id_Locator, feedbackText);
                //CLick on 'Save'
                IWebElement getSaveButton = base.GetWebElementPropertiesByCssSelector
                    (ViewSubmissionPageResource.ViewSubmission_Page_Feedback_Save_Button_CssSelector_Locator);
                base.ClickByJavaScriptExecutor(getSaveButton);
                // close pop up in case is open
                if (!base.IsPopUpClosed(3, 5))
                {
                    base.CloseBrowserWindow();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage",
                    "InstructorFeedbackToStudent",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save and close the 'View Submission' window.
        /// </summary>
        /// <param name="buttonName">This is the button name.</param>
        public void SaveAndCloseViewSubmission(string buttonName)
        {
            //Save and close the 'View Submission' window
            Logger.LogMethodEntry("ViewSubmissionPage", "SaveAndCloseViewSubmission",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectViewSubmissionWindow();
                base.WaitForElement(By.PartialLinkText(buttonName));
                IWebElement getSaveAndClose =
                    base.GetWebElementPropertiesByPartialLinkText(buttonName);
                base.ClickByJavaScriptExecutor(getSaveAndClose);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage", "SaveAndCloseViewSubmission",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Instructor grading student for WL Essay Activity.
        /// </summary>
        /// <param name="score">This is the activity score.</param>
        public void InstructorgradingStudentforWorldLanguageEssayActivity(string score)
        {
            //Instructor grading student for WL Essay Activity
            Logger.LogMethodEntry("ViewSubmissionPage", "InstructorgradingStudentforWorldLanguageEssayActivity",
                    base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selecting Window.
                this.SelectViewSubmissionWindow();
                //Get essay question count.
                int getCount = base.GetElementCountByXPath(
                    ViewSubmissionPageResource.
                    ViewSubmission_Page_QuestionCount_XPath_Locator);
                for (int i = 3; i <= getCount; i++)
                {
                    IWebElement getactivityId = base.
                        GetWebElementPropertiesByCssSelector(
                        string.Format(ViewSubmissionPageResource.
                        ViewSubmission_Page_ActivityID_CSS_Locator, i));
                    string activityId = getactivityId.GetAttribute(
                        ViewSubmissionPageResource.
                        ViewSubmission_Page_Activity_Attribute);
                    string textactivityId = activityId.Split('_')[1];
                    string activityInputId = ViewSubmissionPageResource.
                 ViewSubmission_Page_Activity_InputId + '_' + textactivityId;
                    //Fill the textbox with score 
                    base.WaitForElement(By.Id(activityInputId));
                    base.FillTextBoxById(activityInputId, score);
                }
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("ViewSubmissionPage", "InstructorgradingStudentforWorldLanguageEssayActivity",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Submission Score In View Submission for a student
        /// </summary>
        /// <param name="lastname">This is the Student Lastname of the user.</param>
        /// <param name="firstname">This is the Student Firstname of the user.</param>
        /// <returns>This is Submission Score.</returns>
        public string GetEditedSubmissionScore(string lastname, string firstname)
        {
            //Get Submitted Grade In ViewSubmission Page
            Logger.LogMethodEntry("ViewSubmissionPage",
                "GetSubmissionScoreByStudent",
                base.IsTakeScreenShotDuringEntryExit);
            //Intialize the variable
            string getScore = string.Empty;
            try
            {
                // Get student property by searching sent student
                IWebElement getStudentProperty = this.SearchStudentByLastAndFirstName(lastname, firstname);
                // Click on student index
                this.ClickStudent(getStudentProperty);

                //Select View Submission Window
                this.SelectViewSubmissionWindow();
               
                //Get Score
                getScore = base.GetElementTextByCssSelector(
                    ViewSubmissionPageResource.ViewSubmission_Page_ViewSubmission_GetScore_CSS_Locator);

                // Eliminate % delimeter from getScore
                getScore = getScore.Replace("%", string.Empty).Trim();
                //close the view submission window
              

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ViewSubmissionPage",
                "GetSubmissionScoreInViewSubmissionPageHEDCore",
                           base.IsTakeScreenShotDuringEntryExit);
            return getScore;
        }
        /// <summary>
        /// Edit The Manual Grade In View Submission Page.
        /// </summary>
        public void EditTheGradeInViewSubmissionPageByBBIns(Grade.GradeTypeEnum gradeTypeEnum)
        {
            // Edit The Manual Grade In View Submission Page
            Logger.LogMethodEntry("ViewSubmissionPage",
                "EditTheGradeInViewSubmissionPageByBBIns",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Edit Grade
                string editGrade = ViewSubmissionPageResource.ViewSubmission_Page_GradeTextbox_Value;
                this.EditGradeInViewSubmissionBBIns();
                this.ClickOnSaveButton();
                // Store edited grades
                this.StoreGradeDetails(gradeTypeEnum, editGrade);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("ViewSubmissionPage",
                "EditTheGradeInViewSubmissionPageByBBIns",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// BlackBoard instructor edit grades in View submission page.
        /// </summary>
        private void EditGradeInViewSubmissionBBIns()
        {
            // Edit The Manual Grade In View Submission Page
            Logger.LogMethodEntry("ViewSubmissionPage",
                "EditGradeInViewSubmissionBBIns",
                base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("ViewSubmissionPage",
                "EditGradeInViewSubmissionBBIns",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Stores Grade Details in Memory.
        /// </summary>
        /// <param name="gradeTypeEnum">This is Grade by Type.</param>
        /// <param name="editGrade">This is edited grade value.</param>        
        public void StoreGradeDetails(Grade.GradeTypeEnum gradeTypeEnum, string editGrade)
        {
            //Stores User Details in Memory

            Logger.LogMethodEntry("AddUserPage", "StoreGradeDetails"
                , base.IsTakeScreenShotDuringEntryExit);
            switch (gradeTypeEnum)
            {
                case Grade.GradeTypeEnum.BBEditedGrade:
                case Grade.GradeTypeEnum.BBNewGrade:
                case Grade.GradeTypeEnum.PegasusEditedGrade:
                case Grade.GradeTypeEnum.PegasusNewGrade:
                    //Wait to Pop Up Get Close Successfully
                    if (base.IsPopUpClosed(3))
                    {
                        //Store User Details in Memory
                        this.StoreGradeDetailsInMemory(gradeTypeEnum, editGrade);
                    }
                    break;
            }
            Logger.LogMethodExit("AddUserPage", "StoreUserDetails"
                , base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Saving the Grade Details in Memory
        /// </summary>
        /// <param name="gradeTypeEnum">This is Grade Type Enum</param>
        /// <param name="editGrade">This is edited grade</param>
        private void StoreGradeDetailsInMemory(Grade.GradeTypeEnum gradeTypeEnum, string editGrade)
        {
            //Save user in Memory
            Logger.LogMethodEntry("AddUserPage", "StoreGradeDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            //Save User Properties in Memory
            switch (gradeTypeEnum)
            {
                case Grade.GradeTypeEnum.BBEditedGrade:
                case Grade.GradeTypeEnum.BBNewGrade:
                case Grade.GradeTypeEnum.PegasusEditedGrade:
                case Grade.GradeTypeEnum.PegasusNewGrade:
                    {
                        //Save Student Details
                        this.SaveGradeInMemory(gradeTypeEnum, editGrade);
                    }
                    break;
            }
            Logger.LogMethodExit("AddUserPage", "StoreGradeDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save Grade In Memory
        /// </summary>
        /// <param name="GradeTypeEnum">This is Grade Type Enum</param>
        /// <param name="editGrade">This is editted grade</param>
        private void SaveGradeInMemory(Grade.GradeTypeEnum gradeTypeEnum, string editGrade)
        {
            //Save The User In Memory
            Logger.LogMethodEntry("AddUserPage", "SaveUserInMemory",
              base.IsTakeScreenShotDuringEntryExit);
            Grade grade = new Grade
            {
                Score = editGrade,
                GradeType = gradeTypeEnum,
                IsCreated = true,
            };
            //Save The User In Memory
            grade.StoreGradeInMemory();
            Logger.LogMethodExit("AddUserPage", "SaveUserInMemory",
              base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
