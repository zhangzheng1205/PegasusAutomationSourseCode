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
    }
}
