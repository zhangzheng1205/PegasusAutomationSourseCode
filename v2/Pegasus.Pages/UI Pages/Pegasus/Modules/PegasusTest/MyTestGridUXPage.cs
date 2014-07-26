using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.PegasusTest;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Creation of MyTest Actions
    /// </summary>
    public class MyTestGridUXPage : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(MyTestGridUXPage));

        /// <summary>
        /// Create New Test.
        /// </summary>
        public void ClickOnLinkToSelect()
        {
            // Create New Test
            Logger.LogMethodEntry("MyTestGridUXPage", "ClickOnLinkToSelect",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectMyTestWindow();
                //Select Frame
                this.SelectMyTestGridFrame();
                //Click on Link
                this.ClickOnCreateNewTestLink();
                //Create MyTest Activity
                new AssessmentNamePage().CreateMyTestActivity();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestGridUXPage", "ClickOnLinkToSelect",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Create New Test Link.
        /// </summary>
        /// <param name="linkName">This is a link name.</param>
        private void ClickOnCreateNewTestLink()
        {
            Logger.LogMethodEntry("MyTestGridUXPage", "ClickOnCreateNewTestLink",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(MyTestGridUXPageResource.
                MyTestGridUX_Page_CreateNewTest_Id_Locator));
            //Focus on element
            base.FocusOnElementById(MyTestGridUXPageResource.
                MyTestGridUX_Page_CreateNewTest_Id_Locator);
            IWebElement getCreateNewTestLinkProperty = base.
                GetWebElementPropertiesById(MyTestGridUXPageResource.
                MyTestGridUX_Page_CreateNewTest_Id_Locator);
            //Click the "Create New Test" Link
            base.ClickByJavaScriptExecutor(getCreateNewTestLinkProperty);
            Logger.LogMethodExit("MyTestGridUXPage", "ClickOnCreateNewTestLink",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select My Test Grid Frame in the Page.
        /// </summary>
        private void SelectMyTestGridFrame()
        {
            //This is logger entry
            Logger.LogMethodEntry("MyTestGridUXPage", "SelectMyTestGridFrame",
              base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(MyTestGridUXPageResource.
                MyTestGridUX_Page_MyTest_Frame_Id_Locator));
            //Select IFrame
            base.SwitchToIFrame(MyTestGridUXPageResource.
                MyTestGridUX_Page_MyTest_Frame_Id_Locator);
            //This is logger exit
            Logger.LogMethodExit("MyTestGridUXPage", "SelectMyTestGridFrame",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select My Test Window.
        /// </summary>
        private void SelectMyTestWindow()
        {
            //This is entry logger
            Logger.LogMethodEntry("MyTestGridUXPage", "SelectMyTestWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilWindowLoads(MyTestGridUXPageResource.
                MyTestGridUX_Page_MyTest_Window_Name);
            //Select the window
            base.SelectWindow(MyTestGridUXPageResource.
                MyTestGridUX_Page_MyTest_Window_Name);
            //This is exit logger
            Logger.LogMethodExit("MyTestGridUXPage", "SelectMyTestWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Success Message In MyTest Tab.
        /// </summary>
        /// <returns>Success Message.</returns>
        public string GetSuccessMessageInMyTestTab()
        {
            //Get Success Message In MyTest Tab
            Logger.LogMethodEntry("MyTestGridUXPage",
                "GetSuccessMessageInMyTestTab",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSuccessMessage = string.Empty;
            try
            {
                Thread.Sleep(Convert.ToInt32(MyTestGridUXPageResource.
                    MyTestGridUX_Page_Thred_Time));
                //Select Window
                this.SelectMyTestWindow();
                base.WaitForElement(By.Id(MyTestGridUXPageResource.
                    MyTestGridUX_Page_MyTest_Tab_Message_Id_Locator));
                //Get Success Message From Application
                getSuccessMessage = base.GetElementTextById(MyTestGridUXPageResource.
                    MyTestGridUX_Page_MyTest_Tab_Message_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("MyTestGridUXPage",
                "GetSuccessMessageInMyTestTab",
                 base.isTakeScreenShotDuringEntryExit);
            return getSuccessMessage;
        }

        /// <summary>
        /// Click MyTest Activity Cmenu Option.
        /// </summary>
        /// <param name="cMenuOptionName">This is option name.</param>
        public void ClickMyTestCMenuOption(
            String cMenuOptionName)
        {
            //Click MyTest Activity Cmenu Option
            Logger.LogMethodEntry("MyTestGridUXPage", "ClickMyTestCMenuOption",
             base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select MyTest Window
                this.SelectMyTestWindow();
                //Select IFrame
                this.SelectMyTestGridFrame();
                //Click cmenu option
                this.ClickTestActivtyContextualMenuOption(cMenuOptionName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestGridUXPage", "ClickMyTestCMenuOption",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on MyTest activity cmenu option.
        /// </summary>
        /// <param name="cMenuOptionName">This is cmenu option name.</param>
        private void ClickTestActivtyContextualMenuOption(
            String cMenuOptionName)
        {
            //Click on MyTest activity cmenu option
            Logger.LogMethodEntry("MyTestGridUXPage", "ClickTestActivtyContextualMenuOption",
                 base.isTakeScreenShotDuringEntryExit);
            //Get Activity
            Activity activity = Activity.Get(Activity.ActivityTypeEnum.MyTest);
            int getTestColumnCount = this.SelectMyTestInManageYourTest(activity.Name);
            //Click on Test Image Cmenu Options
            this.ClickMyTestActivityCMenuOpenOption(getTestColumnCount);
            //Select Cmenu Options In ManageYourTest
            this.SelectCmenuOptionsInManageYourTest(cMenuOptionName);
            Logger.LogMethodExit("MyTestGridUXPage", "ClickTestActivtyContextualMenuOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select MyTest In Manage YourTest.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Column Count.</returns>
        private int SelectMyTestInManageYourTest
            (String activityName)
        {
            //Select MyTest In Manage YourTest
            Logger.LogMethodEntry("MyTestGridUXPage", "SelectMyTestInManageYourTest",
                 base.isTakeScreenShotDuringEntryExit);
            string newActivityName = activityName.Substring(Convert.ToInt32(
                MyTestGridUXPageResource.MyTestGridUX_Page_IntIntializer_Value),
                Convert.ToInt32(MyTestGridUXPageResource.
                MyTestGridUX_Page_SubstringSecond_Value));
            //Initialize VariableVariable
            int activityColumnNumber = Convert.ToInt32(MyTestGridUXPageResource.
                MyTestGridUX_Page_IntIntializer_Value);            
            string getTextFromActivityText = string.Empty; 
            do
            {
                //Get The MyTest Activity Table Text
                getTextFromActivityText=this.GetTheMyTestActivityTableText();                
                if (!getTextFromActivityText.Contains(newActivityName))
                {
                    //Click The MyTest Next Link
                    this.ClickTheMyTestNextLink();                    
                }
            }
            while (!getTextFromActivityText.Contains(newActivityName));
            //Get the Test RowCount
            activityColumnNumber = this.SelectMyTestActivityInManageYourTestFrame
                (activityName);            
            Logger.LogMethodExit("MyTestGridUXPage", "SelectMyTestInManageYourTest",
                base.isTakeScreenShotDuringEntryExit);
            return activityColumnNumber;
        }

        /// <summary>
        /// Get The MyTest Activity Table Text.
        /// </summary>
        private string GetTheMyTestActivityTableText()
        {
            //Get The MyTest Activity Table Text
            Logger.LogMethodEntry("MyTestGridUXPage","GetTheMyTestActivityTableText",
                       base.isTakeScreenShotDuringEntryExit);
            string getTextFromActivityText = string.Empty; 
            //Wait For Element
            base.WaitForElement(By.XPath(MyTestGridUXPageResource.
                MyTestGridUX_Page_Table_Contents_XPath_Locator));
            //Get the table content
            getTextFromActivityText =
            base.GetElementTextByXPath(MyTestGridUXPageResource.
            MyTestGridUX_Page_Table_Contents_XPath_Locator).Trim();
            Thread.Sleep(Convert.ToInt32(MyTestGridUXPageResource.
                MyTestGridUX_Page_Thred_Time));
            Logger.LogMethodExit("MyTestGridUXPage", "GetTheMyTestActivityTableText",
                base.isTakeScreenShotDuringEntryExit);
            return getTextFromActivityText;
        }

        /// <summary>
        /// Select MyTest Activity In Manage Your Test Frame.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Activity row count.</returns>
        private int SelectMyTestActivityInManageYourTestFrame(string activityName)
        {
            // Select MyTest Activity In Manage Your Test Frame
            Logger.LogMethodEntry("MyTestGridUXPage", 
                "SelectMyTestActivityInManageYourTestFrame",
                       base.isTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            int activityColumnNumber = Convert.ToInt32(MyTestGridUXPageResource.
                MyTestGridUX_Page_IntIntializer_Value);     
            base.WaitForElement(By.XPath(MyTestGridUXPageResource.
                    MyTestGridUX_Page_CreateNewTest_Table_Row_XPath_Locator));
            //Get Activity Count
            int getTotalActivityRowCount =
                base.GetElementCountByXPath(MyTestGridUXPageResource.
                MyTestGridUX_Page_CreateNewTest_Table_Row_XPath_Locator);
            //Iterate For Respective Activity In Grid
            for (int setActivityRowCount = Convert.ToInt16(MyTestGridUXPageResource.
                MyTestGridUX_Page_LoopIntializer_Value); setActivityRowCount <=
                getTotalActivityRowCount; setActivityRowCount++)
            {
                //Get Activity Name
                String getActivityName =
                    this.GetMyTestGetActivityName(setActivityRowCount);
                if (activityName.Contains(getActivityName))
                {
                    //Get web element
                    IWebElement getScrollBarProperty = base.GetWebElementPropertiesByXPath
                        (String.Format(MyTestGridUXPageResource.
                        MyTestGridUX_Page_CreateNewTest_Table_ActivityTitle_XPath_Locator,
                        setActivityRowCount));
                    base.ScrollElementByJavaScriptExecutor(getScrollBarProperty);
                    activityColumnNumber = setActivityRowCount;
                    break;
                }
            }
            Logger.LogMethodExit("MyTestGridUXPage", 
                "SelectMyTestActivityInManageYourTestFrame",
                         base.isTakeScreenShotDuringEntryExit);
            return activityColumnNumber;
        }

        /// <summary>
        /// Click The MyTest Next Link.
        /// </summary>
        private void ClickTheMyTestNextLink()
        {
            //Click The MyTest Next Link
            Logger.LogMethodEntry("MyTestGridUXPage", "ClickTheMyTestNextLink",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(MyTestGridUXPageResource.
                MyTestGridUX_Page_MyTest_Next_Link_Id_Locator));
            IWebElement getNextLink = base.GetWebElementPropertiesById
                (MyTestGridUXPageResource.
                MyTestGridUX_Page_MyTest_Next_Link_Id_Locator);
            //Click the next button
            base.ClickByJavaScriptExecutor(getNextLink);
            Thread.Sleep(Convert.ToInt32(MyTestGridUXPageResource.
                MyTestGridUX_Page_Wait_Element_Thred_Time));
            Logger.LogMethodExit("MyTestGridUXPage", "ClickTheMyTestNextLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get activity name from the table.
        /// </summary>
        /// <param name="setActivityRowCount">This is activity row count.</param>
        /// <returns>Activity name.</returns>
        private String GetMyTestGetActivityName(
            int setActivityRowCount)
        {
            //Get activity name from the table
            Logger.LogMethodEntry("MyTestGridUXPage", "GetMyTestGetActivityName",
                base.isTakeScreenShotDuringEntryExit);
            //Get Activity Row Text
            String getTextFromActivityRow =
                base.GetElementTextByXPath(
                    String.Format(MyTestGridUXPageResource.
                    MyTestGridUX_Page_CreateNewTest_Table_ActivityTitle_XPath_Locator,
                        setActivityRowCount));
            //Get activity name
            String getActivityName = getTextFromActivityRow.Replace(
                Environment.NewLine, string.Empty);
            //Logger exit
            Logger.LogMethodExit("MyTestGridUXPage", "GetMyTestGetActivityName",
               base.isTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Click on MyTest Activity CMenu Option.
        /// </summary>
        /// <param name="cMenuOptionName">This is cmenu option name.</param>
        /// <param name="setActivityRowCount">This is activiy row count.</param>
        private void ClickMyTestActivityCMenuOpenOption
            (int setActivityRowCount)
        {
            //Click on MyTest Activity CMenu Option
            Logger.LogMethodEntry("MyTestGridUXPage", "ClickMyTestActivityCMenuOpenOption",
               base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(String.Format(
                 MyTestGridUXPageResource.
                 MyTestGridUX_Page_CreateNewTest_Table_Activity_CMenu_Image_XPath_Locator,
                 setActivityRowCount)));
            //Get Web Element Property
            IWebElement getImageWebElementProperty =
                base.GetWebElementPropertiesByXPath(
                String.Format(MyTestGridUXPageResource.
                MyTestGridUX_Page_CreateNewTest_Table_Activity_CMenu_Image_XPath_Locator,
                setActivityRowCount));
            //Click On Image
            base.ClickByJavaScriptExecutor(getImageWebElementProperty);
            Logger.LogMethodExit("MyTestGridUXPage", "ClickMyTestActivityCMenuOpenOption",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Options In ManageYourTest.
        /// </summary>
        /// <param name="cMenuOptionName">This is Cmenu Option.</param>
        private void SelectCmenuOptionsInManageYourTest
            (string cMenuOptionName)
        {
            //Click on MyTest Activity CMenu Option
            Logger.LogMethodEntry("MyTestGridUXPage", "SelectCmenuOptionsInManageYourTest",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.ClassName(MyTestGridUXPageResource.
                MyTestGridUX_Page_CreateNewTest_Activity_CMenu_Options_ClassName_Locator));
            //Get CMenu Option Web Element Property
            IWebElement getCMenuWebElementProperty =
                base.GetWebElementPropertiesByPartialLinkText(cMenuOptionName);
            //Click CMenu Web Element
            base.ClickByJavaScriptExecutor(getCMenuWebElementProperty);
            Logger.LogMethodExit("MyTestGridUXPage", "SelectCmenuOptionsInManageYourTest",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Ok Button In Confirmation Popup.
        /// </summary>
        public void ClickTheOkButtonInConfirmationPopup()
        {
            //Click The Ok Button In Confirmation Popup           
            Logger.LogMethodEntry("MyTestGridUXPage", "ClickTheOkButtonInConfirmationPopup",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Pegasus Window
                base.SelectWindow(MyTestGridUXPageResource.
                    MyTestGridUX_Page_Pegasus_Window_Name);
                //wait for the element
                base.WaitForElement(By.Id(MyTestGridUXPageResource.
                    MyTestGridUX_Page_pegasus_Ok_Button_Id_Locator));
                IWebElement getOkButtonProperty = base.GetWebElementPropertiesById
                    (MyTestGridUXPageResource.MyTestGridUX_Page_pegasus_Ok_Button_Id_Locator);
                //Click on 'OK' button
                base.ClickByJavaScriptExecutor(getOkButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestGridUXPage", "ClickTheOkButtonInConfirmationPopup",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Display Of Header Options In Manage Your Test.
        /// </summary>
        /// <returns>Display of Headers Options.</returns>
        public String GetDisplayOfHeaderOptionsInManageYourTest()
        {
            //Get Display Of Header Options In Manage Your Test.          
            Logger.LogMethodEntry("MyTestGridUXPage", "GetDisplayOfHeaderOptionsInManageYourTest",
              base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getDisplayOfHeaderOptions = string.Empty;
            try
            {
                //Select MyTest Window and frame
                this.SelectMyTestWindow();
                this.SelectMyTestGridFrame();
                //Wait for the element
                base.WaitForElement(By.XPath(MyTestGridUXPageResource.
                    MyTestGridUX_Page_HeaderOptions_Table_Row_XPath_Locator));
                int getTotalHeaderCount = base.GetElementCountByXPath(MyTestGridUXPageResource.
                    MyTestGridUX_Page_HeaderOptions_Table_Row_XPath_Locator);
                for (int setHeaderCount = 1; setHeaderCount <=
                    getTotalHeaderCount; setHeaderCount++)
                {
                    //Get the Displayed options in mytest
                    getDisplayOfHeaderOptions += base.GetElementTextByXPath
                        (String.Format(MyTestGridUXPageResource.
                        MyTestGridUX_Page_HeaderOptionsName_Table_Row_XPath_Locator,
                        setHeaderCount));
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestGridUXPage", "GetDisplayOfHeaderOptionsInManageYourTest",
             base.isTakeScreenShotDuringEntryExit);
            return getDisplayOfHeaderOptions;
        }

        /// <summary>
        /// Validate the display of Manage Your Test Frame.
        /// </summary>
        /// <returns>Text of Manage Your Test Link.</returns>
        public String DisplayOfManageYourTestFrame()
        {
            //Logger Entry
            Logger.LogMethodEntry("MyTestGridUXPage", "DisplayOfManageYourTestFrame",
                 base.isTakeScreenShotDuringEntryExit);
            //Initialize varialbe 
            string getTextofManageYourTestLink = string.Empty;
            try
            {
                //Select MyTest window
                this.SelectMyTestWindow();
                //Select MyTest Grid Frame
                this.SelectMyTestGridFrame();
                //Validate the display of Manage Your Tests element 
                base.WaitForElement(By.ClassName
                    (MyTestGridUXPageResource.
                    MyTestGridUX_Page_ManageYourTest_Class_Name_Locator));
                //Get Text of element
                getTextofManageYourTestLink = base.
                    GetElementTextByClassName(MyTestGridUXPageResource.
                    MyTestGridUX_Page_ManageYourTest_Class_Name_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("MyTestGridUXPage", "DisplayOfManageYourTestFrame",
                 base.isTakeScreenShotDuringEntryExit);
            return getTextofManageYourTestLink;
        }

        /// <summary>
        /// Click MyTest CMenuOption In CourseSpace.
        /// </summary>
        /// <param name="cMenuOptionName">This is cmenu option</param>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        public void ClickMyTestCMenuOptionInCourseSpace
            (string cMenuOptionName, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click MyTest CMenuOption In CourseSpace
            Logger.LogMethodEntry("MyTestGridUXPage", "ClickMyTestCMenuOptionInCourseSpace",
             base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select MyTest Window
                this.SelectMyTestWindow();
                //Select IFrame
                this.SelectMyTestGridFrame();
                //Get Activity
                Activity activity = Activity.Get(activityTypeEnum);
                //Get the Test RowCount
                int getTestColumnCount = this.SelectMyTestInManageYourTest
                    (activity.Name);
                //Click on Test Image Cmenu Options
                this.ClickMyTestActivityCMenuOpenOption(getTestColumnCount);
                //Select Cmenu Options In ManageYourTest
                this.SelectCmenuOptionsInManageYourTest(cMenuOptionName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestGridUXPage", "ClickMyTestCMenuOptionInCourseSpace",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Image Cmenu Option From Test DropDown.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        public void ClickTheImageCmenuOptionFromTestDropDown
            (Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click The Image Cmenu Option From Test DropDown
            Logger.LogMethodEntry("MyTestGridUXPage",
                "ClickTheImageCmenuOptionFromTestDropDown",
             base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select MyTest Window
                this.SelectMyTestWindow();
                //Select IFrame
                this.SelectMyTestGridFrame();
                //Get Activity 
                Activity activity = Activity.Get(activityTypeEnum);
                //Get the Test RowCount
                int getTestColumnCount = this.SelectMyTestInManageYourTest
                    (activity.Name);
                //Click on Test Image Cmenu Options
                this.ClickMyTestActivityCMenuOpenOption(getTestColumnCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestGridUXPage", "ClickTheImageCmenuOptionFromTestDropDown",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Displayed Cmenu Options For Download.
        /// </summary>
        /// <param name="actualCmenuOption">This is Actual Cmenu.</param>
        /// <returns>Cmenu Options.</returns>
        public string GetDisplayedCmenuOptionsForDownload
            (string actualCmenuOption)
        {
            //Get Display Of Cmenu Option For For Download
            Logger.LogMethodEntry("MyTestGridUXPage", "GetDisplayedCmenuOptionsForDownload",
             base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getCmenuOptionsDisplayed = string.Empty;
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(PaperTestUXPageResource.
                    PaperTestUX_Page_MyTest_Table_Id_Locator));
                //Get the displayed cmenu options
                getCmenuOptionsDisplayed = base.GetElementTextById(PaperTestUXPageResource.
                    PaperTestUX_Page_MyTest_Table_Id_Locator);
                getCmenuOptionsDisplayed = getCmenuOptionsDisplayed.Replace
                        (Environment.NewLine, string.Empty).Trim();
                if (getCmenuOptionsDisplayed.Contains(actualCmenuOption))
                {
                    getCmenuOptionsDisplayed = actualCmenuOption;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestGridUXPage", "GetDisplayedCmenuOptionsForDownload",
             base.isTakeScreenShotDuringEntryExit);
            return getCmenuOptionsDisplayed;
        }

        /// <summary>
        /// Get Display Of Cmenu Option For Created Test.
        /// </summary>
        /// <param name="actualCmenuOption">This is Cmenu Options.</param>
        /// <returns>Cmenu Options.</returns>
        public string GetDisplayOfCmenuOptionForCreatedTest
            (string actualCmenuOption)
        {
            //Get Display Of Cmenu Option For Created Test
            Logger.LogMethodEntry("MyTestGridUXPage", "GetDisplayOfCmenuOptionForCreatedTest",
             base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getTestCmenuOptionsDisplayed = string.Empty;
            try
            {
                //Wait for the element
                base.WaitForElement(By.ClassName(MyTestGridUXPageResource.
                    MyTestGridUX_Page_MyTest_Cmenu_ClassName_Locator));
                //Get the displayed cmenu options
                getTestCmenuOptionsDisplayed = base.GetElementTextByClassName(
                    MyTestGridUXPageResource.
                    MyTestGridUX_Page_MyTest_Cmenu_ClassName_Locator);
                getTestCmenuOptionsDisplayed = getTestCmenuOptionsDisplayed.Replace
                        (Environment.NewLine, string.Empty).Trim();
                if (getTestCmenuOptionsDisplayed.Contains(actualCmenuOption))
                {
                    getTestCmenuOptionsDisplayed = actualCmenuOption;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestGridUXPage", "GetDisplayOfCmenuOptionForCreatedTest",
             base.isTakeScreenShotDuringEntryExit);
            return getTestCmenuOptionsDisplayed;
        }
    }
}
