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

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus GBDefaultUX Page Actions
    /// </summary>
    public class GBDefaultUXPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(GBDefaultUXPage));

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
                getActivityGrade = new GBInstructorUXPage().
                    GetActivityStatus(activityName, userLastName, userFirstName);
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
            base.PerformClickAndHoldAction(getCmenuIconProperty);
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
                // Wait untill Gradebook page loads
                base.WaitUntilWindowLoads(GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_Page_Name);
                // Switch to Iframe in the Gradebook
                base.SwitchToIFrameById(GBDefaultUXPageResource.GBDefaultUXPage_Gradebook_Frame);
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
    }
}
