using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the course publishing actions
    /// </summary>
    public class PublishingNotesPage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(PublishingNotesPage));

        /// <summary>
        /// Publish the course and set the publish status as true in memory
        /// </summary>
        public void PublishCourseInWorkSpace(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Publish Course
            Logger.LogMethodEntry("PublishingNotesPage", "PublishCourseInWorkSpace",
                                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.WaitUntilWindowLoads(PublishingNotesPageResource.
                                         PublishingNotes_Page_PopUp_Window_Name);
                //Select Window
                base.SelectWindow(PublishingNotesPageResource.
                                      PublishingNotes_Page_PopUp_Window_Name);
                //Wait for Window
                base.WaitForElement(By.Id(PublishingNotesPageResource.
                                              PublishingNotes_Page_PublishingNotes_Id_Locator));
                //Insert Publish Notes in Text Box                
                base.FillTextBoxByID(PublishingNotesPageResource.
                 PublishingNotes_Page_PublishingNotes_Id_Locator, PublishingNotesPageResource.
                   PublishingNotes_Page_PublishCourse_Description_Text);
                //Save Course Publishing Description As Browser Selected
                SaveCoursePublishingDetails();
                //Wait For Pop up Get Close
                if (base.IsPopUpClosed(2))
                {
                    // Set Course Publish Status as True
                    SetCoursePublishStatusTrueInMemory(courseTypeEnum);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PublishingNotesPage", "PublishCourseInWorkSpace",
                                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save course publishing details on basis of browser selection.
        /// </summary>
        private void SaveCoursePublishingDetails()
        {
            //Enter Course Publishing Details on Basis of Browser
            Logger.LogMethodEntry("PublishingNotesPage",
                                  "SaveCoursePublishingDetails", base.isTakeScreenShotDuringEntryExit);
            //Enter Publish Details on Basis of Browser
            switch (base.Browser)
            {
                //Firefox Browser Selection
                case PegasusBaseTestFixture.FireFox:
                    this.SaveCoursePublishDescriptionInFirefox();
                    break;
                //Internet Explorer Browser Selection
                case PegasusBaseTestFixture.InternetExplorer:
                    this.SaveCoursePublishDescriptionInInternetExplorer();
                    break;
                //Chrome Browser Selection
                case PegasusBaseTestFixture.Chrome:
                    this.SaveCoursePublishDescriptionInChrome();
                    break;
            }
            Logger.LogMethodExit("PublishingNotesPage",
                                 "SaveCoursePublishingDetails", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save Course Publish Description in Chrome Browser
        /// </summary>
        private void SaveCoursePublishDescriptionInChrome()
        {
            //Save Course Publish Description
            Logger.LogMethodEntry("PublishingNotesPage", "SaveCoursePublishDescriptionInChrome",
                                  base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(PublishingNotesPageResource.
                                          PublishingNotes_Page_Save_Button_Id_Locator));
            IWebElement saveButtononChrome =
                base.GetWebElementPropertiesById(PublishingNotesPageResource.
                                           PublishingNotes_Page_Save_Button_Id_Locator);
            //Mouse Hover on Save Button
            new Actions(WebDriver).
                MoveToElement(saveButtononChrome).Build().Perform();
            new Actions(WebDriver).MoveToElement(saveButtononChrome).Click().Perform();
            Logger.LogMethodExit("PublishingNotesPage", "SaveCoursePublishDescriptionInChrome",
                                          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save Course Publish Description in IE  Browser.
        /// </summary>
        private void SaveCoursePublishDescriptionInInternetExplorer()
        {
            //Save Course Publish Description
            Logger.LogMethodEntry("PublishingNotesPage",
                                  "SaveCoursePublishDescriptionInInternetExplorer",
                                  base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(PublishingNotesPageResource.
                                          PublishingNotes_Page_Save_Button_Id_Locator));
            //Get HTML Element Property
            IWebElement getButtonProperyInInternetExplorer =
                base.GetWebElementPropertiesById(PublishingNotesPageResource.
                                           PublishingNotes_Page_Save_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(getButtonProperyInInternetExplorer);
            Logger.LogMethodExit("PublishingNotesPage",
                                  "SaveCoursePublishDescriptionInInternetExplorer",
                                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save Course Publish Description in FireFox Browser.
        /// </summary>
        private void SaveCoursePublishDescriptionInFirefox()
        {
            //Save Course Publish Description in FF Browser
            Logger.LogMethodEntry("PublishingNotesPage",
                                  "SaveCoursePublishDescriptionInFirefox",
                                  base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(PublishingNotesPageResource.
                                          PublishingNotes_Page_Save_Button_Id_Locator));
            //Insert Publishing Notes in Text Box
            base.FillEmptyTextByID(PublishingNotesPageResource.
                                       PublishingNotes_Page_Save_Button_Id_Locator);
            //Click on Button
            base.ClickButtonByID(PublishingNotesPageResource.
                                     PublishingNotes_Page_Save_Button_Id_Locator);
            Logger.LogMethodExit("PublishingNotesPage",
                                 "SaveCoursePublishDescriptionInFirefox",
                                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Course Publish Status as True In Memory
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        private void SetCoursePublishStatusTrueInMemory(
            Course.CourseTypeEnum courseTypeEnum)
        {
            Course.Get(courseTypeEnum).IsPublished = true;
        }
    }

}
