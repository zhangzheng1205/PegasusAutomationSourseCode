using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.StudyMaterialsExplorer;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Student Explore Page Actions.
    /// </summary>
    public class StudentExplorePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(StudentExplorePage));

        /// <summary>
        /// Click on Activity.
        /// </summary>
        /// <param name="activityName">This is name of activity.</param>
        public void OpenActivityInPracticeTab(string activityName)
        {
            //Click On Activity
            logger.LogMethodEntry("StudentExplorePage", "OpenActivityInPracticeTab",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Practice Window
                base.SelectWindow(StudentExplorePageResource.
                    StudentExplore_Page_Practice_Window_Name);
                //Navigate Inside Activity Folder
                this.NavigateInsideActivityFolder();
                //Wait For Element
                base.WaitForElement(By.Id(StudentExplorePageResource.
                    StudentExplore_Page_CoursePreview_Frame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(StudentExplorePageResource.
                    StudentExplore_Page_CoursePreview_Frame_Id_Locator);
                //Wait For Element
                base.WaitForElement(By.Id(StudentExplorePageResource.
                    StudentExplore_Page_ActivityText_Id_Locator));
                //Get Activity Name
                string getActivityName = base.GetElementTextById(StudentExplorePageResource.
                    StudentExplore_Page_ActivityText_Id_Locator).Trim();
                if (getActivityName == activityName)
                {
                    //Wait For Element
                    base.WaitForElement(By.Id(StudentExplorePageResource.
                                                  StudentExplore_Page_PostTest_Link_Id_Locator));
                    //Get Element Property
                    IWebElement getPostTestActivityProperty = base.
                        GetWebElementPropertiesById(StudentExplorePageResource.
                                                        StudentExplore_Page_PostTest_Link_Id_Locator);
                    //Click on Link Button
                    base.ClickByJavaScriptExecutor(getPostTestActivityProperty);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("StudentExplorePage", "OpenActivityInPracticeTab",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside Activity Folder.
        /// </summary>
        private void NavigateInsideActivityFolder()
        {
            logger.LogMethodEntry("StudentExplorePage", "NavigateInsideActivityFolder",
                 base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(StudentExplorePageResource.
                StudentExplore_Page_ActivityFolder_Id_Locator));
            //Click Link Button
            base.ClickLinkById(StudentExplorePageResource.
                StudentExplore_Page_ActivityFolder_Id_Locator);
            logger.LogMethodExit("StudentExplorePage", "NavigateInsideActivityFolder",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Practice Page window Title.
        /// If Window is accessible then window title should be as expected.
        /// </summary>
        /// <param name="tabName">This is name of the tab.</param>
        /// <returns>True if window title found as expected otherwirse false.</returns>
        public String GetPracticeTabWindowTitle(string tabName)
        {
            //Get Window Title
            logger.LogMethodEntry("StudentExplorePage", "GetPracticeTabWindowTitle",
               base.isTakeScreenShotDuringEntryExit);
            //Wait For Page To Get Switched
            base.WaitUntilPageGetSwitchedSuccessfully(tabName);
            //Get Page Title
            string getWindowTitle = base.GetPageTitle;
            logger.LogMethodEntry("StudentExplorePage", "GetPracticeTabWindowTitle",
               base.isTakeScreenShotDuringEntryExit);
            return getWindowTitle;
        }
    }
}
