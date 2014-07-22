using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains the details of the Content Library frame 
    /// in the Add Content from Library in the Content tab
    /// </summary>
    public class ContentLibraryUXPage : BasePage
    {
        /// <summary>
        /// This is the static instance of logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ContentLibraryUXPage));

        /// <summary>
        /// This the enum available for Course Materials type Enum
        /// </summary>
        public enum CourseMaterialsTypeEnum
        {
            /// <summary>
            /// Course Materials type for Content Libarry.
            /// </summary>
            ContentLibrary = 1,
            /// <summary>
            /// Course Materials type for Course Content.
            /// </summary>
            CourseContent,
        }

        /// <summary>
        /// Specifiyies different button types available in Advanced Options.
        /// </summary>
        public enum AdvancedOptionsButtonType
        {
            Copy = 1,
            Cut = 2,
            Delete = 3,
            Paste = 4
        }

        /// <summary>
        /// Possible Options available for pasting the assets.
        /// </summary>
        public enum PasteOptions
        {
            PasteAtTop = 1,
            PasteBeforeSelected = 2,
            PasteAfterSelected = 3,
            PasteAtBottom = 4
        }

        /// <summary>
        /// Click on Add Content Options.
        /// </summary>
        /// <param name="linkName">This is Link Name.</param>
        public void ClickOnAddContentOption(string linkName)
        {
            //Click on Add Content Options
            logger.LogMethodEntry("ContentLibraryUXPage",
                "ClickOnAddContentOption", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Left Frame In Content Window
                this.SelectLeftFrameInContentWindow();
                //Select Asset Type From Add Content Link Option
                this.SelectAssetTypeFromAddContentLinkOption(linkName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage",
                "ClickOnAddContentOption", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Asset Type From Add Content Link Option.
        /// </summary>
        /// <param name="linkName">This is Link Name</param>
        private void SelectAssetTypeFromAddContentLinkOption(string linkName)
        {
            //Select Asset Type From Add Content Link Option
            logger.LogMethodEntry("ContentLibraryUXPage",
                "ClickOnLinkOption", base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_AddContent_Link_PartialLinktext_Locator));
            IWebElement getAddContentButton = base.GetWebElementPropertiesByPartialLinkText
                (ContentLibraryUXPageResource.
                ContentLibraryUX_Page_AddContent_Link_PartialLinktext_Locator);
            //Click on Add Content Button
            base.ClickByJavaScriptExecutor(getAddContentButton);  
            int getLinkCount = base.GetElementCountByXPath(ContentLibraryUXPageResource.
                ContentLibraryUX_Page_AddContentOptionCount_Xpath_Locator);
            for (int i = 1; i <= getLinkCount; i++)
            {
                //Get the Name of the Link
                string getLinkName = base.GetElementTextByXPath(string.Format(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_getLinkName_Xpath_Locator, i));
                if (getLinkName == linkName)
                {
                    base.WaitForElement(By.XPath(string.Format(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_getLinkName_Xpath_Locator, i)));
                    IWebElement getActivityType=base.GetWebElementPropertiesByXPath
                        (string.Format(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_getLinkName_Xpath_Locator, i));
                    //Click on Activity Radio Button
                    base.ClickByJavaScriptExecutor(getActivityType);
                    Thread.Sleep(Convert.ToInt32(ContentLibraryUXPageResource.
                                ContentLibraryUXPage_ElementLoad_Time_Value));
                    break;
                }
            }
            logger.LogMethodExit("ContentLibraryUXPage",
                "ClickOnLinkOption", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Import LTI Activity Links option
        /// </summary>
        public void ClickOnImportLTIActivityLinksOption()
        {
            //Click on the Import LTI Activity Links option
            logger.LogMethodEntry("ContentLibraryUXPage", "ClickOnImportLTIActivityLinksOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.SelectWindow(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_ContentWindow_Name);
                //Wait for the Content Library Frame
                base.WaitForElement(By.Id(ContentLibraryUXPageResource.
                        ContentLibraryUX_Page_Left_Frame_ID_Locator));
                //Switch to Content Library Frame
                base.SwitchToIFrame(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_Left_Frame_ID_Locator);
                //Wait for the Add Content Button
                base.WaitForElement(By.PartialLinkText(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_AddContent_Link_PartialLinktext_Locator));
                //Click on the Add Content Button
                base.ClickButtonByPartialLinkText(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_AddContent_Link_PartialLinktext_Locator);
                if (base.IsElementPresent(By.XPath(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_ImportLTIActivityLinksXpath_Locator),
                    Convert.ToInt32(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_Customized_TimeOut)))
                {
                    IWebElement getImport=base.GetWebElementPropertiesByXPath
                        (ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_ImportLTIActivityLinksXpath_Locator);
                    //Click on the Import LTI Activity Links option
                    base.ClickByJavaScriptExecutor(getImport);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "ClickOnImportLTIActivityLinksOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Activity Name
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        /// <returns>Activity Name</returns>
        public String GetActivityName(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Gets the Activity Name
            logger.LogMethodEntry("ContentLibraryUXPage", "GetActivityName",
                base.isTakeScreenShotDuringEntryExit);
            String getActivityName = String.Empty;
            try
            {
                //Refresh the Page to Display the Activities
                base.RefreshTheCurrentPage();
                this.SelectLeftFrameInContentWindow();
                Activity activity = Activity.Get(activityTypeEnum);
                //Search the Activity Name
                this.SearchTheActivity(activity.Name);
                //Selct the Content Frane
                this.SelectLeftFrameInContentWindow();
                //Get searched activity
                getActivityName = this.GetSearchedActivity(activity.Name);
                //Store Activity Details In Memory
                this.StoreActivityDetailsInMemory(getActivityName, activityTypeEnum);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "GetActivityName",
                base.isTakeScreenShotDuringEntryExit);
            //Refresh the Page
            base.RefreshTheCurrentPage();
            return getActivityName;
        }

        /// <summary>
        /// Get And Store MGM Test Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity Name.</returns>
        public string GetAndStoreMGMTestActivity(string activityName)
        {
            //Get And Store MGM Test Activity
            logger.LogMethodEntry("ContentLibraryUXPage", "GetAndStoreMGMTestActivity",
                base.isTakeScreenShotDuringEntryExit);
            String getActivityName = String.Empty;
            try
            {
                //Refresh the Page to Display the Activities
                base.RefreshTheCurrentPage();
                this.SelectLeftFrameInContentWindow();
                //Search the Activity 
                this.SearchTheActivity(activityName);
                //Selct the Content Frame
                this.SelectLeftFrameInContentWindow();
                //Get searched activity
                getActivityName = this.GetSearchedActivity(activityName);
                //Store Activity Details In Memory
                this.StoreActivityDetailsInMemory(getActivityName,
                    Activity.ActivityTypeEnum.Test);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "GetAndStoreMGMTestActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Refresh the Page
            base.RefreshTheCurrentPage();
            return getActivityName;
        }
        /// <summary>
        /// Select Left Frame In Content Window.
        /// </summary>
        public void SelectLeftFrameInContentWindow()
        {
            //Select Left Frame In Content Window
            logger.LogMethodEntry("ContentLibraryUXPage", "SelectLeftFrameInContentWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Selects the Default Window
                base.WaitUntilWindowLoads(ContentLibraryUXPageResource.
                   ContentLibraryUXPage_ContentWindow_Name);
                base.SelectWindow(ContentLibraryUXPageResource.
                   ContentLibraryUXPage_ContentWindow_Name);
                //Wait for the Content Library Frame
                base.WaitForElement(By.Id(ContentLibraryUXPageResource.
                        ContentLibraryUX_Page_Left_Frame_ID_Locator));
                base.SwitchToIFrame(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_Left_Frame_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "SelectLeftFrameInContentWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store the Activity Details in Memory.
        /// </summary>
        /// <param name="activityName">This is the Activity Name.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        private void StoreActivityDetailsInMemory(string activityName,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Storing the Activity Name
            logger.LogMethodEntry("ContentLibraryUXPage", "StoreActivityDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
            Activity newActivity;
            switch (activityTypeEnum)
            {
                case Activity.ActivityTypeEnum.Test:
                    newActivity = new Activity
                    {
                        ActivityID = CommonResource.CommonResource.DigitalPath_Activity_Test_UC1,
                        Name = activityName,
                        ActivityType = Activity.ActivityTypeEnum.Test,
                        IsCreated = true,
                    };
                    //Saves the Activity
                    newActivity.StoreActivityInMemory();
                    break;
                case Activity.ActivityTypeEnum.SkillStudyPlan:
                    newActivity = new Activity
                    {
                        ActivityID = CommonResource.CommonResource.DigitalPath_Activity_SkillStudyPlan_UC1,
                        Name = activityName,
                        ActivityType = Activity.ActivityTypeEnum.Test,
                        IsCreated = true,
                    };
                    //Saves the Activity
                    newActivity.StoreActivityInMemory();
                    break;
            }
            logger.LogMethodExit("ContentLibraryUXPage", "StoreActivityDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Activity.
        /// </summary>
        /// <param name="activityName">This is Activity name.</param>
        public void SearchTheActivity(String activityName)
        {
            //Search the Activity
            logger.LogMethodEntry("ContentLibraryUXPage", "SearchTheActivity",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_Button_Search_ID_Locator));
                IWebElement getSearchButton = base.GetWebElementPropertiesById
                    (ContentLibraryUXPageResource.
                    ContentLibraryUXPage_Button_Search_ID_Locator);
                //Click the search button
                base.ClickByJavaScriptExecutor(getSearchButton);
                //Wait for Search field
                base.WaitForElement(By.ClassName(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_Search_Textbox_ID_Locator));
                //Fill Text in the Text box
                base.FillTextBoxByClassName(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_Search_Textbox_ID_Locator, activityName.ToString());
                //Wait for the element
                base.WaitForElement(By.Id(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_Go_Button_Id_Locator));
                IWebElement getGoButton = base.GetWebElementPropertiesById
                    (ContentLibraryUXPageResource.ContentLibraryUXPage_Go_Button_Id_Locator);
                //Click the GO button
                base.ClickByJavaScriptExecutor(getGoButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "SearchTheActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Searched Activity
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        /// <returns>Searched Activity Name</returns>
        public string GetSearchedActivity(String activityName)
        {
            //Get the Searched Activity
            logger.LogMethodEntry("ContentLibraryUXPage", "GetSearchedActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Content Library table search
            base.WaitForElement(By.Id(ContentLibraryUXPageResource.
                ContentLibraryUXPage_Searched_Table_ID_Locator));
            string getSearchedActivityName = string.Empty;
            //Gets the Count of Activities
            int getActivityCount = base.GetElementCountByXPath(ContentLibraryUXPageResource.
                ContentLibraryUXPage_SearchedActivityCount_XPath_Locator);
            for (int rowCountAfterSearch = Convert.ToInt32(ContentLibraryUXPageResource.
                ContentLibraryUXPage_Activity_RowCount_InitialValue_AfterSearch);
                rowCountAfterSearch <= getActivityCount; rowCountAfterSearch++)
            {
                //Gets the Activity Name
                getSearchedActivityName = base.GetElementTextByXPath
                    (string.Format(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_Searched_ActivityName_Xpath_Locator, rowCountAfterSearch)).Trim();
                if (getSearchedActivityName.Contains(activityName))
                {
                    getSearchedActivityName = activityName;
                    break;
                }
                else
                {
                    getSearchedActivityName = string.Empty;
                }
                Thread.Sleep(Convert.ToInt32(ContentLibraryUXPageResource.
                                ContentLibraryUXPage_ElementLoad_Time_Value));
            }
            logger.LogMethodExit("ContentLibraryUXPage", "GetSearchedActivity",
                base.isTakeScreenShotDuringEntryExit);
            return getSearchedActivityName;
        }

        /// <summary>
        /// Selects the Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SelectActivity(String activityName)
        {
            //Selects the Activity
            logger.LogMethodEntry("ContentLibraryUXPage", "SelectActivity",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the Next link if Activity Not Present
                ClickOnNextLinkIfActivityNotPresent(activityName);
                //Select the Activity
                int getActivityCount = base.GetElementCountByXPath(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_SearchedActivityCount_XPath_Locator);
                for (int rowCount = Convert.ToInt32(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_Activity_Counter); rowCount <= getActivityCount;
                    rowCount++)
                {
                    //Gets the Activity Name
                    string getActivityName = base.GetElementTextByXPath
                        (string.Format(ContentLibraryUXPageResource.
                        ContentLibraryUXPage_ActivityName_Xpath_Locator, rowCount)).Trim();
                    if (getActivityName.Contains(activityName))
                    {
                        base.FocusOnElementByXPath(string.Format(ContentLibraryUXPageResource.
                        ContentLibraryUXPage_Checkbox_Activity_XPath_Locator, rowCount));
                        IWebElement getCheckBox=base.GetWebElementPropertiesByXPath
                            (string.Format(ContentLibraryUXPageResource.
                        ContentLibraryUXPage_Checkbox_Activity_XPath_Locator, rowCount));
                        //Click on the Checkbox
                        base.ClickByJavaScriptExecutor(getCheckBox);                        
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "SelectActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks On Next Link If Activity Is Not Present
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        public void ClickOnNextLinkIfActivityNotPresent(String activityName)
        {
            //Clicks On Next Link If Activity Not Present
            logger.LogMethodEntry("ContentLibraryUXPage", "ClickOnNextLinkIfActivityNotPresent",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Initialized Variable
                string getTableText = string.Empty;
                do
                {
                    base.WaitForElement(By.Id(ContentLibraryUXPageResource.
                        ContentLibraryUXPage_Searched_Table_ID_Locator));
                    getTableText = base.GetElementTextByID(ContentLibraryUXPageResource.
                        ContentLibraryUXPage_Searched_Table_ID_Locator);
                    Thread.Sleep(Convert.ToInt32(ContentLibraryUXPageResource.
                            ContentLibraryUXPage_Search_Time_Value));
                    if (!getTableText.Contains(activityName))
                    {
                        if (base.IsElementPresent(By.Id(ContentLibraryUXPageResource.
                            ContentLibraryUXPage_Searched_Table_Next_Id_Locator),Convert.ToInt32
                            (ContentLibraryUXPageResource.ContentLibraryUX_Page_Customized_TimeOut)))
                        {
                            IWebElement getNextButton=base.GetWebElementPropertiesById
                                (ContentLibraryUXPageResource.
                                ContentLibraryUXPage_Searched_Table_Next_Id_Locator);
                            //Click on the Next
                            base.ClickByJavaScriptExecutor(getNextButton);
                            Thread.Sleep(Convert.ToInt32(ContentLibraryUXPageResource.
                                ContentLibraryUXPage_ElementLoad_Time_Value));
                            //Select Default Window
                            base.SelectDefaultWindow();
                            base.SwitchToIFrame(ContentLibraryUXPageResource.
                                ContentLibraryUX_Page_Left_Frame_ID_Locator);
                            getTableText = base.GetElementTextByID(ContentLibraryUXPageResource.
                                ContentLibraryUXPage_Searched_Table_ID_Locator);
                        }
                    }
                } while (!getTableText.Contains(activityName));
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "ClickOnNextLinkIfActivityNotPresent",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on the Activity Add Button.
        /// </summary>
        public void ClickOnActivityAddButton()
        {
            //Clicks on the Add Button
            logger.LogMethodEntry("ContentLibraryUXPage", "ClickOnActivityAddButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Selects the Default window
                base.SelectDefaultWindow();
                base.WaitForElement(By.ClassName(ContentLibraryUXPageResource.
                ContentLibraryUXPage_Add_Button_ID_Locator));
                IWebElement getAddButton = base.GetWebElementPropertiesByClassName
                    (ContentLibraryUXPageResource.
                ContentLibraryUXPage_Add_Button_ID_Locator);
                //Clicks on the Add Button
                base.ClickByJavaScriptExecutor(getAddButton);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "ClickOnActivityAddButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Course Materails Link.
        /// </summary>        
        public void ClickOnAddCourseMaterialsLink()
        {
            //Click On Add Course Materails Link
            logger.LogMethodEntry("ContentLibraryUXPage", "ClickOnAddCourseMaterialsLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element              
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
            logger.LogMethodExit("ContentLibraryUXPage", "ClickOnAddCourseMaterialsLink",
               base.isTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Select The Window Name.
        /// </summary>
        /// <param name="windowName">This is Window Name.</param>
        public void SelectTheWindowName(string windowName)
        {
            //Select The Window Name
            logger.LogMethodEntry("ContentLibraryUXPage", "SelectTheWindowName",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(windowName);
                base.SelectWindow(windowName);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "SelectTheWindowName",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select And Switch to Frame.
        /// </summary>
        /// <param name="frameAttributeValue">This is Iframe Attribute Value.</param>
        public void SelectAndSwitchtoFrame(string frameAttributeValue)
        {
            //Select And Switch to Frame
            logger.LogMethodEntry("ContentLibraryUXPage", "SelectAndSwitchtoFrame",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(frameAttributeValue));
                //Switch to Frame
                base.SwitchToIFrame(frameAttributeValue);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "SelectAndSwitchtoFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity Type.
        /// </summary>
        /// <param name="activityType">This is Activity Type.</param>
        public void ClickOnActivityType(string activityType)
        {
            //Click On Activity Type
            logger.LogMethodEntry("ContentLibraryUXPage", "ClickOnActivityType",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get Link Count
                int getLinkCount = base.GetElementCountByXPath(ContentLibraryUXPageResource.
                        ContentLibraryUX_Page_AddContentOptionCount_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_Activity_RowCount_InitialValue_AfterSearch);
                    rowCount <= getLinkCount; rowCount++)
                {
                    //Get the Name of the Link
                    string getLinkName = base.GetElementTextByXPath(string.
                        Format(ContentLibraryUXPageResource.
                        ContentLibraryUX_Page_getLinkName_Xpath_Locator, rowCount));
                    if (getLinkName == activityType)
                    {
                        //Wait for the asset link
                        base.WaitForElement(By.XPath(string.Format(ContentLibraryUXPageResource.
                        ContentLibraryUX_Page_getLinkName_Xpath_Locator, rowCount)));
                        base.FocusOnElementByXPath(string.Format(ContentLibraryUXPageResource.
                        ContentLibraryUX_Page_getLinkName_Xpath_Locator, rowCount));
                        IWebElement getAssetLink = base.GetWebElementPropertiesByXPath
                            (string.Format(ContentLibraryUXPageResource.
                        ContentLibraryUX_Page_getLinkName_Xpath_Locator, rowCount));
                        //Click on Activity type
                        base.ClickByJavaScriptExecutor(getAssetLink);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "ClickOnActivityType",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Name In Content Library
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        /// <returns>Activity Name</returns>
        public String GetActivityNameInContentLibrary(String activityName)
        {
            //Get Activity Name In Content Library
            logger.LogMethodEntry("ContentLibraryUXPage", "GetActivityNameInContentLibrary",
                base.isTakeScreenShotDuringEntryExit);
            //Variable declaration
            String getActivityName = String.Empty;
            try
            {
                //Select the Course Materials Window
                this.SelectTheWindowName(ContentLibraryUXPageResource.
                       ContentLibraryUX_Page_CourseMaterials_Window_Name);
                //Select the window
                this.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_Left_Frame_ID_Locator);
                //Search the Activity Name
                this.SearchTheActivity(activityName);
                //Select the Course Materials Window
                this.SelectTheWindowName(ContentLibraryUXPageResource.
                       ContentLibraryUX_Page_CourseMaterials_Window_Name);
                //Select the window
                this.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_Left_Frame_ID_Locator);
                getActivityName = this.GetSearchedActivity(activityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "GetActivityNameInContentLibrary",
                base.isTakeScreenShotDuringEntryExit);
            return getActivityName;
        } 
        
        /// <summary>
        /// Click On Search View Button.
        /// </summary>
        private void ClickOnSearchViewButton()
        {
            //Click On Search View Button
            logger.LogMethodEntry("ContentLibraryUXPage", "ClickOnSearchViewButton",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(ContentLibraryUXPageResource.
                ContentLibraryUXPage_Button_Search_ID_Locator));
            IWebElement getSearchViewButtonProperty = base.GetWebElementPropertiesById(
                ContentLibraryUXPageResource.ContentLibraryUXPage_Button_Search_ID_Locator);            
            //Click the Search View Button property
            base.ClickByJavaScriptExecutor(getSearchViewButtonProperty);
            logger.LogMethodExit("ContentLibraryUXPage", "ClickOnSearchViewButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Advanced Search Option.
        /// </summary>
        public void ClickAdvanceSearchOption()
        {
            //Click On Advanced Search Option
            logger.LogMethodEntry("ContentLibraryUXPage", "ClickAdvanceSearchOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(ContentLibraryUXPageResource.
                        ContentLibraryUXPage_AdvanceSearch_Button_Id_Locator));
                IWebElement getAdvancedSearchButtonProperty = base.
                    GetWebElementPropertiesById(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_AdvanceSearch_Button_Id_Locator);
                //Click the Advanced Search Button property
                base.ClickByJavaScriptExecutor(getAdvancedSearchButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "ClickAdvanceSearchOption",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Name From Course Materials Tab
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        /// <returns>Asset Name</returns>
        public String GetAssetNameFromCourseMaterialsTab(string assetName)
        {
            //Get Asset Name From Course Materials Tab
            logger.LogMethodEntry("ContentLibraryUXPage",
                "GetAssetNameFromCourseMaterialsTab",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssetName = string.Empty;
            try
            {
                //Select the Course Materials Window
                this.SelectTheWindowName(ContentLibraryUXPageResource.
                       ContentLibraryUX_Page_CourseMaterials_Window_Name);
                //Select the window
                this.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_Left_Frame_ID_Locator);
                //Get Asset Name
                getAssetName = base.GetElementTextByID(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_GetAssetName_Id_Locator);
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
            logger.LogMethodExit("ContentLibraryUXPage",
                "GetAssetNameFromCourseMaterialsTab",
            base.isTakeScreenShotDuringEntryExit);
            return getAssetName;
        }

        /// <summary>
        /// Get MyTestFolder Name In ContentLibrary.
        /// </summary>
        /// <param name="myTestFolderName">This is MyTestFolder name</param>
        /// <returns>Folder Name</returns>
        public String GetMyTestFolderNameInContentLibrary(string myTestFolderName)
        {
            //Get MyTestFolder Name In ContentLibrary
            logger.LogMethodEntry("ContentLibraryUXPage",
                "GetMyTestFolderNameInContentLibrary",
                base.isTakeScreenShotDuringEntryExit);
            //Variable declaration
            String getFolderName = String.Empty;
            try
            {
                //Select the Course Materials Window
                this.SelectTheWindowName(ContentLibraryUXPageResource.
                       ContentLibraryUX_Page_CourseMaterials_Window_Name);
                //Select the window
                this.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_Left_Frame_ID_Locator);
                //Content Library table search
                base.WaitForElement(By.Id(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_Searched_Table_ID_Locator));
                getFolderName = this.GetFolderNameInCourseMaterialsLibrary(myTestFolderName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage",
                "GetMyTestFolderNameInContentLibrary",
            base.isTakeScreenShotDuringEntryExit);
            return getFolderName;
        }

        /// <summary>
        /// Get Asset Name In Course Materials Library.
        /// </summary>
        /// <param name="myTestFolderName">This is Asset Name.</param>
        /// <returns>Folder Name</returns>
        private String GetFolderNameInCourseMaterialsLibrary(string myTestFolderName)
        {
            //Get Asset Name In Course Materials Library
            logger.LogMethodEntry("ContentLibraryUXPage", "GetFolderNameInCourseMaterialsLibrary",
                base.isTakeScreenShotDuringEntryExit);
            //Intialize the variables
            string getFolderName = string.Empty;
            //Gets the Count of Activities
            int getActivityCount = base.GetElementCountByXPath(ContentLibraryUXPageResource.
                ContentLibraryUXPage_SearchedActivityCount_XPath_Locator);
            for (int rowCount = Convert.ToInt16(ContentLibraryUXPageResource.
                ContentLibraryUXPage_Activity_Counter);
                rowCount <= getActivityCount; rowCount++)
            {
                //Wait for the element
                base.WaitForElement(By.XPath(
                    string.Format(ContentLibraryUXPageResource.
                        ContentLibraryUXPage_ActivityName_Xpath_Locator, rowCount)));
                getFolderName = base.GetElementTextByXPath
                    (string.Format(ContentLibraryUXPageResource.
                        ContentLibraryUXPage_ActivityName_Xpath_Locator, rowCount));
                if (getFolderName.Contains(myTestFolderName))
                {
                    break;
                }
            }
            logger.LogMethodExit("ContentLibraryUXPage", "GetFolderNameInCourseMaterialsLibrary",
                base.isTakeScreenShotDuringEntryExit);
            return getFolderName;
        }

        /// <summary>
        /// Get MyTest Folder Position In ContentLibrary.
        /// </summary>
        /// <param name="myTestFolderName">This is Folder Name</param>
        /// <returns>Foler Position</returns>
        public String GetMyTestFolderpositionInContentLibrary(string myTestFolderName)
        {
            //Get MyTest Folder Position In ContentLibrary
            logger.LogMethodEntry("ContentLibraryUXPage", "GetMyTestFolderpositionInContentLibrary",
                base.isTakeScreenShotDuringEntryExit);
            //Variable declaration
            int getFolderPosition = Convert.ToInt16(ContentLibraryUXPageResource.
                ContentLibraryUXPage_Activity_Counter_Int);
            try
            {
                //Select the Course Materials Window
                this.SelectTheWindowName(ContentLibraryUXPageResource.
                       ContentLibraryUX_Page_CourseMaterials_Window_Name);
                //Select the window
                this.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_Left_Frame_ID_Locator);
                //Get Folder Column Count
                getFolderPosition = this.GetMyTestFolderCount(myTestFolderName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "GetMyTestFolderpositionInContentLibrary",
            base.isTakeScreenShotDuringEntryExit);
            return getFolderPosition.ToString();
        }

        /// <summary>
        /// Get MyTest Folder Count.
        /// </summary>
        /// <param name="myTestFolderName">This is Folder Name.</param>
        /// <returns>Folder Count</returns>
        private int GetMyTestFolderCount(string myTestFolderName)
        {
            //Get MyTest Folder Count
            logger.LogMethodEntry("ContentLibraryUXPage", "GetMyTestFolderCount",
                base.isTakeScreenShotDuringEntryExit);
            //Variable declaration
            string getFolderName = string.Empty;
            //Wait for the element
            base.WaitForElement(By.XPath(ContentLibraryUXPageResource.
                ContentLibraryUXPage_SearchedActivityCount_XPath_Locator));
            //Gets the Count of Folder
            int getFolderCount = base.GetElementCountByXPath(ContentLibraryUXPageResource.
                ContentLibraryUXPage_SearchedActivityCount_XPath_Locator);
            for (int rowCount = Convert.ToInt16(ContentLibraryUXPageResource.
                ContentLibraryUXPage_Activity_Counter); rowCount <= getFolderCount; rowCount++)
            {
                //Wait for the element
                base.WaitForElement(By.XPath(string.Format(ContentLibraryUXPageResource.
                        ContentLibraryUXPage_ActivityName_Xpath_Locator, rowCount)));
                getFolderName = base.GetElementTextByXPath
                    (string.Format(ContentLibraryUXPageResource.
                        ContentLibraryUXPage_ActivityName_Xpath_Locator, rowCount));
                if (getFolderName == myTestFolderName)
                {
                    //Get the Folder count
                    getFolderCount = --rowCount;
                    break;
                }
            }
            logger.LogMethodExit("ContentLibraryUXPage", "GetMyTestFolderCount",
                base.isTakeScreenShotDuringEntryExit);
            return getFolderCount;
        }

        /// <summary>
        /// Select Cmenu Option Of Activity
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option</param>
        public void SelectCmenuOptionOfActivity(string cmenuOption)
        {
            //Select Cmenu Option Of Activity
            logger.LogMethodEntry("ContentLibraryUXPage", "SelectCmenuOptionOfActivity",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Perform Mouse Hover on Activity
                this.PerformMouseHoverOnActivty();
                //Click On Cmenu Option Of Activity
                this.ClickCmenuOptionOfActivity();
                //Click On Cmenu Options of Activity
                this.SelectTheCmenuOptionOfActivity(cmenuOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "SelectCmenuOptionOfActivity",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Peform MouseHover on Activity
        /// </summary>
        private void PerformMouseHoverOnActivty()
        {
            //Perform MouseHover on Activity
            logger.LogMethodEntry("ContentLibraryUXPage", "PerformMouseHoverOnActivty",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.ClassName(ContentLibraryUXPageResource.
                ContentLibraryUXPage_Activity_Id_Locator));
            //Get Activity property
            IWebElement getActivityProperty = base.GetWebElementPropertiesByClassName(
                ContentLibraryUXPageResource.ContentLibraryUXPage_Activity_Id_Locator);
            //Perform MouseHover On Activity
            base.PerformMouseHoverByJavaScriptExecutor(getActivityProperty);
            logger.LogMethodExit("ContentLibraryUXPage", "PerformMouseHoverOnActivty",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Option Of Activity
        /// </summary>
        private void ClickCmenuOptionOfActivity()
        {
            //Click On Cmenu Option of Activity
            logger.LogMethodEntry("ContentLibraryUXPage", "ClickCmenuOptionOfActivity",
              base.isTakeScreenShotDuringEntryExit);
              base.WaitForElement(By.ClassName(ContentLibraryUXPageResource.
                ContentLibraryUXPage_Activity_Cmenu_Id_Locator));
            //Get Cmenu property
            IWebElement getCmenuProperty = base.GetWebElementPropertiesByClassName(ContentLibraryUXPageResource.
                ContentLibraryUXPage_Activity_Cmenu_Id_Locator);
            //Click On Cmenu Option
            base.ClickByJavaScriptExecutor(getCmenuProperty);
            logger.LogMethodExit("ContentLibraryUXPage", "ClickCmenuOptionOfActivity",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Cmenu Option Of Activity
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option</param>
        private void SelectTheCmenuOptionOfActivity(string cmenuOption)
        {
            //Select Cmenu Option of Activity
            logger.LogMethodEntry("ContentLibraryUXPage", "SelectTheCmenuOptionOfActivity",
              base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(cmenuOption));
            //Get Cmenu Property
            IWebElement getCmenuOptionProperty = base.
                GetWebElementPropertiesByPartialLinkText(cmenuOption);
            //Click On Cmenu Option
            base.ClickByJavaScriptExecutor(getCmenuOptionProperty);
            logger.LogMethodExit("ContentLibraryUXPage", "SelectTheCmenuOptionOfActivity",
              base.isTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Click On The Add Course Materials Button.
        /// </summary>
        /// <param name="courseMaterialsTypeEnum">This is Course Materials Type Enum.</param>
        public void ClickOnTheAddCourseMaterialsButton(
            CourseMaterialsTypeEnum courseMaterialsTypeEnum)
        {
            //Click On The Add Course Materials Button
            logger.LogMethodEntry("ContentLibraryUXPage", "ClickOnTheAddCourseMaterialsButton",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                new CourseHomeListItemViewPage().SelectCourseHomeWindow();
                //Select the Course Materials type
                switch (courseMaterialsTypeEnum)
                {
                    case CourseMaterialsTypeEnum.ContentLibrary:
                        //Select the frame
                        this.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                            ContentLibraryUX_Page_Left_Frame_ID_Locator);
                        break;
                    case CourseMaterialsTypeEnum.CourseContent:
                        //Select the frame
                        this.SelectAndSwitchtoFrame(CourseContentUXPageResource.
                    CourseContentUXPage_Frame_Right_Id_Locator);                        
                        break;
                }
                //Click On Add Course Materials Option
                this.ClickOnAddCourseMaterialsLink();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "ClickOnTheAddCourseMaterialsButton",
              base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Get Activity Name In Add CourseMaterials.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        /// <returns>Asset Type Name.</returns>
        public String GetTheDisplayOfActivityNameInAddCourseMaterials(string assetName)
        {
            //Get Activity Name In Add CourseMaterials
            logger.LogMethodEntry("ContentLibraryUXPage",
                "GetTheDisplayOfActivityNameInAddCourseMaterials",
              base.isTakeScreenShotDuringEntryExit);
            //Initialize getActivity variable
            string getActivityName = string.Empty;
            try
            {
                //passing the parameter of activty and xpath value to get the activity name
                getActivityName = this.GetTheDisplayOfActivityName(assetName,
                    ContentLibraryUXPageResource.
                    ContentLibraryUXPage_Search_Asset_InAddCourseMaterialTable_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage",
                "GetTheDisplayOfActivityNameInAddCourseMaterials",
                base.isTakeScreenShotDuringEntryExit);
            //Return activity Name
            return getActivityName;
        }

        /// <summary>
        /// Click The Advanced Search Link In Course Materials.
        /// </summary>
        /// <param name="activityTypeEnum">This is Course Materials Type enum.</param>
        public void ClickTheAdvancedSearchLinkInCourseMaterials(
                           CourseMaterialsTypeEnum courseMaterialsTypeEnum)
        {
            //Click The Advanced Search Link In Course Materials
            logger.LogMethodEntry("ContentLibraryUXPage",
                "ClickTheAdvancedSearchLinkInCourseMaterials",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                new CourseHomeListItemViewPage().SelectCourseHomeWindow();
                //Select the Course Materials type
                switch (courseMaterialsTypeEnum)
                {
                    case CourseMaterialsTypeEnum.ContentLibrary:
                        //Select the frame
                        this.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                            ContentLibraryUX_Page_Left_Frame_ID_Locator);
                        break;
                    case CourseMaterialsTypeEnum.CourseContent:
                        //Select the frame
                        this.SelectAndSwitchtoFrame(CourseContentUXPageResource.
                    CourseContentUXPage_Frame_Right_Id_Locator); 
                        break;
                }
                //Click On Search View Button
                this.ClickOnSearchViewButton();
                //Click On Advanced Search link
                this.ClickAdvanceSearchOption();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }         
            logger.LogMethodExit("ContentLibraryUXPage",
                "ClickTheAdvancedSearchLinkInCourseMaterials",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Display Of Asset Type In Advanced Search Popup.
        /// </summary>
        /// <param name="assetName">This is Asset Type.</param>
        /// <returns>Asset Type.</returns>
        public String GetTheDisplayOfAssetTypeInAdvancedSearchPopup(string assetName)
        {
            //Get The Display Of Asset Type In Advanced Search Popup
            logger.LogMethodEntry("ContentLibraryUXPage",
                "GetTheDisplayOfAssetTypeInAdvancedSearchPopup",
              base.isTakeScreenShotDuringEntryExit);
            //Declaration of object
            AdvancedSearchPage advancedSearchPage = new AdvancedSearchPage();
            //Initialize getActivityText variable
            string getActivityName = string.Empty;
            try
            {
                //Select the window
                new CourseHomeListItemViewPage().SelectCourseHomeWindow();
                //Select Advanced Search Popoup Frame
                advancedSearchPage.SelectAdvanceSearchFrame();
                //passing the parameter of activty and xpath value to get the activity name
                getActivityName = this.GetTheDisplayOfActivityName(assetName,
                    ContentLibraryUXPageResource.
                    ContentLibraryUXPage_AdvancedSearch_Popup_AssetDisplay_XPath_Locator);
                // Click On Advanced Search Close Button.
                advancedSearchPage.ClickOnAdvancedSearchCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage",
                "GetTheDisplayOfAssetTypeInAdvancedSearchPopup",
                base.isTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Get Display Of Activity Name.
        /// </summary>
        /// <param name="assetType">This AssetType Name.</param>
        /// <param name="attributeValue">Attribute Xpath Value.</param>
        /// <returns>AssetType Name.</returns>
        public String GetTheDisplayOfActivityName(string assetType, string attributeValue)
        {
            //Get Display Of Activity Name 
            logger.LogMethodEntry("ContentLibraryUXPage", "GetTheDisplayOfActivityName",
                    base.isTakeScreenShotDuringEntryExit);
            //Initialize getActivityText variable
            string getAssetName = string.Empty;
            string getTextofElement = string.Empty;
            try
            {
                //Wait for the element
                base.WaitForElement(By.XPath(attributeValue));
                //Get Text of Element
                getTextofElement = base.GetElementTextByXPath(attributeValue);
                //Match the Asset text
                if (getTextofElement.Contains(assetType))
                {
                    //Get Asset Name
                    getAssetName = assetType;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "GetTheDisplayOfActivityName",
                   base.isTakeScreenShotDuringEntryExit);
            return getAssetName;
        }
      
        /// <summary>
        /// Search The Activity Name In Course Materials.
        /// </summary>
        /// <param name="courseMaterialsTypeEnum">This is Activity Type Enum.</param>
        /// <param name="activity">This is Activity Name.</param>
        public void SearchTheActivityNameInCourseMaterials(
            CourseMaterialsTypeEnum courseMaterialsTypeEnum, string activity)
        {
            //Search The Activity Name In Course Materials
            logger.LogMethodEntry("ContentLibraryUXPage", 
                "SearchTheActivityNameInCourseMaterials",
                    base.isTakeScreenShotDuringEntryExit);
            //Select the window
            new CourseHomeListItemViewPage().SelectCourseHomeWindow(); 
            //Select the Course Materials type
            switch (courseMaterialsTypeEnum)
            {
                case CourseMaterialsTypeEnum.ContentLibrary:
                    //Select the frame
                    this.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                        ContentLibraryUX_Page_Left_Frame_ID_Locator);
                    break;
                case CourseMaterialsTypeEnum.CourseContent:
                    //Select the frame
                    this.SelectAndSwitchtoFrame(CourseContentUXPageResource.
                CourseContentUXPage_Frame_Right_Id_Locator);
                    break;
            }
            //Search the Activity Name
            this.SearchTheActivity(activity);
            logger.LogMethodExit("ContentLibraryUXPage",
                "SearchTheActivityNameInCourseMaterials",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Asset Name From Course Materials Tab.
        /// <param name="courseMaterialsTypeEnum">This is Course Materials Type.</param>
        /// <param name="assetName">This is Activity Name.</param>
        /// <returns>Activity Name.</returns>
        public String GetActivityNameInCourseMaterialsTab(
            CourseMaterialsTypeEnum courseMaterialsTypeEnum, string assetName)
        {
            //Get Asset Name From Course Materials Tab
            logger.LogMethodEntry("ContentLibraryUXPage","GetAssetNameFromCourseMaterialsTab",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssetName = string.Empty;
            try
            {                
                //Select the window
                new CourseHomeListItemViewPage().SelectCourseHomeWindow();
                //Select the Course Materials type
                switch (courseMaterialsTypeEnum)
                {
                    case CourseMaterialsTypeEnum.ContentLibrary:
                        //Switch to Frame and Get Asset Name In Content Library
                        getAssetName =
                            this.SwitchtoFrameandGetAssetNameInContentLibrary(getAssetName);
                        //Click On Clear Results Link
                        this.ClickOnClearResults();
                        break;
                    case CourseMaterialsTypeEnum.CourseContent:
                        //Switch to Frame and Get Asset Name In Course Content
                        getAssetName =
                            this.SwitchtoFrameandGetAssetNameInCourseContent(getAssetName);
                        //Click On Clear Results Link
                        this.ClickOnClearResults();
                        break;
                }                
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
            logger.LogMethodExit("ContentLibraryUXPage","GetAssetNameFromCourseMaterialsTab",
            base.isTakeScreenShotDuringEntryExit);
            return getAssetName;
        }

        /// <summary>
        /// Switch to Frame and Get Asset Name In Course Content.
        /// </summary>
        /// <param name="getAssetName">This is Asset Name.</param>
        /// <returns>Asset Name.</returns>
        private string SwitchtoFrameandGetAssetNameInCourseContent(string getAssetName)
        {
            //Switch to Frame and Get Asset Name In Course Content
            logger.LogMethodEntry("ContentLibraryUXPage",
                "SwitchtoFrameandGetAssetNameInCourseContent",
               base.isTakeScreenShotDuringEntryExit);
            //Select the frame
            this.SelectAndSwitchtoFrame(CourseContentUXPageResource.
          CourseContentUXPage_Frame_Right_Id_Locator);
            //Get Asset Name
            getAssetName = base.GetElementTextByID(ContentLibraryUXPageResource.
                ContentLibraryUXPage_SearchedContent_Table_Id_Locator);            
            logger.LogMethodExit("ContentLibraryUXPage",
                "SwitchtoFrameandGetAssetNameInCourseContent",
            base.isTakeScreenShotDuringEntryExit);
            return getAssetName;
        }

        /// <summary>
        /// Click On Clear Results Link.
        /// </summary>
        private void ClickOnClearResults()
        {
            //Click On Clear Results Link
            logger.LogMethodEntry("ContentLibraryUXPage",
                "ClickOnClearResults",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ContentLibraryUXPageResource.
                ContentLibraryUXPage_ClearResults_Id_Locator));
            //Click on Clear Results
            IWebElement getClearResultsElement =
                base.GetWebElementPropertiesById(ContentLibraryUXPageResource.
                ContentLibraryUXPage_ClearResults_Id_Locator);
            base.ClickByJavaScriptExecutor(getClearResultsElement);
            Thread.Sleep(Convert.ToInt32(ContentLibraryUXPageResource.
                ContentLibraryUXPage_ElementLoad_Time_Value));
            logger.LogMethodExit("ContentLibraryUXPage",
                "ClickOnClearResults",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to Frame and Get Asset Name In Content Library.
        /// </summary>
        /// <param name="getAssetName">This is Asset Name.</param>
        /// <returns>Asset Name.</returns>
        private string SwitchtoFrameandGetAssetNameInContentLibrary(string getAssetName)
        {
            //Switch to Frame and Get Asset Name In Content Library
            logger.LogMethodEntry("ContentLibraryUXPage",
                "SwitchtoFrameandGetAssetNameInContentLibrary",
               base.isTakeScreenShotDuringEntryExit);
            //Select the frame
            this.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                ContentLibraryUX_Page_Left_Frame_ID_Locator);
            //Get Asset Name
            getAssetName = base.GetElementTextByID(ContentLibraryUXPageResource.
                ContentLibraryUXPage_GetAssetName_Id_Locator);           
            logger.LogMethodExit("ContentLibraryUXPage",
                "SwitchtoFrameandGetAssetNameInContentLibrary",
            base.isTakeScreenShotDuringEntryExit);
            return getAssetName;
        }

        /// <summary>
        /// Create NonGradable Activity In Content library.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        public void CreateNonGradableActivityInContentlibrary(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Create NonGradable Activity In Content library
            logger.LogMethodEntry("ContentLibraryUXPage",
                "CreateNonGradableActivityInContentlibrary",
                      base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (activityTypeEnum)
                {                    
                    case Activity.ActivityTypeEnum.File:
                        //Create File Asset
                        new UploadFilePage().CreateFileAsset(activityTypeEnum);
                        break;
                    case Activity.ActivityTypeEnum.Page:
                        //Creation of page
                        new PegasusHTMLUXPage().CreatePageAsset(activityTypeEnum);
                        break;
                    case Activity.ActivityTypeEnum.Link:
                        //Creation of page
                        new AddUrlPage().CreateLinkAsset(activityTypeEnum);
                        break;
                    case Activity.ActivityTypeEnum.DiscussionTopic:
                        //Create Discussion Topic 
                        new AddDiscussionTopicPage().
                            CreateDiscussionTopicAsset(activityTypeEnum);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage",
                "CreateNonGradableActivityInContentlibrary",
                     base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Search View Option.
        /// </summary>
        /// <param name="courseMaterialsTypeEnum">This is Course Materials Type Enum.</param>
        public void ClickOnSearchViewOption(CourseMaterialsTypeEnum courseMaterialsTypeEnum)
        {
            //Click On Search View Option
            logger.LogMethodEntry("ContentLibraryUXPage", "ClickOnSearchViewOption",
                    base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Refersh the Current Page
                base.RefreshTheCurrentPage();
                //Select the Course Materials Window
                this.SelectTheWindowName(ContentLibraryUXPageResource.
                       ContentLibraryUX_Page_CourseMaterials_Window_Name);
                //Select the Course Materials type
                switch (courseMaterialsTypeEnum)
                {
                    case CourseMaterialsTypeEnum.ContentLibrary:
                        //Select the frame
                        this.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                            ContentLibraryUX_Page_Left_Frame_ID_Locator);
                        break;
                    case CourseMaterialsTypeEnum.CourseContent:
                        //Select the frame
                        this.SelectAndSwitchtoFrame(CourseContentUXPageResource.
                    CourseContentUXPage_Frame_Right_Id_Locator);
                        break;
                }
                //Click On Search View Button
                this.ClickOnSearchViewButton();
                //Click on Advanced search option
                this.ClickAdvanceSearchOption();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage","ClickOnSearchViewOption",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Asset Name By Advanced Search Option.
        /// </summary>
        /// <param name="courseMaterialsTypeEnum">This is Course Materials Type Enum.</param>
        /// <param name="activityName">This is Activity Name.</param>
        public void SearchAssetNameByAdvancedSearchOption(
            CourseMaterialsTypeEnum courseMaterialsTypeEnum, string activityName)
        {
            //Search Asset Name By Advanced Search Option
            logger.LogMethodEntry("ContentLibraryUXPage", 
                "SearchAssetNameByAdvancedSearchOption",
                    base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Course Materials Window
                this.SelectTheWindowName(ContentLibraryUXPageResource.
                       ContentLibraryUX_Page_CourseMaterials_Window_Name);
                new AdvancedSearchPage().
                    FillAssetNameInTextBoxAndClickSearchButton(activityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage",
                "SearchAssetNameByAdvancedSearchOption",
                   base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select Left Frame In Content Window.
        /// </summary>
        public void SelectLeftFrame() {
    
             //Wait for the Content Library Frame
                base.WaitForElement(By.Id(ContentLibraryUXPageResource.
                        ContentLibraryUX_Page_Left_Frame_ID_Locator));
                base.SwitchToIFrame(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_Left_Frame_ID_Locator);
    }

        /// <summary>
        /// Select and swith to content library frame
        /// </summary>
        public void SelectAndSwitchToContentLibrary()
        {
            logger.LogMethodEntry("ContentLibraryUXPage", "SelectAndSwitchToContentLibrary",
                base.isTakeScreenShotDuringEntryExit);

            this.SelectTheWindowName(ContentLibraryUXPageResource.
                ContentLibraryUX_Page_CourseMaterials_Window_Name);            
            this.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                ContentLibraryUX_Page_Left_Frame_ID_Locator);

            logger.LogMethodExit("ContentLibraryUXPage", "SelectAndSwitchToContentLibrary",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Expnads the Advanced options on Content Library
        /// </summary>
        public void ExpandAdvancedOptions()
        {
            logger.LogMethodEntry("ContentLibraryUXPage", "ExpandAdvancedOptions",
                base.isTakeScreenShotDuringEntryExit);
            try
            {                                          
                base.WaitForElement(By.ClassName(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_AdvancedOptions_Link_Class_Locator));                
                IWebElement advancedOptionsLink = base.GetWebElementPropertiesByClassName(
                    ContentLibraryUXPageResource.
                    ContentLibraryUXPage_AdvancedOptions_Link_Class_Locator);
                
                base.ClickByJavaScriptExecutor(advancedOptionsLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryUXPage", "ExpandAdvancedOptions",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects check boxes in assets item listed in Content library.
        /// </summary>
        /// <param name="assetCount">Number of assets to be selected.</param>
        public void SelectCheckboxOfAssets(int assetCount)
        {
            logger.LogMethodEntry("ContentLibraryUXPage", 
                "SelectCheckboxOfAssets",
                base.isTakeScreenShotDuringEntryExit);

            if (assetCount <= 0) return;
            Thread.Sleep(Convert.ToInt32(ContentLibraryUXPageResource
                .ContentLibraryUXPage_AdvancedOptions_ItemReady_Wait_Value));
            ICollection<IWebElement> assetCheckBoxs = base.GetWebElementsCollectionById(
                ContentLibraryUXPageResource
                .ContentLibraryUX_Page_Asset_Checkbox_ID_Locator);
            int counter = 0;
            foreach(IWebElement assetCheckBox in assetCheckBoxs)
            {
                
                base.ClickByJavaScriptExecutor(assetCheckBox);
                ++counter;
                if (counter >= assetCount-1) break;
            }

            logger.LogMethodExit("ContentLibraryUXPage", 
                "SelectCheckboxOfAssets",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Is button on header enabled or not.
        /// </summary>
        /// <param name="buttonType">Type of header button.</param>
        /// <returns></returns>
        public bool IsButtonEnabledOnHeader(AdvancedOptionsButtonType buttonType)
        {
            logger.LogMethodEntry("ContentLibraryUXPage", 
                "IsButtonEnabledOnHeader",
                base.isTakeScreenShotDuringEntryExit);

            string buttonID = this.GetButtonIDOnHeaderByButtonType(buttonType);
            if (buttonID == null) return false;
            return base.IsElementEnabledByID(buttonID); 
        }

        /// <summary>
        /// Clicks button on the header.
        /// </summary>
        /// <param name="buttonType">Type of header button.</param>
        public void ClickButtonOnHeader(AdvancedOptionsButtonType buttonType)
        {
            logger.LogMethodEntry("ContentLibraryUXPage", 
                "ClickButtonOnHeader",
                base.isTakeScreenShotDuringEntryExit);

            string buttonID = this.GetButtonIDOnHeaderByButtonType(buttonType);
            this.ClickButtonByID(buttonID);
            logger.LogMethodExit("ContentLibraryUXPage", 
                "ClickButtonOnHeader",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Gets the ID attribute value of button on the header by button type.
        /// </summary>
        /// <param name="buttonType">Type of header button.</param>
        /// <returns>ID attribute value of the button</returns>
        private string GetButtonIDOnHeaderByButtonType(AdvancedOptionsButtonType buttonType)
        {
            string buttonID;
            switch (buttonType)
            {
                case AdvancedOptionsButtonType.Copy:
                    buttonID = ContentLibraryUXPageResource
                        .ContentLibraryUXPage_AdvancedOptions_Copy_Link_ID_Locator;
                    break;
                case AdvancedOptionsButtonType.Cut:
                    buttonID = ContentLibraryUXPageResource
                        .ContentLibraryUXPage_AdvancedOptions_Cut_Link_ID_Locator;
                    break;
                case AdvancedOptionsButtonType.Paste:
                    buttonID = ContentLibraryUXPageResource
                        .ContentLibraryUXPage_AdvancedOptions_Paste_Link_ID_Locator;
                    break;
                case AdvancedOptionsButtonType.Delete:
                    buttonID = ContentLibraryUXPageResource
                        .ContentLibraryUXPage_AdvancedOptions_Delete_Link_ID_Locator;
                    break;
                default:
                    return null;
            }
            return buttonID;
        }

        /// <summary>
        /// Getsitems count displayed on Clipboard division.
        /// </summary>
        /// <returns>Count of Clipboard item.</returns>
        public int GetClipboardItemsCount()
        {
            logger.LogMethodEntry("ContentLibraryUXPage", 
                "GetClipboardItemsCount",
                base.isTakeScreenShotDuringEntryExit);

            int itemCount = 0;
            int.TryParse(base.GetElementTextByID(ContentLibraryUXPageResource
                .ContentLibraryUXPage_AdvancedOptions_ClipBoard_Count_Span_ID_Locator)
                , out itemCount);

            logger.LogMethodExit("ContentLibraryUXPage", 
                "GetClipboardItemsCount",
               base.isTakeScreenShotDuringEntryExit);
            return itemCount;
        }

        /// <summary>
        /// Gets the count of assets by color and style.
        /// </summary>
        /// <param name="titleColor">Color</param>
        /// <param name="fontStyle">Style i.e. Italic.</param>
        /// <returns>Count of the assets</returns>
        public int GetCountOfAssetTitleByColorAndFontStyle(
            string titleColor, string fontStyle)
        {
            logger.LogMethodEntry("ContentLibraryUXPage", 
                "GetCountOfAssetTitleByColorAndFontStyle",
                base.isTakeScreenShotDuringEntryExit);

            ICollection<IWebElement> clipBoardAssets = base
                .GetWebElementsCollectionByClassName(ContentLibraryUXPageResource
                .ContentLibraryUXPage_AdvancedOptions_ClipboardAsset_Link_Class_Locator);
            if (clipBoardAssets == null) 
                return 0;
            logger.LogMethodExit("ContentLibraryUXPage", 
                "GetCountOfAssetTitleByColorAndFontStyle",
               base.isTakeScreenShotDuringEntryExit);
            return clipBoardAssets.Count;            
        }

        /// <summary>
        /// Selects paste option.
        /// </summary>
        /// <param name="option">Paste option type.</param>
        public void SelectPasteOption(PasteOptions option)
        {
            logger.LogMethodEntry("ContentLibraryUXPage",
                "SelectPasteOption",
                base.isTakeScreenShotDuringEntryExit);
            string optionButtonID = string.Empty;
            switch (option)
            {
                case PasteOptions.PasteAtTop:
                    optionButtonID = ContentLibraryUXPageResource
                        .ContentLibraryUXPage_PasteOptions_Top_TD_ID_Locator;
                    break;
                case PasteOptions.PasteBeforeSelected:
                    optionButtonID = ContentLibraryUXPageResource
                        .ContentLibraryUXPage_PasteOptions_BeforeSelected_TD_ID_Locator;
                    break;
                case PasteOptions.PasteAfterSelected:
                    optionButtonID = ContentLibraryUXPageResource
                        .ContentLibraryUXPage_PasteOptions_AfterSelected_TD_ID_Locator;
                    break;
                case PasteOptions.PasteAtBottom:
                    optionButtonID = ContentLibraryUXPageResource
                        .ContentLibraryUXPage_PasteOptions_Bottom_TD_ID_Locator;
                    break;
            }
            this.ClickButtonByID(optionButtonID);

            logger.LogMethodExit("ContentLibraryUXPage",
                "SelectPasteOption",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks the button by its ID attribute.
        /// </summary>
        /// <param name="buttonID">ID attribute of the button.</param>
        private void ClickButtonByID(string buttonID)
        {
            if (buttonID != null)
            {
                base.WaitForElement(By.Id(buttonID));
                IWebElement headerButton = base
                    .GetWebElementPropertiesById(buttonID);
                base.ClickByJavaScriptExecutor(headerButton);
            }
        }

    }
}
