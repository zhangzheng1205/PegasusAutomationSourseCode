using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.QuestionLibrary;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Random Topic List Page actions.
    /// </summary>
    public class RandomTopicListPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RandomTopicListPage));


        /// <summary>
        /// Click On Add Question Link.
        /// </summary>
        public void ClickOnAddQuestionLink()
        {
            //Click On Add Question Link
            logger.LogMethodEntry("RandomTopicListPage", "ClickOnAddQuestionLink",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {


                Thread.Sleep(Convert.ToInt32(RandomTopicListPageResource.
                     RandomTopicList_Page_Time_Value));
                //Select window
                //base.SelectWindow(RandomTopicListPageResource.
                //    RandomTopicList_Page_CreateActivity_Window_Title_Locator);
                //Wait for Add Question Button
                base.WaitForElement(By.Id(RandomTopicListPageResource.
                    RandomTopicList_Page_AddQuestion_Button_Id_Locator));
                //Get Add Question Button Property
                IWebElement getAddQuestionsButtonProperty = base.
                    GetWebElementPropertiesById(RandomTopicListPageResource.
                    RandomTopicList_Page_AddQuestion_Button_Id_Locator);
                //Click On Add Question
                base.ClickByJavaScriptExecutor(getAddQuestionsButtonProperty);
                Thread.Sleep(Convert.ToInt32(RandomTopicListPageResource.
                    RandomTopicList_Page_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "ClickOnAddQuestionLink",
              base.IsTakeScreenShotDuringEntryExit);
        }




        /// <summary>
        /// Select Question From Bank for Basic Random.
        /// </summary>
        public void SelectQuestionFromBankForBasicRandom()
        {
            //Select Question From Bank for Basic Random
            logger.LogMethodEntry("RandomTopicListPage", "SelectQuestionFromBankForBasicRandom",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath(RandomTopicListPageResource.
                        RandomTopicList_Page_SelectQuestionFromBank_Xpath_Locator));
                IWebElement getSelectQuestion = base.GetWebElementPropertiesByXPath
                    (RandomTopicListPageResource.
                        RandomTopicList_Page_SelectQuestionFromBank_Xpath_Locator);
                //Click On Select Question From Bank
                base.ClickByJavaScriptExecutor(getSelectQuestion);
                //Wait for Select Questions Window
                base.WaitUntilWindowLoads(RandomTopicListPageResource.
                    RandomTopicList_Page_SelectQuestions_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "SelectQuestionFromBankForBasicRandom",
              base.IsTakeScreenShotDuringEntryExit);
        }





        /// <summary>
        /// Select Question From Bank for Assignment.
        /// </summary>
        public void SelectQuestionFromBankForAssignment()
        {
            //Select Question From Bank for Assignment
            logger.LogMethodEntry("RandomTopicListPage", "SelectQuestionFromBankForAssignment",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Select Question From Bank Link 
                base.WaitForElement(By.PartialLinkText(RandomTopicListPageResource.
                    RandomTopicList_Page_SelectQuestionFromBank_Link_Locator));
                //Click On Select Question From Bank Option
                base.ClickButtonByPartialLinkText(RandomTopicListPageResource.
                    RandomTopicList_Page_SelectQuestionFromBank_Link_Locator);
                //Wait for Select Questions Window
                base.WaitUntilWindowLoads(RandomTopicListPageResource.
                    RandomTopicList_Page_SelectQuestions_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "SelectQuestionFromBankForAssignment",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait For Question To Display.
        /// </summary>
        public void WaitForQuestionToDisplay()
        {
            //Wait For Question To Display
            logger.LogMethodEntry("RandomTopicListPage", "WaitForQuestionToDisplay",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(RandomTopicListPageResource.
                        RandomTopicList_Page_Frame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(RandomTopicListPageResource.
                    RandomTopicList_Page_Frame_Id_Locator);
                //Wait for Activity 
                base.WaitForElement(By.Id(RandomTopicListPageResource.
                    RandomTopicList_Page_Activity_Table_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "WaitForQuestionToDisplay",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save and Return Button.
        /// </summary>
        public void ClickOnSaveAndReturnButton()
        {
            //Click On Save And Return Button
            logger.LogMethodEntry("RandomTopicListPage", "ClickOnSaveAndReturnButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.SwitchToDefaultWindow();
                base.WaitForElement(By.Id(RandomTopicListPageResource.
                        RandomTopicList_Page_SaveAndReturn_Id_Locator));
                //Get Save And Return Button Property
                IWebElement getSaveAndReturnButtonProperty = base.
                    GetWebElementPropertiesById(RandomTopicListPageResource.
                    RandomTopicList_Page_SaveAndReturn_Id_Locator);
                //Click On Save and Return Button
                base.ClickByJavaScriptExecutor(getSaveAndReturnButtonProperty);
                Thread.Sleep(Convert.ToInt32(RandomTopicListPageResource.
                    RandomTopicList_Page_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "ClickOnSaveAndReturnButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On SaveAndReturn Button In MessageTab.
        /// </summary>
        public void ClickOnSaveAndReturnButtonInMessageTab()
        {
            //Click On SaveAndReturn Button In MessageTab
            logger.LogMethodEntry("RandomTopicListPage",
                "ClickOnSaveAndReturnButtonInMessageTab",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(RandomTopicListPageResource.
                        RandomTopicList_Page_MessageTab_SaveAndReturn_Id_Locator));
                //Get Save And Return Button Property
                IWebElement getSaveAndReturnButtonProperty = base.
                    GetWebElementPropertiesById(RandomTopicListPageResource.
                    RandomTopicList_Page_MessageTab_SaveAndReturn_Id_Locator);
                //Click On Save and Return Button
                base.ClickByJavaScriptExecutor(getSaveAndReturnButtonProperty);
                Thread.Sleep(Convert.ToInt32(RandomTopicListPageResource.
                    RandomTopicList_Page_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage",
                "ClickOnSaveAndReturnButtonInMessageTab",
               base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Select Add Questions link.
        /// </summary>
        public void SelectAddQuestionsLink()
        {
            //Select Add Questions link
            logger.LogMethodEntry("RandomTopicListPage", "SelectAddQuestionsLink",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on Add Question Link
                this.ClickonAddQuestionLink();
                //Wait for the element
                base.WaitForElement(By.Id(RandomTopicListPageResource.
                    RandomTopicList_Page_AddQuestion_Div_Id_Locator));
                IWebElement getSkillFrameLink = base.GetWebElementPropertiesByXPath
                    (RandomTopicListPageResource.
                    RandomTopicList_Page_SelectskillFrameBank_Xpath_Locator);
                //Click the skill framework
                base.ClickByJavaScriptExecutor(getSkillFrameLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "SelectAddQuestionsLink",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Question Link.
        /// </summary>
        public void ClickonAddQuestionLink()
        {
            logger.LogMethodEntry("RandomTopicListPage", "ClickonAddQuestionLink",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(AddAssessmentPageResources.
                    AddAsessment_Page_PretestActiviity_Window_Name);
                base.SelectWindow(AddAssessmentPageResources.
                    AddAsessment_Page_PretestActiviity_Window_Name);
                //Wait for Add Question Button
                base.WaitForElement(By.Id(RandomTopicListPageResource.
                    RandomTopicList_Page_AddQuestion_Link_Id_Locator));
                //Get Add Question Button Property
                IWebElement getAddQuestionsButtonProperty = base.
                    GetWebElementPropertiesById(RandomTopicListPageResource.
                    RandomTopicList_Page_AddQuestion_Link_Id_Locator);
                //Click On Add Question
                base.ClickByJavaScriptExecutor(getAddQuestionsButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "ClickonAddQuestionLink",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create New Question Option.
        /// </summary>
        public void SelectCreateNewQuestionOption()
        {
            //Select Create New Question Option
            logger.LogMethodEntry("RandomTopicListPage", "SelectCreateNewQuestionOption",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectCreateRandomActivityWindow();
                //Wait for Create New Question Option 
                base.WaitForElement(By.XPath(RandomTopicListPageResource.
                    RandomTopicList_Page_CreateNewQuestion_Option_Xpath_Locator));
                //Click On Create New Question Option
                base.ClickButtonByXPath(RandomTopicListPageResource.
                    RandomTopicList_Page_CreateNewQuestion_Option_Xpath_Locator);
                //Wait for Create New Question Window
                base.WaitUntilWindowLoads(RandomTopicListPageResource.
                    RandomTopicList_Page_CreateNewQuestion_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "SelectCreateNewQuestionOption",
              base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Select The Create New Question link For Asset Creation.
        /// </summary>
        /// <param name="addQuestionLink">This is Add Question Link.</param>
        public void SelectTheCreateNewQuestionForAssetCreation(string addQuestionLink)
        {
            //Select Create New Question Option
            logger.LogMethodEntry("RandomTopicListPage",
                  "SelectTheCreateNewQuestionForAssetCreation",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create Random Activity Window
                this.SelectCreateRandomActivityWindow();
                //Wait for Create New Question Option 
                base.WaitForElement(By.XPath(addQuestionLink));
                IWebElement getCreateQuestion = base.GetWebElementPropertiesByXPath(
                        addQuestionLink);
                //Click On Create New Question Option
                base.ClickByJavaScriptExecutor(getCreateQuestion);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage",
                   "SelectTheCreateNewQuestionForAssetCreation",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Random Activity Window.
        /// </summary>
        private void SelectCreateRandomActivityWindow()
        {
            //Select Create Random Activity Window
            logger.LogMethodEntry("RandomTopicListPage",
                  "SelectCreateRandomActivityWindow",
                 base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            base.WaitUntilWindowLoads(RandomTopicListPageResource.
                RandomTopicList_Page_CreateRandomActivity_WindowName);
            base.SelectWindow(RandomTopicListPageResource.
                RandomTopicList_Page_CreateRandomActivity_WindowName);
            logger.LogMethodExit("RandomTopicListPage",
                   "SelectCreateRandomActivityWindow",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Create New Question Link.
        /// </summary>
        public void ClickOnCreateNewQuestionLink()
        {
            //Click On Create New Question Link
            logger.LogMethodEntry("RandomTopicListPage",
                  "ClickOnCreateNewQuestionLink",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait for the element
                base.WaitForElement(By.Id(RandomTopicListPageResource.
                    RandomTopicList_Page_CreateNewQuestion_Link_Id_Locator));
                IWebElement getCreateNewQuestion = base.GetWebElementPropertiesById
                    (RandomTopicListPageResource.
                    RandomTopicList_Page_CreateNewQuestion_Link_Id_Locator);
                //Click On Create New Question Link
                base.ClickByJavaScriptExecutor(getCreateNewQuestion);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage",
                   "ClickOnCreateNewQuestionLink",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On SaveAndReturn Button In Preference.
        /// </summary>
        public void ClickOnSaveAndReturnButtonInPreference()
        {
            //Click On SaveAndReturn Button In Preference
            logger.LogMethodEntry("RandomTopicListPage",
                  "ClickOnSaveAndReturnButtonInPreference",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait for the element
                base.WaitForElement(By.Id(RandomTopicListPageResource.
                    RandomTopicList_Page_ActivityPreference_Save_Button_Id_Locator));
                IWebElement getSaveReturnButton = base.GetWebElementPropertiesById
                    (RandomTopicListPageResource.
                    RandomTopicList_Page_ActivityPreference_Save_Button_Id_Locator);
                //Click On Create New Question Link
                base.ClickByJavaScriptExecutor(getSaveReturnButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage",
                   "ClickOnSaveAndReturnButtonInPreference",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Add Questions Link For Post Test.
        /// </summary>
        public void SelectAddQuestionsLinkForPostTest()
        {
            //Select Add Questions Link For Post Test
            logger.LogMethodEntry("RandomTopicListPage",
                  "SelectAddQuestionsLinkForPostTest",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create Post Test Window And Frame
                this.SelectCreatePostTestWindowAndFrame();
                base.WaitForElement(By.PartialLinkText(RandomTopicListPageResource.
                    RandomTopicList_Page_AddQuestions_PartialText_Locator));
                //Click on Add Questions Link
                IWebElement getAddQuestionsProperty =
                    base.GetWebElementPropertiesByPartialLinkText(RandomTopicListPageResource.
                    RandomTopicList_Page_AddQuestions_PartialText_Locator);
                base.ClickByJavaScriptExecutor(getAddQuestionsProperty);
                base.WaitForElement(By.PartialLinkText(RandomTopicListPageResource.
                    RandomTopicList_Page_BrowseSkillFramework_TPartialText_Locator));
                //Click on Browser Skill Framework Link
                IWebElement getBrowseSkillFrameworkProperty =
                    base.GetWebElementPropertiesByPartialLinkText(RandomTopicListPageResource.
                    RandomTopicList_Page_BrowseSkillFramework_TPartialText_Locator);
                base.ClickByJavaScriptExecutor(getBrowseSkillFrameworkProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage",
                  "SelectAddQuestionsLinkForPostTest",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Post Test Window And Frame.
        /// </summary>
        private void SelectCreatePostTestWindowAndFrame()
        {
            //Select Create Post Test Window And Frame
            logger.LogMethodEntry("RandomTopicListPage",
                  "SelectCreatePostTestWindowAndFrame",
                 base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(RandomTopicListPageResource.
                RandomTopicList_Page_CreatePostTest_WindowName);
            //Select Window
            base.SelectWindow(RandomTopicListPageResource.
                RandomTopicList_Page_CreatePostTest_WindowName);
            base.WaitForElement(By.Id(RandomTopicListPageResource.
                RandomTopicList_Page_Frame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrameById(RandomTopicListPageResource.
                RandomTopicList_Page_Frame_Id_Locator);
            logger.LogMethodExit("RandomTopicListPage",
                  "SelectCreatePostTestWindowAndFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Add Links link to add HelpLinks to activity.
        /// </summary>
        public void ClickOnAddLinksLink()
        {
            //Click On Add Question Link
            logger.LogMethodEntry("RandomTopicListPage", "ClickOnAddLinksLink",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Add Question Button
                base.WaitForElement(By.Id(RandomTopicListPageResource.
                    RandomTopicList_Page_AddLinks_Button_Id_Locator));
                //Get Add Question Button Property
                IWebElement getAddQuestionsButtonProperty = base.
                    GetWebElementPropertiesById(RandomTopicListPageResource.
                    RandomTopicList_Page_AddLinks_Button_Id_Locator);
                //Click On Add Question
                base.ClickByJavaScriptExecutor(getAddQuestionsButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "ClickOnAddLinksLink",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create New Question Option.
        /// </summary>
        public void SelectOptionForQuestionCreation(string expectedQuestionOption)
        {
            //Select Create New Question Option
            logger.LogMethodEntry("RandomTopicListPage", "SelectOptionForQuestionCreation",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click On Add Question Link
                this.ClickOnAddQuestionLink();
                //Select Window
                this.SelectCreateRandomActivityWindow();
                //Get total count of Add Questions Option
                int questionOptionCount = base.GetElementCountByXPath
                    ("//div[@id='AddQuestionsContextMenu']/table/thead/tr");
                //Iterate the Add Question Options and select the expected option
                for (int i = 1; i <= questionOptionCount; i++)
                {
                    base.WaitForElement(By.XPath(string.Format
                        ("//div[@id='AddQuestionsContextMenu']/table/thead/tr[{0}]/td", i)));
                    IWebElement questionOption = base.GetWebElementPropertiesByXPath(string.Format
                        ("//div[@id='AddQuestionsContextMenu']/table/thead/tr[{0}]/td", i));
                    Thread.Sleep(1000);
                    string actualquestionOption = base.GetElementInnerTextByXPath(string.Format
                        ("//div[@id='AddQuestionsContextMenu']/table/thead/tr[{0}]/td", i)).Trim();
                    Thread.Sleep(1000);
                    //Compare expected option and click on match
                    if (expectedQuestionOption == actualquestionOption)
                    {
                        base.ClickByJavaScriptExecutor(questionOption);
                        break;
                    }
                 }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "SelectOptionForQuestionCreation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Sections Option.
        /// </summary>
        public void ClickOnAddSections()
        {
            //Click On Add Question Link
            logger.LogMethodEntry("RandomTopicListPage", "ClickOnAddSections",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(Convert.ToInt32(RandomTopicListPageResource.
                     RandomTopicList_Page_Time_Value));               
                //Wait for Add Question Button
                base.WaitForElement(By.Id("cmdAddsection"));
                //Get Add Question Button Property
                IWebElement getAddQuestionsButtonProperty = base.
                    GetWebElementPropertiesById("cmdAddsection");
                //Click On Add Question
                base.ClickByJavaScriptExecutor(getAddQuestionsButtonProperty);
                Thread.Sleep(Convert.ToInt32(RandomTopicListPageResource.
                    RandomTopicList_Page_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "ClickOnAddSections",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Add Sections Option.
        /// </summary>
        /// <param name="sectionOptionValue">Add Section Option</param>
        public void SelectAddSectionsOptions(string sectionOptionValue)
        {
            // Select Add Sections Option
            logger.LogMethodEntry("RandomTopicListPage", "SelectAddSectionsOptions",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click On Add Section
                this.ClickOnAddSections();
                //Select Window
                this.SelectCreateRandomActivityWindow();
                //Select expected option under Add Section
                int sectionOptionCount = base.GetElementCountByXPath
                    ("//div[@id='AddSectionsContextmenu']/table/thead/tr");
                for (int i = 1; i <= sectionOptionCount; i++)
                {
                    base.WaitForElement(By.XPath(string.Format
                        ("//div[@id='AddSectionsContextmenu']/table/thead/tr[{0}]/td", i)));
                    IWebElement sectionOption = base.GetWebElementPropertiesByXPath(string.Format
                        ("//div[@id='AddSectionsContextmenu']/table/thead/tr[{0}]/td", i));
                    Thread.Sleep(1000);
                    string actualsectionOption = base.GetElementInnerTextByXPath(string.Format
                        ("//div[@id='AddSectionsContextmenu']/table/thead/tr[{0}]/td", i)).Trim();
                    Thread.Sleep(1000);
                    //Select the option on match
                    if (sectionOptionValue == actualsectionOption)
                    {
                        base.ClickByJavaScriptExecutor(sectionOption);
                        break;
                    }

                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "SelectAddSectionsOptions",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create a new Section at activity creation .
        /// </summary>
        public void CreateSection(string sectionName)
        {
            logger.LogMethodEntry("RandomTopicListPage", "CreateSection",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Create a new Section at activity creation and save
                base.WaitForElement(By.Id("txtSectionName"));
                base.FillTextBoxById("txtSectionName", sectionName);
                base.WaitForElement(By.Id("cmdSave"));
                base.GetWebElementPropertiesById("cmdSave").Click();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "CreateSection",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select expected option for add questionunder a section.
        /// </summary>
        /// <param name="optionValue">Expected option value.</param>
        public void SectionAddQuestionsOptionsUnderSection(string optionValue,string sectionNumber)
        {
            // Select expected option for add questionunder a section
            logger.LogMethodEntry("RandomTopicListPage", "SectionAddQuestionsOptionsUnderSection",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the current window
                this.SelectCreateRandomActivityWindow();
                //Switch to frame
                base.SwitchToIFrameById("frmTopic");
                string sectionIdentifier = "(0," + sectionNumber + ")";
                // Select expected option for add questionunder a section
                base.WaitForElement(By.CssSelector(string.Format("a[id='cmdadd'][onclick*='{0}']", sectionIdentifier)));
                base.FocusOnElementByCssSelector(string.Format("a[id='cmdadd'][onclick*='{0}']", sectionIdentifier));
                base.GetWebElementPropertiesByCssSelector(string.Format("a[id='cmdadd'][onclick*='{0}']", sectionIdentifier)).Click();
                base.WaitForElement(By.PartialLinkText(optionValue));
                base.GetWebElementPropertiesByPartialLinkText(optionValue).Click();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "SectionAddQuestionsOptionsUnderSection",
           base.IsTakeScreenShotDuringEntryExit);
        }

        public void CreateSectionsWithMultipleQuestions(int numberOfQuestions,
            string questionType, string sectionNumber)
        {
            for(int i=1;i<=numberOfQuestions;i++)
            {

                this.SectionAddQuestionsOptionsUnderSection("Create New Question", sectionNumber);
                
                new SelectQuestionTypePage().ClickTheExpectedQuestionType(questionType);
                FillInTheBlanksPage fillInTheBlanks = new FillInTheBlanksPage();
                fillInTheBlanks.CreateFillInBlankAtActivityCreation();
            }
        }

        /// <summary>
        /// Click on Save and Return Button.
        /// </summary>
        public void ClickOnSaveAndContinueButton()
        {
            //Click On Save And Return Button
            logger.LogMethodEntry("RandomTopicListPage", "ClickOnSaveAndContinueButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.SwitchToDefaultWindow();
                bool pres = base.IsElementPresent(By.Id("cmdTabTopicsNext"), 10);
                base.WaitForElement(By.Id("cmdTabTopicsNext"));
                //Get Save And Return Button Property
                IWebElement getSaveAndReturnButtonProperty = base.
                    GetWebElementPropertiesById("cmdTabTopicsNext");
                Thread.Sleep(Convert.ToInt32(RandomTopicListPageResource.
                   RandomTopicList_Page_Time_Value));
                //Click On Save and Return Button
                base.ClickByJavaScriptExecutor(getSaveAndReturnButtonProperty);
               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "ClickOnSaveAndContinueButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        public void NavigatetoTabInCreateRandomActvityWindow(string tabName)
        {
            logger.LogMethodEntry("RandomTopicListPage", "NavigatetoTabInCreateRandomActvityWindow",
                          base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string idValue = string.Empty;
                base.SwitchToDefaultWindow();
                switch (tabName)
                {
                    case "Preferences": idValue = "cmdTabPreference";
                        break;
                    case "Teaching Support": idValue = "cmdTabHelpPanel";
                        break;
                    case "Grades": idValue = "cmdTabGrades";
                        break;
                    case "Messages": idValue = "cmdTabMessages";
                        break;
                    case "HelpLinks": idValue = "cmdTabHelpLinks";
                        break;
                    case "Questions": idValue = "cmdTabTopics";
                        break;
                    case "Activity Details": idValue = "cmdTabAssessment";
                        break;
                }

                base.WaitForElement(By.Id(idValue));
                //Get Save And Return Button Property
                IWebElement getSaveAndReturnButtonProperty = base.
                    GetWebElementPropertiesById(idValue);
                Thread.Sleep(Convert.ToInt32(RandomTopicListPageResource.
                   RandomTopicList_Page_Time_Value));
                //Click On Save and Return Button
                base.ClickByJavaScriptExecutor(getSaveAndReturnButtonProperty);
               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "NavigatetoTabInCreateRandomActvityWindow",
           base.IsTakeScreenShotDuringEntryExit);
        }

        public void ButtonActionsForTabsAtEditRandomActivity(string buttonType,string tabName)
        {
            logger.LogMethodEntry("RandomTopicListPage", "ButtonActionsForTabsAtEditRandomActivity",
                          base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string idValue = string.Empty;
                base.SwitchToDefaultWindow();
            switch(buttonType)
            {
                case "Save and Return":
                    switch(tabName)
                    {
                        #region Tabs
                        case "Preferences": idValue = "cmdTabPreferenceFinish";
                            break;
                        case "Teaching Support": idValue = "cmdTabHelpPanelFinish";
                            break;
                        case "Grades": idValue = "cmdTabGradesFinish";
                            break;
                        case "Messages": idValue = "cmdTabMessagesFinish";
                            break;
                        case "HelpLinks": idValue = "cmdTabHelpLinksFinish";
                            break;
                        case "Questions": idValue = "cmdTabTopicsFinish";
                            break;
                        case "Activity Details": idValue = "cmdTabAssessmentFinish";
                            break; 
                        #endregion
                    }
                    break;
                 case "Save and Continue":
                     switch(tabName)
                    {
                        #region Tabs
                        case "Preferences": idValue = "cmdTabPreferenceNext";
                            break;
                        case "Teaching Support": idValue = "cmdTabHelpPanelNext";
                            break;
                        case "Grades": idValue = "cmdTabGradesNext";
                            break;
                        case "Messages": idValue = "cmdTabMessagesNext";
                            break;
                        case "HelpLinks": idValue = "cmdTabHelpLinksNext";
                            break;
                        case "Questions": idValue = "cmdTabTopicsNext";
                            break;
                        case "Activity Details": idValue = "tdcmdTabAssessmentNext";
                            break; 
                        #endregion
                    }
                    break;
                 case "Cancel":
                    switch (tabName)
                    {
                        #region Tab
                        case "Preferences": idValue = "cmdTabPreferenceCancel";
                            break;
                        case "Teaching Support": idValue = "cmdTabHelpPanelCancel";
                            break;
                        case "Grades": idValue = "cmdTabGradesCancel";
                            break;
                        case "Messages": idValue = "cmdTabMessagesCancel";
                            break;
                        case "HelpLinks": idValue = "cmdTabHelpLinksCancel";
                            break;
                        case "Questions": idValue = "cmdTabTopicsCancel";
                            break;
                        case "Activity Details": idValue = "cmdTabAssessmentCancel";
                            break; 
                        #endregion
                    }
                    break;
                case "Navigate":
                    switch(tabName)
                    {
                        #region Tab
                        case "Preferences": idValue = "cmdTabPreference";
                            break;
                        case "Teaching Support": idValue = "cmdTabHelpPanel";
                            break;
                        case "Grades": idValue = "cmdTabGrades";
                            break;
                        case "Messages": idValue = "cmdTabMessages";
                            break;
                        case "HelpLinks": idValue = "cmdTabHelpLinks";
                            break;
                        case "Questions": idValue = "cmdTabTopics";
                            break;
                        case "Activity Details": idValue = "cmdTabAssessment";
                            break; 
                        #endregion
                    }
                    break;
            }
             base.WaitForElement(By.Id(idValue));
                //Get  Button Property
                IWebElement getSaveAndReturnButtonProperty = base.
                    GetWebElementPropertiesById(idValue);
                Thread.Sleep(Convert.ToInt32(RandomTopicListPageResource.
                   RandomTopicList_Page_Time_Value));
                //Click On  Button
                base.ClickByJavaScriptExecutor(getSaveAndReturnButtonProperty);
               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "ButtonActionsForTabsAtEditRandomActivity",
           base.IsTakeScreenShotDuringEntryExit);
        }

        
    }
}
