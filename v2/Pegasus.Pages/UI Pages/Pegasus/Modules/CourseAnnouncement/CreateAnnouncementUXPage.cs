using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.CourseAnnouncement;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TodaysView;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Create AnnouncementUX Page Actions
    /// </summary>
    public class CreateAnnouncementUXPage : BasePage
    {

        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(CreateAnnouncementUXPage));


        /// <summary>
        /// Enter Subject text.
        /// </summary>
        /// <param name="courseAnnouncement">This is CourseAnnouncement Subject Text.</param>
        private void EnterAnnouncementSubject(string courseAnnouncement)
        {
            //Enter Subject text
            logger.LogMethodEntry("CreateAnnouncementUXPage", "EnterAnnouncementSubject"
                , base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_SubjectTextbox_Id_Locator));
            // Fill Subject text
            base.FocusOnElementById(CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_SubjectTextbox_Id_Locator);
            base.FillTextBoxById(CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_SubjectTextbox_Id_Locator, courseAnnouncement);
            logger.LogMethodExit("CreateAnnouncementUXPage", "EnterAnnouncementSubject",
                            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// /Enter Description text.
        /// </summary>
        /// <param name="description">This is Announcement Description.</param>
        private void EnterAnnouncementDescription(string description)
        {
            //Enter Description text
            logger.LogMethodEntry("CreateAnnouncementUXPage", "EnterAnnouncementDescription"
                , base.IsTakeScreenShotDuringEntryExit);
            //Select HTML Editor Frame
            this.SelectHTMLEditorFrame();            
            //Wait For Element
            base.WaitForElement(By.Id(CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_ShowHTML_Image_Id_Locator));
            // Click on ShowHTML button
            base.FocusOnElementById(CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_ShowHTML_Image_Id_Locator);
            base.ClickButtonById(CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_ShowHTML_Image_Id_Locator);
            //Wait For HTML Editor
            base.WaitForElement(By.Id(CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_HTMLEditor_Id_Locator));
            // Fill Description text in HTMLEditor textbox
            base.FillTextBoxById(CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_HTMLEditor_Id_Locator, description);
            base.SwitchToDefaultPageContent();
            logger.LogMethodExit("CreateAnnouncementUXPage", "EnterAnnouncementDescription",
                            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select HTML Editor Frame.
        /// </summary>
        private void SelectHTMLEditorFrame()
        {
            //Select HTML Editor Frame
            logger.LogMethodEntry("CreateAnnouncementUXPage", "SelectHTMLEditorFrame"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait For IFrame
            base.WaitForElement(By.Id(CreateAnnouncementUXPageResource.
            CreateAnnouncementUX_Page_Frame_HTMLEditor_Id_Locator));
            //Select HTML Editor Frame
            base.FocusOnElementById(CreateAnnouncementUXPageResource.
            CreateAnnouncementUX_Page_Frame_HTMLEditor_Id_Locator);
            //Switch to Frame
            base.SwitchToIFrame(CreateAnnouncementUXPageResource.
            CreateAnnouncementUX_Page_Frame_HTMLEditor_Id_Locator);
            logger.LogMethodExit("CreateAnnouncementUXPage", "SelectHTMLEditorFrame",
                           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create  course Announcement.
        /// </summary>
        /// <returns>Announcement Details.</returns>
        public string CreateCourseAnnouncement()
        {
            logger.LogMethodEntry("CreateAnnouncementUXPage", "CreateCourseAnnouncement"
                , base.IsTakeScreenShotDuringEntryExit);
            //Generate New Guid announcement Name
            Guid announcementGuid = Guid.NewGuid();
            try
            {
                //Click ManageAll Button
                new MyPegasusUXPage().ClickAnnouncementManageAllButton();
                //Declaration of class object
                AnnouncementDefaultUXPage announcementDefaultUxPage = 
                    new AnnouncementDefaultUXPage();
                //Select Announcement Frame
                announcementDefaultUxPage.SelectAnnouncementFrame();
                //Click on the CreateAnnouncement Button
                new AnnouncementDefaultUXPage().ClickCreateAnnouncementButton();                
                //Enter subject text
                this.EnterAnnouncementSubject(announcementGuid.ToString());
                //Enter description text
                this.EnterAnnouncementDescription(announcementGuid.ToString());
                //Select Announcement frame
                new AnnouncementDefaultUXPage().SelectAnnouncementFrame();
                //Click on To.. Button
                ClickAnnouncementToButton();
                //Select Announcement frame
                new AnnouncementDefaultUXPage().SelectAnnouncementFrame();
                // Add Recipients
                new AnnouncementRecipientListUXPage().AddRecipients();
                //Select Announcement Frame
                announcementDefaultUxPage.SelectAnnouncementFrame();
                // Click Create Button           
                this.ClickAnnouncementCreateButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateAnnouncementUXPage", "CreateCourseAnnouncement",
                            base.IsTakeScreenShotDuringEntryExit);
            return announcementGuid.ToString();
        }

        /// <summary>
        /// Click Announcement 'To' Button.
        /// </summary>
        private void ClickAnnouncementToButton()
        {
            //Clicking To Button
            logger.LogMethodEntry("CreateAnnouncementUXPage", "ClickAnnouncementToButton"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_To_Button_Id_Locator));
            // Focus To Button
            base.FocusOnElementById(CreateAnnouncementUXPageResource.
                     CreateAnnouncementUX_Page_To_Button_Id_Locator);
            //Click on To Button
            base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesById
                (CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_To_Button_Id_Locator));
            logger.LogMethodExit("CreateAnnouncementUXPage", "ClickAnnouncementToButton",
                            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click 'Create' Announcement Button
        /// </summary>
        private void ClickAnnouncementCreateButton()
        {
            // To click on the Create button
            logger.LogMethodEntry("CreateAnnouncementUXPage", "ClickAnnouncementCreateButton"
                , base.IsTakeScreenShotDuringEntryExit);
            //Click on Create button
            base.WaitForElement(By.Id(CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_Create_Button_Id_Locator));
            //Focus on create button
            base.FocusOnElementById(CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_Create_Button_Id_Locator);
            //Click on the Create Button
            base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesById(
                CreateAnnouncementUXPageResource.
                CreateAnnouncementUX_Page_Create_Button_Id_Locator));
            logger.LogMethodExit("CreateAnnouncementUXPage", "ClickAnnouncementCreateButton",
                            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Creation of class announcement
        /// </summary>
        public void CreateClassAnnouncement(Announcement.AnnouncementTypeEnum announcementType)
        {
            //Create Announcement
            logger.LogMethodEntry("CreateAnnouncementPage", "CreateClassAnnouncement",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Declaration of class object
                AnnouncementDefaultUXPage announcementDefaultUxPage = new AnnouncementDefaultUXPage();
                //Select the frame
                announcementDefaultUxPage.SelectAnnouncementLightBoxFrame();
                //Click on the 'Create Announcement' button         
                new AnnouncementDefaultUXPage().ClickCreateAnnouncementButton();
                //Select the frame
                announcementDefaultUxPage.SelectAnnouncementLightBoxFrame();
                //Click on To.. Button
                ClickAnnouncementToButton();
                //Select the frame
                announcementDefaultUxPage.SelectAnnouncementLightBoxFrame();
                //Click on the 'Add Recipients' Button
                new AnnouncementRecipientListUXPage().AddRecipients();
                base.SwitchToDefaultPageContent();
                //Select the frame
                announcementDefaultUxPage.SelectAnnouncementLightBoxFrame();
                //Enter Annoucement Subject And Description
                string getAnnouncementSubject = this.EnterAnnoucementSubjectAndDescription();
                //Select the frame
                announcementDefaultUxPage.SelectAnnouncementLightBoxFrame();
                // Click Create Button           
                this.ClickAnnouncementCreateButton();
                // Store Announcement Details in Memory
                StoreAnnouncementDetailsInMemory(getAnnouncementSubject,announcementType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateAnnouncementPage", "CreateClassAnnouncement",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create  course Announcement in CS
        /// </summary>
        public void CreateCourseAnnouncementInCs()
        {
            logger.LogMethodEntry("CreateAnnouncementUXPage", "CreateCourseAnnouncementInCs"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {  //Declaration of class object
                AnnouncementDefaultUXPage announcementDefaultUxPage = new AnnouncementDefaultUXPage();
                //Select Announcement Frame
                announcementDefaultUxPage.SelectAnnouncementFrameInCs();
                //Click on the CreateAnnouncement Button
                new AnnouncementDefaultUXPage().ClickCreateAnnouncementButton();
                //Enter Annoucement Subject And Description
                this.EnterAnnoucementSubjectAndDescription();
                //Select Announcement frame                
                new AnnouncementDefaultUXPage().SelectAnnouncementFrameInCs();
                //Click on To.. Button
                this.ClickAnnouncementToButton();
                //Select Announcement frame
                new AnnouncementDefaultUXPage().SelectAnnouncementFrameInCs();
                // Add Recipients
                new AnnouncementRecipientListUXPage().AddRecipients();
                //Select Announcement Frame
                announcementDefaultUxPage.SelectAnnouncementFrameInCs();
                // Click Create Button           
                this.ClickAnnouncementCreateButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateAnnouncementUXPage", "CreateCourseAnnouncementInCs",
                            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Annoucement Subject And Description.
        /// </summary>
        private String EnterAnnoucementSubjectAndDescription()
        {
            //Enter subject and  description text 
            logger.LogMethodEntry("CreateAnnouncementUXPage",
            "EnterAnnoucementSubjectAndDescription", base.IsTakeScreenShotDuringEntryExit);
            //Generate New Guid announcement Name
            Guid announcementGuid = Guid.NewGuid();
            //Enter subject text
            this.EnterAnnouncementSubject(announcementGuid.ToString());
            //Enter description text
            this.EnterAnnouncementDescription(announcementGuid.ToString());
            logger.LogMethodExit("CreateAnnouncementUXPage",
            "EnterAnnoucementSubjectAndDescription", base.IsTakeScreenShotDuringEntryExit);
            return announcementGuid.ToString();
        }

        /// <summary>
        /// Store Announcement Details In Memory.
        /// </summary>
        /// <param name="announcmentName">This is Announcement Name.</param>
        /// <param name="announcementTypeEnum">This is Announcement Type Enum.</param>
        private void StoreAnnouncementDetailsInMemory(string announcmentName,
            Announcement.AnnouncementTypeEnum announcementTypeEnum)
        {
            logger.LogMethodEntry("CreateAnnouncementPage", "StoreAnnouncementDetailsInMemory",
               base.IsTakeScreenShotDuringEntryExit);
            Announcement newAnnouncement = new Announcement
            {
                //Store announcement Details
                Name = announcmentName,
                AnnouncementType = announcementTypeEnum,
                IsCreated = true
            };
            newAnnouncement.StoreAnnouncementInMemory();
            logger.LogMethodExit("CreateAnnouncementPage", "StoreAnnouncementDetailsInMemory",
               base.IsTakeScreenShotDuringEntryExit);
        }
        

        /// <summary>
        /// Create Announcement Inside Course
        /// </summary>
        /// <param name="announcementTypeEnum">This is Announcement TypeEnum</param>
        public void CreateAnnouncementInSideCourseHED(Announcement.AnnouncementTypeEnum 
            announcementTypeEnum)
        {
            //Create Announcement Inside Course
            logger.LogMethodEntry("CreateAnnouncementPage", 
                "CreateAnnouncementInSideCourseHED",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Annuncement Frame
                this.SelectAnnouncmentFrame();
                //Click On Create Announcement Button
                new AnnouncementDefaultUXPage().ClickCreateAnnouncementButton();
                //Get Subject Name
                string getSubjectName = EnterAnnoucementSubjectAndDescription();
                //Select Announcement Frame
                this.SelectAnnouncmentFrame();
                //Click on To.. Button
                this.ClickAnnouncementToButton();
                //Add Recipients
                new AnnouncementRecipientListUXPage().AddRecipients();
                //Select Announcement Frame
                this.SelectAnnouncmentFrame();
                //Click On Create Button
                this.ClickAnnouncementCreateButton();
                //Store Announcement Details In Memory
                this.StoreAnnouncementDetailsInMemory(getSubjectName, announcementTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);               
            }
            logger.LogMethodExit("CreateAnnouncementPage", 
                "CreateAnnouncementInSideCourseHED",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select Announcement Frame
        /// </summary>
        public void SelectAnnouncmentFrame()
        {
            //Select Announcement Frame
            logger.LogMethodEntry("CreateAnnouncementPage", "SelectAnnouncmentFrame",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Default Window
                base.SelectDefaultWindow();              
                base.WaitForElement(By.XPath(CreateAnnouncementUXPageResource.
                    CreateAnnouncementUX_Page_Announcement_Frame_Xpath_Locator));
                //Get Iframe Property
                IWebElement getIframeProperty = base.GetWebElementPropertiesByXPath(
                    CreateAnnouncementUXPageResource.
                    CreateAnnouncementUX_Page_Announcement_Frame_Xpath_Locator);
                //Switch to Iframe
                base.SwitchToIFrameByWebElement(getIframeProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("CreateAnnouncementPage", "SelectAnnouncmentFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Create Class Announcement In GlobalHome.
        /// </summary>
        /// <param name="announcementType">This is Announcement Type Enum.</param>
        public void CreateClassAnnouncementInGlobalHome(
            Announcement.AnnouncementTypeEnum announcementType)
        {
            // Create Class Announcement In GlobalHome
            logger.LogMethodEntry("CreateAnnouncementPage",
                "CreateClassAnnouncementInGlobalHome",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Declaration of class object
                AnnouncementDefaultUXPage announcementDefaultUxPage = 
                    new AnnouncementDefaultUXPage();
                //Select the frame
                announcementDefaultUxPage.SelectGlobalAnnouncementframe();
                //Click on the 'Create Announcement' button         
                new AnnouncementDefaultUXPage().ClickCreateAnnouncementButton();
                //Select the frame
                announcementDefaultUxPage.SelectGlobalAnnouncementframe();
                //Click on To.. Button
                ClickAnnouncementToButton();
                //Select the frame
                announcementDefaultUxPage.SelectGlobalAnnouncementframe();
                //Click on the 'Add Recipients' Button
                new AnnouncementRecipientListUXPage().AddRecipients();
                base.SwitchToDefaultPageContent();
                //Select the frame
                announcementDefaultUxPage.SelectGlobalAnnouncementframe();
                //Enter Annoucement Subject And Description
                string getAnnouncementSubject = this.EnterAnnoucementSubjectAndDescription();
                //Select the frame
                announcementDefaultUxPage.SelectGlobalAnnouncementframe();
                // Click Create Button           
                this.ClickAnnouncementCreateButton();
                // Store Announcement Details in Memory
                StoreAnnouncementDetailsInMemory(getAnnouncementSubject, announcementType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateAnnouncementPage",
                "CreateClassAnnouncementInGlobalHome",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Course Announcement In WorkSpace GlobalHome.
        /// </summary>
        /// <param name="announcementTypeEnum">This is Announcement Type Enum.</param>
        public void CreateCourseAnnouncementInWorkSpaceGlobalHome(
            Announcement.AnnouncementTypeEnum announcementTypeEnum)
        {
            // Create Course Announcement In WorkSpace GlobalHome
            logger.LogMethodEntry("CreateAnnouncementPage", 
                "CreateCourseAnnouncementInWorkSpaceGlobalHome",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Intialize the variable
                string announcementName = string.Empty;
                //Create the announcement
                announcementName = this.CreateCourseAnnouncement();
                //Storing Announcement Name In Memory
                this.StoreAnnouncementDetailsInMemory(
                    announcementName, announcementTypeEnum);
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateAnnouncementPage",
                "CreateCourseAnnouncementInWorkSpaceGlobalHome",
               base.IsTakeScreenShotDuringEntryExit);
        }        
    }
}
