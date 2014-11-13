using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using System.Windows.Forms;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;
using System.Text.RegularExpressions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the CoursePreviewmainUX Page Actions.
    /// Preview
    /// </summary>
    public class CoursePreviewMainUXPage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CoursePreviewMainUXPage));

        /// <summary>
        /// This is the space in pegasus where user will be logged in.
        /// </summary>
        public enum OpenActivityTab
        {
            /// <summary>
            /// View All Content Tab
            /// </summary>
            ViewAllContent = 1,
            /// <summary>
            /// Practice Tab
            /// </summary>
            Practice
        }


        /// <summary>
        /// This is Activity Cmenu Enum
        /// </summary>
        public enum ActivityCmenuEnum
        {
            GetInformation=1,
            SetSchedulingOptions=2,
            ViewSubmissions=3
        }

        /// <summary>
        /// Click to Open Activity Presentation Window.
        /// </summary>
        public void OpenActivity()
        {
            // Open Activity
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "OpenActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectCourseMaterialsWindow();
                //Select Root Folder in Course Materials
                this.SelectRootFolderInCourseMaterials();
                //Select Activity Sub Folder
                base.WaitForElement(By.PartialLinkText(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_AssetFolder_Level2_Name));
                base.ClickButtonByPartialLinkText(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_AssetFolder_Level2_Name);
                //Select Activity
                base.WaitForElement(By.PartialLinkText(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Activity_Name));
                //Click Button
                IWebElement getActivityName = base.GetWebElementPropertiesByPartialLinkText
                    (CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Activity_Name);
                base.ClickByJavaScriptExecutor(getActivityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "OpenActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Root Folder in Course Materials.
        /// </summary>
        private void SelectRootFolderInCourseMaterials()
        {
            // Select Root Folder in Course Materials
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "SelectRootFolderInCourseMaterials",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Activity Root Folder
            base.WaitForElement(By.PartialLinkText(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_AssetFolder_Level1_Name));
            base.ClickButtonByPartialLinkText(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_AssetFolder_Level1_Name);
            Logger.LogMethodExit("CoursePreviewMainUXPage", "SelectRootFolderInCourseMaterials",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        public void SelectCourseMaterialsWindow()
        {
            //Select Window
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "SelectCourseMaterialsWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Window_Title_Name_HED);
                base.SelectWindow(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Window_Title_Name_HED);
                base.WaitForElement(By.Id(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_CoursePreview_IFrame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_CoursePreview_IFrame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "SelectCourseMaterialsWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch The Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This Is Activity Type Enum.</param>
        public void OpenActivity(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Get Activity Type
            Activity activity = Activity.Get(activityTypeEnum);
            OpenActivity(activity.Name);
        }

        /// <summary>
        /// Select Course Preview Frame
        /// </summary>
        private void SelectCoursePreviewFrame()
        {
            //Select Course Preview Frame
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "SelectCoursePreviewFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_CoursePreview_IFrame_Id_Locator));
            //Navigate To ViewAll Course Material Iframe
            base.SwitchToIFrame(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_CoursePreview_IFrame_Id_Locator);
            Logger.LogMethodExit("CoursePreviewMainUXPage", "SelectCoursePreviewFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch Pretest Of A Studyplan
        /// </summary>
        public void LaunchPretest()
        {
            //Launch Pretest Of A Studyplan
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "LaunchPretest",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Begin Button
                base.WaitForElement(By.CssSelector(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_BeginButton_CssSelector_Locator),
                    Convert.ToInt32(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_TimeToWait_Value));
                //Focus on begin button
                base.FillEmptyText(By.CssSelector(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_BeginButton_CssSelector_Locator));
                //Click On begin Button
                base.ClickButtonByCssSelector(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_BeginButton_CssSelector_Locator);
                // Close Activity Alert
                new ShowMessagePage().ClickContinueInActivityAlert();
                //Select The Last Opened Window
                base.SwitchToLastOpenedWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "LaunchPretest",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch Post Test.
        /// </summary>
        public void LaunchPostTest()
        {
            //Launch Post Test
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "LaunchPostTest",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Practice Window
                base.WaitUntilWindowLoads(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Practice_Window_Name);
                base.SelectWindow(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Practice_Window_Name);
                //Select Activity Frame
                this.SelectActivityFrame();
                base.WaitForElement(By.Id(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_PostTest_Id_Locator));
                //Get Button Property
                IWebElement getPostTestProperty = base.GetWebElementPropertiesById(
                    CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_PostTest_Id_Locator);
                //Click on Post Test
                base.ClickByJavaScriptExecutor(getPostTestProperty);
                Thread.Sleep(Convert.ToInt32(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Sleep_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "LaunchPostTest",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open Activity in View All Content.
        /// </summary>
        /// <param name="activityName">This is activity Name.</param>
        /// <param name="openActivityTab">This is tab type enum. </param>
        public void OpenActivityInTab(
            string activityName, OpenActivityTab openActivityTab)
        {
            //Open Activity in View All Content
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "OpenActivityInTab",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Activity Open Tab Option
                switch (openActivityTab)
                {
                    //Open Activity In View All Content Tab
                    case OpenActivityTab.ViewAllContent:
                        this.OpenActivityInViewAllContentTab(activityName);
                        break;
                    //Open Activity In Practice Tab
                    case OpenActivityTab.Practice:
                        new StudentExplorePage().OpenActivityInPracticeTab(activityName);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "OpenActivityInTab",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open Activity In View All Content Tab.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        private void OpenActivityInViewAllContentTab(
            string activityName)
        {
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "OpenActivityInViewAllContentTab",
             base.IsTakeScreenShotDuringEntryExit);
            //Wait for Content Window
            base.WaitUntilWindowLoads(CoursePreviewMainUXPageResource.
                                     CoursePreviewMainUX_Page_Content_Window_Name);
            //Select Window
            base.SelectWindow(CoursePreviewMainUXPageResource.
                                  CoursePreviewMainUX_Page_Content_Window_Name);
            //Select Activity Frame
            this.SelectActivityFrame();
            base.WaitForElement(By.LinkText(activityName));
            IWebElement getActivityName=base.GetWebElementPropertiesByPartialLinkText
                (activityName);
            //Click on activity name
            base.ClickByJavaScriptExecutor(getActivityName);
            Logger.LogMethodExit("CoursePreviewMainUXPage", "OpenActivityInViewAllContentTab",
             base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Open Activity In View All Content Tab.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void ClickActivityInViewAllContentTab(
            string activityName)
        {
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "ClickActivityInViewAllContentTab",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Activity Frame
                this.SelectActivityFrame();
                base.WaitForElement(By.LinkText(activityName));
                //Click on activity name
                base.ClickButtonByLinkText(activityName);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickActivityInViewAllContentTab",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Content Window
        /// </summary>
        public void SelectContentWindow()
        {
            // Select Content Window
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "SelectContentWindow",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Content Window
                base.WaitUntilWindowLoads(CoursePreviewMainUXPageResource.
                   CoursePreviewMainUX_Page_Content_Window_Name);
                //Select Window
                base.SelectWindow(CoursePreviewMainUXPageResource.
                   CoursePreviewMainUX_Page_Content_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "SelectContentWindow",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity Frame
        /// </summary>
        private void SelectActivityFrame()
        {
            //Select Activity Frame
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "SelectActivityFrame",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait gor Activity Frame
            base.WaitForElement(By.Id(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_Frame_Id_Locator));
            base.SwitchToIFrame(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_Frame_Id_Locator);
            Logger.LogMethodExit("CoursePreviewMainUXPage", "SelectActivityFrame",
             base.IsTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Navigate Inside Activity Folder.
        /// </summary>
        private void NavigateInsideActivityFolder()
        {
            //Navigate Inside Activity Folder
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "NavigateInsideActivityFolder",
                 base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(
                     By.Id(CoursePreviewMainUXPageResource.
                     CoursePreviewMainUX_Page_PostTestActivity_Link_Id_Locator));
            //Get Link Property
            IWebElement getLinkButtonProperty = base.GetWebElementPropertiesById
                (CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_PostTestActivity_Link_Id_Locator);
            //Click on Link Button
            base.ClickByJavaScriptExecutor(getLinkButtonProperty);
            Logger.LogMethodExit("CoursePreviewMainUXPage", "NavigateInsideActivityFolder",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into The Activity Folder HED
        /// </summary>
        public void LaunchTheActivityHED()
        {
            //Enter Into the Activity Folder
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "LaunchTheActivityHED",
                 base.IsTakeScreenShotDuringEntryExit);
            //Select the folder
            this.EnterIntoTheAsset(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_ManuallyGradableAssetFolder_Level1_Name);
            //Select the Sub folder
            this.EnterIntoTheAsset(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_ManuallyGradableAssetFolder_Level2_Name);
            //Open the Activity 
            this.EnterIntoTheAsset(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_Essay_Activity_Name);
            Logger.LogMethodExit("CoursePreviewMainUXPage", "LaunchTheActivityHED",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into The Asset.
        /// </summary>
        /// <param name="assetName">This is asset name.</param>
        private void EnterIntoTheAsset(String assetName)
        {
            //Enter Into The Asset
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "EnterIntoTheAsset",
                    base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_Window_Title_Name_HED);
            //Select the 'Course Materials' Window
            base.SelectWindow(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_Window_Title_Name_HED);
            //Select the Frame
            SelectActivityFrame();
            //Click on the Asset Name
            base.WaitForElement(By.PartialLinkText(assetName));
            base.FocusOnElementByPartialLinkText(assetName);
            IWebElement getAssetName=base.GetWebElementPropertiesByPartialLinkText
                (assetName);           
            base.ClickByJavaScriptExecutor(getAssetName);
            Logger.LogMethodExit("CoursePreviewMainUXPage", "EnterIntoTheAsset",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt Essay Activity.
        /// </summary>
        /// <param name="answerText">This is Answer Text.</param>
        public void AttemptEssayActivity(
            string answerText)
        {
            //Attempt Essay Activity
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "AttemptEssayActivity",
                    base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.SelectWindow(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Video_Activity_Window_Name);
                base.WaitForElement(By.XPath(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Answer_TextArea_Xpath_Locator));
                //Enter the Answer text
                base.GetWebElementPropertiesByXPath(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Answer_TextArea_Xpath_Locator).
                    SendKeys(answerText);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "AttemptEssayActivity",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fetch Status Of Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Status Text</returns>
        public String GetStatusOfActivity(
            string activityName)
        {
            //Fetch the Status
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "GetStatusOfActivity",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize getStatusText
            string getStatusText = string.Empty;
            try
            {
                //Select the Window
                base.SelectWindow(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_Window_Title_Name_HED);
                //Select the Frame
                SelectActivityFrame();
                //Total Row count of the Assets
                int getTotalRowCount = base.GetElementCountByXPath(
                    CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Assets_Count_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Loop_Initialization_Value);
                    rowCount <= getTotalRowCount; rowCount++)
                {
                    //Get the Activity Name
                    getStatusText = base.GetElementTextByXPath(string.
                        Format(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Activity_Name_Xpath_Locator,
                        rowCount + Convert.ToInt32(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Assets_Row_Increment_Value)));
                    if (getStatusText.Contains(activityName))
                    {
                        //Get the status text
                        getStatusText = base.GetElementTextByXPath(string.
                            Format(CoursePreviewMainUXPageResource.
                            CoursePreviewMainUX_Page_Activity_Status_Xpath_Locator,
                            rowCount + Convert.ToInt32(CoursePreviewMainUXPageResource.
                            CoursePreviewMainUX_Page_Assets_Row_Increment_Value)));
                        base.SwitchToDefaultPageContent();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "GetStatusOfActivity",
                    base.IsTakeScreenShotDuringEntryExit);
            return getStatusText;
        }

        /// <summary>
        /// Get Status Of Activity In View All Content tab.
        /// </summary>
        /// <param name="activityName">This is Activity by type.</param>
        /// <returns>Activity Status.</returns>
        public String GetStatusOfActivityInViewAllContentTab
            (string activityName)
        {
            //Get Status Of Activity In View All Content tab
            Logger.LogMethodEntry("CoursePreviewMainUXPage",
                "GetStatusOfActivityInViewAllContentTab",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize getStatusText
            string getActivityStatus = string.Empty;
            try
            {
                //Wait For Window Gets Load
                base.WaitUntilWindowLoads(CoursePreviewMainUXPageResource.
                       CoursePreviewMainUX_Page_ContentWindow_Title_Name);
                //Select the window
                base.SelectWindow(CoursePreviewMainUXPageResource.
                       CoursePreviewMainUX_Page_ContentWindow_Title_Name);
                //Switch To Frame
                base.SwitchToIFrame(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_CoursePreview_IFrame_Id_Locator);
                getActivityStatus = this.GetStatusOfSubmittedActivity
                            (activityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage",
                "GetStatusOfActivityInViewAllContentTab",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivityStatus;
        }

        /// <summary>
        /// Get Status Of Activity In Course Materials tab.
        /// </summary>    
        /// <param name="assetName">This is Asset Name</param>
        /// <returns>Activity Status</returns>
        public String GetStatusOfActivityInCourseMaterialsTab(string assetName)
        {
            //Get Status Of Activity In Course Materials Tab
            Logger.LogMethodEntry("CoursePreviewMainUXPage",
                "GetStatusOfActivityInCourseMaterialsTab",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize getStatusText
            string getActivityStatus = string.Empty;
            try
            {                
                //Select the window and Frame
                this.SelectCourseMaterialsWindow();
                //Get Activity Status
                getActivityStatus = this.GetStatusOfSubmittedActivity(assetName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage",
                "GetStatusOfActivityInCourseMaterialsTab",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivityStatus;
        }

        /// <summary>
        /// Get Status Of Submitted Activity. 
        /// </summary>
        /// <param name="activityType">This is Activity .</param>
        /// <returns>Activity Status</returns>
        public String GetStatusOfSubmittedActivity(
            string assetName)
        {
            //Get Status Of Submitted Activity 
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "GetStatusOfSubmittedActivity",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize getStatusText variable
            string getActivitySubmittedStatus = string.Empty;
            //Initialize Variable
            string getActivityName = string.Empty;
            //Total Row count of the Assets
            int getTotalRowCount = base.GetElementCountByXPath(
                CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_Assets_Count_Xpath_Locator);
            try
            {
                for (int setRowCount = Convert.ToInt32(CoursePreviewMainUXPageResource.
                       CoursePreviewMainUX_Page_Asset_Loop_Initialization_Value);
                       setRowCount <= getTotalRowCount; setRowCount++)
                {
                    //Getting the assets name               
                    getActivityName = base.GetElementTextByXPath
                     (string.Format(CoursePreviewMainUXPageResource.
                     CoursePreviewMainUX_Page_Assets_Name_Xpath_Locator, setRowCount));
                    if (getActivityName.Contains(assetName))
                    {
                        //Get the status text                    
                        getActivitySubmittedStatus = base.GetElementTextByXPath(string.
                        Format(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Assets_Status_Xpath_Locator, setRowCount));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "GetStatusOfSubmittedActivity",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivitySubmittedStatus;
        }

        /// <summary>
        /// Click to Open Activity in Course Materials.
        /// </summary>
        public void OpenActivityInCourseMaterials()
        {
            // Click to Open Activity in Course Materials
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "OpenActivityInCourseMaterials",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectCourseMaterialsWindow();
                //Select Root Folder in Course Materials
                this.SelectRootFolderInCourseMaterials();
                //Select Activity Sub Folder
                base.WaitForElement(By.PartialLinkText(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Asset_SubFolder_Name));
                base.ClickButtonByPartialLinkText(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Asset_SubFolder_Name);
                //Select Activity
                base.WaitForElement(By.PartialLinkText(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Student_StudyPlan_Name));
                //Click Button
                IWebElement getActivityName = base.GetWebElementPropertiesByPartialLinkText
                    (CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Student_StudyPlan_Name);
                base.ClickByJavaScriptExecutor(getActivityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "OpenActivityInCourseMaterials",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Name In Course Materials Tab.
        /// </summary>
        /// <param name="assetName">This is Activity Name.</param>
        /// <returns>Activity Name</returns>
        public String GetActivityNameInCourseMaterialsTab(string assetName)
        {
            // Get Activity Name In Course Materials Tab
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "GetActivityNameInCourseMaterialsTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize getActivityText variable
            string getActivityName = string.Empty;
            try
            {
                //Select the window
                this.SelectCourseMaterialsWindow();
                //Total Row count of the Assets
                int getTotalRowCount = base.GetElementCountByXPath(
                    CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Assets_Count_Xpath_Locator);
                for (int setRowCount = Convert.ToInt32(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Asset_Loop_Initialization_Value);
                    setRowCount <= getTotalRowCount; setRowCount++)
                {
                    //Getting the assets name               
                    getActivityName = base.GetElementTextByXPath
                     (string.Format(CoursePreviewMainUXPageResource.
                     CoursePreviewMainUX_Page_Assets_Name_Xpath_Locator, setRowCount));
                    if (getActivityName == assetName)
                    {
                        base.FocusOnElementByXPath(string.Format(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Assets_Name_Xpath_Locator, setRowCount));
                        //Wait for the element
                        base.WaitForElement(By.PartialLinkText(getActivityName));
                        IWebElement getAssetName = base.GetWebElementPropertiesByPartialLinkText
                            (getActivityName);
                        //Click the asset
                        base.ClickByJavaScriptExecutor(getAssetName);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "GetActivityNameInCourseMaterialsTab",
                  base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;           
        }

        /// <summary>
        /// Open The Activity In Student Course Materials.
        /// </summary>
        /// <param name="assetName">This is Activity Name.</param>
        public void OpenTheActivityInStudentCourseMaterials(string assetName)
        {
            //Open The Activity In Student Course Materials
            Logger.LogMethodEntry("CoursePreviewMainUXPage",
                "OpenTheActivityInStudentCourseMaterials",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                this.SelectCourseMaterialsWindow();
                base.WaitForElement(By.PartialLinkText(assetName));
                IWebElement getActivityName = base.GetWebElementPropertiesByPartialLinkText
                    (assetName);
                //Click on activity name
                base.ClickByJavaScriptExecutor(getActivityName);
                Thread.Sleep(Convert.ToInt32(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_ElementWait_Value));
                base.SwitchToLastOpenedWindow();
                base.CloseBrowserPopUpByJavaScriptExecutor();
                //Used SendKeys to Close modal pop up
                SendKeys.SendWait(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_PresssEnterKey);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage",
                "OpenTheActivityInStudentCourseMaterials",
                  base.IsTakeScreenShotDuringEntryExit);
        }
   
        /// <summary>
        /// Select Activity Cmenu Option
        /// </summary>
        /// <param name="activityCmenuEnum">This is Activity Cmenu Type</param>
        /// <param name="activityName">This is activity Name</param>
        public void SelectActivityCmenuOption(ActivityCmenuEnum activityCmenuEnum,String activityName)
        {
            //Select Activity 
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "SelectActivityCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Course Materials Window
                this.SelectCourseMaterialsWindow();
                //Click On Activity Cmenu
                this.ClickOnActivityCmenu(activityName);
                switch (activityCmenuEnum)
                {
                    case CoursePreviewMainUXPage.ActivityCmenuEnum.GetInformation:
                        //Click On GetInfomration Option
                        this.ClickOnGetInformationOption();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "SelectActivityCmenuOption",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity Cmenu
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        private void ClickOnActivityCmenu(String activityName)
        {
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "ClickOnActivityCmenu",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            int activityCount;
            //Initialize Variable
            string getActivityname = string.Empty;            
            base.WaitForElement(By.XPath(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Assets_Count_Xpath_Locator));
            //Get Activity Count
            activityCount = base.GetElementCountByXPath(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Assets_Count_Xpath_Locator);
             for(int initialCount =Convert.ToInt32(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Asset_Loop_Initialization_Value);
                    initialCount<=activityCount;initialCount++)
             {
                 //Get Activity Name
                 getActivityname = base.GetElementTextByXPath
                         (string.Format(CoursePreviewMainUXPageResource.
                         CoursePreviewMainUX_Page_Assets_Name_Xpath_Locator, initialCount));
                 if (getActivityname == activityName)                
                {
                    IWebElement getActivityProperty = base.GetWebElementPropertiesByXPath(
                        string.Format(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Assets_Name_Xpath_Locator, initialCount));
                    base.PerformMouseHoverByJavaScriptExecutor(getActivityProperty);
                    //Get Cmenu Property
                    IWebElement getCmenuProperty = base.
                        GetWebElementPropertiesByXPath(string.Format(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Activitycmenu_Xpath_Locator,initialCount));
                     //Click On Cmenu Option
                    base.ClickByJavaScriptExecutor(getCmenuProperty);
                    break;
                }               
            }
             Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickOnActivityCmenu",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Get Information Option
        /// </summary>
        private void ClickOnGetInformationOption()
        {
            //Click On Get Information Option
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "ClickOnGetInformationOption",
                    base.IsTakeScreenShotDuringEntryExit);
            //Get Information Property
            IWebElement getGetInformationProperty = base.
                GetWebElementPropertiesByXPath(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_GetInformation_Xpath_Locator);
            //Click On GetInformation Link
            base.ClickByJavaScriptExecutor(getGetInformationProperty);
            Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickOnGetInformationOption",
                   base.IsTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Get Display Of Activity Name In View All Content.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Name.</returns>
        public String GetDisplayOfActivityNameInViewAllContent(string activityName)
        {
            //Get Display Of Activity Name In View All Content
            Logger.LogMethodEntry("CoursePreviewMainUXPage",
                "GetDisplayOfActivityNameInViewAllContent",
                    base.IsTakeScreenShotDuringEntryExit);
            //Declaration of object
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //Initialize getActivityText variable
            string getActivityName = string.Empty;
            try
            {
                new CourseHomeListItemViewPage().SelectCourseHomeWindow();
                //Switch To Frame
                base.SwitchToIFrame(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_CoursePreview_IFrame_Id_Locator);
                //passing the parameter of activty and xpath value to get the activity name
                getActivityName = contentLibraryUXPage.GetTheDisplayOfActivityName(activityName, 
                    CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_ViewAllContent_TableText_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", 
                "GetDisplayOfActivityNameInViewAllContent",
                   base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }
      
        /// <summary>
        /// Launch The Activity by activity name.
        /// </summary>
        /// <param name="activityName">Name of the activity</param>
        public void OpenActivity(string activityName)
        {
            // Launch The Activity
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "OpenActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                this.SelectCourseMaterialsWindow();
                //Wait For The Activity Name
                base.WaitForElement(By.PartialLinkText(activityName));
                //Get Activity Property
                IWebElement getActivityProperty = base.GetWebElementPropertiesByPartialLinkText
                    (activityName);
                base.ClickByJavaScriptExecutor(getActivityProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "OpenActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Searching for the activity, open the c menu for that activity and click on the given c menu option
        /// </summary>
        /// <param name="activityCmenuEnum"></param>
        /// <param name="activityName"></param>
        public void SelectActivityCmenuForInstructor(ActivityCmenuEnum activityCmenuEnum, String activityName)
        {
            //Select Activity 
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "SelectActivityCmenuOptionIns",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Course Materials Window
                this.SelectCourseMaterialsWindow();
                //Click On Activity Cmenu
                this.ClickOnAssetCmenuForInstructor(activityName);
                switch (activityCmenuEnum)
                {
                    case CoursePreviewMainUXPage.ActivityCmenuEnum.SetSchedulingOptions:
                        //Click On Scheduling Option
                        this.ClickOnSetSchedulingOption();
                        break;
                    //Click On View Submissions Option
                    case CoursePreviewMainUXPage.ActivityCmenuEnum.ViewSubmissions:
                        this.ClickOnViewSubmissions();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "SelectActivityCmenuOptionIns",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Set Scheduling Option
        /// </summary>
        private void ClickOnSetSchedulingOption()
        {
            //Click On Get Information Option
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "ClickOnGetInformationOption",
                    base.IsTakeScreenShotDuringEntryExit);
            //Get Information Property
            IWebElement getGetInformationProperty = base.
                GetWebElementPropertiesByXPath(CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_SetSchedulingOptions_Xpath_Locator);
            //Click On GetInformation Link
            base.ClickByJavaScriptExecutor(getGetInformationProperty);
            Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickOnGetInformationOption",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On View Submissions.
        /// </summary>
        private void ClickOnViewSubmissions()
        {
            //Click On Get Information Option
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "ClickOnGetInformationOption",
                    base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath (CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_ViewSubmissions_Xpath_Locator));
            //Get Information Property
            IWebElement GetInformationProperty = base.GetWebElementPropertiesByXPath
                (CoursePreviewMainUXPageResource.
                CoursePreviewMainUX_Page_ViewSubmissions_Xpath_Locator);
            //Click On GetInformation Link
            Thread.Sleep(Convert.ToInt32(CoursePreviewMainUXPageResource.
                   CoursePreviewMainUX_Page_ElementWait_Value));
            base.ClickByJavaScriptExecutor(GetInformationProperty);
            Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickOnGetInformationOption",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Searching for the activity and opening the cmenu for instructor view
        /// </summary>
        /// <param name="activityName"></param>
        private void ClickOnAssetCmenuForInstructor(String activityName)
        {
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "ClickOnActivityCmenuIns",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            int getActivityCount;
            //Initialize Variable
            string getActivityname = string.Empty;
            //Get Activity Count
            getActivityCount = base.GetElementCountByXPath(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Assets_Count_Xpath_Locator);
            for (int initialCount = Convert.ToInt32(CoursePreviewMainUXPageResource.
                   CoursePreviewMainUX_Page_Asset_Loop_Initialization_InstValue);
                   initialCount <= getActivityCount; initialCount++)
            {
                //Get Activity Name
                getActivityname = base.GetElementTextByXPath
                        (string.Format(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Assets_Name_Xpath_Locator_Ins, initialCount));
                if (getActivityname == activityName)
                {
                    IWebElement getActivityProperty = base.GetWebElementPropertiesByXPath(
                        string.Format(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Assets_Name_Xpath_Locator_Ins, initialCount));
                    Thread.Sleep(Convert.ToInt32(CoursePreviewMainUXPageResource.
                   CoursePreviewMainUX_Page_ElementWait_Value));
                    base.PerformMouseHoverByJavaScriptExecutor(getActivityProperty);
                    //Get Cmenu Property
                    IWebElement getCmenuProperty = base.
                        GetWebElementPropertiesByXPath(string.Format(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Activitycmenu_Xpath_Locator_Ins, initialCount));
                    Thread.Sleep(Convert.ToInt32(CoursePreviewMainUXPageResource.
                   CoursePreviewMainUX_Page_ElementWait_Value));
                    //Click On Cmenu Option
                    base.ClickByJavaScriptExecutor(getCmenuProperty);
                    break;
                }
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickOnActivityCmenuIns",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checking the assigned status by assign icon and due date existance
        /// </summary>
        /// <param name="activityName"></param>
        /// <returns></returns>
        public Boolean IsAssetAssigned(String activityName)
        {
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "CheckAssignedStatus",
                base.IsTakeScreenShotDuringEntryExit);
            string getAssignedDueDate = string.Empty;
            Boolean isAssigned = false;
            bool isDueDateExists = false;
            DateTime dueDate;
            try
            {
                this.SelectCourseMaterialsWindow();
                //Initialize Variable
                int getActivityCount;
                //Initialize Variable
                string getActivityname = string.Empty;
                //Get Activity Count
                getActivityCount = base.GetElementCountByXPath(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Assets_Count_Xpath_Locator);
                for (int initialCount = Convert.ToInt32(CoursePreviewMainUXPageResource.
                       CoursePreviewMainUX_Page_Asset_Loop_Initialization_InstValue);
                       initialCount <= getActivityCount; initialCount++)
                {
                    //Get Activity Name
                    getActivityname = base.GetElementTextByXPath
                            (string.Format(CoursePreviewMainUXPageResource.
                            CoursePreviewMainUX_Page_Assets_Name_Xpath_Locator_Ins, initialCount));
                    if (getActivityname == activityName)
                    {
                        //Check assigned icon
                        isAssigned = base.IsElementPresent(By.XPath(string.Format(CoursePreviewMainUXPageResource.
                             CoursePreviewMainUX_Page_AssignedIcon_Xpath_Locator_Ins, initialCount)));

                        getAssignedDueDate = base.GetTitleAttributeValueByXPath(string.Format(CoursePreviewMainUXPageResource.
                              CoursePreviewMainUX_Page_AssignedIcon_Xpath_Locator_Ins, initialCount));

                        isDueDateExists = DateTime.TryParse(getAssignedDueDate.Trim(), out dueDate);
                        break;

                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "CheckAssignedStatus",
            base.IsTakeScreenShotDuringEntryExit);
            return isAssigned & isDueDateExists;
        }

        /// <summary>
        /// Checking if asset is scheduled with start and end date
        /// </summary>
        /// <param name="activityName"></param>
        /// <returns></returns>
        public Boolean IsAssetScheduled(String activityName)
        {
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "CheckAssignedStatus",
                base.IsTakeScreenShotDuringEntryExit);
            DateTime startDate;
            DateTime endDate;
            bool isStartDateExists = false;
            bool isEndDateExists = false;
            Boolean isScheduled = false;
            try
            {
                this.SelectCourseMaterialsWindow();

                //Initialize Variable
                int getActivityCount;
                //Initialize Variable
                string getActivityname = string.Empty;
                //Get Activity Count
                getActivityCount = base.GetElementCountByXPath(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Assets_Count_Xpath_Locator);
                for (int initialCount = Convert.ToInt32(CoursePreviewMainUXPageResource.
                       CoursePreviewMainUX_Page_Asset_Loop_Initialization_InstValue);
                       initialCount <= getActivityCount; initialCount++)
                {
                    //Get Activity Name
                    getActivityname = base.GetElementTextByXPath
                            (string.Format(CoursePreviewMainUXPageResource.
                            CoursePreviewMainUX_Page_Assets_Name_Xpath_Locator_Ins, initialCount));
                    if (getActivityname == activityName)
                    {
                        //Check for scheduled icon
                        isScheduled = base.IsElementPresent(By.XPath(string.Format(CoursePreviewMainUXPageResource.
                             CoursePreviewMainUX_Page_ScheduledIcon_Xpath_Locator_Ins, initialCount)));

                        IWebElement getAssignedDiv = base.GetWebElementPropertiesByXPath(string.Format(CoursePreviewMainUXPageResource.
                              CoursePreviewMainUX_Page_ScheduleInfo_Xpath_Locator_Ins, initialCount));

                        var elements = Regex.Matches(getAssignedDiv.Text, @"(?:\S+\s)?\S*-\S*(?:\s\S+)?", RegexOptions.IgnoreCase);
                        char[] delimiterChars = { '-' };
                        string[] startAndEnddate = elements[0].ToString().Split(delimiterChars);
                        isStartDateExists = DateTime.TryParse(startAndEnddate[0].Trim(), out startDate);
                        isEndDateExists = DateTime.TryParse(startAndEnddate[1].Trim(), out endDate);
                        break;

                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "CheckAssignedStatus",
            base.IsTakeScreenShotDuringEntryExit);

            return isScheduled & isStartDateExists & isEndDateExists;
        }

        /// <summary>
        /// Open the activity.
        /// </summary>
        /// <param name="ActivityName">This is the activity.</param>
        public void OpenTheActivityFromMyCourse(string ActivityName)
        {
            // Launch The Activity
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "OpenTheActivityFromMyCourse",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Window_Title_Name_HED);
                base.SelectWindow(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Window_Title_Name_HED);
                base.WaitForElement(By.Id(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Iframe_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrameById(CoursePreviewMainUXPageResource.
                    CoursePreviewMainUX_Page_Iframe_Id_Locator);
                //Wait For The Activity Name
                base.WaitForElement(By.PartialLinkText(ActivityName));
                //Get Activity Property
                IWebElement getActivityProperty = base.GetWebElementPropertiesByPartialLinkText
                    (ActivityName);
                base.ClickByJavaScriptExecutor(getActivityProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "OpenTheActivityFromMyCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }       
    }
}
