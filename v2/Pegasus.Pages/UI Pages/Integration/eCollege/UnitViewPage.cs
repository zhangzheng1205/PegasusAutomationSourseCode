using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Integration.eCollege;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using System.Threading;
using System.Diagnostics;
using System.Configuration;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handle all action of verify grade in ECollege Gradebook 
    /// </summary>
    public class UnitViewPage : BasePage
    {
        /// <summary>
        /// The Static instance of the Logger for the class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(UnitViewPage));

        /// <summary>
        /// Click on Gradbook Tab on .Next Page.
        /// </summary>
        /// <param name="tabName">This is name of tab</param>
        public void ClickOnGradbookOnECollege(String tabName)
        {
            //Click on gradebook tab
            logger.LogMethodEntry("UnitViewPage", "ClickOnGradbookOnECollege"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Top Frame
                this.SelectTopFrame();
                //Wait for element
                base.WaitForElement(By.Id(tabName));
                //Get property of Tab
                IWebElement getPropertyOfGradbookTab = base.
                    GetWebElementPropertiesById(tabName);
                //Click of GradeBook Tab
                base.ClickByJavaScriptExecutor(getPropertyOfGradbookTab);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UnitViewPage", "ClickOnGradbookOnECollege"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// //Select Dropdown's value.
        /// </summary>
        /// <param name="dropDownValue">This is value of dropdown</param>
        public void SelectDropDownValue(String dropDownValue)
        {
            //Select Dropdown's value
            logger.LogMethodEntry("UnitViewPage", "SelectDropDownItem"
               , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to Content Frame
                SelectContentFrame();
                //Click on Select gradebook dropdown
                base.WaitForElement(By.Id(UnitViewPageResource.
                    UnitViewPage_gradebookViewDropDown_ID_locator));
                //Select Item summary from dropdown
                base.SelectDropDownValueThroughTextById(UnitViewPageResource.
                    UnitViewPage_gradebookViewDropDown_ID_locator, dropDownValue);
                //Get property of Go button
                IWebElement getPropertyOfGoButton = base.GetWebElementPropertiesById
                    (UnitViewPageResource.UnitViewPage_Go_Button_ID_locator);
                //Click on Go button
                base.ClickByJavaScriptExecutor(getPropertyOfGoButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UnitViewPage", "SelectDropDownItem"
              , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify grades of activity on ECollege gradebook. 
        /// </summary>
        public String VerifyGrade()
        {
            //Verify activity's grades in gradebook
            logger.LogMethodEntry("UnitViewPage", "VerifyGrade"
              , base.IsTakeScreenShotDuringEntryExit);
            //Define Variable for get activity garde
            String getGradesOfActivity = null;
            try
            {
                //Wait for Activity table row
                base.WaitForElement(By.XPath(UnitViewPageResource.
                    UnitViewPage_ActivityName_TotalColumn_Xpath_locator));
                //Sleep For Time
                Thread.Sleep(Convert.ToInt32(UnitViewPageResource.
                    UnitViewPage_Custom_Sleep_Time));
                //Get total activity column count
                int getTotalActivityColumnCount = base.GetElementCountByXPath
                    (UnitViewPageResource.
                    UnitViewPage_ActivityName_TotalColumn_Xpath_locator);
                //Get Activity name coulmn count
                int setActivityColumnCount =this.SelectActivityNameInItemSummaryTable(
                    getTotalActivityColumnCount);                
                //Get gardes of activity
                getGradesOfActivity = base.GetInnerTextAttributeValueByXPath
                    (String.Format(UnitViewPageResource.
                UnitViewPage_ActivityName_Grade_Xpath_locator, 
                setActivityColumnCount));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UnitViewPage", "VerifyGrade"
              , base.IsTakeScreenShotDuringEntryExit);
            return getGradesOfActivity;
        }

        /// <summary>
        /// Select Activity Name in Item summary table.
        /// </summary>
        /// <param name="getTotalActivityColumnCount">
        /// This column count number.</param>
        /// <returns>activity column count number</returns>
        private int SelectActivityNameInItemSummaryTable(
            int getTotalActivityColumnCount)
        {
            //Select Activity Name in Item summary table
            logger.LogMethodEntry("UnitViewPage", 
                "SelectActivityNameInItemSummaryTable"
              , base.IsTakeScreenShotDuringEntryExit);
            //Define Variable for Activity Column Count
            int setActivityColumnCount;
            //Varify activity Title
            for (setActivityColumnCount = 1; setActivityColumnCount <=
                getTotalActivityColumnCount - 5; setActivityColumnCount++)
            {
                //Get Activity name 
                String getTotalActivityName = base.GetInnerTextAttributeValueByXPath
                    (String.Format(UnitViewPageResource.
                    UnitViewPage_ActivityName_Column_Xpath_locator,
                    setActivityColumnCount));
                //Repalce xtra character from activity name
                string replaceWith = "";
                string getReplaceActivityName = getTotalActivityName.Replace("-\r\n", replaceWith);
                //Match actvity name 
                if (getReplaceActivityName.Equals
                    (UnitViewPageResource.UnitViewPage_Activity_Name))
                {
                    break;
                }
            }
            //Decrease activity column count to get activity grades in next statment 
            setActivityColumnCount--;
            logger.LogMethodExit("UnitViewPage", 
                "SelectActivityNameInItemSummaryTable"
             , base.IsTakeScreenShotDuringEntryExit);
            return setActivityColumnCount;
        }

        /// <summary>
        /// Select to Content Frame.
        /// </summary>
        private void SelectContentFrame()
        {
            //Switch to Content Frame
            logger.LogMethodEntry("UnitViewPage", "SelectContentFrame"
              , base.IsTakeScreenShotDuringEntryExit);
            //Select default window
            base.SelectDefaultWindow();
            //Switch to Main Frame
            this.SelectMainFrame();
            //Switch to Content Frame
            base.WaitForElement(By.Id(UnitViewPageResource.
                UnitViewPage_Content_Frame_ID_locator));
            base.SwitchToIFrame(UnitViewPageResource.
                UnitViewPage_Content_Frame_ID_locator);
            logger.LogMethodExit("UnitViewPage", "SelectContentFrame"
             , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Top frame.
        /// </summary>
        private void SelectTopFrame()
        {
            //Select Top frame
            logger.LogMethodEntry("UnitViewPage", "SelectTopFrame"
             , base.IsTakeScreenShotDuringEntryExit);
            //Select default window
            base.SelectDefaultWindow();
            //Select Main Frame
            SelectMainFrame();
            //Switch To Top farem
            base.WaitForElement(By.Id(UnitViewPageResource.
                UnitViewPage_Top_Frame_ID_locator));
            base.SwitchToIFrame(UnitViewPageResource.
                UnitViewPage_Top_Frame_ID_locator);
            logger.LogMethodExit("UnitViewPage", "SelectTopFrame"
            , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Main Frame.
        /// </summary>
        private void SelectMainFrame()
        {
            //Select to Main Frame
            logger.LogMethodEntry("UnitViewPage", "SelectMainFrame"
            , base.IsTakeScreenShotDuringEntryExit);
            //Switch to Main Frame
            base.WaitForElement(By.Id(UnitViewPageResource.
                UnitViewPage_Main_Frame_ID_locator));
            base.SwitchToIFrame(UnitViewPageResource.
                UnitViewPage_Main_Frame_ID_locator);
            logger.LogMethodExit("UnitViewPage", "SelectMainFrame"
            , base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
