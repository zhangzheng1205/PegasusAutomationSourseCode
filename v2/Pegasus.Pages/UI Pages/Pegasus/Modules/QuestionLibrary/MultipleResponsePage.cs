﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.QuestionLibrary;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handles Multiple Response Page actions
    /// </summary>
    public class MultipleResponsePage : BasePage
    {

        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(MultipleResponsePage));

        /// <summary>
        /// Create Multiple Response Question.
        /// </summary>
        public void CreateMultipleResponseQuestion()
        {
            //Create Multiple Response Question
            logger.LogMethodEntry("MultipleResponsePage", "CreateMultipleResponseQuestion",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create Multiple Response Window
                this.SelectCreateMultipleResponseWindow();
                //Enter Question Title
                string questionDetails = this.EnterQuestionTitle().ToString();
                //Click On View Source Button and Fill Question details
                this.ClickOnViewSourceAndEnterDataForMultipleResponseQuestion(questionDetails);
                //Click On Add Choice Button
                this.ClicKOnAddChoiceButton();
                //Select Edit Button to Fill Text
                this.SelectEditButtonAndFillText(questionDetails);
                //Select Edit Button To Insert Image
                this.SelectEditButtonToInsertImage();
                //Select Edit Button To Insert Audio
                this.SelectEditButtonAndInsertAudio();
                //Select Edit Button To Insert Video
                this.SelectEditButtonAndInsertVideo();
                //Fill The Score Value
                this.FillScoreValue();
                //Click On Save And Close Button
                this.ClickONSaveAndCloseButtonOfMultipleResponseQuestion();
                //Store Question Details
                this.StoreQuestionDetailsInMemory(questionDetails);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MultipleResponsePage", "CreateMultipleResponseQuestion",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Multiple Response Window.
        /// </summary>
        private void SelectCreateMultipleResponseWindow()
        {
            //Select Create Multiple Response Window
            logger.LogMethodEntry("MultipleResponsePage", "SelectCreateMultipleResponseWindow",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(MultipleResponsePageResource.
                MultipleResponse_Page_CreateMultipleResponse_Window_Name);
            //Select Create Multiple Response Window
            base.SelectWindow(MultipleResponsePageResource.
                MultipleResponse_Page_CreateMultipleResponse_Window_Name);
            logger.LogMethodExit("MultipleResponsePage", "SelectCreateMultipleResponseWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Question Title.
        /// </summary>
        /// <returns>Question Title Guid</returns>
        private Guid EnterQuestionTitle()
        {
            //Enter Question Title
            logger.LogMethodEntry("MultipleResponsePage", "EnterQuestionTitle",
                base.IsTakeScreenShotDuringEntryExit);
            //Generate Question Title Guid
            Guid questionTitle = Guid.NewGuid();
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_EnterQuestionTitle_Id_Locator));
            //Fill the Question Title
            base.FillTextBoxById(MultipleResponsePageResource.
                MultipleResponse_Page_EnterQuestionTitle_Id_Locator, questionTitle.ToString());
            logger.LogMethodExit("MultipleResponsePage", "EnterQuestionTitle",
                base.IsTakeScreenShotDuringEntryExit);
            return questionTitle;
        }

        /// <summary>
        /// Click on View Source Button and enter HTML Text.
        /// </summary>
        /// <param name="questionText">This is Question text</param>
        private void ClickOnViewSourceAndEnterDataForMultipleResponseQuestion
            (string questionText)
        {
            //Click On View Source Button and Enter Data
            logger.LogMethodEntry("MultipleResponsePage",
                "ClickOnViewSourceAndEnterDataForMultipleResponseQuestion",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Frame
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_Frame_Id_Locator));
            base.SwitchToIFrame(MultipleResponsePageResource.
                MultipleResponse_Page_Frame_Id_Locator);
            //Wait for view Source Button
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_ViewSource_Button_Id_Locator));
            //Click on View Source Button
            base.ClickButtonById(MultipleResponsePageResource.
                MultipleResponse_Page_ViewSource_Button_Id_Locator);
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_EnterTextHTML_Id_Locator));
            //Enter data
            base.FillTextBoxById(MultipleResponsePageResource.
                MultipleResponse_Page_EnterTextHTML_Id_Locator, questionText);
            //Click on View Source Button
            base.ClickButtonById(MultipleResponsePageResource.
                MultipleResponse_Page_ViewSource_Button_Id_Locator);
            logger.LogMethodExit("MultipleResponsePage",
                "ClickOnViewSourceAndEnterDataForMultipleResponseQuestion",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Pallette Characters.
        /// </summary>
        private void AddPalletteCharacters()
        {
            //Add Pallette Characters
            logger.LogMethodEntry("MultipleResponsePage", "AddPalletteCharacters",
                base.IsTakeScreenShotDuringEntryExit);
            //Add a character
            this.ClickOnCharacterPalleteButton(MultipleResponsePageResource.
                MultipleResponse_Page_CharacterPalletea_Xpath_Locator_one);
            //Add e character
            this.ClickOnCharacterPalleteButton(MultipleResponsePageResource.
                MultipleResponse_Page_CharacterPalletee_Xpath_Locator_two);
            //Add i character
            this.ClickOnCharacterPalleteButton(MultipleResponsePageResource.
                MultipleResponse_Page_CharacterPalletei_Xpath_Locator_three);
            //Add o character
            this.ClickOnCharacterPalleteButton(MultipleResponsePageResource.
                MultipleResponse_Page_CharacterPalleteo_Xpath_Locator_four);
            //Add u character
            this.ClickOnCharacterPalleteButton(MultipleResponsePageResource.
                MultipleResponse_Page_CharacterPalleteu_Xpath_Locator_five);
            logger.LogMethodExit("MultipleResponsePage", "AddPalletteCharacters",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Character Pallette.
        /// </summary>
        /// <param name="locator">This is Locator of Pallete Character</param>
        private void ClickOnCharacterPalleteButton(string locator)
        {
            //Click on Character Pallette
            logger.LogMethodEntry("MultipleResponsePage", "ClickOnCharacterPalleteButton",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(locator));
            base.FocusOnElementByXPath(locator);
            //Get Button Property
            IWebElement getButtonProperty = base.GetWebElementPropertiesByXPath(locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("MultipleResponsePage", "ClickOnCharacterPalleteButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Choice Button.
        /// </summary>
        private void ClicKOnAddChoiceButton()
        {
            //Click On Add Choice Button
            logger.LogMethodEntry("MultipleResponsePage", "ClicKOnAddChoiceButton",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Create Multiple Response Window
            base.SelectWindow(MultipleResponsePageResource.
                MultipleResponse_Page_CreateMultipleResponse_Window_Name);
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_AddChoice_Button_Id_Locator));
            //Get Add Choice Button Property
            IWebElement getAddChoiceButtonProperty = base.
                GetWebElementPropertiesById(MultipleResponsePageResource.
                MultipleResponse_Page_AddChoice_Button_Id_Locator);
            //Click On Add Choice Button
            base.ClickByJavaScriptExecutor(getAddChoiceButtonProperty);
            logger.LogMethodExit("MultipleResponsePage", "ClicKOnAddChoiceButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit Button and Fill Text.
        /// </summary>
        /// <param name="questionText">This is Question Text</param>
        private void SelectEditButtonAndFillText(string questionText)
        {
            //Select Edit Button and Fill Text
            logger.LogMethodEntry("MultipleResponsePage",
                "SelectEditButtonAndFillText",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Edit Button
            this.ClickEditButtonToAddText();
            //Select Editor Window
            this.SelectEditorWindow();
            //Fill Question Text
            this.FillQuestionText(questionText);
            //Click On 'OK' button
            this.ClickOnOkButton();
            logger.LogMethodExit("MultipleResponsePage",
                "SelectEditButtonAndFillText",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Edit Button To Add Text.
        /// </summary>
        private void ClickEditButtonToAddText()
        {
            //Click Edit Button To Add Text
            logger.LogMethodEntry("MultipleResponsePage", "ClickEditButtonToAddText",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_EditButton_Text_Id_Locator));
            //Get Edit button Property
            IWebElement getEditButtonPropertyToAddText = base.
                GetWebElementPropertiesById(MultipleResponsePageResource.
                MultipleResponse_Page_EditButton_Text_Id_Locator);
            //Click On Edit Button
            base.ClickByJavaScriptExecutor(getEditButtonPropertyToAddText);
            logger.LogMethodExit("MultipleResponsePage", "ClickEditButtonToAddText",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Editor Window.
        /// </summary>
        private void SelectEditorWindow()
        {
            //Select Editor Window
            logger.LogMethodEntry("MultipleResponsePage", "SelectEditorWindow",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(MultipleResponsePageResource.
                MultipleResponse_Page_Editor_Window_Name);
            //Select Editor Window
            base.SelectWindow(MultipleResponsePageResource.
                MultipleResponse_Page_Editor_Window_Name);
            logger.LogMethodExit("MultipleResponsePage", "SelectEditorWindow",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Question Text.
        /// </summary>
        /// <param name="questionText">This is Question Text</param>
        private void FillQuestionText(string questionText)
        {
            //Fill Question Text
            logger.LogMethodEntry("MultipleResponsePage", "FillQuestionText",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_ViewSource_Button_Id_Locator));
            //Get View Source Button Property
            IWebElement getViewSourceButtonProperty = base.GetWebElementPropertiesById
                (MultipleResponsePageResource.
                MultipleResponse_Page_ViewSource_Button_Id_Locator);
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_EnterQuestionTextHTML_Id_Locator));
            //Fill Question Text
            base.FillTextBoxById(MultipleResponsePageResource.
                MultipleResponse_Page_EnterQuestionTextHTML_Id_Locator, questionText);
            logger.LogMethodExit("MultipleResponsePage", "FillQuestionText",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'OK' Button.
        /// </summary>
        private void ClickOnOkButton()
        {
            //Click On 'OK' Button
            logger.LogMethodEntry("MultipleResponsePage", "ClickOnOkButton",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_Ok_Button_Id_Locator));
            //Get 'OK' Button Property
            IWebElement getOkButtonProperty = base.GetWebElementPropertiesById
                (MultipleResponsePageResource.
                MultipleResponse_Page_Ok_Button_Id_Locator);
            //Click On 'OK' Button
            base.ClickByJavaScriptExecutor(getOkButtonProperty);
            logger.LogMethodExit("MultipleResponsePage", "ClickOnOkButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit Button To Insert Image.
        /// </summary>
        private void SelectEditButtonToInsertImage()
        {
            //Select Edit Button To Insert Image
            logger.LogMethodEntry("MultipleResponsePage", "SelectEditButtonToInsertImage",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Drop Down To Add Image
            this.SelectDropDownToAddImage();
            //Select Edit Button To Add Image
            this.ClickEditButtonToAddImage();
            //Select the Image
            new ContentBrowserUXPage().SelectNarativeImage(
                MultipleResponsePageResource.MultipleResponse_Page_ImageFile_Name);
            logger.LogMethodExit("MultipleResponsePage", "SelectEditButtonToInsertImage",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Drop Down To Add Image.
        /// </summary>
        private void SelectDropDownToAddImage()
        {
            //Select Drop Down To Add Image
            logger.LogMethodEntry("MultipleResponsePage", "SelectDropDownToAddImage",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Create Multiple Response Window
            this.SelectCreateMultipleResponseWindow();
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_ImageDropDown_Id_Locator));
            //Select 'Image' in Drop Down
            base.SelectDropDownValueThroughTextById(MultipleResponsePageResource.
                MultipleResponse_Page_ImageDropDown_Id_Locator,
                MultipleResponsePageResource.MultipleResponse_Page_DropDown_Image_Name);
            logger.LogMethodExit("MultipleResponsePage", "SelectDropDownToAddImage",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Edit Button to Add Image.
        /// </summary>
        private void ClickEditButtonToAddImage()
        {
            //Click Edit Button to Add Image
            logger.LogMethodEntry("MultipleResponsePage", "ClickEditButtonToAddImage",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_EditButton_Image_Id_Locator));
            //Get Edit Button Property 
            IWebElement getEditButtonPropertyToAddImage = base.
                GetWebElementPropertiesById(MultipleResponsePageResource.
                MultipleResponse_Page_EditButton_Image_Id_Locator);
            //Click On Edit Button
            base.ClickByJavaScriptExecutor(getEditButtonPropertyToAddImage);
            logger.LogMethodExit("MultipleResponsePage", "ClickEditButtonToAddImage",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit Button And Insert Audio.
        /// </summary>
        private void SelectEditButtonAndInsertAudio()
        {
            //Select Edit Button And Insert Audio
            logger.LogMethodEntry("MultipleResponsePage", "SelectEditButtonAndInsertAudio",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Drop Down To Add Audio
            this.SelectDropDownToAddAudio();
            //Select Edit Button To Add Audio
            this.SelectEditButtonToAddAudio();
            new ContentBrowserUXPage().SelectNarativeImage(
                MultipleResponsePageResource.MultipleResponse_Page_AudioFile_Name);
            logger.LogMethodExit("MultipleResponsePage", "SelectEditButtonAndInsertAudio",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit Button To Add Audio.
        /// </summary>
        private void SelectEditButtonToAddAudio()
        {
            //Select Edit Button To Add Audio
            logger.LogMethodEntry("MultipleResponsePage", "SelectEditButtonToAddAudio",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_EditButton_Audio_Id_Locator));
            //Get Edit Button Property
            IWebElement getEditButtonpropertyToAddAudio = base.
                GetWebElementPropertiesById(MultipleResponsePageResource.
                MultipleResponse_Page_EditButton_Audio_Id_Locator);
            //Click On Edit Button
            base.ClickByJavaScriptExecutor(getEditButtonpropertyToAddAudio);
            logger.LogMethodExit("MultipleResponsePage", "SelectEditButtonToAddAudio",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Drop Down To Add Audio.
        /// </summary>
        private void SelectDropDownToAddAudio()
        {
            //Select Drop Down To Add Audio
            logger.LogMethodEntry("MultipleResponsePage", "SelectDropDownToAddAudio",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Create Multiple Response Window
            this.SelectCreateMultipleResponseWindow();
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_AudioDropDown_Id_Locator));
            //Select Drop Down for Audio
            base.SelectDropDownValueThroughTextById(MultipleResponsePageResource.
                MultipleResponse_Page_AudioDropDown_Id_Locator,
                MultipleResponsePageResource.MultipleResponse_Page_DropDown_Audio_Name);
            logger.LogMethodExit("MultipleResponsePage", "SelectDropDownToAddAudio",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit Button And Insert Video.
        /// </summary>
        private void SelectEditButtonAndInsertVideo()
        {
            //Select Edit Button And Insert Video
            logger.LogMethodEntry("MultipleResponsePage", "SelectEditButtonAndInsertVideo",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Drop Down To Add Video
            this.SelectDropDownToAddVideo();
            //Select Edit Button To Add Video
            this.SelectEditButtonToAddVideo();
            //Select the Video
            new ContentBrowserUXPage().SelectNarativeImage(
                MultipleResponsePageResource.MultipleResponse_Page_VideoFile_Name);
            logger.LogMethodExit("MultipleResponsePage", "SelectEditButtonAndInsertVideo",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit Button To Add Video.
        /// </summary>
        private void SelectEditButtonToAddVideo()
        {
            //Select Edit Button To Add Video
            logger.LogMethodEntry("MultipleResponsePage", "SelectEditButtonToAddVideo",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_EditButton_Video_Id_Locator));
            //Get Edit Button Property
            IWebElement getEditButtonpropertyToAddVideo = base.
                GetWebElementPropertiesById(MultipleResponsePageResource.
                MultipleResponse_Page_EditButton_Video_Id_Locator);
            //Click On Edit Button
            base.ClickByJavaScriptExecutor(getEditButtonpropertyToAddVideo);
            logger.LogMethodExit("MultipleResponsePage", "SelectEditButtonToAddVideo",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Drop Down To Add video.
        /// </summary>
        private void SelectDropDownToAddVideo()
        {
            //Select Drop Down To Add video
            logger.LogMethodEntry("MultipleResponsePage", "SelectDropDownToAddVideo",
             base.IsTakeScreenShotDuringEntryExit);
            //Select Create Multiple Response Window
            this.SelectCreateMultipleResponseWindow();
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_VideoDropDown_Id_Locator));
            //Select Drop Down for video
            base.SelectDropDownValueThroughTextById(MultipleResponsePageResource.
                MultipleResponse_Page_VideoDropDown_Id_Locator,
                MultipleResponsePageResource.MultipleResponse_Page_DropDown_Movie_Name);
            logger.LogMethodExit("MultipleResponsePage", "SelectDropDownToAddVideo",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Score Value.
        /// </summary>
        private void FillScoreValue()
        {
            //Fill Score Value
            logger.LogMethodEntry("MultipleResponsePage", "FillScoreValue",
             base.IsTakeScreenShotDuringEntryExit);
            //Select Create Multiple Response Window
            base.SelectWindow(MultipleResponsePageResource.
                MultipleResponse_Page_CreateMultipleResponse_Window_Name);
            for (int initialCount = Convert.ToInt32(MultipleResponsePageResource.
                MultipleResponse_Page_InitialCount_Value); initialCount <= Convert.ToInt32
                (MultipleResponsePageResource.MultipleResponse_Page_MaxCount_Value); initialCount++)
            {
                base.WaitForElement(By.Id(string.Format(MultipleResponsePageResource.
                    MultipleResponse_Page_FillScoreValue_Id_Locator, initialCount)));
                //Clear the Text Box
                base.ClearTextById(string.Format(MultipleResponsePageResource.
                    MultipleResponse_Page_FillScoreValue_Id_Locator, initialCount));
                //Fill The First Score Value
                base.FillTextBoxById(string.Format(MultipleResponsePageResource.
                    MultipleResponse_Page_FillScoreValue_Id_Locator, initialCount),
                    initialCount.ToString() + MultipleResponsePageResource.
                    MultipleResponse_Page_ZeroScoreValue);
            }
            logger.LogMethodExit("MultipleResponsePage", "FillScoreValue",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save and Close button.
        /// </summary>
        private void ClickONSaveAndCloseButtonOfMultipleResponseQuestion()
        {
            //Click on Save and Close Button
            logger.LogMethodEntry("MultipleResponsePage",
                "ClickONSaveAndCloseButtonOfMultipleResponseQuestion",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Create Entry List Window
            base.WaitForElement(By.Id(MultipleResponsePageResource.
                MultipleResponse_Page_Save_Button_Id_Locator));
            //Get Button property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById(
                MultipleResponsePageResource.
                MultipleResponse_Page_Save_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("MultipleResponsePage",
                "ClickONSaveAndCloseButtonOfMultipleResponseQuestion",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Storde Question Detials in Memory.
        /// </summary>
        /// <param name="questionGuid">This is Question Name Generated by Guid</param>
        private void StoreQuestionDetailsInMemory(string questionGuid)
        {
            //Store Question Details in Memory
            logger.LogMethodEntry("MultipleResponsePage", "StoreQuestionDetailsInMemory",
               base.IsTakeScreenShotDuringEntryExit);
            //Save Question Properties in Memory
            Question newQuestion = new Question
            {
                Name = questionGuid.ToString(),
                QuestionType = Question.QuestionTypeEnum.MultipleResponse,
                IsCreated = true,
            };
            newQuestion.StoreQuestionInMemory();
            logger.LogMethodExit("MultipleResponsePage", "StoreQuestionDetailsInMemory",
              base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
