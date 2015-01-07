using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Configuration;
using System.Diagnostics;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains the details of the My Course frame 
    /// in the Add Content from Library in the Content tab.
    /// </summary>
    public class CourseContentUXPage : BasePage
    {
        /// <summary>
        /// This is the static instance of logger
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CourseContentUXPage));

        /// <summary>
        /// Specifiyies different button types available on My Course header.
        /// </summary>
        public enum MyCourseButtonType
        {
            AssignUnassign = 1,
            ShowHide = 2,
            Remove = 3,
            Copy = 4,
            Cut = 5,
            Paste = 6
        }


        /// <summary>
        /// This is the Broswer variable called from AppSettings.
        /// </summary>
        private int waitTimeOut = Convert.ToInt32(
            ConfigurationManager.AppSettings["ElementFindTimeOutInSeconds"]);

        /// <summary>
        /// Gets the Activity Name from the MyCourse Frame.
        /// </summary>
        /// <param name="activityName">Activity Name.</param>
        /// <returns>Searched Activity Name.</returns>
        public String GetActivityName(String activityName)
        {
            //Gets the Activity Name
            Logger.LogMethodEntry("CourseContentUXPage", "GetActivityName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Activity Name Variable
            string getActivityName = string.Empty;
            try
            {
                //Declaration of object
                ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
                base.SwitchToDefaultWindow();
                //Select the frame
                contentLibraryUXPage.SelectAndSwitchtoFrame(CourseContentUXPageResource.
                CourseContentUXPage_Frame_Right_Id_Locator);
                //Get the Searched Activity Name
                getActivityName = GetSearchedActivityInMyCourseFrame(activityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "GetActivityName",
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Get the Searched Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Searched Activity Name.</returns> 
        private String GetSearchedActivityInMyCourseFrame(String activityName)
        {
            //Gets the Searched Activity
            Logger.LogMethodEntry("CourseContentUXPage", "GetSearchedActivityInMyCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Gets the First Activity from My Course Frame
            string getSearchedActivityName = string.Empty;
            //Get Count of Activity
            int getActivityCount = this.GetActivityCountAfterSearch(activityName);
            for (int rowCountAfterSearch = Convert.ToInt32(CourseContentUXPageResource.
                CourseContentUXPage_Activity_Counter); rowCountAfterSearch <= getActivityCount;
                rowCountAfterSearch++)
            {
                base.WaitForElement(By.XPath(string.Format(CourseContentUXPageResource.
                    CourseContentUXPage_Searched_ActivityName_ID_Locator,
                    rowCountAfterSearch)));
                //Gets the Activity Name
                getSearchedActivityName = base.GetElementTextByXPath
                    (string.Format(CourseContentUXPageResource.
                    CourseContentUXPage_Searched_ActivityName_ID_Locator,
                    rowCountAfterSearch)).Trim();
                //Verify Same Activity by Name is present on page
                if (getSearchedActivityName.Contains(activityName))
                {
                    getSearchedActivityName = activityName;
                    break;
                }
                else
                {
                    getSearchedActivityName = string.Empty;
                }
            }
            Logger.LogMethodExit("CourseContentUXPage", "GetSearchedActivityInMyCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
            return getSearchedActivityName;
        }

        /// <summary>
        /// Get the Activity Count Afetr Search.
        /// </summary>
        /// <returns>Count of Activity Name After Search.</returns>
        private int GetActivityCountAfterSearch(String activityName)
        {
            //Get the Activity Count 
            Logger.LogMethodEntry("CourseContentUXPage", "GetActivityCountAfterSearch",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CourseContentUXPageResource.
               CourseContentUXPage_Button_Search_ID_Locator));
            //Get property of serch button
            IWebElement getPropertyOfSearchButton = base.
                GetWebElementPropertiesById(CourseContentUXPageResource.
               CourseContentUXPage_Button_Search_ID_Locator);
            base.ClickByJavaScriptExecutor(getPropertyOfSearchButton);
            //Wait for Search field
            base.WaitForElement(By.ClassName(CourseContentUXPageResource.
                CourseContentUXPage_Search_Textbox_ID_Locator));
            //Enter the Text in the Text Field
            base.FillTextBoxByClassName(CourseContentUXPageResource.
                CourseContentUXPage_Search_Textbox_ID_Locator, activityName);
            IWebElement getGoButton = base.GetWebElementPropertiesByPartialLinkText
                (CourseContentUXPageResource.
                CouorseContentUXPage_Go_Button_PartialLinkText_Locator);
            //Click on 'GO' button
            base.ClickByJavaScriptExecutor(getGoButton);
            //Check the Thinking Indicator appearence
            int getActivityCount = 0;
            if (!base.IsThinkingIndicatorLoading())
            {
                //Course Content table search
                base.WaitForElement(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_Searched_Table_ID_Locator));
                //Get the Count of Activity Afetr Search
                getActivityCount = base.GetElementCountByXPath(CourseContentUXPageResource.
                   CourseContentUXPage_SearchedActivityCount_XPath_Locator);
            }
            Logger.LogMethodExit("CourseContentUXPage", "GetActivityCountAfterSearch",
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityCount;
        }

        /// <summary>
        ///Perform Mouse Over on the Cmenu option to Preview the Activity.
        /// </summary>
        /// <param name="cMenuOptionName">This is cmenu option name.</param>
        /// <param name="userTypeEnum">This is User type</param>
        public void PerformMouseOverOnCMenuOptionOfActivity(
            string cMenuOptionName, User.UserTypeEnum userTypeEnum)
        {
            //Perform Mouse Over on CMenu option of Activity
            Logger.LogMethodEntry("CourseContentUXPage", "PerformMouseOverOnCMenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userTypeEnum)
                {      //Course content
                    case User.UserTypeEnum.WsTeacher:
                    case User.UserTypeEnum.HedWsInstructor:
                    case User.UserTypeEnum.CsAdmin:
                        if (!base.IsThinkingIndicatorLoading(2))
                        {
                            //Wait for element 
                            base.WaitForElement(By.XPath(CourseContentUXPageResource.
                                CourseContentUX_Page_MyCourseActivity_Hover_XPath_Locator));
                            IWebElement getCourseContentTitleHover = base.
                                GetWebElementPropertiesByXPath(CourseContentUXPageResource.
                                CourseContentUX_Page_MyCourseActivity_Hover_XPath_Locator);
                            //Mouse Hover on Activity
                            base.PerformMouseHoverByJavaScriptExecutor(getCourseContentTitleHover);
                        }
                        break;
                    //Conent library
                    case User.UserTypeEnum.CsSmsInstructor:
                        if (!base.IsThinkingIndicatorLoading(2))
                        {
                            base.WaitForElement(By.XPath(CourseContentUXPageResource.
                                CourseContentUXPage_Activity_Icon_Xpath_Locator));
                            //Get Element Property To Mouse Hover on the activity name
                            IWebElement getContentLibraryTitleHover = base.GetWebElementPropertiesByXPath
                            (CourseContentUXPageResource.CourseContentUXPage_Activity_Icon_Xpath_Locator);
                            //Mouse Hover on Activity
                            base.PerformMouseHoverByJavaScriptExecutor(getContentLibraryTitleHover);
                        }
                        break;
                }
                //Click On Cmenu Options In ContentLibrary
                this.ClickOnCmenuOptionsInContentLibrary(cMenuOptionName, userTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "PerformMouseOverOnCMenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Options In ContentLibrary
        /// </summary>
        /// <param name="userTypeEnum">This is User type</param>
        /// <param name="cMenuOptionName">This is Cmenu options</param>
        private void ClickOnCmenuOptionsInContentLibrary(
            string cMenuOptionName, User.UserTypeEnum userTypeEnum)
        {
            //Click on Master Library Checkbox
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnCmenuOptionsInContentLibrary",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the drop down option when it is visble
            base.WaitForElement(By.ClassName(CourseContentUXPageResource.
                CourseContentUX_Page_Activity_Cmenu_Class_Locator));
            //Get property of drop down option when it is visble
            IWebElement getCmenuOption = base.GetWebElementPropertiesByClassName
                (CourseContentUXPageResource.
                CourseContentUX_Page_Activity_Cmenu_Class_Locator);
            //Click on cmenu icon
            base.ClickByJavaScriptExecutor(getCmenuOption);
            //get property of cmmenu option name element 
            IWebElement getCmenuOptionName = base.
                GetWebElementPropertiesByPartialLinkText(cMenuOptionName);
            //Click on Cmenu option element 
            base.ClickByJavaScriptExecutor(getCmenuOptionName);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.CsSmsInstructor:
                    base.SwitchToLastOpenedWindow();
                    break;

                case User.UserTypeEnum.HedWsInstructor:
                    base.SwitchToLastOpenedWindow();
                    break;
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnCmenuOptionsInContentLibrary",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Master Library Checkbox.
        /// </summary>
        public void ClickOnMasterLibraryCheckBox()
        {
            //Click on Master Library Checkbox
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnMasterLibraryCheckBox",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_Content_Window_Name,
                    CourseContentUXPageResource.CourseContentUXPage_FrameLeft_Id_Locator);
                //Wait For Element
                base.WaitForElement(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_SelectAll_CheckBox_Id_Locator));
                //Click To Check The CheckBox
                base.SelectCheckBoxById(CourseContentUXPageResource.
                    CourseContentUXPage_SelectAll_CheckBox_Id_Locator);
                //Switch To Default Page
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnMasterLibraryCheckBox",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Button.
        /// </summary>
        public void ClickOnAddButton()
        {
            //Click On Add Button
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnAddButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Content Window
                base.SelectWindow(CourseContentUXPageResource.
                            CourseContentUXPage_Content_Window_Name);
                base.WaitForElement(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_AddButton_Id_Locator));
                //Click On Add Button
                base.ClickButtonById(CourseContentUXPageResource.
                    CourseContentUXPage_AddButton_Id_Locator);
                //Is Alert Pop Up Window Present
                if (base.IsPopupPresent(CourseContentUXPageResource.
                    CourseContentUXPage_Pegasus_Window_Name, Convert.ToInt32(
                    CourseContentUXPageResource.
                    CourseContentUX_Page_Customized_TimeOut)))
                {
                    HandlePegasusAlertWindow();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnAddButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Handle Alert Window.
        /// </summary>
        private void HandlePegasusAlertWindow()
        {
            Logger.LogMethodEntry("CourseContentUXPage", "HandlePegasusAlertWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Alert Window
            base.SelectWindow(CourseContentUXPageResource.CourseContentUXPage_Pegasus_Window_Name);
            //Wait for the element
            base.WaitForElement(By.Id(CourseContentUXPageResource.
                CourseContentUXPage_Pegasus_Checkbox_Id_Locator));
            base.FocusOnElementById(CourseContentUXPageResource.
                CourseContentUXPage_Pegasus_Checkbox_Id_Locator);
            //Click the checkbox
            base.SelectCheckBoxById(CourseContentUXPageResource.
                CourseContentUXPage_Pegasus_Checkbox_Id_Locator);
            //Wait for the element
            base.WaitForElement(By.Id(CourseContentUXPageResource.
                CourseContentUXPage_Ok_Button_Id_Locator));
            base.FocusOnElementById(CourseContentUXPageResource.
                CourseContentUXPage_Ok_Button_Id_Locator);
            //Get web element
            IWebElement getOkBtnProperty = base.GetWebElementPropertiesById
                (CourseContentUXPageResource.CourseContentUXPage_Ok_Button_Id_Locator);
            //Click the Ok button
            base.ClickByJavaScriptExecutor(getOkBtnProperty);
            Logger.LogMethodExit("CourseContentUXPage", "HandlePegasusAlertWindow",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Wait for Master Library to Copy.
        /// </summary>
        public void WaitMasterLibraryToGetInPrepareState()
        {
            //Wait for Master Library to Copy
            Logger.LogMethodEntry("CourseContentUXPage", "WaitMasterLibraryToGetInPrepareState",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
                while (stopWatch.Elapsed.TotalMinutes < minutesToWait)
                {
                    Thread.Sleep(Convert.ToInt32(CourseContentUXPageResource.
                        CourseContentUXPage_ThreadSleep_Time_Value));

                    //Select Right Frame
                    this.SelectFrameInWindow(CourseContentUXPageResource.
                        CourseContentUXPage_Content_Window_Name,
                        CourseContentUXPageResource.
                    CourseContentUXPage_FrameRight_Id_Locator);
                    base.WaitForElement(By.CssSelector(CourseContentUXPageResource.
                        CourseContentUXPage_MasterLibrary_Copy_CssSelector_Locator));
                    //Get Master Library Copy Text
                    string getMessage = base.GetElementTextByCssSelector(CourseContentUXPageResource.
                                                                             CourseContentUXPage_MasterLibrary_Copy_CssSelector_Locator);
                    if (getMessage.Contains(CourseContentUXPageResource.
                        CourseContentUXPage_CourseCopy_Message) == false) break;
                    {
                        base.SwitchToDefaultPageContent();
                        //Refresh the Current Frame
                        base.RefreshIFrameByJavaScriptExecutor(CourseContentUXPageResource.
                        CourseContentUXPage_FrameRight_Id_Locator);
                    }
                }
                Thread.Sleep(Convert.ToInt32(CourseContentUXPageResource.
                   CourseContentUX_Page_Customized_TimeOut));
                //Set the Course As Shown state
                this.SetTheCourseAsShownState();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "WaitMasterLibraryToGetInPrepareState",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Shown state
        /// </summary>
        private void SetTheCourseAsShownState()
        {
            //Set the Course As Shown state
            Logger.LogMethodEntry("CourseContentUXPage", "SetTheCourseAsShownState",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the course name element
            base.WaitForElement(By.XPath(CourseContentUXPageResource.
                CourseContentUXPage_ContentTab_CourseName_Xpath_Locator));
            IWebElement getMouseoverProperty = base.GetWebElementPropertiesByXPath
                (CourseContentUXPageResource.
                CourseContentUXPage_ContentTab_CourseName_Xpath_Locator);
            //Mouseover action on course name
            base.PerformMouseHoverByJavaScriptExecutor(getMouseoverProperty);
            //Wait for the img button
            base.WaitForElement(By.ClassName(CourseContentUXPageResource.
                CourseContentUXPage_ContentTab_CourseTraingle_Img_Class_Locator));
            IWebElement getTrainglebtnProperty = base.GetWebElementPropertiesByClassName
                (CourseContentUXPageResource.
                CourseContentUXPage_ContentTab_CourseTraingle_Img_Class_Locator);
            //Click the img button
            base.ClickByJavaScriptExecutor(getTrainglebtnProperty);
            //Wait for the cmenu 
            base.WaitForElement(By.Id(CourseContentUXPageResource.
                CourseContentUXPage_ContentTab_CourseMenu_Xpath_Locator));
            //Wait for the Show/Hide cmenu
            base.WaitForElement(By.XPath(CourseContentUXPageResource.
                CourseContentUXPage_ContentTab_CourseMenu_Show_Xpath_Locator));
            IWebElement getShowProperty = base.GetWebElementPropertiesByXPath
                (CourseContentUXPageResource.
                CourseContentUXPage_ContentTab_CourseMenu_Show_Xpath_Locator);
            //Click the Show/Hide Cmenu option
            base.ClickByJavaScriptExecutor(getShowProperty);
            Logger.LogMethodExit("CourseContentUXPage", "SetTheCourseAsShownState",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Activity For 'Copy Content'
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        public void SelectTheActivityForCopyContent(string activityName)
        {
            //Select The Activity For 'CopyContent'
            Logger.LogMethodEntry("CourseContentUXPage", "SelectTheActivityForCopyContent",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Frame In Window
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title, CourseContentUXPageResource.
                    CourseContentUXPage_FrameLeft_Id_Locator);
                //Click on the Folder 'Capítulo Preliminar 0A: Para empezar'
                this.ClickOnTheFolderInContentLibrary(CourseContentUXPageResource.
                    CourseContentUXPage_RootFolder_Name_Value);
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title, CourseContentUXPageResource.
                    CourseContentUXPage_FrameLeft_Id_Locator);
                //Click on the Folder 'ADDITIONAL PRACTICE'
                this.ClickOnTheFolderInContentLibrary(CourseContentUXPageResource.
                    CourseContentUXPage_SubFolder_Name_Value);
                //Select Frame In Window
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title, CourseContentUXPageResource.
                    CourseContentUXPage_FrameLeft_Id_Locator);
                //Select the CheckBox
                this.ClickOnTheAssetCheckBox(activityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "SelectTheActivityForCopyContent",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Asset CheckBox
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        private void ClickOnTheAssetCheckBox(string assetName)
        {
            //Click On The Asset CheckBox
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnTheAssetCheckBox",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the total count of Activity
            base.WaitForElement(By.XPath(CourseContentUXPageResource.
                CourseContentUXPage_SearchedActivityCount_XPath_Locator));
            int getActivityCount = base.GetElementCountByXPath(CourseContentUXPageResource.
                CourseContentUXPage_SearchedActivityCount_XPath_Locator);
            for (int rowCount = Convert.ToInt32(CourseContentUXPageResource.
                CourseContentUXPage_Loop_Initializer_Value);
                rowCount <= getActivityCount; rowCount++)
            {
                //Get the Activity name
                string getActivityName = base.GetElementTextByXPath(
                    String.Format(CourseContentUXPageResource.
                    CourseContentUXPage_ActivityName_By_ClassName_Xpath_Locator, rowCount));
                if (getActivityName == assetName)
                {
                    //Wait for the Element
                    base.WaitForElement(By.XPath(String.Format(CourseContentUXPageResource.
                        CourseContentUXPage_CheckBox_By_Id_Xpath_Locator, rowCount)));
                    base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(String.
                        Format(CourseContentUXPageResource.
                        CourseContentUXPage_CheckBox_By_Id_Xpath_Locator, rowCount)));
                    break;
                }
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnTheAssetCheckBox",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Frame In Window.
        /// </summary>
        /// <param name="windowName">This is Window Name.</param>
        /// <param name="frame">Thei is Frame Name.</param>
        public void SelectFrameInWindow(string windowName, string frame)
        {
            //Select Frame In Window
            Logger.LogMethodEntry("CourseContentUXPage", "SelectFrameInWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Window
                base.WaitUntilWindowLoads(windowName);
                base.SelectWindow(windowName);
                //Wait for the Frame
                base.WaitForElement(By.Id(frame));
                base.SwitchToIFrame(frame);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "SelectFrameInWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Gradebook Window In Course Home.
        /// </summary>
        public void SelectGradebookWindowInCourseHome()
        {
            //Select Gradebook Window In Course Home
            Logger.LogMethodEntry("CourseContentUXPage", "SelectGradebookWindowInCourseHome",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                new CourseHomeListItemViewPage().SelectCourseHomeWindow();
                //Select Frame
                base.WaitForElement(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_Gradebook_Frame_Id_Locator));
                base.SwitchToIFrame(CourseContentUXPageResource.
                    CourseContentUXPage_Gradebook_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "SelectGradebookWindowInCourseHome",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Folder In Content Library in Source Course.
        /// </summary>
        /// <param name="folderName">This is Folder Name.</param>
        private void ClickOnTheFolderInContentLibrary(string folderName)
        {
            //Click On The Folder In Content Library
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnTheFolderInContentLibrary",
                base.IsTakeScreenShotDuringEntryExit);
            //Select the Frame
            this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title, CourseContentUXPageResource.
                    CourseContentUXPage_FrameLeft_Id_Locator);
            //Get the text in Table
            base.WaitForElement(By.Id(CourseContentUXPageResource.
                CourseContentUXPage_Searched_Table_ID_Locator));
            string getTableText = base.GetElementTextById(CourseContentUXPageResource.
                CourseContentUXPage_Searched_Table_ID_Locator);
            if (getTableText.Contains(folderName))
            {
                //Focus on the Folder
                base.FocusOnElementByXPath(String.Format(CourseContentUXPageResource.
                    CourseContentUXPage_ActivityTitle_By_Title_Attribute_Xpath_Locator,
                    folderName));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                    String.Format(CourseContentUXPageResource.
                    CourseContentUXPage_ActivityTitle_By_Title_Attribute_Xpath_Locator,
                    folderName)));
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnTheFolderInContentLibrary",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Asset Name From Course Content
        /// </summary>
        /// <param name="activityName">This is Asset Name</param>
        /// <returns>Activity Name</returns>
        public string GetAssetNameFromCourseContent(string activityName)
        {
            //Display of Activity in the My Course Frame
            Logger.LogMethodEntry("CourseContentUXPage", "GetAssetNameFromCourseContent",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getCopiedAssetName = string.Empty;
            try
            {
                //Select the Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                        CourseContentUXPage_CourseMaterials_Window_Title, CourseContentUXPageResource.
                        CourseContentUXPage_FrameLeft_Id_Locator);
                //Get the total count of Activity
                int getActivityCount = base.GetElementCountByXPath(CourseContentUXPageResource.
                    CourseContentUXPage_SearchedActivityCount_XPath_Locator);
                for (int rowCount = Convert.ToInt32(CourseContentUXPageResource.
                        CourseContentUXPage_Loop_Initializer_Value);
                        rowCount <= getActivityCount; rowCount++)
                {
                    //Get activity Name
                    string getActivityName = base.GetElementTextByXPath(String.Format(
                        CourseContentUXPageResource.CourseContentUXPage_ActivityTitle_Xpath_Locator,
                        rowCount));
                    if (getActivityName.Contains(activityName))
                    {
                        getCopiedAssetName = activityName;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "GetAssetNameFromCourseContent",
                base.IsTakeScreenShotDuringEntryExit);
            return getCopiedAssetName;
        }

        /// <summary>
        /// Click On Add Course Materials Option
        /// </summary>
        public void ClickOnAddCourseMaterialsOption()
        {
            //Click On Add Course Materails Option
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnAddCourseMaterialsOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.CourseContentUXPage_FrameRight_Id_Locator);
                base.WaitForElement(By.ClassName(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_AddContent_Button_Id_Locator));
                //Get Add Course Materials Button Property
                IWebElement getButtonProperty = base.GetWebElementPropertiesByClassName(
                    ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_AddContent_Button_Id_Locator);
                //Click On Add Course Materails Button
                base.ClickByJavaScriptExecutor(getButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnAddCourseMaterialsOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close eText Presentation Window
        /// </summary>
        /// <param name="windowName">This is Window Name</param>
        public void CloseETextPresentationWindow(string windowName)
        {
            //Close eText Presentation Window
            Logger.LogMethodEntry("CourseContentUXPage",
                "CloseETextPresentationWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.SelectWindow(windowName);
                //Close the window
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage",
                "CloseETextPresentationWindow",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The ShowHide Status Option.
        /// </summary>
        public void ClickTheShowHideStatusOption()
        {
            // Click The ShowHide Status Option
            Logger.LogMethodEntry("CourseContentUXPage", "ClickTheShowHideStatusOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.CourseContentUXPage_FrameRight_Id_Locator);
                //Wait for the asset checkbox elemnet           
                base.WaitForElement(By.XPath(CourseContentUXPageResource.
                    CourseContentUXPage_AssetCheckbox_Xpath_Locator));
                IWebElement getSelectCheckbox = base.GetWebElementPropertiesByXPath
                    (CourseContentUXPageResource.CourseContentUXPage_AssetCheckbox_Xpath_Locator);
                //Click the checkbox
                base.ClickByJavaScriptExecutor(getSelectCheckbox);
                //Wait for the showhide link
                base.WaitForElement(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_ShowHide_Link_ID_Locator));
                IWebElement getShowHideProperty = base.GetWebElementPropertiesById
                    (CourseContentUXPageResource.
                    CourseContentUXPage_ShowHide_Link_ID_Locator);
                //Click on showhide link
                base.ClickByJavaScriptExecutor(getShowHideProperty);
                Thread.Sleep(Convert.ToInt32(CourseContentUXPageResource.
                    CourseContentUXPage_ShowHide_Status_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickTheShowHideStatusOption",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu of Activity
        /// </summary>
        /// <param name="cmenuOption">This is cmenu 'Open' option</param>
        public void ClickOnCmenuofActivity(string cmenuOption)
        {
            // Click On Cmenu of Activity
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnCmenuofActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.CourseContentUXPage_FrameRight_Id_Locator);
                //Wait for the element
                base.WaitForElement(By.XPath(CourseContentUXPageResource.
                    CourseContentUXPage_eTextAssetName_Xpath_Locator));
                IWebElement getMouseoverAsset = base.GetWebElementPropertiesByXPath
                    (CourseContentUXPageResource.
                    CourseContentUXPage_eTextAssetName_Xpath_Locator);
                //Perform mouseover on asset
                base.PerformMouseHoverAction(getMouseoverAsset);
                //Wait for the element
                base.WaitForElement(By.ClassName(CourseContentUXPageResource.
                    CourseContentUXPage_eTextAssetName_ClassName));
                IWebElement getImgOption = base.GetWebElementPropertiesByClassName
                    (CourseContentUXPageResource.CourseContentUXPage_eTextAssetName_ClassName);
                //Click the img option
                base.ClickByJavaScriptExecutor(getImgOption);
                //Click the cmenu option
                base.ClickLinkByPartialLinkText(cmenuOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnCmenuofActivity",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Gets the Activity Name from the MyCourse Frame.
        /// </summary>
        /// <param name="activityTypeEnum">Activity Name.</param>
        /// <returns>Searched Activity Name.</returns>
        public String GetETextActivityName(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Gets the Activity Name
            Logger.LogMethodEntry("CourseContentUXPage", "GetETextActivityName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Activity Name Variable
            String getActivityName = null;
            Activity getActivity = Activity.Get(activityTypeEnum);
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.
                    CourseContentUXPage_FrameRight_Id_Locator);
                //Get the Searched Activity Name
                getActivityName = GetSearchedActivityInMyCourseFrame(
                    getActivity.Name.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "GetETextActivityName",
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Click on MasterLibrary
        /// </summary>
        public void ClickonMasterLibrary()
        {
            // Click on MasterLibrary
            Logger.LogMethodEntry("CourseContentUXPage", "ClickonMasterLibrary",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_Content_Window_Name,
                    CourseContentUXPageResource.
                CourseContentUXPage_FrameLeft_Id_Locator);
                //Wait for the Element
                base.WaitForElement(By.ClassName(CourseContentUXPageResource.
                    CourseContentUXPage_Masterlibrary_Classname_Locator));
                IWebElement getMasterLibrary = base.GetWebElementPropertiesByClassName
                    (CourseContentUXPageResource.CourseContentUXPage_Masterlibrary_Classname_Locator);
                //Click on Masterlibrary
                base.ClickByJavaScriptExecutor(getMasterLibrary);
                Thread.Sleep(Convert.ToInt32(CourseContentUXPageResource.
                    CourseContentUXPage_ThreadSleep_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickonMasterLibrary",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        public void SelectActivity(string activityName)
        {
            //Select Activity
            Logger.LogMethodEntry("CourseContentUXPage", "SelectActivity",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getActivityname = string.Empty;
            try
            {
                //Select window
                base.SelectWindow(ContentLibraryUXPageResource.
                        ContentLibraryUXPage_ContentWindow_Name);
                base.SwitchToIFrame(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_Left_Frame_ID_Locator);
                //Get ActivityCount
                int getActivitycount = base.GetElementCountByXPath(CourseContentUXPageResource.
                    CourseContentUXPage_SearchedActivityCount_XPath_Locator);
                for (int rowCount = Convert.ToInt32(CourseContentUXPageResource.
                    CourseContentUXPage_Loop_Initializer_Value); rowCount <= getActivitycount; rowCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(CourseContentUXPageResource.
                        CourseContentUXPage_ActivityName_Xpath_Locator, rowCount)));
                    //Get Activity Name
                    getActivityname = base.GetElementTextByXPath(string.Format(CourseContentUXPageResource.
                        CourseContentUXPage_ActivityName_Xpath_Locator, rowCount));
                    if (getActivityname == activityName)
                    {
                        base.WaitForElement(By.XPath(string.Format(CourseContentUXPageResource.
                            CourseContentUXPage_ActivityCheckbox_XpathLocator, rowCount)));
                        base.FocusOnElementByXPath(string.Format(CourseContentUXPageResource.
                            CourseContentUXPage_ActivityCheckbox_XpathLocator, rowCount));
                        //Click on Activity Checkbox
                        base.ClickButtonByXPath(string.Format(CourseContentUXPageResource.
                            CourseContentUXPage_ActivityCheckbox_XpathLocator, rowCount));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "SelectActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the activity name
        /// </summary>
        /// <param name="activityName">This is activity Name</param>
        /// <returns>This is the Activity Name</returns>
        public String GetTheActivityName(String activityName)
        {
            //Gets the Activity Name
            Logger.LogMethodEntry("CourseContentUXPage", "GetActivityName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Activity Name Variable
            string getActivityName = string.Empty;
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_Content_Window_Name,
                    CourseContentUXPageResource.
                CourseContentUXPage_Frame_Right_Id_Locator);
                //Get the Searched Activity Name
                getActivityName = GetSearchedActivityInMyCourseFrame(activityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "GetActivityName",
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Verify Copy State for Contents in Mycourse Frame
        /// </summary>
        public void VerifyCopyStateforContentsinMycourseFrame()
        {
            //Verify Copy State for Content in Mycourse Frame
            Logger.LogMethodEntry("CourseContentUXPage", "VerifyCopyStateforContentsinMycourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getCopyMessage = string.Empty;
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
                while (stopWatch.Elapsed.TotalMinutes < minutesToWait)
                {
                    //Select Right Frame
                    this.SelectFrameInWindow(CourseContentUXPageResource.
                        CourseContentUXPage_Content_Window_Name,
                        CourseContentUXPageResource.
                    CourseContentUXPage_Frame_Right_Id_Locator);
                    base.WaitForElement(By.Id(CourseContentUXPageResource.
                        CourseContentUXPage_MyCourseFrameDiv_Id_Locator));
                    //Get Copy Message
                    getCopyMessage = base.GetElementTextById(CourseContentUXPageResource.
                        CourseContentUXPage_MyCourseFrameDiv_Id_Locator);
                    if (getCopyMessage.Contains(CourseContentUXPageResource.
                        CourseContentUXPage_CopyMessage_Value) == false) break;
                    {
                        base.SwitchToDefaultPageContent();
                        //Refresh the Current Frame
                        base.RefreshIFrameByJavaScriptExecutor(CourseContentUXPageResource.
                        CourseContentUXPage_FrameRight_Id_Locator);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "VerifyCopyStateforContentsinMycourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check Cmenu Option Present or not
        /// </summary>
        /// <returns>Status of Cmenu Option</returns>
        public bool IsCmenuOptionofContentPresent(string contentCmenu)
        {
            //Check Cmenu Option Present or not
            Logger.LogMethodEntry("CourseContentUXPage", "IsCmenuOptionofContentPresent",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool getCmenuOptionStatus = false;
            string getCmenuText = string.Empty;
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.CourseContentUXPage_FrameRight_Id_Locator);
                base.WaitForElement(By.XPath(CourseContentUXPageResource.
                    CourseContentUXPage_ContentTab_CourseName_Xpath_Locator));
                //Get Content in MyCourse frame
                IWebElement getContent = base.GetWebElementPropertiesByXPath(CourseContentUXPageResource.
                    CourseContentUXPage_ContentTab_CourseName_Xpath_Locator);
                //Perform Mouse Hover
                base.PerformMouseHoverByJavaScriptExecutor(getContent);
                //Click Cmenu icon
                base.WaitForElement(By.XPath(CourseContentUXPageResource.
                    CourseContentUXPage_Content_Cmenu_MyCourse_Xpath_Locator));
                base.ClickButtonByXPath(CourseContentUXPageResource.
                    CourseContentUXPage_Content_Cmenu_MyCourse_Xpath_Locator);
                base.WaitForElement(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_Content_CmenuOption_Xpath_Locator));
                //Get Cmenu Text
                getCmenuText = base.GetElementTextById(CourseContentUXPageResource.
                    CourseContentUXPage_Content_CmenuOption_Xpath_Locator);
                if (getCmenuText.Contains(contentCmenu))
                {
                    getCmenuOptionStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "IsCmenuOptionofContentPresent",
                base.IsTakeScreenShotDuringEntryExit);
            return getCmenuOptionStatus;
        }

        /// <summary>
        /// Click On Search View Option
        /// </summary>
        public void ClickOnSearchViewOption()
        {
            //Click On Search View Option
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnSearchViewOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Refersh the Current Page
                base.RefreshTheCurrentPage();
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.CourseContentUXPage_FrameRight_Id_Locator);
                //Click On Search View Button
                this.ClickOnSearchViewButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnSearchViewOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Search View Button
        /// </summary>
        private void ClickOnSearchViewButton()
        {
            //Click On Search View Button
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnSearchViewButton",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CourseContentUXPageResource.
                CourseContentUXPage_Button_Search_ID_Locator));
            //Get Search View Button property
            IWebElement getSearchViewButtonProperty = base.GetWebElementPropertiesById(
                CourseContentUXPageResource.CourseContentUXPage_Button_Search_ID_Locator);
            base.ClickByJavaScriptExecutor(getSearchViewButtonProperty);
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnSearchViewButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Advanced Search Option
        /// </summary>
        public void ClickAdvanceSearchOption()
        {
            //Click On Advanced Search Option
            Logger.LogMethodEntry("CourseContentUXPage", "ClickAdvanceSearchOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(CourseContentUXPageResource.
                        CourseContentUXPage_AdvanceSearch_Button_Id_Locator));
                //Get Advanced Search Button property
                IWebElement getAdvancedSearchButtonProperty = base.
                    GetWebElementPropertiesById(CourseContentUXPageResource.
                    CourseContentUXPage_AdvanceSearch_Button_Id_Locator);
                base.ClickByJavaScriptExecutor(getAdvancedSearchButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickAdvanceSearchOption",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Name From Course Materials Tab
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        /// <returns>Asset Name</returns>
        public String GetAssetNameFromMyCourseTab(string assetName)
        {
            //Get Asset Name From My Course Tab
            Logger.LogMethodEntry("CourseContentUXPage",
                "GetAssetNameFromMyCourseTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssetName = string.Empty;
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.CourseContentUXPage_FrameRight_Id_Locator);
                base.WaitForElement(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_GetAssetName_Id_Locator));
                //Get Asset Name
                getAssetName = base.GetElementTextById(CourseContentUXPageResource.
                    CourseContentUXPage_GetAssetName_Id_Locator);
                if (getAssetName != assetName)
                {
                    if (getAssetName.Contains(assetName))
                    {
                        //Get Asset Name
                        getAssetName = getAssetName.Replace(
                            getAssetName.Substring(assetName.Length), string.Empty);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage",
                "GetAssetNameFromMyCourseTab",
            base.IsTakeScreenShotDuringEntryExit);
            return getAssetName;
        }

        /// <summary>
        ///  Click The Activity ShowHide Cmenu Option In MyCourse Frame.
        /// </summary>
        public void ClickTheActivityShowHideCmenuInMyCourseFrame()
        {
            // Click The Activity ShowHide Cmenu Option In MyCourse Frame
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnTheActivityCmenuInMyCourseFrame",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.CourseContentUXPage_Frame_Right_Id_Locator);
                //Course Content table search
                base.WaitForElement(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_Searched_Table_ID_Locator));
                string getAssetName = base.GetElementTextById(CourseContentUXPageResource.
                    CourseContentUXPage_Searched_Table_ID_Locator);
                if (getAssetName.Contains(CourseContentUXPageResource.
                    CourseContentUXPage_Asset_State_ShowHide))
                {
                    //Click The Activity Cmneu Image Icon
                    this.ClickTheActivityCmneuImageIcon();
                    //Select the 'Show/Hide' cmenu option
                    this.ClickTheShowHideCmenuOptionInCourseSpace();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnTheActivityCmenuInMyCourseFrame",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The CmenuOption of Activity.
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu O</param>
        public void ClickTheCmenuOptionofActivity(string cmenuOption)
        {
            // Click The Activity Cmenu Option In MyCourse Frame
            Logger.LogMethodEntry("CourseContentUXPage", "ClickTheCmenuOptionofActivity",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement getCmneuOption = base.GetWebElementPropertiesByPartialLinkText
                    (cmenuOption);
                //Click the cmenu option
                base.ClickByJavaScriptExecutor(getCmneuOption);
                Thread.Sleep(Convert.ToInt32(CourseContentUXPageResource.
                        CourseContentUX_Page_Customized_TimeOut));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickTheCmenuOptionofActivity",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click On ShowHide Cmenu Option In CourseSpace.
        /// </summary>
        private void ClickTheShowHideCmenuOptionInCourseSpace()
        {
            //Click On ShowHide Cmenu Option In CourseSpace
            Logger.LogMethodEntry("CourseContentUXPage",
                "ClickTheShowHideCmenuOptionInCourseSpace",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.XPath(CourseContentUXPageResource.
                    CourseContentUXPage_MyTestActivity_Cmenu_XPath_Locator));
                IWebElement getShowHideOption = base.GetWebElementPropertiesByXPath
                    (CourseContentUXPageResource.
                    CourseContentUXPage_MyTestActivity_Cmenu_XPath_Locator);
                //Click on the 'Show/Hide' cmenu option
                base.ClickByJavaScriptExecutor(getShowHideOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage",
                "ClickTheShowHideCmenuOptionInCourseSpace",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click The Activity Cmneu Image Icon.
        /// </summary>
        public void ClickTheActivityCmneuImageIcon()
        {
            //Click The Activity Cmneu Image Icon
            Logger.LogMethodEntry("CourseContentUXPage", "ClickTheActivityCmneuImageIcon",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.CourseContentUXPage_FrameRight_Id_Locator);
                //Wait for element 
                base.WaitForElement(By.XPath(CourseContentUXPageResource.
                    CourseContentUX_Page_MyCourseActivity_Hover_XPath_Locator));
                IWebElement getCourseContentTitleHover = base.
                    GetWebElementPropertiesByXPath(CourseContentUXPageResource.
                    CourseContentUX_Page_MyCourseActivity_Hover_XPath_Locator);
                //Mouse Hover on Activity
                base.PerformMouseHoverByJavaScriptExecutor(getCourseContentTitleHover);
                //Click on the drop down option when it is visble
                base.WaitForElement(By.ClassName(CourseContentUXPageResource.
                    CourseContentUX_Page_Activity_Cmenu_Class_Locator));
                //Get property of drop down option when it is visble
                IWebElement getCmenuOption = base.GetWebElementPropertiesByClassName
                    (CourseContentUXPageResource.
                    CourseContentUX_Page_Activity_Cmenu_Class_Locator);
                //Click on cmenu icon
                base.ClickByJavaScriptExecutor(getCmenuOption);
                Thread.Sleep(Convert.ToInt32(CourseContentUXPageResource.
                   CourseContentUXPage_ShowHide_Status_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickTheActivityCmneuImageIcon",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Display Of Activity Cmenu Options.
        /// </summary>
        /// <param name="actualCmenuOption">This is Cmenu options.</param>
        /// <returns>Displayed Cmenu Options.</returns>
        public string GetDisplayOfActivityCmenuOptions(string actualCmenuOption)
        {
            //Get Display Of Activity CmenuOptions
            Logger.LogMethodEntry("CourseContentUXPage", "GetDisplayOfActivityCmenuOptions",
             base.IsTakeScreenShotDuringEntryExit);
            //Initialize Activity Cmenuoptions Variable
            string getDisplayOfActivityCmenuOptions = string.Empty;
            try
            {
                //Wait for the element
                base.WaitForElement(By.XPath(CourseContentUXPageResource.
                    CourseContentUXPage_Activity_CmenuOption_Displayed_Xpath_Locator));
                //Get the cmenu options
                getDisplayOfActivityCmenuOptions = base.GetElementTextByXPath
                    (CourseContentUXPageResource.
                    CourseContentUXPage_Activity_CmenuOption_Displayed_Xpath_Locator);
                getDisplayOfActivityCmenuOptions = getDisplayOfActivityCmenuOptions.Replace
                    (Environment.NewLine, string.Empty).Trim();
                if (getDisplayOfActivityCmenuOptions.Contains(actualCmenuOption))
                {
                    getDisplayOfActivityCmenuOptions = actualCmenuOption;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "GetDisplayOfActivityCmenuOptions",
               base.IsTakeScreenShotDuringEntryExit);
            return getDisplayOfActivityCmenuOptions;
        }

        /// <summary>
        /// Remove Asset From Course Content
        /// </summary>
        public void RemoveAssetFromCourseContent()
        {
            //Remove Asset From Course Content
            Logger.LogMethodEntry("CourseContentUXPage", "RemoveAssetFromCourseContent",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.
                    CourseContentUXPage_FrameRight_Id_Locator);
                //Select All Asset Check Box
                this.SelectAllAssetCheckBox();
                //Click On Delete Option
                this.ClickOnDeleteOption();
                //Select Pegasus Window
                this.SelectPegasusWindow();
                //Click On Ok Button
                this.ClickOkButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "RemoveAssetFromCourseContent",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select All Asset Check Box
        /// </summary>
        private void SelectAllAssetCheckBox()
        {
            Logger.LogMethodEntry("CourseContentUXPage", "SelectAllAssetCheckBox",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_SelectAll_CheckBox_Id_Locator));
            //Get All Asset CheckBox Property 
            IWebElement getAllAssetCheckBoxProperty = base.GetWebElementPropertiesById(
                CourseContentUXPageResource.CourseContentUXPage_SelectAll_CheckBox_Id_Locator);
            //Click On All Asse Check Box
            base.ClickByJavaScriptExecutor(getAllAssetCheckBoxProperty);
            Logger.LogMethodExit("CourseContentUXPage", "SelectAllAssetCheckBox",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Delete Option
        /// </summary>
        private void ClickOnDeleteOption()
        {
            //Click On Delete Option
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnDeleteOption",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CourseContentUXPageResource.
                CourseContentUXPage_DeleteOption_Id_Locator));
            //Get Delete Button Property
            IWebElement getDeleteButtonOption = base.GetWebElementPropertiesById(
                CourseContentUXPageResource.CourseContentUXPage_DeleteOption_Id_Locator);
            base.ClickByJavaScriptExecutor(getDeleteButtonOption);
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnDeleteOption",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Pegasus Window
        /// </summary>
        private void SelectPegasusWindow()
        {
            Logger.LogMethodEntry("CourseContentUXPage", "SelectPegasusWindow",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(CourseContentUXPageResource.
                CourseContentUXPage_Pegasus_Window_Name);
            //Select Pegasus Window
            base.SelectWindow(CourseContentUXPageResource.
                CourseContentUXPage_Pegasus_Window_Name);
            Logger.LogMethodExit("CourseContentUXPage", "SelectPegasusWindow",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Ok Button
        /// </summary>
        private void ClickOkButton()
        {
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOkButton",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CourseContentUXPageResource.
                CourseContentUXPage_Ok_Button_Id_Locator));
            //Get Ok Button Property
            IWebElement getOkButtonProperty = base.GetWebElementPropertiesById(
                CourseContentUXPageResource.CourseContentUXPage_Ok_Button_Id_Locator);
            //Click On Ok Button
            base.ClickByJavaScriptExecutor(getOkButtonProperty);
            Logger.LogMethodExit("CourseContentUXPage", "ClickOkButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Activity In My Course Frame.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        public void SearchAssetInMyCourseFrame(string assetName)
        {
            //Search Activity In My Course Frame
            Logger.LogMethodEntry("CourseContentUXPage", "SearchActivityInMyCourseFrame",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click On Search View Option
                this.ClickOnSearchViewOption();
                //Fill Asset Name
                this.FillAssetNameInTextBox(assetName);
                //Click On Go Button
                this.ClickOnGoButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "SearchActivityInMyCourseFrame",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Asset Name In Text Box.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        private void FillAssetNameInTextBox(string assetName)
        {
            //Fill Asset Name In Text Box
            Logger.LogMethodEntry("CourseContentUXPage", "FillAssetNameInTextBox",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CourseContentUXPageResource.
                CourseContentUXPage_InputSearch_Textbox_Id_Locator));
            // clear search box
            base.ClearTextById(CourseContentUXPageResource.
                CourseContentUXPage_InputSearch_Textbox_Id_Locator);
            //Fill Asset Name In Text Box
            base.FillTextBoxById(CourseContentUXPageResource.
                CourseContentUXPage_InputSearch_Textbox_Id_Locator, assetName);
            Logger.LogMethodExit("CourseContentUXPage", "FillAssetNameInTextBox",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Go Button
        /// </summary>
        private void ClickOnGoButton()
        {
            //Click On Go Button
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnGoButton",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CourseContentUXPageResource.
                CourseContentUXPage_Go_Button_Id_Locator));
            //Get Go Button Property
            IWebElement getGoButtonProperty = base.GetWebElementPropertiesById(
                CourseContentUXPageResource.CourseContentUXPage_Go_Button_Id_Locator);
            //Click On Go Button
            base.ClickByJavaScriptExecutor(getGoButtonProperty);
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnGoButton",
             base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Click On Show Hide Cmenu Option
        /// </summary>
        public void ClickOnShowHideCmenuOptionforAssetInFireFox()
        {
            // Click The Activity ShowHide Cmenu Option In MyCourse Frame
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnShowHideCmenuOptionforAssetInFireFox",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.
                    CourseContentUXPage_FrameRight_Id_Locator);
                //Course Content table search
                base.WaitForElement(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_Searched_Table_ID_Locator));
                string getAssetName = base.GetElementTextById(CourseContentUXPageResource.
                    CourseContentUXPage_Searched_Table_ID_Locator);
                if (getAssetName.Contains(CourseContentUXPageResource.
                    CourseContentUXPage_Asset_State_ShowHide))
                {
                    //Click The Activity Cmneu Image Icon
                    this.ClickTheActivityCmneuImageIcon();
                    //Select the 'Show/Hide' cmenu option
                    this.ClickTheShowHideCmenuOptionInFireFox();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnShowHideCmenuOptionforAssetInFireFox",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click On ShowHide Cmenu Option .
        /// </summary>
        private void ClickTheShowHideCmenuOptionInFireFox()
        {
            //Click On ShowHide Cmenu Option In CourseSpace
            Logger.LogMethodEntry("CourseContentUXPage",
                "ClickTheShowHideCmenuOptionInFireFox",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.XPath(CourseContentUXPageResource.
                    CourseContentUXPage_Activity_Cmenu_XPath_Locator1));
                IWebElement getShowHideOption = base.GetWebElementPropertiesByXPath
                    (CourseContentUXPageResource.
                    CourseContentUXPage_Activity_Cmenu_XPath_Locator1);
                //Click on the 'Show/Hide' cmenu option
                base.ClickByJavaScriptExecutor(getShowHideOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage",
                "ClickTheShowHideCmenuOptionInFireFox",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create The NonGradable Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type enum.</param>
        public void CreateTheNonGradableActivity(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create The NonGradable Activity
            Logger.LogMethodEntry("CourseContentUXPage",
                "CreateTheNonGradableActivity",
                      base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (activityTypeEnum)
                {
                    case Activity.ActivityTypeEnum.Link:
                        //Create Link Asset
                        new AddUrlPage().CreateLinkAsset(activityTypeEnum);
                        //Click On Add And Close Button
                        new ContentBrowserUXPage().ClickOnAddAndCloseButton();
                        break;
                    case Activity.ActivityTypeEnum.File:
                        //Create File Asset
                        new UploadFilePage().CreateFileAsset(activityTypeEnum);
                        //Click On Add And Close Button
                        new ContentBrowserUXPage().ClickOnAddAndCloseButton();
                        break;
                    case Activity.ActivityTypeEnum.DiscussionTopic:
                        //Create Discussion Topic 
                        new AddDiscussionTopicPage().
                                    CreateDiscussionTopicAsset(activityTypeEnum);
                        //Click On Add And Close Button
                        new ContentBrowserUXPage().ClickOnAddAndCloseButton();
                        break;
                    case Activity.ActivityTypeEnum.Page:
                        //Creation of page
                        new PegasusHTMLUXPage().CreatePageAsset(activityTypeEnum);
                        //Click On Add And Close Button
                        new ContentBrowserUXPage().ClickOnAddAndCloseButton();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage",
                "CreateTheNonGradableActivity",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Content Order In My Course.
        /// </summary>
        /// <returns>Assets Name.</returns>
        public String GetContentOrderInMyCourse()
        {
            //Get Content Order In My Course
            Logger.LogMethodEntry("CourseContentUXPage",
                "GetContentOrderInMyCourse",
                      base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variables
            string getAssetText = string.Empty;
            string getAssetsName = string.Empty;
            //Click On 'Add from Library' tab
            this.ClickOnAddFromLibraryTab();
            //Select Right Frame
            this.SelectFrameInWindow(CourseContentUXPageResource.
                CourseContentUXPage_CourseMaterials_Window_Title,
                CourseContentUXPageResource.CourseContentUXPage_FrameRight_Id_Locator);
            base.WaitForElement(By.XPath(CourseContentUXPageResource.
                CourseContentUXPage_Asset_Count_Xpath_Locator));
            //Get Assets Total Count
            int assetCount = base.GetElementCountByXPath(CourseContentUXPageResource.
                CourseContentUXPage_Asset_Count_Xpath_Locator);
            for (int rowCount = Convert.ToInt32(CourseContentUXPageResource.
                CourseContentUXPage_Loop_Initializer_Value);
                rowCount <= assetCount; rowCount++)
            {
                //Get Assets Name
                getAssetText =
                    base.GetElementTextByXPath(string.Format(CourseContentUXPageResource.
                    CourseContentUXPage_Asset_Name_Xpath_Locator, rowCount));
                getAssetsName += getAssetText;
            }
            Logger.LogMethodExit("CourseContentUXPage",
                "GetContentOrderInMyCourse",
                     base.IsTakeScreenShotDuringEntryExit);
            return getAssetsName;
        }

        /// <summary>
        /// Click On 'Add from Library' tab.
        /// </summary>
        private void ClickOnAddFromLibraryTab()
        {
            //Click On 'Add from Library' tab
            Logger.LogMethodEntry("CourseContentUXPage",
               "ClickOnAddFromLibraryTab",
                     base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(CourseContentUXPageResource.
                CourseContentUXPage_AddfromLibrary_Tab_Name));
            //Get Tab Link Property
            IWebElement getTabNameProperty =
                base.GetWebElementPropertiesByPartialLinkText(CourseContentUXPageResource.
                CourseContentUXPage_AddfromLibrary_Tab_Name);
            //Click On 'Add from Library' Tab
            base.ClickByJavaScriptExecutor(getTabNameProperty);
            Logger.LogMethodExit("CourseContentUXPage",
               "ClickOnAddFromLibraryTab",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign The Activity In CourseContent.
        /// </summary>
        public void AssignTheActivityInCourseContent()
        {
            //Assign The Activity In CourseContent
            Logger.LogMethodEntry("CourseContentUXPage",
               "AssignTheActivityInCourseContent",
                     base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.
                    CourseContentUXPage_FrameRight_Id_Locator);
                //Wait for the checkbox
                base.IsElementPresent(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_Activity_Checkbox_Id_Locator));
                IWebElement getAssetCheckbox = base.GetWebElementPropertiesById
                    (CourseContentUXPageResource.
                    CourseContentUXPage_Activity_Checkbox_Id_Locator);
                //Select the checkbox
                base.ClickByJavaScriptExecutor(getAssetCheckbox);
                //Wait for the element
                base.WaitForElement(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_AssignUnassign_Id_Locator));
                IWebElement getAssignLink = base.GetWebElementPropertiesById
                    (CourseContentUXPageResource.
                    CourseContentUXPage_AssignUnassign_Id_Locator);
                //Click on the 'Assign/UnAssign' link
                base.ClickByJavaScriptExecutor(getAssignLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage",
               "AssignTheActivityInCourseContent",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select and swith to My Course.
        /// </summary>
        public void SelectAndSwitchToMyCourseHome()
        {
            Logger.LogMethodEntry("CourseContentUXPage",
               "SelectAndSwitchToMyCourseHome",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(CourseContentUXPageResource
                    .CourseContentUXPage_FrameRight_Id_Locator));
                this.SelectFrameInWindow(CourseContentUXPageResource.
                   CourseContentUXPage_CourseMaterials_Window_Title,
                   CourseContentUXPageResource.CourseContentUXPage_FrameRight_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage",
                "SelectAndSwitchToMyCourseHome",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects check boxes in assets item listed in My Course home.
        /// </summary>
        /// <param name="assetCount">Number of assets to be selected.</param>
        public void SelectCheckboxOfAssets(int assetCount)
        {
            Logger.LogMethodEntry("CourseContentUXPage",
                "SelectCheckboxOfAssets",
             base.IsTakeScreenShotDuringEntryExit);
            if (assetCount <= 0) return;
            base.WaitForElement(By.Id(CourseContentUXPageResource
                .CourseContentUXPage_Activity_Checkbox_Id_Locator));
            ICollection<IWebElement> assetCheckBoxs = base.GetWebElementsCollectionById(
                CourseContentUXPageResource
                .CourseContentUXPage_Activity_Checkbox_Id_Locator);
            int counter = 0;
            foreach (IWebElement assetCheckBox in assetCheckBoxs)
            {
                base.ClickByJavaScriptExecutor(assetCheckBox);
                this.StoreSelectedActivityInMemory(assetCheckBox);
                ++counter;
                if (counter >= assetCount) break;
            }

            Logger.LogMethodExit("CourseContentUXPage",
                "SelectCheckboxOfAssets",
             base.IsTakeScreenShotDuringEntryExit);
        }

        public bool IsButtonEnabled(MyCourseButtonType buttonType)
        {
            Logger.LogMethodEntry("CourseContentUXPage",
                "IsButtonEnabled",
             base.IsTakeScreenShotDuringEntryExit);

            string buttonID = this.GetButtonIDByButtonType(buttonType);
            if (buttonID == null) return false;
            return base.IsElementEnabledById(buttonID);
        }

        /// <summary>
        /// Clicks button on header.
        /// </summary>
        /// <param name="buttonType">Type of the button.</param>
        public void ClickButtonOnHeader(MyCourseButtonType buttonType)
        {
            Logger.LogMethodEntry("CourseContentUXPage",
               "ClickButtonOnHeader",
                base.IsTakeScreenShotDuringEntryExit);
            this.ClickHeaderButtonById(this
                .GetButtonIDByButtonType(buttonType));
            Thread.Sleep(Convert.ToInt32(CourseContentUXPageResource
                .CourseContentUXPage_ShowHide_Status_Time_Value));
            Logger.LogMethodExit("CourseContentUXPage",
                "ClickButtonOnHeader",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Gets the show-hide status of the activity.
        /// </summary>
        /// <param name="activityID">Activity ID.</param>
        /// <returns>Show-hide status.</returns>
        public Activity.ShowHideStatusEnum GetAssetsShowHideStatus(string activityID)
        {
            base.WaitForElement(By.XPath(string.Format(
                CourseContentUXPageResource.CourseContentUXPage_ActivityTitle_Table_XPath_Locator
                , activityID)));
            IWebElement assetTitleTable = base.GetWebElementPropertiesByXPath(string.Format(
                CourseContentUXPageResource.CourseContentUXPage_ActivityTitle_Table_XPath_Locator
                , activityID));
            return (Activity.ShowHideStatusEnum)
                Convert.ToInt32(assetTitleTable.GetAttribute(
                CourseContentUXPageResource.CourseContentUXPage_IsHiddenAttribute_Value));
        }

        /// <summary>
        /// Gets the text displayed in Shown To column.
        /// </summary>
        /// <param name="activityId">Activity ID</param>
        /// <returns></returns>
        public string GetTextInShownToColumn(string activityId)
        {
            Logger.LogMethodEntry("CourseContentUXPage",
                "GetTextInShownToColumn",
                 base.IsTakeScreenShotDuringEntryExit);
            return base.GetElementTextByXPath(string.Format(CourseContentUXPageResource
                .CourseContentUXPage_Activity_ShownToColumn_Span_XPath_Locator
                , activityId));
        }

        /// <summary>
        /// Gets the ID attribute value of button by button type.
        /// </summary>
        /// <param name="buttonType">Type of the button.</param>
        /// <returns>ID attribute value of the button.</returns>
        private string GetButtonIDByButtonType(
            MyCourseButtonType buttonType)
        {
            string buttonId = null;
            if (buttonType == MyCourseButtonType.ShowHide)
            {
                buttonId = CourseContentUXPageResource
                    .CourseContentUXPage_ShowHide_Link_ID_Locator;
            }

            return buttonId;
        }

        /// <summary>
        /// Clicks the button by its ID attribute.
        /// </summary>
        /// <param name="buttonId">ID attribute of the button.</param>
        private void ClickHeaderButtonById(string buttonId)
        {
            if (buttonId != null)
            {
                base.WaitForElement(By.Id(buttonId));
                IWebElement headerButton = base
                    .GetWebElementPropertiesById(buttonId);
                base.ClickByJavaScriptExecutor(headerButton);
            }
        }

        /// <summary>
        /// Stores select checkbox activity to memory.
        /// </summary>
        /// <param name="assetCheckBox"></param>
        private void StoreSelectedActivityInMemory(IWebElement assetCheckBox)
        {
            string activityId = assetCheckBox.GetAttribute(
                CourseContentUXPageResource.CourseContentUXPage_ValueAttribute_Value);
            if (string.IsNullOrEmpty(activityId)) return;
            var activity = new Activity
            {
                ActivityId = activityId,
                ShowHideStatus = this.GetAssetsShowHideStatus(activityId),
                IsCreated = true
            };
            activity.StoreActivityInMemory();
        }

        /// <summary>
        /// Select Activity
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        public void SelectAssetCheckBox(string activityName)
        {
            //Select Activity
            Logger.LogMethodEntry("CourseContentUXPage", "SelectActivity",
               base.IsTakeScreenShotDuringEntryExit);

            //Initialize Variable
            string getActivityname = string.Empty;
            int rID = 0;

            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.CourseContentUXPage_FrameRight_Id_Locator);

                //Get ActivityCount
                int getActivitycount = base.GetElementCountByXPath(CourseContentUXPageResource.
                    CourseContentUXPage_SearchedActivityCount_XPath_Locator);
                for (int rowCount = Convert.ToInt32(CourseContentUXPageResource.
                    CourseContentUXPage_Loop_Initializer_Value); rowCount <= getActivitycount; rowCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(CourseContentUXPageResource.
                        CourseContentUXPage_ActivityName_Xpath_Locator, rowCount)));
                    //Get Activity Name
                    getActivityname = base.GetElementTextByXPath(string.Format(CourseContentUXPageResource.
                        CourseContentUXPage_ActivityName_Xpath_Locator, rowCount));
                    if (getActivityname == activityName)
                    {
                        rID = rowCount;
                        break;
                    }
                }

                IWebElement getAsset = base.GetWebElementPropertiesByXPath(string.Format(CourseContentUXPageResource.
                    CourseContentUXPage_chkLink_Xpath_Locator, rID));
                
                base.ClickByJavaScriptExecutor(getAsset);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "SelectActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The ShowHide Status Option.
        /// </summary>
        public void ClickOnShowHideStatusOption()
        {
            // Click The ShowHide Status Option
            Logger.LogMethodEntry("CourseContentUXPage", "ClickOnShowHideStatusOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.CourseContentUXPage_FrameRight_Id_Locator);
                //Wait for the showhide link
                base.WaitForElement(By.Id(CourseContentUXPageResource.
                    CourseContentUXPage_ShowHide_Link_ID_Locator));
                IWebElement getShowHideProperty = base.GetWebElementPropertiesById
                    (CourseContentUXPageResource.
                    CourseContentUXPage_ShowHide_Link_ID_Locator);
                //Click on showhide link
                base.ClickByJavaScriptExecutor(getShowHideProperty);
                Thread.Sleep(Convert.ToInt32(CourseContentUXPageResource.
                    CourseContentUXPage_ShowHide_Status_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", "ClickOnShowHideStatusOption",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the activity ID
        /// </summary>
        /// <param name="activityName">This is activity Name</param>
        /// <returns>This is the Activity Name</returns>
        public string getAssetID(string activityName)
        {
            //Select Activity
            Logger.LogMethodEntry("CourseContentUXPage", "getAssetID",
               base.IsTakeScreenShotDuringEntryExit);

            //Initialize Variable
            string getActivityname = string.Empty, ID = string.Empty;
            int rID = 0;

            try
            {               
                //Select Right Frame
                this.SelectFrameInWindow(CourseContentUXPageResource.
                    CourseContentUXPage_CourseMaterials_Window_Title,
                    CourseContentUXPageResource.CourseContentUXPage_FrameRight_Id_Locator);

                //Get ActivityCount
                int getActivitycount = base.GetElementCountByXPath(CourseContentUXPageResource.
                    CourseContentUXPage_SearchedActivityCount_XPath_Locator);

                for (int rowCount = Convert.ToInt32(CourseContentUXPageResource.
                    CourseContentUXPage_Loop_Initializer_Value); rowCount <= getActivitycount; rowCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(CourseContentUXPageResource.
                        CourseContentUXPage_ActivityName_Xpath_Locator, rowCount)));
                    //Get Activity Name
                    getActivityname = base.GetElementTextByXPath(string.Format(CourseContentUXPageResource.
                        CourseContentUXPage_ActivityName_Xpath_Locator, rowCount));
                    if (getActivityname == activityName)
                    {
                        rID = rowCount;
                        break;
                    }
                }
                IWebElement getSelectedTabElement = base.GetWebElementPropertiesByXPath(string.Format(CourseContentUXPageResource.
                    CourseContentUXPage_link_Xpath_Locator, rID));
                ID = getSelectedTabElement.GetAttribute("id");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("CourseContentUXPage", "getAssetID",
                base.IsTakeScreenShotDuringEntryExit);

            return ID;
        }

        /// <summary>
        /// Answer and submit the SAM Activity to score 100.
        /// </summary>
        public void SubmitSAMActivityToScore100()
        {
            //Answer the SAM Activity to score 100
            Logger.LogMethodEntry("CourseContentUXPage",
                "SubmitSAMActivityToScore100",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {               
                //Input answer to the activity questions
                this.AnswerSAMActivity(1, CourseContentUXPageResource
                    .CourseContentUXPage_WLActivity_Q1_Answer);
                this.AnswerSAMActivity(2, CourseContentUXPageResource.
                    CourseContentUXPage_WLActivity_Q2_Answer);
                this.AnswerSAMActivity(3, CourseContentUXPageResource.
                    CourseContentUXPage_WLActivity_Q3_Answer);
                this.AnswerSAMActivity(4, CourseContentUXPageResource.
                    CourseContentUXPage_WLActivity_Q4_Answer);
                this.AnswerSAMActivity(5, CourseContentUXPageResource.
                    CourseContentUXPage_WLActivity_Q5_Answer);
                    this.AnswerSAMActivity(6, CourseContentUXPageResource.
                    CourseContentUXPage_WLActivity_Q6_Answer);
                //submit the activity
            this.SubmitActivity();
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
             Logger.LogMethodExit("CourseContentUXPage",
                 "SubmitSAMActivityToScore100",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Answer the SAM activity questions based on field value.
        /// </summary>
        /// <param name="answerFieldValue">This is the answer field value.</param>
        /// <param name="fieldAnswer">This is the answer text.</param>       
        public void AnswerSAMActivity(int answerFieldValue, string fieldAnswer)
        {
            //Answer the SAM activity questions based on field value
            Logger.LogMethodEntry("CourseContentUXPage", 
                "AnswerSAMActivity",
                  base.IsTakeScreenShotDuringEntryExit);
           try
            {
                //Switch to Activity window
                this.SelectActivityWindow(CourseContentUXPageResource.
                    CourseContentUXPage_WL_ActivityWindowName);                       
                IWebElement getAnswerField = base.
                    GetWebElementPropertiesByCssSelector(
                    string.Format(CourseContentUXPageResource.
                    CourseContentUXPage_WL_SAMActivity_AnswerField_CSS_Locator,
                    answerFieldValue));
                string getAnswerFieldId = getAnswerField.GetAttribute(
                    CourseContentUXPageResource.
                CourseContentUXPage_WL_SAMActivity_Attribute);
                string textId = getAnswerFieldId.Split('_')[1];
                string getId = textId + getAnswerFieldId +
                    CourseContentUXPageResource.
                    CourseContentUXPage_WL_SAMActivity_AppendText;
                base.FillTextBoxById(getId, fieldAnswer);
            }
            catch (Exception e)
            {
             ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage", 
                "AnswerSAMActivity",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity Window
        /// </summary>
        /// <param name="windowName">This is the Window Name</param>
        public void SelectActivityWindow(string windowName)
        {
            Logger.LogMethodEntry("CourseContentUXPage",
                "SelectActivityWindow",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to Activity window
                base.WaitUntilWindowLoads(windowName);
                base.SelectWindow(windowName);
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage",
                "SelectActivityWindow",
                   base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Answer and submit the SAM Activity to score 0.
        /// </summary>
        public void SubmitSamActivityToScore0()
        {
            //Answer the SAM Activity to score 0
            Logger.LogMethodEntry("CourseContentUXPage",
                "SubmitSamActivityToScore0",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Input answer to the activity questions
                for (int i = Convert.ToInt16(CourseContentUXPageResource.
                    CourseContentUXPage_ActivityLoop_Initializer_Value);
                    i <= Convert.ToInt16(CourseContentUXPageResource.
                    CourseContentUXPage_ActivityLoop_End_Value); i++)
                {
                    this.AnswerSAMActivity(i, CourseContentUXPageResource.
                        CourseContentUXPage_WLActivity_WrongAnswer);                    
                }
                //submit the activity
               this.SubmitActivity();
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage",
                "SubmitSamActivityToScore0",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submitting the Word Language Essay Activity By Student.
        /// </summary>
        /// <param name="answerField">This is the answer field value.</param>
        public void SubmittingWorldLanguageEssayActivityByStudent(int answerField)
        {
            Logger.LogMethodEntry("CourseContentUXPage",
                "SubmittingWorldLanguageEssayActivityByStudent",
                         base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectActivityWindow(CourseContentUXPageResource.
                   CourseContentUXPage_WL_ActivityWindowName);
                string getActivityId = base.GetWebElementPropertiesByCssSelector
                    (String.Format(CourseContentUXPageResource.
                    CoursePreviewUX_Page_Activity_Properties_CSS_Selector,
                    answerField)).GetAttribute(CourseContentUXPageResource.
                CourseContentUXPage_WL_SAMActivity_Attribute);
                string activityId = getActivityId.Split('_')[1];
                Guid guidAnswerText = Guid.NewGuid();
                base.FillTextBoxById(activityId, guidAnswerText.ToString());
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("CourseContentUXPage",
                "SubmittingWorldLanguageEssayActivityByStudent",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the Essay activity in Word Language.
        /// </summary>
        public void SubmitWordLanguageEssayActivity()
        {
            //Answer the Essay Activity
            Logger.LogMethodEntry("CourseContentUXPage",
                "SubmitWordLanguageEssayActivity",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                for (int i = Convert.ToInt16(CourseContentUXPageResource.
                    CourseContentUXPage_ActivityLoop_Initializer_Value);
                    i <= Convert.ToInt16(
                    CourseContentUXPageResource.
                    CourseContentUXPage_ActivityLoop_Limit_Value); i++)
                {
                    //Input answer to the activity questions
                    this.SubmittingWorldLanguageEssayActivityByStudent(i);
                }
                // Submitt WL Activity
                this.SubmitActivity();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseContentUXPage",
                "SubmitWordLanguageEssayActivity",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submitt Word Language Activity.
        /// </summary>
        public void SubmitActivity()
        {
           Logger.LogMethodEntry("CourseContentUXPage", "SubmitActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on submit button
                IWebElement getFinishButton = base.
                    GetWebElementPropertiesByPartialLinkText
                    (CourseContentUXPageResource.
                    CoursePreviewUX_Page_Submit_Button_LinkText_Locator);
                base.ClickByJavaScriptExecutor(getFinishButton);
                //Click on Finish button
                IWebElement finishButton = base.GetWebElementPropertiesById(
                    CourseContentUXPageResource.
                    CoursePreviewUX_Page_Finish_Button_Id_Locator);
                base.ClickByJavaScriptExecutor(finishButton);
                Thread.Sleep(Convert.ToInt32(CourseContentUXPageResource.
                    CourseContentUXPage_ShowHide_Status_Time_Value));
                //Click on 'Return to course'
                IWebElement returnToCourse = base.GetWebElementPropertiesById(
                   CourseContentUXPageResource.
                   CoursePreviewUX_Page_ReturntoCourse_Button_Id_Locator);
                base.ClickByJavaScriptExecutor(returnToCourse);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("CourseContentUXPage", "SubmitActivity",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Activity Status of WL Activity.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <returns>The Activity status.</returns>
        public string GetTheActivityStatusofWordLanguageActivity(string activityName)
        {

            Logger.LogMethodEntry("CourseContentUXPage",
                "GetTheActivityStatusofWordLanguageActivity",
                base.IsTakeScreenShotDuringEntryExit);
            string getactivityStatus = string.Empty;
            try
            {
                //Selecting Window.
                new StudentPresentationPage().SelectWindowAndFrame();
                //Verify The Actvity Status.
                IWebElement getactivityId = base.
                    GetWebElementPropertiesByPartialLinkText(string.Format(activityName));
                string activityId = getactivityId.GetAttribute(
                    CourseContentUXPageResource.
                CourseContentUXPage_WL_SAMActivity_Attribute);
                string textactivityId = activityId.Split('_')[1];
                string activityStatusId = CourseContentUXPageResource.
                    CourseContentUXPage_WLActivity_AppendText + 
                    CourseContentUXPageResource.
                    CourseContentUXPage_WLActivity_AppendSymbol + textactivityId;
                base.WaitForElement(By.Id(activityStatusId));
                getactivityStatus = base.GetElementTextById(activityStatusId);
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
           Logger.LogMethodEntry("CoursePreviewUXPage",
                "GetTheActivityStatusofWordLanguageActivity",
                        base.IsTakeScreenShotDuringEntryExit);
            return getactivityStatus;
        }

        /// <summary>
        /// Submitting the Learnocity Activity By Student
        /// </summary>
        /// <param name="recordButtonNumber">This is record button.</param>
        public void SubmittingtheLearnocityActivityByStudent()
        {
            try
            {
                this.SelectActivityWindow(CourseContentUXPageResource.
                   CourseContentUXPage_WL_ActivityWindowName);
                IList<IWebElement> recordButtonList = WebDriver.FindElements(By.CssSelector("[class$='lrn_btn lrn_start_recording']"));
                for (int i = 0; i < recordButtonList.Count; i++)
                {
                    Thread.Sleep(3000);
                    base.ClickByJavaScriptExecutor(recordButtonList[i]);
                    Thread.Sleep(5000);
                    base.SelectWindow(CoursePreviewUXPageResource.CoursePreviewUX_Page_Activity_Window_Title_Name_HED);
                    base.ClickByJavaScriptExecutor(recordButtonList[i]);
                }
                // Submitt WL Activity
                new CourseContentUXPage().SubmitActivity();
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
        }
    }
}
