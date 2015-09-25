using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.User;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation.AutoGrader;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using System.Windows.Forms;
using System.Diagnostics;


namespace Pegasus.Pages.UI_Pages.Integration.PCT
{
    /// <summary>
    /// This class handles all the operations performed on Project creation tool page
    /// </summary>
    public class PCTProjectListPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger.
        /// </summary>
        private static readonly Logger logger = Logger.
        GetInstance(typeof(PCTProjectListPage));

        /// <summary>
        ///  Click Create link in Project creation page.
        /// </summary>
        public void CSInsClickCreateLinkPCT()
        {
            logger.LogMethodEntry("PCTProjectListPage", "CSInsClickCreateLinkPCT", base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToActivePageElement();
            SelectPCTProjectListPopup();
            Thread.Sleep(20000);
            base.WaitForElement(By.Id(PCTProjectListPageResource.PCTProjectList_Page_CreateProject_Link_ID_Locator));
            IWebElement getCreateLinkProperty = base.GetWebElementPropertiesById(PCTProjectListPageResource.
                PCTProjectList_Page_CreateProject_Link_ID_Locator);
            base.ClickByJavaScriptExecutor(getCreateLinkProperty);
            logger.LogMethodExit("PCTProjectListPage", "CSInsClickCreateLinkPCT", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Project Creation Tool popup.
        /// </summary>
        private void SelectPCTProjectListPopup()
        {
            logger.LogMethodEntry("PCTProjectListPage", "SelectPCTProjectListPopup", base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilPopUpLoads(PCTProjectListPageResource.PCTProjectList_Page_ProjectCreationTool_Page_Title_Value);
            base.SelectWindow(PCTProjectListPageResource.PCTProjectList_Page_ProjectCreationTool_Page_Title_Value);
            logger.LogMethodExit("PCTProjectListPage", "SelectPCTProjectListPopup", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the Project name in "Create/Import Project"
        /// </summary>
        /// <param name="userTypeEnum"></param>
        public void EnterProjectName(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Create New User
            logger.LogMethodEntry("PCTProjectListPage", "EnterProjectName",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Creating the Cs User by UserType                
                Guid activityInformation = this.CreatePCTProject(activityTypeEnum);
                //Stores User Details in Memory
                this.StoreTheGraderAsset(activityInformation, activityTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PCTProjectListPage", "EnterProjectName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store the asset
        /// </summary>
        /// <param name="newLinkAsset">This is Link Asset Guid</param>
        /// <param name="activityTypeEnum">This is Activity Type enum.</param>
        private void StoreTheGraderAsset(Guid newLinkAsset,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Store the asset 
            logger.LogMethodEntry("PCTProjectListPage", "StoreTheGraderAsset",
                base.IsTakeScreenShotDuringEntryExit);
            //Store the Link in memory
            Activity newLink = new Activity
            {

                Name = newLinkAsset.ToString(),
                ActivityType = activityTypeEnum,
                IsCreated = true,
            };
            newLink.StoreActivityInMemory();
            logger.LogMethodExit("PCTProjectListPage", "StoreTheGraderAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create New PCT Project.
        /// </summary>
        /// <param name="userTypeEnum">This Is User Type Enum.</param>
        /// <returns>User Name.</returns>
        private Guid CreatePCTProject(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // CreateNewUser for CS user creation
            logger.LogMethodEntry("PCTProjectListPage", "CreatePCTProject",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Add User Window
            this.SelectPCTProjectListPopup();
            // Generate User Login Details Guid
            Guid activityInformation = Guid.NewGuid();
            // Enter Project Name
            base.WaitForElement(By.Id("NameInput"));
            base.ClearTextById("NameInput");
            base.FillTextBoxById("NameInput", activityInformation.ToString());
            logger.LogMethodEntry("PCTProjectListPage", "CreatePCTProject",
             base.IsTakeScreenShotDuringEntryExit);
            return activityInformation;
        }


        /// <summary>
        /// Stores User Details in Memory.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type.</param>
        /// <param name="userInformation">This is User Information Guid.</param>        
        public void StoreActivityDetails(Activity.ActivityTypeEnum activityTypeEnum, Guid projectName)
        {
            //Stores User Details in Memory
            logger.LogMethodEntry("PCTProjectListPage", "CreatePCTProject",
                base.IsTakeScreenShotDuringEntryExit);
            //Store Activity Details in Memory
            this.StoreUserDetailsInMemory(activityTypeEnum, projectName);
            logger.LogMethodExit("PCTProjectListPage", "StoreUserDetails"
                , base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Saving the User Details in Memory
        /// </summary>
        /// <param name="userTypeEnum">This is Activity Type Enum</param>
        /// <param name="userName">This is ProjectName Guid</param>
        private void StoreUserDetailsInMemory(Activity.ActivityTypeEnum activityTypeEnum,
            Guid projectName)
        {
            //Save user in Memory
            logger.LogMethodEntry("PCTProjectListPage", "StoreUserDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            //Save User Properties in Memory
            //Save Student Details
            this.SaveActivityInMemory
                (activityTypeEnum, projectName);
            logger.LogMethodExit("PCTProjectListPage", "StoreUserDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save Activity In Memory
        /// </summary>
        /// <param name="userTypeEnum">This is Activity Type Enum</param>
        /// <param name="userName">This is ProjectName Guid</param>
        private void SaveActivityInMemory(Activity.ActivityTypeEnum activityTypeEnum, Guid projectName)
        {
            //Save The Activity In Memory
            logger.LogMethodEntry("PCTProjectListPage", "SaveUserInMemory",
              base.IsTakeScreenShotDuringEntryExit);
            Activity activity = new Activity()
            {
                Name = projectName.ToString(),
                IsCreated = true,
            };
            //Save The Activity In Memory
            activity.StoreActivityInMemory();
            logger.LogMethodExit("PCTProjectListPage", "SaveUserInMemory",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Done button in PCT Page
        /// </summary>
        public void ClickDoneButtonPCT()
        {
            logger.LogMethodEntry("PCTProjectListPage", "ClickDoneButtonPCT",
                base.IsTakeScreenShotDuringEntryExit);
            base.PressEnterKeyById("NameInput");
            logger.LogMethodEntry("PCTProjectListPage", "ClickDoneButtonPCT",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Upload icon and upload the file
        /// </summary>
        /// <param name="fileUploadOptionName">This is the file upload option name.</param>
        public void ClickUploadIconPCT(string fileUploadOptionName)
        {
            logger.LogMethodEntry("PCTProjectListPage", "ClickUploadIconPCT",
            base.IsTakeScreenShotDuringEntryExit);
            SelectPCTProjectListPopup();
            switch (fileUploadOptionName)
            {
                case "Final Document":
                    Thread.Sleep(10000);
                    base.WaitForElement(By.XPath(PCTProjectListPageResource.
                        PCTProjectList_Page_PCT_FinalDocument_UploadIcon_Xpath_Locator));
                    IWebElement getFinalDocumentDownloadIcon = base.GetWebElementPropertiesByXPath(
                        PCTProjectListPageResource.
                        PCTProjectList_Page_PCT_FinalDocument_UploadIcon_Xpath_Locator);
                    base.ClickByJavaScriptExecutor(getFinalDocumentDownloadIcon);
                    Thread.Sleep(10000);
                    break;

                case "Start Document":
                    Thread.Sleep(10000);
                    base.WaitForElement(By.XPath(PCTProjectListPageResource.
                        PCTProjectList_Page_PCT_StartDocument_UploadIcon_Xpath_Locator));
                    IWebElement getStartDocumentDownloadIcon = base.GetWebElementPropertiesByXPath(
                        PCTProjectListPageResource.
                        PCTProjectList_Page_PCT_StartDocument_UploadIcon_Xpath_Locator);
                    base.ClickByJavaScriptExecutor(getStartDocumentDownloadIcon);
                    Thread.Sleep(10000);
                    break;

                case "Instruction Document":
                    Thread.Sleep(10000);
                    base.WaitForElement(By.XPath(PCTProjectListPageResource.
                        PCTProjectList_Page_PCT_InstructionDocument_UploadIcon_Xpath_Locator));
                    IWebElement getInstructionDocumentDownloadIcon = base.GetWebElementPropertiesByXPath(PCTProjectListPageResource.
                        PCTProjectList_Page_PCT_InstructionDocument_UploadIcon_Xpath_Locator);
                    base.ClickByJavaScriptExecutor(getInstructionDocumentDownloadIcon);
                    Thread.Sleep(10000);
                    break;
            }
            logger.LogMethodExit("PCTProjectListPage", "ClickUploadIconPCT",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Upload the file based in PCT
        /// </summary>
        /// <param name="uploadFileName">File name to be uploaded.</param>
        public void UploadFileInPCT(String uploadFileName)
        {
            //Upload file to PCT
            logger.LogMethodEntry("UploadCompletedFilesPage", "UploadGraderItFile",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Project creation tool windown to load and select the window
                SelectPCTProjectListPopup();
                //Grader IT File Upload.
                switch (uploadFileName)
                {
                    // Upload Final Document Word File.
                    case "Final Document Word File":
                        base.ClickButtonById(PCTProjectListPageResource.
                            PCTProjectList_Page_PCT_Filupload_BrowseButton_Id_Locator);
                        Thread.Sleep(10000);
                        base.SwitchToLastOpenedWindow();
                        Process.Start((AutomationConfigurationManager.TestDataPath
                                   + PCTProjectListPageResource.PCTProjectList_Page_AutoIT_WordFinal_FilePath).Replace("file:\\", ""));
                        Thread.Sleep(20000);
                        bool okButtonExistance = base.IsElementPresent(By.ClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator), 10);
                        if (okButtonExistance.Equals("True"))
                        {
                            // Click ok button
                            base.ClickButtonByClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator);
                            break;
                        }
                        else
                        {
                            IWebElement getUploadFinalDocumentButton = base.GetWebElementPropertiesByXPath(PCTProjectListPageResource.
                                PCTProjectList_Page_PCT_StartDocument_Word_FilUpload_Icon_Xpath);
                            base.ClickByJavaScriptExecutor(getUploadFinalDocumentButton);
                            Thread.Sleep(30000);
                            break;
                        }

                    case "Final Document Excel File":
                        base.ClickButtonById(PCTProjectListPageResource.
                            PCTProjectList_Page_PCT_Filupload_BrowseButton_Id_Locator);
                        Thread.Sleep(10000);
                        base.SwitchToLastOpenedWindow();
                        Process.Start((AutomationConfigurationManager.TestDataPath
                                   + PCTProjectListPageResource.PCTProjectList_Page_AutoIT_ExcelFinal_FilePath).Replace("file:\\", ""));
                        Thread.Sleep(20000);
                        bool okButtonPCTExcelFinalExistance = base.IsElementPresent(By.ClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator), 10);
                        if (okButtonPCTExcelFinalExistance.Equals("True"))
                        {
                            // Click ok button
                            base.ClickButtonByClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator);
                            break;
                        }
                        else
                        {
                            IWebElement getUploadFinalDocumentButton = base.GetWebElementPropertiesByXPath(PCTProjectListPageResource.
                                PCTProjectList_Page_PCT_StartDocument_Word_FilUpload_Icon_Xpath);
                            base.ClickByJavaScriptExecutor(getUploadFinalDocumentButton);
                            Thread.Sleep(30000);
                            break;
                        }

                    case "Final Document PPT File":
                        base.ClickButtonById(PCTProjectListPageResource.
                            PCTProjectList_Page_PCT_Filupload_BrowseButton_Id_Locator);
                        Thread.Sleep(10000);
                        base.SwitchToLastOpenedWindow();
                        Process.Start((AutomationConfigurationManager.TestDataPath
                                   + PCTProjectListPageResource.PCTProjectList_Page_AutoIT_PPTFinal_FilePath).Replace("file:\\", ""));
                        Thread.Sleep(20000);
                        bool okButtonPCTPPTFinalExistance = base.IsElementPresent(By.ClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator), 10);
                        if (okButtonPCTPPTFinalExistance.Equals("True"))
                        {
                            // Click ok button
                            base.ClickButtonByClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator);
                            break;
                        }
                        else
                        {
                            IWebElement getUploadFinalDocumentButton = base.GetWebElementPropertiesByXPath(PCTProjectListPageResource.
                                PCTProjectList_Page_PCT_StartDocument_Word_FilUpload_Icon_Xpath);
                            base.ClickByJavaScriptExecutor(getUploadFinalDocumentButton);
                            Thread.Sleep(30000);
                            break;
                        }

                    case "Start Document Word File":
                        base.ClickButtonById(PCTProjectListPageResource.
                           PCTProjectList_Page_PCT_Filupload_BrowseButton_Id_Locator);
                        Thread.Sleep(10000);
                        base.SwitchToLastOpenedWindow();
                        Process.Start((AutomationConfigurationManager.TestDataPath
                                   + PCTProjectListPageResource.PCTProjectList_Page_AutoIT_WordInitial_FilePath).Replace("file:\\", ""));
                        Thread.Sleep(20000);
                        bool okButtonExistanceStartDocument = base.IsElementPresent(By.ClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator), 10);
                        if (okButtonExistanceStartDocument.Equals("True"))
                        {
                            // Click ok button
                            base.ClickButtonByClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator);
                            break;
                        }
                        else
                        {
                            IWebElement getStartDocumentUploadButton = base.
                                GetWebElementPropertiesByXPath(PCTProjectListPageResource.
                                PCTProjectList_Page_PCT_StartDocument_Word_FilUpload_Icon_Xpath);
                            base.ClickByJavaScriptExecutor(getStartDocumentUploadButton);
                            Thread.Sleep(20000);
                            break;
                        }

                    case "Start Document Excel File":
                        base.ClickButtonById(PCTProjectListPageResource.
                            PCTProjectList_Page_PCT_Filupload_BrowseButton_Id_Locator);
                        Thread.Sleep(10000);
                        base.SwitchToLastOpenedWindow();
                        Process.Start((AutomationConfigurationManager.TestDataPath
                                   + PCTProjectListPageResource.PCTProjectList_Page_AutoIT_ExcelInitial_FilePath).Replace("file:\\", ""));
                        Thread.Sleep(20000);
                        bool okButtonExistanceStartDocumentExcel = base.IsElementPresent(By.ClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator), 10);
                        if (okButtonExistanceStartDocumentExcel.Equals("True"))
                        {
                            // Click ok button
                            base.ClickButtonByClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator);
                            break;
                        }
                        else
                        {
                            IWebElement getStartDocumentUploadButton = base.GetWebElementPropertiesByXPath(PCTProjectListPageResource.
                                PCTProjectList_Page_PCT_StartDocument_Word_FilUpload_Icon_Xpath);
                            base.ClickByJavaScriptExecutor(getStartDocumentUploadButton);
                            Thread.Sleep(20000);
                            break;
                        }

                    case "Start Document PPT File":
                        base.ClickButtonById(PCTProjectListPageResource.
                            PCTProjectList_Page_PCT_Filupload_BrowseButton_Id_Locator);
                        Thread.Sleep(10000);
                        base.SwitchToLastOpenedWindow();
                        Process.Start((AutomationConfigurationManager.TestDataPath
                                   + PCTProjectListPageResource.PCTProjectList_Page_AutoIT_PPTInitial_FilePath).Replace("file:\\", ""));
                        Thread.Sleep(20000);
                        bool okButtonExistanceStartDocumentPPT = base.IsElementPresent(By.ClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator), 10);
                        if (okButtonExistanceStartDocumentPPT.Equals("True"))
                        {
                            // Click ok button
                            base.ClickButtonByClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator);
                            break;
                        }
                        else
                        {
                            IWebElement getStartDocumentUploadButton = base.GetWebElementPropertiesByXPath(PCTProjectListPageResource.
                                PCTProjectList_Page_PCT_StartDocument_Word_FilUpload_Icon_Xpath);
                            base.ClickByJavaScriptExecutor(getStartDocumentUploadButton);
                            Thread.Sleep(20000);
                            break;
                        }

                    case "Instruction Document Word File":
                        base.ClickButtonById(PCTProjectListPageResource.
                           PCTProjectList_Page_PCT_Filupload_BrowseButton_Id_Locator);
                        Thread.Sleep(10000);
                        base.SwitchToLastOpenedWindow();
                        Process.Start((AutomationConfigurationManager.TestDataPath
                                   + PCTProjectListPageResource.PCTProjectList_Page_AutoIT_WordInstruction_FilePath).Replace("file:\\", ""));
                        Thread.Sleep(20000);
                        // Check if upload failed alert window is displayed 
                        // and click ok button
                        bool okButtonExistanceInstructionDocument = base.IsElementPresent(By.ClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator), 10);
                        if (okButtonExistanceInstructionDocument.Equals("True"))
                        {
                            // Click ok button
                            base.ClickButtonByClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator);
                            break;
                        }
                        else
                        {
                            IWebElement getInstructionDocumentUploadButton = base.GetWebElementPropertiesByXPath(PCTProjectListPageResource.
                                PCTProjectList_Page_PCT_StartDocument_Word_FilUpload_Icon_Xpath);
                            base.ClickByJavaScriptExecutor(getInstructionDocumentUploadButton);
                            Thread.Sleep(20000);
                            break;
                        }

                    case "Instruction Document Excel File":
                        base.ClickButtonById(PCTProjectListPageResource.
                            PCTProjectList_Page_PCT_Filupload_BrowseButton_Id_Locator);
                        Thread.Sleep(10000);
                        base.SwitchToLastOpenedWindow();
                        Process.Start((AutomationConfigurationManager.TestDataPath
                                   + PCTProjectListPageResource.PCTProjectList_Page_AutoIT_ExcelInstruction_FilePath).Replace("file:\\", ""));
                        Thread.Sleep(20000);
                        // Check if upload failed alert window is displayed 
                        // and click ok button
                        bool okButtonExistanceInstructionDocumentExcel = base.IsElementPresent(By.ClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator), 10);
                        if (okButtonExistanceInstructionDocumentExcel.Equals("True"))
                        {
                            // Click ok button
                            base.ClickButtonByClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator);
                            break;
                        }
                        else
                        {
                            IWebElement getInstructionDocumentUploadButton = base.GetWebElementPropertiesByXPath(PCTProjectListPageResource.
                                PCTProjectList_Page_PCT_StartDocument_Word_FilUpload_Icon_Xpath);
                            base.ClickByJavaScriptExecutor(getInstructionDocumentUploadButton);
                            Thread.Sleep(20000);
                            break;
                        }

                    case "Instruction Document PPT File":
                        base.ClickButtonById(PCTProjectListPageResource.
                            PCTProjectList_Page_PCT_Filupload_BrowseButton_Id_Locator);
                        Thread.Sleep(10000);
                        base.SwitchToLastOpenedWindow();
                        Process.Start((AutomationConfigurationManager.TestDataPath
                                   + PCTProjectListPageResource.PCTProjectList_Page_AutoIT_PPTInstruction_FilePath).Replace("file:\\", ""));
                        Thread.Sleep(20000);
                        // Check if upload failed alert window is displayed 
                        // and click ok button
                        bool okButtonExistanceInstructionDocumentPPT = base.IsElementPresent(By.ClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator), 10);
                        if (okButtonExistanceInstructionDocumentPPT.Equals("True"))
                        {
                            // Click ok button
                            base.ClickButtonByClassName(PCTProjectListPageResource.
                                PCTProjectList_Page_ProjectCreationTool_Alertbox_OKButton_ClassName_Locator);
                            break;
                        }
                        else
                        {
                            IWebElement getInstructionDocumentUploadButton = base.GetWebElementPropertiesByXPath(PCTProjectListPageResource.
                                PCTProjectList_Page_PCT_StartDocument_Word_FilUpload_Icon_Xpath);
                            base.ClickByJavaScriptExecutor(getInstructionDocumentUploadButton);
                            Thread.Sleep(20000);
                            break;
                        }
                }
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ImportUsersPage", "UploadBulkUserFile",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Map Skill to instruction in PCT tool page
        /// </summary>
        /// <param name="skillName">This is skill name.</param>
        /// <param name="folderName">This is the folder name were skills are placed.</param>
        public void MapSkillToInstruction(string skillName, string folderName)
        {
            logger.LogMethodEntry("PCTProjectListPage", "MapSkillToInstruction",
                base.IsTakeScreenShotDuringEntryExit);
            SelectPCTProjectListPopup();
            base.MaximizeWindow();
            IWebElement getFolderProperty = base.GetWebElementPropertiesByPartialLinkText(folderName);
            base.PerformMouseClickAction(getFolderProperty);

            // Source WebElement property
            IWebElement getSkillProperty = base.GetWebElementPropertiesByPartialLinkText(skillName);
            // Target WebElement property
            IWebElement getDestinationProperty = base.GetWebElementPropertiesByClassName(PCTProjectListPageResource.
                PCTProjectList_Page_PCT_TargetLocation_ClassName_Value);
            base.PerformDragAndDropAction(getSkillProperty, getDestinationProperty);
            Thread.Sleep(10000);
            base.SelectCheckBoxByClassName("propertyCheckBox");
            IWebElement getDoneButton = base.GetWebElementPropertiesByClassName("OkDiv");
            base.PerformMouseClickAction(getDoneButton);
            logger.LogMethodExit("PCTProjectListPage", "MapSkillToInstruction",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the uploaded file name based on the frame selected
        /// </summary>
        /// <param name="frameName">This is the frame name where the file are uploaded 
        /// and displayed.</param>
        /// <returns>Return uploaded file name.</returns>
        public string GetUploadedFileName(string frameName)
        {
            //Get the successfully uploaded file name
            logger.LogMethodEntry("PCTProjectListPage",
                "GetUploadedFileName",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize upload file name variable
            string uploadedfileName = string.Empty;
            try
            {
                //Select Window And Frame
                SelectPCTProjectListPopup();
                //Execute the code based on the uploaded frame name.
                switch (frameName)
                {
                    case "Final Document":
                        //Get The file Name In Final Document frame
                        //base.IsPCTFileUploadThinkingIndicatorLoading();
                        Thread.Sleep(30000);
                        base.IsPCTThinkingIndicatorLoading();
                        uploadedfileName = base.GetElementTextByCssSelector(PCTProjectListPageResource.
                            PCTProjectList_Page_PCT_GetFileName_FinalDocument_CSS_Locator);
                        break;
                    case "Start Document":
                        //Get The file Name In Start Document frame
                        uploadedfileName = base.GetElementTextByCssSelector(PCTProjectListPageResource.
                            PCTProjectList_Page_PCT_GetFileName_StartDocument_CSS_Locator);
                        break;
                    case "Instruction Document":
                        //Get The file Name In Instruction Document frame
                        uploadedfileName = base.GetElementTextByCssSelector(PCTProjectListPageResource.
                            PCTProjectList_Page_PCT_GetFileName_InstructionDocument_CSS_Locator);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PCTProjectListPage",
                "GetUploadedFileName",
                    base.IsTakeScreenShotDuringEntryExit);
            return uploadedfileName;
        }

        /// <summary>
        /// Publish the newly created project in project creation tool page.
        /// </summary>
        public void PublishProjectInPCT()
        {
            //Publish newly created project
            logger.LogMethodEntry("PCTProjectListPage", "PublishProjectInPCT",
                    base.IsTakeScreenShotDuringEntryExit);
            //Select Project creation tool page
            SelectPCTProjectListPopup();
            // Click publish button
            IWebElement getPublishButtonProperty = base.GetWebElementPropertiesById(PCTProjectListPageResource.
                PCTProjectList_Page_ProjectCreationTool_PublishHomeButton_Id_Locator);
            base.PerformMouseClickAction(getPublishButtonProperty);
            // Click publish button in PCT Project Publish page
            IWebElement getPublishButtonPropertyProjectPublishpage = base.GetWebElementPropertiesById(
                PCTProjectListPageResource.PCTProjectList_Page_ProjectCreationTool_PublishButton_Id_Locator);
            base.PerformMouseClickAction(getPublishButtonPropertyProjectPublishpage);
            // Click Done button
            IWebElement getPublishCompleteButtonProperty = base.GetWebElementPropertiesById(PCTProjectListPageResource.
                PCTProjectList_Page_ProjectCreationTool_PublishCompleteButton_Id_Locator);
            base.PerformMouseClickAction(getPublishCompleteButtonProperty);
            logger.LogMethodExit("PCTProjectListPage", "PublishProjectInPCT",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Instructor select PCT project type in project creation tool.
        /// </summary>
        /// <param name="projectType">This is a project type.</param>
        public void SelectPCTProjectType(string projectType)
        {
            // Select project type
            logger.LogMethodEntry("PCTProjectListPage", "SelectPCTProjectType", IsTakeScreenShotDuringEntryExit);
            switch (projectType)
            {
                // Select Word type project
                case "Word":
                    base.WaitForElement(By.Id(PCTProjectListPageResource.
                        PCTProjectList_Page_ProjectCreationTool_ProjectType_Word_Id_Locator));
                    IWebElement getWordProjectTypeProperty = base.GetWebElementPropertiesById(PCTProjectListPageResource.
                        PCTProjectList_Page_ProjectCreationTool_ProjectType_Word_Id_Locator);
                    base.PerformMouseClickAction(getWordProjectTypeProperty);
                    break;

                // Select Excel type project
                case "Excel":
                    base.WaitForElement(By.Id(PCTProjectListPageResource.
                        PCTProjectList_Page_ProjectCreationTool_ProjectType_Excel_Id_Locator));
                    IWebElement getExcelProjectTypeProperty = base.GetWebElementPropertiesById(PCTProjectListPageResource.
                        PCTProjectList_Page_ProjectCreationTool_ProjectType_Excel_Id_Locator);
                    base.PerformMouseClickAction(getExcelProjectTypeProperty);
                    break;

                // Select PPT type project
                case "PPT":
                    base.WaitForElement(By.Id(PCTProjectListPageResource.
                        PCTProjectList_Page_ProjectCreationTool_ProjectType_PPT_Id_Locator));
                    IWebElement getPPTProjectTypeProperty = base.GetWebElementPropertiesById(PCTProjectListPageResource.
                        PCTProjectList_Page_ProjectCreationTool_ProjectType_PPT_Id_Locator);
                    base.PerformMouseClickAction(getPPTProjectTypeProperty);
                    break;
            }
            logger.LogMethodExit("PCTProjectListPage", "SelectPCTProjectType", IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close PCT popup by SMS instructor
        /// </summary>
        public void ClosePCTToolPopup()
        {
            // Close PCT popup
            logger.LogMethodEntry("PCTProjectListPage", "closePCTToolPopup", base.IsTakeScreenShotDuringEntryExit);
            this.SelectPCTProjectListPopup();
            base.CloseBrowserWindow();
            logger.LogMethodExit("PCTProjectListPage", "closePCTToolPopup", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the page load status
        /// </summary>
        /// <returns>Return the page load status.</returns>
        public bool ValidateContentLoadInPage()
        {
            logger.LogMethodEntry("PCTProjectListPage", "ValidateContentLoadInPage", base.IsTakeScreenShotDuringEntryExit);
            bool status = false;
            //Wait for Project creation tool windown to load and select the window
            this.SelectPCTProjectListPopup();
            bool myProjectIconstatus = base.IsElementPresent(By.ClassName("projectListTabIcon"), 5);
            bool createProjectIconStatus = base.IsElementPresent(By.Id("CreateProj"), 5);
            if ((myProjectIconstatus && createProjectIconStatus) == true)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            logger.LogMethodExit("PCTProjectListPage", "ValidateContentLoadInPage", base.IsTakeScreenShotDuringEntryExit);
            return status;
        }

    }
}