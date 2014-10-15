using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeacherSharedLibrary;
using OpenQA.Selenium.Interactions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Custom Content Page Actions
    /// </summary>
    public class CustomContentPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(CustomContentPage));

        /// <summary>
        /// Click On Expand Button of ML In Custom Content View
        /// </summary>
        public void ClickOnExpandButtonofMLInCustomContentView()
        {
            //Click On Expand Button of ML In Custom Content View
            logger.LogMethodEntry("CustomContentPage",
                "ClickOnExpandButtonofMLInCustomContentView",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Frame
                this.SelectCurriculumFrame();
                base.WaitForElement(By.XPath(CustomContentPageResource.
                    CustomContent_Page_ExpandButton_Xpath_Locator));
                //Focus on Expand Button
                base.FocusOnElementByXPath(CustomContentPageResource.
                    CustomContent_Page_ExpandButton_Xpath_Locator);
                //Click on Expand Button              
                IWebElement getExpandButton = base.
                    GetWebElementPropertiesByXPath(CustomContentPageResource.
                    CustomContent_Page_ExpandButton_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getExpandButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage",
                "ClickOnExpandButtonofMLInCustomContentView",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Master Library
        /// </summary>
        /// <returns>This is ML Name</returns>
        public string GetMasterLibraryName()
        {
            //Get Master Library
            logger.LogMethodEntry("CustomContentPage", "GetMasterLibraryName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getMLName = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(CustomContentPageResource.
                    CustomContent_Page_Window_Title_Name);
                ////Select Window
                base.SelectWindow(CustomContentPageResource.
                    CustomContent_Page_Window_Title_Name);
                //Switch to Frame
                base.WaitForElement(By.Id(CustomContentPageResource.
                    CustomContent_Page_Frame_Id_Locator));
                base.SwitchToIFrame(CustomContentPageResource.
                    CustomContent_Page_Frame_Id_Locator);
                base.WaitForElement(By.Id(CustomContentPageResource.
                    CustomContent_Page_MLName_Id_Locator));
                //Get ML Name From Application
                getMLName = base.GetElementTextById(CustomContentPageResource.
                    CustomContent_Page_MLName_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage", "GetMasterLibraryName",
                base.IsTakeScreenShotDuringEntryExit);
            return getMLName;
        }

        /// <summary>
        /// Get Customized Content Name.
        /// </summary>
        /// <returns>This is Customized Content Name.</returns>
        public string GetCustomizedContentName(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Get Customized Content Name
            logger.LogMethodEntry("CustomContentPage", "GetCustomizedContentName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getActivityTitle = string.Empty;
            try
            {
                //Switch to Frame
                this.SwitchToCurriculumFrame();
                base.WaitForElement(By.Id(CustomContentPageResource.
                    CustomContent_Page_CustomizedContentName_Id_Locator));
                //Purpose : Search Activity based on the Activity Type Enum
                this.SearchTheAsset(activityTypeEnum);
                //Switch to Frame
                this.SwitchToCurriculumFrame();
                //Wait for searched activity row 
                base.WaitForElement(By.Id(CustomContentPageResource.
                    CustomContent_Page_Searched_Activity_Div_ID_Locator));
                //Get Customized Content Name 
                getActivityTitle = base.GetInnerTextAttributeValueById(
                    CustomContentPageResource.
                    CustomContent_Page_Searched_Activity_Div_ID_Locator);
                //Select default page
                base.SelectDefaultWindow();
                //Refresh The page
                base.RefreshTheCurrentPage();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage", "GetCustomizedContentName",
                base.IsTakeScreenShotDuringEntryExit);            
            return getActivityTitle.TrimEnd();
        }

        /// <summary>
        /// Search The Asset.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        private void SearchTheAsset(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Search The Asset
            logger.LogMethodEntry("CustomContentPage", "SearchTheAsset",
                base.IsTakeScreenShotDuringEntryExit);
            switch (activityTypeEnum)
            {
                case Activity.ActivityTypeEnum.Test:
                    //Get activity from In-Memory
                    Activity activity = Activity.Get(CommonResource.CommonResource.
                        DigitalPath_Activity_TestData_UC1);
                    //Search activity name 
                    new ContentLibraryPage().SearchActivity(activity.Name);
                    break;
                case Activity.ActivityTypeEnum.SkillStudyPlan:
                    Activity skillStudyPlan = Activity.Get(CommonResource.CommonResource.
                       DigitalPath_Activity_SkillStudyPlan_UC1);
                    //Search activity name 
                    new ContentLibraryPage().SearchActivity(skillStudyPlan.Name);
                    break;
            }
            logger.LogMethodExit("CustomContentPage", "SearchTheAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch To Curriculum Frame.
        /// </summary>
        private void SwitchToCurriculumFrame()
        {
            //Switch To Curriculum Frame.
            logger.LogMethodEntry("CustomContentPage", "SwitchToCurriculumFrame",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(CustomContentPageResource.
                CustomContent_Page_Window_Title_Name);
            //Select Window
            base.SelectWindow(CustomContentPageResource.
                CustomContent_Page_Window_Title_Name);
            //Switch to Frame
            base.WaitForElement(By.Id(CustomContentPageResource.
                CustomContent_Page_Frame_Id_Locator));
            base.SwitchToIFrame(CustomContentPageResource.
                CustomContent_Page_Frame_Id_Locator);
            logger.LogMethodExit("CustomContentPage", "SwitchToCurriculumFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Master library course
        /// </summary>
        /// <param name="masterLibraryCourse">This is MasterLibrary course</param>
        /// <returns>Master library Course</returns>
        public string GetTheMasterLibraryCourse(string masterLibraryCourse)
        {
            // Get the Master library course
            logger.LogMethodEntry("CustomContentPage", "GetTheMasterLibraryCourse",
                 base.IsTakeScreenShotDuringEntryExit);
            //Variable Declaration of Master Library course         
            string getMasterLibraryName = string.Empty;
            try
            {
                //Select the frame
                this.SelectCurriculumFrame();
                //Getting the counts of Master Library course                
                int getCourseCount = base.GetElementCountByXPath(CustomContentPageResource.
                    CustomContent_Page_MasterLibrary_Count_Xpath_Locator);
                for (int setRowCount = 1; setRowCount <= getCourseCount; setRowCount++)
                {
                    //Getting the Master Library name text
                    getMasterLibraryName = base.GetElementTextByXPath
                        (string.Format(CustomContentPageResource.
                     CustomContent_Page_MasterLibrary_Name_Xpath_Locator, setRowCount));
                    if (getMasterLibraryName == masterLibraryCourse)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage", "GetTheMasterLibraryCourse",
                base.IsTakeScreenShotDuringEntryExit);
            return getMasterLibraryName;
        }

        /// <summary>
        /// Select the Curriculum Frame
        /// </summary>
        public void SelectCurriculumFrame()
        {
            //Select the Curriculum Frame
            logger.LogMethodEntry("CustomContentPage", "SelectCurriculumFrame",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitUntilWindowLoads(CustomContentPageResource.
                       CustomContent_Page_Window_Title_Name);
                base.WaitUntilWindowLoads(CustomContentPageResource.
                       CustomContent_Page_Window_Title_Name);
                ////Select Window
                base.SelectWindow(CustomContentPageResource.
                    CustomContent_Page_Window_Title_Name);
                //Switch to Frame            
                base.SwitchToIFrame(CustomContentPageResource.
                    CustomContent_Page_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage", "SelectCurriculumFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Mouse over on the Row of Master Library course
        /// </summary>       
        public void MouseOverOnRowMLCourse()
        {
            //Mouse over on the Row of Master Library course
            logger.LogMethodEntry("CustomContentPage",
                "MouseOverOnRowMLCourse",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the Master Library course from memory 
                Course newCourse = Course.Get(Course.CourseTypeEnum.MasterLibrary);             
                //Mouse over on the licensed master library coures        
                this.MouseOverOnLicensedMasterLibraryCourse(newCourse.Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage",
                "MouseOverOnRowMLCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Mouse over on the licensed Master Library course
        /// </summary>
        /// <param name="masterLibraryCourse">This is Master Library course</param>
        private void MouseOverOnLicensedMasterLibraryCourse(string masterLibraryCourse)
        {
            //Mouse over on the licensed Master Library course
            logger.LogMethodEntry("CustomContentPage",
                "MouseOverOnLicensedMasterLibraryCourse",
                 base.IsTakeScreenShotDuringEntryExit);
            //Select the frame
            this.SelectCurriculumFrame();
            //Getting the counts of Master Library course                
            int getCourseCount = base.GetElementCountByXPath(CustomContentPageResource.
                CustomContent_Page_MasterLibrary_Count_Xpath_Locator);
            for (int setRowCount = 1; setRowCount <= getCourseCount; setRowCount++)
            {
                //Getting the Master Library name text
                string getMasterLibrary = base.GetElementTextByXPath
                     (string.Format(CustomContentPageResource.
                  CustomContent_Page_MasterLibrary_Name_Xpath_Locator, setRowCount));
                if (getMasterLibrary == masterLibraryCourse)
                {
                    //Perform Mouse hover on Master Library course
                    this.PerformMouseHoverOnMLCourse();
                    break;
                }
                logger.LogMethodExit("CustomContentPage",
                    "MouseOverOnLicensedMasterLibraryCourse",
                    base.IsTakeScreenShotDuringEntryExit);
            }
        }

        /// <summary>
        /// Perform Mouse Hover On Master Library Course
        /// </summary>
        private void PerformMouseHoverOnMLCourse()
        {
            //Perform Mouse Hover On Master Library Course
            logger.LogMethodEntry("CustomContentPage",
                "PerformMouseHoverOnMLCourse",
                 base.IsTakeScreenShotDuringEntryExit);
            //Get the web element
            IWebElement getMLCourseTitleAttribute =
                base.GetWebElementPropertiesByClassName
                (CustomContentPageResource.
                CustomContent_Page_MasterLibrary_ClassName_Locator);
            //Perform mouse over action
            base.PerformMouseHoverByJavaScriptExecutor(getMLCourseTitleAttribute);            
            Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
                 CustomContent_Page_CustonContent_ButtonClick_Time_value));
            //Click on the "Create Content" Button on row
            this.ClickTheCreateContentButtonOnRow();
            //Select the content menu
            this.SelectTheContentMenu();
            logger.LogMethodExit("CustomContentPage",
                "PerformMouseHoverOnMLCourse",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the "Create Content" Button on row
        /// </summary>
        public void ClickTheCreateContentButtonOnRow()
        {
            //Click on the "Create Content" Button on row
            logger.LogMethodEntry("CustomContentPage",
                "ClickTheCreateContentButtonOnRow",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.XPath(CustomContentPageResource.
                   CustomContent_Page_CreateContent_Button_Xpath_Locator));
                base.FillEmptyTextByXPath(CustomContentPageResource.
                   CustomContent_Page_CreateContent_Button_Xpath_Locator);
                //Get the web element
                IWebElement clickButton = base.GetWebElementPropertiesByXPath
                    (CustomContentPageResource.
                   CustomContent_Page_CreateContent_Button_Xpath_Locator);
                //Click the "Create Content" button
                base.ClickByJavaScriptExecutor(clickButton);
                Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
            CustomContent_Page_CustonContent_ButtonClick_Time_value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage",
                "ClickTheCreateContentButtonOnRow",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Conten Menu
        /// </summary>
        public void SelectTheContentMenu()
        {
            //Select the Conten Menu
            logger.LogMethodEntry("CustomContentPage", "SelectContentMenu",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(CustomContentPageResource.
                    CustomContent_Page_SelectContentMenu_Id_Locator));
                base.FocusOnElementById(CustomContentPageResource.
                    CustomContent_Page_SelectContentMenu_Id_Locator);
                //Focus on "Test" text
                base.FocusOnElementByXPath(CustomContentPageResource.
                    CustomContent_Page_SelectContent_Test_Name_Text);
                IWebElement getSelectContent =
                    base.GetWebElementPropertiesByXPath(CustomContentPageResource.
                    CustomContent_Page_SelectContent_Test_Name_Text);
                //Click on the "Test" link
                base.ClickByJavaScriptExecutor(getSelectContent);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage", "SelectContentMenu",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select  Licensed Checkbox 
        /// </summary>
        private void SelectLicencedCheckBox()
        {
            //Select Licensed Checkbox 
            logger.LogMethodEntry("CustomContentPage", "SelectLicencedCheckBox",
                 base.IsTakeScreenShotDuringEntryExit);          
                //Wait for the element
                base.WaitForElement(By.XPath(CustomContentPageResource.
                    CustomContent_Page_Activity_Checkbox_Xpath_Locator));
                base.FocusOnElementByXPath(CustomContentPageResource.
                    CustomContent_Page_Activity_Checkbox_Xpath_Locator);
                //Click on the check box
                base.SelectCheckBoxByXPath(CustomContentPageResource.
                    CustomContent_Page_Activity_Checkbox_Xpath_Locator);          
            logger.LogMethodExit("CustomContentPage", "SelectLicencedCheckBox",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Copy Link
        /// </summary>
        private void ClickTheCopyLink()
        {
            //Click The Copy Link
            logger.LogMethodEntry("CustomContentPage", "ClickTheCopyLink",
                 base.IsTakeScreenShotDuringEntryExit);           
                //Wait for the element
                base.WaitForElement(By.Id(CustomContentPageResource.
                      CustomContent_Page_Copy_Id_Locator));
                base.FocusOnElementById(CustomContentPageResource.
                      CustomContent_Page_Copy_Id_Locator);
                //Click on the "Copy" link
                base.ClickButtonById(CustomContentPageResource.
                    CustomContent_Page_Copy_Id_Locator);           
            logger.LogMethodExit("CustomContentPage", "ClickTheCopyLink",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Mouse Over On Licensed Action Row Assets
        /// </summary>
        private void MouseOverOnLicensedActionRowAssets()
        {
            //Mouse Over On Licensed Action Row Assets
            logger.LogMethodEntry("CustomContentPage",
                "MouseOverOnLicensedActionRowAssets",
                 base.IsTakeScreenShotDuringEntryExit);           
                //Get the Activity from memory           
                Activity newActivity = Activity.Get(CommonResource.      
                   CommonResource.DigitalPath_Activity_Test_UC2);
                //Select The Licensed Activity Test     
                this.SelectTheLicensedActivityTest(newActivity.Name);
                     //MouseOver On Licensed Assets row
                     this.MouseOverOnLicensedAssetsRow();
                     //Select The Paste Button For Licensed Asset
                     this.SelectThePasteButtonForLicensedAsset();
                     Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
                      CustomContent_Page_CustonContent_ButtonClick_Time_value));            
            logger.LogMethodExit("CustomContentPage",
                "MouseOverOnLicensedActionRowAssets",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select The Licensed Activity Test
        /// </summary>
        /// <param name="activityName">This is activity name</param>
        private void SelectTheLicensedActivityTest(string activityName)
        {
            //Select The Licensed Activity Test
            logger.LogMethodEntry("CustomContentPage",
                "SelectTheLicensedActivityTest",
                 base.IsTakeScreenShotDuringEntryExit);
            //Getting the counts of Activity
            int getActivityCount = base.
                GetElementCountByXPath(CustomContentPageResource.
                CustomContent_Page_Activity_Count_Xpath_Locator);
            for (int setRowCount = 1; setRowCount <= getActivityCount; setRowCount++)
            {
                //Get the Activity  Name Text
                string getActivityTest = base.GetElementTextByXPath
                    (string.Format(CustomContentPageResource.
                    CustomContent_Page_Activity_Name_Xpath_Locator, setRowCount));
                if (getActivityTest == activityName)
                {                                     
                    break;
                }
                logger.LogMethodExit("CustomContentPage",
                    "SelectTheLicensedActivityTest",
                       base.IsTakeScreenShotDuringEntryExit);
            }
        }      
       
        /// <summary>
        /// MouseOver On Licensed Assets row
        /// </summary>
        private void MouseOverOnLicensedAssetsRow()
        {
            //MouseOver On Licensed Assets row
            logger.LogMethodEntry("CustomContentPage",
                "MouseOverOnLicensedAssetsRow",
              base.IsTakeScreenShotDuringEntryExit);         
            //Wait for the element
            base.WaitForElement(By.XPath(CustomContentPageResource.
                CustomContent_Page_Activity_Name_Checkbox_Xpath_Locator));
            //Get the web element of asset row 
            IWebElement getTitleAttribute = base.
                GetWebElementPropertiesByXPath(CustomContentPageResource.
                CustomContent_Page_Activity_Name_Checkbox_Xpath_Locator);
            //Perform mouse over action on asset to make paste button visible
            base.PerformMouseHoverByJavaScriptExecutor(getTitleAttribute);            
            Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
                 CustomContent_Page_Activity_Name_Row_Time_value));          
            logger.LogMethodExit("CustomContentPage",
                "MouseOverOnLicensedAssetsRow",
                      base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select The Paste Button For Licensed Asset
        /// </summary>
        private void SelectThePasteButtonForLicensedAsset()
        {
            //Select The Paste Button For Licensed Asset
            logger.LogMethodEntry("CustomContentPage",
                "SelectThePasteButtonForLicensedAsset",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element           
            base.WaitForElement(By.ClassName(CustomContentPageResource.
                CustomContent_Page_Paste_Button_ClassName_Locator));
            IWebElement getPasteButton = base.
                GetWebElementPropertiesByClassName(CustomContentPageResource.
                CustomContent_Page_Paste_Button_ClassName_Locator);
            //Click the paste button
            base.ClickByJavaScriptExecutor(getPasteButton);
            Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
                CustomContent_Page_CustonContent_ButtonClick_Time_value));           
            //Select The Options In Paste DropDown
            this.SelectTheOptionsInPasteDropDown();           
            logger.LogMethodExit("CustomContentPage",
                "SelectThePasteButtonForLicensedAsset",
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select The Options In Paste DropDown
        /// </summary>
        private void SelectTheOptionsInPasteDropDown()
        {
            //Select The Options In Paste DropDown
            logger.LogMethodEntry("CustomContentPage",
               "SelectTheOptionsInPasteDropDown",
             base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(CustomContentPageResource.
                CustomContent_Page_Paste_Dropdown_Id_Locator));
            FocusOnElementById(CustomContentPageResource.
                CustomContent_Page_Paste_Dropdown_Id_Locator);
            //Time Value for dropdown
            Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
                CustomContent_Page_CustonContent_ButtonClick_Time_value));
            //Wait for the element
            base.WaitForElement(By.Id(CustomContentPageResource.
                 CustomContent_Page_Paste_Dropdown_BelowItem_Id_Locator));
            IWebElement getCopyContent = base.
                GetWebElementPropertiesById(CustomContentPageResource.
                CustomContent_Page_Paste_Dropdown_BelowItem_Id_Locator);
            //Perform mouse over action
            base.PerformMouseHoverByJavaScriptExecutor(getCopyContent);            
            //Click the below item
            base.ClickByJavaScriptExecutor(getCopyContent);
            Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
            CustomContent_Page_CustonContent_ButtonClick_Time_value));
            logger.LogMethodExit("CustomContentPage",
                "SelectTheOptionsInPasteDropDown",
                      base.IsTakeScreenShotDuringEntryExit);
        }       
       

        /// <summary>
        /// Select The CutPaste Button For NonLicensed Asset
        /// </summary>
        private void SelectTheCutPasteButtonForNonLicensedAsset()
        {
            //Select The CutPaste Button For NonLicensed Asset
            logger.LogMethodEntry("CustomContentPage",
                "SelectTheCutPasteButtonForNonLicensedAsset",
              base.IsTakeScreenShotDuringEntryExit);
                //Wait for the element
                base.WaitForElement(By.XPath(CustomContentPageResource.
                    CustomContent_Page_CutPaste_Button_Xpath_Locator));
                IWebElement getButtonpaste = base.
                    GetWebElementPropertiesByXPath(CustomContentPageResource.
                    CustomContent_Page_CutPaste_Button_Xpath_Locator);
                //Click the paste button
                base.ClickByJavaScriptExecutor(getButtonpaste);
                Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
                    CustomContent_Page_CustonContent_ButtonClick_Time_value));  
            logger.LogMethodExit("CustomContentPage",
                "SelectTheCutPasteButtonForNonLicensedAsset",
                 base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Click The Clear Clipboard Link
        /// </summary>
        public void ClickTheClearClipboardLink()
        {
            //Click The Clear Clipboard Link
            logger.LogMethodEntry("CustomContentPage",
                "ClickTheClearClipboardLink",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(CustomContentPageResource.
                    CustomContent_Page_Clipboard_Id_Locator));
                base.FocusOnElementById(CustomContentPageResource.
                    CustomContent_Page_Clipboard_Id_Locator);
                //Get the Web element
                IWebElement getClipboarProperty =
                base.GetWebElementPropertiesById(CustomContentPageResource.
                    CustomContent_Page_Clipboard_Id_Locator);
                //Click the "Clear Clipboard" link
                base.ClickByJavaScriptExecutor(getClipboarProperty);
                //Refresh the current page
                WebDriver.Navigate().Refresh();
                Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
                CustomContent_Page_CustonContent_ButtonClick_Time_value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage",
                "ClickTheClearClipboardLink",
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Create Button In Global
        /// </summary>
        public void ClickTheCreateButtonInGlobal()
        {
            //Click The Create Button In Global
            logger.LogMethodEntry("CustomContentPage",
                "ClickTheCreateButtonInGlobal",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(CustomContentPageResource.
                    CustomContent_Page_CreateButton_Global_Id_Locator));
                base.FocusOnElementById(CustomContentPageResource.
                    CustomContent_Page_CreateButton_Global_Id_Locator);
                //Click the "CreateButton"
                base.ClickButtonById(CustomContentPageResource.
                    CustomContent_Page_CreateButton_Global_Id_Locator);
                Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
                    CustomContent_Page_CustonContent_ButtonClick_Time_value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage",
                "ClickTheCreateButtonInGlobal",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Assets Type Folder
        /// </summary>
        public void SelectAssetsTypeFolder()
        {
            //Select Assets Type Folder
            logger.LogMethodEntry("CustomContentPage", "SelectAssetsTypeFolder",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(CustomContentPageResource.
                  CustomContent_Page_Global_CreateContent_Menu_Id_Locator));
                base.FocusOnElementById(CustomContentPageResource.
                  CustomContent_Page_Global_CreateContent_Menu_Id_Locator);
                //Wait for the element
                base.WaitForElement(By.XPath(CustomContentPageResource.
                  CustomContent_Page_Global_CreateContent_Folder_Xpath_Locator));
                base.FocusOnElementByXPath(CustomContentPageResource.
                  CustomContent_Page_Global_CreateContent_Folder_Xpath_Locator);
                //Click the "Folder" option
                base.ClickLinkByXPath(CustomContentPageResource.
                  CustomContent_Page_Global_CreateContent_Folder_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage", "SelectAssetsTypeFolder",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Custom Content Asset
        /// </summary>
        /// <param name="getAssetType">This is AssetType</param>
        /// <param name="activityType">This is Activity by type</param>
        public void VerifyCustomContentAsset
            (AddAssessmentPage.AssetTypeEnum getAssetType,
         Activity.ActivityTypeEnum activityType)
        {
            //Verify Custom Content Asset
            logger.LogMethodEntry("CustomContentPage",
                "VerifyCustomContentAsset",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (getAssetType)
                {
                    case AddAssessmentPage.AssetTypeEnum.Licensed:
                        //Get the Activity from memory           
                        Activity newActivityTest = Activity.Get(CommonResource.
                           CommonResource.DigitalPath_Activity_TestData_UC1);           
                        //Select the Licensed Activity Asset        
                        this.SelectLicensedActivityTest(newActivityTest.Name);
                        break;
                    case AddAssessmentPage.AssetTypeEnum.NonLicensed:
                        //Get the Activity from memory  
                        Activity nonLicensedActivity=Activity.Get(CommonResource.
                             CommonResource.DigitalPath_Activity_Test_UC3);                     
                        //Select NonLicensed Activity Test          
                        this.SelectNonLicensedActivityTest(nonLicensedActivity.Name);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage",
                "VerifyCustomContentAsset",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Licensed Activity Asset 
        /// </summary>
        /// <param name="activityTest">This is Activity Test</param>
        private void SelectLicensedActivityTest(string activityTest)
        {
            //Select the Licensed Activity Asset 
            logger.LogMethodEntry("CustomContentPage",
                "SelectLicensedActivityTest",
                base.IsTakeScreenShotDuringEntryExit);
            //Getting the counts of activity
            int getCourseCount = base.GetElementCountByXPath(CustomContentPageResource.
           CustomContent_Page_Activity_Count_Xpath_Locator);
            for (int setRowCount = 1; setRowCount <= getCourseCount; setRowCount++)
            {
                //Getting the assets name
                string getActivityTest = base.GetElementTextByXPath
                  (string.Format(CustomContentPageResource.
                  CustomContent_Page_Activity_Name_Xpath_Locator, setRowCount));
                if (getActivityTest == activityTest)
                {
                    break;
                }
            }

            logger.LogMethodExit("CustomContentPage",
                "SelectLicensedActivityTest",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click The Expand Button NonLicensed Folder
        /// </summary>
        public void ClickTheExpandButtonNonLicensedFolder()
        {
            //Click The Expand Button NonLicensed Asset
            logger.LogMethodEntry("CustomContentPage",
                "ClickTheExpandButtonNonLicensedFolder",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Frame
                this.SelectCurriculumFrame();
                //Wait for the Element
                base.WaitForElement(By.XPath(CustomContentPageResource.
                      CustomContent_Page_FolderExpandButton_Title_Name));
                //Focus on Expand Button
                base.FocusOnElementByXPath(CustomContentPageResource.
                     CustomContent_Page_FolderExpandButton_Title_Name);
                IWebElement getExpandButton = base.GetWebElementPropertiesByXPath
                    (CustomContentPageResource.
                      CustomContent_Page_FolderExpandButton_Title_Name);
                //Click on Expand Button 
                base.ClickByJavaScriptExecutor(getExpandButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage",
                "ClickTheExpandButtonNonLicensedFolder",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Mouse Over On NonLecensed Folder
        /// </summary>
        public void MouseOverOnNonLecensedFolder()
        {
            //Mouse Over On NonLecensed Folder
            logger.LogMethodEntry("CustomContentPage",
                "MouseOverOnNonLecensedFolder",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for a element
                base.WaitForElement(By.ClassName(CustomContentPageResource.
                    CustomContent_Page_Folder_Title_Mouseover_ClassName));
                base.FocusOnElementByClassName(CustomContentPageResource.
                    CustomContent_Page_Folder_Title_Mouseover_ClassName);
                //Get Web element
                IWebElement getAsset = base.
                    GetWebElementPropertiesByClassName(CustomContentPageResource.
                    CustomContent_Page_Folder_Title_Mouseover_ClassName);
                //Perform mouse over action
                base.PerformMouseHoverByJavaScriptExecutor(getAsset);                
                //Click NonLicensed CreateContent Button
                this.ClickNonLicensedCreateContentButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage",
               "MouseOverOnNonLecensedFolder",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click NonLicensed CreateContent Button
        /// </summary>
        private void ClickNonLicensedCreateContentButton()
        {
            //Click NonLicensed CreateContent Button    
            logger.LogMethodEntry("CustomContentPage",
               "ClickNonLicensedCreateContentButton",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(CustomContentPageResource.
                CustomContent_Page_Folder_CreateContent_Button_Xpath_Locator));
            base.FillEmptyTextByXPath(CustomContentPageResource.
             CustomContent_Page_Folder_CreateContent_Button_Xpath_Locator);
            //Get the web element             
            IWebElement clickButton = base.
                GetWebElementPropertiesByXPath(CustomContentPageResource.
                CustomContent_Page_Folder_CreateContent_Button_Xpath_Locator);
            //Click the "Create Content" button
            base.ClickByJavaScriptExecutor(clickButton);
            logger.LogMethodExit("CustomContentPage",
               "ClickNonLicensedCreateContentButton",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Link Asset
        /// </summary>
        public void SelectLinkAsset()
        {
            //Select Link Asset
            logger.LogMethodEntry("CustomContentPage", "SelectLinkAsset",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element             
                base.WaitForElement(By.XPath(CustomContentPageResource.
                    CustomContent_Page_Folder_Link_Xpath_locator));
                IWebElement getSelectlink = base.GetWebElementPropertiesByXPath
                    (CustomContentPageResource.
                    CustomContent_Page_Folder_Link_Xpath_locator);
                //Click on the "Link" Assets
                base.ClickByJavaScriptExecutor(getSelectlink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage", "SelectLinkAsset",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Curriculum Link In Home Page
        /// </summary>
        public void ClickTheCurriculumLinkInHomePage(string customContent)
        {
            // Click The Curriculum Link In Home Page
            logger.LogMethodEntry("CustomContentPage",
                "ClickTheCurriculumLinkInHomePage",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.SelectWindow(CustomContentPageResource.
                    CustomContent_Page_Home_Window_Name);
                //Getting the counts of curriculum links
                int getLinkCount = base.GetElementCountByXPath(CustomContentPageResource.
                    CustomContent_Page_Home_LinkTitle_Count_Xpath_Locator);
                for (int setRowCount = 1; setRowCount <= getLinkCount; setRowCount++)               
                {                   
                    //Getting the link name
                    string getLinkName = base.GetElementTextByXPath
                        (string.Format(CustomContentPageResource.
                        CustomContent_Page_Home_LinkTitle_Xpath_Locator,setRowCount));
                    if (getLinkName == customContent)
                    {
                        //Focus on the link
                        base.FocusOnElementByXPath(string.Format(CustomContentPageResource.
                        CustomContent_Page_Home_LinkTitle_Xpath_Locator, setRowCount));
                        //Click the Link
                        base.ClickButtonByXPath(string.Format(CustomContentPageResource.
                        CustomContent_Page_Home_LinkTitle_Xpath_Locator, setRowCount));
                        Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
                           CustomContent_Page_CustonContent_ButtonClick_Time_value)); 
                        break;
                    }
                }              
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage",
               "ClickTheCurriculumLinkInHomePage",
                 base.IsTakeScreenShotDuringEntryExit);
        }      

        /// <summary>
        /// Select NonLicensed Activity Test
        /// </summary>
        /// <param name="activityTest">This is activity type</param>
        private void SelectNonLicensedActivityTest(string activityTest)
        {
            //Select NonLicensed Activity Test
            logger.LogMethodEntry("CustomContentPage",
                "SelectNonLicensedActivityTest",
                base.IsTakeScreenShotDuringEntryExit);
            //Getting the counts of activity
            int getCourseCount = base.GetElementCountByXPath
                (CustomContentPageResource.
                CustomContent_Page_NonLicensedActivity_RowCount_Xpath_Locator);
            for (int setRowCount = 1; setRowCount <= getCourseCount; setRowCount++)
            {
                //Getting the Activity Test name               
                string getActivityTest = base.GetElementTextByXPath
                 (string.Format(CustomContentPageResource.
                 CustomContent_Page_NonLicensedActivity_Name_Xpath_Locator, setRowCount));
                if (getActivityTest == activityTest)
                {
                    break;
                }
            }
            logger.LogMethodExit("CustomContentPage",
               "SelectNonLicensedActivityTest",
           base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Select NonLicensed CheckBox
        /// </summary>
        private void SelectNonLicensedCheckBox()
        {
            //Select NonLicensed CheckBox
            logger.LogMethodEntry("CustomContentPage",
               "SelectNonLicensedCheckBox",
               base.IsTakeScreenShotDuringEntryExit);           
                //Wait for the element
                base.WaitForElement(By.XPath(CustomContentPageResource.
                    CustomContent_Page_NonLicensedActivity_Checkbox_Xpath_Locator));
                base.FocusOnElementByXPath(CustomContentPageResource.
                    CustomContent_Page_NonLicensedActivity_Checkbox_Xpath_Locator);
                //Click on the check box
                base.SelectCheckBoxByXPath(CustomContentPageResource.
                    CustomContent_Page_NonLicensedActivity_Checkbox_Xpath_Locator);           
            logger.LogMethodExit("CustomContentPage",
               "SelectNonLicensedCheckBox",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Mouse Over On NonLicensed Action Row Assets
        /// </summary>
        private void MouseOverOnNonLicensedActionRowAssets()
        {
            //Mouse Over On NonLicensed Action Row Assets
            logger.LogMethodEntry("CustomContentPage",
                   "MouseOverOnNonLicensedActionRowAssets",
              base.IsTakeScreenShotDuringEntryExit);            
                //Get the Activity from memory           
              Activity newActivity = Activity.Get(CommonResource.
                  CommonResource.DigitalPath_Activity_Link_UC4);       
                //Select NonLicensed Activity Test 
              this.SelectNonLicensedActivityTest(newActivity.Name);
              //Mouse Over On NonLicensed Assets Row
                this.MouseOverOnNonLicensedAssetsRow();
                //Select The Paste Button For Licensed Asset
                this.SelectThePasteButtonForLicensedAsset();
                Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
                 CustomContent_Page_CustonContent_ButtonClick_Time_value));            
            logger.LogMethodExit("CustomContentPage",
                          "MouseOverOnNonLicensedActionRowAssets",
           base.IsTakeScreenShotDuringEntryExit);
        }
       

        /// <summary>
        ///Mouse Over On NonLicensed Assets Row
        /// </summary>
        private void MouseOverOnNonLicensedAssetsRow()
        {
            //Mouse Over On NonLicensed Assets Row
            logger.LogMethodEntry("CustomContentPage",
              "MouseOverOnNonLicensedAssetsRow",
            base.IsTakeScreenShotDuringEntryExit);           
                //Wait for the element
            base.WaitForElement(By.XPath(CustomContentPageResource.
                    CustomContent_Page_NonLicensedActivity_Link_Xpath_Locator));
                //Get the web element 
            IWebElement getTitleAsset = base.GetWebElementPropertiesByXPath
                    (CustomContentPageResource.
                    CustomContent_Page_NonLicensedActivity_Link_Xpath_Locator);
                //Perform mouse over action
            base.PerformMouseHoverByJavaScriptExecutor(getTitleAsset);                        
            logger.LogMethodExit("CustomContentPage",
               "MouseOverOnNonLicensedAssetsRow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Cut Link
        /// </summary>
        private void ClickTheCutLink()
        {
            //Click The Cut Link
            logger.LogMethodEntry("CustomContentPage", "ClickTheCutLink",
              base.IsTakeScreenShotDuringEntryExit);           
                //Wait for the element
                base.WaitForElement(By.Id(CustomContentPageResource.
                    CustomContent_Page_Cut_Link_Id_Locator));
                base.FocusOnElementById(CustomContentPageResource.
                    CustomContent_Page_Cut_Link_Id_Locator);
                //Click the "Cut" link
                base.ClickButtonById(CustomContentPageResource.
                    CustomContent_Page_Cut_Link_Id_Locator);           
            logger.LogMethodExit("CustomContentPage", "ClickTheCutLink",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Remove NonLicensed Copied Content
        /// </summary>
        private void RemoveNonLicensedCopiedContent()
        {
            //Remove NonLicensed Copied Content
            logger.LogMethodEntry("CustomContentPage",
                "RemoveNonLicensedCopiedContent",
              base.IsTakeScreenShotDuringEntryExit);                         
                //Wait for the element
                base.WaitForElement(By.Id(CustomContentPageResource.
                    CustomContent_Page_Activity_Remove_Checkbox_Id_Locator));
                base.FocusOnElementById(CustomContentPageResource.
                    CustomContent_Page_Activity_Remove_Checkbox_Id_Locator);
                //Click the check box
                base.SelectCheckBoxById(CustomContentPageResource.
                    CustomContent_Page_Activity_Remove_Checkbox_Id_Locator); 
            logger.LogMethodExit("CustomContentPage",
                "RemoveNonLicensedCopiedContent",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Remove Button
        /// </summary>
        private void ClickTheRemoveButton()
        {
            // Click The Remove Button
            logger.LogMethodEntry("CustomContentPage", "ClickTheRemoveButton",
              base.IsTakeScreenShotDuringEntryExit);
                //Wait for the element
                base.WaitForElement(By.Id(CustomContentPageResource.
                    CustomContent_Page_RemoveButton_Id_Locator));
                base.FocusOnElementById(CustomContentPageResource.
                    CustomContent_Page_RemoveButton_Id_Locator);
                //Click the "Remove " Button
                base.ClickButtonById(CustomContentPageResource.
                    CustomContent_Page_RemoveButton_Id_Locator);           
            logger.LogMethodExit("CustomContentPage", "ClickTheRemoveButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click OK Button
        /// </summary>
        private void ClickOKButton()
        {
            //Click OK Button
            logger.LogMethodEntry("CustomContentPage", "ClickOKButton",
               base.IsTakeScreenShotDuringEntryExit);          
                //Select window
                base.SelectWindow(CustomContentPageResource.
                    CustomContent_Page_OK_Window_Title_Name);
                //Waiat for the element
                base.WaitForElement(By.Id(CustomContentPageResource.
                    CustomContent_Page_Ok_Button_Id_Locator));
                base.FocusOnElementById(CustomContentPageResource.
                    CustomContent_Page_Ok_Button_Id_Locator);
                //Click the "OK" button
                base.ClickButtonById(CustomContentPageResource.
                    CustomContent_Page_Ok_Button_Id_Locator);
                Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
                  CustomContent_Page_CustonContent_ButtonClick_Time_value));            
           logger.LogMethodExit("CustomContentPage", "ClickOKButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Remove Licensed Copied Content
        /// </summary>
        private void RemoveLicensedCopiedContent()
        {
            //Remove Licensed Copied Content
            logger.LogMethodEntry("CustomContentPage",
                "RemoveLicensedCopiedContent",
             base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
                base.WaitForElement(By.Id(CustomContentPageResource.
                    CustomContent_Page_Remove_Paste_LicensedAsset_Id_Locator));
                base.FocusOnElementById(CustomContentPageResource.
                    CustomContent_Page_Remove_Paste_LicensedAsset_Id_Locator);
                //Click the Check box of pasted asset
                base.SelectCheckBoxById(CustomContentPageResource.
                    CustomContent_Page_Remove_Paste_LicensedAsset_Id_Locator); 
            logger.LogMethodExit("CustomContentPage",
                "RemoveLicensedCopiedContent",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Mouse Over On NonLicensed Cut Paste Asset
        /// </summary>
        private void MouseOverOnNonLicensedCutPasteAsset()
        {
            //Mouse Over On NonLicensed Cut Paste Asset
            logger.LogMethodEntry("CustomContentPage",
                "MouseOverOnNonLicensedCutPasteAsset",
             base.IsTakeScreenShotDuringEntryExit);           
                //Get the Activity from memory           
               Activity newActivity = Activity.Get(CommonResource.
                  CommonResource.DigitalPath_Activity_Link_UC4);   
                //Select NonLicensed Activity Test
                this.SelectNonLicensedActivityTest(newActivity.Name);
                //Mouse Over On NonLicensed Assets Row
                this.MouseOverOnNonLicensedAssetsRow();
                //Select The CutPaste Button For NonLicensed Asset
                this.SelectTheCutPasteButtonForNonLicensedAsset();
                //Select The Options In PasteDropDown
                this.SelectTheOptionsInPasteDropDown();
                Thread.Sleep(Convert.ToInt32(CustomContentPageResource.
                  CustomContent_Page_CustonContent_ButtonClick_Time_value));            
            logger.LogMethodExit("CustomContentPage",
               "MouseOverOnNonLicensedCutPasteAsset",
        base.IsTakeScreenShotDuringEntryExit);
        }

      /// <summary>
      /// Select CopyPaste Link
      /// </summary>
      /// <param name="getAssetType"></param>
        public void SelectCopyPasteLink
            (AddAssessmentPage.AssetTypeEnum getAssetType)
        {
            //Select CopyPaste Link
            logger.LogMethodEntry("CustomContentPage","SelectCopyPasteLink",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select  Checkbox 
                this.SelectCheckBox(getAssetType);
                //Click The Copy Link
                this.ClickTheCopyLink();
                switch (getAssetType)
                {
                    //Copy Paste for Licensed Assets
                    case AddAssessmentPage.AssetTypeEnum.Licensed:                       
                        //Mouse over on Action Row Assets               
                        this.MouseOverOnLicensedActionRowAssets();
                        break;
                    //Copy Paste for NonLicensed Assets
                    case AddAssessmentPage.AssetTypeEnum.NonLicensed:
                        //Mouse Over On NonLicensed Action Row Assets
                        this.MouseOverOnNonLicensedActionRowAssets();
                        break;
                } 
            }
            catch (Exception e)
            {  ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage", "SelectCopyPasteLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select CheckBox
        /// </summary>
        /// <param name="getAssetType">This is AssetType Enum</param>
        private void SelectCheckBox
            (AddAssessmentPage.AssetTypeEnum getAssetType)
        {
            //Select CheckBox
            logger.LogMethodEntry("CustomContentPage", "SelectCheckBox",
             base.IsTakeScreenShotDuringEntryExit);
            switch (getAssetType)
            {
                  //Checkbox select for Licensed Assets
                case AddAssessmentPage.AssetTypeEnum.Licensed:
                    //Select Licensed Checkbox 
                    this.SelectLicencedCheckBox();
                    break;
                //Checkbox select for NonLicensed Assets
                case AddAssessmentPage.AssetTypeEnum.NonLicensed:
                    //Select NonLicensed CheckBox
                    this.SelectNonLicensedCheckBox();
                    break;
            }
            logger.LogMethodExit("CustomContentPage", "SelectCheckBox",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Remove The Copied Content In Global
        /// </summary>
        /// <param name="assetTypeEnum">This is AssetType Enum</param>
        public void RemoveTheCopiedContentInGlobal(
            AddAssessmentPage.AssetTypeEnum assetTypeEnum)
        {
            //Remove The Copied Content In Global
            logger.LogMethodEntry("CustomContentPage",
                "RemoveTheCopiedContentInGlobal",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (assetTypeEnum)
                {
                    //Remove Licensed Copied Content
                    case AddAssessmentPage.AssetTypeEnum.Licensed:
                        //Remove Licensed Copied Content
                        this.RemoveLicensedCopiedContent();
                        break;
                    //Remove NonLicensed Copied Content
                    case AddAssessmentPage.AssetTypeEnum.NonLicensed:
                        //Remove NonLicensed Copied Content
                        this.RemoveNonLicensedCopiedContent();
                        break;
                }
                //Click The Remove Button
                this.ClickTheRemoveButton();
                //Click OK Button
                this.ClickOKButton();
            }
            catch (Exception e)
            {   ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage",
                "RemoveTheCopiedContentInGlobal",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The CutPaste Link
        /// </summary>
        /// <param name="assetTypeEnum">This is AssetType Enum</param>
        public void SelectTheCutPasteLink(
            AddAssessmentPage.AssetTypeEnum assetTypeEnum)
        {
            //Select The CutPaste Link
            logger.LogMethodEntry("CustomContentPage",
                "SelectTheCutPasteLink",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select  Checkbox 
                this.SelectCheckBox(assetTypeEnum);
                //Click The Cut Link
                this.ClickTheCutLink();
                switch (assetTypeEnum)
                {
                    case AddAssessmentPage.AssetTypeEnum.Licensed:                       
                        //Mouse over on Action Row Assets               
                        this.MouseOverOnLicensedActionRowAssets();
                        break;
                    case AddAssessmentPage.AssetTypeEnum.NonLicensed:                       
                        //Mouse Over On NonLicensed Assets
                        this.MouseOverOnNonLicensedCutPasteAsset();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage",
                "SelectTheCutPasteLink",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fetch Updated Activity Name From Memory.
        /// </summary>
        /// <returns>Update Activity Name.</returns>
        public String FetchUpdatedActivityNameFromMemory()
        {
            //Fetch Updated Activity Name From Memory
            logger.LogMethodEntry("CustomContentPage",
                "FetchUpdatedActivityName",
             base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getUpdatedActivityName = string.Empty;
            try
            {
                //Get Activity Name From Memory
                Activity activity = Activity.Get(CommonResource.CommonResource.
                            DigitalPath_Activity_TestData_UC1);
                //Get Updated Activity Name
                getUpdatedActivityName = activity.Name; ;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CustomContentPage",
                "FetchUpdatedActivityName",
              base.IsTakeScreenShotDuringEntryExit);
            return getUpdatedActivityName;
        }
    }
}
