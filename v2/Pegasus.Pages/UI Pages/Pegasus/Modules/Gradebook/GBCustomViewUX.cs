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
    /// This class handles Pegasus GBCustomViewUX Page Actions
    /// </summary>
    public class GBCustomViewUX : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(GBCustomViewUX));

        /// <summary>
        /// Switch to IFrame in Custom View tab
        /// </summary>
        private void SwitchToCustomViewFrame()
        {
            logger.LogMethodEntry("GBCustomViewUXPage", "SwitchToCustomViewFrame",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to Custom Vie iframe
                base.WaitForElement(By.Id(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_CustomView_Frame_ID_Locator));
                base.SwitchToIFrameById(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_CustomView_Frame_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBCustomViewUX",
                           "SwitchToCustomViewFrame",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is to get the column names of the Custom view frame
        /// </summary>
        /// <param name="expectedOption">This is the expected column name.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        /// <returns>This returns the column name.</returns>
        /// 
        public String GetCustomViewTabDisplayItems(string expectedOption, User.UserTypeEnum userTypeEnum)
        {
            logger.LogMethodEntry("GBCustomViewUX",
                           "GetCustomViewTabDisplayItems",
                          base.IsTakeScreenShotDuringEntryExit);
            String optionDisplayText = String.Empty;
            try
            {
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.CsSmsInstructor:
                        break;

                    case User.UserTypeEnum.CsSmsStudent:
                        switch (expectedOption)
                        {
                            case "Custom View":
                                //Wait for the sub menu element to be loaded
                                this.SwitchToCustomViewFrame();
                                bool customElement = base.IsElementPresent(By.Id(GBCustomViewUXPageResource.
                                    GBCustomViewUXPage_CustomView_subMenu_ID_Locator));
                                base.WaitForElement(By.Id(GBCustomViewUXPageResource.
                                    GBCustomViewUXPage_CustomView_subMenu_ID_Locator));
                                //Get the sub menu title text
                                optionDisplayText = base.GetElementInnerTextById(
                                    GBCustomViewUXPageResource.
                                    GBCustomViewUXPage_CustomView_subMenu_ID_Locator);
                                break;

                            case "Activity":
                            case "Grade":
                                this.SwitchToCustomViewFrame();
                                base.WaitForElement(By.PartialLinkText(expectedOption));
                                optionDisplayText = base.GetElementTextByPartialLinkText(expectedOption);
                                break;
                        }
                        break;
                }
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBCustomViewUX",
                          "GetCustomViewTabDisplayItems",
                         base.IsTakeScreenShotDuringEntryExit);
            return optionDisplayText;
        }

        /// <summary>
        /// This method is to get the Activity name in the Custom View list
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="userTypeEnum">This is thee user type enum.</param>
        /// <returns>This returns the activity name.</returns>
        public string GetActivitySavedInCustomView(string activityName,
            User.UserTypeEnum userTypeEnum)
        {
            logger.LogMethodEntry("GBCustomViewUX",
                           "GetActivitySavedInCustomView",
                          base.IsTakeScreenShotDuringEntryExit);
            String actualActivityName = String.Empty;
            try
            {
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.CsSmsInstructor:
                        break;

                    case User.UserTypeEnum.CsSmsStudent:
                        actualActivityName = this.GetStudentCustomViewActivityName(activityName);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBCustomViewUX",
                           "GetActivitySavedInCustomView",
                          base.IsTakeScreenShotDuringEntryExit);
            return actualActivityName;
        }

        /// <summary>
        /// This method is to get the Activity name in the Custom View list of student
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <returns>This returns the activity name.</returns>
        private string GetStudentCustomViewActivityName(string activityName)
        {
            logger.LogMethodEntry("GBCustomViewUX",
                           "GetStudentCustomViewActivityName",
                          base.IsTakeScreenShotDuringEntryExit);
            String activityNameInCustomView = String.Empty;
            //Switch to Custom view activity list iframe
            this.SwitchToCustomViewFrame();
            //Get the Activity count displayed in Custom View frame
            base.WaitForElement(By.XPath(GBCustomViewUXPageResource.
                GBCustomViewUXPage_CustomView_ActivityColumn_RowCount_XPath_Locator));
            int getActivityCount = base.GetElementCountByXPath(GBCustomViewUXPageResource.
                GBCustomViewUXPage_CustomView_ActivityColumn_RowCount_XPath_Locator);
            for (int activityCount = 1; activityCount <= getActivityCount; activityCount++)
            {
                base.WaitForElement(By.XPath(string.Format(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_CustomView_ActivityName_XPath_Locator, activityCount)));
                //Get the activity name from the activity column
                activityNameInCustomView = base.GetElementTextByXPath(string.Format(
                    GBCustomViewUXPageResource.
                    GBCustomViewUXPage_CustomView_ActivityName_XPath_Locator, activityCount));
                if (activityNameInCustomView == activityName)
                {
                    break;
                }
            }
            logger.LogMethodExit("GBCustomViewUX",
                          "GetStudentCustomViewActivityName",
                         base.IsTakeScreenShotDuringEntryExit);
            return activityNameInCustomView;
        }

        /// <summary>
        /// This method is to get the Activity Grade in the Custom View         
        /// </summary>
        /// <param name="activityScore">This is the activity score.</param>
        /// <param name="userTypeEnum">this is the usertype enum.</param>
        /// <returns>This returns the grade of the activity.</returns>
        public string GetActivityScoreInCustomView(string activityName,
            User.UserTypeEnum userTypeEnum)
        {
            logger.LogMethodEntry("GBCustomViewUX",
                          "GetActivityScoreInCustomView",
                         base.IsTakeScreenShotDuringEntryExit);
            String activityScoreInCustomView = String.Empty;
            try
            {
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.CsSmsInstructor:
                        break;

                    case User.UserTypeEnum.CsSmsStudent:
                        this.GetStudentCustomViewActivityScore(activityName);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBCustomViewUX",
                          "GetActivityScoreInCustomView",
                         base.IsTakeScreenShotDuringEntryExit);
            return activityScoreInCustomView;
        }

        /// <summary>
        /// This method is to get the Activity Score in the Custom View list of student
        /// </summary>
        /// <param name="activityScore">This is the expected activity score.</param>
        /// <returns>The actual score of the activity,</returns>
        private string GetStudentCustomViewActivityScore(string activityName)
        {
            logger.LogMethodEntry("GBCustomViewUX",
                          "GetStudentCustomViewActivityScore",
                         base.IsTakeScreenShotDuringEntryExit);
            String activityScoreInCustomView = String.Empty;
            String activityNameInCustomView = String.Empty;
            //Get the Activity count displayed in Custom View frame
            base.WaitForElement(By.XPath(GBCustomViewUXPageResource.
                GBCustomViewUXPage_CustomView_ActivityColumn_RowCount_XPath_Locator));
            int getActivityCount = base.GetElementCountByXPath(GBCustomViewUXPageResource.
                GBCustomViewUXPage_CustomView_ActivityColumn_RowCount_XPath_Locator);
            for (int activityCount = 1; activityCount <= getActivityCount; activityCount++)
            {
                base.WaitForElement(By.XPath(string.Format(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_CustomView_ActivityName_XPath_Locator, activityCount)));
                //Get the activity name from the activity column
                activityNameInCustomView = base.GetElementTextByXPath(
                    string.Format(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_CustomView_ActivityName_XPath_Locator, activityCount));
                if (activityNameInCustomView == activityName)
                {
                    base.WaitForElement(By.XPath(string.Format(
                        GBCustomViewUXPageResource.
                        GBCustomViewUXPage_CustomView_ActivityScore_XPath_Locator, activityCount)));
                    //Get the activity grade from the Grade column
                    activityScoreInCustomView = base.GetElementTextByXPath(
                        string.Format(GBCustomViewUXPageResource.
                        GBCustomViewUXPage_CustomView_ActivityScore_XPath_Locator, activityCount));
                }
            }
            logger.LogMethodExit("GBCustomViewUX",
                         "GetStudentCustomViewActivityScore",
                        base.IsTakeScreenShotDuringEntryExit);
            return activityScoreInCustomView;
        }

        /// <summary>
        /// This method is to get the Activity Icon in the Custom View list of student
        /// </summary>
        /// <param name="expectedActivity">This is the activity name.</param>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        /// <returns></returns>
        public bool GetActivityIconInCustomView(string activityName, User.UserTypeEnum userTypeEnum)
        {
            logger.LogMethodEntry("GBCustomViewUX",
                         "GetActivityIconInCustomView",
                        base.IsTakeScreenShotDuringEntryExit);
            bool customViewActivityIcon = false;
            String activityNameInCustomView = String.Empty;
            try
            {
                //Get the Activity count displayed in Custom View frame
                base.WaitForElement(By.XPath(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_CustomView_ActivityColumn_RowCount_XPath_Locator));
                int getActivityCount = base.GetElementCountByXPath(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_CustomView_ActivityColumn_RowCount_XPath_Locator);
                for (int activityCount = 1; activityCount <= getActivityCount; activityCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(GBCustomViewUXPageResource.
                        GBCustomViewUXPage_CustomView_ActivityName_XPath_Locator, activityCount)));
                    //Get the activity name from the activity column
                    activityNameInCustomView = base.GetElementTextByXPath(
                        string.Format(GBCustomViewUXPageResource.
                        GBCustomViewUXPage_CustomView_ActivityName_XPath_Locator, activityCount));
                    if (activityNameInCustomView == activityName)
                    {
                        customViewActivityIcon = base.IsElementPresent(By.XPath(
                            string.Format(GBCustomViewUXPageResource.
                            GBCustomViewUXPage_CustomView_ActivityIcon_XPath_Locator, activityCount)));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBCustomViewUX",
                         "GetActivityIconInCustomView",
                        base.IsTakeScreenShotDuringEntryExit);
            return customViewActivityIcon;
        }

        /// <summary>
        /// This mehtod is to get the Activity position in custom view frame
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="activityPosition">This is the expecetd Activity position in frame.</param>
        /// <returns></returns>
        public Boolean IsTheActivtiyColumnSorted(string activity1, string activity2, string sortOrder)
        {
            bool isActivitySorted = false;
            int activity1Position = 0;
            int activity2Position = 0;
            activity1Position = this.GetActivityPositionInCustomView(activity1);
            activity2Position = this.GetActivityPositionInCustomView(activity2);
            try
            {
                switch (sortOrder)
                {
                    case "Ascending":
                        if (activity2Position > activity1Position)
                        {
                            isActivitySorted = true;
                        }
                        break;
                    case "Descending":
                        if (activity2Position < activity1Position)
                        {
                            isActivitySorted = true;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return isActivitySorted;

        }

        /// <summary>
        /// This mehtod is to get the Activity position in custom view frame
        /// </summary>
        /// <param name="expectedActivityName">This is the activity name.</param>
        /// <returns>Position of the activity in custom view rame.</returns>
        private int GetActivityPositionInCustomView(string expectedActivityName)
        {
            logger.LogMethodEntry("GBCustomViewUX",
                         "GetActivityPositionInCustomView",
                        base.IsTakeScreenShotDuringEntryExit);
            String activityNameInCustomView = String.Empty;
            int activityPosition = 0;
            try
            {
                //Switch to Custom view activity list iframe
                this.SwitchToCustomViewFrame();
                //Get the Activity count displayed in Custom View frame
                base.WaitForElement(By.XPath(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_CustomView_ActivityColumn_RowCount_XPath_Locator));
                int getActivityCount = base.GetElementCountByXPath(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_CustomView_ActivityColumn_RowCount_XPath_Locator);
                for (int activityCount = 1; activityCount <= getActivityCount; activityCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(GBCustomViewUXPageResource.
                        GBCustomViewUXPage_CustomView_ActivityName_XPath_Locator, activityCount)));
                    //Get the activity name from the activity column
                    activityNameInCustomView = base.GetElementTextByXPath(
                        string.Format(GBCustomViewUXPageResource.
                        GBCustomViewUXPage_CustomView_ActivityName_XPath_Locator, activityCount));
                    if (activityNameInCustomView == expectedActivityName)
                    {
                        activityPosition = activityCount;
                        break;
                    }
                }
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBCustomViewUX",
                        "GetActivityPositionInCustomView",
                       base.IsTakeScreenShotDuringEntryExit);
            return activityPosition;
        }

        /// <summary>
        /// Sort tha activity in custom view
        /// </summary>
        /// <param name="sortType">This is the column to be sorted.</param>
        public void SortCustomViewActivity(string sortColumn)
        {
            logger.LogMethodEntry("GBCustomViewUX",
                         "SortCustomViewActivity",
                        base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to the custom view frame
                this.SwitchToCustomViewFrame();
                base.WaitForElement(By.PartialLinkText(sortColumn));
                //Click on the column name to sort
                IWebElement columnToSort = base.GetWebElementPropertiesByPartialLinkText(sortColumn);
                base.ClickByJavaScriptExecutor(columnToSort);
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBCustomViewUX",
                          "SortCustomViewActivity",
                         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is to verify the column sort icon.
        /// </summary>
        /// <param name="sortType">This is the sort type.</param>
        /// <param name="sortColumn">This is the sort column name.</param>
        /// <returns>Boolean value based on the sort status.</returns>
        public Boolean IsCustomViewColumnSorted(string sortType)
        {
            logger.LogMethodEntry("GBCustomViewUX",
                         "IsCustomViewColumnSorted",
                        base.IsTakeScreenShotDuringEntryExit);
            bool isColumnSortIconPresent = false;
            try
            {
                this.SwitchToCustomViewFrame();
                switch (sortType)
                {
                    case "Ascending":
                        //Verify if the Asscending sort icon is displayed
                        isColumnSortIconPresent = base.IsElementPresent(
                            By.ClassName(GBCustomViewUXPageResource.
                            CustomViewUXPage_CustomView_ColumnSort_Ascending_XPath_Locator));
                        break;

                    case "Descending":
                        //Verify if the descending sort icon is displayed
                        isColumnSortIconPresent = base.IsElementPresent(
                            By.ClassName(GBCustomViewUXPageResource.
                            CustomViewUXPage_CustomView_ColumnSort_descending_XPath_Locator));
                        break;
                }
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBCustomViewUX",
                      "IsCustomViewColumnSorted",
                     base.IsTakeScreenShotDuringEntryExit);
            return isColumnSortIconPresent;
        }

        /// <summary>
        /// This method is to navigate nside the folder in the Grades tab
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="tabName">This is the tab name.</param>
        /// <param name="userTypeEnum">This is the User type enum.</param>
        public void FolderLevelNavigation(string activityName, string tabName, User.UserTypeEnum userTypeEnum)
        {
            logger.LogMethodEntry("GBCustomViewUX",
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
            logger.LogMethodExit("GBCustomViewUX",
                         "FolderLevelNavigation",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is to navigate inside the Word simulation folder 
        /// </summary>
        private void NavigateToWordChapter1SimulationActivitiesFolder()
        {
            logger.LogMethodEntry("GBCustomViewUX",
                         "FolderLevelNavigation",
                        base.IsTakeScreenShotDuringEntryExit);
            //Navigate inside the Word 1st folder 
            int f1Index = this.FolderLevel1Navigation(GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_Word2013_FolderName);
            //Navigate into 2nd folder
            int f2Index = this.FolderLevel2Navigation(GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_CreatingDocumentswithMicrosoftWord2013_FolderName, f1Index);
            //Navigate into 3rd folder
            int f3Index = this.FolderLevel3Navigation(GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_WordChapter1_Activities_FolderName, f1Index, f2Index);
            //Navigate into 4th folder
            this.FolderLevel4Navigation(GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_WordChapter1_SimulationActivities_FolderName,
                f1Index, f2Index, f3Index);
            logger.LogMethodEntry("GBCustomViewUX",
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
            base.WaitUntilWindowLoads(base.GetPageTitle);
            int activityFolder1Index = 0;
            //ExpandRoot Folder Plus icon
            IWebElement getRootExpandIcon = base.GetWebElementPropertiesByXPath(GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_RootFolderPlus_Xpath_Locator);
            base.PerformMouseClickAction(getRootExpandIcon);
            //Get the count of folders inside root folder
            base.WaitForElement(By.XPath(GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_SubFoldersInRoot_Count_XPath_Locator));
            int getFolderCount = base.GetElementCountByXPath(string.Format(GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_SubFoldersInRoot_Count_XPath_Locator));
            for (activityFolder1Index = 1; activityFolder1Index <= getFolderCount; activityFolder1Index++)
            {
                //Get the name of the folder
                base.WaitForElement(By.XPath(string.Format(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_SubFoldersInRoot_Name_XPath_Locator, activityFolder1Index)));
                string getFolderName = base.GetElementInnerTextByXPath(string.Format(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_SubFoldersInRoot_Name_XPath_Locator, activityFolder1Index));
                if (getFolderName == activityFolderName)
                {
                    //Expand sub folder 1
                    IWebElement expandL1Folder = base.GetWebElementPropertiesByXPath(string.Format(GBCustomViewUXPageResource.
                        GBCustomViewUXPage_StudentGrades_Level1Folder_PlusIcon_XPath_Locator, activityFolder1Index));
                    base.ClickByJavaScriptExecutor(expandL1Folder);
                    break;

                }
            }
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
            //Expand level 2 folder
            int activityFolder2Index;            
            base.WaitForElement(By.XPath(string.Format(GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_Level2SubFolders_Count_XPath_Locator, 
                activityFolder1Index)));
            //Get the sub folders count in level 2
            int getLevel2FolderCount = base.GetElementCountByXPath(string.Format(
                GBCustomViewUXPageResource.GBCustomViewUXPage_StudentGrades_Level2SubFolders_Count_XPath_Locator,
                activityFolder1Index));
            for (activityFolder2Index = 1; activityFolder2Index <= getLevel2FolderCount; activityFolder2Index++)
            {
                base.WaitForElement(By.XPath(string.Format(GBCustomViewUXPageResource.
                     GBCustomViewUXPage_StudentGrades_Level2SubFolder_Name_XPath_Locator,
                     activityFolder1Index, activityFolder2Index)));
               //Get the sub folders name in level 2
                string getFolderName = base.GetElementInnerTextByXPath(string.Format(
                    GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_Level2SubFolder_Name_XPath_Locator, 
                    activityFolder1Index, activityFolder2Index));
                if (getFolderName == activityFolderName)
                {
                    //Expand the folder in Level 2
                    base.WaitForElement(By.XPath(string.Format(
                    GBCustomViewUXPageResource.
                        GBCustomViewUXPage_StudentGrades_Level2Folder_PlusIcon_XPath_Locator, 
                        activityFolder1Index, activityFolder2Index)));
                    IWebElement expandL2Folder = base.GetWebElementPropertiesByXPath(string.Format(
                    GBCustomViewUXPageResource.
                        GBCustomViewUXPage_StudentGrades_Level2Folder_PlusIcon_XPath_Locator,
                        activityFolder1Index, activityFolder2Index));
                    base.ClickByJavaScriptExecutor(expandL2Folder);
                    break;
                }
            }
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
            int activityFolder3Index;  
            base.WaitForElement(By.XPath(string.Format(
                    GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_Level3SubFolders_Count_XPath_Locator, 
                activityFolder1Index, activityFolder2Index)));
            //Get the sub folders count in level 3
            int getLevel3FolderCount = base.GetElementCountByXPath(string.Format(
                    GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_Level3SubFolders_Count_XPath_Locator, 
                activityFolder1Index, activityFolder2Index));
            for (activityFolder3Index = 1; activityFolder3Index <= getLevel3FolderCount; activityFolder3Index++)
            {
                base.WaitForElement(By.XPath(string.Format(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_Level3SubFolder_Name_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index)));
                //Get the sub folders name in level 3
                string getFolderName = base.GetElementInnerTextByXPath(string.Format(
                    GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_Level3SubFolder_Name_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index));
                if (getFolderName == activityFolderName)
                {                   
                    base.WaitForElement(By.XPath(string.Format(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_Level3Folder_PlusIcon_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index)));
                    //Expand level 3 folder plus icon
                    IWebElement expandL3Folder = base.GetWebElementPropertiesByXPath(string.Format(
                    GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_Level3Folder_PlusIcon_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index));
                    base.ClickByJavaScriptExecutor(expandL3Folder);
                    break;
                }
            }
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
            base.WaitForElement(By.XPath(string.Format(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_Level4SubFolders_Count_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index)));
            int getLevel4FolderCount = base.GetElementCountByXPath(string.Format(
                   GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_Level4SubFolders_Count_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index));
            for (int activityFolder4Index = 1; activityFolder4Index <= getLevel4FolderCount; activityFolder4Index++)
            {
                base.WaitForElement(By.XPath(string.Format(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_Level4Folder_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder4Index, activityFolder4Index)));
                string getFolderName = base.GetElementInnerTextByXPath(string.Format(
                    GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_Level4Folder_XPath_Locator,
                    activityFolder1Index, activityFolder2Index, activityFolder3Index, activityFolder4Index));
                if (getFolderName.Contains(activityFolderName))
                {
                    //Click on the Folder name
                    IWebElement expandL4Folder = base.GetWebElementPropertiesByXPath(
                        string.Format(GBCustomViewUXPageResource.
                        GBCustomViewUXPage_StudentGrades_Level4Folder_XPath_Locator,                        
                          activityFolder1Index, activityFolder2Index, activityFolder3Index, activityFolder4Index));
                    base.PerformMouseClickAction(expandL4Folder);
                    break;
                }
            }
        }

        /// <summary>
        /// Verify the activity name displayed
        /// </summary>
        /// <param name="activityName">This is the Activity name.</param>
        /// <returns>Activity name.</returns>
        public string IsActivityDisplayedInGradesTab(string activityName)
        {
            base.SwitchToIFrameById(GBCustomViewUXPageResource.
                GBCustomViewUXPage_CustomView_Frame_ID_Locator);
            string getActivityName = string.Empty;
            base.WaitForElement(By.XPath(GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_ActivityCount_XPath_Locator));
            //Get the Activity count in Grades tab
            int getActivityCount = base.GetElementCountByXPath(GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_ActivityCount_XPath_Locator);
            for (int i = 1; i <= getActivityCount; i++)
            {
                //Get the Activity name in Grades tab
                getActivityName = base.GetElementInnerTextByXPath(string.Format(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_ActivityName_XPath_Locator, i));
                if (getActivityName == activityName)
                {
                    break;
                }
            }
            base.SwitchToDefaultPageContent();
            return getActivityName;
        }

        /// <summary>
        /// Verify the activity grade displayed
        /// </summary>
        /// <param name="activityName">This is the Activity name.</param>
        /// <param name="grade">This is the Activity grade.</param>
        /// <returns>Activity grade.</returns>
        public string IsActivityGradeDisplayedInGradesTab(string activityName,int grade)
        {
            base.SwitchToIFrameById(GBCustomViewUXPageResource.
                GBCustomViewUXPage_CustomView_Frame_ID_Locator);
            string getActivityName = string.Empty;
            string getActivitygrade = string.Empty;
            base.WaitForElement(By.XPath(GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_ActivityCount_XPath_Locator));
            int getActivityCount = base.GetElementCountByXPath(GBCustomViewUXPageResource.
                GBCustomViewUXPage_StudentGrades_ActivityCount_XPath_Locator);
            for (int i = 1; i <= getActivityCount; i++)
            {
                //Get the Activity Grade in Grades tab
                getActivityName = base.GetElementInnerTextByXPath(string.Format(GBCustomViewUXPageResource.
                    GBCustomViewUXPage_StudentGrades_ActivityName_XPath_Locator, i));
                if (getActivityName == activityName)
                {
                    getActivitygrade = base.GetElementInnerTextByXPath(string.Format(
                        GBCustomViewUXPageResource.GBCustomViewUXPage_StudentGrades_Activity_Grade_XPath_Locator, i));
                    break;
                }
            }
            base.SwitchToDefaultPageContent();
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
           switch(userTypeEnum)
           {
               case User.UserTypeEnum.CsSmsInstructor:
                   break;

               case User.UserTypeEnum.CsSmsStudent:
                   this.SelectActivitycMenuOption(cmenuOption, activityName);
                   break;
           }
        }

        private void SelectActivitycMenuOption(string cmenuOption, string activityName)
        {
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
                    base.SelectDropDownOptionById("35d15ecb-88ec-40a1-b497-2095239d1ac7",cmenuOption);
                    bool jhrjt = base.IsElementPresent(By.XPath("//a[@class = 'PU_render']"), 10);
                    bool hgfks = base.IsElementPresent(By.XPath("//div[contains(@id,'reference')]"), 10);
                    Thread.Sleep(2000);
                    IWebElement activityCmenu = base.GetWebElementPropertiesByPartialLinkText("cmenuOption");
                    base.PerformMouseClickAction(activityCmenu);
                   
                }
            }
        }
    }
}

