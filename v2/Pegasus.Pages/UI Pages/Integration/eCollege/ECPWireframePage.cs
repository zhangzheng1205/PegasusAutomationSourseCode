using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages.Integration.eCollege
{
    /// <summary>
    /// This class handles the Home Page action by teacher 
    /// </summary>
    public class ECPWireframePage : BasePage
    {
        /// <summary>
        /// The Static instance of the Logger for the class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(ECPWireframePage));
        /// <summary>
        /// Click on ECollege Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        public void SelectECollegeCourse(Course.CourseTypeEnum courseTypeEnum)
        {
            //Click on ECollege course name
            logger.LogMethodEntry("ECPWireframePage", "SelectECollegeCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for form element
            base.WaitForElement(By.Name(ECPWireframePageResource.
                CourseList_Form_Name_Locator));
            //Get the course name from the memory
            Course course = Course.Get(courseTypeEnum);
            base.WaitForElement(By.XPath(ECPWireframePageResource.
               ECPWireframePage_CourseList_Table_XPath));
            //Get the row count
            int getRowCount = base.GetElementCountByXPath(ECPWireframePageResource.
                ECPWireframePage_CourseList_CourseName_RowCount_XPath);
            for (int setCourseRowCount = 1; setCourseRowCount <=
                               getRowCount; setCourseRowCount++)
            {
                String getRowText = base.GetElementTextByXPath(String.Format(ECPWireframePageResource.
                    ECPWireframePage_CourseList_CourseName_Row_Text_XPath, setCourseRowCount));
                //Row text match by course name
                if (getRowText.Contains(course.Name))
                {
                    base.WaitForElement(By.XPath(string.Format
                        (ECPWireframePageResource.
                        ECPWireframePage_CourseList_CourseName_Row_Text_XPath,
                        setCourseRowCount)));
                    IWebElement courseNameElement = base.GetWebElementPropertiesByXPath
                        (string.Format(ECPWireframePageResource.
                        ECPWireframePage_CourseList_CourseName_Row_Text_XPath,
                        setCourseRowCount, setCourseRowCount));
                    base.ClickByJavaScriptExecutor(courseNameElement);
                }
            }
            logger.LogMethodExit("ECPWireframePage", "SelectECollegeCourse",
            base.isTakeScreenShotDuringEntryExit);
        }

    }
}
