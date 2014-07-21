using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  This class handles Pegasus Shared Library Preferences Page Actions
    /// </summary>
    public class SharedLibraryPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(SharedLibraryPreferencesPage));

        /// <summary>
        /// Sets 'Shared Libraries' Preferences
        /// </summary>
        public void SetSharedLibrariesPreferences()
        {
            //Sets 'Shared Libraries' Preferences
            logger.LogMethodEntry("SharedLibraryPreferencesPage", "SetSharedLibrariesPreferences",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the Shared Library Link
                this.ClickOnSharedLibrariesLink();
                //Search The Master Library
                this.SearchTheMasterLibrary();
                //Select the CheckBox
                this.SelectTheCheckBoxAndAssociateTheMasterLibraryToCourse();
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SharedLibraryPreferencesPage", "SetSharedLibrariesPreferences",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Check Box And Associate The Master Library to Course
        /// </summary>
        private void SelectTheCheckBoxAndAssociateTheMasterLibraryToCourse()
        {
            //Select The Check Box And Associate The Master Library to Course
            logger.LogMethodEntry("SharedLibraryPreferencesPage",
                "SelectTheCheckBoxAndAssociateTheMasterLibraryToCourse", 
                base.isTakeScreenShotDuringEntryExit);
            //Select the Frame leftSCLFrame
            base.WaitForElement(By.Id(SharedLibraryPreferencesPageResource.
                SharedLibraryPreferencesPage_Frame_SharedLibraries_Id_Locator));
            base.SwitchToIFrame(SharedLibraryPreferencesPageResource.
                SharedLibraryPreferencesPage_Frame_SharedLibraries_Id_Locator);
            base.WaitForElement(By.Id(SharedLibraryPreferencesPageResource.
                SharedLibraryPreferencesPage_Checkbox_SearchedMasterLibrary_Id_Locator));
            //Click onthe checkbox for ML            
            base.ClickCheckBoxById(SharedLibraryPreferencesPageResource.
                SharedLibraryPreferencesPage_Checkbox_SearchedMasterLibrary_Id_Locator);
            //Select the Main Frame
            new CourseCopyPreferencesPage().SelectTheMainPreferencesFrame();
            //Click onthe Enroll button
            base.FocusOnElementByID(SharedLibraryPreferencesPageResource.
                SharedLibraryPreferencesPage_Image_AddMasterLibraryToCourse_Id_Locator);
            base.ClickButtonByID(SharedLibraryPreferencesPageResource.
                SharedLibraryPreferencesPage_Image_AddMasterLibraryToCourse_Id_Locator);
            logger.LogMethodExit("SharedLibraryPreferencesPage",
                "SelectTheCheckBoxAndAssociateTheMasterLibraryToCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Master Library
        /// </summary>
        private void SearchTheMasterLibrary()
        {
            //Search The Master Library
            logger.LogMethodEntry("SharedLibraryPreferencesPage","SearchTheMasterLibrary",
                base.isTakeScreenShotDuringEntryExit);
            //Select the Main Frame
            new CourseCopyPreferencesPage().SelectTheMainPreferencesFrame();
            //Wait for the textbox
            base.WaitForElement(By.Id(SharedLibraryPreferencesPageResource.
                SharedLibraryPreferencesPage_Textbox_SharedLibraryCourse_Id_Locator));
            //Get the ML from Memory
            Course getMasterLibrary = Course.Get(Course.CourseTypeEnum.NovaNETMasterLibrary);
            base.ClearTextByID(SharedLibraryPreferencesPageResource.
                SharedLibraryPreferencesPage_Textbox_SharedLibraryCourse_Id_Locator);
            base.FillTextBoxByID(SharedLibraryPreferencesPageResource.
                SharedLibraryPreferencesPage_Textbox_SharedLibraryCourse_Id_Locator, 
                getMasterLibrary.Name);
            //Click on the Search Button
            base.ClickLinkById(SharedLibraryPreferencesPageResource.
                SharedLibraryPreferencesPage_Button_Search_Id_Locator);
            logger.LogMethodExit("SharedLibraryPreferencesPage", "SearchTheMasterLibrary",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Shared Libraries Link
        /// </summary>
        private void ClickOnSharedLibrariesLink()
        {
            //Click On Shared Libraries Link
            logger.LogMethodEntry("SharedLibraryPreferencesPage", "ClickOnSharedLibrariesLink",
                base.isTakeScreenShotDuringEntryExit);
            //Select the Main Frame
            new CourseCopyPreferencesPage().SelectTheMainPreferencesFrame();
            //Click on the Shared Libraries link
            base.WaitForElement(By.Id(SharedLibraryPreferencesPageResource.
                SharedLibraryPreferencesPage_SharedLibraries_Link_Id_Locator));
            base.ClickLinkById(SharedLibraryPreferencesPageResource.
                SharedLibraryPreferencesPage_SharedLibraries_Link_Id_Locator);
            logger.LogMethodExit("SharedLibraryPreferencesPage", "ClickOnSharedLibrariesLink",
                base.isTakeScreenShotDuringEntryExit);
        }


    }
}
