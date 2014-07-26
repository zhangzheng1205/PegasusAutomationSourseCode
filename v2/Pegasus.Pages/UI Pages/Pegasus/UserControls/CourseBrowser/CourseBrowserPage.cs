using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.UserControls.CourseBrowser;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains 'Course Browser' Page Details
    /// </summary>
    public class CourseBrowserPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(CourseBrowserPage));
                
        /// <summary>
        /// Get The 'Target Course' Displayed
        /// </summary>
        /// <param name="courseName">This is Course Name</param>
        /// <returns>Target Course Name</returns>
        public string GetTheTargetCourseDisplayed(string courseName)
        {
            //Get The Target Course Displayed
            logger.LogMethodEntry("CourseBrowserPage", "GetTheTargetCourseDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            //Initializing the Variable
            string getTargetCourseDisplayed = string.Empty;
            try
            {
                //Select the Frame
                this.SelectTheFrame(CourseBrowserPageResource.
                CourseBrowserPage_Frame_Id_Locator);
                //Wait for the Element 
                base.WaitForElement(By.Id(CourseBrowserPageResource.
                    CourseBrowserPage_Div_Id_Locator));
                if (base.GetElementTextById(CourseBrowserPageResource.
                    CourseBrowserPage_Div_Id_Locator).Contains(courseName))
                {
                    getTargetCourseDisplayed = courseName;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseBrowserPage", "GetTheTargetCourseDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            return getTargetCourseDisplayed;
        }

        /// <summary>
        /// Select The Frame
        /// </summary>
        private void SelectTheFrame(string frameName)
        {
            //Select The Frame
            logger.LogMethodEntry("CourseBrowserPage", "SelectTheFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Select the Window
            base.SelectDefaultWindow();
            base.WaitForElement(By.Id(frameName));
            //Switch to Frame
            base.SwitchToIFrame(frameName);
            logger.LogMethodExit("CourseBrowserPage", "SelectTheFrame",
                base.isTakeScreenShotDuringEntryExit);
        }
                
        /// <summary>
        /// Select The Source Course for Copy Content
        /// </summary>
        /// <param name="courseName">This is Course Name</param>
        public void SelectTheSourceCourseForCopyContent(string courseName)
        {
            //Select The Source Course for Copy Content
            logger.LogMethodEntry("CourseBrowserPage", "SelectTheSourceCourseForCopyContent",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Frame
                this.SelectTheFrame(CourseBrowserPageResource.
                    CourseBrowserPage_Frame_Id_Locator);
                //Wait for the Element
                base.WaitForElement(By.XPath(CourseBrowserPageResource.
                    CourseBrowserPage_CourseCount_XPath_Locator));
                //Get Course Count
                int getCourseCount = base.GetElementCountByXPath(CourseBrowserPageResource.
                    CourseBrowserPage_CourseCount_XPath_Locator);
                for (int rowCount = Convert.ToInt32(CourseBrowserPageResource.
                    CourseBrowserPage_Loop_Initializer_Value_1);
                    rowCount <= getCourseCount; rowCount++)
                {
                    //Get Course Name
                    string getCourseName = base.GetElementTextByXPath(String.Format(
                        CourseBrowserPageResource.CourseBrowserPage_CourseName_XPath_Locator,
                        rowCount));
                    if (getCourseName.Contains(courseName))
                    {
                        //click on the Course
                        base.ClickLinkByXPath(String.Format(CourseBrowserPageResource.
                            CourseBrowserPage_CourseName_XPath_Locator, rowCount));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseBrowserPage", "SelectTheSourceCourseForCopyContent",
                base.isTakeScreenShotDuringEntryExit);

        }

    }
}
