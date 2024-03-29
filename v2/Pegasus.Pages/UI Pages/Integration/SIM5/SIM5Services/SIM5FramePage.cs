﻿using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.SIM5.SIM5Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Keys = OpenQA.Selenium.Keys;
using System.Threading;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UITesting;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Pegasus.Automation;
using System.IO;
using Pegasus.Pages.CommonPageObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Discussion;


namespace Pegasus.Pages.UI_Pages
{
    public class Sim5FramePage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Sim5FramePage));
        PowerPointSim5Activity powerPoint = new PowerPointSim5Activity();

        /// <summary>
        /// Submit SIM5 Type Activity To Score.
        /// <param name="activityName">This is activity name.</param>
        /// /// <param name="score">This is achieve score.</param>
        /// </summary>
        public void SubmitSimActivityWithScore(string activityName, string score)
        {
            Logger.LogMethodEntry("SIM5FramePage",
               "SubmitSimActivityWithScore",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (score)
                {
                    case "100%":
                        // complete question based on asset name
                        switch (activityName)
                        {
                            case "Excel Chapter 1 Skill-Based Training":

                                this.SubmitSim5ExcelActivityExcelChapter1SkillBasedTrainingToScore100(activityName);
                                break;
                            case "Access Chapter 1 Skill-Based Exam (Scenario 1)":
                                this.SubmitSim5AccessChapter1Project1ASkillBasedExamScenario1ToScore100(activityName);
                                break;
                        }
                        break;

                    case "70%":
                        // complete question based on asset name
                        switch (activityName)
                        {
                            case "Excel Chapter 1 Skill-Based Training":
                                this.SubmitSim5ExcelActivityExcelChapter1SkillBasedTrainingToScore70(activityName);
                                break;
                            case "Access Chapter 1 Skill-Based Exam (Scenario 1)":
                                this.SubmitSim5AccessActivityPostTestSeventyPercentScore(activityName);
                                break;
                        }
                        break;
                }
                //Click on SIM5 activity Submit button
                this.ClickOnSIM5ActivitySubmitButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("SIM5FramePage", "SubmitSimActivityWithScore",
              base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Submit SIM5 Excel type activity to score 100%.
        /// <param name="activityName">This is activity name.</param>
        /// </summary>
        private void SubmitSim5ExcelActivityExcelChapter1SkillBasedTrainingToScore100(String activityName)
        {
            //Submit SIM5 Excel type activity
            Logger.LogMethodEntry("SIM5FramePage",
                "SubmitSim5ExcelActivityExcelChapter1SkillBasedTrainingToScore100",
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
                powerPoint.JumpToQuestion("2");
                this.EnteringTextUsingAutoCompleteAndUsingTheNameBoxToSelectACell();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                ////Answer third question
                //this.AutoFillAndKeyboardShortcuts();
                //Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                //    SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                powerPoint.JumpToQuestion("4");
                // Answer Fourth question
                this.SettingCellWidthAndSelectingCellRangeToAlignData();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                   SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                powerPoint.JumpToQuestion("5");
                //Answer Fifth excel quetion
                this.SettingDataInCell();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                   SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                powerPoint.JumpToQuestion("6");
                //Anser sixth question
                this.ConstructingAFormulaAndUsingTheSumFunction();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                //Answer Seventh Question
                //this.CopyingAFormulaByUsingTheFillHandle();
                //Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                //    SIM5Frame_Page_SIM5_Sleep_Time));
                powerPoint.JumpToQuestion("8");
                //Answer Eighth Question
                this.UsingMergerAndCenterAndApplyingCellStyles();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Sleep_Time));
                powerPoint.JumpToQuestion("9");
                //Answer Ninth Question
                this.SimultaneouslyFormatMultipleCells();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Sleep_Time));
                powerPoint.JumpToQuestion("10");
                //Answer Tenth Question
                this.SetWorksheetThemeToRetrospect();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                       SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                powerPoint.JumpToQuestion("11");
                //Answer Eleventh Question
                this.ChartingDataUsingRecomendedChartsInsertChart();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                     SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                powerPoint.JumpToQuestion("13");
                //Answer Twelfth Question
                //this.UsingChartToolsSetChartLayoutsandStyles();
                //Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                //     SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                //Answer Thirteenth Question
                this.CreatingandFormattingSparkLines();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                     SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                //Answer fourteenth Question
                powerPoint.JumpToQuestion("14");
                this.SetMarginsAndPageLayout();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Fifteenth Question
                powerPoint.JumpToQuestion("15");
                this.DisplayDocumentProperties();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Sixteenth Question
                powerPoint.JumpToQuestion("16");
                this.PrintingUsingKeyboard();
                //Answer Seventeenth Question
                powerPoint.JumpToQuestion("17");
                this.ChangingPageDetailsandFormulas();
                //Answer Eighteenth Question
                powerPoint.JumpToQuestion("18");
                this.SpellCheckingSheet();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));
                powerPoint.JumpToQuestion("19");
                //Answer Nineteenth Question
                this.EnteringDataByRange();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Twentyth Question
                powerPoint.JumpToQuestion("20");
                this.ApplyNumberingtoCells();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Twenty First Question
                powerPoint.JumpToQuestion("21");
                this.UsingQuickAnalysisTool();
                ////Answer Twenty Second Question
                powerPoint.JumpToQuestion("22");
                this.CopyingFormulasContainingAbsoluteCellReferences();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Twentythird Question
                powerPoint.JumpToQuestion("23");
                this.EditingTheValuesInWorksheet();
                //Answer Twentyfourth question
                powerPoint.JumpToQuestion("24");
                new StudentPresentationPage().getQuestionNumber(24);
                this.FormatCellWithPercentStyle();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                powerPoint.JumpToQuestion("25");
                //Answer Tewntyfifth Question

                this.insertAndDeletingRows();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                powerPoint.JumpToQuestion("26");
                //Answer TewntySixth Question
                this.AdjustingcolumnAndText();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                //Answer TwentySeventh Question
                powerPoint.JumpToQuestion("27");
                this.ChangingWorkSheetTheme();
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
                 "SubmitSim5ExcelActivityExcelChapter1SkillBasedTrainingToScore100",
               base.IsTakeScreenShotDuringEntryExit);
        }

        #region SIM5 TewntyThrid Question
        /// <summary>
        /// Editing the Values In Workbook.
        /// </summary>
        private void EditingTheValuesInWorksheet()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "EditingTheValuesInWorksheet", base.IsTakeScreenShotDuringEntryExit);

            IWebElement getB5Cell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B5_Cell_Id_Locator);
            Thread.Sleep(2000);
            base.PerformMouseClickAction(getB5Cell);
            Thread.Sleep(2000);
            this.EnterValuesToSelectedCell(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B5_Cell_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B5_Cell_Integer_Value);
            IWebElement getD8Cell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_D8_Cell_ID_Locator);
            Thread.Sleep(2000);
            base.PerformMouseClickAction(getD8Cell);
            Thread.Sleep(2000);
            this.EnterValuesToSelectedCell(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_D8_Cell_ID_Locator
            , SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel__D8_Cell_Decimal_Value);
            IWebElement getA2Cell = base.GetWebElementPropertiesById(
          "Sheet1_A2");
            Thread.Sleep(2000);
            base.PerformMouseClickAction(getA2Cell);
            Thread.Sleep(2000);
            base.ClearTextById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //Fill vlaue in Formula Box 
            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A2_Cell_Text_Value);
            Thread.Sleep(2000);
            PressEnterKeyById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            IWebElement getB3Cell = base.GetWebElementPropertiesById(
         SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B3_Cell_ID_Locator);
            Thread.Sleep(2000);
            base.PerformMouseClickAction(getB3Cell);
            Thread.Sleep(2000);
            base.ClearTextById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //Fill vlaue in Formula Box 
            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B3_Cell_Text_Value);
            Thread.Sleep(2000);
            PressEnterKeyById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);

            Logger.LogMethodExit("SIM5FramePage",
            "EditingTheValuesInWorksheet", base.IsTakeScreenShotDuringEntryExit);

        }

        private void AppendTheTextInsideCell(string CellID, string CellValue)
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "AppendTheTextInsideCell", base.IsTakeScreenShotDuringEntryExit);

            IWebElement getB3Cell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B3_Cell_ID_Locator);
            base.PerformMouseClickAction(getB3Cell);
            base.ClearTextById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in Reference Box 
            base.FillTextBoxById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator, CellID);
            base.ClearTextById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //Fill vlaue in Formula Box 
            base.FillTextBoxById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator, CellValue);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Launch_Sleep_Time));
            base.PressKey(SIM5FramePageResource.SIM5Frame_Page_SIM5_EnterKey_Value);

            Logger.LogMethodExit("SIM5FramePage",
            "AppendTheTextInsideCell", base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Tewntyfifth Question
        /// <summary>
        /// Inserting and Deleting Rows in Workbook.
        /// </summary>
        private void insertAndDeletingRows()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "insertAndDeletingRows", base.IsTakeScreenShotDuringEntryExit);
            //rightclick on Row 3 and select Insert
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_A3_Cell_Id_Locator));
            IWebElement Test = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A3_Cell_Id_Locator);
            Thread.Sleep(3000);
            base.PerformMouseRightClickAction(Test);
            Thread.Sleep(3000);
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_InsertRowButton_Xpath_Locator), 10);
            IWebElement InsertCdolButton = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_InsertRowButton_Xpath_Locator);
            Thread.Sleep(3000);
            base.PerformMoveToElementClickAction(InsertCdolButton);
            Thread.Sleep(3000);
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_RowButton_Xpath_Locator));
            IWebElement insertOption = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_RowButton_Xpath_Locator);
            Thread.Sleep(3000);
            base.PerformMouseClickAction(insertOption);
            Thread.Sleep(3000);
            IWebElement OkButton = base.GetWebElementPropertiesByXPath(
           SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_InsertOkButton_Xpath_Locator);
            Thread.Sleep(3000);
            base.PerformMoveToElementClickAction(OkButton);
            Thread.Sleep(3000);

            //type As of September 30 press Enter
            IWebElement getA3Cell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A3_Cell_Id_Locator);
            base.PerformMouseClickAction(getA3Cell);
            this.PutExcelValueInCell(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_A3_Cell_Id_Locator, SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A3_Cell_Value);
            //select A3:F3
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A3_Cell_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_F3_Cell_ID_Locator);
            //Under Home tab click Merge and center
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_MergeAndcenterLink_Xpath_Locator);

            //click on cell styles
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_cellStyles_Xpath_Locator);

            //select heading 2 inder titles 
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_cellStyles_Heading2_Xpath_Locator);

            //rightclick on column B header and select Insert
            IWebElement getBCell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B_Column_Id_Locator);
            Thread.Sleep(3000);
            base.PerformMouseRightClickAction(getBCell);
            Thread.Sleep(3000);
            IWebElement InsertColButton = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_InsertColButton_Xpath_Locator);
            Thread.Sleep(3000);
            base.PerformMoveToElementClickAction(InsertColButton);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Sleep_Time));
            //rightclick on column D header and select Delete
            IWebElement getDCell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_D_Column_Id_Locator);
            base.PerformMouseRightClickAction(getDCell);
            IWebElement DeleteColButton = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_DeleteColButton_Xpath_Locator);
            base.PerformMoveToElementClickAction(DeleteColButton);

            Logger.LogMethodExit("SIM5FramePage",
            "insertAndDeletingRows", base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 TewntySixth Question
        /// <summary>
        /// Adjusting column and Textarea in Workbook.
        /// </summary>
        private void AdjustingcolumnAndText()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "AdjustingcolumnAndText", base.IsTakeScreenShotDuringEntryExit);

            //click and drag from B:F
            IWebElement getBCell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B_Column_Id_Locator);
            base.PerformMouseClickAction(getBCell);
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B_Column_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_F_Column_Id_Locator);
            //minimize the size of B to (12.86)95px
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_FormatButton_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_ColumnWidthButton_Xpath_Locator);

            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_ColumnWidthTextBox_Xpath_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_ColumnWidthTextBox_Value);

            IWebElement clickOKButton = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_ColumnWidth_OK_Button_ID_Locator);
            Thread.Sleep(2000);
            base.ClickByJavaScriptExecutor(clickOKButton);
            Thread.Sleep(2000);

            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_ScrollButton_Xpath_Locator));
            IWebElement scroll = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_ScrollButton_Xpath_Locator);
            Thread.Sleep(3000);
            for (int i = 0; i < 18; i++)
                base.PerformMouseClickAction(scroll);
            //select from B4:F4

            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_B4_Cell_Id_Locator));
            IWebElement getB4Cell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B4_Cell_Id_Locator);
            Thread.Sleep(3000);
            base.PerformMouseClickAction(getB4Cell);
            Thread.Sleep(3000);

            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B4_Cell_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_F4_Cell_ID_Locator);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Sleep_Time));
            //click on wrap text under home tab 
            powerPoint.ClickOnElementByCssSelector(SIM5FramePageResource.
             SIM5Frame_Page_SIM5_Excel_wrapTextButton_Menu_CSSLocator);

            //click on center under alignment group 
            powerPoint.ClickOnElementByCssSelector(SIM5FramePageResource.
              SIM5Frame_Page_SIM5_Excel_centerAlignButton_Menu_CSSLocator);

            //click middle align
            powerPoint.ClickOnElementByCssSelector(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_middleAlignButton_Menu_CSSLocator);

            //click on cell styles
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_cellStyles_Xpath_Locator);

            //select heading 4 inder titles 
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_cellStyles_Heading4_Xpath_Locator);

            //click on A11
            IWebElement getA11Cell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A11_Cell_ID_Locator);
            base.PerformMouseClickAction(getA11Cell);
            //click on cell styles
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
               SIM5Frame_Page_SIM5_Excel_cellStyles_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
             SIM5Frame_Page_SIM5_Excel_cellStyles_ThemedStyleButton_Xpath_Locator);


            //Select B5:B10
            IWebElement getB5Cell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B5_Cell_Id_Locator);
            base.PerformMouseClickAction(getB5Cell);
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B5_Cell_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B10_Cell_ID_Locator);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Sleep_Time));

            powerPoint.ClickOnElementByCssSelector(SIM5FramePageResource.
             SIM5Frame_Page_SIM5_Excel_centerAlignButton_Menu_CSSLocator);

            Logger.LogMethodExit("SIM5FramePage",
            "AdjustingcolumnAndText", base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 TewntySeventh Question
        /// <summary>
        /// Adjusting column and Textarea in Workbook.
        /// </summary>
        private void ChangingWorkSheetTheme()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "ChangingWorkSheetTheme", base.IsTakeScreenShotDuringEntryExit);
            //click on Page Layout
            powerPoint.ClickOnElementByCssSelector(SIM5FramePageResource
                .SIM5Frame_Page_SIM5_Excel_Pagelayout_Menu_CSSLocator);

            //click on colors under themes
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_ColorTheme_Xpath_Locator);

            //click on 8th color-Green
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Color_Xpath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
            "ChangingWorkSheetTheme", base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Sixteenth Question
        /// <summary>
        /// Printing Using Keyboard shorcuts.
        /// </summary>
        private void PrintingUsingKeyboard()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "PrintingUsingKeyboard", base.IsTakeScreenShotDuringEntryExit);
            //click on A3 and select A3:F5
            IWebElement getA4Cell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A3_Cell_Id_Locator);
            Thread.Sleep(3000);
            base.PerformMouseClickAction(getA4Cell);
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A3_Cell_Id_Locator,
             SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_F5_Cell_Id_Locator);
            //Press Cntrl+F2
            base.PerformKeyDownThenPressKeyToElement(Keys.Control, Keys.F2, 1);
            // Click on Print Active sheets and select Print Selection
            base.WaitForElement(By.CssSelector(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_PrintStyle_CSSLocator));
            IWebElement PrintOption = base.GetWebElementPropertiesByCssSelector(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_PrintStyle_CSSLocator);
            Thread.Sleep(3000);
            base.PerformMouseClickAction(PrintOption);
            Thread.Sleep(3000);
            IWebElement SelectionButton = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_PrintOption_Xpath_Locator);
            Thread.Sleep(3000);
            base.PerformMouseClickAction(SelectionButton);
            Thread.Sleep(3000);
            //click on Print
            IWebElement PrintButton = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_PrintButtonOption_Id_Locator);
            Thread.Sleep(3000);
            base.PerformMouseClickAction(PrintButton);

            Logger.LogMethodExit("SIM5FramePage",
          "PrintingUsingKeyboard", base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Seventeenth Question
        /// <summary>
        /// Changing PageDetails and Formulas in sheet.
        /// </summary>
        private void ChangingPageDetailsandFormulas()
        {
            Logger.LogMethodEntry("SIM5FramePage",
           "ChangingPageDetailsandFormulas", base.IsTakeScreenShotDuringEntryExit);
            //click on Formulas Tab and show formulas
            IWebElement getFormulasMenuItem = base.GetWebElementPropertiesByCssSelector(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_Formulas_Menu_CSSLocator);
            base.ClickByJavaScriptExecutor(getFormulasMenuItem);
            IWebElement ShowFormulaButton = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_ShowFormulas_Xpath_Locator);
            base.PerformMouseClickAction(ShowFormulaButton);
            //select A:F and double click on right column of A
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A_Column_Id_Locator,
             SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_F_Column_Id_Locator);
            IWebElement getAutoFitSize = base.GetWebElementPropertiesByCssSelector(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_AutoFitForA_CSSLocator);
            base.DoubleClickByJavaScriptExecuter(getAutoFitSize);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Sleep_Time));
            //click on PageLayout ,orientation and select Landscape
            IWebElement getPagelayoutMenuItem = base.GetWebElementPropertiesByCssSelector(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_Pagelayout_Menu_CSSLocator);
            base.ClickByJavaScriptExecutor(getPagelayoutMenuItem);
            IWebElement orientationButton = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_orientationButton_Xpath_Locator);
            base.PerformMouseClickAction(orientationButton);
            IWebElement LandscapeButton = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_LandscapeStyle_Xpath_Locator);
            base.PerformMouseClickAction(LandscapeButton);
            //click on width arrow under scale fit and then click page 1
            IWebElement widthButton = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_WidthArrow_Xpath_Locator);
            base.PerformMouseClickAction(widthButton);
            IWebElement PageOption = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_Page1Option_Xpath_Locator);
            base.PerformMouseClickAction(PageOption);
            Logger.LogMethodExit("SIM5FramePage",
            "ChangingPageDetailsandFormulas", base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Nineteenth Question
        /// <summary>
        /// Apply Numbering and decimal places to Cells
        /// </summary>
        private void EnteringDataByRange()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "EnteringDataByRange", base.IsTakeScreenShotDuringEntryExit);
            //Select Range B4:D9
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B4_Cell_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_D9_Cell_Id_Locator);
            //type 125 in cell B4 and press Enter
            this.EnterValuesToSelectedCell(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B4_Cell_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_19_B4_Cell_Value);
            //type 1125 in cell B5 and press Enter
            this.EnterValuesToSelectedCell(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B5_Cell_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_19_B5_Cell_Value);
            //type 450 in cell B6 and press Enter
            this.EnterValuesToSelectedCell(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B6_Cell_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_19_B6_Cell_Value);
            //type 1105 in cell B7 and press Enter
            this.EnterValuesToSelectedCell(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B7_Cell_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_19_B7_Cell_Value);
            //type 255 in cell B8 and press Enter
            this.EnterValuesToSelectedCell(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B8_Cell_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_19_B8_Cell_Value);
            //type 215 in cell B9 and press Enter
            this.EnterValuesToSelectedCell(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B9_Cell_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_19_B9_Cell_Value);
            //type 15.50 in cell C4 and press Enter
            this.EnterValuesToSelectedCell(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_C4_Cell_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_19_C4_Cell_Value);
            Logger.LogMethodExit("SIM5FramePage",
                "EnteringDataByRange", base.IsTakeScreenShotDuringEntryExit);
        }

        private void EnterValuesToSelectedCell(string CellID, string CellValue)
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "EnterValuesToSelectedCell", base.IsTakeScreenShotDuringEntryExit);

            base.ClearTextById(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in Reference Box 
            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator, CellID);
            //Clear Formula Box
            base.ClearTextById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //Fill vlaue in Formula Box 
            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator, CellValue);
            Actions builder = new Actions(WebDriver);
            builder.SendKeys(Keys.Enter).Perform();

            Logger.LogMethodExit("SIM5FramePage",
            "EnterValuesToSelectedCell", base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Twentyth Question
        /// <summary>
        /// Apply Numbering and decimal places to Cells
        /// </summary>
        private void ApplyNumberingtoCells()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "ApplyNumberingtoCells",
            base.IsTakeScreenShotDuringEntryExit);
            //click on E4 and type "=b4*d4"

            IWebElement getE4Cell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E4_Cell_Id_Locator);
            Thread.Sleep(3000);
            base.PerformMouseClickAction(getE4Cell);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Buffer_Sleep_Time));
            base.ClearTextById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //Fill vlaue in Formula Box 
            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator, "=b4*d4");
            PressEnterKeyById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);

            //click on E4 and drag down till E9         
            IWebElement getE9Cell = base.GetWebElementPropertiesById(
           SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E9_Cell_Id_Locator);
            Thread.Sleep(2000);
            base.PerformMouseClickAction(getE4Cell);
            Thread.Sleep(2000);
            IWebElement E4Setter = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E4Setter_Xpath_Locator);
            Thread.Sleep(2000);
            base.DragAndDropWebElement(E4Setter, getE9Cell);
            Thread.Sleep(2000);
            //select B4 to B9
            IWebElement getB4Cell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B4_Cell_Id_Locator);
            Thread.Sleep(2000);
            IWebElement getB9Cell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B9_Cell_Id_Locator);
            Thread.Sleep(2000);
            base.PerformDragAndDropAction(getB4Cell, getB9Cell);
            Thread.Sleep(2000);
            // click on Home tab
            powerPoint.ClickOnElementByCssSelector(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Home_Menu_CSSLocator);


            // Under numbering group click on comma
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_CommaOption_Xpath_Locator);

            // click on decrease decimal icon twice
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_DecreaseDecimalOption_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
              SIM5Frame_Page_SIM5_Excel_DecreaseDecimalOption_Xpath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
            "ApplyNumberingtoCells",
            base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Eighteenth Question
        /// <summary>
        /// Spell Checking.
        /// </summary>
        public void SpellCheckingSheet()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "SpellCheckingSheet",
            base.IsTakeScreenShotDuringEntryExit);
            //click on Review Tab
            powerPoint.ClickOnElementByCssSelector(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Ribbon_Review_tab_CssSelector_Locator);

            //click on Spelling Icon
            IWebElement SpellButton = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_Spelling_Button_Xpath_Locator);
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(SpellButton);
            // click on change button
            IWebElement ChangeButton = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_ChangeSpelling_Button_Xpath_Locator);
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(ChangeButton);
            Thread.Sleep(3000);
            // click Ok
            Actions builder = new Actions(WebDriver);
            builder.SendKeys(Keys.Enter).Perform();
            Logger.LogMethodExit("SIM5FramePage",
            "SpellCheckingSheet",
            base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Fifteenth Question
        /// <summary>
        /// Set and DisplayDocumentProperties.
        /// </summary>
        public void DisplayDocumentProperties()
        {
            Logger.LogMethodEntry("SIM5FramePage",
            "DisplayDocumentProperties",
            base.IsTakeScreenShotDuringEntryExit);
            //click on File Tab
            IWebElement getFileMenuItem = base.GetWebElementPropertiesByCssSelector(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_File_Menu_CSSLocator);
            base.ClickByJavaScriptExecutor(getFileMenuItem);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_File_Info_ShowAllproperties_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_File_Info_ShowAllproperties_Properties_ArrowList_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_File_Info_ShowAllproperties_AdvancedProperties_Icon_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__File_Info_Properties_AdvancedProperties_Summary_Subject_TextInput_XPath_Locator);
            base.FillTextBoxByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__File_Info_Properties_AdvancedProperties_Summary_Subject_TextInput_XPath_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_SubjectTextBox_Value);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_File_Info_AdvancedPropertes_Summary_Keyword_TextInput_Xpath_Locator);
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_File_Info_AdvancedPropertes_Summary_Keyword_TextInput_Xpath_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_AddTagTextBox_Value);


            powerPoint.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__File_Info_Properties_AdvancedProperties_Ok_Button_XPath_Locator);

            //click on Print option and print button

            powerPoint.ClickOnElementByCssSelector(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_PrintTab_CssLocator);
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_PrintButton_ID_Locator));
            IWebElement HorizontalCheckBox = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_PrintButton_ID_Locator);
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(HorizontalCheckBox);
            Thread.Sleep(3000);
            Logger.LogMethodExit("SIM5FramePage",
            "DisplayDocumentProperties",
            base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Fourteenth Question
        /// <summary>
        /// Set the Margins And PageLayout
        /// </summary>
        public void SetMarginsAndPageLayout()
        {
            Logger.LogMethodEntry("SIM5FramePage", "SetMarginsAndPageLayout",
            base.IsTakeScreenShotDuringEntryExit);
            //Click on PageLayout file menu item
            powerPoint.ClickOnElementByCssSelector(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_PageLayout_Menu);

            //click on margins arrow and select Custom margins
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_MarginsButton_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_CustomMarginsButton_Xpath_Locator);

            //select check box horizontal margins
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_HorizontalMarginCheckBox_ID_Locator));
            IWebElement HorizontalCheckBox = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_HorizontalMarginCheckBox_ID_Locator);
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(HorizontalCheckBox);
            Thread.Sleep(3000);
            //navigate header/footer tab and click on custom footer
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_HeaderTab_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_CustomFooterButton_Xpath_Locator);

            //click on insert file name button and click OK
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_InsertFNIcon_ID_Locator));
            IWebElement InsertFileName = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_InsertFNIcon_ID_Locator);
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(InsertFileName);
            Thread.Sleep(3000);
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_OKButton_ID_Locator));
            IWebElement Accept = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_OKButton_ID_Locator);
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(Accept);
            Thread.Sleep(3000);
            //Click on OK
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_AcceptOKButton_Xpath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
            "SetMarginsAndPageLayout",
            base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        /// <summary>
        /// Submit SIM5 Excel type activity to score 70%.
        /// <param name="activityName">This is activity name.</param>
        /// </summary>
        private void SubmitSim5ExcelActivityExcelChapter1SkillBasedTrainingToScore70(String activityName)
        {
            //Submit SIM5 Excel type activity
            Logger.LogMethodEntry("SIM5FramePage",
                "SubmitSim5ExcelActivityExcelChapter1SkillBasedTrainingToScore70",
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
                powerPoint.JumpToQuestion("4");
                // Answer Fourth question
                this.SettingCellWidthAndSelectingCellRangeToAlignData();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                   SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                powerPoint.JumpToQuestion("8");
                //Answer Eighth Question
                this.UsingMergerAndCenterAndApplyingCellStyles();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Sleep_Time));
                powerPoint.JumpToQuestion("9");
                //Answer Ninth Question
                this.SimultaneouslyFormatMultipleCells();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Sleep_Time));
                powerPoint.JumpToQuestion("10");
                //Answer Tenth Question
                this.SetWorksheetThemeToRetrospect();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                       SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                powerPoint.JumpToQuestion("11");
                //Answer Eleventh Question
                this.ChartingDataUsingRecomendedChartsInsertChart();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                     SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                powerPoint.JumpToQuestion("13");
                //Answer Thirteenth Question
                this.CreatingandFormattingSparkLines();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                     SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                //Answer fourteenth Question
                powerPoint.JumpToQuestion("14");
                this.SetMarginsAndPageLayout();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Fifteenth Question
                powerPoint.JumpToQuestion("15");
                this.DisplayDocumentProperties();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Sixteenth Question
                powerPoint.JumpToQuestion("16");
                this.PrintingUsingKeyboard();
                //Answer Eighteenth Question
                powerPoint.JumpToQuestion("18");
                this.SpellCheckingSheet();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Twentyth Question
                powerPoint.JumpToQuestion("20");
                this.ApplyNumberingtoCells();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Twenty First Question
                powerPoint.JumpToQuestion("21");
                this.UsingQuickAnalysisTool();
                ////Answer Twenty Second Question
                powerPoint.JumpToQuestion("22");
                this.CopyingFormulasContainingAbsoluteCellReferences();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Sleep_Time));
                //Answer Twentythird Question
                powerPoint.JumpToQuestion("23");
                this.EditingTheValuesInWorksheet();
                //Answer Twentyfourth question
                powerPoint.JumpToQuestion("24");
                new StudentPresentationPage().getQuestionNumber(24);
                this.FormatCellWithPercentStyle();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                //Answer Tewntyfifth Question
                powerPoint.JumpToQuestion("25");
                this.insertAndDeletingRows();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                powerPoint.JumpToQuestion("26");
                //Answer TewntySixth Question
                this.AdjustingcolumnAndText();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Launch_Sleep_Time));
                //Answer TwentySeventh Question
                powerPoint.JumpToQuestion("27");
                this.ChangingWorkSheetTheme();
                Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Launch_Sleep_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SIM5FramePage",
                 "SubmitSim5ExcelActivityExcelChapter1SkillBasedTrainingToScore70",
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
            base.WaitForElement(By.Id(SIM5FramePageResource.
                 SIM5Frame_Page_Excel_Icon_Id_Locator));
            IWebElement getExcelIconButton = base.GetWebElementPropertiesById
                (SIM5FramePageResource.
                 SIM5Frame_Page_Excel_Icon_Id_Locator);
            Thread.Sleep(3000);
            //Click on Excel desktop icon button
            base.ClickByJavaScriptExecutor(getExcelIconButton);
            Thread.Sleep(3000);
            //Get Excel blank workbook icon button Property
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_New_Excel_Workbook_Xpath_Locator));
            IWebElement getBlankWorkbookIconButton = base.GetWebElementPropertiesByXPath
                (SIM5FramePageResource.
                 SIM5Frame_Page_New_Excel_Workbook_Xpath_Locator);
            //Click on Excel blank workbook icon button
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(getBlankWorkbookIconButton);
            Thread.Sleep(3000);
            SaveFilesInUSB();
            Logger.LogMethodExit("SIM5FramePage",
                "AnswersFirstExcelQuestion",
              base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

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
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Excel_Save_Xpath_Locator));
            IWebElement getSaveIconButton = base.GetWebElementPropertiesByXPath
                (SIM5FramePageResource.
                SIM5Frame_Page_Excel_Save_Xpath_Locator);
            Thread.Sleep(3000);
            //Click on save icon button
            base.ClickByJavaScriptExecutor(getSaveIconButton);
            Thread.Sleep(3000);
            //Get  computer browse icon button Property
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                 SIM5Frame_Page_Save_MyComputer_Browse_Xpath_Locator));
            IWebElement getComputerBrowseIconButton = base.GetWebElementPropertiesByXPath
                (SIM5FramePageResource.
                 SIM5Frame_Page_Save_MyComputer_Browse_Xpath_Locator);
            Thread.Sleep(3000);
            //Click on computer browse icon button
            base.ClickByJavaScriptExecutor(getComputerBrowseIconButton);
            Thread.Sleep(3000);
            //Get  USB disk icon button Property
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                 SIM5Frame_Page_Save_USB_Disk_Xpath_Locator));
            IWebElement getUSBDiskIconButton = base.GetWebElementPropertiesByXPath
                (SIM5FramePageResource.
                 SIM5Frame_Page_Save_USB_Disk_Xpath_Locator);
            Thread.Sleep(3000);
            //Click on USB disk icon button
            base.ClickByJavaScriptExecutor(getUSBDiskIconButton);
            Thread.Sleep(3000);
            //Get  New Folder button Property
            base.WaitForElement(By.Id(SIM5FramePageResource.
                 SIM5Frame_Page_Save_New_Folder_ID_Locator));
            IWebElement getNewFolderButton = base.GetWebElementPropertiesById
                (SIM5FramePageResource.
                 SIM5Frame_Page_Save_New_Folder_ID_Locator);
            Thread.Sleep(3000);
            //Click on New Folder button
            base.ClickByJavaScriptExecutor(getNewFolderButton);
            Thread.Sleep(3000);
            //Get created new folder Property
            base.WaitForElement(By.ClassName(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_New_Folder_Class_Name));
            IWebElement getNewFolderName = base.GetWebElementPropertiesByClassName
                (SIM5FramePageResource.
                SIM5Frame_Page_SIM5_New_Folder_Class_Name);
            Thread.Sleep(3000);
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
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Open_button_Id_Locator));
            IWebElement getOpenFileButton = base.GetWebElementPropertiesById
                (SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Open_button_Id_Locator);
            Thread.Sleep(3000);
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
            base.WaitForElement(By.Id(SIM5FramePageResource.
               SIM5Frame_Page_SIM5_Save_button_Id_Locator));
            IWebElement getSaveFileButton = base.GetWebElementPropertiesById(
                SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Save_button_Id_Locator);
            Thread.Sleep(3000);
            //Click on  save button
            base.ClickByJavaScriptExecutor(getSaveFileButton);
            Thread.Sleep(3000);
            Logger.LogMethodExit("SIM5FramePage",
                "SaveFilesInUSB",
              base.IsTakeScreenShotDuringEntryExit);
        }

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
            powerPoint.IsQuestionLoaded("2");
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
            powerPoint.IsQuestionLoaded("4");
            //Set Cell Width
            this.SetCellWidth();
            //Select Cell Range And Align Data
            this.SelectCellRangeAndAlignData();


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
            base.WaitForElement(By.Id(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator));
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
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_ColumnWidth_TextBox_ID_Locator));
            //Clear the Column Width value text box
            base.ClearTextById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_ColumnWidth_TextBox_ID_Locator);
            //enter the desired value in column width text box
            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_ColumnWidth_TextBox_ID_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_ColumnWidth_Value);
            //Get property for Column width OK button
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_ColumnWidth_OK_Button_ID_Locator));
            IWebElement clickOKButton = base.GetWebElementPropertiesById(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_ColumnWidth_OK_Button_ID_Locator);
            //click on ok button for setting the column width value
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(clickOKButton);
            Thread.Sleep(3000);
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
            base.WaitForElement(By.CssSelector(SIM5FramePageResource.
                SIM5Frame_Page_MenuToolsObject_Collection_CssSelector));
            ICollection<IWebElement> getCellsToolsCollection = base.GetWebElementsCollectionByCssSelector(
                SIM5FramePageResource.SIM5Frame_Page_MenuToolsObject_Collection_CssSelector);
            foreach (IWebElement cellToolOption in getCellsToolsCollection)
            {
                // from the above collection get the specific tool object that we wish to click
                if (count == 2)
                {
                    Thread.Sleep(2000);
                    base.PerformMouseHoverAction(cellToolOption);
                    base.ClickByJavaScriptExecutor(cellToolOption);
                    Thread.Sleep(2000);
                    break;
                }
                count++;
            }
            count = 0;
            base.WaitForElement(By.CssSelector(SIM5FramePageResource.
                SIM5Frame_Page_FormatToolsObject_Collection_CssSelector));
            // get the collection of objects of various tools available in Format dropdown by CssSelector using class names
            ICollection<IWebElement> getFormatToolCollection = base.GetWebElementsCollectionByCssSelector(
                SIM5FramePageResource.SIM5Frame_Page_FormatToolsObject_Collection_CssSelector);
            foreach (IWebElement formatTool in getFormatToolCollection)
            {
                // from the above collection get the specific tool object that we wish to click
                if (count == 2)
                {
                    Thread.Sleep(2000);
                    base.PerformMouseHoverAction(formatTool);
                    base.ClickByJavaScriptExecutor(formatTool);
                    Thread.Sleep(2000);
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
            ICollection<IWebElement> getAlighmentOptionsCollection = base.GetWebElementsCollectionByCssSelector(
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
            powerPoint.IsQuestionLoaded("5");
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
            base.WaitForElement(By.Id(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator));
            //Clear Reference Box
            base.ClearTextById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in Reference Box
            base.FillTextBoxById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator, referenceCellId);
            //Press Enter in Reference Box
            PressEnterKeyById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            base.WaitForElement(By.Id(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator));
            //Clear Formula Box
            base.ClearTextById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //Fill vlaue in Formula Box
            base.FillTextBoxById(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator, dataValue);
            //Get WebElement object for Cell A1
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_A1_Cell_ID_Locator));
            IWebElement cellA1 = base.GetWebElementPropertiesById(
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A1_Cell_ID_Locator);
            //Click on Cell A1 inorder to commit the change made to the Formula Box above
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(cellA1);
            Thread.Sleep(3000);
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
            powerPoint.IsQuestionLoaded("6");
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
            powerPoint.IsQuestionLoaded("8");
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                       SIM5Frame_Page_SIM5_Launch_Sleep_Time));
            // Select cell range from cell A1 to cell F1
            base.WaitForElement(By.Id(SIM5FramePageResource.
           SIM5Frame_Page_SIM5_Excel_A1_Cell_ID_Locator));
            IWebElement getCellA1 = base.GetWebElementPropertiesById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_A1_Cell_ID_Locator);
            Thread.Sleep(3000);
            base.PerformMouseClickAction(getCellA1);
            this.SelectCellRange(SIM5FramePageResource.
           SIM5Frame_Page_SIM5_Excel_A1_Cell_ID_Locator, SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_F1_Cell_ID_Locator);

            // Click Merge and Center to merge and center align the data in cells A1 to F1
            this.MergeAndCenter();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));
            // Open the Cell Style Dropdown
            this.OpenCellStyleDropdown();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));
            // Set the cell style as 'Title'
            this.SetTheCellStyleTitle();
            // Select cell range from cell A2 to cell F2
            base.WaitForElement(By.Id(SIM5FramePageResource.
          SIM5Frame_Page_SIM5_Excel_A1_Cell_ID_Locator));
            IWebElement getCellA2 = base.GetWebElementPropertiesById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_A2_Cell_ID_Locator);
            Thread.Sleep(3000);
            base.PerformMouseClickAction(getCellA2);
            this.SelectCellRange(SIM5FramePageResource.
           SIM5Frame_Page_SIM5_Excel_A2_Cell_ID_Locator, SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_F2_Cell_ID_Locator);

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
        #endregion

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
            base.PerformControlKeyDown();
            // select the desired cell range
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A4_Cell_ID_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_A8_Cell_ID_Locator);
            // perform CTRL key up
            base.PerformControlKeyUp();

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
            base.WaitForElement(By.Id(SIM5FramePageResource.
            SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator));
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
            base.WaitForElement(By.Id(SIM5FramePageResource.
           SIM5Frame_Page_SIM5_Excel_A1_Cell_ID_Locator));
            IWebElement getCellA1 = base.GetWebElementPropertiesById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_A1_Cell_ID_Locator);
            //Get property D3 Cell
            base.WaitForElement(By.Id(SIM5FramePageResource.
          SIM5Frame_Page_SIM5_Excel_F1_Cell_ID_Locator));
            IWebElement getCellF1 = base.GetWebElementPropertiesById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_F1_Cell_ID_Locator);
            //select and drag the range B3:D3
            Thread.Sleep(3000);
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
            base.WaitForElement(By.CssSelector(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_MergeAndCenter_Dropdown_CSS_Selector_Class_Locator));
            IWebElement getMergeAndCenterDropdownObject = base.GetWebElementPropertiesByCssSelector(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_MergeAndCenter_Dropdown_CSS_Selector_Class_Locator);
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(getMergeAndCenterDropdownObject);
            Thread.Sleep(3000);
            IWebElement getMergeAndCenterObject = base.GetWebElementPropertiesByCssSelector(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_MergeAndCenter_CSS_Selector_Class_Locator);
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(getMergeAndCenterObject);
            Thread.Sleep(3000);
            Logger.LogMethodExit("SIM5FramePage",
            "MergeAndCenter",
            base.IsTakeScreenShotDuringEntryExit);
        }


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
            base.PerformControlKeyDown();
            //Select the desired Cell range
            this.SelectCellRange(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_B8_Cell_Id_Locator,
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E8_Cell_Id_Locator);
            //Key up the CTRL keyboard key
            base.PerformControlKeyUp();
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
            ICollection<IWebElement> getStyleCollection = base.GetWebElementsCollectionByCssSelector(
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
            Thread.Sleep(3000);
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
            ICollection<IWebElement> themesCollection = base.GetWebElementsCollectionByCssSelector(
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
                    break;
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
            ICollection<IWebElement> getExcelStylesCollection = base.GetWebElementsCollectionByCssSelector(
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
            ICollection<IWebElement> getCellStylesCollection = base.GetWebElementsCollectionByCssSelector(
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
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator));
            base.ClearTextById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Fill Cell ID in Reference Box 
            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator, referenceCellId);
            //Press Enter in Reference Box
            PressEnterKeyById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Reference_TextBox_Id_Locator);
            //Actions builder = new Actions(WebDriver);
            //builder.SendKeys(Keys.Enter).Perform();
            //Clear Formula Box
            base.WaitForElement(By.Id(SIM5FramePageResource.
               SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator));
            base.ClearTextById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //Fill vlaue in Formula Box 
            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator, formulaValue);
            Thread.Sleep(3000);
            ////Press Enter in Formula Box
            PressEnterKeyById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //builder.SendKeys(Keys.F2).Perform();
            //builder.SendKeys(formulaValue).Perform();

            //builder.SendKeys(Keys.Enter).Perform();
            Logger.LogMethodExit("SIM5FramePage",
                "PutExcelValueInCell",
              base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Activity Submission

        /// <summary>
        /// Click On SIM5 Activity Submit Button.
        /// </summary>
        private void ClickOnSIM5ActivitySubmitButton()
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

        #endregion SIM5 Excel Activity Submission

        /// <summary>
        /// Click On SIM5 Activity Submit Button.
        /// </summary>
        public void ClickOnSim5ActivitySubmitButton()
        {
            Logger.LogMethodEntry("SIM5FramePage", "ClickOnSim5ActivitySubmitButton",
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
            Logger.LogMethodExit("SIM5FramePage", "ClickOnSim5ActivitySubmitButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit Access SIM Activity To Score 100%.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        private void SubmitSim5AccessChapter1Project1ASkillBasedExamScenario1ToScore100(string activityName)
        {
            // select window name
            new StudentPresentationPage().SelectSimActivityNormalStudentWindowName
                (activityName);
            // complete access question 
            this.AcActivity102StartingWithABlankDesktopDatabase();
            this.AcActivity105AddingARecordToATable();
            //Click on SIM5 activity Submit button
            this.ClickOnSIM5ActivitySubmitButton();
        }

        /// <summary>
        /// Submit Access SIM Activity To Score 70%.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        private void SubmitSim5AccessChapter1Project1ASkillBasedExamScenario1ToScore70(string activityName)
        {
            // select window name
            new StudentPresentationPage().SelectSimActivityNormalStudentWindowName
                (activityName);
            // complete access question 
            this.AcActivity102StartingWithABlankDesktopDatabase();
            //Click on SIM5 activity Submit button
            this.ClickOnSIM5ActivitySubmitButton();
        }

        /// <summary>
        /// Complete Access Question 2.
        /// </summary>
        private void AcActivity105AddingARecordToATable()
        {
            // access question 2
            Logger.LogMethodEntry("SIM5FramePage", "AcActivity105AddingARecordToATable",
               base.IsTakeScreenShotDuringEntryExit);
            base.ClickButtonById(SIM5FramePageResource.SIM5Frame_Page_NextQuestion_Button_Id_Locator);
            base.ClickButtonById(SIM5FramePageResource.SIM5Frame_Page_NextQuestion_Button_Id_Locator);
            base.FillTextBoxById(SIM5FramePageResource.SIM5Frame_Page_AccessGridCell0_TextBox_Id_Locator
                , SIM5FramePageResource.SIM5Frame_Page_AccessGridCell0_TextBox_Value);
            base.FillTextBoxById(SIM5FramePageResource.SIM5Frame_Page_AccessGridCell1_TextBox_Id_Locator
                , SIM5FramePageResource.SIM5Frame_Page_AccessGridCell1_TextBox_Value);
            base.FillTextBoxById(SIM5FramePageResource.SIM5Frame_Page_AccessGridCell2_TextBox_Id_Locator
                , SIM5FramePageResource.SIM5Frame_Page_AccessGridCell2_TextBox_Value);
            base.FillTextBoxById(SIM5FramePageResource.SIM5Frame_Page_AccessGridCell3_TextBox_Id_Locator
                , SIM5FramePageResource.SIM5Frame_Page_AccessGridCell3_TextBox_Value);
            base.FillTextBoxById(SIM5FramePageResource.SIM5Frame_Page_AccessGridCell4_TextBox_Id_Locator
                , SIM5FramePageResource.SIM5Frame_Page_AccessGridCell4_TextBox_Value);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Launch_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage", "AcActivity105AddingARecordToATable",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Complete Access Question 5.
        /// </summary>
        private void AcActivity102StartingWithABlankDesktopDatabase()
        {
            // access question 5
            Logger.LogMethodEntry("SIM5FramePage", "AcActivity102StartingWithABlankDesktopDatabase",
               base.IsTakeScreenShotDuringEntryExit);
            base.ClickButtonById(SIM5FramePageResource.SIM5Frame_Page_NextQuestion_Button_Id_Locator);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));
            base.ClickButtonById(SIM5FramePageResource.SIM5Frame_Page_AccessDatabase_Icon_Id_Locator);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));
            var propertyTemplateImage = (IList<IWebElement>)base.GetWebElementsCollectionByClassName
                (SIM5FramePageResource.SIM5Frame_Page_AccessTemplate_Image_ClassName_Locator);
            base.ClickButtonByClassName(propertyTemplateImage[1].ToString());
            base.ClickButtonByCssSelector(SIM5FramePageResource
                .SIM5Frame_Page_AccessUsbDisk_Menu_CssSelector_Locator);
            base.ClearTextById(SIM5FramePageResource.SIM5Frame_Page_FileName_TextBox_Id_Locator);
            base.FillTextBoxById(SIM5FramePageResource.SIM5Frame_Page_FileName_TextBox_Id_Locator
                , SIM5FramePageResource.SIM5Frame_Page_FileName_TextBox_Value);
            base.ClickButtonByCssSelector(SIM5FramePageResource.SIM5Frame_Page_FileSave_Button_CssSelector_Locator);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_SIM5_Sleep_Time));
            base.ClickButtonByCssSelector(SIM5FramePageResource.SIM5Frame_Page_CreateFile_Button_CssSelector_Locator);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Launch_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage", "AcActivity102StartingWithABlankDesktopDatabase",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit access activity Sim 5 questions to score Threshold value.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        public void SubmitSim5AccessActivityPostTestSeventyPercentScore(String activityName)
        {
            Logger.LogMethodEntry("SIM5FramePage",
                        "SubmitSim5AccessActivityPostTestSeventyPercentScore",
                       base.IsTakeScreenShotDuringEntryExit);
            //Submit Access activty Post-Test Sim5 Questions to score 70 percent
            this.AccessFirstQuestion(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_AccessPostTest_CommonField_Value));
            this.AccessSecondQuestion(SIM5FramePageResource.
                SIM5Frame_Page_Access_PostTest_FileName);
            this.AccessPreTestThirdQuestion();
            this.AccessFourthQuestion(SIM5FramePageResource.
                SIM5Frame_Page_AccessPage_PostTest_FirstField_InputValue);
            this.AccessFifthQuestion();
            this.ClickOnSim5ActivitySubmitButton();
            Logger.LogMethodExit("SIM5FramePage",
                        "SubmitSim5AccessActivityPostTestSeventyPercentScore",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit access activity Sim 5 questions to score hundred percent.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        public void SubmitSim5AccessActivityPostTestHundredPercentScore(String activityName)
        {
            Logger.LogMethodEntry("SIM5FramePage",
                        "SubmitSim5AccessActivityPostTestHundredPercentScore",
                       base.IsTakeScreenShotDuringEntryExit);
            //Submit Access activty Post-Test Sim5 Questions
            this.AccessFirstQuestion(Convert.ToInt32(SIM5FramePageResource.
                 SIM5Frame_Page_AccessPostTest_CommonField_Value));
            this.AccessSecondQuestion(SIM5FramePageResource.
                SIM5Frame_Page_Access_PostTest_FileName);
            this.AccessPreTestThirdQuestion();
            this.AccessFourthQuestion(SIM5FramePageResource.
                SIM5Frame_Page_AccessPage_PostTest_FirstField_InputValue);
            this.AccessFifthQuestion();
            this.ClickOnSim5ActivitySubmitButton();
            Logger.LogMethodExit("SIM5FramePage",
                        "SubmitSim5AccessActivityPostTestHundredPercentScore",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit Access activty Pre-Test Sim5 Questions.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        public void SubmitSim5AccessPreTestActivityQuestions(String activityName)
        {
            Logger.LogMethodEntry("SIM5FramePage",
                        "SubmitSim5AccessActivityQuestions",
                       base.IsTakeScreenShotDuringEntryExit);
            //Submit Access activty Pre-Test Sim5 Questions
            new StudentPresentationPage().SelectSimActivityNormalStudentWindowName
                 (activityName);
            this.AccessFirstQuestion(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_AccessPreTest_CommonField_Value));
            this.AccessSecondQuestion(SIM5FramePageResource.
                SIM5Frame_Page_Access_PreTest_FileName);
            this.AccessPreTestThirdQuestion();
            this.AccessFourthQuestion(SIM5FramePageResource.
                SIM5Frame_Page_AccessPage_FirstField_InputValue_XPathLocator);
            this.AccessFifthQuestion();
            this.AccessSixthQuestion();
            this.AccessSeventhQuestion();
            this.AccessActivityQuestionEight();
            this.AccessActivityQuestionNine();
            this.AccessActivityQuestionTen();
            this.AccessActivityQuestionEleven();
            this.AccessActivityQuestionTwelve();
            this.AccessActivityQuestionThirteen();
            this.AnswerAccessActivityQuestionFourteen();
            this.AccessActivityQuestionFifteen();
            this.AccessActivityQuestionSixteen();
            this.AccessActivityQuestionSeventeen();
            this.AccessActivityQuestionEighteen();
            this.AccessActivityQuestionNinteen();
            this.AccessActivityQuestionTwenty();
            this.AccessActivityQuestionTwentyone();
            this.AccessActivityQuestionTwentyTwo();
            this.AccessActivityQuestionTwentyThree();
            this.AccessActivityQuestionTwentyFour();
            this.AccessActivityQuestionFive();
            //Get the Submit Assignment 'OK' button as WebElement
            IWebElement getSubmitAssignment = base.GetWebElementPropertiesByXPath
            (SIM5FramePageResource.
            SIM5Frame_Page_SubmitAssignment_OK_Button_Id_Locator);
            //Click on the Submit Assignment 'OK' button
            base.ClickByJavaScriptExecutor(getSubmitAssignment);
            Logger.LogMethodExit("SIM5FramePage",
                        "SubmitSim5AccessActivityQuestions",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit SIM5 Access Activity Post-Test with 100 percent score.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        public void SubmitSim5AccessPostTestActivityQuestions(String activityName)
        {
            Logger.LogMethodEntry("SIM5FramePage",
                        "SubmitSim5AccessActivityQuestions",
                       base.IsTakeScreenShotDuringEntryExit);
            //Submit SIM5 Access Activity Post-Test
            this.AccessFirstQuestion(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_AccessPostTest_CommonField_Value));
            this.AccessSecondQuestion(SIM5FramePageResource.
                SIM5Frame_Page_Access_PostTest_FileName);
            this.AccessPostTestThirdQuestion();
            this.AccessFourthQuestion(SIM5FramePageResource.
                SIM5Frame_Page_AccessPage_PostTest_FirstField_InputValue);
            this.AccessPostTestFifthQuestion();
            //Get the Submit Assignment 'OK' button as WebElement
            IWebElement getSubmitAssignment = base.GetWebElementPropertiesByXPath
            (SIM5FramePageResource.
            SIM5Frame_Page_SubmitAssignment_OK_Button_Id_Locator);
            //Click on the Submit Assignment 'OK' button
            base.ClickByJavaScriptExecutor(getSubmitAssignment);
            Logger.LogMethodExit("SIM5FramePage",
                        "SubmitSim5AccessActivityQuestions",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Using good design technique to design a database.
        /// </summary>
        private void AccessFirstQuestion(int commonFieldNumber)
        {
            //Using good design technique to design a database
            Logger.LogMethodEntry("SIM5FramePage",
                       "SubmitSim5AccessActivityQuestions",
                      base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToLastOpenedWindow();
            base.WaitForElement(By.XPath(String.Format(SIM5FramePageResource.
                SIM5Frame_Page_Access_CommonField_Locator, commonFieldNumber)));
            //Select the text
            IWebElement getColumnName = base.GetWebElementPropertiesByXPath(
                String.Format(SIM5FramePageResource.
                SIM5Frame_Page_Access_CommonField_Locator, commonFieldNumber));
            base.SelectTextUsingCoordinates(getColumnName,
                Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_Access_StudentId_X_StartValue),
                Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_Access_StudentId_Y_StartValue),
                Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_Access_StudentId_X_EndValue),
                Convert.ToInt32(SIM5FramePageResource.SIM5Frame_Page_Access_StudentId_Y_EndValue));
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Sleep_Time));
            //'Bold' the selected text
            base.PressCtrlBKey(getColumnName);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                        "SubmitSim5AccessActivityQuestions",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Starting with a blank desktop database.
        /// </summary>
        private void AccessSecondQuestion(string accessFileName)
        {
            //Starting with a blank desktop database           
            Logger.LogMethodEntry("SIM5FramePage",
                    "AccessSecondQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToLastOpenedWindow();
            //Click Access desktop icon button  
            powerPoint.ClickOnElementById(SIM5FramePageResource.
                SIM5Frame_Page_Access_Id_Locator);

            //Click Access blank workbook icon button 
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_AccessBlankWOrkBookXPath_Locator);

            //Click on folder link         
            powerPoint.ClickOnElementById(SIM5FramePageResource.
                SIM5Frame_Page_AccessFolderId_Locator);

            //Enter file name  

            base.WaitForElement(By.Id(SIM5FramePageResource.
                 SIM5Frame_Page_AccessFileName_Id_Locator));
            base.ClearTextById(SIM5FramePageResource.
                 SIM5Frame_Page_AccessFileName_Id_Locator);
            base.FillTextBoxById(SIM5FramePageResource.
                 SIM5Frame_Page_AccessFileName_Id_Locator, accessFileName);
            Thread.Sleep(2000);
            //Click Ok
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_TemplateOk_XPath_Locator);

            //Click on create button
            powerPoint.ClickOnElementById(SIM5FramePageResource.
                SIM5Frame_Page_CreateButton_ID_Locator);


            Logger.LogMethodExit("SIM5FramePage",
                "AccessSecondQuestion",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assigning datatype and name to fields to access pre-test activity.
        /// </summary>
        private void AccessPreTestThirdQuestion()
        {
            //Assigning datatype and name to fields
            Logger.LogMethodEntry("SIM5FramePage",
                 "AccessPreTestThirdQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
            //Close navigation pane
            this.CloseNavigationPane();
            //Click on 2nd field
            this.FillThirdQuestionSecondField(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_ClickOnField_Value), SIM5FramePageResource.
                SIM5Frame_Page_Access_LastName_Column_XPathLocator);
            //Click on 3rd field
            this.FillthirdQuestionFieldThree(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_Field3_Value), SIM5FramePageResource.
                SIM5Frame_Page_Access_FirstName_Column_Value);
            //Click 12th field
            this.SelectMenuOption(Convert.ToInt32(SIM5FramePageResource
                .SIM5Frame_Page_Access_Menu_Value));
            this.FillField(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_Field12_Value),
                SIM5FramePageResource.
                SIM5Frame_Page_Access_AmountOwed_Column_XPathLocator);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                  "AccessPreTestThirdQuestion",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assigning datatype and name to fields to access post test activity.
        /// </summary>
        private void AccessPostTestThirdQuestion()
        {
            //Assigning datatype and name to fields
            Logger.LogMethodEntry("SIM5FramePage",
                 "AccessPostTestThirdQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
            //Close navigation pane
            this.CloseNavigationPane();
            //Click on 2nd field
            this.FillThirdQuestionSecondField(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_ClickOnField_Value), SIM5FramePageResource.
                SIM5Frame_Page_Access_LastName_Column_XPathLocator);
            //Click on 3rd field
            this.FillthirdQuestionFieldThree(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_Menu_Value), SIM5FramePageResource.
                SIM5Frame_Page_Access_FirstName_Column_Value);
            //Click 4th field
            this.SelectMenuOption(Convert.ToInt32(SIM5FramePageResource
                .SIM5Frame_Page_AccessPostTest_DateMenu_Value));
            this.FillField(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_Field4_Value),
                SIM5FramePageResource.
                SIM5Frame_Page_Access_PostTest_DateField_Value);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                  "AccessPostTestThirdQuestion",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Field 3 and fill the text.
        /// </summary>
        private void FillthirdQuestionFieldThree(int fieldValue, string valueToFill)
        {
            Logger.LogMethodEntry("SIM5FramePage",
                 "FillthirdQuestionFieldThree",
                   base.IsTakeScreenShotDuringEntryExit);
            //Select the datatype
            this.SelectMenuOption(Convert.ToInt32(SIM5FramePageResource
                .SIM5Frame_Page_Access_Field3_Menu_Value));
            //Fill Field three
            this.FillField(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_Field3_Value), valueToFill);
            Logger.LogMethodExit("SIM5FramePage",
                  "FillthirdQuestionFieldThree",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select field 2 and fill the text
        /// </summary>
        private void FillThirdQuestionSecondField(int fieldValue, string valueToFill)
        {
            Logger.LogMethodEntry("SIM5FramePage",
                "FillThirdQuestionSecondField",
                  base.IsTakeScreenShotDuringEntryExit);
            //Click on the field 2
            this.ClickOnField(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_ClickOnField_Value));
            //Select the datatype
            this.SelectMenuOption(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_Field2_Menu_Value));
            //Fill the field 2
            this.FillField(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_ClickOnField_Value), valueToFill);
            Logger.LogMethodExit("SIM5FramePage",
                  "FillThirdQuestionSecondField",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on fields in the excel sheet.
        /// </summary>
        /// <param name="fieldValue">This is the field number to be clicked.</param>
        public void ClickOnField(int fieldValue)
        {
            //Click on fields in the excel sheet
            Logger.LogMethodEntry("SIM5FramePage",
                 "ClickOnField",
                   base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(String.Format(SIM5FramePageResource.
                SIM5Frame_Page_Field_XPath_Locator, fieldValue)));
            IWebElement getSecondField = base.GetWebElementPropertiesByXPath(
                String.Format(SIM5FramePageResource.
                SIM5Frame_Page_Field_XPath_Locator, fieldValue));
            Thread.Sleep(3000);
            base.ClickByJavaScriptExecutor(getSecondField);
            Thread.Sleep(3000);
            Logger.LogMethodExit("SIM5FramePage",
                  "ClickOnField",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter values to the field.
        /// </summary>
        /// <param name="fieldValue">This is the field number.</param>
        /// <param name="fieldText">This is the text to be entered to the field.</param>
        public void FillField(int fieldValue, string fieldText)
        {
            //Enter values to the field
            Logger.LogMethodEntry("SIM5FramePage",
                 "FillField",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(String.Format(SIM5FramePageResource.
                SIM5Frame_Page_AccessFillField_XPath_Locator, fieldValue)));
            IWebElement getFillField = base.GetWebElementPropertiesByXPath(
                String.Format(SIM5FramePageResource.
                SIM5Frame_Page_AccessFillField_XPath_Locator, fieldValue));
            base.ClickByJavaScriptExecutor(getFillField);
            base.ClearTextByXPath(String.Format(SIM5FramePageResource.
                SIM5Frame_Page_AccessFillField_XPath_Locator, fieldValue));
            Thread.Sleep(3000);
            base.FillTextBoxByXPath(String.Format(
                SIM5FramePageResource.
                SIM5Frame_Page_AccessFillField_XPath_Locator,
                fieldValue), fieldText);
            base.PressEnterKeyByXPath(String.Format(SIM5FramePageResource.
                SIM5Frame_Page_AccessFillField_XPath_Locator,
                fieldValue));
            Logger.LogMethodExit("SIM5FramePage",
                  "FillField",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Datatype menu option from the list.
        /// </summary>
        /// <param name="menuValue">This is the Menu value.</param>
        public void SelectMenuOption(int menuValue)
        {
            //Select the Datatype menu option from the list
            Logger.LogMethodEntry("SIM5FramePage",
                "SelectMenuOption",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(String.Format(
                SIM5FramePageResource.SIM5Frame_Page_AccessSelectMenu_XPath_Locator,
                menuValue)));
            IWebElement selectList = base.
                GetWebElementPropertiesByXPath(String.Format(
                SIM5FramePageResource.SIM5Frame_Page_AccessSelectMenu_XPath_Locator,
                menuValue));
            Thread.Sleep(3000);
            Actions builder = new Actions(WebDriver);
            Actions hoverOverRegistrar = builder.MoveToElement(selectList);
            hoverOverRegistrar.Perform();
            selectList.Click();
            Thread.Sleep(3000);
            Logger.LogMethodExit("SIM5FramePage",
                  "SelectMenuOption",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close the Navigation pane
        /// </summary>
        private void CloseNavigationPane()
        {
            //Close the Navigation pane
            Logger.LogMethodEntry("SIM5FramePage",
                 "CloseNavigationPane",
                   base.IsTakeScreenShotDuringEntryExit);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_CloseNavigationPane_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                 "CloseNavigationPane",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open the navigation pane.
        /// </summary>
        private void OpenNavigationPane()
        {
            //Open the navigation pane
            Logger.LogMethodEntry("SIM5FramePage",
                 "OpenNavigationPane",
             base.IsTakeScreenShotDuringEntryExit);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
           SIM5Frame_Page_OpenNavigationpane_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                 "OpenNavigationPane",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Renaming fields and changing the datatypes of the table.
        /// </summary>
        /// <param name="firstFieldValue">This is the value to be entered in the first field.</param>
        private void AccessFourthQuestion(string firstFieldValue)
        {
            //Renaming fields and changing the datatypes of the table
            Logger.LogMethodEntry("SIM5FramePage",
                   "AccessFourthQuestion",
                     base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToLastOpenedWindow();
            int fieldValue = 1;
            base.WaitForElement(By.XPath(String.Format(SIM5FramePageResource.
                SIM5Frame_Page_Field_XPath_Locator, fieldValue)));
            IWebElement getFirstField = base.GetWebElementPropertiesByXPath(
                String.Format(SIM5FramePageResource.
                SIM5Frame_Page_Field_XPath_Locator, fieldValue));
            Thread.Sleep(3000);
            base.PerformMouseClickAction(getFirstField);
            Thread.Sleep(3000);
            //Enter 'Student ID' in Name field
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_TableToolsField_XPath_Locator);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_FieldName_XPath_Locator);
            base.ClearTextByXPath(SIM5FramePageResource.
                SIM5Frame_Page_FieldName_XPath_Locator);
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_FieldName_XPath_Locator, firstFieldValue);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_OK_XPath_Locator);
            this.SetFieldDataType();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
           "AccessFourthQuestion",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set the field data type.
        /// </summary>
        private void SetFieldDataType()
        {
            //Set the datatype of the field
            Logger.LogMethodEntry("SIM5FramePage",
                     "SetFieldDataType",
                       base.IsTakeScreenShotDuringEntryExit);
            //Change the datatype of the 'Student id' field
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_AccessPage_FirstField_DataType_Id_Locator));
            IWebElement getFirstField = base.GetWebElementPropertiesById(
                SIM5FramePageResource.
                SIM5Frame_Page_AccessPage_FirstField_DataType_Id_Locator);
            Thread.Sleep(3000);
            base.DoubleClickByJavaScriptExecuter(getFirstField);
            Thread.Sleep(3000);
            //Click on datatype option
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_AccessPage_FirstField_DataTypeMenu_XPath_Locator);

            //Select Datatype
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_AccessPage_FirstField_DataTypeSelect_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                  "SetFieldDataType",
                  base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        ///Adding records into table in Pre-Test.
        /// </summary>           
        private void AccessFifthQuestion()
        {
            //Adding records into table in Pre-Test
            Logger.LogMethodEntry("SIM5FramePage",
                  "AccessFifthQuestion",
                    base.IsTakeScreenShotDuringEntryExit);
            //Enter student ID
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_Xpath_Locator));
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_Xpath_Locator, SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_Xpath_Locator);
            //Enter Last Name
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudent_LastName_Xpath_Locator));
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudent_LastName_Xpath_Locator, SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentLastName_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudent_LastName_Xpath_Locator);
            //Enter the amount
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudent_Amount_Xpath_Locator));
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudent_Amount_Xpath_Locator, SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentAmount_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudent_Amount_Xpath_Locator);
            this.SaveTable(SIM5FramePageResource.
                SIM5Frame_Page_AccessPreTest_SaveTableName_Value);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
               "AccessFifthQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Adding records into table in Access activity Post-Test.
        /// </summary>
        private void AccessPostTestFifthQuestion()
        {
            //Adding records into table in Post-Test
            Logger.LogMethodEntry("SIM5FramePage",
                  "AccessPostTestFifthQuestion",
                    base.IsTakeScreenShotDuringEntryExit);
            //Enter driver ID
            this.AccessFifthQuestionPostTestFieldData(Convert.ToInt16(SIM5FramePageResource.
                SIM5Frame_Page_Access_PostTest_Q5_DriverId_FieldValue),
                SIM5FramePageResource.
             SIM5Frame_Page_Access_PostTest_Q5_DriverId_Value);
            //Enter Last name
            this.AccessFifthQuestionPostTestFieldData(Convert.ToInt16(SIM5FramePageResource.
                SIM5Frame_Page_Access_PostTest_Q5_LastName_FieldValue), SIM5FramePageResource.
             SIM5Frame_Page_Access_PostTest_Q5_LastName_Value);
            //Enter Middle initial
            this.AccessFifthQuestionPostTestFieldData(Convert.ToInt16(SIM5FramePageResource.
                SIM5Frame_Page_Access_PostTest_Q5_MiddleInitial_FieldValue), SIM5FramePageResource.
             SIM5Frame_Page_Access_PostTest_Q5_MiddleInitial_Value);
            //Enter FirstName
            this.AccessFifthQuestionPostTestFieldData(Convert.ToInt16(SIM5FramePageResource.
                SIM5Frame_Page_Access_PostTest_Q5_FirstName_FieldValue), SIM5FramePageResource.
             SIM5Frame_Page_Access_PostTest_Q5_FirstName_Value);
            //Enter date of birth
            this.AccessFifthQuestionPostTestFieldData(Convert.ToInt16(SIM5FramePageResource.
                SIM5Frame_Page_Access_PostTest_Q5_DateofBirth_FieldValue), SIM5FramePageResource.
             SIM5Frame_Page_Access_PostTest_Q5_DateofBirth_Value);
            //Save the table
            this.SaveTable(SIM5FramePageResource.
                SIM5Frame_Page_AccessPostTest_SaveTableName_Value);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
               "AccessPostTestFifthQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter details in to the fields.
        /// </summary>
        /// <param name="fieldNumber">This is the field number.</param>
        /// <param name="fieldFiveValue">This is the value to be antered.</param>
        private void AccessFifthQuestionPostTestFieldData(int fieldNumber, string fieldFiveValue)
        {
            //Enter details in to the fields
            Logger.LogMethodEntry("SIM5FramePage",
                        "AccessFifthQuestionPostTestFieldData",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(String.Format(SIM5FramePageResource.
                SIM5Frame_Page_Access_PostTest_Q5_Field_XPath_Locator, fieldFiveValue)));
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PostTest_Q5_Field_XPath_Locator, fieldFiveValue);
            base.PressEnterKeyByXPath(String.Format(SIM5FramePageResource.
                SIM5Frame_Page_Access_PostTest_Q5_Field_XPath_Locator, fieldFiveValue));
            Logger.LogMethodExit("SIM5FramePage",
                   "AccessFifthQuestionPostTestFieldData",
                    base.IsTakeScreenShotDuringEntryExit);

        }


        /// <summary>
        /// Adding additional records into table.
        /// </summary>
        private void AccessSixthQuestion()
        {
            //Adding additional records into table
            Logger.LogMethodEntry("SIM5FramePage",
                   "AccessSixthQuestion",
                     base.IsTakeScreenShotDuringEntryExit);
            //Click Second Row Id field
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_2_XPath_Locator));

            IWebElement clickSecondField = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_2_XPath_Locator);
            Thread.Sleep(3000);
            base.DoubleClickByJavaScriptExecuter(clickSecondField);
            Thread.Sleep(3000);
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_2Input_XPath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_AccessStudentId_2Input_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_2Input_XPath_Locator);
            //Enter Second row Last name
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentLastName_2Input_XPath_Locator));
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentLastName_2Input_XPath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_AccessStudentLastName_2Input_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentLastName_2Input_XPath_Locator);
            //Enter Second row Amount
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentAmount_2Input_XPath_Locator));
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentAmount_2Input_XPath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_AccessStudentAmount_2Input_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentAmount_2Input_XPath_Locator);
            //Click Third Row Id field           
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_3Input_XPath_Locator));
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_3Input_XPath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_AccessStudentId_3Input_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_3Input_XPath_Locator);
            //Last name
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentLastName_3Input_XPath_Locator));
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentLastName_3Input_XPath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_AccessStudentLastName_3Input_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentLastName_3Input_XPath_Locator);
            //First name
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentFirstName_3Input_XPath_Locator));
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentFirstName_3Input_XPath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_AccessStudentFirstName_3Input_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentFirstName_3Input_XPath_Locator);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                  "AccessSixthQuestion",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Importing data from Excel workbook into existing access table.
        /// </summary>           
        private void AccessSeventhQuestion()
        {
            //Importing data from Excel workbook into existing access table
            Logger.LogMethodEntry("SIM5FramePage",
                 "AccessSeventhQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
            //Click on "cancel" table button
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_CancelButton_XPath_Locator);

            //Select the Excel file from USB
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_ExternalDataButton_XPath_Locator);

            this.SelectExcelFileInUsb();
            //Append copy to sudents               
            this.AppendExcelFile();
            //Open the Table and close navigation pane
            this.OpenNavigationPane();
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_OpenExcelTable_XPath_Locator));
            IWebElement openExcelSheetTable = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_OpenExcelTable_XPath_Locator);
            Thread.Sleep(3000);
            base.PerformDoubleClickAction(openExcelSheetTable);
            Thread.Sleep(3000);
            //CLose the navigation pane
            this.CloseNavigationPane();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                 "AccessSeventhQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Append the copy to sudents.
        /// </summary>
        private void AppendExcelFile()
        {
            //Append the copy to sudents 
            Logger.LogMethodEntry("SIM5FramePage",
                 "SelectAndAppendExcelFile",
                   base.IsTakeScreenShotDuringEntryExit);
            //Select 'Append to student' radio button 

            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_Access_AppendradioButton_Id_Locator));
            IWebElement getElementProperty = base.GetWebElementPropertiesById(SIM5FramePageResource.
                SIM5Frame_Page_Access_AppendradioButton_Id_Locator);
            Thread.Sleep(4000);
            base.PerformMouseClickAction(getElementProperty);
            Thread.Sleep(2000);

            //Click on ok
            powerPoint.ClickOnElementById(SIM5FramePageResource.
                SIM5Frame_Page_Access_AppendOkButton_Id_Locator);

            //Click on next
            this.ClickNextButton();
            this.ClickOnFinish();
            Logger.LogMethodExit("SIM5FramePage",
                 "SelectAndAppendExcelFile",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the excel file from USB drive.
        /// </summary>
        private void SelectExcelFileInUsb()
        {
            //Select the excel file from USB drive
            Logger.LogMethodEntry("SIM5FramePage",
                 "SelectAndAppendExcelFile",
                   base.IsTakeScreenShotDuringEntryExit);
            //Click on Excel link  
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_ExcelLink_XPath_Locator);

            //Click on Browse
            powerPoint.ClickOnElementById(SIM5FramePageResource.
                SIM5Frame_Page_Access_BrowseButton_Id_Locator);

            //Select the excel file
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_Access_ExcelItemInUsb_Id_Locator));

            IWebElement selectExcelFile = base.GetWebElementPropertiesById(
               SIM5FramePageResource.
                SIM5Frame_Page_Access_ExcelItemInUsb_Id_Locator);
            Thread.Sleep(2000);
            base.DoubleClickByJavaScriptExecuter(selectExcelFile);
            Logger.LogMethodExit("SIM5FramePage",
                "SelectAndAppendExcelFile",
                  base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        ///Deleting a table in design view.
        /// </summary>
        private void AccessActivityQuestionEight()
        {
            //Deleting a table in design view
            Logger.LogMethodEntry("SIM5FramePage",
                  "AccessActivityQuestionEight",
                    base.IsTakeScreenShotDuringEntryExit);
            //Switch to design view   
            this.SwitchToDesignView();
            //Delete the Middle Initial column
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Table_MiddleInitialRow_XPath_Locator);

            //Click on Delete
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Delete_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Delete__Ok_Xpath_Locator);

            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                      "AccessActivityQuestionEight",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Changing the field size and adding a description.
        /// </summary>
        private void AccessActivityQuestionNine()
        {
            //Changing the field size and adding a description
            Logger.LogMethodEntry("SIM5FramePage",
                     "AccessActivityQuestionNine",
                       base.IsTakeScreenShotDuringEntryExit);
            //Set student Id field property
            this.SetStudentIdFieldProperty();
            //Set State field property
            this.SetStateFieldProperty();
            //Save the changes
            this.ClickOnSave();
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Save_YesButton_XPath_Locator));
            IWebElement clickYes = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_Save_YesButton_XPath_Locator);
            base.ClickByJavaScriptExecutor(clickYes);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                  "AccessActivityQuestionNine",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set the 'Student ID' field property.
        /// </summary>
        private void SetStateFieldProperty()
        {
            //Set the 'State' field property
            Logger.LogMethodEntry("SIM5FramePage",
                     "SetStateFieldProperty",
                       base.IsTakeScreenShotDuringEntryExit);
            //Click State field 
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessState_FieldProperty_XPath_Locator));
            IWebElement getStateField = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_AccessState_FieldProperty_XPath_Locator);
            base.ClickByJavaScriptExecutor(getStateField);
            //Select the text and fill new value
            base.WaitForElement(By.XPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_SelectText_XPath_Locator));
            IWebElement element1 = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_SelectText_XPath_Locator);
            element1.SendKeys(Keys.Control + "a");
            base.ClearTextByXPath(SIM5FramePageResource.SIM5Frame_Page_Access_SelectText_XPath_Locator);
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_SelectText_XPath_Locator, "2");
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessState_FieldProperty_XPath_Locator);
            //Click description field
            base.WaitForElement(By.XPath(
                SIM5FramePageResource.
                SIM5Frame_Page_AccessStateDescription_FieldProperty_Value));
            IWebElement clickStateDescriptionField = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_AccessStateDescription_FieldProperty_Value);
            base.ClickByJavaScriptExecutor(clickStateDescriptionField);
            //Fill description field
            base.FillTextBoxByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_AccessStateDescription_FieldProperty_Value,
                SIM5FramePageResource.
                SIM5Frame_Page_AccessStateDescription_Value_FieldProperty_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStateDescription_FieldProperty_Value);
            Logger.LogMethodExit("SIM5FramePage",
                    "SetStateFieldProperty",
                      base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Set 'Student Id' field property.
        /// </summary>
        private void SetStudentIdFieldProperty()
        {
            //Set 'Student Id' field property
            Logger.LogMethodEntry("SIM5FramePage",
                      "SetStudentIdFieldProperty",
                        base.IsTakeScreenShotDuringEntryExit);
            //Select Student id Field
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_FieldProperty_XPath_Locator));
            IWebElement clickStudentIdField = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_FieldProperty_XPath_Locator);
            base.ClickByJavaScriptExecutor(clickStudentIdField);
            //Select the text and fill new value
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_SelectText_XPath_Locator));
            IWebElement element = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_SelectText_XPath_Locator);
            element.SendKeys(Keys.Control + "a");
            base.FillTextBoxByXPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_SelectText_XPath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_StudentIdProperty_FieldValue);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentId_FieldProperty_XPath_Locator);
            //Click description field
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentDescription_FieldProperty_Value));
            IWebElement clickStudentDescriptionField = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentDescription_FieldProperty_Value);
            base.ClickByJavaScriptExecutor(clickStudentDescriptionField);
            //Fill description field
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentDescription_FieldProperty_Value));
            base.FillTextBoxByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentDescription_FieldProperty_Value,
                SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentDescription_Value_FieldProperty_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessStudentDescription_FieldProperty_Value);
            Logger.LogMethodExit("SIM5FramePage",
                  "SetStudentIdFieldProperty",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Switch to the design view of the excel sheet.
        /// </summary>
        private void SwitchToDesignView()
        {
            //Switch to the design vie of the excel sheet
            Logger.LogMethodEntry("SIM5FramePage",
                  "SwitchToDesignView",
                    base.IsTakeScreenShotDuringEntryExit);
            //Click Home button
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Home_Button_XPath_Locator);

            //Click 'View' button 
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_View_Link_XPath_Locator);

            //Select 'Design view'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_DesignView_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                  "SwitchToDesignView",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save the table.
        /// </summary>
        public void SaveTable(string tableName)
        {
            //Save the table
            Logger.LogMethodEntry("SIM5FramePage",
                  "SaveTable",
                    base.IsTakeScreenShotDuringEntryExit);
            //save the table
            this.ClickOnSave();
            Thread.Sleep(3000);
            bool ddf = base.IsElementPresent(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_SaveTableName_XPath_Locator), 10);
            //Enter the table name
            base.WaitForElement(By.XPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_SaveTableName_XPath_Locator));
            IWebElement getInputBox = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_SaveTableName_XPath_Locator);
            getInputBox.SendKeys(Keys.Control + "a");
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_SaveTableName_XPath_Locator,
               tableName);
            Thread.Sleep(3000);
            //Click on ok
            base.WaitForElement(By.XPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_Save_Ok_Button));
            IWebElement clickOk = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_Save_Ok_Button);
            base.ClickByJavaScriptExecutor(clickOk);
            Logger.LogMethodExit("SIM5FramePage",
               "SaveTable",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Viewing the primary key in design view.
        /// </summary>
        private void AccessActivityQuestionTen()
        {
            //Viewing the primary key in design view
            Logger.LogMethodEntry("SIM5FramePage",
                 "AccessActivityQuestionTen",
                   base.IsTakeScreenShotDuringEntryExit);
            this.CLickStudentIdField();
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_View_Button_XPath_Locator);

            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                 "AccessActivityQuestionTen",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on ID fiels of the student.
        /// </summary>
        private void CLickStudentIdField()
        {
            //Click on ID fiels of the student
            Logger.LogMethodEntry("SIM5FramePage",
                        "CLickStudentIdField",
                          base.IsTakeScreenShotDuringEntryExit);
            //Select Student id Field
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Student_IdField_XPath);

            Logger.LogMethodExit("SIM5FramePage",
                        "CLickStudentIdField",
                          base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Adding a second table into the database by importing an Excel spreadsheet.
        /// </summary>
        private void AccessActivityQuestionEleven()
        {
            //Adding a second table into the database 
            //by importing an Excel spreadsheet.
            Logger.LogMethodEntry("SIM5FramePage",
                          "AccessActivityQuestionEleven",
                            base.IsTakeScreenShotDuringEntryExit);
            //Click External data button  
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_ExternalLink_XPath_Locator);

            //Select Excel file from USB drive
            this.SelectExcelFileInUsb();
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_Access_AppendOkButton_Id_Locator));
            IWebElement getOk = base.GetWebElementPropertiesById(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_AppendOkButton_Id_Locator);
            Thread.Sleep(2000);
            base.PerformMouseClickAction(getOk);
            Thread.Sleep(2000);
            this.ClickNextButton();
            //Select check box
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_CheckMark_XPath_Locator);
            //Click on next
            this.ClickNextButton();
            this.ClickNextButton();
            //Select 'Primary key' radio button
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
            SIM5Frame_Page_Access_PrimaryKey_RadioButton_XPath_Locator);

            this.ClickNextButton();

            Thread.Sleep(3000);
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_TableName_Field_XPath_Locator));
            IWebElement getFilltextBox = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_TableName_Field_XPath_Locator);
            Thread.Sleep(3000);
            base.DoubleClickByJavaScriptExecuter(getFilltextBox);
            Thread.Sleep(3000);
            getFilltextBox.SendKeys(Keys.Control + "a");
            Thread.Sleep(3000);
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_TableName_Field_XPath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_Access_TableName_Field_Value);
            this.ClickOnFinish();
            //Open the navigation pane
            this.OpenNavigationPane();
            //Open the table
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_ExcelTable_XPath_Locator));
            IWebElement openExcelSheetTable = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_ExcelTable_XPath_Locator);
            Thread.Sleep(3000);
            base.PerformDoubleClickAction(openExcelSheetTable);
            Thread.Sleep(3000);
            //Close the navigation pane
            this.CloseNavigationPane();
            this.SetPostalCodeDataType();

            Logger.LogMethodExit("SIM5FramePage",
                        "AccessActivityQuestionEleven",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set datatype for the postal code field.
        /// </summary>
        private void SetPostalCodeDataType()
        {
            //Set datatype for the postal code field
            Logger.LogMethodEntry("SIM5FramePage",
                            "SetPostalCodeDataType",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on Postal code column
            powerPoint.ClickOnElementById(SIM5FramePageResource.
                SIM5Frame_Page_Access_PostalCode_Id_Locator);

            //Click on 'Fields' tab
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Fields_Xpath_Locator);

            //Select the data type
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                    SIM5Frame_Page_AccessPage_FirstField_DataTypeMenu_XPath_Locator);

            //Select datatype
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_AccessPage_FirstField_DataTypeSelect_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                             "SetPostalCodeDataType",
                         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on next button.
        /// </summary>
        private void ClickNextButton()
        {
            // Click on next button
            Logger.LogMethodEntry("SIM5FramePage",
                "ClickNextButton",
             base.IsTakeScreenShotDuringEntryExit);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Next_Button_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                "ClickNextButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on 'Finish' and 'Close' button.
        /// </summary>
        private void ClickOnFinish()
        {
            // Click on 'Finish' and 'Close' button
            Logger.LogMethodEntry("SIM5FramePage",
                          "ClickOnFinish",
                        base.IsTakeScreenShotDuringEntryExit);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Finish_Xpath_Locator);

            //Click 'Close'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_AppendClose_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                        "ClickOnFinish",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Adjusting the column width.
        /// </summary>
        private void AccessActivityQuestionTwelve()
        {
            //Adjusting the column width
            Logger.LogMethodEntry("SIM5FramePage",
                    "AccessActivityQuestionTwelve",
                   base.IsTakeScreenShotDuringEntryExit);
            //Adjust Address field Column width
            //select sheet
            powerPoint.ClickOnElementByXpath(".//*[@id='access-item-1']/div/div[1]/div[2]/label");
            this.SetAddressColumnWidth();
            //Set city field column width
            this.SetCityFieldColumnWidth();
            //Set the width of all the columns
            this.SetAllFielColumnWidth();
            //Select 'Best Fit' option
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                     SIM5Frame_Page_Access_GetBestFit_Xpath_Locator);

            //Save the changes
            this.ClickOnSave();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                     "AccessActivityQuestionTwelve",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set the Address field column width.
        /// </summary>
        private void SetAddressColumnWidth()
        {
            //Set the Address field column width.
            Logger.LogMethodEntry("SIM5FramePage",
                   "SetAddressColumnWidth",
               base.IsTakeScreenShotDuringEntryExit);
            //Select 1A Students table
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_AddressColumn_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_ColumnHeader_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_SetFieldWidth_Ribbon_Icon_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_FieldWidth_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_BestFitOption_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                      "SetAddressColumnWidth",
                    base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Set the 'City' field column width.
        /// </summary>
        private void SetCityFieldColumnWidth()
        {
            //Set the 'City' field column width
            Logger.LogMethodEntry("SIM5FramePage",
                     "SetCityFieldColumnWidth",
                 base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(SIM5FramePageResource.
                    SIM5Frame_Page_Access_CityFieldColumnWidth_Id_Locator));
            IWebElement clickCityField = base.GetWebElementPropertiesById(
                    SIM5FramePageResource.
                    SIM5Frame_Page_Access_CityFieldColumnWidth_Id_Locator);
            Thread.Sleep(3000);
            base.PerformMouseRightClickAction(clickCityField);
            Thread.Sleep(3000);
            //Select field width option
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_CityFieldWidth_Xpath_Locator);

            //Select 'Best Fit' option
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                         SIM5Frame_Page_Access_CityField_BestFit_Xpath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                                    "SetCityFieldColumnWidth",
                                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set the column width of all the rows.
        /// </summary>
        private void SetAllFielColumnWidth()
        {
            //Set the column width of all the rows
            Logger.LogMethodEntry("SIM5FramePage",
                  "SetAllFielColumnWidth",
            base.IsTakeScreenShotDuringEntryExit);

            //Click 'Home' button
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Home_Button_XPath_Locator);
            //Select all the columns
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_SelectOption_Ribbon_Icon_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_SelectOption_SelectAll_Ribbon_Icon_Xpath_Locator);
            //Click on 'Field width'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_SetFieldWidth_Ribbon_Icon_Xpath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_FieldWidth_Xpath_Locator);
            //Select 'Best Fit' option
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_BestFitOption_XPath_Locator);
            Logger.LogMethodExit("SIM5FramePage",
                        "SetAllFielColumnWidth",
             base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on save button.
        /// </summary>
        private void ClickOnSave()
        {
            //Save the changes made.
            Logger.LogMethodEntry("SIM5FramePage",
                  "ClickOnSave",
           base.IsTakeScreenShotDuringEntryExit);
            //Clisk save button
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Save_Button_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                        "ClickOnSave",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Printing the table.
        /// /// </summary>
        private void AccessActivityQuestionThirteen()
        {
            //Answer Access activity thirteenth question
            Logger.LogMethodEntry("SIM5FramePage",
                        "AccessActivityQuestionThirteen",
                          base.IsTakeScreenShotDuringEntryExit);
 
            //Open 'file' and click 'Print'
            this.OpenFileToPrinting();
            //Click on 'Print Preview
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintPreviewLink_Xpath_Locator);

            //Select 'Landscape' option
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintLandscape_Xpath_Locator);

            //Select 'Print'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
            SIM5Frame_Page_Access_PrintIcon_Xpath_Locator);

            //Click ok
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintOk_Xpath_Locator);

            //Close 'Print Preview'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
            SIM5Frame_Page_Access_ClosePrintPreview_Xpath_Locator);


            Logger.LogMethodExit("SIM5FramePage",
                        "AccessActivityQuestionThirteen",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open the file for printing.
        /// </summary>
        private void OpenFileToPrinting()
        {
            //Open the file for printing
            Logger.LogMethodEntry("SIM5FramePage",
                 "OpenFileForPrinting",
               base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToLastOpenedWindow();
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_FileLink_Xpath_Locator);

            //Click on 'Print'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintLink_Xpath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                      "OpenFileForPrinting",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Creating a query using simple query wizard.
        /// </summary>
        private void AnswerAccessActivityQuestionFourteen()
        {
            //Creating a query using simple query wizard
            Logger.LogMethodEntry("SIM5FramePage",
                      "AnswerAccessActivityQuestionFourteen",
                 base.IsTakeScreenShotDuringEntryExit);
            //Create the query using 'Query wizard'
            this.CreateQuery();
            //Add specified fields to the query
            this.AddFieldsToQuery();
            //Click on next
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_NextLink_XPath_Locator);

            //Rename the Query
            this.RenameQuery();

            Logger.LogMethodExit("SIM5FramePage",
                       "AnswerAccessActivityQuestionFourteen",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create query using 'Query Wizard'.
        /// </summary>
        private void CreateQuery()
        {
            //Create query using 'Query Wizard'
            Logger.LogMethodEntry("SIM5FramePage",
                             "CreateQuery",
                       base.IsTakeScreenShotDuringEntryExit);
            //Click on 'Create' link  
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Create_Xpath_Locator);

            //Click 'Query Wizard'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
            SIM5Frame_Page_Access_QueryWizard_Xpath_Locator);

            //Click Ok
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_CreateOk_Xpath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                             "CreateQuery",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add the specified fields to the query.
        /// </summary>
        private void AddFieldsToQuery()
        {
            //Add the specified fields to the query
            Logger.LogMethodEntry("SIM5FramePage",
                             "AddFieldsToQuery",
                       base.IsTakeScreenShotDuringEntryExit);
            //Click Dropdown icon 
            powerPoint.ClickOnElementById(SIM5FramePageResource.
                SIM5Frame_Page_Access_DropdownIcon_Id_Locator);

            //Select '1A Students' from dropdown
            base.WaitForElement(By.XPath(
                    SIM5FramePageResource.
                      SIM5Frame_Page_Access_TableName_XPath_Locator));
            IWebElement getTable = base.GetWebElementPropertiesByXPath(
                      SIM5FramePageResource.
                      SIM5Frame_Page_Access_TableName_XPath_Locator);
            Thread.Sleep(3000);
            base.PerformDoubleClickAction(getTable);
            Thread.Sleep(3000);
            //Add the LastName             
            this.AddIndividualFields(Convert.ToInt32(SIM5FramePageResource.
                 SIM5Frame_Page_Access_StudentLastName_IndexValue));
            //Add the FirstName
            this.AddIndividualFields(Convert.ToInt32(SIM5FramePageResource.
                 SIM5Frame_Page_Access_StudentFirstName_IndexValue));
            //Add the StudentEmail
            this.AddIndividualFields(Convert.ToInt32(SIM5FramePageResource.
                 SIM5Frame_Page_Access_StudentEmail_IndexValue));
            //Add the Phone
            this.AddIndividualFields(Convert.ToInt32(SIM5FramePageResource.
                 SIM5Frame_Page_Access_StudentPhone_IndexValue));
            //Add the StudentId
            this.AddIndividualFields(Convert.ToInt32(SIM5FramePageResource.
                 SIM5Frame_Page_Access_StudentId_IndexValue));
            Logger.LogMethodExit("SIM5FramePage",
                             "AddFieldsToQuery",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add the fields in to the query.
        /// </summary>
        /// <param name="fieldOption">This is the field value.</param>
        private void AddIndividualFields(int fieldOption)
        {
            //Add the fields in to the query
            Logger.LogMethodEntry("SIM5FramePage",
                             "AddIndividualFields",
                       base.IsTakeScreenShotDuringEntryExit);

            base.WaitForElement(By.XPath(String.Format(
               SIM5FramePageResource.
               SIM5Frame_Page_Access_StudentDetails_XPath_Locator, fieldOption)));
            IWebElement getAddField = base.GetWebElementPropertiesByXPath(String.Format(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_StudentDetails_XPath_Locator, fieldOption));
            Thread.Sleep(3000);
            base.PerformDoubleClickAction(getAddField);
            Thread.Sleep(3000);
            //Click add button

            Logger.LogMethodExit("SIM5FramePage",
                             "AddIndividualFields",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Rename the query.
        /// </summary>
        private void RenameQuery()
        {
            //Rename the query
            Logger.LogMethodEntry("SIM5FramePage",
                                  "RenameQuery",
                 base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_Query_Xpath_Locator));
            IWebElement getQueryFillText = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_Query_Xpath_Locator);
            Thread.Sleep(3000);
            base.ClearTextByXPath(SIM5FramePageResource.SIM5Frame_Page_Access_Query_Xpath_Locator);
            Thread.Sleep(3000);
            //Enter the query name
            base.FillTextBoxByXPath(SIM5FramePageResource.SIM5Frame_Page_Access_Query_Xpath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_Access_Query_Rename_Value);
            //Click on 'Finish'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
               SIM5Frame_Page_Access_QueryFinish_Button_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                             "RenameQuery",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Creating and printing a form.
        /// </summary>
        private void AccessActivityQuestionFifteen()
        {
            //Creating and printing a form
            Logger.LogMethodEntry("SIM5FramePage",
                       "AccessActivityQuestionFifteen",
                base.IsTakeScreenShotDuringEntryExit);
            //Create the form
            this.CreateForm();
            this.SwitchToFormView();
            //Print the form
            this.PrintRecord();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                     "AccessActivityQuestionFifteen",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Creat the form.
        /// </summary>
        private void CreateForm()
        {
            //Creat the form
            Logger.LogMethodEntry("SIM5FramePage",
                                   "CreateForm",
                            base.IsTakeScreenShotDuringEntryExit);
            //Click on 'Form' link
            base.WaitForElement(By.XPath(SIM5FramePageResource.
            SIM5Frame_Page_Access_FormButton_XPath_Locator));
            IWebElement getForm = base.GetWebElementPropertiesByXPath(
               SIM5FramePageResource.
            SIM5Frame_Page_Access_FormButton_XPath_Locator);
            base.ClickByJavaScriptExecutor(getForm);
            //Click On Save
            this.ClickOnSave();
            Thread.Sleep(3000);
            //Enter form name 
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_CreateForm_XPath_Locator));
            IWebElement getCreateForm = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_CreateForm_XPath_Locator);
            getCreateForm.SendKeys(Keys.Control + "a");
            Thread.Sleep(2000);
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_CreateForm_XPath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_CreateForm_Name);
            //Click on ok
            base.ClickButtonById(SIM5FramePageResource.
                SIM5Frame_Page_Access_FormOkButton_XPath_Locator);
            Logger.LogMethodExit("SIM5FramePage",
                    "CreateForm",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to Form view.
        /// </summary>
        private void SwitchToFormView()
        {
            //Switch to Form view
            Logger.LogMethodEntry("SIM5FramePage",
                                  "AccessActivityQuestionFifteen",
                           base.IsTakeScreenShotDuringEntryExit);
            //Click on 'Form View' button
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_FormView_XPath_Locator));
            IWebElement clickFormView = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_FormView_XPath_Locator);
            base.ClickByJavaScriptExecutor(clickFormView);
            //Click on record button
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_RecordButton_XPath_Locator));
            IWebElement getRecordButton = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_RecordButton_XPath_Locator);
            base.ClickByJavaScriptExecutor(getRecordButton);
            base.ClickByJavaScriptExecutor(getRecordButton);
            Logger.LogMethodExit("SIM5FramePage",
                       "AccessActivityQuestionFifteen",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Print the recod by adjusting the column width.
        /// </summary>
        private void PrintRecord()
        {
            //Print the recod by adjusting the column width
            Logger.LogMethodEntry("SIM5FramePage",
                 "PrintRecord",
               base.IsTakeScreenShotDuringEntryExit);
            //Open File option and click on Print
            this.OpenFileToPrinting();
            //Click on print option
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Print_XPath_Locator));
            IWebElement clickPrint = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_Print_XPath_Locator);
            base.ClickByJavaScriptExecutor(clickPrint);
            //Select radio button
            base.WaitForElement(By.XPath(SIM5FramePageResource.
               SIM5Frame_Page_Access_PrintRadioButton_XPath_Locator));
            base.SelectRadioButtonByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintRadioButton_XPath_Locator);
            //Click on Setup
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintSetup_XPath_Locator));
            IWebElement clickSetup = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintSetup_XPath_Locator);
            base.ClickByJavaScriptExecutor(clickSetup);
            //Click 'Columns' option
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintColumn_XPath_Locator));
            IWebElement clickColumn = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintColumn_XPath_Locator);
            base.ClickByJavaScriptExecutor(clickColumn);
            //Set column width
            base.WaitForElement(By.XPath(SIM5FramePageResource.
               SIM5Frame_Page_Access_PrintColumn_Ok_XPath_Locator), 10);
            IWebElement getColumWidth = base.GetWebElementPropertiesByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintColumn_Width_XPath_Locator);
            Thread.Sleep(3000);
            getColumWidth.SendKeys(Keys.Control + "a");
            //Enter column width
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintColumn_Width_XPath_Locator));
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintColumn_Width_XPath_Locator,
               SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintColumn_Width_Value);
            Thread.Sleep(3000);
            //click ok  
            base.WaitForElement(By.XPath(SIM5FramePageResource.
            SIM5Frame_Page_Access_PrintColumn_Ok_XPath_Locator));
            IWebElement getButtonOk = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintColumn_Ok_XPath_Locator);
            base.PerformClickAction(getButtonOk);
            IWebElement getOkButton = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
            SIM5Frame_Page_Access_PrintColumnOkButton_XPath_Locator);
            base.PerformMouseClickAction(getOkButton);
            Logger.LogMethodExit("SIM5FramePage",
                      "PrintRecord",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Creating, Modifying and Printing a report.
        /// </summary>
        private void AccessActivityQuestionSixteen()
        {
            //Creating, Modifying and Printing a report
            Logger.LogMethodEntry("SIM5FramePage",
                                 "AccessActivityQuestionSixteen",
                base.IsTakeScreenShotDuringEntryExit);
            this.CreateReport();
            this.AlterFieldProperty();
            //this.DeletePageNumberAndPrintReport();
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PageNumber_XPath_Locator));
            base.FocusOnElementByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PageNumber_XPath_Locator);
            //Press 'Delete' key
            base.PressKey(SIM5FramePageResource.
                 SIM5Frame_Page_Access_Delete_Key);
            Thread.Sleep(3000);
            //Open file for printing
            this.OpenFileToPrinting();
            //Delete page number and print report
            this.DeletePageNumberAndPrintReport();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                             "AccessActivityQuestionSixteen",
            base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Create the report and delete selected column.
        /// </summary>
        private void CreateReport()
        {
            //Create the report and delete selected column
            Logger.LogMethodEntry("SIM5FramePage",
                                  "CreateReport",
                           base.IsTakeScreenShotDuringEntryExit);
            //Click on 'Report' link
            base.WaitForElement(By.XPath(SIM5FramePageResource.
            SIM5Frame_Page_Access_ReportButton_XPath_Locator));
            IWebElement getReport = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
            SIM5Frame_Page_Access_ReportButton_XPath_Locator); ;
            base.ClickByJavaScriptExecutor(getReport);
            //Click on 'Faculty Id' field
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_Access_ReportName_Id_Locator));
            base.FocusOnElementById(SIM5FramePageResource.
                SIM5Frame_Page_Access_ReportName_Id_Locator);
            Thread.Sleep(2000);
            IWebElement getFacultyField = base.GetWebElementPropertiesById(
            SIM5FramePageResource.
                SIM5Frame_Page_Access_ReportName_Id_Locator);
            base.ClickByJavaScriptExecutor(getFacultyField);
            Thread.Sleep(5000);
            //Select 'Arrange' button
            base.WaitForElement(By.XPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_ArrangeButton_XPath_Locator));
            IWebElement getArrange = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_Access_ArrangeButton_XPath_Locator);
            base.ClickByJavaScriptExecutor(getArrange);
            //Select the column
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_ColumnSelectButton_XPath_Locator));
            base.FocusOnElementByXPath
                (SIM5FramePageResource.
                SIM5Frame_Page_Access_ColumnSelectButton_XPath_Locator);
            IWebElement getColumn = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.
                SIM5Frame_Page_Access_ColumnSelectButton_XPath_Locator);
            base.ClickByJavaScriptExecutor(getColumn);
            Thread.Sleep(3000);
            //Press 'Delete' key
            base.PressKey(SIM5FramePageResource.
                SIM5Frame_Page_Access_Delete_Key);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                       "CreateReport",
              base.IsTakeScreenShotDuringEntryExit);
        }

        private void AlterFieldProperty()
        {
            Logger.LogMethodEntry("SIM5FramePage",
                         "AlterFieldPropert",
                base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(3000);
            IWebElement getCampus = base.GetWebElementPropertiesByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access16_FirstField_XPath_Locator);
            IWebElement getFirstName = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_Access16_Field3_XPath_Locator);
            Thread.Sleep(3000);
            base.SelectMultipleElementsUsingShift(Keys.Shift, getCampus, getFirstName);
            Thread.Sleep(3000);
            //Click on 'Property Sheet' option
            IWebElement getPropertyField = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_Access_PropertySheet_XPath_Locator);
            base.ClickByJavaScriptExecutor(getPropertyField);
            //Click on 'Format'
            IWebElement getFormatField = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_Access_Format_XPath_Locator);
            base.ClickByJavaScriptExecutor(getFormatField);
            //Click on 'Width' row
            IWebElement getWidthRow = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.
            SIM5Frame_Page_Access_PropertySheet_Width_XPath_Locator);
            base.PerformClickAction(getWidthRow);
            //Enter the width
            getWidthRow.SendKeys(Keys.Control + "a");
            base.FillTextBoxByXPath(SIM5FramePageResource.
            SIM5Frame_Page_Access_PropertySheet_Width_XPath_Locator,
                SIM5FramePageResource.
            SIM5Frame_Page_Access_PropertySheet_Width_Value_XPath_Locator);
            //Close the 'Property Sheet'
            IWebElement getCloseProperty = base.GetWebElementPropertiesByXPath(
           SIM5FramePageResource.SIM5Frame_Page_Access_PropertySheet_Close_XPath_Locator);
            base.ClickByJavaScriptExecutor(getCloseProperty);
            //Sort the last name field
            this.SortLastNameField();
            Logger.LogMethodExit("SIM5FramePage",
                         "AlterFieldPropert",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Sort the colum names in ascending order.
        /// </summary>
        private void SortLastNameField()
        {
            //Sort the colum names in ascending order
            Logger.LogMethodEntry("SIM5FramePage",
                                        "SortLastNameField",
                            base.IsTakeScreenShotDuringEntryExit);
            //Click Last name field
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_LastNameField_XPath_Locator), 10);
            base.FocusOnElementByXPath(SIM5FramePageResource.
                SIM5Frame_Page_LastNameField_XPath_Locator);
            IWebElement getLastNameField = base.GetWebElementPropertiesByXPath(
                        SIM5FramePageResource.
                SIM5Frame_Page_LastNameField_XPath_Locator);
            base.ClickByJavaScriptExecutor(getLastNameField);
            //Click 'Home'
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Home_Button_XPath_Locator), 10);
            IWebElement getHomeProperty = base.GetWebElementPropertiesByXPath(
              SIM5FramePageResource.SIM5Frame_Page_Access_Home_Button_XPath_Locator);
            base.ClickByJavaScriptExecutor(getHomeProperty);
            //Click on 'Ascending' button
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_AscendingOrderButton_XPath_Locator), 10);
            IWebElement getAscendingButtonProperty = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_AscendingOrderButton_XPath_Locator);
            base.ClickByJavaScriptExecutor(getAscendingButtonProperty);
            Logger.LogMethodExit("SIM5FramePage",
                             "SortLastNameField",
                    base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Delete the page number and print the report
        /// </summary>
        private void DeletePageNumberAndPrintReport()
        {
            //Delete the page number and print the report
            Logger.LogMethodEntry("SIM5FramePage",
                            "DeletePageNumberAndPrintReport",
                            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_PageNumber_XPath_Locator));
            //Focus on the page number
            base.FocusOnElementByXPath(SIM5FramePageResource.
                SIM5Frame_Page_PageNumber_XPath_Locator);
            IWebElement getPageNumber = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_PageNumber_XPath_Locator);
            base.ClickByJavaScriptExecutor(getPageNumber);
            //Press 'Delete' key
            base.PressKey(SIM5FramePageResource.
                SIM5Frame_Page_Access_Delete_Key);
            //Open file for printing
            this.OpenFileToPrinting();
            //Click on Print Preview
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Delete_PrintPreview_XPath_Locator));
            IWebElement clickOnPrintPreview = base.GetWebElementPropertiesByXPath(
                  SIM5FramePageResource.
                SIM5Frame_Page_Access_Delete_PrintPreview_XPath_Locator);
            base.ClickByJavaScriptExecutor(clickOnPrintPreview);
            //Select 'Print'
            base.WaitForElement(By.XPath(SIM5FramePageResource.
            SIM5Frame_Page_Printpage_XPath_Locator));
            IWebElement selectPrint = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
            SIM5Frame_Page_Printpage_XPath_Locator);
            base.ClickByJavaScriptExecutor(selectPrint);
            //Click ok
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_PrintpageOk_XPath_Locator));
            IWebElement getOkProperty = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_PrintpageOk_XPath_Locator);
            base.ClickByJavaScriptExecutor(getOkProperty);
            Logger.LogMethodExit("SIM5FramePage",
                  "DeletePageNumberAndPrintReport",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Closing the database and exiting the access.
        /// </summary>
        private void AccessActivityQuestionSeventeen()
        {
            //Closing the database and exiting the access
            Logger.LogMethodEntry("SIM5FramePage",
                            "AccessActivityQuestionSeventeen",
                            base.IsTakeScreenShotDuringEntryExit);
            //Close all the tables opened
            base.SwitchToLastOpenedWindow();
            //Close all the tables opened            
            base.WaitForElement(By.XPath(
                SIM5FramePageResource.SIM5Frame_Page_CloseTable_XPath_Locator));
            IWebElement getTableName = base.GetWebElementPropertiesByXPath(
                       SIM5FramePageResource.SIM5Frame_Page_CloseTable_XPath_Locator);
            Thread.Sleep(3000);
            base.PerformMouseRightClickAction(getTableName);
            Thread.Sleep(3000);
            //Click on 'Close all Tabs'
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                 SIM5Frame_Page_CloseButton_XPath_Locator));

            IWebElement getCloseAll = base.GetWebElementPropertiesByXPath(
                       SIM5FramePageResource.
                SIM5Frame_Page_CloseButton_XPath_Locator);
            Thread.Sleep(3000);
            base.PerformClickAction(getCloseAll);
            Thread.Sleep(3000);
            this.OpenNavigationPane();
            //Click on file
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                 SIM5Frame_Page_FileOption_XPath_Locator);

            //Click on 'Close'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_FileClose_XPath_Locator);

            //Close 'Access'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_AccessClose_XPath_Locator);


            Logger.LogMethodExit("SIM5FramePage",
                  "AccessActivityQuestionSeventeen",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        ///  Using the template to create the database.
        /// </summary>
        private void AccessActivityQuestionEighteen()
        {
            //Answer Access activity question eighteen
            Logger.LogMethodEntry("SIM5FramePage",
                       "AccessActivityQuestionEighteen",
                base.IsTakeScreenShotDuringEntryExit);
            //Enter the text to be searcher in the search textbox field
            this.EnterTextInSearchTextbox();
            this.CreateTemplate();
            //Click on 'Enable the content'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_EnableContent_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                     "AccessActivityQuestionEighteen",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search for the text entered in the search field.
        /// </summary>
        private void EnterTextInSearchTextbox()
        {
            //Search for the text entered in the search field
            Logger.LogMethodEntry("SIM5FramePage",
                          "EnterTextInSearchTextbox",
                   base.IsTakeScreenShotDuringEntryExit);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                      SIM5Frame_Page_Access_EventSearchField_XPath_Locator);

            base.FillTextBoxByXPath(SIM5FramePageResource.
                      SIM5Frame_Page_Access_EventSearchField_XPath_Locator,
                      SIM5FramePageResource.
                      SIM5Frame_Page_Access_EventSearchField_Text_XPath_Locator);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_EventSearchFieldLookUpIconButton_XPath_Locator);
            Thread.Sleep(5000);
            Logger.LogMethodExit("SIM5FramePage",
                     "EnterTextInSearchTextbox",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create the template and save in Usb.
        /// </summary>
        private void CreateTemplate()
        {
            //Create the template and save in Usb
            Logger.LogMethodEntry("SIM5FramePage",
                          "EnterTextInSearchTextbox",
                   base.IsTakeScreenShotDuringEntryExit);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
             SIM5Frame_Page_Access_CreateTemplate_XPath_Locator);
            //Enter New Template name
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_NewTemplateName_Input_XPath_Locator);
            base.ClearTextByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_NewTemplateName_Input_XPath_Locator);
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_NewTemplateName_Input_XPath_Locator, SIM5FramePageResource.
                SIM5Frame_Page_Access_NewTemplateName_Qs18_String);
            //Click on 'Create'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Template_Create_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                     "EnterTextInSearchTextbox",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Building the table by entering the records in multiple-items form and a single record form.
        /// </summary>
        private void AccessActivityQuestionNinteen()
        {
            //Building the table by entering the records 
            //in multiple-items form and a single record form
            Logger.LogMethodEntry("SIM5FramePage",
                       "AccessActivityQuestionNinteen",
                base.IsTakeScreenShotDuringEntryExit);
            //Enter the Event list items
            this.EventListItems(Convert.ToInt32(
                SIM5FramePageResource.SIM5Frame_Page_Access_EventField_Number),
                SIM5FramePageResource.SIM5Frame_Page_Access_EventList_Item1);
            this.EventListItems(Convert.ToInt32(
                SIM5FramePageResource.SIM5Frame_Page_Access_EventField_NumberThree),
                SIM5FramePageResource.SIM5Frame_Page_Access_EventField_Date);
            this.EventListItems(Convert.ToInt32(
                SIM5FramePageResource.SIM5Frame_Page_Access_EventField_NumberFour)
                , SIM5FramePageResource.SIM5Frame_Page_Access_EventDate_NumberFour);
            this.EventListItems(Convert.ToInt32(
                SIM5FramePageResource.SIM5Frame_Page_Access_EventField_NumberFive),
                SIM5FramePageResource.SIM5Frame_Page_Access_EventData_NumberFive);
            this.EventListItems(Convert.ToInt32(
                SIM5FramePageResource.SIM5Frame_Page_Access_EventField_NumberSix),
                SIM5FramePageResource.SIM5Frame_Page_Access_EventData_NumberSix);
            base.PressKey(SIM5FramePageResource.SIM5Frame_Page_Access_TAB_Key);
            base.PressKey(SIM5FramePageResource.SIM5Frame_Page_Access_TAB_Key);
            //Create a new event
            //Enter Title
            this.NewEventRecord(Convert.ToInt32(
                SIM5FramePageResource.SIM5Frame_Page_Access_EventTitle_Number),
                SIM5FramePageResource.SIM5Frame_Page_Access_EventTitle);
            //Enter Location
            this.NewEventRecord(Convert.ToInt32(
                SIM5FramePageResource.SIM5Frame_Page_Access_EventLocation),
                SIM5FramePageResource.SIM5Frame_Page_Access_EventLocation_Name);
            //Enter Start date
            this.NewEventRecord(Convert.ToInt32(
                SIM5FramePageResource.SIM5Frame_Page_Access_Event_StartDate),
                SIM5FramePageResource.SIM5Frame_Page_Access_Event_StartDate_Value);
            //Enter End date           
            this.NewEventRecord(Convert.ToInt32(
                SIM5FramePageResource.SIM5Frame_Page_Access_Event_EndDate),
                SIM5FramePageResource.SIM5Frame_Page_Access_Event_EndDate_Value);
            //Enter description
            IWebElement getDescription = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_Event_Description);
            base.PerformClickAction(getDescription);
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Event_Description,
              SIM5FramePageResource.SIM5Frame_Page_Access_Event_Description_Text);
            base.PressKey(SIM5FramePageResource.SIM5Frame_Page_Access_TAB_Key);
            base.PressKey(SIM5FramePageResource.SIM5Frame_Page_Access_TAB_Key);
            base.PressKey(SIM5FramePageResource.SIM5Frame_Page_Access_TAB_Key);
            //Close the event record room
            IWebElement getCloseLink = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_CloseEvent_XPath_Locator);
            base.PerformClickAction(getCloseLink);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                     "AccessActivityQuestionNinteen",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter the event details in the respective columns.
        /// </summary>
        /// <param name="eventColumn">This is the column number index value.</param>
        /// <param name="textToEnter">This is the text to enter</param>
        private void EventListItems(int eventColumn, string textToEnter)
        {
            //Enter the event details in the respective columns
            Logger.LogMethodEntry("SIM5FramePage",
                       "EventListItems",
                base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Sleep_Time));
            IWebElement getEventColumn = base.GetWebElementPropertiesByXPath(
                String.Format(SIM5FramePageResource.
                SIM5Frame_Page_Access_EventList_XPath_Locator, eventColumn));
            base.DoubleClickByJavaScriptExecuter(getEventColumn);
            base.FillTextBoxByXPath(String.Format(
               SIM5FramePageResource.
               SIM5Frame_Page_Access_EventList_XPath_Locator1, eventColumn), textToEnter);
            base.PressKey(SIM5FramePageResource.SIM5Frame_Page_Access_TAB_Key);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                 SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                     "EventListItems",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create a new event record.
        /// </summary>
        private void NewEventRecord(int eventDetailType, string eventDetailsToFill)
        {
            //Create a new event record
            Logger.LogMethodEntry("SIM5FramePage",
                       "NewEventRecord",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on 'New' to create new event
            bool gafs = base.IsElementPresent(By.XPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_NewEventField_XPath_Locator), 10);
            IWebElement getNewColumn = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_NewEventField_XPath_Locator);
            base.PerformClickAction(getNewColumn);
            //Enter the event details
            IWebElement getEvent = base.GetWebElementPropertiesByXPath(
                String.Format(SIM5FramePageResource.
                SIM5Frame_Page_Access_NewEventdetails_XPath_Locator, eventDetailType));
            base.PerformClickAction(getEvent);
            base.FillTextBoxByXPath(String.Format(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_NewEventdetails_XPath_Locator, eventDetailType),
                eventDetailsToFill);
            base.PressKey(SIM5FramePageResource.SIM5Frame_Page_Access_TAB_Key);
            Logger.LogMethodExit("SIM5FramePage",
                     "NewEventRecord",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Appending records by importing from an excel spreadsheet.
        /// </summary>
        private void AccessActivityQuestionTwenty()
        {
            //Appending records by importing from an excel spreadsheet
            Logger.LogMethodEntry("SIM5FramePage",
                       "AccessActivityQuestionNinteen",
                base.IsTakeScreenShotDuringEntryExit);
            this.AppendExcelFileFromUsb();
            this.OpenEventList();
            this.ApplyBestFit();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                     "AccessActivityQuestionNinteen",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Append the excel from usb.
        /// </summary>
        private void AppendExcelFileFromUsb()
        {
            //Append the excel from usb
            Logger.LogMethodEntry("SIM5FramePage",
                           "AppendExcelFileFromUsb",
                    base.IsTakeScreenShotDuringEntryExit);
            //Select the Excel file and from Usb
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_ExternalLink_XPath_Locator);

            this.SelectExcelFileInUsb();
            //Select 'Append to student' radio button 
            base.WaitForElement(By.Id(SIM5FramePageResource.
                SIM5Frame_Page_Access_AppendradioButton_Id_Locator));
            IWebElement getElementProperty = base.GetWebElementPropertiesById(SIM5FramePageResource.
                SIM5Frame_Page_Access_AppendradioButton_Id_Locator);
            Thread.Sleep(4000);
            base.PerformMouseClickAction(getElementProperty);
            Thread.Sleep(2000);


            //Click on ok
            powerPoint.ClickOnElementById(SIM5FramePageResource.
                SIM5Frame_Page_Access_AppendOkButton_Id_Locator);

            //Click on next
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Next_XPath_Locator);

            //click 'Finish'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_AppendFinish_XPath_Locator);

            //CLick 'Close'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
               SIM5Frame_Page_Access_AppendClose_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                     "AppendExcelFileFromUsb",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Open the event list form from the navigation pane. 
        /// </summary>
        private void OpenEventList()
        {
            //Open the event list form from the navigation pane
            Logger.LogMethodEntry("SIM5FramePage",
                       "OpenEventList",
                base.IsTakeScreenShotDuringEntryExit);
            //Open the navigation pane
            this.OpenNavigationPane();
            IWebElement getEventList = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_OpenEvent_XPath_Locator);
            Thread.Sleep(3000);
            base.PerformDoubleClickAction(getEventList);
            Thread.Sleep(3000);
            //Close the navigation pane
            this.CloseNavigationPane();
            Logger.LogMethodExit("SIM5FramePage",
                     "OpenEventList",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select all columns and apply best fit option.
        /// </summary>
        private void ApplyBestFit()
        {
            //Select all columns and apply best fit option
            Logger.LogMethodEntry("SIM5FramePage",
                       "ApplyBestFit",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on 'Select all' button
            base.ClickButtonByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_SelectAllColumn_Xpath_Locator);
            //Double click on the column rightend
            IWebElement getColumnRightEnd = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.
                SIM5Frame_Page_Access_ColumnRightEnd_XPath_Locator);
            Thread.Sleep(3000);
            base.DoubleClickByJavaScriptExecuter(getColumnRightEnd);
            Thread.Sleep(3000);
            //Click on save
            this.ClickOnSave();
            Logger.LogMethodExit("SIM5FramePage",
                     "ApplyBestFit",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Grouping database objects in navigation pane.
        /// </summary>
        private void AccessActivityQuestionTwentyone()
        {
            //Grouping database objects in navigation pane
            Logger.LogMethodEntry("SIM5FramePage",
                       "AccessActivityQuestionTwentyone",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on navigation panel menu arrow
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PanelRow_XPath_Locator);

            //Select grouping option fron list
            IWebElement getListOption = base.GetWebElementPropertiesById(
                SIM5FramePageResource.SIM5Frame_Page_Access__GroupingElement_Id_Locator);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
             SIM5Frame_Page_Sleep_Time));
            base.PerformClickAction(getListOption);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                     "AccessActivityQuestionTwentyone",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Using the table tool to create new table.
        /// </summary>
        private void AccessActivityQuestionTwentyTwo()
        {
            //Using the table tool to create new table
            Logger.LogMethodEntry("SIM5FramePage",
                       "AccessActivityQuestionTwentyTwo",
                base.IsTakeScreenShotDuringEntryExit);
            //Create new table
            this.CreateTable();
            this.ClickOnField(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_ClickOnField_Index_Value));
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                 SIM5Frame_Page_Sleep_Time));
            this.SelectMenuOption(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_SelectMenu_Index_Value));
            this.FillField(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Access_ClickOnField_Index_Value),
                SIM5FramePageResource.SIM5Frame_Page_Access_FillField_Value);
            base.PressKey(SIM5FramePageResource.SIM5Frame_Page_Access_EnterKey);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Sleep_Time));
            //Rename the id field
            this.SetIdFieldDatatype();
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                     "AccessActivityQuestionTwentyTwo",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create new table.
        /// </summary>
        private void CreateTable()
        {
            //Create new table
            Logger.LogMethodEntry("SIM5FramePage",
                          "CreateTable",
                   base.IsTakeScreenShotDuringEntryExit);
            //Click on Create
            IWebElement getCreate = base.GetWebElementPropertiesByXPath(
               SIM5FramePageResource.SIM5Frame_Page_Access_Create_Xpath_Locator);
            base.ClickByJavaScriptExecutor(getCreate);
            //Click on 'table' link
            IWebElement getTable = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_Table_XPath_Locator);
            base.PerformClickAction(getTable);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                     "CreateTable",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set the datatype of Id field.
        /// </summary>
        private void SetIdFieldDatatype()
        {
            //Set the datatype of Id field
            Logger.LogMethodEntry("SIM5FramePage",
                        "SetIdFieldDatatype",
                 base.IsTakeScreenShotDuringEntryExit);
            IWebElement getIdField = base.GetWebElementPropertiesByXPath(
               SIM5FramePageResource.SIM5Frame_Page_AccessPage_FirstField_XPathLocator1);
            base.PerformMouseRightClickAction(getIdField);
            //Select 'Rename' option
            IWebElement getRenameField = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_Rename_XPath_Locator);
            base.PerformClickAction(getRenameField);
            //enter Id
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_AccessPage_FirstField_Input_XPathLocator,
                SIM5FramePageResource.SIM5Frame_Page_Access_IdValue);
            //Click on datatype cmenu
            IWebElement getDatatypeField = base.GetWebElementPropertiesByXPath(
           SIM5FramePageResource.
           SIM5Frame_Page_AccessPage_FirstField_DataTypeMenu_XPath_Locator);
            base.ClickByJavaScriptExecutor(getDatatypeField);
            //Select 'Short text'
            IWebElement getShortText = base.GetWebElementPropertiesByXPath(
           SIM5FramePageResource.
           SIM5Frame_Page_AccessPage_FirstField_DataTypeSelect_XPath_Locator);
            base.ClickByJavaScriptExecutor(getShortText);
            Logger.LogMethodExit("SIM5FramePage",
                     "SetIdFieldDatatype",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Entering records into a new table.
        /// </summary>
        private void AccessActivityQuestionTwentyThree()
        {
            //Entering records into a new table
            Logger.LogMethodEntry("SIM5FramePage",
                       "AccessActivityQuestionTwentyThree",
                base.IsTakeScreenShotDuringEntryExit);
            //Enter Id value
            powerPoint.IsQuestionLoaded("23");
            IWebElement getRoomIdField = base.GetWebElementPropertiesByXPath(
                SIM5FramePageResource.SIM5Frame_Page_Access_IdField_XPath_Locator);
            Thread.Sleep(5000);
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_IdField_XPath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_Access_IdField_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_IdField_XPath_Locator);
            //Enter 'Campus/Location' field
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_CampusLocation_Field_XPath_Locator,
                SIM5FramePageResource.
                SIM5Frame_Page_Access_CampusLocation_Field_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_CampusLocation_Field_XPath_Locator);
            //Enter 'Room' field
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Room_Field_XPath_Locator,
                SIM5FramePageResource.
                SIM5Frame_Page_Access_Room_Field_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Room_Field_XPath_Locator);
            //Enter 'Seats' field
            base.FillTextBoxByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Seat_Field_XPath_Locator, SIM5FramePageResource.
                SIM5Frame_Page_Access_Seat_Field_Value);
            base.PressEnterKeyByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Access_Seat_Field_XPath_Locator);
            //Apply BestFit to the columns
            this.SetAllFielColumnWidth();
            //Select 'Best Fit' option
            Logger.LogMethodExit("SIM5FramePage",
                    "AccessActivityQuestionTwentyThree",
           base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Viewing report and printing the report.
        /// </summary>
        private void AccessActivityQuestionTwentyFour()
        {
            //Viewing report and printing the report
            Logger.LogMethodEntry("SIM5FramePage",
                       "AccessActivityQuestionTwentyFour",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on 'All event' in the navigation pane
            IWebElement getAllEvent = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.SIM5Frame_Page_Access_AllEvent_XPath_Locator);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
             SIM5Frame_Page_Sleep_Time));
            base.PerformDoubleClickAction(getAllEvent);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
             SIM5Frame_Page_Sleep_Time));
            //Click on 'print preview'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                        SIM5Frame_Page_Access_AllEvent_PrintPreview_XPath_Locator);

            //Click on 'Print'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                        SIM5Frame_Page_Access_PrintIcon_Xpath_Locator);

            //Click on 'OK'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_PrintpageOk_XPath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                     "AccessActivityQuestionTwentyFour",
            base.IsTakeScreenShotDuringEntryExit);
        }

        private void AccessActivityQuestionFive()
        {
            Logger.LogMethodEntry("SIM5FramePage",
                       "AccessActivityQuestionFive",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the table name 
            IWebElement getStudentTable = base.GetWebElementPropertiesByXPath(
            SIM5FramePageResource.
            SIM5Frame_Page_Access_StudentTableName_XPath_Locator);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
             SIM5Frame_Page_Sleep_Time));
            base.PerformDoubleClickAction(getStudentTable);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
             SIM5Frame_Page_Sleep_Time));
            //Click on file and Print
            this.OpenFileToPrinting();
            //Click on 'Print Preview
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                    SIM5Frame_Page_Access_PrintPreviewLink_Xpath_Locator);

            //Select 'Landscape' option
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                        SIM5Frame_Page_Access_PrintLandscape_Xpath_Locator);

            //Select 'Print'
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Printpage_XPath_Locator);

            //Click ok
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Access_PrintColumnOkButton_XPath_Locator);

            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
               SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                     "AccessActivityQuestionFive",
            base.IsTakeScreenShotDuringEntryExit);
        }

        #region SIM5 Excel Eleventh Question
        /// <summary>
        /// Charting Data and Using Recommended .
        /// Charts to Select and Insert a Column Chart .
        /// </summary>
        public void ChartingDataUsingRecomendedChartsInsertChart()
        {
            Logger.LogMethodEntry("SIM5FramePage",
                   "AttemptingEleventhExcelQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            // Charting Data and Using Recommended Charts to Select and Insert a Column Chart 
            //Selecting Cell Range
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_Block_A3_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_Block_D7_Id_Locator);
            //Clicking on Insert Button
            base.ClickButtonByXPath(SIM5FramePageResource.SIM5Frame_Page_Insert_Button_Xpath_Locator);
            //Selecting RecomendedChart Image
            base.ClickImageByXPath(SIM5FramePageResource.SIM5Frame_Page_RecomendedChart_Image_Xpath_Locator);
            //Selecting Style Type 5
            base.FocusOnElementByXPath(SIM5FramePageResource.
                SIM5Frame_Page_RecomendedChart_Type5_Xpath_Locator);
            IWebElement shape = base.GetWebElementPropertiesByXPath(SIM5FramePageResource.
                SIM5Frame_Page_RecomendedChart_Type5_Xpath_Locator);
            base.ClickByJavaScriptExecutor(shape);
            //Clicking OK Button
            base.ClickButtonById(SIM5FramePageResource.SIM5Frame_Page_Ok_Button_Id_Locator);
            Logger.LogMethodExit("SIM5FramePage",
                           "AttemptingEleventhExcelQuestion",
                  base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion
        /// <summary>
        ///  Attempting Excel Twelfth Question
        /// </summary>
        public void UsingChartToolsSetChartLayoutsandStyles()
        {
            Logger.LogMethodEntry("SIM5FramePage",
                  "AttemptingTwelfthExcelQuestion",
           base.IsTakeScreenShotDuringEntryExit);
            //Selecting Chart Image
            base.ClickImageById(SIM5FramePageResource.SIM5Frame_Page_Chart_Title_Id_Locator);
            //Selecting Formula Box
            IWebElement formulaBox = base.GetWebElementPropertiesById
                (SIM5FramePageResource.SIM5Frame_Page_FormulaBox_Id_Locator);
            base.ClickByJavaScriptExecutor(formulaBox);
            //Filling Text to Formula Box
            base.FillTextBoxById(SIM5FramePageResource.SIM5Frame_Page_FormulaBox_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_FormulaBox_Text_Fill);
            //Enter Key Action
            base.PressEnterKeyById(SIM5FramePageResource.
                SIM5Frame_Page_FormulaBox_Id_Locator);
            base.ClickImageByXPath(SIM5FramePageResource.
                SIM5Frame_Page_Chart_Image_Xpath_Locator);
            IWebElement designTab = base.GetWebElementPropertiesByXPath
                (SIM5FramePageResource.SIM5Frame_Page_Design_Tab_Xpath_Locator);
            base.ClickByJavaScriptExecutor(designTab);
            IWebElement shape6 = base.GetWebElementPropertiesByXPath
                (SIM5FramePageResource.SIM5Frame_Page_Shape6_Image_Xpath_Locator);
            base.ClickByJavaScriptExecutor(shape6);
            base.ClickImageByXPath(SIM5FramePageResource.
                SIM5Frame_Page_ColorOption_Image_Xpath_Locator);
            base.FocusOnElementByXPath(SIM5FramePageResource.
                SIM5Frame_Page_ColorOption_Image_Xpath_Locator);
            base.ClickImageByXPath(SIM5FramePageResource.
                SIM5Frame_Page_ColorOption_Image_Xpath_Locator);
            //Drag and Drop Chart Image
            IWebElement imageBlock = base.GetWebElementPropertiesByXPath
                (SIM5FramePageResource.SIM5Frame_Page_Chart_Image_Xpath_Locator);
            IWebElement blockId = base.GetWebElementPropertiesById
                (SIM5FramePageResource.SIM5Frame_Page_Block_A10_Id_Locator);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                SIM5Frame_Page_Sleep_Time));
            base.DragAndDropWebElement(imageBlock, blockId);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                   SIM5Frame_Page_Sleep_Time));
            Logger.LogMethodExit("SIM5FramePage",
                             "AttemptingTwelfthExcelQuestion",
                    base.IsTakeScreenShotDuringEntryExit);

        }

        #region SIM5 Excel Thirteenth Question
        /// <summary>
        /// Creating and Formatting Sparklines .
        /// </summary>
        public void CreatingandFormattingSparkLines()
        {
            Logger.LogMethodEntry("SIM5FramePage",
                    "AttemptingthirteenthExcelQuestion",
             base.IsTakeScreenShotDuringEntryExit);
            //Selecting Box Range
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_Block_B4_Id_Locator, SIM5FramePageResource.
                SIM5Frame_Page_Block_D7_Id_Locator);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Insert_Button_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Sparkline_Option_Xpath_Locator);
            //Filling Text to Range Location
            base.WaitForElement(By.XPath(SIM5FramePageResource.
                SIM5Frame_Page_LocationRange_Xpath_Locator));
            IWebElement getpointer = base.GetWebElementPropertiesByXPath
             (SIM5FramePageResource.SIM5Frame_Page_LocationRange_Xpath_Locator);
            Thread.Sleep(3000);
            base.DoubleClickByJavaScriptExecuter(getpointer);
            Thread.Sleep(3000);
            getpointer.SendKeys(Keys.Control + "a");
            Thread.Sleep(3000);
            base.FillTextBoxByXPath(SIM5FramePageResource.SIM5Frame_Page_LocationRange_Xpath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_LocationRange_Text_Fill);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Ok_Button_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.SIM5Frame_Page_Markers_CheckBox_Xpath_Locator);
            powerPoint.ClickOnElementByCssSelector(SIM5FramePageResource.SIM5Frame_Page_SparkStyle_CSS_Locator);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.SIM5Frame_Page_SparkStyle_Type_Xpath_Locator);

            Logger.LogMethodExit("SIM5FramePage",
                             "AttemptingthirteenthExcelQuestion",
                    base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        #region SIM5 Excel Twenty fourth Question
        /// <summary>
        /// Formatting cells with the percent style.
        /// </summary>
        private void FormatCellWithPercentStyle()
        {
            //Formatting cells with the percent style
            Logger.LogMethodEntry("SIM5FramePage",
                   "FormatCellWithPercentStyle",
                 base.IsTakeScreenShotDuringEntryExit);
            //Select the cells
            this.SelectCellRange(SIM5FramePageResource.
                SIM5Frame_Page_Excel_E24_CellStart_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_Excel_E24_CellEnd_Id_Locator);
            //Click on Percentile 
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                 SIM5Frame_Page_Excel_E24_Percentile_XPath_Locator);

            //Click on Increase decimal option
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                   SIM5Frame_Page_Excel_E24_IncreasePercent_XPath_Locator);

            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                   SIM5Frame_Page_Excel_E24_IncreasePercent_XPath_Locator);
            //Apply center align
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                  SIM5Frame_Page_Excel_E24_CenterAlign_XPath_Locator);

        }
        #endregion

        #region SIM5 Excel Twenty First Question
        /// <summary>
        /// Using the Quick Analysis Tool .
        /// </summary>
        public void UsingQuickAnalysisTool()
        {
            Logger.LogMethodEntry("SIM5FramePage",
                   "AttemptingTwentyFirstQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            //Use the Quick Analysis button to sum the range E4:E9 and 
            //place the result in cell E10. Select the range C5:E9, and then 
            //apply Comma Style. Simultaneously format the range C4:E4 and cell E10 with Accounting Number Format.
            //Format cell E10 with the Total style. 
            IWebElement getE4Cell = base.GetWebElementPropertiesById(
            SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E4_Cell_Id_Locator);
            base.PerformMouseClickAction(getE4Cell);
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E4_Cell_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E9_Cell_Id_Locator);

            IWebElement Sheet1_E9Properties = base.GetWebElementPropertiesById
                (SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E9_Cell_Id_Locator);
            base.PerformMouseHoverAction(Sheet1_E9Properties);
            Thread.Sleep(3000);

            IWebElement quickToolBar = base.GetWebElementPropertiesByXPath
                (SIM5FramePageResource.SIM5Frame_Page_QuickToolBar_Xpath_Locator);
            Thread.Sleep(3000);
            base.PerformMouseHoverByJavaScriptExecutor(quickToolBar);
            base.ClickImageByXPath(SIM5FramePageResource.SIM5Frame_Page_QuickToolBar_Xpath_Locator);
            Thread.Sleep(3000);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_QuickAnalysisButton_Xpath_ocator);
            powerPoint.ClickOnElementByCssSelector(SIM5FramePageResource.
                SIM5Frame_Page_QuickSumOption_CSS_Locator);
            //Applying Comma Style
            IWebElement getC5Cell = base.GetWebElementPropertiesById(
           SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_C5_Cell_Id_Locator);
            base.PerformMouseClickAction(getC5Cell);
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_C5_Cell_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E9_Cell_Id_Locator);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_CommaImage_Xpath_Locator);


            //Simultaneously Selecting Text Box     
            IWebElement getC4Cell = base.GetWebElementPropertiesById(
           SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_C4_Cell_Id_Locator);
            base.PerformMouseClickAction(getC4Cell);
            this.SelectCellRange(SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_C4_Cell_Id_Locator,
                SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E4_Cell_Id_Locator);

            IWebElement blockE10 = base.GetWebElementPropertiesById
                (SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E10_Cell_Id_Locator);
            new Actions(WebDriver).KeyDown(Keys.Control).Click(blockE10).KeyUp(Keys.Control).Perform();
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Accounting_NumberFormat_Xpath_ocator);


            //Selecting Totals Cell Styles
            base.PerformMouseClickAction(Sheet1_E9Properties);
            Thread.Sleep(3000);
            base.PerformMouseClickAction(blockE10);


            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_CellStyles_Xpath_Locator);
            powerPoint.ClickOnElementByXpath(SIM5FramePageResource.
                SIM5Frame_Page_Total_CellStyles_Xpath_Locator);


            Logger.LogMethodExit("SIM5FramePage",
                            "AttemptingTwentyFirstQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        /// <summary>
        /// Fill Excel cell.
        /// </summary>
        /// <param name="refCell">Cell Id</param>
        /// <param name="formulaValue">Cell value</param>
        private void PutExcelValueInCellWithoutErasingText(string referenceCellId, string formulaValue)
        {
            //Fill Excel cell
            Logger.LogMethodEntry("SIM5FramePage",
                "PutExcelValueInCellWithoutErasingText",
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
            Logger.LogMethodExit("SIM5FramePage",
                          "PutExcelValueInCellWithoutErasingText",
                 base.IsTakeScreenShotDuringEntryExit);

        }

        #region SIM5 Excel Twenty Second Question
        /// <summary>
        /// Copying Formulas Containing Absolute Cell References .
        /// </summary>
        private void CopyingFormulasContainingAbsoluteCellReferences()
        {
            Logger.LogMethodEntry("SIM5FramePage",
               "PutExcelValueInCellWithoutErasingText",
              base.IsTakeScreenShotDuringEntryExit);
            //In cell F4, enter a formula that divides the Total Retail Value in E4 by the Total Retail Value for All Products in E10. 
            //Set E10 as an absolute cell reference in the formula. 
            //Copy the formula from cell F4 down through cells F5:F9. 
            base.SwitchToLastOpenedWindow();
            IWebElement BlockF4 = base.GetWebElementPropertiesById
                (SIM5FramePageResource.SIM5Frame_Page_Excel_E24_CellStart_Id_Locator);
            base.PerformMouseClickAction(BlockF4);
            Thread.Sleep(Convert.ToInt32(SIM5FramePageResource.
                    SIM5Frame_Page_SIM5_Buffer_Sleep_Time));
            base.ClearTextById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);
            //Fill vlaue in Formula Box 
            base.FillTextBoxById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator, "=E4/$E$10");
            PressEnterKeyById(SIM5FramePageResource.
                SIM5Frame_Page_SIM5_Excel_Formula_TextBox_Id_Locator);

            IWebElement BlockE4 = base.GetWebElementPropertiesById
                (SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E4_Cell_Id_Locator);

            IWebElement BlockE10 = base.GetWebElementPropertiesById
                (SIM5FramePageResource.SIM5Frame_Page_SIM5_Excel_E10_Cell_Id_Locator);
            Thread.Sleep(3000);
            base.PerformMouseClickAction(BlockE10);

            base.PerformMouseClickAction(BlockF4);
            this.SelectCellRangeByXpath
                (SIM5FramePageResource.SIM5Frame_Page_SIM5_Block_Dragger_Xpath_Locator,
                SIM5FramePageResource.SIM5Frame_Page_Excel_E24_CellEnd_Id_Locator);
            Logger.LogMethodEntry("SIM5FramePage",
               "PutExcelValueInCellWithoutErasingText",
              base.IsTakeScreenShotDuringEntryExit);
        }
        #endregion

        /// <summary>
        /// Select Cell Range By Xpath
        /// </summary>
        private void SelectCellRangeByXpath(string firstCellID, string lastCellID)
        {
            Logger.LogMethodEntry("SIM5FramePage",
                    "SelectCellRange",
                   base.IsTakeScreenShotDuringEntryExit);
            //Get first cell object          
            IWebElement getFirstCellObject = base.GetWebElementPropertiesByXPath(firstCellID);
            //Get Last cell object
            IWebElement getLastCellObject = base.GetWebElementPropertiesById(lastCellID);
            //select and drag the range from the first cell above to the last cell
            base.PerformDragAndDropAction(getFirstCellObject, getLastCellObject);
            Logger.LogMethodExit("SIM5FramePage",
                "SelectCellRange",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit Access activty Pre-Test Sim5 Questions.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        public void SubmitSim5AccessActivityQuestionsfor70Percentage(String activityName)
        {
            Logger.LogMethodEntry("SIM5FramePage",
                        "SubmitSim5AccessActivityQuestionsfor70Percentage",
                       base.IsTakeScreenShotDuringEntryExit);
            //Submit Access activty Pre-Test Sim5 Questions
            new StudentPresentationPage().SelectSimActivityNormalStudentWindowName
                 (activityName);
            //Access Second Question
            powerPoint.JumpToQuestion("2");
            this.AccessSecondQuestion(SIM5FramePageResource.
                SIM5Frame_Page_Access_PreTest_FileName);
            //Access Third Question
            powerPoint.JumpToQuestion("3");
            this.AccessPreTestThirdQuestion();
            //Access Fourth Question
            powerPoint.JumpToQuestion("4");
            this.AccessFourthQuestion(SIM5FramePageResource.
                SIM5Frame_Page_AccessPage_FirstField_InputValue_XPathLocator);
            //Access Fifth Question
            powerPoint.JumpToQuestion("5");
            this.AccessFifthQuestion();
            //Access Sixth Question
            powerPoint.JumpToQuestion("6");
            this.AccessSixthQuestion();
            //Access Seventh Question
            powerPoint.JumpToQuestion("7");
            this.AccessSeventhQuestion();
            //Access Eight Question
            powerPoint.JumpToQuestion("8");
            this.AccessActivityQuestionEight();
            //Access Activity Question Ten
            powerPoint.JumpToQuestion("10");
            this.AccessActivityQuestionTen();
            //Access Activity Question Eleven
            powerPoint.JumpToQuestion("11");
            this.AccessActivityQuestionEleven();
            //Access Activity Question Thirteen
            powerPoint.JumpToQuestion("13");
            this.AccessActivityQuestionThirteen();
            //Access Activity Question Fourteen
            powerPoint.JumpToQuestion("14");
            this.AnswerAccessActivityQuestionFourteen();
            //Access Activity Question Seventeen
            powerPoint.JumpToQuestion("17");
            this.AccessActivityQuestionSeventeen();
            //Access Activity Question Eighteen
            powerPoint.JumpToQuestion("18");
            this.AccessActivityQuestionEighteen();
            //Access Activity Question Twenty
            powerPoint.JumpToQuestion("20");
            this.AccessActivityQuestionTwenty();
            //Access Activity Question Twentyone
            powerPoint.JumpToQuestion("21");
            this.AccessActivityQuestionTwentyone();
            //Access Activity Question TwentyThree
            powerPoint.JumpToQuestion("23");
            this.AccessActivityQuestionTwentyThree();
            //Access Activity Question TwentyFour
            powerPoint.JumpToQuestion("24");
            this.AccessActivityQuestionTwentyFour();
            //Access Activity Question TwentyFive
            powerPoint.JumpToQuestion("25");
            this.AccessActivityQuestionFive();
            //Click Submit Button
            StudentPresentationPage studentPresentation = new StudentPresentationPage();
            studentPresentation.ClickOnSim5ActivitySubmitButton();
            Logger.LogMethodExit("SIM5FramePage",
                        "SubmitSim5AccessActivityQuestionsfor70Percentage",
                       base.IsTakeScreenShotDuringEntryExit);
        }
    }
}


