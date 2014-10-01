using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.SIM5.SIM5Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    public class SIM5FramePage:BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(SIM5FramePage));

       /// <summary>
        /// Submit SIM5 Excel type activity.
        /// <param name="activityName">This is activity name.</param>
        /// </summary>
        public void SubmitSim5ExcelActivityExcelChapter1SkillBasedTraining(String activityName)
        {
            //Submit SIM5 Excel type activity
            Logger.LogMethodEntry("SIM5FramePage",
                "SubmitSim5ExcelActivityExcelChapter1SkillBasedTraining",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select window name
                new StudentPresentationPage().SelectSimActivityNormalStudentWindowName
                    (activityName);
                //Answer first excel question
                this.StartingExcelNavigatingExcelAndNamingAndSavingAWorkbook();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                //Answer second question
                this.EnteringTextUsingAutoCompleteAndUsingTheNameBoxToSelectACell();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                //Answer third question
                this.AutoFillAndKeyboardShortcuts();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                // Answer Fourth question
                this.SettingCellWidthAndSelectingCellRangeToAlignData();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                   SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                //Answer Fifth excel quetion
                this.SettingDataInCell();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                   SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                //Anser sixth question
                this.ConstructingAFormulaAndUsingTheSumFunction();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                //Answer Seventh Question
                this.CopyingAFormulaByUsingTheFillHandle();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Eighth Question
                this.UsingMergerAndCenterAndApplyingCellStyles();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Ninth Question
                this.SimultaneouslyFormatMultipleCells();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Tenth Question
                this.SetWorksheetThemeToRetrospect();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                       SIM5Frame_Page_SIM5_Launch_Sleep_Time));

                //Click on SIM5 activity Submit button
                this.ClickOnSIM5ActivitySubmitButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SIM5FramePage",
                 "SubmitSim5ExcelActivityExcelChapter1SkillBasedTraining",
               base.IsTakeScreenShotDuringEntryExit);
        }

        #region SIM5 Excel First Question
        /// <summary>
        /// Answers Starting Excel Navigating Excel And Naming And Saving A Workbook.
        /// </summary>
        private void StartingExcelNavigatingExcelAndNamingAndSavingAWorkbook()
        {
            //Answers first Excel Question            
            Logger.LogMethodEntry("SIM5FramePage",
                    "AnswersFirstExcelQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
            //Get Excel desktop icon button Property
            IWebElement getExcelIconButton = base.GetWebElementPropertiesById
                (SIM5FramePageResource.
                 SIM5Frame_Page_Excel_Icon_Id_Locator);
            //Click on Excel desktop icon button
            base.ClickByJavaScriptExecutor(getExcelIconButton);
            //Get Excel blank workbook icon button Property
            IWebElement getBlankWorkbookIconButton = base.GetWebElementPropertiesByXPath
                (SIM5FramePageResource.
                 SIM5Frame_Page_New_Excel_Workbook_Xpath_Locator);
            //Click on Excel blank workbook icon button

            base.ClickByJavaScriptExecutor(getBlankWorkbookIconButton);
            SaveFilesInUSB();
            Logger.LogMethodExit("SIM5FramePage",
                "AnswersFirstExcelQuestion",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save office file in USB in SIM5.
        /// </summary>
        private void SaveFilesInUSB()
        {
            //Save office file in USB in SIM5        
            Logger.LogMethodEntry("SIM5FramePage",
                    "SaveFilesInUSB",
                   base.IsTakeScreenShotDuringEntryExit);
            //Get Excel save icon button Property
            IWebElement getSaveIconButton = base.GetWebElementPropertiesByXPath
                (SIM5FramePageResource.
                SIM5Frame_Page_Excel_Save_Xpath_Locator);
            //Click on save icon button
            base.ClickByJavaScriptExecutor(getSaveIconButton);
            //Get  computer browse icon button Property
            IWebElement getComputerBrowseIconButton = base.GetWebElementPropertiesByXPath
                (SIM5FramePageResource.
                 SIM5Frame_Page_Save_MyComputer_Browse_Xpath_Locator);
            //Click on computer browse icon button
            base.ClickByJavaScriptExecutor(getComputerBrowseIconButton);
            //Get  USB disk icon button Property
            IWebElement getUSBDiskIconButton = base.GetWebElementPropertiesByXPath
                (SIM5FramePageResource.
                 SIM5Frame_Page_Save_USB_Disk_Xpath_Locator);
            //Click on USB disk icon button
            base.ClickByJavaScriptExecutor(getUSBDiskIconButton);

            //Get  New Folder button Property
            IWebElement getNewFolderButton = base.GetWebElementPropertiesById
                (SIM5FramePageResource.
                 SIM5Frame_Page_Save_New_Folder_ID_Locator);
            //Click on New Folder button
            base.ClickByJavaScriptExecutor(getNewFolderButton);
            //Get created new folder Property
            IWebElement getNewFolderName = base.GetWebElementPropertiesByClassName
                (SIM5FramePageResource.
                SIM5Frame_Page_SIM5_New_Folder_Class_Name);
            //focus on created new folder
            base.FocusOnElementByClassName(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_New_Folder_Class_Name);
            //Select all in New folder Text box
            base.ClearTextByClassName((SIM5FramePageResource.
                SIM5Frame_Page_SIM5_New_Folder_Class_Name));
            //Rename Folder name
            base.FillTextBoxByClassName(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_New_Folder_Class_Name,
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Folder_Name);

            //Press Enter Key in New Folder text box
            base.PressEnterKeyByClassName(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_New_Folder_Class_Name);
            //Get open button Property
            IWebElement getOpenFileButton = base.GetWebElementPropertiesById
                (SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Open_button_Id_Locator);
            //Click on open button
            base.ClickByJavaScriptExecutor(getOpenFileButton);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));

            //Select all in file name Text box
            base.ClearTextById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Save_File_TextBox_Id_Locator);
            //SSave file name
            base.FillTextBoxById(SIM5FramePageResource.
                 SIM5Frame_Page_SIM5_Save_File_TextBox_Id_Locator,
                 SIM5FramePageResource.
                 SIM5Frame_Page_SIM5_Save_Excel_File_Name);

            //Get save button Property
            IWebElement getSaveFileButton = base.GetWebElementPropertiesById(
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Save_button_Id_Locator);
            //Click on  save button
            base.ClickByJavaScriptExecutor(getSaveFileButton);

            Logger.LogMethodExit("SIM5FramePage",
                "SaveFilesInUSB",
              base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Second Question
        /// <summary>
        /// Answers Entering Text Using AutoComplete And Using The NameBox To Select A Cell.
        /// </summary>
        private void EnteringTextUsingAutoCompleteAndUsingTheNameBoxToSelectACell()
        {
            //Answer second Excel Question       
            Logger.LogMethodEntry("SIM5FramePage",
                    "AnswerSecondExcelQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
            //Fill A1 cell value
            PutExcelValueInCell(
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_A1_Cell_Id,
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_First_Activity_A1_Cell_Value);
            //Fill A2 cell value
            PutExcelValueInCell(
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_A2_Cell_Id,
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_First_Activity_A2_Cell_Value);
            //Fill A4 cell value
            PutExcelValueInCell(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_A4_Cell_Id,
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_First_Activity_A4_Cell_Value);
            //Fill A5 cell value
            PutExcelValueInCell(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_A5_Cell_Id,
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_First_Activity_A5_Cell_Value);
            Logger.LogMethodExit("SIM5FramePage",
                "AnswerSecondExcelQuestion",
              base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Third Question
        /// <summary>
        /// Answers Autofill and Keyboard shortcuts
        /// </summary>     
        private void AutoFillAndKeyboardShortcuts()
        {
            //Answer third Excel Question       
            Logger.LogMethodEntry("SIM5FramePage",
                    "AutoFillAndKeyboardShortcuts",
                   base.IsTakeScreenShotDuringEntryExit);
            //Fill B3 cell value
            PutExcelValueInCell(
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_B3_Cell_Id,
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_First_Activity_ThirdQuestion_B3_Cell_Value);
            //Clear reference box
            base.ClearTextById(SIM5FramePageResource.
               SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in reference box
            base.FillTextBoxById(SIM5FramePageResource.
               SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator, SIM5FramePageResource.
               SIM5Frame_Page_SIM5_Excel_B3_Cell_Id);
            //Press enter
            this.PressEnterKeyById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Wait for element Border bullet for cell B3
            base.WaitForElement(By.ClassName(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Cell_B3_BorderBullet_ClassName_Locator));
            //Get web element property for border bullet element
            IWebElement getBorderBullet = base.GetWebElementPropertiesByClassName(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Cell_B3_BorderBullet_ClassName_Locator);
            //select and drag the range B3:D3        
            base.PerformDragAndDropToOffset(getBorderBullet,
                Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_D3_Cell_OffsetX),
                Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_D3_Cell_OffsetY));
            Logger.LogMethodExit("SIM5FramePage",
                "AutoFillAndKeyboardShortcuts",
              base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Fourth Question
        /// <summary>
        /// Setting Cell Width And Selecting Cell Range To Align Data.
        /// </summary>
        public void SettingCellWidthAndSelectingCellRangeToAlignData()
        {
            //Submit SIM5 Excel type activity
            Logger.LogMethodEntry("SIM5FramePage",
            "SettingCellWidthAndSelectingCellRangeToAlignData",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Set Cell Width
                this.SetCellWidth();
                //Select Cell Range And Align Data
                this.SelectCellRangeAndAlignData();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SIM5FramePage",
            "SettingCellWidthAndSelectingCellRangeToAlignData",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Set excel spread sheet Cell Width.
        /// </summary>
        private void SetCellWidth()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "SetCellWidth",
            base.IsTakeScreenShotDuringEntryExit);

            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Sleep_Time));
            //Clear Reference Box
            base.ClearTextById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in Reference Box
            base.FillTextBoxById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator,
            SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_A1_Cell_Id);
            //Press Enter in Reference Box
            PressEnterKeyById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //click on Format button
            this.ClickFormatColumnWidth();
            //Clear the Column Width value text box
            base.ClearTextById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_ColumnWidth_TextBox_ID_Locator);
            //enter the desired value in column width text box
            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_ColumnWidth_TextBox_ID_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_ColumnWidth_Value);
            //Get property for Column width OK button
            IWebElement clickOKButton = base.GetWebElementPropertiesById(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_ColumnWidth_OK_Button_ID_Locator);
            //click on ok button for setting the column width value
            base.ClickByJavaScriptExecutor(clickOKButton);

            Logger.LogMethodExit("SIM5FramePage",
            "SetCellWidth",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click Format Column Width.
        /// </summary>
        private void ClickFormatColumnWidth()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "ClickFormatColumnWidth",
            base.IsTakeScreenShotDuringEntryExit);

            int count = 0;
            // get the collection of menu tools by CssSelector using class names
            ICollection<IWebElement> getCellsToolsCollection = base.GetWebElementsCollectionByPartialCssSelector(
                SIM5FramePageResource.SIM5Frame_Page_MenuToolsObject_Collection_CssSelector);
            foreach (IWebElement cellToolOption in getCellsToolsCollection)
            {
                // from the above collection get the specific tool object that we wish to click
                if (count == 2)
                {
                    base.PerformMouseHoverAction(cellToolOption);
                    base.ClickByJavaScriptExecutor(cellToolOption);
                    break;
                }
                count++;
            }
            count = 0;
            // get the collection of objects of various tools available in Format dropdown by CssSelector using class names
            ICollection<IWebElement> getFormatToolCollection = base.GetWebElementsCollectionByPartialCssSelector(
                SIM5FramePageResource.SIM5Frame_Page_FormatToolsObject_Collection_CssSelector);
            foreach (IWebElement formatTool in getFormatToolCollection)
            {
                // from the above collection get the specific tool object that we wish to click
                if (count == 2)
                {
                    base.PerformMouseHoverAction(formatTool);
                    base.ClickByJavaScriptExecutor(formatTool);
                    break;
                }
                count++;
            }

            Logger.LogMethodExit("SIM5FramePage",
            "ClickFormatColumnWidth",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select Cell Range And Align Data.
        /// </summary>
        private void SelectCellRangeAndAlignData()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "SelectCellRangeAndAlignData",
            base.IsTakeScreenShotDuringEntryExit);

            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Sleep_Time));
            //Clear Reference Box
            base.ClearTextById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in Reference Box
            base.FillTextBoxById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B3_Cell_Id);
            //Press Enter in Reference Box
            PressEnterKeyById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Get property B3 Cell
            IWebElement getCellB3 = base.GetWebElementPropertiesById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_B3_Cell_ID_Locator);
            //Get property D3 Cell
            IWebElement getCellD3 = base.GetWebElementPropertiesById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_D3_Cell_ID_Locator);
            //select and drag the range B3:D3
            base.PerformDragAndDropAction(getCellB3, getCellD3);
            // Click Center Alighment Button
            this.ClickCenterAlighmentButton();

            Logger.LogMethodExit("SIM5FramePage",
            "SelectCellRangeAndAlignData",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click Center Alighment Button.
        /// </summary>
        private void ClickCenterAlighmentButton()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "ClickCenterAlighmentButton",
            base.IsTakeScreenShotDuringEntryExit);

            int count = 0;
            // get the collection of Alignment tool options by CssSelector using class names
            ICollection<IWebElement> getAlighmentOptionsCollection = base.GetWebElementsCollectionByPartialCssSelector(
                SIM5FramePageResource.SIM5Frame_Page_AlignmentObjects_Collection_CssSelector);
            foreach (IWebElement AlignmentOption in getAlighmentOptionsCollection)
            {
                // from the above collection get the specific tool object that we wish to click
                if (count == 4)
                {
                    base.PerformMouseHoverAction(AlignmentOption);
                    base.ClickByJavaScriptExecutor(AlignmentOption);
                    break;
                }
                count++;
            }

            Logger.LogMethodExit("SIM5FramePage",
            "ClickCenterAlighmentButton",
            base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Fifth Question
        /// <summary>
        /// Setting Data In Cell.
        /// </summary>
        public void SettingDataInCell()
        {
            //Answer second Excel Question
            Logger.LogMethodEntry("SIM5FramePage",
            "SettingDataInCell",
            base.IsTakeScreenShotDuringEntryExit);
            //Fill B4 cell value
            PutExcelValueInCellAndPressFormulaButtonCenter(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B4_Cell_Id,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B4_Cell_Value);
            //Fill C4 cell value
            PutExcelValueInCellAndPressFormulaButtonCenter(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_C4_Cell_Id,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_C4_Cell_Value);
            //Fill D4 cell value
            PutExcelValueInCellAndPressFormulaButtonCenter(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_D4_Cell_Id,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_D4_Cell_Value);

            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Sleep_Time));

            //Fill B5 cell value
            PutExcelValueInCellAndPressFormulaButtonCenter(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B5_Cell_Id,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B5_Cell_Value);
            //Fill C5 cell value
            PutExcelValueInCellAndPressFormulaButtonCenter(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_C5_Cell_Id,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_C5_Cell_Value);
            //Fill D5 cell value
            PutExcelValueInCellAndPressFormulaButtonCenter(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_D5_Cell_Id,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_D5_Cell_Value);

            Logger.LogMethodExit("SIM5FramePage",
            "SettingDataInCell",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Put Excel Value In Cell And Press Formula Button Center.
        /// </summary>
        /// <param name="refCell">Cell Id</param>
        /// <param name="formulaValue">Cell value</param>
        private void PutExcelValueInCellAndPressFormulaButtonCenter(string referenceCellId, string dataValue)
        {
            //Fill Excel cell
            Logger.LogMethodEntry("SIM5FramePage",
            "PutExcelValueInCellAndPressFormulaButtonCenter",
            base.IsTakeScreenShotDuringEntryExit);

            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Sleep_Time));

            //Clear Reference Box
            base.ClearTextById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in Reference Box
            base.FillTextBoxById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator, referenceCellId);
            //Press Enter in Reference Box
            PressEnterKeyById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);

            //Clear Formula Box
            base.ClearTextById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //Fill vlaue in Formula Box
            base.FillTextBoxById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator, dataValue);
            //Get WebElement object for Cell A1
            IWebElement cellA1 = base.GetWebElementPropertiesById(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A1_Cell_ID_Locator);
            //Click on Cell A1 inorder to commit the change made to the Formula Box above
            base.PerformMouseClickAction(cellA1);

            Logger.LogMethodExit("SIM5FramePage",
            "PutExcelValueInCellAndPressFormulaButtonCenter",
            base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Sixth Question
        /// <summary>
        /// Answers Constructing A Formula And Using The Sum Function.
        /// </summary>
        private void ConstructingAFormulaAndUsingTheSumFunction()
        {
            //Answer second Excel Question       
            Logger.LogMethodEntry("SIM5FramePage",
                    "ConstructingAFormulaAndUsingTheSumFunction",
                   base.IsTakeScreenShotDuringEntryExit);
            //Fill B8 cell value
            PutExcelValueInCell(
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_B8_Cell_Id,
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_First_Activity_B8_Cell_Value);
            //Fill C8 cell value
            PutExcelValueInCell(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_C8_Cell_Id,
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_First_Activity_C8_Cell_Value);
            //Fill D8 cell value
            PutExcelValueInCell(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_D8_Cell_Id,
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_First_Activity_D8_Cell_Value);
            Logger.LogMethodExit("SIM5FramePage",
                "ConstructingAFormulaAndUsingTheSumFunction",
              base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Seventh Question
        /// <summary>
        /// Copying a Formula by Using the Fill Handle.
        /// </summary>
        private void CopyingAFormulaByUsingTheFillHandle()
        {

            Logger.LogMethodEntry("SIM5FramePage",
            "CopyingAFormulaByUsingTheFillHandle",
            base.IsTakeScreenShotDuringEntryExit);

            // Question Part 1: sum the numeric data in the specified columns/cells
            this.SumColumnNumericData();
            // Question Part 2: apply the same Sum formula to multiple cells of the specified column
            this.ApplySumFormulaToMultipleCells();
            // Question Part 3: Fill F3 cell value
            this.PutExcelValueInCell(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_F3_Cell_Id,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_SeventhQuestion_ColumnData_Trend);

            Logger.LogMethodExit("SIM5FramePage",
            "CopyingAFormulaByUsingTheFillHandle",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Apply the same Sum formula to multiple cells of the specified column.
        /// </summary>
        private void ApplySumFormulaToMultipleCells()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "ApplySumFormulaToMultipleCells",
            base.IsTakeScreenShotDuringEntryExit);

            //Wait for element Border bullet for cell E4
            base.WaitForElement(By.ClassName(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Cell_B3_BorderBullet_ClassName_Locator));
            //Get web element property for border bullet element
            IWebElement getBorderBullet = base.GetWebElementPropertiesByClassName(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Cell_B3_BorderBullet_ClassName_Locator);
            //Drag the Cell E4 down through E5:E8
            base.PerformDragAndDropToOffset(getBorderBullet,
                Convert.ToInt16(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_Border_DragDrop_XYOffset),
                Convert.ToInt16(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_Border_DragDrop_XYOffset));

            Logger.LogMethodExit("SIM5FramePage",
            "ApplySumFormulaToMultipleCells",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Sum the numeric data in the specified columns/cells.
        /// </summary>
        private void SumColumnNumericData()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "SumColumnNumericData",
            base.IsTakeScreenShotDuringEntryExit);

            //Fill E3 cell value
            this.PutExcelValueInCell(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E3_Cell_Id,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E3_Cell_Value);
            //Fill E4 cell value
            this.PutExcelValueInCell(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E4_Cell_Id,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E4_Cell_Value);
            //Clear reference box
            base.ClearTextById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in reference box
            base.FillTextBoxById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E4_Cell_Id);
            //Press enter
            this.PressEnterKeyById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);

            Logger.LogMethodExit("SIM5FramePage",
            "SumColumnNumericData",
            base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Eighth Question
        /// <summary>
        /// Using Merger And Center And Applying CellStyles.
        /// </summary>
        private void UsingMergerAndCenterAndApplyingCellStyles()
        {

            Logger.LogMethodEntry("SIM5FramePage",
            "UsingMergerAndCenterAndApplyingCellStyles",
            base.IsTakeScreenShotDuringEntryExit);

            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                       SIM5Frame_Page_SIM5_Launch_Sleep_Time));
            // Select cell range from cell A1 to cell F1
            this.SelectTherangeA1ToF1();
            // Click Merge and Center to merge and center align the data in cells A1 to F1
            this.MergeAndCenter();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));
            // Open the Cell Style Dropdown
            this.OpenCellStyleDropdown();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));
            // Set the cell style as 'Title'
            this.SetTheCellStyleTitle();
            // Select cell range from cell A2 to cell F2
            this.SelectTheRangeA2ToF2();
            // Click Merge and Center to merge and center align the data in cells A2 to F2
            this.MergeAndCenter();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));
            // Open the Cell Style Dropdown
            this.OpenCellStyleDropdown();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));
            // Set the cell style as 'Heading1'
            this.SetTheCellStyleHeading1();
            // Select Range And Apply Cell Style
            this.SelectRangeAndApplyCellStyle();

            Logger.LogMethodExit("SIM5FramePage",
            "CopyingAFormulaByUsingTheFillHandle",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select Range And Apply Cell Style Heading4.
        /// </summary>
        private void SelectRangeAndApplyCellStyle()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "SelectRangeAndApplyCellStyle",
            base.IsTakeScreenShotDuringEntryExit);

            //Clear reference box
            base.ClearTextById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in reference box
            base.FillTextBoxById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B3_Cell_Id);
            //Press enter
            this.PressEnterKeyById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B3_Cell_ID_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_F3_Cell_ID_Locator);
            // Press and hold the CTRL key
            base.PerformCTRLKeyDown();
            // select the desired cell range
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A4_Cell_ID_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A8_Cell_ID_Locator);
            // perform CTRL key up
            base.PerformCTRLKeyUp();

            // open the Cell Style dropdown
            this.OpenCellStyleDropdown();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));
            // select the cell style 'Heading4'
            this.SetTheCellStyleHeading4();

            Logger.LogMethodExit("SIM5FramePage",
            "SelectRangeAndApplyCellStyle",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Set the Cell Style as Title.
        /// </summary>
        private void SetTheCellStyleTitle()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "SetTheCellStyleTitle",
            base.IsTakeScreenShotDuringEntryExit);

            this.SelectCellStyle(Convert.ToInt16(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_CellStyle_Title_CSSLocator_Class_Index));

            Logger.LogMethodExit("SIM5FramePage",
            "SetTheCellStyleTitle",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set the Cell Style as Heading1.
        /// </summary>
        private void SetTheCellStyleHeading1()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "SetTheCellStyleHeading1",
            base.IsTakeScreenShotDuringEntryExit);

            this.SelectCellStyle(Convert.ToInt16(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_CellStyle_Heading1_CSSLocator_Class_Index));

            Logger.LogMethodExit("SIM5FramePage",
            "SetTheCellStyleHeading1",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set the Cell Style as Heading4.
        /// </summary>
        private void SetTheCellStyleHeading4()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "SetTheCellStyleHeading4",
            base.IsTakeScreenShotDuringEntryExit);

            this.SelectCellStyle(Convert.ToInt16(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_CellStyle_Heading4_CSSLocator_Class_Index));

            Logger.LogMethodExit("SIM5FramePage",
            "SetTheCellStyleHeading4",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select The range A2 To F2.
        /// </summary>
        private void SelectTheRangeA2ToF2()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "SelectTheRangeA2ToF2",
            base.IsTakeScreenShotDuringEntryExit);

            //Clear reference box
            base.ClearTextById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in reference box
            base.FillTextBoxById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A2_Cell_Id);
            //Press enter
            this.PressEnterKeyById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);

            //Get property B3 Cell
            IWebElement getCellA2 = base.GetWebElementPropertiesById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_A2_Cell_ID_Locator);
            //Get property D3 Cell
            IWebElement getCellF2 = base.GetWebElementPropertiesById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_F2_Cell_ID_Locator);
            //select and drag the range B3:D3
            base.PerformDragAndDropAction(getCellA2, getCellF2);

            Logger.LogMethodExit("SIM5FramePage",
            "SelectTheRangeA2ToF2",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The range A1 To F1.
        /// </summary>
        private void SelectTherangeA1ToF1()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "SelectTherangeA1ToF1",
            base.IsTakeScreenShotDuringEntryExit);

            //Clear reference box
            base.ClearTextById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in reference box
            base.FillTextBoxById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A1_Cell_Id);
            //Press enter
            this.PressEnterKeyById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);

            //Get property B3 Cell
            IWebElement getCellA1 = base.GetWebElementPropertiesById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_A1_Cell_ID_Locator);
            //Get property D3 Cell
            IWebElement getCellF1 = base.GetWebElementPropertiesById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_F1_Cell_ID_Locator);
            //select and drag the range B3:D3
            base.PerformDragAndDropAction(getCellA1, getCellF1);

            Logger.LogMethodExit("SIM5FramePage",
            "SelectTherangeA1ToF1",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Apply Merge and center
        /// </summary>
        private void MergeAndCenter()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "MergeAndCenter",
            base.IsTakeScreenShotDuringEntryExit);

            IWebElement getMergeAndCenterDropdownObject = base.GetWebElementPropertiesByCssSelector(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_MergeAndCenter_Dropdown_CSS_Selector_Class_Locator);
            base.ClickByJavaScriptExecutor(getMergeAndCenterDropdownObject);
            IWebElement getMergeAndCenterObject = base.GetWebElementPropertiesByCssSelector(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_MergeAndCenter_CSS_Selector_Class_Locator);
            base.ClickByJavaScriptExecutor(getMergeAndCenterObject);

            Logger.LogMethodExit("SIM5FramePage",
            "MergeAndCenter",
            base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Ninth Question
        /// <summary>
        /// Simultaneously Format Multiple Cells.
        /// </summary>
        private void SimultaneouslyFormatMultipleCells()
        {
            Logger.LogMethodEntry("SIM5FramePage",
                    "SimultaneouslyFormatMultipleCells",
                   base.IsTakeScreenShotDuringEntryExit);

            //Part 1
            //Select the desired Cell range
            this.SelectCellRange(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B4_Cell_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E4_Cell_Id_Locator);
            //Click and hold the CTRL keyboard key
            base.PerformCTRLKeyDown();
            //Select the desired Cell range
            this.SelectCellRange(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B8_Cell_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E8_Cell_Id_Locator);
            //Key up the CTRL keyboard key
            base.PerformCTRLKeyUp();
            //Apply the Account Number Format to the cell ranges selected above
            this.ApplyAccountNumberFormat();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));

            //Part 2
            //Select the desired Cell range
            this.SelectCellRange(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B5_Cell_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E7_Cell_Id_Locator);
            //Apply the Comma Style to the cell range select above
            this.ApplyCommaStyle();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));

            //Part 3
            //Select the desired Cell range
            this.SelectCellRange(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B8_Cell_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E8_Cell_Id_Locator);
            //Apply the Total Cell Style to the cell range selected above
            this.OpenCellStyleDropdown();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));
            this.SelectCellStyle(Convert.ToInt16(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_CellStyle_Total_CSSLocator_Class_Index));

            Logger.LogMethodExit("SIM5FramePage",
                "SimultaneouslyFormatMultipleCells",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Apply Comma Style.
        /// </summary>
        private void ApplyCommaStyle()
        {
            Logger.LogMethodEntry("SIM5FramePage",
                    "ApplyCommaStyle",
                   base.IsTakeScreenShotDuringEntryExit);

            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));
            int count = 0;
            ICollection<IWebElement> getStyleCollection = base.GetWebElementsCollectionByPartialCssSelector(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_Comma_CSS_Selector_Class_Collection_Locator);
            foreach (IWebElement style in getStyleCollection)
            {
                // from the collection of style objects we choose the Comma Style object
                if (count == 1)
                {
                    base.PerformMouseHoverAction(style);
                    base.ClickByJavaScriptExecutor(style);
                    break;
                }
                count++;
            }

            Logger.LogMethodExit("SIM5FramePage",
                "ApplyCommaStyle",
              base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Apply Account Number Format.
        /// </summary>
        private void ApplyAccountNumberFormat()
        {
            Logger.LogMethodEntry("SIM5FramePage",
                    "ApplyAccountNumberFormat",
                   base.IsTakeScreenShotDuringEntryExit);

            //Clear Reference Box
            base.ClearTextByCssSelector(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Number_Format_TextBox_CSS_Selector);
            //Fill Cell ID in Reference Box
            base.FillTextBoxByCssSelector(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Number_Format_TextBox_CSS_Selector,
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Number_Format_TextBox_Accounting_Value);
            //Press Enter in Reference Box
            base.PressEnterKeyByCssSelector(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Number_Format_TextBox_CSS_Selector);

            Logger.LogMethodExit("SIM5FramePage",
                "ApplyAccountNumberFormat",
              base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select Cell Range.
        /// </summary>
        private void SelectCellRange(string firstCellID, string lastCellID)
        {
            Logger.LogMethodEntry("SIM5FramePage",
                    "SelectCellRange",
                   base.IsTakeScreenShotDuringEntryExit);

            //Get first cell object
            IWebElement getFirstCellObject = base.GetWebElementPropertiesById(firstCellID);
            //Get Last cell object
            IWebElement getLastCellObject = base.GetWebElementPropertiesById(lastCellID);
            //select and drag the range from the first cell above to the last cell
            base.PerformDragAndDropAction(getFirstCellObject, getLastCellObject);

            Logger.LogMethodExit("SIM5FramePage",
                "SelectCellRange",
              base.IsTakeScreenShotDuringEntryExit);
        }

        #endregion

        #region SIM5 Excel Tenth Question
        /// <summary>
        /// Set the Worksheet Theme To Retrospect.
        /// </summary>
        public void SetWorksheetThemeToRetrospect()
        {
            Logger.LogMethodEntry("SIM5FramePage",
                    "SetWorksheetThemeToRetrospect",
                   base.IsTakeScreenShotDuringEntryExit);

            //Click on PageLayout file menu item
            IWebElement getPageLayoutMenuItem = base.GetWebElementPropertiesByCssSelector(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_PageLayout_Menu);
            base.ClickByJavaScriptExecutor(getPageLayoutMenuItem);
            //Click on Themes icon
            IWebElement getThemesIcon = base.GetWebElementPropertiesByCssSelector(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_Themes_Dropdown_CSSSelector);
            base.ClickByJavaScriptExecutor(getThemesIcon);
            // Get the Themes Objects collection
            ICollection<IWebElement> themesCollection = base.GetWebElementsCollectionByPartialCssSelector(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_ThemeObjects_Collection_CSSSelector);
            foreach (IWebElement theme in themesCollection)
            {
                // Get the Retrospect theme from the above collection and click on it
                if (theme.GetAttribute(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Excel_ThemeObjects_Title_Attribute).Equals(
                    SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Excel_ThemeObjects_Retrospect_Title_Value))
                {
                    base.ClickByJavaScriptExecutor(theme.FindElement(By.XPath(SIM5FramePageResource.
                        SIM5Frame_Page_SIM5_Excel_ThemeObjects_Title_Retrospect_XPath_Locator)));
                }
            }

            Logger.LogMethodExit("SIM5FramePage",
                "SetWorksheetThemeToRetrospect",
              base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Common Functions

        /// <summary>
        /// Apply Total Cell Style.
        /// </summary>
        private void OpenCellStyleDropdown()
        {
            Logger.LogMethodEntry("SIM5FramePage",
                "OpenCellStyleDropdown",
               base.IsTakeScreenShotDuringEntryExit);

            // Get the menu tool objects collection
            ICollection<IWebElement> getExcelStylesCollection = base.GetWebElementsCollectionByPartialCssSelector(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_Styles_Collection_CSSSelector_Locator);
            int count = 0;
            foreach (IWebElement ExcelStyleObject in getExcelStylesCollection)
            {
                // Get the Excel Style tool object from the above collection and then click it to open the dropdown
                if (count == 2)
                {
                    base.PerformMouseHoverAction(ExcelStyleObject);
                    base.ClickByJavaScriptExecutor(ExcelStyleObject);
                    break;
                }
                count++;
            }

            Logger.LogMethodExit("SIM5FramePage",
                "OpenCellStyleDropdown",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the appropriate Cell Style.
        /// </summary>
        /// <param name="countCellStyle">the cell style count</param>
        private void SelectCellStyle(int countCellStyle)
        {
            Logger.LogMethodEntry("SIM5FramePage",
                "SelectCellStyle",
               base.IsTakeScreenShotDuringEntryExit);

            // Get the style objects collection from the Cell Styles dropdown
            ICollection<IWebElement> getCellStylesCollection = base.GetWebElementsCollectionByPartialCssSelector(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_Cell_Styles_Collection_CSSSelector_Locator);
            int count = 0;
            foreach (IWebElement CellStyle in getCellStylesCollection)
            {
                // from the above collection find the 'Total' Cell Style and click it
                if (count == countCellStyle)
                {
                    base.PerformMouseHoverAction(CellStyle);
                    base.ClickByJavaScriptExecutor(CellStyle);
                    break;
                }
                count++;
            }

            Logger.LogMethodExit("SIM5FramePage",
                "SelectCellStyle",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Excel cell.
        /// </summary>
        /// <param name="refCell">Cell Id</param>
        /// <param name="formulaValue">Cell value</param>
        private void PutExcelValueInCell(string referenceCellId, string formulaValue)
        {
            //Fill Excel cell
            Logger.LogMethodEntry("SIM5FramePage",
                "PutExcelValueInCell",
               base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));
            //Clear Reference Box
            base.ClearTextById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in Reference Box 
            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator, referenceCellId);
            //Press Enter in Reference Box
            PressEnterKeyById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Clear Formula Box
            base.ClearTextById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //Fill vlaue in Formula Box 
            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator, formulaValue);
            //Press Enter in Formula Box
            PressEnterKeyById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            Logger.LogMethodExit("SIM5FramePage",
                "PutExcelValueInCell",
              base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Activity Submission

        /// <summary>
        /// Click On SIM5 Activity Submit Button.
        /// </summary>
        public void ClickOnSIM5ActivitySubmitButton()
        {
            Logger.LogMethodEntry("SIM5FramePage", "ClickOnSIM5ActivitySubmitButton",
            base.IsTakeScreenShotDuringEntryExit);

            //Click on Ok button
            IWebElement getSubmitButton = base.GetWebElementPropertiesById
            (SIM5FramePageResource.
            SIM5Frame_Page_Submit_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(getSubmitButton);

            //Get the Submit Assignment 'OK' button as WebElement
            IWebElement getSubmitAssignment = base.GetWebElementPropertiesByXPath
            (SIM5FramePageResource.
            SIM5Frame_Page_SubmitAssignment_OK_Button_Id_Locator);
            //Click on the Submit Assignment 'OK' button
            base.ClickByJavaScriptExecutor(getSubmitAssignment);
            Logger.LogMethodExit("SIM5FramePage", "ClickOnSIM5ActivitySubmitButton",
            base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion
    }
}
