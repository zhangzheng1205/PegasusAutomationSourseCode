using System;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  This class handles Pegasus GBFolders Page Actions.
    /// </summary>
    public class GBFoldersPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger.
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(GBFoldersPage));
       
        /// <summary>
        /// This the enum available for Sub Folder Name in gradebook.
        /// </summary>
        public enum SubFolderAssetEnum
        {
            /// <summary>
            /// Sub Folder Name Enum in Gradebook
            /// </summary>
            ADDITIONALPRACTICE = 1,
            /// <summary>
            /// Sub Folder Name Enum in Gradebook
            /// </summary>
            READINESSCHECK = 2,
        }
        /// <summary>
        /// Get The Grade For Submitted Activity.
        /// </summary>
        /// <returns>Grade Of The Activity.</returns>
        public String GetActivityGrade()
        {
            //View Grades For Submitted Activity
            logger.LogMethodEntry("GBFoldersPage", "GetActivityGrade",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Navigate Inside Folder Asset
                this.NavigateInsideFolderAsset();                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBFoldersPage", "GetActivityGrade",
                base.isTakeScreenShotDuringEntryExit);
            return this.GetGradePresentInCell();
        }

        /// <summary>
        /// Navigate Inside Folder Asset.
        /// </summary>
        public void NavigateInsideFolderAsset()
        {
            //Navigate Inside Folder Asset
            logger.LogMethodEntry("GBFoldersPage", "NavigateInsideFolderAsset",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select GradeBook Window
                SelectGradeBookWindow();
                //Select Folder Frame
                SelectActivityFolderIFrame();
                //Navigate Inside Folders
                this.NavigateInsideQuestionFolder();
                //Switch To Default Page
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBFoldersPage", "NavigateInsideFolderAsset",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside Folder Asset.
        /// </summary>
        /// <param name="subFolderAssetEnum">This is SubFolder Name Type Enum</param>
        public void NavigateInsideSubFolderAsset(SubFolderAssetEnum subFolderAssetEnum)
        {
            //Navigate Inside Folder Asset
            logger.LogMethodEntry("GBFoldersPage", "NavigateInsideSubFolderAsset",
                base.isTakeScreenShotDuringEntryExit);
            try
            {    
                switch (subFolderAssetEnum)
                {
                        //Additional practice folder
                    case SubFolderAssetEnum.ADDITIONALPRACTICE:
                        // Navigate Inside Folder Asset
                        this.NavigateInsideFolderAsset();
                        break;
                    //Readiness check folder
                    case SubFolderAssetEnum.READINESSCHECK:
                        //Select GradeBook Window
                        SelectGradeBookWindow();
                        //Select Frame
                        new GBStudentUXPage().SelectStudentFolderNavigationFrame();
                        //Select Folder Asset In Gradebook
                        this.SelectFolderAssetInGradebook();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBFoldersPage", "NavigateInsideSubFolderAsset",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Folder Asset In Gradebook.
        /// </summary>
        private void SelectFolderAssetInGradebook()
        {
            //Select Folder Asset In Gradebook
            logger.LogMethodEntry("GBFoldersPage", "SelectFolderAssetInGradebook",
                base.isTakeScreenShotDuringEntryExit);
            //Navigate Inside Main Folder
            base.WaitForElement(By.XPath(GBFoldersPageResource.
                GBFolders_Page_Student_Folder_Xpath_Locator));
            IWebElement getXpathproperty = base.GetWebElementPropertiesByXPath(GBFoldersPageResource.
                GBFolders_Page_Student_Folder_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getXpathproperty);
            //Navigate Inside Sub Folder   
            Thread.Sleep(Convert.ToInt32(GBFoldersPageResource
            .GBFolders_Page_ThreadTime_Value));
            base.SwitchToDefaultPageContent();
            SelectGradeBookWindow();
            //Select Frame
            new GBStudentUXPage().SelectStudentFolderNavigationFrame();
            //Click on Readiness Check                         
            IWebElement getReadinessCheckProperty =
                base.WebDriver.FindElement(By.XPath(GBFoldersPageResource.
                GBFolders_Page_Student_Folder_Xpath_Locator));
            base.ClickByJavaScriptExecutor(getReadinessCheckProperty);
            Thread.Sleep(Convert.ToInt32(GBFoldersPageResource
           .GBFolders_Page_ThreadTime_Value));
            logger.LogMethodExit("GBFoldersPage", "SelectFolderAssetInGradebook",
               base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select Activity Grade Folder Frame.
        /// </summary>
        private void SelectActivityFolderIFrame()
        {
            //Select Frame
            logger.LogMethodEntry("GBFoldersPage", "SelectActivityFolderIFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Name(GBFoldersPageResource.
                                            GBFolders_Page_FoldersFrame_Iframe_Name_Locator));
            //Switch To The Folders Frame
            base.SwitchToIFrame(GBFoldersPageResource.
                                    GBFolders_Page_FoldersFrame_Iframe_Name_Locator);
            logger.LogMethodExit("GBFoldersPage", "SelectActivityFolderIFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectGradeBookWindow()
        {
            //Select Window
            logger.LogMethodEntry("GBFoldersPage", "SelectGradeBookWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For The Gradebook Window
            base.WaitUntilWindowLoads(GBFoldersPageResource.
                                          GBFolders_Page_Gradebook_WindowName);
            //Select Window
            base.SelectWindow(GBFoldersPageResource.
                                  GBFolders_Page_Gradebook_WindowName);
            logger.LogMethodExit("GBFoldersPage", "SelectGradeBookWindow",
         base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside Question Folders.
        /// </summary>
        private void NavigateInsideQuestionFolder()
        {
            //Navigate Inside Folders
            logger.LogMethodEntry("GBFoldersPage", "NavigateInsideQuestionFolder",
                                base.isTakeScreenShotDuringEntryExit);
            //Navigate Inside Main Folder
            base.WaitForElement(By.XPath(GBFoldersPageResource.
              GBFolders_Page_MainFolder_Xpath_Locator));
            IWebElement getXpathproperty = base.GetWebElementPropertiesByXPath(GBFoldersPageResource.
              GBFolders_Page_MainFolder_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getXpathproperty);
            //Navigate Inside Sub Folder   
            Thread.Sleep(Convert.ToInt32(GBFoldersPageResource
            .GBFolders_Page_ThreadTime_Value));
            base.SwitchToDefaultPageContent();
            base.SelectWindow(GBFoldersPageResource
                .GBFolders_Page_Gradebook_WindowName);
            base.WaitForElement(By.Name(GBFoldersPageResource.
             GBFolders_Page_FoldersFrame_Iframe_Name_Locator));
            base.SwitchToIFrame(GBFoldersPageResource.
             GBFolders_Page_FoldersFrame_Iframe_Name_Locator);
            //Click on additional practice 
            IWebElement getAdditonalPracticeProperty =
                base.WebDriver.FindElement(By.XPath(GBFoldersPageResource.
              GBFolders_Page_SubFolder_Xpath_Locator));
            base.ClickByJavaScriptExecutor(getAdditonalPracticeProperty);
            Thread.Sleep(Convert.ToInt32(GBFoldersPageResource
           .GBFolders_Page_ThreadTime_Value));
            logger.LogMethodExit("GBFoldersPage", "NavigateInsideQuestionFolder",
                                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the display of grades
        /// in Activity Grade Cell.
        /// </summary>
        /// <returns>Grade Present in Activity Grade Cell.</returns>
        public String GetGradePresentInCell()
        {
            //View Grade in Activity Grade Cell
            logger.LogMethodEntry("GBFoldersPage", "GetGradePresentInCell",
                                 base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getActivityGrade = string.Empty;
            string getActivityName = GBInstructorUXPageResource.
                    GBInstructorUX_Page_AssignmentTitle_Value;
            try
            {
                //Verify the display of grades
                getActivityGrade = new GBInstructorUXPage().
                    GetGradeDisplayedInTheGradeCell(getActivityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBFoldersPage", "GetGradePresentInCell",
                                  base.isTakeScreenShotDuringEntryExit);
            return getActivityGrade;
        }        

        /// <summary>
        /// Navigate Inside the Activity Folder.
        /// </summary>
        public void NavigateInsideParentActivityFolder()
        {
            //Navigate Inside the Folder
            logger.LogMethodEntry("GBFoldersPage", "NavigateInsideParentActivityFolder",
                                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for GradeBook Window
                base.WaitUntilWindowLoads(GBFoldersPageResource.
                    GBFolders_Page_Gradebook_WindowName);
                base.SelectWindow(GBFoldersPageResource.GBFolders_Page_Gradebook_WindowName);
                //Wait for Frame Id
                base.WaitForElement(By.Id(GBFoldersPageResource.GBFolders_Page_Frame_Id_Locator));
                base.SwitchToIFrame(GBFoldersPageResource.GBFolders_Page_Frame_Id_Locator);
                //Navigate Inside the SubFolder Folder
                this.NavigateInsideActivityFolder(GBFoldersPageResource.
                    GBFolders_Page_Root_Folder_one);
                //Navigate Inside the SubFolder Folder
                this.NavigateInsideActivityFolder(GBFoldersPageResource.
                    GBFolders_Page_Root_Folder_two);
                base.SelectWindow(GBFoldersPageResource.GBFolders_Page_Gradebook_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBFoldersPage", "NavigateInsideParentActivityFolder",
                                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside the Folder.
        /// </summary>
        /// <param name="activityFolderName">This is Activity Folder Name.</param>
        private void NavigateInsideActivityFolder(String activityFolderName)
        {
            //Navigate Inside the Activity Folder
            logger.LogMethodEntry("GBFoldersPage", "NavigateInsideActivityFolder",
                                 base.isTakeScreenShotDuringEntryExit);
            //Get Activity Folder Count
            int getActivityFolderCount = GetActivityFolderCount();
            for (int initailActivityFolderCount = Convert.ToInt32(GBFoldersPageResource.
                GBFolders_Page_Initial_Value); initailActivityFolderCount < getActivityFolderCount;
                initailActivityFolderCount++)
            {
                //Get Activity Folder Name
                String getActiivtyFolderName = GetActiivtyFolderName(initailActivityFolderCount);
                if (getActiivtyFolderName.Contains(activityFolderName))
                {
                    ClickOnActivtyFolderName(initailActivityFolderCount);
                    break;
                }
            }
            logger.LogMethodExit("GBFoldersPage", "NavigateInsideActivityFolder",
                                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Total Folder Count.
        /// </summary>
        /// <returns>Activity Folder Count.</returns>
        private int GetActivityFolderCount()
        {
            //Get Activity Folder Count
            logger.LogMethodEntry("GBFoldersPage", "GetActivityFolderCount",
                                base.isTakeScreenShotDuringEntryExit);
            //Pause Code For Frame Loads
            Thread.Sleep(Convert.ToInt32(GBFoldersPageResource.GBFolders_Page_ThreadTime_Value));
            //Wait for Folder Element
            base.WaitForElement(By.XPath(GBFoldersPageResource.
                GBFolders_Page_Folder_Count_Xpath_Locator));
            //Get Activity Folder Count
            int getActivityFolderCount = GetElementCountByXPath(GBFoldersPageResource.
                GBFolders_Page_Folder_Count_Xpath_Locator);
            logger.LogMethodExit("GBFoldersPage", "GetActivityFolderCount",
                                base.isTakeScreenShotDuringEntryExit);
            return getActivityFolderCount;
        }

        /// <summary>
        /// Get Activity Folder Name.
        /// </summary>
        /// <param name="initailActivityFolderCount">This is activity folder count.</param>
        /// <returns>Activity Folder Name.</returns>
        private string GetActiivtyFolderName(int initailActivityFolderCount)
        {
            //Get Activity Folder Name
            logger.LogMethodEntry("GBFoldersPage", "GetActiivtyFolderName",
                                base.isTakeScreenShotDuringEntryExit);
            //Wait for the Folder 
            base.WaitForElement(By.XPath(string.Format(GBFoldersPageResource.
                GBFolders_Page_GetFolderName_Xpath_Locator, initailActivityFolderCount)));
            base.FocusOnElementByXPath(string.Format(GBFoldersPageResource.
                GBFolders_Page_GetFolderName_Xpath_Locator, initailActivityFolderCount));
            IWebElement getWebElementProperty = base.GetWebElementPropertiesByXPath(string.Format
                (GBFoldersPageResource.GBFolders_Page_GetFolderName_Xpath_Locator,
                initailActivityFolderCount));
            //Scroll Folder Frame
            base.ScrollElementByJavaScriptExecutor(getWebElementProperty);
            //Get Folder Name
            string getActiivtyFolderName = base.GetElementTextByXPath(string.Format
                (GBFoldersPageResource.GBFolders_Page_GetFolderName_Xpath_Locator, 
                initailActivityFolderCount));
            logger.LogMethodExit("GBFoldersPage", "GetActiivtyFolderName",
                              base.isTakeScreenShotDuringEntryExit);
            return getActiivtyFolderName;
        }

        /// <summary>
        /// Click on Activity Folder Name.
        /// </summary>
        /// <param name="initailActivityFolderCount">This is activity folder count.</param>
        private void ClickOnActivtyFolderName(int initailActivityFolderCount)
        {
            //Click on Activity Name
            logger.LogMethodEntry("GBFoldersPage", "ClickOnActivtyFolderName",
                              base.isTakeScreenShotDuringEntryExit);
            //Focus on Element
            base.FocusOnElementByXPath(string.Format(GBFoldersPageResource.
                GBFolders_Page_GetFolderName_Xpath_Locator,
                                                     initailActivityFolderCount));
            //Click On Folder
            base.ClickLinkByXPath(string.Format(GBFoldersPageResource.
                GBFolders_Page_GetFolderName_Xpath_Locator, initailActivityFolderCount));
            //Pause Code Till Folder Frame Loads
            Thread.Sleep(Convert.ToInt32(GBFoldersPageResource.
                GBFolders_Page_Activity_Click_ThreadTime_Value));
            logger.LogMethodExit("GBFoldersPage", "ClickOnActivtyFolderName",
                              base.isTakeScreenShotDuringEntryExit);
        }

        
    }
}
