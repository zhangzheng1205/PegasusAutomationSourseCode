using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool;
using System.Configuration;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation.AutoGrader;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.ContentTool;


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
                 base.IsTakeScreenShotDuringEntryExit);
            //Intialize Guid for Activity
            Guid activityTest = Guid.NewGuid();
            try
            {
                //Select the frame
                new CustomContentPage().SelectCurriculumFrame();
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAsessment_Page_ActivityName_Id_Locator));
                //Fill the Activity Name in textbox
                base.FillTextBoxById(AddAssessmentPageResources.
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
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click On SaveAndContinue Button
        /// </summary>
        private void ClickOnSaveContinueButton()
        {
            //Click On SaveAndContinue Button
            logger.LogMethodEntry("AddAssessmentPage", "ClickOnSaveContinueButton",
                 base.IsTakeScreenShotDuringEntryExit);
            //Click on the "SaveAndContinue" Button
            base.ClickButtonById(AddAssessmentPageResources.
                AddAsessment_Page_SaveAndContinue_Button_Id_Locator);
            Thread.Sleep(Convert.ToInt32(AddAssessmentPageResources.
                 AddAsessment_Page_Asset_Question_Window_Time_Value));
            //Select the Add Question 
            this.SelectAddQuestion();
            //Click the Question type
            new SelectQuestionTypePage().ClickTheQuestionType();
            logger.LogMethodExit("AddAssessmentPage", "ClickOnSaveContinueButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the Radio button.
        /// </summary>
        private void ClickTheBasicRandomRadioButton()
        {
            //Click the Radio button
            logger.LogMethodEntry("AddAssessmentPage",
                "ClickTheBasicRandomRadioButton",
                 base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Behavioral Mode Type.
        /// </summary>
        public void SelectBehavioralModeType(string behavioralMode)
        {
            //Click the Radio button
            logger.LogMethodEntry("AddAssessmentPage",
                "ClickTheBasicRandomRadioButton",
                 base.IsTakeScreenShotDuringEntryExit);
            switch (behavioralMode)
            {
                case "Basic Random":
                    //Wait for the element
                    base.WaitForElement(By.Id(AddAssessmentPageResources.
                         AddAsessment_Page_BehavioralMode_RedioButton_Id_Locator));
                    IWebElement getBasicRadioButton = base.GetWebElementPropertiesById(
                        AddAssessmentPageResources.
                         AddAsessment_Page_BehavioralMode_RedioButton_Id_Locator);
                    //Click on Radio Button
                    base.ClickByJavaScriptExecutor(getBasicRadioButton);
                    break;

                case "Adaptive":
                    //Wait for the element
                    base.WaitForElement(By.Id(AddAssessmentPageResources.
                         AddAsessment_Page_BehavioralMode_RedioButton_Id_Locator));
                    IWebElement getAdaptiveRadioButton = base.GetWebElementPropertiesById(
                        AddAssessmentPageResources.
                         AddAsessment_Page_BehavioralMode_AdaptiveRadioButton_Id_Locator);
                    //Click on Radio Button 
                    base.ClickByJavaScriptExecutor(getAdaptiveRadioButton);
                    break;

                case "Assignment":
                    //Wait for the element
                    base.WaitForElement(By.Id(AddAssessmentPageResources.
                         AddAsessment_Page_BehavioralMode_RedioButton_Id_Locator));
                    IWebElement getAssignmentRadioButton = base.GetWebElementPropertiesById(
                        AddAssessmentPageResources.
                         AddAsessment_Page_BehavioralMode_AssignmentRadioButton_Id_Locator);
                    //Click on Radio Button 
                    base.ClickByJavaScriptExecutor(getAssignmentRadioButton);
                    break;

            }
            logger.LogMethodExit("AddAssessmentPage",
                "ClickTheBasicRandomRadioButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add question from Select Questions From Bank
        /// </summary>
        /// <param name="questionType">This is question type enum.</param>
        public void AddQuestionFromSelectQuestionsFromBank(Question.QuestionTypeEnum questionType)
        {
            logger.LogMethodEntry("AddAssessmentPage", "AddQuestionFromSelectQuestionsFromBank", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(base.GetPageTitle);
                this.SelectQuestionFromBankForBasicRandom(questionType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "AddQuestionFromSelectQuestionsFromBank", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select Question From Bank for Basic Random.
        /// </summary>
        public void SelectQuestionFromBankForBasicRandom(Question.QuestionTypeEnum questionType)
        {
            //Select Question From Bank for Basic Random
            logger.LogMethodEntry("AddAssessmentPage", "SelectQuestionFromBankForBasicRandom",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Question question = Question.Get(questionType);
                string questionName = question.Name.ToString();

                // Switch to IFrame
                base.WaitForElement(By.Id("frmTopic"));
                base.SwitchToIFrameById("frmTopic");

                IWebElement getAddQuestionsLink = base.GetWebElementPropertiesById("cmdadd");
                base.ClickByJavaScriptExecutor(getAddQuestionsLink);

                // Click "Select Questions from Bank" option
                base.WaitForElement(By.ClassName("trrandomstyle3"));
                IWebElement getSelectQuestionsFromBank = base.GetWebElementPropertiesByClassName("trrandomstyle3");
                base.PerformMouseClickAction(getSelectQuestionsFromBank);
                base.SwitchToLastOpenedWindow();
                base.WaitUntilWindowLoads("Select Questions");
                base.SelectWindow("Select Questions");
                base.SwitchToIFrameById("_ctl0_PopupPageContent_ifrmLeft"); ;

                // Enter the search text
                base.WaitForElement(By.ClassName("txtESearchc"));
                base.ClearTextByClassName("txtESearchc");
                base.FillTextBoxByClassName("txtESearchc", "Culture Close-Up: United States");

                // Click Go button
                base.WaitForElement(By.Id("btnContainer"));
                base.ClickButtonById("btnContainer");

                // Select select all check box
                base.WaitForElement(By.ClassName("ES_PreviewMultiSel"));
                base.SelectCheckBoxByClassName("ES_PreviewMultiSel");

                // Wait for popup to load
                base.WaitUntilWindowLoads("Select Questions");
                base.SelectWindow("Select Questions");

                //Click "Add and Close" button
                base.WaitForElement(By.LinkText("Add and Close"));
                base.ClickButtonByLinkText("Add and Close");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "SelectQuestionFromBankForBasicRandom",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Activity Details and Click on Add Question.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type.</param>
        /// <param name="behavioralMode">This is behavioral Mode.</param>
        public void EnterActivityDetails(Activity.ActivityTypeEnum activityTypeEnum, string behavioralMode)
        {
            //Enter Activity Details and Click on Add Question
            logger.LogMethodEntry("AddAssessmentPage",
                "EnterActivityDetails",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generate Activity Name GUID
                Guid activity = Guid.NewGuid();
                String date = DateTime.Now.ToString("yyyy/MM/dd");
                string randomValue = activity.ToString().Split('-')[0];
                string activityName = string.Empty;

                switch (activityTypeEnum)
                {
                    //Create Activity Name for general activity
                    case Activity.ActivityTypeEnum.RegChildActivity:
                    case Activity.ActivityTypeEnum.RegChildAbruptActivity:
                        activityName = "Auto-" + date + "-" + randomValue + "-Activity";
                        break;
                    //Create Activity Name for activity with GB Score set to First
                    case Activity.ActivityTypeEnum.RegFirstScoreActivity:
                    case Activity.ActivityTypeEnum.RegCSFirstScoreActivity:
                        activityName = "Auto-" + date + "-" + randomValue + "-First-Activity";
                        break;
                    //Create Activity Name for activity with GB Score set to Last
                    case Activity.ActivityTypeEnum.RegLastScoreActivity:
                    case Activity.ActivityTypeEnum.RegCSLastScoreActivity:
                        activityName = "Auto-" + date + "-" + randomValue + "-Last-Activity";
                        break;
                    //Create Activity Name for activity with GB Score set to Highest
                    case Activity.ActivityTypeEnum.RegHighestScoreActivity:
                    case Activity.ActivityTypeEnum.RegCSHighestScoreActivity:
                        activityName = "Auto-" + date + "-" + randomValue + "-Highest-Activity";
                        break;
                    //Create Activity Name for activity with GB Score set to Lowest
                    case Activity.ActivityTypeEnum.RegLowestScoreActivity:
                    case Activity.ActivityTypeEnum.RegCSLowestScoreActivity:
                        activityName = "Auto-" + date + "-" + randomValue + "-Lowest-Activity";
                        break;
                    //Create Activity Name for activity with GB Score set to Average
                    case Activity.ActivityTypeEnum.RegAverageScoreActivity:
                    case Activity.ActivityTypeEnum.RegCSAverageScoreActivity:
                        activityName = "Auto-" + date + "-" + randomValue + "-Average-Activity";
                        break;
                }
                //Select Window
                this.SelectCreateActivityWindow();
                //Enter Activity Title
                this.EnterActivityTitle(activityName);
                //Click The Basic Random Radio Button
                this.SelectBehavioralModeType(behavioralMode);
                //Store Gradable NonGradable Asset
                this.StoreGradableAsset(activityName, activityTypeEnum);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage",
                "EnterActivityDetails",
                   base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter Activity Details and Click on Add Question.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type.</param>
        /// <param name="behavioralMode">This is behavioral Mode.</param>
        public void EnterAssetDetails(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Enter Activity Details and Click on Add Question
            logger.LogMethodEntry("AddAssessmentPage",
                "EnterAssetDetails",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generate Activity Name GUID
                Guid activity = Guid.NewGuid();
                String date = DateTime.Now.ToString("yyyy/MM/dd");
                string randomValue = activity.ToString().Split('-')[0];
                string activityName = string.Empty;

                //Intialize Guid for Page Asset
                Guid newPageAsset = Guid.NewGuid();
                //Generate New Guid Page Name
                Guid newHTMLDiscription = Guid.NewGuid();

                switch (activityTypeEnum)
                {
                    //Create Activity Name for general activity
                    case Activity.ActivityTypeEnum.RegLinkAsset:
                        activityName = "Auto-" + date + "-" + randomValue + "-Non Gradable Link Asset";
                        //Select Window
                        this.SelectCreateLinkAssetWindow();
                        //Enter Activity Title
                        this.EnterLinkAssetTitle(activityName);
                        //Enter Description
                        this.EnterLinkAssetDescription();
                        //Enter website URL
                        this.EnterURLInLinkAsset();
                        // Click add button
                        base.WaitForElement(By.Id(AddAssessmentPageResources.
                            AddAsessment_Page_LinkAsset_AddButton_Id_Locator));
                        base.ClickButtonById(AddAssessmentPageResources.
                            AddAsessment_Page_LinkAsset_AddButton_Id_Locator);
                        //Click On Add And Close Button
                        new ContentBrowserUXPage().ClickOnAddAndCloseButton();
                        //Swith To Add Materials Popup In Course Materials tab
                        new ContentLibraryUXPage().SwithToAddMaterialsPopupInCourseMaterials();
                        //Click on CLose button in Add Materials popup
                        this.CloseAddMaterialsPopupInCourseMaterials();
                        break;

                    case Activity.ActivityTypeEnum.RegEtextLinkAsset:
                        activityName = "Auto-" + date + "-" + randomValue + "-Non Gradable Etext Link Asset";
                        //Select Window
                        this.SelectCreateEtextLinkAssetWindow();
                        //Enter Activity Title
                        this.EnterEtextLinkAssetTitle(activityName);
                        //Enter Description
                        this.SelectBookInEtextLinkAsset();
                        // Click add button
                        bool asd = base.IsElementPresent(By.Id("imgBtnSave_Update"), 10);
                        base.WaitForElement(By.Id("imgBtnSave_Update"));
                        IWebElement getSubmitButton = base.GetWebElementPropertiesById("imgBtnSave_Update");
                        base.PerformMouseClickAction(getSubmitButton);
                        //Click On Add And Close Button
                        new ContentBrowserUXPage().ClickOnAddAndCloseButton();
                        break;

                    case Activity.ActivityTypeEnum.RegFolderAsset:
                        activityName = "Auto-" + date + "-" + randomValue + "-Folder";
                        //Select Window
                        this.SelectCreateNewFolderWindow();
                        //Enter Activity Title
                        this.EnterFolderTitle(activityName);
                        //Enter Description
                        this.EnterFolderDescription();
                        // Click create button
                        base.WaitForElement(By.Id(AddAssessmentPageResources.
                            AddAsessment_Page_Folder_CreateButton_Id_Locator));
                        base.ClickButtonById(AddAssessmentPageResources.
                            AddAsessment_Page_Folder_CreateButton_Id_Locator);
                        //Refresh the page to display new folder created
                        base.RefreshTheCurrentPage();
                        break;

                    case Activity.ActivityTypeEnum.RegFileAsset:
                        activityName = "Auto-" + date + "-" + randomValue + "-Non Gradable File Asset";
                        //Select Window
                        this.SelectCreateFileAssetWindow();
                        string getGraderItWordFilePathFor70Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                             UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_Word_File_70Percent_Path).
                         Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItWordFilePathFor70Percent, By.Id("txtFile"));
                        //Enter Activity Title
                        this.EnterFileAssetTitle(activityName);
                        //Enter Description
                        this.SelectBookInEtextLinkAsset();
                        //Enter website URL
                        this.EnterURLInLinkAsset();
                        // Click add button
                        base.WaitForElement(By.Id(AddAssessmentPageResources.
                            AddAsessment_Page_LinkAsset_AddButton_Id_Locator));
                        base.ClickButtonById(AddAssessmentPageResources.
                            AddAsessment_Page_LinkAsset_AddButton_Id_Locator);
                        break;

                    case Activity.ActivityTypeEnum.RegMultipleFileAsset:
                        activityName = "Auto-" + date + "-" + randomValue + "-Non Gradable Multiple File Asset";
                        //Select Window
                        this.SelectCreateFileAssetWindow();
                        getGraderItWordFilePathFor70Percent = (AutomationConfigurationManager.PegasusPagesTestDataPath +
                            UploadCompletedFilesResource.UploadCompleteFile_Page_GraderIT_Word_File_70Percent_Path).
                        Replace("file:\\", "");
                        //Upload the xls File
                        base.UploadFile(getGraderItWordFilePathFor70Percent, By.Id("MultiPowUpload"));
                        //Enter Activity Title
                        this.EnterFileAssetTitle(activityName);
                        //Enter Description
                        this.SelectBookInEtextLinkAsset();
                        //Enter website URL
                        this.EnterURLInLinkAsset();
                        // Click add button
                        base.WaitForElement(By.Id(AddAssessmentPageResources.
                            AddAsessment_Page_LinkAsset_AddButton_Id_Locator));
                        base.ClickButtonById(AddAssessmentPageResources.
                            AddAsessment_Page_LinkAsset_AddButton_Id_Locator);
                        break;

                    //Create Activity Name for general activity
                    case Activity.ActivityTypeEnum.RegPageAsset:
                        activityName = "Auto-" + date + "-" + randomValue + "-Non Gradable Page Asset";
                        //Select Window
                        this.SelectCreatePageAssetWindow();
                        //Enter Activity Title
                        this.EnterPageAssetTitle(activityName);
                        //Enter Description
                        this.EnterPageAssetDescription();
                        //Fill The HTML Description
                        this.FillTheHTMLDescription(activityTypeEnum, 
                            newHTMLDiscription.ToString());
                        // Click add button
                        base.WaitForElement(By.Id(AddAssessmentPageResources.
                            AddAsessment_Page_PageAsset_AddButton_Id_Locator));
                        IWebElement getElement = base.GetWebElementPropertiesById(
                            AddAssessmentPageResources.
                            AddAsessment_Page_PageAsset_AddButton_Id_Locator);
                        base.PerformMouseClickAction(getElement);
                        //Click On Add And Close Button
                        new ContentBrowserUXPage().ClickOnAddAndCloseButton();
                        break;

                    case Activity.ActivityTypeEnum.RegDiscussionTopic:
                        activityName = "Auto-" + date + "-" + randomValue + "-Non Gradable Discussion Topic";
                        //Select Window
                        this.SelectCreateEtextLinkAssetWindow();
                        //this.SelectCreateLinkAssetWindow();
                        // Enter title in discussion topic
                        this.EnterDiscussionTopicTitle(activityName);
                        //Enter discussion topic description
                        this.EnterDiscussionTopicDescription();
                        //Fill The HTML Description
                        this.FillTheHTMLDescription(activityTypeEnum, newHTMLDiscription.ToString());
                        ////Click On Save And Close Button
                        base.WaitForElement(By.PartialLinkText(
                            AddAssessmentPageResources.
                            AddAsessment_Page_Close_DiscussionTopic_Popup_PartialLinkText_Locator));
                        base.ClickButtonByPartialLinkText(AddAssessmentPageResources.
                            AddAsessment_Page_Close_DiscussionTopic_Popup_PartialLinkText_Locator);
                        //Click On Add And Close Button
                        new ContentBrowserUXPage().ClickOnAddAndCloseButton();
                        //Swith To Add Materials Popup In Course Materials tab
                        new ContentLibraryUXPage().SwithToAddMaterialsPopupInCourseMaterials();
                        //Click on CLose button in Add Materials popup
                        this.CloseAddMaterialsPopupInCourseMaterials();
                        break;
                }
                //Store Gradable NonGradable Asset
                this.StoreGradableAsset(activityName, activityTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage",
                "EnterAssetDetails",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close the Add Materials Poupup
        /// </summary>
        private void CloseAddMaterialsPopupInCourseMaterials()
        {
            logger.LogMethodEntry("AddAssessmentPage",
                "CloseAddMaterialsPopupInCourseMaterials",
                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for Close button to load
            base.WaitForElement(By.XPath(AddAssessmentPageResources.
                            AddAsessment_Page_AddCourseMaterials_CloseButton_XPath_Locator));
            //Click on CLose button
            base.ClickButtonByXPath(AddAssessmentPageResources.
                            AddAsessment_Page_AddCourseMaterials_CloseButton_XPath_Locator);
            logger.LogMethodExit("AddAssessmentPage",
                    "CloseAddMaterialsPopupInCourseMaterials",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill The HTML Description.
        /// </summary>
        /// <param name="newHTMLDiscription">This is HTML Description.</param>
        private void FillTheHTMLDescription(Activity.ActivityTypeEnum activityTypeEnum, string newHTMLDiscription)
        {
            //Fill The HTML Description
            logger.LogMethodEntry("PegasusHTMLUXPage", "FillTheHTMLDescription",
                      base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Sourse_Id_Locator));
            // Click on ShowHTML button
            base.PerformFocusOnElementActionById(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Sourse_Id_Locator);
            IWebElement getHTMLSourceButton = base.GetWebElementPropertiesById
                (PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Sourse_Id_Locator);
            //Click the sourse link
            base.PerformClickAndHoldAction(getHTMLSourceButton);
            base.PerformDoubleClickAction(getHTMLSourceButton);
            switch(activityTypeEnum)
            {
                case Activity.ActivityTypeEnum.RegPageAsset:
                    //Wait For HTML Editor to load in Page asset create window
                    base.WaitForElement(By.Id(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_TextArea_Id_Locator));
                // Fill Description text in HTMLEditor textbox
                base.FillTextBoxById(PegasusHTMLUXPageResource.
                    PegasusHTMLUXPageResource_HTML_TextArea_Id_Locator,
                    newHTMLDiscription.ToString());
                break;

                case Activity.ActivityTypeEnum.RegDiscussionTopic:
                //Wait For HTML Editor to load in DiscussionTopic create window
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                            AddAsessment_Page_DiscussionTopic_HTML_Resource_ID_Locator));
                base.FillTextBoxById(AddAssessmentPageResources.
                            AddAsessment_Page_DiscussionTopic_HTML_Resource_ID_Locator,
                    newHTMLDiscription.ToString());
                break;
            }
            base.SwitchToDefaultPageContent();            
            logger.LogMethodExit("PegasusHTMLUXPage", "FillTheHTMLDescription",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store NonLicensed Activity
        /// </summary>
        /// <param name="activityTest">This is activity</param>
        private void StoreNonLicensedActivity(Guid activityTest)
        {
            //Store NonLicensed Activity
            logger.LogMethodEntry("AddAssessmentPage", "StoreNonLicensedActivity",
                  base.IsTakeScreenShotDuringEntryExit);
            //Store the activity in memory
            Activity newActivityTest = new Activity
            {
                ActivityId = CommonResource.CommonResource.DigitalPath_Activity_Test_UC3,
                Name = activityTest.ToString(),
                ActivityType = Activity.ActivityTypeEnum.Test,
                IsCreated = true,
            };
            newActivityTest.StoreActivityInMemory();
            logger.LogMethodExit("AddAssessmentPage", "StoreNonLicensedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Licensed Activity
        /// </summary>
        /// <param name="activityTest">This is activity</param>
        private void StoreLicensedActivity(Guid activityTest)
        {
            //Store Licensed Activity
            logger.LogMethodEntry("AddAssessmentPage", "StoreLicensedActivity",
                  base.IsTakeScreenShotDuringEntryExit);
            //Store the activity in memory
            Activity newActivityTest = new Activity
            {
                ActivityId = CommonResource.CommonResource.DigitalPath_Activity_Test_UC2,
                Name = activityTest.ToString(),
                ActivityType = Activity.ActivityTypeEnum.Test,
                IsCreated = true,
            };
            newActivityTest.StoreActivityInMemory();
            logger.LogMethodExit("AddAssessmentPage", "StoreLicensedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Add Questions 
        /// </summary>        
        public void SelectAddQuestion()
        {
            //Select Add Questions 
            logger.LogMethodEntry("AddAssessmentPage", "SelectAddQuestion",
                   base.IsTakeScreenShotDuringEntryExit);
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
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Create Question link
        /// </summary>
        private void ClickTheCreateQuestionLink()
        {
            //Click The Create Question link
            logger.LogMethodEntry("AddAssessmentPage", "ClickTheCreateQuestionLink",
                   base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
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
                        this.CreateSIM5SkillBehavioralModeActivity(activityName, behavioralModeEnum);
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
                   base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Create SIM5 Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode Enum.</param>
        public void CreateSIM5Activity(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateSIM5Activity",
                   base.IsTakeScreenShotDuringEntryExit);
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
                //Create SIM5 Skill Based Activity
                this.CreateSkillBasedActivity(activityName, behavioralModeEnum);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "CreateSIM5Activity",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create SIM5 Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode Enum.</param>
        public void CreatePreTest(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateSIM5Activity",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {

                //Switch to add myitlab study plan window
                base.WaitUntilWindowLoads("Add myitlab Study Plan");
                IWebElement preTest = base.GetWebElementPropertiesByXPath(
                    AddAssessmentPageResources.
                AddAsessment_Page_OpenPreTestCreation_XPath_Locator);
                base.ClickByJavaScriptExecutor(preTest);
                //Switch to last open Window
                base.SwitchToLastOpenedWindow();
                //Wait for Add and Close button
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAsessment_Page_SAveCopyAddandClose_ID_Locator));
                //Get Property of Add and Close button
                IWebElement GetAddAndCloseButton = base.GetWebElementPropertiesById(AddAssessmentPageResources.
                AddAsessment_Page_SAveCopyAddandClose_ID_Locator);
                //Click on Add and Close button
                base.ClickByJavaScriptExecutor(GetAddAndCloseButton);
                //Generate Random Number
                string randomNumber = base.GetRandomNumber(AddAssessmentPageResources.
                    AddAsessment_Page_RandomNumber_Character,
                    Convert.ToInt32(AddAssessmentPageResources.
                    AddAsessment_Page_RandomNumber_Length));
                //Generate GUID for Activity Name
                Guid activity = Guid.NewGuid();
                string activityName = activity.ToString();
                //Stor Activity Name
                this.StoreActivityDetails(activityTypeEnum, behavioralModeEnum, activityName);
                //Create SIM5 Skill Based Activity
                this.CreateSkillBasedPreTest(activityName, behavioralModeEnum);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "CreateSIM5Activity",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create SIM5 Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode Enum.</param>
        public void CreatePostTest(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateSIM5Activity",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement postTest = base.GetWebElementPropertiesByXPath(AddAssessmentPageResources.
                AddAsessment_Page_OpenPostTestCeationPage_XPath_Locator);
                base.ClickByJavaScriptExecutor(postTest);
                //Generate Random Number
                string randomNumber = base.GetRandomNumber(AddAssessmentPageResources.
                    AddAsessment_Page_RandomNumber_Character,
                    Convert.ToInt32(AddAssessmentPageResources.
                    AddAsessment_Page_RandomNumber_Length));
                //Generate GUID for Activity Name
                Guid activity = Guid.NewGuid();
                string activityName = activity.ToString();
                //Stor Activity Name
                this.StoreActivityDetails(activityTypeEnum, behavioralModeEnum, activityName);
                //Create SIM5 Skill Based Post TEst
                this.CreateSkillBasedPostTest(activityName, behavioralModeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "CreateSIM5Activity",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create SIM5 Skill Behavioral Mode Activity
        /// </summary>
        /// <param name="activityName">This is activityName</param>
        private void CreateSIM5SkillBehavioralModeActivity(string activityName,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            logger.LogMethodEntry("AddAssessmentPage", "CreateSIM5SkillBehavioralModeActivity",
                  base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Create SIM5 SkillBased Activity
        /// </summary>
        /// <param name="activityName">This is activityName</param>
        private void CreateSIM5SkillBasedActivity(string activityName,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            logger.LogMethodEntry("AddAssessmentPage", "CreateSIM5SkillBasedActivity",
                  base.IsTakeScreenShotDuringEntryExit);

            //Create Skill Based SIM5 Activity
            this.CreateSkillBasedActivity(activityName, behavioralModeEnum);

            logger.LogMethodExit("AddAssessmentPage", "CreateSIM5SkillBasedActivity",
                   base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);
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
            this.SelectCreateRandomActivity();
            //Click On Add Question Link
            new RandomTopicListPage().ClickOnAddQuestionLink();
            logger.LogMethodExit("AddAssessmentPage",
                "CreateTheActivityUsingBehavioralModeType",
                   base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Create the SkillBasedActivity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode.</param>
        private void CreateSkillBasedActivity(string activityName,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create The Activity Using Behavioral ModeType.
            logger.LogMethodEntry("AddAssessmentPage",
                "CreateSkillBasedActivity",
                  base.IsTakeScreenShotDuringEntryExit);
            //Select Create Activity Window
            this.SelectCreateActivityWindow();
            //Fill Asset name
            this.FillAssetName(activityName);
            //Click On Save And Continue Button
            this.ClickOnSaveAndContinueButton();
            //Click On Add Question Link
            new RandomTopicListPage().ClickOnAddQuestionLink();
            logger.LogMethodExit("AddAssessmentPage",
                "CreateSkillBasedActivity",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create the SkillBasedActivity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode.</param>
        public void CreateSkillBasedPreTest(string activityName,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create The Activity Using Behavioral ModeType.
            logger.LogMethodEntry("AddAssessmentPage",
                "CreateSkillBasedActivity",
                  base.IsTakeScreenShotDuringEntryExit);
            //Select Create Activity Window
            base.SwitchToDefaultWindow();
            base.WaitUntilWindowLoads("Create Pre-test:");
            bool dsd = base.IsElementPresent(By.Id("txtAssname"), 5);
            //Fill Asset name
            this.FillAssetName(activityName);
            //Click On Save And Continue Button
            this.ClickOnSaveAndContinueButton();
            //Click On Add Question Link
            new RandomTopicListPage().ClickOnAddQuestionLink();
            logger.LogMethodExit("AddAssessmentPage",
                "CreateSkillBasedActivity",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create the SkillBasedActivity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="behavioralModeEnum">This is Behavioral Mode.</param>
        public void CreateSkillBasedPostTest(string activityName,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum)
        {
            //Create The Activity Using Behavioral ModeType.
            logger.LogMethodEntry("AddAssessmentPage",
                "CreateSkillBasedActivity",
                  base.IsTakeScreenShotDuringEntryExit);
            this.FillAssetName(activityName);
            //Click On Save And Continue Button
            this.ClickOnSaveAndContinueButton();
            //Click On Add Question Link
            new RandomTopicListPage().ClickOnAddQuestionLink();
            logger.LogMethodExit("AddAssessmentPage",
                "CreateSkillBasedActivity",
                   base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Activity Window.
        /// </summary>
        private void SelectCreateActivityWindow()
        {
            //Select Create Activity Window
            logger.LogMethodEntry("AddAssessmentPage", "SelectCreateActivityWindow",
                   base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(AddAssessmentPageResources.
                AddAsessment_Page_Createactivity_Window_Name);
            //Select Create Activity Window
            base.SelectWindow(AddAssessmentPageResources.
                AddAsessment_Page_Createactivity_Window_Name);
            logger.LogMethodExit("AddAssessmentPage", "SelectCreateActivityWindow",
                   base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select Create Activity Window.
        /// </summary>
        private void SelectCreateLinkAssetWindow()
        {
            //Select Create Activity Window
            logger.LogMethodEntry("AddAssessmentPage", "SelectCreateAssetWindow",
                   base.IsTakeScreenShotDuringEntryExit);
            // Select window    
            base.SelectWindow(base.GetPageTitle);
            base.SwitchToDefaultWindow();
            // Switch to iFrame 
            base.SwitchToIFrameById(AddAssessmentPageResources.
                AddAssessment_Page_AssetCreation_IFrame_Id_Locator);
            logger.LogMethodExit("AddAssessmentPage", "SelectCreateAssetWindow",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create New Folder Window.
        /// </summary>
        private void SelectCreateNewFolderWindow()
        {
            //Select Create Activity Window
            logger.LogMethodEntry("AddAssessmentPage", "SelectCreateNewFolderWindow",
                   base.IsTakeScreenShotDuringEntryExit);
            // Select window    
            base.SelectWindow(base.GetPageTitle);
            base.SwitchToDefaultWindow();
            // Switch to iFrame 
            base.SwitchToIFrameById(AddAssessmentPageResources.
                AddAssessment_Page_AssetCreation_IFrame_Id_Locator);
            logger.LogMethodExit("AddAssessmentPage", "SelectCreateNewFolderWindow",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Activity Window.
        /// </summary>
        private void SelectCreatePageAssetWindow()
        {
            //Select Create Activity Window
            logger.LogMethodEntry("AddAssessmentPage", "SelectCreateAssetWindow",
                   base.IsTakeScreenShotDuringEntryExit);
            // Select window    
            base.SelectWindow(base.GetPageTitle);
            logger.LogMethodExit("AddAssessmentPage", "SelectCreateAssetWindow",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Activity Window.
        /// </summary>
        private void SelectCreateEtextLinkAssetWindow()
        {
            //Select Create Activity Window
            logger.LogMethodEntry("AddAssessmentPage", "SelectCreateAssetWindow",
                   base.IsTakeScreenShotDuringEntryExit);
            // Select window    
            base.SelectWindow(base.GetPageTitle);
            base.SwitchToDefaultWindow();
            // Switch to iFrame 
            base.SwitchToIFrameById(AddAssessmentPageResources.
                AddAssessment_Page_EtextLinkAssetCreation_IFrame_Id_Locator);
            logger.LogMethodExit("AddAssessmentPage", "SelectCreateAssetWindow",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Activity Window.
        /// </summary>
        private void SelectCreateFileAssetWindow()
        {
            //Select Create Activity Window
            logger.LogMethodEntry("AddAssessmentPage", "SelectCreateAssetWindow",
                   base.IsTakeScreenShotDuringEntryExit);
            // Select window    
            base.SelectWindow(base.GetPageTitle);
            base.SwitchToDefaultWindow();
            // Switch to iFrame 
            base.SwitchToIFrameById(AddAssessmentPageResources.
                AddAssessment_Page_AssetCreation_IFrame_Id_Locator);
            logger.LogMethodExit("AddAssessmentPage", "SelectCreateAssetWindow",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Activity Window.
        /// </summary>
        private void SelectCreateAddMultipleFileAssetWindow()
        {
            //Select Create Activity Window
            logger.LogMethodEntry("AddAssessmentPage", "SelectCreateAssetWindow",
                   base.IsTakeScreenShotDuringEntryExit);
            // Select window    
            base.SelectWindow(base.GetPageTitle);
            base.SwitchToDefaultWindow();
            // Switch to iFrame 
            base.SwitchToIFrameById(AddAssessmentPageResources.
                AddAssessment_Page_AssetCreation_IFrame_Id_Locator);
            logger.LogMethodExit("AddAssessmentPage", "SelectCreateAssetWindow",
                   base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Fill Asset Name
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        private void FillAssetName(String assetName)
        {
            //Fill Asset Name
            logger.LogMethodEntry("AddAssessmentPage", "FillAssetName",
                   base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                     AddAsessment_Page_ActivityName_Id_Locator));
            //Fill the Activity Name in textbox
            base.FillTextBoxById(AddAssessmentPageResources.
                AddAsessment_Page_ActivityName_Id_Locator, assetName);
            logger.LogMethodExit("AddAssessmentPage", "FillAssetName",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Skill Based Behavioral Mode.
        /// </summary>
        private void SelectSkillBasedBehavioralMode()
        {
            //Select Skill Based Behavioral Mode
            logger.LogMethodEntry("AddAssessmentPage", "SelectSkillBasedBehavioralMode",
                   base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAsessment_Page_SkillBased_RadioButton_Id_Locator));
            //Get Skill Based Radio Button Property
            IWebElement getSkillRadioButtonProperty = base.GetWebElementPropertiesById(
                AddAssessmentPageResources.AddAsessment_Page_SkillBased_RadioButton_Id_Locator);
            //Click On Skill Based Radio Button
            base.ClickByJavaScriptExecutor(getSkillRadioButtonProperty);
            logger.LogMethodExit("AddAssessmentPage", "SelectSkillBasedBehavioralMode",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Doc Based Behavioral Mode.
        /// </summary>
        private void SelectDocBasedBehavioralMode()
        {
            //Select Doc Based Behavioral Mode
            logger.LogMethodEntry("AddAssessmentPage", "SelectDocBasedBehavioralMode",
                   base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAssement_Page_Select_DocBased_Mode_Id_Locator));
            //Get Doc Based Radio Button Property
            IWebElement getDocRadioButtonProperty = base.GetWebElementPropertiesById(
                AddAssessmentPageResources.AddAssement_Page_Select_DocBased_Mode_Id_Locator);
            //Click On Doc Based Radio Button
            base.ClickByJavaScriptExecutor(getDocRadioButtonProperty);
            logger.LogMethodExit("AddAssessmentPage", "SelectDocBasedBehavioralMode",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create 'Assignment' Behavioral Mode Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void CreateAssignmentBehavioralModeActivity(String activityName)
        {
            //Create Assignment Behoiral Mode Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateAssignmentBehavioralModeActivity",
                 base.IsTakeScreenShotDuringEntryExit);
            //Select Create Activity Window
            this.SelectCreateActivityWindow();
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                     AddAsessment_Page_ActivityName_Id_Locator));
            //Fill the Activity Name in textbox
            base.FillTextBoxById(AddAssessmentPageResources.
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
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Assignment Activity Window.
        /// </summary>
        private void SelectCreateAssignmentActivityWindow()
        {
            //Select Create Assignment Activity Window
            logger.LogMethodEntry("AddAssessmentPage", "SelectCreateAssignmentActivityWindow",
                 base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(AddAssessmentPageResources.
                 AddAsessment_Page_CreateAssignmentactivity_Window_Name);
            //Select Create Assignemt Activity Window
            base.SelectWindow(AddAssessmentPageResources.
                AddAsessment_Page_CreateAssignmentactivity_Window_Name);
            logger.LogMethodExit("AddAssessmentPage", "SelectCreateAssignmentActivityWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Basic Random Behavioral Mode Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void CreateBasicRandomBehavioralModeActivity(String activityName)
        {
            //Create Basic Random Behavoiral Mode Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateBasicRandomBehavioralModeActivity",
                 base.IsTakeScreenShotDuringEntryExit);
            //Select Create Activity Window
            this.SelectCreateActivityWindow();
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                     AddAsessment_Page_ActivityName_Id_Locator));
            //Fill the Activity Name in textbox
            base.FillTextBoxById(AddAssessmentPageResources.
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
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Activity Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterActivityTitle(string activityTitle)
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                             AddAsessment_Page_ActivityName_Id_Locator));
                //Fill the Activity Name in textbox
                base.FillTextBoxById(AddAssessmentPageResources.
                    AddAsessment_Page_ActivityName_Id_Locator, activityTitle.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter Activity Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterLinkAssetTitle(string activityTitle)
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                             AddAsessment_Page_AssetName_Id_Locator));
                //Fill the Activity Name in textbox
                base.FillTextBoxById(AddAssessmentPageResources.
                             AddAsessment_Page_AssetName_Id_Locator, activityTitle.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Folder Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterFolderTitle(string activityTitle)
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                             AddAsessment_Page_FolderName_Id_Locator));
                //Fill the Activity Name in textbox
                base.FillTextBoxById(AddAssessmentPageResources.
                             AddAsessment_Page_FolderName_Id_Locator, activityTitle.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Activity Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterDicsussionTopicDescription(string activityTitle)
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterDicsussionTopicDescription",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                             AddAssessment_Page_DiscussionTopic_Description_TextBox_ClassName));
                //Fill the Activity Name in textbox
                base.FillTextBoxById(AddAssessmentPageResources.
                             AddAssessment_Page_DiscussionTopic_Description_TextBox_ClassName,
                             activityTitle.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterDicsussionTopicDescription",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Activity Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterDiscussionTopicTitle(string activityTitle)
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAssessment_Page_DiscussionTopic_Title_TextBox_Id_Locator));
                //Fill the Activity Name in textbox
                base.FillTextBoxById(AddAssessmentPageResources.
                    AddAssessment_Page_DiscussionTopic_Title_TextBox_Id_Locator,
                    activityTitle.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter Activity Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterEtextLinkAssetTitle(string activityTitle)
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                             AddAssessment_Page_EtextLinkAsset_Title_TextBox_Id_Locator));
                //Fill the Activity Name in textbox
                base.FillTextBoxById(AddAssessmentPageResources.
                             AddAssessment_Page_EtextLinkAsset_Title_TextBox_Id_Locator, activityTitle.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Activity Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterFileAssetTitle(string activityTitle)
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                             AddAssessment_Page_FileAsset_Title_TextBox_Id_Locator));
                //Fill the Activity Name in textbox
                base.FillTextBoxById(AddAssessmentPageResources.
                             AddAssessment_Page_FileAsset_Title_TextBox_Id_Locator, activityTitle.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Activity Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterPageAssetTitle(string activityTitle)
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                             AddAssessment_Page_PageAsset_Title_TextBox_Id_Locator));
                //Fill the Activity Name in textbox
                base.FillTextBoxById(AddAssessmentPageResources.
                             AddAssessment_Page_PageAsset_Title_TextBox_Id_Locator, activityTitle.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Activity Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterLinkAssetDescription()
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
            //Generate Activity description
            String date = DateTime.Now.ToString("yyyy/MM/dd");
            string activityDescription = string.Empty;
            activityDescription = "Auto-" + "Activity description entered on " + "-" + date;
            try
            {
                base.ClearTextByClassName(AddAssessmentPageResources.
                    AddAssessment_Page_LinkAsset_Description_TextBox_ClassName);
                //Fill the Activity Name in textbox
                base.FillTextBoxByClassName(AddAssessmentPageResources.
                    AddAssessment_Page_LinkAsset_Description_TextBox_ClassName, activityDescription);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Folder Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterFolderDescription()
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterFolderDescription",
                   base.IsTakeScreenShotDuringEntryExit);
            //Generate Activity description
            String date = DateTime.Now.ToString("yyyy/MM/dd");
            string activityDescription = string.Empty;
            activityDescription = "Auto-" + "Folder description entered on " + "-" + date;
            try
            {
                base.ClearTextByClassName(AddAssessmentPageResources.
                    AddAssessment_Page_LinkAsset_Description_TextBox_ClassName);
                //Fill the Activity Name in textbox
                base.FillTextBoxByClassName(AddAssessmentPageResources.
                    AddAssessment_Page_LinkAsset_Description_TextBox_ClassName, activityDescription);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterFolderDescription",
                   base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter Activity Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterPageAssetDescription()
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
            //Generate Activity description
            String date = DateTime.Now.ToString("yyyy/MM/dd");
            string activityDescription = string.Empty;
            activityDescription = "Auto-" + "Activity description entered on " + "-" + date;
            try
            {

                base.ClearTextById(AddAssessmentPageResources.
                    AddAssessment_Page_PageAsset_Description_TextBox_Id_Locator);
                //Fill the Activity Name in textbox
                base.FillTextBoxById(AddAssessmentPageResources.
                    AddAssessment_Page_PageAsset_Description_TextBox_Id_Locator, activityDescription);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Activity Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void EnterDiscussionTopicDescription()
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
            //Generate Activity description
            String date = DateTime.Now.ToString("yyyy/MM/dd");
            string activityDescription = string.Empty;
            activityDescription = "Auto-" + "Discussion Topic description entered on " + "-" + date;
            try
            {
                bool dfgd = base.IsElementPresent(By.ClassName("cssDiscussionTextArea"), 10);
                //base.ClearTextByClassName(AddAssessmentPageResources.
                //    AddAssessment_Page_DiscussionTopic_Description_TextBox_ClassName);

                base.ClearTextByClassName("cssDiscussionTextArea");
                //Fill the Activity Name in textbox
                base.FillTextBoxByClassName("cssDiscussionTextArea",
                    activityDescription);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Activity Title.
        /// </summary>  
        /// <param name="activityTitle">This is Activity Title GUID.</param>
        public void SelectBookInEtextLinkAsset()
        {
            //Enter Activity Title
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAssessment_Page_EtextLinkAsset_SelectBook_Id_Locator));
                base.SelectDropDownValueThroughIndexById(AddAssessmentPageResources.
                    AddAssessment_Page_EtextLinkAsset_SelectBook_Id_Locator, 1);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterActivityTitle",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Select From Course Materials Library link.
        /// </summary>
        private void EnterURLInLinkAsset()
        {
            logger.LogMethodEntry("AddAssessmentPage", "ClickTheAddLinkToWebsiteLink",
                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element             
            base.WaitForElement(By.Id(AddAssessmentPageResources.
               AddAssessment_Page_LinkAsset_URL_TextBox_Id_Locator));
            base.ClearTextById(AddAssessmentPageResources.
               AddAssessment_Page_LinkAsset_URL_TextBox_Id_Locator);

            switch (Environment.GetEnvironmentVariable(AddAssessmentPageResources.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AddAssessmentPageResources.TestEnvironment_Key].ToUpper())
            {
                case "PPE":
                    base.FillTextBoxById(AddAssessmentPageResources.
                        AddAssessment_Page_LinkAsset_URL_TextBox_Id_Locator, AddAssessmentPageResources.
                        AddAsessment_Page_LinkAsset_URL_VCD);
                    break;
                case "CGIE":
                case "VCD":
                    base.FillTextBoxById(AddAssessmentPageResources.
                        AddAssessment_Page_LinkAsset_URL_TextBox_Id_Locator, AddAssessmentPageResources.
                        AddAsessment_Page_LinkAsset_URL_VCD);
                    break;
                case "PROD":
                    base.FillTextBoxById(AddAssessmentPageResources.
                        AddAssessment_Page_LinkAsset_URL_TextBox_Id_Locator, AddAssessmentPageResources.
                        AddAsessment_Page_LinkAsset_URL_VCD);
                    break;
            }
            logger.LogMethodExit("AddAssessmentPage", "ClickTheAddLinkToWebsiteLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click On SaveAndContinue Button.
        /// </summary>
        public void ClickOnSaveAndContinueButton()
        {
            //Click On SaveAndContinue Button
            logger.LogMethodEntry("RandomTopicListPage", "ClickOnSaveAndContinueButton",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SelectRadioButtonById("radSkill");
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                        AddAsessment_Page_SaveAndContinue_Button_Id_Locator));
                base.FocusOnElementById(AddAssessmentPageResources.
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Assignment Radio Button.
        /// </summary>
        private void SelectAssignmentRadioButton()
        {
            //Click the Assignment Radio button
            logger.LogMethodEntry("AddAssessmentPage", "SelectAssignmentRadioButton",
                 base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAsessment_Page_BehavioralMode_Assignment_RadioButton_Id_Locator));
            //Click the Radio button
            base.SelectRadioButtonById(AddAssessmentPageResources.
                AddAsessment_Page_BehavioralMode_Assignment_RadioButton_Id_Locator);
            logger.LogMethodExit("AddAssessmentPage", "SelectAssignmentRadioButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Activity Details.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behvioralModeTypeEnum">This is Behavioral Mode Enum.</param>
        /// <param name="activityName">This is Activity Name.</param>
        public void StoreActivityDetails(Activity.ActivityTypeEnum activityTypeEnum,
            Activity.ActivityBehavioralModesEnum behavioralModeEnum, String activityName)
        {
            logger.LogMethodEntry("AddAssessmentPage", "StoreActivityDetails",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Store the activity in memory
                Activity newActivityTest = new Activity
                {
                    Name = activityName,
                    ActivityType = activityTypeEnum,
                    ActivityBehavioralMode = behavioralModeEnum,
                    IsCreated = true,
                };
                newActivityTest.StoreActivityInMemory();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "StoreActivityDetails",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create PreTest Activity.
        /// </summary>
        public void CreatePreTestActivity()
        {
            //Create PreTest Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreatePreTestActivity",
                  base.IsTakeScreenShotDuringEntryExit);
            //Generate Activity Name GUID
            Guid activityName = Guid.NewGuid();
            try
            {
                //Select Pretest Window
                this.SelectPretestWindow();
                //Enter Activity Title
                this.EnterActivityTitle(activityName.ToString());
                //Store PreTest Details
                this.StoreGradableAsset(activityName.ToString(), Activity.ActivityTypeEnum.PreTest);
                //Click On Save and Continue Button
                this.ClickOnSaveAndContinueButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "CreatePreTestActivity",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Pretest Window.
        /// </summary>
        public void SelectPretestWindow()
        {
            //Select Pretest Window
            logger.LogMethodEntry("AddAssessmentPage", "SelectPretestWindow",
                  base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generate Activity Name GUID
                Guid activity = Guid.NewGuid();
                String date = DateTime.Now.ToString("yyyy/MM/dd");
                string randomValue = activity.ToString().Split('-')[0];
                string activityName = "Auto-" + date + "-" + randomValue + "-Activity";

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
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Random Activity.
        /// </summary>
        public void SelectCreateRandomActivity()
        {
            //Select Create Random Activity
            logger.LogMethodEntry("AddAssessmentPage",
                "SelectCreateRandomActivity",
                  base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Activity Details.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="activityTypeEnum">This is Activity Type.</param>
        private void StoreGradableAsset(string activityName,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Store Activity Details
            logger.LogMethodEntry("AddAssessmentPage",
                "StoreGradableAsset",
                  base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Create Sim GraderIT Activity
                Guid activityName = Guid.NewGuid();
                //Select Window
                this.SelectCreateActivityWindow();
                //Enter Activity Title
                this.EnterActivityTitle(activityName.ToString());
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
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Grader Checkbox.
        /// </summary>
        private void SelectGraderCheckbox()
        {
            //Select Grader Checkbox
            logger.LogMethodEntry("AddAssessmentPage",
                "SelectGraderCheckbox",
                  base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On SaveAndReturn Button.
        /// </summary>
        public void ClickOnSaveAndReturnButton()
        {
            //Click On SaveAndReturn Button.
            logger.LogMethodEntry("AddAssessmentPage",
              "ClickOnSaveAndReturnButton",
                base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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

            logger.LogMethodExit("AddAssessmentPage", "CreateSIMActivity",
                   base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Message.
        /// </summary>
        public void EnterActivityMessage()
        {
            //Enter The Message
            logger.LogMethodEntry("AddAssessmentPage", "EnterActivityMessage",
                base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Message Save Close Button
        /// </summary>
        private void MessageSaveCloseButton()
        {
            //Enter The Message
            logger.LogMethodEntry("AddAssessmentPage", "MessageSaveCloseButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAssement_Page_ActivityMessagae_SaveButton_Id_Locator));
            IWebElement getSaveButton = base.GetWebElementPropertiesById
                (AddAssessmentPageResources.
                AddAssement_Page_ActivityMessagae_SaveButton_Id_Locator);
            base.ClickByJavaScriptExecutor(getSaveButton);
            logger.LogMethodExit("AddAssessmentPage", "MessageSaveCloseButton",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Start and End Message.
        /// </summary>
        public void EnterStartandEndMessage()
        {
            //Enter Start and End Message
            logger.LogMethodEntry("AddAssessmentPage", "EnterStartandEndMessage",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the begining text element
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAssement_Page_Begin_Message_Id_Locator));
                //Fill the Begin message in textbox
                base.FillTextBoxById(AddAssessmentPageResources.
                    AddAssement_Page_Begin_Message_Id_Locator,
                    AddAssessmentPageResources.AddAssement_Page_Begin_Message);
                //Wait for the end text element
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAssement_Page_End_Message_Id_Locator));
                //Fill the Activity Name in textbox
                base.FillTextBoxById(AddAssessmentPageResources.
                    AddAssement_Page_End_Message_Id_Locator,
                    AddAssessmentPageResources.AddAssement_Page_End_Message);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "EnterStartandEndMessage",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Activity Message SubTab.
        /// </summary>
        private void ClickTheActivityMessageSubTab()
        {
            //Click The Activity Message SubTab
            logger.LogMethodEntry("AddAssessmentPage",
                "ClickTheActivityMessageSubTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Create Random Activity
            this.SelectCreateRandomActivity();
            //Click on Message Tab
            this.ClickonMessageTab();
            logger.LogMethodExit("AddAssessmentPage",
                "ClickTheActivityMessageSubTab",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Message Tab.
        /// </summary>
        public void ClickonMessageTab()
        {
            //Click on Message Tab
            logger.LogMethodEntry("AddAssessmentPage", "ClickonMessageTab",
                base.IsTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("AddAssessmentPage", "ClickonMessageTab",
                    base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Message For Activity.
        /// </summary>
        public void EnterTheMessageForActivity()
        {
            //Enter The Message For Activity
            logger.LogMethodEntry("AddAssessmentPage",
                "EnterTheMessageForActivity",
                base.IsTakeScreenShotDuringEntryExit);
            SkillBasedAssessmentPage skillBasedAssessmentPage =
                new SkillBasedAssessmentPage();
            //Select the Create Random Activity window
            this.SelectCreateRandomActivity();
            //enter the message
            this.EnterActivityMessage();
            logger.LogMethodExit("AddAssessmentPage",
                 "EnterTheMessageForActivity",
                     base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter Assignment Activity Details and Click Save and Continue button.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type.</param>
        public void EnterAssignmentActivityDetailsandClickSaveandContinue()
        {
            //Enter Activity Details and Click on Add Question
            logger.LogMethodEntry("AddAssessmentPage",
                "EnterAssignmentActivityDetailsandClickSaveandContinue",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generate Activity Name GUID
                Guid activityName = Guid.NewGuid();
                //Select Window
                this.SelectCreateActivityWindow();
                //Enter Activity Title
                this.EnterActivityTitle(activityName.ToString());
                //Click The Basic Random Radio Button
                this.SelectAssignmentRadioButton();
                //Click On Save and Continue Button
                this.ClickOnSaveAndContinueButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage",
                "EnterAssignmentActivityDetailsandClickSaveandContinue",
                   base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// return Beginning of Activity Default Message Text.
        /// </summary>
        /// <returns>string</returns>
        public string returnBeginningofActivityDefaultMessageText()
        {
            logger.LogMethodEntry("AddAssessmentPage",
                "returnBeginningofActivityDefaultMessageText",
               base.IsTakeScreenShotDuringEntryExit);
            //Gets Beginning of Activity Default Message Span
            IWebElement BeginActivityDefaultMessage = base.GetWebElementPropertiesById(
                AddAssessmentPageResources.AddAssessment_Page_BeginActivityDefaultMessage_Id_Locator);

            logger.LogMethodExit("AddAssessmentPage",
                "returnBeginningofActivityDefaultMessageText",
                base.IsTakeScreenShotDuringEntryExit);
            return BeginActivityDefaultMessage.Text;
        }
        /// <summary>
        /// return Beginning of Activity Instructor Message Text.
        /// </summary>
        /// <returns>string</returns>
        public string returnBeginningofActivityInstructorMessageText()
        {
            logger.LogMethodEntry("AddAssessmentPage",
                "returnBeginningofActivityInstructorMessageText",
               base.IsTakeScreenShotDuringEntryExit);
            //Gets Beginning of Activity Instructor Message Text Box
            IWebElement BeginActivityInstructorMessage = base.GetWebElementPropertiesById(
                AddAssessmentPageResources.AddAssessment_Page_BeginActivityInstructorMessage_Id_Locator);

            logger.LogMethodExit("AddAssessmentPage",
                "returnBeginningofActivityInstructorMessageText",
                base.IsTakeScreenShotDuringEntryExit);
            return BeginActivityInstructorMessage.Text;
        }
        /// <summary>
        /// return End of Activity Default Message Text.
        /// </summary>
        /// <returns>string</returns>
        public string returnEndofActivityDefaultMessageText()
        {
            logger.LogMethodEntry("AddAssessmentPage",
                "returnEndofActivityDefaultMessageText",
               base.IsTakeScreenShotDuringEntryExit);
            //Gets End of Activity Default Message Span
            IWebElement EndActivityDefaultMessage = base.GetWebElementPropertiesById(
                AddAssessmentPageResources.AddAssessment_Page_EndActivityDefaultMessage_Id_Locator);

            logger.LogMethodExit("AddAssessmentPage",
                "returnEndofActivityDefaultMessageText",
                base.IsTakeScreenShotDuringEntryExit);
            return EndActivityDefaultMessage.Text;
        }
        /// <summary>
        /// return End of Activity Instructor Message Text.
        /// </summary>
        /// <returns>string</returns>
        public string returnEndofActivityInstructorMessageText()
        {
            logger.LogMethodEntry("AddAssessmentPage",
                "returnEndofActivityInstructorMessageText",
               base.IsTakeScreenShotDuringEntryExit);
            //Get End of Activity Instructor Message Text Box
            IWebElement EndActivityInstructorMessage = base.GetWebElementPropertiesById(
                AddAssessmentPageResources.AddAssessment_Page_EndActivityInstructorMessage_Id_Locator);

            logger.LogMethodExit("AddAssessmentPage",
                "returnEndofActivityInstructorMessageText",
                base.IsTakeScreenShotDuringEntryExit);
            return EndActivityInstructorMessage.Text;
        }
        /// <summary>
        /// Create the Activity With HelpLinks.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        public void CreateActivityWithHelpLinks(Activity.ActivityTypeEnum
            activityTypeEnum)
        {
            //Create The Instructor Gradable Activity
            logger.LogMethodEntry("AddAssessmentPage", "CreateActivityWithHelpLinks",
                base.IsTakeScreenShotDuringEntryExit);
            SkillBasedAssessmentPage skillBasedAssessmentPage =
                new SkillBasedAssessmentPage();
            try
            {
                //Select the Question Type
                this.ClickTheCreateQuestionLink();
                //Select Question Type
                new SelectQuestionTypePage().ClickTheTrueFalseQuestionType();
                //Create True/False Question
                new TrueFalsePage().CreateTrueFalseQuestion();
                //Click on the HelpLinks tab
                this.ClickOnHelpLinksTab();
                //Click on the Add Links link
                new RandomTopicListPage().ClickOnAddLinksLink();
                //Open the Add Help Links popup
                this.ClickTheSelectFromCourseMaterialsLibraryLink();
                //Save Help Link
                this.SaveHelpLink();
                //Preview the added Help Link
                this.PreviewHelpLink();
                //Select Create Activity window
                base.SelectWindow(AddAssessmentPageResources.AddAsessment_Page_CreateRandomActivity_Window_Name);
                //Wait for Save and Return button on page
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                                    AddAssessment_Page_ActivityHelpLinksSaveAndReturn_Id_Locator));
                IWebElement getSaveButton = base.GetWebElementPropertiesById
                    (AddAssessmentPageResources.
                                    AddAssessment_Page_ActivityHelpLinksSaveAndReturn_Id_Locator);
                //Click Save and Return button to save the activity
                base.ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "CreateActivityWithHelpLinks",
                    base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        ///Click On HelpLinks Tab.
        /// </summary>
        public void ClickOnHelpLinksTab()
        {
            //Click On SaveAndContinue Button
            logger.LogMethodEntry("AddAssessmentPage", "ClickOnHelpLinksTab",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Help Links tab
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                        AddAssessment_Page_HelpLinks_Tab_Id_Locator));
                //Focus control on the Help Links tab
                base.FocusOnElementById(AddAssessmentPageResources.
                    AddAssessment_Page_HelpLinks_Tab_Id_Locator);
                //Get Save And Continue Button Property
                IWebElement getbuttonProperty = base.GetWebElementPropertiesById(
                    AddAssessmentPageResources.
                    AddAssessment_Page_HelpLinks_Tab_Id_Locator);
                //Click On Save And Continue Button
                base.ClickByJavaScriptExecutor(getbuttonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "ClickOnHelpLinksTab",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click on Select From Course Materials Library link.
        /// </summary>
        private void ClickTheSelectFromCourseMaterialsLibraryLink()
        {
            logger.LogMethodEntry("AddAssessmentPage", "ClickTheAddLinkToWebsiteLink",
                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element             
            base.WaitForElement(By.XPath(AddAssessmentPageResources.
               AddAssessment_Page_SelectFromCourseMaterialsLibrary_XPath_Locator));
            //Get web element
            IWebElement getCreateQuesLinkProperty = base.GetWebElementPropertiesByXPath
                (AddAssessmentPageResources.
               AddAssessment_Page_SelectFromCourseMaterialsLibrary_XPath_Locator);
            //Click the "Add Link to Website" link
            base.ClickByJavaScriptExecutor(getCreateQuesLinkProperty);
            logger.LogMethodExit("AddAssessmentPage", "ClickTheAddLinkToWebsiteLink",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter Name, URL and save the HelpLink.
        /// </summary>
        public void SaveHelpLink()
        {
            //Create The Instructor Gradable Activity
            logger.LogMethodEntry("AddAssessmentPage", "SaveHelpLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Add Link popup to load  
                base.WaitUntilWindowLoads(AddAssessmentPageResources.AddAssessment_Page_SelectContentPopup_Title_Loactor);
                //Select the Add Link popup
                base.SelectWindow(AddAssessmentPageResources.AddAssessment_Page_SelectContentPopup_Title_Loactor);

                //Wait for web element
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAssessment_Page_HelpLinkAssetsIFrame_Id_Locator));
                //Select the iFrame
                base.SwitchToIFrame(AddAssessmentPageResources.
                    AddAssessment_Page_HelpLinkAssetsIFrame_Id_Locator);

                // Click on "Instructor's Resources" folder
                base.ClickLinkByPartialLinkText("Instructor's Resources");

                Thread.Sleep(2000);

                //Gets the collection of all Help Link assets
                ICollection<IWebElement> getAllHelpLinkAssets = base.GetWebElementsCollectionById(
                    AddAssessmentPageResources.AddAssessment_Page_HelpLinkAssets_CheckBox_Id_Locator);

                //Check the first enabled checkbox for a Help Link asset to add it to HelpLinks grid in Activity
                foreach (IWebElement helpLinkAsset in getAllHelpLinkAssets)
                {
                    if (helpLinkAsset.Enabled)
                        helpLinkAsset.Click();
                    break;
                }
                //Select the Add Link popup
                base.SwitchToDefaultPageContent();
                //Wait for the element
                base.WaitForElement(By.PartialLinkText(AddAssessmentPageResources.
                    AddAssessment_Page_HelpLinkAddAndClose_PartialText_Locator));
                IWebElement getSaveButton = base.GetWebElementPropertiesByLinkText
                    (AddAssessmentPageResources.
                    AddAssessment_Page_HelpLinkAddAndClose_PartialText_Locator);
                //Click on the Save Add Link button
                base.ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "SaveHelpLink",
                    base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Preview the added HelpLink.
        /// </summary>
        public void PreviewHelpLink()
        {
            //Create The Instructor Gradable Activity
            logger.LogMethodEntry("AddAssessmentPage", "PreviewHelpLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Add Link popup
                base.SelectWindow(AddAssessmentPageResources.
                    AddAsessment_Page_CreateRandomActivity_Window_Name);

                this.ClickOnPreviewHelpLink();

                //Select the Add Link popup
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "PreviewHelpLink",
                    base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Preview Help Link.
        /// </summary>
        private void ClickOnPreviewHelpLink()
        {
            logger.LogMethodEntry("AddAssessmentPage", "ClickOnPreviewHelpLink",
                base.IsTakeScreenShotDuringEntryExit);

            //Wait for web element
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAssessment_Page_HelpLink_Frame_ID_Locator));
            //Select the iFrame
            base.SwitchToIFrame(AddAssessmentPageResources.
                AddAssessment_Page_HelpLink_Frame_ID_Locator);

            //Wait for the Help Link C-Menu
            base.WaitForElement(By.XPath(AddAssessmentPageResources.
                AddAssessment_Page_HelpLinkCMenu_XPath_Locator));
            IWebElement getHelpLinkCMenu = base.GetWebElementPropertiesByXPath
                (AddAssessmentPageResources.
                AddAssessment_Page_HelpLinkCMenu_XPath_Locator);
            //Click on the Help Link C-Menu
            base.ClickByJavaScriptExecutor(getHelpLinkCMenu);

            base.WaitForElement(By.XPath(AddAssessmentPageResources.
                AddAssessment_Page_HelpLinkPreview_XPath_Locator));
            //click on Help-Link Preview link
            base.FocusOnElementByXPath(AddAssessmentPageResources.
                AddAssessment_Page_HelpLinkPreview_XPath_Locator);
            IWebElement previewHelpLink = base.GetWebElementPropertiesByXPath
                (AddAssessmentPageResources.
                AddAssessment_Page_HelpLinkPreview_XPath_Locator);
            //Click on the Help Link C-Menu
            base.ClickByJavaScriptExecutor(previewHelpLink);

            logger.LogMethodExit("AddAssessmentPage", "ClickOnPreviewHelpLink",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create the Activity With HelpLinks.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        public void AddHelpLinks()
        {
            //Create The Instructor Gradable Activity
            logger.LogMethodEntry("AddAssessmentPage", "AddHelpLinks",
                base.IsTakeScreenShotDuringEntryExit);
            SkillBasedAssessmentPage skillBasedAssessmentPage =
                new SkillBasedAssessmentPage();
            try
            {
                //Select Create Random Activity
                this.SelectCreateRandomActivity();
                //Click on the HelpLinks tab
                this.ClickOnHelpLinksTab();
                //Click on the Add Links link
                new RandomTopicListPage().ClickOnAddLinksLink();
                //Open the Add Help Links popup
                this.ClickTheSelectFromCourseMaterialsLibraryLink();
                //Save Help Link
                this.SaveHelpLink();
                //Preview the added Help Link
                // this.PreviewHelpLink();
                //Select Create Activity window
                base.SelectWindow(AddAssessmentPageResources.AddAsessment_Page_CreateRandomActivity_Window_Name);
                //Wait for Save and Return button on page
                new RandomTopicListPage().ClickOnAddLinksLink();
                //Open the Add Help Links popup
                this.ClickAddLinkToWebsiteLink();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "AddHelpLinks",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Select From Course Materials Library link.
        /// </summary>
        private void ClickAddLinkToWebsiteLink()
        {
            logger.LogMethodEntry("AddAssessmentPage", "ClickTheAddLinkToWebsiteLink",
                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element             
            base.WaitForElement(By.XPath(AddAssessmentPageResources.
               AddAssessment_Page_AddLinkToWebsite_XPath_Locator));
            //Get web element
            IWebElement getCreateQuesLinkProperty = base.GetWebElementPropertiesByXPath
                (AddAssessmentPageResources.
               AddAssessment_Page_AddLinkToWebsite_XPath_Locator);
            //Click the "Add Link to Website" link
            base.ClickByJavaScriptExecutor(getCreateQuesLinkProperty);
            base.WaitUntilWindowLoads(AddAssessmentPageResources.
                AddAsessment_Page_AddLink_Popup_Title);
            base.SelectWindow(AddAssessmentPageResources.
                AddAsessment_Page_AddLink_Popup_Title);
            // Wait for Title field and enter the Title
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAsessment_Page_AddLink_LinkText_ID_Value));
            base.FillTextBoxById(AddAssessmentPageResources.
                AddAsessment_Page_AddLink_LinkText_ID_Value, AddAssessmentPageResources.
                AddAsessment_Page_AllLink_Title_Text);
            // Wait for URL field and enter the URL
            base.WaitForElement(By.Id(AddAssessmentPageResources.
             AddAsessment_Page_AddLink_LinkURL_ID_Value));

            switch (Environment.GetEnvironmentVariable(AddAssessmentPageResources.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AddAssessmentPageResources.TestEnvironment_Key].ToUpper())
            {
                case "PPE":
                    base.FillTextBoxById(AddAssessmentPageResources.
                        AddAsessment_Page_AddLink_LinkURL_ID_Value, AddAssessmentPageResources.
                        AddAsessment_Page_AllLink_URL_PROD);
                    break;
                case "CGIE":
                    base.FillTextBoxById(AddAssessmentPageResources.
                        AddAsessment_Page_AddLink_LinkURL_ID_Value, AddAssessmentPageResources.
                        AddAsessment_Page_AllLink_URL_PROD);
                    break;
                case "PROD":
                    base.FillTextBoxById(AddAssessmentPageResources.
                        AddAsessment_Page_AddLink_LinkURL_ID_Value, AddAssessmentPageResources.
                        AddAsessment_Page_AllLink_URL_PROD);
                    break;
            }
            // Wait for Save button to load and click on Save button
            base.WaitForElement(By.Id(AddAssessmentPageResources.
                AddAsessment_Page_AddLink_Popup_SaveButton_ID));
            IWebElement getSaveButton = base.GetWebElementPropertiesById(AddAssessmentPageResources.
                AddAsessment_Page_AddLink_Popup_SaveButton_ID);
            base.ClickByJavaScriptExecutor(getSaveButton);
            logger.LogMethodExit("AddAssessmentPage", "ClickTheAddLinkToWebsiteLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Workspace instructor configore default grades option for random activity
        /// </summary>
        public void ConfigureGradesForSamActivity()
        {
            //Create The Instructor Gradable Activity
            logger.LogMethodEntry("AddAssessmentPage", "ConfigureGrades",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the Grades tab
                this.ClickOnGradesTab();
                //Select Default grades option from "Select grade schema" dropdown
                this.SelectDefaultGradeSchema();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "ConfigureGrades",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to configure default Grade Schema 
        /// </summary>
        public void SelectDefaultGradeSchema()
        {
            //Create The Instructor Gradable Activity
            logger.LogMethodEntry("AddAssessmentPage", "SelectDefaultGradeSchema",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create Random Activity
                //Click on the Grades tab
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                    AddAssessment_Page_Grades_SchemaSelector_Id_Locator));
                base.SelectDropDownOptionById(AddAssessmentPageResources.
                    AddAssessment_Page_Grades_SchemaSelector_Id_Locator, AddAssessmentPageResources.
                    AddAssessment_Page_Grades_SchemaSelector_Default_DropDown_Option);
                base.SelectDropDownValueThroughTextById(AddAssessmentPageResources.
                    AddAssessment_Page_Grades_SchemaSelector_Id_Locator, AddAssessmentPageResources.
                    AddAssessment_Page_Grades_SchemaSelector_Default_DropDown_Option);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "SelectDefaultGradeSchema",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click On HelpLinks Tab.
        /// </summary>
        public void ClickOnGradesTab()
        {
            //Click On SaveAndContinue Button
            logger.LogMethodEntry("AddAssessmentPage", "ClickOnGradesTab",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create Random Activity
                this.SelectCreateRandomActivity();
                //Wait for the Grades tab
                base.WaitForElement(By.Id(AddAssessmentPageResources.
                        AddAssessment_Page_Grades_Tab_Id_Locator));
                //Focus control on the Grades tab
                base.FocusOnElementById(AddAssessmentPageResources.
                    AddAssessment_Page_Grades_Tab_Id_Locator);
                //Get Grades Property
                IWebElement getbuttonProperty = base.GetWebElementPropertiesById(
                    AddAssessmentPageResources.
                    AddAssessment_Page_Grades_Tab_Id_Locator);
                //Click On Grades tab
                base.ClickByJavaScriptExecutor(getbuttonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "ClickOnGradesTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Preview the added HelpLink when editing activity.
        /// </summary>
        public void PreviewHelpLinkOnEdit()
        {
            logger.LogMethodEntry("AddAssessmentPage", "PreviewHelpLinkOnEdit",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Preview the added HelpLink when editing activity
                this.ClickOnPreviewHelpLink();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "PreviewHelpLinkOnEdit",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get lightbox title
        /// </summary>
        /// <returns>Return lightbox name.</returns>
        public string GetLightBoxTitle(string lightBoxName)
        {
            logger.LogMethodEntry("AddAssessmentPage", "GetLightBoxTitle",
                    base.IsTakeScreenShotDuringEntryExit);
            string getLightBoxName = string.Empty;
            string lightBoxTitle = string.Empty;
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(base.GetPageTitle);
                // Switch to default window lightbox
                base.SwitchToDefaultWindow();
                switch (lightBoxName)
                {
                    case "Add Link":
                    case "Add File":
                    case "Add Multiple Files":
                        base.WaitForElement(By.ClassName(AddAssessmentPageResources.
                            AddAssessment_Page_CourseMaterials_LinkAndFile__ID_Locator));
                        getLightBoxName = base.
                            GetInnerTextAttributeValueByClassName(AddAssessmentPageResources.
                            AddAssessment_Page_CourseMaterials_LinkAndFile__ID_Locator);
                        break;

                    case "Add eText Link":
                    case "Add Discussion Topic":
                        base.WaitForElement(By.Id(AddAssessmentPageResources.
                            AddAssessment_Page_CourseMaterials_eTextandDT__ID_Locator));
                        getLightBoxName = base.
                            GetInnerTextAttributeValueById(AddAssessmentPageResources.
                            AddAssessment_Page_CourseMaterials_eTextandDT__ID_Locator);
                        break;

                    case "Add Page":
                        string getPageTitle = base.GetPageTitle;
                        if (getPageTitle == AddAssessmentPageResources.
                            AddAssessment_Page_CourseMaterials_AddPageTitle) 
                        {
                            getLightBoxName = AddAssessmentPageResources.
                            AddAssessment_Page_CourseMaterials_AddPage_LightBox_Name;
                        }
                        break;

                    case "Add from Library":
                    case "Note":
                        base.WaitForElement(By.ClassName(AddAssessmentPageResources.
                           AddAssessment_Page_CourseMaterials_AddNote__ClassName_Locator));
                        // Get the lightbox title based on the class name
                        getLightBoxName = base.GetInnerTextAttributeValueByClassName
                            (AddAssessmentPageResources.
                            AddAssessment_Page_CourseMaterials_AddNote__ClassName_Locator);
                        break;
                }               

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "GetLightBoxTitle",
                    base.IsTakeScreenShotDuringEntryExit);
            return getLightBoxName;
        }


        /// <summary>
        /// Get Activity name in Course Materials tab
        /// </summary>
        /// <returns>Return lightbox name.</returns>
        public string GetActivityName(string activityName)
        {
            logger.LogMethodEntry("AddAssessmentPage", "GetActivityName",
                    base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(AddAssessmentPageResources.
                    AddAssessment_Page_CourseMaterials_WindowName);
                base.SelectWindow(AddAssessmentPageResources.
                    AddAssessment_Page_CourseMaterials_WindowName);
                base.SwitchToIFrameById(AddAssessmentPageResources.
                    AddAssessment_Page_CourseMaterials_Iframe_ID_Locator);
                // Check pagination existance
                int pageCount = new CoursePreviewUXPage().CheckPaginationStatus();
                //Get the Activity count in Course Materials tab
                int getActivityCount = base.GetElementCountByXPath(
                    AddAssessmentPageResources.
                    AddAssessment_Page_CourseMaterialstab_ActivityCount_XPath_Locator);   
                for (int pageNumber = Convert.ToInt32(1); pageNumber <= pageCount; pageNumber++)
                {
                    for (int rowCount = Convert.ToInt32(1); rowCount <= getActivityCount;
                        rowCount++)
                    {
                        //Fetch the Activity Name
                        getActivityName = base.GetElementTextByXPath
                            (string.Format(AddAssessmentPageResources.
                    AddAssessment_Page_CourseMaterialstab_ActivityName_XPath_Locator,                           
                             rowCount)).Trim();
                        if (getActivityName.Equals(activityName))
                        {
                            getActivityName = base.GetElementTextByXPath
                            (string.Format(AddAssessmentPageResources.
                    AddAssessment_Page_CourseMaterialstab_ActivityName_XPath_Locator,
                    rowCount)).Trim();
                            return getActivityName;
                        }
                    }
                    //Click on Next icon to go to next page in Course Materials tab
                    IWebElement getNextIcon = base.
                        GetWebElementPropertiesById(AddAssessmentPageResources.
                        AddAssessment_Page_CourseMaterialstab_NextPage_Link_XPath_Locator);
                    base.ClickByJavaScriptExecutor(getNextIcon);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "GetActivityName",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Click activity name.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void ClickActivityName(string activityName)
        {
            logger.LogMethodEntry("AddAssessmentPage", "ClickActivityName",
        base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            try
            {
                //Select Course Materials window
                base.WaitUntilWindowLoads(AddAssessmentPageResources.
                     AddAssessment_Page_CourseMaterials_WindowName);
                base.SelectWindow(AddAssessmentPageResources.
                    AddAssessment_Page_CourseMaterials_WindowName);
                //Switch to Iframe
                base.SwitchToIFrameById(AddAssessmentPageResources.
                    AddAssessment_Page_CourseMaterials_Iframe_ID_Locator);
                int getActivityCount = base.GetElementCountByXPath(
                    AddAssessmentPageResources.
                    AddAssessment_Page_CourseMaterialstab_ActivityCount_XPath_Locator);

                for (int rowCount = Convert.ToInt32(1); rowCount <= getActivityCount;
                    rowCount++)
                {
                    //Gets the Activity Name
                    getActivityName = base.GetElementTextByXPath
                        (string.Format(AddAssessmentPageResources.
                        AddAssessment_Page_CourseMaterialstab_ActivityName_XPath_Locator,
                        rowCount)).Trim();
                    if (getActivityName.Equals(activityName))
                    {
                        //Click on the Activity / Folder name 
                        IWebElement getAssetTitle = base.GetWebElementPropertiesByXPath(
                            string.Format(AddAssessmentPageResources.
                        AddAssessment_Page_CourseMaterialstab_ActivitySelect_XPath_Locator
                            , rowCount));
                        base.PerformMouseClickAction(getAssetTitle);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddAssessmentPage", "ClickActivityName",
                    base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
