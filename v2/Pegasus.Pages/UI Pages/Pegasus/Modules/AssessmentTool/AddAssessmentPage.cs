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
    /// This Class Handles Create Custom Content activity
    /// </summary>
    public class AddAssessmentPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(AddAssessmentPage));


        /// <summary>
        /// This the enum available for Asset type Enum
        /// </summary>
        public enum AssetTypeEnum
        {
            /// <summary>
            /// Asset type for Licensed
            /// </summary>
            Licensed = 1,
            /// <summary>
            /// Asset type for NonLicensed
            /// </summary>
            NonLicensed,
        }

        /// <summary>
        /// Create Global Custom Content Activity
        /// </summary>
        /// <param name="getAssetType">This is AssetType</param>
        /// <param name="activityType">This is Activity by type</param>
        public void CreateGlobalCustomContentActivity
          (AddAssessmentPage.AssetTypeEnum getAssetType,
          Activity.ActivityTypeEnum activityType)
        {
            //Create Global Custom Content Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateGlobalCustomContentActivity",
                 base.isTakeScreenShotDuringEntryExit);
            //Intialize Guid for Activity
            Guid activityTest = Guid.NewGuid();
            try
            {
                //Select the frame
                new CustomContentPage().SelectCurriculumFrame();
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAsessment_Page_ActivityName_Id_Locator));
                //Fill the Activity Name in textbox
                base.FillTextBoxByID(AddAssessmentPageResources.
                    AddAsessment_Page_ActivityName_Id_Locator, activityTest.ToString());
                //Store the Activity content
                this.StoreTheActivityContent(activityTest, getAssetType);
                switch (getAssetType)
                {
                    case AssetTypeEnum.Licensed:
                        //Click The Activity Radio Button
                        this.ClickTheBasicRandomRadioButton();
                        break;
                }
                //Click On SaveAndContinue Button
                this.ClickOnSaveContinueButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "CreateGlobalCustomContentActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click On SaveAndContinue Button
        /// </summary>
        private void ClickOnSaveContinueButton()
        {
            //Click On SaveAndContinue Button
            logger.LogMethodEntry("AddAssessmentPage", "ClickOnSaveContinueButton",
                 base.isTakeScreenShotDuringEntryExit);
            base.FocusOnElementByID(AddAssessmentPageResources.
                AddAsessment_Page_SaveAndContinue_Button_Id_Locator);
            //Click on the "SaveAndContinue" Button
            base.ClickButtonByID(AddAssessmentPageResources.
                AddAsessment_Page_SaveAndContinue_Button_Id_Locator);
            Thread.Sleep(Convert.ToInt32(AddAssessmentPageResources.
                 AddAsessment_Page_Asset_Question_Window_Time_Value));
            //Select the Add Question 
            this.SelectAddQuestion();
            //Click the Question type
            new SelectQuestionTypePage().ClickTheQuestionType();
            logger.LogMethodExit("AddAssessmentPage", "ClickOnSaveContinueButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the Radio button.
        /// </summary>
        private void ClickTheBasicRandomRadioButton()
        {
            //Click the Radio button
            logger.LogMethodEntry("AddAssessmentPage",
                "ClickTheBasicRandomRadioButton",
                 base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                 AddAsessment_Page_BehavioralMode_RedioButton_Id_Locator));
            IWebElement getBasicRadioButton = base.GetWebElementPropertiesById(
                AddAssessmentPageResources.
                 AddAsessment_Page_BehavioralMode_RedioButton_Id_Locator);
            //Click on Radio Button
            base.ClickByJavaScriptExecutor(getBasicRadioButton);
            logger.LogMethodExit("AddAssessmentPage",
                "ClickTheBasicRandomRadioButton",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store the Activity content
        /// </summary>
        /// <param name="activityTest">This is activity Guid</param>      
        private void StoreTheActivityContent(Guid activityTest,
            AddAssessmentPage.AssetTypeEnum getAssetType)
        {
            //Store the Activity content
            logger.LogMethodEntry("AddAssessmentPage", "StoreTheActivityContent",
                 base.isTakeScreenShotDuringEntryExit);
            switch (getAssetType)
            {
                //Storing the Licensed Activity
                case AssetTypeEnum.Licensed:
                    this.StoreLicensedActivity(activityTest);
                    break;
                //Storing the NonLicensed Activity
                case AssetTypeEnum.NonLicensed:
                    this.StoreNonLicensedActivity(activityTest);
                    break;
            }
            logger.LogMethodExit("AddAssessmentPage", "StoreTheActivityContent",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store NonLicensed Activity
        /// </summary>
        /// <param name="activityTest">This is activity</param>
        private void StoreNonLicensedActivity(Guid activityTest)
        {
            //Store NonLicensed Activity
            logger.LogMethodEntry("AddAssessmentPage", "StoreNonLicensedActivity",
                  base.isTakeScreenShotDuringEntryExit);
            //Store the activity in memory
            Activity newActivityTest = new Activity
            {
                ActivityID = CommonResource.CommonResource.DigitalPath_Activity_Test_UC3,
                Name = activityTest.ToString(),
                ActivityType = Activity.ActivityTypeEnum.Test,
                IsCreated = true,
            };
            newActivityTest.StoreActivityInMemory();
            logger.LogMethodExit("AddAssessmentPage", "StoreNonLicensedActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Licensed Activity
        /// </summary>
        /// <param name="activityTest">This is activity</param>
        private void StoreLicensedActivity(Guid activityTest)
        {
            //Store Licensed Activity
            logger.LogMethodEntry("AddAssessmentPage", "StoreLicensedActivity",
                  base.isTakeScreenShotDuringEntryExit);
            //Store the activity in memory
            Activity newActivityTest = new Activity
            {
                ActivityID = CommonResource.CommonResource.DigitalPath_Activity_Test_UC2,
                Name = activityTest.ToString(),
                ActivityType = Activity.ActivityTypeEnum.Test,
                IsCreated = true,
            };
            newActivityTest.StoreActivityInMemory();
            logger.LogMethodExit("AddAssessmentPage", "StoreLicensedActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Add Questions 
        /// </summary>        
        public void SelectAddQuestion()
        {
            //Select Add Questions 
            logger.LogMethodEntry("AddAssessmentPage", "SelectAddQuestion",
                   base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the frame
                new CustomContentPage().SelectCurriculumFrame();
                //Wait for the element
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAsessment_Page_AddQuestion_Link_Id_Locator));
                IWebElement getAddQuesLinkProperty =
                    base.GetWebElementPropertiesById(AddAssessmentPageResources.
                    AddAsessment_Page_AddQuestion_Link_Id_Locator);
                //Find the element
                WebDriver.FindElement(By.Id(AddAssessmentPageResources.
                  AddAsessment_Page_AddQuestion_Link_Id_Locator)).
                  SendKeys(string.Empty);
                //Click the "AddQuestion" link  
                base.ClickByJavaScriptExecutor(getAddQuesLinkProperty);
                //Click The Create Question link
                this.ClickTheCreateQuestionLink();
                Thread.Sleep(Convert.ToInt32(AddAssessmentPageResources.
                     AddAsessment_Page_Asset_Question_Window_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "SelectAddQuestion",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Create Question link
        /// </summary>
        private void ClickTheCreateQuestionLink()
        {
            //Click The Create Question link
            logger.LogMethodEntry("AddAssessmentPage", "ClickTheCreateQuestionLink",
                   base.isTakeScreenShotDuringEntryExit);
            //Wait for the element             
            base.WaitForElement(By.XPath(AddAssessmentPageResources.
               AddAsessment_Page_CreateQues_Link_Xpath_Locator));
            base.FocusOnElementByXPath(AddAssessmentPageResources.
               AddAsessment_Page_CreateQues_Link_Xpath_Locator);
            //Get web element
            IWebElement getCreateQuesLinkProperty = base.GetWebElementPropertiesByXPath
                (AddAssessmentPageResources.
               AddAsessment_Page_CreateQues_Link_Xpath_Locator);
            //Click the "Create New Question" link
            base.ClickByJavaScriptExecutor(getCreateQuesLinkProperty);
            Thread.Sleep(Convert.ToInt32(AddAssessmentPageResources.
                AddAsessment_Page_Asset_Question_Window_Time_Value));
            logger.LogMethodExit("AddAssessmentPage", "ClickTheCreateQuestionLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode Enum.</param>
        public void CreateActivity(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateActivity",
                   base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Generate Random Number
                string randomNumber = base.GetRandomNumber(AddAssessmentPageResources.
                    AddAsessment_Page_RandomNumber_Character,
                    Convert.ToInt32(AddAssessmentPageResources.
                    AddAsessment_Page_RandomNumber_Length));
                //Generate GUID for Activity Name
                Guid activity = Guid.NewGuid();
                string activityName = activity.ToString();
                switch (behavioralModeEnum)
                {
                    case Activity.ActivityBehavioralModesEnum.BasicRandom:
                        //Create Basic Random Behavioral Mode Activity\
                        activityName = activityName + randomNumber;
                        this.CreateBasicRandomBehavioralModeActivity(activityName);
                        //Store Activity Details In Memory
                        this.StoreActivityDetails(activityTypeEnum, behavioralModeEnum, activityName);
                        break;

                    case Activity.ActivityBehavioralModesEnum.Assignment:
                        //Create Assignment Behavoiral Mode Activity
                        this.CreateAssignmentBehavioralModeActivity(activityName);
                        //Store Activity Details In Memory
                        this.StoreActivityDetails(activityTypeEnum, behavioralModeEnum, activityName);
                        break;

                    case Activity.ActivityBehavioralModesEnum.SkillBased:
                        //Create SIM5Skill Behavoiral Mode Activity
                        this.CreateSIM5SkillBehavioralModeActivity(activityName,behavioralModeEnum);
                        //Store Activity Details In Memory
                        this.StoreActivityDetails(activityTypeEnum, behavioralModeEnum, activityName);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "CreateActivity",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create SIM5 Skill Behavioral Mode Activity
        /// </summary>
        /// <param name="activityName">This is activityName</param>
        private void CreateSIM5SkillBehavioralModeActivity(string activityName, 
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            logger.LogMethodEntry("AddAssessmentPage", "CreateSIM5SkillBehavioralModeActivity",
                  base.isTakeScreenShotDuringEntryExit);
            //Create Object for ContentBrowserUXPage
            ContentBrowserUXPage contentBrowserUXPage = new ContentBrowserUXPage();
            //Create The Activity
            this.CreateTheActivityUsingBehavioralModeType(activityName, behavioralModeEnum);
            //Select Questions Window
            contentBrowserUXPage.SelectQuestionsWindow();
            contentBrowserUXPage.SwitchToPopupPageContentIFrameLeft();
            //Click On Question Folder
            contentBrowserUXPage.ClickOnQuestionFolderInHed(AddAssessmentPageResources.
                AddAsessment_Page_QuestionFolder_Name);
            //Slect Fill in the Blank Question
            new ContentBrowserUXPage().SelectQuestion
                (AddAssessmentPageResources.AddAssement_Page_Question_Name);
            Thread.Sleep(Convert.ToInt32(AddAssessmentPageResources.
                AddAsessment_Page_Asset_Question_Window_Time_Value));
            //Select Create Activity Window
            this.SelectCreateActivityWindow();
            //Click On Save and Return Button
            new RandomTopicListPage().ClickOnSaveAndReturnButton();            
            logger.LogMethodExit("AddAssessmentPage", "CreateSIM5SkillBehavioralModeActivity",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create The Activity Using Behavioral ModeType.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode.</param>
        private void CreateTheActivityUsingBehavioralModeType(string activityName,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create The Activity Using Behavioral ModeType.
            logger.LogMethodEntry("AddAssessmentPage", 
                "CreateTheActivityUsingBehavioralModeType",
                  base.isTakeScreenShotDuringEntryExit);
            //Select Create Activity Window
            this.SelectCreateActivityWindow();
            //Fill Asset name
            this.FillAssetName(activityName);
            switch (behavioralModeEnum)
            {
                case Activity.ActivityBehavioralModesEnum.SkillBased:
                    //Select Skill based Behavioral Mode
                    this.SelectSkillBasedBehavioralMode();
                    break;
                case Activity.ActivityBehavioralModesEnum.DocBased:
                    //Select Doc based Behavioral Mode
                    this.SelectDocBasedBehavioralMode();
                    break;
            }            
            //Click On Save And Continue Button
            this.ClickOnSaveAndContinueButton();
            //Select Create Random Activity
            this.SelectCreateActivityWindow();
            //Click On Add Question Link
            new RandomTopicListPage().ClickOnAddQuestionLink();
            logger.LogMethodExit("AddAssessmentPage", 
                "CreateTheActivityUsingBehavioralModeType",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create SIM Activity Of Behavioral ModeType.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="behavioralModeEnum">This is behavioral Mode Type Enum. </param>
        private void CreateSIMActivityOfBehavioralModeType(string activityName, 
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create SIM Activity Of Behavioral ModeType
            logger.LogMethodEntry("AddAssessmentPage", "CreateSIMActivityOfBehavioralModeType",
                  base.isTakeScreenShotDuringEntryExit);
            //Create Object for ContentBrowserUXPage
            ContentBrowserUXPage contentBrowserUXPage = new ContentBrowserUXPage();            
            //Create The Activity
            this.CreateTheActivityUsingBehavioralModeType(activityName, behavioralModeEnum);
            //Select the Question Type
            new SkillBasedAssessmentPage().SelectTheQuestionType(
                AddAssessmentPageResources.AddAssement_Page_Select_QuestionType);
            switch (behavioralModeEnum)
            {
                case Activity.ActivityBehavioralModesEnum.SkillBased:
                    //Search the Question
                    contentBrowserUXPage.SearchTheQuestionInSelectQuestionWindow(
                        AddAssessmentPageResources.AddAssement_Page_Search_QuestionName); 
                    break;
                case Activity.ActivityBehavioralModesEnum.DocBased:
                    Question questionName = Question.Get(
                        Question.QuestionTypeEnum.SIM2010WordQuestionSet);
                    //Search the Question
                    new ContentBrowserUXPage().SelectQuestion(questionName.Name);
                    break;
            }                               
            logger.LogMethodExit("AddAssessmentPage", "CreateSIMActivityOfBehavioralModeType",
                   base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select Create Activity Window.
        /// </summary>
        private void SelectCreateActivityWindow()
        {
            //Select Create Activity Window
            logger.LogMethodEntry("AddAssessmentPage", "SelectCreateActivityWindow",
                   base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(AddAssessmentPageResources.
                AddAsessment_Page_Createactivity_Window_Name);
            //Select Create Activity Window
            base.SelectWindow(AddAssessmentPageResources.
                AddAsessment_Page_Createactivity_Window_Name);
            logger.LogMethodExit("AddAssessmentPage", "SelectCreateActivityWindow",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Asset Name
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        private void FillAssetName(String assetName)
        {
            //Fill Asset Name
            logger.LogMethodEntry("AddAssessmentPage", "FillAssetName",
                   base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                     AddAsessment_Page_ActivityName_Id_Locator));
            //Fill the Activity Name in textbox
            base.FillTextBoxByID(AddAssessmentPageResources.
                AddAsessment_Page_ActivityName_Id_Locator, assetName);
            logger.LogMethodExit("AddAssessmentPage", "FillAssetName",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Skill Based Behavioral Mode.
        /// </summary>
        private void SelectSkillBasedBehavioralMode()
        {
            //Select Skill Based Behavioral Mode
            logger.LogMethodEntry("AddAssessmentPage", "SelectSkillBasedBehavioralMode",
                   base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAsessment_Page_SkillBased_RadioButton_Id_Locator));
            //Get Skill Based Radio Button Property
            IWebElement getSkillRadioButtonProperty = base.GetWebElementPropertiesById(
                AddAssessmentPageResources.AddAsessment_Page_SkillBased_RadioButton_Id_Locator);
            //Click On Skill Based Radio Button
            base.ClickByJavaScriptExecutor(getSkillRadioButtonProperty);
            logger.LogMethodExit("AddAssessmentPage", "SelectSkillBasedBehavioralMode",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Doc Based Behavioral Mode.
        /// </summary>
        private void SelectDocBasedBehavioralMode()
        {
            //Select Doc Based Behavioral Mode
            logger.LogMethodEntry("AddAssessmentPage", "SelectDocBasedBehavioralMode",
                   base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAssement_Page_Select_DocBased_Mode_Id_Locator));
            //Get Doc Based Radio Button Property
            IWebElement getDocRadioButtonProperty = base.GetWebElementPropertiesById(
                AddAssessmentPageResources.AddAssement_Page_Select_DocBased_Mode_Id_Locator);
            //Click On Doc Based Radio Button
            base.ClickByJavaScriptExecutor(getDocRadioButtonProperty);
            logger.LogMethodExit("AddAssessmentPage", "SelectDocBasedBehavioralMode",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create 'Assignment' Behavioral Mode Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void CreateAssignmentBehavioralModeActivity(String activityName)
        {
            //Create Assignment Behoiral Mode Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateAssignmentBehavioralModeActivity",
                 base.isTakeScreenShotDuringEntryExit);
            //Select Create Activity Window
            this.SelectCreateActivityWindow();
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                     AddAsessment_Page_ActivityName_Id_Locator));
            //Fill the Activity Name in textbox
            base.FillTextBoxByID(AddAssessmentPageResources.
                AddAsessment_Page_ActivityName_Id_Locator, activityName);
            //Select Assignemt Radio Button
            this.SelectAssignmentRadioButton();
            //Click On Save and Continue
            this.ClickOnSaveAndContinueButton();
            //Select Create Assignment Activity Window
            this.SelectCreateAssignmentActivityWindow();            
            //Click On Add Question Link
            new RandomTopicListPage().ClickOnAddQuestionLink();
            //Select Question From Bank Option
            new RandomTopicListPage().SelectQuestionFromBankForAssignment();
            //Get Essat Question Details From Memory
            Question fileUploadQuestion = Question.Get(Question.QuestionTypeEnum.FileUpload);
            //Select Essay Question
            new ContentBrowserUXPage().SelectQuestion(fileUploadQuestion.Name); 
            //Select Create Assignment Activity Window
            this.SelectCreateAssignmentActivityWindow();       
            //Check Activity Selected
            new RandomTopicListPage().WaitForQuestionToDisplay();
            //Select Create Assignment Activity Window
            this.SelectCreateAssignmentActivityWindow();       
            //Click On Save and Return Button
            new RandomTopicListPage().ClickOnSaveAndReturnButton();
            logger.LogMethodExit("AddAssessmentPage", "CreateAssignmentBehavioralModeActivity",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Assignment Activity Window.
        /// </summary>
        private void SelectCreateAssignmentActivityWindow()
        {
            //Select Create Assignment Activity Window
            logger.LogMethodEntry("AddAssessmentPage", "SelectCreateAssignmentActivityWindow",
                 base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(AddAssessmentPageResources.
                 AddAsessment_Page_CreateAssignmentactivity_Window_Name);
            //Select Create Assignemt Activity Window
            base.SelectWindow(AddAssessmentPageResources.
                AddAsessment_Page_CreateAssignmentactivity_Window_Name);
            logger.LogMethodExit("AddAssessmentPage", "SelectCreateAssignmentActivityWindow",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Basic Random Behavioral Mode Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void CreateBasicRandomBehavioralModeActivity(String activityName)
        {
            //Create Basic Random Behavoiral Mode Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateBasicRandomBehavioralModeActivity",
                 base.isTakeScreenShotDuringEntryExit);
            //Select Create Activity Window
            this.SelectCreateActivityWindow();
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                     AddAsessment_Page_ActivityName_Id_Locator));
            //Fill the Activity Name in textbox
            base.FillTextBoxByID(AddAssessmentPageResources.
                AddAsessment_Page_ActivityName_Id_Locator, activityName);
            //Click The Basic Random Radio Button
            this.ClickTheBasicRandomRadioButton();
            //Click On Save and Continue Button
            this.ClickOnSaveAndContinueButton();
            //Select Create Random Activity
            this.SelectCreateRandomActivity();
            //Click On Add Question Link
            new RandomTopicListPage().ClickOnAddQuestionLink();
            //Select Question From Bank Option
            new RandomTopicListPage().SelectQuestionFromBankForBasicRandom();
            //Get Fill In the Blanks Question Details from Memory
            Question fillInTheBlanksQuestion = Question.
               Get(Question.QuestionTypeEnum.FillInTheBlank);
            //Slect Fill in the Blank Question
            new ContentBrowserUXPage().SelectQuestion(fillInTheBlanksQuestion.Name);
            //Select Create Random Activity
            this.SelectCreateRandomActivity();
            //Check Activity Selected
            new RandomTopicListPage().WaitForQuestionToDisplay();
            //Select Create Random Activity
            this.SelectCreateRandomActivity();
            //Click On Save And Return Button
            new RandomTopicListPage().ClickOnSaveAndReturnButton();
            logger.LogMethodExit("AddAssessmentPage", "CreateBasicRandomBehavioralModeActivity",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Activity Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterActivityTitle(Guid activityTitle)
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityTitle",
                   base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                             AddAsessment_Page_ActivityName_Id_Locator));
                //Fill the Activity Name in textbox
                base.FillTextBoxByID(AddAssessmentPageResources.
                    AddAsessment_Page_ActivityName_Id_Locator, activityTitle.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityTitle",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click On SaveAndContinue Button.
        /// </summary>
        public void ClickOnSaveAndContinueButton()
        {
            //Click On SaveAndContinue Button
            logger.LogMethodEntry("RandomTopicListPage", "ClickOnSaveAndContinueButton",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                        AddAsessment_Page_SaveAndContinue_Button_Id_Locator));
                base.FocusOnElementByID(AddAssessmentPageResources.
                    AddAsessment_Page_SaveAndContinue_Button_Id_Locator);
                //Get Save And Continue Button Property
                IWebElement getbuttonProperty = base.GetWebElementPropertiesById(
                    AddAssessmentPageResources.
                    AddAsessment_Page_SaveAndContinue_Button_Id_Locator);
                //Click On Save And Continue Button
                base.ClickByJavaScriptExecutor(getbuttonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RandomTopicListPage", "ClickOnSaveAndContinueButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Assignment Radio Button.
        /// </summary>
        private void SelectAssignmentRadioButton()
        {
            //Click the Assignment Radio button
            logger.LogMethodEntry("AddAssessmentPage", "SelectAssignmentRadioButton",
                 base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAsessment_Page_BehavioralMode_Assignment_RadioButton_Id_Locator));
            //Click the Radio button
            base.SelectRadioButtonById(AddAssessmentPageResources.
                AddAsessment_Page_BehavioralMode_Assignment_RadioButton_Id_Locator);
            logger.LogMethodExit("AddAssessmentPage", "SelectAssignmentRadioButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Activity Details.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behvioralModeTypeEnum">This is Behavioral Mode Enum.</param>
        /// <param name="activityName">This is Activity Name.</param>
        public void StoreActivityDetails(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behvioralModeTypeEnum, String activityName)
        {
            logger.LogMethodEntry("AddAssessmentPage", "StoreActivityDetails",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Store the activity in memory
                Activity newActivityTest = new Activity
                {
                    Name = activityName,
                    ActivityType = activityTypeEnum,
                    ActivityBehavioralMode = behvioralModeTypeEnum,
                    IsCreated = true,
                };
                newActivityTest.StoreActivityInMemory();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "StoreActivityDetails",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create PreTest Activity.
        /// </summary>
        public void CreatePreTestActivity()
        {
            //Create PreTest Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreatePreTestActivity",
                  base.isTakeScreenShotDuringEntryExit);
            //Generate Activity Name GUID
            Guid activityName = Guid.NewGuid();            
            try
            {
                //Select Pretest Window
                this.SelectPretestWindow();
                //Enter Activity Title
                this.EnterActivityTitle(activityName);
                //Store PreTest Details
                this.StoreGradableAsset(activityName, Activity.ActivityTypeEnum.PreTest);                        
                //Click On Save and Continue Button
                this.ClickOnSaveAndContinueButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "CreatePreTestActivity",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Pretest Window.
        /// </summary>
        public void SelectPretestWindow()
        {
            //Select Pretest Window
            logger.LogMethodEntry("AddAssessmentPage", "SelectPretestWindow",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(AddAssessmentPageResources.
                    AddAsessment_Page_PretestActiviity_Window_Name);
                base.SelectWindow(AddAssessmentPageResources.
                    AddAsessment_Page_PretestActiviity_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "SelectPretestWindow",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Activity Details and Click on Add Question.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type.</param>
        public void EnterActivityDetailsandClickonAddQuestion
            (Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Enter Activity Details and Click on Add Question
            logger.LogMethodEntry("AddAssessmentPage",
                "EnterActivityDetailsandClickonAddQuestion",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Generate Activity Name GUID
                Guid activityName = Guid.NewGuid();
                //Select Window
                this.SelectCreateActivityWindow();
                //Enter Activity Title
                this.EnterActivityTitle(activityName);
                //Click The Basic Random Radio Button
                this.ClickTheBasicRandomRadioButton();
                //Click On Save and Continue Button
                this.ClickOnSaveAndContinueButton();
                //Store Gradable NonGradable Asset
                this.StoreGradableAsset(activityName, activityTypeEnum);
                //Select Create Random Activity
                this.SelectCreateRandomActivity();
                //Click On Add Question Link
                new RandomTopicListPage().ClickOnAddQuestionLink();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage",
                "EnterActivityDetailsandClickonAddQuestion",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Random Activity.
        /// </summary>
        public void SelectCreateRandomActivity()
        {
            //Select Create Random Activity
            logger.LogMethodEntry("AddAssessmentPage",
                "SelectCreateRandomActivity",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(AddAssessmentPageResources.
                        AddAsessment_Page_CreateRandomActivity_Window_Name);
                //Select Window
                base.SelectWindow(AddAssessmentPageResources.
                    AddAsessment_Page_CreateRandomActivity_Window_Name);
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage",
               "SelectCreateRandomActivity",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Activity Details.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="activityTypeEnum">This is Activity Type.</param>
        private void StoreGradableAsset(Guid activityName,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Store Activity Details
            logger.LogMethodEntry("AddAssessmentPage",
                "StoreGradableAsset",
                  base.isTakeScreenShotDuringEntryExit);
            Activity newActivity = new Activity
            {
                Name = activityName.ToString(),
                ActivityType = activityTypeEnum,
                IsCreated = true,
            };
            //Saves the Activity
            newActivity.StoreActivityInMemory();
            logger.LogMethodExit("AddAssessmentPage",
                "StoreGradableAsset",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Sim GraderIT Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Activity Behavioral mode type Enum.</param>
        public void CreateSimGraderITActivity(Activity.ActivityTypeEnum 
            activityTypeEnum, Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Select Create Random Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateSimGraderITActivity",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Create Sim GraderIT Activity
                Guid activityName = Guid.NewGuid();
                //Select Window
                this.SelectCreateActivityWindow();
                //Enter Activity Title
                this.EnterActivityTitle(activityName);
                //Select Assignemt Radio Button
                this.SelectAssignmentRadioButton();
                //Select Grader checkbox
                this.SelectGraderCheckbox();
                //Click On Save and Continue Button
                this.ClickOnSaveAndContinueButton();
                //Select Create Assignment Activity Window
                this.SelectCreateAssignmentActivityWindow();
                //Store Activity Details In Memory
                this.StoreSimGraderActivityDetails(
                    activityTypeEnum, behavioralModeEnum, activityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "CreateSimGraderITActivity",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Grader Checkbox.
        /// </summary>
        private void SelectGraderCheckbox()
        {
            //Select Grader Checkbox
            logger.LogMethodEntry("AddAssessmentPage",
                "SelectGraderCheckbox",
                  base.isTakeScreenShotDuringEntryExit);
            //wait for the element
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAsessment_Page_MyItLabGrader_Checkbox_Id_Locator));
            IWebElement getGradeITCheckbox = base.GetWebElementPropertiesById
                (AddAssessmentPageResources.
                AddAsessment_Page_MyItLabGrader_Checkbox_Id_Locator);
            //Select Grader checkbox
            base.ClickByJavaScriptExecutor(getGradeITCheckbox);
            logger.LogMethodExit("AddAssessmentPage",
                "SelectGraderCheckbox",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Activity Details In Memory.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Activity Behavioral mode type Enum.</param>
        /// <param name="activityName">This is Activity Name.</param>
        private void StoreSimGraderActivityDetails(Activity.ActivityTypeEnum activityTypeEnum, 
            Activity.ActivityBehavioralModesEnum behavioralModeEnum, Guid activityName)
        {
            //Store Activity Details In Memory
            logger.LogMethodEntry("AddAssessmentPage",
                "CreateSimGraderITActivity",
                  base.isTakeScreenShotDuringEntryExit);            
                //Store the activity in memory
                Activity newActivityTest = new Activity
                {
                    Name = activityName.ToString(),
                    ActivityType = activityTypeEnum,
                    ActivityBehavioralMode = behavioralModeEnum,
                    IsCreated = true,
                };
                newActivityTest.StoreActivityInMemory();            
            logger.LogMethodExit("AddAssessmentPage",
                "CreateSimGraderITActivity",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On SaveAndReturn Button.
        /// </summary>
        public void ClickOnSaveAndReturnButton()
        {
            //Click On SaveAndReturn Button.
            logger.LogMethodEntry("AddAssessmentPage",
              "ClickOnSaveAndReturnButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create Assignment Activity Window
                this.SelectCreateAssignmentActivityWindow();
                //Click on Save and Return
                new RandomTopicListPage().ClickOnSaveAndReturnButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage",
                "ClickOnSaveAndReturnButton",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create SIM Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        /// <param name="behavioralModeEnum">This is behavioral mode enum.</param>
        public void CreateSIMActivity(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create SIM Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateSIMActivity",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Generate GUID for Activity Name
                Guid activity = Guid.NewGuid();
                string activityName = activity.ToString();
                switch (activityTypeEnum)
                {
                    case Activity.ActivityTypeEnum.SIMExamActivity:
                    case Activity.ActivityTypeEnum.SIMTrainingActivity:
                        //Create SIMActivty Skill Based Behavoiral Mode Activity
                        this.CreateSIMActivityOfBehavioralModeType(activityName, behavioralModeEnum);
                        //Store Activity Details In Memory
                        this.StoreActivityDetails(activityTypeEnum, behavioralModeEnum, activityName);
                        //Verify Play TrainingMode Preference
                        new SkillBasedAssessmentPage().VerifyPlayTrainingModePreference(activityTypeEnum);
                        //Click On Save and Return Button
                        new RandomTopicListPage().ClickOnSaveAndReturnButtonInPreference();
                        //Click On Add And Close Button
                        new ContentBrowserUXPage().ClickOnAddAndCloseButton();
                        break;
                    case Activity.ActivityTypeEnum.SIMStudyPlan2010:
                        new SIMStudyPlanDefaultUXPage().CreateSIMStudyPlanUsingSIMQuestions(
                            activityTypeEnum, behavioralModeEnum);                        
                        break;
                    case Activity.ActivityTypeEnum.SIMStudyPlan2007:
                        //Create SIM Study Plan Using 2007 SIM Questions
                        new SIMStudyPlanDefaultUXPage().CreateSIMStudyPlanUsing2007SIMQuestions(
                            activityTypeEnum, behavioralModeEnum);                        
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("AddAssessmentPage","CreateSIMActivity",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create The Instructor Gradable Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        public void CreateTheInstructorGradableActivity(Activity.ActivityTypeEnum 
            activityTypeEnum)
        {
            //Create The Instructor Gradable Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateTheInstructorGradableActivity",
                base.isTakeScreenShotDuringEntryExit);
            SkillBasedAssessmentPage skillBasedAssessmentPage =
                new SkillBasedAssessmentPage();
            try
            {
                //Select the Question Type
                this.ClickTheCreateQuestionLink();
                //Select Question Type
                new SelectQuestionTypePage().ClickTheEssayQuestionType();
                //Create True/False Question
                new EssayPage().CreateEssayQuestionInsideTheActivity();
                //Click On Add And Close Button
                new ContentBrowserMainUXPage().ClickOnAddAndCloseButton();
                //Select the Create Random Activity window
                this.SelectCreateRandomActivity();
                //enter the message
                this.EnterActivityMessage();
                //Click the preference
                skillBasedAssessmentPage.ClickThePreferenceTab();
                //Select 'Create Random Activity' window
                this.SelectCreateRandomActivity();
                //Set Save for Later Preference
                skillBasedAssessmentPage.SetSaveforLaterPreference();
                //Enable The Manual Grading Preference
                skillBasedAssessmentPage.EnableTheManualGradingPreference();
                //Click On Add And Close Button
                new ContentBrowserUXPage().ClickOnAddAndCloseButton();
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "CreateTheInstructorGradableActivity",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Message.
        /// </summary>
        public void EnterActivityMessage()
        {
            //Enter The Message
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityMessage",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click The Activity Message SubTab
                this.ClickTheActivityMessageSubTab();
                //Select Create Random Activity
                this.SelectCreateRandomActivity();
                //Enter Start and End Message
                this.EnterStartandEndMessage();
                //Message Save Close Button
                this.MessageSaveCloseButton();                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityMessage",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Message Save Close Button
        /// </summary>
        private void MessageSaveCloseButton()
        {
            //Enter The Message
            logger.LogMethodEntry("AddAssessmentPage", "MessageSaveCloseButton",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAssement_Page_ActivityMessagae_SaveButton_Id_Locator));
            IWebElement getSaveButton = base.GetWebElementPropertiesById
                (AddAssessmentPageResources.
                AddAssement_Page_ActivityMessagae_SaveButton_Id_Locator);
            base.ClickByJavaScriptExecutor(getSaveButton);
            logger.LogMethodExit("AddAssessmentPage", "MessageSaveCloseButton",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Start and End Message.
        /// </summary>
        public void EnterStartandEndMessage()
        {
            //Enter Start and End Message
            logger.LogMethodEntry("AddAssessmentPage", "EnterStartandEndMessage",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the begining text element
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAssement_Page_Begin_Message_Id_Locator));
                //Fill the Begin message in textbox
                base.FillTextBoxByID(AddAssessmentPageResources.
                    AddAssement_Page_Begin_Message_Id_Locator,
                    AddAssessmentPageResources.AddAssement_Page_Begin_Message);
                //Wait for the end text element
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAssement_Page_End_Message_Id_Locator));
                //Fill the Activity Name in textbox
                base.FillTextBoxByID(AddAssessmentPageResources.
                    AddAssement_Page_End_Message_Id_Locator,
                    AddAssessmentPageResources.AddAssement_Page_End_Message);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterStartandEndMessage",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Activity Message SubTab.
        /// </summary>
        private void ClickTheActivityMessageSubTab()
        {
            //Click The Activity Message SubTab
            logger.LogMethodEntry("AddAssessmentPage", 
                "ClickTheActivityMessageSubTab",
                base.isTakeScreenShotDuringEntryExit);
            //Select Create Random Activity
            this.SelectCreateRandomActivity();
            //Click on Message Tab
            this.ClickonMessageTab();
            logger.LogMethodExit("AddAssessmentPage", 
                "ClickTheActivityMessageSubTab",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Message Tab.
        /// </summary>
        public void ClickonMessageTab()
        {
            //Click on Message Tab
            logger.LogMethodEntry("AddAssessmentPage","ClickonMessageTab",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAssement_Page_Select_MessageTab_Id_Locator));
                IWebElement getMessageLink = base.GetWebElementPropertiesById
                    (AddAssessmentPageResources.
                    AddAssement_Page_Select_MessageTab_Id_Locator);
                //Click the Message sub tab
                base.ClickByJavaScriptExecutor(getMessageLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage","ClickonMessageTab",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Gradable Activity Using Essay Question.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        public void CreateGradableActivityUsingEssayQuestion(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create Gradable Activity Using Essay Question
            logger.LogMethodEntry("AddAssessmentPage",
                "CreateGradableActivityUsingEssayQuestion",
                base.isTakeScreenShotDuringEntryExit);
            SkillBasedAssessmentPage skillBasedAssessmentPage = 
                new SkillBasedAssessmentPage();
            try
            {
                //Select the Question Type
                this.ClickTheCreateQuestionLink();
                //Select Question Type
                new SelectQuestionTypePage().ClickTheEssayQuestionType();
                //Create True/False Question
                new EssayPage().CreateEssayQuestionInsideTheActivity();
                //Click On Add And Close Button
                new ContentBrowserMainUXPage().ClickOnAddAndCloseButton();
                //Select the Create Random Activity window
                this.SelectCreateRandomActivity();
                //enter the message
                this.EnterActivityMessage();                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage",
                 "CreateGradableActivityUsingEssayQuestion",
                     base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Message For Activity.
        /// </summary>
        public void EnterTheMessageForActivity()
        {
            //Enter The Message For Activity
            logger.LogMethodEntry("AddAssessmentPage",
                "EnterTheMessageForActivity",
                base.isTakeScreenShotDuringEntryExit);
            SkillBasedAssessmentPage skillBasedAssessmentPage =
                new SkillBasedAssessmentPage();
            //Select the Create Random Activity window
            this.SelectCreateRandomActivity();
            //enter the message
            this.EnterActivityMessage();           
            logger.LogMethodExit("AddAssessmentPage",
                 "EnterTheMessageForActivity",
                     base.isTakeScreenShotDuringEntryExit);
        }
    }
}
