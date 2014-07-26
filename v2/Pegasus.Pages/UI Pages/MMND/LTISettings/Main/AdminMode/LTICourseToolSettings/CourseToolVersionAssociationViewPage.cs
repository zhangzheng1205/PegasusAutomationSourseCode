using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.LTISettings.Main.AdminMode.LTICourseToolSettings;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class Handles CourseToolVersionAssociationViewPage actions
    /// </summary>
    public class CourseToolVersionAssociationViewPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(CourseToolVersionAssociationViewPage));


        /// <summary>
        /// Click On Next Button.
        /// </summary>
        public void ClickOnNextButton()
        {
            //Click On Next button
            logger.LogMethodEntry("CourseToolVersionAssociationViewPage", "ClickOnNextButton",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Adminiatrative Pages Window
                base.SelectWindow(CourseToolVersionAssociationViewPageResource.
                        CourseToolVersionAssociationView_Page_Window_Name);
                base.WaitForElement(By.Name(CourseToolVersionAssociationViewPageResource.
                    CourseToolVersionAssociatioView_Page_Frame_Name_Locator));
                //Switch to Frame
                base.SwitchToIFrame(CourseToolVersionAssociationViewPageResource.
                    CourseToolVersionAssociatioView_Page_Frame_Name_Locator);
                base.WaitForElement(By.Id(CourseToolVersionAssociationViewPageResource.
                    CourseToolVersionAssociationView_Page_NextButton_Id_Locator));
                //Click On Next Button
                base.ClickButtonById(CourseToolVersionAssociationViewPageResource.
                    CourseToolVersionAssociationView_Page_NextButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("CourseToolVersionAssociationViewPage", "ClickOnNextButton",
              base.isTakeScreenShotDuringEntryExit);
        }

    }
}
