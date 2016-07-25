using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.ViewSubmission;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus GBDefaultUX Page Actions
    /// </summary>
    public class GBDefaultUXPage:BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(GBDefaultUXPage));

        /// <summary>
        ///Get writing Space Activity Name In Gradebook.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Name.</returns>
        public String GetWritingSpaceActivityNameInGradebook(string activityName)
        {
            logger.LogMethodEntry("GBDefaultUXPage", "GetWritingSpaceActivityNameInGradebook",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialized Variable
            string getActivityName = string.Empty;
            try
            {                
                //Select Course Home Window
                new CourseContentUXPage().SelectFrameInWindow(GBDefaultUXPageResource.
                    GBDefaultUXPage_Gradebook_CourseHome_Window,
                    GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_Center_Frame);
                //Switch to Frame
                base.SwitchToIFrame(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Synapse_GradesFrame_Iframe_Name_Locator);
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                //Getting the counts of Activity                    
                int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator);
                for (int activityColumnNo = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); activityColumnNo <= getActivityCount;
                activityColumnNo++)
                {
                    //Wait for Element
                    base.WaitForElement(By.XPath(string.Format(GBDefaultUXPageResource.
                        GBDefaultUXPage_Gradebook_ActivityName_Xpath_Locator, activityColumnNo)));
                    //Getting the Activity name
                    getActivityName = base.GetTitleAttributeValueByXPath
                        (string.Format(GBDefaultUXPageResource.
                        GBDefaultUXPage_Gradebook_ActivityName_Xpath_Locator, activityColumnNo));
                    if (getActivityName.Contains(activityName))
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBDefaultUXPage", "GetWritingSpaceActivityNameInGradebook",
                          base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        ///Get Activity Name In Gradebook.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Name.</returns>
        public String GetActivityNameInGradebook(string activityName)
        {
            logger.LogMethodEntry("GBDefaultUXPage", "GetActivityNameInGradebook",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialized Variable
            string getActivityName = string.Empty;
            try
            {
                //Select Course Home Window
                new CourseContentUXPage().SelectFrameInWindow(GBDefaultUXPageResource.
                    GBDefaultUXPage_Gradebook_CourseHome_Window,
                    GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_Center_Frame);               
                base.WaitForElement(By.Id(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Synapse_GradesFrame_Iframe_Name_Locator));
                //Switch to Frame
                base.SwitchToIFrame(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Synapse_GradesFrame_Iframe_Name_Locator);
                base.WaitForElement(By.XPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator));
                //Getting the counts of Activity                    
                int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator);
                for (int activityColumnNo = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); activityColumnNo <= getActivityCount;
                activityColumnNo++)
                {
                    //Wait for Element
                    base.WaitForElement(By.XPath(string.Format(GBDefaultUXPageResource.
                         GBDefaultUXPage_Gradebook_GetActivityCount_Xpath_Locator, activityColumnNo)));
                    //Getting the Activity name
                    getActivityName = base.GetTitleAttributeValueByXPath
                        (string.Format(GBDefaultUXPageResource.
                       GBDefaultUXPage_Gradebook_GetActivityCount_Xpath_Locator, activityColumnNo));
                    if (getActivityName.Contains(activityName))
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBDefaultUXPage", "GetActivityNameInGradebook",
                          base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Get Writing Space Activity Score.
        /// </summary> 
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="userLastName">This is User Last name.</param>
        /// <param name="userFirstName">This is User First Name.</param>
        /// <returns>Activity Score.</returns>
        public String GetWritingSpaceActivityScore(string activityName, string userLastName,
            string userFirstName)
        {
            //Get Writing Space Activity Score
            logger.LogMethodEntry("GBDefaultUXPage", "GetWritingSpaceActivityScore",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getActivityGrade = string.Empty;
            try
            {               
                //Select the course home window
                new CourseHomeListItemViewPage().SelectCourseHomeWindow();                
                //Switch to Frame
                base.SwitchToIFrame(GBInstructorUXPageResource.
                    GBInstructorUX_Page_Synapse_GradesFrame_Iframe_Name_Locator);
                //Get Activity Score
                getActivityGrade =new GBInstructorUXPage().
                    GetActivityStatus(activityName, userLastName,userFirstName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBDefaultUXPage", "GetWritingSpaceActivityScore",
                          base.IsTakeScreenShotDuringEntryExit);
            return getActivityGrade;
        }


        /// <summary>
        /// Select The Cmenu Option Of Asset.
        /// </summary>
        /// <param name="assetCmenuOptionEnum">This is Asset cmenu options.</param>
        /// <param name="assetName">This is Asset name.</param>
        public void SelectTheCmenuOptionOfAssetK12(
            String assetCmenuOption, string assetName)
        {
            //Select The Cmenu Option Of Asset
            logger.LogMethodEntry("GBInstructorUXPage", "SelectTheCmenuOptionOfAssetHED",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill Gradebook page loads
                base.WaitUntilWindowLoads(GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_Page_Name);
                // Switch to Iframe in the Gradebook
                base.SwitchToIFrameById(GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_Frame);
                // Get activity count
                int getActivityCount = base.GetElementCountByXPath(GBDefaultUXPageResource.
                    GBDefaultUXPage_Gradebook_NormalActivityName_Xpath_Locator);
                //Getting the counts of Activity
                for (int columnCount = Convert.ToInt32(GBInstructorUXPageResource.
                        GBInstructorUX_Page_Initial_Value); columnCount <= getActivityCount;
                        columnCount++)
                {
                    {
                        //Getting the Activity name
                        string getActivityName = base.GetTitleAttributeValueByXPath(string.Format(
                            GBDefaultUXPageResource.
                            GBDefaultUXPage_Gradebook_GetActivityName_Xpath_Locator, columnCount));
                        if (getActivityName.Trim() == assetName.Trim())
                        {
                            // Click cmenu icon
                            this.activityCmenuOption(columnCount);
                            //Click View Submission C-menu option of activity
                            this.ClickViewSubmissionCmenuOption(assetCmenuOption);
                            break;
                        }
                    }
                    logger.LogMethodExit("GBInstructorUXPage", "GetActivityColumnCountHED",
                   base.IsTakeScreenShotDuringEntryExit);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "SelectTheCmenuOptionOfAssetHED",
             base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click Cmenu icon of activity in Gradebook
        /// </summary>
        /// <param name="activityColumnCount">Activity column count</param>
        public void activityCmenuOption(int activityColumnCount)
        {
            logger.LogMethodEntry("GBDefaultUXPage", "activityCmenuOption",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for the cmenu icon
            base.WaitForElement(By.XPath(String.Format(GBDefaultUXPageResource.
                GBDefaultUXPage_Gradebook_GetActivityName_Xpath_Locator, activityColumnCount)));
            //Get Element Property
            IWebElement getCmenuIconProperty = base.GetWebElementPropertiesByXPath
                (String.Format(GBDefaultUXPageResource.
                GBDefaultUXPage_Gradebook_GetActivityName_Xpath_Locator, activityColumnCount));
            //Perform Mouse Click Action
            base.PerformMouseClickAction(getCmenuIconProperty);
            // Click the Cmenu icon
            IWebElement CmenuIconProperty = base.GetWebElementPropertiesByXPath
                    (String.Format(GBDefaultUXPageResource.
                    GBDefaultUXPage_Gradebook_ActivityCmenu_Xpath_Locator, activityColumnCount));
            base.ClickByJavaScriptExecutor(CmenuIconProperty);
            logger.LogMethodExit("GBDefaultUXPage", "activityCmenuOption",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click View Submimssion Cmenu option of the activity
        /// </summary>
        public void ClickViewSubmissionCmenuOption(string assetCmenuOption)
        {
            // Click cmenu option "View Submission"
            logger.LogMethodEntry("GBDefaultUXPage", "ClickViewSubmissionCmenuOption",
            base.IsTakeScreenShotDuringEntryExit);
            base.ClickLinkByPartialLinkText(assetCmenuOption);
            logger.LogMethodExit("GBDefaultUXPage", "ClickViewSubmissionCmenuOption",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click On View Grades Button of Asset In Gradebook.
        /// </summary>
        /// <param name="assetName">Asset Name</param>
        public void ClickViewGradesButton(string assetName)
        {
            //Click On View Grades Button of Asset
            logger.LogMethodEntry("GBDefaultUXPage", "ClickViewGradesButton",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Swith to Iframe at Student's Gradebook in DP
                GBInstructorUXPage gbInstructorPage = new GBInstructorUXPage();
                //Select Frame
                gbInstructorPage.SelectGradebookFrame();
                // Get activity count
                int getActivityCount = base.GetElementCountByXPath(GBDefaultUXPageResource.
                    GBDefaultUXPage_Gradebook_NormalActivityName_Xpath_Locator);
                //Getting the counts of Activity
                for (int columnCount = Convert.ToInt32(GBDefaultUXPageResource.
                        GBDefaultUXPage_Page_Initial_Count_Value); columnCount <= getActivityCount;
                        columnCount++)
                {
                    {
                        //Getting the Activity name
                        string getActivityName = base.GetTitleAttributeValueByXPath(string.Format
                            (GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_GetActivityName_Xpath_Locator,
                            columnCount));
                        //Check if the activity name retrived from the application is same as the 
                        //input activity name
                        if (getActivityName.Trim() == assetName.Trim())
                        {
                            // Click On View Grades Button of Asset
                            bool pres = base.IsElementPresent(By.XPath(string.Format(GBDefaultUXPageResource.
                                GBDefaultUXPage_Gradebook_ViewGradesButton_Xpath_Locator, columnCount)), 10);
                            base.ClickButtonByXPath(string.Format(GBDefaultUXPageResource.
                                GBDefaultUXPage_Gradebook_ViewGradesButton_Xpath_Locator, columnCount));
                            break;
                        }
                    }
                    logger.LogMethodExit("GBDefaultUXPage", "ClickViewGradesButton",
                   base.IsTakeScreenShotDuringEntryExit);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Swith to Iframe at Student's Gradebook in DP.
        /// </summary>
        private void SwitchToDPStudentGradebookIFrame()
        {
            // Swith to Iframe at Student's Gradebook in DP
            logger.LogMethodEntry("GBDefaultUXPage", "SwitchToDPStudentGradebookIFrame",
                base.IsTakeScreenShotDuringEntryExit);
            // Wait untill Gradebook page loads
            base.WaitUntilWindowLoads(GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_Page_Name);
            //Wait for Element         
            base.WaitForElement(By.Id(GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_Frame));
            // Switch to Iframe in the Gradebook
            base.SwitchToIFrameById(GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_Frame);
            logger.LogMethodExit("GBDefaultUXPage", "SwitchToDPStudentGradebookIFrame",
                   base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        ///Click View All Submissions option in teacher gradebook.
        /// </summary>
        /// <param name="cmenuName">This is Cmenu option Name.</param>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Name.</returns>
        public void ClickViewAllSubmissionsInGradebookK12(string cmenuName, string activityName)
        {
            logger.LogMethodEntry("GBDefaultUXPage", "ClickViewAllSubmissionsInGradebookK12",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialized Variable
            string getActivityName = string.Empty;
            try
            {
                this.SwitchToTeacherGradebookIframe();
                // Getting the counts of Activity  
                int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator);
                for (int activityColumnNo = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); activityColumnNo <= getActivityCount;
                activityColumnNo++)
                {
                    // Getting the Activity name
                    getActivityName = base.GetTitleAttributeValueByXPath
                        (string.Format(GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_ActivityName_Xpath_Locator,
                        activityColumnNo));
                    if (getActivityName.Trim() == activityName.Trim())
                    {
                        // Click view submission option in the activity cmenu
                        this.ClickViewSubmissionOption(activityColumnNo, activityName);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBDefaultUXPage", "ClickViewAllSubmissionsInGradebookK12",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to Iframe in Instructor gradebook.
        /// </summary>
        private void SwitchToTeacherGradebookIframe()
        {
            logger.LogMethodEntry("GBDefaultUXPage", "SwitchToTeacherGradebookIframe",
            base.IsTakeScreenShotDuringEntryExit);
            // Switch to iFrame
              base.SwitchToIFrameBySource(GBDefaultUXPageResource.
                GBDefaultUXPage_Page_CourseContent_Iframe_srcText);

            base.SwitchToIFrameBySource(GBDefaultUXPageResource.
                GBDefaultUXPage_Page_srcGBFrame_Iframe_srcText);
            logger.LogMethodExit("GBDefaultUXPage", "SwitchToTeacherGradebookIframe",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        ///Click View Submission option for StudyPlan in Gradbook.
        /// </summary>
        /// <param name="cmenuName">This is Cmenu option Name.</param>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Name.</returns>
        public void ClickViewAllSubmissionsForStudyPlan(string cmenuName, string activityName)
        {
            logger.LogMethodEntry("GBDefaultUXPage", "ClickViewAllSubmissionsForStudyPlan",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialized Variable
            string getActivityName = string.Empty;
         
            try
            {
                // Getting the counts of Activity                    
                int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator);
                for (int activityColumnNo = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); activityColumnNo <= getActivityCount;
                activityColumnNo++)
                {
                    // Getting the Activity name
                    getActivityName = base.GetTitleAttributeValueByXPath
                        (string.Format(GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_ActivityName_Xpath_Locator,
                        activityColumnNo));
                    if (getActivityName.Trim() == activityName.Trim())
                    {
                        // Click View Submission option of asset in the Gradebook
                        this.ClickViewSubmissionOption(activityColumnNo, activityName);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBDefaultUXPage", "ClickViewAllSubmissionsForStudyPlan",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click View submission option
        /// </summary>
        /// <param name="activityColumnNo">This is the Activity column count.</param>
        /// <param name="activityName">This is Activity Name.</param>
        public void ClickViewSubmissionOption(int activityColumnNo,string activityName)
        {
            logger.LogMethodEntry("GBDefaultUXPage", "ClickViewSubmissionOption",
                          base.IsTakeScreenShotDuringEntryExit);
            // Click the Cmenu icon of the asset in Gradebook
            base.ClickImageByXPath(String.Format(GBDefaultUXPageResource.
                GBDefaultUXPage_Gradebook_DPGetActivityCount_Xpath_Locator, activityColumnNo));
            // Click "View All Submissions" option of the asset in Gradebook
            IWebElement getViewsubmissonProperty = base.GetWebElementPropertiesById(
                GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_DPViewSubmissionLink_ID);
            Thread.Sleep(2000);
            // Check the condition if the activity is a homework and then click on the Level
            if (activityName == GBDefaultUXPageResource.GBDefaultUXPage_Page_HomeWorkActivityName)
            {
                base.PerformMouseHoverByJavaScriptExecutor(getViewsubmissonProperty);
                IWebElement getLevelProperty = base.GetWebElementPropertiesByCssSelector(
                    GBDefaultUXPageResource.GBDefaultUXPage_Page_HomeWork_LevelG_CSS_Locator);
                Thread.Sleep(2000);
                base.ClickByJavaScriptExecutor(getLevelProperty);
            }
            else
            {
                base.ClickByJavaScriptExecutor(getViewsubmissonProperty);
            }

            logger.LogMethodExit("GBDefaultUXPage", "ClickViewSubmissionOption",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Get Studyplan Name In Gradebook and click on View Grade option.
        /// </summary>
        /// <param name="activityName">This is Studyplan Name.</param>
        /// <returns>Activity Name.</returns>
        public void ClickViewGradeOptionforStudyPlan(String StudyPlanName)
        {
            logger.LogMethodEntry("GBDefaultUXPage", "ClickViewGradeOption",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialized Variable
            string getActivityName = string.Empty;
            try
            {
                // Switch to iFrame
                this.SwitchToTeacherGradebookIframe();
                // Getting the counts of Activity                    
                int getActivityCount = base.GetElementCountByXPath(GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentCount_Xpath_Locator);
                for (int activityColumnNo = Convert.ToInt32(GBInstructorUXPageResource.
                GBInstructorUX_Page_Initial_Value); activityColumnNo <= getActivityCount;
                activityColumnNo++)
                {
                    // Getting the Activity name
                    getActivityName = base.GetTitleAttributeValueByXPath
                        (string.Format(GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_ActivityName_Xpath_Locator,
                        activityColumnNo));
                    if (getActivityName.Trim() == StudyPlanName.Trim())
                    {
                        //Click The View Grade Button.
                        this.ClickViewGradeButton(activityColumnNo);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBDefaultUXPage", "ClickViewGradeOption",
                          base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        ///Click The View Grade Button.
        /// </summary>
        /// <param name="activityColumnNo">This is Column count.</param>
        private void ClickViewGradeButton(int activityColumnNo)
        {
            //Click The View Grade Button
            logger.LogMethodEntry("GBInstructorUXPage", "ClickViewGradeButton",
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
            logger.LogMethodExit("GBInstructorUXPage", "ClickViewGradeButton",
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
        /// Search an asset at Gradebook in DP.
        /// </summary>
        /// <param name="assetName">This is the Asset name.</param>
        public void SearchAssetInDPInstructorGradebook(string assetName)
        {

            // Search an asset at Gradebook in DP
            logger.LogMethodEntry("GBInstructorUXPage",
                "SearchAssetInDPInstructorGradebook",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to Iframe
                base.SwitchToDefaultPageContent();
                base.WaitForAjaxToComplete();
                //Switching to frame using source.
                base.SwitchToIFrameBySource(GBDefaultUXPageResource.
                GBDefaultUXPage_Page_CourseContent_Iframe_srcText);

                IWebElement searchFilter = base.GetWebElementPropertiesByCssSelector(GBDefaultUXPageResource.
                   GBDefaultUXPage_Page_Gradebook_TitleSearchButton_cssSelector_Value);
                base.ClickByJavaScriptExecutor(searchFilter);

                //Enter the asset to be searched
                base.WaitForElement(By.Id(GBDefaultUXPageResource.
                  GBDefaultUXPage_Page_Gradebook_TitleSearchTextBox_Id_Value));
                base.FillTextBoxById(GBDefaultUXPageResource.
                  GBDefaultUXPage_Page_Gradebook_TitleSearchTextBox_Id_Value, assetName);
                //Press Enter to perform the search
                WebDriver.FindElement(By.Id(GBDefaultUXPageResource.
                    GBDefaultUXPage_Page_Gradebook_TitleSearchTextBox_Id_Value))
                    .SendKeys(Keys.Enter);
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage",
                "SearchAssetInDPInstructorGradebook",
                base.IsTakeScreenShotDuringEntryExit);
            

        }

    }
}

