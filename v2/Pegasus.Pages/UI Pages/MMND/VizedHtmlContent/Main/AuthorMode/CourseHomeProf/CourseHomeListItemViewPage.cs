using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.MMND.VizedHtmlContent.Main.AuthorMode.CourseHomeProf;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Actions related to "Course Home List Item View Page"
    /// </summary>
    public class CourseHomeListItemViewPage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(CourseHomeListItemViewPage));

        /// <summary>
        /// Display Of Course Links
        /// </summary>
        /// <returns>True if Course Links are Displayed otherwise False</returns>
        public Boolean IsCourseLinksDisplayed()
        {
            //Display Of Course Links
            logger.LogMethodEntry("CourseHomeListItemViewPage", "IsCourseLinksDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            //Initializing the Variable
            Boolean isLinksDisplayed = false;
            try
            {
                //Wait for the window to Load
                base.WaitUntilWindowLoads(CourseHomeListItemViewPageResource.
                    CourseHomeListItemViewPage_CourseHome_Window_Title);
                base.SelectWindow(CourseHomeListItemViewPageResource.
                    CourseHomeListItemViewPage_CourseHome_Window_Title);
                //Wait for the User Name
                base.WaitForElement(By.Id(CourseHomeListItemViewPageResource.
                    CourseHomeListItemViewPage_MenuList_Id_Locator));
                isLinksDisplayed = base.IsElementPresent(By.Id(CourseHomeListItemViewPageResource.
                    CourseHomeListItemViewPage_MenuList_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseHomeListItemViewPage", "IsCourseLinksDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            return isLinksDisplayed;
        }

        /// <summary>
        /// Click Pegasus Subtab Link In CourseHome.
        /// </summary>
        /// <param name="tabName">This is subtab Name.</param>
        public void ClickPegasusSubtabLinkInCourseHome(string tabName)
        {
            //Click Pegasus Subtab Link In CourseHome
            logger.LogMethodEntry("CourseHomeListItemViewPage", 
                "ClickPegasusSubtabLinkInCourseHome",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                this.SelectCourseHomeWindow(); 
                //Wait for the element
                base.WaitForElement(By.PartialLinkText(tabName));
                base.FocusOnElementByPartialLinkText(tabName);
                //Press Enter Key
                new ViewPage().PressEnterKeyAndAcceptTheAlert();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseHomeListItemViewPage", 
                "ClickPegasusSubtabLinkInCourseHome",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Home Window.
        /// </summary>
        public void SelectCourseHomeWindow()
        {
            //Select Course Home Window
            logger.LogMethodEntry("CourseHomeListItemViewPage","SelectCourseHomeWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(CourseHomeListItemViewPageResource.
                        CourseHomeListItemViewPage_CourseHome_Window_Title);
                base.SelectWindow(CourseHomeListItemViewPageResource.
                        CourseHomeListItemViewPage_CourseHome_Window_Title);
                base.WaitForElement(By.Id(CourseHomeListItemViewPageResource.
                    CourseHomeListItemViewPage_CourseHome_IFrame));
                base.SwitchToIFrame(CourseHomeListItemViewPageResource.
                    CourseHomeListItemViewPage_CourseHome_IFrame);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseHomeListItemViewPage","SelectCourseHomeWindow",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
