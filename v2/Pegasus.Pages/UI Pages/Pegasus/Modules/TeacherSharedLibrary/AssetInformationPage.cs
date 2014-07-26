using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Text;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeacherSharedLibrary;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handles the Asset Information Page actions
    /// </summary>
    public class AssetInformationPage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(AssetInformationPage));


        /// <summary>
        /// Select Course Materials Window
        /// </summary>
        private void SelectCourseMaterialsWindow()
        {
            //Select Course Materials Window
            logger.LogMethodEntry("AssetInformationPage", "SelectCourseMaterialsWindow",
                  base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(AssetInformationPageResource.
                AssetInformation_Page_CourseMaterials_Window_Name);
            //Select Course Materials Window
            base.SelectWindow(AssetInformationPageResource.
                AssetInformation_Page_CourseMaterials_Window_Name);
            logger.LogMethodExit("AssetInformationPage", "SelectCourseMaterialsWindow",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch To Iframe
        /// </summary>
        private void SwitchToIFrame()
        {
            //Switch To Iframe
            logger.LogMethodEntry("AssetInformationPage", "SwitchToIFrame",
            base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AssetInformationPageResource.
                AssetInfomation_Page_Frame_Id_Locator));
            //Switch To Iframe
            base.SwitchToIFrameById(AssetInformationPageResource.
                AssetInfomation_Page_Frame_Id_Locator);
            logger.LogMethodExit("AssetInformationPage", "SwitchToIFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Name
        /// </summary>
        /// <returns>Activity Name</returns>
        public String GetActivityName()
        {
            logger.LogMethodEntry("AssetInformationPage", "GetActivityName",
                   base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getActivityName = string.Empty;
            //Select Course Materials Window
            try
            {
                this.SelectCourseMaterialsWindow();
                //Switch To Iframe
                this.SwitchToIFrame();
                base.WaitForElement(By.Id(AssetInformationPageResource.
                    AssetInfomation_Page_Title_Id_Locator));
                //Get Activity Name
                getActivityName = base.GetElementTextById(AssetInformationPageResource.
                    AssetInfomation_Page_Title_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssetInformationPage", "GetActivityName",
                 base.isTakeScreenShotDuringEntryExit);
            return getActivityName;
        }


    }
}
