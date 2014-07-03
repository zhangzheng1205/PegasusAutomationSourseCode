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
                 base.isTakeScreenShotDuringEntryExit);
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
                          base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
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
                        GBDefaultUXPage_Gradebook_NormalActivityName_Xpath_Locator, activityColumnNo)));
                    //Getting the Activity name
                    getActivityName = base.GetTitleAttributeValueByXPath
                        (string.Format(GBDefaultUXPageResource.
                        GBDefaultUXPage_Gradebook_NormalActivityName_Xpath_Locator, activityColumnNo));
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
                          base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
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
                          base.isTakeScreenShotDuringEntryExit);
            return getActivityGrade;
        }
    }
}
