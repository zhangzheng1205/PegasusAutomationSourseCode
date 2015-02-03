using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
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
    public class DrtDefaultUxPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(DrtDefaultUxPage));


        ///<summary>
        /// To create a SkillStudyPlan
        ///</summary>
        public void AddPreTestToSkillStudyPlan()
        {
            //Create Study Plan
            Logger.LogMethodEntry("DRTDefaultUXPage",
                "AddPreTestToSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
            //Create studyplan
            try
            {
                //Wait for TextBox of Study Plan name
                base.WaitForElement(By.Id(DRTDefaultUXPageResource.
                        DRTDefaultUX_Page_StudyplanName_Input_Id_Locator),
                        Convert.ToInt32(DRTDefaultUXPageResource.
                        DRTDefaultUX_Page_WaitForElement_Time_Value));
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
            Logger.LogMethodExit("DRTDefaultUXPage",
                "AddPreTestToSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// To Store Activity Name in memory
        /// </summary>
        /// <param name="activityName">Activity Name</param>
        private void StoreActivityDetailsInMemory(string activityName)
        {
            //Store Activity Name in Memory
            Logger.LogMethodEntry("DRTDefaultUXPage",
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
            Logger.LogMethodExit("DRTDefaultUXPage",
                "StoreActivityDetailsInMemory", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On SaveClose Button Of SkillStudyPlan.
        /// </summary>
        public void ClickOnSaveCloseButtonOfSkillStudyPlan()
        {
            // Click On SaveClose Button Of SkillStudyPlan
            Logger.LogMethodEntry("DRTDefaultUXPage",
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
            Logger.LogMethodExit("DRTDefaultUXPage",
                "ClickOnSaveCloseButtonOfSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save and Close Button.
        /// </summary>
        private void ClickonSaveandCloseButton()
        {
            //Click on Save and Close Button
            Logger.LogMethodEntry("DRTDefaultUXPage",
                "ClickOnSaveCloseButtonOfSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_content_SaveButton_Id_Locator));
            //Get Button Property
            IWebElement getSaveandCloseButtonProperty = base.GetWebElementPropertiesById
                (DRTDefaultUXPageResource.DRTDefaultUX_Page_content_SaveButton_Id_Locator);
            //Click on Save and Return Button
            base.ClickByJavaScriptExecutor(getSaveandCloseButtonProperty);
            Thread.Sleep(Convert.ToInt32(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_WaitElement_Thread_Time));
            Logger.LogMethodExit("DRTDefaultUXPage",
                "ClickOnSaveCloseButtonOfSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Creation of Pre Test for Study Plan
        /// </summary>
        public void CreatePreTest()
        {
            //Create Pre Test
            Logger.LogMethodEntry("DRTDefaultUXPage",
                "CreatePreTest", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Add Existing Activity Link
                base.WaitForElement(By.XPath(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_AddExistingActivity_Link_Xpath_Locator));
                IWebElement getActivity = base.GetWebElementPropertiesByXPath
                    (DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_AddExistingActivity_Link_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getActivity);
                //Select the Activity for Pre Test
                new ContentBrowserUXPage().SelectActivityForPreTest(
                    DRTDefaultUXPageResource.DRTDefaultUX_Page_Search_PretestActivity);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("DRTDefaultUXPage",
                "CreatePreTest", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Begin button to initiate pretest.
        /// </summary>
        public void ClickBeginButton()
        {
            //Select Begin Button
            Logger.LogMethodEntry("DRTDefaultUXPage",
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
            Logger.LogMethodExit("DRTDefaultUXPage",
                "ClickBeginButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Study Plan Window.
        /// </summary>
        private void SelectStudyPlanWindow()
        {
            //Select Study Plan Window
            Logger.LogMethodEntry("DRTDefaultUXPage",
                "SelectStudyPlanWindow", base.IsTakeScreenShotDuringEntryExit);
            //Select study plan window
            base.WaitUntilWindowLoads(DRTDefaultUXPageResource
                .DRTDefaultUX_Page_Studyplan_WindowName);
            base.SelectWindow(DRTDefaultUXPageResource
                .DRTDefaultUX_Page_Studyplan_WindowName);
            Logger.LogMethodExit("DRTDefaultUXPage",
                "SelectStudyPlanWindow", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Begin button to initiate posttest.
        /// </summary>
        public void ClickPostTestBeginButton()
        {
            //Select Begin Button
            Logger.LogMethodEntry("DRTDefaultUXPage",
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
            Logger.LogMethodExit("DRTDefaultUXPage",
                "ClickPostTestBeginButton", base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select return to course button
        /// </summary>
        public void ClickReturnToCourseButton()
        {
            //Create Pre Test
            Logger.LogMethodEntry("DRTDefaultUXPage",
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
            Logger.LogMethodExit("DRTDefaultUXPage",
                "ClickReturnToCourseButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Create PreTest link.
        /// </summary>
        public void ClickTheCreatePreTestLink()
        {
            //Click the Pre Test link
            Logger.LogMethodEntry("DRTDefaultUXPage",
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
            Logger.LogMethodExit("DRTDefaultUXPage",
                "ClickTheCreatePreTestLink", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Skill StudyPlan
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity typ enum.</param>
        public void CreateSkillStudyPlan(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create Skill StudyPlan
            Logger.LogMethodEntry("DRTDefaultUXPage",
                "CreateSkillStudyPlan", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for TextBox of Study Plan name
                base.WaitForElement(By.Id(DRTDefaultUXPageResource.
                        DRTDefaultUX_Page_StudyplanName_Input_Id_Locator),
                        Convert.ToInt32(DRTDefaultUXPageResource.
                        DRTDefaultUX_Page_WaitForElement_Time_Value));
                //Storing the Activity
                Guid studyPlanName = Guid.NewGuid();
                //Fill Text Box With Study Plan Name
                base.FillTextBoxById(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_StudyplanName_Input_Id_Locator,
                    studyPlanName.ToString());
                //Save Skill Study Plan in Memory
                this.StoreActivityInMemory(
                    studyPlanName.ToString(), activityTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("DRTDefaultUXPage",
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
            Logger.LogMethodEntry("DRTDefaultUXPage",
               "StoreActivityInMemory",
               base.IsTakeScreenShotDuringEntryExit);
            Activity activity = new Activity
            {
                Name = activityName,
                ActivityType = activityTypeEnum,
                IsCreated = true,
            };
            //Save Activity Name to Memory
            activity.StoreActivityInMemory();
            Logger.LogMethodExit("DRTDefaultUXPage",
               "StoreActivityInMemory",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Customize the Content
        /// </summary>
        public void CustomizeTheContent()
        {
            //Customize the Content
            Logger.LogMethodEntry("DRTDefaultUXPage",
               "CustomizeTheContent",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generates GUID
                Guid assetName = Guid.NewGuid();
                base.WaitUntilWindowLoads(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_Edit_WindowName);
                //Select window
                base.SelectWindow(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_Edit_WindowName);
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
                    DRTDefaultUX_Page_Content_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("DRTDefaultUXPage",
               "CustomizeTheContent",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Post Test Activity.
        /// </summary>
        public void CreatePostTestActivity()
        {
            //Create PostTest Activity
            Logger.LogMethodEntry("DRTDefaultUXPage", "CreatePostTestActivity",
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
            Logger.LogMethodExit("DRTDefaultUXPage", "CreatePostTestActivity",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add and Close Button.
        /// </summary>
        private void ClickonAddandCloseButton()
        {
            //Click on Add and Close Button
            Logger.LogMethodEntry("DRTDefaultUXPage", "ClickonAddandCloseButton",
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
            Logger.LogMethodExit("DRTDefaultUXPage", "ClickonAddandCloseButton",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Question For Post Test.
        /// </summary>
        private void SelectQuestionForPostTest()
        {
            //Select Question For Post Test
            Logger.LogMethodEntry("DRTDefaultUXPage", "SelectQuestionForPostTest",
                  base.IsTakeScreenShotDuringEntryExit);
            //Click on Add Questions Link For Post Test
            new RandomTopicListPage().SelectAddQuestionsLinkForPostTest();
            //Select Question Window and Frame
            new SkillStandardAlignedAssetsUXPage().SelectQuestionFrame();
            //Select Question Checkbox
            new SkillStandardAlignedAssetsUXPage().SelectQuestionCheckbox();
            //Select Questions Window
            this.SelectQuestionsWindow();
            Logger.LogMethodExit("DRTDefaultUXPage", "SelectQuestionForPostTest",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Post Test Window.
        /// </summary>
        private void SelectPostTestWindow()
        {
            //Select Post Test Window
            Logger.LogMethodEntry("DRTDefaultUXPage", "SelectPostTestWindow",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_PostTest_Window_Name);
            //Select Window
            base.SelectWindow(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_PostTest_Window_Name);
            Logger.LogMethodExit("DRTDefaultUXPage", "SelectPostTestWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Questions Window.
        /// </summary>
        private void SelectQuestionsWindow()
        {
            //Select Questions Window
            Logger.LogMethodEntry("DRTDefaultUXPage", "SelectQuestionsWindow",
                 base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_SelectQuestions_Window_Name);
            //Select the window
            base.SelectWindow(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_SelectQuestions_Window_Name);
            Logger.LogMethodExit("DRTDefaultUXPage", "SelectQuestionsWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Skill Studyplan Window.
        /// </summary>
        public void SelectCreateSkillStudyplanWindow()
        {
            //Select Create Skill Studyplan Window
            Logger.LogMethodEntry("DRTDefaultUXPage", "SelectCreateSkillStudyplanWindow",
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
            Logger.LogMethodExit("DRTDefaultUXPage", "SelectCreateSkillStudyplanWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Study Plan.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        public void CreateStudyPlan(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create Study Plan
            Logger.LogMethodEntry("DRTDefaultUXPage",
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
            Logger.LogMethodExit("DRTDefaultUXPage",
                "CreateStudyPlan", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Studyplan Name and Store.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        private void EnterStudyplanNameandStore(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Enter Studyplan Name and Store
            Logger.LogMethodEntry("DRTDefaultUXPage",
                "EnterStudyplanNameandStore", base.IsTakeScreenShotDuringEntryExit);
            //Wait for TextBox of Study Plan name
            base.WaitForElement(By.Id(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_StudyplanName_Input_Id_Locator),
                    Convert.ToInt32(DRTDefaultUXPageResource.
                    DRTDefaultUX_Page_WaitForElement_Time_Value));
            //GUID for Studyplan Name
            Guid studyPlanName = Guid.NewGuid();
            //Fill Text Box With Study Plan Name
            base.FillTextBoxById(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_StudyplanName_Input_Id_Locator,
                studyPlanName.ToString());
            //Storing the Activity
            this.StoreActivityInMemory(studyPlanName.ToString(), activityTypeEnum);
            Logger.LogMethodExit("DRTDefaultUXPage",
                "EnterStudyplanNameandStore", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Studyplan Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Studyplan Window
            Logger.LogMethodEntry("DRTDefaultUXPage",
                "SelectWindow", base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_StudyPlan_Window_Name);
            //Select Window
            base.SelectWindow(DRTDefaultUXPageResource.
                DRTDefaultUX_Page_StudyPlan_Window_Name);
            Logger.LogMethodExit("DRTDefaultUXPage",
                "SelectWindow", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Open Study Plan Window.
        /// </summary>
        private void SelectOpenStudyPlanWindow()
        {
            // select Window
            Logger.LogMethodEntry("DRTDefaultUXPage",
                "SelectOpenStudyPlanWindow", base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads("Open Study Plan");
            base.SelectWindow("Open Study Plan");
            Logger.LogMethodExit("DRTDefaultUXPage",
                "SelectOpenStudyPlanWindow", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Study Plan Asset Name.
        /// </summary>
        /// <param name="assetName">This is asset name.</param>
        /// <returns>Study Plan Name.</returns>
        public string GetStudyPlanAssetName(string assetName)
        {
            // get the study plan asset name.
            Logger.LogMethodEntry("DRTDefaultUXPage",
              "GetStudyPlanAssetName", base.IsTakeScreenShotDuringEntryExit);
            IWebElement webElementPageContent = null;
            try
            {
                // select window
                this.SelectOpenStudyPlanWindow();
                base.WaitForElementDisplayedInUi(By.XPath("//span[@title= '" + assetName + "']"));
                webElementPageContent = base.GetWebElementPropertiesByXPath("//span[@title= '" + assetName + "']");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("DRTDefaultUXPage",
              "GetStudyPlanAssetName", base.IsTakeScreenShotDuringEntryExit);
            return webElementPageContent.Text;
        }

        /// <summary>
        /// Get The Study Plan Window Title.
        /// </summary>
        /// <returns>Selected Window Title.</returns>
        public string GetStudyPlanWindowTitle()
        {
            // get the study plan window title
            Logger.LogMethodEntry("DRTDefaultUXPage",
              "GetStudyPlanWindowTitle", base.IsTakeScreenShotDuringEntryExit);
            string selectedWindowTitle = string.Empty;
            try
            {
                selectedWindowTitle = base.GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("DRTDefaultUXPage",
              "GetStudyPlanWindowTitle", base.IsTakeScreenShotDuringEntryExit);
            return selectedWindowTitle;
        }

        /// <summary>
        /// Click On Button Object.
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        public void ClickOnButtonObject(string buttonName)
        {
            Logger.LogMethodEntry("DRTDefaultUXPage", "ClickOnButtonObject"
                , base.IsTakeScreenShotDuringEntryExit);
            IWebElement webElementButton = null;
            try
            {
                // button name
                switch (buttonName)
                {
                    case "Begin":
                        webElementButton = base.GetWebElementPropertiesById
                            (DRTDefaultUXPageResource.DRTDefaultUX_Page_PageContent_BeginButton_Id_Locator);

                        break;
                    case "Return to Course":
                        webElementButton = base.GetWebElementPropertiesById
                            (DRTDefaultUXPageResource.DRTDefaultUX_Page_PageContent_ReturnToCourseButton_Id_Locator);
                        break;
                }
                // click on button
                base.ClickByJavaScriptExecutor(webElementButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("DRTDefaultUXPage", "ClickOnButtonObject"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Score In Study Plan Test Frame.
        /// </summary>
        /// <returns>Study Plan Score.</returns>
        public string GetScoreInStudyPlanTestFrame()
        {
            // get the score in study plan frame
            Logger.LogMethodEntry("DRTDefaultUXPage",
              "GetScoreInStudyPlanTestFrame", base.IsTakeScreenShotDuringEntryExit);
            IWebElement webElementDrtTestsPanelScore = null;
            try
            {
                // select window
                this.SelectOpenStudyPlanWindow();
                base.WaitForElementDisplayedInUi(By.Id(DRTDefaultUXPageResource
                    .DRTDefaultUX_Page_PageContent_Score_Id_Locator));
                webElementDrtTestsPanelScore = base.GetWebElementPropertiesById(DRTDefaultUXPageResource
                    .DRTDefaultUX_Page_PageContent_Score_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("DRTDefaultUXPage",
              "GetScoreInStudyPlanTestFrame", base.IsTakeScreenShotDuringEntryExit);
            return webElementDrtTestsPanelScore.Text;
        }
    }
}
