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
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(Convert.ToInt32(RandomTopicListPageResource.
                     RandomTopicList_Page_Time_Value));
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
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question From Bank for Basic Random.
        /// </summary>
        public void SelectQuestionFromBankForBasicRandom()
        {
            //Select Question From Bank for Basic Random
            logger.LogMethodEntry("RandomTopicListPage", "SelectQuestionFromBankForBasicRandom",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath(RandomTopicListPageResource.
                        RandomTopicList_Page_SelectQuestionFromBank_Xpath_Locator));
                IWebElement getSelectQuestion=base.GetWebElementPropertiesByXPath
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
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question From Bank for Assignment.
        /// </summary>
        public void SelectQuestionFromBankForAssignment()
        {
            //Select Question From Bank for Assignment
            logger.LogMethodEntry("RandomTopicListPage", "SelectQuestionFromBankForAssignment",
                 base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait For Question To Display.
        /// </summary>
        public void WaitForQuestionToDisplay()
        {
            //Wait For Question To Display
            logger.LogMethodEntry("RandomTopicListPage", "WaitForQuestionToDisplay",
                 base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save and Return Button.
        /// </summary>
        public void ClickOnSaveAndReturnButton()
        {
            //Click On Save And Return Button
            logger.LogMethodEntry("RandomTopicListPage", "ClickOnSaveAndReturnButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
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
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On SaveAndReturn Button In MessageTab.
        /// </summary>
        public void ClickOnSaveAndReturnButtonInMessageTab()
        {
            //Click On SaveAndReturn Button In MessageTab
            logger.LogMethodEntry("RandomTopicListPage",
                "ClickOnSaveAndReturnButtonInMessageTab",
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
        }

         

        /// <summary>
        /// Select Add Questions link.
        /// </summary>
        public void SelectAddQuestionsLink()
        {
            //Select Add Questions link
            logger.LogMethodEntry("RandomTopicListPage", "SelectAddQuestionsLink",
                 base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Question Link.
        /// </summary>
        public void ClickonAddQuestionLink()
        {
            logger.LogMethodEntry("RandomTopicListPage", "ClickonAddQuestionLink",
                 base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create New Question Option.
        /// </summary>
        public void SelectCreateNewQuestionOption()
        {
            //Select Create New Question Option
            logger.LogMethodEntry("RandomTopicListPage", "SelectCreateNewQuestionOption",
                 base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Random Activity Window.
        /// </summary>
        private void SelectCreateRandomActivityWindow()
        {
            //Select Create Random Activity Window
            logger.LogMethodEntry("RandomTopicListPage",
                  "SelectCreateRandomActivityWindow",
                 base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.WaitUntilWindowLoads(RandomTopicListPageResource.
                RandomTopicList_Page_CreateRandomActivity_WindowName);
            base.SelectWindow(RandomTopicListPageResource.
                RandomTopicList_Page_CreateRandomActivity_WindowName);
            logger.LogMethodExit("RandomTopicListPage",
                   "SelectCreateRandomActivityWindow",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Create New Question Link.
        /// </summary>
        public void ClickOnCreateNewQuestionLink()
        {
            //Click On Create New Question Link
            logger.LogMethodEntry("RandomTopicListPage",
                  "ClickOnCreateNewQuestionLink",
                 base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On SaveAndReturn Button In Preference.
        /// </summary>
        public void ClickOnSaveAndReturnButtonInPreference()
        {
            //Click On SaveAndReturn Button In Preference
            logger.LogMethodEntry("RandomTopicListPage",
                  "ClickOnSaveAndReturnButtonInPreference",
                 base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Add Questions Link For Post Test.
        /// </summary>
        public void SelectAddQuestionsLinkForPostTest()
        {
            //Select Add Questions Link For Post Test
            logger.LogMethodEntry("RandomTopicListPage",
                  "SelectAddQuestionsLinkForPostTest",
                 base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Post Test Window And Frame.
        /// </summary>
        private void SelectCreatePostTestWindowAndFrame()
        {
            //Select Create Post Test Window And Frame
            logger.LogMethodEntry("RandomTopicListPage",
                  "SelectCreatePostTestWindowAndFrame",
                 base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
