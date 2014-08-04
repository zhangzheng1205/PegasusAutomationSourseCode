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
    /// This class Handles CourseToolAssociationViewPage actions
    /// </summary>
    public  class CourseToolAssociationViewPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance
            (typeof(CourseToolAssociationViewPage));

        /// <summary>
        /// Click On Course Tool Associated.
        /// </summary>
        public void ClickOnCourseToolAssociated()
        {
            //Click On Tool Associated Button
            logger.LogMethodEntry("CourseToolAssociationViewPage", "ClickOnCourseToolAssociated",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath(CourseToolAssociationViewPageResource.
                    CourseToolAssociationView_Page_CourseCount_Xpath_Locator));
                //Get Course Providers Count
                int getCourseCount = base.GetElementCountByXPath(CourseToolAssociationViewPageResource.
                    CourseToolAssociationView_Page_CourseCount_Xpath_Locator);
                for (int i = Convert.ToInt32(CourseToolAssociationViewPageResource.
                    CourseToolAssociationView_Page_Loop_Initializer); i <= getCourseCount; i++)
                {
                    base.WaitForElement(By.XPath(string.Format(CourseToolAssociationViewPageResource.
                        CourseToolAssociationView_Page_CourseProvider_Text_XpathLocator, i)));
                    //Get Course Provider Text
                    string getCourseProviderText =
                        base.GetElementTextByXPath(string.Format(CourseToolAssociationViewPageResource.
                        CourseToolAssociationView_Page_CourseProvider_Text_XpathLocator, i));
                    if (getCourseProviderText == CourseToolAssociationViewPageResource.
                        CourseToolAssociationView_Page_CourseProvider_Name)
                    {
                        base.WaitForElement(By.XPath(string.Format(CourseToolAssociationViewPageResource.
                            CourseToolAssociationView_Page_EditIcon_XpathLocator, i)));
                        //Click on Edit Icon
                        base.ClickButtonByXPath((string.Format(CourseToolAssociationViewPageResource.
                            CourseToolAssociationView_Page_EditIcon_XpathLocator, i)));
                        break;
                    }
                }                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                  
            }
            logger.LogMethodExit("CourseToolAssociationViewPage", "ClickOnCourseToolAssociated",
              base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
