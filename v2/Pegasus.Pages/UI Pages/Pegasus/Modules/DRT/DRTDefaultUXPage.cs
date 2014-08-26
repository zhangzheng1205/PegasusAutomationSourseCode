using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.DRT;
using System.Threading;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles DRT Default Page Actions
    /// </summary>
    public class DRTDefaultUXPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(DRTDefaultUXPage));


        ///<summary>
        /// To create a SkillStudyPlan
        ///</summary>
        public void AddPreTestToSkillStudyPlan()
        {
            //Create Study Plan
            logger.LogMethodEntry("DRTDefaultUXPage",
                "AddPreTestToSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
            //Create studyplan
            try
            {
                //Wait for TextBox of Study Plan name
                base.WaitForElement(By.Id(DRTDefaultUXPageResource.
                        DRTDefaultUX_Page_StudyplanName_Input_Id_Locator),
                        Convert.ToInt32(DRTDefaultUXPageResource.
                        DRTDefaultUX_page_WaitForElement_Time_Value));
                //Storing the Activity
                Guid studyPlanName = Guid.NewGuid();
                //Fill Text Box With Study Plan Name
                base.FillTextBoxById(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_StudyplanName_Input_Id_Locator,
                    studyPlanName.ToString());               
                //Save Skill Study Plan in Memory
                this.StoreActivityDetailsInMemory(studyPlanName.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DRTDefaultUXPage",
                "AddPreTestToSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// To Store Activity Name in memory
        /// </summary>
        /// <param name="activityName">Activity Name</param>
        private void StoreActivityDetailsInMemory(string activityName)
        {
            //Store Activity Name in Memory
            logger.LogMethodEntry("DRTDefaultUXPage",
                "StoreActivityDetailsInMemory", base.IsTakeScreenShotDuringEntryExit);
            Activity studyPlan = new Activity
            {
                ActivityId = CommonResource.CommonResource.DigitalPath_Activity_SkillStudyPlan_UC1,
                Name = activityName,
                ActivityType = Activity.ActivityTypeEnum.SkillStudyPlan,
                IsCreated = true,
            };
            //Save Activity Name to Memory
            studyPlan.StoreActivityInMemory();
            logger.LogMethodExit("DRTDefaultUXPage",
                "StoreActivityDetailsInMemory", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On SaveClose Button Of SkillStudyPlan.
        /// </summary>
        public void ClickOnSaveCloseButtonOfSkillStudyPlan()
        {
            // Click On SaveClose Button Of SkillStudyPlan
            logger.LogMethodEntry("DRTDefaultUXPage",
                "ClickOnSaveCloseButtonOfSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create Skill Studyplan Window
                this.SelectCreateSkillStudyplanWindow();
                //Wait for Success Message
                base.WaitForElement(By.ClassName(DRTDefaultUXPageResource.
                 DRTDefaultUX_Page_PreTestCreated_SuccessMessage));
                //Click on Save and Close Button
                this.ClickonSaveandCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DRTDefaultUXPage",
                "ClickOnSaveCloseButtonOfSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save and Close Button.
        /// </summary>
        private void ClickonSaveandCloseButton()
        {
            //Click on Save and Close Button
            logger.LogMethodEntry("DRTDefaultUXPage",
                "ClickOnSaveCloseButtonOfSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(DRTDefaultUXPageResource.
                DRTDefaultUX_page_content_SaveButton_Id_Locator));
            //Get Button Property
            IWebElement getSaveandCloseButtonProperty = base.GetWebElementPropertiesById
                (DRTDefaultUXPageResource.DRTDefaultUX_page_content_SaveButton_Id_Locator);
            //Click on Save and Return Button
            base.ClickByJavaScriptExecutor(getSaveandCloseButtonProperty);
            Thread.Sleep(Convert.ToInt32(DRTDefaultUXPageResource.
                DRTDefaultUX_page_WaitElement_Thread_Time));
            logger.LogMethodExit("DRTDefaultUXPage",
                "ClickOnSaveCloseButtonOfSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Creation of Pre Test for Study Plan
        /// </summary>
        public void CreatePreTest()
        {
            //Create Pre Test
            logger.LogMethodEntry("DRTDefaultUXPage",
                "CreatePreTest", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Add Existing Activity Link
                base.WaitForElement(By.XPath(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_AddExistingActivity_Link_Xpath_Locator));
                IWebElement getActivity=base.GetWebElementPropertiesByXPath
                    (DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_AddExistingActivity_Link_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getActivity);
                //Select the Activity for Pre Test
                new ContentBrowserUXPage().SelectActivityForPreTest(
                    DRTDefaultUXPageResource.DRTDefaultUX_page_Search_PretestActivity);
            }
            catch (Exception e)
            {
                 ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DRTDefaultUXPage",
                "CreatePreTest", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Begin button to initiate pretest.
        /// </summary>
        public void ClickBeginButton()
        {
            //Select Begin Button
            logger.LogMethodEntry("DRTDefaultUXPage",
                "ClickBeginButton", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Study Plan Window
                this.SelectStudyPlanWindow();
                // Click on begin button
                base.WaitForElement(By.Id(DRTDefaultUXPageResource
                 .DRTDefaultUX_Page_BeginButton_Id_Locator));
                IWebElement getPretestBeginButon = base.GetWebElementPropertiesById
                    (DRTDefaultUXPageResource
                 .DRTDefaultUX_Page_BeginButton_Id_Locator);
                base.ClickByJavaScriptExecutor(getPretestBeginButon);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DRTDefaultUXPage",
                "ClickBeginButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Study Plan Window.
        /// </summary>
        private void SelectStudyPlanWindow()
        {
            //Select Study Plan Window
            logger.LogMethodEntry("DRTDefaultUXPage",
                "SelectStudyPlanWindow", base.IsTakeScreenShotDuringEntryExit);
            //Select study plan window
            base.WaitUntilWindowLoads(DRTDefaultUXPageResource
                .DRTDefaultUX_Page_Studyplan_WindowName);
            base.SelectWindow(DRTDefaultUXPageResource
                .DRTDefaultUX_Page_Studyplan_WindowName);
            logger.LogMethodExit("DRTDefaultUXPage",
                "SelectStudyPlanWindow", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Begin button to initiate posttest.
        /// </summary>
        public void ClickPostTestBeginButton()
        {
            //Select Begin Button
            logger.LogMethodEntry("DRTDefaultUXPage",
                "ClickPostTestBeginButton", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Study Plan Window
                this.SelectStudyPlanWindow();
                // Click on begin button
                base.WaitForElement(By.Id(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_PostTest_BeginButton_Id_Locator));
                IWebElement getPosttestBeginButton = base.GetWebElementPropertiesById
                    (DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_PostTest_BeginButton_Id_Locator);
                //Click the begin button
                base.ClickByJavaScriptExecutor(getPosttestBeginButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DRTDefaultUXPage",
                "ClickPostTestBeginButton", base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select return to course button
        /// </summary>
        public void ClickReturnToCourseButton()
        {
            //Create Pre Test
            logger.LogMethodEntry("DRTDefaultUXPage",
                "ClickReturnToCourseButton", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select study plan window
                base.WaitUntilWindowLoads(DRTDefaultUXPageResource
                    .DRTDefaultUX_Page_Studyplan_WindowName);
                base.SelectWindow(DRTDefaultUXPageResource
                    .DRTDefaultUX_Page_Studyplan_WindowName);
                // Click on return to course button
                base.WaitForElement(By.XPath(DRTDefaultUXPageResource
                 .DRTDefaultUX_Page_ReturnToCourse_Xpath_Locator));
                IWebElement returnToCourse = base.GetWebElementPropertiesByXPath
                    (DRTDefaultUXPageResource.DRTDefaultUX_Page_ReturnToCourse_Xpath_Locator);
                base.ClickByJavaScriptExecutor(returnToCourse);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DRTDefaultUXPage",
                "ClickReturnToCourseButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Create PreTest link.
        /// </summary>
        public void ClickTheCreatePreTestLink()
        {
            //Click the Pre Test link
            logger.LogMethodEntry("DRTDefaultUXPage",
                "ClickTheCreatePreTestLink", base.IsTakeScreenShotDuringEntryExit);           
           try 
	         {	        
		        //Wait for pretest link
                base.WaitForElement(By.XPath(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_Pretest_Img_Xpath_Locator));
                IWebElement getPreTest = base.GetWebElementPropertiesByXPath
                (DRTDefaultUXPageResource.
                DRTDefaultUX_Page_Pretest_Img_Xpath_Locator);
                //Click the pretest link
                base.ClickByJavaScriptExecutor(getPreTest);
	        }
	        catch (Exception e)
	        {
		        ExceptionHandler.HandleException(e);
	        }           
            logger.LogMethodExit("DRTDefaultUXPage",
                "ClickTheCreatePreTestLink", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Skill StudyPlan
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity typ enum.</param>
        public void CreateSkillStudyPlan(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create Skill StudyPlan
            logger.LogMethodEntry("DRTDefaultUXPage",
                "CreateSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for TextBox of Study Plan name
                base.WaitForElement(By.Id(DRTDefaultUXPageResource.
                        DRTDefaultUX_Page_StudyplanName_Input_Id_Locator),
                        Convert.ToInt32(DRTDefaultUXPageResource.
                        DRTDefaultUX_page_WaitForElement_Time_Value));
                //Storing the Activity
                Guid studyPlanName = Guid.NewGuid();
                //Fill Text Box With Study Plan Name
                base.FillTextBoxById(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_StudyplanName_Input_Id_Locator,
                    studyPlanName.ToString());
                //Save Skill Study Plan in Memory
                this.StoreActivityInMemory(
                    studyPlanName.ToString(),activityTypeEnum);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DRTDefaultUXPage",
                "CreateSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Activity Details In Memory.
        /// </summary>
        /// <param name="activityName">Activity name.</param>
        /// <param name="activityTypeEnum">This is Activity type enum.</param>
        private void StoreActivityInMemory(
            string activityName, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Store Activity Details In Memory
            logger.LogMethodEntry("DRTDefaultUXPage",
               "StoreActivityInMemory",
               base.IsTakeScreenShotDuringEntryExit);
            Activity activity = new Activity
            {                
                Name = activityName,
                ActivityType=activityTypeEnum,
                IsCreated = true,
            };
            //Save Activity Name to Memory
            activity.StoreActivityInMemory();
            logger.LogMethodExit("DRTDefaultUXPage",
               "StoreActivityInMemory",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Customize the Content
        /// </summary>
        public void CustomizeTheContent()
        {
            //Customize the Content
            logger.LogMethodEntry("DRTDefaultUXPage",
               "CustomizeTheContent",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generates GUID
                Guid assetName = Guid.NewGuid();
                base.WaitUntilWindowLoads(DRTDefaultUXPageResource.
                    DRTDefaultUX_page_Edit_WindowName);
                //Select window
                base.SelectWindow(DRTDefaultUXPageResource.
                    DRTDefaultUX_page_Edit_WindowName);
                //Wait for the Element
                base.WaitForElement(By.Id(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_StudyplanName_Input_Id_Locator));
                base.GetWebElementPropertiesById(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_StudyplanName_Input_Id_Locator).Clear();
                //Fill the Activity name in text box
                base.GetWebElementPropertiesById(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_StudyplanName_Input_Id_Locator).SendKeys(assetName.ToString());
                //Click on save and Return button
                base.WaitForElement(By.PartialLinkText(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_SaveandReturn_Link_PartialLinktext_Locator));
                IWebElement getSaveButton = GetWebElementPropertiesByPartialLinkText(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_SaveandReturn_Link_PartialLinktext_Locator);
                base.ClickByJavaScriptExecutor(getSaveButton);
                //Select window
                base.SelectWindow(DRTDefaultUXPageResource.
                    DRTDefaultUX_page_Content_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DRTDefaultUXPage",
               "CustomizeTheContent",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Post Test Activity.
        /// </summary>
        public void CreatePostTestActivity()
        {
            //Create PostTest Activity
            logger.LogMethodEntry("DRTDefaultUXPage", "CreatePostTestActivity",
                  base.IsTakeScreenShotDuringEntryExit);
            //Generate Activity Name GUID
            Guid activityName = Guid.NewGuid();
            try
            {
                //Select Create Skill Studyplan Window
                this.SelectCreateSkillStudyplanWindow();
                base.WaitForElement(By.XPath(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_Posttest_Img_Xpath_Locator));
                //Click on Create Test 
                IWebElement getCreateTest =
                    base.GetWebElementPropertiesByXPath(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_Posttest_Img_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getCreateTest);
                //Select Post Test Window
                this.SelectPostTestWindow();
                //Enter Activity Title
                new AddAssessmentPage().EnterActivityTitle(activityName);
                //Click On Save and Continue Button
                new AddAssessmentPage().ClickOnSaveAndContinueButton();
                //Select Question For Post Test
                this.SelectQuestionForPostTest();
                //Click on Add and Close Button
                this.ClickonAddandCloseButton();
                //Select Post Test Window
                this.SelectPostTestWindow();
                //Click On Save And Return Button
                new RandomTopicListPage().ClickOnSaveAndReturnButton();
                //Click On Save Close Button Of Skill StudyPlan
                this.ClickOnSaveCloseButtonOfSkillStudyPlan();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DRTDefaultUXPage", "CreatePostTestActivity",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add and Close Button.
        /// </summary>
        private void ClickonAddandCloseButton()
        {
            //Click on Add and Close Button
            logger.LogMethodEntry("DRTDefaultUXPage", "ClickonAddandCloseButton",
                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_AddandClose_Button_Id_Locator));
            //Click on Add and Close Button
            IWebElement getAddandCloseButton = base.GetWebElementPropertiesById
                (DRTDefaultUXPageResource.
                DRTDefaultUX_Page_AddandClose_Button_Id_Locator);
            //Click on the save button
            base.ClickByJavaScriptExecutor(getAddandCloseButton);
            logger.LogMethodExit("DRTDefaultUXPage", "ClickonAddandCloseButton",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question For Post Test.
        /// </summary>
        private void SelectQuestionForPostTest()
        {
            //Select Question For Post Test
            logger.LogMethodEntry("DRTDefaultUXPage", "SelectQuestionForPostTest",
                  base.IsTakeScreenShotDuringEntryExit);
            //Click on Add Questions Link For Post Test
            new RandomTopicListPage().SelectAddQuestionsLinkForPostTest();
            //Select Question Window and Frame
            new SkillStandardAlignedAssetsUXPage().SelectQuestionFrame();
            //Select Question Checkbox
            new SkillStandardAlignedAssetsUXPage().SelectQuestionCheckbox();
            //Select Questions Window
            this.SelectQuestionsWindow();
            logger.LogMethodExit("DRTDefaultUXPage", "SelectQuestionForPostTest",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Post Test Window.
        /// </summary>
        private void SelectPostTestWindow()
        {
            //Select Post Test Window
            logger.LogMethodEntry("DRTDefaultUXPage", "SelectPostTestWindow",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_PostTest_Window_Name);
            //Select Window
            base.SelectWindow(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_PostTest_Window_Name);
            logger.LogMethodExit("DRTDefaultUXPage", "SelectPostTestWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Questions Window.
        /// </summary>
        private void SelectQuestionsWindow()
        {
            //Select Questions Window
            logger.LogMethodEntry("DRTDefaultUXPage", "SelectQuestionsWindow",
                 base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_SelectQuestions_Window_Name);
            //Select the window
            base.SelectWindow(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_SelectQuestions_Window_Name);
            logger.LogMethodExit("DRTDefaultUXPage", "SelectQuestionsWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Skill Studyplan Window.
        /// </summary>
        public void SelectCreateSkillStudyplanWindow()
        {
            //Select Create Skill Studyplan Window
            logger.LogMethodEntry("DRTDefaultUXPage", "SelectCreateSkillStudyplanWindow",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Create Skill Study Plan Window Loads
                base.WaitUntilWindowLoads(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_CreateSkillStudyPlan_Window_Name);
                //Select Create Skill Study Plan Window
                base.SelectWindow(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_CreateSkillStudyPlan_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DRTDefaultUXPage", "SelectCreateSkillStudyplanWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Study Plan.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        public void CreateStudyPlan(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create Study Plan
            logger.LogMethodEntry("DRTDefaultUXPage",
                "CreateStudyPlan", base.IsTakeScreenShotDuringEntryExit);          
            try
            {
                RandomTopicListPage randomTopicListPage = new RandomTopicListPage();
                AddAssessmentPage addAssessmentPage = new AddAssessmentPage();
                //Select Window
                this.SelectWindow();
                //Enter Studyplan Name and Store
                this.EnterStudyplanNameandStore(activityTypeEnum);
                //Click on Create Pretest Link
                this.ClickTheCreatePreTestLink(); 
                //Create Pretest
                addAssessmentPage.CreatePreTestActivity();
                //Select Add Question Link
                randomTopicListPage.ClickonAddQuestionLink();
                //Select Question               
                new ContentBrowserMainUXPage().SelectQuestion();
                //Select Window
                addAssessmentPage.SelectPretestWindow();
                //Click on Message Tab
                addAssessmentPage.ClickonMessageTab();
                //Enter Start and End Message
                addAssessmentPage.EnterStartandEndMessage();
                //Select Window
                addAssessmentPage.SelectPretestWindow();
                //Click On Save And Return Button
                new RandomAssessmentPage().ClickSaveandReturnActivityPreferenceButtonInMessageTab();
                //Select Window
                this.SelectWindow();
                //Click on Save and Close Button
                this.ClickonSaveandCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DRTDefaultUXPage",
                "CreateStudyPlan", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Studyplan Name and Store.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        private void EnterStudyplanNameandStore(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Enter Studyplan Name and Store
            logger.LogMethodEntry("DRTDefaultUXPage",
                "EnterStudyplanNameandStore", base.IsTakeScreenShotDuringEntryExit); 
            //Wait for TextBox of Study Plan name
            base.WaitForElement(By.Id(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_StudyplanName_Input_Id_Locator),
                    Convert.ToInt32(DRTDefaultUXPageResource.
                    DRTDefaultUX_page_WaitForElement_Time_Value));
            //GUID for Studyplan Name
            Guid studyPlanName = Guid.NewGuid();
            //Fill Text Box With Study Plan Name
            base.FillTextBoxById(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_StudyplanName_Input_Id_Locator,
                studyPlanName.ToString());
            //Storing the Activity
            this.StoreActivityInMemory(studyPlanName.ToString(), activityTypeEnum);
            logger.LogMethodExit("DRTDefaultUXPage",
                "EnterStudyplanNameandStore", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Studyplan Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Studyplan Window
            logger.LogMethodEntry("DRTDefaultUXPage",
                "SelectWindow", base.IsTakeScreenShotDuringEntryExit); 
            base.WaitUntilWindowLoads(DRTDefaultUXPageResource.
                DRTDefaultUX_page_StudyPlan_Window_Name);
            //Select Window
            base.SelectWindow(DRTDefaultUXPageResource.
                DRTDefaultUX_page_StudyPlan_Window_Name);
            logger.LogMethodExit("DRTDefaultUXPage",
                "SelectWindow", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
