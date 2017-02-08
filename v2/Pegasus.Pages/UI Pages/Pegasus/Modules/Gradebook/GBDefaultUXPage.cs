using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
                bool pres1 = base.IsElementPresent(By.CssSelector("#srcGBFrame"), 10);

                IWebElement frame = base.GetWebElementProperties(By.CssSelector
                    ("#srcGBFrame"));

                WebDriver.SwitchTo().Frame(frame);
           
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
            //  base.SwitchToIFrameBySource(GBDefaultUXPageResource.
            //    GBDefaultUXPage_Page_CourseContent_Iframe_srcText);

            //base.SwitchToIFrameBySource(GBDefaultUXPageResource.
            //    GBDefaultUXPage_Page_srcGBFrame_Iframe_srcText);
            bool pres1 = base.IsElementPresent(By.CssSelector("#classes-Grades-gadget-chrome iframe[id='frmCourseContainer']"), 10);

            IWebElement frame = base.GetWebElementProperties(By.CssSelector
                ("#classes-Grades-gadget-chrome iframe[id='frmCourseContainer']"));
          
            WebDriver.SwitchTo().Frame(frame);
           
                
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
                bool pres1 = base.IsElementPresent(By.CssSelector("#srcGBFrame"), 10);

                IWebElement frame = base.GetWebElementProperties(By.CssSelector
                    ("#srcGBFrame"));

                WebDriver.SwitchTo().Frame(frame);
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
            logger.LogMethodEntry("GBDefaultUXPage", "ClickViewGradeButton",
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
            logger.LogMethodEntry("GBDefaultUXPage", "ClickViewGradeOption",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on View Grades Button.
        /// </summary>
        private void ClickonViewGradesButton()
        {
            //Click on View Grades Button
            logger.LogMethodEntry("GBDefaultUXPage", "ClickonViewGradesButton",
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
            logger.LogMethodExit("GBDefaultUXPage", "ClickonViewGradesButton",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search an asset at Gradebook in DP.
        /// </summary>
        /// <param name="assetName">This is the Asset name.</param>
        public void SearchAssetInDPInstructorGradebook(string assetName)
        {

            // Search an asset at Gradebook in DP
            logger.LogMethodEntry("GBDefaultUXPage",
                "SearchAssetInDPInstructorGradebook",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to Iframe
                base.SwitchToDefaultPageContent();
                base.WaitForAjaxToComplete();
                //Switching to frame using source.
                //bool pres = base.IsElementPresent(By.CssSelector(string.Format("iframe[src='{0}']", GBDefaultUXPageResource.
                //GBDefaultUXPage_Page_CourseContent_Iframe_srcText)), 10);
                bool pres1 = base.IsElementPresent(By.CssSelector("#classes-Grades-gadget-chrome iframe[id='frmCourseContainer']"), 10);
               
                IWebElement frame=base.GetWebElementProperties(By.CssSelector
                    ("#classes-Grades-gadget-chrome iframe[id='frmCourseContainer']"));
                //base.WaitForElement(By.CssSelector(string.Format("iframe[src='{0}']",GBDefaultUXPageResource.
                //GBDefaultUXPage_Page_CourseContent_Iframe_srcText)));
                WebDriver.SwitchTo().Frame(frame);
                //base.SwitchToIFrameBySource(GBDefaultUXPageResource.
                

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

        /// <summary>
        /// This method is to navigate nside the folder in the Grades tab
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="tabName">This is the tab name.</param>
        /// <param name="userTypeEnum">This is the User type enum.</param>
        public void FolderLevelNavigation(string activityName, string tabName, User.UserTypeEnum userTypeEnum)
        {
            logger.LogMethodEntry("GBDefaultUXPage",
                         "FolderLevelNavigation",
                        base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.CsSmsStudent:
                        switch (activityName)
                        {
                            case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                this.NavigateToWordChapter1SimulationActivitiesFolder();
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBDefaultUXPage",
                         "FolderLevelNavigation",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is to navigate inside the Word simulation folder 
        /// </summary>
        private void NavigateToWordChapter1SimulationActivitiesFolder()
        {
            logger.LogMethodEntry("GBDefaultUXPage",
                         "FolderLevelNavigation",
                        base.IsTakeScreenShotDuringEntryExit);
            //Navigate inside the Word 1st folder 
            int f1Index = this.FolderLevel1Navigation(GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_Word2013_FolderName);
            //Navigate into 2nd folder
            int f2Index = this.FolderLevel2Navigation(GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_CreatingDocumentswithMicrosoftWord2013_FolderName, f1Index);
            //Navigate into 3rd folder
            int f3Index = this.FolderLevel3Navigation(GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_WordChapter1_Activities_FolderName, f1Index, f2Index);
            //Navigate into 4th folder
            this.FolderLevel4Navigation(GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_WordChapter1_SimulationActivities_FolderName,
                f1Index, f2Index, f3Index);
            logger.LogMethodEntry("GBDefaultUXPage",
                         "FolderLevelNavigation",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate inside folder at the root level
        /// </summary>
        /// <param name="activityFolderName">This is the Folder name.</param>
        /// <returns>Returns the index of the folder level.</returns>
        private int FolderLevel1Navigation(string activityFolderName)
        {
            logger.LogMethodEntry("GBDefaultUXPage",
                         "FolderLevel1Navigation",
                        base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(base.GetPageTitle);
            int activityFolder1Index = 0;
            //ExpandRoot Folder Plus icon
            IWebElement getRootExpandIcon = base.GetWebElementPropertiesByXPath(GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_RootFolderPlus_Xpath_Locator);
            base.PerformMouseClickAction(getRootExpandIcon);
            //Get the count of folders inside root folder
            base.WaitForElement(By.XPath(GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_SubFoldersInRoot_Count_XPath_Locator));
            int getFolderCount = base.GetElementCountByXPath(string.Format(GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_SubFoldersInRoot_Count_XPath_Locator));
            for (activityFolder1Index = 1; activityFolder1Index <= getFolderCount; activityFolder1Index++)
            {
                //Get the name of the folder
                base.WaitForElement(By.XPath(string.Format(GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_SubFoldersInRoot_Name_XPath_Locator, activityFolder1Index)));
                string getFolderName = base.GetElementInnerTextByXPath(string.Format(GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_SubFoldersInRoot_Name_XPath_Locator, activityFolder1Index));
                if (getFolderName == activityFolderName)
                {
                    //Expand sub folder 1
                    IWebElement expandL1Folder = base.GetWebElementPropertiesByXPath(string.Format(GBDefaultUXPageResource.
                        GBDefaultUXPage_StudentGrades_Level1Folder_PlusIcon_XPath_Locator, activityFolder1Index));
                    base.ClickByJavaScriptExecutor(expandL1Folder);
                    break;

                }
            }
            logger.LogMethodEntry("GBDefaultUXPage",
                        "FolderLevel1Navigation",
                       base.IsTakeScreenShotDuringEntryExit);
            return activityFolder1Index;
        }

        /// <summary>
        /// Navigate inside level 2 folder
        /// /// </summary>
        /// <param name="activityFolderName">This is the activity folder name.</param>
        /// <param name="activityFolder1Index">This is the folder1 index.</param>
        /// <returns>Returns the index of the level 2 folder.</returns>
        private int FolderLevel2Navigation(string activityFolderName, int activityFolder1Index)
        {
            logger.LogMethodEntry("GBDefaultUXPage",
                         "FolderLevel2Navigation",
                        base.IsTakeScreenShotDuringEntryExit);
            //Expand level 2 folder
            int activityFolder2Index;
            base.WaitForElement(By.XPath(string.Format(GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_Level2SubFolders_Count_XPath_Locator,
                activityFolder1Index)));
            //Get the sub folders count in level 2
            int getLevel2FolderCount = base.GetElementCountByXPath(string.Format(
                GBDefaultUXPageResource.GBDefaultUXPage_StudentGrades_Level2SubFolders_Count_XPath_Locator,
                activityFolder1Index));
            for (activityFolder2Index = 1; activityFolder2Index <= getLevel2FolderCount; activityFolder2Index++)
            {
                base.WaitForElement(By.XPath(string.Format(GBDefaultUXPageResource.
                     GBDefaultUXPage_StudentGrades_Level2SubFolder_Name_XPath_Locator,
                     activityFolder1Index, activityFolder2Index)));
                //Get the sub folders name in level 2
                string getFolderName = base.GetElementInnerTextByXPath(string.Format(
                    GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_Level2SubFolder_Name_XPath_Locator,
                    activityFolder1Index, activityFolder2Index));
                if (getFolderName == activityFolderName)
                {
                    //Expand the folder in Level 2
                    base.WaitForElement(By.XPath(string.Format(
                    GBDefaultUXPageResource.
                        GBDefaultUXPage_StudentGrades_Level2Folder_PlusIcon_XPath_Locator,
                        activityFolder1Index, activityFolder2Index)));
                    IWebElement expandL2Folder = base.GetWebElementPropertiesByXPath(string.Format(
                    GBDefaultUXPageResource.
                        GBDefaultUXPage_StudentGrades_Level2Folder_PlusIcon_XPath_Locator,
                        activityFolder1Index, activityFolder2Index));
                    base.ClickByJavaScriptExecutor(expandL2Folder);
                    break;
                }
            }
            logger.LogMethodEntry("GBDefaultUXPage",
                        "FolderLevel2Navigation",
                       base.IsTakeScreenShotDuringEntryExit);
            return activityFolder2Index;
        }

        /// <summary>
        /// Navigate inside level 3 folder
        /// </summary>
        /// <param name="activityFolderName">This is the activity folder name.</param>
        /// <param name="activityFolder1Index">This is the folder1 index.</param>
        /// <param name="activityFolder2Index">This is the folder2 index.</param>
        /// <returns>Returns the index of the level 3 folder.</returns>
        private int FolderLevel3Navigation(string activityFolderName, int activityFolder1Index, int activityFolder2Index)
        {
            logger.LogMethodEntry("GBDefaultUXPage",
                         "FolderLevel3Navigation",
                        base.IsTakeScreenShotDuringEntryExit);
            int activityFolder3Index;
            base.WaitForElement(By.XPath(string.Format(
                    GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_Level3SubFolders_Count_XPath_Locator,
                activityFolder1Index, activityFolder2Index)));
            //Get the sub folders count in level 3
            int getLevel3FolderCount = base.GetElementCountByXPath(string.Format(
                    GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_Level3SubFolders_Count_XPath_Locator,
                activityFolder1Index, activityFolder2Index));
            for (activityFolder3Index = 1; activityFolder3Index <= getLevel3FolderCount; activityFolder3Index++)
            {
                base.WaitForElement(By.XPath(string.Format(GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_Level3SubFolder_Name_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index)));
                //Get the sub folders name in level 3
                string getFolderName = base.GetElementInnerTextByXPath(string.Format(
                    GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_Level3SubFolder_Name_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index));
                if (getFolderName == activityFolderName)
                {
                    base.WaitForElement(By.XPath(string.Format(GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_Level3Folder_PlusIcon_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index)));
                    //Expand level 3 folder plus icon
                    IWebElement expandL3Folder = base.GetWebElementPropertiesByXPath(string.Format(
                    GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_Level3Folder_PlusIcon_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index));
                    base.ClickByJavaScriptExecutor(expandL3Folder);
                    break;
                }
            }
            logger.LogMethodExit("GBDefaultUXPage",
                         "FolderLevel3Navigation",
                        base.IsTakeScreenShotDuringEntryExit);
            return activityFolder3Index;
        }

        /// <summary>
        /// Navigate inside level 4 folder
        /// </summary>
        /// <param name="activityFolderName">This is the activity folder name.</param>
        /// <param name="activityFolder1Index">This is the folder1 index.</param>
        /// <param name="activityFolder2Index">This is the folder2 index.</param>
        /// <param name="activityFolder3Index">This is the folder3 index.</param>
        private void FolderLevel4Navigation(string activityFolderName, int activityFolder1Index,
                int activityFolder2Index, int activityFolder3Index)
        {
            logger.LogMethodEntry("GBDefaultUXPage",
                         "FolderLevel4Navigation",
                        base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(string.Format(GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_Level4SubFolders_Count_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index)));
            int getLevel4FolderCount = base.GetElementCountByXPath(string.Format(
                   GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_Level4SubFolders_Count_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index));
            for (int activityFolder4Index = 1; activityFolder4Index <= getLevel4FolderCount; activityFolder4Index++)
            {
                base.WaitForElement(By.XPath(string.Format(GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_Level4Folder_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder4Index, activityFolder4Index)));
                string getFolderName = base.GetElementInnerTextByXPath(string.Format(
                    GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_Level4Folder_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index, activityFolder4Index));
                if (getFolderName.Contains(activityFolderName))
                {
                    //Click on the Folder name
                    IWebElement expandL4Folder = base.GetWebElementPropertiesByXPath(
                        string.Format(GBDefaultUXPageResource.
                        GBDefaultUXPage_StudentGrades_Level4Folder_XPath_Locator,
                          activityFolder1Index, activityFolder2Index, activityFolder3Index, activityFolder4Index));
                    base.PerformMouseClickAction(expandL4Folder);
                    break;
                }
            }
            logger.LogMethodExit("GBDefaultUXPage",
                         "FolderLevel4Navigation",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the activity name displayed
        /// </summary>
        /// <param name="activityName">This is the Activity name.</param>
        /// <returns>Activity name.</returns>
        public String IsActivityDisplayedInGradesTab(string activityName)
        {
            logger.LogMethodEntry("GBDefaultUXPage",
                         "IsActivityDisplayedInGradesTab",
                        base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToIFrameById(GBDefaultUXPageResource.
                GBDefaultUXPage_Grades_Frame_ID_Locator);
            string getActivityName = string.Empty;
            base.WaitForElement(By.XPath(GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_ActivityCount_XPath_Locator));
            //Get the Activity count in Grades tab
            int getActivityCount = base.GetElementCountByXPath(GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_ActivityCount_XPath_Locator);
            for (int i = 1; i <= getActivityCount; i++)
            {
                //Get the Activity name in Grades tab
                getActivityName = base.GetElementInnerTextByXPath(string.Format(GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_ActivityName_XPath_Locator, i));
                if (getActivityName == activityName)
                {
                    break;
                }
            }
            base.SwitchToDefaultPageContent();
            logger.LogMethodExit("GBDefaultUXPage",
                         "IsActivityDisplayedInGradesTab",
                        base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Verify the activity grade displayed
        /// </summary>
        /// <param name="activityName">This is the Activity name.</param>
        /// <param name="grade">This is the Activity grade.</param>
        /// <returns>Activity grade.</returns>
        public String IsActivityGradeDisplayedInGradesTab(string activityName, String grade)
        {
            logger.LogMethodEntry("GBDefaultUXPage",
                         "IsActivityGradeDisplayedInGradesTab",
                        base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToIFrameById(GBDefaultUXPageResource.
                GBDefaultUXPage_Grades_Frame_ID_Locator);
            string getActivityName = string.Empty;
            string getActivitygrade = string.Empty;
            base.WaitForElement(By.XPath(GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_ActivityCount_XPath_Locator));
            int getActivityCount = base.GetElementCountByXPath(GBDefaultUXPageResource.
                GBDefaultUXPage_StudentGrades_ActivityCount_XPath_Locator);
            for (int i = 1; i <= getActivityCount; i++)
            {
                //Get the Activity Grade in Grades tab
                getActivityName = base.GetElementInnerTextByXPath(string.Format(GBDefaultUXPageResource.
                    GBDefaultUXPage_StudentGrades_ActivityName_XPath_Locator, i));
                if (getActivityName == activityName)
                {
                    getActivitygrade = base.GetElementInnerTextByXPath(string.Format(
                        GBDefaultUXPageResource.GBDefaultUXPage_StudentGrades_Activity_Grade_XPath_Locator, i));
                    break;
                }
            }
            base.SwitchToDefaultPageContent();
            logger.LogMethodExit("GBDefaultUXPage",
                         "IsActivityGradeDisplayedInGradesTab",
                        base.IsTakeScreenShotDuringEntryExit);
            return getActivitygrade;
        }

        /// <summary>
        /// Click on the cmen option of an activity in Grades tab
        /// </summary>
        /// <param name="cmenuOption">This is the cmenu option.</param>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="userTypeEnum">This is the User type enum.</param>
        public void ClickOnActivitycMenuOption(string cmenuOption, string activityName, User.UserTypeEnum userTypeEnum)
        {
            logger.LogMethodEntry("GBDefaultUXPage",
                         "ClickOnActivitycMenuOption",
                        base.IsTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.CsSmsInstructor:
                    break;

                case User.UserTypeEnum.CsSmsStudent:
                    this.SelectActivitycMenuOption(cmenuOption, activityName);
                    break;
            }
            logger.LogMethodEntry("GBDefaultUXPage",
                         "ClickOnActivitycMenuOption",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        private void SelectActivitycMenuOption(string cmenuOption, string activityName)
        {
            logger.LogMethodEntry("GBDefaultUXPage",
                         "SelectActivitycMenuOption",
                        base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToIFrameById("srcGBFrame");
            string getActivityName = string.Empty;
            base.WaitForElement(By.XPath("//table[@id='GridStudent']/tbody/tr"));
            int getActivityCount = base.GetElementCountByXPath("//table[@id='GridStudent']/tbody/tr");
            for (int i = 1; i <= getActivityCount; i++)
            {
                bool hgsd = base.IsElementPresent(By.XPath(string.Format("//table[@id='GridStudent']/tbody/tr[{0}]/td[2]/span", i)), 10);
                getActivityName = base.GetElementInnerTextByXPath(string.Format("//table[@id='GridStudent']/tbody/tr[{0}]/td[2]/span", i));
                if (getActivityName == activityName)
                {
                    bool hgssad = base.IsElementPresent(By.XPath(string.Format("//table[@id='GridStudent']/tbody/tr[{0}]/td[2]/span/span/a", i)), 10);
                    IWebElement activityName1 = base.GetWebElementPropertiesByXPath(string.Format("//table[@id='GridStudent']/tbody/tr[{0}]/td[2]/span/span/a", i));
                    base.PerformMouseHoverAction(activityName1);
                    Thread.Sleep(2000);
                    bool jh = base.IsElementPresent(By.XPath(string.Format(".//*[@id='spFeed']/input")), 10);
                    IWebElement cmenuOption1 = base.GetWebElementPropertiesByXPath(string.Format(".//*[@id='spFeed']/input"));
                    base.PerformMouseClickAction(cmenuOption1);

                    Thread.Sleep(1000);
                    base.SelectDropDownOptionById("35d15ecb-88ec-40a1-b497-2095239d1ac7", cmenuOption);
                    bool jhrjt = base.IsElementPresent(By.XPath("//a[@class = 'PU_render']"), 10);
                    bool hgfks = base.IsElementPresent(By.XPath("//div[contains(@id,'reference')]"), 10);
                    Thread.Sleep(2000);
                    IWebElement activityCmenu = base.GetWebElementPropertiesByPartialLinkText("cmenuOption");
                    base.PerformMouseClickAction(activityCmenu);

                }
            }
            logger.LogMethodExit("GBDefaultUXPage",
                         "SelectActivitycMenuOption",
                        base.IsTakeScreenShotDuringEntryExit);
        }
             
    }
}

