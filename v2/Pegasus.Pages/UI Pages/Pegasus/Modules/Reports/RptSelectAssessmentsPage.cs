using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus RptSelectAssessments Page Actions
    /// </summary>
    public class RptSelectAssessmentsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptSelectAssessmentsPage));

        /// <summary>
        /// Selecting the Activity in Instructor Report
        /// </summary>
        public void SelectActivityToGenerateInstructorReport()
        {
            //Select the Activity
            logger.LogMethodEntry("RptSelectAssessmentsPage", "SelectActivityToGenerateInstructorReport",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.WaitUntilWindowLoads(RptSelectAssessmentsResource.
                       RptSelectAssessments_Page_Ins_SelectActivities_Window_Title_Name);
                base.SelectWindow(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_SelectActivities_Window_Title_Name);
                //Selecting The Activity
                this.SelectActivityToGenerateReport();
                base.WaitForElement(By.PartialLinkText(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_Add_Link_Locator));
                //Click on Add Button
                base.ClickButtonByPartialLinkText(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_Add_Link_Locator);
                base.IsPopUpClosed(Convert.ToInt32(RptSelectAssessmentsResource.
                   RptSelectAssessments_Page_Ins_Window_Count));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectAssessmentsPage", "SelectActivityToGenerateInstructorReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the Writing space Activity in Instructor Report.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SelectWtritingspaceActivityToGenerateReport(string activityName)
        {
            //Select the Activity
            logger.LogMethodEntry("RptSelectAssessmentsPage",
                "SelectWtritingspaceActivityToGenerateReport",
                base.isTakeScreenShotDuringEntryExit);            
            try
            {
                base.SwitchToLastOpenedWindow();
                //Select Activity Radio button
                this.SelectActivityRadiobutton(activityName);
                //Click on Add Button
                this.ClickonAddButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectAssessmentsPage",
                "SelectWtritingspaceActivityToGenerateReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity Radio button.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void SelectActivityRadiobutton(string activityName)
        {
            //Select Activity Radio button
            logger.LogMethodEntry("RptSelectAssessmentsPage","SelectActivityRadiobutton",
                base.isTakeScreenShotDuringEntryExit);  
            base.WaitForElement(By.XPath(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_ActivityCount_Xpath_Locator));
            //Get Activity Count
            int getActivityCount = base.GetElementCountByXPath(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_ActivityCount_Xpath_Locator);
            for (int i = Convert.ToInt32(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_Activity_InitialCount_Value);
                i <= getActivityCount; i++)
            {
                base.WaitForElement(By.XPath(string.Format(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Activity_Text_Xpath_Locator, i)));
                //Get Activity Text
                string getActivityText =
                    base.GetElementTextByXPath(string.Format(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Activity_Text_Xpath_Locator, i));
                if (getActivityText == activityName)
                {
                    base.WaitForElement(By.XPath(string.Format(
                       RptSelectAssessmentsResource.
                       RptSelectAssessments_Page_ActivityRadiobutton_Xpath_Locator, i)));
                    //Select Activity Radio button
                    IWebElement getActivityRadiobutton =
                       base.GetWebElementPropertiesByXPath(string.Format(
                       RptSelectAssessmentsResource.
                       RptSelectAssessments_Page_ActivityRadiobutton_Xpath_Locator, i));
                    base.ClickByJavaScriptExecutor(getActivityRadiobutton);
                    break;
                }
            }
            logger.LogMethodExit("RptSelectAssessmentsPage","SelectActivityRadiobutton",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Button
        /// </summary>
        private void ClickonAddButton()
        {
            //Click on Add Button
            logger.LogMethodEntry("RptSelectAssessmentsPage","ClickonAddButton",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_Add_Link_Locator));
            //Click on Add Button
            base.ClickButtonByPartialLinkText(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_Add_Link_Locator);
            base.IsPopUpClosed(Convert.ToInt32(RptSelectAssessmentsResource.
               RptSelectAssessments_Page_Ins_Window_Count));
            logger.LogMethodExit("RptSelectAssessmentsPage","ClickonAddButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the RadioButton of the Activity in Instructor Report
        /// </summary>   
        private void SelectActivityToGenerateReport()
        {
            //Selecting Radibutton of Activity
            logger.LogMethodEntry("RptSelectAssessmentsPage", "SelectActivityToGenerateReport",
               base.isTakeScreenShotDuringEntryExit);
            //Get Count of Activity
            base.WaitForElement(By.XPath(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_ActivityCount_Xpath_Locator));
            //Initilizating Variable
            int getActivityCount = 1;
            //Get Student Name
            IWebElement selectActivityTextValue = base.GetWebElementPropertiesByXPath
                (string.Format(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_ActivitySelect_Xpath_Locator, getActivityCount));
            if (!selectActivityTextValue.Text.Contains(RptSelectAssessmentsResource
                .RptSelectAssessments_Page_Ins_ActivityName))
            {
                // Select activity on select activity window
                SelectStudentsActivity(getActivityCount, selectActivityTextValue);
            }
            else
            {
                base.WaitForElement(By.XPath(string.Format(RptSelectAssessmentsResource.
                      RptSelectAssessments_Page_Ins_Activity_Radibutton_Xpath_Locator, getActivityCount)));
                //Click on Activity Radio Button
                base.SelectCheckBoxByXPath(string.Format(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_Activity_Radibutton_Xpath_Locator, getActivityCount));
            }

            logger.LogMethodExit("RptSelectAssessmentsPage", "SelectActivityToGenerateReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select activity on Select activity window
        /// </summary>
        /// <param name="getActivityCount">This is activity count</param>
        /// <param name="selectActivityTextValue">This is Iwebelement text value</param>
        private void SelectStudentsActivity(int getActivityCount, IWebElement selectActivityTextValue)
        {
            logger.LogMethodEntry("RptSelectAssessmentsPage", "SelectStudentsActivity",
                base.isTakeScreenShotDuringEntryExit);
            while (!selectActivityTextValue.Text.Contains(RptSelectAssessmentsResource
                .RptSelectAssessments_Page_Ins_ActivityName))
            {
                getActivityCount = getActivityCount + 1;
                string getActivityTextValue = base.GetElementTextByXPath
               (string.Format(RptSelectAssessmentsResource.
               RptSelectAssessments_Page_Ins_ActivitySelect_Xpath_Locator, getActivityCount));

                if (RptSelectAssessmentsResource.RptSelectAssessments_Page_Ins_ActivityName == getActivityTextValue)
                {
                    base.WaitForElement(By.XPath(string.Format(RptSelectAssessmentsResource.
                        RptSelectAssessments_Page_Ins_Activity_Radibutton_Xpath_Locator, getActivityCount)));
                    //Click on Activity Radio Button
                    base.SelectCheckBoxByXPath(string.Format(RptSelectAssessmentsResource.
                        RptSelectAssessments_Page_Ins_Activity_Radibutton_Xpath_Locator, getActivityCount));
                    break;
                }
            }
            logger.LogMethodExit("RptSelectAssessmentsPage", "SelectStudentsActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity In Student Results By Activity Report
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        public void SelectActivityInStudentResultsByActivityReport(string activityName)
        {
            //Select Activity In Student Results by Activity Report
            logger.LogMethodEntry("RptSelectAssessmentsPage",
                "SelectActivityInStudentResultByActivityReport",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.SelectWindow(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Reports_Window_Name);
                //Wait for Frame
                base.WaitForElement(By.Id(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Frame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Frame_Id_Locator);
                base.WaitForElement(By.PartialLinkText(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_SelectActivities_Window_Title_Name));
                //Click On Select Activities Button
                base.ClickButtonByPartialLinkText(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_SelectActivities_Window_Title_Name);
                //Select the Activity
                this.SelectActivity(activityName);
                base.WaitForElement(By.PartialLinkText(RptSelectAssessmentsResource.
                       RptSelectAssessments_Page_Ins_Add_Link_Locator));
                //Click on Add Button
                base.ClickButtonByPartialLinkText(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_Add_Link_Locator);
                base.IsPopUpClosed(Convert.ToInt32(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_Window_Count));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectAssessmentsPage",
                "SelectActivityInStudentResultByActivityReport",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Activity
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        private void SelectActivity(string activityName)
        {
            //Select the Activity
            logger.LogMethodEntry("RptSelectAssessmentsPage", "SelectActivity",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(RptSelectAssessmentsResource.
                   RptSelectAssessments_Page_Ins_SelectActivities_Window_Title_Name);
            //Select Select Activities Window
            base.SelectWindow(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_SelectActivities_Window_Title_Name);
            base.WaitForElement(By.XPath(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_ActivityCount_Xpath_Locator));
            //Get Activity Count
            int getActivityCount = base.GetElementCountByXPath(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_ActivityCount_Xpath_Locator);
            for (int initialCount = Convert.ToInt32(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_Activity_InitialCount_Value);
                initialCount <= getActivityCount; initialCount++)
            {
                base.WaitForElement(By.XPath(string.Format(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_ActivitySelect_Xpath_Locator, initialCount)));
                //Get Activity Name
                string getActivityName = base.GetTitleAttributeValueByXPath(string.Format(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_ActivitySelect_Xpath_Locator, initialCount));
                if (getActivityName.Contains(activityName))
                {
                    //Wait for Activity CheckBox
                    base.WaitForElement(By.XPath(string.Format(RptSelectAssessmentsResource.
                        RptSelectAssessments_Page_Ins_Checkbox_Xpath_Locator, initialCount)));
                    base.FocusOnElementByXPath((string.Format(RptSelectAssessmentsResource.
                        RptSelectAssessments_Page_Ins_Checkbox_Xpath_Locator, initialCount)));
                    //Click On Activity Checkbox
                    base.ClickButtonByXPath((string.Format(RptSelectAssessmentsResource.
                        RptSelectAssessments_Page_Ins_Checkbox_Xpath_Locator, initialCount)));
                    break;
                }
            }
            logger.LogMethodExit("RptSelectAssessmentsPage", "SelectActivity",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Name.
        /// </summary>
        /// <returns>Activity Name.</returns>        
        /// <param name="activityName">This is Activity Name.</param>
        public String GetActivityName(string activityName)
        {
            //Get Activity Name
            logger.LogMethodEntry("RptSelectAssessmentsPage", "GetActivityName",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSearchedActivityName = string.Empty;
            string getActivityName = string.Empty;
            try
            {
                //Select Window
                this.SelectWindow();
                base.WaitForElement(By.XPath(RptSelectAssessmentsResource.
                   RptSelectAssessments_Page_Ins_ActivityCount_Xpath_Locator));
                //Get Activity Count
                int getActivityCount = base.GetElementCountByXPath(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_ActivityCount_Xpath_Locator);
                for (int initialCount = Convert.ToInt32(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_Activity_InitialCount_Value);
                    initialCount <= getActivityCount; initialCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(RptSelectAssessmentsResource.
                        RptSelectAssessments_Page_Ins_ActivitySelect_Xpath_Locator, initialCount)));
                    //Get Activity Name
                    getSearchedActivityName = base.GetTitleAttributeValueByXPath(
                        string.Format(RptSelectAssessmentsResource.
                       RptSelectAssessments_Page_Ins_ActivitySelect_Xpath_Locator, initialCount));
                    if (getSearchedActivityName.Contains(activityName))
                    {
                        getActivityName = activityName;
                        break;
                    }
                }
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectAssessmentsPage", "GetActivityName",
                  base.isTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Select Study Plan For Study Plan Results Report
        /// </summary>
        /// <param name="activityName">This is Study Plan Name</param>
        public void SelectStudyPlanInStudyPlanResultsReport(string studyPlanName)
        {
            //Select StudyPlan In Study Plan Results Report
            logger.LogMethodEntry("RptSelectAssessmentsPage",
                "SelectStudyPlanInStudyPlanResultsReport",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.SelectWindow(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Reports_Window_Name);
                //Wait for Frame
                base.WaitForElement(By.Id(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Frame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Frame_Id_Locator);
                base.WaitForElement(By.PartialLinkText(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_SelectStudyPlans_Window_Title_Name));
                //Click On Select Study Plan Button
                base.ClickButtonByPartialLinkText(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_SelectStudyPlans_Window_Title_Name);
                //Select the Study Plan
                this.SelectStudyPlan(studyPlanName);
                base.WaitForElement(By.PartialLinkText(RptSelectAssessmentsResource.
                       RptSelectAssessments_Page_Ins_Add_Link_Locator));
                //Click on Add Button
                base.ClickButtonByPartialLinkText(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_Add_Link_Locator);
                //Make sure the pop up is closed
                base.IsPopUpClosed(Convert.ToInt32(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_Window_Count));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectAssessmentsPage",
                "SelectStudyPlanInStudyPlanResultsReport",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Study Plan
        /// </summary>
        /// <param name="activityName">This is the Study Plan Name to be selected</param>
        private void SelectStudyPlan(string studyPlanName)
        {
            logger.LogMethodEntry("RptSelectAssessmentsPage", "SelectStudyPlan",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(RptSelectAssessmentsResource.
                   RptSelectAssessments_Page_Ins_SelectStudyPlans_Popup_Window_Title_Name);
            //Select Select Study Plan Window
            base.SelectWindow(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_SelectStudyPlans_Popup_Window_Title_Name);
            base.WaitForElement(By.XPath(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_ActivityCount_Xpath_Locator));
            //Get Study Plan Count
            int getActivityCount = base.GetElementCountByXPath(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_ActivityCount_Xpath_Locator);
            for (int initialCount = Convert.ToInt32(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_Activity_InitialCount_Value);
                initialCount <= getActivityCount; initialCount++)
            {
                base.WaitForElement(By.XPath(string.Format(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_ActivitySelect_Xpath_Locator, initialCount)));
                //Get Study Plan Name
                string getActivityName = base.GetTitleAttributeValueByXPath(string.Format(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_ActivitySelect_Xpath_Locator, initialCount));
                if (getActivityName.Contains(studyPlanName))
                {
                    //Wait for study plan CheckBox
                    base.WaitForElement(By.XPath(string.Format(RptSelectAssessmentsResource.
                        RptSelectAssessments_Page_Ins_Checkbox_Xpath_Locator, initialCount)));
                    base.FocusOnElementByXPath((string.Format(RptSelectAssessmentsResource.
                        RptSelectAssessments_Page_Ins_Checkbox_Xpath_Locator, initialCount)));
                    //Click On study plan Checkbox
                    base.ClickButtonByXPath((string.Format(RptSelectAssessmentsResource.
                        RptSelectAssessments_Page_Ins_Checkbox_Xpath_Locator, initialCount)));
                    break;
                }
            }
            logger.LogMethodExit("RptSelectAssessmentsPage", "SelectStudyPlan",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("RptSelectAssessmentsPage", "SelectWindow",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(RptSelectAssessmentsResource.
                  RptSelectAssessments_Page_Ins_SelectActivities_Window_Title_Name);
            //Select Select Activities Window
            base.SelectWindow(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_SelectActivities_Window_Title_Name);
            logger.LogMethodExit("RptSelectAssessmentsPage", "SelectWindow",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Exam Asset
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        public void SelectExamAsset(string assetName)
        {
            //Select Exam Asset
            logger.LogMethodEntry("RptSelectAssessmentsPage", "SelectExamAsset",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Exam Window
                this.SelectExamWindow();
                //Select Exam
                this.SelectExam(assetName);
                //Click On Add Button
                this.ClickOnAddButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectAssessmentsPage", "SelectExamAsset",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Exam Window
        /// </summary>
        private void SelectExamWindow()
        {
            //Select Exam Window
            logger.LogMethodEntry("RptSelectAssessmentsPage", "SelectExamWindow",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_SelectExam_Window_Name);
            //Select Select Exam Window
            base.SelectWindow(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_SelectExam_Window_Name);
            logger.LogMethodExit("RptSelectAssessmentsPage", "SelectExamWindow",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Exam
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        private void SelectExam(string assetName)
        {
            //Select Exam
            logger.LogMethodEntry("RptSelectAssessmentsPage", "SelectExam",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSearchedActivityName = string.Empty;
            //Get Count of Activity
            base.WaitForElement(By.XPath(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_ActivityCount_Xpath_Locator));
            base.WaitForElement(By.XPath(RptSelectAssessmentsResource.
                  RptSelectAssessments_Page_Ins_ActivityCount_Xpath_Locator));
            //Get Activity Count
            int getActivityCount = base.GetElementCountByXPath(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_ActivityCount_Xpath_Locator);
            for (int initialCount = Convert.ToInt32(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_Activity_RowNo);
                initialCount <= getActivityCount; initialCount++)
            {
                base.WaitForElement(By.XPath(string.Format(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_ActivitySelect_Xpath_Locator, initialCount)));
                //Get Activity Name
                getSearchedActivityName = base.GetTitleAttributeValueByXPath(string.Format(RptSelectAssessmentsResource.
                    RptSelectAssessments_Page_Ins_ActivitySelect_Xpath_Locator, initialCount));
                if (getSearchedActivityName == assetName)
                {
                    base.WaitForElement(By.XPath(string.Format(RptSelectAssessmentsResource.
                      RptSelectAssessments_Page_Ins_Activity_Radibutton_Xpath_Locator, getActivityCount)));
                    //Click on Activity Radio Button
                    base.SelectCheckBoxByXPath(string.Format(RptSelectAssessmentsResource.
                        RptSelectAssessments_Page_Ins_Activity_Radibutton_Xpath_Locator, getActivityCount));
                    break;
                }
            }
            logger.LogMethodExit("RptSelectAssessmentsPage", "SelectExam",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Button
        /// </summary>
        private void ClickOnAddButton()
        {
            logger.LogMethodEntry("RptSelectAssessmentsPage", "ClickOnAddButton",
              base.isTakeScreenShotDuringEntryExit);
            //Click On Add Button
            base.WaitForElement(By.ClassName(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_AddButton_Class_Locator));
            //Get Add Button Peoperty
            IWebElement getAddButtonProperty = base.GetWebElementPropertiesByClassName
                (RptSelectAssessmentsResource.
                RptSelectAssessments_Page_AddButton_Class_Locator);
            //Click On Add Button
            base.ClickByJavaScriptExecutor(getAddButtonProperty);
            logger.LogMethodExit("RptSelectAssessmentsPage", "ClickOnAddButton",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Exams Activity In Report.
        /// </summary>
        public void SelectTheExamsActivityInReport()
        {
            //Select The Exams Activity In Report
            logger.LogMethodEntry("RptSelectAssessmentsPage",
                "SelectTheExamsActivityInReport",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                this.SelectExamWindow();
                //Get Activity From Memory
                Activity activity = Activity.Get(Activity.ActivityTypeEnum.Test);
                //Get Activity Column Count
                int getActivityColumnCount =
                     new RptSaveReportPage().GetActivityColumnCount(activity.Name);
                //Select Student CheckBox
                new RptSaveReportPage().SelectStudentCheckBox(getActivityColumnCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectAssessmentsPage",
                "SelectTheExamsActivityInReport",
                base.isTakeScreenShotDuringEntryExit);
        }


    }
}
