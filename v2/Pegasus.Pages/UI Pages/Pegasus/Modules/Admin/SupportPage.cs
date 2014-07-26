using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Windows.Forms;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains the details of Support Page.
    /// </summary>
    public class SupportPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(SupportPage));

        /// <summary>
        /// Fetch and Store Pegasus Course Id.
        /// </summary>
        public void FetchAndStoreCourseId()
        {
            //Fetch and Store Pegasus Course Id
            logger.LogMethodEntry("SupportPage","FetchAndStoreCourseId",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectWindow();
                base.WaitForElement(By.Id(SupportPageResource.
                    Support_Page_Resource_Course_Id_Label_Id_Locator));
                //Get Pegasus Course Id
                string getPegasusCourseId = base.GetElementTextById(SupportPageResource.
                    Support_Page_Resource_Course_Id_Label_Id_Locator);
                string[] courseId = getPegasusCourseId.Split(Convert.ToChar(SupportPageResource.
                    Support_Page_Resource_Split_Value));
                string pegasusCourseId = courseId[Convert.ToInt32(
                    SupportPageResource.Support_Page_Resource_Index_Value)];
                //Store Course Id in memory
                this.StorePegasusCourseIDInMemory(pegasusCourseId);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SupportPage", "FetchAndStoreCourseId", 
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("SupportPage", "SelectWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Select Support Window
            base.WaitUntilWindowLoads(SupportPageResource.
                Support_Page_Resource_Support_Window_Title);
            base.SelectWindow(SupportPageResource.
                Support_Page_Resource_Support_Window_Title);
            logger.LogMethodExit("SupportPage", "SelectWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Pegasus CourseID In Memory.
        /// </summary>
        /// <param name="IntegrationPointID">This is Pegasus Course ID.</param>
        private void StorePegasusCourseIDInMemory(string pegasusCourseId)
        {
            //Store Pegasus CourseID In Memory
            logger.LogMethodEntry("SupportPage",
                "StorePegasusCourseIDInMemory", base.isTakeScreenShotDuringEntryExit);
            Course course = new Course
            {
                PegasusCourseId = pegasusCourseId,
                CourseType = Course.CourseTypeEnum.PegasusCourseID,
                IsCreated = true,
            };
            course.StoreCourseInMemory();
            logger.LogMethodExit("SupportPage",
                "StorePegasusCourseIDInMemory", base.isTakeScreenShotDuringEntryExit);
        }
    }
}
