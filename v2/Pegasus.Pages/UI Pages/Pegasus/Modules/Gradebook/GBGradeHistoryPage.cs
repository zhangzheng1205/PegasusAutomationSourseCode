using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus GBGradeHistory Page Actions.
    /// </summary>
  public class GBGradeHistoryPage: BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(GBGradeHistoryPage));

       /// <summary>
        /// Get Instructor Updated View Grade History NewScore.
        /// </summary>
        /// <param name="userFirstName">This is User First name.</param>
        /// <param name="userLastName">This is User Last name.</param>
        /// <returns>updated score</returns>
        public String GetInstructorUpdatedViewGradeHistoryNewScore(
            String userLastName, String userFirstName)
        {
            //Get Instructor Updated View Grade History NewScore
            Logger.LogMethodEntry("GBGradeHistoryPage", "GetInstructorUpdatedViewGradeHistoryNewScore",
              base.isTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getViewGradeNewScoreValue = string.Empty;
            try
            {
                //Select View Grade History Window
                this.SelectViewGradeHistoryWindow();
                //Get User Row Count
                int getUserRowCount = this.GetUserRowCount(userLastName, userFirstName);
                string getNewScore = base.GetElementTextByXPath(string.Format(GBGradeHistoryPageResource.
                    GBGradeHistory_Page_NewScore_Grade_Xpath_Locator, getUserRowCount));
                //Get the New score
                getViewGradeNewScoreValue = getNewScore.Substring(Convert.ToInt32(GBGradeHistoryPageResource.
                    GBGradeHistory_Page_Initial_Substring_Value), Convert.ToInt32(
                    GBGradeHistoryPageResource.GBGradeHistory_Page_Initial_Substring_LastValue));
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("GBGradeHistoryPage", "GetInstructorUpdatedViewGradeHistoryNewScore",
                 base.isTakeScreenShotDuringEntryExit);
            return getViewGradeNewScoreValue;
        }

        /// <summary>
        /// Get Instructor Updated View Grade History OldScore.
        /// </summary>
        /// <param name="userFirstName">This is User First name.</param>
        /// <param name="userLastName">This is User Last name.</param>
        /// <returns>previous score</returns>
        public string GetInstructorUpdatedViewGradeHistoryOldScore(
            String userLastName, String userFirstName)
        {
            //Get Instructor Updated View Grade History OldScore
          Logger.LogMethodEntry("GBGradeHistoryPage", "GetInstructorUpdatedViewGradeHistoryOldScore",
            base.isTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getViewGradeOldScoreValue= string.Empty;
            try
            {
                //Select View Grade History Window
                this.SelectViewGradeHistoryWindow();
                //Get User Row Count
                int getUserRowCount = this.GetUserRowCount(userLastName, userFirstName);
                string getOldScore = base.GetElementTextByXPath(string.Format
                    (GBGradeHistoryPageResource.GBGradeHistory_Page_OldScore_Grade_Xpath_Locator,
                   getUserRowCount));
                //Get the old score
                getViewGradeOldScoreValue = getOldScore.Substring(Convert.ToInt32(GBGradeHistoryPageResource.
                    GBGradeHistory_Page_Initial_Substring_Value), Convert.ToInt32(
                    GBGradeHistoryPageResource.GBGradeHistory_Page_Initial_Substring_LastValue));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
         Logger.LogMethodExit("GBGradeHistoryPage", "GetInstructorUpdatedViewGradeHistoryOldScore",
           base.isTakeScreenShotDuringEntryExit);
            return getViewGradeOldScoreValue;
        }
       
        /// <summary>
        /// Select View Grade History Window.
        /// </summary>
        private void SelectViewGradeHistoryWindow()
        {
            //Select View Grade History Window
            Logger.LogMethodEntry("GBGradeHistoryPage", "SelectViewGradeHistoryWindow",
              base.isTakeScreenShotDuringEntryExit);
            //Select the window
            base.WaitUntilWindowLoads(GBGradeHistoryPageResource.
                GBGradeHistory_Page_Window_Name);
            base.SelectWindow(GBGradeHistoryPageResource.
                GBGradeHistory_Page_Window_Name);
            Logger.LogMethodExit("GBGradeHistoryPage", "SelectViewGradeHistoryWindow",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get User RowCount.
        /// </summary>
        /// <param name="userFirstName">This is User First name.</param>
        /// <param name="userLastName">This is User Last name.</param>
        /// <returns>This is User Row Number</returns>
       private int GetUserRowCount(
           String userLastName, String userFirstName)
       {
           // Get User RowCount
           Logger.LogMethodEntry("GBGradeHistoryPage", "GetUserRowCount",
             base.isTakeScreenShotDuringEntryExit);
           //Initialize VariableVariable
           int userRowNumber = Convert.ToInt32(GBGradeHistoryPageResource.
               GBGradeHistory_Page_Initial_Count);
            //Get User Count
           int getUserCount = base.GetElementCountByXPath(GBGradeHistoryPageResource.
               GBGradeHistory_Page_User_Count_Xpath_Locator);
            for (int userRowCount = Convert.ToInt32(GBGradeHistoryPageResource.
                 GBGradeHistory_Page_Initial_Value); userRowCount <= getUserCount;
                 userRowCount++)
            {
                //Get user Name
                string getUserName = base.GetElementTextByXPath(string.Format(
                    GBGradeHistoryPageResource.GBGradeHistory_Page_User_Name_Xpath_Locator,
                    userRowCount));
                if (getUserName == userLastName + GBInstructorUXPageResource.
                    GBInstructorUX_Page_Space_value + userFirstName)
                {
                    userRowNumber = userRowCount;
                    break;
                }
            }
           Logger.LogMethodExit("GBGradeHistoryPage", "GetUserRowCount",
                base.isTakeScreenShotDuringEntryExit);
           return userRowNumber;
       }
    }
}
